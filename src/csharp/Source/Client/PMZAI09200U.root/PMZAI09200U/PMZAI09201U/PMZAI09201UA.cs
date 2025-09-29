using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品在庫一括登録修正フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品在庫一括登録修正関連の一覧表示を行うフォームクラスです。<br />
    /// <br>Programmer : 30452 上野 俊治<br />
    /// <br>Date       : 2008.12.22<br />
    /// <br>Update Note: 2009.02.03 30452 上野 俊治</br>
    /// <br>            ・障害対応(10780,10775,10769,10752,10749,10748,10746,10739,10738)</br>
    /// <br>            ・障害対応(10786,10785,10784,10737,10736)</br>
    /// <br>Update Note: 2009.02.03 30452 上野 俊治</br>
    /// <br>            ・障害対応(10777)</br>
    /// <br>Update Note: 2009.02.04 30452 上野 俊治</br>
    /// <br>            ・障害対応(10787)</br>
    /// <br>Update Note: 2009.02.05 30452 上野 俊治</br>
    /// <br>            ・障害対応(10790)</br>
    /// <br>Update Note: 2009.02.12 30452 上野 俊治</br>
    /// <br>            ・障害対応(11364)</br>
    /// <br>Update Note: 2009/02/23 30452 上野 俊治</br>
    /// <br>            ・障害対応10766 複数行選択対応</br>
    /// <br>Update Note: 2009/03/03 30452 上野 俊治</br>
    /// <br>            ・障害対応12104,12103,12081,12074,12075</br>
    /// <br>Update Note: 2009/03/03 30452 上野 俊治</br>
    /// <br>            ・障害対応12079</br>
    /// <br>Update Note: 2009/03/05 30452 上野 俊治</br>
    /// <br>            ・障害対応12082,12070,12132,12073,12205</br>
    /// <br>Update Note: 2009/03/10 30452 上野 俊治</br>
    /// <br>            ・障害対応12223</br>
    /// <br>Update Note: 2009/11/26 30434 工藤 恵優</br>
    /// <br>            ・障害対応14686</br>
    /// <br>Update Note: 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
    /// <br>Update Note: 2010/08/11 高峰 障害改良対応（８月分） キーボード操作の改良を行う</br>
    /// <br>Update Note: 2011/08/03 王飛３</br>
    /// <br>            ・Redmine23379</br>
    /// <br>①在庫登録時に管理区分１・２が未入力の場合、コード０をセットして頂く様にしました。</br>
    /// <br>②管理区分マスタに登録の無いコードの入力があった際は、マスタの存在チェックを行わずに登録可能としました</br>
    /// <br>Update Note: 2011/08/23 wangf</br>
    /// <br>            ・Redmine23907</br>
    /// <br>①対象区分「商品」を選んでいるので、このメッセージ「在庫情報未入力です」は不要です</br>
    /// <br>Update Note: 2011/10/31 凌小青</br>
    /// <br>            .障害対応 Redmine#26317</br>
    /// <br>Update Note: 2011/11/29 30517 夏野 駿希</br>
    /// <br>             商品在庫一括登録修正検索時のタイムアウト時間を60秒に延長</br>
    /// <br>Update Note: 2012/09/19 凌小青</br>
    /// <br>            .障害対応 Redmine#32370　界面初期化刷新画面の修正</br>
    /// <br>Update Note: 2013/03/18 yangyi</br>
    /// <br>管理番号   : 10801804-00 20150515配信分の対応</br>
    /// <br>           : Redmine#34962 　「商品在庫一括修正」のサーバー負荷軽減対応</br>
    /// <br>Update Note: 2013/05/11 yangyi</br>
    /// <br>管理番号   : 10801804-00 20150515配信分の対応</br>
    /// <br>           : Redmine#35018 「商品在庫一括修正」のサーバー負荷軽減　その２対応</br>
    /// </remarks>
    public partial class PMZAI09201UA : Form
    {
        #region ■private定数
        private const string CT_PGID = "PMZAI09201U";
        private readonly Color CT_EssentialColor = Color.FromArgb(179, 219, 231);
        private readonly Color CT_OptionalColor = Color.FromArgb(255, 255, 255);
        #endregion

        #region ■private変数

        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin;

        // 企業コード
        private string _enterpriseCode;
        // 自拠点コード
        private string _sectionCode;

        // ガイド関連
        // メーカーガイド
        private MakerAcs _makerAcs;
        // 倉庫ガイド
        private WarehouseAcs _warehouseAcs;
        // 商品中分類ガイド
        private GoodsGroupUAcs _goodsGroupUAcs;
        // BLコードガイド
        private BLGoodsCdAcs _blGoodsCdAcs;
        // 管理拠点ガイド
        SecInfoSetAcs _secInfoSetAcs;
        // 担当者ガイド
        private EmployeeAcs _employeeAcs;

        // 初期化完了フラグ (true:完了済)
        private bool _initializeFinish = false;
        // フォームClose前処理完了フラグ
        private bool _closeCheckFinish = false;

        // 抽出条件前回入力値(更新有無チェック用)
        private int _tmpGoodsMakerCd;
        private int _tmpGoodsMGroup;
        private int _tmpBLGoodsCode;
        private string _tmpWareHouseCode;
        private string _tmpEmployeeCode;
        private string _tmpSectionCode;

        private int _tmpDisplayDivValue; // ADD 2009/02/03
        private int _tmpTargetDivValue; // ADD 2009/02/03

        // 明細グリッドコントロールクラス
        private PMZAI09201UB _detailGrid;
        // 商品在庫一括登録修正アクセスクラス
        private GoodsStockAcs _goodsStockAcs;

        private object _preComboEditorValue = null; // ADD 2010/08/11

        private int _maxCount = 0; //ADD yangyi 2013/03/18 Redmine#34962 

        private PMZAI09201UC _form = null;  //ADD yangyi 2013/03/18 Redmine#34962 
     
        #endregion

        #region ■コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        public PMZAI09201UA()
        {
            InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();

            // ログイン情報取得
            this.GetLoginInfo();

            // ガイド初期化
            this.GetGuideInstance();

            // グリッド
            this._detailGrid = new PMZAI09201UB();

            // 商品在庫一括登録修正アクセスクラス
            this._goodsStockAcs = GoodsStockAcs.GetInstance();

            // 抽出条件取得イベント
            this._detailGrid.GetExtractInfo += new PMZAI09201UB.GetExtractInfoHander(this.DetailGrid_GetExtractInfo);

            // フォーカス設定イベント
            this._detailGrid.SetFocus += new PMZAI09201UB.SettingFocusEventHandler(this.DetailGrid_SetFocus);

            // 保存ボタン押下可否設定イベント
            this._detailGrid.SetSaveButton += new PMZAI09201UB.SetSaveButtonEnableHandler(this.SetSaveButtonEnable); // ADD 2009/02/03

            this._detailGrid.SetGuide += new PMZAI09201UB.SetGuideEnabled(this.SetGuideEnabled); // ADD 2010/08/11
        }
        #endregion

        #region ■publicプロパティ
        /// <summary>
        /// フォームClose前処理完了フラグ
        /// </summary>
        public bool FormCloseCheckFinish
        {
            get { return this._closeCheckFinish; }
        }
        #endregion

        #region ■publicメソッド

        /// <summary>
        /// フォームClose前更新確認＆保存処理
        /// </summary>
        public void FormClosingCheck()
        {
            if (!this._closeCheckFinish)
            {
                this.CloseWindow();
            }
        }

        /// <summary>
        /// ＸＭＬデータの保存処理
        /// </summary>
        public void SaveStateXmlData()
        {
            // グリッド情報を保存
            this._detailGrid.SaveStateXmlData();
        }
        #endregion

        #region ■privateメソッド

        #region ■ 初期表示関連
        /// <summary>
        /// ログイン情報取得
        /// </summary>
        private void GetLoginInfo()
        {
            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 自拠点コード
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        }

        /// <summary>
        /// アクセスクラス初期化
        /// </summary>
        private void GetGuideInstance()
        {
            this._makerAcs = new MakerAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._employeeAcs = new EmployeeAcs();
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // 初期化処理中(イベント制御)
                this._initializeFinish = false;

                // --- ADD 2009/03/05 -------------------------------->>>>>
                // スキン変更除外設定
                List<string> excCtrlNm = new List<string>();
                excCtrlNm.Add(this.uGroupBox_ExtractInfo.Name);
                this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);
                // --- ADD 2009/03/05 --------------------------------<<<<<

                // スキン設定
                this._controlScreenSkin.LoadSkin();
                this._controlScreenSkin.SettingScreenSkin(this);

                // ツールバーアイコン設定
                tToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
                this.tToolbarsManager1.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
                this.tToolbarsManager1.Tools["ButtonTool_Save"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
                this.tToolbarsManager1.Tools["ButtonTool_New"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL; // ADD 2009/02/03
                this.tToolbarsManager1.Tools["ButtonTool_Search"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
                this.tToolbarsManager1.Tools["ButtonTool_Guide"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE; // ADD 2010/08/11
                this.tToolbarsManager1.Tools["ButtonTool_Renewal"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL; // ADD 2010/08/11
                this.tToolbarsManager1.Tools["ButtonTool_SetUp"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;  //ADD yangyi 2013/03/18 Redmine#34962 

                // ガイドボタンアイコン設定
                this.SetIconImage(this.uButton_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_WarehouseCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_GoodsMGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_BLGoodsCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_SectionCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_EmployeeCdGuide, Size16_Index.STAR1);

                // 保存ボタン押下可否設定
                this.SetSaveButtonEnable(); // ADD 2009/02/03

                // パネル表示を非表示に
                this.Panel_GoodsMGroup.Visible = false;
                this.Panel_WareHouse.Visible = false;
                this.Panel_Section.Visible = false;
                this.Panel_BLGoodsCode.Visible = false;

                // 削除行を表示しない
                this.DeleteIndication_CheckEditor.Checked = false;

                // 表示区分
                //this.tComboEditor_DisplayDiv.Value = 0; // DEL 2009/02/03
                this.tComboEditor_DisplayDiv.Value = 1; // ADD 2009/02/03

                // 対象区分
                this.tComboEditor_TargetDiv.ResetItems(); // ADD 2009/02/03
                this.SetTComboEditor_TargetDiv(); // ADD 2009/02/03
                this.tComboEditor_TargetDiv.Value = 0;

                // 出力指定(ValueList設定)
                this.tComboEditor_OutputDiv.ResetItems();
                this.SetTComboEditor_OutputDiv();
                this.tComboEditor_OutputDiv.Value = 0;

                // 出力指定(表示有無)
                this.SetTComboEditor_OutputDivVisible();

                // 抽出条件コード、名称のクリア
                this.tNedit_GoodsMakerCd.SetInt(0);
                this.uLabel_GoodsMakerName.Text = string.Empty;
                this.tEdit_WarehouseCode.DataText = string.Empty;
                this.uLabel_WareHouseName.Text = string.Empty;
                this.tNedit_GoodsMGroup.SetInt(0);
                this.uLabel_GoodsMGroupName.Text = string.Empty;
                this.tEdit_GoodsNo.DataText = string.Empty;
                this.tNedit_BLGoodsCode.SetInt(0);
                this.uLabel_BLGoodsCodeName.Text = string.Empty;
                this.tEdit_SectionCode.DataText = string.Empty;
                this.uLabel_SectionName.Text = string.Empty;
                this.tEdit_EmployeeCode.DataText = string.Empty;
                this.uLabel_EmployeeName.Text = string.Empty;

                // 抽出条件保存値のクリア
                this._tmpGoodsMakerCd = 0;
                this._tmpWareHouseCode = string.Empty;
                this._tmpGoodsMGroup = 0;
                this._tmpBLGoodsCode = 0;
                this._tmpSectionCode = string.Empty;
                this._tmpEmployeeCode = string.Empty;

                this._tmpDisplayDivValue = 0; // ADD 2009/02/03
                this._tmpTargetDivValue = 0; // ADD 2009/02/03

                // 抽出条件設定
                this.SetExtractItemSettings();

                // 初期化処理完了
                this._initializeFinish = true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// ガイドボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }

        /// <summary>
        /// 対象区分リストボックス設定
        /// </summary>
        private void SetTComboEditor_TargetDiv()
        {
            Infragistics.Win.ValueListItem listItem;

            if ((int)this.tComboEditor_DisplayDiv.SelectedItem.DataValue == 0) // 表示区分 新規登録
            {
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                //listItem.DisplayText = "商品"; // DEL 2010/08/11
                listItem.DisplayText = "0:商品"; // ADD 2010/08/11
                this.tComboEditor_TargetDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 3;
                listItem.DataValue = 3;
                //listItem.DisplayText = "在庫"; // DEL 2010/08/11
                listItem.DisplayText = "3:在庫"; // ADD 2010/08/11
                this.tComboEditor_TargetDiv.Items.Add(listItem);
            }
            else  // 表示区分 修正登録
            {
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                //listItem.DisplayText = "商品"; // DEL 2010/08/11
                listItem.DisplayText = "0:商品"; // ADD 2010/08/11
                this.tComboEditor_TargetDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                //listItem.DisplayText = "商品-在庫"; // DEL 2010/08/11
                listItem.DisplayText = "1:商品-在庫"; // ADD 2010/08/11
                this.tComboEditor_TargetDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                //listItem.DisplayText = "在庫-商品"; // DEL 2010/08/11
                listItem.DisplayText = "2:在庫-商品"; // ADD 2010/08/11
                this.tComboEditor_TargetDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 3;
                listItem.DataValue = 3;
                //listItem.DisplayText = "在庫"; // DEL 2010/08/11
                listItem.DisplayText = "3:在庫"; // ADD 2010/08/11
                this.tComboEditor_TargetDiv.Items.Add(listItem);
            }
        }

        /// <summary>
        /// 出力リストボックス設定
        /// </summary>
        private void SetTComboEditor_OutputDiv()
        {
            Infragistics.Win.ValueListItem listItem;

            if (this._goodsStockAcs.RateProtyMngExist) 
            {
                // 掛率優先管理情報がある
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                //listItem.DisplayText = "全て"; // DEL 2010/08/11
                listItem.DisplayText = "0:全て"; // ADD 2010/08/11
                this.tComboEditor_OutputDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                //listItem.DisplayText = "ユーザ価格設定分"; // DEL 2010/08/11
                listItem.DisplayText = "1:ユーザ価格設定分"; // ADD 2010/08/11
                this.tComboEditor_OutputDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                //listItem.DisplayText = "原価設定分"; // DEL 2010/08/11
                listItem.DisplayText = "2:原価設定分"; // ADD 2010/08/11
                this.tComboEditor_OutputDiv.Items.Add(listItem);
            }
            else
            {
                // 掛率優先管理情報がない
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                //listItem.DisplayText = "全て"; // DEL 2010/08/11
                listItem.DisplayText = "0:全て"; // ADD 2010/08/11
                this.tComboEditor_OutputDiv.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                //listItem.Tag = 2; // DEL 2010/08/11
                //listItem.DataValue = 2; // DEL 2010/08/11
                //listItem.DisplayText = "原価設定分"; // DEL 2010/08/11
                listItem.Tag = 1; // ADD 2010/08/11
                listItem.DataValue = 1; // ADD 2010/08/11
                listItem.DisplayText = "1:原価設定分"; // ADD 2010/08/11
                this.tComboEditor_OutputDiv.Items.Add(listItem);
            }
        }

        /// <summary>
        /// 出力指定リストボックス設定
        /// </summary>
        private void SetTComboEditor_OutputDivVisible()
        {
            if ((int)this.tComboEditor_DisplayDiv.SelectedItem.DataValue == 0
                || (int)this.tComboEditor_TargetDiv.SelectedItem.DataValue == 3) // 表示区分「新規登録」か対象区分「在庫」
            {
                // 表示しない
                this.uLabel_OutputDiv.Visible = false;
                this.tComboEditor_OutputDiv.Visible = false;
            }
            else
            {
                // 表示する
                this.uLabel_OutputDiv.Visible = true;
                this.tComboEditor_OutputDiv.Visible = true;
            }
        }
        #endregion

        #region ■ 抽出条件パネル設定
        /// <summary>
        /// 抽出条件設定
        /// </summary>
        private void SetExtractItemSettings()
        {
            // パネルを一度非表示にする
            this.Panel_WareHouse.Visible = false;
            this.Panel_GoodsMGroup.Visible = false;
            this.Panel_BLGoodsCode.Visible = false;
            this.Panel_Section.Visible = false;

            // パネル位置調整
            this.Panel_GoodsMGroup.Location = this.Panel_WareHouse.Location;
            this.Panel_BLGoodsCode.Location = this.Panel_Section.Location;

            if ((ExtractInfo.DisplayDivState)this.tComboEditor_DisplayDiv.SelectedItem.DataValue 
                == ExtractInfo.DisplayDivState.New)
            {
                // 表示区分「新規登録」
                if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue 
                    == ExtractInfo.TargetDivState.Goods)
                {
                    // 対象区分「商品」
                    this.Panel_GoodsMGroup.Visible = false;
                    this.Panel_BLGoodsCode.Visible = true;
                    this.Panel_WareHouse.Visible = false;
                    this.Panel_Section.Visible = false;

                    // 入力必須項目
                    this.tNedit_GoodsMakerCd.Appearance.BackColor = this.CT_EssentialColor;
                    this.tNedit_BLGoodsCode.Appearance.BackColor = this.CT_OptionalColor;
                    this.tEdit_WarehouseCode.Appearance.BackColor = this.CT_OptionalColor;
                    this.tEdit_SectionCode.Appearance.BackColor = this.CT_OptionalColor;
                }
                else
                {
                    // 対象区分「在庫」
                    this.Panel_WareHouse.Visible = true;
                    this.Panel_Section.Visible = true;
                    this.Panel_GoodsMGroup.Visible = false;
                    this.Panel_BLGoodsCode.Visible = false;

                    // 入力必須項目
                    this.tNedit_GoodsMakerCd.Appearance.BackColor = this.CT_EssentialColor;
                    this.tEdit_WarehouseCode.Appearance.BackColor = this.CT_EssentialColor;
                    this.tEdit_SectionCode.Appearance.BackColor = this.CT_EssentialColor;
                    this.tNedit_BLGoodsCode.Appearance.BackColor = this.CT_OptionalColor;
                }
            }
            else
            {
                // 表示区分「修正登録」
                if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.Goods
                    || (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.GoodsStock)
                {
                    // 対象区分「商品」「商品-在庫」
                    this.Panel_GoodsMGroup.Visible = true; // 商品中分類
                    this.Panel_BLGoodsCode.Visible = true; // BLコード
                    this.Panel_WareHouse.Visible = false;
                    this.Panel_Section.Visible = false;

                    this.tNedit_BLGoodsCode.Appearance.BackColor = this.CT_OptionalColor;
                    this.tNedit_GoodsMakerCd.Appearance.BackColor = this.CT_OptionalColor;
                    this.tEdit_WarehouseCode.Appearance.BackColor = this.CT_OptionalColor;
                    this.tEdit_SectionCode.Appearance.BackColor = this.CT_OptionalColor;
                }
                else if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.StockGoods)
                {
                    // 対象区分「在庫-商品」
                    this.Panel_WareHouse.Visible = true;
                    this.Panel_Section.Visible = true;
                    this.Panel_GoodsMGroup.Visible = false;
                    this.Panel_BLGoodsCode.Visible = false;

                    this.tNedit_GoodsMakerCd.Appearance.BackColor = this.CT_OptionalColor;
                    this.tEdit_WarehouseCode.Appearance.BackColor = this.CT_OptionalColor;
                    this.tEdit_SectionCode.Appearance.BackColor = this.CT_OptionalColor;
                    this.tNedit_BLGoodsCode.Appearance.BackColor = this.CT_OptionalColor;
                }
                else
                {
                    // 対象区分「在庫」
                    this.Panel_WareHouse.Visible = true;
                    this.Panel_Section.Visible = true;
                    this.Panel_GoodsMGroup.Visible = false;
                    this.Panel_BLGoodsCode.Visible = false;

                    // 入力必須項目
                    this.tNedit_GoodsMakerCd.Appearance.BackColor = this.CT_EssentialColor;
                    this.tEdit_WarehouseCode.Appearance.BackColor = this.CT_EssentialColor; // ADD 2009/02/03
                    this.tEdit_SectionCode.Appearance.BackColor = this.CT_EssentialColor; // ADD 2009/02/03
                    this.tNedit_BLGoodsCode.Appearance.BackColor = this.CT_OptionalColor;
                }
            }
        }

        #endregion

        # region ■ 抽出条件取得処理 ■
        /// <summary>
        /// 抽出条件情報取得処理
        /// </summary>
        /// <returns>メソッド呼出し時の抽出条件</returns>
        /// <remarks>グリッド側よりデリゲート呼出しあり</remarks>
        private ExtractInfo GetExtractInfo()
        {
            ExtractInfo extractInfo = new ExtractInfo();

            // 表示区分
            extractInfo.DisplayDiv
                = (ExtractInfo.DisplayDivState)this.tComboEditor_DisplayDiv.SelectedItem.DataValue;
            // 対象区分
            extractInfo.TargetDiv
                = (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue;
            // 出力指定
            extractInfo.OutputDiv
                = (ExtractInfo.OutputDivState)this.tComboEditor_OutputDiv.SelectedItem.DataValue;

            // 商品メーカーコード
            extractInfo.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            extractInfo.MakerName = this.uLabel_GoodsMakerName.Text;

            // 商品中分類
            extractInfo.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();
            extractInfo.GoodsMGroupName = this.uLabel_GoodsMGroupName.Text;

            // 倉庫コード
            extractInfo.WarehouseCode = this.tEdit_WarehouseCode.DataText;
            extractInfo.WarehouseName = this.uLabel_WareHouseName.Text;

            // 品番
            extractInfo.GoodsNo = this.tEdit_GoodsNo.DataText;
            
            // ＢＬコード
            extractInfo.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            extractInfo.BLGoodsName = this.uLabel_BLGoodsCodeName.Text;
            
            // 管理拠点コード
            extractInfo.AddUpSectionCode = this.tEdit_SectionCode.DataText;
            extractInfo.AddUpSectionGuidNm = this.uLabel_SectionName.Text;

            // 入力担当者コード
            extractInfo.StockAgentCode = this.tEdit_EmployeeCode.DataText;
            extractInfo.StockAgentName = this.uLabel_EmployeeName.Text;

            // 削除済みデータ表示ボタン状態
            extractInfo.DeleteIndication = this.DeleteIndication_CheckEditor.Checked;

            return extractInfo;
        }
        #endregion

        # region ■ 検索処理 ■
        /// <summary>
        /// 検索処理
        /// </summary>
        private void Search()
        {
            int status = -1;

            // 変更有無チェック
            bool isChanged = this.CompareGridDataWithOriginal();

            if (isChanged)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
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

            string errMsg;
            Control errCtl;

            // 入力条件チェック
            if (!this.SearchBeforeCheck(out errMsg, out errCtl))
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);

                // コントロールにフォーカスをセット
                if (errCtl != null)
                {
                    errCtl.Focus();
                    // --- ADD 2010/08/09 ---------->>>>>
                    switch (errCtl.Name)
                    {
                        case "tEdit_EmployeeCode":
                        case "tNedit_GoodsMakerCd":
                        case "tNedit_BLGoodsCode":
                        case "tEdit_WarehouseCode":
                        case "tEdit_SectionCode":
                        case "tNedit_GoodsMGroup":
                        {
                            ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = true;
                            break;
                        }
                        default:
                        {
                            ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false;
                            break;
                        }
                    }
                    // --- ADD 2010/08/09 ----------<<<<<
                }

                return;
            }

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "抽出中";
            msgForm.Message = "商品在庫情報の抽出中です。";

            // --- ADD 2009/02/04 -------------------------------->>>>>
            // キャンセルボタン追加
            msgForm.DispCancelButton = true;
            msgForm.CancelButtonClick += new EventHandler(this.SearchCancelButton_Click);
            this._goodsStockAcs.CancelFlg = false;
            // --- ADD 2009/02/04 --------------------------------<<<<<

            try
            {
                msgForm.Show();

                if ((ExtractInfo.DisplayDivState)this.tComboEditor_DisplayDiv.SelectedItem.DataValue ==
                    ExtractInfo.DisplayDivState.New
                    && (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue ==
                    ExtractInfo.TargetDivState.Goods)
                {
                    // 新規登録の商品時、提供データ検索
                    status = this.ExecuteOfferGoodsUnitDataSearch(out errMsg);
                }
                else
                {
                    // 修正登録時、ユーザデータ検索
                    status = this.ExecuteUserGoodsUnitDataSearch(out errMsg);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // --- ADD 2009/03/03 -------------------------------->>>>>
                    // ソート、フィルタ状態の破棄
                    this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();
                    this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.RefreshSort(true);
                    this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    // --- ADD 2009/03/03 --------------------------------<<<<<

                    // グリッド表示の更新
                    this._detailGrid.SetGridSettings();

                    // キー項目のActivation制御
                    this._detailGrid.SetCellActivation();

                    // 削除済みデータ表示・非表示の反映
                    this._detailGrid.DeleteIndicationSetting(this.DeleteIndication_CheckEditor.Checked);

                    msgForm.Close();

                    if (this._goodsStockAcs.CancelFlg)
                    {
                        // キャンセル処理メッセージ
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "検索処理を中断しました。",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                    }
                    // ADD gezh 2013/01/24 Redmine#33361 「20000件」の改修案 ----->>>>>
                    if (this._goodsStockAcs.OutMaxCount)
                    {
                        // キャンセル処理メッセージ
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "データ件数が20,000件を超えました。",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                    }
                    // ADD gezh 2013/01/24 Redmine#33361 「20000件」の改修案 -----<<<<<
                    int activationColIndex;
                    int activationRowIndex;

                    // フォーカス設定
                    string nextFocusColKey = this._detailGrid.GetNextFocusColumnKey(0, 0, false, out activationColIndex, out activationRowIndex);

                    if (nextFocusColKey != string.Empty)
                    {
                        this._detailGrid.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColKey].Activate();
                        //this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        // --- ADD 2009/02/23 -------------------------------->>>>>
                        if (!this._detailGrid.uGrid_Details.Rows[activationRowIndex].IsFilteredOut)
                        {
                            this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            if (this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.BelowCell))
                            {
                                this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this._detailGrid.uGrid_Details.ActiveCell = null;
                                this._detailGrid.uGrid_Details.ActiveRow = null;
                            }
                        }
                        // --- ADD 2009/02/23 --------------------------------<<<<<
                    }
                }
                // --- ADD 2009/02/03 -------------------------------->>>>>
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF
                        || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    msgForm.Close();

                    // 0件エラー
                    DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "検索条件に該当するデータが存在しません",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                }
                // 2011/11/29 Add >>>
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgForm.Close();

                    // タイムアウトエラー
                    DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "処理が込み合っています。\n少し経ってから、再度検索を行って下さい。",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                }
                // 2011/11/29 Add <<<
                else
                {
                    msgForm.Close();

                    // その他エラー
                    DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            this.Name,
                            "検索処理でエラーが発生しました" + "[" + errMsg + "]",
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                }
                // --- ADD 2009/02/03 --------------------------------<<<<<
            }
            finally
            {
                //msgForm.Close();
                this.SetSaveButtonEnable(); // ADD 2009/02/03
                this._detailGrid.SetButtonEnable(); // ADD 2009/02/23
            }
        }

        /// <summary>
        /// 検索処理前入力項目チェック
        /// </summary>
        /// <returns></returns>
        private bool SearchBeforeCheck(out string errMsg, out Control errCtl)
        {
            bool status = true;
            errMsg = string.Empty;
            errCtl = null;

            if ((ExtractInfo.DisplayDivState)this.tComboEditor_DisplayDiv.SelectedItem.DataValue 
                == ExtractInfo.DisplayDivState.New)
            {
                // 表示区分「新規登録」
                if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                    == ExtractInfo.TargetDivState.Goods)
                {
                    // 対象区分「商品」
                    if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                    {
                        status = false;
                        errMsg = "メーカーコードを入力してください";
                        errCtl = tNedit_GoodsMakerCd;
                    }
                    else if (string.IsNullOrEmpty(this.tEdit_GoodsNo.DataText)
                        && this.tNedit_BLGoodsCode.GetInt() == 0)
                    {
                        status = false;
                        errMsg = "品番かBLコードを入力してください";
                        if (string.IsNullOrEmpty(this.tEdit_GoodsNo.DataText))
                        {
                            errCtl = tEdit_GoodsNo;
                        }
                        else
                        {
                            errCtl = tNedit_BLGoodsCode;
                        }
                    }
                }
                else
                {
                    // 対象区分「在庫」
                    if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                    {
                        status = false;
                        errMsg = "メーカーコードを入力してください";
                        errCtl = tNedit_GoodsMakerCd;
                    }
                    // --- ADD 2009/03/10 -------------------------------->>>>>
                    else if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.DataText))
                    {
                        status = false;
                        errMsg = "倉庫コードを入力してください";
                        errCtl = tEdit_WarehouseCode;
                    }
                    else if (string.IsNullOrEmpty(this.tEdit_SectionCode.DataText))
                    {
                        status = false;
                        errMsg = "管理拠点コードを入力してください";
                        errCtl = tEdit_SectionCode;
                    }
                    // --- ADD 2009/03/10 --------------------------------<<<<<
                }
            }
            else
            {
                // 表示区分「修正登録」
                if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue 
                    == ExtractInfo.TargetDivState.Stock)
                {
                    // 対象区分「在庫」
                    if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                    {
                        status = false;
                        errMsg = "メーカーコードを入力してください";
                        errCtl = tNedit_GoodsMakerCd;
                    }
                    // --- ADD 2009/02/03 -------------------------------->>>>>
                    else if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.DataText))
                    {
                        status = false;
                        errMsg = "倉庫コードを入力してください";
                        errCtl = tEdit_WarehouseCode;
                    }
                    else if (string.IsNullOrEmpty(this.tEdit_SectionCode.DataText))
                    {
                        status = false;
                        errMsg = "管理拠点コードを入力してください";
                        errCtl = tEdit_SectionCode;
                    }
                    // --- ADD 2009/02/03 --------------------------------<<<<<
                }
            }

            return status;
        }

        /// <summary>
        /// 商品連結データ(提供分)検索処理
        /// </summary>
        /// <returns></returns>
        private int ExecuteOfferGoodsUnitDataSearch(out string errMsg)
        {
            // 抽出条件(区分)取得
            ExtractInfo extractInfo = this.GetExtractInfo();

            extractInfo.MaxCount = _maxCount;  //ADD yangyi 2013/03/18 Redmine#34962

            //string errMsg; // DEL 2009/02/03
            int status = this._goodsStockAcs.SearchOfferGoodsUnitData(extractInfo, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._detailGrid.BeforeSearchExtractInfo = extractInfo;
            }
            // --- DEL 2009/02/03 -------------------------------->>>>>
            //else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF
            //    || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            //{
            //    // 0件エラー
            //    DialogResult dialogResult = TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_INFO,
            //            this.Name,
            //            "検索条件に該当するデータが存在しません。",
            //            status,
            //            MessageBoxButtons.OK,
            //            MessageBoxDefaultButton.Button1);
            //}
            //else
            //{
            //    // その他エラー
            //    DialogResult dialogResult = TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_STOP,
            //            this.Name,
            //            "検索処理でエラーが発生しました。" + "["+ errMsg + "]",
            //            status,
            //            MessageBoxButtons.OK,
            //            MessageBoxDefaultButton.Button1);
            //}
            // --- DEL 2009/02/03 --------------------------------<<<<<

            return status;
        }

        /// <summary>
        /// 商品連結データ(ユーザー分)検索処理
        /// </summary>
        /// <returns></returns>
        private int ExecuteUserGoodsUnitDataSearch(out string errMsg)
        {
            // 抽出条件(区分)取得
            ExtractInfo extractInfo = this.GetExtractInfo();

            extractInfo.MaxCount = _maxCount;  //ADD yangyi 2013/03/18 Redmine#34962

            //string errMsg; // DEL 2009/02/03
            int status = this._goodsStockAcs.SearchUserGoodsUnitData(extractInfo, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._detailGrid.BeforeSearchExtractInfo = extractInfo;
            }
            // --- DEL 2009/02/03 -------------------------------->>>>>
            //else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF
            //    || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            //{
            //    // 0件エラー
            //    DialogResult dialogResult = TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_INFO,
            //            this.Name,
            //            "検索条件に該当するデータが存在しません",
            //            0,
            //            MessageBoxButtons.OK,
            //            MessageBoxDefaultButton.Button1);
            //}
            //else
            //{
            //    // 0件エラー
            //    DialogResult dialogResult = TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_STOP,
            //            this.Name,
            //            "検索処理でエラーが発生しました" + "[" + errMsg + "]",
            //            0,
            //            MessageBoxButtons.OK,
            //            MessageBoxDefaultButton.Button1);
            //}
            // --- DEL 2009/02/03 --------------------------------<<<<<

            return status;
        }

        # endregion ■ 検索処理 ■

        # region ■ 終了処理 ■
        /// <summary>
        /// 終了処理
        /// </summary>
        /// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
        private void CloseWindow()
        {
            // 変更有無チェック
            bool isChanged =  this.CompareGridDataWithOriginal();

            if (isChanged)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                    "登録してもよろしいですか？",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    int status = this.Save();
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this._closeCheckFinish = true;
                        this.Close();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    this._closeCheckFinish = true;
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                this._closeCheckFinish = true;
                this.Close();
            }
        }
        # endregion ■ 終了処理 ■

        # region ■ 保存処理 ■
        /// <summary>
        /// 保存処理
        /// </summary>
        private int Save()
        {
            // ADD 2009/11/26 MANTIS対応[14686]：月次更新後の在庫データの更新は不可 ---------->>>>>
            // TODO:月次更新後であれば在庫データの更新は行えない
            if (!MAKHN09280UA.CanWrite(DateTime.Now)) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            // ADD 2009/11/26 MANTIS対応[14686]：月次更新後の在庫データの更新は不可 ----------<<<<<
            // --- ADD 2009/02/03 -------------------------------->>>>>
            if (this._detailGrid.uGrid_Details.ActiveCell != null
                && this._detailGrid.uGrid_Details.ActiveCell.IsInEditMode)
            {
                // 編集モードを解除する
                this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
            }
            // --- ADD 2009/02/03 --------------------------------<<<<<

            this._goodsStockAcs.GoodsStockDataTable.AcceptChanges(); // ADD 2009/03/10
            // --- ADD 2009/02/03 -------------------------------->>>>>
            // データ存在チェック
            if (this._goodsStockAcs.GoodsStockDataTable.Rows.Count == 0)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "更新対象のデータが存在しません",
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);

                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            // --- ADD 2009/02/03 --------------------------------<<<<<

            // 変更有無チェック
            if (this._detailGrid.BeforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update)
            {
                bool isChanged = this.CompareGridDataWithOriginal();

                if (!isChanged)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "更新対象のデータが存在しません",
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);

                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }
            }

            string errMsg;
            Control errCtl;

            // 入力条件チェック
            if (!this.SaveBeforeExtractInfoCheck(out errMsg, out errCtl))
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);

                // コントロールにフォーカスをセット
                if (errCtl != null)
                {
                    errCtl.Focus();
                    // --- ADD 2010/08/09 ---------->>>>>
                    switch (errCtl.Name)
                    {
                        case "tEdit_EmployeeCode":
                        case "tNedit_GoodsMakerCd":
                        case "tNedit_BLGoodsCode":
                        case "tEdit_WarehouseCode":
                        case "tEdit_SectionCode":
                        case "tNedit_GoodsMGroup":
                            {
                                ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = true;
                                break;
                            }
                        default:
                            {
                                ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false;
                                break;
                            }
                    }
                    // --- ADD 2010/08/09 ----------<<<<<
                }

                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            // 入力チェック（グリッド内）
            if (!this.SaveBeforeGridCheck(out errMsg))
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);

                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            
            // 重複チェック
            if (!this.SaveBeforeDuplicationCheck(out errMsg))
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);

                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            // --- ADD 2009/03/10 -------------------------------->>>>>
            // 管理拠点違いのチェック

            bool dialogflag = false;//ADD 2011/08/03
            if (this._detailGrid.BeforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && this._detailGrid.BeforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
            {
                if (this.AddupSectionCheck())
                {
                    // 警告を表示
                    DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "更新対象に管理拠点の違う在庫情報が存在します。" + "\r\n" + "\r\n" +
                            "検索条件で入力された管理拠点で更新してよろしいですが？",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                    if (dialogResult != DialogResult.Yes)
                    {
                        return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    //-----ADD 2011/08/03---------->>>>>
                    else
                    {
                        dialogflag = true ;
                    }
                    //-----ADD 2011/08/03----------<<<<<

                }
            }
            // --- ADD 2009/03/10 --------------------------------<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string msg = "";

            Cursor _localCursor = this.Cursor;

            this.Cursor = Cursors.WaitCursor;

            // 保存中ダイアログ表示
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "保存中";
            msgForm.Message = "商品在庫情報の保存中です。";

            //-----ADD 2011/08/03---------->>>>>
            bool noinputflag = false;

            bool flag = false;
            int count = 0;

            while (flag == false && count < this._detailGrid.uGrid_Details.Rows.Count)
            {
                if (this._detailGrid.uGrid_Details.Rows[count].Cells["StockDeleteReserveFlg"].Value.ToString() == "0")
                {
                    flag = true;
                }
                count++;
            }
            //-----ADD 2011/08/03----------<<<<<
            try
            {
                // 保存処理            
                status = this._goodsStockAcs.Write(this._detailGrid.BeforeSearchExtractInfo, this.GetExtractInfo(), out msg);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // グリッドをクリアする
                            //this._goodsStockAcs.GoodsStockDataTable.Clear();//DEL 2011/08/03
                            //this._goodsStockAcs.OriginalGoodsStockDataTable.Clear();//DEL 2011/08/03

                            //-----ADD 2011/08/03---------->>>>>
                            //if (this._goodsStockAcs.NoneFlag == true && this._goodsStockAcs.HaveNullSectionRow == true && dialogflag ==false) // DEL wangf 2011/08/23
                            //-----ADD 2011/08/23---------->>>>>
                            if ((int)this.tComboEditor_DisplayDiv.SelectedItem.DataValue == 0 
                                  && (int)this.tComboEditor_TargetDiv.SelectedItem.DataValue == 3 
                                  && this._goodsStockAcs.NoneFlag == true 
                                  && this._goodsStockAcs.HaveNullSectionRow == true && dialogflag == false)
                            //-----ADD 2011/08/23----------<<<<<
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    CT_PGID,
                                    "在庫情報が未入力です",
                                    status,
                                    MessageBoxButtons.OK);
                                noinputflag = true;
                                if (flag ==true )
                                {
                                    this._detailGrid.uGrid_Details.ActiveCell = this._detailGrid.uGrid_Details.Rows[count-1].Cells["WarehouseShelfNo"];
                                    this._detailGrid.uGrid_Details.Focus();
                                    this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else
                            {
                                this._goodsStockAcs.GoodsStockDataTable.Clear();
                                this._goodsStockAcs.OriginalGoodsStockDataTable.Clear();
                            }
                            //-----ADD 2011/08/03----------<<<<<
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                CT_PGID,
                                //"登録処理にてエラーが発生しました。", // DEL 2009/03/10
                                "一部の商品／在庫の更新が出来ませんでした。" + "\r\n" + "\r\n"
                                + "エラー内容を確認して下さい。", // ADD 2009/03/10
                                status,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);

                            // グリッド表示の更新
                            this._detailGrid.SetGridSettings();

                            // エラーメッセージ行を表示
                            this._detailGrid.uGrid_Details.DisplayLayout.Bands[0]
                                .Columns[this._goodsStockAcs.GoodsStockDataTable.ErrorMessageColumn.ColumnName].Hidden = false; // ADD 2009/03/10

                            // キー項目のActivation制御
                            this._detailGrid.SetCellActivation();

                            // 削除済みデータ表示・非表示の反映
                            this._detailGrid.DeleteIndicationSetting(this.DeleteIndication_CheckEditor.Checked);

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                status = -1; // ADD 2009/02/23
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                    CT_PGID,
                    "登録処理にてエラーが発生しました。" + "[" + ex.Message + "]",
                    status,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            finally
            {
                // 保存中ダイアログを閉じる
                msgForm.Close();

                // 保存ボタン押下可否制御
                this.SetSaveButtonEnable(); // ADD 2009/02/03

                this._detailGrid.SetButtonEnable(); // ADD 2009/02/23

                // カーソルを元に戻す
                this.Cursor = _localCursor;
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)//DEL 2011/08/03
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && noinputflag ==false )//ADD 2011/08/03
                {
                    // 保存確認ダイアログを表示する
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.Show(2); 
                }
            }

            return status;
        }

        /// <summary>
        /// 保存処理前入力項目チェック
        /// </summary>
        /// <returns></returns>
        /// <remarks>入力チェックは現在の設定値ではなく、検索時の条件でチェック</remarks>
        private bool SaveBeforeExtractInfoCheck(out string errMsg, out Control errCtl)
        {
            bool status = true;
            errMsg = string.Empty;
            errCtl = null;

            if (this._detailGrid.BeforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && this._detailGrid.BeforeSearchExtractInfo.TargetDiv
                == ExtractInfo.TargetDivState.Stock)
            {
                if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.DataText))
                {
                    status = false;
                    errMsg = "倉庫コードを入力してください";
                    errCtl = tEdit_WarehouseCode;
                }
                else if (string.IsNullOrEmpty(this.tEdit_SectionCode.DataText))
                {
                    status = false;
                    errMsg = "管理拠点コードを入力してください";
                    errCtl = tEdit_SectionCode;
                }
            }

            if (status
                && string.IsNullOrEmpty(this.tEdit_EmployeeCode.DataText))
            {
                status = false;
                errMsg = "入力担当コードを入力してください";
                errCtl = tEdit_EmployeeCode;
            }

            return status;
        }

        // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
        /// <summary>
        /// 最大出力件数の設定処理
        /// </summary>
        private void SetUp()
        {
            _form = new PMZAI09201UC();
            _form.ShowDialog();
            _maxCount = _form.MaxCount;
        }
        // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<

        /// <summary>
        /// グリッド項目チェック
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2013/05/11 yangyi</br>
        /// <br>管理番号   : 10801804-00 20150515配信分の対応</br>
        /// <br>           : Redmine#35018 「商品在庫一括修正」のサーバー負荷軽減　その２対応</br>
        /// </remarks>
        private bool SaveBeforeGridCheck(out string errMsg)
        {
            errMsg = string.Empty;

            //--- ADD 2013/05/11 yangyi Redmine#35018の#53-No.7 ----->>>>>
            bool needCheck = true;
            int rowIndex = 0;
            int errRowIndex = 0;
            bool focusFlg = true;
            //--- ADD 2013/05/11 yangyi Redmine#35018の#53-No.7 -----<<<<<

            if (this._detailGrid.BeforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && this._detailGrid.BeforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                // キー項目の入力が無い場合エラー
                foreach (UltraGridRow ultraRow in this._detailGrid.uGrid_Details.Rows)
                {
                    if (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].Value == null
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].Value == DBNull.Value
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == string.Empty)
                    {
                        errMsg = "品番を入力してください";

                        // フォーカス
                        ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].Activate();
                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        
                        return false;
                    }
                    else if (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value == null
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value == DBNull.Value
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value.ToString() == string.Empty)
                    {
                        errMsg = "品名を入力してください";

                        // フォーカス
                        ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Activate();
                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }
                    else if (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName].Value == null
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName].Value == DBNull.Value
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName].Value.ToString() == string.Empty
                        || (int)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName].Value == 0)
                    {
                        errMsg = "メーカーコードを入力してください";

                        // フォーカス
                        ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName].Activate();
                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }
                    // --- ADD 2010/06/08 ---------->>>>>
                    else if (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate1Column.ColumnName].Value == null
                      || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate1Column.ColumnName].Value == DBNull.Value
                      || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate1Column.ColumnName].Value.ToString() == string.Empty)
                    {
                        errMsg = "価格開始日１を入力してください";

                        // フォーカス
                        ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate1Column.ColumnName].Activate();
                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }
                    // --- ADD 2010/06/08 ----------<<<<<
                }
            }
            else if (this._detailGrid.BeforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && this._detailGrid.BeforeSearchExtractInfo.TargetDiv != ExtractInfo.TargetDivState.Stock)
            {
                // 価格開始日が一つもない場合エラー
                foreach (UltraGridRow ultraRow in this._detailGrid.uGrid_Details.Rows)
                {
                    UltraGridRow nextRow = null;
                    if (rowIndex < this._detailGrid.uGrid_Details.Rows.Count - 1)
                    {
                        nextRow = (UltraGridRow)this._detailGrid.uGrid_Details.Rows[rowIndex + 1];
                    }
                    rowIndex++;
                    // 既論理削除行、論理削除予約行は対象外
                    if (
                        (int)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName].Value != 0
                        ||
                        //(ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value != null
                        //&& ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsDeleteDateColumn.ColumnName].Value != DBNull.Value) // DEL 2009/02/05
                        (int)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName].Value != 0 // ADD 2009/02/05
                        )
                    {
                        // 更新行ではないのでチェック不要
                        continue;
                    }

                    // 商品変更有無フラグ
                    bool isChangedRow = false;

                    // 新規行はチェック対象
                    //if (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() == "新規") // DEL 2009/03/06
                    if (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.RowIndexColumn.ColumnName].Value.ToString() == "新規") // ADD 2009/03/06
                    {
                        isChangedRow = true;
                    }
                    else
                    {
                        // 更新行と更新前行を比較
                        // --- DEL 2009/03/06 -------------------------------->>>>>
                        //DataRow originalDr = this._goodsStockAcs.OriginalGoodsStockDataTable
                        //    .Select(this._goodsStockAcs.GoodsStockDataTable.RowNumberColumn.ColumnName + " = '"
                        //    + ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() + "'")[0];

                        //DataRow updateDr = this._goodsStockAcs.GoodsStockDataTable
                        //.Select(this._goodsStockAcs.GoodsStockDataTable.RowNumberColumn.ColumnName + " = '"
                        //    + ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.RowNumberColumn.ColumnName].Value.ToString() + "'")[0];
                        // --- DEL 2009/03/06 --------------------------------<<<<<
                        // --- ADD 2009/03/06 -------------------------------->>>>>
                        DataRow originalDr = this._goodsStockAcs.OriginalGoodsStockDataTable
                            .Select(this._goodsStockAcs.GoodsStockDataTable.RowIndexColumn.ColumnName + " = '"
                            + ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.RowIndexColumn.ColumnName].Value.ToString() + "'")[0];

                        DataRow updateDr = this._goodsStockAcs.GoodsStockDataTable
                        .Select(this._goodsStockAcs.GoodsStockDataTable.RowIndexColumn.ColumnName + " = '"
                            + ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.RowIndexColumn.ColumnName].Value.ToString() + "'")[0];
                        // --- ADD 2009/03/06 --------------------------------<<<<<
                        //int stockColIndex = this._detailGrid.uGrid_Details.DisplayLayout.Bands[0]
                        //    .Columns[this._goodsStockAcs.GoodsStockDataTable.WarehouseCodeColumn.ColumnName].Index;  //DELETE BY 凌小青 on 2011/10/31 for Redmine#26317
                        //-------------ADD BY 凌小青 on 2011/10/31 for Redmine#26317 ----------------->>>>>>>>>>>>>>
                        int stockColIndex = this._detailGrid.uGrid_Details.DisplayLayout.Bands[0]
                            .Columns[this._goodsStockAcs.GoodsStockDataTable.StockUnitPriceFlColumn.ColumnName].Index + 1; 
                        int WarehouseCodeIndex = this._detailGrid.uGrid_Details.DisplayLayout.Bands[0]
                            .Columns[this._goodsStockAcs.GoodsStockDataTable.WarehouseCodeColumn.ColumnName].Index;
                        //-------------ADD BY 凌小青 on 2011/10/31 for Redmine#26317 -----------------<<<<<<<<<<<<<<
                        for (int i = 0; i < stockColIndex; i++)
                        {
                            // 在庫削除日は除く
                            //-------------DEL BY 凌小青 on 2011/10/31 for Redmine#26317 ----------------->>>>>>>>>>>
                            //if (i != this._detailGrid.uGrid_Details.DisplayLayout.Bands[0]
                            //.Columns[this._goodsStockAcs.GoodsStockDataTable.StockDeleteDateColumn.ColumnName].Index)
                            //{
                            //    if (originalDr[i].ToString() != updateDr[i].ToString())
                            //    {
                            //        isChangedRow = true;
                            //        break;
                            //    }
                            //}
                            //-------------DEL BY 凌小青 on 2011/10/31 for Redmine#26317 -----------------<<<<<<<<<<<<

                            //-------------ADD BY 凌小青 on 2011/10/31 for Redmine#26317 ----------------->>>>>>>>>>>>>>
                            if (i != this._detailGrid.uGrid_Details.DisplayLayout.Bands[0]
                            .Columns[this._goodsStockAcs.GoodsStockDataTable.StockDeleteDateColumn.ColumnName].Index)
                            {                              
                                if (i < WarehouseCodeIndex)
                                {
                                    if (originalDr[i].ToString() != updateDr[i].ToString())
                                    {
                                        isChangedRow = false;
                                        continue;
                                    }
                                }                                
                                else if (originalDr[i].ToString() != updateDr[i].ToString())
                                {
                                    isChangedRow = true;
                                    break;
                                }
                            }
                            //-------------ADD BY 凌小青 on 2011/10/31 for Redmine#26317 -----------------<<<<<<<<<<<<<<<<
                        }

                    }

                    if (
                        isChangedRow
                        &&
                        (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate1Column.ColumnName].Value == null
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate1Column.ColumnName].Value == DBNull.Value)
                        &&
                        (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate2Column.ColumnName].Value == null
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate2Column.ColumnName].Value == DBNull.Value)
                        &&
                        (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate3Column.ColumnName].Value == null
                        || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate3Column.ColumnName].Value == DBNull.Value)
                       )
                    {
                        errMsg = "価格開始日に一つ以上入力してください";

                        // フォーカス
                        ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PriceStartDate1Column.ColumnName].Activate();
                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }

                    // --- ADD 2009/03/03 -------------------------------->>>>>
                    // 商品-在庫の場合、新規在庫のチェック
                    if (isChangedRow) //ADD BY 凌小青 on 2011.10.31 for Redmine#26317
                    {
                        if (this._detailGrid.BeforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock
                            || this._detailGrid.BeforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods)
                        {
                            if (
                                // --- DEL 2009/03/05 -------------------------------->>>>>
                                //(ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value == null
                                //||
                                //ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName].Value == DBNull.Value
                                //)
                                //&&
                                // --- DEL 2009/03/05 -------------------------------->>>>>
                                (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.WarehouseCodeColumn.ColumnName].Value == null
                                ||
                                ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.WarehouseCodeColumn.ColumnName].Value == DBNull.Value)
                                )
                            {
                                // 倉庫コードの入力なし＆他の在庫項目に入力ありの場合エラー
                                if (
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.WarehouseShelfNoColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.WarehouseShelfNoColumn.ColumnName].Value != DBNull.Value)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.DuplicationShelfNo1Column.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.DuplicationShelfNo1Column.ColumnName].Value != DBNull.Value)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.DuplicationShelfNo2Column.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.DuplicationShelfNo2Column.ColumnName].Value != DBNull.Value)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PartsManagementDivide1Column.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PartsManagementDivide1Column.ColumnName].Value != DBNull.Value)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PartsManagementDivide2Column.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.PartsManagementDivide2Column.ColumnName].Value != DBNull.Value)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockSupplierCodeColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockSupplierCodeColumn.ColumnName].Value != DBNull.Value
                                    && (int)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockSupplierCodeColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockDivColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockDivColumn.ColumnName].Value != DBNull.Value
                                    && (int)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockDivColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.SalesOrderUnitColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.SalesOrderUnitColumn.ColumnName].Value != DBNull.Value
                                    && (int)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.SalesOrderUnitColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MinimumStockCntColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MinimumStockCntColumn.ColumnName].Value != DBNull.Value
                                    && (double)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MinimumStockCntColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MaximumStockCntColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MaximumStockCntColumn.ColumnName].Value != DBNull.Value
                                    && (double)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MaximumStockCntColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.SupplierStockColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.SupplierStockColumn.ColumnName].Value != DBNull.Value
                                    && (double)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.SupplierStockColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.ArrivalCntColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.ArrivalCntColumn.ColumnName].Value != DBNull.Value
                                    && (double)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.ArrivalCntColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.ShipmentCntColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.ShipmentCntColumn.ColumnName].Value != DBNull.Value
                                    && (double)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.ShipmentCntColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.AcpOdrCountColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.AcpOdrCountColumn.ColumnName].Value != DBNull.Value
                                    && (double)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.AcpOdrCountColumn.ColumnName].Value != 0)
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MovingSupliStockColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MovingSupliStockColumn.ColumnName].Value != DBNull.Value
                                    && (double)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.MovingSupliStockColumn.ColumnName].Value != 0)
                                    // --- ADD 2009/03/05 -------------------------------->>>>>
                                    ||
                                    (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockUnitPriceFlColumn.ColumnName].Value != null
                                    && ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockUnitPriceFlColumn.ColumnName].Value != DBNull.Value
                                    && (double)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.StockUnitPriceFlColumn.ColumnName].Value != 0)
                                    // --- ADD 2009/03/05 --------------------------------<<<<<
                                    )
                                {
                                    errMsg = "倉庫コードを入力してください";

                                    // フォーカス
                                    ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.WarehouseCodeColumn.ColumnName].Activate();
                                    this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                                    return false;
                                }

                            }
                        }
                    } //ADD BY 凌小青 on 2011.10.31
                    // --- ADD 2009/03/03 --------------------------------<<<<<
                    //--- ADD 2013/05/11 yangyi Redmine#35018の#53-No.7 ----->>>>>
                    if (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == _detailGrid.GridGoodsNo
                             && (int)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName].Value == _detailGrid.GridGoodsMakerCd)
                    {
                        // 同一商品はいくつか倉庫があり、且つ、フォーカスは品名セルである場合、一行で品名は空白さえなければ、品名のチェックを行わない
                        if (focusFlg)
                        {
                            errRowIndex = ultraRow.Index;
                            focusFlg = false;
                        }
                        if (!needCheck)
                        {
                            continue;
                        }

                        if (!(ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value == null
                            || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value == DBNull.Value
                            || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value.ToString() == string.Empty))
                        {
                            needCheck = false;
                            continue;
                        }
                        if (nextRow == null ||
                            !(ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() == nextRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].Value.ToString() &&
                            (int)ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName].Value == (int)nextRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName].Value))
                        {
                            errMsg = "品名を入力してください";

                            // フォーカス
                            ((UltraGridRow)this._detailGrid.uGrid_Details.Rows[errRowIndex]).Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Activate();
                            this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                            return false;
                        }
                    }
                    else
                    {
                    //--- ADD 2013/05/11 yangyi Redmine#35018の#53-No.7 -----<<<<<
                        // --- ADD 2010/06/08 ---------->>>>>
                        if (
                            //--- DEL 2013/05/11 yangyi Redmine#35018の#53-No.7 ----->>>>>
                            //isChangedRow
                            //&&
                            //--- DEL 2013/05/11 yangyi Redmine#35018の#53-No.7 -----<<<<<
                            (ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value == null
                            || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value == DBNull.Value
                            || ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Value.ToString() == string.Empty))
                        {

                            errMsg = "品名を入力してください";

                            // フォーカス
                            ultraRow.Cells[this._goodsStockAcs.GoodsStockDataTable.GoodsNameColumn.ColumnName].Activate();
                            this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                            return false;
                        }
                    } // ADD 2013/05/11 yangyi Redmine#35018の#53-No.7
                    // --- ADD 2010/06/08 ----------<<<<<
                }
            }

            return true;
        }

        /// <summary>
        /// キー重複チェック
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="errCtl"></param>
        /// <returns></returns>
        private bool SaveBeforeDuplicationCheck(out string errMsg)
        {
            errMsg = string.Empty;

            // 商品、在庫追加がある場合のみチェックが必要
            if (this._detailGrid.BeforeSearchExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && this._detailGrid.BeforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                // 新規追加行を取得
                //DataRow[] drList = this._goodsStockAcs.GoodsStockDataTable.Select(
                //    this._goodsStockAcs.GoodsStockDataTable.RowNumberColumn.ColumnName + " = '新規'"); // DEL 2009/03/06
                DataRow[] drList = this._goodsStockAcs.GoodsStockDataTable.Select(
                    this._goodsStockAcs.GoodsStockDataTable.RowIndexColumn.ColumnName + " = '新規'"); // ADD 2009/03/06

                foreach (DataRow dr in drList)
                {
                    int sameKeyNum = 0;

                    string goodsNo = dr[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].ToString();
                    int makerCd = (int)dr[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName];

                    foreach (DataRow checkDr in drList)
                    {
                        if (goodsNo == checkDr[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].ToString()
                            && makerCd == (int)checkDr[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName])
                        {
                            sameKeyNum++;
                        }
                    }

                    if (sameKeyNum > 1)
                    {
                        errMsg = "商品追加した行でキーが重複しています。"　+"\r\n" + "\r\n" +
									"【品名：" + goodsNo + " " + "メーカー名：" + makerCd.ToString() + "】";

                        // キー重複あり
                        return false;
                    }
                }

                return true;
            }
            else if (this._detailGrid.BeforeSearchExtractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {
                // 新規追加行を取得
                //DataRow[] drList = this._goodsStockAcs.GoodsStockDataTable.Select(
                //    this._goodsStockAcs.GoodsStockDataTable.RowNumberColumn.ColumnName + " = '新規'");
                DataRow[] drList = this._goodsStockAcs.GoodsStockDataTable.Select(
                    this._goodsStockAcs.GoodsStockDataTable.RowIndexColumn.ColumnName + " = '新規'"); // ADD 2009/03/06

                foreach (DataRow dr in drList)
                {
                    int sameKeyNum = 0;

                    string goodsNo = dr[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].ToString();
                    int makerCd = (int)dr[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName];
                    string warehouseCd = dr[this._goodsStockAcs.GoodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString();

                    foreach (DataRow checkDr in drList)
                    {
                        if (goodsNo == checkDr[this._goodsStockAcs.GoodsStockDataTable.GoodsNoColumn.ColumnName].ToString()
                            && makerCd == (int)checkDr[this._goodsStockAcs.GoodsStockDataTable.GoodsMakerColumn.ColumnName]
                            && warehouseCd == checkDr[this._goodsStockAcs.GoodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString())
                        {
                            sameKeyNum++;
                        }
                    }

                    if (sameKeyNum > 1)
                    {
                        errMsg = "在庫追加した行でキーが重複しています。" + "\r\n" + "\r\n" +
                                    "【品番：" + goodsNo + " " + "メーカーコード：" + makerCd.ToString() + "倉庫コード：" + warehouseCd.TrimEnd().PadLeft(4, '0') + "】";

                        // キー重複あり
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 管理拠点違いレコードの存在チェック
        /// </summary>
        /// <returns></returns>
        private bool AddupSectionCheck()
        {
            DataRow[] drList = this._goodsStockAcs.GoodsStockDataTable.Select(
                    this._goodsStockAcs.GoodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName + " <> '' AND "
                    + this._goodsStockAcs.GoodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName + " = 0");

            if (drList.Length > 0) return true;
            else return false;
        }

        # endregion ■ 保存処理 ■

        # region ■ 初期化処理 ■
        /// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		/// <returns>true:初期化実行 false:初期化未実行</returns>
        private void Clear()
        {
            // 変更有無チェック
            bool isChanged = this.CompareGridDataWithOriginal();

            if (isChanged)
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

            string errMsg;

            // 画面初期化
            int status = this.InitializeScreen(out errMsg);

            // グリッド部の初期化
            this._detailGrid.Initialize();

            // 保存ボタン押下可否設定
            this.SetSaveButtonEnable(); // ADD 2009/02/03

            // フォーカス設定
            this.tComboEditor_DisplayDiv.Focus();
            ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11

        }
        # endregion ■ 初期化処理 ■

        #region ■ その他処理 ■

        /// <summary>
        /// 明細グリッド変更有無チェック
        /// </summary>
        private bool CompareGridDataWithOriginal()
        {
            if (this._goodsStockAcs.GoodsStockDataTable.Rows.Count 
                != this._goodsStockAcs.OriginalGoodsStockDataTable.Rows.Count)
            {
                // 行数が変わっているか
                return true;
            }

            // 値が変更されたセルがあるか
            for (int rowIndex = 0; rowIndex < this._goodsStockAcs.GoodsStockDataTable.Rows.Count; rowIndex++)
            {
                for (int colIndex = 0; colIndex < this._goodsStockAcs.GoodsStockDataTable.Columns.Count; colIndex++)
                {
                    // 棚卸評価率は更新しないので除く
                    if (this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].Columns[colIndex].Key
                        != this._goodsStockAcs.GoodsStockDataTable.StockUnitPriceRateColumn.ColumnName) // ADD 2009/03/05
                    {
                        if (this._goodsStockAcs.GoodsStockDataTable.Rows[rowIndex][colIndex].ToString()
                            != this._goodsStockAcs.OriginalGoodsStockDataTable.Rows[rowIndex][colIndex].ToString())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 明細からのヘッダ情報取得イベント
        /// </summary>
        /// <returns></returns>
        private ExtractInfo DetailGrid_GetExtractInfo()
        {
            return GetExtractInfo();
        }

        /// <summary>
        /// 明細からのフォーカス設定イベント
        /// </summary>
        /// <param name="ctrlKey">コントロール名</param>
        /// <returns></returns>
        private void DetailGrid_SetFocus(string ctrlKey)
        {
            switch (ctrlKey)
            {
                case "tComboEditor_DisplayDiv":
                    {
                        this.tComboEditor_DisplayDiv.Focus();
                        ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
                        break;
                    }
                case "tComboEditor_TargetDiv":
                    {
                        this.tComboEditor_TargetDiv.Focus();
                        ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
                        break;
                    }
                case "tComboEditor_OutputDiv":
                    {
                        this.tComboEditor_OutputDiv.Focus();
                        ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
                        break;
                    }
                case "tEdit_GoodsNo":
                    {
                        this.tEdit_GoodsNo.Focus();
                        ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
                        break;
                    }
                case "tEdit_EmployeeCode":
                    {
                        this.tEdit_EmployeeCode.Focus();
                        ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = true; // ADD 2010/08/11
                        break;
                    }
                case "uButton_EmployeeCdGuide":
                    {
                        this.uButton_EmployeeCdGuide.Focus();
                        ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
                        break;
                    }
                case "Before_Grid":
                    {
                        // --- ADD 2009/03/06 -------------------------------->>>>>
                        // グリッドの前のコントロールにフォーカス
                        // 対象区分により異なる
                        if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                            == ExtractInfo.TargetDivState.Goods
                            || (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                            == ExtractInfo.TargetDivState.GoodsStock)
                        {
                            this.uButton_BLGoodsCdGuide.Focus();
                            ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
                        }
                        else
                        {
                            this.uButton_SectionCdGuide.Focus();
                            ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
                        }

                        break;
                        // --- ADD 2009/03/06 --------------------------------<<<<<
                    }
            }
        }

        /// <summary>
        /// 保存ボタンの押下可否を設定する
        /// </summary>
        private void SetSaveButtonEnable()
        {
            if (this._goodsStockAcs.GoodsStockDataTable.Rows.Count == 0)
            {
                this.tToolbarsManager1.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
            }
            else
            {
                this.tToolbarsManager1.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
            }
        }

        // --- ADD 2010/08/11 ---------->>>>>
        /// <summary>
        /// ガイドボタンのセット
        /// </summary>
        /// <param name="enabled"></param>
        private void SetGuideEnabled(bool enabled)
        {
            ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = enabled;
        }
        // --- ADD 2010/08/11 ----------<<<<<

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                "PMZAI09200UA",						// アセンブリＩＤまたはクラスＩＤ
                "商品在庫一括登録修正",				// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }

        #endregion

        #endregion

        #region ■コントロールイベント

        #region ■ Load,Closeイベント
        /// <summary>
        /// PMZAI09201UA_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI09201UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // コントロール初期化
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // 画面イメージ統一
            this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

            // 明細部
            this.Panel_Detail.Controls.Add(this._detailGrid);
            this._detailGrid.Dock = DockStyle.Fill;
            //-------ADD BY 凌小青 on 2012/09/19 for Redmine#32370------>>>>>>
            // XMLデータ読込
            this._detailGrid.LoadStateXmlData();
            //-------ADD BY 凌小青 on 2012/09/19 for Redmine#32370------<<<<<<
            // フォーカス設定タイマー
            this.InitialFocusTimer.Enabled = true;

            // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
            _form = new PMZAI09201UC();
            _maxCount = _form.MaxCount;

            if (_maxCount == 0)
            {
                _maxCount = 2000; //最大出力件数の規定値：2000
            }
            // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<

        }

        ///// <summary>
        ///// PMZAI09201UA_FormClosing
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void PMZAI09201UA_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (!this._closeProcFinish)
        //    {
        //        this.CloseWindow();
        //    }
        //}
        #endregion

        #region ■ ChangeFocusイベント
        /// <summary>
        /// tRetKeyControl1_ChangeFocusイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (!this._initializeFinish)
            {
                // 画面初期化中は処理しない
                return;
            }

            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // 表示区分
                case "tComboEditor_DisplayDiv":
                    {
                            if ((e.Key == Keys.Tab && e.ShiftKey) 
                                || e.Key == Keys.Left)
                            {
                                e.NextCtrl = this._detailGrid.uGrid_Details;
                            }
                            this.setTComboEditorByName(e.PrevCtrl.Name); // ADD 2010/08/11
                        break;
                    }
                // 対象区分
                case "tComboEditor_TargetDiv":
                    {
                        this.setTComboEditorByName(e.PrevCtrl.Name); // ADD 2010/08/11

                        break;
                    }
                // --- ADD 2010/08/11 ---------->>>>>
                // 出力指定
                case "tComboEditor_OutputDiv":
                    {
                        this.setTComboEditorByName(e.PrevCtrl.Name);

                        break;
                    }
                // --- ADD 2010/08/11 ----------<<<<<
                // メーカーコード
                case "tNedit_GoodsMakerCd":
                    {
                        #region メーカーコード
                        // 入力無し
                        if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpGoodsMakerCd = 0;
                            this.uLabel_GoodsMakerName.Text = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_GoodsMakerCd.GetInt() == this._tmpGoodsMakerCd)
                        {
                            if (e.NextCtrl == this.uButton_GoodsMakerCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                if ((ExtractInfo.DisplayDivState)this.tComboEditor_DisplayDiv.SelectedItem.DataValue == ExtractInfo.DisplayDivState.New
                                    && (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.Goods)
                                {
                                    // 新規、商品
                                    e.NextCtrl = this.tEdit_GoodsNo;
                                }
                                else if ((ExtractInfo.DisplayDivState)this.tComboEditor_DisplayDiv.SelectedItem.DataValue == ExtractInfo.DisplayDivState.Update
                                    &&
                                    ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.Goods
                                    || (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.GoodsStock)
                                    )
                                {
                                    // 修正登録、対象区分「商品」「商品-在庫」
                                    e.NextCtrl = this.tNedit_GoodsMGroup;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_WarehouseCode;
                                }
                            }

                            break;
                        }

                        // 入力値チェック
                        MakerUMnt makerUMnt;

                        int status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt());

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || makerUMnt == null || (makerUMnt != null && makerUMnt.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 結果を画面に設定
                            this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                            this.uLabel_GoodsMakerName.Text = makerUMnt.MakerName;

                            // 設定値を保存
                            this._tmpGoodsMakerCd = makerUMnt.GoodsMakerCd;
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tNedit_GoodsMakerCd.SetInt(this._tmpGoodsMakerCd);

                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件でメーカーコードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_GoodsMakerCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                            if ((ExtractInfo.DisplayDivState)this.tComboEditor_DisplayDiv.SelectedItem.DataValue == ExtractInfo.DisplayDivState.New
                                && (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.Goods)
                            {
                                // 新規、商品
                                e.NextCtrl = this.tEdit_GoodsNo;
                            }
                            else if ((ExtractInfo.DisplayDivState)this.tComboEditor_DisplayDiv.SelectedItem.DataValue == ExtractInfo.DisplayDivState.Update
                                &&
                                ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.Goods
                                || (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue == ExtractInfo.TargetDivState.GoodsStock)
                                )
                            {
                                // 修正登録、対象区分「商品」「商品-在庫」
                                e.NextCtrl = this.tNedit_GoodsMGroup;
                            }
                            else
                            {
                                e.NextCtrl = this.tEdit_WarehouseCode;
                            }


                        }

                        break;
                        #endregion
                    }
                // 商品中分類
                case "tNedit_GoodsMGroup":
                    {
                        #region 商品中分類
                        // 入力無し
                        if (this.tNedit_GoodsMGroup.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpGoodsMGroup = 0;
                            this.uLabel_GoodsMGroupName.Text = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_GoodsMGroup.GetInt() == this._tmpGoodsMGroup)
                        {
                            if (e.NextCtrl == this.uButton_GoodsMGroupGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                e.NextCtrl = this.tEdit_GoodsNo;
                            }

                            break;
                        }

                        // 入力値チェック
                        GoodsGroupU goodsGroupU;

                        int status = this._goodsGroupUAcs.Search(out goodsGroupU, this._enterpriseCode, this.tNedit_GoodsMGroup.GetInt());

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || goodsGroupU == null || (goodsGroupU != null && goodsGroupU.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 結果を画面に設定
                            this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
                            this.uLabel_GoodsMGroupName.Text = goodsGroupU.GoodsMGroupName;

                            // 設定値を保存
                            this._tmpGoodsMGroup = goodsGroupU.GoodsMGroup;
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tNedit_GoodsMGroup.SetInt(this._tmpGoodsMGroup);

                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件で商品中分類コードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_GoodsMGroupGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                            e.NextCtrl = this.tEdit_GoodsNo;
                        }

                        break;
                        #endregion
                    }
                // 倉庫
                case "tEdit_WarehouseCode":
                    {
                        #region 倉庫コード
                        // 入力無し
                        if (this.tEdit_WarehouseCode.DataText == string.Empty)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpWareHouseCode = string.Empty;
                            this.uLabel_WareHouseName.Text = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tEdit_WarehouseCode.DataText == this._tmpWareHouseCode)
                        {
                            if (e.NextCtrl == this.uButton_WarehouseCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                e.NextCtrl = this.tEdit_GoodsNo;
                            }

                            break;
                        }

                        // 入力値チェック
                        Warehouse warehouse;

                        int status = this._warehouseAcs.Read(out warehouse, this._enterpriseCode, this._sectionCode, this.tEdit_WarehouseCode.DataText);

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || warehouse == null || (warehouse != null && warehouse.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 結果を画面に設定
                            this.tEdit_WarehouseCode.Text = warehouse.WarehouseCode.TrimEnd(); // ADD 2009/02/12
                            this.uLabel_WareHouseName.Text = warehouse.WarehouseName;

                            // 設定値を保存
                            this._tmpWareHouseCode = warehouse.WarehouseCode.TrimEnd();
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tEdit_WarehouseCode.DataText = this._tmpWareHouseCode.TrimEnd();

                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件で倉庫コードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_BLGoodsCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                            e.NextCtrl = this.tEdit_GoodsNo;
                        }

                        break;
                        #endregion
                    }
                // BLコード
                case "tNedit_BLGoodsCode":
                    {
                        #region BLコード
                        // 入力無し
                        if (this.tNedit_BLGoodsCode.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpBLGoodsCode = 0;
                            this.uLabel_BLGoodsCodeName.Text = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_BLGoodsCode.GetInt() == this._tmpBLGoodsCode)
                        {
                            if (e.NextCtrl == this.uButton_BLGoodsCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                //e.NextCtrl = this.tEdit_EmployeeCode; // DEL 2009/03/06
                                e.NextCtrl = this._detailGrid.uGrid_Details; // ADD 2009/03/06
                            }

                            //--- ADD 2010/09/07 ---------->>>>>
                            if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                            //--- ADD 2010/09/07 ----------<<<<<

                            break;
                        }

                        // 入力値チェック
                        BLGoodsCdUMnt blGoodsCdUMnt;

                        int status = this._blGoodsCdAcs.Read(out blGoodsCdUMnt, this._enterpriseCode, this.tNedit_BLGoodsCode.GetInt());

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || blGoodsCdUMnt == null || (blGoodsCdUMnt != null && blGoodsCdUMnt.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 結果を画面に設定
                            this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
                            this.uLabel_BLGoodsCodeName.Text = blGoodsCdUMnt.BLGoodsHalfName;

                            // 設定値を保存
                            this._tmpBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;

                            //--- ADD 2010/09/07 ---------->>>>>
                            if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                            //--- ADD 2010/09/07 ----------<<<<<
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tNedit_BLGoodsCode.SetInt(this._tmpBLGoodsCode);

                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件でBLコードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_BLGoodsCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                            //e.NextCtrl = this.tEdit_EmployeeCode; // DEL 2009/03/06
                            e.NextCtrl = this._detailGrid.uGrid_Details; // ADD 2009/03/06
                        }

                        break;
                        #endregion
                    }
                // 管理拠点
                case "tEdit_SectionCode":
                    {
                        #region 管理拠点コード
                        // 入力無し
                        if (this.tEdit_SectionCode.DataText == string.Empty)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpSectionCode = string.Empty;
                            this.uLabel_SectionName.Text = string.Empty;


                            break;
                        }

                        // 入力変更なし
                        if (this.tEdit_SectionCode.DataText == this._tmpSectionCode)
                        {
                            if (e.NextCtrl == this.uButton_SectionCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                //e.NextCtrl = this.tEdit_EmployeeCode; // DEL 2009/03/06
                                e.NextCtrl = this._detailGrid.uGrid_Details; // ADD 2009/03/06
                            }

                            //--- ADD 2010/09/07 ---------->>>>>
                            if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                            //--- ADD 2010/09/07 ----------<<<<<
                            break;
                        }

                        // 入力値チェック
                        SecInfoSet secInfoSet;

                        int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this.tEdit_SectionCode.DataText);

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || secInfoSet == null || (secInfoSet != null && secInfoSet.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 結果を画面に設定
                            this.tEdit_SectionCode.Text = secInfoSet.SectionCode.TrimEnd(); // ADD 2009/02/12
                            this.uLabel_SectionName.Text = secInfoSet.SectionGuideSnm;

                            // 設定値を保存
                            this._tmpSectionCode = secInfoSet.SectionCode.TrimEnd();

                            //--- ADD 2010/09/07 ---------->>>>>
                            if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                            {
                                this.Search();
                                e.NextCtrl = null;
                            }
                            //--- ADD 2010/09/07 ----------<<<<<
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tEdit_SectionCode.DataText = this._tmpSectionCode.TrimEnd();

                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件で管理拠点コードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_SectionCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                            //e.NextCtrl = this.tEdit_EmployeeCode; // DEL 2009/03/06
                            e.NextCtrl = this._detailGrid.uGrid_Details; // ADD 2009/03/06
                        }

                        break;
                        #endregion
                    }
                //--- ADD 2010/09/07 ---------->>>>>
                // BLコードガイド
                case "uButton_BLGoodsCdGuide":
                // 管理拠点ガイド
                case "uButton_SectionCdGuide":
                    {
                        if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                        {
                            this.Search();
                            e.NextCtrl = null;
                        }
                        break;
                    }
                //--- ADD 2010/09/07 ----------<<<<<
                // 入力担当
                case "tEdit_EmployeeCode":
                    {
                        #region 入力担当コード
                        // 入力無し
                            if (this.tEdit_EmployeeCode.DataText == string.Empty)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpEmployeeCode = string.Empty;
                            this.uLabel_EmployeeName.Text = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tEdit_EmployeeCode.DataText == this._tmpEmployeeCode.TrimEnd())
                        {
                            if (e.NextCtrl == this.uButton_EmployeeCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                //e.NextCtrl = this._detailGrid.uGrid_Details; // DEL 2009/03/06
                                e.NextCtrl = this.tNedit_GoodsMakerCd; // ADD 2009/03/06
                            }

                            break;
                        }

                        // 入力値チェック
                        Employee employee;

                        int status = this._employeeAcs.Read(out employee, this._enterpriseCode, this.tEdit_EmployeeCode.DataText);

                        //--- ADD 2010/08/11 ---------->>>>>
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL || employee == null || (employee != null && employee.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0))
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        //--- ADD 2010/08/11 ---------->>>>>

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 結果を画面に設定
                            this.tEdit_EmployeeCode.Text = employee.EmployeeCode.TrimEnd();
                            this.uLabel_EmployeeName.Text = employee.Name;

                            // 設定値を保存
                            this._tmpEmployeeCode = employee.EmployeeCode.TrimEnd();
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tEdit_EmployeeCode.DataText = this._tmpEmployeeCode.TrimEnd();

                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件で入力担当コードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_EmployeeCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                            //e.NextCtrl = this._detailGrid.uGrid_Details; // DEL 2009/03/06
                            e.NextCtrl = this.tNedit_GoodsMakerCd; // ADD 2009/03/06
                        }

                        break;
                        #endregion
                    }
                    // グリッド
                case "uGrid_Details":
                    {
                        if (this._detailGrid.uGrid_Details.Rows.Count == 0)
                        {
                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                // グリッドタブ移動制御
                                this._detailGrid.SetGridTabFocus(ref e);
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (e.NextCtrl.Name == "PMZAI09201UB")
                                {
                                    //e.NextCtrl = this.tEdit_EmployeeCode; // DEL 2009/03/06
                                    // --- ADD 2009/03/06 -------------------------------->>>>>
                                    if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                                        == ExtractInfo.TargetDivState.Goods
                                        || (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                                        == ExtractInfo.TargetDivState.GoodsStock
                                        )
                                    {
                                        e.NextCtrl = this.uButton_BLGoodsCdGuide; 
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uButton_SectionCdGuide; 
                                    }
                                    // --- ADD 2009/03/06 --------------------------------<<<<<
                                }
                                // グリッドシフトタブ移動制御
                                this._detailGrid.SetGridShiftTabFocus(ref e);
                            }
                        }

                        break;
                    }
            }

            // --- ADD 2010/08/11----------------------------------->>>>>
            if (e.NextCtrl is TComboEditor)
            {
                this._preComboEditorValue = ((TComboEditor)e.NextCtrl).Value;
            }
            // --- ADD 2010/08/11-----------------------------------<<<<<

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                case "PMZAI09201UB":
                case "uGrid_Details":
                    {
                        if (this._detailGrid.uGrid_Details.Rows.Count == 0)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = this.tComboEditor_DisplayDiv;
                                }
                                else if (e.Key == Keys.Up)
                                {
                                    e.NextCtrl = this.tEdit_GoodsNo;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    //e.NextCtrl = this.tEdit_EmployeeCode; // DEL 2009/03/06
                                    // --- ADD 2009/03/06 -------------------------------->>>>>
                                    if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                                        == ExtractInfo.TargetDivState.Goods
                                        || (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                                        == ExtractInfo.TargetDivState.GoodsStock
                                        )
                                    {
                                        e.NextCtrl = this.uButton_BLGoodsCdGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uButton_SectionCdGuide;
                                    }
                                    // --- ADD 2009/03/06 --------------------------------<<<<<
                                }
                            }
                        }
                        else
                        {
                            string nextFocusColumn;

                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = null;
                                    this._detailGrid.uGrid_Details.Focus();
                                    ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11

                                    int activationColIndex;
                                    int activationRowIndex;

                                    nextFocusColumn = this._detailGrid.GetNextFocusColumnKey(0, 0, false, out activationColIndex, out activationRowIndex);

                                    if (nextFocusColumn != string.Empty)
                                    {
                                        this._detailGrid.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();

                                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tComboEditor_DisplayDiv;
                                    }
                                }
                                else if (e.Key == Keys.Up)
                                {
                                    // 最終行にフォーカス
                                    e.NextCtrl = null;
                                    this._detailGrid.uGrid_Details.Focus();
                                    ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11

                                    int activationColIndex;
                                    int activationRowIndex;

                                    nextFocusColumn = this._detailGrid.GetNextFocusColumnKey(0, this._detailGrid.uGrid_Details.Rows.Count - 1, false, out activationColIndex, out activationRowIndex);

                                    if (nextFocusColumn != string.Empty)
                                    {
                                        this._detailGrid.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();

                                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_GoodsNo;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = null;
                                    this._detailGrid.uGrid_Details.Focus();
                                    ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11

                                    int activationColIndex;
                                    int activationRowIndex;

                                    nextFocusColumn = this._detailGrid.GetNextFocusColumnKey(this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1, this._detailGrid.uGrid_Details.Rows.Count - 1, true, out activationColIndex, out activationRowIndex);

                                    if (nextFocusColumn != string.Empty)
                                    {
                                        this._detailGrid.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();

                                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        //e.NextCtrl = this.tEdit_EmployeeCode; // DEL 2009/03/06
                                        // --- ADD 2009/03/06 -------------------------------->>>>>
                                        if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                                            == ExtractInfo.TargetDivState.Goods
                                            || (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                                            == ExtractInfo.TargetDivState.GoodsStock
                                            )
                                        {
                                            e.NextCtrl = this.uButton_BLGoodsCdGuide;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_SectionCdGuide;
                                        }
                                        // --- ADD 2009/03/06 --------------------------------<<<<<
                                    }
                                }
                            }
                        }

                        break;
                    }
            }

            //---ADD 2010/08/09---------->>>>>
            // ガイドの設定
            Infragistics.Win.UltraWinToolbars.ButtonTool guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"];
            if (guideButton != null && e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tEdit_EmployeeCode":
                    case "tNedit_GoodsMakerCd":
                    case "tNedit_BLGoodsCode":
                    case "tEdit_WarehouseCode":
                    case "tEdit_SectionCode":
                    case "tNedit_GoodsMGroup":
                        {
                            guideButton.SharedProps.Enabled = true;
                            break;
                        }
                    case "uGrid_Details":
                        break;
                    default:
                        {
                            if (e.NextCtrl.CanFocus && e.NextCtrl.CanSelect)
                            {
                                guideButton.SharedProps.Enabled = false;
                            }
                            break;
                        }
                }
            }
            //---ADD 2010/08/09----------<<<<<
        }
        #endregion

        #region ■ ツールバークリックイベント
        /// <summary>
        /// tToolbarsManager1_ToolClickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        this.CloseWindow();
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // 検索
                        this.Search();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // 保存処理
                        this.Save();
                        break;
                    }
                case "ButtonTool_New":
                    {
                        // クリア処理
                        this.Clear();
                        
                        break;
                    }
                // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                case "ButtonTool_SetUp":
                    {
                        // 最大出力件数の設定処理
                        this.SetUp();

                        break;
                    }
                // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
                // --- ADD 2010/09/11-------------------------------------->>>>>
                case "ButtonTool_Guide":
                    {
                        if (this._detailGrid.ContainsFocus)
                        {
                            // 明細ガイド処理
                            this._detailGrid.ExecuteGuideMain();
                        } else {
                            // 入力担当
                            if (tEdit_EmployeeCode.Focused)
                            {
                                uButton_EmployeeCdGuide_Click_1(sender, e);
                                this.tEdit_EmployeeCode.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_EmployeeCode.Name, this.tEdit_EmployeeCode.Text);
                            } else 
                            // メーカー
                            if (tNedit_GoodsMakerCd.Focused)
                            {
                                uButton_GoodsMakerCdGuide_Click_1(sender, e);
                            } else
                            // ＢＬコード
                            if (tNedit_BLGoodsCode.Focused)
                            {
                                uButton_BLGoodsCdGuide_Click_1(sender, e);
                            } else
                            // 倉庫
                            if (tEdit_WarehouseCode.Focused)
                            {
                                uButton_WarehouseCdGuide_Click_1(sender, e);
                                this.tEdit_WarehouseCode.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_WarehouseCode.Name, this.tEdit_WarehouseCode.Text);
                            } else
                            // 管理拠点
                            if (tEdit_SectionCode.Focused)
                            {
                                uButton_SectionCdGuide_Click_1(sender, e);
                                this.tEdit_SectionCode.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_SectionCode.Name, this.tEdit_SectionCode.Text);
                            } else
                            // 商品中分類
                            if (tNedit_GoodsMGroup.Focused)
                            {
                                uButton_GoodsMGroupGuide_Click_1(sender, e);
                            }
                        }
                        break;
                    }
                // --- ADD 2010/09/11--------------------------------------<<<<<
            }
        }
        #endregion

        #region ■ ガイドクリックイベント
        /// <summary>
        /// メーカーガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMakerCdGuide_Click_1(object sender, EventArgs e)
        {
            MakerUMnt makerUmnt;

            int status = this._detailGrid.ExecuteMakerGuide(out makerUmnt);

            if (status == 0)
            {
                this.tNedit_GoodsMakerCd.SetInt(makerUmnt.GoodsMakerCd);
                this.uLabel_GoodsMakerName.Text = makerUmnt.MakerName;

                // フォーカス
                if ((ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                    == ExtractInfo.TargetDivState.Goods
                    ||
                    (ExtractInfo.TargetDivState)this.tComboEditor_TargetDiv.SelectedItem.DataValue
                    == ExtractInfo.TargetDivState.GoodsStock)
                {
                    // 商品中分類にフォーカス
                    this.tNedit_GoodsMGroup.Focus();
                    ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = true; // ADD 2010/08/11
                }
            }
        }

        /// <summary>
        /// 倉庫ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_WarehouseCdGuide_Click_1(object sender, EventArgs e)
        {
            Warehouse warehouse;

            int status = this._detailGrid.ExecuteWarehouseGuide(out warehouse);

            if (status == 0)
            {
                this.tEdit_WarehouseCode.DataText = warehouse.WarehouseCode.Trim();
                this.uLabel_WareHouseName.Text = warehouse.WarehouseName;

                // フォーカス
                this.tEdit_GoodsNo.Focus();
                ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
            }
        }

        /// <summary>
        /// BLコードガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_BLGoodsCdGuide_Click_1(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt;

            int status = this._detailGrid.ExecuteBLGoodsCodeGuide(out blGoodsCdUMnt);

            if (status == 0)
            {
                this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
                this.uLabel_BLGoodsCodeName.Text = blGoodsCdUMnt.BLGoodsHalfName;

                // フォーカス
                this.tEdit_EmployeeCode.Focus();
                ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = true; // ADD 2010/08/11

                //---ADD 2010/09/07---------->>>>>
                this.Search();
                //---ADD 2010/09/07----------<<<<<
            }
        }

        /// <summary>
        /// 商品中分類コードガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMGroupGuide_Click_1(object sender, EventArgs e)
        {
            GoodsGroupU goodgroupU;

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);

            if (status == 0)
            {
                this.tNedit_GoodsMGroup.SetInt(goodgroupU.GoodsMGroup);
                this.uLabel_GoodsMGroupName.Text = goodgroupU.GoodsMGroupName;

                // フォーカス
                this.tEdit_GoodsNo.Focus();
                ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11
            }
        }

        /// <summary>
        /// 管理拠点ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SectionCdGuide_Click_1(object sender, EventArgs e)
        {
            SecInfoSet secInfoSet;

            int status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

            // 結果反映
            if (status == 0)
            {
                this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;

                // フォーカス
                this.tEdit_EmployeeCode.Focus();
                ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = true; // ADD 2010/08/11

                //---ADD 2010/09/07---------->>>>>
                this.Search();
                //---ADD 2010/09/07----------<<<<<
            }
        }

        /// <summary>
        /// 担当者ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_EmployeeCdGuide_Click_1(object sender, EventArgs e)
        {
            Employee employee;

            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            // 結果反映
            if (status == 0)
            {
                this.tEdit_EmployeeCode.DataText = employee.EmployeeCode.Trim();
                this.uLabel_EmployeeName.Text = employee.Name;

                // フォーカス
                this.tNedit_GoodsMakerCd.Focus();
                ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = true; // ADD 2010/08/11
            }
        }
        #endregion

        #region ■ 抽出条件変更イベント
        // --- ADD 2009/02/03 -------------------------------->>>>>
        /// <summary>
        /// tComboEditor_DisplayDiv_BeforeEnterEditModeイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_DisplayDiv_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            // 変更前のDisplayDivのValueを保持
            this._tmpDisplayDivValue = (int)this.tComboEditor_DisplayDiv.SelectedItem.DataValue;
        }
        // --- ADD 2009/02/03 --------------------------------<<<<<

        /// <summary>
        /// tComboEditor_DisplayDiv_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_DisplayDiv_ValueChanged(object sender, EventArgs e)
        {
            // --- 2010/08/11 ---------->>>>>
            bool inputErrorFlg = true;
            foreach (Infragistics.Win.ValueListItem item in this.tComboEditor_DisplayDiv.Items)
            {
                if (item.DataValue == this.tComboEditor_DisplayDiv.Value)
                {
                    inputErrorFlg = false;
                    break;
                }
            }
            if (inputErrorFlg)
            {
                return;
            }
            // --- 2010/08/11 ----------<<<<<

            if (!this._initializeFinish)
            {
                // 画面初期化中は処理しない
                return;
            }

            // --- ADD 2009/02/03 -------------------------------->>>>>
            // クリア処理
            // 変更有無チェック
            bool isChanged = this.CompareGridDataWithOriginal();

            if (isChanged)
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
                    this.tComboEditor_DisplayDiv.ValueChanged -= this.tComboEditor_DisplayDiv_ValueChanged;
                    this.tComboEditor_DisplayDiv.Value = this._tmpDisplayDivValue;
                    this.tComboEditor_DisplayDiv.ValueChanged += this.tComboEditor_DisplayDiv_ValueChanged;
                    return;
                }
            }
            // --- ADD 2009/02/03 --------------------------------<<<<<

            // 対象区分
            // 選択値を保存
            object tmpObj;

            if (this.tComboEditor_TargetDiv.SelectedItem != null)
            {
                tmpObj = this.tComboEditor_TargetDiv.SelectedItem.DataValue;
            }
            else
            {
                tmpObj = 0;
            }

            this.tComboEditor_TargetDiv.ResetItems();

            this.SetTComboEditor_TargetDiv();

            this.tComboEditor_TargetDiv.ValueChanged -= this.tComboEditor_TargetDiv_ValueChanged; // ADD 2009/02/03
            this.tComboEditor_TargetDiv.Value = tmpObj;
            this.tComboEditor_TargetDiv.ValueChanged += this.tComboEditor_TargetDiv_ValueChanged; // ADD 2009/02/03

            if (this.tComboEditor_TargetDiv.SelectedItem == null)
            {
                this.tComboEditor_TargetDiv.SelectedIndex = 0;
            }

            // 出力指定
            this.SetTComboEditor_OutputDivVisible();

            // 抽出条件設定
            SetExtractItemSettings();

            // グリッド部の初期化
            this._detailGrid.Initialize(); // ADD 2009/02/03
        }

        // --- ADD 2009/02/03 -------------------------------->>>>>
        /// <summary>
        /// tComboEditor_TargetDiv_BeforeEnterEditModeイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_TargetDiv_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            // 変更前のTargetDivのValueを保持
            this._tmpTargetDivValue = (int)this.tComboEditor_TargetDiv.SelectedItem.DataValue;
        }
        // --- ADD 2009/02/03 --------------------------------<<<<<

        /// <summary>
        /// tComboEditor_TargetDiv_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_TargetDiv_ValueChanged(object sender, EventArgs e)
        {
            // --- 2010/08/11 ---------->>>>>
            bool inputErrorFlg = true;
            foreach (Infragistics.Win.ValueListItem item in this.tComboEditor_TargetDiv.Items)
            {
                if (item.DataValue == this.tComboEditor_TargetDiv.Value)
                {
                    inputErrorFlg = false;
                    break;
                }
                
            }
            if (inputErrorFlg)
            {
                return;
            }
            // --- 2010/08/11 ----------<<<<<

            if (!this._initializeFinish)
            {
                // 画面初期化中は処理しない
                return;
            }

            // --- ADD 2009/02/03 -------------------------------->>>>>
            // クリア処理
            // 変更有無チェック
            bool isChanged = this.CompareGridDataWithOriginal();

            if (isChanged)
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
                    this.tComboEditor_TargetDiv.ValueChanged -= this.tComboEditor_TargetDiv_ValueChanged;
                    this.tComboEditor_TargetDiv.Value = this._tmpTargetDivValue;
                    this.tComboEditor_TargetDiv.ValueChanged += this.tComboEditor_TargetDiv_ValueChanged;
                    return;
                }
            }
            // --- ADD 2009/02/03 --------------------------------<<<<<

            if (this.tComboEditor_TargetDiv.SelectedItem == null)
            {
                // 選択値が無い場合も処理しない(表示区分変更イベントで、元の選択項目が無い場合)
                return;
            }

            // 出力指定
            this.SetTComboEditor_OutputDivVisible();

            // 抽出条件設定
            SetExtractItemSettings();

            // グリッド部の初期化
            this._detailGrid.Initialize(); // ADD 2009/02/03
        }
        #endregion

        #region ■ 削除済みデータ表示ボタンクリックイベント
        /// <summary>
        /// 削除済みデータ表示ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteIndication_CheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            this._detailGrid.DeleteIndicationSetting(this.DeleteIndication_CheckEditor.Checked);
        }
        #endregion

        // --- ADD 2009/02/04 -------------------------------->>>>>
        #region ■ 検索処理キャンセルボタンクリックイベント
        private void SearchCancelButton_Click(object sender, EventArgs e)
        {
            this._goodsStockAcs.CancelFlg = true;
        }
        #endregion
        // --- ADD 2009/02/04 -------------------------------->>>>>

        #region ■ 初期フォーカスタイマ
        /// <summary>
        /// 初期フォーカス設定タイマ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitialFocusTimer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tComboEditor_DisplayDiv.Focus();
            ((Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Guide"]).SharedProps.Enabled = false; // ADD 2010/08/11

            //-------DEL BY 凌小青 on 2012/09/19 for Redmine#32370------>>>>>>
            //// XMLデータ読込
            //this._detailGrid.LoadStateXmlData();
            //-------DEL BY 凌小青 on 2012/09/19 for Redmine#32370------<<<<<<

            // グリッドの表示、非表示設定を再読込み
            this._detailGrid.SetGridSettings();

            // 削除済みデータ表示の制御
            this._detailGrid.DeleteIndicationSetting(this.DeleteIndication_CheckEditor.Checked);

            this.InitialFocusTimer.Enabled = false;
        }
        #endregion 

        //---ADD 2010/08/11---------->>>>>
        /// <summary>
        /// コードからの選択を可能へ変更する
        /// </summary>
        /// <param name="name"></param>
        private void setTComboEditorByName(string name)
        {
            TComboEditor control = (TComboEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

            bool inputErrorFlg = true;
            foreach (Infragistics.Win.ValueListItem item in control.Items)
            {
                if (item.DataValue == control.Value)
                {
                    inputErrorFlg = false;
                    break;
                }
            }

            if (inputErrorFlg)
            {
                control.Value = this._preComboEditorValue;
            }
            else
            {
                this._preComboEditorValue = control.Value;
            }
        }

        /// <summary>
        /// キー押下イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI09201UA_KeyDown(object sender, KeyEventArgs e)
        {
            this._detailGrid.PMZAI09201UB_KeyDown(sender, e);
        }

        //---ADD 2010/08/11----------<<<<<

        #endregion
    }
}