using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Infragistics.Win.UltraWinGrid;

using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �����X�֔ԍ�������I��������E�B���h�E�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011�@����@���N</br>
	/// <br>Date       : 2006.01.11</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class PostNoSelectWindow : System.Windows.Forms.Form
	{
		
		#region �R���|�[�l���g
		
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PostNoSelectWindow_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PostNoSelectWindow_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PostNoSelectWindow_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PostNoSelectWindow_Toolbars_Dock_Area_Bottom;
		private System.ComponentModel.IContainer components;
		
		#endregion
		
		#region UI�̊O�ϐݒ胁�\�b�h

		/// <summary>
		/// UltraGrid�̔z�F���d�l�ʂ�ɐݒ肷��
		/// </summary>
		/// <param name="ugTarget"></param>
		private void setGridAppearance( Infragistics.Win.UltraWinGrid.UltraGrid ugTarget )
		{
			//�^�C�g���̊O��
			ugTarget.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
			ugTarget.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			ugTarget.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			ugTarget.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			ugTarget.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;

			//�w�i�F��ݒ�
			ugTarget.DisplayLayout.Appearance.BackColor = Color.White;
			
			//�������J�����ɓ���悤�ɐݒ肷��
			//ugTarget.DisplayLayout.AutoFitColumns = true;
            ugTarget.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

			// �I���s�̊O�ς�ݒ�
			ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
			ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
			ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

			//�s�Z���N�^�̐ݒ�
			ugTarget.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
			ugTarget.DisplayLayout.Override.RowSelectorAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
			ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			ugTarget.DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.White;

			ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			
			//�s�̃T�C�Y�ύX�s��
			ugTarget.DisplayLayout.Override.RowSizing = RowSizing.Fixed;
			
			//�C���W�Q�[�^��\��
			ugTarget.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			
			//�����̈��\��
			ugTarget.DisplayLayout.MaxColScrollRegions = 1;
			ugTarget.DisplayLayout.MaxRowScrollRegions = 1;
						
			//���݂ɍs�̐F��ς���
			ugTarget.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
			
			//�O���b�h�̔w�i�F��ς���
			ugTarget.DisplayLayout.Appearance.BackColor = Color.Gray;
			
			//�����X�N���[���o�[�̂݋���
			ugTarget.DisplayLayout.Scrollbars = Scrollbars.Automatic;
			
			//�A�N�e�B�u�s�̃t�H���g�̐F��ς���
			ugTarget.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
			
			//�A�N�e�B�u�s�̃t�H���g�𑾎��ɂ���
			ugTarget.DisplayLayout.Override.ActiveRowAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			
		}
		
		/// <summary>
		/// UltraGrid�̋�����ݒ肷��
		/// </summary>
		/// <param name="ugTarget"></param>
		private void setGridBehavior( Infragistics.Win.UltraWinGrid.UltraGrid ugTarget )
		{
			//�񕝂̎��������s��
			//ugTarget.DisplayLayout.AutoFitColumns = false;
            ugTarget.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

			//�s�̒ǉ��s��
			ugTarget.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			
			//�s�̍폜�s��
			ugTarget.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			
			// ��̈ړ��s��
			ugTarget.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
			
			// ��̌����s��
			ugTarget.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
			
			// �t�B���^�̎g�p�s��
			ugTarget.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
			
			// ���[�U�[�̃f�[�^������������
			ugTarget.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
			
			//�I����@���s�I���ɐݒ�B
			ugTarget.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			
			//�w�b�_���N���b�N�����Ƃ��͗�I����Ԃɂ���B
			ugTarget.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
			//+��I��s�ɂ��邱�ƂŃw�b�_���N���b�N���Ă������N����Ȃ�
			ugTarget.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;

			//��s�̂ݑI���\�ɂ���
			ugTarget.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
			
			//�X�N���[�����ɂ����܂ǂ��������Ă����ԂȂ̂����킩��悤�ɂ���
			ugTarget.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;

            ugTarget.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;

			//IME����
			ugTarget.ImeMode = ImeMode.Disable;			
		}
		
//		void setTEditAppearance( TEdit teTarget )
//		{
//			//�I�����ꂽ�Ƃ��̔w�i�F��ς���
//			teTarget.ActiveAppearance.BackColor = Color.FromArgb( 247, 227, 156 );
//			teTarget.ActiveAppearance.BackColor2 = Color.FromArgb( 247, 227, 156 );
//		}
//		
		//		void setTComboEditorAppearance( TComboEditor tceTarget )
		//		{
		//			//�I�����ꂽ�Ƃ��̔w�i�F��ς���
		//			tceTarget.ActiveAppearance.BackColor = Color.FromArgb( 247, 227, 156 );
		//			tceTarget.ActiveAppearance.BackColor2 = Color.FromArgb( 247, 227, 156 );
		//		}
		//
		private void setToolbarAppearance()
		{
			//�c�[���o�[�ɃA�C�R���ݒ�
			//using Broadleaf.Library.Resources;
			//SFCMN00008C
			ImageList imList = IconResourceManagement.ImageList16;
			this.ultraToolbarsManager1.ImageListSmall = imList;

			this.ultraToolbarsManager1.Toolbars[0].Tools[0].InstanceProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			this.ultraToolbarsManager1.Toolbars[0].Tools[1].InstanceProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;

			//�c�[���o�[���J�X�^�}�C�Y�s�ɂ���
			this.ultraToolbarsManager1.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockTop = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
		}
		
		//���l�̗��ݒ肷��
		private void setNumberColumnAppearance( UltraGrid ug, string strColumn, string strFormat )
		{
			ug.DisplayLayout.Bands[0].Columns[strColumn].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			ug.DisplayLayout.Bands[0].Columns[strColumn].Format = strFormat;
		}
		
		#endregion
		
		private DataTable dtDisp = null;
		
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="alAddressData"></param>
		public PostNoSelectWindow( ArrayList alAddressData )
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();
			
			//�O�ϐݒ�
			this.setToolbarAppearance();
			this.setGridAppearance( this.ultraGrid1 );
			this.setGridBehavior( this.ultraGrid1 );
			
			this.dtDisp = new DataTable();
			
			this.dtDisp.Columns.Add( "�X�֔ԍ�", typeof( string ) );
			this.dtDisp.Columns.Add( "�Z������", typeof( string ) );
			this.dtDisp.Columns.Add( "�f�[�^", typeof( AddressData ) );
			
			this.ultraGrid1.DataSource = this.dtDisp;
			
			foreach( AddressData data in alAddressData )
			{
				DataRow drAdd = this.dtDisp.NewRow();
				
				drAdd["�X�֔ԍ�"] = data.PostNo;
				drAdd["�Z������"] = data.AddressName;
				drAdd["�f�[�^"] = data;
				
				this.dtDisp.Rows.Add( drAdd );
			}
			
			this.ultraGrid1.DisplayLayout.Bands[0].Columns["�f�[�^"].Hidden = true;
			//this.ultraGrid1.DisplayLayout.AutoFitColumns = true;
            ultraGrid1.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

			this.PerformAutoFitResultColumns();
		}
		
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
		
		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("�I��(S)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("�L�����Z��(X)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("�I��(S)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("�L�����Z��(X)");
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostNoSelectWindow));
			this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
			this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
			this._PostNoSelectWindow_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._PostNoSelectWindow_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._PostNoSelectWindow_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._PostNoSelectWindow_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// ultraStatusBar1
			// 
			this.ultraStatusBar1.Location = new System.Drawing.Point(0, 229);
			this.ultraStatusBar1.Name = "ultraStatusBar1";
			this.ultraStatusBar1.Size = new System.Drawing.Size(638, 23);
			this.ultraStatusBar1.TabIndex = 0;
			this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
			// 
			// ultraToolbarsManager1
			// 
			this.ultraToolbarsManager1.DesignerFlags = 1;
			this.ultraToolbarsManager1.DockWithinContainer = this;
			this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
			ultraToolbar1.DockedColumn = 0;
			ultraToolbar1.DockedRow = 0;
			ultraToolbar1.Text = "UltraToolbar1";
			ultraToolbar1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2});
			this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
			buttonTool3.SharedProps.Caption = "�I��(&S)";
			buttonTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool4.SharedProps.Caption = "�߂�(&C)";
			buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool4});
			this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
			// 
			// _PostNoSelectWindow_Toolbars_Dock_Area_Left
			// 
			this._PostNoSelectWindow_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._PostNoSelectWindow_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._PostNoSelectWindow_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
			this._PostNoSelectWindow_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
			this._PostNoSelectWindow_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 27);
			this._PostNoSelectWindow_Toolbars_Dock_Area_Left.Name = "_PostNoSelectWindow_Toolbars_Dock_Area_Left";
			this._PostNoSelectWindow_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 202);
			this._PostNoSelectWindow_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _PostNoSelectWindow_Toolbars_Dock_Area_Right
			// 
			this._PostNoSelectWindow_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._PostNoSelectWindow_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._PostNoSelectWindow_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
			this._PostNoSelectWindow_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
			this._PostNoSelectWindow_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(638, 27);
			this._PostNoSelectWindow_Toolbars_Dock_Area_Right.Name = "_PostNoSelectWindow_Toolbars_Dock_Area_Right";
			this._PostNoSelectWindow_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 202);
			this._PostNoSelectWindow_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _PostNoSelectWindow_Toolbars_Dock_Area_Top
			// 
			this._PostNoSelectWindow_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._PostNoSelectWindow_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._PostNoSelectWindow_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
			this._PostNoSelectWindow_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
			this._PostNoSelectWindow_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
			this._PostNoSelectWindow_Toolbars_Dock_Area_Top.Name = "_PostNoSelectWindow_Toolbars_Dock_Area_Top";
			this._PostNoSelectWindow_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(638, 27);
			this._PostNoSelectWindow_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _PostNoSelectWindow_Toolbars_Dock_Area_Bottom
			// 
			this._PostNoSelectWindow_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._PostNoSelectWindow_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._PostNoSelectWindow_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
			this._PostNoSelectWindow_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
			this._PostNoSelectWindow_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 229);
			this._PostNoSelectWindow_Toolbars_Dock_Area_Bottom.Name = "_PostNoSelectWindow_Toolbars_Dock_Area_Bottom";
			this._PostNoSelectWindow_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(638, 0);
			this._PostNoSelectWindow_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// ultraGrid1
			// 
			this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ultraGrid1.Location = new System.Drawing.Point(0, 64);
			this.ultraGrid1.Name = "ultraGrid1";
			this.ultraGrid1.Size = new System.Drawing.Size(638, 165);
			this.ultraGrid1.TabIndex = 5;
			this.ultraGrid1.DoubleClick += new System.EventHandler(this.ultraGrid1_DoubleClick);
			this.ultraGrid1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ultraGrid1_KeyDown);
			this.ultraGrid1.AfterRowActivate += new System.EventHandler(this.ultraGrid1_AfterRowActivate);
			this.ultraGrid1.Resize += new System.EventHandler(this.ultraGrid1_Resize);
			// 
			// ultraLabel1
			// 
			appearance1.BackColor = System.Drawing.Color.Black;
			appearance1.BackColor2 = System.Drawing.Color.Black;
			appearance1.BorderColor = System.Drawing.Color.Blue;
			appearance1.BorderColor3DBase = System.Drawing.Color.Blue;
			appearance1.ForeColor = System.Drawing.Color.Lime;
			appearance1.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ultraLabel1.Appearance = appearance1;
			this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
			this.ultraLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
			this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ultraLabel1.Location = new System.Drawing.Point(0, 27);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(638, 37);
			this.ultraLabel1.TabIndex = 6;
			this.ultraLabel1.Text = "�X�֔ԍ����������݂��܂�";
			// 
			// PostNoSelectWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(638, 252);
			this.Controls.Add(this.ultraGrid1);
			this.Controls.Add(this.ultraLabel1);
			this.Controls.Add(this._PostNoSelectWindow_Toolbars_Dock_Area_Left);
			this.Controls.Add(this._PostNoSelectWindow_Toolbars_Dock_Area_Right);
			this.Controls.Add(this._PostNoSelectWindow_Toolbars_Dock_Area_Top);
			this.Controls.Add(this._PostNoSelectWindow_Toolbars_Dock_Area_Bottom);
			this.Controls.Add(this.ultraStatusBar1);
			this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PostNoSelectWindow";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "�����X�֔ԍ��I��";
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		/// <summary>
		/// �O���b�h�̗񂪃A�N�e�B�u�ɂȂ����Ƃ��̏���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraGrid1_AfterRowActivate(object sender, System.EventArgs e)
		{
			if( ultraGrid1.ActiveRow == null )
			{
				return;
			}
			
			ultraGrid1.ActiveRow.Selected = true;
		}

        /// <summary>
        /// �w��ʒu�̃Z�����擾����
        /// �Z���ȊO��������null��Ԃ�
        /// </summary>
        /// <param name="point"></param>
        /// <param name="ugClick"></param>
        /// <returns></returns>
        private static UltraGridCell GetCell(Point point, UltraGrid ugClick)
        {
            point = ugClick.PointToClient(point);
            Infragistics.Win.UIElement objElement = null;
            Infragistics.Win.UltraWinGrid.RowCellAreaUIElement objRowCellAreaUIElement = null;
            objElement = ugClick.DisplayLayout.UIElement.ElementFromPoint(point);

            if (objElement == null)
            {
                return null;
            }
            objRowCellAreaUIElement = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
                (typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

            // �w�b�_���̏ꍇ�͈ȉ��̏������L�����Z�����܂��B
            if (objRowCellAreaUIElement == null)
            {
                return null;
            }

            UltraGridCell ugCell;

            //�N���b�N�����������񂶂�Ȃ������ꍇ
            if ((ugCell = objElement.GetContext(typeof(UltraGridCell)) as UltraGridCell) == null)
            {
                return null;
            }

            return ugCell;
        }

		/// <summary>
		/// �O���b�h���_�u���N���b�N���ꂽ�Ƃ��̏���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			//�w�b�_�Ȃǂ��N���b�N����Ă�����߂�
            if (GetCell(Cursor.Position, this.ultraGrid1) == null)
			{
				return;
			}
			this.PerformOkClick();
		}
		
		/// <summary>
		/// �c�[���o�[�̃{�^���������ꂽ�Ƃ��̏���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			if( e.Tool.CaptionResolved == "�I��(&S)" )
			{
				this.PerformOkClick();
			}
			else if( e.Tool.CaptionResolved == "�߂�(&C)" )
			{
				this.PerformCancelClick();
			}
			
		}
		
		/// <summary>
		/// ����
		/// </summary>
		private AddressData adResult = null;
		
		/// <summary>
		/// ���ʂ��擾����
		/// </summary>
		/// <returns></returns>
		public AddressData GetResult()
		{
			return this.adResult;
		}
		
		/// <summary>
		/// �I���������ꂽ�Ƃ��̏���
		/// </summary>
		private void PerformOkClick()
		{
			//�A�N�e�B�u�ȗ񂪖����Ȃ�L�����Z���������ꂽ���Ƃɂ���
			if( this.ultraGrid1.ActiveRow == null )
			{
				this.PerformCancelClick();
				return;
			}
			
			this.adResult = this.ultraGrid1.ActiveRow.Cells["�f�[�^"].Value as AddressData;
			
			if( this.adResult == null )
			{
				this.PerformCancelClick();
				return;
			}
			
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		
		/// <summary>
		/// �L�����Z���������ꂽ�Ƃ��̏���
		/// </summary>
		private void PerformCancelClick()
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		
		/// <summary>
		/// �O���b�h�ŃL�[�������ꂽ�Ƃ��̏���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraGrid1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if( e.KeyCode == Keys.Enter )
			{
                this.PerformOkClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.PerformCancelClick();
            }
		}
		
		/// <summary>
		/// �O���b�h�̃T�C�Y���ύX���ꂽ�Ƃ��̃C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraGrid1_Resize(object sender, System.EventArgs e)
		{
			this.PerformAutoFitResultColumns();
		}
		
		/// <summary>
		/// �O���b�h�̗񎩓��T�C�Y
		/// </summary>
		private void PerformAutoFitResultColumns()
		{
			int dwScrollBarWidth = 20;
			
			int dwColumnPostNoWidth = 120;
			
			this.ultraGrid1.DisplayLayout.Bands[0].Columns["�X�֔ԍ�"].Width = dwColumnPostNoWidth;
			
			this.ultraGrid1.DisplayLayout.Bands[0].Columns["�Z������"].Width = this.ultraGrid1.Width;
						
			if( this.ultraGrid1.Width > this.ultraGrid1.DisplayLayout.Bands[0].RowSelectorWidthResolved + dwScrollBarWidth + dwColumnPostNoWidth )
			{
				this.ultraGrid1.DisplayLayout.Bands[0].Columns["�Z������"].Width -= ( this.ultraGrid1.DisplayLayout.Bands[0].RowSelectorWidthResolved + dwScrollBarWidth + dwColumnPostNoWidth );
			}
			
		}

	}
}
