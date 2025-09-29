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
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/02/10  修正内容 : ③拠点入力時にスペースカット
//                                  ④設定マスタ該当無し時のサンプル取込画面に
//                                    基本条件の拠点・得意先を初期表示
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田靖之
// 作 成 日  2015/02/16  修正内容 : システムテスト障害#218
//                                  ・サンプル取込で未入力などのメッセージが表示されることがある
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/03/03  修正内容 : Redmine#308 得意先の全得意先対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/03/04  修正内容 : Redmine#323 サンプル取込時に全得意先を指定した場合の
//                                              既存データ検索条件を修正
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/03/06  修正内容 : Redmine#338 全得意先設定内容を定数化
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Collections;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using System.Diagnostics;
using System.Threading;

namespace Broadleaf.Windows.Forms
{
    public partial class PMREC09011UC : Form
    {
        # region Private Members
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        private RecGoodsLkStAcs _recGoodsLkStAcs = null;

        // 得意先関連
        private bool _cusotmerGuideSelected; // 得意先ガイド選択フラグ
        private int _prevCusotmerCd = 0;

        //拠点関連
        private bool _sectionGuideSelected; // 拠点ガイド選択フラグ
        private string _prevSectionCd = string.Empty;

        private string _sampleSecCd = string.Empty;
        private string _sampleSecNm = string.Empty;
        private CustomerInfo _sampleCustomerInfo = null;

        public string SampleSecCd
        {
            get { return this._sampleSecCd; }
            set { this._sampleSecCd = value; }
        }
        public string SampleSecNm
        {
            get { return this._sampleSecNm; }
            set { this._sampleSecNm = value; }
        }
        public CustomerInfo SampleCustomerInfo
        {
            get { return this._sampleCustomerInfo; }
            set { this._sampleCustomerInfo = value; }
        }

        #endregion


        #region [ コンストラクタ ]
        /// <summary>
        /// 選択画面コンストラクタ
        /// </summary>
        public PMREC09011UC()
        {
            InitializeComponent();
            InitializeForm();

            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._recGoodsLkStAcs = new RecGoodsLkStAcs();
            this._recGoodsLkStAcs.LoadMstData();

            // --- ADD 2015/02/16 Y.Wakita RedMine#218 ------------------------------>>>>>
            while (this._recGoodsLkStAcs.MasterAcsThread.ThreadState == System.Threading.ThreadState.Running)
            {
                Thread.Sleep(100);
            }
            // --- ADD 2015/02/16 Y.Wakita RedMine#218 ------------------------------<<<<<
        }
        #endregion

        #region [ 初期処理 ]
        private void InitializeForm()
        {
            // ステータスバーの初期化
            StatusBar.Panels[0].Text = "";

            // ツールバーのイメージ(16x16)やメッセージを設定する
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            ToolbarsManager.Tools["Button_Guide"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;

            #region ガイドボタン
            this.uButton_SectionGuide.ImageList = IconResourceManagement.ImageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_CustomerGuide.ImageList = IconResourceManagement.ImageList16;
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            #endregion
        }
        #endregion


        #region [ フォームイベント処理 ]
        // --- ADD 2015/02/10④ T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// FormShown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMREC09011UC_Shown(object sender, EventArgs e)
        {
            this.tEdit_SectionCodeAllowZero.Text = this._sampleSecCd;
            this.uLabel_SectionName.Text = this._sampleSecNm;
            // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
            //this.tNedit_CustomerCodeAllowZero.DataText = this._sampleCustomerInfo.CustomerCode.ToString();
            if (this._sampleCustomerInfo.CustomerCode >= 0)
            {
                this.tNedit_CustomerCodeAllowZero.DataText = this._sampleCustomerInfo.CustomerCode.ToString().PadLeft(8, '0');
            }
            // --- UPD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
            this.uLabel_CustomerName.Text = this._sampleCustomerInfo.CustomerSnm;
        }
        // --- ADD 2015/02/10④ T.Miyamoto ------------------------------<<<<<
        /// <summary>
        /// ESCキー押下による終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMREC09011UC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
        #endregion

        #region [ ツールバーイベント処理 ]
        /// <summary>
        /// ツールボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Button_Select": // 確定
                    if (this.SetResult())
                    {
                        DialogResult = DialogResult.OK;
                    }
                    break;

                case "Button_Back":   // 戻る
                    DialogResult = DialogResult.Cancel;
                    break;
                case "Button_Guide":   // ガイド
                    this.GuideStart();
                    break;
            }
        }
        #endregion

