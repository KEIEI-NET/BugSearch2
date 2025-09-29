using System;
using Broadleaf.Application.Remoting;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Diagnostics;
using System.Text;
using System.Net;
using Microsoft.VisualBasic.Devices;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// Windows API コールバック関数定義
    /// </summary>
    /// <remarks>
    /// <br>Note       : Windows API コールバック関数定義をするクラスです。</br>
    /// <br>Programmer : </br>
    /// <br>Date       : 2020/06/15</br>
    /// </remarks>
    public class ExeConvert : RemoteDB
    { 
        #region プライベート変数

        /// <summary>企業コード</summary>
        private string _enterpriseCode;

        /// <summary>商品コード</summary>
        private string _goodsNo;

        /// <summary>商品メーカーコード</summary>
        private int _goodsMakerCd;

        /// <summary>変換前パラメータ</summary>
        private double _convertSetParam;

        /// <summary>変換後パラメータ</summary>
        private double _convertGetParam;

        /// <summary>コンバート対象管理１</summary>
        private ConvertVersionSettingOne _convertVersionSettingOne;

        /// <summary>コールバック関数戻りステータス</summary>
        private int _callBackStatus;

        #endregion // プライベート変数

        #region 定数

        /// <summary>
        /// CLCログファイル名
        /// </summary>
        private const string CLCLogFileName = "PMCMN00120C_{0}_{1}.log";

        /// <summary>
        /// CLCログファイル名(検索用)
        /// </summary>
        private const string CLCLogFileNameSearch = "PMCMN00120C_{0}_{1}";

        /// <summary>
        /// CLCログファイル名
        /// </summary>
        private const string CLCLogErrMsg = "{0},status={1},EnterpriseCode={2},GoodsMakerCd={3},GoodsNo={4},ConvertSetParam={5},ConvertGetParam={6}";

        /// <summary>
        /// PC（ログ出力）
        /// </summary>
        private const string LOGOUTPUT_INFO_PC = "PC={0},";

        /// <summary>
        /// IPアドレス
        /// </summary>
        private const string LOGOUTPUT_INFO_IP = "IP={0},";

        /// <summary>
        /// メモリ使用量/容量 （ログ出力）
        /// </summary>
        private const string LOGOUTPUT_INFO_MEM = "MEM(MB)={0},";

        /// <summary>
        /// 情報取得失敗 （ログ出力）
        /// </summary>
        private const string LOGOUTPUT_NA = "NA";

        /// <summary>
        /// 情報取得例外 （ログ出力）
        /// </summary>
        private const string LOGOUTPUT_EXNA = "EXNA";

        /// <summary>
        /// ログ出力内容
        /// </summary>
        private const string LOGOUTPUT_MESSAGE = "{0} Process={1},SYSINFO:{2}";

        /// <summary>
        /// スタックフレーム初期値
        /// ReleaseProc、ConvertProc、ReleaseProcDirect、ConvertProcDirectよりログ出力する場合
        /// </summary>
        private const int FRAME_DEFAULT = 7;

        /// <summary>
        /// スタックフレーム
        /// ExecuteConvert、ExecuteConvertよりログ出力する場合
        /// </summary>
        private const int FRAME_EXECUTECONVERT = 6;

        #endregion // 定数

        #region API使用定数

        const uint COLOR_WINDOW = 5;

        const uint CS_VREDRAW = 0x0001;
        const uint CS_HREDRAW = 0x0002;

        const int CW_USEDEFAULT = -2147483648; // ((uint)0x80000000)

        const int IDC_ARROW = 32512;

        const int IDI_APPLICATION = 32512;

        const uint WM_CREATE = 0x0001;
        const uint WM_PAINT = 0x000F;

        const uint WS_OVERLAPPED = 0x00000000;
        const uint WS_POPUP = 0x80000000;
        const uint WS_CHILD = 0x40000000;
        const uint WS_MINIMIZE = 0x20000000;
        const uint WS_VISIBLE = 0x10000000;
        const uint WS_DISABLED = 0x08000000;
        const uint WS_CLIPSIBLINGS = 0x04000000;
        const uint WS_CLIPCHILDREN = 0x02000000;
        const uint WS_MAXIMIZE = 0x01000000;
        const uint WS_CAPTION = 0x00C00000; // WS_BORDER | WS_DLGFRAME
        const uint WS_BORDER = 0x00800000;
        const uint WS_DLGFRAME = 0x00400000;
        const uint WS_VSCROLL = 0x00200000;
        const uint WS_HSCROLL = 0x00100000;
        const uint WS_SYSMENU = 0x00080000;
        const uint WS_THICKFRAME = 0x00040000;
        const uint WS_GROUP = 0x00020000;
        const uint WS_TABSTOP = 0x00010000;

        const uint WS_MINIMIZEBOX = 0x00020000;
        const uint WS_MAXIMIZEBOX = 0x00010000;

        const uint WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX;

        #endregion // API使用定数

        #region API定義

        /// <summary>
        /// ウィンドウクラス登録
        /// </summary>
        /// <param name="pcWndClassEx"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern short RegisterClassEx(ref WNDCLASSEX pcWndClassEx);

        /// <summary>
        /// ウィンドウ作成
        /// </summary>
        /// <param name="dwExStyle"></param>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <param name="dwStyle"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
        /// <param name="hWndParent"></param>
        /// <param name="hMenu"></param>
        /// <param name="hInstance"></param>
        /// <param name="lpParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr CreateWindowEx(uint dwExStyle, string lpClassName, string lpWindowName, uint dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

        /// <summary>
        /// 標準ウィンドウ処理
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="uMsg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// アイコン読み込み
        /// </summary>
        /// <param name="hInstance"></param>
        /// <param name="lpIconName"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);

        /// <summary>
        /// ウィンドウ削除
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern bool DestroyWindow(IntPtr hWnd);

        /// <summary>
        /// ウィンドウクラス登録解除
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern bool UnregisterClass(string lpClassName, IntPtr hInstance);

        #endregion // API定義

        #region API使用構造体定義

        /// <summary>
        /// コールバック関数定義
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="uMsg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        delegate IntPtr WndProcDelgate(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// ウィンドウクラス作成構造体
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct WNDCLASSEX
        {
            public uint cbSize;
            public uint style;
            public WndProcDelgate lpfnWndProc;
            public Int32 cbClsExtra;
            public Int32 cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public string lpszMenuName;
            public string lpszClassName;
            public IntPtr hIconSm;
        }

        #endregion // API使用構造体定義

        #region 列挙体

        private enum StatusCode
        {
            /// <summary>成功</summary>
            Normal = 0
          , /// <summary>成功（コンバートなし）</summary>
            NormalNotFound = 4
          , /// <summary>変換テーブルインスタンス生成</summary>
            TableCreate = 2000
          , /// <summary>自インスタンスハンドル取得</summary>
            GetHandle = 2010
          , /// <summary>ウィンドウクラス登録用構造体設定</summary>
            RegistStructSet = 2020
          , /// <summary>ウィンドウクラス登録</summary>
            RegistClass = 2030
          , /// <summary>ウィンドウ作成</summary>
            CreateWindow = 2040
          , /// <summary>ウィンドウ削除</summary>
            DestroyWindow = 2050
          , /// <summary>ウィンドウクラス登録解除</summary>
            UnregisterClass = 2060
        };

        #endregion // 列挙体

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ExeConvert()
        {
            // 初期値セット
            _enterpriseCode = string.Empty;
            _goodsNo = string.Empty;
            _goodsMakerCd = int.MinValue;
            _convertSetParam = int.MinValue;
            _convertGetParam = int.MinValue;
            
        }

        #endregion // コンストラクタ

        #region プロパティ

        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// 商品メーカーコード
        /// </summary>
        public int GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// <summary>
        /// 商品番号
        /// </summary>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// <summary>
        /// 変換前パラメータ
        /// </summary>
        public double ConvertSetParam
        {
            get { return this._convertSetParam; }
            set { this._convertSetParam = value; }
        }

        /// <summary>
        /// 変換後パラメータ
        /// </summary>
        public double ConvertGetParam
        {
            get { return this._convertGetParam; }
            set { this._convertGetParam = value; }
        }

        #endregion

        #region publicメソッド
        
        /// <summary>
        /// 変換解除処理
        /// </summary>
        /// <param name="procCls">0:解除、1:変換</param>
        /// <returns>実行ステータス</returns>
        /// <remarks>
        /// <br>Note       : 変換解除処理を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ExecuteConvert(int procCls)
        {
            int status = (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;
            int lastError = 0; // 初期値：エラーなし
            string errMsg = string.Empty;
            IntPtr hInstance = IntPtr.Zero;
            IntPtr hWnd = IntPtr.Zero;
            int procStatus = (int)StatusCode.Normal;
            string windowClassName = Guid.NewGuid().ToString();
            string windowName = Guid.NewGuid().ToString();
            
#if DEBUG
            ClcLogOutput("Call ExeConvert.ExecuteConvert", FRAME_EXECUTECONVERT, true);
#endif

            try
            {
                if (_convertVersionSettingOne == null)
                {
                    // 変換テーブルのインスタンス生成
                    procStatus = (int)StatusCode.TableCreate;

                    _convertVersionSettingOne = new ConvertVersionSettingOne();
                }

                // 自インスタンスハンドル取得
                procStatus = (int)StatusCode.GetHandle;

                hInstance = Marshal.GetHINSTANCE(typeof(ExeConvert).Module);

                // ウィンドウクラス登録用構造体設定
                procStatus = (int)StatusCode.RegistStructSet;

                WNDCLASSEX wcex = new WNDCLASSEX();
                wcex.cbSize = (uint)Marshal.SizeOf(wcex);
                wcex.style = CS_HREDRAW | CS_VREDRAW;

                if (procCls == (int)ConvertVersionSetting.ProcCls.CT_PROC_CONVERT)
                {
                    // 変換
                    wcex.lpfnWndProc = new WndProcDelgate(ConvertProc);
                }
                else
                {
                    // 解除
                    wcex.lpfnWndProc = new WndProcDelgate(ReleaseProc);
                }

                wcex.cbClsExtra = 0;
                wcex.cbWndExtra = 0;
                wcex.hInstance = hInstance;
                wcex.hIcon = LoadIcon(hInstance, new IntPtr(IDI_APPLICATION));
                wcex.hCursor = LoadIcon(hInstance, new IntPtr(IDC_ARROW));
                wcex.hbrBackground = new IntPtr(COLOR_WINDOW + 1);
                wcex.lpszMenuName = "";
                wcex.lpszClassName = windowClassName;
                wcex.hIconSm = IntPtr.Zero;

                // ウィンドウクラス登録
                procStatus = (int)StatusCode.RegistClass;

                short rceRet = RegisterClassEx(ref wcex);

                if (rceRet == 0)
                {
                    // エラー発生時は処理中断
                    // エラー取得
                    lastError = Marshal.GetLastWin32Error();

                    if (lastError == 0)
                    {
                        errMsg = "WAC.EC RCEError";
                    }
                    else
                    {
                        errMsg = "WAC.EC RCEError LastError：" + lastError.ToString();
                    }

                    //ログ出力
                    WriteErrorLogProc(errMsg);
                }

                // ウィンドウ作成
                procStatus = (int)StatusCode.CreateWindow;

                // コールバックステータスの初期化
                _callBackStatus = (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

                // コールバック関数が呼び出される
                hWnd = CreateWindowEx(
                    0,
                    windowClassName,
                    windowName,
                    WS_OVERLAPPEDWINDOW,
                    CW_USEDEFAULT,
                    CW_USEDEFAULT,
                    CW_USEDEFAULT,
                    CW_USEDEFAULT,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    hInstance,
                    IntPtr.Zero);

                if (hWnd == IntPtr.Zero)
                {
                    // エラー発生時
                    // エラー取得
                    lastError = Marshal.GetLastWin32Error();

                    if (lastError == 0)
                    {
                        errMsg = "WAC.EC CWEError";
                    }
                    else
                    {
                        errMsg = "WAC.EC CWEError LastError：" + lastError.ToString();
                    }

                    //ログ出力
                    WriteErrorLogProc(errMsg);
                }

                // コールバック関数のステータスを返却する
                status = _callBackStatus;
            }
            catch (Exception ex)
            {
                //ログ出力
                WriteErrorLogProc(ex, "WAC.EC procStatus=" + procStatus.ToString());
            }
            finally
            {
                if (hWnd != IntPtr.Zero)
                {
                    // ウィンドウ削除
                    DestroyWindow(hWnd);
                }

                if (hInstance != IntPtr.Zero)
                {
                    // ウィンドウクラス登録解除
                    UnregisterClass(windowClassName, hInstance);
                }
            }

            return status;
        }

        /// <summary>
        /// 変換解除処理
        /// </summary>
        /// <param name="procCls">0:解除、1:変換</param>
        /// <returns>実行ステータス</returns>
        /// <remarks>
        /// <br>Note       : 変換解除処理を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ExecuteConvertDirect(int procCls)
        {
            int status = (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;
            string errMsg = string.Empty;
            int procStatus = (int)StatusCode.Normal;

#if DEBUG
            ClcLogOutput("Call ExeConvert.ExecuteConvertDirect", FRAME_EXECUTECONVERT, true);
#endif

            try
            {
                if (_convertVersionSettingOne == null)
                {
                    // 変換テーブルのインスタンス生成
                    procStatus = (int)StatusCode.TableCreate;

                    _convertVersionSettingOne = new ConvertVersionSettingOne();
                }

                status = ExeConvertProc(procCls);
            }
            catch (Exception ex)
            {
                //ログ出力
                WriteErrorLogProc(ex, "Exeption ExeConvert.ExecuteConvertDirect procStatus=" + procStatus.ToString());
            }
            finally
            {
            }

            return status;
        }

        #endregion // publicメソッド

        #region privateメソッド

        /// <summary>
        /// 解除処理
        /// </summary>
        /// <returns>ウィンドウハンドル</returns>
        /// <remarks>
        /// <br>Note       : 解除処理を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private IntPtr ReleaseProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam)
        {
            try
            {
                switch (uMsg)
                {
                    case WM_CREATE:
                        // ウィンドウ作成時
                        // 解除処理
                        _callBackStatus = ExeConvertProc((int)ConvertVersionSetting.ProcCls.CT_PROC_RELEASE);

                        break;
                    default:
                        // ウィンドウ作成時以外はシステム標準ウィンドウ処理を実行する
                        return DefWindowProc(hWnd, uMsg, wParam, lParam);
                }
            }
            catch (Exception ex)
            {
                //ログ出力
                WriteErrorLogProc(ex, string.Format(CLCLogErrMsg, "EXP ExeConvert.ReleaseProc", _callBackStatus.ToString(), _enterpriseCode,
                                _goodsMakerCd, _goodsNo, _convertSetParam,
                                _convertVersionSettingOne.ConvertGetParam) + " uMsg=" + uMsg.ToString());
            }

            return IntPtr.Zero;
        }

        /// <summary>
        /// 変換処理
        /// </summary>
        /// <returns>ウィンドウハンドル</returns>
        /// <remarks>
        /// <br>Note       : 変換処理を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private IntPtr ConvertProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam)
        {
            try
            {
                switch (uMsg)
                {
                    case WM_CREATE:
                        // ウィンドウ作成時
                        // 変換処理
                        _callBackStatus = ExeConvertProc((int)ConvertVersionSetting.ProcCls.CT_PROC_CONVERT);

                        break;

                    default:
                        // ウィンドウ作成時以外はシステム標準ウィンドウ処理を実行する
                        return DefWindowProc(hWnd, uMsg, wParam, lParam);
                }
            }
            catch (Exception ex)
            {
                //ログ出力
                WriteErrorLogProc(ex, string.Format(CLCLogErrMsg, "EXP ExeConvert.ConvertProc", _callBackStatus.ToString(), _enterpriseCode,
                                _goodsMakerCd, _goodsNo, _convertSetParam,
                                _convertVersionSettingOne.ConvertGetParam) + " uMsg=" + uMsg.ToString());
            }

            return IntPtr.Zero;
        }

        /// <summary>
        /// 変換解除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 変換解除処理を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private int ExeConvertProc(int procCls)
        {
            int status = (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

            // 変換後値の初期化
            _convertGetParam = int.MinValue;

            try
            {
                // パラメータ設定
                _convertVersionSettingOne.EnterpriseCode = _enterpriseCode;
                _convertVersionSettingOne.GoodsMakerCd = _goodsMakerCd;
                _convertVersionSettingOne.GoodsNo = _goodsNo;
                _convertVersionSettingOne.ConvertSetParam = _convertSetParam;

                if (procCls == (int)ConvertVersionSetting.ProcCls.CT_PROC_CONVERT)
                {
                    // 変換
                    status = _convertVersionSettingOne.ConvertProc();
                }
                else
                {
                    // 解除
                    status = _convertVersionSettingOne.ReleaseProc();
                }

                if (status == (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_OK)
                {
                    // 変換値設定
                    _convertGetParam = _convertVersionSettingOne.ConvertGetParam;
                }
                else
                {
                    WriteErrorLogProc(string.Format(CLCLogErrMsg, "ERR ExeConvert.ExeConvertProc", status.ToString(), _enterpriseCode,
                        _goodsMakerCd, _goodsNo, _convertSetParam,
                        _convertVersionSettingOne.ConvertGetParam));
                }

            }
            catch (Exception ex)
            {
                //ログ出力
                WriteErrorLogProc(ex, string.Format(CLCLogErrMsg, "EXP ExeConvert.ExeConvertProc", status.ToString(), _enterpriseCode,
                    _goodsMakerCd, _goodsNo, _convertSetParam,
                    _convertVersionSettingOne.ConvertGetParam));
            }

            return status;
        }

        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="errorText"></param>
        /// <remarks>
        /// <br>Note       : ログ出力を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        internal void WriteErrorLogProc(string errorText)
        {
            try
            {
                base.WriteErrorLog(errorText);
                ClcLogOutput(errorText);
            }
            catch
            {
            }
            finally
            {
            }
        }

        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="errorText"></param>
        /// <remarks>
        /// <br>Note       : ログ出力を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        internal void WriteErrorLogProc(Exception ex, string errorText)
        {
            try
            {
                base.WriteErrorLog(ex, errorText);
                ClcLogOutput(errorText + "ex:" + ex.Message);
            }
            catch
            {
            }
            finally
            {
            }
        }

        #region CLCログ出力

        /// <summary>
        /// CLCログ出力
        /// </summary>
        /// <param name="message">ログメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        private void ClcLogOutput(string message)
        {
            ClcLogOutput(message, 7);
        }

        /// <summary>
        /// CLCログ出力
        /// </summary>
        /// <param name="message">ログメッセージ</param>
        /// <param name="frame">呼び出しフレーム</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        private void ClcLogOutput(string message, int frame)
        {
            ClcLogOutputProc(message, frame, false);
        }

        /// <summary>
        /// CLCログ出力
        /// </summary>
        /// <param name="message">ログメッセージ</param>
        /// <param name="frame">呼び出しフレーム</param>
        /// <param name="isappend">日単位で複数作成しない場合false</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        private void ClcLogOutput(string message, int frame, bool isappend)
        {
            ClcLogOutputProc(message, frame, isappend);
        }

        /// <summary>
        /// CLCログ出力
        /// </summary>
        /// <param name="message">ログメッセージ</param>
        /// <param name="frame">
        /// 呼び出しフレーム
        /// RelaseProc、ConvertProcが5
        /// </param>
        /// <param name="isappend">日単位で複数作成しない場合false</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        private void ClcLogOutputProc(string message, int frame, bool isappend)
        {
            try
            {
                DateTime now = DateTime.Now;

                string logFileName = string.Empty;

                KICLC00001C.LogHeader log = null;

                string clcFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Broadleaf\CLC\Service\Partsman\PMCMN00120C\");
                string clcFileName = string.Format(CLCLogFileNameSearch, DateTime.Now.ToString("yyyyMMdd"), "*");
                string[] clcFileFind = null;

                if (Directory.Exists(clcFilePath))
                {
                    clcFileFind = Directory.GetFiles(clcFilePath, clcFileName, SearchOption.TopDirectoryOnly);
                }

                if (clcFileFind == null || clcFileFind.Length == 0 || isappend)
                {
                    // 呼び元クラス名取得
                    string stack = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame(frame));

                    // 出力内容にシステム情報を付加する。
                    string logoutput = string.Format(LOGOUTPUT_MESSAGE, message, stack, GetSysInfo()) + clcFileFind.Length;

                    // メッセージ内の改行コードをスペースに変換
                    logoutput = logoutput.Replace("\r", "").Replace("\n", " ");

                    // ログファイル名称作成
                    // "日付_PMCMN00120C_"+DateTimeのTicks+Guid文字列
                    logFileName = string.Format(CLCLogFileName, DateTime.Now.ToString("yyyyMMdd"), Guid.NewGuid().ToString().Replace("-", ""));

                    // ProgramData側へログ出力
                    log = new KICLC00001C.LogHeader();
                    log.WriteServiceLogHeader(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, "PMCMN00120C", logFileName, logoutput);

                }
            }
            catch
            {
            }
            finally
            {
            }

        }

        #endregion // CLCログ出力


        #region システム情報取得
        /// <summary>
        /// システム情報取得
        /// </summary>
        /// <returns>システム情報文字列</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        private string GetSysInfo()
        {
            StringBuilder sysInfo = new StringBuilder();

            #region PC名取得
            try
            {
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_PC, Environment.MachineName));
            }
            catch
            {
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_PC, LOGOUTPUT_EXNA));
            }
            #endregion PC名取得

            #region IPアドレス取得
            try
            {
                IPAddress[] adrList = Dns.GetHostAddresses(Environment.MachineName);
                StringBuilder ipAddress = new StringBuilder();
                foreach (IPAddress address in adrList)
                {
                    ipAddress.Append(address.ToString());
                    ipAddress.Append(" ");
                }
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_IP, ipAddress.ToString()));
            }
            catch
            {
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_IP, LOGOUTPUT_EXNA));
            }
            #endregion PC名取得

            #region メモリ使用量取得
            try
            {
                ComputerInfo ci = new ComputerInfo();

                string avaliableMemory = (Convert.ToInt64(ci.AvailablePhysicalMemory.ToString()) / 1024 / 1024).ToString();
                string totalMemory = (Convert.ToInt64(ci.TotalPhysicalMemory.ToString()) / 1024 / 1024).ToString();

                string memUsageCap = string.Format("{0}/{1}", avaliableMemory, totalMemory);
                if (!string.IsNullOrEmpty(memUsageCap))
                {
                    // ログ出力内容格納
                    sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_MEM, memUsageCap));
                }
                else
                {
                    // ログ出力内容格納
                    sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_MEM, LOGOUTPUT_NA));
                }
            }
            catch
            {
                // ログ出力内容格納
                sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_MEM, LOGOUTPUT_EXNA));
            }
            #endregion メモリ使用量取得

            return sysInfo.ToString();
        }
        #endregion // システム情報取得

        #endregion // privateメソッド

    }
}
