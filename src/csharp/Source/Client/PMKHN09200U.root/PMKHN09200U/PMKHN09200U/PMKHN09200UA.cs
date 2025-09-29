

//#define _MANUAL_MERGE_PRIME_SETTING_

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Diagnostics;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller.Util;    // ADD 2009/01/22 機能追加

namespace Broadleaf.Windows.Forms
{
    using ProcessConfigAcs = SingletonPolicy<ProcessConfig>;   // ADD 2009/01/30 機能追加
    using LatestPair = Pair<DateTime, int>;
    using Broadleaf.Application.Remoting.ParamData;              // ADD 2009/02/03 機能追加

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// <br>Note       : </br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.05</br>
    /// <br></br>
    /// <br>Update Note: 2010/05/24 朱俊成</br>
    /// <br>             PM.NS1009</br>
    /// <br>             最新履歴削除の追加</br>
    /// </remarks>
    public partial class PMKHN09200UA : Form
    {
        // ADD 2009/01/22 機能追加 ---------->>>>>
        #region [ Const ]

        /// <summary>更新されていない場合のメッセージ</summary>
        private const string MSG_PLEASE_UPDATE = "価格改正が行われていません。更新を行って下さい。";

        /// <summary>選択時の印</summary>
        private const string SELECTED_MARK = "●";

        /// <summary>前回処理日のフォーマット</summary>
        private const string DATE_FORMAT = "yyyy/MM/dd";

        #endregion  // [ Const ]
        // ADD 2008/01/22 機能追加 ----------<<<<<

        #region [ Private Member ]

        private OfferMergeAcs _offerMergeAcs;
        private string _enterpriseCode;
        private dtHist _dtHist;
        private readonly string[] ct_UpdateDiv;

        // --- ADD 2010/05/24 ---------->>>>>
        private ArrayList _historyList;
        // --- ADD 2010/05/24 -----------<<<<<

        // DEL 2009/01/22 機能追加 ---------->>>>>
        /// <summary>
        /// 更新データ区分の名称を取得します。
        /// </summary>
        /// <param name="updateDataDiv">更新データ区分</param>
        /// <returns><c>0</c>:ＵＩ<br/><c>1</c>:自動</returns>
        private string GetUpdateDataDivName(int updateDataDiv)
        {
            return ct_UpdateDiv[updateDataDiv];
        }
        // DEL 2009/01/22 機能追加 ----------<<<<<
        private const int UPDATING_ITEM_COUNT = 11; // MOD 2009/01/30 機能追加：6→11
        private readonly string[] ct_TblIDList;
        private readonly string[] ct_TblNameList;
        private readonly List<string> ct_TblNoUpdList;

        #endregion  // [ Private Member ]

        #region [ コンストラクタ ]

        /// <summary>
        /// 
        /// </summary>
        public PMKHN09200UA()
        {
            _offerMergeAcs = new OfferMergeAcs();
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _offerMergeAcs.Initialize(_enterpriseCode);

            // DEL 2009/01/22 機能追加：自動処理を廃止 ---------->>>>>
            #region 削除コード
            //if (Program._parameter.Length > 0) // 自動起動の場合
            //{
            //    int offerDate;
            //    if (int.TryParse(Program._parameter[0], out offerDate))
            //    {
            //        _OfferMergeAcs.MergeOfferToUser(_enterpriseCode, offerDate);
            //    }
            //    Close();
            //}
            //else // 手動起動の場合
            //{
            #endregion
            // DEL 2009/01/22 機能追加：自動処理を廃止 ----------<<<<<

            ct_UpdateDiv = new string[2] { "ＵＩ", "自動" };
            ct_TblIDList = new string[UPDATING_ITEM_COUNT] {
                ProcessConfig.BL_CODE_MASTER_ID,        // MOD 2009/01/30 機能追加："BLGOODSCDURF"→ProcessConfig.BL_CODE_MASTER_ID
                ProcessConfig.BL_GROUP_MASTER_ID,       // MOD 2009/01/30 機能追加："BLGROUPURF"→ProcessConfig.BL_GROUP_MASTER_ID
                ProcessConfig.MIDDLE_GENRE_MASTER_ID,   // MOD 2009/01/30 機能追加："GOODSGROUPURF"→ProcessConfig.MIDDLE_GENRE_MASTER_ID
                ProcessConfig.MODEL_NAME_MASTER_ID,     // MOD 2009/01/30 機能追加："MODELNAMEURF"→ProcessConfig.MODEL_NAME_MASTER_ID
                ProcessConfig.MAKER_MASTER_ID,          // MOD 2009/01/30 機能追加："MAKERURF"→ProcessConfig.MAKER_MASTER_ID
                ProcessConfig.PARTS_POS_CODE_MASTER_ID, // MOD 2009/01/30 機能追加："PARTSPOSCODEURF"→ProcessConfig.PARTS_POS_CODE_MASTER_ID
                ProcessConfig.PRIME_SETTING_MASTER_ID,          // ADD 2009/01/30 機能追加
                ProcessConfig.PRIME_SETTING_CHANGE_MASTER_ID,   // ADD 2009/01/30 機能追加
                ProcessConfig.GOODS_MASTER_ID,                  // ADD 2009/01/30 機能追加
                ProcessConfig.GOODS_PRICE_MASTER_ID,            // ADD 2009/01/30 機能追加  
                ProcessConfig.PRICE_REVISION_ID                 // ADD 2009/01/30 機能追加
            };
            ct_TblNameList = new string[UPDATING_ITEM_COUNT] {
                ProcessConfig.BL_CODE_MASTER_NAME,          // MOD 2009/01/30 機能追加："BLコードマスタ"→ProcessConfig.BL_CODE_MASTER_NAME
                ProcessConfig.BL_GROUP_MASTER_NAME,         // MOD 2009/01/30 機能追加："BLグループマスタ"→ProcessConfig.BL_GROUP_MASTER_NAME
                ProcessConfig.MIDDLE_GENRE_MASTER_NAME,     // MOD 2009/01/30 機能追加："中分類マスタ"→ProcessConfig.MIDDLE_GENRE_MASTER_NAME
                ProcessConfig.MODEL_NAME_MASTER_NAME,       // MOD 2009/01/30 機能追加："車種マスタ"→ProcessConfig.MODEL_NAME_MASTER_NAME
                ProcessConfig.MAKER_MASTER_NAME,            // MOD 2009/01/30 機能追加："メーカーマスタ"→ProcessConfig.MAKER_MASTER_NAME
                ProcessConfig.PARTS_POS_CODE_MASTER_NAME,   // MOD 2009/01/30 機能追加："部位マスタ"→ProcessConfig.PARTS_POS_CODE_MASTER_NAME
                ProcessConfig.PRIME_SETTING_MASTER_NAME,        // ADD 2009/01/30 機能追加
                ProcessConfig.PRIME_SETTING_CHANGE_MASTER_NAME, // Add 2009/01/30 機能追加
                ProcessConfig.GOODS_MASTER_NAME,                // ADD 2009/01/30 機能追加
                ProcessConfig.GOODS_PRICE_MASTER_NAME,          // ADD 2009/01/30 機能追加
                ProcessConfig.PRICE_REVISION_NAME               // ADD 2009/01/30 機能追加
            };
            // DEL 2009/01/22 機能追加↓：価格改正を追加
            //ct_TblNoUpdList = new List<string>(new string[2] { "MODELNAMEURF", "MAKERURF" });
            // ADD 2009/01/30 機能追加：価格改正 ---------->>>>>
            ct_TblNoUpdList = new List<string>(new string[4] {
                ProcessConfig.MODEL_NAME_MASTER_ID,
                ProcessConfig.MAKER_MASTER_ID,
                ProcessConfig.PRIME_SETTING_MASTER_ID,
                ProcessConfig.PRICE_REVISION_ID
            });
            // ADD 2008/01/30 機能追加：価格改正 ----------<<<<<

            InitializeComponent();

            _dtHist = new dtHist();

            ultraToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            ultraToolbarsManager1.Tools["Btn_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            ultraToolbarsManager1.Tools["Btn_Update"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;

            // ADD 2009/01/22 機能追加：[抽出]ツールボタン ---------->>>>>
            // [抽出]ツールボタン
            //ultraToolbarsManager1.Tools["Btn_Extraction"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            //ultraToolbarsManager1.Tools["Btn_Extraction"].SharedProps.Visible = false;
            // ADD 2008/01/22 機能追加：[抽出]ツールボタン ----------<<<<<

            tabStrip.Tabs[0].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.INPUTCHECK];
            tabStrip.Tabs[1].Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.INPUTCHECK];

