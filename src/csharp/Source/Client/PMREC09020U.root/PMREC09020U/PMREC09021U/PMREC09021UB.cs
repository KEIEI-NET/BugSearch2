//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買得商品設定マスタ
// プログラム概要   : お買得商品設定マスタを行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 作 成 日  2015/02/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/03  修正内容 : RedMine#309 品番入力後、別の品番を入力すると
//　　　　　　　　　　　　　　　　　　　　　　　「商品が存在しません」と出て変更できない
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/04  修正内容 : RedMine#319 売単価に掛率マスタの拠点ごとの設定が適用されない
//                                  RedMine#320 売単価にキャンペーンマスタの拠点ごとの設定が適用されない
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/10  修正内容 : RedMine#351 売単価の桁数に制限がかかっていない
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 小栗 大介
// 更 新 日  2015/03/13  修正内容 : 売単価を必須入力に変更
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/16  修正内容 : 障害 検索表示時に公開区分がOFFの場合、項目が非活性にならない
//                                       また行移動時も同様
//                                  要望 公開区分をOFFにした場合に非活性項目の値をクリアしない
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/23  修正内容 : 品証Redmine#3158 課題管理表№37
//                                  公開区分チェックをはずした状態であれば仮登録できるように対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/24  修正内容 : 品証Redmine#3093 課題管理表№35
//                                  メーカー希望価格・標準価格の再計算機能を実装する
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/25  修正内容 : メーカー価格取得方法修正
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/26  修正内容 : 品証Redmine#3247
//                                  PM商品マスタ(ユーザー登録)から取得したメーカー価格に対して離島設定が反映される
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本 利明
// 更 新 日  2015/03/31  修正内容 : システムテスト障害 №61
//                                  価格再取得後にプレビューを更新する
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/04/01  修正内容 : システムテスト障害 №63
//                                  公開区分チェックなしで保存する場合、メーカー価格が未設定のまま保存される
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/04/02  修正内容 : システムテスト障害 №65
//                                  価格再取得後に得意先個別設定を入力してもメーカー価格が変更前のまま
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/04/08  修正内容 : 品証Redmine#3452
//                                  行削除ボタン押下し再度行削除ボタンを押下した時に明細の表示色が元に戻らない
//                                  （全削除ボタン押下時も同様）
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Globalization; // 日付チェック
using System.Diagnostics;

