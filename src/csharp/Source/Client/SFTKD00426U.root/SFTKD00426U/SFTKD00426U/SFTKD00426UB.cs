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
	/// 管区選択ダイアログクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011　野口　暢朗</br>
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
		
		//アクセスクラス
		private DataTable dtAreaGroup;
		
		#region UIの外観設定メソッド
		
		/// <summary>
		/// UltraGridの配色を仕様通りに設定する
		/// </summary>
		/// <param name="ugTarget"></param>
		private void setGridAppearance( Infragistics.Win.UltraWinGrid.UltraGrid ugTarget )
		{
			//タイトルの外観
			ugTarget.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
			ugTarget.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			ugTarget.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			ugTarget.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			ugTarget.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;

			//背景色を設定
			ugTarget.DisplayLayout.Appearance.BackColor = Color.White;
			
			//文字をカラムに入るように設定する
			//ugTarget.DisplayLayout.AutoFitColumns = true;
            ugTarget.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

			// 選択行の外観を設定
			ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
			ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
			ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

			//行セレクタの設定
			ugTarget.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
			ugTarget.DisplayLayout.Override.RowSelectorAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
			ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			ugTarget.DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.White;

			ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			
			//行のサイズ変更不可
			ugTarget.DisplayLayout.Override.RowSizing = RowSizing.Fixed;
			
			//インジゲータ非表示
			ugTarget.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			
			//分割領域非表示
			ugTarget.DisplayLayout.MaxColScrollRegions = 1;
			ugTarget.DisplayLayout.MaxRowScrollRegions = 1;
						
			//交互に行の色を変える
			ugTarget.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
			
			//グリッドの背景色を変える
			ugTarget.DisplayLayout.Appearance.BackColor = Color.Gray;
			
			//垂直スクロールバーのみ許可
			ugTarget.DisplayLayout.Scrollbars = Scrollbars.Automatic;
			
			//アクティブ行のフォントの色を変える
			ugTarget.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
			
			//アクティブ行のフォントを太字にする
			ugTarget.DisplayLayout.Override.ActiveRowAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			
		}
		
		/// <summary>
		/// UltraGridの挙動を設定する
		/// </summary>
		/// <param name="ugTarget"></param>
		private void setGridBehavior( Infragistics.Win.UltraWinGrid.UltraGrid ugTarget )
		{
			//列幅の自動調整不可
			//ugTarget.DisplayLayout.AutoFitColumns = false;
            ugTarget.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

			//行の追加不可
			ugTarget.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			
			//行の削除不可
			ugTarget.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			
			// 列の移動不可
			ugTarget.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
			
			// 列の交換不可
			ugTarget.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
			
			// フィルタの使用不可
			ugTarget.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
			
			// ユーザーのデータ書き換え許可
			ugTarget.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
			
			//選択方法を行選択に設定。
			ugTarget.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			
			//ヘッダをクリックしたときは列選択状態にする。
			ugTarget.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
			//+列選択不可にすることでヘッダをクリックしても何も起こらない
			ugTarget.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;

			//一行のみ選択可能にする
			ugTarget.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
			
			//スクロール中にもいまどこが見えている状態なのかがわかるようにする
			ugTarget.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;

            ugTarget.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;

			//IME無効
			ugTarget.ImeMode = ImeMode.Disable;			
		}
		
		void setTEditAppearance( TEdit teTarget )
		{
			//選択されたときの背景色を変える
			teTarget.ActiveAppearance.BackColor = Color.FromArgb( 247, 227, 156 );
			teTarget.ActiveAppearance.BackColor2 = Color.FromArgb( 247, 227, 156 );
		}
		
		void setTComboEditorAppearance( TComboEditor tceTarget )
		{
			//選択されたときの背景色を変える
			tceTarget.ActiveAppearance.BackColor = Color.FromArgb( 247, 227, 156 );
			tceTarget.ActiveAppearance.BackColor2 = Color.FromArgb( 247, 227, 156 );
		}

		private void setToolbarAppearance()
		{
			//ツールバーにアイコン設定
			//using Broadleaf.Library.Resources;
			//SFCMN00008C
			ImageList imList = IconResourceManagement.ImageList16;
			this.ultraToolbarsManager1.ImageListSmall = imList;

			this.ultraToolbarsManager1.Toolbars[0].Tools[0].InstanceProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			this.ultraToolbarsManager1.Toolbars[0].Tools[1].InstanceProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;

			//ツールバーをカスタマイズ不可にする
			this.ultraToolbarsManager1.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockTop = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
		}
		
		//数値の列を設定する
		private void setNumberColumnAppearance( UltraGrid ug, string strColumn, string strFormat )
		{
			ug.DisplayLayout.Bands[0].Columns[strColumn].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			ug.DisplayLayout.Bands[0].Columns[strColumn].Format = strFormat;
		}
		
		#endregion
		
		//このクラスをインスタンスにするために必要な情報はアクセスクラスと選択位置(地区グループコード)
		
		/// <summary>
		/// 地区グループコードを渡して管区ガイドを開く
		/// </summary>
		/// <param name="areaGroupCodeDef"></param>
		public AreaGroupWindow( int areaGroupCodeDef )
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();
			
			this.setToolbarAppearance();
			
			//Grid設定
			dtAreaGroup = new DataTable();
			
			//一列目設定
			dtAreaGroup.Columns.Add( "管区名称", typeof( System.String ) );
			dtAreaGroup.Columns.Add( "データ", typeof( AreaGroup ) );
			
			ugAreaGroup.DataSource = dtAreaGroup;
			
			ugAreaGroup.DataBind();
			
			this.setGridAppearance( this.ugAreaGroup );
			this.setGridBehavior( this.ugAreaGroup );
			
			//列非表示
			ugAreaGroup.DisplayLayout.Bands[0].Columns["データ"].Hidden = true;
			
			ugAreaGroup.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			//ugAreaGroup.DisplayLayout.AutoFitColumns = true;
            ugAreaGroup.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

			//-----------情報読み込み---------------
			
			List<AreaGroup> alTmp;
			
			//アクセスクラスから管区一覧を取得
			if( AddressInfoAreaGroupCacheAcs.GetAreaGroup( out alTmp ) != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				return;
			}
			
			//管区選択ダイアログの指定位置を選択する
			for( int i = 0 ; i < alTmp.Count ; i++ )
			{
				AreaGroup ag = alTmp[i];
				
				//グリッドに列追加
				DataRow dr = dtAreaGroup.NewRow();
				dr["管区名称"] = ag.AreaName;
				dr["データ"] = ag;
				dtAreaGroup.Rows.Add( dr );
				
			}
			
			//指定の管区をアクティブにする
			for( int i = 0 ; i < this.ugAreaGroup.Rows.Count ; i++ )
			{
				//指定位置のグリッドだったら選択する
				if( ((AreaGroup)ugAreaGroup.Rows[i].Cells["データ"].Value).AreaGroupCode == areaGroupCodeDef )
				{
					ugAreaGroup.Rows[i].Activate();
					break;
				}
			}
			
		}
		
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
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

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
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
			buttonTool3.SharedProps.Caption = "確定(&S)";
			buttonTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool4.SharedProps.Caption = "戻る(&C)";
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
			this.ultraLabel1.Text = "管区を選択してください";
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
			this.Text = "管区変更";
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ugAreaGroup)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		#region 確定、キャンセル処理
		
		private AreaGroup agSelected = null;
		
		/// <summary>
		/// 結果を取得する
		/// </summary>
		/// <returns></returns>
		public AreaGroup GetResult()
		{
			return this.agSelected;
		}
		
		//OKボタンを押したことにする
		private void PerformOKClick()
		{
			//選択位置のアイテムを保存
			if( this.ugAreaGroup.ActiveRow != null )
			{
				this.agSelected = this.ugAreaGroup.ActiveRow.Cells["データ"].Value as AreaGroup;
			}
			
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		
		//Cancelボタンを押したことにする
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
				case "確定(&S)":
					this.PerformOKClick();
					break;
					
				case "戻る(&C)":
					this.PerformCancelClick();
					break;
					
				default:
					break;
			}

		}
		
		#region グリッドのイベント
		
		private void ugAreaGroup_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//Enterが押された場合
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
        /// 指定位置のセルを取得する
        /// セル以外だったらnullを返す
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

            // ヘッダ部の場合は以下の処理をキャンセルします。
            if (objRowCellAreaUIElement == null)
            {
                return null;
            }

            UltraGridCell ugCell;

            //クリックした部分が列じゃなかった場合
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
