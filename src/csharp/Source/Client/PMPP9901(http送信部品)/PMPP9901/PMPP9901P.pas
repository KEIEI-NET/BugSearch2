//****************************************************************************//
//  ���ю���       : PM.NS                                                    //
//  �����ް�ޮ�    : 8.10.1.0                                                 //
//  ��۸����ް�ޮ� : 1.00                                                     //
//  հ�ް�ԍ�      :                                                          //
//  ��۸���ID      : PMPP9901                                                 //
//  ��۸��і�      : Http���M���i                                             //
//  ��۸��ю��    :                                                          //
//  ��۸��ю��    :                                                          //
//  DFDNo.         :                                                          //
//  ����           : Delphi                                                   //
//  �����ް�ޮ�    : 5.0                                                      //
//  �����ް�ޮ�    : PTSP5.00                                                 //
//  �N�����Ұ�     :                                                          //
//  �N����         :                                                          //
//  ���l           :                                                          //
//----------------------------------------------------------------------------//
//            (c) Copyright 2015 BroadLeaf Corporation                        //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 11000127-00  �쐬�S�� : ���X�� �M�p     �쐬���� �D�y��1�J����    //
// ������   2015/01/08   �C�����e : �V�K�쐬                                  //
//----------------------------------------------------------------------------//
//****************************************************************************//
unit PMPP9901P;

interface

uses
  Windows, SysUtils, WinInet;

type
 TGetHashText =Function( argc:Integer; argv:PChar; len:Pointer; buffer:Pchar):Integer;  stdcall;

// �O���ďo�֐��ihttp����M�����̎��s�j
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

  // ����M����
  procedure xUpLoad(sWsse: String); forward;
  // WSSE�F�ؗp������̍쐬����
  function  xWsse: String; forward;
  // Base64�G���R�[�h�֐��ďo
  function  xBase64EncodeStr(const Value: String): String; forward;
  // Base64�G���R�[�h����
  function  xBase64Encode(pInput: Pointer; pOutput: Pointer; iSize: Longint): Longint; forward;
  // UTF8�ݺ��ޏ���
  function xUTF8(sStr: String; iMode: Integer): String; forward;
  // SJIS��UTF-8�ɕϊ�
  function SJIS2UTF(sStr: String): String; forward;
  // UTF-8��SJIS�ɕϊ�
  function UTF82Sjis(sUTFStr: String): String; forward;
  // ��M�f�[�^(XML)�쐬����
  procedure xMakeFile(sValue: String);

var
  gAddress1  : String;    // URL
  gAddress2  : String;    // CGI
  gUserName  : String;    // ���[�U�[��
  gPassword  : String;    // �p�X���[�h
  gSNDFPath  : String;    // ���M�t�@�C���p�X
  gRCVFPath  : String;    // ��M�t�@�C���p�X
  gLOGFPath  : String;    // ���O�t�@�C���p�X
  gSSL       : Smallint;  // SSL�敪
  gUserCode  : String;    // ���[�U�[�R�[�h
  gTimeOut   : Longint;   // �^�C���A�E�g����
  gErrKbn    : Smallint;  // �G���[�敪
  gErrCode   : Smallint;  // �G���[�R�[�h
  gErrMessage: String;    // �G���[���b�Z�[�W
//  gMessage   : String;    // �G���[�ȊO�̃��b�Z�[�W

const
  _UserAgent = 'Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.0.3705; .NET CLR 1.1.4322; .NET CLR 2.0.50727)';
  _Boundary  = '-----------------------------7d21cef303f8';
  _LF        = #13#10;
  _SndFileEx = '.Xml';
  _RcvFileEx = 'RECV.XML';

implementation

//******************************************************************************
// ���C������
// ����  �FURL,CGI,հ�ް��,�߽ܰ��,̧���ިڸ��,SSL�敪,հ�ް����,
//         ��ѱ�Ď���
// �߂�l�F�װ�敪
//******************************************************************************

//****************************************************************************//
//  module name : http����M�����̎��s
//============================================================================//
//  parameter   : sAddress1    : PChar      : �h���C��
//              : sAddress2    : PChar      : �����p�A�h���X
//              : sUserName    : PChar      : ���[�U�[�R�[�h
//              : sPassword    : PChar      : �p�X���[�h
//              : sFileDir     : PChar      : ���M�t�@�C���p�X
//              : sFileName    : PChar      : ���M�t�@�C����
//              : iSSL         : Smallint   : �v���g�R��[0:HTTP 1:HTTPS]
//              : sUserCode    : PChar      : ��ƃR�[�h
//              : iTimeOut     : Longint    : �^�C������
//              : var iErrCode : Smallint   : �G���[�R�[�h
//----------------------------------------------------------------------------//
//  return      :            Smallint       : �G���[�敪
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
  // ������
  iErrCode := 0;
  sWsse    := '';
  gErrKbn  := 0;
  gErrCode := 0;
  gErrMessage := '';

