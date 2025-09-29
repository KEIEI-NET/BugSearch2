//****************************************************************************//
// システム         : PM.NS                                                   //
// プログラム名称   : 商品バーコード一括登録                                  //
// プログラム概要   : 商品バーコード一括登録 UIクラス                 　　    //
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.                       //
//============================================================================//
// 履歴                                                                       //
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊                                 //
// 作 成 日  2017/06/12  修正内容 : 新規作成                                  //
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 3H 楊善娟                                  //
// 作 成 日  2017/09/22  修正内容 : ハンディ対応（2次）商品バーコード一括登録の改良//
//----------------------------------------------------------------------------//
// 管理番号  11770175-00 作成担当 : 呉元嘯                                    //
// 修 正 日  2021/11/03  修正内容 : PJMIT-1499 OUT OF MEMORY対応(4GB対応)     //
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Infragistics.Win.UltraWinGrid;
using System.IO;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品バーコード一括登録 UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 商品バーコード一括登録 UIクラス</br>
    /// <br>Programmer  : 3H 張小磊</br>
    /// <br>Date        : 2017/06/12</br>
    /// <br>Update Note: 2021/11/03 呉元嘯</br>
    /// <br>管理番号   : 11770175-00</br>
    /// <br>             PJMIT-1499　OUT OF MEMORY対応(4GB対応)</br>
    /// </remarks>
    public partial class PMHND09210UA : Form
    {
        # region [private field]
        /// <summary>拠点アクセス</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        /// <summary>倉庫アクセス</summary>
        private WarehouseAcs _warehouseAcs;
        /// <summary>メーカーアクセス</summary>
        private MakerAcs _makerAcs;
        /// <summary>商品バーコードアクセス</summary>
        private GoodsBarCodeRevnAcs _goodsBarCodeRevnAcs;
        // 前回入力検索条件情報(ヘッダ用)
        private GoodsBarCodeRevnSearchPara _prevHeaderInfo;

        private string _enterpriseCode;             // 企業コード
        private ImageList _imageList16 = null;									// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;		// 検索ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;		// 取消ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;		// 保存ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _inputTextButton;		// 取込ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _extractTextButton;		// テキストボタン

        /// <summary>画面コントロールスキン</summary>
        private ControlScreenSkin _controlScreenSkin;
        /// <summary>商品バーコードデータテーブル</summary>
        private DataTable _goodsBarCodeDt = null;
        /// <summary>商品バーコードデータビュー</summary>
        private DataView _goodsBarCodeView;
        // 商品バーコード関連付けディクショナリ
        private Dictionary<string, GoodsBarCodeRevn> _goodsBarCodeRevnDic;

        // 前選択行インデックス(背景色設定用)
        private List<int> _beforeSelectRowIndexList = new List<int>();

        /// <summary>グリッド設定制御クラス</summary>
        private GridStateController _gridStateController;

        /// <summary>テキスト出力用設定XMLからの取得設定</summary>
        private GoodsBarCodeRevnExtractTextUserConst _userSetting;

        # endregion

        # region [private const]
        // クラスID
        private const string ct_ClassID = "PMHND09210UA";
        // クラス名称
        private const string ct_ClassName = "商品バーコード一括登録";
        // グリッド表示最大件数：5000
        private const int ct_MaxCount = 5000;
        // CsvTitle出力用
        private string[] ctCsvTitle = new string[] { "GoodsMakerCd", "GoodsNo", "GoodsBarCode", "GoodsBarCodeKind", "MakerName", "GoodsName"};
        // --- ADD 2021/11/03 呉元嘯 PJMIT-1499対応 ------>>>>> 
        // メモリアウト時のエラーメッセージ
        private const string INFO_MEMORYOUT_MSG = "検索する商品数が多すぎます。検索条件を追加して、再度検索を行って下さい。";
        // --- ADD 2021/11/03 呉元嘯 PJMIT-1499対応 ------<<<<<
        # endregion

        # region [private readonly]
        // 必須入力項目バックカラー
        private readonly Color ct_EssentialColor = Color.FromArgb(179, 219, 231);
        // 非必須入力項目バックカラー
        private readonly Color ct_OptionalColor = Color.FromArgb(255, 255, 255);
        # endregion

        # region [コンストラクタ]
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : デフォルトコンストラクタ</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public PMHND09210UA()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            this._undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
            this._inputTextButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_InPutText"];
            this._extractTextButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"];
            this._controlScreenSkin = new ControlScreenSkin();
            // グリッド設定制御
            this._gridStateController = new GridStateController();
            // 前回入力検索条件情報(ヘッダ用)
            this._prevHeaderInfo = new GoodsBarCodeRevnSearchPara();
            // 商品バーコードアクセス
            this._goodsBarCodeRevnAcs = new GoodsBarCodeRevnAcs();
            // 商品バーコード関連付けディクショナリ
            this._goodsBarCodeRevnDic = new Dictionary<string, GoodsBarCodeRevn>();
        }
        # endregion

        # region [初期化処理]

        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            // 終了ボタン
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // 検索ボタン
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // クリアボタン
            this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // 保存ボタン
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            // 取込ボタン
            this._inputTextButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVTAKING;
            // テキスト出力ボタン
            this._extractTextButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            // 拠点ガイド
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // 倉庫ガイド
            this.uButton_WarehouseGuide.ImageList = this._imageList16;
            this.uButton_WarehouseGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // メーカーガイド
            this.uButton_GoodsMakerGuide.ImageList = this._imageList16;
            this.uButton_GoodsMakerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // 行削除ボタン
            this.uButton_RowGoodsDelete.ImageList = this._imageList16;
            this.uButton_RowGoodsDelete.Appearance.Image = (int)Size16_Index.ROWDELETE;
            // 行復活ボタン
            this.uButton_RowGoodsRevive.ImageList = this._imageList16;
            this.uButton_RowGoodsRevive.Appearance.Image = (int)Size16_Index.RENEWAL;

            // テキスト出力ボタンのVisibleをセット
            this.SetExtractToolButtonVisible();
            // 保存ボタン
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
            // テキスト出力ボタン
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = false;

            // 削除ボタンを不可にする
            this.uButton_RowGoodsDelete.Enabled = false;
            // 復活ボタンを不可にする
            this.uButton_RowGoodsRevive.Enabled = false;

        }

        /// <summary>
        /// テキスト出力関連ボタンの利用可否セット処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力関連ボタンの利用可否セット処理</br>
        /// <br>Programmer  : 3H 張小磊</br>
        /// <br>Date        : 2017/06/12</br>
        /// </remarks>
        private void SetExtractToolButtonVisible()
        {
            // オプションコードのテキスト出力を参照
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus textOutputPs;
            textOutputPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            if (textOutputPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                // テキスト出力ボタン表示
                // Enableは検索後にtrueにする
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Visible = true;
            }
            else
            {
                // テキスト出力ボタン非表示
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Visible = false;
            }
        }

        /// <summary>
        /// 画面ヘッダ初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面ヘッダ初期設定処理します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br>Update Note: 2017/09/22 3H 楊善娟</br>
        /// <br>管理番号   : 11370074-00 ハンディ対応（2次）</br>
        /// <br>             商品バーコード一括登録の改良</br>
        /// </remarks>
        private void HeaderInitialSetting()
        {
            // 在庫区分 0:在庫のみ
            this.tEdit_StockDiv.Text = "0";
            this.tEdit_StockDiv.Appearance.BackColor = this.ct_EssentialColor;

            // 登録区分 0:全て
            this.tEdit_HaveBarCodeDiv.Text = "0";
            this.tEdit_HaveBarCodeDiv.Appearance.BackColor = this.ct_EssentialColor;

            // メーカー
            this.tNedit_GoodsMakerCd.Clear();
            //this.tNedit_GoodsMakerCd.Appearance.BackColor = this.ct_EssentialColor; // --- DEL 3H 楊善娟 2017/09/22
            this.uLabel_MakerName.Text = string.Empty;

            // 品番
            this.tEdit_GoodsNo.Text = string.Empty;
            this.tEdit_GoodsNo.Appearance.BackColor = this.ct_OptionalColor;

            // 拠点
            this.tEdit_SectionCode.Text = string.Empty;
            this.uLabel_SectionName.Text = string.Empty;
            this.tEdit_SectionCode.Enabled = true;
            this.uButton_SectionGuide.Enabled = true;

            // 倉庫
            this.tEdit_WarehouseCode.Text = string.Empty;
            this.tEdit_WarehouseCode.Appearance.BackColor = this.ct_EssentialColor;
            this.uLabel_WarehouseName.Text = string.Empty;
            this.tEdit_WarehouseCode.Enabled = true;
            this.uButton_WarehouseGuide.Enabled = true;

            // 在庫区分
            this.tEdit_StockDiv.Focus();

            // 前回入力検索条件情報(ヘッダ用)
            this._prevHeaderInfo = new GoodsBarCodeRevnSearchPara();
        }

        /// <summary>
        /// グリッド初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド初期設定処理します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GridInitialSetting()
        {
            // 商品バーコードデータテーブル
            GoodsBarCodeRevnTbl.CreateDataTable(ref _goodsBarCodeDt);
            // 商品バーコードデータビュー
            _goodsBarCodeView = new DataView(_goodsBarCodeDt);
            GoodsBarCodeRevn_Grid.DataSource = _goodsBarCodeView;
            // グリッド設定制御
            _gridStateController.SetGridStateToGrid(ref this.GoodsBarCodeRevn_Grid);
        }

        # endregion

        # region ツールバーボタンイベント処理
        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ツールバーボタンクリックイベント</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        CloseProcess();
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // 検索処理
                        SearchProcess();
                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // クリア処理
                        ClearProcess();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // 保存処理
                        SaveProcess();
                        break;
                    }
                case "ButtonTool_InPutText":
                    {
                        // 取込処理
                        InputTextProcess();
                        break;
                    }
                case "ButtonTool_ExtractText":
                    {
                        // テキスト出力処理
                        ExtractTextProcess();
                        break;
                    }
            }
        }

        # region 終了処理
        /// <summary>
        /// フォーム終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : フォーム終了処理します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void CloseProcess()
        {
            // 編集中のデータが存在状況
            if (GridDataIsChange())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                    "画面を終了処理しますか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            // 画面終了
            this.Close();
        }
        # endregion

        # region 検索処理
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検索処理します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br>Update Note: 2021/11/03 呉元嘯</br>
        /// <br>管理番号   : 11770175-00</br>
        /// <br>             PJMIT-1499　OUT OF MEMORY対応(4GB対応)</br> 
        /// </remarks>
        private void SearchProcess()
        {
            // 検索条件をチェック
            if (!CheckSearchPara()) return;

            // 編集中のデータが存在状況
            if (GridDataIsChange())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                    "破棄してもよろしいですか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = false;
            // 削除ボタンを不可にする
            this.uButton_RowGoodsDelete.Enabled = false;
            // 復活ボタンを不可にする
            this.uButton_RowGoodsRevive.Enabled = false;
            // 共通処理中画面生成
            SFCMN00299CA form = new SFCMN00299CA();
            try
            {
                // 共通処理中画面プロパティ設定
                form.Title = "抽出中";                            // 画面のタイトル部分に表示する文字列
                form.Message = "商品バーコードデータの読込み中です";    // 画面のプログレスバーの上に表示する文字列
                form.DispCancelButton = false;                      // キャンセルボタン押下による中断機能ＯＮ（デフォルトはＯＦＦ）

                // 共通処理中画面表示
                form.Show();
                // 商品バーコードデータList
                List<GoodsBarCodeRevn> goodsBarCodeRevnList = new List<GoodsBarCodeRevn>();
                // 商品バーコード検索条件
                GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara = new GoodsBarCodeRevnSearchPara();
                // 商品バーコード検索条件を取る
                GetSearchParaFromScreen(out goodsBarCodeRevnSearchPara);
                // 商品バーコード関連付け検索処理
                int status = _goodsBarCodeRevnAcs.Search(out goodsBarCodeRevnList, goodsBarCodeRevnSearchPara);

                // 共通処理中画面終了
                if (form != null) form.Close();
                
                // グリッドデータクリア処理
                ClearGridDataSource();

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 商品バーコード関連付けデータテープル
                    SetListToDataTable(goodsBarCodeRevnList);
                    // 取得データをグリッドに表示
                    GoodsBarCodeRevn_Grid.DataSource = _goodsBarCodeView;
                    // グリッド設定制御
                    _gridStateController.SetGridStateToGrid(ref this.GoodsBarCodeRevn_Grid);

                    this.GoodsBarCodeRevn_Grid.Focus();
                    this.GoodsBarCodeRevn_Grid.Rows[0].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activate();
                    this.GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = true;
                    // 削除ボタンを可にする
                    this.uButton_RowGoodsDelete.Enabled = true;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {

                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "該当データがありません", status, MessageBoxButtons.OK);
                }
                else
                {
                    // --- ADD 2021/11/03 呉元嘯 PJMIT-1499対応 ------>>>>>
                    //メモリアウト発生した場合、メッセージを出す
                    if (this._goodsBarCodeRevnAcs.MemoryOutFlag && status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        Form memoryOutForm = new Form();
                        memoryOutForm.TopMost = true;
                        TMsgDisp.Show(memoryOutForm, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), INFO_MEMORYOUT_MSG, status, MessageBoxButtons.OK);
                        memoryOutForm.TopMost = false;
                    }
                    else
                    {
                    // --- ADD 2021/11/03 呉元嘯 PJMIT-1499対応 ------<<<<<
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "検索処理に失敗しました", status, MessageBoxButtons.OK);
                    }// ADD 2021/11/03 呉元嘯 PJMIT-1499対応
                }
            }
            catch
            {
                // 共通処理中画面終了
                if (form != null) form.Close();

                // グリッドデータクリア処理
                ClearGridDataSource();
                
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.ToString(), "検索処理に失敗しました", 9, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 検索条件をチェック
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面入力情報より検索条件をチェック</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br>Update Note: 2017/09/22 3H 楊善娟</br>
        /// <br>管理番号   : 11370074-00 ハンディ対応（2次）</br>
        /// <br>             商品バーコード一括登録の改良</br>
        /// </remarks>
        private bool CheckSearchPara()
        {
            // 在庫区分
            if (string.IsNullOrEmpty(tEdit_StockDiv.DataText.Trim()))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "在庫区分を入力してください。", 9, MessageBoxButtons.OK);
                tEdit_StockDiv.Focus();
                return false;
            }
            // 登録区分
            if (string.IsNullOrEmpty(tEdit_HaveBarCodeDiv.DataText.Trim()))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "登録区分を入力してください。", 9, MessageBoxButtons.OK);
                tEdit_HaveBarCodeDiv.Focus();
                return false;
            }
            // --- DEL 3H 楊善娟 2017/09/22---------->>>>>
            //// メーカーコード
            //if (string.IsNullOrEmpty(tNedit_GoodsMakerCd.DataText.Trim()))
            //{
            //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "メーカーコードを入力してください。", 9, MessageBoxButtons.OK);
            //    tNedit_GoodsMakerCd.Focus();
            //    return false;
            //}
            // --- DEL 3H 楊善娟 2017/09/22----------<<<<<
            // 在庫区分:[全て]
            if (tEdit_StockDiv.DataText.Trim() == "1")
            {
                // --- ADD 3H 楊善娟 2017/09/22---------->>>>>
                // メーカーコード
                if (string.IsNullOrEmpty(tNedit_GoodsMakerCd.DataText.Trim()))
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "メーカーコードを入力してください。", 9, MessageBoxButtons.OK);
                    tNedit_GoodsMakerCd.Focus();
                    return false;
                }
                // --- ADD 3H 楊善娟 2017/09/22----------<<<<<

                if (string.IsNullOrEmpty(tEdit_GoodsNo.DataText.Trim()))
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "品番を入力してください。", 9, MessageBoxButtons.OK);
                    tEdit_GoodsNo.Focus();
                    return false;
                }
            }
            // 在庫区分:[在庫のみ]
            else
            {
                // 倉庫
                if (string.IsNullOrEmpty(tEdit_WarehouseCode.DataText.Trim()))
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "倉庫コードを入力してください。", 9, MessageBoxButtons.OK);
                    tEdit_WarehouseCode.Focus();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 検索条件を取る
        /// </summary>
        /// <param name="goodsBarCodeRevnSearchPara">検索条件</param>
        /// <remarks>
        /// <br>Note       : 画面入力情報より検索条件を取る</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GetSearchParaFromScreen(out GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara)
        {
            goodsBarCodeRevnSearchPara = new GoodsBarCodeRevnSearchPara();

            // 在庫区分
            if (!string.IsNullOrEmpty(tEdit_StockDiv.Text.Trim()))
            {
                goodsBarCodeRevnSearchPara.StockDiv = int.Parse(tEdit_StockDiv.Text.Trim());
            }
            else
            {
                goodsBarCodeRevnSearchPara.StockDiv = 1;
            }
            // 登録区分
            if (!string.IsNullOrEmpty(tEdit_HaveBarCodeDiv.Text.Trim()))
            {
                goodsBarCodeRevnSearchPara.HaveBarCodeDiv = int.Parse(tEdit_HaveBarCodeDiv.Text.Trim());
            }
            else
            {
                goodsBarCodeRevnSearchPara.HaveBarCodeDiv = 0;
            }
            // 企業コード
            goodsBarCodeRevnSearchPara.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 商品メーカーコード
            goodsBarCodeRevnSearchPara.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            // 品番
            goodsBarCodeRevnSearchPara.GoodsNo = this.tEdit_GoodsNo.DataText;
            // 倉庫コード
            goodsBarCodeRevnSearchPara.WarehouseCode = this.tEdit_WarehouseCode.DataText;
            // 管理拠点コード
            goodsBarCodeRevnSearchPara.SectionCode = this.tEdit_SectionCode.DataText;
        }

        /// <summary>
        /// 商品バーコード関連付けデータList ⇒ データテープル
        /// </summary>
        /// <param name="goodsBarCodeRevnList">商品バーコード関連付けデータList</param>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けデータList ⇒ データテープル</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetListToDataTable(List<GoodsBarCodeRevn> goodsBarCodeRevnList)
        {
            if (goodsBarCodeRevnList != null && goodsBarCodeRevnList.Count > 0)
            {
                // 表示件数
                int showCount = ct_MaxCount;
                if (goodsBarCodeRevnList.Count < ct_MaxCount)
                {
                    showCount = goodsBarCodeRevnList.Count;
                }

                for (int i = 0; i < showCount; i++)
                {
                    DataRow row = _goodsBarCodeDt.NewRow();
                    // 行番号
                    row[GoodsBarCodeRevnTbl.ct_Col_RowNo] = i + 1;
                    // 商品番号
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsNo] = goodsBarCodeRevnList[i].GoodsNo;
                    // 商品メーカーコード
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd] = goodsBarCodeRevnList[i].GoodsMakerCd.ToString("0000");
                    // メーカー名称
                    row[GoodsBarCodeRevnTbl.ct_Col_MakerName] = goodsBarCodeRevnList[i].MakerName;
                    // 商品名称
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsName] = goodsBarCodeRevnList[i].GoodsName;
                    // 商品バーコード種別
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind] = goodsBarCodeRevnList[i].GoodsBarCodeKind;
                    // 商品バーコード
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode] = goodsBarCodeRevnList[i].GoodsBarCode;
                    // 削除区分 0:削除なし行
                    row[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv] = "0";
                    _goodsBarCodeDt.Rows.Add(row);
                    // ディクショナリのキー
                    string dicKey = goodsBarCodeRevnList[i].GoodsMakerCd.ToString("0000") + "_" + goodsBarCodeRevnList[i].GoodsNo;
                    if (!_goodsBarCodeRevnDic.ContainsKey(dicKey))
                    {
                        // データをディクショナリにセット
                        _goodsBarCodeRevnDic.Add(dicKey, goodsBarCodeRevnList[i]);
                    }
                }
            }
        }

        # endregion

        # region クリア処理
        /// <summary>
        /// クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : クリア処理します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void ClearProcess()
        {
            // 編集中のデータが存在状況
            if (GridDataIsChange())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                    "初期状態に戻しますか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            // 画面ヘッダ初期設定処理
            HeaderInitialSetting();
            // グリッドデータクリア処理
            ClearGridDataSource();
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = false;
            // 削除ボタンを不可にする
            this.uButton_RowGoodsDelete.Enabled = false;
            // 復活ボタンを不可にする
            this.uButton_RowGoodsRevive.Enabled = false;
        }

        /// <summary>
        /// グリッドデータクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドデータクリア処理します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void ClearGridDataSource()
        {
            // データテーブルクリア
            if (_goodsBarCodeDt != null)
            {
                _goodsBarCodeDt.Rows.Clear();
            }
            // ディクショナリクリア
            if (_goodsBarCodeRevnDic != null)
            {
                _goodsBarCodeRevnDic.Clear();
            }
        }
        # endregion

        # region 保存処理
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 保存処理します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SaveProcess()
        {
            if (this.GoodsBarCodeRevn_Grid.ActiveCell != null && this.GoodsBarCodeRevn_Grid.ActiveCell.IsInEditMode)
            {
                // 編集モードを解除する
                this.GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.ExitEditMode);
            }
            // 保存商品バーコード関連付けデータ　false:保存
            SaveGoodsBarCodeRevnProcess(false);
        }

        /// <summary>
        /// 保存商品バーコード関連付けデータ
        /// </summary>
        /// <returns>保存処理の結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けデータを保存します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int SaveGoodsBarCodeRevnProcess(bool outPutDiv)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            List<GoodsBarCodeRevn> saveList = null;
            List<GoodsBarCodeRevn> deleteList = null;
            try
            {
                // 画面から保存用データを取る
                GetSaveGoodsBarCodeRevnDataFromScreen(out saveList, out deleteList);
                if ((saveList != null && saveList.Count > 0)
                    || (deleteList != null && deleteList.Count > 0))
                {
                    // 商品バーコード関連付けデータの保存処理
                    status = _goodsBarCodeRevnAcs.WriteBySave(saveList, deleteList);
                }
                else
                {
                    // 保存
                    if (!outPutDiv)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "更新対象のデータが存在しません。", status, MessageBoxButtons.OK);
                        return status;
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 保存
                        if (!outPutDiv)
                        {
                            // グリッドデータクリア
                            ClearGridDataSource();
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = false;
                            // 削除ボタンを不可にする
                            this.uButton_RowGoodsDelete.Enabled = false;
                            // 復活ボタンを不可にする
                            this.uButton_RowGoodsRevive.Enabled = false;
                        }
                        if ((saveList != null && saveList.Count > 0)
                            || (deleteList != null && deleteList.Count > 0))
                        {
                            // 登録完了ダイアログ表示
                            SaveCompletionDialog dialog = new SaveCompletionDialog();
                            dialog.ShowDialog(2);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "既に他端末より削除されています。", status, MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "既に他端末より更新されています。", status, MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "保存処理に失敗しました。", status, MessageBoxButtons.OK);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.ToString(), "保存処理に失敗しました。", 9, MessageBoxButtons.OK);
                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// 画面から保存用データを取る
        /// </summary>
        /// <param name="goodsBarCodeRevnList">商品バーコード関連付けデータList</param>
        /// <param name="deleteGoodsBarCodeRevnList">商品バーコード関連付けデータList</param>
        /// <remarks>
        /// <br>Note       : 画面から保存用データを取る</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GetSaveGoodsBarCodeRevnDataFromScreen(out List<GoodsBarCodeRevn> goodsBarCodeRevnList, out List<GoodsBarCodeRevn> deleteGoodsBarCodeRevnList)
        {
            goodsBarCodeRevnList = new List<GoodsBarCodeRevn>();
            deleteGoodsBarCodeRevnList = new List<GoodsBarCodeRevn>();
            DataTable dt = new DataTable();
            if (_goodsBarCodeDt != null)
            {
                for (int index = 0; index < _goodsBarCodeDt.Rows.Count; index++)
                {
                    // キー
                    string dicKey = StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd]) + "_" + StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsNo]);
                    if (_goodsBarCodeRevnDic.ContainsKey(dicKey))
                    {
                        // 変更するデータとバーコードがなしデータ
                        if ((StrObjToString(_goodsBarCodeRevnDic[dicKey].GoodsBarCode).Trim() != StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode]).Trim()
                            || StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode]).Trim() == ""
                            || _goodsBarCodeRevnDic[dicKey].GoodsBarCodeKind != IntObjToInt(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind]))
                            && StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_DeleteDiv]) == "0")
                        {
                            GoodsBarCodeRevn temp = new GoodsBarCodeRevn();
                            temp = _goodsBarCodeRevnDic[dicKey].Clone();
                            // バーコード種別：グリッドから値をセット
                            temp.GoodsBarCodeKind = IntObjToInt(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind]);
                            // 商品バーコード：グリッドから値をセット
                            temp.GoodsBarCode = StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode]).Trim();
                            if (string.IsNullOrEmpty(temp.GoodsBarCode))
                            {
                                // 商品バーコード：メーカーコード(4桁)+" "+商品番号
                                temp.GoodsBarCode = StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd]) + " " + StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsNo]);
                                // 商品バーコード種別：1:code39
                                temp.GoodsBarCodeKind = 1;
                            }
                            // 保存のデータを商品バーコード関連付けListにセット
                            goodsBarCodeRevnList.Add(temp);
                        }
                        else if (StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_DeleteDiv]) == "1")
                        {
                            GoodsBarCodeRevn temp = new GoodsBarCodeRevn();
                            temp = _goodsBarCodeRevnDic[dicKey].Clone();
                            deleteGoodsBarCodeRevnList.Add(temp);
                        }
                    }
                }
            }
        }

        # endregion

        # region 取込処理
        /// <summary>
        /// 取込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 取込処理します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void InputTextProcess()
        {
            // 編集中のデータが存在状況
            if (GridDataIsChange())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                    "破棄してもよろしいですか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            // グリッドデータクリア処理
            ClearGridDataSource();
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = false;
            // 削除ボタンを不可にする
            this.uButton_RowGoodsDelete.Enabled = false;
            // 復活ボタンを不可にする
            this.uButton_RowGoodsRevive.Enabled = false;

            // 取込画面表示
            PMHND09210UB textOutDialog = new PMHND09210UB();
            textOutDialog.ShowDialog();
        }
        # endregion

        # region テキスト出力処理
        /// <summary>
        /// テキスト出力処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力処理します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void ExtractTextProcess()
        {
            if (this.GoodsBarCodeRevn_Grid.ActiveCell != null && this.GoodsBarCodeRevn_Grid.ActiveCell.IsInEditMode)
            {
                // 編集モードを解除する
                this.GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.ExitEditMode);
            }

            // 確認ダイアログ生成・表示
            PMHND09210UC textOutDialog = new PMHND09210UC();
            if (textOutDialog.ShowDialog() != DialogResult.OK)
            {
                // 中止
                return;
            }

            // 保存商品バーコード関連付けデータ
            int status = SaveGoodsBarCodeRevnProcess(true);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 中止
                return;
            }
            // 出力用テーブル
            DataTable outDt = null;
            // 出力データを取る
            GetExtractDataTable(out outDt);
            // グリッドデータクリア
            ClearGridDataSource();
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = false;
            // 削除ボタンを不可にする
            this.uButton_RowGoodsDelete.Enabled = false;
            // 復活ボタンを不可にする
            this.uButton_RowGoodsRevive.Enabled = false;

            try
            {
                // 出力データがありません
                if (outDt.Rows.Count == 0)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                        "テキスト出力データがありません", status, MessageBoxButtons.OK);
                    return;
                }
                // 設定オブジェクトを取得
                this._userSetting = textOutDialog.UserSetting;

                FormattedTextWriter tw = new FormattedTextWriter();

                // 出力項目名
                List<String> schemeList = new List<string>();

                // CsvTitle出力
                for (int i = 0; i < ctCsvTitle.Length; i++)
                {
                    schemeList.Add(ctCsvTitle[i].ToString());

                }
                tw.SchemeList = schemeList;

                // TextWriterのDataSourceセット
                tw.DataSource = outDt.DefaultView;

                // グリッドのソート情報を適用する
                if (tw.DataSource is DataView)
                {
                    (tw.DataSource as DataView).Sort = GetSortingColumns(this.GoodsBarCodeRevn_Grid);
                }

                # region [フォーマットリスト]

                tw.FormatList = null;
                # endregion

                // ファイル名
                tw.OutputFileName = this._userSetting.OutputFilePath + this._userSetting.OutputFileName;
                // 区切り文字
                tw.Splitter = ",";

                // 括り文字
                tw.Encloser = "\"";

                // 項目括り適用
                List<Type> enclosingList = new List<Type>();

                // 文字タイプ
                String typeStr = string.Empty;
                Char typeChar = new char();
                Byte typeByte = new byte();
                DateTime typeDate = new DateTime();
                // 数値タイプ
                Int16 typeInt16 = new short();
                Int32 typeInt32 = new int();
                Int64 typeInt64 = new long();
                Single typeSingle = new float();
                Double typeDouble = new double();
                Decimal typeDecimal = new decimal();

                // 数値括り
                enclosingList.Add(typeInt16.GetType());
                enclosingList.Add(typeInt32.GetType());
                enclosingList.Add(typeInt64.GetType());
                enclosingList.Add(typeDouble.GetType());
                enclosingList.Add(typeDecimal.GetType());
                enclosingList.Add(typeSingle.GetType());
                // 文字括り
                enclosingList.Add(typeStr.GetType());
                enclosingList.Add(typeChar.GetType());
                enclosingList.Add(typeByte.GetType());
                enclosingList.Add(typeDate.GetType());

                tw.EnclosingTypeList = enclosingList;

                // タイトル行出力
                tw.CaptionOutput = true;

                // 固定幅
                tw.FixedLength = false;
                int outputCount = 0;

                // フォルダーがない場合
                if (!Directory.Exists(this._userSetting.OutputFilePath))
                {
                    // フォルダーを作成する
                    Directory.CreateDirectory(this._userSetting.OutputFilePath);
                }

                status = tw.TextOut(out outputCount);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                {
                    // 出力失敗
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "ファイルへの出力に失敗しました。", status, MessageBoxButtons.OK);
                }
                else
                {
                    // 出力成功
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                        outputCount.ToString() + "行のデータをファイルへ出力しました。", status, MessageBoxButtons.OK);
                }
            }
            catch
            {
                // 異常終了
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                    "ファイルへの出力に失敗しました。", 9, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 出力データを取る
        /// </summary>
        /// <param name="outDt">出力用データ</param>
        /// <remarks>
        /// <br>Note       : 出力データを取る</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GetExtractDataTable(out DataTable outDt)
        {
            outDt = null;
            GoodsBarCodeRevnTbl.CreateDataTable(ref outDt);
            foreach (UltraGridRow ultraRow in this.GoodsBarCodeRevn_Grid.Rows)
            {
                if (StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Text) == "0")
                {
                    DataRow row = outDt.NewRow();
                    // 行番号
                    row[GoodsBarCodeRevnTbl.ct_Col_RowNo] = StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_RowNo].Text);
                    // 商品番号
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsNo] = StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].Text);
                    // 商品メーカーコード
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd] = StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].Text);
                    // メーカー名称
                    row[GoodsBarCodeRevnTbl.ct_Col_MakerName] = StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_MakerName].Text);
                    // 商品名称
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsName] = StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsName].Text);
                    if (StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Text.Trim()) == "")
                    {
                        // 商品バーコード：メーカーコード(4桁)+" "+商品番号
                        row[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode] = StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].Text)
                            + " " + StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].Text);
                    }
                    else
                    {
                        // 商品バーコード
                        row[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode] = StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Text.Trim());
                    }
                    // 商品バーコード種別
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind] = IntObjToInt(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Value);
                    // 削除区分
                    row[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv] = StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Text);
                    outDt.Rows.Add(row);
                }
            }
        }

        /// <summary>
        /// 現在ソート中カラム取得処理
        /// </summary>
        /// <param name="grid">グリッド</param>
        /// <returns>ソート順</returns>
        /// <remarks>
        /// <br>Note       : 現在ソート中カラム取得処理。</br>
        /// <br>Programmer  : 3H 張小磊</br>
        /// <br>Date        : 2017/06/12</br>
        /// </remarks>
        private string GetSortingColumns(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            string sortText = string.Empty;
            bool firstCol = true;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in grid.DisplayLayout.Bands[0].SortedColumns)
            {
                if (firstCol == false)
                {
                    sortText += ",";
                }

                // 列名を取得
                sortText += ultraGridColumn.Key;

                // 列のソート方向(昇順,降順)を取得
                if (ultraGridColumn.SortIndicator == Infragistics.Win.UltraWinGrid.SortIndicator.Ascending)
                {
                    sortText += " ASC";
                }
                else
                {
                    sortText += " DESC";
                }

                firstCol = false;
            }

            return sortText;
        }
        # endregion

        # endregion

        # region [画面・イベント]
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームロードイベント</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void PMHND09210UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            //　企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // 画面ヘッダ初期設定処理
            this.HeaderInitialSetting();

            // グリッド初期設定処理
            this.GridInitialSetting();

        }

        /// <summary>
        /// フォーム初回表示イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォーム初回表示イベント</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void PMHND09210UA_Shown(object sender, EventArgs e)
        {
            // 在庫区分
            this.tEdit_StockDiv.Focus();
        }

        /// <summary>
        /// キー押下イベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 明細グリッド行の背景色を設定。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void PMHND09210UA_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    {
                        if (uButton_RowGoodsDelete.Enabled == true)
                        {
                            // 商品バーコードを削除処理
                            uButton_RowGoodsDelete_Click(sender, e);
                        }
                        break;
                    }
                case Keys.F4:
                    {
                        if (uButton_RowGoodsRevive.Enabled == true)
                        {
                            // 商品バーコードを復活処理
                            uButton_RowGoodsRevive_Click(sender, e);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// 在庫区分変更された時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 在庫区分変更された時発生します。</br> 
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br>Update Note: 2017/09/22 3H 楊善娟</br>
        /// <br>管理番号   : 11370074-00 ハンディ対応（2次）</br>
        /// <br>             商品バーコード一括登録の改良</br>
        /// </remarks>
        private void tEdit_StockDiv_ValueChanged(object sender, EventArgs e)
        {
            // 拠点
            tEdit_SectionCode.DataText = string.Empty;
            uLabel_SectionName.Text = string.Empty;
            tEdit_SectionCode.Enabled = false;
            uButton_SectionGuide.Enabled = false;
            // 倉庫
            tEdit_WarehouseCode.DataText = string.Empty;
            uLabel_WarehouseName.Text = string.Empty;
            tEdit_WarehouseCode.Enabled = false;
            uButton_WarehouseGuide.Enabled = false;
            // --- ADD 3H 楊善娟 2017/09/22---------->>>>>
            // メーカーコード
            this.tNedit_GoodsMakerCd.Appearance.BackColor = this.ct_EssentialColor;
            // --- ADD 3H 楊善娟 2017/09/22----------<<<<<
            // 倉庫
            this.tEdit_WarehouseCode.Appearance.BackColor = this.ct_OptionalColor;
            // 品番
            this.tEdit_GoodsNo.Appearance.BackColor = this.ct_EssentialColor;
            // 前回入力検索条件情報(ヘッダ用)
            if (this._prevHeaderInfo != null)
            {
                // 拠点
                this._prevHeaderInfo.SectionCode = string.Empty;
                // 倉庫
                this._prevHeaderInfo.WarehouseCode = string.Empty;
            }

            // 在庫区分： 0 と 1 のみ
            if (!string.IsNullOrEmpty(tEdit_StockDiv.DataText.Trim()) && tEdit_StockDiv.DataText.Trim() != "1" && tEdit_StockDiv.DataText.Trim() != "0")
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "在庫区分は 0 と 1 以外の値が入力できません。", 0, MessageBoxButtons.OK);
                tEdit_StockDiv.DataText = string.Empty;
                tEdit_StockDiv.Focus();
            }
            else if (tEdit_StockDiv.DataText.Trim() == "0")
            {
                // --- ADD 3H 楊善娟 2017/09/22---------->>>>>
                // メーカーコード
                this.tNedit_GoodsMakerCd.Appearance.BackColor = this.ct_OptionalColor;
                // --- ADD 3H 楊善娟 2017/09/22----------<<<<<

                // 拠点
                tEdit_SectionCode.Enabled = true;
                uButton_SectionGuide.Enabled = true;
                // 倉庫
                tEdit_WarehouseCode.Enabled = true;
                this.tEdit_WarehouseCode.Appearance.BackColor = this.ct_EssentialColor;
                uButton_WarehouseGuide.Enabled = true;
                // 品番
                this.tEdit_GoodsNo.Appearance.BackColor = this.ct_OptionalColor;
            }
        }

        /// <summary>
        /// 登録区分変更された時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 登録区分変更された時発生します。</br> 
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void tEdit_HaveBarCodeDiv_ValueChanged(object sender, EventArgs e)
        {
            // 登録区分： 0 と 1 のみ
            if (!string.IsNullOrEmpty(tEdit_HaveBarCodeDiv.DataText.Trim()) && tEdit_HaveBarCodeDiv.DataText.Trim() != "0"
                && tEdit_HaveBarCodeDiv.DataText.Trim() != "1" && tEdit_HaveBarCodeDiv.DataText.Trim() != "2")
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "登録区分は 0,1と2 以外の値が入力できません。", 0, MessageBoxButtons.OK);
                tEdit_HaveBarCodeDiv.DataText = string.Empty;
                tEdit_HaveBarCodeDiv.Focus();
            }
        }

        /// <summary>
        /// 商品バーコード削除処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 商品バーコード削除処理。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_RowGoodsDelete_Click(object sender, EventArgs e)
        {
            List<int> rowIndexList = this.GetSelectRowIndex();
            rowIndexList.Sort();

            if (rowIndexList.Count == 0)
            {
                // 選択行、アクティブセルが無い場合、処理なし
                return;
            }
            foreach (int rowIndex in rowIndexList)
            {
                this.GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation = Activation.Disabled;
                this.GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activation = Activation.Disabled;
                // 削除区分 1:削除済み行
                this.GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Value = "1";
            }

            // 選択行の状態が変わるので削除ボタン押下制御
            this.uButton_RowGoodsDelete.Enabled = false;
            // 選択行の状態が変わるので復活ボタン押下制御
            this.uButton_RowGoodsRevive.Enabled = true;

            // 選択行の状態が変わるので背景色リフレッシュ
            this.SetGridColorAll();
        }

        /// <summary>
        /// 商品バーコード復活処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 商品バーコード復活処理。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_RowGoodsRevive_Click(object sender, EventArgs e)
        {
            List<int> rowIndexList = this.GetSelectRowIndex();
            rowIndexList.Sort();

            if (rowIndexList.Count == 0)
            {
                // 選択行、アクティブセルが無い場合、処理なし
                return;
            }
            foreach (int rowIndex in rowIndexList)
            {
                this.GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation = Activation.AllowEdit;
                this.GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activation = Activation.AllowEdit;
                // 削除区分 0:正常行(復活済み)
                this.GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Value = "0";
            }
            // 選択行の状態が変わるので削除ボタン押下制御
            this.uButton_RowGoodsDelete.Enabled = true;
            // 選択行の状態が変わるので復活ボタン押下制御
            this.uButton_RowGoodsRevive.Enabled = false;

            // 選択行の状態が変わるので背景色リフレッシュ
            this.SetGridColorAll();
        }

        # endregion

        # region [ChangeFocus]
        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 矢印キーでのフォーカス移動イベント</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // 名称取得 ============================================ //
            # region [名称取得]
            switch (e.PrevCtrl.Name)
            {
                //-----------------------------------------------------
                // メーカー
                //-----------------------------------------------------
                case "tNedit_GoodsMakerCd":
                    {
                        # region [メーカー]
                        bool status;

                        if (tNedit_GoodsMakerCd.GetInt() == _prevHeaderInfo.GoodsMakerCd)
                        {
                            status = true;
                        }
                        else
                        {
                            int code;
                            string name;

                            // 読み込み
                            status = ReadGoodsMaker(tNedit_GoodsMakerCd.GetInt(), out code, out name);

                            // コード・名称を更新
                            tNedit_GoodsMakerCd.SetInt(code);
                            _prevHeaderInfo.GoodsMakerCd = code;
                            uLabel_MakerName.Text = name;
                        }

                        if (status == true)
                        {
                            if (!e.ShiftKey)
                            {
                                // NextCtrl制御
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (_prevHeaderInfo.GoodsMakerCd == 0)
                                            {
                                                e.NextCtrl = this.uButton_GoodsMakerGuide;
                                            }
                                            else
                                            {
                                                if (this.tEdit_WarehouseCode.Enabled == true)
                                                {
                                                    e.NextCtrl = this.tEdit_WarehouseCode;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tEdit_GoodsNo;
                                                }
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "メーカーが存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                        }

                        # endregion
                    }
                    break;
                case "tEdit_GoodsNo":
                    {
                        if (!e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tEdit_SectionCode.Enabled == true)
                                        {
                                            e.NextCtrl = this.tEdit_SectionCode;
                                        }
                                        else
                                        {
                                            if (this.GoodsBarCodeRevn_Grid.Rows.Count > 0)
                                            {
                                                e.NextCtrl = this.GoodsBarCodeRevn_Grid;
                                            }
                                            else
                                            {
                                                e.NextCtrl = tEdit_StockDiv;
                                            }
                                        }
                                        break;
                                    }
                            }
                        }
                    }
                    break;
                //-----------------------------------------------------
                // 倉庫
                //-----------------------------------------------------
                case "tEdit_WarehouseCode":
                    {
                        # region [倉庫]

                        bool status;

                        if (tEdit_WarehouseCode.Text == _prevHeaderInfo.WarehouseCode)
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // 読み込み
                            status = ReadWarehouse(tEdit_WarehouseCode.Text, out code, out name);

                            // コード・名称を更新
                            tEdit_WarehouseCode.Text = code.TrimEnd();
                            _prevHeaderInfo.WarehouseCode = code.TrimEnd();
                            uLabel_WarehouseName.Text = name;
                        }

                        if (status == true)
                        {
                            if (!e.ShiftKey)
                            {
                                // NextCtrl制御
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (_prevHeaderInfo.WarehouseCode == string.Empty)
                                            {
                                                e.NextCtrl = this.uButton_WarehouseGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_GoodsNo;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "倉庫が存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                        }

                        # endregion
                    }
                    break;
                //-----------------------------------------------------
                // 拠点
                //-----------------------------------------------------
                case "tEdit_SectionCode":
                    {
                        # region [拠点]

                        bool status;

                        if (tEdit_SectionCode.Text == _prevHeaderInfo.SectionCode)
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // 拠点読み込み
                            status = ReadSection(tEdit_SectionCode.Text, out code, out name);

                            // コード・名称を更新
                            tEdit_SectionCode.Text = code.TrimEnd();
                            _prevHeaderInfo.SectionCode = code.TrimEnd();
                            uLabel_SectionName.Text = name;
                        }

                        if (status == true)
                        {
                            if (!e.ShiftKey)
                            {
                                // NextCtrl制御
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (_prevHeaderInfo.SectionCode == string.Empty)
                                            {
                                                // 拠点ガイド
                                                e.NextCtrl = this.uButton_SectionGuide;
                                            }
                                            else
                                            {
                                                if (this.GoodsBarCodeRevn_Grid.Rows.Count > 0)
                                                {
                                                    e.NextCtrl = this.GoodsBarCodeRevn_Grid;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = tEdit_StockDiv;
                                                }
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "拠点が存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                        }
                        # endregion
                    }
                    break;

                // グリッド
                case "GoodsBarCodeRevn_Grid":
                    {
                        if (this.GoodsBarCodeRevn_Grid.Rows.Count == 0)
                        {
                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                // グリッドタブ移動制御
                                SetGridTabFocus(ref e);
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || (e.Key == Keys.Enter))
                            {
                                // グリッドシフトタブ移動制御
                                SetGridShiftTabFocus(ref e);
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl != null && e.NextCtrl.Name == "GoodsBarCodeRevn_Grid")
            {
                if (this.GoodsBarCodeRevn_Grid.Rows.Count == 0)
                {
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down) || (e.Key == Keys.Up))
                        {
                            // 在庫区分
                            e.NextCtrl = this.tEdit_StockDiv;
                        }
                    }
                    else
                    {
                        if (e.Key == Keys.Tab)
                        {
                            // 在庫区分
                            e.NextCtrl = this.tEdit_StockDiv;
                        }
                    }
                }
                else
                {
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                        {
                            e.NextCtrl = null;
                            this.GoodsBarCodeRevn_Grid.Focus();

                            bool doActivate = false;

                            for (int i = 0; i < GoodsBarCodeRevn_Grid.Rows.Count; i++)
                            {
                                // アクティブ行探し
                                if (!GoodsBarCodeRevn_Grid.Rows[i].IsFilteredOut)
                                {
                                    if (GoodsBarCodeRevn_Grid.Rows[i].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation == Activation.AllowEdit)
                                    {
                                        GoodsBarCodeRevn_Grid.Rows[i].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activate();
                                        GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        doActivate = true;
                                        break;
                                    }
                                }
                            }

                            if (!doActivate)
                            {
                                // 在庫区分
                                this.tEdit_StockDiv.Focus();
                            }

                        }
                        else if (e.Key == Keys.Up)
                        {
                            e.NextCtrl = null;
                            this.GoodsBarCodeRevn_Grid.Focus();

                            bool doActivate = false;

                            for (int i = GoodsBarCodeRevn_Grid.Rows.Count-1; i >= 0; i--)
                            {
                                // アクティブ行探し
                                if (!GoodsBarCodeRevn_Grid.Rows[i].IsFilteredOut)
                                {
                                    if (GoodsBarCodeRevn_Grid.Rows[i].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation == Activation.AllowEdit)
                                    {
                                        GoodsBarCodeRevn_Grid.Rows[i].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activate();
                                        GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        doActivate = true;
                                        break;
                                    }
                                }
                            }

                            if (!doActivate)
                            {
                                if (this.uButton_SectionGuide.Enabled == true)
                                {
                                    // 拠点ガイド
                                    this.uButton_SectionGuide.Focus();
                                }
                                else
                                {
                                    // 品番
                                    this.tEdit_GoodsNo.Focus();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (e.Key == Keys.Tab || (e.Key == Keys.Enter))
                        {
                            e.NextCtrl = null;
                            this.GoodsBarCodeRevn_Grid.Focus();

                            bool doActivate = false;

                            for (int i = GoodsBarCodeRevn_Grid.Rows.Count - 1; i >= 0; i--)
                            {
                                // アクティブ行探し
                                if (!GoodsBarCodeRevn_Grid.Rows[i].IsFilteredOut)
                                {
                                    if (GoodsBarCodeRevn_Grid.Rows[i].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activation == Activation.AllowEdit)
                                    {
                                        GoodsBarCodeRevn_Grid.Rows[i].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activate();
                                        GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        doActivate = true;
                                        break;
                                    }
                                }
                            }

                            if (!doActivate)
                            {
                                if (this.uButton_SectionGuide.Enabled == true)
                                {
                                    // 拠点ガイド
                                    this.uButton_SectionGuide.Focus();
                                }
                                else
                                {
                                    // 品番
                                    this.tEdit_GoodsNo.Focus();
                                }
                            }
                        }
                    }
                }
            }

            # endregion

        }
        # endregion

        # region [ChangeFocus時のRead処理]
        /// <summary>
        /// 拠点Read
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="code">拠点コード</param>
        /// <param name="name">拠点名</param>
        /// <returns>Read処理結果</returns>
        /// <remarks>
        /// <br>Note       : 拠点Read</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private bool ReadSection(string sectionCode, out string code, out string name)
        {
            bool result = false;

            // 未入力判定
            if (sectionCode != string.Empty)
            {
                // 読み込み
                if (_secInfoSetAcs == null)
                {
                    _secInfoSetAcs = new SecInfoSetAcs();
                }
                SecInfoSet secInfoSet;
                int status = _secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, sectionCode);

                if (status == 0 && secInfoSet != null)
                {
                    // 該当あり→表示
                    code = secInfoSet.SectionCode.TrimEnd();
                    name = secInfoSet.SectionGuideNm;

                    result = true;
                }
                else
                {
                    // 該当なし→クリア
                    code = string.Empty;
                    name = string.Empty;

                    // ＮＧにする
                    result = false;
                }
            }
            else
            {
                // 未入力→クリア
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// 倉庫Read
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="code">倉庫コード</param>
        /// <param name="name">倉庫名</param>
        /// <returns>Read処理結果</returns>
        /// <remarks>
        /// <br>Note       : 倉庫Read</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private bool ReadWarehouse(string warehouseCode, out string code, out string name)
        {
            bool result = false;

            // 未入力判定
            if (warehouseCode != string.Empty)
            {
                // 読み込み
                if (_warehouseAcs == null)
                {
                    _warehouseAcs = new WarehouseAcs();
                }
                Warehouse warehouse;
                int status = _warehouseAcs.Read(out warehouse, this._enterpriseCode, string.Empty, warehouseCode);

                if (status == 0 && warehouse != null)
                {
                    // 該当あり→表示
                    code = warehouse.WarehouseCode.TrimEnd();
                    name = warehouse.WarehouseName;

                    result = true;
                }
                else
                {
                    // 該当なし→クリア
                    code = string.Empty;
                    name = string.Empty;

                    // ＮＧにする
                    result = false;
                }
            }
            else
            {
                // 未入力→クリア
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// 商品メーカーRead
        /// </summary>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="code">商品メーカーコード</param>
        /// <param name="name">商品メーカー名</param>
        /// <returns>Read処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品メーカーRead</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private bool ReadGoodsMaker(int goodsMakerCd, out int code, out string name)
        {
            bool result = false;

            // 未入力判定
            if (goodsMakerCd != 0)
            {
                // 読み込み
                if (_makerAcs == null)
                {
                    _makerAcs = new MakerAcs();
                }
                MakerUMnt maker;
                int status = _makerAcs.Read(out maker, this._enterpriseCode, goodsMakerCd);

                if (status == 0 && maker != null)
                {
                    // 該当あり→表示
                    code = maker.GoodsMakerCd;
                    name = maker.MakerName;

                    result = true;
                }
                else
                {
                    // 該当なし→クリア
                    code = 0;
                    name = string.Empty;

                    // ＮＧにする
                    result = false;
                }
            }
            else
            {
                // 未入力→クリア
                code = 0;
                name = string.Empty;

                result = true;
            }

            return result;
        }
        # endregion

        # region [ガイドボタンクリック]
        /// <summary>
        /// 拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドボタンクリックイベント</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            if (_secInfoSetAcs == null)
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }

            SecInfoSet secInfoSet;
            int status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();
                this._prevHeaderInfo.SectionCode = secInfoSet.SectionCode.Trim();

                // フォーカス移動
                tEdit_StockDiv.Focus();
            }
        }

        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : メーカーガイドボタンクリックイベント</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_GoodsMakerGuide_Click(object sender, EventArgs e)
        {
            if (_makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            MakerUMnt makerUMnt;
            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                uLabel_MakerName.Text = makerUMnt.MakerName.Trim();
                this._prevHeaderInfo.GoodsMakerCd = makerUMnt.GoodsMakerCd;

                // フォーカス移動
                tEdit_GoodsNo.Focus();
            }
        }
        /// <summary>
        /// 倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンクリックイベント</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_WarehouseGuide_Click(object sender, EventArgs e)
        {
            if (_warehouseAcs == null)
            {
                _warehouseAcs = new WarehouseAcs();
            }

            Warehouse warehouse;
            int status = _warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode, this.tEdit_SectionCode.Text);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_WarehouseCode.Text = warehouse.WarehouseCode.TrimEnd();
                uLabel_WarehouseName.Text = warehouse.WarehouseName.TrimEnd();
                this._prevHeaderInfo.WarehouseCode = warehouse.WarehouseCode.TrimEnd();

                // フォーカス移動
                tEdit_SectionCode.Focus();
            }
        }
        # endregion

        # region [グリッドイベント]

        /// <summary>
        /// グリッド初期設定イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッド初期設定イベント</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBar_Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // 該当のグリッドコントロール取得
            UltraGrid grids = (UltraGrid)sender;

            // 『固定列』プッシュピンアイコンを消す
            e.Layout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;

            // 固定ヘッダー機能を有効にする
            grids.DisplayLayout.UseFixedHeaders = true;
            // 複数行選択可
            e.Layout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag;

            // 行サイズを設定
            grids.DisplayLayout.Override.DefaultRowHeight = 24;
            grids.DisplayLayout.Override.FixedCellSeparatorColor = Color.Black;
            int visiblePosition = 0;

            ColumnsCollection Columns = grids.DisplayLayout.Bands[GoodsBarCodeRevnTbl.ct_Tbl_GoodsBarCodeRevn].Columns;
           
            // 行番号
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].Hidden = false;
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].Header.Fixed = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].Width = 50;
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].CellActivation = Activation.Disabled;
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].Header.VisiblePosition = visiblePosition++;
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].CellClickAction = CellClickAction.RowSelect;

            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].CellAppearance.ForeColor = Color.White;
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].CellAppearance.ForeColorDisabled = Color.White;

            // 品番
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].Hidden = false;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].Header.Fixed = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].Width = 200;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].CellActivation = Activation.Disabled;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].Header.VisiblePosition = visiblePosition++;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].CellAppearance.ForeColor = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].CellAppearance.ForeColorDisabled = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].CellClickAction = CellClickAction.RowSelect;

            // メーカーコード
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].Hidden = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].Header.Fixed = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].Width = 100;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].CellActivation = Activation.Disabled;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].Header.VisiblePosition = visiblePosition++;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].CellAppearance.ForeColor = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].CellAppearance.ForeColorDisabled = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].CellClickAction = CellClickAction.RowSelect;

            // メーカー名
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].Hidden = false;
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].Header.Fixed = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].Width = 100;
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].CellActivation = Activation.Disabled;
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].Header.VisiblePosition = visiblePosition++;
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].CellAppearance.ForeColor = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].CellAppearance.ForeColorDisabled = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].CellClickAction = CellClickAction.RowSelect;

            // 品名
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].Hidden = false;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].Header.Fixed = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].Width = 200;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].CellActivation = Activation.Disabled;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].Header.VisiblePosition = visiblePosition++;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].CellAppearance.ForeColor = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].CellAppearance.ForeColorDisabled = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].CellClickAction = CellClickAction.RowSelect;

            //--------------------------------------
            // コンボボックス設定
            //--------------------------------------
            // バーコード種別 0:JAN  1:CODE39
            ValueList valueList = new ValueList();
            valueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);
            valueList.ValueListItems.Add(0, "0:JAN");
            valueList.ValueListItems.Add(1, "1:CODE39");

            // バーコード種別
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Hidden = false;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Header.Fixed = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Width = 150;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].CellActivation = Activation.AllowEdit;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].CellAppearance.ForeColor = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].CellAppearance.ForeColorDisabled = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Header.VisiblePosition = visiblePosition++;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].ValueList = valueList.Clone();

            // バーコード
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Hidden = false;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Header.Fixed = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Width = 250;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].CellActivation = Activation.AllowEdit;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].CellAppearance.ForeColor = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].CellAppearance.ForeColorDisabled = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].MaxLength = 128;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Header.VisiblePosition = visiblePosition++;

            // 削除区分
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Hidden = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Header.Fixed = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Width = 50;
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].CellActivation = Activation.Disabled;
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].CellAppearance.ForeColor = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].CellAppearance.ForeColorDisabled = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].MaxLength = 128;
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Header.VisiblePosition = visiblePosition++;

        }

        /// <summary>
        /// AfterCellUpdate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : AfterCellUpdate イベント</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBarCodeRevn_Grid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;
            int rowIndex = e.Cell.Row.Index;
            // キー
            string dicKey = StrObjToString(uGrid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].Value) + "_" + StrObjToString(uGrid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].Value);
            if (_goodsBarCodeRevnDic.ContainsKey(dicKey))
            {
                // バーコード
                if (e.Cell.Column.Key == GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode)
                {
                    // 変更するデータ
                    if (StrObjToString(_goodsBarCodeRevnDic[dicKey].GoodsBarCode) != StrObjToString(uGrid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Value))
                    {
                        e.Cell.Appearance.BackColor = Color.Lime;
                    }
                    else
                    {
                        e.Cell.Appearance.BackColor = Color.Empty;
                    }
                }
                // バーコード種別
                else if (e.Cell.Column.Key == GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind)
                {
                    // 変更するデータ
                    if (_goodsBarCodeRevnDic[dicKey].GoodsBarCodeKind != IntObjToInt(uGrid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Value))
                    {
                        e.Cell.Appearance.BackColor = Color.Lime;
                    }
                    else
                    {
                        e.Cell.Appearance.BackColor = Color.Empty;
                    }
                }
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBarCodeRevn_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if ((GoodsBarCodeRevn_Grid.Rows.Count == 0) ||
                ((GoodsBarCodeRevn_Grid.ActiveCell == null) && (GoodsBarCodeRevn_Grid.ActiveRow == null)))
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            if (this.uButton_SectionGuide.Enabled == true)
                            {
                                // 拠点ガイド
                                this.uButton_SectionGuide.Focus();
                            }
                            else
                            {
                                // 品番
                                this.tEdit_GoodsNo.Focus();
                            }
                            break;
                        }
                    case Keys.Down:
                    case Keys.Right:
                        {
                            //　在庫区分
                            this.tEdit_StockDiv.Focus();
                            break;
                        }
                    case Keys.Left:
                        {
                            // 品番
                            this.tEdit_GoodsNo.Focus();
                            break;
                        }
                }
                return;
            }

            int rowIndex;
            string columnKey = string.Empty;
            if (GoodsBarCodeRevn_Grid.ActiveCell != null)
            {
                // アクティブCell
                rowIndex = GoodsBarCodeRevn_Grid.ActiveCell.Row.Index;
                columnKey = GoodsBarCodeRevn_Grid.ActiveCell.Column.Key;
            }
            else
            {
                // アクティブ行
                rowIndex = GoodsBarCodeRevn_Grid.ActiveRow.Index;
                // 商品バーコード種別
                columnKey = GoodsBarCodeRevnTbl.ct_Col_GoodsNo;
            }

            bool doActivate = false;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {

                        if (rowIndex == 0)
                        {
                            e.Handled = true;
                            if (this.uButton_SectionGuide.Enabled == true)
                            {
                                // 拠点ガイド
                                this.uButton_SectionGuide.Focus();
                            }
                            else
                            {
                                // 品番
                                this.tEdit_GoodsNo.Focus();
                            }
                        }
                        else
                        {
                            if (GoodsBarCodeRevn_Grid.ActiveCell != null)
                            {
                                e.Handled = true;
                                for (int i = rowIndex; i >= 1; i--)
                                {
                                    // アクティブ行探し
                                    if (!GoodsBarCodeRevn_Grid.Rows[i - 1].IsFilteredOut)
                                    {
                                        if (GoodsBarCodeRevn_Grid.Rows[i - 1].Cells[columnKey].Activation == Activation.AllowEdit && columnKey != GoodsBarCodeRevnTbl.ct_Col_GoodsNo)
                                        {
                                            GoodsBarCodeRevn_Grid.Rows[i - 1].Cells[columnKey].Activate();
                                            GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                            doActivate = true;
                                            break;
                                        }
                                        else
                                        {
                                            // 行アクティブ
                                            GoodsBarCodeRevn_Grid.Rows[i - 1].Activate();
                                            GoodsBarCodeRevn_Grid.Rows[i - 1].Selected = true;
                                            doActivate = true;
                                            break;
                                        }
                                    }
                                }
                                if (!doActivate)
                                {
                                    if (this.uButton_SectionGuide.Enabled == true)
                                    {
                                        // 拠点ガイド
                                        this.uButton_SectionGuide.Focus();
                                    }
                                    else
                                    {
                                        // 品番
                                        this.tEdit_GoodsNo.Focus();
                                    }
                                }
                            }
                        }
                        break;
                    }
                case Keys.Down:
                    {
                     
                        if (rowIndex == GoodsBarCodeRevn_Grid.Rows.Count - 1)
                        {
                            e.Handled = true;
                            // 在庫区分
                            this.tEdit_StockDiv.Focus();
                        }
                        else
                        {
                            if (GoodsBarCodeRevn_Grid.ActiveCell != null)
                            {
                                e.Handled = true;
                                for (int i = rowIndex; i < GoodsBarCodeRevn_Grid.Rows.Count - 1; i++)
                                {
                                    // アクティブ行探し
                                    if (!GoodsBarCodeRevn_Grid.Rows[i + 1].IsFilteredOut)
                                    {
                                        if (GoodsBarCodeRevn_Grid.Rows[i + 1].Cells[columnKey].Activation == Activation.AllowEdit && columnKey != GoodsBarCodeRevnTbl.ct_Col_GoodsNo)
                                        {
                                            GoodsBarCodeRevn_Grid.Rows[i + 1].Cells[columnKey].Activate();
                                            GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                            doActivate = true;
                                            break;
                                        }
                                        else
                                        {
                                            // 行アクティブ
                                            GoodsBarCodeRevn_Grid.Rows[i + 1].Activate();
                                            GoodsBarCodeRevn_Grid.Rows[i + 1].Selected = true;
                                            doActivate = true;
                                            break;
                                        }
                                    }
                                }

                                if (!doActivate)
                                {
                                    // 在庫区分
                                    this.tEdit_StockDiv.Focus();
                                }
                            }
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        e.Handled = true;
                        // 商品バーコード種別
                        if (columnKey == GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind)
                        {
                            if (rowIndex == 0)
                            {
                                doActivate = false;
                            }
                            else
                            {
                                for (int i = rowIndex; i >= 1; i--)
                                {
                                    // アクティブ行探し
                                    if (!GoodsBarCodeRevn_Grid.Rows[i - 1].IsFilteredOut)
                                    {
                                        // 商品バーコード
                                        if (GoodsBarCodeRevn_Grid.Rows[i - 1].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activation == Activation.AllowEdit)
                                        {
                                            GoodsBarCodeRevn_Grid.Rows[i - 1].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activate();
                                            GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                            doActivate = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (!doActivate)
                            {
                                if (this.uButton_SectionGuide.Enabled == true)
                                {
                                    // 拠点ガイド
                                    this.uButton_SectionGuide.Focus();
                                }
                                else
                                {
                                    // 品番
                                    this.tEdit_GoodsNo.Focus();
                                }
                            }
                        }
                        // 商品バーコード
                        else
                        {
                            // 商品バーコード種別
                            if (GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation == Activation.AllowEdit)
                            {
                                GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activate();
                                GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                doActivate = true;
                                break;
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        e.Handled = true;
                        // 商品バーコード種別
                        if (columnKey == GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind)
                        {
                            // 商品バーコード
                            if (GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activation == Activation.AllowEdit)
                            {
                                GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activate();
                                GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                doActivate = true;
                                break;
                            }
                        }
                        // 商品バーコード
                        else
                        {
                            if (rowIndex == GoodsBarCodeRevn_Grid.Rows.Count - 1)
                            {
                                doActivate = false;
                            }
                            else
                            {
                                for (int i = rowIndex; i < GoodsBarCodeRevn_Grid.Rows.Count - 1; i++)
                                {
                                    // アクティブ行探し
                                    if (!GoodsBarCodeRevn_Grid.Rows[i + 1].IsFilteredOut)
                                    {
                                        // 商品バーコード種別
                                        if (GoodsBarCodeRevn_Grid.Rows[i + 1].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation == Activation.AllowEdit)
                                        {
                                            GoodsBarCodeRevn_Grid.Rows[i + 1].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activate();
                                            GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                            doActivate = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (!doActivate)
                            {
                                // 在庫区分
                                this.tEdit_StockDiv.Focus();
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBarCodeRevn_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.GoodsBarCodeRevn_Grid.ActiveCell == null)
            {
                return;
            }
            // アクティブCell
            UltraGridCell cell = this.GoodsBarCodeRevn_Grid.ActiveCell;

            if (cell.IsInEditMode)
            {
                // UI設定を参照
                if (this.uiSetControl1.CheckMatchingSet(cell.Column.Key, e.KeyChar) == false)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// セルアクティブ前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : セルアクティブ前イベント</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBarCodeRevn_Grid_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            // グリッドCellアクティブを指定した、ボタン押下可否制御を行う。
            this.SetDeleteAndReviveRowButtonEnableByActiveCell(e.Cell.Row.Index);
        }

        /// <summary>
        /// セル非アクティブ前イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : セル非アクティブ前イベント</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBarCodeRevn_Grid_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            if (this.GoodsBarCodeRevn_Grid.ActiveCell != null)
            {
                int rowIndex = this.GoodsBarCodeRevn_Grid.ActiveCell.Row.Index;
                // 背景色設定

                UltraGridRow dr = GoodsBarCodeRevn_Grid.Rows[rowIndex];
                // 明細グリッド行の背景色を設定
                SetGridColorRow(dr);

            }
        }

        /// <summary>
        /// AfterSelectChange イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : AfterSelectChange イベント</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBarCodeRevn_Grid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // 前選択した行
            if (this._beforeSelectRowIndexList.Count != 0)
            {
                foreach (int rowIndex in this._beforeSelectRowIndexList)
                {
                    if (rowIndex <= this.GoodsBarCodeRevn_Grid.Rows.Count - 1)
                    {
                        this.SetGridColorRow(this.GoodsBarCodeRevn_Grid.Rows[rowIndex]);
                    }
                }

                this._beforeSelectRowIndexList.Clear();
            }

            // BeforeRowDeactivateから移動
            foreach (UltraGridRow ultraGridRow in this.GoodsBarCodeRevn_Grid.Selected.Rows)
            {
                this._beforeSelectRowIndexList.Add(ultraGridRow.Index);
            }

            // 選択行の背景色設定
            if (this.GoodsBarCodeRevn_Grid.Selected.Rows.Count != 0)
            {
                foreach (UltraGridRow ultraGr in this.GoodsBarCodeRevn_Grid.Selected.Rows)
                {
                    this.SetGridColorRow(ultraGr);
                }
            }

            if (this.GoodsBarCodeRevn_Grid.ActiveCell != null)
            {
                this.SetGridColorRow(this.GoodsBarCodeRevn_Grid.Rows[this.GoodsBarCodeRevn_Grid.ActiveCell.Row.Index]);
            }

            // 削除と復活ボタン押下制御
            this.SetDeleteAndReviveRowButtonEnable();
        }

        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドが非アクティブになった時に発生します。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBarCodeRevn_Grid_Leave(object sender, EventArgs e)
        {
            if (!uButton_RowGoodsDelete.Focused && !uButton_RowGoodsRevive.Focused)
            {
                this.GoodsBarCodeRevn_Grid.ActiveCell = null;
                this.GoodsBarCodeRevn_Grid.ActiveRow = null;
                this.GoodsBarCodeRevn_Grid.Selected.Rows.Clear();
                // 削除ボタンを不可にする
                this.uButton_RowGoodsDelete.Enabled = false;
                // 復活ボタンを不可にする
                this.uButton_RowGoodsRevive.Enabled = false;
                // 明細グリッド各行の背景色を設定
                SetGridColorAll();
            }

        }

        # endregion

        #region [セル値変換]
        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>セル値変換結果</returns>
        /// <remarks>
        /// <br>Note        : セル値をString型に変換します。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private string StrObjToString(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null))
            {
                return "";
            }

            return (string)cellValue;
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <remarks>
        /// <br>Note        : セル値をInt型に変換します。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int IntObjToInt(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null))
            {
                return 0;
            }

            return (int)cellValue;
        }
        # endregion

        #region [編集中のデータが存在状況]
        /// <summary>
        /// 編集中のデータが存在状況
        /// </summary>
        /// <returns>true:存在 false:存在なし </returns>
        /// <remarks>
        /// <br>Note       : 編集中のデータが存在状況</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private bool GridDataIsChange()
        {
            if (this.GoodsBarCodeRevn_Grid.ActiveCell != null && this.GoodsBarCodeRevn_Grid.ActiveCell.IsInEditMode)
            {
                // 編集モードを解除する
                this.GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.ExitEditMode);
            }

            // データテーブル
            if (_goodsBarCodeDt != null)
            {
                for (int index = 0; index < _goodsBarCodeDt.Rows.Count; index++)
                {
                    // キー
                    string dicKey = StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd]) + "_" + StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsNo]);
                    if (_goodsBarCodeRevnDic.ContainsKey(dicKey))
                    {
                        // 削除するデータ
                        if (StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_DeleteDiv]) == "1")
                        {
                            return true;
                        }
                        // 変更するデータ:商品バーコード
                        if (StrObjToString(_goodsBarCodeRevnDic[dicKey].GoodsBarCode) != StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode]).Trim())
                        {
                            return true;
                        }
                        // 変更するデータ:商品バーコード種別
                        if (_goodsBarCodeRevnDic[dicKey].GoodsBarCodeKind != IntObjToInt(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind]))
                        {
                            return true;
                        } 
                    }
                }
            }
            return false;
        }
        # endregion

        #region [エラーメッセージ表示処理]
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                ct_ClassName,			    	// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion

        #region [グリッドタブ移動]
        /// <summary>
        /// グリッドタブ移動制御
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドにフォーカスがある場合のタブ移動を制御します。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetGridTabFocus(ref ChangeFocusEventArgs e)
        {
            e.NextCtrl = null;
            this.GoodsBarCodeRevn_Grid.Focus();

            int rowIndex = 0;
            string columnKey = string.Empty;

            if (this.GoodsBarCodeRevn_Grid.ActiveCell == null)
            {
                // アクティブ行
                if (this.GoodsBarCodeRevn_Grid.ActiveRow != null)
                {
                    rowIndex = this.GoodsBarCodeRevn_Grid.ActiveRow.Index;
                    // 商品バーコード種別
                    columnKey = GoodsBarCodeRevnTbl.ct_Col_GoodsNo;
                }
            }
            else
            {
                // アクティブCell
                rowIndex = this.GoodsBarCodeRevn_Grid.ActiveCell.Row.Index;
                columnKey = GoodsBarCodeRevn_Grid.ActiveCell.Column.Key;
                this.GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.ExitEditMode);
            }

            bool doActivate = false;
            // 商品バーコード種別
            if (columnKey == GoodsBarCodeRevnTbl.ct_Col_GoodsNo)
            {
                // 商品バーコード
                if (GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation == Activation.AllowEdit)
                {
                    GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activate();
                    GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                    doActivate = true;
                }
            }
            // 商品バーコード種別
            else if (columnKey == GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind)
            {
                // 商品バーコード
                if (GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activation == Activation.AllowEdit)
                {
                    GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activate();
                    GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                    doActivate = true;
                }
            }
            if (!doActivate)
            {
                for (int i = rowIndex; i < GoodsBarCodeRevn_Grid.Rows.Count - 1; i++)
                {
                    // アクティブ行探し
                    if (!GoodsBarCodeRevn_Grid.Rows[i + 1].IsFilteredOut)
                    {
                        // 商品バーコード種別
                        if (GoodsBarCodeRevn_Grid.Rows[i + 1].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation == Activation.AllowEdit)
                        {
                            GoodsBarCodeRevn_Grid.Rows[i + 1].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activate();
                            GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                            doActivate = true;
                            break;
                        }
                    }
                }
            }

            if (!doActivate)
            {
                // 在庫区分
                this.tEdit_StockDiv.Focus();
            }

        }

        /// <summary>
        /// グリッドシフトタブ制御
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドにフォーカスがある場合のシフトタブ移動を制御します。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetGridShiftTabFocus(ref ChangeFocusEventArgs e)
        {
            e.NextCtrl = null;
            this.GoodsBarCodeRevn_Grid.Focus();

            int rowIndex = this.GoodsBarCodeRevn_Grid.Rows.Count - 1;
            string columnKey = string.Empty;
            if (this.GoodsBarCodeRevn_Grid.ActiveCell == null)
            {
                // アクティブ行
                if (this.GoodsBarCodeRevn_Grid.ActiveRow != null)
                {
                    rowIndex = this.GoodsBarCodeRevn_Grid.ActiveRow.Index;
                    // 商品バーコード種別
                    columnKey = GoodsBarCodeRevnTbl.ct_Col_GoodsNo;
                }
            }
            else
            {
                // アクティブCell
                rowIndex = this.GoodsBarCodeRevn_Grid.ActiveCell.Row.Index;
                columnKey = GoodsBarCodeRevn_Grid.ActiveCell.Column.Key;
                this.GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.ExitEditMode);
            }

            bool doActivate = false;
            // 商品バーコード
            if (columnKey == GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode)
            {
                // 商品バーコード種別
                if (GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation == Activation.AllowEdit)
                {
                    GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activate();
                    GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                    doActivate = true;
                }
            }

            if (!doActivate)
            {
                for (int i = rowIndex; i >= 1; i--)
                {
                    // アクティブ行探し
                    if (!GoodsBarCodeRevn_Grid.Rows[i - 1].IsFilteredOut)
                    {
                        // 商品バーコード
                        if (GoodsBarCodeRevn_Grid.Rows[i - 1].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activation == Activation.AllowEdit)
                        {
                            GoodsBarCodeRevn_Grid.Rows[i - 1].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activate();
                            GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                            doActivate = true;
                            break;
                        }
                    }
                }
            }
            if (!doActivate)
            {
                if (this.uButton_SectionGuide.Enabled == true)
                {
                    // 拠点ガイド
                    this.uButton_SectionGuide.Focus();
                }
                else
                {
                    // 品番
                    this.tEdit_GoodsNo.Focus();
                }
            }
        }

        #endregion

        #region [選択行インデックス取得]
        /// <summary>
        /// 明細グリッド選択行、アクティブセルの行インデックス取得
        /// </summary>
        /// <returns>選択行インデックスのList</returns>
        /// <remarks>
        /// <br>Note       : 明細グリッド選択行、アクティブセルの行インデックス取得。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private List<int> GetSelectRowIndex()
        {
            List<int> rowIndexList = new List<int>();

            if (this.GoodsBarCodeRevn_Grid.ActiveCell != null)
            {
                // セルアクティブ
                rowIndexList.Add(this.GoodsBarCodeRevn_Grid.ActiveCell.Row.Index);
            }
            else if (this.GoodsBarCodeRevn_Grid.Selected.Rows.Count != 0)
            {
                foreach (UltraGridRow ultraRow in this.GoodsBarCodeRevn_Grid.Selected.Rows)
                {
                    rowIndexList.Add(ultraRow.Index);
                }
            }

            return rowIndexList;
        }
        #endregion

        #region [グリッド行の背景色を設定]
        /// <summary>
        /// 明細グリッド各行の背景色を設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 明細グリッド各行の背景色を設定。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetGridColorAll()
        {
            UltraGridRow dr;

            for (int i = 0; i < this.GoodsBarCodeRevn_Grid.Rows.Count; i++)
            {
                dr = this.GoodsBarCodeRevn_Grid.Rows[i];

                // 明細グリッド行の背景色を設定
                this.SetGridColorRow(dr);
            }
        }

        /// <summary>
        /// 明細グリッド行の背景色を設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 明細グリッド行の背景色を設定。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetGridColorRow(UltraGridRow dr)
        {
            // 行番号
            dr.Cells[GoodsBarCodeRevnTbl.ct_Col_RowNo].Appearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            dr.Cells[GoodsBarCodeRevnTbl.ct_Col_RowNo].Appearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);

            // 削除行はピンク
            if (StrObjToString(dr.Cells[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Text) == "1")
            {
                dr.Cells[GoodsBarCodeRevnTbl.ct_Col_RowNo].Appearance.BackColorDisabled = Color.Pink;
                dr.Cells[GoodsBarCodeRevnTbl.ct_Col_RowNo].Appearance.BackColorDisabled2 = Color.Pink;
            }

            if (dr.Selected)
            {
                // 選択行の場合
                foreach (UltraGridCell cell in dr.Cells)
                {
                    if (cell.Column.Key != GoodsBarCodeRevnTbl.ct_Col_RowNo)
                    {
                        // 無効行もActiveセル色で上書き
                        cell.Appearance.BackColor = Color.FromArgb(251, 230, 148);
                        cell.Appearance.BackColor2 = Color.FromArgb(238, 149, 21);
                        cell.Appearance.BackColorDisabled = Color.FromArgb(251, 230, 148);
                        cell.Appearance.BackColorDisabled2 = Color.FromArgb(238, 149, 21);
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                    }
                }
            }
            else
            {
                // 削除行の場合
                if (StrObjToString(dr.Cells[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Text) == "1")
                {
                    foreach (UltraGridCell cell in dr.Cells)
                    {
                        if (cell.Column.Key != GoodsBarCodeRevnTbl.ct_Col_RowNo)
                        {
                            cell.Appearance.BackColor = Color.Pink;
                            cell.Appearance.BackColor2 = Color.Pink;
                            cell.Appearance.BackColorDisabled = Color.Pink;
                            cell.Appearance.BackColorDisabled2 = Color.Pink;
                        }
                    }
                    return;
                }

                // 通常色設定
                if (dr.Index % 2 == 0)
                {
                    foreach (UltraGridCell cell in dr.Cells)
                    {
                        if (cell.Column.Key != GoodsBarCodeRevnTbl.ct_Col_RowNo)
                        {
                            cell.Appearance.BackColor = Color.White;
                            cell.Appearance.BackColor2 = Color.White;
                            cell.Appearance.BackColorDisabled = Color.White;
                            cell.Appearance.BackColorDisabled2 = Color.White;
                        }
                    }

                }
                else
                {
                    foreach (UltraGridCell cell in dr.Cells)
                    {
                        if (cell.Column.Key != GoodsBarCodeRevnTbl.ct_Col_RowNo)
                        {
                            cell.Appearance.BackColor = Color.Lavender;
                            cell.Appearance.BackColor2 = Color.Lavender;
                            cell.Appearance.BackColorDisabled = Color.Lavender;
                            cell.Appearance.BackColorDisabled2 = Color.Lavender;
                        }
                    }
                }

                // キー
                string dicKey = StrObjToString(dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].Value) + "_" + StrObjToString(dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].Value);
                if (_goodsBarCodeRevnDic.ContainsKey(dicKey))
                {
                    // 変更するデータ: 商品バーコード
                    if (StrObjToString(_goodsBarCodeRevnDic[dicKey].GoodsBarCode).Trim() != StrObjToString(dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Value).Trim())
                    {
                        dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Appearance.BackColor = Color.Lime;
                        dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Appearance.BackColor2 = Color.Lime;
                        dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Appearance.BackColorDisabled = Color.Lime;
                        dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Appearance.BackColorDisabled2 = Color.Lime;
                    }
                    // 変更するデータ: 商品バーコード種別
                    if (_goodsBarCodeRevnDic[dicKey].GoodsBarCodeKind != IntObjToInt(dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Value))
                    {
                        dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Appearance.BackColor = Color.Lime;
                        dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Appearance.BackColor2 = Color.Lime;
                        dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Appearance.BackColorDisabled = Color.Lime;
                        dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Appearance.BackColorDisabled2 = Color.Lime;
                    }
                }
            }
        }

        # endregion

        #region 削除と復活ボタン制御
        /// <summary>
        /// ボタン制御をCellアクティブとRowアクティブで振り分ける
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン制御をCellアクティブとRowアクティブで振り分ける</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetDeleteAndReviveRowButtonEnable()
        {
            if (this.GoodsBarCodeRevn_Grid.ActiveCell != null)
            {
                // グリッドCellアクティブを指定した、ボタン押下可否制御を行う。
                this.SetDeleteAndReviveRowButtonEnableByActiveCell(this.GoodsBarCodeRevn_Grid.ActiveCell.Row.Index);
            }
            else
            {
                // 指定グリッド行の状態に応じたボタン押下可否制御を行う
                this.SetDeleteAndReviveRowButtonEnableBySelectedRows();
            }
        }

        /// <summary>
        /// グリッドCellアクティブを指定した、ボタン押下可否制御を行う。
        /// </summary>
        /// <param name="rowIndex">グリッドCellアクティブを指定した行</param>
        /// <remarks>
        /// <br>Note       : グリッドCellアクティブを指定した、ボタン押下可否制御を行う。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetDeleteAndReviveRowButtonEnableByActiveCell(int rowIndex)
        {
            #region 削除と復活ボタン制御

            // 商品は削除予約状態か
            if (StrObjToString(this.GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Text) == "1")
            {
                // 削除予約行なので、削除押下不可
                this.uButton_RowGoodsDelete.Enabled = false;
                // 復活予約行なので、復活押下可
                this.uButton_RowGoodsRevive.Enabled = true;
            }
            else
            {
                // 正常行なので、削除押下可
                this.uButton_RowGoodsDelete.Enabled = true;
                // 正常行なので、復活押下不可
                this.uButton_RowGoodsRevive.Enabled = false;
            }
            #endregion
        }

        /// <summary>
        /// 指定グリッド行の状態に応じたボタン押下可否制御を行う。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 指定グリッド行の状態に応じたボタン押下可否制御を行う。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetDeleteAndReviveRowButtonEnableBySelectedRows()
        {
            #region 削除と復活ボタン制御
            // 選択する行に正常行があるかの状態
            bool isGoodsNotDelete = false;
            // 選択する行に削除行があるかの状態
            bool isGoodNotRevive = false;

            #region 行状態チェック
            foreach (UltraGridRow ultraRow in this.GoodsBarCodeRevn_Grid.Selected.Rows)
            {
                if (StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Text) == "0")
                {
                    // 選択する正常行がある
                    isGoodsNotDelete = true;
                }
                else
                {
                    // 選択する削除行がある
                    isGoodNotRevive = true;
                }
                if (isGoodsNotDelete && isGoodNotRevive)
                {
                    break;
                }
            }
            #endregion

            if (!isGoodsNotDelete)
            {
                // 選択する正常行が無い場合、削除ボタン押下不可
                this.uButton_RowGoodsDelete.Enabled = false;
            }
            else
            {
                this.uButton_RowGoodsDelete.Enabled = true;
            }

            if (!isGoodNotRevive)
            {
                // 選択する削除行が無い場合、復活ボタン押下不可
                this.uButton_RowGoodsRevive.Enabled = false;
            }
            else
            {
                this.uButton_RowGoodsRevive.Enabled = true;
            }

            #endregion
        }

        #endregion

    }
}