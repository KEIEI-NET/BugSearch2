//****************************************************************************//
//  ｼｽﾃﾑ識別       : PM.NS                                                    //
//  ｼｽﾃﾑﾊﾞｰｼﾞｮﾝ    : 8.10.1.0                                                 //
//  ﾌﾟﾛｸﾞﾗﾑﾊﾞｰｼﾞｮﾝ : 1.00                                                     //
//  ﾕｰｻﾞｰ番号      :                                                          //
//  ﾌﾟﾛｸﾞﾗﾑID      : PMPP9901                                                 //
//  ﾌﾟﾛｸﾞﾗﾑ名      : Http送信部品                                             //
//  ﾌﾟﾛｸﾞﾗﾑ種類    :                                                          //
//  ﾌﾟﾛｸﾞﾗﾑ種別    :                                                          //
//  DFDNo.         :                                                          //
//  言語           : Delphi                                                   //
//  言語ﾊﾞｰｼﾞｮﾝ    : 5.0                                                      //
//  ｺﾝﾎﾟﾊﾞｰｼﾞｮﾝ    : PTSP5.00                                                 //
//  起動ﾊﾟﾗﾒｰﾀ     :                                                          //
//  起動元         :                                                          //
//  備考           :                                                          //
//----------------------------------------------------------------------------//
//            (c) Copyright 2015 BroadLeaf Corporation                        //
//----------------------------------------------------------------------------//
// 管理番号 11000127-00  作成担当 : 佐々木 貴英     作成部署 札幌第1開発課    //
// 完成日   2015/01/08   修正内容 : 新規作成                                  //
//----------------------------------------------------------------------------//
//****************************************************************************//
unit PMPP9901P;

interface

uses
  Windows, SysUtils, WinInet;

type
 TGetHashText =Function( argc:Integer; argv:PChar; len:Pointer; buffer:Pchar):Integer;  stdcall;

// 外部呼出関数（http送受信処理の実行）
function xPMPP9901(
	sAddress1: PChar;
	sAddress2: PChar;
	sUserName: PChar;
	sPassword: PChar;
    sFileDir: PChar; 
    sFileName   : PChar;
    iSSL        : Smallint;
    sUserCode   : PChar;
    iTimeOut    : Longint;
    var iErrCode: Smallint
    ): Smallint; stdcall; overload; export;

  // 送受信処理
  procedure xUpLoad(sWsse: String); forward;
  // WSSE認証用文字列の作成処理
  function  xWsse: String; forward;
  // Base64エンコード関数呼出
  function  xBase64EncodeStr(const Value: String): String; forward;
  // Base64エンコード処理
  function  xBase64Encode(pInput: Pointer; pOutput: Pointer; iSize: Longint): Longint; forward;
  // UTF8ｴﾝｺｰﾄﾞ処理
  function xUTF8(sStr: String; iMode: Integer): String; forward;
  // SJISをUTF-8に変換
  function SJIS2UTF(sStr: String): String; forward;
  // UTF-8をSJISに変換
  function UTF82Sjis(sUTFStr: String): String; forward;
  // 受信データ(XML)作成処理
  procedure xMakeFile(sValue: String);

var
  gAddress1  : String;    // URL
  gAddress2  : String;    // CGI
  gUserName  : String;    // ユーザー名
  gPassword  : String;    // パスワード
  gSNDFPath  : String;    // 送信ファイルパス
  gRCVFPath  : String;    // 受信ファイルパス
  gLOGFPath  : String;    // ログファイルパス
  gSSL       : Smallint;  // SSL区分
  gUserCode  : String;    // ユーザーコード
  gTimeOut   : Longint;   // タイムアウト時間
  gErrKbn    : Smallint;  // エラー区分
  gErrCode   : Smallint;  // エラーコード
  gErrMessage: String;    // エラーメッセージ
//  gMessage   : String;    // エラー以外のメッセージ

