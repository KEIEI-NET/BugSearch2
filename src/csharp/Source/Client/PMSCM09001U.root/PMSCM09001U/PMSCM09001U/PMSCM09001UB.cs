//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : SCM品目設定マスタメンテナンス
// プログラム概要   : SCM品目設定マスタの操作を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 作 成 日  2009/05/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ＳＣＭ品目設定マスタメンテナンス編集フォーム
    /// </summary>
    /// <remarks>
    /// <br>Note       : ＳＣＭ品目設定マスタの入力を行います。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2009.05.18</br>
    /// <br>Update Note: </br>
    /// <br></br>
    /// </remarks>
    public partial class PMSCM09001UB : System.Windows.Forms.Form
    {
        #region Private Menbers

        private string _enterpriseCode;         // 企業コード

        // ＵＩ配置用（開始位置）
        private const int ct_PositionStart = 105;
        // ＵＩ配置用（間隔）
        private const int ct_Interval = 4;


        // SCM品目設定アクセスクラス
        private SCMPrtSettingAcs _scmPrtSettingAcs;
        // SCM品目設定マスメン用ガイド制御クラス
        private SCMPrtSettingGuideControl _guideControl;

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
        // 商品番号（前回値）
        private string _prevGoodsNo;
        
        // グループコード（退避用）
        private int _blGroupCode;


        // 編集中レコードGUID
        private Guid _recordGuid;
        // 編集中レコード
        private SCMPrtSetting _scmPrtSetting;

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // 終了時の編集チェック用
        private SCMPrtSetting _recordClone;


        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string DELETE_DATE_TITLE = "削除日";
        private const string SECTIONCODE_TITLE = "拠点コード";
        private const string SECTIONGUIDENM_TITLE = "拠点名";
        private const string SUBSECTIONCODE_TITLE = "SCM品目設定コード";
        private const string SUBSECTIONNAME_TITLE = "SCM品目設定名";

        // 画面レイアウト用定数
        private const int BUTTON_LOCATION1_X = 196;     // 完全削除ボタン位置X
        private const int BUTTON_LOCATION2_X = 323;     // 復活ボタン位置X
        private const int BUTTON_LOCATION3_X = 450;     // 保存ボタン位置X
        private const int BUTTON_LOCATION4_X = 577;     // 閉じるボタン位置X
        private const int BUTTON_LOCATION_Y = 8;        // ボタン位置Y(共通)

        // Message関連定義
        private const string ASSEMBLY_ID = "DCKHN09010U";
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "入力された品目設定は既に登録されています。編集を行いますか？";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";

        #endregion


        # region Constructor

        /// <summary>
        /// ＳＣＭ品目設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        public PMSCM09001UB( SCMPrtSettingAcs scmPrtSettingAcs, SCMPrtSettingGuideControl scmPrtSettingGuideControl )
        {
            InitializeComponent();

            // 各種インスタンスを受け取る
            _scmPrtSettingAcs = scmPrtSettingAcs;
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
            _blGroupCode = 0;
            // 商品番号（前回値）
            _prevGoodsNo = string.Empty;

            // 編集中レコードのGUIDとレコード
            _recordGuid = Guid.Empty;
            _scmPrtSetting = null;
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
            _prevGoodsMakerCd = 0;
            _prevGoodsMGroup = 0;
            _prevBLGoodsCode = 0;
            _prevGoodsNo = string.Empty;

            _blGroupCode = 0;

            // 名称再取得
            // 拠点
            MasterRead( ref tEdit_SectionCodeAllowZero, ref tEdit_SectionGuideNm, ref _prevSectionCode, ReadSection );
            // 得意先
            MasterRead( ref tNedit_CustomerCode, ref tEdit_CustomerName, ref _prevCustomerCode, ReadCustomer );
            // メーカー
            MasterRead( ref tNedit_GoodsMakerCd, ref tEdit_GoodsMakerName, ref _prevGoodsMakerCd, ReadMaker );
            // 商品中分類
            MasterRead( ref tNedit_GoodsMGroup, ref tEdit_GoodsMGroupName, ref _prevGoodsMGroup, ReadGoodsMGroup );
            // ＢＬコード
            MasterRead( ref tNedit_BLGoodsCode, ref tEdit_BLCodeName, ref _prevBLGoodsCode, ReadBLCode );
            if ( _prevBLGoodsCode == 0 ) _blGroupCode = 0;
            // 品番→商品
            ReadGoods();
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
                    panel_Customer.Visible = false;
                    panel_Line.Visible = false;
                    break;
                // 1:拠点
                case 1:
                    panel_Section.Visible = true;
                    panel_Customer.Visible = false;
                    panel_Line.Visible = true;

                    panel_Section.Top = currPosition;
                    currPosition += panel_Section.Height + ct_Interval;
                    panel_Line.Top = currPosition;
                    currPosition += panel_Line.Height + ct_Interval;
                    break;
                // 2:得意先
                case 2:
                    panel_Section.Visible = false;
                    panel_Customer.Visible = true;
                    panel_Line.Visible = true;

                    panel_Customer.Top = currPosition;
                    currPosition += panel_Customer.Height + ct_Interval;
                    panel_Line.Top = currPosition;
                    currPosition += panel_Line.Height + ct_Interval;
                    break;
            }


            // クリア
            if ( panel_Section.Visible == false )
            {
                ClearEditOnPanel( panel_Section );
                _prevSectionCode = string.Empty;
            }
            else
            {
                string sectionCode = tEdit_SectionCodeAllowZero.Text.Trim();
                if ( sectionCode == string.Empty || sectionCode == "00" )
                {
                    tEdit_SectionCodeAllowZero.Text = "00";
                    tEdit_SectionGuideNm.Text = "全社";
                }
            }
            if ( panel_Customer.Visible == false)
            { 
                ClearEditOnPanel( panel_Customer );
                _prevCustomerCode = 0;
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
            //if ( panel_Line.Visible )
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
            bool goodsMakerEnabled = false;
            bool goodsMGroupEnabled = false;
            bool goodsNoEnabled = false;

            // メーカー,中分類,ＢＬコード,品番
            switch ( (int)tComboEditor_SetKind2.Value )
            {
                // 0:メーカー
                default:
                case 0:
                    goodsMakerEnabled = true;
                    break;
                // 1:メーカー＋中分類
                case 1:
                    goodsMakerEnabled = true;
                    goodsMGroupEnabled = true;
                    break;
                // 2:メーカー＋ＢＬコード
                case 2:
                    goodsMakerEnabled = true;
                    blCodeEnabled = true;
                    break;
                // 3:メーカー＋品番
                case 3:
                    goodsMakerEnabled = true;
                    goodsNoEnabled = true;
                    break;
            }
            # endregion

            # region [コントロールの配置]
            // メーカー
            if ( goodsMakerEnabled )
            {
                panel_GoodsMaker.Top = currPosition;
                currPosition += panel_GoodsMaker.Height + ct_Interval;
            }
            panel_GoodsMaker.Enabled = goodsMakerEnabled;
            panel_GoodsMaker.Visible = goodsMakerEnabled;

            // ＢＬコード
            if ( blCodeEnabled )
            {
                panel_BLCode.Top = currPosition;
                currPosition += panel_BLCode.Height + ct_Interval;
            }
            panel_BLCode.Enabled = blCodeEnabled;
            panel_BLCode.Visible = blCodeEnabled;
            
            // 商品中分類
            if ( goodsMGroupEnabled )
            {
                panel_GoodsMGroup.Top = currPosition;
                currPosition += panel_GoodsMGroup.Height + ct_Interval;
            }
            panel_GoodsMGroup.Enabled = goodsMGroupEnabled;
            panel_GoodsMGroup.Visible = goodsMGroupEnabled;
            
            // 品番
            if ( goodsNoEnabled )
            {
                panel_GoodsNo.Top = currPosition;
                currPosition += panel_GoodsNo.Height + ct_Interval;
            }
            panel_GoodsNo.Enabled = goodsNoEnabled;
            panel_GoodsNo.Visible = goodsNoEnabled;

            // 自動回答区分
            panel_AutoAnswerDiv.Top = currPosition;
            # endregion

            # region [パネル内のクリア]
            // パネル内クリア
            if ( panel_BLCode.Enabled == false )
            {
                ClearEditOnPanel( panel_BLCode );
                _prevBLGoodsCode = 0;
                _blGroupCode = 0;
            }
            if ( panel_GoodsMaker.Enabled == false )
            {
                ClearEditOnPanel( panel_GoodsMaker );
                _prevGoodsMakerCd = 0;
            }
            if ( panel_GoodsMGroup.Enabled == false )
            {
                ClearEditOnPanel( panel_GoodsMGroup );
                _prevGoodsMGroup = 0;
            }
            if ( panel_GoodsNo.Enabled == false )
            {
                ClearEditOnPanel( panel_GoodsNo );
                _prevGoodsNo = string.Empty;
            }
            # endregion
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
        private delegate bool MasterReadForNumber( ref int code, out string name );
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
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
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            if ( this.RecordGuid == null || this.RecordGuid == Guid.Empty )
            {
                // 新規
                _scmPrtSetting = new SCMPrtSetting();
                ScreenInputPermissionControl( 0 );
            }
            else
            {
                // レコード取得
                _scmPrtSetting = _scmPrtSettingAcs.GetRecordForMaintenance( this.RecordGuid );

                if ( _scmPrtSetting.LogicalDeleteCode == 0 )
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
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="setType">設定タイプ 0:親-新規, 1:親-更新, 2:親-削除, 3:子-新規, 4:子-更新, 5:子-削除</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
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
                    this.panel_GoodsNo.Enabled = true;
                    this.panel_AutoAnswerDiv.Enabled = true;

                    break;
                // 1:更新
                case 1:
                    // 設定種別取得
                    GetSetKind( _scmPrtSetting, out setKind1, out setKind2 );
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
                    this.panel_GoodsNo.Enabled = false;
                    this.panel_AutoAnswerDiv.Enabled = true;

                    break;
                // 2:削除
                case 2:
                    // 設定種別取得
                    GetSetKind( _scmPrtSetting, out setKind1, out setKind2 );
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
                    this.panel_GoodsNo.Enabled = false;
                    this.panel_AutoAnswerDiv.Enabled = false;

                    break;
            }
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if ( _scmPrtSetting == null || _scmPrtSetting.FileHeaderGuid == null || _scmPrtSetting.FileHeaderGuid == Guid.Empty )
            {
                //---------------------------------------------
                // 新規
                //---------------------------------------------
                this.Mode_Label.Text = INSERT_MODE;

                // 画面展開処理
                RecordToScreen( _scmPrtSetting );

                // クローン作成
                this._recordClone = _scmPrtSetting.Clone();
                DispToRecord( ref this._recordClone );
            }
            else if ( _scmPrtSetting.LogicalDeleteCode == 0 )
            {
                //---------------------------------------------
                // 更新
                //---------------------------------------------
                this.Mode_Label.Text = UPDATE_MODE;

                // 画面展開処理
                RecordToScreen( _scmPrtSetting );

                // クローン作成
                this._recordClone = _scmPrtSetting.Clone();
                DispToRecord( ref this._recordClone );
            }
            else
            {
                //---------------------------------------------
                // 削除
                //---------------------------------------------
                this.Mode_Label.Text = DELETE_MODE;

                // 画面展開処理
                RecordToScreen( _scmPrtSetting );
            }
        }

        /// <summary>
        /// 拠点クラス画面展開処理
        /// </summary>
        /// <param name="secInfoSet">拠点オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void SecInfoSetToScreen(SecInfoSet secInfoSet)
        {
            this.tEdit_SectionCodeAllowZero.Text     = secInfoSet.SectionCode;       // 拠点コード
            this.tEdit_SectionGuideNm.Text  = secInfoSet.SectionGuideNm;    // 拠点名称
        }

        /// <summary>
        /// SCM品目設定クラス画面展開処理
        /// </summary>
        /// <param name="Subsection">SCM品目設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void RecordToScreen(SCMPrtSetting scmPrtSetting)
        {
            if ( scmPrtSetting.SectionCode.Trim() == "00" || scmPrtSetting.SectionCode.Trim() == string.Empty )
            {
                // 拠点コード
                this.tEdit_SectionCodeAllowZero.Text = "00";
                // 拠点名
                this.tEdit_SectionGuideNm.Text = "全社";
            }
            else
            {
                // 拠点コード
                this.tEdit_SectionCodeAllowZero.Text = scmPrtSetting.SectionCode.Trim();
                // 拠点名
                this.tEdit_SectionGuideNm.Text = scmPrtSetting.SectionNm.Trim();
            }

            // 得意先コード
            this.tNedit_CustomerCode.SetInt( scmPrtSetting.CustomerCode );

            // 得意先名
            this.tEdit_CustomerName.Text = scmPrtSetting.CustomerName.Trim();

            // メーカーコード
            this.tNedit_GoodsMakerCd.SetInt( scmPrtSetting.GoodsMakerCd );

            // メーカー名
            this.tEdit_GoodsMakerName.Text = scmPrtSetting.MakerName.Trim();

            // 商品中分類コード
            this.tNedit_GoodsMGroup.SetInt( scmPrtSetting.GoodsMGroup );

            // 商品中分類名
            this.tEdit_GoodsMGroupName.Text = scmPrtSetting.GoodsMGroupName.Trim();

            // ＢＬコード
            this.tNedit_BLGoodsCode.SetInt( scmPrtSetting.BLGoodsCode );

            // ＢＬコード名
            this.tEdit_BLCodeName.Text = scmPrtSetting.BLGoodsName.Trim();

            // 品番
            this.tEdit_GoodsNo.Text = scmPrtSetting.GoodsNo.Trim();

            // 品名
            this.tEdit_GoodsName_ReadOnly.Text = scmPrtSetting.GoodsName.Trim();

            // 自動回答区分
            this.tComboEditor_AutoAnswerDiv.Value = scmPrtSetting.AutoAnswerDiv;
        }

        /// <summary>
        /// 画面情報拠点クラス格納処理
        /// </summary>
        /// <param name="secInfoSet">拠点オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からオブジェクトにデータを格納します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void DispToSecInfoSet(ref SecInfoSet secInfoSet)
        {
            secInfoSet.SectionCode      = this.tEdit_SectionCodeAllowZero.Text;      // 拠点コード
            secInfoSet.SectionGuideNm   = this.tEdit_SectionGuideNm.Text;   // 拠点名称
            secInfoSet.EnterpriseCode   = this._enterpriseCode;             // 企業コード
        }

        /// <summary>
        /// 画面情報SCM品目設定クラス格納処理
        /// </summary>
        /// <param name="Subsection">SCM品目設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からSCM品目設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void DispToRecord( ref SCMPrtSetting scmPrtSetting )
        {
            // 企業コード
            scmPrtSetting.EnterpriseCode = this._enterpriseCode;

            // 拠点コード
            scmPrtSetting.SectionCode = this.GetDispValue( this.tEdit_SectionCodeAllowZero );
            // 拠点名
            scmPrtSetting.SectionNm = this.GetDispValue( this.tEdit_SectionGuideNm );
            // 得意先コード
            scmPrtSetting.CustomerCode = this.GetDispValue( this.tNedit_CustomerCode );
            // 得意先名
            scmPrtSetting.CustomerName = this.GetDispValue( this.tEdit_CustomerName );
            // メーカーコード
            scmPrtSetting.GoodsMakerCd = this.GetDispValue( this.tNedit_GoodsMakerCd );
            // メーカー名
            scmPrtSetting.MakerName = this.GetDispValue( this.tEdit_GoodsMakerName );
            // 商品中分類コード
            scmPrtSetting.GoodsMGroup = this.GetDispValue( this.tNedit_GoodsMGroup );
            // 商品中分類名
            scmPrtSetting.GoodsMGroupName = this.GetDispValue( this.tEdit_GoodsMGroupName );
            // ＢＬコード
            scmPrtSetting.BLGoodsCode = this.GetDispValue( this.tNedit_BLGoodsCode );
            // ＢＬコード名
            scmPrtSetting.BLGoodsName = this.GetDispValue( this.tEdit_BLCodeName );
            // 品番
            scmPrtSetting.GoodsNo = this.GetDispValue( this.tEdit_GoodsNo );
            // 品名
            scmPrtSetting.GoodsName = this.GetDispValue( this.tEdit_GoodsName_ReadOnly );
            // 自動回答区分
            scmPrtSetting.AutoAnswerDiv = (int)this.tComboEditor_AutoAnswerDiv.Value;

            // グループコード
            scmPrtSetting.BLGroupCode = _blGroupCode;
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
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note		: 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private bool ScreenDataCheck( ref Control control, ref string message )
        {
            bool result = true;

            // 入力項目一覧
            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(tEdit_SectionCodeAllowZero);
            ctrlList.Add(tNedit_CustomerCode);
            ctrlList.Add(tNedit_GoodsMakerCd);
            ctrlList.Add(tNedit_GoodsMGroup);
            ctrlList.Add(tNedit_BLGoodsCode);
            ctrlList.Add(tEdit_GoodsNo);

            // メッセージ一覧
            Dictionary<string, string> messageList = new Dictionary<string, string>();
            messageList.Add( tEdit_SectionCodeAllowZero.Name, "拠点コード" );
            messageList.Add( tNedit_CustomerCode.Name, "得意先コード" );
            messageList.Add( tNedit_GoodsMakerCd.Name, "メーカーコード" );
            messageList.Add( tNedit_GoodsMGroup.Name, "商品中分類コード" );
            messageList.Add( tNedit_BLGoodsCode.Name, "ＢＬコード" );
            messageList.Add( tEdit_GoodsNo.Name, "品番" );


            // 表示されていて入力可能な全ての項目は必須入力。
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
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

            return true;
        }

        /// <summary>
        /// SCM品目設定テーブル更新
        /// </summary>
        /// <return>更新結果status</return>
        /// <remarks>
        /// <br>Note       : Subsectionテーブルの更新を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private bool SaveRecord()
        {
            // 登録レコード情報取得(変更前)
            if ( _scmPrtSetting == null || _scmPrtSetting.FileHeaderGuid == Guid.Empty )
            {
                _scmPrtSetting = _scmPrtSettingAcs.GetRecordForMaintenance( _recordGuid );
            }

            // ＵＩからデータ取得
            DispToRecord( ref _scmPrtSetting );
            ArrayList writeList = new ArrayList();
            writeList.Add( _scmPrtSetting );

            // 更新
            string msg;
            int status = _scmPrtSettingAcs.Write( ref writeList, out msg );

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
                    ExclusiveTransaction( status, TMsgDisp.OPE_UPDATE, this._scmPrtSettingAcs );
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
                        this._scmPrtSettingAcs,				    // エラーが発生したオブジェクト
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
        /// SCM品目設定 論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : SCM品目設定の対象レコードをマスタから論理削除します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private int LogicalDeleteSubsection()
        {
            int status = 0;

            return status;
        }

        /// <summary>
        /// SCM品目設定 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : SCM品目設定の対象レコードをマスタから物理削除します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private int PhysicalDeleteRecord()
        {
            int status = 0;


            // 登録レコード情報取得(変更前)
            if ( _scmPrtSetting == null || _scmPrtSetting.FileHeaderGuid == Guid.Empty )
            {
                _scmPrtSetting = _scmPrtSettingAcs.GetRecordForMaintenance( _recordGuid );
            }
            ArrayList writeList = new ArrayList();
            writeList.Add( _scmPrtSetting );

            // 物理削除
            string msg;
            status = _scmPrtSettingAcs.Delete( ref writeList, out msg );

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction( status, TMsgDisp.OPE_DELETE, this._scmPrtSettingAcs );
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
                        this._scmPrtSettingAcs,					// エラーが発生したオブジェクト
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
        /// 拠点 復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : SCM品目設定の対象レコードを復活します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private int ReviveRecord()
        {
            int status = 0;

                // 登録レコード情報取得(変更前)
                if ( _scmPrtSetting == null || _scmPrtSetting.FileHeaderGuid == Guid.Empty )
                {
                    _scmPrtSetting = _scmPrtSettingAcs.GetRecordForMaintenance( _recordGuid );
                }
                ArrayList writeList = new ArrayList();
                writeList.Add( _scmPrtSetting );


                string msg;
                status = this._scmPrtSettingAcs.Revival( ref writeList, out msg );


                switch ( status )
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        // 排他処理
                        ExclusiveTransaction( status, TMsgDisp.OPE_UPDATE, this._scmPrtSettingAcs );
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
                            this._scmPrtSettingAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
                        return status;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            return status;
        }

        /// <summary>
        /// 新規登録時処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規登録時の処理を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            // 新規モードの場合は画面を終了せずに連続入力を可能とする
            if ( this.Mode_Label.Text == INSERT_MODE )
            {
                // クローン作成
                this._recordClone = _scmPrtSetting.Clone();

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
        /// UI子画面強制終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データ更新エラー時のUI子画面強制終了処理を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
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
                _scmPrtSetting = new SCMPrtSetting();
                DispToRecord( ref _scmPrtSetting );
                int retStatus = _scmPrtSettingAcs.Read( ref _scmPrtSetting );

                // 画面クリア処理
                ScreenClear();
                
                if ( retStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _scmPrtSetting.LogicalDeleteCode == 0 )
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
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
        # endregion

        # region Control Events

        /// <summary>
        /// Form.Load イベント(MAKHN09230U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void PMSCM09001UB_Load(object sender, System.EventArgs e)
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
            
            // 初期フォーカス
            this.tComboEditor_SetKind1.Focus();
        }

        /// <summary>
        /// Form.Closing イベント(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void PMSCM09001UB_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        /// <summary>
        /// Control.VisibleChanged イベント(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void PMSCM09001UB_VisibleChanged(object sender, System.EventArgs e)
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            bool cloneFlg = true;

            // 削除モード以外の場合は保存確認処理を行う
            if ( this.Mode_Label.Text != DELETE_MODE )
            {
                // 現在の画面情報を取得
                SCMPrtSetting scmPrtSetting = new SCMPrtSetting();
                scmPrtSetting = this._recordClone.Clone();
                DispToRecord( ref scmPrtSetting );
                // 最初に取得した画面情報と比較
                cloneFlg = this._recordClone.Equals( scmPrtSetting );


                if ( !(cloneFlg) )
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

            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
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
            }
        }

        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2008.06.04</br>
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
        /// <br>Programmer	: 22018　鈴木 正臣</br>
        /// <br>Date		: 2009/05/11</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            //_modeFlg = false;
        
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
                        MasterRead(ref tNedit_CustomerCode, ref tEdit_CustomerName, ref _prevCustomerCode, ReadCustomer, ref e, "得意先" );
                    }
                    break;
                // メーカー
                case "tNedit_GoodsMakerCd":
                    {
                        int makerCdBackup = _prevGoodsMakerCd;
                        MasterRead(ref tNedit_GoodsMakerCd, ref tEdit_GoodsMakerName, ref _prevGoodsMakerCd, ReadMaker, ref e, "メーカー" );

                        // 商品再取得
                        if ( this.tEdit_GoodsNo.Text.Trim() != string.Empty )
                        {
                            // 内部判定の為、一時的に戻します
                            _prevGoodsMakerCd = makerCdBackup;
                            ReadGoods( ref e );
                        }
                    }
                    break;
                // 商品中分類
                case "tNedit_GoodsMGroup":
                    {
                        MasterRead(ref tNedit_GoodsMGroup, ref tEdit_GoodsMGroupName, ref _prevGoodsMGroup, ReadGoodsMGroup, ref e, "商品中分類" );
                    }
                    break;
                // ＢＬコード
                case "tNedit_BLGoodsCode":
                    {
                        MasterRead( ref tNedit_BLGoodsCode, ref tEdit_BLCodeName, ref _prevBLGoodsCode, ReadBLCode, ref e, "ＢＬコード" );
                        if ( _prevBLGoodsCode == 0 ) _blGroupCode = 0;
                    }
                    break;
                // 品番
                case "tEdit_GoodsNo":
                    {
                        ReadGoods( ref e );

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
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
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD
                    }
                    break;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
                case "tComboEditor_AutoAnswerDiv":
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
                    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD
                default:
                    break;
            }
        }

        /// <summary>
        /// 各種マスタ読み込み共通処理（数値コード用）
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="tEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        private void MasterRead(ref TNedit codeEdit, ref TEdit nameEdit, ref int prevCode, MasterReadForNumber proc, ref ChangeFocusEventArgs e, string masterName )
        {
            int code = codeEdit.GetInt();

            if ( code != 0 )
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
                    codeEdit.SetInt( code );
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
                codeEdit.SetInt( 0 );
                nameEdit.Text = string.Empty;
                prevCode = 0;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
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
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
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
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD
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
        private void MasterRead( ref TEdit codeEdit, ref TEdit nameEdit, ref string prevCode, MasterReadForText proc )
        {
            string code = codeEdit.Text.Trim();

            if ( code != string.Empty )
            {
                string name;
                bool status = proc( ref code, out name );

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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SetKind1_ValueChanged( object sender, EventArgs e )
        {
            DrawPanelsBySetKind1();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SetKind2_ValueChanged( object sender, EventArgs e )
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
                    this.tNedit_GoodsMGroup.SetInt( goodsMGroup.GoodsMGroup );
                    this.tEdit_GoodsMGroupName.Text = goodsMGroup.GoodsMGroupName;
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
                    _prevBLGoodsCode = bLGoodsCdUMnt.BLGoodsCode;

                    _blGroupCode = bLGoodsCdUMnt.BLGloupCode;

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
            MakerUMnt maker;
            int status = _guideControl.MakerAcs.Read( out maker, this._enterpriseCode, code );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && maker != null )
            {
                name = maker.MakerName;
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
        /// 商品中分類名取得
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadGoodsMGroup( ref int code, out string name )
        {
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
        private bool ReadBLCode( ref int code, out string name )
        {
            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = _guideControl.BLGoodsCdAcs.Read( out blGoodsCdUMnt, _enterpriseCode, code );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && blGoodsCdUMnt != null )
            {
                name = blGoodsCdUMnt.BLGoodsFullName;
                _blGroupCode = blGoodsCdUMnt.BLGloupCode;
                return true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                _blGroupCode = 0;

                return false;
            }
        }

        /// <summary>
        /// 商品情報　取得処理
        /// </summary>
        private void ReadGoods( ref ChangeFocusEventArgs e )
        {
            // 画面入力の取得
            int makerCode = this.tNedit_GoodsMakerCd.GetInt();
            string makerName = tEdit_GoodsMakerName.Text.Trim();
            string goodsNo = this.tEdit_GoodsNo.Text.Trim();
            string goodsName = string.Empty;

            bool checkOK = false;

            if ( goodsNo != string.Empty )
            {
                if ( goodsNo != _prevGoodsNo || makerCode != _prevGoodsMakerCd )
                {
                    # region [抽出条件]
                    GoodsCndtn cndtn = new GoodsCndtn();
                    cndtn.EnterpriseCode = this._enterpriseCode;
                    cndtn.GoodsMakerCd = makerCode;
                    cndtn.GoodsNo = goodsNo;
                    cndtn.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                    cndtn.PriceApplyDate = DateTime.Today;
                    # endregion

                    // 検索実行
                    List<GoodsUnitData> goodsUnitDataList;
                    string msg;
                    int status = this._guideControl.GoodsAcs.SearchPartsFromGoodsNoNonVariousSearch( cndtn, out goodsUnitDataList, out msg );

                    # region [結果取得と反映]
                    // 結果取得
                    if ( status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL )
                    {
                        // キャンセル時
                        goodsNo = string.Empty;
                        goodsName = string.Empty;

                        _prevGoodsNo = string.Empty;

                        checkOK = false;
                    }
                    else if ( goodsUnitDataList.Count > 0 )
                    {
                        // 通常
                        GoodsUnitData goodsUnitData = goodsUnitDataList[0];
                        makerCode = goodsUnitData.GoodsMakerCd;
                        makerName = goodsUnitData.MakerName;
                        goodsNo = goodsUnitData.GoodsNo;
                        goodsName = goodsUnitData.GoodsName;

                        checkOK = true;
                    }
                    else
                    {
                        // エラーメッセージ
                        TMsgDisp.Show( this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "商品が存在しません。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK );				// 表示するボタン


                        goodsNo = string.Empty;
                        goodsName = string.Empty;

                        checkOK = false;
                    }


                    // ＵＩ表示
                    tNedit_GoodsMakerCd.SetInt( makerCode );
                    tEdit_GoodsMakerName.Text = makerName;
                    tEdit_GoodsNo.Text = goodsNo;
                    tEdit_GoodsName_ReadOnly.Text = goodsName;

                    // 前回入力として退避
                    _prevGoodsMakerCd = makerCode;
                    _prevGoodsNo = goodsNo;
                    # endregion
                }
                else
                {
                    // 品番・メーカーが変わらなければ無視する
                    checkOK = true;
                }
            }
            else
            {
                // 入力クリア（品番・品名のみ）
                tEdit_GoodsNo.Text = string.Empty;
                tEdit_GoodsName_ReadOnly.Text = string.Empty;

                _prevGoodsNo = string.Empty;

                checkOK = true;
            }

            if ( checkOK )
            {
            }
            else
            {
                e.NextCtrl = e.PrevCtrl;
            }
        }
        /// <summary>
        /// 商品読み込み
        /// </summary>
        private void ReadGoods()
        {
            int makerCd = this.tNedit_GoodsMakerCd.GetInt();
            string goodsNo = this.tEdit_GoodsNo.Text.Trim();

            if ( goodsNo != string.Empty && makerCd != 0 )
            {
                GoodsUnitData goodsUnitData;
                int status = this._guideControl.GoodsAcs.Read( this._enterpriseCode, makerCd, goodsNo, out goodsUnitData );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    tEdit_GoodsNo.Text = goodsUnitData.GoodsNo;
                    tEdit_GoodsName_ReadOnly.Text = goodsUnitData.GoodsName;

                    _prevGoodsNo = goodsUnitData.GoodsNo;
                }
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
                case "tComboEditor_SetKind2":
                    nextControl = tEdit_SectionCodeAllowZero;
                    break;
                case "tEdit_SectionCodeAllowZero":
                    nextControl = tNedit_CustomerCode;
                    break;
                case "tNedit_CustomerCode":
                    nextControl = tNedit_GoodsMakerCd;
                    break;
                case "tNedit_GoodsMakerCd":
                    nextControl = tNedit_GoodsMGroup;
                    break;
                case "tNedit_GoodsMGroup":
                    nextControl = tNedit_BLGoodsCode;
                    break;
                case "tNedit_BLGoodsCode":
                    nextControl = tEdit_GoodsNo;
                    break;
                default:
                    nextControl = tComboEditor_AutoAnswerDiv;
                    break;
            }

            // 入力不可なら再帰的に取得
            if ( !nextControl.Enabled || !nextControl.Visible )
            {
                nextControl = GetNextEdit( nextControl );
            }

            // 返却
            return nextControl;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
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
                case "tComboEditor_AutoAnswerDiv":
                    prevControl = tEdit_GoodsNo;
                    break;
                case "tEdit_GoodsNo":
                    prevControl = tNedit_BLGoodsCode;
                    break;
                case "tNedit_BLGoodsCode":
                    prevControl = tNedit_GoodsMGroup;
                    break;
                case "tNedit_GoodsMGroup":
                    prevControl = tNedit_GoodsMakerCd;
                    break;
                case "tNedit_GoodsMakerCd":
                    prevControl = tNedit_CustomerCode;
                    break;
                case "tNedit_CustomerCode":
                    prevControl = tEdit_SectionCodeAllowZero;
                    break;
                case "tEdit_SectionCodeAllowZero":
                    prevControl = tComboEditor_SetKind2;
                    break;
                case "tComboEditor_SetKind2":
                    prevControl = tComboEditor_SetKind1;
                    break;
                default:
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/28 DEL
                    //prevControl = tComboEditor_AutoAnswerDiv;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/28 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/28 ADD
                    prevControl = Cancel_Button;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/28 ADD
                    break;
            }

            // 入力不可なら再帰的に取得
            if ( !prevControl.Enabled || !prevControl.Visible )
            {
                prevControl = GetPrevEdit( prevControl );
            }

            // 前項目の入力チェック
            if ( prevControl != null )
            {
                if ( prevControl is TNedit )
                {
                    if ( (prevControl as TNedit).GetInt() == 0 )
                    {
                        prevControl = null;
                    }
                }
                else if ( prevControl is TEdit )
                {
                    if ( (prevControl as TEdit).Text.Trim() == string.Empty )
                    {
                        prevControl = null;
                    }
                }
            }

            // 返却
            return prevControl;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD

        /// <summary>
        /// 設定種別１・２取得処理
        /// </summary>
        /// <param name="scmPrtSetting"></param>
        /// <param name="setKind1"></param>
        /// <param name="setKind2"></param>
        private void GetSetKind( SCMPrtSetting scmPrtSetting, out int setKind1, out int setKind2 )
        {
            # region [設定種別１]
            if ( scmPrtSetting.SectionCode == null || scmPrtSetting.SectionCode.Trim() != string.Empty )
            {
                // 1:拠点
                setKind1 = 1;
            }
            else if ( scmPrtSetting.CustomerCode != 0 )
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
            if ( scmPrtSetting.GoodsNo != string.Empty )
            {
                // 3:メーカー＋品番
                setKind2 = 3;
            }
            else if ( scmPrtSetting.BLGoodsCode != 0 )
            {
                // 2:メーカー＋ＢＬコード
                setKind2 = 2;
            }
            else if ( scmPrtSetting.GoodsMGroup != 0 )
            {
                // 1:メーカー＋商品中分類
                setKind2 = 1;
            }
            else
            {
                // 0:メーカー
                setKind2 = 0;
            }

            # endregion
        }

        # endregion
    }
}
