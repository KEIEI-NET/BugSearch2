//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : BL�R�[�h�K�C�h�}�X�^
// �v���O�����T�v   : BL�R�[�h�K�C�h�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �E �K�j
// �� �� ��  2008/09/30  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  12694       �쐬�S�� : �H���@�b�D
// �C �� ��  2009/03/24  �C�����e : �u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
//----------------------------------------------------------------------------//
#define DELETE_DATE_DEPEND_ON_SUB_TABLE // ���C���e�[�u���̍폜�����T�u�e�[�u���Ɋ֘A������t���O

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Resources;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// BL�R�[�h�K�C�h�}�X�^UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: BL�R�[�h�K�C�h�}�X�^��UI�ݒ���s���܂��B</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/09/30</br>
    /// <br>Note		: �u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���</br>
    /// <br>Programmer	: 30434 �H���@�b�D</br>
    /// <br>Date		: 2009/03/24</br>
    /// </remarks>
    public partial class PMKHN09230UA : Form, IMasterMaintenanceArrayType
    {
        #region �� Constants

        // �v���O����ID
        private const string ASSEMBLY_ID = "PMKHN09230U";

        // �e�[�u������
        private const string TABLE_MAIN = "MainTable";
        private const string TABLE_DETAIL = "DetailTable";

        // �f�[�^�r���[�^�C�g��
        private const string GRIDTITLE_SECTION = "���_";
        private const string GRIDTITLE_BLGOODSCODE = "BL����";

        // �f�[�^�r���[�\���p
        private const string VIEW_SECTIONCODE = "���_�R�[�h";
        private const string VIEW_SECTIONNAME = "���_��";
        private const string VIEW_DELETEDATE = "�폜��";
        private const string VIEW_BLGOODSCODE = "BL����";
        private const string VIEW_BLGOODSCODENAME = "BL���ޖ�";

        // �O���b�h��^�C�g��
        private const string COLUMN_BLGOODSCODE = "BLGoodsCode";
        private const string COLUMN_BLGOODSCODEGUIDE = "BLGoodsCodeGuide";
        private const string COLUMN_BLGOODSCODENAME = "BLGoodsCodeName";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // �e�O���b�h�s��
        private const int ROWCOUNT = 18;

        #endregion �� Constants


        #region �� Private Members

        private bool _canClose;
        private bool _canDelete;
        private bool _canNew;
        private bool _canPrint;

        private MGridDisplayLayout _defaultGridDisplayLayout;

        private string _targetTableName;
        private int _mainDataIndex;
        private int _detailDataIndex;

        private string _enterpriseCode;

        private BLCodeGuideAcs _bLCodeGuidAcs;              // BL�R�[�h�K�C�h�}�X�^�A�N�Z�X�N���X
        private SecInfoAcs _secInfoAcs;                     // ���_�}�X�^�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs;               // ���_���ݒ�}�X�^�A�N�Z�X�N���X
        private BLGoodsCdAcs _bLGoodsCdAcs;                 // BL�R�[�h�}�X�^�A�N�Z�X�N���X

        private List<BLCodeGuide> _bLCodeGuideListClone;    // BL�R�[�h�K�C�h�}�X�^���X�gClone
        private UltraGrid[] _bLGoodsCode_Grid;              // �O���b�h�p�z��

        private ControlScreenSkin _controlScreenSkin;       // ��ʃf�U�C���ύX�N���X

        private Dictionary<string, SecInfoSet> _mainList;
        private List<BLCodeGuide> _detailList;

        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
		
        #endregion �� Private Members


        # region �� Constructor

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^UI�N���X�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        public PMKHN09230UA()
        {
            InitializeComponent();

            this._canClose = true;
            this._canDelete = true;
            this._canNew = true;
            this._canPrint = false;
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;

            // �e��C���f�b�N�X������
            this._mainDataIndex = -1;
            this._detailDataIndex = -1;

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._controlScreenSkin = new ControlScreenSkin();

            // �C���X�^���X����
            this._bLCodeGuidAcs = new BLCodeGuideAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._bLGoodsCdAcs = new BLGoodsCdAcs();

            // �O���b�h��z��ɃZ�b�g
            this._bLGoodsCode_Grid = new UltraGrid[15];
            this._bLGoodsCode_Grid[0] = this.uGrid_BLGoodsCode1;
            this._bLGoodsCode_Grid[1] = this.uGrid_BLGoodsCode2;
            this._bLGoodsCode_Grid[2] = this.uGrid_BLGoodsCode3;
            this._bLGoodsCode_Grid[3] = this.uGrid_BLGoodsCode4;
            this._bLGoodsCode_Grid[4] = this.uGrid_BLGoodsCode5;
            this._bLGoodsCode_Grid[5] = this.uGrid_BLGoodsCode6;
            this._bLGoodsCode_Grid[6] = this.uGrid_BLGoodsCode7;
            this._bLGoodsCode_Grid[7] = this.uGrid_BLGoodsCode8;
            this._bLGoodsCode_Grid[8] = this.uGrid_BLGoodsCode9;
            this._bLGoodsCode_Grid[9] = this.uGrid_BLGoodsCode10;
            this._bLGoodsCode_Grid[10] = this.uGrid_BLGoodsCode11;
            this._bLGoodsCode_Grid[11] = this.uGrid_BLGoodsCode12;
            this._bLGoodsCode_Grid[12] = this.uGrid_BLGoodsCode13;
            this._bLGoodsCode_Grid[13] = this.uGrid_BLGoodsCode14;
            this._bLGoodsCode_Grid[14] = this.uGrid_BLGoodsCode15;

            // DataSet����\�z
            this.Bind_DataSet = new DataSet();
            DataSetColumnConstruction();
        }

        # endregion �� Constructor


        #region �� IMasterMaintenanceArrayType �����o

        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
        public bool CanClose
        {
            get
            {
                return _canClose;
            }
            set
            {
                _canClose = value;
            }
        }

        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get { return _canDelete; }
        }

        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get { return _canNew; }
        }

        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get { return _canPrint; }
        }

        /// <summary>�O���b�h�̃f�t�H���g�\���ʒu�v���p�e�B</summary>
        /// <value>�O���b�h�̃f�t�H���g�\���ʒu���擾���܂��B</value>
        public MGridDisplayLayout DefaultGridDisplayLayout
        {
            get { return _defaultGridDisplayLayout; }
        }

        /// <summary>����Ώۃf�[�^�e�[�u�����̃v���p�e�B</summary>
        /// <value>����Ώۃf�[�^�̃e�[�u�����̂��擾�܂��͐ݒ肵�܂��B</value>
        public string TargetTableName
        {
            get
            {
                return _targetTableName;
            }
            set
            {
                _targetTableName = value;
            }
        }

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            //==============================
            // ���C��
            //==============================
            Hashtable main = new Hashtable();

            main.Add(VIEW_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));    // ADD 2008/03/24 �s��Ή�[12694]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            main.Add(VIEW_SECTIONCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            main.Add(VIEW_SECTIONNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            //==============================
            // �ڍ�
            //==============================
            Hashtable detail = new Hashtable();

            detail.Add(VIEW_SECTIONCODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            detail.Add(VIEW_BLGOODSCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            detail.Add(VIEW_BLGOODSCODENAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            detail.Add(VIEW_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));

            appearanceTable = new Hashtable[2];
            appearanceTable[0] = main;
            appearanceTable[1] = detail;
        }

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h�\���p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            // �O���b�h�\���p�f�[�^�Z�b�g��ݒ�
            bindDataSet = this.Bind_DataSet;

            // �Q�̃e�[�u�����̂̐ݒ�
            string[] strRet = { TABLE_MAIN, TABLE_DETAIL };
            tableName = strRet;
        }

        /// <summary>
        /// �_���폜�f�[�^���o�\�ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�_���폜�f�[�^���o�\�ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�f�[�^�̒��o���\���ǂ����̐ݒ��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDeleteButton = { true, false };   // MOD 2008/03/24 �s��Ή�[12694]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� { false, true }��{ true, false }
            return logicalDeleteButton;
        }

        /// <summary>
        /// �O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g�擾����
        /// </summary>
        /// <returns>�O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            bool[] defaultAutoFill = { true, true };
            return defaultAutoFill;
        }

        /// <summary>
        /// �폜�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�폜�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �폜�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] deleteButton = { true, false };
            return deleteButton;
        }

        /// <summary>
        /// �O���b�h�A�C�R�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�A�C�R�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�C�R����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public Image[] GetGridIconList()
        {
            Image[] gridIcon = { null, null };
            return gridIcon;
        }

        /// <summary>
        /// �O���b�h�^�C�g�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�^�C�g�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃^�C�g����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { GRIDTITLE_SECTION, GRIDTITLE_BLGOODSCODE };
            return gridTitle;
        }

        /// <summary>
        /// �C���{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] modifyButton = { true, false };
            return modifyButton;
        }

        /// <summary>
        /// �V�K�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�V�K�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �V�K�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] newButton = { true, false };
            return newButton;
        }

        /// <summary>
        /// �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g�ݒ菈��
        /// </summary>
        /// <param name="indexList">�f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g��ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;
            this._mainDataIndex = intVal[0];
            this._detailDataIndex = intVal[1];
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public int Delete()
        {
            // �_���폜����
            bool bStatus = LogicalDeleteProc();
            if (!bStatus)
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// ���׃f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            ArrayList bLCodeGuideList;

            // ���ݕێ����Ă���f�[�^���N���A����
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Clear();

            // ADD 2009/03/24 �s��Ή�[12694]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // readCount�����̏ꍇ�A�����I��
            if (readCount < 0) return 0;
            // ADD 2009/03/24 �s��Ή�[12694]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

            // �I������Ă���f�[�^���擾����
            string sectionCode = (string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SECTIONCODE];

            // ���������i�_���폜�܂ށj
            int status = this._bLCodeGuidAcs.Search(out bLCodeGuideList, this._enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetDataAll);
            
            // BL�R�[�h�K�C�h���L���b�V��
            CacheBLCodeGuideList(ConvertSectionCodeNumber(sectionCode), bLCodeGuideList);   // ADD 2009/03/24 �s��Ή�[12694]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �擾�����N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
                        {
                            // DataSet�W�J����
                            DetailToDataSet(bLCodeGuide, index);
                            index++;
                        }

                        totalCount = bLCodeGuideList.Count;

                        if (status == 0)
                        {
                            this._canNew = false;
                        }
                        else
                        {
                            this._canNew = true;
                        }

                        break;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "DetailsDataSearch",
                                       "�ǂݍ��݂Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        totalCount = 0;

                        break;
                    }
            }

            // ���C���e�[�u���̍폜�����T�u�e�[�u������ݒ�
            SetDeleteDateOfMainTable(); // ADD 2009/03/24 �s��Ή�[12694]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            return 0;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            // ���ݕێ����Ă���f�[�^���N���A����
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Clear();

            this._mainList = new Dictionary<string, SecInfoSet>();
            this._detailList = new List<BLCodeGuide>();

            // ���_�}�X�^�ɓo�^����Ă��鋒�_�ꗗ���擾
            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._mainList.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }

            ArrayList retList;

            int status = this._bLCodeGuidAcs.Search(out retList, this._enterpriseCode, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        foreach (BLCodeGuide bLCodeGuide in retList)
                        {
                            this._detailList.Add(bLCodeGuide);
                        }

                        break;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Search",
                                       "�ǂݍ��݂Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        totalCount = 0;

                        break;
                    }
            }

            // �ǂݍ��񂾃C���X�^���X�̂��ꂼ����f�[�^�Z�b�g�ɓW�J
            int index = 0;
            foreach (SecInfoSet secInfoSet in this._mainList.Values)
            {
                // DataSet�W�J����
                MainToDataSet(secInfoSet, index);
                index++;
            }

            totalCount = this._mainList.Count;

            // ���C���e�[�u���̍폜�����T�u�e�[�u������ݒ�
            SetDeleteDateOfMainTable(); // ADD 2009/03/24 �s��Ή�[12694]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            return 0;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // ������
            return 0;
        }

        /// <summary>
        /// ���׃l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            // ������
            return 0;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        public int Print()
        {
            // ������
            return 0;
        }

        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;

        #endregion �� IMasterMaintenanceArrayType �����o


        #region �� Private Methods

        /// <summary>
        /// ���_���擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_��</returns>
        /// <remarks>
        /// <br>Note       : ���_�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // �S�Ђ͑ΏۊO
            if ((sectionCode.Trim() == "") || (sectionCode.Trim().PadLeft(2, '0') == "00"))
            {
                return "";
            }

            this._secInfoAcs.ResetSectionInfo();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                        {
                            sectionName = secInfoSet.SectionGuideNm.Trim();
                            break;
                        }
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        /// <summary>
        /// BL�R�[�h���擾����
        /// </summary>
        /// <param name="bLGoodsCode">BL�R�[�h</param>
        /// <returns>BL�R�[�h��</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private string GetBLGoodsCodeName(int bLGoodsCode)
        {
            string bLGoodsCodeName = "";

            try
            {
                BLGoodsCdUMnt bLGoodsCdUMnt;

                // �Ǎ�
                int status = this._bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, bLGoodsCode);
                if (status == 0)
                {
                    if (bLGoodsCdUMnt.LogicalDeleteCode == 0)
                    {
                        bLGoodsCodeName = bLGoodsCdUMnt.BLGoodsHalfName.Trim();
                    }
                }
            }
            catch
            {
                bLGoodsCodeName = "";
            }

            return bLGoodsCodeName;
        }

        /// <summary>
        /// DataSet�W�J����(���C���e�[�u��)
        /// </summary>
        /// <param name="bLCodeGuide">BL�R�[�h�K�C�h�}�X�^</param>
        /// <param name="index">�s�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�}�X�^��DataSet�ɓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void MainToDataSet(SecInfoSet secInfoSet, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[TABLE_MAIN].NewRow();
                this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count - 1;
            }

            // �폜��
            // ADD 2008/03/24 �s��Ή�[12694]���F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_DELETEDATE] = GetDeleteDate(secInfoSet);

            // ���_�R�[�h
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_SECTIONCODE] = secInfoSet.SectionCode.Trim();
            // ���_����
            this.Bind_DataSet.Tables[TABLE_MAIN].Rows[index][VIEW_SECTIONNAME] = GetSectionName(secInfoSet.SectionCode.Trim());
        }

        // ADD 2009/03/24 �s��Ή�[12694]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
        /// <summary>
        /// ���C���e�[�u���̍폜�����擾���܂��B
        /// </summary>
        /// <param name="makerUMnt">BL�R�[�h�K�C�h�}�X�^</param>
        /// <returns>���C���e�[�u���̍폜���i�폜����Ă��Ȃ��ꍇ�A<c>string.Empty</c>��Ԃ��܂��B�j</returns>
        private string GetDeleteDate(SecInfoSet secInfoSet)
        {
            if (secInfoSet.LogicalDeleteCode.Equals(0))
            {
                return string.Empty;
            }
            else
            {
                return secInfoSet.UpdateDateTimeJpInFormal;
            }
        }

        #region <BL�R�[�h�K�C�h�̃L���b�V��/>

        /// <summary>BL�R�[�h�K�C�h�̃L���b�V��</summary>
        /// <remarks>�L�[�F���_�R�[�h</remarks>
        private readonly IDictionary<int, ArrayList> _blCodeGuideListCacheMap = new Dictionary<int, ArrayList>();
        /// <summary>
        /// BL�R�[�h�K�C�h�̃L���b�V�����擾���܂��B
        /// </summary>
        private IDictionary<int, ArrayList> BLCodeGuideListCacheMap
        {
            get { return _blCodeGuideListCacheMap; }
        }

        /// <summary>
        /// ���_�R�[�h�̐��l�ɕϊ����܂��B
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_�R�[�h�̐��l</returns>
        private int ConvertSectionCodeNumber(string sectionCode)
        {
            return string.IsNullOrEmpty(sectionCode.Trim()) ? 0 : int.Parse(sectionCode.Trim());
        }

        /// <summary>
        /// BL�R�[�h�K�C�h���L���b�V�����܂��B
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="blCodeGuideList">BL�R�[�h�K�C�h�̃��R�[�h���X�g</param>
        private void CacheBLCodeGuideList(
            int sectionCode,
            ArrayList blCodeGuideList
        )
        {
            if (BLCodeGuideListCacheMap.ContainsKey(sectionCode))
            {
                BLCodeGuideListCacheMap.Remove(sectionCode);
            }
            BLCodeGuideListCacheMap.Add(sectionCode, (blCodeGuideList != null ? blCodeGuideList : new ArrayList()));
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�̃L���b�V�������Z�b�g���܂��B
        /// </summary>
        private void ResetBLCodeGuideCache()
        {
            BLCodeGuideListCacheMap.Clear();
        }

        #endregion  // <BL�R�[�h�K�C�h�̃L���b�V��/>

        /// <summary>
        /// ���C���e�[�u���̍폜����ݒ肵�܂��B
        /// </summary>
        [Conditional("DELETE_DATE_DEPEND_ON_SUB_TABLE")]
        private void SetDeleteDateOfMainTable()
        {
            const string MAIN_TABLE_NAME        = TABLE_MAIN;
            const string RELATION_COLUMN_NAME   = VIEW_SECTIONCODE;
            const string SUB_TABLE_NAME         = TABLE_DETAIL;
            const string DELETE_DATE_COLUMN_NAME= VIEW_DELETEDATE;

            foreach (DataRow mainRow in this.Bind_DataSet.Tables[MAIN_TABLE_NAME].Rows)
            {
                // �Ή�����T�u�e�[�u���̃��R�[�h�𒊏o
                string relationColumn = mainRow[RELATION_COLUMN_NAME].ToString();
                DataRow[] foundSubRows = this.Bind_DataSet.Tables[SUB_TABLE_NAME].Select(
                    RELATION_COLUMN_NAME + "='" + relationColumn.ToString() + "'"
                );
                Debug.WriteLine("�֘A = " + relationColumn.ToString() + ":" + foundSubRows.Length.ToString() + "��");

                if (foundSubRows.Length.Equals(0))
                {
                    #region �T�u�e�[�u���ɊY�����R�[�h�������ꍇ�ADB�������ʁi�L���b�V���j���ݒ�

                    // ���_�R�[�h�w�� BL�R�[�h�K�C�h���������i�_���폜�܂ށj
                    int sectionCode = ConvertSectionCodeNumber(relationColumn);
                    ArrayList blCodeGuideList = null;
                    if (BLCodeGuideListCacheMap.ContainsKey(sectionCode))
                    {
                        blCodeGuideList = BLCodeGuideListCacheMap[sectionCode];
                    }
                    else
                    {
                        int status = this._bLCodeGuidAcs.Search(out blCodeGuideList, this._enterpriseCode, relationColumn, ConstantManagement.LogicalMode.GetDataAll);
                        CacheBLCodeGuideList(sectionCode, blCodeGuideList);
                    }
                    if (blCodeGuideList == null || blCodeGuideList.Count.Equals(0)) continue;

                    // �폜�����~���Œ��o
                    int deleteRowCount = 0;
                    SortedList<string, string> sortedDeleteDateList = new SortedList<string, string>(
                        new ReverseComparer<string>()
                    );
                    foreach (BLCodeGuide blCodeGuide in blCodeGuideList)
                    {
                        if (blCodeGuide.LogicalDeleteCode.Equals(0)) continue;

                        deleteRowCount++;
                        if (!sortedDeleteDateList.ContainsKey(blCodeGuide.UpdateDateTimeJpInFormal))
                        {
                            sortedDeleteDateList.Add(
                                blCodeGuide.UpdateDateTimeJpInFormal,
                                blCodeGuide.UpdateDateTimeJpInFormal
                            );
                        }
                    }

                    // ���R�[�h���S���폜����Ă���ꍇ
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(blCodeGuideList.Count))
                    {
                        deleteDate = sortedDeleteDateList.Values[0];
                    }
                    mainRow[DELETE_DATE_COLUMN_NAME] = deleteDate;

                    #endregion  // �T�u�e�[�u���ɊY�����R�[�h�������ꍇ�ADB�������ʁi�L���b�V���j���ݒ�
                }
                else
                {
                    #region �T�u�e�[�u���ɊY�����R�[�h������ꍇ�A�T�u�e�[�u�����ݒ�

                    // �폜�����~���ɒ��o
                    int deleteRowCount = 0;
                    SortedList<string, string> sortedDeleteDateList = new SortedList<string, string>(
                        new ReverseComparer<string>()
                    );
                    foreach (DataRow subRow in foundSubRows)
                    {
                        Debug.WriteLine("�폜���F" + subRow[DELETE_DATE_COLUMN_NAME].ToString());
                        if (string.IsNullOrEmpty(subRow[DELETE_DATE_COLUMN_NAME].ToString()))
                        {
                            continue;
                        }

                        deleteRowCount++;
                        if (!sortedDeleteDateList.ContainsKey(subRow[DELETE_DATE_COLUMN_NAME].ToString()))
                        {
                            sortedDeleteDateList.Add(
                                subRow[DELETE_DATE_COLUMN_NAME].ToString(),
                                subRow[DELETE_DATE_COLUMN_NAME].ToString()
                            );
                        }
                    }

                    // �T�u�e�[�u�����S���폜����Ă���ꍇ
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(foundSubRows.Length))
                    {
                        deleteDate = sortedDeleteDateList.Values[0];
                    }
                    mainRow[DELETE_DATE_COLUMN_NAME] = deleteDate;

                    #endregion  // �T�u�e�[�u���ɊY�����R�[�h������ꍇ�A�T�u�e�[�u�����ݒ�
                }
            }
        }
        // ADD 2009/03/24 �s��Ή�[12694]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

        /// <summary>
        /// DataSet�W�J����(�ڍ׃e�[�u��)
        /// </summary>
        /// <param name="bLCodeGuide">BL�R�[�h�K�C�h�}�X�^</param>
        /// <param name="index">�s�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�}�X�^��DataSet�ɓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void DetailToDataSet(BLCodeGuide bLCodeGuide, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[TABLE_DETAIL].NewRow();
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[TABLE_DETAIL].Rows.Count - 1;
            }

            // ���_�R�[�h
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_SECTIONCODE] = bLCodeGuide.SectionCode.ToString().Trim();   // ADD 2008/03/24 �s��Ή�[12694]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

            // BL�R�[�h
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_BLGOODSCODE] = bLCodeGuide.BLGoodsCode.ToString("00000");
            // BL����
            this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_BLGOODSCODENAME] = GetBLGoodsCodeName(bLCodeGuide.BLGoodsCode);
            // �폜��
            if (bLCodeGuide.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[TABLE_DETAIL].Rows[index][VIEW_DELETEDATE] = bLCodeGuide.UpdateDateTimeJpInFormal;
            }
        }

        /// <summary>
        /// DataSet����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet������\�z���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //==============================
            // ���C��
            //==============================
            DataTable mainTable = new DataTable(TABLE_MAIN);

            mainTable.Columns.Add(VIEW_DELETEDATE, typeof(string)); // ADD 2008/03/24 �s��Ή�[12694]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            mainTable.Columns.Add(VIEW_SECTIONCODE, typeof(string));
            mainTable.Columns.Add(VIEW_SECTIONNAME, typeof(string));

            //==============================
            // �ڍ�
            //==============================
            DataTable detailTable = new DataTable(TABLE_DETAIL);

            detailTable.Columns.Add(VIEW_SECTIONCODE, typeof(string));  // ADD 2008/03/24 �s��Ή�[12694]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            detailTable.Columns.Add(VIEW_BLGOODSCODE, typeof(string));
            detailTable.Columns.Add(VIEW_BLGOODSCODENAME, typeof(string));
            detailTable.Columns.Add(VIEW_DELETEDATE, typeof(string));

            this.Bind_DataSet.Tables.Add(mainTable);
            this.Bind_DataSet.Tables.Add(detailTable);
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ������������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void ScreenClear()
        {
            // ���_
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();

            // �O���b�h
            for (int index = 0; index < this._bLGoodsCode_Grid.Length; index++)
            {
                for (int rowIndex = 0; rowIndex < this._bLGoodsCode_Grid[index].Rows.Count; rowIndex++)
                {
                    this._bLGoodsCode_Grid[index].Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Value = DBNull.Value;
                    this._bLGoodsCode_Grid[index].Rows[rowIndex].Cells[COLUMN_BLGOODSCODENAME].Value = DBNull.Value;
                }

                this._bLGoodsCode_Grid[index].ActiveCell = null;
                this._bLGoodsCode_Grid[index].ActiveRow = null;
            }

            // �^�u
            this.MainTabControl.Tabs[0].Active = true;
            this.MainTabControl.Tabs[0].Selected = true;
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // �R���g���[���T�C�Y�ݒ�
            this.tEdit_SectionCode.Size = new Size(28, 24);
            this.tEdit_SectionName.Size = new Size(108, 24);

            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList16 = IconResourceManagement.ImageList16;
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Ok_Button.ImageList = imageList24;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.ImageList = imageList24;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.ImageList = imageList24;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.ImageList = imageList24;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.SectionGuide_Button.ImageList = imageList16;
            this.SectionGuide_Button.Appearance.Image = Size16_Index.STAR1;

            // �O���b�h�\�z
            for (int index = 0; index < this._bLGoodsCode_Grid.Length; index++)
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add(COLUMN_BLGOODSCODE, typeof(string));
                dataTable.Columns.Add(COLUMN_BLGOODSCODEGUIDE, typeof(string));
                dataTable.Columns.Add(COLUMN_BLGOODSCODENAME, typeof(string));

                for (int rowIndex = 0; rowIndex < ROWCOUNT; rowIndex++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[COLUMN_BLGOODSCODE] = DBNull.Value;
                    dataRow[COLUMN_BLGOODSCODEGUIDE] = DBNull.Value;
                    dataRow[COLUMN_BLGOODSCODENAME] = DBNull.Value;
                    dataTable.Rows.Add(dataRow);
                }

                this._bLGoodsCode_Grid[index].DataSource = dataTable;

                this._bLGoodsCode_Grid[index].Tag = index;

                ColumnsCollection columns = this._bLGoodsCode_Grid[index].DisplayLayout.Bands[0].Columns;

                // �w�b�_�[�L���v�V����
                columns[COLUMN_BLGOODSCODE].Header.Caption = "BL����";
                columns[COLUMN_BLGOODSCODEGUIDE].Header.Caption = "";
                columns[COLUMN_BLGOODSCODENAME].Header.Caption = "BL���ޖ�";
                // TextHAlign
                columns[COLUMN_BLGOODSCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_BLGOODSCODEGUIDE].CellAppearance.TextHAlign = HAlign.Center;
                columns[COLUMN_BLGOODSCODENAME].CellAppearance.TextHAlign = HAlign.Left;
                // TextVAlign
                columns[COLUMN_BLGOODSCODE].CellAppearance.TextVAlign = VAlign.Middle;
                columns[COLUMN_BLGOODSCODEGUIDE].CellAppearance.TextVAlign = VAlign.Middle;
                columns[COLUMN_BLGOODSCODENAME].CellAppearance.TextVAlign = VAlign.Middle;
                // ��X�^�C��(�{�^���ݒ�)
                columns[COLUMN_BLGOODSCODEGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                columns[COLUMN_BLGOODSCODEGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
                columns[COLUMN_BLGOODSCODEGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
                columns[COLUMN_BLGOODSCODEGUIDE].CellButtonAppearance.ImageHAlign = HAlign.Center;
                columns[COLUMN_BLGOODSCODEGUIDE].CellButtonAppearance.ImageVAlign = VAlign.Middle;
                columns[COLUMN_BLGOODSCODEGUIDE].CellAppearance.Cursor = Cursors.Hand;
                // ���͐���
                columns[COLUMN_BLGOODSCODE].CellActivation = Activation.AllowEdit;
                columns[COLUMN_BLGOODSCODEGUIDE].CellActivation = Activation.AllowEdit;
                columns[COLUMN_BLGOODSCODENAME].CellActivation = Activation.Disabled;
                // ��
                columns[COLUMN_BLGOODSCODE].Width = 70;
                columns[COLUMN_BLGOODSCODEGUIDE].Width = 25;
                columns[COLUMN_BLGOODSCODENAME].Width = 180;
                // �Z��Color
                columns[COLUMN_BLGOODSCODE].CellAppearance.BackColorDisabled = Color.FromKnownColor(KnownColor.Control);
                columns[COLUMN_BLGOODSCODENAME].CellAppearance.BackColor = Color.Gainsboro;
                columns[COLUMN_BLGOODSCODENAME].CellAppearance.BackColorDisabled = Color.Gainsboro;
                // MaxLength
                columns[COLUMN_BLGOODSCODE].MaxLength = this.uiSetControl1.GetSettingColumnCount(COLUMN_BLGOODSCODE);
                columns[COLUMN_BLGOODSCODENAME].MaxLength = 20;
            }
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._mainDataIndex < 0)
            {
                //------------------------------
                // �V�K���[�h
                //------------------------------
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋�����
                PermitScreenInput(INSERT_MODE);

                this.Ok_Button.Visible = true;
                this.Cancel_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;

                // �N���[���쐬
                this._bLCodeGuideListClone = new List<BLCodeGuide>();

                // �t�H�[�J�X�ݒ�
                this.tEdit_SectionCode.Focus();
            }
            else
            {
                // DataSet���狒�_�R�[�h���擾
                string sectionCode = (string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SECTIONCODE];

                // ���_�R�[�h�ŃC���X�^���X���X�g����Y���f�[�^���擾
                List<BLCodeGuide> bLCodeGuideList = this._detailList.FindAll(delegate(BLCodeGuide x)
                {
                    if (x.SectionCode.Trim() == sectionCode.Trim())
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                this._bLCodeGuideListClone = new List<BLCodeGuide>();

                if (bLCodeGuideList.Count == 0)
                {
                    BLCodeGuide bLCodeGuide = new BLCodeGuide();
                    bLCodeGuide.SectionCode = sectionCode.Trim();
                    bLCodeGuideList.Add(bLCodeGuide);
                }
                else
                {
                    // �N���[���쐬
                    foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
                    {
                        this._bLCodeGuideListClone.Add(bLCodeGuide.Clone());
                    }
                }

                // ��ʓW�J����
                BLCodeGuideListToScreen(bLCodeGuideList);

                if (bLCodeGuideList[0].LogicalDeleteCode == 0)
                {
                    // �X�V���[�h
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋�����
                    PermitScreenInput(UPDATE_MODE);

                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    // �t�H�[�J�X�ݒ�
                    this._bLGoodsCode_Grid[0].Focus();
                    this._bLGoodsCode_Grid[0].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                    this._bLGoodsCode_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    // �폜���[�h
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓ��͋�����
                    PermitScreenInput(DELETE_MODE);

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">�ҏW���[�h</param>
        /// <remarks>
        /// <br>Note       : �ҏW���[�h�ɂ���ĉ�ʂ̓��͋�������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void PermitScreenInput(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:   
                    {
                        // �V�K���[�h
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;

                        for (int index = 0; index < this._bLGoodsCode_Grid.Length; index++)
                        {
                            this._bLGoodsCode_Grid[index].Enabled = true;
                        }
                        break;
                    }
                case UPDATE_MODE:   
                    {
                        // �X�V���[�h
                        this.tEdit_SectionCode.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;

                        for (int index = 0; index < this._bLGoodsCode_Grid.Length; index++)
                        {
                            this._bLGoodsCode_Grid[index].Enabled = true;
                        }
                        break;
                    }
                case DELETE_MODE:   
                    {
                        // �폜���[�h
                        this.tEdit_SectionCode.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;

                        for (int index = 0; index < this._bLGoodsCode_Grid.Length; index++)
                        {
                            this._bLGoodsCode_Grid[index].Enabled = false;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// BL�R�[�h�K�C�h���X�g��ʓW�J����
        /// </summary>
        /// <param name="bLCodeGuideList">BL�R�[�h�K�C�h���X�g</param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h���X�g����ʓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void BLCodeGuideListToScreen(List<BLCodeGuide> bLCodeGuideList)
        {
            foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
            {
                // ���_�R�[�h
                this.tEdit_SectionCode.DataText = bLCodeGuide.SectionCode.Trim();
                // ���_��
                this.tEdit_SectionName.DataText = GetSectionName(bLCodeGuide.SectionCode.Trim());

                if ((bLCodeGuide.BLCodeDspPage == 0) || (bLCodeGuide.BLCodeDspCol == 0) || (bLCodeGuide.BLCodeDspRow == 0))
                {
                    continue;
                }

                int gridIndex = GetTargetGridIndex(bLCodeGuide);

                // BL�R�[�h
                this._bLGoodsCode_Grid[gridIndex].Rows[bLCodeGuide.BLCodeDspRow - 1].Cells[COLUMN_BLGOODSCODE].Value = bLCodeGuide.BLGoodsCode.ToString("00000");
                // BL�R�[�h��
                this._bLGoodsCode_Grid[gridIndex].Rows[bLCodeGuide.BLCodeDspRow - 1].Cells[COLUMN_BLGOODSCODENAME].Value = GetBLGoodsCodeName(bLCodeGuide.BLGoodsCode);
            }
        }

        /// <summary>
        /// Main���X�g�擾����
        /// </summary>
        /// <param name="bLCodeGuideList">BL�R�[�h�K�C�h���X�g</param>
        /// <returns>Main���X�g</returns>
        /// <remarks>
        /// <br>Note       : Main���X�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private Dictionary<string, BLCodeGuide> GetMainList(ArrayList bLCodeGuideList)
        {
            Dictionary<string, BLCodeGuide> mainList = new Dictionary<string, BLCodeGuide>();

            if ((bLCodeGuideList == null) || (bLCodeGuideList.Count == 0))
            {
                return mainList;
            }

            foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
            {
                if (mainList.ContainsKey(bLCodeGuide.SectionCode.Trim()) == false)
                {
                    mainList.Add(bLCodeGuide.SectionCode.Trim(), bLCodeGuide);
                }
            }

            return mainList;
        }

        /// <summary>
        /// �ۑ��f�[�^�擾����
        /// </summary>
        /// <returns>�ۑ��f�[�^</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�A�ۑ��f�[�^���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private Dictionary<string, BLCodeGuide> GetSaveBLCodeGuideDicFromScreen()
        {
            Dictionary<string, BLCodeGuide> bLCodeGuideDic = new Dictionary<string, BLCodeGuide>();

            for (int index = 0; index < this._bLGoodsCode_Grid.Length; index++)
            {
                for (int rowIndex = 0; rowIndex < ROWCOUNT; rowIndex++)
                {
                    CellsCollection cells = this._bLGoodsCode_Grid[index].Rows[rowIndex].Cells;

                    // BL�R�[�h���󔒂̏ꍇ
                    if ((cells[COLUMN_BLGOODSCODE].Value == DBNull.Value) || (((string)cells[COLUMN_BLGOODSCODE].Value).Trim() == ""))
                    {
                        continue;
                    }

                    BLCodeGuide bLCodeGuide = new BLCodeGuide();

                    // ��ƃR�[�h
                    bLCodeGuide.EnterpriseCode = this._enterpriseCode;
                    // ���_�R�[�h
                    bLCodeGuide.SectionCode = this.tEdit_SectionCode.DataText.Trim();
                    // BL�R�[�h�\����
                    bLCodeGuide.BLCodeDspPage = GetTargetTabIndex(index) + 1;
                    // BL�R�[�h�\���s
                    bLCodeGuide.BLCodeDspRow = rowIndex + 1;
                    // BL�R�[�h�\����
                    bLCodeGuide.BLCodeDspCol = GetTargetColIndex(index);
                    // BL�R�[�h
                    bLCodeGuide.BLGoodsCode = int.Parse((string)cells[COLUMN_BLGOODSCODE].Value);
                    // BL�R�[�h��
                    bLCodeGuide.BLGoodsName = GetBLGoodsCodeName(bLCodeGuide.BLGoodsCode);

                    bLCodeGuideDic.Add(GetKey(bLCodeGuide), bLCodeGuide);   
                }
            }

            return bLCodeGuideDic;
        }

        /// <summary>
        /// �X�V�p���X�g�擾����
        /// </summary>
        /// <param name="saveList">�ۑ����X�g</param>
        /// <param name="deleteList">�폜���X�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�A�ۑ����X�g�E�폜���X�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void GetUpdateList(out ArrayList saveList, out ArrayList deleteList)
        {
            saveList = new ArrayList();
            deleteList = new ArrayList();

            // �ۑ��p�f�[�^�擾
            Dictionary<string, BLCodeGuide> saveBLCodeGuideDic = GetSaveBLCodeGuideDicFromScreen();

            // �폜���X�g�쐬
            foreach (BLCodeGuide bLCodeGuide in this._bLCodeGuideListClone)
            {
                deleteList.Add(bLCodeGuide.Clone());
            }

            // �ۑ����X�g�쐬
            foreach (BLCodeGuide bLCodeGuide in saveBLCodeGuideDic.Values)
            {
                saveList.Add(bLCodeGuide);
            }
        }

        /// <summary>
        /// Key�擾����
        /// </summary>
        /// <param name="bLCodeGuide">BL�R�[�h�K�C�h�}�X�^</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^����Key���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private string GetKey(BLCodeGuide bLCodeGuide)
        {
            string key = "";

            // ���_�R�[�h(2��)�{�\����(2��)�{�\����(2��)�{�\���s(2��)
            key = bLCodeGuide.SectionCode.Trim() + bLCodeGuide.BLCodeDspPage.ToString("00") + 
                  bLCodeGuide.BLCodeDspCol.ToString("00") + bLCodeGuide.BLCodeDspRow.ToString("00");

            return key;
        }

        /// <summary>
        /// Tab�C���f�b�N�X�擾����
        /// </summary>
        /// <param name="gridIndex">Grid�C���f�b�N�X</param>
        /// <returns>Tab�C���f�b�N�X</returns>
        /// <remarks>
        /// <br>Note       : Grid�C���f�b�N�X���猻�݂�Tab�C���f�b�N�X���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private int GetTargetTabIndex(int gridIndex)
        {
            switch (gridIndex)
            {
                case 0:
                case 1:
                case 2:
                    return 0;
                case 3:
                case 4:
                case 5:
                    return 1;
                case 6:
                case 7:
                case 8:
                    return 2;
                case 9:
                case 10:
                case 11:
                    return 3;
                case 12:
                case 13:
                case 14:
                    return 4;
            }

            return 0;
        }

        /// <summary>
        /// ��C���f�b�N�X�擾����
        /// </summary>
        /// <param name="gridIndex">Grid�C���f�b�N�X</param>
        /// <returns>��C���f�b�N�X</returns>
        /// <remarks>
        /// <br>Note       : Grid�C���f�b�N�X�����C���f�b�N�X���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private int GetTargetColIndex(int gridIndex)
        {
            switch (gridIndex)
            {
                case 0:
                case 3:
                case 6:
                case 9:
                case 12:
                    return 1;
                case 1:
                case 4:
                case 7:
                case 10:
                case 13:
                    return 2;
                case 2:
                case 5:
                case 8:
                case 11:
                case 14:
                    return 3;
            }

            return 1;
        }

        /// <summary>
        /// Grid�C���f�b�N�X�擾����
        /// </summary>
        /// <param name="bLCodeGuide">BL�R�[�h�K�C�h�}�X�^</param>
        /// <returns>Grid�C���f�b�N�X</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^����Ώۂ�Grid�C���f�b�N�X���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private int GetTargetGridIndex(BLCodeGuide bLCodeGuide)
        {
            switch (bLCodeGuide.BLCodeDspPage)
            {
                case 1:
                    {
                        return bLCodeGuide.BLCodeDspCol - 1;
                    }
                case 2:
                    {
                        return bLCodeGuide.BLCodeDspCol + 2;
                    }
                case 3:
                    {
                        return bLCodeGuide.BLCodeDspCol + 5;
                    }
                case 4:
                    {
                        return bLCodeGuide.BLCodeDspCol + 8;
                    }
                case 5:
                    {
                        return bLCodeGuide.BLCodeDspCol + 11;
                    }
            }

            return 0;
        }

        /// <summary>
        /// ���͏��`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���͏��̃`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                // ���_�R�[�h
                if (this.tEdit_SectionCode.DataText.Trim() == "")
                {
                    errMsg = "���_�R�[�h����͂��Ă��������B";
                    this.tEdit_SectionCode.Focus();
                    return (false);
                }
                string sectionCode = this.tEdit_SectionCode.DataText.Trim();
                if (GetSectionName(sectionCode) == "")
                {
                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                    this.tEdit_SectionCode.Focus();
                    return (false);
                }
                if (this.Mode_Label.Text == INSERT_MODE)
                {
                    foreach (BLCodeGuide blCodeGuide in this._detailList)
                    {
                        if (blCodeGuide.SectionCode.Trim() == sectionCode)
                        {
                            errMsg = "���̋��_�R�[�h�͊��Ɏg�p����Ă��܂��B";
                            this.tEdit_SectionCode.Focus();
                            return (false);
                        }
                    }
                }

                // BL�R�[�h
                bool inputFlg = false;

                for (int index = 0; index < this._bLGoodsCode_Grid.Length; index++)
                {
                    for (int rowIndex = 0; rowIndex < ROWCOUNT; rowIndex++)
                    {
                        CellsCollection cells = this._bLGoodsCode_Grid[index].Rows[rowIndex].Cells;

                        // BL�R�[�h���󔒂̏ꍇ
                        if ((cells[COLUMN_BLGOODSCODE].Value == DBNull.Value) || (((string)cells[COLUMN_BLGOODSCODE].Value).Trim() == ""))
                        {
                            continue;
                        }

                        inputFlg = true;

                        // BL�R�[�h�擾
                        int bLGoodsCode = int.Parse((string)cells[COLUMN_BLGOODSCODE].Value);

                        // �}�X�^�ɓo�^����Ă��Ȃ��ꍇ
                        if (GetBLGoodsCodeName(bLGoodsCode) == "")
                        {
                            errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                            int tabIndex = GetTargetTabIndex(index);
                            this.MainTabControl.Tabs[tabIndex].Selected = true;
                            this.MainTabControl.Tabs[tabIndex].Active = true;
                            this._bLGoodsCode_Grid[index].Focus();
                            this._bLGoodsCode_Grid[index].Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Activate();
                            this._bLGoodsCode_Grid[index].PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                    }
                }

                // BL�R�[�h��1�������͂���Ă��Ȃ������ꍇ
                if (inputFlg == false)
                {
                    errMsg = "BL���ނ̓o�^������܂���B";
                    this.MainTabControl.Tabs[0].Active = true;
                    this.MainTabControl.Tabs[0].Selected = true;
                    this._bLGoodsCode_Grid[0].Focus();
                    this._bLGoodsCode_Grid[0].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                    this._bLGoodsCode_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   -1,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// BL�R�[�h���ݒ菈��
        /// </summary>
        /// <param name="uGrid">�ΏۃO���b�h</param>
        /// <param name="bLGoodsCodeName">BL�R�[�h��</param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�����O���b�h�̑ΏۃZ���ɐݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void SetBLGoodsCodeName(UltraGrid uGrid, out string bLGoodsCodeName)
        {
            bLGoodsCodeName = "";

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if (uGrid.ActiveCell.Column.Key != COLUMN_BLGOODSCODE)
            {
                return;
            }

            int rowIndex = uGrid.ActiveCell.Row.Index;

            if (uGrid.ActiveCell.Text.Trim() == "")
            {
                uGrid.Rows[rowIndex].Cells[COLUMN_BLGOODSCODENAME].Value = DBNull.Value;
                return;
            }

            // BL�R�[�h�擾
            int bLGoodsCode = int.Parse(uGrid.ActiveCell.Text.Trim());

            // BL�R�[�h���擾
            bLGoodsCodeName = GetBLGoodsCodeName(bLGoodsCode);
            uGrid.Rows[rowIndex].Cells[COLUMN_BLGOODSCODENAME].Value = bLGoodsCodeName;
        }

        /// <summary>
        /// NextFocus �ݒ菈��
        /// </summary>
        /// <param name="uGrid">�ΏۃO���b�h</param>
        /// <param name="bLGoodsCodeName">BL�R�[�h��</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h����Enter�L�[���������ꂽ����NextFocus�ݒ���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void SetNextFocus(UltraGrid uGrid, string bLGoodsCodeName, ref ChangeFocusEventArgs e)
        {
            int rowIndex;
            int columnIndex;

            if (uGrid.ActiveCell == null)
            {
                if (uGrid.ActiveRow == null)
                {
                    return;
                }
                else
                {
                    rowIndex = uGrid.ActiveRow.Index;
                    columnIndex = 2;
                }
            }
            else
            {
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
            }

            e.NextCtrl = null;

            if (columnIndex == 0)
            {
                //-------------------------
                // BL�R�[�h��
                //-------------------------

                if (bLGoodsCodeName.Trim() == "")
                {
                    uGrid.Rows[rowIndex].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    if (rowIndex == ROWCOUNT - 1)
                    {
                        int gridIndex = (int)uGrid.Tag;

                        uGrid.ActiveCell = null;
                        uGrid.ActiveRow = null;

                        switch (gridIndex)
                        {
                            case 2:
                            case 5:
                            case 8:
                            case 11:
                            case 14:
                                {
                                    this.Ok_Button.Focus();
                                    break;
                                }
                            default:
                                {
                                    this._bLGoodsCode_Grid[gridIndex + 1].Focus();
                                    this._bLGoodsCode_Grid[gridIndex + 1].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                                    this._bLGoodsCode_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    else
                    {
                        uGrid.Rows[rowIndex + 1].Cells[COLUMN_BLGOODSCODE].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
            else
            {
                //-------------------------
                // BL�R�[�h�K�C�h�{�^����
                //-------------------------

                if (rowIndex == ROWCOUNT - 1)
                {
                    int gridIndex = (int)uGrid.Tag;

                    uGrid.ActiveCell = null;
                    uGrid.ActiveRow = null;

                    switch (gridIndex)
                    {
                        case 2:
                        case 5:
                        case 8:
                        case 11:
                        case 14:
                            {
                                this.Ok_Button.Focus();
                                break;
                            }
                        default:
                            {
                                this._bLGoodsCode_Grid[gridIndex + 1].Focus();
                                this._bLGoodsCode_Grid[gridIndex + 1].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                                this._bLGoodsCode_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                                break;
                            }
                    }
                }
                else
                {
                    uGrid.Rows[rowIndex + 1].Cells[COLUMN_BLGOODSCODE].Activate();
                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
        }

        /// <summary>
        /// BeforeFocus �ݒ菈��
        /// </summary>
        /// <param name="uGrid">�ΏۃO���b�h</param>
        /// <param name="bLGoodsCodeName">BL�R�[�h��</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h����Shift + Tab�L�[���������ꂽ����NextFocus�ݒ���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void SetBeforeFocus(UltraGrid uGrid, ref ChangeFocusEventArgs e)
        {
            int rowIndex;
            int columnIndex;

            if (uGrid.ActiveCell == null)
            {
                if (uGrid.ActiveRow == null)
                {
                    return;
                }
                else
                {
                    rowIndex = uGrid.ActiveRow.Index;
                    columnIndex = 0;
                }
            }
            else
            {
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
            }

            e.NextCtrl = null;

            if (columnIndex == 0)
            {
                //-------------------------
                // BL�R�[�h��
                //-------------------------

                if (rowIndex == 0)
                {
                    int gridIndex = (int)uGrid.Tag;

                    switch (gridIndex)
                    {
                        case 0:
                        case 3:
                        case 6:
                        case 9:
                        case 12:
                            {
                                this.MainTabControl.Focus();
                                break;
                            }
                        default:
                            {
                                e.NextCtrl = this._bLGoodsCode_Grid[gridIndex - 1];

                                if ((this._bLGoodsCode_Grid[gridIndex - 1].Rows[ROWCOUNT - 1].Cells[COLUMN_BLGOODSCODENAME].Value == DBNull.Value) ||
                                    ((string)this._bLGoodsCode_Grid[gridIndex - 1].Rows[ROWCOUNT - 1].Cells[COLUMN_BLGOODSCODENAME].Value == ""))
                                {
                                    this._bLGoodsCode_Grid[gridIndex - 1].Rows[ROWCOUNT - 1].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                    this._bLGoodsCode_Grid[gridIndex - 1].PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this._bLGoodsCode_Grid[gridIndex - 1].Rows[ROWCOUNT - 1].Cells[COLUMN_BLGOODSCODE].Activate();
                                    this._bLGoodsCode_Grid[gridIndex - 1].PerformAction(UltraGridAction.EnterEditMode);
                                }
                                break;
                            }
                    }
                }
                else
                {
                    if ((uGrid.Rows[rowIndex - 1].Cells[COLUMN_BLGOODSCODENAME].Value == DBNull.Value) ||
                        ((string)uGrid.Rows[rowIndex - 1].Cells[COLUMN_BLGOODSCODENAME].Value == ""))
                    {
                        uGrid.Rows[rowIndex - 1].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        uGrid.Rows[rowIndex - 1].Cells[COLUMN_BLGOODSCODE].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
            else
            {
                //-------------------------
                // BL�R�[�h�K�C�h�{�^����
                //-------------------------

                uGrid.Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Activate();
                uGrid.PerformAction(UltraGridAction.EnterEditMode);
            }
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:���� False:���s)</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private bool SaveProc()
        {
            // ���̓`�F�b�N
            bool bStatus = CheckScreenInput();
            if (!bStatus)
            {
                return (false);
            }

            ArrayList saveList;
            ArrayList deleteList;

            // �X�V�p�f�[�^�擾
            GetUpdateList(out saveList, out deleteList);

            int status;

            if (deleteList.Count > 0)
            {
                // �폜����
                status = this._bLCodeGuidAcs.Delete(deleteList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        // �r������
                        ExclusiveTransaction(status);
                        return (false);
                    default:
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "SaveProc",
                                       "�o�^�Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                }
            }

            // �ۑ�����
            status = this._bLCodeGuidAcs.Write(ref saveList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int totalCount = 0;

                        // �Č���
                        Search(ref totalCount, 0);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "���̋��_�R�[�h�͊��Ɏg�p����Ă��܂��B",
                                       status,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);

                        this.tEdit_SectionCode.Focus();

                        return (false);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        // �o�^���s
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "SaveProc",
                                       "�o�^�Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            return (true);
        }

        /// <summary>
        /// �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:���� False:���s)</returns>
        /// <remarks>
        /// <br>Note       : �����폜�������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private bool DeleteProc()
        {
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                                 "�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",
                                                 0,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxDefaultButton.Button2);

            
            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return (false);
            }

            // �폜���X�g�擾
            ArrayList deleteList = new ArrayList();
            foreach (BLCodeGuide bLCodeGuide in this._bLCodeGuideListClone)
            {
                deleteList.Add(bLCodeGuide.Clone());
            }

            // �폜����
            int status = this._bLCodeGuidAcs.Delete(deleteList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int totalCount = 0;

                        // �Č���
                        Search(ref totalCount, 0);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return (false);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "DeleteProc",
                                       "�폜�Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                    }
            }

            return (true);
        }

        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:���� False:���s)</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private bool LogicalDeleteProc()
        {
            // DataSet���狒�_�R�[�h���擾
            string sectionCode = (string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[this._mainDataIndex][VIEW_SECTIONCODE];

            // ���_�R�[�h�ŃC���X�^���X���X�g����Y���f�[�^���擾
            List<BLCodeGuide> bLCodeGuideList = this._detailList.FindAll(delegate(BLCodeGuide x)
            {
                if (x.SectionCode.Trim() == sectionCode.Trim())
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            if (bLCodeGuideList.Count == 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "�폜�Ώۃf�[�^�����݂��܂���B",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                return (true);
            }

            ArrayList logicalList = new ArrayList();
            foreach (BLCodeGuide bLCodeGuide in bLCodeGuideList)
            {
                logicalList.Add(bLCodeGuide.Clone());
            }

            // �_���폜����
            int status = this._bLCodeGuidAcs.LogicalDelete(ref logicalList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        string key;

                        foreach (BLCodeGuide bLCodeGuide in logicalList)
                        {
                            key = GetKey(bLCodeGuide);
                            int listIndex = this._detailList.FindIndex(delegate(BLCodeGuide x)
                            {
                                string key2 = GetKey(x);

                                if (key == key2)
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                            if (listIndex >= 0)
                            {
                                // �o�b�t�@�X�V
                                this._detailList[listIndex] = bLCodeGuide.Clone();
                            }

                            // DataSet�W�J
                            DetailToDataSet(bLCodeGuide, index);
                            index++;
                        }

                        

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "LogicalDeleteProc",
                                       "�_���폜�Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
            }

            return (true);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�X�e�[�^�X(True:���� False:���s)</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private bool RevivalProc()
        {
            // �������X�g�擾
            ArrayList reviveList = new ArrayList();
            foreach (BLCodeGuide bLCodeGuide in this._bLCodeGuideListClone)
            {
                reviveList.Add(bLCodeGuide.Clone());
            }

            // ��������
            int status = this._bLCodeGuidAcs.Revival(ref reviveList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int totalCount = 0;

                        // �Č���
                        Search(ref totalCount, 0);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r��
                        ExclusiveTransaction(status);
                        return (false);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                       "RevivalProc",
                                       "�����Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                    }
            }

            return (true);
        }

        /// <summary>
        /// ��ʏ���r����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ� False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note       : ��ʓǍ����Ɖ�ʏI�����̃f�[�^���r���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            // �V�K�Ǎ����ɋ��_�R�[�h�����͂���Ă����ꍇ
            if ((this._bLCodeGuideListClone.Count == 0) && (this.Mode_Label.Text == INSERT_MODE))
            {
                if (this.tEdit_SectionCode.DataText.Trim() != "")
                {
                    return (false);
                }
            }

            // �ۑ��f�[�^�擾
            Dictionary<string, BLCodeGuide> saveBLCodeGuideDic = GetSaveBLCodeGuideDicFromScreen();

            // ��ʓǍ����ƕۑ��f�[�^�̌������Ⴄ�ꍇ
            if (this._bLCodeGuideListClone.Count != saveBLCodeGuideDic.Values.Count)
            {
                return (false);
            }

            string key;
            foreach (BLCodeGuide bLCodeGuide in this._bLCodeGuideListClone)
            {
                // Key�擾
                key = GetKey(bLCodeGuide);

                // ��ʓǍ����̃f�[�^�������ꍇ
                if (!saveBLCodeGuideDic.ContainsKey(key))
                {
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "ExclusiveTransaction",
                                       "���ɑ��[�����X�V����Ă��܂��B",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "ExclusiveTransaction",
                                       "���ɑ��[�����폜����Ă��܂��B",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
            }
        }

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <param name="defaultButton">�����\���{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // �e�E�B���h�E�t�H�[��
                                         errLevel,                          // �G���[���x��
                                         ASSEMBLY_ID,                       // �A�Z���u��ID
                                         message,                           // �\�����郁�b�Z�[�W
                                         status,                            // �X�e�[�^�X�l
                                         msgButton,                         // �\������{�^��
                                         defaultButton);                    // �����\���{�^��
            return dialogResult;
        }

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="methodName">��������</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/30</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // �e�E�B���h�E�t�H�[��
                                         errLevel,			                // �G���[���x��
                                         this.Name,						    // �v���O��������
                                         ASSEMBLY_ID, 		  �@�@			// �A�Z���u��ID
                                         methodName,						// ��������
                                         "",					            // �I�y���[�V����
                                         message,	                        // �\�����郁�b�Z�[�W
                                         status,							// �X�e�[�^�X�l
                                         this._bLCodeGuidAcs,				// �G���[�����������I�u�W�F�N�g
                                         msgButton,         			  	// �\������{�^��
                                         MessageBoxDefaultButton.Button1);	// �����\���{�^��

            return dialogResult;
        }

        #endregion �� Private Methods


        #region �� Control Events

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[����Load���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void PMKHN09230UA_Load(object sender, EventArgs e)
        {
            // ��ʏ����ݒ�
            SetScreenInitialSetting();

            // ��ʃN���A
            ScreenClear();
        }

        /// <summary>
        /// FormClosing �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void PMKHN09230UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// VisibleChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[���̕\����Ԃ��ύX�������ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void PMKHN09230UA_VisibleChanged(object sender, EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // ��ʃN���A
            ScreenClear();

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Button_Click �C�x���g(���_�K�C�h�{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._secInfoAcs.ResetSectionInfo();
                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    // ���_�R�[�h�擾
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    // ���_���擾
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

                    // �t�H�[�J�X�ݒ�
                    if (this.MainTabControl.ActiveTab == null)
                    {
                        this.MainTabControl.Tabs[0].Active = true;
                        this.MainTabControl.Tabs[0].Selected = true;
                        this._bLGoodsCode_Grid[0].Focus();
                        this._bLGoodsCode_Grid[0].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                        this._bLGoodsCode_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3].Focus();
                        this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                        this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3].PerformAction(UltraGridAction.EnterEditMode);
                    }

                    // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                    if (this._mainDataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                           ((Control)sender).Focus();
                        }
                    }
                    // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(�ۑ��{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ۑ��{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // �ۑ�����
            SaveProc();
        }

        /// <summary>
        /// Button_Click �C�x���g(����{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ����{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʏ���r
                if (!CompareOriginalScreen())
                {
                    //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                      "",
                                                      0,
                                                      MessageBoxButtons.YesNoCancel,
                                                      MessageBoxDefaultButton.Button1);

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // �ۑ�����
                                if (SaveProc() != true)
                                {
                                    return;
                                }

                                this.DialogResult = DialogResult.OK;

                                break;
                            }
                        case DialogResult.No:
                            {
                                this.DialogResult = DialogResult.Cancel;

                                break;
                            }
                        default:
                            {
                                // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                                //this.Cancel_Button.Focus();
                                if (_modeFlg)
                                {
                                    tEdit_SectionCode.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                                return;
                            }
                    }
                }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

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
        /// Button_Click �C�x���g(�����{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �����{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ��������
                bool bStatus = RevivalProc();
                if (!bStatus)
                {
                    return;
                }

                if (UnDisplaying != null)
                {
                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                    UnDisplaying(this, me);
                }

                this.DialogResult = DialogResult.OK;

                if (CanClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }

                // ADD 2009/03/24 �s��Ή�[12694]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
                // �폜�����Ď擾
                ResetBLCodeGuideCache();
                SetDeleteDateOfMainTable();
                // ADD 2009/03/24 �s��Ή�[12694]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(�폜�{�^��)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �폜�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // �����폜����
            bool bStatus = DeleteProc();
            if (!bStatus)
            {
                return;
            }

            int totalCount = 0;

            // �Č�������
            Search(ref totalCount, 0);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

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
        /// Timer_Tick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂������ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // ��ʍč\�z����
            ScreenReconstruction();
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �^�u���A�N�e�B�u���ɃL�[�������ꂽ�^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void MainTabControl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.PageUp:
                    {
                        e.Handled = true;

                        if (this.MainTabControl.ActiveTab == null)
                        {
                            this.MainTabControl.Tabs[0].Active = true;
                            this.MainTabControl.Tabs[0].Selected = true;
                        }
                        else
                        {
                            int index = this.MainTabControl.ActiveTab.Index;

                            if (index == 4)
                            {
                                this.MainTabControl.Tabs[0].Active = true;
                                this.MainTabControl.Tabs[0].Selected = true;
                            }
                            else
                            {
                                this.MainTabControl.Tabs[index + 1].Active = true;
                                this.MainTabControl.Tabs[index + 1].Selected = true;
                            }
                        }

                        break;
                    }
                case Keys.PageDown:
                    {
                        e.Handled = true;

                        if (this.MainTabControl.ActiveTab == null)
                        {
                            this.MainTabControl.Tabs[4].Active = true;
                            this.MainTabControl.Tabs[4].Selected = true;
                        }
                        else
                        {
                            int index = this.MainTabControl.ActiveTab.Index;

                            if (index == 0)
                            {
                                this.MainTabControl.Tabs[4].Active = true;
                                this.MainTabControl.Tabs[4].Selected = true;
                            }
                            else
                            {
                                this.MainTabControl.Tabs[index - 1].Active = true;
                                this.MainTabControl.Tabs[index - 1].Selected = true;
                            }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// ClickCellButton �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Z���{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void uGrid_BLGoodsCode_ClickCellButton(object sender, CellEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                BLGoodsCdUMnt bLGoodsCdUMnt;

                int status = this._bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
                if (status == 0)
                {
                    UltraGrid uGrid = (UltraGrid)sender;

                    int rowIndex = e.Cell.Row.Index;

                    // BL�R�[�h�擾
                    uGrid.Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Value = bLGoodsCdUMnt.BLGoodsCode.ToString("00000");
                    // BL�R�[�h���擾
                    uGrid.Rows[rowIndex].Cells[COLUMN_BLGOODSCODENAME].Value = bLGoodsCdUMnt.BLGoodsHalfName.Trim();

                    // �t�H�[�J�X�ݒ�
                    if (rowIndex != ROWCOUNT - 1)
                    {
                        // �ŏI�s�ł͂Ȃ��ꍇ�́A�P���Ɉ���̍s��BL�R�[�h�Ƀt�H�[�J�X�ݒ�
                        uGrid.Rows[rowIndex + 1].Cells[COLUMN_BLGOODSCODE].Activate();
                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        // �ŏI�s�̏ꍇ�́A���̃O���b�h�̐擪�s��BL�R�[�h�Ƀt�H�[�J�X�ݒ�
                        // �������A�A�N�e�B�u�O���b�h���Ō�̃O���b�h�������ꍇ�́A�ۑ��{�^���Ƀt�H�[�J�X�ݒ�
                        int gridIndex = (int)uGrid.Tag;

                        uGrid.ActiveCell = null;
                        uGrid.ActiveRow = null;

                        switch (gridIndex)
                        {
                            case 2:
                            case 5:
                            case 8:
                            case 11:
                            case 14:
                                {
                                    this.Ok_Button.Focus();
                                    break;
                                }
                            default:
                                {
                                    this._bLGoodsCode_Grid[gridIndex + 1].Focus();
                                    this._bLGoodsCode_Grid[gridIndex + 1].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                                    this._bLGoodsCode_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�A�N�e�B�u���ɃL�[�������ꂽ�^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void uGrid_BLGoodsCode_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            int rowIndex;
            int columnIndex;

            if (uGrid.ActiveCell == null)
            {
                if (uGrid.ActiveRow == null)
                {
                    return;
                }
                else
                {
                    rowIndex = uGrid.ActiveRow.Index;
                    columnIndex = 0;
                }
            }
            else
            {
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
            }

            string bLGoodsCodeName;

            if (columnIndex == 0)
            {
                //-------------------------
                // BL�R�[�h��
                //-------------------------
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            // BL�R�[�h���ݒ�
                            SetBLGoodsCodeName(uGrid, out bLGoodsCodeName);

                            e.Handled = true;

                            if (rowIndex == 0)
                            {
                                this.MainTabControl.Focus();
                            }
                            else
                            {
                                uGrid.Rows[rowIndex - 1].Cells[COLUMN_BLGOODSCODE].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                    case Keys.Down:
                        {
                            // BL�R�[�h���ݒ�
                            SetBLGoodsCodeName(uGrid, out bLGoodsCodeName);

                            e.Handled = true;

                            if (rowIndex == ROWCOUNT - 1)
                            {
                                this.Ok_Button.Focus();
                            }
                            else
                            {
                                uGrid.Rows[rowIndex + 1].Cells[COLUMN_BLGOODSCODE].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                    case Keys.Left:
                        {
                            int gridIndex = (int)uGrid.Tag;
                            switch (gridIndex)
                            {
                                case 0:
                                case 3:
                                case 6:
                                case 9:
                                case 12:
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        if (uGrid.ActiveCell.SelStart == 0)
                                        {
                                            // BL�R�[�h���ݒ�
                                            SetBLGoodsCodeName(uGrid, out bLGoodsCodeName);

                                            this._bLGoodsCode_Grid[gridIndex - 1].Focus();
                                            this._bLGoodsCode_Grid[gridIndex - 1].Rows[rowIndex].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                            this._bLGoodsCode_Grid[gridIndex - 1].PerformAction(UltraGridAction.EnterEditMode);
                                            e.Handled = true;
                                        }
                                        break;
                                    }
                            }

                            break;
                        }
                    case Keys.Right:
                        {
                            if (uGrid.ActiveCell.SelStart >= uGrid.ActiveCell.Text.Length)
                            {
                                // BL�R�[�h���ݒ�
                                SetBLGoodsCodeName(uGrid, out bLGoodsCodeName);

                                uGrid.Rows[rowIndex].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                e.Handled = true;
                            }
                            
                            break;
                        }
                }
            }
            else
            {
                //-------------------------
                // BL�R�[�h�K�C�h�{�^����
                //-------------------------
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            e.Handled = true;

                            if (rowIndex == 0)
                            {
                                this.MainTabControl.Focus();
                            }
                            else
                            {
                                uGrid.Rows[rowIndex - 1].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                    case Keys.Down:
                        {
                            e.Handled = true;

                            if (rowIndex == ROWCOUNT - 1)
                            {
                                this.Ok_Button.Focus();
                            }
                            else
                            {
                                uGrid.Rows[rowIndex + 1].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                    case Keys.Left:
                        {
                            e.Handled = true;

                            uGrid.Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            break;
                        }
                    case Keys.Right:
                        {
                            e.Handled = true;

                            int gridIndex = (int)uGrid.Tag;
                            switch (gridIndex)
                            {
                                case 2:
                                case 5:
                                case 8:
                                case 11:
                                case 14:
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        this._bLGoodsCode_Grid[gridIndex + 1].Focus();
                                        this._bLGoodsCode_Grid[gridIndex + 1].Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Activate();
                                        this._bLGoodsCode_Grid[gridIndex + 1].PerformAction(UltraGridAction.EnterEditMode);
                                        break;
                                    }
                            }
                            break;
                        }
                    case Keys.Space:
                        {
                            uGrid_BLGoodsCode_ClickCellButton(uGrid, new CellEventArgs(uGrid.ActiveCell));
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// KeyPress �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�A�N�e�B�u���ɃL�[�������ꂽ�^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void uGrid_BLGoodsCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            if (uGrid.ActiveCell.IsInEditMode)
            {
                // UI�ݒ���Q��
                if (this.uiSetControl1.CheckMatchingSet(uGrid.ActiveCell.Column.Key, e.KeyChar) == false)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// BeforeEnterEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ҏW���[�h�ɓ���O�ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void uGrid_BLGoodsCode_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int columnIndex = uGrid.ActiveCell.Column.Index;

            if (columnIndex != 0)
            {
                return;
            }

            if ((uGrid.ActiveCell.Value == DBNull.Value) || ((string)uGrid.ActiveCell.Value == ""))
            {
                return;
            }

            // �[���l�߉���
            uGrid.ActiveCell.Value = this.uiSetControl1.GetZeroPadCanceledText(uGrid.ActiveCell.Column.Key, (string)uGrid.ActiveCell.Value);
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ҏW���[�h���I���������ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void uGrid_BLGoodsCode_AfterExitEditMode(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int columnIndex = uGrid.ActiveCell.Column.Index;

            if (columnIndex != 0)
            {
                return;
            }

            if ((uGrid.ActiveCell.Value == DBNull.Value) || ((string)uGrid.ActiveCell.Value == ""))
            {
                return;
            }

            // �[���l��
            uGrid.ActiveCell.Value = this.uiSetControl1.GetZeroPaddedText(uGrid.ActiveCell.Column.Key, (string)uGrid.ActiveCell.Value);
        }

        /// <summary>
        /// Leave �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h����t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void uGrid_BLGoodsCode_Leave(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            uGrid.ActiveCell = null;
            uGrid.ActiveRow = null;
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �A�N�e�B�u�R���g���[�����ς�������ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/09/30</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            string bLGoodsCodeName;

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SectionCode":
                    {
                        if (this.tEdit_SectionCode.DataText.Trim() == "")
                        {
                            this.tEdit_SectionName.Clear();
                            return;
                        }

                        // ���_�R�[�h�擾
                        string sectionCode = this.tEdit_SectionCode.DataText.Trim();

                        // ���_���擾
                        this.tEdit_SectionName.DataText = GetSectionName(sectionCode);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                // �t�H�[�J�X�ݒ�
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.MainTabControl;

                                    //return;
                                }
                            }
                        }

                        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // �J�ڐ悪����{�^��
                            _modeFlg = true;
                        }
                        else if (this._mainDataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tEdit_SectionCode;
                            }
                        }
                        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                        break;
                    }
                case "SectionGuide_Button":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = this.MainTabControl;
                        }
                        break;
                    }
                case "MainTabControl":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = null;

                                if (this.MainTabControl.ActiveTab == null)
                                {
                                    this.MainTabControl.Tabs[0].Active = true;
                                    this.MainTabControl.Tabs[0].Selected = true;
                                    this._bLGoodsCode_Grid[0].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                                    this._bLGoodsCode_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                                    this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3].PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;

                                if (this.MainTabControl.ActiveTab == null)
                                {
                                    this.MainTabControl.Tabs[0].Active = true;
                                    this.MainTabControl.Tabs[0].Selected = true;
                                    this._bLGoodsCode_Grid[0].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                                    this._bLGoodsCode_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3].Rows[0].Cells[COLUMN_BLGOODSCODE].Activate();
                                    this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3].PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = this.tEdit_SectionCode;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() == "")
                                {
                                    e.NextCtrl = this.SectionGuide_Button;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                }
                            }
                        }
                        break;
                    }
                case "Ok_Button":
                case "Cancel_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Up)
                            {
                                if (this.MainTabControl.ActiveTab == null)
                                {
                                    e.NextCtrl = this._bLGoodsCode_Grid[2];
                                    this.MainTabControl.Tabs[0].Active = true;
                                    this.MainTabControl.Tabs[0].Selected = true;
                                    this._bLGoodsCode_Grid[2].Rows[ROWCOUNT - 1].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                    this._bLGoodsCode_Grid[2].PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    e.NextCtrl = this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3 + 2];
                                    this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3 + 2].Rows[ROWCOUNT - 1].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                    this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3 + 2].PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        else
                        {
                            if (e.PrevCtrl == this.Ok_Button)
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    if (this.MainTabControl.ActiveTab == null)
                                    {
                                        e.NextCtrl = this._bLGoodsCode_Grid[2];
                                        this.MainTabControl.Tabs[0].Active = true;
                                        this.MainTabControl.Tabs[0].Selected = true;
                                        this._bLGoodsCode_Grid[0].Rows[ROWCOUNT - 1].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                        this._bLGoodsCode_Grid[0].PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3 + 2];
                                        this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3 + 2].Rows[ROWCOUNT - 1].Cells[COLUMN_BLGOODSCODEGUIDE].Activate();
                                        this._bLGoodsCode_Grid[this.MainTabControl.ActiveTab.Index * 3 + 2].PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode1":
                    {
                        // BL�R�[�h���ݒ�
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode1, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode1, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode1, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode2":
                    {
                        // BL�R�[�h���ݒ�
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode2, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode2, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode2, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode3":
                    {
                        // BL�R�[�h���ݒ�
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode3, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode3, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode3, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode4":
                    {
                        // BL�R�[�h���ݒ�
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode4, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode4, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode4, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode5":
                    {
                        // BL�R�[�h���ݒ�
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode5, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode5, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode5, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode6":
                    {
                        // BL�R�[�h���ݒ�
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode6, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode6, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode6, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode7":
                    {
                        // BL�R�[�h���ݒ�
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode7, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode7, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode7, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode8":
                    {
                        // BL�R�[�h���ݒ�
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode8, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode8, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode8, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode9":
                    {
                        // BL�R�[�h���ݒ�
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode9, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode9, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode9, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode10":
                    {
                        // BL�R�[�h���ݒ�
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode10, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode10, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode10, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode11":
                    {
                        // BL�R�[�h���ݒ�
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode11, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode11, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode11, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode12":
                    {
                        // BL�R�[�h���ݒ�
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode12, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode12, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode12, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode13":
                    {
                        // BL�R�[�h���ݒ�
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode13, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode13, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode13, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode14":
                    {
                        // BL�R�[�h���ݒ�
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode14, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode14, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode14, ref e);
                            }
                        }
                        break;
                    }
                case "uGrid_BLGoodsCode15":
                    {
                        // BL�R�[�h���ݒ�
                        SetBLGoodsCodeName(this.uGrid_BLGoodsCode15, out bLGoodsCodeName);

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextFocus(this.uGrid_BLGoodsCode15, bLGoodsCodeName, ref e);
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Tab))
                            {
                                SetBeforeFocus(this.uGrid_BLGoodsCode15, ref e);
                            }
                        }
                        break;
                    }
            }
        }

        #endregion �� Control Events

        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();
        }

        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // ���_�R�[�h
            string sectionCd = tEdit_SectionCode.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[TABLE_MAIN].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsSecCd = (string)this.Bind_DataSet.Tables[TABLE_MAIN].Rows[i][VIEW_SECTIONCODE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    BLCodeGuide blCodeGuide = this._detailList.Find(delegate(BLCodeGuide x)
                    {
                        if (x.SectionCode.Trim() == sectionCd)
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });
                    if ((blCodeGuide != null) && (blCodeGuide.LogicalDeleteCode != 0))
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h��BL�K�C�h�R�[�h�}�X�^�����͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���_�R�[�h�A���̂̃N���A
                        tEdit_SectionCode.Clear();
                        tEdit_SectionName.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h��BL�K�C�h�R�[�h�}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",     // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._mainDataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ���_�R�[�h�A���̂̃N���A
                                tEdit_SectionCode.Clear();
                                tEdit_SectionName.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
    }
}