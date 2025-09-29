//****************************************************************************//
//  ｼｽﾃﾑ識別       : PM7                                                      //
//  ｼｽﾃﾑﾊﾞｰｼﾞｮﾝ    : 7.00                                                     //
//  ﾌﾟﾛｸﾞﾗﾑﾊﾞｰｼﾞｮﾝ : 1.00                                                     //
//  ﾕｰｻﾞｰ番号      :                                                          //
//  ﾌﾟﾛｸﾞﾗﾑID      : PMPU9013                                                 //
//  ﾌﾟﾛｸﾞﾗﾑ名      : UOEリクエスト送信部品                                    //
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
//            (c) Copyright 2012 BroadLeaf Corporation                        //
//----------------------------------------------------------------------------//
// 管理番号 xxxxxxxx-00  作成担当 : 籾山 孝幸       作成部署 札幌第1開発課    //
// 完成日   2012/04/02   修正内容 : 新規作成                                  //
//----------------------------------------------------------------------------//
// 管理番号 xxxxxxxx-00  作成担当 : FSI佐々木 貴英  作成部署 札幌第1開発課    //
// 完成日   2013/05/17   修正内容 : 文字列要素内の禁則文字(<,>,&,",',)を      //
//                                  XMLエンティティ参照(&lt;,&gt;,&amp;,      //
//                                  &quot;,&apos;)に変換してXMLに出力するよう //
//                                  修正                                      //
//----------------------------------------------------------------------------//
// 管理番号 10900008-00  作成担当 : FSI佐々木 貴英  作成部署 札幌第1開発課    //
// 完成日   2013/08/01   修正内容 : 禁則文字変換対象取得方法変更              //
//----------------------------------------------------------------------------//
// 管理番号 10902175-00  作成担当 : FSI佐々木 貴英  作成部署 札幌第1開発課    //
// 完成日   2013/09/03   修正内容 : UOEリクエスト送信処理受信データ不正対応   //
//----------------------------------------------------------------------------//
// 管理番号 10904597-00  作成担当 : FSI佐々木 貴英  作成部署 札幌第1開発課    //
// 完成日   2014/04/01   修正内容 : ①受信XMLデータでリマークに空白を設定     //
//                                : ②変換対象終了タグNETRECVに大文字小文字が //
//                                    混在する場合も対象とするよう修正        //
//****************************************************************************//
unit PMPU9013P;

interface

uses
  Windows, SysUtils, WinInet;

// 外部呼出関数宣言部(引数:URL,CGI,ﾕｰｻﾞｰ名,ﾊﾟｽﾜｰﾄﾞ,ﾌｧｲﾙﾃﾞｨﾚｸﾄﾘ,SSL区分,NETﾌﾗｸﾞ,
//                         ﾕｰｻﾞｰｺｰﾄﾞ,ﾀｲﾑｱｳﾄ時間,nonce,created,SHA1ﾊｯｼｭ変換値,
//                         仕入受信区分,復旧ﾌﾗｸﾞ,ｴﾗｰｺｰﾄﾞ)
function xPMPU9013(sAddress1: PChar; sAddress2: PChar; sUserName: PChar; sPassword: PChar;
                   sFileDir: PChar; iSSL: Smallint; iNetFlg: Smallint; sUserCode: PChar;
                   iTimeOut: Longint; sNonce: PChar; sCreated: PChar; sShaText: PChar;
                   iSJKbn: Smallint; iRestoreFlg: Smallint; var iErrCode: Smallint): Smallint; stdcall; overload; export;

  // 送受信処理
  procedure xUpLoad(sWsse: String); forward;
  // WSSE認証用文字列の作成処理
  function xWsse: String; forward;
  // Base64エンコード関数呼出
  function xBase64EncodeStr(const Value: String): String; forward;
  // Base64エンコード処理
  function  xBase64Encode(pInput: Pointer; pOutput: Pointer; iSize: Longint): Longint; forward;
  // 受信データ(XML)作成処理
  procedure xMakeFile(sValue: String);
