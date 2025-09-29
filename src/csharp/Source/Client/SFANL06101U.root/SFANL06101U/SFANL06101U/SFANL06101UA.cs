//**********************************************************************//
// System           :   �r�e�D�m�d�s                                    //
// Sub System       :                                                   //
// Program name     :   �o�͍ϒ��[�I�����                              //
//                  :   SFUKK06025U.DLL                                 //
// Name Space       :   Broadleaf.Windows.Forms                         //
// Programer        :   �����@����Y                                    //
// Date             :   2005.03.18                                      //
//----------------------------------------------------------------------//
// Update Note      :	2005.08.20�@���с@�^��@PDF�폜�����ǉ�         //
//----------------------------------------------------------------------//
//                Copyright(c)2005 Broadleaf Co.,Ltd.                   //
//**********************************************************************//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Xml;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
	/// **********************************************************************
	/// public class name:   SFANL06101U
	///                      SFANL06101U.DLL
	/// <summary>
	///                      �o�͍ϒ��[�I�����
	/// </summary>
	/// ----------------------------------------------------------------------
	/// <remarks> 
	/// <br>note             :   �o�͍ϒ��[��\�������ʂł�</br>
	/// <br>Programer        :   �����@����Y</br>
	/// <br>Date             :   2005.03.18</br>
	/// <br>Update Note      :   </br>
	/// <br>Programmer : 94012 K.Takeshita</br>
	/// <br>Date       : 2005.09.26</br>
	/// <br>Note       :		�E���b�Z�[�W�\�����V�X�e���K��̃��b�Z�[�W�\���ɕύX</br>
	/// <br>Programmer : 94012 K.Takeshita</br>
	/// <br>Date       : 2005.12.05</br>
	/// <br>Note       :    �EAddPrintInfo��OverLoad�ǉ�(���O�C���S���Ғǉ�)</br>
	/// <br>Update Note: 2006.03.02 Y.Sasaki</br>
	/// <br>           : �P.��L�C���Ń��O�C���S���ҏ��������Ƃ��Ă�����Ă���
	///	               :    ���̕��i�Ń��O�C�������擾���Đݒ肷��悤�ɕύX�B</br>
	/// <br>Update Note: 2006.04.13 Y.Sasaki</br>
	/// <br>           : �P.PDF����ۑ��ς݃`�F�b�N�@�\�ǉ��B</br>
	/// <br>Update Note: 2006.08.01 Y.Sasaki</br>
	/// <br>           : �P.�R�s�[���C�g�ύX�B</br>
	/// <br>           : �Q.�J�����_�[�̕����I��\�����̕\�����ς��s��Ή��B</br>
	/// <br>Update Note: 2007.01.12 �����@�m</br>
	/// <br>           : Vista�Ή�</br>
	/// <br>           : �J�����_�[�̃T�C�Y���X���C�_�[�Ɏ��܂肫��Ȃ��̂ŁA��ʂ̔z�u��ύX</br>
	/// <br>Update Note: 2008.03.11 Y.Sasaki</br>
	/// <br>           : �P.SF eye's����(08'Q1-2)(No.10400972-00) ���[���@�\�Ή�</br>
    /// <br>Update Note: 2010.11.09 Miwa Honda</br>
    /// <br>           : PDF�폜�@�\�̏�Q����(�m�r���Ή��񍐕[)</br>
	/// </remarks>
	/// **********************************************************************
	public class SFANL06101UA : System.Windows.Forms.Form
	{
		// �C�x���g����
		private bool _DateRangeChage = false;
		private static bool _PrintItemInfoChange = false;
		// �J�����_�[�̓��t����
		private DateTime _CalenderDate = DateTime.Now;

		// �F��`
		private Color ctActiveForeColor   = Color.Black;
		private Color ctReadOnlyForeColor = Color.Gray;
//		private Color ActiveFocusColor = Color.FromArgb(255,224,194);

		// ���[PDF�̊i�[��(path)
		private string _PdfPath;
		// ���[XML�̊i�[��(path)
		private string _XmlPath;
		// ���O�C���S����
		private string _LoginWorker;
		// PDF�t�@�C���̃R���N�V����
		private static ArrayList _PrintInfoItems = new ArrayList();
		// ����ς̃R���N�V����
		private static ArrayList _PrintKindInfo = new ArrayList();
		//�}�E�X�|�C���^�̂���m�[�h��ۑ�����̈�
		private Infragistics.Win.UltraWinTree.UltraTreeNode _LastUltraTreeNode = null;

#if !ADD20060302
		// ���O�C���]�ƈ�
		private Employee _loginEmployee = null; 
#endif
		
		private const string UNITID = "SFANL06101UA";
		private const string PGNM   = "�o�͍ϒ��[�I�����";
		/// <summary>
		/// event�L�[���[�h��t�����f���Q�[�g�֐��̃C���X�^���X
		/// </summary>
		public event SelectNodeEvent SelectNode;

		// >>>>> 2008.03.11 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
		/// <summary>�V�X�e�����[��IF</summary>
		INsMenuRoleManager _iNsMenuRoleManager;
		/// <summary>.NS�V�X�e�� DI�R���e�i</summary>
		ServiceInterfaceFactory _serviceInterfaceFactory;
		// <<<<< 2008.03.11 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

		private System.Windows.Forms.MonthCalendar monthCalendar;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet UdsDateType;
        private System.Windows.Forms.Timer PrintItemInfoTimer;
		private System.Windows.Forms.ToolTip NodeToolTip;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private Panel panel1;
        private Panel panel2;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet UdsDspType;
        private Infragistics.Win.UltraWinTree.UltraTree UTlistVew;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL06101UA()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent �Ăяo���̌�ɁA�R���X�g���N�^ �R�[�h��ǉ����Ă��������B
			//
			
			// �\���͈͎w��O���[�v�{�b�N�X������
			UdsDateType.Value = 0;
			UdsDateType.CheckedIndex  = 0;

			// �\���`���w��O���[�v�{�b�N�X������
			UdsDspType.Value = 0;
			UdsDspType.CheckedIndex  = 0;

			// PDF�p�X��XML�p�X���擾����
			SFCMN00331C prtCommon = new SFCMN00331C();
			prtCommon.GetPdfSavePath(ref _PdfPath);
			prtCommon.GetPdfXmlSavePath(ref _XmlPath);

#if REP20060302
			// LOGIN�S���҂�ݒ肷�遙
			_LoginWorker = "";
#else
			// ���O�C���]�ƈ��̎擾
			this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
			if (this._loginEmployee != null)
			{
				this._LoginWorker = this._loginEmployee.Name;
			} 
			else 
			{
				this._LoginWorker = "";
			}
#endif
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFANL06101UA));
            Infragistics.Win.UltraWinTree.UltraTreeColumnSet ultraTreeColumnSet1 = new Infragistics.Win.UltraWinTree.UltraTreeColumnSet();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.UdsDateType = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.PrintItemInfoTimer = new System.Windows.Forms.Timer(this.components);
            this.NodeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UTlistVew = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.UdsDspType = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            ((System.ComponentModel.ISupportInitialize)(this.UdsDateType)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UTlistVew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdsDspType)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.BackColor = System.Drawing.Color.White;
            this.monthCalendar.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.monthCalendar.Location = new System.Drawing.Point(3, 42);
            this.monthCalendar.Margin = new System.Windows.Forms.Padding(0);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.ShowTodayCircle = false;
            this.monthCalendar.TabIndex = 1;
            this.monthCalendar.TitleBackColor = System.Drawing.Color.RoyalBlue;
            this.monthCalendar.TitleForeColor = System.Drawing.Color.Orange;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            // 
            // UdsDateType
            // 
            this.UdsDateType.Dock = System.Windows.Forms.DockStyle.Top;
            this.UdsDateType.ItemAppearance = appearance1;
            this.UdsDateType.ItemOrigin = new System.Drawing.Point(2, 10);
            valueListItem2.DataValue = ((short)(0));
            valueListItem2.DisplayText = "���w��";
            valueListItem1.DataValue = valueListItem2;
            valueListItem1.DisplayText = "���w��";
            valueListItem4.DataValue = ((short)(1));
            valueListItem4.DisplayText = "�T�w��";
            valueListItem3.DataValue = valueListItem4;
            valueListItem3.DisplayText = "�T�w��";
            valueListItem6.DataValue = ((short)(2));
            valueListItem6.DisplayText = "���w��";
            valueListItem5.DataValue = valueListItem6;
            valueListItem5.DisplayText = "���w��";
            valueListItem8.DataValue = ((short)(3));
            valueListItem8.DisplayText = "�S��";
            valueListItem7.DataValue = valueListItem8;
            valueListItem7.DisplayText = "�S��";
            this.UdsDateType.Items.Add(valueListItem1);
            this.UdsDateType.Items.Add(valueListItem3);
            this.UdsDateType.Items.Add(valueListItem5);
            this.UdsDateType.Items.Add(valueListItem7);
            this.UdsDateType.ItemSpacingHorizontal = 2;
            this.UdsDateType.ItemSpacingVertical = 2;
            this.UdsDateType.Location = new System.Drawing.Point(3, 3);
            this.UdsDateType.Margin = new System.Windows.Forms.Padding(0);
            this.UdsDateType.Name = "UdsDateType";
            this.UdsDateType.Size = new System.Drawing.Size(242, 37);
            this.UdsDateType.TabIndex = 0;
            this.UdsDateType.ValueChanged += new System.EventHandler(this.ultraOptionSet1_ValueChanged);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem3,
            this.menuItem2,
            this.menuItem4});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "���̒��[���폜(&D)";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "�����ٰ�߂̒��[���폜(&G)";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "���X�g�̒��[��S�č폜(&A)";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "����ް�w����ȑO�̒��[���폜(&S)";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // PrintItemInfoTimer
            // 
            this.PrintItemInfoTimer.Interval = 10;
            this.PrintItemInfoTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // NodeToolTip
            // 
            this.NodeToolTip.AutomaticDelay = 50;
            this.NodeToolTip.AutoPopDelay = 1000;
            this.NodeToolTip.InitialDelay = 50;
            this.NodeToolTip.ReshowDelay = 10;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.UdsDateType);
            this.panel1.Controls.Add(this.monthCalendar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(248, 190);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.UTlistVew);
            this.panel2.Controls.Add(this.ultraLabel1);
            this.panel2.Controls.Add(this.UdsDspType);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 190);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel2.Size = new System.Drawing.Size(248, 456);
            this.panel2.TabIndex = 6;
            // 
            // UTlistVew
            // 
            this.UTlistVew.AccessibleDescription = "";
            this.UTlistVew.ColumnSettings.RootColumnSet = ultraTreeColumnSet1;
            this.UTlistVew.ContextMenu = this.contextMenu1;
            this.UTlistVew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UTlistVew.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.UTlistVew.HideSelection = false;
            this.UTlistVew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UTlistVew.Location = new System.Drawing.Point(3, 35);
            this.UTlistVew.Name = "UTlistVew";
            this.UTlistVew.Size = new System.Drawing.Size(242, 418);
            this.UTlistVew.TabIndex = 5;
            this.UTlistVew.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UTlistVew_MouseMove);
            this.UTlistVew.Click += new System.EventHandler(this.UTlistVew_Click);
            this.UTlistVew.DoubleClick += new System.EventHandler(this.UTlistVew_DoubleClick);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraLabel1.Location = new System.Drawing.Point(3, 32);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(242, 3);
            this.ultraLabel1.TabIndex = 6;
            // 
            // UdsDspType
            // 
            this.UdsDspType.Dock = System.Windows.Forms.DockStyle.Top;
            this.UdsDspType.ItemAppearance = appearance2;
            this.UdsDspType.ItemOrigin = new System.Drawing.Point(10, 3);
            valueListItem10.DataValue = ((short)(0));
            valueListItem10.DisplayText = "�o�͓��";
            valueListItem9.DataValue = valueListItem10;
            valueListItem9.DisplayText = "�o�͓��";
            valueListItem12.DataValue = ((short)(1));
            valueListItem12.DisplayText = "�o�͒��[�";
            valueListItem11.DataValue = valueListItem12;
            valueListItem11.DisplayText = "�o�͒��[�";
            this.UdsDspType.Items.Add(valueListItem9);
            this.UdsDspType.Items.Add(valueListItem11);
            this.UdsDspType.ItemSpacingVertical = 10;
            this.UdsDspType.Location = new System.Drawing.Point(3, 0);
            this.UdsDspType.Name = "UdsDspType";
            this.UdsDspType.Size = new System.Drawing.Size(242, 32);
            this.UdsDspType.TabIndex = 4;
            this.UdsDspType.ValueChanged += new System.EventHandler(this.UdsDspType_ValueChanged);
            // 
            // SFANL06101UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 12);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(248, 646);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "SFANL06101UA";
            this.Text = "�o�͒��[����";
            this.Load += new System.EventHandler(this.SFUANL06101UA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UdsDateType)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UTlistVew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdsDspType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFANL06101UA());
		}

		/// <summary>
		/// ���[PDF�̊i�[��(Path)
		/// </summary>
		public string PdfPath
		{
			get { return _PdfPath; }
			set { _PdfPath = value; }
		}
		/// <summary>
		/// ���[XML�̊i�[��(Path)
		/// </summary>
		public string XmlPath
		{
			get { return _XmlPath; }
			set { _XmlPath = value; }
		}
		
		/// <summary>
		/// ���O�C���S����
		/// </summary>
		public string LoginWorker
		{
			get { return _LoginWorker; }
			set { _LoginWorker = value; }
		}

		/// <summary>
		/// ���[���̒ǉ�
		/// </summary>
		public void SetPrintKey(string pPrintKey, string pPrintName)
		{
			// ���[��ޏ����C���X�^���X��
			PrintInfoItem PrtInf = new PrintInfoItem(pPrintKey, pPrintName);

			// XML����̓ǂݍ��ׁ݂̈A�f�[�^�Z�b�g�𐶐�����
			DataSet PrintDs = new DataSet(pPrintKey);
			// �f�[�^�e�[�u���𐶐�
			DataTable dtPrintInfo = new DataTable("PrintInfo");
			// �f�[�^�e�[�u���ɒǉ�
			dtPrintInfo = setPrintInfoDataTable();
			// �f�[�^�Z�b�g�Ƀf�[�^�e�[�u����ǉ�
			PrintDs.Tables.Add(dtPrintInfo);

			// �f�[�^�\�[�X�� XML �̃f�[�^��ǂݍ��ށB
			string FileName = FileNameAddPath(_XmlPath, pPrintKey+".xml");
			if (System.IO.File.Exists(FileName) == true)
			{
				// ���[�h����O�ɁA�f�[�^�Z�b�g���N���A����B
				PrintDs.Clear();

				FileStream myFileStream = new FileStream(FileName, System.IO.FileMode.Open);
				XmlTextReader myXmlReader = new XmlTextReader(myFileStream);
				// XML �t�@�C������ǂݍ���
				PrintDs.ReadXml(myXmlReader);   

				myXmlReader.Close();
			}

			// ���[��ޏ��R���N�V�����ɓo�^����
			_PrintKindInfo.Add(PrtInf);

			// �������W�J����
			for(int ii = 0; ii < PrintDs.Tables["PrintInfo"].Rows.Count; ii++)
			{
				_PrintInfoItems.Add(new PrintInfoItem(pPrintKey,
					(DateTime)PrintDs.Tables["PrintInfo"].Rows[ii]["PrintOutDateTime"],
					(string)PrintDs.Tables["PrintInfo"].Rows[ii]["PdfFileName"],
					(string)PrintDs.Tables["PrintInfo"].Rows[ii]["PrintName"],
					(string)PrintDs.Tables["PrintInfo"].Rows[ii]["PrintDetailName"],
					(string)PrintDs.Tables["PrintInfo"].Rows[ii]["LoginWorkerName"]));
			}
		}

		/// <summary>
		/// ���[���̒ǉ�
		/// </summary>
		public void AddPrintInfo(string PrintKey, string PrintName, string PrintDetailName, string PdfFileName)
		{
			// �f�[�^�Z�b�g���C���X�^���X��
			DataSet PrintDs = new DataSet(PrintKey);
			// �f�[�^�e�[�u�����C���X�^���X��
			DataTable dtPrintInfo = new DataTable("PrintInfo");
			// �f�[�^�e�[�u����ݒ肷��
			dtPrintInfo = setPrintInfoDataTable();
			
			// �f�[�^�Z�b�g�Ƀf�[�^�e�[�u����ǉ�
			PrintDs.Tables.Add(dtPrintInfo);

			// �f�[�^�\�[�X�� XML �̃f�[�^��ǂݍ��ށB
			string FileName = FileNameAddPath(_XmlPath, PrintKey+".xml");
			if (System.IO.File.Exists(FileName) == true)
			{
				// ���[�h����O�ɁA�f�[�^�Z�b�g���N���A����B
				PrintDs.Clear();

				FileStream ReadStream = new FileStream(FileName, System.IO.FileMode.Open);
				XmlTextReader myXmlReader = new XmlTextReader(ReadStream);
				// XML �t�@�C������ǂݍ���
				PrintDs.ReadXml(myXmlReader);   

				myXmlReader.Close();
			}

			DateTime dt = DateTime.Now;
			// �f�[�^�Z�b�g�Ƀ��R�[�h��ǉ�����
			DataRow row;
			row = PrintDs.Tables["PrintInfo"].NewRow();
			row["PrintOutDateTime"] = dt;
			row["PdfFileName"] = PdfFileName;
			row["PrintName"] = PrintName;
			row["PrintDetailName"] = PrintDetailName;
			row["LoginWorkerName"] = _LoginWorker;
			PrintDs.Tables["PrintInfo"].Rows.Add(row);

			// �f�[�^�\�[�X�� XML �̃f�[�^���������ށB
			FileStream WriteStream = new FileStream(FileName, System.IO.FileMode.Create);
			XmlTextWriter myXmlWriter = new XmlTextWriter(WriteStream, System.Text.Encoding.UTF8);
			// �C���f���g�����ď����o���悤�Ɏw�肷��B
			myXmlWriter.Formatting = Formatting.Indented;
			// XML �t�@�C���ɏ����o��
			PrintDs.WriteXml(myXmlWriter);
			myXmlWriter.Close();

			// �R���N�V�����ɒǉ�����
			_PrintInfoItems.Add(new PrintInfoItem(PrintKey, dt, PdfFileName, PrintName, PrintDetailName, _LoginWorker));
			// TreeVew���ĕ`�悷��
			_PrintItemInfoChange = true;
		}
		
		/// <summary>
		/// ���[���̒ǉ�
		/// </summary>
		/// <param name="PrintKey">���[KEY���</param>
		/// <param name="PrintName">���[����</param>
		/// <param name="PrintDetailName">���[�ڍז���</param>
		/// <param name="PdfFileName">PDF�t�@�C����</param>
		/// <param name="loginName">���O�C���S���Җ�</param>
		/// <remarks>
		/// <br>Note       : ���[�̏o�͏���Xml�ɏ������݂܂�</br>
		/// <br>Programmer : 94012 K.Takeshita</br>
		/// <br>Date       : 2005.12.05</br>
		/// <br>Note       :    �EOverLoad��Login�S���Ғǉ�</br>
		/// </remarks>
		public void AddPrintInfo(string PrintKey, string PrintName, string PrintDetailName, string PdfFileName, string loginName)
		{
			this._LoginWorker = loginName;
			AddPrintInfo(PrintKey, PrintName, PrintDetailName, PdfFileName);
		}

		/// <summary>
		/// �d���`�F�b�N����
		/// </summary>
		/// <param name="printKey">���[KEY���</param>
		/// <param name="pdfFileName">PDF�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �Y���o�c�e�t�@�C���̏d���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.04.13</br>
		/// </remarks>
		public bool Contains(string printKey, string pdfFileName)
		{
			foreach (PrintInfoItem itm in _PrintInfoItems)
			{
				if (itm.PrintKey.Equals(printKey) &&
					itm.PdfFileName.Equals(pdfFileName))
				{
					return true;
				}
			}
			return false;
		}
		
		/// <summary>
		/// ���[���̒ǉ�
		/// </summary>
		private DataTable setPrintInfoDataTable()
		{
			// �f�[�^�e�[�u���𐶐�
			DataTable dtPrintInfo = new DataTable("PrintInfo");
			// �f�[�^Colm�ǉ�(���s����)
			DataColumn colPrintOutDateTime = new DataColumn();
			colPrintOutDateTime.ColumnName = "PrintOutDateTime";
			colPrintOutDateTime.DataType   = typeof(DateTime);
			colPrintOutDateTime.Unique     = false;
			dtPrintInfo.Columns.Add(colPrintOutDateTime);
			// �f�[�^Colm�ǉ�(PDF�t�@�C����)
			DataColumn colPdfFileName      = new DataColumn();
			colPdfFileName.ColumnName      = "PdfFileName";
			colPdfFileName.DataType        = typeof(string);
			colPdfFileName.Unique          = true;			// ��L�[
			dtPrintInfo.Columns.Add(colPdfFileName);
			// �f�[�^Colm�ǉ�(���[��)
			DataColumn colPrintName        = new DataColumn();
			colPrintName.ColumnName        = "PrintName";
			colPrintName.DataType          = typeof(string);
			colPrintName.Unique            = false;
			dtPrintInfo.Columns.Add(colPrintName);
			// �f�[�^Colm�ǉ�(���[���ڍ�)
			DataColumn colPrintDetailName  = new DataColumn();
			colPrintDetailName.ColumnName  = "PrintDetailName";
			colPrintDetailName.DataType    = typeof(string);
			colPrintDetailName.Unique      = false;
			dtPrintInfo.Columns.Add(colPrintDetailName);
			// �f�[�^Colm�ǉ�(���s��)
			DataColumn colLoginWorkerName = new DataColumn();
			colLoginWorkerName.ColumnName = "LoginWorkerName";
			colLoginWorkerName.DataType   = typeof(string);
			colLoginWorkerName.Unique     = false;
			dtPrintInfo.Columns.Add(colLoginWorkerName);

			return dtPrintInfo;
		}

		/// **********************************************************************
		/// ivent name       : ultraOptionSet1_ValueChanged
		/// <summary>
		///                    ���t���w��{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">
		///                    �N���b�N���ꂽ�I�u�W�F�N�g
		/// </param>
		/// <param name="e">
		///                    �C�x���g �f�[�^
		/// </param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note�@�@�@�@�@�@ :   ���t���w��{�^���N���b�N���ɔ������܂�</br>
		/// <br>Programer       :   �����@����Y</br>
		/// <br>Date            :   2005.03.18</br>
		/// <br>Update Note     :   </br>
		/// </remarks>
		/// **********************************************************************
		private void ultraOptionSet1_ValueChanged(object sender, System.EventArgs e)
		{
			if (UdsDateType.Value != null)
			{
                switch (UdsDateType.CheckedIndex) 
				{
					case 0:
						// ���t�w��̏ꍇ
						monthCalendar.SelectionStart = _CalenderDate;
						monthCalendar.MaxSelectionCount = 1;
						monthCalendar.ForeColor = ctActiveForeColor;
						monthCalendar.Enabled = true;
						break;
					case 1:
						// �T�ԕ\���̏ꍇ
						monthCalendar.MaxSelectionCount = 7;
						monthCalendar.ForeColor = ctActiveForeColor;
						monthCalendar.Enabled = true;
						break;
					case 2:
						// ���ԕ\���̏ꍇ
						monthCalendar.MaxSelectionCount = 31;
						monthCalendar.ForeColor = ctActiveForeColor;
						monthCalendar.Enabled = true;
						break;
					default:
						// �S�Ă̏ꍇ
                        //2007/01/15 H.NAKAMURA DEL START //////////////////////////////////////////////////////////
                        //Vista�̏ꍇMaxSelectionCount=1�Ƃ���ƑI������Ă������̂���������Ă��܂�(XP�ł͖��Ȃ�)
                        //�S�Ă̏ꍇ�͂���ȊO��MaxSelectionCount�������p�����Ƃɂ���B                       
						//monthCalendar.MaxSelectionCount = 1;
                        //DEL END //////////////////////////////////////////////////////////////////////////////////
						monthCalendar.ForeColor = ctReadOnlyForeColor;
						monthCalendar.Enabled = false;
						break;
				}
				setMonthCalendarDateRange();
			}
		}

		/// **********************************************************************
		/// ivent name       : monthCalendar_DateChanged
		/// <summary>
		///                    �J�����_�[�̓��t��ύX�����ꍇ�ɔ�������C�x���g
		/// </summary>
		/// <param name="sender">
		///                    �N���b�N���ꂽ�I�u�W�F�N�g
		/// </param>
		/// <param name="e">
		///                    �C�x���g �f�[�^
		/// </param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note�@�@�@�@�@�@ :   �J�����_�[�̓��t����ύX�����ۂɔ������܂�</br>
		/// <br>Programer       :   �����@����Y</br>
		/// <br>Date            :   2005.03.18</br>
		/// <br>Update Note     :   </br>
		/// </remarks>
		/// **********************************************************************
		private void monthCalendar_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
		{
			if (_DateRangeChage == false)
			{
				setMonthCalendarDateRange();

				if (UdsDateType.Value != null)
				{
					if(UdsDateType.CheckedIndex == 0) 
					{
						_CalenderDate = this.monthCalendar.SelectionStart;
					}
				}
			}
		}
		/// **********************************************************************
		/// ivent name       : SFUANL06101UA_Load
		/// <summary>
		///                    ��ʂ𐶐�����ۂɔ�������C�x���g
		/// </summary>
		/// <param name="sender">
		///                    ���������ʂ̃I�u�W�F�N�g
		/// </param>
		/// <param name="e">
		///                    �C�x���g �f�[�^
		/// </param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note�@�@�@�@�@�@ :   ��ʂ𐶐�����ۂɔ�������C�x���g</br>
		/// <br>Programer       :   �����@����Y</br>
		/// <br>Date            :   2005.03.18</br>
		/// <br>Update Note     :   </br>
		/// </remarks>
		/// **********************************************************************
		private void SFUANL06101UA_Load(object sender, System.EventArgs e)
		{
			// �f�[�^��ݒ�i�\���j����
			setListData();
			// ��ʋN���̏ꍇ�́A�^�C�}���N������B
			PrintItemInfoTimer.Enabled = true;
			PrintItemInfoTimer.Interval = 10;
			PrintItemInfoTimer.Start();
		}

		/// **********************************************************************
		/// ivent name       : UdsDspType_ValueChanged
		/// <summary>
		///                    �\�������i���[��/���t�ʁj��ύX�����ꍇ�ɔ�������C�x���g
		/// </summary>
		/// <param name="sender">
		///                    �ύX���ꂽ�I�u�W�F�N�g
		/// </param>
		/// <param name="e">
		///                    �C�x���g �f�[�^
		/// </param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note�@�@�@�@�@�@ :   �\�������i���[��/���t�ʁj��ύX�����ꍇ�ɔ�������</br>
		/// <br>Programer       :   �����@����Y</br>
		/// <br>Date            :   2005.03.18</br>
		/// <br>Update Note     :   </br>
		/// </remarks>
		/// **********************************************************************
		private void UdsDspType_ValueChanged(object sender, System.EventArgs e)
		{
			setListData();
		}

		/// **********************************************************************
		/// ivent name       : UTlistVew_DoubleClick
		/// <summary>
		///                    �m�[�h���_�u���N���b�N�����ۂɔ�������C�x���g
		/// </summary>
		/// <param name="sender">
		///                    �_�u���N���b�N���ꂽ�I�u�W�F�N�g
		/// </param>
		/// <param name="e">
		///                    �C�x���g �f�[�^
		/// </param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note�@�@�@�@�@�@ :   �m�[�h���_�u���N���b�N�����ۂɔ�������</br>
		/// <br>Programer       :   �����@����Y</br>
		/// <br>Date            :   2005.03.18</br>
		/// <br>Update Note     :   </br>
		/// </remarks>
		/// **********************************************************************
		private void UTlistVew_DoubleClick(object sender, System.EventArgs e)
		{
			// �����̃`�F�b�N		2008.03.11 Y.Sasaki ADD
			if (this.CheckRoleManeger() != 0) return;

			PrintInfoItem Itm = new PrintInfoItem();
			// �m�[�h���P�ȏ�A�I�����Ă��邩�H
			if(UTlistVew.SelectedNodes.Count > 0)
			{
				// �I�����ꂽ�m�[�h�̏����R���N�V��������擾����
				Itm = NodeKeyToItem(UTlistVew.SelectedNodes[0].Key);
				if (Itm != null)
				{
					// �f���Q�[�g�o�^����Ă��邩�H
					if (SelectNode != null)
					{
						// �f���Q�[�g����Ă���C�x���g���N������
						SelectNode(Itm.PrintKey, Itm.PrintName, Itm.PdfFileName);
					}
				}
			}
		}

		/// **********************************************************************
		/// ivent name       : UTlistVew_MouseMove
		/// <summary>
		///                    �c���[��Ń}�E�X���ړ������ۂɔ�������C�x���g
		/// </summary>
		/// <param name="sender">
		///                    �t�H�[�J�X�̂���I�u�W�F�N�g
		/// </param>
		/// <param name="e">
		///                    �C�x���g �f�[�^
		/// </param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note�@�@�@�@�@�@ :   �c���[��Ń}�E�X���ړ������ۂɔ�������</br>
		/// <br>Programer       :   �����@����Y</br>
		/// <br>Date            :   2005.03.18</br>
		/// <br>Update Note     :   </br>
		/// </remarks>
		/// **********************************************************************
		private void UTlistVew_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(NodeToolTip != null)
			{
				Infragistics.Win.UltraWinTree.UltraTree ut = (Infragistics.Win.UltraWinTree.UltraTree)sender;
				//�}�E�X�|�C���^�̂���A�C�e�����擾
				Infragistics.Win.UltraWinTree.UltraTreeNode Utn = ut.GetNodeFromPoint(e.X, e.Y);
				//�|�C���g����Ă���A�C�e�����ς������
				if (Utn != _LastUltraTreeNode)
				{
					// ToolTip��Active�ȏꍇ�AActive����
					if(NodeToolTip.Active)
						NodeToolTip.Active = false;
					if (Utn != null)
					{
						// �|�C���g����Ă���m�[�h�̏����R���N�V��������擾
						PrintInfoItem Itm = new PrintInfoItem();
						Itm = NodeKeyToItem(Utn.Key);
						if (Itm != null)
						{
							//ToolTip�̃e�L�X�g��ݒ肷��
							NodeToolTip.SetToolTip(ut, Itm.PrintDetailName+"  ���s�ҁF"+Itm.LoginWorkerName);
							//ToolTip���ĂуA�N�e�B�u�ɂ���
							NodeToolTip.Active = true;
						}
					}
					// �|�C���g����Ă���m�[�h���L������
					_LastUltraTreeNode = Utn;
				}
			}
		}

		/// **********************************************************************
		/// ivent name       : timer1_Tick
		/// <summary>
		///                    �c���[��Ń}�E�X���ړ������ۂɔ�������C�x���g
		/// </summary>
		/// <param name="sender">
		///                    �^�C�}�[�I�u�W�F�N�g
		/// </param>
		/// <param name="e">
		///                    �C�x���g �f�[�^
		/// </param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note�@�@�@�@�@�@ :   �^�C�}�[���N�����ꂽ�ۂɔ�������</br>
		/// <br>Programer       :   �����@����Y</br>
		/// <br>Date            :   2005.03.18</br>
		/// <br>Update Note     :   </br>
		/// </remarks>
		/// **********************************************************************
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			// �^�C�}�[���X�g�b�v����
			PrintItemInfoTimer.Stop();
			if (_PrintItemInfoChange == true)
			{
				_PrintItemInfoChange = false;
				setListData();
			}
			// �^�C�}�[���X�^�[�g����
			PrintItemInfoTimer.Start();
		}

		/// **********************************************************************
		/// Module name			: setMonthCalendarDateRange
		/// <summary>
		///						�J�����_�[���t�̐ݒ菈��  
		/// </summary>
		/// <param>
		///						none
		/// </param>
		/// <returns>
		///						none
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note			:   �J�����_�[�̃v���p�e�B��ύX����</br>
		/// <br>Programer		:   �����@����Y</br>
		/// <br>Date			:   2005.03.18</br>
		/// <br>Update Note		:   </br>
		/// </remarks>
		/// **********************************************************************
		private void setMonthCalendarDateRange()
		{
			System.DateTime dt, sdt, edt;

			if (UdsDateType.Value != null)
			{
				_DateRangeChage = true;
				dt = sdt = edt = monthCalendar.SelectionStart;
				switch (UdsDateType.CheckedIndex) 
				{
					case 0:
						// ���ԕ\���̏ꍇ
						monthCalendar.SelectionStart = dt;
						monthCalendar.SelectionEnd   = dt;
						break;
					case 1:
						// �T�ԕ\���̏ꍇ
						switch (dt.DayOfWeek)
						{
							case DayOfWeek.Sunday  :
								sdt = dt;
								edt = dt.AddDays(6);
								break;
							case DayOfWeek.Monday :
								sdt = dt.AddDays(-1);
								edt = dt.AddDays(5);
								break;
							case DayOfWeek.Tuesday  :
								sdt = dt.AddDays(-2);
								edt = dt.AddDays(4);
								break;
							case DayOfWeek.Wednesday  :
								sdt = dt.AddDays(-3);
								edt = dt.AddDays(3);
								break;
							case DayOfWeek.Thursday  :
								sdt = dt.AddDays(-4);
								edt = dt.AddDays(2);
								break;
							case DayOfWeek.Friday  :
								sdt = dt.AddDays(-5);
								edt = dt.AddDays(1);
								break;
							case DayOfWeek.Saturday  :
								sdt = dt.AddDays(-6);
								edt = dt;
								break;
						};
						monthCalendar.SelectionStart = sdt;
						monthCalendar.SelectionEnd   = edt;
						break;
					case 2:
						// ���ԕ\���̏ꍇ
						sdt = new DateTime(dt.Year, dt.Month, 1);
						edt = new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
						monthCalendar.MaxSelectionCount = DateTime.DaysInMonth(dt.Year, dt.Month);
						monthCalendar.SelectionStart = sdt;
						monthCalendar.SelectionEnd   = edt;
						//2007/01/15 H.NAKAMURA DEL START //////////////////////////////////////////////////////////
                        //Vista�̏ꍇMaxSelectionCount=1�Ƃ���ƑI������Ă������̂���������Ă��܂�(XP�ł͖��Ȃ�)
                        //�����MaxSelectionCount��ύX���Ȃ��B
						//monthCalendar.MaxSelectionCount = 1;
                        ////DEL END ////////////////////////////////////////////////////////////////////////////////
						break;
					default:
						break;
				}
				_DateRangeChage = false;

				setListData();
			}
		}

		/// <summary>
		/// �����������DateTime�^�ɕϊ�����
		/// </summary>
		/// **********************************************************************
		/// Module name			: setMonthCalendarDateRange
		/// <summary>
		///						�����������DateTime�^�ɕϊ�����  
		/// </summary>
		/// <param name="dateTimeString">
		///						none
		/// </param>
		/// <returns>
		///						none
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note			:   �J�����_�[�̃v���p�e�B��ύX����</br>
		/// <br>Programer		:   �����@����Y</br>
		/// <br>Date			:   2005.03.18</br>
		/// <br>Update Note		:   </br>
		/// </remarks>
		/// **********************************************************************
		private DateTime ToDateTime(string dateTimeString)
		{
			return System.DateTime.ParseExact(dateTimeString,
				"yyyyMMddHHmmss",
				System.Globalization.DateTimeFormatInfo.InvariantInfo,
				System.Globalization.DateTimeStyles.None);
		}


		/// <summary>
		/// ���t�͈͂̒��[�𒊏o����
		/// </summary>
		private void setListData()
		{
			if (_PdfPath == null || _PrintKindInfo.Count == 0) return;
			if (UdsDateType.Value != null)
			{
				if (UdsDspType.CheckedIndex == 0) 
				{
					setListVewOfDate();
				}
				else
				{
					setListVewOfPrintKey();
				}
			}
		}

		/// <summary>
		/// ���[�^�C�v�Ńc���[�r���[��ݒ肷��
		/// </summary>
		private void setListVewOfPrintKey()
		{
			string wstr;								// ������ҏW���[�N
			DateTime dt = DateTime.MinValue;			// ���t���[�N(�����l=MinValue)
			UTlistVew.Nodes.Clear();					// �c���[�r���[�̃m�[�h��������
			ArrayList PrtItmList = new ArrayList();		// ���t�P�ʂ̐ݒ�p�R���N�V����

			// �w����t��ϊ�
			int DateType = UdsDateType.CheckedIndex;
			if (DateType == 3)
			{
				// �S�����o�̏ꍇ

				// ���[���
				foreach(PrintInfoItem PrtKidInf in _PrintKindInfo)
				{
					// �R���N�V����������
					PrtItmList.Clear();
					// ���t�\�[�g�p�C���^�[�t�F�[�X����
					PrintInfoComparer pc = new PrintInfoComparer();
					pc.Key = PrintInfoComparer.SortKey.PrintOutDateTime;
					// �~�����w��
					pc.Order = SortOrder.Descending;
					// ���t�Ń\�[�g����
					_PrintInfoItems.Sort(pc);
					// ���t�Ō�������
					foreach (PrintInfoItem Itm in _PrintInfoItems)
					{
						// ���[��ʂ͓����ł��邩�H
						if (PrtKidInf.PrintKey == Itm.PrintKey)
						{
							// �A�C�e����ǉ�����
							PrtItmList.Add(Itm);
						}
					}
					// �R���N�V�����̒��g��TreeVew�ɐݒ肷��(��ʂ��Ƃ�)
					if (PrtItmList.Count > 0)
					{
						// �e�m�[�h�𐶐�
						wstr = PrtKidInf.PrintName;
						Infragistics.Win.UltraWinTree.UltraTreeNode topNode = new Infragistics.Win.UltraWinTree.UltraTreeNode("",wstr);
						foreach (PrintInfoItem DspItm in PrtItmList)
						{
							// �q�m�[�h��ǉ�����
							topNode.Nodes.Add(setNodePrintDate(DspItm));
						}
						// �c���[�r���[��\������
						UTlistVew.Nodes.Add(topNode);
					}
				}
				UTlistVew.ExpandAll();
			}
			else 
			{
				// ���t/�T��/���Ԍ����̏ꍇ
				foreach(PrintInfoItem PrtKidInf in _PrintKindInfo)
				{
					// �R���N�V����������
					PrtItmList.Clear();
					// ���t�͈�
					TimeSpan ts = monthCalendar.SelectionRange.End - monthCalendar.SelectionRange.Start;
					for(int xx = ts.Days +1; xx > 0; xx--)
					{
						// �T�Ԍ����̏ꍇ
						dt = monthCalendar.SelectionStart.AddDays(xx-1);
						// ���t�\�[�g�p�C���^�[�t�F�[�X����
						PrintInfoComparer pc = new PrintInfoComparer();
						pc.Key = PrintInfoComparer.SortKey.PrintOutDate;
						// �������w��
						pc.Order = SortOrder.Ascending;
						// ���t�Ń\�[�g����
						_PrintInfoItems.Sort(pc);
						// ���t�Ō������� 
						int st = _PrintInfoItems.BinarySearch(new PrintInfoItem(null, dt, null, null, null, null), pc);
						if (st >= 0)
						{
							int StartPos = st;
							PrintInfoItem Itm = new PrintInfoItem();
							// �X�^�[�g�ʒu�������i�O���ɓ������̂����邩�j
							for(int zz=st; zz >= 0 ;zz--)
							{
								Itm = (PrintInfoItem)_PrintInfoItems[zz];
								if (Itm.PrintOutDateTime.Date != dt.Date) break;
								StartPos = zz;
							}
							// ���X�g�𐶐�����
							for(int ii=StartPos; ii < _PrintInfoItems.Count; ii++)
							{
								// ArrayList��Cast����
								Itm = (PrintInfoItem)_PrintInfoItems[ii];
								// ���t����v���Ă��邩�H
								if (Itm.PrintOutDateTime.Date != dt.Date) break;
								// �����ʂ���v���Ă��邩�H
								if (Itm.PrintKey == PrtKidInf.PrintKey)
								{
									// �A�C�e����ǉ�����
									PrtItmList.Add(Itm);
								}
							}
						}
					}
					// �R���N�V�����̒��g��TreeVew�ɐݒ肷��
					if (PrtItmList.Count > 0)
					{
						// ���t�\�[�g�p�C���^�[�t�F�[�X����
						PrintInfoComparer pc2 = new PrintInfoComparer();
						pc2.Key = PrintInfoComparer.SortKey.PrintOutDateTime;
						// �������w��
						pc2.Order = SortOrder.Descending;
						// ���t�Ń\�[�g����
						PrtItmList.Sort(pc2);
						// �e�m�[�h�𐶐�
						wstr = PrtKidInf.PrintName;
						Infragistics.Win.UltraWinTree.UltraTreeNode topNode = new Infragistics.Win.UltraWinTree.UltraTreeNode("",wstr);
						foreach (PrintInfoItem DspItm in PrtItmList)
						{
							// �q�m�[�h��ǉ�����
							topNode.Nodes.Add(setNodePrintDate(DspItm));
						}
						// �c���[�r���[��\������
						UTlistVew.Nodes.Add(topNode);
					}
				}
				// �c���[�r���[�̃m�[�h��\������
				UTlistVew.ExpandAll();
			}
		}

		/// <summary>
		/// �q�m�[�h��������i���t�j
		/// </summary>
		private Infragistics.Win.UltraWinTree.UltraTreeNode setNodePrintDate(PrintInfoItem DspItm)
		{
			string  wstr;
			// �q�m�[�h��ǉ�����
			wstr = DspItm.PrintOutDateTime.ToString("yyyy�NMM��dd��(ddd) HH:mm");
			Infragistics.Win.UltraWinTree.UltraTreeNode ChildNode = new Infragistics.Win.UltraWinTree.UltraTreeNode(DspItm.Id.ToString(),wstr);
			ChildNode.LeftImages.Add(this.imageList1.Images[0]);
			return ChildNode;
		}

		/// <summary>
		/// ���t�Ńc���[�r���[��ݒ肷��
		/// </summary>
		private void setListVewOfDate()
		{
			string wstr;								// ������ҏW���[�N
			DateTime dt = DateTime.MinValue;			// ���t���[�N(�����l=MinValue)
			UTlistVew.Nodes.Clear();					// �c���[�r���[�̃m�[�h��������
			ArrayList PrtItmList = new ArrayList();		// ���t�P�ʂ̐ݒ�p�R���N�V����

			// �w����t��ϊ�
			int DateType = UdsDateType.CheckedIndex;
			if (DateType == 3)
			{
				// �S�����o�̏ꍇ
				// ���t�\�[�g�p�C���^�[�t�F�[�X����
				PrintInfoComparer pc = new PrintInfoComparer();
				pc.Key = PrintInfoComparer.SortKey.PrintOutDateTime;
				// �~�����w��
				pc.Order = SortOrder.Descending;
				// ���t�Ń\�[�g����
				_PrintInfoItems.Sort(pc);
				// ���t�Ō�������
				foreach (PrintInfoItem Itm in _PrintInfoItems)
				{
					// ���t����v���Ă��邩�H
					if (Itm.PrintOutDateTime.Date != dt.Date)
					{
						// �R���N�V�����̒��g��TreeVew�ɐݒ肷��
						if (PrtItmList.Count > 0)
						{
							// �e�m�[�h�𐶐�
							wstr = dt.ToString("yyyy�NMM��dd��(ddd)");
							Infragistics.Win.UltraWinTree.UltraTreeNode topNode = new Infragistics.Win.UltraWinTree.UltraTreeNode("",wstr);
							foreach (PrintInfoItem DspItm in PrtItmList)
							{
								// �q�m�[�h��ǉ�����
								topNode.Nodes.Add(SetNodePrintName(DspItm));
							}
							// �c���[�r���[��\������
							UTlistVew.Nodes.Add(topNode);
						}
						// ���t����Ҕ�����
						dt = Itm.PrintOutDateTime;
						// �R���N�V����������
						PrtItmList.Clear();
					}
					// �A�C�e����ǉ�����
					PrtItmList.Add(Itm);
				}
				// �R���N�V�����̒��g��TreeVew�ɐݒ肷��
				if (PrtItmList.Count > 0)
				{
					// �e�m�[�h�𐶐�
					wstr = dt.ToString("yyyy�NMM��dd��(ddd)");
					Infragistics.Win.UltraWinTree.UltraTreeNode topNode = new Infragistics.Win.UltraWinTree.UltraTreeNode("",wstr);
					foreach (PrintInfoItem DspItm in PrtItmList)
					{
						// �q�m�[�h��ǉ�����
						topNode.Nodes.Add(SetNodePrintName(DspItm));
					}
					// �c���[�r���[��\������
					UTlistVew.Nodes.Add(topNode);
				}
				UTlistVew.ExpandAll();
			}
			else 
			{
				// ���t/�T��/���Ԍ����̏ꍇ
				TimeSpan ts = monthCalendar.SelectionRange.End - monthCalendar.SelectionRange.Start;
				for(int xx = ts.Days +1; xx > 0; xx--)
				{
					// �R���N�V����������
					PrtItmList.Clear();
					// �T�Ԍ����̏ꍇ
					dt = monthCalendar.SelectionStart.AddDays(xx-1);
					// ���t�\�[�g�p�C���^�[�t�F�[�X����
					PrintInfoComparer pc = new PrintInfoComparer();
					pc.Key = PrintInfoComparer.SortKey.PrintOutDate;
					// �������w��
					pc.Order = SortOrder.Ascending;
					// ���t�Ń\�[�g����
					_PrintInfoItems.Sort(pc);
					// ���t�Ō������� 
					int st = _PrintInfoItems.BinarySearch(new PrintInfoItem(null, dt, null, null, null, null), pc);
					if (st >= 0)
					{
						int StartPos = st;
						PrintInfoItem Itm = new PrintInfoItem();
						// �X�^�[�g�ʒu�������i�O���ɓ������̂����邩�j
						for(int zz=st; zz >= 0 ;zz--)
						{
							Itm = (PrintInfoItem)_PrintInfoItems[zz];
							if (Itm.PrintOutDateTime.Date != dt.Date) break;
							StartPos = zz;
						}
						// ���X�g�𐶐�����
						for(int ii=StartPos; ii < _PrintInfoItems.Count; ii++)
						{
							// ArrayList��Cast����
							Itm = (PrintInfoItem)_PrintInfoItems[ii];
							// ���t����v���Ă��邩�H
							if (Itm.PrintOutDateTime.Date != dt.Date) break;
							// �A�C�e����ǉ�����
							PrtItmList.Add(Itm);
						}
					}
					// �R���N�V�����̒��g��TreeVew�ɐݒ肷��
					if (PrtItmList.Count > 0)
					{
						// ���t�\�[�g�p�C���^�[�t�F�[�X����
						PrintInfoComparer pc2 = new PrintInfoComparer();
						pc2.Key = PrintInfoComparer.SortKey.PrintOutDateTime;
						// �������w��
						pc2.Order = SortOrder.Descending;
						// ���t�Ń\�[�g����
						PrtItmList.Sort(pc2);

						// �e�m�[�h�𐶐�
						wstr = dt.ToString("yyyy�NMM��dd��(ddd)");
						Infragistics.Win.UltraWinTree.UltraTreeNode topNode = new Infragistics.Win.UltraWinTree.UltraTreeNode("",wstr);
						foreach (PrintInfoItem DspItm in PrtItmList)
						{
							// �q�m�[�h��ǉ�����
							topNode.Nodes.Add(SetNodePrintName(DspItm));
						}
						// �c���[�r���[��\������
						UTlistVew.Nodes.Add(topNode);
					}
				}
				UTlistVew.ExpandAll();
			}
		}

		/// <summary>
		/// �q�m�[�h��������i���[�j
		/// </summary>
		private Infragistics.Win.UltraWinTree.UltraTreeNode SetNodePrintName(PrintInfoItem DspItm)
		{
			string  wstr;
			wstr = DspItm.PrintName+DspItm.PrintOutDateTime.ToString(" HH:mm");
			Infragistics.Win.UltraWinTree.UltraTreeNode ChildNode = new Infragistics.Win.UltraWinTree.UltraTreeNode(DspItm.Id.ToString(),wstr);
			ChildNode.LeftImages.Add(this.imageList1.Images[0]);
			return ChildNode;
		}

		/// <summary>
		/// ���[����ݒ�
		/// </summary>
		private string FileNameAddPath(string path, string FileName)
		{
			return path + "\\" + FileName;
		}

		/// <summary>
		/// �m�[�h�j�d�x���h���������擾����
		/// </summary>
		private PrintInfoItem NodeKeyToItem(string NodeKey)
		{
			PrintInfoItem result = new PrintInfoItem();
			result = null;
			if ( NodeKey.Length > 0 && NodeKey != null )
			{
				// �m�[�h�ɖ��߂�KEY�iGuid)��Guid�^�ɕϊ�����
				GuidConverter gc = new GuidConverter();
				Guid wId = (Guid)gc.ConvertFromString(NodeKey);

				// Guid�\�[�g�p�C���^�[�t�F�[�X����
				PrintInfoComparer pc = new PrintInfoComparer();
				pc.Key = PrintInfoComparer.SortKey.Id;
				_PrintInfoItems.Sort(pc);

				// Guid�Ō������� 
				int st = _PrintInfoItems.BinarySearch(new PrintInfoItem(wId, null, DateTime.Now, null, null, null, null), pc);
				if (st >= 0)
				{
					// �I������PDF�̃t�@�C�������擾����
					result = (PrintInfoItem)_PrintInfoItems[st];
				}
			}
			return result;
		}

		/// <summary>
		/// �폜���j���[�|�b�v�A�b�v
		/// </summary>
		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
			PrintInfoItem Itm = new PrintInfoItem();

			// �m�[�h���P�ȏ�A�I�����Ă��邩�H
			if(UTlistVew.SelectedNodes.Count > 0)
			{
				// �I�����ꂽ�m�[�h�̏����R���N�V��������擾����
				Itm = NodeKeyToItem(UTlistVew.SelectedNodes[0].Key);
			}
			//�c���[��ŃA�C�e�������I���̎��̓|�b�v�A�b�v���Ȃ�
			if ( UTlistVew.SelectedNodes.Count == 0     ||   //�A�C�e�����I��
				this._LastUltraTreeNode       == null ||   //�O��I�𖳂�
				Itm                           == null )    //�����񖳂������[�łȂ��������I������Ă���
			{
				contextMenu1.MenuItems[0].Visible = false;	//����̧�ق��폜
				contextMenu1.MenuItems[1].Visible = false;	//�����ٰ�߂̒��[���폜
				contextMenu1.MenuItems[2].Visible = false;	//���X�g�̒��[��S�č폜(&A)
				//contextMenu1.MenuItems[3].Visible = false;	//����ް�w����ȑO�̒��[���폜
			}
			else
			{
				contextMenu1.MenuItems[0].Visible = true;	//����̧�ق��폜
				contextMenu1.MenuItems[1].Visible = true;	//�����ٰ�߂̒��[���폜
				contextMenu1.MenuItems[2].Visible = true;	//���X�g�̒��[��S�č폜(&A)
				//contextMenu1.MenuItems[3].Visible = true;	//����ް�w����ȑO�̒��[���폜
			}
			contextMenu1.MenuItems[3].Visible = true;	//����ް�w����ȑO�̒��[���폜
		}

		/// <summary>
		/// �폜���j���[�I��
		/// </summary>
		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			// �����̃`�F�b�N		2008.03.11 Y.Sasaki ADD
			if (this.CheckRoleManeger() != 0) return;

			//���݂̃}�E�X�|�C���^������ʒu���A�Ō�ɑI������Ă�����̂��m�F
			if (this._LastUltraTreeNode != null)
			{
				// �|�C���g����Ă���m�[�h�̏����R���N�V��������擾
				PrintInfoItem Itm = new PrintInfoItem();
				Itm = NodeKeyToItem(_LastUltraTreeNode.Key);
				if (Itm != null)
				{
					/*
										//�폜���b�Z�[�W�\��
		//                  MessageBox.Show("���̒��[���폜���܂��B��낵���ł����H \n\r"+
																		Itm.PrintName + "  " + Itm.PrintOutDateTime.ToShortDateString() + " " +
																														Itm.PrintOutDateTime.ToShortTimeString()
										);*/
				}
				else
				{
					return;
				}
		            
				// �I�����ꂽ�m�[�h�̏����R���N�V��������擾����
				Itm = NodeKeyToItem(UTlistVew.SelectedNodes[0].Key);
				if (Itm != null)
				{
					try //��O������
					{
						File.Delete(Itm.PdfFileName);
					}
					catch
					{
						//                      MessageBox.Show(
						//                          "���ݕ\�����̂��ߍ폜�ł��܂���B",
						//                          "�폜�ł��܂���",
						//                          MessageBoxButtons.OK,
						//                          MessageBoxIcon.Error,
						//                          MessageBoxDefaultButton.Button1);
						MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���ݕ\�����̂��ߍ폜�ł��܂���B",-1,"menuItem1_Click");
						return;
					}
					finally
					{
						// ����Ȃ�����
					}

					//�I�����ꂽ�m�[�h���폜����
					UTlistVew.SelectedNodes[0].Remove();

					// �t�@�C�����Ō�������
					//_PrintInfoItems����폜����
					foreach (PrintInfoItem prtItm in _PrintInfoItems)
					{
						// ���[��ʂ͓����ł��邩�H  
						//if (prtItm.PrintKey == Itm.PrintKey)                                             // 2010.11.09 del honda 
                        if ((prtItm.PrintKey == Itm.PrintKey) && (prtItm.PdfFileName == Itm.PdfFileName))  // 2010.11.09 add honda 
						{
							// �A�C�e�����폜����
							_PrintInfoItems.Remove(prtItm);
							//XML�t�@�C�����폜����
							DeletePrintInfXML(prtItm);
							break;
						}
					}//foreach
				}
			}
		}

		private void UTlistVew_Click(object sender, System.EventArgs e)
		{
			//TODO: ���N���b�N�ł��E�N���b�N�����悤�ɂ���

		}

		/// <summary>
		/// XML�t�@�C������������폜���܂��B
		/// </summary>
		/// <param name="prtItm">�폜�Ώۈ�����</param>
		private void DeletePrintInfXML(PrintInfoItem prtItm)
		{
			//XML�t�@�C���̓Ǎ�
			string FileName = FileNameAddPath(_XmlPath, prtItm.PrintKey + ".xml");
			if (System.IO.File.Exists(FileName) == false) return; //̧�ٖ�����EXIT
		            
			//XML�̎w��^�O�̎q�m�[�h���X�g(TAG�̃��X�g)���擾
			XmlDocument xmldoc = new XmlDocument();
			xmldoc.Load(FileName);
			XmlNodeList xmlList = xmldoc.GetElementsByTagName("PrintInfo");
			if (xmlList.Count == 0) return;

			//�q�m�[�h���X�g���e�m�[�h�iTAG�j���擾
			bool breakFlg = false;
			foreach(XmlNode listNode in xmlList)
			{
				XmlNode childNode = listNode.FirstChild;            //�ŏ���TAG���擾
				while(childNode != null)
				{
					XmlNode childnextNode = childNode.NextSibling;  //����TAG���擾���Ă���

					//�폜�Ώۂ�PDF�t�@�C���p�X�Ɠ����L�q�̂���
					//TAG�̋L�q��S�č폜���邱�Ƃ�XML��̈�������폜����B
					if (childNode.LocalName == "PdfFileName")
					{
						if (childNode.InnerText == prtItm.PdfFileName)
						{
							listNode.ParentNode.RemoveChild(listNode);
							xmldoc.Save(FileName);
							breakFlg = true;
							break;
						}
					}
					childNode = childnextNode;
				}
				if (breakFlg) break;
			}

			//�����񂪑S�č폜���ꂽ�ꍇ�̓t�@�C�����폜����
			if (xmldoc.GetElementsByTagName("PrintInfo").Count == 0)
			{
				try
				{
					File.Delete(FileName);
				}
				catch
				{
				}
			}
		        
		}

