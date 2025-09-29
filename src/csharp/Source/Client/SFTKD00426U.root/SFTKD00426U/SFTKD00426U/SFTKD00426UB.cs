using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using System.Data;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Windows.Forms;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �ǋ�I���_�C�A���O�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011�@����@���N</br>
	/// <br>Date       : 2005.05.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	internal class AreaGroupWindow : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _AreaGroupWindow_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _AreaGroupWindow_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _AreaGroupWindow_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _AreaGroupWindow_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.UltraWinGrid.UltraGrid ugAreaGroup;
		
		//�A�N�Z�X�N���X
		private DataTable dtAreaGroup;
		
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
		
		void setTEditAppearance( TEdit teTarget )
		{
			//�I�����ꂽ�Ƃ��̔w�i�F��ς���
			teTarget.ActiveAppearance.BackColor = Color.FromArgb( 247, 227, 156 );
			teTarget.ActiveAppearance.BackColor2 = Color.FromArgb( 247, 227, 156 );
		}
		
		void setTComboEditorAppearance( TComboEditor tceTarget )
		{
			//�I�����ꂽ�Ƃ��̔w�i�F��ς���
			tceTarget.ActiveAppearance.BackColor = Color.FromArgb( 247, 227, 156 );
			tceTarget.ActiveAppearance.BackColor2 = Color.FromArgb( 247, 227, 156 );
		}

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
		
		//���̃N���X���C���X�^���X�ɂ��邽�߂ɕK�v�ȏ��̓A�N�Z�X�N���X�ƑI���ʒu(�n��O���[�v�R�[�h)
		
		/// <summary>
		/// �n��O���[�v�R�[�h��n���Ċǋ�K�C�h���J��
		/// </summary>
		/// <param name="areaGroupCodeDef"></param>
		public AreaGroupWindow( int areaGroupCodeDef )
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();
			
			this.setToolbarAppearance();
			
			//Grid�ݒ�
			dtAreaGroup = new DataTable();
			
			//���ڐݒ�
			dtAreaGroup.Columns.Add( "�ǋ於��", typeof( System.String ) );
			dtAreaGroup.Columns.Add( "�f�[�^", typeof( AreaGroup ) );
			
			ugAreaGroup.DataSource = dtAreaGroup;
			
			ugAreaGroup.DataBind();
			
			this.setGridAppearance( this.ugAreaGroup );
			this.setGridBehavior( this.ugAreaGroup );
			
			//���\��
			ugAreaGroup.DisplayLayout.Bands[0].Columns["�f�[�^"].Hidden = true;
			
			ugAreaGroup.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			//ugAreaGroup.DisplayLayout.AutoFitColumns = true;
            ugAreaGroup.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

			//-----------���ǂݍ���---------------
			
			List<AreaGroup> alTmp;
			
			//�A�N�Z�X�N���X����ǋ�ꗗ���擾
			if( AddressInfoAreaGroupCacheAcs.GetAreaGroup( out alTmp ) != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				return;
			}
			
			//�ǋ�I���_�C�A���O�̎w��ʒu��I������
			for( int i = 0 ; i < alTmp.Count ; i++ )
			{
				AreaGroup ag = alTmp[i];
				
				//�O���b�h�ɗ�ǉ�
				DataRow dr = dtAreaGroup.NewRow();
				dr["�ǋ於��"] = ag.AreaName;
				dr["�f�[�^"] = ag;
				dtAreaGroup.Rows.Add( dr );
				
			}
			
			//�w��̊ǋ���A�N�e�B�u�ɂ���
			for( int i = 0 ; i < this.ugAreaGroup.Rows.Count ; i++ )
			{
				//�w��ʒu�̃O���b�h��������I������
				if( ((AreaGroup)ugAreaGroup.Rows[i].Cells["�f�[�^"].Value).AreaGroupCode == areaGroupCodeDef )
				{
					ugAreaGroup.Rows[i].Activate();
					break;
				}
			}
			
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
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ok");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("cancel");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ok");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("cancel");
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AreaGroupWindow));
			this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
			this._AreaGroupWindow_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._AreaGroupWindow_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._AreaGroupWindow_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._AreaGroupWindow_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
			this.ugAreaGroup = new Infragistics.Win.UltraWinGrid.UltraGrid();
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ugAreaGroup)).BeginInit();
			this.SuspendLayout();
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
			buttonTool3.SharedProps.Caption = "�m��(&S)";
			buttonTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool4.SharedProps.Caption = "�߂�(&C)";
			buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool4});
			this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
			// 
			// _AreaGroupWindow_Toolbars_Dock_Area_Left
			// 
			this._AreaGroupWindow_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._AreaGroupWindow_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._AreaGroupWindow_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
			this._AreaGroupWindow_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
			this._AreaGroupWindow_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 27);
			this._AreaGroupWindow_Toolbars_Dock_Area_Left.Name = "_AreaGroupWindow_Toolbars_Dock_Area_Left";
			this._AreaGroupWindow_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 300);
			this._AreaGroupWindow_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _AreaGroupWindow_Toolbars_Dock_Area_Right
			// 
			this._AreaGroupWindow_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._AreaGroupWindow_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._AreaGroupWindow_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
			this._AreaGroupWindow_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
			this._AreaGroupWindow_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(289, 27);
			this._AreaGroupWindow_Toolbars_Dock_Area_Right.Name = "_AreaGroupWindow_Toolbars_Dock_Area_Right";
			this._AreaGroupWindow_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 300);
			this._AreaGroupWindow_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _AreaGroupWindow_Toolbars_Dock_Area_Top
			// 
			this._AreaGroupWindow_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._AreaGroupWindow_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._AreaGroupWindow_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
			this._AreaGroupWindow_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
			this._AreaGroupWindow_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
			this._AreaGroupWindow_Toolbars_Dock_Area_Top.Name = "_AreaGroupWindow_Toolbars_Dock_Area_Top";
			this._AreaGroupWindow_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(289, 27);
			this._AreaGroupWindow_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _AreaGroupWindow_Toolbars_Dock_Area_Bottom
			// 
			this._AreaGroupWindow_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._AreaGroupWindow_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._AreaGroupWindow_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
			this._AreaGroupWindow_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
			this._AreaGroupWindow_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 327);
			this._AreaGroupWindow_Toolbars_Dock_Area_Bottom.Name = "_AreaGroupWindow_Toolbars_Dock_Area_Bottom";
			this._AreaGroupWindow_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(289, 0);
			this._AreaGroupWindow_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// ultraLabel1
			// 
			appearance1.BackColor = System.Drawing.Color.Black;
			appearance1.BorderColor = System.Drawing.Color.Blue;
			appearance1.BorderColor3DBase = System.Drawing.Color.Blue;
			appearance1.FontData.SizeInPoints = 11F;
			appearance1.ForeColor = System.Drawing.Color.Lime;
			appearance1.ForeColorDisabled = System.Drawing.Color.Lime;
			appearance1.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ultraLabel1.Appearance = appearance1;
			this.ultraLabel1.BackColor = System.Drawing.Color.Black;
			this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
			this.ultraLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
			this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ultraLabel1.Location = new System.Drawing.Point(0, 27);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(289, 32);
			this.ultraLabel1.TabIndex = 5;
			this.ultraLabel1.Text = "�ǋ��I�����Ă�������";
			// 
			// ultraStatusBar1
			// 
			this.ultraStatusBar1.Location = new System.Drawing.Point(0, 327);
			this.ultraStatusBar1.Name = "ultraStatusBar1";
			this.ultraStatusBar1.Size = new System.Drawing.Size(289, 23);
			this.ultraStatusBar1.TabIndex = 6;
			this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
			// 
			// ugAreaGroup
			// 
			this.ugAreaGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ugAreaGroup.Location = new System.Drawing.Point(0, 59);
			this.ugAreaGroup.Name = "ugAreaGroup";
			this.ugAreaGroup.Size = new System.Drawing.Size(289, 268);
			this.ugAreaGroup.TabIndex = 10;
			this.ugAreaGroup.DoubleClick += new System.EventHandler(this.ugAreaGroup_DoubleClick);
			this.ugAreaGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ugAreaGroup_KeyDown);
			this.ugAreaGroup.AfterRowActivate += new System.EventHandler(this.ugAreaGroup_AfterRowActivate);
			// 
			// AreaGroupWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(289, 350);
			this.Controls.Add(this.ugAreaGroup);
			this.Controls.Add(this.ultraLabel1);
			this.Controls.Add(this._AreaGroupWindow_Toolbars_Dock_Area_Left);
			this.Controls.Add(this._AreaGroupWindow_Toolbars_Dock_Area_Right);
			this.Controls.Add(this._AreaGroupWindow_Toolbars_Dock_Area_Top);
			this.Controls.Add(this._AreaGroupWindow_Toolbars_Dock_Area_Bottom);
			this.Controls.Add(this.ultraStatusBar1);
			this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AreaGroupWindow";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "�ǋ�ύX";
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ugAreaGroup)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		#region �m��A�L�����Z������
		
		private AreaGroup agSelected = null;
		
		/// <summary>
		/// ���ʂ��擾����
		/// </summary>
		/// <returns></returns>
		public AreaGroup GetResult()
		{
			return this.agSelected;
		}
		
		//OK�{�^�������������Ƃɂ���
		private void PerformOKClick()
		{
			//�I���ʒu�̃A�C�e����ۑ�
			if( this.ugAreaGroup.ActiveRow != null )
			{
				this.agSelected = this.ugAreaGroup.ActiveRow.Cells["�f�[�^"].Value as AreaGroup;
			}
			
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		
		//Cancel�{�^�������������Ƃɂ���
		private void PerformCancelClick()
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		
		#endregion
		
		private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch( e.Tool.CaptionResolved )
			{
				case "�m��(&S)":
					this.PerformOKClick();
					break;
					
				case "�߂�(&C)":
					this.PerformCancelClick();
					break;
					
				default:
					break;
			}

		}
		
		#region �O���b�h�̃C�x���g
		
		private void ugAreaGroup_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//Enter�������ꂽ�ꍇ
			if( e.KeyCode == Keys.Enter )
			{
                this.PerformOKClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.PerformCancelClick();
            }
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

		private void ugAreaGroup_DoubleClick(object sender, System.EventArgs e)
		{
            if (GetCell(Cursor.Position, ugAreaGroup) == null)
            {
                return;
            }
			
			this.PerformOKClick();
		}
		
		private void ugAreaGroup_AfterRowActivate(object sender, System.EventArgs e)
		{
			if( this.ugAreaGroup.ActiveRow == null )
			{
				return;
			}
			this.ugAreaGroup.ActiveRow.Selected = true;
		}
		
		#endregion
		
	}
}
