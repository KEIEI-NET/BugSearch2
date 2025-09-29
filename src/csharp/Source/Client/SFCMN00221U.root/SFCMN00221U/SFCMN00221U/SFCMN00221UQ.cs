using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.IO;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Text;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 仕入先検索ユーザーコントロールクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先と仕入先のアクセスクラスが分離した為新規追加しました。</br>
	/// <br>Programmer : 21024　佐々木　健</br>
	/// <br>Date       : 2008.05.22</br>
    /// <br>Update Note: 2012/12/24 王君</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>             Redmine#33741の対応</br>
	/// <br></br>
	/// </remarks>
	internal partial class SFCMN00221UQ : System.Windows.Forms.UserControl
	{
		// ===================================================================================== //
		// 仕入先検索フォームクラスのデフォルトコンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// 仕入先検索ユーザーコントロールクラスデフォルトコンストラクタ
		/// </summary>
		public SFCMN00221UQ( ControlScreenSkin controlScreenSkin )
		{
			// Windows フォーム デザイナ サポートに必要です。
			InitializeComponent();

			// スキン設定
			List<string> ctrlNameList = new List<string>();
			ctrlNameList.Add(this.uExplorerBar_Condition.Name);
			controlScreenSkin.SetExceptionCtrl(ctrlNameList);
			controlScreenSkin.SettingScreenSkin(this);
		}
		# endregion

		// ===================================================================================== //
		// 内部で使用する定数群
		// ===================================================================================== //
		# region Const
		private const int EDIT_TYPE_Kana = 1;														// 仕入先カナ
		private const int EDIT_TYPE_SupplierCd = 2;													// 仕入先コード

		private const string SEARCH_TABLE = "SupplierSearchTable";
		internal const string SEARCH_COL_EnterpriseCode = "EnterpriseCode";							// 企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)
		internal const string SEARCH_COL_SupplierCd = "SupplierCd";									// 仕入先コード
		internal const string SEARCH_COL_Name = "SupplierNm1";										// 名称
		internal const string SEARCH_COL_Name2 = "SupplierNm2";										// 名称２
		internal const string SEARCH_COL_HonorificTitle = "SuppHonorificTitle";						// 敬称
		internal const string SEARCH_COL_Kana = "Kana";												// カナ
		internal const string SEARCH_COL_TelNo = "TelNo";											// 電話番号
		internal const string SEARCH_COL_PostNo = "PostNo";											// 郵便番号
		internal const string SEARCH_COL_Address1 = "Address1";										// 住所１（都道府県市区郡・町村・字）
		internal const string SEARCH_COL_Address3 = "Address3";										// 住所３（番地）
		internal const string SEARCH_COL_Address4 = "Address4";										// 住所４（アパート名称）
		internal const string SEARCH_COL_Address = "Address";										// 住所
		internal const string SEARCH_COL_CustomerSearchRet = "CustomerSearchRet";					// 仕入先検索結果クラス
		private const string RECORD_KEY_SUPPLIER = "SupplierRecord";

		//private const int DEFAULT_EDIT_WIDTH = 224;
        private const int DEFAULT_EDIT_WIDTH = 320;
		private const int GUIDE_WIDTH_DIFFERENCE = 26;

		private const string FILENAME_COLDISPLAYSTATUS = "SFCMN00221U_ColSetting4.DAT";				// 列表示状態セッティングXMLファイル名
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private DataTable _searchDataTable;
		private DataView _searchDataView;
		private string _enterpriseCode = "";						// 企業コード
		private SFCMN00221UL _customControl_ExtractWait;
		private ColDisplayStatusList _colDisplayStatusList;			// 列表示状態コレクションクラス
		private bool _isInitial = true;								// 初期フラグ
		private SFCMN00221UAParam _param;
		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		/// <summary>パネル変更イベント</summary>
		internal event PanelChangeEventHandler PanelChange;

		/// <summary>仕入先選択後イベント</summary>
		internal event SupplierSelectedHandler SupplierSelected;
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
		/// <summary>
		/// 列表示状態クラス保存処理
		/// </summary>
		internal void SaveColDisplayStatus()
		{
            if (this.uGrid_Search.DataSource != null)
            {
                // 列表示状態クラスリスト構築処理
                List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns);
                this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

                // 列表示状態クラスリストをXMLにシリアライズする
                ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), FILENAME_COLDISPLAYSTATUS);
            }
		}
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// 初期設定処理
        /// <br>Update Note: 2013/02/07 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
		/// </summary>
		internal void InitialSetting(SFCMN00221UAParam param)
		{
			this._param = param;

			List<string> ctrlNameList = new List<string>();
			ctrlNameList.Add(this.uExplorerBar_Condition.Name);

			if (this._isInitial)
			{
				// 変数初期化
				this._searchDataTable = new DataTable(SEARCH_TABLE);
				this._searchDataView = new DataView(this._searchDataTable);
				this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;		// 企業コードを取得

				// 抽出中表示コントロール生成処理
				this._customControl_ExtractWait = new Broadleaf.Windows.Forms.SFCMN00221UL();
				this._customControl_ExtractWait.BringToFront();
				this._customControl_ExtractWait.BackColor = System.Drawing.Color.GhostWhite;
				this._customControl_ExtractWait.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
				this._customControl_ExtractWait.Location = new System.Drawing.Point(5, 245);
				this._customControl_ExtractWait.Name = "customControl_ExtractWait";
				this._customControl_ExtractWait.Size = new System.Drawing.Size(250, 40);
				this._customControl_ExtractWait.TabIndex = 22;
				this._customControl_ExtractWait.Visible = false;
				this._customControl_ExtractWait.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
				this.panel_Main.Controls.Add(this._customControl_ExtractWait);

				// グリッドにデータセットをバインド
				this.uGrid_Search.DataSource = this.dataSet_CustomerSearch;

				// コンポーネント初期設定
				this.tEdit_CustomerFindCondition.Top = 50;
				this.tEdit_CustomerFindCondition.Left = 11;
				this.tNedit_CustomerFindCondition.Top = 50;
				this.tNedit_CustomerFindCondition.Left = 11;

				this.uLabel_CustomerFindCondition.Top = 49;
				this.uLabel_CustomerFindCondition.Left = 10;

                // ----- ADD 王君 2013/02/07 for Redmine#33741 ----->>>>>
                this.uLabel_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width;
                this.tEdit_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width - 2;
                this.tNedit_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width - 2;
                // ----- ADD 王君 2013/02/07 for Redmine#33741 -----<<<<<

				this.tComboEditor_CustomerFindCondition.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
				this.uButton_Find.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));

				this.tComboEditor_CustomerFindCondition.Value = EDIT_TYPE_Kana;

				// イメージアイコン設定処理
				ImageList imglist = IconResourceManagement.ImageList16;

				// グリッドのフォントサイズを設定
				this.tComboEditor_GridFontSize.Value = 11;

				// 仕入先検索結果データテーブル設定処理
				this.SettingDataTable();

				// 仕入先検索結果グリッドカラム情報設定処理
				this.SettingGridColumns();

				this._isInitial = false;
			}

			// 抽出条件タイトル設定
			string dataType1 = "";
			//string dataType2 = "";
			this._customControl_ExtractWait.DataType = dataType1;
		}

		/// <summary>
		/// パネルアクティブメソッド
		/// </summary>
		internal void PanelActivated()
		{
			this.timer_Activated.Enabled = true;
		}

		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
		/// <summary>
		/// 仕入先検索結果データテーブル設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入先検索結果データテーブルを設定します。</br>
		/// <br>Programer  : 21024  佐々木 健</br>
		/// <br>Date       : 2008.05.22</br>
		/// </remarks>
		private void SettingDataTable()
		{
			DataColumn enterpriseCodeColumn = new DataColumn(SEARCH_COL_EnterpriseCode, typeof(String), "", MappingType.Element);		// 企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)
			DataColumn customerCodeColumn = new DataColumn(SEARCH_COL_SupplierCd, typeof(Int32), "", MappingType.Element);				// 仕入先コード
			DataColumn nameColumn = new DataColumn(SEARCH_COL_Name, typeof(String), "", MappingType.Element);							// 名称
			DataColumn name2Column = new DataColumn(SEARCH_COL_Name2, typeof(String), "", MappingType.Element);							// 名称２
			DataColumn honorificTitleColumn = new DataColumn(SEARCH_COL_HonorificTitle, typeof(String), "", MappingType.Element);		// 敬称
			DataColumn kanaColumn = new DataColumn(SEARCH_COL_Kana, typeof(String), "", MappingType.Element);							// カナ
			DataColumn homeTelNoColumn = new DataColumn(SEARCH_COL_TelNo, typeof(String), "", MappingType.Element);						// 電話番号
			DataColumn postNoColumn = new DataColumn(SEARCH_COL_PostNo, typeof(String), "", MappingType.Element);						// 郵便番号
			DataColumn address1Column = new DataColumn(SEARCH_COL_Address1, typeof(String), "", MappingType.Element);					// 住所１（都道府県市区郡・町村・字）
			DataColumn address3Column = new DataColumn(SEARCH_COL_Address3, typeof(String), "", MappingType.Element);					// 住所３（番地）
			DataColumn address4Column = new DataColumn(SEARCH_COL_Address4, typeof(String), "", MappingType.Element);					// 住所４（アパート名称）
			DataColumn addressColumn = new DataColumn(SEARCH_COL_Address, typeof(String), "", MappingType.Element);						// 住所４（アパート名称）
			DataColumn customerSearchRetColumn = new DataColumn(SEARCH_COL_CustomerSearchRet, typeof(Supplier), "", MappingType.Element);	// 仕入先検索結果クラス

			// データセットの初期化
			this.dataSet_CustomerSearch.Tables.AddRange(new DataTable[] { this._searchDataTable });

			// データテーブルの初期化
			this._searchDataTable.Columns.AddRange(new DataColumn[] {
																				    nameColumn,
																					name2Column,
																				    customerCodeColumn,
																				    kanaColumn,
																				    homeTelNoColumn,
																					postNoColumn,
																					address1Column,
																					address3Column,
																					address4Column,
																					addressColumn,
																				    enterpriseCodeColumn,
																					honorificTitleColumn,
																					customerSearchRetColumn
			});

			// 主キー設定(仕入先検索用テーブル）
			DataColumn[] columns = new DataColumn[] {customerCodeColumn};
			this._searchDataTable.PrimaryKey = columns;

			// ソート順設定(仕入先検索用テーブル）カナの昇順とする
			this._searchDataView.Sort = SEARCH_COL_Kana + " DESC";
		}

		/// <summary>
		/// 仕入先検索データテーブル行追加処理
		/// </summary>
		/// <param name="supplierSearchRet">仕入先検索結果クラス</param>
		/// <returns>値が設定されたデータ行</returns>
		/// <remarks>
		/// <br>Note       : 仕入先検索結果クラスをデータ行へ設定します。</br>
		/// <br>Programer  : 21024　佐々木 健</br>
		/// <br>Date       : 2008.05.22</br>
		/// </remarks>
		private void AddSupplierSearchTableRow(Supplier supplierSearchRet)
		{
			DataRow row = this._searchDataTable.NewRow();

			row[SEARCH_COL_EnterpriseCode] = supplierSearchRet.EnterpriseCode;		// 企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)
			row[SEARCH_COL_SupplierCd] = supplierSearchRet.SupplierCd;				// 仕入先コード
			row[SEARCH_COL_Name] = supplierSearchRet.SupplierNm1;					// 名称
			row[SEARCH_COL_Name2] = supplierSearchRet.SupplierNm2;					// 名称２
			row[SEARCH_COL_HonorificTitle] = supplierSearchRet.SuppHonorificTitle;	// 敬称
			row[SEARCH_COL_Kana] = supplierSearchRet.SupplierKana;					// カナ
			row[SEARCH_COL_TelNo] = supplierSearchRet.SupplierTelNo;				// 電話番号
			row[SEARCH_COL_PostNo] = supplierSearchRet.SupplierPostNo;				// 郵便番号
			row[SEARCH_COL_Address1] = supplierSearchRet.SupplierAddr1;				// 住所１（都道府県市区郡・町村・字）
			row[SEARCH_COL_Address3] = supplierSearchRet.SupplierAddr3;				// 住所３（番地）
			row[SEARCH_COL_Address4] = supplierSearchRet.SupplierAddr4;				// 住所４（アパート名称）
			row[SEARCH_COL_CustomerSearchRet] = supplierSearchRet.Clone();			// 仕入先検索結果クラス
			row[SEARCH_COL_Address] =
				supplierSearchRet.SupplierAddr1 +
				supplierSearchRet.SupplierAddr3 +
				supplierSearchRet.SupplierAddr4;									// 住所

			this._searchDataTable.Rows.Add(row);
		}

		/// <summary>
		/// 仕入先検索結果グリッドカラム情報設定処理
		/// </summary>
		/// <param name="Columns">グリッドのカラムコレクション</param>
		private void SettingGridColumns()
		{
			if (!this.uGrid_Search.DisplayLayout.Bands.Exists(SEARCH_TABLE))
			{
				return;
			}

			Infragistics.Win.UltraWinGrid.ColumnsCollection columns = this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns;

			// 一旦、全ての列を非表示に設定し、表示位置を統一させる
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
			{
				column.Hidden = true;
				column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
				column.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Left;
				column.CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
			}

			// 表示するカラム情報を設定する
			// 名称 列設定
			columns[SEARCH_COL_Name].Header.Caption = "仕入先名";
			columns[SEARCH_COL_Name].Hidden = false;
			columns[SEARCH_COL_Name].CellAppearance.Cursor = Cursors.Hand;

			// 仕入先コード 列設定
			columns[SEARCH_COL_SupplierCd].Header.Caption = "コード";
			columns[SEARCH_COL_SupplierCd].Hidden = false;
			columns[SEARCH_COL_SupplierCd].CellAppearance.Cursor = Cursors.Hand;
			columns[SEARCH_COL_SupplierCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

			// カナ 列設定
			columns[SEARCH_COL_Kana].Header.Caption = "カナ";
			columns[SEARCH_COL_Kana].Hidden = false;
			columns[SEARCH_COL_Kana].CellAppearance.Cursor = Cursors.Hand;

			// 自宅TEL 列設定
			columns[SEARCH_COL_TelNo].Header.Caption = "ＴＥＬ";
			columns[SEARCH_COL_TelNo].Hidden = false;
			columns[SEARCH_COL_TelNo].CellAppearance.Cursor = Cursors.Hand;

			// 住所 列設定
			columns[SEARCH_COL_Address].Header.Caption = "住所";
			columns[SEARCH_COL_Address].Hidden = false;
			columns[SEARCH_COL_Address].CellAppearance.Cursor = Cursors.Hand;

			// 列表示状態クラスリストXMLファイルをデシリアライズ
			List<ColDisplayStatus> colDisplayStatusList = ColDisplayStatusList.Deserialize(FILENAME_COLDISPLAYSTATUS);

			// 列表示状態コレクションクラスをインスタンス化
			this._colDisplayStatusList = new ColDisplayStatusList(this, colDisplayStatusList);

			foreach (ColDisplayStatus colDisplayStatus in this._colDisplayStatusList.GetColDisplayStatusList())
			{
				if (colDisplayStatus.Key == this.tComboEditor_GridFontSize.Name)
				{
					this.tComboEditor_GridFontSize.Value = colDisplayStatus.Width;
				}
				else if (columns.Exists(colDisplayStatus.Key))
				{
					columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
					columns[colDisplayStatus.Key].Header.Fixed = colDisplayStatus.HeaderFixed;
					columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
				}
			}
		}

		/// <summary>
		/// 列表示状態クラスリスト構築処理
		/// </summary>
		/// <param name="columns">グリッドのカラムコレクション</param>
		/// <returns>列表示状態クラスリスト</returns>
		/// <remarks>
		/// <br>Note       : グリッドのカラムコレクションを元に、列表示状態クラスリストを構築します。</br>
		/// <br>Programmer : 21024 佐々木 健</br>
		/// <br>Date       : 2008.05.22</br>
		/// </remarks>
		private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
		{
			List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

			// フォントサイズを格納
			ColDisplayStatus fontStatus = new ColDisplayStatus();
			fontStatus.Key = this.tComboEditor_GridFontSize.Name;
			fontStatus.VisiblePosition = -1;
			fontStatus.Width = (int)this.tComboEditor_GridFontSize.Value;
			colDisplayStatusList.Add(fontStatus);

			// グリッドから列表示状態クラスリストを構築
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
			{
				ColDisplayStatus colDisplayStatus = new ColDisplayStatus();

				colDisplayStatus.Key = column.Key;
				colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
				colDisplayStatus.HeaderFixed = column.Header.Fixed;
				colDisplayStatus.Width = column.Width;

				colDisplayStatusList.Add(colDisplayStatus);
			}

			return colDisplayStatusList;
		}

		/// <summary>
		/// パネル変更イベントコール処理
		/// </summary>
		/// <param name="mode">モード</param>
		private void PanelChangeEventCall(int dispNo)
		{
			if (this.PanelChange != null)
			{
				PanelChangeEventArgs e = new PanelChangeEventArgs(PanelChangeEventArgs.MODE_UPDATE, dispNo);
				this.PanelChange(this, e);
			}
		}

		/// <summary>
		/// TEdit入力プロパティド変換処理
		/// </summary>
		/// <param name="edit">変更するEditコンポーネント</param>
		/// <param name="mode">モード</param>
		private void TEditChangeEdit(Broadleaf.Library.Windows.Forms.TEdit edit, int mode)
		{
			switch (mode)
			{
				case EDIT_TYPE_Kana:													// 仕入先カナ
				{
					edit.CharacterCasing = CharacterCasing.Normal;
                    edit.ExtEdit =
                        new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 21, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
					edit.ImeMode = ImeMode.KatakanaHalf;
					break;
				}
			}
		}

		/// <summary>
		/// TNedit入力モード変換処理
		/// </summary>
		/// <param name="edit">変更するEditコンポーネント</param>
		/// <param name="mode">モード</param>
        ///<remarks>
        /// <br>Update Note : 2012/12/24 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        ///</remarks>
		private void TNeditChangeEdit(Broadleaf.Library.Windows.Forms.TNedit nEdit, int mode)
		{
			switch (mode)
			{
				case EDIT_TYPE_SupplierCd:											// 仕入先コード
				{
                    nEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
                    nEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
                    // ----- DEL 王君 2012/12/24 Redmine#33741 ----->>>>>
                    //nEdit.Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    //nEdit.ActiveAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    // ----- DEL 王君 2012/12/24 Redmine#33741 -----<<<<<
					break;
				}
			}
		}

		/// <summary>
		/// 仕入先検索条件クラス取得処理
		/// </summary>
		private Supplier GetSupplierSearchPara()
		{
			Supplier para = new Supplier();

			para.EnterpriseCode = this._enterpriseCode;									// 企業コード

			int customerMode = Convert.ToInt32(this.tComboEditor_CustomerFindCondition.SelectedItem.DataValue);

			switch (customerMode)
			{
				// 顧客コード
				case EDIT_TYPE_SupplierCd:
				{
					para.SupplierCd = this.tNedit_CustomerFindCondition.GetInt();
					break;
				}
				// 仕入先カナ
				case EDIT_TYPE_Kana:
				{
					para.SupplierKana = this.tEdit_CustomerFindCondition.Text.ToString();
					break;
				}
			}

			return para;
		}

		/// <summary>
		/// 仕入先検索処理
		/// </summary>
		/// <param name="para">仕入先検索検索パラメータ</param>
		private void Search(Supplier para)
		{
			// グリッドのフィルタを解除
			this.uGrid_Search.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();

			// データテーブルの行をクリア
			this._searchDataTable.Rows.Clear();

			this.uGrid_Search.Refresh();

			SupplierAcs supplierAcs = new SupplierAcs();
			ArrayList retArray;

			// 検索処理実行
			int status = supplierAcs.Search(out retArray, para, (int)SupplierAcs.SearchMode.Contains);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (Supplier supplier in retArray)
				{
					this.AddSupplierSearchTableRow(supplier);
				}
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
			{
				this._customControl_ExtractWait.Visible = true;
				this._customControl_ExtractWait.mode = 1;
				this._customControl_ExtractWait.Top = this.uGrid_Search.Top + 60;
				this._customControl_ExtractWait.Refresh();

				this.timer_MessageUnDisp.Enabled = true;
			}
			else
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"仕入先の検索に失敗しました。",
					status,
					MessageBoxButtons.OK);
			}
		}

		/// <summary>
		/// 仕入先検索パラメータクラスチェック処理
		/// </summary>
		/// <param name="para">仕入先マスタクラス</param>
		/// <returns>true:チェックＯＫ false:チェックＮＧ</returns>
		private bool CheckSupplierSearchPara(Supplier para)
		{
			return true;
		}
		# endregion

		// ===================================================================================== //
		// コントロールイベントメソッド
		// ===================================================================================== //
		# region Control Event Methods
		/// <summary>
		/// 検索タイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_Search_Tick(object sender, System.EventArgs e)
		{
			this.timer_Search.Enabled = false;

			try
			{
				this.Cursor = Cursors.WaitCursor;

				// 仕入先検索条件クラス取得処理
				Supplier para = this.GetSupplierSearchPara();

				// 仕入先検索パラメータクラスチェック処理
				if (!this.CheckSupplierSearchPara(para)) return;

				this._customControl_ExtractWait.Visible = true;
				this._customControl_ExtractWait.mode = 0;
				this._customControl_ExtractWait.Top = this.uGrid_Search.Top + 60;
				this._customControl_ExtractWait.Refresh();

				// 仕入先検索処理
				this.Search(para);
			}
			finally
			{
				if (this._customControl_ExtractWait.mode == 0)
				{
					this._customControl_ExtractWait.Visible = false;
					this.Cursor = Cursors.Default;
				}
			}
		}

		/// <summary>
		/// フォーカスコントロールイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

			switch (e.PrevCtrl.Name)
			{
				case "uButton_Find":
				{
					switch (e.Key)
					{
						case Keys.Return:
						{
							e.NextCtrl = e.PrevCtrl;

							this.uButton_Find_Click(this.uButton_Find, new EventArgs());

							break;
						}
						case Keys.Tab:
						{
							if (this.uGrid_Search.Rows.Count > 0)
							{
								e.NextCtrl = this.uGrid_Search;
							}
							else
							{
								e.NextCtrl = this.tComboEditor_CustomerFindCondition;
							}
							break;
						}
					}

					break;
				}
				case "tNedit_CustomerFindCondition":
				{
					if (e.Key == Keys.Return)
					{
						if (this.tNedit_CustomerFindCondition.GetInt() != 0)
						{
							this.uButton_Find_Click(this.uButton_Find, new EventArgs());
						}
					}

					break;
				}
				case "tEdit_CustomerFindCondition":
				{
					if (e.Key == Keys.Return)
					{
						if (this.tEdit_CustomerFindCondition.Text != "")
						{
							this.uButton_Find_Click(this.uButton_Find, new EventArgs());
						}
					}

					break;
				}
			}
		}

		/// <summary>
		/// 検索ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_Find_Click(object sender, System.EventArgs e)
		{
			this.timer_Search.Enabled = true;
		}

		/// <summary>
		/// 仕入先検索結果グリッドエレメントマウスエンターイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Search_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			if ((this.ActiveControl != this.uGrid_Search) && (this.uGrid_Search.Rows.Count > 0))
			{
				this.uGrid_Search.Focus();
			}

			// 仕入先情報をポップアップ表示
			Infragistics.Win.UIElement element = e.Element;
			object oContextRow = null;
			object oContextCell = null;

			oContextRow = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));
			oContextCell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

			if (oContextCell != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridCell cell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;
				cell.Appearance.ForeColor = Color.Blue;
				cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True;
			}

			if (oContextRow != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridRow row = (Infragistics.Win.UltraWinGrid.UltraGridRow)oContextRow;

				this.uGrid_Search.ActiveRow = row;
				this.uGrid_Search.ActiveRow.Selected = true;

				string tipString = "";

				if (row.Cells[0] != null)
				{
					int totalWidth = 6;

					// 仕入先名称
					tipString += this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Name].Header.Caption.PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_Name].Value.ToString();

					// カナ
					tipString += "\r\n" + this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Kana].Header.Caption.PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_Kana].Value.ToString();

					// コード
					tipString += "\r\n" + this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_SupplierCd].Header.Caption.PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_SupplierCd].Value.ToString();

					// 自宅TEL
					tipString += "\r\n" + TStrConv.HankakuToZenkaku(this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_TelNo].Header.Caption).PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_TelNo].Value.ToString();

					// 住所
					tipString += "\r\n" + this.uGrid_Search.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Address].Header.Caption.PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_Address].Value.ToString();
				}

				Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
				ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
				ultraToolTipInfo.ToolTipTitle = "仕入先情報";
				ultraToolTipInfo.ToolTipText = tipString;

				this.uToolTipManager_Information.Appearance.FontData.Name = "ＭＳ ゴシック";
				this.uToolTipManager_Information.SetUltraToolTip(this.uGrid_Search, ultraToolTipInfo);
				this.uToolTipManager_Information.Enabled = true;

				return;
			}
		}

		/// <summary>
		/// 仕入先検索結果グリッドエレメントマウスリーヴイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Search_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			Infragistics.Win.UIElement element = e.Element;
			object oContextCell = null;

			oContextCell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

			if (oContextCell != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridCell cell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;
				cell.Appearance.ForeColor = this.uGrid_Search.DisplayLayout.Override.CellAppearance.ForeColor;
				cell.Appearance.FontData.Underline = this.uGrid_Search.DisplayLayout.Override.CellAppearance.FontData.Underline;
			}
		}

		/// <summary>
		/// 仕入先検索結果グリッドクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Search_Click(object sender, System.EventArgs e)
		{
			//
		}

		/// <summary>
		/// アクティブタイマー起動処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_Activated_Tick(object sender, System.EventArgs e)
		{
			this.timer_Activated.Enabled = false;

			if (this.tEdit_CustomerFindCondition.Visible)
			{
				this.tEdit_CustomerFindCondition.Focus();
			}
			else if (this.tNedit_CustomerFindCondition.Visible)
			{
				this.tNedit_CustomerFindCondition.Focus();
			}
		}

		/// <summary>
		/// 検索条件コンボエディタ値変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Update Note: 2013/02/07 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// </remarks>
		private void tComboEditor_FindCondition_ValueChanged(object sender, System.EventArgs e)
		{
			if (!(sender is TComboEditor)) return;

			int mode = 0;

			TComboEditor tComboEditor = (TComboEditor)sender;

			if (tComboEditor.SelectedItem.DataValue is Int32)
			{
				mode = Convert.ToInt32(tComboEditor.SelectedItem.DataValue);
			}

			switch (mode)
			{
				// 仕入先カナ
				case EDIT_TYPE_Kana:
				{
					this.tEdit_CustomerFindCondition.Clear();
					this.tNedit_CustomerFindCondition.Clear();
					this.uLabel_CustomerFindCondition.Text = "";

					this.tEdit_CustomerFindCondition.Visible = true;
					this.tNedit_CustomerFindCondition.Visible = false;
					this.uLabel_CustomerFindCondition.Visible = true;

					this.uLabel_CustomerFindCondition.Appearance.BackColor = Color.White;
                    /* ----- DEL 王君 2013/02/07 for Redmine#33741 ----->>>>>
					this.tEdit_CustomerFindCondition.Width = DEFAULT_EDIT_WIDTH;
					this.tNedit_CustomerFindCondition.Width = DEFAULT_EDIT_WIDTH;
                       ----- DEL 王君 2013/02/07 for Redmine#33741 -----<<<<< */
					this.uLabel_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width;
                    // ----- ADD 王君 2013/02/07 for Redmine#33741 ----->>>>>
                    this.tEdit_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width - 2;
                    this.tNedit_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width - 2;
                    // ----- ADD 王君 2013/02/07 for Redmine#33741 -----<<<<<

					// TEdit入力プロパティド変換処理
					this.TEditChangeEdit(this.tEdit_CustomerFindCondition, mode);
					break;
				}
				// 顧客コード
				case EDIT_TYPE_SupplierCd:
				{
					this.tEdit_CustomerFindCondition.Clear();
					this.tNedit_CustomerFindCondition.Clear();
					this.uLabel_CustomerFindCondition.Text = "";

					this.tEdit_CustomerFindCondition.Visible = false;
					this.tNedit_CustomerFindCondition.Visible = true;
					this.uLabel_CustomerFindCondition.Visible = true;

					this.uLabel_CustomerFindCondition.Appearance.BackColor = Color.White;
                    /* ----- DEL 王君 2013/02/07 for Redmine#33741 ----->>>>>
					this.tEdit_CustomerFindCondition.Width = DEFAULT_EDIT_WIDTH;
					this.tNedit_CustomerFindCondition.Width = DEFAULT_EDIT_WIDTH;
                       ----- DEL 王君 2013/02/07 for Redmine#33741 -----<<<<< */
                    this.uLabel_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width;
                    // ----- ADD 王君 2013/02/07 for Redmine#33741 ----->>>>>
                    this.tEdit_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width - 2;
                    this.tNedit_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width - 2;
                    // ----- ADD 王君 2013/02/07 for Redmine#33741 -----<<<<<

					// TNedit入力プロパティド変換処理
					this.TNeditChangeEdit(this.tNedit_CustomerFindCondition, mode);
					break;
				}
			}
		}

		/// <summary>
		/// 抽出条件ラベルクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uLabel_CustomerFindCondition_Click(object sender, System.EventArgs e)
		{
			if (this.tEdit_CustomerFindCondition.Visible)
			{
				this.tEdit_CustomerFindCondition.Focus();
			}
			else if (this.tNedit_CustomerFindCondition.Visible)
			{
				this.tNedit_CustomerFindCondition.Focus();
			}
		}

		/// <summary>
		/// 抽出条件文字列入力エディタエンターイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tEdit_CustomerFindCondition_Enter(object sender, System.EventArgs e)
		{
			this.uLabel_CustomerFindCondition.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(227)), ((System.Byte)(156)));
		}

		/// <summary>
		/// 抽出条件数値入力エディタエンターイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tNedit_CustomerFindCondition_Enter(object sender, System.EventArgs e)
		{
			this.uLabel_CustomerFindCondition.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(227)), ((System.Byte)(156)));
			this.tNedit_CustomerFindCondition.Left = this.uLabel_CustomerFindCondition.Left + 1;
		}

		/// <summary>
		/// 抽出条件文字列入力エディタリーブイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tEdit_CustomerFindCondition_Leave(object sender, System.EventArgs e)
		{
			this.uLabel_CustomerFindCondition.Appearance.BackColor = Color.White;
		}

		/// <summary>
		/// 抽出条件数値入力エディタリーブイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tNedit_CustomerFindCondition_Leave(object sender, System.EventArgs e)
		{
			this.uLabel_CustomerFindCondition.Appearance.BackColor = Color.White;


			if (this.tNedit_CustomerFindCondition.NormalAppearance.TextHAlign == Infragistics.Win.HAlign.Right)
			{
				int left = this.uLabel_CustomerFindCondition.Width - this.tNedit_CustomerFindCondition.Width;
				if (left > this.uLabel_CustomerFindCondition.Left)
				{
					this.tNedit_CustomerFindCondition.Left = left;
				}
			}
			else
			{
				this.tNedit_CustomerFindCondition.Left = this.uLabel_CustomerFindCondition.Left + 1;
			}
		}

		/// <summary>
		/// 抽出条件コンボエディタサイズ変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Update Note: 2013/02/07 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// </remarks>
		private void tComboEditor_CustomerFindCondition_SizeChanged(object sender, System.EventArgs e)
		{
            /* ----- DEL 王君 2013/02/07 for Redmine#33741 ----->>>>>
			if (this.tComboEditor_CustomerFindCondition.Width > this.tEdit_CustomerFindCondition.Width)
			{
				this.uLabel_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width;
			}
			else
			{
				this.uLabel_CustomerFindCondition.Width = this.tEdit_CustomerFindCondition.Width + 2;
			}
               ----- DEL 王君 2013/02/07 for Redmine#33741 ----->>>>> */
            // ----- ADD 王君 2013/02/07 for Redmine#33741 ----->>>>>
            this.uLabel_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width;
            this.tEdit_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width - 2;
            this.tNedit_CustomerFindCondition.Width = this.tComboEditor_CustomerFindCondition.Width - 2;
            // ----- ADD 王君 2013/02/07 for Redmine#33741 -----<<<<<
		}


		/// <summary>
		/// 検索結果グリッドマウスダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uGrid_Search_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;

			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

			// マウスポインタがグリッドのどの位置にあるかを判定する
			Point point = System.Windows.Forms.Cursor.Position;
			point = targetGrid.PointToClient(point);
			Infragistics.Win.UIElement objElement = null;
			Infragistics.Win.UltraWinGrid.RowCellAreaUIElement element = null;

			objElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);

			if (objElement == null)
			{
				return;
			}

			element = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
				(typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

			// セル以外の場合は以下の処理をキャンセルする
			if (element == null)
			{
				return;
			}

			object oContextRow = null;

			oContextRow = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

			if (oContextRow == null)
			{
				return;
			}

			Infragistics.Win.UltraWinGrid.UltraGridRow row = (Infragistics.Win.UltraWinGrid.UltraGridRow)oContextRow;

			Supplier supplierSearchRet = (Supplier)row.Cells[SEARCH_COL_CustomerSearchRet].Value;

			if (this.SupplierSelected != null)
			{
				this.SupplierSelected(this, supplierSearchRet.Clone());

				// パネル変更イベントコール処理
				this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_CustomerLuncher);
			}
		}

		/// <summary>
		/// グリッドフォントサイズコンボボックス選択値変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_GridFontSize_ValueChanged(object sender, System.EventArgs e)
		{
			if (this.tComboEditor_GridFontSize.Value is int)
			{
				int fontSize = (int)this.tComboEditor_GridFontSize.Value;

				if (fontSize != 0)
				{
					this.uGrid_Search.Font = new System.Drawing.Font("ＭＳ ゴシック", fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
				}
			}
		}

		/// <summary>
		/// メッセージ非表示タイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_MessageUnDisp_Tick(object sender, System.EventArgs e)
		{
			this.timer_MessageUnDisp.Enabled = false;

			this._customControl_ExtractWait.Visible = false;
		}
		# endregion
	}
}
