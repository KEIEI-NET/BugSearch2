//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : TBO�}�X�^
// �v���O�����T�v   : TBO�}�X�^�̓o�^�E�X�V�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E�@�K�j
// �� �� ��  2008/11/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30452 ��� �r��
// �� �� ��  2009/03/16  �C�����e : ��Q�Ή�12344
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/04/09  �C�����e : ��Q�Ή�9264
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : �c���� 2013/04/10�z�M��
// �� �� ��  2013/04/01  �C�����e : Redmine#34640 ���i�݌Ƀ}�X�^�̎d�l�ύX(#33231�̎c����)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10901273-00 �쐬�S�� : ���N
// �� �� ��  2013/05/02  �C�����e : 2013/06/18�z�M�� Redmine#35434
//                                : ���i�݌Ƀ}�X�^�N���敪�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10901273-00 �쐬�S�� : ���N
// �� �� ��  2013/06/03  �C�����e : 2013/06/18�z�M�� Redmine#35434
//                                : ���i�݌Ƀ}�X�^�N���敪�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10901273-00 �쐬�S�� : ���N
// �� �� ��  2013/06/14  �C�����e : 2013/06/18�z�M�� Redmine#35434
//                                : ���i�݌Ƀ}�X�^�N���敪�̒ǉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Infragistics.Win.UltraWinGrid;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// TBO�}�X�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: TBO�}�X�^�̐ݒ���s���܂��B</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/11/28</br>
    /// <br>Update Note : 2009/03/16 30452 ��� �r��</br>
    /// <br>             �E��Q�Ή�12344</br>
    /// <br>Update Note : 2013/04/01 �c����</br>
    /// <br>�Ǘ��ԍ�    : 10806793-00 2013/04/10�z�M��</br>
    /// <br>              Redmine#34640 ���i�݌Ƀ}�X�^�̎d�l�ύX(#33231�̎c����)</br>
    /// <br>Update Note : ���N</br>
    /// <br>Date        : 2013/05/02</br>
    /// <br>�Ǘ��ԍ�    : 10901273-00 2013/06/18�z�M��</br>
    /// <br>            : Redmine#35434�̑Ή�</br>
    /// <br>Update Note : ���N</br>
    /// <br>Date        : 2013/06/03</br>
    /// <br>�Ǘ��ԍ�    : 10901273-00 2013/06/18�z�M��</br>
    /// <br>            : Redmine#35434�̑Ή�</br>
    /// <br>Update Note : ���N</br>
    /// <br>Date        : 2013/06/14</br>
    /// <br>�Ǘ��ԍ�    : 10901273-00 2013/06/18�z�M��</br>
    /// <br>            : Redmine#35434�̑Ή�</br>
    /// </remarks>
    public partial class PMKEN09110UA : Form, IMasterMaintenanceMultiType
    {
        #region �� Const

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";

        // �e�[�u������
        private const string TBOSEARCHU_TABLE = "TBOSearchU";

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string PLURAL_TITLE = "����";
        private const string EQUIPGANRECODE_TITLE = "��������";
        private const string EQUIPGANRENAME_TITLE = "������";
        private const string GOODSNO_TITLE = "�i��";
        private const string GOODSNAME_TITLE = "�i��";
        private const string MAKERCODE_TITLE = "���[�J�[";
        private const string MAKERNAME_TITLE = "���[�J�[��";
        private const string BLGOODSCODE_TITLE = "BL����";
        private const string BLGOODSNAME_TITLE = "BL���ޖ�";
        private const string QTY_TITLE = "QTY";
        private const string WAREHOUSECODE_TITLE = "�q��";
        private const string WAREHOUSESHELFNO_TITLE = "�I��";
        private const string SUPPLIERSTOCK_TITLE = "���݌�";
        private const string STANDARD_TITLE = "�K�i/���L����";
        private const string GUID_TITLE = "Guid";

        //�q��ʗpGrid���KEY���
        private const string COLUMN_NO = "No";
        private const string COLUMN_RANK = "Rank";
        private const string COLUMN_GOODSNO = "GoodsNo";
        private const string COLUMN_GOODSNAME = "GoodsName";
        private const string COLUMN_MAKERCODE = "MakerCode";
        private const string COLUMN_MAKERNAME = "MakerName";
        private const string COLUMN_BLGOODSCODE = "BLGoodsCode";
        private const string COLUMN_BLGOODSNAME = "BLGoodsName";
        private const string COLUMN_QTY = "QTY";
        private const string COLUMN_WAREHOUSECODE = "WarehouseCode";
        private const string COLUMN_WAREHOUSESHELFNO = "WarehouseShelfNo";
        private const string COLUMN_SUPPLIERSTOCK = "SupplierStock";
        private const string COLUMN_STANDARD = "Standard";
        private const string COLUMN_DIVISIONCODE = "DivisionCode";
        private const string COLUMN_DIVISIONNAME = "DivisionName";
        private const string COLUMN_GOODSUNITDATA = "GoodsUnitData";

        // �v���O����ID
        private const string ASSEMBLY_ID = "PMKEN09110U";

        #endregion �� Const


        #region �� Private Members

        // �v���p�e�B�p
        private int _dataIndex;
        private bool _canClose;
        private bool _canDelete;
        private bool _canNew;
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canSpecificationSearch;
        private bool _defaultAutoFillToColumn;

        // ��ƃR�[�h
        private string _enterpriseCode;
        // �������_�R�[�h
        private string _loginSectionCode;
        // �Ǘ��q�ɃR�[�h
        private string _secWarehouseCode;

        // TBO�}�X�^�A�N�Z�X�N���X
        private TBOSearchUAcs _tboSearchAcs;

        private int _indexBuf;

        // �I�����̕ҏW�`�F�b�N�p
        private List<GoodsUnitData> _goodsUnitDataListClone;

        private List<TBOSearchU> _allTBOSearchUList;
        private List<TBOSearchU> _userTBOSearchUList;
        private Dictionary<string, TBOSearchU> _dispTBOSearchUDic;

        private int _prevEquipGanreCode;
        private string _prevEquipName;
        private string _prevGoodsNo;
        private int _prevMakerCode;

        /// <summary>���i���̓A�N�Z�X�N���X</summary>
        GoodsAcs _goodsAcs; // ADD 2013/04/01 �c���� Redmine#34640

        private AllDefSet _allDefSet; // ADD ���N 2013/05/02 Redmine35434
        /// <summary>���i�݌Ƀ}�X�^�d���N��Flag</summary>
        private int flag;// ADD ���N 2013/06/14 Redmine#35434

        #endregion �� Private Members


        #region �� Constructor
        /// <summary>
        /// TBO�}�X�^�ݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: TBO�}�X�^�̃R���X�g���N�^�ł��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/11/28</br>
        /// <br>Update Note : 2013/04/01 �c����</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/04/10�z�M��</br>
        /// <br>              Redmine#34640 ���i�݌Ƀ}�X�^�̎d�l�ύX(#33231�̎c����)</br>
        /// <br>Update Note : ���N</br>
        /// <br>Date        : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�    : 10901273-00 2013/06/18�z�M��</br>
        /// <br>            : Redmine#35434�̑Ή�</br>
        /// </remarks>
        public PMKEN09110UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._dataIndex = -1;
            this._canClose = false;
            this._canDelete = true;
            this._canNew = true;
            this._canPrint = false;
            this._canLogicalDeleteDataExtraction = false;
            this._canSpecificationSearch = false;
            this._defaultAutoFillToColumn = false;

            // �ϐ�������
            this._tboSearchAcs = new TBOSearchUAcs();

            this._goodsAcs = new GoodsAcs(); // ADD 2013/04/01 �c���� Redmine#34640

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �������_�R�[�h�擾
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            // �Ǘ��q�ɃR�[�h
            this._secWarehouseCode = this._tboSearchAcs.GetSecInfoSet(this._loginSectionCode).SectWarehouseCd1.Trim();
            
            // �������ސݒ�
            this.tComboEditor_EquipGenreCode.Items.Clear();
            this.tComboEditor_EquipGenreCode.Items.Add(1001, "�o�b�e���[");
            this.tComboEditor_EquipGenreCode.Items.Add(1005, "�^�C��");
            this.tComboEditor_EquipGenreCode.Items.Add(1010, "�I�C��");
            this.tComboEditor_EquipGenreCode.Value = 1001;

            // GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            //�S�̏����l�ݒ���擾����
            GetDtlCalcStckCntDsp();// ADD ���N 2013/05/02 Redmine#35434
        }
        #endregion �� Constructor


        #region �� IMasterMaintenanceMultiType �����o

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

        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
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

        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

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

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // ����
            appearanceTable.Add(PLURAL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleCenter, "", Color.Black));
            // ��������
            appearanceTable.Add(EQUIPGANRECODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ������
            appearanceTable.Add(EQUIPGANRENAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �i��
            appearanceTable.Add(GOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �i��
            appearanceTable.Add(GOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���[�J�[�R�[�h
            appearanceTable.Add(MAKERCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���[�J�[��
            appearanceTable.Add(MAKERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // BL�R�[�h
            appearanceTable.Add(BLGOODSCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // BL�R�[�h��
            appearanceTable.Add(BLGOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // QTY
            appearanceTable.Add(QTY_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �q�ɃR�[�h
            appearanceTable.Add(WAREHOUSECODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �I��
            appearanceTable.Add(WAREHOUSESHELFNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���݌�
            appearanceTable.Add(SUPPLIERSTOCK_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.BottomRight, "", Color.Black));
            // �K�i/���L����
            appearanceTable.Add(STANDARD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // GUID
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = TBOSEARCHU_TABLE;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public int Print()
        {
            // ����@�\�����̂��ߖ�����
            return 0;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^�𕨗��폜���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public int Delete()
        {
            // �������ރR�[�h
            int equipGanreCode = (int)this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[this._dataIndex][EQUIPGANRECODE_TITLE];
            // ������
            string equipName = (string)this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[this._dataIndex][EQUIPGANRENAME_TITLE];

            // ���[�U�[�f�[�^�擾
            this._userTBOSearchUList = FindUserTBOSearchUList(equipGanreCode, equipName);

            // �폜���X�g�쐬
            ArrayList deleteList = new ArrayList();
            foreach (TBOSearchU tboSearchU in this._userTBOSearchUList)
            {
                deleteList.Add(tboSearchU);
            }

            // �����폜����
            int status = this._tboSearchAcs.Delete(deleteList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �Č���
                        int totalCount = 0;
                        Search(ref totalCount, 0);
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
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Delete",
                                       "�폜�Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S�f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = -1;
            totalCount = 0;

            try
            {
                // �N���A
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows.Clear();
                this._allTBOSearchUList = new List<TBOSearchU>();
                this._dispTBOSearchUDic = new Dictionary<string, TBOSearchU>();

                ArrayList retList = new ArrayList();

                // ��������
                status = this._tboSearchAcs.SearchAll(out retList, this._enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:

                        foreach (TBOSearchU tboSearchU in retList)
                        {
                            // �������ʃ��X�g�쐬
                            this._allTBOSearchUList.Add(tboSearchU);
                            
                            // �L�[�쐬
                            string key = CreateHashKey(tboSearchU);

                            // DataView�\���p���X�g�쐬
                            if (this._dispTBOSearchUDic.ContainsKey(key) == false)
                            {
                                this._dispTBOSearchUDic.Add(key, tboSearchU);
                            }
                        }

                        int index = 0;
                        foreach (TBOSearchU tboSearchU in this._dispTBOSearchUDic.Values)
                        {
                            // �f�[�^�Z�b�g�W�J
                            TBOSearchUToDataSet(tboSearchU.Clone(), index);
                            ++index;
                        }

                        totalCount = retList.Count;

                        break;
                    default:
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Search",
                                       "�����Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        return (status);
                }
            }
            catch (Exception)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Search",
                                       "�����Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                status = -1;
                return (status);
            }

            return 0;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // �����Ȃ�
            return 0;
        }

        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

        #endregion �� IMasterMaintenanceMultiType �����o


        #region �� Private Methods
        /// <summary>
        /// TBO�}�X�^���X�g�擾����(���[�U�[)
        /// </summary>
        /// <param name="equipGanreCode">��������</param>
        /// <param name="equipName">������</param>
        /// <returns>TBO�}�X�^���X�g(���[�U�[)</returns>
        /// <remarks>
        /// <br>Note       : TBO�}�X�^���X�g(���[�U�[)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private List<TBOSearchU> FindUserTBOSearchUList(int equipGanreCode, string equipName)
        {
            // ���[�U�[�f�[�^�擾
            List < TBOSearchU > userTBOSearchUList = this._allTBOSearchUList.FindAll(delegate(TBOSearchU target)
            {
                if ((target.EquipGenreCode == equipGanreCode) && (target.EquipName.Trim() == equipName.Trim()))
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            if (userTBOSearchUList == null)
            {
                userTBOSearchUList = new List<TBOSearchU>();
            }

            return userTBOSearchUList;
        }

        /// <summary>
        /// HashTable�pKey�쐬����
        /// </summary>
        /// <param name="tboSearchU">TBO�}�X�^�I�u�W�F�N�g</param>
        /// <returns>�L�[</returns>
        /// <remarks>
        /// <br>Note       : �n�b�V���e�[�u���p�̃L�[���쐬���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private string CreateHashKey(TBOSearchU tboSearchU)
        {
            return (tboSearchU.EquipGenreCode.ToString() + tboSearchU.EquipName.Trim());
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable dataTable = new DataTable(TBOSEARCHU_TABLE);

            //---------------------------------------------
            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            //---------------------------------------------

            // ����
            dataTable.Columns.Add(PLURAL_TITLE, typeof(string));
            // ��������
            dataTable.Columns.Add(EQUIPGANRECODE_TITLE, typeof(int));
            // ������
            dataTable.Columns.Add(EQUIPGANRENAME_TITLE, typeof(string));
            // �i��
            dataTable.Columns.Add(GOODSNO_TITLE, typeof(string));
            // �i��
            dataTable.Columns.Add(GOODSNAME_TITLE, typeof(string));
            // ���[�J�[�R�[�h
            dataTable.Columns.Add(MAKERCODE_TITLE, typeof(string));
            // ���[�J�[��
            dataTable.Columns.Add(MAKERNAME_TITLE, typeof(string));
            // BL�R�[�h
            dataTable.Columns.Add(BLGOODSCODE_TITLE, typeof(string));
            // BL�R�[�h��
            dataTable.Columns.Add(BLGOODSNAME_TITLE, typeof(string));
            // QTY
            dataTable.Columns.Add(QTY_TITLE, typeof(string));
            // �q�ɃR�[�h
            dataTable.Columns.Add(WAREHOUSECODE_TITLE, typeof(string));
            // �I��
            dataTable.Columns.Add(WAREHOUSESHELFNO_TITLE, typeof(string));
            // ���݌�
            dataTable.Columns.Add(SUPPLIERSTOCK_TITLE, typeof(string));
            // �K�i/���L����
            dataTable.Columns.Add(STANDARD_TITLE, typeof(string));
            // GUID
            dataTable.Columns.Add(GUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(dataTable);
        }

        /// <summary>
        /// �O���b�h�쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h���쐬���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void CreateGrid()
        {
            DataTable dataTable = new DataTable();

            // No.
            dataTable.Columns.Add(COLUMN_NO, typeof(int));
            // ����
            dataTable.Columns.Add(COLUMN_RANK, typeof(int));
            // �i��
            dataTable.Columns.Add(COLUMN_GOODSNO, typeof(string));
            // �i��
            dataTable.Columns.Add(COLUMN_GOODSNAME, typeof(string));
            // ���[�J�[�R�[�h
            dataTable.Columns.Add(COLUMN_MAKERCODE, typeof(string));
            // ���[�J�[��
            dataTable.Columns.Add(COLUMN_MAKERNAME, typeof(string));
            // BL�R�[�h
            dataTable.Columns.Add(COLUMN_BLGOODSCODE, typeof(string));
            // BL�R�[�h��
            dataTable.Columns.Add(COLUMN_BLGOODSNAME, typeof(string));
            // QTY
            dataTable.Columns.Add(COLUMN_QTY, typeof(string));
            // �q�ɃR�[�h
            dataTable.Columns.Add(COLUMN_WAREHOUSECODE, typeof(string));
            // �I��
            dataTable.Columns.Add(COLUMN_WAREHOUSESHELFNO, typeof(string));
            // ���݌�
            dataTable.Columns.Add(COLUMN_SUPPLIERSTOCK, typeof(string));
            // �K�i/���L����
            dataTable.Columns.Add(COLUMN_STANDARD, typeof(string));
            // �񋟋敪
            dataTable.Columns.Add(COLUMN_DIVISIONCODE, typeof(int));
            // �񋟋敪��
            dataTable.Columns.Add(COLUMN_DIVISIONNAME, typeof(string));
            // ���i�A���f�[�^
            dataTable.Columns.Add(COLUMN_GOODSUNITDATA, typeof(GoodsUnitData));

            this.uGrid_Details.DataSource = dataTable;

            if (this.uGrid_Details.Rows.Count < 9999)
            {
                // 1�s�ǉ�
                CreateNewRow(ref this.uGrid_Details);
            }

            this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();
        }

        /// <summary>
        /// �O���b�h���C�A�E�g�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h���C�A�E�g��ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j/br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void SetGridLayout()
        {
            ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            //--------------------------------------
            // ���͕s��
            //--------------------------------------
            columns[COLUMN_NO].CellActivation = Activation.Disabled;
            columns[COLUMN_RANK].CellActivation = Activation.Disabled;
            columns[COLUMN_GOODSNAME].CellActivation = Activation.Disabled;
            columns[COLUMN_MAKERNAME].CellActivation = Activation.Disabled;
            columns[COLUMN_BLGOODSCODE].CellActivation = Activation.Disabled;
            columns[COLUMN_BLGOODSNAME].CellActivation = Activation.Disabled;
            columns[COLUMN_WAREHOUSECODE].CellActivation = Activation.Disabled;
            columns[COLUMN_WAREHOUSESHELFNO].CellActivation = Activation.Disabled;
            columns[COLUMN_SUPPLIERSTOCK].CellActivation = Activation.Disabled;
            columns[COLUMN_DIVISIONCODE].CellActivation = Activation.Disabled;
            columns[COLUMN_DIVISIONNAME].CellActivation = Activation.Disabled;

            //--------------------------------------
            // �Z���J���[
            //--------------------------------------
            columns[COLUMN_NO].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            columns[COLUMN_NO].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            columns[COLUMN_NO].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[COLUMN_NO].CellAppearance.ForeColor = Color.White;
            columns[COLUMN_NO].CellAppearance.ForeColorDisabled = Color.White;

            //--------------------------------------
            // ��Œ�
            //--------------------------------------
            columns[COLUMN_NO].Header.Fixed = true;
            columns[COLUMN_RANK].Header.Fixed = true;
            columns[COLUMN_GOODSNO].Header.Fixed = true;

            //--------------------------------------
            // ��\��
            //--------------------------------------
            columns[COLUMN_DIVISIONCODE].Hidden = true;
            columns[COLUMN_GOODSUNITDATA].Hidden = true;

            //--------------------------------------
            // �L���v�V����
            //--------------------------------------
            columns[COLUMN_NO].Header.Caption = "No.";
            columns[COLUMN_RANK].Header.Caption = "����";
            columns[COLUMN_GOODSNO].Header.Caption = "�i��";
            columns[COLUMN_GOODSNAME].Header.Caption = "�i��";
            columns[COLUMN_MAKERCODE].Header.Caption = "Ұ��";
            columns[COLUMN_MAKERNAME].Header.Caption = "Ұ����";
            columns[COLUMN_BLGOODSCODE].Header.Caption = "BL����";
            columns[COLUMN_BLGOODSNAME].Header.Caption = "BL���ޖ�";
            columns[COLUMN_QTY].Header.Caption = "QTY";
            columns[COLUMN_WAREHOUSECODE].Header.Caption = "�q��";
            columns[COLUMN_WAREHOUSESHELFNO].Header.Caption = "�I��";
            columns[COLUMN_SUPPLIERSTOCK].Header.Caption = "���݌ɐ�";
            columns[COLUMN_STANDARD].Header.Caption = "�K�i/���L����";
            columns[COLUMN_DIVISIONCODE].Header.Caption = "�񋟋敪";
            columns[COLUMN_DIVISIONNAME].Header.Caption = "�񋟋敪";

            //--------------------------------------
            // ��
            //--------------------------------------
            columns[COLUMN_NO].Width = 50;
            columns[COLUMN_RANK].Width = 50;
            columns[COLUMN_GOODSNO].Width = 210;
            columns[COLUMN_GOODSNAME].Width = 330;
            columns[COLUMN_MAKERCODE].Width = 50;
            columns[COLUMN_MAKERNAME].Width = 180;
            columns[COLUMN_BLGOODSCODE].Width = 60;
            columns[COLUMN_BLGOODSNAME].Width = 180;
            columns[COLUMN_QTY].Width = 100;
            columns[COLUMN_WAREHOUSECODE].Width = 50;
            columns[COLUMN_WAREHOUSESHELFNO].Width = 80;
            columns[COLUMN_SUPPLIERSTOCK].Width = 100;
            columns[COLUMN_STANDARD].Width = 330;
            columns[COLUMN_DIVISIONCODE].Width = 80;
            columns[COLUMN_DIVISIONNAME].Width = 80;

            //--------------------------------------
            // ���͌���
            //--------------------------------------
            columns[COLUMN_NO].MaxLength = 4;
            columns[COLUMN_RANK].MaxLength = 4;
            columns[COLUMN_GOODSNO].MaxLength = 24;
            columns[COLUMN_GOODSNAME].MaxLength = 20;
            columns[COLUMN_MAKERCODE].MaxLength = 4;
            columns[COLUMN_MAKERNAME].MaxLength = 10;
            columns[COLUMN_BLGOODSCODE].MaxLength = 5;
            columns[COLUMN_BLGOODSNAME].MaxLength = 10;
            columns[COLUMN_QTY].MaxLength = 9;
            columns[COLUMN_WAREHOUSECODE].MaxLength = 4;
            columns[COLUMN_WAREHOUSESHELFNO].MaxLength = 9;
            columns[COLUMN_SUPPLIERSTOCK].MaxLength = 12;
            columns[COLUMN_STANDARD].MaxLength = 20;
            columns[COLUMN_DIVISIONCODE].MaxLength = 4;
            columns[COLUMN_DIVISIONNAME].MaxLength = 4;

            //--------------------------------------
            // �e�L�X�g�ʒu(HAlign)
            //--------------------------------------
            columns[COLUMN_NO].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_RANK].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_GOODSNO].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_GOODSNAME].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_MAKERCODE].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_MAKERNAME].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_BLGOODSCODE].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_BLGOODSNAME].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_QTY].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_WAREHOUSECODE].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_WAREHOUSESHELFNO].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_SUPPLIERSTOCK].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_STANDARD].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_DIVISIONCODE].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_DIVISIONNAME].CellAppearance.TextHAlign = HAlign.Left;

            //--------------------------------------
            // �e�L�X�g�ʒu(VAlign)
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellAppearance.TextVAlign = VAlign.Middle;
            }
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j/br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ClearScreen()
        {
            this.Mode_Label.Text = "";

            this.tComboEditor_EquipGenreCode.Value = 1001;
            this.tEdit_EquipGenreName.Clear();

            this._prevEquipGanreCode = 1001;
            this._prevEquipName = "";

            // �O���b�h������
            CreateGrid();
            SetGridLayout();
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="editMode">�ҏW���[�h(INSERT_MODE�F�V�K�@UPDATE_MODE�F�X�V)</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string editMode)
        {
            switch (editMode)
            {
                // �V�K���[�h
                case INSERT_MODE:

                    this.tComboEditor_EquipGenreCode.Enabled = true;
                    this.tEdit_EquipGenreName.Enabled = true;
                    this.EquipGenreGuide_Button.Enabled = true;

                    this.RowDelete_Button.Enabled = false;
                    this.GoodsRegist_Button.Enabled = false;

                    break;
                // �X�V���[�h
                case UPDATE_MODE:

                    this.tComboEditor_EquipGenreCode.Enabled = false;
                    this.tEdit_EquipGenreName.Enabled = false;
                    this.EquipGenreGuide_Button.Enabled = false;

                    this.RowDelete_Button.Enabled = true;
                    this.GoodsRegist_Button.Enabled = true;

                    break;
            }
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
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
        /// ���ꑕ�����ށE���������݃`�F�b�N
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <returns>True:���݁@False:�񑶍�</returns>
        /// <remarks>
        /// <br>Note       : ����̑������ށE�����������݂��邩�ǂ����`�F�b�N���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private bool CheckSameKey(string key)
        {
            int count = 0;

            foreach (TBOSearchU tboSearchU in this._allTBOSearchUList)
            {
                if (CreateHashKey(tboSearchU) == key)
                {
                    count++;
                }
            }

            if (count > 1)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        /// <summary>
        /// ���[�U�[�f�[�^�`�F�b�N����
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>�X�e�[�^�X(True:���[�U�[�f�[�^�@False:�񋟃f�[�^)</returns>
        /// <remarks>
        /// <br>Note       : �Ώۂ̏��i�A���f�[�^�����[�U�[�f�[�^�Ƃ��ēo�^����Ă��邩�ǂ����`�F�b�N���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private bool CheckUserData(GoodsUnitData goodsUnitData)
        {
            foreach (TBOSearchU tboSearchU in this._userTBOSearchUList)
            {
                if ((goodsUnitData.GoodsMakerCd == tboSearchU.JoinDestMakerCd) &&
                    (goodsUnitData.GoodsNo.Trim() == tboSearchU.JoinDestPartsNo.Trim()))
                {
                    return (true);
                }
            }

            return (false);
        }

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// <br>Note        : ���l�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/11/28</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                // �����_�܂��́A�}�C�i�X�ȊO
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string strResult = "";
            if (sellength > 0)
            {
                strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if ((priod <= 0) || (strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (strResult.Length > keta)
            {
                if (strResult[0] == '-')
                {
                    if (strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // �����_�ȉ��̃`�F�b�N
            if (priod > 0)
            {
                // �����_�̈ʒu����
                int _pointPos = strResult.IndexOf('.');

                // �������ɓ��͉\�Ȍ���������I
                int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    // �������̌������v�Z
                    int _priketa = strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ���ꏤ�i���݃`�F�b�N����
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="rowIndex">�Ώۍs�C���f�b�N�X</param>
        /// <returns>�X�e�[�^�X(True:�񑶍݁@False:����)</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h���ɓ��ꏤ�i�����邩�ǂ����`�F�b�N���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private bool CheckSameGoods(GoodsUnitData goodsUnitData, int rowIndex)
        {
            int makerCode;
            string goodsNo;

            for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
            {
                if (index == rowIndex)
                {
                    continue;
                }

                makerCode = StrObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_MAKERCODE].Value);
                goodsNo = StrObjToString(this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNO].Value);

                if ((goodsUnitData.GoodsMakerCd == makerCode) &&
                    (goodsUnitData.GoodsNo.Trim() == goodsNo.Trim()))
                {
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// TBO�}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="tboSearchU">TBO�}�X�^�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : TBO�}�X�^�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void TBOSearchUToDataSet(TBOSearchU tboSearchU, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].NewRow();
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows.Count - 1;
            }

            // ����
            if (CheckSameKey(CreateHashKey(tboSearchU)) == true)
            {
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][PLURAL_TITLE] = "��";
            }
            else
            {
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][PLURAL_TITLE] = "";
            }
            // ��������
            this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][EQUIPGANRECODE_TITLE] = tboSearchU.EquipGenreCode;
            // ������
            this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][EQUIPGANRENAME_TITLE] = tboSearchU.EquipName.Trim();
            // �i��
            this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][GOODSNO_TITLE] = tboSearchU.JoinDestPartsNo.Trim();
            // �i��
            this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][GOODSNAME_TITLE] = tboSearchU.JoinDestGoodsName.Trim();
            // DEL 2009/04/09 ------>>>
            //// ���[�J�[�R�[�h
            //this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][MAKERCODE_TITLE] = tboSearchU.JoinDestMakerCd.ToString("0000");
            //// ���[�J�[��
            //this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][MAKERNAME_TITLE] = tboSearchU.JoinDestMakerName.Trim();
            // DEL 2009/04/09 ------<<<

            // ADD 2009/04/09 ------>>>
            if (tboSearchU.JoinDestMakerCd == 0)
            {
                // ���[�J�[�R�[�h
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][MAKERCODE_TITLE] = "";
                // ���[�J�[��
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][MAKERNAME_TITLE] = "";
            }
            else
            {
                // ���[�J�[�R�[�h
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][MAKERCODE_TITLE] = tboSearchU.JoinDestMakerCd.ToString("0000");
                // ���[�J�[��
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][MAKERNAME_TITLE] = tboSearchU.JoinDestMakerName.Trim();
            }
            // ADD 2009/04/09 ------<<<
            
            if (tboSearchU.BLGoodsCode == 0)
            {
                // BL�R�[�h
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][BLGOODSCODE_TITLE] = "";
                // BL�R�[�h��
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][BLGOODSNAME_TITLE] = "";
            }
            else
            {
                // BL�R�[�h
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][BLGOODSCODE_TITLE] = tboSearchU.BLGoodsCode.ToString("00000");
                // BL�R�[�h��
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][BLGOODSNAME_TITLE] = this._tboSearchAcs.GetBLGoodsCdName(tboSearchU.BLGoodsCode);
            }
            // QTY
            this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][QTY_TITLE] = tboSearchU.JoinQty.ToString("N");

            Stock stock;
            int status = this._tboSearchAcs.GetStock(out stock, tboSearchU.JoinDestMakerCd, tboSearchU.JoinDestPartsNo, this._secWarehouseCode);
            if (status == 0)
            {
                // �q�ɃR�[�h
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][WAREHOUSECODE_TITLE] = this._secWarehouseCode.PadLeft(4, '0');
                // �I��
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][WAREHOUSESHELFNO_TITLE] = stock.WarehouseShelfNo.Trim();
                // ���݌�
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][SUPPLIERSTOCK_TITLE] = stock.SupplierStock.ToString("###,##0");
            }
            else
            {
                // �q�ɃR�[�h
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][WAREHOUSECODE_TITLE] = "";
                // �I��
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][WAREHOUSESHELFNO_TITLE] = "";
                // ���݌�
                this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][SUPPLIERSTOCK_TITLE] = "";
            }
            // �K�i/���L����
            this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][STANDARD_TITLE] = tboSearchU.EquipSpecialNote.Trim();
            // GUID
            this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[index][GUID_TITLE] = tboSearchU.FileHeaderGuid;
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j/br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            TBOSearchU tboSearchU = new TBOSearchU();

            // �V�K�̏ꍇ
            if (this._dataIndex < 0)
            {
                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // �N���[���쐬
                this._goodsUnitDataListClone = new List<GoodsUnitData>();

                this._userTBOSearchUList = new List<TBOSearchU>();

                // �t�H�[�J�X�ݒ�
                this.tComboEditor_EquipGenreCode.Focus();
            }
            else
            {
                // �������ރR�[�h
                int equipGanreCode = (int)this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[this._dataIndex][EQUIPGANRECODE_TITLE];
                // ������
                string equipName = (string)this.Bind_DataSet.Tables[TBOSEARCHU_TABLE].Rows[this._dataIndex][EQUIPGANRENAME_TITLE];

                this.tComboEditor_EquipGenreCode.Value = equipGanreCode;
                this.tEdit_EquipGenreName.DataText = equipName.Trim();

                // ���[�U�[�f�[�^�擾
                this._userTBOSearchUList = FindUserTBOSearchUList(equipGanreCode, equipName);

                List<GoodsUnitData> goodsUnitDataList;

                // ���i�A���f�[�^����
                int status = SearchGoodsUnitDataList(out goodsUnitDataList, equipGanreCode, equipName);
                if (status == 0)
                {
                    // ���i�A���f�[�^�����㏈��
                    AfterSearchGoodsUnitDataList(goodsUnitDataList);
                }
            }

            // _indexBuf�o�b�t�@�ێ�
            this._indexBuf = this._dataIndex;
        }

        /// <summary>
        /// ���i�A���f�[�^��������
        /// </summary>
        /// <param name="equipGanreCode">�������ރR�[�h</param>
        /// <param name="equipName">������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �������ށE�������ɊY�����鏤�i�A���f�[�^���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private int SearchGoodsUnitDataList(out List<GoodsUnitData> goodsUnitDataList, int equipGanreCode, string equipName)
        {
            int status;
            goodsUnitDataList = new List<GoodsUnitData>();

            try
            {
                status = this._tboSearchAcs.Search(out goodsUnitDataList, this._enterpriseCode, this._loginSectionCode, equipGanreCode, equipName);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// ���i�A���f�[�^�����㏈��
        /// </summary>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note       : �������ށE�������ɊY�����鏤�i�A���f�[�^�����݂����ꍇ�̏������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void AfterSearchGoodsUnitDataList(List<GoodsUnitData> goodsUnitDataList)
        {
            // �X�V���[�h
            this.Mode_Label.Text = UPDATE_MODE;

            // ��ʓ��͋����䏈��
            ScreenInputPermissionControl(UPDATE_MODE);

            // 2009.03.30 30413 ���� ���i�}�X�^�_���폜���̑Ή� >>>>>>START
            // ���i���폜��TBO���擾
            GetTBOSearchUOfDeletedGoodsInfo(ref goodsUnitDataList);
            // 2009.03.30 30413 ���� ���i�}�X�^�_���폜���̑Ή� <<<<<<END
            
            // �\�[�g
            SortGoodsUnitDataList(ref goodsUnitDataList);

            this.uGrid_Details.BeginUpdate();

            // �O���b�h������
            CreateGrid();

            int rowIndex = 0;
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                // ���i�A���f�[�^��ʓW�J
                GoodsUnitDataToScreen(goodsUnitData, rowIndex, false);
                // �V�K�s�쐬
                CreateNewRow(ref this.uGrid_Details);
                rowIndex++;
            }

            this.uGrid_Details.EndUpdate();

            // �N���[���쐬
            this._goodsUnitDataListClone = new List<GoodsUnitData>();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                this._goodsUnitDataListClone.Add(goodsUnitData);
            }

            for (int index = 0; index < this.uGrid_Details.Rows.Count - 1; index++)
            {
                // �Z��Enabled����
                ChangeGridCellEnabled(index, false);
            }

            // �t�H�[�J�X�ݒ�
            this.uGrid_Details.Focus();
            for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
            {
                if (this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNO].Activation == Activation.AllowEdit)
                {
                    this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNO].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    break;
                }
            }
        }

        /// <summary>
        /// ���i�A���f�[�^���X�g�\�[�g����
        /// </summary>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <returns>�\�[�g��̏��i�A���f�[�^���X�g</returns>
        /// <remarks>
        /// <br>Note       : ���i�A���f�[�^���X�g���\�[�g���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void SortGoodsUnitDataList(ref List<GoodsUnitData> goodsUnitDataList)
        {
            // �\�[�g��
            // ���[�U�[�o�^���A���ʁA���[�J�[�A�i�ԁ@���@�񋟕��A���ʁA���[�J�[�A�i��

            if (this._userTBOSearchUList.Count == 0)
            {
                // �񋟃f�[�^�̂�
                goodsUnitDataList.Sort(delegate(GoodsUnitData x, GoodsUnitData y)
                {
                    if (x.DisplayOrder != y.DisplayOrder)
                    {
                        return x.DisplayOrder - y.DisplayOrder;
                    }
                    else if (x.GoodsMakerCd != y.GoodsMakerCd)
                    {
                        return x.GoodsMakerCd - y.GoodsMakerCd;
                    }
                    else if (x.GoodsNo.Trim() != y.GoodsNo.Trim())
                    {
                        return x.GoodsNo.Trim().CompareTo(y.GoodsNo.Trim());
                    }
                    else
                    {
                        return 0;
                    }
                });
            }
            else
            {
                // ���[�U�[�f�[�^�A�񋟃f�[�^
                List<GoodsUnitData> userList = new List<GoodsUnitData>();
                List<GoodsUnitData> offerList = new List<GoodsUnitData>();

                bool userFlg = false;
                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    userFlg = false;

                    foreach (TBOSearchU tboSearchU in this._userTBOSearchUList)
                    {
                        if ((goodsUnitData.GoodsMakerCd == tboSearchU.JoinDestMakerCd) &&
                            (goodsUnitData.GoodsNo.Trim() == tboSearchU.JoinDestPartsNo.Trim()))
                        {
                            userFlg = true;
                            goodsUnitData.DisplayOrder = tboSearchU.CarInfoJoinDispOrder;
                            userList.Add(goodsUnitData.Clone());
                            break;
                        }
                    }

                    if (!userFlg)
                    {
                        offerList.Add(goodsUnitData.Clone());
                    }
                }

                userList.Sort(delegate(GoodsUnitData x, GoodsUnitData y)
                {
                    if (x.DisplayOrder != y.DisplayOrder)
                    {
                        return x.DisplayOrder - y.DisplayOrder;
                    }
                    else if (x.GoodsMakerCd != y.GoodsMakerCd)
                    {
                        return x.GoodsMakerCd - y.GoodsMakerCd;
                    }
                    else if (x.GoodsNo.Trim() != y.GoodsNo.Trim())
                    {
                        return x.GoodsNo.Trim().CompareTo(y.GoodsNo.Trim());
                    }
                    else
                    {
                        return 0;
                    }
                });

                offerList.Sort(delegate(GoodsUnitData x, GoodsUnitData y)
                {
                    if (x.DisplayOrder != y.DisplayOrder)
                    {
                        return x.DisplayOrder - y.DisplayOrder;
                    }
                    else if (x.GoodsMakerCd != y.GoodsMakerCd)
                    {
                        return x.GoodsMakerCd - y.GoodsMakerCd;
                    }
                    else if (x.GoodsNo.Trim() != y.GoodsNo.Trim())
                    {
                        return x.GoodsNo.Trim().CompareTo(y.GoodsNo.Trim());
                    }
                    else
                    {
                        return 0;
                    }
                });

                goodsUnitDataList = new List<GoodsUnitData>();

                foreach (GoodsUnitData goodsUnitData in userList)
                {
                    goodsUnitDataList.Add(goodsUnitData.Clone());
                }

                foreach (GoodsUnitData goodsUnitData in offerList)
                {
                    goodsUnitDataList.Add(goodsUnitData.Clone());
                }
            }
        }

        /// <summary>
        /// ���ʎ擾����
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : ���ʂ��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private int GetRank(GoodsUnitData goodsUnitData)
        {
            foreach (TBOSearchU tboSearchU in this._userTBOSearchUList)
            {
                if ((tboSearchU.JoinDestMakerCd == goodsUnitData.GoodsMakerCd) &&
                    (tboSearchU.JoinDestPartsNo.Trim() == goodsUnitData.GoodsNo.Trim()))
                {
                    return tboSearchU.CarInfoJoinDispOrder;
                }
            }

            return goodsUnitData.DisplayOrder;
        }

        /// <summary>
        /// ���ʎ擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="rowIndex">�s�C���f�b�N�X</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : ���ʂ��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private int GetRank(int targetMakerCode, int rowIndex)
        {
            int makerCode;

            for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
            {
                if (index == rowIndex)
                {
                    continue;
                }

                makerCode = StrObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_MAKERCODE].Value);

                // ���[�J�[�R�[�h����v����ꍇ
                if (makerCode == targetMakerCode)
                {
                    return IntObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_RANK].Value);
                }
            }

            bool sameFlg = false;
            for (int rank = 1; rank <= 9999; rank++)
            {
                sameFlg = false;

                for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
                {
                    if (rank == IntObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_RANK].Value))
                    {
                        sameFlg = true;
                        break;
                    }
                }

                if (!sameFlg)
                {
                    return rank;
                }
            }

            return (0);
        }

        /// <summary>
        /// ���i�A���f�[�^��ʓW�J����
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="rowIndex">�s�C���f�b�N�X</param>
        /// <param name="newFlg">�V�K�t���O(True:�V�K False:�X�V)</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void GoodsUnitDataToScreen(GoodsUnitData goodsUnitData, int rowIndex, bool newFlg)
        {
            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
            
            CellsCollection cells = this.uGrid_Details.Rows[rowIndex].Cells;

            // ����
            if (cells[COLUMN_RANK].Value == DBNull.Value)
            {
                if (newFlg)
                {
                    cells[COLUMN_RANK].Value = GetRank(goodsUnitData.GoodsMakerCd, rowIndex);
                }
                else
                {
                    cells[COLUMN_RANK].Value = GetRank(goodsUnitData);
                }
            }
            // �i��
            cells[COLUMN_GOODSNO].Value = goodsUnitData.GoodsNo.Trim();
            // �i��
            cells[COLUMN_GOODSNAME].Value = goodsUnitData.GoodsName.Trim();
            // DEL 2009/04/09 ------>>>
            //// ���[�J�[�R�[�h
            //cells[COLUMN_MAKERCODE].Value = goodsUnitData.GoodsMakerCd.ToString("0000");
            //// ���[�J�[��
            //cells[COLUMN_MAKERNAME].Value = goodsUnitData.MakerName.Trim();
            // DEL 2009/04/09 ------<<<

            // ADD 2009/04/09 ------>>>
            if (goodsUnitData.GoodsMakerCd == 0)
            {
                // ���[�J�[�R�[�h
                cells[COLUMN_MAKERCODE].Value = "";
                // ���[�J�[��
                cells[COLUMN_MAKERNAME].Value = "";
            }
            else
            {
                // ���[�J�[�R�[�h
                cells[COLUMN_MAKERCODE].Value = goodsUnitData.GoodsMakerCd.ToString("0000");
                // ���[�J�[��
                cells[COLUMN_MAKERNAME].Value = goodsUnitData.MakerName.Trim();
            }
            // ADD 2009/04/09 ------<<<
            
            if (goodsUnitData.BLGoodsCode == 0)
            {
                // BL�R�[�h
                cells[COLUMN_BLGOODSCODE].Value = "";
                // BL�R�[�h��
                cells[COLUMN_BLGOODSNAME].Value = "";
            }
            else
            {
                // BL�R�[�h
                cells[COLUMN_BLGOODSCODE].Value = goodsUnitData.BLGoodsCode.ToString("00000");
                // BL�R�[�h��
                cells[COLUMN_BLGOODSNAME].Value = this._tboSearchAcs.GetBLGoodsCdName(goodsUnitData.BLGoodsCode);
            }
            // �q�ɃR�[�h
            cells[COLUMN_WAREHOUSECODE].Value = "";
            // �I��
            cells[COLUMN_WAREHOUSESHELFNO].Value = "";
            // ���݌�
            cells[COLUMN_SUPPLIERSTOCK].Value = "0";

            foreach (Stock stock in goodsUnitData.StockList)
            {
                if (stock.WarehouseCode.Trim() == this._secWarehouseCode.Trim())
                {
                    // �q�ɃR�[�h
                    cells[COLUMN_WAREHOUSECODE].Value = this._secWarehouseCode.Trim();
                    // �I��
                    cells[COLUMN_WAREHOUSESHELFNO].Value = stock.WarehouseShelfNo.Trim();
                    // ���݌�
                    cells[COLUMN_SUPPLIERSTOCK].Value = stock.SupplierStock.ToString("###,##0");
                }
            }

            if (newFlg)
            {
                // QTY
                cells[COLUMN_QTY].Value = DBNull.Value;
                // �K�i/���L����
                cells[COLUMN_STANDARD].Value = DBNull.Value;
                // �񋟋敪
                cells[COLUMN_DIVISIONCODE].Value = 0;
                // �񋟋敪��
                cells[COLUMN_DIVISIONNAME].Value = "���[�U�[";
            }
            else
            {
                if (CheckUserData(goodsUnitData))
                {
                    cells[COLUMN_QTY].Value = "";
                    cells[COLUMN_STANDARD].Value = "";

                    foreach (TBOSearchU tboSearchU in this._userTBOSearchUList)
                    {
                        if ((tboSearchU.JoinDestMakerCd == goodsUnitData.GoodsMakerCd) &&
                            (tboSearchU.JoinDestPartsNo.Trim() == goodsUnitData.GoodsNo.Trim()))
                        {
                            // QTY
                            cells[COLUMN_QTY].Value = tboSearchU.JoinQty.ToString("N");
                            // �K�i/���L����
                            cells[COLUMN_STANDARD].Value = tboSearchU.EquipSpecialNote.Trim();
                            break;
                        }
                    }
                    // �񋟋敪
                    cells[COLUMN_DIVISIONCODE].Value = 0;
                    // �񋟋敪��
                    cells[COLUMN_DIVISIONNAME].Value = "���[�U�[";
                }
                else
                {
                    // QTY
                    cells[COLUMN_QTY].Value = goodsUnitData.JoinQty.ToString("N");
                    // �K�i/���L����
                    cells[COLUMN_STANDARD].Value = goodsUnitData.JoinSpecialNote.Trim();
                    // �񋟋敪
                    cells[COLUMN_DIVISIONCODE].Value = 1;
                    // �񋟋敪��
                    cells[COLUMN_DIVISIONNAME].Value = "��";
                }
            }
            
            // ���i�A���f�[�^
            cells[COLUMN_GOODSUNITDATA].Value = goodsUnitData.Clone();

            // �Z��Enabled����
            ChangeGridCellEnabled(rowIndex, true);

            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
        }

        /// <summary>
        /// ��ʏ��TBO�}�X�^�N���X�i�[����
        /// </summary>
        /// <param name="tboSearchUList">TBO�}�X�^���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�TBO�}�X�^�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ScreenToTBOSearchUList(out ArrayList tboSearchUList, out ArrayList goodsUnitDataList)
        {
            tboSearchUList = new ArrayList();
            goodsUnitDataList = new ArrayList();

            TBOSearchU tboSearchU;

            for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
            {
                // �񋟃f�[�^(TBO�}�X�^)�͕ۑ��ΏۂƂ��Ȃ�
                if (IntObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_DIVISIONCODE].Value) == 1)
                {
                    continue;
                }

                // �i�ԁE���[�J�[�EQTY�������͂̏ꍇ
                if ((StrObjToString(this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNO].Value) == "") &&
                    (StrObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_MAKERCODE].Value) == 0) &&
                    (StrObjToDouble(this.uGrid_Details.Rows[index].Cells[COLUMN_QTY].Value) == 0))
                {
                    continue;
                }

                tboSearchU = new TBOSearchU();

                // ��ƃR�[�h
                tboSearchU.EnterpriseCode = this._enterpriseCode;
                // BL�R�[�h
                tboSearchU.BLGoodsCode = StrObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_BLGOODSCODE].Value);
                // ��������
                tboSearchU.EquipGenreCode = (int)this.tComboEditor_EquipGenreCode.Value;
                // ������
                tboSearchU.EquipName = this.tEdit_EquipGenreName.DataText.Trim();
                // ����
                tboSearchU.CarInfoJoinDispOrder = IntObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_RANK].Value);
                // ���[�J�[�R�[�h
                tboSearchU.JoinDestMakerCd = StrObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_MAKERCODE].Value);
                // ���[�J�[��
                tboSearchU.JoinDestMakerName = StrObjToString(this.uGrid_Details.Rows[index].Cells[COLUMN_MAKERNAME].Value);
                // �i��
                tboSearchU.JoinDestPartsNo = StrObjToString(this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNO].Value);
                // �i��
                tboSearchU.JoinDestGoodsName = StrObjToString(this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNAME].Value);
                // QTY
                tboSearchU.JoinQty = StrObjToDouble(this.uGrid_Details.Rows[index].Cells[COLUMN_QTY].Value);
                // �����K�i�E���L����
                tboSearchU.EquipSpecialNote = StrObjToString(this.uGrid_Details.Rows[index].Cells[COLUMN_STANDARD].Value);

                if (this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSUNITDATA].Value != DBNull.Value)
                {
                    GoodsUnitData goodsUnitData = (GoodsUnitData)this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSUNITDATA].Value;

                    // �񋟃f�[�^(���i)
                    if (goodsUnitData.OfferKubun >= 3)
                    {
                        goodsUnitData.OfferDate = DateTime.MinValue;
                        if (goodsUnitData.GoodsPriceList != null)
                        {
                            foreach (GoodsPrice price in goodsUnitData.GoodsPriceList)
                            {
                                price.OfferDate = DateTime.MinValue;
                            }
                        }

                        goodsUnitDataList.Add(goodsUnitData.Clone());
                    }
                }

                tboSearchUList.Add(tboSearchU);
            }
        }

        /// <summary>
        /// TBO�}�X�^�}�X�^�ۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : TBO�}�X�^�}�X�^��ۑ����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private bool SaveProc()
        {
            // ���̓f�[�^�`�F�b�N
            if (CheckScreenInput() != true)
            {
                return (false);
            }

            // ��ʏ��i�[
            ArrayList saveTBOList;
            ArrayList saveGoodsList;
            ScreenToTBOSearchUList(out saveTBOList, out saveGoodsList);

            int status;

            //-------------------------------------
            // �ۑ�����
            //-------------------------------------
            if (saveTBOList.Count > 0)
            {
                status = this._tboSearchAcs.WriteRelation(saveTBOList, saveGoodsList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // �o�^�����_�C�A���O�\��
                            SaveCompletionDialog dialog = new SaveCompletionDialog();
                            dialog.ShowDialog(2);

                            // �Č���
                            int totalCount = 0;
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
                            // �o�^���s
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                           "SaveProc",
                                           "�o�^�Ɏ��s���܂����B",
                                           status,
                                           MessageBoxButtons.OK);
                            return (false);
                        }
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

            return (true);
        }

        /// <summary>
        /// ��ʏ����̓`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                if (this.tComboEditor_EquipGenreCode.Value == null)
                {
                    errMsg = "�������ނ�I�����Ă��������B";
                    this.tComboEditor_EquipGenreCode.Focus();
                    return (false);
                }

                if (this.tEdit_EquipGenreName.DataText.Trim() == "")
                {
                    errMsg = "����������͂��Ă��������B";
                    this.tEdit_EquipGenreName.Focus();
                    return (false);
                }

                bool inputFlg = false;

                for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
                {
                    CellsCollection cells = this.uGrid_Details.Rows[index].Cells;

                    // �i�ԁE���[�J�[�EQTY�������͂̏ꍇ
                    if ((StrObjToString(cells[COLUMN_GOODSNO].Value) == "") &&
                        (StrObjToInt(cells[COLUMN_MAKERCODE].Value) == 0) &&
                        (StrObjToDouble(cells[COLUMN_QTY].Value) == 0))
                    {
                        continue;
                    }

                    inputFlg = true;

                    if (StrObjToString(cells[COLUMN_GOODSNO].Value) == "")
                    {
                        errMsg = "�i�Ԃ���͂��Ă��������B";
                        this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNO].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return (false);
                    }

                    //if (StrObjToInt(cells[COLUMN_MAKERCODE].Value) == 0)  // DEL 2009/04/09
                    // ADD 2009/04/09
                    if ((cells[COLUMN_MAKERCODE].Activation == Activation.AllowEdit) &&
                        (StrObjToInt(cells[COLUMN_MAKERCODE].Value) == 0))
                    {
                        errMsg = "���[�J�[�R�[�h����͂��Ă��������B";
                        //this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNO].Activate();  // DEL 2009/04/09
                        this.uGrid_Details.Rows[index].Cells[COLUMN_MAKERCODE].Activate();  // ADD 2009/04/09
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return (false);
                    }

                    // ���[�U�[�f�[�^�̏ꍇ�̂݁A���݃`�F�b�N���s���܂�
                    if (IntObjToInt(cells[COLUMN_DIVISIONCODE].Value) == 0)
                    {
                        if (StrObjToString(cells[COLUMN_GOODSNAME].Value) == "")
                        {
                            errMsg = "���i�}�X�^�ɓo�^����Ă��܂���B";
                            this.uGrid_Details.Rows[index].Cells[COLUMN_GOODSNO].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                            return (false);
                        }

                        if (StrObjToDouble(cells[COLUMN_QTY].Value) == 0)
                        {
                            errMsg = "QTY����͂��Ă��������B";
                            this.uGrid_Details.Rows[index].Cells[COLUMN_QTY].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                            return (false);
                        }
                    }
                }

                if (!inputFlg)
                {
                    errMsg = "����������͂��Ă��������B";
                    this.tEdit_EquipGenreName.Focus();
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// ���i�o�^�O�`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�^�O�Ƀ`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private bool CheckBeforeGoodsRegist()
        {
            string errMsg = "";

            try
            {
                if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
                {
                    errMsg = "���i�o�^���s���s��I�����Ă��������B";
                    return (false);
                }

                // �Ώۍs�擾
                int rowIndex;
                if (this.uGrid_Details.ActiveCell == null)
                {
                    rowIndex = this.uGrid_Details.ActiveRow.Index;
                }
                else
                {
                    rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                }

                string goodsNo = StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNO].Value);
                int makerCode = StrObjToInt(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERCODE].Value);

                if (goodsNo == "")
                {
                    errMsg = "�i�Ԃ���͂��Ă��������B";
                    this.uGrid_Details.Focus();
                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNO].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }
                if (makerCode == 0)
                {
                    errMsg = "���[�J�[�R�[�h����͂��Ă��������B";
                    this.uGrid_Details.Focus();
                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERCODE].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// ��ʏ���r����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ� False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̔�r���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            // ��ʏ��擾(���[�U�[�f�[�^)
            ArrayList tboSearchUList;
            ArrayList goodsUnitDataList;
            ScreenToTBOSearchUList(out tboSearchUList, out goodsUnitDataList);

            if (tboSearchUList.Count != this._userTBOSearchUList.Count)
            {
                return (false);
            }

            bool sameFlg;
            foreach (TBOSearchU tboSearchU in this._userTBOSearchUList)
            {
                sameFlg = false;

                foreach (TBOSearchU newTBOSearchU in tboSearchUList)
                {
                    if ((tboSearchU.CarInfoJoinDispOrder == newTBOSearchU.CarInfoJoinDispOrder) &&
                        (tboSearchU.JoinDestMakerCd == newTBOSearchU.JoinDestMakerCd) &&
                        (tboSearchU.JoinDestPartsNo.Trim() == newTBOSearchU.JoinDestPartsNo.Trim()) &&
                        (tboSearchU.JoinQty == newTBOSearchU.JoinQty) &&
                        (tboSearchU.EquipSpecialNote.Trim() == newTBOSearchU.EquipSpecialNote.Trim()))
                    {
                        sameFlg = true;
                        break;
                    }
                }

                if (!sameFlg)
                {
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// �V�K�s�쐬����
        /// </summary>
        /// <param name="uGrid">�O���b�h</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�ɍs��ǉ����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void CreateNewRow(ref UltraGrid uGrid)
        {
            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;

            // �s�ǉ�
            uGrid.DisplayLayout.Bands[0].AddNew();

            // �s�ԍ��ݒ�
            uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_NO].Value = uGrid.Rows.Count;
            
            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
        }

        /// <summary>
        /// �O���b�h�s�N���A����
        /// </summary>
        /// <param name="rowIndex">�Ώۍs�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̑Ώۍs���N���A���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ClearRow(int rowIndex)
        {
            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;

            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_RANK].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNO].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNAME].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERCODE].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERNAME].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_BLGOODSNAME].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_QTY].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_WAREHOUSECODE].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_WAREHOUSESHELFNO].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_SUPPLIERSTOCK].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_STANDARD].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_DIVISIONCODE].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_DIVISIONNAME].Value = DBNull.Value;
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSUNITDATA].Value = DBNull.Value;

            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
        }

        /// <summary>
        /// �O���b�h����{�^��Enabled���䏈��
        /// </summary>
        /// <param name="enabled">�p�����[�^(True:�����@False:�����s��)</param>
        /// <remarks>
        /// <br>Note       : �O���b�h����{�^���̐�����s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ChangeButtonEnabled(bool enabled)
        {
            this.RowDelete_Button.Enabled = enabled;
            this.GoodsRegist_Button.Enabled = enabled;

            if (!enabled)
            {
                this.uGrid_Details.ActiveCell = null;
                this.uGrid_Details.ActiveRow = null;
            }
        }

        /// <summary>
        /// �Z��Enabled���䏈��
        /// </summary>
        /// <param name="rowIndex">�s�C���f�b�N�X</param>
        /// <param name="editFlg">�ҏW�t���O(True:�ҏW�@False:�ҏW�s��)</param>
        /// <remarks>
        /// <br>Note       : �Z���̓��͐�����s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ChangeGridCellEnabled(int rowIndex, bool editFlg)
        {
            CellsCollection cells = this.uGrid_Details.Rows[rowIndex].Cells;

            // ���[�U�[�f�[�^
            if (IntObjToInt(cells[COLUMN_DIVISIONCODE].Value) == 0)
            {
                if (editFlg)
                {
                    cells[COLUMN_GOODSNO].Activation = Activation.AllowEdit;
                    cells[COLUMN_MAKERCODE].Activation = Activation.AllowEdit;
                    cells[COLUMN_GOODSNO].Appearance.BackColor = Color.Empty;
                    cells[COLUMN_MAKERCODE].Appearance.BackColor = Color.Empty;
                }
                else
                {
                    cells[COLUMN_GOODSNO].Activation = Activation.NoEdit;
                    cells[COLUMN_MAKERCODE].Activation = Activation.NoEdit;
                    cells[COLUMN_GOODSNO].Appearance.BackColor = Color.Gainsboro;
                    cells[COLUMN_MAKERCODE].Appearance.BackColor = Color.Gainsboro;
                }

                cells[COLUMN_QTY].Activation = Activation.AllowEdit;
                cells[COLUMN_STANDARD].Activation = Activation.AllowEdit;
                cells[COLUMN_QTY].Appearance.BackColor = Color.Empty;
                cells[COLUMN_STANDARD].Appearance.BackColor = Color.Empty;
            }
            // �񋟃f�[�^
            else
            {
                cells[COLUMN_GOODSNO].Activation = Activation.NoEdit;
                cells[COLUMN_MAKERCODE].Activation = Activation.NoEdit;
                cells[COLUMN_QTY].Activation = Activation.NoEdit;
                cells[COLUMN_STANDARD].Activation = Activation.NoEdit;

                cells[COLUMN_GOODSNO].Appearance.BackColor = Color.Gainsboro;
                cells[COLUMN_MAKERCODE].Appearance.BackColor = Color.Gainsboro;
                cells[COLUMN_QTY].Appearance.BackColor = Color.Gainsboro;
                cells[COLUMN_STANDARD].Appearance.BackColor = Color.Gainsboro;
            }
        }

        #region �Z���l�ϊ�
        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <remarks>
        /// <br>Note        : �Z���l��Int�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/11/28</br>
        /// </remarks>
        private int IntObjToInt(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null))
            {
                return 0;
            }

            return (int)cellValue;
        }

        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <remarks>
        /// <br>Note        : �Z���l��String�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/11/28</br>
        /// </remarks>
        private string StrObjToString(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null))
            {
                return "";
            }

            return (string)cellValue;
        }

        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <remarks>
        /// <br>Note        : �Z���l��Int�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/11/28</br>
        /// </remarks>
        private int StrObjToInt(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || ((string)cellValue == ""))
            {
                return 0;
            }

            return int.Parse((string)cellValue);
        }

        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <remarks>
        /// <br>Note        : �Z���l��Int�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/11/28</br>
        /// </remarks>
        private double StrObjToDouble(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || ((string)cellValue == ""))
            {
                return 0;
            }

            return double.Parse((string)cellValue);
        }
        #endregion �Z���l�ϊ�

        #region ���b�Z�[�W�{�b�N�X�\��
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
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // �e�E�B���h�E�t�H�[��
                                         errLevel,                          // �G���[���x��
                                         ASSEMBLY_ID,                        // �A�Z���u��ID
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
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // �e�E�B���h�E�t�H�[��
                                         errLevel,			                // �G���[���x��
                                         this.Name,						    // �v���O��������
                                         ASSEMBLY_ID, 		  �@�@		    // �A�Z���u��ID
                                         methodName,						// ��������
                                         "",					            // �I�y���[�V����
                                         message,	                        // �\�����郁�b�Z�[�W
                                         status,							// �X�e�[�^�X�l
                                         this._tboSearchAcs,	            // �G���[�����������I�u�W�F�N�g
                                         msgButton,         			  	// �\������{�^��
                                         MessageBoxDefaultButton.Button1);	// �����\���{�^��

            return dialogResult;
        }
        #endregion ���b�Z�[�W�{�b�N�X�\��

        /// <summary>
        /// �������K�C�h�\������
        /// </summary>
        /// <param name="equipName">������</param>
        /// <param name="equipGanreCode">��������</param>
        /// <param name="searchName">������(�B�������Ή�)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �������K�C�h��\�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private int ShowEquipNameGuide(out string equipName, int equipGanreCode, string searchName)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            equipName = "";

            try
            {
                this.Cursor = Cursors.WaitCursor;

                status = this._tboSearchAcs.ExecuteGuid(this._enterpriseCode, equipGanreCode, searchName, out equipName);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return (status);
        }

        /// <summary>
        /// ���i�݌Ƀ}�X�^�N������
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="newFlg">�V�K�t���O(True:�V�K���[�h�@False:�X�V���[�h)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�݌Ƀ}�X�^���N�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>           : Redmine#35434�̑Ή�</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/06/03</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>           : Redmine#35434�̑Ή�</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/06/14</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>           : Redmine#35434�̑Ή�</br>
        /// </remarks>
        private int ShowGoodsStockMaster(ref GoodsUnitData goodsUnitData, int makerCode, string goodsNo, bool newFlg)
        {
            // ----- ADD ���N�@2013/06/14 Redmine#35434 ----->>>>>
            if (this.flag == 1)
            {
                return (0);
            }
            // ----- ADD ���N�@2013/06/14 Redmine#35434 -----<<<<<
            // ----- ADD ���N�@2013/05/02 Redmine#35434 ----->>>>>
            if (this._allDefSet != null)
            {
                if (this._allDefSet.GoodsStockMSTBootDiv == 0)
                {
                    // ----- ADD ���N�@2013/05/02 Redmine#35434 -----<<<<<
                    //PMKHN09380UA goodsStockMaster = new PMKHN09380UA(this._tboSearchAcs.GoodsAccess); // DEL  ���N�@2013/06/03 Redmine#35434
                    MAKHN09280UA goodsStockMaster = new MAKHN09280UA(this._tboSearchAcs.GoodsAccess); // ADD  ���N�@2013/06/03 Redmine#35434
                    // �V�K���[�h
                    if (newFlg)
                    {
                        this.flag = 1;// ADD ���N 2013/06/14 Redmine#35434
                        goodsStockMaster.ShowDialog(this, ref goodsUnitData, makerCode, goodsNo);
                        this.flag = 0;// ADD ���N 2013/06/14 Redmine#35434
                    }
                    // �X�V���[�h
                    else
                    {
                        // ���[�U�[�f�[�^
                        if (goodsUnitData.OfferKubun < 3)
                        {
                            // �_���폜����Ă���݌ɂ�����ꍇ�͎擾
                            List<Stock> stockList;
                            int status = this._tboSearchAcs.GetStockList(out stockList, goodsUnitData.Clone());
                            if (status == 0)
                            {
                                goodsUnitData.StockList = new List<Stock>();
                                goodsUnitData.StockList = stockList;
                            }
                        }
                        // �񋟃f�[�^
                        else
                        {
                            goodsUnitData.CreateDateTime = DateTime.Now;// ADD ���N 2013/06/14 Redmine#35434
                            // �񋟓��t���폜
                            goodsUnitData.OfferDate = DateTime.MinValue;
                            if (goodsUnitData.GoodsPriceList != null)
                            {
                                foreach (GoodsPrice price in goodsUnitData.GoodsPriceList)
                                {
                                    price.OfferDate = DateTime.MinValue;
                                }
                            }
                        }
                        this.flag = 1;// ADD ���N 2013/06/14 Redmine#35434
                        goodsStockMaster.ShowDialog(this, ref goodsUnitData);
                        this.flag = 0;// ADD ���N 2013/06/14 Redmine#35434
                    }
                    // ----- ADD ���N�@2013/05/02 Redmine#35434 ----->>>>>
                }
                else
                {
                    PMKHN09380UA goodsStockMaster = new PMKHN09380UA(this._tboSearchAcs.GoodsAccess);
                    // �V�K���[�h
                    if (newFlg)
                    {
                        this.flag = 1;// ADD ���N 2013/06/14 Redmine#35434
                        goodsStockMaster.ShowDialog(this, ref goodsUnitData, makerCode, goodsNo);
                        this.flag = 0;// ADD ���N 2013/06/14 Redmine#35434
                    }
                    // �X�V���[�h
                    else
                    {
                        // ���[�U�[�f�[�^
                        if (goodsUnitData.OfferKubun < 3)
                        {
                            // �_���폜����Ă���݌ɂ�����ꍇ�͎擾
                            List<Stock> stockList;
                            int status = this._tboSearchAcs.GetStockList(out stockList, goodsUnitData.Clone());
                            if (status == 0)
                            {
                                goodsUnitData.StockList = new List<Stock>();
                                goodsUnitData.StockList = stockList;
                            }
                        }
                        // �񋟃f�[�^
                        else
                        {
                            goodsUnitData.CreateDateTime = DateTime.Now;// ADD ���N 2013/06/14 Redmine#35434
                            // �񋟓��t���폜
                            goodsUnitData.OfferDate = DateTime.MinValue;
                            if (goodsUnitData.GoodsPriceList != null)
                            {
                                foreach (GoodsPrice price in goodsUnitData.GoodsPriceList)
                                {
                                    price.OfferDate = DateTime.MinValue;
                                }
                            }
                        }
                        this.flag = 1;// ADD ���N 2013/06/14 Redmine#35434
                        goodsStockMaster.ShowDialog(this, ref goodsUnitData);
                        this.flag = 0;// ADD ���N 2013/06/14 Redmine#35434
                    }
                }
            }
            // ----- ADD ���N�@2013/05/02 Redmine#35434 -----<<<<<
            return (0);
        }

        /// <summary>
        /// ���i�݌Ƀ}�X�^�N���㏈��
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="rowIndex">�s�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���i�݌Ƀ}�X�^���N����̏��������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void AfterShowGoodsStockMaster(GoodsUnitData goodsUnitData, int rowIndex)
        {
            // �O���b�h�ɔ��f
            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;

            // �i��
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNO].Value = goodsUnitData.GoodsNo.Trim();

            // �i��
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNAME].Value = goodsUnitData.GoodsName.Trim();

            if (goodsUnitData.BLGoodsCode == 0)
            {
                // BL�R�[�h
                this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Value = DBNull.Value;
                // BL�R�[�h��
                this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_BLGOODSNAME].Value = DBNull.Value;
            }
            else
            {
                // BL�R�[�h
                this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_BLGOODSCODE].Value = goodsUnitData.BLGoodsCode.ToString("00000");
                // BL�R�[�h��
                this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_BLGOODSNAME].Value = this._tboSearchAcs.GetBLGoodsCdName(goodsUnitData.BLGoodsCode);
            }

            // ���[�J�[�R�[�h
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERCODE].Value = goodsUnitData.GoodsMakerCd.ToString("0000");
            
            // ���[�J��
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERNAME].Value = goodsUnitData.MakerName.Trim();

            foreach (Stock stock in goodsUnitData.StockList)
            {
                if (stock.WarehouseCode.Trim() == this._secWarehouseCode.Trim())
                {
                    // �q�ɃR�[�h
                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_WAREHOUSECODE].Value = this._secWarehouseCode.Trim();
                    // �I��
                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_WAREHOUSESHELFNO].Value = stock.WarehouseShelfNo.Trim();
                    // ���݌ɐ�
                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_SUPPLIERSTOCK].Value = stock.SupplierStock.ToString("###,##0");
                    break;
                }
                else
                {
                    // �q�ɃR�[�h
                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_WAREHOUSECODE].Value = DBNull.Value;
                    // �I��
                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_WAREHOUSESHELFNO].Value = DBNull.Value;
                    // ���݌ɐ�
                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_SUPPLIERSTOCK].Value = DBNull.Value;
                }
            }

            // �񋟋敪
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_DIVISIONCODE].Value = 0;
            // �񋟋敪����
            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_DIVISIONNAME].Value = "���[�U�[";

            if (IntObjToInt(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_RANK].Value) == 0)
            {
                // ����
                this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_RANK].Value = GetRank(goodsUnitData.GoodsMakerCd, rowIndex);
            }

            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSUNITDATA].Value = goodsUnitData.Clone();

            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
        }

        #endregion �� Private Methods


        #region �� Control Events

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����[�h���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void PMKEN09110UA_Load(object sender, EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.SAVE];
            this.Cancel_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.CLOSE];
            this.EquipGenreGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // �R���g���[���T�C�Y�ݒ�
            this.tComboEditor_EquipGenreCode.Size = new Size(144, 24);
            this.tEdit_EquipGenreName.Size = new Size(496, 24);
        }

        /// <summary>
        /// FormClosing �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ��ʂ������鎞�ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void PMKEN09110UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._indexBuf = -2;

            // �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        /// VisibleChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̕\����Ԃ��ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void PMKEN09110UA_VisibleChanged(object sender, EventArgs e)
        {
            this.Owner.Activate();

            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                return;
            }

            // ��ʃN���A����
            ClearScreen();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �������K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void EquipGenreGuide_Button_Click(object sender, EventArgs e)
        {
            string equipName;
            int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;

            int status = ShowEquipNameGuide(out equipName, equipGanreCode, "*");
            if (status == 0)
            {
                if (equipName != this._prevEquipName.Trim())
                {
                    // �������ݒ�
                    this.tEdit_EquipGenreName.DataText = equipName.Trim();
                    this._prevEquipName = equipName.Trim();

                    List<GoodsUnitData> goodsUnitDataList;

                    // 2009.03.30 30413 ���� ���i�}�X�^�_���폜���̑Ή� >>>>>>START
                    // ���[�U�[�f�[�^�擾
                    this._userTBOSearchUList = FindUserTBOSearchUList(equipGanreCode, equipName);

                    // ���i�A���f�[�^��������
                    status = SearchGoodsUnitDataList(out goodsUnitDataList, equipGanreCode, equipName);
                    //if ((status == 0) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                    if ((status == 0) && ((goodsUnitDataList != null) && (goodsUnitDataList.Count > 0)) ||
                        ((this._userTBOSearchUList != null) && (this._userTBOSearchUList.Count > 0)))
                    {
                        //// ���[�U�[�f�[�^�擾
                        //this._userTBOSearchUList = FindUserTBOSearchUList(equipGanreCode, equipName);

                        // ���i�A���f�[�^�����㏈��
                        AfterSearchGoodsUnitDataList(goodsUnitDataList);
                    }
                    else
                    {
                        this.uGrid_Details.Rows[0].Cells[COLUMN_GOODSNO].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    // 2009.03.30 30413 ���� ���i�}�X�^�_���폜���̑Ή� <<<<<<END
                }
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ۑ��{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // �ۑ�����
            SaveProc();
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ����{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
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
                            this.Cancel_Button.Focus();
                            return;
                        }
                }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
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
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �s�폜�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void RowDelete_Button_Click(object sender, EventArgs e)
        {
            // �A�N�e�B�u�s�`�F�b�N
            if ((this.uGrid_Details.ActiveRow == null) && (this.uGrid_Details.ActiveCell == null))
            {
                return;
            }

            // �A�N�e�B�u�s�擾
            int activeRowIndex;
            if (this.uGrid_Details.ActiveRow != null)
            {
                activeRowIndex = this.uGrid_Details.ActiveRow.Index;
            }
            else
            {
                activeRowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }

            DialogResult res;

            // �񋟃f�[�^�̏ꍇ
            if (IntObjToInt(this.uGrid_Details.Rows[activeRowIndex].Cells[COLUMN_DIVISIONCODE].Value) != 0)
            {
                res = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                     "�񋟃f�[�^�̂��߁A�폜�ł��܂���B",
                                     0,
                                     MessageBoxButtons.OK,
                                     MessageBoxDefaultButton.Button1);
                return;
            }

            res = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                 "�I���s���폜���Ă���낵���ł����H",
                                 0,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxDefaultButton.Button1);
            if (res == DialogResult.No)
            {
                return;
            }

            if (this.uGrid_Details.Rows.Count == 1)
            {
                // �A�N�e�B�u�s�N���A
                ClearRow(activeRowIndex);
            }
            else
            {
                // �A�N�e�B�u�s�폜
                this.uGrid_Details.Rows[activeRowIndex].Delete(false);
            }

            // No.�ĕ\��
            for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
            {
                this.uGrid_Details.Rows[index].Cells[COLUMN_NO].Value = index + 1;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���i�o�^�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void GoodsRegist_Button_Click(object sender, EventArgs e)
        {
            // ���i�o�^�O�`�F�b�N
            bool bStatus = CheckBeforeGoodsRegist();
            if (!bStatus)
            {
                return;
            }

            // �Ώۍs�擾
            int rowIndex;
            if (this.uGrid_Details.ActiveCell == null)
            {
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }
            else
            {
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }

            // �i�Ԏ擾
            string goodsNo = StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNO].Value);
            // ���[�J�[�R�[�h�擾
            int makerCode = StrObjToInt(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERCODE].Value);
            
            // ���i�A���f�[�^�擾
            bool newFlg;
            GoodsUnitData goodsUnitData;
            if (this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSUNITDATA].Value == DBNull.Value)
            {
                newFlg = true;
                goodsUnitData = new GoodsUnitData();
            }
            else
            {
                newFlg = false;
                goodsUnitData = (GoodsUnitData)this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSUNITDATA].Value;
            }

            // ���i�݌Ƀ}�X�^�\��
            int status = ShowGoodsStockMaster(ref goodsUnitData, makerCode, goodsNo, newFlg);
            if (goodsUnitData.FileHeaderGuid != Guid.Empty)
            {
                // �O���b�h�ɔ��f
                AfterShowGoodsStockMaster(goodsUnitData.Clone(), rowIndex);
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���p�o�^�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void QuotationRegist_Button_Click(object sender, EventArgs e)
        {
            // ���p�o�^��ʕ\��
            PMKEN09110UB pmken09110UB = new PMKEN09110UB();

            if (this.tComboEditor_EquipGenreCode.Value != null)
            {
                // ��������
                pmken09110UB.EquipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;
            }
            // ������
            pmken09110UB.EquipGanreName = this.tEdit_EquipGenreName.DataText.Trim();
            // TBO�������ʃ��X�g(�S���[�U�[�f�[�^)
            pmken09110UB.AllTBOSearchUList = this._allTBOSearchUList;

            DialogResult res = pmken09110UB.ShowDialog();

            // �ۑ��������s��ꂽ�ꍇ
            if (res == DialogResult.OK)
            {
                // �Č���
                int totalCount = 0;
                Search(ref totalCount, 0);

                // �������ރR�[�h
                int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;
                // ������
                string equipName = (string)this.tEdit_EquipGenreName.DataText.Trim();

                if ((equipGanreCode != pmken09110UB.EquipGanreCode) ||
                    (equipName.Trim() != pmken09110UB.EquipGanreName.Trim()))
                {
                    return;
                }

                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "���ݕ\�����̑������ށE�������ɑ΂��Ĉ��p�o�^���s���܂����B" + "\r\n" + "\r\n" + "�ҏW���̃f�[�^�͔j������܂��B",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);

                // ���[�U�[�f�[�^�擾
                this._userTBOSearchUList = FindUserTBOSearchUList(equipGanreCode, equipName);

                List<GoodsUnitData> goodsUnitDataList;

                // ���i�A���f�[�^����
                int status = SearchGoodsUnitDataList(out goodsUnitDataList, equipGanreCode, equipName);
                if (status == 0)
                {
                    // ���i�A���f�[�^�����㏈��
                    AfterSearchGoodsUnitDataList(goodsUnitDataList);
                }
            }
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�ŃL�[�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// <br>Update Note: 2013/06/14 ���N</br>
        /// <br>           : Redmine#35434</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            int columnIndex = this.uGrid_Details.ActiveCell.Column.Index;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        e.Handled = true;

                        if (rowIndex == 0)
                        {
                            // ���p�o�^�{�^���Ƀt�H�[�J�X
                            this.QuotationRegist_Button.Focus();
                        }
                        else
                        {
                            for (int index = rowIndex - 1; index >= 0; index--)
                            {
                                if (this.uGrid_Details.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit)
                                {
                                    this.uGrid_Details.Rows[index].Cells[columnIndex].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }

                            // ���p�o�^�{�^���Ƀt�H�[�J�X
                            this.QuotationRegist_Button.Focus();
                        }

                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex == this.uGrid_Details.Rows.Count - 1)
                        {
                            // �ۑ��{�^���Ƀt�H�[�J�X
                            this.Ok_Button.Focus();
                            ChangeButtonEnabled(false);
                        }
                        else
                        {
                            for (int index = rowIndex + 1; index < this.uGrid_Details.Rows.Count; index++)
                            {
                                if (this.uGrid_Details.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit)
                                {
                                    this.uGrid_Details.Rows[index].Cells[columnIndex].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }

                            // �ۑ��{�^���Ƀt�H�[�J�X
                            this.Ok_Button.Focus();
                            ChangeButtonEnabled(false);
                        }

                        break;
                    }
                case Keys.Left:
                    {
                        if (this.uGrid_Details.ActiveCell.IsInEditMode)
                        {
                            if (this.uGrid_Details.ActiveCell.SelStart == 0)
                            {
                                e.Handled = true;
                                this.uGrid_Details.PerformAction(UltraGridAction.PrevCellByTab);
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (this.uGrid_Details.ActiveCell.IsInEditMode)
                        {
                            if (this.uGrid_Details.ActiveCell.SelStart >= this.uGrid_Details.ActiveCell.Text.Length)
                            {
                                e.Handled = true;
                                this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                            }
                        }
                        break;
                    }
                // ----- ADD ���N 2013/06/14 Redmine#35434----->>>>>
                case Keys.I:
                    {
                        if (e.Alt)
                        {
                            if (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_MAKERCODE)
                            {
                                this.GoodsRegist_Button.Focus();
                            }
                            else if (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_GOODSNO)
                            {
                                this.GoodsRegist_Button.Focus();
                            }
                            else
                            {
                            }
                        }
                        break;
                    }
                // ----- ADD ���N 2013/06/14 Redmine#35434-----<<<<<
            }
        }

        /// <summary>
        /// KeyPress �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�ŃL�[�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (cell.IsInEditMode)
            {
                // QTY
                if (cell.Column.Key == COLUMN_QTY)
                {
                    if (!KeyPressNumCheck(5, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // UI�ݒ���Q��
                else if (this.uiSetControl1.CheckMatchingSet(cell.Column.Key, e.KeyChar) == false)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// BeforeCellActivate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Z�����A�N�e�B�u������O�ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            // ���ڂɏ]��IME���[�h�ݒ�
            this.uGrid_Details.ImeMode = this.uiSetControl1.GetSettingImeMode(e.Cell.Column.Key);

            // �[���l�߉������s
            if (e.Cell.Column.DataType == typeof(string) &&
                e.Cell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
            {
                if (e.Cell.Value != DBNull.Value)
                {
                    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value =
                        this.uiSetControl1.GetZeroPadCanceledText(e.Cell.Column.Key,
                        (string)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Key].Value);
                }
            }
        }

        /// <summary>
        /// AfterCellActivate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Z�����A�N�e�B�u��������ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            // �O���b�h����{�^������
            ChangeButtonEnabled(true);
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Z���̕ҏW���[�h���I���������ɔ������܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/11/28</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            // ���[�J�[�R�[�h
            if (uGrid.ActiveCell.Column.Key == COLUMN_MAKERCODE)
            {
                int makerCode = StrObjToInt(uGrid.ActiveCell.Value);

                if (makerCode != 0)
                {
                    this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;

                    // �[���l��
                    uGrid.ActiveCell.Value = makerCode.ToString("0000");

                    this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
                }
            }
            // QTY
            else if (uGrid_Details.ActiveCell.Column.Key == COLUMN_QTY)
            {
                double qty = StrObjToDouble(uGrid.ActiveCell.Value);

                if (qty == 0)
                {
                    return;
                }

                this.uGrid_Details.AfterCellUpdate -= uGrid_Details_AfterCellUpdate;

                // �J���}�l��
                uGrid.ActiveCell.Value = qty.ToString("N");

                this.uGrid_Details.AfterCellUpdate += uGrid_Details_AfterCellUpdate;
            }
        }

        /// <summary>
        /// BeforeCellUpdate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Z���̒l���X�V����鎞�ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            string columnKey = this.uGrid_Details.ActiveCell.Column.Key;

            switch (columnKey)
            {
                case COLUMN_GOODSNO:
                    {
                        this._prevGoodsNo = StrObjToString(this.uGrid_Details.ActiveCell.Value);
                        break;
                    }
                case COLUMN_MAKERCODE:
                    {
                        this._prevMakerCode = StrObjToInt(this.uGrid_Details.ActiveCell.Value);
                        break;
                    }
            }
        }

        /// <summary>
        /// AfterCellUpdate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Z���̒l���X�V���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// <br>Update Note: 2013/04/01 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/04/10�z�M��</br>
        /// <br>             Redmine#34640 ���i�݌Ƀ}�X�^�̎d�l�ύX(#33231�̎c����)</br>
        /// <br>Update Note: 2013/06/14 ���N</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/04/10�z�M��</br>
        /// <br>             Redmine#35434 ���i�݌Ƀ}�X�^�̕���</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            UltraGridCell activeCell = this.uGrid_Details.ActiveCell;

            int rowIndex = activeCell.Row.Index;
            string columnKey = activeCell.Column.Key;

            switch (columnKey)
            {
                case COLUMN_GOODSNO:
                    {
                        // �i��
                        string goodsNo = StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNO].Value);

                        if (goodsNo == "")
                        {
                            // �s�N���A
                            ClearRow(rowIndex);

                            return;
                        }
                        // ----- ADD ���N�@2013/06/14�@Redmine#35434 ----->>>>>
                        this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                        this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSUNITDATA].Value = DBNull.Value;
                        this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        // ----- ADD ���N  2013/06/14 Redmine#35434 -----<<<<<
                        // ���[�J�[�R�[�h
                        //int makerCode = StrObjToInt(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERCODE].Value); // DEL 2009/03/16
                        int makerCode = 0; // ADD 2009/03/16

                        // ���i����
                        GoodsUnitData goodsUnitData;
                        int status = this._tboSearchAcs.SearchGoods(out goodsUnitData, makerCode, goodsNo);
                        if (status == 0)
                        {
                            // ���ꏤ�i���݃`�F�b�N
                            bool bStatus = CheckSameGoods(goodsUnitData, rowIndex);
                            if (!bStatus)
                            {
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                               "���ꏤ�i�����݂��邽�ߑI���ł��܂���B",
                                               0,
                                               MessageBoxButtons.OK,
                                               MessageBoxDefaultButton.Button1);

                                // �s�N���A
                                ClearRow(rowIndex);

                                return;
                            }

                            // �O���b�h�ɔ��f
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;//  ADD ���N�@2013/06/14�@Redmine#35434
                            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_RANK].Value = DBNull.Value;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;//  ADD ���N�@2013/06/14�@Redmine#35434
                            GoodsUnitDataToScreen(goodsUnitData, rowIndex, true);
                        }
                        else if (status == -1)
                        {
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;

                            this.uGrid_Details.ActiveCell.Value = this._prevGoodsNo;

                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }
                        else
                        {
                            // �i�ԁE���[�J�[�����͂���Ă���ꍇ
                            if ((goodsNo != "") && (makerCode != 0))
                            {
                                // ���i�݌Ƀ}�X�^�N��
                                goodsUnitData = new GoodsUnitData();
                                status = ShowGoodsStockMaster(ref goodsUnitData, makerCode, goodsNo, true);
                                if (goodsUnitData.FileHeaderGuid != Guid.Empty)
                                {
                                    // �O���b�h�ɔ��f
                                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_RANK].Value = DBNull.Value;
                                    AfterShowGoodsStockMaster(goodsUnitData.Clone(), rowIndex);
                                }
                                else
                                {
                                    this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSUNITDATA].Value = DBNull.Value;
                                    this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                                }
                            }
                        }

                        break;
                    }
                case COLUMN_MAKERCODE:
                    {
                        // ���[�J�[�R�[�h
                        int makerCode = StrObjToInt(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_MAKERCODE].Value);

                        if (makerCode == 0)
                        {
                            // �s�N���A
                            ClearRow(rowIndex);

                            return;
                        }
                        //--- ADD 2013/04/01 �c���� Redmine#34640 --->>>>>
                        else
                        {
                            // ----- ADD ���N�@2013/06/14�@Redmine#35434 ----->>>>>
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSUNITDATA].Value = DBNull.Value;
                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                            // ----- ADD ���N  2013/06/14 Redmine#35434 -----<<<<<
                            MakerUMnt makerUMnt;

                            // ���[�J�[���擾����
                            int stus = this._goodsAcs.GetMaker(this._enterpriseCode, makerCode, out makerUMnt);
                            if (stus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "���[�J�[�R�[�h�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);

                                this.uGrid_Details.BeforeCellUpdate -= this.uGrid_Details_BeforeCellUpdate;
                                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                                if (this._prevMakerCode != 0)
                                {
                                    this.uGrid_Details.ActiveCell.Value = this._prevMakerCode;
                                }
                                else
                                {
                                    this.uGrid_Details.ActiveCell.Value = DBNull.Value;
                                }
                                this.uGrid_Details.BeforeCellUpdate += this.uGrid_Details_BeforeCellUpdate;
                                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                                return;
                            }
                        }
                        //--- ADD 2013/04/01 �c���� Redmine#34640 ---<<<<<

                        // �i��
                        string goodsNo = StrObjToString(this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSNO].Value);

                        // ���i����
                        GoodsUnitData goodsUnitData;
                        int status = this._tboSearchAcs.SearchGoods(out goodsUnitData, makerCode, goodsNo);
                        if (status == 0)
                        {
                            // ���ꏤ�i���݃`�F�b�N
                            bool bStatus = CheckSameGoods(goodsUnitData, rowIndex);
                            if (!bStatus)
                            {
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                               "���ꏤ�i�����݂��邽�ߑI���ł��܂���B",
                                               0,
                                               MessageBoxButtons.OK,
                                               MessageBoxDefaultButton.Button1);

                                // �s�N���A
                                ClearRow(rowIndex);

                                return;
                            }


                            // �O���b�h�ɔ��f
                            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_RANK].Value = DBNull.Value;
                            GoodsUnitDataToScreen(goodsUnitData, rowIndex, true);
                        }
                        else if (status == -1)
                        {
                            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;

                            if (this._prevMakerCode != 0)
                            {
                                this.uGrid_Details.ActiveCell.Value = this._prevMakerCode;
                            }
                            else
                            {
                                this.uGrid_Details.ActiveCell.Value = "";
                            }

                            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                        }
                        else
                        {
                            // �i�ԁE���[�J�[�����͂���Ă���ꍇ
                            if ((goodsNo != "") && (makerCode != 0))
                            {
                                // ���i�݌Ƀ}�X�^�N��
                                goodsUnitData = new GoodsUnitData();
                                status = ShowGoodsStockMaster(ref goodsUnitData, makerCode, goodsNo, true);
                                if (goodsUnitData.FileHeaderGuid != Guid.Empty)
                                {
                                    // �O���b�h�ɔ��f
                                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_RANK].Value = DBNull.Value;
                                    AfterShowGoodsStockMaster(goodsUnitData.Clone(), rowIndex);
                                }
                                else
                                {
                                    this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GOODSUNITDATA].Value = DBNull.Value;
                                    this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                                }
                            }
                        }

                        break;
                    }
            }

            // �ŏI�s�̏ꍇ
            if ((this.uGrid_Details.Rows.Count != 9999) &&
                (rowIndex == this.uGrid_Details.Rows.Count - 1))
            {
                // �s�ǉ�
                CreateNewRow(ref this.uGrid_Details);

                this.uGrid_Details.ActiveCell = activeCell;
            }
        }

        /// <summary>
        /// ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �������ނ̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void tComboEditor_EquipGenreCode_ValueChanged(object sender, EventArgs e)
        {
            // ��������
            int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;
            if (equipGanreCode == this._prevEquipGanreCode)
            {
                return;
            }

            // ������
            string equipName = this.tEdit_EquipGenreName.DataText.Trim();
            if (equipName == "")
            {
                return;
            }

            List<GoodsUnitData> goodsUnitDataList;

            // ���i�A���f�[�^��������
            int status = SearchGoodsUnitDataList(out goodsUnitDataList, equipGanreCode, equipName);
            if ((status == 0) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
            {
                if (this.uGrid_Details.Rows.Count > 1)
                {
                    DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                                      "�������ނ�ύX����Ɩ��ׂ����Z�b�g����܂��B" + "\r\n" + "\r\n" + "�������ނ�ύX���܂����H",
                                                      0,
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxDefaultButton.Button1);
                    if (res != DialogResult.Yes)
                    {
                        this.tComboEditor_EquipGenreCode.ValueChanged -= tComboEditor_EquipGenreCode_ValueChanged;
                        this.tComboEditor_EquipGenreCode.Value = this._prevEquipGanreCode;
                        this.tComboEditor_EquipGenreCode.ValueChanged += tComboEditor_EquipGenreCode_ValueChanged;
                        this.tComboEditor_EquipGenreCode.Focus();
                        return;
                    }
                }

                // ���[�U�[�f�[�^�擾
                this._userTBOSearchUList = FindUserTBOSearchUList(equipGanreCode, equipName);

                // ���i�A���f�[�^�����㏈��
                AfterSearchGoodsUnitDataList(goodsUnitDataList);
            }

            this._prevEquipGanreCode = equipGanreCode;
        }

        /// <summary>
        /// Tick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					 ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					 �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // ��ʍč\�z����
            ScreenReconstruction();
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X���ڂ������ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // ������
                case "tEdit_EquipGenreName":
                    {
                        string equipName = this.tEdit_EquipGenreName.DataText.Trim();

                        if (equipName != "")
                        {
                            if (equipName != this._prevEquipName.Trim())
                            {
                                // �������ރR�[�h�擾
                                int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;

                                // �B������
                                if (equipName.Substring(equipName.Length - 1) == "*")
                                {
                                    string retName;

                                    // �������ރK�C�h�\��
                                    int status = ShowEquipNameGuide(out retName, equipGanreCode, equipName);
                                    if (status == 0)
                                    {
                                        this.tEdit_EquipGenreName.DataText = retName.Trim();
                                        this._prevEquipName = retName.Trim();
                                    }
                                }
                                else
                                {
                                    List<GoodsUnitData> goodsUnitDataList;

                                    // ���i�A���f�[�^��������
                                    int status = SearchGoodsUnitDataList(out goodsUnitDataList, equipGanreCode, equipName);
                                    if ((status == 0) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                                    {
                                        if (this.uGrid_Details.Rows.Count > 1)
                                        {
                                            DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                                                              "��������ύX����Ɩ��ׂ����Z�b�g����܂��B" + "\r\n" + "\r\n" + "��������ύX���܂����H",
                                                                              0,
                                                                              MessageBoxButtons.YesNo,
                                                                              MessageBoxDefaultButton.Button1);
                                            if (res != DialogResult.Yes)
                                            {
                                                this.tEdit_EquipGenreName.DataText = this._prevEquipName;
                                                e.NextCtrl = e.PrevCtrl;
                                                return;
                                            }
                                        }

                                        // ���[�U�[�f�[�^�擾
                                        this._userTBOSearchUList = FindUserTBOSearchUList(equipGanreCode, equipName);

                                        // ���i�A���f�[�^�����㏈��
                                        AfterSearchGoodsUnitDataList(goodsUnitDataList);
                                    }

                                    this._prevEquipName = equipName;
                                }
                            }
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_EquipGenreName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Focus();
                                    this.uGrid_Details.Rows[0].Cells[COLUMN_GOODSNO].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Focus();
                                this.uGrid_Details.Rows[0].Cells[COLUMN_GOODSNO].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }
                // �������K�C�h�{�^��
                case "EquipGenreGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Focus();
                                this.uGrid_Details.Rows[0].Cells[COLUMN_GOODSNO].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }
                // �O���b�h
                case "uGrid_Details":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.uGrid_Details.ActiveCell == null)
                                {
                                    break;
                                }

                                int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                                string columnKey = this.uGrid_Details.ActiveCell.Column.Key;

                                if ((rowIndex == this.uGrid_Details.Rows.Count - 1) &&
                                    (columnKey == COLUMN_STANDARD))
                                {
                                    // �ۑ��{�^���Ƀt�H�[�J�X
                                    e.NextCtrl = this.Ok_Button;
                                }
                                else
                                {
                                    // ���̃Z���Ƀt�H�[�J�X
                                    e.NextCtrl = null;
                                    this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.uGrid_Details.ActiveCell == null)
                                {
                                    break;
                                }

                                int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                                int columnIndex = this.uGrid_Details.ActiveCell.Column.Index;

                                if ((rowIndex == 0) && (columnIndex == 2))
                                {
                                    if (this.tEdit_EquipGenreName.DataText.Trim() != "")
                                    {
                                        // �������Ƀt�H�[�J�X
                                        e.NextCtrl = this.tEdit_EquipGenreName;
                                    }
                                    else
                                    {
                                        // �������K�C�h�{�^���Ƀt�H�[�J�X
                                        e.NextCtrl = this.EquipGenreGuide_Button;
                                    }
                                }
                                else
                                {
                                    // �O�̃Z���Ƀt�H�[�J�X
                                    e.NextCtrl = null;
                                    this.uGrid_Details.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                            }
                        }

                        break;
                    }
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                case "tComboEditor_EquipGenreCode":
                case "tEdit_EquipGenreName":
                case "EquipGenreGuide_Button":
                case "Ok_Button":
                case "Cancel_Button":
                    {
                        // �O���b�h����{�^������
                        ChangeButtonEnabled(false);
                        break;
                    }
                // �O���b�h
                case "uGrid_Details":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Focus();
                                this.uGrid_Details.Rows[0].Cells[COLUMN_GOODSNO].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else if (e.Key == Keys.Up)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Focus();
                                this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[COLUMN_GOODSNO].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Focus();
                                this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[COLUMN_STANDARD].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }
            }
        }

        #endregion �� Control Events

        // 2009.03.30 30413 ���� ���i�}�X�^�_���폜���̑Ή� >>>>>>START
        /// <summary>
        /// ���i���폜��TBO���擾����
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        private void GetTBOSearchUOfDeletedGoodsInfo(ref List<GoodsUnitData> goodsUnitDataList)
        {
            if ((goodsUnitDataList == null) || (this._userTBOSearchUList == null)) return;

            //-----------------------------------------------------------------------------
            // TBO���̃L���b�V���ɑ��݂��āA�������ʂɑ��݂��Ȃ��ꍇ�A�폜���Ƃ��Đݒ�(�폜�����\���ΏۂƂ����)
            //-----------------------------------------------------------------------------
            foreach (TBOSearchU workTBOSearchU in this._userTBOSearchUList)
            {
                GoodsUnitData goodsUnitData = goodsUnitDataList.Find(
                    delegate(GoodsUnitData goodsData)
                    {
                        if ((goodsData.GoodsMakerCd == workTBOSearchU.JoinDestMakerCd) &&
                            (goodsData.GoodsNo == workTBOSearchU.JoinDestPartsNo))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (goodsUnitData == null)
                {
                    GoodsUnitData addGoodsUnitData = new GoodsUnitData();
                    addGoodsUnitData.GoodsNo = workTBOSearchU.JoinDestPartsNo;
                    // DEL 2009/04/09 ------>>>
                    //addGoodsUnitData.GoodsMakerCd = workTBOSearchU.JoinDestMakerCd;
                    //addGoodsUnitData.BLGoodsCode = workTBOSearchU.BLGoodsCode;
                    // DEL 2009/04/09 ------<<<
                    addGoodsUnitData.StockList = new List<Stock>();
                    goodsUnitDataList.Add(addGoodsUnitData);
                }
            }
        }
        // 2009.03.30 30413 ���� ���i�}�X�^�_���폜���̑Ή� <<<<<<END

        // ----- ADD ���N 2013/05/02 Redmine#35434 ----->>>>>
        /// <summary>
        /// �S�̏����l�ݒ���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S�̏����l�ݒ���擾����</br>
        /// <br>Programmer : ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>           : Redmine#35434�̑Ή�</br>
        /// </remarks>
        private void GetDtlCalcStckCntDsp()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
            AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
            ArrayList retAllDefSetList;
            status = allDefSetAcs.Search(out retAllDefSetList, this._enterpriseCode, allDefSetSearchMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���O�C���S���҂̏������_�������͑S�Аݒ���擾
                this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retAllDefSetList);
            }
            else
            {
                this._allDefSet = null;
            }
        }

        /// <summary>
        /// �S�̏����l�ݒ�}�X�^�̃��X�g������A�w�肵�����_�Ŏg�p����ݒ���擾���܂��B(���_�R�[�h��������ΑS�Аݒ�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="allDefSetArrayList">�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g���X�g</param>
        /// <returns>�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>           : Redmine#35434�̑Ή�</br>
        /// </remarks>
        private AllDefSet GetAllDefSetFromList(string sectionCode, ArrayList allDefSetArrayList)
        {
            AllDefSet allSecAllDefSet = null;

            foreach (AllDefSet allDefSet in allDefSetArrayList)
            {
                if (allDefSet.SectionCode.Trim() == sectionCode.Trim())
                {
                    return allDefSet;
                }
                else if (allDefSet.SectionCode.Trim() == "00")
                {
                    allSecAllDefSet = allDefSet;
                }
            }

            return allSecAllDefSet;
        }
        // ----- ADD ���N 2013/05/02 Redmine#35434 -----<<<<<

    }
}