            // DEL 2009/01/22 機能追加↓：自動処理を廃止
            //}
        }

        #endregion  // [ コンストラクタ ]

        #region [ 初期処理 ]

        // ADD 2009/01/22 機能追加：バージョンチェック ---------->>>>>
        /// <summary>
        /// フォームのLoadイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PMKHN09200UA_Load(object sender, EventArgs e)
        {
            _offerMergeAcs.MyLogger.Write("起動", "", "起動");  // ADD 2009/02/10 機能追加：ログ出力

            // マージ済みかチェック
            string msg = string.Empty;
            bool isMerged = _offerMergeAcs.Checker.IsMerged(out msg);
            if (!isMerged)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Text,
                    MSG_PLEASE_UPDATE,
                    (int)Result.Code.Normal,
                    MessageBoxButtons.OK
                );
            }

            _offerMergeAcs.MyLogger.Write("マージチェック", "", msg);   // ADD 2009/02/10 機能追加：ログ出力
        }
        // ADD 2008/01/22 機能追加：バージョンチェック ----------<<<<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKHN09200UA_Shown(object sender, EventArgs e)
        {
            //SFCMN00299CA _progressForm = new SFCMN00299CA();
            //_progressForm.Title = "価格改正履歴取得中";
            //_progressForm.Show();
            try
            {
                GetHistory();
                DisplayUpdateList();
                // --- ADD 2010/05/24 ---------->>>>>
                if (null == _historyList)
                {
                    ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.Enabled = false;
                }
                else
                {
                    ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.Enabled = true;
                }
                // --- ADD 2010/05/24 -----------<<<<<
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.ToString());
            }
            finally
            {
                //_progressForm.Close();
                //_progressForm.Dispose();
            }
        }

        #endregion  // [ 初期処理 ]

        #region [ グリッドイベント処理 ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridHist_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // 列幅の自動調整方法
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            e.Layout.Override.HeaderAppearance = appearance1;

            UltraGridBand band0 = e.Layout.Bands[0];
            //band0.Override.HeaderPlacement = HeaderPlacement.FixedOnTop;
            band0.UseRowLayout = true;
            band0.Indentation = 0;

            for (int Index = 0; Index < band0.Columns.Count; Index++)
            {
                // 水平表示位置
                if ((band0.Columns[Index].DataType == typeof(int)) ||
                   (band0.Columns[Index].DataType == typeof(Int64)))
                {
                    band0.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else
                {
                    band0.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                band0.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // 垂直表示位置
                band0.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                //System.Drawing.Size sizeCell = new Size();
                //sizeCell.Width = 55;
                //sizeCell.Height = 30;
                //band0.Columns[Index].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            }
            band0.Override.CellClickAction = CellClickAction.RowSelect;
            if (tabStrip.ActiveTab.Index == 0) // 履歴タブ
            {
                band0.Columns[_dtHist.Hist.SyncTableIDColumn.ColumnName].Hidden = true;

                band0.Columns[_dtHist.Hist.SyncExecuteDateColumn.ColumnName].Width = 150;
            }
            else // 更新処理タブ
            {
                //band0.Override.CellClickAction = CellClickAction.Default;
                for (int i = 0; i < gridHist.Rows.Count; i++)
                {
                    if (ct_TblNoUpdList.Contains(gridHist.Rows[i].Cells[_dtHist.Update.TableIDColumn.ColumnName].Value.ToString()))
                    {
                        gridHist.Rows[i].Cells[_dtHist.Update.UpdateFlgColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image;
                    }
                }
                band0.Columns[_dtHist.Update.TableIDColumn.ColumnName].Hidden = true;
                //band0.Columns[_dtHist.Update.PrevUpdDateColumn.ColumnName].CellClickAction = CellClickAction.CellSelect;
                //band0.Columns[_dtHist.Update.RowCntColumn.ColumnName].CellClickAction = CellClickAction.CellSelect;
                //band0.Columns[_dtHist.Update.TableNmColumn.ColumnName].CellClickAction = CellClickAction.CellSelect;
                //band0.Columns[_dtHist.Update.SelectionColumn.ColumnName].CellClickAction = CellClickAction.CellSelect;
                band0.Columns[_dtHist.Update.UpdateFlgColumn.ColumnName].CellClickAction = CellClickAction.CellSelect;
                band0.Columns[_dtHist.Update.SelectionColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                band0.Columns[_dtHist.Update.RowCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                ColInfo.SetColInfo(band0, _dtHist.Update.SelectionColumn.ColumnName, 2, 0, 2, 2, 40);
                // DEL 2009/01/22 機能追加 ---------->>>>>
                #region 削除コード
                //ColInfo.SetColInfo(band0, _dtHist.Update.TableNmColumn.ColumnName, 4, 0, 20, 2, 400);
                //ColInfo.SetColInfo(band0, _dtHist.Update.UpdateFlgColumn.ColumnName, 24, 0, 2, 2, 40);
                //ColInfo.SetColInfo(band0, _dtHist.Update.PrevUpdDateColumn.ColumnName, 26, 0, 5, 2, 100);
                //ColInfo.SetColInfo(band0, _dtHist.Update.RowCntColumn.ColumnName, 31, 0, 3, 2, 60);
                #endregion
                // DEL 2008/01/22 機能追加 ----------<<<<<
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridHist_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (tabStrip.ActiveTab.Index == 1) // 更新処理タブ
            {
                bool val = !((bool)e.Cell.Value);
                e.Cell.Value = val;

                if (gridHist.Selected.Rows.Count == 0 || e.Cell.Row != gridHist.Selected.Rows[0])
                    e.Cell.Row.Selected = true;
                gridHist.UpdateData();
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridHist_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (tabStrip.ActiveTab.Index == 1)
            {
                // DEL 2009/01/22 機能追加：バージョンチェック ---------->>>>>
                #region 削除コード
                //if (e.Row.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value.Equals("●"))
                //{
                //    e.Row.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = string.Empty;
                //}
                //else
                //{
                //    e.Row.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = "●";

                //}
                #endregion
                // DEL 2009/01/22 機能追加：バージョンチェック ----------<<<<<
                // ADD 2009/01/22 機能追加：バージョンチェック ---------->>>>>
                string tableId = e.Row.Cells[_dtHist.Update.TableIDColumn.ColumnName].Value.ToString();

                //if (tableId.Equals(ProcessConfig.PARTS_POS_CODE_MASTER_ID))
                //{
                //    if (e.Row.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value.ToString() == SELECTED_MARK)
                //    {
                      

                //        e.Row.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = string.Empty;
                //    }
                //    else
                //    {
                //        e.Row.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = SELECTED_MARK;
                //    }
                //}
                //else
                //{
                //    e.Row.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = string.Empty;
                //}

                e.Row.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = GetSelectedMark(tableId);
                // ADD 2008/01/22 機能追加：バージョンチェック ----------<<<<<

                gridHist.UpdateData();
            }
        }

        // ADD 2009/04/02 不具合対応[12899]：スペースキーでの項目選択機能を実装 ---------->>>>>
        /// <summary>
        /// 履歴グリッドのKeyPressイベントハンドラ
        /// </summary>
        /// <remarks>
        /// アクティブタブが[更新]タブの場合、チェックボックスのスペースキー制御を行います。
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void gridHist_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region <Guard Phrase/>

            if (!this.tabStrip.ActiveTab.Index.Equals(1)) return;
            if (!e.KeyChar.Equals(' ')) return;
            if (this.gridHist.ActiveRow == null) return;

            #endregion  // <Guard Phrase/>

            // [名称更新]カラムがチェックボックス設定の場合
            if (!this.gridHist.ActiveRow.Cells[_dtHist.Update.UpdateFlgColumn.ColumnName].Style.Equals(
                Infragistics.Win.UltraWinGrid.ColumnStyle.Image
            ))
            {
                bool updateFlag = (bool)this.gridHist.ActiveRow.Cells[_dtHist.Update.UpdateFlgColumn.ColumnName].Value;
                this.gridHist.ActiveRow.Cells[_dtHist.Update.UpdateFlgColumn.ColumnName].Value = !updateFlag;
            }
        }
        // ADD 2009/04/02 不具合対応[12899]：スペースキーでの項目選択機能を実装 ----------<<<<<

        #endregion  // [ グリッドイベント処理 ]

        #region [ ツールバー処理 ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2010/05/24 朱俊成</br>
        /// <br>             PM1009B</br>
        /// <br>             最新履歴削除の追加</br>
        /// </remarks>
        private void ultraToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Btn_Close":    // ButtonTool
                    _offerMergeAcs.MyLogger.Write("終了", "", "終了");  // ADD 2009/02/10 機能追加：ログ出力
                    Close();
                    break;

                case "Btn_Update":    // 初期マージ処理
                    ManualMerge();
                    break;

                // --- ADD 2010/05/24 ---------->>>>>
                case "Btn_Delete":    // 初期マージ処理
                    DeleteHistory();
                    break;
                // --- ADD 2010/05/24 -----------<<<<<

                // ADD 2009/01/22 機能追加：[抽出]ツールボタン ---------->>>>>
                //case "Btn_Extraction":  // [抽出]ツールボタン
                //    ShowTargetCount();
                //    break;
                // ADD 2008/01/22 機能追加：[抽出]ツールボタン ----------<<<<<
            }
        }

        /// <summary>
        /// 初期マージ処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 削除処理を追加する</br>
        /// <br>Programmer : 朱俊成</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private int ManualMerge()
        {
            int status = 0;
            DialogResult ret = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text, "実行しますか？", 0, MessageBoxButtons.OKCancel);
            if (ret == DialogResult.Cancel)
            {
                return status;
            }

            int selectedFlag = 0;
            int selectedCount = 0;
            bool nameOverwriteFlg = false; ;
            MergeCond mergeCondition = new MergeCond();
            {
                mergeCondition.EnterpriseCode = _enterpriseCode;
                mergeCondition.TargetDate = _dtHist.GetTargetDate();
            }

            // DEL 2009/02/02 機能追加↓
            //for (int i = 0; i < UPDATING_ITEM_COUNT; i++)
            for (int i = 0; i < gridHist.Rows.Count; i++)   // ADD 2009/02/02 機能追加
            {
                if (gridHist.Rows[i].Cells[_dtHist.Update.SelectionColumn.ColumnName].Value.Equals(SELECTED_MARK))
                //if ((string)(_dtHist.Update.Rows[i] as DataRow)[_dtHist.Update.SelectionColumn.ColumnName] == SELECTED_MARK)
                {
                    selectedFlag = 1;
                    selectedCount++;
                }
                else
                {
                    selectedFlag = 0;
                }
                nameOverwriteFlg = (bool)gridHist.Rows[i].Cells[_dtHist.Update.UpdateFlgColumn.ColumnName].Value;
                switch (i)
                {
                    case 0: // BLコードマスタ
                        mergeCondition.BLFlg = selectedFlag;
                        mergeCondition.BLNmOwFlg = nameOverwriteFlg;
                        break;
                    case 1: // BLグループマスタ
                        mergeCondition.BLGroupFlg = selectedFlag;
                        mergeCondition.BLGroupNmOwFlg = nameOverwriteFlg;
                        break;
                    case 2: // 中分類マスタ
                        mergeCondition.GoodsMGroupFlg = selectedFlag;
                        mergeCondition.GoodsMGroupNmOwFlg = nameOverwriteFlg;
                        break;
                    case 3: // 車種マスタ
                        mergeCondition.ModelNameFlg = selectedFlag;
                        mergeCondition.ModelNameNmOwFlg = nameOverwriteFlg;
                        break;
                    case 4: // メーカーマスタ
                        mergeCondition.PMakerFlg = selectedFlag;
                        mergeCondition.PMakerNmOwFlg = nameOverwriteFlg;
                        break;
                    case 5: // 部位マスタ
                        mergeCondition.PartsPosFlg = selectedFlag;
                        mergeCondition.PartsPosNmOwFlg = nameOverwriteFlg;
                        break;
                    // ADD 2009/01/28 機能追加：価格改正、優良設定マスタ ---------->>>>>
                    case 7: // 価格改正
                        mergeCondition.PriceRevisionFlg = selectedFlag;
                        mergeCondition.PriceRevisionNmOwFlg = nameOverwriteFlg;
                        break;
                    default:// 優良設定マスタ
#if _MANUAL_MERGE_PRIME_SETTING_
                        mergeCondition.PrmSetChgFlg     = MergeCond.DOING_FLG_AS_INT;
                        mergeCondition.PrmSetChgNmOwFlg = MergeCond.DOING_FLG_AS_BOOL;
                        mergeCondition.PrmSetFlg        = MergeCond.DOING_FLG_AS_INT;
                        mergeCondition.PrmSetNmOwFlg    = MergeCond.DOING_FLG_AS_BOOL;
#else
                        mergeCondition.PrmSetChgFlg = selectedFlag;
                        mergeCondition.PrmSetChgNmOwFlg = nameOverwriteFlg;
                        mergeCondition.PrmSetFlg = selectedFlag;
                        mergeCondition.PrmSetNmOwFlg = nameOverwriteFlg;
#endif
                        break;
                    // ADD 2008/01/28 機能追加：価格改正、優良設定マスタ ----------<<<<<
                }
            }   // for (int i = 0; i < UPDATING_ITEM_COUNT; i++)

            if (selectedCount == 0)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                    "選択された更新対象テーブルがありません。    \r\n更新対象テーブルを選んで下さい。",
                    0, MessageBoxButtons.OK);
            }
            else
            {
                SFCMN00299CA _progressForm = new SFCMN00299CA();
                _progressForm.Title = "更新処理中";
                _progressForm.Message = "更新処理中です";
                _progressForm.Show();
                try
                {
                    status = _offerMergeAcs.InitialMerge(mergeCondition);
                    _progressForm.Close();
                    _progressForm = null;
                    if (status == 0)
                    {
                        GetHistory(); // マージ成功し履歴更新
                        DisplayUpdateList();

                        // --- ADD 2010/05/24 ---------->>>>>
                        if(null == _historyList)
                        {
                            ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.Enabled = false;
                        }
                        else
                        {
                            ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.Enabled = true;
                        }
                        // --- ADD 2010/05/24 -----------<<<<<

                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                            "更新処理に成功しました。",
                            0, MessageBoxButtons.OK);
                        // 処理後は更新件数を表示し、エラー時は"エラー(エラーコード)"を表示する
                        ShowUpdateResult(status);   // ADD 2009/02/03 機能追加：優良設定マスタと価格改正
                    }
                    else if (status == 800)
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                            "既に更新処理が行われています。",
                            0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                            "更新処理に失敗しました。",
                            0, MessageBoxButtons.OK);
                        // 処理後は更新件数を表示し、エラー時は"エラー(エラーコード)"を表示する
                        ShowUpdateResult(status);   // ADD 2009/02/03 機能追加：優良設定マスタと価格改正
                    }

                }
                // リモート接続異常による例外対応
