//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコード更新処理（自動）
// プログラム概要   : 商品バーコード更新処理（自動）エントリポイント実装クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00  作成担当 : 30757 佐々木貴英
// 作 成 日  2017/09/20   修正内容 : ハンディターミナル二次対応（新規作成）
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
//using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Diagnostics;
using System.Reflection;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品バーコード更新処理（自動）メイン エントリ ポイント実装クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード更新処理（自動）のメイン エントリ ポイントを実装するクラスの定義と実装</br>
    /// <br>Programmer : 30757　佐々木　貴英</br>
    /// <br>Date       : 2017/09/20</br>
    /// </remarks>
    static class Program
    {
        #region 型宣言

        /// <summary>
        /// オプション有効有無区分列挙体
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効</summary>
            OFF = 0,
            /// <summary>有効</summary>
            ON = 1,
        };

        /// <summary>
        /// 商品バーコード更新処理（手動）ＵＩ独自の結果ステータス列挙体
        /// </summary>
        public enum StatusCode
        {
            /// <summary>成功</summary>
            Normal = 0
          , /// <summary>ハンディーターミナルOPバーコード提供オプション無効</summary>
            OptPmHndBarcodeOfferInvalid = -1
          , /// <summary>致命的エラー</summary>
            Error = -1000
        };

        #endregion //型宣言

        #region 定数定義
        /// <summary>
        /// USER_APレジストリキー　ルート
        /// </summary>
        private static readonly string RegistryKeyUSER_APMain = @"SOFTWARE\Broadleaf\Service\Partsman\USER_AP";

        /// <summary>
        /// USER_APレジストリキー　作業パス
        /// </summary>
        private static readonly string RegistryKeyUSER_APInstallDirectory = "InstallDirectory";

        /// <summary>
        /// 作業パスデフォルト
        /// </summary>
        private static readonly string WorkingDirDefault = @"C:\Program Files\Partsman\USER_AP";

        /// <summary>
        /// 操作ログ　開始
        /// </summary>
        private static readonly string OperationLogTextAutoStart = "自動起動";

        /// <summary>
        /// 操作ログ　終了
        /// </summary>
        private static readonly string OperationLogTextAutoEnd = "終了（自動起動時）";

        /// <summary>
        /// テキストログ　自動起動処理開始
        /// </summary>
        private static readonly string LoggingTextMainStart = "PMHAND09410U.exe　Main() ";

        /// <summary>
        /// テキストログ　ログイン情報取得成功
        /// </summary>
        private static readonly string LoggingTextGetLoginInfoSuccess = "ログイン情報取得成功 ";

        /// <summary>
        /// テキストログ　ログイン情報取得失敗
        /// </summary>
        private static readonly string LoggingTextGetLoginInfoFailed = "ログイン情報取得失敗 ";

        /// <summary>
        /// テキストログ　ログイン情報取得例外
        /// </summary>
        private static readonly string LoggingTextGetLoginInfoException = "catch() ログイン情報取得失敗 ";

        /// <summary>
        /// テキストログ　自動起動処理成功
        /// </summary>
        private static readonly string LoggingTextAutoExecuteSuccess = "自動起動処理成功 ";

        /// <summary>
        /// テキストログ　自動起動処理失敗
        /// </summary>
        private static readonly string LoggingTextAutoExecuteFailed = "自動起動処理失敗 ";

        /// <summary>
        /// テキストログ　自動起動処理例外
        /// </summary>
        private static readonly string LoggingTextAutoExecuteException = "catch() 自動起動処理失敗 ";

        /// <summary>
        /// 自動起動処理その他エラー発生時ログテキスト
        /// </summary>
        private static readonly string LoggingTextAutoExecuteError = "自動起動処理でエラーが発生しました";

        /// <summary>
        /// ハンディターミナルOPバーコード提供オプション無効時ログテキスト
        /// </summary>
        private static readonly string LoggingTextOptPmHndBarcodeOfferInvalid = "ハンディターミナルOPバーコード提供オプションが無効です";

        /// <summary>
        /// エラーメッセージ：処理件数超過
        /// </summary>
        private static readonly string UpdateResultTextReadCountMaxOrver = "処理対象が2万件を超えました、条件を変更して再度処理を行ってください。";

        /// <summary>
        /// エラーメッセージ：処理失敗
        /// </summary>
        private static readonly string UpdateResultTextError = "商品バーコード更新処理（手動）に失敗しました。";

        #endregion //定数定義

        #region メンバーフィールド
        /// <summary>
        /// 起動パラメータ一時保持領域
        /// </summary>
        private static string[] ExecParameter;
        #endregion //メンバーフィールド

        /// <summary>
        /// 商品バーコード更新処理（自動）メイン エントリ ポイント
        /// </summary>
        /// <param name="args">起動パラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品バーコード更新処理の起動時に実行されるメイン エントリ ポイント</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        [STAThread]
        static void Main(String[] args)
        {
            int status = (int)Program.StatusCode.Error;
            string msg = string.Empty;
            string workDir = null;

            Program.ExecParameter = args;

            // レジストリキー取得
            RegistryKey key = Registry.LocalMachine.OpenSubKey( Program.RegistryKeyUSER_APMain );

            // 作業ディレクトリ取得
            if (key == null) // あってはいけないケース
            {
                workDir = Program.WorkingDirDefault; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
            }
            else
            {
                workDir = key.GetValue( Program.RegistryKeyUSER_APInstallDirectory, Program.WorkingDirDefault ).ToString();
            }

            // テキストログ書込み (Main())
            Program.WriteAutoexcuteLog( workDir, new string[] { Program.LoggingTextMainStart } );

            try
            {
                System.IO.Directory.SetCurrentDirectory( workDir );
                //アプリケーション開始準備処理
                //第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                status = ServerApplicationMethodCallControl.StartApplication(
                        out msg, ref ExecParameter, ConstantManagement_SF_PRO.ProductCode );

                if (status != (int)Program.StatusCode.Normal)
                {
                    // テキストログ書込み (ログイン情報取得失敗)
                    Program.WriteAutoexcuteLog(
                          workDir, Program.LoggingTextGetLoginInfoFailed, msg, status, true, true, true );
                }
                else
                {
                    // テキストログ書込み (ログイン情報取得成功)
                    Program.WriteAutoexcuteLog( workDir, new string[] { Program.LoggingTextGetLoginInfoSuccess } );
                }

            }
            catch (Exception ex)
            {
                // テキストログ書込み (ログイン情報取得失敗　例外)
                status = (int)Program.StatusCode.Error;
                Program.WriteAutoexcuteLog(
                      workDir, Program.LoggingTextGetLoginInfoException, ex, status, true, true, false );
            }

            try
            {
                if (status == (int)Program.StatusCode.Normal)
                {
                    status = Program.UpdatPrmGoodsBrcdList(); // 自動起動時処理

                    if (status == (int)Program.StatusCode.Normal)
                    {
                        Program.WriteAutoexcuteLog( workDir, new string[] { Program.LoggingTextAutoExecuteSuccess } );
                    }
                    else if (status == (int)Program.StatusCode.OptPmHndBarcodeOfferInvalid)
                    {
                        // テキストログ書込み (ハンディターミナルOPバーコード提供オプション無効)
                        Program.WriteAutoexcuteLog(
                              workDir
                            , Program.LoggingTextAutoExecuteFailed
                            , Program.LoggingTextOptPmHndBarcodeOfferInvalid
                            , status
                            , false
                            , true
                            , false );
                    }
                    else
                    {
                        // テキストログ書込み (自動起動処理失敗)
                        Program.WriteAutoexcuteLog(
                              workDir
                            , Program.LoggingTextAutoExecuteFailed
                            , Program.LoggingTextAutoExecuteError
                            , status
                            , false
                            , true
                            , true );
                    }
                }
            }
            catch (Exception ex)
            {
                // テキストログ書込み (自動起動処理失敗　例外)
                Program.WriteAutoexcuteLog(
                    workDir, Program.LoggingTextAutoExecuteException, ex, (int)Program.StatusCode.Error, false, true, false );
            }
        }

        /// <summary>
        /// 商品バーコード更新処理（自動）実体
        /// </summary>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 自動起動時の商品バーコード更新処理（自動）を実行</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private static int UpdatPrmGoodsBrcdList()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //オプション判定
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps = 
                LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_HND_BarcodeOffer );
            if (ps != Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                return (int)Program.StatusCode.OptPmHndBarcodeOfferInvalid;
            }

            //機能名の取得
            System.Reflection.AssemblyTitleAttribute assemblyTitle =
                (AssemblyTitleAttribute)Attribute.GetCustomAttribute( Assembly.GetExecutingAssembly(), typeof( AssemblyTitleAttribute ) );
            string assemblyTitleStr = assemblyTitle.Title;


            PrmGoodsBarCodeRevnUpdateAcs PrmGoodsBrcdAcs = new PrmGoodsBarCodeRevnUpdateAcs();


            PrmGoodsBrcdAcs.WriteOperationLog( Program.OperationLogTextAutoStart, Program.OperationLogTextAutoStart, string.Empty );
            try
            {
                // 抽出条件設定
                PrmGoodsBrcdUpdateParamWork updateParam = new PrmGoodsBrcdUpdateParamWork();
                updateParam.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                updateParam.MakerCdST = PrmGoodsBarCodeRevnUpdateAcs.PrmMakerCodeMinimum;
                updateParam.MakerCdED = PrmGoodsBarCodeRevnUpdateAcs.PrmMakerCodeMaximum;
                updateParam.BarcodeUpdateKndDiv = (int)PrmGoodsBarCodeRevnUpdateAcs.BarcodeUpdateKndDiv.WithoutUserUpdate;
                updateParam.GoodMGroup = 0;
                updateParam.BLGoodsCode = 0;
                updateParam.UpdEmployeeCode = string.Empty;
                updateParam.RecordCnt = 0;

                status = PrmGoodsBrcdAcs.Update( ref updateParam, true );
                string logDataMessage = PrmGoodsBrcdAcs.CreateUpdateLogText( ref updateParam );
                PrmGoodsBrcdAcs.WriteOperationLog( assemblyTitleStr, logDataMessage, string.Empty );

                if (status == (int)PrmGoodsBarCodeRevnUpdateAcs.StatusCode.ReadCountMaxOrver)
                {
                    // 処理件数オーバー
                    Program.WriteErrorLog( null, Program.UpdateResultTextReadCountMaxOrver, status );
                }
                else if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND && status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 処理件数オーバー以外のエラー
                    Program.WriteErrorLog( null, Program.UpdateResultTextError, status );
                }
            }
            catch (Exception exp)
            {
                // 例外エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                Program.WriteErrorLog( exp, Program.UpdateResultTextError, status );
            }
            finally
            {
                PrmGoodsBrcdAcs.WriteOperationLog( Program.OperationLogTextAutoEnd, Program.OperationLogTextAutoEnd, string.Empty );
            }

            return status;
        }

        #region PM.NSログ
        /// <summary>
        /// クライアントログ出力
        /// </summary>
        /// <param name="ex">例外</param>
        /// <param name="errorText">エラーメッセージ</param>
        /// <param name="status">処理ステータス</param>
        /// <remarks>
        /// <br>Note       : クライアントログにログを出力する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private static void WriteErrorLog( Exception ex, string errorText, int status )
        {
            ClientLogTextOut clientLogTextOut = new ClientLogTextOut();
            if (ex != null)
            {
                string message = string.Concat( new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" } );
                clientLogTextOut.Output( ex.Source, message, status, ex );
            }
            else
            {
                clientLogTextOut.Output( Type.GetType("Program").Assembly.GetName().Name, errorText, status );
            }
        }
        #endregion //PM.NSログ

        #region テキストログ出力処理

        /// <summary>
        /// テキストログ出力処理
        /// </summary>
        /// <param name="workDir">作業ディレクトリ</param>
        /// <param name="caption">ログキャプション</param>
        /// <param name="errMessage">エラーメッセージとして出力するオブジェクト</param>
        /// <param name="status">ステータス</param>
        /// <param name="doWriteParam">起動パラメータを出力するか否かを指定</param>
        /// <param name="doWriteProductCode">プロダクトコードを出力するか否かを指定</param>
        /// <param name="doWriteStatus">statusにセットされた値を出力するか否かを指定</param>
        /// <remarks>
        /// <br>Note       : USER_APワークパス下の\Log\PMCMN06200S\PrmGoodsBarcodeUpdate.txtに商品バーコード更新処理メインプロセス用ログを出力</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private static void WriteAutoexcuteLog(
              string workDir
            , string caption
            , object errMessage
            , int status
            , bool doWriteParam
            , bool doWriteProductCode
            , bool doWriteStatus)
        {
            const string LogSubTitleError = " エラーメッセージ ";
            const string LogSubTitleParam = " パラメーター ";
            const string LogSubTitleProductCode = " プロダクトコード ";
            const string LogSubTitleStatus = " ステータス ";
            const string logTextSpaceText = " ";

            try
            {
                List<string> logTextList = new List<string>();
                logTextList.Add( caption );
                if ( errMessage != null && !string.IsNullOrEmpty(errMessage.ToString()))
                {
                    logTextList.Add( LogSubTitleError + errMessage.ToString());
                }
                if ( doWriteParam )
                {
                    string parmMsg = string.Empty;
                    foreach (string param in Program.ExecParameter)
                    {
                        parmMsg += param + logTextSpaceText;
                    }
                    logTextList.Add( LogSubTitleParam + parmMsg);
                }
                if ( doWriteProductCode )
                {
                    logTextList.Add( LogSubTitleProductCode + ConstantManagement_SF_PRO.ProductCode);
                }
                if ( doWriteStatus )
                {
                    logTextList.Add( LogSubTitleStatus + status.ToString());
                }
                Program.WriteAutoexcuteLog(workDir, logTextList.ToArray() );
            }
            catch
            {
                // ログ出力による例外は無視
            }
        }

        /// <summary>
        /// テキストログ出力処理
        /// </summary>
        /// <param name="workDir">作業ディレクトリ</param>
        /// <param name="logText">ログ出力テキスト配列</param>
        /// <remarks>
        /// <br>Note       : USER_APワークパス下の\Log\PMCMN06200S\PrmGoodsBarcodeUpdate.txtに商品バーコード更新処理メインプロセス用ログを出力</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private static void WriteAutoexcuteLog( string workDir, string[] logTextArray )
        {
            const string logWritePathPrefix = @"";
            const string logWritePath = @"\Log\PMCMN06200S";
            const string logFileName = @"\PrmGoodsBarcodeUpdate.txt";
            const string logTextSpaceText = " ";
            const string logTextNewLine = "\r\n";

            try
            {
                string writePath = logWritePathPrefix + workDir + logWritePath;
                if (!Directory.Exists( writePath ))
                {
                    //ログ出力パスが生成されていなかった場合生成する
                    Directory.CreateDirectory( writePath );
                }
                StringBuilder logText = new StringBuilder();
                foreach (string text in logTextArray)
                {
                    if (string.IsNullOrEmpty( text ))
                        continue;
                    if (logText.Length > 0)
                        logText.AppendLine();
                    logText.Append( text );
                }

                StreamWriter writer = new StreamWriter(
                    writePath + logFileName, true, System.Text.Encoding.GetEncoding( "shift-jis" ) );
                writer.Write( DateTime.Now + logTextSpaceText + logText.ToString() + logTextNewLine );
                writer.Flush();
                if (writer != null) 
                    writer.Close();
            }
            catch
            {
                // ログ出力による例外は無視
            }
        }

        #endregion //テキストログ出力処理
    }
}