        /// <summary>
        /// ガイド起動処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ガイド起動処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void GuideStart()
        {
            // 拠点
            if (this.tEdit_SectionCodeAllowZero.Focused)
            {
                this.uButton_SectionGuide_Click(this.tEdit_SectionCodeAllowZero, new EventArgs());
            }
            // 得意先
            else if (this.tNedit_CustomerCodeAllowZero.Focused)
            {
                this.uButton_CustomerGuide_Click(this.tNedit_CustomerCodeAllowZero, new EventArgs());
            }
        }

        /// <summary>
        /// 拠点ガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドボタン</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        /// <summary>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.Trim();
                    this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();
                    tNedit_CustomerCodeAllowZero.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 得意先ガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタン</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        /// <summary>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 得意先ガイド
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.CustomerCheck_sample(this.tNedit_CustomerCodeAllowZero.GetInt(), false);
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            // 得意先コード
            this.tNedit_CustomerCodeAllowZero.SetInt(customerSearchRet.CustomerCode);

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// フォーカス変換処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォーカス変換処理。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // 名前により分岐
            switch (e.PrevCtrl.Name)
            {
                #region 拠点コード
                case "tEdit_SectionCodeAllowZero":
                    {
                        string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.PadLeft(2, '0');
                        if (!this.SectionCheck_sample(sectionCode))
                        {
                            e.NextCtrl = e.PrevCtrl; //フォーカス移動無し
                            this.tEdit_SectionCodeAllowZero.SelectAll();
                            break;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_SectionCodeAllowZero.DataText.Trim() == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_SectionGuide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_CustomerCodeAllowZero;
                                }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        break;
                    }
                #endregion

                #region 拠点ガイドボタン
                case "uButton_SectionGuide":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_CustomerCodeAllowZero;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                            }
                        }
                        break;
                    }
                #endregion

                #region 得意先コード
                case "tNedit_CustomerCodeAllowZero":
                    {
                        if (!this.CustomerCheck_sample(this.tNedit_CustomerCodeAllowZero.GetInt(), false))
                        {
                            e.NextCtrl = e.PrevCtrl; //フォーカス移動無し
                            break;
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_CustomerCodeAllowZero.DataText.Trim() == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_CustomerGuide;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_SectionCodeAllowZero.DataText.Trim() == string.Empty)
                                {
                                    e.NextCtrl = this.uButton_SectionGuide;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region 得意先ガイドボタン
                case "uButton_CustomerGuide":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = null;
                            }
                            else if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_CustomerCodeAllowZero;
                            }
                        }
                        break;
                    }
                #endregion
            }
        }

        /// <summary>
        /// 拠点チェック処理
        /// </summary>
        public bool SectionCheck_sample(string sectionCode)
        {
            string errMsg;
            SecInfoSet retSectionInfo;

            bool checkResult = this._recGoodsLkStAcs.CheckSection(sectionCode, false, out errMsg, out retSectionInfo);
            if (checkResult)
            {
                //拠点クリア
                this.tEdit_SectionCodeAllowZero.Clear();
                this.uLabel_SectionName.Text = "";
                this._prevSectionCd = "";

                if (sectionCode == "00")
                {
                    this._prevSectionCd = sectionCode;
                    this.tEdit_SectionCodeAllowZero.Text = sectionCode; //拠点コード
                    this.uLabel_SectionName.Text = "全社共通";  //拠点略称

                    this._sampleSecCd = sectionCode;
                    this._sampleSecNm = "全社共通";
                }
                else
                {
                    if (retSectionInfo != null)
                    {
                        this._prevSectionCd = sectionCode;
                        // --- UPD 2015/02/10③ T.Miyamoto ------------------------------>>>>>
                        //this.tEdit_SectionCodeAllowZero.Text = retSectionInfo.SectionCode; //拠点コード
                        //this.uLabel_SectionName.Text = retSectionInfo.SectionGuideNm;      //拠点名
                        this.tEdit_SectionCodeAllowZero.Text = retSectionInfo.SectionCode.Trim(); //拠点コード
                        this.uLabel_SectionName.Text = retSectionInfo.SectionGuideNm.Trim();      //拠点名
                        // --- UPD 2015/02/10③ T.Miyamoto ------------------------------<<<<<

                        this._sampleSecCd = retSectionInfo.SectionCode;
                        this._sampleSecNm = retSectionInfo.SectionGuideNm;
                    }
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

                this.tEdit_SectionCodeAllowZero.Text = this._prevSectionCd; //拠点コード
            }
            return checkResult;
        }

        /// <summary>
        /// 得意先チェック処理
        /// </summary>
        public bool CustomerCheck_sample(int customerCode, bool chkFlg)
        {
            string errMsg;
            CustomerInfo retCustomerInfo;

            bool checkResult = this._recGoodsLkStAcs.CheckCustomer(customerCode, chkFlg, out errMsg, out retCustomerInfo);
            if (checkResult)
            {
                //得意先クリア
                this.tNedit_CustomerCodeAllowZero.Clear();
                this.uLabel_CustomerName.Text = "";

                this._prevCusotmerCd = 0;
                if (retCustomerInfo != null)
                {
                    this._prevCusotmerCd = customerCode;
                    // --- ADD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                    //this.tNedit_CustomerCodeAllowZero.SetInt(customerCode);      //得意先コード
                    this.tNedit_CustomerCodeAllowZero.DataText = customerCode.ToString().PadLeft(8, '0'); //得意先コード
                    // --- ADD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
                    this.uLabel_CustomerName.Text = retCustomerInfo.CustomerSnm; //得意先略称

                    this._sampleCustomerInfo = retCustomerInfo;
                }
                // --- ADD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------>>>>>
                if (customerCode == 0)
                {
                    this._prevCusotmerCd = customerCode;
                    // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------>>>>>
                    //this.tNedit_CustomerCodeAllowZero.DataText = "00000000";
                    //this.uLabel_CustomerName.Text = "全得意先";

                    //this._sampleCustomerInfo.CustomerCode = 0;
                    //// --- ADD 2015/03/04 T.Miyamoto Redmine#323 ------------------------------>>>>>
                    //// 全得意先の場合、以下の値が問合せ元企業・拠点コードに設定される
                    //this._sampleCustomerInfo.CustomerEpCode  = "0000000000000000"; //得意先企業コード
                    //this._sampleCustomerInfo.CustomerSecCode = "000000";           //得意先拠点コード
                    //// --- ADD 2015/03/04 T.Miyamoto Redmine#323 ------------------------------<<<<<
                    this.tNedit_CustomerCodeAllowZero.DataText = RecGoodsLkStAcs.ALL_CUSTOMERCODE;
                    this.uLabel_CustomerName.Text = RecGoodsLkStAcs.ALL_CUSTOMERNAME;
                    this._sampleCustomerInfo.CustomerCode = 0;
                    // 全得意先の場合、以下の値が問合せ元企業・拠点コードに設定される
                    this._sampleCustomerInfo.CustomerEpCode  = RecGoodsLkStAcs.ALL_ORIGINALEPCD;  //得意先企業コード
                    this._sampleCustomerInfo.CustomerSecCode = RecGoodsLkStAcs.ALL_ORIGINALSECCD; //得意先拠点コード
                    // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------<<<<<
                }
                // --- ADD 2015/03/03 T.Miyamoto Redmine#308 ------------------------------<<<<<
            }
            else
            {
                TMsgDisp.Show(this
                             , emErrorLevel.ERR_LEVEL_EXCLAMATION
                             , this.Name
                             , errMsg
                             , 0
                             , MessageBoxButtons.OK);

                this.tNedit_CustomerCodeAllowZero.SetInt(this._prevCusotmerCd);
            }
            return checkResult;
        }

        /// <summary>
        /// 確定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 確定処理。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        private bool SetResult()
        {
            string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.PadLeft(2, '0');
            if (!this.SectionCheck_sample(sectionCode))
            {
                this.tEdit_SectionCodeAllowZero.Focus();
                return false;
            }
            if (!this.CustomerCheck_sample(this.tNedit_CustomerCodeAllowZero.GetInt(), true))
            {
                this.tNedit_CustomerCodeAllowZero.Focus();
                return false;
            }
            return true;
        }
    }
}