#if DEBUG
                // デバッグ時は例外を捕捉しない
#else
                catch (Exception ex)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Text,
                    ex.Message,
                    0, MessageBoxButtons.OK);
                    status = -1;
                }
#endif
                finally
                {
                    if (_progressForm != null) _progressForm.Close();
                    //_progressForm.Dispose();
                }
            }

            return status;
        }

        // --- ADD 2010/05/24 ---------->>>>>
        /// <summary>
        /// 価格改正履歴削除
        /// </summary>
        /// <returns></returns>
      　/// <remarks>
        /// <br>Note       : 削除処理を追加する</br>
        /// <br>Programmer : 朱俊成</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private int DeleteHistory()
        {
            int status = 0;
            // 最新バージョンの取得
            int maxVersion = 0;
            string maxVersionStr = null;
            for (int i = 0; i < _historyList.Count; i++)
            {
                PriUpdTblUpdHist hist = _historyList[i] as PriUpdTblUpdHist;
                if (null != hist)
                {
                    int version = System.Int32.Parse(hist.OfferVersion.Replace(".", "").ToString());
                    if (version > maxVersion)
                    {
                        maxVersion = version;
                        maxVersionStr = hist.OfferVersion;
                    }
                    else
                    {
                        continue;
                    }
                }

            }
            // 最新バージョンの明細の取得
            ArrayList retList = new ArrayList(); ;
            for (int i = 0; i < _historyList.Count; i++)
            {
                PriUpdTblUpdHist hist = _historyList[i] as PriUpdTblUpdHist;
                if (null != hist && !string.IsNullOrEmpty(hist.OfferVersion.ToString()) && maxVersionStr.Equals(hist.OfferVersion.ToString()))
                {
                    retList.Add(hist);
                }
            }

            // 確認メッセージの表示
            DialogResult dialogResult = TMsgDisp.Show(
            this, 
            emErrorLevel.ERR_LEVEL_INFO, Text,
            "更新履歴を削除してもよろしいですか？" + "\r\n" + "\r\n" + "対象バージョン：" + maxVersionStr,
            0,
            MessageBoxButtons.OKCancel,
            MessageBoxDefaultButton.Button2);

            // 「いいえ」を選択する場合、画面がそのまま
            if (dialogResult == DialogResult.Cancel)
            {
                return status;
            }

            // 「はい」を選択する場合、削除処理を行う
            status = _offerMergeAcs.DeleteHistory(retList);

            if (0 == status)
            {
                // ログ出力
                _offerMergeAcs.MyLogger.Write("履歴削除", "", maxVersionStr + "を削除");

                // 履歴の再取得
                if (0 != GetHistory())
                {
                    _dtHist.Hist.Clear();

                    _historyList = null;
                }

                // 画面の再描画
                DisplayUpdateList();

                // --- ADD 2010/05/24 ---------->>>>>
                if (null == _historyList)
                {
                    ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.Enabled = false;
                }
                else
                {
                    ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.Enabled = true;
                }
                // --- ADD 2010/05/24 -----------<<<<<

                // マージ済みかチェック
                string msg = string.Empty;
                bool isMerged = _offerMergeAcs.Checker.IsMerged(out msg);
                if (!isMerged)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Text,
                        MSG_PLEASE_UPDATE,
                        (int)Result.Code.Normal,
                        MessageBoxButtons.OK
                    );
                }

            }
            else if(status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
            {
                TMsgDisp.Show(
                this, 
                emErrorLevel.ERR_LEVEL_INFO, 
                Text,
                "既に更新処理が行われています。",
                0, 
                MessageBoxButtons.OK);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_INFO,
                Text,
                "既に削除処理が行われています。",
                0,
                MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(
                this, 
                emErrorLevel.ERR_LEVEL_INFO, 
                Text,
                "削除処理に失敗しました。",
                0, 
                MessageBoxButtons.OK);
            }
            
            return status;
        }
        // --- ADD 2010/05/24 -----------<<<<<

        /// <summary>
        /// 更新履歴取得処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 削除処理を追加する</br>
        /// <br>Programmer : 朱俊成</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private int GetHistory()
        {
            int status;
            ArrayList retList = null;
            try
            {
                // 価格改正更新履歴を検索
                DateTime dtSt = DateTime.Now.AddMonths(-6); // 6か月分履歴取得
                int histStDate = dtSt.Year * 10000 + dtSt.Month * 100 + dtSt.Day;
                status = _offerMergeAcs.GetUpdateHistory(_enterpriseCode, histStDate, 0, out retList);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                    ex.Message,
                    0, MessageBoxButtons.OK);
                Debug.Assert(false, ex.Message + "\n" + ex.ToString());
                status = -1;
            }
            if (status == 0)
            {
                _dtHist.Hist.Clear();

                // --- ADD 2010/05/24 ---------->>>>>
                _historyList = retList;
                // --- ADD 2010/05/24 -----------<<<<<

                for (int i = 0; i < retList.Count; i++)
                {
                    PriUpdTblUpdHist hist = retList[i] as PriUpdTblUpdHist;
                    if (!ContainsDefaultSpan(hist.CreateDateTime)) continue;    // ADD 2009/01/22 機能追加：過去6ヶ月分をグリッド表示

                    dtHist.HistRow historyRow = _dtHist.Hist.NewHistRow();
                    {
                        // 提供日付
                        if (hist.OfferDate != 0)
                        {
                            historyRow.OfferDate = hist.OfferDate.ToString("####/##/##");
                        }
                        else
                        {
                            historyRow.OfferDate = "0001/01/01";
                        }
                        // 実行日
                        // DEL 2009/01/22 機能追加↓：実行日は時刻まで表示
                        //historyRow.SyncExecuteDate = hist.SyncExecuteDate.ToString("####/##/##");
                        //historyRow.SyncExecuteDate = hist.CreateDateTime.ToString("yyyy/MM/dd hh:mm"); // ADD 2009/01/22 機能追加：実行日は時刻まで表示
                        historyRow.SyncExecuteDate = hist.CreateDateTime.ToString("yyyy/MM/dd HH:mm"); // ADD 2009/01/22 機能追加：実行日は時刻まで表示
                        // 対象データ
                        historyRow.SyncTableName = hist.SyncTableName;
                        historyRow.SyncTableID = hist.SyncTableID;

                        // 更新行数
                        historyRow.AddUpdateRowsNo = hist.AddUpdateRowsNo;

                        // 更新区分
                        if (hist.UpdateDataDiv == 0 || hist.UpdateDataDiv == 1)
                        {
                            historyRow.UpdateDataDiv = ct_UpdateDiv[hist.UpdateDataDiv];
                        }

                        // ADD 2009/01/22 機能追加：カラム（提供バージョン）の追加 ---------->>>>>
                        // 提供バージョン
                        historyRow.OfferVersion = hist.OfferVersion;
                        // ADD 2009/01/22 機能追加：カラム（提供バージョン）の追加 ----------<<<<<
                    }

                    _dtHist.Hist.AddHistRow(historyRow);
                }   // for (int i = 0; i < retList.Count; i++)

                // グリッドの表示条件
                //_dtHist.Hist.DefaultView.RowFilter = GetDefaultHistoryRowFilter();  // ADD 2009/01/22 機能追加：更新データ区分=1のものをグリッド表示
                _dtHist.Hist.DefaultView.Sort = _dtHist.Hist.SyncExecuteDateColumn.ColumnName + " DESC";
            }

            return status;
            //gridHist.BeginUpdate();
            //gridHist.DataSource = _dtHist.Hist.DefaultView;
            //gridHist.EndUpdate();
        }

        /// <summary>
        /// 更新履歴表示処理
        /// </summary>
        private void DisplayUpdateList()
        {
            // ADD 2009/01/22 機能追加 ---------->>>>>
            // 前回処理日／更新件数の設定用に価格改正更新履歴をフィルタ
            string beforeRowFilter = _dtHist.Hist.DefaultView.RowFilter;
            string beforeSort = _dtHist.Hist.DefaultView.Sort;
            StringBuilder rowFilter = new StringBuilder();
            {
                // 最終更新日は、履歴データより取得する（更新データ区分=0：UI）
                rowFilter.Append(_dtHist.Hist.UpdateDataDivColumn.ColumnName);
                rowFilter.Append(ADOUtil.EQ);
                rowFilter.Append(ADOUtil.GetString(GetUpdateDataDivName((int)PriUpdTblUpdHist.UpdateDataDivValue.UI)));
            }
            try
            {
                _dtHist.Hist.DefaultView.RowFilter = rowFilter.ToString();

                IDictionary<string, LatestPair> latestTableMap = _offerMergeAcs.GetLatestHistoryMap(_enterpriseCode);
                if (latestTableMap != null)
                {
                    if (latestTableMap.Count != 0)
                    {

                        // ADD 2008/01/22 機能追加 ----------<<<<<

                        _dtHist.Update.Clear();

                        IList<ProcessConfigItem> processConfigItemList = new List<ProcessConfigItem>(); // ADD 2009/01/30 機能追加
                        for (int i = 0; i < UPDATING_ITEM_COUNT; i++)  // 更新項目
                        {
                            dtHist.UpdateRow updateRow = _dtHist.Update.NewUpdateRow();

                            // ADD 2009/01/22 機能追加：バージョンチェック ---------->>>>>
                            // 選択：マージ済みではない場合、全て選択
                            if (!_offerMergeAcs.Checker.IsMerged())
                            {
                                updateRow.Selection = SELECTED_MARK;
                            }
                            // ADD 2008/01/22 機能追加：バージョンチェック ----------<<<<<

                            // 対象データ
                            updateRow.TableID = ct_TblIDList[i];
                            updateRow.TableNm = ct_TblNameList[i];


                            // 名称更新
                            updateRow.UpdateFlg = _offerMergeAcs.NameOverwrite;

                            // DEL 2009/01/22 機能追加：対象件数の追加 ---------->>>>>
                            #region 削除コード

                            //// 前回処理日／更新件数
                            //for (int j = 0; j < _dtHist.Hist.DefaultView.Count; j++)
                            //{
                            //    dtHist.HistRow historyRow = _dtHist.Hist.DefaultView[j].Row as dtHist.HistRow;

                            //    if (historyRow.AddUpdateRowsNo.Equals("エラー")) continue;  // ADD 2009/01/22 機能追加：価格改正の追加

                            //    // DEL 2009/01/22 機能追加↓：価格改正の追加
                            //    //if (historyRow.SyncTableID == updateRow.TableID && historyRow.AddUpdateRowsNo != "エラー")
                            //    if (historyRow.SyncTableID.Equals(updateRow.TableID))
                            //    {
                            //        updateRow.PrevUpdDate = historyRow.SyncExecuteDate; // 前回処理日
                            //        updateRow.RowCnt = historyRow.AddUpdateRowsNo;      // 更新件数
                            //        break;
                            //    }
                            //}   // for (int j = 0; j < _dtHist.Hist.DefaultView.Count; j++)

                            #endregion
                            // DEL 2009/01/22 機能追加：対象件数の追加 ----------<<<<<

                            // ADD 2009/01/22 機能追加：対象件数の追加 ---------->>>>>
                            // 前回処理日／更新件数
                            if (latestTableMap.ContainsKey(updateRow.TableID))
                            {
                                if (updateRow.TableID == "PRMSETTINGCHGRF") continue;

                                // 前回処理日
                                DateTime prevUpdDate = latestTableMap[updateRow.TableID].First;
                                string strPrevUpdDate = prevUpdDate.ToString(DATE_FORMAT);
                                if (prevUpdDate.Equals(DateTime.MinValue))
                                {
                                    strPrevUpdDate = string.Empty;
                                }

                                // 更新件数
                                int rowCnt = latestTableMap[updateRow.TableID].Second;
                                string strRowCnt = rowCnt.ToString();
                                if (rowCnt.Equals(0) || string.IsNullOrEmpty(strPrevUpdDate))
                                {
                                    strRowCnt = string.Empty;
                                }

                                updateRow.PrevUpdDate = strPrevUpdDate;   // 前回処理日
                                updateRow.RowCnt = strRowCnt;        // 更新件数
                            }

                            // 対象件数
                            updateRow.TargetCnt = 0;
                            // ADD 2009/01/22 機能追加：対象件数の追加 ----------<<<<<

                            // DEL 2009/01/30 機能追加↓
                            //_dtHist.Update.AddUpdateRow(updateRow);
                            // ADD 2009/01/30 機能追加：価格改正 ---------->>>>>
                            // 非表示行はグリッドに表示しない
                            if (IsVisibledRow(updateRow.TableID))
                            {
                                _dtHist.Update.AddUpdateRow(updateRow);
                            }

                            processConfigItemList.Add(new ProcessConfigItem(
                                updateRow.Selection.Equals(SELECTED_MARK),
                                updateRow.TableID,
                                updateRow.TableNm,
                                updateRow.UpdateFlg,
                                ProcessConfigItem.ConvertPreviousDate(updateRow.PrevUpdDate),
                                ProcessConfigItem.ConvertPreviousCount(updateRow.RowCnt),
                                updateRow.TargetCnt
                            ));
                            // ADD 2008/01/30 機能追加：価格改正 ----------<<<<<
                        } // for (int i = 0; i < UPDATING_ITEM_COUNT; i++)



                        // ADD 2009/01/30 機能追加：価格改正 ---------->>>>>
                        // 価格改正の前回処理日と更新件数を設定
                        ProcessConfigAcs.Instance.Policy.Initialize(processConfigItemList);

                        #region 削除コード

                        //StringBuilder where = new StringBuilder();
                        //{
                        //    where.Append(_dtHist.Update.TableIDColumn.ColumnName);
                        //    where.Append(ADOUtil.EQ);
                        //    where.Append(ADOUtil.GetString(ProcessConfig.PRICE_REVISION_ID));
                        //}
                        //DataRow[] priceRevisionRows = _dtHist.Update.Select(where.ToString());
                        //dtHist.UpdateRow priceRevisionRow = (dtHist.UpdateRow)priceRevisionRows[0];
                        //{
                        //    priceRevisionRow.PrevUpdDate= dtHist.GetPrevUpdDate(ProcessConfigAcs.Instance.Policy.PriceRevision.PreviousDate);
                        //    priceRevisionRow.RowCnt = dtHist.GetRowCnt(ProcessConfigAcs.Instance.Policy.PriceRevision.PreviousCount);
                        //}

                        #endregion
                        // ADD 2008/01/30 機能追加：価格改正 ----------<<<<<

                        // グリッドの設定
                        if (tabStrip.SelectedTab.Index == 1) // 更新処理タブ
                        {
                            for (int i = 0; i < gridHist.Rows.Count; i++)
                            {
                                // ADD 2009/02/23 不具合対応[11497] ---------->>>>>
                                // 優良設定マスタは手動更新を行えない
                                if (gridHist.Rows[i].Cells[_dtHist.Update.TableIDColumn.ColumnName].Value.ToString().Equals(ProcessConfig.PRIME_SETTING_MASTER_ID))
                                {
                                    gridHist.Rows[i].Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = string.Empty;
                                }
                                // ADD 2009/02/23 不具合対応[11497] ----------<<<<<

                                // 名称更新チェックボックスの表示設定
                                if (ct_TblNoUpdList.Contains(gridHist.Rows[i].Cells[_dtHist.Update.TableIDColumn.ColumnName].Value.ToString()))
                                {
                                    gridHist.Rows[i].Cells[_dtHist.Update.UpdateFlgColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image;
                                }
                            }
                        }
                        // グリッドの先頭行を選択
                        if (gridHist.Rows.Count > 0)
                        {
                            gridHist.Select();
                            gridHist.Rows[0].Selected = true;
                        }

                        ShowTargetCount();  // 最新情報を再取得
                        // ADD 2009/01/22 機能追加 ---------->>>>>
                    }
                    else
                    {
                        DialogResult ret = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text, "履歴情報が0件です。", 0, MessageBoxButtons.OK);
                    }
                }
                else
                {
                    DialogResult ret = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text, "履歴情報の取得に失敗しました。", 0, MessageBoxButtons.OK);
                }
            }
            catch
            {
                DialogResult ret = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text, "更新情報の作成に失敗しました。", 0, MessageBoxButtons.OK);
            }
            finally
            {
                _dtHist.Hist.DefaultView.RowFilter = beforeRowFilter;
                _dtHist.Hist.DefaultView.Sort = beforeSort;
            }
            // ADD 2008/01/22 機能追加 ----------<<<<<
        

        }

        #endregion  // [ ツールバー処理 ]

        #region [ その他イベント処理 ]

        /// <summary>
        /// タブ選択処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2010/05/24 朱俊成</br>
        /// <br>             PM1009B</br>
        /// <br>             最新履歴削除の追加</br>
        /// </remarks>
        private void tabStrip_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (e.Tab.Index == 0) // 履歴タブ
            {
                ultraToolbarsManager1.Tools["Btn_Update"].SharedProps.Visible = false;

                // --- ADD 2010/05/24 ---------->>>>>
                ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.Visible = true;
                // --- ADD 2010/05/24 -----------<<<<<

                // [抽出]ツールボタンを非表示
                //ultraToolbarsManager1.Tools["Btn_Extraction"].SharedProps.Visible = false;  // ADD 2009/01/22 機能追加：[抽出]ツールボタン

                gridHist.BeginUpdate();
                gridHist.DataSource = _dtHist.Hist.DefaultView;
                gridHist.EndUpdate();
            }
            else // 更新処理タブ
            {
                ultraToolbarsManager1.Tools["Btn_Update"].SharedProps.Visible = true;

                // --- ADD 2010/05/24 ---------->>>>>
                ultraToolbarsManager1.Tools["Btn_Delete"].SharedProps.Visible = false;
                // --- ADD 2010/05/24 -----------<<<<<

                // [抽出]ツールボタンを表示
                //ultraToolbarsManager1.Tools["Btn_Extraction"].SharedProps.Visible = true;   // ADD 2009/01/22 機能追加：[抽出]ツールボタン

                gridHist.BeginUpdate();
                gridHist.DataSource = _dtHist.Update;
                gridHist.EndUpdate();
            }
            if (gridHist.Rows.Count > 0)
            {
                gridHist.Select();
                gridHist.Rows[0].Selected = true;

            }
        }

        /// <summary>
        /// グリッドエンターキー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == gridHist)
            {
                if (gridHist.ActiveRow != null)
                {
                    if (tabStrip.ActiveTab.Index == 1)
                    {
                        // DEL 2009/01/22 機能追加：バージョンチェック ---------->>>>>
                        #region 削除コード
                        //if (gridHist.ActiveRow.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value.Equals("●"))
                        //{
                        //    gridHist.ActiveRow.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = string.Empty;
                        //}
                        //else
                        //{
                        //    gridHist.ActiveRow.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = "●";   
                        //}
                        #endregion
                        // DEL 2009/01/22 機能追加：バージョンチェック ----------<<<<<
                        // ADD 2009/01/22 機能追加：バージョンチェック ---------->>>>>
                        string tableId = gridHist.ActiveRow.Cells[_dtHist.Update.TableIDColumn.ColumnName].Value.ToString();
                        gridHist.ActiveRow.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value = GetSelectedMark(tableId);
                        // ADD 2008/01/22 機能追加：バージョンチェック ----------<<<<<
                    }
                    gridHist.UpdateData();

                    UltraGridRow ugr = gridHist.ActiveRow.GetSibling(SiblingRow.Next);
                    if (ugr != null)
                    {
                        ugr.Activate();
                        ugr.Selected = true;
                        e.NextCtrl = gridHist;
                    }
                }
            }
        }

        #endregion  // [ その他イベント処理 ]

        #region internal[2007]

        /// <summary>
        /// 
        /// </summary>
        internal static class ColInfo
        {
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 24;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int spanX, int spanY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;
                Band.Columns[colname].RowLayoutColumnInfo.SpanX = spanX;
                Band.Columns[colname].RowLayoutColumnInfo.SpanY = spanY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 24;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
        }

        #endregion  // internal[2007]

        // ADD 2009/01/22 機能追加：更新データ区分=1 && 過去6ヶ月のものをグリッド表示 ---------->>>>>
        #region [ グリッド表示 ]

        /// <summary>
        /// デフォルト期間内か判定します。
        /// </summary>
        /// <param name="dateTime">日時</param>
        /// <returns><c>true</c> :期間内<br/><c>false</c>:期間外</returns>
        [Obsolete("DBアクセスの条件で6ヶ月間を指定しているが、一応、定義しておく")]
        private bool ContainsDefaultSpan(DateTime dateTime)
        {
            // DBアクセスの条件で6ヶ月間を指定しているが、一応、定義しておく
            return true;
        }

        /// <summary>
        /// 履歴表示のデフォルトフィルタを取得します。
        /// </summary>
        /// <returns>更新データ区分=1</returns>
        private string GetDefaultHistoryRowFilter()
        {
            StringBuilder rowFilter = new StringBuilder();
            {
                rowFilter.Append(_dtHist.Hist.UpdateDataDivColumn.ColumnName);
                rowFilter.Append(ADOUtil.EQ);
                rowFilter.Append(ADOUtil.GetString(GetUpdateDataDivName((int)PriUpdTblUpdHist.UpdateDataDivValue.Auto)));
            }
            return rowFilter.ToString();
        }

        /// <summary>
        /// グリッド表示する行か判定します。
        /// </summary>
        /// <param name="tableId">対象データID</param>
        /// <returns>
        /// <c>true</c> :表示する<br/>
        /// <c>false</c>:表示しない
        /// </returns>
        private bool IsVisibledRow(string tableId)
        {
            // DEL 2009/02/23 不具合対応[11497]↓
            // if (tableId.Equals(ProcessConfig.PRIME_SETTING_MASTER_ID))          return false;   // 優良設定マスタ
            if (tableId.Equals(ProcessConfig.PRIME_SETTING_CHANGE_MASTER_ID)) return false;   // 優良設定変更マスタ
            if (tableId.Equals(ProcessConfig.GOODS_MASTER_ID)) return false;   // 商品マスタ
            if (tableId.Equals(ProcessConfig.GOODS_PRICE_MASTER_ID)) return false;   // 価格マスタ
            return true;
        }

        // ADD 2009/01/22 機能追加：バージョンチェック ---------->>>>>
        /// <summary>
        /// 選択時の印を取得します。
        /// </summary>
        /// <param name="tableIdOnGrid">グリッドのテーブルID</param>
        /// <returns>マージ済みではないの場合、<c>SELECTED_MARK</c>を返します。</returns>
        private string GetSelectedMark(string tableIdOnGrid)
        {
            #region <Guard Phrase/>

            // 優良設定マスタは手動更新を行えない
            if (tableIdOnGrid.Equals(ProcessConfig.PRIME_SETTING_MASTER_ID))
            {
                if (this.gridHist.ActiveRow.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value.ToString().Trim() == string.Empty)
                    return string.Empty;
                else
                    return SELECTED_MARK;
            }

            #endregion  // <Guard Phrase/>

            if (!_offerMergeAcs.Checker.IsMerged())
            {
                return SELECTED_MARK;
            }
            else

            {
                 //マージ済みの場合、部位のみ
                if (tableIdOnGrid.Equals(ProcessConfig.PARTS_POS_CODE_MASTER_ID))
                {
                    string activeCellValue = this.gridHist.ActiveRow.Cells[_dtHist.Update.SelectionColumn.ColumnName].Value.ToString().Trim();
                    return string.IsNullOrEmpty(activeCellValue) ? SELECTED_MARK : string.Empty;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        // ADD 2008/01/22 機能追加：バージョンチェック ----------<<<<<

        #endregion  // [ グリッド表示 ]
        // ADD 2008/01/22 機能追加：更新データ区分=1 && 過去6ヶ月のものをグリッド表示 ----------<<<<<

        // ADD 2009/01/22 機能追加：[抽出]ツールボタン ---------->>>>>
        #region [ 処理結果をグリッドに表示 ]

        /// <summary>
        /// 対象件数を表示します。
        /// </summary>
        private void ShowTargetCount()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ProcessConfig target = _offerMergeAcs.GetTargetAndSetProcessSequence(ProcessConfigAcs.Instance.Policy);
                for (int i = 0; i < _dtHist.Update.Count; i++)
                {
                    string processId = _dtHist.Update[i].TableID;
                    if (_dtHist.Update[i].TableID.Equals(ProcessConfig.PRIME_SETTING_MASTER_ID))
                    {
                        _dtHist.Update[i].PrevUpdDate = target.LatestPreviousDateOfPrimeSetting.ToString(DATE_FORMAT);
                        _dtHist.Update[i].RowCnt = target.TotalPreviousCountOfPrimeSetting.ToString();
                        _dtHist.Update[i].TargetCnt = target.TotalPresentCountOfPrimeSetting;
                    }
                    else if (_dtHist.Update[i].TableID.Equals(ProcessConfig.PARTS_POS_CODE_MASTER_ID))
                    {
                        _dtHist.Update[i].PrevUpdDate = target[processId].PreviousDate.ToString(DATE_FORMAT);
                        _dtHist.Update[i].RowCnt = target[processId].PreviousCount.ToString();
                        _dtHist.Update[i].TargetCnt += target[processId].PresentCount;
                    }
                    else
                    {
                        _dtHist.Update[i].PrevUpdDate = target[processId].PreviousDate.ToString(DATE_FORMAT);
                        _dtHist.Update[i].RowCnt = target[processId].PreviousCount.ToString();
                        _dtHist.Update[i].TargetCnt = target[processId].PresentCount;
                    }
                }
            }
            catch(Exception ex)
            {
                DialogResult ret = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text, "提供情報取得に失敗しました。", 0, MessageBoxButtons.OKCancel);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 更新結果を表示します。
        /// </summary>
        /// <param name="status">処理結果コード</param>
        private void ShowUpdateResult(int status)
        {
            for (int i = 0; i < _dtHist.Update.Count; i++)
            {
                string strRowCnt = string.Empty;

                if (status.Equals((int)Result.Code.Normal))
                {
                    string tableId = _dtHist.Update[i].TableID;
                    strRowCnt = _offerMergeAcs.ProcessResult[tableId].ToString();
                }
                else
                {
                    strRowCnt = "エラー(" + status.ToString() + ")";
                }

                if (_dtHist.Update[i].Selection.Equals(SELECTED_MARK))
                {
                    _dtHist.Update[i].RowCnt = strRowCnt;
                }
            }
        }

        #endregion  // [ 処理結果をグリッドに表示 ]
        // ADD 2008/01/22 機能追加：[抽出]ツールボタン ----------<<<<<
    }
}
