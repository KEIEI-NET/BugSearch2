//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入売上実績表
// プログラム概要   : 仕入売上実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/05/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Collections.Specialized;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{

    /// <summary>
    /// 仕入売上実績表デザインクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入売上実績表デザインクラスの概要の説明を行います。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.05.13</br>
    /// </remarks>
    public partial class PMKOU02063P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeCommon, IPrintActiveReportTypeList
    {

        //================================================================================
        //  Constructor
        //================================================================================
        #region コンストラクター
        /// <summary>
        /// 仕入売上実績表印刷帳票ActiveReportクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入売上実績表印刷帳票ActiveReportクラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public PMKOU02063P_01A4C()
        {
            //
            // ActiveReport デザイナ サポートに必要です。
            //
            InitializeComponent();
        }
        #endregion

        //================================================================================
        //  内部変数
        //================================================================================
        #region private member
        // 拠点表示有無
        private bool _isSection;

        // 抽出条件ヘッダ出力区分
        private int _extraCondHeadOutDiv;

        // ソート順タイトル
        private string _pageHeaderSortOderTitle;

        // 抽出条件印字項目
        private StringCollection _extraConditions;

        // フッター出力有無
        private int _pageFooterOutCode;

        // フッタメッセージ1
        private StringCollection _pageFooters;

        // 印刷情報
        private SFCMN06002C _printInfo;

        // 関連データオブジェクト
        private ArrayList _otherDataList;

        // 背景透かしモード(無し)
        private int _watermarkMode = 0;

        // 印刷件数
        private int _printCount = 1;

        // 抽出条件クラス
        private StockSalesResultInfoMainCndtn _extrInfo;

        #endregion

        //================================================================================
        //  プロパティ
        //================================================================================
        #region public property

        #region IPrintActiveReportTypeList メンバ
        /// <summary> ページヘッダソート順タイトル項目</summary>
        /// <value>PageHeaderSortOderTitle</value>               
        /// <remarks>ページヘッダソート順タイトル項目セットプロパティ </remarks> 
        public string PageHeaderSortOderTitle
        {
            set
            {
                this._pageHeaderSortOderTitle = value;
            }
        }

        /// <summary> 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]</summary>
        /// <value>ExtraCondHeadOutDiv</value>               
        /// <remarks>抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]セットプロパティ </remarks> 
        public int ExtraCondHeadOutDiv
        {
            set { this._extraCondHeadOutDiv = value; }
        }

        /// <summary> 抽出条件ヘッダー項目</summary>
        /// <value>ExtraConditions</value>               
        /// <remarks>抽出条件ヘッダー項目セットプロパティ </remarks> 
        public StringCollection ExtraConditions
        {
            set
            {
                this._extraConditions = value;
            }
        }

        /// <summary> フッター出力区分</summary>
        /// <value>PageFooterOutCode</value>               
        /// <remarks>フッター出力区分セットプロパティ </remarks> 
        public int PageFooterOutCode
        {
            set
            {
                this._pageFooterOutCode = value;
            }
        }

        /// <summary> フッタ出力文</summary>
        /// <value>PageFooters</value>               
        /// <remarks>フッタ出力文セットプロパティ </remarks> 
        public StringCollection PageFooters
        {
            set
            {
                this._pageFooters = value;
            }
        }

        /// <summary>印刷条件</summary>
        /// <value>PrintInfo</value>               
        /// <remarks>印刷条件セットプロパティ </remarks> 
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
                this._extrInfo = (StockSalesResultInfoMainCndtn)this._printInfo.jyoken;
            }
        }

        /// <summary>その他データ</summary>
        /// <value>OtherDataList</value>               
        /// <remarks>その他データセットプロパティ </remarks> 
        public ArrayList OtherDataList
        {
            set
            {
                this._otherDataList = value;
                if (this._otherDataList != null)
                {
                    if (this._otherDataList.Count > 0)
                    {
                        this._isSection = (bool)this._otherDataList[0];
                    }
                }
            }
        }

        /// <summary>サブヘッダタイトル</summary>
        /// <value>PageHeaderSubtitle</value>               
        /// <remarks>サブヘッダタイトルセットプロパティ </remarks> 
        public string PageHeaderSubtitle
        {
            set { }
        }
        #endregion

        #region IPrintActiveReportTypeCommon メンバ
        /// <summary>プログレスバーカウントアップイベント</summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;

        /// <summary>背景透かしモード</summary>
        /// <value>0：背景透かし無し, 1:背景透かし有り</value>
        /// <remarks>背景透かしモードセット又は取得プロパティ </remarks> 
        public int WatermarkMode
        {
            set { }
            get { return this._watermarkMode; }
        }
        #endregion
        #endregion

        //================================================================================
        //  イベント
        //================================================================================
        #region event
        /// <summary>
        /// レポートスタートイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: レポートの生成処理が開始されたときに発生します。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.13</br>
        /// </remarks>
        private void PMKOU02063P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            SetOfReportMembersOutput();
        }

        /// <summary>
        /// レポート要素出力設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.13</br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            // 印刷件数初期化
            this._printCount = 0;

            //改頁
            if (this._extrInfo.NewPageType == 0)
            {
                this.SectionHeader.DataField = "SectionCode";
                this.SectionHeader.NewPage = NewPage.Before;
                this.SectionHeader.RepeatStyle = RepeatStyle.OnPage;

                this.groupHeader3.DataField = "";
                this.groupHeader3.NewPage = NewPage.None;
                this.groupHeader3.RepeatStyle = RepeatStyle.None;
            }
            else if (this._extrInfo.NewPageType == 1)
            {
                this.SectionHeader.DataField = "SectionCode";
                this.SectionHeader.NewPage = NewPage.None;
                this.SectionHeader.RepeatStyle = RepeatStyle.OnPage;

                this.groupHeader3.DataField = "";
                this.groupHeader3.NewPage = NewPage.None;
                this.groupHeader3.RepeatStyle = RepeatStyle.None;
            }

        }

        /// <summary>
        /// ページヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.13</br>
        /// </remarks>
        private void pageHeader_Format(object sender, System.EventArgs eArgs)
        {

            //// ソート順
            this.SORTTITLE.Text = this._pageHeaderSortOderTitle;

            // 作成日付
            DateTime now = DateTime.Now;
            this.DATE.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);

            // 作成時間
            this.TIME.Text = TDateTime.DateTimeToString("HH:MM", now);
        }

        /// <summary>
        /// 拠点ヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.13</br>
        /// </remarks>
        private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
        {

            // ヘッダ出力制御
            if (this._extraCondHeadOutDiv == 0)
            {
                // 毎ページ出力
                this.ExtraHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;

            }
            else
            {
                // 先頭ページのみ
                this.ExtraHeader.RepeatStyle = RepeatStyle.None;
            }
            // ヘッダーサブレポート作成
            ListCommon_ExtraHeader rpt = new ListCommon_ExtraHeader();

            // 抽出条件印字項目設定
            rpt.ExtraConditions = this._extraConditions;

            this.Extra_SubReport.Report = rpt;

        }


        /// <summary>
        /// 明細アフタープリントイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションがページに描画された後に発生します。</br>
        /// <br>Programmer  : 汪千来</br>
        /// <br>Date        : 2009.05.13</br>
        /// </remarks>
        private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
        {
            // 印刷件数カウントアップ
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }
        }

        #region Detail_Formatイベント
        /// <summary>
        /// 罫線表示非表示制御処理　Detail_Formatイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : lineをvisibleかどうか。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2008.12.10</br>
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            //if (lineFlag.Text.Equals("true") || lineFlag.Text.Equals("True"))
            //{
            //    this.line5.Visible = true;
            //}
            //else
            //{
            //    this.line5.Visible = false;
            //}
        }
        #endregion

        private void DailyFooter_Format(object sender, EventArgs e)
        {
            long saleData = Convert.ToInt64(this.textBox13.Text);
            if (saleData == 0)
            {
                this.textBox13.Visible = false;
                this.textBox16.Visible = false;
                this.textBox8.Visible = false;
            }
            else
            {
                this.textBox13.Visible = true;
                this.textBox16.Visible = true;
                this.textBox8.Visible = true;
            }
            long stockData = Convert.ToInt64(this.textBox14.Text);
            long grpMoney = saleData - stockData;
            decimal tmpPct = new decimal(0.00);
            if (saleData != 0)
            {
                tmpPct = decimal.Round(((Convert.ToDecimal(grpMoney) / Convert.ToDecimal(saleData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox13.Text = NumberFormat(saleData);
            this.textBox14.Text = NumberFormat(stockData);
            this.textBox16.Text = NumberFormat(grpMoney);
            this.textBox8.Text = Convert.ToString(tmpPct);
        }


        /// <summary>
        /// 数字のフォーマット
        /// </summary>
        /// <param name="number">数字</param>
        /// <remarks>
        /// <br>Note		: 数字のフォーマット(999,999,999)を変換する</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private string NumberFormat(long number)
        {
            string ret;
            if (Math.Abs(number) > 999)
            {
                ret = string.Format("{0:0,0}", number);
            }
            else
            {
                ret = number.ToString();
            }
            return ret;
        }

        #endregion

        /// <summary>
        /// 拠点計処理　SectionFooter_Formatイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 拠点計処理を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.06.04</br>
        /// </remarks>
        private void SectionFooter_Format(object sender, EventArgs e)
        {
            //仕入
            long saleSalesData = Convert.ToInt64(this.textBox15.Text);
            ////if (saleSalesData == 0)
            if (1 == _extrInfo.SalesType)
            {
                this.textBox15.Visible = false;
                this.textBox17.Visible = false;
                this.textBox18.Visible = false;
            }
            else
            {
                this.textBox15.Visible = true;
                this.textBox17.Visible = true;
                this.textBox18.Visible = true;
            }
            long stockSalesData = Convert.ToInt64(this.textBox28.Text);
            long grpSalesMoney = saleSalesData - stockSalesData;
            decimal tmpSalesPct = new decimal(0.00);
            if (saleSalesData != 0)
            {
                tmpSalesPct = decimal.Round(((Convert.ToDecimal(grpSalesMoney) / Convert.ToDecimal(saleSalesData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox15.Text = NumberFormat(saleSalesData);
            this.textBox28.Text = NumberFormat(stockSalesData);
            this.textBox17.Text = NumberFormat(grpSalesMoney);
            if (saleSalesData == 0)
            {
                this.textBox18.Text = Convert.ToString("0.00");
            }
            else
            {
                this.textBox18.Text = Convert.ToString(tmpSalesPct);
            }

            //返品
            long saleRetGdsData = Convert.ToInt64(this.textBox19.Text);
            //if (saleRetGdsData == 0)
            if (1 == _extrInfo.SalesType)
            {
                this.textBox19.Visible = false;
                this.textBox22.Visible = false;
                this.textBox25.Visible = false;
            }
            else
            {
                this.textBox19.Visible = true;
                this.textBox22.Visible = true;
                this.textBox25.Visible = true;
            }
            long stockRetGdsData = Convert.ToInt64(this.textBox29.Text);
            long grpRetGdsMoney = saleRetGdsData - stockRetGdsData;
            decimal tmpRetGdsPct = new decimal(0.00);
            if (saleRetGdsData != 0)
            {
                tmpRetGdsPct = decimal.Round(((Convert.ToDecimal(grpRetGdsMoney) / Convert.ToDecimal(saleRetGdsData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox19.Text = NumberFormat(saleRetGdsData);
            this.textBox29.Text = NumberFormat(stockRetGdsData);
            this.textBox22.Text = NumberFormat(grpRetGdsMoney);
            if (saleRetGdsData == 0)
            {
                this.textBox25.Text = Convert.ToString("0.00");
            }
            else
            {
                this.textBox25.Text = Convert.ToString(tmpRetGdsPct);
            }

            //値引
            long saleDistData = Convert.ToInt64(this.textBox20.Text);
            //if (saleDistData == 0)
            if (1 == _extrInfo.SalesType)
            {
                this.textBox20.Visible = false;
                this.textBox23.Visible = false;
                this.textBox26.Visible = false;
            }
            else
            {
                this.textBox20.Visible = true;
                this.textBox23.Visible = true;
                this.textBox26.Visible = true;
            }
            long stockDistData = Convert.ToInt64(this.textBox30.Text);
            long grpDistMoney = saleDistData - stockDistData;
            decimal tmpDistPct = new decimal(0.00);
            if (saleDistData != 0)
            {
                tmpDistPct = decimal.Round(((Convert.ToDecimal(grpDistMoney) / Convert.ToDecimal(saleDistData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox20.Text = NumberFormat(saleDistData);
            this.textBox30.Text = NumberFormat(stockDistData);
            this.textBox23.Text = NumberFormat(grpDistMoney);
            if (saleDistData == 0)
            {
                this.textBox26.Text = Convert.ToString("0.00");
            }
            else
            {
                this.textBox26.Text = Convert.ToString(tmpDistPct);
            }

            //合計
            long saleTotalData = Convert.ToInt64(this.textBox21.Text);
            //if (saleTotalData == 0)
            if (1 == _extrInfo.SalesType)
            {
                this.textBox21.Visible = false;
                this.textBox24.Visible = false;
                this.textBox27.Visible = false;
            }
            else
            {
                this.textBox21.Visible = true;
                this.textBox24.Visible = true;
                this.textBox27.Visible = true;
            }
            long stockTotalData = Convert.ToInt64(this.textBox31.Text);
            long grpTotalMoney = saleTotalData - stockTotalData;
            decimal tmpTotalPct = new decimal(0.00);
            if (saleTotalData != 0)
            {
                tmpTotalPct = decimal.Round(((Convert.ToDecimal(grpTotalMoney) / Convert.ToDecimal(saleTotalData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox21.Text = NumberFormat(saleTotalData);
            this.textBox31.Text = NumberFormat(stockTotalData);
            this.textBox24.Text = NumberFormat(grpTotalMoney);
            if (saleTotalData == 0)
            {
                this.textBox27.Text = Convert.ToString("0.00");
            }
            else
            {
                this.textBox27.Text = Convert.ToString(tmpTotalPct);
            }
        }


        /// <summary>
        /// 総合計処理　GrandTotalFooter_Formatイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 総合計処理を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.06.04</br>
        /// </remarks>
        private void GrandTotalFooter_Format(object sender, EventArgs e)
        {
            //仕入
            long saleSalesData = Convert.ToInt64(this.textBox37.Text);
            //if (saleSalesData == 0)
            if (1 == _extrInfo.SalesType)
            {
                this.textBox37.Visible = false;
                this.textBox45.Visible = false;
                this.textBox46.Visible = false;
            }
            else
            {
                this.textBox37.Visible = true;
                this.textBox45.Visible = true;
                this.textBox46.Visible = true;
            }
            long stockSalesData = Convert.ToInt64(this.textBox53.Text);
            long grpSalesMoney = saleSalesData - stockSalesData;
            decimal tmpSalesPct = new decimal(0.00);
            if (saleSalesData != 0)
            {
                tmpSalesPct = decimal.Round(((Convert.ToDecimal(grpSalesMoney) / Convert.ToDecimal(saleSalesData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox37.Text = NumberFormat(saleSalesData);
            this.textBox53.Text = NumberFormat(stockSalesData);
            this.textBox45.Text = NumberFormat(grpSalesMoney);
            if (saleSalesData == 0)
            {
                this.textBox46.Text = Convert.ToString("0.00");
            }
            else
            {
                this.textBox46.Text = Convert.ToString(tmpSalesPct);
            }

            //返品
            long saleRetGdsData = Convert.ToInt64(this.textBox38.Text);
            //if (saleRetGdsData == 0)
            if (1 == _extrInfo.SalesType)
            {
                this.textBox38.Visible = false;
                this.textBox44.Visible = false;
                this.textBox47.Visible = false;
            }
            else
            {
                this.textBox38.Visible = true;
                this.textBox44.Visible = true;
                this.textBox47.Visible = true;
            }
            long stockRetGdsData = Convert.ToInt64(this.textBox52.Text);
            long grpRetGdsMoney = saleRetGdsData - stockRetGdsData;
            decimal tmpRetGdsPct = new decimal(0.00);
            if (saleRetGdsData != 0)
            {
                tmpRetGdsPct = decimal.Round(((Convert.ToDecimal(grpRetGdsMoney) / Convert.ToDecimal(saleRetGdsData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox38.Text = NumberFormat(saleRetGdsData);
            this.textBox52.Text = NumberFormat(stockRetGdsData);
            this.textBox44.Text = NumberFormat(grpRetGdsMoney);
            if (saleRetGdsData == 0)
            {
                this.textBox47.Text = Convert.ToString("0.00");
            }
            else
            {
                this.textBox47.Text = Convert.ToString(tmpRetGdsPct);
            }

            //値引
            long saleDistData = Convert.ToInt64(this.textBox39.Text);
            //if (saleDistData == 0)
            if (1 == _extrInfo.SalesType)
            {
                this.textBox39.Visible = false;
                this.textBox43.Visible = false;
                this.textBox48.Visible = false;
            }
            else
            {
                this.textBox39.Visible = true;
                this.textBox43.Visible = true;
                this.textBox48.Visible = true;
            }
            long stockDistData = Convert.ToInt64(this.textBox51.Text);
            long grpDistMoney = saleDistData - stockDistData;
            decimal tmpDistPct = new decimal(0.00);
            if (saleDistData != 0)
            {
                tmpDistPct = decimal.Round(((Convert.ToDecimal(grpDistMoney) / Convert.ToDecimal(saleDistData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox39.Text = NumberFormat(saleDistData);
            this.textBox51.Text = NumberFormat(stockDistData);
            this.textBox43.Text = NumberFormat(grpDistMoney);
            if (saleDistData == 0)
            {
                this.textBox48.Text = Convert.ToString("0.00");
            }
            else
            {
                this.textBox48.Text = Convert.ToString(tmpDistPct);
            }

            //合計
            long saleTotalData = Convert.ToInt64(this.textBox41.Text);
            //if (saleTotalData == 0)
            if (1 == _extrInfo.SalesType)
            {
                this.textBox41.Visible = false;
                this.textBox42.Visible = false;
                this.textBox49.Visible = false;
            }
            else
            {
                this.textBox41.Visible = true;
                this.textBox42.Visible = true;
                this.textBox49.Visible = true;
            }
            long stockTotalData = Convert.ToInt64(this.textBox50.Text);
            long grpTotalMoney = saleTotalData - stockTotalData;
            decimal tmpTotalPct = new decimal(0.00);
            if (saleTotalData != 0)
            {
                tmpTotalPct = decimal.Round(((Convert.ToDecimal(grpTotalMoney) / Convert.ToDecimal(saleTotalData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox41.Text = NumberFormat(saleTotalData);
            this.textBox50.Text = NumberFormat(stockTotalData);
            this.textBox42.Text = NumberFormat(grpTotalMoney);
            if (saleTotalData == 0)
            {
                this.textBox49.Text = Convert.ToString("0.00");
            }
            else
            {
                this.textBox49.Text = Convert.ToString(tmpTotalPct);
            }
        }

        /// <summary>
        /// Detail_BeforePrintイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : Detail_BeforePrintを行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.06.04</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }



        // ===============================================================================
        // ActiveReportsデザイナで生成されたコード
        // ===============================================================================
        #region ActiveReports Designer generated code
        #endregion

    }
}
