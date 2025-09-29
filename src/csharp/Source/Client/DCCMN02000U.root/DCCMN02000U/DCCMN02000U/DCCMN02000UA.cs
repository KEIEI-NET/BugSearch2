using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 伝票印刷ＵＩ呼出制御
    /// </summary>
    /// <remarks>
    /// <br>Note         : 伝票印刷確認画面の呼び出し制御を行うクラスです。</br>
    /// <br>               （※UIでの組み込み時、異なる伝票タイプでも１回のコールで実行できるようにする為、実装）</br>
    /// <br>Programmer   : 22018 鈴木　正臣</br>
    /// <br>Date         : 2008.02.25</br>
    /// <br>-----------------------------------------------------------------</br>
    /// <br>Update Note  : 2008.05.29  22018 鈴木 正臣</br>
    /// <br>             : ①PM.NS向け変更。全体的に大幅に変更。</br>
    /// <br>Update Note  : 2009.07.16  20056 對馬 大輔</br>
    /// <br>             : サーバーへ配置するクライアントアセンブリ対応</br>
    /// <br>             : ①ログイン情報取得方法変更</br>
    /// <br>             : ②サービス起動プロパティ追加</br>
    /// <br>             : ③ウインドウ表示制限追加</br>
    /// <br>Update Note  : 2010/07/30  20056 對馬 大輔</br>
    /// <br>             : SCMクライアント受信対応 </br>
    /// <br>             : サービス起動(サーバー)が無くなった為、_isService を常に0とする </br>
    /// <br>Update Note  : 2010/08/09  周正雨</br>
    /// <br>             : PCCUOE </br>
    /// <br>             : リモート伝票発行</br>
    /// <br>Update Note  : 2010/09/15  周正雨</br>
    /// <br>             : Redmine#24942 </br>
    /// <br>             : PM側からの伝票発行する時、 </br>
    /// <br>             : 「売上全体設定.売上伝票発行区分=しない」の時にSF側リモート伝票を発行する</br>
    /// <br>Update Note  : 2010/09/17  周正雨</br>
    /// <br>             : Redmine#25225 </br>
    /// <br>             : 赤伝発行時はリモ伝の発行はしない</br>
    /// <br>Update Note  : 2010/10/17  wangqx</br>
    /// <br>             : Redmine#25529 </br>
    /// <br>             : PCC問合せ場合見積書印刷チィックを追加する</br>
    /// <br>Update Note  : 2011/10/21  22018  鈴木 正臣</br>
    /// <br>             : SCM得意先で売上伝票登録時に伝票が印刷されない不具合の修正</br>
    /// <br>Update Note  : 2011/11/22  葛中華</br>
    /// <br>             : Redmine#7883 ゼロ伝のみの時の不具合について</br>
    /// <br>Update Note  : 2012/01/18  duzg</br>
    /// <br>             : Redmine#28011 赤伝発行時に印刷されない</br>
    /// <br>Update Note  : 2012/12/13  30744 湯上 千加子</br>
    /// <br>             : SCM障害№10352 PCCforNSの時もリモート伝票を発行できるようにする</br>
    /// <br>Update Note  : 2013/06/17  zhubj</br>
    /// <br>             : Redmine #36594</br>
    /// <br>             : №10542 SCM</br>
    /// <br>Update Note  : 2013/06/21 脇田 靖之
    /// <br>             : SCM障害対応 BLPリモート伝票が発行されない障害の修正
    /// <br>Update Note  : 2013/07/28  zhubj</br>
    /// <br>             : Redmine #36594</br>
    /// <br>             : №10542 SCM NO.10の対応</br>
    /// <br>Update Note  : 2013/09/13  吉岡</br>
    /// <br>             : PM.NS仕掛一覧№2137</br>
    /// <br>Update Note  : 2013/09/19  30744 湯上</br>
    /// <br>             : Redmine #40342</br>
    /// <br>             : リモート伝票発行時エラー対応</br>
    /// <br>Update Note  : 2013/09/20  吉岡</br>
    /// <br>             : ランテルUOE送信処理 速度遅延対応</br>
    /// <br>Update Note  : 2014/12/05  宮本 利明</br>
    /// <br>             : 仕掛一覧№2295(№1725)対応</br>
    /// <br>             : 印刷処理時に登録したイベントハンドラを、処理終了後に全て削除するように修正</br>
    /// <br>             : </br>
    /// <br>Update Note  : 2013/10/30  30744 湯上</br>
    /// <br>             : SCM仕掛一覧№10614対応</br>
    /// </remarks>
    public class DCCMN02000UA
    {
        # region [private フィールド]
        /// <summary>伝票印刷アクセスクラス</summary>
        private SlipPrintAcs _slipPrintAcs;
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>伝票印刷ステータス</summary>
        private SlipPrintStatus _slipPrintState;
        // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>サービス起動フラグ(0:通常 1:サービス起動)</summary> 
        private int _isService = 0;
        // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
        /// <summary>
        /// リモート伝票発行するか
        /// </summary>
        private bool _IsRmSlpPrt;
        /// <summary>PCCUOE自動回答起動フラグ(0:通常 1:PCCUOE自動回答起動)</summary> 
        private int _isAutoAns = 0;
        //ＳＣＭ全体設定の売上伝票印刷区分
        int _SCMTotalSettingSalesSlipPrtDiv;
        // add by zhouzy for PCCUOEリモート伝票発行 20110811  end
        // ADD 2013/09/19 Redmine#40342対応 --------------------------------------------------->>>>>
        // タブレット起動区分
        private bool _isTablet = false;
        // ADD 2013/09/19 Redmine#40342対応 ---------------------------------------------------<<<<<
        // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 複数伝票分のデータリスト
        /// </summary>
        private List<List<object>> _printDataList;
        // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        # endregion

        # region [コンストラクタ]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DCCMN02000UA()
        {
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _slipPrintAcs = new SlipPrintAcs(_enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            _slipPrintState = SlipPrintStatus.BeforeExecute;
        }
        // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// コンストラクタ(ログイン拠点を使用しない)
        /// </summary>
        /// <param name="sectionCode"></param>
        public DCCMN02000UA(string sectionCode)
        {
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _slipPrintAcs = new SlipPrintAcs(_enterpriseCode, sectionCode);
            _slipPrintState = SlipPrintStatus.BeforeExecute;
        }
        // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        # endregion

        # region [public プロパティ]
        /// <summary>
        /// 伝票印刷ステータス
        /// </summary>
        public SlipPrintStatus SlipPrintState
        {
            get { return _slipPrintState; }
        }
        // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// PCCUOE自動回答起動フラグプロパティ(0:通常 1:PCCUOE自動回答起動)
        /// </summary>
        public int IsAutoAns
        {
            get { return this._isAutoAns; }
            set { this._isAutoAns = value; }
        }
        // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
        /// <summary>
        /// サービス起動プロパティ
        /// </summary>
        public int IsService
        {
            get { return this._isService; }
            //>>>2010/07/30
            //set { this._isService = value; }
            set { this._isService = 0; }
            //<<<2010/07/30
        }
        // add by zhouzy for PCCUOEリモート伝票発行 20110811  end
        // ADD 2013/09/19 Redmine#40342対応 --------------------------------------------------->>>>>
        /// <summary>
        /// タブレット起動区分(True:タブレットより起動 False:タブレット以外より起動)
        /// </summary>
        public bool IsTablet
        {
            get { return this._isTablet; }
            set { this._isTablet = value; }
        }
        // ADD 2013/09/19 Redmine#40342対応 ---------------------------------------------------<<<<<
        # endregion

        # region [public メソッド]
        /// <summary>
        /// 印刷処理（画面表示なし）
        /// </summary>
        /// <param name="iSlipPrintCndtn">伝票印刷条件</param>
        /// <remarks>
        /// <br>画面表示せずに直接印刷処理を行います。</br>
        /// </remarks>
        public void Print(ISlipPrintCndtn iSlipPrintCndtn)
        {
            // 画面表示なし
            this.ShowDialogProc(iSlipPrintCndtn, true);
        }
        /// <summary>
        /// 印刷確認画面表示
        /// </summary>
        /// <param name="iSlipPrintCndtn">伝票印刷条件</param>
        /// <param name="printWithoutDialog">ダイアログ表示なしフラグ</param>
        public void ShowDialog(ISlipPrintCndtn iSlipPrintCndtn, bool printWithoutDialog)
        {
            // 画面表示任意
            this.ShowDialogProc(iSlipPrintCndtn, printWithoutDialog);
        }
        # endregion

        # region [private メソッド]
        /// <summary>
        /// 印刷確認画面表示実装
        /// </summary>
        /// <param name="iSlipPrintCndtn">伝票印刷条件</param>
        /// <param name="printWithoutDialog">確認ダイアログ表示無しフラグ</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>伝票印刷確認画面を表示します。</br>
        /// <br>printWithoutDialog = true の場合は画面表示せずに直接印刷処理を行います。</br>
        /// <br>Update Note  : 2011/11/22  葛中華</br>
        /// <br>             : ゼロ伝のみの時の不具合について</br>
        /// <br></br>
        /// </remarks>
        private void ShowDialogProc(ISlipPrintCndtn iSlipPrintCndtn, bool printWithoutDialog)
        {
            if (iSlipPrintCndtn == null)
            {
                _slipPrintState = SlipPrintStatus.Error_Cndtn;
                return;
            }
            else if (String.IsNullOrEmpty(iSlipPrintCndtn.EnterpriseCode))
            {
                _slipPrintState = SlipPrintStatus.Error_Cndtn_EnterpriseCode;
                return;
            }
            else
            {
                if (iSlipPrintCndtn is SalesSlipPrintCndtn)
                {
                    // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
                    _slipPrintAcs.IsRmSlpPrt = false;
                    this._IsRmSlpPrt = false;

                    // add by zhouzy for PCCUOEリモート伝票発行 20110811  end
                    // 売上データの場合
                    // update by zhouzy for PCCUOEリモート伝票発行 20110915  begin
                    //CallSalesSlipPrint((SalesSlipPrintCndtn)iSlipPrintCndtn, printWithoutDialog);
                    if (((SalesSlipPrintCndtn)iSlipPrintCndtn).NomalSalesSlipPrintFlag == 0)
                    {
                        //SCM全体設定.売上伝票印刷フラグ
                        _SCMTotalSettingSalesSlipPrtDiv = ((SalesSlipPrintCndtn)iSlipPrintCndtn).SCMTotalSettingSalesSlipPrtDiv;
                        //得意先マスタと売上全体設定マスタの設定より、印刷する時。
                        CallSalesSlipPrint((SalesSlipPrintCndtn)iSlipPrintCndtn, printWithoutDialog);
                    }
                    // update by zhouzy for PCCUOEリモート伝票発行 20110915  end
                    // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
                    Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
                    ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_RemoteSlipPrt);
                   // if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract) //delete by lingxiaoqing on 20110930 for #Redmine25699
                   if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract || ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Trial_Contract ) //add by lingxiaoqing on 20110930 for #Redmine25699
                    {
                        // update by zhouzy 20110917  begin
                        if (((SalesSlipPrintCndtn)iSlipPrintCndtn).RemoteSalesSlipPrintFlag != 1 && ((SalesSlipPrintCndtn)iSlipPrintCndtn).ScmFlg)
                        {
                            _slipPrintAcs.IsRmSlpPrt = true;
                            this._IsRmSlpPrt = true;
                            CallSalesSlipPrint((SalesSlipPrintCndtn)iSlipPrintCndtn, printWithoutDialog);
                        }
                        // update by zhouzy 20110917 end
                    }
                    else
                    {
                        _slipPrintAcs.IsRmSlpPrt = false;
                        this._IsRmSlpPrt = false;
                    }

                    // add by zhouzy for PCCUOEリモート伝票発行 20110811  end
                }
                else if (iSlipPrintCndtn is StockSlipPrintCndtn)
                {
                    // 仕入データの場合
                    CallStockSlipPrint((StockSlipPrintCndtn)iSlipPrintCndtn, printWithoutDialog);
                }
                else if (iSlipPrintCndtn is StockMoveSlipPrintCndtn)
                {
                    // 在庫移動データの場合
                    CallStockMoveSlipPrint((StockMoveSlipPrintCndtn)iSlipPrintCndtn, printWithoutDialog);
                }
                else if (iSlipPrintCndtn is EstFmPrintCndtn)
                {
                    // 見積書データの場合
                    CallEstFmPrint((EstFmPrintCndtn)iSlipPrintCndtn, printWithoutDialog);
                }
                else if (iSlipPrintCndtn is UOESlipPrintCndtn)
                {
                    // ＵＯＥ伝票データの場合
                    // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
                    _slipPrintAcs.IsRmSlpPrt = false;
                    this._IsRmSlpPrt = false;
                    CallUOESlipPrint((UOESlipPrintCndtn)iSlipPrintCndtn, printWithoutDialog);
                    // add by zhouzy for PCCUOEリモート伝票発行 20110811  end
                    // --- DEL 2013/06/21 Y.Wakita ---------->>>>>
                    //// ADD by gezh for rednine#7883 2011/11/22 begin --------->>>>>
                    //if (iSlipPrintCndtn.ExtrData == null || iSlipPrintCndtn.ExtrData.Count == 0)
                    //{
                    //    return;
                    //}
                    //// ADD by gezh for rednine#7883 2011/11/22 end -----------<<<<<
                    // --- DEL 2013/06/21 Y.Wakita ----------<<<<<
                    // ADD 2013/09/13 PM.NS仕掛一覧№2137 吉岡------------->>>>>>>>>>>>>>>
                    bool rtnFlg = true;
                    foreach(UoeSales uoeSales in ((UOESlipPrintCndtn)iSlipPrintCndtn).UOESalesList)
                    {
                        if (!string.IsNullOrEmpty(uoeSales.salesSlipWork.SalesSlipNum))
                        {
                            rtnFlg = false;
                            break;
                        }
                    }
                    if (rtnFlg) return;
                    // ADD 2013/09/13 PM.NS仕掛一覧№2137 吉岡 -------------<<<<<<<<<<<<<<<
                    // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
                    Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
                    ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_RemoteSlipPrt);
                   // if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract) //delete by lingxiaoqing on 20110930 for #Redmine25699
                   if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract || ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Trial_Contract) //add by lingxiaoqing on 20110930 for #Redmine25699
                    {
                        _slipPrintAcs.IsRmSlpPrt = true;
                        this._IsRmSlpPrt = true;
                        // ＵＯＥリモート伝発処理
                        CallSalesSlipPrint(CopyToSalesSlipPrintCndtnFromUoe((UOESlipPrintCndtn)iSlipPrintCndtn), printWithoutDialog);
                    }
                    else
                    {
                        _slipPrintAcs.IsRmSlpPrt = false;
                        this._IsRmSlpPrt = false;
                    }

                    // add by zhouzy for PCCUOEリモート伝票発行 20110811  end
                }
            }

            // エラーメッセージ表示
            ShowErrorMessage(_slipPrintState);
        }

        /// <summary>
        /// 売上伝票　印刷確認ＵＩ呼び出し
        /// </summary>
        /// <param name="iSlipPrintCndtn"></param>
        /// <param name="printWithoutDialog"></param>
        private void CallSalesSlipPrint(SalesSlipPrintCndtn iSlipPrintCndtn, bool printWithoutDialog)
        {
            if (iSlipPrintCndtn.SalesSlipKeyList == null || iSlipPrintCndtn.SalesSlipKeyList.Count == 0)
            {
                _slipPrintState = SlipPrintStatus.Error_Cndtn_SlipList;
                return;
            }

            // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //SFCMN00299CA progressDialog = null;
            //if (!printWithoutDialog)
            //{
            //    // 処理中ダイアログ表示　＞＞
            //    progressDialog = new SFCMN00299CA();
            //    progressDialog.Title = "伝票印刷処理";
            //    progressDialog.Message = "現在、伝票印刷準備中です。";
            //    progressDialog.Show();
            //}

            SFCMN00299CA progressDialog = null;
            if (this._isService == 0)
            {
                if (!printWithoutDialog)
                {
                    // 処理中ダイアログ表示　＞＞
                    progressDialog = new SFCMN00299CA();
                    progressDialog.Title = "伝票印刷処理";
                    progressDialog.Message = "現在、伝票印刷準備中です。";
                    progressDialog.Show();
                }
            }
            // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            List<List<ArrayList>> printDataList = null;

            try
            {
                // 抽出条件を移行
                FrePSalesSlipParaWork paraWork = new FrePSalesSlipParaWork();
                paraWork.EnterpriseCode = iSlipPrintCndtn.EnterpriseCode;
                paraWork.FrePSalesSlipParaKeyList = new List<FrePSalesSlipParaWork.FrePSalesSlipParaKey>();
                for (int index = 0; index < iSlipPrintCndtn.SalesSlipKeyList.Count; index++)
                {
                    SalesSlipPrintCndtn.SalesSlipKey key = iSlipPrintCndtn.SalesSlipKeyList[index];
                    paraWork.FrePSalesSlipParaKeyList.Add(new FrePSalesSlipParaWork.FrePSalesSlipParaKey(key.AcptAnOdrStatus, key.SalesSlipNum));
                }

                // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// アクセスクラスSearch呼び出し
                //status = _slipPrintAcs.InitialSearchFrePSalesSlip(paraWork, ref printDataList);
                // アクセスクラスSearch呼び出し
                status = _slipPrintAcs.InitialSearchFrePSalesSlip(paraWork, ref printDataList, this._isService);
                // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2013/10/30 SCM仕掛一覧№10614対応 ------------------------------------->>>>>
                paraWork = null;
                // ADD 2013/10/30 SCM仕掛一覧№10614対応 -------------------------------------<<<<<
            }
            finally
            {
                // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //if (!printWithoutDialog)
                //{
                //    // 処理中ダイアログ終了 ＜＜
                //    if (progressDialog != null)
                //    {
                //        progressDialog.Close();
                //    }
                //}

                if (this._isService == 0)
                {
                    if (!printWithoutDialog)
                    {
                        // 処理中ダイアログ終了 ＜＜
                        if (progressDialog != null)
                        {
                            progressDialog.Close();
                        }
                    }
                }
                // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            if (status == 0)
            {
                // --------------- ADD START 2013/06/17 zhubj FOR Redmine #36594-------->>>>
                int slipNums = 0;
                //if (_IsRmSlpPrt)//DEL 2013/07/28 zhubj FOR Redmine #36594
                if (_IsRmSlpPrt && !_slipPrintAcs.IsPrintSplit)//ADD 2013/07/28 zhubj FOR Redmine #36594
                {
                    for (int index = 0; index < iSlipPrintCndtn.SalesSlipKeyList.Count; index++)
                    {
                        if (iSlipPrintCndtn.SalesSlipKeyList[index].AcptAnOdrStatus == 30)
                        {
                            slipNums++;
                        }
                    }
                }
                bool isOnlyOneSlip = true;
                if (slipNums > 1)
                {
                    isOnlyOneSlip = false;
                }
                int printCount = 0;
                bool isLastSlip = false;
                // --------------- ADD START 2013/07/28 zhubj FOR Redmine #36594-------->>>>
                // KEY：問合せ番号、売上伝票番号
                List<string> latestDiscKeyList = new List<string>();
                // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
                // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<
                // ADD 2013/09/19 yugami Redmine#40342対応 --------------------------------------------------->>>>>
                // プロパティ用売上伝票番号リスト、問合せ番号リスト
                List<string> slipNumlist = new List<string>();
                List<string> inquiryNumList = new List<string>();
                // ADD 2013/09/19 yugami Redmine#40342対応 ---------------------------------------------------<<<<<
                foreach (List<ArrayList> printData in printDataList)
                {
                    // 伝票印刷ダイアログ呼び出し
                    DCCMN02000UB slipPrintDialog = new DCCMN02000UB(_slipPrintAcs);
                    slipPrintDialog.IsService = this._isService; // 2009.07.16
                    // add by zhouzy for PCCUOEリモート伝票発行 20110811  begin
                    slipPrintDialog.IsAutoAns = this._isAutoAns;
                    // add by zhouzy for PCCUOEリモート伝票発行 20110811  end
                    // --------------- ADD START 2013/06/17 zhubj FOR Redmine #36594-------->>>>
                    printCount++;
                    if (slipNums > 1 && printCount == printDataList.Count)
                    {
                        isLastSlip = true;
                    }
                    slipPrintDialog.IsOnlyOneSlip = isOnlyOneSlip;
                    slipPrintDialog.IsLastSlip = isLastSlip;
                    // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<
                    // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
                    // ADD 2013/09/19 Redmine#40342対応 --------------------------------------------------->>>>>
                    // タブレット起動区分
                    slipPrintDialog.IsTablet = this._isTablet;
                    // ADD 2013/09/19 Redmine#40342対応 ---------------------------------------------------<<<<<

                    // KEY：問合せ番号、売上伝票番号
                    // 売上伝票の場合
                    FrePSalesSlipWork slipWork = (printData[0][0] as FrePSalesSlipWork);
                    List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork> frePSalesDetailWorkList = printData[0][1] as List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork>;
                    string latestDiscKey = frePSalesDetailWorkList[0].SALESDETAILRF_INQUIRYNUMBERRF + "_" + slipWork.SALESSLIPRF_SALESSLIPNUMRF;
                    if (!latestDiscKeyList.Contains(latestDiscKey))
                    {
                        slipPrintDialog.IsKeyChangeFlag = true;
                        latestDiscKeyList.Add(latestDiscKey);
                        // ADD 2013/09/19 yugami Redmine#40342対応 --------------------------------------------------->>>>>
                        slipNumlist.Add(slipWork.SALESSLIPRF_SALESSLIPNUMRF);
                        inquiryNumList.Add(frePSalesDetailWorkList[0].SALESDETAILRF_INQUIRYNUMBERRF.ToString());
                        // ADD 2013/09/19 yugami Redmine#40342対応 ---------------------------------------------------<<<<<
                    }
                    else
                    {
                        slipPrintDialog.IsKeyChangeFlag = false;
                    }
                    // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
                    if (_IsRmSlpPrt)
                    {
                        //リモート伝票発行の場合
                        slipPrintDialog.IsRmSlpPrt = true;

                        // ADD 2013/09/19 yugami Redmine#40342対応 --------------------------------------------------->>>>>
                        slipPrintDialog.SlipNumlist = slipNumlist;
                        slipPrintDialog.InquiryNumList = inquiryNumList;
                        // ADD 2013/09/19 yugami Redmine#40342対応 ---------------------------------------------------<<<<<

                        // UPD 2012/12/13 2013/01/16配信予定 SCM障害№10352対応 ---------------------------------------->>>>>
                        //if (null != _slipPrintAcs.RmSlpPrtStWork && _slipPrintAcs.RmSlpPrtStWork.RmtSlpPrtDiv == 1 && CheckRmSlpPrt(printData))
                        if (null != _slipPrintAcs.RmSlpPrtStWork && _slipPrintAcs.RmSlpPrtStWork.RmtSlpPrtDiv == 1)
                        // UPD 2012/12/13 2013/01/16配信予定 SCM障害№10352対応 ----------------------------------------<<<<<
                        {
                            // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            slipPrintDialog.PrintDataList = _printDataList;
                            // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                            slipPrintDialog.ShowDialog(iSlipPrintCndtn, printData, printWithoutDialog, _slipPrintAcs.RmSlpPrtStWork);
                            // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            _printDataList = slipPrintDialog.PrintDataList;
                            // ADD 2013/09/20 吉岡 2013/09/99配信予定 ランテルUOE送信処理 速度遅延対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
                    }
                    else
                    {
                        //通常の場合
                        slipPrintDialog.IsRmSlpPrt = false;
                        // zhouzy update 20110927 begin
                        //slipPrintDialog.ShowDialog(iSlipPrintCndtn, printData, printWithoutDialog);
                        if (CheckSCMSlpPrt(printData))
                        {
                            slipPrintDialog.ShowDialog(iSlipPrintCndtn, printData, printWithoutDialog);
                        }
                        // zhouzy update 20110927 end
                    }

                    SetErrorStateFromDialog(ref _slipPrintState, slipPrintDialog);
                    // --- ADD 2014/12/05 T.Miyamoto ------------------------------>>>>>
                    slipPrintDialog.EventDelete();
                    // --- ADD 2014/12/05 T.Miyamoto ------------------------------<<<<<
                    // ADD 2013/10/30 SCM仕掛一覧№10614対応 ------------------------------------->>>>>
                    slipPrintDialog.Clear();
                    slipPrintDialog.Dispose();
                    slipPrintDialog = null;
                    GC.Collect();
                    // ADD 2013/10/30 SCM仕掛一覧№10614対応 -------------------------------------<<<<<
                }
            }
            else
            {
                //ShowErrorMessageOfSlipAcs( _slipPrintAcs.SlipAcsState, status );
                SetErrorState(ref _slipPrintState, _slipPrintAcs.SlipAcsState);
            }
        }

        // zhouzy add 20110920 begin
        /// <summary>
        /// リモート伝票を発行するかを判断する
        /// 受発注種別は1:PCC-UOEの場合は印刷
        /// それ以外の場合は印刷しない
        /// </summary>
        /// <param name="printData">印刷データ</param>
        /// <returns>チェック結果</returns>
        private bool CheckRmSlpPrt(List<ArrayList> printData)
        {
            bool result = false;
            List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork> frePSalesDetailWorkList = printData[0][1] as List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork>;
            // 売上明細データワーク
            FrePSalesDetailWork salesDetailWork = salesDetailWork = frePSalesDetailWorkList[0];
            //PCCUOEの場合、リモート伝票を発行
            if (salesDetailWork.SALESDETAILRF_ACCEPTORORDERKINDRF == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// SCM伝票を発行するかを判断する
        /// 受発注種別は0:SCMの場合、チェックを行う
        /// それ以外の場合は印刷しない
        /// </summary>
        /// <param name="printData">印刷データ</param>
        /// <returns>チェック結果</returns>
        private bool CheckSCMSlpPrt(List<ArrayList> printData)
        {
            bool result = false;
            List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork> frePSalesDetailWorkList = printData[0][1] as List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork>;
            // 売上明細データワーク
            FrePSalesDetailWork salesDetailWork = salesDetailWork = frePSalesDetailWorkList[0];
            //見積書の場合
            if (salesDetailWork.SALESDETAILRF_ACPTANODRSTATUSRF == 10)
            {
                //add by wangqx 2011/10/17
                //SCMの場合
                if (salesDetailWork.SALESDETAILRF_ACCEPTORORDERKINDRF == 0)
                {
                    // 得意先マスタから取得
                    int SlipPrintDivCd = 0;
                    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                    CustomerInfo customerInfo;
                    FrePSalesSlipWork slipWork = (printData[0][0] as FrePSalesSlipWork);
                    int flg = customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, slipWork.SALESSLIPRF_CUSTOMERCODERF, out customerInfo);
                    EstimateDefSetAcs estimateDefSetAcs = new EstimateDefSetAcs();
                    EstimateDefSet estimateDefSet = new EstimateDefSet();
                    // 見積全体設定取得
                    estimateDefSetAcs.Read(out estimateDefSet, LoginInfoAcquisition.EnterpriseCode, slipWork.SALESSLIPRF_SECTIONCODERF);
                    if (estimateDefSet == null)
                    {
                        estimateDefSetAcs.Read(out estimateDefSet, LoginInfoAcquisition.EnterpriseCode, "00");

                    }
                    if (estimateDefSet == null)
                    {
                        estimateDefSet = new EstimateDefSet();
                    }
                    // 得意先マスタ取得
                    if (flg != (int)ConstantManagement.DB_Status.ctDB_NORMAL || customerInfo == null)
                    {
                        customerInfo = new CustomerInfo();
                    }
                    switch (customerInfo.EstimatePrtDiv)
                    {
                        // 0:標準 ← 見積全体設定
                        default:
                        case 0:
                            SlipPrintDivCd = (estimateDefSet.EstimatePrtDiv + 1) % 2;
                            break;
                        // 1:未使用 ← 0:しない
                        case 1:
                            SlipPrintDivCd = 0;
                            break;
                        // 2:使用 ← 1:する
                        case 2:
                            SlipPrintDivCd = 1;
                            break;
                    }
                    if (SlipPrintDivCd != 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }

                }
                // --- Add 2012/01/18 duzg for Redmine#28011 --->>>
                else
                {
                    result = true;
                }
                // --- Add 2012/01/18 duzg for Redmine#28011 ---<<<
                //add by wangqx 2011/10/17
                //result = true;//delete by wangqx 2011/10/17
            }
            //売上伝票の場合
            else
            {
                //通常の場合
                if (salesDetailWork.SALESDETAILRF_ACCEPTORORDERKINDRF == 0)
                {
                    //送信がある場合
                    if (salesDetailWork.SALESDETAILRF_INQUIRYNUMBERRF != 0)
                    {
                        // --- ADD m.suzuki 2011/10/21 ---------->>>>>
                        if ( IsAutoAns == 1 )
                        {
                        // --- ADD m.suzuki 2011/10/21 ----------<<<<<
                            if ( _SCMTotalSettingSalesSlipPrtDiv == 1 )
                            {
                                //SCM全体設定.売上伝票印刷フラグ：1 印刷する
                                result = true;
                            }
                            else
                            {
                                //SCM全体設定.売上伝票印刷フラグ：0 印刷しない
                                result = false;
                            }
                        // --- ADD m.suzuki 2011/10/21 ---------->>>>>
                        }
                        else
                        {
                            //自動回答以外はSCM全体設定.売上伝票印刷フラグによらず、印刷する。
                            result = true;
                        }
                        // --- ADD m.suzuki 2011/10/21 ----------<<<<<
                    }
                    else
                    {
                        //送信ない場合、印刷する
                        result = true;
                    }
                }
                else
                {
                    //PCCUOEの場合
                    result = true;
                }
            }
            return result;
        }
        // zhouzy add 20110920 end

        // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
        /// <summary>
        /// 印刷条件をコピーする。
        /// ＵＯＥ伝票印刷条件⇒売上伝票印刷条件
        /// </summary>
        /// <param name="uoeSlipPrintCndtn">ＵＯＥ伝票印刷条件</param>
        /// <returns>売上伝票印刷条件</returns>
        private SalesSlipPrintCndtn CopyToSalesSlipPrintCndtnFromUoe(UOESlipPrintCndtn uoeSlipPrintCndtn)
        {
            SalesSlipPrintCndtn salesCndtn = new SalesSlipPrintCndtn();
            salesCndtn.EnterpriseCode = uoeSlipPrintCndtn.EnterpriseCode;
            salesCndtn.ExtrData = uoeSlipPrintCndtn.ExtrData;
            // 伝票印刷用KeyListインスタンス生成
            List<SalesSlipPrintCndtn.SalesSlipKey> keyList = new List<SalesSlipPrintCndtn.SalesSlipKey>();
            Dictionary<string, bool> dic = new Dictionary<string, bool>();
            foreach (UoeSales uoeSales in uoeSlipPrintCndtn.UOESalesList)
            {
                // 伝票番号未設定は除外する
                if (string.IsNullOrEmpty(uoeSales.salesSlipWork.SalesSlipNum)) continue;
                // ディクショナリで重複チェックして除外する
                if (dic.ContainsKey(uoeSales.salesSlipWork.SalesSlipNum)) continue;

                // 伝票キー追加
                keyList.Add(new SalesSlipPrintCndtn.SalesSlipKey(uoeSales.salesSlipWork.AcptAnOdrStatus, uoeSales.salesSlipWork.SalesSlipNum));
                dic.Add(uoeSales.salesSlipWork.SalesSlipNum, true);
            }
            salesCndtn.SalesSlipKeyList = keyList;
            return salesCndtn;
        }
        // add by zhouzy for PCCUOEリモート伝票発行 20110811  end


        ///// <summary>
        ///// アクセスクラスエラーの表示
        ///// </summary>
        ///// <param name="slipAcsStatus"></param>
        //private void ShowErrorMessageOfSlipAcs( SlipPrintAcs.SlipAcsStatus slipAcsStatus, int status )
        //{
        //    if ( _slipPrintAcs.SlipAcsState != SlipPrintAcs.SlipAcsStatus.Normal )
        //    {
        //        string message = string.Empty;

        //        switch ( _slipPrintAcs.SlipAcsState )
        //        {
        //            case SlipPrintAcs.SlipAcsStatus.Error_NoTerminalMg:
        //                message = "端末設定が未設定の為、印刷できませんでした。";
        //                break;
        //            case SlipPrintAcs.SlipAcsStatus.Error_SearchSlip:
        //                message = "伝票情報抽出中にエラーが発生した為、印刷できませんでした。";
        //                break;
        //        }

        //        TMsgDisp.Show(
        //            emErrorLevel.ERR_LEVEL_STOPDISP
        //            , this.ToString()
        //            , "伝票発行"
        //            , ""
        //            , TMsgDisp.OPE_PRINT
        //            , message
        //            , status
        //            , null
        //            , MessageBoxButtons.OK
        //            , MessageBoxDefaultButton.Button1 );
        //    }
        //}

        /// <summary>
        /// エラーステータス設定（アクセスクラスのエラー → 印刷ＵＩのエラー）
        /// </summary>
        /// <param name="slipPrintStatus"></param>
        /// <param name="slipAcsStatus"></param>
        private void SetErrorState(ref SlipPrintStatus slipPrintStatus, SlipPrintAcs.SlipAcsStatus slipAcsStatus)
        {
            switch (slipAcsStatus)
            {
                case SlipPrintAcs.SlipAcsStatus.Error_NoTerminalMg:
                    slipPrintStatus = SlipPrintStatus.Error_NoTerminalMg;
                    break;
                case SlipPrintAcs.SlipAcsStatus.Error_SearchSlip:
                    slipPrintStatus = SlipPrintStatus.Error_PrintSlip;
                    break;
            }
        }
        /// <summary>
        /// エラーステータス設定（ダイアログのエラー → 印刷ＵＩのエラー）
        /// </summary>
        /// <param name="slipPrintStatus"></param>
        /// <param name="slipPrintDialog"></param>
        private void SetErrorStateFromDialog(ref SlipPrintStatus slipPrintStatus, DCCMN02000UB slipPrintDialog)
        {
            switch (slipPrintDialog.SlipPrintDialogState)
            {
                case DCCMN02000UB.SlipPrintDialogStatus.Cancel:
                    slipPrintStatus = SlipPrintStatus.Cancel;
                    break;
                case DCCMN02000UB.SlipPrintDialogStatus.Error_CallPrint:
                    slipPrintStatus = SlipPrintStatus.Error_PrintSlip;
                    break;
                case DCCMN02000UB.SlipPrintDialogStatus.Error_InvalidPrinter:
                    slipPrintStatus = SlipPrintStatus.Error_InvalidPrinter;
                    break;
                case DCCMN02000UB.SlipPrintDialogStatus.Error_Initialize:
                    slipPrintStatus = SlipPrintStatus.Error_PrintSlipInit;
                    break;
            }
        }

        /// <summary>
        /// エラー表示
        /// </summary>
        /// <param name="slipPrintStatus"></param>
        private void ShowErrorMessage(SlipPrintStatus slipPrintStatus)
        {
            string message = string.Empty;

            switch (slipPrintStatus)
            {
                case SlipPrintStatus.Error_NoTerminalMg:
                    message = "端末設定が未設定の為、印刷できませんでした。";
                    break;
                case SlipPrintStatus.Error_SearchSlip:
                    message = "伝票情報抽出中にエラーが発生した為、印刷できませんでした。";
                    break;
                case SlipPrintStatus.Error_PrintSlip:
                    message = "伝票印刷処理中にエラーが発生した為、印刷できませんでした。";
                    break;
                case SlipPrintStatus.Error_PrintSlipInit:
                    message = "伝票印刷初期化処理中にエラーが発生した為、印刷できませんでした。";
                    break;
                case SlipPrintStatus.Error_InvalidPrinter:
                    message = "プリンタ設定が不正な為、印刷できませんでした。";
                    break;
                case SlipPrintStatus.Error_Cndtn_EnterpriseCode:
                    message = "伝票印刷条件が不正な為、印刷できませんでした。（企業コード）";
                    break;
                case SlipPrintStatus.Error_Cndtn_SlipList:
                    message = "伝票印刷条件が不正な為、印刷できませんでした。（伝票リスト）";
                    break;
                case SlipPrintStatus.Error_Cndtn:
                    message = "伝票印刷条件が不正な為、印刷できませんでした。";
                    break;
                case SlipPrintStatus.BeforeExecute:
                case SlipPrintStatus.Cancel:
                case SlipPrintStatus.OK:
                default:
                    break;
            }

            if (message != string.Empty)
            {
                // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //TMsgDisp.Show(
                //    emErrorLevel.ERR_LEVEL_STOPDISP
                //    , this.ToString()
                //    , "伝票発行"
                //    , ""
                //    , TMsgDisp.OPE_PRINT
                //    , message
                //    , 0
                //    , null
                //    , MessageBoxButtons.OK
                //    , MessageBoxDefaultButton.Button1);

                if (this._isService == 0)
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_STOPDISP
                        , this.ToString()
                        , "伝票発行"
                        , ""
                        , TMsgDisp.OPE_PRINT
                        , message
                        , 0
                        , null
                        , MessageBoxButtons.OK
                        , MessageBoxDefaultButton.Button1);
                }
                // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<                
            }
        }

        /// <summary>
        /// 仕入伝票　印刷確認ＵＩ呼び出し
        /// </summary>
        /// <param name="iSlipPrintCndtn"></param>
        /// <param name="printWithoutDialog"></param>
        private void CallStockSlipPrint(StockSlipPrintCndtn iSlipPrintCndtn, bool printWithoutDialog)
        {
            //----------------------------------------------------------------
            // ※2008.06.02時点で仕入返品伝票印刷は未実装。
            // 　実装する場合は専用のリモートと、印刷DLLの追加が必要。
            //----------------------------------------------------------------
        }
        /// <summary>
        /// 在庫移動伝票　印刷確認ＵＩ呼び出し
        /// </summary>
        /// <param name="iSlipPrintCndtn"></param>
        /// <param name="printWithoutDialog"></param>
        private void CallStockMoveSlipPrint(StockMoveSlipPrintCndtn iSlipPrintCndtn, bool printWithoutDialog)
        {
            if (iSlipPrintCndtn.StockMoveSlipKeyList == null || iSlipPrintCndtn.StockMoveSlipKeyList.Count == 0)
            {
                _slipPrintState = SlipPrintStatus.Error_Cndtn_SlipList;
                return;
            }

            SFCMN00299CA progressDialog = null;
            if (!printWithoutDialog)
            {
                // 処理中ダイアログ表示　＞＞
                progressDialog = new SFCMN00299CA();
                progressDialog.Title = "伝票印刷処理";
                progressDialog.Message = "現在、伝票印刷準備中です。";
                progressDialog.Show();
            }

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            List<List<ArrayList>> printDataList = null;

            try
            {
                // 抽出条件を移行
                FrePStockMoveSlipParaWork paraWork = new FrePStockMoveSlipParaWork();
                paraWork.EnterpriseCode = iSlipPrintCndtn.EnterpriseCode;
                paraWork.FrePStockMoveSlipParaKeyList = new List<FrePStockMoveSlipParaWork.FrePStockMoveSlipParaKey>();
                for (int index = 0; index < iSlipPrintCndtn.StockMoveSlipKeyList.Count; index++)
                {
                    StockMoveSlipPrintCndtn.StockMoveSlipKey key = iSlipPrintCndtn.StockMoveSlipKeyList[index];
                    paraWork.FrePStockMoveSlipParaKeyList.Add(new FrePStockMoveSlipParaWork.FrePStockMoveSlipParaKey(key.StockMoveFormal, key.StockMoveSlipNo));
                }

                // アクセスクラスSearch呼び出し
                status = _slipPrintAcs.InitialSearchFrePStockMoveSlip(paraWork, ref printDataList);
            }
            finally
            {
                if (!printWithoutDialog)
                {
                    // 処理中ダイアログ終了 ＜＜
                    if (progressDialog != null)
                    {
                        progressDialog.Close();
                    }
                }
            }
            if (status == 0)
            {
                foreach (List<ArrayList> printData in printDataList)
                {
                    // 伝票印刷ダイアログ呼び出し
                    DCCMN02000UB slipPrintDialog = new DCCMN02000UB(_slipPrintAcs);
                    slipPrintDialog.ShowDialog(iSlipPrintCndtn, printData, printWithoutDialog);

                    SetErrorStateFromDialog(ref _slipPrintState, slipPrintDialog);
                }
            }
            else
            {
                //ShowErrorMessageOfSlipAcs( _slipPrintAcs.SlipAcsState, status );
                SetErrorState(ref _slipPrintState, _slipPrintAcs.SlipAcsState);
            }
        }
        /// <summary>
        /// 見積書　印刷確認ＵＩ呼び出し
        /// </summary>
        /// <param name="iSlipPrintCndtn"></param>
        /// <param name="printWithoutDialog"></param>
        private void CallEstFmPrint(EstFmPrintCndtn iSlipPrintCndtn, bool printWithoutDialog)
        {
            if (iSlipPrintCndtn.EstFmUnitDataList == null || iSlipPrintCndtn.EstFmUnitDataList.Count == 0)
            {
                _slipPrintState = SlipPrintStatus.Error_Cndtn_SlipList;
                return;
            }

            SFCMN00299CA progressDialog = null;
            if (!printWithoutDialog)
            {
                // 処理中ダイアログ表示　＞＞
                progressDialog = new SFCMN00299CA();
                progressDialog.Title = "見積書印刷処理";
                progressDialog.Message = "現在、見積書印刷準備中です。";
                progressDialog.Show();
            }

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            List<ArrayList> extData = null;
            List<ArrayList> printData = null;

            try
            {
                // 抽出条件を移行
                FrePEstFmParaWork paraWork = new FrePEstFmParaWork();
                paraWork.EnterpriseCode = iSlipPrintCndtn.EnterpriseCode;
                if (iSlipPrintCndtn.EstFmUnitDataList != null && iSlipPrintCndtn.EstFmUnitDataList.Count > 0 && iSlipPrintCndtn.EstFmUnitDataList[0].FrePEstFmHead != null)
                {
                    // 拠点コードセット
                    paraWork.SectionCode = iSlipPrintCndtn.EstFmUnitDataList[0].FrePEstFmHead.SALESSLIPRF_SECTIONCODERF;
                    // アクセスクラスSearch呼び出し
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 DEL
                    //status = _slipPrintAcs.InitialSearchFrePEstFm( paraWork, ref extData );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
                    status = _slipPrintAcs.InitialSearchFrePEstFm(paraWork, iSlipPrintCndtn.EstFmUnitDataList[0].FrePEstFmHead.SALESSLIPRF_CUSTOMERCODERF, ref extData);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD

                    if (status == 0)
                    {
                        // リモート取得した売上情報(一部)を取得
                        FrePSalesSlipWork frePSalesSlipWork = null;
                        if (extData != null && extData.Count > 0)
                        {
                            foreach (ArrayList list in extData)
                            {
                                foreach (object extObj in list)
                                {
                                    if (extObj is FrePSalesSlipWork)
                                    {
                                        frePSalesSlipWork = (FrePSalesSlipWork)extObj;
                                        break;
                                    }
                                }
                                if (frePSalesSlipWork != null) break;
                            }
                        }

                        if (frePSalesSlipWork != null)
                        {
                            // 各見積書データに反映
                            foreach (EstFmPrintCndtn.EstFmUnitData unitData in iSlipPrintCndtn.EstFmUnitDataList)
                            {
                                // 伝票印刷用帳票ＩＤセット
                                unitData.FrePEstFmHead.HADD_SLIPPRTSETPAPERIDRF = frePSalesSlipWork.HADD_SLIPPRTSETPAPERIDRF;
                                // プリンタ管理№セット
                                unitData.FrePEstFmHead.HADD_PRINTERMNGNORF = frePSalesSlipWork.HADD_PRINTERMNGNORF;

                                // 拠点・自社名称・画像・自社情報をコピー
                                # region [コピー]
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYPRRF = frePSalesSlipWork.COMPANYNMRF_COMPANYPRRF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYNAME1RF = frePSalesSlipWork.COMPANYNMRF_COMPANYNAME1RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYNAME2RF = frePSalesSlipWork.COMPANYNMRF_COMPANYNAME2RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_POSTNORF = frePSalesSlipWork.COMPANYNMRF_POSTNORF;
                                unitData.FrePEstFmHead.COMPANYNMRF_ADDRESS1RF = frePSalesSlipWork.COMPANYNMRF_ADDRESS1RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_ADDRESS3RF = frePSalesSlipWork.COMPANYNMRF_ADDRESS3RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_ADDRESS4RF = frePSalesSlipWork.COMPANYNMRF_ADDRESS4RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYTELNO1RF = frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO1RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYTELNO2RF = frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO2RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYTELNO3RF = frePSalesSlipWork.COMPANYNMRF_COMPANYTELNO3RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYTELTITLE1RF = frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE1RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYTELTITLE2RF = frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE2RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYTELTITLE3RF = frePSalesSlipWork.COMPANYNMRF_COMPANYTELTITLE3RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_TRANSFERGUIDANCERF = frePSalesSlipWork.COMPANYNMRF_TRANSFERGUIDANCERF;
                                unitData.FrePEstFmHead.COMPANYNMRF_ACCOUNTNOINFO1RF = frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO1RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_ACCOUNTNOINFO2RF = frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO2RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_ACCOUNTNOINFO3RF = frePSalesSlipWork.COMPANYNMRF_ACCOUNTNOINFO3RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYSETNOTE1RF = frePSalesSlipWork.COMPANYNMRF_COMPANYSETNOTE1RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYSETNOTE2RF = frePSalesSlipWork.COMPANYNMRF_COMPANYSETNOTE2RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYURLRF = frePSalesSlipWork.COMPANYNMRF_COMPANYURLRF;
                                unitData.FrePEstFmHead.COMPANYNMRF_COMPANYPRSENTENCE2RF = frePSalesSlipWork.COMPANYNMRF_COMPANYPRSENTENCE2RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = frePSalesSlipWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF;
                                unitData.FrePEstFmHead.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = frePSalesSlipWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF;
                                unitData.FrePEstFmHead.IMAGEINFORF_IMAGEINFODATARF = frePSalesSlipWork.IMAGEINFORF_IMAGEINFODATARF;
                                unitData.FrePEstFmHead.COMPANYINFRF_COMPANYNAME1RF = frePSalesSlipWork.COMPANYINFRF_COMPANYNAME1RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_COMPANYNAME2RF = frePSalesSlipWork.COMPANYINFRF_COMPANYNAME2RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_POSTNORF = frePSalesSlipWork.COMPANYINFRF_POSTNORF;
                                unitData.FrePEstFmHead.COMPANYINFRF_ADDRESS1RF = frePSalesSlipWork.COMPANYINFRF_ADDRESS1RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_ADDRESS3RF = frePSalesSlipWork.COMPANYINFRF_ADDRESS3RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_ADDRESS4RF = frePSalesSlipWork.COMPANYINFRF_ADDRESS4RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_COMPANYTELNO1RF = frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO1RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_COMPANYTELNO2RF = frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO2RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_COMPANYTELNO3RF = frePSalesSlipWork.COMPANYINFRF_COMPANYTELNO3RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_COMPANYTELTITLE1RF = frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE1RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_COMPANYTELTITLE2RF = frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE2RF;
                                unitData.FrePEstFmHead.COMPANYINFRF_COMPANYTELTITLE3RF = frePSalesSlipWork.COMPANYINFRF_COMPANYTELTITLE3RF;
                                # endregion

                                //------------------------------------------------
                                // 印刷情報の生成
                                //------------------------------------------------
                                if (printData == null)
                                {
                                    printData = new List<ArrayList>();
                                }
                                ArrayList list = new ArrayList();
                                list.Add(unitData.FrePEstFmHead);         // 他の印刷処理に合わせる為[0]はヘッダにしておく
                                list.Add(unitData.FrePEstFmDetailList);   // 他の印刷処理に合わせる為[1]は明細リストにしておく
                                list.Add(CreateExtraData(unitData));    // [2]に不足分を入れる
                                printData.Add(list);
                            }
                        }
                    }
                }
            }
            finally
            {
                if (!printWithoutDialog)
                {
                    // 処理中ダイアログ終了 ＜＜
                    if (progressDialog != null)
                    {
                        progressDialog.Close();
                    }
                }
            }
            if (status == 0)
            {
                // 伝票印刷ダイアログ呼び出し
                DCCMN02000UB slipPrintDialog = new DCCMN02000UB(_slipPrintAcs);
                slipPrintDialog.ShowDialog(iSlipPrintCndtn, printData, printWithoutDialog);

                SetErrorStateFromDialog(ref _slipPrintState, slipPrintDialog);
            }
            else
            {
                //ShowErrorMessageOfSlipAcs( _slipPrintAcs.SlipAcsState, status );
                SetErrorState(ref _slipPrintState, _slipPrintAcs.SlipAcsState);
            }
        }
        /// <summary>
        /// 見積書　補足情報設定
        /// </summary>
        /// <param name="unitData"></param>
        /// <returns></returns>
        private EstFmUnitExtraData CreateExtraData(EstFmPrintCndtn.EstFmUnitData unitData)
        {
            EstFmUnitExtraData extraData = new EstFmUnitExtraData();
            extraData.PrintCount = unitData.PrintCount;

            return extraData;
        }
        /// <summary>
        /// UOE伝票　印刷確認ＵＩ呼び出し
        /// </summary>
        /// <param name="iSlipPrintCndtn"></param>
        /// <param name="printWithoutDialog"></param>
        private void CallUOESlipPrint(UOESlipPrintCndtn iSlipPrintCndtn, bool printWithoutDialog)
        {
            if (iSlipPrintCndtn.UOESalesList == null || iSlipPrintCndtn.UOESalesList.Count == 0)
            {
                _slipPrintState = SlipPrintStatus.Error_Cndtn_SlipList;
                return;
            }

            SFCMN00299CA progressDialog = null;
            if (!printWithoutDialog)
            {
                // 処理中ダイアログ表示　＞＞
                progressDialog = new SFCMN00299CA();
                progressDialog.Title = "伝票印刷処理";
                progressDialog.Message = "現在、伝票印刷準備中です。";
                progressDialog.Show();
            }

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            List<List<ArrayList>> printDataList = null;

            try
            {
                // 抽出条件を移行
                FrePUOESlipParaWork paraWork = new FrePUOESlipParaWork();
                paraWork.EnterpriseCode = iSlipPrintCndtn.EnterpriseCode;
                paraWork.UOESlipParaUnitList = new List<FrePUOESlipParaWork.FrePUOESlipParaUnitWork>();

                for (int index = 0; index < iSlipPrintCndtn.UOESalesList.Count; index++)
                {
                    // １伝票分をリモートパラメータに変換
                    paraWork.UOESlipParaUnitList.Add(CopyToFrePUOESlipParaUnitWorkFromUOESales(iSlipPrintCndtn.UOESalesList[index]));
                }

                // アクセスクラスSearch呼び出し
                status = _slipPrintAcs.InitialSearchFrePUOESlip(paraWork, ref printDataList, iSlipPrintCndtn.UOESalesList);
            }
            finally
            {
                if (!printWithoutDialog)
                {
                    // 処理中ダイアログ終了 ＜＜
                    if (progressDialog != null)
                    {
                        progressDialog.Close();
                    }
                }
            }
            if (status == 0)
            {
                foreach (List<ArrayList> printData in printDataList)
                {
                    // 伝票印刷ダイアログ呼び出し
                    DCCMN02000UB slipPrintDialog = new DCCMN02000UB(_slipPrintAcs);
                    slipPrintDialog.ShowDialog(iSlipPrintCndtn, printData, printWithoutDialog);

                    SetErrorStateFromDialog(ref _slipPrintState, slipPrintDialog);
                }
            }
            else
            {
                //ShowErrorMessageOfSlipAcs( _slipPrintAcs.SlipAcsState, status );
                SetErrorState(ref _slipPrintState, _slipPrintAcs.SlipAcsState);
            }
        }
        /// <summary>
        /// UOE伝票用 抽出条件移行処理
        /// </summary>
        /// <param name="uoeSales"></param>
        /// <returns></returns>
        private FrePUOESlipParaWork.FrePUOESlipParaUnitWork CopyToFrePUOESlipParaUnitWorkFromUOESales(UoeSales uoeSales)
        {
            FrePUOESlipParaWork.FrePUOESlipParaUnitWork unitWork = new FrePUOESlipParaWork.FrePUOESlipParaUnitWork();

            // 伝票ヘッダ
            unitWork.SlipWork = SlipPrintAcs.CopyToFrePSalesSlipWorkFromSalesSlip(uoeSales.salesSlipWork);

            // 明細リスト
            unitWork.DetailWorkList = new List<FrePSalesDetailWork>();
            for (int index = 0; index < uoeSales.uoeSalesDetailList.Count; index++)
            {
                unitWork.DetailWorkList.Add(SlipPrintAcs.CopyToFrePSalesDetailWorkFromSalesDetail(uoeSales.uoeSalesDetailList[index].salesDetailWork));
            }

            return unitWork;
        }
        # endregion

        # region [伝票印刷ステータス]
        /// <summary>
        /// 伝票印刷ステータス
        /// </summary>
        public enum SlipPrintStatus
        {
            /// <summary>未実行</summary>
            BeforeExecute = 0,
            /// <summary>キャンセル後</summary>
            Cancel = 1,
            /// <summary>正常終了後</summary>
            OK = 2,
            /// <summary>（エラー）端末管理設定なし</summary>
            Error_NoTerminalMg = 11,
            /// <summary>（エラー）伝票情報抽出</summary>
            Error_SearchSlip = 12,
            /// <summary>（エラー）伝票印刷</summary>
            Error_PrintSlip = 13,
            /// <summary>（エラー）伝票印刷時初期化処理</summary>
            Error_PrintSlipInit = 14,
            /// <summary>（エラー）プリンタ不正</summary>
            Error_InvalidPrinter = 15,
            /// <summary>（条件エラー）企業コード</summary>
            Error_Cndtn_EnterpriseCode = 21,
            /// <summary>（条件エラー）伝票リスト</summary>
            Error_Cndtn_SlipList = 22,
            /// <summary>（条件エラー）全般</summary>
            Error_Cndtn = 23,
        }
        # endregion

        // 2009.07.16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ログ出力(DEBUG)処理
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
#if DEBUG
            //System.IO.FileStream _fs;										// ファイルストリーム
            //System.IO.StreamWriter _sw;										// ストリームwriter
            //_fs = new FileStream("DCCMN02000U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            //_sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            //DateTime edt = DateTime.Now;
            ////yyyy/MM/dd hh:mm:ss
            //_sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
            //if (_sw != null)
            //    _sw.Close();
            //if (_fs != null)
            //    _fs.Close();
#endif
        }
        // 2009.07.16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<                

    }
}
