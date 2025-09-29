//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自動起動サービス処理
// プログラム概要   : 自動起動サービスのファイルを更新する
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日  2010/05/21             修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2014/10/02  修正内容 : ツールチェックの修正
//----------------------------------------------------------------------------//
using System;
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
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Windows.Forms;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 受信データフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : なし。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.04.29</br>
    /// </remarks>
    public partial class PMKYO09301UA : Form
    {

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructors
        /// <summary>
        /// データフォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public PMKYO09301UA()
        {
            InitializeComponent();
            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._sectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_SectionTitle"];
            this._sectionNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_SectionName"];
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
            // ログイン担当者
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            this._controlScreenSkin = new ControlScreenSkin();
        }
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members


        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;             // 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;            // 更新ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;             // クリアボタン
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;          // ログイン担当者ラベル
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;			// ログイン担当者名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _sectionTitleLabel;          // ログイン担当者ラベル
        private Infragistics.Win.UltraWinToolbars.LabelTool _sectionNameLabel;			// ログイン担当者名称
        private ServiceFilesInputAcs _serviceFilesInputAcs = ServiceFilesInputAcs.GetInstance();
        private readonly Color DISABLE_COLOR = Color.Gainsboro;
        private readonly Color DISABLE_FONT_COLOR = Color.Black;
        private ControlScreenSkin _controlScreenSkin;
        private bool isSaveFlg = true;
        private bool closeFlg = true;
        private int delNum = 0;

        private Dictionary<string, string> _commdt = new Dictionary<string, string>();  // ADD 譚洪 2014/10/02

        // 2010/05/19 >>>
        private const int ctInterval_Minvalue = 5;
        private const string ctPGID_OfferDataUpdate = "PMKHN09210U.EXE";
        // 2010/05/19 <<<
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            this._sectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            this.uButton_Delete.ImageList = this._imageList16;
            this.uButton_Delete.Appearance.Image = (int)Size16_Index.DELETE;
            // 拠点名称
            this._sectionNameLabel.SharedProps.Caption = this._serviceFilesInputAcs.GetOwnSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private int Clear()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 不可削除行を保存する
            this.delNum = 0;

            // 画面クリア
            this._serviceFilesInputAcs.Conf.Conf.Clear();
            this._serviceFilesInputAcs.CommConf.Conf.Clear();  // ADD 譚洪 2014/10/02

            // 初期化検索
            string msg = "";
            int fileFlg = 0;
            //status = this._serviceFilesInputAcs.Search(ref msg, ref fileFlg);  // DEL 譚洪 2014/10/02
            status = this._serviceFilesInputAcs.SearchAll(ref msg, ref fileFlg); // ADD 譚洪 2014/10/02

            // メッセージを呼び出す
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // メッセージを呼び出す
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_INFO,
                   this.Name,
                   msg,
                   -1,
                   MessageBoxButtons.OK);
            }

            // 画面エディタ判断
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (fileFlg == 2)
                {
                    this.SettingGridRow();
                    delNum = this._serviceFilesInputAcs.Conf.Conf.Count;
                }
            }

            // ---- ADD 譚洪 2014/10/02 ---------------------------->>>>>
            // 空白行を追加する
            this._commdt.Clear();

            foreach (conf.ConfRow commRow in this._serviceFilesInputAcs.CommConf.Conf)
            {
                if (!this._commdt.ContainsKey(commRow.PgId.Trim().ToUpper()))
                {
                    this._commdt.Add(commRow.PgId.Trim().ToUpper(), string.Empty);
                }
            }
            // ---- ADD 譚洪 2014/10/02 ----------------------------<<<<<

            // 空白行を追加する
            conf.ConfRow row = this._serviceFilesInputAcs.Conf.Conf.NewConfRow();
            this._serviceFilesInputAcs.Conf.Conf.AddConfRow(row);

            return status;
        }

        /// <summary>
        /// 画面保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            this._serviceFilesInputAcs.Conf.Conf.AcceptChanges();

            // フラグ
            isSaveFlg = true;

            // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
            if (this.uGrid_Result.ActiveCell != null)
            {
                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            }

            if (!isSaveFlg)
            {
                return;
            }

            // 保存前調整
            SaveDataAdjust();

            // 保存チェック
            bool check = this.CheckSaveData();

            if (!check)
            {
                return;
            }

            // 保存処理
            status = this._serviceFilesInputAcs.SaveData();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SaveCompletionDialog dialog = new SaveCompletionDialog();
                dialog.ShowDialog(2);
                this.Clear();
            }
            else
            {
                // メッセージを呼び出す
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_STOPDISP,
                   this.Name,
                   "ファイルへの書き込みが失敗します。",
                   -1,
                   MessageBoxButtons.OK);
                // 空白行を追加する
                conf.ConfRow row = this._serviceFilesInputAcs.Conf.Conf.NewConfRow();
                this._serviceFilesInputAcs.Conf.Conf.AddConfRow(row);
            }

            // 情報調整
            this.AfterDataAdjust();
            // フォーカス設定
            this.uGrid_Result.Rows[this._serviceFilesInputAcs.Conf.Conf.Count - 1].Cells[0].Activate();
            this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
        }

        /// <summary>
        /// 保存前チェック
        /// </summary>
        /// <returns>フラグ</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private bool CheckSaveData()
        {
            // 存在フラグ
            bool isExistFlg = false;

            int i = 0;
            foreach (conf.ConfRow row in this._serviceFilesInputAcs.Conf.Conf)
            {       
                // グリッド中身が空の場合
                if (!string.IsNullOrEmpty(row.ChkStTime) || !string.IsNullOrEmpty(row.ChkEdTime)
                    || !string.IsNullOrEmpty(row.PgId) || !string.IsNullOrEmpty(row.RunParam)
                    || !(this.uGrid_Result.Rows[i].Cells[4].Value is DBNull))
                {
                    isExistFlg = true;
                }

                // 入力チェック
                if (!string.IsNullOrEmpty(row.ChkStTime) || !string.IsNullOrEmpty(row.ChkEdTime)
                    || !string.IsNullOrEmpty(row.PgId) || !(this.uGrid_Result.Rows[i].Cells[4].Value is DBNull))
                {
                    // チェック開始時刻
                    if (string.IsNullOrEmpty(row.ChkStTime))
                    {
                        // 情報調整
                        this.AfterDataAdjust();
                        // メッセージを呼び出す
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "入力不正です。",
                           -1,
                           MessageBoxButtons.OK);
                        this.uGrid_Result.Rows[i].Cells[0].Activate();
                        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                    // チェック終了時刻
                    if (string.IsNullOrEmpty(row.ChkEdTime))
                    {
                        // 情報調整
                        this.AfterDataAdjust();
                        // メッセージを呼び出す
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "入力不正です。",
                           -1,
                           MessageBoxButtons.OK);
                        this.uGrid_Result.Rows[i].Cells[1].Activate();
                        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                    // 実行プログラム名
                    if (string.IsNullOrEmpty(row.PgId))
                    {
                        // 情報調整
                        this.AfterDataAdjust();
                        // メッセージを呼び出す
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "入力不正です。",
                           -1,
                           MessageBoxButtons.OK);
                        this.uGrid_Result.Rows[i].Cells[2].Activate();
                        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                    // チェック間隔時間
                    if (this.uGrid_Result.Rows[i].Cells[4].Value is DBNull)
                    {
                        // 情報調整
                        this.AfterDataAdjust();
                        // メッセージを呼び出す
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "入力不正です。",
                           -1,
                           MessageBoxButtons.OK);
                        this.uGrid_Result.Rows[i].Cells[4].Activate();
                        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                    else if (row.ChkInterval == 0)
                    {
                        // 情報調整
                        this.AfterDataAdjust();
                        // メッセージを呼び出す
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "入力不正です。",
                           -1,
                           MessageBoxButtons.OK);
                        this.uGrid_Result.Rows[i].Cells[4].Activate();
                        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }

                // 入力チェック
                if (string.IsNullOrEmpty(row.ChkStTime) && string.IsNullOrEmpty(row.ChkEdTime)
                    && string.IsNullOrEmpty(row.PgId) && this.uGrid_Result.Rows[i].Cells[4].Value is DBNull)
                {
                    if (!string.IsNullOrEmpty(row.RunParam))
                    {
                        // 情報調整
                        this.AfterDataAdjust();
                        // メッセージを呼び出す
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "入力不正です。",
                           -1,
                           MessageBoxButtons.OK);
                        this.uGrid_Result.Rows[i].Cells[0].Activate();
                        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }

                if (!string.IsNullOrEmpty(row.PgId) && row.PgId.Length > 30)
                {
                    // 情報調整
                    this.AfterDataAdjust();
                    // メッセージを呼び出す
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "入力不正です。",
                       -1,
                       MessageBoxButtons.OK);
                    this.uGrid_Result.Rows[i].Cells[2].Activate();
                    this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                    return false;
                }

                if (!string.IsNullOrEmpty(row.RunParam) && row.RunParam.Length > 1)
                {
                    // 情報調整
                    this.AfterDataAdjust();
                    // メッセージを呼び出す
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "入力不正です。",
                       -1,
                       MessageBoxButtons.OK);
                    this.uGrid_Result.Rows[i].Cells[3].Activate();
                    this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                    return false;
                }

                // 開始チェック時刻と終了チェック時刻
                if (!string.IsNullOrEmpty(row.ChkStTime) && !string.IsNullOrEmpty(row.ChkEdTime))
                {
                    int start = Convert.ToInt32(row.ChkStTime);
                    int end = Convert.ToInt32(row.ChkEdTime);
                    if (start > end)
                    {
                        // 情報調整
                        this.AfterDataAdjust();
                        // メッセージを呼び出す
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "時刻の範囲指定に誤りがあります。",
                           -1,
                           MessageBoxButtons.OK);
                        this.uGrid_Result.Rows[i].Cells[0].Activate();
                        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }

                    // チェック間隔時間
                    // 2010/05/19 >>>
                    //if (!(this.uGrid_Result.Rows[i].Cells[4].Value is DBNull))
                    //{
                    //    int time = (end / 100 - start / 100) * 60 + (end % 100 - start % 100);
                    //    if (row.ChkInterval > time)
                    //    {
                    //        // 情報調整
                    //        this.AfterDataAdjust();
                    //        // メッセージを呼び出す
                    //        TMsgDisp.Show(
                    //         this,
                    //         emErrorLevel.ERR_LEVEL_INFO,
                    //         this.Name,
                    //         "間隔時間の範囲指定に誤りがあります。",
                    //         -1,
                    //         MessageBoxButtons.OK);
                    //        this.uGrid_Result.Rows[i].Cells[4].Activate();
                    //        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                    //        return false;
                    //    }
                    //}

                    if (!( this.uGrid_Result.Rows[i].Cells[this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName].Value is DBNull ))
                    {
                        bool check = true;
                        string msg = string.Empty;
                        int time = ( end / 100 - start / 100 ) * 60 + ( end % 100 - start % 100 );
                        if (row.ChkInterval > time)
                        {
                            check = false;
                            msg = "間隔時間の範囲指定に誤りがあります。";

                            return false;
                        }
                        else if (row.ChkInterval < ctInterval_Minvalue)
                        {
                            check = false;
                            msg = string.Format("実行間隔は{0}分以上にして下さい。", ctInterval_Minvalue);
                        }

                        if (!check)
                        {
                            // 情報調整
                            this.AfterDataAdjust();

                            // メッセージを呼び出す
                            TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_INFO,
                             this.Name,
                             msg,
                             -1,
                             MessageBoxButtons.OK);
                            this.uGrid_Result.Rows[i].Cells[this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName].Activate();
                            this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                            return false;
                        }
                    }

                    // ---- ADD 譚洪 2014/10/02 ---------------------------->>>>>
                    if (this._commdt.ContainsKey(row.PgId.Trim().ToUpper()) && !row.PgId.Trim().ToUpper().Equals(ctPGID_OfferDataUpdate))
                    {
                        i++;
                        continue;
                    }
                    // ---- ADD 譚洪 2014/10/02 ----------------------------<<<<<

                    #region 処理時間の限定

                    int startTime = Convert.ToInt32(row.ChkStTime);
                    int endTime = Convert.ToInt32(row.ChkEdTime);

                    // 提供データ更新処理は、0:00～3:00は実行不可
                    if (row.PgId.Trim().ToUpper().Equals(ctPGID_OfferDataUpdate))                       
                    {
                        if (startTime < 300 || endTime < 300)
                        {
                            // 情報調整
                            this.AfterDataAdjust();

                            // メッセージを呼び出す
                            TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_INFO,
                             this.Name,
                             "提供データ更新処理は"+
                             Environment.NewLine +
                             "下記時間は設定できません。"+
                             Environment.NewLine+
                             Environment.NewLine +
                             "　0:00 ～ 3:00",
                             -1,
                             MessageBoxButtons.OK);

                            this.uGrid_Result.Rows[i].Cells[( startTime < 300 ) ? this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName : this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName].Activate();
                            this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                            return false;
                        }
                    }
                    // 提供データ更新でない場合は、0:00～6:00は実行不可
                    else
                    {
                        if (startTime < 600 || endTime < 600)
                        {
                            // 情報調整
                            this.AfterDataAdjust();

                            // メッセージを呼び出す
                            TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_INFO,
                             this.Name,
                             "下記時間は設定できません。" +
                             Environment.NewLine +
                             Environment.NewLine +
                             "　0:00 ～ 6:00",
                             -1,
                             MessageBoxButtons.OK);
                            this.uGrid_Result.Rows[i].Cells[( startTime < 600 ) ? this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName : this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName].Activate();
                            this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                            return false;
                        }
                    }
                    #endregion
                    // 2010/05/19 <<<
                }

                i++;
            }

            if (!isExistFlg)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "有効な明細が入力されていません。",
                    -1,
                    MessageBoxButtons.OK);
                // フォーカス設定
                this.uGrid_Result.Rows[0].Cells[0].Activate();
                this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 保存前調整
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public void SaveDataAdjust()
        {
            foreach (conf.ConfRow row in this._serviceFilesInputAcs.Conf.Conf)
            {
                // チェック開始時刻
                if (!string.IsNullOrEmpty(row.ChkStTime))
                {
                    if (row.ChkStTime.Length == 5)
                    {
                        // 情報調整
                        row.ChkStTime = row.ChkStTime.Substring(0, 2) + row.ChkStTime.Substring(3);
                    }
                    else if (row.ChkStTime.Length == 18)
                    {
                        // 情報調整
                        row.ChkStTime = "0" + row.ChkStTime.Substring(11, 1) + row.ChkStTime.Substring(13, 2);
                    }
                    else if (row.ChkStTime.Length == 19)
                    {
                        // 情報調整
                        row.ChkStTime = row.ChkStTime.Substring(11, 2) + row.ChkStTime.Substring(14, 2);
                    }
                }
                // チェック終了時刻
                if (!string.IsNullOrEmpty(row.ChkEdTime))
                {
                    if (row.ChkEdTime.Length == 5)
                    {
                        // 情報調整
                        row.ChkEdTime = row.ChkEdTime.Substring(0, 2) + row.ChkEdTime.Substring(3);
                    }
                    else if (row.ChkEdTime.Length == 18)
                    {
                        // 情報調整
                        row.ChkEdTime = "0" + row.ChkEdTime.Substring(11, 1) + row.ChkEdTime.Substring(13, 2);
                    }
                    else if (row.ChkEdTime.Length == 19)
                    {
                        // 情報調整
                        row.ChkEdTime = row.ChkEdTime.Substring(11, 2) + row.ChkEdTime.Substring(14, 2);
                    }
                }
            }
        }

        /// <summary>
        /// 情報調整
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void AfterDataAdjust()
        {
            foreach (conf.ConfRow row in this._serviceFilesInputAcs.Conf.Conf)
            {
                // チェック開始時刻
                if (!string.IsNullOrEmpty(row.ChkStTime))
                {
                    if (row.ChkStTime.Length == 4)
                    {
                        row.ChkStTime = row.ChkStTime.Substring(0, 2) + ":" + row.ChkStTime.Substring(2);
                    }
                }
                // チェック終了時刻
                if (!string.IsNullOrEmpty(row.ChkEdTime))
                {
                    if (row.ChkEdTime.Length == 4)
                    {
                        row.ChkEdTime = row.ChkEdTime.Substring(0, 2) + ":" + row.ChkEdTime.Substring(2);
                    }
                }
            }
        }

        /// <summary>
        /// グリッドエディタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void SettingGridRow()
        {
            // 画面情報
            int i = 0;
            foreach (conf.ConfRow row in this._serviceFilesInputAcs.Conf.Conf)
            {
                if (!string.IsNullOrEmpty(row.ChkStTime))
                {
                    this.uGrid_Result.Rows[i].Cells[2].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    this.uGrid_Result.Rows[i].Cells[3].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }
                i++;
            }
        }
        #endregion

        // ===================================================================================== //
        // 各コントロールイベント処理
        // ===================================================================================== //
        # region ■Control Event Methods
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void PMKYO09301UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this.uGrid_Result);


            this.uGrid_Result.DataSource = _serviceFilesInputAcs.Conf.Conf;
            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // 初期化検索
            closeFlg = true;
            int status = this.Clear();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this.closeFlg = false;
                return;
            }

            this.timer_setFocus.Enabled = true;
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void uGrid_Result_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Result.DisplayLayout.Bands[0];
            if (editBand == null) return;
            int iIndex = 1;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;

                // 2010/05/19 Del >>>
                col.Hidden = true;
                //if (iIndex > 5)
                //{
                //    col.Hidden = true;
                //}
                //iIndex++;
                // 2010/05/19 Del <<<
            }
            // 2010/05/19 Add >>>
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName].Header.VisiblePosition = iIndex++;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName].Header.VisiblePosition = iIndex++;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName].Header.VisiblePosition = iIndex++;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.RunParamColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.RunParamColumn.ColumnName].Header.VisiblePosition = iIndex++;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ProcessExecuteDivColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ProcessExecuteDivColumn.ColumnName].Header.VisiblePosition = iIndex++;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName].Header.VisiblePosition = iIndex++;
            // 2010/05/19 Add <<<

            // グリッド
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.RunParamColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // 2010/05/19 Add >>>
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ProcessExecuteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // 2010/05/19 Add <<<

            // CellAppearance設定
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.RunParamColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // 2010/05/19 Add >>>
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ProcessExecuteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // 2010/05/19 Add <<<


            // 表示幅設定
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName].Width = 165;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName].Width = 165;
            // 2010/05/19 >>>
            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName].Width = 340;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName].Width = 200;
            // 2010/05/19 <<<
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.RunParamColumn.ColumnName].Width = 164;
            // 2010/05/19 Add >>>
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ProcessExecuteDivColumn.ColumnName].Width = 140;
            // 2010/05/19 Add <<<
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName].Width = 160;

            // フォーマット
            string format = "###";
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName].Format = format;

            // CharacterCasing 
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // style
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Time;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Time;
            // 2010/05/19 Add >>>
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ProcessExecuteDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

            Infragistics.Win.ValueList valueList;
            this.SetExecuteDivComboEditor(out valueList);
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ProcessExecuteDivColumn.ColumnName].ValueList = valueList;
            // 2010/05/19 Add <<<
        }

        // 2010/05/19 Add >>>
        /// <summary>
        /// 処理実行区分のセット
        /// </summary>
        /// <param name="valueList"></param>
        private void SetExecuteDivComboEditor(out Infragistics.Win.ValueList valueList)
        {
            valueList = new Infragistics.Win.ValueList();
            valueList.DisplayStyle = Infragistics.Win.ValueListDisplayStyle.DisplayText;

            Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
            item1.Tag = 0;
            item1.DataValue = 0;
            item1.DisplayText = "あり";

            valueList.ValueListItems.Add(item1);

            Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
            item2.Tag = 1;
            item2.DataValue = 1;
            item2.DisplayText = "なし";
            valueList.ValueListItems.Add(item2);
        }
        // 2010/05/19 Add <<<

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void uButton_Delete_Click(object sender, EventArgs e)
        {


            // アクティブ行チェック
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Result.Selected.Rows;
            if ((cell == null) && (rows == null || rows.Count == 0)) return;

            this._serviceFilesInputAcs.Conf.Conf.AcceptChanges();

            // アクティブ行取得
            int activeRowIndex;
            if (this.uGrid_Result.ActiveRow != null)
            {
                activeRowIndex = this.uGrid_Result.ActiveRow.Index;
            }
            else
            {
                activeRowIndex = this.uGrid_Result.ActiveCell.Row.Index;
            }

            // 最後行を削除できない
            if (this._serviceFilesInputAcs.Conf.Conf.Count == 1)
            {
                TMsgDisp.Show(
                     this,
                     emErrorLevel.ERR_LEVEL_INFO,
                     this.Name,
                     "削除対象行が存在しません。",
                     -1,
                     MessageBoxButtons.OK);
                return;
            }
            if (activeRowIndex + 1 == this._serviceFilesInputAcs.Conf.Conf.Count)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "削除対象行が存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }

            DialogResult result = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_INFO,
                this.Name,
                "選択した行を削除しますか？",
                -1,
                MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                // アクティブ行削除
                conf.ConfRow row = (conf.ConfRow)this._serviceFilesInputAcs.Conf.Conf.Rows[activeRowIndex];

                this._serviceFilesInputAcs.Conf.Conf.RemoveConfRow(row);

                // this._serviceFilesInputAcs.Conf.Conf.Rows[activeRowIndex].Delete();
                // this.uGrid_Result.Rows[activeRowIndex].Delete(true);
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "uGrid_Result":
                    {
                        if (e.Key == Keys.Return || e.Key == Keys.Tab)
                        {
                            isSaveFlg = true;

                            if (this.ReturnKeyDown())
                            {
                                e.NextCtrl = null;
                            }
                            else
                            {
                                if (this.uGrid_Result.Rows[this._serviceFilesInputAcs.Conf.Conf.Count - 1].Cells[4].Activated)
                                {
                                    this.uGrid_Result.PerformAction(UltraGridAction.ExitEditMode);
                                    e.NextCtrl = this.uButton_Delete;
                                }
                                else if (isSaveFlg)
                                {
                                    // エラーがない、削除ボタンを移動する
                                    e.NextCtrl = uButton_Delete;
                                }
                                else
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }
                        }
                        break;
                    }
                case "uButton_Delete":
                    {
                        if (this._serviceFilesInputAcs.Conf.Conf.Count != 0)
                        {
                            this.uGrid_Result.Focus();
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Result.Rows[0].Cells[0].Activate();
                                this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }
                default:
                    break;
            }

            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "uGrid_Result":
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            {
                                if (e.NextCtrl == this.uGrid_Result)
                                {
                                    //e.NextCtrl = this.uButton_Delete;
                                }
                            }
                            break;
                        }
                    default:
                        break;
                }
            }

            // 削除ボタン状態設定
           this.DelButtonSetting();
        }

        /// <summary>
        /// 削除ボタン状態設定
        /// </summary>
        private void DelButtonSetting()
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Result.Selected.Rows;
            if ((cell == null) && (rows == null || rows.Count == 0)) return;

            // アクティブ行取得
            int activeRowIndex;
            if (this.uGrid_Result.ActiveRow != null)
            {
                activeRowIndex = this.uGrid_Result.ActiveRow.Index;
            }
            else
            {
                if (this.uGrid_Result.ActiveCell != null)
                {
                    activeRowIndex = this.uGrid_Result.ActiveCell.Row.Index;
                }
                else
                {
                    return;
                }
            }

            if (activeRowIndex + 1 > delNum)
            {
                this.uButton_Delete.Enabled = true;
            }
            else
            {
                this.uButton_Delete.Enabled = false;
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void timer_setFocus_Tick(object sender, EventArgs e)
        {
            if (closeFlg)
            {
                // フォーカス設定
                this.uGrid_Result.Rows[this._serviceFilesInputAcs.Conf.Conf.Count - 1].Cells[0].Activate();
                this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
            }

            this.timer_setFocus.Enabled = false;
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 画面を閉じる
                        this.Close();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // 保存処理
                        this.Save();
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        // 画面クリア
                        this.Clear();
                        // フォーカス設定
                        this.uGrid_Result.Rows[this._serviceFilesInputAcs.Conf.Conf.Count - 1].Cells[0].Activate();
                        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);

                        break;
                    }
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void uGrid_Result_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Result.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;

            // 空白を追加する
            if (cell.Row.Index + 1 == this._serviceFilesInputAcs.Conf.Conf.Count)
            {
                if (cell.Column.Key == this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName
                    || cell.Column.Key == this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName)
                {
                    if (Char.IsDigit(e.KeyChar))
                    {
                        conf.ConfRow row = this._serviceFilesInputAcs.Conf.Conf.NewConfRow();
                        this._serviceFilesInputAcs.Conf.Conf.AddConfRow(row);
                    }
                }
                else if (cell.Column.Key == this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName)
                {
                    if (Char.IsDigit(e.KeyChar) && !e.KeyChar.ToString().Equals("0"))
                    {
                        conf.ConfRow row = this._serviceFilesInputAcs.Conf.Conf.NewConfRow();
                        this._serviceFilesInputAcs.Conf.Conf.AddConfRow(row);
                    }
                }
                else
                {
                    if (!Char.IsControl(e.KeyChar))
                    {
                        conf.ConfRow row = this._serviceFilesInputAcs.Conf.Conf.NewConfRow();
                        this._serviceFilesInputAcs.Conf.Conf.AddConfRow(row);
                    }
                }
            }

            if (cell.Column.Key == this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(3, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            if (cell.Column.Key == this._serviceFilesInputAcs.Conf.Conf.RunParamColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(1, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            if (cell.Column.Key == this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressStringCheck(30, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private bool KeyPressStringCheck(int keta, string prevVal, char key, int selstart, int sellength)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = string.Empty;
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
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
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
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
            string _strResult = string.Empty;
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
                //int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                int _Rketa = ServiceFilesInputAcs.diverge<int>(_strResult[0] == '-', keta - priod, keta - priod - 1);
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

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public bool ReturnKeyDown()
        {
            return MoveNextAllowEditCell(false);
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {

            this.uGrid_Result.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Result.ActiveCell != null))
            {
                if ((!this.uGrid_Result.ActiveCell.Column.Hidden) &&
                    (this.uGrid_Result.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Result.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {

                performActionResult = this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                //performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

                if (performActionResult)
                {
                    if ((this.uGrid_Result.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Result.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_Result.ResumeLayout();
            return performActionResult;
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void uGrid_Result_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Result.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;

            // ゼロを入力するとき
            if (cell.Column.Key == this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName)
            {
                string value = cell.Value.ToString();

                if (value.Equals("0"))
                {
                    cell.Value = DBNull.Value;
                }
            }

            // 空白行を削除する
            if (cell.Row.Index >= 0)
            {

                conf.ConfRow row = (conf.ConfRow)this._serviceFilesInputAcs.Conf.Conf.Rows[cell.Row.Index];

                // 最後空白行を削除する
                if (string.IsNullOrEmpty(row.ChkStTime) && string.IsNullOrEmpty(row.ChkEdTime)
                    && string.IsNullOrEmpty(row.PgId) && string.IsNullOrEmpty(row.RunParam)
                    && cell.Row.Cells[4].Value is DBNull)
                {
                    if (cell.Row.Index + 2 == this._serviceFilesInputAcs.Conf.Conf.Count)
                    {
                        ArrayList delRow = new ArrayList();

                        int i = 0;
                        for (i = this._serviceFilesInputAcs.Conf.Conf.Count - 1; i >= 0; i--)
                        {
                            // 空白行を計算する
                            conf.ConfRow rowValue = (conf.ConfRow)this._serviceFilesInputAcs.Conf.Conf.Rows[i];
                            if (!string.IsNullOrEmpty(rowValue.ChkStTime)
                                || !string.IsNullOrEmpty(rowValue.ChkEdTime) || !string.IsNullOrEmpty(rowValue.PgId)
                                || !string.IsNullOrEmpty(rowValue.RunParam) || !(this.uGrid_Result.Rows[i].Cells[4].Value is DBNull))
                            {
                                break;
                            }
                            else
                            {
                                if (i != this._serviceFilesInputAcs.Conf.Conf.Count - 1)
                                {
                                    delRow.Add(this._serviceFilesInputAcs.Conf.Conf.Rows[i + 1]);
                                }
                            }
                        }

                        // 空白行を削除する
                        foreach (conf.ConfRow selRow in delRow)
                        {
                            this._serviceFilesInputAcs.Conf.Conf.RemoveConfRow(selRow);
                        }
                    }
                    //if (cell.Row.Index + 2 == this._serviceFilesInputAcs.Conf.Conf.Count)
                    //{
                    //    conf.ConfRow delrow = (conf.ConfRow)this._serviceFilesInputAcs.Conf.Conf.Rows[this._serviceFilesInputAcs.Conf.Conf.Count - 1];
                    //    this._serviceFilesInputAcs.Conf.Conf.RemoveConfRow(delrow);
                    //}
                }
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void CellDataError(object sender, CellDataErrorEventArgs e)
        {
            // 保存しない
            isSaveFlg = false;

            if (this.uGrid_Result.ActiveCell != null)
            {
                if ((this.uGrid_Result.ActiveCell.Column.DataType == typeof(Int32)))
                {

                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Result.ActiveCell.EditorResolved;
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "入力不正です。",
                       -1,
                       MessageBoxButtons.OK);

                    editorBase.Value = 0;
                    this.uGrid_Result.ActiveCell.Value = 0;

                    this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                }
                else if ((this.uGrid_Result.ActiveCell.Column.DataType == typeof(string)))
                {

                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Result.ActiveCell.EditorResolved;
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "入力不正です。",
                       -1,
                       MessageBoxButtons.OK);

                    this.uGrid_Result.Focus();
                    this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                }

                e.RaiseErrorEvent = false;	
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void PMKYO09301UA_Shown(object sender, EventArgs e)
        {
            if (!this.closeFlg)
            {
                this.Close();
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void uGrid_Result_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Result.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;
                // Shiftキーの場合
                if (e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                this.uGrid_Result.ActiveCell = null;
                                this.uGrid_Result.ActiveRow = cell.Row;
                                this.uGrid_Result.Selected.Rows.Clear();
                                this.uGrid_Result.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Up:
                            {
                                this.uGrid_Result.ActiveCell = null;
                                this.uGrid_Result.ActiveRow = cell.Row;
                                this.uGrid_Result.Selected.Rows.Clear();
                                this.uGrid_Result.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Home:
                            {
                                if ((this.uGrid_Result.ActiveCell != null) && (this.uGrid_Result.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                if ((this.uGrid_Result.ActiveCell != null) && (this.uGrid_Result.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                // EnterNextEditableCellDetail(cell, -1);
                                break;
                            }
                    }
                }
                // Altキーの場合
                else if (e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                // s
                                break;
                            }
                    }
                }
                else
                {
                    // 編集中であった場合
                    if (cell.IsInEditMode)
                    {
                        // セルのスタイルにて判定
                        switch (this.uGrid_Result.ActiveCell.StyleResolved)
                        {
                            // テキストボックス・テキストボックス(ボタン付)
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            if (this.uGrid_Result.ActiveCell.SelStart == 0)
                                            {
                                                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            if (this.uGrid_Result.ActiveCell.SelStart >= this.uGrid_Result.ActiveCell.Text.Length)
                                            {
                                                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                }
                                break;
                            // 2009.05.06 劉洋 add
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Time:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            {
                                                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            {
                                                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        case Keys.Up:
                                            {
                                                if (cell.Row.Index + 1 == this._serviceFilesInputAcs.Conf.Conf.Count)
                                                {
                                                    conf.ConfRow row = this._serviceFilesInputAcs.Conf.Conf.NewConfRow();
                                                    this._serviceFilesInputAcs.Conf.Conf.AddConfRow(row);
                                                }
                                            }
                                            break;
                                        case Keys.Down:
                                            {
                                                if (cell.Row.Index + 1 == this._serviceFilesInputAcs.Conf.Conf.Count)
                                                {
                                                    conf.ConfRow row = this._serviceFilesInputAcs.Conf.Conf.NewConfRow();
                                                    this._serviceFilesInputAcs.Conf.Conf.AddConfRow(row);
                                                }
                                            }
                                            break;

                                    }
                                    break;
                                }
                            // 上記以外のスタイル
                            default:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            {
                                                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            {
                                                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                        }
                    }

                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            {
                                if ((this.uGrid_Result.ActiveCell != null) && (this.uGrid_Result.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // 編集モードの場合はなにもしない
                                if ((this.uGrid_Result.ActiveCell != null) && (this.uGrid_Result.ActiveCell.IsInEditMode))
                                {
                                    //
                                }
                                else
                                {
                                    this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                isSaveFlg = true;

                                if (this.ReturnKeyDown())
                                {
                                    // e.NextCtrl = null;
                                }
                                else
                                {
                                    if (this.uGrid_Result.Rows[this._serviceFilesInputAcs.Conf.Conf.Count - 1].Cells[4].Activated)
                                    {
                                        this.uGrid_Result.PerformAction(UltraGridAction.ExitEditMode);
                                        this.uButton_Delete.Focus();
                                    }
                                    else if (isSaveFlg)
                                    {
                                        // エラーがない、削除ボタンを移動する
                                        uButton_Delete.Focus();
                                    }
                                    else
                                    {
                                        // e.NextCtrl = e.PrevCtrl;
                                    }
                                }

                                // 削除ボタン状態設定
                                this.DelButtonSetting();
                                break;
                            }
                        case Keys.Tab:
                            {
                                isSaveFlg = true;

                                if (this.uGrid_Result.Rows[this._serviceFilesInputAcs.Conf.Conf.Count - 1].Cells[4].Activated)
                                {
                                    this.uGrid_Result.PerformAction(UltraGridAction.ExitEditMode);
                                    this.uButton_Delete.Focus();
                                }

                                // 削除ボタン状態設定
                                this.DelButtonSetting();
                                break;
                            }
                    }
                }
            }

            else if (this.uGrid_Result.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Result.ActiveRow;

                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        {
                            // Delキーの操作
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void uButton_Delete_EnabledChanged(object sender, EventArgs e)
        {
            if (this.uButton_Delete.Enabled)
            {
                this.tArrowKeyControl1.OwnerForm = this.panel_Detail;
                this.tRetKeyControl1.OwnerForm = this.panel_Detail;
            }
            else
            {
                this.tArrowKeyControl1.OwnerForm = this.uGrid_Result;
                this.tRetKeyControl1.OwnerForm = this.uGrid_Result;
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void uGrid_Result_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            // ボタン状態設定
            this.DelButtonSetting();
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void uGrid_Result_MouseClick(object sender, MouseEventArgs e)
        {
            // ボタン状態設定
            this.DelButtonSetting();
        }

        private void uGrid_Result_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (this.uGrid_Result.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;

            // 空白行を追加する
            if (cell.Row.Index >= 0)
            {
                conf.ConfRow row = (conf.ConfRow)this._serviceFilesInputAcs.Conf.Conf.Rows[cell.Row.Index];

                // 最後空白行を削除する
                if (!string.IsNullOrEmpty(row.ChkStTime) || !string.IsNullOrEmpty(row.ChkEdTime)
                    || !string.IsNullOrEmpty(row.PgId) || !string.IsNullOrEmpty(row.RunParam)
                    || !(cell.Row.Cells[4].Value is DBNull))
                {
                    if (cell.Row.Index + 1 == this._serviceFilesInputAcs.Conf.Conf.Count)
                    {
                        conf.ConfRow addRow = this._serviceFilesInputAcs.Conf.Conf.NewConfRow();
                        this._serviceFilesInputAcs.Conf.Conf.AddConfRow(addRow);
                    }
                }
            }

            if (cell.Column.Key == this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName)
            {
                string value = cell.Value.ToString();

                // 全角を判断する
                bool isHalfKana = true;
                for (int i = 0; i < value.Length; i++)
                {
                    String cutStr = value.Substring(i, 1);
                    if (ASCIIEncoding.Default.GetByteCount(cutStr) == 2)
                    {
                        isHalfKana = false;
                        break;
                    }
                }

                // 全角がありの場合、クリアする
                if (!isHalfKana)
                {
                    cell.Value = string.Empty;
                }
            }
        }
        #endregion

        private void uGrid_Result_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            // IMEをひらがなモードにする
            this.uGrid_Result.ImeMode = System.Windows.Forms.ImeMode.Close;
            //// セル単位でのIME制御	
            //if ((e.Cell.Column.Key == _serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName))
            //{
            //    // IMEをひらがなモードにする
            //    this.uGrid_Result.ImeMode = System.Windows.Forms.ImeMode.Close;
            //}
            //else
            //{
            //    //// IMEを起動しない
            //    //this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Disable;
            //}
        }
    }
}