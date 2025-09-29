//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F�q�ɐݒ�}�X�^
// �v���O�����T�v   �F�q�ɐݒ�̓o�^�E�C���E�폜���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E�@�K�j
// �C����    2008/06/04     �C�����e�F�u���Ӑ�v�u��Ǒq�Ɂv�u�݌Ɉꊇ���}�[�N�v�ǉ��A�u�q�ɔ��l2�`5�v�폜
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30462 �s�V �m��
// �C����    2008/10/09     �C�����e�F�o�O�C��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/16     �C�����e�FMantis�y12826�z���x�A�b�v�Ή�
//                                  �FMantis�y13189�z�}�X�����ŐV���Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C �� ��  2009/06/29     �C�����e�FMANTIS�y13347�z�Ή�
//----------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;   // ADD 2009/04/16
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Infragistics.Win.Misc;
//using Broadleaf.Application.Remoting.ParamData;  // DEL 2008/06/04

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���_�ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���_�ݒ���s���܂��B
    /// <br>Programmer : 22022 �i�� �m�q</br>
    /// <br>Date       : 2006.12.22</br>
    /// <br>Note       : ���_���̎擾��������[�g�ɏC���B
    /// <br>Programmer : 980023 �ђJ �k��</br>
    /// <br>Date       : 2007.05.23</br>
	/// <br>Update Note: 2007.08.28 30167 ���@�O�M</br>
	/// <br>			�V�K���[�h���̂݃e�[�u���f�[�^�̍Ď擾������悤�C��</br>
	/// <br>Update Note: 2008.03.03 30167 ���@�O�M</br>
	/// <br>			�E���ڃ[�����ߑΉ��i��ʃf�U�C���ɃR���|�[�l���g�ǉ��A
	///					�@Tedit�ATNedit�̐ݒ�ύX�j
	///					�E�q�ɖ��̂̍��ږ���ύX�i�[�����߂w�l�k�Ŏg�p����Ă��邽�߁j</br>
    /// <br>Update Note: 2008/06/04 30414 �E�@�K�j</br>
    /// <br>			�E�u���Ӑ�v�u��Ǒq�Ɂv�u�݌Ɉꊇ���}�[�N�v�ǉ��A�u�q�ɔ��l2�`5�v�폜</br>
    /// <br>UpdateNote   : 2008/10/09 30462 �s�V �m���@�o�O�C��</br>
    /// </remarks>
    public class MAKHN09330UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        # region Private Members (Component)

        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private System.Windows.Forms.Timer Initial_Timer;
        private Broadleaf.Library.Windows.Forms.TEdit SectionGuideNm_tEdit;
        private Infragistics.Win.Misc.UltraLabel Section_Title_Label;
        private System.Data.DataSet Bind_DataSet;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Panel Button_Panel;
        private TEdit WarehouseCdName_tEdit;
        private UltraLabel DivideLine_Label;
        private UltraLabel WarehouseName_Title_Label;
        private UltraLabel WarehouseCode_Title_Label;
        private TEdit tEdit_SectionCode;
        private TEdit tEdit_WarehouseCode;
        private UltraLabel WarehouseNote1_Title_Label;
        private TEdit WarehouseNote1_tEdit;
        private UltraLabel Customer_Title_uLabel;
        private TEdit MainMngWarehouseNm_tEdit;
        private TEdit CustomerName_tEdit;
        private UltraButton MainMngWarehouseGuide_Button;
        private UltraButton CustomerGuide_Button;
        private UltraLabel StockBlnktRemark_Title_uLabel;
        private UltraLabel MainMngWarehouse_Title_uLabel;
        private TEdit StockBlnktRemark2_tEdit;
        private TEdit StockBlnktRemark1_tEdit;
        private UltraButton SectionGuide_Button;
        private TEdit tEdit_MainMngWarehouseCd;
        private UiSetControl uiSetControl1;
        private TNedit tNedit_CustomerCode;
        private UltraButton Renewal_Button;
        private System.ComponentModel.IContainer components;

        # endregion

        # region Constructor

        /// <summary>
        /// ���_�ݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public MAKHN09330UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint                  = false;
            this._canClose                  = false;
            this._canNew                    = true;
            this._canDelete                 = true;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._mainGridTitle             = "���_���";
            this._detailsGridTitle          = "�q��";
            this._defaultGridDisplayLayout  = MGridDisplayLayout.Vertical;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._dataIndex = -1;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            // ��ƃR�[�h���擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �ϐ�������
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._targetTableName = "";
            this._mainDataIndex = -2;
            this._detailsDataIndex = -2;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            // ----- iitani c ---------- start  2007.05.23
            //this._secInfoAcs    = new SecInfoAcs();         // ���_
            this._secInfoAcs = new SecInfoAcs(1);         // ���_(�����[�g�Ǎ�)
            // ----- iitani c ---------- start  2007.05.23
            this._warehouseAcs = new WarehouseAcs();       // �q��

            this._customerInfoAcs = new CustomerInfoAcs();  // ADD 2008/06/04

            //this._mainTable = new Hashtable();  // DEL 2008/06/04
            this._detailsTable = new Hashtable();
            //this._allSearchHash = new Hashtable();  // DEL 2008/06/04

            //GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            //this._mainIndexBuf = -2;  // DEL 2008/06/04
            this._detailsIndexBuf = -2;
            //this._targetTableBuf = "";  // DEL 2008/06/04

            // ADD 2009/04/16 ------>>>
            // �L���b�V�����擾
            this.GetCacheData();
            // ADD 2009/04/16 ------<<<

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // �A�C�R���p�_�~�[
            this._mainGridIcon = null;
            this._detailsGridIcon = null;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        }

        # endregion

        # region Dispose

        /// <summary>
        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        # endregion

        #region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h

        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���Ӑ�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�q�ɃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���_�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKHN09330UA));
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Section_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SectionGuideNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.CustomerGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.MainMngWarehouseGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.Button_Panel = new System.Windows.Forms.Panel();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.WarehouseCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.WarehouseName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DivideLine_Label = new Infragistics.Win.Misc.UltraLabel();
            this.WarehouseCdName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_WarehouseCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.WarehouseNote1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.WarehouseNote1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Customer_Title_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MainMngWarehouseNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.StockBlnktRemark1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.StockBlnktRemark2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MainMngWarehouse_Title_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.StockBlnktRemark_Title_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_MainMngWarehouseCd = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.tNedit_CustomerCode = new Broadleaf.Library.Windows.Forms.TNedit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            this.Button_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCdName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseNote1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainMngWarehouseNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBlnktRemark1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBlnktRemark2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MainMngWarehouseCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).BeginInit();
            this.SuspendLayout();
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 340);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(814, 23);
            this.ultraStatusBar1.TabIndex = 46;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(296, 10);
            this.Delete_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 15;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(423, 10);
            this.Revive_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 16;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(550, 10);
            this.Ok_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 17;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(677, 10);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 18;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Section_Title_Label
            // 
            this.Section_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.Section_Title_Label.Location = new System.Drawing.Point(12, 85);
            this.Section_Title_Label.Name = "Section_Title_Label";
            this.Section_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.Section_Title_Label.TabIndex = 140;
            this.Section_Title_Label.Text = "�Ǘ����_";
            // 
            // Mode_Label
            // 
            appearance13.ForeColor = System.Drawing.Color.White;
            appearance13.TextHAlignAsString = "Center";
            appearance13.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance13;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(709, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 230;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // SectionGuideNm_tEdit
            // 
            this.SectionGuideNm_tEdit.ActiveAppearance = appearance7;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionGuideNm_tEdit.Appearance = appearance8;
            this.SectionGuideNm_tEdit.AutoSelect = true;
            this.SectionGuideNm_tEdit.DataText = "";
            this.SectionGuideNm_tEdit.Enabled = false;
            this.SectionGuideNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionGuideNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionGuideNm_tEdit.Location = new System.Drawing.Point(190, 85);
            this.SectionGuideNm_tEdit.MaxLength = 6;
            this.SectionGuideNm_tEdit.Name = "SectionGuideNm_tEdit";
            this.SectionGuideNm_tEdit.ReadOnly = true;
            this.SectionGuideNm_tEdit.Size = new System.Drawing.Size(113, 24);
            this.SectionGuideNm_tEdit.TabIndex = 4;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // CustomerGuide_Button
            // 
            this.CustomerGuide_Button.Location = new System.Drawing.Point(558, 142);
            this.CustomerGuide_Button.Name = "CustomerGuide_Button";
            this.CustomerGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.CustomerGuide_Button.TabIndex = 8;
            ultraToolTipInfo3.ToolTipText = "���Ӑ�K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.CustomerGuide_Button, ultraToolTipInfo3);
            this.CustomerGuide_Button.Click += new System.EventHandler(this.CustomerGuide_Button_Click);
            // 
            // MainMngWarehouseGuide_Button
            // 
            this.MainMngWarehouseGuide_Button.Location = new System.Drawing.Point(550, 172);
            this.MainMngWarehouseGuide_Button.Name = "MainMngWarehouseGuide_Button";
            this.MainMngWarehouseGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.MainMngWarehouseGuide_Button.TabIndex = 11;
            ultraToolTipInfo2.ToolTipText = "�q�ɃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.MainMngWarehouseGuide_Button, ultraToolTipInfo2);
            this.MainMngWarehouseGuide_Button.Click += new System.EventHandler(this.MainMngWarehouseGuide_Button_Click);
            // 
            // SectionGuide_Button
            // 
            this.SectionGuide_Button.Location = new System.Drawing.Point(309, 85);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.SectionGuide_Button.TabIndex = 5;
            ultraToolTipInfo1.ToolTipText = "���_�K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_Button, ultraToolTipInfo1);
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // Button_Panel
            // 
            this.Button_Panel.Controls.Add(this.Renewal_Button);
            this.Button_Panel.Controls.Add(this.Cancel_Button);
            this.Button_Panel.Controls.Add(this.Delete_Button);
            this.Button_Panel.Controls.Add(this.Revive_Button);
            this.Button_Panel.Controls.Add(this.Ok_Button);
            this.Button_Panel.Location = new System.Drawing.Point(0, 286);
            this.Button_Panel.Name = "Button_Panel";
            this.Button_Panel.Size = new System.Drawing.Size(814, 54);
            this.Button_Panel.TabIndex = 168;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(423, 10);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 16;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // WarehouseCode_Title_Label
            // 
            this.WarehouseCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.WarehouseCode_Title_Label.Location = new System.Drawing.Point(12, 25);
            this.WarehouseCode_Title_Label.Name = "WarehouseCode_Title_Label";
            this.WarehouseCode_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.WarehouseCode_Title_Label.TabIndex = 160;
            this.WarehouseCode_Title_Label.Text = "�q�ɃR�[�h";
            // 
            // WarehouseName_Title_Label
            // 
            this.WarehouseName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.WarehouseName_Title_Label.Location = new System.Drawing.Point(12, 55);
            this.WarehouseName_Title_Label.Name = "WarehouseName_Title_Label";
            this.WarehouseName_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.WarehouseName_Title_Label.TabIndex = 170;
            this.WarehouseName_Title_Label.Text = "�q�ɖ�";
            // 
            // DivideLine_Label
            // 
            this.DivideLine_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DivideLine_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.DivideLine_Label.Location = new System.Drawing.Point(12, 124);
            this.DivideLine_Label.Name = "DivideLine_Label";
            this.DivideLine_Label.Size = new System.Drawing.Size(795, 3);
            this.DivideLine_Label.TabIndex = 24;
            // 
            // WarehouseCdName_tEdit
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.WarehouseCdName_tEdit.ActiveAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.WarehouseCdName_tEdit.Appearance = appearance4;
            this.WarehouseCdName_tEdit.AutoSelect = true;
            this.WarehouseCdName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.WarehouseCdName_tEdit.DataText = "";
            this.WarehouseCdName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.WarehouseCdName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.WarehouseCdName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.WarehouseCdName_tEdit.Location = new System.Drawing.Point(148, 55);
            this.WarehouseCdName_tEdit.MaxLength = 20;
            this.WarehouseCdName_tEdit.Name = "WarehouseCdName_tEdit";
            this.WarehouseCdName_tEdit.Size = new System.Drawing.Size(330, 24);
            this.WarehouseCdName_tEdit.TabIndex = 2;
            // 
            // tEdit_SectionCode
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCode.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCode.Appearance = appearance6;
            this.tEdit_SectionCode.AutoSelect = true;
            this.tEdit_SectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCode.DataText = "";
            this.tEdit_SectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, true, true, true));
            this.tEdit_SectionCode.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SectionCode.Location = new System.Drawing.Point(148, 85);
            this.tEdit_SectionCode.MaxLength = 6;
            this.tEdit_SectionCode.Name = "tEdit_SectionCode";
            this.tEdit_SectionCode.Size = new System.Drawing.Size(35, 24);
            this.tEdit_SectionCode.TabIndex = 3;
            // 
            // tEdit_WarehouseCode
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_WarehouseCode.ActiveAppearance = appearance14;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance25.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_WarehouseCode.Appearance = appearance25;
            this.tEdit_WarehouseCode.AutoSelect = true;
            this.tEdit_WarehouseCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_WarehouseCode.DataText = "";
            this.tEdit_WarehouseCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_WarehouseCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, true, true));
            this.tEdit_WarehouseCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_WarehouseCode.Location = new System.Drawing.Point(148, 25);
            this.tEdit_WarehouseCode.MaxLength = 6;
            this.tEdit_WarehouseCode.Name = "tEdit_WarehouseCode";
            this.tEdit_WarehouseCode.Size = new System.Drawing.Size(51, 24);
            this.tEdit_WarehouseCode.TabIndex = 1;
            // 
            // WarehouseNote1_tEdit
            // 
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.WarehouseNote1_tEdit.ActiveAppearance = appearance21;
            appearance22.ForeColorDisabled = System.Drawing.Color.Black;
            this.WarehouseNote1_tEdit.Appearance = appearance22;
            this.WarehouseNote1_tEdit.AutoSelect = true;
            this.WarehouseNote1_tEdit.DataText = "";
            this.WarehouseNote1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.WarehouseNote1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.WarehouseNote1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.WarehouseNote1_tEdit.Location = new System.Drawing.Point(148, 232);
            this.WarehouseNote1_tEdit.MaxLength = 40;
            this.WarehouseNote1_tEdit.Name = "WarehouseNote1_tEdit";
            this.WarehouseNote1_tEdit.Size = new System.Drawing.Size(639, 24);
            this.WarehouseNote1_tEdit.TabIndex = 14;
            // 
            // WarehouseNote1_Title_Label
            // 
            this.WarehouseNote1_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.WarehouseNote1_Title_Label.Location = new System.Drawing.Point(12, 232);
            this.WarehouseNote1_Title_Label.Name = "WarehouseNote1_Title_Label";
            this.WarehouseNote1_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.WarehouseNote1_Title_Label.TabIndex = 180;
            this.WarehouseNote1_Title_Label.Text = "�q�ɔ��l";
            // 
            // Customer_Title_uLabel
            // 
            this.Customer_Title_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.Customer_Title_uLabel.Location = new System.Drawing.Point(12, 142);
            this.Customer_Title_uLabel.Name = "Customer_Title_uLabel";
            this.Customer_Title_uLabel.Size = new System.Drawing.Size(130, 24);
            this.Customer_Title_uLabel.TabIndex = 169;
            this.Customer_Title_uLabel.Text = "���Ӑ�";
            // 
            // CustomerName_tEdit
            // 
            this.CustomerName_tEdit.ActiveAppearance = appearance11;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            this.CustomerName_tEdit.Appearance = appearance12;
            this.CustomerName_tEdit.AutoSelect = true;
            this.CustomerName_tEdit.DataText = "";
            this.CustomerName_tEdit.Enabled = false;
            this.CustomerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CustomerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CustomerName_tEdit.Location = new System.Drawing.Point(230, 142);
            this.CustomerName_tEdit.MaxLength = 40;
            this.CustomerName_tEdit.Name = "CustomerName_tEdit";
            this.CustomerName_tEdit.ReadOnly = true;
            this.CustomerName_tEdit.Size = new System.Drawing.Size(314, 24);
            this.CustomerName_tEdit.TabIndex = 7;
            // 
            // MainMngWarehouseNm_tEdit
            // 
            this.MainMngWarehouseNm_tEdit.ActiveAppearance = appearance15;
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            this.MainMngWarehouseNm_tEdit.Appearance = appearance16;
            this.MainMngWarehouseNm_tEdit.AutoSelect = true;
            this.MainMngWarehouseNm_tEdit.DataText = "";
            this.MainMngWarehouseNm_tEdit.Enabled = false;
            this.MainMngWarehouseNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MainMngWarehouseNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.MainMngWarehouseNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.MainMngWarehouseNm_tEdit.Location = new System.Drawing.Point(206, 172);
            this.MainMngWarehouseNm_tEdit.MaxLength = 40;
            this.MainMngWarehouseNm_tEdit.Name = "MainMngWarehouseNm_tEdit";
            this.MainMngWarehouseNm_tEdit.ReadOnly = true;
            this.MainMngWarehouseNm_tEdit.Size = new System.Drawing.Size(330, 24);
            this.MainMngWarehouseNm_tEdit.TabIndex = 10;
            // 
            // StockBlnktRemark1_tEdit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockBlnktRemark1_tEdit.ActiveAppearance = appearance17;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            this.StockBlnktRemark1_tEdit.Appearance = appearance18;
            this.StockBlnktRemark1_tEdit.AutoSelect = true;
            this.StockBlnktRemark1_tEdit.DataText = "";
            this.StockBlnktRemark1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.StockBlnktRemark1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, true, true));
            this.StockBlnktRemark1_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.StockBlnktRemark1_tEdit.Location = new System.Drawing.Point(148, 202);
            this.StockBlnktRemark1_tEdit.MaxLength = 3;
            this.StockBlnktRemark1_tEdit.Name = "StockBlnktRemark1_tEdit";
            this.StockBlnktRemark1_tEdit.Size = new System.Drawing.Size(43, 24);
            this.StockBlnktRemark1_tEdit.TabIndex = 12;
            // 
            // StockBlnktRemark2_tEdit
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockBlnktRemark2_tEdit.ActiveAppearance = appearance19;
            appearance20.ForeColorDisabled = System.Drawing.Color.Black;
            this.StockBlnktRemark2_tEdit.Appearance = appearance20;
            this.StockBlnktRemark2_tEdit.AutoSelect = true;
            this.StockBlnktRemark2_tEdit.DataText = "";
            this.StockBlnktRemark2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.StockBlnktRemark2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, true, true));
            this.StockBlnktRemark2_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.StockBlnktRemark2_tEdit.Location = new System.Drawing.Point(198, 202);
            this.StockBlnktRemark2_tEdit.MaxLength = 5;
            this.StockBlnktRemark2_tEdit.Name = "StockBlnktRemark2_tEdit";
            this.StockBlnktRemark2_tEdit.Size = new System.Drawing.Size(51, 24);
            this.StockBlnktRemark2_tEdit.TabIndex = 13;
            // 
            // MainMngWarehouse_Title_uLabel
            // 
            this.MainMngWarehouse_Title_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.MainMngWarehouse_Title_uLabel.Location = new System.Drawing.Point(12, 172);
            this.MainMngWarehouse_Title_uLabel.Name = "MainMngWarehouse_Title_uLabel";
            this.MainMngWarehouse_Title_uLabel.Size = new System.Drawing.Size(130, 24);
            this.MainMngWarehouse_Title_uLabel.TabIndex = 176;
            this.MainMngWarehouse_Title_uLabel.Text = "��Ǒq��";
            // 
            // StockBlnktRemark_Title_uLabel
            // 
            this.StockBlnktRemark_Title_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.StockBlnktRemark_Title_uLabel.Location = new System.Drawing.Point(12, 202);
            this.StockBlnktRemark_Title_uLabel.Name = "StockBlnktRemark_Title_uLabel";
            this.StockBlnktRemark_Title_uLabel.Size = new System.Drawing.Size(130, 24);
            this.StockBlnktRemark_Title_uLabel.TabIndex = 177;
            this.StockBlnktRemark_Title_uLabel.Text = "�݌Ɉꊇ���}�[�N";
            // 
            // tEdit_MainMngWarehouseCd
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_MainMngWarehouseCd.ActiveAppearance = appearance1;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_MainMngWarehouseCd.Appearance = appearance2;
            this.tEdit_MainMngWarehouseCd.AutoSelect = true;
            this.tEdit_MainMngWarehouseCd.DataText = "";
            this.tEdit_MainMngWarehouseCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MainMngWarehouseCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, true, true));
            this.tEdit_MainMngWarehouseCd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_MainMngWarehouseCd.Location = new System.Drawing.Point(148, 172);
            this.tEdit_MainMngWarehouseCd.MaxLength = 6;
            this.tEdit_MainMngWarehouseCd.Name = "tEdit_MainMngWarehouseCd";
            this.tEdit_MainMngWarehouseCd.Size = new System.Drawing.Size(51, 24);
            this.tEdit_MainMngWarehouseCd.TabIndex = 9;
            this.tEdit_MainMngWarehouseCd.ValueChanged += new System.EventHandler(this.tEdit_MainMngWarehouseCd_ValueChanged);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // tNedit_CustomerCode
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance9.ForeColor = System.Drawing.Color.Black;
            this.tNedit_CustomerCode.ActiveAppearance = appearance9;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_CustomerCode.Appearance = appearance10;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode.DataText = "";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point(148, 142);
            this.tNedit_CustomerCode.MaxLength = 12;
            this.tNedit_CustomerCode.Name = "tNedit_CustomerCode";
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(74, 24);
            this.tNedit_CustomerCode.TabIndex = 6;
            // 
            // MAKHN09330UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(814, 363);
            this.Controls.Add(this.tNedit_CustomerCode);
            this.Controls.Add(this.tEdit_MainMngWarehouseCd);
            this.Controls.Add(this.SectionGuide_Button);
            this.Controls.Add(this.MainMngWarehouseGuide_Button);
            this.Controls.Add(this.CustomerGuide_Button);
            this.Controls.Add(this.StockBlnktRemark_Title_uLabel);
            this.Controls.Add(this.MainMngWarehouse_Title_uLabel);
            this.Controls.Add(this.StockBlnktRemark2_tEdit);
            this.Controls.Add(this.StockBlnktRemark1_tEdit);
            this.Controls.Add(this.MainMngWarehouseNm_tEdit);
            this.Controls.Add(this.CustomerName_tEdit);
            this.Controls.Add(this.Customer_Title_uLabel);
            this.Controls.Add(this.WarehouseNote1_Title_Label);
            this.Controls.Add(this.WarehouseNote1_tEdit);
            this.Controls.Add(this.tEdit_WarehouseCode);
            this.Controls.Add(this.tEdit_SectionCode);
            this.Controls.Add(this.WarehouseCdName_tEdit);
            this.Controls.Add(this.DivideLine_Label);
            this.Controls.Add(this.Button_Panel);
            this.Controls.Add(this.WarehouseName_Title_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.WarehouseCode_Title_Label);
            this.Controls.Add(this.SectionGuideNm_tEdit);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Section_Title_Label);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAKHN09330UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "�q�ɐݒ�";
            this.Load += new System.EventHandler(this.MAKHN09230UA_Load);
            this.VisibleChanged += new System.EventHandler(this.MAKHN09230UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MAKHN09230UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            this.Button_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCdName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseNote1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainMngWarehouseNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBlnktRemark1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBlnktRemark2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MainMngWarehouseCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        # region Events

        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;

        # endregion
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        #region Private Menbers

        private SecInfoAcs   _secInfoAcs;       // ���_�p�A�N�Z�X�N���X
        private WarehouseAcs _warehouseAcs;     // �q�ɗp�A�N�Z�X�N���X
        private CustomerInfoAcs _customerInfoAcs;  // ADD 2008/06/04

        private string _enterpriseCode;         // ��ƃR�[�h
        //private Hashtable _mainTable;           // ���_�p�n�b�V���e�[�u��  // DEL 2008/06/04
        private Hashtable _detailsTable;        // �q�ɗp�n�b�V���e�[�u��
        //private Hashtable _allSearchHash;       // �S���R�[�h�m�ۗp  // DEL 2008/06/04

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        private string _mainGridTitle;
        private string _detailsGridTitle;
        private string _targetTableName;
        private int _mainDataIndex;
        private int _detailsDataIndex;
        private Image _mainGridIcon;
        private Image _detailsGridIcon;
        private MGridDisplayLayout _defaultGridDisplayLayout;
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        private int _dataIndex;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canSpecificationSearch;
        private bool _defaultAutoFillToColumn;
        private bool _cusotmerGuideSelected;
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

        // ADD 2009/04/16 ------>>>
        // ���Ӑ���L���b�V��
        private ArrayList _customerList;
        // �q�ɏ��L���b�V��
        private Dictionary<string, Warehouse> _warehouseDic;
        // ADD 2009/04/16 ------<<<
        
        //_GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        //private int _mainIndexBuf;  // DEL 2008/06/04
        private int _detailsIndexBuf;
        //private string _targetTableBuf;  // DEL 2008/06/04

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // �I�����̕ҏW�`�F�b�N�p
        private Warehouse _warehouseClone;

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string DELETE_DATE_TITLE      = "�폜��";
        private const string SECTIONCODE_TITLE      = "�Ǘ����_�R�[�h";
        private const string SECTIONGUIDENM_TITLE   = "�Ǘ����_��";
        private const string WAREHOUSECODE_TITLE    = "�q�ɃR�[�h";
        private const string WAREHOUSENAME_TITLE    = "�q�ɖ�";
        private const string WAREHOUSENOTE_TITLE   = "�q�ɔ��l";
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        private const string WAREHOUSENOTE2_TITLE   = "�q�ɔ��l2";
        private const string WAREHOUSENOTE3_TITLE   = "�q�ɔ��l3";
        private const string WAREHOUSENOTE4_TITLE   = "�q�ɔ��l4";
        private const string WAREHOUSENOTE5_TITLE   = "�q�ɔ��l5";
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        private const string CUSTOMERCODE_TITLE = "���Ӑ�R�[�h";
        private const string CUSTOMERNAME_TITLE = "���Ӑ於";
        private const string MAINMNGWAREHOUSECD_TITLE = "��Ǒq�ɃR�[�h";
        private const string MAINMNGWAREHOUSENM_TITLE = "��Ǒq�ɖ�";
        private const string STOCKBLNKREMARK_TITLE = "�݌Ɉꊇ���}�[�N";
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // �e�[�u������
        //private const string MAIN_TABLE     = "SecInfoSet"; // ���_  // DEL 2008/06/04
        private const string DETAILS_TABLE  = "Warehouse";  // �q��

        // �K�C�h�L�[
        private const string MAIN_GUID_KEY = "MainGuid";
        private const string DETAILS_GUID_KEY = "DetailsGuid";

        // ��ʃ��C�A�E�g�p�萔
        private const int BUTTON_LOCATION1_X = 296;     // ���S�폜�{�^���ʒuX
        private const int BUTTON_LOCATION2_X = 423;     // �����{�^���ʒuX
        private const int BUTTON_LOCATION3_X = 550;     // �ۑ��{�^���ʒuX
        private const int BUTTON_LOCATION4_X = 677;     // ����{�^���ʒuX
        private const int BUTTON_LOCATION_Y = 10;        // �{�^���ʒuY(����)

        // Message�֘A��`
        private const string ASSEMBLY_ID = "MAKHN09330U";
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";

        #endregion

        # region Main
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new MAKHN09330UA());
        }
        # endregion

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

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>�O���b�h�̃f�t�H���g�\���ʒu�v���p�e�B</summary>
        /// <value>�O���b�h�̃f�t�H���g�\���ʒu���擾���܂��B</value>
        public MGridDisplayLayout DefaultGridDisplayLayout
        {
            get { return this._defaultGridDisplayLayout; }
        }

        /// <summary>����Ώۃf�[�^�e�[�u�����̃v���p�e�B</summary>
        /// <value>�{���Ώۃf�[�^�̃e�[�u�����̂��擾�܂��͐ݒ肵�܂��B</value>
        public string TargetTableName
        {
            get { return this._targetTableName; }
            set { this._targetTableName = value; }
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        # endregion

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
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
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add(DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(SECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(SECTIONGUIDENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(WAREHOUSECODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(WAREHOUSENAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(WAREHOUSENOTE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(CUSTOMERCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(CUSTOMERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(MAINMNGWAREHOUSECD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(MAINMNGWAREHOUSENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(STOCKBLNKREMARK_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(DETAILS_GUID_KEY, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

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
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        # region Public Methods
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �_���폜�f�[�^���o�\�ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�_���폜�f�[�^���o�\�ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�f�[�^�̒��o���\���ǂ����̐ݒ��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDelete = { false, true };
            return logicalDelete;
        }

        /// <summary>
        /// �O���b�h�^�C�g�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�^�C�g�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃^�C�g����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { _mainGridTitle, _detailsGridTitle };
            return gridTitle;
        }

        /// <summary>
        /// �O���b�h�A�C�R�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�A�C�R�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�C�R����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public Image[] GetGridIconList()
        {
            Image[] gridIcon = { _mainGridIcon, _detailsGridIcon };
            return gridIcon;
        }

        /// <summary>
        /// �O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g�擾����
        /// </summary>
        /// <returns>�O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            bool[] defaultAutoFill = { true, true };
            return defaultAutoFill;
        }

        /// <summary>
        /// �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g�ݒ菈��
        /// </summary>
        /// <param name="indexList">�f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g��ݒ肵�܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;
            this._mainDataIndex = intVal[0];
            this._detailsDataIndex = intVal[1];
        }

        /// <summary>
        /// �V�K�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�V�K�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �V�K�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] newButtonEnabled = { false, true };
            // �e�f�[�^���Ȃ��ꍇ�́A����
            if (this._mainDataIndex < 0)
            {
                newButtonEnabled[1] = false;
            }
            return newButtonEnabled;
        }

        /// <summary>
        /// �C���{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] modifyButtonEnabled = { false, true };
            // �e�f�[�^���Ȃ��ꍇ�́A����
            if (this._mainDataIndex < 0)
            {
                modifyButtonEnabled[1] = false;
            }
            return modifyButtonEnabled;
        }

        /// <summary>
        /// �폜�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�폜�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �폜�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] deleteButtonEnabled = { false, true };
            // �e�f�[�^���Ȃ��ꍇ�́A����
            if (this._mainDataIndex < 0)
            {
                deleteButtonEnabled[1] = false;
            }
            return deleteButtonEnabled;
        }

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName[0] = MAIN_TABLE;
            tableName[1] = DETAILS_TABLE;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// ���_��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S�f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            totalCount = 0;

            try
            {
                // �N���A
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Clear();
                this._mainTable.Clear();
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();
                this._detailsTable.Clear();
                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                if (this._secInfoAcs.SecInfoSetList.Length > 0)
                {
                    // �擾�������_���N���X���f�[�^�Z�b�g�֓W�J����
                    int index = 0;
                    foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                    {
                        // ���_���N���X�f�[�^�Z�b�g�W�J����
                        MainToDataSet(secInfoSet.Clone(), index);
                        ++index;
                    }

                    totalCount = this._secInfoAcs.SecInfoSetList.Length;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                ArrayList retList = new ArrayList();
                status = this._warehouseAcs.SearchAll(out retList, this._enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        int index = 0;
            
                        foreach (Warehouse warehouse in retList)
                        {
                            if (this._detailsTable.ContainsKey(warehouse.FileHeaderGuid) == false)
                            {
                                DetailsToDataSet(warehouse.Clone(), index);
                                ++index;
                            }
                        }
                        totalCount = retList.Count;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "MAKHN09330U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "�q�ɐݒ�", 					    // �v���O��������
                            "Search", 					        // ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._warehouseAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                }
                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
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
                    this._secInfoAcs,				      // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK,				  // �\������{�^��
                    MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                status = -1;
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // �����Ȃ�
            return 9;
        }

        /// <summary>
        /// �q�Ɍ�������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �S�f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList WarehouseList = null;

            // �I������Ă��鋒�_�R�[�h���擾����
            //string sectionCode = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE];  // DEL 2008/06/04

            // �q�Ɏ擾
            //status = this._warehouseAcs.SearchAll(out WarehouseList, this._enterpriseCode, sectionCode);  // DEL 2008/06/04
            status = this._warehouseAcs.SearchAll(out WarehouseList, this._enterpriseCode);  // ADD 2008/06/04
            
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();
                        this._detailsTable.Clear();

                        int index = 0;
                        foreach (Warehouse warehouse in WarehouseList)
                        {
                            if (this._detailsTable.ContainsKey(warehouse.FileHeaderGuid) == false)
                            {
                                DetailsToDataSet(warehouse.Clone(), index);
                                ++index;
                            }
                        }

                        totalCount = WarehouseList.Count;

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �f�[�^�Ȃ��̏ꍇ�̓O���b�h���N���A
                        this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();
                        this._detailsTable.Clear();
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "DetailsDataSearch", 				// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            ERR_READ_MSG,						// �\�����郁�b�Z�[�W 
                            status, 							// �X�e�[�^�X�l
                            this._warehouseAcs, 			    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
            }

            return status;
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            // ������
            return 9;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName)
            {
                // ���_�e�[�u���̏ꍇ
                case MAIN_TABLE:
                    {
                        break;
                    }
                // �q�Ƀe�[�u���̏ꍇ
                case DETAILS_TABLE:
                    {
                        // �q�ɘ_���폜����
                        status = LogicalDeleteWarehouse();
                        break;
                    }
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // �q�ɘ_���폜����
            status = LogicalDeleteWarehouse();
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Print()
        {
            // ����@�\�����̈ז�����
            return 0;
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] _hashtable)
        {
            // ���_Grid
            Hashtable main = new Hashtable();
            main.Add(SECTIONCODE_TITLE,     new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "",   Color.Black));
            main.Add(SECTIONGUIDENM_TITLE,  new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "",   Color.Black));
            main.Add(MAIN_GUID_KEY,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));

            // �q��Grid
            Hashtable details = new Hashtable();
            details.Add(DELETE_DATE_TITLE,      new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            details.Add(SECTIONCODE_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));
            details.Add(WAREHOUSECODE_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "",   Color.Black));
            details.Add(WAREHOUSENAME_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "",   Color.Black));
            details.Add(WAREHOUSENOTE_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));
            
            details.Add(WAREHOUSENOTE2_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));
            details.Add(WAREHOUSENOTE3_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));
            details.Add(WAREHOUSENOTE4_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));
            details.Add(WAREHOUSENOTE5_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));
            
            details.Add(DETAILS_GUID_KEY,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));

            _hashtable = new Hashtable[2];
            _hashtable[0] = main;
            _hashtable[1] = details;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        # endregion

        # region Private Methods
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���_�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="warehouse">���_�ݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���_�ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void MainToDataSet(SecInfoSet secInfoSet, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[MAIN_TABLE].NewRow();
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count - 1;
            }

            // ���_�R�[�h
            this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][SECTIONCODE_TITLE] = secInfoSet.SectionCode;
            // ���_����
            this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][SECTIONGUIDENM_TITLE] = secInfoSet.SectionGuideNm;
            // GUID
            this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][MAIN_GUID_KEY] = secInfoSet.FileHeaderGuid;


            // �n�b�V���e�[�u���X�V
            if (this._mainTable.ContainsKey(secInfoSet.FileHeaderGuid) == true)
            {
                this._mainTable.Remove(secInfoSet.FileHeaderGuid);
            }
            this._mainTable.Add(secInfoSet.FileHeaderGuid, secInfoSet);
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// �q�ɐݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="warehouse">�q�ɐݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �q�ɐݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void DetailsToDataSet(Warehouse warehouse, int index)
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
            if (warehouse.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = warehouse.UpdateDateTimeJpInFormal;
            }

            // ���_�R�[�h
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SECTIONCODE_TITLE] = warehouse.SectionCode;
            // �q�ɃR�[�h
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSECODE_TITLE] = warehouse.WarehouseCode;
            // �q�ɖ���
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSENAME_TITLE] = warehouse.WarehouseName;
            // �q�ɔ��l
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSENOTE_TITLE] = warehouse.WarehouseNote1;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSENOTE2_TITLE] = warehouse.WarehouseNote2;
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSENOTE3_TITLE] = warehouse.WarehouseNote3;
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSENOTE4_TITLE] = warehouse.WarehouseNote4;
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSENOTE5_TITLE] = warehouse.WarehouseNote5;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // ���_����
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SECTIONGUIDENM_TITLE] = GetSectionName(warehouse.SectionCode);
            // ���Ӑ�R�[�h
            if (warehouse.CustomerCode == 0)
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CUSTOMERCODE_TITLE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CUSTOMERCODE_TITLE] = warehouse.CustomerCode.ToString("00000000");
            }

            // ���Ӑ於��
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CUSTOMERNAME_TITLE] = GetCustomerName(warehouse.CustomerCode);

            // ��Ǒq�ɃR�[�h
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][MAINMNGWAREHOUSECD_TITLE] = warehouse.MainMngWarehouseCd;

            // ��Ǒq�ɖ���
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][MAINMNGWAREHOUSENM_TITLE] = GetWarehouseName(warehouse.MainMngWarehouseCd);

            // �݌Ɉꊇ���}�[�N
            if ((warehouse.StockBlnktRemark != null) && (warehouse.StockBlnktRemark.Length >= 8))
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][STOCKBLNKREMARK_TITLE] = warehouse.StockBlnktRemark.Substring(0, 3) + " " +
                                                                                             warehouse.StockBlnktRemark.Substring(3, 5);
            }
            else
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][STOCKBLNKREMARK_TITLE] = warehouse.StockBlnktRemark;
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            // GUID
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DETAILS_GUID_KEY] = warehouse.FileHeaderGuid;
            
            // �n�b�V���e�[�u���X�V
            if (this._detailsTable.ContainsKey(warehouse.FileHeaderGuid) == true)
            {
                this._detailsTable.Remove(warehouse.FileHeaderGuid);
            }
            this._detailsTable.Add(warehouse.FileHeaderGuid, warehouse);
        }

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於��</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ於�̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            int status;
            CustomerInfo customerInfo = new CustomerInfo();

            try
            {
                // DEL 2009/04/16 ------>>>
                //status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                //if (status == 0)
                //{
                //    customerName = customerInfo.Name.Trim() + customerInfo.Name2.Trim();
                //}
                // DEL 2009/04/16 ------<<<

                // ADD 2009/04/16 ------>>>
                foreach (CustomerSearchRet customerSearchRet in this._customerList)
                {
                    if (customerSearchRet.CustomerCode == customerCode)
                    {
                        customerName = customerSearchRet.Name.Trim() + customerSearchRet.Name2.Trim();
                        break;
                    }
                }

                if (customerName == "")
                {
                    status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                    if (status == 0)
                    {
                        customerName = customerInfo.Name.Trim() + customerInfo.Name2.Trim();
                    }
                }
                // ADD 2009/04/16 ------<<<
            }
            catch
            {
                customerName = "";
            }

            return customerName;
        }

        /// <summary>
        /// �q�ɖ��̎擾����
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <returns>�q�ɖ���</returns>
        /// <remarks>
        /// <br>Note       : �q�ɖ��̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private string GetWarehouseName(string warehouseCode)
        {
            string warehouseName = "";

            // DEL 2009/04/16 ------>>>
            //int status;
            //WarehouseAcs warehouseAcs = new WarehouseAcs();
            //ArrayList retList = new ArrayList();
            // DEL 2009/04/16 ------<<<
                
            try
            {
                // DEL 2009/04/16 ------>>>
                //status = warehouseAcs.SearchAll(out retList, this._enterpriseCode);
                //if (status == 0)
                //{
                //    foreach (Warehouse warehouse in retList)
                //    {
                //        if (warehouse.LogicalDeleteCode == 0)
                //        {
                //            if (warehouse.WarehouseCode.Trim() == warehouseCode.Trim().PadLeft(4, '0'))
                //            {
                //                warehouseName = warehouse.WarehouseName.Trim();
                //                break;
                //            }
                //        }
                //    }
                //}
                // DEL 2009/04/16 ------<<<

                // ADD 2009/04/16 ------>>>
                if (_warehouseDic.ContainsKey(warehouseCode.Trim().PadLeft(4, '0')))
                {
                    Warehouse warehouse = _warehouseDic[warehouseCode.Trim().PadLeft(4, '0')];
                    warehouseName = warehouse.WarehouseName.Trim();
                }
                // ADD 2009/04/16 ------<<<
            }
            catch
            {
                warehouseName = "";
            }

            return warehouseName;
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();
            // DEL 2009/04/16 ------>>>
            //SecInfoAcs secInfoAcs = new SecInfoAcs();
            //secInfoAcs.ResetSectionInfo();
            // DEL 2009/04/16 ------<<<
                
            try
            {
                //foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)      // DEL 2009/04/16
                foreach (SecInfoSet secInfoSet in _secInfoAcs.SecInfoSetList)       // ADD 2009/04/16
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // ADD 2009/06/29 ------>>>
        /// <summary>
        /// ���Ӑ摶�݃`�F�b�N����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>true�FOK�Afalse�FNG</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ悪���݂��邩�`�F�b�N���܂��B</br>
        /// <br></br>
        /// </remarks>
        private bool CheckCustomer(int customerCode)
        {
            bool check = false;

            int status;
            CustomerInfo customerInfo = new CustomerInfo();

            try
            {
                foreach (CustomerSearchRet customerSearchRet in this._customerList)
                {
                    if (customerSearchRet.CustomerCode == customerCode)
                    {
                        check = true;
                        break;
                    }
                }

                if (!check)
                {
                    status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                    if (status == 0)
                    {
                        check = true;
                    }
                }
            }
            catch
            {
                check = false;
            }

            return check;
        }
        // ADD 2009/06/29 ------<<<
        
        // ADD 2009/04/16 ------>>>
        /// <summary>
        /// �L���b�V�����擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�Ƒq�ɂ̖��̂��L���b�V�����B</br>
        /// </remarks>
        private void GetCacheData()
        {
            // ���Ӑ於�̃��X�g�擾
            this.GetCustomerNameList();
            // �q�ɖ��̃��X�g�擾
            this.GetWarehouseNameList();
        }

        /// <summary>
        /// ���Ӑ於�̃��X�g�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ於�̂̃��X�g���擾���܂��B</br>
        /// </remarks>
        private void GetCustomerNameList()
        {
            int status;
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();

            CustomerSearchRet[] customerSearchRetArray;
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;

            this._customerList = new ArrayList();

            status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);
            if (status == 0)
            {
                foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
                {
                    // �_���폜�f�[�^�͓ǂݍ��܂Ȃ�
                    if (customerSearchRet.LogicalDeleteCode != 1)
                    {
                        this._customerList.Add(customerSearchRet);
                    }
                }
            }
        }

        /// <summary>
        /// �q�ɖ��̃��X�g�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �q�ɖ��̃��X�g���擾���܂��B</br>
        /// </remarks>
        private void GetWarehouseNameList()
        {
            int status;
            WarehouseAcs warehouseAcs = new WarehouseAcs();
            ArrayList retList = new ArrayList();

            _warehouseDic = new Dictionary<string, Warehouse>();

            status = warehouseAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (Warehouse warehouse in retList)
                {
                    if (warehouse.LogicalDeleteCode == 0)
                    {
                        if (!_warehouseDic.ContainsKey(warehouse.WarehouseCode.Trim()))
                        {
                            _warehouseDic.Add(warehouse.WarehouseCode.Trim(), warehouse);
                        }
                    }
                }
            }
        }
        // ADD 2009/04/16 ------<<<
                
        #region DEL 2008/06/04 Partsman�p�ɕύX
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //DataTable mainTable     = new DataTable(MAIN_TABLE);    // ���_  // DEL 2008/06/04
            DataTable detailsTable  = new DataTable(DETAILS_TABLE); // �q��

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            mainTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            mainTable.Columns.Add(SECTIONGUIDENM_TITLE, typeof(string));
            mainTable.Columns.Add(MAIN_GUID_KEY, typeof(Guid));
            this.Bind_DataSet.Tables.Add(mainTable);
            detailsTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            detailsTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSECODE_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSENAME_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSENOTE_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSENOTE2_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSENOTE3_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSENOTE4_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSENOTE5_TITLE, typeof(string));
            detailsTable.Columns.Add(DETAILS_GUID_KEY, typeof(Guid));
            this.Bind_DataSet.Tables.Add(detailsTable);
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/04 Partsman�p�ɕύX

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable detailsTable = new DataTable(DETAILS_TABLE); // �q��

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            detailsTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSECODE_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSENAME_TITLE, typeof(string));
            detailsTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            detailsTable.Columns.Add(SECTIONGUIDENM_TITLE, typeof(string));
            detailsTable.Columns.Add(CUSTOMERCODE_TITLE, typeof(string));
            detailsTable.Columns.Add(CUSTOMERNAME_TITLE, typeof(string));
            detailsTable.Columns.Add(MAINMNGWAREHOUSECD_TITLE, typeof(string));
            detailsTable.Columns.Add(MAINMNGWAREHOUSENM_TITLE, typeof(string));
            detailsTable.Columns.Add(STOCKBLNKREMARK_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSENOTE_TITLE, typeof(string));
            detailsTable.Columns.Add(DETAILS_GUID_KEY, typeof(Guid));
            this.Bind_DataSet.Tables.Add(detailsTable);
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void ScreenClear()
        {
            // ���[�h���x��
            this.Mode_Label.Text = INSERT_MODE;

            // �{�^��
            this.Delete_Button.Visible  = true;  // ���S�폜�{�^��
            this.Revive_Button.Visible  = true;  // �����{�^��
            this.Ok_Button.Visible      = true;  // �ۑ��{�^��
            this.Cancel_Button.Visible  = true;  // ����{�^��
            this.Renewal_Button.Visible = true;  // �ŐV���{�^��  // ADD 2009/04/16
            this.Delete_Button.Location = new Point(BUTTON_LOCATION1_X, BUTTON_LOCATION_Y); // ���S�폜�{�^���ʒu
            this.Revive_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // �����{�^���ʒu
            this.Ok_Button.Location     = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // �ۑ��{�^���ʒu
            this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // ����{�^���ʒu

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            SectionGuide_Button.Visible = true;
            CustomerGuide_Button.Visible = true;
            MainMngWarehouseGuide_Button.Visible = true;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            // ���_��
            this.tEdit_SectionCode.Clear();
            this.SectionGuideNm_tEdit.Text = "";
            //this.SectionCode_tEdit.Enabled = false;  // DEL 2008/06/04
            this.tEdit_SectionCode.Enabled = true;  // ADD 2008/06/03
            this.SectionGuideNm_tEdit.Enabled = false;

            // �q�ɕ�
            this.tEdit_WarehouseCode.Clear();
            this.WarehouseCdName_tEdit.Clear();
            this.WarehouseNote1_tEdit.Clear();
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.WarehouseNote2_tEdit.Clear();
            this.WarehouseNote3_tEdit.Clear();
            this.WarehouseNote4_tEdit.Clear();
            this.WarehouseNote5_tEdit.Clear();
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            this.tEdit_WarehouseCode.Enabled = true;
            this.WarehouseCdName_tEdit.Enabled = true;
            this.WarehouseNote1_tEdit.Enabled = true;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.WarehouseNote2_tEdit.Enabled = true;
            this.WarehouseNote3_tEdit.Enabled = true;
            this.WarehouseNote4_tEdit.Enabled = true;
            this.WarehouseNote5_tEdit.Enabled = true;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            this.tNedit_CustomerCode.Clear();
            this.CustomerName_tEdit.Clear();
            this.tEdit_MainMngWarehouseCd.Clear();
            this.MainMngWarehouseNm_tEdit.Clear();
            this.StockBlnktRemark1_tEdit.Clear();
            this.StockBlnktRemark2_tEdit.Clear();
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // UI��ʕ\�����̃`������}����ׂɁA�����ŃT�C�Y���ύX
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName)
            {
                // ���_�e�[�u���̏ꍇ
                case MAIN_TABLE:
                    {
                        break;
                    }
                // �q�Ƀe�[�u���̏ꍇ
                case DETAILS_TABLE:
                    {
                        // �V�K�̏ꍇ
                        if (this._detailsDataIndex < 0)
                        {
                            ScreenInputPermissionControl(3);                        // ��ʓ��͋�����
                            break;
                        }
                        // �폜�̏ꍇ
                        if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][DELETE_DATE_TITLE] != "")
                        {
                            ScreenInputPermissionControl(5);                        // ��ʓ��͋�����
                            break;
                        }
                        // �X�V�̏ꍇ
                        else
                        {
                            ScreenInputPermissionControl(4);                        // ��ʓ��͋�����
                            break;
                        }
                    }
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // �V�K�̏ꍇ
            if (this._dataIndex < 0)
            {
                ScreenInputPermissionControl(3);                        // ��ʓ��͋�����
            }
            else
            {
                // �폜�̏ꍇ
                if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
                {
                    ScreenInputPermissionControl(5);                        // ��ʓ��͋�����
                }
                // �X�V�̏ꍇ
                else
                {
                    ScreenInputPermissionControl(4);                        // ��ʓ��͋�����
                }
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="setType">�ݒ�^�C�v 0:�e-�V�K, 1:�e-�X�V, 2:�e-�폜, 3:�q-�V�K, 4:�q-�X�V, 5:�q-�폜</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            switch (setType)
            {
                // 0:���_-�V�K
                case 0:
                    {
                        break;
                    }
                // 1:���_-�X�V
                case 1:
                    {
                        break;
                    }
                // 2:���_-�폜
                case 2:
                    {
                        break;
                    }
                // 3:�q��-�V�K
                case 3:
                    {
                        // �{�^��
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Renewal_Button.Visible = true;     // ADD 2009/04/16

                        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerGuide_Button.Enabled = true;
                        this.tEdit_MainMngWarehouseCd.Enabled = true;
                        this.MainMngWarehouseGuide_Button.Enabled = true;
                        this.StockBlnktRemark1_tEdit.Enabled = true;
                        this.StockBlnktRemark2_tEdit.Enabled = true;

                        SectionGuide_Button.Visible = true;
                        CustomerGuide_Button.Visible = true;
                        MainMngWarehouseGuide_Button.Visible = true;
                        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                        break;
                    }
                // 4:�q��-�X�V
                case 4:
                    {
                        // �\������
                        this.tEdit_WarehouseCode.Enabled = false;

                        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerGuide_Button.Enabled = true;
                        this.tEdit_MainMngWarehouseCd.Enabled = true;
                        this.MainMngWarehouseGuide_Button.Enabled = true;
                        this.StockBlnktRemark1_tEdit.Enabled = true;
                        this.StockBlnktRemark2_tEdit.Enabled = true;
                        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                        // �{�^��
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;
                        this.Renewal_Button.Visible = true;     // ADD 2009/04/16

                        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                        SectionGuide_Button.Visible = true;
                        CustomerGuide_Button.Visible = true;
                        MainMngWarehouseGuide_Button.Visible = true;
                        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                        break;
                    }
                // 5:�q��-�폜
                case 5:
                    {
                        // �\������
                        this.tEdit_WarehouseCode.Enabled = false;
                        this.WarehouseCdName_tEdit.Enabled = false;
                        this.WarehouseNote1_tEdit.Enabled = false;
                        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                        this.WarehouseNote2_tEdit.Enabled = false;
                        this.WarehouseNote3_tEdit.Enabled = false;
                        this.WarehouseNote4_tEdit.Enabled = false;
                        this.WarehouseNote5_tEdit.Enabled = false;
                           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                        this.tEdit_SectionCode.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_MainMngWarehouseCd.Enabled = false;
                        this.MainMngWarehouseGuide_Button.Enabled = false;
                        this.StockBlnktRemark1_tEdit.Enabled = false;
                        this.StockBlnktRemark2_tEdit.Enabled = false;
                        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                        // �{�^��
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Renewal_Button.Visible = false;    // ADD 2009/04/16
                        this.Delete_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // ���S�폜�{�^���ʒu
                        this.Revive_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // �����{�^���ʒu
                        this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // ����{�^���ʒu

                        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                        SectionGuide_Button.Visible = true;
                        CustomerGuide_Button.Visible = true;
                        MainMngWarehouseGuide_Button.Visible = true;
                        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                        // ���_���_���폜�̏ꍇ�͕����֎~
                        Guid guid = (Guid)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][MAIN_GUID_KEY];
                        SecInfoSet pustSecInfoSet = (SecInfoSet)this._mainTable[guid];
                        if (pustSecInfoSet.LogicalDeleteCode != 0)
                        {
                            this.Revive_Button.Visible = false;
                            this.Delete_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // ���S�폜�{�^���ʒu
                            this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // ����{�^���ʒu
                        }
                           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                        break;
                    }
            }
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName)
            {
                // ���_�e�[�u���̏ꍇ
                case MAIN_TABLE:
                    {
                        break;
                    }
                // �q�Ƀe�[�u���̏ꍇ
                case DETAILS_TABLE:
                    {
                        Warehouse warehouse = new Warehouse();
                        // �V�K�̏ꍇ
                        if (this._detailsDataIndex < 0)
                        {
                            // ��ʓW�J����
                            WarehouseToScreen(warehouse);

                            // �N���[���쐬
                            this._warehouseClone = warehouse.Clone();
                            DispToWarehouse(ref this._warehouseClone);

                            // �t�H�[�J�X�ݒ�
                            this.WarehouseCode_tEdit.Focus();

                            break;
                        }
                        // �폜�̏ꍇ
                        if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][DELETE_DATE_TITLE] != "")
                        {
                            // �폜���[�h
                            this.Mode_Label.Text = DELETE_MODE;

                            // �\�����擾
                            Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][DETAILS_GUID_KEY];
                            warehouse = (Warehouse)this._detailsTable[guid];

                            // ��ʓW�J����
                            WarehouseToScreen(warehouse);

                            break;
                        }
                        // �X�V�̏ꍇ
                        else
                        {
                            // �X�V���[�h
                            this.Mode_Label.Text = UPDATE_MODE;

                            // �\�����擾
                            Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][DETAILS_GUID_KEY];
                            warehouse = (Warehouse)this._detailsTable[guid];

                            // ��ʓW�J����
                            WarehouseToScreen(warehouse);

                            // �N���[���쐬
                            this._warehouseClone = warehouse.Clone();
                            DispToWarehouse(ref this._warehouseClone);

                            // �t�H�[�J�X�ݒ�
                            this.WarehouseCdName_tEdit.SelectAll();

                            break;
                        }
                    }
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            Warehouse warehouse = new Warehouse();
            // �V�K�̏ꍇ
            if (this._dataIndex < 0)
            {
                // ��ʓW�J����
                WarehouseToScreen(warehouse);

                // �N���[���쐬
                this._warehouseClone = warehouse.Clone();
                DispToWarehouse(ref this._warehouseClone);

                // �t�H�[�J�X�ݒ�
                this.tEdit_WarehouseCode.Focus();
            }
            else
            {
                // �폜�̏ꍇ
                if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
                {
                    // �폜���[�h
                    this.Mode_Label.Text = DELETE_MODE;

                    // �\�����擾
                    Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                    warehouse = (Warehouse)this._detailsTable[guid];

                    // ��ʓW�J����
                    WarehouseToScreen(warehouse);
                }
                // �X�V�̏ꍇ
                else
                {
                    // �X�V���[�h
                    this.Mode_Label.Text = UPDATE_MODE;

                    // �\�����擾
                    Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                    warehouse = (Warehouse)this._detailsTable[guid];

                    // ��ʓW�J����
                    WarehouseToScreen(warehouse);

                    // �N���[���쐬
                    this._warehouseClone = warehouse.Clone();
                    DispToWarehouse(ref this._warehouseClone);

                    // �t�H�[�J�X�ݒ�
                    this.WarehouseCdName_tEdit.SelectAll();
                }
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            //_GridIndex�o�b�t�@�ێ�
            this._detailsIndexBuf = this._dataIndex;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._mainIndexBuf = this._mainDataIndex;
            this._targetTableBuf = this._targetTableName;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���_�N���X��ʓW�J����
        /// </summary>
        /// <param name="warehouse">���_�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void SecInfoSetToScreen(SecInfoSet secInfoSet)
        {
            this.SectionCode_tEdit.Text     = secInfoSet.SectionCode;       // ���_�R�[�h
            this.SectionGuideNm_tEdit.Text  = secInfoSet.SectionGuideNm;    // ���_����
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// �q�ɃN���X��ʓW�J����
        /// </summary>
        /// <param name="warehouse">�q�ɃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void WarehouseToScreen(Warehouse warehouse)
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // ���_�R�[�h
            this.SectionCode_tEdit.Text = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE];
            // ���_����
            this.SectionGuideNm_tEdit.Text = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SECTIONGUIDENM_TITLE];
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            this.tEdit_WarehouseCode.Text = warehouse.WarehouseCode.Trim();    // �q�ɃR�[�h
            this.WarehouseCdName_tEdit.Text = warehouse.WarehouseName.Trim();    // �q�ɖ���
            this.WarehouseNote1_tEdit.Text = warehouse.WarehouseNote1.Trim();  // �q�ɔ��l1
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.WarehouseNote2_tEdit.Text = warehouse.WarehouseNote2;  // �q�ɔ��l2
            this.WarehouseNote3_tEdit.Text = warehouse.WarehouseNote3;  // �q�ɔ��l3
            this.WarehouseNote4_tEdit.Text = warehouse.WarehouseNote4;  // �q�ɔ��l4
            this.WarehouseNote5_tEdit.Text = warehouse.WarehouseNote5;  // �q�ɔ��l5
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // ���_�R�[�h
            this.tEdit_SectionCode.DataText = warehouse.SectionCode.Trim();
            // ���_����
            this.SectionGuideNm_tEdit.DataText = GetSectionName(warehouse.SectionCode);

            // ���Ӑ�R�[�h
            this.tNedit_CustomerCode.SetInt(warehouse.CustomerCode);
            // ���Ӑ於��
            this.CustomerName_tEdit.DataText = GetCustomerName(warehouse.CustomerCode);

            // ��Ǒq�ɃR�[�h
            this.tEdit_MainMngWarehouseCd.DataText = warehouse.MainMngWarehouseCd.Trim();
            // ��Ǒq�ɖ���
            this.MainMngWarehouseNm_tEdit.DataText = GetWarehouseName(warehouse.MainMngWarehouseCd);

            // �݌Ɉꊇ���}�[�N
            if (warehouse.StockBlnktRemark.Trim() != "")
            {
                this.StockBlnktRemark1_tEdit.DataText = warehouse.StockBlnktRemark.Substring(0, 3).Trim();
                this.StockBlnktRemark2_tEdit.DataText = warehouse.StockBlnktRemark.Substring(3, 5).Trim();
            }
            else
            {
                this.StockBlnktRemark1_tEdit.DataText = "";
                this.StockBlnktRemark2_tEdit.DataText = "";
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��ʏ�񋒓_�N���X�i�[����
        /// </summary>
        /// <param name="secInfoSet">���_�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void DispToSecInfoSet(ref SecInfoSet secInfoSet)
        {
            secInfoSet.SectionCode      = this.SectionCode_tEdit.Text;      // ���_�R�[�h
            secInfoSet.SectionGuideNm   = this.SectionGuideNm_tEdit.Text;   // ���_����
            secInfoSet.EnterpriseCode   = this._enterpriseCode;             // ��ƃR�[�h
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// ��ʏ��q�ɃN���X�i�[����
        /// </summary>
        /// <param name="warehouse">�q�ɃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�q�ɃI�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void DispToWarehouse(ref Warehouse warehouse)
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            if (Mode_Label.Text == INSERT_MODE)
            {
                // ���_�R�[�h
                warehouse.SectionCode = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE];
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // ��ƃR�[�h
            warehouse.EnterpriseCode = this._enterpriseCode;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName)
            {
                // ���_�e�[�u���̏ꍇ
                case MAIN_TABLE:
                    {
                        break;
                    }
                // �q�Ƀe�[�u���̏ꍇ
                case DETAILS_TABLE:
                    {
                        warehouse.SectionCode   = this.SectionCode_tEdit.Text;
                        warehouse.WarehouseCode = this.WarehouseCode_tEdit.Text;
                        warehouse.WarehouseName = this.WarehouseCdName_tEdit.Text;
                        warehouse.WarehouseNote1 = this.WarehouseNote1_tEdit.Text;
                        warehouse.WarehouseNote2 = this.WarehouseNote2_tEdit.Text;
                        warehouse.WarehouseNote3 = this.WarehouseNote3_tEdit.Text;
                        warehouse.WarehouseNote4 = this.WarehouseNote4_tEdit.Text;
                        warehouse.WarehouseNote5 = this.WarehouseNote5_tEdit.Text;
                        break;
                    }
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            warehouse.SectionCode = this.tEdit_SectionCode.Text;
            warehouse.WarehouseCode = this.tEdit_WarehouseCode.Text;
            warehouse.WarehouseName = this.WarehouseCdName_tEdit.Text;
            warehouse.WarehouseNote1 = this.WarehouseNote1_tEdit.Text;
            warehouse.CustomerCode = this.tNedit_CustomerCode.GetInt();
            warehouse.MainMngWarehouseCd = this.tEdit_MainMngWarehouseCd.DataText.Trim();
            warehouse.StockBlnktRemark = this.StockBlnktRemark1_tEdit.DataText.Trim().PadRight(3, ' ') + this.StockBlnktRemark2_tEdit.DataText.Trim().PadRight(5, ' ');
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note		: ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
           bool result = true;
           
           switch (this._targetTableName)
           {
               // ���_�e�[�u���̏ꍇ
               case MAIN_TABLE:
                   {
                       break;
                   }
               // �q�Ƀe�[�u���̏ꍇ
               case DETAILS_TABLE:
                   {
                       // �q�ɃR�[�h
                       if (this.WarehouseCode_tEdit.Text == "")
                       {
                           control = this.WarehouseCode_tEdit;
                           message = this.WarehouseCode_Title_Label.Text + "����͂��ĉ������B";
                           result = false;
                       }
                       // �q�ɖ���
                       else if (this.WarehouseCdName_tEdit.Text.Trim() == "")
                       {
                           control = this.WarehouseCdName_tEdit;
                           message = this.WarehouseName_Title_Label.Text + "����͂��ĉ������B";
                           result = false;
                       }
                       break;
                   }
           }
              --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // �q�ɃR�[�h
            if (this.tEdit_WarehouseCode.Text == "")
            {
                control = this.tEdit_WarehouseCode;
                message = this.WarehouseCode_Title_Label.Text + "����͂��ĉ������B";
                return (false);
            }
            // �q�ɖ���
            if (this.WarehouseCdName_tEdit.Text.Trim() == "")
            {
                control = this.WarehouseCdName_tEdit;
                message = this.WarehouseName_Title_Label.Text + "����͂��ĉ������B";
                return (false);
            }
            // ���_�R�[�h
            if (this.tEdit_SectionCode.DataText.Trim() == "")
            {
                control = this.tEdit_SectionCode;
                message = this.Section_Title_Label.Text + "����͂��ĉ������B";
                return (false);
            }
            if (GetSectionName(this.tEdit_SectionCode.DataText.Trim()) == "")
            {
                control = this.tEdit_SectionCode;
                message = "�}�X�^�ɓo�^����Ă��܂���B";
                return (false);
            }
            // ���Ӑ�R�[�h
            if (this.tNedit_CustomerCode.DataText.Trim() != "")
            {
                //if (GetCustomerName(this.tNedit_CustomerCode.GetInt()) == "") // DEL 2009/06/29
                if (!CheckCustomer(this.tNedit_CustomerCode.GetInt()))  // ADD 2009/06/29
                {
                    control = this.tNedit_CustomerCode;
                    message = "�}�X�^�ɓo�^����Ă��܂���B";
                    return (false);
                }

                // ADD 2008/10/09 �s��Ή�[6401] ---------->>>>>
                if (this.tEdit_MainMngWarehouseCd.DataText.Trim() == "")
                {
                    control = this.tEdit_MainMngWarehouseCd;
                    message = "��Ǒq�ɂ�ݒ肵�Ă��������B";
                    return (false);
                }
                // ADD 2008/10/09 �s��Ή�[6401] ----------<<<<<
            }
            // ��Ǒq�ɃR�[�h
            if (this.tEdit_MainMngWarehouseCd.DataText.Trim() != "")
            {
                if (GetWarehouseName(this.tEdit_MainMngWarehouseCd.DataText.Trim()) == "")
                {
                    control = this.tEdit_MainMngWarehouseCd;
                    message = "�}�X�^�ɓo�^����Ă��܂���B";
                    return (false);
                }

                // ADD 2008/10/09 �s��Ή�[6401][6402] ---------->>>>>
                if (this.tNedit_CustomerCode.DataText.Trim() == "")
                {
                    control = this.tNedit_CustomerCode;
                    message = "���Ӑ��ݒ肵�Ă��������B";
                    return (false);
                }

                int status = 0;
                ArrayList retList = new ArrayList();
                status = this._warehouseAcs.SearchAll(out retList, this._enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        foreach (Warehouse warehouse in retList)
                        {
                            if (warehouse.WarehouseCode.Trim() == this.tEdit_MainMngWarehouseCd.DataText.Trim())
                            {
                                if (warehouse.MainMngWarehouseCd.Trim() != "")
                                {
                                    control = this.tEdit_MainMngWarehouseCd;
                                    message = "�ϑ��q�ɂ̂��ߐݒ�ł��܂���B";
                                    return (false);
                                }

                                // ADD 2008/12/05 �s��Ή�[8764] ---------->>>>>
                                if (warehouse.LogicalDeleteCode != 0)
                                {
                                    control = this.tEdit_MainMngWarehouseCd;
                                    message = "�폜�ςݑq�ɂ̂��ߐݒ�ł��܂���B";
                                    return (false);
                                }
                                // ADD 2008/12/05 �s��Ή�[8764] ----------<<<<<
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    
                }
                // ADD 2008/10/09 �s��Ή�[6401][6402] ----------<<<<<

            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return (true);
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="saveTarget">�ۑ��}�X�^ (PrdExchPNU/PrdExchPPU)</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�E�q�ɂ̕ۑ��������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        //private bool SaveProc(string saveTarget)  // DEL 2008/06/04
        private bool SaveProc()
        {
            Control control = null;
            string message = null;

            // �s���f�[�^���̓`�F�b�N
            if (!ScreenDataCheck(ref control, ref message))
            {
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

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (saveTarget)
            {
                // ���_�e�[�u���̏ꍇ
                case MAIN_TABLE:
                    {
                        break;
                    }
                // �q�Ƀe�[�u���̏ꍇ
                case DETAILS_TABLE:
                    {
                        // �q�ɍX�V
                        if (!SaveWarehouse())
                        {
                            return false;
                        }
						//----- ueno ---------- start 2007.08.28
						// �t���[���X�V�����͂����ł͕s�v
						//int dataCnt = 0;
                        //DetailsDataSearch(ref dataCnt, 0);
						//----- ueno ---------- end   2007.08.28

                        break;
                    }
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // �q�ɍX�V
            if (!SaveWarehouse())
            {
                return false;
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return true;
        }

        /// <summary>
        /// �q�Ƀe�[�u���X�V
        /// </summary>
        /// <return>�X�V����status</return>
        /// <remarks>
        /// <br>Note       : Warehouse�e�[�u���̍X�V���s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private bool SaveWarehouse()
        {
            Control control = null;
            Warehouse warehouse = new Warehouse();
            //WarehouseWork warehouseWork = new WarehouseWork();  // DEL 2008/06/04

            // �o�^���R�[�h���擾
            if (this._detailsIndexBuf >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                warehouse = ((Warehouse)this._detailsTable[guid]).Clone();
            }

            // SecInfoSet�N���X�Ƀf�[�^���i�[
            DispToWarehouse(ref warehouse);

            // SecInfoSet�N���X���A�N�Z�X�N���X�ɓn���ēo�^�E�X�V
            int status = this._warehouseAcs.Write(ref warehouse);

            // �G���[����
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet/Hash�X�V����
                        DetailsToDataSet(warehouse, this._detailsIndexBuf);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // �d������
                        RepeatTransaction(status, ref control);
                        control.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._warehouseAcs);
                        // UI�q��ʋ����I������
                        EnforcedEndTransaction();
                        return false;
                    }
                default:
                    {
                        // �o�^���s
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "SaveWarehouse",				    // ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._warehouseAcs,				    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        // UI�q��ʋ����I������
                        EnforcedEndTransaction();

                        return false;
                    }
            }

            // �V�K�o�^������
            NewEntryTransaction();

            return true;
        }

        /// <summary>
        /// �q�� �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �q�ɂ̑Ώۃ��R�[�h���}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private int LogicalDeleteWarehouse()
        {
            int status = 0;
            int dummy = 0;

            // �폜�Ώۑq�Ɏ擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            Warehouse warehouse = ((Warehouse)this._detailsTable[guid]).Clone();

            status = this._warehouseAcs.LogicalDelete(ref warehouse);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�X�V�̈�
                        DetailsDataSearch(ref dummy, 0);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, TMsgDisp.OPE_HIDE, this._warehouseAcs);
                        // �t���[���X�V
                        DetailsDataSearch(ref dummy, 0);
                        return status;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "LogicalDeleteWarehouse",	        // ��������
                            TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                            ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._warehouseAcs,			        // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        // �t���[���X�V
                        DetailsDataSearch(ref dummy, 0);
                        return status;
                    }
            }

            return status;
        }

        /// <summary>
        /// �q�� �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �q�ɂ̑Ώۃ��R�[�h���}�X�^���畨���폜���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private int PhysicalDeleteWarehouse()
        {
            int status = 0;
            int dummy = 0;
            Guid guid;

            // �폜�Ώۑq�Ɏ擾
            guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            Warehouse warehouse = ((Warehouse)this._detailsTable[guid]).Clone();

            // �����폜
            status = this._warehouseAcs.Delete(warehouse);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�X�V�̈�
                        DetailsDataSearch(ref dummy, 0);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._warehouseAcs);

                        // UI�q��ʋ����I������
                        EnforcedEndTransaction();

                        return status;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "PhysicalDeleteWarehouse",		    // ��������
                            TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                            ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._warehouseAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        // UI�q��ʋ����I������
                        EnforcedEndTransaction();

                        return status;
                    }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._detailsIndexBuf = -2;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._mainIndexBuf = -2;
            this._targetTableBuf = "";
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

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
        /// ���_ ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �q�ɂ̑Ώۃ��R�[�h�𕜊����܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private int ReviveWarehouse()
        {
            int status = 0;
            Guid guid;

            // �����Ώۑq�Ɏ擾
            guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            Warehouse warehouse = ((Warehouse)this._detailsTable[guid]).Clone();

            // ����
            status = this._warehouseAcs.Revival(ref warehouse);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�W�J����
                        DetailsToDataSet(warehouse, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._warehouseAcs);
                        return status;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "ReviveWarehouse",				    // ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            ERR_RVV_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._warehouseAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
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

            return status;
        }

        /// <summary>
        /// �V�K�o�^������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �V�K�o�^���̏������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            // �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                if (TargetTableName == MAIN_TABLE)
                {
                    // �f�[�^�C���f�b�N�X������������
                    this._mainDataIndex = -1;
                }
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                
                //----- ueno ---------- start 2007.08.28
				// �t���[���X�V
				int dataCnt = 0;
				DetailsDataSearch(ref dataCnt, 0);
				//----- ueno ---------- end   2007.08.28

                // ��ʃN���A����
                ScreenClear();
                // ��ʏ����ݒ菈��
                ScreenInitialSetting();
                // ��ʍč\�z����
                ScreenReconstruction();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this._detailsIndexBuf = -2;
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                this._mainIndexBuf = -2;
                this._targetTableBuf = "";
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                if (CanClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// UI�q��ʋ����I������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V�G���[����UI�q��ʋ����I���������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void EnforcedEndTransaction()
        {
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuf = -2;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._mainIndexBuf = -2;
            this._targetTableBuf = "";
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

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
        /// �d������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̏d���������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
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

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            control = this.tEdit_WarehouseCode;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (TargetTableName)
            {
                // ���_�e�[�u���̏ꍇ
                case MAIN_TABLE:
                    {
                        control = this.SectionCode_tEdit;
                        break;
                    }
                // �q�Ƀe�[�u���̏ꍇ
                case DETAILS_TABLE:
                    {
                        control = this.WarehouseCode_tEdit;
                        break;
                    }
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="operation">�I�y���[�V����</param>
        /// <param name="erObject">�G���[�I�u�W�F�N�g</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
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

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃T�C�Y�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/6/4</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tEdit_WarehouseCode.Size = new System.Drawing.Size(52, 24);
            this.WarehouseCdName_tEdit.Size = new System.Drawing.Size(337, 24);
            this.tEdit_SectionCode.Size = new System.Drawing.Size(36, 24);
            this.SectionGuideNm_tEdit.Size = new System.Drawing.Size(113, 24);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(76, 24);
            this.CustomerName_tEdit.Size = new System.Drawing.Size(322, 24);
            this.tEdit_MainMngWarehouseCd.Size = new System.Drawing.Size(52, 24);
            this.MainMngWarehouseNm_tEdit.Size = new System.Drawing.Size(337, 24);
            this.StockBlnktRemark1_tEdit.Size = new System.Drawing.Size(44, 24);
            this.StockBlnktRemark2_tEdit.Size = new System.Drawing.Size(52, 24);
            this.WarehouseNote1_tEdit.Size = new System.Drawing.Size(639, 24);
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        # endregion

        # region Control Events

        /// <summary>
        /// Form.Load �C�x���g(MAKHN09230U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void MAKHN09230UA_Load(object sender, System.EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;
            this.Renewal_Button.ImageList = imageList16;    // ADD 2009/04/16

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;    // ADD 2009/04/16

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            CustomerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            MainMngWarehouseGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// Form.Closing �C�x���g(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void MAKHN09230UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //this._mainIndexBuf = -2;  // DEL 2008/06/04
            this._detailsIndexBuf = -2;
            //this._targetTableBuf = "";  // DEL 2008/06/04

            // �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Control.VisibleChanged �C�x���g(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void MAKHN09230UA_VisibleChanged(object sender, System.EventArgs e)
        {
            this.Owner.Activate();

            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                return;
            }

            // ��ʃN���A����
            ScreenClear();

            // ��ʏ����ݒ菈��
            ScreenInitialSetting();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                Cursor.Current = Cursors.WaitCursor;// ADD 2009/01/19 �s��Ή�[9896]

                // �o�^����
                //SaveProc(this._targetTableName);  // DEL 2008/06/04
                SaveProc();
            }
            finally
            {
                Cursor.Current = Cursors.Default;   // ADD 2009/01/19 �s��Ή�[9896]
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
			bool cloneFlg = true;

			// �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if (this.Mode_Label.Text != DELETE_MODE)
			{
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
				switch (this._targetTableName)
                {
                    // ���_�e�[�u���̏ꍇ
                    case MAIN_TABLE:
					{
						break;
                    }
                    // �q�Ƀe�[�u���̏ꍇ
                    case DETAILS_TABLE:
                    {
                        // ���݂̉�ʏ����擾
                        Warehouse warehouse = new Warehouse();
                        warehouse = this._warehouseClone.Clone();
                        DispToWarehouse(ref warehouse);
                        // �ŏ��Ɏ擾������ʏ��Ɣ�r
                        cloneFlg = this._warehouseClone.Equals(warehouse);
                        break;
                    }
				}
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                // ���݂̉�ʏ����擾
                Warehouse warehouse = new Warehouse();
                warehouse = this._warehouseClone.Clone();
                DispToWarehouse(ref warehouse);
                // �ŏ��Ɏ擾������ʏ��Ɣ�r
                cloneFlg = this._warehouseClone.Equals(warehouse);
                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

				if(!(cloneFlg))
				{
					// ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
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
                            //if (SaveProc(this._targetTableName))  // DEL 2008/06/04
                            if (SaveProc())
							{
								this.DialogResult = DialogResult.OK;
								break;
							}
							else
							{
								return;
							}
						}
						case DialogResult.No:
						{
							this.DialogResult = DialogResult.Cancel;
							break;
						}
						default:
						{
							// 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                tEdit_WarehouseCode.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
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
			this._detailsIndexBuf = -2;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			this._mainIndexBuf = -2;				   
			this._targetTableBuf = "";
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
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
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// �\������{�^��

            if (result == DialogResult.OK)
            {
                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                // �q�ɕ����폜
                PhysicalDeleteWarehouse();
                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                switch (this._targetTableName)
                {
                    // ���_�e�[�u���̏ꍇ
                    case MAIN_TABLE:
                        {
                            break;
                        }
                    // �q�Ƀe�[�u���̏ꍇ
                    case DETAILS_TABLE:
                        {
                            // �q�ɕ����폜
                            PhysicalDeleteWarehouse();
                            break;
                        }
                }
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // ���_����
            ReviveWarehouse();
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName)
            {
                // ���_�e�[�u���̏ꍇ
                case MAIN_TABLE:
                    {
                        break;
                    }
                // �q�Ƀe�[�u���̏ꍇ
                case DETAILS_TABLE:
                    {
                        // ���_����
                        ReviveWarehouse();
                        break;
                    }
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
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
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionGuideNm_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();

                    this.tNedit_CustomerCode.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// Control.Click �C�x���g(CustomerGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���Ӑ�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if (this._cusotmerGuideSelected == true)
                {
                    this.tEdit_MainMngWarehouseCd.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���Ӑ�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            // ���Ӑ�R�[�h
            this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);
            // ���Ӑ於��
            this.CustomerName_tEdit.DataText = customerSearchRet.Name.Trim();

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// Control.Click �C�x���g(MainMngWarehouseGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ��Ǒq�ɃK�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void MainMngWarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                Warehouse warehouse = new Warehouse();

                status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
                if (status == 0)
                {
                    this.tEdit_MainMngWarehouseCd.DataText = warehouse.WarehouseCode.Trim();
                    this.MainMngWarehouseNm_tEdit.DataText = warehouse.WarehouseName.Trim();

                    this.StockBlnktRemark1_tEdit.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// tArrowKeyControlChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[���̃t�H�[�J�X���ς��^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/06/04</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            _modeFlg = false;
            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_WarehouseCode":
                    {
                        // �q�ɃR�[�h
                        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // �J�ڐ悪����{�^��
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tEdit_WarehouseCode;
                            }
                        }
                        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                        break;
                    }
                case "tEdit_SectionCode":
                    // �Ǘ����_�R�[�h�Ƀt�H�[�J�X������ꍇ
                    if (this.tEdit_SectionCode.DataText.Trim() == "")
                    {
                        this.SectionGuideNm_tEdit.DataText = "";
                        return;
                    }

                    // �Ǘ����_�R�[�h�擾
                    string sectionCode = this.tEdit_SectionCode.DataText;

                    // �Ǘ����_���̎擾
                    this.SectionGuideNm_tEdit.DataText = GetSectionName(sectionCode);

                    if (e.Key == Keys.Enter)
                    {
                        // �t�H�[�J�X�ݒ�
                        if (this.SectionGuideNm_tEdit.DataText.Trim() != "")
                        {
                            e.NextCtrl = this.tNedit_CustomerCode;
                        }
                    }
                    break;
                case "tNedit_CustomerCode":
                    // ���Ӑ�R�[�h�Ƀt�H�[�J�X������ꍇ
                    if (this.tNedit_CustomerCode.DataText.Trim() == "")
                    {
                        this.CustomerName_tEdit.DataText = "";
                        return;
                    }

                    // ���Ӑ�R�[�h�擾
                    int customerCode = this.tNedit_CustomerCode.GetInt();

                    // ���Ӑ於�̎擾
                    this.CustomerName_tEdit.DataText = GetCustomerName(customerCode);

                    if (e.Key == Keys.Enter)
                    {
                        // �t�H�[�J�X�ݒ�
                        //if (this.CustomerName_tEdit.DataText.Trim() != "")    // DEL 2009/06/29
                        if (CheckCustomer(customerCode))    // ADD 2009/06/29
                        {
                            e.NextCtrl = this.tEdit_MainMngWarehouseCd;
                        }
                    }
                    break;
                case "tEdit_MainMngWarehouseCd":
                    // ��Ǒq�ɃR�[�h�Ƀt�H�[�J�X������ꍇ
                    if (this.tEdit_MainMngWarehouseCd.DataText.Trim() == "")
                    {
                        this.MainMngWarehouseNm_tEdit.DataText = "";
                        return;
                    }

                    // ��Ǒq�ɃR�[�h���擾
                    string warehouseCode = this.tEdit_MainMngWarehouseCd.DataText;

                    // ��Ǒq�ɖ��̂���ɂ��܂�
                    this.MainMngWarehouseNm_tEdit.DataText = GetWarehouseName(warehouseCode);

                    if (e.Key == Keys.Enter)
                    {
                        // �t�H�[�J�X�ݒ�
                        if (this.MainMngWarehouseNm_tEdit.DataText.Trim() != "")
                        {
                            e.NextCtrl = this.StockBlnktRemark1_tEdit;
                        }
                    }
                    break;
                case "WarehouseCdName_tEdit":
                    // �q�ɖ��̂Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Down)
                    {
                        // �Ǘ����_�R�[�h�Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = tEdit_SectionCode;
                    }
                    break;
                case "SectionGuide_Button":
                    // �Ǘ����_�K�C�h�{�^���Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Down)
                    {
                        // ���Ӑ�R�[�h�Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = tNedit_CustomerCode;
                    }
                    break;
                case "WarehouseNote1_tEdit":
                    // �q�ɔ��l�Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Up)
                    {
                        // �݌Ɉꊇ���}�[�N�P�Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = StockBlnktRemark1_tEdit;
                    }
                    break;
                default:
                    break;
            }
        }

        private void tEdit_MainMngWarehouseCd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            // ADD 2009/04/16 ------>>>
            _secInfoAcs.ResetSectionInfo();
            GetCacheData();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
            // ADD 2009/04/16 ------<<<
        }
                
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // �q�ɃR�[�h
            string warehouseCode = tEdit_WarehouseCode.Text.TrimEnd().PadLeft(4, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsWarehouseCode = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][WAREHOUSECODE_TITLE];
                if (warehouseCode.Equals(dsWarehouseCode.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][DELETE_DATE_TITLE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̑q�ɐݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // �q�ɃR�[�h�̃N���A
                        tEdit_WarehouseCode.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̑q�ɐݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenInitialSetting();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // �q�ɃR�[�h�̃N���A
                                tEdit_WarehouseCode.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

        # endregion
    }
}
