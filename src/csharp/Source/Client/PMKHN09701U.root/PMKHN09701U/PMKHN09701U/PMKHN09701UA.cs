//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����񓚕i�ڐݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �����񓚕i�ڐݒ�}�X�^�̑�����s���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g�� �F��
// �� �� ��  2012/10/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �O�ˁ@�L��
// �� �� ��  2012/11/07  �C�����e : 12/12�z�M �V�X�e���e�X�g��Q��2�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g���@�F��
// �� �� ��  2012/11/13  �C�����e : 12/12�z�M �V�X�e���e�X�g��Q��1,2,3,4,10,12,13,15,16,17,18,19,23,24,26,27�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g���@�F��
// �� �� ��  2012/11/16  �C�����e : 12/12�z�M �V�X�e���e�X�g��Q��26,35,53�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g���@�F��
// �� �� ��  2012/11/21  �C�����e : 12/12�z�M �V�X�e���e�X�g��Q��57�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 �O�� �L��
// �� �� ��  2012/11/22  �C�����e : 2012/12/12�z�M�\��V�X�e���e�X�g��Q��63�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g���@�F��
// �� �� ��  2012/11/22  �C�����e : 2012/12/12�z�M�\��V�X�e���e�X�g��Q��77�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g���@�F��
// �� �� ��  2012/11/26  �C�����e : 2012/12/12�z�M�\��V�X�e���e�X�g��Q��80,81,82�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g���@�F��
// �� �� ��  2013/11/22  �C�����e : VSS[019] Redmine#677�Ή�
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
    /// �����񓚕i�ڐݒ�}�X�^�����e�i���XUI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �����񓚕i�ڐݒ�}�X�^�����e�i���XUI�t�H�[���N���X</br>
    /// </remarks>
    public partial class PMKHN09701UA : Form
    {
        #region �� Constants

        // �A�Z���u��ID
        private const string ASSEMBLY_ID = "PMKHN09701U";

        // ��ʏ�ԕۑ��p�t�@�C����
        private const string XML_FILE_INITIAL_DATA = "PMKHN09701U.dat";

        // �O���b�h��
        public const string COLUMN_NO = "No";

        private const string ERRORMSG_RANGE = "{0}�͈̔͂Ɍ�܂肪����܂�";

        private const string AUTOANSWER_DIV_NO_AUTOANSWER = "���Ȃ�";
        private const string AUTOANSWER_DIV_AUTOANSWER = "����(������)";
        private const string AUTOANSWER_DIV_AUTOANSWER_PRIORITY = "����(�D�揇��)";

        /// <summary>
        /// ���̍��ڂ�"�ݒ薳��"��\��
        /// �D�ǐݒ�ڍ׃R�[�h�Q�i��ʃR�[�h�j
        /// �D�揇��
        /// </summary>
        public const int NO_SETTING = 0;

        #endregion �� Constants

        #region �� Private Members

        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode;

        private AutoAnsItemStAcs _autoAnsItemStAcs; // �����񓚕i�ڐݒ�}�X�^�����e�i���X�A�N�Z�X�N���X
        private AutoAnsItemStGuideControl _guideControl; // �����񓚕i�ڐݒ�}�X�����K�C�h����N���X

        private PMKHN09701UB _editForm; // �ҏWUI

        // �O���b�h�ݒ萧��N���X
        private GridStateController _gridStateController;

        // ���o����
        private AutoAnsItemStOrder _extrInfo;

        private bool _closeFlg;

        // �V�K�ǉ��s�ύX�O���
        private string _sectionCode = "";               // ���_�R�[�h
        private int _customerCode = 0;                  // ���Ӑ�R�[�h
        private string _goodsMGroup = "";               // ���i�����ރR�[�h
        private string _blGoodsCode = "";               // BL�R�[�h
        private string _goodsMakerCode = "";            // Ұ������
        private string _prmSetDtlNo2 = "";              // ��ʃR�[�h
        private string _priorityOrder = "";             // �D�揇��
        private int _autoAnswerDiv = 0;                 // �����񓚋敪


        // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>
        // �������񕝕ۑ��p
        private int widthDelete = 0;            // �폜��
        private int widthNo = 0;                // ��
        private int widthSection = 0;           // ���_
        private int widthCustomer = 0;          // ���Ӑ�
        private int widthGoodsMGroup = 0;       // ���i������
        private int widthGoodsMGroupName = 0;   // ���i�����ޖ���
        private int widthBlCode = 0;            // BL�R�[�h
        private int widthBlCodeName = 0;        // BL�R�[�h����
        private int widthMaker = 0;             // ���[�J�[
        private int widthMakerName = 0;         // ���[�J�[����
        private int widthType = 0;              // �� ��
        private int widthTypeName = 0;          // ��ʖ���
        private int widthAutoAnsDiv = 0;        // �����񓚋敪
        private int widthPriority = 0;          // �D�揇��
        // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// ��ʏ���r�̗v�ۃt���O 
        /// true�F��r�v�@false�F��r�s�v�@
        /// </summary>
        private bool _needCompare = true;
        #endregion 

        #region �� Public Members

        public static DataView OfferPrimeSettingDataView;

        #endregion

        #region �� Constructor

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^�����e�i���XUI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �����񓚕i�ڐݒ�}�X�^�����e�i���XUI�t�H�[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// </remarks>
        public PMKHN09701UA()
		{
            InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �K�C�h����
            _guideControl = new AutoAnsItemStGuideControl( _enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim() );
            _guideControl.AfterRenewal += new EventHandler( GuideControl_AfterRenewal );

            this._autoAnsItemStAcs = new AutoAnsItemStAcs();
            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��1 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._autoAnsItemStAcs.EnterpriseCode = this._enterpriseCode;
            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��1 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            this._autoAnsItemStAcs.AfterTableUpdate += new EventHandler(AutoAnsItemStAcs_AfterTableUpdate);

            this._gridStateController = new GridStateController();

            // ��ʏ����ݒ�
            SetInitialSetting();

            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��26 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // ����N�����̂݁@�O���b�h�񕝂̐ݒ�
            if (this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details) != 0)
            {
               GridWidthSet();
            }
            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��26 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // ��ʃN���A
            ClearScreen();

            // �D�ǐݒ�}�X�^�̎擾
            int status = this._autoAnsItemStAcs.GetOfferPrimesettingList(ref OfferPrimeSettingDataView);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                status != (int)ConstantManagement.DB_Status.ctDB_EOF &&
                status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {

                // �T�[�`
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                    ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    this.Name, 			                // �v���O��������
                    "PMKHN09701UA", 			        // ��������
                    TMsgDisp.OPE_GET, 					// �I�y���[�V����
                    "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                    status, 							// �X�e�[�^�X�l
                    this._autoAnsItemStAcs, 	        // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 				// �\������{�^��
                    MessageBoxDefaultButton.Button1);	// �����\���{�^��
            }
        }
        #endregion �� Constructor

        #region �� Private Methods

        #region XML����
        /// <summary>
        /// �w�l�k�f�[�^�̓Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ�ԕێ��p�̂w�l�k�̓Ǎ��������s���܂��B</br>
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
        /// <summary>
        /// ���Ӑ於�擾
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadCustomer(ref int code, out string name)
        {
            // ���������Z�b�g
            CustomerSearchPara para = new CustomerSearchPara();
            para.EnterpriseCode = _enterpriseCode;
            para.CustomerCode = code;

            // �������s
            CustomerSearchRet[] retList;
            int status = _guideControl.CustomerSearchAcs.Serch(out retList, para);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null && retList.Length > 0)
            {
                name = retList[0].Name;
                return true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// ���[�J�[���擾
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadMaker(ref int code, out string name)
        {
            bool rtn = false;
            MakerUMnt maker;
            int status = _guideControl.MakerAcs.Read(out maker, this._enterpriseCode, code);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && maker != null)
            {
                name = maker.MakerName;
                rtn = true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                rtn = false;
            }

            return rtn;
        }

        /// <summary>
        /// ���i�����ޖ��擾
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadGoodsMGroup(ref int code, out string name)
        {
            GoodsGroupU goodsGroupU;
            int status = _guideControl.GoodsAcs.GetGoodsMGroup(_enterpriseCode, code, out goodsGroupU);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsGroupU != null)
            {
                name = goodsGroupU.GoodsMGroupName;
                return true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// �a�k�R�[�h���擾
        /// �a�k�R�[�h�ɕR�Â����i�����ނ��擾
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="goodsMGroup"></param>
        /// <returns></returns>
        private bool ReadBLCode(ref int code, out string name,out int goodsMGroup)
        {
            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = _guideControl.BLGoodsCdAcs.Read(out blGoodsCdUMnt, _enterpriseCode, code);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && blGoodsCdUMnt != null)
            {
                name = blGoodsCdUMnt.BLGoodsFullName;
                goodsMGroup = blGoodsCdUMnt.GoodsRateGrpCode;    // ���i������
                return true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                goodsMGroup = 0;
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
            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��10 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��10 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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
            this.uButton_GoodsMakerCd_St.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMakerCd_Ed.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMGroup_St.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMGroup_Ed.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
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
        /// </remarks>
        private void ClearScreen()
        {
            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��12 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            tComboEditor_TargetDivide.Focus();
            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��12 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // �Ώۋ敪
            this.tComboEditor_TargetDivide.Value = 0;

            // ���_
            this.tEdit_SectionCodeAllowZero.Clear();
            this.tEdit_SectionName.Clear();
            // ���Ӑ�R�[�h
            this.tNedit_CustomerCode_St.Clear();
            this.tNedit_CustomerCode_Ed.Clear();
            // ���[�J�[�R�[�h
            this.tNedit_GoodsMakerCd_St.Clear();
            this.tNedit_GoodsMakerCd_Ed.Clear();
            // ���i�����ރR�[�h
            this.tNedit_GoodsMGroup_St.Clear();
            this.tNedit_GoodsMGroup_Ed.Clear();
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
        /// </remarks>
        private void ClearGrid()
        {
            // �O���b�h�쐬����
            CreateGrid(ref this.uGrid_Details);
            // �L�[�}�b�s���O�ݒ�
            MakeKeyMappingForGrid( this.uGrid_Details );

            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��18,��19 --------->>>>>>>>>>>>>>>>>>>>>>>>
            // �V�K�ǉ��s�@�ǉ�����
            this._autoAnsItemStAcs.RowAdd();
            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��18,��19 ---------<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// �O���b�h�V�K�ǉ��s����������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �O���b�h�̐V�K�ǉ��s�̏��������s���܂��B</br>
        /// </remarks>
        private void ClearGridNewAddRow()
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value = string.Empty;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value = string.Empty;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Value = string.Empty;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value = string.Empty;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Value = string.Empty;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_MAKERNAME].Value = string.Empty;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Value = string.Empty;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Value = string.Empty;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value = (int)AutoAnsItemStAcs.AutoAnswerDiv.None;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV_BACKUP].Value = (int)AutoAnsItemStAcs.AutoAnswerDiv.None;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value = string.Empty;

            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWDIV].Value = (int)AutoAnsItemStAcs.NewAddRowDiv.New;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWALLOWSAVE].Value = (int)AutoAnsItemStAcs.NewAddRowAllowSave.No;

            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE_SORT].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE_SORT].Value = int.MaxValue; // �ꗗ�ŉ��s�ɕ\�����邽�ߍő�l�Ƃ���
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD_SORT].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP_SORT].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2_SORT].Value = 0;
            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE_SORT].Value = string.Empty;
        }

        #endregion �N���A����

        #region �ۑ�
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ۑ��������s���܂��B</br>
        /// </remarks>
        private int Save()
        {
            tComboEditor_TargetDivide.Focus();

            # region [�X�V���R�[�h�L���`�F�b�N]
            if (_autoAnsItemStAcs.GetUpdateCountFromTable() == 0)
            {
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                    "�X�V�Ώۂ̃f�[�^�����݂��܂���",// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            # endregion
            
            #region [�ۑ��O�e��`�F�b�N]
            string msg = string.Empty;
            if (!CheckBeforeSave(out msg))
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               msg,
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            #endregion

            // �X�V����
            string errMsg;
            int status = _autoAnsItemStAcs.WriteAll( out errMsg );

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
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
                // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��1 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���͂��ꂽ�i�ڐݒ�͊��ɓo�^����Ă��܂��B", 	                    // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);			// �\������{�^��
                        break;
                    }
                // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��1 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
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

            return status;
        }
        #endregion �ۑ�

        #region ����
        /// <summary>
        /// ��������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �����������s���܂��B</br>
        /// </remarks>
        private int Search()
        {
            // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��53 --------->>>>>>>>>>>>>>>>>>>>>>>>
            GridWidthSave();
            // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��53 ---------<<<<<<<<<<<<<<<<<<<<<<<<

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
                _extrInfo = new AutoAnsItemStOrder();
            }
            AutoAnsItemStOrder extrInfoClone = _extrInfo.Clone();
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
            msgForm.Message = "�����񓚕i�ڐݒ�}�X�^�̒��o���ł��B";

            string msg;

            try
            {
                msgForm.Show();

                // ��������
                status = this._autoAnsItemStAcs.Search( _extrInfo, out msg );
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF)
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
        /// </remarks>
        private void SetExtrInfo(out AutoAnsItemStOrder para)
        {
            para = new AutoAnsItemStOrder();

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

            // ���[�J�[
            para.St_GoodsMakerCd = tNedit_GoodsMakerCd_St.GetInt();
            para.Ed_GoodsMakerCd = tNedit_GoodsMakerCd_Ed.GetInt();
            // ���i������
            para.St_GoodsMGroup = tNedit_GoodsMGroup_St.GetInt();
            para.Ed_GoodsMGroup = tNedit_GoodsMGroup_Ed.GetInt();
            // �a�k�R�[�h
            para.St_BLGoodsCode = tNedit_BLGoodsCode_St.GetInt();
            para.Ed_BLGoodsCode = tNedit_BLGoodsCode_Ed.GetInt();
        }

        #endregion ����

        #region �ŐV���擾
        /// <summary>
        /// �ŐV���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ŐV���擾�������s���܂��B</br>
        /// </remarks>
        private void Renewal()
        {
            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��11 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            tComboEditor_TargetDivide.Focus();
            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��11 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // ���b�Z�[�W�\��
            DialogResult dialogResult = TMsgDisp.Show(
            this,
            emErrorLevel.ERR_LEVEL_INFO,
            this.Name,
            "��ʏ��̓N���A����܂��B" + "\r\n" + "\r\n" +
            "��낵���ł����H",
            0,
            MessageBoxButtons.YesNo,
            MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.No) return;


            // �ŐV���擾
            _guideControl.Renewal();

            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                       "�ŐV�����擾���܂����B",
                       0,
                       MessageBoxButtons.OK,
                       MessageBoxDefaultButton.Button1);

            return;
        }

        #endregion

        #region �`�F�b�N����
        /// <summary>
        /// ���������`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �����������`�F�b�N���܂��B</br>
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
        /// �召��r�`�F�b�N����
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
        /// </remarks>
        public static bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
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
        /// </remarks>
        public bool CompareScreen()
        {
            if (this._closeFlg)
            {
                return true;
            }

            // ��ʏ���r�@�v�۔���
            if (!this._needCompare)
            {
                return true;
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
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            return (_autoAnsItemStAcs.GetUpdateCountFromTable() == 0);
        }


        /// <summary>
        /// �V�K�ǉ��s �ҏW�ς݃`�F�b�N
        /// </summary>
        /// <returns>�X�e�[�^�X(-1:�����͍��ڂ���@0:�K�{���ړ��͍ς�  1:�S���ږ�����)</returns>
        /// <remarks>
        /// <br>Note        : �V�K�ǉ��s�ɕҏW���s���Ă��邩���肷��</br>
        /// </remarks>
        private int CheckRowNewAdd(UltraGridRow row)
        {
            int ret = 1;

            string sectionCode = row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Text;
            int customerCode = 0;
            int.TryParse(row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Text, out customerCode);
            int goodsMGroupCode = 0;
            int.TryParse(row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Text, out goodsMGroupCode);
            int blGoodsCode = 0;
            int.TryParse(row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Text, out blGoodsCode);
            int goodsMakerCode = 0;
            int.TryParse(row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Text, out goodsMakerCode);
            int priorityOrder = 0;
            int.TryParse(row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Text, out priorityOrder);

            // �S�Ė����͂̎��̓`�F�b�N�ΏۊO
            if (sectionCode.Length == 0
                && customerCode == 0
                && row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Text.Trim().Length == 0
                && blGoodsCode == 0
                && goodsMakerCode == 0
                && priorityOrder == 0
               )
            {
                return ret;
            }

            // ���͕K�{���ڂɓ��͂���Ă��邩
            // ���_�R�[�h�E���Ӑ�R�[�h�������͂̓G���[
            if (sectionCode.Length == 0 && customerCode == 0)
            {
                ret = -1;
            }
            // ���i�����ޖ����͂̓G���[
            else if (row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Text.Trim().Equals(string.Empty))
            {
                ret = -1;
            }
            // ���[�J�[�R�[�h�����͂̓G���[
            else if (goodsMakerCode == 0)
            {
                ret = -1;
            }
            // �����񓚋敪���u����i�D�揇�ʁj�v�̎��A�D�揇�ʂ������͂̓G���[
            else if ((int)row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value == (int)AutoAnsItemStAcs.AutoAnswerDiv.Priority
                     && priorityOrder == 0)
            {
                ret = -1;
            }
            else
            {
                ret = 0;
            }
            return ret;
        }

        /// <summary>
        /// �ۑ��O�̊e��`�F�b�N���s��
        /// �E�V�K�ǉ��s �d���`�F�b�N
        /// �E�V�K�ǉ��s�@���_�A���Ӑ�̓��͏�ԃ`�F�b�N
        /// </summary>
        /// <returns>�X�e�[�^�X(true:�G���[����  false:�G���[�L��)</returns>
        /// <remarks>
        /// </remarks>
        private bool CheckBeforeSave(out string msg)
        {
            bool ret = true;
            msg = string.Empty;

            foreach (UltraGridRow row in this.uGrid_Details.Rows)
            {
                string filter = string.Empty;

                #region �V�K�ǉ��s
                // �V�K�ǉ��s
                if (IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWDIV].Value).Equals((int)AutoAnsItemStAcs.NewAddRowDiv.New)
                    && IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWALLOWSAVE].Value).Equals((int)AutoAnsItemStAcs.NewAddRowAllowSave.Yes))
                {
                    #region �V�K�ǉ��s�@���_�A���Ӑ�̓��͏�ԃ`�F�b�N
                    // ���_�R�[�h�A���Ӑ�R�[�h�����͂̓G���[
                    if (string.IsNullOrEmpty(row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim())
                        && IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value).Equals(0))
                    {
                        msg = "���_�R�[�h�����Ӑ�R�[�h����͂��Ă��������B\n";
                        msg += "�s���F" + row.Cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value.ToString();
                        ret = false;
                        break;
                    }
                    // ���_�R�[�h�A���Ӑ�R�[�h�̓������͂̓G���[
                    else if (!string.IsNullOrEmpty(row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim())
                        && !IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value).Equals(0))
                    {
                        msg = "���_�R�[�h�Ɠ��Ӑ�R�[�h�̓������͂͂ł��܂���B\n";
                        msg += "�s���F" + row.Cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value.ToString();
                        ret = false;
                        break;
                    }
                    #endregion

                    #region �V�K�ǉ��s�@�K�{���̓`�F�b�N
                    if (!CheckRowNewAdd(row).Equals(0))
                    {
                        msg = string.Format("�K�{���ڂ����͂���Ă��܂���B\n�s��{0}",
                                            row.Cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value.ToString().Trim());
                        ret = false;
                        break;
                    }
                    #endregion

                    #region �V�K�ǉ��s�d���`�F�b�N
                    filter = string.Format("{0}='{1}' AND {2}={3} AND {4}={5} AND {6}={7} AND {8}={9} AND {10}={11} AND {12}<{13}",
                                          AutoAnsItemStAcs.ct_COL_SECTIONCODE,
                                          row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString(),
                                          AutoAnsItemStAcs.ct_COL_CUSTOMERCODE,
                                          row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value.ToString(),
                                          AutoAnsItemStAcs.ct_COL_GOODSMGROUP,
                                          row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString(),
                                          AutoAnsItemStAcs.ct_COL_BLGOODSCODE,
                                          IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value).ToString(),
                                          AutoAnsItemStAcs.ct_COL_GOODSMAKERCD,
                                          row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value.ToString(),
                                          AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2,
                                          row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Value.ToString(),
                                          AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY,
                                          row.Cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value.ToString());
                    int rowCount = _autoAnsItemStAcs.GetRowForMaintenance(filter);

                    // �d�����Ă��鎞�G���[
                    if (rowCount > 0)
                    {
                        msg = string.Format("�s��{0}���d�����Ă��܂��B",
                                            row.Cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value.ToString().Trim());
                        ret = false;
                        break;
                    }
                    #endregion

                }
                #endregion

                #region �D�揇�ʂ̓��̓`�F�b�N
                if (IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value).Equals((int)AutoAnsItemStAcs.AutoAnswerDiv.Priority)
                     && IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value).Equals(0))
                {
                    msg = string.Format("�D�揇�ʂ����͂���Ă��܂���B\n�s��{0}",
                                        row.Cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value.ToString().Trim());
                    ret = false;
                    break;
                }
                #endregion

                #region �D�揇�ʏd���`�F�b�N
                // �����񓚋敪�F�D�揇�ʁ@�ȊO�͑ΏۊO
                if (IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value).Equals((int)AutoAnsItemStAcs.AutoAnswerDiv.Priority))
                {
                    // ADD 2012/11/26 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��80 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    filter = string.Empty;

                    if (string.IsNullOrEmpty(row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim()))
                    {
                        filter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' ",
                                               AutoAnsItemStAcs.ct_COL_CUSTOMERCODE.ToString(),
                                               row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value.ToString(),
                                               AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(),
                                               row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString(),
                                               AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(),
                                               row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString(),
                                               AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY.ToString(),
                                               row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value);
                    }
                    else
                    {
                        filter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' ",
                                               AutoAnsItemStAcs.ct_COL_SECTIONCODE.ToString(),
                                               row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString(),
                                               AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(),
                                               row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString(),
                                               AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(),
                                               row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString(),
                                               AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY.ToString(),
                                               row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value);
                    }

                    int retCount = 0;
                    List<AutoAnsItemSt> retList = this._autoAnsItemStAcs.GetRecordListForMaintenance(filter, retCount);

                    if (retList != null && retList.Count > 1)
                    {
                        msg = "�D�揇�ʂ��d�����Ă��܂��B\n";
                        if (!string.IsNullOrEmpty(row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim()))
                        {
                            msg += "���_�F" + row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim();
                        }
                        else
                        {
                            msg += "���Ӑ�F" + row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value.ToString().Trim();
                        }
                        msg += "�C���i�����ށF" + row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString().Trim();
                        msg += "�CBL�R�[�h�F" + row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString().Trim();
                        ret = false;
                        break;
                    }
                    // ADD 2012/11/26 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��80 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                    // --- UPD 2012/11/22 �O�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��63 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    #region �폜
                    //bool isSection = false;
                    //filter = string.Empty;

                    //if (string.IsNullOrEmpty(row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim()))
                    //{
                    //    filter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}'",
                    //                           AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(),
                    //                           row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString(),
                    //                           AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(),
                    //                           row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString(),
                    //                           AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY.ToString(),
                    //                           row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value);
                    //}
                    //else
                    //{
                    //    isSection = true;
                    //    filter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' ",
                    //                           AutoAnsItemStAcs.ct_COL_SECTIONCODE.ToString(),
                    //                           row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString(),
                    //                           AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(),
                    //                           row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString(),
                    //                           AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(),
                    //                           row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString(),
                    //                           AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY.ToString(),
                    //                           row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value);
                    //}

                    //int retCount = 0;
                    //List<AutoAnsItemSt> retList = this._autoAnsItemStAcs.GetRecordListForMaintenance(filter, retCount);

                    //if (retList != null && retList.Count > 1)
                    //{
                    //    msg = "�D�揇�ʂ��d�����Ă��܂��B\n";
                    //    if (isSection)
                    //    {
                    //        msg += "���_�F" + row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim();
                    //    }
                    //    else
                    //    {
                    //        msg += "�C���Ӑ�F" + row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value.ToString().Trim();
                    //    }
                    //    msg += "�C���i�����ށF" + row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString().Trim();
                    //    msg += "�CBL�R�[�h�F" + row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString().Trim();
                    //    ret = false;
                    //    break;
                    //}
                    #endregion
                    AutoAnsItemSt autoAnsItemSt = new AutoAnsItemSt();                                          // ���R�[�h�擾
                    autoAnsItemSt.EnterpriseCode = this._enterpriseCode;                                        // ��ƃR�[�h
                    autoAnsItemSt.SectionCode = row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString();// ���_�R�[�h
                    autoAnsItemSt.CustomerCode = (int)row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value;    // ���Ӑ�R�[�h
                    autoAnsItemSt.GoodsMGroup = (int)row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value;      // ���i�����ރR�[�h
                    autoAnsItemSt.BLGoodsCode = (int)row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value;      // �a�k�R�[�h
                    autoAnsItemSt.GoodsMakerCd = (int)row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value;    // ���[�J�[�R�[�h
                    autoAnsItemSt.PrmSetDtlNo2 = (int)row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Value;    // ��ʃR�[�h
                    autoAnsItemSt.PriorityOrder = (int)row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value;  // �D�揇��
                    List<AutoAnsItemSt> _autoAnsItemStList = new List<AutoAnsItemSt>();
                    int retStatus = _autoAnsItemStAcs.Read2(autoAnsItemSt, ref _autoAnsItemStList, true);
                    if (retStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ADD 2012/11/26 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��80 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        msg = string.Empty;
                        // ADD 2012/11/26 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��80 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        foreach (AutoAnsItemSt autoAnsItem in _autoAnsItemStList)
                        {
                            // ADD 2012/11/26 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��80 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            filter = string.Empty;

                            if (string.IsNullOrEmpty(row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim()))
                            {
                                filter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' ",
                                                       AutoAnsItemStAcs.ct_COL_CUSTOMERCODE.ToString(),
                                                       autoAnsItem.CustomerCode,
                                                       AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(),
                                                       autoAnsItem.GoodsMGroup,
                                                       AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(),
                                                       autoAnsItem.BLGoodsCode,
                                                       AutoAnsItemStAcs.ct_COL_GOODSMAKERCD.ToString(),
                                                       autoAnsItem.GoodsMakerCd);
                            }
                            else
                            {
                                filter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' ",
                                                       AutoAnsItemStAcs.ct_COL_SECTIONCODE.ToString(),
                                                       autoAnsItem.SectionCode,
                                                       AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(),
                                                       autoAnsItem.GoodsMGroup,
                                                       AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(),
                                                       autoAnsItem.BLGoodsCode,
                                                       AutoAnsItemStAcs.ct_COL_GOODSMAKERCD.ToString(),
                                                       autoAnsItem.GoodsMakerCd);
                            }

                            // ��ʂɕ\������Ă���Δ�΂�
                            List<AutoAnsItemSt> retList2 = this._autoAnsItemStAcs.GetRecordListForMaintenance(filter, retCount);
                            if (retList2.Count > 0)
                            {
                                continue;
                            }
                            // ADD 2012/11/26 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��80 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                            if ((autoAnsItem.GoodsMakerCd != autoAnsItemSt.GoodsMakerCd) || (autoAnsItem.PrmSetDtlNo2 != autoAnsItemSt.PrmSetDtlNo2))
                            {
                                // ���[�J�[���͎�ʂ��Ⴄ�i�����R�[�h�ȊO�j
                                if (autoAnsItem.PriorityOrder == autoAnsItemSt.PriorityOrder)
                                {
                                    msg = "�D�揇�ʂ��d�����Ă��܂��B\n";
                                    if (!string.IsNullOrEmpty(row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim()))
                                    {
                                        msg += "���_�F" + row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim();
                                    }
                                    else
                                    {
                                        msg += "���Ӑ�F" + row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value.ToString().Trim();
                                    }
                                    msg += "�C���i�����ށF" + row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString().Trim();
                                    msg += "�CBL�R�[�h�F" + row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString().Trim();
                                    ret = false;
                                    break;
                                }
                            }
                        }
                        // ADD 2012/11/26 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��80 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        if (msg != string.Empty)
                        {
                            break;
                        }
                        // ADD 2012/11/26 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��80 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                    // --- UPD 2012/11/22 �O�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��63 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
            #endregion

            return ret;
        }

        /// <summary>
        /// �V�K�ǉ��s ���_�R�[�h���̓`�F�b�N
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�X�e�[�^�X(True:�G���[�Ȃ��@False:�G���[����)</returns>
        /// <remarks>
        /// <br>Note        : ���_�R�[�h�̓��̓`�F�b�N���s���܂�</br>
        /// </remarks>
        private bool CheckRowSectionCode(ref string sectionCode, out string sectionName)
        {
            bool ret = true;
            sectionName = string.Empty;

            // ���_�R�[�h���݃`�F�b�N
            if (!string.IsNullOrEmpty(sectionCode))
            {
                if (!GetSectionName(sectionCode, out sectionName))
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "���_�R�[�h�����݂��܂���B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                    ret = false;
                }

                sectionCode = sectionCode.Trim().PadLeft(2, '0');
            }
            return ret;
        }

        /// <summary>
        /// �V�K�ǉ��s ���Ӑ�R�[�h���̓`�F�b�N
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>�X�e�[�^�X(True:�G���[�Ȃ��@False:�G���[����)</returns>
        /// <remarks>
        /// <br>Note        : ���Ӑ�R�[�h�̓��̓`�F�b�N���s���܂�</br>
        /// </remarks>
        private bool CheckRowCustomerCode(int customerCode, out string customerName)
        {
            bool ret = true;
            customerName = string.Empty;

            // ���Ӑ�R�[�h���݃`�F�b�N
            if (customerCode != 0)
            {
                if (!ReadCustomer(ref customerCode, out customerName))
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "���Ӑ�R�[�h�����݂��܂���B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                    ret = false;
                }
            }
            return ret;
        }

        /// <summary>
        /// �V�K�ǉ��s ���i�����ރR�[�h���̓`�F�b�N
        /// </summary>
        /// <param name="goodsMGroup">���i�����ރR�[�h</param>
        /// <returns>�X�e�[�^�X(True:�G���[�Ȃ��@False:�G���[����)</returns>
        /// <remarks>
        /// <br>Note        : ���i�����ރR�[�h�̓��̓`�F�b�N���s���܂�</br>
        /// </remarks>
        private bool CheckRowGoodsMGroup(ref string goodsMGroup, out string goodsMGroupName, out int goodsMGroupCode)
        {
            bool ret = true;
            goodsMGroupCode = 0;
            goodsMGroupName = string.Empty;

            // ���i�����ރR�[�h���݃`�F�b�N
            if (!string.IsNullOrEmpty(goodsMGroup))
            {
                int.TryParse(goodsMGroup, out goodsMGroupCode);

                if (goodsMGroupCode == 0)
                {
                    goodsMGroup = "0000";
                    goodsMGroupName = "����";
                }
                else
                {
                    if (!ReadGoodsMGroup(ref goodsMGroupCode, out goodsMGroupName))
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "���i�����ރR�[�h�����݂��܂���B",
                                       0,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);
                        ret = false;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// �V�K�ǉ��s �a�k�R�[�h���̓`�F�b�N
        /// </summary>
        /// <param name="goodsMGroup">���i�����ރR�[�h</param>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <returns>�X�e�[�^�X(True:�G���[�Ȃ��@False:�G���[����)</returns>
        /// <remarks>
        /// <br>Note        : BL�R�[�h�̓��̓`�F�b�N���s���܂�</br>
        /// </remarks>
        private bool CheckRowBLCode(out int goodsMGroup, ref string blGoodsCode, out string blGoodsName, out int blGoodsCodeNum)
        {
            bool ret = true;
            blGoodsCodeNum = 0;
            blGoodsName = string.Empty;
            goodsMGroup = 0;

            int.TryParse(blGoodsCode, out blGoodsCodeNum);

            // BL�R�[�h���݃`�F�b�N
            if (!string.IsNullOrEmpty(blGoodsCode))
            {
                if (blGoodsCodeNum == 0)
                {
                    blGoodsCode = "00000";
                    blGoodsName = "����";
                }
                else
                {
                    if (!ReadBLCode(ref blGoodsCodeNum, out blGoodsName,out goodsMGroup))
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "�a�k�R�[�h�����݂��܂���B",
                                       0,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);
                        ret = false;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// �V�K�ǉ��s ���[�J�[�R�[�h���̓`�F�b�N
        /// </summary>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <returns>�X�e�[�^�X(True:�G���[�Ȃ��@False:�G���[����)</returns>
        /// <remarks>
        /// <br>Note        : ���[�J�[�R�[�h�̓��̓`�F�b�N���s���܂�</br>
        /// </remarks>
        private bool CheckRowMakerCode(string goodsMakerCode, out string goodsMakerName)
        {
            bool ret = true;
            goodsMakerName = string.Empty;
            int makerCode = 0;
            int.TryParse(goodsMakerCode, out makerCode);

            // ���[�J�[�R�[�h�����͎��͉������Ȃ�
            if (string.IsNullOrEmpty(goodsMakerCode) || makerCode == 0)
            {
                return true;
            }

            // ���[�J�[�R�[�h���݃`�F�b�N
            if (!ReadMaker(ref makerCode, out goodsMakerName))
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "���[�J�[�R�[�h�����݂��܂���B",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                ret = false;
            }
            return ret;
        }

        /// <summary>
        /// �V�K�ǉ��s ��ʃR�[�h���̓`�F�b�N
        /// </summary>
        /// <param name="prmSetDtlNo2">��ʃR�[�h</param>
        /// <returns>�X�e�[�^�X(True:�G���[�Ȃ��@False:�G���[����)</returns>
        /// <remarks>
        /// <br>Note        : ��ʃR�[�h�̓��̓`�F�b�N���s���܂�</br>
        /// </remarks>
        private bool CheckRowPrmSetDtlNo2(string prmSetDtlNo2, string goodsMGroupCode, string goodsMakerCode, string blGoodsCode, out string prmSetDtlNo2Name, out int prmSetDtlNo2Num)
        {

            bool ret = true;
            prmSetDtlNo2Name = string.Empty;
            int goodsMGroup = 0;
            int makerCode = 0;
            int blCode = 0;
            prmSetDtlNo2Num = 0;

            int.TryParse(goodsMGroupCode, out goodsMGroup);
            int.TryParse(goodsMakerCode, out makerCode);
            int.TryParse(blGoodsCode, out blCode);
            int.TryParse(prmSetDtlNo2, out prmSetDtlNo2Num);

            // ���i�����ރR�[�h�A���[�J�[�R�[�h�ABL�R�[�h�̎w�肪�Ȃ��ꍇ�A��ʃR�[�h�̓��͂̓G���[
            if ((goodsMGroup == 0 || makerCode == 0 || blCode == 0) && prmSetDtlNo2Num != 0)
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                               "���i�����ށA�a�k�R�[�h�A���[�J�[�R�[�h����͂��Ă��������B",
                               0,
                               MessageBoxButtons.OK,
                               MessageBoxDefaultButton.Button1);
                ret = false;
            }

            // ��ʃR�[�h���݃`�F�b�N
            if (!string.IsNullOrEmpty(prmSetDtlNo2))
            {
                // ��ʋN�����Ɏ擾���Ă���D�ǐݒ�}�X�^���擾
                DataView dv = OfferPrimeSettingDataView;
                // ����������ݒ�
                string filter = PrimeSettingInfo.COL_PARTSMAKERCD + " = " + makerCode.ToString() + " AND " +
                                PrimeSettingInfo.COL_TBSPARTSCODE + " = " + blCode.ToString() + " AND " +
                                PrimeSettingInfo.COL_MIDDLEGENRECODE + " = " + goodsMGroup.ToString() + " AND " +
                                PrimeSettingInfo.COL_PRIMEKINDCODE + " = "  + prmSetDtlNo2Num.ToString() ;
                dv.RowFilter = filter;

                if (dv.Count == 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "��ʃR�[�h�����݂��܂���B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                    ret = false;
                }
                else
                {
                    prmSetDtlNo2Name = dv[0][PrimeSettingInfo.COL_PRIMEKINDNAME].ToString();
                }

                // ���ꃁ�[�J�[���Ŏ�ʃR�[�h���d�����Ă��鎞�A�G���[
                if (IsPrmSetDtlNo2Duplicate())
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "��ʃR�[�h���d�����Ă��܂��B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                    ret = false;
                }
            }
            return ret;
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
        /// </remarks>
        private void CreateGrid(ref UltraGrid uGrid)
        {
            uGrid.DataSource = null;

            // �f�[�^�\�[�X�ƂȂ�DataView���A�N�Z�X�N���X����擾
            DataView view = _autoAnsItemStAcs.DataViewForMstList;
            
            uGrid.DataSource = view;
           
            // �_���폜�L��
            _autoAnsItemStAcs.ExcludeLogicalDeleteFromView = !this.uCheckEditor_StatusBar_ShowLogicalDelete.Checked;

            // �O���b�h�X�^�C���ݒ�
            SetGridLayout( ref uGrid );

            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��3 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this.UpdateButtonToolEnabled();
            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��3 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// �O���b�h�X�^�C���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �O���b�h�̃X�^�C����ݒ肵�܂��B</br>
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

                // �s��
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Hidden = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��16 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Header.Caption = "�s��";
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Header.Caption = "��";
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��16 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Header.Appearance.TextHAlign = HAlign.Right;
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellAppearance.TextHAlign = HAlign.Right;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��15 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                //columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.RowAppearance.BackColor;
                //columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
                //columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��15 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellActivation = Activation.Disabled;
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].CellActivation = Activation.NoEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Width = 50;
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Width = widthNo;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Header.VisiblePosition = visiblePosition++;

                // �폜��
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Hidden = !this.uCheckEditor_StatusBar_ShowLogicalDelete.Checked;
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Header.Caption = "�폜��";
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].CellAppearance.ForeColor = Color.Red;
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].CellActivation = Activation.NoEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Width = 100;
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Width = widthDelete;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Header.VisiblePosition = visiblePosition++;

                // ���_�R�[�h
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Hidden = (selectValue == 2);
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Header.Caption = "���_";
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].CellActivation = Activation.AllowEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Width = 50;
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Width = widthSection;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Header.VisiblePosition = visiblePosition++;

                // ���Ӑ�R�[�h
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Hidden = (selectValue == 1);
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Header.Caption = "���Ӑ�";
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].CellActivation = Activation.AllowEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Width = 80;
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Width = widthCustomer;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Format = GetCustomerFormat();
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Header.VisiblePosition = visiblePosition++;

                // ���i�����ރR�[�h
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Header.Caption = "���i������";
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].CellActivation = Activation.AllowEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Width = 100;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Width = widthGoodsMGroup;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Header.VisiblePosition = visiblePosition++;

                // ���i�����ޖ���
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Header.Caption = "����";
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].CellActivation = Activation.Disabled;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Width = 150;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Width = widthGoodsMGroupName;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Header.VisiblePosition = visiblePosition++;

                // BL�R�[�h
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Header.Caption = "BL����";
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].CellActivation = Activation.AllowEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Width = 60;
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Width = widthBlCode;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Header.VisiblePosition = visiblePosition++;

                // BL�R�[�h����
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Header.Caption = "����";
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].CellActivation = Activation.Disabled;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Width = 150;
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Width = widthBlCodeName;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Header.VisiblePosition = visiblePosition++;

                // ���i���[�J�[�R�[�h
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Header.Caption = "Ұ��";
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].CellActivation = Activation.AllowEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Width = 50;
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Width = widthMaker;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Format = GetMakerFormat();
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Header.VisiblePosition = visiblePosition++;

                // ���i���[�J�[����
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].Header.Caption = "����";
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].CellActivation = Activation.Disabled;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].Width = 150;
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].Width = widthMakerName;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].Header.VisiblePosition = visiblePosition++;

                // ���
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Header.Caption = "���";
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].CellActivation = Activation.Disabled;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Width = 50;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Width = widthType;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Header.VisiblePosition = visiblePosition++;

                // ��ʖ���
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Header.Caption = "����";
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].CellActivation = Activation.Disabled;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Width = 100;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Width = widthTypeName;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Header.VisiblePosition = visiblePosition++;

                // �����񓚋敪
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Header.Caption = "�����񓚋敪";
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellAppearance.ForeColorDisabled = Color.Black;
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellAppearance.BackColorDisabled = Color.LightGray;
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellActivation = Activation.AllowEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Width = 130;
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Width = widthAutoAnsDiv;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList(0);
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Header.VisiblePosition = visiblePosition++;

                uGrid_Details.CellListSelect += null;
                uGrid_Details.CellListSelect += new CellEventHandler(this.uGrid_Details_CellListSelect);


                // �D�揇��
                columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Hidden = false;
                columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Header.Caption = "�D�揇��";
                columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Header.Fixed = false;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Header.Appearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Header.Appearance.TextHAlign = HAlign.Center;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��17 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].CellAppearance.TextHAlign = HAlign.Left;
                columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].CellActivation = Activation.AllowEdit;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Width = 80;
                columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Width = widthPriority;
                // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Header.VisiblePosition = visiblePosition++;

                # endregion

                # region [�Z�������ݒ�]
                List<string> colNameList = new List<string>( new string[] 
                                            { 
                                                AutoAnsItemStAcs.ct_COL_SECTIONCODE, 
                                                AutoAnsItemStAcs.ct_COL_CUSTOMERCODE, 
                                                AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY,
                                                AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME,
                                                AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY,
                                                AutoAnsItemStAcs.ct_COL_BLGOODSNAME,
                                                AutoAnsItemStAcs.ct_COL_GOODSMAKERCD,
                                                AutoAnsItemStAcs.ct_COL_MAKERNAME,
                                            });
                
                Infragistics.Win.Appearance margedCellAppearance = new Infragistics.Win.Appearance();
                margedCellAppearance.BackColor = Color.Lavender;
                margedCellAppearance.BackColor2 = Color.Lavender;

                for (int index = 0; index < colNameList.Count; index++)
                {
                    string colName = colNameList[index];

                    // CellAppearance�������I�ɓ��ꂷ��i�s���͏����j
                    if (!columns[colName].Key.Trim().Equals(AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY.Trim()))
                    {
                        columns[colName].MergedCellAppearance = margedCellAppearance;
                        columns[colName].CellAppearance.BackColor = margedCellAppearance.BackColor;
                        columns[colName].CellAppearance.BackColor2 = margedCellAppearance.BackColor2;
                        columns[colName].CellAppearance.TextVAlign = VAlign.Top;
                    }

                    // �Z�������ݒ�
                    columns[colName].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
                    columns[colName].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
                    columns[colName].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
                }
                
                // ���_�Z������ 
                columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(AutoAnsItemStAcs.ct_COL_NEWADDROWDIV,
                                                    AutoAnsItemStAcs.ct_COL_SECTIONCODE );

                // ���Ӑ�Z������ 
                columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(AutoAnsItemStAcs.ct_COL_NEWADDROWDIV,
                                                    AutoAnsItemStAcs.ct_COL_SECTIONCODE, 
                                                    AutoAnsItemStAcs.ct_COL_CUSTOMERCODE );

                // ���i�����ރZ������
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(AutoAnsItemStAcs.ct_COL_NEWADDROWDIV,
                                                    AutoAnsItemStAcs.ct_COL_SECTIONCODE,
                                                    AutoAnsItemStAcs.ct_COL_CUSTOMERCODE,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY);

                // ���i�����ޖ��̃Z������
                columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(AutoAnsItemStAcs.ct_COL_NEWADDROWDIV,
                                                    AutoAnsItemStAcs.ct_COL_SECTIONCODE,
                                                    AutoAnsItemStAcs.ct_COL_CUSTOMERCODE,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME);

                // BL�R�[�h�Z������
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(AutoAnsItemStAcs.ct_COL_NEWADDROWDIV,
                                                    AutoAnsItemStAcs.ct_COL_SECTIONCODE,
                                                    AutoAnsItemStAcs.ct_COL_CUSTOMERCODE,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY,
                                                    AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY);

                // BL�R�[�h���̃Z������
                columns[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(AutoAnsItemStAcs.ct_COL_NEWADDROWDIV,
                                                    AutoAnsItemStAcs.ct_COL_SECTIONCODE,
                                                    AutoAnsItemStAcs.ct_COL_CUSTOMERCODE,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY,
                                                    AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY,
                                                    AutoAnsItemStAcs.ct_COL_BLGOODSNAME);

                // ���[�J�[�Z������
                columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(AutoAnsItemStAcs.ct_COL_NEWADDROWDIV,
                                                    AutoAnsItemStAcs.ct_COL_SECTIONCODE,
                                                    AutoAnsItemStAcs.ct_COL_CUSTOMERCODE,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY,
                                                    AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMAKERCD);

                // ���[�J�[���̃Z������
                columns[AutoAnsItemStAcs.ct_COL_MAKERNAME].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(AutoAnsItemStAcs.ct_COL_NEWADDROWDIV,
                                                    AutoAnsItemStAcs.ct_COL_SECTIONCODE,
                                                    AutoAnsItemStAcs.ct_COL_CUSTOMERCODE,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY,
                                                    AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY,
                                                    AutoAnsItemStAcs.ct_COL_GOODSMAKERCD,
                                                    AutoAnsItemStAcs.ct_COL_MAKERNAME);
                # endregion

                // --- ADD 2012/11/22 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��77 --------->>>>>>>>>>>>>>>>>>>>>>>>
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Hidden = true;
                columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Hidden = true;
                // --- ADD 2012/11/22 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��77 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            }
            finally
            {
                uGrid.EndUpdate();
            }
        }

        # region [�O���b�h�Z����������N���X]
        /// <summary>
        /// �O���b�h�Z����������N���X(�J�X�^�}�C�Y)
        /// </summary>
        public class CustomMergedCellEvaluator : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
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
                if (columnName == AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV)
                {
                    if ((int)row1.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value == (int)AutoAnsItemStAcs.AutoAnswerDiv.Priority)
                    {
                        return ((row1.Cells[columnName].Value.ToString().Trim() == row2.Cells[columnName].Value.ToString().Trim()));
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return ((row1.Cells[columnName].Value.ToString().Trim() == row2.Cells[columnName].Value.ToString().Trim()));
                }
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
        /// �����ރR�[�h�t�H�[�}�b�g�擾
        /// </summary>
        /// <returns></returns>
        private string GetGoodsMGroupFormat()
        {
            return GetFormat("tNedit_GoodsMGroup");
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
        /// </remarks>
        public void SettingGridRows(ref UltraGrid uGrid)
        {
            uGrid.BeginUpdate();

            try
            {
                foreach ( UltraGridRow row in uGrid.Rows)
                {
                    // �s���i�\�����j�̐ݒ�
                    row.Cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value = row.Index + 1;
                    // �D�揇�ʂ͎����񓚋敪���u����i�D�揇�ʁj�v�̎��̂ݕҏW�\
                    if (IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value) == (int)AutoAnsItemStAcs.AutoAnswerDiv.Priority)
                    {
                        row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Activation = Activation.AllowEdit; // �D�揇��
                        row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Appearance = null;
                    }
                    else
                    {
                        row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Activation = Activation.NoEdit; // �D�揇��
                        row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Appearance = null;
                    }

                    // �V�K�ǉ��s�̎��͌�����Ԃ������E�ҏW�\��Ԃɂ���
                    if (IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWDIV].Value) == (int)AutoAnsItemStAcs.NewAddRowDiv.New)
                    {
                        for (int index = 0; index < row.Cells.Count; index++)
                        {
                            // CellAppearance�����Ƃɖ߂��i�s���͏����j
                            if (!row.Cells[index].Column.Key.Trim().Equals(AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY.Trim()))
                            {
                                row.Cells[index].Appearance.BackColor = Color.White;
                                row.Cells[index].Appearance.BackColor2 = Color.White;
                            }
                        }
                        // �����񓚋敪���X�g�ݒ�
                        row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList(IntObjToInt(row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value));
                    }
                    else
                    {
                        if (row.Cells[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Value.ToString().Trim() == string.Empty)
                        {
                            // �ҏW�s��
                            row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Activation = Activation.NoEdit;  // ���_�R�[�h
                            row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Activation = Activation.NoEdit; // ���Ӑ�R�[�h
                            row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Activation = Activation.NoEdit; // ���i�����ރR�[�h
                            row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Activation = Activation.NoEdit; // BL�R�[�h
                            row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Activation = Activation.NoEdit; // Ұ������
                            row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Activation = Activation.NoEdit; // ��ʃR�[�h
                            row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Appearance = null;
                            // �ʏ�F�ҏW��
                            row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Activation = Activation.AllowEdit; // �����񓚋敪
                            row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList((int)row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value);
                        }
                        else
                        {
                            // �ҏW�s��
                            row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Activation = Activation.NoEdit;  // ���_�R�[�h
                            row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Activation = Activation.NoEdit; // ���Ӑ�R�[�h
                            row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Activation = Activation.NoEdit; // ���i�����ރR�[�h
                            row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Activation = Activation.NoEdit; // BL�R�[�h
                            row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Activation = Activation.NoEdit; // Ұ������
                            row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Activation = Activation.NoEdit; // ��ʃR�[�h
                            row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Appearance = null;
                            // �폜�ς݁F�ҏW�s��
                            row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Activation = Activation.NoEdit; // �����񓚋敪
                            row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Appearance.BackColor = Color.LightGray;
                            row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Appearance = null;
                            row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList((int)row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value);
                            row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Appearance.BackColor = Color.LightGray;
                        }
                    }
                }
                uGrid.Refresh();
            }
            finally
            {
                uGrid.EndUpdate();
            }
        }

        /// <summary>
        /// �O���b�h�s�ݒ菈���i�s���̂݁j
        /// </summary>
        /// <param name="uGrid">�O���b�h</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�s�ɑ΂��čs���̂ݐݒ�</br>
        /// </remarks>
        public void SettingGridRowsRowNumber(ref UltraGrid uGrid)
        {
            uGrid.BeginUpdate();

            try
            {
                for (int rowIndex = 0; rowIndex < uGrid.Rows.Count; rowIndex++)
                {
                    CellsCollection cells = uGrid.Rows[rowIndex].Cells;

                    // �s���i�\�����j�̐ݒ�
                    cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value = rowIndex + 1;
                }
                uGrid.Refresh();
            }
            finally
            {
                uGrid.EndUpdate();
            }
        }

        /// <summary>
        /// ��ʍs�ݒ菈��
        /// </summary>
        /// <param name="cell">�A�N�e�B�u�Z�����</param>
        /// <remarks>
        /// <br>Note        : ��ʃR�[�h�̐ݒ�����܂��B</br>
        /// </remarks>
        private int SetPrmSetDtlNo2(UltraGridCell cell)
        {
            string sectionCode = string.Empty;
            int customerCode = 0;
            int goodsMGroup = 0;
            int makerCode = 0;
            int blCode = 0;
            int prmSetDtlNo2Num = 0;
            string filter = string.Empty;
            string filterBefore = string.Empty;
            string message = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            sectionCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim();
            int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value.ToString(), out customerCode);
            int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString(), out goodsMGroup);
            int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value.ToString(), out makerCode);
            int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString(), out blCode);
            int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Value.ToString(), out prmSetDtlNo2Num);

            // ���i�����ށABL�R�[�h�A���[�J�[�R�[�h���ύX����Ă��Ȃ����A�ȍ~�̏������s��Ȃ�
            if (cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString() == this._goodsMGroup &&
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString() == this._blGoodsCode &&
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value.ToString() == this._goodsMakerCode)
            {
                return status;
            }
            // ���i�����ށABL�R�[�h�A���[�J�[�R�[�h�ɖ����͂̍��ڂ�����ꍇ�A�ȍ~�̏������s��Ȃ�
            if ((goodsMGroup == 0 || cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value.ToString().Trim() == "0000") ||
                (blCode == 0 || cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value.ToString().Trim() == "00000") ||
                 makerCode == 0
               )
            {
                return status;
            }

            // �D�ǐݒ�}�X�^�̌���������ݒ�
            filter = PrimeSettingInfo.COL_PARTSMAKERCD + " = " + makerCode.ToString() + " AND " +
                            PrimeSettingInfo.COL_TBSPARTSCODE + " = " + blCode.ToString() + " AND " +
                            PrimeSettingInfo.COL_MIDDLEGENRECODE + " = " + goodsMGroup.ToString();

            // �ύX�O���͍s�폜����
            filterBefore = string.Format("{0}='{1}' AND {2}={3} AND {4}={5} AND {6}={7} AND {8}={9} AND {10}={11}",
                                         AutoAnsItemStAcs.ct_COL_SECTIONCODE.ToString(), this._sectionCode.Trim(),
                                         AutoAnsItemStAcs.ct_COL_CUSTOMERCODE.ToString(),GetIntNullZero(this._customerCode),
                                         AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(), GetIntNullZero(this._goodsMGroup),
                                         AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(), GetIntNullZero(this._blGoodsCode),
                                         AutoAnsItemStAcs.ct_COL_GOODSMAKERCD.ToString(), GetIntNullZero(this._goodsMakerCode),
                                         AutoAnsItemStAcs.ct_COL_NEWADDROWDIV.ToString(), (int)AutoAnsItemStAcs.NewAddRowDiv.New
                                        );

            // �s�ǉ�����            
            status = this._autoAnsItemStAcs.RowInsert(filter, filterBefore, sectionCode, customerCode, makerCode, goodsMGroup, blCode);

            // ��ʃR�[�h�����݂��Ȃ����A��ʃR�[�h�E���̂��N���A����
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Value = 0;
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2_SORT].Value = 0;
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Value = string.Empty;
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Value = string.Empty;
            }

            return status;
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
                                         this._autoAnsItemStAcs,	    // �G���[�����������I�u�W�F�N�g
                                         msgButton,         			  	// �\������{�^��
                                         MessageBoxDefaultButton.Button1);	// �����\���{�^��

            return dialogResult;
        }
        #endregion ���b�Z�[�W�{�b�N�X�\��

        #endregion �� Private Methods

        #region �� Control Events

        #region �� Form �C�x���g
        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �t�H�[����Load���ꂽ���ɔ������܂��B</br>
        /// </remarks>
        private void PMKHN09701UA_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveRow = null;

            // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��27 --------->>>>>>>>>>>>>>>>>>>>>>>>
            // this.Initial_Timer.Enabled = true;

            // �N�����̃O���b�h�̃`�����h�~�ׁ̈A
            // Initial_Timer_Tick�̏�����������ֈړ����܂����B

            this.Initial_Timer.Enabled = false;

            // �t�H�[�J�X�ݒ�
            this.tComboEditor_TargetDivide.Focus();

            // XML�f�[�^�Ǎ�
            LoadStateXmlData();

            // �O���b�h�̃A�N�e�B�u�s���N���A
            this.uGrid_Details.ActiveRow = null;

            // �{�^���\���X�V
            this.UpdateButtonToolEnabled();
            // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��27 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }
        #endregion

        #region �� ToolBar �C�x���g
        /// <summary>
        /// ToolClick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>
            GridWidthSave();
            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<

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
                        int status = Save();

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �Č���
                            _needCompare = false;
                            this._extrInfo = null;
                            this.Search();
                            _needCompare = true;

                            // �t�H�[�J�X�ݒ�
                            this.tEdit_SectionCodeAllowZero.Focus();
                        }
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
                        // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��18,��19 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        #region
                        //// �N���A����
                        //ClearScreen();

                        //// �A�N�Z�X�N���X���̃e�[�u���N���A
                        //_autoAnsItemStAcs.Clear();
                        #endregion
                        // �A�N�Z�X�N���X���̃e�[�u���N���A
                        _autoAnsItemStAcs.Clear();
                        // �N���A����
                        ClearScreen();
                        // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��18,��19 --------->>>>>>>>>>>>>>>>>>>>>>>>

                        break;
                    }
                case "ButtonTool_Insert":
                    {
                        // �i�V�K�j�ҏW�t�h�\��
                        _editForm = new PMKHN09701UB( _autoAnsItemStAcs, _guideControl );
                        _editForm.RecordGuid = Guid.Empty;
                        _editForm.ShowDialog( this );

                        // �Č���
                        if (_editForm.IsSave)
                        {
                            this._extrInfo = null;
                            Search();
                        }

                        _editForm.Dispose();
                        _editForm = null;

                        break;
                    }
                case "ButtonTool_Edit":
                    {
                        // �i�ҏW�j�ҏW�t�h�\��
                        _editForm = new PMKHN09701UB( _autoAnsItemStAcs, _guideControl );
                        _editForm.RecordGuid = this.GetRecordGuidFromGrid();
                        _editForm.ShowDialog( this );

                        // �Č���
                        if (_editForm.IsSave)
                        {
                            this._extrInfo = null;
                            Search();
                        }
                        _editForm.Dispose();
                        _editForm = null;
                        
                        break;
                    }
                case "ButtonTool_Delete":
                    {
                        int displayMode = 0; 
                        // �_���폜
                        int status = this.LogicalDelete(out displayMode);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if (displayMode == 0)
                            {
                                // �Č���
                                this._extrInfo = null;
                                Search();
                            }
                            else
                            {
                                // �O���b�h�f�[�^�ݒ�
                                CreateGrid(ref this.uGrid_Details);
                                // �O���b�h�s�J���[�ݒ�
                                SettingGridRows(ref this.uGrid_Details);
                                // �ŏI�s�̋��_�R�[�h���A�N�e�B�u�Z���ɐݒ�
                                this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Activate();
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
                            }
                        }
                        break;
                    }
                // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��10 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                case "ButtonTool_Guide":
                    {
                        if (this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE]))
                        {
                            // ���_
                            GuideSection();
                        }
                        else if(this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE]))
                        {
                            // ���Ӑ�
                            GuideCustomer();
                        }
                        else if(this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY]))
                        {
                            // ���i������
                            GuideGoodsMGroup();
                        }
                        else if(this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY]))
                        {
                            // BL�R�[�h
                            GuideBLCode();
                        }
                        else if(this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD]))
                        {
                            // ���[�J�[
                            GuideMaker();
                        }
                        break;
                    }
                // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��10 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                case "ButtonTool_Renewal":
                    {
                        // �ŐV���擾����
                        Renewal();

                        break;
                    }
            }
        }

        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �s�I�����ꂽ�c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
        /// </remarks>
        private int LogicalDelete(out int displayMode)
        {
            int status = 0;
            int deleteMode = 0;    // �폜���[�h 0:�_���폜 1:�f�[�^�e�[�u�����폜
            int rowIndex = 0;
            AutoAnsItemSt autoAnsItemSt = null;
            // �I�𒆂̃��R�[�h��Guid���擾
            Guid guid = this.GetRecordGuidFromGrid();
            displayMode = 0;  // �폜�\�����[�h 0:�Č����ŕ\�� 1:�Č������Ȃ�

            // �擾�ł��Ȃ����A�V�K�ǉ��s�i�f�[�^�e�[�u�����폜�j�̍s�����擾
            if (guid == Guid.Empty)
            {
                deleteMode = 1;
                rowIndex =this.GetRecordRowIndex();
            }

            if (deleteMode == 0)
            {
                // �폜�Ώۃ��R�[�h���擾(Guid���)
                autoAnsItemSt = _autoAnsItemStAcs.GetRecordForMaintenance(guid);
            }

            # region [�폜�ς݃`�F�b�N]
            if (deleteMode == 0 && autoAnsItemSt.LogicalDeleteCode != 0)
            {
                // �_���폜�ςݍs�Ȃ烁�b�Z�[�W�\�����ďI��

                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                    "�I�𒆂̃f�[�^�͊��ɍ폜����Ă��܂�",// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                return status;
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
                MessageBoxDefaultButton.Button2);		// �\������{�^��

            if (result != DialogResult.OK)
            {
                return status;
            }
            # endregion

            string errMsg;

            if (deleteMode == 0)
            {
                ArrayList deleteList = new ArrayList();
                deleteList.Add(autoAnsItemSt);
                // �_���폜
                status = _autoAnsItemStAcs.LogicalDelete(ref deleteList, out errMsg);
            }
            else
            {
                // �f�[�^�e�[�u�����폜
                status = _autoAnsItemStAcs.LogicalDeleteRowIndex(ref rowIndex, out errMsg);
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        displayMode = deleteMode;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                        {
                            errMsg = "���ɑ��[�����X�V����Ă��܂��B";
                        }
                        else
                        {
                            errMsg = "���ɑ��[�����폜����Ă��܂��B";
                        }

                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "Save",
                                       errMsg,
                                       status,
                                       MessageBoxButtons.OK);

                        this.tEdit_SectionCodeAllowZero.Focus();
                        break;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                   "Save",
                                   "�ۑ������Ɏ��s���܂����B",
                                   status,
                                   MessageBoxButtons.OK);

                        this.tEdit_SectionCodeAllowZero.Focus();
                        break;
                    }
            }
            return status;
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
                guid = (Guid)uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_FILEHEADERGUID].Value;
            }

            return guid;
        }

        /// <summary>
        /// �O���b�h�I�𒆃��R�[�h����̕\���s�����擾
        /// </summary>
        /// <returns></returns>
        private int GetRecordRowIndex()
        {
            int rowIndex = 0;

            if (uGrid_Details.ActiveCell != null)
            {
                rowIndex = (int)uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Value;
            }

            return rowIndex;
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
            this._autoAnsItemStAcs.Renewal();
        }
        /// <summary>
        /// �f�[�^�X�V��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoAnsItemStAcs_AfterTableUpdate( object sender, EventArgs e )
        {
            if ( _autoAnsItemStAcs.DataViewForMstList.Count > 0 )
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
                    nextControl = tNedit_GoodsMGroup_St;
                    break;
                case "tNedit_GoodsMGroup_St":
                    nextControl = tNedit_GoodsMGroup_Ed;
                    break;
                case "tNedit_GoodsMGroup_Ed":
                    nextControl = tNedit_BLGoodsCode_St;
                    break;
                case "tNedit_BLGoodsCode_St":
                    nextControl = tNedit_BLGoodsCode_Ed;
                    break;
                case "tNedit_BLGoodsCode_Ed":
                    nextControl = tNedit_GoodsMakerCd_St;
                    break;
                case "tNedit_GoodsMakerCd_St":
                    nextControl = tNedit_GoodsMakerCd_Ed;
                    break;
                case "tNedit_GoodsMakerCd_Ed":
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
                case "tNedit_GoodsMakerCd_Ed":
                    prevControl = tNedit_GoodsMakerCd_St;
                    break;
                case "tNedit_GoodsMakerCd_St":
                    prevControl = tNedit_BLGoodsCode_Ed;
                    break;
                case "tNedit_BLGoodsCode_Ed":
                    prevControl = tNedit_BLGoodsCode_St;
                    break;
                case "tNedit_BLGoodsCode_St":
                    prevControl = tNedit_GoodsMGroup_Ed;
                    break;
                case "tNedit_GoodsMGroup_Ed":
                    prevControl = tNedit_GoodsMGroup_St;
                    break;
                case "tNedit_GoodsMGroup_St":
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

        #endregion ToolBar �C�x���g

        #region �� Button �C�x���g
        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
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
        /// <br>Note        : </br>
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
        #endregion Button �C�x���g

        #region �� uGrid_Details�֘A �C�x���g
        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            #region ���Z�����I������Ă���ꍇ
            if (this.uGrid_Details.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
                
                // �ҏW���ł������ꍇ
                if (cell.IsInEditMode)
                {
                    // �Z���̃X�^�C���ɂĔ���
                    switch (this.uGrid_Details.ActiveCell.StyleResolved)
                    {
                        #region < �e�L�X�g�{�b�N�X�E�e�L�X�g�{�b�N�X(�{�^���t) >
                        case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            {
                                switch (e.KeyData)
                                {
                                    // ���L�[
                                    case Keys.Left:
                                        if (this.uGrid_Details.ActiveCell.SelStart == 0)
                                        {
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                    // ���L�[
                                    case Keys.Right:
                                        if (this.uGrid_Details.ActiveCell.SelStart >= this.uGrid_Details.ActiveCell.Text.Length)
                                        {
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                }
                                break;
                            }
                        #endregion

                        #region < ��L�ȊO�̃X�^�C�� >
                        default:
                            {
                                switch (e.KeyData)
                                {
                                    // ���L�[
                                    case Keys.Left:
                                        {
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                    // ���L�[
                                    case Keys.Right:
                                        {
                                            // ���̓`�F�b�N���n�j���A�����񓚋敪���u����i�D�揇�ʁj�v�̎��A�D�揇�ʂ���͉\�ɂ���
                                            if ((int)cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].EditorResolved.Value == (int)AutoAnsItemStAcs.AutoAnswerDiv.Priority)
                                            {
                                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Activation = Activation.AllowEdit; // �D�揇��
                                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Appearance = null;
                                            }
                                            else
                                            {
                                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Activation = Activation.NoEdit; // �D�揇��
                                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Appearance = null;
                                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value = string.Empty;
                                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value = 0;
                                            }
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                            e.Handled = true;
                                        }
                                        break;

                                }
                                break;
                            }
                        #endregion
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// �V�K�ǉ��s���ۑ��\�ȏ�Ԃ����`�F�b�N���A
        /// �\�ȏ�Ԃł���ΐV�K�ǉ��s��ǉ�����
        /// </summary>
        /// <param name="cell">�ΏۃZ��</param>
        private void CheckNewAddRowAllowSave(Infragistics.Win.UltraWinGrid.UltraGridCell cell)
        {
            // ���݂��Ȃ��s�C���f�b�N�X�̏ꍇ�͉������Ȃ�
            if (cell.Row.Index < 0)
            {
                return;
            }

            // �V�K�ǉ��s�̎�
            if (IntObjToInt(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWDIV].Value).Equals((int)AutoAnsItemStAcs.NewAddRowDiv.New))
            {
                if (CheckRowNewAdd(cell.Row).Equals(1))
                {
                    cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWALLOWSAVE].Value = (int)AutoAnsItemStAcs.NewAddRowAllowSave.No;
                }
                else
                {
                    cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWALLOWSAVE].Value = (int)AutoAnsItemStAcs.NewAddRowAllowSave.Yes;
                }
            }
            
            // �����������ȉ��A�ŉ��s�̏ꍇ�̂ݏ���
            if (!cell.Row.Index.Equals(uGrid_Details.Rows.Count - 1))
            {
                return;
            }

            // �V�K�ǉ��s�̎�
            if (IntObjToInt(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWDIV].Value).Equals((int)AutoAnsItemStAcs.NewAddRowDiv.New))
            {
                // ���͂��s���Ă����ꍇ�͓��̓`�F�b�N���s��
                int ret = CheckRowNewAdd(cell.Row);
                if(ret.Equals(0))
                {
                    // ���͂���Ŗ����͍��ڂȂ�

                    // �s�ǉ�����
                    // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��18,��19 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    #region
                    //int status = this._autoAnsItemStAcs.RowAdd();
                    //if (status == 0)
                    //{
                    //    // �O���b�h�f�[�^�ݒ�
                    //    CreateGrid(ref this.uGrid_Details);
                    //    // �O���b�h�s�J���[�ݒ�
                    //    SettingGridRows(ref this.uGrid_Details);
                    //    // �ŏI�s�̋��_�R�[�h���A�N�e�B�u�Z���ɐݒ�
                    //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Activate();
                    //    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
                    //    return;
                    //}
                    #endregion
                    this._autoAnsItemStAcs.RowAdd();

                    // UPD 2012/11/26 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��81 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    #region ���\�[�X
                    //// �O���b�h�f�[�^�ݒ�
                    //CreateGrid(ref this.uGrid_Details);
                    //// �O���b�h�s�J���[�ݒ�
                    //SettingGridRows(ref this.uGrid_Details);
                    //// �ŏI�s�̋��_�R�[�h���A�N�e�B�u�Z���ɐݒ�
                    //this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Activate();
                    //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
                    #endregion
                    // �O���b�h�s�J���[�ݒ�
                    SettingGridRows(ref this.uGrid_Details);
                    // UPD 2012/11/26 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��81 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��18,��19 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
        }

        /// <summary>
        /// KeyPress �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            #region ��ActiveCell�����_�R�[�h�̏ꍇ
            if (cell.Column.Key == AutoAnsItemStAcs.ct_COL_SECTIONCODE)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion

            #region ��ActiveCell�����Ӑ�R�[�h�̏ꍇ
            else if (cell.Column.Key == AutoAnsItemStAcs.ct_COL_CUSTOMERCODE)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion

            #region ��ActiveCell�����i�����ރR�[�h�̏ꍇ
            else if (cell.Column.Key == AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion

            #region ��ActiveCell��BL�R�[�h�̏ꍇ
            else if (cell.Column.Key == AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!KeyPressNumCheck(5, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion

            #region ��ActiveCell�����[�J�[�R�[�h�̏ꍇ
            else if (cell.Column.Key == AutoAnsItemStAcs.ct_COL_GOODSMAKERCD)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion

            #region ��ActiveCell����ʃR�[�h�̏ꍇ
            else if (cell.Column.Key == AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!KeyPressNumCheck(1, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion

            #region ��ActiveCell���D�揇�ʂ̏ꍇ
            else if (cell.Column.Key == AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��13 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // if (!KeyPressNumCheck(1, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    if (!KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��13 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// AfterCellActivate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Z�����A�N�e�B�u���������ɔ������܂��B</br>
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
                if (IntObjToInt(uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWDIV].Value) == (int)AutoAnsItemStAcs.NewAddRowDiv.New)
                {
                    // �V�K�ǉ��s
                    SetButtonToolEnabled("ButtonTool_Edit", false);
                    SetButtonToolEnabled( "ButtonTool_Delete", false );
                    // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��10 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    if (this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_SECTIONCODE])
                        || this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE])
                        || this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY])
                        || this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY])
                        || this.uGrid_Details.ActiveCell.Column.Equals(this.uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD]))
                    {
                        SetButtonToolEnabled("ButtonTool_Guide", true);
                    }
                    else
                    {
                        SetButtonToolEnabled("ButtonTool_Guide", false);
                    }
                    // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��10 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                else
                {
                    SetButtonToolEnabled( "ButtonTool_Edit", true );
                    SetButtonToolEnabled( "ButtonTool_Delete", true );
                    // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��10 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    SetButtonToolEnabled("ButtonTool_Guide", false);
                    // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��10 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
            else
            {
                // �s���I������Ă��Ȃ�
                SetButtonToolEnabled( "ButtonTool_Edit", false );
                SetButtonToolEnabled( "ButtonTool_Delete", false );
                // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��10 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                SetButtonToolEnabled("ButtonTool_Guide", false);
                // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��10 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
        }

        // ADD 2012/11/26 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��82 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        private bool uGridErrChk()
        {
            if (uGrid_Details.ActiveCell == null) return false;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int rowIndex = cell.Row.Index;

            switch (cell.Column.Key)
            {
                #region ActiveCell�����_�R�[�h�̎�
                case AutoAnsItemStAcs.ct_COL_SECTIONCODE:
                    {
                        string sectionCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Text;
                        string sectionName = string.Empty;
                        // �ҏW���s��ꂽ���̂ݏ������s��
                        if (this._sectionCode != sectionCode)
                        {
                            // ���_�R�[�h���̓`�F�b�N
                            if (!CheckRowSectionCode(ref sectionCode, out sectionName))
                            {
                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value = this._sectionCode.Trim();
                                this.uGrid_Details.ActiveCell = cell;
                                return true;
                            }
                            // ���_�R�[�h
                            if (!string.IsNullOrEmpty(sectionCode))
                            {
                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value = sectionCode.Trim();
                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONNM].Value = sectionName.Trim();
                            }
                        }

                        break;
                    }
                #endregion

                #region ActiveCell�����Ӑ�R�[�h�̎�
                case AutoAnsItemStAcs.ct_COL_CUSTOMERCODE:
                    {
                        string sectionCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Text;
                        int customerCode = 0;
                        int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Text, out customerCode);
                        cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value = customerCode;
                        string customerName = string.Empty;

                        // �ҏW���s��ꂽ���̂ݏ������s��
                        if (this._customerCode != customerCode)
                        {
                            // ���Ӑ�R�[�h�`�F�b�N
                            if (!CheckRowCustomerCode(customerCode, out customerName))
                            {
                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value = this._customerCode;
                                return true;
                            }
                            if (!string.IsNullOrEmpty(customerName))
                            {
                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERNAME].Value = customerName;
                            }
                        }
                        break;
                    }
                #endregion

                #region ActiveCell�����i�����ރR�[�h�̎�
                case AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY:
                    {
                        string goodsMGroup = string.Empty;
                        if (cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Text.Trim().Length > 0)
                        {
                            goodsMGroup = GetIntNullZero(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Text.Trim()).ToString();
                        }
                        string goodsMGroupName = string.Empty;

                        // ���i�����ޖ��̂̎擾
                        if (GoodsMGroupReadAndSet(goodsMGroup, this._goodsMGroup, cell))
                        {
                            return true;
                        }
                        break;
                    }
                #endregion

                #region ActiveCell���a�k�R�[�h�̎�
                case AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY:
                    {
                        int goodsMGroup = 0;
                        int goodsMGroupOld = 0;
                        int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Text, out goodsMGroup);
                        goodsMGroupOld = goodsMGroup;

                        string blGoodsCode = string.Empty;
                        if (cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Text.Trim().Length > 0)
                        {
                            blGoodsCode = GetIntNullZero(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Text.Trim()).ToString();
                        }
                        string blGoodsName = string.Empty;
                        int blGoodsCodeNum = 0;

                        // �ҏW���s��ꂽ���̂ݏ������s��
                        if (this._blGoodsCode != blGoodsCode)
                        {
                            // BL�R�[�h���̓`�F�b�N
                            if (!CheckRowBLCode(out goodsMGroup, ref blGoodsCode, out blGoodsName, out blGoodsCodeNum))
                            {
                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value = this._blGoodsCode;
                                return true;
                            }

                            // BL�R�[�h����
                            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Value = blGoodsName.Trim();
                            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value = blGoodsCodeNum;
                            if (blGoodsCode.Length > 0)
                            {
                                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value = GetIntNullZero(blGoodsCode.Trim()).ToString("00000");
                            }
                        }

                        // ���i�����ރR�[�h���ݒ肳�ꂽ��A�O���b�h�̏��i�����ނ��X�V
                        if (!goodsMGroup.Equals(0))
                        {
                            // ���i������ 
                            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value = goodsMGroup;
                            // ���i�����ޖ��̂̎擾
                            GoodsMGroupReadAndSet(goodsMGroup.ToString(), goodsMGroupOld.ToString(), cell);
                        }
                        break;
                    }
                #endregion

                #region ActiveCell�����[�J�[�R�[�h�̎�
                case AutoAnsItemStAcs.ct_COL_GOODSMAKERCD:
                    {
                        string goodsMakerCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Text;
                        string goodsMakerName = string.Empty;

                        // ���[�J�[�R�[�h���̓`�F�b�N
                        if (!CheckRowMakerCode(goodsMakerCode, out goodsMakerName))
                        {
                            int MakerCodeNum = 0;
                            int.TryParse(this._goodsMakerCode, out MakerCodeNum);
                            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value = MakerCodeNum;
                            return true;
                        }

                        // ���[�J�[�R�[�h����
                        cell.Row.Cells[AutoAnsItemStAcs.ct_COL_MAKERNAME].Value = goodsMakerName.Trim();
                        if (!string.IsNullOrEmpty(goodsMakerName))
                        {
                            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList((int)cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value);
                        }
                        else
                        {
                            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList(0);
                        }
                        break;
                    }
                #endregion
            }
            return false;
        }
        // ADD 2012/11/26 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��82 ---------<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// AfterExitEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �ҏW���[�h���I���������ɔ������܂��B</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (uGrid_Details.ActiveCell == null) return;
            // ADD 2013/11/22 T.Yoshioka VSS[019] Redmine#677 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (uGrid_Details.ActiveCell.Row.Index < 0) return;
            // ADD 2013/11/22 T.Yoshioka VSS[019] Redmine#677 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int rowIndex = cell.Row.Index;

            switch (cell.Column.Key)
            {
                // DEL 2012/11/26 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��82 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region ���\�[�X
                //#region ActiveCell�����_�R�[�h�̎�
                //case AutoAnsItemStAcs.ct_COL_SECTIONCODE:          
                //    {
                //        string sectionCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString();
                //        string sectionName = string.Empty;
                //        // �ҏW���s��ꂽ���̂ݏ������s��
                //        if (this._sectionCode != sectionCode)
                //        {
                //            // ���_�R�[�h���̓`�F�b�N
                //            if (!CheckRowSectionCode(ref sectionCode, out sectionName))
                //            {
                //                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value = this._sectionCode.Trim();
                //                this.uGrid_Details.ActiveCell = cell;
                //                return;
                //            }
                //            // ���_�R�[�h
                //            if (!string.IsNullOrEmpty(sectionCode))
                //            {
                //                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value = sectionCode.Trim();
                //                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONNM].Value = sectionName.Trim();
                //            }
                //        }

                //        break;
                //    }
                //#endregion

                //#region ActiveCell�����Ӑ�R�[�h�̎�
                //case AutoAnsItemStAcs.ct_COL_CUSTOMERCODE:         
                //    {
                //        string sectionCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString();
                //        int customerCode = 0;
                //        int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value.ToString(), out customerCode);
                //        // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��23 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                //        cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value = customerCode;
                //        // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��23 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                //        string customerName = string.Empty;

                //        // �ҏW���s��ꂽ���̂ݏ������s��
                //        if (this._customerCode != customerCode)
                //        {
                //            // ���Ӑ�R�[�h�`�F�b�N
                //            if (!CheckRowCustomerCode(customerCode, out customerName))
                //            {
                //                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value = this._customerCode;
                //                return;
                //            }
                //            if (!string.IsNullOrEmpty(customerName))
                //            {
                //                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERNAME].Value = customerName;
                //            }
                //        }
                //        break;
                //    }
                //#endregion

                //#region ActiveCell�����i�����ރR�[�h�̎�
                //case AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY:   
                //    {
                //        string goodsMGroup = string.Empty;
                //        if (cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value.ToString().Trim().Length > 0)
                //        {
                //            goodsMGroup = GetIntNullZero(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value.ToString().Trim()).ToString();
                //        }
                //        string goodsMGroupName = string.Empty;

                //        // ���i�����ޖ��̂̎擾
                //        GoodsMGroupReadAndSet(goodsMGroup, this._goodsMGroup, cell);
                //        break;
                //    }
                //#endregion

                //#region ActiveCell���a�k�R�[�h�̎�
                //case AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY:   
                //    {
                //        int goodsMGroup = 0;
                //        int goodsMGroupOld = 0;
                //        int.TryParse(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value.ToString(), out goodsMGroup);
                //        goodsMGroupOld = goodsMGroup;

                //        string blGoodsCode = string.Empty;
                //        if (cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value.ToString().Trim().Length > 0)
                //        {
                //            blGoodsCode = GetIntNullZero(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value.ToString().Trim()).ToString();
                //        }
                //        string blGoodsName = string.Empty;
                //        int blGoodsCodeNum = 0;

                //        // �ҏW���s��ꂽ���̂ݏ������s��
                //        if (this._blGoodsCode != blGoodsCode)
                //        {
                //            // BL�R�[�h���̓`�F�b�N
                //            if (!CheckRowBLCode(out goodsMGroup, ref blGoodsCode, out blGoodsName, out blGoodsCodeNum))
                //            {
                //                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value = this._blGoodsCode;
                //                return;
                //            } 

                //            // BL�R�[�h����
                //            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Value = blGoodsName.Trim();
                //            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value = blGoodsCodeNum;
                //            if (blGoodsCode.Length > 0)
                //            {
                //                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value = GetIntNullZero(blGoodsCode.Trim()).ToString("00000");
                //            }
                //        }

                //        // ���i�����ރR�[�h���ݒ肳�ꂽ��A�O���b�h�̏��i�����ނ��X�V
                //        if (!goodsMGroup.Equals(0))
                //        {
                //            // ���i������ 
                //            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value = goodsMGroup;
                //            // ���i�����ޖ��̂̎擾
                //            GoodsMGroupReadAndSet(goodsMGroup.ToString(), goodsMGroupOld.ToString(), cell);
                //        }
                //        break;
                //    }
                //#endregion

                //#region ActiveCell�����[�J�[�R�[�h�̎�
                //case AutoAnsItemStAcs.ct_COL_GOODSMAKERCD:          
                //    {
                //        string goodsMakerCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value.ToString();
                //        string goodsMakerName = string.Empty;
                        
                //        // ���[�J�[�R�[�h���̓`�F�b�N
                //        if (!CheckRowMakerCode(goodsMakerCode, out goodsMakerName))
                //        {
                //            int MakerCodeNum = 0;
                //            int.TryParse(this._goodsMakerCode, out MakerCodeNum);
                //            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value = MakerCodeNum;
                //            return;
                //        }

                //        // ���[�J�[�R�[�h����
                //        cell.Row.Cells[AutoAnsItemStAcs.ct_COL_MAKERNAME].Value = goodsMakerName.Trim();
                //        if (!string.IsNullOrEmpty(goodsMakerName))
                //        {
                //            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList((int)cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value);
                //        }
                //        else
                //        {
                //            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = GetAutoAnswerDivValueList(0);
                //        }
                //        break;
                //    }
                //#endregion
                #endregion ���\�[�X
                // DEL 2012/11/26 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��82 ---------<<<<<<<<<<<<<<<<<<<<<

                #region ActiveCell���D�揇�ʂ̎�
                case AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY: 
                    {
                        int autoAnswerDiv = (int)cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value;
                        string priorityOrder = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value.ToString();
                        int priorityOrderNum = 0;

                        // �ҏW���s��ꂽ���̂ݏ������s��
                        if (this._priorityOrder != priorityOrder)
                        {
                            // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��4 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            //if (int.TryParse(priorityOrder, out priorityOrderNum))
                            //{
                            //    cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value = priorityOrderNum;
                            //}
                            int.TryParse(priorityOrder, out priorityOrderNum);
                            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value = priorityOrderNum;
                            // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��4 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
                        break;
                    }
                #endregion
            }

            // ��ʃR�[�h�ݒ�
            if (SetPrmSetDtlNo2(cell) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �O���b�h�f�[�^�ݒ�
                CreateGrid(ref this.uGrid_Details);
                // �O���b�h�s�J���[�ݒ�
                SettingGridRows(ref this.uGrid_Details);

                this.uGrid_Details.Rows[rowIndex].Activate();
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
            }
            else
            {
                SettingGridRowsRowNumber(ref this.uGrid_Details);
            }

            // �V�K�ǉ��s����
            CheckNewAddRowAllowSave(cell);
        }

        /// <summary>
        /// ���i�����ޖ��̂̎擾�ƃO���b�h�ւ̐ݒ�
        /// </summary>
        /// <param name="goodsMGroup">�ύX�㏤�i������</param>
        /// <param name="goodsMGroupOld">�ύX�O���i������</param>
        /// <param name="cell">�ΏۃZ��</param>
        // UPD 2012/11/26 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��82 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // private void GoodsMGroupReadAndSet(string goodsMGroup, string goodsMGroupOld, UltraGridCell cell)
        private bool GoodsMGroupReadAndSet(string goodsMGroup, string goodsMGroupOld, UltraGridCell cell)
        // UPD 2012/11/26 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��82 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            string goodsMGroupName = string.Empty;
            int goodsMGroupNum = 0;

            // �ҏW���s��ꂽ���̂ݏ������s��
            if (goodsMGroup != goodsMGroupOld)
            {
                // ���i�����ރR�[�h�`�F�b�N
                if (!CheckRowGoodsMGroup(ref goodsMGroup, out goodsMGroupName, out goodsMGroupNum))
                {
                    cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value = goodsMGroupOld;
                    // UPD 2012/11/26 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��82 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    //return;
                    return true;
                    // UPD 2012/11/26 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��82 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                }

                // ���i�����ޖ���
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Value = goodsMGroupName.Trim();
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value = goodsMGroupNum;
            }

            if (goodsMGroup.Length > 0)
            {
                cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value = GetIntNullZero(goodsMGroup.Trim()).ToString("0000");
            }
            // ADD 2012/11/26 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��82 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            return false;
            // ADD 2012/11/26 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��82 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// �O���b�h�Z���X�V�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            uGrid_Details.UpdateData();
        }

        /// <summary>
        /// �O���b�h�E�o�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            // ActiveCell����
            if (uGrid_Details.ActiveCell != null)
            {
                uGrid_Details.ActiveCell.Selected = false;
                uGrid_Details.ActiveCell = null;
            }

            // ActiveRow����
            if (uGrid_Details.ActiveRow != null)
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
        private void uGrid_Details_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (uGrid_Details.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // �V�K�ǉ��ҏW���͏������s��Ȃ�
            if ((int)cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWDIV].Value == (int)AutoAnsItemStAcs.NewAddRowDiv.New)
            {
                return;
            }

            // �i�ҏW�j�ҏW�t�h�\��
            _editForm = new PMKHN09701UB(_autoAnsItemStAcs, _guideControl);
            _editForm.RecordGuid = this.GetRecordGuidFromGrid();
            _editForm.ShowDialog(this);

            // �Č���
            if (_editForm.IsSave)
            {
                this._extrInfo = null;
                // ADD 2012/11/21 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��57 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                ClearGrid();
                // ADD 2012/11/21 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��57 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                Search();
            }
            _editForm.Dispose();
            _editForm = null;
        }

        /// <summary>
        /// �O���b�h�L�[�}�b�s���O
        /// </summary>
        /// <param name="grid"></param>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
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
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- Shift + Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŏ�i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŉ��i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- �O�ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);

            //----- ���ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            grid.KeyActionMappings.Add(enterMap);
        }

        /// <summary>
        /// AfterPerformAction �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : Grid�A�N�V����������C�x���g</br>
        /// </remarks>
        private void uGrid_Details_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:

                    // �A�N�e�B�u�ȃZ�������邩�H�܂��͕ҏW�\�Z�����H
                    if ((this.uGrid_Details.ActiveCell != null) && 
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        // �A�N�e�B�u�Z���̃X�^�C�����擾
                        switch (this.uGrid_Details.ActiveCell.StyleResolved)
                        {
                            // �G�f�B�b�g�n�X�^�C��
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // �ҏW���[�h�ɂ���H
                                    if (this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                                    {
                                        if (!(this.uGrid_Details.ActiveCell.Value is System.DBNull))
                                        {
                                            // �S�I����Ԃɂ���B
                                            this.uGrid_Details.ActiveCell.SelStart = 0;
                                            this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // �G�f�B�b�g�n�ȊO�̃X�^�C���ł���΁A�ҏW��Ԃɂ���B
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// BeforePerformAction �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : Grid�A�N�V���������O�C�x���g</br>
        /// </remarks>
        private void uGrid_Details_BeforePerformAction(object sender, BeforeUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:
                    {
                        if (this.uGrid_Details.ActiveCell != null) 
                        {
                            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

                            // �����O�̃Z���͐V�K�ǉ��s���H
                            if ((int)cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWDIV].Value == (int)AutoAnsItemStAcs.NewAddRowDiv.New &&
                                (int)cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWALLOWSAVE].Value == (int)AutoAnsItemStAcs.NewAddRowAllowSave.No)
                            {
                                // ���͂��s���Ă����ꍇ�͓��̓`�F�b�N���s��
                                int ret = CheckRowNewAdd(cell.Row);
                                switch(ret)
                                {
                                    case -1:  // ���͂���Ŗ����͍��ڂ���
                                        {
                                            DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                                                              "�ǉ��s���ҏW����Ă��܂����j�����܂����H",
                                                                              0,
                                                                              MessageBoxButtons.YesNo,
                                                                              MessageBoxDefaultButton.Button1);
                                            if (res == DialogResult.Yes)
                                            {
                                                // �ǉ��s�N���A
                                                ClearGridNewAddRow();
                                            }
                                            e.Cancel = true;
                                            break;
                                        }
                                    case 0:   // ���͂���Ŗ����͍��ڂȂ�
                                        {
                                            // �V�K�ǉ��s�X�V
                                            cell.Row.Cells[AutoAnsItemStAcs.ct_COL_NEWADDROWALLOWSAVE].Value = AutoAnsItemStAcs.NewAddRowAllowSave.Yes;
                                            this.uGrid_Details.Refresh();
                                            break;
                                        }
                                    case 1:   // �S���ږ�����
                                        break;
                                }
                            }

                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// BeforeExitEditMode �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Z���ҏW���[�h�I���O�C�x���g</br>
        /// </remarks>
        private void uGrid_Details_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
        {

            if (this.uGrid_Details.ActiveCell == null) return;

            // ADD 2013/11/22 T.Yoshioka VSS[019] Redmine#677 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (this.uGrid_Details.ActiveCell.Row.Index < 0) return;
            // ADD 2013/11/22 T.Yoshioka VSS[019] Redmine#677 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // �ύX�O���ޔ�
            this._sectionCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString();               // ���_�R�[�h
            this._customerCode = GetIntNullZero(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value);        // ���Ӑ�R�[�h
            if (cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value.ToString().Trim().Length > 0)
            {
                this._goodsMGroup = GetIntNullZero(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value.ToString().Trim()).ToString();        // ���i������
            }
            else
            {
                this._goodsMGroup = string.Empty;
            }
            if (cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value.ToString().Trim().Length > 0)
            {
                this._blGoodsCode = GetIntNullZero(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value.ToString().Trim()).ToString();        // BL�R�[�h
            }
            else
            {
                this._blGoodsCode = string.Empty;
            }
            this._goodsMakerCode = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value.ToString();           // Ұ������
            this._prmSetDtlNo2 = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Value.ToString();      // ��ʃR�[�h
            this._autoAnswerDiv = GetIntNullZero(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value);      // �����񓚋敪
            this._priorityOrder = cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value.ToString();    // �D�揇��
            // ADD 2012/11/26 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��82 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            e.Cancel = uGridErrChk();
            // ADD 2012/11/26 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��82 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// CellDataError �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Z���f�[�^�G���[���C�x���g</br>
        /// </remarks>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // ���l���ڂ̏ꍇ
                if ((this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // �����͂�0�ɂ���
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // ���l���ڂɁu-�vor�u.�v�������������ĂȂ�������ʖڂł�
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // �ʏ����
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Details.ActiveCell.Column.DataType);
                            this.uGrid_Details.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                    e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�
                    e.StayInEditMode = false;			// �ҏW���[�h�͔�����
                }
            }
        }

        /// <summary>
        /// �O���b�h�@�h���b�v�_�E�����X�g�ύX��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_CellListSelect(object sender, CellEventArgs e)
        {
            if (IsPriority(e.Cell.Text))
            {
                // �g�p��
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value = DBNull.Value;
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value = DBNull.Value;
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Activation = Activation.AllowEdit;
            }
            else
            {
                // �g�p�s��
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value = DBNull.Value;
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Value = DBNull.Value;
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Activation = Activation.Disabled;
            }

        }
        #endregion uGrid_Details�֘A �C�x���g

        #region �� Tick �C�x���g
        /// <summary>
        /// �����g�p�ł��B�i12/12�z�M�V�X�e���e�X�g��Q��27�ɂ��j
        /// Tick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���Ԋu���߂��鎞�ɔ������܂��B</br>
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
        #endregion

        #region �� ValueChanged �C�x���g
        /// <summary>
        /// ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �t�H���g�T�C�Y�R���{�{�b�N�X�̒l���ύX���ꂽ���ɔ������܂��B</br>
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
        #endregion ValueChanged �C�x���g

        #region �� ChangeFocus �C�x���g
        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : Enter�L�[�ɂ��R���g���[���̃t�H�[�J�X���ύX���ꂽ���ɔ������܂��B</br>
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
                            else
                            {
                                if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                                {
                                    // �t�H�[�J�X�ړ�
                                    e.NextCtrl = this.GetPrevEdit( e.PrevCtrl );
                                }
                            }
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
                case "tNedit_GoodsMGroup_St":
                case "tNedit_GoodsMGroup_Ed":
                case "tNedit_BLGoodsCode_St":
                case "tNedit_BLGoodsCode_Ed":
                case "tNedit_GoodsMakerCd_St":
                case "tNedit_GoodsMakerCd_Ed":
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
                            if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                            {
                                // �t�H�[�J�X�ړ�
                                e.NextCtrl = this.GetPrevEdit( e.PrevCtrl );
                            }
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
                                // UPD 2012/11/07 �O�� 2012/12/12�z�M �V�X�e���e�X�g��Q��2 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                                //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                                //this.uGrid_Details.PerformAction( Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode );

                                //e.NextCtrl = e.PrevCtrl;
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                e.NextCtrl = null;
                                // UPD 2012/11/07 �O�� 2012/12/12�z�M �V�X�e���e�X�g��Q��2 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            // ADD 2012/11/07 �O�� 2012/12/12�z�M �V�X�e���e�X�g��Q��2 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                e.NextCtrl = null;
                            }
                            // ADD 2012/11/07 �O�� 2012/12/12�z�M �V�X�e���e�X�g��Q��2 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
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
                            // ���i������(�J�n)
                            e.NextCtrl = tNedit_GoodsMGroup_St;
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
        #endregion

        #region �� CheckedChanged �C�x���g
        /// <summary>
        /// �폜�ςݕ\���L���`�F�b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_StatusBar_ShowLogicalDelete_CheckedChanged(object sender, EventArgs e)
        {
            this.uGrid_Details.BeginUpdate();
            try
            {
                bool excludeLogicalDelete = !uCheckEditor_StatusBar_ShowLogicalDelete.Checked;

                // �O���b�h�\���؂�ւ�
                this.ExcludeLogicalDeleteFromGrid(excludeLogicalDelete);
                // �_���폜�L���؂�ւ�
                this._autoAnsItemStAcs.ExcludeLogicalDeleteFromView = excludeLogicalDelete;
                // �X�N���[���|�W�V����������
                this.uGrid_Details.DisplayLayout.RowScrollRegions.Clear();
                this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();

                // �O���b�h�s�Đݒ�
                SettingGridRows(ref this.uGrid_Details);
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
        private void ExcludeLogicalDeleteFromGrid(bool excludeLogicalDelete)
        {
            // �폜��
            uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Hidden = excludeLogicalDelete;
            uGrid_Details.DisplayLayout.Bands[0].Columns[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Header.VisiblePosition = 1;
        }

        /// <summary>
        /// ��T�C�Y�̎��������`�F�b�N�ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged(object sender, EventArgs e)
        {
            if (uCheckEditor_StatusBar_AutoFillToGridColumn.Checked)
            {
                // ��T�C�Y��������
                uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                // ��T�C�Y������������
                uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.None;

                // �����œK������
                for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
                {
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                }
                this.uGrid_Details.Refresh();
            }
        }
        #endregion

        #endregion �� Control Events

        #region �� ���̑�

        /// <summary>
        /// ��ʃR�[�h���d�����Ă��Ȃ���
        /// </summary>
        /// <returns>true:�d�����Ă���@false:�d�����Ă��Ȃ�</returns>
        private bool IsPrmSetDtlNo2Duplicate()
        {
            bool ret = false;
            string filter = string.Empty;
            int retCount = 0;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (string.IsNullOrEmpty(cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString().Trim()))
            {
                filter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}'",
                                       AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString(),
                                       AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString(),
                                       AutoAnsItemStAcs.ct_COL_GOODSMAKERCD.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value.ToString(),
                                       AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Value.ToString());
            }
            else
            {
                filter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' AND {8}='{9}'",
                                       AutoAnsItemStAcs.ct_COL_SECTIONCODE.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value.ToString(),
                                       AutoAnsItemStAcs.ct_COL_GOODSMGROUP.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value.ToString(),
                                       AutoAnsItemStAcs.ct_COL_BLGOODSCODE.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value.ToString(),
                                       AutoAnsItemStAcs.ct_COL_GOODSMAKERCD.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value.ToString(),
                                       AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY.ToString(),
                                       cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Value.ToString());
            }

            List<AutoAnsItemSt> retList = this._autoAnsItemStAcs.GetRecordListForMaintenance(filter, retCount);

            if (retList != null && retList.Count > 1)
            {
                ret = true;
            }
            return ret;
        }

        #endregion

        #region �� Public Methods
        /// <summary>
        /// �ėp�@�R�[�h�A���̍\����
        /// </summary>
        public struct CodeAndName
        {
            public CodeAndName(int _code, string _name)
            {
                Code = _code;
                Name = _name;
            }

            /// <summary>
            /// �R�[�h
            /// </summary>
            public int Code;
            /// <summary>
            /// ����
            /// </summary>
            public string Name;
        }
        /// <summary>
        /// �O���b�h�p�@�����񓚋敪 ValueList�擾
        /// </summary>
        /// <returns></returns>
        public static IValueList GetAutoAnswerDivValueList(int code)
        {
            List<CodeAndName> aList = GetAutoAnswerDivList(code);

            ValueList vList = new ValueList();
            foreach (CodeAndName div in aList)
            {
                vList.ValueListItems.Add(new ValueListItem(div.Code, div.Name));
            }
            return vList;
        }
        /// <summary>
        /// �O���b�h�p�@�����񓚋敪 ValueListItem�z��擾
        /// </summary>
        /// <returns></returns>
        public static ValueListItem[] GetAutoAnswerDivValueArray(int code)
        {
            List<CodeAndName> aList = GetAutoAnswerDivList(code);

            ValueListItem[] vList = new ValueListItem[aList.Count];
            
            for(int i = 0; i < aList.Count ;i++)
            {
                vList[i] = new ValueListItem(aList[i].Code, aList[i].Name);
            }
            return vList;
        }
        /// <summary>
        /// �O���b�h�p�@�����񓚋敪 ValueList�擾
        /// </summary>
        /// <returns></returns>
        public static IValueList GetAutoAnswerDivValueList()
        {
            List<CodeAndName> aList = GetAutoAnswerDivList();

            ValueList vList = new ValueList();
            foreach (CodeAndName div in aList)
            {
                vList.ValueListItems.Add(new ValueListItem(div.Code, div.Name));
            }
            return vList;
        }

        /// <summary>
        /// �����񓚋敪�@�擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static List<CodeAndName> GetAutoAnswerDivList(int code)
        {
            List<CodeAndName> list = new List<CodeAndName>();
            list.Add(new CodeAndName(0, AUTOANSWER_DIV_NO_AUTOANSWER));
            list.Add(new CodeAndName(1, AUTOANSWER_DIV_AUTOANSWER));

            // �D�ǂ̂�
            if (!IsPureMaker(code))
            {
                list.Add(new CodeAndName(2, AUTOANSWER_DIV_AUTOANSWER_PRIORITY));
            }
            return list;
        }

        /// <summary>
        /// �����񓚋敪�@�擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static List<CodeAndName> GetAutoAnswerDivList()
        {
            List<CodeAndName> list = new List<CodeAndName>();
            list.Add(new CodeAndName(0, AUTOANSWER_DIV_NO_AUTOANSWER));
            list.Add(new CodeAndName(1, AUTOANSWER_DIV_AUTOANSWER));
            list.Add(new CodeAndName(2, AUTOANSWER_DIV_AUTOANSWER_PRIORITY));
            return list;
        }

        /// <summary>
        /// �������[�J�[���ۂ�
        /// </summary>
        /// <param name="code">���[�J�[�R�[�h</param>
        /// <returns>true�F�����@false�F�D��</returns>
        public static bool IsPureMaker(int code)
        {
            return code <= 999;
        }

        /// <summary>
        /// �I������Ă��鎩���񓚋敪��"����(�D�揇��)"���ۂ�
        /// </summary>
        /// <param name="text">�ΏۂƂȂ�敪�̃e�L�X�g</param>
        /// <returns>true:����(�D�揇��)�@false:����(�D�揇��)�ȊO</returns>
        public static bool IsPriority(string text)
        {
            return text == AUTOANSWER_DIV_AUTOANSWER_PRIORITY;
        }

        /// <summary>
        /// ����̒l�𐔒l(int)�ɕϊ��B
        /// �ϊ��ł��Ȃ��ꍇ��0��ݒ�B
        /// </summary>
        /// <param name="target">�Ώۍ���</param>
        /// <returns>�ϊ�����int�l</returns>
        public static int GetIntNullZero(object target)
        {
            int rtn = 0;
            if (target != null)
            {
                int.TryParse(target.ToString(), out rtn);
            }
            return rtn;
        }

        /// <summary>
        /// ����̒l�𕶎���(string)�ɕϊ��B
        /// �ϊ��ł��Ȃ��ꍇ�͋󕶎���ݒ�B
        /// </summary>
        /// <param name="target">�Ώۍ���</param>
        /// <returns>�ϊ�����string�l</returns>
        public static string GetString(object target)
        {
            if (target != null)
            {
                return target.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion


        // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��10 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region  ���K�C�h�i�c�[���o�[�j
        /// <summary>
        /// �c�[���o�[�@�K�C�h�@���_
        /// </summary>
        private void GuideSection()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._guideControl.SecInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Value = secInfoSet.SectionCode.Trim();
                    this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_SECTIONNM].Value = secInfoSet.SectionGuideNm.Trim();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// �c�[���o�[�@�K�C�h�@���Ӑ�
        /// </summary>
        private void GuideCustomer()
        {
            // �K�C�h�\��
            DialogResult result = _guideControl.CustomerSearchForm.ShowDialog();
            if (result == DialogResult.OK && _guideControl.CustomerGuideRet != null)
            {
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Value = _guideControl.CustomerGuideRet.CustomerCode;
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_CUSTOMERNAME].Value = _guideControl.CustomerGuideRet.Name.Trim();
            }
        }
        /// <summary>
        /// �c�[���o�[�@�K�C�h�@���i������
        /// </summary>
        private void GuideGoodsMGroup()
        {
            GoodsGroupU goodsGroupU;
            int status = _guideControl.GoodsAcs.ExecuteGoodsMGroupGuid(_enterpriseCode, out goodsGroupU);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsGroupU != null)
            {
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value = goodsGroupU.GoodsMGroup.ToString();
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value = goodsGroupU.GoodsMGroup;
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Value = goodsGroupU.GoodsMGroupName.Trim();
            }
        }
        /// <summary>
        /// �c�[���o�[�@�K�C�h�@BL�R�[�h
        /// </summary>
        private void GuideBLCode()
        {
            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = _guideControl.BLGoodsCdAcs.ExecuteGuid(_enterpriseCode, out blGoodsCdUMnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && blGoodsCdUMnt != null)
            {
                // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��35 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value = blGoodsCdUMnt.BLGoodsCode.ToString();
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Value = blGoodsCdUMnt.BLGoodsCode.ToString("00000");
                // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��35 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSCODE].Value = blGoodsCdUMnt.BLGoodsCode;
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Value = blGoodsCdUMnt.BLGoodsFullName.Trim();

                // ���i�����ނ��擾���邽�߁A�ēx����
                _guideControl.BLGoodsCdAcs.Read(out blGoodsCdUMnt, _enterpriseCode, blGoodsCdUMnt.BLGoodsCode);
                
                if (!blGoodsCdUMnt.GoodsRateGrpCode.Equals(0))
                {
                    int goodsMGroupOld = 0;
                    int.TryParse(this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Value.ToString(), out goodsMGroupOld);
                    // ���i������ 
                    this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMGROUP].Value = blGoodsCdUMnt.GoodsRateGrpCode;
                    // ���i�����ޖ��̂̎擾
                    GoodsMGroupReadAndSet(blGoodsCdUMnt.GoodsRateGrpCode.ToString(), goodsMGroupOld.ToString(), this.uGrid_Details.ActiveCell);
                }
            }
        }
        /// <summary>
        /// �c�[���o�[�@�K�C�h�@���[�J�[
        /// </summary>
        private void GuideMaker()
        {
            MakerUMnt maker;
            int status = _guideControl.MakerAcs.ExecuteGuid(_enterpriseCode, out maker);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && maker != null)
            {
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Value = maker.GoodsMakerCd.ToString();
                this.uGrid_Details.ActiveCell.Row.Cells[AutoAnsItemStAcs.ct_COL_MAKERNAME].Value = maker.MakerName.Trim();
            }
        }
        #endregion
        // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��10 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �O���b�h�̊e��̕���ۊ�
        /// </summary>
        private void GridWidthSave()
        {
            if (uGrid_Details.Rows.Count > 0)
            {
                CellsCollection cell = uGrid_Details.Rows[0].Cells;
                widthDelete = cell[AutoAnsItemStAcs.ct_COL_LOGICALDELETEDATE].Width;        // �폜��
                widthNo = cell[AutoAnsItemStAcs.ct_COL_ROWNUMBERDISPLAY].Width;             // ��
                widthSection = cell[AutoAnsItemStAcs.ct_COL_SECTIONCODE].Width;             // ���_
                widthCustomer = cell[AutoAnsItemStAcs.ct_COL_CUSTOMERCODE].Width;           // ���Ӑ�
                widthGoodsMGroup = cell[AutoAnsItemStAcs.ct_COL_GOODSMGROUPDISPLAY].Width;  // ���i������
                widthGoodsMGroupName = cell[AutoAnsItemStAcs.ct_COL_GOODSMGROUPNAME].Width; // ���i�����ޖ���
                widthBlCode = cell[AutoAnsItemStAcs.ct_COL_BLGOODSCODEDISPLAY].Width;       // BL�R�[�h
                widthBlCodeName = cell[AutoAnsItemStAcs.ct_COL_BLGOODSNAME].Width;          // BL�R�[�h����
                widthMaker = cell[AutoAnsItemStAcs.ct_COL_GOODSMAKERCD].Width;              // ���[�J�[
                widthMakerName = cell[AutoAnsItemStAcs.ct_COL_MAKERNAME].Width;             // ���[�J�[����
                widthType = cell[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2DISPLAY].Width;        // �� ��
                widthTypeName = cell[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Width;         // ��ʖ���
                widthAutoAnsDiv = cell[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Width;        // �����񓚋敪
                widthPriority = cell[AutoAnsItemStAcs.ct_COL_PRIORITYORDERDISPLAY].Width;   // �D�揇��
            }
        }
        // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��24 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��26 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �O���b�h�񕝏����l�Z�b�g
        /// </summary>
        private void GridWidthSet()
        {
            // --- UPD 2012/11/22 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��77 --------->>>>>>>>>>>>>>>>>>>>>>>>
            widthDelete = 80;            // �폜��
            widthNo = 49;                // ��
            widthSection = 54;           // ���_
            widthCustomer = 94;          // ���Ӑ�
            widthGoodsMGroup = 74;       // ���i������
            widthGoodsMGroupName = 133;  // ���i�����ޖ���
            widthBlCode = 74;            // BL�R�[�h
            widthBlCodeName = 134;       // BL�R�[�h����
            widthMaker = 64;             // ���[�J�[
            widthMakerName = 132;        // ���[�J�[����
            widthAutoAnsDiv = 139;       // �����񓚋敪
            widthPriority = 50;          // �D�揇��

            #region ���\�[�X
            //widthDelete = 80;            // �폜��
            //widthNo = 35;                // ��
            //widthSection = 40;           // ���_
            //widthCustomer = 80;          // ���Ӑ�
            //widthGoodsMGroup = 60;       // ���i������
            //widthGoodsMGroupName = 119;  // ���i�����ޖ���
            //widthBlCode = 60;            // BL�R�[�h
            //widthBlCodeName = 120;       // BL�R�[�h����
            //widthMaker = 50;             // ���[�J�[
            //widthMakerName = 118;        // ���[�J�[����
            //// UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��35 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //// widthType = 40;              // �� ��
            //widthType = 36;              // �� ��
            //// UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��35 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            //widthTypeName = 118;         // ��ʖ���
            //widthAutoAnsDiv = 125;       // �����񓚋敪
            //// UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��35 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //// widthPriority = 40;          // �D�揇��
            //widthPriority = 36;          // �D�揇��
            //// UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��35 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            #endregion
            // --- UPD 2012/11/22 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��77 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }
        // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��26 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
    }
}