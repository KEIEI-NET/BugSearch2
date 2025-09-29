//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタ
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2010/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 修 正 日  2010/09/08  修正内容 : #14404の対応
//----------------------------------------------------------------------------//
// 管理番号10704766-00             作成担当 : 李占川
// 修 正 日  2011/08/03  修正内容 : NSユーザー改良要望一覧連番984の対応
//----------------------------------------------------------------------------//
// 管理番号10704766-00              作成担当 : caohh
// 修 正 日  2011/08/04  修正内容 : NSユーザー改良要望一覧連番513、520の対応
//----------------------------------------------------------------------------//
// 管理番号10704766-00              作成担当 : wangf
// 修 正 日  2011/08/29  修正内容 : NSユーザー改良要望一覧連番1016の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛中華
// 修 正 日  2011/11/28  修正内容 : Redmine#8179 デフォルト選択値の変更
//----------------------------------------------------------------------------//
// 管理番号 10806793-00  作成担当 : 田建委
// 修 正 日  2012/12/13  修正内容 : 2013/03/13配信分  Redmine#33835
//                                  出荷回数を追加する対応
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : huangt
// 修 正 日  2014/01/15  修正内容 : Redmine#40998 貸出数の変更を可能にするように修正
//----------------------------------------------------------------------------//
// 管理番号 11770032-00  作成担当 : 譚洪
// 修 正 日 K2021/05/17  修正内容 : BLINCIDENT-3025 現在数が0になる対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Infragistics.Win.UltraWinGrid; // ADD 2012/12/13 田建委 Redmine#33835
using Infragistics.Win; // ADD 2012/12/13 田建委 Redmine#33835

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫マスタフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタのフォームクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2010/08/11</br>
    /// <br>Update Note: 2010/09/08 曹文傑 #14404の対応。</br>
    /// <br>Update Note: 2011/08/03 李占川 NSユーザー改良要望一覧連番984の対応。</br>
    /// <br>Update Note: 2011/08/04 caohh NSユーザー改良要望一覧連番513、520の対応。</br>
    /// <br>Update Note: 2011/08/29 wangf NSユーザー改良要望一覧連番1016の対応。</br>
    /// <br>Update Note: 2011/11/28 葛中華 Redmine#8179 デフォルト選択値の変更。</br>
    /// <br>Update Note: 2012/12/13 田建委</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>             Redmine#33835 出荷回数を追加する対応</br>
    /// <br>Update Note: K2021/05/17 譚洪</br>
    /// <br>管理番号   : 11770032-00</br>
    /// <br>           : BLINCIDENT-3025 現在数が0になる対応</br>
    /// </remarks>
    public partial class PMKHN09491UA : Form
    {
        // ===================================================================================== //
        // 定数
        // ===================================================================================== //
        #region ■ Private Const
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";						// 終了
        private const string TOOLBAR_NEWBUTTON_KEY = "ButtonTool_New";							// 新規
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";							// 保存
        private const string TOOLBAR_DELETEBUTTON_KEY = "ButtonTool_Delete";						// 削除
        private const string TOOLBAR_COMPLETEDELETEBUTTON_KEY = "ButtonTool_CompleteDelete";		 // 完全削除
        private const string TOOLBAR_REVIVEBUTTON_KEY = "ButtonTool_Revive";						// 復活
        private const string TOOLBAR_RENEWALBUTTON_KEY = "ButtonTool_Renewal";						// 最新情報
        private const string ct_Tool_LoginEmployee = "LabelTool_LoginTitle";				// ログイン担当者タイトル
        private const string ct_Tool_LoginEmployeeName = "LabelTool_LoginName";		     // ログイン担当者名称
        // --- ADD 2010/09/08 ----->>>>>
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";		         // ガイド
        // --- ADD 2010/09/08 -----<<<<<

        // ユーザーガイド区分値（部品管理区分１）
        private const int ct_UserGdDiv_PartsManagementDivide1 = 72;
        // ユーザーガイド区分値（部品管理区分２）
        private const int ct_UserGdDiv_PartsManagementDivide2 = 73;

        private const string CT_PGID = "PMKHN09490U";
        private const string CT_PGNM = "在庫マスタ";

        private const string NEW_INPUT_TITLE = "新規";
        private const string UPDATE_INPUT_TITLE = "更新";
        private const string DELETE_INPUT_TITLE = "削除";

        //----- ADD 2012/12/13 田建委 Redmine#33835 ----------->>>>>
        // グリッド列
        private const string COLUMN_TITLE = "Title1";   　 //子列タイトル
        private const string COLUMN_SALESTIMES = "SalesTimes";  //出荷回数

        private DateTime _thisYearMonth;
        private TotalDayCalculator _totalDayCalculator = null; //締日取得部品
        private DateTime _stMonth;
        private DateTime _edMonth;
        private int _stAddUpDate;
        private int _edAddUpDate;
        //----- ADD 2012/12/13 田建委 Redmine#33835 -----------<<<<<


        // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- >>>>>
        //入力不可の背景色
        private readonly Color BACKCOLOR_DISABLE = Color.FromArgb(224, 224, 224);
        //入力可の背景色
        private readonly Color BACKCOLOR_ENABLE = Color.FromArgb(255, 255, 255);
        // 前回貸出数
        private double _preShipmentCnt = 0;
        // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- <<<<<
        #endregion ■ Private Const

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructors
        /// <summary>
        /// 在庫マスタフォームクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫マスタのフォームクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        public PMKHN09491UA()
        {
            InitializeComponent();

            try
            {
                this._stockMstAcs = StockMstAcs.GetInstance();
                this._dateGet = DateGetAcs.GetInstance();
                //-----------------------------------------------------------------------------
                // 各種オブジェクトインスタンス生成
                //-----------------------------------------------------------------------------
                this._goodsAcs = new GoodsAcs();
                this._goodsAcs.IsLocalDBRead = false;

                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                if (LoginInfoAcquisition.Employee != null)
                {
                    this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                }
            }
            catch
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                this.Text + "画面初期化処理に失敗しました。",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }
        #endregion

        //======================================================================================= //
        //  内部メンバー
        //======================================================================================= //
        #region ■Private Members
        private string _enterpriseCode;
        private ImageList _imageList16;
        private string _preGoodsNo = string.Empty;
        private Int32 _preMakerCode = 0;
        private string _preWarehouseCode = string.Empty;
        private double _priceValue = 0;
        private double _shipmentPosCountOrigin;
        private DateTime updateTimeDt = new DateTime();

        // -------------------------------------------------------------------------------
        #region < 各種オブジェクト >
        /// <summary>商品入力アクセスクラス</summary>
        GoodsAcs _goodsAcs;
        /// <summary>変更前在庫リストバッファ</summary>
        private List<Stock> _prevStockList;
        /// <summary>ユーザーガイドマスタ アクセスクラス</summary>
        private UserGuideAcs _userGuideAcs;
        /// <summary>自拠点コード</summary>
        private string _loginSectionCode = "";
        /// <summary>拠点アクセスクラス</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        /// <summary>仕入先アクセスクラス</summary>
        private SupplierAcs _supplierAcs;
        /// <summary>倉庫アクセスクラス</summary>
        private WarehouseAcs _warehouseAcs;
        /// <summary>メーカーマスタ　アクセスクラス</summary>
        private MakerAcs _makerAcs;
        /// <summary>在庫マスタ　アクセスクラス</summary>
        private StockMstAcs _stockMstAcs;
        /// <summary>日付取得部品　アクセスクラス</summary>
        private DateGetAcs _dateGet;
        private GoodsUnitData _goodsUnitData; // ADD 2010/09/01
        private Stock _stockBak; // ADD 2010/09/06
        // -- add wangf 2011/08/29 ---------->>>>>
        /// <summary>在庫管理全体設定設定アクセスクラス</summary>
        private StockMngTtlStAcs _stockMngTtlStAcs;
        // -- add wangf 2011/08/29 ----------<<<<<

        #endregion

        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ◆Private Methods
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// <br>Update Note: 2012/12/13 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33835 出荷回数を追加する対応</br>
        /// </remarks>
        private void PMKHN09491UA_Load(object sender, EventArgs e)
        {
            // 画面を構築
            this.ScreenInitialSetting();

            //-----------------------------------------------------------------------------
            // 新規
            //-----------------------------------------------------------------------------
            this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;

            this.ChangeEditMode(3);

            this.tComboEditor_StockDiv.SelectedIndex = 0;
            this.tNedit_PartsManagementDivide1.SetInt(0);
            this.tNedit_PartsManagementDivide2.SetInt(0);
            this.tNedit_MinimumStockCnt.SetInt(0);
            this.tNedit_MaximumStockCnt.SetInt(0);
            this.tNedit_SalesOrderCount.SetInt(0);
            this.tNedit_SupplierStock.SetInt(0);
            this.tNedit_ArrivalCnt.SetInt(0);
            this.tNedit_ShipmentCnt.SetInt(0);
            this.tNedit_AcpOdrCount.SetInt(0);
            this.tNedit_MovingSupliStock.SetInt(0);
            this.tNedit_ShipmentPosCnt.SetInt(0);

            this.Initial_timer.Enabled = true;
            // --- ADD 2010/09/01 --- >>>>>
            // 管理区分1、2の名称を初期設定
            bool readStatus;
            int code;
            string name;

            // 管理区分1の名称読み込み
            readStatus = ReadUserGuide(ct_UserGdDiv_PartsManagementDivide1, tNedit_PartsManagementDivide1.GetInt(), out code, out name);

            // 名称を更新
            if (readStatus)
            {
                tEdit_PartsManagementDivide1Name.Text = name;
            }
            else
            {
                tEdit_PartsManagementDivide1Name.Text = string.Empty;
            }

            // 管理区分2の名称読み込み
            readStatus = ReadUserGuide(ct_UserGdDiv_PartsManagementDivide2, tNedit_PartsManagementDivide2.GetInt(), out code, out name);

            // 名称を更新
            if (readStatus)
            {
                tEdit_PartsManagementDivide2Name.Text = name;
            }
            else
            {
                tEdit_PartsManagementDivide2Name.Text = string.Empty;
            }
            // --- ADD 2010/09/01 --- <<<<<

            //----- ADD 2012/12/13 田建委 Redmine#33835 -------->>>>>
            // 締日取得部品
            this._totalDayCalculator = TotalDayCalculator.GetInstance();
            this._totalDayCalculator.InitializeHisMonthly();

            // 現在処理年月取得処理
            GetThisYearMonth();

            CreateGrid();

            SetGridLayout();
            //----- ADD 2012/12/13 田建委 Redmine#33835 --------<<<<<
        }

        /// <summary>
        ///	画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期設定を処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {

            // イメージリスト設定
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;

            //----------------------------
            // ツールアイコン設定
            //----------------------------
            // 終了
            this.tToolsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // 新規
            this.tToolsManager_MainMenu.Tools[TOOLBAR_NEWBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            // 保存
            this.tToolsManager_MainMenu.Tools[TOOLBAR_SAVEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            // 削除
            this.tToolsManager_MainMenu.Tools[TOOLBAR_DELETEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            // 完全削除
            this.tToolsManager_MainMenu.Tools[TOOLBAR_COMPLETEDELETEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            // 復活
            this.tToolsManager_MainMenu.Tools[TOOLBAR_REVIVEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODIFY;
            // 最新情報
            this.tToolsManager_MainMenu.Tools[TOOLBAR_RENEWALBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            // ログイン担当者
            this.tToolsManager_MainMenu.Tools[ct_Tool_LoginEmployee].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // --- ADD 2010/09/08 ----->>>>>
            // ガイド
            this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            // --- ADD 2010/09/08 -----<<<<<

            // 担当者表示
            if (LoginInfoAcquisition.Employee != null)
            {
                this.tToolsManager_MainMenu.Tools[ct_Tool_LoginEmployeeName].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            // アイコン設定
            this._imageList16 = IconResourceManagement.ImageList16;

            this.GoodsMakerGuide_uButton.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_WarehouseGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_SectionGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_SupplierGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_PartsManagementDivide1.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_PartsManagementDivide2.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// フォカス変更時にイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォカス変更時に発生します。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2010/08/11</br> 
        /// <br>Update Note: 2010/09/01 楊明俊 #14025の4の対応。</br>
        /// <br>Update Note: 2010/09/08 曹文傑 #14404の対応。</br>
        /// <br>Update Note: 2011/08/03 李占川 NSユーザー改良要望一覧連番984の対応。</br>
        /// <br>Update Note: 2012/12/13 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33835 出荷回数を追加する対応</br>
        /// </remarks> 
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            int status = 0;
            bool changedGoods = false;

            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            //----- ADD 2012/12/13 田建委 Redmine#33835 ---------->>>>>
            if (e.NextCtrl.Name == "uGrid_SalesTimes")
            {
                e.NextCtrl = e.PrevCtrl;
                return;
            }
            //----- ADD 2012/12/13 田建委 Redmine#33835 ----------<<<<<

            #region フォーカス移動
            if (!e.ShiftKey)
            {
                if (e.Key == Keys.Right)
                {
                    if (e.PrevCtrl == this.tEdit_GoodsNo
                        || e.PrevCtrl == this.GoodsMakerGuide_uButton
                        || e.PrevCtrl == this.tNedit_StockUnitPriceFl
                        //|| e.PrevCtrl == this.tNedit_SalesOrderUnit // DEL 2012/12/13 田建委 Redmine#33835
                        //----- ADD 2012/12/13 田建委 Redmine#33835 ---------->>>>>
                        || e.PrevCtrl == this.tNedit_StockUnitPriceRate // 棚卸評価率
                        || e.PrevCtrl == this.tNedit_StockUnitPriceFl // 棚卸評価単価
                        || e.PrevCtrl == this.tNedit_SupplierStock // 仕入在庫数
                        //----- ADD 2012/12/13 田建委 Redmine#33835 ----------<<<<<
                        || e.PrevCtrl == this.tNedit_SalesOrderCount
                        || e.PrevCtrl == this.uButton_SupplierGuide
                        || e.PrevCtrl == this.tDateEdit_lastSalesDate
                        || e.PrevCtrl == this.tDateEdit_lastStockDate
                        || e.PrevCtrl == this.uButton_PartsManagementDivide1
                        || e.PrevCtrl == this.uButton_PartsManagementDivide2
                        || e.PrevCtrl == this.tEdit_StockNote1
                        || e.PrevCtrl == this.tEdit_StockNote2)
                    {
                        e.NextCtrl = null;
                        return;
                    }
                }
            }
            
            #endregion

            #region 項目処理
            switch (e.PrevCtrl.Name)
            {
                // 倉庫ボタン
                case "uButton_WarehouseGuide":
                    {
                        #region 倉庫ボタン
                        if (!e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tEdit_GoodsNo;
                                    }
                                    break;
                            }
                        }
                        #endregion
                        break;
                    }
                

                // 棚卸評価率
                case "tNedit_StockUnitPriceRate":
                    {
                        #region 棚卸評価率
                        if (this.tNedit_StockUnitPriceRate.GetValue() == 0)
                        {
                            return;
                        }

                        // 棚卸評価率
                        double priceRate = this.tNedit_StockUnitPriceRate.GetValue();

                        this.tNedit_StockUnitPriceFl.SetValue(priceRate * this._priceValue / 100);

                        #endregion
                        break;
                    }

                // 管理拠点コード
                case "tEdit_SectionCode":
                    {
                        # region [拠点]
                        bool readStatus = false;
                        if (!string.IsNullOrEmpty(tEdit_SectionCode.Text.Trim()))
                        {
                            string code;
                            string name;

                            this.tEdit_SectionCode.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_SectionCode.Name, this.tEdit_SectionCode.Text);

                            // 拠点読み込み
                            readStatus = ReadSection(tEdit_SectionCode.Text, out code, out name);

                            // コード・名称を更新
                            tEdit_SectionCode.Text = code;
                            tEdit_SectionName.Text = name;
                        }
                        else
                        {
                            this.tEdit_SectionName.Text = string.Empty;

                            readStatus = true;
                        }

                        if (readStatus == true)
                        {
                            if (!e.ShiftKey)
                            {
                                // NextCtrl制御
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SectionGuide;
                                            }
                                            else
                                            {
                                                if (this.tEdit_GoodsNo.Enabled == false)
                                                {
                                                    e.NextCtrl = this.tEdit_WarehouseShelfNo;
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
                                "拠点が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            this.tEdit_SectionCode.Text = string.Empty;
                            e.NextCtrl = this.tEdit_SectionCode;

                        }
                        // --- ADD 2010/09/08 ----->>>>>
                        if (e.NextCtrl != null)
                        {
                            if (e.NextCtrl == this.tEdit_StockNote2)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        // --- ADD 2010/09/08 -----<<<<<
                        # endregion
                        break;
                    }

                // 最高在庫数
                case "tNedit_MaximumStockCnt":
                    {
                        # region [最高在庫数]
                        if (tNedit_MinimumStockCnt.GetValue() > tNedit_MaximumStockCnt.GetValue())
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "最低在庫数≦最高在庫数となるように入力して下さい。",
                                -1,
                                MessageBoxButtons.OK);
                        }
                        # endregion
                        break;
                    }
                // 発注ロット
                case "tNedit_SalesOrderUnit":
                    {
                        # region [発注ロット]
                        if (tNedit_SalesOrderUnit.GetValue() > tNedit_MaximumStockCnt.GetValue())
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "発注ロット≦最高在庫数となるように入力して下さい。",
                                -1,
                                MessageBoxButtons.OK);
                        }
                        # endregion
                        break;
                    }
                // 発注先コード
                case "tNedit_SupplierCd":
                    {
                        # region [発注先（仕入先）]
                        bool readStatus;
                        if (tNedit_SupplierCd.GetInt() == 0)
                        {
                            readStatus = true;
                            this.tEdit_SupplierName.Text = string.Empty;
                        }
                        else
                        {
                            int code;
                            string name;

                            // 仕入先読み込み
                            readStatus = ReadSupplier(tNedit_SupplierCd.GetInt(), out code, out name);

                            // コード・名称を更新
                            tNedit_SupplierCd.SetInt(code);
                            tEdit_SupplierName.Text = name;
                        }

                        if (readStatus == true)
                        {
                            if (!e.ShiftKey)
                            {
                                // NextCtrl制御
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {

                                            if (this.tNedit_SupplierCd.GetInt() == 0)
                                            {
                                                e.NextCtrl = this.uButton_SupplierGuide;
                                            }
                                            else
                                            {
                                                //e.NextCtrl = this.tDateEdit_lastSalesDate;     // DEL huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正
                                                // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- >>>>>
                                                if (this.tNedit_ShipmentCnt.Enabled)
                                                {
                                                    e.NextCtrl = this.tNedit_ShipmentCnt;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tDateEdit_lastSalesDate;
                                                }
                                                // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- <<<<<
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
                                "発注先が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            this.tNedit_SupplierCd.Text = string.Empty;
                            e.NextCtrl = this.uButton_SupplierGuide;

                        }
                        # endregion
                        break;
                    }
                // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- >>>>>
                case "uButton_SupplierGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_ShipmentCnt.Enabled)
                                        {
                                            e.NextCtrl = this.tNedit_ShipmentCnt;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tDateEdit_lastSalesDate;
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "tNedit_ShipmentCnt":
                    {
                        if (!e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tDateEdit_lastSalesDate;
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            e.NextCtrl = this.uButton_SupplierGuide;
                        }
                        break;
                    }
                case "tDateEdit_lastSalesDate":
                    {
                        if (e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_ShipmentCnt.Enabled)
                                        {
                                            e.NextCtrl = this.tNedit_ShipmentCnt;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_SupplierGuide;
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "tDateEdit_lastStockDate":
                    {
                        if (!e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_PartsManagementDivide1;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- <<<<<

                // 管理区分１
                case "tNedit_PartsManagementDivide1":
                    {
                        # region [管理区分１]
                        bool readStatus;
                        // --- DEL 2010/09/01 --- >>>>>
                        //if (tNedit_PartsManagementDivide1.GetInt() != 0)
                        //{
                        // --- DEL 2010/09/01 --- <<<<<
                        int code;
                        string name;

                        // ユーザーガイド読み込み
                        readStatus = ReadUserGuide(ct_UserGdDiv_PartsManagementDivide1, tNedit_PartsManagementDivide1.GetInt(), out code, out name);

                        // コード・名称を更新
                        // (※マスタ未登録コードでもＯＫ)
                        if (readStatus)
                        {
                            tEdit_PartsManagementDivide1Name.Text = name;
                            // --- ADD 2010/09/01 --- >>>>>
                            if ("".Equals(this.tNedit_PartsManagementDivide1.DataText))
                            {
                                this.tNedit_PartsManagementDivide1.SetInt(0);
                            }
                            // --- ADD 2010/09/01 --- <<<<<
                        }
                        else
                        {
                            // --- DEL 2010/09/01 --- >>>>>
                            //this.tNedit_PartsManagementDivide1.SetInt(0);
                            // --- DEL 2010/09/01 --- <<<<<
                            tEdit_PartsManagementDivide1Name.Text = string.Empty;
                        }
                        // --- DEL 2010/09/01 --- >>>>>
                        //}
                        //else
                        //{
                        //    this.tNedit_PartsManagementDivide1.SetInt(0);
                        //    this.tEdit_PartsManagementDivide1Name.Text = string.Empty;
                        //}
                        // --- DEL 2010/09/01 --- <<<<<

                        // (※マスタ未登録コードでもＯＫ)
                        if (!e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (tEdit_PartsManagementDivide1Name.Text == string.Empty)
                                        {
                                            e.NextCtrl = this.uButton_PartsManagementDivide1;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_PartsManagementDivide2;
                                        }
                                        break;
                                    }
                            }
                        }
                        // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- >>>>>
                        else
                        {
                            e.NextCtrl = tDateEdit_lastStockDate;
                        }
                        // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- <<<<<

                        # endregion
                        break;
                    }
                // 管理区分２
                case "tNedit_PartsManagementDivide2":
                    {
                        # region [管理区分２]
                        bool readStatus;
                        // --- DEL 2010/09/01 --- >>>>>
                        //if (this.tNedit_PartsManagementDivide2.GetInt() != 0)
                        //{
                        // --- DEL 2010/09/01 --- <<<<<
                        int code;
                        string name;

                        // ユーザーガイド読み込み
                        readStatus = ReadUserGuide(ct_UserGdDiv_PartsManagementDivide2, tNedit_PartsManagementDivide2.GetInt(), out code, out name);

                        // コード・名称を更新
                        // (※マスタ未登録コードでもＯＫ)
                        if (readStatus)
                        {
                            tEdit_PartsManagementDivide2Name.Text = name;
                            // --- ADD 2010/09/01 --- >>>>>
                            if ("".Equals(this.tNedit_PartsManagementDivide2.DataText))
                            {
                                this.tNedit_PartsManagementDivide2.SetInt(0);
                            }
                            // --- ADD 2010/09/01 --- <<<<<
                        }
                        else
                        {
                            // --- DEL 2010/09/01 --- >>>>>
                            //this.tNedit_PartsManagementDivide2.SetInt(0);
                            // --- DEL 2010/09/01 --- <<<<<
                            tEdit_PartsManagementDivide2Name.Text = string.Empty;
                        }
                        // --- DEL 2010/09/01 --- >>>>>
                        //}
                        //else
                        //{
                        //    this.tNedit_PartsManagementDivide2.SetInt(0);
                        //    this.tEdit_PartsManagementDivide2Name.Text = string.Empty;
                        //}
                        // --- DEL 2010/09/01 --- <<<<<

                        // (※マスタ未登録コードでもＯＫ)
                        if (!e.ShiftKey)
                        {
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (tEdit_PartsManagementDivide2Name.Text == string.Empty)
                                        {
                                            e.NextCtrl = this.uButton_PartsManagementDivide2;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_StockNote1;
                                        }


                                        break;
                                    }
                            }
                        }

                        # endregion
                        break;
                    }

                // 倉庫
                case "tEdit_WarehouseCode":
                    {
                        #region 倉庫
                        if (!string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text.Trim())
                            && !_preWarehouseCode.Equals(this.tEdit_WarehouseCode.Text.Trim()))
                        {

                            this.tEdit_WarehouseCode.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_WarehouseCode.Name, this.tEdit_WarehouseCode.Text);

                            string code;
                            string name;
                            string sectionCode;
                            string sectionName;

                            // 倉庫(+管理拠点)読み込み
                            bool readStatus = ReadWarehouseWithSection(tEdit_WarehouseCode.Text.Trim(), out code, out name, out sectionCode, out sectionName);

                            // コード・名称を更新
                            tEdit_WarehouseCode.Text = code;
                            tEdit_WarehouseName.Text = name;

                            tEdit_SectionCode.Text = sectionCode;
                            tEdit_SectionName.Text = sectionName;

                            # region [フォーカス制御]
                            if (readStatus == true)
                            {
                                if (!e.ShiftKey)
                                {
                                    // NextCtrl制御
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                        //-----UPD 2010/09/01---------->>>>>
                                        case Keys.Down:
                                            //-----UPD 2010/09/01----------<<<<<
                                            {
                                                e.NextCtrl = null;

                                                if (this._prevStockList != null && this._prevStockList.Count > 0)
                                                {
                                                    GetStockFromStockWarehouse(tEdit_WarehouseCode.Text.Trim(), e);
                                                }

                                                if (this.tEdit_GoodsNo.Enabled != false)
                                                {
                                                    e.NextCtrl = this.tEdit_GoodsNo;
                                                }
                                                else if (this.tEdit_WarehouseShelfNo.Enabled != false)
                                                {
                                                    e.NextCtrl = this.tEdit_WarehouseShelfNo;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = null;
                                                }
                                                break;
                                            }
                                        //-----UPD 2010/09/01---------->>>>>
                                        case Keys.Right:
                                            {
                                                e.NextCtrl = this.uButton_WarehouseGuide;

                                                if (this._prevStockList != null && this._prevStockList.Count > 0)
                                                {
                                                    GetStockFromStockWarehouse(tEdit_WarehouseCode.Text.Trim(), e);
                                                }
                                                break;
                                            }
                                        //-----UPD 2010/09/01----------<<<<<
                                    }
                                }
                                // --- ADD 2010/09/08 ----->>>>>
                                else
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                e.NextCtrl = null;
                                            }
                                            break;
                                    }
                                }
                                // --- ADD 2010/09/08 -----<<<<<
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
                        else
                        {
                            if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text.Trim()))
                            {
                                this._preWarehouseCode = string.Empty;
                                this.tEdit_WarehouseName.Text = string.Empty;
                            }
                            // --- ADD 2010/09/01 ------------------>>>>>
                            if (!string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text))
                            {
                                e.NextCtrl = this.tEdit_GoodsNo;
                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Right:
                                            {
                                                if (!string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text))
                                                {
                                                    e.NextCtrl = this.uButton_WarehouseGuide;
                                                }
                                                break;
                                            }
                                    }
                                }
                            }
                            // --- ADD 2010/09/08 ----->>>>>
                            if (e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                }
                            }
                            // --- ADD 2010/09/08 -----<<<<<
                            // --- ADD 2010/09/01 ------------------<<<<<
                        }

                        this._preWarehouseCode = this.tEdit_WarehouseCode.Text.Trim();

                        #endregion
                        break;
                    }

                // メーカーコード
                case "tNedit_GoodsMakerCd":
                    {
                        #region メーカーコード
                        if (this._preMakerCode == this.tNedit_GoodsMakerCd.GetInt())
                        {
                            // --- ADD 2010/09/01 ------------------>>>>>
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            e.NextCtrl = this.tEdit_WarehouseShelfNo;
                                            break;
                                        }
                                }
                            }
                            // --- ADD 2010/09/01 ------------------<<<<<
                            break;
                        }

                        if (this.tNedit_GoodsMakerCd.GetInt() != 0)
                        {
                            MakerUMnt makerUMnt;

                            // メーカー情報取得処理
                            status = this._goodsAcs.GetMaker(this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt(), out makerUMnt);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                                this.GoodsMakerName_tEdit.DataText = makerUMnt.MakerName;
                                this._preMakerCode = makerUMnt.GoodsMakerCd;

                                // 商品コードは入力されているか　→　商品変更ON
                                if (!this.tEdit_GoodsNo.DataText.Equals(string.Empty))
                                {
                                    changedGoods = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_GoodsNo;
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "メーカーマスタが未登録です。",
                                    -1,
                                    MessageBoxButtons.OK);
                                // 非存在時はフォーカス移動無し
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }
                        }
                        else
                        {
                            this.tNedit_GoodsMakerCd.Text = string.Empty;
                            this.GoodsMakerName_tEdit.DataText = string.Empty;
                            this._preMakerCode = 0;
                            this._priceValue = 0;
                            this._prevStockList = null;
                        }
                        #endregion
                        break;
                    }

                // 品番
                
                case "tEdit_GoodsNo":
                    {
                        #region 品番
                        if (!string.IsNullOrEmpty(this.tEdit_GoodsNo.DataText))
                        {
                            if (!this._preGoodsNo.Equals(this.tEdit_GoodsNo.DataText.Trim()))
                            {
                                changedGoods = true;
                                this._preGoodsNo = this.tEdit_GoodsNo.DataText.Trim();
                            }
                        }
                        else
                        {
                            this._preGoodsNo = string.Empty;
                            this._priceValue = 0;
                            this._prevStockList = null;
                            this.tEdit_GoodsName.Text = string.Empty;
                        }
                        #endregion
                        break;
                    }
                // --- ADD 2010/09/08 ----->>>>>
                // 在庫備考２
                case "tEdit_StockNote2":
                    {
                        #region 在庫備考２
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            { 
                                DialogResult dialogResult = TMsgDisp.Show(this,
                                                    emErrorLevel.ERR_LEVEL_QUESTION,
                                                    this.Name,
                                                    "登録してもよろしいですか。",
                                                    0,
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxDefaultButton.Button1);

                                switch (dialogResult)
                                {
                                    case (DialogResult.Yes):
                                        {
                                            #region 保存
                                            e.NextCtrl = null;
                                            // 保存
                                            bool saveFlag = this.SaveProc();

                                            if (saveFlag)
                                            {
                                                e.NextCtrl = this.tEdit_WarehouseCode;
                                            }
                                            #endregion
                                            break;
                                        }
                                    case (DialogResult.No):
                                        {
                                            if (this.uLabel_InputModeTitle.Text == NEW_INPUT_TITLE)
                                            {
                                                e.NextCtrl = this.tEdit_WarehouseCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_WarehouseShelfNo;
                                            }
                                            break;
                                        }
                                }
                            }

                        }
                        #endregion
                        break;
                    }
                // --- ADD 2010/09/08 -----<<<<<
            }
            #endregion

            #region 商品検索
            // 商品コード変更あり！
            if (changedGoods)
            {
                List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                GoodsUnitData goodsUnitData = new GoodsUnitData();
                string msg = string.Empty;
                GoodsCndtn cndtn = new GoodsCndtn();
                cndtn.EnterpriseCode = this._enterpriseCode;
                cndtn.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                cndtn.GoodsNo = this.tEdit_GoodsNo.DataText;
                cndtn.SectionCode = this._goodsAcs.LoginSectionCode;
                cndtn.PriceApplyDate = DateTime.Today; 
                cndtn.LogicalMode = (int)ConstantManagement.LogicalMode.GetData01;

                // --- ADD 2011/08/03 ---------->>>>>
                // 倉庫に値がある場合は入力値を優先させる
                if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text.TrimEnd()) == false)
                {
                    List<string> priorWarehouseList = new List<string>();
                    priorWarehouseList.Add(this.tEdit_WarehouseCode.Text.TrimEnd().PadLeft(4, '0'));
                    cndtn.ListPriorWarehouse = priorWarehouseList;
                }
                // --- ADD 2011/08/03  ----------<<<<<

                status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsUnitDataList, out msg);

                if (goodsUnitDataList.Count > 0)
                {
                    goodsUnitData = goodsUnitDataList[0];
                    this._goodsUnitData = goodsUnitData; // ADD 2010/09/01

                    tEdit_GoodsNo.Text = goodsUnitData.GoodsNo.Trim();
                    // ADD 2010/08/26 --- >>>>
                    if (!string.IsNullOrEmpty(goodsUnitData.SelectedWarehouseCode))
                    {
                        tEdit_WarehouseCode.Text = goodsUnitData.SelectedWarehouseCode.Trim();

                        // ADD 2010/08/27 --- >>>>
                        string code;
                        string name;
                        string sectionCode;
                        string sectionName;

                        // 倉庫(+管理拠点)読み込み
                        bool readStatus = ReadWarehouseWithSection(tEdit_WarehouseCode.Text.Trim(), out code, out name, out sectionCode, out sectionName);

                        // 名称を更新
                        tEdit_WarehouseName.Text = name;
                        // ADD 2010/08/27 --- <<<<
                    }
                    // ADD 2010/08/26 --- <<<<

                    if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)
                    {
                        if (goodsUnitData.GoodsPriceList.Count > 0)
                        {
                            GoodsPrice goodsPrice = goodsUnitData.GoodsPriceList[0];
                            this._priceValue = goodsPrice.ListPrice;
                        }
                    }
                }
                else
                {
                    if (this.tNedit_GoodsMakerCd.GetInt() != 0)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                            CT_PGID,
                                            "商品マスタが未登録です。",
                                            0,
                                            MessageBoxButtons.OK,
                                            MessageBoxDefaultButton.Button1);

                        if (this.tNedit_GoodsMakerCd.Focused)
                        {
                            this.tNedit_GoodsMakerCd.Text = string.Empty;
                            this.GoodsMakerName_tEdit.Text = string.Empty;
                            this._preMakerCode = 0;
                            e.NextCtrl = tNedit_GoodsMakerCd;
                        }
                        else
                        {
                            this.tEdit_GoodsNo.Text = string.Empty;
                            this._preGoodsNo = string.Empty;
                            e.NextCtrl = tEdit_GoodsNo;
                        }

                        this.tEdit_GoodsName.Text = string.Empty; 
                    }
                    else
                    {
                        e.NextCtrl = tNedit_GoodsMakerCd;
                        // --- ADD 2010/09/08 ----->>>>>
                        this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                        // --- ADD 2010/09/08 -----<<<<<
                    }
                    this._priceValue = 0;
                    return;
                }

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        {
                            switch (goodsUnitData.OfferKubun)
                            {
                                case 0: // ユーザー登録
                                case 1: // 提供純正編集
                                case 2: // 提供優良編集

                                    if (goodsUnitData.LogicalDeleteCode != 0)
                                    {
                                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                        CT_PGID,
                                        "商品マスタが未登録です。",
                                        0,
                                        MessageBoxButtons.OK,
                                        MessageBoxDefaultButton.Button1);

                                        if (this.tNedit_GoodsMakerCd.Focused)
                                        {
                                            this.tNedit_GoodsMakerCd.Text = string.Empty;
                                            this.GoodsMakerName_tEdit.Text = string.Empty;
                                            this._preMakerCode = 0;
                                            e.NextCtrl = tNedit_GoodsMakerCd;
                                        }
                                        else
                                        {
                                            this.tEdit_GoodsNo.Text = string.Empty;
                                            this._preGoodsNo = string.Empty;
                                            e.NextCtrl = tEdit_GoodsNo;
                                        }
                                        this.tEdit_GoodsName.Text = string.Empty;
                                        this._priceValue = 0;
                                        return;
                                    }

                                    ArrayList stockList = new ArrayList();
                                    string retMessage = string.Empty;
                                    this._prevStockList = new List<Stock>();
                                    int stockInfoStatus = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                                    try
                                    {
                                        stockInfoStatus = _stockMstAcs.SearchStockInfo(_enterpriseCode, goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd, out stockList, out retMessage);
                                    }
                                    catch
                                    {
                                        stockInfoStatus = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                    }

                                    if (stockInfoStatus == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                                    {
                                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                        CT_PGID,
                                        "在庫情報の取得に失敗しました。",
                                        stockInfoStatus,
                                        MessageBoxButtons.OK,
                                        MessageBoxDefaultButton.Button1);
                                        this.tEdit_GoodsNo.Text = string.Empty;
                                        this.tEdit_GoodsName.Text = string.Empty;
                                        this._preGoodsNo = string.Empty;
                                        e.NextCtrl = tEdit_GoodsNo;
                                        return;
                                    }

                                    // ﾒｰｶｰコード
                                    this.tNedit_GoodsMakerCd.Text = goodsUnitData.GoodsMakerCd.ToString("d4");
                                    this.GoodsMakerName_tEdit.Text = goodsUnitData.MakerName;
                                    this._preMakerCode = goodsUnitData.GoodsMakerCd;
                                    // 品名
                                    this.tEdit_GoodsName.Text = goodsUnitData.GoodsName;

                                    

                                    foreach (Stock stock in stockList)
                                    {
                                        this._prevStockList.Add(stock.Clone());
                                    }

                                    string warehouseCodeStr = this.tEdit_WarehouseCode.Text.Trim();

                                    if (!string.IsNullOrEmpty(warehouseCodeStr))
                                    {
                                        this.GetStockFromStockWarehouse(warehouseCodeStr, e);

                                        //----- ADD 2012/12/13 田建委 Redmine#33835 ------------->>>>>
                                        // 検索条件格納
                                        StockHistoryDspSearchParam extrInfo;
                                        SetExtrInfo(out extrInfo);
                                        List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList;

                                        // 出荷回数検索処理
                                        _stockMstAcs.SearchStockHisDsp(extrInfo, out stockHistoryDspSearchResultList);

                                        CreateGrid();
                                        ShipmentPartsDspResultToScreen(stockHistoryDspSearchResultList);
                                        //----- ADD 2012/12/13 田建委 Redmine#33835 -------------<<<<<
                                    }
                                    else
                                    {
                                        e.NextCtrl = tEdit_WarehouseCode;
                                    }

                                    break;
                                // --- ADD caohh 2011/08/04 ------------------------------------------------------>>>>>
                                case 4: // 提供優良
                                    {
                                        // 品番
                                        this.tEdit_GoodsNo.Text = goodsUnitData.GoodsNo.Trim();
                                        // ﾒｰｶｰコード
                                        this.tNedit_GoodsMakerCd.Text = goodsUnitData.GoodsMakerCd.ToString("d4");
                                        this.GoodsMakerName_tEdit.Text = goodsUnitData.MakerName;
                                        this._preMakerCode = goodsUnitData.GoodsMakerCd;
                                        // 品名
                                        this.tEdit_GoodsName.Text = goodsUnitData.GoodsName;
                                        // 在庫情報
                                        this._prevStockList = new List<Stock>();
 
                                        string warehouseCodeStrTmp = this.tEdit_WarehouseCode.Text.Trim();

                                        if (!string.IsNullOrEmpty(warehouseCodeStrTmp))
                                        {
                                            this.GetStockFromStockWarehouse(warehouseCodeStrTmp, e);
                                        }
                                        else
                                        {
                                            e.NextCtrl = tEdit_WarehouseCode;
                                        }
                                    }
                                    break;
                                // --- ADD caohh 2011/08/04 ------------------------------------------------------<<<<<
                                default:
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                        CT_PGID,
                                        "商品マスタが未登録です。",
                                        0,
                                        MessageBoxButtons.OK,
                                        MessageBoxDefaultButton.Button1);

                                        if (this.tNedit_GoodsMakerCd.Focused)
                                        {
                                            this.tNedit_GoodsMakerCd.Text = string.Empty;
                                            this.GoodsMakerName_tEdit.Text = string.Empty; 
                                            this._preMakerCode = 0;
                                            e.NextCtrl = tNedit_GoodsMakerCd;
                                        }
                                        else
                                        {
                                            this.tEdit_GoodsNo.Text = string.Empty;
                                            this._preGoodsNo = string.Empty;
                                            e.NextCtrl = tEdit_GoodsNo;
                                        }

                                        this.tEdit_GoodsName.Text = string.Empty;
                                        this._priceValue = 0;
                                        return;
                                }
                            break;
                        }
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
                        {
                            break;
                        }
                    default:
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                            CT_PGID,
                            "商品情報の取得に失敗しました。",
                            status,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                        break;
                }
            }
            #endregion

            // --- ADD 2010/09/08 ----->>>>>
            #region フォーカス移動
            if (e.NextCtrl != null && (this.uLabel_InputModeTitle.Text.Equals("新規") || this.uLabel_InputModeTitle.Text.Equals("更新")))
            {
                switch (e.NextCtrl.Name)
                {
                    case "tEdit_WarehouseCode":
                    case "tEdit_SectionCode":
                    case "tNedit_GoodsMakerCd":
                    case "tNedit_SupplierCd":
                    case "tNedit_PartsManagementDivide1":
                    case "tNedit_PartsManagementDivide2":
                        {
                            // ガイド
                            this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                            break;
                        }
                    default:
                        {
                            // ガイド
                            this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                            break;
                        }
                }
            }
            #endregion
            // --- ADD 2010/09/08 -----<<<<<
        }

        //----- ADD 2012/12/13 田建委 Redmine#33835 ------------------------------------->>>>>
        /// <summary>
        /// 現在処理年月取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 現在処理年月を取得します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// </remarks>
        private void GetThisYearMonth()
        {
            try
            {
                // 今回月次更新日を取得
                DateTime prevTotalDay;
                DateTime currentTotalDay;
                DateTime prevTotalMonth;
                DateTime currentTotalMonth;
                this._totalDayCalculator.GetHisTotalDayMonthly(string.Empty,
                                                        out prevTotalDay,
                                                        out currentTotalDay,
                                                        out prevTotalMonth,
                                                        out currentTotalMonth);
                if (currentTotalMonth != DateTime.MinValue)
                {
                    this._thisYearMonth = currentTotalMonth;
                }
                else
                {
                    this._dateGet.GetThisYearMonth(out this._thisYearMonth);
                }

                this._dateGet.GetDaysFromMonth(_thisYearMonth, out _stMonth, out _edMonth);

                _stAddUpDate = _stMonth.Year * 10000 + _stMonth.Month * 100 + _stMonth.Day;
                _edAddUpDate = _edMonth.Year * 10000 + _edMonth.Month * 100 + _edMonth.Day;
            }
            catch
            {
                this._thisYearMonth = new DateTime();
            }
        }

        /// <summary>
        /// グリッドレイアウト設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドレイアウトを設定します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// </remarks>
        private void SetGridLayout()
        {
            //--------------------------------------
            // グリッド外観設定
            //--------------------------------------

            this.uGrid_SalesTimes.DisplayLayout.Override.SelectTypeRow = SelectType.None;
            ColumnsCollection columns = this.uGrid_SalesTimes.DisplayLayout.Bands[0].Columns;

            NoFocusRect noFocusRect = new NoFocusRect();
            this.uGrid_SalesTimes.DrawFilter = noFocusRect;
            this.uGrid_SalesTimes.Refresh();
            
            // キャプション
            columns[COLUMN_TITLE].Header.Caption = "";
            columns[COLUMN_SALESTIMES].Header.Caption = "出荷回数";

            columns[COLUMN_TITLE].Width = 50;
            columns[COLUMN_SALESTIMES].Width = 100;

            // テキスト位置(HAlign)
            columns[COLUMN_TITLE].CellAppearance.TextHAlign = HAlign.Center;
            columns[COLUMN_SALESTIMES].CellAppearance.TextHAlign = HAlign.Right;

            // テキスト位置(VAlign)
            columns[COLUMN_TITLE].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SALESTIMES].CellAppearance.TextVAlign = VAlign.Middle;

            // セルカラー
            columns[COLUMN_TITLE].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            columns[COLUMN_TITLE].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            columns[COLUMN_TITLE].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[COLUMN_TITLE].CellAppearance.ForeColor = Color.White;
            columns[COLUMN_TITLE].CellAppearance.ForeColorDisabled = Color.White;

            // 固定ヘッダー
            columns[COLUMN_TITLE].Header.Fixed = true;
        }

        /// <summary>
        /// 検索条件格納処理
        /// </summary>
        /// <param name="extrInfo">検索条件(明示的にoutパラメータで渡します)</param>
        /// <remarks>
        /// <br>Note       : 検索条件を格納します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// </remarks>
        private void SetExtrInfo(out StockHistoryDspSearchParam extrInfo)
        {
            extrInfo = new StockHistoryDspSearchParam();

            // 企業コード
            extrInfo.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 品番
            extrInfo.GoodsNo = this.tEdit_GoodsNo.DataText.Trim();
            //メーカー
            extrInfo.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            // 倉庫コード
            extrInfo.WarehouseCode = this.tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0');
            // 開始年月
            extrInfo.StAddUpYearMonth = this._thisYearMonth.AddMonths(-12).Year * 100 + this._thisYearMonth.AddMonths(-12).Month;
            // 終了年月
            extrInfo.EdAddUpYearMonth = this._thisYearMonth.AddMonths(-1).Year * 100 + this._thisYearMonth.AddMonths(-1).Month;
            // 開始年月日
            extrInfo.StAddUpDate = this._stAddUpDate;
            // 終了年月日
            extrInfo.EdAddUpDate = this._edAddUpDate;
        }

        /// <summary>
        /// グリッド作成処理
        /// </summary>
        /// <param name="updHisDspWorkList">更新履歴リスト</param>
        /// <remarks>
        /// <br>Note       : グリッドを作成します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// </remarks>
        private void CreateGrid()
        {
            //--------------------------------------
            // グリッド列、データ設定
            //--------------------------------------
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add(COLUMN_TITLE, typeof(string));

            dataTable.Columns.Add(COLUMN_SALESTIMES, typeof(string));

            string[] titleArray = new string[13];
            for (int i = 0; i < 12; i++)
            {
                titleArray[i] = _thisYearMonth.AddMonths(-i - 1).Month.ToString() + "月";
            }
            titleArray[12] = "合計";

            for (int index = 0; index < 13; index++)
            {
                DataRow dataRow = dataTable.NewRow();

                dataRow[COLUMN_TITLE] = titleArray[index];
                dataRow[COLUMN_SALESTIMES] = "0";

                dataTable.Rows.Add(dataRow);
            }
            this.uGrid_SalesTimes.DataSource = dataTable;
            this.uGrid_SalesTimes.ActiveRow = null;
        }

        /// <summary>
        /// 出荷回数抽出結果画面表示処理
        /// </summary>
        /// <param name="shipmentPartsDspResultList">出荷回数抽出結果リスト</param>
        /// <remarks>
        /// <br>Note       : 出荷回数抽出結果リストを画面表示します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// </remarks>
        private void ShipmentPartsDspResultToScreen(List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList)
        {
            int salesTimes, sumsalesTimes = 0;

            int i = 0;
            ArrayList avgList = new ArrayList();

            for (i = 0; i <= 12; i++)
            {
                // 売上
                this.uGrid_SalesTimes.Rows[i].Cells[COLUMN_SALESTIMES].Value = "0";
            }

            if (stockHistoryDspSearchResultList.Count != 0)
            {
                foreach (StockHistoryDspSearchResult stockHistoryDspSearchResult in stockHistoryDspSearchResultList)
                {
                    #region 前月～1年間
                    for (i = 12; i > 0; i--)
                    {
                        int month = _thisYearMonth.AddMonths(-i).Month;
                        int year = _thisYearMonth.AddMonths(-i).Year;
                        if (stockHistoryDspSearchResult.AddUpYearMonth.Month == month && stockHistoryDspSearchResult.AddUpYearMonth.Year == year)
                        {
                            salesTimes = stockHistoryDspSearchResult.SalesTimes;
                            if (salesTimes.ToString().Length > 7)
                            {
                                salesTimes = int.Parse(salesTimes.ToString().Substring(salesTimes.ToString().Length - 7, 7));
                            }
                            this.uGrid_SalesTimes.Rows[i - 1].Cells[COLUMN_SALESTIMES].Value = salesTimes.ToString("#,###,##0");
                            sumsalesTimes += salesTimes;
                        }
                    }
                    #endregion
                }
            }

            // 合計
            if (sumsalesTimes.ToString().Length > 7)
            {
                sumsalesTimes = int.Parse(sumsalesTimes.ToString().Substring(sumsalesTimes.ToString().Length - 7, 7));
            }
            this.uGrid_SalesTimes.Rows[12].Cells[COLUMN_SALESTIMES].Value = sumsalesTimes.ToString("#,###,##0");
        }
        //----- ADD 2012/12/13 田建委 Redmine#33835 -------------------------------------<<<<<

        /// <summary>
        /// 提供・ユーザー画面切替
        /// </summary>
        /// <param name="modeFlg">画面切替区分</param>
        /// <remarks>
        /// <br>Note       : 提供・ユーザー画面切替に発生します。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2010/08/11</br> 
        /// </remarks> 
        private void ChangeEditMode(int modeFlg)
        {
            if (modeFlg == 0)
            {
                // なし
            }
            // 検索後の削除モード
            else if (modeFlg == 1)
            {
                // 削除
                this.tToolsManager_MainMenu.Tools[TOOLBAR_DELETEBUTTON_KEY].SharedProps.Enabled = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_DELETEBUTTON_KEY].SharedProps.Visible = false;
                // 完全削除、復活
                this.tToolsManager_MainMenu.Tools[TOOLBAR_COMPLETEDELETEBUTTON_KEY].SharedProps.Enabled = true;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_COMPLETEDELETEBUTTON_KEY].SharedProps.Visible = true;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_REVIVEBUTTON_KEY].SharedProps.Enabled = true;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_REVIVEBUTTON_KEY].SharedProps.Visible = true;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_SAVEBUTTON_KEY].SharedProps.Enabled = false;
                // --- ADD 2010/09/08 ----->>>>>
                // ガイド
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                // 最新情報
                this.tToolsManager_MainMenu.Tools[TOOLBAR_RENEWALBUTTON_KEY].SharedProps.Enabled = false;
                // --- ADD 2010/09/08 -----<<<<<
            }
            // 検索後の更新モード
            else if (modeFlg == 2)
            {
                // 削除
                this.tToolsManager_MainMenu.Tools[TOOLBAR_DELETEBUTTON_KEY].SharedProps.Enabled = true;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_DELETEBUTTON_KEY].SharedProps.Visible = true;
                // 完全削除、復活
                this.tToolsManager_MainMenu.Tools[TOOLBAR_COMPLETEDELETEBUTTON_KEY].SharedProps.Enabled = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_COMPLETEDELETEBUTTON_KEY].SharedProps.Visible = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_REVIVEBUTTON_KEY].SharedProps.Enabled = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_REVIVEBUTTON_KEY].SharedProps.Visible = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_SAVEBUTTON_KEY].SharedProps.Enabled = true;
                // --- ADD 2010/09/08 ----->>>>>
                // ガイド
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                // 最新情報
                this.tToolsManager_MainMenu.Tools[TOOLBAR_RENEWALBUTTON_KEY].SharedProps.Enabled = true;
                // --- ADD 2010/09/08 -----<<<<<
            }
            // 新規の場合、
            else if (modeFlg == 3)
            {
                // 削除
                this.tToolsManager_MainMenu.Tools[TOOLBAR_DELETEBUTTON_KEY].SharedProps.Enabled = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_DELETEBUTTON_KEY].SharedProps.Visible = true;
                // 完全削除、復活
                this.tToolsManager_MainMenu.Tools[TOOLBAR_COMPLETEDELETEBUTTON_KEY].SharedProps.Enabled = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_COMPLETEDELETEBUTTON_KEY].SharedProps.Visible = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_REVIVEBUTTON_KEY].SharedProps.Enabled = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_REVIVEBUTTON_KEY].SharedProps.Visible = false;
                this.tToolsManager_MainMenu.Tools[TOOLBAR_SAVEBUTTON_KEY].SharedProps.Enabled = true;
                // --- ADD 2010/09/08 ----->>>>>
                // ガイド
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                // 最新情報
                this.tToolsManager_MainMenu.Tools[TOOLBAR_RENEWALBUTTON_KEY].SharedProps.Enabled = true;
                // --- ADD 2010/09/08 -----<<<<<

            }
        }

        /// <summary>
        /// 数値変換処理
        /// </summary>
        /// <param name="text">数値</param>
        /// <remarks>
        /// <br>Note       : 数値変換処理に発生します。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2010/08/11</br> 
        /// </remarks> 
        /// <returns></returns>
        private int ToInt(string text)
        {
            try
            {
                return Int32.Parse(text);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ユーザーガイド名称取得処理
        /// </summary>
        /// <param name="div">ユーザーガイド区分</param>
        /// <param name="userGuideCode">ユーザーガイドコード</param>
        /// <remarks>
        /// <br>Note       : ユーザーガイド名称取得処理に発生します。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2010/08/11</br> 
        /// </remarks> 
        /// <returns></returns>
        private string GetUserGuideName(int div, int userGuideCode)
        {
            int code;
            string name;
            ReadUserGuide(div, userGuideCode, out code, out name);

            return name;
        }

        /// <summary>
        /// ユーザーガイドRead
        /// </summary>
        /// <param name="guideDivCode">ユーザー区分ガイド</param>
        /// <param name="guideCode">ユーザーガイドコード</param>
        /// <param name="code">コード</param>
        /// <param name="name">名称</param>
        /// <remarks>
        /// <br>Note       : ユーザーガイド名称取得処理に発生します。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2010/08/11</br> 
        /// </remarks>
        /// <returns></returns>
        private bool ReadUserGuide(int guideDivCode, int guideCode, out int code, out string name)
        {
            bool result = false;

            // 読み込み
            if (_userGuideAcs == null)
            {
                _userGuideAcs = new UserGuideAcs();
            }
            UserGdBd userGdBd;
            UserGuideAcsData userGuideAcsData = UserGuideAcsData.UserBodyData;
            int status = _userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, guideDivCode, guideCode, ref userGuideAcsData);

            if (status == 0 && userGdBd != null && userGdBd.LogicalDeleteCode == 0)
            {
                // 該当あり→表示
                code = userGdBd.GuideCode;
                name = userGdBd.GuideName.TrimEnd();

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

            return result;
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : Timer.Tick イベント イベント(Initial_Timer)。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void Initial_timer_Tick(object sender, EventArgs e)
        {
            this.Initial_timer.Enabled = false;

            try
            {
                string msg;

                // メニューモード時はサーバー読み込み固定
                this._goodsAcs.IsLocalDBRead = false;

                // 初期値データ取得
                int status = this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch (Exception)
            {
                // なし。
            }
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="iLevel">エラーレベル</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private DialogResult MsgDisp(string message, emErrorLevel iLevel)
        {
            // メッセージ表示
            return TMsgDisp.Show(
                this,                               // 親ウィンドウフォーム
                iLevel,                             // エラーレベル
                this.GetType().ToString(),          // アセンブリＩＤまたはクラスＩＤ
                message,                            // 表示するメッセージ
                0,                                  // ステータス値
                MessageBoxButtons.OK);             // 表示するボタン
        }

        /// <summary>
        /// 在庫　→　画面
        /// </summary>
        /// <param name="data">在庫データ</param>
        /// <remarks>
        /// <br>Note       : 在庫　→　画面の表示を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// <br>Update Note: 2011/08/29 wangf 連番1016の対応</br>
        /// </remarks>
        private void SetScreenFromStock(Stock data)
        {
            try
            {
                // 描画を止める＞＞
                this.SuspendLayout();

                //----------------------------------------------
                // 項目のセット
                //----------------------------------------------
                // 作成日
                CreateDateTime_tDateEdit.SetDateTime(data.CreateDateTime);
                // 更新日
                UpdateDateTime_tDateEdit.SetDateTime(data.UpdateDateTime);

                // 倉庫コード
                tEdit_WarehouseCode.Text = data.WarehouseCode.TrimEnd();
                // 品番
                tEdit_GoodsNo.Text = data.GoodsNo.Trim();

                // 管理拠点コード
                tEdit_SectionCode.Text = data.SectionCode.TrimEnd();
                // 管理拠点名称
                tEdit_SectionName.Text = this.GetSectionName(data.SectionCode.TrimEnd());

                // 商品メーカーコード
                this.tNedit_GoodsMakerCd.Text = data.GoodsMakerCd.ToString();

                // 棚番
                tEdit_WarehouseShelfNo.Text = data.WarehouseShelfNo.TrimEnd();
                // 重複棚番１
                tEdit_DuplicationShelfNo1.Text = data.DuplicationShelfNo1.TrimEnd();
                // 重複棚番２
                tEdit_DuplicationShelfNo2.Text = data.DuplicationShelfNo2.TrimEnd();

                // 最低在庫数
                tNedit_MinimumStockCnt.SetValue(data.MinimumStockCnt);
                // 最高在庫数
                tNedit_MaximumStockCnt.SetValue(data.MaximumStockCnt);

                // 発注ロット
                tNedit_SalesOrderUnit.SetValue(data.SalesOrderUnit);
                // 発注先コード
                tNedit_SupplierCd.SetInt(data.StockSupplierCode);
                // 発注先名称
                tEdit_SupplierName.Text = this.GetSupplierName(data.StockSupplierCode).TrimEnd();

                // 発注残
                tNedit_SalesOrderCount.SetValue(data.SalesOrderCount);

                // 最終売上日
                tDateEdit_lastSalesDate.SetDateTime(data.LastSalesDate);
                // 最終仕入日
                tDateEdit_lastStockDate.SetDateTime(data.LastStockDate);


                // 棚卸評価率
                tNedit_StockUnitPriceRate.Clear();
                // 棚卸評価単価
                if (data.StockUnitPriceFl == 0)
                {
                    tNedit_StockUnitPriceFl.Clear();
                }
                else
                {
                    tNedit_StockUnitPriceFl.SetValue(data.StockUnitPriceFl);
                }
                // 在庫備考１
                tEdit_StockNote1.DataText = data.StockNote1.Trim();
                // 在庫備考２
                tEdit_StockNote2.DataText = data.StockNote2.Trim();

                // 管理区分１コード
                tNedit_PartsManagementDivide1.SetInt(ToInt(data.PartsManagementDivide1));
                // 管理区分１名称
                tEdit_PartsManagementDivide1Name.Text = this.GetUserGuideName(ct_UserGdDiv_PartsManagementDivide1, tNedit_PartsManagementDivide1.GetInt()).TrimEnd();
                // 管理区分２コード
                tNedit_PartsManagementDivide2.SetInt(ToInt(data.PartsManagementDivide2));
                // 管理区分２名称
                tEdit_PartsManagementDivide2Name.Text = this.GetUserGuideName(ct_UserGdDiv_PartsManagementDivide2, tNedit_PartsManagementDivide2.GetInt()).TrimEnd();
                // 在庫区分
                tComboEditor_StockDiv.Value = data.StockDiv;

                //-----------------------------------------------
                // （削除対応）
                //-----------------------------------------------
                if (data.LogicalDeleteCode == 0)
                {
                    // -- add wangf 2011/08/29 ---------->>>>>
                    if (this._stockMngTtlStAcs == null)
                    {
                        this._stockMngTtlStAcs = new StockMngTtlStAcs();
                    }
                    StockMngTtlSt stockMngTtlSt = new StockMngTtlSt();
                    this._stockMngTtlStAcs.Read(out stockMngTtlSt, this._enterpriseCode);
                    // -- add wangf 2011/08/29 ----------<<<<<
                    // 仕入在庫数
                    tNedit_SupplierStock.SetValue(data.SupplierStock);
                    // 入荷数（未計上）
                    tNedit_ArrivalCnt.SetValue(data.ArrivalCnt);
                    // 出荷数（未計上）
                    tNedit_ShipmentCnt.SetValue(data.ShipmentCnt);
                    // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- >>>>>
                    this._preShipmentCnt = data.ShipmentCnt;
                    if (data.ShipmentCnt < 0)
                    {
                        tNedit_ShipmentCnt.Enabled = true;
                        tNedit_ShipmentCnt.Appearance.BackColor = BACKCOLOR_ENABLE;
                    }
                    // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- <<<<<
                    // 受注数
                    tNedit_AcpOdrCount.SetValue(data.AcpOdrCount);
                    // 移動中仕入在庫数
                    tNedit_MovingSupliStock.SetValue(data.MovingSupliStock);
                    // 現在庫数(出荷可能数)
                    tNedit_ShipmentPosCnt.SetValue(data.ShipmentPosCnt);

                    /* -- del wangf 2011/08/29 ---------->>>>>
                    _shipmentPosCountOrigin = data.ShipmentPosCnt - data.SupplierStock
                                                                  - data.ArrivalCnt
                                                                  + data.ShipmentCnt
                                                                  + data.AcpOdrCount
                                                                  + data.MovingSupliStock;
                    // -- del wangf 2011/08/29 ----------<<<<<*/
                    // -- add wangf 2011/08/29 ---------->>>>>
                    if (stockMngTtlSt.PreStckCntDspDiv == 0)
                    {
                        // 受注分含む
                        _shipmentPosCountOrigin = data.ShipmentPosCnt - data.SupplierStock
                                                                  - data.ArrivalCnt
                                                                  + data.ShipmentCnt
                                                                  + data.AcpOdrCount
                                                                  + data.MovingSupliStock;
                    }
                    else
                    {
                        // 受注分含まない
                        _shipmentPosCountOrigin = data.ShipmentPosCnt - data.SupplierStock
                                                                  - data.ArrivalCnt
                                                                  + data.ShipmentCnt
                                                                  + data.MovingSupliStock;
                    }
                    // -- add wangf 2011/08/29 ----------<<<<<
                }
                else
                {
                    //-----------------------------------------------------------------
                    // 論理削除or完全削除ならばゼロで表示
                    // （内部的には元の数量×マイナスで保持する必要がある為）
                    //-----------------------------------------------------------------
                    // 仕入在庫数
                    tNedit_SupplierStock.SetValue(0);
                    // 入荷数（未計上）
                    tNedit_ArrivalCnt.SetValue(0);
                    // 出荷数（未計上）
                    tNedit_ShipmentCnt.SetValue(0);
                    // 受注数
                    tNedit_AcpOdrCount.SetValue(0);
                    // 移動中仕入在庫数
                    tNedit_MovingSupliStock.SetValue(0);
                    // 現在庫数(出荷可能数)
                    tNedit_ShipmentPosCnt.SetValue(0);
                    _shipmentPosCountOrigin = 0;
                }

                updateTimeDt = data.UpdateDateTime;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // 描画を再開＜＜
                this.ResumeLayout();
            }
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <remarks>
        /// <br>Note       : 拠点名称取得処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns></returns>
        private string GetSectionName(string sectionCode)
        {
            string code;
            string name;
            ReadSection(sectionCode, out code, out name);

            return name;
        }

        /// <summary>
        /// 拠点Read
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="code">コード</param>
        /// <param name="name">名称</param>
        /// <remarks>
        /// <br>Note       : 拠点名称取得処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns></returns>
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
                    name = secInfoSet.SectionGuideNm.TrimEnd();

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
        /// 仕入先名称取得処理
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <remarks>
        /// <br>Note       : 拠点名称取得処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns></returns>
        private string GetSupplierName(int supplierCd)
        {
            int code;
            string name;
            ReadSupplier(supplierCd, out code, out name);

            return name;
        }

        /// <summary>
        /// 仕入先Read
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="code">コード</param>
        /// <param name="name">名称</param>
        /// <remarks>
        /// <br>Note       : 仕入先名称取得処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns></returns>
        private bool ReadSupplier(int supplierCd, out int code, out string name)
        {
            bool result = false;

            // 未入力判定
            if (supplierCd != 0)
            {
                // 読み込み
                if (_supplierAcs == null)
                {
                    _supplierAcs = new SupplierAcs();
                }
                Supplier supplier;
                int status = _supplierAcs.Read(out supplier, this._enterpriseCode, supplierCd);

                if (status == 0 && supplier != null && supplier.LogicalDeleteCode == 0)
                {
                    // 該当あり→表示
                    code = supplier.SupplierCd;
                    name = supplier.SupplierNm1.TrimEnd();

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

        /// <summary>
        /// 入力コントロールの入力可・不可設定処理（在庫）
        /// </summary>
        /// <param name="modeFlg">モードフラグ</param>
        /// <remarks>
        /// <br>Note       : 入力コントロールの入力可・不可設定処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void SettingControlsEnabled(int modeFlg)
        {
            // 検索後の新規モード
            if (modeFlg == 0)
            {
                // なし。
            }
            // 検索後の削除モード
            else if (modeFlg == 1)
            {
                this.tEdit_WarehouseCode.Enabled = false;
                this.uButton_WarehouseGuide.Enabled = false;
                this.tEdit_SectionCode.Enabled = false;
                this.uButton_SectionGuide.Enabled = false;
                this.tEdit_GoodsNo.Enabled = false;
                this.tNedit_GoodsMakerCd.Enabled = false;
                this.GoodsMakerGuide_uButton.Enabled = false;

                this.tEdit_WarehouseShelfNo.Enabled = false;
                this.tEdit_DuplicationShelfNo1.Enabled = false;
                this.tEdit_DuplicationShelfNo2.Enabled = false;
                this.tComboEditor_StockDiv.Enabled = false;
                this.tNedit_SupplierCd.Enabled = false;
                this.uButton_SupplierGuide.Enabled = false;
                this.tDateEdit_lastSalesDate.Enabled = false;
                this.tDateEdit_lastStockDate.Enabled = false;
                this.tNedit_PartsManagementDivide1.Enabled = false;
                this.uButton_PartsManagementDivide1.Enabled = false;
                this.tNedit_PartsManagementDivide2.Enabled = false;
                this.uButton_PartsManagementDivide2.Enabled = false;
                this.tEdit_StockNote1.Enabled = false;
                this.tEdit_StockNote2.Enabled = false;
                this.tNedit_MinimumStockCnt.Enabled = false;
                this.tNedit_MaximumStockCnt.Enabled = false;
                this.tNedit_SalesOrderUnit.Enabled = false;
                this.tNedit_SalesOrderCount.Enabled = false;
                this.tNedit_StockUnitPriceRate.Enabled = false;
                this.tNedit_StockUnitPriceFl.Enabled = false;
                this.tNedit_SupplierStock.Enabled = false;
            }
            // 検索後の更新モード
            else if (modeFlg == 2)
            {
                this.tEdit_WarehouseCode.Enabled = false;
                this.uButton_WarehouseGuide.Enabled = false;
                this.tEdit_GoodsNo.Enabled = false;
                this.tNedit_GoodsMakerCd.Enabled = false;
                this.GoodsMakerGuide_uButton.Enabled = false;

                this.tEdit_SectionCode.Enabled = true;
                this.uButton_SectionGuide.Enabled = true;
                this.tEdit_WarehouseShelfNo.Enabled = true;
                this.tEdit_DuplicationShelfNo1.Enabled = true;
                this.tEdit_DuplicationShelfNo2.Enabled = true;
                this.tComboEditor_StockDiv.Enabled = true;
                this.tNedit_SupplierCd.Enabled = true;
                this.uButton_SupplierGuide.Enabled = true;
                this.tDateEdit_lastSalesDate.Enabled = true;
                this.tDateEdit_lastStockDate.Enabled = true;
                this.tNedit_PartsManagementDivide1.Enabled = true;
                this.uButton_PartsManagementDivide1.Enabled = true;
                this.tNedit_PartsManagementDivide2.Enabled = true;
                this.uButton_PartsManagementDivide2.Enabled = true;
                this.tEdit_StockNote1.Enabled = true;
                this.tEdit_StockNote2.Enabled = true;
                this.tNedit_MinimumStockCnt.Enabled = true;
                this.tNedit_MaximumStockCnt.Enabled = true;
                this.tNedit_SalesOrderUnit.Enabled = true;
                this.tNedit_SalesOrderCount.Enabled = true;
                this.tNedit_StockUnitPriceRate.Enabled = true;
                this.tNedit_StockUnitPriceFl.Enabled = true;
                this.tNedit_SupplierStock.Enabled = true;
            }
            // 画面新規モード
            else if (modeFlg == 3)
            {
                this.tEdit_WarehouseCode.Enabled = true;
                this.uButton_WarehouseGuide.Enabled = true;
                this.tEdit_SectionCode.Enabled = true;
                this.uButton_SectionGuide.Enabled = true;
                this.tEdit_GoodsNo.Enabled = true;
                this.tNedit_GoodsMakerCd.Enabled = true;
                this.GoodsMakerGuide_uButton.Enabled = true;

                this.tEdit_WarehouseShelfNo.Enabled = true;
                this.tEdit_DuplicationShelfNo1.Enabled = true;
                this.tEdit_DuplicationShelfNo2.Enabled = true;
                this.tComboEditor_StockDiv.Enabled = true;
                this.tNedit_SupplierCd.Enabled = true;
                this.uButton_SupplierGuide.Enabled = true;
                this.tDateEdit_lastSalesDate.Enabled = true;
                this.tDateEdit_lastStockDate.Enabled = true;
                this.tNedit_PartsManagementDivide1.Enabled = true;
                this.uButton_PartsManagementDivide1.Enabled = true;
                this.tNedit_PartsManagementDivide2.Enabled = true;
                this.uButton_PartsManagementDivide2.Enabled = true;
                this.tEdit_StockNote1.Enabled = true;
                this.tEdit_StockNote2.Enabled = true;
                this.tNedit_MinimumStockCnt.Enabled = true;
                this.tNedit_MaximumStockCnt.Enabled = true;
                this.tNedit_SalesOrderUnit.Enabled = true;
                this.tNedit_SalesOrderCount.Enabled = true;
                this.tNedit_StockUnitPriceRate.Enabled = true;
                this.tNedit_StockUnitPriceFl.Enabled = true;
                this.tNedit_SupplierStock.Enabled = true;
            }

        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : ツールバークリックイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// <br>Update Note: K2021/05/17 譚洪</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>           : BLINCIDENT-3025 現在数が0になる対応</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            this.uiSetControl1.SettingAllControlsZeroPaddedText();

            switch (e.Tool.Key)
            {
                // -------------------------------------------------------------------------------
                // 終了
                // -------------------------------------------------------------------------------
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        #region 終了
                        if (this.CloseCheck())
                        {
                            this.Close();
                        }
                        else
                        {
                            DialogResult dr = TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_QUESTION, 
                                CT_PGID,
                                "現在、編集中のデータが存在します\n\n" + "登録してもよろしいですか？", 
                                0,
                                MessageBoxButtons.YesNoCancel);

                            switch (dr)
                            {
                                case DialogResult.No:
                                    this.Close();
                                    break;
                                case DialogResult.Yes:
                                    if (this.SaveProc())
                                    {
                                        this.Close();
                                    }
                                    break;
                                case DialogResult.Ignore:
                                    break;
                            }
                        }
                        #endregion
                        break;
                    }
				// -------------------------------------------------------------------------------
				// 保存
				// -------------------------------------------------------------------------------
                case TOOLBAR_SAVEBUTTON_KEY:
                    {
                        #region 保存
                        this.SaveProc();
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
				// 新規
				// -------------------------------------------------------------------------------
                case TOOLBAR_NEWBUTTON_KEY:
                    {
                        #region 新規
                        if (this.CloseCheck())
                        {
                            this.NewProc();
                        }
                        else
                        {
                            DialogResult dr = TMsgDisp.Show(
                                            emErrorLevel.ERR_LEVEL_QUESTION,
                                            CT_PGID,
                                            "現在、編集中のデータが存在します\n\n" + "登録してもよろしいですか？",
                                            0,
                                            //MessageBoxButtons.YesNoCancel);  // DEL by gezh 2011/11/28 redmine#8179
                                            // ADD by gezh 2011/11/28 redmine#8179 begin ----------->>>>>
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxDefaultButton.Button2);
                                            // ADD by gezh 2011/11/28 redmine#8179 end -------------<<<<<
                            switch (dr)
                            {
                                case DialogResult.No:
                                    this.NewProc();
                                    break;
                                case DialogResult.Yes:
                                    if (this.SaveProc())
                                    {
                                        this.NewProc();
                                    }
                                    break;
                                case DialogResult.Ignore:
                                    break;
                            }
                        }
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
				// 削除
				// -------------------------------------------------------------------------------
                case TOOLBAR_DELETEBUTTON_KEY:
                    {
                        #region 削除
                        // 月次更新後であれば在庫データの更新は行えない
                        if (!CanWrite(DateTime.Now)) return;

                        DialogResult dialogResult = TMsgDisp.Show(this,
                                                    emErrorLevel.ERR_LEVEL_QUESTION,
                                                    this.Name,
                                                    "データを論理削除します。" + "\r\n" + "\r\n" +
                                                    "よろしいですか？",
                                                    0,
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxDefaultButton.Button1);

                        switch (dialogResult)
                        {
                            case (DialogResult.Yes):
                                {
                                    // 論理削除処理
                                    // --- UPD 2010/09/07 ---------->>>>>
                                    //#region 削除データ
                                    //Stock retStock = new Stock();
                                    //retStock.EnterpriseCode = this._enterpriseCode;
                                    //retStock.WarehouseCode = this.tEdit_WarehouseCode.Text.Trim();
                                    //retStock.GoodsNo = this.tEdit_GoodsNo.Text.Trim();
                                    //retStock.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                                    //retStock.UpdateDateTime = this.updateTimeDt;
                                    //#endregion

                                    //int status = _stockMstAcs.LogicalDelete(retStock);

                                    List<Rate> rateList = new List<Rate>();
                                    string msg = string.Empty;

                                    for (int i = 0; i < this._goodsUnitData.StockList.Count; i++)
                                    {
                                        if (this.tEdit_WarehouseCode.Text.Equals(this._goodsUnitData.StockList[i].WarehouseCode))
                                        {
                                            Stock stock = this._goodsUnitData.StockList[i];
                                            stock.LogicalDeleteCode = 1;
                                            //this._goodsUnitData.StockList[i] = stock;
                                            break;
                                        }
                                    }
                                    // --- ADD K2021/05/17 譚洪 BLINCIDENT-3025 現在数が0になる対応 ----->>>>>
                                    //削除前の倉庫情報を保持する。
                                    List<Stock> bkStockList = new List<Stock>();
                                    foreach (Stock stock in _goodsUnitData.StockList)
                                    {
                                        bkStockList.Add(stock.Clone());
                                    }
                                    // --- ADD K2021/05/17 譚洪 BLINCIDENT-3025 現在数が0になる対応 -----<<<<<
                                    int status = this._goodsAcs.Write(ref this._goodsUnitData, this._prevStockList, ref rateList, out msg);
                                    // --- UPD 2010/09/07 ----------<<<<<

                                    #region < 論理削除後処理 >
                                    switch (status)
                                    {
                                        #region -- 通常終了 --
                                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                                            // --- UPD 2010/09/08 ----->>>>>
                                            //// 画面を初期化する
                                            //this.ClearScreen();
                                            //this.SettingControlsEnabled(3);
                                            //this.ChangeEditMode(3);

                                            //this._preGoodsNo = string.Empty;
                                            //this._preMakerCode = 0;
                                            //this._preWarehouseCode = string.Empty;
                                            //this._prevStockList = null;
                                            //this.updateTimeDt = new DateTime();

                                            //// 倉庫へフォーカス移動
                                            //this.tEdit_WarehouseCode.Focus();

                                            //this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;

                                            // 削除モードを設定
                                            this.SettingControlsEnabled(1);
                                            this.ChangeEditMode(1);

                                            for (int i = 0; i < this._prevStockList.Count; i++)
                                            {
                                                if (this.tEdit_WarehouseCode.Text.Equals(this._prevStockList[i].WarehouseCode.Trim()))
                                                {
                                                    Stock preStock = this._prevStockList[i];
                                                    preStock.SupplierStock = 0;
                                                    break;
                                                }
                                            }

                                            Stock stock = this._goodsUnitData.StockList.Find(delegate(Stock targetStock) {
                                                if (this.tEdit_WarehouseCode.Text.Equals(targetStock.WarehouseCode))
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    return false;
                                                }
                                            });
                                            this.updateTimeDt = stock.UpdateDateTime;
                                            this.tNedit_SupplierStock.SetValue(0);

                                            this.uLabel_InputModeTitle.Text = DELETE_INPUT_TITLE;
                                            // --- UPD 2010/09/08 -----<<<<<

                                            break;
                                        #endregion

                                        #region -- 排他制御 --
                                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                                            ExclusiveTransaction(status, true);
                                            break;
                                        #endregion

                                        #region -- 論理削除失敗 --
                                        default:
                                            TMsgDisp.Show(
                                                this,                                 // 親ウィンドウフォーム
                                                emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
                                                CT_PGID,                                // アセンブリＩＤまたはクラスＩＤ
                                                CT_PGNM,                                // プログラム名称
                                                "LogicalDelete",                           // 処理名称
                                                TMsgDisp.OPE_DELETE,                  // オペレーション
                                                "画面論理削除処理に失敗しました。",               // 表示するメッセージ
                                                status,                      // ステータス値
                                                this._stockMstAcs,                    // エラーが発生したオブジェクト
                                                MessageBoxButtons.OK,                 // 表示するボタン
                                                MessageBoxDefaultButton.Button1);     // 初期表示ボタン
                                            break;
                                        #endregion
                                    }
                                    // --- ADD K2021/05/17 譚洪 BLINCIDENT-3025 現在数が0になる対応 ----->>>>>
                                    //削除失敗の場合
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        //削除前の倉庫情報に戻す
                                        this._goodsUnitData.StockList = bkStockList;
                                    }
                                    // --- ADD K2021/05/17 譚洪 BLINCIDENT-3025 現在数が0になる対応 -----<<<<<
                                    #endregion

                                    break;
                                }
                        }
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
                // 完全削除
                // -------------------------------------------------------------------------------
                case TOOLBAR_COMPLETEDELETEBUTTON_KEY:
                    {
                        #region 完全削除
                        // 月次更新後であれば在庫データの更新は行えない
                        if (!CanWrite(DateTime.Now)) return;

                        DialogResult dialogResult = TMsgDisp.Show(this,
                                                    emErrorLevel.ERR_LEVEL_QUESTION,
                                                    this.Name,
                                                    "データを完全削除します。" + "\r\n" + "\r\n" +
                                                    "よろしいですか？",
                                                    0,
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxDefaultButton.Button1);

                        switch (dialogResult)
                        {
                            case (DialogResult.Yes):
                                {
                                    // 完全削除処理
                                    #region 削除データ
                                    Stock retStock = new Stock();
                                    retStock.EnterpriseCode = this._enterpriseCode;
                                    retStock.WarehouseCode = this.tEdit_WarehouseCode.Text.Trim();
                                    retStock.GoodsNo = this.tEdit_GoodsNo.Text.Trim();
                                    retStock.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                                    retStock.UpdateDateTime = this.updateTimeDt;
                                    #endregion

                                    int status = _stockMstAcs.Delete(retStock);

                                    #region < 完全削除後処理 >
                                    switch (status)
                                    {
                                        #region -- 通常終了 --
                                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                                            // 画面を初期化する
                                            this.ClearScreen();
                                            this.SettingControlsEnabled(3);
                                            this.ChangeEditMode(3);

                                            this._preGoodsNo = string.Empty;
                                            this._preMakerCode = 0;
                                            this._prevStockList = null;
                                            this._preWarehouseCode = string.Empty;
                                            this.updateTimeDt = new DateTime();

                                            // 倉庫へフォーカス移動
                                            this.tEdit_WarehouseCode.Focus();
                                            // --- ADD 2010/09/08 ----->>>>>
                                            this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                                            // --- ADD 2010/09/08 -----<<<<<

                                            this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;

                                            break;
                                        #endregion

                                        #region -- 排他制御 --
                                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                                            ExclusiveTransaction(status, true);
                                            break;
                                        #endregion

                                        #region -- 完全削除失敗 --
                                        default:
                                            TMsgDisp.Show(
                                                this,                                 // 親ウィンドウフォーム
                                                emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
                                                CT_PGID,                                // アセンブリＩＤまたはクラスＩＤ
                                                CT_PGNM,                                // プログラム名称
                                                "Delete",                           // 処理名称
                                                TMsgDisp.OPE_DELETE,                  // オペレーション
                                                "画面完全削除処理に失敗しました。",               // 表示するメッセージ
                                                status,                      　　　　　// ステータス値
                                                this._stockMstAcs,                    // エラーが発生したオブジェクト
                                                MessageBoxButtons.OK,                 // 表示するボタン
                                                MessageBoxDefaultButton.Button1);     // 初期表示ボタン
                                            break;
                                        #endregion
                                    }
                                    #endregion

                                    break;
                                }
                        }
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
                // 復活
                // -------------------------------------------------------------------------------
                case TOOLBAR_REVIVEBUTTON_KEY:
                    {
                        #region 復活
                        // 月次更新後であれば在庫データの更新は行えない
                        if (!CanWrite(DateTime.Now)) return;

                        // 復活処理
                        #region 復活データ
                        Stock retStock = new Stock();
                        retStock.EnterpriseCode = this._enterpriseCode;
                        retStock.WarehouseCode = this.tEdit_WarehouseCode.Text.Trim();
                        retStock.GoodsNo = this.tEdit_GoodsNo.Text.Trim();
                        retStock.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                        retStock.UpdateDateTime = this.updateTimeDt;
                        #endregion

                        int status = _stockMstAcs.RevivalLogicalDelete(ref retStock);
                        this._stockBak.UpdateDateTime = retStock.UpdateDateTime; // ADD 2010/09/06
                        this._stockBak.UpdEmployeeCode = retStock.UpdEmployeeCode; // ADD 2010/09/06
                        this._stockBak.UpdAssemblyId1 = retStock.UpdAssemblyId1; // ADD 2010/09/06
                        this._stockBak.UpdAssemblyId2 = retStock.UpdAssemblyId2; // ADD 2010/09/06
                        this._stockBak.LogicalDeleteCode = retStock.LogicalDeleteCode; // ADD 2010/09/06
                        this._stockBak.SupplierStock = retStock.SupplierStock; // ADD 2010/09/06

                        // --- ADD 2010/09/08 ----->>>>>
                        for (int i = 0; i < this._goodsUnitData.StockList.Count; i++)
                        {
                            if (this.tEdit_WarehouseCode.Text.Equals(this._goodsUnitData.StockList[i].WarehouseCode))
                            {
                                Stock stock = this._goodsUnitData.StockList[i];
                                stock.UpdateDateTime = retStock.UpdateDateTime;
                                stock.UpdEmployeeCode = retStock.UpdEmployeeCode;
                                stock.UpdAssemblyId1 = retStock.UpdAssemblyId1;
                                stock.UpdAssemblyId2 = retStock.UpdAssemblyId2;
                                stock.LogicalDeleteCode = retStock.LogicalDeleteCode;
                                stock.SupplierStock = retStock.SupplierStock;
                                this._goodsUnitData.StockList[i] = stock;
                                break;
                            }
                        }
                        // --- ADD 2010/09/08 -----<<<<<

                        #region < 復活後処理 >
                        switch (status)
                        {
                            #region -- 通常終了 --
                            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                                // 画面を初期化する
                                this.uLabel_InputModeTitle.Text = UPDATE_INPUT_TITLE;

                                this.SettingControlsEnabled(2);
                                this.ChangeEditMode(2);

                                // 棚番へフォーカス移動
                                this.tEdit_WarehouseShelfNo.Focus();

                                this.updateTimeDt = retStock.UpdateDateTime;

                                break;
                            #endregion

                            #region -- 排他制御 --
                            case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                            case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                                ExclusiveTransaction(status, true);
                                break;
                            #endregion

                            #region -- 復活失敗 --
                            default:
                                TMsgDisp.Show(
                                    this,                                 // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
                                    CT_PGID,                                // アセンブリＩＤまたはクラスＩＤ
                                    CT_PGNM,                                // プログラム名称
                                    "RevivalLogicalDelete",                           // 処理名称
                                    TMsgDisp.OPE_RECIEVE,                  // オペレーション
                                    "画面復活処理に失敗しました。",               // 表示するメッセージ
                                    status,                      　　　　　// ステータス値
                                    this._stockMstAcs,                    // エラーが発生したオブジェクト
                                    MessageBoxButtons.OK,                 // 表示するボタン
                                    MessageBoxDefaultButton.Button1);     // 初期表示ボタン
                                break;
                            #endregion
                        }
                        #endregion
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
                // 最新情報
                // -------------------------------------------------------------------------------
                case TOOLBAR_RENEWALBUTTON_KEY:
                    {
                        #region 最新情報
                        string msg;
                        this._goodsAcs.SearchInitial(this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);

                        TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_INFO,
                                      this.Name,
                                      "最新情報を取得しました。",
                                      0,
                                      MessageBoxButtons.OK);
                        #endregion
                        break;
                    }
                // --- ADD 2010/09/08 ----->>>>>
                // -------------------------------------------------------------------------------
                // ガイド
                // -------------------------------------------------------------------------------
                case TOOLBAR_GUIDEBUTTON_KEY:
                    {
                        #region ガイド
                        // ガイド起動処理
                        this.ExecuteGuide();
                        #endregion
                        break;
                    }
                // --- ADD 2010/09/08 -----<<<<<
            }
        }

        /// <summary>
        /// 月次更新されているかチェックし、書込み可能であるか判断します。
        /// </summary>
        /// <param name="updateingDateTime">更新日</param>
        /// <remarks>
        /// <br>Note       : 月次更新されているかチェックし、書込み可能であるか判断します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>
        /// <c>true</c> :書込み可能です。<br/>
        /// <c>false</c>:書込み不可です。
        /// </returns>
        private bool CanWrite(DateTime updateingDateTime)
        {
            return CanWrite(new List<Stock>(), null, updateingDateTime);
        }

        /// <summary>
        /// 月次更新されているかチェックし、書込み可能であるか判断します。
        /// </summary>
        /// <param name="writingStockList">書込む在庫レコードのリスト</param>
        /// <param name="previousStockList">書込む前の在庫レコードのリスト</param>
        /// <param name="updatingDateTime">更新日</param>
        /// <remarks>
        /// <br>Note       : 月次更新されているかチェックし、書込み可能であるか判断します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>
        /// <c>true</c> :書込み可能です。<br/>
        /// <c>false</c>:書込み不可です。
        /// </returns>
        private bool CanWrite(
            List<Stock> writingStockList,
            List<Stock> previousStockList,
            DateTime updatingDateTime
        )
        {

            // 月次更新のチェック
            DateTime updatingDate = new DateTime(updatingDateTime.Year, updatingDateTime.Month, updatingDateTime.Day);
            DateTime prevTotalDay = DateTime.Now;   // 3パラ目
            StockMoveInputInitDataAcs checker = StockMoveInputInitDataAcs.GetInstance();
            bool canWrite = checker.CheckHisTotalDayMonthly(
                string.Empty, 
                updatingDate,
                out prevTotalDay
            );
            if (!canWrite)
            {
                string message = "更新日が前回月次更新日以前になっている為、登録できません。" + Environment.NewLine + Environment.NewLine;
                message += string.Format("　前回月次更新日 ： {0}", prevTotalDay.ToString("yyyy年MM月dd日"));

                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                            CT_PGID,
                            message,
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
            }
            return canWrite;
        }

        /// <summary>
		/// 画面初期化
		/// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期化します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void ClearScreen()
        {
            this._stockBak = null; // ADD 2010/09/06
            this.tEdit_WarehouseCode.Text = string.Empty;
            this.tEdit_SectionCode.Text = string.Empty;
            this.tEdit_GoodsNo.Text = string.Empty;
            this.tNedit_GoodsMakerCd.Text = string.Empty;

            this.tEdit_WarehouseShelfNo.Text = string.Empty;
            this.tEdit_DuplicationShelfNo1.Text = string.Empty;
            this.tEdit_DuplicationShelfNo2.Text = string.Empty;
            this.tComboEditor_StockDiv.SelectedIndex = 0;
            this.tNedit_SupplierCd.Text = string.Empty;
            this.tDateEdit_lastSalesDate.Clear();
            this.tDateEdit_lastStockDate.Clear();
            this.tNedit_PartsManagementDivide1.Text = string.Empty;
            this.tNedit_PartsManagementDivide2.Text = string.Empty;
            this.tEdit_StockNote1.Text = string.Empty;
            this.tEdit_StockNote2.Text = string.Empty;
            this.tNedit_MinimumStockCnt.Text = string.Empty;
            this.tNedit_MaximumStockCnt.Text = string.Empty;
            this.tNedit_SalesOrderUnit.Text = string.Empty;
            this.tNedit_SalesOrderCount.Text = string.Empty;
            this.tNedit_StockUnitPriceRate.Text = string.Empty;
            this.tNedit_StockUnitPriceFl.Text = string.Empty;
            this.tNedit_SupplierStock.Text = string.Empty;

            this.CreateDateTime_tDateEdit.Clear();
            this.UpdateDateTime_tDateEdit.Clear();
            this.tEdit_WarehouseName.Text = string.Empty;
            this.tEdit_SectionName.Text = string.Empty;
            this.GoodsMakerName_tEdit.Text = string.Empty;
            this.tEdit_GoodsName.Text = string.Empty;
            this.tEdit_SupplierName.Text = string.Empty;
            this.tEdit_PartsManagementDivide1Name.Text = string.Empty;
            this.tEdit_PartsManagementDivide2Name.Text = string.Empty;
            this.tNedit_ArrivalCnt.Text = string.Empty;
            this.tNedit_ShipmentCnt.Text = string.Empty;
            this.tNedit_AcpOdrCount.Text = string.Empty;
            this.tNedit_MovingSupliStock.Text = string.Empty;
            this.tNedit_ShipmentPosCnt.Text = string.Empty;

            this.tNedit_PartsManagementDivide1.SetInt(0);
            this.tNedit_PartsManagementDivide2.SetInt(0); 

            this.tNedit_MinimumStockCnt.SetInt(0);
            this.tNedit_MaximumStockCnt.SetInt(0);
            this.tNedit_SalesOrderCount.SetInt(0);
            this.tNedit_SupplierStock.SetInt(0);
            this.tNedit_ArrivalCnt.SetInt(0);
            this.tNedit_ShipmentCnt.SetInt(0);
            this.tNedit_AcpOdrCount.SetInt(0);
            this.tNedit_MovingSupliStock.SetInt(0);
            this.tNedit_ShipmentPosCnt.SetInt(0);

            this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;
            // --- ADD 2010/09/01 --- >>>>>
            // 管理区分1、2の名称を初期設定
            bool readStatus;
            int code;
            string name;

            // 管理区分1の名称読み込み
            readStatus = ReadUserGuide(ct_UserGdDiv_PartsManagementDivide1, tNedit_PartsManagementDivide1.GetInt(), out code, out name);

            // 名称を更新
            if (readStatus)
            {
                tEdit_PartsManagementDivide1Name.Text = name;
            }
            else
            {
                tEdit_PartsManagementDivide1Name.Text = string.Empty;
            }

            // 管理区分2の名称読み込み
            readStatus = ReadUserGuide(ct_UserGdDiv_PartsManagementDivide2, tNedit_PartsManagementDivide2.GetInt(), out code, out name);

            // 名称を更新
            if (readStatus)
            {
                tEdit_PartsManagementDivide2Name.Text = name;
            }
            else
            {
                tEdit_PartsManagementDivide2Name.Text = string.Empty;
            }
            // --- ADD 2010/09/01 --- <<<<<

            CreateGrid(); // ADD 2012/12/13 田建委 Redmine#33835
        }

        /// <summary>
        /// 画面新規処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面新規処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void NewProc()
        {
            // 画面を初期化する
            this.ClearScreen();
            this.SettingControlsEnabled(3);
            this.ChangeEditMode(3);

            this._preGoodsNo = string.Empty;
            this._preMakerCode = 0;
            this._preWarehouseCode = string.Empty;
            this._priceValue = 0;
            this._prevStockList = null;
            this.updateTimeDt = new DateTime();

            // 倉庫へフォーカス移動
            this.tEdit_WarehouseCode.Focus();
            // --- ADD 2010/09/08 ----->>>>>
            this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
            // --- ADD 2010/09/08 -----<<<<<

            this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;
        }

        /// <summary>
        /// 画面新規処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面新規処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// <br>Update Note: K2021/05/17 譚洪</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>           : BLINCIDENT-3025 現在数が0になる対応</br>
        /// </remarks>
        /// <returns></returns>
        private bool SaveProc()
        {
            bool saveFlg = true;

            // 入力内容をチェックする
            if (!this.CheckInputScreen())
            {
                saveFlg = false;
                return saveFlg;
            }
                

            // 月次更新後であれば在庫データの更新は行えない
            if (!CanWrite(DateTime.Now))
            {
                saveFlg = false;
                return saveFlg;
            } 

            // 保存処理
            #region 保存データ
            Stock retStock = new Stock();
            retStock.EnterpriseCode = this._enterpriseCode;
            retStock.WarehouseCode = this.tEdit_WarehouseCode.Text.Trim();
            retStock.GoodsNo = this.tEdit_GoodsNo.Text.Trim();
            retStock.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

            retStock.SectionCode = tEdit_SectionCode.Text.TrimEnd(); // 管理拠点（拠点）コード
            retStock.WarehouseShelfNo = tEdit_WarehouseShelfNo.Text.TrimEnd(); // 倉庫棚番
            retStock.DuplicationShelfNo1 = tEdit_DuplicationShelfNo1.Text.TrimEnd(); // 重複棚番１
            retStock.DuplicationShelfNo2 = tEdit_DuplicationShelfNo2.Text.TrimEnd(); // 重複棚番２
            retStock.SupplierStock = tNedit_SupplierStock.GetValue(); // 仕入在庫数
            retStock.ShipmentPosCnt = tNedit_ShipmentPosCnt.GetValue(); // 出荷可能数(現在庫数)
            retStock.MinimumStockCnt = tNedit_MinimumStockCnt.GetValue(); // 最低在庫数
            retStock.MaximumStockCnt = tNedit_MaximumStockCnt.GetValue(); // 最高在庫数
            retStock.SalesOrderUnit = tNedit_SalesOrderUnit.GetInt(); // 発注ロット
            retStock.StockSupplierCode = tNedit_SupplierCd.GetInt(); // 発注先（仕入先）コード
            // 最終売上日
            retStock.LastSalesDate = tDateEdit_lastSalesDate.GetDateTime();
            // 最終仕入日
            retStock.LastStockDate = tDateEdit_lastStockDate.GetDateTime();
            retStock.ArrivalCnt = tNedit_ArrivalCnt.GetValue(); // 入荷数（未計上）
            retStock.ShipmentCnt = tNedit_ShipmentCnt.GetValue(); // 出荷数（未計上）
            retStock.AcpOdrCount = tNedit_AcpOdrCount.GetValue(); // 受注数
            retStock.MovingSupliStock = tNedit_MovingSupliStock.GetValue(); // 移動中仕入在庫数
            retStock.SalesOrderCount = tNedit_SalesOrderCount.GetValue();   // 発注残
            retStock.StockUnitPriceFl = tNedit_StockUnitPriceFl.GetValue(); // 棚卸評価単価
            retStock.StockNote1 = tEdit_StockNote1.DataText.Trim();         // 在庫備考１
            retStock.StockNote2 = tEdit_StockNote2.DataText.Trim();         // 在庫備考２
            retStock.PartsManagementDivide1 = tNedit_PartsManagementDivide1.GetInt().ToString(); // 部品管理区分１
            retStock.PartsManagementDivide2 = tNedit_PartsManagementDivide2.GetInt().ToString(); // 部品管理区分２
            retStock.StockDiv = (int)tComboEditor_StockDiv.Value; // 在庫区分
            //-----------------------------
            // 非入力項目
            //-----------------------------
            retStock.GoodsNoNoneHyphen = retStock.GoodsNo.Replace("-", "").TrimEnd(); // ハイフン無品番

            if (this.updateTimeDt != DateTime.MinValue)
            {
                retStock.UpdateDateTime = this.updateTimeDt;
            }

            DateTime today = DateTime.Today;
            retStock.UpdateDate = today; // 在庫更新日
            if (retStock.UpdateDateTime == DateTime.MinValue)
            {
                retStock.StockCreateDate = today; // 在庫登録日
            }
            #endregion

            string retMessage = string.Empty;
            //int stockSaveStatus = _stockMstAcs.SaveStockInfo(retStock, out retMessage); // DEL 2010/09/01
            // --- ADD 2010/09/01 ---------->>>>>
            List<Rate> rateList = new List<Rate>();

            bool findFlg = false;
            for (int i = 0; i < this._goodsUnitData.StockList.Count; i++)
            {
                if (this.tEdit_WarehouseCode.Text.Equals(this._goodsUnitData.StockList[i].WarehouseCode))
                {
                    Stock stock = this._goodsUnitData.StockList[i];
                    this.copyProterty(ref stock, retStock);
                    this._goodsUnitData.StockList[i] = stock;
                    findFlg = true;
                    break;
                }
            }
            if (!findFlg)
            {
                // --- ADD 2010/09/06 ---------->>>>>
                if (this._stockBak != null) {
                    this.copyProterty(ref this._stockBak, retStock);
                    this._goodsUnitData.StockList.Add(this._stockBak);
                } else 
                {
                // --- ADD 2010/09/06 ----------<<<<<
                    this._goodsUnitData.StockList.Add(retStock);
                } // ADD 2010/09/06
            }
            // --- ADD K2021/05/17 譚洪 BLINCIDENT-3025 現在数が0になる対応 ----->>>>>
            //更新直前の倉庫情報を保持する。
            List<Stock> bkStockList = new List<Stock>();
            foreach (Stock stock in _goodsUnitData.StockList)
            {
                bkStockList.Add(stock.Clone());
            }
            // --- ADD K2021/05/17 譚洪 BLINCIDENT-3025 現在数が0になる対応 -----<<<<<
            //int stockSaveStatus = this._goodsAcs.Write(ref this._goodsUnitData, this._prevStockList, ref rateList, out retMessage);   // DEL huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正
            // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- >>>>>
            int stockSaveStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            if (retStock.ShipmentCnt.Equals(this._preShipmentCnt))
            {
                stockSaveStatus = this._goodsAcs.Write(ref this._goodsUnitData, this._prevStockList, ref rateList, out retMessage);
            }
            else
            {
                stockSaveStatus = this._goodsAcs.WriteForShipmentCnt(ref this._goodsUnitData, this._prevStockList, ref rateList, out retMessage);
            }
            // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- <<<<<
            // --- ADD 2010/09/01 ----------<<<<<

            #region < 登録後処理 >
            switch (stockSaveStatus)
            {
                #region -- 通常終了 --
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // --- ADD 2010/09/01 ------------------>>>>>
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);
                    // --- ADD 2010/09/01 ------------------<<<<<

                    // 画面を初期化する
                    this.ClearScreen();
                    this.SettingControlsEnabled(3);
                    this.ChangeEditMode(3);

                    this._preGoodsNo = string.Empty;
                    this._preMakerCode = 0;
                    this._preWarehouseCode = string.Empty;
                    this._prevStockList = null;
                    this.updateTimeDt = new DateTime();

                    // 倉庫へフォーカス移動
                    this.tEdit_WarehouseCode.Focus();
                    // --- ADD 2010/09/08 ----->>>>>
                    this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                    // --- ADD 2010/09/08 -----<<<<<

                    this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;

                    // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- >>>>>
                    tNedit_ShipmentCnt.Enabled = false;
                    tNedit_ShipmentCnt.Appearance.BackColor = BACKCOLOR_DISABLE;
                    this._preShipmentCnt = 0;
                    // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- <<<<<

                    break;

                // 重複エラー
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // コード重複
                    TMsgDisp.Show(
                        this, 									// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                        CT_PGID,				        		// アセンブリＩＤまたはクラスＩＤ
                        "このコードは既に使用されています。",  	// 表示するメッセージ
                        0, 										// ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                    break;
                #endregion

                #region -- 排他制御 --
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    ExclusiveTransaction(stockSaveStatus, true);
                    saveFlg = false;
                    break;
                #endregion

                #region -- 登録失敗 --
                default:
                    TMsgDisp.Show(
                        this,                                 // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
                        CT_PGID,                                // アセンブリＩＤまたはクラスＩＤ
                        CT_PGNM,                                // プログラム名称
                        "SaveProc",                           // 処理名称
                        TMsgDisp.OPE_UPDATE,                  // オペレーション
                        "登録に失敗しました。",               // 表示するメッセージ
                        stockSaveStatus,                      // ステータス値
                        this._stockMstAcs,                    // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,                 // 表示するボタン
                        MessageBoxDefaultButton.Button1);     // 初期表示ボタン
                    saveFlg = false;
                    break;
                #endregion
            }
            #endregion
            // --- ADD K2021/05/17 譚洪 BLINCIDENT-3025 現在数が0になる対応 ----->>>>>
            //更新失敗の場合
            if (stockSaveStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //更新直前の倉庫情報に戻す
                this._goodsUnitData.StockList = bkStockList;
            }
            // --- ADD K2021/05/17 譚洪 BLINCIDENT-3025 現在数が0になる対応 -----<<<<<

            return saveFlg;
        }

        /// <summary>
		/// 画面閉じる前のチェック
		/// </summary>
        /// <remarks>
        /// <br>Note       : 画面閉じる前のチェック処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns></returns>
        private bool CloseCheck()
        {
            bool closeFlg = true;

            if (NEW_INPUT_TITLE.Equals(this.uLabel_InputModeTitle.Text)
                || UPDATE_INPUT_TITLE.Equals(this.uLabel_InputModeTitle.Text))
            {
                if (!string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text.Trim())) return false;
                if (!string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim())) return false;
                if (!string.IsNullOrEmpty(this.tEdit_GoodsNo.Text.Trim())) return false;
                if (this.tNedit_GoodsMakerCd.GetInt() != 0) return false;
                if (!string.IsNullOrEmpty(this.tEdit_WarehouseShelfNo.Text.Trim())) return false;
                if (!string.IsNullOrEmpty(this.tEdit_DuplicationShelfNo1.Text.Trim())) return false;
                if (!string.IsNullOrEmpty(this.tEdit_DuplicationShelfNo2.Text.Trim())) return false;
                if (this.tComboEditor_StockDiv.SelectedIndex != 0) return false;
                if (this.tNedit_SupplierCd.GetInt() != 0) return false;
                if (this.tDateEdit_lastSalesDate.GetDateTime() != DateTime.MinValue) return false;
                if (this.tDateEdit_lastStockDate.GetDateTime() != DateTime.MinValue) return false;
                if (this.tNedit_PartsManagementDivide1.GetInt() != 0) return false;
                if (this.tNedit_PartsManagementDivide2.GetInt() != 0) return false;
                if (!string.IsNullOrEmpty(this.tEdit_StockNote1.Text.Trim())) return false;
                if (!string.IsNullOrEmpty(this.tEdit_StockNote2.Text.Trim())) return false;
                if (this.tNedit_MinimumStockCnt.GetInt() != 0) return false;
                if (this.tNedit_MaximumStockCnt.GetInt() != 0) return false;
                if (this.tNedit_SalesOrderUnit.GetInt() != 0) return false;
                if (this.tNedit_SalesOrderCount.GetInt() != 0) return false;
                if (this.tNedit_StockUnitPriceRate.GetInt() != 0) return false;
                if (this.tNedit_StockUnitPriceFl.GetInt() != 0) return false;
                if (this.tNedit_SupplierStock.GetInt() != 0) return false;
                
            }
            return closeFlg;
        }

        /// <summary>
		/// 在庫情報⇒画面
		/// </summary>
        /// <param name="warehouseCodeStr">倉庫コード</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 在庫情報⇒画面処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// <br>Update Note: 2010/09/01 楊明俊 #14025の4の対応。</br>
        /// </remarks>
        private void GetStockFromStockWarehouse(string warehouseCodeStr, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            //-----ADD 2010/09/08---------->>>>>
            int dialogFlag = 0;
            //-----ADD 2010/09/08----------<<<<<
            foreach (Stock stock in this._prevStockList)
            {
                //-----ADD 2010/09/08---------->>>>>
                if (dialogFlag != 2)
                {
                    dialogFlag = 1;
                }
                //-----ADD 2010/09/08----------<<<<<
                if (warehouseCodeStr.Equals(stock.WarehouseCode.Trim()))
                {
                    this._stockBak = stock.Clone(); // ADD 2010/09/06
                    // 論理削除区分 = 0:有効
                    if (stock.LogicalDeleteCode == 0)
                    {
                        DialogResult dialogResult = TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_QUESTION,
                                        this.Name,
                                        "入力された品番は在庫マスタに既に登録されています。" + "\r\n" + "\r\n" +
                                        "編集を行いますか？",
                                        0,
                                        MessageBoxButtons.YesNo,
                                        MessageBoxDefaultButton.Button1);

                        switch (dialogResult)
                        {
                            case (DialogResult.Yes):
                                {
                                    this.uLabel_InputModeTitle.Text = UPDATE_INPUT_TITLE;
                                    this.SetScreenFromStock(stock);

                                    this.SettingControlsEnabled(2);
                                    this.ChangeEditMode(2);
                                    break;
                                }
                            case (DialogResult.No):
                                {
                                    //-----UPD 2010/09/01---------->>>>>
                                    //e.NextCtrl = tNedit_GoodsMakerCd;
                                    string sectionCode = this.tEdit_SectionCode.Text;
                                    string sectionName = this.tEdit_SectionName.Text;
                                    string warehouseName = this.tEdit_WarehouseName.Text;
                                    // 画面を初期化する
                                    this.ClearScreen();
                                    this.SettingControlsEnabled(3);
                                    this.ChangeEditMode(3);

                                    this.tEdit_WarehouseCode.Text = warehouseCodeStr;
                                    this.tEdit_WarehouseName.Text = warehouseName;
                                    this.tEdit_SectionName.Text = sectionName;
                                    this.tEdit_SectionCode.Text = sectionCode;

                                    this._preGoodsNo = string.Empty;
                                    this._preMakerCode = 0;
                                    this._preWarehouseCode = string.Empty;
                                    this._prevStockList = null;
                                    this.updateTimeDt = new DateTime();

                                    // 品番へフォーカス移動
                                    e.NextCtrl = tEdit_GoodsNo;
                                    this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;
                                    //-----UPD 2010/09/01---------->>>>>
                                    //-----ADD 2010/09/08---------->>>>>
                                    dialogFlag = 2;
                                    //-----ADD 2010/09/08----------<<<<<
                                    break;
                                }
                        }
                    }
                    // 論理削除区分 = 1:論理削除
                    else if (stock.LogicalDeleteCode == 1)
                    {
                        this.uLabel_InputModeTitle.Text = DELETE_INPUT_TITLE;
                        this.SetScreenFromStock(stock);

                        
                        this.SettingControlsEnabled(1);

                        this.tNedit_StockUnitPriceRate.Enabled = true;
                        this.tNedit_SupplierStock.Enabled = true;

                        this.tNedit_StockUnitPriceRate.Focus();

                        this.tNedit_SupplierStock.Enabled = false;
                        this.tNedit_StockUnitPriceRate.Enabled = false;
                        

                        this.ChangeEditMode(1);

                        DialogResult dialogResult = TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "入力された品番は在庫マスタから削除されています。" + "\r\n" + "\r\n",
                                        0,
                                        MessageBoxButtons.OK,
                                        MessageBoxDefaultButton.Button1);
                    }
                }
                //-----ADD 2010/09/08---------->>>>>
                if (dialogFlag == 0 || dialogFlag == 1)
                {
                    e.NextCtrl = this.tEdit_WarehouseShelfNo;
                }
                //-----ADD 2010/09/08----------<<<<<
            }
            //-----ADD 2010/09/08---------->>>>>
            if (dialogFlag == 0)
            {
                e.NextCtrl = this.tEdit_WarehouseShelfNo;
            }
            //-----ADD 2010/09/08----------<<<<<
        }

        /// <summary>
		/// 画面入力チェック
		/// </summary>
        /// <remarks>
        /// <br>Note       : 画面入力チェック処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns></returns>
        private bool CheckInputScreen()
        {
            bool checkFlg = true;

            // 倉庫を未入力する場合、エラーとする。
            if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text.Trim()))
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "倉庫を入力して下さい。",
                0,
                MessageBoxButtons.OK);
                checkFlg = false;
                this.tEdit_WarehouseCode.Focus();
                // --- ADD 2010/09/08 ----->>>>>
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                // --- ADD 2010/09/08 -----<<<<<
                return checkFlg;
            }

            // 管理拠点を未入力する場合、エラーとする。
            if (string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "拠点を入力して下さい。",
                0,
                MessageBoxButtons.OK);
                checkFlg = false;
                this.tEdit_SectionCode.Focus();
                return checkFlg;
            }

            // 品番を未入力する場合、エラーとする。
            if (string.IsNullOrEmpty(this.tEdit_GoodsNo.Text.Trim()))
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "品番を入力して下さい。",
                0,
                MessageBoxButtons.OK);
                checkFlg = false;
                this.tEdit_GoodsNo.Focus();
                return checkFlg;
            }

            // ﾒｰｶｰを未入力する場合、エラーとする。
            if (string.IsNullOrEmpty(this.tNedit_GoodsMakerCd.Text.Trim()))
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "ﾒｰｶｰを入力して下さい。",
                0,
                MessageBoxButtons.OK);
                checkFlg = false;
                this.tNedit_GoodsMakerCd.Focus();
                // --- ADD 2010/09/08 ----->>>>>
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                // --- ADD 2010/09/08 -----<<<<<
                return checkFlg;
            }

            // 最低在庫数≦最大在庫数チェック
            if (this.tNedit_MinimumStockCnt.GetValue() > this.tNedit_MaximumStockCnt.GetValue())
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "最低在庫数≦最大在庫数となるように入力して下さい。",
                0,
                MessageBoxButtons.OK);
                checkFlg = false;
                this.tNedit_MaximumStockCnt.Focus();
                return checkFlg;
            }

            // 最終売上日
            if (_dateGet.CheckDate(ref tDateEdit_lastSalesDate, true) == DateGetAcs.CheckDateResult.ErrorOfInvalid)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "最終売上日が不正です。",
                0,
                MessageBoxButtons.OK);
                checkFlg = false;
                this.tDateEdit_lastSalesDate.Focus();
                return checkFlg;
            }
            // 最終仕入日
            if (_dateGet.CheckDate(ref tDateEdit_lastStockDate, true) == DateGetAcs.CheckDateResult.ErrorOfInvalid)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "最終仕入日が不正です。",
                0,
                MessageBoxButtons.OK);
                checkFlg = false;
                this.tDateEdit_lastStockDate.Focus();
                return checkFlg;
            }

            return checkFlg;
        }

        /// <summary>
        /// 倉庫(+管理拠点)読み込み
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="code">コード</param>
        /// <param name="name">名称</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sectionName">拠点名称</param>
        /// <remarks>
        /// <br>Note       : 倉庫(+管理拠点)読み込み処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns></returns>
        private bool ReadWarehouseWithSection(string warehouseCode, out string code, out string name, out string sectionCode, out string sectionName)
        {
            bool result = false;

            sectionCode = string.Empty;
            sectionName = string.Empty;


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

                if (status == 0 && warehouse != null && warehouse.LogicalDeleteCode == 0)
                {
                    // 該当あり→表示
                    code = warehouse.WarehouseCode.TrimEnd();
                    name = warehouse.WarehouseName.TrimEnd();

                    // 拠点読み込み
                    ReadSection(warehouse.SectionCode, out sectionCode, out sectionName);

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
        /// メーカーコードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : メーカーコードガイドボタンクリックイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks> 
        private void GoodsMakerGuide_uButton_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt;

            if (_makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status != 0) return;

            // メーカーコードに変更があるか
            if (this.tNedit_GoodsMakerCd.GetInt() != makerUMnt.GoodsMakerCd)
            {
                this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                this.GoodsMakerName_tEdit.DataText = makerUMnt.MakerName;
                this._preMakerCode = makerUMnt.GoodsMakerCd;

                if (!string.IsNullOrEmpty(this.tEdit_GoodsNo.Text.Trim()))
                {
                    // 商品を検索する
                    GoodsUWork goodsUWork;

                    this._stockMstAcs.SearchGoodsUInfo(_enterpriseCode, this.tEdit_GoodsNo.Text.Trim(), makerUMnt.GoodsMakerCd, out goodsUWork);

                    if (goodsUWork != null)
                    {
                        this.tEdit_GoodsName.Text = goodsUWork.GoodsName;
                    }
                    else
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                CT_PGID,
                                                "商品マスタが未登録です。",
                                                0,
                                                MessageBoxButtons.OK,
                                                MessageBoxDefaultButton.Button1);


                        this.tNedit_GoodsMakerCd.Text = string.Empty;
                        this.GoodsMakerName_tEdit.Text = string.Empty;
                        this._preMakerCode = 0;
                        //-----UPD 2010/09/01---------->>>>>
                        //GoodsMakerGuide_uButton.Focus();
                        //this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;

                        if (this.tNedit_GoodsMakerCd.Focused)
                        {
                            this.tNedit_GoodsMakerCd.Focus();
                            this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                        }
                        else if (GoodsMakerGuide_uButton.Focused)
                        {
                            GoodsMakerGuide_uButton.Focus();
                            this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                        }
                        //-----UPD 2010/09/01----------<<<<<

                        this.tEdit_GoodsName.Text = string.Empty;

                        return;
                    }
                }
                else
                {
                    this.tEdit_GoodsNo.Focus();
                    //-----ADD 2010/09/01---------->>>>>
                    this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                    //-----ADD 2010/09/01----------<<<<<
                }
            }
            //-----ADD 2010/09/08---------->>>>>
            else
            {
                this.tEdit_WarehouseShelfNo.Focus();
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
            }
            //-----ADD 2010/09/08----------<<<<<
        }

        /// <summary>
        /// 倉庫コードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 倉庫コードガイドボタンクリックイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// <br>Update Note: 2010/09/01 楊明俊 #14025の4の対応。</br>
        /// </remarks> 
        private void uButton_WarehouseGuide_Click(object sender, EventArgs e)
        {
            // アクセスクラスインスタンス生成
            if (_warehouseAcs == null)
            {
                _warehouseAcs = new WarehouseAcs();
            }

            // ガイド実行
            Warehouse warehouse;
            int status = _warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);

            // 結果反映
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && warehouse != null)
            {
                if (warehouse.WarehouseCode.Trim() != this.tEdit_WarehouseCode.Text.Trim())
                {
                    string code;
                    string name;
                    string sectionCode;
                    string sectionName;

                    // 倉庫(+管理拠点)読み込み
                    bool readStatus = ReadWarehouseWithSection(warehouse.WarehouseCode.Trim(), out code, out name, out sectionCode, out sectionName);

                    // コード・名称を更新
                    tEdit_WarehouseCode.Text = code;
                    tEdit_WarehouseName.Text = name;

                    tEdit_SectionCode.Text = sectionCode;
                    tEdit_SectionName.Text = sectionName;

                    string warehouseCodeStr = warehouse.WarehouseCode.Trim();

                    if (this._prevStockList != null && this._prevStockList.Count > 0)
                    {
                        foreach (Stock stock in this._prevStockList)
                        {
                            if (warehouseCodeStr.Equals(stock.WarehouseCode.Trim()))
                            {

                                // 論理削除区分 = 0:有効
                                if (stock.LogicalDeleteCode == 0)
                                {
                                    DialogResult dialogResult = TMsgDisp.Show(
                                                    this,
                                                    emErrorLevel.ERR_LEVEL_QUESTION,
                                                    this.Name,
                                                    "入力された品番は在庫マスタに既に登録されています。" + "\r\n" + "\r\n" +
                                                    "編集を行いますか？",
                                                    0,
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxDefaultButton.Button1);

                                    switch (dialogResult)
                                    {
                                        case (DialogResult.Yes):
                                            {
                                                this.uLabel_InputModeTitle.Text = UPDATE_INPUT_TITLE;
                                                this.SetScreenFromStock(stock);

                                                this.SettingControlsEnabled(2);
                                                this.ChangeEditMode(2);
                                                break;
                                            }
                                        case (DialogResult.No):
                                            {
                                                //-----UPD 2010/09/01---------->>>>>
                                                //this.tEdit_WarehouseCode.Focus();
                                                string sectionCodeStr = this.tEdit_SectionCode.Text;
                                                string sectionNameStr = this.tEdit_SectionName.Text;
                                                string warehouseName = this.tEdit_WarehouseName.Text;
                                                // 画面を初期化する
                                                this.ClearScreen();
                                                this.SettingControlsEnabled(3);
                                                this.ChangeEditMode(3);

                                                this.tEdit_WarehouseCode.Text = warehouseCodeStr;
                                                this.tEdit_WarehouseName.Text = warehouseName;
                                                this.tEdit_SectionName.Text = sectionNameStr;
                                                this.tEdit_SectionCode.Text = sectionCodeStr;

                                                this._preGoodsNo = string.Empty;
                                                this._preMakerCode = 0;
                                                this._preWarehouseCode = string.Empty;
                                                this._prevStockList = null;
                                                this.updateTimeDt = new DateTime();

                                                // 品番へフォーカス移動
                                                this.tEdit_GoodsNo.Focus();
                                                this.uLabel_InputModeTitle.Text = NEW_INPUT_TITLE;
                                                //-----UPD 2010/09/01---------->>>>>
                                                return;
                                            }
                                    }
                                }
                                // 論理削除区分 = 1:論理削除
                                else if (stock.LogicalDeleteCode == 1)
                                {
                                    this.uLabel_InputModeTitle.Text = DELETE_INPUT_TITLE;
                                    this.SetScreenFromStock(stock);

                                    this.SettingControlsEnabled(1);
                                    this.ChangeEditMode(1);
                                }
                            }
                        }
                    }

                    if (this.tEdit_GoodsNo.Enabled != false)
                    {
                        this.tEdit_GoodsNo.Focus();
                        //-----ADD 2010/09/08---------->>>>>
                        this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                        //-----ADD 2010/09/08----------<<<<<
                    }
                    else if (this.tEdit_WarehouseShelfNo.Enabled != false)
                    {
                        this.tEdit_WarehouseShelfNo.Focus();
                        //-----ADD 2010/09/08---------->>>>>
                        this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                        //-----ADD 2010/09/08----------<<<<<
                    }
                }
                //-----ADD 2010/09/08---------->>>>>
                else
                {
                    this.tEdit_GoodsNo.Focus();
                    this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                }
                //-----ADD 2010/09/08----------<<<<<
            }
        }

        /// <summary>
        /// 拠点コードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 拠点コードガイドボタンクリックイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks> 
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            // アクセスクラスインスタンス生成
            if (_secInfoSetAcs == null)
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }

            // ガイド実行
            SecInfoSet secInfoSet;
            int status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

            // 結果反映
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && secInfoSet != null)
            {
                tEdit_SectionCode.Text = secInfoSet.SectionCode.TrimEnd();
                tEdit_SectionName.Text = secInfoSet.SectionGuideNm.TrimEnd();

                //-----ADD 2010/09/08---------->>>>>
                // フォーカス移動(次項目)
                //tEdit_WarehouseShelfNo.Focus();
                if (tEdit_GoodsNo.Enabled)
                {
                    tEdit_GoodsNo.Focus();
                }
                else
                {
                    tEdit_WarehouseShelfNo.Focus();
                }
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                //-----ADD 2010/09/08----------<<<<<
            }
            else
            {
                // フォーカス移動(移動しない)
            }
        }

        /// <summary>
        /// 発注先コードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 発注先コードガイドボタンクリックイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks> 
        private void uButton_SupplierGuide_Click(object sender, EventArgs e)
        {
            // アクセスクラスインスタンス生成
            if (_supplierAcs == null)
            {
                _supplierAcs = new SupplierAcs();
            }

            // ガイド実行
            Supplier supplier;
            int status = _supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);

            // 結果反映
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && supplier != null)
            {
                tNedit_SupplierCd.SetInt(supplier.SupplierCd);
                tEdit_SupplierName.Text = supplier.SupplierNm1.TrimEnd();

                // フォーカス移動(次項目)
                this.tDateEdit_lastSalesDate.Focus();
                //-----ADD 2010/09/08---------->>>>>
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                //-----ADD 2010/09/08----------<<<<<
            }
            else
            {
                // フォーカス移動(移動しない)
            }
        }

        /// <summary>
        /// 管理区分１ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       :管理区分１ガイドボタンクリックイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks> 
        private void uButton_PartsManagementDivide1_Click(object sender, EventArgs e)
        {
            // アクセスクラスインスタンス生成
            if (_userGuideAcs == null)
            {
                _userGuideAcs = new UserGuideAcs();
            }

            // 読み込み
            UserGdHd userGdHd;
            UserGdBd userGdBd;
            int status = _userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, ct_UserGdDiv_PartsManagementDivide1);

            // 結果反映
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // 結果セット
                tNedit_PartsManagementDivide1.SetInt(userGdBd.GuideCode);
                tEdit_PartsManagementDivide1Name.Text = userGdBd.GuideName.TrimEnd();

                // フォーカス移動(次項目)
                tNedit_PartsManagementDivide2.Focus();
                // --- ADD 2010/09/08 ----->>>>>
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                // --- ADD 2010/09/08 -----<<<<<
            }
            else
            {
                // フォーカス移動(移動しない)
            }
        }

        /// <summary>
        /// 管理区分２ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       :管理区分２ガイドボタンクリックイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks> 
        private void uButton_PartsManagementDivide2_Click(object sender, EventArgs e)
        {
            // アクセスクラスインスタンス生成
            if (_userGuideAcs == null)
            {
                _userGuideAcs = new UserGuideAcs();
            }

            // 読み込み
            UserGdHd userGdHd;
            UserGdBd userGdBd;
            int status = _userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, ct_UserGdDiv_PartsManagementDivide2);

            // 結果反映
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // 結果セット
                tNedit_PartsManagementDivide2.SetInt(userGdBd.GuideCode);
                tEdit_PartsManagementDivide2Name.Text = userGdBd.GuideName.TrimEnd();

                // フォーカス移動(次項目)
                // --- UPD 2010/09/01 ------------------>>>>>
                //tComboEditor_StockDiv.Focus();
                this.tEdit_StockNote1.Focus();
                // --- UPD 2010/09/01 ------------------<<<<<
                //-----ADD 2010/09/08---------->>>>>
                this.tToolsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                //-----ADD 2010/09/08----------<<<<<
            }
            else
            {
                // フォーカス移動(移動しない)
            }
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 画面を排他処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            CT_PGID, 						        // アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            CT_PGID, 						        // アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        break;
                    }
            }
        }

        /// <summary>
        /// 現在庫数算出処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 現在庫数算出処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// <br>Update Note: 2011/08/29 wangf 連番1016の対応</br>
        /// </remarks>
        private void tNedit_SupplierStock_ValueChanged(object sender, EventArgs e)
        {
            /* -- del wangf 2011/08/29 ---------->>>>>
            tNedit_ShipmentPosCnt.SetValue(_shipmentPosCountOrigin + tNedit_SupplierStock.GetValue()
                                                                   + tNedit_ArrivalCnt.GetValue()
                                                                   - tNedit_ShipmentCnt.GetValue()
                                                                   - tNedit_AcpOdrCount.GetValue()
                                                                   - tNedit_MovingSupliStock.GetValue());
            // -- del wangf 2011/08/29 ----------<<<<<*/
            // -- add wangf 2011/08/29 ---------->>>>>
            // 在庫管理全体設定の「現在庫表示区分」により、受注数は算出条件追加の判断
            if (this._stockMngTtlStAcs == null)
            {
                this._stockMngTtlStAcs = new StockMngTtlStAcs();
            }
            StockMngTtlSt stockMngTtlSt = new StockMngTtlSt();
            this._stockMngTtlStAcs.Read(out stockMngTtlSt, this._enterpriseCode);
            if (stockMngTtlSt.PreStckCntDspDiv == 0)
            {
                // 受注分含む
                tNedit_ShipmentPosCnt.SetValue(_shipmentPosCountOrigin + tNedit_SupplierStock.GetValue()
                                                                       + tNedit_ArrivalCnt.GetValue()
                                                                       - tNedit_ShipmentCnt.GetValue()
                                                                       - tNedit_AcpOdrCount.GetValue()
                                                                       - tNedit_MovingSupliStock.GetValue());
            }
            else
            {
                // 受注分含まない
                tNedit_ShipmentPosCnt.SetValue(_shipmentPosCountOrigin + tNedit_SupplierStock.GetValue()
                                                                       + tNedit_ArrivalCnt.GetValue()
                                                                       - tNedit_ShipmentCnt.GetValue()
                                                                       - tNedit_MovingSupliStock.GetValue());
            }
            // -- add wangf 2011/08/29 ----------<<<<<
        }

        /// <summary>
        /// tEdit_DuplicationShelfNo1_KeyPressイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : tEdit_DuplicationShelfNo1_KeyPressイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void tEdit_DuplicationShelfNo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_DuplicationShelfNo1.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_DuplicationShelfNo1.SelectionStart) // 選択前の部分
                                 + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                 + prevStr.Substring(this.tEdit_DuplicationShelfNo1.SelectionStart + this.tEdit_DuplicationShelfNo1.SelectionLength,
                                                      this.tEdit_DuplicationShelfNo1.Text.Length - (this.tEdit_DuplicationShelfNo1.SelectionStart + this.tEdit_DuplicationShelfNo1.SelectionLength)); // 選択後の部分

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8バイト(半角8桁、全角4桁)まで入力可
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// tEdit_DuplicationShelfNo2_KeyPressイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : tEdit_DuplicationShelfNo2_KeyPressイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void tEdit_DuplicationShelfNo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_DuplicationShelfNo2.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_DuplicationShelfNo2.SelectionStart) // 選択前の部分
                                 + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                 + prevStr.Substring(this.tEdit_DuplicationShelfNo2.SelectionStart + this.tEdit_DuplicationShelfNo2.SelectionLength,
                                                      this.tEdit_DuplicationShelfNo2.Text.Length - (this.tEdit_DuplicationShelfNo2.SelectionStart + this.tEdit_DuplicationShelfNo2.SelectionLength)); // 選択後の部分

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8バイト(半角8桁、全角4桁)まで入力可
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        // --- ADD 2010/09/01 ---------->>>>>
        /// <summary>
        /// copyProterty
        /// </summary>
        /// <param name="toStock"></param>
        /// <param name="fromStock"></param>
        /// <remarks>
        /// <br>Note       : copyProterty</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/09/01</br>
        /// </remarks>
        private void copyProterty(ref Stock toStock, Stock fromStock)
        {
            toStock.EnterpriseCode = fromStock.EnterpriseCode;
            toStock.WarehouseCode = fromStock.WarehouseCode;
            toStock.GoodsNo = fromStock.GoodsNo;
            toStock.GoodsMakerCd = fromStock.GoodsMakerCd;

            toStock.SectionCode = fromStock.SectionCode; // 管理拠点（拠点）コード
            toStock.WarehouseShelfNo = fromStock.WarehouseShelfNo; // 倉庫棚番
            toStock.DuplicationShelfNo1 = fromStock.DuplicationShelfNo1; // 重複棚番１
            toStock.DuplicationShelfNo2 = fromStock.DuplicationShelfNo2; // 重複棚番２
            toStock.SupplierStock = fromStock.SupplierStock; // 仕入在庫数
            toStock.ShipmentPosCnt = fromStock.ShipmentPosCnt; // 出荷可能数(現在庫数)
            toStock.MinimumStockCnt = fromStock.MinimumStockCnt; // 最低在庫数
            toStock.MaximumStockCnt = fromStock.MaximumStockCnt; // 最高在庫数
            toStock.SalesOrderUnit = fromStock.SalesOrderUnit; // 発注ロット
            toStock.StockSupplierCode = fromStock.StockSupplierCode; // 発注先（仕入先）コード
            // 最終売上日
            toStock.LastSalesDate = fromStock.LastSalesDate;
            // 最終仕入日
            toStock.LastStockDate = fromStock.LastStockDate;
            toStock.ArrivalCnt = fromStock.ArrivalCnt; // 入荷数（未計上）
            toStock.ShipmentCnt = fromStock.ShipmentCnt; // 出荷数（未計上）
            toStock.AcpOdrCount = fromStock.AcpOdrCount; // 受注数
            toStock.MovingSupliStock = fromStock.MovingSupliStock; // 移動中仕入在庫数
            toStock.SalesOrderCount = fromStock.SalesOrderCount;   // 発注残
            toStock.StockUnitPriceFl = fromStock.StockUnitPriceFl; // 棚卸評価単価
            toStock.StockNote1 = fromStock.StockNote1;         // 在庫備考１
            toStock.StockNote2 = fromStock.StockNote2;         // 在庫備考２
            toStock.PartsManagementDivide1 = fromStock.PartsManagementDivide1; // 部品管理区分１
            toStock.PartsManagementDivide2 = fromStock.PartsManagementDivide2; // 部品管理区分２
            toStock.StockDiv = fromStock.StockDiv; // 在庫区分
            //-----------------------------
            // 非入力項目
            //-----------------------------
            toStock.GoodsNoNoneHyphen = fromStock.GoodsNoNoneHyphen; // ハイフン無品番

            toStock.UpdateDateTime = fromStock.UpdateDateTime;

            toStock.UpdateDate = fromStock.UpdateDate; // 在庫更新日
        }
        // --- ADD 2010/09/01 ----------<<<<<

        #endregion

        // --- ADD 2010/09/08 ----->>>>>
        #region  ガイド起動処理
        /// <summary>
        /// ガイド起動処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ガイド起動処理</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/09/08</br>
        /// </remarks>
        public void ExecuteGuide()
        {
            if (this.tEdit_WarehouseCode.Focused)
            {
                this.uButton_WarehouseGuide_Click(this, new EventArgs());
            }
            else if (this.tEdit_SectionCode.Focused)
            {
                this.uButton_SectionGuide_Click(this, new EventArgs());
            }
            else if (this.tNedit_GoodsMakerCd.Focused)
            {
                this.GoodsMakerGuide_uButton_Click(this, new EventArgs());
            }
            else if (this.tNedit_SupplierCd.Focused)
            {
                this.uButton_SupplierGuide_Click(this, new EventArgs());
            }
            else if (this.tNedit_PartsManagementDivide1.Focused)
            {
                this.uButton_PartsManagementDivide1_Click(this, new EventArgs());
            }
            else if (this.tNedit_PartsManagementDivide2.Focused)
            {
                this.uButton_PartsManagementDivide2_Click(this, new EventArgs());
            }
        }
        #endregion
        // --- ADD 2010/09/08 -----<<<<<

        // --- ADD caohh 2011/08/04 ------------------------------------------------------>>>>>
        /// <summary>
        /// メーカー設定
        /// </summary>
        /// <param name="maker">メーカー</param>
        /// <param name="data">商品連結データ</param>
        /// <remarks>
        /// <br>Note       : メーカー → 商品連結データを行います。</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/04 NSユーザー改良要望一覧連番513、520の対応</br>
        /// </remarks>
        private void SetGoodsUnitDataFromMaker(MakerUMnt makerUMnt, ref GoodsUnitData data)
        {
            if (makerUMnt != null)
            {
                data.GoodsMakerCd = makerUMnt.GoodsMakerCd;
                data.MakerName = makerUMnt.MakerName;

                this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                this.GoodsMakerName_tEdit.DataText = makerUMnt.MakerName;
            }
            else
            {
                this.tNedit_GoodsMakerCd.SetInt(data.GoodsMakerCd);
                this.GoodsMakerName_tEdit.DataText = data.MakerName;
            }
        }
        // --- ADD caohh 2011/08/04 ------------------------------------------------------<<<<<
    }

    //----- ADD 2012/12/13 田建委 Redmine#33835 ------------------------------------->>>>>
    /// <summary>
    /// Gridのフォーカス矩形をオフする
    /// </summary>
    /// <remarks>
    /// <br>Note       : Gridのフォーカス矩形をオフする。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2012/12/13</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// </remarks>
    public class NoFocusRect : Infragistics.Win.IUIElementDrawFilter
    {
        #region Implementation of IUIElementDrawFilter
        public bool DrawElement(Infragistics.Win.DrawPhase drawPhase, ref Infragistics.Win.UIElementDrawParams drawParams)
        {
            return true;
        }
        public Infragistics.Win.DrawPhase GetPhasesToFilter(ref Infragistics.Win.UIElementDrawParams drawParams)
        {
            return Infragistics.Win.DrawPhase.BeforeDrawFocus;
        }
        #endregion
    }
    //----- ADD 2012/12/13 田建委 Redmine#33835 -------------------------------------<<<<<
}