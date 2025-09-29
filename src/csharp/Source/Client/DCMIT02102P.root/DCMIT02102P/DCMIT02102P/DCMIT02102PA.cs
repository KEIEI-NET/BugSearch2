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
    /// 見積確認表印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 見積確認表の印刷を行う。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.09.19</br>
    /// </remarks>
    class DCMIT02102PA : IPrintProc
    {
        #region ■ Constructor
        /// <summary>
        /// 見積確認表印刷クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 見積確認表印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public DCMIT02102PA ()
        {
        }

        /// <summary>
        /// 見積確認表印刷クラスコンストラクタ
        /// </summary>
        /// <param name="printInfo">印刷情報オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 見積確認表印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public DCMIT02102PA ( object printInfo )
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._estimateListCndtn = this._printInfo.jyoken as EstimateListCndtn;
        }
        #endregion ■ Constructor

        #region ■ Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "　";
        // 2008.08.01 30413 犬飼 文言変更 >>>>>>START
        //private const string ct_Extr_Top = "ＴＯＰ";
        //private const string ct_Extr_End = "ＥＮＤ";
        private const string ct_Extr_Top = "最初から";
        private const string ct_Extr_End = "最後まで";
        // 2008.08.01 30413 犬飼 文言変更 <<<<<<END
        private const string ct_RangeConst = "：{0} ～ {1}";
        #endregion ■ Pricate Const

        #region ■ Private Member
        private SFCMN06002C _printInfo;					// 印刷情報クラス
        private EstimateListCndtn _estimateListCndtn;		// 抽出条件クラス
        #endregion ■ Private Member

        #region ■ Exception Class
        /// <summary> 例外クラス </summary>
        private class StockMoveException : ApplicationException
        {
            private int _status;
            #region ◆ Constructor
            /// <summary>
            /// 例外クラスコンストラクタ
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <param name="status">ステータス</param>
            public StockMoveException ( string message, int status )
                : base( message )
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public int StartPrint ()
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private int PrintMain ()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // 印刷フォームクラスインスタンス作成
            DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;

            try
            {
                // レポートインスタンス作成
                this.CreateReport( out prtRpt, this._printInfo.prpid );
                if ( prtRpt == null ) return status;

                // 各種プロパティ設定
                status = this.SettingProperty( ref prtRpt );
                if ( status != 0 ) return status;

                // データソース設定
                prtRpt.DataSource = this._printInfo.rdData;
                prtRpt.DataMember = DCMIT02104EA.ct_Tbl_EstimateList;

                // 印刷共通情報プロパティ設定
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                this.SetPrintCommonInfo( out commonInfo );

                // プレビュー有無				
                int mode = this._printInfo.prevkbn;

                // 出力モードがＰＤＦの場合、無条件でプレビュー無
                if ( this._printInfo.printmode == 2 )
                {
                    mode = 0;
                }

                switch ( mode )
                {
                    case 0:		// プレビュ無
                        {
                            Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();

                            // 共通条件設定
                            processForm.CommonInfo = commonInfo;

                            // プログレスバーUPイベント追加
                            if ( prtRpt is IPrintActiveReportTypeCommon )
                            {
                                ( (IPrintActiveReportTypeCommon)prtRpt ).ProgressBarUpEvent +=
                                    new ProgressBarUpEventHandler( processForm.ProgressBarUpEvent );
                            }

                            // 印刷実行
                            status = processForm.Run( prtRpt );

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
                            status = viewForm.Run( prtRpt );

                            // 戻り値設定
                            this._printInfo.status = status;

                            break;
                        }
                }

                // ＰＤＦ出力の場合
                if ( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    switch ( this._printInfo.printmode )
                    {
                        case 1:  // プリンタ
                            break;
                        case 2:  // ＰＤＦ
                        case 3:  // 両方(プリンタ + ＰＤＦ)
                            {
                                // ＰＤＦ表示フラグON
                                this._printInfo.pdfopen = true;

                                // 両方印刷時のみ履歴保存
                                if ( this._printInfo.printmode == 3 )
                                {
                                    // 出力履歴管理に追加
                                    Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                                    pdfHistoryControl.AddPrintInfo( this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
                                        this._printInfo.pdftemppath );
                                }
                                break;
                            }
                    }
                }
            }
            catch ( Exception ex )
            {
                this.MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
            }
            finally
            {
                if ( prtRpt != null )
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private void CreateReport ( out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid )
        {
            // 印刷フォームクラスインスタンス作成
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(),
                typeof( DataDynamics.ActiveReports.ActiveReport3 ) );
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private object LoadAssemblyReport ( string asmname, string classname, Type type )
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load( asmname );
                Type objType = asm.GetType( classname );
                if ( objType != null )
                {
                    if ( ( objType == type ) || ( objType.IsSubclassOf( type ) == true ) || ( objType.GetInterface( type.Name ).Name == type.Name ) )
                    {
                        obj = Activator.CreateInstance( objType );
                    }
                }
            }
            catch ( System.IO.FileNotFoundException )
            {
                throw new StockMoveException( asmname + "が存在しません。", -1 );
            }
            catch ( System.Exception er )
            {
                throw new StockMoveException( er.Message, -1 );
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private void SetPrintCommonInfo ( out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            // 帳票チャート共通部品クラス
            SFCMN00331C cmnCommon = new SFCMN00331C();

            // PDFパス取得
            string pdfPath = "";
            string pdfName = "";

            // プリンタ名
            commonInfo.PrinterName = this._printInfo.prinm;
            // 帳票名
            commonInfo.PrintName = this._printInfo.prpnm;
            // 印刷モード
            commonInfo.PrintMode = this.Printinfo.printmode;
            // 印刷件数
            commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;

            status = cmnCommon.GetPdfSavePathName( this._printInfo.prpnm, ref pdfPath, ref pdfName );
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private int SettingProperty ( ref DataDynamics.ActiveReports.ActiveReport3 rpt )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // 印刷条件取得
            EstimateListCndtn extraInfo = (EstimateListCndtn)this._printInfo.jyoken;

            // ソート順プロパティ設定
            instance.PageHeaderSortOderTitle = "";

            // 帳票出力設定情報取得 
            PrtOutSet prtOutSet;
            string message;
            int st = EstimateListAcs.ReadPrtOutSet( out prtOutSet, out message );
            if ( st != 0 )
            {
                throw new StockMoveException( message, status );
            }



            // 抽出条件ヘッダ出力区分
            instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

            // 抽出条件編集処理
            StringCollection extraInfomations;
            this.MakeExtarCondition( out extraInfomations );

            instance.ExtraConditions = extraInfomations;

            // フッタ出力区分
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // フッタ出力メッセージ
            StringCollection footers = new StringCollection();
            footers.Add( prtOutSet.PrintFooter1 );
            footers.Add( prtOutSet.PrintFooter2 );

            instance.PageFooters = footers;

            // 印刷情報オブジェクト
            instance.PrintInfo = this._printInfo;

            // ヘッダーサブタイトル
            object[] titleObj = new object[] { "見積確認表" };
            instance.PageHeaderSubtitle = string.Format( "{0}", titleObj );

            // その他データ
            // Todo:移動元とか渡す？抽出条件渡るからいいか？
            instance.OtherDataList = null;

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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private void MakeExtarCondition ( out StringCollection extraConditions )
        {
            // 2008.08.01 30413 犬飼 書式変更 >>>>>>START
            //const string dateFormat = "yyyy年MM月dd日";
            const string dateFormat = "yyyy/MM/dd";
            // 2008.08.01 30413 犬飼 書式変更 <<<<<<END
            
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();
            string target = "";
            string stTarget = string.Empty;
            string edTarget = string.Empty;
            
            // 2008.08.01 30413 犬飼 見積日を先に印字 >>>>>>START
            //-------------------------------------------------------------------------------------------------------------------
            // 見積日

            // 開始･終了のいずれかが入力されていれば印字
            if ((this._estimateListCndtn.St_SalesDate != DateTime.MinValue) || (this._estimateListCndtn.Ed_SalesDate != DateTime.MinValue))
            {
                // 開始
                if (this._estimateListCndtn.St_SalesDate != DateTime.MinValue)
                {
                    stTarget = this._estimateListCndtn.St_SalesDate.ToString(dateFormat);
                }
                else
                {
                    stTarget = ct_Extr_Top;
                }
                // 終了
                if (this._estimateListCndtn.Ed_SalesDate != DateTime.MinValue)
                {
                    edTarget = this._estimateListCndtn.Ed_SalesDate.ToString(dateFormat);
                }
                else
                {
                    edTarget = ct_Extr_End;
                }
                this.EditCondition(ref addConditions, string.Format("見積日" + ct_RangeConst, stTarget, edTarget));
            }
            // 2008.08.01 30413 犬飼 見積日を先に印字 <<<<<<END
            
            //-------------------------------------------------------------------------------------------------------------------
            // 入力日
            // 開始･終了のいずれかが入力されていれば印字
            if ( ( this._estimateListCndtn.St_SearchSlipDate != DateTime.MinValue ) || ( this._estimateListCndtn.Ed_SearchSlipDate != DateTime.MinValue ) )
            {
                // 開始
                if ( this._estimateListCndtn.St_SearchSlipDate != DateTime.MinValue )
                {
                    stTarget = this._estimateListCndtn.St_SearchSlipDate.ToString(dateFormat);
                }
                else
                {
                    stTarget = ct_Extr_Top;
                }
                // 終了
                if ( this._estimateListCndtn.Ed_SearchSlipDate != DateTime.MinValue )
                {
                    edTarget = this._estimateListCndtn.Ed_SearchSlipDate.ToString(dateFormat);
                }
                else
                {
                    edTarget = ct_Extr_End;
                }
                this.EditCondition(ref addConditions, string.Format("入力日" + ct_RangeConst, stTarget, edTarget));
            }

            // 2008.08.01 30413 犬飼 見積日を先に印字 >>>>>>START
            ////-------------------------------------------------------------------------------------------------------------------
            //// 見積日

            //// 開始･終了のいずれかが入力されていれば印字
            //if ( (this._estimateListCndtn.St_SalesDate != DateTime.MinValue) || (this._estimateListCndtn.Ed_SalesDate != DateTime.MinValue) )
            //{
            //    // 開始
            //    if ( this._estimateListCndtn.St_SalesDate != DateTime.MinValue )
            //    {
            //        stDate = this._estimateListCndtn.St_SalesDate.ToString( dateFormat );
            //    }
            //    else
            //    {
            //        stDate = ct_Extr_Top;
            //    }
            //    // 終了
            //    if ( this._estimateListCndtn.Ed_SalesDate != DateTime.MinValue )
            //    {
            //        edDate = this._estimateListCndtn.Ed_SalesDate.ToString( dateFormat );
            //    }
            //    else
            //    {
            //        edDate = ct_Extr_End;
            //    }
            //    this.EditCondition( ref addConditions, string.Format( "見積日" + ct_RangeConst, stDate, edDate ) );
            //}
            // 2008.08.01 30413 犬飼 見積日を先に印字 <<<<<<END

            // 2008.09.01 30413 犬飼 担当者、得意先の順で印字 >>>>>>START
            ////----------------------------------------------------------------------------------------------------------------
            //// 得意先
            //// 開始･終了のいずれかが入力されていれば印字
            //if ( this._estimateListCndtn.St_CustomerCode != 0 || this._estimateListCndtn.Ed_CustomerCode != 999999999 )
            //{
            //    string stCode = this._estimateListCndtn.St_CustomerCode.ToString();
            //    string edCode = this._estimateListCndtn.Ed_CustomerCode.ToString();
            //    if ( stCode == string.Empty ) stCode = ct_Extr_Top;
            //    if ( edCode == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "得意先" + ct_RangeConst, stCode, edCode ) );
            //}

            ////-------------------------------------------------------------------------------------------------------------------
            //// 担当者 
            //// 開始･終了のいずれかが入力されていれば印字
            //if ( this._estimateListCndtn.St_SalesEmployeeCd != string.Empty || this._estimateListCndtn.Ed_SalesEmployeeCd != string.Empty )
            //{
            //    string stCode = this._estimateListCndtn.St_SalesEmployeeCd;
            //    string edCode = this._estimateListCndtn.Ed_SalesEmployeeCd;
            //    if ( stCode == string.Empty ) stCode = ct_Extr_Top;
            //    if ( edCode == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "担当者" + ct_RangeConst, stCode, edCode ) );
            //}


            ////----------------------------------------------------------------------------------------------------------------
            //// 得意先
            //if ((this._estimateListCndtn.St_CustomerCode == 0) && (this._estimateListCndtn.Ed_CustomerCode != 999999999))
            //{
            //    target = string.Format("得意先" + ct_RangeConst, ct_Extr_Top, this._estimateListCndtn.Ed_CustomerCode.ToString());
            //}

            //if ((this._estimateListCndtn.St_CustomerCode > 0) && (this._estimateListCndtn.Ed_CustomerCode == 999999999))
            //{
            //    target = string.Format("得意先" + ct_RangeConst, this._estimateListCndtn.St_CustomerCode.ToString(), ct_Extr_End);
            //}

            //if ((this._estimateListCndtn.St_CustomerCode > 0) && (this._estimateListCndtn.Ed_CustomerCode != 999999999))
            //{
            //    target = string.Format("得意先" + ct_RangeConst, this._estimateListCndtn.St_CustomerCode.ToString(), this._estimateListCndtn.Ed_CustomerCode.ToString());
            //}
            //this.EditCondition(ref addConditions, target);
            // 2008.09.01 30413 犬飼 担当者、得意先の順で印字 <<<<<<END

            // 2008.09.26 30413 犬飼 抽出条件の出力制御を変更 >>>>>>START
            // 担当者
            if ((this._estimateListCndtn.St_SalesEmployeeCd == "") && (this._estimateListCndtn.Ed_SalesEmployeeCd != ""))
            {
                stTarget = ct_Extr_Top;
                edTarget = this._estimateListCndtn.Ed_SalesEmployeeCd;
                this.EditCondition(ref addConditions, string.Format("担当者" + ct_RangeConst, stTarget, edTarget));
            }
            else if ((this._estimateListCndtn.St_SalesEmployeeCd != "") && (this._estimateListCndtn.Ed_SalesEmployeeCd == ""))
            {
                stTarget = this._estimateListCndtn.St_SalesEmployeeCd;
                edTarget = ct_Extr_End;
                this.EditCondition(ref addConditions, string.Format("担当者" + ct_RangeConst, stTarget, edTarget));
            }
            else if ((this._estimateListCndtn.St_SalesEmployeeCd != "") && (this._estimateListCndtn.Ed_SalesEmployeeCd != ""))
            {
                stTarget = this._estimateListCndtn.St_SalesEmployeeCd;
                edTarget = this._estimateListCndtn.Ed_SalesEmployeeCd;
                this.EditCondition(ref addConditions, string.Format("担当者" + ct_RangeConst, stTarget, edTarget));
            }

            // 得意先
            if ((this._estimateListCndtn.St_CustomerCode == 0) && (this._estimateListCndtn.Ed_CustomerCode != 0))
            {
                stTarget = ct_Extr_Top;
                edTarget = this._estimateListCndtn.Ed_CustomerCode.ToString("d08");
                this.EditCondition(ref addConditions, string.Format("得意先" + ct_RangeConst, stTarget, edTarget));
            }
            else if ((this._estimateListCndtn.St_CustomerCode > 0) && (this._estimateListCndtn.Ed_CustomerCode == 0))
            {
                stTarget = this._estimateListCndtn.St_CustomerCode.ToString("d08");
                edTarget = ct_Extr_End;
                this.EditCondition(ref addConditions, string.Format("得意先" + ct_RangeConst, stTarget, edTarget));
            }
            else if ((this._estimateListCndtn.St_CustomerCode > 0) && (this._estimateListCndtn.Ed_CustomerCode != 0))
            {
                stTarget = this._estimateListCndtn.St_CustomerCode.ToString("d08");
                edTarget = this._estimateListCndtn.Ed_CustomerCode.ToString("d08");
                this.EditCondition(ref addConditions, string.Format("得意先" + ct_RangeConst, stTarget, edTarget));
            }
            // 2008.09.26 30413 犬飼 抽出条件の出力制御を変更 <<<<<<END

            // 2008.08.01 30413 犬飼 見積タイプ、発行タイプを追加 >>>>>>START
            // 見積タイプ
            switch (this._estimateListCndtn.EstimateDivide)
            {
                case -1:
                    {
                        target = "見積タイプ： 全て";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 0:
                    {
                        target = "見積タイプ： 売上入力分";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 1:
                    {
                        target = "見積タイプ： 検索見積分";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
            }

            // 発行タイプ
            switch (this._estimateListCndtn.PrintDiv)
            {
                case -1:
                    {
                        target = "発行タイプ： 全て";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 0:
                    {
                        target = "発行タイプ： 見積計上";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
            }
            // 2008.08.01 30413 犬飼 見積タイプを追加 <<<<<<END
            
            // 追加
            foreach ( string exCondStr in addConditions )
            {
                extraConditions.Add( exCondStr );
            }
        }
        #endregion

        #region ◎ 抽出範囲文字列作成
        /// <summary>
        /// 抽出範囲文字列作成
        /// </summary>
        /// <returns>作成文字列</returns>
        /// <remarks>
        /// <br>Note       : 抽出範囲文字列を作成します</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private string GetConditionRange ( string title, string startString, string endString )
        {
            string result = "";
            if ( ( startString != "" ) || ( endString != "" ) )
            {
                string start = ct_Extr_Top;
                string end = ct_Extr_End;
                if ( startString != "" ) start = startString;
                if ( endString != "" ) end = endString;
                result = String.Format( title + ct_RangeConst, start, end );
            }
            return result;
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private void EditCondition ( ref StringCollection editArea, string target )
        {
            bool isEdit = false;

            // 2008.09.26 30413 犬飼 抽出条件を適宜改行するように修正 >>>>>>START
            // 編集対象文字バイト数算出
            int targetByte = TStrConv.SizeCountSJIS(target);

            //for ( int i = 0; i < editArea.Count; i++ )
            //{
            //    int areaByte = 0;

            //    // 格納エリアのバイト数算出
            //    if ( editArea[i] != null )
            //    {
            //        areaByte = TStrConv.SizeCountSJIS( editArea[i] );
            //    }

            //    if ( ( areaByte + targetByte + 2 ) <= 190 )
            //    {
            //        isEdit = true;

            //        // 全角スペースを挿入
            //        if ( editArea[i] != null ) editArea[i] += ct_Space;

            //        editArea[i] += target;
            //        break;
            //    }
            //}

            int index = 0;
            int areaByte = 0;

            // 追加するエリアのインデックスを取得
            if (editArea.Count != 0)
            {
                index = editArea.Count - 1;

                // 格納エリアのバイト数算出
                if (editArea[index] != null)
                {
                    areaByte = TStrConv.SizeCountSJIS(editArea[index]);
                }

                if ((areaByte + targetByte + 2) >= 140)
                {
                    // 改行
                    editArea[index] += "\n";
                }
                else
                {
                    isEdit = true;

                    // 全角スペースを挿入
                    if (editArea[index] != null) editArea[index] += ct_Space;

                    editArea[index] += target;
                }
            }
            // 2008.09.17 30413 犬飼 抽出条件を適宜改行するように修正 <<<<<<END

            // 新規編集エリア作成
            if ( !isEdit )
            {
                editArea.Add( target );
            }
        }
        #endregion
        #endregion ◆ レポートフォーム設定関連

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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private DialogResult MsgDispProc ( emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton )
        {
            // 2008.08.01 30413 犬飼 アセンブリIDを修正 >>>>>>START
            //return TMsgDisp.Show(iLevel, "MAZAI02032P", iMsg, iSt, iButton, iDefButton);
            return TMsgDisp.Show(iLevel, "DCMIT02102P", iMsg, iSt, iButton, iDefButton);
            // 2008.08.01 30413 犬飼 アセンブリIDを修正 >>>>>>START
        }

        #endregion
        #endregion
    }
}