const
  _UserAgent = 'Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.0.3705; .NET CLR 1.1.4322; .NET CLR 2.0.50727)';
  _Boundary  = '-----------------------------7d21cef303f8';
  _LF        = #13#10;
  _SndFileEx = '.Xml';
  _RcvFileEx = 'RECV.XML';

implementation

//******************************************************************************
// メイン処理
// 引数  ：URL,CGI,ﾕｰｻﾞｰ名,ﾊﾟｽﾜｰﾄﾞ,ﾌｧｲﾙﾃﾞｨﾚｸﾄﾘ,SSL区分,ﾕｰｻﾞｰｺｰﾄﾞ,
//         ﾀｲﾑｱｳﾄ時間
// 戻り値：ｴﾗｰ区分
//******************************************************************************

//****************************************************************************//
//  module name : http送受信処理の実行
//============================================================================//
//  parameter   : sAddress1    : PChar      : ドメイン
//              : sAddress2    : PChar      : 発注用アドレス
//              : sUserName    : PChar      : ユーザーコード
//              : sPassword    : PChar      : パスワード
//              : sFileDir     : PChar      : 送信ファイルパス
//              : sFileName    : PChar      : 送信ファイル名
//              : iSSL         : Smallint   : プロトコル[0:HTTP 1:HTTPS]
//              : sUserCode    : PChar      : 企業コード
//              : iTimeOut     : Longint    : タイム時間
//              : var iErrCode : Smallint   : エラーコード
//----------------------------------------------------------------------------//
//  return      :            Smallint       : エラー区分
//****************************************************************************//
function xPMPP9901(
	sAddress1   : PChar;
	sAddress2   : PChar;
	sUserName   : PChar;
	sPassword   : PChar;
    sFileDir    : PChar;
    sFileName   : PChar;
    iSSL        : Smallint;
    sUserCode   : PChar;
    iTimeOut    : Longint;
    var iErrCode: Smallint
    ): Smallint; stdcall; overload;
var
  sWsse: String;
  sFDir: String;
begin
  // 初期化
  iErrCode := 0;
  sWsse    := '';
  gErrKbn  := 0;
  gErrCode := 0;
  gErrMessage := '';

try
  // 引数取得
  gAddress1   := sAddress1;    // URL
  gAddress2   := sAddress2;    // CGI
  gUserName   := sUserName;    // ユーザー名
  gPassword   := sPassword;    // パスワード
  sFDir       := sFileDir;     // ファイルパス
  gSSL        := iSSL;         // SSL区分
  gUserCode   := sUserCode;    // ユーザーコード
  gTimeOut    := iTimeOut;     // タイムアウト時間

  // 送信受信テキストパス設定
  if IsPathDelimiter(sFDir,Length(sFDir)) = False then sFDir := sFDir + '\';
  // 送信テキスト(XML)
  gSNDFPath := sFDir + sFileName + _SndFileEx;
  // 受信テキスト(XML)
  gRCVFPath := sFDir + sFileName + _RcvFileEx;

  // WSSEヘッダー作成
  sWsse := xWsse;

  // データ送受信
  if (gErrCode = 0) and (gErrKbn = 0) then begin
    xUpLoad(sWsse);
  end;

  // 結果代入
  iErrCode    := gErrCode;
  Result      := gErrKbn;
except
  iErrCode    := -1;
  Result      := -1;
end;

end;

//****************************************************************************//
//  module name : 送受信処理
//============================================================================//
//  parameter   : sWsse        : String     : WSSEヘッダー文字列
//****************************************************************************//
procedure xUpLoad(sWsse: String);
var
  hSession  ,
  hConnect  ,
  hRequest  : HINTERNET;
  F         : TextFile;
  Server    : array [0..127] of Char;  // 送信先サーバー名称
  Cgi       : array [0..255] of Char;  // 送信先CGI名称
  Buf       : array [0..255] of Char;
  ResultData: array [0..255] of Char;
  sData     ,
  sWk       : String;
  sValue    : String;
  myString  : String;
  pData     : PChar;
  szHead    : PChar;
  s         : String;
  c         : Cardinal;
  ms        : Integer;
  iLength   : Integer;
  iSt       : Integer;
  dwSize    ,
  Reversed  : Cardinal;
  lSt       : LongBool;
  dwFlags   ,
  dwFlags2  : DWORD;
  iBuffSize : DWORD;
  bChkFlg   : Boolean;
  dwLastErr : DWORD;
