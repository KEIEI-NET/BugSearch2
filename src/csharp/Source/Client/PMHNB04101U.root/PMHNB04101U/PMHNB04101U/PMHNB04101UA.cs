using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 出荷部品表示UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 出荷部品表示UIフォームクラス</br>
    /// <br>Programmer  : 30414 忍 幸史</br>
    /// <br>Date        : 2008/11/10</br>
    /// </remarks>
    public partial class PMHNB04101UA : Form
    {
        #region Constants

        // アセンブリID
        private const string ASSMBLY_ID = "PMHNB04101U";

        // グリッド列
        private const string COLUMN_TITEL = "Title";
        private const string COLUMN_STOCK = "Stock";
        private const string COLUMN_ORDER = "Order";
        private const string COLUMN_TOTAL = "Total";

        #endregion Constants


        #region Private Members

        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode;

        private DateTime _thisYearMonth;

        private ShipmentPartsDspAcs _shipmentPartsDspAcs;
        private SecInfoAcs _secInfoAcs;
        private SecInfoSetAcs _secInfoSetAcs;

        private DateGetAcs _dateGetAcs;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;

        #endregion


        #region Constructor

        /// <summary>
        /// 出荷部品表示UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 出荷部品表示UIフォームクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        public PMHNB04101UA()
		{
			InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            this._shipmentPartsDspAcs = new ShipmentPartsDspAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._dateGetAcs = DateGetAcs.GetInstance();

            // 拠点マスタ読込
            ReadSecInfoSet();

            // 現在処理年月取得
            GetThisYearMonth();

            // 画面クリア
            ClearScreen();

            // 画面初期設定
            SetInitialSetting();
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// 拠点マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 拠点マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                    }
                }
            }
            catch
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            }
        }

        /// <summary>
        /// 拠点名取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note        : 拠点名を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (sectionCode == "")
            {
                sectionName = "全て";
            }
            else if (sectionCode == "00")
            {
                sectionName = "全て";
            }

            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                sectionName = this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// 現在処理年月取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 現在処理年月を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void GetThisYearMonth()
        {
            try
            {
                this._dateGetAcs.GetThisYearMonth(out this._thisYearMonth);
            }
            catch
            {
                this._thisYearMonth = new DateTime();
            }
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報の初期設定を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void SetInitialSetting()
        {
            //---------------------------------
            // 画面スキンファイルの読込(デフォルトスキン指定)
            //---------------------------------
            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.Standard_UGroupBox.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // コントロールサイズ設定
            this.tEdit_SectionCodeAllowZero.Size = new Size(28, 24);
            this.tEdit_SectionName.Size = new Size(175, 24);

            //---------------------------------
            // アイコン設定
            //---------------------------------
            this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            ButtonTool workButton;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            //---------------------------------
            // グリッド設定
            //---------------------------------
            CreateGrid(new List<ShipmentPartsDspResult>());
            SetGridLayout();
        }

        /// <summary>
        /// 画面情報クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void ClearScreen()
        {
            // 拠点コード
            this.tEdit_SectionCodeAllowZero.Clear();
            this.tEdit_SectionName.DataText = "全て";

            // 対象年月
            this.tDateEdit_CAddUpUpdExecDateSt.SetDateTime(this._thisYearMonth);
            this.tDateEdit_CAddUpUpdExecDateEd.SetDateTime(this._thisYearMonth);            
            
            // グリッド
            CreateGrid(new List<ShipmentPartsDspResult>());

            // フォーカス設定
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        /// <summary>
        /// グリッド作成処理
        /// </summary>
        /// <param name="updHisDspWorkList">更新履歴リスト</param>
        /// <remarks>
        /// <br>Note        : グリッドを作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void CreateGrid(List<ShipmentPartsDspResult> shipmentPartsDspResultList)
        {
            //--------------------------------------
            // グリッド列、データ設定
            //--------------------------------------
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add(COLUMN_TITEL, typeof(string));
            dataTable.Columns.Add(COLUMN_STOCK, typeof(string));
            dataTable.Columns.Add(COLUMN_ORDER, typeof(string));
            dataTable.Columns.Add(COLUMN_TOTAL, typeof(string));

            string[] titleArray = new string[3];
            titleArray[0] = "出荷回数";
            titleArray[1] = "売上金額";
            titleArray[2] = "粗利金額";
            
            for (int index = 0; index < 3; index++)
            {
                DataRow dataRow = dataTable.NewRow();

                dataRow[COLUMN_TITEL] = titleArray[index];
                dataRow[COLUMN_STOCK] = "";
                dataRow[COLUMN_ORDER] = "";
                dataRow[COLUMN_TOTAL] = "";

                dataTable.Rows.Add(dataRow);
            }

            this.uGrid_Details.DataSource = dataTable;

            this.uGrid_Details.ActiveRow = null;
        }

        /// <summary>
        /// グリッドレイアウト設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドレイアウトを設定します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void SetGridLayout()
        {
            //--------------------------------------
            // グリッド外観設定
            //--------------------------------------
            ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // キャプション
            columns[COLUMN_TITEL].Header.Caption = "";
            columns[COLUMN_STOCK].Header.Caption = "在庫分";
            columns[COLUMN_ORDER].Header.Caption = "取寄分";
            columns[COLUMN_TOTAL].Header.Caption = "合計";

            // 列幅
            columns[COLUMN_TITEL].Width = 100;
            columns[COLUMN_STOCK].Width = 140;
            columns[COLUMN_ORDER].Width = 140;
            columns[COLUMN_TOTAL].Width = 140;

            // テキスト位置(HAlign)
            columns[COLUMN_TITEL].CellAppearance.TextHAlign = HAlign.Center;
            columns[COLUMN_STOCK].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_ORDER].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_TOTAL].CellAppearance.TextHAlign = HAlign.Right;

            // テキスト位置(VAlign)
            columns[COLUMN_TITEL].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_STOCK].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_ORDER].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_TOTAL].CellAppearance.TextVAlign = VAlign.Middle;

            // セルカラー
            columns[COLUMN_TITEL].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            columns[COLUMN_TITEL].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            columns[COLUMN_TITEL].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[COLUMN_TITEL].CellAppearance.ForeColor = Color.White;
            columns[COLUMN_TITEL].CellAppearance.ForeColorDisabled = Color.White;

            // 固定ヘッダー
            columns[COLUMN_TITEL].Header.Fixed = true;
        }

        /// <summary>
        /// 出荷部品照会抽出結果画面表示処理
        /// </summary>
        /// <param name="shipmentPartsDspResultList">出荷部品照会抽出結果リスト</param>
        /// <remarks>
        /// <br>Note        : 出荷部品照会抽出結果リストを画面表示します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void ShipmentPartsDspResultToScreen(List<ShipmentPartsDspResult> shipmentPartsDspResultList)
        {
            if (shipmentPartsDspResultList == null)
            {
                return;
            }

            double stockSalesTimes = 0;
            double stockSalesMoney = 0;
            double stockGrossProfit = 0;
            double totalSalesTimes = 0;
            double totalSalesMoney = 0;
            double totalGrossProfit = 0;

            foreach (ShipmentPartsDspResult shipmentPartsDspResult in shipmentPartsDspResultList)
            {
                // 部品合計のレコード
                if (shipmentPartsDspResult.RsltTtlDivCd == 0)
                {
                    // 出荷回数
                    totalSalesTimes = shipmentPartsDspResult.SalesTimes;
                    this.uGrid_Details.Rows[0].Cells[COLUMN_TOTAL].Value = totalSalesTimes.ToString("###,##0");
                    // 売上金額
                    totalSalesMoney = shipmentPartsDspResult.SalesMoney;
                    this.uGrid_Details.Rows[1].Cells[COLUMN_TOTAL].Value = totalSalesMoney.ToString("###,##0");
                    // 粗利金額
                    totalGrossProfit = shipmentPartsDspResult.GrossProfit;
                    this.uGrid_Details.Rows[2].Cells[COLUMN_TOTAL].Value = totalGrossProfit.ToString("###,##0");            
                }
                // 在庫分のレコード
                else if (shipmentPartsDspResult.RsltTtlDivCd == 1)
                {
                    // 出荷回数
                    stockSalesTimes = shipmentPartsDspResult.SalesTimes;
                    this.uGrid_Details.Rows[0].Cells[COLUMN_STOCK].Value = stockSalesTimes.ToString("###,##0");
                    // 売上金額
                    stockSalesMoney = shipmentPartsDspResult.SalesMoney;
                    this.uGrid_Details.Rows[1].Cells[COLUMN_STOCK].Value = stockSalesMoney.ToString("###,##0");
                    // 粗利金額
                    stockGrossProfit = shipmentPartsDspResult.GrossProfit;
                    this.uGrid_Details.Rows[2].Cells[COLUMN_STOCK].Value = stockGrossProfit.ToString("###,##0");                   
                }
            }

            // 取寄分のレコード
            // 出荷回数
            this.uGrid_Details.Rows[0].Cells[COLUMN_ORDER].Value = (totalSalesTimes - stockSalesTimes).ToString("###,##0");
            // 売上金額
            this.uGrid_Details.Rows[1].Cells[COLUMN_ORDER].Value = (totalSalesMoney - stockSalesMoney).ToString("###,##0");
            // 粗利金額
            this.uGrid_Details.Rows[2].Cells[COLUMN_ORDER].Value = (totalGrossProfit - stockGrossProfit).ToString("###,##0");     
        }

        /// <summary>
        /// 確定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 確定処理を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void Search()
        {
            // 画面情報チェック
            bool bStatus = CheckScreenInput();
            if (!bStatus)
            {
                return;
            }

            // 検索条件格納
            ShipmentPartsDspParam extrInfo;
            SetExtrInfo(out extrInfo);

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "抽出中";
            msgForm.Message = "出荷部品データの抽出中です。";

            int status;
            List<ShipmentPartsDspResult> shipmentPartsDspResultList;

            try
            {
                msgForm.Show();

               // 検索処理
               status = this._shipmentPartsDspAcs.Search(extrInfo, out shipmentPartsDspResultList);
                if (status == 0)
                {
                    // 画面表示
                    ShipmentPartsDspResultToScreen(shipmentPartsDspResultList);
                    return;
                }
            }
            finally
            {
                msgForm.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "Search",
                                       "検索条件に該当する出荷部品は存在しません。",
                                       status,
                                       MessageBoxButtons.OK);

                        // グリッド情報クリア
                        CreateGrid(new List<ShipmentPartsDspResult>());
                        return;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "Search",
                                       "確定処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        // グリッド情報クリア
                        CreateGrid(new List<ShipmentPartsDspResult>());
                        return;
                    }
            }
        }

        /// <summary>
        /// 画面情報チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 画面情報をチェックします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                // 拠点コード
                if ((this.tEdit_SectionCodeAllowZero.DataText.Trim() != "") &&
                    (this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0') != "00"))
                {
                    string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
                    if (GetSectionName(sectionCode) == "")
                    {
                        errMsg = "マスタに登録されていません。";
                        this.tEdit_SectionCodeAllowZero.Focus();
                        return (false);
                    }
                }

                // 対象年月(開始)
                if (IsErrorTDateEdit(this.tDateEdit_CAddUpUpdExecDateSt, true, out errMsg) == false)
                {
                    this.tDateEdit_CAddUpUpdExecDateSt.Focus();
                    return (false);
                }
                // 対象年月(終了)
                if (IsErrorTDateEdit(this.tDateEdit_CAddUpUpdExecDateEd, true, out errMsg) == false)
                {
                    this.tDateEdit_CAddUpUpdExecDateEd.Focus();
                    return (false);
                }
                
                int year;
                int month;

                year = this.tDateEdit_CAddUpUpdExecDateSt.GetDateYear();
                month = this.tDateEdit_CAddUpUpdExecDateSt.GetDateMonth();
                this.tDateEdit_CAddUpUpdExecDateSt.SetDateTime(new DateTime(year, month, 1));

                year = this.tDateEdit_CAddUpUpdExecDateEd.GetDateYear();
                month = this.tDateEdit_CAddUpUpdExecDateEd.GetDateMonth();
                this.tDateEdit_CAddUpUpdExecDateEd.SetDateTime(new DateTime(year, month, 1));

                // 対象年月範囲チェック
                if (this.tDateEdit_CAddUpUpdExecDateSt.GetDateTime() > this.tDateEdit_CAddUpUpdExecDateEd.GetDateTime())
                {
                    errMsg = "対象年月の範囲指定に誤りがあります。";
                    this.tDateEdit_CAddUpUpdExecDateSt.Focus();
                    return (false);
                }
                if (this.tDateEdit_CAddUpUpdExecDateSt.GetDateTime().AddMonths(12) <= this.tDateEdit_CAddUpUpdExecDateEd.GetDateTime())
                {
                    errMsg = "対象年月は12ヵ月以内で指定してください。";
                    this.tDateEdit_CAddUpUpdExecDateSt.Focus();
                    return (false);
                }
                
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="tDateEdit">チェック対象TDateEdit</param>
        /// <param name="minValueCheck">未入力チェックフラグ(True:未入力不可 False:未入力可)</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : 日付の入力チェックを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/01</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, bool minValueCheck, out string errMsg)
        {
            errMsg = "";

            int year = tDateEdit.GetDateYear();
            int month = tDateEdit.GetDateMonth();
            int day = tDateEdit.GetDateDay();

            if (minValueCheck == true)
            {
                if ((year == 0) || (month == 0))
                {
                    errMsg = "日付を指定してください。";
                    return (false);
                }
            }
            else
            {
                if ((year == 0) && (month == 0))
                {
                    return (true);
                }
            }

            if (year < 1900)
            {
                errMsg = "正しい日付を指定してください。";
                return (false);
            }

            if (month > 12)
            {
                errMsg = "正しい日付を指定してください。";
                return (false);
            }

            return (true);
        }

        /// <summary>
        /// 検索条件格納処理
        /// </summary>
        /// <param name="extrInfo">検索条件(明示的にoutパラメータで渡します)</param>
        /// <remarks>
        /// <br>Note        : 検索条件を格納します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void SetExtrInfo(out ShipmentPartsDspParam extrInfo)
        {
            extrInfo = new ShipmentPartsDspParam();

            // 企業コード
            extrInfo.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 拠点コード
            extrInfo.SectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
            // 対象年月(開始)
            extrInfo.StAddUpYearMonth = this.tDateEdit_CAddUpUpdExecDateSt.GetDateTime();
            // 対象年月(終了)
            extrInfo.EdAddUpYearMonth = this.tDateEdit_CAddUpUpdExecDateEd.GetDateTime();
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSMBLY_ID,                        // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSMBLY_ID, 		  　　		    // アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._shipmentPartsDspAcs,			// エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }

        #endregion Private Methods


        #region Control Events

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォームがLoadされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void PMHNB04101UA_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// ToolClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ツールバーがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        Close();
                        break;
                    }
                case "ButtonTool_Decision":
                    {
                        // 確定処理
                        Search();
                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // クリア処理
                        ClearScreen();
                        break;
                    }
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

                    // フォーカス設定
                    this.tDateEdit_CAddUpUpdExecDateSt.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ExpandedStateChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 展開ステータスが変更された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void Standard_UGroupBox_ExpandedStateChanged(object sender, EventArgs e)
        {
            Size topSize = new Size();

            topSize.Width = this.Form1_Top_Panel.Size.Width;
            topSize.Height = 20;

            if (this.Standard_UGroupBox.Expanded == true)
            {
                topSize.Height = 100;
            }
            else
            {
                topSize.Height = 20;
            }

            this.Form1_Top_Panel.Size = topSize;
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            int rowIndex = this.uGrid_Details.ActiveRow.Index;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if (rowIndex == 0)
                        {
                            e.Handled = true;
                            this.tDateEdit_CAddUpUpdExecDateSt.Focus();
                        }
                        else
                        {
                            e.Handled = true;
                            this.uGrid_Details.Rows[rowIndex - 1].Activate();
                            this.uGrid_Details.Rows[rowIndex - 1].Selected = true;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (rowIndex == this.uGrid_Details.Rows.Count - 1)
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = true;
                            this.uGrid_Details.Rows[rowIndex + 1].Activate();
                            this.uGrid_Details.Rows[rowIndex + 1].Selected = true;
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        // グリッド表示を右にスクロール
                        this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position + 40;
                        break;
                    }
                case Keys.Left:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        if (this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position != 0)
                        {
                            // グリッド表示を左にスクロール
                            this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position - 40;
                        }
                        break;
                    }
                case Keys.Home:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;

                        // 他キーとの組合せ無しの場合
                        if (e.Modifiers == Keys.None)
                        {
                            // グリッド表示を左先頭にスクロール
                            this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
                        }

                        // Controlキーとの組合せの場合
                        if (e.Modifiers == Keys.Control)
                        {
                            // 先頭行に移動
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                        }
                        break;
                    }
                case Keys.End:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;

                        // 他キーとの組合せ無しの場合
                        if (e.Modifiers == Keys.None)
                        {
                            // グリッド表示を左先頭にスクロール
                            this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Range;
                        }

                        // Controlキーとの組合せの場合
                        if (e.Modifiers == Keys.Control)
                        {
                            // 最終行に移動
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドが非アクティブになった時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveCell = null;
            this.uGrid_Details.ActiveRow = null;

            for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
            {
                this.uGrid_Details.Rows[index].Selected = false;
            }
        }

        /// <summary>
        /// Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 一定間隔が過ぎる度に時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tEdit_SectionCodeAllowZero.Focus();

            // グリッドのアクティブ行を削除
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : コントロールのフォーカスが変更された時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 拠点コード
            if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero)
            {
                // 拠点コード取得
                string sectionCode;
                if (this.tEdit_SectionCodeAllowZero.DataText.Trim() == "")
                {
                    sectionCode = "";
                }
                else
                {
                    sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
                }

                // 拠点名取得
                this.tEdit_SectionName.DataText = GetSectionName(sectionCode);

                if (this.tEdit_SectionName.DataText.Trim() != "")
                {
                    // フォーカス設定
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                        {
                            e.NextCtrl = this.tDateEdit_CAddUpUpdExecDateSt;
                        }
                    }
                }
            }
            // 対象年月(開始)
            else if (e.PrevCtrl == this.tDateEdit_CAddUpUpdExecDateSt)
            {
                if (e.ShiftKey == true)
                {
                    if (e.Key == Keys.Tab)
                    {
                        if (this.tEdit_SectionName.DataText.Trim() != "")
                        {
                            e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                        }
                    }
                }
            }
            // グリッド
            else if (e.PrevCtrl == this.uGrid_Details)
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        if (this.uGrid_Details.ActiveRow == null)
                        {
                            e.NextCtrl = null;
                            this.uGrid_Details.Rows[0].Activate();
                            this.uGrid_Details.Rows[0].Selected = true;
                        }
                        else
                        {
                            int rowIndex = this.uGrid_Details.ActiveRow.Index;
                            if (rowIndex != this.uGrid_Details.Rows.Count - 1)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Rows[rowIndex + 1].Activate();
                                this.uGrid_Details.Rows[rowIndex + 1].Selected = true;
                            }
                        }
                    }
                    return;
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        if (this.uGrid_Details.ActiveRow == null)
                        {
                            e.NextCtrl = null;
                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Activate();
                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Selected = true;
                        }
                        else
                        {
                            int rowIndex = this.uGrid_Details.ActiveRow.Index;
                            if (rowIndex != 0)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Rows[rowIndex - 1].Activate();
                                this.uGrid_Details.Rows[rowIndex - 1].Selected = true;
                            }
                        }
                    }
                    return;
                }
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            // グリッド
            if (e.NextCtrl == this.uGrid_Details)
            {
                if (e.ShiftKey == false)
                {
                    this.uGrid_Details.Rows[0].Activate();
                    this.uGrid_Details.Rows[0].Selected = true;
                    return;
                }
                else
                {
                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Activate();
                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Selected = true;
                }
            }
        }

        #endregion Control Events
    }
}