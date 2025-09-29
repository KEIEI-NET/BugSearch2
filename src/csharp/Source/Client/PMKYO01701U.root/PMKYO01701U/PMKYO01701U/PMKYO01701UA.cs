//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタ抽出条件画面
// プログラム概要   : 在庫マスタ抽出条件の設定・参照処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 芦珊
// 作 成 日  2011.07.30   修正内容 : 新規作成
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
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫マスタ抽出条件画面フォームクラス
    /// </summary>
    /// <remarks>
    /// Note       : 在庫マスタ抽出条件の設定・参照処理です。<br />
    /// Programmer : 芦珊<br />
    /// Date       : 2011.07.30 <br />
    /// </remarks>
    public partial class PMKYO01701UA : Form
    {

        #region ■ Const Memebers ■

        private const string PROGRAM_ID = "PMKYO01701UA";
        
        #endregion ■ Const Memebers ■

        # region ■ Private field ■

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        private SupplierAcs _supplierAcs;       // 仕入先用
        private MakerAcs _makerAcs;             // メーカー用
        private WarehouseAcs _warehouseAcs;     // 倉庫用
        private BLGroupUAcs _blGroupUAcs;       // グループコード用
        
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginEmplooyCode = LoginInfoAcquisition.Employee.EmployeeCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

        # endregion ■ Private field ■

        #region ■ Public Memebers ■
        /// <summary>
        /// 1:新規モード 2:参照モード
        /// </summary>
        public int Mode; 
        /// <summary>
        /// APStockProcParamWork
        /// </summary>
        public APStockProcParamWork _stockProcParam;

        #endregion ■ Public Memebers ■

        #region  ■ ボタン初期設定処理 ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理です。</br>
        /// <br>Programmer : 芦珊</br>
        /// <br>Date       : 2011.07.30 </br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

        }
        # endregion ■ ボタン初期設定処理 ■

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKYO01701UA()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._supplierAcs = new SupplierAcs();
            this._makerAcs = new MakerAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._blGroupUAcs = new BLGroupUAcs();

        }
        # endregion ■ コンストラクタ ■

        # region ■ フォームロード ■
        /// <summary>
        /// 画面の処理化処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 画面の処理化を行う。</br>
        /// <br>Programmer	: 芦珊</br>	
        /// <br>Date		: 2011.07.30 </br>
        /// </remarks>
        private void PMKYO01701UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.ButtonInitialSetting();

            //参照モード
            if (this.Mode == 2)
            {
                this._saveButton.SharedProps.Visible = false;
                this._clearButton.SharedProps.Visible = false;
                //倉庫
                this.tNedit_Store_St.Enabled = false;
                this.tNedit_Store_Ed.Enabled = false;
                this.StoreStGuide_Button.Enabled = false;
                this.StoreEdGuide_Button.Enabled = false;
                //棚番
                this.tEdit_ShelfNo_St.Enabled = false;
                this.tEdit_ShelfNo_Ed.Enabled = false;
                //仕入先
                this.tNedit_SupplierCd_St.Enabled = false;
                this.tNedit_SupplierCd_Ed.Enabled = false;
                this.SupplierStGuide_Button.Enabled = false;
                this.SupplierEdGuide_Button.Enabled = false;
                //メーカー
                this.tNedit_Manuf_St.Enabled = false;
                this.tNedit_Manuf_Ed.Enabled = false;
                this.ManufStGuide_Button.Enabled = false;
                this.ManufEdGuide_Button.Enabled = false;
                //グループコード
                this.tNedit_GroupCd_St.Enabled = false;
                this.tNedit_GroupCd_Ed.Enabled = false;
                this.GroupCdStGuide_Button.Enabled = false;
                this.GroupCdEdGuide_Button.Enabled = false;
                //品番
                this.tEdit_GoodsNo_St .Enabled = false;
                this.tEdit_GoodsNo_Ed.Enabled = false;
            }
            //新規モード
            else
            {
                this._saveButton.SharedProps.Visible = true;
                this._clearButton.SharedProps.Visible = true;
                //倉庫
                this.tNedit_Store_St.Enabled = true;
                this.tNedit_Store_Ed.Enabled = true;
                this.StoreStGuide_Button.Enabled = true;
                this.StoreEdGuide_Button.Enabled = true;
                //棚番
                this.tEdit_ShelfNo_St.Enabled = true;
                this.tEdit_ShelfNo_Ed.Enabled = true;
                //仕入先
                this.tNedit_SupplierCd_St.Enabled = true;
                this.tNedit_SupplierCd_Ed.Enabled = true;
                this.SupplierStGuide_Button.Enabled = true;
                this.SupplierEdGuide_Button.Enabled = true;
                //メーカー
                this.tNedit_Manuf_St.Enabled = true;
                this.tNedit_Manuf_Ed.Enabled = true;
                this.ManufStGuide_Button.Enabled = true;
                this.ManufEdGuide_Button.Enabled = true;
                //グループコード
                this.tNedit_GroupCd_St.Enabled = true;
                this.tNedit_GroupCd_Ed.Enabled = true;
                this.GroupCdStGuide_Button.Enabled = true;
                this.GroupCdEdGuide_Button.Enabled = true;
                //品番
                this.tEdit_GoodsNo_St .Enabled = true;
                this.tEdit_GoodsNo_Ed.Enabled = true;
            }
            
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.StoreStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.StoreEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SupplierStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SupplierEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.ManufStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.ManufEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GroupCdStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GroupCdEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            this.timer_InitialSetFocus.Enabled = true;
        }
        # endregion ■ フォームロード ■

        # region ■ 画面初期化後イベント ■
        /// <summary>
        /// 画面初期化後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面初期化後イベント処理発生します。</br>
        /// <br>Programmer	: 芦珊</br>
        /// <br>Date		: 2011.07.30 </br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;
            if (this._stockProcParam != null)
            {
                // 倉庫
                if (_stockProcParam.WarehouseCodeBeginRF != null && !_stockProcParam.WarehouseCodeBeginRF.Equals(""))
                this.tNedit_Store_St.SetInt(Convert.ToInt32(_stockProcParam.WarehouseCodeBeginRF));
            if (_stockProcParam.WarehouseCodeEndRF != null && !_stockProcParam.WarehouseCodeEndRF.Equals(""))
                this.tNedit_Store_Ed.SetInt(Convert.ToInt32(_stockProcParam.WarehouseCodeEndRF));
                // 棚番
                this.tEdit_ShelfNo_St.Text = _stockProcParam.WarehouseShelfNoBeginRF;
                this.tEdit_ShelfNo_Ed.Text = _stockProcParam.WarehouseShelfNoEndRF;
                // 仕入先
                this.tNedit_SupplierCd_St.SetInt(_stockProcParam.SupplierCdBeginRF);
                this.tNedit_SupplierCd_Ed.SetInt(_stockProcParam.SupplierCdEndRF);
                // メーカー
                this.tNedit_Manuf_St.SetInt(_stockProcParam.GoodsMakerCdBeginRF);
                this.tNedit_Manuf_Ed.SetInt(_stockProcParam.GoodsMakerCdEndRF);
                // グループコード
                this.tNedit_GroupCd_St.SetInt(_stockProcParam.BLGloupCodeBeginRF);
                this.tNedit_GroupCd_Ed.SetInt(_stockProcParam.BLGloupCodeEndRF);
                // 品番
                this.tEdit_GoodsNo_St.Text = _stockProcParam.GoodsNoBeginRF;
                this.tEdit_GoodsNo_Ed.Text = _stockProcParam.GoodsNoEndRF;
            }
            
        }
        #endregion

        # region ■ ツールバー処理 ■

        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 芦珊</br>	
        /// <br>Date		: 2011.07.30 </br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        this.Close();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        //保存処理
                        this.Save();
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        // クリア処理
                        this.Clear();
                        break;
                    }
                
            }
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 保存処理です。</br>
        /// <br>Programmer	: 芦珊</br>	
        /// <br>Date		: 2011.07.30 </br>
        /// </remarks>
        private void Save()
        {
            string errMessage = "";
            // 画面データチェック処理
            if (!this.ScreenInputCheck(ref errMessage))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                //フォーカスを倉庫開始へ移動
                switch (errMessage)
                {
                    case "倉庫の範囲が不正です。":
                        {
                            if (this.tNedit_Store_St.Enabled)
                            {
                                this.tNedit_Store_St.Focus();
                            }
                        }
                        break;
                    case "棚番の範囲が不正です。":
                        {
                            if (this.tEdit_ShelfNo_St.Enabled)
                            {
                                this.tEdit_ShelfNo_St.Focus();
                            }
                        }
                        break;
                    case "仕入先の範囲が不正です。":
                        {
                            if (this.tNedit_SupplierCd_St.Enabled)
                            {
                                this.tNedit_SupplierCd_St.Focus();
                            }
                        }
                        break;
                    case "メーカーの範囲が不正です。":
                        {
                            if (this.tNedit_Manuf_St.Enabled)
                            {
                                this.tNedit_Manuf_St.Focus();
                            }
                        }
                        break;
                    case "グループコードの範囲が不正です。":
                        {
                            if (this.tNedit_GroupCd_St.Enabled)
                            {
                                this.tNedit_GroupCd_St.Focus();
                            }
                        }
                        break;
                    case "品番の範囲が不正です。":
                        {
                            if (this.tEdit_GoodsNo_St.Enabled)
                            {
                                this.tEdit_GoodsNo_St.Focus();
                            }
                        }
                        break;
                }

                return;
            }
            if (_stockProcParam == null)
            {
                _stockProcParam = new APStockProcParamWork();
            }
            else
            {
                // 倉庫
                _stockProcParam.WarehouseCodeBeginRF = this.tNedit_Store_St.Text.Trim();
                _stockProcParam.WarehouseCodeEndRF = this.tNedit_Store_Ed.Text.Trim();
                // 棚番
                _stockProcParam.WarehouseShelfNoBeginRF = this.tEdit_ShelfNo_St.Text;
                _stockProcParam.WarehouseShelfNoEndRF = this.tEdit_ShelfNo_Ed.Text;
                // 仕入先
                _stockProcParam.SupplierCdBeginRF = this.tNedit_SupplierCd_St.GetInt();
                _stockProcParam.SupplierCdEndRF = this.tNedit_SupplierCd_Ed.GetInt();
                // メーカー
                _stockProcParam.GoodsMakerCdBeginRF = this.tNedit_Manuf_St.GetInt();
                _stockProcParam.GoodsMakerCdEndRF = this.tNedit_Manuf_Ed.GetInt();
                // グループコード
                _stockProcParam.BLGloupCodeBeginRF = this.tNedit_GroupCd_St.GetInt();
                _stockProcParam.BLGloupCodeEndRF = this.tNedit_GroupCd_Ed.GetInt();
                // 品番
                _stockProcParam.GoodsNoBeginRF = this.tEdit_GoodsNo_St.Text;
                _stockProcParam.GoodsNoEndRF = this.tEdit_GoodsNo_Ed.Text;
            }

            //保存成功したら画面を閉じる
            this.Close();
        }

        /// <summary>
        /// クリア処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: クリア処理です。</br>
        /// <br>Programmer	: 芦珊</br>	
        /// <br>Date		: 2011.07.30 </br>
        /// </remarks>
        private void Clear()
        {
            //倉庫
            this.tNedit_Store_St.SetInt(0);
            this.tNedit_Store_Ed.SetInt(0);
            //棚番
            this.tEdit_ShelfNo_St.Text = "";
            this.tEdit_ShelfNo_Ed.Text = "";
            //仕入先
            this.tNedit_SupplierCd_St.SetInt(0);
            this.tNedit_SupplierCd_Ed.SetInt(0);
            //メーカー
            this.tNedit_Manuf_St.SetInt(0);
            this.tNedit_Manuf_Ed.SetInt(0);
            //グループコード
            this.tNedit_GroupCd_St.SetInt(0);
            this.tNedit_GroupCd_Ed.SetInt(0);
            //品番
            this.tEdit_GoodsNo_St.Text = "";
            this.tEdit_GoodsNo_Ed.Text = "";
        }

        #endregion region ■ ツールバー処理 ■

        #region ■ Private Method ■

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: フォームロードイベント処理発生します。</br>
        /// <br>Programmer	: 芦珊</br>
        /// <br>Date		: 2011.07.30 </br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_Store_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_Store_St.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_Store_Ed;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.StoreStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_Store_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_Store_Ed.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tEdit_ShelfNo_St;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.StoreEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tEdit_ShelfNo_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                e.NextCtrl = this.tEdit_ShelfNo_Ed;
                            }
                        }
                        break;
                    }
                case "tEdit_ShelfNo_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                e.NextCtrl = this.tNedit_SupplierCd_St;
                            }
                        }
                        break;
                    }
                case "tNedit_SupplierCd_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SupplierCd_St.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_SupplierCd_Ed;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.SupplierStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SupplierCd_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SupplierCd_Ed.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_Manuf_St;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.SupplierEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_Manuf_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_Manuf_St.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_Manuf_Ed;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.ManufStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_Manuf_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_Manuf_Ed.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_GroupCd_St;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.ManufEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_GroupCd_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_GroupCd_St.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_GroupCd_Ed;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.GroupCdStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_GroupCd_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_GroupCd_Ed.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tEdit_GoodsNo_St ;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.GroupCdEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tEdit_GoodsCd_St ":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                e.NextCtrl = this.tEdit_GoodsNo_Ed;
                            }
                        }
                        break;
                    }
                case "tEdit_GoodsCd_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス設定
                                e.NextCtrl = this.tNedit_Store_St;
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// 画面入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 芦珊</br>
        /// <br>Date		: 2011.07.30 </br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage)
        {
            bool status = true;
            const string ct_RangeError = "の範囲が不正です。";
            // 倉庫
            if (this.tNedit_Store_Ed.GetInt() > 0 && this.tNedit_Store_St.GetInt() > this.tNedit_Store_Ed.GetInt())
            {
                errMessage = "倉庫" + ct_RangeError;
                status = false;
                return status;
            }
            // 棚番
            if (!this.tEdit_ShelfNo_Ed.Text.Equals("") && this.tEdit_ShelfNo_St.Text.CompareTo(this.tEdit_ShelfNo_Ed.Text) > 0)
            {
                errMessage = "棚番" + ct_RangeError;
                status = false;
                return status;
            }
            // 仕入先
            if (this.tNedit_SupplierCd_Ed.GetInt() > 0 && this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt())
            {
                errMessage = "仕入先" + ct_RangeError;
                status = false;
                return status;
            }
            // メーカー
            if (this.tNedit_Manuf_Ed.GetInt() > 0 && this.tNedit_Manuf_St.GetInt() > this.tNedit_Manuf_Ed.GetInt())
            {
                errMessage = "メーカー" + ct_RangeError;
                status = false;
                return status;
            }
            // グループコード
            if (this.tNedit_GroupCd_Ed.GetInt() > 0 && this.tNedit_GroupCd_St.GetInt() > this.tNedit_GroupCd_Ed.GetInt())
            {
                errMessage = "グループコード" + ct_RangeError;
                status = false;
                return status;
            }
            // 品番
            if (!this.tEdit_GoodsNo_Ed.Text.Equals("") && this.tEdit_GoodsNo_St.Text.CompareTo(this.tEdit_GoodsNo_Ed.Text)>0)
            {
                errMessage = "品番" + ct_RangeError;
                status = false;
                return status;
            }

            return status;
        }

        /// <summary>
        /// Control.Click イベント(StoreGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 倉庫ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 芦珊</br>
        /// <br>Date        : 2011.07.30 </br>
        /// </remarks>
        private void StoreGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            Warehouse warehouse;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode, this._loginSectionCode);
                if (status == 0)
                {
                    if ("StoreStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_Store_St.Text = warehouse.WarehouseCode;
                    }
                    else
                    {
                        this.tNedit_Store_Ed.Text = warehouse.WarehouseCode;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 仕入先ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 芦珊</br>
        /// <br>Date        : 2011.07.30 </br>
        /// </remarks>
        private void SupplierGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            Supplier supplier;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, this._loginSectionCode);
                if (status == 0)
                {
                    if ("SupplierStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);
                    }
                    else
                    {
                        this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : メーカーガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 芦珊</br>
        /// <br>Date        : 2011.07.30 </br>
        /// </remarks>
        private void ManufGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            MakerUMnt maker;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out maker);
                if (status == 0)
                {
                    if ("ManufStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_Manuf_St.SetInt(maker.GoodsMakerCd);
                    }
                    else
                    {
                        this.tNedit_Manuf_Ed.SetInt(maker.GoodsMakerCd);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : グループコードガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 芦珊</br>
        /// <br>Date        : 2011.07.30 </br>
        /// </remarks>
        private void GroupCdGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            BLGroupU bLGroupU;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out bLGroupU);
                if (status == 0)
                {
                    if ("GroupCdStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_GroupCd_St.SetInt(bLGroupU.BLGroupCode);
                    }
                    else
                    {
                        this.tNedit_GroupCd_Ed.SetInt(bLGroupU.BLGroupCode);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// エラーメッセージ処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">STATUS</param>
        /// <returns>true:チェック完了 false:チェック未完了</returns>
        /// <remarks>
        /// <br>Note		: エラーメッセージを行う。</br>
        /// <br>Programmer	: 芦珊</br>
        /// <br>Date		: 2011.07.30 </br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,
                PROGRAM_ID,
                "",
                "",
                "",
                message,
                status,
                null,
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);
        }

        #endregion Private Method

		# region ■ ExplorerBarの縮小・展開処理 ■
		/// <summary>
		/// グループ展開
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// 常にキャンセル
			e.Cancel = true;
		}
		/// <summary>
		/// グループ縮小
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// 常にキャンセル
			e.Cancel = true;
		}
		# endregion ■  ■
	}
}