begin
  // 送信先サーバー名
  StrPCopy(Server,gAddress1);

  // 送信先CGI
  StrPCopy(Cgi,gAddress2);

  // 送信ﾃｷｽﾄ(XML)存在確認
  if not FileExists(gSNDFPath) then begin
    // ｴﾗｰ内容：'ﾃﾞｰﾀ送信対象ﾌｧｲﾙがありません(AssignFile)(ﾌｧｲﾙﾊﾟｽ)'
    gErrMessage := 'ﾃﾞｰﾀ送信対象ﾌｧｲﾙがありません(AssignFile)(' + gSNDFPath + ')';
    gErrKbn     := -1;
    gErrCode    := -2;
    Exit;
   end;

  // 初期化
  hRequest := nil;
  hConnect := nil;
  hSession := nil;
  bChkFlg  := False;

  // 受信テキスト(XML)削除処理
  if FileExists(gRCVFPath) then begin
    DeleteFile(gRCVFPath);
  end;

  try
    // 接続確認
    lSt := InternetGetConnectedState(@dwFlags2,0);
    if (InternetAttemptConnect(0) <> ERROR_SUCCESS) or (lSt = False) then begin
      // エラー内容：'回線ｵｰﾌﾟﾝ ｴﾗｰ(AttemptConnect)'
      gErrMessage := '回線ｵｰﾌﾟﾝ ｴﾗｰ(AttemptConnect)';
      gErrKbn  := 1;
      gErrCode := 1;
      Exit;
    end;

    // ●インターネットサービスのハンドルを取得(WinInet使用開始)
    hSession := InternetOpen(PChar(_UserAgent),
                             INTERNET_OPEN_TYPE_PRECONFIG,
                             nil,
                             nil,
                             0);

    if Assigned(hSession) = False then begin
      // エラー内容：'回線ｵｰﾌﾟﾝ ｴﾗｰ(Open)'
      gErrMessage := '回線ｵｰﾌﾟﾝ ｴﾗｰ(Open)';
      gErrKbn  := 1;
      gErrCode := 2;
      Exit;
    end;

    // SSL区分判定
    if gSSL = 1 then begin
      //---<< HTTPS通信 >>---
      // ●HTTPまたはFTPサーバへ接続
      hConnect := InternetConnect(hSession,
                                  @Server,
                                  INTERNET_DEFAULT_HTTPS_PORT,  // ポートの指定(443)
                                  nil,
                                  nil,
                                  INTERNET_SERVICE_HTTP,
                                  0,
                                  0);

      if Assigned(hConnect) = False then begin
        // エラー内容：'回線ｵｰﾌﾟﾝ ｴﾗｰ(Connect)'
        gErrMessage := '回線ｵｰﾌﾟﾝ ｴﾗｰ(Connect)';
        gErrKbn  := 1;
        gErrCode := 3;
        Exit;
      end;

      // ●HTTPサーバへのリクエスト初期化
      hRequest := HttpOpenRequest(hConnect ,
                                  'POST',
                                   @Cgi,
                                   nil,
                                   nil,
                                   nil,
                                   INTERNET_FLAG_SECURE,
                                   0);

      if Assigned(hRequest) = False then begin
        // エラー内容：'回線ｵｰﾌﾟﾝ ｴﾗｰ(HttpOpenRequest)'
        gErrMessage := '回線ｵｰﾌﾟﾝ ｴﾗｰ(HttpOpenRequest)';
        gErrKbn  := 1;
        gErrCode := 4;
        Exit;
      end;

      dwFlags := SECURITY_FLAG_IGNORE_UNKNOWN_CA or SECURITY_FLAG_IGNORE_CERT_CN_INVALID;
      dwFlags := dwFlags or SECURITY_FLAG_IGNORE_CERT_DATE_INVALID;
      dwFlags := dwFlags or SECURITY_FLAG_IGNORE_REDIRECT_TO_HTTP;
      dwFlags := dwFlags or SECURITY_FLAG_IGNORE_REDIRECT_TO_HTTPS;

      // ●hInternetで指定されたインターネットのオプション情報を設定する
      lSt := InternetSetOption(hRequest,
                               INTERNET_OPTION_SECURITY_FLAGS,
                               @dwFlags,
                               SizeOf(dwFlags));
      if lSt = False then begin
        // エラー内容：'回線ｵｰﾌﾟﾝ ｴﾗｰ(SetOption)'
        gErrMessage := '回線ｵｰﾌﾟﾝ ｴﾗｰ(SetOption)';
        gErrKbn  := 1;
        gErrCode := 5;
        Exit;
      end;
    end else begin
      //---<< HTTPS通信 >>---
      // ●HTTPまたはFTPサーバへ接続
      hConnect := InternetConnect(hSession,
                                  @Server,
                                  INTERNET_DEFAULT_HTTP_PORT,
                                  nil,
                                  nil,
                                  INTERNET_SERVICE_HTTP,
                                  0,
                                  0);
      if Assigned(hConnect) = False then begin
        // エラー内容：'回線ｵｰﾌﾟﾝ ｴﾗｰ(Connect)'
        gErrMessage := '回線ｵｰﾌﾟﾝ ｴﾗｰ(Connect)';
        gErrKbn  := 1;
        gErrCode := 3;
        Exit;
      end;

      // ●HTTPサーバへのリクエスト初期化
      hRequest := HttpOpenRequest(hConnect,
                                  'POST',
                                  @Cgi,
                                  'HTTP/1.1',
                                  nil,
                                  nil,
                                  INTERNET_FLAG_RELOAD,
                                  1);
      if Assigned(hRequest) = False then begin
        // エラー内容：'回線ｵｰﾌﾟﾝ ｴﾗｰ(HttpOpenRequest)'
        gErrMessage := '回線ｵｰﾌﾟﾝ ｴﾗｰ(HttpOpenRequest)';
        gErrKbn  := 1;
        gErrCode := 4;
        Exit;
      end;
    end;

    // ヘッダ情報追加
    FillChar(szHead,SizeOf(szHead),Ord(' '));
    szHead  := 'Accept:*/*';
    iLength := Length(String(szHead));
    HttpAddRequestHeaders(hRequest,szHead,iLength,HTTP_ADDREQ_FLAG_REPLACE or HTTP_ADDREQ_FLAG_ADD);

    FillChar(szHead,SizeOf(szHead),Ord(' '));
    szHead  := 'Accept-Language:ja';
    iLength := Length(String(szHead));
    HttpAddRequestHeaders(hRequest,szHead,iLength,HTTP_ADDREQ_FLAG_REPLACE or HTTP_ADDREQ_FLAG_ADD);

    // WSSE認証用の文字列を作る
    FillChar(szHead,SizeOf(szHead),Ord(' '));
    szHead  := PChar(sWsse);
    iLength := Length(String(szHead));
    HttpAddRequestHeaders(hRequest,szHead,iLength,HTTP_ADDREQ_FLAG_REPLACE or HTTP_ADDREQ_FLAG_ADD);

    FillChar(szHead,SizeOf(szHead),Ord(' '));
    s := 'Content-Type: multipart/form-data; boundary='+Copy(_Boundary,3,Length(_Boundary));
    szHead := PChar(s);
    iLength := Length(String(szHead));
    HttpAddRequestHeaders(hRequest,szHead,iLength,HTTP_ADDREQ_FLAG_REPLACE or HTTP_ADDREQ_FLAG_ADD);

    FillChar(szHead,SizeOf(szHead),Ord(' '));
    szHead  := 'Proxy-Connection:Keep-Alive';
    iLength := Length(String(szHead));
    HttpAddRequestHeaders(hRequest,szHead,iLength,HTTP_ADDREQ_FLAG_REPLACE or HTTP_ADDREQ_FLAG_ADD);


    // 転送ファイル作成
    // 転送ファイルを読み込む
    AssignFile(F,gSNDFPath);
    try
      Reset(F);
    except
      // ｴﾗｰ内容：'ﾃﾞｰﾀ送信対象ﾌｧｲﾙがありません(AssignFile)(ﾌｧｲﾙﾊﾟｽ)'
      gErrMessage := 'ﾃﾞｰﾀ送信対象ﾌｧｲﾙｵｰﾌﾟﾝ処理でエラーが発生しました(System.Reset)(' + gSNDFPath + ')';
      gErrKbn  := -1;
      gErrCode := -3;
      Exit;
    end;
    sData := '';
    sWk   := '';

    try
      while not Eof(F) do begin
        Read(F,buf[0]);
        sData := sData + buf[0];
      end;
    finally
      try
        CloseFile(F);
      except
        raise;
      end;
    end;

    // マルチパートフォーム
    myString := myString +
                _Boundary+_LF+
                'Content-Disposition: form-data; name="xml_data"; ' +
                'filename=' + '"' +
                gSNDFPath+ '"' + _LF + _LF;

    // ここで sData に設定されている転送ファイル情報をByte変数に設定する
    pData := PChar(TrimRight(myString + sData + _LF + _Boundary + '--' + _LF));
    iLength := Length(pData);

    // タイムアウト時間の設定
    ms := gTimeOut;

    InternetSetOption(hRequest,INTERNET_OPTION_CONNECT_TIMEOUT,@ms,SizeOf(ms));
    InternetSetOption(hRequest,INTERNET_OPTION_CONTROL_RECEIVE_TIMEOUT,@ms,SizeOf(ms));
    InternetSetOption(hRequest,INTERNET_OPTION_CONTROL_SEND_TIMEOUT,@ms,SizeOf(ms));
    InternetSetOption(hRequest,INTERNET_OPTION_DATA_SEND_TIMEOUT,@ms,SizeOf(ms));
    InternetSetOption(hRequest,INTERNET_OPTION_DATA_RECEIVE_TIMEOUT,@ms,SizeOf(ms));

    // リクエスト送信
    lSt := HttpSendRequest(hRequest,nil,0,pData,iLength);

    if lSt = False then begin
      dwLastErr := GetLastError();
      gErrMessage := 'ﾃﾞｰﾀ送信中にｴﾗｰが発生(SendRequest)(' + IntToStr(dwLastErr) + ')';
      gErrKbn  := 2;
      gErrCode := dwLastErr;
      Exit;
    end;

    FillChar(Buf,SizeOf(Buf),Ord(' '));
    dwSize   := SizeOf(Buf);
    Reversed := 0;

    // ●レスポンスのステータスラインを取得(例:HTTP/1.1 404 Object Not Found)
    HttpQueryInfo(hRequest,
                  HTTP_QUERY_RAW_HEADERS_CRLF,
                  @Buf,
                  dwSize,
                  Reversed);

    iSt := StrToIntDef(Copy(Buf,10,3),0);

    // 通常時
    if iSt = 200 then bChkFlg := True;

    if bChkFlg = False then begin
      // エラー内容：'ﾃﾞｰﾀ送信中にｴﾗｰが発生(ｴﾗｰｺｰﾄﾞ)'
      gErrMessage := 'ﾃﾞｰﾀ送信中にｴﾗｰが発生(' + IntToStr(iSt) + ')';
      gErrKbn  := 3;
      gErrCode := iSt;
      Exit;
    end;

    if iSt = 200 then begin
      sValue := '';

      // 返されたコンテンツの内容を取得
      while True do begin
        InternetQueryDataAvailable(hRequest,iBuffSize,0,0);
        // 読込めるバイト数 = iBuffSize が'0'になったらBreak
        if (iBuffSize = 0) then Break;
        FillChar(ResultData,SizeOf(ResultData),Ord(' '));

        // ●返されたコンテンツの内容を取得
        InternetReadFile(hRequest,@ResultData,256,c);
        sValue := sValue + ResultData;
      end;

      // 受信データ(XML)作成処理
      xMakeFile(sValue);
    end else
    if iSt = 404 then begin
      gErrKbn  := 4;
      gErrCode := 404;
    end;
  finally
    InternetCloseHandle(hRequest);
    InternetCloseHandle(hConnect);
    InternetCloseHandle(hSession);
  end;