// 2013/05/17 修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
// 2013/08/01 禁則文字変換対象取得方法変更 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//  // XMLドキュメント変換処理
//  function xConvertRcvXmlDocument(sValue: String): String; forward;
// 2013/08/01 禁則文字変換対象取得方法変更 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
  // XMLエンティティ参照文字列変換処理
  function xXMLRowConv(sValue: String): String; forward;
  // XMLエンティティ参照文字変換
  function xXMLProhibitionCharToStr(cValue: Char): String; forward;
// 2013/05/17 修正 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

var
  gAddress1  : String;    // URL
  gAddress2  : String;    // CGI
  gUserName  : String;    // ユーザー名
  gPassword  : String;    // パスワード
  gSNDFPath  : String;    // 送信ファイルパス
  gRCVFPath  : String;    // 受信ファイルパス
  gSSL       : Smallint;  // SSL区分
  gNetFlg    : Smallint;  // NETフラグ
  gUserCode  : String;    // ユーザーコード
  gTimeOut   : Longint;   // タイムアウト時間
  gNonce     : String;    // WSSE認証用 nonce
  gCreated   : String;    // WSSE認証用 created
  gShaText   : String;    // WSSE認証用 SHA1ハッシュ変換値
  gSJKbn     : Smallint;  // 仕入受信区分(0:通常 1:仕入受信)
  gRestoreFlg: Smallint;  // 復旧フラグ(0:通常 1:復旧処理)
  gErrKbn    : Smallint;  // エラー区分
  gErrCode   : Smallint;  // エラーコード

const
  _UserAgent = 'Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.0.3705; .NET CLR 1.1.4322; .NET CLR 2.0.50727)';
  _Boundary  = '-----------------------------7d21cef303f8';
  _LF        = #13#10;

implementation

//******************************************************************************
// メイン処理
// 引数  ：URL,CGI,ﾕｰｻﾞｰ名,ﾊﾟｽﾜｰﾄﾞ,ﾌｧｲﾙﾃﾞｨﾚｸﾄﾘ,SSL区分,NETﾌﾗｸﾞ,ﾕｰｻﾞｰｺｰﾄﾞ,
//         ﾀｲﾑｱｳﾄ時間,nonce,created,SHA1ﾊｯｼｭ変換値,仕入受信区分,復旧ﾌﾗｸﾞｴﾗｰｺｰﾄﾞ
// 戻り値：ｴﾗｰ区分
//******************************************************************************
function xPMPU9013(sAddress1: PChar; sAddress2: PChar; sUserName: PChar; sPassword: PChar;
                   sFileDir: PChar; iSSL: Smallint; iNetFlg: Smallint; sUserCode: PChar;
                   iTimeOut: Longint; sNonce: PChar; sCreated: PChar; sShaText: PChar;
                   iSJKbn: Smallint; iRestoreFlg: Smallint; var iErrCode: Smallint): Smallint; stdcall; overload;
var
  sWsse: String;
  sFDir: String;
begin
  // 初期化
  Result   := 0;
  iErrCode := 0;
  sWsse    := '';
  gErrKbn  := 0;
  gErrCode := 0;

  // 引数取得
  gAddress1   := sAddress1;    // URL
  gAddress2   := sAddress2;    // CGI
  gUserName   := sUserName;    // ユーザー名
  gPassword   := sPassword;    // パスワード
  sFDir       := sFileDir;     // ファイルパス
  gSSL        := iSSL;         // SSL区分
  gNetFlg     := iNetFlg;      // NETフラグ
  gUserCode   := sUserCode;    // ユーザーコード
  gTimeOut    := iTimeOut;     // タイムアウト時間
  gNonce      := sNonce;       // WSSE認証用 nonce
  gCreated    := sCreated;     // WSSE認証用 created
  gShaText    := sShaText;     // WSSE認証用 SHA1ハッシュ変換値
  gSJKbn      := iSJKbn;       // 仕入受信区分
  gRestoreFlg := iRestoreFlg;  // 復旧フラグ

  // 送信受信テキストパス設定
  if IsPathDelimiter(sFDir,Length(sFDir)) = False then sFDir := sFDir + '\';
  if gNetFlg = 0 then begin
    // 送信テキスト(XML)
    gSNDFPath := sFDir + 'SPKSEND.XML';
    // 受信テキスト(XML)
    gRCVFPath := sFDir + 'SPKRECV.XML';
  end else begin
    // 送信テキスト(XML)
    if gRestoreFlg = 1 then begin
      gSNDFPath := sFDir + 'NETRECR.XML';
    end else begin
      gSNDFPath := sFDir + 'NETSEND.XML';
    end;
    // 受信テキスト(XML)
    gRCVFPath := sFDir + 'NETRECV.XML';
  end;

  // WSSEヘッダー作成
  sWsse := xWsse;
  // エラー発生時
  if (gErrCode <> 0) or (gErrKbn <> 0) then begin
    iErrCode := gErrCode;
    Result   := gErrKbn;
    Exit;
  end;

  // データ送受信
  xUpLoad(sWsse);

  // エラー発生時
  if (gErrCode <> 0) or (gErrKbn <> 0) then begin
    iErrCode := gErrCode;
    Result   := gErrKbn;
  end;
