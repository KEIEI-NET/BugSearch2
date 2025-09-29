//**********************************************************************//
// System           :   �r�e�D�m�d�s                                     //
// Sub System       :                                                   //
// Program name     :   ����_�C�A���O			                        //
//                  :												    //
// Name Space       :   Broadleaf.Windows.Forms							//
// Programer        :   ��{�@�E�@�@�@�@                                 //
// Date             :   2005.02.17                                      //
//----------------------------------------------------------------------//
// Update Note      :   2005.12.06 T.Ohtsuka �󎚈ʒu�I���{�^���ǉ�		// 
// Update Note      :   2006.02.01 iwamoto ��Q 1038,33�Ή��@�@�@�@�@�@	// 
// Update Note      :   2006.03.29 Y.Sasaki �ύX�v�]�Ή��@�@�@�@�@�@		// 
//                  :   �P.�o�c�e�o�̓��[�h���̐ݒ��ʃ��C�A�E�g�ύX		//
//                  :   2006.04.27 iwamoto								//
//                  :     ���[�J���Ή�									//
// Update Note      :   2006.05.01 Y.Sasaki             �@�@�@�@�@�@		// 
//                  :   �P. �I���v���O�����ʂ��ԍ� �ǉ�					//
//                  :   �Q. �K�v�Ȃ��Q��,using�̍폜        �@�@			//
//                  :   2006.06.19 iwamoto                              //
//                  :   �f�t�H���g�ݒ肪�Ȃ��ꍇ�A�󔒂ŕ\��������Q		//
//                  :   ������											//
//                  :   �R�D�e�L�X�g�o�͗p�̏o�͐ݒ�f�[�^�͔�\���ɂ���	//
//                  :   2006.09.04 ���c(20015)							//
// Update Note      :   2006.09.06 Y.Sasaki             �@�@�@�@�@�@		// 
//                  :   �P. ���[�p���f�[�^�擾���\�b�h��ReadStatic�ɕύX//
// Update Note      :   2007.05.18 Y.Sasaki             �@�@�@�@�@�@		// 
//                  :   �P. �󎚈ʒu�I���@�\�͂͂����܂��B//
// Update Note      :   2008.06.25 22018 ��ؐ��b
//                  :   �P�DPM.NS�Ή��B�v�����^�Ǘ��}�X�^���C�A�E�g�ύX�Ή��B
// Update Note      :   2010.02.05 30434 �H���b�D
//                  :   �P�D�v�����^�ݒ�̏����l�̏C��
// Update Note      :   2010.09.28 22018 ��ؐ��b
//                  :   �P�D�[���ʓ`�[�o�͐�ݒ�ɏ]���A�v�����^�̏����\���𐧌䂷��B
// Update Note      :   2011/03/18 22018 ��ؐ��b
//                  :   �P�D���[�v���O�����̃��O�o�͋@�\�Ή��B
//----------------------------------------------------------------------//
//                (c)Copyright  2005 Broadleaf SYSTEM Co,. Ltd          //
//**********************************************************************//
#define ADD20060329
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using System.Reflection;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
		
	/// <summary>
	/// SFCMN06001U(���[�I����ʁj
	/// programer : iwamoto
	/// update:20060202 iwamoto�@�_���폜�敪�Ή�
    /// <br></br>
    /// <br>Update Note: ���[�v���O�����̃��O�o�͋@�\�Ή� </br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2011/03/18</br>
    /// </summary>
	public class SFCMN06001U : System.Windows.Forms.Form
	{
		
		#region �R���|�[�l���g��`
		private Infragistics.Win.Misc.UltraButton OKButton;
		private Infragistics.Win.Misc.UltraButton CanButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox ImagecheckBox;
		private System.Windows.Forms.CheckBox PreviewcheckBox;
		private System.Windows.Forms.GroupBox groupBox3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel11;
		private System.ComponentModel.IContainer components;
		private int _DialogMode = 0;

		private OutputSetAcs rpt;
		private PrtManageAcs pma;
		private PrtPaperStAcs ppa;
		private OutputSet    ops;
		private PrtPaperSt   pps;
        // --- ADD m.suzuki 2010/09/27 ---------->>>>>
        private PosTerminalMgAcs _posTerminalMgAcs;
        private SlipOutputSetAcs _slipOutputSetAcs;
        // --- ADD m.suzuki 2010/09/27 ----------<<<<<

		private ArrayList prial;
		private Infragistics.Win.Misc.UltraLabel comentlbl;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor prtCombo;
		private Infragistics.Win.UltraWinEditors.UltraComboEditor printerCombo;
		private ArrayList prpal;
		private Broadleaf.Library.Windows.Forms.TComboEditor prtCombo1;
		private Broadleaf.Library.Windows.Forms.TComboEditor printerCombo1;
		private Infragistics.Win.Misc.UltraButton selectReport_Button;

		private ArrayList wkal = null;
        private ArrayList alPrintMngNo = null;//2006.04.27 iwa add

		#endregion
		
		#region �R���X�g���N�^
		/// <summary>
		/// ����_�C�A���O�̏������y�уC���X�^���X�������s���܂��B
		/// </summary>
		public SFCMN06001U()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();
			//
			// TODO: InitializeComponent �Ăяo���̌�ɁA�R���X�g���N�^ �R�[�h��ǉ����Ă��������B
			//
			rpt = new OutputSetAcs();
			pma = new PrtManageAcs();
			ppa = new PrtPaperStAcs();
            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
            _posTerminalMgAcs = new PosTerminalMgAcs();
            _slipOutputSetAcs = new SlipOutputSetAcs();
            // --- ADD m.suzuki 2010/09/27 ----------<<<<<
		}
		#endregion
		
		#region �����o�ϐ�
		private Hashtable PrinterInfoList = new Hashtable();
		private Hashtable _SelectPrinterInfo = new Hashtable();
		private int _EnablePreview = 1;		// 0:�v���r���[���Ȃ��@1:�v���r���[����
		private SFCMN06002C _PrintInfo;
		private int _PrintMode = 0;         //������[�h 0:ok�{�^�����������ɒ��o������s���B 1:ok�{�^���������ɒ��[�v�����^�ݒ�݂̂��Z�b�g���I�� 20050822 iwa add
		private bool _prtPosSetButtonVisible = false; // �󎚈ʒu�I���{�^���̕\�� :Default : ��\�� 2005.12.06 Ohtsuka Add
		#endregion
		
