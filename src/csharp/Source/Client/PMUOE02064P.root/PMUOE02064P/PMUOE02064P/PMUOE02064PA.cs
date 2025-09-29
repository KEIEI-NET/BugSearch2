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
    /// 入庫予定表印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入庫予定表の印刷を行う。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date	   : 2008.12.03</br>
    /// <br></br>
    /// </remarks>
    public class PMUOE02064PA : IPrintProc
    {
        #region ■ Constructor
		/// <summary>
		/// 入庫予定表印刷クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入庫予定表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 30413 犬飼</br>
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
		public PMUOE02064PA()
		{
		}

		/// <summary>
		/// 入庫予定表印刷クラスコンストラクタ
		/// </summary>
		/// <param name="printInfo">印刷情報オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 入庫予定表印刷クラスのインスタンスの作成を行う。</br>
		/// <br>Programmer : 30413 犬飼</br>
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
        public PMUOE02064PA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._enterSchOrderCndtn = this._printInfo.jyoken as EnterSchOrderCndtn;
		}
		#endregion ■ Constructor

        #region ■ Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "　";
        private const string ct_Extr_Top = "最初から";
        private const string ct_Extr_End = "最後まで";
        private const string ct_RangeConst = "：{0} ～ {1}";
        private const string ct_DateFormat = "YYYY/MM/DD";
        #endregion ■ Pricate Const

        #region ■ Private Member
        private SFCMN06002C _printInfo;					    // 印刷情報クラス
        private EnterSchOrderCndtn _enterSchOrderCndtn;	// 抽出条件クラス
        #endregion ■ Private Member

        private string CT_Sort0_Odr = "SectionCode, WarehouseCode, WarehouseShelfNo";               // 拠点+倉庫+棚番
        private string CT_Sort1_Odr = "SectionCode, WarehouseCode, GoodsNo"; 　                     // 拠点+倉庫+品番
        private string CT_Sort2_Odr = "SectionCode, WarehouseCode, SupplierCd, GoodsNo"; 　         // 拠点+倉庫+仕入先+品番
        private string CT_Sort3_Odr = "SectionCode, WarehouseCode, SupplierCd, SlipNo_Print";       // 拠点+倉庫+仕入先+仕入伝票番号
        
        #region ■ Exception Class
        /// <summary> 例外クラス </summary>
        private class EnterSchOrderMainException : ApplicationException
        {
            private int _status;
            #region ◆ Constructor
            /// <summary>
            /// 例外クラスコンストラクタ
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <param name="status">ステータス</param>
            public EnterSchOrderMainException(string message, int status)
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date	   : 2008.12.03</br>
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date	   : 2008.12.03</br>
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
                prtRpt.DataSource = (DataSet)this._printInfo.rdData;
                prtRpt.DataMember = EnterSchResult.Col_Tbl_Result_EnterSch;

                // 印刷データ取得
                DataSet ds = (DataSet)this._printInfo.rdData;
                DataView dv = new DataView();
                dv.Table = ds.Tables[EnterSchResult.Col_Tbl_Result_EnterSch];

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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date	   : 2008.12.03</br>
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date	   : 2008.12.03</br>
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
                throw new EnterSchOrderMainException(asmname + "が存在しません。", -1);
            }
            catch (System.Exception er)
            {
                throw new EnterSchOrderMainException(er.Message, -1);
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
        private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
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
            //commonInfo.PrintMax = 0;
            int maxCount = 0;
            foreach (object obj in (this._printInfo.rdData as DataSet).Tables)
            {
                if (obj is DataTable && (obj as DataTable).TableName == EnterSchResult.Col_Tbl_Result_EnterSch)
                {
                    maxCount = (obj as DataTable).Rows.Count;
                    break;
                }
            }
            commonInfo.PrintMax = maxCount;

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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // 印刷条件取得
            EnterSchOrderCndtn extraInfo = (EnterSchOrderCndtn)this._printInfo.jyoken;

            // ソート順プロパティ設定
            instance.PageHeaderSortOderTitle = GetSortOrderName(extraInfo);

            // 帳票出力設定情報取得 
            PrtOutSet prtOutSet;
            string message;
            int st = EnterSchOrderAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new EnterSchOrderMainException(message, status);
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
            instance.PageHeaderSubtitle = this._enterSchOrderCndtn.PrintDivName;

            // その他データ
            ArrayList otherDataList = new ArrayList();
            instance.OtherDataList = otherDataList;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        #endregion

        #region ◎ ソート順名称取得
        /// <summary>
        /// ソート順名称取得
        /// </summary>
        /// <param name="rsltInfo_CollectPlan">抽出条件</param>
        /// <returns>ソート順名称</returns>
        /// <remarks>
        /// <br>Note       : ソート順名称を取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
        private string GetSortOrderName(EnterSchOrderCndtn enterSchOrderCndtn)
        {
            string sortOrderName = string.Empty;

            if (enterSchOrderCndtn.SortOrderDiv == 0)
            {
                sortOrderName = "[倉庫・棚番順]";
            }
            else if (enterSchOrderCndtn.SortOrderDiv == 1)
            {
                sortOrderName = "[倉庫・品番順]";
            }
            else if (enterSchOrderCndtn.SortOrderDiv == 2)
            {
                sortOrderName = "[倉庫・仕入先・品番順]";
            }
            else if (enterSchOrderCndtn.SortOrderDiv == 3)
            {
                sortOrderName = "[倉庫・仕入先・仕入伝票番号順]";
            }
            
            return sortOrderName;
        }
        #endregion

        #region ◎ 抽出条件出力情報作成
        /// <summary>
        /// 抽出条件出力情報作成
        /// </summary>
        /// <param name="extraConditions">作成後抽出条件コレクション</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を作成する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();

            StringCollection addConditions = new StringCollection();

            // 発注日
            if ((this._enterSchOrderCndtn.St_ReceiveDate != DateTime.MinValue) || (this._enterSchOrderCndtn.Ed_ReceiveDate != DateTime.MinValue))
            {
                string st_ReceiveDate = string.Empty;
                string ed_ReceiveDate = string.Empty;
                // 開始
                if (this._enterSchOrderCndtn.St_ReceiveDate != DateTime.MinValue)
                    st_ReceiveDate = TDateTime.DateTimeToString(ct_DateFormat, this._enterSchOrderCndtn.St_ReceiveDate);
                else
                    st_ReceiveDate = ct_Extr_Top;
                // 終了
                if (this._enterSchOrderCndtn.Ed_ReceiveDate != DateTime.MinValue)
                    ed_ReceiveDate = TDateTime.DateTimeToString(ct_DateFormat, this._enterSchOrderCndtn.Ed_ReceiveDate);
                else
                    ed_ReceiveDate = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("発注日" + ct_RangeConst, st_ReceiveDate, ed_ReceiveDate));
            }            

            // 印刷タイプ
            if (this._enterSchOrderCndtn.PrintTypeCndtn == 0)
            {
                this.EditCondition(ref addConditions, "印刷タイプ：入庫分のみ印刷する");
            }
            else if (this._enterSchOrderCndtn.PrintTypeCndtn == 1)
            {
                this.EditCondition(ref addConditions, "印刷タイプ：ﾒｰｶｰﾌｫﾛｰ分のみ印刷する");
            }
            else
            {
                this.EditCondition(ref addConditions, "印刷タイプ：欠品分のみ印刷する");
            }

            // 発注先
            if (this._enterSchOrderCndtn.SupplierExtra == 0)
            {
                // 範囲
                if (this._enterSchOrderCndtn.St_UOESupplierCd != 0 || this._enterSchOrderCndtn.Ed_UOESupplierCd != 0)
                {
                    string startCode = "";
                    if (this._enterSchOrderCndtn.St_UOESupplierCd == 0)
                    {
                        startCode = ct_Extr_Top;
                    }
                    else
                    {
                        startCode = this._enterSchOrderCndtn.St_UOESupplierCd.ToString("d06");
                    }

                    string endCode = "";
                    if (this._enterSchOrderCndtn.Ed_UOESupplierCd == 0)
                    {
                        endCode = ct_Extr_End;
                    }
                    else
                    {
                        endCode = this._enterSchOrderCndtn.Ed_UOESupplierCd.ToString("d06");
                    }
                    this.EditCondition(ref addConditions, string.Format("発注先" + ct_RangeConst, startCode, endCode));
                }
            }
            else
            {
                string unitCode = "";
                // 単独
                foreach (int uoeSupplierCd in this._enterSchOrderCndtn.UOESupplierCds)
                {
                    if (unitCode == "")
                    {
                        unitCode = uoeSupplierCd.ToString("d06");
                    }
                    else
                    {
                        unitCode += " " + uoeSupplierCd.ToString("d06");
                    }
                }
                this.EditCondition(ref addConditions, string.Format("発注先：{0}", unitCode));
            }

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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
        private void EditCondition(ref StringCollection editArea, string target)
        {
            bool isEdit = false;

            // 編集対象文字バイト数算出
            int targetByte = TStrConv.SizeCountSJIS(target);

            // 2008.11.20 30413 犬飼 抽出条件を適宜改行するように修正 >>>>>>START
            //for (int i = 0; i < editArea.Count; i++)
            //{
            //    int areaByte = 0;

            //    // 格納エリアのバイト数算出
            //    if (editArea[i] != null)
            //    {
            //        areaByte = TStrConv.SizeCountSJIS(editArea[i]);
            //    }

            //    if ((areaByte + targetByte + 2) <= 190)
            //    {
            //        isEdit = true;

            //        // 全角スペースを挿入
            //        if (editArea[i] != null) editArea[i] += ct_Space;

            //        editArea[i]  += target;
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
            // 2008.11.20 30413 犬飼 抽出条件を適宜改行するように修正 <<<<<<END

            // 新規編集エリア作成
            if (!isEdit)
            {
                editArea.Add(target);
            }
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
        private string GetPrintOderQuerry()
        {
            string oderQuerry = "";

            switch (this._enterSchOrderCndtn.SortOrderDiv)
            {
                case 0:     // 倉庫・棚番
                    {
                        oderQuerry = CT_Sort0_Odr;
                        break;
                    }
                case 1:     // 倉庫・品番
                    {
                        oderQuerry = CT_Sort1_Odr;
                        break;
                    }
                case 2:     // 倉庫・仕入先・品番
                    {
                        oderQuerry = CT_Sort2_Odr;
                        break;
                    }
                case 3:     // 倉庫・仕入先・仕入伝票番号
                    {
                        oderQuerry = CT_Sort3_Odr;
                        break;
                    }
            }

            return oderQuerry;
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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMUOE02064P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion
        #endregion
    }
}