try
  // �����擾
  gAddress1   := sAddress1;    // URL
  gAddress2   := sAddress2;    // CGI
  gUserName   := sUserName;    // ���[�U�[��
  gPassword   := sPassword;    // �p�X���[�h
  sFDir       := sFileDir;     // �t�@�C���p�X
  gSSL        := iSSL;         // SSL�敪
  gUserCode   := sUserCode;    // ���[�U�[�R�[�h
  gTimeOut    := iTimeOut;     // �^�C���A�E�g����

  // ���M��M�e�L�X�g�p�X�ݒ�
  if IsPathDelimiter(sFDir,Length(sFDir)) = False then sFDir := sFDir + '\';
  // ���M�e�L�X�g(XML)
  gSNDFPath := sFDir + sFileName + _SndFileEx;
  // ��M�e�L�X�g(XML)
  gRCVFPath := sFDir + sFileName + _RcvFileEx;

  // WSSE�w�b�_�[�쐬
  sWsse := xWsse;

  // �f�[�^����M
  if (gErrCode = 0) and (gErrKbn = 0) then begin
    xUpLoad(sWsse);
  end;

  // ���ʑ��
  iErrCode    := gErrCode;
  Result      := gErrKbn;
except
  iErrCode    := -1;
  Result      := -1;
end;

end;

