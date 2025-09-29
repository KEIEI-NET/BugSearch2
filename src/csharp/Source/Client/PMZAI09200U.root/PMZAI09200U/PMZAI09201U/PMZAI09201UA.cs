using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�݌Ɉꊇ�o�^�C���t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�݌Ɉꊇ�o�^�C���֘A�̈ꗗ�\�����s���t�H�[���N���X�ł��B<br />
    /// <br>Programmer : 30452 ��� �r��<br />
    /// <br>Date       : 2008.12.22<br />
    /// <br>Update Note: 2009.02.03 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�(10780,10775,10769,10752,10749,10748,10746,10739,10738)</br>
    /// <br>            �E��Q�Ή�(10786,10785,10784,10737,10736)</br>
    /// <br>Update Note: 2009.02.03 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�(10777)</br>
    /// <br>Update Note: 2009.02.04 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�(10787)</br>
    /// <br>Update Note: 2009.02.05 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�(10790)</br>
    /// <br>Update Note: 2009.02.12 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�(11364)</br>
    /// <br>Update Note: 2009/02/23 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�10766 �����s�I��Ή�</br>
    /// <br>Update Note: 2009/03/03 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12104,12103,12081,12074,12075</br>
    /// <br>Update Note: 2009/03/03 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12079</br>
    /// <br>Update Note: 2009/03/05 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12082,12070,12132,12073,12205</br>
    /// <br>Update Note: 2009/03/10 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12223</br>
    /// <br>Update Note: 2009/11/26 30434 �H�� �b�D</br>
    /// <br>            �E��Q�Ή�14686</br>
    /// <br>Update Note: 2010/06/08 ���� ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
    /// <br>Update Note: 2010/08/11 ���� ��Q���ǑΉ��i�W�����j �L�[�{�[�h����̉��ǂ��s��</br>
    /// <br>Update Note: 2011/08/03 ����R</br>
    /// <br>            �ERedmine23379</br>
    /// <br>�@�݌ɓo�^���ɊǗ��敪�P�E�Q�������͂̏ꍇ�A�R�[�h�O���Z�b�g���Ē����l�ɂ��܂����B</br>
    /// <br>�A�Ǘ��敪�}�X�^�ɓo�^�̖����R�[�h�̓��͂��������ۂ́A�}�X�^�̑��݃`�F�b�N���s�킸�ɓo�^�\�Ƃ��܂���</br>
    /// <br>Update Note: 2011/08/23 wangf</br>
    /// <br>            �ERedmine23907</br>
    /// <br>�@�Ώۋ敪�u���i�v��I��ł���̂ŁA���̃��b�Z�[�W�u�݌ɏ�񖢓��͂ł��v�͕s�v�ł�</br>
    /// <br>Update Note: 2011/10/31 ������</br>
    /// <br>            .��Q�Ή� Redmine#26317</br>
    /// <br>Update Note: 2011/11/29 30517 �Ė� �x��</br>
    /// <br>             ���i�݌Ɉꊇ�o�^�C���������̃^�C���A�E�g���Ԃ�60�b�ɉ���</br>
    /// <br>Update Note: 2012/09/19 ������</br>
    /// <br>            .��Q�Ή� Redmine#32370�@�E�ʏ��������V��ʂ̏C��</br>
    /// <br>Update Note: 2013/03/18 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 20150515�z�M���̑Ή�</br>
    /// <br>           : Redmine#34962 �@�u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���Ή�</br>
    /// <br>Update Note: 2013/05/11 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 20150515�z�M���̑Ή�</br>
    /// <br>           : Redmine#35018 �u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���@���̂Q�Ή�</br>
    /// </remarks>
    public partial class PMZAI09201UA : Form
    {
        #region ��private�萔
        private const string CT_PGID = "PMZAI09201U";
        private readonly Color CT_EssentialColor = Color.FromArgb(179, 219, 231);
        private readonly Color CT_OptionalColor = Color.FromArgb(255, 255, 255);
        #endregion

        #region ��private�ϐ�

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin;

        // ��ƃR�[�h
        private string _enterpriseCode;
        // �����_�R�[�h
        private string _sectionCode;

        // �K�C�h�֘A
        // ���[�J�[�K�C�h
        private MakerAcs _makerAcs;
        // �q�ɃK�C�h
        private WarehouseAcs _warehouseAcs;
        // ���i�����ރK�C�h
        private GoodsGroupUAcs _goodsGroupUAcs;
        // BL�R�[�h�K�C�h
        private BLGoodsCdAcs _blGoodsCdAcs;
        // �Ǘ����_�K�C�h
        SecInfoSetAcs _secInfoSetAcs;
        // �S���҃K�C�h
        private EmployeeAcs _employeeAcs;

        // �����������t���O (true:������)
        private bool _initializeFinish = false;
        // �t�H�[��Close�O���������t���O
        private bool _closeCheckFinish = false;

        // ���o�����O����͒l(�X�V�L���`�F�b�N�p)
        private int _tmpGoodsMakerCd;
        private int _tmpGoodsMGroup;
        private int _tmpBLGoodsCode;
        private string _tmpWareHouseCode;
        private string _tmpEmployeeCode;
        private string _tmpSectionCode;

        private int _tmpDisplayDivValue; // ADD 2009/02/03
        private int _tmpTargetDivValue; // ADD 2009/02/03

        // ���׃O���b�h�R���g���[���N���X
        private PMZAI09201UB _detailGrid;
        // ���i�݌Ɉꊇ�o�^�C���A�N�Z�X�N���X
        private GoodsStockAcs _goodsStockAcs;

        private object _preComboEditorValue = null; // ADD 2010/08/11

        private int _maxCount = 0; //ADD yangyi 2013/03/18 Redmine#34962 

        private PMZAI09201UC _form = null;  //ADD yangyi 2013/03/18 Redmine#34962 
     
        #endregion

        #region ���R���X�g���N�^
        /// <summary>
        /// 
        /// </summary>
        public PMZAI09201UA()
        {
            InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();

            // ���O�C�����擾
            this.GetLoginInfo();

            // �K�C�h������
            this.GetGuideInstance();

            // �O���b�h
            this._detailGrid = new PMZAI09201UB();

            // ���i�݌Ɉꊇ�o�^�C���A�N�Z�X�N���X
            this._goodsStockAcs = GoodsStockAcs.GetInstance();

            // ���o�����擾�C�x���g
            this._detailGrid.GetExtractInfo += new PMZAI09201UB.GetExtractInfoHander(this.DetailGrid_GetExtractInfo);

            // �t�H�[�J�X�ݒ�C�x���g
            this._detailGrid.SetFocus += new PMZAI09201UB.SettingFocusEventHandler(this.DetailGrid_SetFocus);

            // �ۑ��{�^�������ېݒ�C�x���g
            this._detailGrid.SetSaveButton += new PMZAI09201UB.SetSaveButtonEnableHandler(this.SetSaveButtonEnable); // ADD 2009/02/03

            this._detailGrid.SetGuide += new PMZAI09201UB.SetGuideEnabled(this.SetGuideEnabled); // ADD 2010/08/11
        }
        #endregion

        #region ��public�v���p�e�B
        /// <summary>
        /// �t�H�[��Close�O���������t���O
        /// </summary>
        public bool FormCloseCheckFinish
        {
            get { return this._closeCheckFinish; }
        }
        #endregion

        #region ��public���\�b�h

        /// <summary>
        /// �t�H�[��Close�O�X�V�m�F���ۑ�����
        /// </summary>
        public void FormClosingCheck()
        {
            if (!this._closeCheckFinish)
            {
                this.CloseWindow();
            }
        }

        /// <summary>
        /// �w�l�k�f�[�^�̕ۑ�����
        /// </summary>
        public void SaveStateXmlData()
        {
            // �O���b�h����ۑ�
            this._detailGrid.SaveStateXmlData();
        }
        #endregion

        #region ��private���\�b�h

        #region �� �����\���֘A
        /// <summary>
        /// ���O�C�����擾
        /// </summary>
        private void GetLoginInfo()
        {
            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �����_�R�[�h
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        }

        /// <summary>
        /// �A�N�Z�X�N���X������
        /// </summary>
        private void GetGuideInstance()
        {
            this._makerAcs = new MakerAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._employeeAcs = new EmployeeAcs();
        }

        /// <summary>
        /// ��ʏ�����
        /// </summary>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // ������������(�C�x���g����)
                this._initializeFinish = false;

                // --- ADD 2009/03/05 -------------------------------->>>>>
                // �X�L���ύX���O�ݒ�
                List<string> excCtrlNm = new List<string>();
                excCtrlNm.Add(this.uGroupBox_ExtractInfo.Name);
                this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);
                // --- ADD 2009/03/05 --------------------------------<<<<<

                // �X�L���ݒ�
                this._controlScreenSkin.LoadSkin();
                this._controlScreenSkin.SettingScreenSkin(this);

                // �c�[���o�[�A�C�R���ݒ�
                tToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
                this.tToolbarsManager1.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
                this.tToolbarsManager1.Tools["ButtonTool_Save"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
                this.tToolbarsManager1.Tools["ButtonTool_New"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL; // ADD 2009/02/03
                this.tToolbarsManager1.Tools["ButtonTool_Search"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
                this.tToolbarsManager1.Tools["ButtonTool_Guide"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE; // ADD 2010/08/11
                this.tToolbarsManager1.Tools["ButtonTool_Renewal"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL; // ADD 2010/08/11
                this.tToolbarsManager1.Tools["ButtonTool_SetUp"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;  //ADD yangyi 2013/03/18 Redmine#34962 

                // �K�C�h�{�^���A�C�R���ݒ�
                this.SetIconImage(this.uButton_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_WarehouseCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_GoodsMGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_BLGoodsCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_SectionCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_EmployeeCdGuide, Size16_Index.STAR1);

                // �ۑ��{�^�������ېݒ�
                this.SetSaveButtonEnable(); // ADD 2009/02/03

                // �p�l���\�����\����
                this.Panel_GoodsMGroup.Visible = false;
                this.Panel_WareHouse.Visible = false;
                this.Panel_Section.Visible = false;
                this.Panel_BLGoodsCode.Visible = false;

                // �폜�s��\�����Ȃ�
                this.DeleteIndication_CheckEditor.Checked = false;

                // �\���敪
                //this.tComboEditor_DisplayDiv.Value = 0; // DEL 2009/02/03
                this.tComboEditor_DisplayDiv.Value = 1; // ADD 2009/02/03

                // �Ώۋ敪
                this.tComboEditor_TargetDiv.ResetItems(); // ADD 2009/02/03
                this.SetTComboEditor_TargetDiv(); // ADD 2009/02/03
                this.tComboEditor_TargetDiv.Value = 0;

                // �o�͎w��(ValueList�ݒ�)
                this.tComboEditor_OutputDiv.ResetItems();
                this.SetTComboEditor_OutputDiv();
                this.tComboEditor_OutputDiv.Value = 0;

                // �o�͎w��(�\���L��)
                this.SetTComboEditor_OutputDivVisible();

                // ���o�����R�[�h�A���̂̃N���A
                this.tNedit_GoodsMakerCd.SetInt(0);
                this.uLabel_GoodsMakerName.Text = string.Empty;
                this.tEdit_WarehouseCode.DataText = string.Empty;
                this.uLabel_WareHouseName.Text = string.Empty;
                this.tNedit_GoodsMGroup.SetInt(0);
                this.uLabel_GoodsMGroupName.Text = string.Empty;
                this.tEdit_GoodsNo.DataText = string.Empty;
                this.tNedit_BLGoodsCode.SetInt(0);
                this.uLabel_BLGoodsCodeName.Text = string.Empty;
                this.tEdit_SectionCode.DataText = string.Empty;
                this.uLabel_SectionName.Text = string.Empty;
                this.tEdit_EmployeeCode.DataText = string.Empty;
                this.uLabel_EmployeeName.Text = string.Empty;

                // ���o�����ۑ��l�̃N���A
                this._tmpGoodsMakerCd = 0;
                this._tmpWareHouseCode = string.Empty;
                this._tmpGoodsMGroup = 0;
                this._tmpBLGoodsCode = 0;
                this._tmpSectionCode = string.Empty;
                this._tmpEmployeeCode = string.Empty;

                this._tmpDisplayDivValue = 0; // ADD 2009/02/03
                this._tmpTargetDivValue = 0; // ADD 2009/02/03

                // ���o�����ݒ�
                this.SetExtractItemSettings();

                // ��������������
                this._initializeFinish = true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// �K�C�h�{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }

        /// <summary>
        /// �Ώۋ敪���X�g�{�b�N�X�ݒ�
        /// </summary>
        private void SetTComboEditor_TargetDiv()
        {
            Infragistics.Win.ValueListItem listItem;

            if ((int)this.tComboEditor_DisplayDiv.SelectedItem.DataValue == 0) // �\���敪 �V�K�o�^
            {
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                //listItem.DisplayText = "���i"; // DEL 2010/08/11
                listItem.DisplayText = "0:���i"; // ADD 2010/08/11
                this.tComboEditor_TargetDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 3;
                listItem.DataValue = 3;
                //listItem.DisplayText = "�݌�"; // DEL 2010/08/11
                listItem.DisplayText = "3:�݌�"; // ADD 2010/08/11
                this.tComboEditor_TargetDiv.Items.Add(listItem);
            }
            else  // �\���敪 �C���o�^
            {
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                //listItem.DisplayText = "���i"; // DEL 2010/08/11
                listItem.DisplayText = "0:���i"; // ADD 2010/08/11
                this.tComboEditor_TargetDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                //listItem.DisplayText = "���i-�݌�"; // DEL 2010/08/11
                listItem.DisplayText = "1:���i-�݌�"; // ADD 2010/08/11
                this.tComboEditor_TargetDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                //listItem.DisplayText = "�݌�-���i"; // DEL 2010/08/11
                listItem.DisplayText = "2:�݌�-���i"; // ADD 2010/08/11
                this.tComboEditor_TargetDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 3;
                listItem.DataValue = 3;
                //listItem.DisplayText = "�݌�"; // DEL 2010/08/11
                listItem.DisplayText = "3:�݌�"; // ADD 2010/08/11
                this.tComboEditor_TargetDiv.Items.Add(listItem);
            }
        }

        /// <summary>
        /// �o�̓��X�g�{�b�N�X�ݒ�
        /// </summary>
        private void SetTComboEditor_OutputDiv()
        {
            Infragistics.Win.ValueListItem listItem;

            if (this._goodsStockAcs.RateProtyMngExist) 
            {
                // �|���D��Ǘ���񂪂���
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                //listItem.DisplayText = "�S��"; // DEL 2010/08/11
                listItem.DisplayText = "0:�S��"; // ADD 2010/08/11
                this.tComboEditor_OutputDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                //listItem.DisplayText = "���[�U���i�ݒ蕪"; // DEL 2010/08/11
                listItem.DisplayText = "1:���[�U���i�ݒ蕪"; // ADD 2010/08/11
                this.tComboEditor_OutputDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                //listItem.DisplayText = "�����ݒ蕪"; // DEL 2010/08/11
                listItem.DisplayText = "2:�����ݒ蕪"; // ADD 2010/08/11
                this.tComboEditor_OutputDiv.Items.Add(listItem);
            }
            else
            {
                // �|���D��Ǘ���񂪂Ȃ�
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                //listItem.DisplayText = "�S��"; // DEL 2010/08/11
                listItem.DisplayText = "0:�S��"; // ADD 2010/08/11
                this.tComboEditor_OutputDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                //listItem.Tag = 2; // DEL 2010/08/11
                //listItem.DataValue = 2; // DEL 2010/08/11
                //listItem.DisplayText = "�����ݒ蕪"; // DEL 2010/08/11
                listItem.Tag = 1; // ADD 2010/08/11
                listItem.DataValue = 1; // ADD 2010/08/11
                listItem.DisplayText = "1:�����ݒ蕪"; // ADD 2010/08/11
                this.tComboEditor_OutputDiv.Items.Add(listItem);
            }
        }

        /// <summary>
        /// �o�͎w�胊�X�g�{�b�N�X�ݒ�
        /// </summary>
        private void SetTComboEditor_OutputDivVisible()
        {
            if ((int)this.tComboEditor_DisplayDiv.SelectedItem.DataValue == 0
                || (int)this.tComboEditor_TargetDiv.SelectedItem.DataValue == 3) // �\���敪�u�V�K�o�^�v���Ώۋ敪�u�݌Ɂv
            {
                // �\�����Ȃ�
                this.uLabel_OutputDiv.Visible = false;
                this.tComboEditor_OutputDiv.Visible = false;
            }
            else
            {
                // �\������
                this.uLabel_OutputDiv.Visible = true;
                this.tComboEditor_OutputDiv.Visible = true;
            }
        }
        #endregion

        #region �� ���o�����p�l���ݒ�
        /// <summary>
        /// ���o�����ݒ�
        /// </summary>
        private void SetExtractItemSettings()
        {
            // �p�l������x��\���ɂ���
            this.Panel_WareHouse.Visible = false;
            this.Panel_GoodsMGroup.Visible = false;
            this.Panel_BLGoodsCode.Visible = false;
            this.Panel_Section.Visible = false;

            // �p�l���ʒu����
            this.Panel_GoodsMGroup.Location = this.Panel_WareHouse.Location;
            this.Panel_BLGoodsCode.Location = this.Panel_Section.Location;

            if ((ExtractInfo.DisplayDivState)this.tComboEditor_DisplayDiv.SelectedItem.DataValue 
                == ExtractInfo.DisplayDivState.New)
            {
                // �\���敪�u�V�K�o�^�v
                if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue 
                    == ExtractInfo.TargetDivState.Goods)
                {
                    // �Ώۋ敪�u���i�v
                    this.Panel_GoodsMGroup.Visible = false;
                    this.Panel_BLGoodsCode.Visible = true;
                    this.Panel_WareHouse.Visible = false;
                    this.Panel_Section.Visible = false;

                    // ���͕K�{����
                    this.tNedit_GoodsMakerCd.Appearance.BackColor = this.CT_EssentialColor;
                    this.tNedit_BLGoodsCode.Appearance.BackColor = this.CT_OptionalColor;
                    this.tEdit_WarehouseCode.Appearance.BackColor = this.CT_OptionalColor;
                    this.tEdit_SectionCode.Appearance.BackColor = this.CT_OptionalColor;
                }
                else
                {
                    // �Ώۋ敪�u�݌Ɂv
                    this.Panel_WareHouse.Visible = true;
                    this.Panel_Section.Visible = true;
                    this.Panel_GoodsMGroup.Visible = false;
                    this.Panel_BLGoodsCode.Visible = false;

                    // ���͕K�{����
                    this.tNedit_GoodsMakerCd.Appearance.BackColor = this.CT_EssentialColor;
                    this.tEdit_WarehouseCode.Appearance.BackColor = this.CT_EssentialColor;
                    this.tEdit_SectionCode.Appearance.BackColor = this.CT_EssentialColor;
                    this.tNedit_BLGoodsCode.Appearance.BackColor = this.CT_OptionalColor;
                }
            }
            else
            {
                // �\���敪�u�C���o�^�v
                if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.Goods
                    || (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.GoodsStock)
                {
                    // �Ώۋ敪�u���i�v�u���i-�݌Ɂv
                    this.Panel_GoodsMGroup.Visible = true; // ���i������
                    this.Panel_BLGoodsCode.Visible = true; // BL�R�[�h
                    this.Panel_WareHouse.Visible = false;
                    this.Panel_Section.Visible = false;

                    this.tNedit_BLGoodsCode.Appearance.BackColor = this.CT_OptionalColor;
                    this.tNedit_GoodsMakerCd.Appearance.BackColor = this.CT_OptionalColor;
                    this.tEdit_WarehouseCode.Appearance.BackColor = this.CT_OptionalColor;
                    this.tEdit_SectionCode.Appearance.BackColor = this.CT_OptionalColor;
                }
                else if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.StockGoods)
                {
                    // �Ώۋ敪�u�݌�-���i�v
                    this.Panel_WareHouse.Visible = true;
                    this.Panel_Section.Visible = true;
                    this.Panel_GoodsMGroup.Visible = false;
                    this.Panel_BLGoodsCode.Visible = false;

                    this.tNedit_GoodsMakerCd.Appearance.BackColor = this.CT_OptionalColor;
                    this.tEdit_WarehouseCode.Appearance.BackColor = this.CT_OptionalColor;
                    this.tEdit_SectionCode.Appearance.BackColor = this.CT_OptionalColor;
                    this.tNedit_BLGoodsCode.Appearance.BackColor = this.CT_OptionalColor;
                }
                else
                {
                    // �Ώۋ敪�u�݌Ɂv
                    this.Panel_WareHouse.Visible = true;
                    this.Panel_Section.Visible = true;
                    this.Panel_GoodsMGroup.Visible = false;
                    this.Panel_BLGoodsCode.Visible = false;

                    // ���͕K�{����
                    this.tNedit_GoodsMakerCd.Appearance.BackColor = this.CT_EssentialColor;
                    this.tEdit_WarehouseCode.Appearance.BackColor = this.CT_EssentialColor; // ADD 2009/02/03
                    this.tEdit_SectionCode.Appearance.BackColor = this.CT_EssentialColor; // ADD 2009/02/03
                    this.tNedit_BLGoodsCode.Appearance.BackColor = this.CT_OptionalColor;
                }
            }
        }

        #endregion

        # region �� ���o�����擾���� ��
        /// <summary>
        /// ���o�������擾����
        /// </summary>
        /// <returns>���\�b�h�ďo�����̒��o����</returns>
        /// <remarks>�O���b�h�����f���Q�[�g�ďo������</remarks>
        private ExtractInfo GetExtractInfo()
        {
            ExtractInfo extractInfo = new ExtractInfo();

            // �\���敪
            extractInfo.DisplayDiv
                = (ExtractInfo.DisplayDivState)this.tComboEditor_DisplayDiv.SelectedItem.DataValue;
            // �Ώۋ敪
            extractInfo.TargetDiv
                = (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue;
            // �o�͎w��
            extractInfo.OutputDiv
                = (ExtractInfo.OutputDivState)this.tComboEditor_OutputDiv.SelectedItem.DataValue;

            // ���i���[�J�[�R�[�h
            extractInfo.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            extractInfo.MakerName = this.uLabel_GoodsMakerName.Text;

            // ���i������
            extractInfo.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();
            extractInfo.GoodsMGroupName = this.uLabel_GoodsMGroupName.Text;

            // �q�ɃR�[�h
            extractInfo.WarehouseCode = this.tEdit_WarehouseCode.DataText;
            extractInfo.WarehouseName = this.uLabel_WareHouseName.Text;

            // �i��
            extractInfo.GoodsNo = this.tEdit_GoodsNo.DataText;
            
            // �a�k�R�[�h
            extractInfo.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            extractInfo.BLGoodsName = this.uLabel_BLGoodsCodeName.Text;
            
            // �Ǘ����_�R�[�h
            extractInfo.AddUpSectionCode = this.tEdit_SectionCode.DataText;
            extractInfo.AddUpSectionGuidNm = this.uLabel_SectionName.Text;

            // ���͒S���҃R�[�h
            extractInfo.StockAgentCode = this.tEdit_EmployeeCode.DataText;
            extractInfo.StockAgentName = this.uLabel_EmployeeName.Text;

            // �폜�ς݃f�[�^�\���{�^�����
            extractInfo.DeleteIndication = this.DeleteIndication_CheckEditor.Checked;

            return extractInfo;
        }
        #endregion

        # region �� �������� ��
        /// <summary>
        /// ��������
        /// </summary>
        private void Search()
        {
            int status = -1;

            // �ύX�L���`�F�b�N
            bool isChanged = this.CompareGridDataWithOriginal();

            if (isChanged)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                    "�j�����Ă���낵���ł����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            string errMsg;
            Control errCtl;

            // ���͏����`�F�b�N
            if (!this.SearchBeforeCheck(out errMsg, out errCtl))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errCtl != null)
                {
                    errCtl.Focus();
                    // --- ADD 2010/08/09 ---------->>>>>
                    switch (errCtl.Name)
                    {
                        case "tEdit_EmployeeCode":
                        case "tNedit_GoodsMakerCd":
                        case "tNedit_BLGoodsCode":
                        case "tEdit_WarehouseCode":
                        case "tEdit_SectionCode":
                        case "tNedit_GoodsMGroup":
                        {
                            ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = true;
                            break;
                        }
                        default:
                        {
                            ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false;
                            break;
                        }
                    }
                    // --- ADD 2010/08/09 ----------<<<<<
                }

                return;
            }

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "���o��";
            msgForm.Message = "���i�݌ɏ��̒��o���ł��B";

            // --- ADD 2009/02/04 -------------------------------->>>>>
            // �L�����Z���{�^���ǉ�
            msgForm.DispCancelButton = true;
            msgForm.CancelButtonClick += new EventHandler(this.SearchCancelButton_Click);
            this._goodsStockAcs.CancelFlg = false;
            // --- ADD 2009/02/04 --------------------------------<<<<<

            try
            {
                msgForm.Show();

                if ((ExtractInfo.DisplayDivState)this.tComboEditor_DisplayDiv.SelectedItem.DataValue ==
                    ExtractInfo.DisplayDivState.New
                    && (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue ==
                    ExtractInfo.TargetDivState.Goods)
                {
                    // �V�K�o�^�̏��i���A�񋟃f�[�^����
                    status = this.ExecuteOfferGoodsUnitDataSearch(out errMsg);
                }
                else
                {
                    // �C���o�^���A���[�U�f�[�^����
                    status = this.ExecuteUserGoodsUnitDataSearch(out errMsg);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // --- ADD 2009/03/03 -------------------------------->>>>>
                    // �\�[�g�A�t�B���^��Ԃ̔j��
                    this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();
                    this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.RefreshSort(true);
                    this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    // --- ADD 2009/03/03 --------------------------------<<<<<

                    // �O���b�h�\���̍X�V
                    this._detailGrid.SetGridSettings();

                    // �L�[���ڂ�Activation����
                    this._detailGrid.SetCellActivation();

                    // �폜�ς݃f�[�^�\���E��\���̔��f
                    this._detailGrid.DeleteIndicationSetting(this.DeleteIndication_CheckEditor.Checked);

                    msgForm.Close();

                    if (this._goodsStockAcs.CancelFlg)
                    {
                        // �L�����Z���������b�Z�[�W
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���������𒆒f���܂����B",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                    }
                    // ADD gezh 2013/01/24 Redmine#33361 �u20000���v�̉��C�� ----->>>>>
                    if (this._goodsStockAcs.OutMaxCount)
                    {
                        // �L�����Z���������b�Z�[�W
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�f�[�^������20,000���𒴂��܂����B",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                    }
                    // ADD gezh 2013/01/24 Redmine#33361 �u20000���v�̉��C�� -----<<<<<
                    int activationColIndex;
                    int activationRowIndex;

                    // �t�H�[�J�X�ݒ�
                    string nextFocusColKey = this._detailGrid.GetNextFocusColumnKey(0, 0, false, out activationColIndex, out activationRowIndex);

                    if (nextFocusColKey != string.Empty)
                    {
                        this._detailGrid.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColKey].Activate();
                        //this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        // --- ADD 2009/02/23 -------------------------------->>>>>
                        if (!this._detailGrid.uGrid_Details.Rows[activationRowIndex].IsFilteredOut)
                        {
                            this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            if (this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.BelowCell))
                            {
                                this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this._detailGrid.uGrid_Details.ActiveCell = null;
                                this._detailGrid.uGrid_Details.ActiveRow = null;
                            }
                        }
                        // --- ADD 2009/02/23 --------------------------------<<<<<
                    }
                }
                // --- ADD 2009/02/03 -------------------------------->>>>>
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF
                        || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    msgForm.Close();

                    // 0���G���[
                    DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���������ɊY������f�[�^�����݂��܂���",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                }
                // 2011/11/29 Add >>>
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgForm.Close();

                    // �^�C���A�E�g�G���[
                    DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���������ݍ����Ă��܂��B\n�����o���Ă���A�ēx�������s���ĉ������B",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                }
                // 2011/11/29 Add <<<
                else
                {
                    msgForm.Close();

                    // ���̑��G���[
                    DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            this.Name,
                            "���������ŃG���[���������܂���" + "[" + errMsg + "]",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                }
                // --- ADD 2009/02/03 --------------------------------<<<<<
            }
            finally
            {
                //msgForm.Close();
                this.SetSaveButtonEnable(); // ADD 2009/02/03
                this._detailGrid.SetButtonEnable(); // ADD 2009/02/23
            }
        }

        /// <summary>
        /// ���������O���͍��ڃ`�F�b�N
        /// </summary>
        /// <returns></returns>
        private bool SearchBeforeCheck(out string errMsg, out Control errCtl)
        {
            bool status = true;
            errMsg = string.Empty;
            errCtl = null;

            if ((ExtractInfo.DisplayDivState)this.tComboEditor_DisplayDiv.SelectedItem.DataValue 
                == ExtractInfo.DisplayDivState.New)
            {
                // �\���敪�u�V�K�o�^�v
                if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                    == ExtractInfo.TargetDivState.Goods)
                {
                    // �Ώۋ敪�u���i�v
                    if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                    {
                        status = false;
                        errMsg = "���[�J�[�R�[�h����͂��Ă�������";
                        errCtl = tNedit_GoodsMakerCd;
                    }
                    else if (string.IsNullOrEmpty(this.tEdit_GoodsNo.DataText)
                        && this.tNedit_BLGoodsCode.GetInt() == 0)
                    {
                        status = false;
                        errMsg = "�i�Ԃ�BL�R�[�h����͂��Ă�������";
                        if (string.IsNullOrEmpty(this.tEdit_GoodsNo.DataText))
                        {
                            errCtl = tEdit_GoodsNo;
                        }
                        else
                        {
                            errCtl = tNedit_BLGoodsCode;
                        }
                    }
                }
                else
                {
                    // �Ώۋ敪�u�݌Ɂv
                    if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                    {
                        status = false;
                        errMsg = "���[�J�[�R�[�h����͂��Ă�������";
                        errCtl = tNedit_GoodsMakerCd;
                    }
                    // --- ADD 2009/03/10 -------------------------------->>>>>
                    else if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.DataText))
                    {
                        status = false;
                        errMsg = "�q�ɃR�[�h����͂��Ă�������";
                        errCtl = tEdit_WarehouseCode;
                    }
                    else if (string.IsNullOrEmpty(this.tEdit_SectionCode.DataText))
                    {
                        status = false;
                        errMsg = "�Ǘ����_�R�[�h����͂��Ă�������";
                        errCtl = tEdit_SectionCode;
                    }
                    // --- ADD 2009/03/10 --------------------------------<<<<<
                }
            }
            else
            {
                // �\���敪�u�C���o�^�v
                if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue 
                    == ExtractInfo.TargetDivState.Stock)
                {
                    // �Ώۋ敪�u�݌Ɂv
                    if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                    {
                        status = false;
                        errMsg = "���[�J�[�R�[�h����͂��Ă�������";
                        errCtl = tNedit_GoodsMakerCd;
                    }
                    // --- ADD 2009/02/03 -------------------------------->>>>>
                    else if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.DataText))
                    {
                        status = false;
                        errMsg = "�q�ɃR�[�h����͂��Ă�������";
                        errCtl = tEdit_WarehouseCode;
                    }
                    else if (string.IsNullOrEmpty(this.tEdit_SectionCode.DataText))
                    {
                        status = false;
                        errMsg = "�Ǘ����_�R�[�h����͂��Ă�������";
                        errCtl = tEdit_SectionCode;
                    }
                    // --- ADD 2009/02/03 --------------------------------<<<<<
                }
            }

            return status;
        }

        /// <summary>
        /// ���i�A���f�[�^(�񋟕�)��������
        /// </summary>
        /// <returns></returns>
        private int ExecuteOfferGoodsUnitDataSearch(out string errMsg)
        {
            // ���o����(�敪)�擾
            ExtractInfo extractInfo = this.GetExtractInfo();

            extractInfo.MaxCount = _maxCount;  //ADD yangyi 2013/03/18 Redmine#34962

            //string errMsg; // DEL 2009/02/03
            int status = this._goodsStockAcs.SearchOfferGoodsUnitData(extractInfo, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._detailGrid.BeforeSearchExtractInfo = extractInfo;
            }
            // --- DEL 2009/02/03 -------------------------------->>>>>
            //else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF
            //    || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            //{
            //    // 0���G���[
            //    DialogResult dialogResult = TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_INFO,
            //            this.Name,
            //            "���������ɊY������f�[�^�����݂��܂���B",
            //            status,
            //            MessageBoxButtons.OK,
            //            MessageBoxDefaultButton.Button1);
            //}
            //else
            //{
            //    // ���̑��G���[
            //    DialogResult dialogResult = TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_STOP,
            //            this.Name,
            //            "���������ŃG���[���������܂����B" + "["+ errMsg + "]",
            //            status,
            //            MessageBoxButtons.OK,
            //            MessageBoxDefaultButton.Button1);
            //}
            // --- DEL 2009/02/03 --------------------------------<<<<<

            return status;
        }

        /// <summary>
        /// ���i�A���f�[�^(���[�U�[��)��������
        /// </summary>
        /// <returns></returns>
        private int ExecuteUserGoodsUnitDataSearch(out string errMsg)
        {
            // ���o����(�敪)�擾
            ExtractInfo extractInfo = this.GetExtractInfo();

            extractInfo.MaxCount = _maxCount;  //ADD yangyi 2013/03/18 Redmine#34962

            //string errMsg; // DEL 2009/02/03
            int status = this._goodsStockAcs.SearchUserGoodsUnitData(extractInfo, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._detailGrid.BeforeSearchExtractInfo = extractInfo;
            }
            // --- DEL 2009/02/03 -------------------------------->>>>>
            //else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF
            //    || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            //{
            //    // 0���G���[
            //    DialogResult dialogResult = TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_INFO,
            //            this.Name,
            //            "���������ɊY������f�[�^�����݂��܂���",
            //            0,
            //            MessageBoxButtons.OK,
            //            MessageBoxDefaultButton.Button1);
            //}
            //else
            //{
            //    // 0���G���[
            //    DialogResult dialogResult = TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_STOP,
            //            this.Name,
            //            "���������ŃG���[���������܂���" + "[" + errMsg + "]",
            //            0,
            //            MessageBoxButtons.OK,
            //            MessageBoxDefaultButton.Button1);
            //}
            // --- DEL 2009/02/03 --------------------------------<<<<<

            return status;
        }

        # endregion �� �������� ��

        # region �� �I������ ��
        /// <summary>
        /// �I������
        /// </summary>
        /// <param name="isConfirm">true:�m�F�_�C�A���O��\������ false:�\�����Ȃ�</param>
        private void CloseWindow()
        {
            // �ύX�L���`�F�b�N
            bool isChanged =  this.CompareGridDataWithOriginal();

            if (isChanged)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                    "�o�^���Ă���낵���ł����H",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    int status = this.Save();
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this._closeCheckFinish = true;
                        this.Close();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    this._closeCheckFinish = true;
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                this._closeCheckFinish = true;
                this.Close();
            }
        }
        # endregion �� �I������ ��

        # region �� �ۑ����� ��
        /// <summary>
        /// �ۑ�����
        /// </summary>
        private int Save()
        {
            // ADD 2009/11/26 MANTIS�Ή�[14686]�F�����X�V��̍݌Ƀf�[�^�̍X�V�͕s�� ---------->>>>>
            // TODO:�����X�V��ł���΍݌Ƀf�[�^�̍X�V�͍s���Ȃ�
            if (!MAKHN09280UA.CanWrite(DateTime.Now)) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            // ADD 2009/11/26 MANTIS�Ή�[14686]�F�����X�V��̍݌Ƀf�[�^�̍X�V�͕s�� ----------<<<<<
            // --- ADD 2009/02/03 -------------------------------->>>>>
            if (this._detailGrid.uGrid_Details.ActiveCell != null
                && this._detailGrid.uGrid_Details.ActiveCell.IsInEditMode)
            {
                // �ҏW���[�h����������
                this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
            }
            // --- ADD 2009/02/03 --------------------------------<<<<<

            this._goodsStockAcs.GoodsStockDataTable.AcceptChanges(); // ADD 2009/03/10
            // --- ADD 2009/02/03 -------------------------------->>>>>
            // �f�[�^���݃`�F�b�N
            if (this._goodsStockAcs.GoodsStockDataTable.Rows.Count == 0)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "�X�V�Ώۂ̃f�[�^�����݂��܂���",
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);

                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            // --- ADD 2009/02/03 --------------------------------<<<<<

            // �ύX�L���`�F�b�N
            if (this._detailGrid.BeforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update)
            {
                bool isChanged = this.CompareGridDataWithOriginal();

                if (!isChanged)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "�X�V�Ώۂ̃f�[�^�����݂��܂���",
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);

                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }
            }

            string errMsg;
            Control errCtl;

            // ���͏����`�F�b�N
            if (!this.SaveBeforeExtractInfoCheck(out errMsg, out errCtl))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errCtl != null)
                {
                    errCtl.Focus();
                    // --- ADD 2010/08/09 ---------->>>>>
                    switch (errCtl.Name)
                    {
                        case "tEdit_EmployeeCode":
                        case "tNedit_GoodsMakerCd":
                        case "tNedit_BLGoodsCode":
                        case "tEdit_WarehouseCode":
                        case "tEdit_SectionCode":
                        case "tNedit_GoodsMGroup":
                            {
                                ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = true;
                                break;
                            }
                        default:
                            {
                                ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false;
                                break;
                            }
                    }
                    // --- ADD 2010/08/09 ----------<<<<<
                }

                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            // ���̓`�F�b�N�i�O���b�h���j
            if (!this.SaveBeforeGridCheck(out errMsg))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);

                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            
            // �d���`�F�b�N
            if (!this.SaveBeforeDuplicationCheck(out errMsg))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);

                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            // --- ADD 2009/03/10 -------------------------------->>>>>
            // �Ǘ����_�Ⴂ�̃`�F�b�N

            bool dialogflag = false;//ADD 2011/08/03
            if (this._detailGrid.BeforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && this._detailGrid.BeforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
            {
                if (this.AddupSectionCheck())
                {
                    // �x����\��
                    DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "�X�V�ΏۂɊǗ����_�̈Ⴄ�݌ɏ�񂪑��݂��܂��B" + "\r\n" + "\r\n" +
                            "���������œ��͂��ꂽ�Ǘ����_�ōX�V���Ă�낵���ł����H",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                    if (dialogResult != DialogResult.Yes)
                    {
                        return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    //-----ADD 2011/08/03---------->>>>>
                    else
                    {
                        dialogflag = true ;
                    }
                    //-----ADD 2011/08/03----------<<<<<

                }
            }
            // --- ADD 2009/03/10 --------------------------------<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string msg = "";

            Cursor _localCursor = this.Cursor;

            this.Cursor = Cursors.WaitCursor;

            // �ۑ����_�C�A���O�\��
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "�ۑ���";
            msgForm.Message = "���i�݌ɏ��̕ۑ����ł��B";

            //-----ADD 2011/08/03---------->>>>>
            bool noinputflag = false;

            bool flag = false;
            int count = 0;

            while (flag == false && count < this._detailGrid.uGrid_Details.Rows.Count)
            {
                if (this._detailGrid.uGrid_Details.Rows[count].Cells["StockDeleteReserveFlg"].Value.ToString() == "0")
                {
                    flag = true;
                }
                count++;
            }
            //-----ADD 2011/08/03----------<<<<<
            try
            {
                // �ۑ�����            
                status = this._goodsStockAcs.Write(this._detailGrid.BeforeSearchExtractInfo, this.GetExtractInfo(), out msg);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // �O���b�h���N���A����
                            //this._goodsStockAcs.GoodsStockDataTable.Clear();//DEL 2011/08/03
                            //this._goodsStockAcs.OriginalGoodsStockDataTable.Clear();//DEL 2011/08/03

                            //-----ADD 2011/08/03---------->>>>>
                            //if (this._goodsStockAcs.NoneFlag == true && this._goodsStockAcs.HaveNullSectionRow == true && dialogflag ==false) // DEL wangf 2011/08/23
                            //-----ADD 2011/08/23---------->>>>>
                            if ((int)this.tComboEditor_DisplayDiv.SelectedItem.DataValue == 0 
                                  && (int)this.tComboEditor_TargetDiv.SelectedItem.DataValue == 3 
                                  && this._goodsStockAcs.NoneFlag == true 
                                  && this._goodsStockAcs.HaveNullSectionRow == true && dialogflag == false)
                            //-----ADD 2011/08/23----------<<<<<
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    CT_PGID,
                                    "�݌ɏ�񂪖����͂ł�",
                                    status,
                                    MessageBoxButtons.OK);
                                noinputflag = true;
                                if (flag ==true )
                                {
                                    this._detailGrid.uGrid_Details.ActiveCell = this._detailGrid.uGrid_Details.Rows[count-1].Cells["WarehouseShelfNo"];
                                    this._detailGrid.uGrid_Details.Focus();
                                    this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else
                            {
                                this._goodsStockAcs.GoodsStockDataTable.Clear();
                                this._goodsStockAcs.OriginalGoodsStockDataTable.Clear();
                            }
                            //-----ADD 2011/08/03----------<<<<<
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                CT_PGID,
                                //"�o�^�����ɂăG���[���������܂����B", // DEL 2009/03/10
                                "�ꕔ�̏��i�^�݌ɂ̍X�V���o���܂���ł����B" + "\r\n" + "\r\n"
                                + "�G���[���e���m�F���ĉ������B", // ADD 2009/03/10
                                status,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);

                            // �O���b�h�\���̍X�V
                            this._detailGrid.SetGridSettings();

                            // �G���[���b�Z�[�W�s��\��
                            this._detailGrid.uGrid_Details.DisplayLayout.Bands[0]
                                .Columns[this._goodsStockAcs.GoodsStockDataTable.ErrorMessageColumn.ColumnName].Hidden = false; // ADD 2009/03/10

                            // �L�[���ڂ�Activation����
                            this._detailGrid.SetCellActivation();

                            // �폜�ς݃f�[�^�\���E��\���̔��f
                            this._detailGrid.DeleteIndicationSetting(this.DeleteIndication_CheckEditor.Checked);

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                status = -1; // ADD 2009/02/23
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                    CT_PGID,
                    "�o�^�����ɂăG���[���������܂����B" + "[" + ex.Message + "]",
                    status,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            finally
            {
                // �ۑ����_�C�A���O�����
                msgForm.Close();

                // �ۑ��{�^�������ې���
                this.SetSaveButtonEnable(); // ADD 2009/02/03

                this._detailGrid.SetButtonEnable(); // ADD 2009/02/23

                // �J�[�\�������ɖ߂�
                this.Cursor = _localCursor;
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)//DEL 2011/08/03
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && noinputflag ==false )//ADD 2011/08/03
                {
                    // �ۑ��m�F�_�C�A���O��\������
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.Show(2); 
                }
            }

            return status;
        }

        /// <summary>
        /// �ۑ������O���͍��ڃ`�F�b�N
        /// </summary>
        /// <returns></returns>
        /// <remarks>���̓`�F�b�N�͌��݂̐ݒ�l�ł͂Ȃ��A�������̏����Ń`�F�b�N</remarks>
        private bool SaveBeforeExtractInfoCheck(out string errMsg, out Control errCtl)
        {
            bool status = true;
            errMsg = string.Empty;
            errCtl = null;

            if (this._detailGrid.BeforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && this._detailGrid.BeforeSearchExtractInfo.TargetDiv
                == ExtractInfo.TargetDivState.Stock)
            {
                if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.DataText))
                {
                    status = false;
                    errMsg = "�q�ɃR�[�h����͂��Ă�������";
                    errCtl = tEdit_WarehouseCode;
                }
                else if (string.IsNullOrEmpty(this.tEdit_SectionCode.DataText))
                {
                    status = false;
                    errMsg = "�Ǘ����_�R�[�h����͂��Ă�������";
                    errCtl = tEdit_SectionCode;
                }
            }

            if (status
                && string.IsNullOrEmpty(this.tEdit_EmployeeCode.DataText))
            {
                status = false;
                errMsg = "���͒S���R�[�h����͂��Ă�������";
                errCtl = tEdit_EmployeeCode;
            }

            return status;
        }

        // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
        /// <summary>
        /// �ő�o�͌����̐ݒ菈��
        /// </summary>
        private void SetUp()
        {
            _form = new PMZAI09201UC();
            _form.ShowDialog();
            _maxCount = _form.MaxCount;
        }
        // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<

        /// <summary>
        /// �O���b�h���ڃ`�F�b�N
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2013/05/11 yangyi</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 20150515�z�M���̑Ή�</br>
        /// <br>           : Redmine#35018 �u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���@���̂Q�Ή�</br>
        /// </remarks>
        private bool SaveBeforeGridCheck(out string errMsg)
        {
            errMsg = string.Empty;

            //--- ADD 2013/05/11 yangyi Redmine#35018��#53-No.7 ----->>>>>
            bool needCheck = true;
            int rowIndex = 0;
            int errRowIndex = 0;
            bool focusFlg = true;
            //--- ADD 2013/05/11 yangyi Redmine#35018��#53-No.7 -----<<<<<

            if (this._detailGrid.BeforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && this._detailGrid.BeforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                // �L�[���ڂ̓��͂������ꍇ�G���[
                foreach (UltraGridRow ultraRow in this._detailGrid.uGrid_Details.Rows)
                {
                    if (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].Value == null
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].Value == DBNull.Value
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == string.Empty)
                    {
                        errMsg = "�i�Ԃ���͂��Ă�������";

                        // �t�H�[�J�X
                        ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].Activate();
                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        
                        return false;
                    }
                    else if (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value == null
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value == DBNull.Value
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value.ToString() == string.Empty)
                    {
                        errMsg = "�i������͂��Ă�������";

                        // �t�H�[�J�X
                        ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Activate();
                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }
                    else if (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName].Value == null
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName].Value == DBNull.Value
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName].Value.ToString() == string.Empty
                        || (int)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName].Value == 0)
                    {
                        errMsg = "���[�J�[�R�[�h����͂��Ă�������";

                        // �t�H�[�J�X
                        ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName].Activate();
                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }
                    // --- ADD 2010/06/08 ---------->>>>>
                    else if (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate1Column.ColumnName].Value == null
                      || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate1Column.ColumnName].Value == DBNull.Value
                      || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate1Column.ColumnName].Value.ToString() == string.Empty)
                    {
                        errMsg = "���i�J�n���P����͂��Ă�������";

                        // �t�H�[�J�X
                        ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate1Column.ColumnName].Activate();
                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }
                    // --- ADD 2010/06/08 ----------<<<<<
                }
            }
            else if (this._detailGrid.BeforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && this._detailGrid.BeforeSearchExtractInfo.TargetDiv != ExtractInfo.TargetDivState.Stock)
            {
                // ���i�J�n��������Ȃ��ꍇ�G���[
                foreach (UltraGridRow ultraRow in this._detailGrid.uGrid_Details.Rows)
                {
                    UltraGridRow nextRow = null;
                    if (rowIndex < this._detailGrid.uGrid_Details.Rows.Count - 1)
                    {
                        nextRow = (UltraGridRow)this._detailGrid.uGrid_Details.Rows[rowIndex + 1];
                    }
                    rowIndex++;
                    // ���_���폜�s�A�_���폜�\��s�͑ΏۊO
                    if (
                        (int)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value != 0
                        ||
                        //(ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value != null
                        //&& ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value != DBNull.Value) // DEL 2009/02/05
                        (int)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value != 0 // ADD 2009/02/05
                        )
                    {
                        // �X�V�s�ł͂Ȃ��̂Ń`�F�b�N�s�v
                        continue;
                    }

                    // ���i�ύX�L���t���O
                    bool isChangedRow = false;

                    // �V�K�s�̓`�F�b�N�Ώ�
                    //if (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() == "�V�K") // DEL 2009/03/06
                    if (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.RowIndexColumn.ColumnName].Value.ToString() == "�V�K") // ADD 2009/03/06
                    {
                        isChangedRow = true;
                    }
                    else
                    {
                        // �X�V�s�ƍX�V�O�s���r
                        // --- DEL 2009/03/06 -------------------------------->>>>>
                        //DataRow originalDr = this._goodsStockAcs.OriginalGoodsStockDataTable
                        //    .Select(this._goodsStockAcs.GoodsStockDataTable.RowNumberColumn.ColumnName + " = '"
                        //    + ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() + "'")[0];

                        //DataRow updateDr = this._goodsStockAcs.GoodsStockDataTable
                        //.Select(this._goodsStockAcs.GoodsStockDataTable.RowNumberColumn.ColumnName + " = '"
                        //    + ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() + "'")[0];
                        // --- DEL 2009/03/06 --------------------------------<<<<<
                        // --- ADD 2009/03/06 -------------------------------->>>>>
                        DataRow originalDr = this._goodsStockAcs.OriginalGoodsStockDataTable
                            .Select(this._goodsStockAcs.GoodsStockDataTable.RowIndexColumn.ColumnName + " = '"
                            + ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.RowIndexColumn.ColumnName].Value.ToString() + "'")[0];

                        DataRow updateDr = this._goodsStockAcs.GoodsStockDataTable
                        .Select(this._goodsStockAcs.GoodsStockDataTable.RowIndexColumn.ColumnName + " = '"
                            + ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.RowIndexColumn.ColumnName].Value.ToString() + "'")[0];
                        // --- ADD 2009/03/06 --------------------------------<<<<<
                        //int stockColIndex = this._detailGrid.uGrid_Details.DisplayLayout.Bands[0]
                        //    .Columns[this._goodsStockAcs.GoodsStockDataTable.WarehouseCodeColumn.ColumnName].Index;  //DELETE BY ������ on 2011/10/31 for Redmine#26317
                        //-------------ADD BY ������ on 2011/10/31 for Redmine#26317 ----------------->>>>>>>>>>>>>>
                        int stockColIndex = this._detailGrid.uGrid_Details.DisplayLayout.Bands[0]
                            .Columns[this._goodsStockAcs.GoodsStockDataTable.StockUnitPriceFlColumn.ColumnName].Index + 1; 
                        int WarehouseCodeIndex = this._detailGrid.uGrid_Details.DisplayLayout.Bands[0]
                            .Columns[this._goodsStockAcs.GoodsStockDataTable.WarehouseCodeColumn.ColumnName].Index;
                        //-------------ADD BY ������ on 2011/10/31 for Redmine#26317 -----------------<<<<<<<<<<<<<<
                        for (int i = 0; i < stockColIndex; i++)
                        {
                            // �݌ɍ폜���͏���
                            //-------------DEL BY ������ on 2011/10/31 for Redmine#26317 ----------------->>>>>>>>>>>
                            //if (i != this._detailGrid.uGrid_Details.DisplayLayout.Bands[0]
                            //.Columns[this._goodsStockAcs.GoodsStockDataTable.StockDeleteDateColumn.ColumnName].Index)
                            //{
                            //    if (originalDr[i].ToString() != updateDr[i].ToString())
                            //    {
                            //        isChangedRow = true;
                            //        break;
                            //    }
                            //}
                            //-------------DEL BY ������ on 2011/10/31 for Redmine#26317 -----------------<<<<<<<<<<<<

                            //-------------ADD BY ������ on 2011/10/31 for Redmine#26317 ----------------->>>>>>>>>>>>>>
                            if (i != this._detailGrid.uGrid_Details.DisplayLayout.Bands[0]
                            .Columns[this._goodsStockAcs.GoodsStockDataTable.StockDeleteDateColumn.ColumnName].Index)
                            {                              
                                if (i < WarehouseCodeIndex)
                                {
                                    if (originalDr[i].ToString() != updateDr[i].ToString())
                                    {
                                        isChangedRow = false;
                                        continue;
                                    }
                                }                                
                                else if (originalDr[i].ToString() != updateDr[i].ToString())
                                {
                                    isChangedRow = true;
                                    break;
                                }
                            }
                            //-------------ADD BY ������ on 2011/10/31 for Redmine#26317 -----------------<<<<<<<<<<<<<<<<
                        }

                    }

                    if (
                        isChangedRow
                        &&
                        (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate1Column.ColumnName].Value == null
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate1Column.ColumnName].Value == DBNull.Value)
                        &&
                        (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate2Column.ColumnName].Value == null
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate2Column.ColumnName].Value == DBNull.Value)
                        &&
                        (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate3Column.ColumnName].Value == null
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate3Column.ColumnName].Value == DBNull.Value)
                       )
                    {
                        errMsg = "���i�J�n���Ɉ�ȏ���͂��Ă�������";

                        // �t�H�[�J�X
                        ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate1Column.ColumnName].Activate();
                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }

                    // --- ADD 2009/03/03 -------------------------------->>>>>
                    // ���i-�݌ɂ̏ꍇ�A�V�K�݌ɂ̃`�F�b�N
                    if (isChangedRow) //ADD BY ������ on 2011.10.31 for Redmine#26317
                    {
                        if (this._detailGrid.BeforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock
                            || this._detailGrid.BeforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods)
                        {
                            if (
                                // --- DEL 2009/03/05 -------------------------------->>>>>
                                //(ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value == null
                                //||
                                //ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value == DBNull.Value
                                //)
                                //&&
                                // --- DEL 2009/03/05 -------------------------------->>>>>
                                (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.WarehouseCodeColumn.ColumnName].Value == null
                                ||
                                ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.WarehouseCodeColumn.ColumnName].Value == DBNull.Value)
                                )
                            {
                                // �q�ɃR�[�h�̓��͂Ȃ������̍݌ɍ��ڂɓ��͂���̏ꍇ�G���[
                                if (
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.WarehouseShelfNoColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.WarehouseShelfNoColumn.ColumnName].Value != DBNull.Value)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.DuplicationShelfNo1Column.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.DuplicationShelfNo1Column.ColumnName].Value != DBNull.Value)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.DuplicationShelfNo2Column.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.DuplicationShelfNo2Column.ColumnName].Value != DBNull.Value)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PartsManagementDivide1Column.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PartsManagementDivide1Column.ColumnName].Value != DBNull.Value)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PartsManagementDivide2Column.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PartsManagementDivide2Column.ColumnName].Value != DBNull.Value)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockSupplierCodeColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockSupplierCodeColumn.ColumnName].Value != DBNull.Value
                                    && (int)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockSupplierCodeColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockDivColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockDivColumn.ColumnName].Value != DBNull.Value
                                    && (int)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockDivColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.SalesOrderUnitColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.SalesOrderUnitColumn.ColumnName].Value != DBNull.Value
                                    && (int)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.SalesOrderUnitColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MinimumStockCntColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MinimumStockCntColumn.ColumnName].Value != DBNull.Value
                                    && (double)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MinimumStockCntColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MaximumStockCntColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MaximumStockCntColumn.ColumnName].Value != DBNull.Value
                                    && (double)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MaximumStockCntColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.SupplierStockColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.SupplierStockColumn.ColumnName].Value != DBNull.Value
                                    && (double)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.SupplierStockColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.ArrivalCntColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.ArrivalCntColumn.ColumnName].Value != DBNull.Value
                                    && (double)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.ArrivalCntColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.ShipmentCntColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.ShipmentCntColumn.ColumnName].Value != DBNull.Value
                                    && (double)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.ShipmentCntColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.AcpOdrCountColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.AcpOdrCountColumn.ColumnName].Value != DBNull.Value
                                    && (double)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.AcpOdrCountColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MovingSupliStockColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MovingSupliStockColumn.ColumnName].Value != DBNull.Value
                                    && (double)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MovingSupliStockColumn.ColumnName].Value != 0)
                                    // --- ADD 2009/03/05 -------------------------------->>>>>
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockUnitPriceFlColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockUnitPriceFlColumn.ColumnName].Value != DBNull.Value
                                    && (double)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockUnitPriceFlColumn.ColumnName].Value != 0)
                                    // --- ADD 2009/03/05 --------------------------------<<<<<
                                    )
                                {
                                    errMsg = "�q�ɃR�[�h����͂��Ă�������";

                                    // �t�H�[�J�X
                                    ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.WarehouseCodeColumn.ColumnName].Activate();
                                    this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                                    return false;
                                }

                            }
                        }
                    } //ADD BY ������ on 2011.10.31
                    // --- ADD 2009/03/03 --------------------------------<<<<<
                    //--- ADD 2013/05/11 yangyi Redmine#35018��#53-No.7 ----->>>>>
                    if (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == _detailGrid.GridGoodsNo
                             && (int)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName].Value == _detailGrid.GridGoodsMakerCd)
                    {
                        // ���ꏤ�i�͂������q�ɂ�����A���A�t�H�[�J�X�͕i���Z���ł���ꍇ�A��s�ŕi���͋󔒂����Ȃ���΁A�i���̃`�F�b�N���s��Ȃ�
                        if (focusFlg)
                        {
                            errRowIndex = ultraRow.Index;
                            focusFlg = false;
                        }
                        if (!needCheck)
                        {
                            continue;
                        }

                        if (!(ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value == null
                            || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value == DBNull.Value
                            || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value.ToString() == string.Empty))
                        {
                            needCheck = false;
                            continue;
                        }
                        if (nextRow == null ||
                            !(ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == nextRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() &&
                            (int)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName].Value == (int)nextRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName].Value))
                        {
                            errMsg = "�i������͂��Ă�������";

                            // �t�H�[�J�X
                            ((UltraGridRow)this._detailGrid.uGrid_Details.Rows[errRowIndex]).Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Activate();
                            this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                            return false;
                        }
                    }
                    else
                    {
                    //--- ADD 2013/05/11 yangyi Redmine#35018��#53-No.7 -----<<<<<
                        // --- ADD 2010/06/08 ---------->>>>>
                        if (
                            //--- DEL 2013/05/11 yangyi Redmine#35018��#53-No.7 ----->>>>>
                            //isChangedRow
                            //&&
                            //--- DEL 2013/05/11 yangyi Redmine#35018��#53-No.7 -----<<<<<
                            (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value == null
                            || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value == DBNull.Value
                            || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value.ToString() == string.Empty))
                        {

                            errMsg = "�i������͂��Ă�������";

                            // �t�H�[�J�X
                            ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Activate();
                            this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                            return false;
                        }
                    } // ADD 2013/05/11 yangyi Redmine#35018��#53-No.7
                    // --- ADD 2010/06/08 ----------<<<<<
                }
            }

            return true;
        }

        /// <summary>
        /// �L�[�d���`�F�b�N
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="errCtl"></param>
        /// <returns></returns>
        private bool SaveBeforeDuplicationCheck(out string errMsg)
        {
            errMsg = string.Empty;

            // ���i�A�݌ɒǉ�������ꍇ�̂݃`�F�b�N���K�v
            if (this._detailGrid.BeforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && this._detailGrid.BeforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                // �V�K�ǉ��s���擾
                //DataRow[] drList = this._goodsStockAcs.GoodsStockDataTable.Select(
                //    this._goodsStockAcs.GoodsStockDataTable.RowNumberColumn.ColumnName + " = '�V�K'"); // DEL 2009/03/06
                DataRow[] drList = this._goodsStockAcs.GoodsStockDataTable.Select(
                    this._goodsStockAcs.GoodsStockDataTable.RowIndexColumn.ColumnName + " = '�V�K'"); // ADD 2009/03/06

                foreach (DataRow dr in drList)
                {
                    int sameKeyNum = 0;

                    string goodsNo = dr[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].ToString();
                    int makerCd = (int)dr[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName];

                    foreach (DataRow checkDr in drList)
                    {
                        if (goodsNo == checkDr[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].ToString()
                            && makerCd == (int)checkDr[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName])
                        {
                            sameKeyNum++;
                        }
                    }

                    if (sameKeyNum > 1)
                    {
                        errMsg = "���i�ǉ������s�ŃL�[���d�����Ă��܂��B"�@+"\r\n" + "\r\n" +
									"�y�i���F" + goodsNo + " " + "���[�J�[���F" + makerCd.ToString() + "�z";

                        // �L�[�d������
                        return false;
                    }
                }

                return true;
            }
            else if (this._detailGrid.BeforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {
                // �V�K�ǉ��s���擾
                //DataRow[] drList = this._goodsStockAcs.GoodsStockDataTable.Select(
                //    this._goodsStockAcs.GoodsStockDataTable.RowNumberColumn.ColumnName + " = '�V�K'");
                DataRow[] drList = this._goodsStockAcs.GoodsStockDataTable.Select(
                    this._goodsStockAcs.GoodsStockDataTable.RowIndexColumn.ColumnName + " = '�V�K'"); // ADD 2009/03/06

                foreach (DataRow dr in drList)
                {
                    int sameKeyNum = 0;

                    string goodsNo = dr[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].ToString();
                    int makerCd = (int)dr[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName];
                    string warehouseCd = dr[this._goodsStockAcs.GoodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString();

                    foreach (DataRow checkDr in drList)
                    {
                        if (goodsNo == checkDr[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].ToString()
                            && makerCd == (int)checkDr[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName]
                            && warehouseCd == checkDr[this._goodsStockAcs.GoodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString())
                        {
                            sameKeyNum++;
                        }
                    }

                    if (sameKeyNum > 1)
                    {
                        errMsg = "�݌ɒǉ������s�ŃL�[���d�����Ă��܂��B" + "\r\n" + "\r\n" +
                                    "�y�i�ԁF" + goodsNo + " " + "���[�J�[�R�[�h�F" + makerCd.ToString() + "�q�ɃR�[�h�F" + warehouseCd.TrimEnd().PadLeft(4, '0') + "�z";

                        // �L�[�d������
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// �Ǘ����_�Ⴂ���R�[�h�̑��݃`�F�b�N
        /// </summary>
        /// <returns></returns>
        private bool AddupSectionCheck()
        {
            DataRow[] drList = this._goodsStockAcs.GoodsStockDataTable.Select(
                    this._goodsStockAcs.GoodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName + " <> '' AND "
                    + this._goodsStockAcs.GoodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName + " = 0");

            if (drList.Length > 0) return true;
            else return false;
        }

        # endregion �� �ۑ����� ��

        # region �� ���������� ��
        /// <summary>
		/// ��ʏ���������
		/// </summary>
		/// <param name="isConfirm">true:�m�F�_�C�A���O��\������ false:�\�����Ȃ�</param>
		/// <returns>true:���������s false:�����������s</returns>
        private void Clear()
        {
            // �ύX�L���`�F�b�N
            bool isChanged = this.CompareGridDataWithOriginal();

            if (isChanged)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
					"������Ԃɖ߂��܂����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            string errMsg;

            // ��ʏ�����
            int status = this.InitializeScreen(out errMsg);

            // �O���b�h���̏�����
            this._detailGrid.Initialize();

            // �ۑ��{�^�������ېݒ�
            this.SetSaveButtonEnable(); // ADD 2009/02/03

            // �t�H�[�J�X�ݒ�
            this.tComboEditor_DisplayDiv.Focus();
            ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11

        }
        # endregion �� ���������� ��

        #region �� ���̑����� ��

        /// <summary>
        /// ���׃O���b�h�ύX�L���`�F�b�N
        /// </summary>
        private bool CompareGridDataWithOriginal()
        {
            if (this._goodsStockAcs.GoodsStockDataTable.Rows.Count 
                != this._goodsStockAcs.OriginalGoodsStockDataTable.Rows.Count)
            {
                // �s�����ς���Ă��邩
                return true;
            }

            // �l���ύX���ꂽ�Z�������邩
            for (int rowIndex = 0; rowIndex < this._goodsStockAcs.GoodsStockDataTable.Rows.Count; rowIndex++)
            {
                for (int colIndex = 0; colIndex < this._goodsStockAcs.GoodsStockDataTable.Columns.Count; colIndex++)
                {
                    // �I���]�����͍X�V���Ȃ��̂ŏ���
                    if (this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].Columns[colIndex].Key
                        != this._goodsStockAcs.GoodsStockDataTable.StockUnitPriceRateColumn.ColumnName) // ADD 2009/03/05
                    {
                        if (this._goodsStockAcs.GoodsStockDataTable.Rows[rowIndex][colIndex].ToString()
                            != this._goodsStockAcs.OriginalGoodsStockDataTable.Rows[rowIndex][colIndex].ToString())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// ���ׂ���̃w�b�_���擾�C�x���g
        /// </summary>
        /// <returns></returns>
        private ExtractInfo DetailGrid_GetExtractInfo()
        {
            return GetExtractInfo();
        }

        /// <summary>
        /// ���ׂ���̃t�H�[�J�X�ݒ�C�x���g
        /// </summary>
        /// <param name="ctrlKey">�R���g���[����</param>
        /// <returns></returns>
        private void DetailGrid_SetFocus(string ctrlKey)
        {
            switch (ctrlKey)
            {
                case "tComboEditor_DisplayDiv":
                    {
                        this.tComboEditor_DisplayDiv.Focus();
                        ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
                        break;
                    }
                case "tComboEditor_TargetDiv":
                    {
                        this.tComboEditor_TargetDiv.Focus();
                        ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
                        break;
                    }
                case "tComboEditor_OutputDiv":
                    {
                        this.tComboEditor_OutputDiv.Focus();
                        ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
                        break;
                    }
                case "tEdit_GoodsNo":
                    {
                        this.tEdit_GoodsNo.Focus();
                        ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
                        break;
                    }
                case "tEdit_EmployeeCode":
                    {
                        this.tEdit_EmployeeCode.Focus();
                        ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = true; // ADD 2010/08/11
                        break;
                    }
                case "uButton_EmployeeCdGuide":
                    {
                        this.uButton_EmployeeCdGuide.Focus();
                        ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
                        break;
                    }
                case "Before_Grid":
                    {
                        // --- ADD 2009/03/06 -------------------------------->>>>>
                        // �O���b�h�̑O�̃R���g���[���Ƀt�H�[�J�X
                        // �Ώۋ敪�ɂ��قȂ�
                        if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                            == ExtractInfo.TargetDivState.Goods
                            || (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                            == ExtractInfo.TargetDivState.GoodsStock)
                        {
                            this.uButton_BLGoodsCdGuide.Focus();
                            ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
                        }
                        else
                        {
                            this.uButton_SectionCdGuide.Focus();
                            ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
                        }

                        break;
                        // --- ADD 2009/03/06 --------------------------------<<<<<
                    }
            }
        }

        /// <summary>
        /// �ۑ��{�^���̉����ۂ�ݒ肷��
        /// </summary>
        private void SetSaveButtonEnable()
        {
            if (this._goodsStockAcs.GoodsStockDataTable.Rows.Count == 0)
            {
                this.tToolbarsManager1.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
            }
            else
            {
                this.tToolbarsManager1.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
            }
        }

        // --- ADD 2010/08/11 ---------->>>>>
        /// <summary>
        /// �K�C�h�{�^���̃Z�b�g
        /// </summary>
        /// <param name="enabled"></param>
        private void SetGuideEnabled(bool enabled)
        {
            ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = enabled;
        }
        // --- ADD 2010/08/11 ----------<<<<<

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                "PMZAI09200UA",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "���i�݌Ɉꊇ�o�^�C��",				// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }

        #endregion

        #endregion

        #region ���R���g���[���C�x���g

        #region �� Load,Close�C�x���g
        /// <summary>
        /// PMZAI09201UA_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI09201UA_Load(object sender, EventArgs e)
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

            // ���ו�
            this.Panel_Detail.Controls.Add(this._detailGrid);
            this._detailGrid.Dock = DockStyle.Fill;
            //-------ADD BY ������ on 2012/09/19 for Redmine#32370------>>>>>>
            // XML�f�[�^�Ǎ�
            this._detailGrid.LoadStateXmlData();
            //-------ADD BY ������ on 2012/09/19 for Redmine#32370------<<<<<<
            // �t�H�[�J�X�ݒ�^�C�}�[
            this.InitialFocusTimer.Enabled = true;

            // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
            _form = new PMZAI09201UC();
            _maxCount = _form.MaxCount;

            if (_maxCount == 0)
            {
                _maxCount = 2000; //�ő�o�͌����̋K��l�F2000
            }
            // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<

        }

        ///// <summary>
        ///// PMZAI09201UA_FormClosing
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void PMZAI09201UA_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (!this._closeProcFinish)
        //    {
        //        this.CloseWindow();
        //    }
        //}
        #endregion

        #region �� ChangeFocus�C�x���g
        /// <summary>
        /// tRetKeyControl1_ChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (!this._initializeFinish)
            {
                // ��ʏ��������͏������Ȃ�
                return;
            }

            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // �\���敪
                case "tComboEditor_DisplayDiv":
                    {
                            if ((e.Key == Keys.Tab && e.ShiftKey) 
                                || e.Key == Keys.Left)
                            {
                                e.NextCtrl = this._detailGrid.uGrid_Details;
                            }
                            this.setTComboEditorByName(e.PrevCtrl.Name); // ADD 2010/08/11
                        break;
                    }
                // �Ώۋ敪
                case "tComboEditor_TargetDiv":
                    {
                        this.setTComboEditorByName(e.PrevCtrl.Name); // ADD 2010/08/11

                        break;
                    }
                // --- ADD 2010/08/11 ---------->>>>>
                // �o�͎w��
                case "tComboEditor_OutputDiv":
                    {
                        this.setTComboEditorByName(e.PrevCtrl.Name);

                        break;
                    }
                // --- ADD 2010/08/11 ----------<<<<<
                // ���[�J�[�R�[�h
                case "tNedit_GoodsMakerCd":
                    {
                        #region ���[�J�[�R�[�h
                        // ���͖���
                        if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpGoodsMakerCd = 0;
                            this.uLabel_GoodsMakerName.Text = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_GoodsMakerCd.GetInt() == this._tmpGoodsMakerCd)
                        {
                            if (e.NextCtrl == this.uButton_GoodsMakerCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                if ((ExtractInfo.DisplayDivState)this.tComboEditor_DisplayDiv.SelectedItem.DataValue == ExtractInfo.DisplayDivState.New
                                    && (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.Goods)
                                {
                                    // �V�K�A���i
                                    e.NextCtrl = this.tEdit_GoodsNo;
                                }
                                else if ((ExtractInfo.DisplayDivState)this.tComboEditor_DisplayDiv.SelectedItem.DataValue == ExtractInfo.DisplayDivState.Update
                                    &&
                                    ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.Goods
                                    || (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.GoodsStock)
                                    )
                                {
                                    // �C���o�^�A�Ώۋ敪�u���i�v�u���i-�݌Ɂv
                                    e.NextCtrl = this.tNedit_GoodsMGroup;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_WarehouseCode;
                                }
                            }

                            break;
                        }

                        // ���͒l�`�F�b�N
                        MakerUMnt makerUMnt;

                        int status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt());

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || makerUMnt == null || (makerUMnt != null && makerUMnt.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                            this.uLabel_GoodsMakerName.Text = makerUMnt.MakerName;

                            // �ݒ�l��ۑ�
                            this._tmpGoodsMakerCd = makerUMnt.GoodsMakerCd;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tNedit_GoodsMakerCd.SetInt(this._tmpGoodsMakerCd);

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����Ń��[�J�[�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_GoodsMakerCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                            if ((ExtractInfo.DisplayDivState)this.tComboEditor_DisplayDiv.SelectedItem.DataValue == ExtractInfo.DisplayDivState.New
                                && (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.Goods)
                            {
                                // �V�K�A���i
                                e.NextCtrl = this.tEdit_GoodsNo;
                            }
                            else if ((ExtractInfo.DisplayDivState)this.tComboEditor_DisplayDiv.SelectedItem.DataValue == ExtractInfo.DisplayDivState.Update
                                &&
                                ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.Goods
                                || (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.GoodsStock)
                                )
                            {
                                // �C���o�^�A�Ώۋ敪�u���i�v�u���i-�݌Ɂv
                                e.NextCtrl = this.tNedit_GoodsMGroup;
                            }
                            else
                            {
                                e.NextCtrl = this.tEdit_WarehouseCode;
                            }


                        }

                        break;
                        #endregion
                    }
                // ���i������
                case "tNedit_GoodsMGroup":
                    {
                        #region ���i������
                        // ���͖���
                        if (this.tNedit_GoodsMGroup.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpGoodsMGroup = 0;
                            this.uLabel_GoodsMGroupName.Text = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_GoodsMGroup.GetInt() == this._tmpGoodsMGroup)
                        {
                            if (e.NextCtrl == this.uButton_GoodsMGroupGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                e.NextCtrl = this.tEdit_GoodsNo;
                            }

                            break;
                        }

                        // ���͒l�`�F�b�N
                        GoodsGroupU goodsGroupU;

                        int status = this._goodsGroupUAcs.Search(out goodsGroupU, this._enterpriseCode, this.tNedit_GoodsMGroup.GetInt());

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || goodsGroupU == null || (goodsGroupU != null && goodsGroupU.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
                            this.uLabel_GoodsMGroupName.Text = goodsGroupU.GoodsMGroupName;

                            // �ݒ�l��ۑ�
                            this._tmpGoodsMGroup = goodsGroupU.GoodsMGroup;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tNedit_GoodsMGroup.SetInt(this._tmpGoodsMGroup);

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����ŏ��i�����ރR�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_GoodsMGroupGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                            e.NextCtrl = this.tEdit_GoodsNo;
                        }

                        break;
                        #endregion
                    }
                // �q��
                case "tEdit_WarehouseCode":
                    {
                        #region �q�ɃR�[�h
                        // ���͖���
                        if (this.tEdit_WarehouseCode.DataText == string.Empty)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpWareHouseCode = string.Empty;
                            this.uLabel_WareHouseName.Text = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tEdit_WarehouseCode.DataText == this._tmpWareHouseCode)
                        {
                            if (e.NextCtrl == this.uButton_WarehouseCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                e.NextCtrl = this.tEdit_GoodsNo;
                            }

                            break;
                        }

                        // ���͒l�`�F�b�N
                        Warehouse warehouse;

                        int status = this._warehouseAcs.Read(out warehouse, this._enterpriseCode, this._sectionCode, this.tEdit_WarehouseCode.DataText);

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || warehouse == null || (warehouse != null && warehouse.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tEdit_WarehouseCode.Text = warehouse.WarehouseCode.TrimEnd(); // ADD 2009/02/12
                            this.uLabel_WareHouseName.Text = warehouse.WarehouseName;

                            // �ݒ�l��ۑ�
                            this._tmpWareHouseCode = warehouse.WarehouseCode.TrimEnd();
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tEdit_WarehouseCode.DataText = this._tmpWareHouseCode.TrimEnd();

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����őq�ɃR�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_BLGoodsCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                            e.NextCtrl = this.tEdit_GoodsNo;
                        }

                        break;
                        #endregion
                    }
                // BL�R�[�h
                case "tNedit_BLGoodsCode":
                    {
                        #region BL�R�[�h
                        // ���͖���
                        if (this.tNedit_BLGoodsCode.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpBLGoodsCode = 0;
                            this.uLabel_BLGoodsCodeName.Text = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_BLGoodsCode.GetInt() == this._tmpBLGoodsCode)
                        {
                            if (e.NextCtrl == this.uButton_BLGoodsCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                //e.NextCtrl = this.tEdit_EmployeeCode; // DEL 2009/03/06
                                e.NextCtrl = this._detailGrid.uGrid_Details; // ADD 2009/03/06
                            }

                            //--- ADD 2010/09/07 ---------->>>>>
                            if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                            //--- ADD 2010/09/07 ----------<<<<<

                            break;
                        }

                        // ���͒l�`�F�b�N
                        BLGoodsCdUMnt blGoodsCdUMnt;

                        int status = this._blGoodsCdAcs.Read(out blGoodsCdUMnt, this._enterpriseCode, this.tNedit_BLGoodsCode.GetInt());

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || blGoodsCdUMnt == null || (blGoodsCdUMnt != null && blGoodsCdUMnt.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
                            this.uLabel_BLGoodsCodeName.Text = blGoodsCdUMnt.BLGoodsHalfName;

                            // �ݒ�l��ۑ�
                            this._tmpBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;

                            //--- ADD 2010/09/07 ---------->>>>>
                            if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                            //--- ADD 2010/09/07 ----------<<<<<
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tNedit_BLGoodsCode.SetInt(this._tmpBLGoodsCode);

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ������BL�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_BLGoodsCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                            //e.NextCtrl = this.tEdit_EmployeeCode; // DEL 2009/03/06
                            e.NextCtrl = this._detailGrid.uGrid_Details; // ADD 2009/03/06
                        }

                        break;
                        #endregion
                    }
                // �Ǘ����_
                case "tEdit_SectionCode":
                    {
                        #region �Ǘ����_�R�[�h
                        // ���͖���
                        if (this.tEdit_SectionCode.DataText == string.Empty)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpSectionCode = string.Empty;
                            this.uLabel_SectionName.Text = string.Empty;


                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tEdit_SectionCode.DataText == this._tmpSectionCode)
                        {
                            if (e.NextCtrl == this.uButton_SectionCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                //e.NextCtrl = this.tEdit_EmployeeCode; // DEL 2009/03/06
                                e.NextCtrl = this._detailGrid.uGrid_Details; // ADD 2009/03/06
                            }

                            //--- ADD 2010/09/07 ---------->>>>>
                            if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                            //--- ADD 2010/09/07 ----------<<<<<
                            break;
                        }

                        // ���͒l�`�F�b�N
                        SecInfoSet secInfoSet;

                        int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this.tEdit_SectionCode.DataText);

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || secInfoSet == null || (secInfoSet != null && secInfoSet.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tEdit_SectionCode.Text = secInfoSet.SectionCode.TrimEnd(); // ADD 2009/02/12
                            this.uLabel_SectionName.Text = secInfoSet.SectionGuideSnm;

                            // �ݒ�l��ۑ�
                            this._tmpSectionCode = secInfoSet.SectionCode.TrimEnd();

                            //--- ADD 2010/09/07 ---------->>>>>
                            if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                            //--- ADD 2010/09/07 ----------<<<<<
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tEdit_SectionCode.DataText = this._tmpSectionCode.TrimEnd();

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����ŊǗ����_�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_SectionCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                            //e.NextCtrl = this.tEdit_EmployeeCode; // DEL 2009/03/06
                            e.NextCtrl = this._detailGrid.uGrid_Details; // ADD 2009/03/06
                        }

                        break;
                        #endregion
                    }
                //--- ADD 2010/09/07 ---------->>>>>
                // BL�R�[�h�K�C�h
                case "uButton_BLGoodsCdGuide":
                // �Ǘ����_�K�C�h
                case "uButton_SectionCdGuide":
                    {
                        if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                        {
                            this.Search();
                            e.NextCtrl = null;
                        }
                        break;
                    }
                //--- ADD 2010/09/07 ----------<<<<<
                // ���͒S��
                case "tEdit_EmployeeCode":
                    {
                        #region ���͒S���R�[�h
                        // ���͖���
                            if (this.tEdit_EmployeeCode.DataText == string.Empty)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._tmpEmployeeCode = string.Empty;
                            this.uLabel_EmployeeName.Text = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tEdit_EmployeeCode.DataText == this._tmpEmployeeCode.TrimEnd())
                        {
                            if (e.NextCtrl == this.uButton_EmployeeCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                //e.NextCtrl = this._detailGrid.uGrid_Details; // DEL 2009/03/06
                                e.NextCtrl = this.tNedit_GoodsMakerCd; // ADD 2009/03/06
                            }

                            break;
                        }

                        // ���͒l�`�F�b�N
                        Employee employee;

                        int status = this._employeeAcs.Read(out employee, this._enterpriseCode, this.tEdit_EmployeeCode.DataText);

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || employee == null || (employee != null && employee.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tEdit_EmployeeCode.Text = employee.EmployeeCode.TrimEnd();
                            this.uLabel_EmployeeName.Text = employee.Name;

                            // �ݒ�l��ۑ�
                            this._tmpEmployeeCode = employee.EmployeeCode.TrimEnd();
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tEdit_EmployeeCode.DataText = this._tmpEmployeeCode.TrimEnd();

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����œ��͒S���R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_EmployeeCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                            //e.NextCtrl = this._detailGrid.uGrid_Details; // DEL 2009/03/06
                            e.NextCtrl = this.tNedit_GoodsMakerCd; // ADD 2009/03/06
                        }

                        break;
                        #endregion
                    }
                    // �O���b�h
                case "uGrid_Details":
                    {
                        if (this._detailGrid.uGrid_Details.Rows.Count == 0)
                        {
                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                // �O���b�h�^�u�ړ�����
                                this._detailGrid.SetGridTabFocus(ref e);
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (e.NextCtrl.Name == "PMZAI09201UB")
                                {
                                    //e.NextCtrl = this.tEdit_EmployeeCode; // DEL 2009/03/06
                                    // --- ADD 2009/03/06 -------------------------------->>>>>
                                    if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                                        == ExtractInfo.TargetDivState.Goods
                                        || (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                                        == ExtractInfo.TargetDivState.GoodsStock
                                        )
                                    {
                                        e.NextCtrl = this.uButton_BLGoodsCdGuide; 
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uButton_SectionCdGuide; 
                                    }
                                    // --- ADD 2009/03/06 --------------------------------<<<<<
                                }
                                // �O���b�h�V�t�g�^�u�ړ�����
                                this._detailGrid.SetGridShiftTabFocus(ref e);
                            }
                        }

                        break;
                    }
            }

            // --- ADD 2010/08/11----------------------------------->>>>>
            if (e.NextCtrl is TComboEditor)
            {
                this._preComboEditorValue = ((TComboEditor)e.NextCtrl).Value;
            }
            // --- ADD 2010/08/11-----------------------------------<<<<<

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                case "PMZAI09201UB":
                case "uGrid_Details":
                    {
                        if (this._detailGrid.uGrid_Details.Rows.Count == 0)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = this.tComboEditor_DisplayDiv;
                                }
                                else if (e.Key == Keys.Up)
                                {
                                    e.NextCtrl = this.tEdit_GoodsNo;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    //e.NextCtrl = this.tEdit_EmployeeCode; // DEL 2009/03/06
                                    // --- ADD 2009/03/06 -------------------------------->>>>>
                                    if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                                        == ExtractInfo.TargetDivState.Goods
                                        || (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                                        == ExtractInfo.TargetDivState.GoodsStock
                                        )
                                    {
                                        e.NextCtrl = this.uButton_BLGoodsCdGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uButton_SectionCdGuide;
                                    }
                                    // --- ADD 2009/03/06 --------------------------------<<<<<
                                }
                            }
                        }
                        else
                        {
                            string nextFocusColumn;

                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = null;
                                    this._detailGrid.uGrid_Details.Focus();
                                    ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11

                                    int activationColIndex;
                                    int activationRowIndex;

                                    nextFocusColumn = this._detailGrid.GetNextFocusColumnKey(0, 0, false, out activationColIndex, out activationRowIndex);

                                    if (nextFocusColumn != string.Empty)
                                    {
                                        this._detailGrid.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();

                                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tComboEditor_DisplayDiv;
                                    }
                                }
                                else if (e.Key == Keys.Up)
                                {
                                    // �ŏI�s�Ƀt�H�[�J�X
                                    e.NextCtrl = null;
                                    this._detailGrid.uGrid_Details.Focus();
                                    ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11

                                    int activationColIndex;
                                    int activationRowIndex;

                                    nextFocusColumn = this._detailGrid.GetNextFocusColumnKey(0, this._detailGrid.uGrid_Details.Rows.Count - 1, false, out activationColIndex, out activationRowIndex);

                                    if (nextFocusColumn != string.Empty)
                                    {
                                        this._detailGrid.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();

                                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_GoodsNo;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = null;
                                    this._detailGrid.uGrid_Details.Focus();
                                    ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11

                                    int activationColIndex;
                                    int activationRowIndex;

                                    nextFocusColumn = this._detailGrid.GetNextFocusColumnKey(this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1, this._detailGrid.uGrid_Details.Rows.Count - 1, true, out activationColIndex, out activationRowIndex);

                                    if (nextFocusColumn != string.Empty)
                                    {
                                        this._detailGrid.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();

                                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        //e.NextCtrl = this.tEdit_EmployeeCode; // DEL 2009/03/06
                                        // --- ADD 2009/03/06 -------------------------------->>>>>
                                        if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                                            == ExtractInfo.TargetDivState.Goods
                                            || (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                                            == ExtractInfo.TargetDivState.GoodsStock
                                            )
                                        {
                                            e.NextCtrl = this.uButton_BLGoodsCdGuide;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_SectionCdGuide;
                                        }
                                        // --- ADD 2009/03/06 --------------------------------<<<<<
                                    }
                                }
                            }
                        }

                        break;
                    }
            }

            //---ADD 2010/08/09---------->>>>>
            // �K�C�h�̐ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"];
            if (guideButton != null && e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tEdit_EmployeeCode":
                    case "tNedit_GoodsMakerCd":
                    case "tNedit_BLGoodsCode":
                    case "tEdit_WarehouseCode":
                    case "tEdit_SectionCode":
                    case "tNedit_GoodsMGroup":
                        {
                            guideButton.SharedProps.Enabled = true;
                            break;
                        }
                    case "uGrid_Details":
                        break;
                    default:
                        {
                            if (e.NextCtrl.CanFocus && e.NextCtrl.CanSelect)
                            {
                                guideButton.SharedProps.Enabled = false;
                            }
                            break;
                        }
                }
            }
            //---ADD 2010/08/09----------<<<<<
        }
        #endregion

        #region �� �c�[���o�[�N���b�N�C�x���g
        /// <summary>
        /// tToolbarsManager1_ToolClick�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        this.CloseWindow();
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // ����
                        this.Search();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // �ۑ�����
                        this.Save();
                        break;
                    }
                case "ButtonTool_New":
                    {
                        // �N���A����
                        this.Clear();
                        
                        break;
                    }
                // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                case "ButtonTool_SetUp":
                    {
                        // �ő�o�͌����̐ݒ菈��
                        this.SetUp();

                        break;
                    }
                // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
                // --- ADD 2010/09/11-------------------------------------->>>>>
                case "ButtonTool_Guide":
                    {
                        if (this._detailGrid.ContainsFocus)
                        {
                            // ���׃K�C�h����
                            this._detailGrid.ExecuteGuideMain();
                        } else {
                            // ���͒S��
                            if (tEdit_EmployeeCode.Focused)
                            {
                                uButton_EmployeeCdGuide_Click_1(sender, e);
                                this.tEdit_EmployeeCode.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_EmployeeCode.Name, this.tEdit_EmployeeCode.Text);
                            } else 
                            // ���[�J�[
                            if (tNedit_GoodsMakerCd.Focused)
                            {
                                uButton_GoodsMakerCdGuide_Click_1(sender, e);
                            } else
                            // �a�k�R�[�h
                            if (tNedit_BLGoodsCode.Focused)
                            {
                                uButton_BLGoodsCdGuide_Click_1(sender, e);
                            } else
                            // �q��
                            if (tEdit_WarehouseCode.Focused)
                            {
                                uButton_WarehouseCdGuide_Click_1(sender, e);
                                this.tEdit_WarehouseCode.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_WarehouseCode.Name, this.tEdit_WarehouseCode.Text);
                            } else
                            // �Ǘ����_
                            if (tEdit_SectionCode.Focused)
                            {
                                uButton_SectionCdGuide_Click_1(sender, e);
                                this.tEdit_SectionCode.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_SectionCode.Name, this.tEdit_SectionCode.Text);
                            } else
                            // ���i������
                            if (tNedit_GoodsMGroup.Focused)
                            {
                                uButton_GoodsMGroupGuide_Click_1(sender, e);
                            }
                        }
                        break;
                    }
                // --- ADD 2010/09/11--------------------------------------<<<<<
            }
        }
        #endregion

        #region �� �K�C�h�N���b�N�C�x���g
        /// <summary>
        /// ���[�J�[�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMakerCdGuide_Click_1(object sender, EventArgs e)
        {
            MakerUMnt makerUmnt;

            int status = this._detailGrid.ExecuteMakerGuide(out makerUmnt);

            if (status == 0)
            {
                this.tNedit_GoodsMakerCd.SetInt(makerUmnt.GoodsMakerCd);
                this.uLabel_GoodsMakerName.Text = makerUmnt.MakerName;

                // �t�H�[�J�X
                if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                    == ExtractInfo.TargetDivState.Goods
                    ||
                    (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                    == ExtractInfo.TargetDivState.GoodsStock)
                {
                    // ���i�����ނɃt�H�[�J�X
                    this.tNedit_GoodsMGroup.Focus();
                    ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = true; // ADD 2010/08/11
                }
            }
        }

        /// <summary>
        /// �q�ɃK�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_WarehouseCdGuide_Click_1(object sender, EventArgs e)
        {
            Warehouse warehouse;

            int status = this._detailGrid.ExecuteWarehouseGuide(out warehouse);

            if (status == 0)
            {
                this.tEdit_WarehouseCode.DataText = warehouse.WarehouseCode.Trim();
                this.uLabel_WareHouseName.Text = warehouse.WarehouseName;

                // �t�H�[�J�X
                this.tEdit_GoodsNo.Focus();
                ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
            }
        }

        /// <summary>
        /// BL�R�[�h�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_BLGoodsCdGuide_Click_1(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt;

            int status = this._detailGrid.ExecuteBLGoodsCodeGuide(out blGoodsCdUMnt);

            if (status == 0)
            {
                this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
                this.uLabel_BLGoodsCodeName.Text = blGoodsCdUMnt.BLGoodsHalfName;

                // �t�H�[�J�X
                this.tEdit_EmployeeCode.Focus();
                ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = true; // ADD 2010/08/11

                //---ADD 2010/09/07---------->>>>>
                this.Search();
                //---ADD 2010/09/07----------<<<<<
            }
        }

        /// <summary>
        /// ���i�����ރR�[�h�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMGroupGuide_Click_1(object sender, EventArgs e)
        {
            GoodsGroupU goodgroupU;

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);

            if (status == 0)
            {
                this.tNedit_GoodsMGroup.SetInt(goodgroupU.GoodsMGroup);
                this.uLabel_GoodsMGroupName.Text = goodgroupU.GoodsMGroupName;

                // �t�H�[�J�X
                this.tEdit_GoodsNo.Focus();
                ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
            }
        }

        /// <summary>
        /// �Ǘ����_�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SectionCdGuide_Click_1(object sender, EventArgs e)
        {
            SecInfoSet secInfoSet;

            int status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

            // ���ʔ��f
            if (status == 0)
            {
                this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;

                // �t�H�[�J�X
                this.tEdit_EmployeeCode.Focus();
                ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = true; // ADD 2010/08/11

                //---ADD 2010/09/07---------->>>>>
                this.Search();
                //---ADD 2010/09/07----------<<<<<
            }
        }

        /// <summary>
        /// �S���҃K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_EmployeeCdGuide_Click_1(object sender, EventArgs e)
        {
            Employee employee;

            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            // ���ʔ��f
            if (status == 0)
            {
                this.tEdit_EmployeeCode.DataText = employee.EmployeeCode.Trim();
                this.uLabel_EmployeeName.Text = employee.Name;

                // �t�H�[�J�X
                this.tNedit_GoodsMakerCd.Focus();
                ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = true; // ADD 2010/08/11
            }
        }
        #endregion

        #region �� ���o�����ύX�C�x���g
        // --- ADD 2009/02/03 -------------------------------->>>>>
        /// <summary>
        /// tComboEditor_DisplayDiv_BeforeEnterEditMode�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_DisplayDiv_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            // �ύX�O��DisplayDiv��Value��ێ�
            this._tmpDisplayDivValue = (int)this.tComboEditor_DisplayDiv.SelectedItem.DataValue;
        }
        // --- ADD 2009/02/03 --------------------------------<<<<<

        /// <summary>
        /// tComboEditor_DisplayDiv_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_DisplayDiv_ValueChanged(object sender, EventArgs e)
        {
            // --- 2010/08/11 ---------->>>>>
            bool inputErrorFlg = true;
            foreach (Infragistics.Win.ValueListItem item in this.tComboEditor_DisplayDiv.Items)
            {
                if (item.DataValue == this.tComboEditor_DisplayDiv.Value)
                {
                    inputErrorFlg = false;
                    break;
                }
            }
            if (inputErrorFlg)
            {
                return;
            }
            // --- 2010/08/11 ----------<<<<<

            if (!this._initializeFinish)
            {
                // ��ʏ��������͏������Ȃ�
                return;
            }

            // --- ADD 2009/02/03 -------------------------------->>>>>
            // �N���A����
            // �ύX�L���`�F�b�N
            bool isChanged = this.CompareGridDataWithOriginal();

            if (isChanged)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                    "������Ԃɖ߂��܂����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.No)
                {
                    this.tComboEditor_DisplayDiv.ValueChanged -= this.tComboEditor_DisplayDiv_ValueChanged;
                    this.tComboEditor_DisplayDiv.Value = this._tmpDisplayDivValue;
                    this.tComboEditor_DisplayDiv.ValueChanged += this.tComboEditor_DisplayDiv_ValueChanged;
                    return;
                }
            }
            // --- ADD 2009/02/03 --------------------------------<<<<<

            // �Ώۋ敪
            // �I��l��ۑ�
            object tmpObj;

            if (this.tComboEditor_TargetDiv.SelectedItem != null)
            {
                tmpObj = this.tComboEditor_TargetDiv.SelectedItem.DataValue;
            }
            else
            {
                tmpObj = 0;
            }

            this.tComboEditor_TargetDiv.ResetItems();

            this.SetTComboEditor_TargetDiv();

            this.tComboEditor_TargetDiv.ValueChanged -= this.tComboEditor_TargetDiv_ValueChanged; // ADD 2009/02/03
            this.tComboEditor_TargetDiv.Value = tmpObj;
            this.tComboEditor_TargetDiv.ValueChanged += this.tComboEditor_TargetDiv_ValueChanged; // ADD 2009/02/03

            if (this.tComboEditor_TargetDiv.SelectedItem == null)
            {
                this.tComboEditor_TargetDiv.SelectedIndex = 0;
            }

            // �o�͎w��
            this.SetTComboEditor_OutputDivVisible();

            // ���o�����ݒ�
            SetExtractItemSettings();

            // �O���b�h���̏�����
            this._detailGrid.Initialize(); // ADD 2009/02/03
        }

        // --- ADD 2009/02/03 -------------------------------->>>>>
        /// <summary>
        /// tComboEditor_TargetDiv_BeforeEnterEditMode�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_TargetDiv_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            // �ύX�O��TargetDiv��Value��ێ�
            this._tmpTargetDivValue = (int)this.tComboEditor_TargetDiv.SelectedItem.DataValue;
        }
        // --- ADD 2009/02/03 --------------------------------<<<<<

        /// <summary>
        /// tComboEditor_TargetDiv_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_TargetDiv_ValueChanged(object sender, EventArgs e)
        {
            // --- 2010/08/11 ---------->>>>>
            bool inputErrorFlg = true;
            foreach (Infragistics.Win.ValueListItem item in this.tComboEditor_TargetDiv.Items)
            {
                if (item.DataValue == this.tComboEditor_TargetDiv.Value)
                {
                    inputErrorFlg = false;
                    break;
                }
                
            }
            if (inputErrorFlg)
            {
                return;
            }
            // --- 2010/08/11 ----------<<<<<

            if (!this._initializeFinish)
            {
                // ��ʏ��������͏������Ȃ�
                return;
            }

            // --- ADD 2009/02/03 -------------------------------->>>>>
            // �N���A����
            // �ύX�L���`�F�b�N
            bool isChanged = this.CompareGridDataWithOriginal();

            if (isChanged)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                    "������Ԃɖ߂��܂����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.No)
                {
                    this.tComboEditor_TargetDiv.ValueChanged -= this.tComboEditor_TargetDiv_ValueChanged;
                    this.tComboEditor_TargetDiv.Value = this._tmpTargetDivValue;
                    this.tComboEditor_TargetDiv.ValueChanged += this.tComboEditor_TargetDiv_ValueChanged;
                    return;
                }
            }
            // --- ADD 2009/02/03 --------------------------------<<<<<

            if (this.tComboEditor_TargetDiv.SelectedItem == null)
            {
                // �I��l�������ꍇ���������Ȃ�(�\���敪�ύX�C�x���g�ŁA���̑I�����ڂ������ꍇ)
                return;
            }

            // �o�͎w��
            this.SetTComboEditor_OutputDivVisible();

            // ���o�����ݒ�
            SetExtractItemSettings();

            // �O���b�h���̏�����
            this._detailGrid.Initialize(); // ADD 2009/02/03
        }
        #endregion

        #region �� �폜�ς݃f�[�^�\���{�^���N���b�N�C�x���g
        /// <summary>
        /// �폜�ς݃f�[�^�\���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteIndication_CheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            this._detailGrid.DeleteIndicationSetting(this.DeleteIndication_CheckEditor.Checked);
        }
        #endregion

        // --- ADD 2009/02/04 -------------------------------->>>>>
        #region �� ���������L�����Z���{�^���N���b�N�C�x���g
        private void SearchCancelButton_Click(object sender, EventArgs e)
        {
            this._goodsStockAcs.CancelFlg = true;
        }
        #endregion
        // --- ADD 2009/02/04 -------------------------------->>>>>

        #region �� �����t�H�[�J�X�^�C�}
        /// <summary>
        /// �����t�H�[�J�X�ݒ�^�C�}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitialFocusTimer_Tick(object sender, EventArgs e)
        {
            // �t�H�[�J�X�ݒ�
            this.tComboEditor_DisplayDiv.Focus();
            ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11

            //-------DEL BY ������ on 2012/09/19 for Redmine#32370------>>>>>>
            //// XML�f�[�^�Ǎ�
            //this._detailGrid.LoadStateXmlData();
            //-------DEL BY ������ on 2012/09/19 for Redmine#32370------<<<<<<

            // �O���b�h�̕\���A��\���ݒ���ēǍ���
            this._detailGrid.SetGridSettings();

            // �폜�ς݃f�[�^�\���̐���
            this._detailGrid.DeleteIndicationSetting(this.DeleteIndication_CheckEditor.Checked);

            this.InitialFocusTimer.Enabled = false;
        }
        #endregion 

        //---ADD 2010/08/11---------->>>>>
        /// <summary>
        /// �R�[�h����̑I�����\�֕ύX����
        /// </summary>
        /// <param name="name"></param>
        private void setTComboEditorByName(string name)
        {
            TComboEditor control = (TComboEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

            bool inputErrorFlg = true;
            foreach (Infragistics.Win.ValueListItem item in control.Items)
            {
                if (item.DataValue == control.Value)
                {
                    inputErrorFlg = false;
                    break;
                }
            }

            if (inputErrorFlg)
            {
                control.Value = this._preComboEditorValue;
            }
            else
            {
                this._preComboEditorValue = control.Value;
            }
        }

        /// <summary>
        /// �L�[�����C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI09201UA_KeyDown(object sender, KeyEventArgs e)
        {
            this._detailGrid.PMZAI09201UB_KeyDown(sender, e);
        }

        //---ADD 2010/08/11----------<<<<<

        #endregion
    }
}