// ------------------------------------------------------>>MOTO

		/// <summary>
		/// �S����t�@�C���폜����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���X�g�ɂ���PDF�t�@�C����S�č폜���܂��B</br>
		/// <br>Programmer : 90030 ���с@�^��</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			// �����̃`�F�b�N		2008.03.11 Y.Sasaki ADD
			if (this.CheckRoleManeger() != 0) return;

			//TODO:(߄D�)� �� �����ł̓��X�g�ɂ���S�t�@�C�����폜���܂�
			//���X�g�ɂ�������擾���A�폜���܂�
			PrintInfoItem Itm = new PrintInfoItem();

			//�@�e�m�[�h�Ō������܂�
			foreach (Infragistics.Win.UltraWinTree.UltraTreeNode wTreeNode in UTlistVew.Nodes)
			{
				//�A�e�m�[�h�ɕt������q�m�[�h�̏����擾���܂�
				int NodesCount = wTreeNode.Nodes.Count;
				for (int ix = NodesCount-1; ix >= 0 ; ix--)
				{
					Itm = NodeKeyToItem(wTreeNode.Nodes[ix].Key);
					if (Itm != null)
					{
						int ErrStatus = 0;
						PdfFileDeleteProc(Itm, ErrStatus);
						if (ErrStatus != 0 )
						{
//					        MessageBox.Show(
//						    "���ݕ\�����̂��ߍ폜�ł��܂���B",
//						    "�폜�ł��܂���",
//						    MessageBoxButtons.OK,
//						    MessageBoxIcon.Error,
//						    MessageBoxDefaultButton.Button1);
                            MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���ݕ\�����̂��ߍ폜�ł��܂���B",-1,"menuItem2_Click");
                            return;
						}//if (ErrStatus != 0 )
					}//if (Itm != null)
				}//for (int ix = NodesCount-1; ix >= 0 ; ix--)
			}//foreach-Parent

			//�ēx���X�g�\�����s���܂�
			setListData();
		}

		/// <summary>
		/// ����O���[�v����t�@�C���폜����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���X�g�ɂ���w�肵���O���[�v��PDF�t�@�C�����폜���܂��B</br>
		/// <br>Programmer : 90030 ���с@�^��</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			// �����̃`�F�b�N		2008.03.11 Y.Sasaki ADD
			if (this.CheckRoleManeger() != 0) return;

			//TODO:(�L�E��E�M) �w�肵���O���[�v��PDF�t�@�C�����폜���܂�
			//���X�g�ɂ�������擾���A�폜���܂�
			PrintInfoItem Itm = new PrintInfoItem();

			//�@�q�m�[�h�ɑ΂���e�m�[�h�̏����擾���܂�
			Infragistics.Win.UltraWinTree.UltraTreeNode wTreeNode = new Infragistics.Win.UltraWinTree.UltraTreeNode();
			Infragistics.Win.UltraWinTree.UltraTreeNode wTreeNodeParent = new Infragistics.Win.UltraWinTree.UltraTreeNode();
			wTreeNode = UTlistVew.SelectedNodes[0];	//�q�m�[�h���
			wTreeNodeParent = wTreeNode.Parent;		//�q�ɑ΂���e�m�[�h���
			
			//�A�e�m�[�h�ɕt������q�m�[�h�̏����擾���܂�
			int NodesCount = wTreeNode.Parent.Nodes.Count;
			for (int ix = NodesCount-1; ix >= 0 ; ix--)
			{
				Itm = NodeKeyToItem(wTreeNodeParent.Nodes[ix].Key);
				if (Itm != null)
				{
					int ErrStatus = 0;
					PdfFileDeleteProc(Itm, ErrStatus);
					if (ErrStatus != 0 )
					{
//						MessageBox.Show(
//							"���ݕ\�����̂��ߍ폜�ł��܂���B",
//							"�폜�ł��܂���",
//							MessageBoxButtons.OK,
//							MessageBoxIcon.Error,
//							MessageBoxDefaultButton.Button1);
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���ݕ\�����̂��ߍ폜�ł��܂���B",-1,"menuItem3_Click");
                        return;
					}//if (ErrStatus != 0 )
				}//if (Itm != null)
			}//for (int ix = NodesCount-1; ix >= 0 ; ix--)

			//�ēx���X�g�\�����s������
			setListData();
		}

		/// <summary>
		/// �w����ȑO�̈���t�@�C���폜����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �w�肵�����ȑO��PDF�t�@�C�����폜���܂��B</br>
		/// <br>Programmer : 90030 ���с@�^��</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			// �����̃`�F�b�N		2008.03.11 Y.Sasaki ADD
			if (this.CheckRoleManeger() != 0) return;

			//�w������擾���܂�
			//�w�肪���ł͂Ȃ��T�⌎�̏ꍇ�͂��̂Ȃ��̏I���̓����擾���܂�
			DateTime dt = DateTime.MinValue;			// ���t���[�N(�����l=MinValue)
			dt = monthCalendar.SelectionEnd.Date;
			string wstr;								// ������ҏW���[�N
			ArrayList PrtItmList = new ArrayList();		// ���t�P�ʂ̐ݒ�p�R���N�V����

			//�擾�������t���ȑO�̃t�@�C����S�č폜���܂�
			if (UdsDateType.Value != null)
			{
				// ���[���
				foreach(PrintInfoItem PrtKidInf in _PrintKindInfo)
				{
					// �R���N�V����������
					PrtItmList.Clear();
					// ���t�\�[�g�p�C���^�[�t�F�[�X����
					PrintInfoComparer pc = new PrintInfoComparer();
					pc.Key = PrintInfoComparer.SortKey.PrintOutDateTime;
					// �~�����w��
					pc.Order = SortOrder.Descending;
					// ���t�Ń\�[�g����
					_PrintInfoItems.Sort(pc);
					// ���t�Ō�������
					foreach (PrintInfoItem Itm in _PrintInfoItems)
					{
						//���t�̔��f
						if (Itm.PrintOutDateTime.Date > dt.Date) continue;
						// ���[��ʂ͓����ł��邩�H
						if (PrtKidInf.PrintKey == Itm.PrintKey)
						{
							// �A�C�e����ǉ�����
							PrtItmList.Add(Itm);
						}
					}//foreach (PrintInfoItem Itm in _PrintInfoItems)

					// �R���N�V�����̒��g��TreeVew�ɐݒ肷��(��ʂ��Ƃ�)
					if (PrtItmList.Count > 0)
					{
						// �e�m�[�h�𐶐�
						wstr = PrtKidInf.PrintName;
						Infragistics.Win.UltraWinTree.UltraTreeNode topNode = new Infragistics.Win.UltraWinTree.UltraTreeNode("",wstr);
						foreach (PrintInfoItem Itm in PrtItmList)
						{
							// �q�m�[�h���폜����
							if (Itm != null)
							{
								int ErrStatus = 0;
								PdfFileDeleteProc(Itm, ErrStatus);
								if (ErrStatus != 0 )
								{
//									MessageBox.Show(
//										"���ݕ\�����̂��ߍ폜�ł��܂���B",
//										"�폜�ł��܂���",
//										MessageBoxButtons.OK,
//										MessageBoxIcon.Error,
//										MessageBoxDefaultButton.Button1);
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���ݕ\�����̂��ߍ폜�ł��܂���B",-1,"menuItem3_Click");
                                    return;
								}//if (ErrStatus != 0 )
							}//if (Itm != null)
						}//foreach (PrintInfoItem Itm in PrtItmList)
					}//if (PrtItmList.Count > 0)
				}//foreach(PrintInfoItem PrtKidInf in _PrintKindInfo)

				//�ēx���X�g�\�����s���܂�
				setListData();

			}//if (UdsDateType.Value != null)

		}

		/// <summary>
		/// PDF�t�@�C���폜����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �w�肵��PDF�t�@�C�����폜���܂��B</br>
		/// <br>Programmer : 90030 ���с@�^��</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		private void PdfFileDeleteProc(PrintInfoItem Itm, int ErrStatus)
		{
			ErrStatus = 0;

			if (Itm != null)
			{
				try //��O������
				{
					File.Delete(Itm.PdfFileName);
				}
				catch
				{
					ErrStatus = -1;
					return;
				}
				finally
				{
					//
				}

				// �t�@�C�����Ō�������
				//_PrintInfoItems����폜����
				foreach (PrintInfoItem prtItm in _PrintInfoItems)
				{
					// ���[��ʂ͓����ł��邩�H
					if((prtItm.PrintKey == Itm.PrintKey) && (prtItm.PdfFileName == Itm.PdfFileName))
					{
						// �A�C�e�����폜����
						_PrintInfoItems.Remove(prtItm);
						//XML�t�@�C�����폜����
						DeletePrintInfXML(prtItm);
						break;
					}
				}//foreach
			}//if (Itm != null)
		}

		#region ���@�V�X�e�����[���`�F�b�N
		/// <summary>
		/// ���[���`�F�b�N
		/// </summary>
		/// <returns>0�F�����L��A-1�F��������</returns>
		/// <remarks>
		/// <br>Note       : ������^�̐����𐔎��^�ɕύX����</br>
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2008.03.11</br>
		/// </remarks>
		private int CheckRoleManeger()
		{
			try
			{

				// DI�R���e�i�̃C���X�^���X��
				if (this._serviceInterfaceFactory == null)
					this._serviceInterfaceFactory = new ServiceInterfaceFactory();

				// �C���^�t�F�[�X�̎擾
				if (this._iNsMenuRoleManager == null)
					this._iNsMenuRoleManager = (INsMenuRoleManager)this._serviceInterfaceFactory.GetObject("INsMenuRoleManager");

				if (this._iNsMenuRoleManager == null)
					return 0;
				// �� serviceInterfaceFactory.GetObject ���g�p���� iNsMenuRoleManager ���擾���邱�Ƃ��ړI�ł��̂ŁA
				//    serviceInterfaceFactory.GetObject �́A���t���N�V�������g�p���Ď��s���Ă��\���܂���
				//    Broadleaf.Application.Common.ServiceInterfaceFactory�̃A�Z���u��ID�́ASFCMN00040C.DLL �ł�
				//----------------------------------------------------------------------------------------------

				// PDF�o�͂̃V�X�e�����[���`�F�b�N
				RoleCheckInfo roleCheckInfo = new RoleCheckInfo();

				roleCheckInfo.ShowMessage = true;																											// true �ɐݒ肷��� "���̋@�\�͎g�p��������Ă��܂���h���̃��b�Z�[�W���o�͂����
				roleCheckInfo.SystemFunctionCd = "MENU-5028";																					// ���[���@�\�R�[�h(PDF�o�͋@�\:MENU-5028)
				roleCheckInfo.EmployeeCode = this._loginEmployee.EmployeeCode;												// ���O�C���]�ƈ��R�[�h

				// ���[�������`�F�b�N
				bool chkRes = this._iNsMenuRoleManager.CheckPossibleToUseFunction(ref roleCheckInfo);

				if (chkRes)
				{
					return 0;
				}
				else
				{
					return -1;
				}
			}
			catch (Exception)
			{
				return 0;
			}
		}
		#endregion

		/// <summary>
		/// �G���[MSG�\������
		/// </summary>
		/// <param name="level">�\�����x��</param>
		/// <param name="msg">�\�����b�Z�[�W</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <param name="proc">���������\�b�hID</param>
		/// <remarks>
		/// <br>Programmer : 94012 �|���@����</br>
		/// <br>Date       : 2005.09.26</br>
		/// </remarks>
		private void MsgDispProc(emErrorLevel level, string msg, int status, string proc)
		{
			DialogResult dlresult = new DialogResult();

			dlresult = TMsgDisp.Show(
				level,                              //�G���[���x��
				UNITID,                             //UNIT�@ID
				PGNM,                               //�v���O��������
				proc,                               //�v���Z�XID
				"",                                 //�I�y���[�V����
				msg,                                //���b�Z�[�W
				status,                             //�X�e�[�^�X
				null,                               //�I�u�W�F�N�g
				MessageBoxButtons.OK,               //�_�C�A���O�{�^���w��
				MessageBoxDefaultButton.Button1     //�_�C�A���O�����{�^���w��
				);
		}
	}

	/// <summary>
	/// Class1 �̊T�v�̐����ł��B
	/// </summary>
	//���ёւ�����@���`����N���X
	//IComparer�C���^�[�t�F�C�X����������
	public class PrintInfoComparer : IComparer
	{
		/// <summary>
		/// ���ёւ�����@�i�f�t�H���g�j�E�E�E����
		/// </summary>
		public SortOrder Order = SortOrder.Ascending;

		/// <summary>
		/// ���ёւ��鍀��(�f�t�H���g�j�E�E�E���t
		/// </summary>
		public SortKey Key = SortKey.PrintOutDateTime;

		/// <summary>
		/// �\�[�gKEY��`
		/// </summary>
		public enum SortKey
		{
			/// <summary>Id</summary>
			Id,
			/// <summary>���[����</summary>
			PrintKey,
			/// <summary>���s��</summary>
			PrintOutDate,
			/// <summary>���s������</summary>
			PrintOutDateTime,
		}
		/// <summary>
		/// x��y��菬�����Ƃ��̓}�C�i�X�̐��A�傫���Ƃ��̓v���X�̐�
		/// �����Ƃ���0��Ԃ�
		/// </summary>
		/// <param name="x">��r���I�u�W�F�N�g</param>
		/// <param name="y">��r��I�u�W�F�N�g</param>
		/// <returns>��r����</returns>
		public int Compare(object x, object y)
		{
			int result = 0;
			PrintInfoItem cx = (PrintInfoItem) x;
			PrintInfoItem cy = (PrintInfoItem) y;

			if (Key == SortKey.Id)
			{
				// Id�ŕ��ёւ���
				result = cx.Id.CompareTo(cy.Id);
			}
			else if (Key == SortKey.PrintKey)
			{
				// ��ʂŕ��ёւ���
				result = string.Compare(cx.PrintKey, cy.PrintKey);
			}
			else if (Key == SortKey.PrintOutDate)
			{
				// ���s���t�ŕ��ёւ���
				result = DateTime.Compare(cx.PrintOutDateTime.Date, cy.PrintOutDateTime.Date);
			}
			else if (Key == SortKey.PrintOutDateTime)
			{
				// ���s���t�����ŕ��ёւ���
				result = DateTime.Compare(cx.PrintOutDateTime, cy.PrintOutDateTime);
			}
			//�~���̂Ƃ���+-���t�]������
			if (Order == SortOrder.Descending)
			{
				result = -result;
			}
			//���ʂ�Ԃ�
			return result;
		}
	}

	/// <summary>
	/// ���[����ݒ�
	/// </summary>
	public class PrintInfoItem
	{
		/// <summary>
		/// GUID
		/// </summary>
		private Guid _Id;
		/// <summary>
		/// ���[�敪
		/// </summary>
		private string _PrintKey;
		/// <summary>
		/// ���s���t����
		/// </summary>
		private DateTime _PrintOutDateTime;
		/// <summary>
		/// PDF�t�@�C����
		/// </summary>
		private string _PdfFileName;
		/// <summary>
		/// ���[��
		/// </summary>
		private string _PrintName;
		/// <summary>
		/// ���[�ڍז�
		/// </summary>
		private string _PrintDetailName;
		/// <summary>
		/// ���s�Җ�
		/// </summary>
		private string _LoginWorkerName;

		/// <summary>
		/// ID
		/// </summary>
		public Guid Id
		{
			get { return _Id; }
		}
		/// <summary>
		/// ���[�敪
		/// </summary>
		public string PrintKey
		{
			get { return _PrintKey; }
			set { _PrintKey = value; }
		}
		/// <summary>
		/// ���s���t����
		/// </summary>
		public DateTime PrintOutDateTime
		{
			get { return _PrintOutDateTime; }
			set { _PrintOutDateTime = value; }
		}
		/// <summary>
		/// PDF�t�@�C����
		/// </summary>
		public string PdfFileName
		{
			get { return _PdfFileName; }
			set { _PdfFileName = value; }
		}
		/// <summary>
		/// ���[��
		/// </summary>
		public string PrintName
		{
			get { return _PrintName; }
			set { _PrintName = value; }
		}
		/// <summary>
		/// ���[�ڍז�
		/// </summary>
		public string PrintDetailName
		{
			get { return _PrintDetailName; }
			set { _PrintDetailName = value; }
		}
		/// <summary>
		/// ���s�Җ�
		/// </summary>
		public string LoginWorkerName
		{
			get { return _LoginWorkerName; }
			set { _LoginWorkerName = value; }
		}
		
		/// <summary>
		/// �R���X�g���N�^��`
		/// </summary>
		/// <param name="id">ID</param>
		/// <param name="P0">���[�敪</param>
		/// <param name="P1">���s���t����</param>
		/// <param name="P2">PDF�t�@�C����</param>
		/// <param name="P3">���[��</param>
		/// <param name="P4">���[�ڍז�</param>
		/// <param name="P5">���s�Җ�</param>
		public PrintInfoItem(Guid id, string P0, DateTime P1, string P2, string P3, string P4, string P5)
		{
			// ID
			_Id = id;
			// ���[�敪
			_PrintKey = P0;
			// ���s���t����
			_PrintOutDateTime = P1;
			// PDF�t�@�C����
			_PdfFileName = P2;
			// ���[��
			_PrintName = P3;
			// ���[�ڍז�
			_PrintDetailName = P4;
			// ���s�Җ�
			_LoginWorkerName = P5;
		}
		
		/// <summary>
		/// �R���X�g���N�^��`
		/// </summary>
		/// <param name="P0">���[�敪</param>
		/// <param name="P1">���s���t����</param>
		/// <param name="P2">PDF�t�@�C����</param>
		/// <param name="P3">���[��</param>
		/// <param name="P4">���[�ڍז�</param>
		/// <param name="P5">���s�Җ�</param>
		public PrintInfoItem(string P0, DateTime P1, string P2, string P3, string P4, string P5)
			: this( Guid.NewGuid(), P0, P1, P2, P3, P4, P5)
		{
			// ���[�敪
			_PrintKey = P0;
			// ���s���t����
			_PrintOutDateTime = P1;
			// PDF�t�@�C����
			_PdfFileName = P2;
			// ���[��
			_PrintName = P3;
			// ���[�ڍז�
			_PrintDetailName = P4;
			// ���s�Җ�
			_LoginWorkerName = P5;
		}
		
		/// <summary>
		/// �R���X�g���N�^��`
		/// </summary>
		/// <param name="P0">���[�敪</param>
		/// <param name="P1">���[��</param>
		public PrintInfoItem(string P0, string P1)
			: this( Guid.NewGuid(), P0, DateTime.Now, string.Empty, P1, string.Empty, string.Empty)
		{
			// ���[�敪
			_PrintKey = P0;
			// ���[��
			_PrintName = P1;
		}

		/// <summary>
		/// �R���X�g���N�^��`
		/// </summary>
		public PrintInfoItem()
			: this(string.Empty, DateTime.Now, string.Empty, string.Empty, string.Empty, string.Empty)
		{
		}
	}
	/// <summary>
	/// �f���Q�[�g�錾
	/// </summary>
	public delegate void SelectNodeEvent(string PrintKey, string PrintName, string PdfFileName);
}