end;

//******************************************************************************
// 送受信処理
//******************************************************************************
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
begin
  // 送信先サーバー名
  StrPCopy(Server,gAddress1);

  // 送信先CGI
  StrPCopy(Cgi,gAddress2);

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

    // エンパイヤの場合は、プロテクト情報を添付する
    if gNetFlg = 2 then begin
      FillChar(szHead,SizeOf(szHead),Ord(' '));
      s := 'X-PMREN:' + gUserCode;
      szHead  := PChar(s);
      iLength := Length(String(szHead));
      HttpAddRequestHeaders(hRequest,szHead,iLength,HTTP_ADDREQ_FLAG_REPLACE or HTTP_ADDREQ_FLAG_ADD);
    end;

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
    Reset(F);
    sData := '';
    sWk   := '';

    while not Eof(F) do begin
      Read(F,buf[0]);
      sData := sData + buf[0];
    end;

    CloseFile(F);

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
      // エラー内容：'ﾃﾞｰﾀ送信中にｴﾗｰが発生(SendRequest)(ｴﾗｰｺｰﾄﾞ)'
      gErrKbn  := 2;
      gErrCode := GetLastError;
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

    // 仕入受信区分チェック
    if gSJKbn = 1 then begin
      // 仕入受信時
      if (iSt = 200) or (iSt = 404) then bChkFlg := True;
    end else begin
      // 通常時
      if iSt = 200 then bChkFlg := True;
    end;

    if bChkFlg = False then begin
      // エラー内容：'ﾃﾞｰﾀ送信中にｴﾗｰが発生(ｴﾗｰｺｰﾄﾞ)'
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
      gErrCode := 0;
    end;
  finally
    InternetCloseHandle(hRequest);
    InternetCloseHandle(hConnect);
    InternetCloseHandle(hSession);
  end;
end;

//******************************************************************************
// WSSE認証用文字列の作成処理
//******************************************************************************
function xWsse: String;
var
  sWsse          : String;
  sUserName      : String;
  sNonce         : String;
  sCreated       : String;
  sPasswordDigest: String;
begin
  // WSSE認証用の文字列を作る
  // ■■　Username　■■
  sUserName := gUserName;

  // ■■　created　 ■■ ISO-8601表記で記述
  sCreated := gCreated;

  // ■■　nonce　　 ■■
  sNonce := gNonce;

  // ■■　passwordDigest　■■
  sPasswordDigest := gShaText;

  // ◆ BASE64エンコーディング
  sWsse := Format('X-WSSE: UsernameToken Username="%s", PasswordDigest="%s", Nonce="%s", Created="%s"',
                  [sUserName, xBase64EncodeStr(sPasswordDigest), sNonce, sCreated]);

  // WSSEヘッダー内容返却
  Result := sWsse;
end;

//******************************************************************************
// Base64エンコード関数呼出
//******************************************************************************
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

//******************************************************************************
// 受信データ(XML)作成処理
//******************************************************************************
procedure xMakeFile(sValue: String);
var
  F: TextFile;
begin
  AssignFile(F,gRCVFPath);
  Rewrite(F);
  try
// 2013/08/01 禁則文字変換対象取得方法変更 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//// 2013/05/17 修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
////    Write(F,Trim(sValue));
//    Write(F,Trim(xConvertRcvXmlDocument(sValue)));
//// 2013/05/17 修正 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    Write(F,Trim(xXMLRowConv(sValue)));
// 2013/08/01 禁則文字変換対象取得方法変更 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
  finally
    // ファイルを閉じる
    CloseFile(F);
  end;