using Infragistics.Win;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// お買得商品設定マスタ 明細コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : お買得商品設定マスタ 明細コントロールクラス</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2015/02/20</br>
    /// </remarks>
    public partial class PMREC09021UB : UserControl
    {
        # region Private Members
        private RecBgnGdsDataSet.RecBgnGdsDataTable _recBgnGdsDataTable;
        private RecBgnGdsDataSet.SecCusSetDataTable _secCusSetDataTable;
      
        private RecBgnGdsAcs _recBgnGdsAcs = null;
        private Calculator _calculator = null;

        private Dictionary<Guid, RecBgnGds> _prevRecBgnGdsDic = new Dictionary<Guid, RecBgnGds>();
        private ButtonTextCustomizableMessageBox _imageMsg = new ButtonTextCustomizableMessageBox();

        private static readonly Color ct_DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color ct_DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));

        private const string TOOLBAR_ROWDELETEBUTTON_KEY = "ButtonTool_RowDelete";						// 行削除
        private const string TOOLBAR_ALLDELETEBUTTON_KEY = "ButtonTool_AllRowDelete";					// 全削除
        private const string TOOLBAR_REVIVALBUTTON_KEY = "ButtonTool_Revival";						    // 復活
        private const string TOOLBAR_RECAPTUREBUTTON_KEY = "ButtonTool_Recapture";						// 価格再取得 // ADD 2015/03/24 Y.Wakita

        /// <summary>全社設定</summary>
        private const string ALL_SECTION_CODE = "00";
        private const string ALL_SECTION_NAME = "全社共通";

        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "PMREC09020U_Construction.XML";

        /// <summary>企業コード</summary>
        private string _enterpriseCode = string.Empty;
        private string _loginSectionCode = string.Empty;

        /// <summary>拠点コード</summary>
        private string _swSectionInfo = string.Empty;

        /// <summary>品番</summary>
        private string _swGoodsNo = string.Empty;

        /// <summary>得意先</summary>
        private string _swCustomerInfo = string.Empty;

        /// <summary>メーカーコード</summary>
        private int _swGoodsMakerCd = 0;

        /// <summary>お買得商品ｸﾞﾙｰﾌﾟコード</summary>
        private int _swBrgnGoodsGrpCode = 0;

        /// <summary>公開開始日</summary>
        private string _swApplyStaDate = string.Empty;

        /// <summary>公開終了日</summary>
        private string _swApplyEndDate = string.Empty;
        
        private CustomerSearchRet _customerSearchRet = null;

        /// <summary>DCKHN09092A)BLコード</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;

        /// <summary> SCM企業連結データアクセスクラス </summary>
        private ScmEpScCntAcs _scmEpScCntAcs;

        /// <summary> 拠点マスタリスト </summary>
        private List<SecInfoSet> _secInfoSetList;
        /// <summary> お買得商品グループ検索結果</summary>
        private RecBgnGrpRet _recBgnGrpRet = null;

        private bool focusFlg = true;
        private bool leftFocusFlg = false;

        private int _rowIndex = 0;

        // ユーザー設定
        private RecBgnGdsUserSet _userSetting;
        private SecInfoSetAcs _secInfoSetAcs;
        private MakerAcs _makerAcs;
        private BLGroupUAcs _blGroupUAcs;
        private UserGuideAcs _userGuideAcs;
        internal event SetGuidButtonEventHandler SetGuidButton;
        internal delegate void SetGuidButtonEventHandler(Boolean enable);

        internal event GetBaseInfoEventHandler GetBaseInfo;
        internal delegate void GetBaseInfoEventHandler(out string sectionCode, out string sectionName);

        internal event OpenGoodsImgFileEventHandler OpenGoodsImgFile;
        internal delegate void OpenGoodsImgFileEventHandler(out Byte[] dats);

        internal event GoodsInfoPreviewEventHandler GoodsInfoPreview;
        internal delegate void GoodsInfoPreviewEventHandler(int rowIndex);

        internal event PreviewColumnSyncEventHandler PreviewColumnSync;
        internal delegate void PreviewColumnSyncEventHandler(int rowIndex, string columnKeyName);

        internal event GoodsInfoPreviewClearEventHandler GoodsInfoPreviewClear;
        internal delegate void GoodsInfoPreviewClearEventHandler();

        /// <summary>フォーカスの変化</summary>
        internal event EventHandler GridKeyUpTopRow;

        /// <summary>設定XMLファイル名</summary>
        private const string GOODSIMG_FILE_TRUE = "有";
        #endregion

        #region プロパティ
        /// <summary>
        /// お買得商品設定マスタ アクセスクラスプロパティ
        /// </summary>
        public RecBgnGdsAcs RecBgnGdsAcs
        {
            get { return this._recBgnGdsAcs; }
        }

        /// <summary>
        /// お買得商品設定マスタ 価格算出アクセスクラスプロパティ
        /// </summary>
        public Calculator Calculator
        {
            get { return this._calculator; }
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
        public RecBgnGdsUserSet UserSetting
        {
            get { return this._userSetting; }
        }

        /// <summary>
        /// RowIndex
        /// </summary>
        public int RowIndex
        {
            get { return this._rowIndex; }
        }

        /// <summary>
        /// SetBrgnGoodsGrpCode
        /// </summary>
        public int SetBrgnGoodsGrpCode
        {
            set { this._swBrgnGoodsGrpCode = value; }
        }

        /// <summary>
        /// SetApplyStaDate
        /// </summary>
        public string SetApplyStaDate
        {
            set { this._swApplyStaDate = value; }
        }

        /// <summary>
        /// SetApplyEndDate
        /// </summary>
        public string SetApplyEndDate
        {
            set { this._swApplyEndDate = value; }
        }

        #endregion

        # region Constroctors
        /// <summary>
        /// 入力明細入力コントロールクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入力明細入力コントロールクラス デフォルトを行うコントロールクラスです。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public PMREC09021UB()
        {
            InitializeComponent();

            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._recBgnGdsAcs = new RecBgnGdsAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._makerAcs = new MakerAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._userSetting = new RecBgnGdsUserSet();
            this._scmEpScCntAcs = new ScmEpScCntAcs();
            this._secInfoSetList = new List<SecInfoSet>();
            this._secCusSetDataTable = new RecBgnGdsDataSet.SecCusSetDataTable();
            this._calculator = new Calculator();

            this._recBgnGdsDataTable = this._recBgnGdsAcs.RecBgnGdsDataTable;

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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void PMREC09021UB_Load(object sender, EventArgs e)
        {
            // データソースとしてデータビューを指定
            this.uGrid_Details.DataSource = this._recBgnGdsAcs.RecBgnGdsDataTable;

            // グリッドクリア
            this.Clear(false);

            #region 子画面用追加
            // 拠点情報のキャッシュ
            ArrayList list = new ArrayList();
            this._secInfoSetAcs.Search(out list, this._enterpriseCode);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetType().Equals(typeof(SecInfoSet)))
                {
                    this._secInfoSetList.Add((SecInfoSet)list[i]);
                }
            }
            #endregion
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note	   : フォームが読み込まれた時に発生します。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 行削除
                case TOOLBAR_ROWDELETEBUTTON_KEY:
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
                // --- ADD 2015/03/24 Y.Wakita ---------->>>>>
                // 価格再取得
                case TOOLBAR_RECAPTUREBUTTON_KEY:
                    {
                        this.uButton_Recapture_Click(sender, new EventArgs());
                        break;
                    }
                // --- ADD 2015/03/24 Y.Wakita ----------<<<<<
            }
        }

        /// <summary>
        /// 明細初期化イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note	   : 明細初期化イベントします。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
                        if ((int)row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                        {
                            //削除指定区分:0
                            if (this._recBgnGdsAcs.DeleteSearchMode == false)
                            {
                                //if (row.Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activation != Activation.NoEdit)
                                //{
                                //    // 未確定の新規行はクリアする
                                //    this.NewRowClear(this.uGrid_Details.ActiveRow.Index);
                                //    break;
                                //}
                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                                    this.SetGuidButton(false);
                                }

                                // 行削除時BackColorの設定(ピンク色)、入力許可設定
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Column.Key == this._recBgnGdsDataTable.RowNoColumn.ColumnName) // 色は行番号列のみ
                                    {
                                        cell.Appearance.BackColor = Color.Pink;
                                        cell.Appearance.BackColor2 = Color.Pink;
                                        cell.Appearance.BackColorDisabled = Color.Pink;
                                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                    cell.Activation = Activation.NoEdit;

                                    if (cell.Column.Key == this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName ||
                                        cell.Column.Key == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
                                    {
                                        cell.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                                    }
                                }
                                row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                            }
                            //削除指定区分:1
                            else
                            {
                                // 行削除時BackColorの設定(ピンク色)、入力許可設定
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Column.Key == this._recBgnGdsDataTable.RowNoColumn.ColumnName) // 色は行番号列のみ
                                    {
                                        cell.Appearance.BackColor = Color.Pink;
                                        cell.Appearance.BackColor2 = Color.Pink;
                                        cell.Appearance.BackColorDisabled = Color.Pink;
                                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                }
                                row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                            }
                        }
                        else
                        {
                            //削除指定区分:0
                            if (this._recBgnGdsAcs.DeleteSearchMode == false)
                            {
                                #region 行削除解除
                                // 新規行の判断
                                bool isNewRow = false;
                                if ((Guid)row.Cells[this._recBgnGdsDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                                {
                                    isNewRow = true;
                                }

                                #region 入力許可設定
                                row.Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Activation = Activation.AllowEdit;           // 品名
                                row.Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Activation = Activation.AllowEdit;        // 商品ｺﾒﾝﾄ
                                row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button; ;       // 商品イメージ
                                row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Activation = Activation.AllowEdit;                               // 商品イメージ
                                row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activation = Activation.AllowEdit;        // 公開開始日
                                row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Activation = Activation.AllowEdit;        // 公開終了日
                                row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Activation = Activation.AllowEdit;      // 公開区分
                                // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                                if (row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Text != "0")
                                {
                                    // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                                    row.Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.AllowEdit;    // お買得商品ｸﾞﾙｰﾌﾟ
                                    row.Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.AllowEdit;        // 売価率
                                    row.Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.AllowEdit;           // 売単価
                                    // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                                }
                                // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                                row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;   // 得意先別設定
                                row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Activation = Activation.AllowEdit;                          // 得意先別設定
                                if (isNewRow == true)
                                {
                                    row.Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.AllowEdit;   // 拠点
                                    row.Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Activation = Activation.AllowEdit;         // 品番
                                    row.Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;  // メーカー
                                }
                                #endregion

                                // 行削除解除時BackColorの設定(通常色)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Activation == Activation.NoEdit
                                     && cell.Column.Key != this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                                    {
                                        // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                                        if ((Guid)row.Cells[this._recBgnGdsDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                                        {
                                            // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                                            cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                            cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                            cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                            cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                            // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                                        }
                                        else
                                        {
                                            cell.Appearance.BackColor = ct_DISABLE_COLOR;
                                            cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                                            cell.Appearance.BackColorDisabled = ct_DISABLE_COLOR;
                                            cell.Appearance.BackColorDisabled2 = ct_DISABLE_COLOR;
                                        }
                                        // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                                    }
                                    else
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                    //cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }

                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    this.uGrid_Details.ActiveCell.Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    if ((this.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName)
                                     || (this.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName)
                                     || (this.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName))
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
                                row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
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
                                    cell.Appearance.ForeColor = Color.Empty;
                                    cell.Appearance.ForeColorDisabled = Color.Empty;
                                    if (cell.Column.Key == this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                                row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
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
        /// 新規行の行削除（クリア）
        /// </summary>
        private void NewRowClear(int ActiveRowIndex)
        {
            DialogResult dialogResult = TMsgDisp.Show(this
                                                     , emErrorLevel.ERR_LEVEL_QUESTION
                                                     , this.Name
                                                     , "明細をクリアしてもよろしいですか？"
                                                     , 0
                                                     , MessageBoxButtons.YesNo
                                                     , MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.Yes)
            {
                //行クリア
                RecBgnGdsDataSet.RecBgnGdsRow row = (RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsDataTable.Rows[ActiveRowIndex];
                this._recBgnGdsDataTable.Rows.Remove(row);
                this.NewRowAdd();
            }
        }


        /// <summary>
        /// 全削除処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 全削除処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
                if (this._recBgnGdsAcs.DeleteSearchMode == false)
                {
                    for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                    {
                        if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value == 0)
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
                            if ((Guid)row.Cells[this._recBgnGdsDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                            {
                                isNewRow = true;
                            }
                            // --- DEL 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                            //if (isNewRow == true)
                            //{
                            //    row.Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.AllowEdit;       // 拠点
                            //    row.Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Activation = Activation.AllowEdit;             // 品番
                            //    row.Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Activation = Activation.AllowEdit;           // 品名
                            //    row.Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;      // ﾒｰｶｰ
                            //    row.Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Activation = Activation.AllowEdit;        // 商品ｺﾒﾝﾄ
                            //    row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Activation = Activation.AllowEdit;       // 商品ｲﾒｰｼﾞﾀﾞﾐｰ
                            //    row.Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.AllowEdit;    // お買得商品ｸﾞﾙｰﾌﾟ
                            //    row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Activation = Activation.AllowEdit;      // 表示区分
                            //    row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activation = Activation.AllowEdit;        // 公開開始日
                            //    row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Activation = Activation.AllowEdit;        // 公開終了日
                            //    row.Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.AllowEdit;        // 売価率
                            //    row.Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.AllowEdit;           // 売単価
                            //}
                            // --- DEL 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                            // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                            row.Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Activation = Activation.AllowEdit;           // 品名
                            row.Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Activation = Activation.AllowEdit;        // 商品ｺﾒﾝﾄ
                            row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button; ;       // 商品イメージ
                            row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Activation = Activation.AllowEdit;                               // 商品イメージ
                            row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activation = Activation.AllowEdit;        // 公開開始日
                            row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Activation = Activation.AllowEdit;        // 公開終了日
                            row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Activation = Activation.AllowEdit;      // 公開区分
                            if (row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Text != "0")
                            {
                                row.Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.AllowEdit;    // お買得商品ｸﾞﾙｰﾌﾟ
                                row.Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.AllowEdit;        // 売価率
                                row.Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.AllowEdit;           // 売単価
                            }
                            row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;   // 得意先別設定
                            row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Activation = Activation.AllowEdit;                          // 得意先別設定
                            if (isNewRow == true)
                            {
                                row.Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activation = Activation.AllowEdit;   // 拠点
                                row.Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Activation = Activation.AllowEdit;         // 品番
                                row.Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Activation = Activation.AllowEdit;  // メーカー
                            }
                            // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                        }
                        #endregion

                        // 行削除解除時BackColorの設定(通常色)
                        foreach (UltraGridRow row in this.uGrid_Details.Rows)
                        {
                            if ((int)row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value == 1)
                            {
                                // 行削除解除時BackColorの設定(通常色)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    // --- DEL 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                                    //if (cell.Column.Key != this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                                    //{
                                    //    cell.Appearance.BackColor = ct_DISABLE_COLOR;
                                    //    cell.Appearance.BackColor2 = ct_DISABLE_COLOR;

                                    //    if (cell.Column.Key == this._recBgnGdsDataTable.GoodsNameColumn.ColumnName ||    //品名
                                    //        cell.Column.Key == this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName || //商品ｺﾒﾝﾄ
                                    //        cell.Column.Key == this._recBgnGdsDataTable.UnitPriceColumn.ColumnName)      //売単価
                                    //    {
                                    //        cell.Activation = Activation.AllowEdit;
                                    //        cell.Appearance.BackColor = Color.Empty;
                                    //        cell.Appearance.BackColor2 = Color.Empty;
                                    //        cell.Appearance.BackColorDisabled = Color.Empty;
                                    //        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    //        cell.Appearance.ForeColor = Color.Empty;
                                    //        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    //    }
                                    //}
                                    // --- DEL 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                                    // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                                    if (cell.Activation == Activation.NoEdit
                                     && cell.Column.Key != this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                                    {
                                        if ((Guid)row.Cells[this._recBgnGdsDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                                        {
                                            cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                            cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                            cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                            cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                        }
                                        else
                                        {
                                            cell.Appearance.BackColor = ct_DISABLE_COLOR;
                                            cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                                            cell.Appearance.BackColorDisabled = ct_DISABLE_COLOR;
                                            cell.Appearance.BackColorDisabled2 = ct_DISABLE_COLOR;
                                        }
                                    }
                                    // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                                    else
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                }
                            }

                            row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                        }
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        if (this.uGrid_Details.ActiveCell != null)
                        {
                            if (this.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName)
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
                            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                            {
                                // 行削除時BackColorの設定(ピンク色)、入力許可設定
                                foreach (UltraGridCell cell in this.uGrid_Details.Rows[rowIndex].Cells)
                                {
                                    if (cell.Column.Key == this._recBgnGdsDataTable.RowNoColumn.ColumnName) // 色は行番号列のみ
                                    {
                                        cell.Appearance.BackColor = Color.Pink;
                                        cell.Appearance.BackColor2 = Color.Pink;
                                        cell.Appearance.BackColorDisabled = Color.Pink;
                                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                    cell.Activation = Activation.NoEdit;

                                    // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
                                    if (cell.Column.Key == this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName ||
                                        cell.Column.Key == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
                                    {
                                        cell.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                                    }
                                    // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<
                                }
                            }

                            this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
                        }
                    }

                }
                //削除指定区分:1
                else
                {
                    for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                    {
                        if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
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
                            if ((int)row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value == 1)
                            {
                                // 行削除解除時BackColorの設定(通常色)
                                foreach (UltraGridCell cell in row.Cells)
                                {
                                    if (cell.Column.Key == this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                                    {
                                        cell.Appearance.BackColor = Color.Empty;
                                        cell.Appearance.BackColor2 = Color.Empty;
                                        cell.Appearance.BackColorDisabled = Color.Empty;
                                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                    else
                                    {
                                        cell.Appearance.BackColor = ct_DISABLE_COLOR;
                                        cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                                        cell.Appearance.BackColorDisabled = ct_DISABLE_COLOR;
                                        cell.Appearance.BackColorDisabled2 = ct_DISABLE_COLOR;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;

                                    cell.Activation = Activation.NoEdit;
                                }
                            }

                            row.Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
                        }
                    }
                    else
                    {
                        for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
                        {
                            if ((int)this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value != 1)
                            {
                                // 行削除時BackColorの設定(ピンク色)、入力許可設定
                                foreach (UltraGridCell cell in this.uGrid_Details.Rows[rowIndex].Cells)
                                {
                                    if (cell.Column.Key == this._recBgnGdsDataTable.RowNoColumn.ColumnName) // 色は行番号列のみ
                                    {
                                        cell.Appearance.BackColor = Color.Pink;
                                        cell.Appearance.BackColor2 = Color.Pink;
                                        cell.Appearance.BackColorDisabled = Color.Pink;
                                        cell.Appearance.BackColorDisabled2 = Color.Pink;
                                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                        cell.Appearance.ForeColor = Color.Empty;
                                        cell.Appearance.ForeColorDisabled = Color.Empty;
                                    }
                                    cell.Activation = Activation.NoEdit;
                                }
                            }

                            this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 1;
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
                        if ((int)this.uGrid_Details.Rows[row.Index].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value != 2)
                        {
                            //復活処理
                            foreach (UltraGridCell cell in this.uGrid_Details.Rows[row.Index].Cells)
                            {
                                if (cell.Column.Key == this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                                {
                                    cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColor2 = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColorDisabled = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackColorDisabled2 = ct_READONLY_CELL_COLOR;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                    cell.Appearance.ForeColor = ct_DISABLE_FONT_COLOR;
                                    cell.Appearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;
                                }
                            }

                            this.uGrid_Details.Rows[row.Index].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 2;
                        }
                        else
                        {
                            //復活解除処理
                            foreach (UltraGridCell cell in this.uGrid_Details.Rows[row.Index].Cells)
                            {
                                if (cell.Column.Key == this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                                {
                                    cell.Appearance.BackColor = Color.Empty;
                                    cell.Appearance.BackColor2 = Color.Empty;
                                    cell.Appearance.BackColorDisabled = Color.Empty;
                                    cell.Appearance.BackColorDisabled2 = Color.Empty;
                                    cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                                    cell.Appearance.ForeColor = Color.Empty;
                                    cell.Appearance.ForeColorDisabled = Color.Empty;
                                }
                            }

                            this.uGrid_Details.Rows[row.Index].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value = 0;
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

        // --- ADD 2015/03/24 Y.Wakita ---------->>>>>
        /// <summary>
        /// 価格再取得処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 価格再取得処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/03/24 Y.Wakita</br>
        /// </remarks>
        private void uButton_Recapture_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            DialogResult dialogResult = TMsgDisp.Show(this
                                         , emErrorLevel.ERR_LEVEL_QUESTION
                                         , this.Name
                                         , "メーカー価格を再取得しますか？"
                                         , 0
                                         , MessageBoxButtons.YesNo
                                         , MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.No) return;

            SFCMN00299CA msgForm = new SFCMN00299CA();
            try
            {
                // 抽出中画面部品のインスタンスを作成
                msgForm.Title = "価格再取得";
                msgForm.Message = "価格再取得中です。";
                msgForm.DispCancelButton = false;
                msgForm.Show();

                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;

                GoodsUnitData goodsUnitData = new GoodsUnitData();
                // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                PartsInfoDataSet partsInfoDataSet = new PartsInfoDataSet();
                Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
                Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
                // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

                string msg = string.Empty;

                string goodsNo = string.Empty;
                int goodsMakerCd = 0;
                string applyStaDate = string.Empty;

                string sectionCode = string.Empty;  // 拠点
                int customerCode = 0;               // 得意先
                long mkrSuggestRtPric = 0;          // メーカー希望価格
                DateTime startTime;                 // 開始日
                long listPrice = 0;                 // 定価
                long unitPrice = 0;                 // 売価
                bool uPricDiv = false;              // ADD 2015/03/26 Y.Wakita

                this.uGrid_Details.BeginUpdate();

                foreach (RecBgnGdsDataSet.RecBgnGdsRow row in this._recBgnGdsDataTable.Rows)
                {
                    goodsNo = row.GoodsNo;
                    goodsMakerCd = row.GoodsMakerCode;
                    applyStaDate = row.ApplyStaDate;

                    if (goodsNo != string.Empty && goodsMakerCd != 0 && applyStaDate != string.Empty)
                    {
                        // 商品検索
                        // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                        //int status = this._recBgnGdsAcs.SearchPartsFromGoodsNo(goodsNo, goodsMakerCd, out goodsUnitData, out msg);
                        int status = this._recBgnGdsAcs.SearchPartsFromGoodsNo(goodsNo, goodsMakerCd, out goodsUnitData, out partsInfoDataSet, out mkrSuggestRtPricList, out mkrSuggestRtPricUList, out msg);
                        // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
                        if (goodsUnitData != null)
                        {
                            sectionCode = row.InqOtherSecCd;    // 拠点
                            customerCode = 0;   // 得意先
                            startTime = DateTime.Parse(applyStaDate);   // 開始日
                            mkrSuggestRtPric = 0;          // メーカー希望価格
                            listPrice = 0;                 // 定価
                            unitPrice = 0;                 // 売価

                            // 価格取得
                            Calculator.GetUnitPrice(customerCode
                                                  , goodsUnitData
                                                  , startTime
                                                  , sectionCode
                                                  , mkrSuggestRtPricList
                                                  , mkrSuggestRtPricUList
                                                  , out uPricDiv    // ADD 2015/03/26 Y.Wakita
                                                  , out mkrSuggestRtPric
                                                  , out listPrice
                                                  , out unitPrice);

                            // ﾒｰｶｰ希望小売価格
                            row.MkrSuggestRtPric = mkrSuggestRtPric;
                            // 定価
                            row.ListPrice = listPrice;

                            // --- ADD 2015/03/26 Y.Wakita ---------->>>>>
                            int retPartsFlag = 0;
                            status = this._recBgnGdsAcs.GetPartsArticleInfo(goodsUnitData, uPricDiv, out retPartsFlag);
                            row.ModelFitDiv = (short)retPartsFlag;     // 適合車種区分
                            // --- ADD 2015/03/26 Y.Wakita ----------<<<<<

                            row.RowDevelopFlg = 1;  // ADD 2015/04/01 Y.Wakita システムテスト障害 №63 

                            // --- ADD 2015/04/02 Y.Wakita システムテスト障害 №65 ---------->>>>>
                            row.goodsUnitData = goodsUnitData;
                            row.mkrSuggestRtPricList = mkrSuggestRtPricList;
                            row.mkrSuggestRtPricUList = mkrSuggestRtPricUList;
                            // --- ADD 2015/04/02 Y.Wakita システムテスト障害 №65 ----------<<<<<

                            #region 得意先別設定
                            // 得意先別設定
                            int rowNo = row.RowNo;

                            RecBgnGdsCustInfo recBgnGdsCustInfo = null;
                            if (this._recBgnGdsAcs.RecBgnGdsCustInfoDic.ContainsKey(rowNo))
                            {
                                recBgnGdsCustInfo = this._recBgnGdsAcs.RecBgnGdsCustInfoDic[rowNo];
                            }
                            if (recBgnGdsCustInfo != null)
                            {
                                foreach (RecBgnGdsDataSet.RecBgnCustRow RecBgnCustRow in recBgnGdsCustInfo.recBgnCust)
                                {
                                    sectionCode = RecBgnCustRow.MngSectionCode;                 // 拠点
                                    customerCode = int.Parse(RecBgnCustRow.CustomerCode);       // 得意先
                                    mkrSuggestRtPric = RecBgnCustRow.MkrSuggestRtPric;          // メーカー希望価格
                                    startTime = DateTime.Parse(RecBgnCustRow.ApplyStaDate);     // 開始日
                                    listPrice = 0;                                              // 定価
                                    unitPrice = 0;                                              // 売価

                                    // 取り直し
                                    this._calculator.GetUnitPrice(customerCode
                                                               , goodsUnitData
                                                               , startTime
                                                               , sectionCode
                                                               , mkrSuggestRtPricList
                                                               , mkrSuggestRtPricUList
                                                               , out uPricDiv   // ADD 2015/03/26 Y.Wakita
                                                               , out mkrSuggestRtPric
                                                               , out listPrice
                                                               , out unitPrice);

                                    RecBgnCustRow.MkrSuggestRtPric = mkrSuggestRtPric;  // メーカー希望価格
                                    RecBgnCustRow.ListPrice = listPrice;                // 定価
                                }
                            }
                            #endregion
                        }
                    }
                }
                this.uGrid_Details.EndUpdate();

                this.GoodsInfoPreview(this.uGrid_Details.ActiveRow.Index); // ADD 2015/03/31 T.Miyamoto システムテスト障害 №61
            }
            finally
            {
                msgForm.Dispose();
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;

                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "価格再取得が完了しました。",
                                -1,
                                MessageBoxButtons.OK);

                this.Cursor = Cursors.Default;

                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Recapture"].SharedProps.Enabled = true;
                this.uButton_Recapture.Enabled = true;

                this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        // --- ADD 2015/03/24 Y.Wakita ----------<<<<<

        /// <summary>
        /// セルのデータチェック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : セルのデータチェック処理。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // 数値項目の場合
                if ((this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int16)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // 未入力は0にする				
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        //if (this.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsDataTable.SalesPriceSetDivColumn.ColumnName)
                        //{
                        //    editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// 前回値をセット
                        //}
                        //else
                        //{
                        //    editorBase.Value = 0;				// 0をセット
                        //    this.uGrid_Details.ActiveCell.Value = 0;
                        //}
                    }
                    // 数値項目に「-」or「.」だけしか入ってなかったら駄目です				
                    else if ((editorBase.CurrentEditText.Trim() == "-")
                          || (editorBase.CurrentEditText.Trim() == ".")
                          || (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        //if (this.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsDataTable.SalesPriceSetDivColumn.ColumnName)
                        //{
                            editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// 前回値をセット
                        //}
                        //else
                        //{
                        //    editorBase.Value = 0;				// 0をセット
                        //    this.uGrid_Details.ActiveCell.Value = 0;
                        //}
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
                            //if (this.uGrid_Details.ActiveCell.Column.Key == this._recBgnGdsDataTable.SalesPriceSetDivColumn.ColumnName)
                            //{
                                editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// 前回値をセット
                            //}
                            //else
                            //{
                            //    editorBase.Value = 0;				// 0をセット
                            //    this.uGrid_Details.ActiveCell.Value = 0;
                            //}
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
        /// <br>Note        : グリッドセルアクティブ後発生イベント</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            this.SetGridGuid();

            UltraGridCell cell_RowNo = this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._recBgnGdsDataTable.RowNoColumn.ColumnName];
            UltraGridCell cell_RowDel = this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName];

            if (cell_RowDel.Text == "0")
            {
                cell_RowNo.Appearance.BackColor = Color.Orange;
                cell_RowNo.Appearance.BackColor2 = Color.Orange;
                cell_RowNo.Appearance.BackColorDisabled = Color.Orange;
                cell_RowNo.Appearance.BackColorDisabled2 = Color.Orange;
            }

            // --- ADD 2015/03/24 Y.Wakita ---------->>>>>
            if (this._recBgnGdsAcs.DeleteSearchMode == false)
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Recapture"].SharedProps.Enabled = true;
                this.uButton_Recapture.Enabled = true;
            }
            // --- ADD 2015/03/24 Y.Wakita ----------<<<<<
        }

        /// <summary>
        /// グリッドセルアクティブ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドセルアクティブ後発生イベント</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
        {
            // 部品情報プレビュー表示
            this.GoodsInfoPreview(this.uGrid_Details.ActiveRow.Index);

            this._rowIndex = this.uGrid_Details.ActiveRow.Index;
        }

        /// <summary>
        /// グリッドセル出る後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドセル出る後発生イベント</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                UltraGridCell cell = this.uGrid_Details.ActiveCell;
                UltraGridRow row = this.uGrid_Details.ActiveCell.Row;
                if (cell.Value == null)
                {
                    return;
                }

                // 拠点コード
                if (cell.Column.Key == this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName)
                {
                    string inputValue = "";
                    // 入力値を取得
                    inputValue = cell.Value.ToString().Trim();
                    if (!this.SectionCheck_Detail(inputValue, cell.Row.Index))
                    {
                        this.focusFlg = false;
                    }
                }
            }
        }

        /// <summary>
        /// グリッドセルアクティブ前発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドセルアクティブ前発生イベント</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;

            // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ---------->>>>>
            if ((int)this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName].Value == 1) return;
            // --- ADD 2015/04/08 Y.Wakita Redmine#3452 ----------<<<<<

            try
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                // その他 IMEを無効
                this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Off;

                if (cell.Column.Key == this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName)
                {
                    // 拠点
                    this._swSectionInfo = e.Cell.Value.ToString().Trim();
                }
                else if (cell.Column.Key == this._recBgnGdsDataTable.GoodsNoColumn.ColumnName)
                {
                    // 品番
                    this._swGoodsNo = e.Cell.Value.ToString().Trim();
                }
                else if (cell.Column.Key == this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName)
                {
                    // ﾒｰｶｰ
                    this._swGoodsMakerCd = (Int32)e.Cell.Value;
                }
                else if (cell.Column.Key == this._recBgnGdsDataTable.GoodsNameColumn.ColumnName)
                {
                    // 品名
                    // IMEをON
                    this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
                }
                else if (cell.Column.Key == this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName)
                {
                    // 商品コメント
                    // IMEをON
                    this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
                }
                else if (cell.Column.Key == this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
                {
                    // お買得商品ｸﾞﾙｰﾌﾟ
                    this._swBrgnGoodsGrpCode = (Int16)e.Cell.Value;
                }
                else if (cell.Column.Key == this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName)
                {
                    // 公開開始日
                    this._swApplyStaDate = e.Cell.Value.ToString();
                    if (e.Cell.Value.ToString() == string.Empty)
                    {
                        e.Cell.Value = DateTime.Now.ToString("yyyy/MM/dd");
                    }
                }
                else if (cell.Column.Key == this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName)
                {
                    // 公開終了日
                    this._swApplyEndDate = e.Cell.Value.ToString();
                    if (e.Cell.Value.ToString() == string.Empty)
                    {
                        e.Cell.Value = DateTime.Now.ToString("yyyy/MM/dd");
                    }
                }
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
		// ↓2015/03/02 Enter
        //private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        internal void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
		// ↑2015/03/02 Enter
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
            // 商品コメントセルでAlt＋Enterキー押下時に改行コードをセットする
            if (e.Alt && (e.KeyCode == Keys.Enter))
            {
                if (columnKey == this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName)
                {
                    string sVal = this.uGrid_Details.ActiveCell.Text;  //対象文字列
                    int iPos = this.uGrid_Details.ActiveCell.SelStart; //カーソル位置(改行コード挿入位置)
                    // 改行コード挿入
                    this.uGrid_Details.ActiveCell.Value = sVal.Substring(0, iPos)
                                                        + Environment.NewLine
                                                        + sVal.Substring(iPos, (this.uGrid_Details.ActiveCell.Text.Length - iPos));
                    // 改行した先頭にカーソル移動
                    this.uGrid_Details.ActiveCell.SelStart = iPos + Environment.NewLine.Length;
                }
            }

            //if (this.uGrid_Details.ActiveCell.IsInEditMode)
            //{
            //    if (e.KeyCode == Keys.Left && this.uGrid_Details.ActiveCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox)
            //    {
            //        return;
            //    }
            //    if (e.KeyCode == Keys.Left && this.uGrid_Details.ActiveCell.SelStart != 0)
            //    {
            //        return;
            //    }
            //    if (e.KeyCode == Keys.Right && this.uGrid_Details.ActiveCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox)
            //    {
            //        return;
            //    }
            //    if (e.KeyCode == Keys.Right && this.uGrid_Details.ActiveCell.SelStart < this.uGrid_Details.ActiveCell.Text.Length)
            //    {
            //        return;
            //    }
            //    if (e.KeyCode == Keys.Up && this.uGrid_Details.ActiveCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox)
            //    {
            //        return;
            //    }
            //    if (e.KeyCode == Keys.Up && this.uGrid_Details.ActiveCell.SelStart > 0)
            //    {
            //        string sChkVal = this.uGrid_Details.ActiveCell.Text;
            //        sChkVal = sChkVal.Substring(0, this.uGrid_Details.ActiveCell.SelStart); //カーソル位置までの文字列
            //        if (sChkVal.IndexOf(Environment.NewLine) >= 0)
            //        {
            //            // ↑キー押下時にカーソル位置の前で改行されている場合は制御対象外
            //            return;
            //        }
            //    }
            //    if (e.KeyCode == Keys.Down && this.uGrid_Details.ActiveCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox)
            //    {
            //        return;
            //    }
            //    if (e.KeyCode == Keys.Down && this.uGrid_Details.ActiveCell.SelStart < this.uGrid_Details.ActiveCell.Text.Length)
            //    {
            //        string sChkVal = this.uGrid_Details.ActiveCell.Text;
            //        sChkVal = sChkVal.Substring(this.uGrid_Details.ActiveCell.SelStart, (sChkVal.Length - this.uGrid_Details.ActiveCell.SelStart)); //カーソル位置までの文字列
            //        if (sChkVal.IndexOf(Environment.NewLine) >= 0)
            //        {
            //            // ↓キー押下時にカーソル位置の後で改行されている場合は制御対象外
            //            return;
            //        }
            //    }
            //}

            switch (e.KeyCode)
            {
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
                                if (this._recBgnGdsAcs.DeleteSearchMode == false)
                                {
                                    if (CheckDateForDown())
                                    {
                                        #region 最終行の場合、新規行を追加する
                                        this.NewRowAdd();
                                        #endregion
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

                        // 拠点の場合
                        if ((columnKey == this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName)
                          ||(columnKey == this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName))
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
                                    columnName = this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName;
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

                        if (columnKey == this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName)
                        {
                            // なし。
                        }
                        else if (columnKey == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
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
                                        columnName = this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName;
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
                // --- ADD 2015/03/04 CellButtonKeyDown ------------------------------>>>>>
                case Keys.Space:
                    {
                        if (columnKey == this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName)
                        {
                            // 商品イメージ
                            Byte[] dats = new byte[0];
                            if (this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value.ToString().Trim().Length != 0)
                                dats = (Byte[])this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value;

                            this.OpenGoodsImgFile(out dats);

                            if (dats != null)
                            {
                                this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value = dats;

                                // 部品情報プレビュー表示
                                this.GoodsInfoPreview(this.uGrid_Details.ActiveRow.Index);
                                this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Value = GOODSIMG_FILE_TRUE;
                            }
                        }
                        else if (columnKey == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
                        {
                            // 得意先個別設定画面呼び出し
                            //this.OpenRecBgnCustDialog(e.Cell.Row.Index);
                            this.OpenRecBgnCustDialog(rowIndex);
                        }
                        break;
                    }
                // --- ADD 2015/03/04 CellButtonKeyDown ------------------------------<<<<<
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

            int colCount = 5;
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
        /// <br>Note        : グリッドセルアプデト後発生イベント</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;
            UltraGridRow row = e.Cell.Row;
            try
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                this.uGrid_Details.CellChange -= this.uGrid_Details_CellChange;

                string ErrMsg = string.Empty;
                string PriceClearMsg = "価格設定";
                string CustClearMsg = "得意先別設定";

                string applyStaDate = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Text;
                string recBgnCust = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Text;

                #region 品番
                // 品番
                if (cell.Column.Key == this._recBgnGdsDataTable.GoodsNoColumn.ColumnName)
                {
                    string goodsNo = cell.Value.ToString();
                    int goodsMakerCd = (int)this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value;

                    // --- ADD 2015/03/03 Y.Wakita Redmine#309 ---------->>>>>
                    goodsMakerCd = 0;
                    // --- ADD 2015/03/03 Y.Wakita Redmine#309 ----------<<<<<
                    if (!String.IsNullOrEmpty(goodsNo))
                    {
                        if (!this._swGoodsNo.Equals(goodsNo))
                        {
// --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                            //if ((this._swGoodsNo != string.Empty)
                            // && (this._swGoodsMakerCd != 0)
                            // && (this._swApplyStaDate != string.Empty))
                            if (((this._swGoodsNo != string.Empty)
                             && (this._swGoodsMakerCd != 0)
                             && (this._swApplyStaDate != string.Empty))
                             && (this._swGoodsNo != goodsNo))
// --- UPD 2015/03/25 Y.Wakita ----------<<<<<
                            {
                                if (applyStaDate != string.Empty)
                                {
                                    ErrMsg += PriceClearMsg;
                                }
                                if (recBgnCust != string.Empty)
                                {
                                    if (ErrMsg != string.Empty)
                                    {
                                        ErrMsg += "、";
                                    }
                                    ErrMsg += CustClearMsg;
                                }

                                if (ErrMsg != string.Empty)
                                {
                                    DialogResult dialogResult = TMsgDisp.Show(this
                                         , emErrorLevel.ERR_LEVEL_QUESTION
                                         , this.Name
                                         , ErrMsg + "をクリアします。" + "\r\n" + "\r\n" +
                                           "よろしいですか？"
                                         , 0
                                         , MessageBoxButtons.YesNo
                                         , MessageBoxDefaultButton.Button1);

                                    if (dialogResult == DialogResult.No)
                                    {
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value = this._swGoodsNo;
                                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        //this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                                        return;
                                    }
                                }
                            }

                            GoodsUnitData goodsUnitData = new GoodsUnitData();
                            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                            PartsInfoDataSet partsInfoDataSet = new PartsInfoDataSet();
                            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
                            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
                            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

                            string msg = string.Empty;

                            // 商品検索
                            // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                            //int status = this._recBgnGdsAcs.SearchPartsFromGoodsNo(cell.Value.ToString().Trim(), goodsMakerCd, out goodsUnitData, out msg);
                            int status = this._recBgnGdsAcs.SearchPartsFromGoodsNo(cell.Value.ToString().Trim(), goodsMakerCd, out goodsUnitData, out partsInfoDataSet, out mkrSuggestRtPricList, out mkrSuggestRtPricUList, out msg);
                            // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
                            if (goodsUnitData != null)
                            {
                                if (goodsUnitData.LogicalDeleteCode == 0)
                                {
                                    this._swGoodsNo = goodsUnitData.GoodsNo;
                                    this._swGoodsMakerCd = goodsUnitData.GoodsMakerCd;

                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value = goodsUnitData.GoodsMakerCd;
                                    MakerUMnt makerUMnt = null;
                                    try
                                    {
                                        makerUMnt = this._recBgnGdsAcs.MakerUMntDic[goodsUnitData.GoodsMakerCd];
                                    }
                                    catch
                                    {
                                    }
                                    finally
                                    {
                                        if (makerUMnt != null)
                                        {
                                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerKanaName; 
                                        }
                                    }
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value = goodsUnitData.GoodsNo;           // 品番
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Value = goodsUnitData.GoodsNameKana;   // 品名
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BLGoodsCodeColumn.ColumnName].Value = goodsUnitData.BLGoodsCode;   // BL商品ｺｰﾄﾞ
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BLGroupCodeColumn.ColumnName].Value = goodsUnitData.BLGroupCode;   // BLｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                    // --- DEL 2015/03/26 Y.Wakita ---------->>>>>
                                    //int retPartsFlag = 0;
                                    //status = this._recBgnGdsAcs.GetPartsArticleInfo(goodsUnitData, out retPartsFlag);
                                    //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ModelFitDivColumn.ColumnName].Value = retPartsFlag;                // 適合車種区分
                                    // --- DEL 2015/03/26 Y.Wakita ----------<<<<<

                                    int nIndex = cell.Row.Index;
                                    for (int iRowNo = this.uGrid_Details.Rows.Count - 1; 0 < iRowNo; iRowNo--)
                                    {
                                        int sIndex = iRowNo - 1;
                                        if ((this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString() ==
                                             this.uGrid_Details.Rows[sIndex].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString())
                                        &&  (this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value.ToString() ==
                                             this.uGrid_Details.Rows[sIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value.ToString()))
                                        {
                                            // 商品名
                                            this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Value = this.uGrid_Details.Rows[sIndex].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Value;
                                            // 商品コメント
                                            this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Value = this.uGrid_Details.Rows[sIndex].Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Value;
                                            // 商品イメージ
                                            this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value = this.uGrid_Details.Rows[sIndex].Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value;
                                            this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Value = this.uGrid_Details.Rows[sIndex].Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Value;
                                            // お買得商品ｸﾞﾙｰﾌﾟ
                                            this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = this.uGrid_Details.Rows[sIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value;
                                            this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = this.uGrid_Details.Rows[sIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value;
                                            break;
                                        }
                                    }

                                    // 商品情報
                                    this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.goodsUnitDataColumn.ColumnName].Value = goodsUnitData;
                                    // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                                    this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.mkrSuggestRtPricListColumn.ColumnName].Value = mkrSuggestRtPricList;
                                    this.uGrid_Details.Rows[nIndex].Cells[this._recBgnGdsDataTable.mkrSuggestRtPricUListColumn.ColumnName].Value = mkrSuggestRtPricUList;
                                    // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

                                    if (applyStaDate != string.Empty)
                                    {
                                        // 価格取得
                                        this.SetUnitPrice(cell.Row.Index);
                                    }

                                    if (recBgnCust != string.Empty)
                                    {
                                        // 得意先別設定削除
                                        this.DelRecBgnGdsCustInfo(cell.Row.Index);
                                    }

                                    // 在庫マスタチェック
                                    bool stockFlg = false;
                                    foreach (Stock stock in goodsUnitData.StockList)
                                    {
                                        if (stock.SupplierStock != 0)
                                        {
                                            stockFlg = true;
                                            break;
                                        }
                                    }

                                    if (!(stockFlg))
                                    {
                                        // 在庫マスタに存在しない、または在庫数がない場合
                                        DialogResult dialogResult = TMsgDisp.Show(this
                                                                     , emErrorLevel.ERR_LEVEL_QUESTION
                                                                     , this.Name
                                                                     , "在庫数量がありません。" + "\r\n" + "\r\n" +
                                                                       "在庫の登録を行いますか？"
                                                                     , 0
                                                                     , MessageBoxButtons.YesNo
                                                                     , MessageBoxDefaultButton.Button1);

                                        if (dialogResult == DialogResult.Yes)
                                        {
                                            // ユーザーデータ
                                            if (goodsUnitData.OfferKubun < 3)
                                            {
                                                // 論理削除されている在庫がある場合は取得
                                                TBOSearchUAcs _tboSearchAcs = new TBOSearchUAcs();
                                                List<Stock> stockList;
                                                if (_tboSearchAcs.GetStockList(out stockList, goodsUnitData.Clone()) == 0)
                                                {
                                                    goodsUnitData.StockList = new List<Stock>();
                                                    goodsUnitData.StockList = stockList;
                                                }
                                            }
                                            // 提供データ
                                            else
                                            {
                                                goodsUnitData.CreateDateTime = DateTime.Now;
                                                // 提供日付を削除
                                                goodsUnitData.OfferDate = DateTime.MinValue;
                                                if (goodsUnitData.GoodsPriceList != null)
                                                {
                                                    foreach (GoodsPrice price in goodsUnitData.GoodsPriceList)
                                                    {
                                                        price.OfferDate = DateTime.MinValue;
                                                    }
                                                }
                                            }
                                            AllDefSet allDefSet = this._recBgnGdsAcs.AllDefSet;
                                            if (allDefSet != null && allDefSet.GoodsStockMSTBootDiv == 1)
                                            {
                                                //商品在庫マスタⅡを起動
                                                PMKHN09380UA goodsStockMaster = new PMKHN09380UA(this._recBgnGdsAcs.GoodsAcsClass);
                                                goodsStockMaster.ShowDialog(this, ref goodsUnitData);
                                            }
                                            else
                                            {
                                                //商品在庫マスタを起動
                                                MAKHN09280UA goodsStockMaster = new MAKHN09280UA(this._recBgnGdsAcs.GoodsAcsClass);
                                                goodsStockMaster.ShowDialog(this, ref goodsUnitData);
                                            }
                                        }
                                    }
                                }
                            }
                            else if (status == -1)
                            {
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value = string.Empty;        // 品番
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Value = string.Empty;      // 品名
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BLGoodsCodeColumn.ColumnName].Value = 0;               // BL商品ｺｰﾄﾞ
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BLGroupCodeColumn.ColumnName].Value = 0;               // BLｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ModelFitDivColumn.ColumnName].Value = 0;               // 適合車種区分
                                
                                this._swGoodsNo = string.Empty;
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                this.focusFlg = false;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "商品が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value = this._swGoodsNo;
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                this.focusFlg = false;
                            }
                        }
                    }
                    else
                    {
                        this._swGoodsNo = string.Empty;
                        //行クリア
                        RecBgnGdsDataSet.RecBgnGdsRow rowNo = (RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsDataTable.Rows[this.uGrid_Details.ActiveRow.Index];
                        //this._recBgnGdsDataTable.Rows.Remove(rowNo);
                        //this.NewRowAdd();

                        //RecBgnGdsDataSet.RecBgnGdsRow clearRow = this.GetRecBgnGdsRow(int.Parse(this._recBgnGdsDataTable.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Value.ToString()));
                        this.ClearRecBgnGdsRow(rowNo);
                        this.GoodsInfoPreviewClear();
                    }

                    this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion 
                #region 品名
                // 品名
                else if (cell.Column.Key == this._recBgnGdsDataTable.GoodsNameColumn.ColumnName)
                {
                    //なし。
                    this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion
                #region 商品イメージ
                // 商品イメージ
                else if (cell.Column.Key == this._recBgnGdsDataTable.GoodsImageColumn.ColumnName)
                {
                    this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion
                #region メーカー
                // ﾒｰｶｰ
                else if (cell.Column.Key == this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName)
                {
                    int inputValue = 0;
                    // 入力値を取得
                    Int32.TryParse(cell.Value.ToString(), out inputValue);

                    if (inputValue != 0)
                    {
                        MakerUMnt makerUMnt = null;
                        if (this._recBgnGdsAcs.MakerUMntDic.ContainsKey(inputValue))
                        {
                            makerUMnt = this._recBgnGdsAcs.MakerUMntDic[inputValue];
                        }

                        if (makerUMnt != null)
                        {
                            if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Text.Trim()))
                            {
// --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                                if ((this._swGoodsNo == this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Text.Trim())
                                 && (this._swGoodsMakerCd == inputValue))
                                {
                                    return;
                                }
// --- ADD 2015/03/25 Y.Wakita ----------<<<<<

// --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                                //if ((this._swGoodsNo != string.Empty)
                                // && (this._swGoodsMakerCd != 0)
                                // && (this._swApplyStaDate != string.Empty))
                                if (((this._swGoodsNo != string.Empty)
                                 && (this._swGoodsMakerCd != 0)
                                 && (this._swApplyStaDate != string.Empty))
                                 && (this._swGoodsMakerCd != inputValue))
// --- UPD 2015/03/25 Y.Wakita ----------<<<<<
                                {
                                    if (applyStaDate != string.Empty)
                                    {
                                        ErrMsg += PriceClearMsg;
                                    }
                                    if (recBgnCust != string.Empty)
                                    {
                                        if (ErrMsg != string.Empty)
                                        {
                                            ErrMsg += "、";
                                        }
                                        ErrMsg += CustClearMsg;
                                    }

                                    if (ErrMsg != string.Empty)
                                    {
                                        DialogResult dialogResult = TMsgDisp.Show(this
                                             , emErrorLevel.ERR_LEVEL_QUESTION
                                             , this.Name
                                             , ErrMsg + "をクリアします。" + "\r\n" + "\r\n" +
                                               "よろしいですか？"
                                             , 0
                                             , MessageBoxButtons.YesNo
                                             , MessageBoxDefaultButton.Button1);

                                        if (dialogResult == DialogResult.No)
                                        {
                                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value = this._swGoodsMakerCd;
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                            //this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                                            return;
                                        }
                                    }
                                }

                                GoodsUnitData goodsUnitData = new GoodsUnitData();
                                // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                                PartsInfoDataSet partsInfoDataSet = new PartsInfoDataSet();
                                Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
                                Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
                                // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

                                string msg = string.Empty;
                                string goodsNo = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Text.Trim();

                                // 商品検索
                                // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                                //int status = this._recBgnGdsAcs.SearchPartsFromGoodsNo(goodsNo, inputValue, out goodsUnitData, out msg);
                                int status = this._recBgnGdsAcs.SearchPartsFromGoodsNo(goodsNo, inputValue, out goodsUnitData, out partsInfoDataSet, out mkrSuggestRtPricList, out mkrSuggestRtPricUList, out msg);
                                // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
                                if (goodsUnitData != null)
                                {
                                    if (goodsUnitData.LogicalDeleteCode == 0)
                                    {
                                        this._swGoodsMakerCd = inputValue;
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerKanaName;  // ﾒｰｶｰ名
                                        //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value = goodsUnitData.GoodsNo;           // 品番	// DEL 2015/03/25 Y.Wakita
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Value = goodsUnitData.GoodsNameKana;   // 品名
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BLGoodsCodeColumn.ColumnName].Value = goodsUnitData.BLGoodsCode;   // BLｺｰﾄﾞ
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BLGroupCodeColumn.ColumnName].Value = goodsUnitData.BLGroupCode;   // BLｸﾞﾙｰﾌﾟｺｰﾄﾞ
                                        // --- DEL 2015/03/26 Y.Wakita ---------->>>>>
                                        //int retPartsFlag = 0;
                                        //status = this._recBgnGdsAcs.GetPartsArticleInfo(goodsUnitData, out retPartsFlag);
                                        //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ModelFitDivColumn.ColumnName].Value = retPartsFlag;                // 適合車種区分
                                        // --- DEL 2015/03/26 Y.Wakita ----------<<<<<

                                        // 商品情報
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.goodsUnitDataColumn.ColumnName].Value = goodsUnitData;
                                        // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.mkrSuggestRtPricListColumn.ColumnName].Value = mkrSuggestRtPricList;
                                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.mkrSuggestRtPricUListColumn.ColumnName].Value = mkrSuggestRtPricUList;
                                        // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

                                        if (applyStaDate != string.Empty)
                                        {
                                            // 価格取得
                                            this.SetUnitPrice(cell.Row.Index);
                                        }

                                        if (recBgnCust != string.Empty)
                                        {
                                            // 得意先別設定削除
                                            this.DelRecBgnGdsCustInfo(cell.Row.Index);
                                        }
                                    }
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "商品が存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value = this._swGoodsMakerCd;
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    this.focusFlg = false;
                                }
                            }
                            else
                            {
                                this._swGoodsMakerCd = inputValue;
                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Value = makerUMnt.MakerKanaName;
                            }
                        }
                        else
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "メーカーコードが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value = this._swGoodsMakerCd;
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            this.focusFlg = false;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Text.Trim()))
                        {
                            GoodsUnitData goodsUnitData = new GoodsUnitData();
                            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                            PartsInfoDataSet partsInfoDataSet = new PartsInfoDataSet();
                            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
                            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
                            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
                            string msg = string.Empty;

                            string goodsNo = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Text.Trim();
                            
                            // 商品検索
                            // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                            //int status = this._recBgnGdsAcs.SearchPartsFromGoodsNo(goodsNo, inputValue, out goodsUnitData, out msg);
                            int status = this._recBgnGdsAcs.SearchPartsFromGoodsNo(goodsNo, inputValue, out goodsUnitData, out partsInfoDataSet, out mkrSuggestRtPricList, out mkrSuggestRtPricUList, out msg);
                            // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
                            if (goodsUnitData != null)
                            {
                                if (goodsUnitData.LogicalDeleteCode == 0)
                                {
                                    this._swGoodsMakerCd = goodsUnitData.GoodsMakerCd;
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value = goodsUnitData.GoodsMakerCd;   // ﾒｰｶｰ
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Value = goodsUnitData.GoodsNameKana;       // ﾒｰｶｰ名

                                    // 商品情報
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.goodsUnitDataColumn.ColumnName].Value = goodsUnitData;
                                    // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.mkrSuggestRtPricListColumn.ColumnName].Value = mkrSuggestRtPricList;
                                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.mkrSuggestRtPricUListColumn.ColumnName].Value = mkrSuggestRtPricUList;
                                    // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "商品が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value = this._swGoodsMakerCd;
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                this.focusFlg = false;
                            }
                        }
                        else
                        {
                            this._swGoodsMakerCd = 0;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value = 0;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Value = string.Empty;
                        }
                    }
                        this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion 
                #region 商品コメント
                // 商品ｺﾒﾝﾄ
                else if (cell.Column.Key == this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName)
                {
                    // 行サイズ変更（入力後に反映されないため、設定を一旦固定にしてから自動サイズに戻す）
                    this.uGrid_Details.DisplayLayout.Override.RowSizing = RowSizing.Fixed;
                    this.uGrid_Details.DisplayLayout.Override.RowSizing = RowSizing.AutoFree;

                    this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion
                #region 表示区分
                // 表示区分
                else if (cell.Column.Key == this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName)
                {
                    int inputValue = 0;
                    // 入力値を取得
                    Int32.TryParse(cell.Text, out inputValue);

                    // --- DEL 2015/03/16 Y.Wakita 障害 ---------->>>>>
                    #region 削除
                    //if (inputValue == 0)
                    //{
                    //    // チェックOFF

                    //    // お買得商品ｸﾞﾙｰﾌﾟ
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = 0;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.NoEdit;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;
                    //    // お買得商品ｸﾞﾙｰﾌﾟ名
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = string.Empty;
                    //    // メーカー価格
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value = 0;
                    //    // 標準価格
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ListPriceColumn.ColumnName].Value = 0;
                    //    // 売価率
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value = 0;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.NoEdit;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;

                    //    // 売単価
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Value = 0;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.NoEdit;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;
                    //}
                    //else
                    //{
                    //    // チェックON
                    //    // 価格取得
                    //    this.SetUnitPrice(cell.Row.Index);
                    //    // お買得商品ｸﾞﾙｰﾌﾟ
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;

                    //    // 売価率
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.AllowEdit;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;

                    //    // 売単価
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.AllowEdit;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor = Color.Empty;
                    //    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                    //}
                    //this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                    #endregion
                    // --- DEL 2015/03/16 Y.Wakita 障害 ----------<<<<<
                    // --- ADD 2015/03/16 Y.Wakita 障害 ---------->>>>>
                    this.ChangeDisplayDiv(cell.Row.Index, inputValue);
                    // --- ADD 2015/03/16 Y.Wakita 障害 ----------<<<<<
                }
                #endregion
                #region お買得商品グループ
                // お買得商品ｸﾞﾙｰﾌﾟ
                else if (cell.Column.Key == this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
                {
                    short gdsGrpCode = 0;
                    short.TryParse(cell.Value.ToString(), out gdsGrpCode);

                    // 入力値を取得
                    if (!cell.Value.ToString().Trim().Equals(string.Empty))
                    {
                        string errMsg = string.Empty;

                        if (this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Text == "1")
                        {
                            if (this._recBgnGdsAcs.CheckRecBgnGrp(string.Empty, string.Empty, gdsGrpCode, true, out errMsg))
                            {
                                string recBgnGrpName = this._recBgnGdsAcs.GetRecBgnGrpName(string.Empty, string.Empty, gdsGrpCode);

                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = recBgnGrpName;
                                this._swBrgnGoodsGrpCode = gdsGrpCode;
                            }
                            else
                            {
                                TMsgDisp.Show(this
                                             , emErrorLevel.ERR_LEVEL_EXCLAMATION
                                             , this.Name
                                             , errMsg
                                             , 0
                                             , MessageBoxButtons.OK);

                                this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = this._swBrgnGoodsGrpCode;
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                this.focusFlg = false;
                            }
                        }
                    }
                    else
                    {
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = 0;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = string.Empty;
                        this._swBrgnGoodsGrpCode = 0;
                    }

                        this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion
                #region 公開開始日/終了日
                // 公開開始日/終了日
                else if (cell.Column.Key == this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName
                      || cell.Column.Key == this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName)
                {
                    bool chkFlg = true;
                    string sErrMsg = string.Empty;
                    string sColumnName = string.Empty;

                    string iApplyDate = string.Empty;

                    if (cell.Column.Key == this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName)
                    {
                        sColumnName = this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName; //列名
                        sErrMsg = this._recBgnGdsDataTable.ApplyStaDateColumn.Caption;        //列タイトル
                        iApplyDate = this._swApplyStaDate;
                    }
                    else
                    {
                        sColumnName = this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName;
                        sErrMsg = this._recBgnGdsDataTable.ApplyEndDateColumn.Caption;
                        iApplyDate = this._swApplyEndDate;
                    }

                    if (!cell.Value.ToString().Equals(string.Empty))
                    {
                        string sApplyDate = cell.Value.ToString();

                        // 日付チェック
                        chkFlg = CheckDateValue(ref sApplyDate);
                        if (!chkFlg)
                        {
                            sErrMsg = sErrMsg + "に誤りがあります。";
                        }
                        else
                        {
                            if (this.uGrid_Details.Rows[cell.Row.Index].Cells[sColumnName].Text != sApplyDate)	// ADD 2015/03/25 Y.Wakita
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[sColumnName].Value = sApplyDate;

                            //開始日を変更（終了＜開始）した場合
                            if (this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Text.Trim() != string.Empty)
                            {
                                DateTime startDate = DateTime.Parse(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Text.Trim());
                                DateTime endDate = DateTime.MinValue;
                                if (!this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Text.Trim().Equals(string.Empty))
                                {
                                    endDate = DateTime.Parse(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Text.Trim());
                                }
                                if (startDate > endDate && endDate != DateTime.MinValue)
                                {
                                    chkFlg = false;
                                    sErrMsg = "公開日の範囲指定に誤りがあります。";
                                }
                            }
                        }
                        if (chkFlg)
                        {
                            if (sColumnName == this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName)
                            {
                                // 公開開始日が変更された場合
                                if ((this._swGoodsNo != string.Empty)
                                 && (this._swGoodsMakerCd != 0)
                                 && (this._swApplyStaDate != string.Empty))
                                {
                                    if (applyStaDate != string.Empty)
                                    {
                                        ErrMsg += PriceClearMsg;
                                    }
                                    if (recBgnCust != string.Empty)
                                    {
                                        if (ErrMsg != string.Empty)
                                        {
                                            ErrMsg += "、";
                                        }
                                        ErrMsg += CustClearMsg;
                                    }

                                    if (ErrMsg != string.Empty)
                                    {
                                        DialogResult dialogResult = TMsgDisp.Show(this
                                             , emErrorLevel.ERR_LEVEL_QUESTION
                                             , this.Name
                                             , ErrMsg + "をクリアします。" + "\r\n" + "\r\n" +
                                               "よろしいですか？"
                                             , 0
                                             , MessageBoxButtons.YesNo
                                             , MessageBoxDefaultButton.Button1);

                                        if (dialogResult == DialogResult.No)
                                        {
                                            this.uGrid_Details.Rows[cell.Row.Index].Cells[sColumnName].Value = iApplyDate; //戻す
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                            //this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                                            return;
                                        }
                                    }
                                }

                                if (applyStaDate != string.Empty)
                                {
                                    // 価格取得
                                    this.SetUnitPrice(cell.Row.Index);
                                }

                                if (recBgnCust != string.Empty)
                                {
                                    // 得意先別設定削除
                                    this.DelRecBgnGdsCustInfo(cell.Row.Index);
                                }

                                this._swApplyStaDate = sApplyDate;
                            }
                            else
                            {
                                // 公開終了日が変更された場合
                                if ((this._swGoodsNo != string.Empty)
                                 && (this._swGoodsMakerCd != 0)
                                 && (this._swApplyEndDate != string.Empty))
                                {
                                    if (recBgnCust != string.Empty)
                                    {
                                        ErrMsg += CustClearMsg;
                                    }

                                    if (ErrMsg != string.Empty)
                                    {
                                        DialogResult dialogResult = TMsgDisp.Show(this
                                             , emErrorLevel.ERR_LEVEL_QUESTION
                                             , this.Name
                                             , ErrMsg + "をクリアします。" + "\r\n" + "\r\n" +
                                               "よろしいですか？"
                                             , 0
                                             , MessageBoxButtons.YesNo
                                             , MessageBoxDefaultButton.Button1);

                                        if (dialogResult == DialogResult.No)
                                        {
                                            this.uGrid_Details.Rows[cell.Row.Index].Cells[sColumnName].Value = iApplyDate; //戻す
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                            //this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                                            return;
                                        }
                                    }
                                }

                                if (recBgnCust != string.Empty)
                                {
                                    // 得意先別設定削除
                                    this.DelRecBgnGdsCustInfo(cell.Row.Index);
                                }

                                this._swApplyEndDate = sApplyDate;
                            }
                        }
                    }
                    else
                    {
                        if (this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString() != string.Empty)
                        //値("0")を消した場合
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[sColumnName].Value = iApplyDate; //戻す
                    }
                    if (!chkFlg)
                    {
                        TMsgDisp.Show(this
                                     , emErrorLevel.ERR_LEVEL_EXCLAMATION
                                     , this.Name
                                     , sErrMsg
                                     , 0
                                     , MessageBoxButtons.OK);

                        this.focusFlg = false;

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[sColumnName].Value = iApplyDate; //戻す
                    }
                        this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion 
                #region 売価率
                // 売価率
                else if (cell.Column.Key == this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName)
                {
                    double inputValue = 0.0;
                    double.TryParse(cell.Value.ToString(), out inputValue);
                    bool status = IndispensableColumCheck(RowIndex);
                    if (status)
                    {
                        string sectionCode = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value.ToString(); // 拠点
                        int customerCode = 0; // 得意先
                        long mkrSuggestRtPric = int.Parse(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value.ToString()); // ﾒｰｶｰ希望小売価格
                        DateTime startDate = DateTime.Parse(this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Text.Trim()); // 開始日
                        double listPrice = 0; // 定価
                        double unitPrice = 0; // 売価

                        object goodsUnitDataObj = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnGdsDataTable.goodsUnitDataColumn.ColumnName].Value;
                        GoodsUnitData goodsUnitData = new GoodsUnitData();
                        goodsUnitData = goodsUnitDataObj as GoodsUnitData;

                        if (inputValue > 0)
                        {
                            // 価格計算
                            this._calculator.GetUnitPriceFromRate(sectionCode, customerCode, mkrSuggestRtPric, inputValue, goodsUnitData, startDate, out listPrice, out unitPrice);

                            // 定価
                            this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.ListPriceColumn.ColumnName].Value = listPrice;

                            // 売単価
                            this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Value = unitPrice;
                        }
                        else
                        {
                            // 価格取得
                            this.SetUnitPrice(RowIndex);
                        }
                    }
                    this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion	// ADD 2015/03/25 Y.Wakita
                #region 単価
                else if (cell.Column.Key == this._recBgnGdsDataTable.UnitPriceColumn.ColumnName)
                {
                    this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion
                #region 得意先別設定
                else if (cell.Column.Key == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
                {
                    this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                }
                #endregion
			//#endregion	// DEL 2015/03/25 Y.Wakita

                // 部品情報プレビュー表示
                    //this.GoodsInfoPreview(cell.Row.Index);
                
                this._rowIndex = cell.Row.Index;

                //this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
                this.uGrid_Details.CellChange += this.uGrid_Details_CellChange;
            }
        }

        ///// <summary>
        ///// 行取得処理
        ///// </summary>
        ///// <param name="stockRowNo"></param>
        ///// <returns></returns>
        ///// <br>Update Note : </br>
        ///// <br>管理番号    : </br>
        ///// <br>            : </br>
        //public RecBgnGdsDataSet.RecBgnGdsRow GetRecBgnGdsRow(int RecRowNo)
        //{
        //    return this._recBgnGdsDataTable.(RecRowNo);
        //}

        /// <summary>
        /// 明細行オブジェクトのクリアを行います。（オーバーロード）
        /// </summary>
        /// <param name="row">明細行オブジェクト</param>
        private void ClearRecBgnGdsRow(RecBgnGdsDataSet.RecBgnGdsRow row)
        {
            if (row == null) return;

            GoodsUnitData goodsUnitData = new GoodsUnitData();

            #region ●項目クリア
            row.GoodsMakerCode = 0;                     // ﾒｰｶｰ
            row.GoodsMakerName = string.Empty;          // ﾒｰｶｰ名
            row.GoodsNo = string.Empty;                 // 品番
            row.GoodsName = string.Empty;               // 品名
            row.BLGroupCode = 0;                        // BLグループコード
            row.BLGoodsCode = 0;                        // BL商品コード
            row.GoodsComment = string.Empty;            // 商品コメント
            row.MkrSuggestRtPric = 0;                   // ﾒｰｶｰ希望小売価格
            row.ListPrice = 0;                          // 定価
            row.UnitCalcRate = 0;                       // 単価算出掛率
            row.UnitPrice = 0;                          // 売単価
            row.ApplyStaDate = string.Empty;            // 適用開始日
            row.ApplyEndDate = string.Empty;            // 適用終了日
            row.ModelFitDiv = 0;                        // 適合車種区分
            row.CustRateGrpCode = 0;                    // 得意先掛率グループコード
            row.DisplayDivCode = 1;                     // 表示区分
            row.BrgnGoodsGrpCode = 0;                   // お買得商品グループコード
            row.BrgnGoodsGrpName = string.Empty;        // お買得商品グループ名
            row.GoodsImage = new Byte[0];               // 商品画像
            row.GoodsImageDmy = string.Empty;
            row.RowDevelopFlg = 0;
            row.RecBgnCust = string.Empty;
            row.goodsUnitData = goodsUnitData;          // 商品情報
            row.RowDeleteFlg = 0;
            row.FilterGuid = Guid.Empty;
            #endregion
        }

        /// <summary>
        /// 必須項目チェック
        /// </summary>
        /// <param name="RowIndex"></param>
        private bool IndispensableColumCheck(int RowIndex)
        {
            // 拠点コード入力チェック
            string inqOtherSecCd = this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value.ToString();
            if (string.IsNullOrEmpty(inqOtherSecCd.Trim()))
            {
                return false;
            }

            // 品番を入力チェック
            string goodsNo = this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            if (string.IsNullOrEmpty(goodsNo.Trim()))
            {
                return false;
            }

            // メーカーコードを入力チェック
            int goodsMakerCd = (int)this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value;
            if (goodsMakerCd == 0)
            {
                return false;
            }

            // 公開開始日を入力チェック
            string applyStaDate = this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Text;
            if (string.IsNullOrEmpty(applyStaDate.Trim()))
            {
                return false;
            }

            // 公開終了日を入力チェック
            string applyEndDate = this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Text;
            if (string.IsNullOrEmpty(applyEndDate.Trim()))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 個別設定削除
        /// </summary>
        /// <param name="RowIndex"></param>
        private void DelRecBgnGdsCustInfo(int RowIndex)
        {
            int rowNo = (int)this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Value;
            this._recBgnGdsAcs.RecBgnGdsCustInfoDic.Remove(rowNo);

            // 個別設定
            this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Value = string.Empty;
        }

        /// <summary>
        /// 価格取得処理
        /// </summary>
        /// <param name="RowIndex"></param>
        private void SetUnitPrice(int RowIndex)
        {
            // 品番
            if (this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString().Trim() == string.Empty) return;

            // ﾒｰｶｰ
            if (this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value.ToString().Trim() == string.Empty) return;

            // 公開開始日
            if (this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value.ToString().Trim() == string.Empty) return;

            // 公開開始日が変更された場合
            long wkMkrSuggestRtPric = 0;
            long wkListPrice = 0;
            long wkUnitPrice = 0;
            string sApplyDate = this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value.ToString().Trim();

            bool status = this.GetUnitPrice(RowIndex, sApplyDate, out wkMkrSuggestRtPric, out wkListPrice, out wkUnitPrice);

			// --- UPD 2015/03/25 Y.Wakita ---------->>>>>
            //// ﾒｰｶｰ希望小売価格
            //this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value = wkMkrSuggestRtPric;
            //// 定価
            //this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.ListPriceColumn.ColumnName].Value = wkListPrice;
            //// 売価率
            //this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value = 0.0;
            //// 売単価
            //this.uGrid_Details.Rows[RowIndex].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Value = wkUnitPrice;

            RecBgnGdsDataSet.RecBgnGdsRow row = this._recBgnGdsDataTable[RowIndex];

            // ﾒｰｶｰ希望小売価格
            row.MkrSuggestRtPric = wkMkrSuggestRtPric;
            // 定価
            row.ListPrice = wkListPrice;
            // 売価率
            row.UnitCalcRate = 0;
            // 売単価
            row.UnitPrice = wkUnitPrice;
			// --- UPD 2015/03/25 Y.Wakita ----------<<<<<
            row.RowDevelopFlg = 1;  // ADD 2015/04/01 Y.Wakita システムテスト障害 №63 
        }

        /// <summary>
        /// 日付チェック処理
        /// </summary>
        /// <param name="sChkDate"></param>
        public bool CheckDateValue(ref string sChkDate)
        {
            string cellValue = sChkDate;
            string nowString = DateTime.Now.Date.ToString("yyyyMMdd");
            int n =  sChkDate.Length - sChkDate.Replace("/", "").Length;
            string format = "yyyy/M/d";

            // スラッシュなし
            switch (n)
            {
                case 0:
                    switch (sChkDate.Length)
                    {
                        case 1: // 日のみ入力
                            cellValue = nowString.Substring(0, 6) + "0" + cellValue;
                            cellValue = cellValue.Insert(4, "/");
                            cellValue = cellValue.Insert(7, "/");
                            break;
                        case 3: // 月・日のみ入力
                            cellValue = nowString.Substring(0, 4) + "0" + cellValue;
                            cellValue = cellValue.Insert(4, "/");
                            cellValue = cellValue.Insert(7, "/");
                            break;
                        case 0:
                        case 5:
                        case 7:
                            break;
                        default:
                            cellValue = nowString.Substring(0, 8 - cellValue.Length) + cellValue;
                            cellValue = cellValue.Insert(4, "/");
                            cellValue = cellValue.Insert(7, "/");
                            break;
                    }
                    break;
                case 1:
                    cellValue = nowString.Substring(0, 4) + cellValue;
                    cellValue = cellValue.Insert(4, "/");
                    break;

                case 2:
                    if (cellValue.Split('/')[0].Length < 3) format = "y/M/d";
                    break;
            }

            DateTime parseDate;
            if (!DateTime.TryParseExact(cellValue, format, null, DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite | DateTimeStyles.AllowInnerWhite, out parseDate))
            {
                return false;
            }
            sChkDate = parseDate.ToString("yyyy/MM/dd");
            return true;
        }

        /// <summary>
        /// グリッドセルKeyPress発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドセルKeyPress発生イベント</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (!cell.IsInEditMode) return;

            //----------------------------------------------
            // ActiveCellがメーカーの場合
            //----------------------------------------------
            if (cell.Column.Key == this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCellが公開開始日、公開終了日の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName
                  || cell.Column.Key == this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName)
            {
                if (!this.KeyPressDateCheck(10, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCellがお買得商品グループコードの場合
            //----------------------------------------------
            else if (cell.Column.Key == this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCellが売価率の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
                if (col.Key != this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = ct_DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;
                }
            }

            #region ●表示幅設定
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Width = 40;		        // №
            editBand.Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].Width = 80;		    // 削除日
            //-------------------------------------------------------------------------------------------------------
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.RowNoColumn.ColumnName].Width = 40;		        // №
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.UpdateTimeColumn.ColumnName].Width = 80;		    // 削除日
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Width = 35;		// 拠点
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Width = 85;		// 拠点名
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNoColumn.ColumnName].Width = 115;	        // 品番
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsNameColumn.ColumnName].Width = 150;			// 品名
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Width = 40;		// ﾒｰｶｰ
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Width = 85;		// ﾒｰｶｰ名
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsCommentColumn.ColumnName].Width = 200;		// 商品ｺﾒﾝﾄ
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Width = 45;		// 商品ｲﾒｰｼﾞﾎﾞﾀﾝ
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Width = 65;	// お買得商品ｸﾞﾙｰﾌﾟ
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Width = 85;	// お買得商品ｸﾞﾙｰﾌﾟ名
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Width = 45;	    // 商品公開区分
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Width = 80;		// 公開開始日
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Width = 80;		// 公開終了日
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Width = 75;	// ﾒｰｶｰ希望小売価格
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Width = 50;       // 売掛率
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.UnitPriceColumn.ColumnName].Width = 75;          // 売単価
            editBand.Columns[this._recBgnGdsAcs.RecBgnGdsDataTable.RecBgnCustColumn.ColumnName].Width = 45;         // 得意先別
            #endregion

            #region ●固定列設定
            //editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Header.Fixed = true;		            // №
            //editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;		            // №
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Header.Fixed = false;
            #endregion
            
            #region ●CellAppearance設定
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;                // №
            editBand.Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// 削除日
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		// 拠点
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;         // 拠点名
            editBand.Columns[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	            // 品番
            editBand.Columns[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;				// 品名
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		// ﾒｰｶｰ
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;		// ﾒｰｶｰ名
            editBand.Columns[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// 商品ｺﾒﾝﾄ
            editBand.Columns[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;		// 商品ｲﾒｰｼﾞﾎﾞﾀﾝ
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		// お買得商品ｸﾞﾙｰﾌﾟ
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;		// お買得商品ｸﾞﾙｰﾌﾟ名
            editBand.Columns[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;		// 商品公開区分
            editBand.Columns[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// 公開開始日
            editBand.Columns[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// 公開終了日
            editBand.Columns[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;     // ﾒｰｶｰ希望小売価格
            editBand.Columns[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;         // 売単率
            editBand.Columns[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;			// 売単価
            editBand.Columns[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;		    // 得意先別設定

            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            //editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            //editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            //editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            #endregion

            #region ●入力許可設定

            //editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;		        // №
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].CellActivation = Activation.NoEdit;
            editBand.Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;			// 削除日
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;		// 拠点
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		    // 拠点名
            editBand.Columns[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 	        // 品番
            editBand.Columns[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 			// 品名
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;		// ﾒｰｶｰ
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		// ﾒｰｶｰ名
            editBand.Columns[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;		// 商品ｺﾒﾝﾄ
            editBand.Columns[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;      // 商品ｲﾒｰｼﾞﾎﾞﾀﾝ
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 	// お買得商品ｸﾞﾙｰﾌﾟ
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;      // お買得商品ｸﾞﾙｰﾌﾟ名
            editBand.Columns[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 	    // 商品公開区分
            editBand.Columns[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// 公開開始日
            editBand.Columns[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// 公開終了日
            editBand.Columns[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;      // ﾒｰｶｰ希望小売価格
            editBand.Columns[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;       // 売単率
            editBand.Columns[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		    // 売単価
            editBand.Columns[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;         // 得意先別設定
            #endregion

            #region ●Style設定
            editBand.Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;        // 削除日
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;     // 拠点
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;     // 拠点名
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // ﾒｰｶｰ
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // ﾒｰｶｰ名
            editBand.Columns[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;           // 品番
            editBand.Columns[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;         // 品名
            editBand.Columns[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // 商品ｺﾒﾝﾄ
            editBand.Columns[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;        // 商品ｲﾒｰｼﾞ
            editBand.Columns[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;   // 商品ｲﾒｰｼﾞﾎﾞﾀﾝ
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;  // お買得商品ｸﾞﾙｰﾌﾟ
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;  // お買得商品ｸﾞﾙｰﾌﾟ名
            editBand.Columns[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;  // 商品公開区分
            editBand.Columns[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // 公開開始日
            editBand.Columns[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // 公開終了日
            editBand.Columns[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;  // ﾒｰｶｰ希望小売価格
            editBand.Columns[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // 売価率
            editBand.Columns[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;         // 売単価
            editBand.Columns[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;      // 得意先別設定
            editBand.Columns[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].CellMultiLine = DefaultableBoolean.True; //複数行形式で表示
            this.uGrid_Details.DisplayLayout.Override.RowSizing = RowSizing.AutoFree;          //行サイズの設定＝自動サイズ設定(変更可)
            this.uGrid_Details.DisplayLayout.Override.RowSizingArea = RowSizingArea.EntireRow; //行サイズ変更に使用できる部分＝行全体(レコードセレクタ・境界線)
            #endregion

            #region ●フォーマット設定

            string decimalFormat2 = "#,##0;-#,##0;''";
            string codeFormat1 = "#00;-#00;''";
            string codeFormat2 = "#0000;-#0000;''";
            string codeFormat3 = "#0;-#0;''";
            string doubleFormat = "##0.#0;-##0.#0;''";

            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Format = codeFormat1;		    // 拠点
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Format = codeFormat2;		// ﾒｰｶｰ
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Format = codeFormat3;		// お買得商品ｸﾞﾙｰﾌﾟ
            editBand.Columns[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Format = decimalFormat2;	// ﾒｰｶｰ希望小売価格
            editBand.Columns[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Format = doubleFormat;		// 売価率
            editBand.Columns[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Format = decimalFormat2;			// 売単価
            #endregion

            #region ●MaxLength設定
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].MaxLength = 2;        // 拠点
            editBand.Columns[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].MaxLength = 24;             // 品番
            editBand.Columns[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].MaxLength = 100;          // 品名
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].MaxLength = 4;       // ﾒｰｶｰ
            editBand.Columns[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].MaxLength = 200;       // 商品ｺﾒﾝﾄ
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].MaxLength = 4;		// お買得商品ｸﾞﾙｰﾌﾟ
            editBand.Columns[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].MaxLength = 10;		// 公開開始日
            editBand.Columns[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].MaxLength = 10;        // 公開終了日
            editBand.Columns[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].MaxLength = 6;			// 売価率
            // --- UPD 2015/03/09 Y.Wakita Redmine#351 ---------->>>>>
            //editBand.Columns[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].MaxLength = 17;			// 売単価
            editBand.Columns[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].MaxLength = 7;			// 売単価
            // --- UPD 2015/03/09 Y.Wakita Redmine#351 ----------<<<<<
            #endregion

            #region ●グリッド列表示非表示設定処理
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Hidden = false;		        // №
            editBand.Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].Hidden = true;		    // 削除日
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Hidden = false;		// 拠点
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Hidden = false;		// 拠点名
            editBand.Columns[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Hidden = false;	            // 品番
            editBand.Columns[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Hidden = false;			// 品名
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Hidden = false;		// ﾒｰｶｰ
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Hidden = false;		// ﾒｰｶｰ名
            editBand.Columns[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Hidden = false;		// 商品ｺﾒﾝﾄ
            editBand.Columns[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Hidden = true;		    // 商品ｲﾒｰｼﾞ
            editBand.Columns[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Hidden = false;		// 商品ｲﾒｰｼﾞﾎﾞﾀﾝ
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Hidden = false;	// お買得商品ｸﾞﾙｰﾌﾟ
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Hidden = false;	// お買得商品ｸﾞﾙｰﾌﾟ名
            editBand.Columns[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Hidden = false;	    // 商品公開区分
            editBand.Columns[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Hidden = false;		// 公開開始日
            editBand.Columns[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Hidden = false;		// 公開終了日
            editBand.Columns[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Hidden = false;    // ﾒｰｶｰ希望小売価格
            editBand.Columns[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Hidden = false;		// 売価率
            editBand.Columns[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Hidden = false;			// 売単価
            editBand.Columns[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Hidden = false;			// 得意先別設定
            #endregion

            #region ●グリッド列ソート設定処理
            editBand.Columns[this._recBgnGdsDataTable.RowNoColumn.ColumnName].SortIndicator = SortIndicator.Disabled;               // №
            editBand.Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].SortIndicator = SortIndicator.Disabled;          // 削除日
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// 拠点
            editBand.Columns[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// 拠点名
            editBand.Columns[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].SortIndicator = SortIndicator.Disabled;	            // 品番
            editBand.Columns[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].SortIndicator = SortIndicator.Disabled;			// 品名
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].SortIndicator = SortIndicator.Disabled;	    // ﾒｰｶｰ
            editBand.Columns[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].SortIndicator = SortIndicator.Disabled;	    // ﾒｰｶｰ名
            editBand.Columns[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// 商品ｺﾒﾝﾄ
            editBand.Columns[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		    // 商品ｲﾒｰｼﾞ
            editBand.Columns[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// 商品ｲﾒｰｼﾞ
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].SortIndicator = SortIndicator.Disabled;	// お買得商品ｸﾞﾙｰﾌﾟ
            editBand.Columns[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].SortIndicator = SortIndicator.Disabled;	// お買得商品ｸﾞﾙｰﾌﾟ名
            editBand.Columns[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].SortIndicator = SortIndicator.Disabled;	    // 商品公開区分
            editBand.Columns[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// 公開開始日
            editBand.Columns[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// 公開終了日
            editBand.Columns[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].SortIndicator = SortIndicator.Disabled;    // ﾒｰｶｰ希望小売価格
            editBand.Columns[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].SortIndicator = SortIndicator.Disabled; 		// 売価率
            editBand.Columns[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].SortIndicator = SortIndicator.Disabled;			// 売単価
            editBand.Columns[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].SortIndicator = SortIndicator.Disabled;			// 得意先別設定
            #endregion

            try
            {
                this.uGrid_Details.BeginUpdate();
                ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

                # region [セル結合設定]
                List<string> colNameList = new List<string>(new string[] 
                                            { 
                                                this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName,
                                                this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName,
                                                this._recBgnGdsDataTable.GoodsNoColumn.ColumnName,
                                                this._recBgnGdsDataTable.GoodsNameColumn.ColumnName,
                                                this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName,
                                                this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName,
                                                this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName,
                                                this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName,
                                                this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName,
                                            });
                Infragistics.Win.Appearance margedCellAppearance = new Infragistics.Win.Appearance();

                for (int index = 0; index < colNameList.Count; index++)
                {
                    string colName = colNameList[index];

                    // CellAppearanceを強制的に統一する（行№は除く）
                    if (!columns[colName].Key.Trim().Equals(this._recBgnGdsDataTable.RowNoColumn.ColumnName.Trim()))
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
                columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName);

                // 拠点名
                columns[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName);

                // 品番
                columns[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsNoColumn.ColumnName);

                // 品名
                columns[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsNoColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsNameColumn.ColumnName);

                // ﾒｰｶｰ
                columns[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsNoColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName);

                // ﾒｰｶｰ名
                columns[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsNoColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName);

                // 商品コメント
                columns[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsNoColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName);

                // お買得商品グループコード
                columns[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsNoColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName,
                                                    this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName);

                // お買得商品グループ名
                columns[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsNoColumn.ColumnName,
                                                    this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName,
                                                    this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName,
                                                    this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName);

                # endregion
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
            }
        }

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

        # endregion

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面初期化処理します。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void Clear(bool settingGrid)
        {
            this._recBgnGdsAcs.PrevRecBgnGdsDic.Clear();

            this.SetButtonEnabled(1);
            // 明細DataTable行クリア処理
            this._recBgnGdsAcs.RecBgnGdsDataTable.Rows.Clear();
            // ソート設定の解除
            this.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();
            // グリッド行初期設定処理
            this._recBgnGdsAcs.DetailRowInitialSetting(1);
            this.DetailGridInitSetting();

            if (settingGrid)
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].Hidden = true;
            }
            //// 部品情報プレビュークリア
            //this.GoodsInfoPreview(0);
        }

        /// <summary>
        /// グリッド列不可入力色設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : グリッド列不可入力色設定します。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void DetailGridInitSetting()
        {
            if (this.uGrid_Details == null || this.uGrid_Details.Rows.Count < 1)
            {
                return;
            }

            UltraGridRow row = this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count-1];
            
            foreach (UltraGridCell cell in row.Cells)
            {
                // 拠点名、メーカー名、お買得商品ｸﾞﾙｰﾌﾟ名、ﾒｰｶｰ希望小売価格
                if (cell.Column.Key == this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName
                 || cell.Column.Key == this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName
                 || cell.Column.Key == this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName
                 || cell.Column.Key == this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName)
                {
                    cell.Activation = Activation.NoEdit;
                    cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                }
            }
        }

        /// <summary>
        /// メーカーコードガイド起動
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note	   : メーカーコードガイド起動。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void GoodsMakerCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // コードから名称へ変換
                MakerUMnt makerInfo;
                int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerInfo);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value = makerInfo.GoodsMakerCd;
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Value = makerInfo.MakerKanaName;

                    MoveNextAllowEditCell(false);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// 拠点ガイド起動
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note	   : 拠点ガイド起動。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void SectionGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 拠点ガイド呼び出し
                SecInfoSet secInfoSet;
                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value = secInfoSet.SectionCode.ToString().Trim().PadLeft(2, '0');
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Value = secInfoSet.SectionGuideNm;

                    MoveNextAllowEditCell(false);
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// お買得商品グループガイド起動
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note	   : お買得商品グループガイド起動</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void SetGdsGrpCodeGuide(int rowIndex, int customerCode)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // お買得商品グループガイド
                PMREC09030UA recBgnGrpSearchForm = new PMREC09030UA(PMREC09030UA.GUIDETYPE_NORMAL, customerCode, new ArrayList(this._recBgnGdsAcs.CustomerSearchRetList));
                recBgnGrpSearchForm.RecBgnGrpSelect += new PMREC09030UA.RecBgnGrpSelectEventHandler(this.RecBgnGrpSearchForm_RecBgnGrpSelect);
                recBgnGrpSearchForm.ShowDialog(this);

                if (this._recBgnGrpRet != null)
                {
                    // お買得商品グループ
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = this._recBgnGrpRet.BrgnGoodsGrpCode.ToString().PadLeft(4, '0');

                    MoveNextAllowEditCell(false);
                    this._customerSearchRet = null;
                }
                else
                {

                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// お買得商品グループ選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">お買得商品グループ検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note        : お買得商品グループ選択時に発生します。</br>
        /// <br>Programmer	: 脇田 靖之</br>
        /// <br>Date		: 2015/02/20</br>
        /// </remarks>
        private void RecBgnGrpSearchForm_RecBgnGrpSelect(object sender, RecBgnGrpRet recBgnGrpRet)
        {
            if (recBgnGrpRet == null)
            {
                this._recBgnGrpRet = null;
                return;
            }
            this._recBgnGrpRet = recBgnGrpRet;
        }

        /// <summary>
        /// 復活ボタン無効/有効設定
        /// </summary>
        /// <param name="mode">mode1,2,3</param>
        /// <remarks>
        /// <br>Note	   : 復活ボタン無効/有効設定。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void SetButtonEnabled(int mode)
        {
            switch (mode)
            {
                case 1:
                    {
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Revival"].SharedProps.Enabled = false;
                        this.uButton_Revival.Enabled = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_RowDelete"].SharedProps.Enabled = true;
                        this.uButton_RowDelete.Enabled = true;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllRowDelete"].SharedProps.Enabled = true;
                        this.uButton_AllRowDelete.Enabled = true;
                        // --- ADD 2015/03/24 Y.Wakita ---------->>>>>
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Recapture"].SharedProps.Enabled = false;
                        this.uButton_Recapture.Enabled = false;
                        // --- ADD 2015/03/24 Y.Wakita ----------<<<<<
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
                        // --- ADD 2015/03/24 Y.Wakita ---------->>>>>
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Recapture"].SharedProps.Enabled = false;
                        this.uButton_Recapture.Enabled = false;
                        // --- ADD 2015/03/24 Y.Wakita ----------<<<<<
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
                        // --- ADD 2015/03/24 Y.Wakita ---------->>>>>
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Recapture"].SharedProps.Enabled = false;
                        this.uButton_Recapture.Enabled = false;
                        // --- ADD 2015/03/24 Y.Wakita ----------<<<<<
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
        /// <br>Note        : 得意先選択時に発生します。</br>
        /// <br>Programmer	: 脇田 靖之</br>
        /// <br>Date		: 2015/02/20</br>
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
        /// グリッドNextフォーカス取得処理
        /// </summary>
        /// <param name="mode">モード(0:Tab;1;Shift + Tab)</param>
        /// <param name="rowIndex">rowIndex</param>
        /// <param name="columnKey">columnKey</param>
        /// <returns>columnIndex</returns>
        /// <remarks>
        /// <br>Note        : グリッドNextフォーカス取得を行います。</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private int GetNextColumnIndexByTab(int mode, int rowIndex, string columnKey)
        {
            int columnIndex = -1;
            switch (mode)
            {
                case 0:
                    #region Tab
                    // 拠点
                    if (columnKey == this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName)
                    {
                        // 拠点名
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Column.Index;
                    }
                    // 拠点名
                    else if (columnKey == this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName)
                    {
                        // 品番
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Column.Index;
                    }
                    // 品番
                    if (columnKey == this._recBgnGdsDataTable.GoodsNoColumn.ColumnName)
                    {
                        // 品名
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Column.Index;
                    }
                    // 品名
                    else if (columnKey == this._recBgnGdsDataTable.GoodsNameColumn.ColumnName)
                    {
                        // ﾒｰｶｰ
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Column.Index;
                    }
                    // ﾒｰｶｰ
                    if (columnKey == this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName)
                    {
                        // ﾒｰｶｰ名
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Column.Index;
                    }
                    // ﾒｰｶｰ名
                    else if (columnKey == this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName)
                    {
                        // 商品ｺﾒﾝﾄ
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Column.Index;
                    }
                    // 商品ｺﾒﾝﾄ
                    else if (columnKey == this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName)
                    {
                        // 画像ｲﾒｰｼﾞ(ﾎﾞﾀﾝ)
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Column.Index;
                    }
                    // 画像ｲﾒｰｼﾞ(ﾎﾞﾀﾝ)
                    else if (columnKey == this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName)
                    {
                        // 公開開始日
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Column.Index;
                    }
                    // 公開開始日
                    else if (columnKey == this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName)
                    {
                        // 公開終了日
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Column.Index;
                    }
                    // 公開終了日
                    else if (columnKey == this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName)
                    {
                        // 表示区分
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Column.Index;
                    }
                    // 表示区分
                    else if (columnKey == this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName)
                    {
                        // お買得商品ｸﾞﾙｰﾌﾟ
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Column.Index;
                    }
                    // お買得商品ｸﾞﾙｰﾌﾟ
                    else if (columnKey == this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
                    {
                        // お買得商品ｸﾞﾙｰﾌﾟ名
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Column.Index;
                    }
                    // お買得商品ｸﾞﾙｰﾌﾟ名
                    else if (columnKey == this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName)
                    {
                        // ﾒｰｶｰ希望小売価格
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Column.Index;
                    }
                    // ﾒｰｶｰ希望小売価格
                    else if (columnKey == this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName)
                    {
                        // 売価率
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Column.Index;
                    }
                    // 売価率
                    else if (columnKey == this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName)
                    {
                        // 売単価
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Column.Index;
                    }
                    // 売単価
                    else if (columnKey == this._recBgnGdsDataTable.UnitPriceColumn.ColumnName)
                    {
                        // 得意先個別設定
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Column.Index;
                    }
                    // 得意先個別設定
                    else if (columnKey == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
                    {
                        columnIndex = -1;
                    }
                    break;
                    #endregion Tab
                case 1:
                    #region Shift + Tab
                    // 拠点
                    if (columnKey == this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName)
                    {
                        columnIndex = -1;
                    }
                    // 拠点名
                    else if (columnKey == this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName)
                    {
                        // 拠点
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Column.Index;
                    }
                    // 品番
                    if (columnKey == this._recBgnGdsDataTable.GoodsNoColumn.ColumnName)
                    {
                        // 拠点名
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Column.Index;
                    }
                    // 品名
                    else if (columnKey == this._recBgnGdsDataTable.GoodsNameColumn.ColumnName)
                    {
                        // 品番
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Column.Index;
                    }
                    // ﾒｰｶｰ
                    else if (columnKey == this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName)
                    {
                        // 品名
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Column.Index;
                    }
                    // ﾒｰｶｰ名
                    else if (columnKey == this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName)
                    {
                        // ﾒｰｶｰ
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Column.Index;
                    }
                    // 商品ｺﾒﾝﾄ
                    else if (columnKey == this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName)
                    {
                        //  ﾒｰｶｰ名
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerNameColumn.ColumnName].Column.Index;
                    }
                    // 画像ｲﾒｰｼﾞ(ﾎﾞﾀﾝ)
                    else if (columnKey == this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName)
                    {
                        // 商品ｺﾒﾝﾄ
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Column.Index;
                    }
                    // 公開開始日
                    else if (columnKey == this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName)
                    {
                        // 画像ｲﾒｰｼﾞ(ﾎﾞﾀﾝ)
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Column.Index;
                    }
                    // 公開終了日
                    else if (columnKey == this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName)
                    {
                        // 公開開始日
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Column.Index;
                    }
                    // 表示区分
                    else if (columnKey == this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName)
                    {
                        // 公開終了日
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Column.Index;
                    }
                    // お買得商品ｸﾞﾙｰﾌﾟ
                    else if (columnKey == this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
                    {
                        // 表示区分
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Column.Index;
                    }
                    // お買得商品ｸﾞﾙｰﾌﾟ名
                    else if (columnKey == this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName)
                    {
                        // お買得商品ｸﾞﾙｰﾌﾟ
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Column.Index;
                    }
                    // ﾒｰｶｰ希望小売価格
                    else if (columnKey == this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName)
                    {
                        // お買得商品ｸﾞﾙｰﾌﾟ名
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Column.Index;
                    }
                    // 売価率
                    else if (columnKey == this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName)
                    {
                        // ﾒｰｶｰ希望小売価格
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Column.Index;
                    }
                    // 売単価
                    else if (columnKey == this._recBgnGdsDataTable.UnitPriceColumn.ColumnName)
                    {
                        // 売価率
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Column.Index;
                    }
                    // 得意先個別設定
                    else if (columnKey == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
                    {
                        // 売単価
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Column.Index;
                    }
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
        /// <br>Note        : 変化データ取得処理</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        public void GetSaveDate(out List<RecBgnGds> delList, out List<RecBgnGds> updList)
        {
            this._prevRecBgnGdsDic = this._recBgnGdsAcs.PrevRecBgnGdsDic;
            List<RecBgnGds> dList = new List<RecBgnGds>();
            List<RecBgnGds> uList = new List<RecBgnGds>();

            RecBgnGds recBgnGds = new RecBgnGds();
            RecBgnGds recBgnGdsUPD = new RecBgnGds();
            if (this._recBgnGdsDataTable.Rows.Count > 0)
            {
                foreach (RecBgnGdsDataSet.RecBgnGdsRow row in this._recBgnGdsDataTable.Rows)
                {
                    recBgnGds = new RecBgnGds();
                    this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow(row, ref recBgnGds);

                    // 改修行の場合
                    if (_prevRecBgnGdsDic.ContainsKey(row.FilterGuid))
                    {
                        bool keyChanged = this._recBgnGdsAcs.CompareKey(recBgnGds, _prevRecBgnGdsDic[row.FilterGuid]);

                        // 行削除の場合
                        if (row.RowDeleteFlg == 0)
                        {
                            if (this._recBgnGdsAcs.Compare(recBgnGds, _prevRecBgnGdsDic[row.FilterGuid]))
                            {
                                dList.Add(_prevRecBgnGdsDic[row.FilterGuid]);
                                recBgnGdsUPD = recBgnGds.Clone();
                                recBgnGdsUPD.LogicalDeleteCode = 0;

                                if (!keyChanged)
                                {
                                    recBgnGdsUPD.IsUpdRow = true;
                                }
                                uList.Add(recBgnGdsUPD);
                            }
                            else if (row.CustUpdFlg == 1)
                            {
                                dList.Add(_prevRecBgnGdsDic[row.FilterGuid]);
                                recBgnGdsUPD = recBgnGds.Clone();
                                recBgnGdsUPD.LogicalDeleteCode = 0;

                                if (!keyChanged)
                                {
                                    recBgnGdsUPD.IsUpdRow = true;
                                }
                                uList.Add(recBgnGdsUPD);
                            }
                        }
                        else
                        {
                            recBgnGds = _prevRecBgnGdsDic[row.FilterGuid];
                            recBgnGdsUPD = recBgnGds.Clone();
                            recBgnGdsUPD.LogicalDeleteCode = 1;
                            if (!keyChanged)
                            {
                                recBgnGdsUPD.IsUpdRow = true;
                            }
                            uList.Add(recBgnGdsUPD);
                        }
                    }
                    // 新規行の場合
                    else
                    {
                        if (this._recBgnGdsAcs.IsRowUpdate(row) && row.RowDeleteFlg == 0)
                        {
                            recBgnGdsUPD = recBgnGds.Clone();
                            recBgnGdsUPD.InqOtherEpCd = this._enterpriseCode;
                            recBgnGdsUPD.LogicalDeleteCode = 0;
                            recBgnGdsUPD.IsUpdRow = false;

                            uList.Add(recBgnGdsUPD);
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public bool CheckSaveDate(out List<RecBgnGds> deleteList, out List<RecBgnGds> updateList)
        {
            List<RecBgnGds> delList = new List<RecBgnGds>();
            List<RecBgnGds> updList = new List<RecBgnGds>();

            this.GetSaveDate(out delList, out updList);
            deleteList = delList;
            updateList = updList;

            if (updateList.Count == 0)
            {
                return false;
            }
            #region 必須チェック
            if (updateList.Count != 0)
            {
                int rowIndex = -1;
                foreach (RecBgnGds bgn in updateList)
                {
                    // 行削除のデータがチェックない
                    if (bgn.LogicalDeleteCode == 1)
                    {
                        continue;
                    }

                    //行番号を取得
                    foreach (UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        if (bgn.RowIndex == (int)row.Cells[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Value)
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }

                    // 品番を入力チェック
                    if (string.IsNullOrEmpty(bgn.GoodsNo.Trim()))
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "品番を入力して下さい。",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }

                    // メーカーコードを入力チェック
                    if (bgn.GoodsMakerCd == 0)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "メーカーコードを入力して下さい。",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }

                    // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
                    bool custFlg = CheckCustDisplayDiv(bgn.RowIndex);

                    // 表示区分
                    if (bgn.DisplayDivCode == 1 || custFlg)
                    {
                    // --- ADD 2015/03/23 Y.Wakita ----------<<<<<
                        // 品名を入力チェック
                        if (string.IsNullOrEmpty(bgn.GoodsName.Trim()))
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "品名を入力して下さい。",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }

                        // 品名の入力桁数チェック
                        if (bgn.GoodsName.Length > 40)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "品名の入力可能文字数が規定値(40文字)を超えています。",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }

                        // 商品コメントを入力チェック
                        if (string.IsNullOrEmpty(bgn.GoodsComment.Trim()))
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "オススメPOINTを入力して下さい。",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }

                        // 商品イメージを入力チェック
                        if (bgn.GoodsImage.Length == 0)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "商品イメージを入力して下さい。",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }
                    // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
                    }
                    // --- ADD 2015/03/23 Y.Wakita ----------<<<<<

                    // 公開開始日を入力チェック
                    if (bgn.ApplyStaDate == 0)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "公開開始日を入力して下さい。",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }

                    // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
                    // 表示区分
                    if (bgn.DisplayDivCode == 1 || custFlg)
                    {
                    // --- ADD 2015/03/23 Y.Wakita ----------<<<<<
                        // 公開終了日を入力チェック
                        if (bgn.ApplyEndDate == 0)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "公開終了日を入力して下さい。",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }
                    // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
                    }
                    // --- ADD 2015/03/23 Y.Wakita ----------<<<<<

                    // 公開日の範囲チェック
                    if (bgn.ApplyStaDate > bgn.ApplyEndDate && bgn.ApplyEndDate != 0)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "公開日の範囲指定に誤りがあります。",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }

                    // 表示区分
                    if (bgn.DisplayDivCode == 1)
                    {

                        // お買得商品グループコードを入力チェック
                        if (bgn.BrgnGoodsGrpCode == 0)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "お買得商品グループコードを入力して下さい。",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }

                        // 売単価を入力チェック
                        if (bgn.UnitPrice == 0)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "売単価を入力して下さい。",
                                 0,
                                 MessageBoxButtons.OK);
                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }                      
                    }
                    // --- ADD 2015/04/01 Y.Wakita システムテスト障害 №63 ---------->>>>>
                    // 未確定明細チェック
                    if (int.Parse(this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.RowDevelopFlgColumn.ColumnName].Text) == 0)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "未確定な明細が存在します。",
                             0,
                             MessageBoxButtons.OK);
                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }
                    // --- ADD 2015/04/01 Y.Wakita システムテスト障害 №63 ----------<<<<<
                }
            }
            #endregion

            #region 重複チェック
            if (updateList.Count != 0)
            {
                RecBgnGds recBgnGds = null;
                int rowIndex = -1;
                foreach (RecBgnGds bgn in updateList)
                {
                    // 行削除のデータがチェックない
                    if (bgn.LogicalDeleteCode == 1)
                    {
                        continue;
                    }

                    // お買得商品設定マスタ取得
                    if (this._recBgnGdsAcs.RecBgnGdsDic.ContainsKey(bgn.GoodsMakerCd))
                    {
                        recBgnGds = this._recBgnGdsAcs.RecBgnGdsDic[bgn.GoodsMakerCd];
                    }

                    //行番号を取得
                    foreach (UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        if (bgn.RowIndex == (int)row.Cells[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Value)
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }

                    int flag = 0;
                    string errorMsg = string.Empty;

                    #region 重複レコードの存在チェック
                    flag = 0;
                    foreach (RecBgnGdsDataSet.RecBgnGdsRow row in this._recBgnGdsDataTable.Rows)
                    {
                        if (row.FilterGuid == Guid.Empty && row.RowDeleteFlg == 1)
                        {
                            continue;
                        }

                        if (bgn.InqOtherEpCd == row.InqOtherEpCd
                            && bgn.InqOtherSecCd.ToString().PadLeft(2, '0') == row.InqOtherSecCd.ToString().PadLeft(2, '0')
                            && bgn.GoodsMakerCd == row.GoodsMakerCode
                            && bgn.GoodsNo.Trim() == row.GoodsNo.Trim())
                        {
                            errorMsg = "拠点：" + bgn.InqOtherSecCd.ToString().PadLeft(2, '0')
                                   +"、品番：" + bgn.GoodsNo.Trim()
                                   + "、ﾒｰｶｰ：" + bgn.GoodsMakerCd.ToString().PadLeft(4, '0')
                                   + "、公開日：" + bgn.ApplyStaDate.ToString().PadLeft(6, '0')
                                   + "～" + bgn.ApplyEndDate.ToString().PadLeft(6, '0');

                            int startDate = 0;
                            if (!row.ApplyStaDate.Trim().Equals(string.Empty)) startDate = int.Parse(row.ApplyStaDate.Trim().Replace("/", ""));
                            int endDate = 0;
                            if (!row.ApplyEndDate.Trim().Equals(string.Empty)) endDate = int.Parse(row.ApplyEndDate.Trim().Replace("/", ""));

                            if ((startDate <= bgn.ApplyStaDate
                                && bgn.ApplyStaDate <= endDate)
                                || (startDate <= bgn.ApplyEndDate
                                && bgn.ApplyEndDate <= endDate))
                            {
                                flag++;
                            }
                        }
                        if (flag > 1)
                        {
                            TMsgDisp.Show(
                                 this,
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 this.Name,
                                 "同一の商品設定が既に登録されています。" + "\r\n" +
                                 errorMsg,
                                 0,
                                 MessageBoxButtons.OK);

                            if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            return false;
                        }
                    }
                    #endregion
                }
            }
            #endregion

            return true;
        }

        /// <summary>
        /// DOWN前チェック処理
        /// </summary>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 保存前チェック処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2011/07/06</br>
        /// </remarks>
        public bool CheckDateForDown()
        {
            RecBgnGdsDataSet.RecBgnGdsRow row = (RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsDataTable.Rows[this._recBgnGdsDataTable.Count - 1];
            // 行削除のデータがチェックない
            if (row.RowDeleteFlg == 1)
            {
                return true;
            }
            RecBgnGds recBgnGds = new RecBgnGds();
            this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow((RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsDataTable.Rows[this._recBgnGdsDataTable.Count - 1], ref recBgnGds);


            string errMsg = string.Empty;

            // 行削除のデータがチェックない
            if (recBgnGds.LogicalDeleteCode == 1)
            {
                return true;
            }

            // 拠点コード入力チェック
            if (string.IsNullOrEmpty(recBgnGds.InqOtherSecCd.Trim()))
            {
                errMsg = "拠点";
            }

            // 品番を入力チェック
            if (string.IsNullOrEmpty(recBgnGds.GoodsNo.Trim()))
            {
                if (errMsg.Length != 0)
                    errMsg += "、";

                errMsg += "品番";
            }

            // メーカーコードを入力チェック
            if (recBgnGds.GoodsMakerCd == 0)
            {
                if (errMsg.Length != 0)
                    errMsg += "、";

                errMsg += "ﾒｰｶｰ";
            }

            // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
            bool custFlg = CheckCustDisplayDiv(recBgnGds.RowIndex);

            // 表示区分
            if (recBgnGds.DisplayDivCode == 1 || custFlg)
            {
            // --- ADD 2015/03/23 Y.Wakita ----------<<<<<
                // 品名を入力チェック
                if (string.IsNullOrEmpty(recBgnGds.GoodsName.Trim()))
                {
                    if (errMsg.Length != 0)
                        errMsg += "、";

                    errMsg += "品名";
                }

                // 商品コメントを入力チェック
                if (string.IsNullOrEmpty(recBgnGds.GoodsComment.Trim()))
                {
                    if (errMsg.Length != 0)
                        errMsg += "、";

                    errMsg += "オススメPOINT";
                }

                // 商品イメージを入力チェック
                if (recBgnGds.GoodsImage.Length == 0)
                {
                    if (errMsg.Length != 0)
                        errMsg += "、";

                    errMsg += "商品ｲﾒｰｼﾞ";
                }
            // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
            }
            // --- ADD 2015/03/23 Y.Wakita ----------<<<<<

            // 公開開始日を入力チェック
            if (recBgnGds.ApplyStaDate == 0)
            {
                if (errMsg.Length != 0)
                    errMsg += "、";

                errMsg += "公開開始日";
            }

            // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
            // 表示区分
            if (recBgnGds.DisplayDivCode == 1 || custFlg)
            {
            // --- ADD 2015/03/23 Y.Wakita ----------<<<<<
                // 公開終了日を入力チェック
                if (recBgnGds.ApplyEndDate == 0)
                {
                    if (errMsg.Length != 0)
                        errMsg += "、";

                    errMsg += "公開終了日";
                }
            // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
            }
            // --- ADD 2015/03/23 Y.Wakita ----------<<<<<

            // 公開日の範囲チェック
            if (recBgnGds.ApplyStaDate > recBgnGds.ApplyEndDate && recBgnGds.ApplyEndDate != 0)
            {
                return false;
            }

            // 表示区分
            if (recBgnGds.DisplayDivCode == 1)
            {
                // お買得商品グループ
                if (recBgnGds.BrgnGoodsGrpCode == 0)
                {
                    if (errMsg.Length != 0)
                        errMsg += "、";

                    errMsg += "お買得商品ｸﾞﾙｰﾌﾟ";
                }

                // 売単価を入力チェック
                if (recBgnGds.UnitPrice == 0)
                {
                    if (errMsg.Length != 0)
                        errMsg += "、";

                    errMsg += "売単価";
                }
            }

            if (errMsg.Length != 0)
            {
                TMsgDisp.Show(
                     this,
                     emErrorLevel.ERR_LEVEL_EXCLAMATION,
                     this.Name,
                     "行№" + row.RowNo.ToString() + "の必須項目が入力されていません。" + "\r\n" + "\r\n" + errMsg,
                     0,
                     MessageBoxButtons.OK);

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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void ReturnSaveDate(out List<RecBgnGds> deleteList, out List<RecBgnGds> updateList)
        {
            this._prevRecBgnGdsDic = this._recBgnGdsAcs.PrevRecBgnGdsDic;
            List<RecBgnGds> delList = new List<RecBgnGds>();
            List<RecBgnGds> updList = new List<RecBgnGds>();

            RecBgnGds recBgnGds = new RecBgnGds();
            RecBgnGds recBgnGdsUPD = new RecBgnGds();

            if (this._recBgnGdsDataTable.Rows.Count > 0)
            {
                foreach (RecBgnGdsDataSet.RecBgnGdsRow row in this._recBgnGdsDataTable.Rows)
                {
                    this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow(row, ref recBgnGds);

                    if (row.RowDeleteFlg == 1)
                    {
                        delList.Add(this._prevRecBgnGdsDic[row.FilterGuid]);
                    }
                    else if (row.RowDeleteFlg == 2)
                    {
                        recBgnGds = this._prevRecBgnGdsDic[row.FilterGuid];
                        recBgnGdsUPD = recBgnGds.Clone();
                        recBgnGdsUPD.LogicalDeleteCode = 0;
                        updList.Add(recBgnGdsUPD);
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void GridSettingAfterSearch(bool deleteFlg)
        {
            //削除指定区分:0
            if (deleteFlg == false)
            {
                this.SetButtonEnabled(1);
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].Hidden = true;
                // 全項目使用不可
                this.AllCellNoEdit(1);
            }
            //削除指定区分:1
            else
            {
                this.SetButtonEnabled(2);
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].Hidden = false;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recBgnGdsDataTable.UpdateTimeColumn.ColumnName].CellAppearance.ForeColor = Color.Red;
                // 全項目使用不可
                this.AllCellNoEdit(2);
            }
        }

        /// <summary>
        /// 入力不可能セル設定処理
        /// </summary>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void AllCellNoEdit(int mode)
        {
            foreach (UltraGridRow row in this.uGrid_Details.Rows)
            {
                if (mode == 1)
                {
                    if ((Guid)row.Cells[this._recBgnGdsDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                    {
                        continue;
                    }
                }
                foreach (UltraGridCell cell in row.Cells)
                {
                    if (cell.Column.Key != this._recBgnGdsDataTable.RowNoColumn.ColumnName)
                    {
                        cell.Appearance.BackColor = ct_DISABLE_COLOR;
                        cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                        cell.Activation = Activation.NoEdit;
                    }
                    // 画像イメージボタンを使用不可（StyleをEditに変更）
                    if (cell.Column.Key == this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName)
                    {
                        if (mode == 2)
                            cell.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

                        Byte[] dats = new byte[0];
                        if (row.Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value.ToString().Trim().Length != 0)
                            dats = (Byte[])row.Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value;

                        if (dats.Length == 0)
                        {
                            cell.Value = "";
                        }
                        else
                        {
                            cell.Value = GOODSIMG_FILE_TRUE;
                        }

                        cell.Row.Activate();

                    }
                    else if (cell.Column.Key == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
                    {
                        if (mode == 2)
                            cell.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

                        cell.Row.Activate();
                    }
                }
            }

            // 品名、商品ｺﾒﾝﾄ、売単価を使用可
            foreach (UltraGridRow row in this.uGrid_Details.Rows)
            {

                if (mode == 2) break;   // 削除の場合

                if (mode == 1)
                {
                    if ((Guid)row.Cells[this._recBgnGdsDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                    {
                        continue;
                    }
                }
                // 品名
                row.Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsNameColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // 商品ｺﾒﾝﾄ
                row.Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsCommentColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // 商品ｲﾒｰｼﾞ
                row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // お買得商品グループコード
                row.Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // 表示区分
                row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // 適用開始日
                row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // 適用終了日
                row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // 単価算出掛率
                row.Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // 売単価
                row.Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
                // 得意先個別設定
                row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Activation = Activation.AllowEdit;
                row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Appearance.BackColor = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Appearance.BackColorDisabled = Color.Empty;
                row.Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Appearance.BackColorDisabled2 = Color.Empty;
            }
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 次入力可能セル移動処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
                    if (this.uGrid_Details.ActiveRow.Index == this._recBgnGdsDataTable.Count - 1)
                    {
                        if (this.uGrid_Details.ActiveCell == null) break;

                        if (this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key))
                        {
                            if (this._recBgnGdsAcs.DeleteSearchMode == false)
                            {
                                if (CheckDateForDown())
                                {
                                    #region 最終行の場合、新規行を追加する
                                    this.NewRowAdd();
                                    #endregion

                                    return true;
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
                        if (this.uGrid_Details.Rows[0].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Activation != Activation.AllowEdit)
                        {
                            //if ("SectionCode".Equals(this.uGrid_Details.ActiveCell.Column.Key))
                            //{
                            //    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            //    break;
                            //}
                        }
                        else
                        {
                            if ("GoodsMakerCode".Equals(this.uGrid_Details.ActiveCell.Column.Key))
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void ReturnKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
            {
                this.uGrid_Details.Rows[0].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Activate();
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
                columnKey = this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName;
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }

            e.NextCtrl = null;

            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected)
                {
                    if (this._recBgnGdsAcs.DeleteSearchMode == false)
                    {
                        if (this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Activation == Activation.AllowEdit)
                        {
                            this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Activate();
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void ShiftKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
            {
                this.uGrid_Details.Rows[0].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Activate();
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
                columnKey = this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName;
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }

            e.NextCtrl = null;

            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected)
                {
                    if (this._recBgnGdsAcs.DeleteSearchMode == false)
                    {
                        if (this.uGrid_Details.ActiveRow.Index > 0)
                        {
                            if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activation == Activation.AllowEdit)
                            {
                                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                //this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._recBgnGdsDataTable.SalesPriceSetDivColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
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
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void SetGridGuid()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                switch (this.uGrid_Details.ActiveCell.Column.Key)
                {
                    case "InqOtherSecCd":
                    case "BrgnGoodsGrpCode":
                    case "GoodsMakerCode":
                    case "BLGoodsCode":
                    case "BLGroupCode":
                    case "CustomerCode":
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
        /// <br>Note        : 数値入力チェック処理</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
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
                int _Rketa = RecBgnGdsAcs.diverge<int>(_strResult[0] == '-', keta - priod, keta - priod - 1);
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
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(スラッシュ符号を含まず)</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <remarks>
        /// <br>Note        : 日付入力チェック処理</br>
        /// <br>Programmer  : 鹿庭 一郎</br>
        /// <br>Date        : 2015/02/09</br>
        /// </remarks>
        public bool KeyPressDateCheck(int keta, string prevVal, char key, int selstart, int sellength)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                // スラッシュ以外
                if (key != '/') return false;
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
                if (_strResult[0] == '/')
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
        /// ヘッダ部から、ENTER、TAB、↓押下時、最終明細行＋１行目のコードへフォーカスを遷移する。
        /// </summary>
        /// <remarks>
        /// <br>Note       : ヘッダ部から、ENTER、TAB、↓押下時、最終明細行＋１行目のコードへフォーカスを遷移する。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void SetFocusAfterSearch()
        {
            if (this.uGrid_Details.Rows.Count > 0)
            {
                if (this._recBgnGdsAcs.DeleteSearchMode == false)
                {
                    bool flag = false;
                    foreach (UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        if (row.Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Activation == Activation.AllowEdit)
                        {
                            flag = true;
                            row.Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Activate();
                            break;
                        }
                    }

                    if (flag == false)
                    {
                        #region 最終行の場合、新規行を追加する
                        this.NewRowAdd();
                        #endregion

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

        /// <summary>
        /// 新規行を追加する
        /// </summary>
		// ↓2015/03/02 Enter
        //private void NewRowAdd()
        internal void NewRowAdd()
		// ↑2015/03/02 Enter
        {
            string sectionCodeWk = string.Empty;
            string sectionNameWk = string.Empty;
            this.GetBaseInfo(out sectionCodeWk, out sectionNameWk);

            // 拠点
            if (sectionCodeWk == ALL_SECTION_CODE)
            {
                sectionCodeWk = ALL_SECTION_CODE;
                sectionNameWk = ALL_SECTION_NAME;
            }
            
            RecBgnGdsDataSet.RecBgnGdsRow newRow = this._recBgnGdsDataTable.NewRecBgnGdsRow();
            newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
            newRow.FilterGuid = Guid.Empty;
            newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
            newRow.InqOtherEpCd = this._enterpriseCode;
            newRow.InqOtherSecCd = sectionCodeWk;
            newRow.InqOtherSecNm = sectionNameWk;
            newRow.GoodsName = string.Empty;
            newRow.GoodsComment = string.Empty;
            newRow.DisplayDivCode = 1;
            newRow.ApplyStaDate = string.Empty;
            newRow.ApplyEndDate = string.Empty;

            this._recBgnGdsDataTable.AddRecBgnGdsRow(newRow);

            this.DetailGridInitSetting();

            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Activate();

            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            RecBgnGds recBgnGds = null;
            this._recBgnGdsAcs.CopyToRecBgnGdsFromDetailRow((RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsDataTable.Rows[this._recBgnGdsDataTable.Count - 1], ref recBgnGds);
            this._recBgnGdsAcs.NewRecBgnGdsObj = recBgnGds.Clone();
        }

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
        /// お買得商品用ユーザー設定デシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : お買得商品用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<RecBgnGdsUserSet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
                catch
                {
                    this._userSetting = new RecBgnGdsUserSet();
                }
            }
        }

        /// <summary>
        /// グリッドボタン押下処理
        /// </summary>
        private void uGrid_Details_ClickCellButton(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;

            if (cell.Column.Key == this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName)
            {
                // 商品イメージ
                Byte[] dats = new byte[0];
                if (this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value.ToString().Trim().Length != 0)
                    dats = (Byte[])this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value;

                this.OpenGoodsImgFile(out dats);

                if (dats != null)
                {
                    this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsImageColumn.ColumnName].Value = dats;

                    // 部品情報プレビュー表示
                    //this.GoodsInfoPreview(this.uGrid_Details.ActiveRow.Index);
                    this.PreviewColumnSync(this.uGrid_Details.ActiveRow.Index, cell.Column.Key);

                    this.uGrid_Details.ActiveRow.Cells[this._recBgnGdsDataTable.GoodsImageDmyColumn.ColumnName].Value = GOODSIMG_FILE_TRUE;
                }
            }
            else if (cell.Column.Key == this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName)
            {
                // 得意先個別設定画面呼び出し
                this.OpenRecBgnCustDialog(e.Cell.Row.Index);
            }
        }

        /// <summary>
        /// 得意先個別設定画面呼び出し
        /// </summary>
        public void OpenRecBgnCustDialog(int indexRow)
        {
            // --- DEL 2015/03/23 Y.Wakita ---------->>>>>
            #region 旧ソース
            //int rowNo = (int)this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Value;

            //RecBgnGdsCustInfo recBgnGdsCustInfo = null;
            //if (this._recBgnGdsAcs.RecBgnGdsCustInfoDic.ContainsKey(rowNo))
            //{
            //    recBgnGdsCustInfo = this._recBgnGdsAcs.RecBgnGdsCustInfoDic[rowNo];
            //}

            //// ディクショナリがない場合
            //if (recBgnGdsCustInfo == null)
            //{
            //    // 条件を満たしている場合、ディクショナリ作成

            //    string goodsNo = this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            //    int goodsMakerCode = int.Parse(this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value.ToString());
            //    string applyStaDate = this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value.ToString();
            //    string applyEndDate = this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Value.ToString();

            //    if (!((goodsNo == string.Empty) || (goodsMakerCode == 0) || (applyStaDate == string.Empty) || (applyEndDate == string.Empty)))
            //    {
            //        // ヘッダー
            //        RecBgnGdsDataSet.RecBgnGdsRow newRow = (RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsDataTable.Rows[indexRow];
            //        recBgnGdsCustInfo = new RecBgnGdsCustInfo();
            //        recBgnGdsCustInfo.recBgnGdsRow = newRow;
            //        // 明細
            //        RecBgnGdsDataSet.RecBgnCustDataTable recBgnCustDataTable = new RecBgnGdsDataSet.RecBgnCustDataTable();
            //        recBgnGdsCustInfo.recBgnCust = recBgnCustDataTable;
            //        this._recBgnGdsAcs.RecBgnGdsCustInfoDic.Add(rowNo, recBgnGdsCustInfo);
            //    }
            //    else
            //    {
            //        string errMsg = string.Empty;
            //        if (goodsNo == string.Empty)
            //        {
            //            errMsg += "品番";
            //        }

            //        if (goodsMakerCode == 0)
            //        {
            //            if (errMsg.Length != 0)
            //                errMsg += "、";

            //            errMsg += "品名";
            //        }

            //        if (applyStaDate == string.Empty)
            //        {
            //            if (errMsg.Length != 0)
            //                errMsg += "、";

            //            errMsg += "公開開始日";
            //        }

            //        if (applyEndDate == string.Empty)
            //        {
            //            if (errMsg.Length != 0)
            //                errMsg += "、";

            //            errMsg += "公開終了日";
            //        }

            //        TMsgDisp.Show(
            //                 this,
            //                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //                 this.Name,
            //                 errMsg + "を入力してください。",
            //                 0,
            //                 MessageBoxButtons.OK);

            //    }
            //}

            //if (recBgnGdsCustInfo != null)
            //{
            //    PMREC09021UD recBgnCustDialog = new PMREC09021UD(recBgnGdsCustInfo);
            //    DialogResult dialogResult = recBgnCustDialog.ShowDialog();
            //    if (dialogResult == DialogResult.OK)
            //    {
            //        // 戻ってきた値を設定
            //        recBgnGdsCustInfo.recBgnCust = recBgnCustDialog.RecBgnCustDataTable;

            //        this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.CustUpdFlgColumn.ColumnName].Value = 1;
            //        if (recBgnGdsCustInfo.recBgnCust.Count == 0)
            //            this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Value = string.Empty;
            //        else
            //            this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Value = GOODSIMG_FILE_TRUE;
            //    }
            //    recBgnCustDialog.Close();
            //}
            #endregion
            // --- DEL 2015/03/23 Y.Wakita ----------<<<<<

            // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
            // 必須項目チェック
            string goodsNo = this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString();
            int goodsMakerCode = int.Parse(this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value.ToString());
            string applyStaDate = this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value.ToString();
            string applyEndDate = this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Value.ToString();

            if ((goodsNo == string.Empty) || (goodsMakerCode == 0) || (applyStaDate == string.Empty) || (applyEndDate == string.Empty))
            {
                string errMsg = string.Empty;
                if (goodsNo == string.Empty)
                {
                    errMsg += "品番";
                }

                if (goodsMakerCode == 0)
                {
                    if (errMsg.Length != 0)
                        errMsg += "、";

                    errMsg += "品名";
                }

                if (applyStaDate == string.Empty)
                {
                    if (errMsg.Length != 0)
                        errMsg += "、";

                    errMsg += "公開開始日";
                }

                if (applyEndDate == string.Empty)
                {
                    if (errMsg.Length != 0)
                        errMsg += "、";

                    errMsg += "公開終了日";
                }

                TMsgDisp.Show(
                         this,
                         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                         this.Name,
                         errMsg + "を入力してください。",
                         0,
                         MessageBoxButtons.OK);
                return;
            }

            int rowNo = (int)this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.RowNoColumn.ColumnName].Value;

            RecBgnGdsCustInfo recBgnGdsCustInfo = null;
            if (this._recBgnGdsAcs.RecBgnGdsCustInfoDic.ContainsKey(rowNo))
            {
                recBgnGdsCustInfo = this._recBgnGdsAcs.RecBgnGdsCustInfoDic[rowNo];
            }

            // ディクショナリがない場合
            if (recBgnGdsCustInfo == null)
            {
                // ヘッダー
                RecBgnGdsDataSet.RecBgnGdsRow newRow = (RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsDataTable.Rows[indexRow];
                recBgnGdsCustInfo = new RecBgnGdsCustInfo();
                recBgnGdsCustInfo.recBgnGdsRow = newRow;
                // 明細
                RecBgnGdsDataSet.RecBgnCustDataTable recBgnCustDataTable = new RecBgnGdsDataSet.RecBgnCustDataTable();
                recBgnGdsCustInfo.recBgnCust = recBgnCustDataTable;
                this._recBgnGdsAcs.RecBgnGdsCustInfoDic.Add(rowNo, recBgnGdsCustInfo);
            }

            if (recBgnGdsCustInfo != null)
            {
                PMREC09021UD recBgnCustDialog = new PMREC09021UD(recBgnGdsCustInfo);
                DialogResult dialogResult = recBgnCustDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    // 戻ってきた値を設定
                    recBgnGdsCustInfo.recBgnCust = recBgnCustDialog.RecBgnCustDataTable;

                    this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.CustUpdFlgColumn.ColumnName].Value = 1;
                    if (recBgnGdsCustInfo.recBgnCust.Count == 0)
                        this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Value = string.Empty;
                    else
                        this.uGrid_Details.Rows[indexRow].Cells[this._recBgnGdsDataTable.RecBgnCustColumn.ColumnName].Value = GOODSIMG_FILE_TRUE;
                }
                recBgnCustDialog.Close();
            }
            // --- ADD 2015/03/23 Y.Wakita----------<<<<<
        }

        /// <summary>
        /// 明細展開処理
        /// </summary>
        public bool GetUnitPrice(int rowIndex, string date, out long wkMkrSuggestRtPric, out long wkListPrice, out long wkUnitPrice)
        {
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

            string sectionCode = string.Empty;
            string msg = string.Empty;
            int customerCode = 0;
            bool uPricDiv = false;  // ADD 2015/03/26 Y.Wakita

            wkMkrSuggestRtPric = 0;
            wkListPrice = 0;
            wkUnitPrice = 0;

            // --- ADD 2015/03/04 Y.Wakita Redmine#319 ---------->>>>>
            // 拠点
            sectionCode = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value.ToString();
            // --- ADD 2015/03/04 Y.Wakita Redmine#319 ----------<<<<<

            // 商品情報
            object goodsUnitDataObj = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.goodsUnitDataColumn.ColumnName].Value;
            goodsUnitData = goodsUnitDataObj as GoodsUnitData;

            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            object mkrSuggestRtPricListObj = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.mkrSuggestRtPricListColumn.ColumnName].Value;
            mkrSuggestRtPricList = mkrSuggestRtPricListObj as Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>;
            
            object mkrSuggestRtPricUListObj = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.mkrSuggestRtPricUListColumn.ColumnName].Value;
            mkrSuggestRtPricUList = mkrSuggestRtPricUListObj as Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>;
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

            // 公開開始日
            DateTime startDate = DateTime.Parse(date);

            // 価格取得
            // --- UPD 2015/03/04 Y.Wakita Redmine#319 ---------->>>>>
            //Calculator.GetUnitPrice(customerCode
            //                      , goodsUnitData
            //                      , startDate
            //                      , ALL_SECTION_CODE
            //                      , out wkMkrSuggestRtPric
            //                      , out wkListPrice
            //                      , out wkUnitPrice);
            // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
            //Calculator.GetUnitPrice(customerCode
            //                      , goodsUnitData
            //                      , startDate
            //                      , sectionCode
            //                      , out wkMkrSuggestRtPric
            //                      , out wkListPrice
            //                      , out wkUnitPrice);
            Calculator.GetUnitPrice(customerCode
                                  , goodsUnitData
                                  , startDate
                                  , sectionCode
                                  , mkrSuggestRtPricList
                                  , mkrSuggestRtPricUList
                                  , out uPricDiv    // ADD 2015/03/26 Y.Wakita
                                  , out wkMkrSuggestRtPric
                                  , out wkListPrice
                                  , out wkUnitPrice);
            // --- UPD 2015/03/25 Y.Wakita ----------<<<<<

            // --- ADD 2015/03/26 Y.Wakita ---------->>>>>
            RecBgnGdsDataSet.RecBgnGdsRow row = this._recBgnGdsDataTable[rowIndex];
            int retPartsFlag = 0;
            int status = this._recBgnGdsAcs.GetPartsArticleInfo(goodsUnitData, uPricDiv, out retPartsFlag);
            row.ModelFitDiv = (short)retPartsFlag;     // 適合車種区分
            // --- ADD 2015/03/26 Y.Wakita ----------<<<<<

            return true;
        }

        /// <summary>
        /// 拠点チェック処理
        /// </summary>
        public bool SectionCheck_Detail(string sectionCode, int rowIndex)
        {
            string errMsg;
            SecInfoSet retSectionInfo;

            bool checkResult = this._recBgnGdsAcs.CheckSection(sectionCode, false, out errMsg, out retSectionInfo);
            if (checkResult)
            {
                Int32 chkSectionCode = 0;
                Int32.TryParse(sectionCode, out chkSectionCode);
                if (chkSectionCode == 0)
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value = ALL_SECTION_CODE;  //拠点コード
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Value = ALL_SECTION_NAME;  //拠点略称
                    this._swSectionInfo = sectionCode;
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value = retSectionInfo.SectionCode.Trim().PadLeft(2, '0'); //拠点コード
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecNmColumn.ColumnName].Value = retSectionInfo.SectionGuideNm; //拠点略称
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

                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnGdsDataTable.InqOtherSecCdColumn.ColumnName].Value = this._swSectionInfo.ToString().PadLeft(2, '0');
            }
            return checkResult;
        }

        /// <summary>
        /// グリッド セル変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;

            if (e.Cell.Column.Key == this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName)
            {
                int inputValue = 0;
                // 入力値を取得
                Int32.TryParse(e.Cell.Text, out inputValue);

                // --- DEL 2015/03/16 Y.Wakita 障害 ---------->>>>>
                #region 削除
                //if (inputValue == 0)
                //{
                //    // チェックOFF

                //    // お買得商品ｸﾞﾙｰﾌﾟ
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = 0;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.NoEdit;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;

                //    // お買得商品ｸﾞﾙｰﾌﾟ名
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = string.Empty;
                //    // メーカー価格
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value = 0;
                //    // 標準価格
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.ListPriceColumn.ColumnName].Value = 0;

                //    // 売価率
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value = 0;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.NoEdit;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;

                //    // 売単価
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Value = 0;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.NoEdit;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;
                //}
                //else
                //{
                //    // チェックON
                //    // 価格取得
                //    this.SetUnitPrice(e.Cell.Row.Index);
                //    // お買得商品ｸﾞﾙｰﾌﾟ
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;

                //    // 売価率
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.AllowEdit;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;

                //    // 売単価
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.AllowEdit;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor = Color.Empty;
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
                //}

                //// 部品情報プレビュー表示
                //this.PreviewColumnSync(e.Cell.Row.Index, e.Cell.Column.Key);
                //this._rowIndex = e.Cell.Row.Index;
                #endregion
                // --- DEL 2015/03/16 Y.Wakita 障害 ----------<<<<<
                // --- ADD 2015/03/16 Y.Wakita 障害 ---------->>>>>
                this.ChangeDisplayDiv(e.Cell.Row.Index, inputValue);
                // --- ADD 2015/03/16 Y.Wakita 障害 ----------<<<<<
            }
        }

        /// <summary>
        /// グリッド 行移動時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_BeforeRowActivate(object sender, RowEventArgs e)
        {

            // 品番
            this._swGoodsNo = e.Row.Cells[this._recBgnGdsDataTable.GoodsNoColumn.ColumnName].Value.ToString().Trim();
            // ﾒｰｶｰ
            this._swGoodsMakerCd = (Int32)e.Row.Cells[this._recBgnGdsDataTable.GoodsMakerCodeColumn.ColumnName].Value;
            // 公開開始日
            this._swApplyStaDate = e.Row.Cells[this._recBgnGdsDataTable.ApplyStaDateColumn.ColumnName].Value.ToString();
            // 公開終了日
            this._swApplyEndDate = e.Row.Cells[this._recBgnGdsDataTable.ApplyEndDateColumn.ColumnName].Value.ToString();

        }

        /// <summary>
        /// グリッド セル非活性時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            try
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;

                UltraGridCell cell = this.uGrid_Details.ActiveCell;

                switch (cell.Column.Key)
                {
                    case "ApplyStaDate":    // 公開開始日
                        if (cell.Text == this._swApplyStaDate) break;

                        // 価格取得
                        this.SetUnitPrice(cell.Row.Index);

                        // 個別設定削除
                        this.DelRecBgnGdsCustInfo(cell.Row.Index);

                        this._swApplyStaDate = cell.Value.ToString();

                        this.PreviewColumnSync(cell.Row.Index, cell.Column.Key);
                        break;
                    
                    case "ApplyEndDate":    // 公開終了日
                        if (cell.Text == this._swApplyEndDate) break;

                        this._swApplyEndDate = cell.Value.ToString();

                        this.PreviewColumnSync(cell.Row.Index, cell.Column.Key);
                        break;
                }
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
            }
        }

        /// <summary>
        /// グリッド 行非活性時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_BeforeRowDeactivate(object sender, CancelEventArgs e)
        {
            if (_rowIndex < 0) return;

            UltraGridCell cell_RowNo = this.uGrid_Details.Rows[_rowIndex].Cells[this._recBgnGdsDataTable.RowNoColumn.ColumnName];
            UltraGridCell cell_RowDel = this.uGrid_Details.Rows[_rowIndex].Cells[this._recBgnGdsDataTable.RowDeleteFlgColumn.ColumnName];

            if (cell_RowDel.Text == "0")
            {
                // 選択行の№の色を変える
                cell_RowNo.Appearance.BackColor = Color.Empty;
                cell_RowNo.Appearance.BackColor2 = Color.Empty;
                cell_RowNo.Appearance.BackColorDisabled = Color.Empty;
                cell_RowNo.Appearance.BackColorDisabled2 = Color.Empty;
            }
        }

        // --- ADD 2015/03/16 Y.Wakita 障害 ---------->>>>>
        /// <summary>
        /// 公開区分変更時イベント
        /// </summary>
        /// <param name="index"></param>
        /// <param name="inputValue"></param>
        public void ChangeDisplayDiv(int index, int inputValue)
        {
            if (inputValue == 0)
            {
                // チェックOFF

                // お買得商品ｸﾞﾙｰﾌﾟ
                // --- DEL 2015/03/16 Y.Wakita 要望 ---------->>>>>
                //this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = 0;
                // --- DEL 2015/03/16 Y.Wakita 要望 ----------<<<<<
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.NoEdit;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;

                // --- DEL 2015/03/16 Y.Wakita 要望 ---------->>>>>
                //// お買得商品ｸﾞﾙｰﾌﾟ名
                //this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = string.Empty;
                //// メーカー価格
                //this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.MkrSuggestRtPricColumn.ColumnName].Value = 0;
                //// 標準価格
                //this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.ListPriceColumn.ColumnName].Value = 0;
                // --- DEL 2015/03/16 Y.Wakita 要望 ----------<<<<<

                // 売価率
                // --- DEL 2015/03/16 Y.Wakita 要望 ---------->>>>>
                //this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Value = 0;
                // --- DEL 2015/03/16 Y.Wakita 要望 ----------<<<<<
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.NoEdit;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;

                // 売単価
                // --- DEL 2015/03/16 Y.Wakita 要望 ---------->>>>>
                //this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Value = 0;
                // --- DEL 2015/03/16 Y.Wakita 要望 ----------<<<<<
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.NoEdit;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor = ct_DISABLE_COLOR;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor2 = ct_DISABLE_COLOR;
            }
            else
            {
                // チェックON
                // --- DEL 2015/03/16 Y.Wakita 要望 ---------->>>>>
                //// 価格取得
                //this.SetUnitPrice(index);
                // --- DEL 2015/03/16 Y.Wakita 要望 ----------<<<<<
                // お買得商品ｸﾞﾙｰﾌﾟ
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor = Color.Empty;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Appearance.BackColor2 = Color.Empty;

                // 売価率
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.AllowEdit;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor = Color.Empty;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitCalcRateColumn.ColumnName].Appearance.BackColor2 = Color.Empty;

                // 売単価
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Activation = Activation.AllowEdit;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor = Color.Empty;
                this.uGrid_Details.Rows[index].Cells[this._recBgnGdsDataTable.UnitPriceColumn.ColumnName].Appearance.BackColor2 = Color.Empty;
            }

            // 部品情報プレビュー表示
            this.PreviewColumnSync(index, this._recBgnGdsDataTable.DisplayDivCodeColumn.ColumnName);
            this._rowIndex = index;       
        }
        // --- ADD 2015/03/16 Y.Wakita 障害 ----------<<<<<
        // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
        /// <summary>
        /// CheckCustDisplayDiv
        /// </summary>
        /// <param name="RowIndex"></param>
        /// <returns></returns>
        public bool CheckCustDisplayDiv(int RowIndex)
        {
            bool ret = false;

            if (this._recBgnGdsAcs.RecBgnGdsCustInfoDic.Count == 0) return ret;

            RecBgnGdsCustInfo recBgnGdsCustInfo = null;
            if (this._recBgnGdsAcs.RecBgnGdsCustInfoDic.ContainsKey(RowIndex))
            {
                recBgnGdsCustInfo = this._recBgnGdsAcs.RecBgnGdsCustInfoDic[RowIndex];
            }

            // ディクショナリがない場合
            if (recBgnGdsCustInfo == null)
            {
                return ret;
            }
            else
            {
                foreach (RecBgnGdsDataSet.RecBgnCustRow RecBgnCustRow in recBgnGdsCustInfo.recBgnCust)
                {
                    if (RecBgnCustRow.DisplayDivCode == 1)
                    {
                        ret = true;
                        break;
                    }
                }
            }

            return ret;
        }
        // --- ADD 2015/03/23 Y.Wakita ----------<<<<<

        // --- ADD 2015/03/24 Y.Wakita ---------->>>>>
        /// <summary>
        /// uGrid_Details_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Recapture"].SharedProps.Enabled = false;
            this.uButton_Recapture.Enabled = false;
        }
        // --- ADD 2015/03/24 Y.Wakita ----------<<<<<
    }

    # region RecBgnGdsUserSet
    /// <summary>
    /// お買得商品設定マスタ用グリッド設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : お買得商品設定マスタ用グリッド設定クラス</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RecBgnGdsUserSet
    {
        // 出力形式
        private int _outputStyle;

        // 明細グリッドカラムリスト
        private List<ColumnInfo> _detailColumnsList;

        // 明細グリッド自動サイズ調整
        private bool _autoAdjustDetail;

        # region コンストラクタ
        /// <summary>
        /// お買得商品設定マスタ用グリッド設定クラス
        /// </summary>
        public RecBgnGdsUserSet()
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
    # endregion

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