end;

//****************************************************************************//
// WSSE認証用文字列の作成処理
//****************************************************************************//
function xWsse: String;
var
  // 関数ﾎﾟｲﾝﾀ
  GetHashText: TGetHashText;
  
  DLLHandle      : THandle;
  pBuffer        : Pchar;
  pData          : PChar;
  iSts           : Integer;
  iBufSize       : Integer;
  iWork          : Integer;
  sText          : String;
  sWsse          : string;
  sUsername      : String;
  sNonce         : string;
  sCreated       : string;
  sPasswordDigest: string;
  sWide          : WideString;

begin

  // DLLのﾛｰﾄﾞ
  DLLHandle := LoadLibrary('SHA1.DLL');
  try
    if DLLHandle = 0 then begin
      gErrKbn     := 10;
      gErrCode    :=  1100;
      gErrMessage := 'sha1.DLLがロードできません';
      Exit;
    end;

    // DLLのﾊﾝﾄﾞﾙを使用し、関数を取得
    @GetHashText := GetProcAddress(DLLHandle, 'main');

    if (@GetHashText = nil) then begin
      gErrKbn     := -1;
      gErrCode    :=  0;
      gErrMessage := 'sha1.DLLがロードできません';
      Exit;
    end;

    pData := nil;
    GetMem(pBuffer,41);
    ZeroMemory(pBuffer,41);

    // WSSE認証用の文字列を作る
    // ■■　Username　■■
    sUserName := gUserName;

    // ■■　created　 ■■ ISO-8601表記で記述
    sCreated := FormatDateTime('YYYY"-"MM"-"DD"T"hh:mm:ss"Z"',Now);

    // ■■　nonce　　 ■■
    Randomize;
    iWork  := Random($FFFFFFFF);
    sNonce := FormatDateTime('YYYYMMDDhhmmss',Now) + IntToHex(iWork, 8);

    // ■■　passwordDigest　■■
    sText := sNonce + sCreated + gPassword;
    sWide := sText;

    // ◆１ UTF-8ｴﾝｺｰﾃﾞｨﾝｸﾞ
    sText := xUTF8(sText,1);
    Move(sText,pData,SizeOf(sText));

    // ◆２ SHA1ﾊｯｼｭ変換
    iSts := GetHashText(Length(pData),pData,@iBufSize,pBuffer);
    if iSts = 0 then begin
      sPasswordDigest := String(pBuffer);
    end else begin
      gErrKbn     := 10;
      gErrCode    :=  1101;
      gErrMessage := 'ﾊｯｼｭ変換処理でｴﾗｰが発生しました('+IntToStr(iSts)+')';
      Exit;
    end;

    FreeMem(pBuffer);

    // ◆３ BASE64ｴﾝｺｰﾃﾞｨﾝｸﾞ
    sWsse := Format('X-WSSE: UsernameToken Username="%s", PasswordDigest="%s", Nonce="%s", Created="%s"',
                    [sUsername, xBase64EncodeStr(sPasswordDigest), sNonce, sCreated]);

    // WSSEヘッダー内容返却
    Result := sWsse;
  finally
    // DLLの開放
    FreeLibrary(DLLHandle);
  end;
