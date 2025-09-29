using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���������\���t�h�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���������̓��e��\�����܂��B</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
    /// <br></br>
    /// <br>Update Note: 2007.01.31 18322 T.Kimura MA.NS�p�ɕύX</br>
    /// <br>                                         �E����`�[�ǉ�</br>
    /// <br>                                         �E��ʃX�L���ύX�Ή�</br>
    /// <br>Update Note: 2007.10.05 20081 �D�c �E�l DC.NS�p�ɕύX</br>
    /// </remarks>
	public class SFUKK01415UA : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private Infragistics.Win.UltraWinGrid.UltraGrid grdDepositAllowance;
		private System.Windows.Forms.Panel SFUKK01415UA_Fill_Panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFUKK01415UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFUKK01415UA_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFUKK01415UA_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFUKK01415UA_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager;
		private Broadleaf.Library.Windows.Forms.TLine tLine1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Broadleaf.Library.Windows.Forms.TLine tLine2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel labTotalDepositAllowance;
		private Infragistics.Win.Misc.UltraLabel labSlipNo;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// ���������\���t�h�N���X �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �g�p���郁���o�̏��������s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		public SFUKK01415UA()
		{
			InitializeComponent();

			// ���������\���A�N�Z�X�N���X
			this.depositAlwViewAcs = new DepositAlwViewAcs();

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			// ����p�ʓ����I�v�V����
			this._optSeparateCost = false;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            
            // ��ƃR�[�h
			this._enterpriseCode = "";

			// ���Ӑ�R�[�h
			this._customerCode = 0;

			// �󒍔ԍ�
			//this._acceptOdrNo = 0;     // 2007.10.15 del

            // �󒍃X�e�[�^�X
            this._acptAnOdrStatus = 0;   // 2007.10.15 add

            // �� 20070131 18322 c MA.NS�p�ɕύX
			//// �`�[�ԍ�
			//this._slipNo = "";

            // ����`�[�ԍ�
			this._salesSlipNum = "";
            // �� 20070131 18322 c

			// ����t���O
			this._FirstFlg = true;
		}
		# endregion

		# region Dispose
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnClose");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnClose");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK01415UA));
            this.grdDepositAllowance = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.SFUKK01415UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.labTotalDepositAllowance = new Infragistics.Win.Misc.UltraLabel();
            this.tLine2 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.labSlipNo = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tLine1 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraStatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this._SFUKK01415UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFUKK01415UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFUKK01415UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepositAllowance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager)).BeginInit();
            this.SFUKK01415UA_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDepositAllowance
            // 
            this.grdDepositAllowance.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdDepositAllowance.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grdDepositAllowance.Location = new System.Drawing.Point(8, 68);
            this.grdDepositAllowance.Name = "grdDepositAllowance";
            this.grdDepositAllowance.Size = new System.Drawing.Size(451, 184);
            this.grdDepositAllowance.TabIndex = 0;
            this.grdDepositAllowance.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdDepositAllowance_InitializeLayout);
            // 
            // ultraToolbarsManager
            // 
            this.ultraToolbarsManager.DesignerFlags = 1;
            this.ultraToolbarsManager.DockWithinContainer = this;
            this.ultraToolbarsManager.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.Text = "�W��";
            ultraToolbar1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1});
            this.ultraToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            buttonTool2.SharedProps.Caption = "�߂�(&C)";
            buttonTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.ultraToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2});
            this.ultraToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager_ToolClick);
            // 
            // SFUKK01415UA_Fill_Panel
            // 
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.labTotalDepositAllowance);
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.tLine2);
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.ultraLabel4);
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.labSlipNo);
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.ultraLabel2);
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.tLine1);
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.ultraStatusBar);
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.ultraLabel1);
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.grdDepositAllowance);
            this.SFUKK01415UA_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SFUKK01415UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SFUKK01415UA_Fill_Panel.Location = new System.Drawing.Point(0, 27);
            this.SFUKK01415UA_Fill_Panel.Name = "SFUKK01415UA_Fill_Panel";
            this.SFUKK01415UA_Fill_Panel.Size = new System.Drawing.Size(466, 307);
            this.SFUKK01415UA_Fill_Panel.TabIndex = 0;
            // 
            // labTotalDepositAllowance
            // 
            appearance1.TextHAlign = Infragistics.Win.HAlign.Right;
            appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.labTotalDepositAllowance.Appearance = appearance1;
            this.labTotalDepositAllowance.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labTotalDepositAllowance.Location = new System.Drawing.Point(322, 255);
            this.labTotalDepositAllowance.Name = "labTotalDepositAllowance";
            this.labTotalDepositAllowance.Size = new System.Drawing.Size(128, 23);
            this.labTotalDepositAllowance.TabIndex = 10;
            // 
            // tLine2
            // 
            this.tLine2.BackColor = System.Drawing.Color.Transparent;
            this.tLine2.ForeColor = System.Drawing.Color.Gray;
            this.tLine2.Location = new System.Drawing.Point(234, 279);
            this.tLine2.Name = "tLine2";
            this.tLine2.Size = new System.Drawing.Size(224, 8);
            this.tLine2.TabIndex = 9;
            this.tLine2.Text = "tLine2";
            // 
            // ultraLabel4
            // 
            appearance2.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance2.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel4.Appearance = appearance2;
            this.ultraLabel4.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel4.Location = new System.Drawing.Point(234, 255);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(80, 23);
            this.ultraLabel4.TabIndex = 8;
            this.ultraLabel4.Text = "�������v";
            // 
            // labSlipNo
            // 
            appearance3.TextHAlign = Infragistics.Win.HAlign.Right;
            appearance3.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.labSlipNo.Appearance = appearance3;
            this.labSlipNo.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labSlipNo.Location = new System.Drawing.Point(130, 9);
            this.labSlipNo.Name = "labSlipNo";
            this.labSlipNo.Size = new System.Drawing.Size(80, 23);
            this.labSlipNo.TabIndex = 7;
            // 
            // ultraLabel2
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance4.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.FontData.BoldAsString = "True";
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance4.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel2.Appearance = appearance4;
            this.ultraLabel2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(8, 43);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(451, 24);
            this.ultraLabel2.TabIndex = 6;
            this.ultraLabel2.Text = "�� �� �� �� �� ��";
            // 
            // tLine1
            // 
            this.tLine1.BackColor = System.Drawing.Color.Transparent;
            this.tLine1.ForeColor = System.Drawing.Color.Gray;
            this.tLine1.Location = new System.Drawing.Point(10, 33);
            this.tLine1.Name = "tLine1";
            this.tLine1.Size = new System.Drawing.Size(224, 8);
            this.tLine1.TabIndex = 5;
            this.tLine1.Text = "tLine1";
            // 
            // ultraStatusBar
            // 
            this.ultraStatusBar.Location = new System.Drawing.Point(0, 284);
            this.ultraStatusBar.Name = "ultraStatusBar";
            this.ultraStatusBar.Size = new System.Drawing.Size(466, 23);
            this.ultraStatusBar.TabIndex = 3;
            this.ultraStatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // ultraLabel1
            // 
            appearance5.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance5.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel1.Appearance = appearance5;
            this.ultraLabel1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(10, 9);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 2;
            this.ultraLabel1.Text = "�`�[�ԍ�";
            // 
            // _SFUKK01415UA_Toolbars_Dock_Area_Left
            // 
            this._SFUKK01415UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFUKK01415UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFUKK01415UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFUKK01415UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFUKK01415UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 27);
            this._SFUKK01415UA_Toolbars_Dock_Area_Left.Name = "_SFUKK01415UA_Toolbars_Dock_Area_Left";
            this._SFUKK01415UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 307);
            this._SFUKK01415UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager;
            // 
            // _SFUKK01415UA_Toolbars_Dock_Area_Right
            // 
            this._SFUKK01415UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFUKK01415UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFUKK01415UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFUKK01415UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFUKK01415UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(466, 27);
            this._SFUKK01415UA_Toolbars_Dock_Area_Right.Name = "_SFUKK01415UA_Toolbars_Dock_Area_Right";
            this._SFUKK01415UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 307);
            this._SFUKK01415UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager;
            // 
            // _SFUKK01415UA_Toolbars_Dock_Area_Top
            // 
            this._SFUKK01415UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFUKK01415UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFUKK01415UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SFUKK01415UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFUKK01415UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SFUKK01415UA_Toolbars_Dock_Area_Top.Name = "_SFUKK01415UA_Toolbars_Dock_Area_Top";
            this._SFUKK01415UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(466, 27);
            this._SFUKK01415UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager;
            // 
            // _SFUKK01415UA_Toolbars_Dock_Area_Bottom
            // 
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 334);
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom.Name = "_SFUKK01415UA_Toolbars_Dock_Area_Bottom";
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(466, 0);
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager;
            // 
            // SFUKK01415UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(466, 334);
            this.Controls.Add(this.SFUKK01415UA_Fill_Panel);
            this.Controls.Add(this._SFUKK01415UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._SFUKK01415UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFUKK01415UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._SFUKK01415UA_Toolbars_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SFUKK01415UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "�������� ����";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SFUKK01415UA_KeyDown);
            this.Load += new System.EventHandler(this.SFUKK01415UA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDepositAllowance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager)).EndInit();
            this.SFUKK01415UA_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		# region Private Menbers
		//***************************************************************
		// �����o�[
		//***************************************************************
		/// <summary>���������\���A�N�Z�X�N���X</summary>
		private DepositAlwViewAcs depositAlwViewAcs;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>����p�ʓ����I�v�V����</summary>
		private bool _optSeparateCost;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>��ƃR�[�h</summary>
		private string _enterpriseCode;

		/// <summary>���Ӑ�R�[�h</summary>
		private int _customerCode;

		///// <summary>�󒍔ԍ�</summary>
		//private int _acceptOdrNo;    // 2007.10.15 del

		/// <summary>�󒍃X�e�[�^�X</summary>
		private int _acptAnOdrStatus;  // 2007.10.15 add

        // �� 20070131 18322 c MA.NS�p�ɕύX
		///// <summary>�`�[�ԍ�</summary>
		//private string _slipNo;

        /// <summary>����`�[�ԍ�</summary>
        private string _salesSlipNum;
        // �� 20070131 18322 c

		/// <summary>����t���O</summary>
		private bool _FirstFlg;
		# endregion

		# region public Methods
		/// <summary>
		/// ���������\������(�󒍓`�[����������)
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
		/// <param name="salesSlipNum">����`�[�ԍ�</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�󒍔ԍ��Ɍ��т�����������\�����܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.08.26</br>
        /// <br>Update Note : 2007.01.31 18322 T.Kimura MA.NS�p�ɕύX</br>
		/// </remarks>
        // �� 20070131 18322 c MA.NS�p�ɕύX
		//public void ViewAllowanceOfAcceptOdr(bool optSeparateCost, string enterpriseCode, int customerCode, int acceptOdrNo, string slipNo)
        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
        //public void ViewAllowanceOfAcceptOdr(bool optSeparateCost, string enterpriseCode, int customerCode, int acptAnOdrStatus, string salesSlipNum)
        public void ViewAllowanceOfAcceptOdr(string enterpriseCode, int customerCode, int acptAnOdrStatus, string salesSlipNum)
        // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
        // �� 20070131 18322 c
		{
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			// ����p�ʓ����I�v�V����
			this._optSeparateCost = optSeparateCost;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            
            // ��ƃR�[�h
			this._enterpriseCode = enterpriseCode;

			// ���Ӑ�R�[�h
			this._customerCode = customerCode;

			// �󒍔ԍ�
			//this._acceptOdrNo = acceptOdrNo;       // 2007.10.15 del

            this._acptAnOdrStatus = acptAnOdrStatus; // 2007.10.15 add

            // �� 20070131 18322 c MA.NS�p�ɕύX
			//// �`�[�ԍ�
			//this._slipNo = slipNo;

            // ����`�[�ԍ�
            this._salesSlipNum = salesSlipNum;
            // �� 20070131 18322 c

			labSlipNo.Text = "";
			ultraStatusBar.Text = "";

			// ��ʕ\��
			this.ShowDialog();
		}
		# endregion

		# region Private Methods
		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.26</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			ImageList imageList16 = IconResourceManagement.ImageList16;

			ultraToolbarsManager.ImageListSmall = imageList16;

			// �߂�{�^��
			Infragistics.Win.UltraWinToolbars.ButtonTool ButtonClose = (Infragistics.Win.UltraWinToolbars.ButtonTool)ultraToolbarsManager.Tools["btnClose"];
			if (ButtonClose != null)
			{
				ButtonClose.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
			}
		}
		
		/// <summary>
		/// �����O���b�h�����ݒ菈������
		/// </summary>
		/// <param name="grd">�ΏۃO���b�h</param>
		/// <remarks>
		/// <br>Note       : �����O���b�h�̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.26</br>
		/// </remarks>
		private void InitializeDepositAllowanceList(Infragistics.Win.UltraWinGrid.UltraGrid grd)
		{
			// �񕝂��I�[�g�ɐݒ�
            grd.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

			// �s�I��ݒ� �s�I�𖳂����[�h(�A�N�e�B�u�̂�)
			grd.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
			grd.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			grd.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;

			// �O���b�h�S�̂̊O�ϐݒ�
            // �� 20070131 18322 d MA.NS�p�ɕύX
			//grd.DisplayLayout.Appearance.BackColor = Color.White;
			//grd.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
			//grd.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            // �� 20070131 18322 d

			// �s�I�����[�h�̐ݒ�
			grd.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

			// �s�̊O�ϐݒ�
			grd.DisplayLayout.Override.RowAppearance.BackColor = Color.White;

			// 1�s�����̊O�ϐݒ�
			grd.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;

			// �I���s�̊O�ϐݒ�
			grd.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
			grd.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
			grd.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

			// �A�N�e�B�u�s�̊O�ϐݒ�
			grd.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
			grd.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
			grd.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

			// �w�b�_�[�̊O�ϐݒ�
			grd.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
			grd.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			grd.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			grd.DisplayLayout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
			grd.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			grd.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			grd.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			grd.DisplayLayout.Override.HeaderAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

			// �s�Z���N�^�[�̊O�ϐݒ�
			grd.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
			grd.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			grd.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

			// �s�t�B���^�[�̐ݒ�
//			grd.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
//			grd.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
//			grd.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;

			// ���������̃X�N���[���X�^�C��
			grd.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;

			// ������ʕ\��(�X�v���b�^�[)�̕\���ݒ�
			grd.DisplayLayout.MaxRowScrollRegions = 1;

			// �X�N���[���o�[�ŏI�s����
			grd.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;

			// �w�b�_�[�N���b�N�A�N�V�����ݒ�
			grd.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;

			// �t�B���^�̎g�p�ݒ�
//			grd.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

			// �u�Œ��v�v�b�V���s���A�C�R��������
			grd.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

			// �񕝂̐ݒ�
			grd.DisplayLayout.Bands[DepositAlwViewAcs.ctDepositAlwDataTable].Columns[DepositAlwViewAcs.ctDepositSlipNo].Width	= 180;					// �����ԍ�
		}

		/// <summary>
		/// ���������O���b�h�f�[�^�r���[�o�C���h����
		/// </summary>
		/// <param></param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ���������O���b�h�Ƀf�[�^�r���[���o�C���h���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void BindingDsDepositAlwView()
		{
			// ���������O���b�h��View���o�C���h����
			grdDepositAllowance.DataSource = depositAlwViewAcs.GetDsDepositAlwInfo().Tables[DepositAlwViewAcs.ctDepositAlwDataTable].DefaultView;
		}
		
		/// <summary>
		/// ���������O���b�h�r���[�ݒ菈��
		/// </summary>
		/// <param></param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ���������O���b�h�Ƀf�[�^�r���[���o�C���h���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void SettingDepositAlwView()
		{
			Infragistics.Win.UltraWinGrid.UltraGridBand bdDepositAlw = grdDepositAllowance.DisplayLayout.Bands[DepositAlwViewAcs.ctDepositAlwDataTable];
			
			// ���������O���b�h��̏����ݒ�
			bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositSlipNo].Format				= "000000000";			// �����ԍ�
			// bdDepositAlw.Columns[DepositAlwViewAcs.ctAcceptAnOrderNo].Format			= "#########";			// �󒍔ԍ�  // 2007.10.05 hikita del
            // �� 20070131 18322 c MA.NS�p�ɕύX
			//bdDepositAlw.Columns[DepositAlwViewAcs.ctAcpOdrDepositAlwc].Format			= "###,###,###,##0";	// ���������z ��
			//bdDepositAlw.Columns[DepositAlwViewAcs.ctVarCostDepoAlwc].Format			= "###,###,###,##0";	// ���������z ����p
            // �� 20070131 18322 c
			bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositAllowance].Format			= "###,###,###,##0";	// ���������z ����
			bdDepositAlw.Columns[DepositAlwViewAcs.ctReconcileAddUpADate].Format		= "####/##/##";			// �����v���

			bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositSlipNo].CellAppearance.TextHAlign		= Infragistics.Win.HAlign.Right;	// �����`�[�ԍ�
            // �� 20070131 18322 c MA.NS�p�ɕύX
			//bdDepositAlw.Columns[DepositAlwViewAcs.ctAcpOdrDepositAlwc].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Right;	// ���������z ��
			//bdDepositAlw.Columns[DepositAlwViewAcs.ctVarCostDepoAlwc].CellAppearance.TextHAlign		= Infragistics.Win.HAlign.Right;	// ���������z ����p
            // �� 20070131 18322 c
			bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositAllowance].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Right;	// ���������z ����

			bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositSlipNo].Header.Caption			= "�����ԍ�";		// �����ԍ�
			// bdDepositAlw.Columns[DepositAlwViewAcs.ctAcceptAnOrderNo].Header.Caption		= "�󒍔ԍ�";		// �󒍓`�[�ԍ� // 2007.10.10 hikita del
            // �� 20070131 18322 c MA.NS�p�ɕύX
			//bdDepositAlw.Columns[DepositAlwViewAcs.ctAcpOdrDepositAlwc].Header.Caption		= "�����z(��)";		// ���������z ��
			//bdDepositAlw.Columns[DepositAlwViewAcs.ctVarCostDepoAlwc].Header.Caption		= "�����z(��)";		// ���������z ����p
            // �� 20070131 18322 c
			bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositAllowance].Header.Caption		= "�����z";			// ���������z ����
			bdDepositAlw.Columns[DepositAlwViewAcs.ctReconcileDateDisp].Header.Caption		= "������";			// ������
			bdDepositAlw.Columns[DepositAlwViewAcs.ctReconcileAddUpADate].Header.Caption	= "�����v���";		// �����v���

            // �� 20070131 18322 c MA.NS�p�ɕύX
            #region SF ����p�ʓ����I�v�V�����ɂ��\������i�S�ăR�����g�A�E�g�j
            //// ����p�ʓ����I�v�V�����ɂ��\������
			//if (this._optSeparateCost == true)
			//{
			//	bdDepositAlw.Columns[DepositAlwViewAcs.ctAcpOdrDepositAlwc].Hidden		= false;				// ���������z ��
			//	bdDepositAlw.Columns[DepositAlwViewAcs.ctVarCostDepoAlwc].Hidden		= false;				// ���������z ����p
			//	bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositAllowance].Hidden		= true;					// ���������z ����
			//}
			//else
			//{
			//	bdDepositAlw.Columns[DepositAlwViewAcs.ctAcpOdrDepositAlwc].Hidden		= true;					// ���������z ��
			//	bdDepositAlw.Columns[DepositAlwViewAcs.ctVarCostDepoAlwc].Hidden		= true;					// ���������z ����p
			//	bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositAllowance].Hidden		= false;				// ���������z ����
            //}
            #endregion

			// ���������z ����
            bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositAllowance].Hidden = false;
            // �� 20070131 18322 c

			// ��ɔ�\��
			bdDepositAlw.Columns[DepositAlwViewAcs.ctReconcileDate].Hidden				= true;					// ������
			// bdDepositAlw.Columns[DepositAlwViewAcs.ctAcceptAnOrderNo].Hidden			= true;					// �󒍔ԍ�  // 2007.10.05 hikita del
			bdDepositAlw.Columns[DepositAlwViewAcs.ctReconcileAddUpADate].Hidden		= true;					// �����v���

			// �����O���b�h��W�J���� (�P�s���f�[�^�������Ă��^�C�g����\�������)
			grdDepositAllowance.Rows.ExpandAll(true);
		}
		# endregion

		# region Control Events
		/// <summary>
		/// ��ʃ��[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ގ��ɔ������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.08.26</br>
		/// </remarks>
		private void SFUKK01415UA_Load(object sender, System.EventArgs e)
		{
			if (this._FirstFlg == true)
			{
				// ��ʏ����ݒ菈��
				this.ScreenInitialSetting();

				// �������� DataSet Table �쐬����
				depositAlwViewAcs.CreateDepositAlwDataTable();

				// ���������O���b�h�f�[�^�r���[�o�C���h����
				this.BindingDsDepositAlwView();

				this._FirstFlg = false;
			}
			else
			{
				// ��������DataSet����������
				depositAlwViewAcs.ClearDsDepositAlwInfo();
			}
			
			// ���������O���b�h�r���[�ݒ菈��
			this.SettingDepositAlwView();

            // �� 20070131 18322 c MA.NS�p�ɕύX
			//// �`�[�ԍ�
			//labSlipNo.Text = _slipNo;

			// �`�[�ԍ�
			labSlipNo.Text = _salesSlipNum;
            // �� 20070131 18322 c

			labTotalDepositAllowance.Text = "";

			// ���������f�[�^�擾����
			string message;
            int st = depositAlwViewAcs.SearchAllowanceOfAcceptOdrNo(_enterpriseCode, _customerCode, _acptAnOdrStatus, _salesSlipNum, out message);
			if (st == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
                // �� 20070131 18322 c MA.NS�p�ɕύX
				//ultraStatusBar.Text = "���̎󒍓`�[�ɂ́A���������͍s���Ă��܂���B";

				ultraStatusBar.Text = "���̔���`�[�ɂ́A���������͍s���Ă��܂���B";
                // �� 20070131 18322 c
			}
			else if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// �G���[����
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, "���������̓Ǎ������Ɏ��s���܂����B" + "\r\n\r\n" + message, st, MessageBoxButtons.OK);
			}

			// �����������v
			labTotalDepositAllowance.Text = depositAlwViewAcs.GetTotalDepositAllowance().ToString("###,###,###,##0");
		}

		/// <summary>
		/// ���������O���b�h������ �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �f�[�^�\�[�X����R���g���[���Ƀf�[�^�����[�h�����Ƃ��ȂǁA
		///                   �\�����C�A�E�g�������������Ƃ��ɔ������܂��B </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.08.26</br>
		/// </remarks>
		private void grdDepositAllowance_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			// ���������O���b�h�����ݒ菈��
			this.InitializeDepositAllowanceList(grdDepositAllowance);
		}

		/// <summary>
		/// �t�H�[���j�d�x�����C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g���</param>
		/// <remarks>
		/// <br>Note       : �t�H�[����ŃL�[�������ꂽ���ɔ������܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2006.06.07</br>
		/// </remarks>
		private void SFUKK01415UA_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		/// <summary>
		/// �c�[���o�[�{�^�������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �c�[���o�[���N���b�N�������ɔ������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void ultraToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
					// �߂�
				case "btnClose":
				{
					this.Close();
					break;
				}
			}		
		}
		# endregion
	}
}
