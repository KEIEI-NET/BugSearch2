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

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �d�����z�����敪�ݒ�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d�����z�����敪�̐ݒ���s���܂��B
	///					 IMasterMaintenanceMultiType���������Ă��܂��B</br>
	/// <br>Programmer : 30167 ��� �O�M</br>
	/// <br>Date       : 2007.08.20</br>
	/// <br>Update Note: 2008.02.07 30167 ���@�O�M
	/// <br>			 �E�d�����b�Z�[�W�C��
	///					 �E����Őݒ�̏�����z�I�[��9�ɐݒ�</br>
    /// <br>           : 2008/11/07       �Ɠc �M�u</br>
    /// <br>           �@�E�P�������R�[�h�̓��͌���9��4�ɕύX</br>
    /// <br>           : 2009/02/05 30414 �E �K�j</br>
    /// <br>           �@�E�P�������R�[�h�̓��͌���4��8�ɕύX</br>
    /// </remarks>
	public class DCKON09100UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region Private Members (Component)
		private Infragistics.Win.Misc.UltraLabel FRACPROCMONEYDIV_TITLE_Label;
		private Infragistics.Win.Misc.UltraLabel FRACTIONPROCCODE_TITLE_Label;
		private Infragistics.Win.Misc.UltraLabel UPPERLIMITPRICE_TITLE_Label;
		private Infragistics.Win.Misc.UltraLabel FRACTIONPROCUNIT_TITLE_Label;
		private Infragistics.Win.Misc.UltraLabel FRACTIONPROCCD_TITLE_Label;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private System.Data.DataSet Bind_DataSet;
		private TComboEditor fracProcMoneyDiv_tComboEditor1;
		private TNedit upperLimitPrice_tNedit2;
		private TNedit fractionProcCode_tNedit1;
		private TComboEditor fractionProcCd_tComboEditor2;
		private TNedit fractionProcUnit_tNedit3;
		private System.ComponentModel.IContainer components;
		# endregion

		/// <summary>
		/// �d�����z�����敪�ݒ�����̓t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�����̓t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2005.08.14</br>
		/// </remarks>
		public DCKON09100UA()
		{
			InitializeComponent();

			// �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ�
			this._canPrint	= false;
			this._canClose	= false;
			this._canNew	= true;
			this._canDelete = true;
			this._canLogicalDeleteDataExtraction = true;
			this._defaultAutoFillToColumn = true;
			this._canSpecificationSearch = false;

			// ��ƃR�[�h���擾����
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// �ϐ�������
			this._dataIndex = -1;
			this._stockProcMoneyAcs = new StockProcMoneyAcs();
			this._totalCount = 0;
			this._stockProcMoneyTable = new Hashtable();

			//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			this._indexBuf = -2;
		}

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

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKON09100UA));
            this.FRACPROCMONEYDIV_TITLE_Label = new Infragistics.Win.Misc.UltraLabel();
            this.FRACTIONPROCCODE_TITLE_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UPPERLIMITPRICE_TITLE_Label = new Infragistics.Win.Misc.UltraLabel();
            this.FRACTIONPROCUNIT_TITLE_Label = new Infragistics.Win.Misc.UltraLabel();
            this.FRACTIONPROCCD_TITLE_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Bind_DataSet = new System.Data.DataSet();
            this.fracProcMoneyDiv_tComboEditor1 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.fractionProcCode_tNedit1 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.upperLimitPrice_tNedit2 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.fractionProcUnit_tNedit3 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.fractionProcCd_tComboEditor2 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fracProcMoneyDiv_tComboEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fractionProcCode_tNedit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitPrice_tNedit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fractionProcUnit_tNedit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fractionProcCd_tComboEditor2)).BeginInit();
            this.SuspendLayout();
            // 
            // FRACPROCMONEYDIV_TITLE_Label
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.FRACPROCMONEYDIV_TITLE_Label.Appearance = appearance1;
            this.FRACPROCMONEYDIV_TITLE_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.FRACPROCMONEYDIV_TITLE_Label.Location = new System.Drawing.Point(24, 35);
            this.FRACPROCMONEYDIV_TITLE_Label.Name = "FRACPROCMONEYDIV_TITLE_Label";
            this.FRACPROCMONEYDIV_TITLE_Label.Size = new System.Drawing.Size(164, 24);
            this.FRACPROCMONEYDIV_TITLE_Label.TabIndex = 0;
            this.FRACPROCMONEYDIV_TITLE_Label.Text = "�[�������Ώۋ��z�敪";
            // 
            // FRACTIONPROCCODE_TITLE_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.FRACTIONPROCCODE_TITLE_Label.Appearance = appearance2;
            this.FRACTIONPROCCODE_TITLE_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.FRACTIONPROCCODE_TITLE_Label.Location = new System.Drawing.Point(24, 70);
            this.FRACTIONPROCCODE_TITLE_Label.Name = "FRACTIONPROCCODE_TITLE_Label";
            this.FRACTIONPROCCODE_TITLE_Label.Size = new System.Drawing.Size(164, 24);
            this.FRACTIONPROCCODE_TITLE_Label.TabIndex = 1;
            this.FRACTIONPROCCODE_TITLE_Label.Text = "�[�������R�[�h";
            // 
            // UPPERLIMITPRICE_TITLE_Label
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.UPPERLIMITPRICE_TITLE_Label.Appearance = appearance3;
            this.UPPERLIMITPRICE_TITLE_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UPPERLIMITPRICE_TITLE_Label.Location = new System.Drawing.Point(24, 105);
            this.UPPERLIMITPRICE_TITLE_Label.Name = "UPPERLIMITPRICE_TITLE_Label";
            this.UPPERLIMITPRICE_TITLE_Label.Size = new System.Drawing.Size(164, 24);
            this.UPPERLIMITPRICE_TITLE_Label.TabIndex = 2;
            this.UPPERLIMITPRICE_TITLE_Label.Text = "������z";
            // 
            // FRACTIONPROCUNIT_TITLE_Label
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.FRACTIONPROCUNIT_TITLE_Label.Appearance = appearance4;
            this.FRACTIONPROCUNIT_TITLE_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.FRACTIONPROCUNIT_TITLE_Label.Location = new System.Drawing.Point(24, 140);
            this.FRACTIONPROCUNIT_TITLE_Label.Name = "FRACTIONPROCUNIT_TITLE_Label";
            this.FRACTIONPROCUNIT_TITLE_Label.Size = new System.Drawing.Size(164, 24);
            this.FRACTIONPROCUNIT_TITLE_Label.TabIndex = 3;
            this.FRACTIONPROCUNIT_TITLE_Label.Text = "�[�������P��";
            // 
            // FRACTIONPROCCD_TITLE_Label
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.FRACTIONPROCCD_TITLE_Label.Appearance = appearance5;
            this.FRACTIONPROCCD_TITLE_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.FRACTIONPROCCD_TITLE_Label.Location = new System.Drawing.Point(24, 175);
            this.FRACTIONPROCCD_TITLE_Label.Name = "FRACTIONPROCCD_TITLE_Label";
            this.FRACTIONPROCCD_TITLE_Label.Size = new System.Drawing.Size(164, 24);
            this.FRACTIONPROCCD_TITLE_Label.TabIndex = 4;
            this.FRACTIONPROCCD_TITLE_Label.Text = "�[�������敪";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(234, 227);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 5;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(364, 227);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 6;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(364, 227);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 7;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(494, 227);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 8;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Mode_Label
            // 
            appearance6.ForeColor = System.Drawing.Color.White;
            appearance6.TextHAlignAsString = "Center";
            appearance6.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance6;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(515, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 14;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
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
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 268);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(632, 23);
            this.ultraStatusBar1.TabIndex = 15;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // fracProcMoneyDiv_tComboEditor1
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.fracProcMoneyDiv_tComboEditor1.ActiveAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.fracProcMoneyDiv_tComboEditor1.Appearance = appearance16;
            this.fracProcMoneyDiv_tComboEditor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.fracProcMoneyDiv_tComboEditor1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.fracProcMoneyDiv_tComboEditor1.ItemAppearance = appearance17;
            this.fracProcMoneyDiv_tComboEditor1.Location = new System.Drawing.Point(215, 35);
            this.fracProcMoneyDiv_tComboEditor1.Name = "fracProcMoneyDiv_tComboEditor1";
            this.fracProcMoneyDiv_tComboEditor1.Size = new System.Drawing.Size(139, 24);
            this.fracProcMoneyDiv_tComboEditor1.TabIndex = 16;
            this.fracProcMoneyDiv_tComboEditor1.SelectionChangeCommitted += new System.EventHandler(this.fracProcMoneyDiv_tComboEditor1_SelectionChangeCommitted);
            // 
            // fractionProcCode_tNedit1
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.TextHAlignAsString = "Right";
            this.fractionProcCode_tNedit1.ActiveAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance14.TextHAlignAsString = "Right";
            this.fractionProcCode_tNedit1.Appearance = appearance14;
            this.fractionProcCode_tNedit1.AutoSelect = true;
            this.fractionProcCode_tNedit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.fractionProcCode_tNedit1.CalcSize = new System.Drawing.Size(172, 200);
            this.fractionProcCode_tNedit1.DataText = "";
            this.fractionProcCode_tNedit1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.fractionProcCode_tNedit1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.fractionProcCode_tNedit1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.fractionProcCode_tNedit1.Location = new System.Drawing.Point(215, 70);
            this.fractionProcCode_tNedit1.MaxLength = 8;
            this.fractionProcCode_tNedit1.Name = "fractionProcCode_tNedit1";
            this.fractionProcCode_tNedit1.NullText = "0";
            this.fractionProcCode_tNedit1.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.fractionProcCode_tNedit1.Size = new System.Drawing.Size(136, 24);
            this.fractionProcCode_tNedit1.TabIndex = 17;
            // 
            // upperLimitPrice_tNedit2
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance11.TextHAlignAsString = "Right";
            this.upperLimitPrice_tNedit2.ActiveAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance12.TextHAlignAsString = "Right";
            this.upperLimitPrice_tNedit2.Appearance = appearance12;
            this.upperLimitPrice_tNedit2.AutoSelect = true;
            this.upperLimitPrice_tNedit2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.upperLimitPrice_tNedit2.CalcSize = new System.Drawing.Size(172, 200);
            this.upperLimitPrice_tNedit2.DataText = "";
            this.upperLimitPrice_tNedit2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.upperLimitPrice_tNedit2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.upperLimitPrice_tNedit2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.upperLimitPrice_tNedit2.Location = new System.Drawing.Point(215, 105);
            this.upperLimitPrice_tNedit2.MaxLength = 9;
            this.upperLimitPrice_tNedit2.Name = "upperLimitPrice_tNedit2";
            this.upperLimitPrice_tNedit2.NullText = "0";
            this.upperLimitPrice_tNedit2.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.upperLimitPrice_tNedit2.Size = new System.Drawing.Size(136, 24);
            this.upperLimitPrice_tNedit2.TabIndex = 18;
            // 
            // fractionProcUnit_tNedit3
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance9.TextHAlignAsString = "Right";
            this.fractionProcUnit_tNedit3.ActiveAppearance = appearance9;
            appearance10.TextHAlignAsString = "Right";
            this.fractionProcUnit_tNedit3.Appearance = appearance10;
            this.fractionProcUnit_tNedit3.AutoSelect = true;
            this.fractionProcUnit_tNedit3.CalcSize = new System.Drawing.Size(172, 200);
            this.fractionProcUnit_tNedit3.DataText = "";
            this.fractionProcUnit_tNedit3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.fractionProcUnit_tNedit3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.fractionProcUnit_tNedit3.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.fractionProcUnit_tNedit3.Location = new System.Drawing.Point(215, 140);
            this.fractionProcUnit_tNedit3.MaxLength = 9;
            this.fractionProcUnit_tNedit3.Name = "fractionProcUnit_tNedit3";
            this.fractionProcUnit_tNedit3.NullText = "0";
            this.fractionProcUnit_tNedit3.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.fractionProcUnit_tNedit3.Size = new System.Drawing.Size(136, 24);
            this.fractionProcUnit_tNedit3.TabIndex = 19;
            // 
            // fractionProcCd_tComboEditor2
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.fractionProcCd_tComboEditor2.ActiveAppearance = appearance7;
            this.fractionProcCd_tComboEditor2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.fractionProcCd_tComboEditor2.ItemAppearance = appearance8;
            this.fractionProcCd_tComboEditor2.Location = new System.Drawing.Point(215, 175);
            this.fractionProcCd_tComboEditor2.Name = "fractionProcCd_tComboEditor2";
            this.fractionProcCd_tComboEditor2.Size = new System.Drawing.Size(139, 24);
            this.fractionProcCd_tComboEditor2.TabIndex = 20;
            // 
            // DCKON09100UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(632, 291);
            this.Controls.Add(this.fractionProcCd_tComboEditor2);
            this.Controls.Add(this.fractionProcUnit_tNedit3);
            this.Controls.Add(this.upperLimitPrice_tNedit2);
            this.Controls.Add(this.fractionProcCode_tNedit1);
            this.Controls.Add(this.fracProcMoneyDiv_tComboEditor1);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.FRACTIONPROCCD_TITLE_Label);
            this.Controls.Add(this.FRACTIONPROCUNIT_TITLE_Label);
            this.Controls.Add(this.UPPERLIMITPRICE_TITLE_Label);
            this.Controls.Add(this.FRACTIONPROCCODE_TITLE_Label);
            this.Controls.Add(this.FRACPROCMONEYDIV_TITLE_Label);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DCKON09100UA";
            this.Text = "�d�����z�����敪�ݒ�";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fracProcMoneyDiv_tComboEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fractionProcCode_tNedit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitPrice_tNedit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fractionProcUnit_tNedit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fractionProcCd_tComboEditor2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Events

		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

		#endregion

		#region Private Members

		private StockProcMoneyAcs _stockProcMoneyAcs;

		//��r�pclone
		private StockProcMoney _stockProcMoneyClone;
		
		private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _stockProcMoneyTable;
		private int _fracProcMoneyDiv_tComboEditor1Value = -1;

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _indexBuf;

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";

		// Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
		private const string DELETE_DATE			= "�폜��";
		private const string FRACPROCMONEYDIV_TITLE	= "�[�������Ώۋ��z�敪";
		private const string FRACTIONPROCCODE_TITLE	= "�[�������R�[�h";
		private const string UPPERLIMITPRICE_TITLE	= "������z";
		private const string FRACTIONPROCUNIT_TITLE	= "�[�������P��";
		private const string FRACTIONPROCCD_TITLE	= "�[�������敪";

		// �e�[�u������
		private const string MAIN_TABLE = "STOCKPROCMONEY";		// �d�����z�����敪�ݒ�

		// �K�C�h�L�[
		private const string GUID_TITLE = "GUID";

		// Message�֘A��`
        private const string ASSEMBLY_ID	= "DCKON09100U";
        private const string ERR_READ_MSG	= "�ǂݍ��݂Ɏ��s���܂����B";

		//----- ueno upd ---------- start 2008.02.07		
		private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B\r\n�[�������R�[�h�A������z���m�F���ĉ������B";
		//----- ueno upd ---------- end 2008.02.07		
		
		private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG	= "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG	= "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG	= "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG	= "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG	= "�}�X�^����폜����Ă��܂�";
		private const string CONF_DEL_MSG	= "�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H";

		// �������͗p��`
		private const int MAXLENGTH_DECIMAL		= 11;		// ������
		private const string NULLTEXT_DECIMAL	= "0.00";	// �����\��
		private const int NUMEDIT_DECIMAL		= 2;		// �����_�ȉ��\������
		private const int EXTEDITCOLUMN_DECIMAL = 14;		// �\������(�J���}�A�s���I�h�܂�)
		
		// �������͒�`
		private const int MAXLENGTH_INT		= 9;	// ������
		private const string NULLTEXT_INT	= "0";	// �����\��
		private const int NUMEDIT_INT		= 0;	// �����_�ȉ��\������
		private const int EXTEDITCOLUMN_INT = 11;	// �\������(�J���}�A�s���I�h�܂�)

		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new DCKON09100UA());
		}

		/// <summary>����\�ݒ�v���p�e�B</summary>
		/// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanPrint
		{
			get{ return this._canPrint; }
		}

		/// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
		/// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get{ return this._canLogicalDeleteDataExtraction; }
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

		/// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
		/// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
		public int DataIndex
		{
			get{ return this._dataIndex; }
			set{ this._dataIndex = value; }
		}

		/// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
		/// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
		public bool DefaultAutoFillToColumn
		{
			get{ return this._defaultAutoFillToColumn; }
		}

		/// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
		/// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		public bool CanSpecificationSearch
		{					 
			get{ return this._canSpecificationSearch; }
		}

		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u������</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = MAIN_TABLE;
		}

		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���(���g�p)</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList stockProcMoneyList = null;

			// �O���b�h���N���A
			this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Clear();
			
			// ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
			status = this._stockProcMoneyAcs.SearchAll(out stockProcMoneyList, this._enterpriseCode);

			this._totalCount = stockProcMoneyList.Count;

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					int index = 0;
					foreach(StockProcMoney stockProcMoney in stockProcMoneyList)
					{
						StockProcMoneyToDataSet(stockProcMoney.Clone(), index);
						++index;
					}
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					// �f�[�^�Ȃ��̏ꍇ�̓O���b�h���N���A
					this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Clear();
					this._stockProcMoneyTable.Clear();
					break;
				}
				default:
				{
					TMsgDisp.Show(this,						// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,		// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u��ID
						this.Text,							// �v���O��������
						"Search",							// ��������
						TMsgDisp.OPE_GET,					// �I�y���[�V����
						ERR_READ_MSG,						// �\�����郁�b�Z�[�W
						status,								// �X�e�[�^�X�l
						this._stockProcMoneyAcs,			// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��
					
					this.Hide();
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
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			// ������
			return 0;
		}

		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int Delete()
		{
			int status = 0;
			
			//�d�����z�����敪�ݒ�_���폜
			status = LogicalDeleteStockProcMoney();
			
			return status;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int Print()
		{
			// ������
			return 0;
		}

		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth,ContentAlignment.MiddleLeft,"",Color.Red));
			appearanceTable.Add(FRACPROCMONEYDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(FRACTIONPROCCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
			appearanceTable.Add(UPPERLIMITPRICE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "###,#0.00", Color.Black));
			appearanceTable.Add(FRACTIONPROCUNIT_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "###,#0.00", Color.Black));
			appearanceTable.Add(FRACTIONPROCCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleLeft,"",Color.Black));

			return appearanceTable;
		}

		/// <summary>
		/// �d�����z�����敪�ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
		/// <param name="stockProcMoney">�d�����z�����敪�ݒ�I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void StockProcMoneyToDataSet(StockProcMoney stockProcMoney, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[MAIN_TABLE].NewRow();
				this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count - 1;
			}

			// �_���폜�敪
			if (stockProcMoney.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][DELETE_DATE] = "";
			}
			else
			{
				this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][DELETE_DATE] = stockProcMoney.UpdateDateTimeJpInFormal;
			}

			// �[�������Ώۋ��z�敪(�Y���������\��)
			this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][FRACPROCMONEYDIV_TITLE] = StockProcMoney.GetFracProcMoneyDivNm(stockProcMoney.FracProcMoneyDiv);
			
			// �[�������R�[�h
			this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][FRACTIONPROCCODE_TITLE] = stockProcMoney.FractionProcCode;

			// ������z
			this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][UPPERLIMITPRICE_TITLE] = stockProcMoney.UpperLimitPrice;

			// �[�������P��
			this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][FRACTIONPROCUNIT_TITLE] = stockProcMoney.FractionProcUnit;

			// �[�������敪(�Y���������\��)
			this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][FRACTIONPROCCD_TITLE] = StockProcMoney.GetFractionProcCdNm(stockProcMoney.FractionProcCd);
			
			// GUID
			this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][GUID_TITLE] = stockProcMoney.FileHeaderGuid;

            // �n�b�V���e�[�u���X�V
			if (this._stockProcMoneyTable.ContainsKey(stockProcMoney.FileHeaderGuid) == true)
			{
				this._stockProcMoneyTable.Remove(stockProcMoney.FileHeaderGuid);
			}
			this._stockProcMoneyTable.Add(stockProcMoney.FileHeaderGuid, stockProcMoney);
		}

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable stockProcMoneyTable = new DataTable(MAIN_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			stockProcMoneyTable.Columns.Add(DELETE_DATE, typeof(string));
			stockProcMoneyTable.Columns.Add(FRACPROCMONEYDIV_TITLE, typeof(string));
			stockProcMoneyTable.Columns.Add(FRACTIONPROCCODE_TITLE, typeof(string));
			stockProcMoneyTable.Columns.Add(UPPERLIMITPRICE_TITLE, typeof(double));
			stockProcMoneyTable.Columns.Add(FRACTIONPROCUNIT_TITLE, typeof(double));
			stockProcMoneyTable.Columns.Add(FRACTIONPROCCD_TITLE, typeof(string));
			stockProcMoneyTable.Columns.Add(GUID_TITLE, typeof(Guid));

			this.Bind_DataSet.Tables.Add(stockProcMoneyTable);
		}

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			// �[�������Ώۋ��z�敪�擾
			ArrayList wkListCd1 = StockProcMoney.GetFracProcMoneyDivCdList();
			ArrayList wkListNm1 = StockProcMoney.GetFracProcMoneyDivNmList();

			this.fracProcMoneyDiv_tComboEditor1.Items.Clear();			// �����A�C�e���N���A

			for(int ix = 0; ix != wkListCd1.Count; ix++)
			{
				Int32 code = (Int32)wkListCd1[ix];
				this.fracProcMoneyDiv_tComboEditor1.Items.Add(code, wkListNm1[ix].ToString());
			}

			this.fracProcMoneyDiv_tComboEditor1.Value = 0;				// �u�d�����z�v�ɐݒ�

			// �[�������敪�擾
			ArrayList wkListCd2 = StockProcMoney.GetFractionProcCdCdList();
			ArrayList wkListNm2 = StockProcMoney.GetFractionProcCdNmList();

			this.fractionProcCd_tComboEditor2.Items.Clear();			// �����A�C�e���N���A

			for (int ix = 0; ix != wkListCd2.Count; ix++)
			{
				Int32 code = (Int32)wkListCd2[ix];
				this.fractionProcCd_tComboEditor2.Items.Add(code, wkListNm2[ix].ToString());
			}

			this.fractionProcCd_tComboEditor2.Value = 1;				// �u�؎̂āv�ɐݒ�

			_fracProcMoneyDiv_tComboEditor1Value = -1;

			// ���z�\���ύX�`�F�b�N
			MoneyVisibleChange(0);

			// �V�K�̏ꍇ
			if (this._dataIndex < 0)
			{
				ScreenInputPermissionControl(0);                        // ��ʓ��͋�����
			}
			// �폜�̏ꍇ
			else if ((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._dataIndex][DELETE_DATE] != "")
			{
				ScreenInputPermissionControl(2);                        // ��ʓ��͋�����
			}
			// �X�V�̏ꍇ
			else
			{
				ScreenInputPermissionControl(1);                        // ��ʓ��͋�����
			}
		}

		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void ScreenClear()
		{
			// ���[�h���x��
			this.Mode_Label.Text = INSERT_MODE;

			// �{�^��
			this.Delete_Button.Visible	= true;	// ���S�폜�{�^��
			this.Revive_Button.Visible	= true;	// �����{�^��
			this.Ok_Button.Visible		= true;	// �ۑ��{�^��
			this.Cancel_Button.Visible	= true;	// ����{�^��

			// ���͐���
			this.fracProcMoneyDiv_tComboEditor1.Enabled = true;	// �[�������Ώۋ��z�敪
			this.fractionProcCode_tNedit1.Enabled		= true;	// �[�������R�[�h
			this.upperLimitPrice_tNedit2.Enabled		= true;	// ������z
			this.fractionProcUnit_tNedit3.Enabled		= true;	// �[�������P��
			this.fractionProcCd_tComboEditor2.Enabled	= true;	// �[�������敪

			// ����
			this.fracProcMoneyDiv_tComboEditor1.Value = 0;	// �[�������Ώۋ��z�敪(�u�d�����z�v)
			this.fractionProcCode_tNedit1.SetInt(0);		// �[�������R�[�h
			this.upperLimitPrice_tNedit2.SetInt(0);			// ������z
			this.fractionProcUnit_tNedit3.SetInt(0);		// �[�������P��
			this.fractionProcCd_tComboEditor2.Value = 1;	// �[�������敪(�u�؎̂āv)
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			// �V�K�̏ꍇ
			if (this._dataIndex < 0)
			{
				StockProcMoney stockProcMoney = new StockProcMoney();

				// �V�K���[�h
				this.Mode_Label.Text = INSERT_MODE;

				//�N���[���쐬
				this._stockProcMoneyClone = stockProcMoney.Clone();

				//��ʏ����r�p�N���[���ɃR�s�[����@�@�@�@�@   
				DispToStockProcMoney(ref this._stockProcMoneyClone);

				// �t�H�[�J�X�ݒ�(�[�������Ώۋ��z�敪)
				this.fracProcMoneyDiv_tComboEditor1.Focus();
			}
			else
			{
				// �\�����擾
				Guid guid = (Guid)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._dataIndex][GUID_TITLE];
				StockProcMoney stockProcMoney = (StockProcMoney)this._stockProcMoneyTable[guid];

				// ���z�\���ύX�`�F�b�N
				MoneyVisibleChange(stockProcMoney.FracProcMoneyDiv);

				// ��ʓW�J����
				StockProcMoneyToScreen(stockProcMoney);

				if (stockProcMoney.LogicalDeleteCode == 0)
				{
					// �X�V���[�h
					this.Mode_Label.Text = UPDATE_MODE;

					//�N���[���쐬
					this._stockProcMoneyClone = stockProcMoney.Clone();
					
					//��ʏ����r�p�N���[���ɃR�s�[����@�@�@�@�@   
					DispToStockProcMoney(ref this._stockProcMoneyClone);

					this.fracProcMoneyDiv_tComboEditor1.Enabled = false;	// ���͕s��(�[�������Ώۋ��z�敪)
					this.fractionProcCode_tNedit1.Enabled		= false;	// ���͕s��(�[�������R�[�h)
					this.upperLimitPrice_tNedit2.Enabled		= false;	// ���͕s��(������z)

					// �t�H�[�J�X�ݒ�(�[�������P��)
					this.fractionProcUnit_tNedit3.Focus();
				}
				else
				{
					// �폜���[�h
					this.Mode_Label.Text = DELETE_MODE;
					
					this.fracProcMoneyDiv_tComboEditor1.Enabled = false;	// ���͕s��(�[�������Ώۋ��z�敪)
					this.fractionProcCode_tNedit1.Enabled		= false;	// ���͕s��(�[�������R�[�h)
					this.upperLimitPrice_tNedit2.Enabled		= false;	// ���͕s��(������z)
					this.fractionProcUnit_tNedit3.Enabled		= false;	// ���͕s��(�[�������P��)
					this.fractionProcCd_tComboEditor2.Enabled	= false;	// ���͕s��(�[�������敪)
					
					// �t�H�[�J�X(�폜�{�^��)
					this.Delete_Button.Focus();
				}
			}

			//_dataIndex�o�b�t�@�ێ�
			this._indexBuf = this._dataIndex;
		}

		/// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <param name="enabled">���͋��ݒ�l</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void ScreenInputPermissionControl(int setType)
		{
			switch (setType)
			{
				// 0:�V�K
				// 1:�X�V
				case 0:
				case 1:
					{
						// �{�^��
						this.Delete_Button.Visible	= false;
						this.Revive_Button.Visible	= false;
						this.Ok_Button.Visible		= true;
						this.Cancel_Button.Visible	= true;

						break;
					}
				// 2:�폜
				case 2:
					{
						// �{�^��
						this.Delete_Button.Visible	= true;
						this.Revive_Button.Visible	= true;
						this.Ok_Button.Visible		= false;
						this.Cancel_Button.Visible	= true;

						break;
					}
			}
		}

		/// <summary>
		/// �d�����z�����敪�ݒ�N���X��ʓW�J����
		/// </summary>
		/// <param name="stockProcMoney">�d�����z�����敪�ݒ�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void StockProcMoneyToScreen(StockProcMoney stockProcMoney)
		{
			this.fracProcMoneyDiv_tComboEditor1.Value = stockProcMoney.FracProcMoneyDiv;		// �[�������Ώۋ��z�敪
			this.fractionProcCode_tNedit1.SetInt(stockProcMoney.FractionProcCode);				// �[�������R�[�h
			this.upperLimitPrice_tNedit2.SetValue(stockProcMoney.UpperLimitPrice);				// ������z
			this.fractionProcUnit_tNedit3.SetValue(stockProcMoney.FractionProcUnit);			// �[�������P��
			this.fractionProcCd_tComboEditor2.Value = stockProcMoney.FractionProcCd;			// �[�������敪
		}

		/// <summary>
		/// ��ʏ��d�����z�����敪�ݒ�N���X�i�[����
		/// </summary>
		/// <param name="stockProcMoney">�d�����z�����敪�ݒ�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂�d�����z�����敪�ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void DispToStockProcMoney(ref StockProcMoney stockProcMoney)
		{
			if (stockProcMoney == null)
			{
				// �V�K�̏ꍇ
				stockProcMoney = new StockProcMoney();
			}

			stockProcMoney.EnterpriseCode	= this._enterpriseCode;									// ��ƃR�[�h
			stockProcMoney.FracProcMoneyDiv = (Int32)this.fracProcMoneyDiv_tComboEditor1.Value;		// �[�������Ώۋ��z�敪
			stockProcMoney.FractionProcCode = this.fractionProcCode_tNedit1.GetInt();				// �[�������R�[�h
			stockProcMoney.UpperLimitPrice	= this.upperLimitPrice_tNedit2.GetValue();				// ������z
			stockProcMoney.FractionProcUnit = this.fractionProcUnit_tNedit3.GetValue();				// �[�������P��
			stockProcMoney.FractionProcCd	= (Int32)this.fractionProcCd_tComboEditor2.Value;		// �[�������敪
		}

		/// <summary>
		/// ��ʓ��͏��s���`�F�b�N����
		/// </summary>
		/// <param name="control">�s���ΏۃR���g���[��</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private bool ScreenDataCheck(ref Control control, ref string message)
		{
			bool result = true;

			// �[�������R�[�h(�K�{���̓`�F�b�N)
			if (this.fractionProcCode_tNedit1.Text == "")
			{
				control = this.fractionProcCode_tNedit1;
				message = this.FRACTIONPROCCODE_TITLE_Label.Text + "����͂��ĉ������B";
				result = false;
			}
			// ������z(�K�{���̓`�F�b�N)
			else if (this.upperLimitPrice_tNedit2.GetValue() == 0)
			{
				control = this.upperLimitPrice_tNedit2;
				message = this.UPPERLIMITPRICE_TITLE_Label.Text + "����͂��ĉ������B";
				result = false;
			}
			// �[�������P��(�K�{���̓`�F�b�N)
			else if (this.fractionProcUnit_tNedit3.GetValue() == 0)
			{
				control = this.fractionProcUnit_tNedit3;
				message = this.FRACTIONPROCUNIT_TITLE_Label.Text + "����͂��ĉ������B";
				result = false;
			}
			return result;
		}

		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�ւ̕ۑ����s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private bool SaveProc()
		{
			Control control = null;
			string message = null;

			// �s���f�[�^���̓`�F�b�N
			if (!ScreenDataCheck(ref control, ref message))
			{
				TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
					ASSEMBLY_ID,							// �A�Z���u��ID
					message,	                            // �\�����郁�b�Z�[�W
					0,   									// �X�e�[�^�X�l
					MessageBoxButtons.OK);					// �\������{�^��

				control.Focus();
				return false;
			}

			// �d�����z�����敪�ݒ�X�V
			if (!SaveStockProcMoney())
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// �d�����z�����敪�ݒ�X�V
		/// </summary>
		/// <return>�X�V����status</return>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�̍X�V���s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
        private bool SaveStockProcMoney()
		{
			int status = 0;
			StockProcMoney stockProcMoney = new StockProcMoney();
			
			// �o�^���R�[�h���擾
			if (this._dataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._dataIndex][GUID_TITLE];
				stockProcMoney = ((StockProcMoney)this._stockProcMoneyTable[guid]).Clone();
			}

			DispToStockProcMoney(ref stockProcMoney);

			// ��������
			status = this._stockProcMoneyAcs.Write(ref stockProcMoney);

			// �G���[����
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// DataSet�X�V����
						StockProcMoneyToDataSet(stockProcMoney, this._indexBuf);
						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
					{
						//�d��
						TMsgDisp.Show(this,					// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_INFO,	// �G���[���x��
							ASSEMBLY_ID,					// �A�Z���u��ID
							ERR_DPR_MSG,					// �\�����郁�b�Z�[�W
							status,							// �X�e�[�^�X�l
							MessageBoxButtons.OK);			// �\������{�^��

						// �[�������R�[�h�փt�H�[�J�X�Z�b�g
						this.fractionProcCode_tNedit1.Focus();
						
						return false;
					}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// �r������
						ExclusiveTransaction(status);

						// UI�q��ʋ����I������
						EnforcedEndTransaction();

						return false;
					}
				default:
					{
						// �o�^���s
						TMsgDisp.Show(this,						// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
							ASSEMBLY_ID,						// �A�Z���u��ID
							this.Text,							// �v���O��������
							"SaveProc",							// ��������
							TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
							ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W
							status,								// �X�e�[�^�X�l
							this._stockProcMoneyAcs,			// �G���[�����������I�u�W�F�N�g
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
        /// �d�����z�����敪�ݒ� �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �d�����z�����敪�ݒ�Ώۃ��R�[�h���}�X�^����_���폜���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
        /// </remarks>
        private int LogicalDeleteStockProcMoney()
        {
			int status = 0;
			int dummy = 0;
			
			// �폜�Ώێd�����z�敪�ݒ�擾
			Guid guid = (Guid)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._dataIndex][GUID_TITLE];
			StockProcMoney stockProcMoney = ((StockProcMoney)this._stockProcMoneyTable[guid]).Clone();

			// �_���폜
			status = this._stockProcMoneyAcs.LogicalDelete(ref stockProcMoney);

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
						ExclusiveTransaction(status);
						break;
					}
				default:
					{
						TMsgDisp.Show(this,						// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP,		// �G���[���x��
							ASSEMBLY_ID,						// �A�Z���u��ID
							this.Text,							// �v���O��������
							"Delete",							// ��������
							TMsgDisp.OPE_HIDE,					// �I�y���[�V����
							ERR_RDEL_MSG,					    // �\�����郁�b�Z�[�W
							status,								// �X�e�[�^�X�l
							this._stockProcMoneyAcs,			// �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,				// �\������{�^��
							MessageBoxDefaultButton.Button1);	// �����\���{�^��

						break;
					}
			}
			// �t���[���X�V
			Search(ref dummy, 0);

			return status;
		}

		/// <summary>
		/// �d�����z�����敪�ݒ� �����폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�Ώۃ��R�[�h���}�X�^���畨���폜���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
        private int PhysicalDeleteStockProcMoney()
		{
			int status = 0;
			int dummy = 0;

			// �폜�Ώێd�����z�����敪�ݒ�擾
			Guid guid = (Guid)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._dataIndex][GUID_TITLE];
			StockProcMoney stockProcMoney = ((StockProcMoney)this._stockProcMoneyTable[guid]).Clone();

			// �����폜
			status = this._stockProcMoneyAcs.Delete(stockProcMoney);
			
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// DataSet�X�V�̈�
						Search(ref dummy, 0);
						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// �r������
						ExclusiveTransaction(status);

						// UI�q��ʋ����I������
						EnforcedEndTransaction();

						return status;
					}
				default:
					{
						TMsgDisp.Show(this,						// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP,		// �G���[���x��
							ASSEMBLY_ID,						// �A�Z���u��ID
							this.Text,							// �v���O��������
							"Delete_Button_Click",				// ��������
							TMsgDisp.OPE_DELETE,				// �I�y���[�V����
							ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W
							status,								// �X�e�[�^�X�l
							this._stockProcMoneyAcs,			// �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,				// �\������{�^��
							MessageBoxDefaultButton.Button1);	// �����\���{�^��

						// UI�q��ʋ����I������
						EnforcedEndTransaction();

						return status;
					}
			}
			return status;
		}

		/// <summary>
		/// �d�����z�����敪�ݒ� ��������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�Ώۃ��R�[�h�𕜊����܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.23</br>
		/// </remarks>
		private int ReviveStockProcMoney()
		{
			int status = 0;

			// �����Ώێd�����z�����敪�ݒ�擾
			Guid guid = (Guid)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._dataIndex][GUID_TITLE];
			StockProcMoney stockProcMoney = ((StockProcMoney)this._stockProcMoneyTable[guid]).Clone();

			// ����
			status = this._stockProcMoneyAcs.Revival(ref stockProcMoney);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// DataSet�W�J����
						StockProcMoneyToDataSet(stockProcMoney, this._dataIndex);
						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// �r������
						ExclusiveTransaction(status);
						return status;
					}
				default:
					{
						TMsgDisp.Show(
							this,								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
							ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
							this.Text,							// �v���O��������
							"ReviveStockProcMoney",			    // ��������
							TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
							ERR_RVV_MSG,						// �\�����郁�b�Z�[�W 
							status,								// �X�e�[�^�X�l
							this._stockProcMoneyAcs,			// �G���[�����������I�u�W�F�N�g
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

			//_dataIndex�o�b�t�@�ێ�
			this._indexBuf = -2;

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
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
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
				this._dataIndex = -1;

				// �t���[���X�V
				int dummy = 0;
				Search(ref dummy, 0);

				// ��ʃN���A����
				ScreenClear();

				// ��ʏ����ݒ菈��
				ScreenInitialSetting();

				Initial_Timer.Enabled = true;
			}
			else
			{
				this.DialogResult = DialogResult.OK;

				if (CanClose == true)
				{
					this.Close();
				}
				else
				{
					this.Hide();
				}

				//_dataIndex�o�b�t�@�ێ�
				this._indexBuf = -2;
			}
		}

		/// <summary>
		/// UI�q��ʋ����I������
		/// </summary>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�X�V�G���[����UI�q��ʋ����I���������s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void EnforcedEndTransaction()
		{
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			//_dataIndex�o�b�t�@�ێ�
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
		/// �r������
		/// </summary>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					TMsgDisp.Show(this,							// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,		// �G���[���x��
						ASSEMBLY_ID,							// �A�Z���u��ID
						ERR_800_MSG,							// �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					TMsgDisp.Show(this,							// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,		// �G���[���x��
						ASSEMBLY_ID,							// �A�Z���u��ID
						ERR_801_MSG,							// �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��

					break;
				}
			}
		}

		/// <summary>
		/// Form.Load �C�x���g(DCKON09100UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;

			this.Ok_Button.ImageList     = imageList24;
			this.Cancel_Button.ImageList = imageList24;
			this.Revive_Button.ImageList = imageList24;
			this.Delete_Button.ImageList = imageList24;

			this.Ok_Button.Appearance.Image     = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
		}

		/// <summary>
		/// Form.Closing �C�x���g(DCKON09100UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//_dataIndex�o�b�t�@�ێ�
			this._indexBuf = -2;

			// �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
		/// Control.VisibleChanged �C�x���g(DCKON09100UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void Form1_VisibleChanged(object sender, System.EventArgs e)
		{
			// ���C���t���[���A�N�e�B�u��
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
		/// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
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
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if (this.Mode_Label.Text != DELETE_MODE)
			{
				//�ۑ��m�F
				StockProcMoney compareStockProcMoney = new StockProcMoney();
				compareStockProcMoney = this._stockProcMoneyClone.Clone();  
				
				//���݂̉�ʏ����擾����
				DispToStockProcMoney(ref compareStockProcMoney);
				
				//�ŏ��Ɏ擾������ʏ��Ɣ�r
				if (!(this._stockProcMoneyClone.Equals(compareStockProcMoney)))	
				{
					//��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
					DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
						ASSEMBLY_ID, 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
						null, 					                              // �\�����郁�b�Z�[�W
						0, 					                                  // �X�e�[�^�X�l
						MessageBoxButtons.YesNoCancel);	                      // �\������{�^��

					switch(res)
					{
						case DialogResult.Yes:
						{
							if(!SaveProc()) 
							{
								return;
							}
							break;
						}
						case DialogResult.No:
						{
							break;
						}
						default:
						{
							this.Cancel_Button.Focus();
							return;
						}
					}
				}
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			//_dataIndex�o�b�t�@�ێ�
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
		/// Control.Click �C�x���g(Delete_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			DialogResult result = TMsgDisp.Show(this,	// �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_EXCLAMATION,		// �G���[���x��
				ASSEMBLY_ID,							// �A�Z���u���h�c�܂��̓N���X�h�c
				CONF_DEL_MSG,							// �\�����郁�b�Z�[�W
				0,										// �X�e�[�^�X�l
				MessageBoxButtons.OKCancel,				// �\������{�^��
				MessageBoxDefaultButton.Button2);		// �����\���{�^��

			if (result == DialogResult.OK)
			{
				// �d�����z�����敪�ݒ蕨���폜
				PhysicalDeleteStockProcMoney();
			}
			else
			{
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			//_dataIndex�o�b�t�@�ێ�
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
		/// Control.Click �C�x���g(Revive_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			// �d�����z�����敪����
			ReviveStockProcMoney();
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
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}

		/// <summary>
		/// fracProcMoneyDiv_tComboEditor1_SelectionChangeCommitted �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �[�������Ώۋ��z�敪���ω������Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.31</br>
		/// </remarks>
		private void fracProcMoneyDiv_tComboEditor1_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (fracProcMoneyDiv_tComboEditor1.Value != null)
			{
				MoneyVisibleChange((Int32)fracProcMoneyDiv_tComboEditor1.Value);
			}
		}

		/// <summary>
		/// ���z�\���ύX
		/// </summary>
		/// <param name="fracProvMoneyDiv">�[�������Ώۋ��z�敪</param>
		/// <remarks>
		/// <br>Note�@     : �[�������Ώۋ��z�敪�̑I����ύX�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.31</br>
		/// </remarks>
		private void MoneyVisibleChange(int fracProcMoneyDiv)
		{
			if (_fracProcMoneyDiv_tComboEditor1Value == fracProcMoneyDiv) return;

			if (fracProcMoneyDiv == 2)
			{
				// ������z�����_�ݒ�
				this.upperLimitPrice_tNedit2.MaxLength = MAXLENGTH_DECIMAL;
				this.upperLimitPrice_tNedit2.NullText = NULLTEXT_DECIMAL;
				this.upperLimitPrice_tNedit2.NumEdit.DecLen = NUMEDIT_DECIMAL;
				this.upperLimitPrice_tNedit2.ExtEdit.Column = EXTEDITCOLUMN_DECIMAL;

				// �[�������P�ʏ����_�ݒ�
				this.fractionProcUnit_tNedit3.MaxLength = MAXLENGTH_DECIMAL;
				this.fractionProcUnit_tNedit3.NullText = NULLTEXT_DECIMAL;
				this.fractionProcUnit_tNedit3.NumEdit.DecLen = NUMEDIT_DECIMAL;
				this.fractionProcUnit_tNedit3.ExtEdit.Column = EXTEDITCOLUMN_DECIMAL;
			}
			else
			{
				// ������z�����ݒ�
				this.upperLimitPrice_tNedit2.MaxLength = MAXLENGTH_INT;
				this.upperLimitPrice_tNedit2.NullText = NULLTEXT_INT;
				this.upperLimitPrice_tNedit2.NumEdit.DecLen = NUMEDIT_INT;
				this.upperLimitPrice_tNedit2.ExtEdit.Column = EXTEDITCOLUMN_INT;

				// �[�������P�ʐ����ݒ�
				this.fractionProcUnit_tNedit3.MaxLength = MAXLENGTH_INT;
				this.fractionProcUnit_tNedit3.NullText = NULLTEXT_INT;
				this.fractionProcUnit_tNedit3.NumEdit.DecLen = NUMEDIT_INT;
				this.fractionProcUnit_tNedit3.ExtEdit.Column = EXTEDITCOLUMN_INT;
			}

			// ������z�N���A
			this.upperLimitPrice_tNedit2.SetInt(0);

			// �[�������P�ʃN���A
			this.fractionProcUnit_tNedit3.SetInt(0);

			//----- ueno add ---------- start 2008.02.07		
			// ����ł̏ꍇ�͏�����z�Œ�
			if (fracProcMoneyDiv == 1)
			{
				this.upperLimitPrice_tNedit2.SetInt(999999999);
				this.upperLimitPrice_tNedit2.Enabled = false;
			}
			else
			{
				this.upperLimitPrice_tNedit2.Enabled = true;
			}
			//----- ueno add ---------- end 2008.02.07

            // �I�������ԍ���ێ�
            _fracProcMoneyDiv_tComboEditor1Value = fracProcMoneyDiv;
        }

		/// <summary>
		/// tArrowKeyControl1_ChangeFocus�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

            if (e.PrevCtrl.Name == "fracProcMoneyDiv_tComboEditor1")
            {
                MoneyVisibleChange((Int32)fracProcMoneyDiv_tComboEditor1.Value);
            }

            // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            switch (e.NextCtrl.Name)
            {
                case "fractionProcUnit_tNedit3":        // �[�������P��
                case "fractionProcCd_tComboEditor2":    // �[�������敪
                    {
                        if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                MoneyVisibleChange((Int32)fracProcMoneyDiv_tComboEditor1.Value);
                                e.NextCtrl = fracProcMoneyDiv_tComboEditor1;
                            }
                        }
                        break;
                    }
            }
            // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
		}

        // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // �[�������Ώۋ��z�敪
            string fracProcMoneyDiv = fracProcMoneyDiv_tComboEditor1.SelectedItem.DisplayText;
            // �[�������R�[�h
            string fractionProcCode = fractionProcCode_tNedit1.GetInt().ToString();
            // ������z
            double upperLimitPrice = upperLimitPrice_tNedit2.GetValue();

            for (int i = 0; i < this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsFracProcMoneyDiv = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[i][FRACPROCMONEYDIV_TITLE];
                string dsFractionProcCode = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[i][FRACTIONPROCCODE_TITLE];
                double dsUpperLimitPrice = (double)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[i][UPPERLIMITPRICE_TITLE];
                if ((fracProcMoneyDiv == dsFracProcMoneyDiv) &&
                    (fractionProcCode == dsFractionProcCode) &&
                    (upperLimitPrice == dsUpperLimitPrice))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̎d�����z�����敪�ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // �[�������Ώۋ��z�敪�A�[�������R�[�h�A������z�̃N���A
                        fracProcMoneyDiv_tComboEditor1.Value = 0;
                        fractionProcCode_tNedit1.SetInt(0);
                        upperLimitPrice_tNedit2.SetInt(0);
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̎d�����z�����敪�ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
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
                                // �[�������Ώۋ��z�敪�A�[�������R�[�h�A������z�̃N���A
                                fracProcMoneyDiv_tComboEditor1.Value = 0;
                                fractionProcCode_tNedit1.SetInt(0);
                                upperLimitPrice_tNedit2.SetInt(0);
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
	}
}
