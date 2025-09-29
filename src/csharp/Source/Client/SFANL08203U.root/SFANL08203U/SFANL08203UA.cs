//**********************************************************************//
// System           :   �r�e�D�m�d�s                                    //
// Sub System       :                                                   //
// Program name     :   ����_�C�A���O			                        //
//                  :												    //
// Name Space       :   Broadleaf.Windows.Forms							//
// Programer        :   �����@���l�@�@�@�@                              //
// Date             :   2007.03.19                                      //
//----------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co,. Ltd                 //
//**********************************************************************//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using System.Reflection;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using DataDynamics.ActiveReports;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Windows.Forms
{
	#region enum
	/// <summary>
	/// �_�C�A���O���ʗ�
	/// </summary>
	public enum DialogResultCode
	{
		/// <summary>�G���[</summary>
		Error,
		/// <summary>�߂�</summary>
		Return,
		/// <summary>���R���[�̈ꗗ�\</summary>
		FreeList,
		/// <summary>���R���[�̂͂���</summary>
		FreePostCard,
	}
	#endregion
		
	/// <summary>
	/// SFANL08203U(���[�I����ʁj
	/// programer : �������l
    /// <br>Update Note : 2007.09.10 30015 ���{�@�T�B</br>
    /// <br>            :	���R���[DM�Ή�</br>
    /// <br>Update Note : 2008.03.18 30015 ���{�@�T�B</br>
    /// <br>            :	���R���[��ꎟ���ǈČ��@����_�C�A���O�N�����xUp�Ή�</br>
	/// </summary>
	public class SFANL08203U : System.Windows.Forms.Form
	{
		
		#region �R���|�[�l���g��`

        private Infragistics.Win.Misc.UltraButton CanButton;
		private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private System.Windows.Forms.CheckBox PreviewcheckBox;
		private System.Windows.Forms.GroupBox groupBox3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel11;
		private System.ComponentModel.IContainer components;
		private Infragistics.Win.Misc.UltraLabel comentlbl;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TComboEditor printerCombo1;
		private Broadleaf.Library.Windows.Forms.TComboEditor PrintType_tComboEditor;
		private Infragistics.Win.Misc.UltraLabel DMNo_ultraLabel;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.Misc.UltraButton OKButton;

		#endregion
		
		#region �R���X�g���N�^
		/// <summary>
		/// ����_�C�A���O�̏������y�уC���X�^���X�������s���܂��B
		/// </summary>
		public SFANL08203U()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();
			_prtManageAcs = new PrtManageAcs();
			_prtPaperStAcs = new PrtPaperStAcs();

		}
		#endregion

		// 2008.03.18 Hiroki.Hashimoto Add Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		#region Const
		public const string ctMsg_FreeDMList = "���R���[DM�ꗗ�\";
		public const string ctMsg_FreeDMPostCard = "���R���[DM�͂���";
		public const string ctRoot_FrePrtPSet = "\\FREEPOS\\PRTPOS\\FrePrtPSet_";
		#endregion
		// 2008.03.18 Hiroki.Hashimoto Add End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		#region �����o�ϐ�
		private Hashtable PrinterInfoList = new Hashtable();
		private Hashtable _SelectPrinterInfo = new Hashtable();
		private int _EnablePreview = 1;		                    // 0:�v���r���[���Ȃ��@1:�v���r���[����
		private SFANL08205C _PrintInfo;
        private int _DialogMode = 0;
        private List<LastPrtPrinter> _lastPrinters;                        // �ŏI����v�����^
        private LastPrtPrinterAcs _lastPrintersAcs = new LastPrtPrinterAcs(); // 

///// 2007.09.10 Hiroki.Hashimoto Add Sta
		private DialogResultCode _dialogResultCode;           // �_�C�A���O���U���g�R�[�h
		private int _SelectFlag; // �I���t���O�i10:���[,20:DM�j
		private List<FrePrtPSet> _frePrtPSetList; // �󎚈ʒu�ݒ胊�X�g
		//private List<FrePrtPSet> _frePrtPSetListPrint; // �󎚈ʒu�ݒ胊�X�g(�ꗗ�\) // 2008.03.18 Hiroki.Hashimoto Del
		//private List<FrePrtPSet> _frePrtPSetPostCard; // �󎚈ʒu�ݒ胊�X�g(�͂���) // 2008.03.18 Hiroki.Hashimoto Del
		private FrePrtPSet _frePrtPSet = null;
///// 2007.09.10 Hiroki.Hashimoto Add End

        private PrtManageAcs _prtManageAcs;
        private PrtPaperStAcs _prtPaperStAcs;
        private PrtPaperSt _prtPaperSt;            //���[�p���ݒ�
        private ArrayList prial;                   //�v�����^���
        private ArrayList alPrintMngNo = null;     //�v�����^���̃R���N�V����
        private string _printerNm = "";
        private object[] _prtItemSetLs = new object[1];  //�󎚍��ڐݒu�̃��X�g
        #endregion
		
		#region private readonly
		private readonly Size _defaultModeSize = new Size(552,320);			// �W�����[�h��
		private readonly Size _pdfModeSize     = new Size(552,200);			// �o�c�e�o�̓��[�h
		#endregion

		#region private constant
		private const string CT_DEFAULT_TITLE      = "����ݒ�";
		private const string CT_PDFMODE_TITLE      = "�o�͐ݒ�";
		private const int CT_BUTTONINTERVAL_BOTTOM = 72;
		#endregion
		
		#region �v���p�e�B
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
		public SFANL08205C PrintInfo
		{
			get{return this._PrintInfo;}
			set
            {
                this._PrintInfo = value;
                if((_PrintInfo!= null) && (_printerNm != ""))
                  this._PrintInfo.prinm = _printerNm;
            }
		}

		/// <summary>
		/// �v�����^���
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
		/// �I���t���O(10:���[,20:DM)
		/// </summary>
		public int SelectFlag
		{
			get { return _SelectFlag; }
			set { _SelectFlag = value; }
		}

		/// <summary>
		/// �󎚈ʒu�ݒ胊�X�g
		/// </summary>
		public List<FrePrtPSet> frePrtPSetList
		{
			get { return _frePrtPSetList; }
			set { _frePrtPSetList = value; }
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
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFANL08203U));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.printerCombo1 = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.CanButton = new Infragistics.Win.Misc.UltraButton();
			this.PreviewcheckBox = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.comentlbl = new Infragistics.Win.Misc.UltraLabel();
			this.PrintType_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
			this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
			this.OKButton = new Infragistics.Win.Misc.UltraButton();
			this.DMNo_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
			this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.printerCombo1)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PrintType_tComboEditor)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.printerCombo1);
			this.groupBox1.Controls.Add(this.ultraLabel1);
			this.groupBox1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox1.Location = new System.Drawing.Point(24, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(504, 64);
			this.groupBox1.TabIndex = 1;
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
			this.printerCombo1.TabIndex = 0;
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
			// CanButton
			// 
			this.CanButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CanButton.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.CanButton.HotTrackAppearance = appearance3;
			this.CanButton.Location = new System.Drawing.Point(368, 232);
			this.CanButton.Name = "CanButton";
			this.CanButton.Size = new System.Drawing.Size(140, 27);
			this.CanButton.TabIndex = 4;
			this.CanButton.Text = "�L�����Z��(&C)";
			this.CanButton.Click += new System.EventHandler(this.CanButton_Click);
			// 
			// PreviewcheckBox
			// 
			this.PreviewcheckBox.Checked = true;
			this.PreviewcheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.PreviewcheckBox.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.PreviewcheckBox.Location = new System.Drawing.Point(344, 192);
			this.PreviewcheckBox.Name = "PreviewcheckBox";
			this.PreviewcheckBox.Size = new System.Drawing.Size(168, 24);
			this.PreviewcheckBox.TabIndex = 2;
			this.PreviewcheckBox.Text = "�v���r���[���(&V)";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.comentlbl);
			this.groupBox3.Controls.Add(this.PrintType_tComboEditor);
			this.groupBox3.Controls.Add(this.ultraLabel11);
			this.groupBox3.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox3.Location = new System.Drawing.Point(24, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(504, 88);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "���[";
			// 
			// comentlbl
			// 
			this.comentlbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this.comentlbl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.comentlbl.Location = new System.Drawing.Point(106, 52);
			this.comentlbl.Name = "comentlbl";
			this.comentlbl.Size = new System.Drawing.Size(392, 24);
			this.comentlbl.TabIndex = 0;
			// 
			// PrintType_tComboEditor
			// 
			appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.PrintType_tComboEditor.ActiveAppearance = appearance4;
			appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.PrintType_tComboEditor.ItemAppearance = appearance5;
			this.PrintType_tComboEditor.Location = new System.Drawing.Point(104, 22);
			this.PrintType_tComboEditor.Name = "PrintType_tComboEditor";
			this.PrintType_tComboEditor.Size = new System.Drawing.Size(352, 24);
			this.PrintType_tComboEditor.TabIndex = 0;
			this.PrintType_tComboEditor.ValueChanged += new System.EventHandler(this.PrintType_tComboEditor_ValueChanged);
			// 
			// ultraLabel11
			// 
			this.ultraLabel11.Location = new System.Drawing.Point(16, 24);
			this.ultraLabel11.Name = "ultraLabel11";
			this.ultraLabel11.Size = new System.Drawing.Size(88, 23);
			this.ultraLabel11.TabIndex = 3;
			this.ultraLabel11.Text = "���[����";
			// 
			// tArrowKeyControl1
			// 
			this.tArrowKeyControl1.OwnerForm = this;
			// 
			// OKButton
			// 
			this.OKButton.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.OKButton.HotTrackAppearance = appearance7;
			this.OKButton.Location = new System.Drawing.Point(224, 232);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(140, 27);
			this.OKButton.TabIndex = 3;
			this.OKButton.Text = "���(&P)";
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// DMNo_ultraLabel
			// 
			appearance6.ForeColor = System.Drawing.Color.Red;
			this.DMNo_ultraLabel.Appearance = appearance6;
			this.DMNo_ultraLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.DMNo_ultraLabel.Location = new System.Drawing.Point(24, 185);
			this.DMNo_ultraLabel.Name = "DMNo_ultraLabel";
			this.DMNo_ultraLabel.Size = new System.Drawing.Size(307, 36);
			this.DMNo_ultraLabel.TabIndex = 9;
			this.DMNo_ultraLabel.Text = "DM�p�^�[����ݒ肵�Ă��Ȃ��ꍇ�́A\r\n����Ɉ󎚂���Ȃ��ꍇ������܂��B";
			// 
			// tRetKeyControl1
			// 
			this.tRetKeyControl1.OwnerForm = this;
			this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
			// 
			// SFANL08203U
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this.ClientSize = new System.Drawing.Size(544, 268);
			this.Controls.Add(this.DMNo_ultraLabel);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.CanButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.PreviewcheckBox);
			this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SFANL08203U";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "����ݒ�";
			this.Load += new System.EventHandler(this.SFANL08203U_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.printerCombo1)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PrintType_tComboEditor)).EndInit();
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
			System.Windows.Forms.Application.Run(new SFANL08203U());
		}
		#endregion

        #region �_�C�A���O���[�h�C�x���g
        /// <summary>
        /// �_�C�A���O���[�h�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFANL08203U_Load(object sender, System.EventArgs e)
		{
            //�{�^���̃A�C�R����ݒ�
			ImageList imglist = IconResourceManagement.ImageList16;
			OKButton.ImageList			= imglist;
			OKButton.Appearance.Image	= Size16_Index.PRINT;
			CanButton.ImageList			= imglist;
			CanButton.Appearance.Image	= Size16_Index.BEFORE;
            //�R���|�[�l���g������
            printerCombo1.Items.Clear();
			comentlbl.Text = "";

			// 2008.03.18 Hiroki.Hashimoto Del Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

			// �ǂ̒��[�ɑ΂��Ẵ_�C�A���O�����f���ďo���B
			// this.GetPaperInfo(this.SelectFlag); // 2007.09.10 Hiroki.Hashimoto Add 

			// 2008.03.18 Hiroki.Hashimoto Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			// 2008.03.18 Hiroki.Hashimoto Add Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			if (this.SelectFlag == 10)
			{
				this.GetPaperInfo();
			// 2008.03.18 Hiroki.Hashimoto Add End >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
				// �ŏI����v�����^�擾
				_lastPrintersAcs.Search(out _lastPrinters);

				//GetPaperInfo(); // 2007.09.10 Hiroki.Hashimoto Del
				GetPrinterInfo();
				// ��ʕ\���ݒ�
				this.ScreenViewSetting();
			// 2008.03.18 Hiroki.Hashimoto Add Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			}
			else
			{
				// ���[�����擾
				int st = GetPaperInfoForDM();
				if (st == 0)
				{
					// �ŏI����v�����^�擾
					_lastPrintersAcs.Search(out _lastPrinters);

					//GetPaperInfo(); // 2007.09.10 Hiroki.Hashimoto Del
					GetPrinterInfo();
					// ��ʕ\���ݒ�
					this.ScreenViewSetting();
				}
				else
				{
					_dialogResultCode = DialogResultCode.Return;
					this.Close();
				}
			}
			// 2008.03.18 Hiroki.Hashimoto Add End >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        }
        #endregion

        #region ��ʕ\���ݒ�
        /// <summary>
		/// ��ʕ\���ݒ�
		/// </summary>
		/// <remarks>
		/// <br>Note       : �o�̓��[�h����ʕ\���ݒ���s���܂��B</br>
		/// <br>Programmer : 22011 �����@���l</br>
		/// <br>Date       : 2006.03.29</br>
		/// </remarks>
		private void ScreenViewSetting()
		{
            bool isVisibled = true;

            if (DialogMode == 1)
            {
                //�ꊇ���
                groupBox1.Location = new Point(24, 8);
                isVisibled = false;
                // ��ʃT�C�Y
                this.Height = groupBox1.Top + groupBox1.Height + OKButton.Height + (PreviewcheckBox.Height) + CT_BUTTONINTERVAL_BOTTOM;
            }
            else
            {
                //�ʏ���
                groupBox1.Location = new Point(24, 112);
                isVisibled = true;
                // ��ʃT�C�Y
                this.Height = groupBox1.Top + groupBox1.Height + OKButton.Height + (PreviewcheckBox.Height * 2) + CT_BUTTONINTERVAL_BOTTOM;
            }

			// ��ʕ\���E��\������
			this.PreviewcheckBox.Visible = isVisibled;					// �v���r���[�L��
			this.groupBox3.Visible       = isVisibled;					// ���[����
			
			// �R���g���[���ʒu����
			this.OKButton.Top            = this.Height - CT_BUTTONINTERVAL_BOTTOM;
			this.CanButton.Top           = this.Height - CT_BUTTONINTERVAL_BOTTOM;
        }
        #endregion

        #region �ꊇ����p���o���
        /// <summary>
		/// �ꊇ����p���o����֐�
		/// </summary>
		/// <returns></returns>
		public int BatchPrint()
		{
			int status = 0;
			this._PrintInfo.printmode = 3;
            this._PrintInfo.prevkbn = 0;

            status = ExtraProc();
            // ���o����
            if (status == 0)
            {
                // �������
                status = PrtProc();
            }
            return status;
        }
        #endregion

        #region �_�~�[�f�[�^�v���r���[
        /// <summary>
        /// �_�~�[�f�[�^�v���r���[
        /// </summary>
        /// <param name="prtItemSetLs"></param>
        /// <param name="frePrtPset"></param>
        /// <param name="createRowCnt"></param>
        /// <param name="bgImage"></param>
        /// <returns></returns>
        public int DummyDataPreview(List<PrtItemSetWork> prtItemSetLs, FrePrtPSet frePrtPset, Int32 createRowCnt, Bitmap bgImage)
        {
            SFANL08235CB dummyRptGenerater = new SFANL08235CB();
            ActiveReport3 dummyRpt;
            ActiveReport3 prtRpt;
            int status = 0;

            // �_�~�[�f�[�^�쐬
            status = dummyRptGenerater.CreateDummyDataReport(prtItemSetLs, frePrtPset, createRowCnt, bgImage, out dummyRpt);
            if (status == 0)
            {
                //�p����ސݒ�
                SFANL08235CE.SetValidPaperKind(dummyRpt);
                // �w�i�摜�}��
                prtRpt = SFANL08235CE.OverlayImage(dummyRpt, bgImage, frePrtPset.PrtPprBgImageRowPos, frePrtPset.PrtPprBgImageColPos);
                //�p����ސݒ�
                SFANL08235CE.SetValidPaperKind(prtRpt);
                
                // -- ������� ------------------------------- 
                // ������ʏ��v���p�e�B�ݒ�
                Broadleaf.Windows.Forms.SFANL08203UD commonInfo = new SFANL08203UD();
                commonInfo.PrintMax = 0;                              // �������
                commonInfo.PrintMode = 4;                               // ��а�ް�����ޭ

                Broadleaf.Windows.Forms.SFANL08203UB viewForm = new Broadleaf.Windows.Forms.SFANL08203UB();
                // ���ʏ����ݒ�
                viewForm.CommonInfo = commonInfo;
                // �v���r���[���s
                status = viewForm.Run(prtRpt);
            }
            // �߂�l�ݒ�
            this._PrintInfo.status = status;

            return status;
        }
        #endregion

        #region �v�����^�I���_�C�A���O�\��
        /// <summary>
        /// �v�����^�I���_�C�A���O�\��
        /// </summary>
        /// <param name="owner">�I�[�i�[�E�B���h�E</param>
        public DialogResult PinrterSelectDlgShow(IWin32Window owner,string groupNm)
        {
            this.DialogMode = 1;            //�v�����^�I���̂�
			//this.PrintInfo.printmode = 1; // �����
			this.SelectFlag = 10; // ���[
			this.DMNo_ultraLabel.Visible = false;
			// UI�\���ؑ֏���
            this.Text = "����ݒ� - " + groupNm + "�ꊇ���";
			this.ChangeEnable(SelectFlag); // 2007.09.10 Hiroki.Hashimoto ADD 
            this.ShowDialog(owner);
            return this.DialogResult;
        }
        #endregion

        #region ����p�_�C�A���O�\��
        /// <summary>
        /// �v�����^�I���_�C�A���O�\��
        /// </summary>
        /// <param name="owner">�I�[�i�[�E�B���h�E</param>
        public DialogResult PinrtDlgShow(IWin32Window owner)
        {
            this.DialogMode = 0;
			this.PrintInfo.printmode = 1; // �����
            this.SelectFlag = 10; // ���[
			this.DMNo_ultraLabel.Visible = false;
            // UI�\���ؑ֏���
            this.Text = "����ݒ�";
            this.ChangeEnable(SelectFlag); // 2007.09.10 Hiroki.Hashimoto ADD 

            this.ShowDialog(owner);
            return this.DialogResult;
        }
        #endregion

        #region ���[���擾
		#region 2008.03.18 Hiroki.Hashimoto Del
		///// <summary>
		///// ���[�����擾
		///// </summary>
		//private void GetPaperInfo(int flag)
		//{
		//    //-- �R���{�{�b�N�X�ɒǉ� -------------------------------------
		//    _prtPaperSt = new PrtPaperSt();         //���[�p���ݒ�
		//    alPrintMngNo = new ArrayList();         //�v�����^����AL
			
		//    if (_PrintInfo != null)
		//    {
		//        if (_PrintInfo.outConfimationMsg != null)
		//            comentlbl.Text = _PrintInfo.outConfimationMsg;
		//        else
		//            comentlbl.Text = "";

		//        // DM�̏ꍇ
		//        if (this.SelectFlag == 20)
		//        {
		//            // ���[���̎擾����
		//            this.SearchPrintType();
		//            this.PrintType_tComboEditor.SelectedIndex = 0;
		//            FrePrtPSet frePrtPSet = (FrePrtPSet)this.PrintType_tComboEditor.SelectedItem.DataValue;
		//            comentlbl.Text = frePrtPSet.OutConfimationMsg;

		//            if (frePrtPSet.FreePrtPprSpPrpseCd == 1)
		//            {
		//                DMNo_ultraLabel.Visible = true;
		//            }
		//            else
		//            {
		//                DMNo_ultraLabel.Visible = false;
		//            }
		//        }
		//        else
		//        {
		//            if (_PrintInfo.prpnm != null)
		//            {
		//                PrintType_tComboEditor.Text = _PrintInfo.prpnm;
		//            }
		//            else
		//                PrintType_tComboEditor.Text = string.Empty;
		//        }
		//    }
		//}		
		#endregion

		#region 2008.03.18 Hiroki.Hashimoto Add
		/// <summary>
		/// ���[�����擾
		/// </summary>
		private void GetPaperInfo()
		{
		    //-- �R���{�{�b�N�X�ɒǉ� -------------------------------------
		    _prtPaperSt = new PrtPaperSt();         //���[�p���ݒ�
		    alPrintMngNo = new ArrayList();         //�v�����^����AL
		    if (_PrintInfo != null)
		    {
		        if (_PrintInfo.outConfimationMsg != null)
		            comentlbl.Text = _PrintInfo.outConfimationMsg;
		        else
		            comentlbl.Text = "";

		        if (_PrintInfo.prpnm != null)
		        {
		            //PrintTypeEdit.Text = _PrintInfo.prpnm; // 2007.09.10 Hiroki.Hashimoto Del
		            PrintType_tComboEditor.Text = _PrintInfo.prpnm; // 2007.09.10 Hiroki.Hashimoto Add
		        }
		        else
		            //PrintTypeEdit.Text = ""; // 2007.09.10 Hiroki.Hashimoto Del
		            PrintType_tComboEditor.Text = string.Empty; // 2007.09.10 Hiroki.Hashimoto Add
		    }
		}

		/// <summary>
		/// ���[�����擾(���R���[DM�p)
		/// </summary>
		private int GetPaperInfoForDM()
		{
		    //-- �R���{�{�b�N�X�ɒǉ� -------------------------------------
		    _prtPaperSt = new PrtPaperSt();         //���[�p���ݒ�
		    alPrintMngNo = new ArrayList();         //�v�����^����AL
			int st = 4;
		    if (_PrintInfo != null)
		    {
				// ���[���̎擾����
				st = this.SearchPrintType();
				if (st == 0)
				{
					this.PrintType_tComboEditor.SelectedIndex = 0;
					_frePrtPSet = (FrePrtPSet)this.PrintType_tComboEditor.SelectedItem.DataValue;
					comentlbl.Text = _frePrtPSet.OutConfimationMsg;

		            if (_frePrtPSet.FreePrtPprSpPrpseCd == 1)
		            {
		                DMNo_ultraLabel.Visible = true;
		            }
		            else
		            {
		                DMNo_ultraLabel.Visible = false;
		            }
					//FrePrtPSet frePrtPSet = (FrePrtPSet)this.PrintType_tComboEditor.SelectedItem.DataValue;

					//comentlbl.Text = frePrtPSet.OutConfimationMsg;

					//if (frePrtPSet.FreePrtPprSpPrpseCd == 1)
					//{
					//    DMNo_ultraLabel.Visible = true;
					//}
					//else
					//{
					//    DMNo_ultraLabel.Visible = false;
					//}
				}
				else
				{
					PrintInfo.status = st;
					PrintInfo.message = this.CreateMessage(PrintInfo.printPaperUseDivcd);
				}
		    }
			return st;
		}
		#endregion

		/// <summary>
		/// �v�����^�[�����擾
		/// </summary>
		private void GetPrinterInfo()
		{
			prial = new ArrayList();
			int aricnt = 0;
			if ( _prtManageAcs.Search(out prial ,LoginInfoAcquisition.EnterpriseCode) == 0 )
			{
				foreach( PrtManage mf in prial )
				{
					if ( mf != null )
					{
						if ( mf.LogicalDeleteCode == 0 )
						{
							this.printerCombo1.Items.Add(mf.PrinterMngNo,mf.PrinterName);
                            alPrintMngNo.Add(mf.PrinterMngNo);
                            aricnt++;
						}
					}
				}
			}
            
			if ( aricnt == 0 )
			{
				this.printerCombo1.Text = "�f�t�H���g�v�����^";
				// 2008.3.18 Hiroki.Hashimoto Add Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
				if(_PrintInfo != null)
				// 2008.3.18 Hiroki.Hashimoto Add End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
					this._PrintInfo.prinm    = "";
			}

            if (printerCombo1.Items.Count > 0)
            {
                LastPrtPrinter lastPrter;
                printerCombo1.SelectedIndex = 0;

                // �ŏI����v�����^�̃f�[�^������Ώ����l�Ƃ��Đݒ肷��
                if (_lastPrinters == null) return;
                if (_PrintInfo != null)
                    lastPrter = _lastPrintersAcs.FindLastPrtPrinter(_lastPrinters, DialogMode, SelectFlag, _PrintInfo.printPaperUseDivcd);
                else
                    lastPrter = _lastPrintersAcs.FindLastPrtPrinter(_lastPrinters, DialogMode, SelectFlag, 0);
               
                if (lastPrter != null)
                {
                    for (int idx = 0; idx < printerCombo1.Items.Count; idx++)
                    {
                        if ((Int32)(printerCombo1.Items[idx].DataValue) == lastPrter.PrinterMngNo)
                        {
                            printerCombo1.SelectedIndex = idx;
                            break;
                        }
                    }
                }
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
        #endregion

        #region �v�����^�ύX�C�x���g
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
        #endregion
       
        #region ���o���W�b�N
        /// <summary>
        /// ���o���W�b�N
        /// </summary>
        public int ExtraProc()
        {
            int status;
            status = 0;
            // printinfo�Ɋi�[
            string AssemblyID = "";
            string ClassID = "";
            object ob = null;
            
            ///���o����
            if (this._PrintInfo.extrapgid != null)
            {
                if (this._PrintInfo.extrapgid.ToString().Trim() != "")
                {
                    //���o�c�k�k�����t���N�V����
                    AssemblyID = this._PrintInfo.extrapgid.ToString();
                    AssemblyID += ".DLL";
                    ClassID = this._PrintInfo.extraclassid.ToString();

                    // �A�Z���u���̃��[�h
                    try
                    {
                        Assembly assm = Assembly.LoadFrom(AssemblyID);

                        // �A�Z���u�����̃N���X���擾���܂��B
                        // �l�[���X�y�[�X���܂߂����S�ȃN���X���Ŏw�肷��K�v������܂��B
                        System.Type type = assm.GetType(ClassID);

                        if (type != null)
                        {
                            // �N���X�𓮓I�ɍ쐬���܂��B
                            object instance = Activator.CreateInstance(type, new object[] { this._PrintInfo });
                            //���f�[�^���
                            MethodInfo method = type.GetMethod("ExtrPrintData", new Type[0]);
                            ob = method.Invoke(instance, null);
                            status = (int)ob;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "�G���[");
                    }
                }
            }
            return status;
        }
        #endregion

        #region ������W�b�N
        /// <summary>
		/// ������W�b�N
		/// </summary>
		public int PrtProc()
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
					catch(Exception)
					{
					}
				}
			}
			return status;
        }
        #endregion

		#region OK�{�^����������
        /// <summary>
        /// �n�j�{�^������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, System.EventArgs e)
        {
            int status = 0; ;

            // �ꊇ����̏ꍇ�͒��o����͍s��Ȃ��ŏI��
			if (this._DialogMode != 1)
			{
                // �v���r���[����`�F�b�N�{�b�N�X�̒l���i�[
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

				// 2007.10.02 Hiroki.Hashimoto Add //
				if (this.SelectFlag == 20)
				{
					// 2008.03.18 Hiroki Hashimoto Add Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
					// �t�@�C����������1��Read���s��
					try
					{
						List<FrePprECnd> frePprECndList = null;
						List<FrePprSrtO> frePprSrtOList = null;

						status = this.frePrtPosLocalAcs.ReadLocalFrePrtPSet(ref _frePrtPSet, out frePprECndList, out frePprSrtOList);
					// 2008.03.18 Hiroki Hashimoto Add End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

						// DM�̏ꍇ��PrintInfo���쐬
						_PrintInfo.InportFrePrtPSet(_frePrtPSet, _PrintInfo.enterpriseCode, _PrintInfo.kidopgid, _PrintInfo.jyoken, _PrintInfo.jyokenDtl, false);

						// ���[�`���[�g���ʕ��i�N���X
						SFCMN00331C cmnCommon = new SFCMN00331C();
						// PDF�p�X�擾
						string pdfPath = "";
						string pdfName = "";

						//PDF�o�̓t�@�C���p�X
						status = cmnCommon.GetPdfSavePathName(_PrintInfo.prpnm, ref pdfPath, ref pdfName);
						_PrintInfo.pdftemppath = pdfPath + pdfName;	//�ꗗ�\�̂Ƃ���printinfo�ɁAPDF�̏o�͐�t�H���_�����Z�b�g

					// 2008.03.18 Hiroki Hashimoto Add Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
					}
					catch(Exception)
					{
						_dialogResultCode = DialogResultCode.Error;
						return;
					}
					// 2008.03.18 Hiroki Hashimoto Add End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				}
				status = ExtraProc();   // ���o����
                if (status == 0)
                {
                    // ������� 
                    status = PrtProc();
                }
			}
			#region 2007.09.12 Hiroki.Hashimoto Add
			if (this.SelectFlag == 10)
			{
                if (status == 0)
                {
                    if(((_PrintInfo!=null) && (_PrintInfo.prevkbn == 0))||(PrintInfo == null)) 
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                    this.DialogResult = System.Windows.Forms.DialogResult.Abort;
			}
			else
			{
				switch (status)
				{
					case 0:
						// DM�ꗗ�\�ň�����H����Ƃ�DM�͂����ň�����H
						if(PrintInfo.printPaperUseDivcd == 3)
							_dialogResultCode = DialogResultCode.FreeList;
						else
							_dialogResultCode = DialogResultCode.FreePostCard;
						break;
					case -1:
						_dialogResultCode = DialogResultCode.Error;
						break;
					default:
						_dialogResultCode = DialogResultCode.Return;
						break;
				}
			}
			#endregion


            #region �ŏI����v�����^�ۑ�
            if (printerCombo1.SelectedItem != null)
            {
                LastPrtPrinter lastprtr;
                if (_PrintInfo != null)
                    lastprtr = _lastPrintersAcs.FindLastPrtPrinter(_lastPrinters, DialogMode, SelectFlag, _PrintInfo.printPaperUseDivcd);
                else
                    lastprtr = _lastPrintersAcs.FindLastPrtPrinter(_lastPrinters, DialogMode, SelectFlag, 0);

                if (lastprtr != null) _lastPrinters.Remove(lastprtr);

                lastprtr = new LastPrtPrinter();
                lastprtr.PrinterMngNo = (Int32)printerCombo1.SelectedItem.DataValue;
                lastprtr.PrinterName = printerCombo1.Text;
                lastprtr.DialogMode = DialogMode;
                lastprtr.SelectFlag = SelectFlag;
                if (_PrintInfo != null)
                    lastprtr.PrintPaperUseDivcd = _PrintInfo.printPaperUseDivcd;
                else
                    lastprtr.PrintPaperUseDivcd = 0;

                if (_lastPrinters == null) _lastPrinters = new List<LastPrtPrinter>();
                _lastPrinters.Add(lastprtr);
                _lastPrintersAcs.Write(_lastPrinters);
            }
            #endregion


            #region 2007.09.12 Hiroki.Hashimoto Del
            //if (status == 0)
			//    this.DialogResult = System.Windows.Forms.DialogResult.OK;
			//else
			//    this.DialogResult = System.Windows.Forms.DialogResult.Abort;
			#endregion
			this.Hide();
			if (this.SelectFlag == 10)
			{
				this.PrintInfo = null;
			}
        }
         #endregion

        #region �L�����Z���{�^������
        /// <summary>
		/// �L�����Z���{�^������������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CanButton_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region �v�����^�ύX
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
                        // �ꊇ����̎��͈�[�ϐ��Ɋi�[
                        if (DialogMode != 1)
                            this._PrintInfo.prinm = mf.PrinterName;
                        else
                            _printerNm = mf.PrinterName;
					}
					cnt++;
				}
			}
        }
        #endregion

