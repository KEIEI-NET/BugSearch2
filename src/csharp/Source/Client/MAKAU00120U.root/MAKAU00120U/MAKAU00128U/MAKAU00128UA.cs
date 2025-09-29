//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：売上締次更新
// プログラム概要   ：売上締次更新を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2008/08/08     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/06     修正内容：Mantis【10079】全拠点指定対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22018 鈴木 正臣
// 修正日    2010/08/17     修正内容：締次ロック対応
// ---------------------------------------------------------------------//

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
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.Misc;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 売上締次更新フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 売上締次更新を行うフォームクラスです。</br>
	/// <br>Programer  : 19077 渡邉貴裕</br>
	/// <br>Date       : 2007.04.03</br>
    /// <br>Update Note: 2008/08/08 30414 忍 幸史 Partsman用に変更</br>
    /// <br>Update Note: 2010/08/17 22018 鈴木 正臣　締次ロック対応</br>
    /// </remarks>
	public partial class MAKAU00128UA : Form
	{
		//==================================================================
		//  コンストラクタ
		//==================================================================
		#region コンストラクタ
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public MAKAU00128UA()
		{
			InitializeComponent();                        
            
            //CustDmdPrcAcs = CustDmdPrcAcs.GetInstance();

            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }
/*
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
*/
            /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
            this._customerInfoAcs = new CustomerInfoAcs();
               --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/

            this._custDmdPrcAcs = new CustDmdPrcAcs();

            // --- ADD 2008/08/08 --------------------------------------------------------------------->>>>>
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._billAllStAcs = new BillAllStAcs();

            this._totalDayCalculator = TotalDayCalculator.GetInstance();
            this._totalDayCalculator.InitializeHisDmdC();

            this._billAllStDic = new Dictionary<string, BillAllSt>();

            // 請求全体設定マスタ読込
            LoadBillAllSt();
            // --- ADD 2008/08/08 ---------------------------------------------------------------------<<<<<

            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
            ////------ アイコン設定 ------
            //this.Customer01_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer02_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer03_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer04_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer05_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer06_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer07_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer08_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer09_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer10_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            //// 画面初期化
            //AllDispClear(false);
            
            //// フォーカス設定
            //tNedit_TotalDay.Focus();

            //------ アイコン設定 ------
            this.uButton_SectionGuide.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // 画面初期化
            AllDispClear();

            // 画面初期設定
            InitializeSetting();

            // フォーカス設定
            //this.tEdit_SectionCode.Focus();       // DEL 2009/04/06
            SetFocus();                             // ADD 2009/04/06
            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<
        }
		#endregion

		//--------------------------------------------------------
		//  プライベート変数
		//--------------------------------------------------------
		#region プライベート変数

        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
        private ArrayList _stockRet = new ArrayList();
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// 製番在庫アクセスクラス
        /// </summary>
        private CustDmdPrcAcs _custDmdPrcAcs;

		/// <summary>
		/// 伝票明細列表示ステータス
		/// </summary>
