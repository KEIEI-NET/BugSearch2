//**********************************************************************//
// システム         ：PM.NS
// プログラム名称   ：得意先コード設定の引用
// プログラム概要   ：得意先コード設定の引用
// ---------------------------------------------------------------------//
//					Copyright(c) 2011 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011.08.04  修正内容 : 新規作成       
// ---------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先コード引用のフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Node        :  得意先コード引用のフォームクラスです。</br>
    /// <br>Programmer  : 黄海霞</br>
    /// <br>Date        : 2011.08.04 </br>
    /// </remarks>
    public partial class PMPCC09010UB : Form
    {
        /// <summary>
        /// 得意先コード引用のフォームクラス
        /// </summary>
        /// <param name="pccCmpnyStTable">PCC自社設定</param>
        /// <remarks>
        /// <br>Node        :  得意先コード引用のフォームクラスです。</br>
        /// <br>Programmer  : 黄海霞</br>
        /// <br>Date        : 2011.08.04 </br>
        /// </remarks>
        public PMPCC09010UB(Hashtable pccCmpnyStTable)
        {
            InitializeComponent();
            _customerInfoAcs = new CustomerInfoAcs();
            this.DialogResult = DialogResult.Cancel;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            // ガイドボタンのアイコン設定
            this.uButton_CustomerGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.Save_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.DECISION];
            this.Cancel_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.UNDO];
            this._pccCmpnyStTable = pccCmpnyStTable;
            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._pccInqCondition = string.Empty;
            InitCustomer();
            this.tNedit_CustomerCode.Focus();
        }
       
        /// <summary>
        /// 得意先コード
        /// </summary>
        private int _customCode;
        //問合せ元企業コード
        private string _inqOriginalEpCd = string.Empty;
        //問合せ元拠点コード
        private string _inqOriginalSecCd = string.Empty;
        //問合せ
        private string _pccInqCondition;
        //前問合せ元企業コード
        private string _inqOriginalEpCdPre = string.Empty;
        //前問合せ元拠点コード
        private string _inqOriginalSecCdPre = string.Empty;
        private int _preCustomCode = 0;
        private CustomerInfoAcs _customerInfoAcs;
        private string _enterpriseCode;
        private string _sectionCode;
        /// <summary>
        /// PCC自社設定
        /// </summary>
        private Hashtable _pccCmpnyStTable = null;
        // 得意先テープル
        private Dictionary<int, PccCmpnySt> _customerHTable;
        private PccCmpnyStAcs _pccCmpnyStAcs = null;
        private const string CUSTOMEMPTY_BASE = "ベース設定";
        /// <summary>
        /// 得意先コード
        /// </summary>
        public int CustomCode
        {
            get { return this._customCode; }
            set { this._customCode = value; }
        }

        /// <summary>
        /// 得意先
        /// </summary>
        public string PccInqCondition
        {
            get { return this._pccInqCondition; }
            set { this._pccInqCondition = value; }
        }

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 黄海霞</br>
        /// <br>Date        : 2011.08.04 </br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.tNedit_CustomerCode.Focus();
            this.Close();
        }

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 確定ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer  : 黄海霞</br>
        /// <br>Date        : 2011.08.04 </br>
        /// </remarks>
        private void Save_Button_Click(object sender, EventArgs e)
        {

            //必須入力チェック
            int customerCode = this.tNedit_CustomerCode.GetInt();

            if (_pccCmpnyStTable == null || !_pccCmpnyStTable.ContainsKey(this._pccInqCondition))
            {
                //メインに戻る
                TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                           this.Name,						    // アセンブリＩＤまたはクラスＩＤ
                          "マスタに未登録ため引用できません。", 	// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                InitCustomer();
                this.tNedit_CustomerCode.Focus();
                return;
            }
            else
            {
                if (_pccCmpnyStTable[_pccInqCondition] != null)
                {
                    PccCmpnySt pccCmpnySt = _pccCmpnyStTable[_pccInqCondition] as PccCmpnySt;
                    if (pccCmpnySt.LogicalDeleteCode == 1)
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                           this.Name,						    // アセンブリＩＤまたはクラスＩＤ
                          //"入力されたコードのPCC自社設定マスタ情報は既に削除されています。", 	// 表示するメッセージ　//DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                          "入力されたコードのBLﾊﾟｰﾂｵｰﾀﾞｰ自社設定マスタ情報は既に削除されています。", 　//ADD BY wujun FOR Redmine#25173 ON 2011.09.15　
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン

                        // PCC品目設定マスタメンテコードのクリア
                        InitCustomer();
                        this.tNedit_CustomerCode.Focus();
                        return;
                    }
                }
            }

            this._customCode = customerCode;
            this._pccInqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() //@@@@20230303
                + this._enterpriseCode.TrimEnd() + this._sectionCode.TrimEnd();
            this.DialogResult = DialogResult.OK;
            this.tNedit_CustomerCode.Focus();
            this.Close();
        }

        /// <summary>
        /// 得意先ガイドボタンクリックイベント（オーバーロード）
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンクリックイベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // 得意先ガイド表示
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY, PMKHN04005UA.PCCUOE_MASTER_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);

            DialogResult result = customerSearchForm.ShowDialog(this);
        }

        #region 得意先選択ガイドボタンクリック時イベント

        /// <summary>
        /// 得意先選択ガイドボタンクリック時発生イベント
        /// </summary>
        /// <param name="sender">PMKHN4002Eフォームオブジェクト</param>
        /// <param name="customerSearchRet">得意先情報戻り値クラス(PMKHN4002E)</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンクリックイベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // イベントハンドラを渡した相手から戻り値クラスを受け取れなければ終了
            if (customerSearchRet == null) return;

            // DBデータを読み出す(キャッシュを使用)
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode);

            // ステータスによりエラーメッセージを出力
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (customerInfo == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "選択した得意先は得意先情報入力が行われていない為、使用出来ません。",
                        status, MessageBoxButtons.OK);
                    return;
                }


            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "選択した得意先は既に削除されています。",
                    status, MessageBoxButtons.OK);
                return;
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                    "得意先情報の取得に失敗しました。",
                    status, MessageBoxButtons.OK);
                return;
            }

            // 得意先情報をUIに設定
            this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
            this.uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();
            this.tNedit_CustomerCode.Enabled = true;
            this.uButton_CustomerGuide.Enabled = true;
            this._inqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
            this._inqOriginalSecCd = customerInfo.CustomerSecCode;
            //前問合せ元企業コード
            this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
            //前問合せ元拠点コード
            this._inqOriginalSecCdPre = this._inqOriginalSecCd;
            this._pccInqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() //@@@@20230303
                + this._enterpriseCode.TrimEnd() + this._sectionCode.TrimEnd();
        }
        #endregion

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンクリックイベントを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            // PrevCtrl設定
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
            // 名前により分岐
            switch (prevCtrl.Name)
            {
                #region 得意先コード
                // 得意先コード
                case "tNedit_CustomerCode":
                    {
                        int inputValue = tNedit_CustomerCode.GetInt();

                        PccCmpnySt pccCmpnySt;
                        if (_customerHTable == null || !_customerHTable.ContainsKey(inputValue))
                        {
                            this.GetCustomerHTable();
                        }
                        if (_customerHTable != null && _customerHTable.Count > 0 && _customerHTable.ContainsKey(inputValue))
                        {
                            pccCmpnySt = _customerHTable[inputValue];
                            this.uLabel_CustomerName.Text = pccCmpnySt.PccCompanyName.TrimEnd();
                            _preCustomCode = inputValue;
                            this._inqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                            this._inqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                            //前問合せ元企業コード
                            this._inqOriginalEpCdPre = this._inqOriginalEpCd.Trim();//@@@@20230303
                            //前問合せ元拠点コード
                            this._inqOriginalSecCdPre = this._inqOriginalSecCd;
                            this._pccInqCondition = this._inqOriginalEpCd.Trim() + this._inqOriginalSecCd.TrimEnd() //@@@@20230303
                                + this._enterpriseCode.TrimEnd() + this._sectionCode.TrimEnd();

                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                //"PCC自社設定マスタに未登録の為、この得意先は設定できません。\r\n [" + inputValue + "] ",　//DEL BY wujun FOR Redmine#25173 ON 2011.09.15
                                "BLﾊﾟｰﾂｵｰﾀﾞｰ自社設定マスタに未登録の為、この得意先は設定できません。\r\n [" + inputValue + "] ",　//ADD BY wujun FOR Redmine#25173 ON 2011.09.15　
                                -1,
                                MessageBoxButtons.OK);
                            tNedit_CustomerCode.SetInt(_preCustomCode);
                            e.NextCtrl = e.PrevCtrl;
                        }

                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (String.IsNullOrEmpty(this.tNedit_CustomerCode.Text.Trim()))
                                        {
                                            e.NextCtrl = this.uButton_CustomerGuide;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_CustomerGuide;
                                        }
                                        break;
                                    }
                            }

                        }

                        break;
                    }
                #endregion
                case "uButton_CustomerGuide":
                    {
                        if (e.Key == Keys.Right)
                        {
                            e.NextCtrl = uButton_CustomerGuide;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// 画面のクリア
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面のクリアを行います。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04 </br>
        /// </remarks>
        private void InitCustomer()
        {
            this.tNedit_CustomerCode.Clear();
            uLabel_CustomerName.Text = string.Empty;
            //前問合せ元企業コード
            this._inqOriginalEpCdPre = string.Empty;
            //前問合せ元拠点コード
            this._inqOriginalSecCdPre = string.Empty;
            //問合せ元企業コード
            this._inqOriginalEpCd = string.Empty;
            //問合せ元拠点コード
            this._inqOriginalSecCd = string.Empty;
            this._preCustomCode = 0;
            this._pccInqCondition = string.Empty;
        }

        #region 自社設定得意先設定マスタ取得処理
        /// <summary>
        /// 自社設定設定マスタ取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自社設定得意先設定マスタを取得します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public void GetCustomerHTable()
        {
            if (this._pccCmpnyStAcs == null)
            {
                _pccCmpnyStAcs = new PccCmpnyStAcs();
            }
            PccCmpnySt parsePccCmpnySt = new PccCmpnySt();
            parsePccCmpnySt.InqOtherEpCd = this._enterpriseCode;
            parsePccCmpnySt.InqOtherSecCd = this._sectionCode;
            List<PccCmpnySt> pccCmpnyStList = null;
            if (this._customerHTable == null)
            {
                this._customerHTable = new Dictionary<int, PccCmpnySt>();
            }
            else
            {
                this._customerHTable.Clear();
            }
            PccCmpnySt pccCmpnySt0 = new PccCmpnySt();
            pccCmpnySt0.PccCompanyCode = 0;
            pccCmpnySt0.PccCompanyName = CUSTOMEMPTY_BASE;
            pccCmpnySt0.InqOtherEpCd = this._enterpriseCode;
            pccCmpnySt0.InqOtherSecCd = this._sectionCode;
            pccCmpnySt0.InqOriginalEpCd = string.Empty;
            pccCmpnySt0.InqOriginalSecCd = string.Empty;
            this._customerHTable.Add(pccCmpnySt0.PccCompanyCode, pccCmpnySt0);
            int status = this._pccCmpnyStAcs.Search(out pccCmpnyStList, parsePccCmpnySt, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (PccCmpnySt pccCmpnySt in pccCmpnyStList)
                {
                    if (!this._customerHTable.ContainsKey(pccCmpnySt.PccCompanyCode))
                    {
                        this._customerHTable.Add(pccCmpnySt.PccCompanyCode, pccCmpnySt);
                    }
                }
            }

        }
        #endregion
    }
}