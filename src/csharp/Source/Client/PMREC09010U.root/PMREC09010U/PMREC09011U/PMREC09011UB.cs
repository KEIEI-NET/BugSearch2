//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : リコメンド商品関連設定マスタ
// プログラム概要   : リコメンド商品関連設定マスタの保守を行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/01/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 西毅
// 作 成 日  2015/02/09  修正内容 : ①セルの結合
//                                  ②挿入、コピー、貼り付け機能の追加
//                                  ③入力保管（上のセルをコピー）機能を追加
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/02/10  修正内容 : ①BLコード入力時に商品コメント(提供)を表示
//                                  ②明細の確定判定を商品コメント列に修正
// 作 成 日  2015/02/10  修正内容 : システムテスト障害#183
//                                  ・№セルのクリックで行選択状態にする
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/02/12  修正内容 : システムテスト障害#195,196
//                                  ・新規行に基本情報の得意先表示時に問合せ元企業・拠点をセット
//                                  システムテスト障害#203
//                                  ・明細先頭行では前行の値をコピーしない
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田靖之
// 作 成 日  2015/02/16  修正内容 : システムテスト障害#217
//                                  ・得意先コードを未入力で保存するとエラーが表示される
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/03/02  修正内容 : サンプル取込時の登録済チェックに新規入力明細を含める
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/03/02  修正内容 : Redmine#217
//                                  保存チェック時に得意先未入力の場合、元企業・元拠点にゼロをセット
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/03/04  修正内容 : Redmine#318 サンプル取込時の新規入力明細との重複チェックで
//                                              入力中(未確定)の明細は対象外にする
//                                  Redmine#321 サンプル取込時の新規入力明細との重複チェックで
//                                              スペースカットしてコードの比較を行うように修正
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田靖之
// 作 成 日  2015/03/05  修正内容 : Redmine#330 挿入から入力すると保存時にエラーが表示される
// 　　　　　　　　　　　　　　　　 Redmine#332 削除モードで検索時、明細行の右クリックで「削除」以外の機能も選択できてしまう
// 　　　　　　　　　　　　　　　　 Redmine#333 右クリックの行コピーを選択したときの明細の色が行削除と同じ色でわかりずらい
// 　　　　　　　　　　　　　　　　 Redmine#335 未入力の明細を行コピーするとエラーが表示される
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/03/06  修正内容 : Redmine#338 全得意先設定内容を定数化
//                                  Redmine#341 貼り付け時にコピー元の削除区分は引き継がない
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/03/09  修正内容 : Redmine#341 推奨元BLコード以降の入力可否設定を追加
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 西 毅
// 作 成 日  2015/03/13  修正内容 : 拠点コードが0埋めされない障害の修正
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// リコメンド商品関連設定マスタ 明細コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : リコメンド商品関連設定マスタ 明細コントロールクラス</br>
    /// <br>Programmer : 宮本利明</br>
    /// <br>Date       : 2015/01/20</br>
    /// </remarks>
    public partial class PMREC09011UB : UserControl
    {
        # region Private Members
        private RecGoodsLkDataSet.RecGoodsLkDataTable _recGoodsLkDataTable;
        private RecGoodsLkStAcs _recGoodsLkStAcs = null;
        private Dictionary<Guid, RecGoodsLkSt> _prevRecGoodsLkDic = new Dictionary<Guid, RecGoodsLkSt>();

        private static readonly Color ct_DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color ct_DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));

        private const string TOOLBAR_ROWDELETEBUTTON_KEY = "ButtonTool_RowDelete";     // 行削除
        private const string TOOLBAR_ROWDELETEBUTTON_KEY1 = "ButtonTool_RowDelete1";     // 行削除
        private const string TOOLBAR_ALLDELETEBUTTON_KEY = "ButtonTool_AllRowDelete";  // 全削除
        private const string TOOLBAR_REVIVALBUTTON_KEY   = "ButtonTool_Revival";       // 復活
        // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>
        private const string TOOLBAR_ROWINSERTBUTTON_KEY =  "ButtonTool_RowInsert";  // 行挿入
        private const string TOOLBAR_ROWCUTBUTTON_KEY    =  "ButtonTool_RowCut";     // 切り取り
        private const string TOOLBAR_ROWCOPYBUTTON_KEY   =  "ButtonTool_RowCopy";    // コピー
        private const string TOOLBAR_ROWPASTEBUTTON_KEY  =  "ButtonTool_RowPaste";    // 貼り付け
        // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<


        // --- ADD 2015/02/06 T.Miyamoto サンプル取込機能追加 ------------------------------>>>>>
        private const int DELETEFLG_DEFAULT = 0;       // 通常
        private const int DELETEFLG_DELETE  = 1;       // 削除
        private const int DELETEFLG_REVIVAL = 2;       // 復活
        private const int DELETEFLG_SAMPLE  = 9;       // サンプル取込
        // --- ADD 2015/02/06 T.Miyamoto サンプル取込機能追加 ------------------------------<<<<<

        // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>
        /// <summary>行ステータス（通常行）</summary>
        public static readonly int ctROWSTATUS_NORMAL = 0;
        /// <summary>行ステータス（コピー行）</summary>
        public static readonly int ctROWSTATUS_COPY = 1;
        /// <summary>行ステータス（カット行）</summary>
        public static readonly int ctROWSTATUS_CUT = 2;

        private static readonly Color ct_ROWSTATUS_COPY_COLOR = Color.Pink;
        private static readonly Color ct_ROWSTATUS_CUT_COLOR = Color.Gray;
        // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<


        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "PMREC09010U_Construction.XML";

        /// <summary>企業コード</summary>
        private string _enterpriseCode = string.Empty;
        private string _loginSectionCode = string.Empty;

        /// <summary>得意先コード</summary>
        private string _swCustomerInfo = string.Empty;
        /// <summary>拠点コード</summary>
        private string _swSectionInfo = string.Empty;
        /// <summary>推奨元BLコード</summary>
        private int _swRecSourceBLGoodsCd = 0;
        /// <summary>推奨先BLコード</summary>
        private int _swRecDestBLGoodsCd = 0;
        // --- ADD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------>>>>>
        /// <summary>商品コメント</summary>
        private string _swGoodsComment = string.Empty;
        // --- ADD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------<<<<<

        private CustomerSearchRet _customerSearchRet = null;
        //private SectionSearchRet _customerSearchRet = null;

        /// <summary>DCKHN09092A)BLコード</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;

        private bool focusFlg = true;
        private bool leftFocusFlg = false;

        // ユーザー設定
        private RecGoodsLkUserSet _userSetting;
        private SecInfoSetAcs _secInfoSetAcs;
        private UserGuideAcs _userGuideAcs;

        private ImageList _imageList16 = null;

        // --- ADD 2015/02/06 T.Miyamoto サンプル取込機能追加 ------------------------------>>>>>
        internal event SetSampleButtonEventHandler SetSampleButton;
        internal delegate void SetSampleButtonEventHandler(Boolean enable);
        // --- ADD 2015/02/06 T.Miyamoto サンプル取込機能追加 ------------------------------<<<<<

        internal event SetGuidButtonEventHandler SetGuidButton;
        internal delegate void SetGuidButtonEventHandler(Boolean enable);

        internal event GetCustomerInfoEventHandler GetCustomerInfo;
        internal delegate void GetCustomerInfoEventHandler(out Int32 customerCode, out string customerName);

        internal event GetSectionInfoEventHandler GetSectionInfo;
        internal delegate void GetSectionInfoEventHandler(out string sectionCode, out string sectionName);


        /// <summary>フォーカスの変化</summary>
        internal event EventHandler GridKeyUpTopRow;
        #endregion

        #region プロパティ
        /// <summary>
        /// リコメンド商品関連設定マスタ アクセスクラスプロパティ
        /// </summary>
        public RecGoodsLkStAcs RecGoodsLkStAcs
        {
            get { return this._recGoodsLkStAcs; }
        }
        /// <summary>
        /// 明細部にフォーカスありプロパティ
        /// </summary>
        public Boolean FocusFlg
        {
            get { return this.focusFlg; }
        }

        /// <summary>
        /// 明細部にフォーカスありプロパティ
        /// </summary>
        public Boolean LeftFocusFlg
        {
            set { this.leftFocusFlg = value; }
        }

        /// <summary>
        /// ユーザのプロパティ
        /// </summary>
        public RecGoodsLkUserSet UserSetting
        {
            get { return this._userSetting; }
        }
        #endregion

        # region Constroctors
        /// <summary>
        /// 入力明細入力コントロールクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入力明細入力コントロールクラス デフォルトを行うコントロールクラスです。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public PMREC09011UB()
        {
            InitializeComponent();
            this._recGoodsLkStAcs = new RecGoodsLkStAcs();
            this._recGoodsLkDataTable = this._recGoodsLkStAcs.RecGoodsLkDataTable;

            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._userGuideAcs = new UserGuideAcs();

            this._userSetting = new RecGoodsLkUserSet();

            this._imageList16 = IconResourceManagement.ImageList16; // ADD 2015/03/06 T.Miyamoto Redmine#339
        }
        #endregion

        #region イベント
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note	   : フォームが読み込まれた時に発生します。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void PMREC09011UB_Load(object sender, EventArgs e)
        {
            // データソースとしてデータビューを指定
            this.uGrid_Details.DataSource = this._recGoodsLkStAcs.RecGoodsLkDataTable;

            // --- ADD 2015/03/06 T.Miyamoto Redmine#339 ------------------------------>>>>>
            // ボタン初期設定処理
            this.ButtonInitialSetting();
            // --- ADD 2015/03/06 T.Miyamoto Redmine#339 ------------------------------<<<<<

            // グリッドクリア
            this.Clear(false);
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note	   : フォームが読み込まれた時に発生します。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 行削除
                case TOOLBAR_ROWDELETEBUTTON_KEY:
                case TOOLBAR_ROWDELETEBUTTON_KEY1:
                    {
                        this.uButton_RowDelete_Click(sender, new EventArgs());
                        break;
                    }
                // 全削除
                case TOOLBAR_ALLDELETEBUTTON_KEY:
                    {
                        this.uButton_AllRowDelete_Click(sender, new EventArgs());
                        break;
                    }
                // 復活
                case TOOLBAR_REVIVALBUTTON_KEY:
                    {
                        this.uButton_Revival_Click(sender, new EventArgs());
                        break;
                    }
                // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>
                // 行挿入
                case TOOLBAR_ROWINSERTBUTTON_KEY:
                    {
                        this.uButton_RowInsert_Click(this.uButton_RowInsert, new EventArgs());
                        break;
                    }
                // 切り取り
                case TOOLBAR_ROWCUTBUTTON_KEY:
                    {
                        this.uButton_RowCut_Click(this.uButton_RowCut, new EventArgs());
                        break;
                    }
                // コピー
                case TOOLBAR_ROWCOPYBUTTON_KEY:
                    {
                        this.uButton_RowCopy_Click(this.uButton_RowCopy, new EventArgs());
                        break;
                    }
                // 貼り付け
                case TOOLBAR_ROWPASTEBUTTON_KEY:
                    {
                        this.uButton_RowPaste_Click(this.uButton_RowPaste, new EventArgs());
                        break;
                    }
                // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<

            }
        }

        // --- ADD 2015/03/06 T.Miyamoto Redmine#339 ------------------------------>>>>>
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowInsert"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWINSERT;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWDELETE;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowCopy"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWCOPY;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowPaste"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWPASTE;
        }
        // --- ADD 2015/03/06 T.Miyamoto Redmine#339 ------------------------------<<<<<

        /// <summary>
        /// 明細初期化イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note	   : 明細初期化イベントします。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.uGrid_Details.BeginUpdate();

            // グリッド列初期設定処理
            this.InitialSettingGridCol();

            this.uGrid_Details.EndUpdate();
        }

        /// <summary>
        /// 行削除処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 行削除処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uButton_RowDelete_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            try
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                this.Cursor = Cursors.WaitCursor;

                this.uGrid_Details.BeginUpdate();

                foreach (UltraGridRow row in this.uGrid_Details.Rows)
                {
                    if (row.Selected || row.IsActiveRow)
                    {
                        if ((int)row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                        {
                            //削除指定区分:0
                            if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                            {
                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                                    this.SetGuidButton(false);
                                }

                                // 行削除時BackColorの設定(ピンク色)、入力許可設定
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName) // ADD 2015/02/10 行色 T.Miyamoto
                                    {
                                        cell.Appearance.BackColor = Color.Pink;
                                        cell.Appearance.BackColor2 = Color.Pink;
                                        cell.Appearance.BackColorDisabled = Color.Pink;
                                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                    }
                                    cell.Activation = Activation.NoEdit;
                                }
                                row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                            }
                            //削除指定区分:1
                            else
                            {
                                // 行削除時BackColorの設定(ピンク色)、入力許可設定
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName) // ADD 2015/02/10 行色 T.Miyamoto
                                    {
                                        cell.Appearance.BackColor = Color.Pink;
                                        cell.Appearance.BackColor2 = Color.Pink;
                                        cell.Appearance.BackColorDisabled = Color.Pink;
                                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                        // --- ADD 2015/02/10 行色 T.Miyamoto ------------------------------>>>>>
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                        // --- ADD 2015/02/10 行色 T.Miyamoto ------------------------------<<<<<
                                    }
                                }
                                row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                            }
                        }
                        else
                        {
                            //削除指定区分:0
                            if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                            {
                                #region 行削除解除
                                // 新規行の判断
                                bool isNewRow = false;
                                if ((Guid)row.Cells[this._recGoodsLkDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                                {
                                    isNewRow = true;
                                }

                                #region 入力許可設定
                                row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activation = Activation.AllowEdit;
                                row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Activation = Activation.AllowEdit;
                                row.Cells[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Activation = Activation.AllowEdit; // ADD 2015/02/06 T.Miyamoto コメント項目追加
                                if (isNewRow == true)
                                {
                                    row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                    row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.AllowEdit;
                                }
                                #endregion

                                // 行削除解除時BackColorの設定(通常色)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Activation == Activation.NoEdit
                                     && cell.Column.Key != this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                    }
                                    else
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }

                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    this.uGrid_Details.ActiveCell.Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    if (this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName
                                     || this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName
                                     || this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName
                                     || this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName
                                     || this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName) // ADD 2015/02/06 T.Miyamoto コメント項目追加
                                    {
                                        if (this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                                        {
                                            this.SetGuidButton(true);
                                        }
                                        else
                                        {
                                            this.SetGuidButton(false);
                                        }
                                    }
                                    else
                                    {
                                        this.SetGuidButton(false);
                                    }
                                }
                                row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                                #endregion
                            }
                            //削除指定区分:1
                            else
                            {
                                #region 行削除解除
                                // 行削除解除時BackColorの設定(DiabledColor)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    cell.Appearance.BackColor = Color.Gainsboro;
                                    cell.Appearance.BackColor2 = Color.Gainsboro;
                                    cell.Appearance.BackColorDisabled = Color.Gainsboro;
                                    cell.Appearance.BackColorDisabled2 = Color.Gainsboro;
                                    if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                                row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                                #endregion
                            }
                        }
                    }
                }

                this.uGrid_Details.EndUpdate();
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 全削除処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 全削除処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uButton_AllRowDelete_Click(object sender, EventArgs e)
        {
            bool isAllDelete = true;
            try
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                this.Cursor = Cursors.WaitCursor;

                this.uGrid_Details.BeginUpdate();

                //削除指定区分:0
                if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                {
                    for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                    {
                        if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value == 0)
                        {
                            isAllDelete = false;
                            break;
                        }
                    }

                    if (isAllDelete == true)
                    {
                        #region 入力許可設定
                        bool isNewRow = false;
                        foreach (UltraGridRow row in this.uGrid_Details.Rows)
                        {
                            if ((Guid)row.Cells[this._recGoodsLkDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                            {
                                isNewRow = true;
                            }
                            row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activation = Activation.AllowEdit;
                            row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Activation = Activation.AllowEdit;
                            row.Cells[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Activation = Activation.AllowEdit; // ADD 2015/02/06 T.Miyamoto コメント項目追加
                            if (isNewRow == true)
                            {
                                row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.AllowEdit;
                            }
                        }
                        #endregion

                        // 行削除解除時BackColorの設定(通常色)
                        foreach (UltraGridRow row in this.uGrid_Details.Rows)
                        {
                            if ((int)row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value == 1)
                            {
                                // 行削除解除時BackColorの設定(通常色)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Activation != Activation.NoEdit
                                        || cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    }
                                    else
                                    {
                                        cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                        cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                            }

                            row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                        }
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        if (this.uGrid_Details.ActiveCell != null)
                        {
                            if (this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName
                             || this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName
                             || this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName
                             || this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName
                             || this.uGrid_Details.ActiveCell.Column.Key == this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName) // ADD 2015/02/06 T.Miyamoto コメント項目追加
                            {
                                if (this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                                {
                                    this.SetGuidButton(true);
                                }
                                else
                                {
                                    this.SetGuidButton(false);
                                }
                            }
                            else
                            {
                                this.SetGuidButton(false);
                            }
                        }
                    }
                    else
                    {
                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                        this.SetGuidButton(false);

                        for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                        {
                            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                            {
                                // 行削除時BackColorの設定(ピンク色)、入力許可設定
                                foreach (UltraGridCell cell in this.uGrid_Details.Rows[rowIndex].Cells)
                                {
                                    if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName) // ADD 2015/02/10 行色 T.Miyamoto
                                    {
                                        cell.Appearance.BackColor = Color.Pink;
                                        cell.Appearance.BackColor2 = Color.Pink;
                                        cell.Appearance.BackColorDisabled = Color.Pink;
                                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                    }
                                    cell.Activation = Activation.NoEdit;
                                }
                            }

                            this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                        }
                    }

                }
                //削除指定区分:1
                else
                {
                    for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                    {
                        if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                        {
                            isAllDelete = false;
                            break;
                        }
                    }

                    if (isAllDelete == true)
                    {
                        // 行削除解除時BackColorの設定(通常色)
                        foreach (UltraGridRow row in this.uGrid_Details.Rows)
                        {
                            if ((int)row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value == 1)
                            {
                                // 行削除解除時BackColorの設定(通常色)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                        // --- ADD 2015/02/10 行色 T.Miyamoto ------------------------------>>>>>
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                        // --- ADD 2015/02/10 行色 T.Miyamoto ------------------------------<<<<<
                                    }
                                    else
                                    {
                                        cell.Appearance.BackColor = ct_DISABLE_COLOR;
                                        cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                                        cell.Appearance.BackColorDisabled = ct_DISABLE_COLOR;
                                        cell.Appearance.BackColorDisabled2 = ct_DISABLE_COLOR;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;

                                    cell.Activation = Activation.NoEdit;
                                }
                            }

                            row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                        }
                    }
                    else
                    {
                        for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                        {
                            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                            {
                                // 行削除時BackColorの設定(ピンク色)、入力許可設定
                                foreach (UltraGridCell cell in this.uGrid_Details.Rows[rowIndex].Cells)
                                {
                                    if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName) // ADD 2015/02/10 行色 T.Miyamoto
                                    {
                                        cell.Appearance.BackColor = Color.Pink;
                                        cell.Appearance.BackColor2 = Color.Pink;
                                        cell.Appearance.BackColorDisabled = Color.Pink;
                                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                        // --- ADD 2015/02/10 行色 T.Miyamoto ------------------------------>>>>>
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                        // --- ADD 2015/02/10 行色 T.Miyamoto ------------------------------<<<<<
                                    }
                                    cell.Activation = Activation.NoEdit;
                                }
                            }

                            this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                        }
                    }
                }

                this.uGrid_Details.EndUpdate();
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 復活処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uButton_Revival_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            try
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                this.uGrid_Details.BeginUpdate();

                foreach (UltraGridRow row in this.uGrid_Details.Rows)
                {
                    if (row.Selected || row.IsActiveRow)
                    {
                        if ((int)this.uGrid_Details.Rows[row.Index].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value != 2)
                        {
                            //復活処理
                            foreach (UltraGridCell cell in this.uGrid_Details.Rows[row.Index].Cells)
                            {
                                // --- UPD 2015/02/10 行色 T.Miyamoto ------------------------------>>>>>
                                //if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                                //{
                                //    cell.Appearance.BackColor = Color.Empty;
                                //    cell.Appearance.BackColor2 = Color.Empty;
                                //    cell.Appearance.BackColorDisabled = Color.Empty;
                                //    cell.Appearance.BackColorDisabled2 = Color.Empty;
                                //    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                //}
                                //else
                                //{
                                //    cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                //    cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                //    cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                //    cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                //    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                //}
                                if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                                {
                                    cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                    cell.Appearance.ForeColor = ct_DISABLE_FONT_COLOR;
                                    cell.Appearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;
                                }
                                // --- UPD 2015/02/10 行色 T.Miyamoto ------------------------------<<<<<
                            }

                            this.uGrid_Details.Rows[row.Index].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 2;
                        }
                        else
                        {
                            //復活解除処理
                            foreach (UltraGridCell cell in this.uGrid_Details.Rows[row.Index].Cells)
                            {
                                // --- UPD 2015/02/10 行色 T.Miyamoto ------------------------------>>>>>
                                //if (cell.Column.Key != this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                                //{
                                //    cell.Appearance.BackColor = ct_DISABLE_COLOR;
                                //    cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                                //    cell.Appearance.BackColorDisabled = ct_DISABLE_COLOR;
                                //    cell.Appearance.BackColorDisabled2 = ct_DISABLE_COLOR;
                                //    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                //}
                                if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                                {
                                    cell.Appearance.BackColor = Color.Empty;
                                    cell.Appearance.BackColor2 = Color.Empty;
                                    cell.Appearance.BackColorDisabled = Color.Empty;
                                    cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                    cell.Appearance.ForeColor = Color.Empty;
                                    cell.Appearance.ForeColorDisabled = Color.Empty;
                                }
                                // --- UPD 2015/02/10 行色 T.Miyamoto ------------------------------<<<<<
                            }

                            this.uGrid_Details.Rows[row.Index].Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                        }
                    }
                }

                this.uGrid_Details.EndUpdate();
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// セルのデータチェック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : セルのデータチェック処理。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // 数値項目の場合
                if ((this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // 未入力は0にする				
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // 数値項目に「-」or「.」だけしか入ってなかったら駄目です				
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // 通常入力				
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Details.ActiveCell.Column.DataType);
                            this.uGrid_Details.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;				// 0をセット
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない	
                    e.StayInEditMode = false;			// 編集モードは抜ける
                }
            }
        }

        /// <summary>
        /// グリッドセルアクティブ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアクティブ後発生イベント</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            this.SetGridGuid();
            this.SetSampleButton(true);
        }

        /// <summary>
        /// グリッドセル編集モードに入った後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドセル編集モードに入った後発生イベント</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
            }
        }

        /// <summary>
        /// グリッドセル出る後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドセル出る後発生イベント</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>
                UltraGridCell cell = this.uGrid_Details.ActiveCell;
                UltraGridRow row = this.uGrid_Details.ActiveCell.Row;
                if (cell.Value == null)
                {
                    return;
                }


                // 得意先コード
                if (cell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName)
                {
                    // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>
                    //int inputValue = 0;
                    //// 入力値を取得
                    //Int32.TryParse(cell.Value.ToString(), out inputValue);
                    string inputValue = string.Empty;
                    // 入力値を取得
                    inputValue = cell.Value.ToString().Trim();
                    // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<
                    // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>
                    //// --- UPD 2015/02/12 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#203 ------------------------------>>>>>
                    ////if (inputValue == 0 && row.Index != -1)
                    if (inputValue == string.Empty && row.Index > 0)
                    // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<
                    // --- UPD 2015/02/12 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#203 ------------------------------<<<<<
                    {
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = this.uGrid_Details.Rows[cell.Row.Index - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value;
                    }
                }


                // 拠点コード
                else if (cell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName)
                {
                    string inputValue = "";
                    // 入力値を取得
                    inputValue = cell.Value.ToString().Trim();
                    // --- UPD 2015/02/12 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#203 ------------------------------>>>>>
                    //if (inputValue == "" && row.Index != -1)
                    if (inputValue == "" && row.Index > 0)
                    // --- UPD 2015/02/12 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#203 ------------------------------<<<<<
                    {
                        // --- UPD 2015/03/13 T.Nishi ------------------------------>>>>>
                        //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this.uGrid_Details.Rows[cell.Row.Index - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this.uGrid_Details.Rows[cell.Row.Index - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value.ToString().Trim().PadLeft(2, '0');
                        // --- UPD 2015/03/13 T.Nishi ------------------------------<<<<<
                    }
                }


                // 推奨元BLｺｰﾄﾞ/推奨先BLｺｰﾄﾞ
                else if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                {
                    int inputValue = 0;
                    // 入力値を取得
                    Int32.TryParse(cell.Value.ToString(), out inputValue);
                    // --- UPD 2015/02/12 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#203 ------------------------------>>>>>
                    //if (inputValue == 0 && row.Index != -1)
                    if (inputValue == 0 && row.Index > 0)
                    // --- UPD 2015/02/12 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#203 ------------------------------<<<<<
                    {
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value = this.uGrid_Details.Rows[cell.Row.Index - 1].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value;
                    }
                }


                // 得意先コード
                if (cell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName)
                {
                    int inputValue = 0;
                    // 入力値を取得
                    Int32.TryParse(cell.Value.ToString(), out inputValue);

                    if (!this.CustomerCheck_Detail(inputValue, cell.Row.Index))
                    {
                        this.focusFlg = false;
                    }
                }

                // 拠点コード
                else if (cell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName)
                {
                    string inputValue = "";
                    // 入力値を取得
                    inputValue = cell.Value.ToString().Trim();
                    if (!this.SectionCheck_Detail(inputValue, cell.Row.Index))
                    {
                        this.focusFlg = false;
                    }
                }


                // 推奨元BLｺｰﾄﾞ/推奨先BLｺｰﾄﾞ
                else if ((cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                      || (cell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName))
                {
                    int inputValue = 0;
                    // 入力値を取得
                    Int32.TryParse(cell.Value.ToString(), out inputValue);
                    if (inputValue != 0)
                    {
                        BLGoodsCdUMnt blGoodsCdUMnt = null;
                        if (this._recGoodsLkStAcs.BLGoodsCdDic.ContainsKey(inputValue))
                        {
                            blGoodsCdUMnt = this._recGoodsLkStAcs.BLGoodsCdDic[inputValue];
                        }

                        if (blGoodsCdUMnt != null)
                        {
                            if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                            {
                                this._swRecSourceBLGoodsCd = blGoodsCdUMnt.BLGoodsCode;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsCode;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsHalfName;
                            }
                            else
                            {
                                this._swRecDestBLGoodsCd = blGoodsCdUMnt.BLGoodsCode;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsCode;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsHalfName;
                            }
                            // --- ADD 2015/02/10① T.Miyamoto ------------------------------>>>>>
                            // BLコードから商品コメント(提供)を取得
                            this.GoodsCommentDsp(cell.Row.Index);
                            // --- ADD 2015/02/10① T.Miyamoto ------------------------------<<<<<
                        }
                        else
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "ＢＬコードが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                            if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                            {
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value = this._swRecSourceBLGoodsCd;
                            }
                            else
                            {
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value = this._swRecDestBLGoodsCd;
                            }
                            this.focusFlg = false;
                        }
                    }
                    else
                    {
                        if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                        {
                            this._swRecSourceBLGoodsCd = 0;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value = 0;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Value = string.Empty;
                        }
                        else
                        {
                            this._swRecDestBLGoodsCd = 0;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value = 0;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Value = string.Empty;
                        }
                    }
                }
                // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<
            }
        }

        /// <summary>
        /// グリッドセルアクティブ前発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアクティブ前発生イベント</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;

            this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Off; // ADD 2015/02/06 T.Miyamoto コメント項目追加

            if (cell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName)
            {
                this._swCustomerInfo = e.Cell.Value.ToString().Trim();
            }
            else if (cell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName)
            {
                this._swSectionInfo = e.Cell.Value.ToString().Trim();
            }
            else if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
            {
                this._swRecSourceBLGoodsCd = (Int32)e.Cell.Value;
            }
            else if (cell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName)
            {
                this._swRecDestBLGoodsCd = (Int32)e.Cell.Value;
            }
            // --- ADD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------>>>>>
            else if (cell.Column.Key == this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName)
            {
                this._swGoodsComment = e.Cell.Value.ToString().Trim();
                this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            }
            // --- ADD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------<<<<<
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected && this.uGrid_Details.ActiveRow.Index == 0)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        if (this.GridKeyUpTopRow != null)
                        {
                            this.GridKeyUpTopRow(this, new EventArgs());
                            this.uGrid_Details.ActiveRow.Selected = false;
                            this.uGrid_Details.ActiveRow = null;
                            e.Handled = true;
                        }
                    }
                }
            }
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            string columnKey = this.uGrid_Details.ActiveCell.Column.Key;

            if (this.uGrid_Details.ActiveCell.IsInEditMode)
            {
                if (e.KeyCode == Keys.Left && this.uGrid_Details.ActiveCell.SelStart != 0)
                {
                    return;
                }
                if (e.KeyCode == Keys.Right && this.uGrid_Details.ActiveCell.SelStart < this.uGrid_Details.ActiveCell.Text.Length)
                {
                    return;
                }
                if (e.KeyCode == Keys.Escape)
                {
                    return;
                }
            }

            switch (e.KeyCode)
            {
				case Keys.Escape:
    				{
					    // 明細データテーブルRowStatus列初期化処理
					    this.InitializeRecGoodsLkRowStatusColumn();

					    // 明細グリッドセル設定処理
					    this.SettingGrid();
                        break;
    				}
                case Keys.Up:
                    {
                        this.focusFlg = true;
                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                        if (rowIndex == 0)
                        {
                            if (focusFlg)
                            {
                                if (this.GridKeyUpTopRow != null)
                                {
                                    this.GridKeyUpTopRow(this, new EventArgs());
                                    this.uGrid_Details.ActiveCell.Selected = false;
                                    this.uGrid_Details.ActiveCell = null;
                                    e.Handled = true;
                                }
                            }
                            else
                            {
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            e.Handled = true;
                            if (focusFlg)
                            {
                                this.uGrid_Details.Rows[rowIndex - 1].Cells[columnKey].Activate();
                            }
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        this.focusFlg = true;
                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                        if (rowIndex == this.uGrid_Details.Rows.Count - 1)
                        {
                            e.Handled = true;
                            if (focusFlg)
                            {
                                if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                                {
                                    if (CheckDateForDown())
                                    {
                                        #region 最終行の場合、新規行を追加する --DEL
                                        // --- UPD 2015/02/06 T.Miyamoto ------------------------------>>>>>
                                        //RecGoodsLkDataSet.RecGoodsLkRow newRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
                                        //newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
                                        //newRow.FilterGuid = Guid.Empty;
                                        //newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                                        //newRow.InqOtherEpCd = this._enterpriseCode;
                                        ////newRow.InqOtherSecCd = this._loginSectionCode;

                                        //this._recGoodsLkDataTable.AddRecGoodsLkRow(newRow);

                                        //this.DetailGridInitSetting();
                                        //#endregion

                                        ////得意先情報の初期値セット
                                        //Int32 customerCode = 0;
                                        //string customerName = string.Empty;
                                        //this.GetCustomerInfo(out customerCode, out customerName);
                                        //if (customerCode != 0)
                                        //{
                                        //    this.uGrid_Details.Rows[rowIndex + 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = customerCode;
                                        //    this.uGrid_Details.Rows[rowIndex + 1].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = customerName;
                                        //}

                                        ////拠点情報の初期値セット
                                        //string sectionCode = string.Empty;
                                        //string sectionName = string.Empty;
                                        //this.GetSectionInfo(out sectionCode, out sectionName);
                                        //if (sectionCode != string.Empty)
                                        //{
                                        //    this.uGrid_Details.Rows[rowIndex + 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode;
                                        //    this.uGrid_Details.Rows[rowIndex + 1].Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = sectionName;
                                        //}

                                        ////初期フォーカス位置セット
                                        //if (customerCode != 0 || sectionCode != string.Empty)
                                        //{
                                        //    if (sectionCode == string.Empty)
                                        //    {
                                        //        this.uGrid_Details.Rows[rowIndex + 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                        //    }
                                        //    else if (customerCode == 0)
                                        //    {
                                        //        this.uGrid_Details.Rows[rowIndex + 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                                        //    }
                                        //    else
                                        //    {
                                        //        this.uGrid_Details.Rows[rowIndex + 1].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    //両方とも空白の場合は拠点コードにフォーカスセット
                                        //    this.uGrid_Details.Rows[rowIndex + 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                        //}
                                        #endregion 
                                        this.NewRowAdd(rowIndex + 1);
                                        // --- UPD 2015/02/06 T.Miyamoto ------------------------------<<<<<

                                        RecGoodsLkSt recGoodsLkSt = null;
                                        this._recGoodsLkStAcs.CopyToRecGoodsLkFromDetailRow((RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkDataTable.Rows[this._recGoodsLkDataTable.Count - 1], ref recGoodsLkSt);
                                        this._recGoodsLkStAcs.NewRecGoodsLkObj = recGoodsLkSt.Clone();
                                    }
                                }
                            }
                        }
                        else
                        {
                            e.Handled = true;
                            if (focusFlg)
                            {
                                this.uGrid_Details.Rows[rowIndex + 1].Cells[columnKey].Activate();
                            }
                        }
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                case Keys.Left:
                    {
                        this.focusFlg = true;
                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                        if (columnKey == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName
                         || columnKey == this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName)
                        {
                            // 左端から次行左端に移動させない
                            if (this.uGrid_Details.ActiveCell.Column.Header.VisiblePosition == 1)
                            {
                                e.Handled = true;
                            }
                            else
                            {
                                if (!this.leftFocusFlg)
                                {
                                    e.Handled = true;
                                }
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                break;
                            }
                        }
                        else
                        {
                            // 次セル取得
                            string columnName = columnKey;
                            // 次セル取得
                            int targetColumnIndex = GetNextColumnIndexByTab(1, rowIndex, columnName);

                            if (targetColumnIndex != -1)
                            {
                                if (focusFlg)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[targetColumnIndex].Activate();
                                }
                            }
                            else
                            {
                                if (focusFlg)
                                {
                                    // 改行
                                    // --- UPD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------>>>>>
                                    //columnName = this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName;
                                    columnName = this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName;
                                    // --- UPD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------<<<<<
                                    this.uGrid_Details.Rows[rowIndex - 1].Cells[columnName].Activate();
                                }
                            }
                        }

                        e.Handled = true;
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                case Keys.Right:
                    {
                        this.focusFlg = true;

                        if (columnKey == this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName)
                        {
                            // なし。
                        }
                        // --- UPD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------>>>>>
                        //else if (columnKey == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName)
                        else if (columnKey == this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName)
                        // --- UPD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------<<<<<
                        {
                            // 右端のVisiblePositionを取得
                            int lastPosition = this.GetGridLastPosition(this.uGrid_Details);

                            // 右端から次行左端に移動させない
                            if (this.uGrid_Details.ActiveCell.Column.Header.VisiblePosition == lastPosition)
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                            // 次セル取得
                            string columnName = columnKey;
                            // 次セル取得
                            int targetColumnIndex = GetNextColumnIndexByTab(0, rowIndex, columnName);

                            if (targetColumnIndex != -1)
                            {
                                if (focusFlg)
                                {
                                    this.uGrid_Details.Rows[rowIndex].Cells[targetColumnIndex].Activate();
                                }
                            }
                            else
                            {
                                if (focusFlg)
                                {
                                    if (rowIndex < this.uGrid_Details.Rows.Count - 1)
                                    {
                                        // 改行
                                        columnName = this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName;
                                        this.uGrid_Details.Rows[rowIndex + 1].Cells[columnName].Activate();
                                    }
                                    else
                                    {
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                }
                            }

                            e.Handled = true;
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
            }
            this.focusFlg = true;
        }

        /// <summary>
        /// グリッド内の最後のVisiblePosition取得
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private int GetGridLastPosition(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            if (grid.ActiveRow == null) return 0;

            int colCount = 0;
            for (int index = 0; index < grid.ActiveRow.Cells.Count; index++)
            {
                if (grid.ActiveRow.Cells[index].Column.Hidden == false)
                {
                    if (colCount < grid.ActiveRow.Cells[index].Column.Header.VisiblePosition)
                    {
                        colCount = grid.ActiveRow.Cells[index].Column.Header.VisiblePosition;
                    }
                }
            }
            return colCount;
        }

        /// <summary>
        /// グリッド内の最前のVisiblePosition取得
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private int GetGridFirstPosition(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            if (grid.ActiveRow == null) return 0;

            int colCount = 7;
            for (int index = 0; index < grid.ActiveRow.Cells.Count; index++)
            {
                if (grid.ActiveRow.Cells[index].Column.Hidden == false)
                {
                    if (colCount > grid.ActiveRow.Cells[index].Column.Header.VisiblePosition)
                    {
                        colCount = grid.ActiveRow.Cells[index].Column.Header.VisiblePosition;
                    }
                }
            }
            return colCount;
        }

        /// <summary>
        /// グリッドセルアプデト後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアプデト後発生イベント</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            // --- DEL 2015/02/09 T.Nishi ------------------------------>>>>>
            /*
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;
            UltraGridRow row = e.Cell.Row;

            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
            // 得意先コード
            if (cell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName)
            {
                int inputValue = 0;
                // 入力値を取得
                Int32.TryParse(cell.Value.ToString(), out inputValue);
                if (!this.CustomerCheck_Detail(inputValue, cell.Row.Index))
                {
                    this.focusFlg = false;
                }
            }

            // 拠点コード
            else if (cell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName)
            {
                string inputValue = "";
                // 入力値を取得
                inputValue = cell.Value.ToString().Trim();
                if (!this.SectionCheck_Detail(inputValue.PadLeft(2, '0'), cell.Row.Index))
                {
                    this.focusFlg = false;
                }
            }


            // 推奨元BLｺｰﾄﾞ/推奨先BLｺｰﾄﾞ
            else if ((cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                  || (cell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName))
            {
                int inputValue = 0;
                // 入力値を取得
                Int32.TryParse(cell.Value.ToString(), out inputValue);
                if (inputValue != 0)
                {
                    BLGoodsCdUMnt blGoodsCdUMnt = null;
                    if (this._recGoodsLkStAcs.BLGoodsCdDic.ContainsKey(inputValue))
                    {
                        blGoodsCdUMnt = this._recGoodsLkStAcs.BLGoodsCdDic[inputValue];
                    }

                    if (blGoodsCdUMnt != null)
                    {
                        if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                        {
                            this._swRecSourceBLGoodsCd = blGoodsCdUMnt.BLGoodsCode;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsCode;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsHalfName;
                        }
                        else
                        {
                            this._swRecDestBLGoodsCd = blGoodsCdUMnt.BLGoodsCode;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsCode;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Value = blGoodsCdUMnt.BLGoodsHalfName;
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "ＢＬコードが存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                        if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                        {
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value = this._swRecSourceBLGoodsCd;
                        }
                        else
                        {
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value = this._swRecDestBLGoodsCd;
                        }
                        this.focusFlg = false;
                    }
                }
                else
                {
                    if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                    {
                        this._swRecSourceBLGoodsCd = 0;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value = 0;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Value = string.Empty;
                    }
                    else
                    {
                        this._swRecDestBLGoodsCd = 0;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value = 0;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Value = string.Empty;
                    }
                }
            }
            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
            */ 
            // --- DEL 2015/02/09 T.Nishi ------------------------------<<<<<
        }

        // --- ADD 2015/02/10① T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// 商品コメント表示
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note       : 指定行のBLコード入力時に商品コメント(提供)を取得して表示する</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/02/10</br>
        /// </remarks>
        private void GoodsCommentDsp(int rowIndex)
        {
            int recSourceBLGoodsCd = 0;
            Int32.TryParse(this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value.ToString().Trim(), out recSourceBLGoodsCd);
            int recDestBLGoodsCd = 0;
            Int32.TryParse(this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value.ToString().Trim(), out recDestBLGoodsCd);

            if (recSourceBLGoodsCd != 0
             && recDestBLGoodsCd != 0
             && (this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Value.ToString().Trim() == string.Empty))
            {
                // BLコードから商品コメント(提供)を取得
                this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Value = this._recGoodsLkStAcs.SampleRead(recSourceBLGoodsCd, recDestBLGoodsCd);
            }
        }
        // --- ADD 2015/02/10① T.Miyamoto ------------------------------<<<<<

        /// <summary>
        /// グリッドセルKeyPress発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドセルKeyPress発生イベント</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (!cell.IsInEditMode) return;

            //----------------------------------------------
            // ActiveCellが得意先コードの場合
            //----------------------------------------------
            if (cell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCellが拠点コードの場合
            //----------------------------------------------
            else if (cell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCellが推奨元BLｺｰﾄﾞ、推奨先BLｺｰﾄﾞの場合
            //----------------------------------------------
            else if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName
                  || cell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(5, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 明細部初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 明細部初期化処理します。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;
                col.Header.Fixed = false;

                // 「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = ct_DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;
                }
            }

            #region ●表示幅設定
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Width = 40;            // №
            editBand.Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].Width = 80;       // 削除日
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Width = 60;     // 拠点コード
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Width = 180;     // 拠点略称
            editBand.Columns[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Width = 80;     // 得意先コード
            editBand.Columns[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Width = 180;     // 得意先略称
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Width = 70; // 推奨元BLコード
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Width = 220; // 推奨元BLコード名
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Width = 70;   // 推奨先BLコード
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Width = 240;   // 推奨先BLコード名
            editBand.Columns[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Width = 400;   // 商品コメント
            #endregion

            #region ●固定列設定
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Header.Fixed = true;                                     // №
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None; // №
            // 行番号列クリック時は行Active
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellClickAction = CellClickAction.RowSelect; // ADD 2015/02/10 ｼｽﾃﾑﾃｽﾄ障害#183 T.Miyamoto
            #endregion

            #region ●CellAppearance設定
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;           // №
            editBand.Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;       // 削除日
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;    // 拠点コード
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;      // 拠点略称
            editBand.Columns[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;    // 得意先コード
            editBand.Columns[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;      // 得意先略称
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; // 推奨元BLコード
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;  // 推奨元BLコード名
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;   // 推奨先BLコード
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;    // 推奨先BLコード名
            editBand.Columns[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;    // 商品コメント

            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            #endregion

            #region ●入力許可設定
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;            // №
            editBand.Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;         // 削除日
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;    // 拠点コード
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;        // 拠点略称
            editBand.Columns[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;    // 得意先コード
            editBand.Columns[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;        // 得意先略称
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 推奨元BLコード
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;    // 推奨元BLコード名
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;   // 推奨先BLコード
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;      // 推奨先BLコード名
            editBand.Columns[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;    // 商品コメント

            #endregion

            #region ●Style設定
            editBand.Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // 削除日
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // 拠点コード
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;     // 拠点略称
            editBand.Columns[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // 得意先コード
            editBand.Columns[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;     // 得意先略称
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit; // 推奨元BLコード
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit; // 推奨元BLコード名
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;   // 推奨先BLコード
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;   // 推奨先BLコード名
            editBand.Columns[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;   // 商品コメント
            #endregion

            #region ●フォーマット設定
            
            string decimalFormat = "#,##0.00;-#,##0.00;''";
            string codeFormat1 = "#000000;-#0000000;''";
            string codeFormat2 = "#00;-#00;''";
            string codeFormat3 = "#0000;-#0000;''";
            string codeFormat4 = "#00000;-#00000;''";
            string codeFormat5 = "#00000000;-#00000000;''";
            editBand.Columns[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Format = codeFormat5;    // 得意先コード
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Format = codeFormat2;    // 拠点コード
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Format = codeFormat4; // 推奨元BLコード
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Format = codeFormat4;   // 推奨先BLコード
            
            #endregion

            #region ●MaxLength設定
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].MaxLength = 2;    // 拠点コード
            editBand.Columns[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].MaxLength = 8;    // 得意先コード
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].MaxLength = 5; // 推奨元BLコード
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].MaxLength = 5;   // 推奨先BLコード
            editBand.Columns[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].MaxLength = 200;   // 商品コメント
            #endregion

            #region ●グリッド列表示非表示設定処理
            editBand.Columns[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Hidden = false;           // №
            editBand.Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].Hidden = true;       // 削除日
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Hidden = false;    // 拠点コード
            editBand.Columns[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Hidden = false;     // 拠点略称
            editBand.Columns[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Hidden = false;    // 得意先コード
            editBand.Columns[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Hidden = false;     // 得意先略称
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Hidden = false; // 推奨元BLコード
            editBand.Columns[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Hidden = false; // 推奨元BLコード名
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Hidden = false;   // 推奨先BLコード
            editBand.Columns[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Hidden = false;   // 推奨先BLコード名
            editBand.Columns[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Hidden = false;   // 商品コメント
            #endregion
            // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>
            # region [セル結合設定]
            try
            {
                this.uGrid_Details.BeginUpdate();
                ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

                List<string> colNameList = new List<string>(new string[] 
                                            { 
                                                this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName,
                                                this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName,
                                                this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName,
                                                this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName,
                                                this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName,
                                                this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName,
                                                this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName,
                                                this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName,
                                                this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName
                                            });
                Infragistics.Win.Appearance margedCellAppearance = new Infragistics.Win.Appearance();

                for (int index = 0; index < colNameList.Count; index++)
                {
                    string colName = colNameList[index];

                    // CellAppearanceを強制的に統一する（行№は除く）
                    if (!columns[colName].Key.Trim().Equals(this._recGoodsLkDataTable.RowNoColumn.ColumnName.Trim()))
                    {
                        columns[colName].MergedCellAppearance = margedCellAppearance;
                        columns[colName].CellAppearance.TextVAlign = VAlign.Top;
                    }
                    // セル結合設定
                    columns[colName].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
                    columns[colName].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
                    columns[colName].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
                }

                // セル結合設定詳細（親列を判定に含める）
                // 拠点
                columns[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName);

                // 拠点
                columns[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName);

                // 得意先：拠点、得意先が同一のセルを結合
                columns[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName);

                // 得意先：拠点、得意先が同一のセルを結合
                columns[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName);

                // 推奨元BLｺｰﾄﾞ：拠点、得意先、推奨元BLｺｰﾄﾞが同一のセルを結合
                columns[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName);

                // 推奨元BLｺｰﾄﾞ：拠点、得意先、推奨元BLｺｰﾄﾞが同一のセルを結合
                columns[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName);

                // 推奨元BLｺｰﾄﾞ：拠点、得意先、推奨元BLｺｰﾄﾞが同一のセルを結合
                columns[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName);

                // 推奨元BLｺｰﾄﾞ：拠点、得意先、推奨元BLｺｰﾄﾞが同一のセルを結合
                columns[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName,
                                                    this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName);
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
            }
            # endregion
            // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<
        }
        // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>
        # region [グリッドセル結合判定クラス]
        /// <summary>
        /// グリッドセル結合判定クラス(カスタマイズ)
        /// </summary>
        public class CustomMergedCellEvaluator : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
        {
            /// <summary>結合条件セルリスト</summary>
            private List<string> _joinColList;
            /// <summary>
            /// 結合条件セルリスト
            /// </summary>
            public List<string> JoinColList
            {
                get { return _joinColList; }
                set { _joinColList = value; }
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public CustomMergedCellEvaluator()
            {
                _joinColList = new List<string>();
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public CustomMergedCellEvaluator(params string[] joinCols)
            {
                _joinColList = new List<string>(joinCols);
            }

            /// <summary>
            /// セル結合判定処理
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="column"></param>
            /// <returns></returns>
            public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
            {
                foreach (string joinColName in JoinColList)
                {
                    if (!EqualCellValue(row1, row2, joinColName)) return false;
                }
                return true;
            }
            /// <summary>
            /// セルValue比較処理
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="columnName"></param>
            /// <returns></returns>
            private bool EqualCellValue(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, string columnName)
            {
                return ((row1.Cells[columnName].Value.ToString().Trim() == row2.Cells[columnName].Value.ToString().Trim()));
            }
        }
        // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<
        # endregion

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面初期化処理します。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        internal void Clear(bool settingGrid)
        {
            this._recGoodsLkStAcs.PrevRecGoodsLkDic.Clear();

            this.SetButtonEnabled(1);
            // 明細DataTable行クリア処理
            this._recGoodsLkStAcs.RecGoodsLkDataTable.Rows.Clear();

            // ソート設定の解除
            this.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();

            // グリッド行初期設定処理
            this._recGoodsLkStAcs.DetailRowInitialSetting(1);
            this.DetailGridInitSetting();

            if (settingGrid)
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].Hidden = true;
            }
        }

        /// <summary>
        /// グリッド列不可入力色設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : グリッド列不可入力色設定します。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        internal void DetailGridInitSetting()
        {
            if (this.uGrid_Details == null || this.uGrid_Details.Rows.Count < 1)
            {
                return;
            }

            UltraGridRow row = this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1];

            foreach (UltraGridCell cell in row.Cells)
            {
                if (cell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName    //得意先コード
                 || cell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName //拠点コード
                 || cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName //推奨元BLコード
                 || cell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName  //推奨先BLコード
                 || cell.Column.Key == this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName)  //商品コメント // ADD 2015/02/06 T.Miyamoto コメント項目追加
                {
                    cell.Activation = Activation.AllowEdit;
                    cell.Appearance.BackColor = Color.Empty;
                }
                else
                if (cell.Column.Key == this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName     //得意先略称
                 || cell.Column.Key == this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName //拠点名
                 || cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName //推奨元BLコード名
                 || cell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName)  //推奨先BLコード名
                {
                    cell.Activation = Activation.NoEdit;
                    cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                }
            }
        }

        /// <summary>
        /// 拠点ガイド起動
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note	   : 拠点ガイド起動。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        internal void SectionCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // コードから名称へ変換
                SecInfoSet secInfoSet;
                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = secInfoSet.SectionCode;
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = secInfoSet.SectionGuideNm;
                    MoveNextAllowEditCell(false);
                }
                else
                {
                    // 結果セット
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ＢＬコードガイド起動
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note	   : ＢＬコードガイド起動。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        internal void BLGoodsCodeGuide(int rowIndex, string keyName)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // コードから名称へ変換
                BLGoodsCdUMnt blGoodsUnit;
                int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsUnit);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    switch (keyName)
                    {
                        case "RecSourceBLGoodsCd":
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Value = blGoodsUnit.BLGoodsCode;
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Value = blGoodsUnit.BLGoodsHalfName;
                                break;
                            }
                        case "RecDestBLGoodsCd":
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Value = blGoodsUnit.BLGoodsCode;
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Value = blGoodsUnit.BLGoodsHalfName;
                                break;
                            }
                    }
                    MoveNextAllowEditCell(false);
                }
                else
                {
                    // 結果セット
                    switch (keyName)
                    {
                        case "RecSourceBLGoodsCd":
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                                break;
                            }
                        case "RecDestBLGoodsCd":
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Activate();
                                break;
                            }
                    }
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 得意先コードガイド起動
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note	   : 得意先コードガイド起動。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        internal void CustomerCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 得意先ガイド
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if (this._customerSearchRet != null)
                {
                    if (CustomerCheck_Detail(this._customerSearchRet.CustomerCode, rowIndex))
                    {
                        MoveNextAllowEditCell(false);
                    }
                    this._customerSearchRet = null;
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 復活ボタン無効/有効設定
        /// </summary>
        /// <param name="mode">mode1,2,3</param>
        /// <remarks>
        /// <br>Note	   : 復活ボタン無効/有効設定。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        internal void SetButtonEnabled(int mode)
        {
            switch (mode)
            {
                case 1:
                    {
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Revival"].SharedProps.Enabled = false;     // 復活
                        this.uButton_Revival.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = true;    // 行削除
                        this.uButton_RowDelete.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllRowDelete"].SharedProps.Enabled = true; // 全削除
                        this.uButton_AllRowDelete.Enabled = true;
                        // --- ADD 2015/03/05 Y.Wakita Redmine#332 ---------->>>>>
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowInsert"].SharedProps.Enabled = true;    // 行挿入
                        this.uButton_RowInsert.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowCut"].SharedProps.Enabled = true;       // 切り取り
                        this.uButton_RowCut.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowCopy"].SharedProps.Enabled = true;      // コピー
                        this.uButton_RowCopy.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowPaste"].SharedProps.Enabled = true;     // 貼り付け
                        this.uButton_RowPaste.Enabled = true;
                        // --- ADD 2015/03/05 Y.Wakita Redmine#332 ----------<<<<<
                        break;
                    }
                case 2:
                    {
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Revival"].SharedProps.Enabled = true;
                        this.uButton_Revival.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = true;
                        this.uButton_RowDelete.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllRowDelete"].SharedProps.Enabled = true;
                        this.uButton_AllRowDelete.Enabled = true;
                        // --- ADD 2015/03/05 Y.Wakita Redmine#332 ---------->>>>>
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowInsert"].SharedProps.Enabled = false; // 行挿入
                        this.uButton_RowInsert.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowCut"].SharedProps.Enabled = false; // // 切り取り
                        this.uButton_RowCut.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowCopy"].SharedProps.Enabled = false; // // コピー
                        this.uButton_RowCopy.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowPaste"].SharedProps.Enabled = false; // // 貼り付け
                        this.uButton_RowPaste.Enabled = false;
                        // --- ADD 2015/03/05 Y.Wakita Redmine#332 ----------<<<<<
                        break;
                    }
                case 3:
                    {
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Revival"].SharedProps.Enabled = false;
                        this.uButton_Revival.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = false;
                        this.uButton_RowDelete.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllRowDelete"].SharedProps.Enabled = false;
                        this.uButton_AllRowDelete.Enabled = false;
                        // --- ADD 2015/03/05 Y.Wakita Redmine#332 ---------->>>>>
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowInsert"].SharedProps.Enabled = false;   // 行挿入
                        this.uButton_RowInsert.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowCut"].SharedProps.Enabled = false;      // 切り取り
                        this.uButton_RowCut.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowCopy"].SharedProps.Enabled = false;     // コピー
                        this.uButton_RowCopy.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowPaste"].SharedProps.Enabled = false;    // 貼り付け
                        this.uButton_RowPaste.Enabled = false;
                        // --- ADD 2015/03/05 Y.Wakita Redmine#332 ----------<<<<<
                        break;
                    }
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先選択時に発生します。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._customerSearchRet = null;
                return;
            }
            this._customerSearchRet = customerSearchRet;
        }

        /// <summary>
        /// 得意先チェック処理
        /// </summary>
        public bool CustomerCheck_Detail(int customerCode, int rowIndex)
        {
            string errMsg;
            CustomerInfo retCustomerInfo;

            bool checkResult = this._recGoodsLkStAcs.CheckCustomer(customerCode, true, out errMsg, out retCustomerInfo);
            if (checkResult)
            {
                // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
                if (customerCode == 0)
                {
                    // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------>>>>>
                    //this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = customerCode.ToString().PadLeft(8, '0'); //得意先コード
                    //this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = "全得意先"; //得意先略称
                    //this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOriginalEpCdColumn.ColumnName].Value = "0000000000000000";                       //得意先企業コード
                    //this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOriginalSecCdColumn.ColumnName].Value = "000000";                     //得意先拠点コード
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = RecGoodsLkStAcs.ALL_CUSTOMERCODE;      //得意先コード
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = RecGoodsLkStAcs.ALL_CUSTOMERNAME;       //得意先略称
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOriginalEpCdColumn.ColumnName].Value = RecGoodsLkStAcs.ALL_ORIGINALEPCD;   //得意先企業コード
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOriginalSecCdColumn.ColumnName].Value = RecGoodsLkStAcs.ALL_ORIGINALSECCD; //得意先拠点コード
                    // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------<<<<<
                }
                // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = retCustomerInfo.CustomerCode.ToString().PadLeft(8, '0'); //得意先コード
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = retCustomerInfo.CustomerSnm;                              //得意先略称
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOriginalEpCdColumn.ColumnName].Value = retCustomerInfo.CustomerEpCode;                       //得意先企業コード
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOriginalSecCdColumn.ColumnName].Value = retCustomerInfo.CustomerSecCode;                     //得意先拠点コード
                    this._swCustomerInfo = retCustomerInfo.CustomerCode.ToString().PadLeft(8, '0');
                }
            }
            else
            {
                TMsgDisp.Show(this
                             , emErrorLevel.ERR_LEVEL_EXCLAMATION
                             , this.Name
                             , errMsg
                             , 0
                             , MessageBoxButtons.OK);

                if (this._swCustomerInfo != string.Empty)
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = this._swCustomerInfo.ToString().PadLeft(8, '0'); //前の値に戻す
                }
            }
            return checkResult;
        }
        /// <summary>
        /// 拠点チェック処理
        /// </summary>
        public bool SectionCheck_Detail(string sectionCode, int rowIndex)
        {
            string errMsg;
            SecInfoSet retSectionInfo;

            bool checkResult = this._recGoodsLkStAcs.CheckSection(sectionCode, false, out errMsg, out retSectionInfo);
            if (checkResult)
            {
                // --- UPD 2015/02/12 T.Miyamoto ------------------------------>>>>>
                //if (sectionCode == "00")
                Int32 chkSectionCode = 0;
                Int32.TryParse(sectionCode, out chkSectionCode);
                if (chkSectionCode == 0)
                // --- UPD 2015/02/12 T.Miyamoto ------------------------------<<<<<
                {
                    // --- UPD 2015/02/12 T.Miyamoto ------------------------------>>>>>
                    //this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode; //拠点コード
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = chkSectionCode.ToString().PadLeft(2, '0'); ; //拠点コード
                    // --- UPD 2015/02/12 T.Miyamoto ------------------------------<<<<<
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = "全社共通";  //拠点略称
                    this._swSectionInfo = sectionCode;
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = retSectionInfo.SectionCode.Trim().PadLeft(2, '0'); //拠点コード
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = retSectionInfo.SectionGuideNm; //拠点略称
                    this._swSectionInfo = retSectionInfo.SectionCode.Trim().PadLeft(2, '0');
                }
            }
            else
            {
                TMsgDisp.Show(this
                             , emErrorLevel.ERR_LEVEL_EXCLAMATION
                             , this.Name
                             , errMsg
                             , 0
                             , MessageBoxButtons.OK);

                this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = this._swSectionInfo.ToString().PadLeft(2, '0');
            }
            return checkResult;
        }

        /// <summary>
        /// グリッドNextフォーカス取得処理
        /// </summary>
        /// <param name="mode">モード(0:Tab;1;Shift + Tab)</param>
        /// <param name="rowIndex">rowIndex</param>
        /// <param name="columnKey">columnKey</param>
        /// <returns>columnIndex</returns>
        /// <remarks>
        /// <br>Note       : グリッドNextフォーカス取得を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private int GetNextColumnIndexByTab(int mode, int rowIndex, string columnKey)
        {
            int columnIndex = -1;
            switch (mode)
            {
                case 0:
                    #region Tab
                    if (columnKey == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName)
                    // --- ADD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------>>>>>
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName)
                    // --- ADD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------<<<<<
                    {
                        columnIndex = -1;
                    }
                    break;
                    #endregion Tab
                case 1:
                    #region Shift + Tab
                    if (columnKey == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName)
                    {
                        columnIndex = -1;
                    }
                    if (columnKey == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Column.Index;
                    }
                    else if (columnKey == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Column.Index;
                    }
                    // --- ADD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------>>>>>
                    else if (columnKey == this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName)
                    {
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Column.Index;
                    }
                    // --- ADD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------<<<<<
                    break;
                    #endregion Shift + Tab
            }

            return columnIndex;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// 変化データ取得処理
        /// </summary>
        /// <param name="delList">削除リスト</param>
        /// <param name="updList">登録リスト</param>
        /// <remarks>
        /// <br>Note       : 変化データ取得処理</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void GetSaveDate(out List<RecGoodsLkSt> delList, out List<RecGoodsLkSt> updList)
        {
            this._prevRecGoodsLkDic = this._recGoodsLkStAcs.PrevRecGoodsLkDic;
            List<RecGoodsLkSt> dList = new List<RecGoodsLkSt>();
            List<RecGoodsLkSt> uList = new List<RecGoodsLkSt>();

            RecGoodsLkSt recGoodsLk = new RecGoodsLkSt();
            RecGoodsLkSt recGoodsLkUPD = new RecGoodsLkSt();
            if (this._recGoodsLkDataTable.Rows.Count > 0)
            {
                foreach (RecGoodsLkDataSet.RecGoodsLkRow row in this._recGoodsLkDataTable.Rows)
                {
                    recGoodsLk = new RecGoodsLkSt();
                    this._recGoodsLkStAcs.CopyToRecGoodsLkFromDetailRow(row, ref recGoodsLk);
                    // 改修行の場合
                    if (_prevRecGoodsLkDic.ContainsKey(row.FilterGuid))
                    {
                        bool keyChanged = this._recGoodsLkStAcs.CompareKey(recGoodsLk, _prevRecGoodsLkDic[row.FilterGuid]);

                        if (row.RowDeleteFlg == 0)
                        {
                            if (this._recGoodsLkStAcs.Compare(recGoodsLk, _prevRecGoodsLkDic[row.FilterGuid]))
                            {
                                dList.Add(_prevRecGoodsLkDic[row.FilterGuid]);
                                recGoodsLkUPD = recGoodsLk.Clone();
                                recGoodsLkUPD.LogicalDeleteCode = 0;
                                recGoodsLkUPD.IsUpdRow = false;
                                uList.Add(recGoodsLkUPD);
                            }
                        }
                        else
                        {
                            // 行削除の場合
                            recGoodsLk = _prevRecGoodsLkDic[row.FilterGuid];
                            recGoodsLkUPD = recGoodsLk.Clone();
                            recGoodsLkUPD.LogicalDeleteCode = 1;
                            if (!keyChanged)
                            {
                                recGoodsLkUPD.IsUpdRow = true;
                            }
                            uList.Add(recGoodsLkUPD);
                        }
                    }
                    // 新規行の場合
                    else
                    {
                        if (this._recGoodsLkStAcs.IsRowUpdate(row) && row.RowDeleteFlg == 0)
                        {
                            recGoodsLkUPD = recGoodsLk.Clone();
                            recGoodsLkUPD.LogicalDeleteCode = 0;
                            recGoodsLkUPD.IsUpdRow = false;
                            uList.Add(recGoodsLkUPD);
                        }
                    }
                }
            }

            delList = dList;
            updList = uList;
        }

        /// <summary>
        /// 保存前チェック処理
        /// </summary>
        /// <param name="deleteList">削除リスト</param>
        /// <param name="updateList">更新リスト</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 保存前チェック処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CheckSaveDate(out List<RecGoodsLkSt> deleteList, out List<RecGoodsLkSt> updateList)
        {
            List<RecGoodsLkSt> delList = new List<RecGoodsLkSt>();
            List<RecGoodsLkSt> updList = new List<RecGoodsLkSt>();

            this.GetSaveDate(out delList, out updList);
            deleteList = delList;
            updateList = updList;

            if (updateList.Count == 0)
            {
                return false;
            }

            #region
            if (updateList.Count != 0)
            {
                int rowIndex = -1;
                foreach (RecGoodsLkSt recGoodsLk in updateList)
                {
                    // 行削除のデータがチェックない
                    if (recGoodsLk.LogicalDeleteCode == 1)
                    {
                        continue;
                    }

                    //行番号を取得
                    rowIndex = recGoodsLk.RowIndex;

                    // 拠点コードを入力チェック
                    //int inqOtherSecCd = 0;
                    //int.TryParse(recGoodsLk.InqOtherSecCd.Trim(), out inqOtherSecCd);
                    if (recGoodsLk.InqOtherSecCd.Trim() == string.Empty)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "拠点コードを入力して下さい。",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }

                    // --- DEL 2015/02/09 T.Nishi ------------------------------>>>>>
                    //// 得意先コードを入力チェック
                    //if (recGoodsLk.CustomerCode == 0)
                    //{
                    //    TMsgDisp.Show(
                    //         this,
                    //         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    //         this.Name,
                    //         "得意先コードを入力して下さい。",
                    //         0,
                    //         MessageBoxButtons.OK);
                    //    if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                    //    {
                    //        this.uGrid_Details.Rows[rowIndex-1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                    //        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    //    }
                    //    return false;
                    //}
                    // --- DEL 2015/02/09 T.Nishi ------------------------------<<<<<

                    // --- ADD 2015/02/16 Y.Wakita RedMine#217 ------------------------------>>>>>
                    // 得意先コードを入力チェック
                    string errMsg;
                    CustomerInfo retCustomerInfo;

                    bool checkResult = this._recGoodsLkStAcs.CheckCustomer(recGoodsLk.CustomerCode, true, out errMsg, out retCustomerInfo);
                    if (!(checkResult))
                    {
                        TMsgDisp.Show(this
                                     , emErrorLevel.ERR_LEVEL_EXCLAMATION
                                     , this.Name
                                     , errMsg
                                     , 0
                                     , MessageBoxButtons.OK);

                        if (this._swCustomerInfo != string.Empty)
                        {
                            this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }
                    // --- ADD 2015/02/16 Y.Wakita RedMine#217 ------------------------------<<<<<
                    // --- ADD 2015/03/02 T.Miyamoto RedMine#217 ------------------------------>>>>>
                    if (recGoodsLk.CustomerCode == 0)
                    {
                        // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------>>>>>
                        //this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = "00000000";            //得意先コード
                        //this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = "全得意先";             //得意先略称
                        //this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.InqOriginalEpCdColumn.ColumnName].Value = "0000000000000000"; //得意先企業コード
                        //this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.InqOriginalSecCdColumn.ColumnName].Value = "000000";          //得意先拠点コード
                        //recGoodsLk.InqOriginalEpCd = "0000000000000000";
                        //recGoodsLk.InqOriginalSecCd = "000000";
                        this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = RecGoodsLkStAcs.ALL_CUSTOMERCODE;      //得意先コード
                        this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = RecGoodsLkStAcs.ALL_CUSTOMERNAME;       //得意先略称
                        this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.InqOriginalEpCdColumn.ColumnName].Value = RecGoodsLkStAcs.ALL_ORIGINALEPCD;   //得意先企業コード
                        this.uGrid_Details.Rows[rowIndex - 1].Cells[this._recGoodsLkDataTable.InqOriginalSecCdColumn.ColumnName].Value = RecGoodsLkStAcs.ALL_ORIGINALSECCD; //得意先拠点コード
                        recGoodsLk.InqOriginalEpCd = RecGoodsLkStAcs.ALL_ORIGINALEPCD;
                        recGoodsLk.InqOriginalSecCd = RecGoodsLkStAcs.ALL_ORIGINALSECCD;
                        // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------<<<<<
                    }
                    // --- ADD 2015/03/02 T.Miyamoto RedMine#217 ------------------------------<<<<<

                    // 推奨元BLコードを入力チェック
                    if (recGoodsLk.RecSourceBLGoodsCd == 0)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "推奨元BLコードを入力して下さい。",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex-1].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }

                    // 推奨先BLコードを入力チェック
                    if (recGoodsLk.RecDestBLGoodsCd == 0)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "推奨先BLコードを入力して下さい。",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex-1].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }
                    else
                    {
                        if (recGoodsLk.RecSourceBLGoodsCd == recGoodsLk.RecDestBLGoodsCd)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "推奨元BLコードと推奨先BLコードが同一です。",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex-1].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }
                    }
                }
            }

            if (updateList.Count != 0)
            {
                int rowIndex = -1;
                foreach (RecGoodsLkSt recGoodsLk in updateList)
                {
                    // 削除行はチェックなし
                    if (recGoodsLk.LogicalDeleteCode == 1)
                    {
                        continue;
                    }

                    //行番号を取得
                    rowIndex = recGoodsLk.RowIndex;

                    #region 重複レコードの存在チェック
                    foreach (RecGoodsLkDataSet.RecGoodsLkRow row in this._recGoodsLkDataTable.Rows)
                    {
                        Int32 chkCustomerCode = 0;
                        Int32.TryParse(row.CustomerCode, out chkCustomerCode);
                        if (row.UpdateTime == DateTime.MinValue.ToString("yy/MM/dd")
                         && chkCustomerCode == 0)
                        {
                            continue;
                        }
                        if (row.FilterGuid == Guid.Empty && row.RowDeleteFlg == 1)
                        {
                            continue;
                        }
                        if (row.RowNo == recGoodsLk.RowIndex)
                        {
                            continue;
                        }
                        if (chkCustomerCode == recGoodsLk.CustomerCode
                         && row.InqOtherSecCd.Trim().PadLeft(2, '0') == recGoodsLk.InqOtherSecCd.Trim().PadLeft(2, '0')
                         && row.RecSourceBLGoodsCd == recGoodsLk.RecSourceBLGoodsCd
                         && row.RecDestBLGoodsCd == recGoodsLk.RecDestBLGoodsCd)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "同一の商品設定が既に登録されています。" + "\r\n" +
                                 "・拠点ｺｰﾄﾞ　  ：" + recGoodsLk.InqOtherSecCd.ToString().PadLeft(2, '0') + "\r\n" +
                                 "・得意先ｺｰﾄﾞ　：" + recGoodsLk.CustomerCode.ToString().PadLeft(8, '0') + "\r\n" +
                                 "・推奨元BLｺｰﾄﾞ：" + recGoodsLk.RecSourceBLGoodsCd.ToString().PadLeft(5, '0') + "\r\n" +
                                 "・推奨先BLｺｰﾄﾞ：" + recGoodsLk.RecDestBLGoodsCd.ToString().PadLeft(5, '0'),
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex-1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }
                    }
                    #endregion 重複レコードの存在チェック
                }
            }
            #endregion

            return true;
        }

        // --- ADD 2015/03/02 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// サンプル展開前チェック処理
        /// </summary>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : サンプル展開前チェック処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/03/02</br>
        /// </remarks>
        public bool CheckSampleData(string sampleSecCd, string sampleSecNm, CustomerInfo sampleCustomerInfo)
        {
            foreach (RecGoodsLkDataSet.RecGoodsLkRow row in this._recGoodsLkDataTable.Rows)
            {
                if (this._recGoodsLkStAcs.IsRowUpdate(row) && row.RowDeleteFlg == 0) // ADD 2015/03/04 T.Miyamoto Redmine#318
                {
                    // --- UPD 2015/03/04 T.Miyamoto Redmine#321 ------------------------------>>>>>
                    //if ((row.InqOtherSecCd == sampleSecCd.Trim())
                    // && (row.CustomerCode == sampleCustomerInfo.CustomerCode.ToString().PadLeft(8, '0'))
                    // && (row.InqOriginalEpCd == sampleCustomerInfo.CustomerEpCode)
                    // && (row.InqOriginalSecCd == sampleCustomerInfo.CustomerSecCode))
                    if ((row.InqOtherSecCd.Trim() == sampleSecCd.Trim())
                     && (row.CustomerCode.Trim() == sampleCustomerInfo.CustomerCode.ToString().PadLeft(8, '0'))
                     && (row.InqOriginalEpCd.Trim() == sampleCustomerInfo.CustomerEpCode.Trim())
                     && (row.InqOriginalSecCd.Trim() == sampleCustomerInfo.CustomerSecCode.Trim()))
                    // --- UPD 2015/03/04 T.Miyamoto Redmine#321 ------------------------------<<<<<
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        // --- ADD 2015/03/02 T.Miyamoto ------------------------------<<<<<


        /// <summary>
        /// DOWN前チェック処理
        /// </summary>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 保存前チェック処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CheckDateForDown()
        {
            RecGoodsLkDataSet.RecGoodsLkRow row = (RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkDataTable.Rows[this._recGoodsLkDataTable.Count - 1];
            // 行削除のデータがチェックない
            if (row.RowDeleteFlg == 1)
            {
                return true;
            }

            RecGoodsLkSt recGoodsLk = new RecGoodsLkSt();
            this._recGoodsLkStAcs.CopyToRecGoodsLkFromDetailRow((RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkDataTable.Rows[this._recGoodsLkDataTable.Count - 1], ref recGoodsLk);

            // 行削除のデータがチェックない
            if (recGoodsLk.LogicalDeleteCode == 1)
            {
                return true;
            }

            // 拠点コード入力チェック
            if (recGoodsLk.InqOtherSecCd == string.Empty)
            {
                return false;
            }
            // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
            //// 得意先コード入力チェック
            //if (recGoodsLk.CustomerCode == 0)
            //{
            //    return false;
            //}
            // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
            // 推奨元BLコード入力チェック
            if (recGoodsLk.RecSourceBLGoodsCd == 0)
            {
                return false;
            }
            // 推奨先BLコード入力チェック
            if (recGoodsLk.RecDestBLGoodsCd == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 保存前チェック処理（削除指定区分＝１）
        /// </summary>
        /// <param name="deleteList">削除リスト</param>
        /// <param name="updateList">更新リスト</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 保存前チェック処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void ReturnSaveDate(out List<RecGoodsLkSt> deleteList, out List<RecGoodsLkSt> updateList)
        {
            this._prevRecGoodsLkDic = this._recGoodsLkStAcs.PrevRecGoodsLkDic;
            List<RecGoodsLkSt> delList = new List<RecGoodsLkSt>();
            List<RecGoodsLkSt> updList = new List<RecGoodsLkSt>();

            RecGoodsLkSt recGoodsLk = new RecGoodsLkSt();
            RecGoodsLkSt recGoodsLkUPD = new RecGoodsLkSt();
            if (this._recGoodsLkDataTable.Rows.Count > 0)
            {
                foreach (RecGoodsLkDataSet.RecGoodsLkRow row in this._recGoodsLkDataTable.Rows)
                {
                    this._recGoodsLkStAcs.CopyToRecGoodsLkFromDetailRow(row, ref recGoodsLk);
                    if (row.RowDeleteFlg == 1)
                    {
                        delList.Add(this._prevRecGoodsLkDic[row.FilterGuid]);
                    }
                    else if (row.RowDeleteFlg == 2)
                    {
                        recGoodsLk = this._prevRecGoodsLkDic[row.FilterGuid];
                        recGoodsLkUPD = recGoodsLk.Clone();
                        recGoodsLkUPD.LogicalDeleteCode = 0;
                        updList.Add(recGoodsLkUPD);
                    }
                }
            }

            deleteList = delList;
            updateList = updList;
        }

        /// <summary>
        /// 検索後、明細部設定処理
        /// </summary>
        /// <param name="deleteFlg">削除指定区分</param>
        /// <remarks>
        /// <br>Note       : 検索後、明細部設定処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void GridSettingAfterSearch(bool deleteFlg)
        {
            //削除指定区分:0
            if (deleteFlg == false)
            {
                this.SetButtonEnabled(1);
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].Hidden = true;

                foreach (UltraGridRow row in this.uGrid_Details.Rows)
                {
                    // 新規行以外
                    if (!Guid.Empty.Equals((Guid)row.Cells[this._recGoodsLkDataTable.FilterGuidColumn.ColumnName].Value))
                    {
                        row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                        row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.NoEdit;
                        row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                        row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    }
                    else
                    {
                        row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                        row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.AllowEdit;
                    }
                    row.Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                    row.Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activation = Activation.AllowEdit;
                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                    row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Activation = Activation.AllowEdit;
                    row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;

                    row.Cells[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Activation = Activation.AllowEdit; // ADD 2015/02/06 T.Miyamoto コメント項目追加
                }
            }
            //削除指定区分:1
            else
            {
                this.SetButtonEnabled(2);
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].Hidden = false;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recGoodsLkDataTable.UpdateTimeColumn.ColumnName].CellAppearance.ForeColor = Color.Red;
                foreach (UltraGridRow row in this.uGrid_Details.Rows)
                {
                    foreach (UltraGridCell cell in row.Cells)
                    {
                        if (cell.Column.Key != this._recGoodsLkDataTable.RowNoColumn.ColumnName)
                        {
                            cell.Appearance.BackColor = ct_DISABLE_COLOR;
                            cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                            cell.Activation = Activation.NoEdit;
                        }
                    }
                }
            }
        }

        // --- UPD 2015/02/09 T.Miyamoto サンプル取込機能追加 ------------------------------>>>>>
        /// <summary>
        /// サンプル取込後、明細部設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : サンプル取込後、明細部設定処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/02/09</br>
        /// </remarks>
        public void GridSettingAfterSampleSet()
        {
            int ActiveRow = 0;
            this.SetButtonEnabled(1);
            foreach (UltraGridRow row in this.uGrid_Details.Rows)
            {
                if ((int)row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value == DELETEFLG_SAMPLE)
                {
                    if (ActiveRow == 0) ActiveRow = row.Index;
                    //拠点
                    row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.AllowEdit;
                    row.Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    //得意先
                    row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                    row.Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    //推奨元BLコード
                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activation = Activation.AllowEdit;
                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsNmColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    //推奨先BLコード
                    row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Activation = Activation.AllowEdit;
                    row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Activation = Activation.NoEdit;
                    row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                    row.Cells[this._recGoodsLkDataTable.RecDestBLGoodsNmColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                    //商品コメント
                    row.Cells[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Activation = Activation.AllowEdit;

                    row.Cells[this._recGoodsLkDataTable.RowDeleteFlgColumn.ColumnName].Value = DELETEFLG_DEFAULT;
                }
            }
        }
        // --- UPD 2015/02/09 T.Miyamoto サンプル取込機能追加 ------------------------------<<<<<

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 次入力可能セル移動処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            
            bool moved = false;
            bool performActionResult = false;

            try
            {
                // 更新開始（描画ストップ）
                this.uGrid_Details.BeginUpdate();

                if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
                {
                    if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
                        (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                }

                while (!moved)
                {
                    if (this.uGrid_Details.ActiveRow.Index == this._recGoodsLkDataTable.Count - 1)
                    {
                        if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Text.Trim() == string.Empty)
                        {
                            // --- UPD 2015/02/10② T.Miyamoto コメント項目追加 ------------------------------>>>>>
                            //if (this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            if (this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            // --- UPD 2015/02/10② T.Miyamoto コメント項目追加 ------------------------------<<<<<
                            {
                                if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                                {
                                    if (CheckDateForDown())
                                    {
                                        #region 最終行の場合、新規行を追加する
                                        // --- UPD 2015/02/06 T.Miyamoto ------------------------------>>>>>
                                        //RecGoodsLkDataSet.RecGoodsLkRow newRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
                                        //newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
                                        //newRow.FilterGuid = Guid.Empty;
                                        //newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                                        //newRow.InqOtherEpCd = this._enterpriseCode;
                                        ////newRow.InqOtherSecCd = this._loginSectionCode;
                                        //this._recGoodsLkDataTable.AddRecGoodsLkRow(newRow);

                                        //this.DetailGridInitSetting();
                                        ////得意先情報の初期値セット
                                        //Int32 customerCode = 0;
                                        //string customerName = string.Empty;
                                        //this.GetCustomerInfo(out customerCode, out customerName);
                                        //if (customerCode != 0)
                                        //{
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = customerCode; //得意先コード
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = customerName;  //得意先略称
                                        //}

                                        ////拠点情報の初期値セット
                                        //string sectionCode = string.Empty;
                                        //string sectionName = string.Empty;
                                        //this.GetSectionInfo(out sectionCode, out sectionName);
                                        //if (sectionCode != string.Empty)
                                        //{
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode;
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = sectionName;
                                        //}

                                        ////初期フォーカス位置セット
                                        //if (customerCode != 0 || sectionCode != string.Empty)
                                        //{
                                        //    if (sectionCode == string.Empty)
                                        //    {
                                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                        //    }
                                        //    else if (customerCode == 0)
                                        //    {
                                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                                        //    }
                                        //    else
                                        //    {
                                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    //両方とも空白の場合は拠点コードにフォーカスセット
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                        //}
                                        this.NewRowAdd(this.uGrid_Details.Rows.Count);
                                        // --- UPD 2015/02/06 T.Miyamoto ------------------------------<<<<<

                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return true;
                                        #endregion
                                    }
                                    else
                                    {
                                        moved = false;
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // --- UPD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------>>>>>
                            //if (this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            if (this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            // --- UPD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------<<<<<
                            {
                                if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                                {
                                    if (CheckDateForDown())
                                    {
                                        #region 最終行の場合、新規行を追加する
                                        // --- UPD 2015/02/06 T.Miyamoto ------------------------------>>>>>
                                        //RecGoodsLkDataSet.RecGoodsLkRow newRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
                                        //newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
                                        //newRow.FilterGuid = Guid.Empty;
                                        //newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                                        //newRow.InqOtherEpCd = this._enterpriseCode;
                                        ////newRow.InqOtherSecCd = this._loginSectionCode;
                                        //this._recGoodsLkDataTable.AddRecGoodsLkRow(newRow);

                                        //this.DetailGridInitSetting();
                                        ////得意先情報の初期値セット
                                        //Int32 customerCode = 0;
                                        //string customerName = string.Empty;
                                        //this.GetCustomerInfo(out customerCode, out customerName);
                                        //if (customerCode != 0)
                                        //{
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = customerCode; //得意先コード
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = customerName;  //得意先略称
                                        //}

                                        ////拠点情報の初期値セット
                                        //string sectionCode = string.Empty;
                                        //string sectionName = string.Empty;
                                        //this.GetSectionInfo(out sectionCode, out sectionName);
                                        //if (sectionCode != string.Empty)
                                        //{
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode;
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = sectionName;
                                        //}

                                        ////初期フォーカス位置セット
                                        ////両方とも空白の場合は拠点コードにフォーカスセット
                                        //if (customerCode != 0 || sectionCode != string.Empty)
                                        //{
                                        //    if (sectionCode == string.Empty)
                                        //    {
                                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                        //    }
                                        //    else if (customerCode == 0)
                                        //    {
                                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                                        //    }
                                        //    else
                                        //    {
                                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    //両方とも空白の場合は拠点コードにフォーカスセット
                                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                        //}
                                        this.NewRowAdd(this.uGrid_Details.Rows.Count);
                                        // --- UPD 2015/02/06 T.Miyamoto ------------------------------<<<<<

                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                                        return true;
                                        #endregion
                                    }
                                    else
                                    {
                                        moved = false;
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // 更新終了（描画再開）
                this.uGrid_Details.EndUpdate();
            }

            return performActionResult;
        }

        /// <summary>
        /// 前入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 前入力可能セル移動処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private bool MovePreAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            try
            {
                // 更新開始（描画ストップ）
                this.uGrid_Details.BeginUpdate();

                if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
                {
                    if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
                        (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                }

                while (!moved)
                {
                    if (this.uGrid_Details.ActiveRow.Index == 0)
                    {
                        if (this.uGrid_Details.Rows[0].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation != Activation.AllowEdit
                         && this.uGrid_Details.Rows[0].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activation != Activation.AllowEdit)
                        {
                            if ("RecSourceBLGoodsCd".Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                break;
                            }
                        }
                        else
                        {
                            if ("CampaignCode".Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                break;
                            }
                        }
                    }

                    performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // 更新終了（描画再開）
                this.uGrid_Details.EndUpdate();
            }

            return performActionResult;
        }

        #region ReturnKeyDown
        /// <summary>
        /// ReturnKey押下処理(グリッド内)
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ReturnKey押下処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void ReturnKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
            {
                return;
            }

            string columnKey;
            int rowIndex;

            if (this.uGrid_Details.ActiveCell != null)
            {
                columnKey = this.uGrid_Details.ActiveCell.Column.Key;
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }
            else
            {
                columnKey = this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName;
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }

            e.NextCtrl = null;

            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected)
                {
                    if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                    {
                        if (this.uGrid_Details.ActiveRow.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation == Activation.AllowEdit)
                        {
                            this.uGrid_Details.ActiveRow.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            this.uGrid_Details.ActiveRow.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                    }
                    else
                    {
                        if (this.uGrid_Details.ActiveRow.Index < this.uGrid_Details.Rows.Count - 1)
                        {
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Selected = false;
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index + 1].Activate();
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Selected = true;
                        }
                    }
                    return;
                }
            }

            this.focusFlg = true;
            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

            if (this.focusFlg)
            {
                MoveNextAllowEditCell(false);
            }
            else
            {
                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        #endregion ReturnKeyDown

        #region ShiftKeyDown
        /// <summary>
        /// ShiftKey押下処理(グリッド内)
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ShiftKey押下処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void ShiftKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
            {
                return;
            }

            string columnKey;
            int rowIndex;

            if (this.uGrid_Details.ActiveCell != null)
            {
                columnKey = this.uGrid_Details.ActiveCell.Column.Key;
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }
            else
            {
                columnKey = this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName;
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }

            e.NextCtrl = null;

            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected)
                {
                    if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                    {
                        if (this.uGrid_Details.ActiveRow.Index > 0)
                        {
                            // --- UPD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------>>>>>
                            //this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName].Activate();
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName].Activate();
                            // --- UPD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------<<<<<
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                    }
                    else
                    {
                        if (this.uGrid_Details.ActiveRow.Index > 0)
                        {
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Selected = false;
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Activate();
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Selected = true;
                        }
                    }
                    return;
                }
            }

            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

            if (this.focusFlg)
            {
                MovePreAllowEditCell(false);
            }
            else
            {
                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        #endregion ReturnKeyDown

        /// <summary>
        /// 明細部アクッチブキーを取得
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note       : 明細部アクッチブキーを取得を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public string GetFocusColumnKey(out int rowIndex)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                rowIndex = -1;
                return string.Empty;
            }

            rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            return this.uGrid_Details.ActiveCell.Column.Key;
        }

        /// <summary>
        /// ガイドボタン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ガイドボタン設定処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void SetGridGuid()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                switch (this.uGrid_Details.ActiveCell.Column.Key)
                {
                    case "InqOtherSecCd":    //拠点コード
                    case "CustomerCode":    //得意先コード
                    case "RecSourceBLGoodsCd": //推奨元BLコード
                    case "RecDestBLGoodsCd":   //推奨先BLコード
                        {
                            if (this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                            {
                                this.SetGuidButton(true);
                            }
                            else
                            {
                                this.SetGuidButton(false);
                            }
                            break;
                        }
                    default:
                        {
                            this.SetGuidButton(false);
                            break;
                        }
                }
            }
            else
            {
                this.SetGuidButton(false);
            }
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
        /// <br>Note       : 数値入力チェック処理</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
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
                int _Rketa = RecGoodsLkStAcs.diverge<int>(_strResult[0] == '-', keta - priod, keta - priod - 1);
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
        /// ヘッダ部から、ENTER、TAB、↓押下時、最終明細行＋１行目のコードへフォーカスを遷移する。
        /// </summary>
        /// <remarks>
        /// <br>Note       : ヘッダ部から、ENTER、TAB、↓押下時、最終明細行＋１行目のコードへフォーカスを遷移する。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void SetFocusAfterSearch()
        {
            if (this.uGrid_Details.Rows.Count > 0)
            {
                if (this._recGoodsLkStAcs.DeleteSearchMode == false)
                {
                    bool flag = false;
                    foreach (UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        if (row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation == Activation.AllowEdit)
                        {
                            flag = true;
                            Int32 customerCode = 0;
                            string sectionCode = string.Empty;
                            if (row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Text.Trim() == string.Empty)
                            {
                                //拠点情報の初期値セット
                                string customerName = string.Empty;
                                this.GetCustomerInfo(out customerCode, out customerName);
                                if (customerCode != 0)
                                {
                                    row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = customerCode;
                                    row.Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = customerName;
                                }
                            }
                            if (row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Text.Trim() == string.Empty)
                            {
                                string sectionName = string.Empty;
                                this.GetSectionInfo(out sectionCode, out sectionName);
                                if (sectionCode != string.Empty)
                                {
                                    // --- UPD 2015/03/13 T.Nishi ------------------------------>>>>>
                                    //row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode;
                                    row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode.Trim().PadLeft(2,'0');
                                    // --- UPD 2015/03/13 T.Nishi ------------------------------<<<<<
                                    row.Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = sectionName;
                                }
                            }

                            //初期フォーカス位置セット
                            if (customerCode != 0 || sectionCode != string.Empty)
                            {
                                if (sectionCode == string.Empty)
                                {
                                    row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                                }
                                else if (customerCode == 0)
                                {
                                    row.Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                                }
                                else
                                {
                                    row.Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                                }
                            }
                            else
                            {
                                //両方とも空白の場合は拠点コードにフォーカスセット
                                row.Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                            }

                            break;
                        }
                    }

                    if (flag == false)
                    {
                        #region 最終行の場合、新規行を追加する
                        // --- UPD 2015/02/06 T.Miyamoto ------------------------------>>>>>
                        //RecGoodsLkDataSet.RecGoodsLkRow newRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
                        //newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
                        //newRow.FilterGuid = Guid.Empty;
                        //newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                        //newRow.InqOtherEpCd = this._enterpriseCode;
                        ////newRow.InqOtherSecCd = this._loginSectionCode;

                        //this._recGoodsLkDataTable.AddRecGoodsLkRow(newRow);

                        //this.DetailGridInitSetting();
                        //#endregion

                        //Int32 customerCode = 0;
                        //string customerName = string.Empty;
                        //this.GetCustomerInfo(out customerCode, out customerName);
                        //if (customerCode != 0)
                        //{
                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = customerCode;
                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = customerName;
                        //}

                        ////拠点情報の初期値セット
                        //string sectionCode = string.Empty;
                        //string sectionName = string.Empty;
                        //this.GetSectionInfo(out sectionCode, out sectionName);
                        //if (sectionCode != string.Empty)
                        //{
                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode;
                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = sectionName;
                        //}

                        ////初期フォーカス位置セット
                        //if (customerCode != 0 || sectionCode != string.Empty)
                        //{
                        //    if (sectionCode == string.Empty)
                        //    {
                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                        //    }
                        //    else if (customerCode == 0)
                        //    {
                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                        //    }
                        //    else
                        //    {
                        //        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                        //    }
                        //}
                        //else
                        //{
                        //    //両方とも空白の場合は拠点コードにフォーカスセット
                        //    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                        //}
                        this.NewRowAdd(this.uGrid_Details.Rows.Count);
                        #endregion
                        // --- UPD 2015/02/06 T.Miyamoto ------------------------------<<<<<
                    }
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.uGrid_Details.Focus();
                    this.uGrid_Details.Rows[0].Activate();
                    this.uGrid_Details.Rows[0].Selected = true;
                }
            }
        }
        #endregion

        // --- ADD 2015/02/06 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// 新規明細行追加処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規明細行を追加する。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        public void NewRowAdd(int addRowIndex)
        {
            RecGoodsLkDataSet.RecGoodsLkRow newRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
            newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
            newRow.FilterGuid = Guid.Empty;
            newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
            newRow.InqOtherEpCd = this._enterpriseCode;

            this._recGoodsLkDataTable.AddRecGoodsLkRow(newRow);
            this.DetailGridInitSetting();

            //得意先情報の初期値セット
            Int32 customerCode = 0;
            string customerName = string.Empty;
            this.GetCustomerInfo(out customerCode, out customerName);
            if (customerCode != 0)
            {
                this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Value = customerCode;
                this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.CustomerSnmColumn.ColumnName].Value = customerName;
                // --- ADD 2015/02/12 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#196 ------------------------------>>>>>
                this.CustomerCheck_Detail(customerCode, addRowIndex);
                // --- ADD 2015/02/12 T.Miyamoto ｼｽﾃﾑﾃｽﾄ障害#196 ------------------------------<<<<<
            }

            //拠点情報の初期値セット
            string sectionCode = string.Empty;
            string sectionName = string.Empty;
            this.GetSectionInfo(out sectionCode, out sectionName);
            if (sectionCode != string.Empty)
            {
                // --- UPD 2015/03/13 T.Nishi ------------------------------>>>>>
                //this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode;
                this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Value = sectionCode.Trim().PadLeft(2, '0');
                // --- UPD 2015/03/13 T.Nishi ------------------------------<<<<<
                this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecNmColumn.ColumnName].Value = sectionName;
            }

            //初期フォーカス位置セット
            if (customerCode != 0 || sectionCode != string.Empty)
            {
                if (sectionCode == string.Empty)
                {
                    this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                }
                else if (customerCode == 0)
                {
                    this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activate();
                }
                else
                {
                    this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName].Activate();
                }
            }
            else
            {
                //両方とも空白の場合は拠点コードにフォーカスセット
                this.uGrid_Details.Rows[addRowIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activate();
            }
        }
        // --- ADD 2015/02/06 T.Miyamoto ------------------------------<<<<<

        /// <summary>
        /// グリッドカラム情報の保存
        /// </summary>
        /// <param name="fontSize">fontSize</param>
        /// <param name="autoFillToGrid">autoFillToGrid</param>
        public void SaveSettings(int fontSize, bool autoFillToGrid)
        {
            // 明細グリッド
            List<ColumnInfo> detailColumnsList;
            this.SaveGridColumnsSetting(uGrid_Details, out detailColumnsList);
            this._userSetting.DetailColumnsList = detailColumnsList;
            this._userSetting.OutputStyle = fontSize;
            this._userSetting.AutoAdjustDetail = autoFillToGrid;
        }

        /// <summary>
        /// グリッドカラム情報の読み込み
        /// </summary>
        public void LoadSettings()
        {
            this.LoadGridColumnsSetting(ref uGrid_Details, this._userSetting.DetailColumnsList);
        }


        /// <summary>
        /// グリッドカラム情報の保存
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        private void SaveGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, out List<ColumnInfo> settingList)
        {
            settingList = new List<ColumnInfo>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                settingList.Add(new ColumnInfo(ultraGridColumn.Key, ultraGridColumn.Width));
            }
        }

        /// <summary>
        /// グリッドカラム情報の読み込み
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        private void LoadGridColumnsSetting(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, List<ColumnInfo> settingList)
        {
            if (settingList == null || settingList.Count == 0) return;

            targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Width = columnInfo.Width;
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// 得意先電子元帳用ユーザー設定シリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先電子元帳用ユーザー設定のシリアライズを行います。</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

        }

        /// <summary>
        /// 得意先電子元帳用ユーザー設定デシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先電子元帳用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<RecGoodsLkUserSet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
                catch
                {
                    this._userSetting = new RecGoodsLkUserSet();
                }
            }
        }
    

    // --- ADD 2015/02/09 T.Nishi ------------------------------>>>>>

        /// <summary>
        /// ActiveRowインデックス取得処理
        /// </summary>
        /// <returns>ActiveRowインデックス</returns>
        private int GetActiveRowIndex()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                return this.uGrid_Details.ActiveCell.Row.Index;
            }
            else if (this.uGrid_Details.ActiveRow != null)
            {
                return this.uGrid_Details.ActiveRow.Index;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 明細行オブジェクトの追加を行います。
        /// </summary>
        public void AddRecGoodsLkRow()
        {
            int rowCount = this._recGoodsLkDataTable.Rows.Count;

            RecGoodsLkDataSet.RecGoodsLkRow row = this._recGoodsLkDataTable.NewRecGoodsLkRow();
            this._recGoodsLkDataTable.AddRecGoodsLkRow(row);
        }

        # region  ●コピー処理

        /// <summary>
        /// コピーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_RowCopy_Click(object sender, EventArgs e)
        {
           
            this._recGoodsLkDataTable.AcceptChanges();
            
            // 選択済み行番号リスト取得処理
            List<int> selectedRecGoodsLkRowNoList = this.GetSelectedrecGoodsLkRowNoList();
            if (selectedRecGoodsLkRowNoList == null) return;

            // 明細データテーブルRowStatus列初期化処理
            this.InitializeRecGoodsLkRowStatusColumn();

            // 明細データテーブルRowStatus列値設定処理
            this.SetRecGoodsLkRowStatusColumn(selectedRecGoodsLkRowNoList, ctROWSTATUS_COPY);

            //// 明細グリッドセル設定処理
            this.SettingGrid();

            //// グリッド列初期設定処理
            //this.InitialSettingGridCol();

            // --- DEL 2015/03/05 Y.Wakita Redmine#335 ---------->>>>>
            //// 次入力可能セル移動処理
            //this.MoveNextAllowEditCell(true);
            // --- DEL 2015/03/05 Y.Wakita Redmine#335 ----------<<<<<
        }
        /// <summary>
        /// 選択済み行番号リスト取得処理
        /// </summary>
        /// <returns>選択済み行番号リスト</returns>
        private List<int> GetSelectedrecGoodsLkRowNoList() 
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Details.Selected.Rows;
            if ((cell == null) && (rows == null)) return null;

            List<int> selectedRecRowNoList = new List<int>();
            List<int> selectedIndexList = new List<int>();

            if (cell != null)
            {
                // --- UPD 2015/02/12 T.Nishi ------------------------------>>>>>
                //selectedRecRowNoList.Add(this._recGoodsLkDataTable[cell.Row.Index].RowNo);
                selectedRecRowNoList.Add(int.Parse(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString()));
                // --- UPD 2015/02/12 T.Nishi ------------------------------<<<<<
                selectedIndexList.Add(cell.Row.Index);
            }
            else if (rows != null)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rows)
                {
                    // --- UPD 2015/02/12 T.Nishi ------------------------------>>>>>
                    //selectedRecRowNoList.Add(this._recGoodsLkDataTable[row.Index].RowNo);
                    selectedRecRowNoList.Add(int.Parse(this.uGrid_Details.Rows[row.Index].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString()));
                    // --- UPD 2015/02/12 T.Nishi ------------------------------<<<<<
                    selectedIndexList.Add(row.Index);
                }
            }

            return selectedRecRowNoList;
        }

        /// <summary>
        /// 明細データテーブルの行ステータス列の値を初期化します。
        /// </summary>
        public void InitializeRecGoodsLkRowStatusColumn()
        {
            RecGoodsLkDataSet.RecGoodsLkRow[] rows = (RecGoodsLkDataSet.RecGoodsLkRow[])this._recGoodsLkDataTable.Select(this._recGoodsLkDataTable.RowStatusColumn.ColumnName + " <> " + ctROWSTATUS_NORMAL.ToString());

            this._recGoodsLkDataTable.BeginLoadData();
            foreach (RecGoodsLkDataSet.RecGoodsLkRow row in rows)
            {
                row.RowStatus = 0;
            }
            this._recGoodsLkDataTable.EndLoadData();
        }

        /// <summary>
        /// 指定した行番号のリストを元に、該当する明細行オブジェクトの行ステータスに値を設定します。
        /// </summary>
        /// <param name="stockRowNoList">明細行番号リスト</param>
        /// <param name="rowStatus">RowStatus値</param>
        public void SetRecGoodsLkRowStatusColumn(List<int> RecGoodsLkRowNoList, int rowStatus)
        {
            this._recGoodsLkDataTable.BeginLoadData();
            foreach (int RecGoodsLkRowNo in RecGoodsLkRowNoList)
            {
                RecGoodsLkDataSet.RecGoodsLkRow row = this.GetRecGoodsLkRow(RecGoodsLkRowNo);

                //if ((string.IsNullOrEmpty(row.GoodsName)) && (string.IsNullOrEmpty(row.GoodsNo))) continue;

                row.RowStatus = rowStatus;
            }
            this._recGoodsLkDataTable.EndLoadData();
        }

        /// <summary>
        /// 行取得処理
        /// </summary>
        /// <param name="stockRowNo"></param>
        /// <returns></returns>
        /// <br>Update Note : </br>
        /// <br>管理番号    : </br>
        /// <br>            : </br>
        public RecGoodsLkDataSet.RecGoodsLkRow GetRecGoodsLkRow(int RecRowNo)
        {
            return this._recGoodsLkDataTable.FindByRowNo(RecRowNo);
        }

        # endregion 

        # region  ●貼り付け処理


        /// <summary>
        /// 貼り付けボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_RowPaste_Click(object sender, EventArgs e)
        {
            try
            {
                this._recGoodsLkDataTable.AcceptChanges();

                // ActiveRowインデックス取得処理
                int rowIndex = this.GetActiveRowIndex();
                if (rowIndex == -1) return;

                // コピー明細行番号取得処理
                List<int> copyRecGoodsLkRowNoList = this.GetCopyRecGoodsLkRowNo();
                if (copyRecGoodsLkRowNoList == null) return;

                // --- DEL 2015/02/12 T.Nishi ------------------------------>>>>>
                //ここで行挿入処理を行うと、後の処理でずれるので位置をずらす。
                //for (int i = 0; i < copyRecGoodsLkRowNoList.Count; i++)
                //{
                //    // 明細行挿入処理
                //    this.InsertRecGoodsLkRow(rowIndex);
                //}
                // --- DEL 2015/02/12 T.Nishi ------------------------------<<<<<

                // 表示行数取得処理
                int prevVisibleRowCount = this.GetVisibleRowCount();

                // 明細行貼り付け処理
                this.PasteRecGoodsLkRow(copyRecGoodsLkRowNoList, rowIndex);

                // 明細グリッドセル設定処理
                this.SettingGrid();
                //this.InitialSettingGridCol();

                // 表示行数取得処理
                int afterVisibleRowCount = this.GetVisibleRowCount();

                // 表示する行数が減った場合、調整する
                if (afterVisibleRowCount < prevVisibleRowCount)
                {
                    for (int i = afterVisibleRowCount; i < prevVisibleRowCount; i++)
                    {
                        this.AddRecGoodsLkRow();
                    }

                    // 明細グリッドセル設定処理
                    this.SettingGrid();
                    //this.InitialSettingGridCol();
                }
            }
            finally
            {
                if (this.uGrid_Details.ActiveCell != null)
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());
            }
        }

        /// <summary>
        /// 明細データテーブルにコピー行の行番号リストを取得します。
        /// </summary>
        /// <returns>行番号リスト</returns>
        public List<int> GetCopyRecGoodsLkRowNo()
        {
            RecGoodsLkDataSet.RecGoodsLkRow[] rows = (RecGoodsLkDataSet.RecGoodsLkRow[])this._recGoodsLkDataTable.Select(this._recGoodsLkDataTable.RowStatusColumn.ColumnName + " <> " + ctROWSTATUS_NORMAL.ToString());

            if ((rows != null) && (rows.Length > 0))
            {
                List<int> recGoodsLkRowNoList = new List<int>();
                foreach (RecGoodsLkDataSet.RecGoodsLkRow row in rows)
                {
                    recGoodsLkRowNoList.Add(row.RowNo);
                }

                return recGoodsLkRowNoList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 指定したインデックスの明細データ行に対して行貼り付けを行う際、確認が必要かどうかをチェックします。
        /// </summary>
        /// <param name="copyStockRowNoList">コピー行行番号リスト</param>
        /// <param name="pasteIndex">貼り付け行Index</param>
        /// <returns>0:チェック不要 1:チェック必要 2:貼り付け不可</returns>
        public int CheckPasteRecGoodsLkRow(List<int> copyRecGoodsLkRowNoList, int pasteIndex)
        {
            int check = 0;
            // --- UPD 2015/02/12 T.Nishi ------------------------------>>>>>
            //int pasteRecGoodsLkRowNo = this._recGoodsLkDataTable[pasteIndex].RowNo;
            int pasteRecGoodsLkRowNo = int.Parse(this.uGrid_Details.Rows[pasteIndex].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString());
            // --- UPD 2015/02/12 T.Nishi ------------------------------<<<<<

            for (int i = 0; i < copyRecGoodsLkRowNoList.Count; i++)
            {
                RecGoodsLkDataSet.RecGoodsLkRow sourceRow = this._recGoodsLkDataTable.FindByRowNo(copyRecGoodsLkRowNoList[i]);

                if (sourceRow == null)
                {
                    continue;
                }

                RecGoodsLkDataSet.RecGoodsLkRow row = this._recGoodsLkDataTable.FindByRowNo(pasteRecGoodsLkRowNo + i);

                if (row != null)
                {
                    if (this.ExistRecGoodsLkInput(row))
                    {
                        check = 1;
                    }
                }
            }

            return check;
        }

        /// <summary>
        /// 表示行数取得処理
        /// </summary>
        /// <returns>表示行数</returns>
        private int GetVisibleRowCount()
        {
            int count = 0;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_Details.Rows)
            {
                if (!row.Hidden)
                {
                    count++;
                }
            }

            return count;
        }
        /// <summary>
        /// 明細データ行オブジェクトの貼り付けを行います。
        /// </summary>
        /// <param name="copyStockRowNoList">コピー行行番号リスト</param>
        /// <param name="pasteIndex">貼り付け行Index</param>
        public void PasteRecGoodsLkRow(List<int> copyRecGoodsLkRowNoList, int pasteIndex)
        {
            // --- UPD 2015/02/12 T.Nishi ------------------------------>>>>>
            //int pasteTargetRecGoodsLkRowNo = this._recGoodsLkDataTable[pasteIndex].RowNo;
            int pasteTargetRecGoodsLkRowNo = int.Parse(this.uGrid_Details.Rows[pasteIndex].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString());
            // --- UPD 2015/02/12 T.Nishi ------------------------------<<<<<

            this._recGoodsLkDataTable.BeginLoadData();
            List<int> cutRecGoodsLkRowNoList = new List<int>();
            List<int> pasteRecGoodsLkRowNoList = new List<int>();
            List<int> deleteRecGoodsLkRowNoList = new List<int>();
            List<RecGoodsLkDataSet.RecGoodsLkRow> copyRecGoodsLkRowList = new List<RecGoodsLkDataSet.RecGoodsLkRow>();

            foreach (int RecGoodsLkRowNo in copyRecGoodsLkRowNoList)
            {
                RecGoodsLkDataSet.RecGoodsLkRow row = this.GetRecGoodsLkRow(RecGoodsLkRowNo);

                if (row != null)
                {
                    copyRecGoodsLkRowList.Add(this.CloneRecGoodsLkRow(row));

                    if (row.RowStatus == ctROWSTATUS_CUT)
                    {
                        cutRecGoodsLkRowNoList.Add(row.RowNo);
                    }
                }
            }

            if (cutRecGoodsLkRowNoList.Count > 0)
            {
                // 明細行クリア処理
                for (int i = 0; i < cutRecGoodsLkRowNoList.Count; i++)
                {
                    this.ClearRecGoodsLkRow(this.GetRecGoodsLkRow(cutRecGoodsLkRowNoList[i]));
                }
            }

            // --- ADD 2015/02/12 T.Nishi ------------------------------>>>>>
            // 明細行挿入処理
            for (int i = 0; i < copyRecGoodsLkRowNoList.Count; i++)
            {
                // 明細行挿入処理
                this.InsertRecGoodsLkRow(pasteIndex);
            }
            // --- ADD 2015/02/12 T.Nishi ------------------------------<<<<<

            for (int i = 0; i < copyRecGoodsLkRowList.Count; i++)
            {
                RecGoodsLkDataSet.RecGoodsLkRow sourceRow = copyRecGoodsLkRowList[i];
                RecGoodsLkDataSet.RecGoodsLkRow targetRow = null;

                if ((pasteIndex + i) < this._recGoodsLkDataTable.Count)
                {


                    // --- UPD 2015/02/12 T.Nishi ------------------------------>>>>>
                    //targetRow = this._recGoodsLkDataTable[pasteIndex + i];
                    targetRow = this.GetRecGoodsLkRow(int.Parse(this.uGrid_Details.Rows[pasteIndex + i].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString()));
                    // --- UPD 2015/02/12 T.Nishi ------------------------------<<<<<

                    // --- ADD 2015/02/12 T.Nishi ------------------------------>>>>>
                    this.CopyRecGoodsLkRow(sourceRow, targetRow);
                    //コピーしなくていい項目をクリア
                    targetRow.UpdateTime = string.Empty;          // 更新日付
                    targetRow.InqOtherSecCd = string.Empty;       // 問合せ先拠点コード
                    targetRow.InqOtherSecNm = string.Empty;       // 問合せ先拠点名
                    targetRow.CustomerCode = string.Empty;        // 得意先コード
                    targetRow.CustomerSnm = string.Empty;         // 得意先名
                    targetRow.FilterGuid = Guid.Empty;
                    // --- ADD 2015/02/12 T.Nishi ------------------------------<<<<<
                    // --- ADD 2015/03/06 T.Miyamoto Redmine#341 ------------------------------>>>>>
                    // 貼り付けデータの削除フラグをOFF
                    targetRow.RowDeleteFlg = 0;
                    // --- ADD 2015/03/06 T.Miyamoto Redmine#341 ------------------------------<<<<<
                    pasteRecGoodsLkRowNoList.Add(targetRow.RowNo);
                }
            }
            this._recGoodsLkDataTable.EndLoadData();

            // 不要な行を削除する
            this.DeleteRecGoodsLkRow(deleteRecGoodsLkRowNoList, true);

        }

        /// <summary>
        /// 明細行がデータ入力済みかチェックします。
        /// </summary>
        /// <returns></returns>
        public bool ExistRecGoodsLkInput(RecGoodsLkDataSet.RecGoodsLkRow row)
        {
            return ((!string.IsNullOrEmpty(row.InqOtherSecCd)) || (!string.IsNullOrEmpty(row.CustomerCode))
                || (!string.IsNullOrEmpty(row.RecDestBLGoodsCd.ToString())) || (!string.IsNullOrEmpty(row.RecSourceBLGoodsCd.ToString())));
        }


        /// <summary>
        /// 明細行オブジェクトの削除を行います。（オーバーロード）
        /// </summary> 
        /// <param name="stockRowNoList">削除行StockRowNoリスト</param>
        /// <param name="changeRowCount">true:行数を変更する false:行数を変更するは変更しない</param>
        public void DeleteRecGoodsLkRow(List<int> RecGoodsLkRowNoList, bool changeRowCount)
        {
            if (RecGoodsLkRowNoList.Count == 0) return;

            this._recGoodsLkDataTable.BeginLoadData();
            foreach (int RecGoodsLkRowNo in RecGoodsLkRowNoList)
            {
                RecGoodsLkDataSet.RecGoodsLkRow targetRow = this.GetRecGoodsLkRow(RecGoodsLkRowNo);

                if (targetRow == null) continue;

                this._recGoodsLkDataTable.RemoveRecGoodsLkRow(targetRow);
            }

            // データテーブルRecGoodsLkRowNo列初期化処理
            this.InitializeRecGoodsLkRowNoColumn();

            if (!changeRowCount)
            {
                // 削除した分だけ新規に行を追加する
                for (int i = 0; i < RecGoodsLkRowNoList.Count; i++)
                {
                    this.AddRecGoodsLkRow();
                }
            }
            this._recGoodsLkDataTable.EndLoadData();
        }

        /// <summary>
        /// データテーブルの行番号を初期化（再採番）します。
        /// </summary>
        public void InitializeRecGoodsLkRowNoColumn()
        {
            this._recGoodsLkDataTable.BeginLoadData();
            for (int i = 0; i < this._recGoodsLkDataTable.Rows.Count; i++)
            {
                int oldRecGoodsLkRowNo = this._recGoodsLkDataTable[i].RowNo;
                this._recGoodsLkDataTable[i].RowNo = i + 1;
            }
            this._recGoodsLkDataTable.EndLoadData();
        }


        # endregion



        # region ●切り取り処理
        /// <summary>
        /// 切り取りボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_RowCut_Click(object sender, EventArgs e)
        {
            this._recGoodsLkDataTable.AcceptChanges();

            // 選択済み行番号リスト取得処理
            List<int> selectedrecGoodsLkRowNoList = this.GetSelectedrecGoodsLkRowNoList();
            if (selectedrecGoodsLkRowNoList == null) return;

            // データテーブルRowStatus列初期化処理
            this.InitializeRecGoodsLkRowStatusColumn();

            // データテーブルRowStatus列値設定処理
            this.SetRecGoodsLkRowStatusColumn(selectedrecGoodsLkRowNoList, ctROWSTATUS_CUT);

            // 明細グリッドセル設定処理
            this.SettingGrid();
            //this.InitialSettingGridCol();

            // 次入力可能セル移動処理
            this.MoveNextAllowEditCell(true);

        }
        # endregion


        # region ●挿入処理
        /// <summary>
        /// 挿入ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_RowInsert_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
            }
            this._recGoodsLkDataTable.AcceptChanges();

            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            string message;
            bool judge = this.InsertRecGoodsLkRowCheck(out message);
            if (!judge)
            {
                TMsgDisp.Show(
                     this,
                     emErrorLevel.ERR_LEVEL_INFO,
                     this.Name,
                     message,
                     0,
                     MessageBoxButtons.OK);

                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 明細行挿入処理
                this.InsertRecGoodsLkRow(rowIndex);

                // 明細グリッドセル設定処理
                this.SettingGrid();
                //this.InitialSettingGridCol();

                // 次入力可能セル移動処理
                this.MoveNextAllowEditCell(true);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            if (this.uGrid_Details.ActiveCell != null)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }
        }

        /// <summary>
        /// 明細行オブジェクトの挿入を行います。
        /// </summary>
        /// <param name="insertIndex">挿入行Index</param>
        public void InsertRecGoodsLkRow(int insertIndex)
        {
            this.InsertRecGoodsLkRow(insertIndex, 1);
        }

        /// <summary>
        /// 明細行オブジェクトの挿入を行います。（オーバーロード）
        /// </summary>
        /// <param name="insertIndex">挿入行Index</param>
        /// <param name="line">挿入段数</param>
        public void InsertRecGoodsLkRow(int insertIndex, int line)
        {
            if (line == 0) return;

            this._recGoodsLkDataTable.BeginLoadData();

            //挿入前に1行新規行を追加する
            RecGoodsLkDataSet.RecGoodsLkRow newRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
            newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
            newRow.FilterGuid = Guid.Empty;
            newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
            newRow.InqOtherEpCd = this._enterpriseCode;
            //newRow.InqOtherSecCd = this._loginSectionCode;
            this._recGoodsLkDataTable.AddRecGoodsLkRow(newRow);

            int lastRowIndex = this._recGoodsLkDataTable.Rows.Count - 1;
            int RecGoodsLkRowNo = this._recGoodsLkDataTable[insertIndex].RowNo;

            // 最終行から挿入対象行までの行情報を指定段ずつ下にコピーする
            for (int i = lastRowIndex; i >= insertIndex; i--)
            {
                if ((i + line) < this._recGoodsLkDataTable.Rows.Count)
                {
                    // --- UPD 2015/02/12 T.Nishi ------------------------------>>>>>
                    //RecGoodsLkDataSet.RecGoodsLkRow sourceRow = this.GetRecGoodsLkRow(this._recGoodsLkDataTable[i].RowNo);
                    //RecGoodsLkDataSet.RecGoodsLkRow targetRow = this.GetRecGoodsLkRow(this._recGoodsLkDataTable[i + line].RowNo);
                    RecGoodsLkDataSet.RecGoodsLkRow sourceRow = this.GetRecGoodsLkRow(int.Parse(this.uGrid_Details.Rows[i].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString()));
                    RecGoodsLkDataSet.RecGoodsLkRow targetRow = this.GetRecGoodsLkRow(int.Parse(this.uGrid_Details.Rows[i + line].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString()));
                    // --- UPD 2015/02/12 T.Nishi ------------------------------<<<<<

                    this.CopyRecGoodsLkRow(sourceRow, targetRow);
                }
            }

            // 挿入対象行をクリアする
            // --- UPD 2015/02/12 T.Nishi ------------------------------>>>>>
            //RecGoodsLkDataSet.RecGoodsLkRow clearRow = this.GetRecGoodsLkRow(this._recGoodsLkDataTable[insertIndex].RowNo);
            RecGoodsLkDataSet.RecGoodsLkRow clearRow = this.GetRecGoodsLkRow(int.Parse(this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString()));
            // --- UPD 2015/02/12 T.Nishi ------------------------------<<<<<
            this.ClearRecGoodsLkRow(clearRow);
            // --- ADD 2015/03/05 Y.Wakita Redmine#330 ---------->>>>>
            clearRow.InqOtherEpCd = this._enterpriseCode;
            // --- ADD 2015/03/05 Y.Wakita Redmine#330 ----------<<<<<
            // クリア行の入力モードを変更する。
            if (!Guid.Empty.Equals(clearRow.FilterGuid))
            {
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.NoEdit;
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.NoEdit;

                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Appearance.BackColor = ct_READONLY_CELL_COLOR;
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
            }
            else
            {
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.AllowEdit;

                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Appearance.BackColor = Color.Empty;
                this.uGrid_Details.Rows[insertIndex].Cells[this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
            }

            this._recGoodsLkDataTable.EndLoadData();
        }

        /// <summary>
        /// 明細行に行挿入可能かどうかチェックします。
        /// </summary>
        /// <param name="message"></param>
        /// <returns>true:挿入可能 false:挿入不可</returns>
        public bool InsertRecGoodsLkRowCheck(out string message)
        {
            message = string.Empty;
            RecGoodsLkDataSet.RecGoodsLkRow row = (RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkDataTable.Rows[this._recGoodsLkDataTable.Rows.Count - 1];

            if (row != null)
            {
                //if (this.ExistRecGoodsLkInput(row))
                //{
                //    message = "最終行が入力済みの為、行挿入できません。";
                //    return false;
                //}
            }
            return true;
        }

        /// <summary>
        /// 明細行オブジェクトのコピーを行います。
        /// </summary>
        /// <param name="sourceRow">コピー元明細行オブジェクト</param>
        /// <param name="targetRow">コピー先明細行オブジェクト</param>
        private void CopyRecGoodsLkRow(RecGoodsLkDataSet.RecGoodsLkRow sourceRow, RecGoodsLkDataSet.RecGoodsLkRow targetRow)
        {
            if ((sourceRow == null) || (targetRow == null)) return;

            #region ●項目セット

            targetRow.InqOriginalEpCd = sourceRow.InqOriginalEpCd;              // 問合せ元企業コード
            targetRow.InqOriginalSecCd = sourceRow.InqOriginalSecCd;            // 問合せ元拠点コード
            targetRow.InqOtherEpCd = sourceRow.InqOtherEpCd;                    // 問合せ先企業コード
            targetRow.InqOtherSecCd = sourceRow.InqOtherSecCd;                  // 問合せ先拠点コード
            targetRow.InqOtherSecNm = sourceRow.InqOtherSecNm;                  // 問合せ先拠点名
            targetRow.CustomerCode = sourceRow.CustomerCode;                    // 得意先コード
            targetRow.CustomerSnm = sourceRow.CustomerSnm;                      // 得意先名
            targetRow.RecDestBLGoodsCd = sourceRow.RecDestBLGoodsCd;            // 推奨元BL商品コード
            targetRow.RecDestBLGoodsNm = sourceRow.RecDestBLGoodsNm;            // 推奨元BL商品コード名称
            targetRow.RecSourceBLGoodsCd = sourceRow.RecSourceBLGoodsCd;        // 推奨先BL商品コード
            targetRow.RecSourceBLGoodsNm = sourceRow.RecSourceBLGoodsNm;        // 推奨先BL商品コード名称
            targetRow.GoodsComment = sourceRow.GoodsComment;                    // 商品コメント
            targetRow.FilterGuid = sourceRow.FilterGuid;
            targetRow.RowDeleteFlg = sourceRow.RowDeleteFlg;
            targetRow.UpdateTime = sourceRow.UpdateTime;

            // --- UPD 2015/03/06 T.Miyamoto Redmine#341 ------------------------------>>>>>
            //targetRow.RowStatus = ctROWSTATUS_NORMAL;
            targetRow.RowStatus = sourceRow.RowStatus;
            // --- UPD 2015/03/06 T.Miyamoto Redmine#341 ------------------------------<<<<<

            #endregion
        }
        /// <summary>
        /// 明細行オブジェクトのクリアを行います。（オーバーロード）
        /// </summary>
        /// <param name="row">明細行オブジェクト</param>
        private void ClearRecGoodsLkRow(RecGoodsLkDataSet.RecGoodsLkRow row)
        {
            if (row == null) return;

            #region ●項目クリア
            row.UpdateTime = string.Empty;          // 更新日付
            row.InqOriginalEpCd = string.Empty;     // 問合せ元企業コード
            row.InqOriginalSecCd = string.Empty;    // 問合せ元拠点コード
            row.InqOtherEpCd = string.Empty;        // 問合せ先企業コード
            row.InqOtherSecCd = string.Empty;       // 問合せ先拠点コード
            row.InqOtherSecNm = string.Empty;       // 問合せ先拠点名
            row.CustomerCode = string.Empty;        // 得意先コード
            row.CustomerSnm = string.Empty;         // 得意先名
            row.RecDestBLGoodsCd = 0;               // 推奨元BL商品コード
            row.RecDestBLGoodsNm = string.Empty;    // 推奨元BL商品コード名称
            row.RecSourceBLGoodsCd = 0;             // 推奨先BL商品コード
            row.RecSourceBLGoodsNm = string.Empty;  // 推奨先BL商品コード名称
            row.GoodsComment = string.Empty;        // 商品コメント
            row.RowDeleteFlg = 0;
            row.FilterGuid = Guid.Empty;

            row.RowStatus = ctROWSTATUS_NORMAL;

            #endregion
        }

        /// <summary>
        /// 明細行オブジェクトを複製します。
        /// </summary>
        /// <param name="sourceRow">明細行オブジェクト</param>
        /// <returns>複製後明細行オブジェクト</returns>
        private RecGoodsLkDataSet.RecGoodsLkRow CloneRecGoodsLkRow(RecGoodsLkDataSet.RecGoodsLkRow sourceRow)
        {
            RecGoodsLkDataSet.RecGoodsLkRow targetRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();

            #region ●項目セット

            targetRow.InqOriginalEpCd = sourceRow.InqOriginalEpCd;              // 問合せ元企業コード
            targetRow.InqOriginalSecCd = sourceRow.InqOriginalSecCd;            // 問合せ元拠点コード
            targetRow.InqOtherEpCd = sourceRow.InqOtherEpCd;                    // 問合せ先企業コード
            targetRow.InqOtherSecCd = sourceRow.InqOtherSecCd;                  // 問合せ先拠点コード
            targetRow.InqOtherSecNm = sourceRow.InqOtherSecNm;                  // 問合せ先拠点名
            targetRow.CustomerCode = sourceRow.CustomerCode;                    // 得意先コード
            targetRow.CustomerSnm = sourceRow.CustomerSnm;                      // 得意先名
            targetRow.RecDestBLGoodsCd = sourceRow.RecDestBLGoodsCd;            // 推奨元BL商品コード
            targetRow.RecDestBLGoodsNm = sourceRow.RecDestBLGoodsNm;            // 推奨元BL商品コード名称
            targetRow.RecSourceBLGoodsCd = sourceRow.RecSourceBLGoodsCd;        // 推奨先BL商品コード
            targetRow.RecSourceBLGoodsNm = sourceRow.RecSourceBLGoodsNm;        // 推奨先BL商品コード名称
            targetRow.GoodsComment = sourceRow.GoodsComment;                    // 商品コメント
            targetRow.FilterGuid = sourceRow.FilterGuid;
            targetRow.RowDeleteFlg = sourceRow.RowDeleteFlg;
            targetRow.UpdateTime = sourceRow.UpdateTime;

            targetRow.RowStatus = ctROWSTATUS_NORMAL;

            #endregion

            return targetRow;
        }

        # endregion
        /// <summary>
        /// 明細グリッド設定処理
        /// </summary>
        internal void SettingGrid()
        {
            try
            {
                // 描画を一時停止
                this.uGrid_Details.BeginUpdate();

                // 描画が必要な明細件数を取得する。
                int cnt = this._recGoodsLkDataTable.Count;

                // 各行ごとの設定
                for (int i = 0; i < cnt; i++)
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
        /// <param name="stockSlip">データクラスオブジェクト</param>
        /// <remarks>
        /// <br>Update Note : 2012/10/15 田建委</br>
        /// <br>管理番号    : 10801804-00、2012/11/14配信分</br>
        /// <br>              Redmine#32862 価格変更した明細、色を変えるように修正</br>
        /// </remarks>
        private void SettingGridRow(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // 行ステータスを取得
            // --- UPD 2015/02/12 T.Nishi ------------------------------>>>>>
            //int rowStatus = this._recGoodsLkDataTable[rowIndex].RowStatus;
            RecGoodsLkDataSet.RecGoodsLkRow targetRow = this.GetRecGoodsLkRow(int.Parse(this.uGrid_Details.Rows[rowIndex].Cells[this._recGoodsLkDataTable.RowNoColumn.ColumnName].Value.ToString()));
            int rowStatus = targetRow.RowStatus;
            // 行Guidを取得
            Guid filterGuid = targetRow.FilterGuid;
            // --- UPD 2015/02/12 T.Nishi ------------------------------<<<<<
            
            // 指定行の全ての列に対して設定を行う。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // セル情報を取得
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];

                if (cell == null) continue;

                cell.Row.Hidden = false;

                // アンダーラインを全てのセルに対して非表示とする
                cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;

                if (cell.Column.Key == this._recGoodsLkDataTable.RowNoColumn.ColumnName) // ADD 2015/02/10 行色 T.Miyamoto
                {
                    if (rowStatus == ctROWSTATUS_COPY)
                    {
                        // --- UPD 2015/03/05 Y.Wakita Redmine#333 ---------->>>>>
                        //cell.Appearance.BackColor = Color.Pink;
                        //cell.Appearance.BackColor2 = Color.Pink;
                        //cell.Appearance.BackColorDisabled = Color.Pink;
                        //cell.Appearance.BackColorDisabled2 = Color.Pink;
                        //cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                        cell.Appearance.BackColor = Color.Orange;
                        cell.Appearance.BackColor2 = Color.Orange;
                        cell.Appearance.BackColorDisabled = Color.Orange;
                        cell.Appearance.BackColorDisabled2 = Color.Orange;
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                        // --- UPD 2015/03/05 Y.Wakita Redmine#333 ----------<<<<<

                        //cell.Activation = Activation.NoEdit;

                    }
                    else if (rowStatus == ctROWSTATUS_CUT)
                    {
                        cell.Appearance.BackColor = Color.Pink;
                        cell.Appearance.BackColor2 = Color.Pink;
                        cell.Appearance.BackColorDisabled = Color.Pink;
                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;

                        //cell.Activation = Activation.NoEdit;
                    }
                    // --- ADD 2015/03/06 T.Miyamoto Redmine#341 ------------------------------>>>>>
                    else if (targetRow.RowDeleteFlg == 1)
                    {
                        cell.Appearance.BackColor = Color.Pink;
                        cell.Appearance.BackColor2 = Color.Pink;
                        cell.Appearance.BackColorDisabled = Color.Pink;
                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                    }
                    // --- ADD 2015/03/06 T.Miyamoto Redmine#341 ------------------------------<<<<<
                    else
                    {
                        // --- DEL 2015/03/06 T.Miyamoto Redmine#341 ------------------------------>>>>>
                        //// --- ADD 2015/03/05 Y.Wakita Redmine#333 ---------->>>>>
                        //if (cell.Appearance.BackColor != Color.Orange) continue;
                        //// --- ADD 2015/03/05 Y.Wakita Redmine#333 ----------<<<<<
                        // --- DEL 2015/03/06 T.Miyamoto Redmine#341 ------------------------------<<<<<
                        cell.Appearance.BackColor = Color.Empty;
                        cell.Appearance.BackColor2 = Color.Empty;
                        cell.Appearance.BackColorDisabled = Color.Empty;
                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                    }
                }
                else if (cell.Column.Key == this._recGoodsLkDataTable.CustomerCodeColumn.ColumnName
                    || cell.Column.Key == this._recGoodsLkDataTable.InqOtherSecCdColumn.ColumnName) // 2015/02/12
                {
                        // クリア行の入力モードを変更する。
                        if (!Guid.Empty.Equals(filterGuid))
                        {
                            cell.Activation = Activation.NoEdit;
                        }
                        else
                        {
                            cell.Activation = Activation.AllowEdit;
                        }
                }
                // --- ADD 2015/03/09 T.Miyamoto Redmine#341 ------------------------------>>>>>
                else if (cell.Column.Key == this._recGoodsLkDataTable.RecSourceBLGoodsCdColumn.ColumnName
                 || cell.Column.Key == this._recGoodsLkDataTable.RecDestBLGoodsCdColumn.ColumnName
                 || cell.Column.Key == this._recGoodsLkDataTable.GoodsCommentColumn.ColumnName)
                {
                    if (targetRow.RowDeleteFlg == 1)
                    {
                        cell.Activation = Activation.NoEdit;
                    }
                    else
                    {
                        cell.Activation = Activation.AllowEdit;
                    }
                }
                // --- UPD 2015/03/09 T.Miyamoto Redmine#341 ------------------------------<<<<<
            }
        }


        /// <summary>
        /// MouseClickイベント
        /// </summary>
        /// <returns></returns>
        private void uGrid_Details_MouseClick(object sender, MouseEventArgs e)
        {
            // 右クリック以外の場合
            if (e.Button != MouseButtons.Right) return;

            System.Drawing.Point nowPos = new Point(e.X, e.Y);

            Infragistics.Win.UIElement objElement = this.uGrid_Details.DisplayLayout.UIElement.ElementFromPoint(nowPos);

            // クリック位置が列ヘッダーか判定
            bool isColumnHeader = false;

            if (objElement != null)
            {
                if ((objElement.SelectableItem is Infragistics.Win.UltraWinGrid.ColumnHeader) ||
                    (objElement is Infragistics.Win.UltraWinGrid.HeaderUIElement))
                {
                    isColumnHeader = true;
                    // string columnName = ((Infragistics.Win.UltraWinGrid.ColumnHeader)objElement.SelectableItem).Column.Key;
                }
            }

            if (isColumnHeader)
            {
                // 列ヘッダー右クリック時は何もしない
            }
            else
            {
                // それ以外で右クリックされた場合は、編集のポップアップを表示する
                ((Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_MainMenu.Tools["PopupMenuTool_Edit"]).ShowPopup(System.Windows.Forms.Cursor.Position, this.uGrid_Details);

                if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow != null))
                {
                    if (this.uGrid_Details.ActiveRow.Selected)
                    {
                        //
                    }
                    else
                    {
                        this.uGrid_Details.Selected.Rows.Clear();
                        this.uGrid_Details.ActiveRow.Selected = true;
                    }
                }
            }

        }

        private void uButton_RowInsert_Click_1(object sender, EventArgs e)
        {

            MessageBox.Show("1");
        }

        private void uButton_RowInsert_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("");
        }
    }
    // --- ADD 2015/02/09 T.Nishi ------------------------------<<<<<


    /// <summary>
    /// リコメンド商品関連設定マスタ用グリッド設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : リコメンド商品関連設定マスタ用グリッド設定クラス</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RecGoodsLkUserSet
    {
        // 出力形式
        private int _outputStyle;

        // 明細グリッドカラムリスト
        private List<ColumnInfo> _detailColumnsList;

        // 明細グリッド自動サイズ調整
        private bool _autoAdjustDetail;

        # region コンストラクタ
        /// <summary>
        /// リコメンド商品関連設定マスタ用グリッド設定クラス
        /// </summary>
        public RecGoodsLkUserSet()
        {

        }
        # endregion

        /// <summary>出力型式</summary>
        public int OutputStyle
        {
            get { return this._outputStyle; }
            set { this._outputStyle = value; }
        }

        /// <summary>明細グリッドカラムリスト</summary>
        public List<ColumnInfo> DetailColumnsList
        {
            get { return this._detailColumnsList; }
            set { this._detailColumnsList = value; }
        }

        /// <summary>明細グリッド自動サイズ調整</summary>
        public bool AutoAdjustDetail
        {
            get { return _autoAdjustDetail; }
            set { _autoAdjustDetail = value; }
        }
    }

    # region [ColumnInfo]
    /// <summary>
    /// ColumnInfo
    /// </summary>
    [Serializable]
    public struct ColumnInfo
    {
        /// <summary>列名</summary>
        private string _columnName;

        /// <summary>幅</summary>
        private int _width;

        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        /// <summary>
        /// 幅
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="width">幅</param>
        public ColumnInfo(string columnName, int width)
        {
            _columnName = columnName;
            _width = width;
        }
    }
    # endregion
}
