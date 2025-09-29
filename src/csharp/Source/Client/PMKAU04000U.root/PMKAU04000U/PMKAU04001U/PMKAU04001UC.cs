using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;      // ConstantManagementの使用に必要(SFCMN00006C)
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

using System.IO;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先電子元帳残高一覧テキスト出力条件設定UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先電子元帳残高一覧テキスト出力設定UIクラスです。</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date       : 2010/04/15</br>
    /// <br></br>
    /// <br>Update Note: 2013/03/13 30744 湯上 千加子</br>
    /// <br>           : 10801804-00　出力条件の追加、テキスト出力の与信差異額の追加</br>
    /// <br>Update Note: 2013/03/29 shijx</br>
    /// <br>           : 10800003-00　2013/05/15配信分 Redmine#35205得意先電子元帳の対応</br>
    /// <br>           : ①フォーカスが拠点、得意先に指定している場合、shift+tab押下、フォーカスが移動できません</br>
    /// <br>           : ②期日の制御不正</br>
    /// <br>           : ③出力ファイル名に"\\"が有る場合、ガイド押下、エラー発生</br>
    /// <br>Update Note: 2019/08/19 陳艶丹</br>
    /// <br>           : 11570163-00 PMKOBETSU-1379 テキスト出力操作ログおよび出力時アラートメッセージ追加対応</br>
    public partial class PMKAU04001UC : Form
    {
        #region コンストラクタ
        // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
        //public PMKAU04001UC(bool excelFlg, int balanceDiv)
        public PMKAU04001UC(bool excelFlg, int balanceDiv, int RemainSectionType)
        // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<
        {
            InitializeComponent();

            _imageList16 = IconResourceManagement.ImageList16;

            uButton_SectionCodeSt.ImageList = _imageList16;
            uButton_SectionCodeSt.Appearance.Image = (int)Size16_Index.STAR1;

            uButton_SectionCodeEd.ImageList = _imageList16;
            uButton_SectionCodeEd.Appearance.Image = (int)Size16_Index.STAR1;

            uButton_CustomerCodeSt.ImageList = _imageList16;
            uButton_CustomerCodeSt.Appearance.Image = (int)Size16_Index.STAR1;

            uButton_CustomerCodeEd.ImageList = _imageList16;
            uButton_CustomerCodeEd.Appearance.Image = (int)Size16_Index.STAR1;

            uButton_FileSelect.ImageList = _imageList16;
            uButton_FileSelect.Appearance.Image = (int)Size16_Index.STAR1;

            // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
            // 抽出拠点
            tComboEditor_rl_RemainSectionType.SelectedIndex = RemainSectionType;
            // 与信残高出力チェックボックス
            uCheckEditor_CreditMoneyOutputDiv.Checked = false;
            uCheckEditor_CreditMoneyOutputDiv.Font = uLabel_BalanceDiv.Font;
            // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<

            tComboEditor_BalanceDiv.Value = balanceDiv;

            _excelFlg = excelFlg;

            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;

            totalDayCalculator.InitializeHisMonthlyAccRec();
            totalDayCalculator.GetHisTotalDayMonthlyAccRec("", out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);

            if (prevTotalMonth != DateTime.MinValue)
            {
                tDateEdit_CheckDateSt.SetDateTime(prevTotalMonth);
                tDateEdit_CheckDateEd.SetDateTime(prevTotalMonth);
            }
            else
            {
                tDateEdit_CheckDateSt.SetDateTime(DateTime.Now);
                tDateEdit_CheckDateEd.SetDateTime(DateTime.Now);
            }

            ChangeFileName();
        }
        #endregion // コンストラクタ

        #region プライベートメンバ
        string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        PrevInputValue _prevInputValue = new PrevInputValue();
        // **** ボタン用イメージリスト ****
        private ImageList _imageList16 = null;                  // イメージリスト

        private bool _excelFlg;
        //private List<int> _customerList = new List<int>(); // DEL 2010/09/26
        private List<CustomerInfo> _customerList = new List<CustomerInfo>(); // ADD 2010/09/26
        private CustPrtPprBlnce _custPrtPprBlnce = new CustPrtPprBlnce();
        private int _balanceDiv = 0;
        private string _fileName;
        private DialogResult _dialogResult = DialogResult.Cancel;
        //----- ADD 2019/08/19 陳艶丹 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ----->>>>>
        /// <summary>開始拠点コード</summary>
        private string sectionCdSt;
        /// <summary>終了拠点コード</summary>
        private string sectionCdEd;
        /// <summary>開始得意先コード</summary>
        private string customerCdSt;
        /// <summary>終了得意先コード</summary>
        private string customerCdEd;
        /// <summary>開始対象年月</summary>
        private string addUpYearMonthSt;
        /// <summary>終了対象年月</summary>
        private string addUpYearMonthEd;
        //----- ADD 2019/08/19 陳艶丹 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 -----<<<<<
        #endregion // プライベートメンバ

        // --- ADD 2010/10/09 ---------->>>>>
        # region Delegate
        /// <summary>
        /// データを出力
        /// </summary>
        /// <returns>出力結果</returns>
        internal delegate bool OutputDataEvent();
        #endregion

        # region Event
        /// <summary>データを出力イベント</summary>
        internal event OutputDataEvent OutputData;
        #endregion
        // --- ADD 2010/10/09 ----------<<<<<

        #region プロパティ
        // 対象得意先リスト
        //public List<int> CustomerList // DEL 2010/09/26
        public List<CustomerInfo> CustomerList // ADD 2010/09/26
        {
            get { return _customerList; }
            set { _customerList = value; }
        }

        // 抽出条件
        public CustPrtPprBlnce CustPrtPprBlnce
        {
            get { return _custPrtPprBlnce; }
            set { _custPrtPprBlnce = value; }
        }

        // 残高種別
        public int BalanceDiv
        {
            get { return _balanceDiv; }
            set { _balanceDiv = value; }
        }

        // 出力先ファイル名
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        // フォーム終了ステータス
        public DialogResult DResult
        {
            get { return _dialogResult; }
            set { _dialogResult = value; }
        }
        //----- ADD 2019/08/19 陳艶丹 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ----->>>>>
        /// <summary>開始拠点コード</summary>
        public string SectionCodeSt
        {
            get { return sectionCdSt; }
            set { sectionCdSt = value; }
        }

        /// <summary>終了拠点コード</summary>
        public string SectionCodeEd
        {
            get { return sectionCdEd; }
            set { sectionCdEd = value; }
        }

        /// <summary>開始得意先コード</summary>
        public string CustomerCodeSt
        {
            get { return customerCdSt; }
            set { customerCdSt = value; }
        }

        /// <summary>終了得意先コード</summary>
        public string CustomerCodeEd
        {
            get { return customerCdEd; }
            set { customerCdEd = value; }
        }

        /// <summary>開始対象年月</summary>
        public string AddUpYearMonthSt
        {
            get { return addUpYearMonthSt; }
            set { addUpYearMonthSt = value; }
        }

        /// <summary>終了対象年月</summary>
        public string AddUpYearMonthEd
        {
            get { return addUpYearMonthEd; }
            set { addUpYearMonthEd = value; }
        }
        //----- ADD 2019/08/19 陳艶丹 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 -----<<<<<
        #endregion // プロパティ

        #region イベント
        /// <summary>
        /// 開始得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            // フォーカス制御用、ガイド呼出前の得意先コード
            int beCustCd = this.tNedit_CustomerCode_St.GetInt();

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);

            if ((!beCustCd.Equals(this.tNedit_CustomerCode_St.GetInt())) && (this.tNedit_CustomerCode_St.Text != ""))
            {
                // ガイド呼出前と違う、クリアされていない場合
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// 終了得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            // フォーカス制御用、ガイド呼出前の得意先コード
            int beCustCd = this.tNedit_CustomerCode_Ed.GetInt();

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            customerSearchForm.ShowDialog(this);

            if ((!beCustCd.Equals(this.tNedit_CustomerCode_Ed.GetInt())) && (this.tNedit_CustomerCode_Ed.Text != ""))
            {
                // ガイド呼出前と違う、クリアされていない場合
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
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

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 取得した得意先コード(開始)を画面に表示する
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
                int inputValue = this.tNedit_CustomerCode_St.GetInt();
                int code;
                ReadCustomerName(out code, inputValue, true);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した得意先は既に削除されています。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "得意先情報の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 取得した得意先コード(終了)を画面に表示する
                this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
                int inputValue = this.tNedit_CustomerCode_Ed.GetInt();
                int code;
                ReadCustomerName(out code, inputValue, false);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した得意先は既に削除されています。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "得意先情報の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
        }

        /// <summary>
        /// 開始拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SectionCodeSt_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            SecInfoSet sectionInfo;
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            int status = secInfoSetAcs.ExecuteGuid(_enterpriseCode, true, out sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SectionCodeSt.Text = sectionInfo.SectionCode.Trim();
                string inputValue = this.tNedit_SectionCodeSt.Text.Trim();
                string code;
                ReadSectionCodeAllowZero(out code, inputValue, true);
            }
        }

        /// <summary>
        /// 終了拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SectionCodeEd_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            SecInfoSet sectionInfo;
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            int status = secInfoSetAcs.ExecuteGuid(_enterpriseCode, true, out sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SectionCodeEd.Text = sectionInfo.SectionCode.Trim();
                string inputValue = this.tNedit_SectionCodeEd.Text.Trim();
                string code;
                ReadSectionCodeAllowZero(out code, inputValue, false);
            }
        }

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2013/03/29 shijx </br>
        /// <br>            : 10800003-00　2013/05/15配信分 Redmine#35205得意先電子元帳の対応</br>
        /// <br>            : ①フォーカスが拠点、得意先に指定している場合、shift+tab押下、フォーカスが移動できません</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
            switch (prevCtrl.Name)
            {
                // 開始拠点コード
                case "tNedit_SectionCodeSt":
                    {
                        string inputValue = this.tNedit_SectionCodeSt.Text.Trim();
                        string code;
                        bool status = ReadSectionCodeAllowZero(out code, inputValue, true);
                        if (status == true)
                        {
                            this.tNedit_SectionCodeSt.Text = code;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_SectionCodeSt.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SectionCodeSt;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_SectionCodeEd;
                                            }
                                        }
                                        break;
                                }
                            }
                            //----- DEL 2013/03/29 shijx Redmine#35205① ---------->>>>>
                            //else
                            //{
                            //    switch (e.Key)
                            //    {
                            //        case Keys.Tab:
                            //            {
                            //                e.NextCtrl = null;
                            //            }
                            //            break;
                            //    }
                            //}
                            //----- DEL 2013/03/29 shijx Redmine#35205① ----------<<<<<
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "拠点コード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コード戻す
                            this.tNedit_SectionCodeSt.Text = code;
                            this.tNedit_SectionCodeSt.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 終了拠点コード
                case "tNedit_SectionCodeEd":
                    {
                        string inputValue = this.tNedit_SectionCodeEd.Text.Trim();
                        string code;
                        bool status = ReadSectionCodeAllowZero(out code, inputValue, false);
                        if (status == true)
                        {
                            this.tNedit_SectionCodeEd.Text = code;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_SectionCodeEd.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SectionCodeEd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCode_St;
                                            }
                                        }
                                        break;
                                }
                            }
                            //----- DEL 2013/03/29 shijx Redmine#35205① ---------->>>>>
                            //else
                            //{
                            //    switch (e.Key)
                            //    {
                            //        case Keys.Tab:
                            //            {
                            //                e.NextCtrl = null;
                            //            }
                            //            break;
                            //    }
                            //}
                            //----- DEL 2013/03/29 shijx Redmine#35205① ----------<<<<<
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "拠点コード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コード戻す
                            this.tNedit_SectionCodeEd.Text = code;
                            this.tNedit_SectionCodeEd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 開始得意先コード
                case "tNedit_CustomerCode_St":
                    {
                        int inputValue = this.tNedit_CustomerCode_St.GetInt();
                        int code;
                        bool status = ReadCustomerName(out code, inputValue, true);
                        if (status == true)
                        {
                            this.tNedit_CustomerCode_St.SetInt(code);

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_CustomerCode_St.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_CustomerCodeSt;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                            }
                                        }
                                        break;
                                }
                            }
                            //----- DEL 2013/03/29 shijx Redmine#35205① ---------->>>>>
                            //else
                            //{
                            //    switch (e.Key)
                            //    {
                            //        case Keys.Tab:
                            //            {
                            //                e.NextCtrl = null;
                            //            }
                            //            break;
                            //    }
                            //}
                            //----- DEL 2013/03/29 shijx Redmine#35205① ----------<<<<<
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "得意先コード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コード戻す
                            this.tNedit_CustomerCode_St.Text = code.ToString();
                            this.tNedit_CustomerCode_St.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 終了得意先コード
                case "tNedit_CustomerCode_Ed":
                    {
                        int inputValue = this.tNedit_CustomerCode_Ed.GetInt();
                        int code;
                        bool status = ReadCustomerName(out code, inputValue, false);
                        if (status == true)
                        {
                            this.tNedit_CustomerCode_Ed.SetInt(code);

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_CustomerCode_Ed.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_CustomerCodeEd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tDateEdit_CheckDateSt;
                                            }
                                        }
                                        break;
                                }
                            }
                            //----- DEL 2013/03/29 shijx Redmine#35205① ---------->>>>>
                            //else
                            //{
                            //    switch (e.Key)
                            //    {
                            //        case Keys.Tab:
                            //            {
                            //                e.NextCtrl = null;
                            //            }
                            //            break;
                            //    }
                            //}
                            //----- DEL 2013/03/29 shijx Redmine#35205① ----------<<<<<
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "得意先コード [" + inputValue + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コード戻す
                            this.tNedit_CustomerCode_Ed.Text = code.ToString();
                            this.tNedit_CustomerCode_Ed.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// キャンセルボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// OKボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2010/09/28 tianjw</br>
        /// <br>              Redmine #15080 テキスト出力対応</br>
        /// <br>Update Note: 2019/08/19 陳艶丹</br>
        /// <br>           : 11570163-00 PMKOBETSU-1379 テキスト出力操作ログおよび出力時アラートメッセージ追加対応</br>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            #region 入力チェック
            // 拠点
            // --------- UPD 2010/09/28 ------------------------------->>>>>
            //if (string.IsNullOrEmpty(_prevInputValue.SectionCodeSt))
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeSt.Text))
            // --------- UPD 2010/09/28 -------------------------------<<<<<
            {
                _prevInputValue.SectionCodeSt = "00";
            }
            // --------- UPD 2010/09/28 ------------------------------->>>>>
            //if (string.IsNullOrEmpty(_prevInputValue.SectionCodeEd))
            if (string.IsNullOrEmpty(this.tNedit_SectionCodeEd.Text))
            // --------- UPD 2010/09/28 -------------------------------<<<<<
            {
                _prevInputValue.SectionCodeEd = "00";
            }
            // --------- UPD 2010/09/28 ------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputValue.SectionCodeSt) > Convert.ToInt32(_prevInputValue.SectionCodeEd))
            if (Convert.ToInt32(_prevInputValue.SectionCodeEd) != 0 && (Convert.ToInt32(_prevInputValue.SectionCodeSt) > Convert.ToInt32(_prevInputValue.SectionCodeEd)))
            // --------- UPD 2010/09/28 -------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "開始拠点コードの値が終了拠点コードの値を上回っています。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }

            // 得意先
            // --------- UPD 2010/09/28 ------------------------------->>>>>
            //if (string.IsNullOrEmpty(_prevInputValue.CustomerCodeSt))
            if (string.IsNullOrEmpty(this.tNedit_CustomerCode_St.Text))
            // --------- UPD 2010/09/28 -------------------------------<<<<<
            {
                _prevInputValue.CustomerCodeSt = "0";
            }
            // --------- UPD 2010/09/28 ------------------------------->>>>>
            //if (string.IsNullOrEmpty(_prevInputValue.CustomerCodeEd))
            if (string.IsNullOrEmpty(this.tNedit_CustomerCode_Ed.Text))
            // --------- UPD 2010/09/28 -------------------------------<<<<<
            {
                _prevInputValue.CustomerCodeEd = "0";
            }
            // --------- UPD 2010/09/28 ------------------------------->>>>>
            //if (Convert.ToInt32(_prevInputValue.CustomerCodeSt) > Convert.ToInt32(_prevInputValue.CustomerCodeEd))
            if (Convert.ToInt32(_prevInputValue.CustomerCodeEd) != 0 && (Convert.ToInt32(_prevInputValue.CustomerCodeSt) > Convert.ToInt32(_prevInputValue.CustomerCodeEd)))
            // --------- UPD 2010/09/28 -------------------------------<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "開始得意先コードの値が終了得意先コードの値を上回っています。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // 対象年月
            int sMonth = (this.tDateEdit_CheckDateSt.GetLongDate() / 100) % 100;
            int sYear = this.tDateEdit_CheckDateSt.GetLongDate() / 10000;
            int eMonth = (this.tDateEdit_CheckDateEd.GetLongDate() / 100) % 100;
            int eYear = this.tDateEdit_CheckDateEd.GetLongDate() / 10000;

            if (sMonth == 0 || sYear == 0)
            {
                TMsgDisp.Show(
              this,
              emErrorLevel.ERR_LEVEL_INFO,
              this.Name,
              "開始対象日付が不正です。",
              -1,
              MessageBoxButtons.OK);
                return;
            }

            if (eMonth == 0 || eYear == 0)
            {
                TMsgDisp.Show(
              this,
              emErrorLevel.ERR_LEVEL_INFO,
              this.Name,
              "終了対象日付が不正です。",
              -1,
              MessageBoxButtons.OK);
                return;
            }

            if (this.tDateEdit_CheckDateSt.GetLongDate() > this.tDateEdit_CheckDateEd.GetLongDate())
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "開始対象日付が終了対象日付を上回っています。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // 出力ファイル名
            if (string.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "出力ファイル名を設定してください。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            #endregion  // 入力チェック
            //----- ADD 2019/08/19 陳艶丹 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ----->>>>>
            // 開始拠点コード
            this.sectionCdSt = this.tNedit_SectionCodeSt.Text;
            // 終了拠点コード
            this.sectionCdEd = this.tNedit_SectionCodeEd.Text;
            // 開始得意先コード
            this.customerCdSt = this.tNedit_CustomerCode_St.Text;
            // 終了得意先コード
            this.customerCdEd = this.tNedit_CustomerCode_Ed.Text;
            // 開始対象年月
            this.addUpYearMonthSt = this.tDateEdit_CheckDateSt.GetDateYear().ToString() + this.tDateEdit_CheckDateSt.GetDateMonth().ToString("00");
            // 終了対象年月
            this.addUpYearMonthEd = this.tDateEdit_CheckDateEd.GetDateYear().ToString() + this.tDateEdit_CheckDateEd.GetDateMonth().ToString("00");
            //----- ADD 2019/08/19 陳艶丹 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 -----<<<<<
            SetCustPrtPprBlnce();

            this.DResult = DialogResult.OK;
            // --- UPD 2010/10/09 ---------->>>>>
            //this.Close();
            bool outputRslt = true;
            if (this.OutputData != null)
            {
                outputRslt = this.OutputData();
            }
            if (outputRslt)
            {
                this.Close();
            }
            // --- UPD 2010/10/09 ----------<<<<<
        }

        /// <summary>
        /// 残高種別ValueChangeedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_BalanceDiv_ValueChanged(object sender, EventArgs e)
        {
            ChangeFileName();

            // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
            // 与信残高の出力チェックボックス
            // 請求の時
            if (Convert.ToInt32(tComboEditor_BalanceDiv.Value) == 0)
            {
                uCheckEditor_CreditMoneyOutputDiv.Enabled = false;
            }
            // 売掛の時
            else
            {
                uCheckEditor_CreditMoneyOutputDiv.Enabled = true;
            }
            // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<
        }

        /// <summary>
        /// ファイルダイアログ表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note : 2010/09/16 tianjw</br>
        /// <br>           　障害報告 #14483対応</br>
        /// <br>Update Note : 2013/03/29 zhaimm</br>
        /// <br>            : 10800003-00　2013/05/15配信分 Redmine#35205得意先電子元帳の対応</br>
        /// <br>            : ③出力ファイル名に"\\"が有る場合、ガイド押下、エラー発生</br>
        /// </remarks>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                //this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim(); // DEL 2013/03/29 zhaimm Redmine#35205③
                //----- ADD 2013/03/29 zhaimm Redmine#35205③ ---------->>>>>
                try
                {
                    FileInfo objFileInfo = new FileInfo(this.tEdit_SettingFileName.Text.Trim());
                    this.openFileDialog.FileName = objFileInfo.FullName;
                }
                catch (Exception)
                {
                    this.openFileDialog.FileName = string.Empty;
                }
                //----- ADD 2013/03/29 zhaimm Redmine#35205③ ----------<<<<<
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            // ------------- ADD 2010/09/16 ------------------------>>>>>
            if (_excelFlg)
            {
                this.openFileDialog.Filter = string.Format("Excelファイル(*.xls) | *.xls");
            }
            else
            {
                this.openFileDialog.Filter = string.Format("テキストファイル(*.CSV) | *.CSV");
            }
            // ------------- ADD 2010/09/16 ------------------------<<<<<
            // ファイル選択
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_SettingFileName.Text = openFileDialog.FileName.ToUpper();
            }
        }

        #endregion // イベント

        #region プライベートメンバ
        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadSectionCodeAllowZero(out string code, string inputValue, bool stFlg)
        {
            // 入力値を取得
            string sectionCode = inputValue.Trim().PadLeft(2, '0');
            code = sectionCode;

            if (stFlg)
            {
                if (_prevInputValue.SectionCodeSt == sectionCode)
                {
                    this.tNedit_SectionCodeSt.Text = sectionCode;
                    return true;
                }
            }
            else
            {
                if (_prevInputValue.SectionCodeEd == sectionCode)
                {
                    this.tNedit_SectionCodeEd.Text = sectionCode;
                    return true;
                }
            }

            // 00:全社
            if ( sectionCode == "00" )
            {
                sectionCode = "00";
                if (stFlg)
                {
                    _prevInputValue.SectionCodeSt = sectionCode;
                }
                else
                {
                    _prevInputValue.SectionCodeEd = sectionCode;
                }
                code = sectionCode;
                return true;
            }
            else if ( !String.IsNullOrEmpty( sectionCode.Trim() ) )
            {
                // 拠点情報を取得
                SecInfoSet sectionInfo;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                int status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                // ステータスが正常の場合はUIにセット
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)// DEL 2010/09/29
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) // ADD 2010/09/29
                {
                    code = sectionInfo.SectionCode.TrimEnd();
                    if (stFlg)
                    {
                        _prevInputValue.SectionCodeSt = code;
                    }
                    else
                    {
                        _prevInputValue.SectionCodeEd = code;
                    }
                    return true;
                }
                else
                {
                    if (stFlg)
                    {
                        code = _prevInputValue.SectionCodeSt;
                    }
                    else
                    {
                        code = _prevInputValue.SectionCodeEd;
                    }
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                if (stFlg)
                {
                    _prevInputValue.SectionCodeSt = code;
                }
                else
                {
                    _prevInputValue.SectionCodeEd = code;
                }
                return true;
            }
        }

        /// <summary>
        /// 得意先名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        private bool ReadCustomerName(out int code,int inputValue, bool stFlg)
        {
            int customerCode = inputValue;
            code = customerCode;

            if (stFlg)
            {
                if (_prevInputValue.CustomerCodeSt == customerCode.ToString()) return true;
            }
            else
            {
                if (_prevInputValue.CustomerCodeEd == customerCode.ToString()) return true;
            }

            if (customerCode > 0)
            {
                CustomerInfo customerInfo;
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                int status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.IsCustomer) // DEL 2010/09/29
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.IsCustomer && customerInfo.LogicalDeleteCode ==0) // ADD 2010/09/29
                {
                    if (stFlg)
                    {
                        _prevInputValue.CustomerCodeSt = customerCode.ToString();
                    }
                    else
                    {
                        _prevInputValue.CustomerCodeEd = customerCode.ToString();
                    }
                    return true;
                }
                else
                {
                    if (stFlg)
                    {
                        code = Convert.ToInt32(_prevInputValue.CustomerCodeSt);
                    }
                    else
                    {
                        code = Convert.ToInt32(_prevInputValue.CustomerCodeEd);
                    }
                    return false;
                }
            }
            else
            {
                if (stFlg)
                {
                    _prevInputValue.CustomerCodeSt = customerCode.ToString();
                }
                else
                {
                    _prevInputValue.CustomerCodeEd = customerCode.ToString();
                }
                return true;
            }
        }


        /// <summary>
        /// 前回値保持
        /// </summary>
        private struct PrevInputValue
        {
            /// <summary>開始拠点コード</summary>
            private string _sectionCodeSt;
            /// <summary>終了拠点コード</summary>
            private string _sectionCodeEd;
            /// <summary>開始得意先コード</summary>
            private string _customerCodeSt;
            /// <summary>終了得意先コード</summary>
            private string _customerCodeEd;

            /// <summary>開始拠点コード</summary>
            public string SectionCodeSt
            {
                get { return _sectionCodeSt; }
                set { _sectionCodeSt = value; }
            }

            /// <summary>終了拠点コード</summary>
            public string SectionCodeEd
            {
                get { return _sectionCodeEd; }
                set { _sectionCodeEd = value; }
            }

            /// <summary>開始得意先コード</summary>
            public string CustomerCodeSt
            {
                get { return _customerCodeSt; }
                set { _customerCodeSt = value; }
            }

            /// <summary>終了得意先コード</summary>
            public string CustomerCodeEd
            {
                get { return _customerCodeEd; }
                set { _customerCodeEd = value; }
            }
        }

        /// <summary>
        /// 抽出条件セット
        /// </summary>
        /// <br>Update Note : 2010/09/28 tianjw</br>
        /// <br>              Redmine #15080 テキスト出力対応</br>
        private void SetCustPrtPprBlnce()
        {
            // 対象拠点コード
            string[] sectionCode;
            //List<int> customerList = new List<int>(); // DEL 2010/09/26
            List<CustomerInfo> customerList = new List<CustomerInfo>(); // ADD 2010/09/26
            // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
            // 請求タイプ
            this._custPrtPprBlnce.RemainSectionType = Convert.ToInt32(tComboEditor_rl_RemainSectionType.SelectedItem.DataValue.ToString());
            // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<

            if (_prevInputValue.SectionCodeSt == _prevInputValue.SectionCodeEd)
            {
                if (_prevInputValue.SectionCodeSt == "00")
                {
                    sectionCode = null; // 全社指定
                }
                else
                {
                    sectionCode = new string[] { _prevInputValue.SectionCodeSt };
                }
                this._custPrtPprBlnce.SectionCode = sectionCode;
            }
            else
            {
                int i = Convert.ToInt32(_prevInputValue.SectionCodeSt);
                int addCnt = 0;
                string code;
                ArrayList relList;
                SecInfoSet sectionInfo;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                int status = 0;
                if (Convert.ToInt32(_prevInputValue.SectionCodeEd) != 0)
                {
                    sectionCode = new string[Convert.ToInt32(_prevInputValue.SectionCodeEd) - Convert.ToInt32(_prevInputValue.SectionCodeSt) + 1];
                    for (; i <= Convert.ToInt32(_prevInputValue.SectionCodeEd); i++)
                    {
                        code = i.ToString();
                        code = code.Trim().PadLeft(2, '0');
                        status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, code);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sectionCode[addCnt] = code;
                            addCnt++;
                        }
                    }
                    string[] retSecCode = new string[addCnt];
                    for (i = 0; i < addCnt; i++)
                    {
                        retSecCode[i] = sectionCode[i];
                    }
                    this._custPrtPprBlnce.SectionCode = retSecCode;
                }
                else 
                {
                    status = secInfoSetAcs.Search(out relList, this._enterpriseCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        sectionCode = new string[relList.Count];
                        foreach (SecInfoSet sectionCdInfo in relList)
                        {
                            if (Convert.ToInt32(_prevInputValue.SectionCodeSt) <= Convert.ToInt32(sectionCdInfo.SectionCode))
                            {
                                sectionCode[addCnt] = sectionCdInfo.SectionCode;
                                addCnt++;
                            }
                        }
                        string[] retSecCode = new string[addCnt];
                        for (i = 0; i < addCnt; i++)
                        {
                            retSecCode[i] = sectionCode[i];
                        }
                        this._custPrtPprBlnce.SectionCode = retSecCode;
                    }
                }
            }

            // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
            this._custPrtPprBlnce.CreditMoneyOutputDiv = false;
            // 与信残高出力区分が「出力する」時のみ
            if (uCheckEditor_CreditMoneyOutputDiv.Enabled && uCheckEditor_CreditMoneyOutputDiv.Checked)
            {
                this._custPrtPprBlnce.CreditMoneyOutputDiv = true;
            }
            // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<

            // 対象日付
            int dts = this.tDateEdit_CheckDateSt.GetLongDate();
            int dte = this.tDateEdit_CheckDateEd.GetLongDate();
            // DEL 2013/03/29 RedMine#35205②　---------------------------------------->>>>>
            //dts++;
            //dte++;
            // DEL 2013/03/29 RedMine#35205②　----------------------------------------<<<<<
            // ADD 2013/03/29 RedMine#35205②　---------------------------------------->>>>>
            dts = (dts / 100) * 100 + 1;
            dte = (dte / 100) * 100 + 1;
            // ADD 2013/03/29 RedMine#35205②　----------------------------------------<<<<<
            this.tDateEdit_CheckDateSt.SetLongDate(dts);
            this.tDateEdit_CheckDateEd.SetLongDate(dte);
            this._custPrtPprBlnce.St_AddUpYearMonth = this.tDateEdit_CheckDateSt.GetDateTime();
            this._custPrtPprBlnce.Ed_AddUpYearMonth = this.tDateEdit_CheckDateEd.GetDateTime();
            // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
            this._custPrtPprBlnce.Input_St_AddUpYearMonth = this.tDateEdit_CheckDateSt.GetDateTime();
            // 与信残高を出力する時は対象日付の開始を入力年月の前月からとする
            //if (this._custPrtPprBlnce.CreditMoneyOutputDiv)// DEL 2013/03/29 RedMine#35205②
            if (this._custPrtPprBlnce.CreditMoneyOutputDiv && (this.tDateEdit_CheckDateSt.GetLongDate() / 100 > 101))// ADD 2013/03/29 RedMine#35205②
            {
                this._custPrtPprBlnce.St_AddUpYearMonth = this.tDateEdit_CheckDateSt.GetDateTime().AddMonths(-1);
            }
            // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<


            // 対象得意先
            if (_prevInputValue.CustomerCodeSt == _prevInputValue.CustomerCodeEd)
            {
                if (_prevInputValue.CustomerCodeSt == "0" || string.IsNullOrEmpty(_prevInputValue.CustomerCodeSt))
                {
                    // --- DEL 2010/09/26 ---------->>>>>
                    // 全得意先取得
                    //CustomerSearchRet[] customerSearchRet;
                    //CustomerSearchPara customerSearchPara = new CustomerSearchPara();
                    //CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
                    //customerSearchPara.EnterpriseCode = _enterpriseCode;
                    //customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

                    //foreach (CustomerSearchRet ret in customerSearchRet)
                    //{
                    //    customerList.Add(ret.CustomerCode);
                    //}
                    // --- DEL 2010/09/26 ----------<<<<<
                    // --- ADD 2010/09/26 ---------->>>>>
                    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                    customerInfoAcs.Search(_enterpriseCode, false, false, out customerList);
                    // --- ADD 2010/09/26 ----------<<<<<
                }
                else
                {
                    // --- UPD 2010/09/26 ---------->>>>>
                    //customerList.Add(Convert.ToInt32(_prevInputValue.CustomerCodeSt));
                    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                    CustomerInfo customer;
                    int readStatus = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, _enterpriseCode, Convert.ToInt32(_prevInputValue.CustomerCodeSt), true, true, out customer);
                    if (readStatus == 0 && customer != null && customer.LogicalDeleteCode == 0)
                    {
                        customerList.Add(customer);
                    }
                    // --- UPD 2010/09/26 ----------<<<<<
                }
            }
            else
            {
                // --- DEL 2010/09/26 ---------->>>>>
                //CustomerSearchRet[] customerSearchRet;
                //CustomerSearchPara customerSearchPara = new CustomerSearchPara();
                //CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
                //customerSearchPara.EnterpriseCode = _enterpriseCode;
                //customerSearchAcs.Serch(out customerSearchRet, customerSearchPara);

                //foreach (CustomerSearchRet ret in customerSearchRet)
                //{
                //    if (ret.CustomerCode >= Convert.ToInt32(_prevInputValue.CustomerCodeSt) &&
                //        ret.CustomerCode <= Convert.ToInt32(_prevInputValue.CustomerCodeEd))
                //    {
                //        customerList.Add(ret.CustomerCode);
                //    }
                //}
                // --- DEL 2010/09/26 ----------<<<<<

                // --- ADD 2010/09/26 ---------->>>>>
                List<CustomerInfo> customerInfoList = null;
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                customerInfoAcs.Search(_enterpriseCode, false, false, out customerInfoList);

                foreach (CustomerInfo ret in customerInfoList)
                {
                    // ------------------ UPD 2010/09/28 ------------------------------------>>>>>
                    // 開始入力しない、終了入力する
                    if (_prevInputValue.CustomerCodeSt == "0" && _prevInputValue.CustomerCodeEd != "0")
                    {
                        if (ret.CustomerCode <= Convert.ToInt32(_prevInputValue.CustomerCodeEd))
                        {
                            customerList.Add(ret);
                        }
                    }
                    // 開始入力する、終了入力しない
                    else if (_prevInputValue.CustomerCodeSt != "0" && _prevInputValue.CustomerCodeEd == "0")
                    {
                        if (ret.CustomerCode >= Convert.ToInt32(_prevInputValue.CustomerCodeSt))
                        {
                            customerList.Add(ret);
                        }
                    }
                    // 開始入力する、終了入力する
                    else 
                    {
                        if (ret.CustomerCode >= Convert.ToInt32(_prevInputValue.CustomerCodeSt) &&
                        ret.CustomerCode <= Convert.ToInt32(_prevInputValue.CustomerCodeEd))
                        {
                            customerList.Add(ret);
                        }
                    }
                    //if (ret.CustomerCode >= Convert.ToInt32(_prevInputValue.CustomerCodeSt) &&
                    //    ret.CustomerCode <= Convert.ToInt32(_prevInputValue.CustomerCodeEd))
                    //{
                    //    customerList.Add(ret);
                    //}
                    // ------------------ UPD 2010/09/28 ------------------------------------<<<<<
                }
                // --- ADD 2010/09/26 ----------<<<<<
            }

            this.CustomerList = customerList;

            // 残高種別
            this.BalanceDiv = Convert.ToInt32(this.tComboEditor_BalanceDiv.Value);

            // 出力先ファイル名
            this.FileName = this.tEdit_SettingFileName.Text;

            // 企業コード
            this._custPrtPprBlnce.EnterpriseCode = _enterpriseCode;
        }

        /// <summary>
        /// 出力ファイル名変更処理
        /// </summary>
        private void ChangeFileName()
        {
            PMKAU04004UA userSettingForm = new PMKAU04004UA();
            string fileName = string.Empty;
            string path = string.Empty;
            userSettingForm.Deserialize();
            if (Convert.ToInt32(tComboEditor_BalanceDiv.Value) == 0)
            {
                // 請求
                fileName = userSettingForm.UserSetting.ClaimeFileName;
            }
            else
            {
                // 売掛
                fileName = userSettingForm.UserSetting.ChargeFileName;
            }
            if (!string.IsNullOrEmpty(fileName))
            {
                path = Path.GetDirectoryName(fileName);
                fileName = Path.GetFileNameWithoutExtension(fileName);
                fileName = path + "\\" + fileName;
                if (_excelFlg)
                {
                    // 拡張子をXLSにする
                    fileName += ".xls";
                }
                else
                {
                    // 拡張子をCSVにする
                    fileName += ".csv";
                }
            }
            this.tEdit_SettingFileName.Text = fileName;
        }
        #endregion // プライベートメンバ
    }
}
