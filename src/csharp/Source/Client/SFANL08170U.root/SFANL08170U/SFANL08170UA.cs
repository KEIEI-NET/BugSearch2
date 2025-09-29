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
using Infragistics.Win.UltraWinToolTip;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 自由帳票印字位置ExportUIクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票印字位置設定情報のExportを行う為のUI画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.11.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public partial class SFANL08170UA : Form
	{
		#region Const
		// ツールボタン用
		private const string ctButtonTool_SelectALL = "SelectAll_ButtonTool";
		private const string ctButtonTool_CancelALL = "CancelAll_ButtonTool";
		// スキーマ用
		private const string TBL_FREPRTEXPORT = "FrePrtExport";
		private const string COL_FREPRTEXPORT_EXPORTEDFLG			= "ExportedFlg";			// エクスポート済みフラグ
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
		private const string COL_FREPRTEXPORT_ERRORMESSAGE			= "ErrorMessage";			// エラーメッセージ
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
        private const string COL_FREPRTEXPORT_FREEPRTPPRITEMGRPCD   = "FreePrtPprItemGrpCd";    // 自由帳票印刷項目グループコード
        private const string COL_FREPRTEXPORT_FREEPRTPPRSPPRPSECD   = "FreePrtPprSpPrpseCd";    // 自由帳票特殊用途コード
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
		#endregion

		#region PrivateMember
		// --------------------------------------------------------
		// ☆☆☆ 各種アクセスクラス ☆☆☆
		// --------------------------------------------------------
		// 自由帳票Exportアクセスクラス
		private FrePrtPSetExportAcs	_frePrtPSetExportAcs;

		// --------------------------------------------------------
		// ☆☆☆ その他ワーク変数 ☆☆☆
		// --------------------------------------------------------
		// Gridバインド用DataTable
		private DataTable			_dt;
		// Export中フラグ
		private bool				_isInExport;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08170UA()
		{
			InitializeComponent();

			_frePrtPSetExportAcs = new FrePrtPSetExportAcs();
			_frePrtPSetExportAcs.FrePrtPSetExported += new FrePrtPSetExportAcs.FrePrtPSetExportEventHandler(FrePrtPSetExportAcs_FrePrtPSetExported);

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
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void InitializeSetting()
		{
			this.Main_ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
			// 全選択
			ButtonTool selectAllButton = (ButtonTool)this.Main_ToolbarsManager.Tools[ctButtonTool_SelectALL];
			if (selectAllButton != null) selectAllButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLSELECT;
			// 全解除
			ButtonTool cancelAllButton = (ButtonTool)this.Main_ToolbarsManager.Tools[ctButtonTool_CancelALL];
			if (cancelAllButton != null) cancelAllButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
			// エクスポートボタン
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
			//this.ubExport.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.EXPORT];
            this.ubExport.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CSVOUTPUT];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
			// キャンセルボタン
			this.ubCancel.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CLOSE];

			// DataTableのスキーマ設定
			_dt = new DataTable(TBL_FREPRTEXPORT);
			_dt.Columns.Add(COL_FREPRTEXPORT_EXTRACTIONITDEDFLG,	typeof(int));		// 抽出対象フラグ
			_dt.Columns.Add(COL_FREPRTEXPORT_ENTERPRISECODE,		typeof(string));	// 企業コード
			_dt.Columns.Add(COL_FREPRTEXPORT_OUTPUTFORMFILENAME,	typeof(string));	// 出力ファイル名
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
			_dt.Columns.Add(COL_FREPRTEXPORT_EXPORTEDFLG,			typeof(int));		// エクスポート済みフラグ
			_dt.Columns.Add(COL_FREPRTEXPORT_ERRORMESSAGE,			typeof(string));	// エラーメッセージ
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
            _dt.Columns.Add( COL_FREPRTEXPORT_FREEPRTPPRITEMGRPCD, typeof( int ) );     // 自由帳票印刷項目グループコード
            _dt.Columns.Add( COL_FREPRTEXPORT_FREEPRTPPRSPPRPSECD, typeof( int ) );     // 自由帳票特殊項目コード
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
		/// <br>Date		: 2007.11.06</br>
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
				dr[COL_FREPRTEXPORT_EXPORTEDFLG] = 0;
				_dt.Rows.Add(dr);
			}
		}

		/// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <param name="message">NG時のメッセージ</param>
		/// <param name="rowIndex">NG時の行インデック</param>
		/// <param name="columnName">NG時の列名称</param>
		/// <returns>チェック結果</returns>
		/// <remarks>
		/// <br>Note		: 画面内容の入力チェックを行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private bool InputCheck(out string message, out int rowIndex, out string columnName)
		{
			message		= string.Empty;
			rowIndex	= -1;
			columnName	= string.Empty;

			DataRow[] drArray = _dt.Select(COL_FREPRTEXPORT_EXTRACTIONITDEDFLG + "=1");
			if (drArray == null || drArray.Length == 0)
			{
				message		= "印字位置情報を選択してください。";
				rowIndex	= this.gridExportDataSelect.ActiveRow.Index;
				columnName	= COL_FREPRTEXPORT_EXTRACTIONITDEDFLG;
				return false;
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
            //drArray = _dt.Select( COL_FREPRTEXPORT_EXTRACTIONITDEDFLG + "=1 AND " + COL_FREPRTEXPORT_PRINTPAPERUSEDIVCD + "=2" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
            drArray = _dt.Select( COL_FREPRTEXPORT_EXTRACTIONITDEDFLG + "=1 AND " + COL_FREPRTEXPORT_PRINTPAPERUSEDIVCD + "=2 AND " + COL_FREPRTEXPORT_FREEPRTPPRSPPRPSECD + "=0" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
            if ( drArray != null )
            {
                foreach ( DataRow dr in drArray )
                {
                    if ( (int)dr[COL_FREPRTEXPORT_SLIPKINDENTRYDIV1] == 0 &&
                        (int)dr[COL_FREPRTEXPORT_SLIPKINDENTRYDIV2] == 0 &&
                        (int)dr[COL_FREPRTEXPORT_SLIPKINDENTRYDIV3] == 0 &&
                        (int)dr[COL_FREPRTEXPORT_SLIPKINDENTRYDIV4] == 0 )
                    {
                        message = "伝票種別が選択されていません。";
                        rowIndex = this.gridExportDataSelect.Rows.GetRowWithListIndex( _dt.Rows.IndexOf( dr ) ).Index;
                        columnName = COL_FREPRTEXPORT_SLIPKINDENTRYDIV1;
                        return false;
                    }
                }
            }

			return true;
		}

		/// <summary>
		/// データ格納処理（Toデータアクセスクラス）
		/// </summary>
		/// <remarks>
		/// <br>Note		: 入力情報をデータアクセスクラスにセットします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void SetDataToAccessClass()
		{
			foreach (DataRow dr in _dt.Rows)
			{
				FrePrtExport frePrtExport =
					_frePrtPSetExportAcs.FrePrtExportList.Find(
						delegate(FrePrtExport wkFrePrtExport)
						{
							if (wkFrePrtExport.EnterpriseCode == dr[COL_FREPRTEXPORT_ENTERPRISECODE].ToString() &&
								wkFrePrtExport.OutputFormFileName == dr[COL_FREPRTEXPORT_OUTPUTFORMFILENAME].ToString() &&
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
				}
			}
		}

		/// <summary>
		/// Export処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 選択印字位置データのExportを行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void ExportProc()
		{
			_isInExport = true;

			try
			{
				string message;
				int rowIndex;
				string columnName;
				// 入力チェック
				if (InputCheck(out message, out rowIndex, out columnName))
				{
					string filePath = string.Empty;

					DialogResult dlgRet = DialogResult.Retry;
					while (dlgRet == DialogResult.Retry)
					{
						dlgRet = this.folderBrowserDialog.ShowDialog();
						if (dlgRet == DialogResult.OK)
						{
							filePath = Path.Combine(this.folderBrowserDialog.SelectedPath, FrePrtExport.ctExportFileName);
							// 同名ファイルが存在する場合は上書き確認
							if (File.Exists(filePath))
							{
								message = "指定されたディレクトリには、既にエクスポートファイルが存在します。"
									+ Environment.NewLine + Environment.NewLine
									+ "現在のエクスポートファイルに 上書き 又は 追加 しますがよろしいですか？";
								dlgRet = TMsgDisp.Show(
									emErrorLevel.ERR_LEVEL_QUESTION,
									Program.ctASSEMBLY_ID,
									message,
									0,
									MessageBoxButtons.OKCancel);

								// 上書きしない場合はディレクトリの選択からやり直し
								if (dlgRet != DialogResult.OK)
									dlgRet = DialogResult.Retry;
							}
						}
						else
						{
							return;
						}
					}

					// 画面情報をアクセスクラス内のデータに反映
					SetDataToAccessClass();

					int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

					// 共通処理中画面
					SFCMN00299CA waitForm = new SFCMN00299CA();
					waitForm.DispCancelButton = false;
					waitForm.Title = "エクスポート中";
					waitForm.Message = "自由帳票印字位置のエクスポート中です．．．";
					try
					{
						waitForm.Show();

						// エクスポート処理
						status = _frePrtPSetExportAcs.Export(filePath);
					}
					finally
					{
						waitForm.Close();
					}

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						message = "エクスポート処理が終了しました。"
							+ Environment.NewLine + Environment.NewLine
							+ "出力先 : " + filePath;
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
							"ExportProc",						// メソッド名称
							TMsgDisp.OPE_INSERT,				// 処理種別
							_frePrtPSetExportAcs.ErrorMessage,	// 表示するメッセージ 
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

					this.gridExportDataSelect.Focus();
					this.gridExportDataSelect.Rows[rowIndex].Cells[columnName].Activate();
				}
			}
			finally
			{
				_isInExport = false;
			}
		}

		/// <summary>
		/// Search処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 選択印字位置データのSearchを行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private int SearchProc()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				status = _frePrtPSetExportAcs.Search(LoginInfoAcquisition.EnterpriseCode);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						foreach (FrePrtExport frePrtExport in _frePrtPSetExportAcs.FrePrtExportList)
						{
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
                            //if (frePrtExport.PrintPaperUseDivcd == 2)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
                            if (frePrtExport.PrintPaperUseDivcd == 2 && frePrtExport.FreePrtPprSpPrpseCd == 0)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
							{
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                                //frePrtExport.SlipKindEntryDiv1 = 1;
                                //frePrtExport.SlipKindEntryDiv2 = 1;
                                //frePrtExport.SlipKindEntryDiv3 = 1;
                                //frePrtExport.SlipKindEntryDiv4 = 1;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                foreach ( SlipPrtSet slipPrtSet in _frePrtPSetExportAcs.SlipPrtSetList )
                                {
                                    int derivNo;
                                    try
                                    {
                                        derivNo = Int32.Parse(slipPrtSet.SpecialPurpose2);
                                    }
                                    catch
                                    {
                                        derivNo = 0;
                                    }

                                    if ( slipPrtSet.OutputFormFileName == frePrtExport.OutputFormFileName &&
                                         derivNo == frePrtExport.UserPrtPprIdDerivNo )
                                    {
                                        switch ( slipPrtSet.SlipPrtKind )
                                        {
                                            case 30:
                                                // 売上
                                                frePrtExport.SlipKindEntryDiv4 = 1;
                                                break;
                                            case 120:
                                                // 受注
                                                frePrtExport.SlipKindEntryDiv2 = 1;
                                                break;
                                            case 130:
                                                // 貸出
                                                frePrtExport.SlipKindEntryDiv3 = 1;
                                                break;
                                            case 140:
                                                // 見積
                                                frePrtExport.SlipKindEntryDiv1 = 1;
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
							}
						}

						CreateBindData(_frePrtPSetExportAcs.FrePrtExportList);
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						string message = "自由帳票印字位置情報がありません。"
							+ Environment.NewLine + "自由帳票印字位置情報を登録してください。";
						TMsgDisp.Show(
							this,								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
							Program.ctASSEMBLY_ID,				// アセンブリＩＤまたはクラスＩＤ
							message,							// 表示するメッセージ 
							0,									// ステータス値
							MessageBoxButtons.OK);				// 表示するボタン
						break;
					}
					default:
					{
						TMsgDisp.Show(this
							, emErrorLevel.ERR_LEVEL_STOPDISP
							, Program.ctASSEMBLY_ID
							, this.Text
							, "SearchProc"
							, TMsgDisp.OPE_INIT
							, _frePrtPSetExportAcs.ErrorMessage
							, status
							, null
							, MessageBoxButtons.OK
							, MessageBoxDefaultButton.Button1);
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				string message = "自由帳票印字位置設定データ検索処理にて例外が発生しました。"
					+ Environment.NewLine + ex.Message;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, Program.ctASSEMBLY_ID
					, this.Text
					, "SearchProc"
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
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void FrePrtPSetExportAcs_FrePrtPSetExported(int status, string errMsg, FrePrtExport frePrtExport)
		{
			string filter = COL_FREPRTEXPORT_ENTERPRISECODE + "='" + frePrtExport.EnterpriseCode + "'"
				+ " AND " + COL_FREPRTEXPORT_OUTPUTFORMFILENAME + "='" + frePrtExport.OutputFormFileName + "'"
				+ " AND " + COL_FREPRTEXPORT_USERPRTPPRIDDERIVNO + "=" + frePrtExport.UserPrtPprIdDerivNo;
			DataRow[] drArray = _dt.Select(filter);
			if (drArray != null && drArray.Length > 0)
			{
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					drArray[0][COL_FREPRTEXPORT_EXPORTEDFLG]	= 1;
					drArray[0][COL_FREPRTEXPORT_ERRORMESSAGE]	= string.Empty;
				}
				else
				{
					drArray[0][COL_FREPRTEXPORT_EXPORTEDFLG]	= 2;
					drArray[0][COL_FREPRTEXPORT_ERRORMESSAGE]	= errMsg;
					TMsgDisp.Show(this
						, emErrorLevel.ERR_LEVEL_NODISP
						, Program.ctASSEMBLY_ID
						, this.Text
						, "FrePrtPSetExportAcs_FrePrtPSetExported"
						, TMsgDisp.OPE_INSERT
						, errMsg
						, status
						, null
						, MessageBoxButtons.OK
						, MessageBoxDefaultButton.Button1);
				}
				UltraGridRow ultraGridRow = this.gridExportDataSelect.DisplayLayout.Rows.GetRowWithListIndex(_dt.Rows.IndexOf(drArray[0]));
				this.gridExportDataSelect.DisplayLayout.RowScrollRegions[0].ScrollRowIntoView(ultraGridRow);
				ultraGridRow.Activate();
			}
			this.Refresh();
		}

		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void SFANL08170UA_Load(object sender, EventArgs e)
		{
			if (SearchProc() != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				this.Close();
		}

		/// <summary>
		/// フォームShownイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォームが最初に表示された時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void SFANL08170UA_Shown(object sender, EventArgs e)
		{
			this.gridExportDataSelect.Focus();
		}

		/// <summary>
		/// ツールバークリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ツールバーがクリックされた時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
		{
			if (_isInExport) return;

			this.gridExportDataSelect.PerformAction(UltraGridAction.ExitEditMode);

			switch (e.Tool.Key)
			{
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
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void ubExport_Click(object sender, EventArgs e)
		{
			if (_isInExport) return;

			ExportProc();
		}

		/// <summary>
		/// キャンセルボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: キャンセルボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void ubCancel_Click(object sender, EventArgs e)
		{
			if (_isInExport) return;

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
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void gridExportDataSelect_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
			{
				switch (col.Key)
				{
					case COL_FREPRTEXPORT_EXPORTEDFLG:	// エクスポート済みフラグ
					{
						ValueList valueList = new ValueList();
						valueList.ValueListItems.Add(0, "　");
						valueList.ValueListItems.Add(1, "○");
						valueList.ValueListItems.Add(2, "×");
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
						col.CellActivation	= Activation.NoEdit;
						col.Width			= 30;
						break;
					}
					case COL_FREPRTEXPORT_SLIPKINDENTRYDIV1:	// 伝票種別登録区分1
					{
						col.Header.Caption	= "見積";
						col.Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
						col.Width			= 50;
						break;
					}
					case COL_FREPRTEXPORT_SLIPKINDENTRYDIV2:	// 伝票種別登録区分2
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
                        //col.Header.Caption	= "指示";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
                        col.Header.Caption	= "受注";
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
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
						col.Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
						col.Width			= 50;
                        break;
					}
					case COL_FREPRTEXPORT_SLIPPRTKIND:	// 伝票印刷種別
					{
						col.Header.Caption	= "使用余白";
						col.Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
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
						col.CellActivation	= Activation.NoEdit;
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
						col.CellActivation	= Activation.NoEdit;
						col.Width			= 70;
						break;
					}
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                    case COL_FREPRTEXPORT_OUTPUTFORMFILENAME: // 帳票ＩＤ
                    {
                        col.Header.Caption = "帳票ＩＤ";
                        col.CellActivation = Activation.NoEdit;
                        break;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
					case COL_FREPRTEXPORT_DISPLAYNAME:	// 出力名称
					{
						col.Header.Caption	= "帳票名称";
						col.CellActivation	= Activation.NoEdit;
						break;
					}
					case COL_FREPRTEXPORT_PRTPPRUSERDERIVNOCMT:	// 帳票ユーザー枝番コメント
					{
						col.Header.Caption	= "コメント";
						col.CellActivation	= Activation.NoEdit;
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
		/// <br>Date		: 2007.11.06</br>
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
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void gridExportDataSelect_InitializeRow(object sender, InitializeRowEventArgs e)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
            //// 伝票印刷種別
            //ValueList valueList = new ValueList();
            //valueList.ValueListItems.Add(0, "設計");
            //e.Row.Cells[COL_FREPRTEXPORT_SLIPPRTKIND].ValueList = valueList;
            //if ((int)e.Row.Cells[COL_FREPRTEXPORT_PRINTPAPERUSEDIVCD].Value == 2)
            //{
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV1].Activation	= Activation.AllowEdit;
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV2].Activation	= Activation.AllowEdit;
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV3].Activation	= Activation.AllowEdit;
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV4].Activation	= Activation.AllowEdit;
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPPRTKIND].Activation		= Activation.AllowEdit;

            //    // 企業コード
            //    string enterpriseCode		= e.Row.Cells[COL_FREPRTEXPORT_ENTERPRISECODE].Value.ToString();
            //    // データ入力システム	
            //    int dataInputSystem			= (int)e.Row.Cells[COL_FREPRTEXPORT_DATAINPUTSYSTEM].Value;
            //    // 伝票印刷設定用帳票ID
            //    string slipPrtSetPaperId	= e.Row.Cells[COL_FREPRTEXPORT_OUTPUTFORMFILENAME].Value.ToString() + e.Row.Cells[COL_FREPRTEXPORT_USERPRTPPRIDDERIVNO].Value.ToString();
            //    List<SlipPrtSet> slipPrtSetList
            //        = _frePrtPSetExportAcs.SlipPrtSetList.FindAll(
            //            delegate(SlipPrtSet slipPrtSet)
            //            {
            //                if (slipPrtSet.EnterpriseCode == enterpriseCode &&
            //                    slipPrtSet.DataInputSystem == dataInputSystem &&
            //                    slipPrtSet.SlipPrtSetPaperId == slipPrtSetPaperId)
            //                    return true;
            //                else
            //                    return false;
            //            }
            //        );
            //    if (slipPrtSetList != null && slipPrtSetList.Count > 0)
            //    {
            //        foreach (SlipPrtSet slipPrtSet in slipPrtSetList)
            //        {
            //            if (slipPrtSet.SlipPrtKind == 10)
            //                valueList.ValueListItems.Add(slipPrtSet.SlipPrtKind, "見積");
            //            else if (slipPrtSet.SlipPrtKind == 20)
            //                valueList.ValueListItems.Add(slipPrtSet.SlipPrtKind, "指示");
            //            else if (slipPrtSet.SlipPrtKind == 21)
            //                valueList.ValueListItems.Add(slipPrtSet.SlipPrtKind, "承り");
            //            else if (slipPrtSet.SlipPrtKind == 30)
            //                valueList.ValueListItems.Add(slipPrtSet.SlipPrtKind, "納品");
            //        }
            //    }
            //}
            //else
            //{
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV1].Activation	= Activation.Disabled;
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV2].Activation	= Activation.Disabled;
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV3].Activation	= Activation.Disabled;
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV4].Activation	= Activation.Disabled;
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPPRTKIND].Activation		= Activation.NoEdit;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
            if ( (int)e.Row.Cells[COL_FREPRTEXPORT_PRINTPAPERUSEDIVCD].Value == 2 &&
                (int)e.Row.Cells[COL_FREPRTEXPORT_FREEPRTPPRSPPRPSECD].Value == 0 )
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
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD

			// Exportフラグ
			if ((int)e.Row.Cells[COL_FREPRTEXPORT_EXPORTEDFLG].Value == 2)
				e.Row.Cells[COL_FREPRTEXPORT_EXPORTEDFLG].Appearance.ForeColorDisabled = Color.Red;
			else
				e.Row.Cells[COL_FREPRTEXPORT_EXPORTEDFLG].Appearance.ForeColorDisabled = Color.Blue;

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
		/// <br>Date		: 2007.11.06</br>
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
		/// <br>Date		: 2007.11.06</br>
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
		/// <br>Date		: 2007.11.06</br>
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
		/// <br>Date		: 2007.11.06</br>
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
		/// <br>Date		: 2007.11.06</br>
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
									this.ubExport.Focus();
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
		/// <br>Date		: 2007.11.06</br>
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
		/// <br>Date		: 2007.11.06</br>
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

		/// <summary>
		/// MouseEnterElementイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: マウスが要素の四角形に入った時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void gridExportDataSelect_MouseEnterElement(object sender, UIElementEventArgs e)
		{
			object objContextRow	= e.Element.GetContext(typeof(UltraGridRow));
			if (objContextRow != null)
			{
				DataRow dr = _dt.Rows[((UltraGridRow)objContextRow).ListIndex];
				if ((int)dr[COL_FREPRTEXPORT_EXPORTEDFLG] == 2)
				{
					UltraToolTipInfo ultraToolTipInfo = new UltraToolTipInfo();
					ultraToolTipInfo.ToolTipImage		= ToolTipImage.Error;
					ultraToolTipInfo.ToolTipTitle		= "エラー情報";
					ultraToolTipInfo.ToolTipText		= dr[COL_FREPRTEXPORT_ERRORMESSAGE].ToString();

					this.uttmGridToolTip.SetUltraToolTip(this.gridExportDataSelect, ultraToolTipInfo);
					this.uttmGridToolTip.Enabled = true;
				}
			}
		}

		/// <summary>
		/// MouseLeaveElementイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: マウスが要素の四角形から離れた時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void gridExportDataSelect_MouseLeaveElement(object sender, UIElementEventArgs e)
		{
			// ツールチップを非表示にする
			this.uttmGridToolTip.HideToolTip();
			this.uttmGridToolTip.Enabled = false;
		}
		#endregion
	}
}