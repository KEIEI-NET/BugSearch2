using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

using Infragistics.Win;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 目標検索ガイド画面
	/// </summary>
	/// <remarks>
	/// <br>Note			 : 目標検索を行うガイド画面です。</br>
	/// <br>Programmer		 : NEPCO</br>
	/// <br>Date			 : 2007.04.23</br>
	/// <br>Update Note		 : 2007.11.21 上野 弘貴</br>
	/// <br>                   流通.DC用に変更（項目追加・削除）</br>
	/// </remarks>
	public partial class MAMOK09190UA : Form
	{
		# region Private Constants

		// 画面状態保存用ファイル名
		private const string XML_FILE_INITIAL_DATA = "MAMOK09190U.dat";

		// PG名称
		private const string ctPGNM = "個別期間目標ガイド";

		private const string SALESTARGET = "SALESTARGET";

		private const string COL_SALESTARGET_APPLYMONTH = "applyMonth";
		private const string COL_SALESTARGET_APPLYSTADATE = "applyStaDate";
		private const string COL_SALESTARGET_APPLYENDDATE = "applyEndDate";
		private const string COL_SALESTARGET_TARGETDIVIDECODE = "targetDivideCode";
		private const string COL_SALESTARGET_TARGETDIVIDENAME = "targetDivideName";
		private const string COL_SALESTARGET_SECTION = "section";
		private const string COL_SALESTARGET_EMPLOYEE = "employee";
		private const string COL_SALESTARGET_GOODS = "goods";
//----- ueno add---------- start 2007.11.21
		private const string COL_SALESTARGET_CUSTOMER = "customer";
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//private const string COL_SALESTARGET_SALESFORMAL = "salesFormal";
		//private const string COL_SALESTARGET_SALESFORM = "salesForm";
		//----- ueno del---------- end   2007.11.21
		private const string VIEW_SALESTARGET_APPLYMONTH = "適用月";
		private const string VIEW_SALESTARGET_APPLYSTADATE = "期間（開始）";
		private const string VIEW_SALESTARGET_APPLYENDDATE = "期間（終了）";
		private const string VIEW_SALESTARGET_TARGETDIVIDECODE = "目標区分コード";
		private const string VIEW_SALESTARGET_TARGETDIVIDENAME = "目標区分名称";
		private const string VIEW_SALESTARGET_SECTION = "拠点目標";
		private const string VIEW_SALESTARGET_EMPLOYEE = "従業員目標";
		private const string VIEW_SALESTARGET_GOODS = "商品目標";
//----- ueno add---------- start 2007.11.21
		private const string VIEW_SALESTARGET_CUSTOMER = "得意先目標";
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//private const string VIEW_SALESTARGET_SALESFORMAL = "売上形式目標";
		//private const string VIEW_SALESTARGET_SALESFORM = "販売形態目標";
		//----- ueno del---------- end   2007.11.21
		private const int WIDTH_SALESTARGET_APPLYMONTH = 105;
		private const int WIDTH_SALESTARGET_APPLYSTADATE = 105;
		private const int WIDTH_SALESTARGET_APPLYENDDATE = 105;
		private const int WIDTH_SALESTARGET_TARGETDIVIDECODE = 118;
		private const int WIDTH_SALESTARGET_TARGETDIVIDENAME = 240;
		private const int WIDTH_SALESTARGET_SECTION = 95;
		private const int WIDTH_SALESTARGET_EMPLOYEE = 95;
		private const int WIDTH_SALESTARGET_GOODS = 95;
//----- ueno add---------- start 2007.11.21
		private const int WIDTH_SALESTARGET_CUSTOMER = 95;
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//private const int WIDTH_SALESTARGET_SALESFORMAL = 105;
		//private const int WIDTH_SALESTARGET_SALESFORM = 105;
		//----- ueno del---------- end   2007.11.21

		# endregion Private Constants

		# region Private Members

		// 企業コード
		private string _enterpriseCode;
		// 拠点コード
		private string _sectionCode;

		private List<SalesTarget> _sectionSalesTargetList;
		private List<SalesTarget> _employeeSalesTargetList;
		private List<SalesTarget> _goodsSalesTargetList;
//----- ueno add---------- start 2007.11.21
		private List<SalesTarget> _customerSalesTargetList;
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//private List<SalesTarget> _salesFormalSalesTargetList;
		//private List<SalesTarget> _salesFormSalesTargetList;
		//----- ueno del---------- end   2007.11.21

		// 目標マスタアクセスクラス
		private SalesTargetAcs _salesTargetAcs;

		// 目標設定区分
		private int _targetSetCd;

		// グリッド設定制御クラス
		private GridStateController _gridStateController;

		// 拠点選択フラグ
		private bool _selectedSectionFlg;

		/// <summary>画面デザイン変更クラス</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		# endregion Private Members

		# region Constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MAMOK09190UA()
		{
			InitializeComponent();

			// 企業コードを取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 拠点情報取得
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            SecInfoSet secInfoSet;
            secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
            this._sectionCode = secInfoSet.SectionCode.TrimEnd();

			this._gridStateController = new GridStateController();

			this._salesTargetAcs = new SalesTargetAcs();
			this._sectionSalesTargetList = new List<SalesTarget>();
			this._employeeSalesTargetList = new List<SalesTarget>();
			this._goodsSalesTargetList = new List<SalesTarget>();
//----- ueno add---------- start 2007.11.21
			this._customerSalesTargetList = new List<SalesTarget>();
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//this._salesFormalSalesTargetList = new List<SalesTarget>();
			//this._salesFormSalesTargetList = new List<SalesTarget>();
			//----- ueno del---------- end   2007.11.21

			// ツールバーにイメージリストを設定する
			Main_ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
			// アイコン画像の設定
			ButtonTool workButton;
			// 戻るボタンのアイコン設定
			workButton = (ButtonTool)Main_ToolbarsManager.Tools["Return_ButtonTool"];
			if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
			// 確定ボタンのアイコン設定
			workButton = (ButtonTool)Main_ToolbarsManager.Tools["Decision_ButtonTool"];
			if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			// 確定ボタンの制御
			if (workButton != null) workButton.SharedProps.Enabled = false;
			// 検索ボタン
			this.Search_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH];
		}

		# endregion Constructor

		# region Public Propaties

		/// public propaty name  :	TargetSetCd
		/// <summary>目標設定区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 目標設定区分プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public int TargetSetCd
		{
			get
			{
				return this._targetSetCd;
			}
			set
			{
				this._targetSetCd = value;
			}
		}

		# endregion

		# region Public Methods

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ガイド表示処理
		/// </summary>
		/// <param name="owner">フォーム</param>
		/// <param name="salesTarget">目標データ</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="selectedSectionFlag">拠点選択フラグ</param>
		/// <remarks>
		/// <br>Note		: 目標検索ガイド画面を表示し、選択したデータを返します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		public DialogResult ShowGuide(IWin32Window owner, out SalesTarget salesTarget, string[] sectionCode, bool selectedSectionFlag)
		{
			salesTarget = new SalesTarget();

            SecInfoAcs secInfoAcs = new SecInfoAcs();

            // 拠点コンボボックスに拠点リストを設定する
            if (sectionCode[0] == "0")
            {
                //
                // 全社選択の時
                //
                foreach (SecInfoSet secInfoSetWk in secInfoAcs.SecInfoSetList)
                {
                    this.SectionName_tComboEditor.Items.Add(secInfoSetWk.SectionCode.TrimEnd(), secInfoSetWk.SectionGuideNm.TrimEnd());
                }
            }
            else
            {
                for (int i = 0; i < sectionCode.Length; i++)
                {
                    foreach (SecInfoSet secInfoSetWk in secInfoAcs.SecInfoSetList)
                    {
                        if (sectionCode[i] == secInfoSetWk.SectionCode.TrimEnd())
                        {
                            this.SectionName_tComboEditor.Items.Add(secInfoSetWk.SectionCode.TrimEnd(), secInfoSetWk.SectionGuideNm.TrimEnd());
                            continue;
                        }
                    }
                }
                //this.SectionName_tComboEditor.Value = sectionCode[0];
            }
            this.SectionName_tComboEditor.SelectedIndex = 0;

			// 拠点選択フラグ
			this._selectedSectionFlg = selectedSectionFlag;

			this.ShowDialog(owner);

			// 目標データが一件も無い場合
			if (this.SalesTarget_uGrid.ActiveRow == null)
			{
				this.DialogResult = DialogResult.Cancel;
			}

			if (this.DialogResult == DialogResult.OK)
			{
				string targetDate;
				int days;

				// 月間目標
				if ((int)this.TargetSetCd_uOptionSet.Value == 10)
				{
					targetDate = this.SalesTarget_uGrid.ActiveRow.Cells[COL_SALESTARGET_APPLYMONTH].Value.ToString();
					// 開始期間
					salesTarget.ApplyStaDate = new DateTime(int.Parse(targetDate.Substring(0, 4)), int.Parse(targetDate.Substring(5, 2)), 1);
					// 終了期間
					days = DateTime.DaysInMonth(salesTarget.ApplyStaDate.Year, salesTarget.ApplyStaDate.Month);
					salesTarget.ApplyEndDate = new DateTime(salesTarget.ApplyStaDate.Year, salesTarget.ApplyStaDate.Month, days);
					salesTarget.TargetDivideName = "";
				}
				// 個別期間目標
				else
				{
					// 開始期間
					salesTarget.ApplyStaDate = (DateTime)this.SalesTarget_uGrid.ActiveRow.Cells[COL_SALESTARGET_APPLYSTADATE].Value;
					// 終了期間
					salesTarget.ApplyEndDate = (DateTime)this.SalesTarget_uGrid.ActiveRow.Cells[COL_SALESTARGET_APPLYENDDATE].Value;
					// 目標区分名称
					salesTarget.TargetDivideName = (string)this.SalesTarget_uGrid.ActiveRow.Cells[COL_SALESTARGET_TARGETDIVIDENAME].Value;
				}

				// 目標区分コード
				salesTarget.TargetDivideCode = (string)this.SalesTarget_uGrid.ActiveRow.Cells[COL_SALESTARGET_TARGETDIVIDECODE].Value;
				// 目標設定区分
				salesTarget.TargetSetCd = (int)this.TargetSetCd_uOptionSet.Value;
			}

			return (this.DialogResult);
		}

		# endregion Public Methods

		# region Private Methods

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ＸＭＬデータの保存処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面状態保持用のＸＭＬの保存処理を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.27</br>
		/// </remarks>
		private void SaveStateXmlData()
		{
			// グリッド情報を保存
			_gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.SalesTarget_uGrid);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ＸＭＬデータの読込処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面状態保持用のＸＭＬの読込処理を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.27</br>
		/// </remarks>
		private void LoadStateXmlData()
		{
			int status = _gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.SalesTarget_uGrid);
			if (status == 0)
			{
				GridStateController.GridStateInfo gridStateInfo = _gridStateController.GetGridStateInfo(ref this.SalesTarget_uGrid);
				if (gridStateInfo != null)
				{
					// フォントサイズ
					this.cmbFontSize.Value = (int)gridStateInfo.FontSize;
					// 列の自動調整
					this.uceAutoFitCol.Checked = gridStateInfo.AutoFit;
				}
				else
				{
					status = 4;
				}
			}
			if (status != 0)
			{
				// フォントサイズ
				this.cmbFontSize.Value = 10;
				// 列の自動調整
				this.uceAutoFitCol.Checked = false;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 目標データ検索処理
		/// </summary>
		/// <param name="extrInfo">検索条件</param>
		/// <remarks>
		/// <br>Note		: 目標データを検索します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.23</br>
		/// </remarks>
		private bool SearchSalesTarget(ExtrInfo_MAMOK09197EA extrInfo)
		{
			// 拠点目標検索
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.Section;
			bool bStatus = SearchSalesTarget(out this._sectionSalesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
			// 従業員目標検索
			//----- ueno upd---------- start 2007.11.21
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndEmp;
			//----- ueno upd---------- end   2007.11.21
			bStatus = SearchSalesTarget(out this._employeeSalesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}

			// 商品目標検索
			//----- ueno upd---------- start 2007.11.21
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndMaker;
			//----- ueno upd---------- end   2007.11.21
			bStatus = SearchSalesTarget(out this._goodsSalesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}

//----- ueno add---------- start 2007.11.21
			// 得意先目標検索
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndCust;
			bStatus = SearchSalesTarget(out this._customerSalesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
//----- ueno add---------- end   2007.11.21

			//----- ueno del---------- start 2007.11.21
			//// 売上形式目標検索
			//extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesFormal;
			//bStatus = SearchSalesTarget(out this._salesFormalSalesTargetList, extrInfo);
			//if (!bStatus)
			//{
			//    return (false);
			//}
			//// 販売形態目標検索
			//extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesForm;
			//bStatus = SearchSalesTarget(out this._salesFormSalesTargetList, extrInfo);
			//if (!bStatus)
			//{
			//    return (false);
			//}
			//----- ueno del---------- end   2007.11.21

			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 目標データ取得処理
		/// </summary>
		/// <param name="salesTargetList">目標データリスト</param>
		/// <param name="extrInfo">検索条件</param>
		/// <remarks>
		/// <br>Note		: 目標データを取得します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.17</br>
		/// </remarks>
		private bool SearchSalesTarget(out List<SalesTarget> salesTargetList, ExtrInfo_MAMOK09197EA extrInfo)
		{
			int status = this._salesTargetAcs.Search(out salesTargetList, extrInfo, ConstantManagement.LogicalMode.GetData0);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					break;
				default:
					TMsgDisp.Show(this, 						// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
						this.Name,								// アセンブリID
						ctPGNM, 			 　　				// プログラム名称
						"Search",								// 処理名称
						TMsgDisp.OPE_GET,						// オペレーション
						"目標データの読み込みに失敗しました",	// 表示するメッセージ
						status,									// ステータス値
						this._salesTargetAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,					// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン
					return (false);
			}
			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 検索条件設定処理
		/// </summary>
		/// <param name="extrInfo">検索条件</param>
		/// <remarks>
		/// <br>Note		: 検索条件の設定を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.17</br>
		/// </remarks>
		private void GetExtrInfo(out ExtrInfo_MAMOK09197EA extrInfo)
		{
			extrInfo = new ExtrInfo_MAMOK09197EA();

			// 企業コード
			extrInfo.EnterpriseCode = this._enterpriseCode;
			// 拠点コード
			extrInfo.SelectSectCd = new string[1];
			extrInfo.SelectSectCd[0] = this._sectionCode;
			// 目標設定区分
			extrInfo.TargetSetCd = (int)this.TargetSetCd_uOptionSet.Value;
			// 目標区分コード
			extrInfo.TargetDivideCode = this.TargetDivideCode_tEdit.DataText;
			// 目標区分名称
			extrInfo.TargetDivideName = this.TargetDivideName_tEdit.DataText;

			if ((int)this.TargetSetCd_uOptionSet.Value == 10)
			{
				// 月間目標
				extrInfo.ApplyStaDateSt = DateTime.MinValue;
				if (this.ApplyEndMonth_tDateEdit.GetDateYear() != 0 &&
					this.ApplyEndMonth_tDateEdit.GetDateMonth() != 0)
				{
					extrInfo.ApplyStaDateEd = new DateTime(this.ApplyEndMonth_tDateEdit.GetDateYear(), this.ApplyEndMonth_tDateEdit.GetDateMonth(), 1);
				}
				else
				{
					extrInfo.ApplyStaDateEd = DateTime.MinValue;
				}

				if (this.ApplyStaMonth_tDateEdit.GetDateYear() != 0 &&
					this.ApplyStaMonth_tDateEdit.GetDateMonth() != 0)
				{
					extrInfo.ApplyEndDateSt = new DateTime(this.ApplyStaMonth_tDateEdit.GetDateYear(), this.ApplyStaMonth_tDateEdit.GetDateMonth(), 1);
				}
				else
				{
					extrInfo.ApplyEndDateSt = DateTime.MinValue;
				}

				extrInfo.ApplyEndDateEd = DateTime.MinValue;
			}
			else
			{
				// 個別期間目標
				extrInfo.ApplyStaDateSt = DateTime.MinValue;
				extrInfo.ApplyStaDateEd = this.ApplyEndDate_tDateEdit.GetDateTime();
				extrInfo.ApplyEndDateSt = this.ApplyStaDate_tDateEdit.GetDateTime();
				extrInfo.ApplyEndDateEd = DateTime.MinValue;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// グリッド表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 設定済みの目標データをグリッドに表示します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void DispScreen()
		{
			this.SalesTarget_uGrid.DataSource = null;
			this.SalesTarget_uGrid.DataBind();

			// テーブルの定義
			DataTable dataTable = new DataTable(SALESTARGET);

			// 月間目標
			if ((int)this.TargetSetCd_uOptionSet.Value == 10)
			{
				dataTable.Columns.Add(COL_SALESTARGET_APPLYMONTH, typeof(string));
				dataTable.Columns.Add(COL_SALESTARGET_TARGETDIVIDECODE, typeof(string));
			}
			// 個別期間目標
			else
			{
				dataTable.Columns.Add(COL_SALESTARGET_APPLYSTADATE, typeof(DateTime));
				dataTable.Columns.Add(COL_SALESTARGET_APPLYENDDATE, typeof(DateTime));
				dataTable.Columns.Add(COL_SALESTARGET_TARGETDIVIDECODE, typeof(string));
				dataTable.Columns.Add(COL_SALESTARGET_TARGETDIVIDENAME, typeof(string));
			}
			dataTable.Columns.Add(COL_SALESTARGET_SECTION, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_EMPLOYEE, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_GOODS, typeof(string));
//----- ueno add---------- start 2007.11.21
			dataTable.Columns.Add(COL_SALESTARGET_CUSTOMER, typeof(string));
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//dataTable.Columns.Add(COL_SALESTARGET_SALESFORMAL, typeof(string));
			//dataTable.Columns.Add(COL_SALESTARGET_SALESFORM, typeof(string));
			//----- ueno del---------- end   2007.11.21

			//--------------------------------------------------------
			// 目標区分コードリスト作成
			//--------------------------------------------------------
			List<string> sectionDivideCodeList = new List<string>();
			List<string> employeeDivideCodeList = new List<string>();
			List<string> goodsDivideCodeList = new List<string>();
//----- ueno add---------- start 2007.11.21
			List<string> customerDivideCodeList = new List<string>();
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//List<string> salesFormalDivideCodeList = new List<string>();
			//List<string> salesFormDivideCodeList = new List<string>();
			//----- ueno del---------- end   2007.11.21

			// 拠点目標
			foreach (SalesTarget sectionSalesTarget in this._sectionSalesTargetList)
			{
				sectionDivideCodeList.Add(sectionSalesTarget.TargetDivideCode.TrimEnd());
			}
			// 従業員目標
			foreach (SalesTarget employeeSalesTarget in this._employeeSalesTargetList)
			{
				employeeDivideCodeList.Add(employeeSalesTarget.TargetDivideCode.TrimEnd());
			}
			// 商品目標
			foreach (SalesTarget goodsSalesTarget in this._goodsSalesTargetList)
			{
				goodsDivideCodeList.Add(goodsSalesTarget.TargetDivideCode.TrimEnd());
			}
//----- ueno add---------- start 2007.11.21
			// 得意先目標
			foreach (SalesTarget customerSalesTarget in this._customerSalesTargetList)
			{
				customerDivideCodeList.Add(customerSalesTarget.TargetDivideCode.TrimEnd());
			}
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//// 売上形式目標
			//foreach (SalesTarget salesFormalSalesTarget in this._salesFormalSalesTargetList)
			//{
			//    salesFormalDivideCodeList.Add(salesFormalSalesTarget.TargetDivideCode.TrimEnd());
			//}
			//// 販売形態目標
			//foreach (SalesTarget salesFormSalesTarget in this._salesFormSalesTargetList)
			//{
			//    salesFormDivideCodeList.Add(salesFormSalesTarget.TargetDivideCode.TrimEnd());
			//}
			//----- ueno del---------- end   2007.11.21

			//--------------------------------------------------------
			// 追加リスト作成
			//--------------------------------------------------------
			List<string> createdDivideCodeList = new List<string>();

			// 拠点目標
			AddSalesTargetTableData(this._sectionSalesTargetList, ref dataTable, ref createdDivideCodeList);
			// 従業員目標
			AddSalesTargetTableData(this._employeeSalesTargetList, ref dataTable, ref createdDivideCodeList);
			// 商品目標
			AddSalesTargetTableData(this._goodsSalesTargetList, ref dataTable,ref createdDivideCodeList);
//----- ueno add---------- start 2007.11.21
			// 得意先目標
			AddSalesTargetTableData(this._customerSalesTargetList, ref dataTable, ref createdDivideCodeList);			
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//// 売上形式目標
			//AddSalesTargetTableData(this._salesFormalSalesTargetList, ref dataTable, ref createdDivideCodeList);
			//// 販売形態目標
			//AddSalesTargetTableData(this._salesFormSalesTargetList, ref dataTable, ref createdDivideCodeList);
			//----- ueno del---------- end   2007.11.21

			// 目標有無取得
			string targetDivideCode;
			foreach (DataRow dataRow in dataTable.Rows)
			{
				targetDivideCode = (string)dataRow[COL_SALESTARGET_TARGETDIVIDECODE];
				targetDivideCode = targetDivideCode.TrimEnd();

				// 拠点目標
				if (sectionDivideCodeList.Contains(targetDivideCode))
				{
					dataRow[COL_SALESTARGET_SECTION] = "有";
				}
				// 従業員目標
				if (employeeDivideCodeList.Contains(targetDivideCode))
				{
					dataRow[COL_SALESTARGET_EMPLOYEE] = "有";
				}
				// 商品目標
				if (goodsDivideCodeList.Contains(targetDivideCode))
				{
					dataRow[COL_SALESTARGET_GOODS] = "有";
				}
//----- ueno add---------- start 2007.11.21
				// 得意先目標
				if (customerDivideCodeList.Contains(targetDivideCode))
				{
					dataRow[COL_SALESTARGET_CUSTOMER] = "有";
				}
//----- ueno add---------- end   2007.11.21
				//----- ueno del---------- start 2007.11.21
				//// 売上形式目標
				//if (salesFormalDivideCodeList.Contains(targetDivideCode))
				//{
				//    dataRow[COL_SALESTARGET_SALESFORMAL] = "有";
				//}
				//// 販売形態目標
				//if (salesFormDivideCodeList.Contains(targetDivideCode))
				//{
				//    dataRow[COL_SALESTARGET_SALESFORM] = "有";
				//}
				//----- ueno del---------- end   2007.11.21
			}

			if ((int)this.TargetSetCd_uOptionSet.Value == 10)
			{
				// 月間目標
				dataTable.DefaultView.Sort = COL_SALESTARGET_APPLYMONTH + " DESC";
			}
			else
			{
				// 個別期間目標
				dataTable.DefaultView.Sort = COL_SALESTARGET_APPLYSTADATE + " DESC";
			}

			this.SalesTarget_uGrid.DataSource = dataTable.DefaultView;
			this.SalesTarget_uGrid.DataBind();

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// テーブルデータ追加処理
		/// </summary>
		/// <param name="salesTargetList">目標データリスト</param>
		/// <param name="salesTargetTable">データを追加するテーブル</param>
		/// <param name="addedDivideCodeList">追加済み目標区分コードリスト</param>
		/// <remarks>
		/// <br>Note		: 目標テーブルにデータを追加します</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private void AddSalesTargetTableData(
			List<SalesTarget> salesTargetList,
			ref DataTable salesTargetTable,
			ref List<string> addedDivideCodeList)
		{
			DataRow dataRow;

			foreach (SalesTarget salesTarget in salesTargetList)
			{
				if (addedDivideCodeList.Contains(salesTarget.TargetDivideCode.TrimEnd()))
				{
					// 既に作成済み
					continue;
				}

				// 作成済みリストに追加
				addedDivideCodeList.Add(salesTarget.TargetDivideCode.TrimEnd());

				// データ設定
				dataRow = salesTargetTable.NewRow();

				// 月間目標
				if ((int)this.TargetSetCd_uOptionSet.Value == 10)
				{
					dataRow[COL_SALESTARGET_APPLYMONTH] = salesTarget.ApplyStaDate.Year.ToString() + "年" + salesTarget.ApplyStaDate.Month.ToString("00") + "月";
					dataRow[COL_SALESTARGET_TARGETDIVIDECODE] = salesTarget.TargetDivideCode;
				}
				// 個別期間目標
				else
				{
					dataRow[COL_SALESTARGET_APPLYSTADATE] = salesTarget.ApplyStaDate;
					dataRow[COL_SALESTARGET_APPLYENDDATE] = salesTarget.ApplyEndDate;
					dataRow[COL_SALESTARGET_TARGETDIVIDECODE] = salesTarget.TargetDivideCode;
					dataRow[COL_SALESTARGET_TARGETDIVIDENAME] = salesTarget.TargetDivideName;
				}

				salesTargetTable.Rows.Add(dataRow);

			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// グリッドレイアウト設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: グリッドのレイアウト設定を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void InitializeLayout()
		{
			// 月間目標
			if ((int)this.TargetSetCd_uOptionSet.Value == 10)
			{
				// 対象月
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYMONTH].Width = WIDTH_SALESTARGET_APPLYMONTH;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYMONTH].Header.Caption = VIEW_SALESTARGET_APPLYMONTH;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYMONTH].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYMONTH].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYMONTH].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYMONTH].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYMONTH].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYMONTH].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			}
			// 個別期間目標
			else
			{
				// 適用期間（開始）
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYSTADATE].Width = WIDTH_SALESTARGET_APPLYSTADATE;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYSTADATE].Header.Caption = VIEW_SALESTARGET_APPLYSTADATE;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYSTADATE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYSTADATE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYSTADATE].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYSTADATE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYSTADATE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYSTADATE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

				// 適用期間（終了）
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYENDDATE].Width = WIDTH_SALESTARGET_APPLYENDDATE;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYENDDATE].Header.Caption = VIEW_SALESTARGET_APPLYENDDATE;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYENDDATE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYENDDATE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYENDDATE].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYENDDATE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYENDDATE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYENDDATE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

				// 目標区分名称
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDENAME].Width = WIDTH_SALESTARGET_TARGETDIVIDENAME;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDENAME].Header.Caption = VIEW_SALESTARGET_TARGETDIVIDENAME;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDENAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDENAME].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDENAME].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDENAME].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDENAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDENAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			}
			// 目標区分コード
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDECODE].Width = WIDTH_SALESTARGET_TARGETDIVIDECODE;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDECODE].Header.Caption = VIEW_SALESTARGET_TARGETDIVIDECODE;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDECODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDECODE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDECODE].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDECODE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDECODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDECODE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

			// 拠点目標
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTION].Width = WIDTH_SALESTARGET_SECTION;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTION].Header.Caption = VIEW_SALESTARGET_SECTION;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTION].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTION].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTION].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTION].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTION].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTION].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

			// 従業員目標
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEE].Width = WIDTH_SALESTARGET_EMPLOYEE;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEE].Header.Caption = VIEW_SALESTARGET_EMPLOYEE;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEE].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

			// 商品目標
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODS].Width = WIDTH_SALESTARGET_GOODS;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODS].Header.Caption = VIEW_SALESTARGET_GOODS;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODS].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODS].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODS].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODS].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODS].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODS].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