///// 2007.09.10 Hiroki.Hashimoto ADD STA
		#region DM�p����_�C�A���O����
        /// <summary>
		/// DM�p����_�C�A���O�\������
		/// </summary>
		/// <returns>�񋓑�</returns>
		/// <remarks>
		/// <br>Note		: �t�H�[�����Ăяo���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 30015 ���{�@�T�B</br>
		/// <br>Date		: 2007.08.24</br>
		/// </remarks>
        public DialogResultCode ShowDialogFrePrt()
        {
			try
			{
                _dialogResultCode = DialogResultCode.Return;
				this.SelectFlag = 20; // DM

				this.ChangeEnable(SelectFlag);
				this.ShowDialog();
			}
			catch ( Exception )
			{
				_dialogResultCode = DialogResultCode.Error;
			}

			return _dialogResultCode;

        }
		#endregion

		#region UI�\���ؑ֏���
        /// <summary>
		/// UI�\���ؑ֏���
		/// </summary>
		/// <param name="targetUI">10:���[,20:DM</param>
		/// <remarks>
		/// <br>Note		: ���[���̂̕\����؂�ւ��܂��B</br>
		/// <br>Programmer	: 30015 ���{�@�T�B</br>
		/// <br>Date		: 2007.08.24</br>
		/// </remarks>
		private void ChangeEnable(int targetUI)
		{
			if (targetUI == 10)
			{
				this.PrintType_tComboEditor.Appearance.BackColorDisabled = Color.White;
				this.PrintType_tComboEditor.Appearance.ForeColorDisabled = Color.Black;
				this.PrintType_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown; // 2007.10.17 Hiroki.Hashimoto Add
				this.PrintType_tComboEditor.Enabled = false;
			}
			else
			{
				this.PrintType_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList; // 2007.10.17 Hiroki.Hashimoto Add
				this.PrintType_tComboEditor.Enabled = true;
			}
		}
		#endregion

        /// <summary>
		/// PrintType_tComboEditor_ValueChanged�C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���[���I�΂ꂽ�^�C�~���O�ň󎚈ʒu�f�[�^���擾���܂��B</br>
		/// <br>Programmer	: 30015 ���{�@�T�B</br>
		/// <br>Date		: 2007.08.24</br>
		/// </remarks>
		private void PrintType_tComboEditor_ValueChanged(object sender, EventArgs e)
		{
			if (this.PrintType_tComboEditor.SelectedIndex >= 0)
			{
				_frePrtPSet = (FrePrtPSet)this.PrintType_tComboEditor.SelectedItem.DataValue;
				// �o�͊m�F���b�Z�[�W
				comentlbl.Text = _frePrtPSet.OutConfimationMsg;

				// DM�ē�����������A���߂��o��
				if (_frePrtPSet.FreePrtPprSpPrpseCd == 1)
				{
					DMNo_ultraLabel.Visible = true;
				}
				else
				{
					DMNo_ultraLabel.Visible = false;
				}
			}
		}