end;

// 2013/05/17 修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
// 2013/08/01 禁則文字変換対象取得方法変更 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
////****************************************************************************//
//// module name : XMLドキュメント変換処理
////============================================================================//
//// parameter : sValue: String : 変換対象XMLドキュメント
////----------------------------------------------------------------------------//
//// return : String : 変換後XML文字列
////****************************************************************************//
//function xConvertRcvXmlDocument(sValue: String): String;
//const
//  cCR = #13;
//  cLF = #10;
//var
//  buf     : array [0..255] of Char;
//  iLength : Integer;
//  iIndex  : Integer;
//  sXml    : String;
//  sWk     : String;
//begin
//  Result := '';
//
//  sXml := '';
//  sWk := '';
//  iLength := Length(sValue);
//
//  for iIndex := 1 to iLength do begin
//    buf[0] := Char(sValue[iIndex]);
//    sWk := sWk + buf[0];
//
//    //改行コードの場合、XMLエンティティ参照文字列変換処理を実行する
//    if ( buf[0] = cLF ) then begin
//      sXml := sXml + xXMLRowConv(sWk);
//      sWk := '';
//    end;
//  end;
//
//  //最終行に改行コードがない場合、XMLエンティティ参照文字列変換処理を実行する
//  if ( 0 < Length(sWk) ) then
//    sXml := sXml + xXMLRowConv(sWk);
//
//  Result := sXml;
//end;
//
////****************************************************************************//
//// module name : XMLエンティティ参照文字列変換処理
////============================================================================//
//// parameter : cValue: String : 変換対象文字列行
////----------------------------------------------------------------------------//
//// return : String : 変換後文字列
////****************************************************************************//
//function xXMLRowConv(sValue: String): String;
//const
//  cLessThen  = '<';
//  cGreatThen = '>';
//  cSlash     = '/';
//var
//  bTagStartFlag : boolean;
//  iIndex        : integer;
//  iStartTagPos  : integer;
//  iEndTagPos    : integer;
//  iSlashPos     : integer;
//  iLength       : integer;
//  sData         : String;
//begin
//  Result := '';
//  iLength := Length(sValue);
//  iStartTagPos := 0;
//  iEndTagPos := iLength;
//  iSlashPos := -1;
//
//  // 開始タグの解析
//  bTagStartFlag := false;
//  for iIndex := 1 to iLength do begin
//    // マルチバイト文字は判別対象外
//    if ( mbSingleByte <> ByteType(sValue, iIndex ) ) then 
//      continue;
//
//    // >の場合、タグ終了
//    if ( sValue[iIndex] = cGreatThen ) and ( bTagStartFlag = true ) then begin
//      // /が>の手前になければ、開始終了タグではない
//      if ( iSlashPos >= 0 ) and ( iIndex <> iSlashPos + 1 ) then
//        iSlashPos := -1;
//
//      iStartTagPos := iIndex + 1;
//      break;
//    end;
//
//    // <の場合、タグ開始
//    if ( sValue[iIndex] = cLessThen ) then
//      bTagStartFlag := true;
//
//   // /の場合、終了タグの可能性あり
//    if ( sValue[iIndex] = cSlash ) then
//      iSlashPos := iIndex;
//  end;
//
//  // /が発生していない場合、終了タグの解析を行う
//  if ( iSlashPos = -1 ) then begin
//    bTagStartFlag := false;
//    for iIndex := iLength downto 1 do begin
//      // マルチバイト文字は判別対象外
//      if ( mbSingleByte <> ByteType(sValue, iIndex ) ) then
//        continue;
//
//      // <の場合、タグ終了（逆順なので）の可能性あり
//      if ( sValue[iIndex] = cLessThen ) and ( bTagStartFlag = true ) then begin
//        // /が<のあとになければ、終了タグではない
//        if ( iSlashPos >= 0 ) and ( iIndex = iSlashPos - 1 ) then begin
//          iEndTagPos := iIndex - 1;
//          break;
//        end;
//      end;
//
//      // >の場合、タグ開始（逆順なので）
//      if ( sValue[iIndex] = cGreatThen ) then
//        bTagStartFlag := true;
//
//      // /の場合、終了タグの可能性あり
//      if ( sValue[iIndex] = cSlash ) then
//        iSlashPos := iIndex;
//    end;
//  end;
//
//  // 変換処理
//  for iIndex := 1 to iLength do begin
//    if ( mbSingleByte <> ByteType(sValue, iIndex ) ) then begin
//      // マルチバイト文字は変換対象外
//      sData := sData + sValue[iIndex];
//    end else if ( iStartTagPos <= iIndex ) and ( iIndex <= iEndTagPos ) then begin
//      //iStartTagPos <= iIndex <= iEndTagPosが変換対象
//      sData := sData + xXMLProhibitionCharToStr(sValue[iIndex]);
//    end else begin
//      sData := sData + sValue[iIndex];
//    end;
//  end;
//
//  Result := sData;
//end;
//****************************************************************************//
// module name : XMLエンティティ参照文字列変換処理
//============================================================================//
// parameter : cValue: String : 変換対象文字列行
//----------------------------------------------------------------------------//
// return : String : 変換後文字列
//****************************************************************************//
function xXMLRowConv(sValue: String): String;
const
  cLessThen  = '<';
  cGreatThen = '>';
  cSlash     = '/';
  cSlashGreatThen = '/>';
  keys : array[0..10] of String = (
     'KUBUN','REQNO','REMARK','NHNKB','JYUHNNO','SYUHNNO'
    ,'MKCD' ,'HINNM','BOKB'  ,'CHKCD','LINERR');
  cKeyCount = 10;
