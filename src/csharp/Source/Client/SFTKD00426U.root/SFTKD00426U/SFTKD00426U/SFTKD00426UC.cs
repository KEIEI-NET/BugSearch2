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
	/// キーワード検索ダイアログクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011　野口　暢朗</br>
	/// <br>Date       : 2005.05.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	internal class KeyWordSearchWindow : System.Windows.Forms.Form
	{
		#region コンポーネント
		
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

		#region 部分取得用データ

        ///// <summary>
        ///// 全部で何件か？
        ///// </summary>
        //private int totalCount = -1;

        ///// <summary>
        ///// ページ先頭を表すAddressData。
        ///// インデックスがページ。
        ///// </summary>
        //private ArrayList alPageKey = new ArrayList();

        ///// <summary>
        ///// そのページのキャッシュデータ。
        ///// </summary>
        //private ArrayList alPageData = new ArrayList();
		
        ///// <summary>
        ///// 現在のページのAddressData
        ///// </summary>
        //private AddressData awCurrent = new AddressData();
		
		#endregion
		
		#region キーワード整形メソッド
		
		/// <summary>
		/// 子音を母音？に変換するメソッド
		/// </summary>
		/// <param name="strTarget"></param>
		/// <returns></returns>
		private string replaceConsonant( string strTarget )
		{
			string strResult = (string)strTarget.Clone();

			char[] cTable = {'ァ','ィ','ゥ','ェ','ォ','ャ','ュ','ョ','ッ'};
			char[] mTable = {'ア', 'イ', 'ウ', 'エ', 'オ', 'ヤ', 'ユ', 'ヨ', 'ツ' };
			
			for( int i = 0 ; i < cTable.Length ; i++ )
			{
				strResult = strResult.Replace( cTable[i], mTable[i] );
			}
			return strResult;
		}
		
		/// <summary>
		/// 不適切な記号などを削除する
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
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();
			
			this.addressAcs = addressAcs;
			
			//キーワードを文字列検索窓にセット
			this.teKeyword.Text = keyword;
			
			this.setToolbarAppearance();
			
			dtResult = new DataTable();
			
			dtResult.Columns.Add( "郵便番号", typeof( string ) );
			dtResult.Columns.Add( "住所", typeof( string ) );
			dtResult.Columns.Add( "データ", typeof( AddressData ) );
			ugResult.DataSource = dtResult;
			ugResult.DataBind();
			
			this.setGridAppearance( ugResult );
			this.setGridBehavior( ugResult );
			this.setTEditAppearance( this.teKeyword );
			
			//this.ugResult.DisplayLayout.AutoFitColumns = true;
            ugResult.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            this.ugResult.DisplayLayout.Bands[0].Columns["データ"].Hidden = true;

			this.PerformAutoFitResultColumns();

            this.areaGroupTComboEditor.ValueChanged -= new EventHandler(this.areaGroupTComboEditor_ValueChanged);

            #region 管区コンボのデータ設定

            //キーワード検索絞り用管区を設定
            List<AreaGroup> areaGroupList = null;
            AddressInfoAreaGroupCacheAcs.GetAreaGroup(out areaGroupList);

            //頭に全国を入れておく
            this.areaGroupTComboEditor.Items.Add(0, "全国");

            for (int i = 0; i < areaGroupList.Count; i++)
            {
                this.areaGroupTComboEditor.Items.Add(areaGroupList[i].AreaGroupCode, areaGroupList[i].AreaName);
            }

            //先頭の全国を選択
            // TODO : 所属管区を選択状態にするように変更する
            if (this.areaGroupTComboEditor.Items.Count > 0)
            {
                this.areaGroupTComboEditor.SelectedIndex = 0;
            }

            //表示管区を選択
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
		
		#region 検索メソッド
		
		private class AddressDataComparer : IComparer
		{

			#region IComparer メンバ

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
		/// データをグリッドに表示する
		/// </summary>
		private void SetAddressWorkToGrid( List<AddressData> alTarget )
		{
			//テーブルの中身をクリアする
			this.dtResult.Clear();
			
			//該当があるなら表示する
			if( alTarget != null && alTarget.Count > 0 )
			{
				foreach( AddressData aw in alTarget )
				{
					DataRow dr = dtResult.NewRow();
					
					dr["住所"] = aw.AddressName;
					dr["郵便番号"] = aw.PostNo;
					dr["データ"] = aw;

					dtResult.Rows.Add( dr );
				}
			}

            this.dtResult.DefaultView.Sort = "郵便番号";

            this.ultraStatusBar1.Text = "該当件数 " + alTarget.Count + " 件";
		}
		
		/// <summary>
		/// キーワードで検索する
		/// </summary>
		private void SearchKeywordMatchAddress()
		{
			//無効文字を削除
			string strKeyword = this.removeInvalidCharacter( this.teKeyword.Text );
			
			//何もキーワードが指定されていない場合
			if( strKeyword == "" )
			{
				return;
			}

            List<AddressData> alResult = null;
			
			this.addressAcs.GetAddrFromName( (int)this.areaGroupTComboEditor.Items[ this.areaGroupTComboEditor.SelectedIndex].DataValue, strKeyword, out alResult );
			
			this.SetAddressWorkToGrid( alResult );
		}
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
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("確定(S)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("取り消し(X)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("確定(S)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("取り消し(X)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("前の結果(P)");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("次の結果(N)");
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
			buttonTool3.SharedProps.Caption = "確定(&S)";
			buttonTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool4.SharedProps.Caption = "戻る(&C)";
			buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool5.SharedProps.Caption = "前の結果(&P)";
			buttonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool6.SharedProps.Caption = "次の結果(&N)";
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
			this.ultraLabel1.Text = "キーワード";
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
			this.Text = "住所キーワード検索";
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

		#region 確定、キャンセル処理
		
		private AddressData addressWorkResult = null;
		
		public AddressData GetResult()
		{
			return this.addressWorkResult;
		}

		private void PerformOkClick()
		{
			if( this.ugResult.ActiveRow != null ){
				this.addressWorkResult = this.ugResult.ActiveRow.Cells["データ"].Value as AddressData;
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
		/// フォーカスが変更されたときの処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			TEdit te;
			UltraGrid ug;
			
			//エンターキー以外で呼ばれたときは何もしない
			if( e.Key != System.Windows.Forms.Keys.Enter )
			{
				return;
			}
			
			//キーワード用テキストボックスに何も入っていなかったら
			//フォーカスを移動しない
			if( (te = e.PrevCtrl as TEdit) != null )
			{
                if (this.KeywordSearch())
                {
                    return;
                }
			}
				//アイテムが選択されているときにリストボックスにフォーカスがあって
				//エンターが押されたら確定ボタンを押したことにする
			else if( (ug = e.PrevCtrl as UltraGrid) != null )
			{
				this.PerformOkClick();
			}
			
		}

        /// <summary>
        /// キーワード検索を開始する
        /// </summary>
        /// <returns>閉じるかどうか</returns>
        private bool KeywordSearch()
        {
            this.WaitWindowShow();

            try
            {
                this.SearchKeywordMatchAddress();

                //一件しか該当がない場合はOKを押したことにする
                if (this.dtResult.Rows.Count == 1)
                {
                    this.ugResult.Rows[0].Activate();
                    PerformOkClick();
                    return true;
                }
            }
            finally
            {
                //お待ちください窓を閉じる
                this.WaitWindowClose();
            }

            return false;
        }

		private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch( e.Tool.CaptionResolved )
			{
				case "確定(&S)":
					this.PerformOkClick();
					break;
					
				case "戻る(&C)":
					this.PerformCancelClick();
					break;
					
				default:
					break;
			}
			
		}
		
		/// <summary>
		/// ShowDialog()されたときの処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void KeyWordSearchWindow_Load(object sender, System.EventArgs e)
		{
            //津行状Shownに移動
            //if (this.KeywordSearch())
            //{
            //    return;
            //}
        }
		
		#region グリッドのイベント

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

		//UltraGridがダブルクリックされたときの処理
		private void ugResult_DoubleClick(object sender, System.EventArgs e)
		{
            if (GetCell(Cursor.Position, this.ugResult) == null)
            {
                return;
            }

			//確定が押されたことにする
			this.PerformOkClick();
		}
		
		/// <summary>
		/// 列がアクティブになったときの処理
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

				
		#region お待ちくださいウインドウメソッド

        private SFCMN00299CA waitWindow = null;
		
		/// <summary>
		/// お待ちください窓表示関数
		/// </summary>
		private void WaitWindowShow()
		{
			//窓が無い場合
			if( this.waitWindow == null )
			{
                this.waitWindow = new SFCMN00299CA();
                this.waitWindow.DispCancelButton = false;
                this.waitWindow.Message = "住所情報を取得しています。";
                this.waitWindow.Title = "住所情報取得";
			}
			
			waitWindow.Show( this );
		}
		
		/// <summary>
		/// お待ちください窓閉じる関数
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
		/// グリッドの列自動サイズ
		/// </summary>
		private void PerformAutoFitResultColumns()
		{
			int dwScrollBarWidth = 20;
			
			int dwColumnPostNoWidth = 120;
			
			this.ugResult.DisplayLayout.Bands[0].Columns["郵便番号"].Width = dwColumnPostNoWidth;
			
			this.ugResult.DisplayLayout.Bands[0].Columns["住所"].Width = this.ugResult.Width;
						
			if( this.ugResult.Width > this.ugResult.DisplayLayout.Bands[0].RowSelectorWidthResolved + dwScrollBarWidth + dwColumnPostNoWidth )
			{
				this.ugResult.DisplayLayout.Bands[0].Columns["住所"].Width -= ( this.ugResult.DisplayLayout.Bands[0].RowSelectorWidthResolved + dwScrollBarWidth + dwColumnPostNoWidth );
			}
			
		}
		
		/// <summary>
		/// グリッドの幅が変更されたときのイベント
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