end;

//****************************************************************************//
//  module name : Base64エンコード関数呼出
//============================================================================//
//  parameter   : Value        : String     : エンコードする文字列
//----------------------------------------------------------------------------//
//  return      :            String         : エンコード後の文字列
//****************************************************************************//
function xBase64EncodeStr(const Value: String): String;
begin
  SetLength(Result,((Length(Value)+2) div 3) * 4);
  xBase64Encode(@Value[1],@Result[1],Length(Value));
end;

//******************************************************************************
// Base64エンコード処理
//******************************************************************************
function xBase64Encode(pInput: Pointer; pOutput: Pointer; iSize: Longint): Longint;
const
  B64: array [0..63] of Byte = (65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,
    81,82,83,84,85,86,87,88,89,90,97,98,99,100,101,102,103,104,105,106,107,108,
    109,110,111,112,113,114,115,116,117,118,119,120,121,122,48,49,50,51,52,53,
    54,55,56,57,43,47);
var
  iCnt  ,
  iptr  ,
  optr  : Integer;
  Input ,
  Output: PByteArray;
begin
  Input  := PByteArray(pInput);
  Output := PByteArray(pOutput);
  iptr   := 0;
  optr   := 0;

  for iCnt := 1 to (iSize div 3) do begin
    Output^[optr+0] := B64[Input^[iptr] shr 2];
    Output^[optr+1] := B64[((Input^[iptr] and 3) shl 4) + (Input^[iptr+1] shr 4)];
    Output^[optr+2] := B64[((Input^[iptr+1] and 15) shl 2) + (Input^[iptr+2] shr 6)];
    Output^[optr+3] := B64[Input^[iptr+2] and 63];
    Inc(optr,4);
    Inc(iptr,3);
  end;

  case (iSize mod 3) of
    1:begin
        Output^[optr+0] := B64[Input^[iptr] shr 2];
        Output^[optr+1] := B64[(Input^[iptr] and 3) shl 4];
        Output^[optr+2] := Byte('=');
        Output^[optr+3] := Byte('=');
      end;
    2:begin
        Output^[optr+0] := B64[Input^[iptr] shr 2];
        Output^[optr+1] := B64[((Input^[iptr] and 3) shl 4) + (Input^[iptr+1] shr 4)];
        Output^[optr+2] := B64[(Input^[iptr+1] and 15) shl 2];
        Output^[optr+3] := Byte('=');
      end;
  end;

  Result := ((iSize+2) div 3) * 4;
