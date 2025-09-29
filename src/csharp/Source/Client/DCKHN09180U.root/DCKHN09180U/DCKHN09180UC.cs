using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{

	/// <summary>
	/// 掛率マスタ一括登録 置換入力画面クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 掛率マスタ一括登録 置換入力画面クラス</br>
	/// <br>Programmer	: 30167 上野　弘貴</br>
	/// <br>Date		: 2008.01.10</br>
	/// </remarks>
	public partial class DCKHN09180UC : Form
	{
		#region Constructor
		/// <summary>
		/// 掛率マスタ一括登録 置換入力画面クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 掛率マスタ一括登録 置換入力画面クラスのインスタンスを作成</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date		: 2008.01.10</br>
		/// <br>Update Note: </br>
		/// </remarks>
		public DCKHN09180UC(ref UltraGrid uGrid)
		{
			InitializeComponent();

			this._rateBlanketAcs = new RateBlanketAcs();
			
			// グリッドデータ取得
			this.DCKHN09180UB_uGrid = uGrid;
			
			//--------------------
			// コンボボックス設定
			//--------------------
			// コンボボックス用データテーブル
			this._dataTableReplaceTarget = new DataTable();
			this._dataTablePriceDiv = new DataTable();
			this._dataTableUnPrcCalcDiv = new DataTable();
			this._dataTableUnPrcFracProcDiv = new DataTable();
			this._dataTableBargainCd = new DataTable();

			DataTblColumnConstComboList(ref this._dataTableReplaceTarget);
			DataTblColumnConstComboList(ref this._dataTablePriceDiv);
			DataTblColumnConstComboList(ref this._dataTableUnPrcCalcDiv);
			DataTblColumnConstComboList(ref this._dataTableUnPrcFracProcDiv);
			DataTblColumnConstComboList(ref this._dataTableBargainCd);
		}
		#endregion
		
		#region Private Member

		private int _target_tComboEditorValue = -1;
		private RateBlanketAcs _rateBlanketAcs = null;
		private UltraGrid DCKHN09180UB_uGrid = null;
		
		//------------------
		// コンボボックス用
		//------------------
		private DataTable _dataTableReplaceTarget = null;		// 置換対象コンボボックス用
		private DataTable _dataTablePriceDiv = null;			// 価格区分コンボボックス用
		private DataTable _dataTableUnPrcCalcDiv = null;		// 単価算出区分コンボボックス用
		private DataTable _dataTableUnPrcFracProcDiv = null;	// 端数処理区分コンボボックス用
		private DataTable _dataTableBargainCd = null;			// 特売区分コンボボックス用

		#endregion Private Member

		#region Private Const Member

		// コンボボックス用
		private const string COMBO_CODE = "COMBO_CODE";
		private const string COMBO_NAME = "COMBO_NAME";
		
		// 項目桁数
		private const int PRICEFL_NUM = 16;
		private const int RATEVAL_NUM = 6;
		private const int UNPRCFRACPROCUNIT_NUM = 12;
		
		#endregion Private Const Member

		/// <summary>
		/// 初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : UIの初期化処理を行う。</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			//------------------------------------
			// コンボボックス用データテーブル設定
			//------------------------------------
			SetComboData(ref RateBlanket._replaceItemSList, ref this._dataTableReplaceTarget);
			SetComboData(ref RateBlanket._priceDivSList, ref this._dataTablePriceDiv);
			SetComboData(ref Rate._unPrcCalcDivTable, ref this._dataTableUnPrcCalcDiv);
			SetComboData(ref Rate._unPrcFracProcDivTable, ref this._dataTableUnPrcFracProcDiv);
			SetComboData(ref RateBlanket._bargainCdSList, ref this._dataTableBargainCd);

			//-----------------------------------
			// コンボボックス設定（固定部分のみ）
			//-----------------------------------
			BindCombo(ref this.Target_tComboEditor, ref this._dataTableReplaceTarget);

			TargetVisibleChange(0);
		}

		/// <summary>
		/// フォーカスコントロールイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null) return;

			switch (e.PrevCtrl.Name)
			{
				case "Target_tComboEditor":
					{
						if (this.Target_tComboEditor != null)
						{
							TargetVisibleChange((Int32)this.Target_tComboEditor.Value);
						}
						break;
					}
			}
		}

		/// <summary>
		/// コンボボックス用データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <param name="wkTable">データテーブル</param>
		/// <br>Note       : コンボボックス用データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void DataTblColumnConstComboList(ref DataTable wkTable)
		{
			wkTable.Columns.Add(COMBO_CODE, typeof(Int32));		// コード
			wkTable.Columns.Add(COMBO_NAME, typeof(string));	// 名称

			// プライマリキー設定
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COMBO_CODE] };
		}

		/// <summary>
		/// コンボボックスデータ設定
		/// </summary>
		/// <remarks>
		/// <param name="sList">ソートリスト</param>
		/// <param name="dataTable">データテーブル</param>
		/// <br>Note       : コンボボックスデータを設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void SetComboData(ref SortedList sList, ref DataTable dataTable)
		{
			try
			{
				foreach (DictionaryEntry de in sList)
				{
					DataRow dr = dataTable.NewRow();

					dr[COMBO_CODE] = (Int32)de.Key;
					dr[COMBO_NAME] = de.Value.ToString();

					dataTable.Rows.Add(dr);
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// コンボボックスバインド
		/// </summary>
		/// <remarks>
		/// <param name="tCombo">TComboEditor</param>
		/// <param name="dataTable">データテーブル</param>
		/// <br>Note       : コンボボックスにバインドします。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void BindCombo(ref TComboEditor tCombo, ref DataTable dataTable)
		{
			tCombo.DisplayMember = COMBO_NAME;
			tCombo.DataSource = dataTable.DefaultView;
		}

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void ScreenClear()
		{
			//------------------
			// 設定データクリア
			//------------------
			// コンボボックス初期化
			this.Target_tComboEditor.Value = RateBlanket._replaceItemSList.GetKey(0);		// 置換コンボボックス
			this._target_tComboEditorValue = -1;

			this.TargetData_tComboEditor.Clear();
			this.TargetData_tDateEdit.Clear();
			this.TargetData_tNedit.Clear();
			
			this.ReplaceData_tComboEditor.Clear();
			this.ReplaceData_tDateEdit.Clear();
			this.ReplaceData_tNedit.Clear();
		}

		/// <summary>
		/// 置換対象表示変更
		/// </summary>
		/// <param name="target">置換対象コード</param>
		/// <remarks>
		/// <br>Note　     : 置換対象の選択を変更したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void TargetVisibleChange(int target)
		{
			if (this._target_tComboEditorValue == target) return;

			// 全て非表示にする
			this.TargetData_tComboEditor.Hide();
			this.TargetData_tDateEdit.Hide();
			this.TargetData_tNedit.Hide();
			
			this.ReplaceData_tComboEditor.Hide();
			this.ReplaceData_tDateEdit.Hide();
			this.ReplaceData_tNedit.Hide();
			
			// 全てクリアする
			this.TargetData_tComboEditor.Clear();
			this.TargetData_tDateEdit.Clear();
			this.TargetData_tNedit.Clear();
			
			this.ReplaceData_tComboEditor.Clear();
			this.ReplaceData_tDateEdit.Clear();
			this.ReplaceData_tNedit.Clear();
			
			switch(target)
			{
				case 0:	// 掛率開始日
					{
						this.TargetData_tDateEdit.Show();
						this.ReplaceData_tDateEdit.Show();
						break;
					}
				case 1:	// 価格
				case 4:	// 掛率
				case 5:	// 端数処理単位
					{
						switch(target)
						{
							case 1:
								{
									this.TargetData_tNedit.MaxLength = PRICEFL_NUM;
									this.TargetData_tNedit.ExtEdit.Column = PRICEFL_NUM;

									this.ReplaceData_tNedit.MaxLength = PRICEFL_NUM;
									this.ReplaceData_tNedit.ExtEdit.Column = PRICEFL_NUM;
									break;
								}
							case 4:
								{
									this.TargetData_tNedit.MaxLength = RATEVAL_NUM;
									this.TargetData_tNedit.ExtEdit.Column = RATEVAL_NUM;

									this.ReplaceData_tNedit.MaxLength = RATEVAL_NUM;
									this.ReplaceData_tNedit.ExtEdit.Column = RATEVAL_NUM;
									break;
								}
							default:
								{
									this.TargetData_tNedit.MaxLength = UNPRCFRACPROCUNIT_NUM;
									this.TargetData_tNedit.ExtEdit.Column = UNPRCFRACPROCUNIT_NUM;

									this.ReplaceData_tNedit.MaxLength = UNPRCFRACPROCUNIT_NUM;
									this.ReplaceData_tNedit.ExtEdit.Column = UNPRCFRACPROCUNIT_NUM;
									break;
								}
						}
						this.TargetData_tNedit.Show();
						this.ReplaceData_tNedit.Show();
						break;
					}
				case 2:	// 価格区分
				case 3:	// 単価算出区分
				case 6:	// 端数処理区分
				case 7:	// 特売区分
					{
						this.TargetData_tComboEditor.BeginUpdate();
						this.ReplaceData_tComboEditor.BeginUpdate();
						
						// 一度クリアする
						this.TargetData_tComboEditor.Items.Clear();
						this.ReplaceData_tComboEditor.Items.Clear();
						
						// バインドクリア
						this.TargetData_tComboEditor.DataSource = "";
						this.ReplaceData_tComboEditor.DataSource = "";
						
						// 再度設定する
						switch(target)
						{
							case 2:
								{
									BindCombo(ref this.TargetData_tComboEditor, ref this._dataTablePriceDiv);
									BindCombo(ref this.ReplaceData_tComboEditor, ref this._dataTablePriceDiv);
									break;
								}
							case 3:
								{
									BindCombo(ref this.TargetData_tComboEditor, ref this._dataTableUnPrcCalcDiv);
									BindCombo(ref this.ReplaceData_tComboEditor, ref this._dataTableUnPrcCalcDiv);
									break;
								}
							case 6:
								{
									BindCombo(ref this.TargetData_tComboEditor, ref this._dataTableUnPrcFracProcDiv);
									BindCombo(ref this.ReplaceData_tComboEditor, ref this._dataTableUnPrcFracProcDiv);
									break;
								}
							default:
								{
									BindCombo(ref this.TargetData_tComboEditor, ref this._dataTableBargainCd);
									BindCombo(ref this.ReplaceData_tComboEditor, ref this._dataTableBargainCd);
									break;
								}
						}

						// 先頭データを表示する
						if (this.TargetData_tComboEditor.Items.Count > 0)
						{
							this.TargetData_tComboEditor.Value = this.TargetData_tComboEditor.Items[0].DataValue;
						}
						if (this.ReplaceData_tComboEditor.Items.Count > 0)
						{
							this.ReplaceData_tComboEditor.Value = this.ReplaceData_tComboEditor.Items[0].DataValue;
						}
						this.TargetData_tComboEditor.EndUpdate();
						this.ReplaceData_tComboEditor.EndUpdate();

						this.TargetData_tComboEditor.Show();
						this.ReplaceData_tComboEditor.Show();
						break;
					}
			}
			
			// 選択した番号を保持
			this._target_tComboEditorValue = target;
		}

		/// <summary>
		/// 置換処理
		/// </summary>
		/// <remarks>
		/// <br>Note　     : 置換処理を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void TargetReplace(int target, out int cnt)
		{
			cnt = 0;	// 置換数
			
			// 置換対象データ検索
			foreach(UltraGridRow uRow in DCKHN09180UB_uGrid.Rows)
			{	
				switch(target)
				{
					//-----------
					// TDateEdit
					//-----------
					case 0:	// 掛率開始日
						{
							if ((DateTime)uRow.Cells[RateBlanketResult.RATESTARTDATE].Value == this.TargetData_tDateEdit.GetDateTime())
							{
								uRow.Cells[RateBlanketResult.RATESTARTDATE].Value = this.ReplaceData_tDateEdit.GetDateTime();
								cnt++;
							}
							break;
						}
					//--------
					// TNedit
					//--------
					case 1:	// 価格
						{
							if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.PRICEFL].Value) == this.TargetData_tNedit.GetValue())
							{
								// 掛率及び端数処理単位が未設定時のみ設定
								if ((RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.RATEVAL].Value) == 0)
									&& (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Value) == 0))
								{
									uRow.Cells[RateBlanketResult.PRICEFL].Value = this.ReplaceData_tNedit.GetValue();
									cnt++;
								}
							}
							break;
						}
					case 4:	// 掛率
						{
							if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.RATEVAL].Value) == this.TargetData_tNedit.GetValue())
							{
								// 価格未設定時のみ設定
								if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.PRICEFL].Value) == 0)
								{
									uRow.Cells[RateBlanketResult.RATEVAL].Value = this.ReplaceData_tNedit.GetValue();
									cnt++;
								}
							}
							break;
						}
					case 5:	// 端数処理単位
						{
							if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Value) == this.TargetData_tNedit.GetValue())
							{
								// 価格未設定時のみ設定
								if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.PRICEFL].Value) == 0)
								{
									uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Value = this.ReplaceData_tNedit.GetValue();
									cnt++;
								}
							}
							break;
						}
					//--------------
					// tComboEditor
					//--------------
					case 2:	// 価格区分
						{
							if (RateBlanketAcs.NullChgInt(uRow.Cells[RateBlanketResult.PRICEDIV].Value) == RateBlanketAcs.NullChgInt(this.TargetData_tComboEditor.Value))
							{
								uRow.Cells[RateBlanketResult.PRICEDIV].Value = RateBlanketAcs.NullChgInt(this.ReplaceData_tComboEditor.Value);
								cnt++;
							}
							break;
						}
					case 3:	// 単価算出区分
						{
							if (RateBlanketAcs.NullChgInt(uRow.Cells[RateBlanketResult.UNITPRCCALCDIV].Value) == RateBlanketAcs.NullChgInt(this.TargetData_tComboEditor.Value))
							{
								// ワークへコピー
								int wkValue = RateBlanketAcs.NullChgInt(uRow.Cells[RateBlanketResult.UNITPRCCALCDIV].Value);
								
								uRow.Cells[RateBlanketResult.UNITPRCCALCDIV].Value = RateBlanketAcs.NullChgInt(this.ReplaceData_tComboEditor.Value);
								cnt++;
								
								// コンボボックスが有効か確認する（テキストが無効の場合、入力したデータを表示する）
								if (uRow.Cells[RateBlanketResult.UNITPRCCALCDIV].Text == RateBlanketAcs.NullChgStr(this.ReplaceData_tComboEditor.Value))
								{
									// 無効なので元に戻す
									uRow.Cells[RateBlanketResult.UNITPRCCALCDIV].Value = wkValue;
									cnt--;
								}
							}
							break;
						}
					case 6:	// 端数処理区分
						{
							if (RateBlanketAcs.NullChgInt(uRow.Cells[RateBlanketResult.UNPRCFRACPROCDIV].Value) == RateBlanketAcs.NullChgInt(this.TargetData_tComboEditor.Value))
							{
								uRow.Cells[RateBlanketResult.UNPRCFRACPROCDIV].Value = RateBlanketAcs.NullChgInt(this.ReplaceData_tComboEditor.Value);
								cnt++;
							}
							break;
						}
					case 7:	// 特売区分
						{
							if (RateBlanketAcs.NullChgInt(uRow.Cells[RateBlanketResult.BARGAINCD].Value) == RateBlanketAcs.NullChgInt(this.TargetData_tComboEditor.Value))
							{
								uRow.Cells[RateBlanketResult.BARGAINCD].Value = RateBlanketAcs.NullChgInt(this.ReplaceData_tComboEditor.Value);
								cnt++;
							}
							break;
						}
				}
			}
		}

		/// <summary>
		/// Target_tComboEditor_SelectionChangeCommitted イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 置換対象が変化したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void Target_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.Target_tComboEditor != null)
			{
				TargetVisibleChange((Int32)this.Target_tComboEditor.Value);
			}
		}

		/// <summary>
		/// 置換ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void Replace_uButton_Click(object sender, EventArgs e)
		{
			int cnt = 0;
			
			// メッセージで取消の確認
			string strMsg = "全て置換します。よろしいですか？";

			// Okなら初回抽出時、保存時のデータに戻す
			DialogResult dlgRes = TMsgDisp.Show(
				emErrorLevel.ERR_LEVEL_INFO,        //エラーレベル
				"DCKHN09180UC",                     //UNIT　ID
				this.Text,                          //プログラム名称
				"置換",		                        //プロセスID
				"",                                 //オペレーション
				strMsg,                             //メッセージ
				0,									//ステータス
				null,								//オブジェクト
				MessageBoxButtons.YesNo,            //ダイアログボタン指定
				MessageBoxDefaultButton.Button1     //ダイアログ初期ボタン指定
				);
			
			if(dlgRes == DialogResult.Yes)
			{
				if (this.Target_tComboEditor != null)
				{
					TargetReplace((int)this.Target_tComboEditor.Value, out cnt);

					// 置換完了メッセージ
					TMsgDisp.Show(this,							// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_INFO,			// エラーレベル
						"DCKHN09180UC",							// アセンブリID
						cnt + "件置換しました。",				// 表示するメッセージ
						0,										// ステータス値
						MessageBoxButtons.OK);					// 表示するボタン
				}
			}
		}

		/// <summary>
		/// 閉じるボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void Cancel_uButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void DCKHN09180UC_Load(object sender, EventArgs e)
		{
			// アイコンを表示する
			ImageList imageList16 = IconResourceManagement.ImageList16;
			ImageList imageList24 = IconResourceManagement.ImageList24;

			// 制御ボタンアイコン
			this.Replace_uButton.ImageList = imageList24;
			this.Replace_uButton.Appearance.Image = Size24_Index.SAVE;
			
			this.Cancel_uButton.ImageList = imageList24;
			this.Cancel_uButton.Appearance.Image = Size24_Index.CLOSE;
			
			// 画面初期化処理
			ScreenInitialSetting();

			// 画面クリア
			ScreenClear();
			
			this.timer_InitialSetFocus.Enabled = true;
		}

		/// <summary>
		/// 初期フォーカス設定タイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
		{
			this.timer_InitialSetFocus.Enabled = false;
			this.Target_tComboEditor.Focus();
		}
	}
}