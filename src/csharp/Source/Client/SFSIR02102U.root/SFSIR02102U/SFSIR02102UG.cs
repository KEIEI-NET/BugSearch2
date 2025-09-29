//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 支払伝票番号入力
// プログラム概要   : 支払伝票番号入力の検索を行う
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
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 支払伝票番号入力画面
    /// </summary>
    /// <remarks>
    /// <br>Note		: 支払伝票番号入力画面です。</br>
    /// <br>Programmer	: 王君</br>
    /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
    /// <br>            : Redmine#33741の対応</br> 
    /// <br>Date		: 2012/12/24</br>
    /// <br></br>
    public partial class SFSIR02102UG : Form
    {   
        # region [Dispose]
        /// <summary>
        /// 支払伝票入力支払伝票呼出ガイド
        /// </summary>
        /// <remarks>
        /// <br>Note       : 支払伝票入力支払伝票呼出ガイドＵＩの機能を実装します。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号　 : 10806793-00 2013/03/13配信分</br>
        /// <br>           : Redmine#33741の対応</br> 
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        public SFSIR02102UG(PaymentSlpSearch paymentSlpSearch, SearchPaySlpInfoParameter searchPaySlpInfoParameter)
        {
            InitializeComponent();
            this._paymentSlpSearchUG = paymentSlpSearch;
            this._searchPaySlpInfoParameterUG = searchPaySlpInfoParameter;
            this._supplierAcs = new SupplierAcs();
        }

        public int status
        {
            set { _status = value; }
            get { return _status; }
        }

        public bool flag
        {
            set { _flag = value; }
            get { return _flag; }
        }

        public Employee Employee
        {
            set { _employee = value; }
            get { return _employee; }
        }

        #endregion
       
        #region [Private Members]

        private int _status;

        private PaymentSlpSearch _paymentSlpSearchUG;

        private SearchPaySlpInfoParameter _searchPaySlpInfoParameterUG;

        private bool _flag;

        private SupplierAcs _supplierAcs;

        /// <summary>ログイン担当者</summary>
        private Employee _employee;

        /// <summary>拠点アクセスクラス</summary>
        private SecInfoSetAcs _secInfoSetAcs = new SecInfoSetAcs();

        #endregion

        #region[Event]
        /// <summary>
        /// 伝票番号入力ガイド支払伝票クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 伝票番号入力ガイド、伝票伝票呼出ＵＩの機能を実装します。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : Redmine#33741の対応</br> 
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private void SFSIR02102UG_Load(object sender, EventArgs e)
        {
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this._flag = false;
            this.tEdit1.DataText = "支払";
            this.tNedit_SalesSlipNum.Focus();
            this.status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            this.Btn_SalesSlipGuide.ImageList = imageList16;
            this.Btn_SalesSlipGuide.Appearance.Image = Size16_Index.STAR1;
        }

        /// <summary>
        /// 確定ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note　　　  : キーが押された時に発生します。 </br>
        /// <br>Programmer  : 王君</br>
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            //支払伝票番号
            int PaymentSlipNo = this.tNedit_SalesSlipNum.GetInt();
            _searchPaySlpInfoParameterUG.PaymentSlipNo = PaymentSlipNo;
            if (checkData(PaymentSlipNo))
            {
                this._flag = true;
                status = this._paymentSlpSearchUG.SearchPaySlpInfoUG(_searchPaySlpInfoParameterUG, 31);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            DataTable dt = this._paymentSlpSearchUG.GetPaymentInfoDataTable();
                            int supplierCode = Convert.ToInt32(dt.Rows[0][PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERCDRF].ToString().Trim());
                            Supplier supplier;
                            int statusScode = GetSupplier(out supplier, supplierCode);
                            if (statusScode != 0)
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                  this.Name,
                                  "仕入先コードが存在しません。",
                                  0,
                                  MessageBoxButtons.OK);
                                this._paymentSlpSearchUG.ClearPaymentDataTable();
                                this.tNedit_SalesSlipNum.Clear();
                                this.tNedit_SalesSlipNum.Focus();
                                break;
                            }
                            else
                            {
                                this.DialogResult = DialogResult.OK;
                                break;
                            }
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                this._paymentSlpSearchUG.ErrorMessage,
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
                                          "支払伝票の読込処理に失敗しました。" + "\r\n" + this._paymentSlpSearchUG.ErrorMessage,
                                          status,
                                          MessageBoxButtons.OK);
                            break;
                        }
                }
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                  this.Name,
                                  "支払伝票番号が未入力です。",
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
        /// <br>Note　　　  : キーが押された時に発生します。 </br>
        /// <br>Programmer  : 王君</br>
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
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
                    if (e.ShiftKey == false && e.Key == Keys.Enter)
                    {
                        if (this.tNedit_SalesSlipNum.GetInt() != 0)
                        {
                            this.uButton_Save_Click(uButton_Save, new EventArgs());
                            e.NextCtrl = this.tNedit_SalesSlipNum;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 支払伝票ガイド画面を表示する
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ガイドを押す時に発生します。 </br>
        /// <br>Programmer  : 王君</br>
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private void Btn_SalesSlipGuide_Click(object sender, EventArgs e)
        {
            string sectionCode = this._employee.BelongSectionCode.TrimEnd();
            //ログイン拠点名の取る
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.Read(out sectionInfo, this._searchPaySlpInfoParameterUG.EnterpriseCode, sectionCode);
            SFSIR02102UH sFSIR02102UH = new SFSIR02102UH();
            sFSIR02102UH.SearchPaySlpInfoParameter = this._searchPaySlpInfoParameterUG;
            sFSIR02102UH.PaymentSlpSearchUH = this._paymentSlpSearchUG;
            //ログイン拠点
            sFSIR02102UH.SectionCode = sectionCode;
            //ログイン拠点名
            sFSIR02102UH.SectionName = sectionInfo.SectionGuideNm;
            sFSIR02102UH.ShowDialog();
            if (sFSIR02102UH.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this._flag = true;
                this.DialogResult = DialogResult.Cancel;
            }
        }
        #endregion
   
        #region [Private Methord]
        /// <summary>
        /// 支払伝票入力チェック
        /// </summary>
        /// <remarks>
        /// <br>Note       : 支払伝票入力チェックする。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private bool checkData(int PaymentSlipNo)
        {
            if (PaymentSlipNo == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 仕入先情報取る
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入先情報取るに行く。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号 　: 10806793-00 2013/03/13配信分</br>
        /// <br>           : Redmine#33741の対応</br> 
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private int GetSupplier(out Supplier supplier, int supplierCode)
        {
            int status = 0;
            supplier = new Supplier();

            try
            {
                string enterpriseCode = this._searchPaySlpInfoParameterUG.EnterpriseCode;
                status = this._supplierAcs.Read(out supplier, enterpriseCode, supplierCode);
                if ((status == 0) && (supplier.LogicalDeleteCode != 0))
                {
                    return 9;
                }
            }
            catch
            {
                status = -1;
                supplier = new Supplier();
            }

            return (status);
        }
        #endregion    
    }
}