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
	/// �L�[���[�h�����_�C�A���O�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011�@����@���N</br>
	/// <br>Date       : 2005.05.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	internal class KeyWordSearchWindow : System.Windows.Forms.Form
	{
		#region �R���|�[�l���g
		
		private System.ComponentModel.IContainer components = null;
		private Broadleaf.Library.Windows.Forms.TEdit teKeyword;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _KeyWordSearchWindow_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _KeyWordSearchWindow_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _KeyWordSearchWindow_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _KeyWordSearchWindow_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.UltraWinGrid.UltraGrid ugResult;
		private System.Windows.Forms.Panel panel1;
		
		#endregion
		
		private MergedAddressAcs addressAcs = null;
		
		private DataTable dtResult;
        private TComboEditor areaGroupTComboEditor;

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
		
		#endregion
		
		#region �L�[���[�h���`���\�b�h
		
		/// <summary>
		/// �q����ꉹ�H�ɕϊ����郁�\�b�h
		/// </summary>
		/// <param name="strTarget"></param>
		/// <returns></returns>
		private string replaceConsonant( string strTarget )
		{
			string strResult = (string)strTarget.Clone();

			char[] cTable = {'�@','�B','�D','�F','�H','��','��','��','�b'};
			char[] mTable = {'�A', '�C', '�E', '�G', '�I', '��', '��', '��', '�c' };
			
			for( int i = 0 ; i < cTable.Length ; i++ )
			{
				strResult = strResult.Replace( cTable[i], mTable[i] );
			}
			return strResult;
		}
		
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
				if( Char.IsSymbol( strResult[i] ) 
					|| Char.IsPunctuation( strResult[i] )
					|| Char.IsSeparator( strResult[i] )
					|| Char.IsSurrogate( strResult[i] ) )
				{
					strResult = strResult.Remove( i, 1 );
					i--;
				}
			}
			return strResult;
		}
		
		#endregion
		
		public KeyWordSearchWindow(MergedAddressAcs addressAcs, string keyword, int areaGroupCode )
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();
			
			this.addressAcs = addressAcs;
			
			//�L�[���[�h�𕶎��񌟍����ɃZ�b�g
			this.teKeyword.Text = keyword;
			
			this.setToolbarAppearance();
			
			dtResult = new DataTable();
			
			dtResult.Columns.Add( "�X�֔ԍ�", typeof( string ) );
			dtResult.Columns.Add( "�Z��", typeof( string ) );
			dtResult.Columns.Add( "�f�[�^", typeof( AddressData ) );
			ugResult.DataSource = dtResult;
			ugResult.DataBind();
			
			this.setGridAppearance( ugResult );
			this.setGridBehavior( ugResult );
			this.setTEditAppearance( this.teKeyword );
			
			//this.ugResult.DisplayLayout.AutoFitColumns = true;
            ugResult.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            this.ugResult.DisplayLayout.Bands[0].Columns["�f�[�^"].Hidden = true;

			this.PerformAutoFitResultColumns();

            this.areaGroupTComboEditor.ValueChanged -= new EventHandler(this.areaGroupTComboEditor_ValueChanged);

            #region �ǋ�R���{�̃f�[�^�ݒ�

            //�L�[���[�h�����i��p�ǋ��ݒ�
            List<AreaGroup> areaGroupList = null;
            AddressInfoAreaGroupCacheAcs.GetAreaGroup(out areaGroupList);

            //���ɑS�������Ă���
            this.areaGroupTComboEditor.Items.Add(0, "�S��");

            for (int i = 0; i < areaGroupList.Count; i++)
            {
                this.areaGroupTComboEditor.Items.Add(areaGroupList[i].AreaGroupCode, areaGroupList[i].AreaName);
            }

            //�擪�̑S����I��
            // TODO : �����ǋ��I����Ԃɂ���悤�ɕύX����
            if (this.areaGroupTComboEditor.Items.Count > 0)
            {
                this.areaGroupTComboEditor.SelectedIndex = 0;
            }

            //�\���ǋ��I��
            for (int i = 0; i < this.areaGroupTComboEditor.Items.Count; i++)
            {
                if ((int)this.areaGroupTComboEditor.Items[i].DataValue == areaGroupCode)
                {
                    this.areaGroupTComboEditor.SelectedIndex = i;
                }
            }

            #endregion

            this.areaGroupTComboEditor.ValueChanged += new EventHandler(this.areaGroupTComboEditor_ValueChanged);
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
					
					dr["�Z��"] = aw.AddressName;
					dr["�X�֔ԍ�"] = aw.PostNo;
					dr["�f�[�^"] = aw;

					dtResult.Rows.Add( dr );
				}
			}

            this.dtResult.DefaultView.Sort = "�X�֔ԍ�";

            this.ultraStatusBar1.Text = "�Y������ " + alTarget.Count + " ��";
		}
		
		/// <summary>
		/// �L�[���[�h�Ō�������
		/// </summary>
		private void SearchKeywordMatchAddress()
		{
			//�����������폜
			string strKeyword = this.removeInvalidCharacter( this.teKeyword.Text );
			
			//�����L�[���[�h���w�肳��Ă��Ȃ��ꍇ
			if( strKeyword == "" )
			{
				return;
			}

            List<AddressData> alResult = null;
			
			this.addressAcs.GetAddrFromName( (int)this.areaGroupTComboEditor.Items[ this.areaGroupTComboEditor.SelectedIndex].DataValue, strKeyword, out alResult );
			
			this.SetAddressWorkToGrid( alResult );
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
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("�m��(S)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("������(X)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("�m��(S)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("������(X)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("�O�̌���(P)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("���̌���(N)");
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyWordSearchWindow));
			this.teKeyword = new Broadleaf.Library.Windows.Forms.TEdit();
			this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
			this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
			this.ugResult = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.panel1 = new System.Windows.Forms.Panel();
			this.areaGroupTComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			((System.ComponentModel.ISupportInitialize)(this.teKeyword)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ugResult)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.areaGroupTComboEditor)).BeginInit();
			this.SuspendLayout();
			// 
			// teKeyword
			// 
			this.teKeyword.ActiveAppearance = appearance1;
			appearance2.FontData.SizeInPoints = 14F;
			this.teKeyword.Appearance = appearance2;
			this.teKeyword.AutoSelect = true;
			this.teKeyword.DataText = "";
			this.teKeyword.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.teKeyword.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 75, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.teKeyword.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.teKeyword.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.teKeyword.Location = new System.Drawing.Point(161, 12);
			this.teKeyword.MaxLength = 75;
			this.teKeyword.Name = "teKeyword";
			this.teKeyword.Size = new System.Drawing.Size(317, 28);
			this.teKeyword.TabIndex = 2;
			this.teKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyWordSearchWindow_KeyDown);
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
			// _KeyWordSearchWindow_Toolbars_Dock_Area_Left
			// 
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 25);
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Left.Name = "_KeyWordSearchWindow_Toolbars_Dock_Area_Left";
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 362);
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _KeyWordSearchWindow_Toolbars_Dock_Area_Right
			// 
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(742, 25);
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Right.Name = "_KeyWordSearchWindow_Toolbars_Dock_Area_Right";
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 362);
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _KeyWordSearchWindow_Toolbars_Dock_Area_Top
			// 
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Top.Name = "_KeyWordSearchWindow_Toolbars_Dock_Area_Top";
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(742, 25);
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _KeyWordSearchWindow_Toolbars_Dock_Area_Bottom
			// 
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 387);
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Bottom.Name = "_KeyWordSearchWindow_Toolbars_Dock_Area_Bottom";
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(742, 0);
			this._KeyWordSearchWindow_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// ultraLabel1
			// 
			appearance5.BackColor = System.Drawing.Color.Black;
			appearance5.BackColor2 = System.Drawing.Color.Black;
			appearance5.BorderColor = System.Drawing.Color.Blue;
			appearance5.BorderColor3DBase = System.Drawing.Color.Blue;
			appearance5.FontData.SizeInPoints = 11F;
			appearance5.ForeColor = System.Drawing.Color.Lime;
			appearance5.ForeColorDisabled = System.Drawing.Color.Lime;
			appearance5.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance5.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ultraLabel1.Appearance = appearance5;
			this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
			this.ultraLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
			this.ultraLabel1.Location = new System.Drawing.Point(18, 11);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(142, 29);
			this.ultraLabel1.TabIndex = 0;
			this.ultraLabel1.Text = "�L�[���[�h";
			// 
			// ultraStatusBar1
			// 
			this.ultraStatusBar1.Location = new System.Drawing.Point(0, 387);
			this.ultraStatusBar1.Name = "ultraStatusBar1";
			this.ultraStatusBar1.Size = new System.Drawing.Size(742, 23);
			this.ultraStatusBar1.TabIndex = 3;
			this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
			// 
			// ugResult
			// 
			this.ugResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ugResult.Location = new System.Drawing.Point(0, 76);
			this.ugResult.Name = "ugResult";
			this.ugResult.Size = new System.Drawing.Size(742, 311);
			this.ugResult.TabIndex = 1;
			this.ugResult.DoubleClick += new System.EventHandler(this.ugResult_DoubleClick);
			this.ugResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyWordSearchWindow_KeyDown);
			this.ugResult.AfterRowActivate += new System.EventHandler(this.ugResult_AfterRowActivate);
			this.ugResult.Resize += new System.EventHandler(this.ugResult_Resize);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.areaGroupTComboEditor);
			this.panel1.Controls.Add(this.teKeyword);
			this.panel1.Controls.Add(this.ultraLabel1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 25);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(742, 51);
			this.panel1.TabIndex = 12;
			// 
			// areaGroupTComboEditor
			// 
			this.areaGroupTComboEditor.ActiveAppearance = appearance3;
			appearance4.FontData.SizeInPoints = 14.25F;
			this.areaGroupTComboEditor.Appearance = appearance4;
			this.areaGroupTComboEditor.AutoSize = false;
			this.areaGroupTComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.areaGroupTComboEditor.Location = new System.Drawing.Point(480, 12);
			this.areaGroupTComboEditor.Name = "areaGroupTComboEditor";
			this.areaGroupTComboEditor.Size = new System.Drawing.Size(126, 28);
			this.areaGroupTComboEditor.TabIndex = 35;
			this.areaGroupTComboEditor.ValueChanged += new System.EventHandler(this.areaGroupTComboEditor_ValueChanged);
			// 
			// KeyWordSearchWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(742, 410);
			this.Controls.Add(this.ugResult);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this._KeyWordSearchWindow_Toolbars_Dock_Area_Left);
			this.Controls.Add(this._KeyWordSearchWindow_Toolbars_Dock_Area_Right);
			this.Controls.Add(this._KeyWordSearchWindow_Toolbars_Dock_Area_Top);
			this.Controls.Add(this._KeyWordSearchWindow_Toolbars_Dock_Area_Bottom);
			this.Controls.Add(this.ultraStatusBar1);
			this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "KeyWordSearchWindow";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "�Z���L�[���[�h����";
			this.Shown += new System.EventHandler(this.KeyWordSearchWindow_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyWordSearchWindow_KeyDown);
			this.Load += new System.EventHandler(this.KeyWordSearchWindow_Load);
			((System.ComponentModel.ISupportInitialize)(this.teKeyword)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ugResult)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.areaGroupTComboEditor)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region �m��A�L�����Z������
		
		private AddressData addressWorkResult = null;
		
		public AddressData GetResult()
		{
			return this.addressWorkResult;
		}

		private void PerformOkClick()
		{
			if( this.ugResult.ActiveRow != null ){
				this.addressWorkResult = this.ugResult.ActiveRow.Cells["�f�[�^"].Value as AddressData;
			}
			
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		
		private void PerformCancelClick()
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		
		#endregion
		
		/// <summary>
		/// �t�H�[�J�X���ύX���ꂽ�Ƃ��̏���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			TEdit te;
			UltraGrid ug;
			
			//�G���^�[�L�[�ȊO�ŌĂ΂ꂽ�Ƃ��͉������Ȃ�
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
			}
				//�A�C�e�����I������Ă���Ƃ��Ƀ��X�g�{�b�N�X�Ƀt�H�[�J�X��������
				//�G���^�[�������ꂽ��m��{�^�������������Ƃɂ���
			else if( (ug = e.PrevCtrl as UltraGrid) != null )
			{
				this.PerformOkClick();
			}
			
		}

        /// <summary>
        /// �L�[���[�h�������J�n����
        /// </summary>
        /// <returns>���邩�ǂ���</returns>
        private bool KeywordSearch()
        {
            this.WaitWindowShow();

            try
            {
                this.SearchKeywordMatchAddress();

                //�ꌏ�����Y�����Ȃ��ꍇ��OK�����������Ƃɂ���
                if (this.dtResult.Rows.Count == 1)
                {
                    this.ugResult.Rows[0].Activate();
                    PerformOkClick();
                    return true;
                }
            }
            finally
            {
                //���҂����������������
                this.WaitWindowClose();
            }

            return false;
        }

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
		
		/// <summary>
		/// ShowDialog()���ꂽ�Ƃ��̏���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void KeyWordSearchWindow_Load(object sender, System.EventArgs e)
		{
            //�Ís��Shown�Ɉړ�
            //if (this.KeywordSearch())
            //{
            //    return;
            //}
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

		//UltraGrid���_�u���N���b�N���ꂽ�Ƃ��̏���
		private void ugResult_DoubleClick(object sender, System.EventArgs e)
		{
            if (GetCell(Cursor.Position, this.ugResult) == null)
            {
                return;
            }

			//�m�肪�����ꂽ���Ƃɂ���
			this.PerformOkClick();
		}
		
		/// <summary>
		/// �񂪃A�N�e�B�u�ɂȂ����Ƃ��̏���
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
		
		#endregion

				
		#region ���҂����������E�C���h�E���\�b�h

        private SFCMN00299CA waitWindow = null;
		
		/// <summary>
		/// ���҂������������\���֐�
		/// </summary>
		private void WaitWindowShow()
		{
			//���������ꍇ
			if( this.waitWindow == null )
			{
                this.waitWindow = new SFCMN00299CA();
                this.waitWindow.DispCancelButton = false;
                this.waitWindow.Message = "�Z�������擾���Ă��܂��B";
                this.waitWindow.Title = "�Z�����擾";
			}
			
			waitWindow.Show( this );
		}
		
		/// <summary>
		/// ���҂���������������֐�
		/// </summary>
		private void WaitWindowClose()
		{
			if( this.waitWindow != null )
			{
				this.waitWindow.Close();
				this.waitWindow = null;
			}
		}
		
		#endregion
		
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
		
		/// <summary>
		/// �O���b�h�̕����ύX���ꂽ�Ƃ��̃C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ugResult_Resize(object sender, System.EventArgs e)
		{
			this.PerformAutoFitResultColumns();
		}

        private void KeyWordSearchWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.PerformCancelClick();
            }
        }

        private void areaGroupTComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.KeywordSearch())
            {
                return;
            }
        }

        private void KeyWordSearchWindow_Shown(object sender, EventArgs e)
        {
            if (this.KeywordSearch())
            {
                return;
            }
        }
		
	}
}
