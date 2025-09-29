using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.Misc;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 支払処理フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 支払処理を行うフォームクラスです。</br>
	/// <br>Programer  : 19077 渡邉貴裕</br>
	/// <br>Date       : 2007.05.18</br>
	/// </remarks>
	public partial class MAKAU00148UA : Form
	{
		//==================================================================
		//  コンストラクタ
		//==================================================================
		#region コンストラクタ
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public MAKAU00148UA()
		{
			InitializeComponent();

            /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
            //SuplierPayAcs = SuplierPayAcs.GetInstance();

            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }
            // 明細列情報表示生成
            _colDispInfo = new ProductStockDisplayStatus();
            // 定義ファイルより初期値取得
            _colDispInfo.DeserializeData(ctFILE_ColDispInfo);
            // 定義ファイルを正しく読み込めたか？
            if (_colDispInfo.CheckDisplayStatus() == false)
            {
                // 初期値にする。
                _colDispInfo.SetDefaultValue();
            }
            this._customerInfoAcs = new CustomerInfoAcs();
            this._suplierPayAcs = new SuplierPayAcs();                        

            //------ アイコン設定 ------
            this.Customer01_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer02_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer03_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer04_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer05_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer06_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer07_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer08_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer09_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer10_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            
            // 画面初期化
            AllDispClear(false);
            
            // フォーカス設定
            TotalDay_tNedit.Focus();    
                --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        }
		#endregion

        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
		//--------------------------------------------------------
		//  プライベート変数
		//--------------------------------------------------------
		#region プライベート変数

        private ArrayList _stockRet = new ArrayList();

        /// <summary>
        /// 製番在庫アクセスクラス
        /// </summary>
        private SuplierPayAcs _suplierPayAcs;

		/// <summary>
		/// 伝票明細列表示ステータス
		/// </summary>
