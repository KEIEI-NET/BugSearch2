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
	/// 複数郵便番号から一つを選択させるウィンドウクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011　野口　暢朗</br>
	/// <br>Date       : 2006.01.11</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class PostNoSelectWindow : System.Windows.Forms.Form
	{
		
		#region コンポーネント
		
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
		
//		void setTEditAppearance( TEdit teTarget )
//		{
//			//選択されたときの背景色を変える
//			teTarget.ActiveAppearance.BackColor = Color.FromArgb( 247, 227, 156 );
//			teTarget.ActiveAppearance.BackColor2 = Color.FromArgb( 247, 227, 156 );
//		}
//		
		//		void setTComboEditorAppearance( TComboEditor tceTarget )
		//		{
		//			//選択されたときの背景色を変える
		//			tceTarget.ActiveAppearance.BackColor = Color.FromArgb( 247, 227, 156 );
		//			tceTarget.ActiveAppearance.BackColor2 = Color.FromArgb( 247, 227, 156 );
		//		}
		//
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
		
		private DataTable dtDisp = null;
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="alAddressData"></param>
		public PostNoSelectWindow( ArrayList alAddressData )
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();
			
			//外観設定
			this.setToolbarAppearance();
			this.setGridAppearance( this.ultraGrid1 );
			this.setGridBehavior( this.ultraGrid1 );
			
			this.dtDisp = new DataTable();
			
			this.dtDisp.Columns.Add( "郵便番号", typeof( string ) );
			this.dtDisp.Columns.Add( "住所名称", typeof( string ) );
			this.dtDisp.Columns.Add( "データ", typeof( AddressData ) );
			
			this.ultraGrid1.DataSource = this.dtDisp;
			
			foreach( AddressData data in alAddressData )
			{
				DataRow drAdd = this.dtDisp.NewRow();
				
				drAdd["郵便番号"] = data.PostNo;
				drAdd["住所名称"] = data.AddressName;
				drAdd["データ"] = data;
				
				this.dtDisp.Rows.Add( drAdd );
			}
			
			this.ultraGrid1.DisplayLayout.Bands[0].Columns["データ"].Hidden = true;
			//this.ultraGrid1.DisplayLayout.AutoFitColumns = true;
            ultraGrid1.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

			this.PerformAutoFitResultColumns();
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
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("選択(S)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("キャンセル(X)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("選択(S)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("キャンセル(X)");
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
			buttonTool3.SharedProps.Caption = "選択(&S)";
			buttonTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool4.SharedProps.Caption = "戻る(&C)";
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
			this.ultraLabel1.Text = "郵便番号が複数存在します";
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
			this.Text = "複数郵便番号選択";
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		/// <summary>
		/// グリッドの列がアクティブになったときの処理
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

		/// <summary>
		/// グリッドがダブルクリックされたときの処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			//ヘッダなどがクリックされていたら戻る
            if (GetCell(Cursor.Position, this.ultraGrid1) == null)
			{
				return;
			}
			this.PerformOkClick();
		}
		
		/// <summary>
		/// ツールバーのボタンが押されたときの処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			if( e.Tool.CaptionResolved == "選択(&S)" )
			{
				this.PerformOkClick();
			}
			else if( e.Tool.CaptionResolved == "戻る(&C)" )
			{
				this.PerformCancelClick();
			}
			
		}
		
		/// <summary>
		/// 結果
		/// </summary>
		private AddressData adResult = null;
		
		/// <summary>
		/// 結果を取得する
		/// </summary>
		/// <returns></returns>
		public AddressData GetResult()
		{
			return this.adResult;
		}
		
		/// <summary>
		/// 選択が押されたときの処理
		/// </summary>
		private void PerformOkClick()
		{
			//アクティブな列が無いならキャンセルを押されたことにする
			if( this.ultraGrid1.ActiveRow == null )
			{
				this.PerformCancelClick();
				return;
			}
			
			this.adResult = this.ultraGrid1.ActiveRow.Cells["データ"].Value as AddressData;
			
			if( this.adResult == null )
			{
				this.PerformCancelClick();
				return;
			}
			
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		
		/// <summary>
		/// キャンセルが押されたときの処理
		/// </summary>
		private void PerformCancelClick()
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		
		/// <summary>
		/// グリッドでキーが押されたときの処理
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
		/// グリッドのサイズが変更されたときのイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraGrid1_Resize(object sender, System.EventArgs e)
		{
			this.PerformAutoFitResultColumns();
		}
		
		/// <summary>
		/// グリッドの列自動サイズ
		/// </summary>
		private void PerformAutoFitResultColumns()
		{
			int dwScrollBarWidth = 20;
			
			int dwColumnPostNoWidth = 120;
			
			this.ultraGrid1.DisplayLayout.Bands[0].Columns["郵便番号"].Width = dwColumnPostNoWidth;
			
			this.ultraGrid1.DisplayLayout.Bands[0].Columns["住所名称"].Width = this.ultraGrid1.Width;
						
			if( this.ultraGrid1.Width > this.ultraGrid1.DisplayLayout.Bands[0].RowSelectorWidthResolved + dwScrollBarWidth + dwColumnPostNoWidth )
			{
				this.ultraGrid1.DisplayLayout.Bands[0].Columns["住所名称"].Width -= ( this.ultraGrid1.DisplayLayout.Bands[0].RowSelectorWidthResolved + dwScrollBarWidth + dwColumnPostNoWidth );
			}
			
		}

	}
}
