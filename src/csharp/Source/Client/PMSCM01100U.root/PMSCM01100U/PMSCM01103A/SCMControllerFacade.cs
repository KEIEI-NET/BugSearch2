//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/06/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/22  修正内容 : NS待機処理対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/10/17  修正内容 : SCM障害対応 SCM連携未送信データ取得条件を修正 №10414
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三戸　伸悟
// 作 成 日  2012/12/05  修正内容 : 2012/12/99配信 SCM障害№10442対応 送信ボタン表示制御、単体起動時ログ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡
// 作 成 日  2013/08/28  修正内容 : タブレットからの売上登録時、"送信中"ウィンドウを非表示にする
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using System.IO;
// ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------>>>>>
using System.Collections;
using System.Collections.Generic;
// ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------<<<<<

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 回答送信処理の窓口クラス
    /// </summary>
    public static class SCMControllerFacade
    {
        private const string MY_NAME = "SCMControllerFacade";   // ログ用

        /// <summary>PM.NSのパラメータキーワード</summary>
        private const string PMNS_PARAMETER_KEYWORD = "/A";
        /// <summary>PM7のパラメータキーワード</summary>
        private const string PM7_PARAMETER_KEYWORD = "/B";
        // --- ADD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>サポートメニューから起動のパラメータキーワード</summary>
        private const string SYS_PARAMETER_KEYWORD = "/C";
        // --- ADD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 回答送信処理コントローラを生成します。
        /// </summary>
        /// <param name="commandLineArgs">コマンドライン引数</param>
        /// <returns>
        /// 起動パラメータ：無し…単体起動モード(起動：PM.NS)→<c>PMNSNormalController</c><br/>
        /// 起動パラメータ："/A"…送信起動モード(起動：PM.NS)→<c>PMNSBatchController</c><br/>
        /// 起動パラメータ："/B"…単体起動モード(起動：PM7)→<c>PM7NormalController</c><br/>
        /// 起動パラメータ："/B 伝票番号 伝票種別 サーバー番号"…送信起動モード(起動：PM7)→<c>PM7BatchController</c>
        /// </returns>
        public static SCMSendController CreateSCMController(string[] commandLineArgs)
        {
            foreach (string arg in commandLineArgs) Debug.WriteLine(arg);

            // PM7の場合の起動パラメータ確認
            // 起動パラメータ：無し
            if (commandLineArgs == null || commandLineArgs.Length.Equals(0))
            {
                return new PMNSNormalController();  // 単体起動モード(起動：PM.NS)
            }

            // --- ADD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
            // 起動パラメータ："/C"
            if (commandLineArgs[0].Equals(SYS_PARAMETER_KEYWORD))
            {
                PMNSNormalController PMNSNormalControllerSys = new PMNSNormalController();
                PMNSNormalControllerSys.SendDisplay = true;
                return PMNSNormalControllerSys;
            }
            // --- ADD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // 起動パラメータ："/A"
            if (commandLineArgs[0].Equals(PMNS_PARAMETER_KEYWORD))
            {
                //>>>2010/04/08
                //// 2010/03/15 Add >>>
                ////return new PMNSBatchController();   // 送信起動モード(起動：PM.NS)
                //int acptAnOdrStatus = 0;
                //string salesSlipNum = string.Empty;
                //if (commandLineArgs.Length > 1)
                //{
                //    string[] prm = ( commandLineArgs[1] ).Split(':');
                //    if (prm.Length > 1)
                //    {
                //        acptAnOdrStatus = TStrConv.StrToIntDef(prm[0].Trim(), 0);
                //        salesSlipNum = prm[1];
                //    }
                //}
                //PMNSBatchController ctlr = new PMNSBatchController();
                //ctlr.AcptAnOdrStatus = acptAnOdrStatus;
                //ctlr.SalesSlipNum = salesSlipNum;

                //return ctlr;   // 送信起動モード(起動：PM.NS)
                //// 2010/03/15 Add <<<

                Int64 inquiryNumber = 0;
                int inqOrdDivCd = 0;
                // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------>>>>>
                List<string> salesSlipNumList = new List<string>();
                // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------<<<<<
                if (commandLineArgs.Length > 1)
                {
                    string[] prm = (commandLineArgs[1]).Split(':');
                    if (prm.Length > 1)
                    {
                        Int64 outPrm0;
                        Int64.TryParse(prm[0].Trim(), out outPrm0);
                        inquiryNumber = outPrm0;
                        inqOrdDivCd = TStrConv.StrToIntDef(prm[1].Trim(), 0);
                        // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------>>>>>
                        if (prm.Length == 3)
                        {
                            if (prm[2].Trim().Length != 0)
                            {
                                string[] numList = (prm[2].Trim()).Split(',');
                                if (numList.Length != 0)
                                {
                                    for (int i = 0; i < numList.Length; i++)
                                    {
                                        if (numList[i] != null && numList[i].Trim().Length != 0)
                                        {
                                            salesSlipNumList.Add(numList[i].Trim());
                                        }
                                    }
                                }
                            }
                        }
                        // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------<<<<<
                    }
                }
                PMNSBatchController ctlr = new PMNSBatchController();
                ctlr.InquiryNumber = inquiryNumber;
                ctlr.InqOrdDivCd = inqOrdDivCd;
                // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------>>>>>
                ctlr.SalesSlipNumList = salesSlipNumList;
                // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------<<<<<
                // ADD 2013/08/28 吉岡 タブレット 送信中ウィンドウ非表示 ---------->>>>>>>>>>
                // タブレットからの起動の場合のみセットする
                if (commandLineArgs.Length > 2 && commandLineArgs[2] == SCMSendController.CMD_LINE_FOR_PMSCM01100_TABLET)
                {
                    ctlr.CmdLineTablet = SCMSendController.CMD_LINE_FOR_PMSCM01100_TABLET;
                }
                // ADD 2013/08/28 吉岡 タブレット 送信中ウィンドウ非表示 ----------<<<<<<<<<<
                return ctlr;   // 送信起動モード(起動：PM.NS)
                //<<<2010/04/08
            }

            // 起動パラメータ："/B"
            if (commandLineArgs.Length.Equals(1) && commandLineArgs[0].Equals(PM7_PARAMETER_KEYWORD))
            {
                return new PM7NormalController();
            }

            // DEL 2010/06/22 NS待機処理対応 ---------->>>>>
            //// 起動パラメータ："/B 得意先コード 伝票番号 伝票種別 サーバー番号"
            //if (commandLineArgs.Length.Equals(5) && commandLineArgs[0].Equals(PM7_PARAMETER_KEYWORD))
            //{
            //    return new PM7BatchController(commandLineArgs);
            //}
            // DEL 2010/06/22 NS待機処理対応 ----------<<<<<
            // ADD 2010/06/22 NS待機処理対応 ---------->>>>>
            // 起動パラメータ："/B 送信データパス（通常は SCM全体設定マスタ.旧システム連携フォルダ + \Send）"
            if (commandLineArgs.Length.Equals(2) && commandLineArgs[0].Equals(PM7_PARAMETER_KEYWORD))
            {
                return new PM7BatchController(commandLineArgs[1]);
            }
            // ADD 2010/06/22 NS待機処理対応 ----------<<<<<

            // それ以外はPMNS単体起動
            return new PMNSNormalController();
        }

        #region <PM7用>

        /// <summary>
        /// PM7用のコマンドであるか判断します。
        /// </summary>
        /// <param name="commandLineArgs">コマンドライン引数</param>
        /// <returns>
        /// <c>true</c> :PM7用のコマンドです。<br/>
        /// <c>false</c>:PM7用のコマンドではありません。
        /// </returns>
        private static bool IsPM7Mode(string[] commandLineArgs)
        {
            return Array.Exists(commandLineArgs, delegate(string commandLineArg)
            {
                return commandLineArg.Equals(PM7_PARAMETER_KEYWORD);
            });
        }

        /// <summary>
        /// PM7用送信起動モードのコマンドであるか判断します。
        /// </summary>
        /// <param name="commandLineArgs">コマンドライン引数</param>
        /// <returns>
        /// <c>true</c> :PM7用送信起動モードのコマンドです。<br/>
        /// <c>false</c>:PM7用送信起動モードのコマンドではありません。
        /// </returns>
        public static bool IsPM7BatchMode(string[] commandLineArgs)
        {
            if (IsPM7Mode(commandLineArgs))
            {
                int index = Array.IndexOf(commandLineArgs, PM7_PARAMETER_KEYWORD) + 1;
                if (commandLineArgs.Length > index)
                {
                    string parameter = commandLineArgs[index];
                    return Directory.Exists(parameter);
                }
            }
            return false;
        }

        /// <summary>
        /// PM7用送信起動モードでSCM Webサーバへ送信します。
        /// </summary>
        /// <param name="answerDataPath">回答データの保存パス</param>
        /// <remarks>
        /// 回答送信用ログファイルのオープンにより、単体起動モードが送信中であるか判定しています。
        /// 送信中である場合、処理を中断します。
        /// </remarks>
        /// <returns>結果コード</returns>
        public static int SendToWebServerByPM7BatchMode(string answerDataPath)
        {
            const string METHOD_NAME = "SendToWebServerByPM7BatchMode()";   // ログ用

            #region <Log>

            string start = "PM7送信起動モードで回答送信処理を行います。";
            SimpleLogger.Write(MY_NAME, METHOD_NAME, MsgHelper.GetStartMsg(start));
            #endregion // </Log>

            SCMSendController sender = new PM7BatchController(answerDataPath);
            {
                try
                {
                    // TODO:ゴミ掃除…ログファイルは存在しなければ作成するのでボツ
                    #region <ボツ>
                    //// ログファイルをチェック
                    //if (!File.Exists(sender.LogFilePath))
                    //{
                    //    #region <Log>

                    //    string msg = string.Format("ログファイルが存在しませんでした。(ファイルパス@{0})", sender.LogFilePath);
                    //    SimpleLogger.Write(MY_NAME, METHOD_NAME, MsgHelper.GetErrorMsg(msg, (int)ResultUtil.ResultCode.Error));

                    //    #endregion // </Log>

                    //    return (int)ResultUtil.ResultCode.Error;
                    //}
                    #endregion // </ボツ>

                    // ログファイルをオープン
                    int status = sender.OpenLog();
                    if (!status.Equals((int)ResultUtil.ResultCode.Normal))
                    {
                        #region <Log>

                        string abort = "単体起動モードで送信中等により、ログファイルをオープンできませんでしたので、回答送信処理を中断しました。";
                        SimpleLogger.Write(MY_NAME, METHOD_NAME, MsgHelper.GetInfoMsg(abort));

                        #endregion // </Log>

                        return (int)ResultUtil.ResultCode.Abort;
                    }

                    // 得意先情報をチェック
                    string customerDataFile = Path.Combine(answerDataPath, PM7IOAgent.CUSTOMER_LIST_FILE_NAME);
                    if (!File.Exists(customerDataFile))
                    {
                        string msg = string.Format(
                            "得意先データファイルが存在しないので、処理を中断しました；{0}",
                            customerDataFile
                        );
                        sender.WriteLog(Environment.NewLine + msg + Environment.NewLine);
                        return (int)ResultUtil.ResultCode.Abort;
                    }

                    // SCM Webサーバへ送信
                    status = sender.Send();
                    Debug.WriteLine("処理結果=" + status.ToString());

                    #region <Log>

                    string end = "PM7送信起動モードで回答送信処理を行いました。";
                    SimpleLogger.Write(MY_NAME, METHOD_NAME, MsgHelper.GetEndMsg(end, status));

                    #endregion // </Log>

                    return status;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());

                    #region <Log>

                    string err = "PM7送信起動モードで回答送信処理中に例外が発生しました。";
                    MsgHelper.WriteExceptionLog(MY_NAME, METHOD_NAME, err, ex);

                    #endregion // </Log>

                    return (int)ResultUtil.ResultCode.Error;
                }
                finally
                {
                    // ログファイルをクローズ
                    if (sender != null) sender.CloseLog();
                }
            }
        }

        #endregion // </PM7用>
    }
}
