//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 支払伝票ガイド
// プログラム概要   : 支払伝票ガイドの表示を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 王君
// 修 正 日  2012/12/24  修正内容 : 2013/03/13配信分 Redmine#33741の対応
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 王君
// 修 正 日  2013/02/23  修正内容 : 2013/03/13配信分 Redmine#33741の対応
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 王君
// 修 正 日  2013/03/01  修正内容 : 2013/03/13配信分 Redmine#33741の対応
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
using Infragistics.Win;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    public partial class SFSIR02102UH : Form
    {
        /// <summary>
        /// 支払伝票検索ガイド画面
        /// </summary>
        /// <remarks>
        /// <br>Note		: 支払伝票検索ガイド画面です。</br>
        /// <br>Programmer	: 王君</br>
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
        /// <br>Date		: 2012/12/24</br>
        /// <br>Update Note : 2013/02/23  王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
        /// <br>Update Note : 2013/03/01  王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
        /// <br></br>
        public SFSIR02102UH()
        {
            InitializeComponent();
            this._supplierAcs = new SupplierAcs();
        }

        #region[Private Member]
        
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;					// 検索ボタン

        // 拠点アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = new SecInfoSetAcs();

        private PaymentSlpSearch _paymentSlpSearch;

        private SearchPaySlpInfoParameter _searchPaySlpInfoParameter;

        /// <summary> 拠点コード</summary>
        private string _SectionCode;

        /// <summary>拠点名 </summary>
        private string _SectionName;

        /// <summary>企業コード</summary>
        private string _enterpriseCode;

        /// <summary>支払伝票データ</summary>
        private DataTable _paymentInfoTable;

        /// <summary> 仕入先情報クラス</summary>
        private SupplierAcs _supplierAcs;

        /// <summary>画面フォーカス初期設定Flag</summary>
        private bool _focusSetFlag;

        // ---- ADD 王君 2013/02/07 Redmine#33741 ---- >>>>>
        /// <summary>仕入先コード</summary>
        private int _supCode;

        /// <summary>仕入先名</summary>
        private string _supName;

        /// <summary>検索Flag</summary>
        private bool _toolSearchFlag;
        // ---- ADD 王君 2013/02/07 Redmine#33741 ---- <<<<<
        #endregion

        #region[Dispose]

        public string EnterpriseCode
        {
            set { _enterpriseCode = value; }
            get { return _enterpriseCode; }
        }

        public string SectionCode
        {
            set { _SectionCode = value; }
            get { return _SectionCode; }
        }

        public string SectionName
        {
            set { _SectionName = value; }
            get { return _SectionName; }
        }

        public PaymentSlpSearch PaymentSlpSearchUH
        {
            set { _paymentSlpSearch = value; }
            get { return _paymentSlpSearch; }
        }

        public SearchPaySlpInfoParameter SearchPaySlpInfoParameter
        {
            set { _searchPaySlpInfoParameter = value; }
            get { return _searchPaySlpInfoParameter; }
        }
        #endregion

        #region[Private Methord]

        /// <summary>支払ガイドグリッド初期設定処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : 支払ガイドグリッド初期設定処理処理。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// <br>Date	   : 2012/12/24</br>
        /// </remarks>
        private void SetGridLayout()
        {
            // 支払伝票番号
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].Width = 100;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].Header.Caption
                = "支払番号";
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].CellAppearance.TextHAlign
                = HAlign.Right;
            // 支払日付
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTDATE].Width = 110;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTDATE].Header.Caption
                = "支払日";
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_ADDUPADATE].Hidden = true;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_ADDUPADATE].Hidden = true;
            // 支払金種名称
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTMONEYKINDNAME].Hidden = true;
            // 支払金額
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].Header.Caption
                = "支払金額";
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].CellAppearance.TextHAlign
                = HAlign.Right;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].Hidden = true;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENT].Format = "#,##0";
            // 手数料支払額
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FEEPAYMENT].Hidden = true;
            // 値引支払額
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DISCOUNTPAYMENT].Hidden = true;

            // 支払金額計
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL].Width = 130;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL].Header.Caption
                = "支払計";
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL].CellAppearance.TextHAlign
                = HAlign.Right;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTTOTAL].Format = "#,##0";
            // 伝票摘要
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_OUTLINE].Width = 130;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_OUTLINE].Header.Caption
                = "摘要";
            // 締フラグ
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_FINISHEDFLG].Hidden = true;
            // 赤伝区分
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_DEBITNOTEDIV].Hidden = true;
            // 支払入力者名称
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENT_INPUT_AGENT_NM].Hidden = true;
            //仕入先コード
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERCDRF].Width = 130;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERCDRF].Header.Caption = "仕入先コード";
            //仕入先名
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERNAME].Width = 130;
            this.gridPaymentList.DisplayLayout.Bands[0].Columns[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERNAME].Header.Caption = "仕入先名"; 
        }

        /// <summary>
        ///仕入先取る
        /// </summary>
        /// <param name="supplier"></param>
        /// <param name="supplierCode"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note	   : 仕入先取る。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// <br>Date	   : 2012/12/24</br>
        /// </remarks>
        private int GetSupplier(out Supplier supplier, int supplierCode)
        {
            int status;
            supplier = new Supplier();

            try
            {
                status = this._supplierAcs.Read(out supplier, this._enterpriseCode, supplierCode);
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

        #region [Private Event]
        /// <summary>
        /// 拠点ガイドボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// <br>Date	   : 2012/12/24</br>
        /// </remarks> 
        private void SectionCodeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCodeAllowZero.DataText = sectionInfo.SectionCode.TrimEnd();
                this.uLabel_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();
                this._SectionCode = sectionInfo.SectionCode.TrimEnd();
                this._SectionName = sectionInfo.SectionGuideNm.TrimEnd();
            }
            else
            {
                this.tEdit_SectionCodeAllowZero.DataText = this._SectionCode;
                this.uLabel_SectionName.Text = this._SectionName;
            }
        }

        /// <summary>
        /// 仕入先ガイドボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : 仕入先ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// <br>Date	   : 2012/12/24</br>
        /// </remarks> 
        private void uButton_StockCustomerGuide_Click(object sender, EventArgs e)
        {
            int status;
            Supplier supplier;
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, this._SectionCode);
            if (status == 0)
            {
                this.tNedit_SupplierCd.DataText = supplier.SupplierCd.ToString();
                this.uLabel_CustomerName.Text = supplier.SupplierSnm;
            }
        }

        /// <summary>
        /// キーコントロール イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : キーが押された時に発生します。 </br>
        /// <br>Programmer  : 王君</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// <br>Update Note : 10806793-00 2013/02/07  王君</br>
        /// <br>管理番号    : 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br>
        /// <br>Update Note : 10806793-00 2013/03/01  王君</br>
        /// <br>管理番号    : 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (_focusSetFlag && e.NextCtrl!=null)
            {
                // 画面フォーカス初期設定処理
                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                this._focusSetFlag = false;
            }
            if (e.PrevCtrl == null)
            {
                return;
            }
            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SectionCodeAllowZero":
                    {
                        //------------------------------------
                        // 拠点コード取得
                        //------------------------------------
                        string sectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();

                        tEdit_SectionCodeAllowZero_Enter(this.tEdit_SectionCodeAllowZero, new EventArgs());
                        UiSet uiset;
                        uiSetControl1.ReadUISet(out uiset, tEdit_SectionCodeAllowZero.Name);
                        string sectionCodeZero = new string('0', uiset.Column);
                        if (sectionCode == sectionCodeZero || string.IsNullOrEmpty(sectionCode) || "0".Equals(sectionCode))
                        {
                            this.SectionCode = "00";
                            this.tEdit_SectionCodeAllowZero.DataText = "00";
                            this.uLabel_SectionName.Text = "全社";
                            this.SectionCode = "00";
                            this._SectionName = "全社";
                            return;
                        }
                        else if (sectionCode != this._SectionCode)
                        {
                            if (_secInfoSetAcs == null)
                            {
                                _secInfoSetAcs = new SecInfoSetAcs();
                            }
                            if (sectionCode.Length == 1)
                            {
                                sectionCode = sectionCode.PadLeft(2, '0');
                            }
                            SecInfoSet sectionInfo;
                            if (sectionCode != sectionCodeZero)
                            {
                                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
                                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) //DEL 王君 2013/02/07 Redmine#33741
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) //ADD 王君 2013/02/07 Redmine#33741
                                {
                                    // パラメータに保存
                                    this.tEdit_SectionCodeAllowZero.DataText = sectionInfo.SectionCode.TrimEnd();
                                    this.uLabel_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();
                                    this.SectionCode = sectionInfo.SectionCode.TrimEnd();
                                    this._SectionName = sectionInfo.SectionGuideNm.TrimEnd();
                                    //e.NextCtrl = this.tNedit_SupplierCd; // DEL 王君 2013/02/07 Redmine#33741
                                }
                                // ----- DEL 王君 2013/02/07 Redmine#33741 ---->>>>>
                                //else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                //    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                // ----- DEL 王君 2013/02/07 Redmine#33741 ----<<<<<
                                // ----- ADD 王君 2013/02/07 Redmine#33741 ---->>>>>
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF) || (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode != 0))
                                // ----- ADD 王君 2013/02/07 Redmine#33741 ----<<<<<
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する拠点が存在しません。",
                                        status,
                                        MessageBoxButtons.OK);
                                    // ---- DEL 王君 2013/02/07 Redmine#33741 ----- >>>>>
                                    //this.tEdit_SectionCodeAllowZero.Clear();
                                    //this.uLabel_SectionName.Text = "";
                                    // ---- DEL 王君 2013/02/07 Redmine#33741 ----- <<<<<
                                    // ----- ADD 王君 2013/02/07 Redmine#33741 ----- >>>>>
                                    this.tEdit_SectionCodeAllowZero.DataText = this.SectionCode;
                                    this.uLabel_SectionName.Text = this.SectionName;
                                    this._toolSearchFlag = false;
                                    // ----- ADD 王君 2013/02/07 Redmine#33741 ----- <<<<<
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "拠点名の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);
                                    // ---- DEL 王君 2013/02/07 Redmine#33741 ----- >>>>>
                                    //this.tEdit_SectionCodeAllowZero.Clear();
                                    //this.uLabel_SectionName.Text = "";
                                    // ---- DEL 王君 2013/02/07 Redmine#33741 ----- <<<<<
                                    // ----- ADD 王君 2013/02/07 Redmine#33741 ----- >>>>>
                                    this.tEdit_SectionCodeAllowZero.DataText = this.SectionCode.ToString();
                                    this.uLabel_SectionName.Text = this.SectionName;
                                    this._toolSearchFlag = false;
                                    // ----- ADD 王君 2013/02/07 Redmine#33741 ----- <<<<<
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            }
                        }
                        else
                        {
                            // ----- ADD 王君 2013/02/07 Redmine#33741 ----- >>>>>
                            if (e.ShiftKey == true)
                            {
                                switch(e.Key)
                                {
                                    case Keys.Enter:
                                    case Keys.Tab:
                                        {
                                            if (this.gridPaymentList.Rows.Count > 0)
                                            {
                                                this.gridPaymentList.Focus();
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.uButton_StockCustomerGuide;
                                            }
                                            break;
                                        }
                                }
                            }
                            // ----- ADD 王君 2013/02/07 Redmine#33741 ----- >>>>>
                            
                        }
                        break;
                    }
                case "tNedit_SupplierCd":
                    {
                        // 仕入先コード取得
                        int supplierCode = this.tNedit_SupplierCd.GetInt();
                        Supplier supplier;
                        //--------------------------------------------------------------------
                        // 仕入先コードから仕入先マスタを取得し、支払先コードと比較
                        //--------------------------------------------------------------------
                        int status = GetSupplier(out supplier, supplierCode);
                        if (supplierCode == 0)
                        {
                            this.uLabel_CustomerName.Text = "";
                        }
                        else
                        {
                            if (status == 0)
                            {
                                this.tNedit_SupplierCd.DataText = supplier.SupplierCd.ToString();
                                this.uLabel_CustomerName.Text = supplier.SupplierSnm;
                                // ---- ADD 王君 2013/02/07 Redmine#33741 ---- >>>>>
                                this._supCode = supplier.SupplierCd;
                                this._supName = supplier.SupplierSnm;
                                // ---- ADD 王君 2013/02/07 Redmine#33741 ---- <<<<<
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "該当する仕入先が存在しません。",
                                    status,
                                    MessageBoxButtons.OK);
                                this.tNedit_SupplierCd.Clear();
                                this.uLabel_CustomerName.Text = "";
                                // ----- ADD 王君 2013/02/07 Redmine#33741 ---->>>>>
                                this.tNedit_SupplierCd.DataText = this._supCode.ToString();
                                this.uLabel_CustomerName.Text = this._supName;
                                this._toolSearchFlag = false;
                                // ----- ADD 王君 2013/02/07 Redmine#33741 ----<<<<<
                                e.NextCtrl = this.uButton_StockCustomerGuide;
                            }
                        }
                        if (e.ShiftKey == false)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        break;
                                    }
                                case Keys.Right:
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (status == 0)
                                        {
                                            // ---- ADD 王君　2013/03/01 Redmine#33741 ----->>>>>
                                            if (this.gridPaymentList.Rows.Count > 0)
                                            {
                                            // ---- ADD 王君　2013/03/01 Redmine#33741 -----<<<<<
                                                e.NextCtrl = this.gridPaymentList;
                                            // ---- ADD 王君　2013/03/01 Redmine#33741 ----->>>>>
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.uButton_StockCustomerGuide;
                                            }
                                            // ---- ADD 王君　2013/03/01 Redmine#33741 ----->>>>> 
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_StockCustomerGuide;
                                        }
                                        break;
                                    }
                                case Keys.Down:
                                    {
                                        if (this.gridPaymentList.Rows.Count > 0)
                                        {
                                            e.NextCtrl = this.gridPaymentList;
                                        }
                                        // ---- ADD 王君　2013/02/07 Redmine#33741 ----->>>>>
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_SupplierCd;
                                        }
                                        // ---- ADD 王君　2013/02/07 Redmine#33741 -----<<<<<
                                        break;
                                    }
                            }
                        }
                        // ---- ADD 王君　2013/02/07 Redmine#33741 ----->>>>>
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.SectionCodeGuide_ultraButton;
                                        break;
                                    }
                            }
                        }
                        // ---- ADD 王君　2013/02/07 Redmine#33741 -----<<<<<
                        break;
                    }
                case "gridPaymentList":
                    {
                        if (e.ShiftKey == false)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                    {
                                        if (this.gridPaymentList.Rows.Count > 0 && this.gridPaymentList.ActiveRow != null)
                                        {
                                            gridPaymentList_DoubleClickRow(this.gridPaymentList, new DoubleClickRowEventArgs(this.gridPaymentList.ActiveRow, RowArea.CellArea));
                                        }
                                        // ---- ADD 王君　2013/03/01 Redmine#33741 ----->>>>>
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        }
                                        // ---- ADD 王君　2013/03/01 Redmine#33741 -----<<<<<
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                     // ---- ADD 王君　2013/02/07 Redmine#33741 ----->>>>>
                case "SectionCodeGuide_ultraButton":
                    {
                        if(e.ShiftKey==true)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "uButton_StockCustomerGuide":
                    {
                        if (e.ShiftKey == true)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_SupplierCd;
                                        break;
                                    }
                            }
                        }
                        // ---- ADD 王君　2013/03/01 Redmine#33741 ----->>>>>
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.gridPaymentList;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.SectionCodeGuide_ultraButton;
                                        break;
                                    }
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.uButton_StockCustomerGuide;
                                        break;
                                    }
                            }
                        }
                        // ---- ADD 王君　2013/03/01 Redmine#33741 ----->>>>>
                        break;
                    }
                // ---- ADD 王君　2013/02/07 Redmine#33741 -----<<<<<
            }
        }

        /// <summary>
        /// ToolBarのclick・イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note　　　  : ToolBarのclick・イベント。 </br>
        /// <br>Programmer  : 王君</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// <br>Update Note : 2013/02/07  王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
        /// <br>Update Note : 2013/02/23  王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br> 
        /// </remarks>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        /* ----- ADD 王君 2013/02/07 Redmine#33741 ---- >>>>>
                        if (!"00".Equals(this.tEdit_SectionCodeAllowZero.DataText.TrimEnd()))
                        {
                            _searchPaySlpInfoParameter.AddUpSecCode = this.tEdit_SectionCodeAllowZero.DataText.TrimEnd();
                        }
                        else
                        {
                            this._searchPaySlpInfoParameter.AddUpSecCode = "";
                        }
                        //----- ADD 王君 2013/02/07 Redmine#33741 ---- <<<<< */
                        // ----- ADD 王君 2013/02/07 Redmine#33741 ----->>>>>
                        this._toolSearchFlag = true;
                        if (this.tEdit_SectionCodeAllowZero.Focused)
                        {
                            tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero, null));
                        }
                        if (this.tNedit_SupplierCd.Focused)
                        {
                            tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tNedit_SupplierCd, null));
                        }
                        if ("00".Equals(this.SectionCode))
                        {
                            this._searchPaySlpInfoParameter.AddUpSecCode = "";
                        }
                        else
                        {
                            this._searchPaySlpInfoParameter.AddUpSecCode = this.SectionCode;
                        }
                        if (!this._toolSearchFlag)
                        {
                            return;
                        }
                        // ----- ADD 王君 2013/02/07 Redmine#33741 -----<<<<<
                        this._searchPaySlpInfoParameter.SupplierCode = this.tNedit_SupplierCd.GetInt();
                        this._searchPaySlpInfoParameter.PaymentSlipNo = 0; // ADD 王君 2013/02/23 Redmine#33741
                        int status = _paymentSlpSearch.SearchPaySlpInfoUH(_searchPaySlpInfoParameter, 31);
                        switch (status)
                        {
                            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                {
                                    this.gridPaymentList.Rows[0].Activate();
                                    this.gridPaymentList.Focus();
                                    break;
                                }
                            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                            case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        this._paymentSlpSearch.ErrorMessage,
                                        0,
                                        MessageBoxButtons.OK);
                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                                  this.Name,
                                                  "支払伝票の読込処理に失敗しました。" + "\r\n" + this._paymentSlpSearch.ErrorMessage,
                                                  status,
                                                  MessageBoxButtons.OK);
                                    break;
                                }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// DoubleClickRow イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note　　　  : キーが押された時に発生します。 </br>
        /// <br>Programmer  : 王君</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        private void gridPaymentList_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            int guidRowIndex = e.Row.Index;
            string paymentNo = this.gridPaymentList.Rows[guidRowIndex].Cells[PaymentSlpSearch.COL_PAYMENTSLP_PAYMENTSLIPNO].Value.ToString();
            DataRow[] drSlt = this._paymentInfoTable.Select("PaymentSlipNo =" + paymentNo);
            DataRow dr = this._paymentInfoTable.NewRow();
            if (drSlt.Length > 0)
            {
                dr = drSlt[0];
            }
            int supplierNo = Convert.ToInt32(dr[PaymentSlpSearch.COL_PAYMENTSLP_SUPPLIERCDRF].ToString());
            Supplier supplier;
            //--------------------------------------------------------------------
            // 仕入先コードから仕入先マスタを取得し、支払先コードと比較
            //--------------------------------------------------------------------
            int status = GetSupplier(out supplier, supplierNo);
            if (status != 0)
            {
                TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "仕入先は存在しません。",
                        -1,
                        MessageBoxButtons.OK);
                return;
            }
            this._paymentSlpSearch.ClearPaymentDataTableUH();
            this._paymentSlpSearch.GetPaymentInfoDataTable().ImportRow(dr);
            this.DialogResult = DialogResult.OK;
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
        private void SFSIR02102UH_Load(object sender, EventArgs e)
        {
            this._paymentInfoTable = _paymentSlpSearch.GetPaymentInfoDataTableH();
            _paymentSlpSearch.ClearPaymentGdDataTable();
            this.tEdit_SectionCodeAllowZero.DataText = this._SectionCode;
            this.uLabel_SectionName.Text = this._SectionName;
            this._enterpriseCode = this._searchPaySlpInfoParameter.EnterpriseCode;

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.SectionCodeGuide_ultraButton.ImageList = imageList16;
            this.SectionCodeGuide_ultraButton.Appearance.Image = Size16_Index.STAR1;
            this.uButton_StockCustomerGuide.ImageList = imageList16;
            this.uButton_StockCustomerGuide.Appearance.Image = Size16_Index.STAR1;

            this.tToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Search"];
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this._closeButton.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F1;

            this.gridPaymentList.DataSource = _paymentInfoTable;

            SetGridLayout();

            this._focusSetFlag = true;
            this._toolSearchFlag = true; // ADD 王君 2013/02/07 Redmine#33741
        }

        /// <summary>
        /// 拠点コードEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : 拠点コードEnterイベント。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// <br>Date	   : 2012/12/24</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero_Enter(object sender, EventArgs e)
        {
            // ゼロ詰め解除
            this.tEdit_SectionCodeAllowZero.Text = this.uiSetControl1.GetZeroPadCanceledText("tEdit_SectionCode", this.tEdit_SectionCodeAllowZero.Text);
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note　　　  : Guidにキーが押された時に発生します。 </br>
        /// <br>Programmer  : 王君</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        private void gridPaymentList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (this.gridPaymentList.Rows.Count > 0 && this.gridPaymentList.ActiveRow != null)
                        {
                            if (this.gridPaymentList.Rows[0].Activated)
                            {
                                this.tNedit_SupplierCd.Focus();
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// グリッド初期設定処理
        /// </summary>
        /// <param name="uGrid">支払グリッド</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : グリッドの初期設定を行います。</br>
        /// <br>Programmer : 王君</br>
        /// <br>Date       : 2013/02/07</br>
        /// </remarks>
        private void gridPaymentList_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;
            // 行選択モードの設定
            uGrid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;

            // 行選択設定 行選択無しモード(アクティブのみ)
            uGrid.DisplayLayout.Override.SelectTypeRow = SelectType.None;
            uGrid.DisplayLayout.Override.SelectTypeCell = SelectType.None;
            uGrid.DisplayLayout.Override.SelectTypeCol = SelectType.None;

            // 行の外観設定
            uGrid.DisplayLayout.Override.RowAppearance.BackColor = Color.White;

            // 1行おきの外観設定
            uGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;

            // 選択行の外観設定
            uGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            uGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            uGrid.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = GradientStyle.Vertical;

            // アクティブ行の外観設定
            uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            uGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = GradientStyle.Vertical;

            // ヘッダーの外観設定
            uGrid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            uGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            uGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = GradientStyle.Vertical;
            uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            uGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = HAlign.Left;
            uGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Alpha.Transparent;
            uGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = HAlign.Center;
            uGrid.DisplayLayout.Override.HeaderAppearance.TextVAlign = VAlign.Middle;

            // 行セレクターの外観設定
            uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            uGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = GradientStyle.Vertical;

            // 行フィルターの設定
            uGrid.DisplayLayout.Override.RowFilterAction = RowFilterAction.HideFilteredOutRows;

            // 垂直方向のスクロールスタイル
            uGrid.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;

            // 複数画面表示(スプリッター)の表示設定
            uGrid.DisplayLayout.MaxRowScrollRegions = 1;

            // スクロールバー最終行制御
            uGrid.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;

            // ヘッダークリックアクション設定
            uGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;

            // 「固定列」プッシュピンアイコンを消す
            uGrid.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
        }
        #endregion
    }
}