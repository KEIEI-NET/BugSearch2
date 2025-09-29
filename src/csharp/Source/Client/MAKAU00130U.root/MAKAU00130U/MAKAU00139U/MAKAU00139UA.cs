//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：仕入月次更新
// プログラム概要   ：仕入月次更新を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2008/08/21     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/08     修正内容：Mantis【11604】全拠点指定対応
// ---------------------------------------------------------------------//
// 管理番号  10700008-00    作成担当：liyp
// 修正日    2011/04/11     修正内容：月次更新にタイマーをつけて、処理開始時間を指定可能とする
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：zhujc
// 修正日    2011/05/10     修正内容：Redmine#20853、Redmine#20844、Redmine#20840
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：zhujc
// 修正日    2011/06/03     修正内容：Redmine#21960
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
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 月次更新処理(仕入)フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 月次更新処理(仕入)を行うフォームクラスです。</br>
	/// <br>Programer  : 19077 渡邉貴裕</br>
	/// <br>Date       : 2007.04.03</br>
    /// <br>Update Note: 2008/08/21 30414 忍 幸史 Partsman用に変更</br>
    /// <br>UpdateNote   : 2011/04/11 liyp 月次更新にタイマーをつけて、処理開始時間を指定可能とする</br>
    /// <br>UpdateNote   : 2011/05/10 zhujc Redmine#20853、Redmine#20844</br>
	/// </remarks>
	public partial class MAKAU00139UA : Form
    {
        // --- ADD 2008/08/21 --------------------------------------------------------------------->>>>>

        // -------------------------------------------------
        // Constants
        // -------------------------------------------------
        #region Constants

        private const string ctPGID = "MAKAU00139U";

        private const string SECTION_CODE_COMMON = "00";    // ADD 2009/04/08

        #endregion Constants


        // -------------------------------------------------
        // Private Members
        // -------------------------------------------------
        #region Private Members

        private string _enterpriseCode;         // 企業コード
        private string _prevSectionCode;        // 拠点コード(前回値)
        private DateTime _prevTotalDay;         // 前回月次処理日
        private DateTime _currentTotalDay;      // 今回月次処理日
        private int _convertProcessDivCd;       // コンバート処理区分
        private bool _processWaitFlg;           // 月次処理待機状態 True:待機 False:中止待機 //ADD 2011/04/11
        private int counter = 0;                //ADD 2011/04/11

        private SecInfoSetAcs _secInfoSetAcs;
        private CustDmdPrcAcs _custDmdPrcAcs;

        #endregion Private Members


        // -------------------------------------------------
        // Constructor
        // -------------------------------------------------
        #region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MAKAU00139UA()
        {
            InitializeComponent();

            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }

            this._secInfoSetAcs = new SecInfoSetAcs();
            this._custDmdPrcAcs = new CustDmdPrcAcs();

            // アイコン設定
            this.uButton_SectionGuide.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // 画面初期化
            ClearAllDisp();

            // 画面初期設定
            InitializeSetting();
            // ADD 2011/04/11 ------>>>>>
            this._processWaitFlg = false;
            if (this._processWaitFlg)
            {
                this.ultraLabel_Message.Visible = true;
                this.ultraButton_StopPrepare.Visible = true;
                this.ultraButton_Prepare.Visible = false;
            }
            else
            {
                this.ultraLabel_Message.Visible = false;
                this.ultraButton_StopPrepare.Visible = false;
                this.ultraButton_Prepare.Visible = true;
            }
            // ADD 2011/04/11 ------<<<<<

            // フォーカス設定
            SetFocus();
        }

        // -------ADD 2011/04/11 ----->>>>>
        public Boolean ProcessWaitFlg
        {
            get { return _processWaitFlg; }
            set { _processWaitFlg = value; }
        }
        // -------ADD 2011/04/11 -----<<<<<
        #endregion Constructor


        // -------------------------------------------------
        // Public Methods
        // -------------------------------------------------
        #region Public Methods
        /// <summary>
        /// 初期フォーカス設定処理
        /// </summary>
        public void SetFocus()
        {
            // 拠点コードにフォーカス設定
            //this.tEdit_SectionCode.Focus();           // DEL 2009/04/08
            // this.tDateEdit_CurrentTotalMonth.Focus();   // ADD 2009/04/08 // DEL 2011/04/11
            // --------------ADD 2011/04/11 ------------------>>>>>
            if (this.tDateEdit_CurrentTotalMonth.Enabled)
            {
                this.tDateEdit_CurrentTotalMonth.Focus();
            }
            else if (this.tEdit_Hour.Enabled)
            {
                this.tEdit_Hour.Focus();
            }
            // --------------ADD 2011/04/11 ------------------<<<<<
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        public void DispClear()
        {
            // 画面初期化
            ClearAllDisp();
        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <returns>ステータス</returns>
        /// <br>UpdateNote   : 2011/05/10 zhujc Redmine#20844</br>
        public int CheckInput()
        {
            string errMsg = "";

            try
            {
                // DEL 2009/004/08 ------>>>
                //if (this.tEdit_SectionCode.DataText.Trim() == "")
                //{
                //    errMsg = "拠点コードを入力してください。";
                //    this.tEdit_SectionCode.Focus();
                //    return (-1);
                //}

                //string sectionCode = this.tEdit_SectionCode.DataText.Trim();
                //if (this._custDmdPrcAcs.GetSectionName(sectionCode) == "")
                //{
                //    errMsg = "マスタに登録されていません。";
                //    this.tEdit_SectionCode.Focus();
                //    return (-1);
                //}
                // DEL 2009/004/08 ------<<<
                
                if ((this.tDateEdit_CurrentTotalMonth.GetDateYear() == 0) ||
                    // DEL 2011/05/10 ------>>>>>
                    //(this.tDateEdit_CurrentTotalMonth.GetDateMonth() == 0))
                    // DEL 2011/05/10 ------<<<<<
                    // ADD 2011/05/10 ------>>>>>
                    (this.tDateEdit_CurrentTotalMonth.GetDateMonth() == 0) ||
                    (this.tDateEdit_CurrentTotalMonth.GetDateYear() < 1900))
                    // ADD 2011/05/10 ------<<<<<
                {
                    errMsg = "今回月次処理日を入力してください。";
                    this.tDateEdit_CurrentTotalMonth.Focus();
                    return (-1);
                }
                if (this.tDateEdit_CurrentTotalMonth.GetDateMonth() > 12)
                {
                    errMsg = "今回月次処理日が不正です。";
                    this.tDateEdit_CurrentTotalMonth.Focus();
                    return (-1);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(this, 							// 親ウィンドウフォーム
                                  emErrorLevel.ERR_LEVEL_INFO, 		// エラーレベル
                                  ctPGID, 						    // アセンブリＩＤまたはクラスＩＤ
                                  errMsg, 	                        // 表示するメッセージ
                                  0, 								// ステータス値
                                  MessageBoxButtons.OK);			// 表示するボタン
                }
            }

            return (0);
        }

        /// <summary>
        /// 月次更新処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <br>UpdateNote   : 2011/04/11 liyp 月次更新にタイマーをつけて、処理開始時間を指定可能とする</br>
        /// <br>UpdateNote   : 2011/05/10 zhujc Redmine#20853</br>
        public int ExecuteSaveProc()
        {
            // --------------ADD 2011/04/11 ----------->>>>>
            if (!this._processWaitFlg)
            {
                // --------------ADD 2011/04/11 -----------<<<<<
                DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                ctPGID,
                                                "更新してもよろしいですか？",
                                                0,
                                                MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    return (0);
                }
            } //ADD 2011/04/11
            // ADD 2011/05/10 ------>>>>>
            // 自動月次更新する時、処理開始時間をクリアする
            else
            {
                this.tEdit_Hour.Text = string.Empty;
                this.tEdit_Minute.Text = string.Empty;
            }
            // ADD 2011/05/10 ------<<<<<

            string errMsg;

            // 入力チェック
            int status = CheckInput();
            if (status != 0)
            {
                return (-1);
            }

            // 拠点コード
            //string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');  // DEL 2009/04/08
            string sectionCode = SECTION_CODE_COMMON;                                       // ADD 2009/04/08
            // 計上年月
            DateTime cAddUpUpdDate = new DateTime(this.tDateEdit_CurrentTotalMonth.GetDateYear(),
                                                  this.tDateEdit_CurrentTotalMonth.GetDateMonth(),
                                                  1);

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "更新中";
            msgForm.Message = "仕入月次更新処理中です。" + "\n" + "しばらくお待ちください。";

            try
            {
                msgForm.Show();

                status = this._custDmdPrcAcs.RegistDmdData(this._enterpriseCode,
                                                               sectionCode,
                                                               cAddUpUpdDate,
                                                               this.tDateEdit_PrevTotalMonth.GetDateTime(),
                                                               cAddUpUpdDate,
                                                               1,
                                                               out errMsg);
            }
            finally
            {
                msgForm.Close();
            }

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
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "更新に失敗しました。" + "\r\n"
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
                                    "更新に失敗しました。" + "\r\n"
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
                                    "更新に失敗しました。" + "\r\n"
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
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            ctPGID,     						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ExecuteSaveProc",				    // 処理名称
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
                            ctPGID,     						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ExecuteSaveProc",				    // 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            errMsg,				                // 表示するメッセージ 
                            status,								// ステータス値
                            this._custDmdPrcAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                    }
                    
                    return (status);
            }

            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                          ctPGID,
                          "月次更新は完了しました。",
                          0,
                          MessageBoxButtons.OK);

            //// 画面初期化
            //ClearAllDisp();

            // 月次処理月設定
            SetHisTotalDayMonthlyAccRec(sectionCode);
            // --------ADD 2011/04/11 ----------->>>>>
            this.tEdit_Hour.DataText = string.Empty;
            this.tEdit_Minute.DataText = string.Empty;
            // --------ADD 2011/04/11 -----------<<<<<

            // フォーカス設定
            SetFocus();

            return (status);
        }

        /// <summary>
        /// 締取消処理
        /// </summary>
        /// <returns>ステータス</returns>
        public int ExecuteDelProc()
        {
            DialogResult result = TMsgDisp.Show(
                                        this, 								                    // 親ウィンドウフォーム
                                        emErrorLevel.ERR_LEVEL_QUESTION, 		                // エラーレベル
                                        ctPGID, 						                        // アセンブリＩＤまたはクラスＩＤ
                                        "前回月次処理日に該当する締情報の\n取消を処理します。", // 表示するメッセージ
                                        0, 									                    // ステータス値
                                        MessageBoxButtons.YesNo);				                // 表示するボタン

            if (result == DialogResult.No)
            {
                return (-1);
            }

            if (this._convertProcessDivCd == 1)
            {
                result = TMsgDisp.Show(
                                this, 								            // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                ctPGID, 						                // アセンブリＩＤまたはクラスＩＤ
                                "コンバート以前の締取消は実行できません。",     // 表示するメッセージ
                                0, 									            // ステータス値
                                MessageBoxButtons.OK);				            // 表示するボタン
                return (-1);
            }

            // 入力チェック
            int status = CheckInput();
            if (status != 0)
            {
                return (-1);
            }

            string errMsg;

            // 拠点コード
            //string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');  // DEL 2009/04/08
            string sectionCode = SECTION_CODE_COMMON;                                       // ADD 2009/04/08
            // 計上年月
            DateTime cAddUpUpdDate = new DateTime(this.tDateEdit_CurrentTotalMonth.GetDateYear(),
                                                  this.tDateEdit_CurrentTotalMonth.GetDateMonth(),
                                                  1);

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "取消中";
            msgForm.Message = "仕入月次更新取消中です。" + "\n" + "しばらくお待ちください。";

            try
            {
                msgForm.Show();

                status = this._custDmdPrcAcs.BanishDmdData(this._enterpriseCode,
                                                           sectionCode,
                                                           cAddUpUpdDate,
                                                           this.tDateEdit_PrevTotalMonth.GetDateTime(),
                                                           cAddUpUpdDate,
                                                           1,
                                                           out errMsg);
            }
            finally
            {
                msgForm.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                  ctPGID,
                                  "解除しました。",
                                  0,
                                  MessageBoxButtons.OK);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                  ctPGID,
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
                        TMsgDisp.Show(this,								// 親ウィンドウフォーム
                                      emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                                      ctPGID,						    // アセンブリＩＤまたはクラスＩＤ
                                      this.Text,						// プログラム名称
                                      "ExecuteDelProc",				    // 処理名称
                                      TMsgDisp.OPE_DELETE,				// オペレーション
                                      "解除に失敗しました。",			// 表示するメッセージ 
                                      status,							// ステータス値
                                      this._custDmdPrcAcs,				// エラーが発生したオブジェクト
                                      MessageBoxButtons.OK,				// 表示するボタン
                                      MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                    }
                    else
                    {
                        TMsgDisp.Show(this,								    // 親ウィンドウフォーム
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                                      ctPGID,						        // アセンブリＩＤまたはクラスＩＤ
                                      this.Text,						    // プログラム名称
                                      "ExecuteDelProc",				        // 処理名称
                                      TMsgDisp.OPE_DELETE,				    // オペレーション
                                      errMsg,			                    // 表示するメッセージ 
                                      status,							    // ステータス値
                                      this._custDmdPrcAcs,				    // エラーが発生したオブジェクト
                                      MessageBoxButtons.OK,				    // 表示するボタン
                                      MessageBoxDefaultButton.Button1);	    // 初期表示ボタン
                    }

                    return (status);
            }

            //// 画面初期化
            //ClearAllDisp();

            // 月次処理月設定
            SetHisTotalDayMonthlyAccRec(sectionCode);

            // --------ADD 2011/04/11 ----------->>>>>
            this.tEdit_Hour.DataText = string.Empty;
            this.tEdit_Minute.DataText = string.Empty;
            // --------ADD 2011/04/11 -----------<<<<<

            // フォーカス設定
            SetFocus();

            return (status);
        }
        #endregion Public Methods


        // -------------------------------------------------
        // Private Methods
        // -------------------------------------------------
        #region Private Methods
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        private void ClearAllDisp()
        {
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tDateEdit_PrevTotalMonth.SetDateTime(DateTime.MinValue);
            this.tDateEdit_CurrentTotalMonth.SetDateTime(DateTime.MinValue);

            this.tDateEdit_CurrentTotalMonth.Enabled = false;

            this._prevSectionCode = "";
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/21</br>
        /// </remarks>
        private void InitializeSetting()
        {
            // コントロールサイズ設定
            this.tEdit_SectionCode.Size = new Size(36, 24);
            this.tEdit_SectionName.Size = new Size(179, 24);

            // DEL 2009/04/08 ------>>>
            //// 拠点コード
            //this.tEdit_SectionCode.DataText = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            //this._prevSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            //// 拠点名称
            //this.tEdit_SectionName.DataText = this._custDmdPrcAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
            //// 月次処理月設定
            //SetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
            // DEL 2009/04/08 ------<<<

            // ADD 2009/04/08 ------>>>
            // 拠点コード
            this.tEdit_SectionCode.DataText = SECTION_CODE_COMMON;
            this._prevSectionCode = SECTION_CODE_COMMON;
            // 月次処理月設定
            SetHisTotalDayMonthlyAccRec(SECTION_CODE_COMMON);
            // ADD 2009/04/08 ------<<<
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/08/21</br>
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
                            ctPGID,      						// アセンブリＩＤまたはクラスＩＤ
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
                            ctPGID,     						// アセンブリＩＤまたはクラスＩＤ
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
        /// 今回月次処理日設定処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <remarks>
        /// <br>Note       : 今回月次処理日を設定します。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/21</br>
        /// </remarks>
        private void SetHisTotalDayMonthlyAccRec(string sectionCode)
        {
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;

            int status = this._custDmdPrcAcs.GetHisTotalDayMonthlyAccRecPay(sectionCode,
                                                                            1,
                                                                            out prevTotalDay,
                                                                            out currentTotalDay,
                                                                            out prevTotalMonth,
                                                                            out currentTotalMonth,
                                                                            out this._convertProcessDivCd);
            if (status == 0)
            {
                // 今回月次処理月設定
                this.tDateEdit_CurrentTotalMonth.SetDateTime(currentTotalMonth);
                // 前回月次処理月設定
                this.tDateEdit_PrevTotalMonth.SetDateTime(prevTotalMonth);

                if (prevTotalDay == DateTime.MinValue)
                {
                    this.tDateEdit_CurrentTotalMonth.Enabled = true;
                }
                else
                {
                    this.tDateEdit_CurrentTotalMonth.Enabled = false;
                }

                // 今回月次処理日設定
                this._currentTotalDay = currentTotalDay;
                // 前回月次処理日設定
                this._prevTotalDay = prevTotalDay;
            }
            else
            {
                // 今回月次処理月設定
                this.tDateEdit_CurrentTotalMonth.SetDateTime(new DateTime());
                // 前回月次処理月設定
                this.tDateEdit_PrevTotalMonth.SetDateTime(new DateTime());

                this.tDateEdit_CurrentTotalMonth.Enabled = true;

                // 今回月次処理日設定
                this._currentTotalDay = new DateTime();
                // 前回月次処理日設定
                this._prevTotalDay = new DateTime();
            }
        }
        #endregion Private Methods

        
        // -------------------------------------------------
        // Control Events
        // -------------------------------------------------
        #region Control Events
        /// <summary>
        /// Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
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

                    // 月次処理月設定
                    SetHisTotalDayMonthlyAccRec(secInfoSet.SectionCode.Trim());

                    // フォーカス設定
                    this.tDateEdit_CurrentTotalMonth.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // 拠点コード取得
            // 2009.02.20 30413 犬飼 比較で不一致になるので0詰め >>>>>>START
            //string sectionCode = this.tEdit_SectionCode.DataText.Trim();
            string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
            // 2009.02.20 30413 犬飼 比較で不一致になるので0詰め <<<<<<END
            
            if (sectionCode != this._prevSectionCode)
            {
                // バッファに前回値を保存
                this._prevSectionCode = sectionCode;

                // 拠点名称取得
                this.tEdit_SectionName.DataText = this._custDmdPrcAcs.GetSectionName(sectionCode);

                // 月次処理月設定
                SetHisTotalDayMonthlyAccRec(sectionCode);
            }

            if (e.ShiftKey == false)
            {
                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                {
                    if (this.tEdit_SectionName.DataText.Trim() != "")
                    {
                        if (this.tDateEdit_CurrentTotalMonth.Enabled == true)
                        {
                            e.NextCtrl = this.tDateEdit_CurrentTotalMonth;
                        }
                    }
                }
            }
        }

        // --------------ADD 2011/04/11 ---------------->>>>>
        /// <summary>
        /// Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : メッセージを点滅させる。</br>
        /// <br>Programer  : liyp</br>
        /// <br>Date       : 2011/04/11</br>
        /// <br>UpdateNote : 2011/05/10 zhujc Redmine#20853</br>
        /// <br>UpdateNote : 2011/06/03 zhujc Redmine#21960</br>
        /// </remarks>
        private void timer_ShowOrNot_Tick(object sender, EventArgs e)
        {
            counter = counter + 1;
            if (Int32.Parse(this.tEdit_Hour.DataText.Trim()) == System.DateTime.Now.Hour && Int32.Parse(this.tEdit_Minute.DataText.Trim()) == System.DateTime.Now.Minute)
            {
                this.timer_ShowOrNot.Stop();
                this.ultraLabel_Message.Visible = false;
                this.tEdit_Hour.Enabled = true;
                // 処理中時、画面の制御の設定

                // DEL 2011/05/10 ------>>>>>
                //this.tEdit_Hour.Text = string.Empty;
                // DEL 2011/05/10 ------<<<<<

                this.tEdit_Minute.Enabled = true;

                // DEL 2011/05/10 ------>>>>>
                //this.tEdit_Minute.Text = string.Empty;
                // DEL 2011/05/10 ------<<<<<

                this.ultraButton_Prepare.Visible = true;

                // ADD 2011/05/10 ------>>>>>
                this.ultraButton_Prepare.Focus();
                // ADD 2011/05/10 ------<<<<<

                this.ultraButton_StopPrepare.Visible = false;

                // DEL 2011/05/10 ------>>>>>
                //this.tDateEdit_CurrentTotalMonth.Enabled = true;
                // DEL 2011/05/10 ------<<<<<

                //ExecuteSaveProc();//月次更新を行う //DEL 2011/06/03
                // ADD 2011/06/03  ----------------------------->>>>>>
                if (0 != ExecuteSaveProc())
                {
                    this.tEdit_Hour.Focus();
                    if(DateTime.MinValue == this.tDateEdit_PrevTotalMonth.GetDateTime())
                    {
                        this.tDateEdit_CurrentTotalMonth.Enabled = true;
                    }
                }
                // ADD 2011/06/03  -----------------------------<<<<<<
                this._processWaitFlg = false; //月次処理待機状態を解除し
                ParentToolbarSettingEvent(this);
                return;
            }
            if (counter % 4 == 0)
            {
                this.ultraLabel_Message.Visible = false;
            }
            else
            {
                this.ultraLabel_Message.Visible = true;
            }
        }

        /// <summary>
        /// Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 月次待機処理を行います。</br>
        /// <br>Programer  : liyp</br>
        /// <br>Date       : 2011/04/11</br>
        /// </remarks>
        private void ultraButton_Prepare_Click(object sender, EventArgs e)
        {
            DialogResult result;
            // 入力チェック
            int status = CheckInput();
            if (status != 0)
            {
                return;
            }
            if (checkStartTime(this.tEdit_Hour.Text, this.tEdit_Minute.Text))
            {
                if ((Int32.Parse(this.tEdit_Hour.Text) > System.DateTime.Now.Hour) || (Int32.Parse(this.tEdit_Hour.Text) == System.DateTime.Now.Hour && Int32.Parse(this.tEdit_Minute.Text) >= System.DateTime.Now.Minute))
                {
                    result = TMsgDisp.Show(
                                     this, 								            // 親ウィンドウフォーム
                                     emErrorLevel.ERR_LEVEL_QUESTION, 		    // エラーレベル
                                     ctPGID, 						                // アセンブリＩＤまたはクラスＩＤ
                                     "待機処理を開始してよろしいですか？",     // 表示するメッセージ
                                     0, 									            // ステータス値
                                     MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);				            // 表示するボタン
                }
                else
                {
                    result = TMsgDisp.Show(
                                         this, 								            // 親ウィンドウフォーム
                                         emErrorLevel.ERR_LEVEL_QUESTION, 		    // エラーレベル
                                         ctPGID, 						                // アセンブリＩＤまたはクラスＩＤ
                                         "待機処理を開始してよろしいですか？" + "\r\n"
                                          + "(処理開始時間は翌日です)",     // 表示するメッセージ
                                         0, 									            // ステータス値
                                         MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);				            // 表示するボタン
                }

                if (result == DialogResult.Yes)
                {
                    this._processWaitFlg = true;
                    ParentToolbarSettingEvent(this);
                    this.ultraButton_Prepare.Visible = false;
                    this.ultraButton_StopPrepare.Visible = true;
                    this.ultraLabel_Message.Visible = true;
                    this.tEdit_Hour.Enabled = false;
                    this.tEdit_Minute.Enabled = false;
                    this.tDateEdit_CurrentTotalMonth.Enabled = false;
                    this.timer_ShowOrNot.Start();
                }

            }
        }

        /// <summary>
        /// Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 月次処理待機状態の解除を行います。</br>
        /// <br>Programer  : liyp</br>
        /// <br>Date       : 2011/04/11</br>
        /// </remarks>
        private void ultraButton_StopPrepare_Click(object sender, EventArgs e)
        {
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            DialogResult result = TMsgDisp.Show(
                                 this, 								            // 親ウィンドウフォーム
                                 emErrorLevel.ERR_LEVEL_QUESTION, 		    // エラーレベル
                                 ctPGID, 						                // アセンブリＩＤまたはクラスＩＤ
                                 "待機処理を中止してよろしいですか？",     // 表示するメッセージ
                                 0, 									            // ステータス値
                                 MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);				            // 表示するボタン
            if (result == DialogResult.Yes)
            {
                this._processWaitFlg = false; //月次処理待機状態を解除し
                ParentToolbarSettingEvent(this);
                this.tEdit_Hour.Enabled = true;
                this.tEdit_Minute.Enabled = true;
                this.ultraButton_Prepare.Visible = true;
                this.ultraButton_StopPrepare.Visible = false;
                this.ultraLabel_Message.Visible = false;
                int status = this._custDmdPrcAcs.GetHisTotalDayMonthlyAccRecPay(SECTION_CODE_COMMON,
                                                                            1,
                                                                            out prevTotalDay,
                                                                            out currentTotalDay,
                                                                            out prevTotalMonth,
                                                                            out currentTotalMonth,
                                                                            out this._convertProcessDivCd);
                if (status == 0)
                {
                    if (prevTotalDay == DateTime.MinValue)
                    {
                        this.tDateEdit_CurrentTotalMonth.Enabled = true;
                    }
                    else
                    {
                        this.tDateEdit_CurrentTotalMonth.Enabled = false;
                    }
                }
                else
                {
                    // 今回月次処理月設定
                    this.tDateEdit_CurrentTotalMonth.SetDateTime(new DateTime());
                    this.tDateEdit_CurrentTotalMonth.Enabled = true;
                }
                this.timer_ShowOrNot.Stop();
            }
        }

        /// <summary>
        /// Leave  イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 時間は２桁が不足時に発生します。</br>
        /// <br>Programer   : liyp</br>
        /// <br>Date	    : 2011/04/11</br>
        /// </remarks>
        private void tEdit_Hour_Leave(object sender, EventArgs e)
        {
            this.tEdit_Hour.DataText = this.tEdit_Hour.DataText.Trim();
            if (this.tEdit_Hour.DataText.Length < 2 && this.tEdit_Hour.DataText.Length > 0)
            {
                this.tEdit_Hour.DataText = this.tEdit_Hour.DataText.PadLeft(2, '0');
            }
        }

        /// <summary>
        /// Leave  イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 時間は２桁が不足時に発生します。</br>
        /// <br>Programer   : liyp</br>
        /// <br>Date	    : 2011/04/11</br>
        /// </remarks>
        private void tEdit_Minute_Leave(object sender, EventArgs e)
        {
            this.tEdit_Minute.DataText = this.tEdit_Minute.DataText.Trim();
            if (this.tEdit_Minute.DataText.Length < 2 && this.tEdit_Minute.DataText.Length > 0)
            {
                this.tEdit_Minute.DataText = this.tEdit_Minute.DataText.PadLeft(2, '0');
            }
        }

        // --------------ADD 2011/04/11 ----------------<<<<<

        #endregion Control Events
        // --- ADD 2008/08/21 ---------------------------------------------------------------------<<<<<

        // --- ADD 2011/04/11 ----------------->>>>>
        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <br>Programer   : liyp</br>
        /// <br>Date	    : 2011/04/11</br>
        /// <returns>ステータス</returns>
        private bool checkStartTime(string hour, string minute)
        {
            bool checkFlg = true;
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^\\d{2}$");
            if (!string.IsNullOrEmpty(hour) && !string.IsNullOrEmpty(minute))
            {
                if (!regex.IsMatch(hour) || !regex.IsMatch(minute))
                {
                    TMsgDisp.Show(
                                   this, 								            // 親ウィンドウフォーム
                                   emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                   ctPGID, 						                // アセンブリＩＤまたはクラスＩＤ
                                   "処理開始時間の設定が不正です。",     // 表示するメッセージ
                                   0, 									            // ステータス値
                                   MessageBoxButtons.OK);				            // 表示するボタン
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }

                if (Int32.Parse(hour) < 0 || Int32.Parse(hour) > 23)
                {
                    TMsgDisp.Show(
                                this, 								            // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                ctPGID, 						                // アセンブリＩＤまたはクラスＩＤ
                                "処理開始時間の設定が不正です。",     // 表示するメッセージ
                                0, 									            // ステータス値
                                MessageBoxButtons.OK);				            // 表示するボタン
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }
                if (Int32.Parse(minute) < 0 || Int32.Parse(minute) > 59)
                {
                    TMsgDisp.Show(
                                this, 								            // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                ctPGID, 						                // アセンブリＩＤまたはクラスＩＤ
                                "処理開始時間の設定が不正です。",     // 表示するメッセージ
                                0, 									            // ステータス値
                                MessageBoxButtons.OK);				            // 表示するボタン
                    this.tEdit_Minute.Focus();
                    checkFlg = false;
                    return checkFlg;
                }
                if (Int32.Parse(hour) <= 5 || Int32.Parse(hour) >= 23 || (Int32.Parse(hour) == 6 && Int32.Parse(minute) == 0))
                {
                    TMsgDisp.Show(
                                 this, 								            // 親ウィンドウフォーム
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                 ctPGID, 						                // アセンブリＩＤまたはクラスＩＤ
                                 "23時00分～06時00分はメンテナンス時間の為、設定出来ません。",     // 表示するメッセージ
                                 0, 									            // ステータス値
                                 MessageBoxButtons.OK);				            // 表示するボタン
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }
            }
            else if (string.IsNullOrEmpty(hour) && !string.IsNullOrEmpty(minute))
            {
                TMsgDisp.Show(
                                    this, 								            // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                    ctPGID, 						                // アセンブリＩＤまたはクラスＩＤ
                                    "処理開始時間の設定が不正です。",     // 表示するメッセージ
                                    0, 									            // ステータス値
                                    MessageBoxButtons.OK);				            // 表示するボタン
                this.tEdit_Hour.Focus();
                checkFlg = false;
                return checkFlg;
            }
            else if (!string.IsNullOrEmpty(hour) && string.IsNullOrEmpty(minute))
            {
                if (!regex.IsMatch(hour))
                {
                    TMsgDisp.Show(
                                   this, 								            // 親ウィンドウフォーム
                                   emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                   ctPGID, 						                // アセンブリＩＤまたはクラスＩＤ
                                   "処理開始時間の設定が不正です。",     // 表示するメッセージ
                                   0, 									            // ステータス値
                                   MessageBoxButtons.OK);				            // 表示するボタン
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }

                if (Int32.Parse(hour) < 0 || Int32.Parse(hour) > 23)
                {
                    TMsgDisp.Show(
                                this, 								            // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                ctPGID, 						                // アセンブリＩＤまたはクラスＩＤ
                                "処理開始時間の設定が不正です。",     // 表示するメッセージ
                                0, 									            // ステータス値
                                MessageBoxButtons.OK);				            // 表示するボタン
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }
                TMsgDisp.Show(
                                    this, 								            // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                    ctPGID, 						                // アセンブリＩＤまたはクラスＩＤ
                                    "処理開始時間の設定が不正です。",     // 表示するメッセージ
                                    0, 									            // ステータス値
                                    MessageBoxButtons.OK);				            // 表示するボタン
                this.tEdit_Minute.Focus();
                checkFlg = false;
                return checkFlg;
            }
            else if (string.IsNullOrEmpty(hour) && string.IsNullOrEmpty(minute))
            {
                TMsgDisp.Show(
                                        this, 								            // 親ウィンドウフォーム
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // エラーレベル
                                        ctPGID, 						                // アセンブリＩＤまたはクラスＩＤ
                                        "処理開始時間を入力してください。",     // 表示するメッセージ
                                        0, 									            // ステータス値
                                        MessageBoxButtons.OK);				            // 表示するボタン
                this.tEdit_Hour.Focus();
                checkFlg = false;
                return checkFlg;
            }

            return checkFlg;
        }

        // ===================================================================================== //
        // Internalイベント
        // ===================================================================================== //
        #region Internal event
        /// <summary>
        /// ツールバー表示制御イベント
        /// </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion

        // --- ADD 2011/04/11 -----------------<<<<<

        #region DEL 2008/08/21 Partsman用に変更
        /* --- DEL 2008/08/21 --------------------------------------------------------------------->>>>>
		//==================================================================
		//  コンストラクタ
		//==================================================================
		#region コンストラクタ
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public MAKAU00139UA()
		{
			InitializeComponent();                        
            
            //CustDmdPrcAcs = CustDmdPrcAcs.GetInstance();

            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }

            this._customerInfoAcs = new CustomerInfoAcs();            

            this._companyInfAcs = new CompanyInfAcs();
            this._custDmdPrcAcs = new CustDmdPrcAcs();

            // 画面初期化
            AllDispClear(false);
		}
		#endregion

		//--------------------------------------------------------
		//  プライベート変数
		//--------------------------------------------------------
		#region プライベート変数

        private ArrayList _stockRet = new ArrayList();

        /// <summary>
        /// 製番在庫アクセスクラス
        /// </summary>
        private CompanyInfAcs _companyInfAcs;
        private CustDmdPrcAcs _custDmdPrcAcs;

		/// <summary>
		/// 伝票明細列表示ステータス
		/// </summary>
		private ProductStockDisplayStatus _colDispInfo = null;

        /// <summary>
        /// 企業コード
        /// </summary>
		private string _enterpriseCode;

		/// <summary>
		/// イベント制御フラグ
		/// </summary>
		private bool _localEventBlockFlg = false;
        /// <summary>
		/// セル非アクティブ時のセル情報
		/// </summary>
//*		private UltraGridCell _tempCell = null;
		/// <summary>
		/// セル非アクティブ時の初期値
		/// </summary>
//*		private object _tempValue = null;
		/// <summary>
		/// セル非アクティブイベント実行フラグ
		/// </summary>
//*		private bool _beforeCellDeactivateRun = false;

        private Infragistics.Win.Misc.UltraButton _pushBtn = null;

        private int[] _customerTotalDay;

        private CustomerInfoAcs _customerInfoAcs;

        #endregion

        //--------------------------------------------------------
		//  プライベート定数
		//--------------------------------------------------------
		#region プライベート定数

		/// <summary>明細列表示ステータスファイル名称</summary>
		private const string ctFILE_ColDispInfo = "MAKAU00129U.DAT";
        
        /// <summary>PGID</summary>
		private const string ctPGID = "MAKAU00139U";
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
			// オプションによるツールバー設定
			this.SettingOptionTool();

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
//			CustDmdPrcAcs.SlipDtlColChanged += PtSuplSlipAcs_SlipDtlColChanged;

			// 製番在庫アクセスクラスの明細テーブル行変更イベントにハンドラを追加
//			CustDmdPrcAcs.SlipDtlRowChanged += SlipDtlDataTable_SlipDtlRowChanged;
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
        /// 入力内容チェック
        /// </summary>
        /// <returns></returns>
        public int CheckInput()
        {
            return CheckInputData();
        }

        /// <summary>
        /// 入力内容チェック
        /// </summary>
        /// <returns></returns>
        private int CheckInputData()
        {
            //締日
            int result = 0;
            //締日
            int chkInt = (int)TotalDay_tNedit.GetInt();
            if ((chkInt <= 0) || ((chkInt > 31) && (chkInt != 99)))
            {
                return 1;
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
                return 2;
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
                    msg = "更新に失敗しました" + "(" + status.ToString() + ")" ;
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
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        msg,
                        status,
                        MessageBoxButtons.OK);
                }

            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "更新しました", 0, MessageBoxButtons.OK);
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

            int totalDay = TotalDay_tNedit.GetInt();

            DateTime addUpdate = tDateEdit1.GetDateTime();
            DateTime addupYM = addUpdate;

            return _custDmdPrcAcs.RegistDmdData(out retTotalCnt, this._enterpriseCode, this._sectionCd,addUpdate,addupYM, totalDay,2,out msg);
        }

        /// <summary>
        /// 締解除
        /// </summary>
        public int ExecuteDelProc()
        {
            string msg;
            int status = DelProc(out msg);

            if (status != 0)
            {
                if (String.IsNullOrEmpty(msg))
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "解除に失敗しました。", 0, MessageBoxButtons.OK);
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, msg, 0, MessageBoxButtons.OK);
                }
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "解除しました。", 0, MessageBoxButtons.OK);
            }

            return status;
        }

        /// <summary>
        /// 締解除実処理
        /// </summary>
        private int DelProc(out string msg)
        {
            int retTotalCnt = 0;

            int totalDay = TotalDay_tNedit.GetInt();
            DateTime addUpDate = tDateEdit1.GetDateTime();
            DateTime addUpYM = addUpDate;

            return _custDmdPrcAcs.BanishDmdData(out retTotalCnt, _enterpriseCode, _sectionCd, totalDay, addUpDate, addUpYM, 2, out msg);
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

        public void SetFocus()
        {
            tDateEdit1.Focus();            
        }

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

            tDateEdit1.Clear();

            //自社情報取得            
            CompanyInf companyInf = new CompanyInf();
            _companyInfAcs.Read(out companyInf, this._enterpriseCode);
            TotalDay_tNedit.Text = companyInf.CompanyTotalDay.ToString();

            DateTime datetime = DateTime.Now;  //現在日付

            if (datetime.Day > companyInf.CompanyTotalDay)　//現在日付の日が締日指定日超=前月
            {
                datetime = DateTime.Parse(datetime.ToString("yyyy/MM/01")).AddDays(-1); //
            }
            datetime = ChkDate(datetime,companyInf.CompanyTotalDay.ToString());
            tDateEdit1.SetDateTime(datetime);
        }

        private DateTime ChkDate(DateTime tgtDateTime, String tgtDay)
        {
            int year = tgtDateTime.Year;
            int month = tgtDateTime.Month;
            int day = Int32.Parse(tgtDay);

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
                        break;
                    }
                case 2:
                    if (DateTime.IsLeapYear(year))
                    {
                        if (day > 29)
                        {
                            day = 29;
                        }
                    }
                    else
                    {
                        if (day > 28)
                        {
                            day = 28;
                        }
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    {
                        if (day > 30)
                        {
                            day = 30;
                        }                        
                        break;
                    }
            }

            DateTime rtnDateTime = new DateTime(year, month, day);

            return rtnDateTime;
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
		/// オプション系ツールバー設定
		/// </summary>
		private void SettingOptionTool()
		{
			PurchaseStatus purchaseStatus;

			//**************************************************
			// TSP回答データ取込 オプションチェック
			//**************************************************
			// TSPオンラインのオプションチェック
			purchaseStatus =
				LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
				ConstantManagement_SF_PRO.SoftwareCode_OPT_SB_TSP_ONLINE);

			if ((purchaseStatus != PurchaseStatus.Contract) &&
				(purchaseStatus != PurchaseStatus.Trial_Contract))
			{
				// 未契約の場合は、TSPインラインのオプションチェックも行う
				purchaseStatus =
					LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
					ConstantManagement_SF_PRO.SoftwareCode_OPT_SB_TSP_INLINE);
			}

			// 契約時
			if ((purchaseStatus == PurchaseStatus.Contract) ||
				(purchaseStatus == PurchaseStatus.Trial_Contract))
			{
				// ボタンの表示-表示
//				this.ExplorerBar_InputHelp.Groups["InputHelper"].Items["TSPResponseDataImport"].Visible = true;
				// ツールバーのTSP回答データ取込は表示
//				this.ToolbarsManager_Main.Tools["ButtonTool_TSPResponseDataImport"].SharedProps.Visible = true;
			}
			else
			{
				// ボタンの表示-非表示
//				this.ExplorerBar_InputHelp.Groups["InputHelper"].Items["TSPResponseDataImport"].Visible = false;
				// ツールバーのTSP回答データ取込は非表示
//				this.ToolbarsManager_Main.Tools["ButtonTool_TSPResponseDataImport"].SharedProps.Visible = false;
			}

			//**************************************************
			// TSPバーコード入力 オプションチェック
			//**************************************************
			// TSPオフラインのオプションチェック
			purchaseStatus = PurchaseStatus.Uncontract;
// とりあえず現状では非表示
//			purchaseStatus =
//				Broadleaf.Application.Common.LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
//				Broadleaf.Application.Resources.ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BarCodeTspInput);

			// 契約時
			if ((purchaseStatus == PurchaseStatus.Contract) ||
				(purchaseStatus == PurchaseStatus.Trial_Contract))
			{
				// ボタンの表示-非表示
//				this.ExplorerBar_InputHelp.Groups["InputHelper"].Items["TSPBarcodeInput"].Visible = true;
				// ツールバーのTSP回答データ取込は表示
//				this.ToolbarsManager_Main.Tools["ButtonTool_TSPBarcodeInput"].SharedProps.Visible = true;
			}
			else
			{
				// ボタンの表示-非表示
//				this.ExplorerBar_InputHelp.Groups["InputHelper"].Items["TSPBarcodeInput"].Visible = false;
				// ツールバーのTSP回答データ取込は非表示
//				this.ToolbarsManager_Main.Tools["ButtonTool_TSPBarcodeInput"].SharedProps.Visible = false;
			}
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
		/// 品番入力チェック処理
		/// </summary>
		/// <param name="inputString">入力品番</param>
		/// <returns>チェック・修正後品番</returns>
		private string TextChangePartsNoCheck(string inputString)
		{
			if (inputString == null) return "";

			int withHyphenLength = 24;
			int withoutHyphenLength = 20;
			int hyphenCnt = 0;
			StringBuilder retStr = new StringBuilder();

			for (int i = 0; i < inputString.Length; i++)
			{
				// 英数字,ハイフン以外はNG
				if (!Regex.IsMatch(inputString[i].ToString(), "[a-zA-Z0-9-]"))
				{
					continue;
				}

				if (inputString[i] == '-')
				{
					// 追加可能であれば追加する
					if (hyphenCnt < withHyphenLength - withoutHyphenLength)
					{
						retStr.Append(inputString[i]);
					}
					// ハイフンカウンタインクリメント
					hyphenCnt++;
				}
				else
				{
					// 追加可能であれば追加する
					if (retStr.Length - hyphenCnt < withoutHyphenLength)
					{
						retStr.Append(inputString[i]);
					}
				}
			}

			return retStr.ToString();
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
            _pushBtn = (Infragistics.Win.Misc.UltraButton)sender;
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
            }

            _pushBtn = null;

        }

        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {

        }

        private void CustomerCode01_tNedit_ValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// フォーカス抜け次処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerCode_tNedit_BeforeExitEditMode(object sender, Infragistics.Win.BeforeExitEditModeEventArgs e)
        {
            CustomerInfo customerInfo = new CustomerInfo();

            int setCode = 0;
            bool exist = false;

//            exist = CheckValue(ref sender,ref setCode);
           

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
//                    else if ((totalDay > 28) && (LastDay_CheckEditor.Checked != true))
//                    {
//                        chkTarget = true;
//                    }
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
                }
            }
            else
            {
            }           
        }

        private void TotalDay_tNedit_AfterExitEditMode(object sender, EventArgs e)
        {
            //請求日付を変更します。
            int setDay = TotalDay_tNedit.GetInt();
            if (setDay != 0)
            {
                // 締次更新日変更処理
                ChangeDate(setDay);
            }            
        }

        /// <summary>
        /// 締次更新日変更
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
            DateTime setDate = new DateTime(year, month, day);
            tDateEdit1.SetDateTime(setDate);
        }

        /// <summary>
        /// 末日取得
        /// </summary>
        /// <param name="targetDay"></param>
        /// <returns></returns>
        private int SetMaxDay(int year, int month)
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
           --- DEL 2008/08/21 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/21 Partsman用に変更
    }
}