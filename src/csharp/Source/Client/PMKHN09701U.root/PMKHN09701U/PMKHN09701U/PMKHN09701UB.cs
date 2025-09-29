//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自動回答品目設定マスタメンテナンス
// プログラム概要   : 自動回答品目設定マスタの操作を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/10/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2012/11/13  修正内容 : 12/12配信 システムテスト障害№6対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2012/11/16  修正内容 : 12/12配信 システムテスト障害№32,38,37,39対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 三戸 伸悟
// 作 成 日  2012/11/22  修正内容 : 2012/12/12配信予定システムテスト障害№58対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 三戸 伸悟
// 作 成 日  2012/11/22  修正内容 : 2012/12/12配信予定システムテスト障害№77対応
//----------------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Infragistics.Win.Misc;
using System.Collections.Generic;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 自動回答品目設定マスタメンテナンス編集フォーム
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自動回答品目設定マスタの入力を行います。</br>
    /// <br>Update Note: </br>
    /// <br></br>
    /// </remarks>
    public partial class PMKHN09701UB : System.Windows.Forms.Form
    {
        #region Private Menbers

        private string _enterpriseCode;         // 企業コード

        // ＵＩ配置用（開始位置）
        // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№38 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // private const int ct_PositionStart = 119;
        private const int ct_PositionStart = 122;
        // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№38 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ＵＩ配置用（間隔）
        // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№38 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // private const int ct_Interval = 4;
        private const int ct_Interval = 8;
        // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№38 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // 自動回答品目設定アクセスクラス
        private AutoAnsItemStAcs _autoAnsItemStAcs;
        // 自動回答品目設定マスメン用ガイド制御クラス
        private AutoAnsItemStGuideControl _guideControl;

        // 拠点コード（前回値）
        private string _prevSectionCode;
        // 得意先コード（前回値）
        private int _prevCustomerCode;
        // メーカーコード（前回値）
        private int _prevGoodsMakerCd;
        // 商品中分類コード（前回値）
        private int _prevGoodsMGroup;
        // ＢＬコード（前回値）
        private int _prevBLGoodsCode;

        // 編集中レコードGUID
        private Guid _recordGuid;
        // グリッド　データソース用
        DataView _view = null;

        // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        private bool _GridEnterUP = true;
        // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // 終了時の編集チェック用
        private List<AutoAnsItemSt> _recordCloneList = new List<AutoAnsItemSt>();
        // 編集中レコード
        private List<AutoAnsItemSt> _autoAnsItemStList = new List<AutoAnsItemSt>();

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string DELETE_DATE_TITLE = "削除日";
        private const string SECTIONCODE_TITLE = "拠点コード";
        private const string SECTIONGUIDENM_TITLE = "拠点名";
        private const string SUBSECTIONCODE_TITLE = "自動回答品目設定コード";
        private const string SUBSECTIONNAME_TITLE = "自動回答品目設定名";

        // 画面レイアウト用定数
        private const int BUTTON_LOCATION1_X = 196;     // 完全削除ボタン位置X
        private const int BUTTON_LOCATION2_X = 323;     // 復活ボタン位置X
        private const int BUTTON_LOCATION3_X = 450;     // 保存ボタン位置X
        private const int BUTTON_LOCATION4_X = 577;     // 閉じるボタン位置X
        private const int BUTTON_LOCATION_Y = 8;        // ボタン位置Y(共通)

        // Message関連定義
        private const string ASSEMBLY_ID = "PMKHN09700U";
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "入力された品目設定は既に登録されています。編集を行いますか？";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";

        // グリッド関連
        /// <summary> グリッド用テーブル名称 </summary>
        private const string ct_TABLE_FORGRID = "ForGrid";
        
        #endregion

        #region プロパティ
        /// <summary>
        /// 保存実行済みフラグ
        /// </summary>
        private bool _isSave = false;
        /// <summary>
        /// 保存実行済みフラグ
        /// </summary>
        public bool IsSave
        {
            get
            {
                return _isSave;
            }
        }
        #endregion

        # region Constructor

        /// <summary>
        /// 自動回答品目設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : フォームクラスの新しいインスタンスを初期化します。</br>
        /// </remarks>
        public PMKHN09701UB( AutoAnsItemStAcs scmPrtSettingAcs, AutoAnsItemStGuideControl scmPrtSettingGuideControl )
        {
            InitializeComponent();

            // 各種インスタンスを受け取る
            _autoAnsItemStAcs = scmPrtSettingAcs;
            _guideControl = scmPrtSettingGuideControl;
            _guideControl.AfterRenewal += new EventHandler( GuideControl_AfterRenewal );

            // 企業コードを取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 表示更新
            tComboEditor_SetKind1.Value = 1; //1:拠点
            DrawPanelsBySetKind1();

            // 拠点コード（前回値）
            _prevSectionCode = string.Empty;
            // 得意先コード（前回値）
            _prevCustomerCode = 0;
            // メーカーコード（前回値）
            _prevGoodsMakerCd = 0;
            // 商品中分類コード（前回値）
            _prevGoodsMGroup = 0;
            // ＢＬコード（前回値）
            _prevBLGoodsCode = 0;

            // 編集中レコードのGUIDとレコード
            _recordGuid = Guid.Empty;
            _autoAnsItemStList = new List<AutoAnsItemSt>();
        }

        /// <summary>
        /// 最新情報取得後処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuideControl_AfterRenewal( object sender, EventArgs e )
        {
            // 前回値クリア
            _prevSectionCode = string.Empty;
            _prevCustomerCode = 0;
            _prevGoodsMGroup = 0;
            _prevBLGoodsCode = 0;
            _prevGoodsMakerCd = 0;

            // 名称再取得
            // 拠点
            MasterRead( ref tEdit_SectionCodeAllowZero, ref tEdit_SectionGuideNm, ref _prevSectionCode, ReadSection );
            // 得意先
            MasterRead( ref tNedit_CustomerCode, ref tEdit_CustomerName, ref _prevCustomerCode, ReadCustomer );
            // 商品中分類
            MasterReadForGoodsMGroup(ref tEdit_GoodsMGroup, ref tEdit_GoodsMGroupName, ref _prevGoodsMGroup, ReadGoodsMGroup);
            // ＢＬコード
            MasterReadForBlGoodsCode( ref tNedit_BLGoodsCode, ref tEdit_BLCodeName, ref _prevBLGoodsCode, ReadBLCode );
            // メーカー
            MasterRead(ref tNedit_GoodsMakerCd, ref tEdit_GoodsMakerName, ref _prevGoodsMakerCd, ReadMaker);
        }

        /// <summary>
        /// パネルコントロール描画処理
        /// </summary>
        private void DrawPanelsBySetKind1()
        {
            int currPosition = ct_PositionStart;

            // 全てor拠点or得意先
            switch ( (int)tComboEditor_SetKind1.Value )
            {
                // 0:全て
                default:
                case 0:
                    panel_Section.Visible = false;
                    panel_Section.Enabled = false;
                    panel_Customer.Visible = false;
                    panel_Customer.Enabled = false;
                    panel_Line.Visible = false;
                    break;
                // 1:拠点
                case 1:
                    panel_Section.Visible = true;
                    panel_Section.Enabled = true;
                    panel_Customer.Visible = false;
                    panel_Customer.Enabled = false;
                    panel_Line.Visible = true;

                    panel_Section.Top = currPosition;
                    currPosition += panel_Section.Height + ct_Interval;
                    panel_Line.Top = currPosition;
                    currPosition += panel_Line.Height + ct_Interval;
                    break;
                // 2:得意先
                case 2:
                    panel_Section.Visible = false;
                    panel_Section.Enabled = false;
                    panel_Customer.Visible = true;
                    panel_Customer.Enabled = true;
                    panel_Line.Visible = true;

                    panel_Customer.Top = currPosition;
                    currPosition += panel_Customer.Height + ct_Interval;
                    panel_Line.Top = currPosition;
                    currPosition += panel_Line.Height + ct_Interval;
                    break;
            }

            // クリア
            PanelClear(panel_Section);
            PanelClear(panel_Customer);

            // 拠点
            if (panel_Section.Enabled)
            {
                string sectionCode = tEdit_SectionCodeAllowZero.Text.Trim();
                if (sectionCode == string.Empty || sectionCode == "00")
                {
                    tEdit_SectionCodeAllowZero.Text = "00";
                    tEdit_SectionGuideNm.Text = "全社";
                }
            }

            // 商品中分類
            if (panel_GoodsMGroup.Enabled)
            {
                string goodsMGroup = tEdit_GoodsMGroup.Text.Trim();
                if (goodsMGroup == string.Empty || goodsMGroup == "0000")
                {
                    tEdit_GoodsMGroup.Text = "0000";
                    tEdit_SectionGuideNm.Text = "共通";
                }
            }

            // 次の処理も続けて実行
            DrawPanelsBySetKind2();
        }
        /// <summary>
        /// パネルコントロール描画処理
        /// </summary>
        private void DrawPanelsBySetKind2()
        {
            # region [開始位置]
            int currPosition;
            if ( (int)tComboEditor_SetKind1.Value != 0 )
            {
                currPosition = panel_Line.Top + panel_Line.Height + ct_Interval;
            }
            else
            {
                currPosition = ct_PositionStart;
            }
            # endregion

            # region [表示・非表示判定]
            bool blCodeEnabled = false;

            // メーカー,中分類,ＢＬコード,品番
            switch ( (int)tComboEditor_SetKind2.Value )
            {
                // 2:中分類＋BLコード
                case 2:
                    blCodeEnabled = true;
                    break;
            }
            # endregion

            # region [コントロールの配置]
            // 商品中分類
            panel_GoodsMGroup.Top = currPosition;
            currPosition += panel_GoodsMGroup.Height + ct_Interval;

            // ＢＬコード
            if ( blCodeEnabled )
            {
                panel_BLCode.Top = currPosition;
                currPosition += panel_BLCode.Height + ct_Interval;
            }
            panel_BLCode.Enabled = blCodeEnabled;
            panel_BLCode.Visible = blCodeEnabled;

            // メーカー
            panel_GoodsMaker.Top = currPosition;
            currPosition += panel_GoodsMaker.Height + ct_Interval;

            // 自動回答区分
            panel_AutoAnswerDiv.Top = currPosition;
            currPosition += panel_AutoAnswerDiv.Height + ct_Interval;

            // 優先順位
            panel_Priority.Top = currPosition;
            currPosition += panel_Priority.Height + ct_Interval;

            // グリッド
            // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№8 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // panel_Grid.Top = currPosition;
            int btm = panel_Grid.Bottom;
            panel_Grid.Top = currPosition;
            panel_Grid.Height += btm - panel_Grid.Bottom;
            currPosition += panel_Grid.Height + ct_Interval;
            // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№8 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            # endregion

            # region [パネル内のクリア]
            // パネル内クリア
            PanelClear(panel_GoodsMGroup);
            PanelClear(panel_BLCode);
            PanelClear(panel_GoodsMaker);
            SetAutoAnswerDivEnabled(false);
            PanelClear(panel_AutoAnswerDiv);
            PanelClear(panel_Priority);
            PanelClear(panel_Grid);
            # endregion
        }

        /// <summary>
        /// パネルのクリア処理
        /// </summary>
        /// <param name="panel">対象パネル</param>
        private void PanelClear(Panel panel)
        {
            // パネル内クリア
            ClearEditOnPanel(panel);

            // 前回値のクリア
            if (panel.Equals(panel_Section))
            {
                _prevSectionCode = string.Empty;
            }
            else if (panel.Equals(panel_Customer))
            {
                _prevCustomerCode = 0;
            }
            else if (panel.Equals(panel_GoodsMGroup))
            {
                tEdit_GoodsMGroup.Text = "0000";
                tEdit_GoodsMGroupName.Text = "共通";
                _prevGoodsMGroup = 0;
            }
            else if (panel.Equals(panel_BLCode))
            {
                _prevBLGoodsCode = 0;
            }
            else if (panel.Equals(panel_GoodsMaker))
            {
                _prevGoodsMakerCd = 0;
            }
            else if (panel.Equals(panel_AutoAnswerDiv))
            {
                tComboEditor_AutoAnswerDivInitial();
            }
            else if(panel.Equals(panel_Grid))
            {
                GridNew();
            }
        }
        /// <summary>
        /// パネル内エディットクリア処理
        /// </summary>
        /// <param name="panel"></param>
        private void ClearEditOnPanel( Panel panel )
        {
            // 一般的には再帰処理が必要だが、作り的に不要なのが分かっているので簡略化
            foreach ( Control ctrl in panel.Controls )
            {
                // TNEditはTEditを継承するので,この判定に含まれる
                if ( ctrl is TEdit )
                {
                    // 入力クリア
                    (ctrl as TEdit).Clear();
                }
                else if (ctrl is TComboEditor)
                {
                    (ctrl as TComboEditor).Items.Clear();
                }
                else if (ctrl is UltraGrid)
                {
                    GridNew();
                }
            }
        }
        # endregion

        # region Properties

        /// <summary>
        /// 編集中レコードＧＵＩＤ
        /// </summary>
        public Guid RecordGuid
        {
            get { return _recordGuid; }
            set { _recordGuid = value; }
        }

        # endregion

        # region [private delegate]
        /// <summary>
        /// 各種マスタ読み込みデリゲート（数値コード用）
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private delegate bool MasterReadForNumber(ref int code, out string name);
        /// <summary>
        /// 各種マスタ読み込み（デリゲートBLコード用）
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private delegate bool MasterReadForBlCode(ref int code, out string name,out int goodsMGroup);
        /// <summary>
        /// 各種マスタ読み込みデリゲート（文字列コード用）
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private delegate bool MasterReadForText( ref string code, out string name );
        # endregion

        # region Private Methods
        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// </remarks>
        private void ScreenClear()
        {
            // モードラベル
            this.Mode_Label.Text = INSERT_MODE;

            // ボタン
            this.Delete_Button.Visible  = true;  // 完全削除ボタン
            this.Revive_Button.Visible  = true;  // 復活ボタン
            this.Ok_Button.Visible      = true;  // 保存ボタン
            this.Cancel_Button.Visible = true;  // 閉じるボタン
            this.Renewal_Button.Visible = true;  // 最新情報ボタン
            this.Delete_Button.Location = new Point(BUTTON_LOCATION1_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置
            this.Revive_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 復活ボタン位置
            this.Ok_Button.Location     = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 保存ボタン位置
            this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // 閉じるボタン位置
            this.Renewal_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 復活ボタン位置

            // 拠点名
            this.tEdit_SectionCodeAllowZero.Text = "00";
            this.tEdit_SectionGuideNm.Text = "全社";

            // 商品中分類
            this.tEdit_GoodsMGroup.Text = "0000";
            this.tEdit_GoodsMGroupName.Text = "共通";
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            if ( this.RecordGuid == null || this.RecordGuid == Guid.Empty )
            {
                // 新規
                _autoAnsItemStList = new List<AutoAnsItemSt>();
                ScreenInputPermissionControl( 0 );
            }
            else
            {
                // レコード取得
                AutoAnsItemSt autoAnsItemSt = _autoAnsItemStAcs.GetRecordForMaintenance(this.RecordGuid);
                _autoAnsItemStList = _autoAnsItemStAcs.GetRecordListForMaintenance(GetFilter(autoAnsItemSt),this.uGrid_Details2.Rows.Count);

                if ( _autoAnsItemStList[0].LogicalDeleteCode == 0 )
                {
                    // 更新
                    ScreenInputPermissionControl( 1 );
                }
                else
                {
                    // 削除
                    ScreenInputPermissionControl( 2 );
                }
            }
        }

        /// <summary>
        /// 自動回答品目設定マスタレコードから、検索条件の作成
        /// 検索キー
        /// </summary>
        /// <param name="r">自動回答品目設定マスタレコード</param>
        /// <returns>
        /// 検索条件文字列　検索キー：企業コード、拠点コード、得意先コード
        /// 商品中分類コード、BL商品コード、商品メーカーコード
        /// </returns>
        private string GetFilter(AutoAnsItemSt r)
        {
            return string.Format(
                "{0}='{1}' AND " +
                "{2}='{3}' AND " +
                "{4}='{5}' AND " +
                "{6}='{7}' AND " +
                "{8}='{9}' AND " +
                "{10}='{11}' "
                , AutoAnsItemStAcs.ct_COL_ENTERPRISECODE, r.EnterpriseCode.ToString()
                , AutoAnsItemStAcs.ct_COL_SECTIONCODE, r.SectionCode
                , AutoAnsItemStAcs.ct_COL_CUSTOMERCODE, r.CustomerCode
                , AutoAnsItemStAcs.ct_COL_GOODSMGROUP, r.GoodsMGroup
                , AutoAnsItemStAcs.ct_COL_BLGOODSCODE, r.BLGoodsCode
                , AutoAnsItemStAcs.ct_COL_GOODSMAKERCD, r.GoodsMakerCd);
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="setType">設定タイプ 0:親-新規, 1:親-更新, 2:親-削除, 3:子-新規, 4:子-更新, 5:子-削除</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            int setKind1;
            int setKind2;

            switch ( setType )
            {
                // 0:新規
                default:
                case 0:
                    // ボタン
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Renewal_Button.Visible = true;

                    // パネル
                    this.panel_SetKind.Enabled = true;
                    this.panel_Section.Enabled = true;
                    this.panel_Customer.Enabled = true;
                    this.panel_GoodsMaker.Enabled = true;
                    this.panel_GoodsMGroup.Enabled = true;
                    this.panel_BLCode.Enabled = true;
                    this.panel_AutoAnswerDiv.Enabled = true;

                    break;
                // 1:更新
                case 1:
                    // 設定種別取得
                    GetSetKind( _autoAnsItemStList[0], out setKind1, out setKind2 );
                    tComboEditor_SetKind1.Value = setKind1;
                    tComboEditor_SetKind2.Value = setKind2;

                    // ボタン
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;
                    this.Renewal_Button.Visible = true;

                    // パネル
                    this.panel_SetKind.Enabled = false;
                    this.panel_Section.Enabled = false;
                    this.panel_Customer.Enabled = false;
                    this.panel_GoodsMaker.Enabled = false;
                    this.panel_GoodsMGroup.Enabled = false;
                    this.panel_BLCode.Enabled = false;
                    this.panel_AutoAnswerDiv.Enabled = true;

                    break;
                // 2:削除
                case 2:
                    // 設定種別取得
                    GetSetKind(_autoAnsItemStList[0], out setKind1, out setKind2);
                    tComboEditor_SetKind1.Value = setKind1;
                    tComboEditor_SetKind2.Value = setKind2;

                    // ボタン
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Location = new Point( BUTTON_LOCATION2_X, BUTTON_LOCATION_Y ); // 完全削除ボタン位置
                    this.Revive_Button.Location = new Point( BUTTON_LOCATION3_X, BUTTON_LOCATION_Y ); // 復活ボタン位置
                    this.Cancel_Button.Location = new Point( BUTTON_LOCATION4_X, BUTTON_LOCATION_Y ); // 閉じるボタン位置

                    // パネル
                    this.panel_SetKind.Enabled = false;
                    this.panel_Section.Enabled = false;
                    this.panel_Customer.Enabled = false;
                    this.panel_GoodsMaker.Enabled = false;
                    this.panel_GoodsMGroup.Enabled = false;
                    this.panel_BLCode.Enabled = false;
                    this.panel_AutoAnswerDiv.Enabled = false;
                    this.panel_Grid.Enabled = false;
                    this.panel_Priority.Enabled = false;

                    break;
            }
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (_autoAnsItemStList.Count.Equals(0) || _autoAnsItemStList[0].FileHeaderGuid == null || _autoAnsItemStList[0].FileHeaderGuid == Guid.Empty)
            {
                //---------------------------------------------
                // 新規
                //---------------------------------------------
                this.Mode_Label.Text = INSERT_MODE;

                // 画面展開処理
                RecordToScreen(_autoAnsItemStList);

                // クローン作成
                CreateRecordCloneLIst();
                this._recordCloneList = DispToRecord(this._recordCloneList);
            }
            else if ( _autoAnsItemStList[0].LogicalDeleteCode == 0 )
            {
                //---------------------------------------------
                // 更新
                //---------------------------------------------
                this.Mode_Label.Text = UPDATE_MODE;

                // 画面展開処理
                RecordToScreen( _autoAnsItemStList );

                // クローン作成
                CreateRecordCloneLIst();
                this._recordCloneList = DispToRecord(this._recordCloneList);
            }
            else
            {
                //---------------------------------------------
                // 削除
                //---------------------------------------------
                this.Mode_Label.Text = DELETE_MODE;

                // 画面展開処理
                RecordToScreen(_autoAnsItemStList);
            }
        }

        /// <summary>
        /// 拠点クラス画面展開処理
        /// </summary>
        /// <param name="secInfoSet">拠点オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// </remarks>
        private void SecInfoSetToScreen(SecInfoSet secInfoSet)
        {
            this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode;       // 拠点コード
            this.tEdit_SectionGuideNm.Text  = secInfoSet.SectionGuideNm;    // 拠点名称
        }

        /// <summary>
        /// 自動回答品目設定クラス画面展開処理
        /// </summary>
        /// <param name="autoAnsItemStList">自動回答品目設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// </remarks>
        private void RecordToScreen(List<AutoAnsItemSt> autoAnsItemStList)
        {
            if (autoAnsItemStList == null ||  autoAnsItemStList.Count.Equals(0))
            {
                return;
            }

            // 拠点コード、名称
            if (autoAnsItemStList[0].SectionCode.Trim() == "00" || autoAnsItemStList[0].SectionCode.Trim() == string.Empty)
            {
                this.tEdit_SectionCodeAllowZero.Text = "00";
                this.tEdit_SectionGuideNm.Text = "全社";
            }
            else
            {
                this.tEdit_SectionCodeAllowZero.Text = autoAnsItemStList[0].SectionCode.Trim();
                this.tEdit_SectionGuideNm.Text = autoAnsItemStList[0].SectionNm.Trim();
            }

            // 得意先コード
            this.tNedit_CustomerCode.SetInt(autoAnsItemStList[0].CustomerCode);

            // 得意先名
            this.tEdit_CustomerName.Text = autoAnsItemStList[0].CustomerName.Trim();

            // 商品中分類コード、名称
            if (autoAnsItemStList[0].GoodsMGroup.Equals(0))
            {
                this.tEdit_GoodsMGroup.Text = "0000";
                this.tEdit_GoodsMGroupName.Text = "共通";
            }
            else
            {
                this.tEdit_GoodsMGroup.Text = autoAnsItemStList[0].GoodsMGroup.ToString("0000");
                this.tEdit_GoodsMGroupName.Text = autoAnsItemStList[0].GoodsMGroupName.Trim();
            }

            // ＢＬコード
            this.tNedit_BLGoodsCode.SetInt(autoAnsItemStList[0].BLGoodsCode);

            // ＢＬコード名
            this.tEdit_BLCodeName.Text = autoAnsItemStList[0].BLGoodsName.Trim();

            // メーカーコード
            this.tNedit_GoodsMakerCd.SetInt(autoAnsItemStList[0].GoodsMakerCd);

            // メーカー名
            this.tEdit_GoodsMakerName.Text = autoAnsItemStList[0].MakerName.Trim();

            // 種別の有無（グリッドの使用有無）を判断するため、更新後処理を実施
            AfterUpdate();

            // 削除モードの場合
            if (this.Mode_Label.Text == DELETE_MODE)
            {
                // 自動回答区分を使用不可に
                SetAutoAnswerDivEnabled(false);
            }

            if (IsUseGrid())
            {
                // 優良メーカー かつ　種別が存在する
                foreach (DataRow row in this._view.Table.Rows)
                {
                    foreach (AutoAnsItemSt autoAnsItemSt in autoAnsItemStList)
                    {
                        if (row[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Equals(autoAnsItemSt.PrmSetDtlNo2))
                        {
                            // 自動回答区分
                            row[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV] = autoAnsItemSt.AutoAnswerDiv;
                            // 優先順位 
                            row[AutoAnsItemStAcs.ct_COL_PRIORITYORDER] = autoAnsItemSt.PriorityOrder;
                            break;
                        }
                    }
                }

                // 優先順位セルの使用可否設定
                foreach (UltraGridRow row in this.uGrid_Details2.Rows)
                {
                    
                    if (PMKHN09701UA.GetIntNullZero(row.Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Value) == 2)
                    {
                        row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Activation = Activation.AllowEdit;
                    }
                    else
                    {
                        row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Activation = Activation.Disabled;
                    }
                }
            }
            else
            {
                // 純正メーカー　または　優良メーカーかつ種別が存在しない
                // 自動回答区分
                this.tComboEditor_AutoAnswerDiv.Value = autoAnsItemStList[0].AutoAnswerDiv;
                // 優先順位 "0"は表示しない
                this.tNedit_PriorityOrder.SetInt(autoAnsItemStList[0].PriorityOrder);
            }
        }

        /// <summary>
        /// グリッドを使用しているか否か
        /// </summary>
        /// <returns>
        /// true：グリッド使用
        /// false：グリッド不使用
        /// </returns>
        private bool IsUseGrid()
        {
            // グリッドのデータソースにバインドしているビューの行数で判断
            return this._view.Table.Rows.Count >= 1;
        }

        /// <summary>
        /// 画面情報拠点クラス格納処理
        /// </summary>
        /// <param name="secInfoSet">拠点オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からオブジェクトにデータを格納します。</br>
        /// </remarks>
        private void DispToSecInfoSet(ref SecInfoSet secInfoSet)
        {
            secInfoSet.SectionCode      = this.tEdit_SectionCodeAllowZero.Text;      // 拠点コード
            secInfoSet.SectionGuideNm   = this.tEdit_SectionGuideNm.Text;   // 拠点名称
            secInfoSet.EnterpriseCode   = this._enterpriseCode;             // 企業コード
        }

        /// <summary>
        /// 画面情報自動回答品目設定クラス格納処理
        /// </summary>
        /// <param name="Subsection">自動回答品目設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から自動回答品目設定オブジェクトにデータを格納します。</br>
        /// </remarks>
        private List<AutoAnsItemSt> DispToRecord(List<AutoAnsItemSt> autoAnsItemSt)
        {
            foreach (AutoAnsItemSt r in autoAnsItemSt)
            {
                // 企業コード
                r.EnterpriseCode = this._enterpriseCode;

                // 拠点コード
                r.SectionCode = this.GetDispValue(this.tEdit_SectionCodeAllowZero);
                // 拠点名
                r.SectionNm = this.GetDispValue(this.tEdit_SectionGuideNm);
                // 得意先コード
                r.CustomerCode = this.GetDispValue(this.tNedit_CustomerCode);
                // 得意先名
                r.CustomerName = this.GetDispValue(this.tEdit_CustomerName);
                // 商品中分類コード
                r.GoodsMGroup = this.GetDispValueForGoodsMGroup(this.tEdit_GoodsMGroup);
                // 商品中分類名
                r.GoodsMGroupName = this.GetDispValue(this.tEdit_GoodsMGroupName);
                // ＢＬコード
                r.BLGoodsCode = this.GetDispValue(this.tNedit_BLGoodsCode);
                // ＢＬコード名
                r.BLGoodsName = this.GetDispValue(this.tEdit_BLCodeName);
                // メーカーコード
                r.GoodsMakerCd = this.GetDispValue(this.tNedit_GoodsMakerCd);
                // メーカー名
                r.MakerName = this.GetDispValue(this.tEdit_GoodsMakerName);
                
                // 自動回答区分
                r.AutoAnswerDiv = (int)this.tComboEditor_AutoAnswerDiv.Value;
                // 優先順位
                r.PriorityOrder = this.GetDispValue(this.tNedit_PriorityOrder);

                // グリッド
                if (this._view.Table.Rows.Count.Equals(0))
                {
                    r.PrmSetDtlNo2 = PMKHN09701UA.NO_SETTING;
                    r.PrmSetDtlName2 = string.Empty;
                }
                else
                {
                    foreach (DataRow dr in this._view.Table.Rows)
                    {
                        if (dr[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Equals(r.PrmSetDtlNo2))
                        {
                            r.AutoAnswerDiv = PMKHN09701UA.GetIntNullZero(dr[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV]);
                            r.PriorityOrder = PMKHN09701UA.GetIntNullZero(dr[AutoAnsItemStAcs.ct_COL_PRIORITYORDER]);
                            break;
                        }
                    }
                }
            }

            return autoAnsItemSt;
        }
        /// <summary>
        /// 画面情報自動回答品目設定クラス格納処理 検索条件用
        /// </summary>
        /// <param name="autoAnsItemSt">自動回答品目設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から自動回答品目設定オブジェクトにデータを格納します。</br>
        /// </remarks>
        private void DispToRecordForRead(ref AutoAnsItemSt autoAnsItemSt)
        {
            // 企業コード
            autoAnsItemSt.EnterpriseCode = this._enterpriseCode;

            // 拠点コード
            autoAnsItemSt.SectionCode = this.GetDispValue(this.tEdit_SectionCodeAllowZero);
            // 得意先コード
            autoAnsItemSt.CustomerCode = this.GetDispValue(this.tNedit_CustomerCode);
            // 商品中分類コード
            autoAnsItemSt.GoodsMGroup = this.GetDispValueForGoodsMGroup(this.tEdit_GoodsMGroup);
            // ＢＬコード
            autoAnsItemSt.BLGoodsCode = this.GetDispValue(this.tNedit_BLGoodsCode);
            // メーカーコード
            autoAnsItemSt.GoodsMakerCd = this.GetDispValue(this.tNedit_GoodsMakerCd);
        }

        /// <summary>
        /// 画面情報自動回答品目設定クラス格納処理１
        /// </summary>
        /// <param name="Subsection">自動回答品目設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から自動回答品目設定オブジェクトにデータを格納します。</br>
        /// </remarks>
        private void DispToRecord1( ref AutoAnsItemSt autoAnsItemSt )
        {
            // 企業コード
            autoAnsItemSt.EnterpriseCode = this._enterpriseCode;

            // 拠点コード
            autoAnsItemSt.SectionCode = this.GetDispValue( this.tEdit_SectionCodeAllowZero );
            // 拠点名
            autoAnsItemSt.SectionNm = this.GetDispValue( this.tEdit_SectionGuideNm );
            // 得意先コード
            autoAnsItemSt.CustomerCode = this.GetDispValue( this.tNedit_CustomerCode );
            // 得意先名
            autoAnsItemSt.CustomerName = this.GetDispValue( this.tEdit_CustomerName );
            // 商品中分類コード
            autoAnsItemSt.GoodsMGroup = this.GetDispValueForGoodsMGroup(this.tEdit_GoodsMGroup);
            // 商品中分類名
            autoAnsItemSt.GoodsMGroupName = this.GetDispValue(this.tEdit_GoodsMGroupName);
            // ＢＬコード
            autoAnsItemSt.BLGoodsCode = this.GetDispValue(this.tNedit_BLGoodsCode);
            // ＢＬコード名
            autoAnsItemSt.BLGoodsName = this.GetDispValue(this.tEdit_BLCodeName);
            // メーカーコード
            autoAnsItemSt.GoodsMakerCd = this.GetDispValue( this.tNedit_GoodsMakerCd );
            // メーカー名
            autoAnsItemSt.MakerName = this.GetDispValue( this.tEdit_GoodsMakerName );
            // 種別（とりあえず０（設定無し）を設定）
            autoAnsItemSt.PrmSetDtlNo2 = PMKHN09701UA.NO_SETTING;
            // 種別名称（とりあえず空文字（設定無し）を設定）
            autoAnsItemSt.PrmSetDtlName2 = string.Empty;
        }

        /// <summary>
        /// 画面情報自動回答品目設定クラス格納処理２
        /// </summary>
        /// <param name="Subsection">自動回答品目設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から自動回答品目設定オブジェクトにデータを格納します。</br>
        /// </remarks>
        private void DispToRecord2(ref AutoAnsItemSt autoAnsItemSt)
        {
            autoAnsItemSt.AutoAnswerDiv = (int)this.tComboEditor_AutoAnswerDiv.Value;

            // 優先順位
            if (panel_Priority.Enabled)
            {
                autoAnsItemSt.PriorityOrder = this.GetDispValue(this.tNedit_PriorityOrder);
            }
            else
            {
                // 設定無し
                autoAnsItemSt.PriorityOrder = PMKHN09701UA.NO_SETTING;
            }

            // 優良設定詳細コード２（種別コード）
            autoAnsItemSt.PrmSetDtlNo2 = PMKHN09701UA.NO_SETTING;
            // 優良設定詳細名称２
            autoAnsItemSt.PrmSetDtlName2 = string.Empty;
        }

        /// <summary>
        /// 画面情報自動回答品目設定クラス格納処理３
        /// </summary>
        /// <param name="Subsection">自動回答品目設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から自動回答品目設定オブジェクトにデータを格納します。</br>
        /// </remarks>
        private void DispToRecord3(ref AutoAnsItemSt autoAnsItemSt,int i)
        {
            // 種別
            autoAnsItemSt.PrmSetDtlNo2 = PMKHN09701UA.GetIntNullZero(this._view.Table.Rows[i][AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2]);
            // 種別名称
            autoAnsItemSt.PrmSetDtlName2 = PMKHN09701UA.GetString(this._view.Table.Rows[i][AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2]);
            // 自動回答区分
            autoAnsItemSt.AutoAnswerDiv = PMKHN09701UA.GetIntNullZero(this._view.Table.Rows[i][AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV]);
            // 優先順位 
            autoAnsItemSt.PriorityOrder = PMKHN09701UA.GetIntNullZero(this._view.Table.Rows[i][AutoAnsItemStAcs.ct_COL_PRIORITYORDER]);
        }

        /// <summary>
        /// UI入力項目取得処理（非表示項目は初期値を返す）
        /// </summary>
        /// <param name="tEdit"></param>
        /// <returns></returns>
        private string GetDispValue( TEdit tEdit )
        {
            if ( tEdit.Visible != false )
            {
                return tEdit.Text.Trim();
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// UI入力項目取得処理（非表示項目は初期値を返す）
        /// </summary>
        /// <param name="tEdit"></param>
        /// <returns></returns>
        private int GetDispValue( TNedit tNedit )
        {
            if ( tNedit.Visible != false )
            {
                return tNedit.GetInt();
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// UI入力項目取得処理（非表示項目は初期値を返す）
        /// </summary>
        /// <param name="tEdit"></param>
        /// <returns></returns>
        private int GetDispValueForGoodsMGroup(TEdit tEdit)
        {
            if ( tEdit.Visible != false )
            {
                return PMKHN09701UA.GetIntNullZero(tEdit.Text.Trim());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note		: 画面入力情報の不正チェックを行います。</br>
        /// </remarks>
        private bool ScreenDataCheck( ref Control control, ref string message )
        {
            bool result = true;

            // 入力項目一覧
            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(tEdit_SectionCodeAllowZero);
            ctrlList.Add(tNedit_CustomerCode);
            ctrlList.Add(tEdit_GoodsMGroup);
            ctrlList.Add(tNedit_BLGoodsCode);
            ctrlList.Add(tNedit_GoodsMakerCd);
            ctrlList.Add(tNedit_PriorityOrder);
            ctrlList.Add(uGrid_Details2);

            // メッセージ一覧
            Dictionary<string, string> messageList = new Dictionary<string, string>();
            messageList.Add(tEdit_SectionCodeAllowZero.Name, "拠点コード");
            messageList.Add(tNedit_CustomerCode.Name, "得意先コード");
            messageList.Add(tEdit_GoodsMGroup.Name, "商品中分類コード");
            messageList.Add(tNedit_BLGoodsCode.Name, "ＢＬコード");
            messageList.Add(tNedit_GoodsMakerCd.Name, "メーカーコード");
            messageList.Add(tNedit_PriorityOrder.Name, "優先順位");
            messageList.Add(uGrid_Details2.Name, "優先順位");

            // 表示されていて入力可能な全ての項目は必須入力
            foreach ( Control ctrl in ctrlList )
            {
                if ( ctrl.Visible && ctrl.Enabled )
                {
                    if ( ctrl is TNedit )
                    {
                        // 未入力チェック
                        if ( (ctrl as TNedit).GetInt() == 0 )
                        {
                            control = ctrl;
                            message = messageList[ctrl.Name] + "を入力して下さい。";
                            result = false;
                            break;
                        }
                    }
                    else if ( ctrl is TEdit )
                    {
                        // 未入力チェック
                        if ( (ctrl as TEdit).Text.Trim() == string.Empty )
                        {
                            control = ctrl;
                            message = messageList[ctrl.Name] + "を入力して下さい。";
                            result = false;
                            break;
                        }
                    }
                    else if (ctrl is UltraGrid)
                    {
                        foreach (UltraGridRow row in uGrid_Details2.Rows)
                        {
                            if (row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Activation.Equals(Activation.AllowEdit))
                            {
                                if (row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value.Equals(DBNull.Value))
                                {
                                    control = ctrl;
                                    message = messageList[ctrl.Name] + "を入力して下さい。";
                                    result = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="saveTarget">保存マスタ (PrdExchPNU/PrdExchPPU)</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note　　　 : 保存処理を行います。</br>
        /// </remarks>
        private bool SaveProc()
        {
            Control control = null;
            string message = null;

            // 不正データ入力チェック
            if ( !ScreenDataCheck( ref control, ref message ) )
            {
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK );				// 表示するボタン

                control.Focus();
                return false;
            }

            // 更新
            if ( !SaveRecord() )
            {
                return false;
            }

            // 登録完了ダイアログ表示
            SaveCompletionDialog dialog = new SaveCompletionDialog();
            dialog.ShowDialog(2);

            // 保存実行フラグ更新
            _isSave = true;

            return true;
        }

        /// <summary>
        /// 自動回答品目設定テーブル更新
        /// </summary>
        /// <return>更新結果status</return>
        /// <remarks>
        /// <br>Note       : Subsectionテーブルの更新を行います。</br>
        /// </remarks>
        private bool SaveRecord()
        {
            // 登録レコード情報取得(変更前)
            if ( _autoAnsItemStList.Count.Equals(0) || _autoAnsItemStList[0].FileHeaderGuid == Guid.Empty )
            {
                AutoAnsItemSt r = _autoAnsItemStAcs.GetRecordForMaintenance(_recordGuid);
                if (IsUseGrid())
                {
                    _autoAnsItemStList = _autoAnsItemStAcs.GetRecordListForMaintenance(GetFilter(r), this.uGrid_Details2.Rows.Count);
                }
                else
                {
                    _autoAnsItemStList = _autoAnsItemStAcs.GetRecordListForMaintenance(GetFilter(r), 1);
                }
            }

            // ＵＩからデータ取得
            ArrayList writeList = GetUiData();

            // 更新
            string msg;
            int status = _autoAnsItemStAcs.Write( ref writeList, out msg );

            // エラー処理
            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // 重複処理
                    RepeatTransaction( status );
                    return false;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction( status, TMsgDisp.OPE_UPDATE, this._autoAnsItemStAcs );
                    // UI子画面強制終了処理
                    EnforcedEndTransaction();
                    return false;
                default:
                    // 登録失敗
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "SaveSubsection",				    // 処理名称
                        TMsgDisp.OPE_UPDATE,				// オペレーション
                        ERR_UPDT_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._autoAnsItemStAcs,				    // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1 );	// 初期表示ボタン

                    // UI子画面強制終了処理
                    EnforcedEndTransaction();

                    return false;
            }

            // 次回新規入力用処理
            NewEntryTransaction();

            return true;
        }

        /// <summary>
        /// ＵＩからデータ取得
        /// </summary>
        /// <param name="autoAnsItemSt"></param>
        /// <returns></returns>
        private ArrayList GetUiData()
        {
            ArrayList writeList = new ArrayList();

            if (IsUseGrid())
            {
                for (int i = 0; i < this._autoAnsItemStList.Count; i++)
                {
                    AutoAnsItemSt autoAnsItemSt = this._autoAnsItemStList[i];
                    DispToRecord1(ref autoAnsItemSt);
                    // グリッドから
                    DispToRecord3(ref autoAnsItemSt, i);
                    writeList.Add(autoAnsItemSt);
                }
            }
            else
            {
                AutoAnsItemSt autoAnsItemSt = this._autoAnsItemStList[0];
                DispToRecord1(ref autoAnsItemSt);
                DispToRecord2(ref autoAnsItemSt);
                writeList.Add(autoAnsItemSt);
            }
            return writeList;
        }

        /// <summary>
        /// 自動回答品目設定 論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 自動回答品目設定の対象レコードをマスタから論理削除します。</br>
        /// </remarks>
        private int LogicalDeleteSubsection()
        {
            int status = 0;

            return status;
        }

        /// <summary>
        /// 自動回答品目設定 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 自動回答品目設定の対象レコードをマスタから物理削除します。</br>
        /// </remarks>
        private int PhysicalDeleteRecord()
        {
            int status = 0;

            // 登録レコード情報取得(変更前)
            if ( _autoAnsItemStList.Count.Equals(0) || _autoAnsItemStList[0].FileHeaderGuid == Guid.Empty )
            {
                AutoAnsItemSt r = _autoAnsItemStAcs.GetRecordForMaintenance(_recordGuid);
                _autoAnsItemStList = _autoAnsItemStAcs.GetRecordListForMaintenance(GetFilter(r), this.uGrid_Details2.Rows.Count);
            }

            ArrayList writeList = GetUiData();

            // 物理削除
            string msg;
            status = _autoAnsItemStAcs.Delete( ref writeList, out msg );

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction( status, TMsgDisp.OPE_DELETE, this._autoAnsItemStAcs );
                    // UI子画面強制終了処理
                    EnforcedEndTransaction();

                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "PhysicalDeleteSubsection",		    // 処理名称
                        TMsgDisp.OPE_HIDE,					// オペレーション
                        ERR_RDEL_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._autoAnsItemStAcs,					// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1 );	// 初期表示ボタン

                    // UI子画面強制終了処理
                    EnforcedEndTransaction();

                    return status;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

            return status;
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 自動回答品目設定の対象レコードを復活します。</br>
        /// </remarks>
        private int ReviveRecord()
        {
            int status = 0;

            // 登録レコード情報取得(変更前)
            if (_autoAnsItemStList.Count.Equals(0) || _autoAnsItemStList[0].FileHeaderGuid == Guid.Empty)
            {
                AutoAnsItemSt r = _autoAnsItemStAcs.GetRecordForMaintenance(_recordGuid);
                _autoAnsItemStList = _autoAnsItemStAcs.GetRecordListForMaintenance(GetFilter(r), this.uGrid_Details2.Rows.Count);
            }

            // 復活、物理削除は優良設定詳細コード２を除いたキー項目（当画面から1件のレコードで済む）を
            // 検索条件とするため、パラメータを1件にする
            ArrayList writeList = new ArrayList();
            writeList.Add(GetUiData()[0]);

            string msg;
            status = this._autoAnsItemStAcs.Revival(ref writeList, out msg);


            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._autoAnsItemStAcs);
                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "ReviveSubsection",				    // 処理名称
                        TMsgDisp.OPE_UPDATE,				// オペレーション
                        ERR_RVV_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._autoAnsItemStAcs,					// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                    return status;
            }

            this.DialogResult = DialogResult.OK;
            this._isSave = true;
            this.Close();
            return status;
        }

        /// <summary>
        /// 新規登録時処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規登録時の処理を行います。</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            // 新規モードの場合は画面を終了せずに連続入力を可能とする
            if ( this.Mode_Label.Text == INSERT_MODE )
            {
                // クローン作成
                CreateRecordCloneLIst();

                // 初期フォーカス
                this.tComboEditor_SetKind1.Focus();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// クローン作成
        /// </summary>
        private void CreateRecordCloneLIst()
        {
            // クローン作成
            this._recordCloneList.Clear();

            if (this._autoAnsItemStList.Count.Equals(0))
            {
                this._recordCloneList.Add(new AutoAnsItemSt());
            }
            else
            {
                foreach (AutoAnsItemSt r in this._autoAnsItemStList)
                {
                    this._recordCloneList.Add(r.Clone());
                }
            }
        }

        /// <summary>
        /// UI子画面強制終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データ更新エラー時のUI子画面強制終了処理を行います。</br>
        /// </remarks>
        private void EnforcedEndTransaction()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 重複処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <param name="control">対象コントロール</param>
        /// <remarks>
        /// <br>Note       : データ更新時の重複処理を行います。</br>
        /// </remarks>
        private void RepeatTransaction(int status)
        {
            DialogResult result =
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                ERR_DPR_MSG, 	                    // 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.YesNo);			// 表示するボタン

            if ( result == DialogResult.Yes )
            {
                // 更新モードにする

                // レコード取得
                AutoAnsItemSt autoAnsItemSt = new AutoAnsItemSt();
                DispToRecordForRead(ref autoAnsItemSt);
                _autoAnsItemStList = new List<AutoAnsItemSt>();
                int retStatus = _autoAnsItemStAcs.Read2(autoAnsItemSt,ref _autoAnsItemStList);

                // 画面クリア処理
                ScreenClear();
                
                if ( retStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if (_autoAnsItemStList[0].LogicalDeleteCode == 0)
                    {
                        // 更新
                        ScreenInputPermissionControl(1);
                    }
                    else
                    {
                        // 削除
                        ScreenInputPermissionControl(2);
                    }
                }
                // 表示更新
                ScreenReconstruction();
            }
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="operation">オペレーション</param>
        /// <param name="erObject">エラーオブジェクト</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch ( status ) {
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "ExclusiveTransaction",				// 処理名称
                        operation,							// オペレーション
                        ERR_800_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        erObject,							// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                    break;
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_DELETE: 
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "ExclusiveTransaction",				// 処理名称
                        operation,							// オペレーション
                        ERR_801_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        erObject,							// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                    break;
            }
        }

        /// <summary>
        /// 更新後処理
        /// </summary>
        private void AfterUpdate()
        {
            // 各項目クリア
            PanelClear(panel_AutoAnswerDiv);
            PanelClear(panel_Priority);
            PanelClear(panel_Grid);

            // 優先順位 は自動回答区分が"する(優先順位)"の時のみ有効
            panel_Priority.Enabled = false;

            // 商品中分類、BLコード、メーカー いずれかが未入力の場合
            if ( tEdit_GoodsMGroup.Text.Equals(string.Empty)
                || tNedit_GoodsMakerCd.GetInt().Equals(0)
                ||(panel_BLCode.Visible && tNedit_BLGoodsCode.GetInt().Equals(0)))
            {
                // 自動回答区分
                SetAutoAnswerDivEnabled(false);
                return;
            }

            // 純正メーカーか否か
            bool isPure = PMKHN09701UA.IsPureMaker(tNedit_GoodsMakerCd.GetInt());

            // 純正の場合
            if (isPure)
            {
                // 自動回答区分
                SetAutoAnswerDivEnabled(true);
                tComboEditor_AutoAnswerDiv.Items.Clear();
                tComboEditor_AutoAnswerDiv.Items.AddRange(PMKHN09701UA.GetAutoAnswerDivValueArray(tNedit_GoodsMakerCd.GetInt()));
                tComboEditor_AutoAnswerDiv.SelectedIndex = 0;
                return;
            }

            // ↓↓↓↓↓　以下、優良の場合

            if (tNedit_BLGoodsCode.GetInt().Equals(0)
                || tEdit_GoodsMGroup.Text.Equals(string.Empty))
            {
                // 中分類、BLコード、どちらかが未入力であれば優良設定マスタを取得できないので、グリッドを使用不可に
                // 自動回答区分
                SetAutoAnswerDivEnabled(true);
                tComboEditor_AutoAnswerDiv.Items.Clear();
                tComboEditor_AutoAnswerDiv.Items.AddRange(PMKHN09701UA.GetAutoAnswerDivValueArray(tNedit_GoodsMakerCd.GetInt()));
                tComboEditor_AutoAnswerDiv.SelectedIndex = 0;
                return;
            }
            else
            {
                // --- UPD 2012/11/22 三戸 2012/12/12配信分 システムテスト障害№77 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //// 中分類、BLコード、両方入力があれば、優良設定マスタをグリッドに設定
                //// 画面起動時に取得してある優良設定マスタを取得
                //DataView dv = PMKHN09701UA.OfferPrimeSettingDataView;
                //// 検索条件を設定
                //string filter = PrimeSettingInfo.COL_PARTSMAKERCD + " = " + tNedit_GoodsMakerCd.GetInt().ToString() + " AND " +
                //                PrimeSettingInfo.COL_TBSPARTSCODE + " = " + tNedit_BLGoodsCode.GetInt().ToString() + " AND " +
                //                PrimeSettingInfo.COL_MIDDLEGENRECODE + " = " + PMKHN09701UA.GetIntNullZero(tEdit_GoodsMGroup.Text).ToString();
                //dv.RowFilter = filter;
                //// 条件にあった件数分の種別を取得
                //List<PMKHN09701UA.CodeAndName> type = new List<PMKHN09701UA.CodeAndName>();
                //foreach (DataRowView drv in dv)
                //{
                //    if (drv[PrimeSettingInfo.COL_PRIMEKINDCODE] != null &&
                //        (int)drv[PrimeSettingInfo.COL_PRIMEKINDCODE] >= 0)
                //    {
                //        type.Add(new PMKHN09701UA.CodeAndName(
                //            (Int32)drv[PrimeSettingInfo.COL_PRIMEKINDCODE], drv[PrimeSettingInfo.COL_PRIMEKINDNAME].ToString()));
                //    }
                //}

                //// 種別件数が0件であれば、自動回答区分、優先順位を使用
                //// 種別件数が1件以上であれば、グリッドを使用
                //// --- UPD 2012/11/22 三戸 2012/12/12配信分 システムテスト障害№58 --------->>>>>>>>>>>>>>>>>>>>>>>>
                ////if (type.Count.Equals(0))
                ////１件の場合もグリッドを使用しないように修正
                //if (type.Count < 2)
                //// --- UPD 2012/11/22 三戸 2012/12/12配信分 システムテスト障害№58 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                //{
                //    // 自動回答区分
                //    SetAutoAnswerDivEnabled(true);
                //    tComboEditor_AutoAnswerDiv.Items.Clear();
                //    tComboEditor_AutoAnswerDiv.Items.AddRange(PMKHN09701UA.GetAutoAnswerDivValueArray(tNedit_GoodsMakerCd.GetInt()));
                //    tComboEditor_AutoAnswerDiv.SelectedIndex = 0;
                //}
                //else
                //{
                //    // 自動回答区分
                //    SetAutoAnswerDivEnabled(false);

                //    // 種別をグリッドに設定
                //    GridCreate(type);
                //}
                // 自動回答区分
                SetAutoAnswerDivEnabled(true);
                tComboEditor_AutoAnswerDiv.Items.Clear();
                tComboEditor_AutoAnswerDiv.Items.AddRange(PMKHN09701UA.GetAutoAnswerDivValueArray(tNedit_GoodsMakerCd.GetInt()));
                tComboEditor_AutoAnswerDiv.SelectedIndex = 0;
                // --- UPD 2012/11/22 三戸 2012/12/12配信分 システムテスト障害№77 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            }
        }

        /// <summary>
        /// 自動回答区分コンボの初期化
        /// </summary>
        private void tComboEditor_AutoAnswerDivInitial()
        {
            tComboEditor_AutoAnswerDiv.Items.Clear();
            // 自動回答区分にダミー値を設定
            tComboEditor_AutoAnswerDiv.Items.Add(0, "　");
            tComboEditor_AutoAnswerDiv.SelectedIndex = 0;
        }
        # endregion

        # region Control Events

        /// <summary>
        /// Form.Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : ユーザーがフォームを読み込むときに発生します。</br>
        /// </remarks>
        private void PMKHN09701UB_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            // ガイドボタンのアイコン設定
            this.uButton_Section.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerCode.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMakerCd.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMGroup.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_BLGoodsCode.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // 自動回答区分　初期化
            SetAutoAnswerDivEnabled(false);
            tComboEditor_AutoAnswerDivInitial();

            // 優先順位　初期化
            panel_Priority.Enabled = false;

            // グリッド初期化
            GridNew();

            // 初期フォーカス
            this.tComboEditor_SetKind1.Focus();
        }

        /// <summary>
        /// グリッドの初期化
        /// </summary>
        private void GridNew()
        {
            this._view = new DataView();
            this._view = DataSetColumnConstruction();
            this.uGrid_Details2.DataSource = this._view;

            # region [各列設定]
            ColumnsCollection columns = uGrid_Details2.DisplayLayout.Bands[0].Columns;
            int visiblePosition = 0;

            // 種別コード
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Hidden = true;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Header.Caption = "種別コード";
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Header.Fixed = false;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].CellAppearance.TextHAlign = HAlign.Right;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].CellActivation = Activation.NoEdit;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Width = 80;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2].Header.VisiblePosition = visiblePosition++;

            // 種別名称
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Hidden = false;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Header.Caption = "種別";
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Header.Fixed = false;
            // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].CellAppearance.TextHAlign = HAlign.Right;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].CellAppearance.TextHAlign = HAlign.Left;
            // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].CellActivation = Activation.NoEdit;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Width = 200;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Header.VisiblePosition = visiblePosition++;
            columns[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].SortIndicator = SortIndicator.Disabled;

            // 自動回答区分
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Hidden = false;
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Header.Caption = "自動回答区分";
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Header.Fixed = false;
            // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellAppearance.TextHAlign = HAlign.Right;
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellAppearance.TextHAlign = HAlign.Left;
            // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellActivation = Activation.AllowEdit;
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Width = 200;
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellAppearance.ForeColorDisabled = Color.Black;
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].CellAppearance.BackColorDisabled = Color.LightGray;
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].ValueList = PMKHN09701UA.GetAutoAnswerDivValueList();
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Header.VisiblePosition = visiblePosition++;
            columns[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].SortIndicator = SortIndicator.Disabled;

            uGrid_Details2.CellListSelect += null;
            uGrid_Details2.CellListSelect += new CellEventHandler(this.uGrid_Details2_CellListSelect);

            // 優先順位 
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Hidden = false;
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Header.Caption = "優先順位";
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Header.Fixed = false;
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].CellAppearance.TextHAlign = HAlign.Right;
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].CellActivation = Activation.AllowEdit;
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Width = 50;
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Header.VisiblePosition = visiblePosition++;
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Format = "#";
            columns[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].SortIndicator = SortIndicator.Disabled;

            // セルスタイル
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellAppearance.BackColorDisabled = Color.White;
                columns[index].CellAppearance.BackColorDisabled2 = Color.White;
                columns[index].CellAppearance.BackColor = Color.Lavender;
                columns[index].CellAppearance.BackColor2 = Color.Lavender;
                columns[index].CellAppearance.TextVAlign = VAlign.Top;
            }

            #endregion
        }

        /// <summary>
        /// Control.VisibleChanged イベント(PMKHN09701UB)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
        /// </remarks>
        private void PMKHN09701UB_VisibleChanged(object sender, System.EventArgs e)
        {
            if ( this.Owner != null )
            {
                this.Owner.Activate();
            }

            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if ( this.Visible == false )
            {
                return;
            }

            // 画面クリア処理
            ScreenClear();

            // 画面初期設定処理
            ScreenInitialSetting();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // 登録処理
            SaveProc();
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            bool cloneFlg = true;

            // 削除モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text.Equals(DELETE_MODE))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                // 現在の画面情報を取得
                List<AutoAnsItemSt> autoAnsItemStList = new List<AutoAnsItemSt>();
                foreach (AutoAnsItemSt r in this._recordCloneList)
                {
                    autoAnsItemStList.Add(r.Clone());
                }
                autoAnsItemStList = DispToRecord(autoAnsItemStList);
                // 最初に取得した画面情報と比較
                for (int i = 0; i < this._recordCloneList.Count; i++)
                {
                    cloneFlg = this._recordCloneList[i].Equals(autoAnsItemStList[i]);
                    if (!cloneFlg)
                    {
                        break;
                    }
                }

                if (cloneFlg)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                    DialogResult res = TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        "",									// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.YesNoCancel );		// 表示するボタン

                    switch ( res )
                    {
                        case DialogResult.Yes:
                            if ( SaveProc() )
                            {
                                this.DialogResult = DialogResult.OK;
                                break;
                            }
                            else
                            {
                                return;
                            }
                        case DialogResult.No:
                            this.DialogResult = DialogResult.Cancel;
                            break;
                        default:
                            this.Cancel_Button.Focus();
                            return;
                    }
                }
            }
        }

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);		// 表示するボタン

            if ( result == DialogResult.Yes ) 
            {
                // 物理削除
                PhysicalDeleteRecord();
                this._isSave = true;
            }
        }

        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            DialogResult result =
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                "データを復活します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.YesNo);			// 表示するボタン

            if ( result == DialogResult.Yes )
            {
                // 復旧
                ReviveRecord();
            }
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 指定された間隔の時間が経過したときに発生します。
        ///					 この処理は、システムが提供するスレッド プール
        ///					 スレッドで実行されます。</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// </remarks>
        private void SectionGuide_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSet secInfoSet = new SecInfoSet();

                status = _guideControl.SecInfoSetAcs.ExecuteGuid( this._enterpriseCode, true, out secInfoSet );
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionGuideNm.DataText = secInfoSet.SectionGuideNm.Trim();
                    _prevSectionCode = secInfoSet.SectionCode.Trim();

                    // 次フォーカス
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// tArrowKeyControlChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // 設定種別２
                case "tComboEditor_SetKind2":
                    {
                        if (!e.ShiftKey)
                        {
                            if ( e.Key == Keys.Down )
                            {
                                e.NextCtrl = GetNextEdit( e.PrevCtrl );
                            }
                        }
                    }
                    break;
                // 拠点
                case "tEdit_SectionCodeAllowZero":
                    {
                        MasterRead(ref tEdit_SectionCodeAllowZero, ref tEdit_SectionGuideNm, ref _prevSectionCode, ReadSection, ref e, "拠点" );
                    }
                    break;
                // 得意先
                case "tNedit_CustomerCode":
                    {
                        // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        // MasterRead(ref tNedit_CustomerCode, ref tEdit_CustomerName, ref _prevCustomerCode, ReadCustomer, ref e, "得意先");
                        bool status = MasterRead(ref tNedit_CustomerCode, ref tEdit_CustomerName, ref _prevCustomerCode, ReadCustomer, ref e, "得意先");
                        // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        if (status)
                        {
                            FocusControler(e);
                        }
                        // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                    break;
                // メーカー
                case "tNedit_GoodsMakerCd":
                    {
                        int cdBackup = _prevGoodsMakerCd;
                        // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        // MasterRead(ref tNedit_GoodsMakerCd, ref tEdit_GoodsMakerName, ref _prevGoodsMakerCd, ReadMaker, ref e, "メーカー");
                        bool status = MasterRead(ref tNedit_GoodsMakerCd, ref tEdit_GoodsMakerName, ref _prevGoodsMakerCd, ReadMaker, ref e, "メーカー");
                        // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // 入力内容に変更があれば、各項目更新
                        if (!cdBackup.Equals(tNedit_GoodsMakerCd.GetInt()))
                        {
                            // 更新後処理
                            AfterUpdate();
                        }
                        // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        if (status)
                        {
                            FocusControler(e);
                        }
                        // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                    break;
                // 商品中分類
                case "tEdit_GoodsMGroup":
                    {
                        int cdBackup = _prevGoodsMGroup;
                        MasterReadForGoodsMGroup(ref tEdit_GoodsMGroup, ref tEdit_GoodsMGroupName, ref _prevGoodsMGroup, ReadGoodsMGroup, ref e, "商品中分類");
                        // 入力内容に変更があれば、各項目更新
                        if (!cdBackup.Equals(_prevGoodsMGroup)) // この時点で、tEdit_GoodsMGroupと_prevGoodsMGroupは同じ値
                        {
                            // 更新後処理
                            AfterUpdate();
                        }
                    }
                    break;
                // ＢＬコード
                case "tNedit_BLGoodsCode":
                    {
                        int cdBackup = _prevBLGoodsCode;
                        MasterReadForBlGoodsCode(ref tNedit_BLGoodsCode, ref tEdit_BLCodeName, ref _prevBLGoodsCode, ReadBLCode, ref e, "ＢＬコード");
                        // 入力内容に変更があれば、各項目更新
                        if (!cdBackup.Equals(tNedit_BLGoodsCode.GetInt()))
                        {
                            // 更新後処理
                            AfterUpdate();
                        }
                    }
                    break;
                // 自動回答区分
                case "tComboEditor_AutoAnswerDiv":
                // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                case "tNedit_PriorityOrder":
                case "Renewal_Button":
                case "Ok_Button":
                case "Cancel_Button":
                case "Delete_Button":
                case "uButton_GoodsMakerCd":
                // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    //if (e.ShiftKey)
                    //{
                    //    if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                    //    {
                    //        // 前項目取得
                    //        Control control = GetPrevEdit( e.PrevCtrl );
                    //        if ( control != null )
                    //        {
                    //            e.NextCtrl = control;
                    //        }
                    //    }
                    //}
                    FocusControler(e);
                    // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<
                    break;
                // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№39 --------->>>>>>>>>>>>>>>>>>>>>>>>>>
                case "uGrid_Details2":
                    if (!e.ShiftKey)
                    {
                        // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<
                        // 最下行の処理
                        if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                        {
                            // 優先順位が編集可能の場合
                            if (uGrid_Details2.Rows[uGrid_Details2.Rows.Count - 1].Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Activated)
                            {
                                e.NextCtrl = GetNextEdit(uGrid_Details2);
                                break;
                            }
                            // 優先順位が編集不可の場合
                            else if (!uGrid_Details2.Rows[uGrid_Details2.Rows.Count - 1].Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].CanEnterEditMode
                                    && uGrid_Details2.Rows[uGrid_Details2.Rows.Count - 1].Cells[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV].Activated)
                            {
                                e.NextCtrl = GetNextEdit(uGrid_Details2);
                                break;
                            }
                        }
                        // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>>
                        if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                        {
                            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                            e.NextCtrl = null;
                        }
                    }
                    else
                    {
                        // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<
                        // 最上行の処理
                        if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                        {
                            if (uGrid_Details2.Rows[0].Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Activated)
                            {
                                e.NextCtrl = GetPrevEdit(uGrid_Details2);
                                break;
                            }
                        }
                        // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>>
                        e.NextCtrl = e.PrevCtrl;
                        if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                        {
                            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                            e.NextCtrl = null;
                        }
                    }
                    break;
                // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№39 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                default:
                    break;
            }
        }

        // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// フォーカス制御
        /// </summary>
        /// <param name="e"></param>
        private void FocusControler(ChangeFocusEventArgs e)
        {
            if (e.ShiftKey)
            {
                // シフトキー押下時
                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                {
                    e.NextCtrl = GetPrevEdit(e.PrevCtrl);
                }
            }
            else
            {
                if (e.Key == Keys.Down || e.Key == Keys.Return || e.Key == Keys.Tab)
                {
                    e.NextCtrl = GetNextEdit(e.PrevCtrl);
                }
                else if (e.Key == Keys.Up)
                {
                    e.NextCtrl = GetPrevEdit(e.PrevCtrl);
                }
            }

            // フォーカス遷移先がグリッドの場合、最上行に遷移するか、最下行に遷移するか
            if (e.NextCtrl.Equals(uGrid_Details2))
            {
                if (e.PrevCtrl.Equals(Renewal_Button)
                    || e.PrevCtrl.Equals(Ok_Button)
                    || e.PrevCtrl.Equals(Cancel_Button)
                    || e.PrevCtrl.Equals(Delete_Button))
                {
                    this._GridEnterUP = false;
                }
                else
                {
                    this._GridEnterUP = true;
                }

            }

        }
        // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 各種マスタ読み込み共通処理（数値コード用）
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="tEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //private void MasterRead(ref TNedit codeEdit, ref TEdit nameEdit, ref int prevCode, MasterReadForNumber proc, ref ChangeFocusEventArgs e, string masterName)
        private bool MasterRead(ref TNedit codeEdit, ref TEdit nameEdit, ref int prevCode, MasterReadForNumber proc, ref ChangeFocusEventArgs e, string masterName)
        // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            int code = codeEdit.GetInt();
            // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            bool checkOK = false;
            // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            if ( code != 0 )
            {
                // DEL 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // bool checkOK = false;
                // DEL 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                if ( code != prevCode )
                {
                    string name;
                    bool status = proc( ref code, out name );

                    if ( status )
                    {
                        checkOK = true;
                    }
                    else
                    {
                        // エラーメッセージ
                        TMsgDisp.Show( this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          masterName + "が存在しません。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK );				// 表示するボタン

                        e.NextCtrl = e.PrevCtrl;
                    }
                    codeEdit.SetInt( code );
                    nameEdit.Text = name;
                    prevCode = code;
                }
                else
                {
                    checkOK = true;
                }

                // DEL 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // 入力ＯＫならば次入力項目へ
                //if ( checkOK )
                //{
                //    if ( !e.ShiftKey )
                //    {
                //        if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                //        {
                //            // 次項目取得
                //            e.NextCtrl = GetNextEdit( codeEdit );
                //        }
                //    }
                //}
                // DEL 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            else
            {
                // クリア
                codeEdit.SetInt( 0 );
                nameEdit.Text = string.Empty;
                prevCode = 0;
                // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                checkOK = true;
                // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }

            // DEL 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //if (e.ShiftKey)
            //{
            //    if ( e.Key == Keys.Return || e.Key == Keys.Tab )
            //    {
            //        // 前項目取得
            //        Control control = GetPrevEdit( e.PrevCtrl );
            //        if ( control != null )
            //        {
            //            e.NextCtrl = control;
            //        }
            //    }
            //}
            // DEL 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            return checkOK;
            // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }
        /// <summary>
        /// 各種マスタ読み込み共通処理（文字列コード用）
        /// </summary>
        /// <param name="codeEdit"></param>
        /// <param name="nameEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        private void MasterRead(ref TEdit codeEdit, ref TEdit nameEdit, ref string prevCode, MasterReadForText proc, ref ChangeFocusEventArgs e, string masterName )
        {
            string code = codeEdit.Text.Trim();

            if ( code != string.Empty )
            {
                bool checkOK = false;

                if ( code != prevCode )
                {
                    string name;
                    bool status = proc( ref code, out name );

                    if ( status )
                    {
                        checkOK = true;
                    }
                    else
                    {
                        // エラーメッセージ
                        TMsgDisp.Show( this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          masterName + "が存在しません。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK );				// 表示するボタン

                        e.NextCtrl = e.PrevCtrl;
                    }
                    codeEdit.Text = code;
                    nameEdit.Text = name;
                    prevCode = code;
                }
                else
                {
                    checkOK = true;
                }

                // 入力ＯＫならば次入力項目へ
                if ( checkOK )
                {
                    if ( !e.ShiftKey )
                    {
                        if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                        {
                            // 次項目取得
                            e.NextCtrl = GetNextEdit( codeEdit );
                        }
                    }
                }
            }
            else
            {
                // クリア
                codeEdit.Text = string.Empty;
                nameEdit.Text = string.Empty;
                prevCode = string.Empty;
            }

            if ( e.ShiftKey )
            {
                if ( e.Key == Keys.Return || e.Key == Keys.Tab )
                {
                    // 前項目取得
                    Control control = GetPrevEdit( e.PrevCtrl );
                    if ( control != null )
                    {
                        e.NextCtrl = control;
                    }
                }
            }
        }


        /// <summary>
        /// 各種マスタ読み込み共通処理（商品中分類用）
        /// </summary>
        /// <param name="codeEdit"></param>
        /// <param name="nameEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        private void MasterReadForGoodsMGroup(ref TEdit codeEdit, ref TEdit nameEdit, ref int prevCode, MasterReadForNumber proc, ref ChangeFocusEventArgs e, string masterName)
        {
            int code = PMKHN09701UA.GetIntNullZero(codeEdit.Text);

            bool checkOK = false;

            if (code != prevCode)
            {
                string name;
                bool status = proc(ref code, out name);

                if (status)
                {
                    checkOK = true;
                }
                else
                {
                    // エラーメッセージ
                    TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                      emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                      ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                      masterName + "が存在しません。", 			// 表示するメッセージ
                      0, 									// ステータス値
                      MessageBoxButtons.OK);				// 表示するボタン

                    e.NextCtrl = e.PrevCtrl;
                }
                nameEdit.Text = name;
                prevCode = code;
            }
            else
            {
                checkOK = true;
            }

            codeEdit.Text = code.ToString("0000");

            // 入力ＯＫならば次入力項目へ
            if (checkOK)
            {
                if (!e.ShiftKey)
                {
                    if (e.Key == Keys.Return || e.Key == Keys.Tab)
                    {
                        // 次項目取得
                        e.NextCtrl = GetNextEdit(codeEdit);
                    }
                }
            }

            if (e.ShiftKey)
            {
                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                {
                    // 前項目取得
                    Control control = GetPrevEdit(e.PrevCtrl);
                    if (control != null)
                    {
                        e.NextCtrl = control;
                    }
                }
            }
        }

        /// <summary>
        /// 各種マスタ読み込み共通処理（数値コード用）
        /// BLコード用
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="tEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        private void MasterReadForBlGoodsCode(ref TNedit codeEdit, ref TEdit nameEdit, ref int prevCode, MasterReadForBlCode proc, ref ChangeFocusEventArgs e, string masterName)
        {
            int code = codeEdit.GetInt();

            if (code != 0)
            {
                bool checkOK = false;

                if (code != prevCode)
                {
                    string name;
                    int goodsMGroup;
                    bool status = proc(ref code, out name, out goodsMGroup);

                    if (status)
                    {
                        checkOK = true;
                    }
                    else
                    {
                        // エラーメッセージ
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          masterName + "が存在しません。", 		// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン

                        e.NextCtrl = e.PrevCtrl;
                    }
                    codeEdit.SetInt(code);
                    nameEdit.Text = name;
                    prevCode = code;

                    // 商品中分類
                    tEdit_GoodsMGroup.Text = goodsMGroup.ToString();
                    MasterReadForGoodsMGroup(ref tEdit_GoodsMGroup, ref tEdit_GoodsMGroupName, ref _prevGoodsMGroup, ReadGoodsMGroup, ref e, "商品中分類");
                }
                else
                {
                    checkOK = true;
                }

                // 入力ＯＫならば次入力項目へ
                if (checkOK)
                {
                    if (!e.ShiftKey)
                    {
                        if (e.Key == Keys.Return || e.Key == Keys.Tab)
                        {
                            // 次項目取得
                            e.NextCtrl = GetNextEdit(codeEdit);
                        }
                    }
                }
            }
            else
            {
                // クリア
                codeEdit.SetInt(0);
                nameEdit.Text = string.Empty;
                prevCode = 0;
            }

            if (e.ShiftKey)
            {
                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                {
                    // 前項目取得
                    Control control = GetPrevEdit(e.PrevCtrl);
                    if (control != null)
                    {
                        e.NextCtrl = control;
                    }
                }
            }
        }

        /// <summary>
        /// 各種マスタ読み込み共通処理（数値コード用）取得のみ
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="tEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        private void MasterRead( ref TNedit codeEdit, ref TEdit nameEdit, ref int prevCode, MasterReadForNumber proc )
        {
            int code = codeEdit.GetInt();

            if ( code != 0 )
            {
                string name;
                bool status = proc( ref code, out name );

                codeEdit.SetInt( code );
                nameEdit.Text = name;
                prevCode = code;
            }
            else
            {
                // クリア
                codeEdit.SetInt( 0 );
                nameEdit.Text = string.Empty;
                prevCode = 0;
            }
        }

        /// <summary>
        /// 各種マスタ読み込み共通処理（文字列コード用）取得のみ
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="tEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        private void MasterRead(ref TEdit codeEdit, ref TEdit nameEdit, ref string prevCode, MasterReadForText proc)
        {
            string code = codeEdit.Text.Trim();

            if (code != string.Empty)
            {
                string name;
                bool status = proc(ref code, out name);

                codeEdit.Text = code;
                nameEdit.Text = name;
                prevCode = code;
            }
            else
            {
                // クリア
                codeEdit.Text = string.Empty;
                nameEdit.Text = string.Empty;
                prevCode = string.Empty;
            }
        }

        /// <summary>
        /// 各種マスタ読み込み共通処理（商品中分類用）
        /// </summary>
        /// <param name="TEdit"></param>
        /// <param name="tEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        private void MasterReadForGoodsMGroup(ref TEdit codeEdit, ref TEdit nameEdit, ref int prevCode, MasterReadForNumber proc)
        {
            int code = PMKHN09701UA.GetIntNullZero(codeEdit.Text);

            string name;
            bool status = proc(ref code, out name);

            // ゼロは表示表示無し扱い
            // NullValueに"0000"を設定している
            codeEdit.Text = code.ToString("0000");
            nameEdit.Text = name;
            prevCode = code;
        }

        /// <summary>
        /// 各種マスタ読み込み共通処理（BLコード用）
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="tEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        private void MasterReadForBlGoodsCode(ref TNedit codeEdit, ref TEdit nameEdit, ref int prevCode, MasterReadForBlCode proc)
        {
            int code = codeEdit.GetInt();

            if (code != 0)
            {
                string name;
                int goodsMGroup;
                bool status = proc(ref code, out name, out goodsMGroup);

                codeEdit.SetInt(code);
                nameEdit.Text = name;
                prevCode = code;
            }
            else
            {
                // クリア
                codeEdit.SetInt(0);
                nameEdit.Text = string.Empty;
                prevCode = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            // 最新情報
            _guideControl.Renewal();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }

        /// <summary>
        /// 設定種別１　変更時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SetKind1_ValueChanged( object sender, EventArgs e )
        {
            DrawPanelsBySetKind1();
        }

        /// <summary>
        /// 設定種別２　変更時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SetKind2_ValueChanged(object sender, EventArgs e)
        {
            DrawPanelsBySetKind2();
        }

        /// <summary>
        /// メーカーガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMakerCd_Click( object sender, EventArgs e )
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt makerUMnt;

                int status = this._guideControl.MakerAcs.ExecuteGuid( this._enterpriseCode, out makerUMnt );
                if ( status == 0 )
                {
                    // 結果セット
                    this.tNedit_GoodsMakerCd.SetInt( makerUMnt.GoodsMakerCd );
                    this.tEdit_GoodsMakerName.Text = makerUMnt.MakerName;

                    // 入力内容に変更があれば、各項目更新
                    if (!_prevGoodsMakerCd.Equals(tNedit_GoodsMakerCd.GetInt()))
                    {
                        // 更新後処理
                        AfterUpdate();
                    }
                    _prevGoodsMakerCd = makerUMnt.GoodsMakerCd;

                    // 次フォーカス
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 商品中分類ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMGroup_Click( object sender, EventArgs e )
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                GoodsGroupU goodsMGroup;

                // ガイド起動
                int status = this._guideControl.GoodsAcs.ExecuteGoodsMGroupGuid( this._enterpriseCode, out goodsMGroup );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // 結果セット
                    this.tEdit_GoodsMGroup.Text = goodsMGroup.GoodsMGroup.ToString("0000");
                    this.tEdit_GoodsMGroupName.Text = goodsMGroup.GoodsMGroupName;

                    // 入力内容に変更があれば、各項目更新
                    if (!_prevGoodsMGroup.Equals(PMKHN09701UA.GetIntNullZero(tEdit_GoodsMGroup.Text)))
                    {
                        // 更新後処理
                        AfterUpdate();
                    }

                    _prevGoodsMGroup = goodsMGroup.GoodsMGroup;

                    // 次フォーカス
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ＢＬコードガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_BLGoodsCode_Click( object sender, EventArgs e )
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                BLGoodsCdUMnt bLGoodsCdUMnt;

                // ガイド起動
                int status = _guideControl.BLGoodsCdAcs.ExecuteGuid( this._enterpriseCode, out bLGoodsCdUMnt );
                if ( status == 0 )
                {
                    // 結果セット
                    this.tNedit_BLGoodsCode.SetInt( bLGoodsCdUMnt.BLGoodsCode );
                    this.tEdit_BLCodeName.Text = bLGoodsCdUMnt.BLGoodsFullName;
                    // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№32 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // 商品中分類を取得するため、再度検索
                    _guideControl.BLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, bLGoodsCdUMnt.BLGoodsCode);
                    // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№32 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    this.tEdit_GoodsMGroup.Text = bLGoodsCdUMnt.GoodsRateGrpCode.ToString(); // 商品中分類
                    MasterReadForGoodsMGroup(ref tEdit_GoodsMGroup, ref tEdit_GoodsMGroupName, ref _prevGoodsMGroup, ReadGoodsMGroup);

                    // 入力内容に変更があれば、各項目更新
                    if (!_prevBLGoodsCode.Equals(tNedit_BLGoodsCode.GetInt()))
                    {
                        // 更新後処理
                        AfterUpdate();
                    }

                    _prevBLGoodsCode = bLGoodsCdUMnt.BLGoodsCode;

                    // 次フォーカス
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 得意先ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerCode_Click( object sender, EventArgs e )
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ガイド表示
                DialogResult result = _guideControl.CustomerSearchForm.ShowDialog();
                if ( result == DialogResult.OK && _guideControl.CustomerGuideRet != null )
                {
                    // 結果セット
                    this.tNedit_CustomerCode.SetInt( _guideControl.CustomerGuideRet.CustomerCode );
                    this.tEdit_CustomerName.Text = _guideControl.CustomerGuideRet.Name;
                    _prevCustomerCode = _guideControl.CustomerGuideRet.CustomerCode;

                    // 次フォーカス
                    this.SelectNextControl( (Control)sender, true, true, true, true );
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        /// <summary>
        /// 拠点名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadSection( ref string code, out string name )
        {
            if ( code == "00" )
            {
                name = "全社";
                return true;
            }

            if ( _guideControl.SecInfoSetDic.ContainsKey( code ) )
            {
                name = _guideControl.SecInfoSetDic[code].SectionGuideNm;
                return true;
            }
            else
            {
                code = string.Empty;
                name = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// 得意先名取得
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadCustomer( ref int code, out string name )
        {
            // 検索条件セット
            CustomerSearchPara para = new CustomerSearchPara();
            para.EnterpriseCode = _enterpriseCode;
            para.CustomerCode = code;

            // 検索実行
            CustomerSearchRet[] retList;
            int status = _guideControl.CustomerSearchAcs.Serch( out retList, para );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null && retList.Length > 0)
            {
                name = retList[0].Name;
                return true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// メーカー名取得
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadMaker( ref int code, out string name )
        {
            bool rtn = false;
            MakerUMnt maker;
            int status = _guideControl.MakerAcs.Read( out maker, this._enterpriseCode, code );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && maker != null )
            {
                name = maker.MakerName;
                rtn = true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                rtn = false;
            }

            return rtn;
        }

        /// <summary>
        /// 商品中分類名取得
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadGoodsMGroup( ref int code, out string name )
        {
            if (code == 0)
            {
                name = "共通";
                return true;
            }

            GoodsGroupU goodsGroupU;
            int status = _guideControl.GoodsAcs.GetGoodsMGroup( _enterpriseCode, code, out goodsGroupU );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsGroupU != null )
            {
                name = goodsGroupU.GoodsMGroupName;
                return true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                return false;
            }
        }
        
        /// <summary>
        /// ＢＬコード名取得
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadBLCode( ref int code, out string name ,out int goodsMGroup)
        {
            BLGoodsCdUMnt blGoodsCdUMnt;

            if (code.Equals(0))
            {
                name = "共通";
                goodsMGroup = 0;
                return　true;
            }

            int status = _guideControl.BLGoodsCdAcs.Read( out blGoodsCdUMnt, _enterpriseCode, code );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && blGoodsCdUMnt != null )
            {
                name = blGoodsCdUMnt.BLGoodsFullName;
                goodsMGroup = blGoodsCdUMnt.GoodsRateGrpCode;    // 商品中分類
                return true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                goodsMGroup = 0;
                return false;
            }
        }

        /// <summary>
        /// 次の"入力項目"を取得(ガイドボタン除く)
        /// </summary>
        /// <param name="currControl"></param>
        /// <returns></returns>
        private Control GetNextEdit( Control currControl )
        {
            Control nextControl;

            // 次項目取得
            switch ( currControl.Name )
            {
                case "tComboEditor_SetKind1":
                    nextControl = tComboEditor_SetKind2;
                    break;
                case "tComboEditor_SetKind2":
                    nextControl = tEdit_SectionCodeAllowZero;
                    break;
                case "tEdit_SectionCodeAllowZero":
                    nextControl = tNedit_CustomerCode;
                    break;
                case "tNedit_CustomerCode":
                    nextControl = tEdit_GoodsMGroup;
                    break;
                case "tEdit_GoodsMGroup":
                    nextControl = tNedit_BLGoodsCode;
                    break;
                case "tNedit_BLGoodsCode":
                    nextControl = tNedit_GoodsMakerCd;
                    break;
                case "tNedit_GoodsMakerCd":
                    nextControl = tComboEditor_AutoAnswerDiv;
                    break;
                case "tComboEditor_AutoAnswerDiv":
                    nextControl = tNedit_PriorityOrder;
                    break;
                case "tNedit_PriorityOrder":
                    nextControl = uGrid_Details2;
                    break;
                default:
                    // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // nextControl = Cancel_Button;
                    nextControl = Renewal_Button;
                    // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    break;
            }

            // 入力不可なら再帰的に取得
            // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //if (!nextControl.Enabled || !nextControl.Visible)
            if (!nextControl.Enabled || !nextControl.Visible
                || (nextControl.Equals(uGrid_Details2) && uGrid_Details2.Rows.Count <= 0))
            // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                nextControl = GetNextEdit( nextControl );
            }

            // 返却
            return nextControl;
        }

        /// <summary>
        /// 前の"入力項目"を取得(ガイドボタン除く)
        /// </summary>
        /// <param name="currControl"></param>
        /// <returns></returns>
        private Control GetPrevEdit( Control currControl )
        {
            Control prevControl;

            // 前項目取得
            switch ( currControl.Name )
            {
                case "tComboEditor_SetKind2":
                    prevControl = tComboEditor_SetKind1;
                    break;
                case "tEdit_SectionCodeAllowZero":
                    prevControl = tComboEditor_SetKind2;
                    break;
                case "tNedit_CustomerCode":
                    prevControl = tEdit_SectionCodeAllowZero;
                    break;
                case "tEdit_GoodsMGroup":
                    prevControl = tNedit_CustomerCode;
                    break;
                case "tNedit_BLGoodsCode":
                    prevControl = tEdit_GoodsMGroup;
                    break;
                case "tNedit_GoodsMakerCd":
                    prevControl = tNedit_BLGoodsCode;
                    break;
                case "tComboEditor_AutoAnswerDiv":
                    prevControl = tNedit_GoodsMakerCd;
                    break;
                case "tNedit_PriorityOrder":
                    prevControl = tComboEditor_AutoAnswerDiv;
                    break;
                case "uGrid_Details2":
                    prevControl = tNedit_PriorityOrder;
                    break;
                // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // メーカーのガイドボタンは、グリッドへのフォーカス移動が影響するため、制御する。
                // 他のガイドボタンは制御しない
                case "uButton_GoodsMakerCd":
                    if (uButton_BLGoodsCode.Visible)
                    {
                        prevControl = uButton_BLGoodsCode;
                    }
                    else
                    {
                        prevControl = uButton_GoodsMGroup;
                    }
                    break;
                case "Renewal_Button":
                case "Ok_Button":
                case "Cancel_Button":
                case "Delete_Button":
                    prevControl = uGrid_Details2;
                    break;
                // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                default:
                    prevControl = Cancel_Button;
                    break;
            }

            // 入力不可なら再帰的に取得
            // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // if ( !prevControl.Enabled || !prevControl.Visible )
            if (!prevControl.Enabled || !prevControl.Visible
                || (prevControl.Equals(uGrid_Details2) && uGrid_Details2.Rows.Count <= 0))
            // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                prevControl = GetPrevEdit( prevControl );
            }

            // DEL 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 前項目の入力チェック
            //if ( prevControl != null )
            //{
            //    if ( prevControl is TNedit )
            //    {
            //        if ( (prevControl as TNedit).GetInt() == 0 )
            //        {
            //            prevControl = null;
            //        }
            //    }
            //    else if ( prevControl is TEdit )
            //    {
            //        if ( (prevControl as TEdit).Text.Trim() == string.Empty )
            //        {
            //            prevControl = null;
            //        }
            //    }
            //}
            // DEL 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // 返却
            return prevControl;
        }

        /// <summary>
        /// 設定種別１・２取得処理
        /// </summary>
        /// <param name="scmPrtSetting"></param>
        /// <param name="setKind1"></param>
        /// <param name="setKind2"></param>
        private void GetSetKind(AutoAnsItemSt autoAnsItemSt, out int setKind1, out int setKind2)
        {
            # region [設定種別１]
            if (autoAnsItemSt.SectionCode == null || autoAnsItemSt.SectionCode.Trim() != string.Empty)
            {
                // 1:拠点
                setKind1 = 1;
            }
            else if (autoAnsItemSt.CustomerCode != 0)
            {
                // 2:得意先
                setKind1 = 2;
            }
            else
            {
                // 0:全て
                setKind1 = 0;
            }
            # endregion

            # region [設定種別２]
            if (autoAnsItemSt.BLGoodsCode != 0)
            {
                // 2:中分類＋BLコード
                setKind2 = 2;
            }
            else 
            {
                // 1:中分類
                setKind2 = 1;
            }

            # endregion
        }

        # endregion

        #region グリッド設定
        /// <summary>
        /// グリッド作成処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <param name="displayList">表示データリスト</param>
        /// <remarks>
        /// <br>Note        : グリッドの列を作成します。</br>
        /// </remarks>
        private void GridCreate(List<PMKHN09701UA.CodeAndName> typeList)
        {
            this.uGrid_Details2.DataSource = null;

            GridNew();
            this.uGrid_Details2.Enabled = true;

            DataTable tbl = this._view.Table;
            tbl.Clear();
            foreach(PMKHN09701UA.CodeAndName type in typeList)
            {
                DataRow nr = tbl.NewRow();
                nr[AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2] = type.Code;
                nr[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2] = type.Name;
                // 自動回答区分 初期値は０（しない）
                nr[AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV] = 0;
                tbl.Rows.Add(nr);
            }

            this.uGrid_Details2.DataSource = this._view;
            
            // 優先順位列のセル設定
            foreach (UltraGridRow row in this.uGrid_Details2.Rows)
            {
                row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Activation = Activation.Disabled;
            }
        }
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <param name="ds">データセット</param>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。</br>
        /// </remarks>
        private DataView DataSetColumnConstruction()
        {
            //----------------------------------------------------------------
            // グリッド用テーブル列定義
            //----------------------------------------------------------------
            DataTable ForGrid = new DataTable(ct_TABLE_FORGRID);

            // 種別
            ForGrid.Columns.Add(AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2, typeof(Int32));
            ForGrid.Columns.Add(AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2, typeof(string));
            // 自動回答区分
            ForGrid.Columns.Add(AutoAnsItemStAcs.ct_COL_AUTOANSWERDIV, typeof(string));
            // 優先順位
            ForGrid.Columns.Add(AutoAnsItemStAcs.ct_COL_PRIORITYORDER, typeof(Int32));

            //----------------------------------------------------------------
            // データビュー生成
            //----------------------------------------------------------------
            DataView dataView = new DataView(ForGrid);
            dataView.Sort = string.Format("{0}",AutoAnsItemStAcs.ct_COL_PRMSETDTLNO2);

            return dataView;
        }

        #endregion

        /// <summary>
        /// 自動回答区分　使用可否設定
        /// </summary>
        /// <param name="enabled">true:使用可　false:使用不可</param>
        private void SetAutoAnswerDivEnabled(bool enabled)
        {
            panel_AutoAnswerDiv.Enabled = enabled;
            tComboEditor_AutoAnswerDiv.Enabled = enabled;
        }

        /// <summary>
        /// 自動回答区分　変更時
        /// 優先順位の使用可否を設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_AutoAnswerDiv_ValueChanged(object sender, EventArgs e)
        {
            // 削除モードの場合は制御しない
            if (this.Mode_Label.Text.Equals(DELETE_MODE))
            {
                return;
            }
            panel_Priority.Enabled = PMKHN09701UA.IsPriority(tComboEditor_AutoAnswerDiv.Text);
            if (!panel_Priority.Enabled)
            {
                tNedit_PriorityOrder.SetInt(0);
            }
        }


        /// <summary>
        /// グリッド　ドロップダウンリスト変更時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details2_CellListSelect(object sender, CellEventArgs e)
        {
            if (PMKHN09701UA.IsPriority(e.Cell.Text))
            {
                // 使用可に
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value = DBNull.Value;
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Activation = Activation.AllowEdit;
            }
            else
            {
                // 使用不可に
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Value = DBNull.Value;
                e.Cell.Row.Cells[AutoAnsItemStAcs.ct_COL_PRIORITYORDER].Activation = Activation.Disabled;
            }

        }

        /// <summary>
        /// キー押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details2_KeyDown(object sender, KeyEventArgs e)
        {
            #region ■セルが選択されている場合
            if (this.uGrid_Details2.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details2.ActiveCell;

                #region ●Escapeキー
                if (e.KeyCode == Keys.Escape)
                {
                    // なにもしない
                }
                #endregion
                // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<
                switch (e.KeyData)
                {
                    case Keys.Down:
                        // 最下行の処理
                        // 優先順位が編集可能の場合
                        if (uGrid_Details2.Rows[uGrid_Details2.Rows.Count - 1].Activated)
                        {
                            GetNextEdit(uGrid_Details2).Focus();
                            e.Handled = true;
                            return;
                        }
                        break;
                    case Keys.Up:
                        // 最下行の処理
                        // 優先順位が編集可能の場合
                        if (uGrid_Details2.Rows[0].Activated)
                        {
                            GetPrevEdit(uGrid_Details2).Focus();
                            e.Handled = true;
                            return;
                        }
                        break;
                }
                // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>>

                // 編集中であった場合
                if (cell.IsInEditMode)
                {
                    // セルのスタイルにて判定
                    switch (this.uGrid_Details2.ActiveCell.StyleResolved)
                    {
                        #region < テキストボックス・テキストボックス(ボタン付) >
                        case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            {
                                switch (e.KeyData)
                                {
                                    // ←キー
                                    case Keys.Left:
                                        if (this.uGrid_Details2.ActiveCell.SelStart == 0)
                                        {
                                            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                    // →キー
                                    case Keys.Right:
                                        if (this.uGrid_Details2.ActiveCell.SelStart >= this.uGrid_Details2.ActiveCell.Text.Length)
                                        {
                                            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                    case Keys.Down:
                                        this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
                                        e.Handled = true;
                                        break;
                                    case Keys.Up:
                                        this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                                        e.Handled = true;
                                        break;
                                }
                                break;
                            }
                        #endregion

                        #region < 上記以外のスタイル >
                        default:
                            {
                                switch (e.KeyData)
                                {
                                    // ←キー
                                    case Keys.Left:
                                        {
                                            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                    // →キー
                                    case Keys.Right:
                                        {
                                            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                    // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№39 --------->>>>>>>>>>>>>>>>>>>>>>>>>>
                                    case Keys.Up:
                                        {
                                            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                                            e.Handled = true;
                                        }
                                        break;
                                    case Keys.Down:
                                        {
                                            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
                                            e.Handled = true;
                                        }
                                        break;
                                    // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№39 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<
                                }
                                break;
                            }
                        #endregion
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// キーを押下して離した後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details2.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details2.ActiveCell;

            #region ●ActiveCellが優先順位の場合
            if (cell.Column.Key == AutoAnsItemStAcs.ct_COL_PRIORITYORDER)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№14 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    //if (!PMKHN09701UA.KeyPressNumCheck(int.MaxValue.ToString().Length, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    if (!PMKHN09701UA.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№14 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// キーアクションが発生した後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details2_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:

                    // アクティブなセルがあるか？または編集可能セルか？
                    if ((this.uGrid_Details2.ActiveCell != null) &&
                        (this.uGrid_Details2.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details2.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        // アクティブセルのスタイルを取得
                        switch (this.uGrid_Details2.ActiveCell.StyleResolved)
                        {
                            // エディット系スタイル
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // 編集モードにある？
                                    if (this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                                    {
                                        if (!(this.uGrid_Details2.ActiveCell.Value is System.DBNull))
                                        {
                                            // 全選択状態にする。
                                            this.uGrid_Details2.ActiveCell.SelStart = 0;
                                            this.uGrid_Details2.ActiveCell.SelLength = this.uGrid_Details2.ActiveCell.Text.Length;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // エディット系以外のスタイルであれば、編集状態にする。
                                    this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// セルがアクティブになった後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details2_AfterCellActivate(object sender, EventArgs e)
        {
            this.uGrid_Details2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        }

        /// <summary>
        /// グリッド　フォーカスアウト
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details2_Leave(object sender, EventArgs e)
        {
            // ActiveCell解除
            if (uGrid_Details2.ActiveCell != null)
            {
                uGrid_Details2.ActiveCell.Selected = false;
                uGrid_Details2.ActiveCell = null;
            }

            // ActiveRow解除
            if (uGrid_Details2.ActiveRow != null)
            {
                uGrid_Details2.ActiveRow.Selected = false;
                uGrid_Details2.ActiveRow = null;
            }
        }
        // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№39 --------->>>>>>>>>>>>>>>>>>>>>>>>>>
        private void uGrid_Details2_Enter(object sender, EventArgs e)
        {
            if (uGrid_Details2.Rows.Count <= 0)
            {
                return;
            }

            if (this._GridEnterUP)
            {
                uGrid_Details2.Rows[0].Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Activate();
            }
            else
            {
                uGrid_Details2.Rows[uGrid_Details2.Rows.Count - 1].Cells[AutoAnsItemStAcs.ct_COL_PRMSETDTLNAME2].Activate();
            }
        }
        // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№39 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<
    }

}
