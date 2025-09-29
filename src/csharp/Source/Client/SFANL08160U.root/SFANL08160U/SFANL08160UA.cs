using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 自由帳票印字位置ImportUIクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票印字位置設定情報のImportを行う為のUI画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.11.08</br>
    /// <br></br>
    /// <br>UpdateNote	: 2008.06.09 22018 鈴木 正臣</br>
    /// <br>             :   PM.NS向け変更。</br>
    /// <br></br>
    /// <br>UpdateNote	: 2009.06.01 22018 鈴木 正臣</br>
    /// <br>             :   区分＝帳票のインポートに対応する為、一部修正。</br>
	/// </remarks>
	public partial class SFANL08160UA : Form
	{
		#region Const
		// ツールボタン用
		private const string ctButtonTool_Open		= "Open_ButtonTool";
		private const string ctButtonTool_SelectALL	= "SelectAll_ButtonTool";
		private const string ctButtonTool_CancelALL	= "CancelAll_ButtonTool";
		// スキーマ用
		private const string TBL_FREPRTEXPORT = "FrePrtExport";
		private const string COL_FREPRTEXPORT_IMPORTEDFLG			= "ImportedFlg";			// インポート済みフラグ
		private const string COL_FREPRTEXPORT_EXTRACTIONITDEDFLG	= "ExtractionItdedFlg";		// 抽出対象フラグ
		private const string COL_FREPRTEXPORT_ENTERPRISECODE		= "EnterpriseCode";			// 企業コード
		private const string COL_FREPRTEXPORT_OUTPUTFORMFILENAME	= "OutputFormFileName";		// 出力ファイル名
		private const string COL_FREPRTEXPORT_USERPRTPPRIDDERIVNO	= "UserPrtPprIdDerivNo";	// ユーザー帳票ID枝番号
		private const string COL_FREPRTEXPORT_DISPLAYNAME			= "DisplayName";			// 出力名称
		private const string COL_FREPRTEXPORT_PRTPPRUSERDERIVNOCMT	= "PrtPprUserDerivNoCmt";	// 帳票ユーザー枝番コメント
		private const string COL_FREPRTEXPORT_EXPORTDATAFILEPATH	= "ExportDataFilePath";		// エクスポートデータファイルパス
		private const string COL_FREPRTEXPORT_DATAINPUTSYSTEM		= "DataInputSystem";		// データ入力システム
		private const string COL_FREPRTEXPORT_PRINTPAPERUSEDIVCD	= "PrintPaperUseDivcd";		// 帳票使用区分
		private const string COL_FREPRTEXPORT_NOTE					= "Note";					// 備考
		private const string COL_FREPRTEXPORT_SLIPKINDENTRYDIV1		= "SlipKindEntryDiv1";		// 伝票種別登録区分1
		private const string COL_FREPRTEXPORT_SLIPKINDENTRYDIV2		= "SlipKindEntryDiv2";		// 伝票種別登録区分2
		private const string COL_FREPRTEXPORT_SLIPKINDENTRYDIV3		= "SlipKindEntryDiv3";		// 伝票種別登録区分3
		private const string COL_FREPRTEXPORT_SLIPKINDENTRYDIV4		= "SlipKindEntryDiv4";		// 伝票種別登録区分4
		private const string COL_FREPRTEXPORT_SLIPPRTKIND			= "SlipPrtKind";			// 伝票印刷種別
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
        private const string COL_FREPRTEXPORT_FREEPRTPPRITEMGRPCD   = "FreePrtPprItemGrpCd";    // 自由帳票印刷項目グループコード
        private const string COL_FREPRTEXPORT_FREEPRTPPRSPPRPSECD   = "FreePrtPprSpPrpseCd";    // 自由帳票特殊用途コード
        private const string COL_FREPRTEXPORT_OUTPUTFORMFILENAME_ORG = "OutputFormFileName_ORG";		// 出力ファイル名（変更前）
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
		#endregion

		#region PrivateMember
		// --------------------------------------------------------
		// ☆☆☆ 各種アクセスクラス ☆☆☆
		// --------------------------------------------------------
		// 自由帳票Exportアクセスクラス
		private FrePrtPSetImportAcs	_frePrtPSetImportAcs;

		// --------------------------------------------------------
		// ☆☆☆ その他ワーク変数 ☆☆☆
		// --------------------------------------------------------
		// Gridバインド用DataTable
		private DataTable			_dt;
		// Exportファイルパス
		private string				_exportFilePath;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
        // 帳票ID変換ディクショナリ
        private Dictionary<string, string> _exchangeDic;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08160UA()
		{
			InitializeComponent();

			_frePrtPSetImportAcs = new FrePrtPSetImportAcs();
			_frePrtPSetImportAcs.FrePrtPSetImported += new FrePrtPSetImportAcs.FrePrtPSetImportEventHandler(FrePrtPSetImportAcs_FrePrtPSetImported);

			InitializeSetting();
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// 初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 初期設定を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void InitializeSetting()
		{
			this.Main_ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
			// 開く
			ButtonTool openButton = (ButtonTool)this.Main_ToolbarsManager.Tools[ctButtonTool_Open];
			if (openButton != null) openButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.FOLDER2;
			// 全選択
			ButtonTool selectAllButton = (ButtonTool)this.Main_ToolbarsManager.Tools[ctButtonTool_SelectALL];
			if (selectAllButton != null) selectAllButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLSELECT;
			// 全解除
			ButtonTool cancelAllButton = (ButtonTool)this.Main_ToolbarsManager.Tools[ctButtonTool_CancelALL];
			if (cancelAllButton != null) cancelAllButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
			// インポートボタン
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ubImport.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.IMPORT];
            this.ubImport.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CSVOUTPUT];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
			// 終了ボタン
			this.ubCancel.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CLOSE];

			// DataTableのスキーマ設定
			_dt = new DataTable(TBL_FREPRTEXPORT);
			_dt.Columns.Add(COL_FREPRTEXPORT_EXTRACTIONITDEDFLG,	typeof(int));		// 抽出対象フラグ
			_dt.Columns.Add(COL_FREPRTEXPORT_ENTERPRISECODE,		typeof(string));	// 企業コード
			_dt.Columns.Add(COL_FREPRTEXPORT_OUTPUTFORMFILENAME,	typeof(string));	// 出力ファイル名
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
            _dt.Columns.Add( COL_FREPRTEXPORT_OUTPUTFORMFILENAME_ORG, typeof( string ) );	// 出力ファイル名
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
			_dt.Columns.Add(COL_FREPRTEXPORT_USERPRTPPRIDDERIVNO,	typeof(int));		// ユーザー帳票ID枝番号
			_dt.Columns.Add(COL_FREPRTEXPORT_DATAINPUTSYSTEM,		typeof(int));		// データ入力システム
			_dt.Columns.Add(COL_FREPRTEXPORT_PRINTPAPERUSEDIVCD,	typeof(int));		// 帳票使用区分
			_dt.Columns.Add(COL_FREPRTEXPORT_DISPLAYNAME,			typeof(string));	// 出力名称
			_dt.Columns.Add(COL_FREPRTEXPORT_PRTPPRUSERDERIVNOCMT,	typeof(string));	// 帳票ユーザー枝番コメント
			_dt.Columns.Add(COL_FREPRTEXPORT_EXPORTDATAFILEPATH,	typeof(string));	// エクスポートデータファイルパス
			_dt.Columns.Add(COL_FREPRTEXPORT_NOTE,					typeof(string));	// 備考
			_dt.Columns.Add(COL_FREPRTEXPORT_SLIPPRTKIND,			typeof(int));		// 伝票印刷種別
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
            //_dt.Columns.Add( COL_FREPRTEXPORT_SLIPKINDENTRYDIV1, typeof( int ) );		// 伝票種別登録区分1(見積)
            //_dt.Columns.Add( COL_FREPRTEXPORT_SLIPKINDENTRYDIV2, typeof( int ) );		// 伝票種別登録区分2(受注)
            //_dt.Columns.Add( COL_FREPRTEXPORT_SLIPKINDENTRYDIV3, typeof( int ) );		// 伝票種別登録区分3(貸出)
            //_dt.Columns.Add( COL_FREPRTEXPORT_SLIPKINDENTRYDIV4, typeof( int ) );		// 伝票種別登録区分4(売上)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
            _dt.Columns.Add( COL_FREPRTEXPORT_SLIPKINDENTRYDIV4, typeof( int ) );		// 伝票種別登録区分4(売上)
            _dt.Columns.Add( COL_FREPRTEXPORT_SLIPKINDENTRYDIV2, typeof( int ) );		// 伝票種別登録区分2(受注)
            _dt.Columns.Add( COL_FREPRTEXPORT_SLIPKINDENTRYDIV3, typeof( int ) );		// 伝票種別登録区分3(貸出)
            _dt.Columns.Add( COL_FREPRTEXPORT_SLIPKINDENTRYDIV1, typeof( int ) );		// 伝票種別登録区分1(見積)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
			_dt.Columns.Add(COL_FREPRTEXPORT_IMPORTEDFLG,			typeof(int));		// インポート済みフラグ
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
            _dt.Columns.Add( COL_FREPRTEXPORT_FREEPRTPPRITEMGRPCD, typeof( int ) );		// 印刷項目グループコード
            _dt.Columns.Add( COL_FREPRTEXPORT_FREEPRTPPRSPPRPSECD, typeof( int ) );		// 特殊用途コード
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD

			// Gridにバインド
			this.gridExportDataSelect.DataSource = _dt;
		}

		/// <summary>
		/// バインドデータ作成処理
		/// </summary>
		/// <param name="frePrtExportList">自由帳票ExportデータList</param>
		/// <remarks>
		/// <br>Note		: 自由帳票ExportデータよりGridへのバインド情報を作成します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void CreateBindData(List<FrePrtExport> frePrtExportList)
		{
			foreach (FrePrtExport frePrtExport in frePrtExportList)
			{
				DataRow dr = _dt.NewRow();
				foreach (DataColumn col in _dt.Columns)
				{
					PropertyInfo propInfo = typeof(FrePrtExport).GetProperty(col.ColumnName);
					if (propInfo != null)
						dr[col.ColumnName] = propInfo.GetValue(frePrtExport, null);
				}
				dr[COL_FREPRTEXPORT_IMPORTEDFLG] = 0;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                dr[COL_FREPRTEXPORT_OUTPUTFORMFILENAME_ORG] = dr[COL_FREPRTEXPORT_OUTPUTFORMFILENAME];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
				_dt.Rows.Add(dr);
			}
		}

		/// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <param name="message">NG時のメッセージ</param>
		/// <param name="control">NGのコントロール</param>
		/// <param name="rowIndex">NG時の行インデック</param>
		/// <param name="columnName">NG時の列名称</param>
		/// <returns>チェック結果</returns>
		/// <remarks>
		/// <br>Note		: 画面内容の入力チェックを行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private bool InputCheck(out string message, out Control control, out int rowIndex, out string columnName)
		{
			message		= string.Empty;
			control		= null;
			rowIndex	= -1;
			columnName	= string.Empty;

			if (string.IsNullOrEmpty(this.tedEnterpriseCode.Text))
			{
				message	= "企業コードを入力してください。";
				control	= this.tedEnterpriseCode;
				return false;
			}

			DataRow[] drArray = _dt.Select(COL_FREPRTEXPORT_EXTRACTIONITDEDFLG + "=1");
			if (drArray == null || drArray.Length == 0)
			{
				message		= "印字位置情報を選択してください。";
				control		= this.gridExportDataSelect;
				rowIndex	= this.gridExportDataSelect.ActiveRow.Index;
				columnName	= COL_FREPRTEXPORT_EXTRACTIONITDEDFLG;
				return false;
			}
			return true;
		}

		/// <summary>
		/// データ格納処理（Toデータアクセスクラス）
		/// </summary>
		/// <remarks>
		/// <br>Note		: 入力情報をデータアクセスクラスにセットします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void SetDataToAccessClass()
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
            _exchangeDic = new Dictionary<string, string>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD

			foreach (DataRow dr in _dt.Rows)
			{
				FrePrtExport frePrtExport =
					_frePrtPSetImportAcs.FrePrtExportList.Find(
						delegate(FrePrtExport wkFrePrtExport)
						{
							if (wkFrePrtExport.EnterpriseCode == dr[COL_FREPRTEXPORT_ENTERPRISECODE].ToString() &&
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                                //wkFrePrtExport.OutputFormFileName == dr[COL_FREPRTEXPORT_OUTPUTFORMFILENAME].ToString() &&
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                wkFrePrtExport.OutputFormFileName == dr[COL_FREPRTEXPORT_OUTPUTFORMFILENAME_ORG].ToString() &&
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
								wkFrePrtExport.UserPrtPprIdDerivNo == (int)dr[COL_FREPRTEXPORT_USERPRTPPRIDDERIVNO])
								return true;
							else
								return false;
						}
					);
				if (frePrtExport != null)
				{
					foreach (DataColumn col in _dt.Columns)
					{
						PropertyInfo propInfo = typeof(FrePrtExport).GetProperty(col.ColumnName);
						if (propInfo != null)
							propInfo.SetValue(frePrtExport, dr[col.ColumnName], null);
					}
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/01 DEL
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                    //if ( !_exchangeDic.ContainsKey( dr[COL_FREPRTEXPORT_OUTPUTFORMFILENAME_ORG].ToString() ) )
                    //{
                    //    // 変換前→変換後のディクショナリ
                    //    _exchangeDic.Add( dr[COL_FREPRTEXPORT_OUTPUTFORMFILENAME_ORG].ToString(), dr[COL_FREPRTEXPORT_OUTPUTFORMFILENAME].ToString() );
                    //}
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/01 DEL
				}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/01 ADD
                if ( dr[COL_FREPRTEXPORT_OUTPUTFORMFILENAME_ORG].ToString() != dr[COL_FREPRTEXPORT_OUTPUTFORMFILENAME].ToString() )
                {
                    // 変換前→変換後のディクショナリ
                    _exchangeDic.Add( dr[COL_FREPRTEXPORT_OUTPUTFORMFILENAME_ORG].ToString(), dr[COL_FREPRTEXPORT_OUTPUTFORMFILENAME].ToString() );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/01 ADD
			}
		}

		/// <summary>
		/// Export処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 選択印字位置データのExportを行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void ImportProc()
		{
			string	message;
			Control	control;
			int		rowIndex;
			string	columnName;
			// 入力チェック
			if (InputCheck(out message, out control, out rowIndex, out columnName))
			{
				string filePath = string.Empty;

				// 画面情報をアクセスクラス内のデータに反映
				SetDataToAccessClass();

				int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

				// 共通処理中画面
				SFCMN00299CA waitForm = new SFCMN00299CA();
				waitForm.DispCancelButton	= false;
				waitForm.Title				= "インポート中";
				waitForm.Message			= "自由帳票印字位置のインポート中です．．．";
				try
				{
					waitForm.Show();

					string enterpriseCode		= this.tedEnterpriseCode.Text;
					string exportFileDirectory	= Path.GetDirectoryName(_exportFilePath);
					// インポート処理
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                    //status = _frePrtPSetImportAcs.Import(enterpriseCode, exportFileDirectory);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                    status = _frePrtPSetImportAcs.Import( enterpriseCode, exportFileDirectory, _exchangeDic );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
				}
				finally
				{
					waitForm.Close();
				}

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					message = "インポート処理が終了しました。";
					TMsgDisp.Show(
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_INFO,		// エラーレベル
						Program.ctASSEMBLY_ID,				// アセンブリＩＤまたはクラスＩＤ
						message,							// 表示するメッセージ 
						0,									// ステータス値
						MessageBoxButtons.OK);				// 表示するボタン
				}
				else
				{
					TMsgDisp.Show(
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
						Program.ctASSEMBLY_ID,				// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"ImportProc",						// メソッド名称
						TMsgDisp.OPE_INSERT,				// 処理種別
						_frePrtPSetImportAcs.ErrorMessage,	// 表示するメッセージ 
						status,								// ステータス値
						null,
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// ボタンの初期フォーカス
				}
			}
			else
			{
				TMsgDisp.Show(
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_INFO,		// エラーレベル
					Program.ctASSEMBLY_ID,				// アセンブリＩＤまたはクラスＩＤ
					message,							// 表示するメッセージ 
					0,									// ステータス値
					MessageBoxButtons.OK);				// 表示するボタン

				control.Focus();
				if (control is UltraGrid)
					((UltraGrid)control).Rows[rowIndex].Cells[columnName].Activate();
			}
		}

		/// <summary>
		/// ExportファイルOpen処理
		/// </summary>
		/// <returns>ステータス</returns>
		private int OpenExportFileProc()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/11 ADD
            this.openFileDialog.FileName = FrePrtExport.ctExportFileName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/11 ADD
			this.openFileDialog.Filter = "エクスポートファイル(" + FrePrtExport.ctExportFileName + ")|" + FrePrtExport.ctExportFileName;
			DialogResult dlgRet = this.openFileDialog.ShowDialog();
			if (dlgRet == DialogResult.OK)
			{
				_dt.Rows.Clear();
				_exportFilePath = this.openFileDialog.FileName;
			
				status = ReadProc();
			}

			return status;
		}

		/// <summary>
		/// Search処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: Exportファイルの読込を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private int ReadProc()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				status = _frePrtPSetImportAcs.ReadExportFile(_exportFilePath);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						CreateBindData(_frePrtPSetImportAcs.FrePrtExportList);
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					{
						TMsgDisp.Show(
							this,								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
							Program.ctASSEMBLY_ID,				// アセンブリＩＤまたはクラスＩＤ
							_frePrtPSetImportAcs.ErrorMessage,	// 表示するメッセージ 
							0,									// ステータス値
							MessageBoxButtons.OK);				// 表示するボタン
						break;
					}
					default:
					{
						TMsgDisp.Show(this,
							emErrorLevel.ERR_LEVEL_STOPDISP,
							Program.ctASSEMBLY_ID,
							this.Text,
							"ReadProc",
							TMsgDisp.OPE_INIT,
							_frePrtPSetImportAcs.ErrorMessage,
							status,
							null,
							MessageBoxButtons.OK,
							MessageBoxDefaultButton.Button1);
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				string message = "自由帳票エクスポートファイル読込処理にて例外が発生しました。"
					+ Environment.NewLine + ex.Message;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, Program.ctASSEMBLY_ID
					, this.Text
					, "ReadProc"
					, TMsgDisp.OPE_INIT
					, message
					, status
					, null
					, MessageBoxButtons.OK
					, MessageBoxDefaultButton.Button1);
			}

			return status;
		}
		#endregion

		#region Event
		/// <summary>
		/// 自由帳票Exportイベント
		/// </summary>
		/// <param name="status">ステータス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <param name="frePrtExport">自由帳票Exportクラス</param>
		/// <remarks>
		/// <br>Note		: 自由帳票印字位置設定がExportされる度に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
        //private void FrePrtPSetImportAcs_FrePrtPSetImported(int status, string errMsg, FrePrtExport frePrtExport)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
        private void FrePrtPSetImportAcs_FrePrtPSetImported( int status, string errMsg, FrePrtExport frePrtExport, bool newWrite, List<int> slipKindList )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
		{
			string filter = COL_FREPRTEXPORT_ENTERPRISECODE + "='" + frePrtExport.EnterpriseCode + "'"
				+ " AND " + COL_FREPRTEXPORT_OUTPUTFORMFILENAME + "='" + frePrtExport.OutputFormFileName + "'"
				+ " AND " + COL_FREPRTEXPORT_USERPRTPPRIDDERIVNO + "=" + frePrtExport.UserPrtPprIdDerivNo;
			DataRow[] drArray = _dt.Select(filter);
			if (drArray != null && drArray.Length > 0)
			{
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                    //drArray[0][COL_FREPRTEXPORT_IMPORTEDFLG] = 1;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                    if ( newWrite )
                    {
                        // 追加
                        drArray[0][COL_FREPRTEXPORT_IMPORTEDFLG] = 2;
                    }
                    else
                    {
                        // 更新
                        drArray[0][COL_FREPRTEXPORT_IMPORTEDFLG] = 3;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
				}
				else
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                    //drArray[0][COL_FREPRTEXPORT_IMPORTEDFLG] = 2;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                    // 失敗
                    drArray[0][COL_FREPRTEXPORT_IMPORTEDFLG] = 1;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
					TMsgDisp.Show(this
						, emErrorLevel.ERR_LEVEL_NODISP
						, Program.ctASSEMBLY_ID
						, this.Text
						, "FrePrtPSetImportAcs_FrePrtPSetImported"
						, TMsgDisp.OPE_INSERT
						, errMsg
						, status
						, null
						, MessageBoxButtons.OK
						, MessageBoxDefaultButton.Button1);
				}
			}
			this.gridExportDataSelect.Refresh();
		}

		/// <summary>
		/// フォームShownイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォームが最初に表示された時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void SFANL08170UA_Shown(object sender, EventArgs e)
		{
			this.tedEnterpriseCode.Text = LoginInfoAcquisition.EnterpriseCode;
			this.tedEnterpriseCode.SelectAll();

			if (OpenExportFileProc() != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				this.Close();
		}

		/// <summary>
		/// ツールバークリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ツールバーがクリックされた時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
		{
			this.gridExportDataSelect.PerformAction(UltraGridAction.ExitEditMode);

			switch (e.Tool.Key)
			{
				case ctButtonTool_Open:
				{
					OpenExportFileProc();
					break;
				}
				case ctButtonTool_SelectALL:
				{
					foreach (DataRow dr in _dt.Rows)
						dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] = 1;
					break;
				}
				case ctButtonTool_CancelALL:
				{
					foreach (DataRow dr in _dt.Rows)
						dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] = 0;
					break;
				}
			}
		}

		/// <summary>
		/// エクスポートボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: エクスポートボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void ubExport_Click(object sender, EventArgs e)
		{
			ImportProc();
		}

		/// <summary>
		/// キャンセルボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: キャンセルボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void ubCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// グリッド初期化イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: グリッドが初期化された時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void gridExportDataSelect_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
			{
				col.CellActivation = Activation.NoEdit;

				switch (col.Key)
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                    case COL_FREPRTEXPORT_OUTPUTFORMFILENAME:
                    {
                        col.Header.Caption = "帳票ＩＤ";
                        col.Width = 100;
                        col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        col.CellActivation = Activation.AllowEdit;
                        break;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
					case COL_FREPRTEXPORT_IMPORTEDFLG:	// インポート済みフラグ
					{
						ValueList valueList = new ValueList();
						valueList.ValueListItems.Add(0, "　");
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                        //valueList.ValueListItems.Add(1, "○");
                        //valueList.ValueListItems.Add(2, "×");
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                        valueList.ValueListItems.Add( 1, "×" );
                        valueList.ValueListItems.Add( 2, "追加" );
                        valueList.ValueListItems.Add( 3, "更新" );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
						col.ValueList = valueList;

						col.Header.Caption					= "結果";
						col.CellActivation					= Activation.Disabled;
						col.CellAppearance.TextHAlign		= HAlign.Center;
						col.CellAppearance.FontData.Bold	= DefaultableBoolean.True;
						col.Width							= 50;
						break;
					}
					case COL_FREPRTEXPORT_EXTRACTIONITDEDFLG:	// 抽出対象フラグ
					{
						col.Header.Caption	= string.Empty;
						col.Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
						col.Width			= 30;
						break;
					}
					case COL_FREPRTEXPORT_SLIPKINDENTRYDIV1:	// 伝票種別登録区分1
					{
						col.Header.Caption	= "見積";
						col.Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
						col.Width			= 50;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 ADD
                        col.CellActivation = Activation.AllowEdit;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 ADD
						break;
					}
					case COL_FREPRTEXPORT_SLIPKINDENTRYDIV2:	// 伝票種別登録区分2
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
                        //col.Header.Caption	= "指示";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
                        col.Header.Caption = "受注";
                        col.CellActivation = Activation.AllowEdit;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
						col.Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
						col.Width			= 50;
						break;
					}
					case COL_FREPRTEXPORT_SLIPKINDENTRYDIV3:	// 伝票種別登録区分3
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
                        //col.Header.Caption	= "承り";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
                        col.Header.Caption = "貸出";
                        col.CellActivation = Activation.AllowEdit;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
						col.Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
						col.Width			= 50;
						break;
					}
					case COL_FREPRTEXPORT_SLIPKINDENTRYDIV4:	// 伝票種別登録区分4
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
                        //col.Header.Caption	= "納品";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
                        col.Header.Caption = "売上";
                        col.CellActivation = Activation.AllowEdit;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
						col.Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
						col.Width			= 50;
						break;
					}
					case COL_FREPRTEXPORT_SLIPPRTKIND:	// 伝票印刷種別
					{
						ValueList valueList = new ValueList();
						valueList.ValueListItems.Add(0, "設計");
						valueList.ValueListItems.Add(10, "見積");
						valueList.ValueListItems.Add(20, "指示");
						valueList.ValueListItems.Add(21, "承り");
						valueList.ValueListItems.Add(30, "納品");
						col.ValueList = valueList;

						col.Header.Caption	= "使用余白";
						col.Width			= 70;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
                        col.Hidden = true;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
						break;
					}
					case COL_FREPRTEXPORT_DATAINPUTSYSTEM:	// データ入力システム
					{
						ValueList valueList = new ValueList();
						valueList.ValueListItems.Add(0, "共通");
						valueList.ValueListItems.Add(1, "整備");
						valueList.ValueListItems.Add(2, "鈑金");
						valueList.ValueListItems.Add(3, "車販");
						col.ValueList = valueList;

						col.Header.Caption	= "システム";
						col.Width			= 70;
						break;
					}
					case COL_FREPRTEXPORT_PRINTPAPERUSEDIVCD:	// 帳票使用区分
					{
						ValueList valueList = new ValueList();
						valueList.ValueListItems.Add(1, "帳票");
						valueList.ValueListItems.Add(2, "伝票");
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
                        //valueList.ValueListItems.Add(3, "DM一覧表");
                        //valueList.ValueListItems.Add(4, "DMはがき");
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
                        valueList.ValueListItems.Add( 5, "請求書" );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
                        col.ValueList = valueList;

						col.Header.Caption	= "帳票使用区分";
						col.Width			= 70;
						break;
					}
					case COL_FREPRTEXPORT_DISPLAYNAME:	// 出力名称
					{
						col.Header.Caption	= "帳票名称";
						break;
					}
					case COL_FREPRTEXPORT_PRTPPRUSERDERIVNOCMT:	// 帳票ユーザー枝番コメント
					{
						col.Header.Caption	= "コメント";
						break;
					}
					case COL_FREPRTEXPORT_NOTE:	// 備考
					{
						col.Header.Caption	= "備考";
						col.Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
						break;
					}
					default:
					{
						col.Hidden = true;
						break;
					}
				}
			}
		}

		/// <summary>
		/// グリッドAfterRowActivateイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: グリッド上の行がアクティブ化した時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void gridExportDataSelect_AfterRowActivate(object sender, EventArgs e)
		{
			this.gridExportDataSelect.ActiveRow.Selected = true;

			if (this.gridExportDataSelect.ActiveCell == null)
				this.gridExportDataSelect.ActiveRow.Cells[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG].Activate();
		}

		/// <summary>
		/// グリッドInitializeRowイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 行が初期化された時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void gridExportDataSelect_InitializeRow(object sender, InitializeRowEventArgs e)
		{
			// 伝票印刷種別
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
            //if ((int)e.Row.Cells[COL_FREPRTEXPORT_PRINTPAPERUSEDIVCD].Value == 2)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
            if ( (int)e.Row.Cells[COL_FREPRTEXPORT_PRINTPAPERUSEDIVCD].Value == 2 &&
                 (int)e.Row.Cells[COL_FREPRTEXPORT_FREEPRTPPRSPPRPSECD].Value == 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
			{
				e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV1].Activation = Activation.AllowEdit;
				e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV2].Activation = Activation.AllowEdit;
				e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV3].Activation = Activation.AllowEdit;
				e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV4].Activation = Activation.AllowEdit;
			}
			else
			{
				e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV1].Activation = Activation.Disabled;
				e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV2].Activation = Activation.Disabled;
				e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV3].Activation = Activation.Disabled;
				e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV4].Activation = Activation.Disabled;
			}

			// Importフラグ
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
            //if ((int)e.Row.Cells[COL_FREPRTEXPORT_IMPORTEDFLG].Value == 2)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
            if ( (int)e.Row.Cells[COL_FREPRTEXPORT_IMPORTEDFLG].Value == 1 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
				e.Row.Cells[COL_FREPRTEXPORT_IMPORTEDFLG].Appearance.ForeColorDisabled = Color.Red;
			else
				e.Row.Cells[COL_FREPRTEXPORT_IMPORTEDFLG].Appearance.ForeColorDisabled = Color.Blue;

			// データ入力システム
			switch ((int)e.Row.Cells[COL_FREPRTEXPORT_DATAINPUTSYSTEM].Value)
			{
				case 1: e.Row.Cells[COL_FREPRTEXPORT_DATAINPUTSYSTEM].Appearance.ForeColor = Color.Blue; break;
				case 2: e.Row.Cells[COL_FREPRTEXPORT_DATAINPUTSYSTEM].Appearance.ForeColor = Color.Green; break;
				case 3: e.Row.Cells[COL_FREPRTEXPORT_DATAINPUTSYSTEM].Appearance.ForeColor = Color.Purple; break;
				default: e.Row.Cells[COL_FREPRTEXPORT_DATAINPUTSYSTEM].Appearance.ForeColor = Color.Black; break;
			}
		}

		/// <summary>
		/// グリッドクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: グリッド上でクリックされた時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void gridExportDataSelect_MouseClick(object sender, MouseEventArgs e)
		{
			Point lastMouseDown = new Point(e.X, e.Y);
			// UIElementを利用して座標位置のコントロールを取得
			UIElement element = this.gridExportDataSelect.DisplayLayout.UIElement.ElementFromPoint(lastMouseDown);
			// クリックした位置がGridRowの場合のみ処理を行う
			UltraGridCell ultraGridCell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;
			if (ultraGridCell != null && ultraGridCell.Column.Key.Equals(COL_FREPRTEXPORT_EXTRACTIONITDEDFLG))
			{
				DataRow dr = _dt.Rows[ultraGridCell.Row.ListIndex];
				if ((int)dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] == 0)
					dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] = 1;
				else
					dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] = 0;
			}
		}

		/// <summary>
		/// グリッドダブルクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: グリッド上でダブルクリックされた時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void gridExportDataSelect_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Point lastMouseDown = new Point(e.X, e.Y);
			// UIElementを利用して座標位置のコントロールを取得
			UIElement element = this.gridExportDataSelect.DisplayLayout.UIElement.ElementFromPoint(lastMouseDown);
			// クリックした位置がGridRowの場合のみ処理を行う
			UltraGridCell ultraGridCell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;
			if (ultraGridCell != null && ultraGridCell.Column.CellActivation == Activation.NoEdit)
			{
				DataRow dr = _dt.Rows[ultraGridCell.Row.ListIndex];
				if ((int)dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] == 0)
					dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] = 1;
				else
					dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] = 0;
			}
		}

		/// <summary>
		/// グリッドBeforeEnterEditModeイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セルが編集モードに入る前に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void gridExportDataSelect_BeforeEnterEditMode(object sender, CancelEventArgs e)
		{
			// 備考欄はIMEを「ひらがな」で起動する
			if (this.gridExportDataSelect.ActiveCell.Column.Key == COL_FREPRTEXPORT_NOTE)
				this.gridExportDataSelect.ImeMode = ImeMode.Hiragana;
			else
				this.gridExportDataSelect.ImeMode = ImeMode.Disable;
		}

		/// <summary>
		/// グリッドAfterExitEditModeイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セルが編集モードを終了した後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void gridExportDataSelect_AfterExitEditMode(object sender, EventArgs e)
		{
			this.gridExportDataSelect.ImeMode = ImeMode.Disable;
		}

		/// <summary>
		/// グリッドキーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: グリッド上でキーが押下された時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void gridExportDataSelect_KeyDown(object sender, KeyEventArgs e)
		{
			UltraGrid ultraGrid = (UltraGrid)sender;
			if (ultraGrid.ActiveCell != null)
			{
				switch (e.KeyCode)
				{
					case Keys.Space:
					{
						if (ultraGrid.ActiveCell.Column.Key == COL_FREPRTEXPORT_EXTRACTIONITDEDFLG)
						{
							DataRow dr = _dt.Rows[ultraGrid.ActiveCell.Row.ListIndex];
							if ((int)dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] == 0)
								dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] = 1;
							else
								dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] = 0;
						}
						break;
					}
					case Keys.Up:
					{
						switch (ultraGrid.ActiveCell.Column.Style)
						{
							case Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList:
							{
								if (e.Alt)
								{
									ultraGrid.ActiveCell.DroppedDown = true;
									e.Handled = true;
								}
								else if (!ultraGrid.ActiveCell.DroppedDown)
								{
									ultraGrid.PerformAction(UltraGridAction.AboveCell);
									e.Handled = true;
								}
								break;
							}
							default:
							{
								if (ultraGrid.ActiveCell.Row.Index == 0)
									this.tedEnterpriseCode.Focus();
								else
									ultraGrid.PerformAction(UltraGridAction.AboveCell);
								e.Handled = true;
								break;
							}
						}
						break;
					}
					case Keys.Down:
					{
						switch (ultraGrid.ActiveCell.Column.Style)
						{
							case Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList:
							{
								if (e.Alt)
								{
									ultraGrid.ActiveCell.DroppedDown = true;
									e.Handled = true;
								}
								else if (!ultraGrid.ActiveCell.DroppedDown)
								{
									ultraGrid.PerformAction(UltraGridAction.BelowCell);
									e.Handled = true;
								}
								break;
							}
							default:
							{
								if (ultraGrid.ActiveCell.Row.Index == ultraGrid.Rows.Count - 1)
									this.ubImport.Focus();
								else
									ultraGrid.PerformAction(UltraGridAction.BelowCell);
								e.Handled = true;
								break;
							}
						}
						break;
					}
					case Keys.Left:
					{
						if (ultraGrid.ActiveCell.IsInEditMode &&
							ultraGrid.ActiveCell.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
						{
							if (ultraGrid.ActiveCell.SelStart == 0 &&
								ultraGrid.ActiveCell.SelLength == 0)
							{
								ultraGrid.PerformAction(UltraGridAction.PrevCell);
								e.Handled = true;
							}
						}
						else
						{
							ultraGrid.PerformAction(UltraGridAction.PrevCell);
							e.Handled = true;
						}
						break;
					}
					case Keys.Right:
					{
						if (ultraGrid.ActiveCell.IsInEditMode &&
							ultraGrid.ActiveCell.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
						{
							if (ultraGrid.ActiveCell.SelStart == ultraGrid.ActiveCell.Text.Length &&
								ultraGrid.ActiveCell.SelLength == 0)
							{
								ultraGrid.PerformAction(UltraGridAction.NextCell);
								e.Handled = true;
							}
						}
						else
						{
							ultraGrid.PerformAction(UltraGridAction.NextCell);
							e.Handled = true;
						}
						break;
					}
					case Keys.PageUp:
					{
						ultraGrid.PerformAction(UltraGridAction.PageUpCell);
						e.Handled = true;
						break;
					}
					case Keys.PageDown:
					{
						ultraGrid.PerformAction(UltraGridAction.PageDownCell);
						e.Handled = true;
						break;
					}
				}
			}
		}

		/// <summary>
		/// グリッドAfterCellActivateイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セルがアクティブになった後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void gridExportDataSelect_AfterCellActivate(object sender, EventArgs e)
		{
			if (this.gridExportDataSelect.ActiveCell.CanEnterEditMode)
				this.gridExportDataSelect.PerformAction(UltraGridAction.EnterEditMode);
		}

		/// <summary>
		/// グリッドEnterイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールになったときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		private void gridExportDataSelect_Enter(object sender, EventArgs e)
		{
			if (this.gridExportDataSelect.ActiveCell != null)
			{
				if (this.gridExportDataSelect.ActiveCell.Activation == Activation.AllowEdit)
					this.gridExportDataSelect.PerformAction(UltraGridAction.EnterEditMode);
			}
			else if (this.gridExportDataSelect.ActiveRow != null)
			{
				this.gridExportDataSelect.ActiveRow.Cells[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG].Activate();
			}
			else
			{
				if (this.gridExportDataSelect.Rows.Count > 0)
					this.gridExportDataSelect.Rows[0].Cells[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG].Activate();
			}
		}
		#endregion
	}
}