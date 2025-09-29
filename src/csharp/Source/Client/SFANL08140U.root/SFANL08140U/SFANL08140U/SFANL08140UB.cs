using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 案内文はがき選択ガイドUIクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票選択ガイドで案内文が選択された時に表示されるガイドです。</br>
	/// <br>Programmer	: 30015　橋本 裕毅</br>
	/// <br>Date		: 2007.11.06</br>
	/// <br></br>
	/// </remarks>
	public partial class SFANL08140UB : Form
	{
        /// <summary>
        /// コンストラクタ
        /// </summary>
		public SFANL08140UB()
		{
			InitializeComponent();

			_dsDmGuideSnt = new DataSet();
			DataTable dtDmGuideSnt;
			CreateSchema( out dtDmGuideSnt ); // 案内文はがき選択ガイドデータスキーマ作成処理
			_dsDmGuideSnt.Tables.Add( dtDmGuideSnt );		
            this.setToolbarAppearance(); // Toolbar表示設定処理

		}

// **** Const *******************************************************************************
        #region Const

		private const string TBL_DmGuideSnt						= "DmGuideSnt";
		private const string COL_PGIDRF							= "PgId";		// プログラムID
		private const string COL_PGIDNAMERF						= "PgName";		// プログラムID名称
		private const string COL_DMNORF							= "DmNo";		// DMナンバー
		private const string COL_DMGUIDANCERF					= "DmGuidance"; // DM案内文

		private const string CONST_SFANL08140U_DISPLAYINFO = "SFANL08140U_DispInfo.xml"; // 実行環境パス
        #endregion

// **** Private Members *********************************************************************
        #region Private Members

        private string _enterpriseCode;　               // 企業コード
        private DataSet _dsDmGuideSnt;                					// 案内文選択DataSet
		private FrePrtGuideSearchRet _frePrtGuideSearchRet = null;		// 自由帳票結果クラス
		Broadleaf.Windows.Forms.FPprSearchGuide.DialogRetCode _dialogRetCode;


        /// <summary>
		/// 自由帳票選択ガイドを表示する
		/// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="frePrtGuideSearchRet"></param>
		/// <returns>列挙体</returns>
		/// <remarks>
		/// <br>Note		: フォームが呼び出された時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>n
		/// </remarks>
		public Broadleaf.Windows.Forms.FPprSearchGuide.DialogRetCode ShowDmGuideSnt(string enterpriseCode ,ref FrePrtGuideSearchRet frePrtGuideSearchRet)
		{
			_enterpriseCode = enterpriseCode;
			_frePrtGuideSearchRet = new FrePrtGuideSearchRet();
			_frePrtGuideSearchRet = frePrtGuideSearchRet;
			_dialogRetCode = FPprSearchGuide.DialogRetCode.Return;

			this.ShowDialog();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
            //switch ( _dialogRetCode )
            //{
            //    case FPprSearchGuide.DialogRetCode.DMPostCard:
            //        frePrtGuideSearchRet = _frePrtGuideSearchRet;
            //        break;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
			return _dialogRetCode;
		}


		/// <summary>
		/// 案内文はがき選択ガイドデータスキーマ作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 自由帳票ガイドのスキーマを作成します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void CreateSchema( out DataTable dtDmGuideSnt )
		{
			//列を設定
			dtDmGuideSnt = new DataTable(TBL_DmGuideSnt );
			dtDmGuideSnt.Columns.Add( COL_PGIDRF		, typeof( string ) );
			dtDmGuideSnt.Columns.Add( COL_PGIDNAMERF	, typeof( string ) );
			dtDmGuideSnt.Columns.Add( COL_DMNORF		, typeof( int ) );
			dtDmGuideSnt.Columns.Add( COL_DMGUIDANCERF	, typeof( string ) );
        }

        /// <summary>
	    /// ultraToolbarsManager_ToolClickイベント
	    /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note        : ツールバーのボタンをクリックした時のイベントです。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "OK_Button":
					this.OkClick();
					break;
			}
		}

		/// <summary>
		/// 確定押下時処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : 確定が押されたときの処理です</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void OkClick()
		{
			if (this.DmGuideSnt_ultraGrid.ActiveRow != null)
			{
				_frePrtGuideSearchRet.PgId = this.DmGuideSnt_ultraGrid.ActiveRow.Cells[COL_PGIDRF].Value.ToString();	// PGID
				_frePrtGuideSearchRet.DmNo = (int)this.DmGuideSnt_ultraGrid.ActiveRow.Cells[COL_DMNORF].Value;			// DMNo
				_frePrtGuideSearchRet.PgSequenceNo = 0; // プログラム通し番号(2007/11/6現在、車検点検一覧のみ通し番号が振ってある状態。有効マクロ文字はプログラム通し番号が0の時しかデータが存在していない)
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                //_dialogRetCode = FPprSearchGuide.DialogRetCode.DMPostCard;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
			}

			this.Close();
		}

        ///// <summary>
        ///// 案内文グリッド展開処理
        ///// </summary>
        ///// <param name="list">結果List</param>
        ///// <remarks>
        ///// <br>Note        : 取得してきた案内文をグリッドに展開します</br>
        ///// <br>Programmer	: 30015 橋本　裕毅</br>
        ///// <br>Date		: 2007.11.06</br>
        ///// </remarks>
        //private void ExtendToGrid(ArrayList list)
        //{
        //    _dsDmGuideSnt.Tables[TBL_DmGuideSnt].Rows.Clear();
        //    foreach (DmGuideSnt dmGuideSnt in list)
        //    {
        //        // DMパターン名称は表示順位が0の時(グリッドには表示順位が0のものだけ表示
        //        if (dmGuideSnt.DetailDisplayOrder == 0)
        //        {
        //            DataRow drAdd = _dsDmGuideSnt.Tables[TBL_DmGuideSnt].NewRow();
        //            drAdd[COL_PGIDRF]		= dmGuideSnt.PgId;
        //            drAdd[COL_PGIDNAMERF]	= dmGuideSnt.PgName;
        //            drAdd[COL_DMNORF]		= dmGuideSnt.DmNo;
        //            drAdd[COL_DMGUIDANCERF]	= dmGuideSnt.DmGuidance;

        //            _dsDmGuideSnt.Tables[TBL_DmGuideSnt].Rows.Add( drAdd );
        //        }

        //    }
        //}

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面を初期化します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void InitializeDisplay()
		{
            this.DmGuideSnt_ultraGrid.DataSource = _dsDmGuideSnt;
            this.DmGuideSnt_ultraGrid.DataMember = TBL_DmGuideSnt;
            
            this.setGridAppearance( this.DmGuideSnt_ultraGrid ); // UltraGrid配色設定処理

            this.setGridBehavior( this.DmGuideSnt_ultraGrid); // UltraGrid挙動設定処理
			
		}

		/// <summary>
		/// Toolbar表示設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : Toolbarの表示を設定します</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void setToolbarAppearance()
		{
			//ツールバーにアイコン設定
			//SFCMN00008C
			ImageList imList = IconResourceManagement.ImageList16;
			this.ultraToolbarsManager1.ImageListSmall = imList;

			this.ultraToolbarsManager1.Toolbars[0].Tools[0].InstanceProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;

			//ツールバーをカスタマイズ不可にする
			this.ultraToolbarsManager1.ToolbarSettings.AllowCustomize  = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockLeft   = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockRight  = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockTop    = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowFloating   = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowHiding     = Infragistics.Win.DefaultableBoolean.False;
		}
        #endregion

		/// <summary>
		/// FPprSearchGuide_Loadイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォームが呼び出された時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void SFANL08140UB_Load(object sender, EventArgs e)
		{
			// 画面初期化
			InitializeDisplay();

			this.Initial_Timer.Enabled = true;

            //// DM案内文マスタ読込
            //DmGuideSntAcs dmGuideSntAcs = new DmGuideSntAcs();
            //ArrayList retList = null;
            //try
            //{
            //    dmGuideSntAcs.Search(out retList, _enterpriseCode);
            //}
            //catch (Exception ex)
            //{
            //    // メッセージボックス表示
            //    string message = "案内文はがき選択ガイドにてエラーが発生しました。\r\n" + ex.Message;
            //    TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, message, 0, MessageBoxButtons.OK );
            //    _dialogRetCode = FPprSearchGuide.DialogRetCode.Error;
            //    return;
            //}

            //// XMLに表示許可されているものに関してのみ、グリッドに展開
            //ArrayList list = new ArrayList();
            //// XMLファイルを読み取り、項目をフィルタリングする
            //DMGuidanceDevelopSelect[] dMGuidanceDevelopSelects =(DMGuidanceDevelopSelect[])XmlByteSerializer.Deserialize(CONST_SFANL08140U_DISPLAYINFO, typeof(DMGuidanceDevelopSelect[]));
            //if ((dMGuidanceDevelopSelects != null) ||
            //    (dMGuidanceDevelopSelects.Length != 0))
            //{
            //    for (int i = 0; i != dMGuidanceDevelopSelects.Length; i++)
            //    {
            //        foreach (DmGuideSnt wkDmGuideSnt in retList)
            //        {
            //            if (dMGuidanceDevelopSelects[i].DevelopCd == 0)
            //            {
            //                // PGIDが共通し、且展開区分が展開するの場合
            //                if (dMGuidanceDevelopSelects[i].PgId == wkDmGuideSnt.PgId)
            //                {
            //                    list.Add(wkDmGuideSnt);
            //                }
            //            }
            //        }
            //    }
            //}

            //// グリッド展開
            //this.ExtendToGrid(list);
            //if (this.DmGuideSnt_ultraGrid.Rows.Count <= 0)
            //{
            //    // メッセージボックス表示
            //    string message = "対象となる案内文がありません。";
            //    TMsgDisp.Show( emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, message, 0, MessageBoxButtons.OK );
            //    this.Close();
            //    _dialogRetCode = FPprSearchGuide.DialogRetCode.Return;
            //    return;
            //}
		}

		/// <summary>
		/// DmGuideSnt_ultraGrid_InitializeLayoutイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 案内文グリッドが初期化された時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void DmGuideSnt_ultraGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			e.Layout.Bands[0].Columns[COL_PGIDRF].Hidden
				= true;
			e.Layout.Bands[0].Columns[COL_PGIDNAMERF].Header.Caption
				= "設定DM名称";
			e.Layout.Bands[0].Columns[COL_DMNORF].Header.Caption
				= "DMNo";
            e.Layout.Bands[0].Columns[COL_DMGUIDANCERF].Header.Caption
                = "DMパターン名称";
		}

        /// <summary>
		/// DmGuideSnt_ultraGrid_DoubleClickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note        : グリッドがダブルクリックされたときの処理</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void DmGuideSnt_ultraGrid_DoubleClick(object sender, EventArgs e)
		{
			UltraGridRow ultraGridRow = this.DmGuideSnt_ultraGrid.ActiveRow;
			// マウスポインタがグリッドのどの位置にあるかを判定する
			Point point = System.Windows.Forms.Cursor.Position;
			point = this.DmGuideSnt_ultraGrid.PointToClient(point);
			Infragistics.Win.UIElement objElement = null;
			Infragistics.Win.UltraWinGrid.RowCellAreaUIElement	objRowCellAreaUIElement = null;
			objElement = this.DmGuideSnt_ultraGrid.DisplayLayout.UIElement.ElementFromPoint(point);
			
			objRowCellAreaUIElement= (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
				(typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));
			
			// ヘッダ部の場合は以下の処理をキャンセルします。
			if(objRowCellAreaUIElement == null)
			{
				return;
			}

			if ( ultraGridRow != null )
			{
			    this.OkClick();
			}
		}

		/// <summary>
		/// UltraGrid配色設定処理
		/// </summary>
		/// <param name="ugTarget"></param>
		/// <remarks>
		/// <br>Note        : UltraGridの配色を設定する</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void setGridAppearance( Infragistics.Win.UltraWinGrid.UltraGrid ugTarget )
		{
            //タイトルの外観
            ugTarget.DisplayLayout.Override.HeaderAppearance.BackColor          = Color.FromArgb( 89, 135, 214 );
            ugTarget.DisplayLayout.Override.HeaderAppearance.BackColor2         = Color.FromArgb( 7, 59, 150 );
            ugTarget.DisplayLayout.Override.HeaderAppearance.BackGradientStyle  = Infragistics.Win.GradientStyle.Vertical;
            ugTarget.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            ugTarget.DisplayLayout.Override.HeaderAppearance.ForeColor          = Color.White;

            //背景色を設定
            ugTarget.DisplayLayout.Appearance.BackColor = Color.White;

            //文字をカラムに入るように設定する
            ugTarget.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // 選択行の外観を設定
            ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackColor         = Color.FromArgb( 251, 230, 148 );
            ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackColor2        = Color.FromArgb( 238, 149, 21 );
            ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            //行セレクタの設定
            ugTarget.DisplayLayout.Override.RowSelectorAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackColor          = Color.FromArgb( 89, 135, 214 );
            ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackColor2         = Color.FromArgb( 7, 59, 150 );
            ugTarget.DisplayLayout.Override.RowSelectorAppearance.ForeColor          = Color.White;

            ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            //行のサイズ変更不可
            ugTarget.DisplayLayout.Override.RowSizing = RowSizing.Fixed;

            //インジゲータ非表示
            ugTarget.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            //分割領域非表示
            ugTarget.DisplayLayout.MaxColScrollRegions = 1;
            ugTarget.DisplayLayout.MaxRowScrollRegions = 1;

            //交互に行の色を変える
            ugTarget.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.FromArgb( 192, 192, 255 );

            //グリッドの背景色を変える
            ugTarget.DisplayLayout.Appearance.BackColor = Color.Gray;

            //アクティブ行のフォントの色を変える
            ugTarget.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;

            //アクティブ行のフォントを太字にする
            ugTarget.DisplayLayout.Override.ActiveRowAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			
            //アクティブ行の色を設定する
            ugTarget.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb( 247, 227, 156 );
		}
		
		/// <summary>
		/// UltraGrid挙動設定処理
		/// </summary>
		/// <param name="ugTarget"></param>
		/// <remarks>
		/// <br>Note        : UltraGridの挙動を設定する</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void setGridBehavior( Infragistics.Win.UltraWinGrid.UltraGrid ugTarget )
		{
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

            // ユーザーのデータ書き換え不可
            ugTarget.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;

            //選択方法を行選択に設定。
            ugTarget.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

            //+列選択不可にすることでヘッダをクリックしても何も起こらない
            ugTarget.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;

            //一行のみ選択可能にする
            ugTarget.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;

            //スクロール中にもいまどこが見えている状態なのかがわかるようにする
            ugTarget.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;

            //IME無効
            ugTarget.ImeMode = ImeMode.Disable;

            ugTarget.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            ugTarget.DisplayLayout.LoadStyle = LoadStyle.LoadOnDemand;
		}

		/// <summary>
		/// DmGuideSnt_ultraGrid_KeyDownイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 案内文のグリッド上でキーが押下された時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void DmGuideSnt_ultraGrid_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
                UltraGridRow ultraGridRow = this.DmGuideSnt_ultraGrid.ActiveRow;
                if ( ultraGridRow != null )
                {
                    this.OkClick();
                }
			}
		}

		/// <summary>
		/// Initial_Timer_Tickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 初期化タイマーイベントです。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

			if(this.DmGuideSnt_ultraGrid.Rows.Count > 0)
			this.DmGuideSnt_ultraGrid.Rows[0].Activate();
        }

		/// <summary>
		/// FPprGrid_AfterRowActivateイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note        : グリッドの列がアクティブになったときの処理</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void DmGuideSnt_ultraGrid_AfterRowActivate(object sender, System.EventArgs e)
		{
			if( this.DmGuideSnt_ultraGrid.ActiveRow == null )
			{
				return;
			}
			this.DmGuideSnt_ultraGrid.ActiveRow.Selected = true;
        }

	}
}