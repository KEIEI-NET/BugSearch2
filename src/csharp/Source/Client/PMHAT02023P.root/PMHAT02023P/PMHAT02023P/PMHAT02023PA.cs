//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定マスタリスト印刷クラス
// プログラム概要   : 発注点設定マスタリスト印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/04/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using System.Data;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 発注点設定マスタリスト印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定マスタリスト印刷を行う。</br>
    /// <br>Programmer : 呉元嘯</br>                                   
    /// <br>Date       : 2009.04.02</br>                                       
    /// </remarks>
    public class PMHAT02023PA
    {
        #region ■ Private Members
        private SFCMN00299CA _waitDialog = new SFCMN00299CA();

        // 印刷情報クラス
        private SFCMN06002C _printInfo;

        // namespace
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";

        // 検索条件
        private OrderSetMasListPara _orderSetMasListPara;

        // Space
        private const string ct_Space = "　";

        // 文字列TOP
        private const string STR_TOP = "最初から";

        // 文字列END
        private const string STR_END = "最後まで";
        #endregion

        #region ■ コンストラクタ
        /// <summary>
        /// 発注点設定マスタリストクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        public PMHAT02023PA()
        {

        }
        #endregion

        #region ■ コンストラクタ
        /// <summary>
        /// 発注点設定マスタリストクラスコンストラクタ
        /// </summary>
        /// <param name="printInfo">印刷情報オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 発注点設定マスタリスト印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        public PMHAT02023PA(object printInfo)
        {
            _printInfo = printInfo as SFCMN06002C;

            _orderSetMasListPara = this._printInfo.jyoken as OrderSetMasListPara;
        }
        #endregion

        #region ■ 印刷処理
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 印刷を開始する。</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        public int StartPrint()
        {
            return PrintMain();
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を行う。</br>
        /// <br>Programmer : 呉元嘯</br> 
        /// <br>Date       : 2009.04.02</br>
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

                // 各種プロパティ設定
                status = this.SettingProperty(ref prtRpt);
                if (status != 0)
                {
                    return status;
                }

                // データソース設定
                prtRpt.DataSource = (DataSet)this._printInfo.rdData;

                prtRpt.DataMember = PMHAT02025EA.Tbl_OrderSetMasListReportData;

                // 印刷共通情報プロパティ設定
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                this.SetPrintCommonInfo(out commonInfo);

                //プレビュー有無				
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
        #endregion

        #region ■ 各種ActiveReport帳票インスタンス作成処理
        /// <summary>
        /// 各種ActiveReport帳票インスタンス作成処理
        /// </summary>
        /// <param name="rptObj">インスタンス化された帳票フォームクラス</param>
        /// <param name="prpid">帳票フォームID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
        {
            // 印刷フォームクラスインスタンス作成
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(),
                typeof(DataDynamics.ActiveReports.ActiveReport3));
        }
        #endregion

        #region ■ レポートアセンブリインスタンス化処理
        /// <summary>
        /// レポートアセンブリインスタンス化処理
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <param name="type">実装するクラス型</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2009.04.02</br>
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
                throw new SuplierPayMainException(asmname + "が存在しません。", -1);
            }
            catch (System.Exception er)
            {
                throw new SuplierPayMainException(er.Message, -1);
            }
            return obj;
        }
        #endregion

        #region ■ Exception Class
        /// <summary>
        /// 例外クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 例外クラスコンストラクタの作成を行う。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private class SuplierPayMainException : ApplicationException
        {
            private int _status;
            #region ◆ Constructor
            /// <summary>
            /// 例外クラスコンストラクタ
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <param name="status">ステータス</param>
            /// <remarks>
            /// <br>Note		: 例外クラスコンストラクタの作成を行う。</br>
            /// <br>Programmer	: 呉元嘯</br>
            /// <br>Date		: 2009.04.02</br>
            /// </remarks>
            public SuplierPayMainException(string message, int status)
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

        #region ■ メッセージ表示処理
        /// <summary>
        /// メッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">ステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">デフォルトフォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : 出力件数の設定を行います。</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMHAT02023P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion

        #region ■ プロパティ設定処理
        /// <summary>
        /// 各種プロパティ設定処理
        /// </summary>
        /// <param name="rpt">インスタンス化された帳票フォームクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 各種プロパティを設定します。</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReportインターフェースにキャスト
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // 印刷条件取得
            OrderSetMasListPara extraInfo = (OrderSetMasListPara)this._printInfo.jyoken;

            // 抽出条件編集処理
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;
            

            // 印刷情報オブジェクト
            instance.PrintInfo = this._printInfo;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }
        #endregion

        #region ■ 印刷画面共通情報設定処理
        /// <summary>
        /// 印刷画面共通情報設定処理
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷画面共通条件の設定を行います。</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2009.04.02</br>
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

            // 一番印刷数
            DataSet ds = (DataSet)this._printInfo.rdData;
            commonInfo.PrintMax = ds.Tables[PMHAT02025EA.Tbl_OrderSetMasListReportData].Rows.Count;

            // SAVE PATH
            status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
            this._printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = this._printInfo.pdftemppath;

            // 上余白
            commonInfo.MarginsTop = this._printInfo.py;
            // 左余白
            commonInfo.MarginsLeft = this._printInfo.px;
        }
        #endregion

        #region ■ 抽出条件出力情報作成処理
        /// <summary>
        /// 抽出条件出力情報作成処理
        /// </summary>
        /// <param name="extraConditions">作成後抽出条件コレクション</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を作成する。</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();

            // 発行タイプ
            string printType = GetString(this._orderSetMasListPara.PrintType);
            this.EditCondition(ref extraConditions, string.Format("発行タイプ：{0}", printType));

             // 設定コード
            string startSetCode = string.Empty;
            string endSetCode = string.Empty;

            if (String.IsNullOrEmpty(this._orderSetMasListPara.StartSetCode))
            {
                startSetCode = STR_TOP;
            }
            else
            {
                startSetCode = this._orderSetMasListPara.StartSetCode;
            }

            if (String.IsNullOrEmpty(this._orderSetMasListPara.EndSetCode))
            {
                endSetCode = STR_END;
            }
            else
            {
                endSetCode = this._orderSetMasListPara.EndSetCode.ToString();
            }

            if (!STR_TOP.Equals(startSetCode) || !STR_END.Equals(endSetCode))
            {
                this.EditCondition(ref extraConditions, string.Format("設定コード：{0} ～ {1}", startSetCode, endSetCode));
            }


            // 倉庫コード
            string startWarehouseCode = string.Empty;
            string endWarehouseCode = string.Empty;

            if (string.IsNullOrEmpty(this._orderSetMasListPara.StartWarehouseCode))
            {
                startWarehouseCode = STR_TOP;
            }
            else
            {
                startWarehouseCode = this._orderSetMasListPara.StartWarehouseCode;
            }

            if (string.IsNullOrEmpty(this._orderSetMasListPara.EndWarehouseCode))
            {
                endWarehouseCode = STR_END;
            }
            else
            {
                endWarehouseCode = this._orderSetMasListPara.EndWarehouseCode;
            }

            if (!STR_TOP.Equals(startWarehouseCode) || !STR_END.Equals(endWarehouseCode))
            {
                this.EditCondition(ref extraConditions, string.Format("倉庫：{0} ～ {1}", startWarehouseCode, endWarehouseCode));
            }

            // 仕入先コード
            string startSupplierCd = string.Empty;
            string endSupplierCd = string.Empty;

            if (0 == this._orderSetMasListPara.StartSupplierCd)
            {
                startSupplierCd = STR_TOP;
            }
            else
            {
                startSupplierCd = this._orderSetMasListPara.StartSupplierCd.ToString("D6");
            }

            if (0 == this._orderSetMasListPara.EndSupplierCd)
            {
                endSupplierCd = STR_END;
            }
            else
            {
                endSupplierCd = this._orderSetMasListPara.EndSupplierCd.ToString("D6");
            }

            if (!STR_TOP.Equals(startSupplierCd) || !STR_END.Equals(endSupplierCd))
            {
                this.EditCondition(ref extraConditions, string.Format("仕入先：{0} ～ {1}", startSupplierCd, endSupplierCd));
            }


            // メーカーコード
            string startGoodsMakerCd = string.Empty;
            string endGoodsMakerCd = string.Empty;

            if (0 == this._orderSetMasListPara.StartGoodsMakerCd)
            {
                startGoodsMakerCd = STR_TOP;
            }
            else
            {
                startGoodsMakerCd = this._orderSetMasListPara.StartGoodsMakerCd.ToString("D4");
            }

            if (0 == this._orderSetMasListPara.EndGoodsMakerCd)
            {
                endGoodsMakerCd = STR_END;
            }
            else
            {
                endGoodsMakerCd = this._orderSetMasListPara.EndGoodsMakerCd.ToString("D4");
            }

            if (!STR_TOP.Equals(startGoodsMakerCd) || !STR_END.Equals(endGoodsMakerCd))
            {
                this.EditCondition(ref extraConditions, string.Format("ﾒｰｶｰ：{0} ～ {1}", startGoodsMakerCd, endGoodsMakerCd));
            }

            // 中分類コード
            string startGoodsMGroup = string.Empty;
            string endGoodsMGroup = string.Empty;

            if (0 == this._orderSetMasListPara.StartGoodsMGroup)
            {
                startGoodsMGroup = STR_TOP;
            }
            else
            {
                startGoodsMGroup = this._orderSetMasListPara.StartGoodsMGroup.ToString("D4");
            }

            if (0 == this._orderSetMasListPara.EndGoodsMGroup)
            {
                endGoodsMGroup = STR_END;
            }
            else
            {
                endGoodsMGroup = this._orderSetMasListPara.EndGoodsMGroup.ToString("D4");
            }

            if (!STR_TOP.Equals(startGoodsMGroup) || !STR_END.Equals(endGoodsMGroup))
            {
                this.EditCondition(ref extraConditions, string.Format("商品中分類：{0} ～ {1}", startGoodsMGroup, endGoodsMGroup));
            }

            // グループコード
            string startBLGroupCode = string.Empty;
            string endBLGroupCode = string.Empty;

            if (0 == this._orderSetMasListPara.StartBLGroupCode)
            {
                startBLGroupCode = STR_TOP;
            }
            else
            {
                startBLGroupCode = this._orderSetMasListPara.StartBLGroupCode.ToString("D5");
            }

            if (0 == this._orderSetMasListPara.EndBLGroupCode)
            {
                endBLGroupCode = STR_END;
            }
            else
            {
                endBLGroupCode = this._orderSetMasListPara.EndBLGroupCode.ToString("D5");
            }

            if (!STR_TOP.Equals(startBLGroupCode) || !STR_END.Equals(endBLGroupCode))
            {
                this.EditCondition(ref extraConditions, string.Format("ｸﾞﾙｰﾌﾟｺｰﾄﾞ：{0} ～ {1}", startBLGroupCode, endBLGroupCode));
            }

            //BLコード
            string startBLGoodsCode = string.Empty;
            string endBLGoodsCode = string.Empty;

            if (0 == this._orderSetMasListPara.StartBLGoodsCode)
            {
                startBLGoodsCode = STR_TOP;
            }
            else
            {
                startBLGoodsCode = this._orderSetMasListPara.StartBLGoodsCode.ToString("D5");
            }

            if (0 == this._orderSetMasListPara.EndBLGoodsCode)
            {
                endBLGoodsCode = STR_END;
            }
            else
            {
                endBLGoodsCode = this._orderSetMasListPara.EndBLGoodsCode.ToString("D5");
            }

            if (!STR_TOP.Equals(startBLGoodsCode) || !STR_END.Equals(endBLGoodsCode))
            {
                this.EditCondition(ref extraConditions, string.Format("BLｺｰﾄﾞ：{0} ～ {1}", startBLGoodsCode, endBLGoodsCode));
            }

        }

        /// <summary>
        /// IntToString
        /// </summary>
        /// <param name="p">発行タイプ int</param>
        /// <returns>発行タイプ string</returns>
        /// <remarks>
        /// <br>Note       : 発行タイプを取得します。</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2008.04.22</br>
        /// </remarks>
        private string GetString(int p)
        {
            string printType = String.Empty;
            switch (p)
            {
                case (0):
                    {
                        // 通常
                        printType = "通常";
                    }
                    break;
                case (1):
                    {
                        // 削除
                        printType = "削除";
                    }
                    break;
                case (2):
                    {
                        // 全て
                        printType = "全て";
                    }
                    break;
            }
            return printType;
        }
        #endregion

        #region ■ 抽出条件文字列編集処理
        /// <summary>
        /// 抽出条件文字列編集処理
        /// </summary>
        /// <param name="editArea">格納エリア</param>
        /// <param name="target">対象文字列</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を編集します。</br>
        /// <br>Programmer : 呉元嘯</br>                                   
        /// <br>Date       : 2008.04.02</br>
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

        #region ■ Public Members
        /// <summary>  印刷情報プロパティ</summary>
        /// <value>Printinfo</value>               
        /// <remarks> 印刷情報取得又はセットプロパティ </remarks> 
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion
    }
}