//****************************************************************************//
//  module name : ����M����
//============================================================================//
//  parameter   : sWsse        : String     : WSSE�w�b�_�[������
//****************************************************************************//
procedure xUpLoad(sWsse: String);
var
  hSession  ,
  hConnect  ,
  hRequest  : HINTERNET;
  F         : TextFile;
  Server    : array [0..127] of Char;  // ���M��T�[�o�[����
  Cgi       : array [0..255] of Char;  // ���M��CGI����
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
  // ���M��T�[�o�[��
  StrPCopy(Server,gAddress1);

  // ���M��CGI
  StrPCopy(Cgi,gAddress2);

  // ���M÷��(XML)���݊m�F
  if not FileExists(gSNDFPath) then begin
    // �װ���e�F'�ް����M�Ώ�̧�ق�����܂���(AssignFile)(̧���߽)'
    gErrMessage := '�ް����M�Ώ�̧�ق�����܂���(AssignFile)(' + gSNDFPath + ')';
    gErrKbn     := -1;
    gErrCode    := -2;
    Exit;
   end;

  // ������
  hRequest := nil;
  hConnect := nil;
  hSession := nil;
  bChkFlg  := False;

  // ��M�e�L�X�g(XML)�폜����
  if FileExists(gRCVFPath) then begin
    DeleteFile(gRCVFPath);
  end;

  try
    // �ڑ��m�F
    lSt := InternetGetConnectedState(@dwFlags2,0);
    if (InternetAttemptConnect(0) <> ERROR_SUCCESS) or (lSt = False) then begin
      // �G���[���e�F'�������� �װ(AttemptConnect)'
      gErrMessage := '�������� �װ(AttemptConnect)';
      gErrKbn  := 1;
      gErrCode := 1;
      Exit;
    end;

    // ���C���^�[�l�b�g�T�[�r�X�̃n���h�����擾(WinInet�g�p�J�n)
    hSession := InternetOpen(PChar(_UserAgent),
                             INTERNET_OPEN_TYPE_PRECONFIG,
                             nil,
                             nil,
                             0);

    if Assigned(hSession) = False then begin
      // �G���[���e�F'�������� �װ(Open)'
      gErrMessage := '�������� �װ(Open)';
      gErrKbn  := 1;
      gErrCode := 2;
      Exit;
    end;

    // SSL�敪����
    if gSSL = 1 then begin
      //---<< HTTPS�ʐM >>---
      // ��HTTP�܂���FTP�T�[�o�֐ڑ�
      hConnect := InternetConnect(hSession,
                                  @Server,
                                  INTERNET_DEFAULT_HTTPS_PORT,  // �|�[�g�̎w��(443)
                                  nil,
                                  nil,
                                  INTERNET_SERVICE_HTTP,
                                  0,
                                  0);

      if Assigned(hConnect) = False then begin
        // �G���[���e�F'�������� �װ(Connect)'
        gErrMessage := '�������� �װ(Connect)';
        gErrKbn  := 1;
        gErrCode := 3;
        Exit;
      end;

      // ��HTTP�T�[�o�ւ̃��N�G�X�g������
      hRequest := HttpOpenRequest(hConnect ,
                                  'POST',
                                   @Cgi,
                                   nil,
                                   nil,
                                   nil,
                                   INTERNET_FLAG_SECURE,
                                   0);

      if Assigned(hRequest) = False then begin
        // �G���[���e�F'�������� �װ(HttpOpenRequest)'
        gErrMessage := '�������� �װ(HttpOpenRequest)';
        gErrKbn  := 1;
        gErrCode := 4;
        Exit;
      end;

      dwFlags := SECURITY_FLAG_IGNORE_UNKNOWN_CA or SECURITY_FLAG_IGNORE_CERT_CN_INVALID;
      dwFlags := dwFlags or SECURITY_FLAG_IGNORE_CERT_DATE_INVALID;
      dwFlags := dwFlags or SECURITY_FLAG_IGNORE_REDIRECT_TO_HTTP;
      dwFlags := dwFlags or SECURITY_FLAG_IGNORE_REDIRECT_TO_HTTPS;

      // ��hInternet�Ŏw�肳�ꂽ�C���^�[�l�b�g�̃I�v�V��������ݒ肷��
      lSt := InternetSetOption(hRequest,
                               INTERNET_OPTION_SECURITY_FLAGS,
                               @dwFlags,
                               SizeOf(dwFlags));
      if lSt = False then begin
        // �G���[���e�F'�������� �װ(SetOption)'
        gErrMessage := '�������� �װ(SetOption)';
        gErrKbn  := 1;
        gErrCode := 5;
        Exit;
      end;
    end else begin
      //---<< HTTPS�ʐM >>---
      // ��HTTP�܂���FTP�T�[�o�֐ڑ�
      hConnect := InternetConnect(hSession,
                                  @Server,
                                  INTERNET_DEFAULT_HTTP_PORT,
                                  nil,
                                  nil,
                                  INTERNET_SERVICE_HTTP,
                                  0,
                                  0);
      if Assigned(hConnect) = False then begin
        // �G���[���e�F'�������� �װ(Connect)'
        gErrMessage := '�������� �װ(Connect)';
        gErrKbn  := 1;
        gErrCode := 3;
        Exit;
      end;

      // ��HTTP�T�[�o�ւ̃��N�G�X�g������
      hRequest := HttpOpenRequest(hConnect,
                                  'POST',
                                  @Cgi,
                                  'HTTP/1.1',
                                  nil,
                                  nil,
                                  INTERNET_FLAG_RELOAD,
                                  1);
      if Assigned(hRequest) = False then begin
        // �G���[���e�F'�������� �װ(HttpOpenRequest)'
        gErrMessage := '�������� �װ(HttpOpenRequest)';
        gErrKbn  := 1;
        gErrCode := 4;
        Exit;
      end;
    end;

    // �w�b�_���ǉ�
    FillChar(szHead,SizeOf(szHead),Ord(' '));
    szHead  := 'Accept:*/*';
    iLength := Length(String(szHead));
    HttpAddRequestHeaders(hRequest,szHead,iLength,HTTP_ADDREQ_FLAG_REPLACE or HTTP_ADDREQ_FLAG_ADD);

    FillChar(szHead,SizeOf(szHead),Ord(' '));
    szHead  := 'Accept-Language:ja';
    iLength := Length(String(szHead));
    HttpAddRequestHeaders(hRequest,szHead,iLength,HTTP_ADDREQ_FLAG_REPLACE or HTTP_ADDREQ_FLAG_ADD);

    // WSSE�F�ؗp�̕���������
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


    // �]���t�@�C���쐬
    // �]���t�@�C����ǂݍ���
    AssignFile(F,gSNDFPath);
    try
      Reset(F);
    except
      // �װ���e�F'�ް����M�Ώ�̧�ق�����܂���(AssignFile)(̧���߽)'
      gErrMessage := '�ް����M�Ώ�̧�ٵ���ݏ����ŃG���[���������܂���(System.Reset)(' + gSNDFPath + ')';
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

    // �}���`�p�[�g�t�H�[��
    myString := myString +
                _Boundary+_LF+
                'Content-Disposition: form-data; name="xml_data"; ' +
                'filename=' + '"' +
                gSNDFPath+ '"' + _LF + _LF;

    // ������ sData �ɐݒ肳��Ă���]���t�@�C������Byte�ϐ��ɐݒ肷��
    pData := PChar(TrimRight(myString + sData + _LF + _Boundary + '--' + _LF));
    iLength := Length(pData);

    // �^�C���A�E�g���Ԃ̐ݒ�
    ms := gTimeOut;

    InternetSetOption(hRequest,INTERNET_OPTION_CONNECT_TIMEOUT,@ms,SizeOf(ms));
    InternetSetOption(hRequest,INTERNET_OPTION_CONTROL_RECEIVE_TIMEOUT,@ms,SizeOf(ms));
    InternetSetOption(hRequest,INTERNET_OPTION_CONTROL_SEND_TIMEOUT,@ms,SizeOf(ms));
    InternetSetOption(hRequest,INTERNET_OPTION_DATA_SEND_TIMEOUT,@ms,SizeOf(ms));
    InternetSetOption(hRequest,INTERNET_OPTION_DATA_RECEIVE_TIMEOUT,@ms,SizeOf(ms));

    // ���N�G�X�g���M
    lSt := HttpSendRequest(hRequest,nil,0,pData,iLength);

    if lSt = False then begin
      dwLastErr := GetLastError();
      gErrMessage := '�ް����M���ɴװ������(SendRequest)(' + IntToStr(dwLastErr) + ')';
      gErrKbn  := 2;
      gErrCode := dwLastErr;
      Exit;
    end;

    FillChar(Buf,SizeOf(Buf),Ord(' '));
    dwSize   := SizeOf(Buf);
    Reversed := 0;

    // �����X�|���X�̃X�e�[�^�X���C�����擾(��:HTTP/1.1 404 Object Not Found)
    HttpQueryInfo(hRequest,
                  HTTP_QUERY_RAW_HEADERS_CRLF,
                  @Buf,
                  dwSize,
                  Reversed);

    iSt := StrToIntDef(Copy(Buf,10,3),0);

    // �ʏ펞
    if iSt = 200 then bChkFlg := True;

    if bChkFlg = False then begin
      // �G���[���e�F'�ް����M���ɴװ������(�װ����)'
      gErrMessage := '�ް����M���ɴװ������(' + IntToStr(iSt) + ')';
      gErrKbn  := 3;
      gErrCode := iSt;
      Exit;
    end;

    if iSt = 200 then begin
      sValue := '';

      // �Ԃ��ꂽ�R���e���c�̓��e���擾
      while True do begin
        InternetQueryDataAvailable(hRequest,iBuffSize,0,0);
        // �Ǎ��߂�o�C�g�� = iBuffSize ��'0'�ɂȂ�����Break
        if (iBuffSize = 0) then Break;
        FillChar(ResultData,SizeOf(ResultData),Ord(' '));

        // ���Ԃ��ꂽ�R���e���c�̓��e���擾
        InternetReadFile(hRequest,@ResultData,256,c);
        sValue := sValue + ResultData;
      end;

      // ��M�f�[�^(XML)�쐬����
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
// WSSE�F�ؗp������̍쐬����
//****************************************************************************//
function xWsse: String;
var
  // �֐��߲��
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

  // DLL��۰��
  DLLHandle := LoadLibrary('SHA1.DLL');
  try
    if DLLHandle = 0 then begin
      gErrKbn     := 10;
      gErrCode    :=  1100;
      gErrMessage := 'sha1.DLL�����[�h�ł��܂���';
      Exit;
    end;

    // DLL������ق��g�p���A�֐����擾
    @GetHashText := GetProcAddress(DLLHandle, 'main');

    if (@GetHashText = nil) then begin
      gErrKbn     := -1;
      gErrCode    :=  0;
      gErrMessage := 'sha1.DLL�����[�h�ł��܂���';
      Exit;
    end;

    pData := nil;
    GetMem(pBuffer,41);
    ZeroMemory(pBuffer,41);

    // WSSE�F�ؗp�̕���������
    // �����@Username�@����
    sUserName := gUserName;

    // �����@created�@ ���� ISO-8601�\�L�ŋL�q
    sCreated := FormatDateTime('YYYY"-"MM"-"DD"T"hh:mm:ss"Z"',Now);

    // �����@nonce�@�@ ����
    Randomize;
    iWork  := Random($FFFFFFFF);
    sNonce := FormatDateTime('YYYYMMDDhhmmss',Now) + IntToHex(iWork, 8);

    // �����@passwordDigest�@����
    sText := sNonce + sCreated + gPassword;
    sWide := sText;

    // ���P UTF-8�ݺ��ިݸ�
    sText := xUTF8(sText,1);
    Move(sText,pData,SizeOf(sText));

    // ���Q SHA1ʯ���ϊ�
    iSts := GetHashText(Length(pData),pData,@iBufSize,pBuffer);
    if iSts = 0 then begin
      sPasswordDigest := String(pBuffer);
    end else begin
      gErrKbn     := 10;
      gErrCode    :=  1101;
      gErrMessage := 'ʯ���ϊ������Ŵװ���������܂���('+IntToStr(iSts)+')';
      Exit;
    end;

    FreeMem(pBuffer);

    // ���R BASE64�ݺ��ިݸ�
    sWsse := Format('X-WSSE: UsernameToken Username="%s", PasswordDigest="%s", Nonce="%s", Created="%s"',
                    [sUsername, xBase64EncodeStr(sPasswordDigest), sNonce, sCreated]);

    // WSSE�w�b�_�[���e�ԋp
    Result := sWsse;
  finally
    // DLL�̊J��
    FreeLibrary(DLLHandle);
  end;
