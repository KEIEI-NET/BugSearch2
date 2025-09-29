using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCMポップアップ データ詳細確認画面
    /// </summary>
    /// <remarks>
    /// <br>Note		: 新規作成</br>
    /// <br>Programmer	: 21024 佐々木 健</br>
    /// <br>Date		: 2010/12/27</br>
    /// </remarks>
    public partial class PMSCM00005UE : Form
    {
        #region □ Private Member

        private ISCMTerminal _terminal;
        private CustomerInfo _customerInfo;
        private UserSCMOrderHeaderRecord _scmOrderHeader;
        private UserSCMOrderCarRecord _scmOrderCar;
        private List<UserSCMOrderDetailRecord> _scmOrderDetailList;
        private List<UserSCMOrderAnswerRecord> _scmOrderAnswerList;
        DataTable _detailTable = new DataTable();
        private ControlScreenSkin _controlScreenSkin; // 共通スキン

        #endregion

        #region □ Private Const

        private const string ctCol_No = "No.";
        private const string ctCol_BLCode = "BLCode";
        private const string ctCol_GoodsName = "GoodsName";
        private const string ctCol_GoodsNo = "GoodsNo";
        private const string ctCol_MakerName = "MakerName";
        private const string ctCol_Count = "Count";
        private const string ctCol_SalesSlipNo = "SalesSlipNo";

        #endregion

        #region □ Property

        /// <summary>SCM受注データ</summary>
        public UserSCMOrderHeaderRecord SCMOrderHeader
        {
            get { return _scmOrderHeader; }
            set { _scmOrderHeader = value; }
        }

        /// <summary>SCM受注データ(車輌情報)</summary>
        public UserSCMOrderCarRecord SCMOrderCar
        {
            get { return _scmOrderCar; }
            set { _scmOrderCar = value; }
        }

        /// <summary>SCM受注受注明細データ(問合せ・発注)</summary>
        public List<UserSCMOrderDetailRecord> SCMOrderDetailList
        {
            get { return _scmOrderDetailList; }
            set { _scmOrderDetailList = value; }
        }

        /// <summary>SCM受注受注明細データ(回答)</summary>
        public List<UserSCMOrderAnswerRecord> SCMOrderAnswerList
        {
            get { return _scmOrderAnswerList; }
            set { _scmOrderAnswerList = value; }
        }

        /// <summary>SCM端末用アクセスクラス</summary>
        public ISCMTerminal Terminal
        {
            get { return _terminal; }
            set { _terminal = value; }
        }
        /// <summary>得意先マスタデータクラス</summary>
        public CustomerInfo CustomerInfo
        {
            get { return _customerInfo; }
            set { _customerInfo = value; }
        }

        #endregion

        #region □ Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMSCM00005UE()
        {
            InitializeComponent();

            _detailTable = new DataTable();
            _detailTable.Columns.Add(new DataColumn(ctCol_No, typeof(int)));
            _detailTable.Columns.Add(new DataColumn(ctCol_BLCode, typeof(int)));
            _detailTable.Columns.Add(new DataColumn(ctCol_GoodsName, typeof(string)));
            _detailTable.Columns.Add(new DataColumn(ctCol_GoodsNo, typeof(string)));
            _detailTable.Columns.Add(new DataColumn(ctCol_MakerName, typeof(string)));
            _detailTable.Columns.Add(new DataColumn(ctCol_Count, typeof(int)));
            _detailTable.Columns.Add(new DataColumn(ctCol_SalesSlipNo, typeof(string)));
            this.uGrid_Details.DataSource = this._detailTable;
        }

        #endregion

        #region □ Control Event

        /// <summary>
        /// フォーム ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMSCM00005UE_Load(object sender, EventArgs e)
        {
            // スキン設定
            this._controlScreenSkin = new ControlScreenSkin();

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.DataDisp();
            this.GridInitialSetting();
        }

        /// <summary>
        /// フォーム キーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMSCM00005UD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 閉じるボタン クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region □ Private Method

        /// <summary>
        /// データ表示処理
        /// </summary>
        private void DataDisp()
        {
            if (_scmOrderHeader != null)
            {
                this.uLabel_InqNum.Text = _scmOrderHeader.InquiryNumber.ToString();
                this.uLabel_Kind.Text = ( _scmOrderHeader.InqOrdDivCd == 1 ) ? "問合せキャンセル" : "発注キャンセル";
            }

            if (_customerInfo != null)
            {
                this.uLabel_CustSNm.Text = this._customerInfo.CustomerSnm;
            }

            if (_scmOrderCar != null)
            {
                this.uLabel_ModelName.Text = _scmOrderCar.ModelName;
                this.uLabel_FullModel.Text = _scmOrderCar.FullModel;
                this.uLabel_ModelDesignationNo.Text = _scmOrderCar.ModelDesignationNo.ToString("00000");
                this.uLabel_CategoryNo.Text = _scmOrderCar.CategoryNo.ToString("0000");
                this.uLabel_ProduceTypeOfYearNum.Text = Terminal.GetProduceTypeOfYearString(_scmOrderCar.ProduceTypeOfYearNum);
                int year = this._scmOrderHeader.UpdateDate.Year;
                int month = this._scmOrderHeader.UpdateDate.Month;
                int day = this._scmOrderHeader.UpdateDate.Day;
                int hour = this._scmOrderHeader.UpdateTime / 10000000;
                int minute = this._scmOrderHeader.UpdateTime % 10000000 / 100000;
                int second = this._scmOrderHeader.UpdateTime % 10000000 % 100000 / 1000;
                this.uLabel_RecvDateTime.Text = new DateTime(year, month, day, hour, minute, second).ToString("yyyy/MM/dd HH:mm:ss");
            }

            if (_scmOrderDetailList != null)
            {
                int no = 0;
                foreach (UserSCMOrderDetailRecord detail in _scmOrderDetailList)
                {
                    if (detail.CancelCndtinDiv != (int)SCMTerminal.CancelCndtinDiv.Cancelling) continue;
                    // 2011/03/03 Add >>>
                    if (this._scmOrderAnswerList != null)
                    {
                        UserSCMOrderAnswerRecord ans = this._scmOrderAnswerList.Find(
                            delegate(UserSCMOrderAnswerRecord target)
                            {
                                if ((detail.InqRowNumber == target.InqRowNumber) &&
                                    (detail.InqRowNumDerivedNo == target.InqRowNumDerivedNo) &&
                                    ( ( detail.UpdateDate < target.UpdateDate ) || ( ( detail.UpdateDate == target.UpdateDate ) && ( detail.UpdateDateTime < target.UpdateDateTime ) ) )
                                    )
                                {
                                    return true;
                                }
                                return false;
                            });
                        if (ans != null) continue;
                    }
                    // 2011/03/03 Add <<<
                    DataRow dr = _detailTable.NewRow();
                    dr[ctCol_No] = ++no;
                    dr[ctCol_BLCode] = detail.BLGoodsCode;
                    dr[ctCol_GoodsName] = ( string.IsNullOrEmpty(detail.AnsGoodsName) ) ? detail.InqGoodsName : detail.AnsGoodsName;
                    dr[ctCol_GoodsNo] = ( string.IsNullOrEmpty(detail.AnsPureGoodsNo) ) ? detail.InqPureGoodsNo : detail.AnsPureGoodsNo;
                    dr[ctCol_MakerName] = detail.GoodsMakerNm;
                    dr[ctCol_Count] = detail.SalesOrderCount;
                    dr[ctCol_SalesSlipNo] = detail.SalesSlipNum;
                    this._detailTable.Rows.Add(dr);
                }
            }
        }

        /// <summary>
        /// グリッド初期設定処理
        /// </summary>
        private void GridInitialSetting()
        {
            // 外観表示設定
            this.uGrid_Details.BeginUpdate();

            try
            {

                Infragistics.Win.UltraWinGrid.ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
                {
                    // 全列共通設定
                    // 表示位置(vertical)
                    col.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                    // クリック時は行セレクト
                    col.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

                    // 編集不可
                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

                    // 全ての列をいったん非表示にする。
                    col.Hidden = true;
                }

                #region Col単位の設定

                // 固定列設定(行番号列のみ)
                columns[ctCol_No].Header.Fixed = true;

                // 行番号列のセル表示色変更
                columns[ctCol_No].Hidden = false;
                columns[ctCol_No].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
                columns[ctCol_No].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
                columns[ctCol_No].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                columns[ctCol_No].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                columns[ctCol_No].CellAppearance.ForeColor = Color.White;
                columns[ctCol_No].CellAppearance.ForeColorDisabled = Color.White;
                columns[ctCol_No].Width = 30;
                columns[ctCol_No].Header.VisiblePosition = 0;

                int visiblePosition = 1;

                // BLコード
                columns[ctCol_BLCode].Hidden = false;
                columns[ctCol_BLCode].Header.Caption = "BLコード";
                columns[ctCol_BLCode].Width = 70;
                columns[ctCol_BLCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                columns[ctCol_BLCode].Format = "00000";
                columns[ctCol_BLCode].Header.VisiblePosition = visiblePosition++;

                // 品名
                columns[ctCol_GoodsName].Hidden = false; 
                columns[ctCol_GoodsName].Header.Caption = "品名"; 
                columns[ctCol_GoodsName].Width = 250;
                columns[ctCol_GoodsName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                columns[ctCol_GoodsName].Header.VisiblePosition = visiblePosition++;

                // 品番
                columns[ctCol_GoodsNo].Hidden = false;
                columns[ctCol_GoodsNo].Header.Caption = "品番"; 
                columns[ctCol_GoodsNo].Width = 200;
                columns[ctCol_GoodsNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                columns[ctCol_GoodsNo].Header.VisiblePosition = visiblePosition++;

                // メーカー
                columns[ctCol_MakerName].Hidden = false;
                columns[ctCol_MakerName].Header.Caption = "メーカー";
                columns[ctCol_MakerName].Width = 170;
                columns[ctCol_MakerName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                columns[ctCol_MakerName].Header.VisiblePosition = visiblePosition++;

                // 数量
                columns[ctCol_Count].Hidden = false; 
                columns[ctCol_Count].Header.Caption = "返品数";
                columns[ctCol_Count].Width = 80;
                columns[ctCol_Count].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                columns[ctCol_Count].Header.VisiblePosition = visiblePosition++;
                columns[ctCol_Count].Format = "#,##0.00";

                // 伝票番号
                columns[ctCol_SalesSlipNo].Hidden = false;
                columns[ctCol_SalesSlipNo].Header.Caption = "返品元伝票番号";
                columns[ctCol_SalesSlipNo].Width = 120;
                columns[ctCol_SalesSlipNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                columns[ctCol_SalesSlipNo].Header.VisiblePosition = visiblePosition++;
                columns[ctCol_SalesSlipNo].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                #endregion

            }
            finally
            {
                // 外観表示設定
                this.uGrid_Details.EndUpdate();
            }
        }

        #endregion

    }
}