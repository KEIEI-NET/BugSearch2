//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���[�U�[�K�C�h�ݒ�}�X�^
// �v���O�����T�v   : ���[�U�[�K�C�h�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �O�� �M�j
// �� �� ��  2005/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �O�� �M�j
// �C �� ��  2006/07/24  �C�����e : �t�H�[���v���p�e�B�ݒ�i�u���b�V���A�b�v1-28�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �O�� �M�j
// �C �� ��  2006/07/28  �C�����e : �\�[�X���u���b�V���A�b�v�I
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �s�V �m��
// �C �� ��  2008/10/07  �C�����e : �o�O�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  9807        �쐬�S�� : �E �K�j
// �C �� ��  2009/01/09  �C�����e : �����\���ʒu�̉��Z�R�[�h���폜
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  9995        �쐬�S�� : �E �K�j
// �C �� ��  2008/01/13  �C�����e : �u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  12691       �쐬�S�� : �H���@�b�D
// �C �� ��  2009/03/24  �C�����e : �u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �C �� ��  2010/04/21  �C�����e :  �K�C�h�敪�u�S�U�F��s�v���̓o�^��ʂցu�x�X�R�[�h�v�̒ǉ����s��
//----------------------------------------------------------------------------//
# region using
#define DELETE_DATE_DEPEND_ON_SUB_TABLE // ���C���e�[�u���̍폜�����T�u�e�[�u���Ɋ֘A������t���O