#if ADD20060329		
		#region private readonly
		private readonly Size _defaultModeSize = new Size(552,320);			// �W�����[�h��
		private readonly Size _pdfModeSize     = new Size(552,200);			// �o�c�e�o�̓��[�h
		#endregion

		#region private constant
		private const string CT_DEFAULT_TITLE      = "����ݒ�";
		private const string CT_PDFMODE_TITLE      = "�o�͐ݒ�";
		private const int CT_BUTTONINTERVAL_BOTTOM = 72;  
		#endregion
#endif
		
		#region �v���p�e�B

		
		// >>>>20050822 iwa add
		/// <summary>
		///	������[�h 0:ok�{�^�����������ɒ��o������s���B 1:ok�{�^���������ɒ��[�v�����^�ݒ�݂̂��Z�b�g���I�� 
		/// </summary>
		public int PrintMode
		{
			get{return this._PrintMode;}
			set{this._PrintMode = value;}
		}
		// <<<<20050822 iwa add

		// >>>>20050822 iwa del
		/// <summary>
		/// �_�C�A���O�\�����[�h0:�v�����^�A���[�I���@1:�v�����^�ݒ�̂݁i�ꊇ����p�j
		/// </summary>
		public int DialogMode
		{
			get{return this._DialogMode;}
			set{this._DialogMode = value;}
		}
		/// <summary>
		/// ��������v���p�e�B
		/// </summary>
		public SFCMN06002C PrintInfo
		{
			get{return this._PrintInfo;}
			set{this._PrintInfo = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public Hashtable SelectPrinterInfo
		{
			get{return _SelectPrinterInfo;}
			set{_SelectPrinterInfo = value;}
		}
		/// <summary>
		/// �v���r���[�̗L��(0:�v���r���[����@1:�v���r���[���Ȃ�)
		/// </summary>
		public int EnablePreview
		{
			get{return _EnablePreview;}
			set{_EnablePreview = value;}
		}
		/// <summary>
		/// �󎚈ʒu�I���{�^���\����\��(true:�\��,false:��\��)
		/// </summary>
		/// <br>Note   : �󎚈ʒu�ύX�\���[�����v���O�����̂�: true��ݒ肷��K�v������܂��B</br>
		/// <br>Date   : 2005.12.02 �ǉ� Ohtsuka</br>
		public bool PrtPosSetButtonVisible
		{
			get{return _prtPosSetButtonVisible;}
			set{_prtPosSetButtonVisible = value;}
		}

		#endregion
		
		#region �㏈��
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
		#endregion
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN06001U));
			this.OKButton = new Infragistics.Win.Misc.UltraButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.printerCombo1 = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.printerCombo = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ImagecheckBox = new System.Windows.Forms.CheckBox();
			this.CanButton = new Infragistics.Win.Misc.UltraButton();
			this.PreviewcheckBox = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.prtCombo1 = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
			this.prtCombo = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.comentlbl = new Infragistics.Win.Misc.UltraLabel();
			this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
			this.selectReport_Button = new Infragistics.Win.Misc.UltraButton();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.printerCombo1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.printerCombo)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.prtCombo1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.prtCombo)).BeginInit();
			this.SuspendLayout();
			// 
			// OKButton
			// 
			this.OKButton.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.OKButton.Location = new System.Drawing.Point(224, 248);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(140, 27);
			this.OKButton.TabIndex = 0;
			this.OKButton.Text = "���(&P)";
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.printerCombo1);
			this.groupBox1.Controls.Add(this.ultraLabel1);
			this.groupBox1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox1.Location = new System.Drawing.Point(24, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(504, 64);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "�v�����^";
			// 
			// printerCombo1
			// 
			appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.printerCombo1.ActiveAppearance = appearance1;
			this.printerCombo1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.printerCombo1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.printerCombo1.ItemAppearance = appearance2;
			this.printerCombo1.Location = new System.Drawing.Point(104, 22);
			this.printerCombo1.Name = "printerCombo1";
			this.printerCombo1.Size = new System.Drawing.Size(352, 24);
			this.printerCombo1.TabIndex = 4;
			this.printerCombo1.ValueChanged += new System.EventHandler(this.printerCombo_SelectedIndexChanged);
			// 
			// ultraLabel1
			// 
			this.ultraLabel1.Location = new System.Drawing.Point(16, 24);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(88, 23);
			this.ultraLabel1.TabIndex = 3;
			this.ultraLabel1.Text = "�v�����^��";
			// 
			// printerCombo
			// 
			this.printerCombo.Location = new System.Drawing.Point(112, 24);
			this.printerCombo.Name = "printerCombo";
			this.printerCombo.Size = new System.Drawing.Size(344, 21);
			this.printerCombo.TabIndex = 9;
			this.printerCombo.Visible = false;
			this.printerCombo.ValueChanged += new System.EventHandler(this.printerCombo_SelectedIndexChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ImagecheckBox);
			this.groupBox2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox2.Location = new System.Drawing.Point(24, 190);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(184, 50);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "������[�h";
			this.groupBox2.Visible = false;
			// 
			// ImagecheckBox
			// 
			this.ImagecheckBox.Checked = true;
			this.ImagecheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ImagecheckBox.Location = new System.Drawing.Point(24, 20);
			this.ImagecheckBox.Name = "ImagecheckBox";
			this.ImagecheckBox.Size = new System.Drawing.Size(152, 24);
			this.ImagecheckBox.TabIndex = 5;
			this.ImagecheckBox.Text = "�C���[�W���(&I)";
			// 
			// CanButton
			// 
			this.CanButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CanButton.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.CanButton.Location = new System.Drawing.Point(368, 248);
			this.CanButton.Name = "CanButton";
			this.CanButton.Size = new System.Drawing.Size(140, 27);
			this.CanButton.TabIndex = 7;
			this.CanButton.Text = "�L�����Z��(&C)";
			this.CanButton.Click += new System.EventHandler(this.CanButton_Click);
			// 
			// PreviewcheckBox
			// 
			this.PreviewcheckBox.Checked = true;
			this.PreviewcheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.PreviewcheckBox.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.PreviewcheckBox.Location = new System.Drawing.Point(344, 201);
			this.PreviewcheckBox.Name = "PreviewcheckBox";
			this.PreviewcheckBox.Size = new System.Drawing.Size(168, 24);
			this.PreviewcheckBox.TabIndex = 6;
			this.PreviewcheckBox.Text = "�v���r���[���(&V)";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.prtCombo1);
			this.groupBox3.Controls.Add(this.ultraLabel11);
			this.groupBox3.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox3.Location = new System.Drawing.Point(24, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(504, 88);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "���[";
			// 
			// prtCombo1
			// 
			appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.prtCombo1.ActiveAppearance = appearance3;
			this.prtCombo1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.prtCombo1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.prtCombo1.ItemAppearance = appearance4;
			this.prtCombo1.Location = new System.Drawing.Point(104, 22);
			this.prtCombo1.Name = "prtCombo1";
			this.prtCombo1.Size = new System.Drawing.Size(352, 24);
			this.prtCombo1.TabIndex = 4;
			this.prtCombo1.ValueChanged += new System.EventHandler(this.prtCombo_SelectedIndexChanged);
			// 
			// ultraLabel11
			// 
			this.ultraLabel11.Location = new System.Drawing.Point(16, 24);
			this.ultraLabel11.Name = "ultraLabel11";
			this.ultraLabel11.Size = new System.Drawing.Size(88, 23);
			this.ultraLabel11.TabIndex = 3;
			this.ultraLabel11.Text = "���[�^�C�v";
			// 
			// prtCombo
			// 
			this.prtCombo.Location = new System.Drawing.Point(112, 24);
			this.prtCombo.Name = "prtCombo";
			this.prtCombo.Size = new System.Drawing.Size(344, 21);
			this.prtCombo.TabIndex = 4;
			this.prtCombo.Visible = false;
			this.prtCombo.ValueChanged += new System.EventHandler(this.prtCombo_SelectedIndexChanged);
			// 
			// comentlbl
			// 
			this.comentlbl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.comentlbl.Location = new System.Drawing.Point(125, 64);
			this.comentlbl.Name = "comentlbl";
			this.comentlbl.Size = new System.Drawing.Size(392, 24);
			this.comentlbl.TabIndex = 5;
			// 
			// tArrowKeyControl1
			// 
			this.tArrowKeyControl1.OwnerForm = this;
			// 
			// selectReport_Button
			// 
			this.selectReport_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.selectReport_Button.Location = new System.Drawing.Point(32, 248);
			this.selectReport_Button.Name = "selectReport_Button";
			this.selectReport_Button.Size = new System.Drawing.Size(140, 27);
			this.selectReport_Button.TabIndex = 10;
			this.selectReport_Button.Text = "�󎚈ʒu�I��(&F)";
			this.selectReport_Button.Visible = false;
			this.selectReport_Button.Click += new System.EventHandler(this.selectReport_Button_Click);
			// 
			// SFCMN06001U
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this.CancelButton = this.CanButton;
			this.ClientSize = new System.Drawing.Size(544, 286);
			this.Controls.Add(this.selectReport_Button);
			this.Controls.Add(this.comentlbl);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.CanButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.PreviewcheckBox);
			this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SFCMN06001U";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "����ݒ�";
			this.Load += new System.EventHandler(this.SFCMN06001U_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.printerCombo1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.printerCombo)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.prtCombo1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.prtCombo)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		#region �G���g���|�C���g
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{			
			System.Windows.Forms.Application.Run(new SFCMN06001U());
		}
		#endregion
		
		private void SFCMN06001U_Load(object sender, System.EventArgs e)
		{
			ImageList imglist = IconResourceManagement.ImageList16;
			
			OKButton.ImageList			= imglist;
			OKButton.Appearance.Image	= Size16_Index.PRINT;
			CanButton.ImageList			= imglist;
			CanButton.Appearance.Image	= Size16_Index.BEFORE;
		
			prtCombo1.Items.Clear();
			printerCombo1.Items.Clear();

			comentlbl.Text = "";

			GetPaperInfo();
			GetPrinterInfo();
		
			// 2007.05.18 Y.Sasaki DEL
			//// �󎚈ʒu�I���{�^���̕\����\���ݒ� 2005.12.06 Ohtsuka Add
			//this.selectReport_Button.Visible = _prtPosSetButtonVisible;
			
#if ADD20060329
			// ��ʕ\���ݒ�
			this.ScreenViewSetting(this._PrintInfo.printmode);
#endif
			
			// �_�C�A���O�\�����[�h�ɂ���āA���[�I���_�C�A���O��\�����邩�ǂ�����؂�ւ���
			if ( this._DialogMode == 1 )
			{
				groupBox3.Visible = false;
				groupBox1.Top = groupBox3.Top;
			}
			else
			{
				groupBox3.Visible = true;
			}
		}
				