//		private ProductStockDisplayStatus _colDispInfo = null;
        /// <summary>
        /// 企業コード
        /// </summary>
		private string _enterpriseCode;

		/// <summary>
		/// イベント制御フラグ
		/// </summary>
		private bool _localEventBlockFlg = false;

        private UltraButton _pushBtn = null;
        private int[] _customerTotalDay;

        private CustomerInfoAcs _customerInfoAcs;

		#endregion

		//--------------------------------------------------------
		//  プライベート定数
		//--------------------------------------------------------
		#region プライベート定数
		/// <summary>明細列表示ステータスファイル名称</summary>
		private const string ctFILE_ColDispInfo = "MAKAU00148U.DAT";
		
		/// <summary>PGID</summary>
		private const string ctPGID = "MAKAU00148U";
		#endregion

		//==================================================================
		//  パブリックイベント
		//==================================================================
        public static event GetSectionEventHandler GetSection;
        public delegate string GetSectionEventHandler();

        public string _sectionCd;

        //--------------------------------------------------------
		//  インターフェース実装部
		//--------------------------------------------------------
		#region インターフェース実装部
		#region IStockEntryTbsCtrlChild メンバ
		/// <summary>
		/// 画面表示メソッド
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <remarks>
		/// <br>Note       : パラメータ付きで画面表示を行います。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public void Show(object parameter)
		{
			this.Show();
		}

		#endregion

		#region IStockEntryTbsCtrlChildEdit メンバ
		/// <summary>
		/// StaticMemoryの情報を保存します。
		/// </summary>
		/// <param name="sender"></param>
		/// <returns></returns>
		public int SaveStaticMemoryData(object sender)
		{
			// 入力中のデータを決定する。
			// エディット系
			Control wkCtrl = this.ActiveControl;
			if (wkCtrl != null)
			{
				if (wkCtrl is EmbeddableTextBoxWithUIPermissions)
				{
					wkCtrl = wkCtrl.Parent;

					if ((wkCtrl is TNedit) && (wkCtrl.Parent != null) && (wkCtrl.Parent is TDateEdit))
					{
						wkCtrl = wkCtrl.Parent;
					}
				}

				this.tRetKeyControl_ChangeFocus(wkCtrl, new ChangeFocusEventArgs(false, false, false, Keys.Enter, wkCtrl, wkCtrl));
			}

			return 0;
		}

		/// <summary>
		/// エラー項目を表示します。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="ErrorItems"></param>
		/// <returns></returns>
		public int ShowErrorItems(object sender, ArrayList ErrorItems)
		{
			// 未実装
			return 0;
		}
		#endregion

		#region IStockEntryTbsCtrlChildEvent メンバ
		/// <summary>
		/// タブ子画面アクティブ時処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void EntryTabChildFormActivated(object sender, EventArgs e)
		{
			// 製番在庫アクセスクラスの明細変更イベントにハンドラを追加
//			SuplierPayAcs.SlipDtlColChanged += PtSuplSlipAcs_SlipDtlColChanged;

			// 製番在庫アクセスクラスの明細テーブル行変更イベントにハンドラを追加
//			SuplierPayAcs.SlipDtlRowChanged += SlipDtlDataTable_SlipDtlRowChanged;

            // フォーカス設定
            TotalDay_tNedit.Focus();
		}

		/// <summary>
		/// タブ子画面非アクティブ時処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		public int EntryTabChildFormDeactivate(object sender, EventArgs e)
		{
			return 0;
		}

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <returns></returns>
        public int CheckInput()
        {
            return CheckInputData();
        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <returns></returns>
        private int CheckInputData()
        {
            int result = 0;
            //締日
            if (LastDay_CheckEditor.Checked != true)
            {
                int chkInt = (int)TotalDay_tNedit.GetInt();
                if ((chkInt <= 0) || ((chkInt > 31) && (chkInt != 99)))
                {
                    return 1;
                }
            }

            if (Target_uOptionSet.CheckedIndex != 0)
            {
                //得意先個別全て空白
                if ((CustomerCode1_tNedit.Text.Trim() == "") &&
                    (CustomerCode2_tNedit.Text.Trim() == "") &&
                    (CustomerCode3_tNedit.Text.Trim() == "") &&
                    (CustomerCode4_tNedit.Text.Trim() == "") &&
                    (CustomerCode5_tNedit.Text.Trim() == "") &&
                    (CustomerCode6_tNedit.Text.Trim() == "") &&
                    (CustomerCode7_tNedit.Text.Trim() == "") &&
                    (CustomerCode8_tNedit.Text.Trim() == "") &&
                    (CustomerCode9_tNedit.Text.Trim() == "") &&
                    (CustomerCode10_tNedit.Text.Trim() == ""))
                {
                    return 2;
                }

                //得意先重複
                int[] chkInt;
                chkInt = new int[10];
                chkInt[0] = CustomerCode1_tNedit.GetInt();
                chkInt[1] = CustomerCode2_tNedit.GetInt();
                chkInt[2] = CustomerCode3_tNedit.GetInt();
                chkInt[3] = CustomerCode4_tNedit.GetInt();
                chkInt[4] = CustomerCode5_tNedit.GetInt();
                chkInt[5] = CustomerCode6_tNedit.GetInt();
                chkInt[6] = CustomerCode7_tNedit.GetInt();
                chkInt[7] = CustomerCode8_tNedit.GetInt();
                chkInt[8] = CustomerCode9_tNedit.GetInt();
                chkInt[9] = CustomerCode10_tNedit.GetInt();

                for (int i = 0; i < 10; i++)
                {
                    for (int ii = i; ii < 10; ii++)
                    {
                        if ((chkInt[i] != 0) && (i != ii) && (chkInt[i] == chkInt[ii]))
                        {
                            return 3;
                        }
                    }
                }
            }

            // 日付の有効性
            try
            {
                int year = tDateEdit1.GetDateYear();
                int month = tDateEdit1.GetDateMonth();
                int day = tDateEdit1.GetDateDay();
                DateTime datetime = new DateTime(year, month, day);
            }
            catch
            {
                return 4;
            }

            return result;            
        }

        /// <summary>
        /// 締処理
        /// </summary>
        public int ExecuteSaveProc()
        {
            string msg;
            int status = SaveProc(out msg);
            if (status != 0)
            {
                if (String.IsNullOrEmpty(msg))
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, "更新に失敗しました。"　+  " : " + status.ToString(), 0, MessageBoxButtons.OK);
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, msg + " : " + status.ToString() , 0, MessageBoxButtons.OK);
                }
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, "更新しました", 0, MessageBoxButtons.OK);
            }
            return status;
        }

        /// <summary>
        /// 締処理実体
        /// </summary>
        private int SaveProc(out string msg)
        {
            int retTotalCnt = 0;
            
            ArrayList setCustomer = new ArrayList();
            ArrayList setTotalDay = new ArrayList();

            int totalDay = 0;

            if (LastDay_CheckEditor.Checked)
            {
                //チェックあり=>末日
                totalDay = 99;
            }
            else if (TotalDay_tNedit.Text.ToString().Trim() != "")
            {
                totalDay = Int32.Parse(this.TotalDay_tNedit.Text.ToString());
            }

            //仕入先
            if (CustomerCode1_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode1_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode2_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode2_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode3_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode3_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode4_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode4_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode5_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode5_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode6_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode6_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode7_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(System.Int32.Parse(CustomerCode7_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode8_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode8_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode9_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(System.Int32.Parse(CustomerCode9_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode10_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode10_tNedit.Text.ToString().Trim()));
            }

            for (int i = 0; i < 10; i++)
            {
                setTotalDay.Add(_customerTotalDay[i]);
            }

            int setOption = (int)Target_uOptionSet.CheckedItem.DataValue;

            DateTime addUpdate = tDateEdit1.GetDateTime();
            DateTime addupYM = addUpdate;

            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
            //return _suplierPayAcs.RegistDmdData(out retTotalCnt, this._enterpriseCode, this._sectionCd,addUpdate,addupYM, setCustomer, setTotalDay, totalDay, setOption,1,out msg);
            msg = "";
            return 0;
            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<
        }
                
        /// <summary>
        /// 締解除
        /// </summary>
        public int ExecuteDelProc()
        {
            string msg ;
            int status = DelProc(out msg);
            if (status != 0)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    msg,
                    status,
                    MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "締解除しました",
                    status,
                    MessageBoxButtons.OK);
            }
            return status;
        }

        /// <summary>
        /// 締解除実処理
        /// </summary>
        private int DelProc(out string msg)
        {
            int retTotalCnt = 0;

            ArrayList setCustomer = new ArrayList();
            ArrayList setTotalDay = new ArrayList();

            int totalDay = 0;

            if (LastDay_CheckEditor.Checked)
            {
                totalDay = 99;
            }
            else if (this.TotalDay_tNedit.Text.ToString().Trim() != "")
            {
                totalDay = Int32.Parse(this.TotalDay_tNedit.Text.ToString());
            }

            //int setOption = Target_uOptionSet.CheckedIndex;
            int setOption = (int)Target_uOptionSet.Value;

            //仕入先
            if (CustomerCode1_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode1_tNedit.Text.ToString().Trim())); 
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode2_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode2_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode3_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode3_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode4_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode4_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode5_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode5_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode6_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode6_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode7_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode7_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode8_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode8_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode9_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode9_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode10_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode10_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }

            for (int i = 0; i < 10; i++)
            {
                setTotalDay.Add(_customerTotalDay[i]);
            }

            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
            //return _suplierPayAcs.BanishDmdData(out retTotalCnt, _enterpriseCode, _sectionCd, setCustomer, setTotalDay, totalDay, setOption, 1, out msg);
            msg = "";
            return 0;
            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<
        }

		#endregion

		#region IStockEntryTbsCtrlChildCheck メンバ
		/// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <param name="sender"></param>
		/// <returns></returns>
		public int CheckInputData(object sender)
		{
			string message = "";
			bool errFlg = false;
			Control invalidCtrl = null;

            // 明細行チェック
            if (!errFlg)
            {
            }
            
            if (errFlg)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, message, 0, MessageBoxButtons.OK);

				if (invalidCtrl != null)
				{
					invalidCtrl.Focus();
				}

				return 1;
			}

			return 0;
		}
		#endregion

		#region IStockEntryTbsCtrlChildResponse メンバ
		/// <summary>
		/// 親アクション対応処理
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="targetInstance">対応対象オブジェクト</param>
		/// <param name="actionKey">アクション識別キー</param>
		/// <param name="param">アクションパラメータ</param>
		/// <returns></returns>
		public int ChildResponse(object sender, object targetInstance, string actionKey, object param)
		{
			int st = 0;

			// このインスタンスへの要求かどうかの判定
			if (targetInstance.Equals(this))
			{
				switch (actionKey)
				{
					//-- バーコード入力イベント通知
					case "BarcodeRead":
						// ガイドが表示中でもフレームから通知が来るので,そのときはガイド側の処理にまかす。
//						if (this._tspBarcodeInputGuide.IsGuideShowing) return 0;

						// スクロール制御
						break;
					//-- 特殊NewEntry処理
					case "SpecificNewEntry":
						break;
                }
			}

			return st;
		}
		#endregion
		#endregion

		//--------------------------------------------------------
		//  コントロールイベントハンドラ
		//--------------------------------------------------------
		#region コントロールイベントハンドラ

        #region DEL 2008/08/08 使用していないのでコメントアウト
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 伝票種別コンボボックス値変更イベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void cmbSlipKindDiv_ValueChanged(object sender, EventArgs e)
		{
			// イベント制御判定
			if (_localEventBlockFlg) return;
		}

		/// <summary>
		/// ツールバードロップダウン前イベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ToolbarsManager_Main_BeforeToolDropdown(object sender, Infragistics.Win.UltraWinToolbars.BeforeToolDropdownEventArgs e)
		{
			// ドロップダウンする前に各メニューアイテムの状態を設定する
			if ((e.Tool.Key == "PopupMenuTool_Edit") && (e.Tool is Infragistics.Win.UltraWinToolbars.PopupMenuTool))
			{
				Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenu = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)e.Tool;

				// メニューアイテム設定
				Boolean dispFlg = false;

				// メニューを表示可能か？
				e.Cancel = (!dispFlg);

				if (!e.Cancel)
				{
				}
			}
		}

		/// <summary>
		/// ツールバークローズアップ後イベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ToolbarsManager_Main_AfterToolCloseup(object sender, Infragistics.Win.UltraWinToolbars.ToolDropdownEventArgs e)
		{
			if (e.Tool.Key == "PopupMenuTool_Edit")
			{
				Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenu = e.Tool as Infragistics.Win.UltraWinToolbars.PopupMenuTool;

			}
		}

		/// <summary>
		/// 明細グリッド選択状態変更後イベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void SlipGrid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
		{

		}

		/// <summary>
		/// 入力補助エクスプローラバーアイテムクリックイベントハンドラ
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ExplorerBar_InputHelp_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
		{
			this.InputHelperItemExecute(e.Item.Key);
		}

		/// <summary>
		/// 画面入力欄エンターイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void Edit_Enter(object sender, EventArgs e)
		{
		}

        /// <summary>
		/// RetKeyControllフォーカス変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void tRetKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
		}

        /// <summary>
        /// 初期フォーカスセット
        /// </summary>
        public void SetFocus()
        {
            TotalDay_tNedit.Focus();
        }

        /// <summary>
        /// 画面クリア
        /// </summary>
        public void DispClear()
        {
            // 画面初期化
            AllDispClear(false);
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <param name="TempCheck">チェック有無</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 画面を初期化</br>
        /// <br>Programer  : 19077 渡邉貴裕</br>
        /// <br>Date       : 2007.03.08</br>
        /// </remarks>
        private void AllDispClear(bool TempCheck)
        {
            int setInt = 10;
            _customerTotalDay = new int[setInt];
            for (int i = 0; i < setInt; i++)
            {
                _customerTotalDay[i] = 0;
            }
            TotalDay_tNedit.Text = "";

            ClearEmployee();

            ChangeEnableCustomer(false);

            Target_uOptionSet.CheckedIndex = 0;

            LastDay_CheckEditor.Checked = false;

            tDateEdit1.Clear();
            tDateEdit1.SetDateTime(DateTime.Now);
        }

        /// <summary>
        /// 仕入先入力可否制御
        /// </summary>
        /// <param name="enable"></param>
        private void ChangeEnableCustomer(bool enable)
        {
            CustomerCode1_tNedit.Enabled = enable;
            CustomerCode2_tNedit.Enabled = enable;
            CustomerCode3_tNedit.Enabled = enable;
            CustomerCode4_tNedit.Enabled = enable;
            CustomerCode5_tNedit.Enabled = enable;
            CustomerCode6_tNedit.Enabled = enable;
            CustomerCode7_tNedit.Enabled = enable;
            CustomerCode8_tNedit.Enabled = enable;
            CustomerCode9_tNedit.Enabled = enable;
            CustomerCode10_tNedit.Enabled = enable;

            Customer01_uButton.Enabled = enable;
            Customer02_uButton.Enabled = enable;
            Customer03_uButton.Enabled = enable;
            Customer04_uButton.Enabled = enable;
            Customer05_uButton.Enabled = enable;
            Customer06_uButton.Enabled = enable;
            Customer07_uButton.Enabled = enable;
            Customer08_uButton.Enabled = enable;
            Customer09_uButton.Enabled = enable;
            Customer10_uButton.Enabled = enable;
        }

        #endregion

        //--------------------------------------------------------
        //  内部処理
        //--------------------------------------------------------
        #region 内部処理
        /// <summary>
        /// 入力補助項目実行処理
        /// </summary>
        /// <param name="itemKey">項目キー文字列</param>
        private void InputHelperItemExecute(string itemKey)
		{
		}

		/// <summary>
		/// 品番入力チェック処理
		/// </summary>
		/// <param name="prevVal">入力済みテキスト</param>
		/// <param name="key">入力文字</param>
		/// <param name="selstart">選択開始位置</param>
		/// <param name="sellength">選択テキスト文字数</param>
		/// <returns>True:入力文字受付可, False:入力文字受付不可</returns>
		private bool KeyPressPartsNoCheck(string prevVal, char key, int selstart, int sellength)
		{
			int withHyphenLength = 24;
			int withoutHyphenLength = 20;

			// 制御キーが押された？
			if (Char.IsControl(key))
			{
				return true;
			}

			// 英数字,ハイフン以外はNG
			if (!Regex.IsMatch(key.ToString(), "[a-zA-Z0-9-]"))
			{
				return false;
			}

			// キーが押されたと仮定した場合の文字列を生成する。
			string _strResult = "";
			if (sellength > 0)
			{
				_strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
			}
			else
			{
				_strResult = prevVal;
			}

			// ハイフン数取得
			int hyphenCnt = 0;
			foreach(char wkChar in _strResult)
			{
				if (wkChar == '-') hyphenCnt++;
			}

			// ハイフン数チェック
			if ((hyphenCnt >= withHyphenLength - withoutHyphenLength) && (key == '-'))
			{
				return false;
			}

			// ハイフン無し桁数チェック
			if ((_strResult.Length - hyphenCnt >= withoutHyphenLength) && (key != '-'))
			{
				return false;
			}

			// キーが押された結果の文字列を生成する
			_strResult = prevVal.Substring(0, selstart)
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

			// 桁数チェック
			if (_strResult.Length > withHyphenLength)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// 数値入力チェック処理
		/// </summary>
		/// <param name="keta">桁数(マイナス符号を含まず)</param>
		/// <param name="priod">小数点以下桁数</param>
		/// <param name="prevVal">現在の文字列</param>
		/// <param name="key">入力されたキー値</param>
		/// <param name="selstart">カーソル位置</param>
		/// <param name="sellength">選択文字長</param>
		/// <param name="minusFlg">マイナス入力可？</param>
		/// <returns>true=入力可,false=入力不可</returns>
		private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
		{
			// 制御キーが押された？
			if (Char.IsControl(key))
			{
				return true;
			}
			// 数値以外は、ＮＧ
			if (!Char.IsDigit(key))
			{
				// 小数点または、マイナス以外
				if ((key != '.') && (key != '-'))
				{
					return false;
				}
			}

			// キーが押されたと仮定した場合の文字列を生成する。
			string _strResult = "";
			if (sellength > 0)
			{
				_strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
			}
			else
			{
				_strResult = prevVal;
			}

			// マイナスのチェック
			if (key == '-')
			{
				if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
				{
					return false;
				}
			}

			// 小数点のチェック
			if (key == '.')
			{
				if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
				{
					return false;
				}
			}
			// キーが押された結果の文字列を生成する。
			_strResult = prevVal.Substring(0, selstart)
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

			// 桁数チェック！
			if (_strResult.Length > keta)
			{
				if (_strResult[0] == '-')
				{
					if (_strResult.Length > (keta + 1))
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}

			// 小数点以下のチェック
			if (priod > 0)
			{
				// 小数点の位置決定
				int _pointPos = _strResult.IndexOf('.');

				// 整数部に入力可能な桁数を決定！
				int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
				// 整数部の桁数をチェック
				if (_pointPos != -1)
				{
					if (_pointPos > _Rketa)
					{
						return false;
					}
				}
				else
				{
					if (_strResult.Length > _Rketa)
					{
						return false;
					}
				}

				// 小数部の桁数をチェック
				if (_pointPos != -1)
				{
					// 小数部の桁数を計算
					int _priketa = _strResult.Length - _pointPos - 1;
					if (priod < _priketa)
					{
						return false;
					}
				}
			}
			return true;
		}
		#endregion

        /// <summary>
        /// 編集可否変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void methoduoptSet_ValueChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 仕入先情報取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetCustomerInf(object sender, EventArgs e)
        {
//            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
            _pushBtn = (UltraButton)sender;
            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);

            customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
        }

        /// <summary>
        /// 仕入先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">仕入先車両検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustSuppli custSuppli;
//            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            int status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo, out custSuppli);            
  
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (custSuppli == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "選択した仕入先は仕入先情報入力が行われていない為、使用出来ません。",
                        status,
                        MessageBoxButtons.OK);                    
                    return;
                }
                
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した仕入先は既に削除されています。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
            else if (customerInfo.SupplierDiv != 1)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した得意先情報は、仕入先に設定されていません。",
                    status,
                    MessageBoxButtons.OK);
                return;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "仕入先情報の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }

            if (_pushBtn != null)
            {
                if (_pushBtn == Customer01_uButton)
                {
                    CustomerCode1_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm1_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[0] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer02_uButton)
                {
                    CustomerCode2_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm2_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[1] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer03_uButton)
                {
                    CustomerCode3_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm3_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[2] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer04_uButton)
                {
                    CustomerCode4_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm4_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[3] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer05_uButton)
                {
                    CustomerCode5_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm5_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[4] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer06_uButton)
                {
                    CustomerCode6_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm6_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[5] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer07_uButton)
                {
                    CustomerCode7_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm7_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[6] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer08_uButton)
                {
                    CustomerCode8_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm8_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[7] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer09_uButton)
                {
                    CustomerCode9_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm9_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[8] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer10_uButton)
                {
                    CustomerCode10_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm10_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[9] = customerInfo.TotalDay;
                }
            }

            _pushBtn = null;

