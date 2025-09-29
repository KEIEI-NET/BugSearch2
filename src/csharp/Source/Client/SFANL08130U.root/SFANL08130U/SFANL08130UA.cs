using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 自由帳票検索条件設定UI
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票検索条件画面情報用マスメンです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.03.22</br>
	/// <br></br>
	/// <br>UpdateNote	: 2008.03.19 22024 寺坂誉志</br>
	/// <br>			: １．帳票の抽出条件に日付系項目が含まれない状態での確定を不可とする。</br>
	/// <br>			: 2008.04.04 22024 寺坂誉志</br>
	/// <br>			: １．品管№2008P058-5-005010-01 「×」押下時に入力チェックがかからない不具合修正</br>
	/// <br>			: 2008.04.07 22024 寺坂誉志</br>
	/// <br>			: １．品管№2008P058-2-001005-02 2008.04.04対応追加分</br>
	/// <br>			: 　　表示順位等を編集状態にて入力チェックがかからない不具合修正</br>
	/// </remarks>
	public partial class SFANL08130UA : Form
	{
		#region PrivateMember
		// 抽出条件明細LIST
		private List<FrePExCndD>	_frePExCndDList;
		// 有効抽出条件LIST
		private List<FrePprECnd>	_frePprECndList;
		// 抽出条件設定LIST初期値
		private List<FrePprECnd>	_buf_frePprECndList;
		// 印字項目設定LIST
		private List<PrtItemSetWork> _prtItemSetList;
		// バインドデータテーブル
		private DataTable			_dt;
		// 変更チェック用バッファ
		private string				_bufText;
		private int					_bufCode;
////////////////////////////////////////////// 2008.04.04 TERASAKA ADD STA //
		private bool				_cancelCloseCheck;
// 2008.04.04 TERASAKA ADD END //////////////////////////////////////////////
		#endregion

		#region Const
		// アセンブリID
		private const string ctASSEMBLY_ID = "SFANL08130U";
		// ツールボタン用
		private const string ctButtonTool_Decide = "Decide_ButtonTool";
		private const string ctButtonTool_Return = "Return_ButtonTool";
		private const string ctButtonTool_Cancel = "Cancel_ButtonTool";
		// スキーマ用
		private const string TBL_FREPPRECND_SETTING		= "FrePprECndSetting";
		private const string COL_USEDFLG				= "UsedFlg";				// 使用フラグ
		private const string COL_DISPLAYORDER			= "DisplayOrder";			// 表示順位
		private const string COL_EXTRACONDITIONTITLE	= "ExtraConditionTitle";	// 抽出条件タイトル
		private const string COL_FREPRTPPREXTRACONDCD	= "FrePrtPprExtraCondCd";	// 自由帳票抽出条件枝番
		private const string COL_FREPPRECND				= "FrePprECnd";				// 自由帳票抽出条件マスタ
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08130UA()
		{
			InitializeComponent();

			_frePprECndList		= new List<FrePprECnd>();
			_buf_frePprECndList = new List<FrePprECnd>();

			InitializeSetting();
		}
		#endregion

		#region Property
		/// <summary>使用する抽出条件マスタ</summary>
		public List<FrePprECnd> UseFrePprECndList
		{
			get { return _frePprECndList; }
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// 自由帳票検索条件設定画面表示処理
		/// </summary>
		/// <param name="frePprECndList">自由帳票抽出条件設定LIST</param>
		/// <param name="frePExCndDList">自由帳票抽出条件明細LIST</param>
		/// <param name="prtItemSetList">印字項目設定LIST</param>
		/// <returns>ダイアログリザルト</returns>
		/// <remarks>
		/// <br>Note		: 自由帳票検索条件画面を起動します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		public DialogResult ShowFrePprECndSetting(List<FrePprECnd> frePprECndList, List<FrePExCndD> frePExCndDList, List<PrtItemSetWork> prtItemSetList)
		{
			_frePExCndDList	= frePExCndDList;
			foreach (FrePprECnd frePprECnd in frePprECndList)
				_buf_frePprECndList.Add(frePprECnd.Clone());
			_prtItemSetList	= prtItemSetList;

			InitializeData();

			return this.ShowDialog();
		}

////////////////////////////////////////////// 2008.03.19 TERASAKA ADD STA //
		/// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <param name="frePprECndList">自由帳票抽出条件設定LIST</param>
		/// <param name="message">不正時のメッセージ</param>
		/// <param name="errIndex">不正となる項目のListIndex</param>
		/// <returns>チェック結果</returns>
		/// <remarks>
		/// <br>Note		: 画面の入力チェックを行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2008.03.19</br>
		/// </remarks>
		public bool InputCheck(List<FrePprECnd> frePprECndList, out string message, out int errIndex)
		{
			message = string.Empty;
			errIndex = 0;

			// 抽出条件に日付系が含まれているかのチェック
			bool existExtrTypeDate = false;
			foreach (FrePprECnd frePprECnd in frePprECndList)
			{
				if (frePprECnd.UsedFlg == 1 && frePprECnd.ExtraConditionDivCd == 4)
				{
					existExtrTypeDate = true;
					break;
				}
			}
			if (!existExtrTypeDate)
			{
				message		= "日付系条件が1つは必要です。";
				errIndex	= -1;
				return false;
			}

			// 各抽出条件についてのチェック
			if (!SFANL08132CA.InputCheck(frePprECndList, false, out message, out errIndex))
				return false;

			return true;
		}
// 2008.03.19 TERASAKA ADD END //////////////////////////////////////////////
		#endregion

		#region PrivateMethod
		/// <summary>
		/// 初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面および各種変数の初期処理を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void InitializeSetting()
		{
			this.tToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
			// 確定ボタン
			ButtonTool decideButton = (ButtonTool)this.tToolbarsManager.Tools[ctButtonTool_Decide];
			if (decideButton != null) decideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			// 戻るボタン
			ButtonTool returnButton = (ButtonTool)this.tToolbarsManager.Tools[ctButtonTool_Return];
			if (returnButton != null) returnButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
			// 取消ボタン
			ButtonTool cancelButton = (ButtonTool)this.tToolbarsManager.Tools[ctButtonTool_Cancel];
			if (cancelButton != null) cancelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;

			DataSet ds = new DataSet();
			_dt = new DataTable(TBL_FREPPRECND_SETTING);
			_dt.Columns.Add(COL_USEDFLG,				typeof(int));			// 使用フラグ
			_dt.Columns.Add(COL_DISPLAYORDER,			typeof(int));			// 表示順位
			_dt.Columns.Add(COL_EXTRACONDITIONTITLE,	typeof(string));		// 抽出条件タイトル
			_dt.Columns.Add(COL_FREPRTPPREXTRACONDCD,	typeof(int));			// 自由帳票抽出条件枝番
			_dt.Columns.Add(COL_FREPPRECND,				typeof(FrePprECnd));	// 自由帳票抽出条件マスタ
			ds.Tables.Add(_dt);
			this.gridExtrList.DataSource = ds;
			this.gridExtrList.DataMember = TBL_FREPPRECND_SETTING;
		}

		/// <summary>
		/// データ初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面に表示するデータを初期状態にします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void InitializeData()
		{
			_dt.Rows.Clear();

			// データの設定
			foreach (FrePprECnd frePprECnd in _buf_frePprECndList)
				SetFrePprECndToDataTable(frePprECnd.Clone(), -1);
		}

		/// <summary>
		/// データテーブル情報更新処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		/// <param name="index">インデックス</param>
		/// <remarks>
		/// <br>Note		: DataTableに自由帳票抽出条件設定マスタをセットします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void SetFrePprECndToDataTable(FrePprECnd frePprECnd, int index)
		{
			DataRow dr;
			if (index < 0)
			{
				dr = _dt.NewRow();
				_dt.Rows.Add(dr);
			}
			else
			{
				dr = _dt.Rows[index];
			}

			dr[COL_USEDFLG]					= frePprECnd.UsedFlg;				// 使用フラグ
			dr[COL_DISPLAYORDER]			= frePprECnd.DisplayOrder;			// 表示順位
			dr[COL_EXTRACONDITIONTITLE]		= frePprECnd.ExtraConditionTitle;	// 抽出条件タイトル
			dr[COL_FREPRTPPREXTRACONDCD]	= frePprECnd.FrePrtPprExtraCondCd;	// 自由帳票抽出条件枝番
			dr[COL_FREPPRECND]				= frePprECnd;						// 自由帳票抽出条件マスタ
		}

		/// <summary>
		/// 画面生成処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		/// <remarks>
		/// <br>Note		: 自由帳票抽出条件設定マスタの情報を元に画面構成を変更します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void UpdateSetttingUI(FrePprECnd frePprECnd)
		{
			// ☆☆☆ 抽出条件タイプの設定 ☆☆☆
			this.cmdExtraConditionTypeCd.Items.Clear();
			this.cmdExtraConditionTypeCd.ReadOnly = false;
			switch (frePprECnd.ExtraConditionDivCd)
			{
				case 1:
				{
					this.cmdExtraConditionTypeCd.Items.Add(0, "完全一致");
					this.cmdExtraConditionTypeCd.Items.Add(1, "範囲");
					break;
				}
				case 2:
				case 3:
				{
					this.cmdExtraConditionTypeCd.Items.Add(0, "完全一致");
					this.cmdExtraConditionTypeCd.Items.Add(1, "範囲");
					this.cmdExtraConditionTypeCd.Items.Add(2, "あいまい検索");
					break;
				}
				case 4:
				{
					this.cmdExtraConditionTypeCd.Items.Add(0, "完全一致");
					this.cmdExtraConditionTypeCd.Items.Add(1, "範囲");
					this.cmdExtraConditionTypeCd.Items.Add(3, "期間（開始日基準）");
					this.cmdExtraConditionTypeCd.Items.Add(4, "期間（終了日基準）");
					break;
				}
				case 5:
				case 6:
				{
					this.cmdExtraConditionTypeCd.Items.Add(0, "　");
					this.cmdExtraConditionTypeCd.ReadOnly = true;
					break;
				}
			}

			if (frePprECnd.UsedFlg == 1)
			{
				this.pnlExtrProperty.Enabled = true;
				this.pnlDefaultSetting.Enabled = true;
			}
			else
			{
				this.pnlExtrProperty.Enabled = false;
				this.pnlDefaultSetting.Enabled = false;
			}

			// データのセット
			this.tedExtraConditionTitle.Text	= frePprECnd.ExtraConditionTitle;
			this.cmdExtraConditionTypeCd.Value	= frePprECnd.ExtraConditionTypeCd;
			this.ndtDisplayOder.SetInt(frePprECnd.DisplayOrder);

			UpdateDefaultSettingUI(frePprECnd);
		}

		/// <summary>
		/// 初期値設定UI更新処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		/// <remarks>
		/// <br>Note		: 自由帳票抽出条件設定マスタの情報を元に初期値設定用画面を作成します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void UpdateDefaultSettingUI(FrePprECnd frePprECnd)
		{
			while (this.pnlDefSettingUI.Controls.Count > 0)
				this.pnlDefSettingUI.Controls[0].Dispose();

			Control defSettingCtrl = SFANL08132CA.GetExtrSettingControl(frePprECnd, _frePExCndDList);
			if (defSettingCtrl != null)
			{
				this.pnlDefSettingUI.Controls.Add(defSettingCtrl);
				defSettingCtrl.Dock = DockStyle.Top;
			}
		}

		/// <summary>
		/// 初期値設定取得処理
		/// </summary>
		/// <param name="frePprECnd">自由帳票抽出条件設定マスタ</param>
		/// <remarks>
		/// <br>Note		: 初期値設定用画面より抽出条件初期値を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void GetDefaultSettingData(FrePprECnd frePprECnd)
		{
			if (frePprECnd != null && frePprECnd.UsedFlg == 1)
			{
				string controlName = SFANL08132CA.GetControlName(frePprECnd);
				if (this.pnlDefSettingUI.Controls.ContainsKey(controlName))
				{
					IFreePrintUserControl iFreePrintUserControl = this.pnlDefSettingUI.Controls[controlName] as IFreePrintUserControl;
					iFreePrintUserControl.GetFrePprECndInfo(ref frePprECnd);
				}
			}
		}

		/// <summary>
		/// 変更チェック処理
		/// </summary>
		/// <returns>チェック結果</returns>
		/// <remarks>
		/// <br>Note		: 画面の情報が変更されているかチェックします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private bool ChangeCheck()
		{
			List<FrePprECnd> frePprECndList = GetFrePprECndList();
			foreach (FrePprECnd compareFrePprECnd in frePprECndList)
			{
				if (!_buf_frePprECndList.Exists(
					delegate(FrePprECnd frePprECnd)
					{
////////////////////////////////////////////// 2008.03.19 TERASAKA DEL STA //
//						if (frePprECnd.EqualsWithoutExtrDate(compareFrePprECnd))
// 2008.03.19 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2008.03.19 TERASAKA ADD STA //
						if (frePprECnd.EqualsWithoutSystemDate(compareFrePprECnd))
// 2008.03.19 TERASAKA ADD END //////////////////////////////////////////////
							return true;
						else
							return false;
					}
				))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 自由帳票抽出条件LIST取得処理
		/// </summary>
		/// <returns>自由帳票抽出条件LIST</returns>
		private List<FrePprECnd> GetFrePprECndList()
		{
			List<FrePprECnd> frePprECndList = new List<FrePprECnd>();

			foreach (DataRow dr in _dt.Rows)
				frePprECndList.Add((FrePprECnd)dr[COL_FREPPRECND]);

			return frePprECndList;
		}

		/// <summary>
		/// 表示順位更新処理
		/// </summary>
		/// <param name="usedFlg">更新後の使用フラグ</param>
		/// <param name="index">対象データのインデックス</param>
		/// <param name="nextOder">更新後の表示順位</param>
		/// <remarks>
		/// <br>Note		: 表示順位の更新処理を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void UpdateDisplayOder(int usedFlg, int index, int nextOder)
		{
			DataRow dr = _dt.Rows[index];
			FrePprECnd frePprECnd = (FrePprECnd)dr[COL_FREPPRECND];

			int offerOrUserStCd = (int)dr[COL_USEDFLG];
			DataRow[] drArray;
			if (usedFlg == 1)
			{
				// 現在の最大表示順位を取得
				string filter = COL_USEDFLG + "=1";
				drArray = _dt.Select(filter, COL_DISPLAYORDER + " DESC");
				if (drArray.Length != 0)
				{
					int maxDispOder = (int)drArray[0][COL_DISPLAYORDER];
					if (nextOder == 0)
						nextOder = maxDispOder + 1;
					else if (nextOder > maxDispOder)
						nextOder = maxDispOder;
				}
				else
				{
					if (nextOder == 0)
						nextOder = 1;
				}

				if (nextOder > frePprECnd.DisplayOrder)
				{
					filter = COL_USEDFLG + "=1 AND " + COL_DISPLAYORDER + ">" + frePprECnd.DisplayOrder + " AND " + COL_DISPLAYORDER + "<=" + nextOder;
					drArray = _dt.Select(filter, COL_DISPLAYORDER + " ASC");
					if (drArray.Length != 0)
					{
						foreach (DataRow moveRow in drArray)
						{
							FrePprECnd wkFrePprECnd = (FrePprECnd)moveRow[COL_FREPPRECND];
							wkFrePprECnd.DisplayOrder--;
							SetFrePprECndToDataTable(wkFrePprECnd, _dt.Rows.IndexOf(moveRow));
						}
					}
				}
				else
				{
					filter = COL_USEDFLG + "=1 AND " + COL_DISPLAYORDER + "<" + frePprECnd.DisplayOrder + " AND " + COL_DISPLAYORDER + ">=" + nextOder;
					drArray = _dt.Select(filter, COL_DISPLAYORDER + " ASC");
					if (drArray.Length != 0)
					{
						foreach (DataRow moveRow in drArray)
						{
							FrePprECnd wkFrePprECnd = (FrePprECnd)moveRow[COL_FREPPRECND];
							wkFrePprECnd.DisplayOrder++;
							SetFrePprECndToDataTable(wkFrePprECnd, _dt.Rows.IndexOf(moveRow));
						}
					}
				}

				frePprECnd.DisplayOrder = nextOder;
				SetFrePprECndToDataTable(frePprECnd, index);

				this.pnlExtrProperty.Enabled = true;
				this.pnlDefaultSetting.Enabled = true;
			}
			else
			{
				// 必須抽出条件項目の場合は以下の処理を行わない
				if (frePprECnd.NecessaryExtraCondCd == 1) return;

				int dispOder	= frePprECnd.DisplayOrder;
				string filter	= COL_USEDFLG + "=1 AND " + COL_DISPLAYORDER + " > " + frePprECnd.DisplayOrder;
				drArray = _dt.Select(filter, COL_DISPLAYORDER + " ASC");
				foreach (DataRow moveRow in drArray)
				{
					FrePprECnd wkFrePprECnd = (FrePprECnd)moveRow[COL_FREPPRECND];
					wkFrePprECnd.DisplayOrder = dispOder++;
					SetFrePprECndToDataTable(wkFrePprECnd, _dt.Rows.IndexOf(moveRow));
				}

				frePprECnd.DisplayOrder = 999;	// 使用しないデータは999固定
				SetFrePprECndToDataTable(frePprECnd, index);

				this.pnlExtrProperty.Enabled = false;
				this.pnlDefaultSetting.Enabled = false;
			}

			// 表示順位の昇順でソート
			this.gridExtrList.DisplayLayout.Bands[0].Columns[COL_DISPLAYORDER].SortIndicator
				= SortIndicator.Ascending;
			if (this.gridExtrList.ActiveRow != null)
				this.gridExtrList.ActiveRowScrollRegion.ScrollRowIntoView(this.gridExtrList.ActiveRow);
			
			this.ndtDisplayOder.SetInt(frePprECnd.DisplayOrder);
		}

		/// <summary>
		/// 未使用データ初期化処理
		/// </summary>
		/// <param name="frePprECndList">抽出条件設定LIST</param>
		/// <remarks>
		/// <br>Note		: 未使用となっている抽出条件の初期化を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void UnusedDataInitialize(List<FrePprECnd> frePprECndList)
		{
			foreach (FrePprECnd frePprECnd in frePprECndList)
			{
				if (frePprECnd.UsedFlg == 0)
				{
					if (_prtItemSetList != null && _prtItemSetList.Count > 0)
					{
						PrtItemSetWork prtItemSet = _prtItemSetList.Find(
							delegate(PrtItemSetWork prtItemSetWork)
							{
								if (prtItemSetWork.FreePrtPaperItemCd == frePprECnd.FrePrtPprExtraCondCd)
									return true;
								else
									return false;
							}
						);
						if (prtItemSet != null) frePprECnd.ExtraConditionTitle = prtItemSet.FreePrtPaperItemNm;
					}
					frePprECnd.StExtraNumCode		= 0;
					frePprECnd.EdExtraNumCode		= 0;
					frePprECnd.StExtraCharCode		= string.Empty;
					frePprECnd.EdExtraCharCode		= string.Empty;
					frePprECnd.StExtraDateBaseCd	= 2;
					frePprECnd.StExtraDateSignCd	= 0;
					frePprECnd.StExtraDateNum		= 0;
					frePprECnd.StExtraDateUnitCd	= 0;
					frePprECnd.StartExtraDate		= 0;
					frePprECnd.EdExtraDateBaseCd	= 2;
					frePprECnd.EdExtraDateSignCd	= 0;
					frePprECnd.EdExtraDateNum		= 0;
					frePprECnd.EdExtraDateUnitCd	= 0;
					frePprECnd.EndExtraDate			= 0;
					frePprECnd.CheckItemCode1		= -1;
					frePprECnd.CheckItemCode2		= -1;
					frePprECnd.CheckItemCode3		= -1;
					frePprECnd.CheckItemCode4		= -1;
					frePprECnd.CheckItemCode5		= -1;
					frePprECnd.CheckItemCode6		= -1;
					frePprECnd.CheckItemCode7		= -1;
					frePprECnd.CheckItemCode8		= -1;
					frePprECnd.CheckItemCode9		= -1;
					frePprECnd.CheckItemCode10		= -1;
				}
			}
		}
		#endregion

		#region Event
		/// <summary>
		/// ツールバークリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ツールバーがクリックされた時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void tToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
		{
			this.gridExtrList.Focus();
			gridExtrList_BeforeRowDeactivate(this.gridExtrList, new CancelEventArgs());

			switch (e.Tool.Key)
			{
				case ctButtonTool_Decide:	// 確定ボタン
				{
					List<FrePprECnd> frePprECndList = GetFrePprECndList();

					string	message;
					int		errIndex;
////////////////////////////////////////////// 2008.03.19 TERASAKA DEL STA //
//					if (SFANL08132CA.InputCheck(frePprECndList, false, out message, out errIndex))
// 2008.03.19 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2008.03.19 TERASAKA ADD STA //
					// 画面全体での入力チェック→各条件の初期値に関する入力チェック
					if (InputCheck(frePprECndList, out message, out errIndex))
// 2008.03.19 TERASAKA ADD END //////////////////////////////////////////////
					{
						// 未使用データ初期化処理
						UnusedDataInitialize(frePprECndList);

						_frePprECndList		= frePprECndList;
						this.DialogResult	= DialogResult.OK;
////////////////////////////////////////////// 2008.04.04 TERASAKA ADD STA //
						_cancelCloseCheck	= true;
// 2008.04.04 TERASAKA ADD END //////////////////////////////////////////////
						this.Close();
					}
					else
					{
						DialogResult dlgRet = TMsgDisp.Show(
							this,								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
							ctASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
							message,							// 表示するメッセージ 
							0,									// ステータス値
							MessageBoxButtons.OK);				// 表示するボタン
////////////////////////////////////////////// 2008.03.19 TERASAKA DEL STA //
//						foreach (UltraGridRow row in this.gridExtrList.Rows)
//						{
//							if ((int)row.Cells[COL_FREPRTPPREXTRACONDCD].Value == frePprECndList[errIndex].FrePrtPprExtraCondCd)
//							{
//								row.Activate();
//								break;
//							}
//						}
// 2008.03.19 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2008.03.19 TERASAKA ADD STA //
						if (errIndex >= 0 && errIndex < frePprECndList.Count)
						{
							foreach (UltraGridRow row in this.gridExtrList.Rows)
							{
								if ((int)row.Cells[COL_FREPRTPPREXTRACONDCD].Value == frePprECndList[errIndex].FrePrtPprExtraCondCd)
								{
									row.Activate();
									break;
								}
							}
						}
// 2008.03.19 TERASAKA ADD END //////////////////////////////////////////////
					}
					break;
				}
				case ctButtonTool_Return:	// 戻るボタン
				{
////////////////////////////////////////////// 2008.04.04 TERASAKA DEL STA //
//					if (!ChangeCheck())
//					{
//						DialogResult dlgRet = TMsgDisp.Show(
//							emErrorLevel.ERR_LEVEL_CONFIRM,		// エラーレベル
//							ctASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
//							string.Empty,						// 表示するメッセージ 
//							0,									// ステータス値
//							MessageBoxButtons.YesNo);			// 表示するボタン
//						if (dlgRet == DialogResult.Yes)
//						{
//							this.DialogResult = DialogResult.Cancel;
//							this.Close();
//						}
//					}
//					else
//					{
//						this.DialogResult = DialogResult.Cancel;
//						this.Close();
//					}
// 2008.04.04 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2008.04.04 TERASAKA ADD STA //
					this.Close();
// 2008.04.04 TERASAKA ADD END //////////////////////////////////////////////
					break;
				}
				case ctButtonTool_Cancel:	// 取消ボタン
				{
					if (!ChangeCheck())
					{
						string message = "現在編集中のデータが存在します。\r\n\r\n初期状態に戻しますか？";
						DialogResult dlgRet = TMsgDisp.Show(
							this,								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_QUESTION,	// エラーレベル
							ctASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
							message.ToString(),					// 表示するメッセージ 
							0,									// ステータス値
							MessageBoxButtons.YesNo);			// 表示するボタン
						if (dlgRet == DialogResult.Yes)
						{
							InitializeData();
							this.gridExtrList.Rows[0].Activate();
							this.gridExtrList.Focus();
						}
					}
					break;
				}
			}
		}

		/// <summary>
		/// グリッド初期化イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: グリッドが初期化された時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void gridExtrList_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			// 使用フラグ
			e.Layout.Bands[0].Columns[COL_USEDFLG].Header.Caption = "使用区分";
			e.Layout.Bands[0].Columns[COL_USEDFLG].Style
				= Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
			// 表示順位
			e.Layout.Bands[0].Columns[COL_DISPLAYORDER].Header.Caption	= "表示順位";
			e.Layout.Bands[0].Columns[COL_DISPLAYORDER].CellAppearance.TextHAlign = HAlign.Right;
			// 抽出条件タイトル
			e.Layout.Bands[0].Columns[COL_EXTRACONDITIONTITLE].Header.Caption = "抽出条件タイトル";
			// 自由帳票抽出条件マスタ
			e.Layout.Bands[0].Columns[COL_FREPPRECND].Hidden = true;
			// 自由帳票抽出条件枝番
			e.Layout.Bands[0].Columns[COL_FREPRTPPREXTRACONDCD].Hidden = true;

			// 表示順位の昇順でソート
			e.Layout.Bands[0].Columns[COL_DISPLAYORDER].SortIndicator
				= SortIndicator.Ascending;
		}

		/// <summary>
		/// グリッド行初期化イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 行が初期化された時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void gridExtrList_InitializeRow(object sender, InitializeRowEventArgs e)
		{
			FrePprECnd frePprECnd = (FrePprECnd)e.Row.Cells[COL_FREPPRECND].Value;
			if (frePprECnd.NecessaryExtraCondCd == 1)
				e.Row.Appearance.ForeColor = Color.Red;
			else
				e.Row.Appearance.ForeColor = Color.Black;
		}

		/// <summary>
		/// グリッドクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: グリッド上でクリックされた時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void gridExtrList_MouseClick(object sender, MouseEventArgs e)
		{
			Point lastMouseDown = new Point(e.X, e.Y);
			// UIElementを利用して座標位置のコントロールを取得
			UIElement element = this.gridExtrList.DisplayLayout.UIElement.ElementFromPoint(lastMouseDown);
			// クリックした位置がGridRowの場合のみ処理を行う
			UltraGridCell ultraGridCell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;
			if (ultraGridCell != null && ultraGridCell.Column.Key.Equals(COL_USEDFLG))
			{
				if ((int)ultraGridCell.Value == 0)
					UpdateDisplayOder(1, ultraGridCell.Row.ListIndex, 0);
				else
					UpdateDisplayOder(0, ultraGridCell.Row.ListIndex, 999);
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
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void gridExtrList_AfterRowActivate(object sender, EventArgs e)
		{
			this.gridExtrList.DisplayLayout.Override.SelectedRowAppearance.ForeColor
				= this.gridExtrList.ActiveRow.Appearance.ForeColor;

			this.gridExtrList.ActiveRow.Selected = true;

			// 画面の再作成
			FrePprECnd frePprECnd = (FrePprECnd)this.gridExtrList.ActiveRow.Cells[COL_FREPPRECND].Value;
			UpdateSetttingUI(frePprECnd);
		}

		/// <summary>
		/// グリッドキーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: グリッド上でキーが押下された時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void gridExtrList_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Right:
				{
					if (this.pnlExtrProperty.Enabled)
						this.ndtDisplayOder.Focus();
					e.Handled = true;
					break;
				}
				case Keys.Space:
				{
					if (this.gridExtrList.ActiveRow != null)
					{
						if ((int)this.gridExtrList.ActiveRow.Cells[COL_USEDFLG].Value == 0)
							UpdateDisplayOder(1, this.gridExtrList.ActiveRow.ListIndex, 0);
						else
							UpdateDisplayOder(0, this.gridExtrList.ActiveRow.ListIndex, 999);
					}
					break;
				}
			}
		}

		/// <summary>
		/// AfterExitEditModeイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールが編集モードを終了した後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void SettingControl_AfterExitEditMode(object sender, EventArgs e)
		{
			bool isDataChanged = false;
			
			if (sender is TEdit)
				isDataChanged = !_bufText.Equals(((TEdit)sender).Text);
			if (sender is TNedit)
				isDataChanged = !_bufCode.Equals(((TNedit)sender).GetInt());
			if (sender is TComboEditor)
			{
				isDataChanged = !_bufCode.Equals((int)((TComboEditor)sender).Value);
				_bufCode = (int)((TComboEditor)sender).Value;
			}

			if (isDataChanged)
			{
				FrePprECnd frePprECnd = (FrePprECnd)this.gridExtrList.ActiveRow.Cells[COL_FREPPRECND].Value;
				GetDefaultSettingData(frePprECnd);

				if (sender == this.ndtDisplayOder)
				{
					SetFrePprECndToDataTable(frePprECnd, this.gridExtrList.ActiveRow.ListIndex);
					UpdateDisplayOder(1, this.gridExtrList.ActiveRow.ListIndex, this.ndtDisplayOder.GetInt());
				}
				else if (sender == this.tedExtraConditionTitle)
				{
					frePprECnd.ExtraConditionTitle	= this.tedExtraConditionTitle.Text;
					SetFrePprECndToDataTable(frePprECnd, this.gridExtrList.ActiveRow.ListIndex);
					UpdateDefaultSettingUI(frePprECnd);
				}
				else if (sender == this.cmdExtraConditionTypeCd)
				{
					frePprECnd.ExtraConditionTypeCd	= (int)this.cmdExtraConditionTypeCd.Value;
					SetFrePprECndToDataTable(frePprECnd, this.gridExtrList.ActiveRow.ListIndex);
					UpdateDefaultSettingUI(frePprECnd);
				}
			}
		}

		/// <summary>
		/// Enterイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールに</br>
		/// <br>			: なったときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void SettingControl_Enter(object sender, EventArgs e)
		{
			if (sender is TEdit)
				_bufText = ((TEdit)sender).Text;
			if (sender is TNedit)
				_bufCode = ((TNedit)sender).GetInt();
			if (sender is TComboEditor)
				_bufCode = (int)((TComboEditor)sender).Value;
		}

		/// <summary>
		/// フォームキーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォーム上でキー押下された時に発生します。</br>
		/// <br>Programer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void SFANL08130UA_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				ToolClickEventArgs ev = new ToolClickEventArgs(this.tToolbarsManager.Tools[ctButtonTool_Return], new ListToolItem());
				tToolbarsManager_ToolClick(sender, ev);
			}
		}

		/// <summary>
		/// BeforeRowDeactivateイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 行が非アクティブになる前に発生します。</br>
		/// <br>Programer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void gridExtrList_BeforeRowDeactivate(object sender, CancelEventArgs e)
		{
			int listIndex = this.gridExtrList.ActiveRow.ListIndex;

			FrePprECnd frePprECnd = _dt.Rows[listIndex][COL_FREPPRECND] as FrePprECnd;
			GetDefaultSettingData(frePprECnd);

			SetFrePprECndToDataTable(frePprECnd, listIndex);
		}

		/// <summary>
		/// Shownイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォームが最初に表示された時に発生します。</br>
		/// <br>Programer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void SFANL08130UA_Shown(object sender, EventArgs e)
		{
			if (this.gridExtrList.Rows.Count > 0)
				this.gridExtrList.Rows[0].Activate();
		}

////////////////////////////////////////////// 2008.04.04 TERASAKA ADD STA //
		/// <summary>
		/// FormClosingイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォームが最初に表示された時に発生します。</br>
		/// <br>Programer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.04.04</br>
		/// </remarks>
		private void SFANL08130UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && !_cancelCloseCheck)
			{
////////////////////////////////////////////// 2008.04.07 TERASAKA ADD STA //
				this.gridExtrList.Focus();
// 2008.04.07 TERASAKA ADD END //////////////////////////////////////////////
				gridExtrList_BeforeRowDeactivate(this.gridExtrList, new CancelEventArgs());

				if (!ChangeCheck())
				{
					DialogResult dlgRet = TMsgDisp.Show(
						emErrorLevel.ERR_LEVEL_CONFIRM,		// エラーレベル
						ctASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						string.Empty,						// 表示するメッセージ 
						0,									// ステータス値
						MessageBoxButtons.YesNo);			// 表示するボタン
					if (dlgRet == DialogResult.No)
					{
						e.Cancel = true;
					}
				}
			}
		}
// 2008.04.04 TERASAKA ADD END //////////////////////////////////////////////
		#endregion
	}
}