//----- ueno add---------- start 2007.11.21
			// 得意先目標
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMER].Width = WIDTH_SALESTARGET_CUSTOMER;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMER].Header.Caption = VIEW_SALESTARGET_CUSTOMER;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMER].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMER].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMER].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMER].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMER].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
//----- ueno add---------- end   2007.11.21

			//----- ueno del---------- start 2007.11.21
			//// 売上形式目標
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].Width = WIDTH_SALESTARGET_SALESFORMAL;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].Header.Caption = VIEW_SALESTARGET_SALESFORMAL;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

			//// 販売形態目標
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].Width = WIDTH_SALESTARGET_SALESFORM;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].Header.Caption = VIEW_SALESTARGET_SALESFORM;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//----- ueno del---------- end   2007.11.21
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 入力日付チェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 入力日付のチェックを行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.25</br>
		/// </remarks>
		private bool CheckInputDate()
		{
			string errMsg = "";

			try
			{
				// 月間目標
				if ((int)this.TargetSetCd_uOptionSet.Value == 10)
				{
					// 適用月（開始）
					if (this.ApplyStaMonth_tDateEdit.GetDateYear() != 0 ||
						this.ApplyStaMonth_tDateEdit.GetDateMonth() != 0)
					{
						if (this.ApplyStaMonth_tDateEdit.GetDateYear() == 0 ||
							this.ApplyStaMonth_tDateEdit.GetDateMonth() == 0)
						{
							errMsg = "日付を正しく入力してください";
							this.ApplyStaMonth_tDateEdit.Focus();
							return (false);
						}
					}

					if (this.ApplyStaMonth_tDateEdit.GetDateYear() != 0 &&
						this.ApplyStaMonth_tDateEdit.GetDateMonth() != 0)
					{
						try
						{
							DateTime dummyDateTime = new DateTime(
								this.ApplyStaMonth_tDateEdit.GetDateYear(),
								this.ApplyStaMonth_tDateEdit.GetDateMonth(),
								1);
						}
						catch (ArgumentOutOfRangeException)
						{
							errMsg = "日付を正しく入力してください";
							this.ApplyStaMonth_tDateEdit.Focus();
							return (false);
						}
					}

					// 適用月(終了)
					if (this.ApplyEndMonth_tDateEdit.GetDateYear() != 0 ||
						this.ApplyEndMonth_tDateEdit.GetDateMonth() != 0)
					{
						if (this.ApplyEndMonth_tDateEdit.GetDateYear() == 0 ||
							this.ApplyEndMonth_tDateEdit.GetDateMonth() == 0)
						{
							errMsg = "日付を正しく入力してください";
							this.ApplyEndMonth_tDateEdit.Focus();
							return (false);
						}
					}

					if (this.ApplyEndMonth_tDateEdit.GetDateYear() != 0 &&
						this.ApplyEndMonth_tDateEdit.GetDateMonth() != 0)
					{
						try
						{
							DateTime dummyDateTime = new DateTime(
								this.ApplyEndMonth_tDateEdit.GetDateYear(),
								this.ApplyEndMonth_tDateEdit.GetDateMonth(),
								1);
						}
						catch (ArgumentOutOfRangeException)
						{
							errMsg = "日付を正しく入力してください";
							this.ApplyEndMonth_tDateEdit.Focus();
							return (false);
						}
					}

					if (this.ApplyStaDate_tDateEdit.GetLongDate() > this.ApplyEndDate_tDateEdit.GetLongDate())
					{
						errMsg = "開始　<  終了　で指定してください";
						this.ApplyStaDate_tDateEdit.Focus();
						return (false);
					}
				}
				// 個別期間目標
				else
				{
					// 適用期間（開始）
					if (this.ApplyStaDate_tDateEdit.GetDateYear() != 0 ||
						this.ApplyStaDate_tDateEdit.GetDateMonth() != 0 ||
						this.ApplyStaDate_tDateEdit.GetDateDay() != 0)
					{
						if (this.ApplyStaDate_tDateEdit.GetDateYear() == 0 ||
							this.ApplyStaDate_tDateEdit.GetDateMonth() == 0 ||
							this.ApplyStaDate_tDateEdit.GetDateDay() == 0)
						{
							errMsg = "日付を正しく入力してください";
							this.ApplyStaDate_tDateEdit.Focus();
							return (false);
						}
					}

					if (this.ApplyStaDate_tDateEdit.GetDateYear() != 0 &&
						this.ApplyStaDate_tDateEdit.GetDateMonth() != 0 &&
						this.ApplyStaDate_tDateEdit.GetDateDay() != 0)
					{
						try
						{
							DateTime dummyDateTime = new DateTime(
								this.ApplyStaDate_tDateEdit.GetDateYear(),
								this.ApplyStaDate_tDateEdit.GetDateMonth(),
								this.ApplyStaDate_tDateEdit.GetDateDay());
						}
						catch (ArgumentOutOfRangeException)
						{
							errMsg = "日付を正しく入力してください";
							this.ApplyStaDate_tDateEdit.Focus();
							return (false);
						}
					}

					// 適用期間（終了）
					if (this.ApplyEndDate_tDateEdit.GetDateYear() != 0 ||
						this.ApplyEndDate_tDateEdit.GetDateMonth() != 0 ||
						this.ApplyEndDate_tDateEdit.GetDateDay() != 0)
					{
						if (this.ApplyEndDate_tDateEdit.GetDateYear() == 0 ||
							this.ApplyEndDate_tDateEdit.GetDateMonth() == 0 ||
							this.ApplyEndDate_tDateEdit.GetDateDay() == 0)
						{
							errMsg = "日付を正しく入力してください";
							this.ApplyEndDate_tDateEdit.Focus();
							return (false);
						}
					}

					if (this.ApplyEndDate_tDateEdit.GetDateYear() != 0 &&
						this.ApplyEndDate_tDateEdit.GetDateMonth() != 0 &&
						this.ApplyEndDate_tDateEdit.GetDateDay() != 0)
					{
						try
						{
							DateTime dummyDateTime = new DateTime(
								this.ApplyEndDate_tDateEdit.GetDateYear(),
								this.ApplyEndDate_tDateEdit.GetDateMonth(),
								this.ApplyEndDate_tDateEdit.GetDateDay());
						}
						catch (ArgumentOutOfRangeException)
						{
							errMsg = "日付を正しく入力してください";
							this.ApplyEndDate_tDateEdit.Focus();
							return (false);
						}
					}

					if (this.ApplyStaDate_tDateEdit.GetDateTime() != DateTime.MinValue &&
						this.ApplyEndMonth_tDateEdit.GetDateTime() != DateTime.MinValue)
					{
						if (this.ApplyStaDate_tDateEdit.GetLongDate() > this.ApplyEndDate_tDateEdit.GetLongDate())
						{
							errMsg = "開始　<=  終了　で指定してください";
							this.ApplyStaDate_tDateEdit.Focus();
							return (false);
						}
					}
				}
			}
			finally
			{
				if (errMsg.Length > 0)
				{
					TMsgDisp.Show(
							this, 									// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_EXCLAMATION, 	// エラーレベル
							this.Name,								// アセンブリID
							errMsg, 								// 表示するメッセージ
							0,										// ステータス値
							MessageBoxButtons.OK);					// 表示するボタン
				}
			}
			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// コントロールサイズ設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: コントロールサイズの設定を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.17</br>
		/// </remarks>
		private void SetControlSize()
		{
			this.TargetDivideName_tEdit.Size = new Size(306, 24);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// コントロール入力桁数設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: コントロールの入力桁数の設定を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.17</br>
		/// </remarks>
		private void SetNumberOfControlChar()
		{
			this.TargetDivideName_tEdit.MaxLength = 30;
		}

		# endregion Private Methods

		# region Control Events

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Form_Load イベント処理(MAMOK09190UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォームロード処理を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void MAMOK09190UA_Load(object sender, EventArgs e)
		{
			// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.LoadSkin();

			// 画面スキン変更
			this._controlScreenSkin.SettingScreenSkin(this);

			// 日付の背景色設定
			this.ApplyStaMonth_tDateEdit.BackColor = Color.FromArgb(220, 230, 230);
			this.ApplyEndMonth_tDateEdit.BackColor = Color.FromArgb(220, 230, 230);
			this.ApplyStaDate_tDateEdit.BackColor = Color.FromArgb(220, 230, 230);
			this.ApplyEndDate_tDateEdit.BackColor = Color.FromArgb(220, 230, 230);

			// コントロールサイズ設定
			SetControlSize();

			// コントロール入力桁数設定
			SetNumberOfControlChar();

			// 選択中拠点
			this.SectionName_tComboEditor.Value = this._sectionCode;
			// 拠点選択可能
			if (this._selectedSectionFlg == true)
			{
				this.SectionName_tComboEditor.Enabled = true;
			}
			// 拠点選択不可
			else
			{
				this.SectionName_tComboEditor.Enabled = false;
			}

			this.TargetSetCd_uOptionSet.Value = this._targetSetCd;

			// XMLデータ読込
			LoadStateXmlData();

			// グリッド表示
			DispScreen();
			// グリッドスタイル設定
			InitializeLayout();

//----- ueno add---------- start 2007.11.21
			// 月間目標
			if ((int)this.TargetSetCd_uOptionSet.Value == 10)
			{
				// 目標区分名称は入力不可
				this.TargetDivideName_tEdit.Enabled = false;
				this.TargetDivideName_tEdit.Clear();
			}
			// 個別期間目標
			else
			{
				// 目標区分名称は入力可
				this.TargetDivideName_tEdit.Enabled = true;
			}
//----- ueno add---------- end   2007.11.21

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(Search_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 検索ボタンをクリックした時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void Search_Button_Click(object sender, EventArgs e)
		{
			// 入力チェック
			bool status = CheckInputDate();
			if (!status)
			{
				return;
			}

			// 検索条件取得
			ExtrInfo_MAMOK09197EA extrInfo;
			GetExtrInfo(out extrInfo);

			// 目標データ検索
			status = SearchSalesTarget(extrInfo);
			if (!status)
			{
				return;
			}

			// 確定ボタン
			ButtonTool workButton = Main_ToolbarsManager.Tools["Decision_ButtonTool"] as ButtonTool;

			// 目標データが1件も無い場合
			if (this._sectionSalesTargetList.Count < 1 &&
				this._employeeSalesTargetList.Count < 1 &&
				this._goodsSalesTargetList.Count < 1 &&
//----- ueno add---------- start 2007.11.21
				this._customerSalesTargetList.Count < 1)			
//----- ueno add---------- start 2007.11.21
				//----- ueno del---------- start 2007.11.21
				//this._salesFormalSalesTargetList.Count < 1 &&
				//this._salesFormSalesTargetList.Count < 1)
				//----- ueno del---------- end   2007.11.21
			{
				if (workButton != null) workButton.SharedProps.Enabled = false;
			}
			// 目標データがある場合
			else
			{
				if (workButton != null) workButton.SharedProps.Enabled = true;
			}

			// グリッド表示
			DispScreen();
			// グリッドスタイル設定
			InitializeLayout();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ToolClick イベント処理(Main_ToolbarsManager)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ツールバーボタンをクリックした時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.27</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "Return_ButtonTool":
					// XMLデータ保存
					SaveStateXmlData();
					this.DialogResult = DialogResult.Cancel;
					this.Close();
					break;
				case "Decision_ButtonTool":
					// XMLデータ保存
					SaveStateXmlData();
					this.DialogResult = DialogResult.OK;
					this.Close();
					break;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ValueChanged イベント処理(SectionName_tComboEditor)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ドロップダウンリストの選択が変更した時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void SectionName_tComboEditor_ValueChanged(object sender, EventArgs e)
		{
			this._sectionCode = (string)this.SectionName_tComboEditor.Value;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ValueChanged イベント処理(TargetSetCd_uOptionSet)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: ラジオボタンのチェックが変更した時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.23</br>
		/// </remarks>
		private void TargetSetCd_uOptionSet_ValueChanged(object sender, EventArgs e)
		{
			this.ApplyStaMonth_tDateEdit.SetDateTime(new DateTime());
			this.ApplyEndMonth_tDateEdit.SetDateTime(new DateTime());
			this.ApplyStaDate_tDateEdit.SetDateTime(new DateTime());
			this.ApplyEndDate_tDateEdit.SetDateTime(new DateTime());

			// 月間目標
			if ((int)this.TargetSetCd_uOptionSet.Value == 10)
			{
				this.ApplyStaMonth_tDateEdit.Enabled = true;
				this.ApplyEndMonth_tDateEdit.Enabled = true;
				this.ApplyStaDate_tDateEdit.Enabled = false;
				this.ApplyEndDate_tDateEdit.Enabled = false;

//----- ueno add---------- start 2007.11.21
				// 目標区分名称は入力不可
				this.TargetDivideName_tEdit.Enabled = false;
				this.TargetDivideName_tEdit.Clear();
//----- ueno add---------- end   2007.11.21

			}
			// 個別期間目標
			else
			{
				this.ApplyStaDate_tDateEdit.Enabled = true;
				this.ApplyEndDate_tDateEdit.Enabled = true;
				this.ApplyStaMonth_tDateEdit.Enabled = false;
				this.ApplyEndMonth_tDateEdit.Enabled = false;

//----- ueno add---------- start 2007.11.21
				// 目標区分名称は入力可
				this.TargetDivideName_tEdit.Enabled = true;
//----- ueno add---------- end   2007.11.21

			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// DoubleClickRow イベント処理(SalesTarget_uGrid)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: グリッドの行をダブルクリックした時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void SalesTarget_uGrid_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// フォントサイズ変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォントサイズの値が変更された後に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void cmbFontSize_ValueChanged(object sender, EventArgs e)
		{
			// フォントサイズを変更
			this.SalesTarget_uGrid.DisplayLayout.Appearance.FontData.SizeInPoints
				= (int)cmbFontSize.Value;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 列サイズの自動調整チェックチェンジイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: チェックボックスのチェック状態が変更されたタイミングで発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.27</br>
		/// </remarks>
		private void uceAutoFitCol_CheckedChanged(object sender, EventArgs e)
		{
			if (this.SalesTarget_uGrid.DataSource != null)
			{
				if (this.uceAutoFitCol.Checked)
				{
					this.SalesTarget_uGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
				}
				else
				{
					this.SalesTarget_uGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
					InitializeLayout();
				}
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// tArrowKeyControlChangeFocusイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			int rowCount = this.SalesTarget_uGrid.Rows.Count;

			// Nextフォーカスがグリッドの場合
			if (e.NextCtrl == this.SalesTarget_uGrid)
			{
				if (this.SalesTarget_uGrid.Rows.Count > 0)
				{
					if (this.SalesTarget_uGrid.ActiveRow != null)
					{
						if (!this.SalesTarget_uGrid.ActiveRow.Selected)
						{
							this.SalesTarget_uGrid.ActiveRow.Selected = true;
						}
					}
					else
					{
						this.SalesTarget_uGrid.Rows[0].Activate();
						this.SalesTarget_uGrid.Rows[0].Selected = true;
					}
					return;
				}
				else
				{
					if (e.Key == Keys.Up)
					{
						e.NextCtrl = this.TargetSetCd_uOptionSet;
					}
					else if (e.Key == Keys.Down)
					{
						e.NextCtrl = this.cmbFontSize;
					}
					else if (e.Key == Keys.Tab || e.Key == Keys.Enter)
					{
						e.NextCtrl = this.cmbFontSize;
					}
				}
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// KeyDown イベント(SalesTarget_uGrid)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: カーソルボタンを押した時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.28</br>
		/// </remarks>
		private void SalesTarget_uGrid_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.SalesTarget_uGrid.Rows.Count < 1)
			{
				return;
			}

			int rowCount = this.SalesTarget_uGrid.Rows.Count;
			int rowIndex = this.SalesTarget_uGrid.ActiveRow.Index;

			if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
			{
				if (rowIndex == 0)
				{
					this.TargetSetCd_uOptionSet.Focus();
				}
			}
			else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
			{
				if (rowIndex + 1 == rowCount)
				{
					this.cmbFontSize.Focus();
				}
			}
		}

		# endregion Control Events
	}

	/// <summary>
	/// 目標データ比較クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 目標データの比較を行います。</br>
	/// <br>Programmer	: NEPCO</br>
	/// <br>Date		: 2007.04.27</br>
	/// </remarks>
	public class SalesTargetDataCompApplyStaDate : IComparer<SalesTarget>
	{
		#region IComparer<SalesTarget> メンバ

		/// <summary>
		/// 目標データ比較処理
		/// </summary>
		/// <param name="x">比較用目標データ</param>
		/// <param name="y">比較用目標データ</param>
		/// <remarks>
		/// <br>Note		: 適用期間（開始）の比較を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.27</br>
		/// </remarks>
		public int Compare(SalesTarget x, SalesTarget y)
		{
			if (x.ApplyStaDate > y.ApplyStaDate)
			{
				return (-1);
			}
			else if (x.ApplyStaDate == y.ApplyStaDate)
			{
				if (x.ApplyEndDate > y.ApplyEndDate)
				{
					return (-1);
				}
				else if (x.ApplyEndDate == y.ApplyEndDate)
				{
					return (0);
				}
				else
				{
					return (1);
				}
			}
			else
			{
				return (1);
			}
		}

		#endregion
	}
}