///// 2007.09.10 Hiroki.Hashimoto ADD END

		// 2008.03.18 Hiroki Hashimoto Add Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		FrePrtPosLocalAcs frePrtPosLocalAcs = null;
        /// <summary>
		/// ���[���̎擾����
		/// </summary>
        /// <param name="frePrtGuideSearchRet"></param>
		/// <remarks>
		/// <br>Note		: ���[���̂��擾���܂��B</br>
		/// <br>Programmer	: 30015 ���{�@�T�B</br>
		/// <br>Date		: 2007.08.24</br>
		/// </remarks>
		private int SearchPrintType()
		{
			this.PrintType_tComboEditor.Items.Clear();

			if(frePrtPosLocalAcs == null)
				frePrtPosLocalAcs = new FrePrtPosLocalAcs();

			// �T�[�o�[����擾�������X�g��n���āA���[�J���ƃ}�[�W�������ʂ�Ԃ��Ă��炤
			List<FrePrtPSet> retList = this.frePrtPosLocalAcs.FindAllLocalDataExists(_frePrtPSetList);

			if ((retList == null) || (retList.Count == 0))
			{
				return 4;
			}
			else
			{
			    foreach (FrePrtPSet wkFrePrtPSet in retList)
			    {
			        this.PrintType_tComboEditor.Items.Add(wkFrePrtPSet, wkFrePrtPSet.DisplayName);
			    }
				return 0;
			}
		}

 		/// <summary>
		/// �G���[���b�Z�[�W�쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �G���[���b�Z�[�W��Ԃ��܂��B</br>
		/// <br>Programmer : 30015 ���{�@�T�B</br>
		/// <br>Date       : 2009.02.05</br>
		/// </remarks>
		private string CreateMessage(int printPaperUseDivcd)
		{
			string msg = string.Empty;
			if (printPaperUseDivcd == 3)
			{
				msg = "���̒[����" + ctMsg_FreeDMList + "�̈󎚈ʒu��񂪂���܂���\n�󎚈ʒu���̃_�E�����[�h���K�v�ł�";
			}
			else if (printPaperUseDivcd == 4)
			{
				msg = "���̒[����" + ctMsg_FreeDMPostCard + "�̈󎚈ʒu��񂪂���܂���\n�󎚈ʒu���̃_�E�����[�h���K�v�ł�";
			}
			return msg;
		}
		// 2008.03.18 Hiroki Hashimoto Add End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		#region 2008.03.17 Hiroki.Hashimoto Del
		//private void SearchPrintType()
		//{
		//    this.PrintType_tComboEditor.Items.Clear();

		//    if (PrintInfo.printPaperUseDivcd == 3)
		//    {
		//        _frePrtPSetListPrint = new List<FrePrtPSet>();	// �ꗗ�\�󎚈ʒuList
		//        _frePrtPSetListPrint = _frePrtPSetList.FindAll(
		//            delegate(FrePrtPSet wkFrePrtPSet)
		//            {
		//                if(wkFrePrtPSet.PrintPaperUseDivcd == 3)
		//                    return true;
		//                else
		//                    return false;
		//            }
		//        );

		//        foreach (FrePrtPSet wkFrePrtPSet in _frePrtPSetListPrint)
		//        {
		//            this.PrintType_tComboEditor.Items.Add(wkFrePrtPSet, wkFrePrtPSet.DisplayName);
		//        }
		//    }
		//    else if (PrintInfo.printPaperUseDivcd == 4)
		//    {
		//        _frePrtPSetPostCard = new List<FrePrtPSet>();	// �͂����󎚈ʒuList
		//        _frePrtPSetPostCard = _frePrtPSetList.FindAll(
		//            delegate(FrePrtPSet wkFrePrtPSet)
		//            {
		//                if(wkFrePrtPSet.PrintPaperUseDivcd == 4)
		//                    return true;
		//                else
		//                    return false;
		//            }
		//        );

		//        foreach (FrePrtPSet wkFrePrtPSet in _frePrtPSetPostCard)
		//        {
		//            this.PrintType_tComboEditor.Items.Add(wkFrePrtPSet, wkFrePrtPSet.DisplayName);
		//        }
		//    }
		//}
		#endregion

	}
}
