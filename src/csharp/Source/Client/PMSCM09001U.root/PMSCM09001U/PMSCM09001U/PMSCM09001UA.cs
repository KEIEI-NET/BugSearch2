//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : SCM�i�ڐݒ�}�X�^�����e�i���X
// �v���O�����T�v   : SCM�i�ڐݒ�}�X�^�̑�����s���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� ���b
// �� �� ��  2009/05/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCM�i�ڐݒ�}�X�^�����e�i���XUI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : SCM�i�ڐݒ�}�X�^�����e�i���XUI�t�H�[���N���X</br>
    /// <br>Programmer  : 22018 ��� ���b</br>
    /// <br>Date        : 2009/05/12</br>
    /// </remarks>
    public partial class PMSCM09001UA : Form
    {
        #region �� Constants

        // �A�Z���u��ID
        private const string ASSEMBLY_ID = "PMSCM09001U";

        // ��ʏ�ԕۑ��p�t�@�C����
        private const string XML_FILE_INITIAL_DATA = "PMSCM09001U.dat";

        // �O���b�h��
        public const string COLUMN_NO = "No";

        private const string FORMAT = "N";

        private const string ERRORMSG_RANGE = "{0}�͈̔͂Ɍ�܂肪����܂�";

        #endregion �� Constants


        #region �� Private Members

        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode;

        private SCMPrtSettingAcs _scmPrtSettingAcs; // SCM�i�ڐݒ�}�X�^�����e�i���X�A�N�Z�X�N���X
        private SCMPrtSettingGuideControl _guideControl; // SCM�i�ڐݒ�}�X�����K�C�h����N���X

        private PMSCM09001UB _editForm; // �ҏWUI

        // �O���b�h�ݒ萧��N���X
        private GridStateController _gridStateController;

        // ���o����
        private SCMPrtSettingOrder _extrInfo;

        private bool _closeFlg;

        #endregion �� Private Members


        #region �� Constructor

        /// <summary>
        /// SCM�i�ڐݒ�}�X�^�����e�i���XUI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : SCM�i�ڐݒ�}�X�^�����e�i���XUI�t�H�[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        public PMSCM09001UA()
		{
			InitializeComponent();
            
            this._controlScreenSkin = new ControlScreenSkin();
            
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �K�C�h����
            _guideControl = new SCMPrtSettingGuideControl( _enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim() );
            _guideControl.AfterRenewal += new EventHandler( GuideControl_AfterRenewal );

            this._scmPrtSettingAcs = new SCMPrtSettingAcs();
            this._scmPrtSettingAcs.AfterTableUpdate += new EventHandler( SCMPrtSettingAcs_AfterTableUpdate );

            this._gridStateController = new GridStateController();

            // ��ʏ����ݒ�
            SetInitialSetting();

            // ��ʃN���A
            ClearScreen();
        }
        #endregion �� Constructor


        #region �� Private Methods

        #region XML����
        /// <summary>
        /// �w�l�k�f�[�^�̓Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ�ԕێ��p�̂w�l�k�̓Ǎ��������s���܂��B</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2009/05/12</br>
        /// </remarks>
        private void LoadStateXmlData()
        {
            int status = this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
            if (status == 0)
            {
                GridStateController.GridStateInfo gridStateInfo = this._gridStateController.GetGridStateInfo(ref this.uGrid_Details);
                if (gridStateInfo != null)
                {
                    // �t�H���g�T�C�Y
                    this.tComboEditor_GridFontSize.Value = (int)gridStateInfo.FontSize;
                    // ��̎�������
                    this.uCheckEditor_AutoFillToColumn.Checked = gridStateInfo.AutoFit;
                }
                else
                {
                    status = 4;
                }
            }
            if (status != 0)
            {
                // �t�H���g�T�C�Y
                this.tComboEditor_GridFontSize.Value = 11;
                // ��̎�������
                this.uCheckEditor_AutoFillToColumn.Checked = false;
            }
        }

        /// <summary>
        /// �w�l�k�f�[�^�̕ۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ�ԕێ��p�̂w�l�k�̕ۑ��������s���܂��B</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2009/05/12</br>
        /// </remarks>
        public void SaveStateXmlData()
        {
            if (this.uCheckEditor_AutoFillToColumn.Checked)
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            }
            // �O���b�h����ۑ�
            this._gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }
        #endregion XML����

        #region ���̎擾
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sectionName">���_��</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : ���_�R�[�h�ɊY�����鋒�_���̂��擾���܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private bool GetSectionName( string sectionCode, out string sectionName )
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');

            if (sectionCode == "00")
            {
                sectionName = "�S��";
                return true;
            }

            if ( this._guideControl.SecInfoSetDic.ContainsKey( sectionCode ) )
            {
                sectionName = this._guideControl.SecInfoSetDic[sectionCode].SectionGuideNm.Trim();
                return true;
            }
            else
            {
                sectionName = string.Empty;
                return false;
            }
        }
        #endregion ���̎擾

        #region �����ݒ�
        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��̏����ݒ���s���܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void SetInitialSetting()
        {
            //---------------------------------
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            //---------------------------------
            // �X�L���ύX���O�ݒ�
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.Standard_UGroupBox.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);


            //---------------------------------
            // �A�C�R���ݒ�
            //---------------------------------
            this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            LabelTool labelTool;
            labelTool = (LabelTool)this.tToolbarsManager_MainMenu.Tools["Section_LabelTool"];
            labelTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            labelTool = (LabelTool)this.tToolbarsManager_MainMenu.Tools["LoginCaption_LabelTool"];
            labelTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            ButtonTool workButton;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Renewal"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;

            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Insert"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Edit"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EDITING;


            // ���_��
            ToolBase sectionName = tToolbarsManager_MainMenu.Tools["SectionName_LabelTool"];
            if (sectionName != null && LoginInfoAcquisition.Employee != null)
            {
                string name;
                GetSectionName( LoginInfoAcquisition.Employee.BelongSectionCode, out name );
                sectionName.SharedProps.Caption = name;
            }

            // ���O�C����
            ToolBase loginName = tToolbarsManager_MainMenu.Tools["LoginName_LabelTool"];
            if (loginName != null && LoginInfoAcquisition.Employee != null)
            {
                loginName.SharedProps.Caption = LoginInfoAcquisition.Employee.Name.Trim();
            }

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.uButton_SectionCodeAllowZero.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerCode_St.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerCode_Ed.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_SupplierCd_St.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_SupplierCd_Ed.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMakerCd_St.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMakerCd_Ed.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMGroup_St.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMGroup_Ed.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_BLGloupCode_St.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_BLGloupCode_Ed.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_BLGoodsCode_St.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_BLGoodsCode_Ed.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            //---------------------------------
            // �O���b�h�ݒ�
            //---------------------------------
            CreateGrid(ref this.uGrid_Details);
        }
        #endregion �����ݒ�

        #region �N���A����
        /// <summary>
        /// ��ʏ��N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ����N���A���܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void ClearScreen()
        {
            // �Ώۋ敪
            this.tComboEditor_TargetDivide.Value = 0;

            // ���_
            this.tEdit_SectionCodeAllowZero.Clear();
            this.tEdit_SectionName.Clear();
            // ���Ӑ�R�[�h
            this.tNedit_CustomerCode_St.Clear();
            this.tNedit_CustomerCode_Ed.Clear();
            // �d����R�[�h
            this.tNedit_SupplierCd_St.Clear();
            this.tNedit_SupplierCd_Ed.Clear();
            // ���[�J�[�R�[�h
            this.tNedit_GoodsMakerCd_St.Clear();
            this.tNedit_GoodsMakerCd_Ed.Clear();
            // ���i�����ރR�[�h
            this.tNedit_GoodsMGroup_St.Clear();
            this.tNedit_GoodsMGroup_Ed.Clear();
            // �O���[�v�R�[�h
            this.tNedit_BLGloupCode_St.Clear();
            this.tNedit_BLGloupCode_Ed.Clear();
            // �a�k�R�[�h
            this.tNedit_BLGoodsCode_St.Clear();
            this.tNedit_BLGoodsCode_Ed.Clear();

            // �X�N���[���|�W�V����������
            this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();

            // �O���b�h�N���A
            ClearGrid();

            // �t�H�[�J�X�ݒ�
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        /// <summary>
        /// �O���b�h����������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �O���b�h�����������s���܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void ClearGrid()
        {
            // �O���b�h�쐬����
            CreateGrid(ref this.uGrid_Details);
            // �L�[�}�b�s���O�ݒ�
            MakeKeyMappingForGrid( this.uGrid_Details );
        }
        #endregion �N���A����

        #region �ۑ�
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ۑ��������s���܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private int Save()
        {
            tComboEditor_TargetDivide.Focus();

            # region [�X�V���R�[�h�L���`�F�b�N]
            if ( _scmPrtSettingAcs.GetUpdateCountFromTable() == 0 )
            {
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                    "�X�V�Ώۂ̃f�[�^�����݂��܂���",// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK );				// �\������{�^��
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            # endregion

            // �X�V����
            string errMsg;
            int status = _scmPrtSettingAcs.WriteAll( out errMsg );

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        //// �Č���
                        //this.Search();

                        // �o�^�����_�C�A���O�\��
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog( 2 );

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        if ( status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE )
                        {
                            errMsg = "���ɑ��[�����X�V����Ă��܂��B";
                        }
                        else
                        {
                            errMsg = "���ɑ��[�����폜����Ă��܂��B";
                        }

                        ShowMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "Save",
                                       errMsg,
                                       status,
                                       MessageBoxButtons.OK );

                        this.tEdit_SectionCodeAllowZero.Focus();
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox( emErrorLevel.ERR_LEVEL_STOP,
                                   "Save",
                                   "�ۑ������Ɏ��s���܂����B",
                                   status,
                                   MessageBoxButtons.OK );

                        this.tEdit_SectionCodeAllowZero.Focus();
                        return (status);
                    }
            }

            return (status);
        }
        #endregion �ۑ�

        #region ����
        /// <summary>
        /// ��������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �����������s���܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private int Search()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // ��ʏ���r
            if ( !CompareScreen() )
            {
                return status;
            }

            // �����������̓`�F�b�N
            bool bStatus = CheckSearchCondition();
            if (!bStatus)
            {
                return -1;
            }

            // ���������i�[
            if ( _extrInfo == null )
            {
                _extrInfo = new SCMPrtSettingOrder();
            }
            SCMPrtSettingOrder extrInfoClone = _extrInfo.Clone();
            SetExtrInfo(out this._extrInfo);
            ArrayList compareList = _extrInfo.Compare( extrInfoClone );
            if ( compareList == null || compareList.Count == 0 )
            {
                // �������ς��Ȃ��̂ŏI��
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                return status;
            }

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "���o��";
            msgForm.Message = "SCM�i�ڐݒ�}�X�^�̒��o���ł��B";

            string msg;

            try
            {
                msgForm.Show();

                // ��������
                status = this._scmPrtSettingAcs.Search( _extrInfo, out msg );
                if (status == 0)
                {
                    // �O���b�h�f�[�^�ݒ�
                    CreateGrid(ref this.uGrid_Details);

                    // �O���b�h�s�J���[�ݒ�
                    SettingGridRows(ref this.uGrid_Details);

                    return (status);
                }
            }
            finally
            {
                msgForm.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "���������ɊY������f�[�^�����݂��܂���B",
                                       status,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);

                        // �O���b�h�N���A
                        ClearGrid();

                        // �t�H�[�J�X�ړ�
                        tComboEditor_TargetDivide.Focus();

                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Search",
                                       "���������Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        // �O���b�h�N���A
                        ClearGrid();

                        // �t�H�[�J�X�ړ�
                        tComboEditor_TargetDivide.Focus();

                        return (status);
                    }
            }
        }

        /// <summary>
        /// ���������ݒ菈��
        /// </summary>
        /// <param name="para">��������</param>
        /// <remarks>
        /// <br>Note        : ��ʏ�񂩂猟��������ݒ肵�܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void SetExtrInfo(out SCMPrtSettingOrder para)
        {
            para = new SCMPrtSettingOrder();

            // ��ƃR�[�h
            para.EnterpriseCode = this._enterpriseCode;

            // ���_�E���Ӑ�
            switch ( (int)this.tComboEditor_TargetDivide.Value )
            {
                // �S��
                default:
                case 0:
                    {
                        para.SectionCode = null;
                        para.St_CustomerCode = 0;
                        para.Ed_CustomerCode = 0;
                    }
                    break;
                // ���_
                case 1:
                    {
                        para.SectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft( 2, '0' );
                        para.St_CustomerCode = 0;
                        para.Ed_CustomerCode = 0;
                    }
                    break;
                // ���Ӑ�
                case 2:
                    {
                        para.SectionCode = null;
                        para.St_CustomerCode = tNedit_CustomerCode_St.GetInt();
                        para.Ed_CustomerCode = tNedit_CustomerCode_Ed.GetInt();

                        // ���Ӑ�ݒ蕪���擾���邽�߁A1�ȏ�ɂ���
                        if ( para.St_CustomerCode == 0 )
                        {
                            para.St_CustomerCode = 1;
                        }
                    }
                    break;
            }

            // �d����
            para.St_SupplierCd = tNedit_SupplierCd_St.GetInt();
            para.Ed_SupplierCd = tNedit_SupplierCd_Ed.GetInt();
            //if ( para.Ed_SupplierCd != 0 ) para.St_SupplierCd = 1;
            // ���[�J�[
            para.St_GoodsMakerCd = tNedit_GoodsMakerCd_St.GetInt();
            para.Ed_GoodsMakerCd = tNedit_GoodsMakerCd_Ed.GetInt();
            //if ( para.Ed_GoodsMakerCd != 0 ) para.St_GoodsMakerCd = 1;
            // ���i������
            para.St_GoodsMGroup = tNedit_GoodsMGroup_St.GetInt();
            para.Ed_GoodsMGroup = tNedit_GoodsMGroup_Ed.GetInt();
            //if ( para.Ed_GoodsMGroup != 0 ) para.St_GoodsMGroup = 1;
            // �O���[�v
            para.St_BLGroupCode = tNedit_BLGloupCode_St.GetInt();
            para.Ed_BLGroupCode = tNedit_BLGloupCode_Ed.GetInt();
            //if ( para.Ed_BLGroupCode != 0 ) para.St_BLGroupCode = 1;
            // �a�k�R�[�h
            para.St_BLGoodsCode = tNedit_BLGoodsCode_St.GetInt();
            para.Ed_BLGoodsCode = tNedit_BLGoodsCode_Ed.GetInt();
            //if ( para.Ed_BLGoodsCode != 0 ) para.St_BLGoodsCode = 1;
        }
        #endregion ����

        #region �`�F�b�N����
        /// <summary>
        /// ���������`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �����������`�F�b�N���܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private bool CheckSearchCondition()
        {
            string errMsg = "";

            try
            {
                // 1:���_�̏ꍇ�̂�
                if ( (int)tComboEditor_TargetDivide.Value == 1 )
                {
                    // ���_
                    if ( this.tEdit_SectionCodeAllowZero.DataText.Trim() == "" )
                    {
                        errMsg = "���_����͂��Ă��������B";
                        this.tEdit_SectionCodeAllowZero.Focus();
                        return (false);
                    }

                    string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();
                }

                //--------------------------------------------------
                // �召��r
                //--------------------------------------------------

                // ���Ӑ�
                if ( CheckInputRange( tNedit_CustomerCode_St, tNedit_CustomerCode_Ed ) == false )
                {
                    errMsg = string.Format( ERRORMSG_RANGE, "���Ӑ�" );
                    this.tNedit_CustomerCode_St.Focus();
                    return (false);
                }
                // �d����
                if ( CheckInputRange( tNedit_SupplierCd_St, tNedit_SupplierCd_Ed ) == false )
                {
                    errMsg = string.Format( ERRORMSG_RANGE, "�d����" );
                    this.tNedit_SupplierCd_St.Focus();
                    return (false);
                }
                // ���[�J�[
                if ( CheckInputRange( tNedit_GoodsMakerCd_St, tNedit_GoodsMakerCd_Ed ) == false )
                {
                    errMsg = string.Format( ERRORMSG_RANGE, "���[�J�[" );
                    this.tNedit_GoodsMakerCd_St.Focus();
                    return (false);
                }
                // ���i������
                if ( CheckInputRange( tNedit_GoodsMGroup_St, tNedit_GoodsMGroup_Ed ) == false )
                {
                    errMsg = string.Format( ERRORMSG_RANGE, "���i������" );
                    this.tNedit_GoodsMGroup_St.Focus();
                    return (false);
                }
                // �O���[�v
                if ( CheckInputRange( tNedit_BLGloupCode_St, tNedit_BLGloupCode_Ed ) == false )
                {
                    errMsg = string.Format( ERRORMSG_RANGE, "�O���[�v" );
                    this.tNedit_BLGloupCode_St.Focus();
                    return (false);
                }
                // �a�k�R�[�h
                if ( CheckInputRange( tNedit_BLGoodsCode_St, tNedit_BLGoodsCode_Ed ) == false )
                {
                    errMsg = string.Format( ERRORMSG_RANGE, "�a�k�R�[�h" );
                    this.tNedit_BLGoodsCode_St.Focus();
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
        /// 
        /// </summary>
        /// <param name="stEdit"></param>
        /// <param name="edEdit"></param>
        /// <returns></returns>
        private bool CheckInputRange( TNedit stEdit, TNedit edEdit )
        {
            int stCode = stEdit.GetInt();
            int edCode = edEdit.GetInt();

            if ( stCode != 0 && 
                 edCode != 0 &&
                 stCode > edCode)
            {
                return false;
            }
            else
            {
                return true;
            }
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
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
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
        /// ��ʏ���r����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�������s�@False:�������f)</returns>
        /// <remarks>
        /// <br>Note        : ��ʏ����r���A�ύX����Ă���ꍇ�̓��b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        public bool CompareScreen()
        {
            if (this._closeFlg)
            {
                return (true);
            }

            // ��ʏ���r
            if (!CompareOriginalScreen())
            {
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
                            int status = Save();
                            if (status != 0)
                            {
                                //this.uGrid_Details.ActiveCell = this._activeCell;
                                //this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                return (false);
                            }
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            //this.uGrid_Details.ActiveCell = this._activeCell;
                            //this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                }
            }

            return (true);
        }

        /// <summary>
        /// ��ʏ���r����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ��@False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note        : ��ʏ����r���A�ύX����Ă���ꍇ�̓��b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            return (_scmPrtSettingAcs.GetUpdateCountFromTable() == 0);
        }

        #endregion �`�F�b�N����

        #region �O���b�h�ݒ�
        /// <summary>
        /// �O���b�h�쐬����
        /// </summary>
        /// <param name="uGrid">�O���b�h</param>
        /// <param name="displayList">�\���f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�̗���쐬���܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        public void CreateGrid(ref UltraGrid uGrid)
        {
            uGrid.DataSource = null;

            // �f�[�^�\�[�X�ƂȂ�DataView���A�N�Z�X�N���X����擾
            DataView view = _scmPrtSettingAcs.DataViewForMstList;
            uGrid.DataSource = view;

            // �_���폜�L��
            _scmPrtSettingAcs.ExcludeLogicalDeleteFromView = !this.uCheckEditor_StatusBar_ShowLogicalDelete.Checked;

            // �O���b�h�X�^�C���ݒ�
            SetGridLayout( ref uGrid );
        }

        /// <summary>
        /// �O���b�h�X�^�C���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �O���b�h�̃X�^�C����ݒ肵�܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void SetGridLayout(ref UltraGrid uGrid)
        {
            try
            {
                uGrid.BeginUpdate();

                ColumnsCollection columns = uGrid.DisplayLayout.Bands[0].Columns;

                // �Z���X�^�C��
                for (int index = 0; index < columns.Count; index++)
                {
                    columns[index].CellAppearance.BackColorDisabled = Color.White;
                    columns[index].CellAppearance.BackColorDisabled2 = Color.White;
                    columns[index].Hidden = true;
                }

                int visiblePosition = 0;

                int selectValue;
                if ( this.tComboEditor_TargetDivide.Value != null )
                {
                    selectValue = (int)this.tComboEditor_TargetDivide.Value;
                }
                else
                {
                    selectValue = 0;
                }

                # region [�e�J�����̐ݒ�]

                // �폜��
                columns[SCMPrtSettingAcs.ct_COL_LOGICALDELETEDATE].Hidden = !this.uCheckEditor_StatusBar_ShowLogicalDelete.Checked;
                columns[SCMPrtSettingAcs.ct_COL_LOGICALDELETEDATE].Header.Caption = "�폜��";
                columns[SCMPrtSettingAcs.ct_COL_LOGICALDELETEDATE].Header.Fixed = false;
                columns[SCMPrtSettingAcs.ct_COL_LOGICALDELETEDATE].CellAppearance.TextHAlign = HAlign.Left;
                columns[SCMPrtSettingAcs.ct_COL_LOGICALDELETEDATE].CellAppearance.ForeColor = Color.Red;
                columns[SCMPrtSettingAcs.ct_COL_LOGICALDELETEDATE].CellActivation = Activation.NoEdit;
                columns[SCMPrtSettingAcs.ct_COL_LOGICALDELETEDATE].Width = 100;
                columns[SCMPrtSettingAcs.ct_COL_LOGICALDELETEDATE].Header.VisiblePosition = visiblePosition++;

                // ���_�R�[�h
                columns[SCMPrtSettingAcs.ct_COL_SECTIONCODE].Hidden = (selectValue == 2);
                columns[SCMPrtSettingAcs.ct_COL_SECTIONCODE].Header.Caption = "���_";
                columns[SCMPrtSettingAcs.ct_COL_SECTIONCODE].Header.Fixed = false;
                columns[SCMPrtSettingAcs.ct_COL_SECTIONCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[SCMPrtSettingAcs.ct_COL_SECTIONCODE].CellActivation = Activation.NoEdit;
                columns[SCMPrtSettingAcs.ct_COL_SECTIONCODE].Width = 80;
                columns[SCMPrtSettingAcs.ct_COL_SECTIONCODE].Header.VisiblePosition = visiblePosition++;

                // ���Ӑ�R�[�h
                columns[SCMPrtSettingAcs.ct_COL_CUSTOMERCODE].Hidden = (selectValue == 1);
                columns[SCMPrtSettingAcs.ct_COL_CUSTOMERCODE].Header.Caption = "���Ӑ�";
                columns[SCMPrtSettingAcs.ct_COL_CUSTOMERCODE].Header.Fixed = false;
                columns[SCMPrtSettingAcs.ct_COL_CUSTOMERCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[SCMPrtSettingAcs.ct_COL_CUSTOMERCODE].CellActivation = Activation.NoEdit;
                columns[SCMPrtSettingAcs.ct_COL_CUSTOMERCODE].Width = 80;
                columns[SCMPrtSettingAcs.ct_COL_CUSTOMERCODE].Format = GetCustomerFormat();
                columns[SCMPrtSettingAcs.ct_COL_CUSTOMERCODE].Header.VisiblePosition = visiblePosition++;

                // �d����
                columns[SCMPrtSettingAcs.ct_COL_SUPPLIERCD].Hidden = false;
                columns[SCMPrtSettingAcs.ct_COL_SUPPLIERCD].Header.Caption = "�d����";
                columns[SCMPrtSettingAcs.ct_COL_SUPPLIERCD].Header.Fixed = false;
                columns[SCMPrtSettingAcs.ct_COL_SUPPLIERCD].CellAppearance.TextHAlign = HAlign.Right;
                columns[SCMPrtSettingAcs.ct_COL_SUPPLIERCD].CellActivation = Activation.NoEdit;
                columns[SCMPrtSettingAcs.ct_COL_SUPPLIERCD].Width = 80;
                columns[SCMPrtSettingAcs.ct_COL_SUPPLIERCD].Format = GetSupplierFormat();
                columns[SCMPrtSettingAcs.ct_COL_SUPPLIERCD].Header.VisiblePosition = visiblePosition++;

                // ���i���[�J�[�R�[�h
                columns[SCMPrtSettingAcs.ct_COL_GOODSMAKERCD].Hidden = false;
                columns[SCMPrtSettingAcs.ct_COL_GOODSMAKERCD].Header.Caption = "���[�J�[";
                columns[SCMPrtSettingAcs.ct_COL_GOODSMAKERCD].Header.Fixed = false;
                columns[SCMPrtSettingAcs.ct_COL_GOODSMAKERCD].CellAppearance.TextHAlign = HAlign.Right;
                columns[SCMPrtSettingAcs.ct_COL_GOODSMAKERCD].CellActivation = Activation.NoEdit;
                columns[SCMPrtSettingAcs.ct_COL_GOODSMAKERCD].Width = 100;
                columns[SCMPrtSettingAcs.ct_COL_GOODSMAKERCD].Format = GetMakerFormat();
                columns[SCMPrtSettingAcs.ct_COL_GOODSMAKERCD].Header.VisiblePosition = visiblePosition++;

                // ���i�����ރR�[�h
                columns[SCMPrtSettingAcs.ct_COL_GOODSMGROUP].Hidden = false;
                columns[SCMPrtSettingAcs.ct_COL_GOODSMGROUP].Header.Caption = "���i������";
                columns[SCMPrtSettingAcs.ct_COL_GOODSMGROUP].Header.Fixed = false;
                columns[SCMPrtSettingAcs.ct_COL_GOODSMGROUP].CellAppearance.TextHAlign = HAlign.Right;
                columns[SCMPrtSettingAcs.ct_COL_GOODSMGROUP].CellActivation = Activation.NoEdit;
                columns[SCMPrtSettingAcs.ct_COL_GOODSMGROUP].Width = 100;
                columns[SCMPrtSettingAcs.ct_COL_GOODSMGROUP].Format = GetGoodsMGroupFormat();
                columns[SCMPrtSettingAcs.ct_COL_GOODSMGROUP].Header.VisiblePosition = visiblePosition++;

                // �O���[�v�R�[�h
                columns[SCMPrtSettingAcs.ct_COL_BLGROUPCODE].Hidden = false;
                columns[SCMPrtSettingAcs.ct_COL_BLGROUPCODE].Header.Caption = "�O���[�v";
                columns[SCMPrtSettingAcs.ct_COL_BLGROUPCODE].Header.Fixed = false;
                columns[SCMPrtSettingAcs.ct_COL_BLGROUPCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[SCMPrtSettingAcs.ct_COL_BLGROUPCODE].CellActivation = Activation.NoEdit;
                columns[SCMPrtSettingAcs.ct_COL_BLGROUPCODE].Width = 100;
                columns[SCMPrtSettingAcs.ct_COL_BLGROUPCODE].Format = GetBLGroupFormat();
                columns[SCMPrtSettingAcs.ct_COL_BLGROUPCODE].Header.VisiblePosition = visiblePosition++;

                // BL�R�[�h
                columns[SCMPrtSettingAcs.ct_COL_BLGOODSCODE].Hidden = false;
                columns[SCMPrtSettingAcs.ct_COL_BLGOODSCODE].Header.Caption = "�a�k�R�[�h";
                columns[SCMPrtSettingAcs.ct_COL_BLGOODSCODE].Header.Fixed = false;
                columns[SCMPrtSettingAcs.ct_COL_BLGOODSCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[SCMPrtSettingAcs.ct_COL_BLGOODSCODE].CellActivation = Activation.NoEdit;
                columns[SCMPrtSettingAcs.ct_COL_BLGOODSCODE].Width = 100;
                columns[SCMPrtSettingAcs.ct_COL_BLGOODSCODE].Format = GetBLCodeFormat();
                columns[SCMPrtSettingAcs.ct_COL_BLGOODSCODE].Header.VisiblePosition = visiblePosition++;

                // �i��
                columns[SCMPrtSettingAcs.ct_COL_GOODSNO].Hidden = false;
                columns[SCMPrtSettingAcs.ct_COL_GOODSNO].Header.Caption = "�i��";
                columns[SCMPrtSettingAcs.ct_COL_GOODSNO].Header.Fixed = false;
                columns[SCMPrtSettingAcs.ct_COL_GOODSNO].CellAppearance.TextHAlign = HAlign.Left;
                columns[SCMPrtSettingAcs.ct_COL_GOODSNO].CellActivation = Activation.NoEdit;
                columns[SCMPrtSettingAcs.ct_COL_GOODSNO].Width = 200;
                columns[SCMPrtSettingAcs.ct_COL_GOODSNO].Header.VisiblePosition = visiblePosition++;

                // �����񓚋敪
                columns[SCMPrtSettingAcs.ct_COL_AUTOANSWERDIV].Hidden = false;
                columns[SCMPrtSettingAcs.ct_COL_AUTOANSWERDIV].Header.Caption = "�����񓚋敪";
                columns[SCMPrtSettingAcs.ct_COL_AUTOANSWERDIV].Header.Fixed = false;
                columns[SCMPrtSettingAcs.ct_COL_AUTOANSWERDIV].CellAppearance.TextHAlign = HAlign.Left;
                columns[SCMPrtSettingAcs.ct_COL_AUTOANSWERDIV].CellAppearance.ForeColorDisabled = Color.Black;
                columns[SCMPrtSettingAcs.ct_COL_AUTOANSWERDIV].CellAppearance.BackColorDisabled = Color.LightGray;
                columns[SCMPrtSettingAcs.ct_COL_AUTOANSWERDIV].CellActivation = Activation.AllowEdit;
                columns[SCMPrtSettingAcs.ct_COL_AUTOANSWERDIV].Width = 100;
                columns[SCMPrtSettingAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList();
                columns[SCMPrtSettingAcs.ct_COL_AUTOANSWERDIV].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                columns[SCMPrtSettingAcs.ct_COL_AUTOANSWERDIV].Header.VisiblePosition = visiblePosition++;

                // �␳
                columns[SCMPrtSettingAcs.ct_COL_LOGICALDELETEDATE].Header.VisiblePosition = 0;

                # endregion

                # region [�Z�������ݒ�]
                List<string> colNameList = new List<string>( new string[] 
                                            { 
                                                SCMPrtSettingAcs.ct_COL_SECTIONCODE, 
                                                SCMPrtSettingAcs.ct_COL_CUSTOMERCODE, 
                                                SCMPrtSettingAcs.ct_COL_SUPPLIERCD, 
                                                SCMPrtSettingAcs.ct_COL_GOODSMAKERCD, 
                                                SCMPrtSettingAcs.ct_COL_GOODSMGROUP,
                                                SCMPrtSettingAcs.ct_COL_BLGROUPCODE,
                                                SCMPrtSettingAcs.ct_COL_BLGOODSCODE 
                                            } );
                
                Infragistics.Win.Appearance margedCellAppearance = new Infragistics.Win.Appearance();
                margedCellAppearance.BackColor = Color.Lavender;
                margedCellAppearance.BackColor2 = Color.Lavender;

                for (int index = 0; index < colNameList.Count; index++)
                {
                    string colName = colNameList[index];

                    // CellAppearance�������I�ɓ��ꂷ��
                    columns[colName].MergedCellAppearance = margedCellAppearance;
                    columns[colName].CellAppearance.BackColor = margedCellAppearance.BackColor;
                    columns[colName].CellAppearance.BackColor2 = margedCellAppearance.BackColor2;
                    columns[colName].CellAppearance.TextVAlign = VAlign.Top;

                    // �Z�������ݒ�
                    columns[colName].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
                    columns[colName].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
                    columns[colName].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
                }
                columns[SCMPrtSettingAcs.ct_COL_SECTIONCODE].MergedCellEvaluator = new CustomMergedCellEvaluator( SCMPrtSettingAcs.ct_COL_SECTIONCODE );

                columns[SCMPrtSettingAcs.ct_COL_CUSTOMERCODE].MergedCellEvaluator = new CustomMergedCellEvaluator( SCMPrtSettingAcs.ct_COL_SECTIONCODE, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_CUSTOMERCODE );

                columns[SCMPrtSettingAcs.ct_COL_SUPPLIERCD].MergedCellEvaluator = new CustomMergedCellEvaluator( SCMPrtSettingAcs.ct_COL_SECTIONCODE, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_CUSTOMERCODE, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_SUPPLIERCD );

                columns[SCMPrtSettingAcs.ct_COL_GOODSMAKERCD].MergedCellEvaluator = new CustomMergedCellEvaluator( SCMPrtSettingAcs.ct_COL_SECTIONCODE, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_CUSTOMERCODE, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_SUPPLIERCD, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_GOODSMAKERCD );

                columns[SCMPrtSettingAcs.ct_COL_GOODSMGROUP].MergedCellEvaluator = new CustomMergedCellEvaluator( SCMPrtSettingAcs.ct_COL_SECTIONCODE, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_CUSTOMERCODE, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_SUPPLIERCD, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_GOODSMAKERCD, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_GOODSMGROUP );

                columns[SCMPrtSettingAcs.ct_COL_BLGROUPCODE].MergedCellEvaluator = new CustomMergedCellEvaluator( SCMPrtSettingAcs.ct_COL_SECTIONCODE, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_CUSTOMERCODE, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_SUPPLIERCD, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_GOODSMAKERCD, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_GOODSMGROUP,
                                                                                                                    SCMPrtSettingAcs.ct_COL_BLGROUPCODE );

                columns[SCMPrtSettingAcs.ct_COL_BLGOODSCODE].MergedCellEvaluator = new CustomMergedCellEvaluator( SCMPrtSettingAcs.ct_COL_SECTIONCODE, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_CUSTOMERCODE, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_SUPPLIERCD, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_GOODSMAKERCD, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_GOODSMGROUP, 
                                                                                                                    SCMPrtSettingAcs.ct_COL_BLGROUPCODE,
                                                                                                                    SCMPrtSettingAcs.ct_COL_BLGOODSCODE );
                # endregion
            }
            finally
            {
                uGrid.EndUpdate();
            }
        }
        /// <summary>
        /// �����񓚋敪 ���X�g�擾
        /// </summary>
        /// <returns></returns>
        private IValueList GetAutoAnswerDivValueList()
        {
            // 0:���Ȃ�,1:�[��,2:���i

            ValueList list = new ValueList();
            list.ValueListItems.Add( new ValueListItem( 0, "���Ȃ�" ) );
            list.ValueListItems.Add( new ValueListItem( 1, "�[��" ) );
            list.ValueListItems.Add( new ValueListItem( 2, "���i" ) );

            return list;
        }

        # region [�O���b�h�Z����������N���X]
        /// <summary>
        /// �O���b�h�Z����������N���X(�J�X�^�}�C�Y)
        /// </summary>
        private class CustomMergedCellEvaluator : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
        {
            /// <summary>���������Z�����X�g</summary>
            private List<string> _joinColList;
            /// <summary>
            /// ���������Z�����X�g
            /// </summary>
            public List<string> JoinColList
            {
                get { return _joinColList; }
                set { _joinColList = value; }
            }

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public CustomMergedCellEvaluator()
            {
                _joinColList = new List<string>();
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public CustomMergedCellEvaluator( params string[] joinCols )
            {
                _joinColList = new List<string>( joinCols );
            }

            /// <summary>
            /// �Z���������菈��
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="column"></param>
            /// <returns></returns>
            public bool ShouldCellsBeMerged( Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column )
            {
                foreach ( string joinColName in JoinColList )
                {
                    if ( !EqualCellValue( row1, row2, joinColName ) ) return false;
                }
                return true;
            }
            /// <summary>
            /// �Z��Value��r����
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="columnName"></param>
            /// <returns></returns>
            private bool EqualCellValue( Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, string columnName )
            {
                return ((row1.Cells[columnName].Value.ToString().Trim() == row2.Cells[columnName].Value.ToString().Trim()));
            }
        }
        # endregion

        # region [�R�[�h�t�H�[�}�b�g�擾����]
        /// <summary>
        /// ���Ӑ�R�[�h�t�H�[�}�b�g�擾
        /// </summary>
        /// <returns></returns>
        private string GetCustomerFormat()
        {
            return GetFormat( "tNedit_CustomerCode" );
        }
        /// <summary>
        /// �d����R�[�h�t�H�[�}�b�g�擾
        /// </summary>
        /// <returns></returns>
        private string GetSupplierFormat()
        {
            return GetFormat( "tNedit_SupplierCd" );
        }
        /// <summary>
        /// ���[�J�[�R�[�h�t�H�[�}�b�g�擾
        /// </summary>
        /// <returns></returns>
        private string GetMakerFormat()
        {
            return GetFormat( "tNedit_GoodsMakerCd" );
        }
        /// <summary>
        /// �a�k�R�[�h�t�H�[�}�b�g�擾
        /// </summary>
        /// <returns></returns>
        private string GetBLCodeFormat()
        {
            return GetFormat( "tNedit_BLGoodsCode" );
        }
        /// <summary>
        /// �O���[�v�R�[�h�t�H�[�}�b�g�擾
        /// </summary>
        /// <returns></returns>
        private string GetBLGroupFormat()
        {
            return GetFormat( "tNedit_BLGloupCode" );
        }
        /// <summary>
        /// �����ރR�[�h�t�H�[�}�b�g�擾
        /// </summary>
        /// <returns></returns>
        private string GetGoodsMGroupFormat()
        {
            return GetFormat( "tNedit_GoodsMGroup" );
        }
        /// <summary>
        /// �ėp�t�H�[�}�b�g�擾����
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        private string GetFormat( string editName )
        {
            string format = string.Empty;

            UiSet uiset;
            this.uiSetControl1.ReadUISet( out uiset, editName );
            if ( uiset != null )
            {
                format = string.Format( "{0};-{0};''", new string( '0', uiset.Column ) );
            }

            return format;
        }
        # endregion

        /// <summary>
        /// �O���b�h�s�ݒ菈��
        /// </summary>
        /// <param name="uGrid">�O���b�h</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�s�ɑ΂��Ċe��ݒ�����܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        public void SettingGridRows(ref UltraGrid uGrid)
        {
            uGrid.BeginUpdate();

            try
            {
                for ( int rowIndex = 0; rowIndex < uGrid.Rows.Count; rowIndex++ )
                {
                    CellsCollection cells = uGrid.Rows[rowIndex].Cells;

                    if ( cells[SCMPrtSettingAcs.ct_COL_LOGICALDELETEDATE].Value.ToString().Trim() == string.Empty )
                    {
                        // �ʏ�F�ҏW��
                        cells[SCMPrtSettingAcs.ct_COL_AUTOANSWERDIV].Activation = Activation.AllowEdit;
                        cells[SCMPrtSettingAcs.ct_COL_AUTOANSWERDIV].Appearance = null;
                    }
                    else
                    {
                        // �폜�ς݁F�ҏW�s��
                        cells[SCMPrtSettingAcs.ct_COL_AUTOANSWERDIV].Activation = Activation.NoEdit;
                        cells[SCMPrtSettingAcs.ct_COL_AUTOANSWERDIV].Appearance.BackColor = Color.LightGray;
                    }
                }
                uGrid.Refresh();
            }
            finally
            {
                uGrid.EndUpdate();
            }
        }
        #endregion �O���b�h�ݒ�

        #region �Z���l�ϊ�
        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <returns>Int�^</returns>
        /// <remarks>
        /// <br>Note        : �Z���l��Int�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        public int IntObjToInt(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return (int)cellValue;
            }
        }

        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <returns>String�^</returns>
        /// <remarks>
        /// <br>Note        : �Z���l��String�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        public int StrObjToInt(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return int.Parse((string)cellValue);
            }
        }

        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <returns>Double�^</returns>
        /// <remarks>
        /// <br>Note        : �Z���l��Double�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        public double DoubleObjToDouble(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return (double)cellValue;
            }
        }

        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <returns>Bool�^</returns>
        /// <remarks>
        /// <br>Note        : �Z���l��Bool�^�ɕϊ����܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        public bool BoolObjToBool(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return (false);
            }
            else
            {
                return (bool)cellValue;
            }
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/12</br>
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/12</br>
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
                                         this._scmPrtSettingAcs,	    // �G���[�����������I�u�W�F�N�g
                                         msgButton,         			  	// �\������{�^��
                                         MessageBoxDefaultButton.Button1);	// �����\���{�^��

            return dialogResult;
        }
        #endregion ���b�Z�[�W�{�b�N�X�\��

        #endregion �� Private Methods


        #region �� Control Events

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �t�H�[����Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void PMSCM09001UA_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// ToolClick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // ��ʏ���r
                        bool bStatus = CompareScreen();
                        if (!bStatus)
                        {
                            return;
                        }

                        this._closeFlg = true;

                        // �I������
                        Close();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // �ۑ�����
                        Save();

                        // �O���b�h�N���A
                        _scmPrtSettingAcs.Clear();

                        // �t�H�[�J�X�ݒ�
                        this.tEdit_SectionCodeAllowZero.Focus();

                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // ��������
                        _extrInfo = null;
                        Search();
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        // ��ʏ���r
                        bool bStatus = CompareScreen();
                        if (!bStatus)
                        {
                            return;
                        }

                        // �N���A����
                        ClearScreen();

                        // �A�N�Z�X�N���X���̃e�[�u���N���A
                        _scmPrtSettingAcs.Clear();

                        break;
                    }
                case "ButtonTool_Insert":
                    {
                        // �i�V�K�j�ҏW�t�h�\��
                        _editForm = new PMSCM09001UB( _scmPrtSettingAcs, _guideControl );
                        _editForm.RecordGuid = Guid.Empty;
                        _editForm.ShowDialog( this );

                        _editForm.Dispose();
                        _editForm = null;

                        // �O���b�h�f�[�^�ݒ�
                        CreateGrid( ref this.uGrid_Details );
                        SettingGridRows( ref this.uGrid_Details );
                        this.uGrid_Details.Refresh();

                        break;
                    }
                case "ButtonTool_Edit":
                    {
                        // �i�ҏW�j�ҏW�t�h�\��
                        _editForm = new PMSCM09001UB( _scmPrtSettingAcs, _guideControl );
                        _editForm.RecordGuid = this.GetRecordGuidFromGrid();
                        _editForm.ShowDialog( this );

                        _editForm.Dispose();
                        _editForm = null;

                        // �O���b�h�f�[�^�ݒ�
                        CreateGrid( ref this.uGrid_Details );
                        SettingGridRows( ref this.uGrid_Details );
                        this.uGrid_Details.Refresh();

                        break;
                    }
                case "ButtonTool_Delete":
                    {
                        // �_���폜
                        this.LogicalDelete();

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
                        // �O���b�h�f�[�^�ݒ�
                        CreateGrid( ref this.uGrid_Details );
                        SettingGridRows( ref this.uGrid_Details );
                        this.uGrid_Details.Refresh();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD

                        break;
                    }
                case "ButtonTool_Renewal":
                    {
                        // �ŐV���擾
                        _guideControl.Renewal();

                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "�ŐV�����擾���܂����B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                        break;
                    }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LogicalDelete()
        {
            // �I�𒆂̃��R�[�h��Guid���擾
            Guid guid = this.GetRecordGuidFromGrid();
            // �폜�Ώۃ��R�[�h���擾
            SCMPrtSetting scmPrtSetting = _scmPrtSettingAcs.GetRecordForMaintenance( guid );

            # region [�폜�ς݃`�F�b�N]
            if ( scmPrtSetting.LogicalDeleteCode != 0 )
            {
                // �_���폜�ςݍs�Ȃ烁�b�Z�[�W�\�����ďI��

                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                    "�I�𒆂̃f�[�^�͊��ɍ폜����Ă��܂�",// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK );				// �\������{�^��

                return;
            }
            # endregion


            # region [�m�F�_�C�A���O]
            // �폜�m�F�_�C�A���O
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�I�������s���폜���܂����H",		// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2 );		// �\������{�^��

            if ( result != DialogResult.OK )
            {
                return;
            }
            # endregion


            int status;
            string errMsg;
            ArrayList deleteList = new ArrayList();
            deleteList.Add( scmPrtSetting );

            status = _scmPrtSettingAcs.LogicalDelete( ref deleteList, out errMsg );

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        //// �Č���
                        //this.Search();

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        if ( status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE )
                        {
                            errMsg = "���ɑ��[�����X�V����Ă��܂��B";
                        }
                        else
                        {
                            errMsg = "���ɑ��[�����폜����Ă��܂��B";
                        }

                        ShowMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "Save",
                                       errMsg,
                                       status,
                                       MessageBoxButtons.OK );

                        this.tEdit_SectionCodeAllowZero.Focus();
                        //return (status);
                        break;
                    }
                default:
                    {
                        ShowMessageBox( emErrorLevel.ERR_LEVEL_STOP,
                                   "Save",
                                   "�ۑ������Ɏ��s���܂����B",
                                   status,
                                   MessageBoxButtons.OK );

                        this.tEdit_SectionCodeAllowZero.Focus();
                        //return (status);
                        break;
                    }
            }
        }

        /// <summary>
        /// �O���b�h�I�𒆃��R�[�h�����GUID�擾
        /// </summary>
        /// <returns></returns>
        private Guid GetRecordGuidFromGrid()
        {
            Guid guid = Guid.Empty;

            if ( uGrid_Details.ActiveCell != null )
            {
                guid = (Guid)uGrid_Details.ActiveCell.Row.Cells[SCMPrtSettingAcs.ct_COL_FILEHEADERGUID].Value;
            }

            return guid;
        }
        /// <summary>
        /// �K�C�h����N���X�ŐV���擾��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuideControl_AfterRenewal( object sender, EventArgs e )
        {
            // ���_���̂̍X�V�i���ɃK�C�h����N���X�͍ŐV���擾���Ă���̂ŁA�ŐV���̂ɂȂ�j
            string sectionName;
            if (this.GetSectionName( this.tEdit_SectionCodeAllowZero.Text.Trim(), out sectionName ))
            {
                this.tEdit_SectionName.Text = string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()) ?
                    string.Empty : sectionName;
            }
            else
            {
                this.tEdit_SectionCodeAllowZero.Text = "00";
                this.tEdit_SectionName.Text = "�S��";
            }

            // �A�N�Z�X�N���X�ŐV���擾
            this._scmPrtSettingAcs.Renewal();
        }
        /// <summary>
        /// �f�[�^�X�V��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SCMPrtSettingAcs_AfterTableUpdate( object sender, EventArgs e )
        {
            if ( _scmPrtSettingAcs.DataViewForMstList.Count > 0 )
            {
                // �P���ȏ�
                SetButtonToolEnabled( "ButtonTool_Save", true );
            }
            else
            {
                // 0��
                SetButtonToolEnabled( "ButtonTool_Save", false );
                SetButtonToolEnabled( "ButtonTool_Edit", false );
                SetButtonToolEnabled( "ButtonTool_Delete", false );
            }
        }
        /// <summary>
        /// �t�@���N�V�����{�^���L���E�����ݒ�
        /// </summary>
        /// <param name="key"></param>
        /// <param name="enabled"></param>
        private void SetButtonToolEnabled( string key, bool enabled )
        {
            (this.tToolbarsManager_MainMenu.Tools[key] as ButtonTool).SharedProps.Enabled = enabled;
        }

        /// <summary>
        /// ����"���͍���"���擾(�K�C�h�{�^������)
        /// </summary>
        /// <param name="currControl"></param>
        /// <returns></returns>
        private Control GetNextEdit( Control currControl )
        {
            Control nextControl;

            // �����ڎ擾
            # region [�����ڎ擾]
            switch ( currControl.Name )
            {
                case "tComboEditor_TargetDivide":
                    nextControl = tEdit_SectionCodeAllowZero;
                    break;
                case "tEdit_SectionCodeAllowZero":
                    nextControl = tNedit_CustomerCode_St;
                    break;
                case "tNedit_CustomerCode_St":
                    nextControl = tNedit_CustomerCode_Ed;
                    break;
                case "tNedit_CustomerCode_Ed":
                    nextControl = tNedit_SupplierCd_St;
                    break;
                case "tNedit_SupplierCd_St":
                    nextControl = tNedit_SupplierCd_Ed;
                    break;
                case "tNedit_SupplierCd_Ed":
                    nextControl = tNedit_GoodsMakerCd_St;
                    break;
                case "tNedit_GoodsMakerCd_St":
                    nextControl = tNedit_GoodsMakerCd_Ed;
                    break;
                case "tNedit_GoodsMakerCd_Ed":
                    nextControl = tNedit_GoodsMGroup_St;
                    break;
                case "tNedit_GoodsMGroup_St":
                    nextControl = tNedit_GoodsMGroup_Ed;
                    break;
                case "tNedit_GoodsMGroup_Ed":
                    nextControl = tNedit_BLGloupCode_St;
                    break;
                case "tNedit_BLGloupCode_St":
                    nextControl = tNedit_BLGloupCode_Ed;
                    break;
                case "tNedit_BLGloupCode_Ed":
                    nextControl = tNedit_BLGoodsCode_St;
                    break;
                case "tNedit_BLGoodsCode_St":
                    nextControl = tNedit_BLGoodsCode_Ed;
                    break;
                case "tNedit_BLGoodsCode_Ed":
                    nextControl = uGrid_Details;
                    break;
                default:
                    nextControl = null;
                    break;
            }
            # endregion

            if ( nextControl != null )
            {
                // ���͕s�Ȃ�ċA�I�Ɏ擾
                if ( !nextControl.Enabled || !nextControl.Visible )
                {
                    nextControl = GetNextEdit( nextControl );
                }
            }

            // �ԋp
            return nextControl;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
        /// <summary>
        /// �O��"���͍���"���擾(�K�C�h�{�^������)
        /// </summary>
        /// <param name="currControl"></param>
        /// <returns></returns>
        private Control GetPrevEdit( Control currControl )
        {
            Control prevControl;

            // �O���ڎ擾
            # region [�O���ڎ擾]
            switch ( currControl.Name )
            {
                case "tNedit_BLGoodsCode_Ed":
                    prevControl = tNedit_BLGoodsCode_St;
                    break;
                case "tNedit_BLGoodsCode_St":
                    prevControl = tNedit_BLGloupCode_Ed;
                    break;
                case "tNedit_BLGloupCode_Ed":
                    prevControl = tNedit_BLGloupCode_St;
                    break;
                case "tNedit_BLGloupCode_St":
                    prevControl = tNedit_GoodsMGroup_Ed;
                    break;
                case "tNedit_GoodsMGroup_Ed":
                    prevControl = tNedit_GoodsMGroup_St;
                    break;
                case "tNedit_GoodsMGroup_St":
                    prevControl = tNedit_GoodsMakerCd_Ed;
                    break;
                case "tNedit_GoodsMakerCd_Ed":
                    prevControl = tNedit_GoodsMakerCd_St;
                    break;
                case "tNedit_GoodsMakerCd_St":
                    prevControl = tNedit_SupplierCd_Ed;
                    break;
                case "tNedit_SupplierCd_Ed":
                    prevControl = tNedit_SupplierCd_St;
                    break;
                case "tNedit_SupplierCd_St":
                    prevControl = tNedit_CustomerCode_Ed;
                    break;
                case "tNedit_CustomerCode_Ed":
                    prevControl = tNedit_CustomerCode_St;
                    break;
                case "tNedit_CustomerCode_St":
                    prevControl = tEdit_SectionCodeAllowZero;
                    break;
                case "tEdit_SectionCodeAllowZero":
                    prevControl = tComboEditor_TargetDivide;
                    break;
                case "tComboEditor_TargetDivide":
                    prevControl = tNedit_BLGoodsCode_St;
                    break;
                default:
                    prevControl = null;
                    break;
            }
            # endregion

            if ( prevControl != null )
            {
                // ���͕s�Ȃ�ċA�I�Ɏ擾
                if ( !prevControl.Enabled || !prevControl.Visible )
                {
                    prevControl = GetPrevEdit( prevControl );
                }
            }

            // �ԋp
            return prevControl;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._guideControl.SecInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

                    // ���t�H�[�J�X
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���Ӑ�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void uButton_CustomerCode_St_Click( object sender, EventArgs e )
        {
            // �K�C�h�\��
            DialogResult result = _guideControl.CustomerSearchForm.ShowDialog();
            if ( result == DialogResult.OK && _guideControl.CustomerGuideRet != null )
            {
                // ���ʃZ�b�g
                if ( sender == this.uButton_CustomerCode_St )
                {
                    // �J�n
                    tNedit_CustomerCode_St.SetInt( _guideControl.CustomerGuideRet.CustomerCode );
                }
                else if ( sender == this.uButton_CustomerCode_Ed )
                {
                    // �I��
                    tNedit_CustomerCode_Ed.SetInt( _guideControl.CustomerGuideRet.CustomerCode );
                }

                // ���t�H�[�J�X
                this.SelectNextControl( (Control)sender, true, true, true, true );
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �d����K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void SupplierGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Supplier supplier;

                // �K�C�h�\��
                int status = this._guideControl.SupplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
                if (status == 0)
                {
                    if ( sender == uButton_SupplierCd_St )
                    {
                        // �J�n
                        this.tNedit_SupplierCd_St.SetInt( supplier.SupplierCd );
                    }
                    else if ( sender == uButton_SupplierCd_Ed )
                    {
                        // �I��
                        this.tNedit_SupplierCd_Ed.SetInt( supplier.SupplierCd );
                    }

                    // ���t�H�[�J�X
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void uButton_GoodsMGroup_St_Click( object sender, EventArgs e )
        {
            GoodsGroupU goodsMGroup;

            // �K�C�h�N��
            int status = this._guideControl.GoodsAcs.ExecuteGoodsMGroupGuid( this._enterpriseCode, out goodsMGroup );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                if (sender == uButton_GoodsMGroup_St)
                {
                    // �J�n
                    tNedit_GoodsMGroup_St.SetInt( goodsMGroup.GoodsMGroup );
                }
                else if ( sender == uButton_GoodsMGroup_Ed )
                {
                    // �I��
                    tNedit_GoodsMGroup_Ed.SetInt( goodsMGroup.GoodsMGroup );
                }

                // ���t�H�[�J�X
                this.SelectNextControl( (Control)sender, true, true, true, true );
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void uButton_BLGloupCode_St_Click( object sender, EventArgs e )
        {
            // �K�C�h�\��
            BLGroupU blGroupUInfo;
            int status = this._guideControl.GoodsAcs.ExecuteBLGroupGuid( this._enterpriseCode, out blGroupUInfo );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                if ( sender == uButton_BLGloupCode_St )
                {
                    // �J�n
                    tNedit_BLGloupCode_St.SetInt( blGroupUInfo.BLGroupCode );
                }
                else if ( sender == uButton_BLGloupCode_Ed )
                {
                    // �I��
                    tNedit_BLGloupCode_Ed.SetInt( blGroupUInfo.BLGroupCode );
                }

                // ���t�H�[�J�X
                this.SelectNextControl( (Control)sender, true, true, true, true );
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void uButton_BLGoodsCode_St_Click( object sender, EventArgs e )
        {
            BLGoodsCdUMnt bLGoodsCdUMnt;

            // �K�C�h�N��
            int status = _guideControl.BLGoodsCdAcs.ExecuteGuid( this._enterpriseCode, out bLGoodsCdUMnt );
            if ( status == 0 )
            {
                if ( sender == uButton_BLGoodsCode_St )
                {
                    // �J�n
                    tNedit_BLGoodsCode_St.SetInt( bLGoodsCdUMnt.BLGoodsCode );

                    // ���t�H�[�J�X
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
                else if ( sender == uButton_BLGoodsCode_Ed )
                {
                    // �I��
                    tNedit_BLGoodsCode_Ed.SetInt( bLGoodsCdUMnt.BLGoodsCode );

                    // �������s
                    if ( this.Search() == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        // ���t�H�[�J�X
                        this.SelectNextControl( (Control)sender, true, true, true, true );
                    }
                    else
                    {
                        this.tComboEditor_TargetDivide.Focus();
                    }
                }
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���[�J�[�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt makerUMnt;

                int status = this._guideControl.MakerAcs.ExecuteGuid( this._enterpriseCode, out makerUMnt );
                if (status == 0)
                {
                    if ( sender == uButton_GoodsMakerCd_St )
                    {
                        // �J�n
                        this.tNedit_GoodsMakerCd_St.SetInt( makerUMnt.GoodsMakerCd );
                    }
                    else if ( sender == uButton_GoodsMakerCd_Ed )
                    {
                        // �I��
                        this.tNedit_GoodsMakerCd_Ed.SetInt( makerUMnt.GoodsMakerCd );
                    }

                    // ���t�H�[�J�X
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ExpandedStateChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �W�J�X�e�[�^�X���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void Standard_UGroupBox_ExpandedStateChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab )
            {
                this.uGrid_Details.PerformAction( UltraGridAction.ExitEditMode );
                //e.Handled = true;
            }
        }

        /// <summary>
        /// KeyPress �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        /// <summary>
        /// AfterCellActivate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Z�����A�N�e�B�u���������ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            UpdateButtonToolEnabled();
        }
        /// <summary>
        /// �{�^���̗L���E�����ݒ�
        /// </summary>
        private void UpdateButtonToolEnabled()
        {
            if ( uGrid_Details.ActiveCell != null )
            {
                if ( string.IsNullOrEmpty( (string)uGrid_Details.ActiveCell.Row.Cells[SCMPrtSettingAcs.ct_COL_LOGICALDELETEDATE].Value ) )
                {
                    // �ʏ�
                    SetButtonToolEnabled( "ButtonTool_Edit", true );
                    SetButtonToolEnabled( "ButtonTool_Delete", true );
                }
                else
                {
                    // �_���폜
                    SetButtonToolEnabled( "ButtonTool_Edit", true );
                    //SetButtonToolEnabled( "ButtonTool_Delete", false );
                    SetButtonToolEnabled( "ButtonTool_Delete", true );
                }
            }
            else
            {
                // �s���I������Ă��Ȃ�
                SetButtonToolEnabled( "ButtonTool_Edit", false );
                SetButtonToolEnabled( "ButtonTool_Delete", false );
            }
        }

        /// <summary>
        /// AfterRowActivate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �s���A�N�e�B�u���������ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �ҏW���[�h���I���������ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Tick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���Ԋu���߂��鎞�ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // �t�H�[�J�X�ݒ�
            this.tComboEditor_TargetDivide.Focus();

            // XML�f�[�^�Ǎ�
            LoadStateXmlData();

            // �O���b�h�̃A�N�e�B�u�s���N���A
            this.uGrid_Details.ActiveRow = null;

            // �{�^���\���X�V
            this.UpdateButtonToolEnabled();

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �t�H���g�T�C�Y�R���{�{�b�N�X�̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void tComboEditor_GridFontSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_GridFontSize.Value == null)
            {
                this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (int)11;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.tComboEditor_GridFontSize.Value;
            }
        }

        /// <summary>
        /// ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Ώۋ敪�R���{�{�b�N�X�̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void tComboEditor_TargetDivide_ValueChanged(object sender, EventArgs e)
        {
            // ���͕␳
            if (this.tComboEditor_TargetDivide.Value == null)
            {
                this.tComboEditor_TargetDivide.Value = 0;
            }

            // �p�l���L���E����
            bool sectionEnable = false;
            bool customerEnable = false;

            // �R���{�{�b�N�X�I��
            int selectValue = (int)this.tComboEditor_TargetDivide.Value;
            switch ( selectValue )
            {
                // 0:�S��
                default:
                case 0:
                    break;
                // 1:���_
                case 1:
                    sectionEnable = true;
                    break;
                // 2:���Ӑ�
                case 2:
                    customerEnable = true;
                    break;
            }

            // ���_�̕\���X�V
            panel_Section.Enabled = sectionEnable;
            if ( !sectionEnable )
            {
                tEdit_SectionCodeAllowZero.Clear();
                tEdit_SectionName.Clear();
            }
            else
            {
                this.tEdit_SectionCodeAllowZero.DataText = "00";
                this.tEdit_SectionName.DataText = "�S��";
            }

            // ���Ӑ�̕\���X�V
            panel_Customer.Enabled = customerEnable;
            if ( !customerEnable )
            {
                tNedit_CustomerCode_St.Clear();
                tNedit_CustomerCode_Ed.Clear();
            }
        }

        /// <summary>
        /// Leave �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���Ӑ�|���f����t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��� ���b</br>
        /// <br>Date        : 2009/05/12</br>
        /// </remarks>
        private void tNedit_CustRateGrpCode_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = (TNedit)sender;

            if (tNedit.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = tNedit.GetInt();

            tNedit.DataText = custRateGrpCode.ToString("0000");
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃t�H�[�J�X���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/12</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            # region [��ʏ���]
            switch (e.PrevCtrl.Name)
            {
                // ���_�R�[�h
                case "tEdit_SectionCodeAllowZero":
                    {
                        string sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
                        string name;
                        if ( GetSectionName( sectionCode, out name ) )
                        {
                            this.tEdit_SectionName.Text = name;

                            if ( e.ShiftKey == false )
                            {
                                if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                                {
                                    if ( this.tEdit_SectionCodeAllowZero.Text.Trim() != string.Empty )
                                    {
                                        // �t�H�[�J�X�ړ�
                                        e.NextCtrl = this.GetNextEdit( e.PrevCtrl );
                                    }
                                }
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
                            else
                            {
                                if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                                {
                                    // �t�H�[�J�X�ړ�
                                    e.NextCtrl = this.GetPrevEdit( e.PrevCtrl );
                                }
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD
                        }
                        else
                        {
                            // �G���[���b�Z�[�W
                            TMsgDisp.Show( this, 					// �e�E�B���h�E�t�H�[��
                              emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                              ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                              "���_�����݂��܂���B", 			// �\�����郁�b�Z�[�W
                              0, 									// �X�e�[�^�X�l
                              MessageBoxButtons.OK );				// �\������{�^��

                            this.tEdit_SectionCodeAllowZero.Text = string.Empty;
                            this.tEdit_SectionName.Text = string.Empty;
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                case "tNedit_CustomerCode_St":
                case "tNedit_CustomerCode_Ed":
                case "tNedit_SupplierCd_St":
                case "tNedit_SupplierCd_Ed":
                case "tNedit_GoodsMakerCd_St":
                case "tNedit_GoodsMakerCd_Ed":
                case "tNedit_GoodsMGroup_St":
                case "tNedit_GoodsMGroup_Ed":
                case "tNedit_BLGloupCode_St":
                case "tNedit_BLGloupCode_Ed":
                case "tNedit_BLGoodsCode_St":
                case "tNedit_BLGoodsCode_Ed":
                    {
                        if ( !e.ShiftKey )
                        {
                            if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                            {
                                if ( e.PrevCtrl is TNedit )
                                {
                                    if ( (e.PrevCtrl as TNedit).GetInt() != 0 )
                                    {
                                        e.NextCtrl = this.GetNextEdit( e.PrevCtrl );
                                    }
                                }
                                else if ( e.PrevCtrl is TEdit )
                                {
                                    if ( (e.PrevCtrl as TEdit).Text != string.Empty )
                                    {
                                        e.NextCtrl = this.GetNextEdit( e.PrevCtrl );
                                    }
                                }
                            }
                        }
                        else
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
                            if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                            {
                                // �t�H�[�J�X�ړ�
                                e.NextCtrl = this.GetPrevEdit( e.PrevCtrl );
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD
                        }
                        break;
                    }
                // �O���b�h
                case "uGrid_Details":
                    {
                        if (!e.ShiftKey)
                        {
                            if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                            {
                                this.uGrid_Details.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode );
                                this.uGrid_Details.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );

                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
                            e.NextCtrl = e.PrevCtrl;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD
                        }
                        break;
                    }
            }
            # endregion

            # region [�t�H�[�J�X�ړ��̔�����]
            if ( e.PrevCtrl == tComboEditor_TargetDivide )
            {
                if ( !e.ShiftKey )
                {
                    if ( e.Key == Keys.Down )
                    {
                        if ( tEdit_SectionCodeAllowZero.Enabled && tEdit_SectionCodeAllowZero.Visible )
                        {
                            // ���_
                            e.NextCtrl = tEdit_SectionCodeAllowZero;
                        }
                        else if ( tNedit_CustomerCode_St.Enabled && tNedit_CustomerCode_St.Visible )
                        {
                            // ���Ӑ�(�J�n)
                            e.NextCtrl = tNedit_CustomerCode_St;
                        }
                        else
                        {
                            // �d����(�J�n)
                            e.NextCtrl = tNedit_SupplierCd_St;
                        }
                    }
                }
            }
            # endregion

            // �t�@���N�V�����{�^���\���X�V
            this.UpdateButtonToolEnabled();

            // �ړ���Ȃ���΂����ŉI��
            if (e.NextCtrl == null)
            {
                return;
            }

            # region [�ړ���ʂ̏���]
            switch (e.NextCtrl.Name)
            {
                // �O���b�h
                case "uGrid_Details":
                    {
                        if (!e.ShiftKey && e.PrevCtrl != uGrid_Details)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            {
                                // �������s
                                if ( this.Search() == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                }
                                else
                                {
                                    e.NextCtrl = tComboEditor_TargetDivide;
                                }
                            }
                            else if (e.Key == Keys.Up)
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                    if ( Standard_UGroupBox.Expanded == false )
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    else if ( Standard_UGroupBox.Expanded == true )
                                    {
                                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                                    }
                                    else
                                    {
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                }
                            }
                        }
                        break;
                    }
            }
            # endregion
        }

        #endregion �� Control Events

        /// <summary>
        /// �폜�ςݕ\���L���`�F�b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_StatusBar_ShowLogicalDelete_CheckedChanged( object sender, EventArgs e )
        {
            this.uGrid_Details.BeginUpdate();
            try
            {
                bool excludeLogicalDelete = !uCheckEditor_StatusBar_ShowLogicalDelete.Checked;

                // �O���b�h�\���؂�ւ�
                this.ExcludeLogicalDeleteFromGrid( excludeLogicalDelete );
                // �_���폜�L���؂�ւ�
                this._scmPrtSettingAcs.ExcludeLogicalDeleteFromView = excludeLogicalDelete; 
                // �X�N���[���|�W�V����������
                this.uGrid_Details.DisplayLayout.RowScrollRegions.Clear();
                this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();

                // �O���b�h�s�Đݒ�
                SettingGridRows( ref this.uGrid_Details );
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
            }
        }
        /// <summary>
        /// �폜�ς݃f�[�^�̕\���`�F�b�N�ύX
        /// </summary>
        /// <param name="excludeLogicalDelete"></param>
        private void ExcludeLogicalDeleteFromGrid( bool excludeLogicalDelete )
        {
            // �폜��
            uGrid_Details.DisplayLayout.Bands[0].Columns[SCMPrtSettingAcs.ct_COL_LOGICALDELETEDATE].Hidden = excludeLogicalDelete;
            uGrid_Details.DisplayLayout.Bands[0].Columns[SCMPrtSettingAcs.ct_COL_LOGICALDELETEDATE].Header.VisiblePosition = 0;
        }

        /// <summary>
        /// ��T�C�Y�̎��������`�F�b�N�ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged( object sender, EventArgs e )
        {
            if ( uCheckEditor_StatusBar_AutoFillToGridColumn.Checked )
            {
                // ��T�C�Y��������
                uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                // ��T�C�Y������������
                uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.None;

                // �����œK������
                for ( int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++ )
                {
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                }
                this.uGrid_Details.Refresh();
            }
        }

        /// <summary>
        /// �O���b�h�Z���X�V�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_AfterCellUpdate( object sender, CellEventArgs e )
        {
            uGrid_Details.UpdateData();
        }

        /// <summary>
        /// �O���b�h�E�o�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_Leave( object sender, EventArgs e )
        {
            // ActiveCell����
            if ( uGrid_Details.ActiveCell != null )
            {
                uGrid_Details.ActiveCell.Selected = false;
                uGrid_Details.ActiveCell = null;
            }

            // ActiveRow����
            if ( uGrid_Details.ActiveRow != null )
            {
                uGrid_Details.ActiveRow.Selected = false;
                uGrid_Details.ActiveRow = null;
            }

            // �{�^���\���X�V
            this.UpdateButtonToolEnabled();
        }

        /// <summary>
        /// �O���b�h�Z���_�u���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_DoubleClickCell( object sender, DoubleClickCellEventArgs e )
        {
            // �i�ҏW�j�ҏW�t�h�\��
            _editForm = new PMSCM09001UB( _scmPrtSettingAcs, _guideControl );
            _editForm.RecordGuid = this.GetRecordGuidFromGrid();
            _editForm.ShowDialog( this );

            _editForm.Dispose();
            _editForm = null;

            // �O���b�h�f�[�^�ݒ�
            CreateGrid( ref this.uGrid_Details );
            SettingGridRows( ref this.uGrid_Details );
            this.uGrid_Details.Refresh();            
        }
        /// <summary>
        /// �O���b�h�L�[�}�b�s���O
        /// </summary>
        /// <param name="grid"></param>
        private void MakeKeyMappingForGrid( Infragistics.Win.UltraWinGrid.UltraGrid grid )
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0,
                true );
            grid.KeyActionMappings.Add( enterMap );

            //----- Shift + Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true );
            grid.KeyActionMappings.Add( enterMap );

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true );
            grid.KeyActionMappings.Add( enterMap );

            //----- ���L�[ (�ŏ�i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true );
            grid.KeyActionMappings.Add( enterMap );

            //----- ���L�[ (�ŉ��i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true );
            grid.KeyActionMappings.Add( enterMap );

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true );
            grid.KeyActionMappings.Add( enterMap );

            //----- �O�ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true );
            grid.KeyActionMappings.Add( enterMap );

            //----- ���ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true );
            grid.KeyActionMappings.Add( enterMap );
        }
    }
}