//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ホンダUOE WEB引当チェックリスト
// プログラム概要   : ホンダUOE WEB引当チェックリスト印刷クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/06/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// ホンダUOE WEB引当チェックリスト印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ホンダUOE WEB引当チェックリストの印刷を行う。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date	   : 2009.06.03</br>
    /// <br></br>
    /// </remarks>
    public class PMUOE01607PA : IPrintProc
    {
        #region ■ Constructor
		/// <summary>
		/// ホンダUOE WEB引当チェックリスト印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : ホンダUOE WEB引当チェックリスト印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 劉洋</br>
        /// <br>Date	   : 2009.06.03</br>
        /// </remarks>
		public PMUOE01607PA()
		{
		}

		/// <summary>
		/// ホンダUOE WEB引当チェックリスト印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : ホンダUOE WEB引当チェックリスト印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 劉洋</br>
        /// <br>Date	   : 2009.06.03</br>
        /// </remarks>
        public PMUOE01607PA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._slipNoAlwcData = this._printInfo.jyoken as SlipNoAlwcData;
		}
		#endregion ■ Constructor

        #region ■ Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "　";
        #endregion ■ Pricate Const

        #region ■ Private Member
        private SFCMN06002C _printInfo;					        // 印刷情報クラス
        private SlipNoAlwcData _slipNoAlwcData;	            // 抽出条件クラス
        #endregion ■ Private Member
        
        #region ■ Exception Class
        /// <summary> 例外クラス </summary>
        private class RateUnMatchException : ApplicationException
        {
            private int _status;
            #region ◆ Constructor
            /// <summary>
            /// 例外クラスコンストラクタ
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <param name="status">ステータス</param>
            public RateUnMatchException(string message, int status)
                : base(message)
            {
                this._status = status;
            }
            #endregion

            #region ◆ Public Property
            /// <summary> ステータスプロパティ </summary>
            public int Status
            {
                get { return this._status; }
            }
            #endregion
        }
        #endregion ■ Exception Class

        #region ■ IPrintProc メンバ
        #region ◆ Public Property
        /// <summary>
        /// 印刷情報取得プロパティ
        /// </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion ◆ Public Property

        #region ◆ Public Method
        #region ◎ 印刷処理開始
        /// <summary>
        /// 印刷処理開始
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷を開始する。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date	   : 2009.06.03</br>
        /// </remarks>
        public int StartPrint()
        {
            return PrintMain();
        }
        #endregion
        #endregion ◆ Public Method
        #endregion ■ IPrintProc メンバ

        #region ■ Private Member
        #region ◆ 印刷処理
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を行う。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date	   : 2009.06.03</br>
        /// </remarks>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // 印刷フォームクラスインスタンス作成
            DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;
            try
            {
                // レポートインスタンス作成
                this.CreateReport(out prtRpt, this._printInfo.prpid);
                if (prtRpt == null) return status;

                // 各種プロパティ設定
                status = this.SettingProperty(ref prtRpt);
                if (status != 0) return status;

                // データソース設定
                prtRpt.DataSource = (DataView)this._printInfo.rdData;
                prtRpt.DataMember = SlipNoAlwcResult.Tbl_Result_SlipNoAlwc;

                // 印刷データ取得
                DataView dv = (DataView)this._printInfo.rdData;
                
                // ソート順設定
                dv.Sort = this.GetPrintOderQuerry();

                // データソース設定
                prtRpt.DataSource = dv;

                // 印刷共通情報プロパティ設定
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                this.SetPrintCommonInfo(out commonInfo);

                // プレビュー有無				
                int mode = this._printInfo.prevkbn;

                // 出力モードがＰＤＦの場合、無条件でプレビュー無
                if (this._printInfo.printmode == 2)
                {
                    mode = 0;
                }

                switch (mode)
                {
                    case 0:		// プレビュ無
                        {
                            Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();

                            // 共通条件設定
                            processForm.CommonInfo = commonInfo;

                            // プログレスバーUPイベント追加
                            if (prtRpt is IPrintActiveReportTypeCommon)
                            {
                                ((IPrintActiveReportTypeCommon)prtRpt).ProgressBarUpEvent +=
                                    new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
                            }

                            // 印刷実行
                            status = processForm.Run(prtRpt);

                            // 戻り値設定
                            this._printInfo.status = status;

                            break;
                        }
                    case 1:		// プレビュ有
                        {
                            Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

                            // 共通条件設定
                            viewForm.CommonInfo = commonInfo;

                            // プレビュー実行
                            status = viewForm.Run(prtRpt);

                            // 戻り値設定
                            this._printInfo.status = status;

                            break;
                        }
                }

                // ＰＤＦ出力の場合
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    switch (this._printInfo.printmode)
                    {
                        case 1:  // プリンタ
                            break;
                        case 2:  // ＰＤＦ
                        case 3:  // 両方(プリンタ + ＰＤＦ)
                            {
                                // ＰＤＦ表示フラグON
                                this._printInfo.pdfopen = true;

                                // 両方印刷時のみ履歴保存
                                if (this._printInfo.printmode == 3)
                                {
                                    // 出力履歴管理に追加
                                    Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                                    pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
                                        this._printInfo.pdftemppath);
                                }
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (prtRpt != null)
                {
                    prtRpt.Dispose();
                }
            }
            return status;
        }
        #endregion ◆ 印刷処理

        #region ◆ レポートフォーム設定関連
        #region ◎ 各種ActiveReport帳票インスタンス作成
        /// <summary>
        /// 各種ActiveReport帳票インスタンス作成
        /// </summary>
        /// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
        /// <param name="prpid">帳票フォームID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date	   : 2009.06.03</br>
        /// </remarks>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
        {
            // 印刷フォームクラスインスタンス作成
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(),
                typeof(DataDynamics.ActiveReports.ActiveReport3));
        }
        #endregion

        #region ◎ レポートアセンブリインスタンス化
        /// <summary>
        /// レポートアセンブリインスタンス化
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <param name="type">実装するクラス型</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date	   : 2009.06.03</br>
        /// </remarks>
        private object LoadAssemblyReport(string asmname, string classname, Type type)
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
                    {
                        obj = Activator.CreateInstance(objType);
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new RateUnMatchException(asmname + "が存在しません。", -1);
            }
            catch (System.Exception er)
            {
                throw new RateUnMatchException(er.Message, -1);
            }
            return obj;
        }
        #endregion

        #region ◎ 印刷画面共通情報設定

        /// <summary>
        /// 印刷画面共通情報設定
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷画面共通条件の設定を行います。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date	   : 2009.06.03</br>
        /// </remarks>
        private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            // 帳票チャート共通部品クラス
            SFCMN00331C cmnCommon = new SFCMN00331C();

            // PDFパス取得
            string pdfPath = string.Empty;
            string pdfName = string.Empty;

            // プリンタ名
            commonInfo.PrinterName = this._printInfo.prinm;
            // 帳票名
            commonInfo.PrintName = this._printInfo.prpnm;
            // 印刷モード
            commonInfo.PrintMode = this.Printinfo.printmode;
            // 印刷件数
            commonInfo.PrintMax = 0;
            DataView dv = (DataView)this._printInfo.rdData;
            commonInfo.PrintMax = dv.Count;

            status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
            this._printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = this._printInfo.pdftemppath;

            // 上余白
            commonInfo.MarginsTop = this._printInfo.py;
            // 左余白
            commonInfo.MarginsLeft = this._printInfo.px;
        }

        #endregion


        #region ◎ 各種プロパティ設定

        /// <summary>
        /// 各種プロパティ設定
        /// </summary>
        /// <param name="rpt">インスタンス化された帳票フォームクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 各種プロパティを設定します。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date	   : 2009.06.03</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // 印刷条件取得
            SlipNoAlwcData extraInfo = (SlipNoAlwcData)this._printInfo.jyoken;
            
            // ソート順プロパティ設定
            instance.PageHeaderSortOderTitle = GetSortOrderName(extraInfo);

            // 帳票出力設定情報取得 
            PrtOutSet prtOutSet;
            string message;
            int st = SlipNoAlwcInputAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new RateUnMatchException(message, status);
            }

            // 抽出条件ヘッダ出力区分
            instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

            // 抽出条件編集処理
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;

            // フッタ出力区分
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // フッタ出力メッセージ
            StringCollection footers = new StringCollection();
            footers.Add(prtOutSet.PrintFooter1);
            footers.Add(prtOutSet.PrintFooter2);

            instance.PageFooters = footers;

            // 印刷情報オブジェクト
            instance.PrintInfo = this._printInfo;

            // ヘッダーサブタイトル
            // instance.PageHeaderSubtitle = string.Format("{0}", this._printInfo.prpnm);

            // その他データ
            ArrayList otherDataList = new ArrayList();
            instance.OtherDataList = otherDataList;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }



        #endregion

        #region ◎ 抽出条件出力情報作成
        /// <summary>
        /// 抽出条件出力情報作成
        /// </summary>
        /// <param name="extraConditions">作成後抽出条件コレクション</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を作成する。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.10</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            // 発注先
            if (_slipNoAlwcData.UOESupplierCd != 0)
            {
                this.EditCondition(ref addConditions, string.Format("発注先：{0}", _slipNoAlwcData.UOESupplierCd.ToString("000000") + " " + _slipNoAlwcData.UOESupplierName));
            }
            // 更新原価
            if (_slipNoAlwcData.PriceUpdateCode == 0)
            {
                this.EditCondition(ref addConditions, "原価更新区分：しない");
            }
            else
            {
                this.EditCondition(ref addConditions, "原価更新区分：する");
            }
            // 仕入データ区分
            if (_slipNoAlwcData.StockDataCode == 0)
            {
                this.EditCondition(ref addConditions, "仕入データ作成：しない");
            }
            else
            {
                this.EditCondition(ref addConditions, "仕入データ作成：する");
            }

            // 追加
            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }
        }
        #endregion

        #region ◎ 抽出条件文字列編集
        /// <summary>
        /// 抽出条件文字列編集
        /// </summary>
        /// <param name="editArea">格納エリア</param>
        /// <param name="target">対象文字列</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を編集します。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.06.10</br>
        /// </remarks>
        private void EditCondition(ref StringCollection editArea, string target)
        {
            bool isEdit = false;

            // 編集対象文字バイト数算出
            int targetByte = TStrConv.SizeCountSJIS(target);

            for (int i = 0; i < editArea.Count; i++)
            {
                int areaByte = 0;

                // 格納エリアのバイト数算出
                if (editArea[i] != null)
                {
                    areaByte = TStrConv.SizeCountSJIS(editArea[i]);
                }

                if ((areaByte + targetByte + 2) <= 190)
                {
                    isEdit = true;

                    // 全角スペースを挿入
                    if (editArea[i] != null) editArea[i] += ct_Space;

                    editArea[i] += target;
                    break;
                }
            }
            // 新規編集エリア作成
            if (!isEdit)
            {
                editArea.Add(target);
            }
        }
        #endregion

        #region ◎ ソート順名称取得
        /// <summary>
        /// ソート順名称取得
        /// </summary>
        /// <param name="slipNoAlwcData">抽出条件</param>
        /// <returns>ソート順名称</returns>
        /// <remarks>
        /// <br>Note       : ソート順名称を取得する。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date	   : 2009.06.03</br>
        /// </remarks>
        private string GetSortOrderName(SlipNoAlwcData slipNoAlwcData)
        {
            return string.Empty;
        }
        #endregion
        #endregion ◆ レポートフォーム設定関連

        #region ◆　印刷順クエリ作成関数
        /// <summary>
        /// 印字順クエリ作成処理
        /// </summary>
        /// <returns>作成したクエリ</returns>
        /// <remarks>
        /// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date	   : 2009.06.03</br>
        /// </remarks>
        private string GetPrintOderQuerry()
        {
            return string.Empty;
        }
        #endregion

        #region ◎ メッセージ表示

        /// <summary>
        /// メッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">ステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">デフォルトフォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : 出力件数の設定を行います。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date	   : 2009.06.03</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMUOE01607P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion
        #endregion
    }
}