// 2013/09/03 UOEリクエスト送信処理受信データ不正対応 >>>>>>>>>>>>>>>>>>>>>>>>>>
  cEndTag = '</NETRECV>';
// 2013/09/03 UOEリクエスト送信処理受信データ不正対応 <<<<<<<<<<<<<<<<<<<<<<<<<<
// 2014/04/01 受信XMLデータでリマークに空白を設定 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
  cRemarkValue = '';
// 2014/04/01 受信XMLデータでリマークに空白を設定 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
var
  iIndex     : integer;
  iStartPos  : integer;
  iNextPos   : integer;
  iEndPos    : integer;
  iLength    : integer;
  sData      : String;

  iEndIndex : integer;
  bTagFindFlag : boolean;
  iIdx2 : integer;
  sTmp , sTag: String;
// 2014/04/01 受信XMLデータでリマークに空白を設定 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
  iKeyIndex :  integer;                               // 変換中タグインデックス
// 2014/04/01 受信XMLデータでリマークに空白を設定 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
begin
  iIndex := 0;
  sData := '';
  Result := '';
  iLength := Length(sValue);
  iEndIndex := 0;

// 2013/09/03 UOEリクエスト送信処理受信データ不正対応 >>>>>>>>>>>>>>>>>>>>>>>>>>
  // 変換対象文字列長を終端タグ（</NETRECV>）までとする
  if ( iLength > 0 ) then begin
// 2014/04/01 ②対象タグの大文字小文字混在対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//    iEndPos := Pos( cEndTag, sValue );
    iEndPos := Pos( cEndTag, AnsiUpperCase(sValue) );
// 2014/04/01 ②対象タグの大文字小文字混在対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    if ( iEndPos > 0 ) then begin
      iLength := iEndPos - 1 + Length(cEndTag) ;
    end;
  end;

// 2013/09/03 UOEリクエスト送信処理受信データ不正対応 <<<<<<<<<<<<<<<<<<<<<<<<<<
  while iIndex < iLength do begin
    iIndex := iIndex + 1;
    // マルチバイト文字は判別対象外
    if ( mbSingleByte <> ByteType(sValue, iIndex ) ) then begin
      continue;
    end;
    // <の場合、タグ解析
    if ( sValue[iIndex] = cLessThen ) then begin
      bTagFindFlag := false;
// 2014/04/01 受信XMLデータでリマークに空白を設定 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
      iKeyIndex := -1;
// 2014/04/01 受信XMLデータでリマークに空白を設定 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
      sTag := '';
      for iIdx2 := 0 to cKeyCount do begin
        if ( Copy(sValue, iIndex+1, Length(keys[iIdx2])) = keys[iIdx2] ) then begin
          //'<'以降の文字がキーの場合、変換対象の開始タグか否か確認
          sTmp := Copy(sValue, iIndex+1+Length(keys[iIdx2]), iLength);
          if ( Copy(Trim(sTmp),1,1) <> cGreatThen ) then begin
            //キーに続く文字が'>'以外の場合、変換対象外
            continue;
          end;
          sTag := keys[iIdx2];
          bTagFindFlag := true;
