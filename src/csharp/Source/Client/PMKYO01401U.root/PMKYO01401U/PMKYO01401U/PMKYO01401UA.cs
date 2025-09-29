//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品マスタ抽出条件画面
// プログラム概要   : 商品マスタ抽出条件の設定・参照処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 丁建雄
// 作 成 日  2011.07.27  修正内容 : 新規作成
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
    /// 商品マスタ抽出条件画面フォームクラス
    /// </summary>
    /// <remarks>
    /// Note       : 商品マスタ抽出条件の設定・参照処理です。<br />
    /// Programmer : 丁建雄<br />
    /// Date       : 2011.07.27<br />
    /// </remarks>
    public partial class PMKYO01401UA : Form
    {

        #region ■ Const Memebers ■

        private const string PROGRAM_ID = "PMKYO01401UA";
        
        #endregion ■ Const Memebers ■

        # region ■ Private field ■

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        private SupplierAcs _supplierAcs;       //  仕入先用
        private BLGoodsCdAcs _blGoodsCdAcs;     //  BLコード用
        private MakerAcs _makerAcs;             // メーカー用


        private string _loginName;
        private string _enterpriseCode;
        private string _loginEmplooyCode;
        private string _loginSectionCode;

        # endregion ■ Private field ■

        #region ■ Public Memebers ■
        /// <summary>
        /// 1:新規モード 2:参照モード
        /// </summary>
        public int Mode; 
        /// <summary>
        /// APGoodsProcParamWork
        /// </summary>
        public APGoodsProcParamWork _goodsProcParam;

        #endregion ■ Public Memebers ■

        #region  ■ ボタン初期設定処理 ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理です。</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011.07.27</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.SupplierStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SupplierEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GoodsMakerCdStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GoodsMakerCdEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGoodsCodeStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGoodsCodeEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;
        }
        # endregion ■ ボタン初期設定処理 ■

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKYO01401UA()
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
            this._blGoodsCdAcs = new BLGoodsCdAcs();

            this._loginName = LoginInfoAcquisition.Employee.Name;
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginEmplooyCode = LoginInfoAcquisition.Employee.EmployeeCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

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
        /// <br>Programmer	: 丁建雄</br>	
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void PMKYO01201UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.ButtonInitialSetting();

            //参照モード
            if (this.Mode == 2)
            {
                this._saveButton.SharedProps.Visible = false;
                this._clearButton.SharedProps.Visible = false;

                this.tNedit_SupplierCd_St.Enabled = false;
                this.tNedit_SupplierCd_Ed.Enabled = false;
                this.SupplierStGuide_Button.Enabled = false;
                this.SupplierEdGuide_Button.Enabled = false;
                this.tNedit_GoodsMakerCd_St.Enabled = false;
                this.tNedit_GoodsMakerCd_Ed.Enabled = false;
                this.GoodsMakerCdStGuide_Button.Enabled = false;
                this.GoodsMakerCdEdGuide_Button.Enabled = false;
                this.tNedit_BLGoodsCode_St.Enabled = false;
                this.tNedit_BLGoodsCode_Ed.Enabled = false;
                this.BLGoodsCodeStGuide_Button.Enabled = false;
                this.BLGoodsCodeEdGuide_Button.Enabled = false;
                this.tEdit_GoodsNo_St.Enabled = false;
                this.tEdit_GoodsNo_Ed.Enabled = false;
            }
            //新規モード
            else
            {
                this._saveButton.SharedProps.Visible = true;
                this._clearButton.SharedProps.Visible = true;
                this.tNedit_SupplierCd_St.Enabled = true;
                this.tNedit_SupplierCd_Ed.Enabled = true;
                this.SupplierStGuide_Button.Enabled = true;
                this.SupplierEdGuide_Button.Enabled = true;
                this.tNedit_GoodsMakerCd_St.Enabled = true;
                this.tNedit_GoodsMakerCd_Ed.Enabled = true;
                this.GoodsMakerCdStGuide_Button.Enabled = true;
                this.GoodsMakerCdEdGuide_Button.Enabled = true;
                this.tNedit_BLGoodsCode_St.Enabled = true;
                this.tNedit_BLGoodsCode_Ed.Enabled = true;
                this.BLGoodsCodeStGuide_Button.Enabled = true;
                this.BLGoodsCodeEdGuide_Button.Enabled = true;
                this.tEdit_GoodsNo_St.Enabled = true;
                this.tEdit_GoodsNo_Ed.Enabled = true;
            }

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
        /// <br>Programmer	: 丁建雄</br>
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;
            if (this._goodsProcParam != null)
            {
                // 仕入先
                this.tNedit_SupplierCd_St.SetInt(Convert.ToInt32(_goodsProcParam.SupplierCdBeginRF));
                this.tNedit_SupplierCd_Ed.SetInt(Convert.ToInt32(_goodsProcParam.SupplierCdEndRF));


                // メーカー
                this.tNedit_GoodsMakerCd_St.SetInt(Convert.ToInt32(_goodsProcParam.GoodsMakerCdBeginRF));
                this.tNedit_GoodsMakerCd_Ed.SetInt(Convert.ToInt32(_goodsProcParam.GoodsMakerCdEndRF));

                // BLコード
                this.tNedit_BLGoodsCode_St.SetInt(Convert.ToInt32(_goodsProcParam.BLGoodsCodeBeginRF));
                this.tNedit_BLGoodsCode_Ed.SetInt(Convert.ToInt32(_goodsProcParam.BLGoodsCodeEndRF));

                // 品番
                this.tEdit_GoodsNo_St.Text = Convert.ToString(_goodsProcParam.GoodsNoBeginRF);
                this.tEdit_GoodsNo_Ed.Text = Convert.ToString(_goodsProcParam.GoodsNoEndRF);
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
        /// <br>Programmer	: 丁建雄</br>	
        /// <br>Date		: 2011.07.27</br>
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
        /// <br>Programmer	: 丁建雄</br>	
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void Save()
        {
            string errMessage = "";
            // 画面データチェック処理
            if (!this.ScreenInputCheck(ref errMessage))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                //フォーカスを仕入先開始へ移動
                switch (errMessage)
                {
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
                            if (this.tNedit_GoodsMakerCd_St.Enabled)
                            {
                                this.tNedit_GoodsMakerCd_St.Focus();
                            }
                        }
                        break;
                    case "BLコードの範囲が不正です。":
                        {
                            if (this.tNedit_BLGoodsCode_St.Enabled)
                            {
                                this.tNedit_BLGoodsCode_St.Focus();
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
            if (_goodsProcParam == null)
            {
                _goodsProcParam = new APGoodsProcParamWork();
            }
            else
            {
                // 仕入先
                _goodsProcParam.SupplierCdBeginRF = this.tNedit_SupplierCd_St.GetInt();
                _goodsProcParam.SupplierCdEndRF = this.tNedit_SupplierCd_Ed.GetInt();

                // メーカー
                _goodsProcParam.GoodsMakerCdBeginRF = this.tNedit_GoodsMakerCd_St.GetInt();
                _goodsProcParam.GoodsMakerCdEndRF = this.tNedit_GoodsMakerCd_Ed.GetInt();

                // BLコード
                _goodsProcParam.BLGoodsCodeBeginRF = this.tNedit_BLGoodsCode_St.GetInt();
                _goodsProcParam.BLGoodsCodeEndRF = this.tNedit_BLGoodsCode_Ed.GetInt();

                // 品番
                _goodsProcParam.GoodsNoBeginRF = this.tEdit_GoodsNo_St.Text;
                _goodsProcParam.GoodsNoEndRF = this.tEdit_GoodsNo_Ed.Text;
            }

            //保存成功したら画面を閉じる
            this.Close();
        }

        /// <summary>
        /// クリア処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: クリア処理です。</br>
        /// <br>Programmer	: 丁建雄</br>	
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void Clear()
        {
            // 仕入先
            this.tNedit_SupplierCd_St.SetInt(0);
            this.tNedit_SupplierCd_Ed.SetInt(0);
            // メーカー
            this.tNedit_GoodsMakerCd_St.SetInt(0);
            this.tNedit_GoodsMakerCd_Ed.SetInt(0);
            // BLコード
            this.tNedit_BLGoodsCode_St.SetInt(0);
            this.tNedit_BLGoodsCode_Ed.SetInt(0);
            // 品番
            this.tEdit_GoodsNo_St.Text = String.Empty;
            this.tEdit_GoodsNo_Ed.Text = String.Empty;
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
        /// <br>Programmer	: 丁建雄</br>
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                // 仕入先
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
                                    e.NextCtrl = this.tNedit_GoodsMakerCd_St;
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

                // メーカー
                case "tNedit_GoodsMakerCd_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SupplierCd_St.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.GoodsMakerCdStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_GoodsMakerCd_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SupplierCd_Ed.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_BLGoodsCode_St;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.GoodsMakerCdEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }

                // BLコード
                case "tNedit_BLGoodsCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SupplierCd_St.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.BLGoodsCodeStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_BLGoodsCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SupplierCd_Ed.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tEdit_GoodsNo_St;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.BLGoodsCodeEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }

                // 品番
                case "tEdit_GoodsNo_St":
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
                case "tEdit_GoodsNo_Ed":
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
            }
        }

        /// <summary>
        /// 画面入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 丁建雄</br>
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage)
        {
            bool status = true;
            const string ct_RangeError = "の範囲が不正です。";

            // 仕入先
            if (this.tNedit_SupplierCd_Ed.GetInt() > 0 && this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt())
            {
                errMessage = "仕入先" + ct_RangeError;
                status = false;
                return status;
            }
            // メーカー
            if (this.tNedit_GoodsMakerCd_Ed.GetInt() > 0 && this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                errMessage = "メーカー" + ct_RangeError;
                status = false;
                return status;
            }
            // BLコード
            if (this.tNedit_BLGoodsCode_Ed.GetInt() > 0 && this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                errMessage = "BLコード" + ct_RangeError;
                status = false;
                return status;
            }
            // 品番
            if (String.Compare(this.tEdit_GoodsNo_Ed.Text, "0") > 0 && String.Compare(this.tEdit_GoodsNo_St.Text, this.tEdit_GoodsNo_Ed.Text) > 0)
            {
                errMessage = "品番" + ct_RangeError;
                status = false;
                return status;
            }

            return status;
        }

        /// <summary>
        /// Control.Click イベント(SupplierGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 仕入先ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 丁建雄</br>
        /// <br>Date        : 2011.07.27</br>
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
        /// Control.Click イベント(GoodsMakerCdStGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : メーカーガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 丁建雄</br>
        /// <br>Date        : 2011.07.27</br>
        /// </remarks>
        private void GoodsMakerCdStGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            MakerUMnt makerUMnt;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    if ("GoodsMakerCdStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                    }
                    else
                    {
                        this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(BLGoodsCodeStGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : BLコードガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 丁建雄</br>
        /// <br>Date        : 2011.07.27</br>
        /// </remarks>
        private void BLGoodsCodeStGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            BLGoodsCdUMnt blGoodsCdUMnt;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    if ("BLGoodsCodeStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_BLGoodsCode_St.SetInt(blGoodsCdUMnt.BLGoodsCode);
                    }
                    else
                    {
                        this.tNedit_BLGoodsCode_Ed.SetInt(blGoodsCdUMnt.BLGoodsCode);
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
        /// <br>Programmer	: 丁建雄</br>
        /// <br>Date		: 2011.07.27</br>
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