#if ADD20060329
		/// <summary>
		/// ��ʕ\���ݒ�
		/// </summary>
		/// <param name="printMode">�o�̓��[�h</param>
		/// <remarks>
		/// <br>Note       : �o�̓��[�h����ʕ\���ݒ���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.03.29</br>
		/// </remarks>
		private void ScreenViewSetting(int printMode)
		{
			bool isVisibled = true;
			
			// ������N���X�̈�����[�h�ɂ���ĕ\�����[�h��؂�ւ���
			switch (this._PrintInfo.printmode)
			{
				case 2:		// �o�c�e�o��
				{
					this.Size  = this._pdfModeSize;
					isVisibled = false;
					this.Text          = CT_PDFMODE_TITLE;
					this.OKButton.Text = "�o��(&P)";
					break;
				}
				default:
					this.Size = this._defaultModeSize;
					this.Text          = CT_DEFAULT_TITLE;
					this.OKButton.Text = "���(&P)";
					break;
			}

			// ��ʕ\���E��\������
			this.groupBox1.Visible       = isVisibled;					// �v�����^�I��
			this.PreviewcheckBox.Visible = isVisibled;					// �v���r���[�L��
			this.comentlbl.Visible       = isVisibled;					// �R�����g
			
			// �R���g���[���ʒu����
			this.selectReport_Button.Top = this.Height - CT_BUTTONINTERVAL_BOTTOM;
			this.OKButton.Top            = this.Height - CT_BUTTONINTERVAL_BOTTOM;
			this.CanButton.Top           = this.Height - CT_BUTTONINTERVAL_BOTTOM;
		
		}
