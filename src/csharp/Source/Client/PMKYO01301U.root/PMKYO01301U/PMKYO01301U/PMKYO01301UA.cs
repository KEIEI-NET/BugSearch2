//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 得意先マスタ抽出条件画面
// プログラム概要   : 得意先マスタ抽出条件の設定・参照処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 馮文雄
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
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先マスタ抽出条件画面フォームクラス
    /// </summary>
    /// <remarks>
    /// Note       : 得意先マスタ抽出条件の設定・参照処理です。<br />
    /// Programmer : 馮文雄<br />
    /// Date       : 2011.07.27<br />
    /// </remarks>
    public partial class PMKYO01301UA : Form
    {

        #region ■ Const Memebers ■

        private const string PROGRAM_ID = "PMKYO01301UA";
        
        #endregion ■ Const Memebers ■

        # region ■ Private field ■

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        // 得意先マスタアクセス
        CustomerInfoAcs _customerInfoAcs;
        // 拠点マスタアクセス
        SecInfoSetAcs _secInfoSetAcs;
        // 従業員マスタアクセス
        private EmployeeAcs _employeeAcs;
        // ユーザマスタアクセスクラス
        private UserGuideAcs _userGuideAcs;
        // 得意先ガイド設定成功フラグ
        private bool _customerGuidOK;

        
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
        /// APCustomerProcParamWork
        /// </summary>
        public APCustomerProcParamWork _customerProcParam;

        #endregion ■ Public Memebers ■

        #region  ■ ボタン初期設定処理 ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理です。</br>
        /// <br>Programmer : 馮文雄</br>
        /// <br>Date       : 2011.07.27</br>
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
        public PMKYO01301UA()
        {
            InitializeComponent();

            // 得意先ガイド用アクセスクラス
            _customerInfoAcs = new CustomerInfoAcs();
            // 拠点ガイド用アクセスクラス
            this._secInfoSetAcs = new SecInfoSetAcs();
            // 従業員ガイド用アクセスクラス
            this._employeeAcs = new EmployeeAcs();
            // ユーザーガイド用アクセスクラス
            this._userGuideAcs = new UserGuideAcs();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();

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
        /// <br>Programmer	: 馮文雄</br>	
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
                this.tNedit_CustomerCode_St.Enabled = false;
                this.tNedit_CustomerCode_Ed.Enabled = false;
                this.tEdit_Kana_St.Enabled = false;
                this.tEdit_Kana_Ed.Enabled = false;
                this.tEdit_SectionCode_St.Enabled = false;
                this.tEdit_SectionCode_Ed.Enabled = false;
                this.tEdit_EmployeeCode_St.Enabled = false;
                this.tEdit_EmployeeCode_Ed.Enabled = false;
                this.tNedit_SalesAreaCode_St.Enabled = false;
                this.tNedit_SalesAreaCode_Ed.Enabled = false;
                this.tNedit_BusinessTypeCode_St.Enabled = false;
                this.tNedit_BusinessTypeCode_Ed.Enabled = false;
                this.CustomerStGuide_Button.Enabled = false;
                this.CustomerEdGuide_Button.Enabled = false;
                this.SectionStGuide_Button.Enabled = false;
                this.SectionEdGuide_Button.Enabled = false;
                this.EmployeeStGuide_Button.Enabled = false;
                this.EmployeeEdGuide_Button.Enabled = false;
                this.AreaStGuide_Button.Enabled = false;
                this.AreaEdGuide_Button.Enabled = false;
                this.BusinessTypeCodeSt_Button.Enabled = false;
                this.BusinessTypeCodeEd_Button.Enabled = false;

            }
            //新規モード
            else
            {
                this._saveButton.SharedProps.Visible = true;
                this._clearButton.SharedProps.Visible = true;
                this.tNedit_CustomerCode_St.Enabled = true;
                this.tNedit_CustomerCode_Ed.Enabled = true;
                this.tEdit_Kana_St.Enabled = true;
                this.tEdit_Kana_Ed.Enabled = true;
                this.tEdit_SectionCode_St.Enabled = true;
                this.tEdit_SectionCode_Ed.Enabled = true;
                this.tEdit_EmployeeCode_St.Enabled = true;
                this.tEdit_EmployeeCode_Ed.Enabled = true;
                this.tNedit_SalesAreaCode_St.Enabled = true;
                this.tNedit_SalesAreaCode_Ed.Enabled = true;
                this.tNedit_BusinessTypeCode_St.Enabled = true;
                this.tNedit_BusinessTypeCode_Ed.Enabled = true;
                this.CustomerStGuide_Button.Enabled = true;
                this.CustomerEdGuide_Button.Enabled = true;
                this.SectionStGuide_Button.Enabled = true;
                this.SectionEdGuide_Button.Enabled = true;
                this.EmployeeStGuide_Button.Enabled = true;
                this.EmployeeEdGuide_Button.Enabled = true;
                this.AreaStGuide_Button.Enabled = true;
                this.AreaEdGuide_Button.Enabled = true;
                this.BusinessTypeCodeSt_Button.Enabled = true;
                this.BusinessTypeCodeEd_Button.Enabled = true;
            }
            
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.CustomerStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SectionStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SectionEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.EmployeeStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.EmployeeEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.AreaStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.AreaEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BusinessTypeCodeSt_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BusinessTypeCodeEd_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

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
        /// <br>Programmer	: 馮文雄</br>
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;
            if (this._customerProcParam != null)
            {
                //開始条件1(得意先)
                this.tNedit_CustomerCode_St.SetInt(_customerProcParam.CustomerCodeBeginRF);
                //終了条件1(得意先)
                this.tNedit_CustomerCode_Ed.SetInt(_customerProcParam.CustomerCodeEndRF);
                //開始条件2(カナ)
                this.tEdit_Kana_St.DataText = _customerProcParam.KanaBeginRF;
                //終了条件2(カナ)
                this.tEdit_Kana_Ed.DataText = _customerProcParam.KanaEndRF;
                //開始条件3(拠点)
                this.tEdit_SectionCode_St.DataText = _customerProcParam.MngSectionCodeBeginRF.Trim();
                //終了条件3(拠点)
                this.tEdit_SectionCode_Ed.DataText = _customerProcParam.MngSectionCodeEndRF.Trim();
                //開始条件4(担当者)
                this.tEdit_EmployeeCode_St.DataText = _customerProcParam.CustomerAgentCdBeginRF;
                //終了条件4(担当者)
                this.tEdit_EmployeeCode_Ed.DataText = _customerProcParam.CustomerAgentCdEndRF;
                //開始条件5(地区)
                this.tNedit_SalesAreaCode_St.SetInt(_customerProcParam.SalesAreaCodeBeginRF);
                //終了条件5(地区)
                this.tNedit_SalesAreaCode_Ed.SetInt(_customerProcParam.SalesAreaCodeEndRF);
                //開始条件6(業種)
                this.tNedit_BusinessTypeCode_St.SetInt(_customerProcParam.BusinessTypeCodeBeginRF);
                //終了条件6(業種)
                this.tNedit_BusinessTypeCode_Ed.SetInt(_customerProcParam.BusinessTypeCodeEndRF);
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
        /// <br>Programmer	: 馮文雄</br>	
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
        /// <br>Programmer	: 馮文雄</br>	
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void Save()
        {
            string errMessage = "";
            Control errCtrl = null;
            // 画面データチェック処理
            if (!this.ScreenInputCheck(out errCtrl, ref errMessage))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                //フォーカスをエラー項目へ移動
                if (null != errCtrl && errCtrl.Enabled)
                {
                    errCtrl.Focus();
                }
                return;
            }
            if (_customerProcParam == null)
            {
                _customerProcParam = new APCustomerProcParamWork();
            }
            else
            {
                //開始条件1(得意先)
                _customerProcParam.CustomerCodeBeginRF = this.tNedit_CustomerCode_St.GetInt();
                //終了条件1(得意先)
                _customerProcParam.CustomerCodeEndRF =  this.tNedit_CustomerCode_Ed.GetInt();
                //開始条件2(カナ)
                _customerProcParam.KanaBeginRF =  this.tEdit_Kana_St.DataText;
                //終了条件2(カナ)
                _customerProcParam.KanaEndRF = this.tEdit_Kana_Ed.DataText;
                //開始条件3(拠点)
                _customerProcParam.MngSectionCodeBeginRF = this.tEdit_SectionCode_St.DataText;
                //終了条件3(拠点)
                _customerProcParam.MngSectionCodeEndRF =  this.tEdit_SectionCode_Ed.DataText;
                //開始条件4(担当者)
                _customerProcParam.CustomerAgentCdBeginRF =  this.tEdit_EmployeeCode_St.DataText;
                //終了条件4(担当者)
                _customerProcParam.CustomerAgentCdEndRF =  this.tEdit_EmployeeCode_Ed.DataText;
                //開始条件5(地区)
                _customerProcParam.SalesAreaCodeBeginRF = this.tNedit_SalesAreaCode_St.GetInt();
                //終了条件5(地区)
                _customerProcParam.SalesAreaCodeEndRF = this.tNedit_SalesAreaCode_Ed.GetInt();
                //開始条件6(業種)
                _customerProcParam.BusinessTypeCodeBeginRF =  this.tNedit_BusinessTypeCode_St.GetInt();
                //終了条件6(業種)
                _customerProcParam.BusinessTypeCodeEndRF =  this.tNedit_BusinessTypeCode_Ed.GetInt();
            }

            //保存成功したら画面を閉じる
            this.Close();
        }

        /// <summary>
        /// クリア処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: クリア処理です。</br>
        /// <br>Programmer	: 馮文雄</br>	
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void Clear()
        {
            this.tNedit_CustomerCode_St.SetInt(0);
            this.tNedit_CustomerCode_Ed.SetInt(0);
            this.tEdit_Kana_St.DataText = string.Empty;
            this.tEdit_Kana_Ed.DataText = string.Empty;
            this.tEdit_SectionCode_St.DataText = string.Empty;
            this.tEdit_SectionCode_Ed.DataText = string.Empty;
            this.tEdit_EmployeeCode_St.DataText = string.Empty;
            this.tEdit_EmployeeCode_Ed.DataText = string.Empty;
            this.tNedit_SalesAreaCode_St.SetInt(0);
            this.tNedit_SalesAreaCode_Ed.SetInt(0);
            this.tNedit_BusinessTypeCode_St.SetInt(0);
            this.tNedit_BusinessTypeCode_Ed.SetInt(0);
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
        /// <br>Programmer	: 馮文雄</br>
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //得意先(開始)
                case "tNedit_CustomerCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_CustomerCode_St.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.CustomerStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //得意先(終了)
                case "tNedit_CustomerCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_CustomerCode_Ed.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tEdit_Kana_St;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.CustomerEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //拠点(開始)
                case "tEdit_SectionCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tEdit_SectionCode_St.DataText))
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tEdit_SectionCode_Ed;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.SectionStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //拠点(終了)
                case "tEdit_SectionCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tEdit_SectionCode_Ed.DataText))
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tEdit_EmployeeCode_St;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.SectionEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //担当者(開始)
                case "tEdit_EmployeeCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tEdit_EmployeeCode_St.DataText))
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.EmployeeStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //担当者(終了)
                case "tEdit_EmployeeCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tEdit_EmployeeCode_Ed.DataText))
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_SalesAreaCode_St;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.EmployeeEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //地区(開始)
                case "tNedit_SalesAreaCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SalesAreaCode_St.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.AreaStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //地区(終了)
                case "tNedit_SalesAreaCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_SalesAreaCode_Ed.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_BusinessTypeCode_St;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.AreaEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                //業種(開始)
                case "tNedit_BusinessTypeCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_BusinessTypeCode_St.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_BusinessTypeCode_Ed;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.BusinessTypeCodeSt_Button;
                                }
                            }
                        }
                        break;
                    }
                //業種(終了)
                case "tNedit_BusinessTypeCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_BusinessTypeCode_Ed.GetInt() > 0)
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.tNedit_CustomerCode_St;
                                }
                                else
                                {
                                    // フォーカス設定
                                    e.NextCtrl = this.BusinessTypeCodeEd_Button;
                                }
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
        /// <param name="errCtrl">Control</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 馮文雄</br>
        /// <br>Date		: 2011.07.27</br>
        /// </remarks>
        private bool ScreenInputCheck(out Control errCtrl, ref string errMessage)
        {
            bool status = true;
            errCtrl = null;
            const string ct_RangeError = "の範囲が不正です。";

            //得意先範囲チェック
            if (this.tNedit_CustomerCode_Ed.GetInt() > 0 && this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
            {
                errMessage = this.ultraLabel_Customer.Text + ct_RangeError;
                errCtrl = tNedit_CustomerCode_St;
                status = false;
                return status;
            }
            //カナ範囲チェック
            if (!string.IsNullOrEmpty(this.tEdit_Kana_Ed.DataText.Trim()) &&
                0 < this.tEdit_Kana_St.DataText.CompareTo(this.tEdit_Kana_Ed.DataText))
            {
                errMessage = this.ultraLabel_Kana.Text + ct_RangeError;
                errCtrl = tEdit_Kana_St;
                status = false;
                return status;
            }
            //拠点範囲チェック
            if (!string.IsNullOrEmpty(this.tEdit_SectionCode_Ed.DataText.Trim()) &&
                0 < this.tEdit_SectionCode_St.DataText.CompareTo(this.tEdit_SectionCode_Ed.DataText))
            {
                errMessage = this.ultraLabel_Section.Text + ct_RangeError;
                errCtrl = tEdit_SectionCode_St;
                status = false;
                return status;
            }
            //担当者範囲チェック
            if (!string.IsNullOrEmpty(this.tEdit_EmployeeCode_Ed.DataText.Trim()) &&
                0 < this.tEdit_EmployeeCode_St.DataText.CompareTo(this.tEdit_EmployeeCode_Ed.DataText))
            {
                errMessage = this.ultraLabel_Employee.Text + ct_RangeError;
                errCtrl = tEdit_EmployeeCode_St;
                status = false;
                return status;
            }
            //地区範囲チェック
            if (this.tNedit_SalesAreaCode_Ed.GetInt() > 0 && this.tNedit_SalesAreaCode_St.GetInt() > this.tNedit_SalesAreaCode_Ed.GetInt())
            {
                errMessage = this.ultraLabel_Area.Text + ct_RangeError;
                errCtrl = tNedit_SalesAreaCode_St;
                status = false;
                return status;
            }
            //業種範囲チェック
            if (this.tNedit_BusinessTypeCode_Ed.GetInt() > 0 && this.tNedit_BusinessTypeCode_St.GetInt() > this.tNedit_BusinessTypeCode_Ed.GetInt())
            {
                errMessage = this.ultraLabel_BusinessType.Text + ct_RangeError;
                errCtrl = tNedit_BusinessTypeCode_St;
                status = false;
                return status;
            }
            return status;
        }

        /// <summary>
        /// Control.Click イベント(CustomerGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 得意先ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011.07.27</br>
        /// </remarks>
        private void CustomerStGuide_Button_Click(object sender, EventArgs e)
        {
            this._customerGuidOK = false;
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (this._customerGuidOK)
            {
                this.tNedit_CustomerCode_Ed.Focus();
            }
        }

        /// <summary>
        /// Control.Click イベント(CustomerGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 得意先ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011.07.27</br>
        /// </remarks>
        private void CustomerEdGuide_Button_Click(object sender, EventArgs e)
        {
            this._customerGuidOK = false;
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (this._customerGuidOK)
            {
                this.tEdit_Kana_St.Focus();
            }
        }

        /// <summary>
		/// 得意先選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // 取得した得意先コード(開始)を画面に表示する
            this.tNedit_CustomerCode_St.SetInt(customerSearchRet.CustomerCode);
            this._customerGuidOK = true;
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // 取得した得意先コード(終了)を画面に表示する
            this.tNedit_CustomerCode_Ed.SetInt(customerSearchRet.CustomerCode);
            this._customerGuidOK = true;
        }

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011.07.27</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet = new SecInfoSet();

                status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    //取得した拠点コードを画面に表示する
                    if ("SectionStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tEdit_SectionCode_St.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_SectionCode_Ed.Focus();
                    }
                    else
                    {
                        this.tEdit_SectionCode_Ed.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_EmployeeCode_St.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(EmployeeGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 担当者ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011.07.27</br>
        /// </remarks>
        private void EmployeeGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Employee employee = new Employee();

                status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);
                if (status == 0)
                {
                    //取得した担当者コードを画面に表示する
                    if ("EmployeeStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tEdit_EmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_EmployeeCode_Ed.Focus();
                    }
                    else
                    {
                        this.tEdit_EmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                        this.tNedit_SalesAreaCode_St.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(AreaGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 地区ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011.07.27</br>
        /// </remarks>
        private void AreaGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdBd userGdBd = new UserGdBd();
                UserGdHd userGdHd = new UserGdHd();

                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);
                if (status == 0)
                {
                    //取得した地区コードを画面に表示する
                    if ("AreaStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_SalesAreaCode_St.SetInt(userGdBd.GuideCode);
                        this.tNedit_SalesAreaCode_Ed.Focus();
                    }
                    else
                    {
                        this.tNedit_SalesAreaCode_Ed.SetInt(userGdBd.GuideCode);
                        this.tNedit_BusinessTypeCode_St.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(BusinessTypeGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 業種ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 馮文雄</br>
        /// <br>Date        : 2011.07.27</br>
        /// </remarks>
        private void BusinessTypeGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdBd userGdBd = new UserGdBd();
                UserGdHd userGdHd = new UserGdHd();

                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);
                if (status == 0)
                {
                    //取得した業種コードを画面に表示する
                    if ("BusinessTypeCodeSt_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_BusinessTypeCode_St.SetInt(userGdBd.GuideCode);
                        this.tNedit_BusinessTypeCode_Ed.Focus();
                    }
                    else
                    {
                        this.tNedit_BusinessTypeCode_Ed.SetInt(userGdBd.GuideCode);
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
        /// <br>Programmer	: 馮文雄</br>
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
		private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// 常にキャンセル
			e.Cancel = true;
		}
		/// <summary>
		/// グループ縮小
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// 常にキャンセル
			e.Cancel = true;
		}
		# endregion ■  ■
    }
}