end;

//****************************************************************************//
// コード変換
//============================================================================//
//  parameter   : sStr         : String     : コード変換前文字列
//              : iMode        : Integer    : 変換区分[1:SJIS→UTF-8][1以外:UTF-8→SJIS]
//----------------------------------------------------------------------------//
//  return      :            String         : コード変換結果
//****************************************************************************//
function xUTF8(sStr: String; iMode: Integer): String;
begin
  if iMode = 1 then begin
    Result := SJIS2UTF(sStr);
  end else begin
    Result := UTF82Sjis(sStr);
  end;
end;

//****************************************************************************//
// SJISをUTF-8に変換
//============================================================================//
//  parameter   : sStr         : String     : コード変換前文字列
//----------------------------------------------------------------------------//
//  return      :            String         : コード変換結果
//****************************************************************************//
function SJIS2UTF(sStr: String): String;
var
  pUc  ,
  pSc  : PChar;
  pUsc2: PWideChar;
  pW   : ^Word;
  iLen : Integer;
begin
  Result := '';
  iLen   := Length(sStr);
  pUsc2  := AllocMem(iLen * 4 + 4);
  pW     := Pointer(pUsc2);

  try
    pUc := AllocMem(iLen * 3 + 3);
    pSc := pUc;
    try
      // 一旦Unicodeに変換
      StringToWideChar(sStr, pUsc2, iLen * 4);
      while pW^ <> 0 do begin
        if (pW^ and $FF80) = 0 then
        begin
          pUc^ := Char(Lo(pW^));
          Inc(pUc);
          Inc(pW);
        // 00000xxx-xxyyyyyy
        end else if (pW^ and $F800) = 0 then begin
          // 110xxxxx
          pUc^ := Char($C0 + (pW^ shr 6));
          Inc(pUc);
          // 10yyyyyy
          pUc^ := Char($80 + (pW^ and $3F));
          Inc(pUc);
          Inc(pW);
        // xxxxyyyy-yyzzzzzz
        end else begin
          // 1110xxxx
          pUc^ := Char($E0 + (pW^ shr 12));
          Inc(pUc);
          // 10yyyyyy
          pUc^ := Char($80 + ((pW^ shr 6) and $3F));
          Inc(pUc);
          // 10zzzzzz
          pUc^ := Char($80 + (pW^ and $3F));
          Inc(pUc);
          Inc(pW);
        end;
      end;
      pUc^ := #0;
      Result := pSc;
    finally
      Freemem(pSc);
    end;
  finally
    FreeMem(pUsc2);
  end;