#endif
		
		/// <summary>
		/// �v���r���[�p�o�c�e�쐬���s�֐�
		/// </summary>
		/// <param name="rpt"></param>
		/// <returns></returns>
		public int PreviewPdfmake()
		{
			int status;
			// �`�o���Ń��[�h���Ă���e�l�q�o�s�̓��e���킽���Ă��炤
			// �v�����^���͗v��Ȃ�
			this._PrintInfo.prevkbn = 0; // �v���r���[�͖���

			status = ExtraProc();
			/// ���o����
			if ( status == 0 )
			{		
				/// ������� 
				status = PrtProc();
			}
		
			return status;
		}
		/// <summary>
		/// �ꊇ����p���o����֐�
		/// </summary>
		/// <returns></returns>
		public int BatchPrint()
		{
			int status = 0;
			// �`�o���Ń��[�h���Ă���e�l�q�o�s�̓��e���킽���Ă��炤
			// �v�����^���͗v��Ȃ�
			this._PrintInfo.printmode = 3;

			status = ExtraProc();
			/// ���o����
			if ( status == 0 )
			{
				/// ������� 
				status = PrtProc();
			}
		
			return status;
		}
		
		/// <summary>
		/// �v�����^�[�����擾
		/// </summary>
		private void GetPaperInfo()
		{
		
			// FMRPT�̃t�@�C�����C�A�E�g�m���A�f�t�H���g��
			// ���[�^�C�v���擾���A�R���{�{�b�N�X�ɕ\������B
			
			int st  = 0;
			// �R���{�{�b�N�X�ɒǉ��i���j
			ops = new OutputSet();
			pps = new PrtPaperSt();
			
			prpal = new ArrayList();
            alPrintMngNo = new ArrayList();//2006.04.27 iwa add
			
			OutputSet inpara = new OutputSet();
			inpara.EnterpriseCode = this._PrintInfo.enterpriseCode;
			inpara.PgId = this._PrintInfo.kidopgid;
			inpara.PrintPaperSetCd = this._PrintInfo.PrintPaperSetCd;
			inpara.SelectInfoCode = 0;			// �I�����敪��0:���[�I���̂�		2006.09.04 ���c Add

			inpara.OutputFormFileName    = "";	//�o�̓t�@�C����
			inpara.OutputFormFileName    = "";	//�o�̓t�@�C����
			inpara.DisplayName           = "";			//�o�͖���
			inpara.ExtractionPgId        = "";		//���o�v���O����ID
			inpara.ExtractionPgClassId   = "";	//���o�v���O�����N���XID
			inpara.OutputPgId            = "";			//�o�̓v���O����ID
			inpara.OutputPgClassId       = "";		//�o�̓v���O�����N���XID
			inpara.OutConfimationMsg     = "";	//�o�͊m�F���b�Z�[�W
            
			st = rpt.SearchOutputSet(out wkal,inpara);
			
			if ( st == 0 )
			{
				foreach ( OutputSet mf in wkal )
				{
					if ( mf != null )
					{
						// 2006.09.04 ���c Add �I�����敪 0:���[ �̂ݕ\������(�e�L�X�g�͕\�����Ȃ�)
						if ( ( mf.PgId == this._PrintInfo.kidopgid ) && ( mf.LogicalDeleteCode == 0 ) && ( mf.PrintPaperSetCd ==  this._PrintInfo.PrintPaperSetCd ) && (mf.SelectInfoCode == 0))
						{
                            prpal.Add(mf);
                            prtCombo1.Items.Add(mf.DisplayName.ToString());
                        }
					}
				}
			}
			 
			// �f�t�H���g�ݒ�}�X�^���[�h
			int defcnt = 0;
			OutputSet rops = new OutputSet();
			
			if ( rpt.ReadDefault(out rops ,this._PrintInfo.enterpriseCode,this._PrintInfo.kidopgid,this._PrintInfo.PrintPaperSetCd,0) == 0 )
			{
                //>>>>2006.04.26 iwa add start
                if (rops == null)
                    defcnt = -99;//2006.06.19 iwa add
                else
                //<<<<2006.04.26 iwa add end
				    defcnt = rops.SelectPgSequenceNo;

			}else
                defcnt = -99;//2006.06.19 iwa add
		
			int cnt = 1;

            for (int lpcnt = 0; lpcnt < prpal.Count; lpcnt++ )//2006.04.26 iwa add
            {
                OutputSet mf = (OutputSet)prpal[lpcnt];//2006.04.26 iwa add

                if (((mf != null) && (mf.SelectPgSequenceNo == defcnt)) || ( defcnt == -99 ))  //2006.06.19 iwa add
                {
                    this._PrintInfo.frycd = mf.OutputPurpose;
                    this._PrintInfo.prpid = mf.OutputFormFileName;
                    this._PrintInfo.prpnm = mf.DisplayName;
                    this._PrintInfo.extrapgid = mf.ExtractionPgId;
                    this._PrintInfo.extraclassid = mf.ExtractionPgClassId;
                    this._PrintInfo.printpgid = mf.OutputPgId;
                    this._PrintInfo.printclassid = mf.OutputPgClassId;
                    //>>>> 2006.04.27 iwa add start
                    if (rops == null)
                        rops = new OutputSet();

                    if (rops.PrinterMngNo == 0)
                        ops.PrinterMngNo = mf.PrinterMngNo;
                    else
                    {
                        ops.PrinterMngNo = rops.PrinterMngNo;
                        mf.PrinterMngNo = ops.PrinterMngNo;
                    }
                    //<<<< 2006.04.27 iwa add end

                    comentlbl.Text = mf.OutConfimationMsg;
                    prtCombo1.Text = this._PrintInfo.prpnm;

                    if (mf.PrintPaperCode != 0)
                    {

											//if (ppa.Read(out pps, this._PrintInfo.enterpriseCode, mf.PrintPaperCode) == 0)		2006.09.06 Y.Sasaki CHG
												if (ppa.ReadStaticMemory(out pps, this._PrintInfo.enterpriseCode, mf.PrintPaperCode) == 0)
												{
                            this._PrintInfo.px = pps.PrintPaperCol;
                            this._PrintInfo.py = pps.PrintPaperRow;
                            //>>>>2006.02.01 iwa add start
                            if (pps.PrtPreviewExistCode == 0)
                                PreviewcheckBox.Checked = false;
                            else
                                PreviewcheckBox.Checked = true;
                            //<<<<2006.02.01 iwa add end
                        }
                        else
                        {
                            this._PrintInfo.px = 0;
                            this._PrintInfo.py = 0;
                        }
                        
                    }
                    break;
                }
                cnt++;
            }
			prtCombo1.SelectedIndex = cnt-1;

		}
		/// <summary>
		/// �v�����^�[�����擾
		/// </summary>
		private void GetPrinterInfo()
		{
			prial = new ArrayList();
			int aricnt = 0;
            // DEL 2010/02/05 MANTIS�Ή�[14971]�F�v�����^�ݒ�̏����l�̏C�� ---------->>>>>
            //if ( pma.SearchAll(out prial ,this._PrintInfo.enterpriseCode) == 0 )
            //{
            // DEL 2010/02/05 MANTIS�Ή�[14971]�F�v�����^�ݒ�̏����l�̏C�� ----------<<<<<
            // ADD 2010/02/05 MANTIS�Ή�[14971]�F�v�����^�ݒ�̏����l�̏C�� ---------->>>>>
            ArrayList printerList = new ArrayList();
            if (pma.SearchAll(out printerList, this._PrintInfo.enterpriseCode) == 0)
			{
                // �_���폜����Ă���v�����^�ݒ�}�X�^�f�[�^�͖���
                foreach (PrtManage prtManage in printerList)
                {
                    if (!prtManage.LogicalDeleteCode.Equals(0)) continue;
                    prial.Add(prtManage);
                }
            // ADD 2010/02/05 MANTIS�Ή�[14971]�F�v�����^�ݒ�̏����l�̏C�� ----------<<<<<
				foreach( PrtManage mf in prial )
				{
					if ( mf != null )
					{
						if ( mf.LogicalDeleteCode == 0 )//20060202 iwa add
						{//20060202 iwa add
							this.printerCombo1.Items.Add(mf.PrinterName);
                            alPrintMngNo.Add(mf.PrinterMngNo);//2006.04.27 iwa add
                            aricnt++;
						}//20060202 iwa add
					}
				}
			}
            
			int cnt = 1;
			if ( aricnt != 0 )
			{
                // --- ADD m.suzuki 2010/09/27 ---------->>>>>
                int status;

                // �[���ԍ����擾
                int cashRegisterNo = 0;
                status = _posTerminalMgAcs.GetCashRegisterNo( out cashRegisterNo, _PrintInfo.enterpriseCode );
                if ( status == 0 )
                {
                    // �[���ʓ`�[�o�͐�ݒ���Q�Ɓi���v�����^�̃f�t�H���g�\���𐧌�j
                    SlipOutputSet slipOutputSet;
                    status = _slipOutputSetAcs.Read( out slipOutputSet, _PrintInfo.enterpriseCode, cashRegisterNo, "0000", 0, 99, _PrintInfo.kidopgid );

                    if ( status == 0 && slipOutputSet != null && slipOutputSet.LogicalDeleteCode == 0 )
                    {
                        // --- UPD m.suzuki 2010/10/12 ---------->>>>>
                        //// �v�����^�Ǘ��ԍ����Z�b�g
                        //ops.PrinterMngNo = slipOutputSet.PrinterMngNo;

                        // �[���ʓ`�[�o�͐�ݒ�̃v�����^���_���폜����Ă��Ȃ����`�F�b�N
                        // �i�����X�g�ɑ��݂���Ȃ�OK�Ƃ݂Ȃ��j
                        foreach ( PrtManage mf in prial )
                        {
                            if ( (mf != null) && (mf.PrinterMngNo == slipOutputSet.PrinterMngNo) )
                            {
                                // �v�����^�Ǘ��ԍ����Z�b�g
                                ops.PrinterMngNo = slipOutputSet.PrinterMngNo;
                                break;
                            }
                        }
                        // --- UPD m.suzuki 2010/10/12 ----------<<<<<
                    }
                }
                // --- ADD m.suzuki 2010/09/27 ----------<<<<<

                // --- DEL m.suzuki 2010/09/27 ---------->>>>>
                ////���󔒂�����邽�߂O�̏ꍇ�͂P�Z�b�g
                //if (ops.PrinterMngNo == 0) //2006.04.27 iwa add
                //    ops.PrinterMngNo = 1;//2006.04.27 iwa add
                // --- DEL m.suzuki 2010/09/27 ----------<<<<<
                // --- DEL m.suzuki 2010/09/27 ---------->>>>>
                //if ( ops.PrinterMngNo != 0 )
                // --- DEL m.suzuki 2010/09/27 ----------<<<<<
				{
                    
                    // --- ADD m.suzuki 2010/09/27 ---------->>>>>
                    int selectedIndex = -1;
                    // --- ADD m.suzuki 2010/09/27 ----------<<<<<

					foreach( PrtManage mf in prial )
					{
                        // --- UPD m.suzuki 2010/09/27 ---------->>>>>
                        //if ( ( mf != null ) && ( cnt == ops.PrinterMngNo ))
                        if ( (mf != null) && ((mf.PrinterMngNo == ops.PrinterMngNo) || (ops.PrinterMngNo <= 0)) )
                        // --- UPD m.suzuki 2010/09/27 ----------<<<<<
						{						
							this.printerCombo1.Text = mf.PrinterName;
							this._PrintInfo.prinm = mf.PrinterName;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/25 DEL
                            //if ( mf.SvfCtlCodeUseCode == 1 )
                            //{
                            //    this._PrintInfo.svfpricd = mf.ImgPrtSvfCtlCode;
                            //}
                            //else
                            //{
                            //    this._PrintInfo.svfpricd = mf.DefaultSvfCtlCode;
                            //}
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/25 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/25 ADD
                            this._PrintInfo.svfpricd = string.Empty;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/25 ADD
                            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
                            selectedIndex = cnt-1;
                            // --- ADD m.suzuki 2010/09/27 ----------<<<<<

							break;
						}
						cnt++;
					}

                    // --- UPD m.suzuki 2010/09/27 ---------->>>>>
                    //this.printerCombo1.SelectedIndex = cnt-1;
                    if ( selectedIndex < 0 )
                    {
                        // �擪��I��
                        selectedIndex = 0;
                        if ( prial.Count > 0 )
                        {
                            this.printerCombo1.Text = ((PrtManage)prial[0]).PrinterName;
                            this._PrintInfo.prinm = ((PrtManage)prial[0]).PrinterName;
                        }
                        this._PrintInfo.svfpricd = string.Empty;
                    }
                    // �v�����^�I����K�p
                    this.printerCombo1.SelectedIndex = selectedIndex;
                    // --- UPD m.suzuki 2010/09/27 ----------<<<<<
				}
			}
			else
			{
				this.printerCombo1.Text = "�f�t�H���g�v�����^";
				this._PrintInfo.svfpricd = "";
				this._PrintInfo.prinm    = "";

                // TODO:�v�����^�ݒ�}�X�^�ɗL���ȃf�[�^���Ȃ��ꍇ
			}
		}
		
		/// <summary>
		/// �v�����^�[���̏ڍׂ�\��
		/// </summary>
		/// <param name="PrinterName"></param>
		private void SetPrinterInfo(string PrinterName)
		{
			// �v�����^���̂��L�[�Ƀv�����^�����擾
			Hashtable SelectPrinterInfo = (Hashtable)PrinterInfoList[PrinterName];
			_SelectPrinterInfo = SelectPrinterInfo;
			this._PrintInfo.prinm = printerCombo1.Text.Trim();

		}
		
		/// <summary>
		/// �R���{���ύX���ꂽ�Ƃ��̏���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PrinterCombo_SelectionChanged(object sender, System.EventArgs e)
		{
			// �ύX���ꂽ�v�����^�̏���\��
			SetPrinterInfo(printerCombo1.Text.Trim());
		}
		/// <summary>
		/// �n�j�{�^������������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OKButton_Click(object sender, System.EventArgs e)
		{
			int status = 0; ;

			// �C���[�W����`�F�b�N�{�b�N�X�̒l���i�[
			if (PreviewcheckBox.Checked)
			{
				_EnablePreview = 1;
				this._PrintInfo.prevkbn = 1;
			}
			else
			{
				_EnablePreview = 0;
				this._PrintInfo.prevkbn = 0;
			}

			if (this._PrintMode == 0)//20050822 iwa add
			{						   //20050822 iwa add

				// �ꊇ����̏ꍇ�͒��o����͍s��Ȃ��ŏI��
				if (this._DialogMode != 1)
				{
					status = ExtraProc();
					/// ���o����
					if (status == 0)
					{
						/// ������� 
						status = PrtProc();
					}
				}

			}
			else                     //20050822 iwa add
				status = 0;           //20050822 iwa add

			// �f�t�H���g�ݒ�}�X�^���X�V

			OutputSet wk = new OutputSet();
			int selcnt = 1;
			int ret = 0;
			foreach (OutputSet mf in prpal)
			{
				if ((mf != null) && (selcnt == prtCombo1.SelectedIndex + 1))
				{
					wk = mf.Clone();
					//>>>2006.04.27 iwa add start
					int[] prtmng = (int[])alPrintMngNo.ToArray(typeof(int));
					if (printerCombo1.SelectedIndex != -1)
						wk.PrinterMngNo = prtmng[printerCombo1.SelectedIndex];
					else
						wk.PrinterMngNo = 1;
					//<<<2006.04.27 iwa add end

					ret = rpt.WriteDefault(ref wk);

					// >>>>> 2006.05.01 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
					// PrintInfo�̑I���v���O�����ʂ��ԍ����X�V
					this._PrintInfo.SelectPgSequenceNo = wk.SelectPgSequenceNo; 
					// <<<<< 2006.05.01 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
				}
				selcnt++;
			}


			if (status == 0)
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
			else
				this.DialogResult = System.Windows.Forms.DialogResult.Abort;

			Close();
		}
		
		/// <summary>
		/// ���o���W�b�N
		/// </summary>
		//private int ExtraProc() 20050822 iwa del
		public int ExtraProc() //20050822 iwa add
		{
			int status;
			status = 0;
			// printinfo�Ɋi�[
			string AssemblyID = "";
			string ClassID    = "";
			object ob = null;
			///���o����
			if ( this._PrintInfo.extrapgid != null )
			{
		
				if ( this._PrintInfo.extrapgid.ToString().Trim() != "" )
				{
					//���o�c�k�k�����t���N�V����
					//����c�k�k�����t���N�V����
					AssemblyID = this._PrintInfo.extrapgid.ToString(); 
					AssemblyID += ".DLL";
					ClassID    = this._PrintInfo.extraclassid.ToString();
			
					// �A�Z���u���̃��[�h
					try
					{
						
						Assembly assm = Assembly.LoadFrom(AssemblyID);
		
						// �A�Z���u�����̃N���X���擾���܂��B
						// �l�[���X�y�[�X���܂߂����S�ȃN���X���Ŏw�肷��K�v������܂��B
						System.Type type = assm.GetType(ClassID);
		
						if( type != null)
						{
                            // --- ADD m.suzuki 2011/03/18 ---------->>>>>
                            // 2:���,1:PDF
                            int operationCode = (_PrintInfo.printmode == 2) ? 1 : 2;
                            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
                            operationHistoryLog.WriteOperationLog( this, LogDataKind.OperationLog, "SFANL07200U", _PrintInfo.prpnm, "", operationCode, 0, "���o�J�n", "" );
                            // --- ADD m.suzuki 2011/03/18 ----------<<<<<

							// �N���X�𓮓I�ɍ쐬���܂��B
							object instance = Activator.CreateInstance(type,new object[]{this._PrintInfo});
							// �N���X���̃��\�b�h���擾���ČĂяo���܂��B
							MethodInfo method = type.GetMethod("ExtrPrintData",new Type[0]);
							ob = method.Invoke(instance,null);

							status = (int)ob;

                            // --- ADD m.suzuki 2011/03/18 ---------->>>>>
                            operationHistoryLog.WriteOperationLog( this, LogDataKind.OperationLog, "SFANL07200U", _PrintInfo.prpnm, "", operationCode, 0, "���o�I��", "" );
                            // --- ADD m.suzuki 2011/03/18 ----------<<<<<
						}												
					}
					catch(Exception ex)
					{
						MessageBox.Show(ex.Message, "�G���[");
					}		
				}
			}
			return status;
		}
		
		/// <summary>
		/// ������W�b�N
		/// </summary>
		public int PrtProc() //20050822 iwa add
		{
			int status = 0;
		
			object ob = null;
			string AssemblyID = "";
			string ClassID    = "";
			///�������
			if ( this._PrintInfo.printpgid != null )
			{
				if ( this._PrintInfo.printpgid.ToString().Trim() != "" )
				{
					//����c�k�k�����t���N�V����
					AssemblyID = this._PrintInfo.printpgid.ToString(); 
					AssemblyID += ".DLL";
					ClassID = this._PrintInfo.printclassid.ToString();			
					// �A�Z���u���̃��[�h
					try
					{						
						Assembly assm = Assembly.LoadFrom(AssemblyID);
						// �A�Z���u�����̃N���X���擾���܂��B
						// �l�[���X�y�[�X���܂߂����S�ȃN���X���Ŏw�肷��K�v������܂��B
						System.Type type = assm.GetType(ClassID);			
						if( type != null)
						{
							// �N���X�𓮓I�ɍ쐬���܂��B
							object instance = Activator.CreateInstance(type,new object[]{this._PrintInfo});
							MethodInfo method = type.GetMethod("StartPrint",new Type[0]);
							ob = method.Invoke(instance,null);			

							status = (int)ob;
						}						
					}
					catch(Exception ex)
					{
						MessageBox.Show(ex.Message, "�G���[");
					}
				}
			}
			return status;
		}

		/// <summary>
		/// �L�����Z���{�^������������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CanButton_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			Close();				
		}
		
		/// <summary>
		/// �v���p�e�B�{�^������������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PropButton_Click(object sender, System.EventArgs e)
		{
			// �v���p�e�B��\�������܂�
		}
		/// <summary>
		/// ���[�^�C�v�ύX�{�^���N���b�N
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PaperBtn_Click(object sender, System.EventArgs e)
		{
			// �@���[�ݒ�}�X�^�����[�h
		
			// �A���[�ݒ�}�X�^�ɂ���v�����^�𔻒f���ăv�����^�ݒ���ă��[�h���A
			// �@��ʕ\��
		}

		/// <summary>
		/// ���[�^�C�v�ύX
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void prtCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int selcnt = 0;

			selcnt = prtCombo1.SelectedIndex;

			//if ( selcnt != 0 )
				selcnt++;

			int cnt = 1;
			foreach ( OutputSet mf in prpal )
			{
				if ( ( mf != null ) && ( cnt  == selcnt ) )
				{
					
					this._PrintInfo.frycd = mf.OutputPurpose;
					this._PrintInfo.prpid = mf.OutputFormFileName;
					this._PrintInfo.prpnm = mf.DisplayName;
					this._PrintInfo.extrapgid = mf.ExtractionPgId;
					this._PrintInfo.extraclassid = mf.ExtractionPgClassId;
					this._PrintInfo.printpgid    = mf.OutputPgId;
					this._PrintInfo.printclassid = mf.OutputPgClassId;
					ops.PrinterMngNo = mf.PrinterMngNo;
					comentlbl.Text = mf.OutConfimationMsg;		
					prtCombo1.Text = this._PrintInfo.prpnm;

					if ( mf.PrintPaperCode != 0 )
					{

//						if (ppa.Read(out pps, this._PrintInfo.enterpriseCode, mf.PrintPaperCode) == 0)		2006.09.06 Y.Sasaki CHG
							if (ppa.ReadStaticMemory(out pps, this._PrintInfo.enterpriseCode, mf.PrintPaperCode) == 0)
							{
							this._PrintInfo.px = pps.PrintPaperCol;
							this._PrintInfo.py = pps.PrintPaperRow;
							//>>>>2006.02.01 iwa add start
							if ( pps.PrtPreviewExistCode == 0 )
								PreviewcheckBox.Checked = false;
							else
								PreviewcheckBox.Checked = true;
							//<<<<2006.02.01 iwa add end
						}
						else
						{
							this._PrintInfo.px = 0;
							this._PrintInfo.py = 0;
						}
                        
					}

				}
				cnt++;
			}
		
		}
		
		/// <summary>
		/// �v�����^�ύX
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void printerCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int selcnt;
			
			selcnt = printerCombo1.SelectedIndex;
			
			selcnt++;
			
			int cnt = 1;
			if ( selcnt != 0 )
			{
                
				foreach( PrtManage mf in prial )
				{
					if ( ( mf != null ) && ( cnt == selcnt ))
					{						
						this.printerCombo1.Text = mf.PrinterName;
						this._PrintInfo.prinm = mf.PrinterName;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/25 DEL
                        //if ( mf.SvfCtlCodeUseCode == 1 )
                        //{
                        //    this._PrintInfo.svfpricd = mf.ImgPrtSvfCtlCode;
                        //}
                        //else
                        //{
                        //    this._PrintInfo.svfpricd = mf.DefaultSvfCtlCode;
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/25 DEL
			            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/25 ADD
                        this._PrintInfo.svfpricd = string.Empty;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/25 ADD
					}
					cnt++;
				}
                 
			}
		}

		/// *******************************************************************************
		/// <summary>
		/// �󎚈ʒu�I���{�^���I������
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note			:	������̏����l�I�𒠕[�̊m��E�T�[�o�[�̈󎚈ʒu���̎擾���s���܂��B</br>
		/// <br>Programmer		:	T.Ohtsuka</br>
		/// <br>Date			:	2005.12.06</br>
		/// </remarks>
		/// **********************************************************************
		private void selectReport_Button_Click(object sender, System.EventArgs e)
		{
			// 2007.05.18 Y.Sasaki DEL
			//// �󎚈ʒu�I��UI�v���O�������N������  "SFCMN00296U.DLL"
			//SFCMN00296UA selectPrtPosSet = new SFCMN00296UA(); 

			//// ����֘A�̏���ݒ�
			//// ��ƃR�[�h�E�o�̓t�@�C����(���[ID)�E�o�͖���(��ʕ\�����[����)
			//string[] prpid = new string[1];
			//prpid[0] = PrintInfo.prpid;
			//string[] prpnm = new string[1];
			//prpnm[0] = PrintInfo.prpnm;
			//selectPrtPosSet.prtPosSelectInfo(PrintInfo.enterpriseCode,prpid,prpnm);
			
			//// �󎚈ʒu���[�I����ʂ̋N��
			//DialogResult dialogResult = selectPrtPosSet.ShowDialog();
             
		}
	}
}
