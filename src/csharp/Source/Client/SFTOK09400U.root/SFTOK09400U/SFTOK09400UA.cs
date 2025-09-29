//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���l�ݒ�}�X�^
// �v���O�����T�v   : ���l�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �O�� �M�j
// �� �� ��  2005/10/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �O�� �M�j
// �C �� ��  2006/08/30  �C�����e : ��ʕ\���ʒu�𐳂����C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �i�� �m�q
// �C �� ��  2007/02/27  �C�����e : SF�ł𗬗p���g�єł��쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���X�� ��
// �C �� ��  2007/10/04  �C�����e : �g�єł𗬗p��DC.NS�ł��쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �C �� ��  2008/09/11  �C�����e : �����\���ʒu�̉��Z�R�[�h���폜
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  12690       �쐬�S�� : �H�� �b�D
// �C �� ��  2008/03/24  �C�����e : �u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
//----------------------------------------------------------------------------//
# region ��using
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
	/// ���l�ݒ���̓t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���l�̐ݒ���s���܂��B
	///					 IMasterMaintenanceArrayType���������Ă��܂��B</br>
	/// <br>Programmer : 22033 �O��  �M�j</br>
	/// <br>Date       : 2005.10.14</br>
	/// <br>Update Note: 2006.08.30 22033 �O�� �M�j</br>
    /// <br>			 �E��ʕ\���ʒu�𐳂����C��</br>
    /// <br>Update Note: 2007.02.27 22022 �i�� �m�q</br>
    /// <br>		     �ESF�ł𗬗p���g�єł��쐬</br>
	/// <br>Update Note: 2007.10.04 21024 ���X�� ��</br>
	/// <br>		     �E�g�єł𗬗p��DC.NS�ł��쐬</br>
    /// <br>Update Note: 2008.09.11 30434 �H�� �b�D</br>
    /// <br>		     �E�����\���ʒu�̉��Z�R�[�h���폜</br>
    /// <br>Update Note: 2009.03.24 30434 �H�� �b�D</br>
    /// <br>		     �E�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���</br>
	/// </remarks>
	public class SFTOK09400UA : System.Windows.Forms.Form, IMasterMaintenanceArrayType
	{
		# region ��Private Members (Component)

		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Data.DataSet Bind_DataSet;
		private System.Data.DataSet Details_DataSet;
		private Infragistics.Win.Misc.UltraLabel NoteGuideDivCode_uLabel;
		private Broadleaf.Library.Windows.Forms.TEdit NoteGuideDivName_tEdit;
		private Infragistics.Win.Misc.UltraLabel NoteGuideDivName_uLabel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Broadleaf.Library.Windows.Forms.TEdit NoteGuideName_tEdit;
		private Broadleaf.Library.Windows.Forms.TNedit NoteGuideCode_tNedit;
		private Infragistics.Win.Misc.UltraLabel NoteGuideName_uLabel;
		private Infragistics.Win.Misc.UltraLabel NoteGuideCode_uLabel;
		private Broadleaf.Library.Windows.Forms.TNedit NoteGuideDivCode_tNedit;
		private System.Windows.Forms.Panel Body_Panel;
		private System.Windows.Forms.Panel Button_Panel;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private TMemPos tMemPos;
		private System.ComponentModel.IContainer components;

		# endregion

		# region ��Constructor

		/// <summary>
		/// ���l�ݒ���̓t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���l�ݒ���̓t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public SFTOK09400UA()
		{
			InitializeComponent();

			// �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ�
			this._canPrint					= false;
			this._canClose					= true;
			this._canNew					= true;
			this._canDelete					= true;
			this._mainGridTitle				= "�敪";
			this._detailsGridTitle			= "�R�[�h";
			this._defaultGridDisplayLayout	= MGridDisplayLayout.Vertical;

			// ��ƃR�[�h���擾����
			this._enterpriseCode			= LoginInfoAcquisition.EnterpriseCode;

			// �ϐ�������
			this._targetTableName			= "";
			this._mainDataIndex				= -1;
			this._detailsDataIndex			= -1;
			this._noteGuidAcs				= new NoteGuidAcs();
			this._noteGuideHdTable			= new Hashtable();	  
			this._noteGuideBdTable			= new Hashtable();	  
			//GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			this._detailsIndexBuf			= -2;
			this._mainIndexBuf				= -2;
			this._targetTableBuf			= "";
			this._mainGridIcon				= null;	
			this._detailsGridIcon			= null;	
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFTOK09400UA));
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.NoteGuideDivCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Details_DataSet = new System.Data.DataSet();
            this.Bind_DataSet = new System.Data.DataSet();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.NoteGuideDivName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.NoteGuideDivName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Body_Panel = new System.Windows.Forms.Panel();
            this.NoteGuideName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.NoteGuideCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.NoteGuideName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.NoteGuideCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.NoteGuideDivCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Button_Panel = new System.Windows.Forms.Panel();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.tMemPos = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Details_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteGuideDivName_tEdit)).BeginInit();
            this.Body_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NoteGuideName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteGuideCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteGuideDivCode_tNedit)).BeginInit();
            this.Button_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 231);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(484, 23);
            this.ultraStatusBar1.TabIndex = 1;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(376, 8);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 10;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // NoteGuideDivCode_uLabel
            // 
            this.NoteGuideDivCode_uLabel.Location = new System.Drawing.Point(12, 42);
            this.NoteGuideDivCode_uLabel.Name = "NoteGuideDivCode_uLabel";
            this.NoteGuideDivCode_uLabel.Size = new System.Drawing.Size(88, 23);
            this.NoteGuideDivCode_uLabel.TabIndex = 17;
            this.NoteGuideDivCode_uLabel.Text = "�K�C�h�敪";
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
            // NoteGuideDivName_tEdit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NoteGuideDivName_tEdit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            this.NoteGuideDivName_tEdit.Appearance = appearance9;
            this.NoteGuideDivName_tEdit.AutoSelect = true;
            this.NoteGuideDivName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.NoteGuideDivName_tEdit.DataText = "";
            this.NoteGuideDivName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.NoteGuideDivName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.NoteGuideDivName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.NoteGuideDivName_tEdit.Location = new System.Drawing.Point(135, 71);
            this.NoteGuideDivName_tEdit.MaxLength = 20;
            this.NoteGuideDivName_tEdit.Name = "NoteGuideDivName_tEdit";
            this.NoteGuideDivName_tEdit.Size = new System.Drawing.Size(337, 24);
            this.NoteGuideDivName_tEdit.TabIndex = 152;
            // 
            // NoteGuideDivName_uLabel
            // 
            this.NoteGuideDivName_uLabel.Location = new System.Drawing.Point(12, 75);
            this.NoteGuideDivName_uLabel.Name = "NoteGuideDivName_uLabel";
            this.NoteGuideDivName_uLabel.Size = new System.Drawing.Size(117, 23);
            this.NoteGuideDivName_uLabel.TabIndex = 151;
            this.NoteGuideDivName_uLabel.Text = "�K�C�h�敪��";
            // 
            // Body_Panel
            // 
            this.Body_Panel.Controls.Add(this.NoteGuideName_tEdit);
            this.Body_Panel.Controls.Add(this.NoteGuideCode_tNedit);
            this.Body_Panel.Controls.Add(this.NoteGuideName_uLabel);
            this.Body_Panel.Controls.Add(this.NoteGuideCode_uLabel);
            this.Body_Panel.Controls.Add(this.ultraLabel1);
            this.Body_Panel.Location = new System.Drawing.Point(4, 96);
            this.Body_Panel.Name = "Body_Panel";
            this.Body_Panel.Size = new System.Drawing.Size(476, 80);
            this.Body_Panel.TabIndex = 153;
            // 
            // NoteGuideName_tEdit
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NoteGuideName_tEdit.ActiveAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.NoteGuideName_tEdit.Appearance = appearance5;
            this.NoteGuideName_tEdit.AutoSelect = true;
            this.NoteGuideName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.NoteGuideName_tEdit.DataText = "";
            this.NoteGuideName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.NoteGuideName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.NoteGuideName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.NoteGuideName_tEdit.Location = new System.Drawing.Point(132, 48);
            this.NoteGuideName_tEdit.MaxLength = 20;
            this.NoteGuideName_tEdit.Name = "NoteGuideName_tEdit";
            this.NoteGuideName_tEdit.Size = new System.Drawing.Size(337, 24);
            this.NoteGuideName_tEdit.TabIndex = 152;
            // 
            // NoteGuideCode_tNedit
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance6.TextHAlignAsString = "Right";
            this.NoteGuideCode_tNedit.ActiveAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Right";
            this.NoteGuideCode_tNedit.Appearance = appearance7;
            this.NoteGuideCode_tNedit.AutoSelect = true;
            this.NoteGuideCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.NoteGuideCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.NoteGuideCode_tNedit.DataText = "";
            this.NoteGuideCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.NoteGuideCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.NoteGuideCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.NoteGuideCode_tNedit.Location = new System.Drawing.Point(132, 16);
            this.NoteGuideCode_tNedit.MaxLength = 4;
            this.NoteGuideCode_tNedit.Name = "NoteGuideCode_tNedit";
            this.NoteGuideCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.NoteGuideCode_tNedit.Size = new System.Drawing.Size(44, 24);
            this.NoteGuideCode_tNedit.TabIndex = 151;
            // 
            // NoteGuideName_uLabel
            // 
            this.NoteGuideName_uLabel.Location = new System.Drawing.Point(8, 52);
            this.NoteGuideName_uLabel.Name = "NoteGuideName_uLabel";
            this.NoteGuideName_uLabel.Size = new System.Drawing.Size(85, 23);
            this.NoteGuideName_uLabel.TabIndex = 153;
            this.NoteGuideName_uLabel.Text = "�K�C�h��";
            // 
            // NoteGuideCode_uLabel
            // 
            this.NoteGuideCode_uLabel.Location = new System.Drawing.Point(8, 20);
            this.NoteGuideCode_uLabel.Name = "NoteGuideCode_uLabel";
            this.NoteGuideCode_uLabel.Size = new System.Drawing.Size(104, 23);
            this.NoteGuideCode_uLabel.TabIndex = 150;
            this.NoteGuideCode_uLabel.Text = "�K�C�h�R�[�h";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel1.Location = new System.Drawing.Point(4, 8);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(464, 3);
            this.ultraLabel1.TabIndex = 149;
            // 
            // NoteGuideDivCode_tNedit
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.TextHAlignAsString = "Right";
            this.NoteGuideDivCode_tNedit.ActiveAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            this.NoteGuideDivCode_tNedit.Appearance = appearance3;
            this.NoteGuideDivCode_tNedit.AutoSelect = true;
            this.NoteGuideDivCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.NoteGuideDivCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.NoteGuideDivCode_tNedit.DataText = "";
            this.NoteGuideDivCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.NoteGuideDivCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.NoteGuideDivCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.NoteGuideDivCode_tNedit.Location = new System.Drawing.Point(136, 36);
            this.NoteGuideDivCode_tNedit.MaxLength = 4;
            this.NoteGuideDivCode_tNedit.Name = "NoteGuideDivCode_tNedit";
            this.NoteGuideDivCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.NoteGuideDivCode_tNedit.Size = new System.Drawing.Size(44, 24);
            this.NoteGuideDivCode_tNedit.TabIndex = 154;
            // 
            // Button_Panel
            // 
            this.Button_Panel.Controls.Add(this.Revive_Button);
            this.Button_Panel.Controls.Add(this.Delete_Button);
            this.Button_Panel.Controls.Add(this.Cancel_Button);
            this.Button_Panel.Controls.Add(this.Ok_Button);
            this.Button_Panel.Location = new System.Drawing.Point(92, 180);
            this.Button_Panel.Name = "Button_Panel";
            this.Button_Panel.Size = new System.Drawing.Size(388, 48);
            this.Button_Panel.TabIndex = 155;
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(134, 8);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 6;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(8, 8);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 5;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(260, 8);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 7;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(134, 8);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 4;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // tMemPos
            // 
            this.tMemPos.OwnerForm = this;
            // 
            // SFTOK09400UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(484, 254);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Button_Panel);
            this.Controls.Add(this.NoteGuideDivCode_tNedit);
            this.Controls.Add(this.Body_Panel);
            this.Controls.Add(this.NoteGuideDivName_tEdit);
            this.Controls.Add(this.NoteGuideDivName_uLabel);
            this.Controls.Add(this.NoteGuideDivCode_uLabel);
            this.Controls.Add(this.Mode_Label);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFTOK09400UA";
            this.Text = "���l�ݒ�";
            this.Load += new System.EventHandler(this.SFTOK09400UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFTOK09400UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFTOK09400UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Details_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteGuideDivName_tEdit)).EndInit();
            this.Body_Panel.ResumeLayout(false);
            this.Body_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NoteGuideName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteGuideCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteGuideDivCode_tNedit)).EndInit();
            this.Button_Panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		# region ��Private Members
		private NoteGuidAcs _noteGuidAcs;
		private string _enterpriseCode;
		private Hashtable _noteGuideHdTable;
		private Hashtable _noteGuideBdTable;
		//_GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _detailsIndexBuf;
		private int _mainIndexBuf;
		private string _targetTableBuf;

        // 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

		/// <summary>���̓t�H�[���N�����[�h_�敪</summary>
		private const int DISPMODE_DIV = 0;
		/// <summary>���̓t�H�[���N�����[�h_�R�[�h</summary>
		private const int DISPMODE_CODE = 1;

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
		// Frame��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
		private const string NOTE_GUIDE_DIVCODE_TITLE = "�K�C�h�敪";
        private const string NOTE_GUIDE_DIVNAME_TITLE = "�K�C�h�敪��"; // MOD 2008/10/09 �s��Ή�[6326] "�K�C�h�敪����"��"�K�C�h�敪��"
		private const string NOTE_GUID_HD_TABLE		  = "NOTEGUIDHD";
        private const string NOTE_GUIDE_DIVCODE_FORMAT= "0000";         // ADD 2008/10/09 �s��Ή�[6325]

		private const string DELETEDATE_TITLE		  = "�폜��";
		private const string NOTE_GUIDE_CODE_TITLE	  = "�K�C�h�R�[�h";
        private const string NOTE_GUIDE_NAME_TITLE    = "�K�C�h��";     // MOD 2008/10/09 �s��Ή�[6326] "�K�C�h����"��"�K�C�h��"
		private const string NOTE_GUID_BD_TABLE		  = "NOTEGUIDBD";
        private const string NOTE_GUIDE_CODE_FORMAT   = "0000";         // ADD 2008/10/09 �s��Ή�[6325]

		// �ҏW���[�h
		private const string INSERT_MODE			= "�V�K���[�h";
		private const string UPDATE_MODE			= "�X�V���[�h";
		private const string DELETE_MODE			= "�폜���[�h";

		// ��r�pclone
		private NoteGuidHd _noteGuidHdClone;
		private NoteGuidBd _noteGuidBdClone;

		// Message�֘A��`
		private const string ASSEMBLY_ID	= "SFTOK09400U";
		private const string ERR_READ_MSG	= "�ǂݍ��݂Ɏ��s���܂����B";
		private const string ERR_DPR_MSG	= "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
		private const string ERR_RDEL_MSG	= "�폜�Ɏ��s���܂����B";
		private const string ERR_UPDT_MSG	= "�o�^�Ɏ��s���܂����B";
		private const string ERR_RVV_MSG	= "�����Ɏ��s���܂����B";
		private const string ERR_800_MSG	= "���ɑ��[�����X�V����Ă��܂�";
		private const string ERR_801_MSG	= "���ɑ��[�����폜����Ă��܂�";
		# endregion

		# region ��Main

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main()
		{
			System.Windows.Forms.Application.Run(new SFTOK09400UA());
		}

		# endregion
		
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
		/// <value>�{���Ώۃf�[�^�̃e�[�u�����̂��擾�܂��͐ݒ肵�܂��B</value>
		public string TargetTableName
		{
			get{ return this._targetTableName; }
			set{  this._targetTableName = value; }
		}

		# endregion

		# region ��Public Methods

		/// <summary>
		/// �_���폜�f�[�^���o�\�ݒ胊�X�g�擾����
		/// </summary>
		/// <returns>�_���폜�f�[�^���o�\�ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �_���폜�f�[�^�̒��o���\���ǂ����̐ݒ��z��Ŏ擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public bool[] GetCanLogicalDeleteDataExtractionList()
		{
			bool[] blRet	= new bool[2];
			blRet[0] = true;    // MOD 2009/03/24 �s��Ή�[12690]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� false��true
            blRet[1] = false;   // MOD 2009/03/24 �s��Ή�[12690]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� true��false
			return blRet; 
		}

		/// <summary>
		/// �O���b�h�^�C�g�����X�g�擾����
		/// </summary>
		/// <returns>�O���b�h�^�C�g�����X�g</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h�̃^�C�g����z��Ŏ擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
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
		/// <br>Date       : 2005.10.14</br>
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
		/// <br>Date       : 2005.10.14</br>
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
		/// <br>Date       : 2005.10.14</br>
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
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public bool[] GetNewButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= true;

			return blRet;
		}

		/// <summary>
		/// �C���{�^���̗L���ݒ胊�X�g�擾����
		/// </summary>
		/// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public bool[] GetModifyButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= true;
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
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public bool[] GetDeleteButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= true;

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
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		/// 
		public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
		{
			bindDataSet = this.Bind_DataSet;

			string[] strRet	= new string[2];
			strRet[0]		= NOTE_GUID_HD_TABLE;
			strRet[1]		= NOTE_GUID_BD_TABLE;
			tableName		= strRet;
		}

		/// <summary>
		/// ���l�K�C�h�i�w�b�_�j���R�[�h��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �擪����w�茏�����̔��l�K�C�h�i�w�b�_�j���R�[�h���������A
		///					 ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			ArrayList noteGuidHdList = null;

			int status = this._noteGuidAcs.SearchHeader(out noteGuidHdList, this._enterpriseCode);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					int index = 0;
					foreach (NoteGuidHd noteGuidHd in noteGuidHdList)
					{
						NoteGuidHdToDataSet(noteGuidHd.Clone(), index);
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
						ERR_READ_MSG,						  // �\�����郁�b�Z�[�W 
						status,								  // �X�e�[�^�X�l
						this._noteGuidAcs,					  // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				  // �\������{�^��
						MessageBoxDefaultButton.Button1);	  // �����\���{�^��

					break;
				}
			}

			totalCount = noteGuidHdList.Count;

            // ���C���e�[�u���̍폜�����T�u�e�[�u������ݒ�i���C���e�[�u���̍폜���̐ݒ�p�j
            SetDeleteDateOfMainTable(); // ADD 2009/03/24 �s��Ή�[12690]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

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
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			// �����Ȃ�
			return 9;
		}

		/// <summary>
		/// ���l�K�C�h�i�{�f�B�j���R�[�h��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �擪����w�茏�����̔��l�K�C�h�i�{�f�B�j���R�[�h���������A
		///					 ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public int DetailsDataSearch(ref int totalCount, int readCount)
		{
			ArrayList noteGuidBdList = null;
			string hashKey;

            // ADD 2009/03/24 �s��Ή�[12690]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // readCount�����̏ꍇ�A�����I��
            if (readCount < 0)
            {
                this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows.Clear();
                return 0;
            }
            // ADD 2009/03/24 �s��Ή�[12690]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

			this._detailsIndexBuf = -2;
			this._targetTableBuf  = "";

			// Buffer�������ꍇ�����[�g
			if (this._noteGuideBdTable.Count == 0)
			{
				int status = this._noteGuidAcs.SearchAllBody(out noteGuidBdList, this._enterpriseCode);

                // ���l�K�C�h���L���b�V��
                CacheNoteGuidBdList(noteGuidBdList);    // ADD 2009/03/24 �s��Ή�[12690]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						foreach(NoteGuidBd noteGuidBd in noteGuidBdList)
						{
							hashKey = noteGuidBd.NoteGuideDivCode.ToString() + "_" + noteGuidBd.NoteGuideCode.ToString();
							this._noteGuideBdTable.Add(hashKey, noteGuidBd.Clone());
						}

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						return status;
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
							ERR_READ_MSG,						  // �\�����郁�b�Z�[�W 
							status,								  // �X�e�[�^�X�l
							this._noteGuidAcs,					  // �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,				  // �\������{�^��
							MessageBoxDefaultButton.Button1);	  // �����\���{�^��

						return status;
					}
				}
			}

			this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows.Clear();

			SortedList sortList = new SortedList();
			foreach (NoteGuidBd noteGuidBd in this._noteGuideBdTable.Values)
			{
				if ((int)this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows[this._mainDataIndex][NOTE_GUIDE_DIVCODE_TITLE] == noteGuidBd.NoteGuideDivCode)
				{
					sortList.Add(noteGuidBd.NoteGuideCode, noteGuidBd.Clone());
				}
			}

			int index = 0;
			foreach (NoteGuidBd noteGuidBd in sortList.Values)
			{
				NoteGuidBdToDataSet(noteGuidBd, index);
				++index;
			}

			totalCount = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows.Count;

            // ���C���e�[�u���̍폜�����T�u�e�[�u������ݒ�
            SetDeleteDateOfMainTable(); // ADD 2009/03/24 �s��Ή�[12690]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

			return 0;
		}

		/// <summary>
		/// ���׃l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public int DetailsDataSearchNext(int readCount)
		{
			// ������
			return 9;
		}

		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public int Delete()
		{
			string hashKey = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_DIVCODE_TITLE].ToString()
				+ "_" + this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_CODE_TITLE].ToString();
			NoteGuidBd noteGuidBd = ((NoteGuidBd)this._noteGuideBdTable[hashKey]).Clone();

			int status = this._noteGuidAcs.LogicalDelete(ref noteGuidBd);
			
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status, TMsgDisp.OPE_HIDE, this._noteGuidAcs);
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
						ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						this._noteGuidAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��

					return status;
				}
			}

			NoteGuidBdToDataSet(noteGuidBd.Clone(), this._detailsDataIndex);

            // ���l�K�C�h�̃L���b�V�����������i���C���e�[�u���̍폜���̐ݒ�p�j
            InitializeCacheNoteGuidBdList();    // ADD 2009/03/24 �s��Ή�[12690]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���

			return status;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public int Print()
		{
			// ����@�\�����̈ז�����
			return 0;
		}

		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public void GetAppearanceTable(out Hashtable[] appearanceTable)
		{
			// MainGrid
			Hashtable main = new Hashtable();
            main.Add(DELETEDATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));   // ADD 2009/03/24 �s��Ή�[12690]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            main.Add(NOTE_GUIDE_DIVCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, NOTE_GUIDE_DIVCODE_FORMAT, Color.Black));     // MOD 2008/10/09 �s��Ή�[6325] ""��NOTE_GUIDE_DIVCODE_FORMAT
			main.Add(NOTE_GUIDE_DIVNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft,  "", Color.Black));

			// DetailsGrid
			Hashtable details = new Hashtable();
			details.Add(DELETEDATE_TITLE,		  new GridColAppearance(MGridColDispType.DeletionDataBoth,ContentAlignment.MiddleLeft,"",Color.Red));
            details.Add(NOTE_GUIDE_DIVCODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, NOTE_GUIDE_DIVCODE_FORMAT, Color.Black));  // MOD 2008/10/09 �s��Ή�[6325] ""��NOTE_GUIDE_DIVCODE_FORMAT
			details.Add(NOTE_GUIDE_DIVNAME_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            details.Add(NOTE_GUIDE_CODE_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, NOTE_GUIDE_CODE_FORMAT, Color.Black));     // MOD 2008/10/09 �s��Ή�[6325] ""��NOTE_GUIDE_CODE_FORMAT
			details.Add(NOTE_GUIDE_NAME_TITLE,	  new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft,  "", Color.Black));

			appearanceTable = new Hashtable[2];
			appearanceTable[0] = main;
			appearanceTable[1] = details;
		}

		# endregion

		# endregion

		# region ��Private Methods

		/// <summary>
		/// ���l�I�u�W�F�N�g�f�[�^�Z�b�g�W�J���� (�w�b�_)
		/// </summary>
		/// <param name="noteGuidHd">���l�I�u�W�F�N�g�i�w�b�_�j</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : ���l�f�[�^�N���X�i�w�b�_�j���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void NoteGuidHdToDataSet(NoteGuidHd noteGuidHd, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].NewRow();
				this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows.Count - 1;
			}

			// DataTable�Ƀf�[�^���Z�b�g
            this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows[index][DELETEDATE_TITLE] = GetDeleteDate(noteGuidHd); // ADD 2008/03/24 �s��Ή�[12690]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
			this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows[index][NOTE_GUIDE_DIVCODE_TITLE] = noteGuidHd.NoteGuideDivCode;
			this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows[index][NOTE_GUIDE_DIVNAME_TITLE] = noteGuidHd.NoteGuideDivName;

			int hashKey = noteGuidHd.NoteGuideDivCode;
			// HashTable�Ƀf�[�^���Z�b�g
			if (this._noteGuideHdTable.ContainsKey(hashKey))
			{
				this._noteGuideHdTable.Remove(hashKey);
			}
			this._noteGuideHdTable.Add(hashKey, noteGuidHd);
		}

        // ADD 2009/03/24 �s��Ή�[12690]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
        #region <���l�K�C�h�̃L���b�V��/>

        /// <summary>���l�K�C�h�̃L���b�V��</summary>
        /// <remarks>�L�[�F���l�K�C�h�敪�R�[�h</remarks>
        private readonly IDictionary<int, ArrayList> _noteGuidBdListCacheMap = new Dictionary<int, ArrayList>();
        /// <summary>
        /// ���l�K�C�h�̃L���b�V�����擾���܂��B
        /// </summary>
        private IDictionary<int, ArrayList> NoteGuidBdListCacheMap
        {
            get { return _noteGuidBdListCacheMap; }
        }

        /// <summary>
        /// ���l�K�C�h���L���b�V�����܂��B
        /// </summary>
        /// <param name="allNoteGuidBdList">�S���l�K�C�h�̃��R�[�h���X�g</param>
        private void CacheNoteGuidBdList(ArrayList allNoteGuidBdList)
        {
            if (allNoteGuidBdList == null) return;

            // ���l�K�C�h�敪�R�[�h�ʂɕ���
            NoteGuidBdListCacheMap.Clear();
            foreach (NoteGuidBd noteGuidBd in allNoteGuidBdList)
            {
                int noteGuideDivCode = noteGuidBd.NoteGuideDivCode;
                if (!NoteGuidBdListCacheMap.ContainsKey(noteGuideDivCode))
                {
                    NoteGuidBdListCacheMap.Add(noteGuideDivCode, new ArrayList());
                }
                NoteGuidBdListCacheMap[noteGuideDivCode].Add(noteGuidBd);
            }
        }

        /// <summary>
        /// ���l�K�C�h�̃L���b�V�������������܂��B
        /// </summary>
        private void InitializeCacheNoteGuidBdList()
        {
            ArrayList noteGuidBdList = null;
            int status = this._noteGuidAcs.SearchAllBody(out noteGuidBdList, this._enterpriseCode);
            CacheNoteGuidBdList(noteGuidBdList);
        }

        #endregion  // <���l�K�C�h�̃L���b�V��/>

        /// <summary>
        /// ���C���e�[�u���̍폜�����擾���܂��B
        /// </summary>
        /// <param name="noteGuidHd"></param>
        /// <returns>�폜���i�폜���ꂽ���R�[�h�ł͖����ꍇ�A<c>string.Empty</c>��Ԃ��܂��B�j</returns>
        private string GetDeleteDate(NoteGuidHd noteGuidHd)
        {
            if (noteGuidHd.LogicalDeleteCode.Equals(0))
            {
                return string.Empty;
            }
            else
            {
                return noteGuidHd.UpdateDateTimeJpInFormal;
            }
        }

        /// <summary>
        /// ���C���e�[�u���̍폜����ݒ肵�܂��B
        /// </summary>
        [Conditional("DELETE_DATE_DEPEND_ON_SUB_TABLE")]
        private void SetDeleteDateOfMainTable()
        {
            const string MAIN_TABLE_NAME        = NOTE_GUID_HD_TABLE;
            const string RELATION_COLUMN_NAME   = NOTE_GUIDE_DIVCODE_TITLE;
            const string SUB_TABLE_NAME         = NOTE_GUID_BD_TABLE;
            const string DELETE_DATE_COLUMN_NAME= DELETEDATE_TITLE;

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

                    // ���l�K�C�h�敪�R�[�h�w�� �Ԏ햼�̌��������i�_���폜�܂ށj
                    ArrayList noteGuidBdList = null;
                    if (NoteGuidBdListCacheMap.ContainsKey(relationColumn))
                    {
                        noteGuidBdList = NoteGuidBdListCacheMap[relationColumn];
                    }
                    else
                    {
                        int status = this._noteGuidAcs.SearchAllBody(out noteGuidBdList, this._enterpriseCode);
                        CacheNoteGuidBdList(noteGuidBdList);
                    }
                    if (noteGuidBdList == null || noteGuidBdList.Count.Equals(0)) continue;

                    // �폜�����~���Œ��o
                    int deleteRowCount = 0;
                    SortedList<string, string> sortedDeleteDateList = new SortedList<string, string>(
                        new ReverseComparer<string>()
                    );
                    foreach (NoteGuidBd noteGuidBd in noteGuidBdList)
                    {
                        if (noteGuidBd.LogicalDeleteCode.Equals(0)) continue;

                        deleteRowCount++;
                        if (!sortedDeleteDateList.ContainsKey(noteGuidBd.UpdateDateTimeJpInFormal))
                        {
                            sortedDeleteDateList.Add(
                                noteGuidBd.UpdateDateTimeJpInFormal,
                                noteGuidBd.UpdateDateTimeJpInFormal
                            );
                        }
                    }

                    // ���R�[�h���S���폜����Ă���ꍇ
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(noteGuidBdList.Count))
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
                    mainRow[DELETEDATE_TITLE] = deleteDate;

                    #endregion  // �T�u�e�[�u���ɊY�����R�[�h������ꍇ�A�T�u�e�[�u�����ݒ�
                }
            }
        }
        // ADD 2009/03/24 �s��Ή�[12690]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

		/// <summary>
		/// ���l�I�u�W�F�N�g�f�[�^�Z�b�g�W�J���� (�{�f�B)
		/// </summary>
		/// <param name="noteGuidBd">���l�I�u�W�F�N�g�i�{�f�B�j</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : ���l�f�[�^�N���X�i�{�f�B�j���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void NoteGuidBdToDataSet(NoteGuidBd noteGuidBd, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].NewRow();
				this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows.Count - 1;
			}

			// DataTable�Ƀf�[�^���Z�b�g
			if (noteGuidBd.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[index][DELETEDATE_TITLE] = "";
			}
			else
			{
				this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[index][DELETEDATE_TITLE] = noteGuidBd.UpdateDateTimeJpInFormal;
			}
		
			this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[index][NOTE_GUIDE_DIVCODE_TITLE] = noteGuidBd.NoteGuideDivCode;
			this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[index][NOTE_GUIDE_NAME_TITLE]	   = noteGuidBd.NoteGuideDivName;
			this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[index][NOTE_GUIDE_CODE_TITLE]	   = noteGuidBd.NoteGuideCode;
			this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[index][NOTE_GUIDE_NAME_TITLE]	   = noteGuidBd.NoteGuideName;

			string hashKey = noteGuidBd.NoteGuideDivCode.ToString() 
				+ "_" + noteGuidBd.NoteGuideCode.ToString();

			// HashTable�X�V
			this._noteGuideBdTable[hashKey] = noteGuidBd;
		}

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			// �w�b�_���R�[�h�p�e�[�u��
			DataTable noteGuideHdTable = new DataTable(NOTE_GUID_HD_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            noteGuideHdTable.Columns.Add(DELETEDATE_TITLE, typeof(string)); // ADD 2008/03/24 �s��Ή�[12690]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
			noteGuideHdTable.Columns.Add(NOTE_GUIDE_DIVCODE_TITLE, typeof(int));
			noteGuideHdTable.Columns.Add(NOTE_GUIDE_DIVNAME_TITLE, typeof(string));

			this.Bind_DataSet.Tables.Add(noteGuideHdTable);

			// �{�f�B���R�[�h�p�e�[�u��
			DataTable noteGuideBdTable = new DataTable(NOTE_GUID_BD_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			noteGuideBdTable.Columns.Add(DELETEDATE_TITLE,		   typeof(string));
			noteGuideBdTable.Columns.Add(NOTE_GUIDE_DIVCODE_TITLE, typeof(int));
			noteGuideBdTable.Columns.Add(NOTE_GUIDE_DIVNAME_TITLE, typeof(string));
			noteGuideBdTable.Columns.Add(NOTE_GUIDE_CODE_TITLE,	   typeof(int));
			noteGuideBdTable.Columns.Add(NOTE_GUIDE_NAME_TITLE,	   typeof(string));

			this.Bind_DataSet.Tables.Add(noteGuideBdTable);
		}

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			// UI��ʕ\�����̃`������}����ׂɁA�����ŃT�C�Y���ύX
			switch (this._targetTableName)
			{
				// �w�b�_
				case NOTE_GUID_HD_TABLE:
				{
					// ��ʃT�C�Y/���P�[�V�����ݒ�
					this.SetFormLocationAndSize(DISPMODE_DIV);
					// �X�V���[�h
					this.Mode_Label.Text = UPDATE_MODE;
					// ��ʓ��͋�����
					ScreenInputPermissionControl(1);

					break;
				}
				// �{�f�B
				case NOTE_GUID_BD_TABLE:
				{
					// ��ʃT�C�Y/���P�[�V�����ݒ�
					this.SetFormLocationAndSize(DISPMODE_CODE);

					// �V�K�̏ꍇ
					if (this._detailsDataIndex < 0)
					{
						// ��ʓ��͋�����
						ScreenInputPermissionControl(2);
						break;
					}
					// �폜�̏ꍇ
					if((string)this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][DELETEDATE_TITLE] != "")
					{
						// ��ʓ��͋�����
						ScreenInputPermissionControl(4);
						break;
					}
						// �X�V�̏ꍇ
					else
					{
						// ��ʓ��͋�����
						ScreenInputPermissionControl(3);
						break;
					}
				}
			}		
		}

		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void ScreenClear()
		{
			// �w�b�_
			this.NoteGuideDivCode_tNedit.Clear();
			this.NoteGuideDivName_tEdit.Clear();
			this.NoteGuideDivCode_tNedit.Enabled = true;
			this.NoteGuideDivName_tEdit.Enabled = true;
			// �{�f�B
			this.NoteGuideCode_tNedit.Clear();
			this.NoteGuideName_tEdit.Clear();
			this.NoteGuideCode_tNedit.Enabled = true;
			this.NoteGuideName_tEdit.Enabled = true;
			this.Body_Panel.Visible = true;
			// �{�^��
			this.Button_Panel.Visible = true;
			this.Ok_Button.Visible = true;
			this.Revive_Button.Visible = true;
			this.Delete_Button.Visible = true;
			// ���[�h���x��
			this.Mode_Label.Text = INSERT_MODE;
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			switch (this._targetTableName)
			{
				// �w�b�_
				case NOTE_GUID_HD_TABLE:
				{
					NoteGuidHd noteGuidHd = new NoteGuidHd();
					
					// �X�V���[�h
					this.Mode_Label.Text = UPDATE_MODE;

					// �\�����擾
					int hashKey = (int)this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows[this._mainDataIndex][NOTE_GUIDE_DIVCODE_TITLE];
					noteGuidHd = (NoteGuidHd)this._noteGuideHdTable[hashKey];
						
					// ��ʓW�J����
					NoteGuidHdToScreen(noteGuidHd);
						
					// �N���[���쐬
					this._noteGuidHdClone = noteGuidHd.Clone(); 
					DispToNoteGuidHd(ref this._noteGuidHdClone);
						
					// �t�H�[�J�X�ݒ�
					this.NoteGuideDivName_tEdit.SelectAll();

					break;
				}
				// �{�f�B
				case NOTE_GUID_BD_TABLE:
				{
					NoteGuidBd noteGuidBd = new NoteGuidBd();
			
					// �V�K�̏ꍇ
					if (this._detailsDataIndex < 0)
					{
						// �\�����擾
						int hashKey = (int)this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows[this._mainDataIndex][NOTE_GUIDE_DIVCODE_TITLE];
						NoteGuidHd noteGuidHd = (NoteGuidHd)this._noteGuideHdTable[hashKey];
						
						// ��ʓW�J����
						NoteGuidHdToScreen(noteGuidHd);
						
						// �N���[���쐬
						DispToNoteGuidBd(ref noteGuidBd);
						this._noteGuidBdClone = noteGuidBd; 
						
						// �t�H�[�J�X�ݒ�
						this.NoteGuideCode_tNedit.Focus();
			
						break;
					}
					// �폜�̏ꍇ
					if ((string)this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][DELETEDATE_TITLE] != "")
					{
						// �폜���[�h
						this.Mode_Label.Text = DELETE_MODE;
						
						// �\�����擾
						string hashKey = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_DIVCODE_TITLE].ToString()
							+ "_" + this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_CODE_TITLE].ToString(); 
						noteGuidBd = (NoteGuidBd)this._noteGuideBdTable[hashKey];
						
						// ��ʓW�J����
						NoteGuidBdToScreen(noteGuidBd);
	
						break;
					}
					// �X�V�̏ꍇ
					else
					{
						// �X�V���[�h
						this.Mode_Label.Text = UPDATE_MODE;

						// �\�����擾
						string hashKey = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_DIVCODE_TITLE].ToString()
							+ "_" + this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_CODE_TITLE].ToString(); 
						noteGuidBd = (NoteGuidBd)this._noteGuideBdTable[hashKey];
						
						// ��ʓW�J����
						NoteGuidBdToScreen(noteGuidBd);
						
						// �N���[���쐬
						this._noteGuidBdClone = noteGuidBd.Clone(); 
						DispToNoteGuidBd(ref this._noteGuidBdClone);
						
						// �t�H�[�J�X�ݒ�
						this.NoteGuideName_tEdit.SelectAll();

						break;
					}
				}
			}		
			//_GridIndex�o�b�t�@�ێ�
			this._detailsIndexBuf	= this._detailsDataIndex;
			this._mainIndexBuf		= this._mainDataIndex;
			this._targetTableBuf	= this._targetTableName;
		}

		/// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <param name="setType">�ݒ�^�C�v 1:�w�b�_-�X�V, 2:�{�f�B-�V�K, 3:�{�f�B-�X�V, 4:�{�f�B-�폜</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void ScreenInputPermissionControl(int setType)
		{
			switch (setType)
			{
					// 1:�w�b�_-�X�V
				case 1:
				{
					this.NoteGuideDivCode_tNedit.Enabled = false;
					this.Body_Panel.Visible = false;
					this.Revive_Button.Visible = false;
					this.Delete_Button.Visible = false;
					break;
				}
					// 2:�{�f�B-�V�K
				case 2:
				{
					this.NoteGuideDivCode_tNedit.Enabled = false;
					this.NoteGuideDivName_tEdit.Enabled = false;
					this.Revive_Button.Visible = false;
					this.Delete_Button.Visible = false;
					break;
				}
					// 3:�{�f�B-�X�V
				case 3:
				{
					this.NoteGuideDivCode_tNedit.Enabled = false;
					this.NoteGuideDivName_tEdit.Enabled = false;
					this.NoteGuideCode_tNedit.Enabled = false;
					this.Revive_Button.Visible = false;
					this.Delete_Button.Visible = false;
					break;
				}
					// 4:�{�f�B-�폜
				case 4:
				{
					this.NoteGuideDivCode_tNedit.Enabled = false;
					this.NoteGuideDivName_tEdit.Enabled = false;
					this.NoteGuideCode_tNedit.Enabled = false;
					this.NoteGuideName_tEdit.Enabled = false; 
					this.Ok_Button.Visible = false;
					break;
				}
			}
		}

		/// <summary>
		/// ���l�N���X�i�w�b�_�j��ʓW�J����
		/// </summary>
		/// <param name="noteGuidHd">���l�I�u�W�F�N�g�i�w�b�_�j</param>
		/// <remarks>
		/// <br>Note       : ���l�I�u�W�F�N�g�i�w�b�_�j�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void NoteGuidHdToScreen(NoteGuidHd noteGuidHd)
		{
			this.NoteGuideDivCode_tNedit.SetInt(noteGuidHd.NoteGuideDivCode);
			this.NoteGuideDivName_tEdit.Text = noteGuidHd.NoteGuideDivName;
		}									

		/// <summary>
		/// ���l�N���X�i�{�f�B�j��ʓW�J����
		/// </summary>
		/// <param name="noteGuidBd">���l�I�u�W�F�N�g�i�{�f�B�j</param>
		/// <remarks>
		/// <br>Note       : ���l�I�u�W�F�N�g�i�{�f�B�j�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void NoteGuidBdToScreen(NoteGuidBd noteGuidBd)
		{
			this.NoteGuideDivCode_tNedit.SetInt(noteGuidBd.NoteGuideDivCode);
			this.NoteGuideDivName_tEdit.Text = this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows[this._mainDataIndex][NOTE_GUIDE_DIVNAME_TITLE].ToString();
			
			this.NoteGuideCode_tNedit.SetInt(noteGuidBd.NoteGuideCode);
			this.NoteGuideName_tEdit.Text = noteGuidBd.NoteGuideName;
		}									

		/// <summary>
		/// ��ʏ����l�N���X�i�w�b�_�j�i�[����
		/// </summary>
		/// <param name="noteGuidHd">���l�I�u�W�F�N�g�i�w�b�_�j</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂���l�I�u�W�F�N�g�i�w�b�_�j�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void DispToNoteGuidHd(ref NoteGuidHd noteGuidHd)
		{
			if (noteGuidHd == null)
			{
				// �V�K�̏ꍇ
				noteGuidHd = new NoteGuidHd();
			}													  

			noteGuidHd.EnterpriseCode	= this._enterpriseCode;	
			noteGuidHd.NoteGuideDivCode	= this.NoteGuideDivCode_tNedit.GetInt();
			noteGuidHd.NoteGuideDivName	= this.NoteGuideDivName_tEdit.Text;
		}

		/// <summary>
		/// ��ʏ����l�N���X�i�{�f�B�j�i�[����
		/// </summary>
		/// <param name="noteGuidBd">���l�I�u�W�F�N�g�i�{�f�B�j</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂���l�I�u�W�F�N�g�i�{�f�B�j�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void DispToNoteGuidBd(ref NoteGuidBd noteGuidBd)
		{
			if (noteGuidBd == null)
			{
				// �V�K�̏ꍇ
				noteGuidBd = new NoteGuidBd();
			}													  

			noteGuidBd.EnterpriseCode	= this._enterpriseCode;	
			noteGuidBd.NoteGuideDivCode	= this.NoteGuideDivCode_tNedit.GetInt();
			noteGuidBd.NoteGuideDivName	= this.NoteGuideDivName_tEdit.Text;
			noteGuidBd.NoteGuideCode	= this.NoteGuideCode_tNedit.GetInt();
			noteGuidBd.NoteGuideName	= this.NoteGuideName_tEdit.Text;
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
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private bool ScreenDataCheck(ref Control control, ref string message)
		{
			bool result = true;

			// �w�b�_�̏ꍇ
			if (this.Body_Panel.Visible == false)
			{
				if (this.NoteGuideDivName_tEdit.Text == "")
				{
					control = this.NoteGuideDivName_tEdit;
					message = this.NoteGuideDivName_uLabel.Text + "����͂��ĉ������B";
					result	= false;	
				}
			}
			else	// �{�f�B�̏ꍇ
			{
				if (this.NoteGuideCode_tNedit.GetInt() == 0)
				{
					control = this.NoteGuideCode_tNedit;
					message = this.NoteGuideCode_uLabel.Text + "����͂��ĉ������B";
					result	= false;
				}
				else if (this.NoteGuideName_tEdit.Text == "")
				{
					control = this.NoteGuideName_tEdit;
					message = this.NoteGuideName_uLabel.Text + "����͂��ĉ������B";
					result	= false;	
				}
			}

			return result;
		}

		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <returns>�`�F�b�N����</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : ���l�I�u�W�F�N�g�̕ۑ��������s���܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>
		private bool SaveProc()
		{
			Control control = null;
			string message = null;	

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

			// �w�b�_
			if (this.Body_Panel.Visible == false)
			{
				NoteGuidHd noteGuidHd = null;
				if (this._mainDataIndex >= 0)
				{
					int hashKey = (int)this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows[this._mainIndexBuf][NOTE_GUIDE_DIVCODE_TITLE];
					noteGuidHd = ((NoteGuidHd)this._noteGuideHdTable[hashKey]).Clone();
				}

				// ��ʏ��i�[����
				DispToNoteGuidHd(ref noteGuidHd);

				int status = this._noteGuidAcs.Write(ref noteGuidHd);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						NoteGuidHdToDataSet(noteGuidHd, this._mainIndexBuf);
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

						this.NoteGuideDivCode_tNedit.Focus();
						return false;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// �r������
						ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._noteGuidAcs);

						// UI��ʋ����I������
						EnforcedEndTransaction();
					
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
							this._noteGuidAcs,					// �G���[�����������I�u�W�F�N�g
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
			else
			{
				NoteGuidBd noteGuidBd = null;
				if (this._detailsDataIndex >= 0)
				{
					string hashKey = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_DIVCODE_TITLE].ToString()
						+ "_" + this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_CODE_TITLE].ToString();
						noteGuidBd = ((NoteGuidBd)this._noteGuideBdTable[hashKey]).Clone();
				}

				// ��ʏ��i�[����
				DispToNoteGuidBd(ref noteGuidBd);

				int status = this._noteGuidAcs.Write(ref noteGuidBd);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						NoteGuidBdToDataSet(noteGuidBd, this._detailsDataIndex);
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

						this.NoteGuideCode_tNedit.Focus();
						return false;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// �r������
						ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._noteGuidAcs);

						// UI��ʋ����I������
						EnforcedEndTransaction();
					
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
							this._noteGuidAcs,					// �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,				// �\������{�^��
							MessageBoxDefaultButton.Button1);	// �����\���{�^��

						// UI��ʋ����I������
						EnforcedEndTransaction();
						return false;
					}
				}
				// �V�K�o�^������
				NewEntryTransaction();
				return true;
			}
		}

		/// <summary>
		/// �V�K�o�^������
		/// </summary>
		/// <remarks>
		/// <br>Note       : �V�K�o�^���̏������s���܂��B</br>
		/// <br>Programmer : 22033  �O�� �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void NewEntryTransaction ()
		{
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}
			// �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				if (TargetTableName == NOTE_GUID_HD_TABLE)
				{
					// �f�[�^�C���f�b�N�X������������
					this._mainDataIndex = -1;
				}
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
				this._mainIndexBuf = -2;
				this._targetTableBuf = "";

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
		/// UI�q��ʋ����I������
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�X�V�G���[����UI�q��ʋ����I���������s���܂��B</br>
		/// <br>Programmer : 22033  �O�� �M�j</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void EnforcedEndTransaction ()
		{
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;
			this._detailsIndexBuf = -2;
			this._mainIndexBuf	  = -2;
			this._targetTableBuf  = "";

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
		/// ���̓t�H�[����ʃT�C�Y/�\���ʒu�ݒ菈��
		/// </summary>
		/// <param name="mode">���̓t�H�[���N�����[�h</param>
		private void SetFormLocationAndSize(int mode)
		{
			// �X�N���[���T�C�Y�̎擾
			int width = Screen.PrimaryScreen.Bounds.Width;
			int hight = Screen.PrimaryScreen.Bounds.Height;

			// �敪�̏ꍇ
			if (mode == DISPMODE_DIV)
			{
				// ���̓t�H�[���̃T�C�Y
				this.ClientSize = new Size(484, 180);
				// �{�^���p�l���ړ�
				this.Button_Panel.Location = new System.Drawing.Point(88, 105);
			}
			// �R�[�h�̏ꍇ
			else if (mode == DISPMODE_CODE)
			{
				// ���̓t�H�[���̃T�C�Y
				this.ClientSize = new Size(484, 250);
				// �{�^���p�l���ړ�
				this.Button_Panel.Location = new System.Drawing.Point(88, 180);
			}

			// ���̓t�H�[���̃��P�[�V����
            //this.Location = new Point((width / 2) - (this.Size.Width / 2), (hight / 2) - (this.Size.Height / 2)); // DEL 2008/09/11
		}
		# endregion

		# region ��Control Events

		/// <summary>
		/// Form.Load �C�x���g(SFTOK09400UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>
		private void SFTOK09400UA_Load(object sender, System.EventArgs e)
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

			// ��ʏ����ݒ菈��
			ScreenInitialSetting();
		}

		/// <summary>
		/// Form.Closing �C�x���g(SFTOK09400UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>
		private void SFTOK09400UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._detailsIndexBuf	= -2;
			this._mainIndexBuf		= -2;
			this._targetTableBuf  = "";

			// �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}	
		}

		/// <summary>
		/// Control.VisibleChanged �C�x���g(SFTOK09400UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>
		private void SFTOK09400UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				this.Owner.Activate();
				
				return;
			}
			
			if ((this._detailsIndexBuf == this._detailsDataIndex) &&
				(this._mainIndexBuf == this._mainDataIndex) &&
				(this._targetTableBuf == this._targetTableName))
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
		/// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// ���l�o�^����
			SaveProc();
		}

		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>		
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			bool cloneFlg;
			// �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if (this.Mode_Label.Text != DELETE_MODE)
			{
				switch (this._targetTableName)
				{
					case NOTE_GUID_HD_TABLE:
					{
						// ���݂̉�ʏ����擾
						NoteGuidHd compareNoteGuidHd = new NoteGuidHd();  
						compareNoteGuidHd = this._noteGuidHdClone.Clone();  
						DispToNoteGuidHd(ref compareNoteGuidHd);
						// �ŏ��Ɏ擾������ʏ��Ɣ�r
						cloneFlg = this._noteGuidHdClone.Equals(compareNoteGuidHd);
						break;
					}
					default:
					{
						// ���݂̉�ʏ����擾
						NoteGuidBd compareNoteGuidBd = new NoteGuidBd();  
						compareNoteGuidBd = this._noteGuidBdClone.Clone();  
						DispToNoteGuidBd(ref compareNoteGuidBd);
						// �ŏ��Ɏ擾������ʏ��Ɣ�r
						cloneFlg = this._noteGuidBdClone.Equals(compareNoteGuidBd);
						break;
					}
				}
				if (!(cloneFlg))
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
							// 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                NoteGuideCode_tNedit.Focus();
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
			this._targetTableBuf = "";

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
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			// ��ʍč\�z����
			ScreenReconstruction();		
		}

		/// <summary>
		/// Control.Click �C�x���g(Revive_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			string hashKey = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_DIVCODE_TITLE]
				+ "_" + this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_CODE_TITLE];
			NoteGuidBd noteGuidBd = ((NoteGuidBd)_noteGuideBdTable[hashKey]).Clone();

			int status = this._noteGuidAcs.Revival(ref noteGuidBd);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					// DataSet�W�J����
					NoteGuidBdToDataSet(noteGuidBd, this._detailsDataIndex);
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// �r������
					ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._noteGuidAcs);
					
					// UI��ʋ����I������
					EnforcedEndTransaction();
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
						ERR_RVV_MSG,						  // �\�����郁�b�Z�[�W 
						status,								  // �X�e�[�^�X�l
						this._noteGuidAcs,					  // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				  // �\������{�^��
						MessageBoxDefaultButton.Button1);	  // �����\���{�^��
					
					// UI��ʋ����I������
					EnforcedEndTransaction();
					
					return;
				}
			}
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;
			this._detailsIndexBuf = -2;
			this._mainIndexBuf = -2;
			this._targetTableBuf = "";

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}

            // ���l�K�C�h�̃L���b�V����������
            InitializeCacheNoteGuidBdList();    // ADD 2009/03/24 �s��Ή�[12690]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
		}

		/// <summary>
		/// Control.Click �C�x���g(Delete_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
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
				string hashKey = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_DIVCODE_TITLE]
					+ "_" + this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_CODE_TITLE];
				NoteGuidBd noteGuidBd = ((NoteGuidBd)_noteGuideBdTable[hashKey]).Clone();

				int status = this._noteGuidAcs.Delete(noteGuidBd);
				
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex].Delete();
						this._noteGuideBdTable.Remove(hashKey);

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// �r������
						ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._noteGuidAcs);
			
						// UI�q��ʋ����I������
						EnforcedEndTransaction();
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
							ERR_RDEL_MSG,						  // �\�����郁�b�Z�[�W 
							status,								  // �X�e�[�^�X�l
							this._noteGuidAcs,					  // �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,				  // �\������{�^��
							MessageBoxDefaultButton.Button1);	  // �����\���{�^��
			
						if (UnDisplaying != null)
						{
							MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
							UnDisplaying(this, me);
						}

						// UI�q��ʋ����I������
						EnforcedEndTransaction();
						return;
					}
				}
			}
			else
			{
				this.Delete_Button.Focus();
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;
			this._detailsIndexBuf = -2;
			this._mainIndexBuf = -2;
			this._targetTableBuf = "";

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
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
                case "NoteGuideCode_tNedit":
                    // �K�C�h�R�[�h�Ƀt�H�[�J�X������ꍇ
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // �J�ڐ悪����{�^��
                        _modeFlg = true;
                    }
                    else if (this._detailsDataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            e.NextCtrl = NoteGuideCode_tNedit;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // �K�C�h�R�[�h
            int noteGuideCode = NoteGuideCode_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsNoteGuideCode = (int)this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[i][NOTE_GUIDE_CODE_TITLE];
                if (noteGuideCode == dsNoteGuideCode)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[i][DELETEDATE_TITLE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̔��l�ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // �K�C�h�R�[�h�̃N���A
                        NoteGuideCode_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̔��l�ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._detailsDataIndex = i;
                                ScreenClear();
                                ScreenInitialSetting();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // �K�C�h�R�[�h�̃N���A
                                NoteGuideCode_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.26 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
	}
}
