//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : SCM売上回答履歴照会
// プログラム概要   : SCM受注データ、SCM受注明細データの照会を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/05/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCM売上回答履歴照会フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM受注データ、SCM受注明細データの照会を行う</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2009.05.27</br>
    /// <br></br>
    public partial class PMSCM04101UA : Form
    {
        #region ■private定数
        // 画面状態保存用ファイル名
        private const string XML_FILE_INITIAL_DATA = "PMSCM04101U.dat";

        //エラー条件メッセージ
        private const string ct_InputError = "の入力が不正です";
        private const string ct_NoInput = "を入力して下さい";
        private const string ct_RangeError = "の範囲指定に誤りがあります";
        #endregion

        #region ■private変数
        // 共通スキン
        private ControlScreenSkin _controlScreenSkin;

        // ログイン企業コード
        private string _enterpriseCode;
        // ログイン拠点コード
        private string _sectionCode;

        private readonly Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionTitleLabel;   // ログイン拠点タイトル
        private readonly Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionNameLabel;	// ログイン拠点名称
        private readonly Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;		    // ログイン担当者タイトル
        private readonly Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;			// ログイン担当者名称

        // グリッド状態保存
        private GridStateController _gridStateController;

        #region アクセスクラス
        // 売上回答履歴照会アクセスクラス
        private SCMAnsHistInquiryAsc _scmAnsHistInquiryAcs;
        // 日付部品
        private DateGetAcs _dateGet;
        // 拠点ガイド
        private SecInfoSetAcs _secInfoSetAcs;
        // メーカーガイド
        private MakerAcs _makerAcs;
        // BLコードガイド
        private BLGoodsCdAcs _blGoodsCdAcs;
        // 車種ガイド
        private ModelNameUAcs _modelNameUAcs;
        #endregion

        #region 前回入力値
        private string _beforeSectionCode; // 拠点コード
        private int _beforeMakerCode; // メーカーコード
        private int _beforeBLGoodsCode; // BLコード
        private int _beforeMakerCodeCar; // メーカーコード(車両情報)
        private int _beforeModelCode; // 車種コード
        private int _beforeModelSubCode; // 車種サブコード
        private string _beforeGoodsNo; // 商品番号
        private string _beforePureGoodsNo; // 純正商品番号
        #endregion

        #region 得意先ガイド用
        // 押下ガイドボタン
        private UltraButton _customerGuideSender;
        #endregion

        #endregion

        #region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMSCM04101UA()
        {
            InitializeComponent();

            #region ログイン情報

            // メンバに保持
            _loginSectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LabelTool_LoginSectionTitle"];
            _loginSectionNameLabel  = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LabelTool_LoginSectionName"];
            _loginTitleLabel        = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LabelTool_LoginTitle"];
            _loginNameLabel         = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LabelTool_LoginName"];

            // アイコンを設定
            _loginSectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image   = Size16_Index.BASE;
            _loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image          = Size16_Index.EMPLOYEE;

            // ログイン情報を設定
            string loginSectionName = string.Empty;
            string loginEmployeeName= string.Empty;
            if (LoginInfoAcquisition.Employee != null)
            {
                loginSectionName = LoginInfoAcquisition.Employee.BelongSectionName;
                loginEmployeeName= LoginInfoAcquisition.Employee.Name;
            }
            _loginSectionNameLabel.SharedProps.Caption  = loginSectionName;
            _loginNameLabel.SharedProps.Caption         = loginEmployeeName;

            #endregion // ログイン情報
        }
        #endregion

        #region ■publicメソッド
        #region XML操作
        /// <summary>
        /// ＸＭＬデータの保存処理
        /// </summary>
        public void SaveStateXmlData()
        {
            // グリッド情報を保存
            this._gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }
        #endregion
        #endregion

        #region ■privateメソッド
        #region 初期設定
        /// <summary>
        /// ガイドアクセス初期化
        /// </summary>
        private void GetGuideInstance()
        {
            this._scmAnsHistInquiryAcs = SCMAnsHistInquiryAsc.GetInstance();
            this._dateGet = DateGetAcs.GetInstance();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._modelNameUAcs = new ModelNameUAcs();
        }

        /// <summary>
        /// 初期化を行う
        /// </summary>
        private void SetInitialSetting()
        {
            // ガイドアクセス初期化
            this.GetGuideInstance();

            this._gridStateController = new GridStateController();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;　// 自企業コード
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim().PadLeft(2, '0'); // 自拠点コード

            this._controlScreenSkin = new ControlScreenSkin();

            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.uGroupBox_ExtractInfo.Name);
            excCtrlNm.Add(this.uGroupBox_DetailInfo.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // ツールバーアイコン設定
            tToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            this.tToolbarsManager1.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this.tToolbarsManager1.Tools["ButtonTool_Search"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this.tToolbarsManager1.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;

            // ガイドボタン設定
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.uButton_SectionCdGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerCdGuideSt.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerCdGuideEd.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMakerCdGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_BLGoodsCdGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_ModelFullGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // グリッド設定
            this.SetGridSetting();
        }

        /// <summary>
        /// 初期項目設定
        /// </summary>
        private void ClearScreen()
        {
            // 前回設定値を初期化
            this._beforeSectionCode = string.Empty; // 拠点コード
            this._beforeMakerCode = 0; // メーカーコード
            this._beforeBLGoodsCode = 0; // BLコード
            this._beforeMakerCodeCar = 0; // メーカーコード(車両情報)
            this._beforeModelCode = 0; // 車種コード
            this._beforeModelSubCode = 0; // 車種サブコード
            this._beforeGoodsNo = string.Empty; // 商品番号
            this._beforePureGoodsNo = string.Empty; // 純正商品番号

            // 問合せ日
            tde_InquiryDateSt.SetLongDate(0);
            tde_InquiryDateEd.SetLongDate(0);

            // 拠点
            this.tEdit_SectionCodeAllowZero.Text = string.Empty;
            this.uLabel_SectionName.Text = string.Empty;

            // 得意先
            this.tNedit_CustomerCode_St.SetInt(0);
            this.tNedit_CustomerCode_Ed.SetInt(0);

            // 回答方法
            this.uCheckEditor_AnswerMethodAll.Checked = true; // 全て
            this.uCheckEditor_AnswerMethodAuto.Checked = false; // 自動
            this.uCheckEditor_AnswerMethodManual.Checked = false; // 手動

            // 伝票番号(受注ステータス)
            this.uCheckEditor_AcptAnOdrStatusAll.Checked = true; // 全て
            this.uCheckEditor_AcptAnOdrStatusSales.Checked = false; // 売上
            this.uCheckEditor_AcptAnOdrStatusAccept.Checked = false; // 受注
            this.uCheckEditor_AcptAnOdrStatusEstimate.Checked = false; // 見積

            // 伝票番号
            this.tEdit_SalesSlipNum_St.Text = string.Empty;
            this.tEdit_SalesSlipNum_Ed.Text = string.Empty;

            // 問合せ番号(問合せ・発注種別)
            this.uCheckEditor_InqOrdDivAll.Checked = true; // 全て
            this.uCheckEditor_InqOrdDivAccept.Checked = false; // 受注
            this.uCheckEditor_InqOrdDivEstimate.Checked = false; // 見積

            // 問合せ番号
            this.tNedit_InquiryNumber_St.SetInt(0);
            this.tNedit_InquiryNumber_Ed.SetInt(0);

            // 車両登録番号(プレート番号)
            this.tNedit_NumberPlate4.SetInt(0);
            // 型式
            this.tEdit_FullModel.DataText = string.Empty;
            // 車種(メーカー)
            this.tNedit_CarMakerCode.SetInt(0);
            // 車種コード
            this.tNedit_ModelCode.SetInt(0);
            // 車種サブコード
            this.tNedit_ModelSubCode.SetInt(0);
            // 車種名
            this.tEdit_ModelFullName.DataText = string.Empty;

            // メーカー
            this.tNedit_GoodsMakerCd.SetInt(0);
            // BLコード
            this.tNedit_BLGoodsCode.SetInt(0);
            // 品番
            this.tEdit_GoodsNo.DataText = string.Empty;
            // 純正品番
            this.tEdit_PureGoodsNo.DataText = string.Empty;
        }

        /// <summary>
        /// グリッド設定
        /// </summary>
        private void SetGridSetting()
        {
            // データソース設定
            this.uGrid_Details.DataSource = this._scmAnsHistInquiryAcs.SCMAnsHistInquiryDataTable;

            // 外観表示設定
            this.uGrid_Details.BeginUpdate();

            try
            {
                ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

                foreach (UltraGridColumn col in columns)
                {
                    // 全列共通設定
                    // 表示位置(vertical)
                    col.CellAppearance.TextVAlign = VAlign.Middle;

                    // クリック時は行セレクト
                    col.CellClickAction = CellClickAction.RowSelect;

                    // 編集不可
                    col.CellActivation = Activation.Disabled;
                    
                    // 全ての列をいったん非表示にする。
                    col.Hidden = true;
                }

                SCMAcOdrDataDataSet.SCMAnsHistInquiryDataTable table = this._scmAnsHistInquiryAcs.SCMAnsHistInquiryDataTable;

                // 固定列設定(行番号列のみ)
                columns[table.RowNumberColumn.ColumnName].Header.Fixed = true;

                // 行番号列のセル表示色変更
                columns[table.RowNumberColumn.ColumnName].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
                columns[table.RowNumberColumn.ColumnName].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
                columns[table.RowNumberColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
                columns[table.RowNumberColumn.ColumnName].CellAppearance.ForeColor = Color.White;
                columns[table.RowNumberColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.White;

                int visiblePosition = 0;

                #region カラム設定
                // No.列
                columns[table.RowNumberColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.RowNumberColumn.ColumnName].Header.Caption = "No."; // 列キャプション
                columns[table.RowNumberColumn.ColumnName].Width = 50; // 表示幅
                columns[table.RowNumberColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.RowNumberColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                #region 受注データ
                // 拠点
                columns[table.InqOtherSecCdColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.InqOtherSecCdColumn.ColumnName].Header.Caption = "拠点"; // 列キャプション
                columns[table.InqOtherSecCdColumn.ColumnName].Width = 70; // 表示幅
                columns[table.InqOtherSecCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.InqOtherSecCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 拠点名
                columns[table.InqOtherSecNmColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.InqOtherSecNmColumn.ColumnName].Header.Caption = "拠点名"; // 列キャプション
                columns[table.InqOtherSecNmColumn.ColumnName].Width = 100; // 表示幅
                columns[table.InqOtherSecNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.InqOtherSecNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 問合せ番号
                columns[table.InquiryNumberColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.InquiryNumberColumn.ColumnName].Header.Caption = "問合せ番号"; // 列キャプション
                columns[table.InquiryNumberColumn.ColumnName].Width = 100; // 表示幅
                columns[table.InquiryNumberColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.InquiryNumberColumn.ColumnName].Format = "0000000000";
                columns[table.InquiryNumberColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 得意先
                columns[table.CustomerCodeColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.CustomerCodeColumn.ColumnName].Header.Caption = "得意先"; // 列キャプション
                columns[table.CustomerCodeColumn.ColumnName].Width = 100; // 表示幅
                columns[table.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.CustomerCodeColumn.ColumnName].Format = "00000000";
                columns[table.CustomerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 得意先名
                columns[table.CustomerNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.CustomerNameColumn.ColumnName].Header.Caption = "得意先名"; // 列キャプション
                columns[table.CustomerNameColumn.ColumnName].Width = 120; // 表示幅
                columns[table.CustomerNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.CustomerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 更新日時
                columns[table.UpdateDateTimeForDispColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.UpdateDateTimeForDispColumn.ColumnName].Header.Caption = "更新日時"; // 列キャプション
                columns[table.UpdateDateTimeForDispColumn.ColumnName].Width = 200; // 表示幅
                columns[table.UpdateDateTimeForDispColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.UpdateDateTimeForDispColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 回答区分
                columns[table.AnswerDivNmColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.AnswerDivNmColumn.ColumnName].Header.Caption = "回答区分"; // 列キャプション
                columns[table.AnswerDivNmColumn.ColumnName].Width = 150; // 表示幅
                columns[table.AnswerDivNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.AnswerDivNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 確定日
                //columns[table.JudgementDateForDispColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.JudgementDateForDispColumn.ColumnName].Header.Caption = "確定日"; // 列キャプション
                //columns[table.JudgementDateForDispColumn.ColumnName].Width = 100; // 表示幅
                //columns[table.JudgementDateForDispColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.JudgementDateForDispColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 問合せ・発注備考
                //columns[table.InqOrdNoteColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.InqOrdNoteColumn.ColumnName].Header.Caption = "問合せ・発注備考"; // 列キャプション
                //columns[table.InqOrdNoteColumn.ColumnName].Width = 150; // 表示幅
                //columns[table.InqOrdNoteColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.InqOrdNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 問合せ従業員コード
                columns[table.InqEmployeeCdColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.InqEmployeeCdColumn.ColumnName].Header.Caption = "問合せ担当者"; // 列キャプション
                columns[table.InqEmployeeCdColumn.ColumnName].Width = 170; // 表示幅
                columns[table.InqEmployeeCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.InqEmployeeCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 問合せ従業員名称
                columns[table.InqEmployeeNmColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.InqEmployeeNmColumn.ColumnName].Header.Caption = "問合せ担当者名"; // 列キャプション
                columns[table.InqEmployeeNmColumn.ColumnName].Width = 150; // 表示幅
                columns[table.InqEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.InqEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 回答従業員コード
                columns[table.AnsEmployeeCdColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.AnsEmployeeCdColumn.ColumnName].Header.Caption = "担当者"; // 列キャプション
                columns[table.AnsEmployeeCdColumn.ColumnName].Width = 170; // 表示幅
                columns[table.AnsEmployeeCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.AnsEmployeeCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 回答従業員名称
                columns[table.AnsEmployeeNmColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.AnsEmployeeNmColumn.ColumnName].Header.Caption = "担当者名"; // 列キャプション
                columns[table.AnsEmployeeNmColumn.ColumnName].Width = 150; // 表示幅
                columns[table.AnsEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.AnsEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 問合せ日
                columns[table.InquiryDateForDispColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.InquiryDateForDispColumn.ColumnName].Header.Caption = "問合せ日"; // 列キャプション
                columns[table.InquiryDateForDispColumn.ColumnName].Width = 150; // 表示幅
                columns[table.InquiryDateForDispColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.InquiryDateForDispColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 売上伝票合計（税込み）
                columns[table.SalesTotalTaxIncColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.SalesTotalTaxIncColumn.ColumnName].Header.Caption = "金額"; // 列キャプション
                columns[table.SalesTotalTaxIncColumn.ColumnName].Width = 200; // 表示幅
                columns[table.SalesTotalTaxIncColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.SalesTotalTaxIncColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.SalesTotalTaxIncColumn.ColumnName].Format = "#,##0";

                // 売上小計（税）
                columns[table.SalesSubtotalTaxColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.SalesSubtotalTaxColumn.ColumnName].Header.Caption = "消費税"; // 列キャプション
                columns[table.SalesSubtotalTaxColumn.ColumnName].Width = 150; // 表示幅
                columns[table.SalesSubtotalTaxColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.SalesSubtotalTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.SalesSubtotalTaxColumn.ColumnName].Format = "#,##0";

                // 問発・回答種別
                columns[table.InqOrdAnsDivNmColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.InqOrdAnsDivNmColumn.ColumnName].Header.Caption = "問発・回答区分"; // 列キャプション
                columns[table.InqOrdAnsDivNmColumn.ColumnName].Width = 150; // 表示幅
                columns[table.InqOrdAnsDivNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.InqOrdAnsDivNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 受信日時
                columns[table.ReceiveDateTimeForDispColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.ReceiveDateTimeForDispColumn.ColumnName].Header.Caption = "受信日時"; // 列キャプション
                columns[table.ReceiveDateTimeForDispColumn.ColumnName].Width = 170; // 表示幅
                columns[table.ReceiveDateTimeForDispColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.ReceiveDateTimeForDispColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                #endregion

                #region 車両情報
                //// 陸運事務所番号
                //columns[table.NumberPlate1CodeColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.NumberPlate1CodeColumn.ColumnName].Header.Caption = "陸運事務所番号"; // 列キャプション
                //columns[table.NumberPlate1CodeColumn.ColumnName].Width = 150; // 表示幅
                //columns[table.NumberPlate1CodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                //columns[table.NumberPlate1CodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 陸運事務局名称
                //columns[table.NumberPlate1NameColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.NumberPlate1NameColumn.ColumnName].Header.Caption = "陸運事務局名称"; // 列キャプション
                //columns[table.NumberPlate1NameColumn.ColumnName].Width = 150; // 表示幅
                //columns[table.NumberPlate1NameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.NumberPlate1NameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 陸運事務局名称
                //columns[table.NumberPlate1NameColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.NumberPlate1NameColumn.ColumnName].Header.Caption = "陸運事務局名称"; // 列キャプション
                //columns[table.NumberPlate1NameColumn.ColumnName].Width = 150; // 表示幅
                //columns[table.NumberPlate1NameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.NumberPlate1NameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 車両登録番号（種別）
                //columns[table.NumberPlate2Column.ColumnName].Hidden = true; // 表示設定
                //columns[table.NumberPlate2Column.ColumnName].Header.Caption = "車両登録番号（種別）"; // 列キャプション
                //columns[table.NumberPlate2Column.ColumnName].Width = 200; // 表示幅
                //columns[table.NumberPlate2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.NumberPlate2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 車両登録番号（カナ）
                //columns[table.NumberPlate3Column.ColumnName].Hidden = true; // 表示設定
                //columns[table.NumberPlate3Column.ColumnName].Header.Caption = "車両登録番号（カナ）"; // 列キャプション
                //columns[table.NumberPlate3Column.ColumnName].Width = 200; // 表示幅
                //columns[table.NumberPlate3Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.NumberPlate3Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 車両登録番号（プレート番号）
                //columns[table.NumberPlate4Column.ColumnName].Hidden = true; // 表示設定
                //columns[table.NumberPlate4Column.ColumnName].Header.Caption = "車両登録番号（プレート番号）"; // 列キャプション
                //columns[table.NumberPlate4Column.ColumnName].Width = 250; // 表示幅
                //columns[table.NumberPlate4Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                //columns[table.NumberPlate4Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                // プレートNo
                columns[table.PlateNoColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.PlateNoColumn.ColumnName].Header.Caption = "車両登録番号（プレート番号）"; // 列キャプション
                columns[table.PlateNoColumn.ColumnName].Width = 250; // 表示幅
                columns[table.PlateNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.PlateNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 型式指定番号
                //columns[table.ModelDesignationNoColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.ModelDesignationNoColumn.ColumnName].Header.Caption = "型式指定番号"; // 列キャプション
                //columns[table.ModelDesignationNoColumn.ColumnName].Width = 150; // 表示幅
                //columns[table.ModelDesignationNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                //columns[table.ModelDesignationNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 類別番号
                //columns[table.CategoryNoColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.CategoryNoColumn.ColumnName].Header.Caption = "類別番号"; // 列キャプション
                //columns[table.CategoryNoColumn.ColumnName].Width = 100; // 表示幅
                //columns[table.CategoryNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                //columns[table.CategoryNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 類別
                columns[table.ModelCategoryColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.ModelCategoryColumn.ColumnName].Header.Caption = "類別"; // 列キャプション
                columns[table.ModelCategoryColumn.ColumnName].Width = 150; // 表示幅
                columns[table.ModelCategoryColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.ModelCategoryColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// メーカーコード(車両情報)
                //columns[table.MakerCodeCarColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.MakerCodeCarColumn.ColumnName].Header.Caption = "メーカー(車両)"; // 列キャプション
                //columns[table.MakerCodeCarColumn.ColumnName].Width = 150; // 表示幅
                //columns[table.MakerCodeCarColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                //columns[table.MakerCodeCarColumn.ColumnName].Format = "0000";
                //columns[table.MakerCodeCarColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// メーカー名(車両情報)
                //columns[table.MakerNameCarColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.MakerNameCarColumn.ColumnName].Header.Caption = "メーカー名(車両)"; // 列キャプション
                //columns[table.MakerNameCarColumn.ColumnName].Width = 170; // 表示幅
                //columns[table.MakerNameCarColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.MakerNameCarColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 車種コード
                //columns[table.ModelCodeColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.ModelCodeColumn.ColumnName].Header.Caption = "車種コード"; // 列キャプション
                //columns[table.ModelCodeColumn.ColumnName].Width = 100; // 表示幅
                //columns[table.ModelCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                //columns[table.ModelCodeColumn.ColumnName].Format = "000";
                //columns[table.ModelCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 車種サブコード
                //columns[table.ModelSubCodeColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.ModelSubCodeColumn.ColumnName].Header.Caption = "車種サブコード"; // 列キャプション
                //columns[table.ModelSubCodeColumn.ColumnName].Width = 150; // 表示幅
                //columns[table.ModelSubCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                //columns[table.ModelSubCodeColumn.ColumnName].Format = "000";
                //columns[table.ModelSubCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 車種名
                columns[table.ModelNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.ModelNameColumn.ColumnName].Header.Caption = "車種名"; // 列キャプション
                columns[table.ModelNameColumn.ColumnName].Width = 150; // 表示幅
                columns[table.ModelNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.ModelNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 車検証型式
                //columns[table.CarInspectCertModelColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.CarInspectCertModelColumn.ColumnName].Header.Caption = "車検証型式"; // 列キャプション
                //columns[table.CarInspectCertModelColumn.ColumnName].Width = 150; // 表示幅
                //columns[table.CarInspectCertModelColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.CarInspectCertModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 型式（フル型）
                columns[table.FullModelColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.FullModelColumn.ColumnName].Header.Caption = "型式"; // 列キャプション
                columns[table.FullModelColumn.ColumnName].Width = 150; // 表示幅
                columns[table.FullModelColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.FullModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // UNDONE:車台番号
                columns[table.FrameNoColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.FrameNoColumn.ColumnName].Header.Caption = "車台番号"; // 列キャプション
                columns[table.FrameNoColumn.ColumnName].Width = 100; // 表示幅
                columns[table.FrameNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.FrameNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 車台型式
                //columns[table.FrameModelColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.FrameModelColumn.ColumnName].Header.Caption = "車台型式"; // 列キャプション
                //columns[table.FrameModelColumn.ColumnName].Width = 100; // 表示幅
                //columns[table.FrameModelColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.FrameModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// シャシーNo
                //columns[table.ChassisNoColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.ChassisNoColumn.ColumnName].Header.Caption = "シャシーNo"; // 列キャプション
                //columns[table.ChassisNoColumn.ColumnName].Width = 100; // 表示幅
                //columns[table.ChassisNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.ChassisNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 車両固有番号
                // 注意:表示してはいけない項目
                //columns[table.CarProperNoColumn.ColumnName].Hidden = false; // 表示設定
                //columns[table.CarProperNoColumn.ColumnName].Header.Caption = "車両固有番号"; // 列キャプション
                //columns[table.CarProperNoColumn.ColumnName].Width = 150; // 表示幅
                //columns[table.CarProperNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                //columns[table.CarProperNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 生産年式
                columns[table.ProduceTypeOfYearStringColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.ProduceTypeOfYearStringColumn.ColumnName].Header.Caption = "年式"; // 列キャプション
                columns[table.ProduceTypeOfYearStringColumn.ColumnName].Width = 150; // 表示幅
                columns[table.ProduceTypeOfYearStringColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.ProduceTypeOfYearStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // コメント
                columns[table.CommentColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.CommentColumn.ColumnName].Header.Caption = "コメント"; // 列キャプション
                columns[table.CommentColumn.ColumnName].Width = 100; // 表示幅
                columns[table.CommentColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.CommentColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // リペアカラーコード
                columns[table.RpColorCodeColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.RpColorCodeColumn.ColumnName].Header.Caption = "カラー"; // 列キャプション
                columns[table.RpColorCodeColumn.ColumnName].Width = 200; // 表示幅
                columns[table.RpColorCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.RpColorCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // カラー名称1
                columns[table.ColorName1Column.ColumnName].Hidden = false; // 表示設定
                columns[table.ColorName1Column.ColumnName].Header.Caption = "カラー名称"; // 列キャプション
                columns[table.ColorName1Column.ColumnName].Width = 100; // 表示幅
                columns[table.ColorName1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.ColorName1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                // トリムコード
                columns[table.TrimCodeColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.TrimCodeColumn.ColumnName].Header.Caption = "トリム"; // 列キャプション
                columns[table.TrimCodeColumn.ColumnName].Width = 150; // 表示幅
                columns[table.TrimCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.TrimCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // トリム名称
                columns[table.TrimNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.TrimNameColumn.ColumnName].Header.Caption = "トリム名称"; // 列キャプション
                columns[table.TrimNameColumn.ColumnName].Width = 100; // 表示幅
                columns[table.TrimNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.TrimNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 車両走行距離
                columns[table.MileageColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.MileageColumn.ColumnName].Header.Caption = "車両走行距離"; // 列キャプション
                columns[table.MileageColumn.ColumnName].Width = 150; // 表示幅
                columns[table.MileageColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.MileageColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 装備オブジェクト
                //columns[table.EquipObjColumn.ColumnName].Hidden = false; // 表示設定
                //columns[table.EquipObjColumn.ColumnName].Header.Caption = "装備オブジェクト"; // 列キャプション
                //columns[table.EquipObjColumn.ColumnName].Width = 200; // 表示幅
                //columns[table.EquipObjColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.EquipObjColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                #endregion

                #region 受注明細データ

                // 問合せ行番号
                columns[table.InqRowNumberColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.InqRowNumberColumn.ColumnName].Header.Caption = "問合せ行No"; // 列キャプション
                columns[table.InqRowNumberColumn.ColumnName].Width = 150; // 表示幅
                columns[table.InqRowNumberColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                //columns[table.InqRowNumberColumn.ColumnName].Format = "00";
                columns[table.InqRowNumberColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 問合せ行番号枝番
                //columns[table.InqRowNumDerivedNoColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.InqRowNumDerivedNoColumn.ColumnName].Header.Caption = "問合せ行番号枝番"; // 列キャプション
                //columns[table.InqRowNumDerivedNoColumn.ColumnName].Width = 200; // 表示幅
                //columns[table.InqRowNumDerivedNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                //columns[table.InqRowNumDerivedNoColumn.ColumnName].Format = "00";
                //columns[table.InqRowNumDerivedNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 商品種別
                columns[table.GoodsDivNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.GoodsDivNameColumn.ColumnName].Header.Caption = "部品種別"; // 列キャプション
                columns[table.GoodsDivNameColumn.ColumnName].Width = 100; // 表示幅
                columns[table.GoodsDivNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.GoodsDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // リサイクル部品種別
                columns[table.RecyclePrtKindNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.RecyclePrtKindNameColumn.ColumnName].Header.Caption = "リサイクル区分"; // 列キャプション
                columns[table.RecyclePrtKindNameColumn.ColumnName].Width = 200; // 表示幅
                columns[table.RecyclePrtKindNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.RecyclePrtKindNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 納品区分
                //columns[table.DeliveredGoodsDivNameColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.DeliveredGoodsDivNameColumn.ColumnName].Header.Caption = "納品区分"; // 列キャプション
                //columns[table.DeliveredGoodsDivNameColumn.ColumnName].Width = 100; // 表示幅
                //columns[table.DeliveredGoodsDivNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.DeliveredGoodsDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 取扱区分
                //columns[table.HandleDivCodeNameColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.HandleDivCodeNameColumn.ColumnName].Header.Caption = "取扱区分"; // 列キャプション
                //columns[table.HandleDivCodeNameColumn.ColumnName].Width = 100; // 表示幅
                //columns[table.HandleDivCodeNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.HandleDivCodeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 商品形態
                //columns[table.GoodsShapeNameColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.GoodsShapeNameColumn.ColumnName].Header.Caption = "商品形態"; // 列キャプション
                //columns[table.GoodsShapeNameColumn.ColumnName].Width = 100; // 表示幅
                //columns[table.GoodsShapeNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.GoodsShapeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 納品確認区分
                //columns[table.DelivrdGdsConfNmColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.DelivrdGdsConfNmColumn.ColumnName].Header.Caption = "納品確認区分"; // 列キャプション
                //columns[table.DelivrdGdsConfNmColumn.ColumnName].Width = 150; // 表示幅
                //columns[table.DelivrdGdsConfNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.DelivrdGdsConfNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 納品完了予定日
                //columns[table.DeliGdsCmpltDueDateForDispColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.DeliGdsCmpltDueDateForDispColumn.ColumnName].Header.Caption = "納品完了予定日"; // 列キャプション
                //columns[table.DeliGdsCmpltDueDateForDispColumn.ColumnName].Width = 200; // 表示幅
                //columns[table.DeliGdsCmpltDueDateForDispColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.DeliGdsCmpltDueDateForDispColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 回答納期
                columns[table.AnswerDeliveryDateColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.AnswerDeliveryDateColumn.ColumnName].Header.Caption = "回答納期"; // 列キャプション
                columns[table.AnswerDeliveryDateColumn.ColumnName].Width = 100; // 表示幅
                columns[table.AnswerDeliveryDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.AnswerDeliveryDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // BL商品コード
                columns[table.BLGoodsCodeColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.BLGoodsCodeColumn.ColumnName].Header.Caption = "BLｺｰﾄﾞ"; // 列キャプション
                columns[table.BLGoodsCodeColumn.ColumnName].Width = 100; // 表示幅
                columns[table.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // BL商品コード枝番
                columns[table.BLGoodsDrCodeColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.BLGoodsDrCodeColumn.ColumnName].Header.Caption = "BLｺｰﾄﾞ枝番"; // 列キャプション
                columns[table.BLGoodsDrCodeColumn.ColumnName].Width = 100; // 表示幅
                columns[table.BLGoodsDrCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.BLGoodsDrCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 発注数
                columns[table.SalesOrderCountColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.SalesOrderCountColumn.ColumnName].Header.Caption = "発注数"; // 列キャプション
                columns[table.SalesOrderCountColumn.ColumnName].Width = 100; // 表示幅
                columns[table.SalesOrderCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.SalesOrderCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.SalesOrderCountColumn.ColumnName].Format = "#,##0.00";

                // 納品数
                columns[table.DeliveredGoodsCountColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.DeliveredGoodsCountColumn.ColumnName].Header.Caption = "納品数"; // 列キャプション
                columns[table.DeliveredGoodsCountColumn.ColumnName].Width = 100; // 表示幅
                columns[table.DeliveredGoodsCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.DeliveredGoodsCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.DeliveredGoodsCountColumn.ColumnName].Format = "#,##0.00";

                // 商品番号
                columns[table.GoodsNoColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.GoodsNoColumn.ColumnName].Header.Caption = "品番"; // 列キャプション
                columns[table.GoodsNoColumn.ColumnName].Width = 200; // 表示幅
                columns[table.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // UNDONE:？？？商品名(カナ)→品名

                // メーカー
                columns[table.GoodsMakerCdColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.GoodsMakerCdColumn.ColumnName].Header.Caption = "メーカー"; // 列キャプション
                columns[table.GoodsMakerCdColumn.ColumnName].Width = 100; // 表示幅
                columns[table.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.GoodsMakerCdColumn.ColumnName].Format = "0000;'';''";
                columns[table.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // メーカー名
                columns[table.GoodsMakerNmColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.GoodsMakerNmColumn.ColumnName].Header.Caption = "メーカー名"; // 列キャプション
                columns[table.GoodsMakerNmColumn.ColumnName].Width = 150; // 表示幅
                columns[table.GoodsMakerNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.GoodsMakerNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 純正商品メーカー
                columns[table.PureGoodsMakerCdColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.PureGoodsMakerCdColumn.ColumnName].Header.Caption = "純正メーカー"; // 列キャプション
                columns[table.PureGoodsMakerCdColumn.ColumnName].Width = 200; // 表示幅
                columns[table.PureGoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.PureGoodsMakerCdColumn.ColumnName].Format = "0000;'';''";
                columns[table.PureGoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 純正商品メーカー名
                columns[table.PureGoodsMakerNmColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.PureGoodsMakerNmColumn.ColumnName].Header.Caption = "純正メーカー名"; // 列キャプション
                columns[table.PureGoodsMakerNmColumn.ColumnName].Width = 200; // 表示幅
                columns[table.PureGoodsMakerNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.PureGoodsMakerNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 問発純正商品番号
                //columns[table.InqPureGoodsNoColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.InqPureGoodsNoColumn.ColumnName].Header.Caption = "問発純正商品番号"; // 列キャプション
                //columns[table.InqPureGoodsNoColumn.ColumnName].Width = 200; // 表示幅
                //columns[table.InqPureGoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.InqPureGoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 問発純正商品名
                //columns[table.InqPureGoodsNameColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.InqPureGoodsNameColumn.ColumnName].Header.Caption = "問発純正商品名"; // 列キャプション
                //columns[table.InqPureGoodsNameColumn.ColumnName].Width = 200; // 表示幅
                //columns[table.InqPureGoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.InqPureGoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 回答純正商品番号
                //columns[table.AnsPureGoodsNoColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.AnsPureGoodsNoColumn.ColumnName].Header.Caption = "回答純正商品番号"; // 列キャプション
                //columns[table.AnsPureGoodsNoColumn.ColumnName].Width = 200; // 表示幅
                //columns[table.AnsPureGoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.AnsPureGoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 回答純正商品名
                //columns[table.AnsPureGoodsNameColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.AnsPureGoodsNameColumn.ColumnName].Header.Caption = "回答純正商品名"; // 列キャプション
                //columns[table.AnsPureGoodsNameColumn.ColumnName].Width = 200; // 表示幅
                //columns[table.AnsPureGoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.AnsPureGoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // UNDONE:問合せ品番

                // 問発商品名
                columns[table.InqGoodsNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.InqGoodsNameColumn.ColumnName].Header.Caption = "問合せ品名"; // 列キャプション
                columns[table.InqGoodsNameColumn.ColumnName].Width = 200; // 表示幅
                columns[table.InqGoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.InqGoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // UNDONE:回答品番

                // 回答商品名
                columns[table.AnsGoodsNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.AnsGoodsNameColumn.ColumnName].Header.Caption = "回答品名"; // 列キャプション
                columns[table.AnsGoodsNameColumn.ColumnName].Width = 200; // 表示幅
                columns[table.AnsGoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.AnsGoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 定価
                columns[table.ListPriceColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.ListPriceColumn.ColumnName].Header.Caption = "標準価格"; // 列キャプション
                columns[table.ListPriceColumn.ColumnName].Width = 100; // 表示幅
                columns[table.ListPriceColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.ListPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.ListPriceColumn.ColumnName].Format = "#,##0";

                // 単価
                columns[table.UnitPriceColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.UnitPriceColumn.ColumnName].Header.Caption = "単価"; // 列キャプション
                columns[table.UnitPriceColumn.ColumnName].Width = 100; // 表示幅
                columns[table.UnitPriceColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.UnitPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.UnitPriceColumn.ColumnName].Format = "#,##0";

                //// 商品補足情報
                //columns[table.GoodsAddInfoColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.GoodsAddInfoColumn.ColumnName].Header.Caption = "商品補足情報"; // 列キャプション
                //columns[table.GoodsAddInfoColumn.ColumnName].Width = 150; // 表示幅
                //columns[table.GoodsAddInfoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.GoodsAddInfoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 粗利額
                columns[table.RoughRrofitColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.RoughRrofitColumn.ColumnName].Header.Caption = "粗利額"; // 列キャプション
                columns[table.RoughRrofitColumn.ColumnName].Width = 100; // 表示幅
                columns[table.RoughRrofitColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.RoughRrofitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.RoughRrofitColumn.ColumnName].Format = "#,##0";

                // 粗利率
                columns[table.RoughRateColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.RoughRateColumn.ColumnName].Header.Caption = "粗利率"; // 列キャプション
                columns[table.RoughRateColumn.ColumnName].Width = 100; // 表示幅
                columns[table.RoughRateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.RoughRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.RoughRateColumn.ColumnName].Format = "#,##0";

                // 回答期限
                columns[table.AnswerLimitDateForDispColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.AnswerLimitDateForDispColumn.ColumnName].Header.Caption = "回答期限"; // 列キャプション
                columns[table.AnswerLimitDateForDispColumn.ColumnName].Width = 150; // 表示幅
                columns[table.AnswerLimitDateForDispColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.AnswerLimitDateForDispColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 備考(明細)
                columns[table.CommentDtlColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.CommentDtlColumn.ColumnName].Header.Caption = "備考"; // 列キャプション
                columns[table.CommentDtlColumn.ColumnName].Width = 150; // 表示幅
                columns[table.CommentDtlColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.CommentDtlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 棚番
                columns[table.ShelfNoColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.ShelfNoColumn.ColumnName].Header.Caption = "棚番"; // 列キャプション
                columns[table.ShelfNoColumn.ColumnName].Width = 100; // 表示幅
                columns[table.ShelfNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.ShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 追加区分
                //columns[table.AdditionalDivCdColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.AdditionalDivCdColumn.ColumnName].Header.Caption = "追加区分"; // 列キャプション
                //columns[table.AdditionalDivCdColumn.ColumnName].Width = 100; // 表示幅
                //columns[table.AdditionalDivCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                //columns[table.AdditionalDivCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 訂正区分
                //columns[table.CorrectDivCDColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.CorrectDivCDColumn.ColumnName].Header.Caption = "訂正区分"; // 列キャプション
                //columns[table.CorrectDivCDColumn.ColumnName].Width = 100; // 表示幅
                //columns[table.CorrectDivCDColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                //columns[table.CorrectDivCDColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 受注ステータス
                columns[table.AcptAnOdrStatusNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.AcptAnOdrStatusNameColumn.ColumnName].Header.Caption = "区分"; // 列キャプション
                columns[table.AcptAnOdrStatusNameColumn.ColumnName].Width = 150; // 表示幅
                columns[table.AcptAnOdrStatusNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.AcptAnOdrStatusNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 売上伝票番号
                columns[table.SalesSlipNumColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.SalesSlipNumColumn.ColumnName].Header.Caption = "伝票番号"; // 列キャプション
                columns[table.SalesSlipNumColumn.ColumnName].Width = 150; // 表示幅
                columns[table.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.SalesSlipNumColumn.ColumnName].Format = "000000000;'';''";
                columns[table.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 売上行番号
                columns[table.SalesRowNoColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.SalesRowNoColumn.ColumnName].Header.Caption = "行No"; // 列キャプション
                columns[table.SalesRowNoColumn.ColumnName].Width = 100; // 表示幅
                columns[table.SalesRowNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.SalesRowNoColumn.ColumnName].Format = "0000;'';''";
                columns[table.SalesRowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 問合せ・発注種別
                columns[table.InqOrdDivNmColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.InqOrdDivNmColumn.ColumnName].Header.Caption = "問合せ・発注区分"; // 列キャプション
                columns[table.InqOrdDivNmColumn.ColumnName].Width = 200; // 表示幅
                columns[table.InqOrdDivNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.InqOrdDivNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 回答作成区分
                columns[table.AnswerCreateDivNmColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.AnswerCreateDivNmColumn.ColumnName].Header.Caption = "回答作成区分"; // 列キャプション
                columns[table.AnswerCreateDivNmColumn.ColumnName].Width = 150; // 表示幅
                columns[table.AnswerCreateDivNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.AnswerCreateDivNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 在庫区分
                columns[table.StockDivNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.StockDivNameColumn.ColumnName].Header.Caption = "在庫区分"; // 列キャプション
                columns[table.StockDivNameColumn.ColumnName].Width = 150; // 表示幅
                columns[table.StockDivNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.StockDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// 表示順位
                //columns[table.DisplayOrderColumn.ColumnName].Hidden = true; // 表示設定
                //columns[table.DisplayOrderColumn.ColumnName].Header.Caption = "表示順位"; // 列キャプション
                //columns[table.DisplayOrderColumn.ColumnName].Width = 150; // 表示幅
                //columns[table.DisplayOrderColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                //columns[table.DisplayOrderColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // キャンペーンコード
                columns[table.CampaignCodeColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.CampaignCodeColumn.ColumnName].Header.Caption = "キャンペーンコード"; // 列キャプション
                columns[table.CampaignCodeColumn.ColumnName].Width = 200; // 表示幅
                columns[table.CampaignCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.CampaignCodeColumn.ColumnName].Format = "00000000;'';''";
                columns[table.CampaignCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // キャンペーン名
                columns[table.CampaignNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.CampaignNameColumn.ColumnName].Header.Caption = "キャンペーン名称"; // 列キャプション
                columns[table.CampaignNameColumn.ColumnName].Width = 150; // 表示幅
                columns[table.CampaignNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.CampaignNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                #endregion

                #endregion
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
            }
        }

        #endregion

        #region XML操作
        /// <summary>
        /// ＸＭＬデータの読込処理
        /// </summary>
        private void LoadStateXmlData()
        {
            int status = this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }
        #endregion

        #region 検索処理

        /// <summary>
        /// 検索処理
        /// </summary>
        private void Search()
        {
            if (this.SeachBeforeCheck())
            {
                this.ExecuteSearch();
            }
        }

        /// <summary>
        /// 検索前確認処理
        /// </summary>
        /// <returns>status</returns>
        public bool SeachBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // メッセージを表示
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMessage,
                    0,
                    MessageBoxButtons.OK);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }

        /// <summary>
        /// 画面入力チェック
        /// </summary>
        /// <param name="errMessage"></param>
        /// <param name="errComponent"></param>
        /// <returns></returns>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            // 問合せ日
            DateGetAcs.CheckDateResult cdResult;

            if (tde_InquiryDateSt.GetLongDate() != 0)
            {
                cdResult = this._dateGet.CheckDate(ref tde_InquiryDateSt, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("開始問合せ日{0}", ct_InputError);
                    errComponent = this.tde_InquiryDateSt;
                    return false;
                }
            }

            if (tde_InquiryDateEd.GetLongDate() != 0)
            {
                cdResult = this._dateGet.CheckDate(ref tde_InquiryDateEd, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("終了問合せ日{0}", ct_InputError);
                    errComponent = this.tde_InquiryDateEd;
                    return false;
                }
            }

            // 大小チェック
            if (tde_InquiryDateSt.GetLongDate() != 0
                && tde_InquiryDateEd.GetLongDate() != 0)
            {
                if (tde_InquiryDateSt.GetLongDate() > tde_InquiryDateEd.GetLongDate())
                {
                    errMessage = string.Format("問合せ日{0}", ct_RangeError);
                    errComponent = this.tde_InquiryDateSt;
                    return false;
                }
            }

            // 拠点の未入力チェック
            if (this.tEdit_SectionCodeAllowZero.Text == string.Empty)
            {
                errMessage = string.Format("拠点{0}", ct_NoInput);
                errComponent = this.tEdit_SectionCodeAllowZero;
                return false;
            }

            // 得意先大小チェック
            if (!this.CheckInputRange(this.tNedit_CustomerCode_St, this.tNedit_CustomerCode_Ed))
            {
                errMessage = string.Format("得意先{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                return false;
            }

            // 回答方法
            if (!this.uCheckEditor_AnswerMethodAll.Checked
                && !this.uCheckEditor_AnswerMethodAuto.Checked
                && !this.uCheckEditor_AnswerMethodManual.Checked)
            {
                errMessage = "回答方法を選択してください。";
                errComponent = this.uCheckEditor_AnswerMethodAll;
                return false;
            }

            // 伝票番号(受注ステータス)
            if (!this.uCheckEditor_AcptAnOdrStatusAll.Checked
                && !this.uCheckEditor_AcptAnOdrStatusEstimate.Checked
                && !this.uCheckEditor_AcptAnOdrStatusAccept.Checked
                && !this.uCheckEditor_AcptAnOdrStatusSales.Checked)
            {
                errMessage = "受注ステータスを選択してください。";
                errComponent = this.uCheckEditor_AcptAnOdrStatusAll;
                return false;
            }

            // 伝票番号大小チェック
            if (this.tEdit_SalesSlipNum_St.Text != string.Empty
                && this.tEdit_SalesSlipNum_Ed.Text != string.Empty)
            {
                int salesSlipNumSt;
                int salesSlipNumEd;

                Int32.TryParse(this.tEdit_SalesSlipNum_St.Text, out salesSlipNumSt);
                Int32.TryParse(this.tEdit_SalesSlipNum_Ed.Text, out salesSlipNumEd);

                if (salesSlipNumSt > salesSlipNumEd)
                {
                    errMessage = string.Format("伝票番号{0}", ct_RangeError);
                    errComponent = this.tEdit_SalesSlipNum_St;
                    return false;
                }
            }

            // 問合せ番号(問合せ・発注種別)
            if (!this.uCheckEditor_InqOrdDivAll.Checked
                && !this.uCheckEditor_InqOrdDivEstimate.Checked
                && !this.uCheckEditor_InqOrdDivAccept.Checked)
            {
                errMessage = "問合せ・発注種別を選択してください。";
                errComponent = this.uCheckEditor_InqOrdDivAll;
                return false;
            }

            // 問合せ番号大小チェック
            if (!this.CheckInputRange(this.tNedit_InquiryNumber_St, this.tNedit_InquiryNumber_Ed))
            {
                errMessage = string.Format("問合せ番号{0}", ct_RangeError);
                errComponent = this.tNedit_InquiryNumber_St;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 数値項目の大小比較
        /// </summary>
        /// <param name="stEdit"></param>
        /// <param name="edEdit"></param>
        /// <returns></returns>
        private bool CheckInputRange(TNedit stEdit, TNedit edEdit)
        {
            int stCode = stEdit.GetInt();
            int edCode = edEdit.GetInt();

            if (stCode != 0 &&
                 edCode != 0 &&
                 stCode > edCode)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        private void ExecuteSearch()
        {
            // 画面→抽出条件クラス
            SCMAnsHistInquiryInfo scmAnsHistInquiryInfo = this.SetExtraInfoFromScreen();

            string errMsg;
            int status = this._scmAnsHistInquiryAcs.Search(scmAnsHistInquiryInfo, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // 該当なし
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                this.Name,											// アセンブリID
                                errMsg, // 表示するメッセージ
                                -1,													// ステータス値
                                MessageBoxButtons.OK);
            }
            else
            {
                // エラー
                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOP, 						// エラーレベル
                                this.Name,											// アセンブリID
                                errMsg, // 表示するメッセージ
                                status,													// ステータス値
                                MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 画面情報取得
        /// </summary>
        /// <returns></returns>
        private SCMAnsHistInquiryInfo SetExtraInfoFromScreen()
        {
            SCMAnsHistInquiryInfo scmAnsHistInquiryInfo = new SCMAnsHistInquiryInfo();

            scmAnsHistInquiryInfo.EnterpriseCode = this._enterpriseCode; // 共通ヘッダの企業コード

            scmAnsHistInquiryInfo.St_InquiryDate = this.tde_InquiryDateSt.GetLongDate(); // 問合せ日(開始)
            scmAnsHistInquiryInfo.Ed_InquiryDate = this.tde_InquiryDateEd.GetLongDate(); // 問合せ日(終了)

            scmAnsHistInquiryInfo.InqOtherEpCd = this._enterpriseCode; // 問合せ先企業コード
            scmAnsHistInquiryInfo.InqOtherSecCd = this.tEdit_SectionCodeAllowZero.DataText; // 問合せ先拠点コード

            scmAnsHistInquiryInfo.St_CustomerCode = this.tNedit_CustomerCode_St.GetInt(); // 得意先(開始)
            scmAnsHistInquiryInfo.Ed_CustomerCode = this.tNedit_CustomerCode_Ed.GetInt(); // 得意先(終了)

            // 回答方法
            List<Int32> answerMethodList = new List<int>();
            if (this.uCheckEditor_AnswerMethodAll.Checked)
            {
                answerMethodList.AddRange(new Int32[] {(int)SCMAnsHistInquiryInfo.AnswerMethodState.Auto ,
                                                        (int)SCMAnsHistInquiryInfo.AnswerMethodState.ManualWeb ,
                                                        (int)SCMAnsHistInquiryInfo.AnswerMethodState.ManualOther});
            }
            else
            {
                if (this.uCheckEditor_AnswerMethodAuto.Checked)
                {
                    answerMethodList.Add((int)SCMAnsHistInquiryInfo.AnswerMethodState.Auto);
                }
                if (this.uCheckEditor_AnswerMethodManual.Checked)
                {
                    answerMethodList.Add((int)SCMAnsHistInquiryInfo.AnswerMethodState.ManualWeb);
                    answerMethodList.Add((int)SCMAnsHistInquiryInfo.AnswerMethodState.ManualOther);
                }
            }

            scmAnsHistInquiryInfo.AwnserMethod = answerMethodList.ToArray();

            // 伝票番号(受注ステータス)
            List<Int32> acptAnOdrStatusList = new List<int>();
            if (this.uCheckEditor_AcptAnOdrStatusAll.Checked)
            {
                acptAnOdrStatusList.AddRange(new Int32[] {(int)SCMAnsHistInquiryInfo.AcptAnOdrStatusState.NotSet ,
                                                        (int)SCMAnsHistInquiryInfo.AcptAnOdrStatusState.Estimate ,
                                                        (int)SCMAnsHistInquiryInfo.AcptAnOdrStatusState.Accept ,
                                                        (int)SCMAnsHistInquiryInfo.AcptAnOdrStatusState.Sales});
            }
            else
            {
                if (this.uCheckEditor_AcptAnOdrStatusEstimate.Checked)
                {
                    acptAnOdrStatusList.Add((int)SCMAnsHistInquiryInfo.AcptAnOdrStatusState.Estimate);
                }
                if (this.uCheckEditor_AcptAnOdrStatusAccept.Checked)
                {
                    acptAnOdrStatusList.Add((int)SCMAnsHistInquiryInfo.AcptAnOdrStatusState.Accept);
                }
                if (this.uCheckEditor_AcptAnOdrStatusSales.Checked)
                {
                    acptAnOdrStatusList.Add((int)SCMAnsHistInquiryInfo.AcptAnOdrStatusState.Sales);
                }
            }

            scmAnsHistInquiryInfo.AcptAnOdrStatus = acptAnOdrStatusList.ToArray();

            // 伝票番号
            scmAnsHistInquiryInfo.St_SalesSlipNum = this.tEdit_SalesSlipNum_St.DataText; // 伝票番号(開始)
            scmAnsHistInquiryInfo.Ed_SalesSlipNum = this.tEdit_SalesSlipNum_Ed.DataText; // 伝票番号(終了) 

            // 問合せ番号(問合せ・発注種別)
            List<Int32> inqOrdDivList = new List<int>();
            if (this.uCheckEditor_InqOrdDivAll.Checked)
            {
                inqOrdDivList.AddRange(new Int32[] {(int)SCMAnsHistInquiryInfo.InqOrdDivState.Estimate ,
                                                        (int)SCMAnsHistInquiryInfo.InqOrdDivState.Accept});
            }
            else
            {
                if (this.uCheckEditor_InqOrdDivEstimate.Checked)
                {
                    inqOrdDivList.Add((int)SCMAnsHistInquiryInfo.InqOrdDivState.Estimate);
                }
                if (this.uCheckEditor_InqOrdDivAccept.Checked)
                {
                    inqOrdDivList.Add((int)SCMAnsHistInquiryInfo.InqOrdDivState.Accept);
                }
            }

            scmAnsHistInquiryInfo.InqOrdDivCd = inqOrdDivList.ToArray();

            // 問合せ番号
            scmAnsHistInquiryInfo.St_InquiryNumber = this.tNedit_InquiryNumber_St.GetInt(); // 問合せ番号(開始)
            scmAnsHistInquiryInfo.Ed_InquiryNumber = this.tNedit_InquiryNumber_Ed.GetInt(); // 問合せ番号(終了)

            // 車両情報
            scmAnsHistInquiryInfo.NumberPlate4 = this.tNedit_NumberPlate4.GetInt(); // 車両登録番号（プレート番号）
            scmAnsHistInquiryInfo.FullModel = this.tEdit_FullModel.DataText; // 型式(フル)

            scmAnsHistInquiryInfo.CarMakerCode = this.tNedit_CarMakerCode.GetInt(); // メーカーコード
            scmAnsHistInquiryInfo.ModelCode = this.tNedit_ModelCode.GetInt(); // 車種コード
            scmAnsHistInquiryInfo.ModelSubCode = this.tNedit_ModelSubCode.GetInt(); // 車種サブコード

            // 明細情報
            scmAnsHistInquiryInfo.DetailMakerCode = this.tNedit_GoodsMakerCd.GetInt(); // メーカーコード
            scmAnsHistInquiryInfo.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt(); // BLコード
            scmAnsHistInquiryInfo.GoodsNo = this.tEdit_GoodsNo.DataText; // 品番
            scmAnsHistInquiryInfo.PureGoodsNo = this.tEdit_PureGoodsNo.DataText; // 純正品番

            return scmAnsHistInquiryInfo;
        }

        #endregion

        #endregion

        #region ■イベント
        /// <summary>
        /// PMSCM04101UA_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMSCM04101UA_Load(object sender, EventArgs e)
        {
            // 画面初期設定
            this.SetInitialSetting();

            // 画面クリア
            ClearScreen();

            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// 初期化タイマー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tde_InquiryDateSt.Focus();

            // XMLデータ読込
            LoadStateXmlData();

            // グリッドのアクティブ行をクリア
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// tRetKeyControl1_ChangeFocusイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                case "uCheckEditor_AnswerDivNon":
                    {
                        #region 回答区分 未アクション
                        if ((e.Key == Keys.Tab || e.Key == Keys.Left)
                            && e.NextCtrl == this.uGrid_Details)
                        {
                            if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                            {
                                this.uGrid_Details.DisplayLayout.Rows[this.uGrid_Details.DisplayLayout.Rows.Count - 1].Activate();
                                this.uGrid_Details.DisplayLayout.Rows[this.uGrid_Details.DisplayLayout.Rows.Count - 1].Selected = true;
                            }
                            else
                            {
                                if (uGroupBox_DetailInfo.Expanded)
                                {
                                    e.NextCtrl = this.tEdit_PureGoodsNo;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_InquiryNumber_Ed;
                                }
                            }
                        }
                        break;
                        #endregion
                    }
                case "tEdit_SectionCodeAllowZero":
                    {
                        #region 拠点コード
                        // 入力無し
                        if (this.tEdit_SectionCodeAllowZero.DataText == string.Empty
                            || this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0') == "00")
                        {
                            this.tEdit_SectionCodeAllowZero.Text = "00";
                            this.uLabel_SectionName.Text = "全社";

                            // 設定値保存
                            this._beforeSectionCode = "00";

                            if (e.NextCtrl == this.uButton_SectionCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                e.NextCtrl = this.tNedit_CustomerCode_St;
                            }

                            break;
                        }

                        // 入力変更なし
                        if (this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0') == this._beforeSectionCode)
                        {
                            if (e.NextCtrl == this.uButton_SectionCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                e.NextCtrl = this.tNedit_CustomerCode_St;
                            }

                            break;
                        }

                        // 入力値チェック
                        SecInfoSet secInfoSet;

                        int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this.tEdit_SectionCodeAllowZero.DataText);

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 結果を画面に設定
                            this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.Trim().PadLeft(2, '0');
                            this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;

                            // 設定値を保存
                            this._beforeSectionCode = secInfoSet.SectionCode.Trim().PadLeft(2, '0');
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tEdit_SectionCodeAllowZero.DataText = this._beforeSectionCode;

                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件で拠点コードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_SectionCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                            e.NextCtrl = this.tNedit_CustomerCode_St;
                        }

                        break;
                        #endregion
                    }
                case "tNedit_CustomerCode_St":
                    {
                        #region 得意先コード(開始)
                        if (e.NextCtrl == this.uButton_CustomerCdGuideSt)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tNedit_CustomerCode_Ed;
                            }
                        }

                        break;
                        #endregion
                    }
                case "tNedit_CustomerCode_Ed":
                    {
                        #region 得意先コード(終了)
                        if (e.NextCtrl == this.uButton_CustomerCdGuideEd)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.uCheckEditor_AnswerMethodAll;
                            }
                        }

                        break;
                        #endregion
                    }
                case "tNedit_InquiryNumber_Ed":
                    {
                        #region 問合せ番号(終了)
                        // 詳細条件が閉じられている場合に該当
                        if ((e.Key == Keys.Tab || e.Key == Keys.Right || e.Key == Keys.Down)
                            && e.NextCtrl == this.uGrid_Details)
                        {
                            if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                            {
                                this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                            }
                            else
                            {
                                e.NextCtrl = this.tde_InquiryDateSt;
                            }
                        }
                        break;
                        #endregion
                    }
                case "tNedit_GoodsMakerCd":
                    {
                        #region メーカーコード
                        // 入力無し
                        if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._beforeMakerCode = 0;
                            this.uLabel_GoodsMakerName.Text = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_GoodsMakerCd.GetInt() == this._beforeMakerCode)
                        {
                            if (e.NextCtrl == this.uButton_GoodsMakerCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                e.NextCtrl = this.tNedit_NumberPlate4;
                            }

                            break;
                        }

                        // 入力値チェック
                        MakerUMnt makerUMnt;

                        int status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt());

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 結果を画面に設定
                            this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                            this.uLabel_GoodsMakerName.Text = makerUMnt.MakerName;

                            // 設定値を保存
                            this._beforeMakerCode = makerUMnt.GoodsMakerCd;
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tNedit_GoodsMakerCd.SetInt(this._beforeMakerCode);

                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件でメーカーコードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_GoodsMakerCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            e.NextCtrl = this.tNedit_NumberPlate4;
                        }

                        break;
                        #endregion
                    }
                case "tNedit_BLGoodsCode":
                    {
                        #region BLコード
                        // 入力無し
                        if (this.tNedit_BLGoodsCode.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._beforeBLGoodsCode = 0;
                            this.uLabel_BLGoodsCodeName.Text = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_BLGoodsCode.GetInt() == this._beforeBLGoodsCode)
                        {
                            if (e.NextCtrl == this.uButton_BLGoodsCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {

                                e.NextCtrl = this.tEdit_FullModel;
                            }

                            break;
                        }

                        // 入力値チェック
                        BLGoodsCdUMnt blGoodsCdUMnt;

                        int status = this._blGoodsCdAcs.Read(out blGoodsCdUMnt, this._enterpriseCode, this.tNedit_BLGoodsCode.GetInt());

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 結果を画面に設定
                            this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
                            this.uLabel_BLGoodsCodeName.Text = blGoodsCdUMnt.BLGoodsHalfName;

                            // 設定値を保存
                            this._beforeBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tNedit_BLGoodsCode.SetInt(this._beforeBLGoodsCode);

                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件でBLコードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_BLGoodsCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            e.NextCtrl = this.tEdit_FullModel;
                        }

                        break;
                        #endregion
                    }
                case "tNedit_CarMakerCode":
                    {
                        #region メーカーコード(車両情報)
                        // 入力なし
                        if (this.tNedit_CarMakerCode.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._beforeMakerCodeCar = 0;
                            this.tNedit_ModelCode.SetInt(0);
                            this.tNedit_ModelSubCode.SetInt(0);
                            this.tEdit_ModelFullName.DataText = string.Empty;
                            this.tNedit_ModelCode.Enabled = false;
                            this.tNedit_ModelSubCode.Enabled = false;

                            if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }

                            break;
                        }

                        // 入力値変更なし
                        if (this.tNedit_CarMakerCode.GetInt() == this._beforeMakerCodeCar)
                        {
                            if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }

                            break;
                        }
                        
                        // 入力値チェック
                        MakerUMnt makerUMnt;

                        int status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_CarMakerCode.GetInt());

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 結果を画面に設定
                            this.tNedit_CarMakerCode.SetInt(makerUMnt.GoodsMakerCd);
                            this.tEdit_ModelFullName.DataText = makerUMnt.MakerName;

                            // 設定値を保存
                            this._beforeMakerCodeCar = makerUMnt.GoodsMakerCd;

                            // 車種コードを入力可能にする
                            this.tNedit_ModelCode.Enabled = true;
                            this.tNedit_ModelCode.SetInt(0);
                            this.tNedit_ModelSubCode.SetInt(0);

                            if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tNedit_ModelCode;
                            }
                            else if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tNedit_CarMakerCode.SetInt(this._beforeMakerCodeCar);

                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件でメーカーコードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン

                            return;
                        }

                        break;
                        #endregion
                    }
                case "tNedit_ModelCode":
                    {
                        #region 車種コード

                        int status;

                        // 入力なし
                        if (this.tNedit_ModelCode.GetInt() == 0)
                        {
                            // メーカー名を取得
                            MakerUMnt makerUMnt;

                            status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_CarMakerCode.GetInt());

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.tEdit_ModelFullName.DataText = makerUMnt.MakerName;
                            }

                            // 設定値を保存
                            this._beforeModelCode = this.tNedit_ModelCode.GetInt();

                            this.tNedit_ModelSubCode.Enabled = false;
                            this.tNedit_ModelSubCode.SetInt(0);

                            if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }

                            break;
                        }

                        // 入力値変更なし
                        if (this.tNedit_ModelCode.GetInt() == this._beforeModelCode)
                        {
                            if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }

                            break;
                        }

                        ModelNameU modelNameU = new ModelNameU();

                        status = this._modelNameUAcs.Read(
                            out modelNameU, this._enterpriseCode, this.tNedit_CarMakerCode.GetInt(), this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt());

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 結果を画面に設定
                            this.tNedit_ModelCode.SetInt(modelNameU.ModelCode);
                            this.tEdit_ModelFullName.DataText = modelNameU.ModelFullName;

                            // 設定値を保存
                            this._beforeModelCode = modelNameU.ModelCode;

                            // 車種サブコードを入力可能にする
                            this.tNedit_ModelSubCode.Enabled = true;
                            this.tNedit_ModelSubCode.SetInt(0);

                            if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tNedit_ModelSubCode;
                            }
                            else if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tNedit_ModelCode.SetInt(this._beforeModelCode);

                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件で車種コードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン
                            return;
                        }

                        break;
                        #endregion
                    }
                case "tNedit_ModelSubCode":
                    {
                        #region 車種サブコード

                        int status;
                        ModelNameU modelNameU;

                        // 入力なし
                        if (this.tNedit_ModelSubCode.GetInt() == 0)
                        {
                            modelNameU = new ModelNameU();

                            // メーカー、車種コードより名称を取得
                            status = this._modelNameUAcs.Read(
                            out modelNameU, this._enterpriseCode, this.tNedit_CarMakerCode.GetInt(), this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt());

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.tEdit_ModelFullName.DataText = modelNameU.ModelFullName;
                            }

                            this._beforeModelSubCode = this.tNedit_ModelSubCode.GetInt();

                            if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }

                            break;
                        }

                        // 変更なし
                        if (this.tNedit_ModelSubCode.GetInt() == this._beforeModelSubCode)
                        {
                            if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }

                            break;
                        }

                        modelNameU = new ModelNameU();

                        status = this._modelNameUAcs.Read(
                            out modelNameU, this._enterpriseCode, this.tNedit_CarMakerCode.GetInt(), this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt());

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 結果を画面に設定
                            this.tNedit_ModelSubCode.SetInt(modelNameU.ModelSubCode);
                            this.tEdit_ModelFullName.DataText = modelNameU.ModelFullName;

                            // 設定値を保存
                            this._beforeModelSubCode = modelNameU.ModelSubCode;

                            if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }
                        }
                        else
                        {
                            // 前回入力値を設定
                            this.tNedit_ModelSubCode.SetInt(this._beforeModelSubCode);

                            // 該当なし
                            TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                            this.Name,											// アセンブリID
                                            "指定された条件で車種サブコードは存在しませんでした。", // 表示するメッセージ
                                            -1,													// ステータス値
                                            MessageBoxButtons.OK);								// 表示するボタン
                            return;
                        }

                        break;
                        #endregion
                    }
                case "tEdit_PureGoodsNo":
                    {
                        #region 純正品番
                        if ((e.Key == Keys.Tab || e.Key == Keys.Right || e.Key == Keys.Down)
                            && e.NextCtrl == this.uGrid_Details)
                        {
                            if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                            {
                                this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                            }
                            else
                            {
                                e.NextCtrl = this.tde_InquiryDateSt;
                            }
                        }

                        break;
                        #endregion
                    }
                case "uGrid_Details":
                    {
                        #region グリッド
                        if (e.Key == Keys.Tab)
                        {
                            if (this.uGrid_Details.Rows.Count == 0 ||
                                ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null)))
                            {
                                if (e.ShiftKey)
                                {
                                    if (this.uGroupBox_DetailInfo.Expanded)
                                    {
                                        e.NextCtrl = this.tEdit_PureGoodsNo;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_InquiryNumber_Ed;
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }
                            else
                            {
                                if (e.ShiftKey)
                                {
                                    if (this.uGrid_Details.DisplayLayout.ActiveRow.Index == 0)
                                    {
                                        if (this.uGroupBox_DetailInfo.Expanded)
                                        {
                                            e.NextCtrl = this.tEdit_PureGoodsNo;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_InquiryNumber_Ed;
                                        }
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uGrid_Details;
                                        this.uGrid_Details.PerformAction(UltraGridAction.AboveRow);
                                    }
                                }
                                else
                                {
                                    if (this.uGrid_Details.DisplayLayout.ActiveRow.Index
                                        == this.uGrid_Details.DisplayLayout.Rows.Count - 1)
                                    {
                                        e.NextCtrl = this.tde_InquiryDateSt;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uGrid_Details;
                                        this.uGrid_Details.PerformAction(UltraGridAction.BelowRow);
                                    }
                                }
                            }
                        }
                        break;
                        #endregion
                    }
            }
        }

        #region ガイドボタン押下イベント
        /// <summary>
        /// 拠点ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SectionCdGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.Trim().PadLeft(2, '0');
                    this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();

                    this._beforeSectionCode = secInfoSet.SectionCode.Trim().PadLeft(2, '0');

                    // 次フォーカス
                    tNedit_CustomerCode_St.Focus();
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerCdGuideSt_Click(object sender, EventArgs e)
        {
            // 押下されたボタンを退避
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            // 得意先ガイド用ライブラリ名変更
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// 得意先検索アクセスクラス
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult ret = customerSearchForm.ShowDialog(this);
            if (ret == DialogResult.OK)
            {
                // 次フォーカス
                if (sender == this.uButton_CustomerCdGuideSt)
                {
                    this.tNedit_CustomerCode_Ed.Focus();
                }
                else
                {
                    this.uCheckEditor_AnswerMethodAll.Focus();
                }

            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            CustomerInfo customerInfo = new CustomerInfo();

            int status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerSearchRet.CustomerCode, out customerInfo);
            if (status != 0) return;

            if (_customerGuideSender == this.uButton_CustomerCdGuideSt)
            {
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
            }

        }

        /// <summary>
        /// メーカーガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUmnt;

            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUmnt);

            if (status == 0)
            {
                this.tNedit_GoodsMakerCd.SetInt(makerUmnt.GoodsMakerCd);
                this.uLabel_GoodsMakerName.Text = makerUmnt.MakerName;

                this._beforeMakerCode = makerUmnt.GoodsMakerCd;

                // フォーカス
                this.tNedit_BLGoodsCode.Focus();
            }
        }

        /// <summary>
        /// BLコードガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_BLGoodsCdGuide_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt;

            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);

            if (status == 0)
            {
                this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
                this.uLabel_BLGoodsCodeName.Text = blGoodsCdUMnt.BLGoodsHalfName;

                this._beforeBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;

                // フォーカス
                this.tEdit_GoodsNo.Focus();
            }
        }

        /// <summary>
        /// 車種ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_ModelFullGuide_Click(object sender, EventArgs e)
        {
            
            ModelNameU modelNameU;

            int makerCode = this.tNedit_CarMakerCode.GetInt();
            int status = this._modelNameUAcs.ExecuteGuid(makerCode, this._enterpriseCode, out modelNameU);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_CarMakerCode.SetInt(modelNameU.MakerCode);
                this.tNedit_ModelCode.SetInt(modelNameU.ModelCode);
                this.tNedit_ModelSubCode.SetInt(modelNameU.ModelSubCode);
                this.tEdit_ModelFullName.DataText = modelNameU.ModelFullName;

                this.tNedit_ModelCode.Enabled = true;
                this.tNedit_ModelSubCode.Enabled = true;

                this._beforeMakerCodeCar = modelNameU.MakerCode;
                this._beforeModelCode = modelNameU.ModelCode;
                this._beforeModelSubCode = modelNameU.ModelSubCode;

                // フォーカス
                this.tNedit_GoodsMakerCd.Focus();
            }
        }
        #endregion

        #region 回答区分制御
        /// <summary>
        /// 回答区分「全て」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AnswerMethodAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AnswerMethodAll.Checked)
            {
                this.uCheckEditor_AnswerMethodAuto.Checked = false;
                this.uCheckEditor_AnswerMethodManual.Checked = false;
            }
        }

        /// <summary>
        /// 回答区分「自動」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AnswerMethodAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AnswerMethodAuto.Checked)
            {
                this.uCheckEditor_AnswerMethodAll.Checked = false;
            }
        }

        /// <summary>
        /// 回答区分「手動」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AnswerMethodManual_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AnswerMethodManual.Checked)
            {
                this.uCheckEditor_AnswerMethodAll.Checked = false;
            }
        }
        #endregion

        #region 伝票番号(受注ステータス)制御
        /// <summary>
        /// 伝票番号 受注ステータス「全て」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AcptAnOdrStatusAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AcptAnOdrStatusAll.Checked)
            {
                this.uCheckEditor_AcptAnOdrStatusSales.Checked = false;
                this.uCheckEditor_AcptAnOdrStatusAccept.Checked = false;
                this.uCheckEditor_AcptAnOdrStatusEstimate.Checked = false;
            }
        }

        /// <summary>
        /// 伝票番号 受注ステータス「売上」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AcptAnOdrStatusSales_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AcptAnOdrStatusSales.Checked)
            {
                this.uCheckEditor_AcptAnOdrStatusAll.Checked = false;
            }
        }

        /// <summary>
        /// 伝票番号 受注ステータス「受注」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AcptAnOdrStatusAccept_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AcptAnOdrStatusAccept.Checked)
            {
                this.uCheckEditor_AcptAnOdrStatusAll.Checked = false;
            }
        }

        /// <summary>
        /// 伝票番号 受注ステータス「見積」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AcptAnOdrStatusEstimate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AcptAnOdrStatusEstimate.Checked)
            {
                this.uCheckEditor_AcptAnOdrStatusAll.Checked = false;
            }
        }
        #endregion

        #region 問合せ番号(問合せ発注種別)制御
        /// <summary>
        /// 問合せ番号 問合せ発注種別「全て」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_InqOrdDivAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_InqOrdDivAll.Checked)
            {
                this.uCheckEditor_InqOrdDivAccept.Checked = false;
                this.uCheckEditor_InqOrdDivEstimate.Checked = false;
            }
        }

        /// <summary>
        /// 問合せ番号 問合せ発注種別「受注」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_InqOrdDivAccept_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_InqOrdDivAccept.Checked)
            {
                this.uCheckEditor_InqOrdDivAll.Checked = false;
            }
        }

        /// <summary>
        /// 問合せ番号 問合せ発注種別「見積」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_InqOrdDivEstimate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_InqOrdDivEstimate.Checked)
            {
                this.uCheckEditor_InqOrdDivAll.Checked = false;
            }
        }
        #endregion

        #region ツールバークリック
        /// <summary>
        /// tToolbarsManager1_ToolClickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        this.Search();
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        // 画面クリア
                        this.ClearScreen();

                        // グリッドクリア
                        this._scmAnsHistInquiryAcs.SCMAnsHistInquiryDataTable.Clear();

                        this.Initial_Timer.Enabled = true;

                        break;
                    }
            }
        }
        #endregion

        #region グリッド関連
        /// <summary>
        /// uGrid_Details_Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            // アクティブ行の解除
            if (this.uGrid_Details.ActiveRow != null)
            {
                this.uGrid_Details.ActiveRow.Selected = false;
                this.uGrid_Details.ActiveRow = null;
            }
        }

        /// <summary>
        /// uGrid_Details_InitializeLayoutイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // ヘッダクリックアクションの設定(ソート処理)
            e.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            // 行フィルター設定
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            // 列移動可能
            e.Layout.Override.AllowColMoving = AllowColMoving.WithinBand;
        }

        /// <summary>
        /// uGrid_Details_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.Rows.Count == 0 ||
                ((uGrid.ActiveCell == null) && (uGrid.ActiveRow == null)))
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            e.Handled = true;
                            this.tNedit_CarMakerCode.Focus();
                            break;
                        }
                    case Keys.Down:
                    case Keys.Right:
                        {
                            e.Handled = true;
                            this.tde_InquiryDateSt.Focus();
                            break;
                        }
                    case Keys.Left:
                        {
                            e.Handled = true;
                            if (this.uGroupBox_DetailInfo.Expanded)
                            {
                                this.tEdit_PureGoodsNo.Focus();
                            }
                            else
                            {
                                this.tNedit_InquiryNumber_Ed.Focus();
                            }

                            break;
                        }
                }

                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Left:
                    {
                        e.Handled = true;
                        if (uGrid.DisplayLayout.ActiveRow.Index != 0)
                        {
                            uGrid.PerformAction(UltraGridAction.AboveRow);
                        }
                        else
                        {
                            if (e.KeyCode == Keys.Up)
                            {
                                this.tNedit_CarMakerCode.Focus();
                            }
                            else
                            {
                                if (this.uGroupBox_DetailInfo.Expanded)
                                {
                                    this.tEdit_PureGoodsNo.Focus();
                                }
                                else
                                {
                                    this.tNedit_InquiryNumber_Ed.Focus();
                                }
                            }
                        }
                        break;
                    }
                case Keys.Down:
                case Keys.Right:
                    {
                        e.Handled = true;
                        if (uGrid.DisplayLayout.ActiveRow.Index != uGrid.DisplayLayout.Rows.Count - 1)
                        {
                            uGrid.PerformAction(UltraGridAction.BelowRow);
                        }
                        else
                        {
                            this.tde_InquiryDateSt.Focus();
                        }
                        break;
                    }
            }
        }
        #endregion

        #endregion

    }
}