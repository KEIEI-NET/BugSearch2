using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using System.IO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 請求売掛残高出力UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求売掛残高出力UIクラスです。</br>
    /// <br>Programmer : 30521 本山 貴将</br>
    /// <br>Date       : 2014/08/25</br>        
    public partial class PMKAU09910UA : Form
    {
        public PMKAU09910UA()
        {
            InitializeComponent();

            _imageList16 = IconResourceManagement.ImageList16;

            ub_SectionCodeStGuid.ImageList = _imageList16;
            ub_SectionCodeStGuid.Appearance.Image = (int)Size16_Index.STAR1;

            ub_SectionCodeEdGuid.ImageList = _imageList16;
            ub_SectionCodeEdGuid.Appearance.Image = (int)Size16_Index.STAR1;

            ub_St_CustomerCdGuid.ImageList = _imageList16;
            ub_St_CustomerCdGuid.Appearance.Image = (int)Size16_Index.STAR1;

            ub_Ed_CustomerCdGuid.ImageList = _imageList16;
            ub_Ed_CustomerCdGuid.Appearance.Image = (int)Size16_Index.STAR1;

            TextFileName_uButton.ImageList = _imageList16;
            TextFileName_uButton.Appearance.Image = (int)Size16_Index.STAR1;

            this.BlnceRefer_tComboEditor.SelectedIndex = 0;

            this.OutPutSec_tComboEditor.SelectedIndex = 1;

            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;

            totalDayCalculator.InitializeHisMonthlyAccRec();
            totalDayCalculator.GetHisTotalDayMonthlyAccRec("", out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);

            if (prevTotalMonth != DateTime.MinValue)
            {
                tDateEdit_CheckDate_St.SetDateTime(prevTotalMonth);
                tDateEdit_CheckDate_Ed.SetDateTime(prevTotalMonth);
            }
            else
            {
                tDateEdit_CheckDate_St.SetDateTime(DateTime.Now);
                tDateEdit_CheckDate_Ed.SetDateTime(DateTime.Now);
            }
        }

        // ===================================================================================== //
		// プライベートメンバー
		// ===================================================================================== //
		#region Private Menbers
        string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;  // 企業コード
        private Hashtable _secInfSetTable = new Hashtable();    // 拠点情報
        /// <summary> アクセスクラス </summary>
        private PMKAU09911AA _pmkau09911A = new PMKAU09911AA();
        /// <summary> 抽出条件クラス </summary>
        private CustPrtPprBlnce _custPrtPprBlnce = new CustPrtPprBlnce();
        /// <summary> 得意先リスト </summary>
        private List<CustomerInfo> _customerList = new List<CustomerInfo>();
        /// <summary> ボタン用イメージリスト </summary>
        private ImageList _imageList16 = null;
        /// <summary> 残高種別 </summary>
        private int _remainType = 0;
        #endregion
                
        // ===================================================================================== //
        // 内部メソッド
        // ===================================================================================== //
        # region Private Methods
        /// <summary>
        /// 出力条件セット
        /// </summary>
        private void SetCustPrtPprBlnce()
        {
            // 対象拠点コード
            string[] sectionCode;
            if (_customerList == null)
                _customerList = new List<CustomerInfo>();
            // 残高種別
            this._remainType = Convert.ToInt32(BlnceRefer_tComboEditor.SelectedItem.DataValue.ToString());

            // 抽出拠点(請求拠点に強制固定・・管理拠点は色々と不具合がある)
            // this._custPrtPprBlnce.RemainSectionType = Convert.ToInt32(OutPutSec_tComboEditor.SelectedItem.DataValue.ToString());
            this._custPrtPprBlnce.RemainSectionType = 1;

            if (this.SectionCode_tEdit_St.Text == this.SectionCode_tEdit_Ed.Text)
            {
                if (this.SectionCode_tEdit_St.Text == "00")
                {
                    int i = Convert.ToInt32(this.SectionCode_tEdit_St.Text);
                    int addCnt = 0;
                    ArrayList relList;
                    SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                    int status = 0;

                    status = secInfoSetAcs.Search(out relList, this._enterpriseCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        sectionCode = new string[relList.Count];
                        foreach (SecInfoSet sectionCdInfo in relList)
                        {
                            if (Convert.ToInt32(this.SectionCode_tEdit_St.Text) <= Convert.ToInt32(sectionCdInfo.SectionCode))
                            {
                                sectionCode[addCnt] = sectionCdInfo.SectionCode;
                                addCnt++;
                            }
                        }
                        string[] retSecCode = new string[addCnt];
                        for (i = 0; i < addCnt; i++)
                        {
                            retSecCode[i] = sectionCode[i].Trim();
                        }
                        this._custPrtPprBlnce.SectionCode = retSecCode;
                    }

                    sectionCode = this._custPrtPprBlnce.SectionCode;
                    // sectionCode = null; // 全社指定
                }
                else
                {
                    sectionCode = new string[] { this.SectionCode_tEdit_St.Text };
                }
                this._custPrtPprBlnce.SectionCode = sectionCode;
            }
            else
            {
                int i = Convert.ToInt32(this.SectionCode_tEdit_St.Text);
                int addCnt = 0;
                string code;
                ArrayList relList;
                SecInfoSet sectionInfo;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                int status = 0;
                if (Convert.ToInt32(this.SectionCode_tEdit_Ed.Text) != 0)
                {
                    sectionCode = new string[Convert.ToInt32(this.SectionCode_tEdit_Ed.Text) - Convert.ToInt32(this.SectionCode_tEdit_St.Text) + 1];
                    for (; i <= Convert.ToInt32(this.SectionCode_tEdit_Ed.Text); i++)
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
                        retSecCode[i] = sectionCode[i].Trim();
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
                            if (Convert.ToInt32(this.SectionCode_tEdit_St.Text) <= Convert.ToInt32(sectionCdInfo.SectionCode))
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

            // 対象日付
            int dts = this.tDateEdit_CheckDate_St.GetLongDate();
            int dte = this.tDateEdit_CheckDate_Ed.GetLongDate();
            dts = (dts / 100) * 100 + 1;
            dte = (dte / 100) * 100 + 1;
            this.tDateEdit_CheckDate_St.SetLongDate(dts);
            this.tDateEdit_CheckDate_Ed.SetLongDate(dte);
            this._custPrtPprBlnce.St_AddUpYearMonth = this.tDateEdit_CheckDate_St.GetDateTime();
            this._custPrtPprBlnce.Ed_AddUpYearMonth = this.tDateEdit_CheckDate_Ed.GetDateTime();

            _customerList.Clear();

            // 対象得意先
            if (this.tNedit_CustomerCode_St.Text == this.tNedit_CustomerCode_Ed.Text)
            {
                if (this.tNedit_CustomerCode_St.Text == "0" || string.IsNullOrEmpty(this.tNedit_CustomerCode_St.Text))
                {
                    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                    customerInfoAcs.Search(_enterpriseCode, false, false, out _customerList);
                }
                else
                {
                    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                    CustomerInfo customer;
                    int readStatus = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, _enterpriseCode, Convert.ToInt32(this.tNedit_CustomerCode_St.Text), true, true, out customer);
                    if (readStatus == 0 && customer != null && customer.LogicalDeleteCode == 0)
                    {
                        _customerList.Add(customer);
                    }
                }
            }
            else
            {
                List<CustomerInfo> customerInfoList = null;
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                customerInfoAcs.Search(_enterpriseCode, false, false, out customerInfoList);

                foreach (CustomerInfo ret in customerInfoList)
                {
                    // 開始入力しない、終了入力する
                    if (this.tNedit_CustomerCode_St.Text == "0" && this.tNedit_CustomerCode_Ed.Text != "0")
                    {
                        if (ret.CustomerCode <= Convert.ToInt32(this.tNedit_CustomerCode_Ed.Text))
                        {
                            _customerList.Add(ret);
                        }
                    }
                    // 開始入力する、終了入力しない
                    else if (this.tNedit_CustomerCode_St.Text != "0" && this.tNedit_CustomerCode_Ed.Text == "0")
                    {
                        if (ret.CustomerCode >= Convert.ToInt32(this.tNedit_CustomerCode_St.Text))
                        {
                            _customerList.Add(ret);
                        }
                    }
                    // 開始入力する、終了入力する
                    else
                    {
                        if (ret.CustomerCode >= Convert.ToInt32(this.tNedit_CustomerCode_St.Text) &&
                        ret.CustomerCode <= Convert.ToInt32(this.tNedit_CustomerCode_Ed.Text))
                        {
                            _customerList.Add(ret);
                        }
                    }
                }
            }
            
            // 企業コード
            this._custPrtPprBlnce.EnterpriseCode = _enterpriseCode;

            // 与信残高（初期作成時は与信残高の出力はしないので固定でセット）
            this._custPrtPprBlnce.CreditMoneyOutputDiv = false;
        }

        /// <summary>
        /// テキスト出力処理
        /// </summary>
        /// <returns>True:正常; False:異常</returns>
        private void outputTextData()
        {
            CustPrtPprBlnce custPrtPprBlnce;
            custPrtPprBlnce = _custPrtPprBlnce;
            string columtext;
            string datatext;
            SFCMN00299CA processingDialog = new SFCMN00299CA();

            string outputFileName = this.TextFileName_tEdit.Text;
            
            try
            {
                processingDialog.Title = "抽出処理";
                processingDialog.Message = "現在、データ抽出中です。";
                processingDialog.DispCancelButton = false;
                processingDialog.Show((Form)this.Parent);
                // アクセスクラスのSearchメソッドを呼ぶ
                int status = _pmkau09911A.SearchBalanceAll(ref _custPrtPprBlnce, this._remainType, _customerList);
            }
            finally
            {
                processingDialog.Dispose();
            }
            
            // 出力データ取得
            if (_pmkau09911A._outputTable.Rows.Count == 0)
            {
                // 該当データがないとエラー
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    "出力データがありません。", -1, MessageBoxButtons.OK);
                return;
            }

            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(outputFileName, false, Encoding.GetEncoding("shift_jis"));
            }
            catch (IOException ex)
            {
                // 該当データがないとエラー
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    ex.Message, -1, MessageBoxButtons.OK);
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "ファイルの出力に失敗しました。", -1, MessageBoxButtons.OK);
                return;            
            }
            

            // 項目名のテキスト作成
            for (int i = 0; i < _pmkau09911A._outputTable.Columns.Count; i++)
            {
                columtext = _pmkau09911A._outputTable.Columns[i].ColumnName;

                if (i != _pmkau09911A._outputTable.Columns.Count - 1)
                    writer.Write(columtext + ",");
                else
                    writer.Write(columtext);
            }

            writer.Write("\r\n");

            // データ出力
            for (int i = 0; i < _pmkau09911A._outputTable.Rows.Count; i++)
            {
                for (int j = 0; j < _pmkau09911A._outputTable.Columns.Count; j++)
                {
                    datatext = _pmkau09911A._outputTable.Rows[i][j].ToString().Replace("\"", "\"\"");

                    if (j != _pmkau09911A._outputTable.Columns.Count - 1)
                    {
                        writer.Write("\"" + datatext + "\"" + ",");
                    }
                    else
                    {
                        writer.WriteLine("\"" + datatext + "\"");
                    }
                }
            }
            writer.Close();

            // 出力に成功
            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                "出力しました。", -1, MessageBoxButtons.OK);
            return;
        }

        #region フォーカスイベント
        /// <summary>
        /// チェンジフォーカス
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                return;
            } 
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
            switch (prevCtrl.Name)
            {
                // 残高種別
                case "BlnceRefer_tComboEditor":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.OutPutSec_tComboEditor;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.End_ultraButton;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // 出力拠点
                case "OutPutSec_tComboEditor":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.SectionCode_tEdit_St;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.BlnceRefer_tComboEditor;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // 開始拠点コード
                case "SectionCode_tEdit_St":
                    {
                        // 終了ボタンの場合はチェックしない
                        if (e.NextCtrl == this.End_ultraButton)
                        {
                            break;
                        }

                        string inputValue = this.SectionCode_tEdit_St.Text.Trim();
                        string code;
                        bool status = ReadSectionCodeAllowZero(out code, inputValue, true);
                        if (status == true)
                        {                            
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Enter:
                                        {
                                            if (String.IsNullOrEmpty(this.SectionCode_tEdit_St.Text.Trim()))
                                            {
                                                e.NextCtrl = this.ub_SectionCodeStGuid;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.SectionCode_tEdit_Ed;
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Enter:
                                        {
                                            e.NextCtrl = this.OutPutSec_tComboEditor;
                                        }
                                        break;
                                }                            
                            }
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
                            this.SectionCode_tEdit_St.Text = code;
                            this.SectionCode_tEdit_St.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 開始拠点ガイドボタン
                case "ub_SectionCodeStGuid":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        if (String.IsNullOrEmpty(this.SectionCode_tEdit_Ed.Text.Trim()))
                                        {
                                            e.NextCtrl = this.SectionCode_tEdit_Ed;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.ub_SectionCodeEdGuid;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        if (String.IsNullOrEmpty(this.SectionCode_tEdit_St.Text.Trim()))
                                        {
                                            e.NextCtrl = this.SectionCode_tEdit_St;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.OutPutSec_tComboEditor;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // 終了拠点コード
                case "SectionCode_tEdit_Ed":
                    {
                        // 終了ボタンの場合はチェックしない
                        if (e.NextCtrl == this.End_ultraButton)
                        {
                            break;
                        }

                        string inputValue = this.SectionCode_tEdit_Ed.Text.Trim();
                        string code;
                        bool status = ReadSectionCodeAllowZero(out code, inputValue, false);
                        if (status == true)
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Enter:
                                        {
                                            if (String.IsNullOrEmpty(this.SectionCode_tEdit_Ed.Text.Trim()))
                                            {
                                                e.NextCtrl = this.ub_SectionCodeEdGuid;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCode_St;
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Enter:
                                        {
                                            e.NextCtrl = this.ub_SectionCodeStGuid;                                            
                                        }
                                        break;
                                }
                            }
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
                            this.SectionCode_tEdit_Ed.Text = code;
                            this.SectionCode_tEdit_Ed.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // 終了拠点ガイドボタン
                case "ub_SectionCodeEdGuid":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        if (String.IsNullOrEmpty(this.tNedit_CustomerCode_St.Text.Trim()))
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode_St;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.ub_St_CustomerCdGuid;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        if (String.IsNullOrEmpty(this.SectionCode_tEdit_Ed.Text.Trim()))
                                        {
                                            e.NextCtrl = this.SectionCode_tEdit_Ed;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.ub_SectionCodeStGuid;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // 開始得意先コード
                case "tNedit_CustomerCode_St":
                    {
                        // 終了ボタンの場合はチェックしない
                        if (e.NextCtrl == this.End_ultraButton)
                        {
                            break;
                        }

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
                                    case Keys.Enter:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_CustomerCode_St.Text.Trim()))
                                            {
                                                e.NextCtrl = this.ub_St_CustomerCdGuid;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Enter:
                                        {
                                            e.NextCtrl = this.ub_SectionCodeEdGuid;                                            
                                        }
                                        break;
                                }
                            }
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
                // 開始得意先ガイドボタン
                case "ub_St_CustomerCdGuid":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        if (String.IsNullOrEmpty(this.tNedit_CustomerCode_Ed.Text.Trim()))
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.ub_Ed_CustomerCdGuid;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        if (String.IsNullOrEmpty(this.tNedit_CustomerCode_St.Text.Trim()))
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode_St;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.ub_SectionCodeEdGuid;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // 終了得意先コード
                case "tNedit_CustomerCode_Ed":
                    {
                        // 終了ボタンの場合はチェックしない
                        if (e.NextCtrl == this.End_ultraButton)
                        {
                            break;
                        }

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
                                    case Keys.Enter:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_CustomerCode_Ed.Text.Trim()))
                                            {
                                                e.NextCtrl = this.ub_Ed_CustomerCdGuid;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tDateEdit_CheckDate_St;
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Enter:
                                        {
                                            e.NextCtrl = this.ub_St_CustomerCdGuid;                                            
                                        }
                                        break;
                                }
                            }
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
                // 終了得意先ガイドボタン
                case "ub_Ed_CustomerCdGuid":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.tDateEdit_CheckDate_St;                                        
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        if (String.IsNullOrEmpty(this.tNedit_CustomerCode_Ed.Text.Trim()))
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.ub_St_CustomerCdGuid;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // 開始対象年月日
                case "tDateEdit_CheckDate_St":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.tDateEdit_CheckDate_Ed;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.ub_Ed_CustomerCdGuid;                                        
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // 終了対象年月日
                case "tDateEdit_CheckDate_Ed":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.TextFileName_tEdit;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.tDateEdit_CheckDate_St;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // 出力ファイル名
                case "TextFileName_tEdit":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.TextFileName_uButton;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.tDateEdit_CheckDate_Ed;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // 出力ファイルガイドボタン
                case "TextFileName_uButton":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.OutPut_ultraButton;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.TextFileName_tEdit;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // 出力ボタン
                case "OutPut_ultraButton":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.End_ultraButton;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.TextFileName_tEdit;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // 終了ボタン
                case "End_ultraButton":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.BlnceRefer_tComboEditor;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.OutPut_ultraButton;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
            }
        }
        #endregion

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

            // 00:全社
            if (sectionCode == "00")
            {                
                return true;
            }
            else if (!String.IsNullOrEmpty(sectionCode.Trim()))
            {
                // 拠点情報を取得
                SecInfoSet sectionInfo;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                int status = secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                // ステータスが正常の場合はUIにセット
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0)
                {
                    code = sectionInfo.SectionCode.TrimEnd();
                    if (stFlg)
                    {
                        SectionCode_tEdit_St.Text = code;
                    }
                    else
                    {
                        SectionCode_tEdit_Ed.Text = code;
                    }
                    return true;
                }
                else
                {
                    if (stFlg)
                    {
                        code = SectionCode_tEdit_St.Text;
                    }
                    else
                    {
                        code = SectionCode_tEdit_Ed.Text;
                    }
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                if (stFlg)
                {
                    SectionCode_tEdit_St.Text = code;
                }
                else
                {
                    SectionCode_tEdit_Ed.Text = code;
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
        private bool ReadCustomerName(out int code, int inputValue, bool stFlg)
        {
            int customerCode = inputValue;
            code = customerCode;

            if (customerCode > 0)
            {
                CustomerInfo customerInfo;
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                int status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.IsCustomer && customerInfo.LogicalDeleteCode == 0)
                {
                    if (stFlg)
                    {
                        tNedit_CustomerCode_St.Text = customerCode.ToString();
                    }
                    else
                    {
                        tNedit_CustomerCode_Ed.Text = customerCode.ToString();
                    }
                    return true;
                }
                else
                {
                    if (stFlg)
                    {
                        code = Convert.ToInt32(tNedit_CustomerCode_St.Text);
                    }
                    else
                    {
                        code = Convert.ToInt32(tNedit_CustomerCode_Ed.Text);
                    }
                    return false;
                }
            }
            else
            {
                if (stFlg)
                {
                    tNedit_CustomerCode_St.Text = customerCode.ToString();
                }
                else
                {
                    tNedit_CustomerCode_Ed.Text = customerCode.ToString();
                }
                return true;
            }
        }
        #endregion

        // ===================================================================================== //
        // ボタンイベント
        // ===================================================================================== //
        #region ボタンイベント
        /// <summary>
        /// OKボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutPut_ultraButton_Click(object sender, EventArgs e)
        {
            #region 入力チェック
            if (string.IsNullOrEmpty(this.SectionCode_tEdit_St.Text))
            {
                this.SectionCode_tEdit_St.Text = "00";
            }
            if (string.IsNullOrEmpty(this.SectionCode_tEdit_Ed.Text))
            {
                this.SectionCode_tEdit_Ed.Text = "00";
            }
            if (Convert.ToInt32(this.SectionCode_tEdit_Ed.Text) != 0 && (Convert.ToInt32(this.SectionCode_tEdit_St.Text) > Convert.ToInt32(this.SectionCode_tEdit_Ed.Text)))
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
            if (string.IsNullOrEmpty(this.tNedit_CustomerCode_St.Text))
            {
                this.tNedit_CustomerCode_St.Text = "0";
            }
            if (string.IsNullOrEmpty(this.tNedit_CustomerCode_Ed.Text))
            {
                this.tNedit_CustomerCode_Ed.Text = "0";
            }
            if (Convert.ToInt32(this.tNedit_CustomerCode_Ed.Text) != 0 && (Convert.ToInt32(this.tNedit_CustomerCode_St.Text) > Convert.ToInt32(this.tNedit_CustomerCode_Ed.Text)))            
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
            int sMonth = (this.tDateEdit_CheckDate_St.GetLongDate() / 100) % 100;
            int sYear = this.tDateEdit_CheckDate_St.GetLongDate() / 10000;
            int eMonth = (this.tDateEdit_CheckDate_Ed.GetLongDate() / 100) % 100;
            int eYear = this.tDateEdit_CheckDate_Ed.GetLongDate() / 10000;

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

            if (sYear > eYear
                || ((sYear == eYear) && (sMonth > eMonth)))
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
            if (string.IsNullOrEmpty(this.TextFileName_tEdit.Text))
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

            string outputFileName = this.TextFileName_tEdit.Text;

            if (".csv" != Path.GetExtension(outputFileName) &&
                ".CSV" != Path.GetExtension(outputFileName))
            {
                // ファイル名が指定されていないとエラー
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "出力ファイルをCSVにして下さい。", -1, MessageBoxButtons.OK);
                return;
            }

            #endregion  // 入力チェック

            // 出力条件セット処理
            SetCustPrtPprBlnce();
            
            // テキスト出力処理
            outputTextData();

            // 0埋めしている内容を元に戻す(つくりがいまいち)
            if(this.SectionCode_tEdit_St.Text == "00")
                this.SectionCode_tEdit_St.Text = "";
            if(this.SectionCode_tEdit_Ed.Text == "00")
                this.SectionCode_tEdit_Ed.Text = "";
            if (this.tNedit_CustomerCode_St.Text == "0")
                this.tNedit_CustomerCode_St.Text = "";
            if (this.tNedit_CustomerCode_Ed.Text == "0")
                this.tNedit_CustomerCode_Ed.Text = "";

        }
        
        /// <summary>
        /// キャンセルボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void End_ultraButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 拠点ガイド
        /// <summary>
        /// 開始拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_SectionCodeStGuid_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            SecInfoSet sectionInfo;
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            int status = secInfoSetAcs.ExecuteGuid(_enterpriseCode, true, out sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SectionCode_tEdit_St.Text = sectionInfo.SectionCode.Trim();
                this.SectionCodeNm_tEdit_St.Text = sectionInfo.SectionGuideNm;
            }
        }

        /// <summary>
        /// 終了拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_SectionCodeEdGuid_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            SecInfoSet sectionInfo;
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            int status = secInfoSetAcs.ExecuteGuid(_enterpriseCode, true, out sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SectionCode_tEdit_Ed.Text = sectionInfo.SectionCode.Trim();
                this.SectionCodeNm_tEdit_Ed.Text = sectionInfo.SectionGuideNm;      
            }
        }
        #endregion

        #region 得意先ガイド
        /// <summary>
        /// 開始得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_CustomerCdGuid_Click(object sender, EventArgs e)
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
        private void ub_Ed_CustomerCdGuid_Click(object sender, EventArgs e)
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
        /// 得意先選択時発生イベント(開始)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo = new CustomerInfo();
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 取得した得意先コード(開始)を画面に表示する
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
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
        /// 得意先選択時発生イベント(終了)
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
        #endregion

        #region 出力先フォルダガイド
        /// <summary>
        /// ファイルダイアログ表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        private void TextFileName_uButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.TextFileName_tEdit.Text))
            {
                try
                {
                    FileInfo objFileInfo = new FileInfo(this.TextFileName_tEdit.Text.Trim());
                    this.openFileDialog.FileName = objFileInfo.FullName;
                }
                catch (Exception)
                {
                    this.openFileDialog.FileName = string.Empty;
                }
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;

            this.openFileDialog.Filter = string.Format("テキストファイル(*.CSV) | *.CSV");
            
            // ファイル選択
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.TextFileName_tEdit.Text = openFileDialog.FileName.ToUpper();
            }
        }
        #endregion
               
        #endregion        

        private void PMKAU09910UA_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = this.BlnceRefer_tComboEditor;
        }
    }
}