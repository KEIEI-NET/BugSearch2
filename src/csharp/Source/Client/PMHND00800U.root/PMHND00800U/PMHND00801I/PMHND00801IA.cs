//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : HTプログラム導入処理
// プログラム概要   : HTプログラム導入処理インターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370104-00 作成担当 : 森山　浩
// 作 成 日  2017/12/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#region BTCommLibEx

namespace Broadleaf.Windows.Forms
{
using BTCOMM_HHT = System.Int32;

    //HT情報構造体
    [StructLayout(LayoutKind.Sequential)]
    public struct BTCOMM_HTInfo
    {
        public Int16 wID;               // HT ID	(指定しない場合はBTCOMM_ID_NO_CAREを入れる)
        public Int16 wCradleType;       // 通信ユニットの種別
        public Int16 wPortNo;           // ポート番号 // シリアルポート番号
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] strip;            // IPアドレス
    }

    //HT情報構造体2
    [StructLayout(LayoutKind.Sequential)]
    public struct BTCOMM_HTInfo2
    {
        public BTCOMM_HTInfo info;             // HT情報構造体
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] sSerial;                 // シリアルNo
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] sFirmVersionl;           // ファームウェアのバージョン
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] sAppVirsion;            // APP ファイルのバージョン
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] sSbVersion;             // スクリプトバイナリ(sb3)ファイルのバージョン
    }


    // 送受信情報構造体
    // btcommCreateHTHandle()で設定する構造体です。
    [StructLayout(LayoutKind.Sequential)]
    public struct BTCOMM_Param
    {
        public IntPtr hWnd;				// イベント配信先
        public Int32  dwMsgID;			// イベントID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] strSendPath;		// ファイル送信時（btcommPutFile）のカレントフォルダ
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] strRecvPath;		// ファイル受信時（btcommGetFile）のカレントフォルダ
        public bool bDispDialog;		// 通信中のダイアログを表示する/しない
        public bool bSetTime;			// 端末の時刻をPCに合わせる/合わせない
    }

    // ファイル情報構造体
    // btcommFindFileNext()の結果を取得する構造体です。
    [StructLayout(LayoutKind.Sequential)]
    public struct BTCOMM_FileInfo
    {
        public Int32 dwAttribute;				// 属性
        public ulong ullFileSize;				// ファイルサイズ
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public char[] strFileName;		        // ファイル名
        public Int32 wYear;					    // 更新日付（年）
        public byte byMonth;					// 更新日付（月）
        public byte byDay;						// 更新日付（日）
        public byte byHour;					    // 更新日付（時）
        public byte byMin;						// 更新日付（分）
        public byte bySec;						// 更新日付（秒）
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] reserved;	   			    // 予備
    }

    // 送受信データ構造体
    // btcommFindFileNext()の結果を取得する構造体です。
    [StructLayout(LayoutKind.Sequential)]
    public struct BTCOMM_TransProgress
    {
        public Int32 dwStatus;                 // 送受信区別（BTCOMM_TP_SEND/BTCOMM_TP_RECV/...)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] strFileName;             // ファイル名
        public ulong ullFileLen;               // ファイル長
        public ulong ullTransLen;              // 送受信済のデータ長
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct BTCOMM_TransProgress2
    {
        public Int32 dwStatus;                 // 送受信区別（BTCOMM_TP_SEND/BTCOMM_TP_RECV/...)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] strFileName;             // ファイル名
        public Int32 dwFileLen;                // ファイル長
        public Int32 dwTransLen;               // 送受信済のデータ長
    } ;

    // 送受信データ構造体
    // btcommInitializeHT()で設定する構造体です。
    public struct BTCOMM_InitInfo
    {
        public Int16 wTermID;                  // 端末ID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public char[] reserved;                // ファイル名
    } ;

    // 端末アプリ更新情報構造体
    public struct BTCOMM_APP_INFO
    {
        public char major_version;             // メジャーバージョン
        public char minor_version;             // マイナーバージョン
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public char[] comment;                 // アプリケーションに関するコメント（タイトル）
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] filepath;                // アプリケーションに関するコメント（タイトル）

    } ;

    // システムアップデートファイル情報構造体
    public struct BTCOMM_SYSUPFILE_INFO
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] filepath;                // システムアップデートファイル名(in)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] version;                 // アプリケーションを検索するフォルダ（受信フォルダからの相対パス）。
							            // 取得時にはアプリケーションのファイル名。

    } ;

    // ファイル圧縮情報構造体
    public struct BTCOMM_COMPRESS_INFO
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] strSrcFileName;          // 圧縮対象ファイル名(in))
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] strDstFileName;          // 圧縮ファイル名(in)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] strCmpFileName;          // 解凍されるファイル名(in)(ファイル名のみ)
        public Int16 wOverWrite;               // 上書き許可/禁止(in)(1/0)
        public Int16 wFolderType;              // フォルダ種別(in)(1:受信フォルダ/2:送信フォルダ)
        public Int32 dwBeforeFileSize;         // 圧縮前のファイルサイズ(out)
        public Int32 dwAfterFileSize;          // 圧縮後のファイルサイズ(out)

    } ;

    // ファイル解凍情報構造体
    public struct BTCOMM_UNCOMPRESS_INFO
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] strSrcFileName;          // 圧縮ファイル名(in)
        public Int16 wOverWrite;               // 上書き許可/禁止(in)(1/0)
        public Int16 wFolderType;              // フォルダ種別(in)(1:受信フォルダ/2:送信フォルダ)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public char[] strDstFileName;          // 解凍ファイル名(in)

    } ;
    

    // 通信ユニット種別(BTCOMM_HTInfo構造体のwCradleTypeに指定します
    public enum BTCOMM_CRADLETYPE : int
    {
        BTCOMM_CRADLE_TYPE_COM          = 1,    // COM通信ユニット
	    BTCOMM_CRADLE_TYPE_USB,			        // USB通信ユニット
	    BTCOMM_CRADLE_TYPE_LAN,			        // LAN通信ユニット
	    BTCOMM_CRADLE_TYPE_MODEM        = 6,	// モデム(9600通信)
	    BTCOMM_CRADLE_TYPE_RF           = 10,	// 無線通信
	    BTCOMM_CRADLE_TYPE_SOCK_PASSIVE = 11,	// 無線通信(サーバ)
	    BTCOMM_CRADLE_TYPE_MODEM_115K = 12,	    // モデム(115K通信)

    } ;

    // 戻り値種別定義
    public enum BTCOMM_RESULT : int
    {
	    BTCOMM_INVALID_VALUE	= -320,	// 内部使用
	    BTCOMM_NOTINITIALISED,			// (-319)初期化されていません。不正なハンドルです。
	    BTCOMM_INUSE,					// (-318)ポートが使用中です。
	    BTCOMM_NOTCONNECT,				// (-317)ConnectまたはListenをしていない状態で関数が呼ばれました。
	    BTCOMM_WOULDBLOCK,				// (-316)非同期関数が呼ばれました。処理の結果はイベントで返ります。
	    BTCOMM_NOTFOUND,				// (-315)指定した端末が見つかりませんでした。
	    BTCOMM_REFUSED,					// (-314)端末から接続を拒否されました。
	    BTCOMM_CANCELED,				// (-313)キャンセルされました。
	    BTCOMM_TIMEOUT,					// (-312)相手との接続がタイムアウト時間内にできませんでした。
	    BTCOMM_NETDOWN,					// (-311)（接続中の）通信経路がダウンしました。
	    BTCOMM_BIGDATA,					// (-310)相手の空き容量以上のファイルを送信しようとしました。
	    BTCOMM_FILENOTFOUND,			// (-309)送受信で指定したファイルが見つかりません。
	    BTCOMM_INCOMPLETE,				// (-308)処理が完了しませんでした。
	    BTCOMM_CONVERT_FAILED,			// (-307)変換処理失敗
	    BTCOMM_OTHER,					// (-306)その他のエラーが発生しました。
	    BTCOMM_CALLBACK,				// (-305)コールバック関数で戻り値がエラーを返しました。
	    BTCOMM_OK				= 0,	// 処理が成功しました。
    
    }

    // イベント定義 wParamに相当します
    public enum BTCOMM_EVENTDEF : int
    {
	    EV_SEARCH_FIN,					// (0)端末検索終了時に送信されるイベント

	    EV_LISTENING_START,				// (1)Listen開始前に送信されるイベント
	    EV_LISTENING_ACCEPTED,			// (2)Listen後、端末と接続できたときに送信されるイベント
	    EV_LISTENING_FIN,				// (3)Listen終了後に送信されるイベント

	    EV_CONNECT_FIN,					// (4)Connect後、端末と接続できたときに送信されるイベント
	    EV_DISCONNECT_FIN,				// (5)Disconnect後、端末との接続を切断できたときに送信されるイベント

	    EV_FILE_TRANSPORTING,			// (6)ファイル送受信中に送信されるイベント
	    EV_PROCEDURE_COMPLETE,			// (7)処理完了時に送信されるイベント
	    EV_FIND_FIN,					// (8)ファイル検索完了時に送信されるイベント
	    EV_INVALID_VALUE,				// (9)実際には使用しない値
	    EV_FILE_TRANSPORTING2,			// (10)ファイル送受信中に送信されるイベント（ロングファイル名対応）
    } ;

    // 戻り値種別定義 BTCOMM_TransProgress::dwStatusに指定します。
    public enum BTCOMM_RETVALDEF : int
    {
	    BTCOMM_TP_SEND = 0,				// (0)送信中
	    BTCOMM_TP_RECV,					// (1)受信中
	    BTCOMM_TP_SAVE,					// (2)データ保存中
	    BTCOMM_TP_COMP,					// (3)データ保存成功
	    BTCOMM_TP_INCP,					// (4)データ保存失敗
	    BTCOMM_TP_MELT,					// (5)ログファイル解凍
	    BTCOMM_TP_LOGCOMP,				// (6)ログファイル保存成功
	    BTCOMM_TP_NUM					//    定義数
    } ;

    /// <summary>
    /// HTプログラム導入処理 RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : HTプログラム導入処理 RemoteObject Interfaceです。</br>
    /// <br>Programmer : 森山　浩</br>
    /// <br>Date       : 2017/12/22</br>
    /// </remarks>
    public class btcommclass
    {

        // 検索条件 btcommSearchHT()のdwSearchInfoに指定します
        public static uint BTCOMM_CRADLE_COM1 = 2;
        public static uint BTCOMM_CRADLE_COM2 = 4;
        public static uint BTCOMM_CRADLE_COM3 = 8;
        public static uint BTCOMM_CRADLE_COM4 = 16;
        public static uint BTCOMM_CRADLE_COM5 = 32;
        public static uint BTCOMM_CRADLE_COM6 = 64;
        public static uint BTCOMM_CRADLE_COM7 = 128;
        public static uint BTCOMM_CRADLE_COM8 = 256;
        public static uint BTCOMM_CRADLE_COM9 = 512;
        // 検索条件 btcommSearchHT(),btcommSearchCradle()のdwSearchInfoに指定します
        public static uint BTCOMM_CRADLE_COMALL = 1024;
        public static uint BTCOMM_CRADLE_USBALL = 2048;
        public static uint BTCOMM_CRADLE_LANALL = 4096;
        public static uint BTCOMM_TERM_WLANALL = 8192;

        // ログデータカスタマイズ条件
        public static uint DEL_DATE           = 1;           // 日付データ削除
        public static uint DEL_HOURMINUTE     = 2;           // 日付データ削除
        public static uint DEL_DADEL_SECONDTE = 4;           // 日付データ削除
        public static uint DEL_ID             = 8;           // 日付データ削除
        public static uint DEL_SEPARATOR      = 0x80000000;  // 日付データ削除

        // アプリ更新情報
        public static int BTCOMM_APLIUPDATE_SAME = 1;   // 日付データ削除
        public static int BTCOMM_APLIUPDATE_NONE = 2;   // 日付データ削除
        public static int BTCOMM_APLIUPDATE_NORM = 3;   // 日付データ削除

        // メッセージ送信ID
        public static int ID_MSG_CALLBACK = 1;  // 相手先ファイル送受信完了コールバック呼び出し



        //
        // 通信ユニットの検索
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static BTCOMM_RESULT btcommSearchCradle(
                            Int32 dwSearchInfo,		// [in]	 検索条件
                            Int32* nResult			// [out] 検索結果数
                            );

        //
        // 通信ユニット検索結果からHT情報の取得(端末IDはBTCOMM_ID_NO_CARE固定)
        //
        [DllImport("BTCommLibEx.dll")]
        public　unsafe extern static bool btcommGetCradleNext(
                            ref BTCOMM_HTInfo info		// [out] 端末情報
                            );

        //
        // HTの検索
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static BTCOMM_RESULT btcommSearchHT(
                            IntPtr hWnd,			// [in]	 イベント配信先。NULLの場合ブロック関数になる
                            Int32 Msg,				// [in]	 送信メッセージID
                            uint dwSearchInfo,		// [in]	 検索条件
                            Int32* nResult		    // [out] 検索結果数
                            );

        //
        // HTの検索2
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static BTCOMM_RESULT btcommSearchHT2(
                            IntPtr hWnd,			// [in]	 イベント配信先。NULLの場合ブロック関数になる
                            Int32 Msg,				// [in]	 送信メッセージID
                            uint dwSearchInfo,		// [in]	 検索条件
                            Int32* nResult		    // [out] 検索結果数
                            );

        //
        // HTの検索結果からHT情報の取得
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static bool btcommGetHTNext(
                            out BTCOMM_HTInfo info		// [out] 端末情報
                            );

        //
        // HTの検索結果からHT情報の取得
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static bool btcommGetHTNext2(
                            out BTCOMM_HTInfo2 info		// [out] 端末情報
                            );

        //
        // HTハンドルの生成
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static BTCOMM_HHT btcommCreateHTHandle(
                              ref BTCOMM_HTInfo info,	    // [in]	 端末情報
                              ref BTCOMM_Param param		// [in]	 送受信情報
                              );

        //
        // HTハンドルの解放
        //
        [DllImport("BTCommLibEx.dll")]
        public  extern static bool btcommCloseHTHandle(
                              BTCOMM_HHT hHT			// [in]	 HTハンドル
                              );

        //
        // HTハンドルからHT情報の取得
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static BTCOMM_RESULT btcommGetHTInfo(
                            BTCOMM_HHT hHT,			// [in]	 HTハンドル
                            ref BTCOMM_HTInfo info,	// [out] 端末情報
                            ref BTCOMM_Param param		// [out] 送受信情報
                            );

        //
        // 端末からの接続待ち
        //
        [DllImport("BTCommLibEx.dll")]
        public  extern static BTCOMM_RESULT btcommListen(
                            BTCOMM_HHT hHT			// [in]	 HTハンドル
                            );

        //
        // 端末からの接続待ち終了
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommStopListening(
                                BTCOMM_HHT hHT			// [in]	 HTハンドル
                                );

        //
        // 端末への接続開始
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommConnect(
                                BTCOMM_HHT hHT,			// [in]	 HTハンドル
                                Int32 dwTimeOut			// [in]	 タイムアウト時間（秒）
                                );

        //
        // 端末との接続解除（Connectの解除。Listenの解除ではない）
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommDisconnect(
                                BTCOMM_HHT hHT,			// [in]	 HTハンドル
                                Int32 dwTimeOut			// [in]	 タイムアウト時間（秒）
                                );

        //
        // 端末(Server)の接続待ちを強制終了させる
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommStopRemoteServer(
                                BTCOMM_HHT hHT,			// [in]	 HTハンドル
                                BTCOMM_RESULT retCode,	// [in]	 終了コード
                                Int32 dwTimeOut			// [in]	 タイムアウト時間（秒）
                                );

        //
        // 端末への接続確認（Connect後(1)またはListen後(2)または未接続(0)か確認する）
        //
        [DllImport("BTCommLibEx.dll")]
        private extern static int btcommIsConnect(
                                BTCOMM_HHT hHT			// [in]	 HTハンドル
                                );

        //
        // 端末へのファイル送信（アップロード）
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommPutFile(
                                BTCOMM_HHT hHT,			// [in]	 HTハンドル
                                [MarshalAs(UnmanagedType.LPStr)]
                                string pstrLocalFile,	// [in]	 ローカルファイル名
                                [MarshalAs(UnmanagedType.LPStr)]
                                string pstrRemoteFile,	// [in]	 リモートファイル名
                                Int32 dwTimeOut		    // [in]	 タイムアウト時間（秒）
                                );

        //
        // 端末からのファイル受信（ダウンロード）
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommGetFile(
                                BTCOMM_HHT hHT,			// [in]	 HTハンドル
                                [MarshalAs(UnmanagedType.LPStr)]
                                string pstrRemoteFile,	// [in]	 リモートファイル名
                                [MarshalAs(UnmanagedType.LPStr)]
                                string pstrLocalFile,	// [in]	 ローカルファイル名
                                Int32 dwTimeOut			// [in]	 タイムアウト時間（秒）
                                );

        //
        // 端末との通信キャンセル
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommCancel(
                                BTCOMM_HHT hHT			// [in]	 HTハンドル
                                );

        //
        // 端末内のファイル検索
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static BTCOMM_RESULT btcommFindFile(
                                BTCOMM_HHT hHT,			// [in]	 HTハンドル
                                [MarshalAs(UnmanagedType.LPStr)]
                                string pstrPath,	    // [in]	 検索パス
                                Int32* nResult,			// [out] 検索結果数
                                Int32 dwTimeOut			// [in]	 タイムアウト時間（秒）
                                );

        //
        // 端末内のファイル検索
        //
        [DllImport("BTCommLibEx.dll")]
        public unsafe extern static BTCOMM_RESULT btcommFindFileNext(
                                BTCOMM_HHT hHT,			// [in]	 HTハンドル
                                ref BTCOMM_FileInfo info	// [out] ファイル構造体
                                );

        //
        // 端末内のファイル名変更
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommRenameFile(
                                BTCOMM_HHT hHT,			// [in]	 HTハンドル
                                [MarshalAs(UnmanagedType.LPStr)]
                                string pstrExistFile,	// [in]	 現在のファイル名
                                [MarshalAs(UnmanagedType.LPStr)]
                                string pstrNewFile,	    // [in]	 新しいファイル名
                                Int32 dwTimeOut			// [in]	 タイムアウト時間（秒）
                                );

        //
        // 端末内のファイル削除
        //
        [DllImport("BTCommLibEx.dll")]
        public extern static BTCOMM_RESULT btcommRemoveFile(
                                BTCOMM_HHT hHT,				// [in]	 HTハンドル
                                [MarshalAs(UnmanagedType.LPStr)]
                                string pstrFileName,	// [in]	 削除するファイル名
                                Int32 dwTimeOut				// [in]	 タイムアウト時間（秒）
                                );
    }

}

#endregion

