//**********************************************************************//
// �V�X�e��         �FPM.NS
// �v���O��������   �FPCC���Аݒ�}�X�^�����e
// �v���O�����T�v   �FPCC���Аݒ�}�X�^�o�^�E�C���E�폜���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2011 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.08.04  �C�����e : �V�K�쐬       
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/06/28  �C�����e : SCM��Q��10292�Ή� �w�b�_�^�C�g�����̕ύX       
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/02/12  �C�����e : SCM��Q��10342,10343�Ή�        
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/02/17  �C�����e : 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή�       
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/09/13  �C�����e : SCM�d�|�ꗗ��10571�Ή� �Q�Ƒq�ɃR�[�h�ǉ�      
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  11070147-00 �쐬�S�� : ���N�n��
// �� �� ��  2014/07/23  �C�����e : SCM�d�|�ꗗ��10659��1���݌ɐ��\���敪�̒ǉ�     
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30746 ���� ��
// �C �� ��  2014/09/04  �C�����e : SCM�d�|�ꗗ��10678�Ή��@�񓚔[���\���敪�ǉ�
//----------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30746 ���� ��
// �C �� ��  2014/10/22  �C�����e : �\���敪���⍇���������ʂŉ񓚔[���\���敪��ݒ肵�Ă��A�����̋敪���ݒ肳��Ȃ����̑Ή�
//----------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Infragistics.Win.Misc;
using System.Text.RegularExpressions;
using System.Collections.Generic;
// ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Infragistics.Win.UltraWinToolTip;// ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ�

// ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PCC���Аݒ�}�X�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC���Аݒ�}�X�^���s���܂��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.08.04 </br>
    /// </remarks>
    public partial class PMPCC09010UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {

        # region Constructor

        /// <summary>
        /// PCC���Аݒ�}�X�^�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        public PMPCC09010UA()
        {
            InitializeComponent();

            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            // USB�I�v�V�����`�F�b�N
            this._optionBLPPriWareHouse = GetBLPPriWareHouseOption();
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint                  = false;
            this._canClose                  = true;
            this._canNew                    = true;
            this._canDelete                 = true;
            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._dataIndex = -1;

            // ��ƃR�[�h���擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //���O�C���S���҂̋��_ 
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            // �ϐ�������
            this._pccCmpnyStAcs = new PccCmpnyStAcs();
            _customerInfoAcs = new CustomerInfoAcs();
            this._detailsTable = new Hashtable();
            //GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._detailsIndexBuf = -2;

        }

        # endregion

        #region IMasterMaintenanceMultiType �����o

        # region ��Properties
        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
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
        # endregion ��Properties

        # region ��Public Methods
        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note        : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add(DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            //�⍇������ƃR�[�h
            appearanceTable.Add(INQORIGINALEPCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //�⍇�������_�R�[�h
            appearanceTable.Add(INQORIGINALSECCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //�⍇�����ƃR�[�h
            appearanceTable.Add(INQOTHEREPCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //�⍇���拒�_�R�[�h
            appearanceTable.Add(INQOTHERSECCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC���ЃR�[�h
            appearanceTable.Add(PCCCOMPANYCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //PCC���Ж���
            appearanceTable.Add(PCCCOMPANYNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC�q�ɃR�[�h
            appearanceTable.Add(PCCWAREHOUSECD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //PCC�D��q�ɃR�[�h1
            appearanceTable.Add(PCCPRIWAREHOUSECD1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //PCC�D��q�ɃR�[�h2
            appearanceTable.Add(PCCPRIWAREHOUSECD2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //PCC�D��q�ɃR�[�h3
            appearanceTable.Add(PCCPRIWAREHOUSECD3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            if (this._optionBLPPriWareHouse)
            {
                //PCC�D��q�ɃR�[�h4
                appearanceTable.Add(PCCPRIWAREHOUSECD4_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            }
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            //�i�ԕ\���敪
            appearanceTable.Add(GOODSNODSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�W�����i�\���敪
            appearanceTable.Add(LISTPRCDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�d�؉��i�\���敪
            appearanceTable.Add(COSTDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�I�ԕ\���敪
            appearanceTable.Add(SHELFDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            //���݌ɐ��\���敪(�⍇��)
            appearanceTable.Add(PRSNTSTKCTDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            // �񓚔[���\���敪(�⍇��)
            appearanceTable.Add(ANSDELIDTDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
            //�R�����g�\���敪
            appearanceTable.Add(COMMENTDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�o�א��\���敪
            appearanceTable.Add(SPMTCNTDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�󒍐��\���敪
            //appearanceTable.Add(ACPTCNTDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            //���i�I��i�ԕ\���敪
            appearanceTable.Add(PRTSELGDNODSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //���i�I��W�����i�\���敪
            appearanceTable.Add(PRTSELLSPRDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //���i�I��I�ԕ\���敪
            appearanceTable.Add(PRTSELSELFDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
           //PCC�����於��1
            appearanceTable.Add(PCCSUPLNAME1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC�����於��2
            appearanceTable.Add(PCCSUPLNAME2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC������J�i����
            appearanceTable.Add(PCCSUPLKANA_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC�����旪��
            appearanceTable.Add(PCCSUPLSNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC������X�֔ԍ�
            appearanceTable.Add(PCCSUPLPOSTNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC������Z��1
            appearanceTable.Add(PCCSUPLADDR1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC������Z��2
            appearanceTable.Add(PCCSUPLADDR2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC������Z��3
            appearanceTable.Add(PCCSUPLADDR3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC������d�b�ԍ�1
            appearanceTable.Add(PCCSUPLTELNO1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC������d�b�ԍ�2
            appearanceTable.Add(PCCSUPLTELNO2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //PCC������FAX�ԍ�
            appearanceTable.Add(PCCSUPLFAXNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�`�[���s�敪�iPCC�j
            appearanceTable.Add(PCCSLIPPRTDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
          �@//�݌ɃR�����g1
            appearanceTable.Add(STCKSTCOMMENT1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�݌ɃR�����g2
            appearanceTable.Add(STCKSTCOMMENT2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�݌ɃR�����g3
            appearanceTable.Add(STCKSTCOMMENT3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�݌ɕ\���敪(�⍇��)
            //appearanceTable.Add(STOCKDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            ////���i�I���݌ɕ\���敪(�⍇��)
            //appearanceTable.Add(PRTSELSTCKDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�q�ɕ\���敪(�⍇��)
            appearanceTable.Add(WAREHOUSEDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //����\���敪(�⍇��)
            appearanceTable.Add(CANCELDSPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�i�ԕ\���敪(����)
            appearanceTable.Add(GOODSNODSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�W�����i�\���敪(����)
            appearanceTable.Add(LISTPRCDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�d�؉��i�\���敪(����)
            appearanceTable.Add(COSTDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�I�ԕ\���敪(����)
            appearanceTable.Add(SHELFDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            //���݌ɐ��\���敪(����)
            appearanceTable.Add(PRSNTSTKCTDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            // �񓚔[���\���敪(����)
            appearanceTable.Add(ANSDELIDTDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�݌ɕ\���敪(����)
            //appearanceTable.Add(STOCKDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�R�����g�\���敪(����)
            appearanceTable.Add(COMMENTDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�o�א��\���敪(����)
            appearanceTable.Add(SPMTCNTDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�󒍐��\���敪(����)
            //appearanceTable.Add(ACPTCNTDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //���i�I��i�ԕ\���敪(����)
            appearanceTable.Add(PRTSELGDNODSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //���i�I��W�����i�\���敪(����)
            appearanceTable.Add(PRTSELLSPRDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //���i�I��I�ԕ\���敪(����)
            appearanceTable.Add(PRTSELSELFDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////���i�I���݌ɕ\���敪(����)
            //appearanceTable.Add(PRTSELSTCKDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�q�ɕ\���敪(����)
            appearanceTable.Add(WAREHOUSEDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //����\���敪(����)
            appearanceTable.Add(CANCELDSPDIVOD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�⍇�������\���敪�ݒ�
            appearanceTable.Add(INQODRDSPDIVSET_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<

            appearanceTable.Add(DETAILS_GUID_KEY, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note		: �t���[�����̃O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = DETAILS_TABLE;
        }
        # endregion ��Public Methods

        # region ��Events
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        #endregion

        #region Private Menbers
        
        private string _enterpriseCode;         // ��ƃR�[�h
        private string _loginSectionCode;
        private Hashtable _detailsTable;        // ���Аݒ�}�X�^�p�n�b�V���e�[�u��
        private PccCmpnyStAcs _pccCmpnyStAcs = null;
        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canSpecificationSearch;
        private bool _defaultAutoFillToColumn;

        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
            
        //_GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        private int _detailsIndexBuf;
        //�⍇������ƃR�[�h
        private string _inqOriginalEpCd = string.Empty;
        //�⍇�������_�R�[�h
        private string _inqOriginalSecCd = string.Empty;
        //�O�⍇������ƃR�[�h
        private string _inqOriginalEpCdPre = string.Empty;
        //�O�⍇�������_�R�[�h
        private string _inqOriginalSecCdPre = string.Empty;
        private CustomerInfoAcs _customerInfoAcs;
        private PMPCC09010UB _pMPCC09010UB;
        /// <summary>
        /// �O���Ӑ�R�[�h
        /// </summary>
        private int _customerCodePre = -1;
        /// <summary>
        /// �O���Ӑ於��
        /// </summary>
        private string _customerNamePre = string.Empty;

        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
        // USB�I�v�V���� BLP�Q�Ƒq�ɒǉ��I�v�V����
        private bool _optionBLPPriWareHouse = false;
        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<

        #endregion

        #region  Private const
        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // �I�����̕ҏW�`�F�b�N�p
        private PccCmpnySt _pccCmpnySt;

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string DELETE_DATE_TITLE = "�폜��";
        private const string INQORIGINALEPCD_TITLE = "�⍇������ƃR�[�h";
        private const string INQORIGINALSECCD_TITLE = "�⍇�������_�R�[�h";
        private const string INQOTHEREPCD_TITLE = "�⍇�����ƃR�[�h";
        private const string INQOTHERSECCD_TITLE = "�⍇���拒�_�R�[�h";
        //DEL SATART BY wujun FOR Redmine#25173 ON 2011.09.15 
        //private const string PCCCOMPANYCODE_TITLE = "PCC���ЃR�[�h";
        //private const string PCCCOMPANYNAME_TITLE = "PCC���Ж���";
        //private const string PCCWAREHOUSECD_TITLE = "PCC�q�ɃR�[�h";
        //private const string PCCPRIWAREHOUSECD1_TITLE = "PCC�D��q�ɃR�[�h1";
        //private const string PCCPRIWAREHOUSECD2_TITLE = "PCC�D��q�ɃR�[�h2";
        //private const string PCCPRIWAREHOUSECD3_TITLE = "PCC�D��q�ɃR�[�h3";
        //DEL END BY wujun FOR Redmine#25173 ON 2011.09.15
        //ADD START BY wujun FOR Redmine#25173 ON 2011.09.15
        private const string PCCCOMPANYCODE_TITLE = "���ЃR�[�h";
        private const string PCCCOMPANYNAME_TITLE = "���Ж���";
        // UPD 2012/06/28 ���� No.10292 -------------------------------------------->>>>>
        //private const string PCCWAREHOUSECD_TITLE = "�q�ɃR�[�h";
        //private const string PCCPRIWAREHOUSECD1_TITLE = "�D��q�ɃR�[�h1";
        //private const string PCCPRIWAREHOUSECD2_TITLE = "�D��q�ɃR�[�h2";
        //private const string PCCPRIWAREHOUSECD3_TITLE = "�D��q�ɃR�[�h3";
        private const string PCCWAREHOUSECD_TITLE = "�ϑ��q�ɃR�[�h";
        private const string PCCPRIWAREHOUSECD1_TITLE = "�Q�Ƒq�ɃR�[�h1";
        private const string PCCPRIWAREHOUSECD2_TITLE = "�Q�Ƒq�ɃR�[�h2";
        private const string PCCPRIWAREHOUSECD3_TITLE = "�Q�Ƒq�ɃR�[�h3";
        // UPD 2012/06/28 ���� No.10292 --------------------------------------------<<<<<
        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
        private const string PCCPRIWAREHOUSECD4_TITLE = "�Q�Ƒq�ɃR�[�h4";
        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
        //ADD END BY wujun FOR Redmine#25173 ON 2011.09.15
        // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
        //private const string GOODSNODSPDIV_TITLE = "�i�ԕ\���敪";
        //private const string LISTPRCDSPDIV_TITLE = "�W�����i�\���敪";
        //private const string COSTDSPDIV_TITLE = "�d�؉��i�\���敪";
        //private const string SHELFDSPDIV_TITLE = "�I�ԕ\���敪";
        //private const string COMMENTDSPDIV_TITLE = "�R�����g�\���敪";
        //private const string SPMTCNTDSPDIV_TITLE = "�o�א��\���敪";
        //private const string ACPTCNTDSPDIV_TITLE = "�󒍐��\���敪";
        //private const string PRTSELGDNODSPDIV_TITLE = "���i�I��i�ԕ\���敪";
        //private const string PRTSELLSPRDSPDIV_TITLE = "���i�I��W�����i�\���敪";
        //private const string PRTSELSELFDSPDIV_TITLE = "���i�I��I�ԕ\���敪";
        // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
        //private const string GOODSNODSPDIV_TITLE = "�i�ԕ\���敪(�⍇��)";
        //private const string LISTPRCDSPDIV_TITLE = "�W�����i�\���敪(�⍇��)";
        //private const string COSTDSPDIV_TITLE = "�d�؉��i�\���敪(�⍇��)";
        //private const string SHELFDSPDIV_TITLE = "�I�ԕ\���敪(�⍇��)";
        //private const string STOCKDSPDIV_TITLE = "�݌ɕ\���敪(�⍇��)";
        //private const string COMMENTDSPDIV_TITLE = "�R�����g�\���敪(�⍇��)";
        //private const string SPMTCNTDSPDIV_TITLE = "�o�א��\���敪(�⍇��)";
        //private const string ACPTCNTDSPDIV_TITLE = "�󒍐��\���敪(�⍇��)";
        //private const string PRTSELGDNODSPDIV_TITLE = "���i�I��i�ԕ\���敪(�⍇��)";
        //private const string PRTSELLSPRDSPDIV_TITLE = "���i�I��W�����i�\���敪(�⍇��)";
        //private const string PRTSELSELFDSPDIV_TITLE = "���i�I��I�ԕ\���敪(�⍇��)";
        //private const string PRTSELSTCKDSPDIV_TITLE = "���i�I���݌ɕ\���敪(�⍇��)";
        //private const string WAREHOUSEDSPDIV_TITLE = "�q�ɕ\���敪(�⍇��)";
        //private const string CANCELDSPDIV_TITLE = "����\���敪(�⍇��)";
        //private const string GOODSNODSPDIVOD_TITLE = "�i�ԕ\���敪(����)";
        //private const string LISTPRCDSPDIVOD_TITLE = "�W�����i�\���敪(����)";
        //private const string COSTDSPDIVOD_TITLE = "�d�؉��i�\���敪(����)";
        //private const string SHELFDSPDIVOD_TITLE = "�I�ԕ\���敪(����)";
        //private const string STOCKDSPDIVOD_TITLE = "�݌ɕ\���敪(����)";
        //private const string COMMENTDSPDIVOD_TITLE = "�R�����g�\���敪(����)";
        //private const string SPMTCNTDSPDIVOD_TITLE = "�o�א��\���敪(����)";
        //private const string ACPTCNTDSPDIVOD_TITLE = "�󒍐��\���敪(����)";
        //private const string PRTSELGDNODSPDIVOD_TITLE = "���i�I��i�ԕ\���敪(����)";
        //private const string PRTSELLSPRDSPDIVOD_TITLE = "���i�I��W�����i�\���敪(����)";
        //private const string PRTSELSELFDSPDIVOD_TITLE = "���i�I��I�ԕ\���敪(����)";
        //private const string PRTSELSTCKDSPDIVOD_TITLE = "���i�I���݌ɕ\���敪(����)";
        //private const string WAREHOUSEDSPDIVOD_TITLE = "�q�ɕ\���敪(����)";
        //private const string CANCELDSPDIVOD_TITLE = "����\���敪(����)";
        //private const string INQODRDSPDIVSET_TITLE = "�⍇�������\���敪�ݒ�";
        private const string GOODSNODSPDIV_TITLE = "�i�ԕ\���敪(�⍇��)";
        private const string LISTPRCDSPDIV_TITLE = "�W�����i�\���敪(�⍇��)";
        private const string COSTDSPDIV_TITLE = "�d�؉��i�\���敪(�⍇��)";
        private const string SHELFDSPDIV_TITLE = "�I�ԕ\���敪(�⍇��)";
        private const string PRSNTSTKCTDSPDIV_TITLE = "���݌ɐ��\���敪(�⍇��)";// ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ�
        private const string COMMENTDSPDIV_TITLE = "�R�����g�\���敪(�⍇��)";
        private const string SPMTCNTDSPDIV_TITLE = "�o�א��\���敪(�⍇��)";
        private const string PRTSELGDNODSPDIV_TITLE = "���i�I��i�ԕ\���敪(�⍇��)";
        private const string PRTSELLSPRDSPDIV_TITLE = "���i�I��W�����i�\���敪(�⍇��)";
        private const string PRTSELSELFDSPDIV_TITLE = "���i�I��I�ԕ\���敪(�⍇��)";
        private const string WAREHOUSEDSPDIV_TITLE = "�q�ɕ\���敪(�⍇��)";
        private const string CANCELDSPDIV_TITLE = "����\���敪(�⍇��)";
        private const string GOODSNODSPDIVOD_TITLE = "�i�ԕ\���敪(����)";
        private const string LISTPRCDSPDIVOD_TITLE = "�W�����i�\���敪(����)";
        private const string COSTDSPDIVOD_TITLE = "�d�؉��i�\���敪(����)";
        private const string SHELFDSPDIVOD_TITLE = "�I�ԕ\���敪(����)";
        private const string PRSNTSTKCTDSPDIVOD_TITLE = "���݌ɐ��\���敪(����)";// ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ�
        private const string COMMENTDSPDIVOD_TITLE = "�R�����g�\���敪(����)";
        private const string SPMTCNTDSPDIVOD_TITLE = "�o�א��\���敪(����)";
        private const string PRTSELGDNODSPDIVOD_TITLE = "���i�I��i�ԕ\���敪(����)";
        private const string PRTSELLSPRDSPDIVOD_TITLE = "���i�I��W�����i�\���敪(����)";
        private const string PRTSELSELFDSPDIVOD_TITLE = "���i�I��I�ԕ\���敪(����)";
        private const string WAREHOUSEDSPDIVOD_TITLE = "�q�ɕ\���敪(����)";
        private const string CANCELDSPDIVOD_TITLE = "����\���敪(����)";
        private const string INQODRDSPDIVSET_TITLE = "�⍇�������\���敪�ݒ�";
        // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
        // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
        //DEL SATART BY wujun FOR Redmine#25173 ON 2011.09.15 
        //private const string PCCSUPLNAME1_TITLE = "PCC�����於��1";
        //private const string PCCSUPLNAME2_TITLE = "PCC�����於��2";
        //private const string PCCSUPLKANA_TITLE = "PCC������J�i����";
        //private const string PCCSUPLSNM_TITLE = "PCC�����旪��";
        //private const string PCCSUPLPOSTNO_TITLE = "PCC������X�֔ԍ�";
        //private const string PCCSUPLADDR1_TITLE = "PCC������Z��1";
        //private const string PCCSUPLADDR2_TITLE = "PCC������Z��2";
        //private const string PCCSUPLADDR3_TITLE = "PCC������Z��3";
        //private const string PCCSUPLTELNO1_TITLE = "PCC������d�b�ԍ�1";
        //private const string PCCSUPLTELNO2_TITLE = "PCC������d�b�ԍ�2";
        //private const string PCCSUPLFAXNO_TITLE = "PCC������FAX�ԍ�";
        //private const string PCCSLIPPRTDIV_TITLE = "�`�[���s�敪�iPCC�j";
        //private const string STCKSTCOMMENT1_TITLE = "�݌ɃR�����g1";
        //private const string STCKSTCOMMENT2_TITLE = "�݌ɃR�����g2";
        //private const string STCKSTCOMMENT3_TITLE = "�݌ɃR�����g3";
        //DEL END BY wujun FOR Redmine#25173 ON 2011.09.15
        //ADD START BY wujun FOR Redmine#25173 ON 2011.09.15
        private const string PCCSUPLNAME1_TITLE = "�����於��1";
        private const string PCCSUPLNAME2_TITLE = "�����於��2";
        private const string PCCSUPLKANA_TITLE = "������J�i����";
        private const string PCCSUPLSNM_TITLE = "�����旪��";
        private const string PCCSUPLPOSTNO_TITLE = "������X�֔ԍ�";
        private const string PCCSUPLADDR1_TITLE = "������Z��1";
        private const string PCCSUPLADDR2_TITLE = "������Z��2";
        private const string PCCSUPLADDR3_TITLE = "������Z��3";
        private const string PCCSUPLTELNO1_TITLE = "������d�b�ԍ�1";
        private const string PCCSUPLTELNO2_TITLE = "������d�b�ԍ�2";
        private const string PCCSUPLFAXNO_TITLE = "������FAX�ԍ�";
        private const string PCCSLIPPRTDIV_TITLE = "�����[�g�`���敪";
        private const string STCKSTCOMMENT1_TITLE = "�݌ɗL��";
        private const string STCKSTCOMMENT2_TITLE = "�݌ɖ���";
        private const string STCKSTCOMMENT3_TITLE = "�݌ɕs��";
        //ADD END BY wujun FOR Redmine#25173 ON 2011.09.15
        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
        private const string ANSDELIDTDSPDIV_TITLE = "�񓚔[���\���敪(�⍇��)";
        private const string ANSDELIDTDSPDIVOD_TITLE = "�񓚔[���\���敪(����)";

        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

        //PCC�I�����C����ʋ敪
        private const int ONLINEKINDDIV = 10;
        
        // �e�[�u������
        private const string DETAILS_TABLE = "PccCmpnyStRF";  

        // �K�C�h�L�[
        private const string DETAILS_GUID_KEY = "FileHeaderGuid";

        // Message�֘A��`
        private const string ASSEMBLY_ID = "PMPCC09010U";
        //private const string PROGRAM_NAME = "PCC���Аݒ�";�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15
        private const string PROGRAM_NAME = "BL�߰µ��ް���Аݒ�";�@//ADD BY wujun FOR Redmine#25173 ON 2011.09.15�@
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";
        private const string ERR_TIMEOUT_MSG = "�폜���Ƀ^�C���A�E�g���������܂����B\r\n���΂炭���Ԃ�u���čēx�X�V���Ă��������B";
        private const string CUSTOMEMPTY_BASE = "�x�[�X�ݒ�";
        #endregion

        // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
        // �⍇�������\���敪
        private const int INQODRCOMMON = 0; // �⍇����������
        private const int INQODRINDIVIDUAL = 1; // �⍇��������
        // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<

        # region Properties

        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
        public bool CanClose
        {
            get { return this._canClose; }
            set { this._canClose = value; }
        }

        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get { return this._canNew; }
        }

        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get { return this._canDelete; }
        }

        # endregion

        # region Public Methods

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S�f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            totalCount = 0;

            try
            {
                // �N���A
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();
                this._detailsTable.Clear();

                List<PccCmpnySt> retList = null;
                PccCmpnySt parsePccCmpnySt = new PccCmpnySt();
                parsePccCmpnySt.InqOtherEpCd = this._enterpriseCode;
                parsePccCmpnySt.InqOtherSecCd = this._loginSectionCode;
                status = this._pccCmpnyStAcs.Search(out retList, parsePccCmpnySt, 0, ConstantManagement.LogicalMode.GetData01);
                if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    
                    return status;
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        int index = 0;
                        foreach (PccCmpnySt pccCmpnySt in retList)
                        {
                            if (pccCmpnySt.LogicalDeleteCode > 1)
                            {
                                continue;
                            }
                            string guid = pccCmpnySt.InqOriginalEpCd.Trim() + pccCmpnySt.InqOriginalSecCd.TrimEnd() + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();//@@@@20230303
                            if (this._detailsTable.ContainsKey(guid) == false)
                            {
                                DetailsToDataSet(pccCmpnySt.Clone(), index);
                                ++index;
                            }
                        }
                        totalCount = retList.Count;
                        break;
                    case ( int )ConstantManagement.DB_Status.ctDB_EOF:
					    break;
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
                                this._pccCmpnyStAcs,					  // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,				  // �\������{�^��
                                MessageBoxDefaultButton.Button1);	  // �����\���{�^��
                            break;
                        }
				    default:
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                        PROGRAM_NAME, 			            // �v���O��������
                        "Search", 					        // ��������
						TMsgDisp.OPE_GET, 					// �I�y���[�V����
                        ERR_READ_MSG, 		                // �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
                        this._pccCmpnyStAcs, 		        // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��

					break;
                }
            }
            catch (Exception)
            {
                // �T�[�`
                TMsgDisp.Show(
                    this,								  // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                    ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                    this.Text,							  // �v���O��������
                    "Search",							  // ��������
                    TMsgDisp.OPE_GET,					  // �I�y���[�V����
                    ERR_READ_MSG,						  // �\�����郁�b�Z�[�W 
                    status,								  // �X�e�[�^�X�l
                    this._pccCmpnyStAcs,		          // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK,				  // �\������{�^��
                    MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                return status;
            }

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
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // �����Ȃ�
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        public int Delete()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            status = LogicalDeletePccCmpnySt();
            Initial_Timer.Enabled = true;
            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        public int Print()
        {
            // ����@�\�����̈ז�����
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        # endregion

        # region Private Methods

        /// <summary>
        /// PCC���Аݒ�}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="commColumn">PCC���Аݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : PCC���Аݒ�}�X�^�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void DetailsToDataSet(PccCmpnySt pccCmpnySt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[DETAILS_TABLE].NewRow();
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count - 1;
            }

            // �_���폜�敪
            if (pccCmpnySt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = pccCmpnySt.UpdateDateTimeJpInFormal;
            }

            //�⍇������ƃR�[�h
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][INQORIGINALEPCD_TITLE] = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
            //�⍇�������_�R�[�h
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][INQORIGINALSECCD_TITLE] = pccCmpnySt.InqOriginalSecCd;
            //�⍇�����ƃR�[�h
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][INQOTHEREPCD_TITLE] = pccCmpnySt.InqOtherEpCd;
            //�⍇���拒�_�R�[�h
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][INQOTHERSECCD_TITLE] = pccCmpnySt.InqOtherSecCd;
            //PCC���ЃR�[�h
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCCOMPANYCODE_TITLE] = pccCmpnySt.PccCompanyCode;
            //PCCCOMPANYNAME_TITLE
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCCOMPANYNAME_TITLE] = pccCmpnySt.PccCompanyName;
            //PCC�q�ɃR�[�h
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCWAREHOUSECD_TITLE] = pccCmpnySt.PccWarehouseCd;
            //PCC�D��q�ɃR�[�h1
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCPRIWAREHOUSECD1_TITLE] = pccCmpnySt.PccPriWarehouseCd1;
            //PCC�D��q�ɃR�[�h2
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCPRIWAREHOUSECD2_TITLE] = pccCmpnySt.PccPriWarehouseCd2;
            //PCC�D��q�ɃR�[�h3
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCPRIWAREHOUSECD3_TITLE] = pccCmpnySt.PccPriWarehouseCd3;
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            if (this._optionBLPPriWareHouse)
            {
                //PCC�D��q�ɃR�[�h4
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCPRIWAREHOUSECD4_TITLE] = pccCmpnySt.PccPriWarehouseCd4;
            }
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            //�i�ԕ\���敪
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][GOODSNODSPDIV_TITLE] = pccCmpnySt.GoodsNoDspDivName;
            //�W�����i�\���敪
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][LISTPRCDSPDIV_TITLE] = pccCmpnySt.ListPrcDspDivName;
            //�d�؉��i�\���敪
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][COSTDSPDIV_TITLE] = pccCmpnySt.CostDspDivName;
            //�I�ԕ\���敪
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SHELFDSPDIV_TITLE] = pccCmpnySt.ShelfDspDivName;
            //�R�����g�\���敪
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][COMMENTDSPDIV_TITLE] = pccCmpnySt.CommentDspDivName;
            //�o�א��\���敪
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SPMTCNTDSPDIV_TITLE] = pccCmpnySt.SpmtCntDspDivName;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�󒍐��\���敪
            //this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][ACPTCNTDSPDIV_TITLE] = pccCmpnySt.AcptCntDspDivName;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //���i�I��i�ԕ\���敪
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRTSELGDNODSPDIV_TITLE] = pccCmpnySt.PrtSelGdNoDspDivName;
            //���i�I��W�����i�\���敪
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRTSELLSPRDSPDIV_TITLE] = pccCmpnySt.PrtSelLsPrDspDivName;
            //���i�I��I�ԕ\���敪
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRTSELSELFDSPDIV_TITLE] = pccCmpnySt.PrtSelSelfDspDivName;
            //PCC�����於��1
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLNAME1_TITLE] = pccCmpnySt.PccSuplName1;
            //PCC�����於��2
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLNAME2_TITLE] = pccCmpnySt.PccSuplName2;
            //PCC������J�i����
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLKANA_TITLE] = pccCmpnySt.PccSuplKana;
            //PCC�����旪��
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLSNM_TITLE] = pccCmpnySt.PccSuplSnm;
            //PCC������X�֔ԍ�
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLPOSTNO_TITLE] = pccCmpnySt.PccSuplPostNo;
            //PCC������Z��1
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLADDR1_TITLE] = pccCmpnySt.PccSuplAddr1;
            //PCC������Z��2
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLADDR2_TITLE] = pccCmpnySt.PccSuplAddr2;
            //PCC������Z��3
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLADDR3_TITLE] = pccCmpnySt.PccSuplAddr3;
            //PCC������d�b�ԍ�1
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLTELNO1_TITLE] = pccCmpnySt.PccSuplTelNo1;
            //PCC������d�b�ԍ�2
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLTELNO2_TITLE] = pccCmpnySt.PccSuplTelNo2;
            //PCC������FAX�ԍ�
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSUPLFAXNO_TITLE] = pccCmpnySt.PccSuplFaxNo;
            //�`�[���s�敪�iPCC�j
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PCCSLIPPRTDIV_TITLE] = pccCmpnySt.PccSlipPrtDivName;
            //�݌ɃR�����g1
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][STCKSTCOMMENT1_TITLE] = pccCmpnySt.StckStComment1;
            //�݌ɃR�����g2
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][STCKSTCOMMENT2_TITLE] = pccCmpnySt.StckStComment2;
            //�݌ɃR�����g3
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][STCKSTCOMMENT3_TITLE] = pccCmpnySt.StckStComment3;

            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�݌ɕ\���敪(�⍇��)
            //this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][STOCKDSPDIV_TITLE] = pccCmpnySt.StockDspDivName;
            ////���i�I���݌ɕ\���敪(�⍇��)
            //this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRTSELSTCKDSPDIV_TITLE] = pccCmpnySt.PrtSelStckDspDivName;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�q�ɕ\���敪(�⍇��)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSEDSPDIV_TITLE] = pccCmpnySt.WarehouseDspDivName;
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            //���݌ɐ��\���敪(�⍇��)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRSNTSTKCTDSPDIV_TITLE] = pccCmpnySt.PrsntStkCtDspDivName;
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            // �񓚔[���\���敪(�⍇��)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][ANSDELIDTDSPDIV_TITLE] = pccCmpnySt.AnsDeliDtDspDivName;
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
            //����\���敪(�⍇��)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CANCELDSPDIV_TITLE] = pccCmpnySt.CancelDspDivName;
            //�i�ԕ\���敪(����)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][GOODSNODSPDIVOD_TITLE] = pccCmpnySt.GoodsNoDspDivOdName;
            //�W�����i�\���敪(����)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][LISTPRCDSPDIVOD_TITLE] = pccCmpnySt.ListPrcDspDivOdName;
            //�d�؉��i�\���敪(����)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][COSTDSPDIVOD_TITLE] = pccCmpnySt.CostDspDivOdName;
            //�I�ԕ\���敪(����)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SHELFDSPDIVOD_TITLE] = pccCmpnySt.ShelfDspDivOdName;
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            //���݌ɐ��\���敪(����)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRSNTSTKCTDSPDIVOD_TITLE] = pccCmpnySt.PrsntStkCtDspDivOdName;
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            // �񓚔[���\���敪(����)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][ANSDELIDTDSPDIVOD_TITLE] = pccCmpnySt.AnsDeliDtDspDivOdName;
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�݌ɕ\���敪(����)
            //this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][STOCKDSPDIVOD_TITLE] = pccCmpnySt.StockDspDivOdName;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�R�����g�\���敪(����)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][COMMENTDSPDIVOD_TITLE] = pccCmpnySt.CommentDspDivOdName;
            //�o�א��\���敪(����)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SPMTCNTDSPDIVOD_TITLE] = pccCmpnySt.SpmtCntDspDivOdName;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�󒍐��\���敪(����)
            //this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][ACPTCNTDSPDIVOD_TITLE] = pccCmpnySt.AcptCntDspDivOdName;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //���i�I��i�ԕ\���敪(����)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRTSELGDNODSPDIVOD_TITLE] = pccCmpnySt.PrtSelGdNoDspDivOdName;
            //���i�I��W�����i�\���敪(����)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRTSELLSPRDSPDIVOD_TITLE] = pccCmpnySt.PrtSelLsPrDspDivOdName;
            //���i�I��I�ԕ\���敪(����)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRTSELSELFDSPDIVOD_TITLE] = pccCmpnySt.PrtSelSelfDspDivOdName;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////���i�I���݌ɕ\���敪(����)
            //this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][PRTSELSTCKDSPDIVOD_TITLE] = pccCmpnySt.PrtSelStckDspDivOdName;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�q�ɕ\���敪(����)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSEDSPDIVOD_TITLE] = pccCmpnySt.WarehouseDspDivOdName;
            //����\���敪(����)
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CANCELDSPDIVOD_TITLE] = pccCmpnySt.CancelDspDivOdName;
            //�⍇�������\���敪�ݒ�
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][INQODRDSPDIVSET_TITLE] = pccCmpnySt.InqOdrDspDivSetName;
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<

            // GUID
            string guid = pccCmpnySt.InqOriginalEpCd.Trim() + pccCmpnySt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DETAILS_GUID_KEY] = guid;

            // �n�b�V���e�[�u���X�V
            if (this._detailsTable.ContainsKey(guid) == true)
            {
                this._detailsTable.Remove(guid);
            }
            this._detailsTable.Add(guid, pccCmpnySt);
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�폜����
        /// </summary>
        /// <param name="commColumn">PCC���Аݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        private void DeleteFromDataSet(PccCmpnySt pccCmpnySt, int index)
        {
            // �f�[�^�Z�b�g����s�폜���܂�
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index].Delete();

            // �n�b�V���e�[�u������폜���܂�
            string guid = pccCmpnySt.InqOriginalEpCd.Trim() + //@@@@20230303
                pccCmpnySt.InqOriginalSecCd.TrimEnd() + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();

            if (this._detailsTable.ContainsKey(guid) == true)
            {
                this._detailsTable.Remove(guid);
            }
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //PCC���Аݒ�}�X�^
            DataTable detailsTable = new DataTable(DETAILS_TABLE); 
            detailsTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            //�⍇������ƃR�[�h
            detailsTable.Columns.Add(INQORIGINALEPCD_TITLE, typeof(string));
            //�⍇�������_�R�[�h
            detailsTable.Columns.Add(INQORIGINALSECCD_TITLE, typeof(string));
            //�⍇�����ƃR�[�h
            detailsTable.Columns.Add(INQOTHEREPCD_TITLE, typeof(string));
            //�⍇���拒�_�R�[�h
            detailsTable.Columns.Add(INQOTHERSECCD_TITLE, typeof(string));
            //PCC���ЃR�[�h
            detailsTable.Columns.Add(PCCCOMPANYCODE_TITLE, typeof(Int32));
            //PCC���Ж���
            detailsTable.Columns.Add(PCCCOMPANYNAME_TITLE, typeof(string));
            //PCC�q�ɃR�[�h
            detailsTable.Columns.Add(PCCWAREHOUSECD_TITLE, typeof(string));
            //PCC�D��q�ɃR�[�h1
            detailsTable.Columns.Add(PCCPRIWAREHOUSECD1_TITLE, typeof(string));
            //PCC�D��q�ɃR�[�h2
            detailsTable.Columns.Add(PCCPRIWAREHOUSECD2_TITLE, typeof(string));
            //PCC�D��q�ɃR�[�h3
            detailsTable.Columns.Add(PCCPRIWAREHOUSECD3_TITLE, typeof(string));
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            if (this._optionBLPPriWareHouse)
            {
                //PCC�D��q�ɃR�[�h4
                detailsTable.Columns.Add(PCCPRIWAREHOUSECD4_TITLE, typeof(string));
            }
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            //�i�ԕ\���敪
            detailsTable.Columns.Add(GOODSNODSPDIV_TITLE, typeof(string));
            //�W�����i�\���敪
            detailsTable.Columns.Add(LISTPRCDSPDIV_TITLE, typeof(string));
            //�d�؉��i�\���敪
            detailsTable.Columns.Add(COSTDSPDIV_TITLE, typeof(string));
            //�I�ԕ\���敪
            detailsTable.Columns.Add(SHELFDSPDIV_TITLE, typeof(string));
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            //���݌ɐ��\���敪(�⍇��)
            detailsTable.Columns.Add(PRSNTSTKCTDSPDIV_TITLE, typeof(string));
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            // �񓚔[���\���敪(�⍇��)
            detailsTable.Columns.Add(ANSDELIDTDSPDIV_TITLE, typeof(string));
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
            //�R�����g�\���敪
            detailsTable.Columns.Add(COMMENTDSPDIV_TITLE, typeof(string));
            //�o�א��\���敪
            detailsTable.Columns.Add(SPMTCNTDSPDIV_TITLE, typeof(string));
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�󒍐��\���敪
            //detailsTable.Columns.Add(ACPTCNTDSPDIV_TITLE, typeof(string));
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //���i�I��i�ԕ\���敪
            detailsTable.Columns.Add(PRTSELGDNODSPDIV_TITLE, typeof(string));
            //���i�I��W�����i�\���敪
            detailsTable.Columns.Add(PRTSELLSPRDSPDIV_TITLE, typeof(string));
            //���i�I��I�ԕ\���敪
            detailsTable.Columns.Add(PRTSELSELFDSPDIV_TITLE, typeof(string));
            //PCC�����於��1
            detailsTable.Columns.Add(PCCSUPLNAME1_TITLE, typeof(string));
            //PCC�����於��2
            detailsTable.Columns.Add(PCCSUPLNAME2_TITLE, typeof(string));
            //PCC������J�i����
            detailsTable.Columns.Add(PCCSUPLKANA_TITLE, typeof(string));
            //PCC�����旪��
            detailsTable.Columns.Add(PCCSUPLSNM_TITLE, typeof(string));
            //PCC������X�֔ԍ�
            detailsTable.Columns.Add(PCCSUPLPOSTNO_TITLE, typeof(string));
            //PCC������Z��1
            detailsTable.Columns.Add(PCCSUPLADDR1_TITLE, typeof(string));
            //PCC������Z��2
            detailsTable.Columns.Add(PCCSUPLADDR2_TITLE, typeof(string));
            //PCC������Z��3
            detailsTable.Columns.Add(PCCSUPLADDR3_TITLE, typeof(string));
            //PCC������d�b�ԍ�1
            detailsTable.Columns.Add(PCCSUPLTELNO1_TITLE, typeof(string));
            //PCC������d�b�ԍ�2
            detailsTable.Columns.Add(PCCSUPLTELNO2_TITLE, typeof(string));
            //PCC������FAX�ԍ�
            detailsTable.Columns.Add(PCCSUPLFAXNO_TITLE, typeof(string));
            //�`�[���s�敪�iPCC�j
            detailsTable.Columns.Add(PCCSLIPPRTDIV_TITLE, typeof(string));
            //�݌ɃR�����g1
            detailsTable.Columns.Add(STCKSTCOMMENT1_TITLE, typeof(string));
            //�݌ɃR�����g2
            detailsTable.Columns.Add(STCKSTCOMMENT2_TITLE, typeof(string));
            //�݌ɃR�����g3
            detailsTable.Columns.Add(STCKSTCOMMENT3_TITLE, typeof(string));

            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�݌ɕ\���敪(�⍇��)
            //detailsTable.Columns.Add(STOCKDSPDIV_TITLE, typeof(string));
            ////���i�I���݌ɕ\���敪(�⍇��)
            //detailsTable.Columns.Add(PRTSELSTCKDSPDIV_TITLE, typeof(string));
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�q�ɕ\���敪(�⍇��)
            detailsTable.Columns.Add(WAREHOUSEDSPDIV_TITLE, typeof(string));
            //����\���敪(�⍇��)
            detailsTable.Columns.Add(CANCELDSPDIV_TITLE, typeof(string));
            //�i�ԕ\���敪(����)
            detailsTable.Columns.Add(GOODSNODSPDIVOD_TITLE, typeof(string));
            //�W�����i�\���敪(����)
            detailsTable.Columns.Add(LISTPRCDSPDIVOD_TITLE, typeof(string));
            //�d�؉��i�\���敪(����)
            detailsTable.Columns.Add(COSTDSPDIVOD_TITLE, typeof(string));
            //�I�ԕ\���敪(����)
            detailsTable.Columns.Add(SHELFDSPDIVOD_TITLE, typeof(string));
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            //���݌ɐ��\���敪(����)
            detailsTable.Columns.Add(PRSNTSTKCTDSPDIVOD_TITLE, typeof(string));
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            // �񓚔[���\���敪(����)
            detailsTable.Columns.Add(ANSDELIDTDSPDIVOD_TITLE, typeof(string));
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�݌ɕ\���敪(����)
            //detailsTable.Columns.Add(STOCKDSPDIVOD_TITLE, typeof(string));
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�R�����g�\���敪(����)
            detailsTable.Columns.Add(COMMENTDSPDIVOD_TITLE, typeof(string));
            //�o�א��\���敪(����)
            detailsTable.Columns.Add(SPMTCNTDSPDIVOD_TITLE, typeof(string));
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�󒍐��\���敪(����)
            //detailsTable.Columns.Add(ACPTCNTDSPDIVOD_TITLE, typeof(string));
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //���i�I��i�ԕ\���敪(����)
            detailsTable.Columns.Add(PRTSELGDNODSPDIVOD_TITLE, typeof(string));
            //���i�I��W�����i�\���敪(����)
            detailsTable.Columns.Add(PRTSELLSPRDSPDIVOD_TITLE, typeof(string));
            //���i�I��I�ԕ\���敪(����)
            detailsTable.Columns.Add(PRTSELSELFDSPDIVOD_TITLE, typeof(string));
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////���i�I���݌ɕ\���敪(����)
            //detailsTable.Columns.Add(PRTSELSTCKDSPDIVOD_TITLE, typeof(string));
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�q�ɕ\���敪(����)
            detailsTable.Columns.Add(WAREHOUSEDSPDIVOD_TITLE, typeof(string));
            //����\���敪(����)
            detailsTable.Columns.Add(CANCELDSPDIVOD_TITLE, typeof(string));
            //�⍇�������\���敪�ݒ�
            detailsTable.Columns.Add(INQODRDSPDIVSET_TITLE, typeof(string));
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<

            detailsTable.Columns.Add(DETAILS_GUID_KEY, typeof(string));
            this.Bind_DataSet.Tables.Add(detailsTable);
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void ScreenClear()
        {
            // ���[�h���x��
            this.Mode_Label.Text = INSERT_MODE;
            this.ClearAll();
            // �{�^��
            this.Delete_Button.Visible  = true;  // ���S�폜�{�^��
            this.Revive_Button.Visible  = true;  // �����{�^��
            this.Ok_Button.Visible      = true;  // �ۑ��{�^��
            this.Cancel_Button.Visible = true;  // ����{�^��
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">���[�h(�V�K�E�X�V�E�폜)</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                // �V�K
                case INSERT_MODE:
                    //���Ӑ�R�[�h
                    this.tNedit_CustomerCode.Enabled = true;
                    //���Ӑ於��
                    this.uLabel_CustomerName.Enabled = true;
                    //PCC���ЃR�[�h
                    this.tNedit_PccCompanyCode.Enabled = false;
                    //PCC�q�ɃR�[�h
                    this.tNedit_PccWarehouseCd.Enabled = true;
                    //PCC�D��q�ɃR�[�h1
                    this.tNedit_PccPriWarehouseCd1.Enabled = true;
                    //PCC�D��q�ɃR�[�h2
                    this.tNedit_PccPriWarehouseCd2.Enabled = true;
                    //PCC�D��q�ɃR�[�h3
                    this.tNedit_PccPriWarehouseCd3.Enabled = true;
                    // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                    // �I�v�V�����`�F�b�N
                    if (this._optionBLPPriWareHouse)
                    {
                        //PCC�D��q�ɃR�[�h4
                        this.tNedit_PccPriWarehouseCd4.Enabled = true;
                    }
                    else
                    {
                        this.tNedit_PccPriWarehouseCd4.Enabled = false;
                        this.tNedit_PccPriWarehouseCd4.Visible = false;
                        this.ultraLabel27.Visible = false;
                    }
                    // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                    //�i�ԕ\���敪
                    this.tComboEditor_GoodsNoDspDiv.Enabled = true;
                    //�W�����i�\���敪
                    this.tComboEditor_ListPrcDspDiv.Enabled = true;
                    //�d�؉��i�\���敪
                    this.tComboEditor_CostDspDiv.Enabled = true;
                    //�I�ԕ\���敪
                    this.tComboEditor_ShelfDspDiv.Enabled = true;
                    //�R�����g�\���敪
                    this.tComboEditor_CommentDspDiv.Enabled = true;
                    //�o�א��\���敪
                    this.tComboEditor_SpmtCntDspDiv.Enabled = true;
                    // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                    ////�󒍐��\���敪
                    //this.tComboEditor_AcptCntDspDiv.Enabled = true;
                    // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                    //���i�I��i�ԕ\���敪
                    this.tComboEditor_PrtSelGdNoDspDiv.Enabled = true;
                    //���i�I��W�����i�\���敪
                    this.tComboEditor_PrtSelLsPrDspDiv.Enabled = true;
                    //���i�I��I�ԕ\���敪
                    this.tComboEditor_PrtSelSelfDspDiv.Enabled = true;
                    //�݌ɏ󋵃}�[�N1
                    this.tEdit_StckStComment1.Enabled = true;
                    //�݌ɏ󋵃}�[�N2
                    this.tEdit_StckStComment2.Enabled = true;
                    //�݌ɏ󋵃}�[�N3
                    this.tEdit_StckStComment3.Enabled = true;
                    //PCC�����於��1
                    this.tEdit_PccSuplName1.Enabled = true;
                    //PCC�����於��2
                    this.tEdit_PccSuplName2.Enabled = true;
                    //PCC������J�i����
                    this.tEdit_PccSuplKana.Enabled = true;
                    //PCC�����旪��
                    this.tEdit_PccSuplSnm.Enabled = true;
                    //PCC������X�֔ԍ�
                    this.tEdit_PccSuplPostNo.Enabled = true;
                    //PCC������Z��1
                    this.tEdit_PccSuplAddr1.Enabled = true;
                    //PCC������Z��2
                    this.tEdit_PccSuplAddr2.Enabled = true;
                    //PCC������Z��3
                    this.tEdit_PccSuplAddr3.Enabled = true;
                    //PCC������d�b�ԍ�1
                    this.tEdit_PccSuplTelNo1.Enabled = true;
                    //PCC������d�b�ԍ�2
                    this.tEdit_PccSuplTelNo2.Enabled = true;
                    //PCC������FAX�ԍ�
                    this.tEdit_PccSuplFaxNo.Enabled = true;
                    //�`�[���s�敪�iPCC�j
                    this.tComboEditor_PccSlipPrtDiv.Enabled = true;

                    // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
                    // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                    ////�݌ɕ\���敪(�⍇���j
                    //this.tComboEditor_StockDspDiv.Enabled = true;
                    ////���i�I���݌ɕ\���敪(�⍇��)
                    //this.tComboEditor_PrtSelStckDspDiv.Enabled = true;
                    // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                    //�q�ɕ\���敪(�⍇��)
                    this.tComboEditor_WarehouseDspDiv.Enabled = true;

                    // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                    // ���݌ɐ��\���敪(�⍇��)
                    this.tComboEditor_PrsntStkCtDspDiv.Enabled = true;
                    // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<

                    // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                    // �񓚔[���\���敪(�⍇��)
                    this.tComboEditor_AnsDeliDtDspDiv.Enabled = true;
                    // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

                    //����\���敪(�⍇��)
                    this.tComboEditor_CancelDspDiv.Enabled = true;
                    //�⍇�������\���敪�ݒ�
                    this.tComboEditor_InqOdrDspDivSet.Enabled = true;

                    //�⍇�������\���敪�����ʂ̎�
                    if (this.ValueToInt(this.tComboEditor_InqOdrDspDivSet.Value).Equals(INQODRCOMMON))
                    {
                        //���x����\��
                        this.ultraLabel1.Visible = false;
                        this.ultraLabel9.Visible = false;
                        this.ultraLabel10.Visible = false;
                        this.ultraLabel23.Visible = false;
                        //�i�ԕ\���敪(����)
                        this.tComboEditor_GoodsNoDspDivOd.Enabled = false;
                        this.tComboEditor_GoodsNoDspDivOd.Visible = false;
                        //�W�����i�\���敪(����)
                        this.tComboEditor_ListPrcDspDivOd.Enabled = false;
                        this.tComboEditor_ListPrcDspDivOd.Visible = false;
                        //�d�؉��i�\���敪(����)
                        this.tComboEditor_CostDspDivOd.Enabled = false;
                        this.tComboEditor_CostDspDivOd.Visible = false;
                        //�I�ԕ\���敪(����)
                        this.tComboEditor_ShelfDspDivOd.Enabled = false;
                        this.tComboEditor_ShelfDspDivOd.Visible = false;
                        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                        // ���݌ɐ��\���敪(����)
                        this.tComboEditor_PrsntStkCtDspDivOd.Enabled = false;
                        this.tComboEditor_PrsntStkCtDspDivOd.Visible = false;
                        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                        // �񓚔[���\���敪(����)
                        this.tComboEditor_AnsDeliDtDspDivOd.Enabled = false;
                        this.tComboEditor_AnsDeliDtDspDivOd.Visible = false;
                        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////�݌ɕ\���敪(����)
                        //this.tComboEditor_StockDspDivOd.Enabled = false;
                        //this.tComboEditor_StockDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //�R�����g�\���敪(����)
                        this.tComboEditor_CommentDspDivOd.Enabled = false;
                        this.tComboEditor_CommentDspDivOd.Visible = false;
                        //�o�א��\���敪(����)
                        this.tComboEditor_SpmtCntDspDivOd.Enabled = false;
                        this.tComboEditor_SpmtCntDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////�󒍐��\���敪(����)
                        //this.tComboEditor_AcptCntDspDivOd.Enabled = false;
                        //this.tComboEditor_AcptCntDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //���i�I��i�ԕ\���敪(����)
                        this.tComboEditor_PrtSelGdNoDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelGdNoDspDivOd.Visible = false;
                        //���i�I��W�����i�\���敪(����)
                        this.tComboEditor_PrtSelLsPrDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelLsPrDspDivOd.Visible = false;
                        //���i�I��I�ԕ\���敪(����)
                        this.tComboEditor_PrtSelSelfDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelSelfDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////���i�I���݌ɕ\���敪(����)
                        //this.tComboEditor_PrtSelStckDspDivOd.Enabled = false;
                        //this.tComboEditor_PrtSelStckDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //�q�ɕ\���敪(����)
                        this.tComboEditor_WarehouseDspDivOd.Enabled = false;
                        this.tComboEditor_WarehouseDspDivOd.Visible = false;
                        //����\���敪(����)
                        this.tComboEditor_CancelDspDivOd.Enabled = false;
                        this.tComboEditor_CancelDspDivOd.Visible = false;
                    }
                    //�⍇�������\���敪���ʂ̎�
                    else
                    {
                        //���x���\��
                        this.ultraLabel1.Visible = true;
                        this.ultraLabel9.Visible = true;
                        this.ultraLabel10.Visible = true;
                        this.ultraLabel23.Visible = true;
                        //�i�ԕ\���敪(����)
                        this.tComboEditor_GoodsNoDspDivOd.Enabled = true;
                        this.tComboEditor_GoodsNoDspDivOd.Visible = true;
                        //�W�����i�\���敪(����)
                        this.tComboEditor_ListPrcDspDivOd.Enabled = true;
                        this.tComboEditor_ListPrcDspDivOd.Visible = true;
                        //�d�؉��i�\���敪(����)
                        this.tComboEditor_CostDspDivOd.Enabled = true;
                        this.tComboEditor_CostDspDivOd.Visible = true;
                        //�I�ԕ\���敪(����)
                        this.tComboEditor_ShelfDspDivOd.Enabled = true;
                        this.tComboEditor_ShelfDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////�݌ɕ\���敪(����)
                        //this.tComboEditor_StockDspDivOd.Enabled = true;
                        //this.tComboEditor_StockDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //�R�����g�\���敪(����)
                        this.tComboEditor_CommentDspDivOd.Enabled = true;
                        this.tComboEditor_CommentDspDivOd.Visible = true;
                        //�o�א��\���敪(����)
                        this.tComboEditor_SpmtCntDspDivOd.Enabled = true;
                        this.tComboEditor_SpmtCntDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////�󒍐��\���敪(����)
                        //this.tComboEditor_AcptCntDspDivOd.Enabled = true;
                        //this.tComboEditor_AcptCntDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //���i�I��i�ԕ\���敪(����)
                        this.tComboEditor_PrtSelGdNoDspDivOd.Enabled = true;
                        this.tComboEditor_PrtSelGdNoDspDivOd.Visible = true;
                        //���i�I��W�����i�\���敪(����)
                        this.tComboEditor_PrtSelLsPrDspDivOd.Enabled = true;
                        this.tComboEditor_PrtSelLsPrDspDivOd.Visible = true;
                        //���i�I��I�ԕ\���敪(����)
                        this.tComboEditor_PrtSelSelfDspDivOd.Enabled = true;
                        this.tComboEditor_PrtSelSelfDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////���i�I���݌ɕ\���敪(����)
                        //this.tComboEditor_PrtSelStckDspDivOd.Enabled = true;
                        //this.tComboEditor_PrtSelStckDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //�q�ɕ\���敪(����)
                        this.tComboEditor_WarehouseDspDivOd.Enabled = true;
                        this.tComboEditor_WarehouseDspDivOd.Visible = true;
                        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                        // ���݌ɐ��\���敪(����)
                        this.tComboEditor_PrsntStkCtDspDivOd.Enabled = true;
                        this.tComboEditor_PrsntStkCtDspDivOd.Visible = true;
                        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<

                        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                        this.tComboEditor_AnsDeliDtDspDivOd.Enabled = true;
                        this.tComboEditor_AnsDeliDtDspDivOd.Visible = true;
                        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

                        //����\���敪(����)
                        this.tComboEditor_CancelDspDivOd.Enabled = true;
                        this.tComboEditor_CancelDspDivOd.Visible = true;
                    }
                    // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<

                    // �{�^��
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.UltraButton_Quote.Visible = true;
                    this.UButton_CustomerGuide.Enabled = true;
                    break;
                // �X�V
                case UPDATE_MODE:
                    //���Ӑ�R�[�h
                    this.tNedit_CustomerCode.Enabled = true;
                    //���Ӑ於��
                    this.uLabel_CustomerName.Enabled = true;
                    //PCC���ЃR�[�h
                    this.tNedit_PccCompanyCode.Enabled = false;
                    //PCC�q�ɃR�[�h
                    this.tNedit_PccWarehouseCd.Enabled = true;
                    //PCC�D��q�ɃR�[�h1
                    this.tNedit_PccPriWarehouseCd1.Enabled = true;
                    //PCC�D��q�ɃR�[�h2
                    this.tNedit_PccPriWarehouseCd2.Enabled = true;
                    //PCC�D��q�ɃR�[�h3
                    this.tNedit_PccPriWarehouseCd3.Enabled = true;
                    // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                    // �I�v�V�����`�F�b�N
                    if (this._optionBLPPriWareHouse)
                    {
                        //PCC�D��q�ɃR�[�h4
                        this.tNedit_PccPriWarehouseCd4.Enabled = true;
                    }
                    else
                    {
                        this.tNedit_PccPriWarehouseCd4.Enabled = false;
                        this.tNedit_PccPriWarehouseCd4.Visible = false;
                        this.ultraLabel27.Visible = false;
                    }
                    // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                    //�i�ԕ\���敪
                    this.tComboEditor_GoodsNoDspDiv.Enabled = true;
                    //�W�����i�\���敪
                    this.tComboEditor_ListPrcDspDiv.Enabled = true;
                    //�d�؉��i�\���敪
                    this.tComboEditor_CostDspDiv.Enabled = true;
                    //�I�ԕ\���敪
                    this.tComboEditor_ShelfDspDiv.Enabled = true;
                    //�R�����g�\���敪
                    this.tComboEditor_CommentDspDiv.Enabled = true;
                    //�o�א��\���敪
                    this.tComboEditor_SpmtCntDspDiv.Enabled = true;
                    // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                    ////�󒍐��\���敪
                    //this.tComboEditor_AcptCntDspDiv.Enabled = true;
                    // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                    //���i�I��i�ԕ\���敪
                    this.tComboEditor_PrtSelGdNoDspDiv.Enabled = true;
                    //���i�I��W�����i�\���敪
                    this.tComboEditor_PrtSelLsPrDspDiv.Enabled = true;
                    //���i�I��I�ԕ\���敪
                    this.tComboEditor_PrtSelSelfDspDiv.Enabled = true;
                    //�݌ɏ󋵃}�[�N1
                    this.tEdit_StckStComment1.Enabled = true;
                    //�݌ɏ󋵃}�[�N2
                    this.tEdit_StckStComment2.Enabled = true;
                    //�݌ɏ󋵃}�[�N3
                    this.tEdit_StckStComment3.Enabled = true;
                    //PCC�����於��1
                    this.tEdit_PccSuplName1.Enabled = true;
                    //PCC�����於��2
                    this.tEdit_PccSuplName2.Enabled = true;
                    //PCC������J�i����
                    this.tEdit_PccSuplKana.Enabled = true;
                    //PCC�����旪��
                    this.tEdit_PccSuplSnm.Enabled = true;
                    //PCC������X�֔ԍ�
                    this.tEdit_PccSuplPostNo.Enabled = true;
                    //PCC������Z��1
                    this.tEdit_PccSuplAddr1.Enabled = true;
                    //PCC������Z��2
                    this.tEdit_PccSuplAddr2.Enabled = true;
                    //PCC������Z��3
                    this.tEdit_PccSuplAddr3.Enabled = true;
                    //PCC������d�b�ԍ�1
                    this.tEdit_PccSuplTelNo1.Enabled = true;
                    //PCC������d�b�ԍ�2
                    this.tEdit_PccSuplTelNo2.Enabled = true;
                    //PCC������FAX�ԍ�
                    this.tEdit_PccSuplFaxNo.Enabled = true;
                    //�`�[���s�敪�iPCC�j
                    this.tComboEditor_PccSlipPrtDiv.Enabled = true;

                    // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
                    // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                    ////�݌ɕ\���敪(�⍇���j
                    //this.tComboEditor_StockDspDiv.Enabled = true;
                    ////���i�I���݌ɕ\���敪(�⍇��)
                    //this.tComboEditor_PrtSelStckDspDiv.Enabled = true;
                    // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                    //�q�ɕ\���敪(�⍇��)
                    this.tComboEditor_WarehouseDspDiv.Enabled = true;
                    // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                    // ���݌ɐ��\���敪(�⍇��)
                    this.tComboEditor_PrsntStkCtDspDiv.Enabled = true;
                    // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                    // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                    // �񓚔[���\���敪(�⍇��)
                    this.tComboEditor_AnsDeliDtDspDiv.Enabled = true;
                    // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
                    //����\���敪(�⍇��)
                    this.tComboEditor_CancelDspDiv.Enabled = true;
                    //�⍇�������\���敪�ݒ�
                    this.tComboEditor_InqOdrDspDivSet.Enabled = true;

                    //�⍇�������\���敪�����ʂ̎�
                    if (this.ValueToInt(this.tComboEditor_InqOdrDspDivSet.Value).Equals(INQODRCOMMON))
                    {
                        //���x����\��
                        this.ultraLabel1.Visible = false;
                        this.ultraLabel9.Visible = false;
                        this.ultraLabel10.Visible = false;
                        this.ultraLabel23.Visible = false;
                        //�i�ԕ\���敪(����)
                        this.tComboEditor_GoodsNoDspDivOd.Enabled = false;
                        this.tComboEditor_GoodsNoDspDivOd.Visible = false;
                        //�W�����i�\���敪(����)
                        this.tComboEditor_ListPrcDspDivOd.Enabled = false;
                        this.tComboEditor_ListPrcDspDivOd.Visible = false;
                        //�d�؉��i�\���敪(����)
                        this.tComboEditor_CostDspDivOd.Enabled = false;
                        this.tComboEditor_CostDspDivOd.Visible = false;
                        //�I�ԕ\���敪(����)
                        this.tComboEditor_ShelfDspDivOd.Enabled = false;
                        this.tComboEditor_ShelfDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////�݌ɕ\���敪(����)
                        //this.tComboEditor_StockDspDivOd.Enabled = false;
                        //this.tComboEditor_StockDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //�R�����g�\���敪(����)
                        this.tComboEditor_CommentDspDivOd.Enabled = false;
                        this.tComboEditor_CommentDspDivOd.Visible = false;
                        //�o�א��\���敪(����)
                        this.tComboEditor_SpmtCntDspDivOd.Enabled = false;
                        this.tComboEditor_SpmtCntDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////�󒍐��\���敪(����)
                        //this.tComboEditor_AcptCntDspDivOd.Enabled = false;
                        //this.tComboEditor_AcptCntDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //���i�I��i�ԕ\���敪(����)
                        this.tComboEditor_PrtSelGdNoDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelGdNoDspDivOd.Visible = false;
                        //���i�I��W�����i�\���敪(����)
                        this.tComboEditor_PrtSelLsPrDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelLsPrDspDivOd.Visible = false;
                        //���i�I��I�ԕ\���敪(����)
                        this.tComboEditor_PrtSelSelfDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelSelfDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////���i�I���݌ɕ\���敪(����)
                        //this.tComboEditor_PrtSelStckDspDivOd.Enabled = false;
                        //this.tComboEditor_PrtSelStckDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //�q�ɕ\���敪(����)
                        this.tComboEditor_WarehouseDspDivOd.Enabled = false;
                        this.tComboEditor_WarehouseDspDivOd.Visible = false;
                        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                        // ���݌ɐ��\���敪(����)
                        this.tComboEditor_PrsntStkCtDspDivOd.Enabled = false;
                        this.tComboEditor_PrsntStkCtDspDivOd.Visible = false;
                        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                        // �񓚔[���\���敪(����)
                        this.tComboEditor_AnsDeliDtDspDivOd.Enabled = false;
                        this.tComboEditor_AnsDeliDtDspDivOd.Visible = false;
                        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
                        //����\���敪(����)
                        this.tComboEditor_CancelDspDivOd.Enabled = false;
                        this.tComboEditor_CancelDspDivOd.Visible = false;
                    }
                    //�⍇�������\���敪���ʂ̎�
                    else
                    {
                        //���x���\��
                        this.ultraLabel1.Visible = true;
                        this.ultraLabel9.Visible = true;
                        this.ultraLabel10.Visible = true;
                        this.ultraLabel23.Visible = true;
                        //�i�ԕ\���敪(����)
                        this.tComboEditor_GoodsNoDspDivOd.Enabled = true;
                        this.tComboEditor_GoodsNoDspDivOd.Visible = true;
                        //�W�����i�\���敪(����)
                        this.tComboEditor_ListPrcDspDivOd.Enabled = true;
                        this.tComboEditor_ListPrcDspDivOd.Visible = true;
                        //�d�؉��i�\���敪(����)
                        this.tComboEditor_CostDspDivOd.Enabled = true;
                        this.tComboEditor_CostDspDivOd.Visible = true;
                        //�I�ԕ\���敪(����)
                        this.tComboEditor_ShelfDspDivOd.Enabled = true;
                        this.tComboEditor_ShelfDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////�݌ɕ\���敪(����)
                        //this.tComboEditor_StockDspDivOd.Enabled = true;
                        //this.tComboEditor_StockDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //�R�����g�\���敪(����)
                        this.tComboEditor_CommentDspDivOd.Enabled = true;
                        this.tComboEditor_CommentDspDivOd.Visible = true;
                        //�o�א��\���敪(����)
                        this.tComboEditor_SpmtCntDspDivOd.Enabled = true;
                        this.tComboEditor_SpmtCntDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////�󒍐��\���敪(����)
                        //this.tComboEditor_AcptCntDspDivOd.Enabled = true;
                        //this.tComboEditor_AcptCntDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //���i�I��i�ԕ\���敪(����)
                        this.tComboEditor_PrtSelGdNoDspDivOd.Enabled = true;
                        this.tComboEditor_PrtSelGdNoDspDivOd.Visible = true;
                        //���i�I��W�����i�\���敪(����)
                        this.tComboEditor_PrtSelLsPrDspDivOd.Enabled = true;
                        this.tComboEditor_PrtSelLsPrDspDivOd.Visible = true;
                        //���i�I��I�ԕ\���敪(����)
                        this.tComboEditor_PrtSelSelfDspDivOd.Enabled = true;
                        this.tComboEditor_PrtSelSelfDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////���i�I���݌ɕ\���敪(����)
                        //this.tComboEditor_PrtSelStckDspDivOd.Enabled = true;
                        //this.tComboEditor_PrtSelStckDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //�q�ɕ\���敪(����)
                        this.tComboEditor_WarehouseDspDivOd.Enabled = true;
                        this.tComboEditor_WarehouseDspDivOd.Visible = true;
                        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                        // ���݌ɐ��\���敪(����)
                        this.tComboEditor_PrsntStkCtDspDivOd.Enabled = true;
                        this.tComboEditor_PrsntStkCtDspDivOd.Visible = true;
                        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                        this.tComboEditor_AnsDeliDtDspDivOd.Enabled = true;
                        this.tComboEditor_AnsDeliDtDspDivOd.Visible = true;
                        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
                        //����\���敪(����)
                        this.tComboEditor_CancelDspDivOd.Enabled = true;
                        this.tComboEditor_CancelDspDivOd.Visible = true;
                    }
                    // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<

                    // �{�^��
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;
                    this.UltraButton_Quote.Visible = true;
                    this.UButton_CustomerGuide.Enabled = true;
                    break;
                // �폜
                case DELETE_MODE:
                    //���Ӑ�R�[�h
                    this.tNedit_CustomerCode.Enabled = false;
                    //���Ӑ於��
                    this.uLabel_CustomerName.Enabled = false;
                    //PCC���ЃR�[�h
                    this.tNedit_PccCompanyCode.Enabled = false;
                    //PCC�q�ɃR�[�h
                    this.tNedit_PccWarehouseCd.Enabled = false;
                    //PCC�D��q�ɃR�[�h1
                    this.tNedit_PccPriWarehouseCd1.Enabled = false;
                    //PCC�D��q�ɃR�[�h2
                    this.tNedit_PccPriWarehouseCd2.Enabled = false;
                    //PCC�D��q�ɃR�[�h3
                    this.tNedit_PccPriWarehouseCd3.Enabled = false;
                    // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                    // �I�v�V�����`�F�b�N
                    if (this._optionBLPPriWareHouse)
                    {
                        //PCC�D��q�ɃR�[�h4
                        this.tNedit_PccPriWarehouseCd4.Enabled = false;
                    }
                    else
                    {
                        this.tNedit_PccPriWarehouseCd4.Enabled = false;
                        this.tNedit_PccPriWarehouseCd4.Visible = false;
                        this.ultraLabel27.Visible = false;
                    }
                    // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                    //�i�ԕ\���敪
                    this.tComboEditor_GoodsNoDspDiv.Enabled = false;
                    //�W�����i�\���敪
                    this.tComboEditor_ListPrcDspDiv.Enabled = false;
                    //�d�؉��i�\���敪
                    this.tComboEditor_CostDspDiv.Enabled = false;
                    //�I�ԕ\���敪
                    this.tComboEditor_ShelfDspDiv.Enabled = false;
                    //�R�����g�\���敪
                    this.tComboEditor_CommentDspDiv.Enabled = false;
                    //�o�א��\���敪
                    this.tComboEditor_SpmtCntDspDiv.Enabled = false;
                    // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                    ////�󒍐��\���敪
                    //this.tComboEditor_AcptCntDspDiv.Enabled = false;
                    // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                    //���i�I��i�ԕ\���敪
                    this.tComboEditor_PrtSelGdNoDspDiv.Enabled = false;
                    //���i�I��W�����i�\���敪
                    this.tComboEditor_PrtSelLsPrDspDiv.Enabled = false;
                    //���i�I��I�ԕ\���敪
                    this.tComboEditor_PrtSelSelfDspDiv.Enabled = false;
                    //�݌ɏ󋵃}�[�N1
                    this.tEdit_StckStComment1.Enabled = false;
                    //�݌ɏ󋵃}�[�N2
                    this.tEdit_StckStComment2.Enabled = false;
                    //�݌ɏ󋵃}�[�N3
                    this.tEdit_StckStComment3.Enabled = false;
                    //PCC�����於��1
                    this.tEdit_PccSuplName1.Enabled = false;
                    //PCC�����於��2
                    this.tEdit_PccSuplName2.Enabled = false;
                    //PCC������J�i����
                    this.tEdit_PccSuplKana.Enabled = false;
                    //PCC�����旪��
                    this.tEdit_PccSuplSnm.Enabled = false;
                    //PCC������X�֔ԍ�
                    this.tEdit_PccSuplPostNo.Enabled = false;
                    //PCC������Z��1
                    this.tEdit_PccSuplAddr1.Enabled = false;
                    //PCC������Z��2
                    this.tEdit_PccSuplAddr2.Enabled = false;
                    //PCC������Z��3
                    this.tEdit_PccSuplAddr3.Enabled = false;
                    //PCC������d�b�ԍ�1
                    this.tEdit_PccSuplTelNo1.Enabled = false;
                    //PCC������d�b�ԍ�2
                    this.tEdit_PccSuplTelNo2.Enabled = false;
                    //PCC������FAX�ԍ�
                    this.tEdit_PccSuplFaxNo.Enabled = false;
                    //�`�[���s�敪�iPCC�j
                    this.tComboEditor_PccSlipPrtDiv.Enabled = false;

                    // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
                    // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                    ////�݌ɕ\���敪(�⍇���j
                    //this.tComboEditor_StockDspDiv.Enabled = false;
                    ////���i�I���݌ɕ\���敪(�⍇��)
                    //this.tComboEditor_PrtSelStckDspDiv.Enabled = false;
                    // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                    //�q�ɕ\���敪(�⍇��)
                    this.tComboEditor_WarehouseDspDiv.Enabled = false;
                    //����\���敪(�⍇��)
                    this.tComboEditor_CancelDspDiv.Enabled = false;
                    //�⍇�������\���敪�ݒ�
                    this.tComboEditor_InqOdrDspDivSet.Enabled = false;

                    // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                    // ���݌ɐ��\���敪(�⍇��)
                    this.tComboEditor_PrsntStkCtDspDiv.Enabled = false;
                    // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<

                    // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                    // �񓚔[���\���敪(�⍇��)
                    this.tComboEditor_AnsDeliDtDspDiv.Enabled = false;
                    // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

                    //�⍇�������\���敪�����ʂ̎�
                    if (this.ValueToInt(this.tComboEditor_InqOdrDspDivSet.Value).Equals(INQODRCOMMON))
                    {
                        //���x����\��
                        this.ultraLabel1.Visible = false;
                        this.ultraLabel9.Visible = false;
                        this.ultraLabel10.Visible = false;
                        this.ultraLabel23.Visible = false;
                        //�i�ԕ\���敪(����)
                        this.tComboEditor_GoodsNoDspDivOd.Enabled = false;
                        this.tComboEditor_GoodsNoDspDivOd.Visible = false;
                        //�W�����i�\���敪(����)
                        this.tComboEditor_ListPrcDspDivOd.Enabled = false;
                        this.tComboEditor_ListPrcDspDivOd.Visible = false;
                        //�d�؉��i�\���敪(����)
                        this.tComboEditor_CostDspDivOd.Enabled = false;
                        this.tComboEditor_CostDspDivOd.Visible = false;
                        //�I�ԕ\���敪(����)
                        this.tComboEditor_ShelfDspDivOd.Enabled = false;
                        this.tComboEditor_ShelfDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////�݌ɕ\���敪(����)
                        //this.tComboEditor_StockDspDivOd.Enabled = false;
                        //this.tComboEditor_StockDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //�R�����g�\���敪(����)
                        this.tComboEditor_CommentDspDivOd.Enabled = false;
                        this.tComboEditor_CommentDspDivOd.Visible = false;
                        //�o�א��\���敪(����)
                        this.tComboEditor_SpmtCntDspDivOd.Enabled = false;
                        this.tComboEditor_SpmtCntDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////�󒍐��\���敪(����)
                        //this.tComboEditor_AcptCntDspDivOd.Enabled = false;
                        //this.tComboEditor_AcptCntDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //���i�I��i�ԕ\���敪(����)
                        this.tComboEditor_PrtSelGdNoDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelGdNoDspDivOd.Visible = false;
                        //���i�I��W�����i�\���敪(����)
                        this.tComboEditor_PrtSelLsPrDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelLsPrDspDivOd.Visible = false;
                        //���i�I��I�ԕ\���敪(����)
                        this.tComboEditor_PrtSelSelfDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelSelfDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////���i�I���݌ɕ\���敪(����)
                        //this.tComboEditor_PrtSelStckDspDivOd.Enabled = false;
                        //this.tComboEditor_PrtSelStckDspDivOd.Visible = false;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //�q�ɕ\���敪(����)
                        this.tComboEditor_WarehouseDspDivOd.Enabled = false;
                        this.tComboEditor_WarehouseDspDivOd.Visible = false;
                        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                        // ���݌ɐ��\���敪(����)
                        this.tComboEditor_PrsntStkCtDspDivOd.Enabled = false;
                        this.tComboEditor_PrsntStkCtDspDivOd.Visible = false;
                        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                        // �񓚔[���\���敪(����)
                        this.tComboEditor_AnsDeliDtDspDivOd.Enabled = false;
                        this.tComboEditor_AnsDeliDtDspDivOd.Visible = false;
                        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
                        //����\���敪(����)
                        this.tComboEditor_CancelDspDivOd.Enabled = false;
                        this.tComboEditor_CancelDspDivOd.Visible = false;
                    }
                    //�⍇�������\���敪���ʂ̎�
                    else
                    {
                        //���x���\��
                        this.ultraLabel1.Visible = true;
                        this.ultraLabel9.Visible = true;
                        this.ultraLabel10.Visible = true;
                        this.ultraLabel23.Visible = true;
                        //�i�ԕ\���敪(����)
                        this.tComboEditor_GoodsNoDspDivOd.Enabled = false;
                        this.tComboEditor_GoodsNoDspDivOd.Visible = true;
                        //�W�����i�\���敪(����)
                        this.tComboEditor_ListPrcDspDivOd.Enabled = false;
                        this.tComboEditor_ListPrcDspDivOd.Visible = true;
                        //�d�؉��i�\���敪(����)
                        this.tComboEditor_CostDspDivOd.Enabled = false;
                        this.tComboEditor_CostDspDivOd.Visible = true;
                        //�I�ԕ\���敪(����)
                        this.tComboEditor_ShelfDspDivOd.Enabled = false;
                        this.tComboEditor_ShelfDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////�݌ɕ\���敪(����)
                        //this.tComboEditor_StockDspDivOd.Enabled = false;
                        //this.tComboEditor_StockDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //�R�����g�\���敪(����)
                        this.tComboEditor_CommentDspDivOd.Enabled = false;
                        this.tComboEditor_CommentDspDivOd.Visible = true;
                        //�o�א��\���敪(����)
                        this.tComboEditor_SpmtCntDspDivOd.Enabled = false;
                        this.tComboEditor_SpmtCntDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////�󒍐��\���敪(����)
                        //this.tComboEditor_AcptCntDspDivOd.Enabled = false;
                        //this.tComboEditor_AcptCntDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //���i�I��i�ԕ\���敪(����)
                        this.tComboEditor_PrtSelGdNoDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelGdNoDspDivOd.Visible = true;
                        //���i�I��W�����i�\���敪(����)
                        this.tComboEditor_PrtSelLsPrDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelLsPrDspDivOd.Visible = true;
                        //���i�I��I�ԕ\���敪(����)
                        this.tComboEditor_PrtSelSelfDspDivOd.Enabled = false;
                        this.tComboEditor_PrtSelSelfDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                        ////���i�I���݌ɕ\���敪(����)
                        //this.tComboEditor_PrtSelStckDspDivOd.Enabled = false;
                        //this.tComboEditor_PrtSelStckDspDivOd.Visible = true;
                        // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                        //�q�ɕ\���敪(����)
                        this.tComboEditor_WarehouseDspDivOd.Enabled = false;
                        this.tComboEditor_WarehouseDspDivOd.Visible = true;
                        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                        // ���݌ɐ��\���敪(����)
                        this.tComboEditor_PrsntStkCtDspDivOd.Enabled = false;
                        this.tComboEditor_PrsntStkCtDspDivOd.Visible = true;
                        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<

                        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                        this.tComboEditor_AnsDeliDtDspDivOd.Enabled = true;
                        this.tComboEditor_AnsDeliDtDspDivOd.Visible = true;
                        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

                        //����\���敪(����)
                        this.tComboEditor_CancelDspDivOd.Enabled = false;
                        this.tComboEditor_CancelDspDivOd.Visible = true;
                    }
                    // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<

                    // �{�^��
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.UltraButton_Quote.Visible = false;
                    this.UButton_CustomerGuide.Enabled = false;
                    break;
            }

        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            PccCmpnySt pccCmpnySt = new PccCmpnySt();
            ScreenClear();
                
            // �V�K�̏ꍇ
            if (this._dataIndex < 0)
            {
                // �N���[���쐬
                this._pccCmpnySt = pccCmpnySt.Clone();
                DispToPccCmpnySt(ref this._pccCmpnySt);
                //�⍇������ƃR�[�h
                this._inqOriginalEpCd =string.Empty;
                //�⍇�������_�R�[�h
                this._inqOriginalSecCd = string.Empty;
                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);
                this.TabControl_PccCmpnySt.Tabs[0].Selected = true;
                // �t�H�[�J�X�ݒ�
                this.tNedit_CustomerCode.Focus();
            }
            // �폜�̏ꍇ
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                // �폜���[�h
                this.Mode_Label.Text = DELETE_MODE;

                // �\�����擾
                string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pccCmpnySt = (PccCmpnySt)this._detailsTable[guid];
                //�⍇������ƃR�[�h
                this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                //�⍇�������_�R�[�h
                this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd.TrimEnd();
                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(DELETE_MODE);
                // �t�H�[�J�X�ݒ�
                this.Delete_Button.Focus();
                this.TabControl_PccCmpnySt.Tabs[0].Selected = true;
                // ��ʓW�J����
                PccCmpnyStToScreen(pccCmpnySt);
            }
            // �X�V�̏ꍇ
            else
            {
                // �X�V���[�h
                this.Mode_Label.Text = UPDATE_MODE;

                // �\�����擾
                string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pccCmpnySt = (PccCmpnySt)this._detailsTable[guid];

                //�⍇������ƃR�[�h
                this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                //�⍇�������_�R�[�h
                this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd.TrimEnd();
                //�O���Ӑ�R�[�h
                this._customerCodePre = pccCmpnySt.PccCompanyCode;
                //�O���Ӑ於��
                this._customerNamePre = pccCmpnySt.PccCompanyName;
                this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(UPDATE_MODE);

                // ��ʓW�J����
                PccCmpnyStToScreen(pccCmpnySt);

                // �N���[���쐬
                this._pccCmpnySt = pccCmpnySt.Clone();
                DispToPccCmpnySt(ref this._pccCmpnySt);

                // �t�H�[�J�X�ݒ� PCC�q�ɃR�[�h
                this.tNedit_PccWarehouseCd.Focus();
                this.TabControl_PccCmpnySt.Tabs[0].Selected = true;
            }

            //_GridIndex�o�b�t�@�ێ�
            this._detailsIndexBuf = this._dataIndex;
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^�N���X��ʓW�J����
        /// </summary>
        /// <param name="commColumn">PCC���Аݒ�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void PccCmpnyStToScreen(PccCmpnySt pccCmpnySt)
        {
            //���Ӑ�R�[�h
            this.tNedit_CustomerCode.SetInt(pccCmpnySt.PccCompanyCode);
            //���Ӑ於��
            this.uLabel_CustomerName.Text = pccCmpnySt.PccCompanyName;
            //PCC���ЃR�[�h
            this.tNedit_PccCompanyCode.SetInt(pccCmpnySt.PccCompanyCode);
            //PCC�q�ɃR�[�h
            int pccWarehouseCd = 0;
            Int32.TryParse(pccCmpnySt.PccWarehouseCd, out pccWarehouseCd);
            this.tNedit_PccWarehouseCd.SetInt(pccWarehouseCd);
            //PCC�D��q�ɃR�[�h1
            int pccPriWarehouseCd1 = 0;
            Int32.TryParse(pccCmpnySt.PccPriWarehouseCd1, out pccPriWarehouseCd1);
            this.tNedit_PccPriWarehouseCd1.SetInt(pccPriWarehouseCd1);
            //PCC�D��q�ɃR�[�h2
            int pccPriWarehouseCd2 = 0;
            Int32.TryParse(pccCmpnySt.PccPriWarehouseCd2, out pccPriWarehouseCd2);
            this.tNedit_PccPriWarehouseCd2.SetInt(pccPriWarehouseCd2);
            //PCC�D��q�ɃR�[�h3
            int pccPriWarehouseCd3 = 0;
            Int32.TryParse(pccCmpnySt.PccPriWarehouseCd3, out pccPriWarehouseCd3);
            this.tNedit_PccPriWarehouseCd3.SetInt(pccPriWarehouseCd3);
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            //PCC�D��q�ɃR�[�h4
            int pccPriWarehouseCd4 = 0;
            Int32.TryParse(pccCmpnySt.PccPriWarehouseCd4, out pccPriWarehouseCd4);
            this.tNedit_PccPriWarehouseCd4.SetInt(pccPriWarehouseCd4);
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            //�i�ԕ\���敪
            this.tComboEditor_GoodsNoDspDiv.Value = pccCmpnySt.GoodsNoDspDiv;
            //�W�����i�\���敪
            this.tComboEditor_ListPrcDspDiv.Value = pccCmpnySt.ListPrcDspDiv;
            //�d�؉��i�\���敪
            this.tComboEditor_CostDspDiv.Value = pccCmpnySt.CostDspDiv;
            //�I�ԕ\���敪
            this.tComboEditor_ShelfDspDiv.Value = pccCmpnySt.ShelfDspDiv;
            //�R�����g�\���敪
            this.tComboEditor_CommentDspDiv.Value = pccCmpnySt.CommentDspDiv;
            //�o�א��\���敪
            this.tComboEditor_SpmtCntDspDiv.Value = pccCmpnySt.SpmtCntDspDiv;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�󒍐��\���敪
            //this.tComboEditor_AcptCntDspDiv.Value = pccCmpnySt.AcptCntDspDiv;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //���i�I��i�ԕ\���敪
            this.tComboEditor_PrtSelGdNoDspDiv.Value = pccCmpnySt.PrtSelGdNoDspDiv;
            //���i�I��W�����i�\���敪
            this.tComboEditor_PrtSelLsPrDspDiv.Value = pccCmpnySt.PrtSelLsPrDspDiv;
            //���i�I��I�ԕ\���敪
            this.tComboEditor_PrtSelSelfDspDiv.Value = pccCmpnySt.PrtSelSelfDspDiv;
            //�݌ɃR�����g1
            this.tEdit_StckStComment1.Value = pccCmpnySt.StckStComment1;
            //�݌ɃR�����g2
            this.tEdit_StckStComment2.Value = pccCmpnySt.StckStComment2;
            //�݌ɃR�����g3
            this.tEdit_StckStComment3.Value = pccCmpnySt.StckStComment3;
            //PCC�����於��1
            this.tEdit_PccSuplName1.Value = pccCmpnySt.PccSuplName1;
            //PCC�����於��2
            this.tEdit_PccSuplName2.Value = pccCmpnySt.PccSuplName2;
            //PCC������J�i����
            this.tEdit_PccSuplKana.Value = pccCmpnySt.PccSuplKana;
            //PCC�����旪��
            this.tEdit_PccSuplSnm.Value = pccCmpnySt.PccSuplSnm;
            //PCC������X�֔ԍ�
            this.tEdit_PccSuplPostNo.Value = pccCmpnySt.PccSuplPostNo;
            //PCC������Z��1
            this.tEdit_PccSuplAddr1.Value = pccCmpnySt.PccSuplAddr1;
            //PCC������Z��2
            this.tEdit_PccSuplAddr2.Value = pccCmpnySt.PccSuplAddr2;
            //PCC������Z��3
            this.tEdit_PccSuplAddr3.Value = pccCmpnySt.PccSuplAddr3;
            //PCC������d�b�ԍ�1
            this.tEdit_PccSuplTelNo1.Value = pccCmpnySt.PccSuplTelNo1;
            //PCC������d�b�ԍ�2
            this.tEdit_PccSuplTelNo2.Value = pccCmpnySt.PccSuplTelNo2;
            //PCC������FAX�ԍ�
            this.tEdit_PccSuplFaxNo.Value = pccCmpnySt.PccSuplFaxNo;
            //�`�[���s�敪�iPCC�j
            this.tComboEditor_PccSlipPrtDiv.Value = pccCmpnySt.PccSlipPrtDiv;

            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�݌ɕ\���敪(�⍇��)
            //this.tComboEditor_StockDspDiv.Value = pccCmpnySt.StockDspDiv;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�q�ɕ\���敪(�⍇��)
            this.tComboEditor_WarehouseDspDiv.Value = pccCmpnySt.WarehouseDspDiv;
            //����\���敪(�⍇��)
            this.tComboEditor_CancelDspDiv.Value = pccCmpnySt.CancelDspDiv;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////���i�I���݌ɕ\���敪(�⍇���j
            //this.tComboEditor_PrtSelStckDspDiv.Value = pccCmpnySt.PrtSelStckDspDiv;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�i�ԕ\���敪(����)
            this.tComboEditor_GoodsNoDspDivOd.Value = pccCmpnySt.GoodsNoDspDivOd;
            //�W�����i�\���敪(����)
            this.tComboEditor_ListPrcDspDivOd.Value = pccCmpnySt.ListPrcDspDivOd;
            //�d�؉��i�\���敪(����)
            this.tComboEditor_CostDspDivOd.Value = pccCmpnySt.CostDspDivOd;
            //�I�ԕ\���敪(����)
            this.tComboEditor_ShelfDspDivOd.Value = pccCmpnySt.ShelfDspDivOd;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�݌ɕ\���敪(����)
            //this.tComboEditor_StockDspDivOd.Value = pccCmpnySt.StockDspDivOd;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�R�����g�\���敪(����)
            this.tComboEditor_CommentDspDivOd.Value = pccCmpnySt.CommentDspDivOd;
            //�o�א��\���敪(����)
            this.tComboEditor_SpmtCntDspDivOd.Value = pccCmpnySt.SpmtCntDspDivOd;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�󒍐��\���敪(����)
            //this.tComboEditor_AcptCntDspDivOd.Value = pccCmpnySt.AcptCntDspDivOd;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //���i�I��i�ԕ\���敪(����)
            this.tComboEditor_PrtSelGdNoDspDivOd.Value = pccCmpnySt.PrtSelGdNoDspDivOd;
            //���i�I��W�����i�\���敪(����)
            this.tComboEditor_PrtSelLsPrDspDivOd.Value = pccCmpnySt.PrtSelLsPrDspDivOd;
            //���i�I��I�ԕ\���敪(����)
            this.tComboEditor_PrtSelSelfDspDivOd.Value = pccCmpnySt.PrtSelSelfDspDivOd;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////���i�I���݌ɕ\���敪(����)
            //this.tComboEditor_PrtSelStckDspDivOd.Value = pccCmpnySt.PrtSelStckDspDivOd;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�q�ɕ\���敪(����)
            this.tComboEditor_WarehouseDspDivOd.Value = pccCmpnySt.WarehouseDspDivOd;
            //����\���敪(����)
            this.tComboEditor_CancelDspDivOd.Value = pccCmpnySt.CancelDspDivOd;
            //�⍇�������\���敪�ݒ�
            this.tComboEditor_InqOdrDspDivSet.Value = pccCmpnySt.InqOdrDspDivSet;
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            //���݌ɐ��\���敪(����)
            this.tComboEditor_PrsntStkCtDspDivOd.Value = pccCmpnySt.PrsntStkCtDspDivOd;
            //���݌ɐ��\���敪(�⍇��)
            this.tComboEditor_PrsntStkCtDspDiv.Value = pccCmpnySt.PrsntStkCtDspDiv;
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            // �񓚔[���\���敪(�⍇��)
            this.tComboEditor_AnsDeliDtDspDiv.Value = pccCmpnySt.AnsDeliDtDspDiv;
            // �񓚔[���\���敪(����)
            this.tComboEditor_AnsDeliDtDspDivOd.Value = pccCmpnySt.AnsDeliDtDspDivOd;
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^�N���X��ʓW�J����
        /// </summary>
        /// <param name="commColumn">PCC���Аݒ�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void PccCmpnyStToScreenForQuote(PccCmpnySt pccCmpnySt)
        {
           
            //PCC�q�ɃR�[�h
            int pccWarehouseCd = 0;
            Int32.TryParse(pccCmpnySt.PccWarehouseCd, out pccWarehouseCd);
            this.tNedit_PccWarehouseCd.SetInt(pccWarehouseCd);
            //PCC�D��q�ɃR�[�h1
            int pccPriWarehouseCd1 = 0;
            Int32.TryParse(pccCmpnySt.PccPriWarehouseCd1, out pccPriWarehouseCd1);
            this.tNedit_PccPriWarehouseCd1.SetInt(pccPriWarehouseCd1);
            //PCC�D��q�ɃR�[�h2
            int pccPriWarehouseCd2 = 0;
            Int32.TryParse(pccCmpnySt.PccPriWarehouseCd2, out pccPriWarehouseCd2);
            this.tNedit_PccPriWarehouseCd2.SetInt(pccPriWarehouseCd2);
            //PCC�D��q�ɃR�[�h3
            int pccPriWarehouseCd3 = 0;
            Int32.TryParse(pccCmpnySt.PccPriWarehouseCd3, out pccPriWarehouseCd3);
            this.tNedit_PccPriWarehouseCd3.SetInt(pccPriWarehouseCd3);
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            //PCC�D��q�ɃR�[�h4
            int pccPriWarehouseCd4 = 0;
            Int32.TryParse(pccCmpnySt.PccPriWarehouseCd4, out pccPriWarehouseCd4);
            this.tNedit_PccPriWarehouseCd4.SetInt(pccPriWarehouseCd4);
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            //�i�ԕ\���敪
            this.tComboEditor_GoodsNoDspDiv.Value = pccCmpnySt.GoodsNoDspDiv;
            //�W�����i�\���敪
            this.tComboEditor_ListPrcDspDiv.Value = pccCmpnySt.ListPrcDspDiv;
            //�d�؉��i�\���敪
            this.tComboEditor_CostDspDiv.Value = pccCmpnySt.CostDspDiv;
            //�I�ԕ\���敪
            this.tComboEditor_ShelfDspDiv.Value = pccCmpnySt.ShelfDspDiv;
            //�R�����g�\���敪
            this.tComboEditor_CommentDspDiv.Value = pccCmpnySt.CommentDspDiv;
            //�o�א��\���敪
            this.tComboEditor_SpmtCntDspDiv.Value = pccCmpnySt.SpmtCntDspDiv;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�󒍐��\���敪
            //this.tComboEditor_AcptCntDspDiv.Value = pccCmpnySt.AcptCntDspDiv;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //���i�I��i�ԕ\���敪
            this.tComboEditor_PrtSelGdNoDspDiv.Value = pccCmpnySt.PrtSelGdNoDspDiv;
            //���i�I��W�����i�\���敪
            this.tComboEditor_PrtSelLsPrDspDiv.Value = pccCmpnySt.PrtSelLsPrDspDiv;
            //���i�I��I�ԕ\���敪
            this.tComboEditor_PrtSelSelfDspDiv.Value = pccCmpnySt.PrtSelSelfDspDiv;
            //�݌ɃR�����g1
            this.tEdit_StckStComment1.Value = pccCmpnySt.StckStComment1;
            //�݌ɃR�����g2
            this.tEdit_StckStComment2.Value = pccCmpnySt.StckStComment2;
            //�݌ɃR�����g3
            this.tEdit_StckStComment3.Value = pccCmpnySt.StckStComment3;
            //PCC�����於��1
            this.tEdit_PccSuplName1.Value = pccCmpnySt.PccSuplName1;
            //PCC�����於��2
            this.tEdit_PccSuplName2.Value = pccCmpnySt.PccSuplName2;
            //PCC������J�i����
            this.tEdit_PccSuplKana.Value = pccCmpnySt.PccSuplKana;
            //PCC�����旪��
            this.tEdit_PccSuplSnm.Value = pccCmpnySt.PccSuplSnm;
            //PCC������X�֔ԍ�
            this.tEdit_PccSuplPostNo.Value = pccCmpnySt.PccSuplPostNo;
            //PCC������Z��1
            this.tEdit_PccSuplAddr1.Value = pccCmpnySt.PccSuplAddr1;
            //PCC������Z��2
            this.tEdit_PccSuplAddr2.Value = pccCmpnySt.PccSuplAddr2;
            //PCC������Z��3
            this.tEdit_PccSuplAddr3.Value = pccCmpnySt.PccSuplAddr3;
            //PCC������d�b�ԍ�1
            this.tEdit_PccSuplTelNo1.Value = pccCmpnySt.PccSuplTelNo1;
            //PCC������d�b�ԍ�2
            this.tEdit_PccSuplTelNo2.Value = pccCmpnySt.PccSuplTelNo2;
            //PCC������FAX�ԍ�
            this.tEdit_PccSuplFaxNo.Value = pccCmpnySt.PccSuplFaxNo;
            //�`�[���s�敪�iPCC�j
            this.tComboEditor_PccSlipPrtDiv.Value = pccCmpnySt.PccSlipPrtDiv;

            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�݌ɕ\���敪(�⍇��)
            //this.tComboEditor_StockDspDiv.Value = pccCmpnySt.StockDspDiv;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�q�ɕ\���敪(�⍇��)
            this.tComboEditor_WarehouseDspDiv.Value = pccCmpnySt.WarehouseDspDiv;
            //����\���敪(�⍇��)
            this.tComboEditor_CancelDspDiv.Value = pccCmpnySt.CancelDspDiv;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////���i�I���݌ɕ\���敪(�⍇��)
            //this.tComboEditor_PrtSelStckDspDiv.Value = pccCmpnySt.PrtSelStckDspDiv;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�i�ԕ\���敪(����)
            this.tComboEditor_GoodsNoDspDivOd.Value = pccCmpnySt.GoodsNoDspDivOd;
            //�W�����i�\���敪(����)
            this.tComboEditor_ListPrcDspDivOd.Value = pccCmpnySt.ListPrcDspDivOd;
            //�d�؉��i�\���敪(����)
            this.tComboEditor_CostDspDivOd.Value = pccCmpnySt.CostDspDivOd;
            //�I�ԕ\���敪(����)
            this.tComboEditor_ShelfDspDivOd.Value = pccCmpnySt.ShelfDspDivOd;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�݌ɕ\���敪(����)
            //this.tComboEditor_StockDspDivOd.Value = pccCmpnySt.StockDspDivOd;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�R�����g�\���敪(����)
            this.tComboEditor_CommentDspDivOd.Value = pccCmpnySt.CommentDspDivOd;
            //�o�א��\���敪(����)
            this.tComboEditor_SpmtCntDspDivOd.Value = pccCmpnySt.SpmtCntDspDivOd;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�󒍐��\���敪(����)
            //this.tComboEditor_AcptCntDspDivOd.Value = pccCmpnySt.AcptCntDspDivOd;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //���i�I��i�ԕ\���敪(����)
            this.tComboEditor_PrtSelGdNoDspDivOd.Value = pccCmpnySt.PrtSelGdNoDspDivOd;
            //���i�I��W�����i�\���敪(����)
            this.tComboEditor_PrtSelLsPrDspDivOd.Value = pccCmpnySt.PrtSelLsPrDspDivOd;
            //���i�I��I�ԕ\���敪(����)
            this.tComboEditor_PrtSelSelfDspDivOd.Value = pccCmpnySt.PrtSelSelfDspDivOd;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////���i�I���݌ɕ\���敪(����)
            //this.tComboEditor_PrtSelStckDspDivOd.Value = pccCmpnySt.PrtSelStckDspDivOd;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�q�ɕ\���敪(����)
            this.tComboEditor_WarehouseDspDivOd.Value = pccCmpnySt.WarehouseDspDivOd;
            //����\���敪(����)
            this.tComboEditor_CancelDspDivOd.Value = pccCmpnySt.CancelDspDivOd;
            //�⍇�������\���敪�ݒ�
            this.tComboEditor_InqOdrDspDivSet.Value = pccCmpnySt.InqOdrDspDivSet;
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            //���݌ɐ��\���敪(����)
            this.tComboEditor_PrsntStkCtDspDivOd.Value = pccCmpnySt.PrsntStkCtDspDivOd;
            //���݌ɐ��\���敪(�⍇��)
            this.tComboEditor_PrsntStkCtDspDiv.Value = pccCmpnySt.PrsntStkCtDspDiv;
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            // �񓚔[���\���敪(�⍇��)
            this.tComboEditor_AnsDeliDtDspDiv.Value = pccCmpnySt.AnsDeliDtDspDiv;
            // �񓚔[���\���敪(����)
            this.tComboEditor_AnsDeliDtDspDivOd.Value = pccCmpnySt.AnsDeliDtDspDivOd;
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
        }

        /// <summary>
        /// Value�`�F�b�N�����istring�j
        /// </summary>
        /// <param name="sorce">tCombo��Value</param>
        /// <returns>�`�F�b�N��̒l</returns>
        /// <remarks>
        /// <br>Note		: tCombo�̒l��Class�ɓ���鎞��NULL�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private string ValueToString(object sorce)
        {
            string dest = string.Empty;
            try
            {
                if (sorce != null)
                {
                    dest = Convert.ToString(sorce);
                }
            }
            catch
            {
                return dest;
            }
            return dest;
        }
       
        /// <summary>
        /// Value�`�F�b�N�����iint�j
        /// </summary>
        /// <param name="sorce">tCombo��Value</param>
        /// <returns>�`�F�b�N��̒l</returns>
        /// <remarks>
        /// <br>Note		: tCombo�̒l��Class�ɓ���鎞��NULL�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private int ValueToInt(object sorce)
        {
            int dest = 0;
            try
            {
                if (sorce != null)
                {
                    Int32.TryParse(sorce.ToString(), out dest);
                }
            }
            catch
            {
                return dest;
            }
            return dest;
        }

        /// <summary>
        /// ��ʏ��PCC���Аݒ�}�X�^�N���X�i�[����
        /// </summary>
        /// <param name="commColumn">PCC���Аݒ�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂畔��I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void DispToPccCmpnySt(ref PccCmpnySt pccCmpnySt)
        {
            //�⍇������ƃR�[�h
            pccCmpnySt.InqOriginalEpCd = this._inqOriginalEpCd.Trim();//@@@@20230303
            //�⍇�������_�R�[�h
            pccCmpnySt.InqOriginalSecCd = this._inqOriginalSecCd;
            //�⍇�����ƃR�[�h
            pccCmpnySt.InqOtherEpCd = this._enterpriseCode;
            //�⍇���拒�_�R�[�h
            pccCmpnySt.InqOtherSecCd = this._loginSectionCode;
             //PCC���ЃR�[�h
            pccCmpnySt.PccCompanyCode = this.tNedit_PccCompanyCode.GetInt();
            //PCC�q�ɃR�[�h
            pccCmpnySt.PccWarehouseCd = this.ValueToString(this.tNedit_PccWarehouseCd.Value);
            //PCC�D��q�ɃR�[�h1
            pccCmpnySt.PccPriWarehouseCd1 = this.ValueToString(this.tNedit_PccPriWarehouseCd1.Value);
            //PCC�D��q�ɃR�[�h2
            pccCmpnySt.PccPriWarehouseCd2 = this.ValueToString(this.tNedit_PccPriWarehouseCd2.Value);
            //PCC�D��q�ɃR�[�h3
            pccCmpnySt.PccPriWarehouseCd3 = this.ValueToString(this.tNedit_PccPriWarehouseCd3.Value);
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            //PCC�D��q�ɃR�[�h4
            pccCmpnySt.PccPriWarehouseCd4 = this.ValueToString(this.tNedit_PccPriWarehouseCd4.Value);
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            //�i�ԕ\���敪
            pccCmpnySt.GoodsNoDspDiv = this.ValueToInt(this.tComboEditor_GoodsNoDspDiv.Value);
            //�W�����i�\���敪
            pccCmpnySt.ListPrcDspDiv = this.ValueToInt(this.tComboEditor_ListPrcDspDiv.Value);
            //�d�؉��i�\���敪
            pccCmpnySt.CostDspDiv = this.ValueToInt(this.tComboEditor_CostDspDiv.Value);
            //�I�ԕ\���敪
            pccCmpnySt.ShelfDspDiv = this.ValueToInt(this.tComboEditor_ShelfDspDiv.Value);
            //�R�����g�\���敪
            pccCmpnySt.CommentDspDiv = this.ValueToInt(this.tComboEditor_CommentDspDiv.Value);
            //�o�א��\���敪
            pccCmpnySt.SpmtCntDspDiv = this.ValueToInt(this.tComboEditor_SpmtCntDspDiv.Value);
            //�󒍐��\���敪
            pccCmpnySt.AcptCntDspDiv = 1;
            //���i�I��i�ԕ\���敪
            pccCmpnySt.PrtSelGdNoDspDiv = this.ValueToInt(this.tComboEditor_PrtSelGdNoDspDiv.Value);
            //���i�I��W�����i�\���敪
            pccCmpnySt.PrtSelLsPrDspDiv = this.ValueToInt(this.tComboEditor_PrtSelLsPrDspDiv.Value);
            //���i�I��I�ԕ\���敪
            pccCmpnySt.PrtSelSelfDspDiv = this.ValueToInt(this.tComboEditor_PrtSelSelfDspDiv.Value);
            //�݌ɏ󋵃R�����g1
            pccCmpnySt.StckStComment1 = this.ValueToString(this.tEdit_StckStComment1.Value);
            //�݌ɏ󋵃R�����g2
            pccCmpnySt.StckStComment2 = this.ValueToString(this.tEdit_StckStComment2.Value);
            //�݌ɏ󋵃R�����g3
            pccCmpnySt.StckStComment3 = this.ValueToString(this.tEdit_StckStComment3.Value);
            //PCC�����於��1
            pccCmpnySt.PccSuplName1 = this.ValueToString(this.tEdit_PccSuplName1.Value);
            //PCC�����於��2
            pccCmpnySt.PccSuplName2 = this.ValueToString(this.tEdit_PccSuplName2.Value);
            //PCC������J�i����
            pccCmpnySt.PccSuplKana = this.ValueToString(this.tEdit_PccSuplKana.Value);
            //PCC�����旪��
            pccCmpnySt.PccSuplSnm = this.ValueToString(this.tEdit_PccSuplSnm.Value);
            //PCC������X�֔ԍ�
            pccCmpnySt.PccSuplPostNo = this.ValueToString(this.tEdit_PccSuplPostNo.Value);
            //PCC������Z��1
            pccCmpnySt.PccSuplAddr1 = this.ValueToString(this.tEdit_PccSuplAddr1.Value);
            //PCC������Z��2
            pccCmpnySt.PccSuplAddr2 = this.ValueToString(this.tEdit_PccSuplAddr2.Value);
            //PCC������Z��3
            pccCmpnySt.PccSuplAddr3 = this.ValueToString(this.tEdit_PccSuplAddr3.Value);
            //PCC������d�b�ԍ�1
            pccCmpnySt.PccSuplTelNo1 = this.ValueToString(this.tEdit_PccSuplTelNo1.Value);
            //PCC������d�b�ԍ�2
            pccCmpnySt.PccSuplTelNo2 = this.ValueToString(this.tEdit_PccSuplTelNo2.Value);
            //PCC������FAX�ԍ�
            pccCmpnySt.PccSuplFaxNo = this.ValueToString(this.tEdit_PccSuplFaxNo.Value);
            //�`�[���s�敪�iPCC�j
            pccCmpnySt.PccSlipPrtDiv = this.ValueToInt(this.tComboEditor_PccSlipPrtDiv.Value);

            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
            //�⍇�������\���敪�ݒ�
            pccCmpnySt.InqOdrDspDivSet = this.ValueToInt(this.tComboEditor_InqOdrDspDivSet.Value);

            // �⍇���������ʂ̎�
            if (pccCmpnySt.InqOdrDspDivSet.Equals(INQODRCOMMON))
            {
                //�݌ɕ\���敪(�⍇��)
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                //pccCmpnySt.StockDspDiv = this.ValueToInt(this.tComboEditor_StockDspDiv.Value);
                pccCmpnySt.StockDspDiv = 1;
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                //�q�ɕ\���敪(�⍇��)
                pccCmpnySt.WarehouseDspDiv = this.ValueToInt(this.tComboEditor_WarehouseDspDiv.Value);
                //����\���敪(�⍇��)
                pccCmpnySt.CancelDspDiv = this.ValueToInt(this.tComboEditor_CancelDspDiv.Value);
                //���i�I���݌ɕ\���敪(�⍇��)
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                //pccCmpnySt.PrtSelStckDspDiv = this.ValueToInt(this.tComboEditor_PrtSelStckDspDiv.Value);
                pccCmpnySt.PrtSelStckDspDiv = 1;
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                //�i�ԕ\���敪(����)
                pccCmpnySt.GoodsNoDspDivOd = this.ValueToInt(this.tComboEditor_GoodsNoDspDiv.Value);
                //�W�����i�\���敪(����)
                pccCmpnySt.ListPrcDspDivOd = this.ValueToInt(this.tComboEditor_ListPrcDspDiv.Value);
                //�d�؉��i�\���敪(����)
                pccCmpnySt.CostDspDivOd = this.ValueToInt(this.tComboEditor_CostDspDiv.Value);
                //�I�ԕ\���敪(����)
                pccCmpnySt.ShelfDspDivOd = this.ValueToInt(this.tComboEditor_ShelfDspDiv.Value);
                //�݌ɕ\���敪(����)
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                //pccCmpnySt.StockDspDivOd = this.ValueToInt(this.tComboEditor_StockDspDiv.Value);
                pccCmpnySt.StockDspDivOd = 1;
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                //�R�����g�\���敪(����)
                pccCmpnySt.CommentDspDivOd = this.ValueToInt(this.tComboEditor_CommentDspDiv.Value);
                //�o�א��\���敪(����)
                pccCmpnySt.SpmtCntDspDivOd = this.ValueToInt(this.tComboEditor_SpmtCntDspDiv.Value);
                //�󒍐��\���敪(����)
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                //pccCmpnySt.AcptCntDspDivOd = this.ValueToInt(this.tComboEditor_AcptCntDspDiv.Value);
                pccCmpnySt.AcptCntDspDivOd = 1;
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                //���i�I��i�ԕ\���敪(����)
                pccCmpnySt.PrtSelGdNoDspDivOd = this.ValueToInt(this.tComboEditor_PrtSelGdNoDspDiv.Value);
                //���i�I��W�����i�\���敪(����)
                pccCmpnySt.PrtSelLsPrDspDivOd = this.ValueToInt(this.tComboEditor_PrtSelLsPrDspDiv.Value);
                //���i�I��I�ԕ\���敪(����)
                pccCmpnySt.PrtSelSelfDspDivOd = this.ValueToInt(this.tComboEditor_PrtSelSelfDspDiv.Value);
                //���i�I���݌ɕ\���敪(����)
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                //pccCmpnySt.PrtSelStckDspDivOd = this.ValueToInt(this.tComboEditor_PrtSelStckDspDiv.Value);
                pccCmpnySt.PrtSelStckDspDivOd = 1;
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                //�q�ɕ\���敪(����)
                pccCmpnySt.WarehouseDspDivOd = this.ValueToInt(this.tComboEditor_WarehouseDspDiv.Value);
                //����\���敪(����)
                pccCmpnySt.CancelDspDivOd = this.ValueToInt(this.tComboEditor_CancelDspDiv.Value);
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                //���݌ɐ��\���敪(�⍇��)
                pccCmpnySt.PrsntStkCtDspDiv = Convert.ToInt16(this.tComboEditor_PrsntStkCtDspDiv.Value);
                //���݌ɐ��\���敪(����)
                pccCmpnySt.PrsntStkCtDspDivOd = Convert.ToInt16(this.tComboEditor_PrsntStkCtDspDiv.Value);
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                // �񓚔[���\���敪(�⍇��)
                pccCmpnySt.AnsDeliDtDspDiv = Convert.ToInt16(this.tComboEditor_AnsDeliDtDspDiv.Value);
                // �񓚔[���\���敪(����)
                // 2014/10/22 UPD TAKAGAWA �\���敪���⍇���������ʂŉ񓚔[���\���敪��ݒ肵�Ă��A�����̋敪���ݒ肳��Ȃ����̑Ή� ---------->>>>>>>>>>
                //pccCmpnySt.AnsDeliDtDspDivOd = Convert.ToInt16(this.tComboEditor_AnsDeliDtDspDivOd.Value);
                pccCmpnySt.AnsDeliDtDspDivOd = Convert.ToInt16(this.tComboEditor_AnsDeliDtDspDiv.Value);
                // 2014/10/22 UPD TAKAGAWA �\���敪���⍇���������ʂŉ񓚔[���\���敪��ݒ肵�Ă��A�����̋敪���ݒ肳��Ȃ����̑Ή� ----------<<<<<<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
            }
            // �⍇�������ʂ̎�
            else
            {
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                //�݌ɕ\���敪(�⍇��)
                //pccCmpnySt.StockDspDiv = this.ValueToInt(this.tComboEditor_StockDspDiv.Value);
                pccCmpnySt.StockDspDiv = 1;
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                //�q�ɕ\���敪(�⍇��)
                pccCmpnySt.WarehouseDspDiv = this.ValueToInt(this.tComboEditor_WarehouseDspDiv.Value);
                //����\���敪(�⍇��)
                pccCmpnySt.CancelDspDiv = this.ValueToInt(this.tComboEditor_CancelDspDiv.Value);
                //���i�I���݌ɕ\���敪(�⍇��)
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                //pccCmpnySt.PrtSelStckDspDiv = this.ValueToInt(this.tComboEditor_PrtSelStckDspDiv.Value);
                pccCmpnySt.PrtSelStckDspDiv = 1;
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                //�i�ԕ\���敪(����)
                pccCmpnySt.GoodsNoDspDivOd = this.ValueToInt(this.tComboEditor_GoodsNoDspDivOd.Value);
                //�W�����i�\���敪(����)
                pccCmpnySt.ListPrcDspDivOd = this.ValueToInt(this.tComboEditor_ListPrcDspDivOd.Value);
                //�d�؉��i�\���敪(����)
                pccCmpnySt.CostDspDivOd = this.ValueToInt(this.tComboEditor_CostDspDivOd.Value);
                //�I�ԕ\���敪(����)
                pccCmpnySt.ShelfDspDivOd = this.ValueToInt(this.tComboEditor_ShelfDspDivOd.Value);
                //�݌ɕ\���敪(����)
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                //pccCmpnySt.StockDspDivOd = this.ValueToInt(this.tComboEditor_StockDspDivOd.Value);
                pccCmpnySt.StockDspDivOd = 1;
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                //�R�����g�\���敪(����)
                pccCmpnySt.CommentDspDivOd = this.ValueToInt(this.tComboEditor_CommentDspDivOd.Value);
                //�o�א��\���敪(����)
                pccCmpnySt.SpmtCntDspDivOd = this.ValueToInt(this.tComboEditor_SpmtCntDspDivOd.Value);
                //�󒍐��\���敪(����)
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                //pccCmpnySt.AcptCntDspDivOd = this.ValueToInt(this.tComboEditor_AcptCntDspDivOd.Value);
                pccCmpnySt.AcptCntDspDivOd = 1;
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
                //���i�I��i�ԕ\���敪(����)
                pccCmpnySt.PrtSelGdNoDspDivOd = this.ValueToInt(this.tComboEditor_PrtSelGdNoDspDivOd.Value);
                //���i�I��W�����i�\���敪(����)
                pccCmpnySt.PrtSelLsPrDspDivOd = this.ValueToInt(this.tComboEditor_PrtSelLsPrDspDivOd.Value);
                //���i�I��I�ԕ\���敪(����)
                pccCmpnySt.PrtSelSelfDspDivOd = this.ValueToInt(this.tComboEditor_PrtSelSelfDspDivOd.Value);
                //���i�I���݌ɕ\���敪(����)
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                //pccCmpnySt.PrtSelStckDspDivOd = this.ValueToInt(this.tComboEditor_PrtSelStckDspDivOd.Value);
                pccCmpnySt.PrtSelStckDspDivOd = 1;
                // UPD 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
                //�q�ɕ\���敪(����)
                pccCmpnySt.WarehouseDspDivOd = this.ValueToInt(this.tComboEditor_WarehouseDspDivOd.Value);
                //����\���敪(����)
                pccCmpnySt.CancelDspDivOd = this.ValueToInt(this.tComboEditor_CancelDspDivOd.Value);
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                //���݌ɐ��\���敪(����)
                pccCmpnySt.PrsntStkCtDspDivOd = Convert.ToInt16(this.tComboEditor_PrsntStkCtDspDivOd.Value);
                //���݌ɐ��\���敪(�⍇��)
                pccCmpnySt.PrsntStkCtDspDiv = Convert.ToInt16(this.tComboEditor_PrsntStkCtDspDiv.Value);
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                // �񓚔[���\���敪(�⍇��)
                pccCmpnySt.AnsDeliDtDspDiv = Convert.ToInt16(this.tComboEditor_AnsDeliDtDspDiv.Value);
                // �񓚔[���\���敪(����)
                pccCmpnySt.AnsDeliDtDspDivOd = Convert.ToInt16(this.tComboEditor_AnsDeliDtDspDivOd.Value);
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
            }
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note		: ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;
           
            return result;
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="saveTarget">�ۑ��}�X�^ (PrdExchPNU/PrdExchPPU)</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note�@�@�@ : PCC���Аݒ�}�X�^�̕ۑ��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private bool SaveProc()
        {
            Control control = null;
            string message = null;

            // �s���f�[�^���̓`�F�b�N
            if (!ScreenDataCheck(ref control, ref message)) {
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message, 							// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                control.Focus();
                return false;
            }

            // PCC���Аݒ�}�X�^�X�V
            if (!SavePccCmpnySt())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^�e�[�u���X�V
        /// </summary>
        /// <return>�X�V����status</return>
        /// <remarks>
        /// <br>Note       : PccCmpnySt�e�[�u���̍X�V���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private bool SavePccCmpnySt()
        {
            Control control = null;
            PccCmpnySt pccCmpnySt = new PccCmpnySt();

            // �o�^���R�[�h���擾
            if (this._detailsIndexBuf >= 0)
            {
                string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pccCmpnySt = ((PccCmpnySt)this._detailsTable[guid]).Clone();
            }

            // PccCmpnySt�N���X�Ƀf�[�^���i�[
            DispToPccCmpnySt(ref pccCmpnySt);
            List<PccCmpnySt> pccCmpnyStList = new  List<PccCmpnySt>();
            pccCmpnyStList.Add(pccCmpnySt);
            // PccCmpnySt�N���X���A�N�Z�X�N���X�ɓn���ēo�^�E�X�V
            int status = this._pccCmpnyStAcs.Write(ref pccCmpnyStList);

            // �G���[����
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet/Hash�X�V����
                    DetailsToDataSet(pccCmpnyStList[0], this._detailsIndexBuf);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // �d������
                    RepeatTransaction(status, ref control);
                    control.Focus();
                    return false;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pccCmpnyStAcs);
                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();
                    return false;
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "SavePccCmpnySt",							  // ��������
                            TMsgDisp.OPE_GET,					  // �I�y���[�V����
                            ERR_TIMEOUT_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._pccCmpnyStAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                        // UI�q��ʋ����I������
                        EnforcedEndTransaction();

                        return false;
                    }
                default:
                    // �o�^���s
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "SavePccCmpnySt",			// ��������
                        TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                        ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._pccCmpnyStAcs,		// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��

                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();

                    return false;
            }

            // �V�K�o�^������
            NewEntryTransaction();
            return true;
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^ �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC���Аݒ�}�X�^�̑Ώۃ��R�[�h���}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private int LogicalDeletePccCmpnySt()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �폜�Ώ�PCC���Аݒ�}�X�^�擾
            string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PccCmpnySt pccCmpnySt = ((PccCmpnySt)this._detailsTable[guid]).Clone();
            this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
            pccCmpnySt.InqOtherEpCd = this._enterpriseCode;
            pccCmpnySt.InqOtherSecCd = this._loginSectionCode;
            pccCmpnySt.InqOriginalEpCd = this._inqOriginalEpCd.Trim();//@@@@20230303
            pccCmpnySt.InqOriginalSecCd = this._inqOriginalSecCd;
            List<PccCmpnySt> pccCmpnyStList = new List<PccCmpnySt>();
            pccCmpnyStList.Add(pccCmpnySt);
            status = this._pccCmpnyStAcs.LogicalDelete(ref pccCmpnyStList);
            pccCmpnySt = pccCmpnyStList[0] as PccCmpnySt;
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet�X�V
                    DetailsToDataSet(pccCmpnySt, _dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_HIDE, this._pccCmpnyStAcs);
                    // �t���[���X�V
                    DetailsToDataSet(pccCmpnyStList[0], _dataIndex);
                    return status;
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "LogicalDeletePccCmpnySt",							  // ��������
                            TMsgDisp.OPE_GET,					  // �I�y���[�V����
                            ERR_TIMEOUT_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._pccCmpnyStAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��
                        // �t���[���X�V
                        DetailsToDataSet(pccCmpnySt, _dataIndex);

                        return status;
                    }
                default:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "LogicalDeletePccCmpnySt",	// ��������
                        TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                        ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._pccCmpnyStAcs,		// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��

                    // �t���[���X�V
                    DetailsToDataSet(pccCmpnySt, _dataIndex);

                    return status;
            }

            return status;
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^ �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC���Аݒ�}�X�^�̑Ώۃ��R�[�h���}�X�^���畨���폜���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private int PhysicalDeleteCampaignRate()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            
            // �폜�Ώ�PCC���Аݒ�}�X�^�擾
            string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PccCmpnySt pccCmpnySt = ((PccCmpnySt)this._detailsTable[guid]).Clone();
            pccCmpnySt.InqOtherEpCd = this._enterpriseCode;
            pccCmpnySt.InqOtherSecCd = this._loginSectionCode;
            pccCmpnySt.InqOriginalEpCd = this._inqOriginalEpCd.Trim();//@@@@20230303
            pccCmpnySt.InqOriginalSecCd = this._inqOriginalSecCd;
            List<PccCmpnySt> pccCmpnyStList = new List<PccCmpnySt>();
            pccCmpnyStList.Add(pccCmpnySt);
            // �����폜
            status = this._pccCmpnyStAcs.Delete(ref pccCmpnyStList);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet�X�V
                    DeleteFromDataSet(pccCmpnyStList[0], _dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._pccCmpnyStAcs);
                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();

                    return status;
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "PhysicalDeleteCampaignRate",							  // ��������
                            TMsgDisp.OPE_GET,					  // �I�y���[�V����
                            ERR_TIMEOUT_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._pccCmpnyStAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��
                        // UI�q��ʋ����I������
                        EnforcedEndTransaction();

                        return status;
                    }
                default:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "PhysicalDeleteCampaignRate",	// ��������
                        TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                        ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._pccCmpnyStAcs,		// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��

                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();

                    return status;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._detailsIndexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            return status;
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^ ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PCC���Аݒ�}�X�^�̑Ώۃ��R�[�h�𕜊����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private int ReviveSharedPartsAddInfo()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // �����Ώ�PCC���Аݒ�}�X�^�擾
            string guid = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PccCmpnySt pccCmpnySt = ((PccCmpnySt)this._detailsTable[guid]).Clone();
            List<PccCmpnySt> pccCmpnyStList = new List<PccCmpnySt>();
            pccCmpnyStList.Add(pccCmpnySt);
            
            // ����
            status = this._pccCmpnyStAcs.RevivalLogicalDelete(ref pccCmpnyStList);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet�W�J����
                    DetailsToDataSet(pccCmpnyStList[0], this._dataIndex);
                    Initial_Timer.Enabled = true;
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pccCmpnyStAcs);
                    return status;
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "ReviveSharedPartsAddInfo",							  // ��������
                            TMsgDisp.OPE_GET,					  // �I�y���[�V����
                            ERR_TIMEOUT_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._pccCmpnyStAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��
                        // PCC�i�ڃN���X�f�[�^�Z�b�g�W�J����
                        return status;
                    }
                default:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "ReviveSharedPartsAddInfo",			// ��������
                        TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                        ERR_RVV_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._pccCmpnyStAcs,		// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��
                    return status;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this.Close();

            return status;
        }

        /// <summary>
        /// �V�K�o�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�K�o�^���̏������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            // �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
            if (this.Mode_Label.Text == INSERT_MODE) 
            {
                // ��ʃN���A����
                ScreenClear();
                // ��ʍč\�z����
                ScreenReconstruction();
            }
            else {
                this.DialogResult = DialogResult.OK;
                this._detailsIndexBuf = -2;

                if (CanClose == true) {
                    this.Close();
                }
                else {
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// UI�q��ʋ����I������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V�G���[����UI�q��ʋ����I���������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void EnforcedEndTransaction()
        {
            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuf = -2;

            if (CanClose == true) {
                this.Close();
            }
            else {
                this.Hide();
            }
        }

        /// <summary>
        /// �d������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="control">�ΏۃR���g���[��</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̏d���������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                ERR_DPR_MSG, 	                    // �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK);				// �\������{�^��
            control = this.tNedit_CustomerCode;
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
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch ( status ) {
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
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
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_DELETE: 
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

        /// <summary>
        /// ��ʂ̃N���A
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̃N���A���s��</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void ClearAll()
        {
            //���Ӑ�R�[�h
            this.tNedit_CustomerCode.SetInt(0);
            //���Ӑ於��
            this.uLabel_CustomerName.Text = string.Empty;
            //PCC���ЃR�[�h
            this.tNedit_PccCompanyCode.SetInt(0);
            //PCC�q�ɃR�[�h
            this.tNedit_PccWarehouseCd.SetInt(0);
            //PCC�D��q�ɃR�[�h1
            this.tNedit_PccPriWarehouseCd1.SetInt(0);
            //PCC�D��q�ɃR�[�h2
            this.tNedit_PccPriWarehouseCd2.SetInt(0);
            //PCC�D��q�ɃR�[�h3
            this.tNedit_PccPriWarehouseCd3.SetInt(0);
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            //PCC�D��q�ɃR�[�h4
            this.tNedit_PccPriWarehouseCd4.SetInt(0);
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            //�i�ԕ\���敪
            this.tComboEditor_GoodsNoDspDiv.SelectedIndex = 0;
            //�W�����i�\���敪
            this.tComboEditor_ListPrcDspDiv.SelectedIndex = 0;
            //�d�؉��i�\���敪
            this.tComboEditor_CostDspDiv.SelectedIndex = 0;
            //�I�ԕ\���敪
            this.tComboEditor_ShelfDspDiv.SelectedIndex = 0;
            //�R�����g�\���敪
            this.tComboEditor_CommentDspDiv.SelectedIndex = 0;
            //�o�א��\���敪
            this.tComboEditor_SpmtCntDspDiv.SelectedIndex = 0;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�󒍐��\���敪
            //this.tComboEditor_AcptCntDspDiv.SelectedIndex = 1;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //���i�I��i�ԕ\���敪
            this.tComboEditor_PrtSelGdNoDspDiv.SelectedIndex = 0;
            //���i�I��W�����i�\���敪
            this.tComboEditor_PrtSelLsPrDspDiv.SelectedIndex = 0;
            //���i�I��I�ԕ\���敪
            this.tComboEditor_PrtSelSelfDspDiv.SelectedIndex = 0;
            //�݌ɏ󋵃R�����g1
            this.tEdit_StckStComment1.Text = "�݌ɂ���";
            //�݌ɏ󋵃R�����g2
            this.tEdit_StckStComment2.Text = "�݌ɂȂ�";
            //�݌ɏ󋵃R�����g3
            this.tEdit_StckStComment3.Text = "�݌ɕs��";
            //PCC�����於��1
            this.tEdit_PccSuplName1.Text = string.Empty;
            //PCC�����於��2
            this.tEdit_PccSuplName2.Text = string.Empty;
            //PCC������J�i����
            this.tEdit_PccSuplKana.Text = string.Empty;
            //PCC�����旪��
            this.tEdit_PccSuplSnm.Text = string.Empty;
            //PCC������X�֔ԍ�
            this.tEdit_PccSuplPostNo.Text = string.Empty;
            //PCC������Z��1
            this.tEdit_PccSuplAddr1.Text = string.Empty;
            //PCC������Z��2
            this.tEdit_PccSuplAddr2.Text = string.Empty;
            //PCC������Z��3
            this.tEdit_PccSuplAddr3.Text = string.Empty;
            //PCC������d�b�ԍ�1
            this.tEdit_PccSuplTelNo1.Text = string.Empty;
            //PCC������d�b�ԍ�2
            this.tEdit_PccSuplTelNo2.Text = string.Empty;
            //PCC������FAX�ԍ�
            this.tEdit_PccSuplFaxNo.Text = string.Empty;
            //�`�[���s�敪�iPCC�j
            this.tComboEditor_PccSlipPrtDiv.SelectedIndex = 0;
            this.TabControl_PccCmpnySt.Tabs[0].Selected = true;
            //�O���Ӑ�R�[�h
            this._customerCodePre = -1;
            //�O���Ӑ於��
            this._customerNamePre = string.Empty;
            this._inqOriginalEpCdPre = string.Empty;
            this._inqOriginalSecCdPre = string.Empty;

            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�݌ɕ\���敪(�⍇��)
            //this.tComboEditor_StockDspDiv.SelectedIndex = 0;
            ////���i�I���݌ɕ\���敪(�⍇��)
            //this.tComboEditor_PrtSelStckDspDiv.SelectedIndex = 0;
            ////���i�I���݌ɕ\���敪(�⍇��)
            //this.tComboEditor_PrtSelStckDspDiv.SelectedIndex = 0;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�q�ɕ\���敪(�⍇��)
            this.tComboEditor_WarehouseDspDiv.SelectedIndex = 0;
            //����\���敪(�⍇��)
            this.tComboEditor_CancelDspDiv.SelectedIndex = 0;
            //�i�ԕ\���敪(����)
            this.tComboEditor_GoodsNoDspDivOd.SelectedIndex = 0;
            //�W�����i�\���敪(����)
            this.tComboEditor_ListPrcDspDivOd.SelectedIndex = 0;
            //�d�؉��i�\���敪(����)
            this.tComboEditor_CostDspDivOd.SelectedIndex = 0;
            //�I�ԕ\���敪(����)
            this.tComboEditor_ShelfDspDivOd.SelectedIndex = 0;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�݌ɕ\���敪(����)
            //this.tComboEditor_StockDspDivOd.SelectedIndex = 0;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�R�����g�\���敪(����)
            this.tComboEditor_CommentDspDivOd.SelectedIndex = 0;
            //�o�א��\���敪(����)
            this.tComboEditor_SpmtCntDspDivOd.SelectedIndex = 0;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////�󒍐��\���敪(����)
            //this.tComboEditor_AcptCntDspDivOd.SelectedIndex = 0;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //���i�I��i�ԕ\���敪(����)
            this.tComboEditor_PrtSelGdNoDspDivOd.SelectedIndex = 0;
            //���i�I��W�����i�\���敪(����)
            this.tComboEditor_PrtSelLsPrDspDivOd.SelectedIndex = 0;
            //���i�I��I�ԕ\���敪(����)
            this.tComboEditor_PrtSelSelfDspDivOd.SelectedIndex = 0;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� ----------------------->>>>>
            ////���i�I���݌ɕ\���敪(����)
            //this.tComboEditor_PrtSelStckDspDivOd.SelectedIndex = 0;
            // DEL 2013/02/17 2013/03/06�z�M �V�X�e���e�X�g��Q�Ή� -----------------------<<<<<
            //�q�ɕ\���敪(����)
            this.tComboEditor_WarehouseDspDivOd.SelectedIndex = 0;
            //����\���敪(����)
            this.tComboEditor_CancelDspDivOd.SelectedIndex = 0;
            //�⍇�������\���敪�ݒ�
            this.tComboEditor_InqOdrDspDivSet.SelectedIndex = 0;
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            // ���݌ɐ��\���敪(�⍇��)
            this.tComboEditor_PrsntStkCtDspDiv.SelectedIndex = 0;
            // ���݌ɐ��\���敪(����)
            this.tComboEditor_PrsntStkCtDspDivOd.SelectedIndex = 0;
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            // �񓚔[���\���敪(�⍇��)
            this.tComboEditor_AnsDeliDtDspDiv.SelectedIndex = 0;
            // �񓚔[���\���敪(����)
            this.tComboEditor_AnsDeliDtDspDivOd.SelectedIndex = 0;
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
        }

        /// <summary>
        /// ���p�{�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���p�{�^���������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void QuoteButtonProc()
        {

            _pMPCC09010UB = new PMPCC09010UB(this._detailsTable);
            string inqCondition = string.Empty;
            this._pMPCC09010UB.ShowDialog();
            DialogResult dialogResult = this._pMPCC09010UB.DialogResult;
            PccCmpnySt parsePccCmpnySt = null;
            int customerCode = this.tNedit_CustomerCode.GetInt();

            if (DialogResult.OK == dialogResult)
            {
                inqCondition = this._pMPCC09010UB.PccInqCondition;
                if (this._detailsTable != null && this._detailsTable.ContainsKey(inqCondition))
                {
                    parsePccCmpnySt = this._detailsTable[inqCondition] as PccCmpnySt;
                }
                if (parsePccCmpnySt != null)
                {
                    // ��ʓW�J����
                    PccCmpnyStToScreenForQuote(parsePccCmpnySt);
                }

            }

        }

        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
        /// <summary>
        ///  �I�v�V�����`�F�b�N�FBLP�Q�Ƒq�ɒǉ��I�v�V����
        /// </summary>
        /// <returns></returns>
        private bool GetBLPPriWareHouseOption()
        {
            PurchaseStatus status = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                 ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_BLPRefWarehouse
            );
            return status.Equals(PurchaseStatus.Contract) ? true : false;
        }
        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<


        # endregion

        # region Control Events

        /// <summary>
        /// Form.Load �C�x���g(PMPCC09010UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void PMPCC09010UA_Load(object sender, System.EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;
            this.UltraButton_Quote.ImageList = imageList25;
            this.SetIconImage(this.UButton_CustomerGuide, Size16_Index.STAR1);
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.UltraButton_Quote.Appearance.Image = Size24_Index.ADJUST;
            this.PictureBox_type();// ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ�
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            this.PictureBox2_type();
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
        }

        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
        /// <summary>
        /// �u�󋵕\���v�̃q���g�\���̐ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: �u�󋵕\���v�̃q���g�\���̐ݒ菈�����܂��B</br>
        /// <br>Programmer	: ���N�n��</br>
        /// <br>Date		: 2014/07/23</br>
        /// </remarks>
        private void PictureBox_type()
        {
            this.pictureBox1.Image
                    = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.pictureBox1.Visible = true;

            UltraToolTipInfo toolTipInfo = this.ultraToolTipManager2.GetUltraToolTip(this.pictureBox1);
            toolTipInfo.Enabled = Infragistics.Win.DefaultableBoolean.True;

            toolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Custom;

            toolTipInfo.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
         
            this.ultraToolTipManager2.Appearance.FontData.SizeInPoints = 11f;
            this.ultraToolTipManager2.Appearance.FontData.Name = "�l�r �S�V�b�N";
            this.ultraToolTipManager2.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.BalloonTip;
            this.ultraToolTipManager2.AutoPopDelay = 0;

    
            toolTipInfo.ToolTipTitleAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            toolTipInfo.ToolTipTitle = "�u�󋵕\���v�ɂ���";

            toolTipInfo.ToolTipText = "\n�����ňȉ��̓��e��\�����܂��B"
                                      + "\n \n���񂹁E�E�E�E���݌ɐ����Ȃ��ꍇ"
                                      + "\n�݌ɕs���E�E�E�E���݌ɐ����⍇���������̏ꍇ"
                                      + "\n�݌Ɏc���E�E�E�E���݌ɐ����݌Ƀ}�X�^�Őݒ肳�ꂽ�Œ�݌ɐ������ɂȂ�ꍇ"
                                      + "\n�݌ɖL�x�E�E�E�E���݌ɐ����݌Ƀ}�X�^�Őݒ肳�ꂽ�Œ�݌ɐ��ȏ�̏ꍇ"
                                      + "\n�Y���Ȃ��E�E�E�E�⍇���ɊY�����镔�i���Ȃ��ꍇ"
                                      + "\n \n \n ";
        
        }
        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<

        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
        /// <summary>
        /// �u�񓚔[���\���敪�v�̃q���g�\���̐ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: �u�񓚔[���\���敪�v�̃q���g�\���̐ݒ菈�����܂��B</br>
        /// <br>Programmer	: 30746 ���� ��</br>
        /// <br>Date		: 2014/09/04</br>
        /// </remarks>
        private void PictureBox2_type()
        {
            this.pictureBox2.Image
                    = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.pictureBox2.Visible = true;

            UltraToolTipInfo toolTipInfo = this.ultraToolTipManager2.GetUltraToolTip(this.pictureBox2);
            toolTipInfo.Enabled = Infragistics.Win.DefaultableBoolean.True;

            toolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Custom;

            toolTipInfo.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            this.ultraToolTipManager2.Appearance.FontData.SizeInPoints = 11f;
            this.ultraToolTipManager2.Appearance.FontData.Name = "�l�r �S�V�b�N";
            this.ultraToolTipManager2.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.BalloonTip;
            this.ultraToolTipManager2.AutoPopDelay = 0;


            toolTipInfo.ToolTipTitleAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            toolTipInfo.ToolTipTitle = "�u�񓚔[���\���敪�v�ɂ���";

            toolTipInfo.ToolTipText = "\n�uCarpodTab �Ԍ��R�[�X��ăT�[�r�X�v�݂̂ɓK�p����܂��B";

        }
        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

        /// <summary>
        /// Form.Closing �C�x���g(PMPCC09010UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void PMPCC09010UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._detailsIndexBuf = -2;

            // �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
            if ( CanClose == false ) {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Control.VisibleChanged �C�x���g(PMPCC09010UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void PMPCC09010UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                // ���C���t���[���A�N�e�B�u��
                this.Owner.Activate();

                return;
            }

            // �������g����\���ɂȂ����ꍇ�A
            // �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
            if (this._detailsIndexBuf == this._dataIndex)
            {
                return;
            }
            
            // ��ʍč\�z����
            
            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // �o�^����
            SaveProc();
        }

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            bool cloneFlg = true;

            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if ( this.Mode_Label.Text != DELETE_MODE ) {
                // ���݂̉�ʏ����擾
                PccCmpnySt pccCmpnySt = new PccCmpnySt();
                pccCmpnySt = this._pccCmpnySt.Clone();
                DispToPccCmpnySt(ref pccCmpnySt);
                // �ŏ��Ɏ擾������ʏ��Ɣ�r
                cloneFlg = this._pccCmpnySt.Equals(pccCmpnySt);

                if ( !( cloneFlg ) ) {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    DialogResult res = TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "",									// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);		// �\������{�^��

                    switch ( res ) {
                        case DialogResult.Yes:
                            if (SaveProc()) {
                                this.DialogResult = DialogResult.OK;
                                break;
                            }
                            else {
                                return;
                            }
                        case DialogResult.No: 
                            this.DialogResult = DialogResult.Cancel;
                            break;
                        default:
                            if (_modeFlg)
                            {
                                this.tNedit_CustomerCode.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            return;
                    }
                }
            }

            if ( UnDisplaying != null ) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuf = -2;

            if ( CanClose == true ) {
                this.Close();
            }
            else {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION, // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                //MessageBoxButtons.OKCancel,
                //MessageBoxDefaultButton.Button2);	// �\������{�^��
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);	// �\������{�^��

            if ( result == DialogResult.Yes ) {
                // PCC���Аݒ�}�X�^�����폜
                PhysicalDeleteCampaignRate();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            ReviveSharedPartsAddInfo();
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���p�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void UltraButton_Quote_Click(object sender, EventArgs e)
        {
            this.QuoteButtonProc();
        }

        /// <summary>
        /// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					 ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					 �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        /// tArrowKeyControlChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[���̃t�H�[�J�X���ς��^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            _modeFlg = false;
            int customerCode = this.tNedit_CustomerCode.GetInt();
            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CustomerCode":
                    if (_customerCodePre != customerCode)
                    {
                        // PCC���Аݒ�}�X�^�����e�R�[�h�R�[�h�Ƀt�H�[�J�X������ꍇ
                        if (customerCode != 0)
                        {
                            if (e.NextCtrl.Name == "Cancel_Button")
                            {
                                // �J�ڐ悪����{�^��
                                _modeFlg = true;
                            }
                            else
                            {
                                //���Ӑ�����擾
                                CustomerInfo customerInfo;
                                int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, customerCode);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.IsCustomer)
                                {
                                    //�O�⍇������ƃR�[�h
                                    this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                                    //�O�⍇�������_�R�[�h
                                    this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                                    if (customerInfo.OnlineKindDiv == ONLINEKINDDIV)
                                    {
                                        if (ModeChangeProc(customerInfo))
                                        {
                                            if (this._dataIndex < 0 && this.tNedit_CustomerCode.GetInt() == 0)
                                            {
                                                e.NextCtrl = tNedit_CustomerCode;
                                            }
                                        }
                                        else
                                        {
                                            //�⍇������ƃR�[�h
                                            this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                                            //�⍇�������_�R�[�h
                                            this._inqOriginalSecCd = customerInfo.CustomerSecCode.TrimEnd();
                                            this.uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();
                                            this.tNedit_PccCompanyCode.SetInt(customerCode);
                                            //�O�⍇������ƃR�[�h
                                            this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                                            //�O�⍇�������_�R�[�h
                                            this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                                            //�O���Ӑ�R�[�h
                                            this._customerCodePre = customerCode;
                                            //�O���Ӑ於��
                                            this._customerNamePre = customerInfo.CustomerSnm.TrimEnd();
                                        }
                                    }
                                    else
                                    {
                                        // �G���[��
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "���Ӑ�R�[�h [" + customerInfo.CustomerCode + "] �͐ݒ�ł��܂���B\r\n�I�����C�������m�F���ĉ������B",
                                            -1,
                                            MessageBoxButtons.OK);
                                        if (this._customerCodePre == -1)
                                        {
                                            this.tNedit_PccCompanyCode.SetInt(0);
                                        }
                                        else
                                        {
                                            this.tNedit_PccCompanyCode.SetInt(this._customerCodePre);
                                        }
                                        e.NextCtrl = tNedit_CustomerCode;
                                    }
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                         this, 								// �e�E�B���h�E�t�H�[��
                                         emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                                         ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                                         "�}�X�^�ɓo�^����Ă��܂���B", 							// �\�����郁�b�Z�[�W
                                         0, 									// �X�e�[�^�X�l
                                         MessageBoxButtons.OK);				// �\������{�^��
                                    e.NextCtrl = tNedit_CustomerCode;
                                    if (this._customerCodePre == -1)
                                    {
                                        this.tNedit_PccCompanyCode.SetInt(0);
                                    }
                                    else
                                    {
                                        this.tNedit_PccCompanyCode.SetInt(this._customerCodePre);
                                    }
                                }

                            }
                        }
                        else
                        {
                           //���Ӑ�����擾
                            CustomerInfo customerInfo = new CustomerInfo();
                            customerInfo.CustomerSnm = CUSTOMEMPTY_BASE;
                            customerInfo.CustomerEpCode = string.Empty;
                            customerInfo.CustomerSecCode = string.Empty;
                            if (ModeChangeProc(customerInfo))
                            {
                                if (this._dataIndex < 0)
                                {
                                    e.NextCtrl = tNedit_CustomerCode;
                                }
                            }
                            else
                            {
                                //�⍇������ƃR�[�h
                                this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                                //�⍇�������_�R�[�h
                                this._inqOriginalSecCd = customerInfo.CustomerSecCode.TrimEnd();
                                this.uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();
                                this.tNedit_PccCompanyCode.SetInt(customerCode);
                                //�O�⍇������ƃR�[�h
                                this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                                //�O�⍇�������_�R�[�h
                                this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                                //�O���Ӑ�R�[�h
                                this._customerCodePre = customerCode;
                                //�O���Ӑ於��
                                this._customerNamePre = customerInfo.CustomerSnm.TrimEnd();
                            }
                           
                        }
                    }
                    break;
                //-----ADD by huanghx for #24894 on 20110913----->>>>>
                //���Ӑ�K�C�h
                case "UButton_CustomerGuide":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = UButton_CustomerGuide;
                        }
                        break;
                    }
                case "TabControl_PccCmpnySt":
                    {
                        if (e.Key == Keys.Up)
                        {
                            e.NextCtrl = tNedit_CustomerCode;
                        }
                        break;
                    }
                //���p
                case "UltraButton_Quote":
                    {
                        switch (TabControl_PccCmpnySt.SelectedTab.Key)
                        {
                            case "firstTab":
                                {
                                    if (e.Key == Keys.Left)
                                    {
                                        // UPD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                                        //e.NextCtrl = tNedit_PccPriWarehouseCd3;
                                        if (this._optionBLPPriWareHouse)
                                        {
                                            e.NextCtrl = tNedit_PccPriWarehouseCd4;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tNedit_PccPriWarehouseCd3;
                                        }
                                        // UPD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                                    }
                                    break;
                                }
                            case "secondTab":
                                {
                                    if (e.Key == Keys.Left)
                                    {
                                        e.NextCtrl = tEdit_PccSuplFaxNo;
                                    }
                                    break;
                                }
                            case "thirdTab":
                                {
                                    if (e.Key == Keys.Left)
                                    {
                                        e.NextCtrl = tEdit_StckStComment3;
                                    }
                                    break;
                                }
                        }
                        break;
                    }
               //�`�[���s�敪
                case "tComboEditor_PccSlipPrtDiv":
                    {
                        if (e.Key == Keys.Left)
                        {
                            e.NextCtrl = tComboEditor_PccSlipPrtDiv;
                        }
                        break;
                    }
                //PCC���Бq�ɃR�[�h
                case "tNedit_PccWarehouseCd":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = tNedit_PccWarehouseCd;
                        }
                        break;
                    }
                //�D��q��1
                case "tNedit_PccPriWarehouseCd1":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = tNedit_PccPriWarehouseCd1;
                        }
                        break;
                    }
                //�D��q��2
                case "tNedit_PccPriWarehouseCd2":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = tNedit_PccPriWarehouseCd2;
                        }
                        break;
                    }
                //�D��q��3
                case "tNedit_PccPriWarehouseCd3":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = tNedit_PccPriWarehouseCd3;
                        }
                        break;
                    }
                //-----ADD by huanghx for #24894 on 20110913-----<<<<<
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                //�D��q��4
                case "tNedit_PccPriWarehouseCd4":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = tNedit_PccPriWarehouseCd4;
                        }
                        break;
                    }
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                default:
                    break;
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h�{�^���N���b�N�C�x���g�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void UButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // ���Ӑ�K�C�h�\��

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY, PMKHN04005UA.PCCUOE_CMPNYST_ONLY);
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
        /// <br>Note       : ���Ӑ�K�C�h�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
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
                        if (ModeChangeProc(customerInfo))
                        {

                        }
                        else
                        {
                            //���Ӑ����UI�ɐݒ�
                            //�⍇������ƃR�[�h
                            this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                            //�⍇�������_�R�[�h
                            this._inqOriginalSecCd = customerInfo.CustomerSecCode.TrimEnd();
                            //�O�⍇������ƃR�[�h
                            this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                            //�O�⍇�������_�R�[�h
                            this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                        
                            tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
                            tNedit_PccCompanyCode.SetInt(customerInfo.CustomerCode);
                            uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();
                            TabControl_PccCmpnySt.Tabs[0].Selected = true;
                            //�O���Ӑ�R�[�h
                            this._customerCodePre = customerInfo.CustomerCode;
                            //�O���Ӑ於��
                            this._customerNamePre = customerInfo.CustomerSnm.TrimEnd();
                        }
                       
                        return;
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

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note		: �{�^���A�C�R���ݒ菈�����s��</br>
        /// <br>Programmer	: ���C��</br>
        /// <br>Date		: 2010.11.20</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }

        #endregion

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        /// <param name="pccInqCondition">�₹����</param>
        /// <param name="customerInfo">���Ӑ���</param>
        /// <remarks>
        /// <br>Note       : ���[�h�ύX�������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private bool ModeChangeProc(CustomerInfo customerInfo)
        {
            // PCC���Аݒ�}�X�^�����e�R�[�h
            int customerCode = this.tNedit_CustomerCode.GetInt();

            string pccInqCondition = customerInfo.CustomerEpCode.TrimEnd() + customerInfo.CustomerSecCode.TrimEnd()
                + this._enterpriseCode.TrimEnd() + this._loginSectionCode.TrimEnd();
            bool exsit = false;
            for (int i = 0; i < this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string pccInqConditionPre = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][DETAILS_GUID_KEY];
                int customerCodePre = (Int32)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][PCCCOMPANYCODE_TITLE];

                if (pccInqConditionPre.Equals(pccInqCondition))
                {
                    exsit = true;
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][DELETE_DATE_TITLE] != "")
                    {
                        // �_���폜
                        if (customerInfo.CustomerCode == 0)
                        {
                            TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                              emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                              ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                //"�x�[�X�ݒ��PCC���Аݒ�}�X�^���͊��ɍ폜����Ă��܂��B", 	// �\�����郁�b�Z�[�W�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                             "�x�[�X�ݒ��BL�߰µ��ް���Аݒ�}�X�^���͊��ɍ폜����Ă��܂��B", //ADD BY wujun FOR Redmine#25173 ON 2011.09.15�@ 
                              0, 									// �X�e�[�^�X�l
                              MessageBoxButtons.OK);				// �\������{�^��
                        }
                        else
                        {
                            TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                             emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                             ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                //"���͂��ꂽ�R�[�h��PCC���Аݒ�}�X�^���͊��ɍ폜����Ă��܂��B", �@// �\�����郁�b�Z�[�W�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                             "���͂��ꂽ�R�[�h��BL�߰µ��ް���Аݒ�}�X�^���͊��ɍ폜����Ă��܂��B",  //ADD BY wujun FOR Redmine#25173 ON 2011.09.15�@
                             0, 									// �X�e�[�^�X�l
                             MessageBoxButtons.OK);				// �\������{�^��
                        }
                        // PCC���Аݒ�}�X�^�����e�R�[�h�̃N���A
                        if (this._customerCodePre == -1)
                        {
                            this.tNedit_PccCompanyCode.SetInt(0);
                        }
                        else
                        {
                            this.tNedit_PccCompanyCode.SetInt(this._customerCodePre);
                        }
                        this.uLabel_CustomerName.Text = this._customerNamePre;
                        //�⍇������ƃR�[�h
                        this._inqOriginalEpCd = this._inqOriginalEpCdPre.Trim();//@@@@20230303
                        //�⍇�������_�R�[�h
                        this._inqOriginalSecCd = this._inqOriginalSecCdPre;
                        return true;
                    }
                    //�V�K�ꍇ�A�X�V�ꍇ
                    DialogResult res = DialogResult.No;
                    if (customerInfo.CustomerCode == 0)
                    {
                        res = TMsgDisp.Show(
                       this,                                   // �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_QUESTION,            // �G���[���x��
                       ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                       //"�x�[�X�ݒ��PCC���Џ��͊��ɓo�^����Ă��܂��B�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15
                       "�x�[�X�ݒ��BL�߰µ��ް���Џ��͊��ɓo�^����Ă��܂��B�ҏW���s���܂����H",  �@//ADD BY wujun FOR Redmine#25173 ON 2011.09.15�@
                       0,                                      // �X�e�[�^�X�l
                       MessageBoxButtons.YesNo);               // �\������{�^��
                    }
                    else
                    {
                        res = TMsgDisp.Show(
                       this,                                   // �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_QUESTION,            // �G���[���x��
                       ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            //"���͂��ꂽ���Ӑ��PCC���Џ��͊��ɓo�^����Ă��܂��B�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15
                       "���͂��ꂽ���Ӑ��BL�߰µ��ް���Џ��͊��ɓo�^����Ă��܂��B�ҏW���s���܂����H",  �@//ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                       0,                                      // �X�e�[�^�X�l
                       MessageBoxButtons.YesNo);               // �\������{�^��
                    }
                   
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                ScreenReconstruction();
                                this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
                                this.tNedit_PccCompanyCode.SetInt(customerInfo.CustomerCode);
                                this.uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();
                                //�⍇������ƃR�[�h
                                this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                                //�⍇�������_�R�[�h
                                this._inqOriginalSecCd = customerInfo.CustomerSecCode.TrimEnd();
                                //�O���Ӑ�R�[�h
                                this._customerCodePre = customerInfo.CustomerCode;
                                //�O���Ӑ於��
                                this._customerNamePre = customerInfo.CustomerSnm.TrimEnd();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // �R�[�h�̃N���A
                                if (this._customerCodePre == -1)
                                {
                                    this.tNedit_CustomerCode.SetInt(0);
                                }
                                else
                                {
                                    this.tNedit_CustomerCode.SetInt(this._customerCodePre);
                                }
                                this.uLabel_CustomerName.Text = this._customerNamePre;
                                //�⍇������ƃR�[�h
                                this._inqOriginalEpCd = this._inqOriginalEpCdPre.Trim();//@@@@20230303
                                //�⍇�������_�R�[�h
                                this._inqOriginalSecCd = this._inqOriginalSecCdPre;
                                break;
                            }
                    }
                    return true;
                }

            }
            if (!exsit && this._dataIndex >= 0)
            {
                DialogResult res = DialogResult.No;
                if (customerInfo.CustomerCode == 0)
                {
                    res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_QUESTION,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        //"�x�[�X�ݒ��PCC���Аݒ�}�X�^��񂪑��݂��܂���B\n�V�K�o�^���s���܂����H",   // �\�����郁�b�Z�[�W�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                        "�x�[�X�ݒ��BL�߰µ��ް���Аݒ�}�X�^��񂪑��݂��܂���B\n�V�K�o�^���s���܂����H",�@//ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                }
                else
                {
                    res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_QUESTION,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        //"���͂��ꂽ�R�[�h��PCC���Аݒ�}�X�^��񂪑��݂��܂���B\n�V�K�o�^���s���܂����H",   // �\�����郁�b�Z�[�W�@//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                        "���͂��ꂽ�R�[�h��BL�߰µ��ް���Аݒ�}�X�^��񂪑��݂��܂���B\n�V�K�o�^���s���܂����H",  �@//ADD BY wujun FOR Redmine#25173 ON 2011.09.15
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                }
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            // ��ʍĕ`��
                            this._dataIndex = -1;
                            ScreenReconstruction();
                            this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
                            this.tNedit_PccCompanyCode.SetInt(customerInfo.CustomerCode);
                            this.uLabel_CustomerName.Text = customerInfo.CustomerSnm;
                            //�⍇������ƃR�[�h
                            this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                            //�⍇�������_�R�[�h
                            this._inqOriginalSecCd = customerInfo.CustomerSecCode;
                            //�O���Ӑ�R�[�h
                            this._customerCodePre = customerInfo.CustomerCode;
                            //�O���Ӑ於��
                            this._customerNamePre = customerInfo.CustomerSnm.TrimEnd();
                            break;
                        }
                    case DialogResult.No:
                        {
                            // �R�[�h�̃N���A
                            if (this._customerCodePre == -1)
                            {
                                this.tNedit_CustomerCode.SetInt(0);
                            }
                            else
                            {
                                this.tNedit_CustomerCode.SetInt(this._customerCodePre);
                            }
                            this.uLabel_CustomerName.Text = this._customerNamePre;
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
        /// KeyPress �C�x���g(grdPaymentKind)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �O���b�h���Key�������ꂽ�Ƃ��ɔ������܂��B </br>
        /// <br>Programmer  : ���C��</br>
        /// <br>Date        : 2011.08.04 </br>
        /// </remarks>
        private void Name_tEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            TEdit nametEdit = (TEdit)sender;
            if (!nametEdit.Focused)
            {
                return;
            }
            if (!nametEdit.IsInEditMode)
            {
                return;
            }

            // �S�p�ȊO�́A�m�f
            int length = System.Text.Encoding.Default.GetByteCount(e.KeyChar.ToString());
            if ((byte)e.KeyChar == (byte)'\b' || e.KeyChar == (char)3 || e.KeyChar == (char)22) //ADD �BCTRL+�uC�v�ACTRL+�uV�v
            {
                return;
            }


            if (length == 2)
            {
                e.KeyChar = '\0';
                e.Handled = true;
                return;
            }
        }
        # endregion

        // ADD 2013/02/12 SCM��Q��10342,10343�Ή� -------------------------------------------->>>>>
        /// <summary>
        /// ValueChanged �C�x���gInqOdrDspDivSet)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �⍇�������\���敪���I�����ꂽ�Ƃ��ɔ������܂��B </br>
        /// <br>Programmer  : </br>
        /// <br>Date        : </br>
        /// </remarks>
        private void tComboEditor_InqOdrDspDivSet_ValueChanged(object sender, EventArgs e)
        {
            // ���͕␳
            if (this.tComboEditor_InqOdrDspDivSet.Value == null)
            {
                this.tComboEditor_InqOdrDspDivSet.Value = 0;
            }
            // �V�K�o�^�̎�
            if (this._dataIndex < 0)
            {
                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);
            }
            // �폜�̏ꍇ
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(DELETE_MODE);
            }
            // �X�V�̏ꍇ
            else
            {
                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(UPDATE_MODE);
            }
        }

        private void ultraLabel44_Click(object sender, EventArgs e)
        {

        }
        // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
    }
}
