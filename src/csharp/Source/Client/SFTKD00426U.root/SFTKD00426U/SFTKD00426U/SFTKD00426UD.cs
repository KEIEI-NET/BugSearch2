using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
//using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �X�֔ԍ�����Z����������_�C�A���O�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011�@����@���N</br>
	/// <br>Date       : 2005.05.28</br>
	/// <br></br>
	/// <br>Update Note:</br>
	/// </remarks>
	internal class PostCodeSearchWindow : System.Windows.Forms.Form
	{
		#region �R���|�[�l���g

		private System.ComponentModel.IContainer components;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PostCodeSearchWindow_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PostCodeSearchWindow_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PostCodeSearchWindow_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PostCodeSearchWindow_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.UltraWinGrid.UltraGrid ugResult;
		private Broadleaf.Library.Windows.Forms.TEdit teKeyword;
		private System.Windows.Forms.Panel panel1;
		
		#endregion
		
		private MergedAddressAcs addressAcs = null;
		private ControlScreenSkin _controlScreenSkin;
		private DataTable dtResult;
		
		#region �����擾�p�f�[�^
		
        ///// <summary>
        ///// �S���ŉ������H
        ///// </summary>
        //private int totalCount = -1;
		
        ///// <summary>
        ///// �y�[�W�擪��\��AddressData�B
        ///// �C���f�b�N�X���y�[�W�B
        ///// </summary>
        //private ArrayList alPageKey = new ArrayList();
		
        ///// <summary>
        ///// ���̃y�[�W�̃L���b�V���f�[�^�B
        ///// </summary>
        //private ArrayList alPageData = new ArrayList();
		
        ///// <summary>
        ///// ���݂̃y�[�W��AddressData
        ///// </summary>
        //private AddressData awCurrent = new AddressData();
		
		/*
		private int currentAddrConnectCd1 = 0;
		private long currentAddrConnectCd2 = 0;
		private int currentAddrConnectCd3 = 0;
		private int currentAddrConnectCd4 = 0;
		private int currentAddrConnectCd5 = 0;
		*/

		#endregion
		
		#region �L�[���[�h���`���\�b�h
		
		/// <summary>
		/// �s�K�؂ȋL���Ȃǂ��폜����
		/// </summary>
		/// <param name="strTarget"></param>
		/// <returns></returns>
		private string removeInvalidCharacter( string strTarget )
		{
			string strResult = (string)strTarget.Clone();
			
			for( int i = 0 ; i < strResult.Length ; i++ )
			{
				//�����ƃ}�C�i�X�ȊO�͍폜
				if( !Char.IsNumber( strResult[i] ) && strResult[i] != '-' )
				{
					strResult = strResult.Remove( i, 1 );
					i--;
				}
				
			}
			return strResult;
		}
		
		#endregion
		
		public PostCodeSearchWindow( string keyword, MergedAddressAcs addressAcs )
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();
			
			this.addressAcs = addressAcs;
			this.teKeyword.Text = keyword;
			
			this.setToolbarAppearance();
			
			dtResult = new DataTable();
			
			dtResult.Columns.Add( "�X�֔ԍ�", typeof( string ) );
			dtResult.Columns.Add( "�Z��", typeof( string ) );
			dtResult.Columns.Add( "�f�[�^", typeof( object ) );
			
			ugResult.DataSource = dtResult;
			ugResult.DataBind();
			
			this.setGridAppearance( ugResult );
			this.setGridBehavior( ugResult );
			this.setTEditAppearance( this.teKeyword );
						
			//�񕝂�������������悤�ɐݒ�
			//this.ugResult.DisplayLayout.AutoFitColumns = true;
            this.ugResult.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

			this.ugResult.DisplayLayout.Bands[0].Columns["�f�[�^"].Hidden = true;
			
			this.PerformAutoFitResultColumns();
			this._controlScreenSkin = new ControlScreenSkin();
		}
		
		#region �������\�b�h
		
		private class AddressDataComparer : IComparer
		{

			#region IComparer �����o

			public int Compare(object x, object y)
			{
				AddressData ax = x as AddressData;
				AddressData ay = y as AddressData;
				
				if( ax.AddrConnectCd1 > ay.AddrConnectCd1 )
				{
					return 1;
				}
				else if( ax.AddrConnectCd1 < ay.AddrConnectCd1 )
				{
					return -1;
				}
				
				if( ax.AddrConnectCd2 > ay.AddrConnectCd2 )
				{
					return 1;
				}
				else if( ax.AddrConnectCd2 < ay.AddrConnectCd2 )
				{
					return -1;
				}
				
				if( ax.AddrConnectCd3 > ay.AddrConnectCd3 )
				{
					return 1;
				}
				else if( ax.AddrConnectCd3 < ay.AddrConnectCd3 )
				{
					return -1;
				}
				
				if( ax.AddrConnectCd4 > ay.AddrConnectCd4 )
				{
					return 1;
				}
				else if( ax.AddrConnectCd4 < ay.AddrConnectCd4 )
				{
					return -1;
				}
				
				if( ax.AddrConnectCd5 > ay.AddrConnectCd5 )
				{
					return 1;
				}
				else if( ax.AddrConnectCd5 < ay.AddrConnectCd5 )
				{
					return -1;
				}
				
				return 0;
			}

			#endregion

		}
		
		/// <summary>
		/// �f�[�^���O���b�h�ɕ\������
		/// </summary>
		private void SetAddressWorkToGrid( List<AddressData> alTarget )
		{
			//�e�[�u���̒��g���N���A����
			this.dtResult.Clear();
			
			//�Y��������Ȃ�\������
			if( alTarget != null && alTarget.Count > 0 )
			{
				foreach( AddressData aw in alTarget )
				{
					DataRow dr = dtResult.NewRow();
					dr["�X�֔ԍ�"] = aw.PostNo;
					dr["�Z��"] = aw.AddressName;
					dr["�f�[�^"] = aw;
					dtResult.Rows.Add( dr );
				}
			}

            this.dtResult.DefaultView.Sort = "�X�֔ԍ�";

            //this.ultraStatusBar1.Text = "�Y������ " + alTarget.Count + " ��";
            this.ultraStatusBar1.Panels[0].Text = "�Y������ " + alTarget.Count + " ��";
		}
		
		/// <summary>
		/// �L�[���[�h�Ō�������B
		/// </summary>
		private int SearchPostCodeMatchAddress()
		{
			//�����������폜
			string strKeyword = this.removeInvalidCharacter( this.teKeyword.Text );
			
			//�����L�[���[�h���w�肳��Ă��Ȃ��ꍇ
			if( strKeyword == "" )
			{
				return 0;
			}

            List<AddressData> alResult = null;

            this.addressAcs.GetAddressWorkFromZipCd(strKeyword, out alResult);

			this.SetAddressWorkToGrid( alResult );

            int count = 0;

            if (alResult != null)
            {
                count = alResult.Count;
            }

            return count;
		}
				
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
		
		void setTEditAppearance( TEdit teTarget )
		{
			//�I�����ꂽ�Ƃ��̔w�i�F��ς���
			teTarget.ActiveAppearance.BackColor = Color.FromArgb( 247, 227, 156 );
			teTarget.ActiveAppearance.BackColor2 = Color.FromArgb( 247, 227, 156 );
		}
		
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
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("�m��(S)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("������(X)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("�m��(S)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("������(X)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("���̌���(N)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("���̌���(P)");
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostCodeSearchWindow));
			this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
			this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.ugResult = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.teKeyword = new Broadleaf.Library.Windows.Forms.TEdit();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ugResult)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.teKeyword)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tRetKeyControl1
			// 
			this.tRetKeyControl1.OwnerForm = this;
			this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
			this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
			// 
			// ultraToolbarsManager1
			// 
			this.ultraToolbarsManager1.DesignerFlags = 1;
			this.ultraToolbarsManager1.DockWithinContainer = this;
			this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
			ultraToolbar1.DockedColumn = 0;
			ultraToolbar1.DockedRow = 0;
			ultraToolbar1.IsMainMenuBar = true;
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
			buttonTool5.SharedProps.Caption = "�O�̌���(&P)";
			buttonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool6.SharedProps.Caption = "���̌���(&N)";
			buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6});
			this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
			// 
			// _PostCodeSearchWindow_Toolbars_Dock_Area_Left
			// 
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 25);
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Left.Name = "_PostCodeSearchWindow_Toolbars_Dock_Area_Left";
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 362);
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _PostCodeSearchWindow_Toolbars_Dock_Area_Right
			// 
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(742, 25);
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Right.Name = "_PostCodeSearchWindow_Toolbars_Dock_Area_Right";
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 362);
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _PostCodeSearchWindow_Toolbars_Dock_Area_Top
			// 
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Top.Name = "_PostCodeSearchWindow_Toolbars_Dock_Area_Top";
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(742, 25);
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _PostCodeSearchWindow_Toolbars_Dock_Area_Bottom
			// 
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 387);
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Bottom.Name = "_PostCodeSearchWindow_Toolbars_Dock_Area_Bottom";
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(742, 0);
			this._PostCodeSearchWindow_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// ultraStatusBar1
			// 
			this.ultraStatusBar1.Location = new System.Drawing.Point(0, 387);
			this.ultraStatusBar1.Name = "ultraStatusBar1";
			ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
			this.ultraStatusBar1.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1});
			this.ultraStatusBar1.Size = new System.Drawing.Size(742, 23);
			this.ultraStatusBar1.TabIndex = 13;
			this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
			// 
			// ultraLabel2
			// 
			appearance3.BackColor = System.Drawing.Color.Black;
			appearance3.BackColor2 = System.Drawing.Color.Black;
			appearance3.BorderColor = System.Drawing.Color.Blue;
			appearance3.BorderColor3DBase = System.Drawing.Color.Blue;
			appearance3.FontData.SizeInPoints = 11F;
			appearance3.ForeColor = System.Drawing.Color.Lime;
			appearance3.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance3.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ultraLabel2.Appearance = appearance3;
			this.ultraLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
			this.ultraLabel2.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
			this.ultraLabel2.Location = new System.Drawing.Point(18, 11);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.Size = new System.Drawing.Size(189, 30);
			this.ultraLabel2.TabIndex = 14;
			this.ultraLabel2.Text = "�X�֔ԍ��L�[���[�h";
			// 
			// ugResult
			// 
			this.ugResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ugResult.Location = new System.Drawing.Point(0, 76);
			this.ugResult.Name = "ugResult";
			this.ugResult.Size = new System.Drawing.Size(742, 311);
			this.ugResult.TabIndex = 15;
			this.ugResult.DoubleClick += new System.EventHandler(this.ugResult_DoubleClick);
			this.ugResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PostCodeSearchWindow_KeyDown);
			this.ugResult.AfterRowActivate += new System.EventHandler(this.ugResult_AfterRowActivate);
			this.ugResult.Resize += new System.EventHandler(this.ugResult_Resize);
			// 
			// teKeyword
			// 
			this.teKeyword.ActiveAppearance = appearance1;
			appearance2.FontData.SizeInPoints = 14F;
			this.teKeyword.Appearance = appearance2;
			this.teKeyword.AutoSelect = true;
			this.teKeyword.AutoSize = false;
			this.teKeyword.DataText = "";
			this.teKeyword.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.teKeyword.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.teKeyword.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.teKeyword.Location = new System.Drawing.Point(208, 11);
			this.teKeyword.MaxLength = 8;
			this.teKeyword.Name = "teKeyword";
			this.teKeyword.Size = new System.Drawing.Size(293, 30);
			this.teKeyword.TabIndex = 20;
			this.teKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PostCodeSearchWindow_KeyDown);
			this.teKeyword.TextChanged += new System.EventHandler(this.teKeyword_TextChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.teKeyword);
			this.panel1.Controls.Add(this.ultraLabel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 25);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(742, 51);
			this.panel1.TabIndex = 25;
			// 
			// PostCodeSearchWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(742, 410);
			this.Controls.Add(this.ugResult);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this._PostCodeSearchWindow_Toolbars_Dock_Area_Left);
			this.Controls.Add(this._PostCodeSearchWindow_Toolbars_Dock_Area_Right);
			this.Controls.Add(this._PostCodeSearchWindow_Toolbars_Dock_Area_Top);
			this.Controls.Add(this._PostCodeSearchWindow_Toolbars_Dock_Area_Bottom);
			this.Controls.Add(this.ultraStatusBar1);
			this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PostCodeSearchWindow";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "�X�֔ԍ�����";
			this.Shown += new System.EventHandler(this.PostCodeSearchWindow_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PostCodeSearchWindow_KeyDown);
			this.Load += new System.EventHandler(this.PostCodeSearchWindow_Load);
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ugResult)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.teKeyword)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		#region �m��A�L�����Z������
		
		private AddressData addressWorkResult = null;
		
		/// <summary>
		/// ���ʂ��擾����
		/// </summary>
		/// <returns></returns>
		public AddressData GetResult()
		{
			return this.addressWorkResult;
		}
		
		/// <summary>
		/// �m�肪�����ꂽ�Ƃ��̏���
		/// </summary>
		private void PerformOkClick()
		{
			if( this.ugResult.ActiveRow != null )
			{
				this.addressWorkResult = this.ugResult.ActiveRow.Cells["�f�[�^"].Value as AddressData;
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
		
		#endregion
		
		//�����������̓e�L�X�g�{�b�N�X����t�H�[�J�X���͂��ꂽ�Ƃ�
		//���Ȃ킿Enter��������ăt�H�[�J�X���ς�����Ƃ�
		private void PostCodeSearchWindow_Load(object sender, System.EventArgs e)
		{
            //�s����Shown�Ɉړ�
            ////���҂������������쐬
            //this.WaitWindowShow();

            //if (this.KeywordSearch())
            //{
            //    return;
            //}
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);
		}
		
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			TEdit te;
			UltraGrid ug;
			
			//�G���^�[�L�[�ȊO�̎��͉������Ȃ�
			if( e.Key != System.Windows.Forms.Keys.Enter )
			{
				return;
			}
			
			//�L�[���[�h�p�e�L�X�g�{�b�N�X�ɉ��������Ă��Ȃ�������
			//�t�H�[�J�X���ړ����Ȃ�
			if( (te = e.PrevCtrl as TEdit) != null )
			{
                if (this.KeywordSearch())
                {
                    return;
                }

                if (this.ugResult.Rows.Count == 0 && e.NextCtrl is UltraGrid)
                {
                    e.NextCtrl = null;
                }
			}
				//�A�C�e�����I������Ă���Ƃ��Ƀ��X�g�{�b�N�X�Ƀt�H�[�J�X��������
				//�G���^�[�������ꂽ��m��{�^�������������Ƃɂ���
			else if( (ug = e.PrevCtrl as UltraGrid) != null )
			{
				PerformOkClick();
			}
		}
		
		//�c�[���o�[�̃{�^���������ꂽ�Ƃ�
		private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch( e.Tool.CaptionResolved )
			{
				case "�m��(&S)":
					this.PerformOkClick();
					break;
					
				case "�߂�(&C)":
					this.PerformCancelClick();
					break;
										
				default:
					break;
			}
			
		}
		
		#region �O���b�h�̃C�x���g

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

		//�O���b�h���_�u���N���b�N���ꂽ�Ƃ��̏���
		private void ugResult_DoubleClick(object sender, System.EventArgs e)
		{
            //�Z���ȊO���N���b�N���ꂽ��߂�
            if (GetCell(Cursor.Position, this.ugResult) == null)
            {
                return;
            }
			
			this.PerformOkClick();
		}
		
		/// <summary>
		/// �O���b�h�̗񂪃A�N�e�B�u�ɂȂ����Ƃ��̏���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ugResult_AfterRowActivate(object sender, System.EventArgs e)
		{
			if( this.ugResult.ActiveRow == null )
			{
				return;
			}
			this.ugResult.ActiveRow.Selected = true;
		}
		
		/// <summary>
		/// �O�b�h�̃T�C�Y���ύX���ꂽ�Ƃ��̏���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ugResult_Resize(object sender, System.EventArgs e)
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
			
			this.ugResult.DisplayLayout.Bands[0].Columns["�X�֔ԍ�"].Width = dwColumnPostNoWidth;
			
			this.ugResult.DisplayLayout.Bands[0].Columns["�Z��"].Width = this.ugResult.Width;
			
			if( this.ugResult.Width > this.ugResult.DisplayLayout.Bands[0].RowSelectorWidthResolved + dwScrollBarWidth + dwColumnPostNoWidth )
			{
				this.ugResult.DisplayLayout.Bands[0].Columns["�Z��"].Width -= ( this.ugResult.DisplayLayout.Bands[0].RowSelectorWidthResolved + dwScrollBarWidth + dwColumnPostNoWidth );
			}
			
		}
		
		#endregion
		
		/// <summary>
		/// �L�[���[�h�̃e�L�X�g�{�b�N�X���ύX���ꂽ�Ƃ��̏���
		/// �S�������N���A����
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void teKeyword_TextChanged(object sender, System.EventArgs e)
		{
            //this.totalCount = -1;
			
            ////�y�[�W�C���f�b�N�X���N���A����
            //this.alPageKey.Clear();
			
            ////�y�[�W�̃L���b�V�����N���A����
            //this.alPageData.Clear();
		}


        #region ���҂����������E�C���h�E���\�b�h

        private SFCMN00299CA waitWindow = null;

        /// <summary>
        /// ���҂������������\���֐�
        /// </summary>
        private void WaitWindowShow()
        {
            //���������ꍇ
            if (this.waitWindow == null)
            {
                this.waitWindow = new SFCMN00299CA();
                this.waitWindow.DispCancelButton = false;
                this.waitWindow.Message = "�Z�������擾���Ă��܂��B";
                this.waitWindow.Title = "�Z�����擾";
            }

            waitWindow.Show(this);
        }

        /// <summary>
        /// ���҂���������������֐�
        /// </summary>
        private void WaitWindowClose()
        {
            if (this.waitWindow != null)
            {
                this.waitWindow.Close();
                this.waitWindow = null;
            }
        }

        #endregion

        /// <summary>
        /// ���̓L�[���[�h�̃`�F�b�N
        /// </summary>
        /// <returns>OK���ǂ���</returns>
        private bool KeywordInputCheck()
        {
            ////�L�[���[�h�̓��̓`�F�b�N
            //if (this.teKeyword.Text.Length < 3)
            //{
            //    //�I�����Ȃ��G���[
            //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFTKD00426U", "3�����ȏ�̃L�[���[�h����͂��Ă��������B", 0, MessageBoxButtons.OK);

            //    this.teKeyword.Focus();

            //    return false;
            //}

            return true;
        }

        /// <summary>
        /// �L�[���[�h�������J�n����
        /// </summary>
        /// <returns>���邩�ǂ���</returns>
        private bool KeywordSearch()
        {
            this.dtResult.Rows.Clear();

            if (!this.KeywordInputCheck())
            {
                return false;
            }

            this.WaitWindowShow();

            try
            {
                int count = this.SearchPostCodeMatchAddress();

                //�ꌏ�����Y�����Ȃ��ꍇ��OK�����������Ƃɂ���
                if (count == 1)
                {
                    this.ugResult.Rows[0].Activate();
                    PerformOkClick();
                    return true;
                }
                else if (count > 0)
                {
                    this.ugResult.Rows[0].Activate();
                }
            }
            finally
            {
                //���҂����������������
                this.WaitWindowClose();
            }

            return false;
        }

        private void PostCodeSearchWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.PerformCancelClick();
            }
        }

        private void PostCodeSearchWindow_Shown(object sender, EventArgs e)
        {
            //if (!this.KeywordInputCheck())
            //{
            //    return;
            //}

            ////���҂������������쐬
            //this.WaitWindowShow();

            if (this.KeywordSearch())
            {
                return;
            }
        }
		
	}
}