// 2014/04/01 受信XMLデータでリマークに空白を設定 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
          iKeyIndex := iIdx2;
// 2014/04/01 受信XMLデータでリマークに空白を設定 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
          break;
        end;
      end;
      if ( bTagFindFlag = false ) then begin
        continue;
      end;
      //変換開始位置
      iStartPos := iIndex + Length(sTag) + Pos(cGreatThen,sTmp) + 1;
      iEndPos := iIndex + Length(sTag);
      //終了タグの前に開始タグが存在する可能性があるので、次の開始タグの位置を検索する
      iNextPos := Pos( cLessThen + sTag + cGreatThen,sTmp);
      if ( iNextPos > 0 ) then begin
        iNextPos := iEndPos + iNextPos - 1;
      end;
      //変換終了位置(終了タグの手前まで)
      sTag := cLessThen + cSlash + sTag + cGreatThen;
      iEndPos := iEndPos + Pos(sTag,sTmp) - 1;

      if ( ( iNextPos > 0 ) And ( iNextPos < iEndPos ) ) then begin
        // 次の開始タグ位置 < 次の終了タグ位置ならスキップ
        continue;
      end;
      if ( iStartPos > iEndPos ) then begin
        // 変換開始位置 > 変換終了位置ならスキップ
        continue;
      end;

      //変換開始位置までのコピー
      sTmp := Copy(sValue, iEndIndex + 1, iStartPos - 1 - iEndIndex );
      sData := sData + sTmp;
      //変換
// 2014/04/01 受信XMLデータでリマークに空白を設定 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//      for iIdx2 := iStartPos to iEndPos do begin
//        sData := sData + xXMLProhibitionCharToStr(sValue[iIdx2]);
//      end;
      case iKeyIndex of
        2, 9:
          //開始タグが'REMARK'または'CHKCD'の場合、空白をセット。
          sData := sData + cRemarkValue;
        0, 1, 3, 4, 5, 6, 7, 8, 10:
          begin
            //開始タグが'REMARK'および'CHKCD'以外の場合、XMLエンティティ参照文字変換処理
            for iIdx2 := iStartPos to iEndPos do begin
              sData := sData + xXMLProhibitionCharToStr(sValue[iIdx2]);
            end;
          end;
      end;
// 2014/04/01 受信XMLデータでリマークに空白を設定 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
      //終了タグのコピー
      sData := sData + sTag;
      iEndIndex := iEndPos + Length(sTag);
      iIndex := iEndIndex;
    end;
  end;

  if ( iEndIndex < iLength ) then begin
// 2013/09/03 UOEリクエスト送信処理受信データ不正対応 >>>>>>>>>>>>>>>>>>>>>>>>>>
//    sData := sData + Copy(sValue, iEndIndex + 1, iLength - iEndIndex + 1);
    sData := sData + Copy(sValue, iEndIndex + 1, iLength - iEndIndex);
// 2013/09/03 UOEリクエスト送信処理受信データ不正対応 <<<<<<<<<<<<<<<<<<<<<<<<<<
  end;

  Result := sData;
end;
// 2013/08/01 禁則文字変換対象取得方法変更 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

//****************************************************************************//
// module name : XMLエンティティ参照文字変換処理
//============================================================================//
// parameter : cValue: Char : 変換対象文字
//----------------------------------------------------------------------------//
// return : String : 変換後文字列
//****************************************************************************//
function xXMLProhibitionCharToStr(cValue: Char): String;
const
  ProhibitionChar: array [0..4] of Char = ('<','>','&','''','"');
  EntityStr: array [0..4] of String = ('&lt;','&gt;','&amp;','&quot;','&apos;');
var
  iIndex   : Integer;
begin
  Result := cValue;

  for iIndex := 0 to 4 do begin
    if ProhibitionChar[iIndex] = cValue then begin
      Result := EntityStr[iIndex];
      break;
    end;
  end;
end;
// 2013/05/17 修正 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

end.
