//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メーカーパターン検索履歴照会
// プログラム概要   : メーカーパターン検索履歴照会の検索を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11570249-00 作成担当 : 陳艶丹
// 作 成 日  2020/03/09  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11570249-00 作成担当 : 岸
// 作 成 日  2020/04/28  修正内容 : グリッドに発注項目追加
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.ComponentModel;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// メーカーパターン検索履歴照会メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : メーカーパターン検索履歴照会メインフレームの定義と実装を行うクラス。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/03/09</br>
    /// </remarks>
    public partial class PMKHN09783UB :Form
    {
        #region ■Private Const
        /// <summary>終了ボタン</summary>
        private const string ButtonToolClose = "ButtonTool_Close";
        /// <summary>検索ボタン</summary>
        private const string ButtonToolSearch = "ButtonTool_Search";
        /// <summary>クリアボタン</summary>
        private const string ButtonToolClear = "ButtonTool_Clear";
        /// <summary>ログイン担当者タイトル</summary>
        private const string LabelToolLoginTitle = "LabelTool_LoginTitle";
        /// <summary>ログイン担当者名称</summary>
        private const string LabelToolLoginName = "LabelTool_LoginName";

        /// <summary>開始検索日付無効年月日のメッセージ</summary>
        private const string SearchDateBeginInvalidDate = "開始検索日付の入力が不正です。";
        /// <summary>終了検索日付無効年月日のメッセージ</summary>
        private const string SearchDateEndInvalidDate = "終了検索日付の入力が不正です。";
        /// <summary>検索日付開始＞終了のメッセージ</summary>
        private const string SearchDateStartEndError = "検索日付の範囲指定に誤りがあります。";
        /// <summary>メーカー情報取得エラーのメッセージ</summary>
        private const string GoodsMakerInfoSearchError = "メーカー情報取得に失敗しました。";
        /// <summary>メーカー情報取得できないのメッセージ</summary>
        private const string GoodsMakerInfoEmptyError = "メーカーコードが存在しません。";
        /// <summary>データ情報取得できないのメッセージ</summary>
        private const string DataInfoEmptyError = "該当するデータがありません。";
        /// <summary>履歴情報取得エラーのメッセージ</summary>
        private const string HisInfoSearchError = "検索処理に失敗しました。";
        /// <summary>グリッド列表示状態保存処理エラーのメッセージ</summary>
        private const string ColDisplayStatusSaveError = "グリッド列表示状態保存処理に失敗しました。";
        /// <summary>列表示状態セッティングXMLファイル名</summary>
        private const string FileNameColDisplayStatus = "PMKHN09783U_ColSetting.DAT";
        /// <summary>抽出中画面のタイトル</summary>
        private const string SearchFormTitle = "抽出中";
        /// <summary>抽出中画面のメッセージ</summary>
        private const string SearchFormMessage = "データ抽出中です。";
        /// <summary>プログラムID</summary>
        private const string AssemblyId = "PMKHN09783U";
        /// <summary>プログラム名前</summary>
        private const string AssemblyName = "メーカーパターン検索履歴照会";
        /// <summary>画面メニュー</summary>
        private const string Toolbars = "Toolbars";

        /// <summary>0文字列</summary>
        private const string StringZero = "0";
        /// <summary>00文字列</summary>
        private const string StringZZ = "00";
        /// <summary>0000文字列</summary>
        private const string StringZZZZ = "0000";
        /// <summary>000000文字列</summary>
        private const string StringZZZZZZ = "000000";
        /// <summary>/文字列</summary>
        private const string StringSlash = "/";
        /// <summary>未登録</summary>
        private const string Status0 = "未登録";
        /// <summary>正常登録</summary>
        private const string Status1 = "正常登録";
        /// <summary>登録エラー</summary>
        private const string Status2 = "登録エラー";
        // --- ADD 2020/04/28 M.KISHI ---------->>>>>
        /// <summary>発注</summary>
        private const string KinDUoeOrderExists = "有";
        // --- ADD 2020/04/28 M.KISHI ----------<<<<<
        /// <summary>-1ステータス</summary>
        private const int StatusError = -1;
        /// <summary>0ステータス</summary>
        private const int StatusNormal = 0;

        /// <summary>グリッドのアクティブ行のインデックス「0」：グリッドの最上行</summary>
        private const int ActiveRowIndexZero = 0;
        /// <summary>日付「0」：日付未入力</summary>
        private const int LongDateZero = 0;
        /// <summary>グリッドデータ件数「0」：グリッドデータ件数0件</summary>
        private const int SearchHisGridRowsCountZero = 0;
        /// <summary>メーカーコード「0」：メーカーコード未入力</summary>
        private const int GoodsMakerCdZero = 0;
        /// <summary>文字列の一部を取得(Substring用:0)</summary>
        private const int SubstringIndexZero = 0;
        /// <summary>文字列の一部を取得(Substring用:2)</summary>
        private const int SubstringIndexTwo = 2;
        /// <summary>文字列の一部を取得(Substring用:4)</summary>
        private const int SubstringIndexFour = 4;
        /// <summary>文字列の一部を取得(Substring用:6)</summary>
        private const int SubstringIndexSix = 6;
        /// <summary>文字列の長度(Length:8)</summary>
        private const int StringLengthEight = 8;

        /// <summary>メーカーコード</summary>
        private const string GoodsMakerCdCaption = "メーカー";
        /// <summary>メーカー</summary>
        private const string GoodsMakerNameCaption = "メーカー名";
        /// <summary>最終日付</summary>
        private const string SearchDateCaption = "最終日付";
        /// <summary>バーコード</summary>
        private const string BarCodeDataCaption = "バーコード";
        /// <summary>パターン№</summary>
        private const string MakerGoodsPtrnNoCaption = "パターン№";
        /// <summary>検索品番</summary>
        private const string SearchGoodsNoCaption = "検索品番";
        /// <summary>確定品番</summary>
        private const string EntryGoodsNoCaption = "確定品番";
        /// <summary>回数</summary>
        private const string UseCountCaption = "回数";
        // --- ADD 2020/04/28 M.KISHI ---------->>>>>
        /// <summary>発注</summary>
        private const string UoeOrderDtlKindCaption = "発注";
        // --- ADD 2020/04/28 M.KISHI ----------<<<<<
        /// <summary>結果</summary>
        private const string EntryStatusCaption = "結果";
        
        #endregion ■ Private Const

        # region ◆Private Members

        /// <summary>コントロール部品スキン</summary>
        private ControlScreenSkin ControlScreenSkinAccessor = null;
        /// <summary>画面イメージ</summary>
        private ImageList ImageList16 = null;
        /// <summary>企業コード</summary>
        private string EnterpriseCode = string.Empty;
        /// <summary>メーカー品番パターンアクセスクラス</summary>
        private HandyMakerGoodsPtrnAcs HandyMakerGoodsPtrnAccessor = null;
        /// <summary>日付アクセスクラス</summary>
        private DateGetAcs DateGetAccessor = null;
        /// <summary>メーカーアクセスクラス</summary>
        private MakerAcs MakerAccessor = null;
        /// <summary>前回入力メーカーコード</summary>
        private string PrevGoodsMakerCode = string.Empty;
        /// <summary>前回入力メーカー名</summary>
        private string PrevGoodsMakerName = string.Empty;
        /// <summary>明細データ格納データビュー</summary>
        private DataView DataViewHis = null;
        /// <summary>明細データ格納データセット</summary>
        private MakerGoodsPtrnHisDataSet MakerGoodsPtrnHisDs = null;
        /// <summary>メーカーディクショナリー</summary>
        private Dictionary<int, string> GoodsMakerDic = null;
        /// <summary>「enter、マウス、F2など」連続押下判断用フラグ</summary>
        private bool IsSaveFlg = false;
        # endregion

        #region ◆Constractor

        /// <summary>
        /// メーカーパターン検索履歴照会フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカーパターン検索履歴照会フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public PMKHN09783UB()
        {
            InitializeComponent();

            // コントロール部品スキンを設定します。
            this.ControlScreenSkinAccessor = new ControlScreenSkin();
            // コントロール部品イメージを設定します。
            this.ImageList16 = IconResourceManagement.ImageList16;
            // 企業コードを取得します。
            this.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // メーカー品番パターンアクセスクラスを初期化します。
            this.HandyMakerGoodsPtrnAccessor = new HandyMakerGoodsPtrnAcs();

            // 日付アクセスクラスを初期化します。
            this.DateGetAccessor = DateGetAcs.GetInstance();

            // メーカーアクセスクラスを初期化します。
            this.MakerAccessor = new MakerAcs();
            // メーカーマスタデータキャッシューします。
            int status = this.GetGoodsMakerInfo();
            // メーカー情報を取得できない場合
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ErrMsgDispProc(GoodsMakerInfoSearchError, status);
                this.Close();
            }
        }
        #endregion

        #region ◆ControlEvent

        /// <summary>
        /// Form.Load イベント (PMKHN09783UB)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが表示されるときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void PMKHN09783UB_Load(object sender, EventArgs e)
        {
            // 画面を構築
            this.ScreenInitialSetting();
            this.ScreenClear();
        }

        /// <summary>
        ///	Control.ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーカス移動時に発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            Control NextControl = null;

            switch (e.PrevCtrl.Name)
            {
                #region ●グリッド内フォーカス移動
                case "SearchHis_Grid":
                    {
                        NextControl = this.GetSearchHisFormFocus(e);
                        if (this.SearchHis_Grid.ActiveRow != null && e.NextCtrl != null && e.NextCtrl.Name.IndexOf(Toolbars) < 0)
                        {
                            this.SearchHis_Grid.ActiveRow.Selected = false;
                            this.SearchHis_Grid.ActiveRow = null;
                        }
                        break;
                    }
                #endregion

                #region ●メーカーコード
                case "tNedit_GoodsMakerCd":
                    {
                        #region < 編集チェック >
                        // 変数保持
                        string goodsMakerCd = this.tNedit_GoodsMakerCd.GetInt().ToString();

                        if (this.PrevGoodsMakerCode == goodsMakerCd)
                        {
                            if (goodsMakerCd == StringZero)
                            {
                                this.tNedit_GoodsMakerCd.Clear();
                                this.lb_GoodsMakerName.Text = string.Empty;
                            }
                            // 編集前と同じなら処理を行なわない
                            // カーソル制御
                            NextControl = this.GetSearchHisFormFocus(e);
                            break;
                        }
                        #endregion

                        #region < メーカー検索 >
                        if (goodsMakerCd != StringZero)
                        {
                            string goodsMakerName = this.GetGoodsMakerName(goodsMakerCd);

                            if (string.IsNullOrEmpty(goodsMakerName))
                            {
                                #region -- 取得失敗 --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    GoodsMakerInfoEmptyError,
                                    -1,
                                    MessageBoxButtons.OK);

                                if (!string.IsNullOrEmpty(this.PrevGoodsMakerCode))
                                {
                                    this.tNedit_GoodsMakerCd.SetInt(int.Parse(this.PrevGoodsMakerCode));
                                }
                                else
                                {
                                    this.tNedit_GoodsMakerCd.Clear();
                                }

                                this.tNedit_GoodsMakerCd.SelectAll();
                                // カーソル制御
                                e.NextCtrl = e.PrevCtrl;
                                #endregion
                            }
                            else
                            {
                                this.tNedit_GoodsMakerCd.SetInt(int.Parse(goodsMakerCd));
                                this.lb_GoodsMakerName.Text = goodsMakerName;
                                // カーソル制御
                                NextControl = this.GetSearchHisFormFocus(e);
                            }
                        }
                        else
                        {
                            this.tNedit_GoodsMakerCd.Clear();
                            this.lb_GoodsMakerName.Text = string.Empty;
                            // カーソル制御
                            NextControl = this.GetSearchHisFormFocus(e);
                        }
                        #endregion

                        #region < 編集前データ保持 >
                        // 編集された親商品情報を編集前データとして保持
                        this.PrevGoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt().ToString();
                        this.PrevGoodsMakerName = this.lb_GoodsMakerName.Text.Trim();
                        #endregion

                        break;
                    }

                #endregion

                #region ●検索日付開始
                case "tDate_SearchDateBegin":

                    // 数字以外を入力する場合、クリアする
                    if (this.tDate_SearchDateBegin.GetDateYear() == 0 || this.tDate_SearchDateBegin.GetDateMonth() == 0 || this.tDate_SearchDateBegin.GetDateDay() == 0)
                    {
                        this.tDate_SearchDateBegin.Clear();
                    }
                    break;
                #endregion

                #region ●検索日付終了
                case "tDate_SearchDateEnd":

                    // 数字以外を入力する場合、クリアする
                    if (this.tDate_SearchDateEnd.GetDateYear() == 0 || this.tDate_SearchDateEnd.GetDateMonth() == 0 || this.tDate_SearchDateEnd.GetDateDay() == 0)
                    {
                        this.tDate_SearchDateEnd.Clear();
                    }
                    NextControl = this.GetSearchHisFormFocus(e);

                    break;
                #endregion

                #region 他のフォーカス補正処理
                case "tEdit_SeachStr":
                case "CheckEditor_Insert":
                    NextControl = this.GetSearchHisFormFocus(e);

                    if (NextControl == this.SearchHis_Grid)
                    {
                        this.SearchHis_Grid.ActiveRow = this.SearchHis_Grid.Rows[0];
                        this.SearchHis_Grid.ActiveRow.Selected = true;
                    }

                    break;
                case "ub_GoodsMakerCd":
                case "tEdit_BarCode":
                    NextControl = this.GetSearchHisFormFocus(e);
                    break;
                #endregion
            }

            // フォーカス補正コントロールがある場合
            if (NextControl != null)
            {
                e.NextCtrl = NextControl;
            }
        }

        /// <summary>
        /// 表示絞込条件値変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 表示絞込条件値変更イベント時に発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void tEdit_SeachStr_TextChanged(object sender, EventArgs e)
        {
            string filter = string.Empty;

            //表示絞り込む条件
            string searchStr = this.tEdit_SeachStr.Text.Trim();

            // 未登録チェックオフの場合
            if (this.CheckEditor_Insert.Checked)
            {
                if (string.IsNullOrEmpty(searchStr))
                {
                    filter = this.GetCheckedRowFilter();
                }
                else
                {
                    filter = this.GetAllRowFilter(searchStr);
                }
                this.DataViewHis.RowFilter = filter;
            }
            else
            {
                if (string.IsNullOrEmpty(searchStr))
                {
                    this.DataViewHis.RowFilter = string.Empty;
                }
                else
                {
                    filter = this.GetSearchStrRowFilter(searchStr);
                    this.DataViewHis.RowFilter = filter;
                }
            }

        }

        /// <summary>
        /// メインメニュークリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : メインメニューをクリックした際に発生するイベントハンドラ</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // 処理中、再処理不可
            // IsSaveFlgがTrueの場合、処理不可。IsSaveFlgがFalseの場合、処理可
            if (this.IsSaveFlg)
            {
                return;
            }
            this.IsSaveFlg = true;

            #region 各処理前、フォーカスアウト補正処理
            Control ActiveControl = this.GetActiveControl();
            if (ActiveControl != null)
            {
                if (ActiveControl != this.SearchHis_Grid)
                {
                    ChangeFocusEventArgs ex = new ChangeFocusEventArgs(false, false, false, Keys.Right, this.GetActiveControl(), this.uGroupBox_ExtractInfo);
                    this.tArrowKeyControl1_ChangeFocus(sender, ex);
                }
                else
                {
                    this.uGroupBox_ExtractInfo.Focus();
                    this.SearchHis_Grid.Focus();
                }
            }
            #endregion

            try
            {
                switch (e.Tool.Key)
                {
                    #region 終了(F1)
                    case "ButtonTool_Close":
                        {
                            // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
                            if (this.SearchHis_Grid.ActiveCell != null)
                            {
                                this.SearchHis_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            }

                            // 終了処理
                            this.Close();

                            break;
                        }
                    #endregion

                    #region 検索(F2)
                    case "ButtonTool_Search":
                        {
                            // 入力項目チェック処理
                            if (!this.CheckInputPara())
                            {
                                return;
                            }

                            // 検索処理
                            this.SearchProc();

                            break;
                        }
                    #endregion

                    #region クリア(F9)
                    case "ButtonTool_Clear":
                        {
                            // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
                            if (this.SearchHis_Grid.ActiveCell != null)
                            {
                                this.SearchHis_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            }

                            // 画面変更確認処理
                            // 終了処理
                            this.ScreenClear();

                            break;
                        }
                    #endregion
                }
            }
            finally
            {
                this.IsSaveFlg = false;
            }
        }


        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : メーカーガイドボタンクリックイベント。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void ub_GoodsMakerCd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt MakerUMntWork;

                int Status = this.MakerAccessor.ExecuteGuid(this.EnterpriseCode, out MakerUMntWork);
                if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    this.tNedit_GoodsMakerCd.SetInt(MakerUMntWork.GoodsMakerCd);
                    this.lb_GoodsMakerName.Text = MakerUMntWork.MakerName;

                    #region < 編集前データ保持 >
                    // 編集された親商品情報を編集前データとして保持
                    this.PrevGoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt().ToString();
                    this.PrevGoodsMakerName = this.lb_GoodsMakerName.Text.Trim();
                    #endregion

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// グリッド　キーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッド　キーダウンイベント。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void SearchHis_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.SearchHis_Grid.ActiveRow == null) return;

            int RowIndex = this.SearchHis_Grid.ActiveRow.Index;

            if ((this.SearchHis_Grid.ActiveRow.Index == ActiveRowIndexZero && e.KeyCode == Keys.Up))
            {
                this.tEdit_SeachStr.Focus();
                this.SearchHis_Grid.ActiveRow.Selected = false;
                this.SearchHis_Grid.ActiveRow = null;

            }
        }

        /// <summary>
        /// グリッド　セルアクティブ前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッド　セルアクティブ前イベント。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void SearchHis_Grid_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            if (this.SearchHis_Grid.ActiveRow == null) return;
            this.SearchHis_Grid.ActiveRow.Selected = true;
        }

        /// <summary>
        /// 未登録チェックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 未登録チェックイベント。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void CheckEditor_SearchHis_CheckedChanged(object sender, EventArgs e)
        {
            string Filter = string.Empty;
            string SearchStr = this.tEdit_SeachStr.Text.Trim();

            if (this.CheckEditor_Insert.Checked)
            {
                // 表示絞込条件が入力無しの場合
                if (string.IsNullOrEmpty(SearchStr))
                {
                    Filter = this.GetCheckedRowFilter();
                }
                else
                {

                    Filter = GetAllRowFilter(SearchStr);
                }
                this.DataViewHis.RowFilter = Filter;
            }
            else
            {
                if (string.IsNullOrEmpty(SearchStr))
                {
                    this.DataViewHis.RowFilter = string.Empty;
                }
                else
                {
                    Filter = this.GetSearchStrRowFilter(SearchStr);
                    this.DataViewHis.RowFilter = Filter;
                }
            }
        }

        /// <summary>
        /// フォントサイズ値変更
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォントサイズの値が変更された時に発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void FontSize_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // フォントサイズを変更
            this.SearchHis_Grid.DisplayLayout.Appearance.FontData.SizeInPoints = (int)FontSize_tComboEditor.Value;
        }

        /// <summary>
        /// 列サイズの自動調整チェック変更
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 列サイズの自動調整のチェックが変更された時に発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void AutoFitCol_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            // 列サイズの自動調整
            if (this.AutoFitCol_ultraCheckEditor.Checked)
                this.SearchHis_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            else
                this.SearchHis_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn wkColumn in this.SearchHis_Grid.DisplayLayout.Bands[0].Columns)
            {
                wkColumn.PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
        }

        /// <summary>
        /// フォーム閉じる処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void PMKHN09783UB_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.BeforeClosing();
            }
            catch
            {
                // エラーメッセージ表示
                this.ErrMsgDispProc(ColDisplayStatusSaveError, StatusError);

            }
        }

        /// <summary>
        /// フォーカス補正処理
        /// </summary>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーカス移動の補正処理します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>フォーカス補正コントロール</returns>
        private Control GetSearchHisFormFocus(ChangeFocusEventArgs e)
        {
            Control NextControl = null;
            if (e == null || e.PrevCtrl == null) return null;

            switch (e.PrevCtrl.Name)
            {

                #region メーカーコード
                case "tNedit_GoodsMakerCd":
                    if (!e.ShiftKey && (e.Key == Keys.Enter || e.Key == Keys.Tab))
                    {
                        if (this.tNedit_GoodsMakerCd.GetInt() != GoodsMakerCdZero)
                        {
                            // パーコード
                            NextControl = this.tEdit_BarCode;
                        }
                        else
                        {
                            // メーカーガイド
                            NextControl = this.ub_GoodsMakerCd;
                        }
                    }
                    else if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        if (this.SearchHis_Grid.Rows.Count > SearchHisGridRowsCountZero)
                        {
                            // グリッド
                            NextControl = this.SearchHis_Grid;
                            this.SearchHis_Grid.ActiveRow = this.SearchHis_Grid.Rows[0];
                            this.SearchHis_Grid.ActiveRow.Selected = true;
                        }
                        else
                        {
                            // 未登録チェック
                            NextControl = this.CheckEditor_Insert;
                        }
                    }
                    break;
                #endregion
                
                #region メーカーガイドボタン
                case "ub_GoodsMakerCd":
                    if (!e.ShiftKey && (e.Key == Keys.Enter || e.Key == Keys.Tab))
                    {
                        // パーコード
                        NextControl = this.tEdit_BarCode;
                    }
                    else if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        // メーカーコード
                        NextControl = this.tNedit_GoodsMakerCd;
                    }
                    else if (e.Key == Keys.Right)
                    {
                        // 未登録チェック
                        NextControl = this.CheckEditor_Insert;
                    }
                    break;
                #endregion

                #region パーコード
                case "tEdit_BarCode":
                    if (e.Key == Keys.Up)
                    {
                        // メーカーコード
                        NextControl = this.tNedit_GoodsMakerCd;
                    }
                    else if (e.Key == Keys.Down)
                    {
                        // パーコード
                        NextControl = this.tDate_SearchDateBegin;
                    }
                    break;
                #endregion

                #region 検索日付終了
                case "tDate_SearchDateEnd":
                    if (e.Key == Keys.Down)
                    {
                        // 表示絞込条件
                        NextControl = this.tEdit_SeachStr;
                    }
                    else if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        // 表示絞込条件
                        NextControl = this.tEdit_SeachStr;
                    }
                    break;
                #endregion

                #region 未登録チェック
                case "CheckEditor_Insert":
                    if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        if (this.SearchHis_Grid.Rows.Count > SearchHisGridRowsCountZero)
                        {
                            // グリッド
                            NextControl = this.SearchHis_Grid;
                        }
                        else
                        {
                            if (this.uGroupBox_ExtractInfo.Expanded)
                            {
                                // メーカー
                                NextControl = this.tNedit_GoodsMakerCd;
                            }
                            else
                            {
                                // 表示絞込条件
                                NextControl = this.tEdit_SeachStr;
                            }
                        }
                    }
                    else if ((e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter)) || e.Key == Keys.Left)
                    {
                        // 検索文字列
                        NextControl = this.tEdit_SeachStr;
                    }
                    else if (e.Key == Keys.Down)
                    {
                        if (this.SearchHis_Grid.Rows.Count > SearchHisGridRowsCountZero)
                        {
                            // グリッド
                            NextControl = this.SearchHis_Grid;
                        }
                        else
                        {
                            // 移動しない
                            NextControl = this.CheckEditor_Insert;
                        }
                    }
                    else if (e.Key == Keys.Up)
                    {
                        // 検索日付終了の年
                        NextControl = this.tDate_SearchDateEnd.Controls[5];
                    }
                    break;
                #endregion

                #region 表示絞込条件
                case "tEdit_SeachStr":
                    if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        if (this.uGroupBox_ExtractInfo.Expanded)
                        {
                            // 検索日付終了
                            NextControl = this.tDate_SearchDateEnd;
                        }
                        else
                        {
                            if (this.SearchHis_Grid.Rows.Count > SearchHisGridRowsCountZero)
                            {
                                // グリッド
                                NextControl = this.SearchHis_Grid;
                            }
                            else
                            {
                                // 未登録チェック
                                NextControl = this.CheckEditor_Insert;
                            }
                        }
                    }
                    else if (e.Key == Keys.Down)
                    {
                        if (this.SearchHis_Grid.Rows.Count > SearchHisGridRowsCountZero)
                        {
                            // グリッド
                            NextControl = this.SearchHis_Grid;
                        }
                        else
                        {
                            // 移動しない
                            NextControl = this.tEdit_SeachStr;
                        }
                    }
                    else if (e.Key == Keys.Up)
                    {
                        // 検索日付開始の年
                        NextControl = this.tDate_SearchDateBegin.Controls[5];
                    }
                    break;
                #endregion

                #region グリッド
                case "SearchHis_Grid":

                    if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        NextControl = this.CheckEditor_Insert;
                    }
                    else if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                    {
                        if (this.uGroupBox_ExtractInfo.Expanded)
                        {
                            NextControl = this.tNedit_GoodsMakerCd;
                        }
                        else
                        {
                            NextControl = this.tEdit_SeachStr;
                        }
                    }

                    break;
                #endregion

                default:
                    break;
            }
            return NextControl;
        }

        #endregion

        #region ◆Private Method

        /// <summary>
        ///	画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面の初期設定を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // スキン設定
            this.ControlScreenSkinAccessor.LoadSkin();
            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.uGroupBox_ExtractInfo.Name);
            this.ControlScreenSkinAccessor.SetExceptionCtrl(excCtrlNm);
            this.ControlScreenSkinAccessor.SettingScreenSkin(this);

            // アイコン設定
            this.ImageList16 = IconResourceManagement.ImageList16;

            // ガイドボタンのアイコン設定
            this.ub_GoodsMakerCd.Appearance.Image = this.ImageList16.Images[(int)Size16_Index.STAR1];

            // イメージリスト設定
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;

            //----------------------------
            // ツールアイコン設定
            //----------------------------
            // 終了
            this.tToolsManager_MainMenu.Tools[ButtonToolClose].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // 検索
            this.tToolsManager_MainMenu.Tools[ButtonToolSearch].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // クリア
            this.tToolsManager_MainMenu.Tools[ButtonToolClear].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // ログイン担当者
            this.tToolsManager_MainMenu.Tools[LabelToolLoginTitle].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // 担当者表示
            if (LoginInfoAcquisition.Employee != null)
            {
                this.tToolsManager_MainMenu.Tools[LabelToolLoginName].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            this.MakerGoodsPtrnHisDs = new MakerGoodsPtrnHisDataSet();

            this.DataViewHis = new DataView(this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList);

            this.SearchHis_Grid.DataSource = this.DataViewHis;

            // グリッド列初期設定処理
            InitializeGridColumns(this.SearchHis_Grid.DisplayLayout.Bands[0].Columns);
        }

        /// <summary>
        ///	画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面をクリアします。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        ///</remarks>
        private void ScreenClear()
        {
            // 画面内容をクリア
            this.tDate_SearchDateBegin.Clear();
            this.tDate_SearchDateEnd.Clear();
            this.tNedit_GoodsMakerCd.Clear();
            this.lb_GoodsMakerName.Text = string.Empty;
            this.PrevGoodsMakerCode = string.Empty;
            this.PrevGoodsMakerName = string.Empty;

            this.tEdit_BarCode.Text = string.Empty;
            this.tEdit_SeachStr.Text = string.Empty;
            this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.Clear();

            // 検索日付⇒システム日付セット
            DateTime dateTime = DateTime.Now;
            this.tDate_SearchDateBegin.SetDateTime(dateTime);
            this.tDate_SearchDateEnd.SetDateTime(dateTime);

            this.CheckEditor_Insert.Checked = false;

            this.tNedit_GoodsMakerCd.Focus();

        }

        /// <summary>
        /// 入力項目チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入力項目をチェックします。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>チェック結果[true: チェックOK, false: チェックエラー]</returns>
        private bool CheckInputPara()
        {
            DateGetAcs.CheckDateResult Cdr;

            // 検索日付開始
            if (this.tDate_SearchDateBegin.GetLongDate() != LongDateZero)
            {
                // 無効年月日の場合
                Cdr = this.DateGetAccessor.CheckDate(ref this.tDate_SearchDateBegin, true);

                if (Cdr != DateGetAcs.CheckDateResult.OK)
                {
                    this.tDate_SearchDateBegin.Focus();

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        SearchDateBeginInvalidDate,
                        StatusNormal,
                        MessageBoxButtons.OK);

                    return false;
                }
            }

            // 検索日付終了
            if (this.tDate_SearchDateEnd.GetLongDate() != LongDateZero)
            {
                // 無効年月日の場合
                Cdr = this.DateGetAccessor.CheckDate(ref this.tDate_SearchDateEnd, true);

                if (Cdr != DateGetAcs.CheckDateResult.OK)
                {
                    this.tDate_SearchDateEnd.Focus();

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        SearchDateEndInvalidDate,
                        StatusNormal,
                        MessageBoxButtons.OK);

                    return false;
                }
            }

            // 検索日付開始、終了
            // 開始、終了の大小比較
            if (this.tDate_SearchDateBegin.GetLongDate() != LongDateZero && this.tDate_SearchDateEnd.GetLongDate() != LongDateZero)
            {
                if (this.tDate_SearchDateBegin.GetLongDate() > this.tDate_SearchDateEnd.GetLongDate())
                {
                    this.tDate_SearchDateBegin.Focus();

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        SearchDateStartEndError,
                        StatusNormal,
                        MessageBoxButtons.OK);

                    return false;
                }
            }

            return true;
        }

        #region グリッドレイアウト設定処理
        /// <summary>
        /// グリッドレイアウト設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドレイアウトを設定します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            int visiblePosition = 0;

            // セル選択時は行選択に
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.SearchHis_Grid.DisplayLayout.Bands[0];
            for (int i = 0; i < band.Columns.Count; i++)
            {
                band.Columns[i].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            }

            // 商品メーカーコード
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn.ColumnName].Header.Caption = GoodsMakerCdCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn.ColumnName].Width = 70;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn.ColumnName].Header.Fixed = true;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 商品メーカー名
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn.ColumnName].Header.Caption = GoodsMakerNameCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn.ColumnName].Width = 180;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn.ColumnName].Header.Fixed = true;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 最終日付
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn.ColumnName].Header.Caption = SearchDateCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn.ColumnName].Width = 100;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn.ColumnName].Header.Fixed = true;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // バーコード
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn.ColumnName].Header.Caption = BarCodeDataCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn.ColumnName].Width = 120;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn.ColumnName].Header.Fixed = true;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // パターン№
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn.ColumnName].Header.Caption = MakerGoodsPtrnNoCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn.ColumnName].Width = 100;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 検索品番
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn.ColumnName].Header.Caption = SearchGoodsNoCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn.ColumnName].Width = 120;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 確定品番
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName].Header.Caption = EntryGoodsNoCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName].Width = 120;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 回数(グリッド表示用)
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn.ColumnName].Header.Caption = UseCountCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            // --- UPD 2020/04/28 M.KISHI ---------->>>>>
            //columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn.ColumnName].Width = 60;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn.ColumnName].Width = 30;
            // --- UPD 2020/04/28 M.KISHI ----------<<<<<
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // --- ADD 2020/04/28 M.KISHI ---------->>>>>

            // 回数(フィルタ用)
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn.ColumnName].Hidden = true;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn.ColumnName].Header.Caption = UseCountCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn.ColumnName].Width = 30;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 発注
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn.ColumnName].Header.Caption = UoeOrderDtlKindCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn.ColumnName].Width = 30;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2020/04/28 M.KISHI ----------<<<<<

            // 結果
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn.ColumnName].Header.Caption = EntryStatusCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn.ColumnName].Width = 100;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn.ColumnName].Header.Fixed = true;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // パターン検索履歴通番
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsSerchHisNoColumn.ColumnName].Hidden = true;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsSerchHisNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsSerchHisNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsSerchHisNoColumn.ColumnName].Width = 50;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsSerchHisNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsSerchHisNoColumn.ColumnName].Header.Fixed = true;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsSerchHisNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //-------------------------------------------------------------
            // 前回表示情報設定
            //-------------------------------------------------------------
            // 列表示状態クラスリストXMLファイルをデシリアライズ
            List<ColDisplayStatus> colDisplayStatusList = this.Deserialize(FileNameColDisplayStatus);

            foreach (ColDisplayStatus colDisplayStatus in colDisplayStatusList)
            {
                if (colDisplayStatus.Key == this.FontSize_tComboEditor.Name)
                {
                    this.FontSize_tComboEditor.Value = colDisplayStatus.Width;
                }
                else if (columns.Exists(colDisplayStatus.Key))
                {
                    columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
                    columns[colDisplayStatus.Key].Header.Fixed = colDisplayStatus.HeaderFixed;
                    columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
                }
            }
        }
        #endregion

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカー品番パターン検索履歴情報の検索処理を行ないます。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>[0: 正常, 4: 検索結果0件,0、4以外: 異常]</returns>
        private int SearchProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // パラメータを設定
            HandyMakerGoodsPtrnHisCondWork condWork = new HandyMakerGoodsPtrnHisCondWork();
            // 企業コード
            condWork.EnterpriseCode = this.EnterpriseCode;
            // メーカーコード
            condWork.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            // 検索日付開始
            condWork.SearchDateSt = GetLongDate(this.tDate_SearchDateBegin.GetDateTime());
            // 検索日付終了
            condWork.SearchDateEd = GetLongDate(this.tDate_SearchDateEnd.GetDateTime());
            // パーコード
            condWork.BarCodeData = this.tEdit_BarCode.Text.Trim();

            // 抽出中画面インスタンス作成
            Broadleaf.Windows.Forms.SFCMN00299CA sfcmn00299ca = new Broadleaf.Windows.Forms.SFCMN00299CA();
            sfcmn00299ca.Title = SearchFormTitle;
            sfcmn00299ca.Message = SearchFormMessage;

            ArrayList makerGoodsPtrnHisList = new ArrayList();
            object condObj = condWork as object;
            object retObj = null;

            try
            {
                // 抽出中画面を表示します。
                sfcmn00299ca.Show();
                status = this.HandyMakerGoodsPtrnAccessor.SearchHis(condObj, out retObj);
                makerGoodsPtrnHisList = (ArrayList)retObj;
            }
            finally
            {
                // 抽出中画面を閉じます。
                sfcmn00299ca.Close();
                // グリッドをクリアします。
                this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.Clear();
           }

            #region < 検索後処理 >
            switch (status)
            {
                #region -- 正常終了 --
                // 全件取得メソッドの結果が"正常終了"のとき
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 検索結果はグリッドに設定します。
                        this.HisGridSetting(makerGoodsPtrnHisList);
                        // グリッド選択行を設定します。
                        if (this.SearchHis_Grid.Rows.Count > SearchHisGridRowsCountZero)
                        {
                            this.SearchHis_Grid.Focus();
                            this.SearchHis_Grid.ActiveRow = this.SearchHis_Grid.Rows[0];
                            this.SearchHis_Grid.ActiveRow.Selected = true;
                        }
                        // 検索後、フィールドします。
                        this.CheckEditor_SearchHis_CheckedChanged(null, null);

                        break;
                    }
                #endregion

                #region -- データ無し --
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        this.InfoMsgDispProc(DataInfoEmptyError, status);
                        break;
                    }
                #endregion

                #region -- 検索失敗 --
                default:
                    {
                        this.ErrMsgDispProc(HisInfoSearchError, status);
                        break;
                    }
                #endregion
            }
            #endregion

            return status;

        }

        /// <summary>
        /// アクティブコントロール取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : アクティブコントロールを取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private Control GetActiveControl()
        {
            Control Ctrl = this.ActiveControl;

            if (Ctrl != null)
            {
                Ctrl = this.GetParentControl(Ctrl);
            }

            return Ctrl;
        }

        /// <summary>
        /// 親コントロール取得処理
        /// </summary>
        /// <param name="ctrl">子コントロール</param>
        /// <remarks>
        /// <br>Note       : 親コントロールを取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>親コントロール</returns>
        private Control GetParentControl(Control ctrl)
        {
            Control RetCtrl = ctrl;
            if (RetCtrl.Parent != null)
            {
                if ((RetCtrl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
                    (RetCtrl.Parent is Broadleaf.Library.Windows.Forms.TEdit) ||
                    (RetCtrl.Parent is Broadleaf.Library.Windows.Forms.TDateEdit) ||
                    (RetCtrl.Parent is Broadleaf.Library.Windows.Forms.TComboEditor))
                {
                    RetCtrl = GetParentControl(RetCtrl.Parent);
                }
            }

            return RetCtrl;
        }

        /// <summary>
        /// グリッドに情報設定処理
        /// </summary>
        /// <param name="searchHisList">メーカー品番パータン検索履歴情報リスト</param>
        /// <remarks>
        /// <br>Note       : グリッドにメーカー品番パータン検索履歴情報を設定します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void HisGridSetting(ArrayList searchHisList)
        {
            if (searchHisList == null || searchHisList.Count == SearchHisGridRowsCountZero)
            {
                return;
            }

            this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BeginLoadData();
            this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.Rows.Clear();

            DataRow Row = null;
            foreach (HandyMakerGoodsPtrnHisResultWork dataWork in searchHisList)
            {
                
                Row = this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.NewRow();

                // 商品メーカーコード
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn] = dataWork.GoodsMakerCd.ToString(StringZZZZ);

                // 商品メーカー名称
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn] = dataWork.MakerName;

                // 最終日付
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn] = this.GetStringDateTimeForInt(dataWork.SearchDate);

                // パーコード
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn] = dataWork.BarCodeData;

                // パターン№
                if (dataWork.MakerGoodsPtrnNo != 0)
                {
                    Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn] = dataWork.MakerGoodsPtrnNo.ToString(StringZZZZZZ);
                }

                // 検索品番
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn] = dataWork.SearchGoodsNo;

                // 確定品番
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn] = dataWork.EntryGoodsNo;

                // 回数
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn] = dataWork.UseCount;
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn] = dataWork.UseCount;

                // --- ADD 2020/04/28 M.KISHI ---------->>>>>
                // 発注
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn] =　this.GetUoeOrderDtlKind(dataWork.UOEOrderTdlKind);
                // --- ADD 2020/04/28 M.KISHI ----------<<<<<

                // 結果
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn] = this.GetEntryStatus(dataWork.EntryStatus);

                this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.Rows.Add(Row);
            }
            this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EndLoadData();
        }

        /// <summary>
        /// 登録ステータス結果取得　※コード⇒名称
        /// </summary>
        /// <param name="entryStatus">登録ステータス</param>
        /// <remarks>
        /// <br>Note       : 登録ステータス結果を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>登録ステータス結果</returns>
        private string GetEntryStatus(int entryStatus)
        {
            string statusNm = string.Empty;
            switch (entryStatus)
            {
                // 0:未登録
                case 0:
                    statusNm = Status0;
                    break;
                // 1:正常登録
                case 1:
                    statusNm = Status1;
                    break;
                // -1:登録エラー
                case -1:
                    statusNm = Status2;
                    break;
            }
            return statusNm;
        }

        // --- ADD 2020/04/28 M.KISHI ---------->>>>>
        /// <summary>
        /// UOE発注データ区分取得　※コード⇒名称
        /// </summary>
        /// <param name="uoeOrderDtlKind">登録ステータス</param>
        /// <remarks>
        /// <br>Note       : UOE発注データ区分を取得します。</br>
        /// <br>Programmer : 岸</br>
        /// <br>Date       : 2020/04/28</br>
        /// </remarks>
        /// <returns>UOE発注データ区分名</returns>
        private string GetUoeOrderDtlKind(int uoeOrderDtlKind)
        {
            string statusNm = string.Empty;
            switch (uoeOrderDtlKind)
            {
                // 0:未登録
                case 0:
                    statusNm = string.Empty;
                    break;
                // 1:発注データあり
                case 1:
                    statusNm = KinDUoeOrderExists;
                    break;
                // 以外
                default:
                    statusNm = string.Empty;
                    break;
            }
            return statusNm;
        }
        // --- ADD 2020/04/28 M.KISHI ----------<<<<<


        /// <summary>
        /// int型値からyyyy/MM/dd文字列の変換処理
        /// </summary>
        /// <param name="paraDate">時間数字</param>
        /// <remarks>
        /// <br>Note       : int型値からyyyy/MM/dd文字列を変換します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>変換後yyyy/MM/dd文字列</returns>
        private string GetStringDateTimeForInt(int paraDate)
        {
            string ResultDate = string.Empty;
            string dateStr = paraDate.ToString();
            if (dateStr.Length != StringLengthEight)
            {
                return ResultDate;
            }
            // 年
            int Year = int.Parse(dateStr.Substring(SubstringIndexZero, SubstringIndexFour));
            // 月
            int Month = int.Parse(dateStr.Substring(SubstringIndexFour, SubstringIndexTwo));
            // 日
            int Day = int.Parse(dateStr.Substring(SubstringIndexSix, SubstringIndexTwo));
            // yyyy/MM/dd
            ResultDate = Year.ToString(StringZZZZ) + StringSlash + Month.ToString(StringZZ) + StringSlash + Day.ToString(StringZZ);
            return ResultDate;
        }

        /// <summary>
        /// メーカー情報のキャッシュ処理。
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカー情報をキャッシュします。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>取得結果[0: 取得OK, 0以外: 取得エラー]</returns>
        private int GetGoodsMakerInfo()
        {
            ArrayList MakerList = new ArrayList();
            int Status = this.MakerAccessor.SearchAll(out MakerList, this.EnterpriseCode);

            if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.GoodsMakerDic = new Dictionary<int, string>();
                foreach (MakerUMnt MakerUMntWork in MakerList)
                {
                    if (MakerUMntWork.LogicalDeleteCode == 0 && !this.GoodsMakerDic.ContainsKey(MakerUMntWork.GoodsMakerCd))
                    {
                        this.GoodsMakerDic.Add(MakerUMntWork.GoodsMakerCd, MakerUMntWork.MakerName.Trim());
                    }
                }
            }
            return Status;
        }

        /// <summary>
        /// メーカー名の取得処理。
        /// </summary>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <remarks>
        /// <br>Note       : メーカー名を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>メーカー名</returns>
        private string GetGoodsMakerName(string goodsMakerCode)
        {
            string GoodsMakerName = string.Empty;
            if (string.IsNullOrEmpty(goodsMakerCode)) return GoodsMakerName;
            int goodsMakerCodeInt = int.Parse(goodsMakerCode.Trim());

            if (this.GoodsMakerDic.ContainsKey(goodsMakerCodeInt))
            {
                GoodsMakerName = this.GoodsMakerDic[goodsMakerCodeInt];
            }

            return GoodsMakerName;
        }

        /// <summary>
        /// 未登録チェック行フィルタ文字列の取得処理。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 未登録チェック行フィルタ文字列を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>未登録チェック行フィルタ文字列</returns>
        private string GetCheckedRowFilter()
        {
            return string.Format(" {0} = '{1}' ",
                                   this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName, string.Empty);
        }

        /// <summary>
        /// 行検索フィルタ文字列の取得処理。
        /// </summary>
        /// <param name="searchStr">検索文字列</param>
        /// <remarks>
        /// <br>Note       : 行検索フィルタ文字列を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>行検索フィルタ文字列</returns>
        private string GetSearchStrRowFilter(string searchStr)
        {
            return string.Format("{0} like '%{1}%' OR {2} like '%{3}%' OR {4} like '%{5}%' "
                                + " OR {6} like '%{7}%' OR {8} like '%{9}%' OR {10} like '%{11}%' "
                                + " OR {12} like '%{13}%' OR {14} like '%{15}%' OR {16} like '%{17}%' OR {18} like '%{19}%' ",
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn, searchStr);
        }

        /// <summary>
        /// 未登録行検索フィルタ文字列の取得処理。
        /// </summary>
        /// <param name="searchStr">検索文字列</param>
        /// <remarks>
        /// <br>Note       : 未登録行検索フィルタ文字列を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>未登録行検索フィルタ文字列</returns>
        private string GetAllRowFilter(string searchStr)
        {
            return string.Format(" ({0} like '%{1}%' OR {2} like '%{3}%' OR {4} like '%{5}%' "
                                 + " OR {6} like '%{7}%' OR {8} like '%{9}%' OR {10} like '%{11}%' "
                                 + " OR {12} like '%{13}%' OR {14} like '%{15}%' OR {16} like '%{17}%') "
                                 + " AND {18} = '{19}' ",
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName, string.Empty);
        }

        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void ErrMsgDispProc(string message, int status)
        {
            TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP, 							// エラーレベル
                AssemblyId,						// アセンブリＩＤまたはクラスＩＤ
                AssemblyName,						// プログラム名称
                MethodBase.GetCurrentMethod().Name, // 処理名称
                string.Empty,						// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                string.Empty, 						// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }

        /// <summary>
        /// インフォメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : インフォメッセージの表示を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void InfoMsgDispProc(string message, int status)
        {
            TMsgDisp.Show(this,											// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,					// エラーレベル
                          AssemblyId,									// アセンブリＩＤ
                          message, 										// 表示するメッセージ
                          status,										// ステータス値
                          MessageBoxButtons.OK);						// 表示するボタン
        }

        /// <summary>
        /// 確認（はい、いいえ）ダイアログ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <remarks>
        /// <br>Note       : 確認（はい、いいえ）ダイアログの表示を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>>DialogResult[OK: 確定, OK以外: キャンセル]</returns>
        private DialogResult QuestionYesNoProc(string message)
        {
            DialogResult Dialog = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    AssemblyId,
                    message,
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);
            return Dialog;
        }

        /// <summary>
        /// 確認（はい、いいえ、キャンセル）ダイアログ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <remarks>
        /// <br>Note       : 確認（はい、いいえ、キャンセル）ダイアログの表示を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>>DialogResult[OK: 確定, No:確定なし , Cancel: キャンセル]</returns>
        private DialogResult QuestionYesNoCancelProc(string message)
        {
            DialogResult Dialog = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    AssemblyId,
                    message,
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);
            return Dialog;
        }
        #endregion

        #region 列表示状態構築と保存処理
        /// <summary>
        /// 列表示状態クラスリスト構築処理
        /// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
        /// <returns>列表示状態クラスリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのカラムコレクションを元に、列表示状態クラスリストを構築します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

            // フォントサイズを格納
            ColDisplayStatus fontStatus = new ColDisplayStatus();
            fontStatus.Key = this.FontSize_tComboEditor.Name;
            fontStatus.VisiblePosition = -1;
            fontStatus.Width = (int)this.FontSize_tComboEditor.Value;
            colDisplayStatusList.Add(fontStatus);

            // グリッドから列表示状態クラスリストを構築
            // グループ内の各カラム
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
            {
                ColDisplayStatus colDisplayStatus = new ColDisplayStatus();
                colDisplayStatus.Key = column.Key;
                colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
                colDisplayStatus.HeaderFixed = column.Header.Fixed;
                colDisplayStatus.Width = column.Width;

                colDisplayStatusList.Add(colDisplayStatus);
            }

            return colDisplayStatusList;
        }

        /// <summary>
        /// 終了前処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 終了前処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void BeforeClosing()
        {
            // 列表示状態クラスリスト構築処理
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.SearchHis_Grid.DisplayLayout.Bands[0].Columns);
            // 列表示状態クラスリストをXMLにシリアライズする
            this.Serialize(colDisplayStatusList, FileNameColDisplayStatus);
        }

        /// <summary>
        /// 列表示状態クラスリストシリアライズ処理
        /// </summary>
        /// <param name="colDisplayStatusList">列表示状態クラスリスト</param>
        /// <param name="fileName">ファイル名</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストのシリアライズ処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void Serialize(List<ColDisplayStatus> colDisplayStatusList, string fileName)
        {
            ColDisplayStatus[] colDisplayStatusArray = new ColDisplayStatus[colDisplayStatusList.Count];
            colDisplayStatusList.CopyTo(colDisplayStatusArray);

            UserSettingController.SerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
        }

        /// <summary>
        /// 列表示状態クラスリストデシリアライズ処理
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns>列表示状態クラスリスト</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストのデシリアライズ処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public List<ColDisplayStatus> Deserialize(string fileName)
        {
            List<ColDisplayStatus> retList = new List<ColDisplayStatus>();

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName)) == true)
            {
                try
                {
                    ColDisplayStatus[] retArray = UserSettingController.DeserializeUserSetting<ColDisplayStatus[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

                    foreach (ColDisplayStatus colDisplayStatus in retArray)
                    {
                        retList.Add(colDisplayStatus);
                    }
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
                }
            }

            return retList;
        }
        #endregion

        #region 日付数値取得処理
        /// <summary>
        /// 日付数値取得処理
        /// </summary>
        /// <param name="date">DateTime型日付</param>
        /// <returns>数値日付(YYYYMMDD)</returns>
        /// <remarks
        /// <br>Note       : 日付数値取得処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private static int GetLongDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return 0;
            }
            else
            {
                return ((date.Year * 10000) + (date.Month * 100) + (date.Day));
            }
        }
        #endregion

        #endregion
    }
}
