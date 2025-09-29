//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌別出荷実績表
// プログラム概要   : 車輌別出荷実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/09/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/10/13  修正内容 : 粗利率 =（粗利 ÷ 売上金額）*100を変更する
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

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMSYA02003P_01A4C帳票クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 特になし</br>
    /// <br>Programmer	: 張莉莉</br>
    /// <br>Date		: 2009.09.15</br>
    /// </remarks>
    public partial class PMSYA02003P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeCommon, IPrintActiveReportTypeList
    {
        #region Private Members
        // 印刷件数
        private int _printCount = 0;

        // 背景透かしモード(無し)
        private int _watermarkMode = 0;

        // 抽出条件ヘッダ出力区分
        private int _extraCondHeadOutDiv;

        // 関連データオブジェクト
        private ArrayList _otherDataList;

        // 抽出条件印字項目
        private StringCollection _extraConditions;

        // 拠点表示有無
        private bool _isSection;

        // フッター出力有無
        private int _pageFooterOutCode;

        // フッタメッセージ1
        private StringCollection _pageFooters;

        // ソート順タイトル
        private string _pageHeaderSortOderTitle;

        // Extra SubReport
        ListCommon_ExtraHeader _rptExtraHeader = new ListCommon_ExtraHeader();

        // 印刷情報
        private SFCMN06002C _printInfo;

        // 表示条件クラス
        private CarShipRsltListCndtn _extrInfo;

        #endregion

        /// <summary>
        /// ProgressBarUpEvent
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;

        /// <summary>
        /// PMSYA02003P_01A4C帳票コンストラクタ
        /// </summary>
        public PMSYA02003P_01A4C()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 明細アフタープリントイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画された後に発生します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
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

        /// <summary>
        /// レポートスタートイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: レポートの生成処理が開始されたときに発生します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void PMSYA02003P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            // レポート要素出力設定	
            SetOfReportMembersOutput();
        }

        /// <summary>
        /// ページヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void PageHeader_Format(object sender, EventArgs eArgs)
        {
            // 作成日付
            DateTime now = DateTime.Now;
            this.tb_PrintDate.Text = now.ToString("yyyy/MM/dd");
            this.tb_PrintTime.Text = now.ToString("HH:mm");
            if ((int)_extrInfo.DetailDataValue == 0)
            {
                this.SortTitle.Text = "[明細単位：品番]";
            }
            else if ((int)_extrInfo.DetailDataValue == 1)
            {
                this.SortTitle.Text = "[明細単位：BLｺｰﾄﾞ]";
            }
            else if ((int)_extrInfo.DetailDataValue == 2)
            {
                this.SortTitle.Text = "[明細単位：ｸﾞﾙｰﾌﾟｺｰﾄﾞ]";
            }
        }

        /// <summary>
        /// 抽出データフォーマット処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: 抽出データフォーマットを処理します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
         private void ExtraHeader_Format ( object sender, System.EventArgs eArgs )
        {
            // 抽出条件設定
            // ヘッダ出力制御
            if ( this._extraCondHeadOutDiv == 0 )
            {
                // 毎ページ出力
                this.ExtraHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            }
            else
            {
                // 先頭ページのみ
                this.ExtraHeader.RepeatStyle = RepeatStyle.None;
            }

            // インスタンスが作成されていなければ作成
            if ( this._rptExtraHeader == null )
            {
                this._rptExtraHeader = new ListCommon_ExtraHeader();
            }
            else
            {
                // インスタンスが作成されていれば、データソースを初期化する
                // (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
                this._rptExtraHeader.DataSource = null;
            }

            // 抽出条件印字項目設定
            this._rptExtraHeader.ExtraConditions = this._extraConditions;

            this.Header_SubReport.Report = this._rptExtraHeader;
        }

        #region IPrintActiveReportTypeCommon メンバ

        /// <summary>背景透かしモード</summary>
        /// <value>0：背景透かし無し, 1:背景透かし有り</value>
        public int WatermarkMode
        {
            set { }
            get { return this._watermarkMode; }
        }

        #endregion

        #region IPrintActiveReportTypeList メンバ

        /// <summary>
        /// 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]
        /// </summary>
        public int ExtraCondHeadOutDiv
        {
            set { this._extraCondHeadOutDiv = value; }
        }

        /// <summary>
        /// 抽出条件ヘッダー項目
        /// </summary>
        public StringCollection ExtraConditions
        {
            set
            {
                this._extraConditions = value;
            }
        }

        /// <summary>
        /// その他データ
        /// </summary>
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

        /// <summary>
        /// フッター出力区分
        /// </summary>
        public int PageFooterOutCode
        {
            set
            {
                this._pageFooterOutCode = value;
            }
        }

        /// <summary>
        /// フッタ出力文
        /// </summary>
        public StringCollection PageFooters
        {
            set
            {
                this._pageFooters = value;
            }
        }

        /// <summary>
        /// ページヘッダソート順タイトル項目
        /// </summary>
        public string PageHeaderSortOderTitle
        {
            set
            {
                this._pageHeaderSortOderTitle = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PageHeaderSubtitle
        {
            set { }
        }

        /// <summary>
        /// 印刷条件
        /// </summary>
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
                _extrInfo = (CarShipRsltListCndtn)this._printInfo.jyoken;
            }
        }

        #endregion

        /// <summary>
        /// レポート要素出力設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>																
        /// </remarks>																
        private void SetOfReportMembersOutput()
        {
            // 改頁
            if ((int)this._extrInfo.NewPageDiv == 0)
            {
                MngNoHeader.NewPage = NewPage.None;
            }
            else
            {
                MngNoHeader.NewPage = NewPage.Before;
            }

        }

        /// <summary>
        /// ページヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void detail_Format(object sender, EventArgs e)
        {
            // [明細単位：品番]
            if ((int)_extrInfo.DetailDataValue == 0)
            {
                this.tb_BLGoodsCode.Visible = true;
                this.tb_BLGoodsHalfName.Visible = false;
                this.tb_BLGroupCode.Visible = false;
                this.tb_BLGroupKanaName.Visible = false;
                this.tb_GoodsNo.Visible = true;
                this.tb_GoodsNameKana.Visible = true;
                this.tb_GoodsMakerCd.Visible = true;
                // 画面の明細単位「品番」設定時は、商品名称カナ(商品名称)をセットする
                this.tb_GoodsNameKana.DataField = "GoodsNameKanaRF";
            }
            // [明細単位：BLｺｰﾄﾞ]
            else if ((int)_extrInfo.DetailDataValue == 1)
            {
                this.tb_BLGoodsCode.Visible = true;
                this.tb_BLGoodsHalfName.Visible = true;
                this.tb_BLGroupCode.Visible = false;
                this.tb_BLGroupKanaName.Visible = false;
                this.tb_GoodsNo.Visible = false;
                this.tb_GoodsNameKana.Visible = false;
                this.tb_GoodsMakerCd.Visible = false;
            }
            // [明細単位：ｸﾞﾙｰﾌﾟｺｰﾄﾞ]
            else if ((int)_extrInfo.DetailDataValue == 2)
            {
                this.tb_BLGoodsCode.Visible = false;
                this.tb_BLGoodsHalfName.Visible = false;
                this.tb_BLGroupCode.Visible = true;
                this.tb_BLGroupKanaName.Visible = true;
                this.tb_GoodsNo.Visible = false;
                this.tb_GoodsNameKana.Visible = false;
                this.tb_GoodsMakerCd.Visible = false;
            }

            // 品番出力区分
            if ((int)this._extrInfo.GoodsNoPrint == 0)
            {
                this.tb_GoodsNo.Visible = false;
            }
            else
            {
                this.tb_GoodsNo.Visible = true;
            }

            // 原価・粗利出力
            if ((int)this._extrInfo.CostGrossPrint == 0)
            {
                this.tb_GrossProfit.Visible = false;
                this.tb_GrossPiv.Visible = false;
            }
            else
            {
                this.tb_GrossProfit.Visible = true;
                this.tb_GrossPiv.Visible = true;
            }
        }

        /// <summary>
        /// ページヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void TitleHeader_Format(object sender, EventArgs e)
        {
            // [明細単位：品番]
            if ((int)_extrInfo.DetailDataValue == 0)
            {
                this.lb_GroupCd.Visible = false;
                this.lb_blCd.Visible = true;
                this.lb_goodsNm.Visible = true;
                this.lb_GoodsNo.Visible = true;
                this.lb_maker.Visible = true;
            }
            // [明細単位：BLｺｰﾄﾞ]
            else if ((int)_extrInfo.DetailDataValue == 1)
            {
                this.lb_GroupCd.Visible = false;
                this.lb_blCd.Visible = true;
                this.lb_goodsNm.Visible = false;
                this.lb_GoodsNo.Visible = false;
                this.lb_maker.Visible = false;

            }
            // [明細単位：ｸﾞﾙｰﾌﾟｺｰﾄﾞ]
            else if ((int)_extrInfo.DetailDataValue == 2)
            {
                this.lb_GroupCd.Visible = true;
                this.lb_blCd.Visible = false;
                this.lb_goodsNm.Visible = false;
                this.lb_GoodsNo.Visible = false;
                this.lb_maker.Visible = false;
            }

            // 品番出力区分
            if ((int)this._extrInfo.GoodsNoPrint == 0)
            {
                this.lb_GoodsNo.Visible = false;
            }
            else
            {
                this.lb_GoodsNo.Visible = true;
            }

            // 原価・粗利出力
            if ((int)this._extrInfo.CostGrossPrint == 0)
            {
                this.lb_GrossProfit.Visible = false;
                this.lb_GrossPiv.Visible = false;
            }
            else
            {
                this.lb_GrossProfit.Visible = true;
                this.lb_GrossPiv.Visible = true;
            }

        }

        /// <summary>
        /// ページヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void BLGroupCodeHeader_Format(object sender, EventArgs e)
        {
            // [明細単位：ｸﾞﾙｰﾌﾟｺｰﾄﾞ]
            if ((int)_extrInfo.DetailDataValue == 2)
            {
                this.BLGroupCodeHeader.Visible = false;
            }
            else
            {
                this.BLGroupCodeHeader.Visible = true;
            }
        }

        /// <summary>
        /// ページヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void BLGoodsCdFooter_Format(object sender, EventArgs e)
        {
            // [明細単位：品番]
            if ((int)_extrInfo.DetailDataValue == 0)
            {
                this.BLGoodsCdFooter.Visible = true;
            }
            // [明細単位：BLｺｰﾄﾞ][明細単位：ｸﾞﾙｰﾌﾟｺｰﾄﾞ]
            else 
            {
                this.BLGoodsCdFooter.Visible = false;
            }

            //粗利率
            // 端数処理
            double grosspiv_blcode = 0;
            if ((Convert.ToDouble(tb_SalesMoneyTaxExc_blcode.Text)) != 0)
            {
                // --- UPD 2009/10/13 ------>>>>>
                // 粗利率　（粗利 ÷ 売上金額）*100　
                //  grosspiv_blcode = (Convert.ToDouble(tb_GrossProfit_blcode.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_blcode.Text));
                grosspiv_blcode = ((Convert.ToDouble(tb_GrossProfit_blcode.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_blcode.Text))) * 100;
                // --- UPD 2009/10/13 ------<<<<<
            }
            tb_GrossPiv_blcode.Text = grosspiv_blcode.ToString("f2");

            // 原価・粗利出力
            if ((int)this._extrInfo.CostGrossPrint == 0)
            {
                this.tb_GrossProfit_blcode.Visible = false;
                this.tb_GrossPiv_blcode.Visible = false;
            }
            else
            {
                this.tb_GrossProfit_blcode.Visible = true;
                this.tb_GrossPiv_blcode.Visible = true;
            }
        }

        /// <summary>
        /// ページヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void BLGroupCodeFooter_Format(object sender, EventArgs e)
        {
            // [明細単位：ｸﾞﾙｰﾌﾟｺｰﾄﾞ]
            if ((int)_extrInfo.DetailDataValue == 2)
            {
                this.BLGroupCodeFooter.Visible = false;
                this.line_blgroup.Visible = false;
            }
            // [明細単位：BLｺｰﾄﾞ]
            else if ((int)_extrInfo.DetailDataValue == 1)
            {
                this.BLGroupCodeFooter.Visible = true;
                this.line_blgroup.Visible = true;
            }
            // [明細単位：品番]
            else if ((int)_extrInfo.DetailDataValue == 0)
            {
                this.BLGroupCodeFooter.Visible = true;
                this.line_blgroup.Visible = false;
            }

            //粗利率
            // 端数処理
            double grosspiv_groupcd = 0;
            if ((Convert.ToDouble(tb_SalesMoneyTaxExc_groupcd.Text)) != 0)
            {
                // --- UPD 2009/10/13 ------>>>>>
                // 粗利率　（粗利 ÷ 売上金額）*100　
                //  grosspiv_groupcd = (Convert.ToDouble(tb_GrossProfit_groupcd.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_groupcd.Text));
                grosspiv_groupcd = ((Convert.ToDouble(tb_GrossProfit_groupcd.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_groupcd.Text))) * 100;
                // --- UPD 2009/10/13 ------<<<<<
            }
            tb_GrossPiv_groupcd.Text = grosspiv_groupcd.ToString("f2");

            // 原価・粗利出力
            if ((int)this._extrInfo.CostGrossPrint == 0)
            {
                this.tb_GrossProfit_groupcd.Visible = false;
                this.tb_GrossPiv_groupcd.Visible = false;
            }
            else
            {
                this.tb_GrossProfit_groupcd.Visible = true;
                this.tb_GrossPiv_groupcd.Visible = true;
            }
        }

        /// <summary>
        /// ページヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void MngNoFooter_Format(object sender, EventArgs e)
        {
            // [明細単位：ｸﾞﾙｰﾌﾟｺｰﾄﾞ]
            if ((int)_extrInfo.DetailDataValue == 2)
            {
                this.line_car.Visible = true;
            }
            // [明細単位：BLｺｰﾄﾞ]
            else if ((int)_extrInfo.DetailDataValue == 1)
            {
                this.line_car.Visible = false;
            }
            // [明細単位：品番]
            else if ((int)_extrInfo.DetailDataValue == 0)
            {
                this.line_car.Visible = false;
            }
            //粗利率
            // 端数処理
            double grosspiv_car = 0;
            if ((Convert.ToDouble(tb_SalesMoneyTaxExc_car.Text)) != 0)
            {
                // --- UPD 2009/10/13 ------>>>>>
                // 粗利率　（粗利 ÷ 売上金額）*100　
                //  grosspiv_car = (Convert.ToDouble(tb_GrossProfit_car.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_car.Text));
                grosspiv_car = ((Convert.ToDouble(tb_GrossProfit_car.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_car.Text))) * 100;
                // --- UPD 2009/10/13 ------<<<<<
            }
            tb_GrossPiv_car.Text = grosspiv_car.ToString("f2");

            // 原価・粗利出力
            if ((int)this._extrInfo.CostGrossPrint == 0)
            {
                this.tb_GrossProfit_car.Visible = false;
                this.tb_GrossPiv_car.Visible = false;
            }
            else
            {
                this.tb_GrossProfit_car.Visible = true;
                this.tb_GrossPiv_car.Visible = true;
            }
        }

        /// <summary>
        /// ページヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void CustomerFooter_Format(object sender, EventArgs e)
        {
            //粗利率
            // 端数処理
            double grosspiv_customer = 0;
            if ((Convert.ToDouble(tb_SalesMoneyTaxExc_customer.Text)) != 0)
            {
                // --- UPD 2009/10/13 ------>>>>>
                // 粗利率　（粗利 ÷ 売上金額）*100　
                //  grosspiv_customer = (Convert.ToDouble(tb_GrossProfit_customer.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_customer.Text));
                grosspiv_customer = ((Convert.ToDouble(tb_GrossProfit_customer.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_customer.Text))) * 100;
                // --- UPD 2009/10/13 ------<<<<<
            }
            tb_GrossPiv_customer.Text = grosspiv_customer.ToString("f2");

            // 原価・粗利出力
            if ((int)this._extrInfo.CostGrossPrint == 0)
            {
                this.tb_GrossProfit_customer.Visible = false;
                this.tb_GrossPiv_customer.Visible = false;
            }
            else
            {
                this.tb_GrossProfit_customer.Visible = true;
                this.tb_GrossPiv_customer.Visible = true;
            }
        }

        /// <summary>
        /// ページヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void SectionFooter_Format(object sender, EventArgs e)
        {
            //粗利率
            // 端数処理
            double grosspiv_sec = 0;
            if ((Convert.ToDouble(tb_SalesMoneyTaxExc_sec.Text)) != 0)
            {
                // --- UPD 2009/10/13 ------>>>>>
                // 粗利率　（粗利 ÷ 売上金額）*100　
                //  grosspiv_sec = (Convert.ToDouble(tb_GrossProfit_sec.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_sec.Text));
                grosspiv_sec = ((Convert.ToDouble(tb_GrossProfit_sec.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_sec.Text))) * 100;
                // --- UPD 2009/10/13 ------<<<<<
            }
            tb_GrossPiv_sec.Text = grosspiv_sec.ToString("f2");

            // 原価・粗利出力
            if ((int)this._extrInfo.CostGrossPrint == 0)
            {
                this.tb_GrossProfit_sec.Visible = false;
                this.tb_GrossPiv_sec.Visible = false;
            }
            else
            {
                this.tb_GrossProfit_sec.Visible = true;
                this.tb_GrossPiv_sec.Visible = true;
            }
        }

        /// <summary>
        /// ページヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void TotalFooter_Format(object sender, EventArgs e)
        {
            //粗利率
            // 端数処理
            double grosspiv_all = 0;
            if ((Convert.ToDouble(tb_SalesMoneyTaxExc_all.Text)) != 0)
            {
                // --- UPD 2009/10/13 ------>>>>>
                // 粗利率　（粗利 ÷ 売上金額）*100　
                //  grosspiv_all = (Convert.ToDouble(tb_GrossProfit_all.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_all.Text));
                grosspiv_all = ((Convert.ToDouble(tb_GrossProfit_all.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_all.Text))) * 100;
                // --- UPD 2009/10/13 ------<<<<<
            }
            tb_GrossPiv_all.Text = grosspiv_all.ToString("f2");

            // 原価・粗利出力
            if ((int)this._extrInfo.CostGrossPrint == 0)
            {
                this.tb_GrossProfit_all.Visible = false;
                this.tb_GrossPiv_all.Visible = false;
            }
            else
            {
                this.tb_GrossProfit_all.Visible = true;
                this.tb_GrossPiv_all.Visible = true;
            }
        }
    }
}