//		private ProductStockDisplayStatus _colDispInfo = null;

        /// <summary>
        /// 企業コード
        /// </summary>
		private string _enterpriseCode;

        // --- ADD 2008/08/08 --------------------------------------------------------------------->>>>>
        private SecInfoAcs _secInfoAcs;
        private SecInfoSetAcs _secInfoSetAcs;
        private BillAllStAcs _billAllStAcs;
        private TotalDayCalculator _totalDayCalculator;
        
        private Dictionary<string, BillAllSt> _billAllStDic;

        private string _prevSectionCode;

        private int _convertProcessDivCd;

        // プログラムID
        private const string ASSEMBLY_ID = "MAKAU00128U";
        // --- ADD 2008/08/08 ---------------------------------------------------------------------<<<<<

        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// イベント制御フラグ
		/// </summary>
		private bool _localEventBlockFlg = false;

        private UltraButton _pushBtn = null;
        private int[] _customerTotalDay;

        private CustomerInfoAcs _customerInfoAcs;
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/

        private const string SECTION_CODE_COMMON = "00";    // ADD 2009/04/06
        
        #endregion

        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
        //--------------------------------------------------------
		//  プライベート定数
		//--------------------------------------------------------
		#region プライベート定数
		/// <summary>明細列表示ステータスファイル名称</summary>
		private const string ctFILE_ColDispInfo = "MAKAU00128U.DAT";
		
		/// <summary>PGID</summary>
		private const string ctPGID = "MAKAU00128U";
		#endregion

		//==================================================================
		//  パブリックイベント
		//==================================================================
        public static event GetSectionEventHandler GetSection;
        public delegate string GetSectionEventHandler();

        public string _sectionCd;
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/

        //--------------------------------------------------------
		//  インターフェース実装部
		//--------------------------------------------------------
		#region インターフェース実装部

        #region DEL 2008/08/08 使用していないのでコメントアウト
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
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
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 使用していないのでコメントアウト

        #region IStockEntryTbsCtrlChildEvent メンバ

        #region DEL 2008/08/08 使用していないのでコメントアウト
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// タブ子画面アクティブ時処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void EntryTabChildFormActivated(object sender, EventArgs e)
		{
			// 製番在庫アクセスクラスの明細変更イベントにハンドラを追加
//			CustDmdPrcAcs.SlipDtlColChanged += PtSuplSlipAcs_SlipDtlColChanged;

			// 製番在庫アクセスクラスの明細テーブル行変更イベントにハンドラを追加
//			CustDmdPrcAcs.SlipDtlRowChanged += SlipDtlDataTable_SlipDtlRowChanged;

            tNedit_TotalDay.Focus();
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

            //得意先
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
                int year = tDateEdit_CAddUpUpdDate.GetDateYear();
                int month = tDateEdit_CAddUpUpdDate.GetDateMonth();
                int day = tDateEdit_CAddUpUpdDate.GetDateDay();
                DateTime datetime = new DateTime(year, month, day);
            }
            catch
            {
                return 4;
            }

            return result;            
        }
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 使用していないのでコメントアウト

        /// <summary>
        /// 締処理
        /// </summary>
        public int ExecuteSaveProc()
        {
            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
            //string msg;
            //int status = SaveProc(out msg);
            //if (status != 0)
            //{
            //    if (String.IsNullOrEmpty(msg))
            //    {
            //        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, "更新に失敗しました", 0, MessageBoxButtons.OK);
            //    }
            //    else
            //    {
            //        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, msg, 0, MessageBoxButtons.OK);
            //    }
            //}
            //else
            //{
            //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "更新しました", 0, MessageBoxButtons.OK);
            //}

            int status = SaveProc();
            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<

            return status;
        }

        /// <summary>
        /// 締処理実行
        /// </summary>
        private int SaveProc()
        {
            DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                            ASSEMBLY_ID,
                                            "更新してもよろしいですか？",
                                            0,
                                            MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                return (0);
            }

            // 入力チェック
            bool bStatus = CheckInputData(false);
            if (!bStatus)
            {
                return (-1);
            }

            string errMsg;

            // 拠点コード
            //string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');  // DEL 2009/04/06
            string sectionCode = SECTION_CODE_COMMON;                                       // ADD 2009/04/06
            // 今回締処理日
            DateTime cAddUpUpdDate = this.tDateEdit_CAddUpUpdDate.GetDateTime();
            // 対象締日
            int totalDay = this.tNedit_TotalDay.GetInt();

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "更新中";
            msgForm.Message = "売上締次更新処理中です。" + "\n" + "しばらくお待ちください。";

            int status;

            try
            {
                msgForm.Show();

                status = this._custDmdPrcAcs.RegistDmdData(this._enterpriseCode,
                                                               sectionCode,
                                                               cAddUpUpdDate,
                                                               totalDay,
                                                               out errMsg);
            }
            finally
            {
                msgForm.Close();
            }

            // 2009.04.02 30413 犬飼 フォームを最上位に持ってくる >>>>>>START
            this.TopMost = true;
            this.TopMost = false;
            // 2009.04.02 30413 犬飼 フォームを最上位に持ってくる <<<<<<END
            
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    ExclusiveTransaction(status);
                    return (status);
                // 企業ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    {
                        // --- UPD m.suzuki 2010/08/17 ---------->>>>>
                        //TMsgDisp.Show(this,
                        //            emErrorLevel.ERR_LEVEL_STOPDISP,
                        //            this.Name,
                        //            "更新に失敗しました。" + "\r\n"
                        //            + "\r\n" +
                        //            "シェアチェックエラー（企業ロック）です。" + "\r\n" +
                        //            "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                        //            "再試行するか、しばらく待ってから再度処理を行ってください。",
                        //            status,
                        //            MessageBoxButtons.OK);
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            "",
                            "処理が込み合っているため中断しました。" + "\r\n" +
                            "再試行するか、しばらく待ってから再度処理を実行して下さい。" + "\r\n",
                            status,
                            MessageBoxButtons.OK );
                        // --- UPD m.suzuki 2010/08/17 ----------<<<<<
                        return (status);
                    }
                // 拠点ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                // --- ADD m.suzuki 2010/08/17 ---------->>>>>
                // 締次ロック(伝票側)タイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_ADS_LOCK_TIMEOUT:
                // --- ADD m.suzuki 2010/08/17 ----------<<<<<
                    {
                        // --- UPD m.suzuki 2010/08/17 ---------->>>>>
                        //TMsgDisp.Show(this,
                        //            emErrorLevel.ERR_LEVEL_STOPDISP,
                        //            this.Name,
                        //            "更新に失敗しました。" + "\r\n"
                        //            + "\r\n" +
                        //            "シェアチェックエラー（拠点ロック）です。" + "\r\n" +
                        //            "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n" +
                        //            "再試行するか、しばらく待ってから再度処理を行ってください。",
                        //            status,
                        //            MessageBoxButtons.OK);
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            "",
                            "処理が込み合っているため中断しました。" + "\r\n" +
                            "再試行するか、しばらく待ってから再度処理を実行して下さい。" + "\r\n",
                            status,
                            MessageBoxButtons.OK );
                        // --- UPD m.suzuki 2010/08/17 ----------<<<<<
                        return (status);
                    }
                // 倉庫ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        // --- UPD m.suzuki 2010/08/17 ---------->>>>>
                        //TMsgDisp.Show(this,
                        //            emErrorLevel.ERR_LEVEL_STOPDISP,
                        //            this.Name,
                        //            "更新に失敗しました。" + "\r\n"
                        //            + "\r\n" +
                        //            "シェアチェックエラー（倉庫ロック）です。" + "\r\n" +
                        //            "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n" +
                        //            "再試行するか、しばらく待ってから再度処理を行ってください。",
                        //            status,
                        //            MessageBoxButtons.OK);
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            "",
                            "処理が込み合っているため中断しました。" + "\r\n" +
                            "再試行するか、しばらく待ってから再度処理を実行して下さい。" + "\r\n",
                            status,
                            MessageBoxButtons.OK );
                        // --- UPD m.suzuki 2010/08/17 ----------<<<<<
                        return (status);
                    }
                // --- ADD m.suzuki 2010/08/17 ---------->>>>>
                // 締次ロック(集計側)タイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_ADU_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            "",
                            "対象の期間を集計処理中のため中断しました。" + "\r\n" +
                            "再試行するか、しばらく待ってから再度処理を実行して下さい。" + "\r\n",
                            status,
                            MessageBoxButtons.OK );
                        return (status);
                    }
                // --- ADD m.suzuki 2010/08/17 ----------<<<<<
                default:
                    if ((errMsg == null) || (errMsg.Trim() == ""))
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "SaveProc",				            // 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "更新に失敗しました。",				// 表示するメッセージ 
                            status,								// ステータス値
                            this._custDmdPrcAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "SaveProc",				            // 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            errMsg,				                // 表示するメッセージ 
                            status,								// ステータス値
                            this._custDmdPrcAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                    }

                    // 該当データなし時　一時的に126にしておく
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        // 次締日設定処理
                        SetNextTotalDay(sectionCode, totalDay);
                    }
                    return (status);
            }

            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                          ASSEMBLY_ID,
                          "締次更新は完了しました。",
                          0,
                          MessageBoxButtons.OK);

            this._totalDayCalculator.ClearCache();
            this._totalDayCalculator.InitializeHisDmdC();

            // 締日設定
            SetHisTotalDayDmdC(sectionCode);

            // フォーカス設定
            SetFocus();
            
            return (status);
        }

        /// <summary>
        /// 次締日設定処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="totalDay">対象締日</param>
        private void SetNextTotalDay(string sectionCode, int totalDay)
        {
            BillAllSt billAllSt;

            if (this._billAllStDic.ContainsKey(sectionCode))
            {
                // 対象拠点の請求全体設定マスタを取得
                billAllSt = this._billAllStDic[sectionCode];
            }
            else
            {
                // 全社共通の請求全体設定マスタを取得
                billAllSt = this._billAllStDic["00"];
            }

            // 得意先締日をリストに保持
            ArrayList totalDayList = new ArrayList();

            if (billAllSt.CustomerTotalDay1 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay1);
            }
            if (billAllSt.CustomerTotalDay2 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay2);
            }
            if (billAllSt.CustomerTotalDay3 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay3);
            }
            if (billAllSt.CustomerTotalDay4 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay4);
            }
            if (billAllSt.CustomerTotalDay5 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay5);
            }
            if (billAllSt.CustomerTotalDay6 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay6);
            }
            if (billAllSt.CustomerTotalDay7 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay7);
            }
            if (billAllSt.CustomerTotalDay8 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay8);
            }
            if (billAllSt.CustomerTotalDay9 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay9);
            }
            if (billAllSt.CustomerTotalDay10 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay10);
            }

            // 設定されている締日が1以下の場合、処理終了
            if (totalDayList.Count <= 1)
            {
                return;
            }

            int index = 0;
            foreach (int day in totalDayList)
            {
                if (totalDay <= day)
                {
                    break;
                }

                index++;
            }

            // 次の締日取得
            int nextTotalDay;
            if (totalDay >= 28)
            {
                nextTotalDay = (int)totalDayList[0];
            }
            else
            {
                if (index == totalDayList.Count - 1)
                {
                    nextTotalDay = (int)totalDayList[0];
                }
                else
                {
                    nextTotalDay = (int)totalDayList[index + 1];
                }
            }

            // 入力された今回締処理日取得
            DateTime currentTotalDay = this.tDateEdit_CAddUpUpdDate.GetDateTime();

            if (totalDay > nextTotalDay)
            {
                currentTotalDay = currentTotalDay.AddMonths(1);
            }

            if (nextTotalDay >= 28)
            {
                nextTotalDay = DateTime.DaysInMonth(currentTotalDay.Year, currentTotalDay.Month);
            }

            // 今回締処理日に次の締日をセット
            this.tDateEdit_CAddUpUpdDate.SetDateTime(new DateTime(currentTotalDay.Year, currentTotalDay.Month, nextTotalDay));
            // 対象締日に次の締日をセット
            this.tNedit_TotalDay.SetInt(nextTotalDay);
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,				            // プログラム名称
                            "ExclusiveTransaction", 			// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "既に他端末より更新されています。", // 表示するメッセージ
                            status, 							// ステータス値
                            this._custDmdPrcAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,				            // プログラム名称
                            "ExclusiveTransaction", 			// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "既に他端末より削除されています。", // 表示するメッセージ
                            status, 							// ステータス値
                            this._custDmdPrcAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
            }
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="deleteFlg">True:解除前チェック False:更新前チェック</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報の入力チェックを行います。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private bool CheckInputData(bool deleteFlg)
        {
            string errMsg = "";

            try
            {
                // DEL 2009/04/06 ------>>>
                //// 拠点
                //if (this.tEdit_SectionCode.DataText.Trim() == "")
                //{
                //    errMsg = "拠点を入力してください。";
                //    this.tEdit_SectionCode.Focus();
                //    return (false);
                //}
                //string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
                //if (GetSectionName(sectionCode) == "")
                //{
                //    errMsg = "マスタに登録されていません。";
                //    this.tEdit_SectionCode.Focus();
                //    return (false);
                //}
                // DEL 2009/04/06 ------<<<
                
                // 今回締処理日
                if (this.tDateEdit_CAddUpUpdDate.GetDateTime() == DateTime.MinValue)
                {
                    errMsg = "今回締処理日を入力してください。";
                    this.tDateEdit_CAddUpUpdDate.Focus();
                    return (false);
                }
                if (this.tDateEdit_LastCAddUpUpdDate.GetDateTime() != DateTime.MinValue)
                {
                    if (this.tDateEdit_CAddUpUpdDate.GetDateTime() <= this.tDateEdit_LastCAddUpUpdDate.GetDateTime())
                    {
                        errMsg = "日付の指定に誤りがあります。";
                        this.tDateEdit_CAddUpUpdDate.Focus();
                        return (false);
                    }
                }

                // 解除前
                if (deleteFlg == true)
                {
                    // コンバート実行日
                    if (this._convertProcessDivCd == 1)
                    {
                        errMsg = "コンバート以前の締取消はできません。";
                        //this.tEdit_SectionCode.Focus();       // DEL 2009/04/06
                        this.tDateEdit_CAddUpUpdDate.Focus();   // ADD 2009/04/06
                        return (false);
                    }

                    if (this.tDateEdit_LastCAddUpUpdDate.GetDateTime() == DateTime.MinValue)
                    {
                        errMsg = "前回の締更新履歴が存在しないため、締取消処理は実行できません。";
                        //this.tEdit_SectionCode.Focus();       // DEL 2009/04/06
                        this.tDateEdit_CAddUpUpdDate.Focus();   // ADD 2009/04/06
                        return (false);
                    }
                }
                // 更新前
                else
                {
                    // 対象締日
                    if (!CheckTotalDay(out errMsg))
                    {
                        this.tNedit_TotalDay.Focus();
                        return (false);
                    }
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO, 		// エラーレベル
                        ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                        errMsg, 	                        // 表示するメッセージ
                        0, 									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン
                }
            }

            return (true);
        }

        /// <summary>
        /// 対象締日チェック処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 対象締日のチェックを行います。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private bool CheckTotalDay(out string errMsg)
        {
            errMsg = "";

            int totalDay = this.tNedit_TotalDay.GetInt();

            if (totalDay == 0)
            {
                errMsg = "対象締日を入力してください。";
                return (false);
            }
            else if (totalDay == 99)
            {
                // 対象締日が99の場合、全締日対応
                return (true);
            }

            //string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');  // DEL 2009/04/06
            string sectionCode = SECTION_CODE_COMMON;                                       // ADD 2009/04/06

            BillAllSt billAllSt;

            if (this._billAllStDic.ContainsKey(sectionCode))
            {
                // 対象拠点の請求全体設定マスタを取得
                billAllSt = this._billAllStDic[sectionCode];
            }
            else
            {
                // 対象拠点の請求全体設定マスタを取得
                billAllSt = this._billAllStDic["00"];
            }

            if (totalDay >= 28)
            {
                if ((28 > billAllSt.CustomerTotalDay1) && (28 > billAllSt.CustomerTotalDay2) &&
                    (28 > billAllSt.CustomerTotalDay3) && (28 > billAllSt.CustomerTotalDay4) &&
                    (28 > billAllSt.CustomerTotalDay5) && (28 > billAllSt.CustomerTotalDay6) &&
                    (28 > billAllSt.CustomerTotalDay7) && (28 > billAllSt.CustomerTotalDay8) &&
                    (28 > billAllSt.CustomerTotalDay9) && (28 > billAllSt.CustomerTotalDay10) &&
                    (28 > billAllSt.CustomerTotalDay11) && (28 > billAllSt.CustomerTotalDay12))
                {
                    errMsg = "請求全体設定の処理対象締日に該当締日がありません。";
                    return (false);
                }
            }
            else
            {
                if ((totalDay != billAllSt.CustomerTotalDay1) && (totalDay != billAllSt.CustomerTotalDay2) &&
                    (totalDay != billAllSt.CustomerTotalDay3) && (totalDay != billAllSt.CustomerTotalDay4) &&
                    (totalDay != billAllSt.CustomerTotalDay5) && (totalDay != billAllSt.CustomerTotalDay6) &&
                    (totalDay != billAllSt.CustomerTotalDay7) && (totalDay != billAllSt.CustomerTotalDay8) &&
                    (totalDay != billAllSt.CustomerTotalDay9) && (totalDay != billAllSt.CustomerTotalDay10) &&
                    (totalDay != billAllSt.CustomerTotalDay11) && (totalDay != billAllSt.CustomerTotalDay12))
                {
                    errMsg = "請求全体設定の処理対象締日に該当締日がありません。";
                    return (false);
                }
            }

            int year = this.tDateEdit_CAddUpUpdDate.GetDateYear();
            int month = this.tDateEdit_CAddUpUpdDate.GetDateMonth();
            int day = this.tDateEdit_CAddUpUpdDate.GetDateDay();

            // 今回締日が末日の場合、締日31日はエラーとしない
            if ((DateTime.DaysInMonth(year, month) != day) || (totalDay != 31))
            {
                if (this.tDateEdit_CAddUpUpdDate.GetDateDay() != totalDay)
                {
                    errMsg = "日付の指定に誤りがあります。";
                    return (false);
                }
            }

            return (true);
        }

        #region DEL 2008/08/08 Partsman用に変更
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
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
            }else if (TotalDay_tNedit.Text.ToString().Trim() != "")
            {
                totalDay = Int32.Parse(this.TotalDay_tNedit.Text.ToString());
            }

            //得意先
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
                setCustomer.Add(Int32.Parse(CustomerCode7_tNedit.Text.ToString().Trim()));
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
                setCustomer.Add(Int32.Parse(CustomerCode9_tNedit.Text.ToString().Trim()));
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

            DateTime addUpdate = tDateEdit_CAddUpUpdDate.GetDateTime();

            if (addUpdate == DateTime.MinValue)
            {
                msg = "締次更新年月日の指定に誤りがあります。";
                return -1;
            }

            DateTime addupYM = addUpdate;

            return _custDmdPrcAcs.RegistDmdData(out retTotalCnt, this._enterpriseCode, this._sectionCd, addUpdate, addupYM, setCustomer, setTotalDay, totalDay, setOption, 1, out msg);
        }
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 Partsman用に変更

        /// <summary>
        /// 締解除
        /// </summary>
        public int ExecuteDelProc()
        {
            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
            //string msg ;
            //int status = DelProc(out msg);
            //if (status != 0)
            //{
            //    if (!String.IsNullOrEmpty(msg))
            //    {
            //        TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //            this.Name,
            //            msg,
            //            status,
            //            MessageBoxButtons.OK);
            //    }
            //    else
            //    {
            //        TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_INFO,
            //            this.Name,
            //            "締解除に失敗しました",
            //            status,
            //            MessageBoxButtons.OK);
            //    }
            //}
            //else
            //{
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_INFO,
            //        this.Name,
            //        "締解除しました",
            //        status,
            //        MessageBoxButtons.OK);
            //}
            int status = DelProc();
            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<

            return status;
        }

        /// <summary>
        /// 締解除実行処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 締解除を実行します。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        /// </remarks>
        private int DelProc()
        {
            DialogResult result = TMsgDisp.Show(
                                        this, 								                    // 親ウィンドウフォーム
                                        emErrorLevel.ERR_LEVEL_QUESTION, 		                // エラーレベル
                                        ASSEMBLY_ID, 						                    // アセンブリＩＤまたはクラスＩＤ
                                        "前回締処理日に該当する締情報の\n取消を処理します。",   // 表示するメッセージ
                                        0, 									                    // ステータス値
                                        MessageBoxButtons.YesNo);				                // 表示するボタン

            if (result == DialogResult.No)
            {
                return (-1);
            }

            // 入力チェック
            bool bStatus = CheckInputData(true);
            if (!bStatus)
            {
                return (-1);
            }

            string errMsg;

            // 拠点コード
            //string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');      // DEL 2009/04/06
            string sectionCode = SECTION_CODE_COMMON;                                           // ADD 2009/04/06
            // 前回締処理日
            DateTime lastCAddUpUpdDate = this.tDateEdit_LastCAddUpUpdDate.GetDateTime();

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "取消中";
            msgForm.Message = "売上締次更新取消中です。" + "\n" + "しばらくお待ちください。";
            
            int status;

            try
            {
                msgForm.Show();

                status = this._custDmdPrcAcs.BanishDmdData(this._enterpriseCode,
                                                               sectionCode,
                                                               lastCAddUpUpdDate,
                                                               out errMsg);
            }
            finally
            {
                msgForm.Close();
            }

            // 2009.04.02 30413 犬飼 フォームを最上位に持ってくる >>>>>>START
            this.TopMost = true;
            this.TopMost = false;
            // 2009.04.02 30413 犬飼 フォームを最上位に持ってくる <<<<<<END

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                  ASSEMBLY_ID,
                                  "解除しました。",
                                  0,
                                  MessageBoxButtons.OK);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                  ASSEMBLY_ID,
                                  errMsg,
                                  0,
                                  MessageBoxButtons.OK);
                    return (status);
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    ExclusiveTransaction(status);
                    return (status);
                // 企業ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "解除に失敗しました。" + "\r\n"
                                    + "\r\n" +
                                    "シェアチェックエラー（企業ロック）です。" + "\r\n" +
                                    "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                                    "再試行するか、しばらく待ってから再度処理を行ってください。",
                                    status,
                                    MessageBoxButtons.OK);
                        return (status);
                    }
                // 拠点ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "解除に失敗しました。" + "\r\n"
                                    + "\r\n" +
                                    "シェアチェックエラー（拠点ロック）です。" + "\r\n" +
                                    "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n" +
                                    "再試行するか、しばらく待ってから再度処理を行ってください。",
                                    status,
                                    MessageBoxButtons.OK);
                        return (status);
                    }
                // 倉庫ロックタイムアウト
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "解除に失敗しました。" + "\r\n"
                                    + "\r\n" +
                                    "シェアチェックエラー（倉庫ロック）です。" + "\r\n" +
                                    "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n" +
                                    "再試行するか、しばらく待ってから再度処理を行ってください。",
                                    status,
                                    MessageBoxButtons.OK);
                        return (status);
                    }
                default:
                    if ((errMsg == null) || (errMsg.Trim() == ""))
                    {
                        TMsgDisp.Show(this,							// 親ウィンドウフォーム
                                  emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                                  ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                                  this.Text,						// プログラム名称
                                  "DelProc",				        // 処理名称
                                  TMsgDisp.OPE_DELETE,				// オペレーション
                                  "解除に失敗しました。",			// 表示するメッセージ 
                                  status,							// ステータス値
                                  this._custDmdPrcAcs,				// エラーが発生したオブジェクト
                                  MessageBoxButtons.OK,				// 表示するボタン
                                  MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                    }
                    else
                    {
                        TMsgDisp.Show(this,							    // 親ウィンドウフォーム
                                  emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                                  ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                                  this.Text,						    // プログラム名称
                                  "DelProc",				            // 処理名称
                                  TMsgDisp.OPE_DELETE,				    // オペレーション
                                  errMsg,			                    // 表示するメッセージ 
                                  status,							    // ステータス値
                                  this._custDmdPrcAcs,				    // エラーが発生したオブジェクト
                                  MessageBoxButtons.OK,				    // 表示するボタン
                                  MessageBoxDefaultButton.Button1);	    // 初期表示ボタン
                    }

                    return (status);
            }

            this._totalDayCalculator.ClearCache();
            this._totalDayCalculator.InitializeHisDmdC();

            // 締日設定
            SetHisTotalDayDmdC(sectionCode);

            // フォーカス設定
            SetFocus();

            return (status);
        }

        #region DEL 2008/08/08 Partsman用に変更
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
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

            //得意先
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

            return _custDmdPrcAcs.BanishDmdData(out retTotalCnt, _enterpriseCode,_sectionCd, setCustomer, setTotalDay, totalDay, setOption, 1, out msg);
        }
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 Partsman用に変更

        #endregion

        #region DEL 2008/08/08 使用していないのでコメントアウト
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
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
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 使用していないのでコメントアウト

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
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 使用していないのでコメントアウト

        /// <summary>
        /// 初期フォーカスセット
        /// </summary>
        public void SetFocus()
        {
            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
            //tNedit_TotalDay.Focus();
            //this.tEdit_SectionCode.Focus();       // DEL 2009/04/06
            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<
            this.tDateEdit_CAddUpUpdDate.Focus();   // ADD 2009/04/06
        }

        /// <summary>
        /// 画面クリア
        /// </summary>
        public void DispClear()
        {
            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
            //AllDispClear(false);
            AllDispClear();
            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<
        }

        // --- ADD 2008/08/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を初期化します。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private void AllDispClear()
        {
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tDateEdit_LastCAddUpUpdDate.Clear();
            this.tDateEdit_CAddUpUpdDate.Clear();
            this.tNedit_TotalDay.Clear();

            this._prevSectionCode = "";
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private void InitializeSetting()
        {
            // DEL 2009/04/06 ------>>>
            //// 拠点コード
            //this.tEdit_SectionCode.DataText = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            //this._prevSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            //// 拠点名称
            //this.tEdit_SectionName.DataText = GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
            //// 締日設定
            //SetHisTotalDayDmdC(LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
            // DEL 2009/04/06 ------<<<

            // ADD 2009/04/06 ------>>>
            // 拠点コード
            this.tEdit_SectionCode.DataText = SECTION_CODE_COMMON;
            this._prevSectionCode = SECTION_CODE_COMMON;
            // 締日設定
            SetHisTotalDayDmdC(SECTION_CODE_COMMON);
            // ADD 2009/04/06 ------<<<
            //// 対象締日
            //this.tNedit_TotalDay.SetInt(this.tDateEdit_CAddUpUpdDate.GetDateDay());
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        break;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        /// <summary>
        /// 締日取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="lastCAddUpUpdDate">前回締日</param>
        /// <param name="currentCAddUpUpdDate">今回締日</param>
        /// <param name="convertProcessDivCd">コンバート処理区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 前回締日、今回締日を取得します。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private int GetHisTotalDayDmdC(string sectionCode, out DateTime lastCAddUpUpdDate, out DateTime currentCAddUpUpdDate, out int convertProcessDivCd)
        {
            lastCAddUpUpdDate = new DateTime();
            currentCAddUpUpdDate = new DateTime();
            convertProcessDivCd = 0;
            
            if ((sectionCode == "") || (sectionCode == "0") || (sectionCode == "00"))
            {
                // 全社の場合
                sectionCode = "";
            }
            else
            {
                // 各拠点の場合
                sectionCode = sectionCode.PadLeft(2, '0');
            }

            int status;

            try
            {
                status = this._totalDayCalculator.GetHisTotalDayDmdC(sectionCode, out lastCAddUpUpdDate, out currentCAddUpUpdDate, out convertProcessDivCd);
            }
            catch
            {
                lastCAddUpUpdDate = new DateTime();
                currentCAddUpUpdDate = new DateTime();
                convertProcessDivCd = 0;

                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 締日設定処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <remarks>
        /// <br>Note       : 前回締日、今回締日を設定します。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private void SetHisTotalDayDmdC(string sectionCode)
        {
            DateTime lastCAddUpUpdDate;
            DateTime currentCAddUpUpdDate;
            int convertProcessDivCd;

            int status = GetHisTotalDayDmdC(sectionCode, out lastCAddUpUpdDate, out currentCAddUpUpdDate, out convertProcessDivCd);
            if (status == 0)
            {
                // 前回締日設定
                this.tDateEdit_LastCAddUpUpdDate.SetDateTime(lastCAddUpUpdDate);

                // 今回締日設定
                this.tDateEdit_CAddUpUpdDate.SetDateTime(currentCAddUpUpdDate);

                // 対象締日(今回締処理日の日が28日以降は、対象締日31日を初期表示)
                if (currentCAddUpUpdDate.Day >= 28)
                {
                    this.tNedit_TotalDay.SetInt(31);
                }
                else
                {
                    this.tNedit_TotalDay.SetInt(this.tDateEdit_CAddUpUpdDate.GetDateDay());
                }

                // コンバート処理区分
                this._convertProcessDivCd = convertProcessDivCd;
            }
            else
            {
                // 前回締日設定
                this.tDateEdit_LastCAddUpUpdDate.SetDateTime(new DateTime());

                // 今回締日設定
                this.tDateEdit_CAddUpUpdDate.SetDateTime(new DateTime());

                // 対象締日
                this.tNedit_TotalDay.Clear();

                // コンバート処理区分
                this._convertProcessDivCd = 0;
            }
        }

        /// <summary>
        /// 請求全体設定マスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 請求全体設定マスタを取得します。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private int LoadBillAllSt()
        {
            int status = 0;

            try
            {
                ArrayList retList;

                status = this._billAllStAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BillAllSt billAllSt in retList)
                    {
                        this._billAllStDic.Add(billAllSt.SectionCode.Trim(), billAllSt);
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }
        // --- ADD 2008/08/08 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/08/08 Partsman用に変更
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
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

            LastDay_CheckEditor.Checked = false;

            Target_uOptionSet.CheckedIndex = 0;

            tDateEdit_CAddUpUpdDate.Clear();
            tDateEdit_CAddUpUpdDate.SetDateTime(DateTime.Now);
        }
        
        /// <summary>
        /// 得意先入力可否制御
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
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 Partsman用に変更

        #endregion

        #region DEL 2008/08/08 使用していないのでコメントアウト
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
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
        /// 得意先情報取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetCustomerInf(object sender, EventArgs e)
        {
//            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
            _pushBtn = (UltraButton)sender;
            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_NORMAL, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);

            customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
//            CustSuppli custSuppli;
            
//            int status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo, out custSuppli);
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //if (custSuppli == null)
                //{
                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //        this.Name,
                //        "選択した仕入先は仕入先情報入力が行われていない為、使用出来ません。",
                //        status,
                //        MessageBoxButtons.OK);

                //    return;
                //}
  

                //if (customerInfo.SupplierDiv == 1)
                //{
                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //        this.Name,
                //        "選択した得意先は仕入先に設定されています。",
                //        status,
                //        MessageBoxButtons.OK);

                //    return;
                //}
  
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した得意先は既に削除されています。",
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
                    "得意先情報の取得に失敗しました。",
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
            int setDay = tNedit_TotalDay.GetInt();
            if (setDay != 0)
            {
                ChangeDate(setDay);
            }
        }

        /// <summary>
        /// 締次更新日変更
        /// </summary>
        /// <param name="totalday"></param>
        private void ChangeDate(int totalday)
        {
            int year = tDateEdit_CAddUpUpdDate.GetDateYear();
            int month = tDateEdit_CAddUpUpdDate.GetDateMonth();
            int day = tDateEdit_CAddUpUpdDate.GetDateDay();
            if (day == 0)
            {
                day = totalday;
            }
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
            tDateEdit_CAddUpUpdDate.SetDateTime(setDate);
        }

        /// <summary>
        /// 末日取得
        /// </summary>
        /// <param name="targetDay"></param>
        /// <returns></returns>
        private int SetMaxDay(int year,int month)
        {
            int totalday = DateTime.Today.Day;

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    {
                        totalday = 31;
                        break;
                    }
                case 2:
                    if (DateTime.IsLeapYear(year))
                    {
                        totalday = 29;
                    }
                    else
                    {
                        totalday = 28;
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    {
                        totalday = 30;
                        break;
                    }
            }

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
                                "締日が異なる得意先です",
                                status,
                                MessageBoxButtons.OK);

                            //Objectを取得
                            TNedit errNedit = new TNedit();
                            errNedit = (TNedit)sender;

                            errNedit.Focus();

                            return;
                        }
                    }

                    //if (customerInfo.SupplierDiv == 1)
                    //{
                    //    TMsgDisp.Show(
                    //        this,
                    //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    //        this.Name,
                    //        "選択した得意先情報は仕入先に設定されています。",
                    //        status,
                    //        MessageBoxButtons.OK);

                    //    ((TNedit)sender).Focus();

                    //    return;
                    //}
  
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
                        "該当する得意先はありません。",
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
                SetLastdate();
            }
        }
        
        private void SetLastdate()
        {
            DateTime datetime = tDateEdit_CAddUpUpdDate.GetDateTime();
            //            string sEndDate = DateTime.Parse(datetime.AddMonths(1).ToString("yyyy/MM/01")).AddDays(-1).ToShortDateString();
            datetime = DateTime.Parse(datetime.AddMonths(1).ToString("yyyy/MM/01")).AddDays(-1);
            tDateEdit_CAddUpUpdDate.SetDateTime(datetime);
        }
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 使用していないのでコメントアウト

        // --- ADD 2008/08/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Click イベント(拠点ガイド)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    if (secInfoSet.SectionCode.Trim() == this._prevSectionCode.Trim())
                    {
                        return;
                    }

                    // 拠点コード取得
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    // 拠点名称取得
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

                    // バッファに前回値を保存
                    this._prevSectionCode = secInfoSet.SectionCode.Trim();

                    // 締日設定
                    SetHisTotalDayDmdC(secInfoSet.SectionCode.Trim());

                    // フォーカス設定
                    this.tDateEdit_CAddUpUpdDate.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            if (e.PrevCtrl == this.tEdit_SectionCode)
            {
                if (this.tEdit_SectionCode.DataText.Trim() == "")
                {
                    this.tEdit_SectionName.Clear();
                    this.tDateEdit_CAddUpUpdDate.SetDateTime(new DateTime());
                    this.tDateEdit_LastCAddUpUpdDate.SetDateTime(new DateTime());
                    this.tNedit_TotalDay.Clear();
                    this._prevSectionCode = "";
                    return;
                }

                string sectionCode = this.tEdit_SectionCode.DataText.Trim();
                if (sectionCode != this._prevSectionCode)
                {
                    // 拠点名称取得
                    this.tEdit_SectionName.DataText = GetSectionName(sectionCode);

                    if (this.tEdit_SectionName.DataText.Trim() == "")
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                      ASSEMBLY_ID,
                                      "マスタに登録されていません。",
                                      0,
                                      MessageBoxButtons.OK);

                        this.tEdit_SectionCode.Clear();
                        this.tDateEdit_LastCAddUpUpdDate.SetDateTime(new DateTime());
                        this.tDateEdit_CAddUpUpdDate.SetDateTime(new DateTime());
                        this.tNedit_TotalDay.Clear();
                        this._prevSectionCode = "";

                        e.NextCtrl = e.PrevCtrl;
                        return;
                    }

                    // 締日設定
                    SetHisTotalDayDmdC(sectionCode);

                    // バッファに前回値を保存
                    this._prevSectionCode = sectionCode;
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        if (this.tEdit_SectionName.DataText.Trim() != "")
                        {
                            // フォーカス設定
                            e.NextCtrl = this.tDateEdit_CAddUpUpdDate;
                        }
                    }
                }
            }
            else if (e.PrevCtrl == this.tDateEdit_CAddUpUpdDate)
            {
                // DEL 2009/04/06 ------>>>
                //if (e.ShiftKey == true)
                //{
                //    if (e.Key == Keys.Tab)
                //    {
                //        if (this.tEdit_SectionName.DataText.Trim() != "")
                //        {
                //            e.NextCtrl = this.tEdit_SectionCode;
                //            return;
                //        }
                //    }
                //}
                // DEL 2009/04/06 ------<<<
            }
        }
        // --- ADD 2008/08/08 ---------------------------------------------------------------------<<<<<
    }
}