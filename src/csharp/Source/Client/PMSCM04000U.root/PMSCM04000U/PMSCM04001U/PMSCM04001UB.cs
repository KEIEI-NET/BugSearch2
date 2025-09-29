//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 問合せ一覧/受注検索ウィンドウ
// プログラム概要   : SCM受注データ、SCM受注明細データの照会を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/05/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/04/16  修正内容 : キャンセル対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/17  修正内容 : キャンセル追加対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2010/06/17  修正内容 : Delphi売伝を起動するように変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2011/01/24  修正内容 : ・明細単位で回答状況がわかるように修正
//                                 ・問合/発注を別明細で表示するように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2011/02/14  修正内容 : ・取消対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 久保田 誠
// 作 成 日  2011/05/26  修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号  10703242-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2011/06/09  修正内容 : 名称変更対応[SCM→PCC]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : wangl2
// 作 成 日  2013/04/03  修正内容 : Redmine#35273 (SCM障害№10319)対応
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : qijh
// 作 成 日  2013/02/27  修正内容 : 2013/06/18配信 Redmine#34752 「PMSCMのNo.10385」BLPの対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 吉岡
// 作 成 日  2015/02/20  修正内容 : SCM高速化 C向け種別特記対応
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 問合せ一覧(明細)/受注検索ウィンドウ(明細)検索フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM受注データ、SCM受注明細データの照会を行う</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2009.05.27</br>
    /// <br></br>
    public partial class PMSCM04001UB : Form
    {
        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        # region Event
        /// <summary>画面抽出条件取得イベント</summary>
        internal event SetExtraInfoFromScreen SetScreen;

        # endregion

        // ===================================================================================== //
        // デリゲート
        // ===================================================================================== //
        # region Delegate
        /// <summary>
        /// 画面抽出条件取得デリゲート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="salesRowNo"></param>
        internal delegate SCMInquiryOrder SetExtraInfoFromScreen();

        # endregion

        #region ■private定数
        //>>>2010/06/17
        //private const string SALESSLIPINPUT_EXE_NAME = "MAHNB01000U.exe"; // 売上伝票入力の実行exe
        private const string SALESSLIPINPUT_EXE_NAME = "MAHNB01001U.exe"; // 売上伝票入力の実行exe
        //<<<2010/06/17
        // 画面状態保存用ファイル名
        private const string XML_FILE_INITIAL_DATA = "PMSCM04001UB.dat";// ADD  2013/04/03 wangl2 #35273
        #endregion

        #region ■private変数

        private ControlScreenSkin _controlScreenSkin; // 共通スキン

        SCMInquiryOrderAcs _scmInquiryOrderAcs; // 問合せ一覧表アクセスクラス

        UltraGridRow _scmInquiryResultRow; // SCM受注データ(伝票)

        // -- ADD 2010/02/09 -------------------->>>
        string _inquiryNumber = string.Empty;    //問合せ番号

        string _acptAnOdrStatus = string.Empty;  //受注ステータス
 
        string _salesSlipNum = string.Empty;     //売上伝票番号
        // -- ADD 2010/02/09 --------------------<<<

        // -- ADD 2010/03/02 -------------------->>>
        string _inqOriginalEpCd = string.Empty;  //問合せ元企業コード

        string _inqOriginalSecCd = string.Empty; //問合せ元拠点コード
        // -- ADD 2010/03/02 --------------------<<<

        // 2011/02/14 Add >>>
        int _inqOrdDivCd = 0;                    // 問合せ・発注種別
        // 2011/02/14 Add <<<

        // 2010/05/27 Add >>>
        int _answerDivCd = 0;
        // 2010/05/27 Add <<<

        private Mode _mode; // 起動モード

        private string[] _commandLineArgs; // コマンドライン引数

        private bool _isLegacySection; // 旧システム連携有無(true:旧システム連携あり)
        // グリッド状態保存
        private GridStateController _gridStateController;// ADD  2013/04/03 wangl2 #35273

        #endregion

        #region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMSCM04001UB()
        {
            InitializeComponent();
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="commandLineArgs">親画面起動時のコマンドライン引数</param>
        /// <param name="scmInquiryResultRow">親画面で選択したSCM受注データ(伝票)</param>
        public PMSCM04001UB(int mode, string[] commandLineArgs, UltraGridRow scmInquiryResultRow, bool isLegacySection,
            bool canInputSalesSlip  // ADD 2010/04/16 キャンセル対応
        ) : this()
        {
            this._mode = (Mode)mode;
            this._commandLineArgs = commandLineArgs;
            this._scmInquiryResultRow = scmInquiryResultRow;
            this._isLegacySection = isLegacySection;


            // -- ADD 2010/02/09 -------------------->>>
            this.GetGuideInstance();
            this._inquiryNumber = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InquiryNumberColumn.ColumnName].Value.ToString();
            this._acptAnOdrStatus = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AcptAnOdrStatusColumn.ColumnName].Value.ToString();
            this._salesSlipNum = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesSlipNumColumn.ColumnName].Value.ToString();
            // -- ADD 2010/02/09 --------------------<<<

            // -- ADD 2010/03/02 -------------------->>>
            this._inqOriginalEpCd = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOriginalEpCdColumn.ColumnName].Value.ToString().Trim();	//@@@@20230303
            this._inqOriginalSecCd = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOriginalSecCdColumn.ColumnName].Value.ToString();
            // -- ADD 2010/03/02 --------------------<<<

            // 2010/05/27 Add >>>
            this._answerDivCd = (int)this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnswerDivCdColumn.ColumnName].Value;
            // 2010/05/27 Add <<<

            // 2011/02/14 Add >>>
            this._inqOrdDivCd = (int)this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOrdDivCdColumn.ColumnName].Value;
            // 2011/02/14 Add <<<

            // 2010/05/27 >>>
            //// ADD 2010/04/16 キャンセル対応 ---------->>>>>
            //// 以下の場合、売上伝票入力を行えません。
            //// ①回答区分が｢回答完了｣
            //// ②回答区分が｢キャンセル｣で『未回答データが全てキャンセル』または『全て返品済み』
            //this.uButton_SalesSlip.Enabled = canInputSalesSlip;
            //// ADD 2010/04/16 キャンセル対応 ----------<<<<<


            this.uButton_SalesSlip.Visible = false;
            // 2010/05/27 <<<
        }
        #endregion

        #region ■privateメソッド
        /// <summary>
        /// Visible設定イベントコール処理
        /// </summary>
        private SCMInquiryOrder SetExtraInfoFromScreenEventCall()
        {
            if (this.SetScreen != null)
            {
                return this.SetScreen();
            }
            return null;
        }

        /// <summary>
        /// 画面初期設定
        /// </summary>
        private void SetInitialSetting()
        {
            this._gridStateController = new GridStateController();// ADD  2013/04/03 wangl2 #35273
            // タイトル
            if (this._mode == Mode.SalesSlip)
            {
                this.Text = "受注検索ウィンドウ（明細）";
            }
            else
            {
                //>>>2011/06/09
                //this.Text = "SCM問合せ一覧（明細）";
                this.Text = "PCC問合せ一覧（明細）";
                //<<<2011/06/09
            }

            // ガイドアクセス初期化
            this.GetGuideInstance();
            
            // スキン設定
            this._controlScreenSkin = new ControlScreenSkin();

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // ボタン制御
            // イメージ設定
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.uButton_SalesSlip.Appearance.Image = imageList16.Images[(int)Size16_Index.SLIP];
            this.uButton_SalesSlip.Appearance.ImageHAlign = HAlign.Center;
            this.uButton_SalesSlip.Appearance.ImageVAlign = VAlign.Top;
            this.uButton_Close.Appearance.Image = imageList16.Images[(int)Size16_Index.CLOSE];
            this.uButton_Close.Appearance.ImageHAlign = HAlign.Center;
            this.uButton_Close.Appearance.ImageVAlign = VAlign.Top;

            // 親画面が売上伝票入力画面から遷移した場合と、
            // 旧システム連携拠点の場合は売上伝票入力ボタンを非表示にする。
            if (this._mode == Mode.SalesSlip || this._isLegacySection)
            {
                this.uButton_SalesSlip.Visible = false;
            }

            // 各項目の初期値設定
            // 類別
            this.uLabel_ModelCategory.Text 
                = this._scmInquiryResultRow.Cells[
                this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ModelCategoryColumn.ColumnName].Value.ToString();

            // 車種
            this.uLabel_ModelName.Text
                = this._scmInquiryResultRow.Cells[
                this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ModelNameColumn.ColumnName].Value.ToString();

            // 型式
            this.uLabel_ModelDesignationNo.Text
                = this._scmInquiryResultRow.Cells[
                this._scmInquiryOrderAcs.SCMInquiryResultDataTable.FullModelColumn.ColumnName].Value.ToString();

            // 年式
            this.uLabel_ProduceTypeOfYearNum.Text
                = this._scmInquiryResultRow.Cells[
                this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ProduceTypeOfYearStringColumn.ColumnName].Value.ToString();

            // 金額
            Int64 salesTotalTaxInc = (Int64)this._scmInquiryResultRow.Cells[
                this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesTotalTaxIncColumn.ColumnName].Value;
            this.uLabel_SalesTotalTaxInc.Text
                = salesTotalTaxInc.ToString("#,##0");

            // グリッド設定
            this.SetGridSetting();

            this.LoadStateXmlData();// ADD  2013/04/03 wangl2 #35273
        }

        /// <summary>
        /// ガイドアクセス初期化
        /// </summary>
        private void GetGuideInstance()
        {
            this._scmInquiryOrderAcs = SCMInquiryOrderAcs.GetInstance();
        }

        /// <summary>
        /// グリッド設定
        /// </summary>
        private void SetGridSetting()
        {
            // 画面→抽出条件クラス
            SCMInquiryOrder scmInquiryOrder = this.SetExtraInfoFromScreenEventCall();

            SCMAcOdrDataDataSet.SCMInquiryResultDataTable ttable = this._scmInquiryOrderAcs.SCMInquiryResultDataTable;

            SCMInquiryResultWork scmInquiryResultWork = new SCMInquiryResultWork();
            scmInquiryResultWork.AcptAnOdrStatus = (int)this._scmInquiryResultRow.Cells[ttable.AcptAnOdrStatusColumn.ColumnName].Value;
            //scmInquiryResultWork.AnsEmployeeCd = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnsEmployeeCdColumn.ColumnName].Value;
            //scmInquiryResultWork.AnsEmployeeNm = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnsEmployeeNmColumn.ColumnName].Value;
            
            scmInquiryResultWork.AnswerDivCd = (int)this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnswerDivCdColumn.ColumnName].Value;
            
            //scmInquiryResultWork.AwnserMethod = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnswerMethodColumn.ColumnName].Value;
            //scmInquiryResultWork.CarInspectCertModel = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.CarInspectCertModelColumn.ColumnName].Value;
            //scmInquiryResultWork.CarProperNo = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.CarProperNoColumn.ColumnName].Value;
            //scmInquiryResultWork.CategoryNo = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.CategoryNoColumn.ColumnName].Value;
            //scmInquiryResultWork.ChassisNo = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ChassisNoColumn.ColumnName].Value;
            //scmInquiryResultWork.ColorName1 = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ColorName1Column.ColumnName].Value;
            //scmInquiryResultWork.Comment = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.CommentColumn.ColumnName].Value;
            //scmInquiryResultWork.CustomerCode = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.CustomerCodeColumn.ColumnName].Value;
            //scmInquiryResultWork.CustomerName = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.CustomerNameColumn.ColumnName].Value;
            scmInquiryResultWork.EnterpriseCode = scmInquiryOrder.EnterpriseCode;
            //scmInquiryResultWork.FrameModel = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.FrameModelColumn.ColumnName].Value;
            //scmInquiryResultWork.FrameNo = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.FrameNoColumn.ColumnName].Value;
            //scmInquiryResultWork.FullModel = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.FullModelColumn.ColumnName].Value;
            //scmInquiryResultWork.InqEmployeeCd = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqEmployeeCdColumn.ColumnName].Value;
            //scmInquiryResultWork.InqEmployeeCd_Car = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqEmployeeCdCarColumn.ColumnName].Value;
            //scmInquiryResultWork.InqEmployeeNm = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqEmployeeNmColumn.ColumnName].Value;
            //scmInquiryResultWork.InqEmployeeNm_Car = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqEmployeeNmCarColumn.ColumnName].Value;
            scmInquiryResultWork.InqOrdDivCd = (int)this._scmInquiryResultRow.Cells[ttable.InqOrdDivCdColumn.ColumnName].Value;
            //scmInquiryResultWork.InqOrdNote = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOrdNoteColumn.ColumnName].Value;

            scmInquiryResultWork.InqOriginalEpCd = ((string)this._scmInquiryResultRow.Cells[ttable.InqOriginalEpCdColumn.ColumnName].Value).Trim();	//@@@@20230303
            scmInquiryResultWork.InqOriginalSecCd = (string)this._scmInquiryResultRow.Cells[ttable.InqOriginalSecCdColumn.ColumnName].Value;
            scmInquiryResultWork.InqOtherEpCd = (string)this._scmInquiryResultRow.Cells[ttable.InqOtherEpCdColumn.ColumnName].Value;
            scmInquiryResultWork.InqOtherSecCd = (string)this._scmInquiryResultRow.Cells[ttable.InqOtherSecCdColumn.ColumnName].Value;
            //scmInquiryResultWork.InquiryDate = (int)this._scmInquiryResultRow.Cells[ttable.InquiryDateColumn.ColumnName].Value;
            //scmInquiryResultWork.InquiryDate_Car = (int)this._scmInquiryResultRow.Cells[ttable.InquiryDateCarColumn.ColumnName].Value;
            scmInquiryResultWork.InquiryNumber = (long)this._scmInquiryResultRow.Cells[ttable.InquiryNumberColumn.ColumnName].Value;

            //scmInquiryResultWork.JudgementDate = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.JudgementDateColumn.ColumnName].Value;
            //scmInquiryResultWork.MakerCode = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.MakerCodeColumn.ColumnName].Value;
            //scmInquiryResultWork.Mileage = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.MileageColumn.ColumnName].Value;
            //scmInquiryResultWork.ModelCode = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ModelCodeColumn.ColumnName].Value;
            //scmInquiryResultWork.ModelDesignationNo = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ModelDesignationNoColumn.ColumnName].Value;
            //scmInquiryResultWork.ModelName = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ModelNameColumn.ColumnName].Value;
            //scmInquiryResultWork.ModelSubCode = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ModelSubCodeColumn.ColumnName].Value;
            //scmInquiryResultWork.NumberPlate1Code = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.NumberPlate1CodeColumn.ColumnName].Value;
            //scmInquiryResultWork.NumberPlate1Name = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.NumberPlate1NameColumn.ColumnName].Value;
            //scmInquiryResultWork.NumberPlate2 = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.NumberPlate2Column.ColumnName].Value;
            //scmInquiryResultWork.NumberPlate3 = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.NumberPlate3Column.ColumnName].Value;
            //scmInquiryResultWork.NumberPlate4 = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.NumberPlate4Column.ColumnName].Value;
            //scmInquiryResultWork.ProduceTypeOfYearNum = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ProduceTypeOfYearNumColumn.ColumnName].Value;
            //scmInquiryResultWork.RpColorCode = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.RpColorCodeColumn.ColumnName].Value;
            //scmInquiryResultWork.SalesOrderDate_Car = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesOrderDateCarColumn.ColumnName].Value;
            //scmInquiryResultWork.SalesOrderEmployeeCd = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesOrderEmployeeCdColumn.ColumnName].Value;
            //scmInquiryResultWork.SalesOrderEmployeeNm = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesOrderEmployeeNmColumn.ColumnName].Value;
            // DEL 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
            // FIXME:1問合せが複数の伝票に分かれることもあるので、伝票番号を条件に設定しない
            scmInquiryResultWork.SalesSlipNum = (string)this._scmInquiryResultRow.Cells[ttable.SalesSlipNumColumn.ColumnName].Value;
            // DEL 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<
            //scmInquiryResultWork.SalesTotalTaxInc = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesTotalTaxIncColumn.ColumnName].Value;
            //scmInquiryResultWork.TrimCode = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.TrimCodeColumn.ColumnName].Value;
            //scmInquiryResultWork.TrimName = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.TrimNameColumn.ColumnName].Value;

            scmInquiryResultWork.UpdateDate = (DateTime)this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.UpdateDateColumn.ColumnName].Value;
            scmInquiryResultWork.UpdateTime = (int)this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.UpdateTimeColumn.ColumnName].Value;
            
            //this._scmInquiryOrderAcs.Setting
            string errMsg;

            // DEL 2010/06/17 キャンセル追加対応 ---------->>>>>
            int status = 0; // finally句で実施する、グリッドのフォント色を赤に変更する処理で使用
            // DEL 2010/06/17 キャンセル追加対応 ----------<<<<<
            if (scmInquiryResultWork != null)
            {
                // DEL 2010/06/17 キャンセル追加対応 ---------->>>>>
                //this._scmInquiryOrderAcs.SearchDetail(scmInquiryResultWork, out errMsg);
                // DEL 2010/06/17 キャンセル追加対応 ----------<<<<<
                // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
                status = this._scmInquiryOrderAcs.SearchDetail(scmInquiryResultWork, out errMsg);
                // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
            }
            
            //// データソース設定
            //int linkKey = (int)this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryDetailResultDataTable.DetailLinkKeyNumberColumn.ColumnName].Value;

            DataView dv = new DataView(this._scmInquiryOrderAcs.SCMInquiryDetailResultDataTable);

            //// PMSCM04001UAで選択した行Keyでフィルタ
            //dv.RowFilter = this._scmInquiryOrderAcs.SCMInquiryDetailResultDataTable.DetailLinkKeyNumberColumn.ColumnName + " = " + linkKey;

            // 行番号の設定
            for (int i = 0; i < dv.Count; i++)
            {
                dv[i][this._scmInquiryOrderAcs.SCMInquiryDetailResultDataTable.RowNumberColumn.ColumnName] = i + 1;
            }

            dv.RowStateFilter = DataViewRowState.CurrentRows;

            this.uGrid_Details.DataSource = dv;

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

                SCMAcOdrDataDataSet.SCMInquiryDetailResultDataTable table = (SCMAcOdrDataDataSet.SCMInquiryDetailResultDataTable)this._scmInquiryOrderAcs.SCMInquiryDetailResultDataTable;

                // 固定列設定(行番号列のみ)
                columns[table.RowNumberColumn.ColumnName].Header.Fixed = true;

                // 行番号列のセル表示色変更
                columns[table.RowNumberColumn.ColumnName].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
                columns[table.RowNumberColumn.ColumnName].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
                columns[table.RowNumberColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
                columns[table.RowNumberColumn.ColumnName].CellAppearance.ForeColor = Color.White;
                columns[table.RowNumberColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.White;

                int visiblePosition = 0;

                // No.列
                columns[table.RowNumberColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.RowNumberColumn.ColumnName].Header.Caption = "No."; // 列キャプション
                columns[table.RowNumberColumn.ColumnName].Width = 50; // 表示幅
                columns[table.RowNumberColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.RowNumberColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 2011/01/24 Add >>>
                columns[table.InqAnsDivNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.InqAnsDivNameColumn.ColumnName].Header.Caption = "回答区分"; // 列キャプション
                columns[table.InqAnsDivNameColumn.ColumnName].Width = 80; // 表示幅
                columns[table.InqAnsDivNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.InqAnsDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                // 2011/01/24 Add <<<

                // BLコード列
                columns[table.BLGoodsCodeColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.BLGoodsCodeColumn.ColumnName].Header.Caption = "BLコード"; // 列キャプション
                columns[table.BLGoodsCodeColumn.ColumnName].Width = 100; // 表示幅
                columns[table.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.BLGoodsCodeColumn.ColumnName].Format = "00000";
                columns[table.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 品名列
                columns[table.GoodsNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.GoodsNameColumn.ColumnName].Header.Caption = "品名"; // 列キャプション
                columns[table.GoodsNameColumn.ColumnName].Width = 200; // 表示幅
                columns[table.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 品番列
                columns[table.GoodsNoColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.GoodsNoColumn.ColumnName].Header.Caption = "品番"; // 列キャプション
                columns[table.GoodsNoColumn.ColumnName].Width = 200; // 表示幅
                columns[table.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // メーカー列
                columns[table.MakerNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.MakerNameColumn.ColumnName].Header.Caption = "メーカー"; // 列キャプション
                columns[table.MakerNameColumn.ColumnName].Width = 100; // 表示幅
                columns[table.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.MakerNameColumn.ColumnName].Format = "0000";
                columns[table.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 受注数列
                columns[table.SalesOrderCountColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.SalesOrderCountColumn.ColumnName].Header.Caption = "受注数"; // 列キャプション
                columns[table.SalesOrderCountColumn.ColumnName].Width = 100; // 表示幅
                columns[table.SalesOrderCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.SalesOrderCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.SalesOrderCountColumn.ColumnName].Format = "#,##0.00";

                // 出荷数列
                columns[table.DeliveredGoodsCountColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.DeliveredGoodsCountColumn.ColumnName].Header.Caption = "出荷数"; // 列キャプション
                columns[table.DeliveredGoodsCountColumn.ColumnName].Width = 100; // 表示幅
                columns[table.DeliveredGoodsCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.DeliveredGoodsCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.DeliveredGoodsCountColumn.ColumnName].Format = "#,##0.00";

                // 標準価格列
                columns[table.ListPriceColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.ListPriceColumn.ColumnName].Header.Caption = "標準価格"; // 列キャプション
                columns[table.ListPriceColumn.ColumnName].Width = 100; // 表示幅
                columns[table.ListPriceColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.ListPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.ListPriceColumn.ColumnName].Format = "#,##0";

                // 売単価列
                columns[table.UnitPriceColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.UnitPriceColumn.ColumnName].Header.Caption = "売単価"; // 列キャプション
                columns[table.UnitPriceColumn.ColumnName].Width = 100; // 表示幅
                columns[table.UnitPriceColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.UnitPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.UnitPriceColumn.ColumnName].Format = "#,##0";

                // 金額列
                columns[table.SalesMoneyColumn.ColumnName].Hidden = true; // 表示設定
                columns[table.SalesMoneyColumn.ColumnName].Header.Caption = "金額"; // 列キャプション
                columns[table.SalesMoneyColumn.ColumnName].Width = 100; // 表示幅
                columns[table.SalesMoneyColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.SalesMoneyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.SalesMoneyColumn.ColumnName].Format = "#,##0";

                // 消費税列
                columns[table.SalesPriceConsTaxColumn.ColumnName].Hidden = true; // 表示設定
                columns[table.SalesPriceConsTaxColumn.ColumnName].Header.Caption = "消費税"; // 列キャプション
                columns[table.SalesPriceConsTaxColumn.ColumnName].Width = 100; // 表示幅
                columns[table.SalesPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.SalesPriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.SalesPriceConsTaxColumn.ColumnName].Format = "#,##0";

                //--- DEL 2011/05/26 --------------------------------------------------------->>>
                // 棚番列
                //columns[table.ShelfNoColumn.ColumnName].Hidden = false; // 表示設定
                //columns[table.ShelfNoColumn.ColumnName].Header.Caption = "棚番"; // 列キャプション
                //columns[table.ShelfNoColumn.ColumnName].Width = 100; // 表示幅
                //columns[table.ShelfNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                //columns[table.ShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                //--- DEL 2011/05/26 ---------------------------------------------------------<<<

                //--- ADD 2011/05/26 --------------------------------------------------------->>>
                // 倉庫名列
                columns[table.WarehouseNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.WarehouseNameColumn.ColumnName].Header.Caption = "倉庫"; // 列キャプション
                columns[table.WarehouseNameColumn.ColumnName].Width = 100; // 表示幅
                columns[table.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.WarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 棚番列
                columns[table.WarehouseShelfNoColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.WarehouseShelfNoColumn.ColumnName].Header.Caption = "棚番"; // 列キャプション
                columns[table.WarehouseShelfNoColumn.ColumnName].Width = 100; // 表示幅
                columns[table.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.WarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                //--- ADD 2011/05/26 ---------------------------------------------------------<<<

                // リサイクル種別
                columns[table.RecyclePrtKindNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.RecyclePrtKindNameColumn.ColumnName].Width = 120; // 表示幅
                columns[table.RecyclePrtKindNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.RecyclePrtKindNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 明細備考
                columns[table.CommentDtlColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.CommentDtlColumn.ColumnName].Width = 150; // 表示幅
                columns[table.CommentDtlColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.CommentDtlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.CommentDtlColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;

                // ADD 2010/04/16 キャンセル対応 ---------->>>>>
                // 伝票区分
                columns[table.SlipNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.SlipNameColumn.ColumnName].Width = 100; // 表示幅
                columns[table.SlipNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.SlipNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.SlipNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;

                // 伝票番号
                columns[table.SalesSlipNumColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.SalesSlipNumColumn.ColumnName].Width = 100; // 表示幅
                columns[table.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.SalesSlipNumColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                // ADD 2010/04/16 キャンセル対応 ----------<<<<<

                // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
                // 状態列
                columns[table.StateColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.StateColumn.ColumnName].Header.Caption = "キャンセル状態"; // 列キャプション
                columns[table.StateColumn.ColumnName].Width = 120; // 表示幅
                columns[table.StateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.StateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.StateColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Red;
                // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<

                // ------------ ADD START 2013/02/27 qijh #34752 ---------- >>>>>>
                // PM主管倉庫コード
                columns[table.PmMainMngWarehouseCdColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.PmMainMngWarehouseCdColumn.ColumnName].Width = 120; // 表示幅
                columns[table.PmMainMngWarehouseCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.PmMainMngWarehouseCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // PM主管倉庫名称
                columns[table.PmMainMngWarehouseNameColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.PmMainMngWarehouseNameColumn.ColumnName].Width = 120; // 表示幅
                columns[table.PmMainMngWarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.PmMainMngWarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // PM主管棚番
                columns[table.PmMainMngShelfNoColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.PmMainMngShelfNoColumn.ColumnName].Width = 100; // 表示幅
                columns[table.PmMainMngShelfNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.PmMainMngShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // PM主管現在個数
                columns[table.PmMainMngPrsntCountColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.PmMainMngPrsntCountColumn.ColumnName].Width = 120; // 表示幅
                columns[table.PmMainMngPrsntCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// 表示位置
                columns[table.PmMainMngPrsntCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.PmMainMngPrsntCountColumn.ColumnName].Format = "#,##0.00;-#,##0.00;";
                // ------------ ADD END 2013/02/27 qijh #34752 ---------- <<<<<<

                // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   -------------->>>>>>>>>>>>>>>>>>>>
                // 商品規格・特記事項(工場向け)
                columns[table.GoodsSpecialNtForFacColumn.ColumnName].Hidden = true; // 表示設定
                columns[table.GoodsSpecialNtForFacColumn.ColumnName].Width = 120; // 表示幅
                columns[table.GoodsSpecialNtForFacColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.GoodsSpecialNtForFacColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 商品規格・特記事項(カーオーナー向け)
                columns[table.GoodsSpecialNtForCOwColumn.ColumnName].Hidden = true; // 表示設定
                columns[table.GoodsSpecialNtForCOwColumn.ColumnName].Width = 120; // 表示幅
                columns[table.GoodsSpecialNtForCOwColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.GoodsSpecialNtForCOwColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                // 優良設定詳細名称２(工場向け)
                columns[table.PrmSetDtlName2ForFacColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.PrmSetDtlName2ForFacColumn.ColumnName].Width = 120; // 表示幅
                columns[table.PrmSetDtlName2ForFacColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.PrmSetDtlName2ForFacColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                // 優良設定詳細名称２(カーオーナー向け)
                columns[table.PrmSetDtlName2ForCOwColumn.ColumnName].Hidden = false; // 表示設定
                columns[table.PrmSetDtlName2ForCOwColumn.ColumnName].Width = 120; // 表示幅
                columns[table.PrmSetDtlName2ForCOwColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// 表示位置
                columns[table.PrmSetDtlName2ForCOwColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                // ADD 2015/02/20 吉岡 SCM高速化 C向け種別特記対応   --------------<<<<<<<<<<<<<<<<<<<<
            }
            finally
            {
                this.uGrid_Details.EndUpdate();

                // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
                // 「キャンセル区分」が「10:キャンセル要求」の明細はフォント色を赤にする
                if (status.Equals(0))
                {
                    SCMAcOdrDataDataSet columnName = new SCMAcOdrDataDataSet();
                    string stateCellName = columnName.SCMInquiryDetailResult.StateColumn.ColumnName;
                    for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
                    {
                        // 2011/02/14 >>>
                        //string state = this.uGrid_Details.Rows[i].Cells[stateCellName].Value.ToString();
                        int cancelCndtinDiv = (int)this.uGrid_Details.Rows[i].Cells[columnName.SCMInquiryDetailResult.CancelCndtinDivColumn.ColumnName].Value;
                        // 2011/02/14 <<<

                        Color fontColor = Color.Black;
                        // 2011/02/14 >>>
                        //if (
                        //    state.Equals(SCMInquiryDBAgent.GetCancelCndtinDivName((int)CancelCndtinDiv.Cancelling))
                        //        ||
                        //    state.Equals(SCMInquiryDBAgent.GetCancelCndtinDivName((int)CancelCndtinDiv.Cancelled))
                        //)
                        // 回答区分「キャンセル」以外で明細が「キャンセル確定」は、取消データ
                        if (_answerDivCd != (int)AnswerDivCd.Cancel && cancelCndtinDiv.Equals((int)CancelCndtinDiv.Cancelled))
                        {
                            fontColor = Color.Gray;
                        }
                        else if (cancelCndtinDiv.Equals((int)CancelCndtinDiv.Cancelling) ||
                                 cancelCndtinDiv.Equals((int)CancelCndtinDiv.Cancelled)
                        )
                        // 2011/02/14 <<<
                        {
                            // 「10:キャンセル要求」「30:キャンセル受付」は赤
                            fontColor = Color.Red;
                        }
                        int iCell = 0;
                        foreach (UltraGridCell cell in this.uGrid_Details.Rows[i].Cells)
                        {
                            if (iCell > 0)  // 先頭のセル(No.セル)は色を変えない
                            {
                                cell.Appearance.ForeColorDisabled = fontColor;
                            }
                            iCell++;
                        }
                    }
                }
                // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
            }
        }

        // 2010/05/27 Add >>>

        /// <summary>
        /// 検索条件取得
        /// </summary>
        /// <returns></returns>
        private SCMInquiryOrder GetSearchCndtn()
        {
            SCMInquiryOrder cndtn = new SCMInquiryOrder();

            cndtn.EnterpriseCode = (string)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.EnterpriseCodeColumn.ColumnName].Value;

            cndtn.AcptAnOdrStatus = new int[1] { (int)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AcptAnOdrStatusColumn.ColumnName].Value };

            cndtn.AnswerDivCd = new int[1] { (int)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnswerDivCdColumn.ColumnName].Value };

            cndtn.InqOrdDivCd = new int[1] { (int)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOrdDivCdColumn.ColumnName].Value };

            cndtn.InqOriginalEpCd = ((string)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOriginalEpCdColumn.ColumnName].Value).Trim();//@@@@20230303
            cndtn.InqOriginalSecCd = (string)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOriginalSecCdColumn.ColumnName].Value;
            cndtn.InqOtherEpCd = (string)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOtherEpCdColumn.ColumnName].Value;
            cndtn.InqOtherSecCd = (string)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOtherSecCdColumn.ColumnName].Value;
            cndtn.St_InquiryNumber = (long)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InquiryNumberColumn.ColumnName].Value;

            cndtn.SalesSlipNum = (string)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesSlipNumColumn.ColumnName].Value;
            cndtn.UpdateDate = (DateTime)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.UpdateDateColumn.ColumnName].Value;
            cndtn.UpdateTime = (int)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.UpdateTimeColumn.ColumnName].Value;
            return cndtn;
        }
       
        // 2010/05/27 Add <<<
        #endregion

        #region ■イベント
        /// <summary>
        /// PMSCM04001UB_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMSCM04001UB_Load(object sender, EventArgs e)
        {
            // 画面初期設定
            this.SetInitialSetting();

            this.uGrid_Details.ActiveRow = null;
        }

        /// <summary>
        /// uButton_SalesSlip_Clickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SalesSlip_Click(object sender, EventArgs e)
        {
            string programPath = Path.Combine(Directory.GetCurrentDirectory(), SALESSLIPINPUT_EXE_NAME);
            if (!File.Exists(programPath)) return;

            // ログインパラメータ情報を設定
            // ポップアップからの起動の場合、引数が追加されているので使用しない。
            StringBuilder loginArguments = new StringBuilder();
            {
                for (int i = 0; i < this._commandLineArgs.Length && i < 2; i++)
                {
                    string argument = this._commandLineArgs[i];

                    if (!string.IsNullOrEmpty(argument.Trim()))
                    {
                        loginArguments.Append(argument + " ");
                    }
                }
            }

            // -- ADD 2010/03/02 ------------------>>>
            //// -- UPD 2010/02/09 ------------------>>>
            ////// 問合せ番号を追加
            ////loginArguments.Append(this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InquiryNumberColumn.ColumnName].Value.ToString() + " ");
            ////// 受注ステータスを追加
            ////loginArguments.Append(this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AcptAnOdrStatusColumn.ColumnName].Value.ToString() + " ");
            ////// 伝票番号を追加
            ////loginArguments.Append(this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesSlipNumColumn.ColumnName].Value.ToString() + " ");

            //// 問合せ番号を追加
            //loginArguments.Append(this._inquiryNumber + " ");
            //// 受注ステータスを追加
            //loginArguments.Append(this._acptAnOdrStatus + " ");
            //// 伝票番号を追加
            //loginArguments.Append(this._salesSlipNum + " ");
            //// -- UPD 2010/02/09 ------------------<<<

            //売伝起動モード
            loginArguments.Append("/INQ ");
            // 問合せ番号を追加
            loginArguments.Append(this._inquiryNumber + ",");
            // 受注ステータスを追加
            loginArguments.Append(this._acptAnOdrStatus + ",");
            // 伝票番号を追加
            loginArguments.Append(this._salesSlipNum + ",");
            // 問合せ元企業コードを追加
            loginArguments.Append(this._inqOriginalEpCd.Trim() + ",");//@@@@20230303_
            // 問合せ元拠点コードを追加
            loginArguments.Append(this._inqOriginalSecCd + "");
            // -- ADD 2010/03/02 ------------------<<<

            // 売上伝票入力画面を起動
            Process.Start(programPath, loginArguments.ToString());
        }

        /// <summary>
        /// uButton_Close_Clickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// tRetKeyControl1_ChangeFocusイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {

        }

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
        #endregion

        #region 起動タイプ区分列挙
        /// <summary>起動タイプ列挙</summary>
        private enum Mode
        {
            ///<summary>メニュー</summary>
            Menu = 0,
            ///<summary>ポップアップ</summary>
            Popup = 1,
            /// <summary>売上伝票入力</summary>
            SalesSlip = 2
        }
        #endregion

        // --------------- ADD 2013/04/03 wangl2 #35273------>>>> 
        #region XML操作
        /// <summary>
        /// ＸＭＬデータの読込処理
        /// </summary>
        private void LoadStateXmlData()
        {

            int status = this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }

        /// <summary>
        /// ＸＭＬデータの保存処理
        /// </summary>
        private void SaveStateXmlData()
        {
            // グリッド情報を保存
            this._gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }
        #endregion
        // --------------- ADD 2013/04/03 wangl2 #35273------<<<<<

        private void button1_Click(object sender, EventArgs e)
        {
            PMSCM04001UC noteForm = new PMSCM04001UC();
            noteForm.ShowDialog();
        }

        private void uGrid_Details_Click(object sender, EventArgs e)
        {
            // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
            try
            {
            // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
                Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

                // マウスポインタがグリッドのどの位置にあるかを判定する
                Point point = System.Windows.Forms.Cursor.Position;
                point = targetGrid.PointToClient(point);

                // UIElementを取得する。
                Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
                if (objUIElement == null)
                    return;

                // マウスポインターが列のヘッダ上にあるかチェック。
                Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
                  (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

                if (objHeader != null) return;

                // マウスポインターが行の上にあるかチェック。
                Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
                  (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

                if (objRow == null) return;

                Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
                  (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

                if (objCell.Column.Index != 16) return;

                string commentDtl = (string)objRow.Cells[this._scmInquiryOrderAcs.SCMInquiryDetailResultDataTable.CommentDtlColumn.ColumnName].Value;

                PMSCM04001UC noteForm = new PMSCM04001UC();
                noteForm.CommentDtl = commentDtl;
                noteForm.ShowDialog();

                ////-----------------------------------------------------------
                //// カラー情報設定処理
                ////-----------------------------------------------------------
                //this.SettingColorInfoProc(colorCode);
            // ADD 2010/06/17 キャンセル追加対応 ---------->>>>>
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine(ex);
            }
            // ADD 2010/06/17 キャンセル追加対応 ----------<<<<<
        }

        private void PMSCM04001UB_Shown(object sender, EventArgs e)
        {
            //
        }

        // --------------- ADD 2013/04/03 wangl2 #35273------>>>> 
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
            // 列移動可
            e.Layout.Override.AllowColMoving = AllowColMoving.WithinBand;
        }

        /// <summary>
        ///  PMSCM04001UB_FormClosingイベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: フォームを終了する際にします。</br>
        /// <br>Programmer	: wangl2</br>
        /// <br>Date		: 2013/04/03</br>
        /// </remarks>
        private void PMSCM04001UB_FormClosing(object sender, FormClosingEventArgs e)
        {
            // XMLデータの保存処理
            this.SaveStateXmlData();
        }
        // --------------- ADD 2013/04/03 wangl2 #35273------<<<<<
    }
}