//            StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;
//            stockSlip.CustomerCode = customerSearchRet.CustomerCode;
//            stockSlip.CustomerName = customerSearchRet.Name;
//            stockSlip.CustomerName2 = customerSearchRet.Name2;

            // 仕入データクラス→画面格納処理
//            this.SetDisplay(stockSlip);
            

            // 仕入データキャッシュ処理
//            this._stockSlipInputAcs.Cache(stockSlip);
        }

        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {

        }

        private bool CheckValue(ref object sender,ref int setCode)
        {
            bool exist = false;
            
            if (sender == CustomerCode1_tNedit)
            {
                if ((CustomerCode1_tNedit.Text.Trim() != "") && (CustomerCode1_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode1_tNedit.Text.Trim());
                    exist = true;
                }
            }
            else if (sender == CustomerCode2_tNedit) 
            {
                if ((CustomerCode2_tNedit.Text.Trim() != "") && (CustomerCode2_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode2_tNedit.Text.Trim());
                    exist = true;
                }
            }
            else if (sender == CustomerCode3_tNedit)
            {
                if ((CustomerCode3_tNedit.Text.Trim() != "") && (CustomerCode3_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode3_tNedit.Text.Trim());
                    exist = true;
                }
            }
            else if (sender == CustomerCode4_tNedit)
            {
                if ((CustomerCode4_tNedit.Text.Trim() != "") && (CustomerCode4_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode4_tNedit.Text.Trim());
                    exist = true;
                }
            }
            else if (sender == CustomerCode5_tNedit)
            {
                if ((CustomerCode5_tNedit.Text.Trim() != "") && (CustomerCode5_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode5_tNedit.Text.Trim());
                    exist = true;
                }                
            }
            else if (sender == CustomerCode6_tNedit)
            {
                if ((CustomerCode6_tNedit.Text.Trim() != "") && (CustomerCode6_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode6_tNedit.Text.Trim());
                    exist = true;
                }                
            }
            else if (sender == CustomerCode7_tNedit)
            {
                if ((CustomerCode7_tNedit.Text.Trim() != "") && (CustomerCode7_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode7_tNedit.Text.Trim());
                    exist = true;
                }
            }
            else if (sender == CustomerCode8_tNedit)
            {
                if ((CustomerCode8_tNedit.Text.Trim() != "") && (CustomerCode8_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode8_tNedit.Text.Trim());
                    exist = true;
                }
            }
            else if (sender == CustomerCode9_tNedit)
            {
                if ((CustomerCode9_tNedit.Text.Trim() != "") && (CustomerCode9_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode9_tNedit.Text.Trim());
                    exist = true;
                }
            }
            else if (sender == CustomerCode10_tNedit)
            {
                if ((CustomerCode10_tNedit.Text.Trim() != "") && (CustomerCode10_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode10_tNedit.Text.Trim());
                    exist = true;
                }
            }
            return exist;
        }

        private void TotalDay_tNedit_AfterExitEditMode(object sender, EventArgs e)
        {
            //請求日付を変更します。
            int setDay = TotalDay_tNedit.GetInt();
            if (setDay != 0)
            {
                // 支払日変更処理
                ChangeDate(setDay);
            }
        }

        /// <summary>
        /// 支払日変更
        /// </summary>
        /// <param name="totalday"></param>
        private void ChangeDate(int totalday)
        {
            int year = tDateEdit1.GetDateYear();
            int month = tDateEdit1.GetDateMonth();
            int day = tDateEdit1.GetDateDay();
            if (totalday < 28)
            {
                day = totalday;
            }
            else if (totalday > 31)
            {
                day = SetMaxDay(year, month);
            }
            else
            {
                int chkday = SetMaxDay(year, month);

                if (chkday == totalday)
                {
                    day = chkday;
                }
                else if (totalday > chkday)
                {
                    day = chkday;
                }
            }
            DateTime setDate = new DateTime(year,month,day);
            tDateEdit1.SetDateTime(setDate);
        }

        /// <summary>
        /// 末日取得
        /// </summary>
        /// <param name="targetDay"></param>
        /// <returns></returns>
        private int SetMaxDay(int year,int month)
        {
            int totalday = DateTime.Today.Day;

            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
            //switch (month)
            //{
            //    case 1:
            //    case 3:
            //    case 5:
            //    case 7:
            //    case 8:
            //    case 10:
            //    case 12:
            //        {
            //            totalday = 31;
            //            break;
            //        }
            //    case 2:
            //        if (DateTime.IsLeapYear(year))
            //        {
            //            totalday = 29;
            //        }
            //        else
            //        {
            //            totalday = 28;
            //        }
            //        break;
            //    case 4:
            //    case 6:
            //    case 9:
            //    case 11:
            //        {
            //            totalday = 30;
            //            break;
            //        }
            //}
            try
            {
                totalday = DateTime.DaysInMonth(year, month);
            }
            catch
            {
                totalday = DateTime.Today.Day;
            }
            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<

            return totalday;
        }

        /// <summary>
        /// 締日一致チェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerCode_tNedit_BeforeExitEditMode(object sender, Infragistics.Win.BeforeExitEditModeEventArgs e)
        {
            CustomerInfo customerInfo = new CustomerInfo();

            int setCode = 0;
            bool exist = false;

            exist = CheckValue(ref sender, ref setCode);

            if (exist)
            {
                //入力が確認されたときの処理
                int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, setCode, out customerInfo);
                
                if (status == 0)
                {
                    //締日チェック
                    int totalDay = customerInfo.TotalDay;

                    //チェック対象か判定
                    bool chkTarget = false;

                    //if ((totalDay < 28) && ((TotalDay_tNedit.GetInt() >= 28) || (LastDay_CheckEditor.Checked == true)))

                    if ((TotalDay_tNedit.GetInt() == 0) || (TotalDay_tNedit.GetInt() == 99))
                    {
                        chkTarget = false;
                    }
                    else if (totalDay < 28)
                    {
                        chkTarget = true;
                    }
                    else if ((totalDay > 28) && (LastDay_CheckEditor.Checked != true))
                    {
                        chkTarget = true;
                    }
                    if (chkTarget)
                    {
                        if (totalDay != TotalDay_tNedit.GetInt())
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "締日が異なる仕入先です",
                                status,
                                MessageBoxButtons.OK);

                            //Objectを取得
                            TNedit errNedit = new TNedit();
                            errNedit = (TNedit)sender;

                            errNedit.Focus();

                            return;
                        }
                    }
                    if (customerInfo.SupplierDiv != 1)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "選択した得意先情報は、仕入先に設定されていません。",
                            status,
                            MessageBoxButtons.OK);
                        ((TNedit)sender).Focus();
                        return;
                    }


                    if (sender == CustomerCode1_tNedit)
                    {
                        CustomerNm1_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[0] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode2_tNedit)
                    {
                        CustomerNm2_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[1] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode3_tNedit)
                    {
                        CustomerNm3_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[2] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode4_tNedit)
                    {
                        CustomerNm4_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[3] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode5_tNedit)
                    {
                        CustomerNm5_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[4] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode6_tNedit)
                    {
                        CustomerNm6_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[5] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode7_tNedit)
                    {
                        CustomerNm7_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[6] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode8_tNedit)
                    {
                        CustomerNm8_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[7] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode9_tNedit)
                    {
                        CustomerNm9_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[8] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode10_tNedit)
                    {
                        CustomerNm10_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[9] = customerInfo.TotalDay;
                    }
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "該当する仕入先はありません。",
                        status,
                        MessageBoxButtons.OK);
                    if (sender == CustomerCode1_tNedit)
                    {
                        CustomerNm1_tEdit.Text = "";
                        _customerTotalDay[0] = 0;
                        CustomerCode1_tNedit.Focus();
                    }
                    else if (sender == CustomerCode2_tNedit)
                    {
                        CustomerNm2_tEdit.Text = "";
                        _customerTotalDay[1] = 1;
                        CustomerCode2_tNedit.Focus();
                    }
                    else if (sender == CustomerCode3_tNedit)
                    {
                        CustomerNm3_tEdit.Text = "";
                        _customerTotalDay[2] = 2;
                        CustomerCode3_tNedit.Focus();
                    }
                    else if (sender == CustomerCode4_tNedit)
                    {
                        CustomerNm4_tEdit.Text = "";
                        _customerTotalDay[3] = 3;
                        CustomerCode4_tNedit.Focus();
                    }
                    else if (sender == CustomerCode5_tNedit)
                    {
                        CustomerNm5_tEdit.Text = "";
                        _customerTotalDay[4] = 4;
                        CustomerCode5_tNedit.Focus();
                    }
                    else if (sender == CustomerCode6_tNedit)
                    {
                        CustomerNm6_tEdit.Text = "";
                        _customerTotalDay[5] = 5;
                        CustomerCode6_tNedit.Focus();
                    }
                    else if (sender == CustomerCode7_tNedit)
                    {
                        CustomerNm7_tEdit.Text = "";
                        _customerTotalDay[6] = 6;
                        CustomerCode7_tNedit.Focus();
                    }
                    else if (sender == CustomerCode8_tNedit)
                    {
                        CustomerNm8_tEdit.Text = "";
                        _customerTotalDay[7] = 7;
                        CustomerCode8_tNedit.Focus();
                    }
                    else if (sender == CustomerCode9_tNedit)
                    {
                        CustomerNm9_tEdit.Text = "";
                        _customerTotalDay[8] = 8;
                        CustomerCode9_tNedit.Focus();
                    }
                    else if (sender == CustomerCode10_tNedit)
                    {
                        CustomerNm10_tEdit.Text = "";
                        _customerTotalDay[9] = 9;
                        CustomerCode10_tNedit.Focus();
                    }
                }
            }
            else
            {
                //名称部分のみクリアしておく
                if (sender == CustomerCode1_tNedit)
                {
                    CustomerNm1_tEdit.Text = "";
                    _customerTotalDay[0] = 0;
                }
                else if (sender == CustomerCode2_tNedit)
                {
                    CustomerNm2_tEdit.Text = "";
                    _customerTotalDay[1] = 1;
                }
                else if (sender == CustomerCode3_tNedit)
                {
                    CustomerNm3_tEdit.Text = "";
                    _customerTotalDay[2] = 2;
                }
                else if (sender == CustomerCode4_tNedit)
                {
                    CustomerNm4_tEdit.Text = "";
                    _customerTotalDay[3] = 3;
                }
                else if (sender == CustomerCode5_tNedit)
                {
                    CustomerNm5_tEdit.Text = "";
                    _customerTotalDay[4] = 4;
                }
                else if (sender == CustomerCode6_tNedit)
                {
                    CustomerNm6_tEdit.Text = "";
                    _customerTotalDay[5] = 5;
                }
                else if (sender == CustomerCode7_tNedit)
                {
                    CustomerNm7_tEdit.Text = "";
                    _customerTotalDay[6] = 6;
                }
                else if (sender == CustomerCode8_tNedit)
                {
                    CustomerNm8_tEdit.Text = "";
                    _customerTotalDay[7] = 7;
                }
                else if (sender == CustomerCode9_tNedit)
                {
                    CustomerNm9_tEdit.Text = "";
                    _customerTotalDay[8] = 8;
                }
                else if (sender == CustomerCode10_tNedit)
                {
                    CustomerNm10_tEdit.Text = "";
                    _customerTotalDay[9] = 9;
                }
            }           
        }

        private void Target_uOptionSet_ValueChanged(object sender, EventArgs e)
        {
            switch ((int)Target_uOptionSet.CheckedItem.DataValue)
            {
                case 1: ChangeEnableCustomer(false);
                    ClearEmployee();
                    break;
                case 2: ChangeEnableCustomer(true);
                    break;
                case 3: ChangeEnableCustomer(true);
                    break;
            }
        }

        /// <summary>
        /// 担当者情報クリア
        /// </summary>
        private void ClearEmployee()
        {
            CustomerCode1_tNedit.Text = "";
            CustomerCode2_tNedit.Text = "";
            CustomerCode3_tNedit.Text = "";
            CustomerCode4_tNedit.Text = "";
            CustomerCode5_tNedit.Text = "";
            CustomerCode6_tNedit.Text = "";
            CustomerCode7_tNedit.Text = "";
            CustomerCode8_tNedit.Text = "";
            CustomerCode9_tNedit.Text = "";
            CustomerCode10_tNedit.Text = "";

            CustomerNm1_tEdit.Text = "";
            CustomerNm2_tEdit.Text = "";
            CustomerNm3_tEdit.Text = "";
            CustomerNm4_tEdit.Text = "";
            CustomerNm5_tEdit.Text = "";
            CustomerNm6_tEdit.Text = "";
            CustomerNm7_tEdit.Text = "";
            CustomerNm8_tEdit.Text = "";
            CustomerNm9_tEdit.Text = "";
            CustomerNm10_tEdit.Text = "";
        }

        private void LastDay_CheckEditor_CheckedValueChanged(object sender, EventArgs e)
        {
            if (LastDay_CheckEditor.Checked != true)
            {
                TotalDay_tNedit.Enabled = true;
            }
            else
            {
                TotalDay_tNedit.Value = 99;
                TotalDay_tNedit.Text = "";
                TotalDay_tNedit.Enabled = false;
                SetLastDay();
            }
        }

        /// <summary>
        /// 月末日セット
        /// </summary>
        private void SetLastDay()
        {
            DateTime datetime = tDateEdit1.GetDateTime();
//            string sEndDate = DateTime.Parse(datetime.AddMonths(1).ToString("yyyy/MM/01")).AddDays(-1).ToShortDateString();
            datetime = DateTime.Parse(datetime.AddMonths(1).ToString("yyyy/MM/01")).AddDays(-1);
            tDateEdit1.SetDateTime(datetime);
        }
            --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
    }
}