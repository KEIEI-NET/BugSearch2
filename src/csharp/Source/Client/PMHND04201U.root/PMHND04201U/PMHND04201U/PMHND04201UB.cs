//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 検品ガイド
// プログラム概要   : 検品ガイド検索を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 譚洪
// 作 成 日  2017/07/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 3H 張小磊                               
// 修 正 日  2017/09/07  修正内容 : 検品照会の変更対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 検品ガイドフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検品ガイドフォームクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/07/20</br>
    /// <br>Update Note: 2017/09/07 3H 張小磊</br>
    /// <br>　　　　　 : 検品照会の変更対応</br>
    /// </remarks>
    public partial class PMHND04201UB : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■Privaete Members
        /// <summary>ダイアログリザルト</summary>
        private DialogResult DgResult = DialogResult.Cancel;
        /// <summary>イメージリスト</summary>
        private ImageList ImageList16 = null;
        /// <summary>終了ボタン</summary>
        private Infragistics.Win.UltraWinToolbars.ButtonTool BackButton;
        /// <summary>確定ボタン</summary>
        private Infragistics.Win.UltraWinToolbars.ButtonTool DecisionButton;
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin ControlScreenSkin;
        /// <summary>検品アクセスクラス</summary>
        private InspectInfoAcs InspectInfoObj;
        /// <summary>明細データ格納データセット</summary>
        private InspectDataSet DataSet;
        /// <summary>日付アクセスクラス</summary>
        private DateGetAcs DateGetObj = null;
        /// <summary>戻る検品データ</summary>
        private HandyInspectDataWork RetWork = new HandyInspectDataWork();
        /// <summary>明細データ格納データビュー</summary>
        private DataView ViewInspect = null;

        /// <summary>検品日入力エラー </summary>
        private const string InspectDateError = "検品日の入力が不正です。";
        /// <summary>検品データエラーのメッセージ</summary>
        private const string UpdInspectDateEmptyError = "引当可能な検品データが存在しません。";
        /// <summary>検品データエラーのメッセージ</summary>
        private const string InspectDateEmptyError = "検品データが存在しません。";
        /// <summary>検品データ取得エラーのメッセージ</summary>
        private const string InspectDateSearchError = "検品データが検索に失敗しました。";
        /// <summary>検品データ未選択エラーのメッセージ</summary>
        private const string InspectDateNoSelectError = "検品データが選択しません。";

        /// <summary>数量フォーマット</summary>
        private const string CountFormat = "#,###,##0.00";
        /// <summary>/文字列</summary>
        private const string StringSlash = "/";
        /// <summary>空文字列</summary>
        private const string StringEmpty = "";
        /// <summary>日付フォーマット</summary>
        private const string DateFormat = "yyyy/MM/dd";
        /// <summary>販売業務(入荷)</summary>
        private const string AcPaySlipName = "販売業務(入荷)";
        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
        /// <summary>在庫仕入(入荷)</summary>
        private const string AcPaySlipStockSupplierInName = "在庫仕入(入荷)";
        /// <summary>在庫仕入(出荷)</summary>
        private const string AcPaySlipStockSupplierOutName = "在庫仕入(出荷)";
        // --- ADD 3H 張小磊 2017/09/07----------<<<<<
        /// <summary>終了ボタン</summary>
        private const string ButtonToolBack = "ButtonTool_Back";
        /// <summary>確定ボタン</summary>
        private const string ButtonToolDecision = "ButtonTool_Decision";
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■Constructors

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMHND04201UB()
        {
            InitializeComponent();
            // コントロール部品スキンを設定します。
            this.ControlScreenSkin = new ControlScreenSkin();
            // 検品アクセスクラスを初期化します。
            this.InspectInfoObj = InspectInfoAcs.GetInstance();
            // 日付アクセスクラスを初期化します。
            this.DateGetObj = DateGetAcs.GetInstance();
            // コントロール部品イメージを設定します。
            this.ImageList16 = IconResourceManagement.ImageList16;
            // 終了ボタン
            this.BackButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools[ButtonToolBack];
            // 確定ボタン
            this.DecisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools[ButtonToolDecision];
            this.tToolbarsManager_Main.ImageListSmall = this.ImageList16;
            this.BackButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this.DecisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
        }

        #endregion

        #region ■プロパティ
        /// <summary>
        /// ガイド画面で確定ボタンを押下した際に選択されていた検品データ
        /// </summary>
        public HandyInspectDataWork RetInspectDataWork
        {
            get
            {
                return RetWork;
            }
            set
            {
                this.RetWork = value;
            }
        }

        #endregion

        // ===================================================================================== //
        // パブリック メソッド
        // ===================================================================================== //
        #region ■Public Methods

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="handyInspectParamWork">検索パラメータ</param>
        /// <param name="mode">0:検品表示 1:検品引当</param>
        /// <returns>>DialogResult[OK: 確定, OK以外: キャンセル]</returns>
        /// <remarks>
        /// <br>Note       : 画面表示処理を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// </remarks>
        public DialogResult ShowDialog(IWin32Window owner, HandyInspectDataWork handyInspectParamWork, int mode)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            this.tEdit_GoodsNo.Value = handyInspectParamWork.GoodsNo;
            this.tDateEdit_InspectDate.SetDateTime(handyInspectParamWork.InspectDateTime);
            this.DataSet = new InspectDataSet();
            ArrayList HandyInspectDataList = new ArrayList();

            //if (handyInspectParamWork.AcPaySlipCd == 20 && handyInspectParamWork.AcPayTransCd == 11)  // --- DEL 3H 張小磊 2017/09/07
            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            // 条件１：　受払元伝票区分＝「20：売上」　AND　受払元取引区分＝「11：返品」
            // 条件２：　受払元伝票区分＝「10：仕入」　AND　受払元取引区分　IN「10：通常伝票 , 11：返品」
            if ((handyInspectParamWork.AcPaySlipCd == 20 && handyInspectParamWork.AcPayTransCd == 11) 
                || (handyInspectParamWork.AcPaySlipCd == 10 && (handyInspectParamWork.AcPayTransCd == 10 || handyInspectParamWork.AcPayTransCd == 11)))
            // --- ADD 3H 張小磊 2017/09/07----------<<<<<
            {
                // 検品データ検索
                Status = this.InspectInfoObj.SearchGuid(handyInspectParamWork, out HandyInspectDataList);
            }
            else
            {
                Status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 画面表示モードに1:検品引当を指定して表示処理が実行された場合、且つ、対象データが一件だけの場合、検品ガイドポップアップ画面を起動しません。
                if (mode == 1 && HandyInspectDataList.Count == 1)
                {
                    RetWork = HandyInspectDataList[0] as HandyInspectDataWork;
                    return DialogResult.OK;
                }

                // 画面表示モードに0:検品表示を指定して表示処理が実行された、あるいは、対象データが複数ある場合、検品ガイドを表示します。
                if (HandyInspectDataList.Count > 1 || mode == 0)
                {

                    this.DataSet.InspectData.BeginLoadData();
                    this.DataSet.InspectData.Rows.Clear();
                    DataRow newRow = null;
                    int index = 0;
                    // データ展開処理
                    foreach (HandyInspectDataWork refDataWork in HandyInspectDataList)
                    {
                        newRow = this.DataSet.InspectData.NewRow();

                        newRow[this.DataSet.InspectData.NoColumn] = index;            // NO
                        newRow[this.DataSet.InspectData.InspectDateColumn] = refDataWork.InspectDateTime.ToString(DateFormat);          // 検品日
                        newRow[this.DataSet.InspectData.InspectTimeColumn] = refDataWork.InspectDateTime.ToShortTimeString().ToString();                // 検品日時間
                        newRow[this.DataSet.InspectData.InspectCntColumn] = refDataWork.InspectCnt.ToString(CountFormat); ;          // 数量
                        if (refDataWork.AcPaySlipCd == 20 && refDataWork.AcPayTransCd == 11)
                        {
                            newRow[this.DataSet.InspectData.AcPaySlipNameColumn] = AcPaySlipName;                  // 処理
                        }
                        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                        // 受払元伝票区分＝「10：仕入」　AND　受払元取引区分＝「10：通常伝票」
                        else if (refDataWork.AcPaySlipCd == 10 && refDataWork.AcPayTransCd == 10)
                        {
                            // 処理: 在庫仕入(入荷)
                            newRow[this.DataSet.InspectData.AcPaySlipNameColumn] = AcPaySlipStockSupplierInName;
                        }
                        // 受払元伝票区分＝「10：仕入」　AND　受払元取引区分＝「11：返品」
                        else if (refDataWork.AcPaySlipCd == 10 && refDataWork.AcPayTransCd == 11)
                        {
                            // 処理: 在庫仕入(出荷)
                            newRow[this.DataSet.InspectData.AcPaySlipNameColumn] = AcPaySlipStockSupplierOutName;
                        }
                        // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                        else
                        {
                            newRow[this.DataSet.InspectData.AcPaySlipNameColumn] = string.Empty;                  // 処理
                        }
                        newRow[this.DataSet.InspectData.AcPaySlipCdColumn] = refDataWork.AcPaySlipCd;          // 受払元伝票区分
                        newRow[this.DataSet.InspectData.AcPayTransCdColumn] = refDataWork.AcPayTransCd;          // 受払元取引区分
                        newRow[this.DataSet.InspectData.AcPaySlipNumColumn] = refDataWork.AcPaySlipNum;          // 受払元伝票番号
                        newRow[this.DataSet.InspectData.AcPaySlipRowNoColumn] = refDataWork.AcPaySlipRowNo;          // 受払元行番号
                        newRow[this.DataSet.InspectData.EmployeeCodeColumn] = refDataWork.EmployeeCode;
                        newRow[this.DataSet.InspectData.EmployeeNameColumn] = this.InspectInfoObj.GetEmployeeName(refDataWork.EmployeeCode);                // 担当者
                        newRow[this.DataSet.InspectData.GoodsMakerCdColumn] = refDataWork.GoodsMakerCd;          // メーカーコード
                        newRow[this.DataSet.InspectData.GoodsNoColumn] = refDataWork.GoodsNo;                  // 品番
                        newRow[this.DataSet.InspectData.InspectStatusColumn] = refDataWork.InspectStatus;                  // 検品ステータス
                        newRow[this.DataSet.InspectData.InspectCodeColumn] = refDataWork.InspectCode;                  // 検品区分
                        newRow[this.DataSet.InspectData.HandTerminalCodeColumn] = refDataWork.HandTerminalCode;                  // ハンディターミナル区分
                        newRow[this.DataSet.InspectData.MachineNameColumn] = refDataWork.MachineName;                  // 端末名称
                        newRow[this.DataSet.InspectData.WarehouseCodeColumn] = refDataWork.WarehouseCode;                  // 倉庫コード
                        newRow[this.DataSet.InspectData.EnterpriseCodeColumn] = refDataWork.EnterpriseCode;                  // 企業コード
                        newRow[this.DataSet.InspectData.InspectDateTimeColumn] = (long)refDataWork.InspectDateTime.Ticks;                  // 検品日時
                        index++;
                        this.DataSet.InspectData.Rows.Add(newRow);
                    }
                    this.DataSet.InspectData.EndLoadData();
                }
                // 画面表示モードに「0:検品表示」を指定して表示処理が実行された場合、確定(F10)非表示
                if (mode == 0)
                {
                    this.DecisionButton.SharedProps.Visible = false;
                }
                // 画面表示モードに「1:検品引当」を指定して表示処理が実行された場合、確定(F10)ボタン有効
                else
                {
                    this.DecisionButton.SharedProps.Visible = true;
                }
                
            }
            else if (Status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                if (mode == 1)
                {
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       UpdInspectDateEmptyError,
                       0,
                       MessageBoxButtons.OK);
                }
                else
                {
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       InspectDateEmptyError,
                       0,
                       MessageBoxButtons.OK);
                }
                return DialogResult.None;
            }
            else
            {
                TMsgDisp.Show(
                      this,
                      emErrorLevel.ERR_LEVEL_EXCLAMATION,
                      this.Name,
                      InspectDateSearchError,
                      -1,
                      MessageBoxButtons.OK);
                return DialogResult.None;
            }

            return this.ShowDialog(owner);

        }

        #endregion

        // ===================================================================================== //
        // プライベート メソッド
        // ===================================================================================== //
        #region ■Private Methods
        /// <summary>
        /// 明細グリッド設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 明細グリッド設定処理を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        internal void SettingGrid()
        {
            try
            {
                // 描画を一時停止
                this.uGrid_Details.BeginUpdate();

                // 描画が必要な明細件数を取得する。
                int Cnt = this.uGrid_Details.Rows.Count;

                // 各行ごとの設定
                for (int i = 0; i < Cnt; i++)
                {
                    this.SettingGridRow(i);
                }
            }
            finally
            {
                // 描画を開始
                this.uGrid_Details.EndUpdate();
            }
        }

        /// <summary>
        /// 明細グリッド・行単位でのセル設定
        /// </summary>
        /// <param name="rowIndex">対象行インデックス</param>
        /// <remarks>
        /// <br>Note       : 明細グリッド・行単位でのセル設定処理を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void SettingGridRow(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand EditBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (EditBand == null) return;

            // 指定行の全ての列に対して設定を行う。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in EditBand.Columns)
            {
                // セル情報を取得
                Infragistics.Win.UltraWinGrid.UltraGridCell Cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
                if (Cell == null) continue;

                Cell.Row.Hidden = false;

                // アンダーラインを全てのセルに対して非表示とする
                Cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;

                Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
        }

        #endregion

        // ===================================================================================== //
        // コントロールのイベント
        // ===================================================================================== //
        #region ■Control Events

        /// <summary>
        /// フォーム Loadイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーム Loadイベントを行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void PMHND04201UB_Load(object sender, EventArgs e)
        {
            this.ControlScreenSkin.LoadSkin();
            this.ControlScreenSkin.SettingScreenSkin(this);

           this.ViewInspect = new DataView(this.DataSet.InspectData);

           this.uGrid_Details.DataSource = this.ViewInspect;
           string Filter = string.Format(" {0} >= '{1}' ",
               this.DataSet.InspectData.InspectDateColumn.ColumnName, this.tDateEdit_InspectDate.GetDateTime().ToString(DateFormat));

           this.ViewInspect.RowFilter = Filter;

            this.SettingGrid();
        }

        /// <summary>
        /// フォーム Closedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーム Closedイベントを行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void PMHND04201UB_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = this.DgResult;
        }

        /// <summary>
        /// フォーカスChangeイベント(tArrowKeyControl1, tRetKeyControl1)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーカスChangeイベントを行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tDateEdit_InspectDate":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                case Keys.Right:
                                case Keys.Down:
                                    {
                                        DateGetAcs.CheckDateResult Cdr;
                                        Cdr = this.DateGetObj.CheckDate(ref this.tDateEdit_InspectDate, true);
                                        if (Cdr != DateGetAcs.CheckDateResult.OK)
                                        {
                                            this.tDateEdit_InspectDate.Clear();
                                            e.NextCtrl = this.tDateEdit_InspectDate;

                                            TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                InspectDateError,
                                                0,
                                                MessageBoxButtons.OK);
                                        }
                                        else
                                        {
                                            string Filter = string.Format(" {0} >= '{1}' ",
                                            this.DataSet.InspectData.InspectDateColumn.ColumnName, this.tDateEdit_InspectDate.GetDateTime().ToString(DateFormat));

                                            this.ViewInspect.RowFilter = Filter;

                                            if (this.uGrid_Details.Rows.Count > 0)
                                            {
                                                e.NextCtrl = null;
                                                this.uGrid_Details.Focus();
                                                this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[0];
                                                this.uGrid_Details.ActiveRow.Selected = true;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tDateEdit_InspectDate;
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (e.NextCtrl == this.uGrid_Details)
                                        {
                                            e.NextCtrl = this.tDateEdit_InspectDate;
                                        }
                                    }
                                    break;
                            }
                        }

                    }
                    break;
            }
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ツールバークリックイベントを行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void tToolbarsManager_Main_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 戻る
                case "ButtonTool_Back":
                    {
                        this.Close();
                        break;
                    }
                // 確定
                case "ButtonTool_Decision":
                    {
                        if (this.uGrid_Details.ActiveRow == null
                           || this.uGrid_Details.ActiveRow.Selected == false)
                        {
                            TMsgDisp.Show(this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          InspectDateNoSelectError,
                                          0,
                                          MessageBoxButtons.OK);
                            break;
                        }
                        RetWork = new HandyInspectDataWork();
                        // 担当者
                        RetWork.EmployeeCode = (string)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.EmployeeCodeColumn];
                        // 端末名称
                        RetWork.MachineName = (string)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.MachineNameColumn];
                        // ハンディターミナル区分
                        RetWork.HandTerminalCode = (int)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.HandTerminalCodeColumn];
                        // 検品区分
                        RetWork.InspectCode = (int)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.InspectCodeColumn];
                        // 検品ステータス
                        RetWork.InspectStatus = (int)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.InspectStatusColumn];
                        // 受払元伝票区分
                        RetWork.AcPaySlipCd = (int)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.AcPaySlipCdColumn];
                        // 受払元伝票番号
                        RetWork.AcPaySlipNum = (string)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.AcPaySlipNumColumn];
                        // 受払元行番号
                        RetWork.AcPaySlipRowNo = (int)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.AcPaySlipRowNoColumn];
                        // 受払元取引区分
                        RetWork.AcPayTransCd = (int)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.AcPayTransCdColumn];
                        // メーカーコード
                        RetWork.GoodsMakerCd = (int)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.GoodsMakerCdColumn];
                        // 品番
                        RetWork.GoodsNo = (string)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.GoodsNoColumn];
                        // 倉庫コード
                        RetWork.WarehouseCode = (string)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.WarehouseCodeColumn];
                        // 企業コード
                        RetWork.EnterpriseCode = (string)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.EnterpriseCodeColumn];
                        // 検品日時
                        long InspectString = (Int64)ViewInspect[this.uGrid_Details.ActiveRow.Index].Row[this.DataSet.InspectData.InspectDateTimeColumn];
                        RetWork.InspectDateTime = new DateTime(InspectString);
                        this.DgResult = DialogResult.OK;
                        this.Close();
                        break;
                    }
            }
        }

        /// <summary>
        /// フォームキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームキーダウンイベントを行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void PMHND04201UB_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        #region グリッド関連
        /// <summary>
        /// 検品データグリッドレイアウト初期化イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 検品データグリッドレイアウト初期化イベントを行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
                column.Header.Fixed = false;
            }

            int visiblePosition = 1;
            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------
            #region カラム情報の設定

            // 検品日
            Columns[this.DataSet.InspectData.InspectDateColumn.ColumnName].Hidden = false;
            Columns[this.DataSet.InspectData.InspectDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.DataSet.InspectData.InspectDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this.DataSet.InspectData.InspectDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this.DataSet.InspectData.InspectDateColumn.ColumnName].Header.Caption = "検品日";
            Columns[this.DataSet.InspectData.InspectDateColumn.ColumnName].Width = 40;

            // 検品時間
            Columns[this.DataSet.InspectData.InspectTimeColumn.ColumnName].Hidden = false;
            Columns[this.DataSet.InspectData.InspectTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.DataSet.InspectData.InspectTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this.DataSet.InspectData.InspectTimeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this.DataSet.InspectData.InspectTimeColumn.ColumnName].Header.Caption = "検品時刻";
            Columns[this.DataSet.InspectData.InspectTimeColumn.ColumnName].Width = 40;

            // 数量
            Columns[this.DataSet.InspectData.InspectCntColumn.ColumnName].Hidden = false;
            Columns[this.DataSet.InspectData.InspectCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.DataSet.InspectData.InspectCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this.DataSet.InspectData.InspectCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this.DataSet.InspectData.InspectCntColumn.ColumnName].Header.Caption = "数量";
            Columns[this.DataSet.InspectData.InspectCntColumn.ColumnName].Width = 45;

            // 処理
            Columns[this.DataSet.InspectData.AcPaySlipNameColumn.ColumnName].Hidden = false;
            Columns[this.DataSet.InspectData.AcPaySlipNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.DataSet.InspectData.AcPaySlipNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this.DataSet.InspectData.AcPaySlipNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this.DataSet.InspectData.AcPaySlipNameColumn.ColumnName].Header.Caption = "処理";
            Columns[this.DataSet.InspectData.AcPaySlipNameColumn.ColumnName].Width = 50;

            // 検品担当者
            Columns[this.DataSet.InspectData.EmployeeNameColumn.ColumnName].Hidden = false;
            Columns[this.DataSet.InspectData.EmployeeNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.DataSet.InspectData.EmployeeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this.DataSet.InspectData.EmployeeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this.DataSet.InspectData.EmployeeNameColumn.ColumnName].Header.Caption = "検品担当者";
            Columns[this.DataSet.InspectData.EmployeeNameColumn.ColumnName].Width = 75;
            #endregion

            // 固定列区切り線設定
            this.uGrid_Details.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;

            this.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
        }
        #endregion

        /// <summary>
        /// 検品データグリッドのLeaveイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 検品データグリッドのLeaveイベントを行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow != null)
            {
                this.uGrid_Details.ActiveRow.Selected = false;
                this.uGrid_Details.ActiveRow = null;
            }
        }

        /// <summary>
        /// 検品データグリッドのKeyDownイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 検品データグリッドのKeyDownイベントを行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if ((this.uGrid_Details.ActiveRow.Index == 0 && e.KeyCode == Keys.Up))
            {
                this.tDateEdit_InspectDate.Focus();
            }
        }

        /// <summary>
        /// 検品日のValueChangedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 検品日のValueChangedイベントを行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void tDateEdit_InspectDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.ViewInspect != null)
            {
                string Filter = string.Format(" {0} >= '{1}' ",
                this.DataSet.InspectData.InspectDateColumn.ColumnName, this.tDateEdit_InspectDate.GetDateTime().ToString(DateFormat));

                this.ViewInspect.RowFilter = Filter;
            }
        }
        #endregion
    }

}