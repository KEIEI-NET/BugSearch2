using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 個別目標編集画面
	/// </summary>
	/// <remarks>
	/// <br>Note			 : 個別目標の編集を行う画面です。</br>
	/// <br>Programmer		 : NEPCO</br>
	/// <br>Date			 : 2007.05.21</br>
	/// <br>Update Note		 : 2007.11.21 上野 弘貴</br>
	/// <br>                   流通.DC用に変更（項目追加・削除）</br>
	/// </remarks>
	public partial class MAMOK09190UB : Form
	{
		# region Private Constants

		// PG名称
		private const string ctPGNM = "個別目標編集";

		# endregion Private Constants

		# region Private Members

		// 企業コード
		private string _enterpriseCode;
		// 拠点コード
		private string _sectionCode;
		// 拠点名
		private string _sectionName;
		// 目標データ
		private SalesTarget _salesTarget;

		// 目標マスタアクセスクラス
		private SalesTargetAcs _salesTargetAcs;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		# endregion Private Members

		# region Constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MAMOK09190UB()
		{
			InitializeComponent();

			// 企業コードを取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// 拠点名称取得
			SecInfoSet secInfoSet;
			SecInfoAcs secInfoAcs = new SecInfoAcs();
			secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
			this._sectionCode = secInfoSet.SectionCode.TrimEnd();
			this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();

			// 目標マスタアクセスクラス初期化
			this._salesTargetAcs = new SalesTargetAcs();

			// アイコン画像の設定
			// 終了ボタン
			this.Close_Button.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.CLOSE];
			// 保存ボタン
			this.Save_Button.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.SAVE];

		}

		# endregion Constructor

		# region Public Propaties

		/// public propaty name  :	SalesTarget
		/// <summary>目標データプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 目標データプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public SalesTarget SalesTarget
		{
			get
			{
				return this._salesTarget;
			}
			set
			{
				this._salesTarget = value;
			}
		}

		# endregion Public Propaties

		# region Private Methods

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 目標データ画面展開処理
		/// </summary>
		/// <param name="salesTarget">目標データ</param>
		/// <remarks>
		/// Note	   : 修正対象の目標データを画面に展開します。<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.03<br />
		/// </remarks>
		private void SalesTargetToScreen(SalesTarget salesTarget)
		{
			// 目標設定区分
			this.TargetSetCd_uOptionSet.Value = salesTarget.TargetSetCd;
			// 拠点名称
			this.SectionName_tEdit.DataText = this._sectionName;
			// 適用期間（開始）
			this.ApplyStaDate_tDateEdit.SetDateTime(salesTarget.ApplyStaDate);
			// 適用期間（終了）
			this.ApplyEndDate_tDateEdit.SetDateTime(salesTarget.ApplyEndDate);
			// 目標区分コード
			this.TargetDivideCode_tEdit.DataText = salesTarget.TargetDivideCode;
			// 目標区分名称
			this.TargetDivideName_tEdit.DataText = salesTarget.TargetDivideName;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 入力データチェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 入力データのチェックを行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private bool CheckInputData()
		{
			string errMsg = "";

			try
			{
				// 適用期間（開始）
				if (this.ApplyStaDate_tDateEdit.GetDateYear() == 0 ||
					this.ApplyStaDate_tDateEdit.GetDateMonth() == 0 ||
					this.ApplyStaDate_tDateEdit.GetDateDay() == 0)
				{
                    errMsg = "日付を正しく入力してください";
					this.ApplyStaDate_tDateEdit.Focus();
					return (false);
				}
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

                if (this.ApplyStaDate_tDateEdit.GetDateYear() < 1900)
                {
                    errMsg = "日付を正しく入力してください";
                    this.ApplyStaDate_tDateEdit.Focus();
                    return (false);
                }

				// 適用期間（終了）
				if (this.ApplyEndDate_tDateEdit.GetDateYear() == 0 ||
					this.ApplyEndDate_tDateEdit.GetDateMonth() == 0 ||
					this.ApplyEndDate_tDateEdit.GetDateDay() == 0)
				{
                    errMsg = "日付を正しく入力してください";
					this.ApplyEndDate_tDateEdit.Focus();
					return (false);
				}
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

                if (this.ApplyEndDate_tDateEdit.GetDateYear() < 1900)
                {
                    errMsg = "日付を正しく入力してください";
                    this.ApplyEndDate_tDateEdit.Focus();
                    return (false);
                }

				if (this.ApplyStaDate_tDateEdit.GetDateTime() > this.ApplyEndDate_tDateEdit.GetDateTime())
				{
					errMsg = "開始　<=  終了で指定してください";
					this.ApplyStaDate_tDateEdit.Focus();
					return (false);
				}
				// 目標区分名称
				if (this.TargetDivideName_tEdit.DataText == "")
				{
					errMsg = "目標区分名称を入力してください";
					this.TargetDivideName_tEdit.Focus();
					return (false);
				}

			}
			finally
			{
				if (errMsg.Length > 0)
				{
					TMsgDisp.Show(
							this, 							// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
							this.Name,						// アセンブリID
							errMsg, 						// 表示するメッセージ
							0,								// ステータス値
							MessageBoxButtons.OK);			// 表示するボタン
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
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void SetControlSize()
		{
			this.TargetDivideCode_tEdit.Size = new Size(84, 24);
			this.TargetDivideName_tEdit.Size = new Size(290, 24);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// コントロール入力桁数設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: コントロールの入力桁数の設定を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void SetNumberOfControlChar()
		{
			this.TargetDivideCode_tEdit.MaxLength = 9;
			this.TargetDivideName_tEdit.MaxLength = 30;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 目標データ保存
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: 目標設定区分および目標区分コードが同じ目標データを保存します</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private bool SaveTargetData()
		{
			DateTime applyStaDate;
			DateTime applyEndDate;
			string targetDivideName;
			bool retResult;

			// 画面からデータを取得
			GetScreenData(out applyStaDate, out applyEndDate, out targetDivideName);

			// 目標データ検索
			List<List<SalesTarget>> salesTargetLists;
			retResult = SearchSalesTargetMain(out salesTargetLists);
			if (!retResult)
			{
				return (false);
			}

			// 目標データ更新
			List<SalesTarget> saveSalesTargetList;
			foreach (List<SalesTarget> salesTargetList in salesTargetLists)
			{
				saveSalesTargetList = new List<SalesTarget>();
				foreach (SalesTarget salesTarget in salesTargetList)
				{
					salesTarget.ApplyStaDate = applyStaDate;
					salesTarget.ApplyEndDate = applyEndDate;
					salesTarget.TargetDivideName = targetDivideName;

					saveSalesTargetList.Add(salesTarget);
				}
				retResult = UpdateSalesTarget(saveSalesTargetList);
				if (!retResult)
				{
					return (false);
				}
			}

			this._salesTarget.ApplyStaDate = applyStaDate;
			this._salesTarget.ApplyEndDate = applyEndDate;
			this._salesTarget.TargetDivideName = targetDivideName;

			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 画面から入力データを取得する
		/// </summary>
		/// <param name="applyStaDate">適用開始日</param>
		/// <param name="applyEndDate">適用終了日</param>
		/// <param name="targetDivideName">目標区分名称</param>
		/// <remarks>
		/// <br>Note		: 画面から入力されたデータを取得します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void GetScreenData(out DateTime applyStaDate, out DateTime applyEndDate, out string targetDivideName)
		{
			// 適用期間（開始）
			applyStaDate = this.ApplyStaDate_tDateEdit.GetDateTime();

			// 適用期間（終了）
			applyEndDate = this.ApplyEndDate_tDateEdit.GetDateTime();

			// 目標区分名称
			targetDivideName = this.TargetDivideName_tEdit.DataText;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 目標データ検索処理
		/// </summary>
		/// <param name="salesTargetLists">目標データリスト</param>
		/// <remarks>
		/// <br>Note		: 目標データを検索します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private bool SearchSalesTargetMain(out List<List<SalesTarget>> salesTargetLists)
		{
			ExtrInfo_MAMOK09197EA extrInfo;
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

			salesTargetLists = new List<List<SalesTarget>>();
			List<SalesTarget> salesTargetList;

			// 拠点目標検索
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.Section;
			bool bStatus = SearchSalesTarget(out salesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
			salesTargetLists.Add(salesTargetList);

			// 従業員目標検索
			//----- ueno upd---------- start 2007.11.21
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndEmp;
			//----- ueno upd---------- end   2007.11.21
			bStatus = SearchSalesTarget(out salesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
			salesTargetLists.Add(salesTargetList);

			// 商品目標検索
			//----- ueno upd---------- start 2007.11.21
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods;
			//----- ueno upd---------- end   2007.11.21
			bStatus = SearchSalesTarget(out salesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
			salesTargetLists.Add(salesTargetList);

//----- ueno add---------- start 2007.11.21

			// 得意先目標検索
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndCust;
			bStatus = SearchSalesTarget(out salesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
			salesTargetLists.Add(salesTargetList);

//----- ueno add---------- end   2007.11.21

			//----- ueno del---------- start 2007.11.21
			//// 売上形式目標検索
			//extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesFormal;
			//bStatus = SearchSalesTarget(out salesTargetList, extrInfo);
			//if (!bStatus)
			//{
			//    return (false);
			//}
			//salesTargetLists.Add(salesTargetList);

			//// 販売形態目標検索
			//extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesForm;
			//bStatus = SearchSalesTarget(out salesTargetList, extrInfo);
			//if (!bStatus)
			//{
			//    return (false);
			//}
			//salesTargetLists.Add(salesTargetList);
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
		/// 目標データ更新処理
		/// </summary>
		/// <param name="saveSalesTargetList">更新データ</param>
		/// <remarks>
		/// <br>Note		: 目標データを更新します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private bool UpdateSalesTarget(List<SalesTarget> saveSalesTargetList)
		{
			string checkMessage;

			// 目標データ更新
			int status = this._salesTargetAcs.Write(ref saveSalesTargetList);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					break;
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    checkMessage = "既に他端末より更新されています";
                    TMsgDisp.Show(
                        this,									// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	// エラーレベル
                        this.Name,								// アセンブリID
                        checkMessage,							// 表示するメッセージ
                        status,									// ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                    return (false);
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    checkMessage = "既に他端末より削除されています";
                    TMsgDisp.Show(
                        this, 						                // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	    // エラーレベル
                        this.Name,								    // アセンブリID
                        checkMessage,		                        // 表示するメッセージ
                        status,									    // ステータス値
                        MessageBoxButtons.OK);					    // 表示するボタン
                    return (false);
				default:
					checkMessage = "目標データ修正時にエラーが発生しました";
                    TMsgDisp.Show(
                        this, 						                // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOP,			    // エラーレベル
                        this.Name,								    // アセンブリID
                        ctPGNM, 		  　　					    // プログラム名称
                        "UpdateSalesTarget",						            // 処理名称
                        TMsgDisp.OPE_UPDATE,					    // オペレーション
                        checkMessage,	                            // 表示するメッセージ
                        status,									    // ステータス値
                        this._salesTargetAcs,					    // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,			  		    // 表示するボタン
                        MessageBoxDefaultButton.Button1);		    // 初期表示ボタン
                    return (false);
			}

			return (true);

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 終了前処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面の終了前に処理します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private bool BeforeClose()
		{
			bool retResult;
			DateTime applyStaDate;
			DateTime applyEndDate;
			string targetDivideName;

			// 画面からデータを取得
			GetScreenData(out applyStaDate, out applyEndDate, out targetDivideName);

			if (this._salesTarget.ApplyStaDate.Date != applyStaDate ||
				this._salesTarget.ApplyEndDate.Date != applyEndDate ||
				this._salesTarget.TargetDivideName != targetDivideName)
			{
				DialogResult res = TMsgDisp.Show(
							this, 								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
							this.Name,							// アセンブリID
							"", 								// 表示するメッセージ
							0,									// ステータス値
							MessageBoxButtons.YesNoCancel);		// 表示するボタン
				switch (res)
				{
					case DialogResult.Yes:
						// 保存
						retResult = SaveTargetData();
						if (!retResult)
						{
							return (false);
						}
						this.DialogResult = DialogResult.OK;
						return (true);
					case DialogResult.No:
						return (true);
					case DialogResult.Cancel:
						return (false);
				}
			}
			return (true);
		}

		# endregion Private Methods

		# region Control Events

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Form_Load イベント処理(MAMOK09190UB)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォームロード処理を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void MAMOK09190UB_Load(object sender, EventArgs e)
		{
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

			this.SectionName_tEdit.DataText = this._sectionName;

			SetControlSize();
			SetNumberOfControlChar();

			// 目標データ画面展開
			SalesTargetToScreen(this._salesTarget);

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(Save_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 保存ボタンがクリックされた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void Save_Button_Click(object sender, EventArgs e)
		{
			// 入力チェック
			bool retResult = CheckInputData();
			if (!retResult)
			{
				return;
			}

			// 保存
			retResult = SaveTargetData();
			if (!retResult)
			{
				return;
			}

			this.DialogResult = DialogResult.OK;

			this.Close();

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(Close_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 閉じるボタンがクリックされた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void Close_Button_Click(object sender, EventArgs e)
		{
			bool retResult = BeforeClose();
			if (!retResult)
			{
				return;
			}

			this.Close();
		}

		# endregion Control Events
	}
}