end;

//****************************************************************************//
//  module name : Base64�G���R�[�h�֐��ďo
//============================================================================//
//  parameter   : Value        : String     : �G���R�[�h���镶����
//----------------------------------------------------------------------------//
//  return      :            String         : �G���R�[�h��̕�����
//****************************************************************************//
function xBase64EncodeStr(const Value: String): String;
begin
  SetLength(Result,((Length(Value)+2) div 3) * 4);
  xBase64Encode(@Value[1],@Result[1],Length(Value));
end;

//******************************************************************************
// Base64�G���R�[�h����
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
// �R�[�h�ϊ�
//============================================================================//
//  parameter   : sStr         : String     : �R�[�h�ϊ��O������
//              : iMode        : Integer    : �ϊ��敪[1:SJIS��UTF-8][1�ȊO:UTF-8��SJIS]
//----------------------------------------------------------------------------//
//  return      :            String         : �R�[�h�ϊ�����
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
// SJIS��UTF-8�ɕϊ�
//============================================================================//
//  parameter   : sStr         : String     : �R�[�h�ϊ��O������
//----------------------------------------------------------------------------//
//  return      :            String         : �R�[�h�ϊ�����
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
      // ��UUnicode�ɕϊ�
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
// UTF-8��SJIS�ɕϊ�
//============================================================================//
//  parameter   : sStr         : String     : �R�[�h�ϊ��O������
//----------------------------------------------------------------------------//
//  return      :            String         : �R�[�h�ϊ�����
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
  // ������̏I�������o���邽�߂ɔԕ�4�l�𗧂Ă�
  pUc := PChar(sUTFStr + #0#0#0#0);
  // ���S������4�{����؂��m��
  pUsc2 := AllocMem(iLen * 4);
  // pUsc2���߲���Ƃ��Ďg���̂�pWc�ɐ擪���ڽ��ۑ�
  pWc := PWideChar(pUsc2);
  try
    while pUc^ <> #0 do begin
      // ASCII
      if pUc^ in [#0..#$7F] then begin
        pUsc2^ := pUc^;
        (pUsc2+1)^ := #0;
        Inc(pUsc2, 2);
        Inc(pUc);
      // 2byte��������1
      end else if pUc^ in [#$C0.. #$DF] then begin
        wUn := (Ord(pUc^) and $1F) shl 6 + Ord((pUc+1)^) and $3F;
        pUsc2^ := Char(Lo(wUn));
        (pUsc2+1)^ := Char(Hi(wUn));
        Inc(pUsc2, 2);
        Inc(pUc, 2);
      // 2byte��������2
      end else if pUc^ in [#$E0..#$EF] then begin
        wUn := (Ord(pUc^) and $0F) shl 12 + (Ord((pUc+1)^) and $3F) shl 6
              + (Ord((pUc+2)^) and $3F);
        pUsc2^ := Char(Lo(wUn));
        (pUsc2+1)^ := Char(Hi(wUn));
        Inc(pUsc2, 2);
        Inc(pUc, 3);
      // 4byte����(USC-4�̂�)
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
    // UTF����ϊ�����Unicode��String�^�ŕԂ��B
    Result := pWc;
  finally
    FreeMem(pWc);
  end;
end;


//******************************************************************************
// ��M�f�[�^(XML)�쐬����
//============================================================================//
//  parameter   : sValue       : String     : �i�[������
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
    // �t�@�C�������
    CloseFile(F);
  end;
end;

end.