end;

//****************************************************************************//
// UTF-8をSJISに変換
//============================================================================//
//  parameter   : sStr         : String     : コード変換前文字列
//----------------------------------------------------------------------------//
//  return      :            String         : コード変換結果
//****************************************************************************//
function UTF82Sjis(sUTFStr: String): String;
var
  pUsc2,
  pUc  : PChar;
  pWc  : PWideChar;
  iLen : Integer;
  wUn  : WORD;
begin
  Result := '';
  iLen := Length(sUTFStr);
  // 文字列の終わりを検出するために番兵4人を立てる
  pUc := PChar(sUTFStr + #0#0#0#0);
  // 安全を見て4倍のﾒﾓﾘを確保
  pUsc2 := AllocMem(iLen * 4);
  // pUsc2はﾎﾟｲﾝﾀとして使うのでpWcに先頭ｱﾄﾞﾚｽを保存
  pWc := PWideChar(pUsc2);
  try
    while pUc^ <> #0 do begin
      // ASCII
      if pUc^ in [#0..#$7F] then begin
        pUsc2^ := pUc^;
        (pUsc2+1)^ := #0;
        Inc(pUsc2, 2);
        Inc(pUc);
      // 2byte文字その1
      end else if pUc^ in [#$C0.. #$DF] then begin
        wUn := (Ord(pUc^) and $1F) shl 6 + Ord((pUc+1)^) and $3F;
        pUsc2^ := Char(Lo(wUn));
        (pUsc2+1)^ := Char(Hi(wUn));
        Inc(pUsc2, 2);
        Inc(pUc, 2);
      // 2byte文字その2
      end else if pUc^ in [#$E0..#$EF] then begin
        wUn := (Ord(pUc^) and $0F) shl 12 + (Ord((pUc+1)^) and $3F) shl 6
              + (Ord((pUc+2)^) and $3F);
        pUsc2^ := Char(Lo(wUn));
        (pUsc2+1)^ := Char(Hi(wUn));
        Inc(pUsc2, 2);
        Inc(pUc, 3);
      // 4byte文字(USC-4のみ)
      end else if pUc^ in [#$F0..#$F7] then begin
        wUn := (Ord(pUc^) and $07) shl 2 + (Ord((pUc+1)^) shr 4) and $03;
        pUsc2^ := Char(Lo(wUn));
        (pUsc2+1)^ := Char(Hi(wUn));
        Inc(pUsc2, 2);
        Inc(pUc);
        wUn := ((Ord(pUc^) shl 4) and $F0) + (Ord((pUc+1)^) and $3F) shl 6
              + (Ord((pUc+2)^) and $3F);
        pUsc2^ := Char(Lo(wUn));
        (pUsc2+1)^ := Char(Hi(wUn));
        Inc(pUsc2, 2);
        Inc(pUc, 3);
      end else
        raise Exception.Create('UTF-8 Unknown code.');
    end;
    // UTFから変換したUnicodeをString型で返す。
    Result := pWc;
  finally
    FreeMem(pWc);
  end;
end;


//******************************************************************************
// 受信データ(XML)作成処理
//============================================================================//
//  parameter   : sValue       : String     : 格納文字列
//****************************************************************************//
procedure xMakeFile(sValue: String);
var
  F: TextFile;
begin
  AssignFile(F,gRCVFPath);
  Rewrite(F);
  try
    Write(F,Trim(sValue));
  finally
    // ファイルを閉じる
    CloseFile(F);
  end;
end;

end.