using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Common;
# endregion

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���[�U�[�K�C�h�ݒ� ���̓t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���[�U�[�K�C�h�̐ݒ���s���܂��B
	///					  IMasterMaintenanceArrayType���������Ă��܂��B</br>
	/// <br>Programmer	: 22033 �O��  �M�j</br>
	/// <br>Date		: 2005.05.13</br>
	/// <br>UpdateNote	: 2006.07.24 22033 �O��  �M�j</br>
	/// <br>			: �E�t�H�[���v���p�e�B�ݒ�i�u���b�V���A�b�v1-28�j</br>
	/// <br>UpdateNote	: 2006.07.28 22033 �O��  �M�j</br>
	/// <br>			: �E�\�[�X���u���b�V���A�b�v�I</br>
    /// <br>UpdateNote   : 2008/10/07 30462 �s�V �m���@�o�O�C��</br>
    /// <br>UpdateNote   : 2009/01/09 30414 �E �K�j�@��QID:9807�Ή�</br>
    /// <br>UpdateNote   : 2009/01/13 30414 �E �K�j�@��QID:9995�Ή�</br>
    /// <br>UpdateNote   : 2009/03/24 30434 �H�� �b�D�@��QID:12691�Ή�</br>
    /// <br>UpdateNote   : 2010/04/21 ���` PM1007</br>
    /// <br>             : �K�C�h�敪�u�S�U�F��s�v���̓o�^��ʂցu�x�X�R�[�h�v�̒ǉ����s��</br>
	/// </remarks>
	public class SFCMN09060UA : System.Windows.Forms.Form, IMasterMaintenanceArrayType
	{
		# region region�}�[�N��`����
		//------------------------------//
		//   ���F�啪��					//
		//	 ���F������					//
		//	 ���F������					//
		//	 ���F�G��Ȃ�(;߄t�)��....	//
		//------------------------------//
		# endregion

		# region ��Private Members (Component)

		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Data.DataSet Bind_DataSet;
		private System.Data.DataSet Details_DataSet;
		private Infragistics.Win.Misc.UltraLabel GuideCode_uLabel;
		private Infragistics.Win.Misc.UltraLabel GuideName_uLabel;
		private Infragistics.Win.Misc.UltraLabel GuideType_uLabel;
		private Broadleaf.Library.Windows.Forms.TNedit GuideCode_tNedit;
		private Infragistics.Win.Misc.UltraLabel GuideDivCode_uLabel;
		private Broadleaf.Library.Windows.Forms.TNedit GuideDivCode_tNedit;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Broadleaf.Library.Windows.Forms.TNedit GuideType_tNedit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel17;
		private Broadleaf.Library.Windows.Forms.TEdit GuideName_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit GuideDivName_tEdit;
		private Infragistics.Win.Misc.UltraLabel GuideDivName_uLabel;
        private Infragistics.Win.Misc.UltraLabel BranchCode_ultraLabel;
        private TNedit BranchCode_tNedit;
		private System.ComponentModel.IContainer components;

		# endregion

		# region ��Constructor
		/// <summary>
		/// ���[�U�[�K�C�h�ݒ���̓t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�ݒ���̓t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public SFCMN09060UA()
		{
			// �R���|�[�l���g������
			this.InitializeComponent();
			// �t���[���O���b�hBind�f�[�^�Z�b�g ����\�z����
			this.DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ� -------------------------------------------------------------------------
			this._canPrint					= false;						// ����{�^��
			this._canClose					= true;							// ����{�^��
			this._canNew					= true;							// �V�K�{�^��
			this._canDelete					= true;							// �폜�{�^��
			this._mainGridTitle				= MAINGRID_TITLE;				// �t���[��_MainGrid_Title
			this._detailsGridTitle			= DETAILGRID_TITLE;				// �t���[��_DetailGrid_Title
			this._defaultGridDisplayLayout	= MGridDisplayLayout.Vertical;	// �t���[���O���b�h_DisplayLayout
			//------------------------------------------------------------------------------------------------

			// Private Member������/�擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._targetTableName = "";
			this._mainDataIndex = -1;
			this._detailsDataIndex = -1;
			this._userGuideAcs = new UserGuideAcs();
			this._userGuideHTable = new Hashtable();
			this._userGuideMTable = new Hashtable();
			this._mainIndexBuf = -2;		// -1�͖��I���Ȃ̂�-2�ŏ�����
			this._detailsIndexBuf = -2;		// -1�͖��I���Ȃ̂�-2�ŏ�����	
			this._mainGridIcon = null;		// �O���b�h�A�C�R���͂���Ȃ����ۂ��H
			this._detailsGridIcon = null;	// �O���b�h�A�C�R���͂���Ȃ����ۂ��H
		}
		# endregion

		# region ��Dispose
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		# endregion

		#region ��Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN09060UA));
            this.GuideCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.GuideName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.GuideType_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.GuideCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.GuideDivCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Details_DataSet = new System.Data.DataSet();
            this.Bind_DataSet = new System.Data.DataSet();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.GuideDivCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.GuideType_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.GuideName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GuideDivName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GuideDivName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BranchCode_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BranchCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Details_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideDivCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideType_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideDivName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchCode_tNedit)).BeginInit();
            this.SuspendLayout();
            // 
            // GuideCode_uLabel
            // 
            this.GuideCode_uLabel.Location = new System.Drawing.Point(12, 119);
            this.GuideCode_uLabel.Name = "GuideCode_uLabel";
            this.GuideCode_uLabel.Size = new System.Drawing.Size(104, 23);
            this.GuideCode_uLabel.TabIndex = 0;
            this.GuideCode_uLabel.Text = "�K�C�h�R�[�h";
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 230);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(648, 23);
            this.ultraStatusBar1.TabIndex = 1;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // GuideName_uLabel
            // 
            this.GuideName_uLabel.Location = new System.Drawing.Point(12, 151);
            this.GuideName_uLabel.Name = "GuideName_uLabel";
            this.GuideName_uLabel.Size = new System.Drawing.Size(85, 23);
            this.GuideName_uLabel.TabIndex = 2;
            this.GuideName_uLabel.Text = "�K�C�h��";
            // 
            // GuideType_uLabel
            // 
            this.GuideType_uLabel.Location = new System.Drawing.Point(295, 42);
            this.GuideType_uLabel.Name = "GuideType_uLabel";
            this.GuideType_uLabel.Size = new System.Drawing.Size(64, 23);
            this.GuideType_uLabel.TabIndex = 3;
            this.GuideType_uLabel.Text = "�^�C�v";
            this.GuideType_uLabel.Visible = false;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(535, 8);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 10;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(507, 183);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 8;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(379, 183);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 7;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // GuideCode_tNedit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance12.TextHAlignAsString = "Right";
            this.GuideCode_tNedit.ActiveAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance13.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            appearance13.TextHAlignAsString = "Right";
            this.GuideCode_tNedit.Appearance = appearance13;
            this.GuideCode_tNedit.AutoSelect = true;
            this.GuideCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.GuideCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GuideCode_tNedit.DataText = "";
            this.GuideCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GuideCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.GuideCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GuideCode_tNedit.Location = new System.Drawing.Point(135, 116);
            this.GuideCode_tNedit.MaxLength = 4;
            this.GuideCode_tNedit.Name = "GuideCode_tNedit";
            this.GuideCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.GuideCode_tNedit.Size = new System.Drawing.Size(44, 24);
            this.GuideCode_tNedit.TabIndex = 3;
            // 
            // GuideDivCode_uLabel
            // 
            this.GuideDivCode_uLabel.Location = new System.Drawing.Point(12, 42);
            this.GuideDivCode_uLabel.Name = "GuideDivCode_uLabel";
            this.GuideDivCode_uLabel.Size = new System.Drawing.Size(88, 23);
            this.GuideDivCode_uLabel.TabIndex = 17;
            this.GuideDivCode_uLabel.Text = "�K�C�h�敪";
            // 
            // Details_DataSet
            // 
            this.Details_DataSet.DataSetName = "NewDataSet";
            this.Details_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // GuideDivCode_tNedit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.GuideDivCode_tNedit.ActiveAppearance = appearance10;
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Right";
            this.GuideDivCode_tNedit.Appearance = appearance11;
            this.GuideDivCode_tNedit.AutoSelect = true;
            this.GuideDivCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GuideDivCode_tNedit.DataText = "";
            this.GuideDivCode_tNedit.Enabled = false;
            this.GuideDivCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GuideDivCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.GuideDivCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GuideDivCode_tNedit.Location = new System.Drawing.Point(135, 38);
            this.GuideDivCode_tNedit.MaxLength = 4;
            this.GuideDivCode_tNedit.Name = "GuideDivCode_tNedit";
            this.GuideDivCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.GuideDivCode_tNedit.Size = new System.Drawing.Size(44, 24);
            this.GuideDivCode_tNedit.TabIndex = 0;
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(379, 183);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 7;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(251, 183);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 6;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // GuideType_tNedit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GuideType_tNedit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            this.GuideType_tNedit.Appearance = appearance9;
            this.GuideType_tNedit.AutoSelect = true;
            this.GuideType_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.GuideType_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GuideType_tNedit.DataText = "";
            this.GuideType_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GuideType_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.GuideType_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GuideType_tNedit.Location = new System.Drawing.Point(359, 37);
            this.GuideType_tNedit.MaxLength = 2;
            this.GuideType_tNedit.Name = "GuideType_tNedit";
            this.GuideType_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.GuideType_tNedit.Size = new System.Drawing.Size(28, 24);
            this.GuideType_tNedit.TabIndex = 1;
            this.GuideType_tNedit.Visible = false;
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(12, 105);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(624, 3);
            this.ultraLabel17.TabIndex = 148;
            // 
            // GuideName_tEdit
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GuideName_tEdit.ActiveAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            this.GuideName_tEdit.Appearance = appearance7;
            this.GuideName_tEdit.AutoSelect = true;
            this.GuideName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.GuideName_tEdit.DataText = "";
            this.GuideName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GuideName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GuideName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.GuideName_tEdit.Location = new System.Drawing.Point(135, 148);
            this.GuideName_tEdit.MaxLength = 30;
            this.GuideName_tEdit.Name = "GuideName_tEdit";
            this.GuideName_tEdit.Size = new System.Drawing.Size(496, 24);
            this.GuideName_tEdit.TabIndex = 5;
            // 
            // GuideDivName_tEdit
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GuideDivName_tEdit.ActiveAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.GuideDivName_tEdit.Appearance = appearance5;
            this.GuideDivName_tEdit.AutoSelect = true;
            this.GuideDivName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.GuideDivName_tEdit.DataText = "";
            this.GuideDivName_tEdit.Enabled = false;
            this.GuideDivName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GuideDivName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GuideDivName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.GuideDivName_tEdit.Location = new System.Drawing.Point(135, 71);
            this.GuideDivName_tEdit.MaxLength = 30;
            this.GuideDivName_tEdit.Name = "GuideDivName_tEdit";
            this.GuideDivName_tEdit.Size = new System.Drawing.Size(496, 24);
            this.GuideDivName_tEdit.TabIndex = 2;
            // 
            // GuideDivName_uLabel
            // 
            this.GuideDivName_uLabel.Location = new System.Drawing.Point(12, 75);
            this.GuideDivName_uLabel.Name = "GuideDivName_uLabel";
            this.GuideDivName_uLabel.Size = new System.Drawing.Size(117, 23);
            this.GuideDivName_uLabel.TabIndex = 151;
            this.GuideDivName_uLabel.Text = "�K�C�h�敪��";
            // 
            // BranchCode_ultraLabel
            // 
            this.BranchCode_ultraLabel.Location = new System.Drawing.Point(204, 119);
            this.BranchCode_ultraLabel.Name = "BranchCode_ultraLabel";
            this.BranchCode_ultraLabel.Size = new System.Drawing.Size(85, 23);
            this.BranchCode_ultraLabel.TabIndex = 153;
            this.BranchCode_ultraLabel.Text = "�x�X�R�[�h";
            // 
            // BranchCode_tNedit
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.TextHAlignAsString = "Right";
            this.BranchCode_tNedit.ActiveAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            this.BranchCode_tNedit.Appearance = appearance3;
            this.BranchCode_tNedit.AutoSelect = true;
            this.BranchCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BranchCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.BranchCode_tNedit.DataText = "";
            this.BranchCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BranchCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.BranchCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.BranchCode_tNedit.Location = new System.Drawing.Point(295, 116);
            this.BranchCode_tNedit.MaxLength = 3;
            this.BranchCode_tNedit.Name = "BranchCode_tNedit";
            this.BranchCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.BranchCode_tNedit.Size = new System.Drawing.Size(36, 24);
            this.BranchCode_tNedit.TabIndex = 4;
            // 
            // SFCMN09060UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(648, 253);
            this.Controls.Add(this.BranchCode_tNedit);
            this.Controls.Add(this.BranchCode_ultraLabel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.GuideDivName_tEdit);
            this.Controls.Add(this.GuideDivName_uLabel);
            this.Controls.Add(this.GuideName_tEdit);
            this.Controls.Add(this.GuideType_tNedit);
            this.Controls.Add(this.GuideDivCode_tNedit);
            this.Controls.Add(this.GuideCode_tNedit);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.GuideDivCode_uLabel);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.GuideType_uLabel);
            this.Controls.Add(this.GuideName_uLabel);
            this.Controls.Add(this.GuideCode_uLabel);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFCMN09060UA";
            this.Text = "���[�U�[�K�C�h�ݒ�";
            this.Load += new System.EventHandler(this.SFCMN09060UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFCMN09060UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFCMN09060UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.GuideCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Details_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideDivCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideType_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideDivName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchCode_tNedit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region ��Private Members
		/// <summary>���[�U�[�K�C�h�ݒ� �A�N�Z�X�N���X</summary>
		private UserGuideAcs _userGuideAcs;
		/// <summary>��ƃR�[�h</summary>
		private string _enterpriseCode;
		/// <summary>�t���[��BindDataSet�pHashtable_���[�U�[�K�C�h�i�w�b�_�j</summary>
		private Hashtable _userGuideHTable;
		/// <summary>�t���[��BindDataSet�pHashtable_���[�U�[�K�C�h�i�{�f�B�j</summary>
		/// <remarks>�񋟂ƃ��[�U�[���A�N�Z�X�N���X�Ń}�[�W�ςł��B</remarks>
		private Hashtable _userGuideMTable;
		/// <summary>�ҏW�`�F�b�N�pBuffer</summary>
		private UserGdBd _userGdBdClone;
		/// <summary>�t���[��MainGrid_Index_Buffer�i�t���[���ŏ����Ή��p�j</summary>
		private int _mainIndexBuf;
		/// <summary>�t���[��DetailGrid_Index_Buffer�i�t���[���ŏ����Ή��p�j</summary>
		private int _detailsIndexBuf;

        // 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

		# region ��IMasterMaintenanceArrayType�p

		# region ���v���p�e�B�p
		/// <summary>����{�^��Visible</summary>
		private bool _canPrint;
		/// <summary>����{�^��Visible</summary>
		private bool _canClose;
		/// <summary>�V�K�{�^��Visible</summary>
		private bool _canNew;
		/// <summary>�폜�{�^��Visible</summary>
		private bool _canDelete;
		/// <summary>�t���[��MainGrid�^�C�g��</summary>
		private string _mainGridTitle;
		/// <summary>�t���[��DetailGrid�^�C�g��</summary>
		private string _detailsGridTitle;
		/// <summary>�t���[���I��DataTable��</summary>
		private string _targetTableName;
		# endregion

		# region �����\�b�h�p
		/// <summary>�t���[��MainGrid_Index</summary>
		private int _mainDataIndex;
		/// <summary>�t���[��DetailGrid_Index</summary>
		private int _detailsDataIndex;
		/// <summary>�t���[��MainGrid_Icon</summary>
		private Image _mainGridIcon;
		/// <summary>�t���[��DetailGrid_Icon</summary>
		private Image _detailsGridIcon;
		/// <summary>�t���[��Grid_DisplayLayout</summary>
		private MGridDisplayLayout _defaultGridDisplayLayout;

		# endregion

		# endregion
		
		# endregion

		# region ��Consts

		# region ���t���[���̃O���b�h�^�C�g��
		/// <summary>�t���[��_MainGrid_Title</summary>
		private const string MAINGRID_TITLE	= "�敪";
		/// <summary>�t���[��_DetailGrid_Title</summary>
		private const string DETAILGRID_TITLE = "�R�[�h";
		# endregion

        // --- ADD 2010.04.21 START ���` ---------->>>>>
        /// <summary>���x������:�K�C�h�R�[�h</summary>
        private const string GUIDECODE_ULABEL = "�K�C�h�R�[�h";
        /// <summary>���x������:�K�C�h��</summary>
        private const string GUIDENAME_ULABEL = "�K�C�h��";
        /// <summary>���x������:��s�R�[�h</summary>
        private const string BANKCODE_ULABEL = "��s�R�[�h";
        /// <summary>���x������:��s��</summary>
        private const string BANKNAME_ULABEL = "��s��";
        // --- ADD 2010.04.21 END ���` ----------<<<<<

		# region ���t���[���O���b�h��DataTble����
		/// <summary>�t���[��MainGrid_DataTable����</summary>
		private const string TABLENAME_USERGDHD_TABLE = "USERGDHD";
		/// <summary>�t���[��DetailGrid_DataTable����</summary>
		private const string TABLENAME_USERGDBD_TABLE = "USERGDBD";
		# endregion

		# region ���t���[��Grid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)

		# region ��MainGrid
		/// <summary>�t���[��Grid��_Key_�K�C�h�敪�iMain/Detail���ʁj</summary>
		private const string COLUMNNAME_MD_GUIDEDIVCODE = "�K�C�h�敪";
		/// <summary>�t���[��MainGrid��_Key_�K�C�h�敪����</summary>
		private const string COLUMNNAME_MAIN_GUIDEDIVNAME = "�K�C�h�敪��";
		/// <summary>�t���[��MainGrid��_Key_�}�X�^�񋟋敪�R�[�h</summary>
		private const string COLUMNNAME_MAIN_MASTEROFFERCD = "�}�X�^�񋟋敪�R�[�h";
		/// <summary>�t���[��MainGrid��_Key_�}�X�^�񋟋敪</summary>
		private const string COLUMNNAME_MAIN_MASTEROFFERNM = "�}�X�^�񋟋敪";
		# endregion

		# region ��DetaiGrid
		/// <summary>�t���[��DetailGrid��_Key_�폜��</summary>
		private const string COLUMNNAME_DETAIL_DELETEDATE = "�폜��";
		/// <summary>�t���[��DetailGrid��_Key_�K�C�h�R�[�h</summary>
		private const string COLUMNNAME_DETAIL_GUIDECODE = "�K�C�h�R�[�h";
		/// <summary>�t���[��DetailGrid��_Key_�K�C�h����</summary>
		private const string COLUMNNAME_DETAIL_GUIDENAME = "�K�C�h��";
		/// <summary>�t���[��DetailGrid��_Key_�K�C�h�^�C�v</summary>
		private const string COLUMNNAME_DETAIL_GUIDETYPE = "�K�C�h�^�C�v";
		# endregion

		# endregion

		# region ���ҏW���[�h
		/// <summary>�V�K���[�h</summary>
		private const string INSERT_MODE = "�V�K���[�h";
		/// <summary>�X�V���[�h</summary>
		private const string UPDATE_MODE = "�X�V���[�h";
		/// <summary>�폜���[�h</summary>
		private const string DELETE_MODE = "�폜���[�h";
		/// <summary>�Q�ƃ��[�h</summary>
		private const string REFER_MODE	= "�Q�ƃ��[�h";
		# endregion

		# region �����b�Z�[�W�{�b�N�X�֘A
		/// <summary>�A�Z���u��ID</summary>
		private const string ASSEMBLY_ID = "SFCMN09060U";
		/// <summary>���b�Z�[�W_�G���[_�Ǎ�</summary>
		private const string MSG_ERROR_READ	= "�ǂݍ��݂Ɏ��s���܂����B";
		/// <summary>���b�Z�[�W_�G���[_�d��</summary>
		private const string MSG_ERROR_ST5 = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
		/// <summary>���b�Z�[�W_�G���[_�폜</summary>
		private const string MSG_ERROR_DELETE = "�폜�Ɏ��s���܂����B";
		/// <summary>���b�Z�[�W_�G���[_�X�V</summary>
		private const string MSG_ERROR_UPDATE = "�o�^�Ɏ��s���܂����B";
		/// <summary>���b�Z�[�W_�G���[_����</summary>
		private const string MSG_ERROR_REVIVE = "�����Ɏ��s���܂����B";
		/// <summary>���b�Z�[�W_�G���[_�X�V�i�r���j</summary>
		private const string MSG_ERROR_ST800 = "���ɑ��[�����X�V����Ă��܂�";
		/// <summary>���b�Z�[�W_�G���[_�폜�i�r���j</summary>
		private const string MSG_ERROR_ST801 = "���ɑ��[�����폜����Ă��܂�";
		# endregion

		# endregion

		# region ��Main

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFCMN09060UA());
		}

		# endregion

		# region ��IMasterMaintenanceArrayType�����o�[

		# region ��Propaties
		/// <summary>����\�ݒ�v���p�e�B</summary>
		/// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanPrint
		{
			get{ return this._canPrint; }
		}

		/// <summary>��ʏI���ݒ�v���p�e�B</summary>
		/// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		/// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
		public bool CanClose
		{
			get{ return this._canClose; }
			set{ this._canClose = value; }
		}

		/// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
		/// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanNew
		{
			get{ return this._canNew; }
		}

		/// <summary>�폜�\�ݒ�v���p�e�B</summary>
		/// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanDelete
		{
			get{ return this._canDelete; }
		}

		/// <summary>�O���b�h�̃f�t�H���g�\���ʒu�v���p�e�B</summary>
		/// <value>�O���b�h�̃f�t�H���g�\���ʒu���擾���܂��B</value>
		public MGridDisplayLayout DefaultGridDisplayLayout
		{
			get{ return this._defaultGridDisplayLayout; }
		}

		/// <summary>����Ώۃf�[�^�e�[�u�����̃v���p�e�B</summary>
		/// <value>����Ώۃf�[�^�̃e�[�u�����̂��擾�܂��͐ݒ肵�܂��B</value>
		public string TargetTableName
		{
			get{ return this._targetTableName; }
			set{  this._targetTableName = value; }
		}
		# endregion

		# region ��Events
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region ��Methods

		# region ���{�^��/�O���b�h�ݒ蓙
		/// <summary>
		/// �_���폜�f�[�^���o�\�ݒ胊�X�g�擾����
		/// </summary>
		/// <returns>�_���폜�f�[�^���o�\�ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �_���폜�f�[�^�̒��o���\���ǂ����̐ݒ��z��Ŏ擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public bool[] GetCanLogicalDeleteDataExtractionList()
		{
			bool[] blRet	= new bool[2];
            blRet[0] = true;    // MOD 2008/03/24 �s��Ή�[12691]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� false��true
            blRet[1] = false;   // MOD 2008/03/24 �s��Ή�[12691]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� true��false
			return blRet; 
		}

		/// <summary>
		/// �O���b�h�^�C�g�����X�g�擾����
		/// </summary>
		/// <returns>�O���b�h�^�C�g�����X�g</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h�̃^�C�g����z��Ŏ擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public string[] GetGridTitleList()
		{
			string[] strRet	= new string[2];
			strRet[0]		= this._mainGridTitle;
			strRet[1]		= this._detailsGridTitle;
			return strRet;
		}

		/// <summary>
		/// �O���b�h�A�C�R�����X�g�擾����
		/// </summary>
		/// <returns>�O���b�h�A�C�R�����X�g</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h�̃A�C�R����z��Ŏ擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public Image[] GetGridIconList()
		{
			Image[] objRet	= new Image[2];
			objRet[0]		= this._mainGridIcon;
			objRet[1]		= this._detailsGridIcon;
			return objRet; 
		}

		/// <summary>
		/// �O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g�擾����
		/// </summary>
		/// <returns>�O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l��z��Ŏ擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public bool[] GetDefaultAutoFillToGridColumnList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= true;
			blRet[1]		= true;
			return blRet; 
		}

		/// <summary>
		/// �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g�ݒ菈��
		/// </summary>
		/// <param name="indexList">�f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g��ݒ肵�܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public void SetDataIndexList(int[] indexList)
		{
			int[] intVal			= indexList;
			this._mainDataIndex		= intVal[0];
			this._detailsDataIndex	= intVal[1];
		}

		/// <summary>
		/// �V�K�{�^���̗L���ݒ胊�X�g�擾����
		/// </summary>
		/// <returns>�V�K�{�^���̗L���ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �V�K�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public bool[] GetNewButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= true;

			// ������ �񋟃f�[�^�͐V�K�s�� ������
			if ((this._mainDataIndex >= 0) &&
				((int)this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MAIN_MASTEROFFERCD] == 0))
			{
				blRet[1]		= false;
			}
			else
			{
				blRet[1]		= true;
			}

			return blRet;
		}

		/// <summary>
		/// �C���{�^���̗L���ݒ胊�X�g�擾����
		/// </summary>
		/// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public bool[] GetModifyButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= true;
			return blRet;
		}

		/// <summary>
		/// �폜�{�^���̗L���ݒ胊�X�g�擾����
		/// </summary>
		/// <returns>�폜�{�^���̗L���ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �폜�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public bool[] GetDeleteButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= true;

			// ������ �񋟃f�[�^�͍폜�s�� ������
			if ((this._mainDataIndex >= 0) &&
				((int)this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MAIN_MASTEROFFERCD] == 0))
			{
				blRet[1]		= false;
			}
			else
			{
				blRet[1]		= true;
			}

			return blRet;
		}

		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet"></param>
		/// <param name="tableName"></param>
		/// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
		{
			bindDataSet = this.Bind_DataSet;

			string[] strRet	= new string[2];
			strRet[0]		= TABLENAME_USERGDHD_TABLE;
			strRet[1]		= TABLENAME_USERGDBD_TABLE;
			tableName		= strRet;
		}
		# endregion

		# region ���O���b�h�f�[�^����n
		/// <summary>
		/// ���[�U�[�K�C�h���R�[�h��������
		/// </summary>
		/// <param name="totalCount">���o����</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ���[�U�[�K�C�h�i�w�b�_�j�������[�g�őS���擾���A</br>
		///	<br>			: ���o���ʂ�DataSet�ɓW�J���A���o������Ԃ��܂��B</br>
		/// <br>Programmer	: 22033 �O��  �M�j</br>
		/// <br>Date		: 2005.05.13</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			ArrayList userGuides = null;

			// ���[�U�[�K�C�h�i�w�b�_�j�擾
			int status = this._userGuideAcs.SearchHeader(out userGuides);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					int index = 0;
					// �擾�f�[�^���f�[�^�Z�b�g�ɓW�J
					foreach (UserGdHd userGuide in userGuides)
					{
						// ���[�U�[�K�C�h�i�w�b�_�j�I�u�W�F�N�g �f�[�^�Z�b�g�W�J����
						this.UserGdHdToDataSet(userGuide.Clone(), index);
						++index;
					}
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
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
						MSG_ERROR_READ,						  // �\�����郁�b�Z�[�W 
						status,								  // �X�e�[�^�X�l
						this._userGuideAcs,					  // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				  // �\������{�^��
						MessageBoxDefaultButton.Button1);	  // �����\���{�^��

					break;
				}
			}

			totalCount = userGuides.Count;

            // ���C���e�[�u���̍폜�����T�u�e�[�u������ݒ�
            SetDeleteDateOfMainTable(); // ADD 2009/03/24 �s��Ή�[12691]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

			return status;
		}

		/// <summary>
		/// �l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			// �����Ȃ�
			return 9;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �E���[�U�[�K�C�h�i�{�f�B�j�������[�g�őS���擾���A���ݑI������Ă��郆�[�U�[�K�C�h�i�w�b�_�j��</br>
		///	<br>			:   ���[�U�[�K�C�h�敪�ɊY������f�[�^��DataSet�ɓW�J���܂��B</br>
		/// <br>			: �E���o���ʑS�����L���b�V�����܂��B</br>
		///	<br>			: �E�L���b�V��������ꍇ�͂����炩�猟�����܂��B</br>
		/// <br>Programmer	: 22033 �O��  �M�j</br>
		/// <br>Date		: 2005.05.13</br>
		/// </remarks>
		public int DetailsDataSearch(ref int totalCount, int readCount)
		{
			int status = 0;
			int index = 0;
			ArrayList userGdBd = null;

            // ADD 2009/03/24 �s��Ή�[12691]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // readCount�����̏ꍇ�A�����I��
            if (readCount < 0)
            {
                // ���ݕ\������Ă���Row���N���A
                this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows.Clear();
                return 0;
            }
            // ADD 2009/03/24 �s��Ή�[12691]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

			// ���C���t���[���������UI��ʏI�������pClear����
			this._detailsIndexBuf = -2;

			// �I������Ă��郆�[�U�[�K�C�h�i�w�b�_�j�f�[�^���擾����
			// Key:�K�C�h�敪
			int hashKey = (int)this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE];
			UserGdHd userGdHd = (UserGdHd)this._userGuideHTable[hashKey];

			// ���ݕ\������Ă���Row���N���A
			this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows.Clear();

            // --- �L���b�V�������������ꍇ --- //
			if (this._userGuideMTable.Count == 0)
			{
				// ���o�����s����
				status = this._userGuideAcs.SearchAllBody(
					out userGdBd,
					this._enterpriseCode,
					UserGuideAcsData.OfferDivCodeMergeBodyData);

                // ���[�U�[�K�C�h�̑S�������ʂ�ێ�
                CacheUserGuideBodyList(userGdBd);  // ADD 2009/03/24 �s��Ή�[12691]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						foreach (UserGdBd usergdbd in userGdBd)
						{
							// �L���b�V���ێ� Key:�K�C�h�敪_�K�C�h�R�[�h
							this._userGuideMTable.Add(usergdbd.UserGuideDivCd.ToString() + "_" + usergdbd.GuideCode.ToString() , usergdbd);
						
							// �I�����[�U�[�K�C�h�i�w�b�_�j�̃K�C�h�敪�̏ꍇ
							if (usergdbd.UserGuideDivCd == userGdHd.UserGuideDivCd)
							{
								// ���[�U�[�K�C�h�i�w�b�_�j�I�u�W�F�N�g �f�[�^�Z�b�g�W�J����
								this.UserGdBdToDataSet((UserGdBd)usergdbd.Clone(), index);
								++index;
							}
						}
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						break;
					}
					default:
					{
						TMsgDisp.Show( 
							this,								  // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
							ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
							this.Text,							  // �v���O��������
							"DetailsDataSearch",				  // ��������
							TMsgDisp.OPE_GET,					  // �I�y���[�V����
							MSG_ERROR_READ,						  // �\�����郁�b�Z�[�W 
							status,								  // �X�e�[�^�X�l
							this._userGuideAcs,					  // �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,				  // �\������{�^��
							MessageBoxDefaultButton.Button1);	  // �����\���{�^��

						break;
					}
				}
			}
			// --- �L���b�V������擾 --- //
			else
			{
				Hashtable wkUserGdBdTable = (Hashtable)this._userGuideMTable.Clone();
				SortedList sortList = new SortedList();
				
				foreach (UserGdBd usergdbd in wkUserGdBdTable.Values)
				{
					// �I�����[�U�[�K�C�h�i�w�b�_�j�̃K�C�h�敪�̏ꍇ
					if (usergdbd.UserGuideDivCd == userGdHd.UserGuideDivCd)
					{
						// �K�C�h�R�[�h�Ń\�[�g
						sortList.Add(usergdbd.GuideCode, usergdbd);
					}
				}
					
				// ���בւ��ς݂̃f�[�^��DataSet�ɓW�J
				foreach (UserGdBd usergdbd in sortList.Values)
				{
					// ���[�U�[�K�C�h�i�{�f�B�j�I�u�W�F�N�g �f�[�^�Z�b�g�W�J����
					this.UserGdBdToDataSet((UserGdBd)usergdbd.Clone(), index);
					++index;
				}
			}

			totalCount = index;

            // ���C���e�[�u���̍폜�����T�u�e�[�u������ݒ�
            SetDeleteDateOfMainTable(); // ADD 2009/03/24 �s��Ή�[12691]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

			return status;
		}

		/// <summary>
		/// ���׃l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public int DetailsDataSearchNext(int readCount)
		{
			// ������
			return 9;
		}

		/// <summary>
		/// �f�[�^�_���폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �I�𒆂̃f�[�^��_���폜���܂��B</br>
		/// <br>		   : �t���[���̍폜�{�^�����Ă΂�܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public int Delete()
		{
            // --- ADD 2009/01/13 ��QID:9995�Ή�------------------------------------------------------>>>>>
            int guideDivCode = Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE].ToString());
            int guideCode = Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString());

            if ((guideDivCode == 43) && (guideCode < 20))
            {
                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                    "�񋟃f�[�^�̂��ߍ폜�ł��܂���B",	// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��
                return (-1);
            }
            // --- ADD 2009/01/13 ��QID:9995�Ή�------------------------------------------------------<<<<<

			// Key:�K�C�h�敪_�K�C�h�R�[�h
			string hashKey = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE].ToString()
				+ "_"
                // 2008.11.06 modify start
                // + this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString();
				+ Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString()).ToString();
                // 2008.11.06 modify end
			// �폜�Ώۃf�[�^�擾
			UserGdBd usergdbd = ((UserGdBd)this._userGuideMTable[hashKey]).Clone();

			// �_���폜����
			int status = this._userGuideAcs.LogicalDelete(ref usergdbd);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// �r������
					this.ExclusiveTransaction(status, TMsgDisp.OPE_HIDE, this._userGuideAcs);
					return status;
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
						MSG_ERROR_DELETE,					// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						this._userGuideAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��

					return status;
				}
			}

			// �t���[���̃O���b�h�X�V
			this.UserGdBdToDataSet(usergdbd.Clone(), this._detailsDataIndex);

            // ���[�U�[�K�C�h�̃L���b�V�����������i���C���e�[�u���̍폜���̐ݒ�p�j
            InitializeCacheUserGuideBodyList(); // ADD 2009/03/24 �s��Ή�[12691]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

			return status;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public int Print()
		{
			// ����@�\�����̈ז�����
			return 0;
		}
		# endregion

		# region ���O���b�h�ݒ�
		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public void GetAppearanceTable(out Hashtable[] appearanceTable)
		{
			// --- MainGrid --- //
			Hashtable main = new Hashtable();
            // �폜��
            // ADD 2008/03/24 �s��Ή�[12691]���F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            main.Add(COLUMNNAME_DETAIL_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
			// �K�C�h�敪
			main.Add(COLUMNNAME_MD_GUIDEDIVCODE,	new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
			// �K�C�h�敪����
			main.Add(COLUMNNAME_MAIN_GUIDEDIVNAME,	new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			// �}�X�^�񋟋敪�R�[�h
			main.Add(COLUMNNAME_MAIN_MASTEROFFERCD,	new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			// �}�X�^�񋟋敪����
			main.Add(COLUMNNAME_MAIN_MASTEROFFERNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

			// --- DetailsGrid --- //
			Hashtable details = new Hashtable();
			// �폜��
			details.Add(COLUMNNAME_DETAIL_DELETEDATE,	new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
			// �K�C�h�敪
			details.Add(COLUMNNAME_MD_GUIDEDIVCODE,		new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
			// �K�C�h�R�[�h
			details.Add(COLUMNNAME_DETAIL_GUIDECODE,	new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
			// �K�C�h����
			details.Add(COLUMNNAME_DETAIL_GUIDENAME,	new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			// �K�C�h�^�C�v�i���g�p�j
			details.Add(COLUMNNAME_DETAIL_GUIDETYPE,	new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

			appearanceTable = new Hashtable[2];
			appearanceTable[0] = main;
			appearanceTable[1] = details;
		}
		# endregion

		# endregion

		# endregion

		# region ��Private Methods

		# region ��DataSet�֘A
		/// <summary>
		/// ���[�U�[�K�C�h�i�w�b�_�j�I�u�W�F�N�g �f�[�^�Z�b�g�W�J����
		/// </summary>
		/// <param name="usergdhd">���[�U�[�K�C�h�i�w�b�_�j�I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�f�[�^�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private void UserGdHdToDataSet(UserGdHd usergdhd, int index)
		{
			// �V�K�ǉ����́ADataSet�̍s���ȏ�̓W�JIndex���w�肳��Ă���ꍇ
			if ((index < 0) || (this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].NewRow();
				this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows.Add(dataRow);
				// index���s�̍ŏI�s�ԍ��Ƃ���
				index = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows.Count - 1;
			}

			// --- DataTable�Ƀf�[�^���Z�b�g --- //
            // �폜��
            this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[index][COLUMNNAME_DETAIL_DELETEDATE] = GetDeleteDate(usergdhd);   // ADD 2008/03/24 �s��Ή�[12691]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
			// �K�C�h�敪
			this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[index][COLUMNNAME_MD_GUIDEDIVCODE] = usergdhd.UserGuideDivCd;
			// �K�C�h�敪����
			this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[index][COLUMNNAME_MAIN_GUIDEDIVNAME] = usergdhd.UserGuideDivNm;
			// �}�X�^�񋟋敪�R�[�h
			this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[index][COLUMNNAME_MAIN_MASTEROFFERCD] = usergdhd.MasterOfferCd;
			// �}�X�^�񋟋敪�R�[�h��[0:��]�̏ꍇ
			if (usergdhd.MasterOfferCd == 0)
			{
				this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[index][COLUMNNAME_MAIN_MASTEROFFERNM] = "��";
			}
			// �}�X�^�񋟋敪�R�[�h��[1:������]�̏ꍇ
			else
			{
				this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[index][COLUMNNAME_MAIN_MASTEROFFERNM] = "������";
			}
			
			// �t���[��BindDataSet�pHashtable_���[�U�[�K�C�h�i�w�b�_�j�Ƀf�[�^���Z�b�g
			this._userGuideHTable[usergdhd.UserGuideDivCd] = usergdhd;
		}

        // ADD 2009/03/24 �s��Ή�[12691]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
        /// <summary>
        /// ���C���e�[�u���̍폜�����擾���܂��B
        /// </summary>
        /// <param name="usergdhd"></param>
        /// <returns>�폜���i�폜���ꂽ���R�[�h�ł͖����ꍇ�A<c>string.Empty</c>��Ԃ��܂��B�j</returns>
        private string GetDeleteDate(UserGdHd usergdhd)
        {
            if (usergdhd.LogicalDeleteCode.Equals(0))
            {
                return string.Empty;
            }
            else
            {
                return usergdhd.UpdateDateTimeJpInFormal;
            }
        }

        #region <���[�U�[�K�C�h�̃L���b�V��/>

        /// <summary>���[�U�[�K�C�h�̃L���b�V��</summary>
        /// <remarks>�L�[�F���[�U�[�K�C�h�敪�R�[�h</remarks>
        private readonly IDictionary<int, ArrayList> _userGuideBodyListCacheMap = new Dictionary<int, ArrayList>();
        /// <summary>
        /// ���[�U�[�K�C�h�̃L���b�V�����擾���܂��B
        /// </summary>
        private IDictionary<int, ArrayList> UserGuideBodyListCacheMap
        {
            get { return _userGuideBodyListCacheMap; }
        }

        /// <summary>
        /// ���[�U�[�K�C�h���L���b�V�����܂��B
        /// </summary>
        /// <param name="userGuideBodyList">���[�U�[�K�C�h�̃��R�[�h���X�g</param>
        private void CacheUserGuideBodyList(ArrayList userGuideBodyList)
        {
            if (userGuideBodyList == null) return;

            UserGuideBodyListCacheMap.Clear();
            foreach (DataRow mainRow in this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows)
            {
                // ���[�U�[�K�C�h�敪�R�[�h�ŕ���
                int userGuideDivCd = int.Parse(mainRow[COLUMNNAME_MD_GUIDEDIVCODE].ToString());
                if (!UserGuideBodyListCacheMap.ContainsKey(userGuideDivCd))
                {
                    UserGuideBodyListCacheMap.Add(userGuideDivCd, new ArrayList());
                }
                foreach (UserGdBd userGdBd in userGuideBodyList)
                {
                    if (!userGdBd.UserGuideDivCd.Equals(userGuideDivCd)) continue;

                    UserGuideBodyListCacheMap[userGuideDivCd].Add(userGdBd);
                }
            }
        }

        /// <summary>
        /// ���[�U�[�K�C�h�̃L���b�V�������������܂��B
        /// </summary>
        private void InitializeCacheUserGuideBodyList()
        {
            ArrayList userDgBdList = null;
            int status = this._userGuideAcs.SearchAllBody(
                out userDgBdList,
                this._enterpriseCode,
                UserGuideAcsData.OfferDivCodeMergeBodyData
            );
            CacheUserGuideBodyList(userDgBdList);
        }

        #endregion  // <���[�U�[�K�C�h�̃L���b�V��/>

        /// <summary>
        /// ���C���e�[�u���̍폜����ݒ肵�܂��B
        /// </summary>
        [Conditional("DELETE_DATE_DEPEND_ON_SUB_TABLE")]
        private void SetDeleteDateOfMainTable()
        {
            const string MAIN_TABLE_NAME        = TABLENAME_USERGDHD_TABLE;
            const string RELATION_COLUMN_NAME   = COLUMNNAME_MD_GUIDEDIVCODE;
            const string SUB_TABLE_NAME         = TABLENAME_USERGDBD_TABLE;
            const string DELETE_DATE_COLUMN_NAME= COLUMNNAME_DETAIL_DELETEDATE;

            foreach (DataRow mainRow in this.Bind_DataSet.Tables[MAIN_TABLE_NAME].Rows)
            {
                // �Ή�����T�u�e�[�u���̃��R�[�h�𒊏o
                int relationColumn = (int)mainRow[RELATION_COLUMN_NAME];
                DataRow[] foundSubRows = this.Bind_DataSet.Tables[SUB_TABLE_NAME].Select(
                    RELATION_COLUMN_NAME + "=" + relationColumn.ToString()
                );
                Debug.WriteLine("�֘A = " + relationColumn.ToString() + ":" + foundSubRows.Length.ToString() + "��");

                if (foundSubRows.Length.Equals(0))
                {
                    #region �T�u�e�[�u���ɊY�����R�[�h�������ꍇ�ADB�������ʁi�L���b�V���j���ݒ�

                    // ���[�U�[�K�C�h�敪�R�[�h�w�� ���������i�_���폜�܂ށj
                    ArrayList userDgBdList = null;
                    if (UserGuideBodyListCacheMap.ContainsKey(relationColumn))
                    {
                        userDgBdList = UserGuideBodyListCacheMap[relationColumn];
                    }
                    else
                    {
                        int status = this._userGuideAcs.SearchAllBody(
                            out userDgBdList,
                            this._enterpriseCode,
                            UserGuideAcsData.OfferDivCodeMergeBodyData
                        );
                        CacheUserGuideBodyList(userDgBdList);
                    }
                    if (userDgBdList == null || userDgBdList.Count.Equals(0)) continue;

                    // �폜�����~���Œ��o
                    int deleteRowCount = 0;
                    SortedList<string, string> sortedDeleteDateList = new SortedList<string, string>(
                        new ReverseComparer<string>()
                    );
                    foreach (UserGdBd modelNameU in userDgBdList)
                    {
                        if (modelNameU.LogicalDeleteCode.Equals(0)) continue;

                        deleteRowCount++;
                        if (!sortedDeleteDateList.ContainsKey(modelNameU.UpdateDateTimeJpInFormal))
                        {
                            sortedDeleteDateList.Add(
                                modelNameU.UpdateDateTimeJpInFormal,
                                modelNameU.UpdateDateTimeJpInFormal
                            );
                        }
                    }

                    // ���R�[�h���S���폜����Ă���ꍇ
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(userDgBdList.Count))
                    {
                        deleteDate = sortedDeleteDateList.Values[0];
                    }
                    mainRow[DELETE_DATE_COLUMN_NAME] = deleteDate;

                    #endregion  // �T�u�e�[�u���ɊY�����R�[�h�������ꍇ�ADB�������ʁi�L���b�V���j���ݒ�
                }
                else
                {
                    #region �T�u�e�[�u���ɊY�����R�[�h������ꍇ�A�T�u�e�[�u�����ݒ�

                    // �폜���𒊏o
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
        // ADD 2009/03/24 �s��Ή�[12691]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j�I�u�W�F�N�g �f�[�^�Z�b�g�W�J����
		/// </summary>
		/// <param name="usergdbd">���[�U�[�K�C�h�i�{�f�B�j�I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�f�[�^�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private void UserGdBdToDataSet(UserGdBd usergdbd, int index)
		{
			// �V�K�ǉ����́ADataSet�̍s���ȏ�̓W�JIndex���w�肳��Ă���ꍇ
			if ((index < 0) || (this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].NewRow();
				this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows.Add( dataRow );
				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows.Count - 1;
			}

			// --- DataTable�Ƀf�[�^���Z�b�g --- //
			// �_���폜�敪��0�̏ꍇ
			if (usergdbd.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[index][COLUMNNAME_DETAIL_DELETEDATE] = "";
			}
			else
			{
				// �i�폜�� =�j�X�V���t���Z�b�g
				this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[index][COLUMNNAME_DETAIL_DELETEDATE] = usergdbd.UpdateDateTimeJpInFormal;
			}
			// �K�C�h�敪
			this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[index][COLUMNNAME_MD_GUIDEDIVCODE] = usergdbd.UserGuideDivCd;
			// �K�C�h�R�[�h
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/02 G.Miyatsu ADD
            if ((usergdbd.UserGuideDivCd == 72) || (usergdbd.UserGuideDivCd == 73))
            {
                this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[index][COLUMNNAME_DETAIL_GUIDECODE] = usergdbd.GuideCode;
            }
            // --- ADD 2010.04.21 START ���` ---------->>>>>
            //�K�C�h�敪�u�S�U�F��s�v��
            else if (usergdbd.UserGuideDivCd == 46)
            {
                this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[index][COLUMNNAME_DETAIL_GUIDECODE] = usergdbd.GuideCode.ToString().PadLeft(7, '0');
            }
            // --- ADD 2010.04.21 END ���` ----------<<<<<
            else
            {
                this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[index][COLUMNNAME_DETAIL_GUIDECODE] = usergdbd.GuideCode.ToString().PadLeft(4, '0');
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/02 G.Miyatsu ADD
			// �K�C�h����
			this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[index][COLUMNNAME_DETAIL_GUIDENAME]	= usergdbd.GuideName;
			// �K�C�h�^�C�v�i���g�p�j
			// this.Bind_DataSet.Tables[USERGDBD_TABLE].Rows[index][GUIDETYPE_TITLE] = usergdbd.GuideType;

			// �t���[��BindDataSet�pHashtable_���[�U�[�K�C�h�i�{�f�B�j�Ƀf�[�^���Z�b�g
			string key = usergdbd.UserGuideDivCd.ToString() + "_" + usergdbd.GuideCode.ToString();
			this._userGuideMTable[key] = usergdbd;
		}

		/// <summary>
		/// �t���[���O���b�hBind�f�[�^�Z�b�g ����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			// ���[�U�[�K�C�h�i�w�b�_�j�p�e�[�u��
			DataTable userGdHdTable = new DataTable(TABLENAME_USERGDHD_TABLE);
			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            // ADD 2008/03/24 �s��Ή�[12691]���F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            userGdHdTable.Columns.Add(COLUMNNAME_DETAIL_DELETEDATE, typeof(string));	// �폜��
			userGdHdTable.Columns.Add(COLUMNNAME_MD_GUIDEDIVCODE,		typeof(int));		// �K�C�h�敪
			userGdHdTable.Columns.Add(COLUMNNAME_MAIN_GUIDEDIVNAME,		typeof(string));	// �K�C�h�敪����
			userGdHdTable.Columns.Add(COLUMNNAME_MAIN_MASTEROFFERCD,	typeof(int));		// �}�X�^�񋟋敪�R�[�h
			userGdHdTable.Columns.Add(COLUMNNAME_MAIN_MASTEROFFERNM,	typeof(string));	// �}�X�^�񋟋敪����
			this.Bind_DataSet.Tables.Add(userGdHdTable);

			// ���[�U�[�K�C�h�i�{�f�B�j�p�e�[�u��
			DataTable userGdBdTable = new DataTable(TABLENAME_USERGDBD_TABLE);
			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			userGdBdTable.Columns.Add(COLUMNNAME_DETAIL_DELETEDATE,     typeof(string));	// �폜��
			userGdBdTable.Columns.Add(COLUMNNAME_MD_GUIDEDIVCODE,		typeof(int));		// �K�C�h�敪
            // 2008.11.06 modify start
			//userGdBdTable.Columns.Add(COLUMNNAME_DETAIL_GUIDECODE,		typeof(int));		// �K�C�h�R�[�h
            userGdBdTable.Columns.Add(COLUMNNAME_DETAIL_GUIDECODE, typeof(string));		// �K�C�h�R�[�h
            // 2008.11.06 modify end
			userGdBdTable.Columns.Add(COLUMNNAME_DETAIL_GUIDENAME,		typeof(string));	// �K�C�h����
			userGdBdTable.Columns.Add(COLUMNNAME_DETAIL_GUIDETYPE,		typeof(int));		// �K�C�h�^�C�v
			this.Bind_DataSet.Tables.Add(userGdBdTable);
		}
		# endregion

		# region ����ʑ���
		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private void ScreenClear()
		{
			// �K�C�h�R�[�h
			this.GuideCode_tNedit.Clear();		
            // --- ADD 2010.04.21 START ���` ---------->>>>>
            if (this.GuideDivCode_tNedit.Text.Equals("46"))
            {
                this.BranchCode_tNedit.Clear();
            }
            // --- ADD 2010.04.21 END ���` ----------<<<<<
			// �K�C�h�^�C�v�i�������j
			//this.GuideType_tNedit.Clear();
			// �K�C�h����
			this.GuideName_tEdit.Clear();
			// �K�C�h�敪����
			this.GuideDivName_tEdit.Text = (string)this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MAIN_GUIDEDIVNAME];
			// �K�C�h�敪
			this.GuideDivCode_tNedit.SetInt((int)this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE]);  
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			// �V�K�쐬�̏ꍇ
			if (this._detailsDataIndex < 0)
			{
				# region �� �V�K�쐬������ ��
				// ��ʃN���A����
				this.ScreenClear();
				// �V�K���[�h
				this.Mode_Label.Text = INSERT_MODE;
				// �{�^���ݒ�
				this.Ok_Button.Visible	   = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;
				// ��ʏO�͋����䏈��
				this.ScreenInputPermissionControl(true);
				// �I���K�C�h�敪�Z�b�g
				this.GuideDivCode_tNedit.SetInt((int)this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE]);
                // --- ADD 2010.04.21 START ���` ---------->>>>>
                //�K�C�h�敪�u�S�U�F��s�v��
                if (this.GuideDivCode_tNedit.Text.Equals("46"))
                {
                    //�x�X�R�[�h
                    this.BranchCode_ultraLabel.Visible = true;
                    this.BranchCode_tNedit.Visible = true;
                    //��s�R�[�h
                    this.GuideCode_uLabel.Text = BANKCODE_ULABEL;
                    //��s��
                    this.GuideName_uLabel.Text = BANKNAME_ULABEL;
                }
                else
                {
                    //�x�X�R�[�h
                    this.BranchCode_ultraLabel.Visible = false;
                    this.BranchCode_tNedit.Visible = false;
                    //�K�C�h�R�[�h
                    this.GuideCode_uLabel.Text = GUIDECODE_ULABEL;
                    //�K�C�h��
                    this.GuideName_uLabel.Text = GUIDENAME_ULABEL;
                }
                // --- ADD 2010.04.21 END ���` ----------<<<<<
                // --- �ҏW�`�F�b�N�p�N���[���쐬 --- //
				this._userGdBdClone = new UserGdBd();
				this.DispToUserGdBd(ref this._userGdBdClone);	// ��ʏ��擾����
                                
				// �����t�H�[�J�X�Z�b�g
				this.GuideCode_tNedit.Focus();
				# endregion

                // ADD 2008/10/07 �s��Ή�[6271] ---------->>>>>
                if (this.GuideDivCode_tNedit.Text.Equals("72") ||
                this.GuideDivCode_tNedit.Text.Equals("73"))
                {
                    this.GuideCode_tNedit.MaxLength = 1;
                    //this.GuideCode_tNedit.//TODO
                }
                else
                {
                    this.GuideCode_tNedit.MaxLength = 4;
                }
                // ADD 2008/10/07 �s��Ή�[6271] ----------<<<<<

				return;
			}
			
			// �}�X�^�񋟋敪��[0:��]�̏ꍇ
			if ((int)this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MAIN_MASTEROFFERCD] == 0)
			{
				# region �� �Q�ƃ��[�h������ ��
				// �Q�ƃ��[�h
				this.Mode_Label.Text = REFER_MODE;
				// �{�^���ݒ�
				this.Ok_Button.Visible     = false;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;
				// �Q�ƃf�[�^�擾
				string hashKey = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE].ToString()
					+ "_"
                    // 2008.11.06 modify start
                    // + this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString();
                    + Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString()).ToString();
                    // 2008.11.06 modify end
				UserGdBd userGdBd = (UserGdBd)this._userGuideMTable[hashKey];
				// �擾�f�[�^����ʓW�J
				this.UserGdBdUToScreen(userGdBd);
				// ��ʓ��͋����䏈��
				this.ScreenInputPermissionControl(false);
				// �����t�H�[�J�X�ݒ�
				this.Cancel_Button.Focus();
				# endregion

                // ADD 2008/10/07 �s��Ή�[6271] ---------->>>>>
                if (this.GuideDivCode_tNedit.Text.Equals("72") ||
                this.GuideDivCode_tNedit.Text.Equals("73"))
                {
                    this.GuideCode_tNedit.MaxLength = 1;
                }
                else
                {
                    this.GuideCode_tNedit.MaxLength = 4;
                }
                // ADD 2008/10/07 �s��Ή�[6271] ----------<<<<<

				return;
			}
			
			// �폜��������ꍇ
			if((string)this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_DELETEDATE] != "")
			{
				# region �� �Q�ƃ��[�h������ ��
				// �폜���[�h
				this.Mode_Label.Text = DELETE_MODE;
				// �{�^���ݒ�
				this.Ok_Button.Visible = false;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = true;
				this.Revive_Button.Visible = true;
				// �Ώۃf�[�^�擾
				string hashKey = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE].ToString()
					+ "_"
                    // 2008.11.06 modify start
                    // + this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString();
					+ Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString()).ToString();
                    // 2008.11.06 modify end
				UserGdBd userGdBd = (UserGdBd)this._userGuideMTable[hashKey];
				// �擾�f�[�^����ʂɓW�J
				this.UserGdBdUToScreen(userGdBd);
				// ��ʓ��͋����䏈��
				this.ScreenInputPermissionControl(false);
				// �����t�H�[�J�X
				this.Delete_Button.Focus();
				# endregion
			}
			// �폜���������ꍇ
			else
			{
				# region �� �X�V���[�h������ ��
				// �X�V���[�h
				this.Mode_Label.Text	   = UPDATE_MODE;
				// �{�^���ݒ�
				this.Ok_Button.Visible	   = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;
				// �Ώۃf�[�^�擾
				string hashKey = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE].ToString()
					+ "_"
                    // 2008.11.06 modify start
                    // + this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString();
					+ Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString()).ToString();
                    // 2008.11.06 modify end
				UserGdBd userGdBd = (UserGdBd)this._userGuideMTable[hashKey];
				// �擾�f�[�^����ʂɓW�J
				this.UserGdBdUToScreen(userGdBd);
				// �ҏW�`�F�b�N�p�N���[���쐬
				this._userGdBdClone = userGdBd.Clone(); 
				this.DispToUserGdBd(ref this._userGdBdClone);
				// ��ʓ��͋����䏈��
				this.ScreenInputPermissionControl(true);
				// �ǉ�����
				this.GuideCode_tNedit.Enabled = false;
                // --- ADD 2010.04.21 START ���` ---------->>>>>
                if (this.GuideDivCode_tNedit.Text.Equals("46"))
                {
                    this.BranchCode_tNedit.Enabled = false;
                }
                // --- ADD 2010.04.21 END ���` ----------<<<<<
				// �����t�H�[�J�X�ݒ�
				this.GuideName_tEdit.Focus();
				# endregion
			}

            // ADD 2008/10/07 �s��Ή�[6271] ---------->>>>>
            if (this.GuideDivCode_tNedit.Text.Equals("72") ||
            this.GuideDivCode_tNedit.Text.Equals("73"))
            {
                this.GuideCode_tNedit.MaxLength = 1;
            }
            else
            {
                this.GuideCode_tNedit.MaxLength = 4;
            }
            // ADD 2008/10/07 �s��Ή�[6271] ----------<<<<<

			// �t���[��Grid_Index_Buffer�ێ�
			this._detailsIndexBuf = this._detailsDataIndex;
			this._mainIndexBuf = this._mainDataIndex;
		}

		/// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <param name="enabled">���͋��ݒ�l</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private void ScreenInputPermissionControl(bool enabled)
		{
			// �K�C�h�R�[�h
			this.GuideCode_tNedit.Enabled	= enabled;
			// �K�C�h����
			this.GuideName_tEdit.Enabled	= enabled;
			// �K�C�h�^�C�v�i���g�p�j
			// this.GuideType_tNedit.Enabled	= enabled;
            // --- ADD 2010.04.21 START ���` ---------->>>>>
            if (this.GuideDivCode_tNedit.Text.Equals("46"))
            {
                this.BranchCode_tNedit.Enabled = enabled;
            }
            // --- ADD 2010.04.21 END ���` ----------<<<<<
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j�N���X��ʓW�J����
		/// </summary>
		/// <param name="userGdBd">���[�U�[�K�C�h�i�{�f�B�j�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private void UserGdBdUToScreen(UserGdBd userGdBd)
		{
            if (userGdBd != null)
            {
                // �K�C�h�敪
                this.GuideDivCode_tNedit.SetInt(userGdBd.UserGuideDivCd);
                // �K�C�h�敪����
                this.GuideDivName_tEdit.Text = (string)this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MAIN_GUIDEDIVNAME];
                // �K�C�h�R�[�h
                // --- ADD 2010.04.21 START ���` ---------->>>>>
                //�K�C�h�敪�u�S�U�F��s�v��
                if (this.GuideDivCode_tNedit.Text.Equals("46"))
                {
                    //�x�X�R�[�h
                    this.BranchCode_ultraLabel.Visible = true;
                    this.BranchCode_tNedit.Visible = true;
                    //��s�R�[�h
                    this.GuideCode_uLabel.Text = BANKCODE_ULABEL;
                    //��s��
                    this.GuideName_uLabel.Text = BANKNAME_ULABEL;
                }
                else
                {
                    //�x�X�R�[�h
                    this.BranchCode_ultraLabel.Visible = false;
                    this.BranchCode_tNedit.Visible = false;
                    //�K�C�h�R�[�h
                    this.GuideCode_uLabel.Text = GUIDECODE_ULABEL;
                    //�K�C�h��
                    this.GuideName_uLabel.Text = GUIDENAME_ULABEL;
                }
                // --- ADD 2010.04.21 END ���` ----------<<<<<
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/02 G.Miyatsu ADD
                if (this.GuideDivCode_tNedit.Text.Equals("72") ||
                    this.GuideDivCode_tNedit.Text.Equals("73"))
                {
                    this.GuideCode_tNedit.ExtEdit.AutoWidth = false;
                    this.GuideCode_tNedit.SetInt(userGdBd.GuideCode);
                    this.GuideCode_tNedit.ExtEdit.Column = 1;
                }
                // --- ADD 2010.04.21 START ���` ---------->>>>>
                //�K�C�h�敪�u�S�U�F��s�v��
                else if (this.GuideDivCode_tNedit.Text.Equals("46"))
                {
                    //��s�R�[�h
                    int guideCodeInt = userGdBd.GuideCode / 1000;
                    this.GuideCode_tNedit.Text = guideCodeInt.ToString().PadLeft(4, '0');
                    this.GuideCode_tNedit.ExtEdit.Column = 4;
                    //�x�X�R�[�h
                    int branchCodeInt = userGdBd.GuideCode % 1000;
                    this.BranchCode_tNedit.Text = branchCodeInt.ToString().PadLeft(3, '0');
                    this.BranchCode_tNedit.ExtEdit.Column = 3;
                }
                // --- ADD 2010.04.21 END ���` ----------<<<<<
                else
                {
                    this.GuideCode_tNedit.ExtEdit.AutoWidth = true;
                    this.GuideCode_tNedit.Text = userGdBd.GuideCode.ToString().PadLeft(4, '0');
                    this.GuideCode_tNedit.ExtEdit.Column = 4;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/02 G.Miyatsu ADD
                // �K�C�h����
                this.GuideName_tEdit.Text = userGdBd.GuideName;
                // �K�C�h�^�C�v�i���g�p�j
                // this.GuideType_tNedit.Text = userGdBd.GuideType.ToString();
            }
		}
		# endregion

		# region ����ʏ��擾
		/// <summary>
		/// ��ʏ�񃆁[�U�[�K�C�h�N���X�i�[����
		/// </summary>
		/// <param name="userGdBd">���[�U�[�K�C�h�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂烆�[�U�[�K�C�h�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private void DispToUserGdBd(ref UserGdBd userGdBd)
		{
			if (userGdBd == null)
			{
				// �V�K�̏ꍇ
				userGdBd = new UserGdBd();
			}													  

			// ��ƃR�[�h
			userGdBd.EnterpriseCode	= this._enterpriseCode;
			// �K�C�h�敪
			userGdBd.UserGuideDivCd	= this.GuideDivCode_tNedit.GetInt();
            // --- ADD 2010.04.21 START ���` ---------->>>>>
            //�K�C�h�敪�u�S�U�F��s�v��
            if (this.GuideDivCode_tNedit.Text.Equals("46"))
            {
                // �K�C�h�R�[�h
                userGdBd.GuideCode = this.GuideCode_tNedit.GetInt() * 1000 + this.BranchCode_tNedit.GetInt();
            }
            else
            {
                // �K�C�h�R�[�h
                userGdBd.GuideCode = this.GuideCode_tNedit.GetInt();
            }
            // --- ADD 2010.04.21 END ���` ----------<<<<<
            // --- DEL 2010.04.21 START ���` ---------->>>>>
			// �K�C�h�R�[�h
            //userGdBd.GuideCode = this.GuideCode_tNedit.GetInt();
            // --- DEL 2010.04.21 END ���` ----------<<<<<
			// �K�C�h����
			userGdBd.GuideName		= this.GuideName_tEdit.Text;
			// �K�C�h�^�C�v�i���g�p�j
			// userGdBd.GuideType	= GuideType_tNedit.GetInt();
		}

		/// <summary>
		/// ��ʓ��͏��s���`�F�b�N����
		/// </summary>
		/// <param name="control">�s���ΏۃR���g���[��</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private bool ScreenDataCheck(ref Control control, ref string message)
		{
			bool result = true;

			// �K�C�h�R�[�h�����͂���Ă������ꍇ
            // --- CHG 2009/01/09 ��QID:9807�Ή�------------------------------------------------------>>>>>
            //if (this.GuideCode_tNedit.GetInt() == 0)
            if (this.GuideCode_tNedit.DataText.Trim() == "")
			{
				control = this.GuideCode_tNedit;
				message = this.GuideCode_uLabel.Text + "����͂��ĉ������B";
				result	= false;
			}
            // --- CHG 2009/01/09 ��QID:9807�Ή�------------------------------------------------------<<<<<
            
                // �K�C�h���̂����͂���Ă������ꍇ
			else if (this.GuideName_tEdit.Text == "")
			{
				control = this.GuideName_tEdit;
				message = this.GuideName_uLabel.Text + "����͂��ĉ������B";
				result	= false;	
			}
			
			return result;
		}
		# endregion

		# region ������/�d������
		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <returns>�`�F�b�N����</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[�K�C�h�I�u�W�F�N�g�̕ۑ��������s���܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>
		private bool SaveProc()
		{
			Control control = null;
			string message = null;	

			// ���̓`�F�b�N��NG�̏ꍇ
			if (!ScreenDataCheck(ref control, ref message))
			{
				TMsgDisp.Show( 
					this,								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
					ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
					message,							// �\�����郁�b�Z�[�W 
					0,									// �X�e�[�^�X�l
					MessageBoxButtons.OK);				// �\������{�^��

				control.Focus();
				return false;
			}

			UserGdBd usergdbd = null;
			// �X�V�̏ꍇ
			if (this._detailsDataIndex >= 0)
			{
				// �X�V�Ώۃf�[�^�擾
				string hashKey = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE].ToString()
					+ "_"
					//+ this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString();
                    // 2008.11.06 modify start
                    + Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString()).ToString();
                    // 2008.11.06 modify end
				usergdbd = ((UserGdBd)this._userGuideMTable[hashKey]).Clone();
			}

			// ��ʏ��Ńf�[�^���㏑��
			this.DispToUserGdBd(ref usergdbd);

			// �ۑ�����
			int status = this._userGuideAcs.Write(ref usergdbd);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						MSG_ERROR_ST5,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						MessageBoxButtons.OK);				// �\������{�^��

					// �t�H�[�J�X�ݒ�
					this.GuideCode_tNedit.Focus();
					return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// �r������
					this.ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._userGuideAcs);

					// ���̓t�H�[���I��������
					this.TimeOfFormEndProc(DialogResult.OK, DialogResult.Cancel);
					
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
						MSG_ERROR_UPDATE,					// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						this._userGuideAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��

					// ���̓t�H�[���I��������
					this.TimeOfFormEndProc(DialogResult.OK, DialogResult.Cancel);
				
					return false;
				}
			}

			// �t���[���O���b�h�X�V
			this.UserGdBdToDataSet(usergdbd, this._detailsDataIndex);

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
		/// <br>Programmer : 22033  �O�� �M�j</br>
		/// <br>Date       : 2005.09.21</br>
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
						MSG_ERROR_ST800,					// �\�����郁�b�Z�[�W 
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
						MSG_ERROR_ST801,					// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						erObject,							// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��
					break;
				}
			}
		}

		/// <summary>
		/// ���̓t�H�[���I��������
		/// </summary>
		/// <param name="dRet1">UnDisplaying�p DialogResult</param>
		/// <param name="dRet2">�t�H�[���p DialogResult</param>
		/// <remarks>�C�x���g�p�����[�^��ϐ��̏�������t�H�[���̏�Ԃ�ݒ肵�܂��B</remarks>
		private void TimeOfFormEndProc(DialogResult dRet1, DialogResult dRet2)
		{
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dRet1);
				UnDisplaying(this, me);
			}

			this.DialogResult = dRet2;
			// �t���[���O���b�hIndex_Buffer������
			this._detailsIndexBuf	= -2;
			this._mainIndexBuf		= -2;

			// �t�H�[�������
			if (CanClose)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}
		# endregion

		# endregion

		# region ��Control Events

		# region ���t�H�[���C�x���g
		/// <summary>
		/// Form.Load �C�x���g(SFCMN09060UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>
		private void SFCMN09060UA_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;

			this.Ok_Button.ImageList = imageList24;
			this.Cancel_Button.ImageList = imageList24;
			this.Revive_Button.ImageList = imageList24;
			this.Delete_Button.ImageList = imageList24;

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
		}

		/// <summary>
		/// Form.Closing �C�x���g(SFCMN09060UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>
		private void SFCMN09060UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// �t���[���̍ŏ����Ή�
			this._detailsIndexBuf	= -2;
			this._mainIndexBuf		= -2;

			// �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}	
		}

		/// <summary>
		/// Control.VisibleChanged �C�x���g(SFCMN09060UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>
		private void SFCMN09060UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				this.Owner.Activate();
				return;
			}
			
			if ((this._detailsIndexBuf == this._detailsDataIndex) &&
				(this._mainIndexBuf == this._mainDataIndex))
			{
				return;
			}
			
			this.Initial_Timer.Enabled = true;
			// ��ʃN���A
			this.ScreenClear();
		}
		# endregion

		# region ���{�^���N���b�N�C�x���g
		/// <summary>
		/// Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// ���[�U�[�K�C�h�o�^����
			if (SaveProc() == false)
			{
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			// �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				// �f�[�^�C���f�b�N�X������������
				this._detailsDataIndex = -1;
				// ��ʃN���A
				this.ScreenClear();
				// �N���[�����ēx�擾����
				UserGdBd usergdbd = new UserGdBd();
				//�N���[���쐬
				this._userGdBdClone = usergdbd.Clone(); 
				this.DispToUserGdBd(ref this._userGdBdClone);
				// �V�K���[�h
				this.Mode_Label.Text = INSERT_MODE;
				// �{�^���ݒ�
				this.Ok_Button.Visible	   = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;
				// ��ʓ��͋����䏈��
				this.ScreenInputPermissionControl(true);
				// �����t�H�[�J�X�Z�b�g
				this.GuideCode_tNedit.Focus();
			}
			else
			{
				this.DialogResult = DialogResult.OK;
				this._detailsIndexBuf = -2;
				this._mainIndexBuf = -2;

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
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>		
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if ((this.Mode_Label.Text != DELETE_MODE) &&
				(this.Mode_Label.Text != REFER_MODE))
			{
				// ���݂̉�ʏ����擾
				UserGdBd compareUserGdBd = new UserGdBd();  
				compareUserGdBd = this._userGdBdClone.Clone();  
				this.DispToUserGdBd(ref compareUserGdBd);

				// �ŏ��Ɏ擾������ʏ��Ɣ�r
				if (!(this._userGdBdClone.Equals(compareUserGdBd)))	
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
							// �ۑ�����
							if (!this.SaveProc())
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
							// 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                GuideCode_tNedit.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
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
			this._mainIndexBuf = -2;

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
		/// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
		///					  �X���b�h�Ŏ��s����܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Initial_Timer.Enabled = false;
			this.ScreenReconstruction();		
		}

		/// <summary>
		/// Control.Click �C�x���g(Revive_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			// �Ώۃf�[�^�擾
			string hashKey = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE].ToString()
				+ "_"
                // 2008.11.06 modify start
                // + this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString();
				+ Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString()).ToString();
                // 2008.11.06 modify end
			UserGdBd usergdbd = ((UserGdBd)_userGuideMTable[hashKey]).Clone();

			// ��������
			int status = this._userGuideAcs.Revival(ref usergdbd);
			
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// �r������
					this.ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._userGuideAcs);
					// ���̓t�H�[���I��������
					this.TimeOfFormEndProc(DialogResult.OK, DialogResult.Cancel);

					return;
				}
				default:
				{
					TMsgDisp.Show( 
						this,								  // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
						ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							  // �v���O��������
						"Revive_Button_Click",				  // ��������
						TMsgDisp.OPE_UPDATE,				  // �I�y���[�V����
						MSG_ERROR_REVIVE,					  // �\�����郁�b�Z�[�W 
						status,								  // �X�e�[�^�X�l
						this._userGuideAcs,					  // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				  // �\������{�^��
						MessageBoxDefaultButton.Button1);	  // �����\���{�^��

					// ���̓t�H�[���I��������
					this.TimeOfFormEndProc(DialogResult.OK, DialogResult.Cancel);
					return;
				}
			}

			// �t���[���O���b�h�X�V
			this.UserGdBdToDataSet(usergdbd, this._detailsDataIndex);
			// ���̓t�H�[���I��������
			this.TimeOfFormEndProc(DialogResult.OK, DialogResult.OK);

            // ���[�U�[�K�C�h�̃L���b�V����������
            InitializeCacheUserGuideBodyList(); // ADD 2009/03/24 �s��Ή�[12691]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
		}

		/// <summary>
		/// Control.Click �C�x���g(Delete_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			// �m�F���b�Z�[�W�\��
			DialogResult result = TMsgDisp.Show( 
				this,													// �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_QUESTION,						// �G���[���x��
				ASSEMBLY_ID,											// �A�Z���u���h�c�܂��̓N���X�h�c
				"�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",	// �\�����郁�b�Z�[�W 
				0,														// �X�e�[�^�X�l
				MessageBoxButtons.OKCancel,								// �\������{�^��
				MessageBoxDefaultButton.Button2);						// �����\���{�^��

			if (result == DialogResult.OK)
			{
				// �Ώۃf�[�^�擾
				string hashKey = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE].ToString()
					+ "_"
                    // 2008.11.06 modify start
                    // + this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString();
					+ Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString()).ToString();
                    // 2008.11.06 modify end
				UserGdBd usergdbd = ((UserGdBd)this._userGuideMTable[hashKey]).Clone();

				// �����폜����
				int status = this._userGuideAcs.Delete(usergdbd);
				
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex].Delete();
						this._userGuideMTable.Remove(usergdbd.UserGuideDivCd.ToString() + "_" + usergdbd.GuideCode.ToString());

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// �r������
						this.ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._userGuideAcs);
						// ���̓t�H�[���I��������
						this.TimeOfFormEndProc(DialogResult.OK, DialogResult.Cancel);
					
						return;
					}
					default:
					{
						TMsgDisp.Show( 
							this,								  // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
							ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
							this.Text,							  // �v���O��������
							"Delete_Button_Click",				  // ��������
							TMsgDisp.OPE_DELETE,				  // �I�y���[�V����
							MSG_ERROR_DELETE,					  // �\�����郁�b�Z�[�W 
							status,								  // �X�e�[�^�X�l
							this._userGuideAcs,					  // �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,				  // �\������{�^��
							MessageBoxDefaultButton.Button1);	  // �����\���{�^��

						// ���̓t�H�[���I��������
						this.TimeOfFormEndProc(DialogResult.OK, DialogResult.Cancel);
						return;
					}
				}
			}
			else
			{
				this.Delete_Button.Focus();
				return;
			}

			// ���̓t�H�[���I��������
			this.TimeOfFormEndProc(DialogResult.OK, DialogResult.OK);
		}
		# endregion

        // 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// tArrowKeyControlChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            _modeFlg = false;

            switch (e.PrevCtrl.Name)
            {
                case "GuideCode_tNedit":
                    // �K�C�h�R�[�h�Ƀt�H�[�J�X������ꍇ
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // �J�ڐ悪����{�^��
                        _modeFlg = true;
                    }
                    //else if (this._detailsDataIndex < 0) // DEL 2010.04.21 ���`
                    else if (e.NextCtrl.Name != "BranchCode_tNedit" && this._detailsDataIndex < 0) // ADD 2010.04.21 ���`
                    {
                        if (ModeChangeProc())
                        {
                            e.NextCtrl = GuideCode_tNedit;
                        }
                    }
                    break;
                // --- ADD 2010.04.21 START ���` ---------->>>>>
                case "BranchCode_tNedit":
                    if (this.BranchCode_tNedit.GetInt() == 0)
                    {
                        int branchCodeInt = 0;
                        this.BranchCode_tNedit.Text = branchCodeInt.ToString().PadLeft(3, '0');
                        this.BranchCode_tNedit.ExtEdit.Column = 3;
                    }
                    // �K�C�h�R�[�h�Ƀt�H�[�J�X������ꍇ
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // �J�ڐ悪����{�^��
                        _modeFlg = true;
                    }
                    //else if (this._detailsDataIndex < 0) // DEL 2010.04.21 ���`
                    else if (e.NextCtrl.Name != "GuideCode_tNedit" && this._detailsDataIndex < 0) // ADD 2010.04.21 ���`
                    {
                        if (ModeChangeProc())
                        {
                            e.NextCtrl = GuideCode_tNedit;
                        }
                    }
                    break;
                // --- ADD 2010.04.21 END ���` ----------<<<<<
            }
        }

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // �K�C�h�R�[�h
            string guideCode = GuideCode_tNedit.GetInt().ToString().PadLeft(4, '0');
            // --- ADD 2010.04.21 START ���` ---------->>>>>
            //�K�C�h�敪�u�S�U�F��s�v��
            if (this.GuideDivCode_tNedit.Text.Equals("46"))
            {
                int guideCodeInt = GuideCode_tNedit.GetInt() * 1000 + BranchCode_tNedit.GetInt();
                guideCode = guideCodeInt.ToString().PadLeft(7, '0');
            }
            // --- ADD 2010.04.21 END ���` ----------<<<<<

            for (int i = 0; i < this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsGuideCode = (string)this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[i][COLUMNNAME_DETAIL_GUIDECODE];
                if (guideCode.Equals(dsGuideCode.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[i][COLUMNNAME_DETAIL_DELETEDATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̃��[�U�[�K�C�h�ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // �K�C�h�R�[�h�̃N���A
                        GuideCode_tNedit.Clear();
                        // --- ADD 2010.04.21 START ���` ---------->>>>>
                        //�K�C�h�敪�u�S�U�F��s�v��
                        if (this.GuideDivCode_tNedit.Text.Equals("46"))
                        {
                            BranchCode_tNedit.Clear();
                        }
                        // --- ADD 2010.04.21 END ���` ----------<<<<<
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̃��[�U�[�K�C�h�ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._detailsDataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // �K�C�h�R�[�h�̃N���A
                                GuideCode_tNedit.Clear();
                                //�K�C�h�敪�u�S�U�F��s�v��
                                if (this.GuideDivCode_tNedit.Text.Equals("46"))
                                {
                                    BranchCode_tNedit.Clear();
                                }
                                // --- ADD 2010.04.21 END ���` ----------<<<<<
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

        # endregion
	}
}
