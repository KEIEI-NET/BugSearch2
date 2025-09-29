//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : レコメンド設定マスタ印刷 テンプレートクラス
// プログラム概要   : レコメンド設定マスタ印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : 西 毅
// 作 成 日  2015/02/23   修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using System.Collections.Specialized;
using System.Data;
using System.Text;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// レコメンド設定マスタ印刷テンプレートクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: レコメンド設定マスタ印刷テンプレートクラス。</br>
    /// <br>Programmer	: 西 毅</br>
    /// <br>Date		: 2015/02/23</br>
    /// <br></br>
    /// </remarks>
    public partial class PMREC09019P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ Constructor
        /// <summary>
        /// レコメンド設定マスタ印刷テンプレートクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: レコメンド設定マスタ印刷テンプレートクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 西 毅</br>
        /// <br>Date		: 2015/02/23</br>
        /// </remarks>
        public PMREC09019P_01A4C()
        {
            InitializeComponent();
        }
        #endregion ■ Constructor

        #region ■ Private Member
        // 印刷件数用カウンタ
        private int _printCount;
        // 抽出条件ヘッダ出力区分
        private int _extraCondHeadOutDiv;
        // 抽出条件	
        private StringCollection _extraConditions;
        // フッター出力区分	
        private int _pageFooterOutCode;
        // フッターメッセージ	
        private StringCollection _pageFooters;
        // 印刷情報クラス			
        private SFCMN06002C _printInfo;
        // ソート順			
        private string _pageHeaderSortOderTitle;
        // 抽出条件クラス
        private SearchCondition _inventoryDataDspParam;
        // 背景透かしモード(無し)
        private int _watermarkMode = 0;

        #endregion ■ Private Member

        #region ■ IPrintActiveReportTypeList メンバ
        #region ◆ Public Property
        /// <summary> ページヘッダソート順タイトル項目</summary>
        /// <value>PageHeaderSortOderTitle</value>               
        /// <remarks>ページヘッダソート順タイトル項目セットプロパティ </remarks> 
        public string PageHeaderSortOderTitle
        {
            set { _pageHeaderSortOderTitle = value; }
        }

        /// <summary> 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]</summary>
        /// <value>ExtraCondHeadOutDiv</value>               
        /// <remarks>抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]セットプロパティ </remarks> 
        public int ExtraCondHeadOutDiv
        {
            set { _extraCondHeadOutDiv = value; }
        }

        /// <summary> 抽出条件ヘッダー項目</summary>
        /// <value>ExtraConditions</value>               
        /// <remarks>抽出条件ヘッダー項目セットプロパティ </remarks> 
        public StringCollection ExtraConditions
        {
            set { this._extraConditions = value; }
        }

        /// <summary> フッター出力区分</summary>
        /// <value>PageFooterOutCode</value>               
        /// <remarks>フッター出力区分セットプロパティ </remarks> 
        public int PageFooterOutCode
        {
            set { this._pageFooterOutCode = value; }
        }

        /// <summary> フッタ出力文</summary>
        /// <value>PageFooters</value>               
        /// <remarks>フッタ出力文セットプロパティ </remarks> 
        public StringCollection PageFooters
        {
            set { this._pageFooters = value; }
        }

        /// <summary>印刷条件</summary>
        /// <value>PrintInfo</value>               
        /// <remarks>印刷条件セットプロパティ </remarks> 
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
                this._inventoryDataDspParam = (SearchCondition)this._printInfo.jyoken;
            }
        }

        /// <summary>その他データ</summary>
        /// <value>OtherDataList</value>               
        /// <remarks>その他データセットプロパティ </remarks> 
        public ArrayList OtherDataList
        {
            set { }
        }

        /// <summary>サブヘッダタイトル</summary>
        /// <value>PageHeaderSubtitle</value>               
        /// <remarks>サブヘッダタイトルセットプロパティ </remarks> 
        public string PageHeaderSubtitle
        {
            set { }
        }

        #endregion ◆ Public Property
        #endregion ■ IPrintActiveReportTypeList メンバ

        #region ■IPrintActiveReportTypeCommon メンバ
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
        #endregion ■IPrintActiveReportTypeCommon メンバ

        #region ■ Private Method
        #region ◆ レポート要素出力設定
        /// <summary>
        /// レポート要素出力設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer	: 西 毅</br>
        /// <br>Date		: 2015/02/23</br>
        /// <br></br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;
            /*
            if (this._inventoryDataDspParam.GoodsMakerCd == 0)
            {
                this.lb_MakerNameDsp.Text = "全メーカー";
            }
            else
            {
                //this.lb_MakerNameDsp.Text = this._inventoryDataDspParam.GoodsMakerName; // DEL 2014/03/26 西 毅 Redmine#42247
                this.lb_MakerNameDsp.Text = SubStringOfByte(this._inventoryDataDspParam.GoodsMakerName, 10); // ADD 2014/03/26 西 毅 Redmine#42247
            }

            // 表示タイプ
            if (this._inventoryDataDspParam.ListTypeDiv == 2)
            {
                // 表示タイプ：最大
                // 棚卸金額：非表示
                this.lb_InventoryMony.Visible = false;
                this.tb_InventoryMony.Visible = false;
                // 最大棚卸金額：表示
                this.lb_MaxInventoryMony.Visible = true;
                this.tb_MaxInventoryMony.Visible = true;
                // 差額：表示
                this.lb_Balance.Visible = true;
                this.tb_Balance.Visible = true;
            }
            else
            {
                // 表示タイプ：最大以外
                // 棚卸金額：表示
                this.lb_InventoryMony.Visible = true;
                this.tb_InventoryMony.Visible = true;
                // 最大棚卸金額：非表示
                this.lb_MaxInventoryMony.Visible = false;
                this.tb_MaxInventoryMony.Visible = false;
                // 差額：非表示
                this.lb_Balance.Visible = false;
                this.tb_Balance.Visible = false;
            }
             */ 
        }

        //----- ADD 2014/03/26 西 毅 Redmine#42247 ---------->>>>>
        /// <summary>
        /// 元文字列により、指定バイト数の目標文字列の取得
        /// </summary>
        /// <param name="orgString">元文字列</param>
        /// <param name="byteCount">指定バイト数</param>
        /// <returns>目標文字列</returns>
        /// <remarks>
        /// <br>Note		: 元文字列により、指定バイト数の目標文字列の取得</br>
        /// <br>Programmer	: 西 毅</br>
        /// <br>Date		: 2014/03/26</br>
        /// </remarks>
        private string SubStringOfByte(string orgString, int byteCount)
        {
            if (byteCount <= 0)
            {
                return string.Empty;
            }

            Encoding encoding = Encoding.Default;

            string resultString = string.Empty;

            // あらかじめ「文字数」を指定して切り抜いておく
            // (この段階でbyte数は<文字数>～2*<文字数>の間になる)
            orgString = orgString.PadRight(byteCount).Substring(0, byteCount);

            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // 「文字数」を減らす
                resultString = orgString.Substring(0, i);

                // バイト数を取得して判定
                count = encoding.GetByteCount(resultString);
                if (count <= byteCount) break;
            }

            // 終端の空白は削除
            return resultString;

        }
        //----- ADD 2014/03/26 西 毅 Redmine#42247 ----------<<<<<
        #endregion ◆ レポート要素出力設定
        #endregion

        #region ■ Control Event

        #region ◎ PMREC09019P_01A4C_ReportStart Event
        /// <summary>
        /// PMREC09019P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 西 毅</br>
        /// <br>Date		: 2015/02/23</br>
        /// </remarks>
        private void PMREC09019P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            SetOfReportMembersOutput();
        }
        #endregion

        #region ◎ PageHeader_Format Event
        /// <summary>
        /// PageHeader_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 西 毅</br>
        /// <br>Date		: 2015/02/23</br>
        /// </remarks>
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            // 作成日付
            DateTime now = DateTime.Now;
            // 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
            // 作成時間
            this.tb_PrintTime.Text = TDateTime.DateTimeToString("HH:MM", now);
        }
        #endregion

        #region ◎ ExtraHeader_Format Event
        /// <summary>
        /// ExtraHeader_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ExtraHeaderグループのフォーマットイベント。</br>
        /// <br>Programmer	: 西 毅</br>
        /// <br>Date		: 2015/02/23</br>
        /// </remarks>
        private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
        {
        }
        #endregion

        #region ◎ Detail_AfterPrint Event
        /// <summary>
        /// Detail_AfterPrint Event
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションがページに描画された後に発生します。</br>
        /// <br>Programmer	: 西 毅</br>
        /// <br>Date		: 2015/02/23</br>
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
        #endregion

        #region ◎ Detail_BeforePrint Event
        /// <summary>
        /// Detail_BeforePrintイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生します。</br>
        /// <br>Programmer  : 西 毅</br>                                   
        /// <br>Date        : 2015/02/23</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);            
        }
        #endregion ◎ Detail_BeforePrint Event

        #region ◎ Detail_Format Event
        /// <summary>
        /// Detail_Format イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 明細セクションのフォーマットイベントです。</br>
        /// <br>Programmer  : 西 毅</br>                                   
        /// <br>Date        : 2015/02/23</br>
        /// </remarks>
        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            string goodscomment = string.Empty;
            string goodscomment2 = string.Empty;
            int num = sjisEnc.GetByteCount(this.goodscomment.Text);
            if (num > 60)
            {
                goodscomment = this.ByteSubstring(this.goodscomment.Text, 0, 60);
                if (num > 120)
                {
                    goodscomment2 = this.ByteSubstring(this.goodscomment.Text, 60, 60);
                }
                else
                {
                    goodscomment2 = this.ByteSubstring(this.goodscomment.Text, 60, 60);
                }
            }
            else
            {
                goodscomment = this.goodscomment.Text;
            }

            this.goodscomment.Text  = goodscomment;
            this.goodscomment2.Text = goodscomment2;

            /*
            // アイテム数が「Z,ZZZ,ZZ9」を超える場合、「*********」を印刷する
            if (this.tb_ItemCnt.Value.ToString().Length > 9)
            {
                this.tb_ItemCnt.Text = "*********";
            }
            // 棚卸金額が「Z,ZZZ,ZZZ,ZZ9」を超える場合、「*************」を印刷する
            if (this.tb_InventoryMony.Value.ToString().Length > 13)
            {
                this.tb_InventoryMony.Text = "*************";
            }
            // 最大棚卸金額が「Z,ZZZ,ZZZ,ZZ9」を超える場合、「*************」を印刷する
            if (this.tb_MaxInventoryMony.Value.ToString().Length > 13)
            {
                this.tb_MaxInventoryMony.Text = "*************";
            }
            // 差額が「Z,ZZZ,ZZZ,ZZ9」を超える場合、「*************」を印刷する
            if (this.tb_Balance.Value.ToString().Length > 13)
            {
                this.tb_Balance.Text = "*************";
            }
             */ 
        }
        public string ByteSubstring(string value, int startindex, int length)
        {
            string ret = "";          // 切り出した文字列
            int start = 0;
            Encoding sjis = Encoding.GetEncoding("Shift-JIS");

            if (startindex < 0) { startindex = 0; }
            if (length < 0) { length = 0; }

            // 開始位置を取得
            if (startindex == 0)
            {
                // 先頭を指定された
                start = 0;
            }
            else
            {
                // 先頭以外を指定された
                int bytecnt = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    // 先頭からのバイト数を取得
                    bytecnt += sjis.GetByteCount(value.Substring(i, 1));
                    if (bytecnt >= startindex)
                    {
                        // 先頭からのバイト数が開始位置以上になる文字の次の文字が開始位置
                        start = i + 1;
                        break;
                    }
                }
            }

            // 指定された開始位置が文字の途中だった場合、切出しサイズをマイナス１！
            if (length > 0)
            {
                if (sjis.GetByteCount(value.Substring(0, start)) > startindex)
                {
                    length--;
                }
            }

            // 決定した開始位置から1文字ずつ取得し、指定バイト数を超えるまで取得
            for (int i = 0; i < value.Length; i++)
            {
                if (i >= start)
                {
                    if ((sjis.GetByteCount(ret + value.Substring(i, 1)) <= length) || (length == 0))
                    {
                        ret += value.Substring(i, 1);
                    }
                }
            }
            return ret;
        }
        #endregion ◎ Detail_Format Event

        #region ◎ フッターデータ連結後、描画前(PageFooter_Format)
        /// <summary>
        /// フッターデータ連結後、描画前
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後、描画前に発生します。</br>
        /// <br>Programmer  : 西 毅</br>                                   
        /// <br>Date        : 2014/02/23</br>
        /// </remarks>
        private void pageFooter_Format(object sender, EventArgs e)
        {
            if (this._pageFooters == null)
            {
                return;
            }

            // フッター出力
            if (this._pageFooterOutCode == 0)
            {
                // フッター印字項目設定
                //this.line3.Visible = true;

                if (this._pageFooters[0] != null)
                {
                    this.tb_FooterStr1.Text = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    this.tb_FooterStr2.Text = this._pageFooters[1];
                }
            }
        }
        #endregion // フッターデータ連結後、描画前(PageFooter_Format)

        #endregion ■ Control Event

    }
}
