//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 入金伝票番号入力
// プログラム概要   : 入金伝票番号入力の検索を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 王君
// 修 正 日  2012/12/24  修正内容 : 2013/03/13配信分 Redmine#33741の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 入金伝票番号入力コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入金伝票番号の入力を行うコントロールクラスです。</br>
    /// <br>Programmer : 王君</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>             Redmine#33741の対応</br>
    /// <br>Date       : 2012/12/24</br>
    /// <br></br>
    /// </remarks>
    public partial class SFUKK01403UD : Form
    {
        #region[Private Members]

        /// <summary>入金伝票入力画面(入金型)アクセスクラス</summary>
        private InputDepositNormalTypeAcs inputDepositNormalTypeAcsUD;

        private InputDepositNormalTypeAcs.SearchDepositParameter searchDepParameter;

        /// <summary>得意先情報クラス</summary>
        private CustomerInfoAcs _customerInfoAcs;

        /// <summary>入金検索結果</summary>
        private int _status;

        /// <summary>検索</summary>
        private bool _flag;

        /// <summary>ログイン担当者</summary>
        private Employee _employee;

        /// <summary>拠点アクセスクラス</summary>
        private SecInfoSetAcs _secInfoSetAcs = new SecInfoSetAcs();

        #endregion

        # region Dispose

        /// <summary>
        /// 入金伝票入力（入金型）入金伝票呼出ガイド
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入金伝票入力（入金型）入金伝票呼出ガイドＵＩの機能を実装します。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        public SFUKK01403UD(InputDepositNormalTypeAcs.SearchDepositParameter searchDepositParameter, InputDepositNormalTypeAcs inputDepositNormalTypeAcs)
        {
            InitializeComponent();
            this.searchDepParameter = searchDepositParameter;
            this._customerInfoAcs = new CustomerInfoAcs();
            this.inputDepositNormalTypeAcsUD = inputDepositNormalTypeAcs;
        }

        /// <summary>
        /// 検索status
        /// </summary>
        public int status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        /// 検索status
        /// </summary>
        public bool flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        /// <summary>
        /// ログイン担当者
        /// </summary>
        public Employee Employee
        {
            set { _employee = value; }
            get { return _employee; }
        }
        # endregion

        #region[Private Event]
        /// <summary>
        /// 確定ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 確定ボタンクリックイベント。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            if (saveCheck())
            {
                this.flag = true;
                string message;
                searchDepParameter.DepositSlipNo = this.tNedit_SalesSlipNum.GetInt();
                
                this.status = inputDepositNormalTypeAcsUD.SearchDepositOnlyMode(searchDepParameter, out message);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            CustomerInfo customerInfo;
                            DataTable dt = inputDepositNormalTypeAcsUD.GetDsDepositInfo().Tables[InputDepositNormalTypeAcs.ctDepositDataTable];
                            //伝票の得意先コード
                            int customerCode = Convert.ToInt32(dt.Rows[0][InputDepositNormalTypeAcs.ctCustomerCode].ToString());
                            //得意先情報取得処理
                            status = GetCustomerInfo(out customerInfo, customerCode);
                            if (status == 0)
                            {
                                // 納入先入力チェック
                                if (customerInfo.IsCustomer != true)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "納入先は入力できません。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    inputDepositNormalTypeAcsUD.ClearDsDepositInfo();
                                    this.tNedit_SalesSlipNum.Clear();
                                    this.tNedit_SalesSlipNum.Focus();
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                    break;
                                }
                                else
                                {
                                    int claimCode = customerInfo.ClaimCode;
                                    CustomerInfo claimInfo;
                                    status = GetCustomerInfo(out claimInfo, claimCode);
                                    if (claimInfo.IsCustomer != true)
                                    {
                                        TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "納入先は入力できません。",
                                        -1,
                                        MessageBoxButtons.OK);
                                        inputDepositNormalTypeAcsUD.ClearDsDepositInfo();
                                        this.tNedit_SalesSlipNum.Clear();
                                        this.tNedit_SalesSlipNum.Focus();
                                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                        break;
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.OK;
                                    }
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "得意先は存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);
                                inputDepositNormalTypeAcsUD.ClearDsDepositInfo();
                                this.tNedit_SalesSlipNum.Clear();
                                this.tNedit_SalesSlipNum.Focus();
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                break;
                            } 
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            //入金伝票が存在しなかった時
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                              this.Name,
                                              message,
                                              0,
                                              MessageBoxButtons.OK);
                            this.tNedit_SalesSlipNum.Clear();
                            this.tNedit_SalesSlipNum.Focus();
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                          this.Name,
                                          "入金伝票の読込処理に失敗しました。" + "\r\n\r\n" + message,
                                          status,
                                          MessageBoxButtons.OK);
                            return;
                        }
                }
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                 this.Name,
                                                 "入金伝票番号が未入力です。",
                                                 0,
                                                 MessageBoxButtons.OK);
                this.tNedit_SalesSlipNum.Focus();
            }
        }

        /// <summary>
        /// 閉じるボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンクリックイベント</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// キーコントロール イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : キーが押された時に発生します。 </br>
        /// <br>Programmer  : 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            switch (e.PrevCtrl.Name)
            {
                case "tNedit_SalesSlipNum":
                    {
                        if (this.tNedit_SalesSlipNum.GetInt() != 0)
                        {
                            if (e.ShiftKey == false && e.Key == Keys.Enter)
                            {
                                uButton_Save_Click(uButton_Save, new EventArgs());
                                if (this.status != 0)
                                {
                                    e.NextCtrl = this.tNedit_SalesSlipNum;
                                }
                                return;
                            }
                        }
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.Btn_SalesSlipGuide;
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : ユーザーがフォームを読み込む時に発生します。</br>
        /// <br>Programmer  : 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private void SFUKK01403UD_Load(object sender, EventArgs e)
        {
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.flag = false;
            this.status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            this.tEdit1.Text = "入金";
            this.tNedit_SalesSlipNum.Focus();
            this.Btn_SalesSlipGuide.ImageList = imageList16;
            this.Btn_SalesSlipGuide.Appearance.Image = Size16_Index.STAR1;
        }

        private void uButton_SalesSlipGuide_Click(object sender, EventArgs e)
        {
            string sectionCode = this._employee.BelongSectionCode.TrimEnd();
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.Read(out sectionInfo, this.searchDepParameter.EnterpriseCode, sectionCode);
            SFUKK01403UE sFUKK01403UE = new SFUKK01403UE();
            sFUKK01403UE.SearchDepositParameter = this.searchDepParameter;
            sFUKK01403UE.InputDepositNormalTypeAcsUE = this.inputDepositNormalTypeAcsUD;
            sFUKK01403UE.SectionCode = sectionInfo.SectionCode.TrimEnd();
            sFUKK01403UE.SectionName = sectionInfo.SectionGuideNm.Trim();
            sFUKK01403UE.ShowDialog();
            if (sFUKK01403UE.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
            }
        }
        #endregion

        #region[private methord]

        /// <summary>
        /// 入金伝票番号のチェック。
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 入金伝票番号をチェックする。</br>
        /// <br>Programmer  : 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private bool saveCheck()
        {
            if (this.tNedit_SalesSlipNum.GetInt() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 得意先情報取得処理
        /// </summary>
        /// <param name="customerInfo">得意先情報オブジェクト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 得意先コードから対象の得意先情報を取得します。 </br>
        /// <br>Programmer  : 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private int GetCustomerInfo(out CustomerInfo customerInfo, int customerCode)
        {
            string enterpriseCode = searchDepParameter.EnterpriseCode;
            customerInfo = new CustomerInfo();
            int status;
            try
            {
                status = this._customerInfoAcs.ReadDBData(enterpriseCode, customerCode, true, out customerInfo);
            }
            catch
            {
                status = -1;
                customerInfo = null;
            }
            return (status);
        }
        #endregion
     
    }
}