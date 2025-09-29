//****************************************************************************//
//  ���ю���       : PM.NS                                                      //
//  �����ް�ޮ�    : 1.00                                                     //
//  ��۸����ް�ޮ� : 1.00                                                     //
//  հ�ް�ԍ�      :                                                          //
//  ��۸���ID      : PMPU9013                                                 //
//  ��۸��і�      : UOE���N�G�X�g���M���i                                    //
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
//            (c) Copyright 2012 BroadLeaf Corporation                        //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� xxxxxxxx-00  �쐬�S�� : ���R �F�K       �쐬���� �D�y��1�J����    //
// ������   2012/04/02   �C�����e : �V�K�쐬                                  //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� xxxxxxxx-00  �쐬�S�� : FSI���X�� �M�p  �쐬���� �D�y��1�J����    //
// ������   2013/05/17   �C�����e : ������v�f���֑̋�����(<,>,&,",',)��      //
//                                  XML�G���e�B�e�B�Q��(&lt;,&gt;,&amp;,      //
//                                  &quot;,&apos;)�ɕϊ�����XML�ɏo�͂���悤 //
//                                  �C��                                      //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10900008-00  �쐬�S�� : FSI���X�� �M�p  �쐬���� �D�y��1�J����    //
// ������   2013/08/01   �C�����e : �֑������ϊ��Ώێ擾���@�ύX              //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10902175-00  �쐬�S�� : FSI���X�� �M�p  �쐬���� �D�y��1�J����    //
// ������   2013/09/03   �C�����e : UOE���N�G�X�g���M������M�f�[�^�s���Ή�   //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10904597-00  �쐬�S�� : FSI���X�� �M�p  �쐬���� �D�y��1�J����    //
// ������   2014/04/01   �C�����e : �@��MXML�f�[�^�Ń��}�[�N�ɋ󔒂�ݒ�     //
//                                : �A�ϊ��ΏۏI���^�ONETRECV�ɑ啶���������� //
//                                    ���݂���ꍇ���ΏۂƂ���悤�C��        //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 11100068-00  �쐬�S�� : 30757���X�� �M�p  �쐬���� �D�y�J����     //
// ������   2015/07/08   �C�����e : WebUOE���N�G�X�g���M���� ��M�d���s���Ή� //
//                                  ����M�d���̍Ō��</DATA>�^�O�`</NETRECV> //
//                                    �^�O�Ԃɕs�v�ȕ����񂪑��݂���ꍇ�A����//
//                                    ��������폜����悤�C��                //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 11100068-00  �쐬�S�� : 30757���X�� �M�p  �쐬���� �D�y�J����     //
// ������   2015/07/23   �C�����e : WebUOE���N�G�X�g���M���� ��M�d���s���Ή� //
//                                  ���V�X�e���e�X�g��Q�i���jNo.1 �Ή�       //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 11100068-00  �쐬�S�� : 30757���X�� �M�p  �쐬���� �D�y�J����     //
// ������   2015/08/03   �C�����e : WebUOE���N�G�X�g���M���� �f�O���[�h�Ή�   //
//                                  ��2015/07/08��M�d���s���Ή���SPK�����   //
//                                    �����d����M�ŃG���[�ƂȂ�s����C��  //
//                                    ��SPK�̉����d���̏ꍇ�A���������s���Ȃ� //
//****************************************************************************//
// �Ǘ��ԍ� 11275084-00  �쐬�S�� : 30757���X�� �M�p  �쐬���� �D�y�J����     //
// ������   2016/05/06   �C�����e : SPK�d����M�G���[�Ή��i�d����M�̏ꍇ     //
//                                  ���}�[�N���֑������ϊ��ΏۂƂ���          //
//----------------------------------------------------------------------------//

unit PMPU9013P;

interface

uses
  Windows, SysUtils, WinInet;

// �O���ďo�֐��錾��(����:URL,CGI,հ�ް��,�߽ܰ��,̧���ިڸ��,SSL�敪,NET�׸�,
//                         հ�ް����,��ѱ�Ď���,nonce,created,SHA1ʯ���ϊ��l,
//                         �d����M�敪,�����׸�,�װ����)
function xPMPU9013(sAddress1: PChar; sAddress2: PChar; sUserName: PChar; sPassword: PChar;
                   sFileDir: PChar; iSSL: Smallint; iNetFlg: Smallint; sUserCode: PChar;
                   iTimeOut: Longint; sNonce: PChar; sCreated: PChar; sShaText: PChar;
                   iSJKbn: Smallint; iRestoreFlg: Smallint; var iErrCode: Smallint): Smallint; stdcall; overload; export;

  // ����M����
  procedure xUpLoad(sWsse: String); forward;
  // WSSE�F�ؗp������̍쐬����
  function xWsse: String; forward;
  // Base64�G���R�[�h�֐��ďo
  function xBase64EncodeStr(const Value: String): String; forward;
  // Base64�G���R�[�h����
  function  xBase64Encode(pInput: Pointer; pOutput: Pointer; iSize: Longint): Longint; forward;
  // ��M�f�[�^(XML)�쐬����
  procedure xMakeFile(sValue: String);
// 2013/05/17 �C�� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
// 2013/08/01 �֑������ϊ��Ώێ擾���@�ύX >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//  // XML�h�L�������g�ϊ�����
//  function xConvertRcvXmlDocument(sValue: String): String; forward;
// 2013/08/01 �֑������ϊ��Ώێ擾���@�ύX <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
  // XML�G���e�B�e�B�Q�ƕ�����ϊ�����
  function xXMLRowConv(sValue: String): String; forward;
  // XML�G���e�B�e�B�Q�ƕ����ϊ�
  function xXMLProhibitionCharToStr(cValue: Char): String; forward;
// 2013/05/17 �C�� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
// 2016/05/06 ADD 30757���X�� �M�p SPK�d����M�G���[�Ή� >>>>>>>>>>>>>>>>>>>>>>>
  // �d����M�敪���菈��
  function xGetReceivingStockKbn(sValue: String): Smallint; forward;
// 2016/05/06 ADD 30757���X�� �M�p SPK�d����M�G���[�Ή� <<<<<<<<<<<<<<<<<<<<<<<
// 2015/07/08 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�>>>>>>>>>>>>
  //</DATA>�`</NETRECV>�ԕs�v������폜����
  function xDeleteUnnecessaryChars(sValue: String): String; forward;
// 2015/07/08 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�<<<<<<<<<<<<


var
  gAddress1  : String;    // URL
  gAddress2  : String;    // CGI
  gUserName  : String;    // ���[�U�[��
  gPassword  : String;    // �p�X���[�h
  gSNDFPath  : String;    // ���M�t�@�C���p�X
  gRCVFPath  : String;    // ��M�t�@�C���p�X
  gSSL       : Smallint;  // SSL�敪
  gNetFlg    : Smallint;  // NET�t���O
  gUserCode  : String;    // ���[�U�[�R�[�h
  gTimeOut   : Longint;   // �^�C���A�E�g����
  gNonce     : String;    // WSSE�F�ؗp nonce
  gCreated   : String;    // WSSE�F�ؗp created
  gShaText   : String;    // WSSE�F�ؗp SHA1�n�b�V���ϊ��l
  gSJKbn     : Smallint;  // �d����M�敪(0:�ʏ� 1:�d����M)
  gRestoreFlg: Smallint;  // �����t���O(0:�ʏ� 1:��������)
  gErrKbn    : Smallint;  // �G���[�敪
  gErrCode   : Smallint;  // �G���[�R�[�h
// 2016/05/06 ADD 30757���X�� �M�p SPK�d����M�G���[�Ή� >>>>>>>>>>>>>>>>>>>>>>>
  gRecvStockKbn :Smallint;// �d����M�敪
// 2016/05/06 ADD 30757���X�� �M�p SPK�d����M�G���[�Ή� <<<<<<<<<<<<<<<<<<<<<<<

const
  _UserAgent = 'Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.0.3705; .NET CLR 1.1.4322; .NET CLR 2.0.50727)';
  _Boundary  = '-----------------------------7d21cef303f8';
  _LF        = #13#10;

// 2016/05/06 ADD 30757���X�� �M�p SPK�d����M�G���[�Ή� >>>>>>>>>>>>>>>>>>>>>>>
  _RecvStockKbnTrue = 1;  // �d����M�敪�L��
  _RecvStockKbnFalse = 0; // �d����M�敪����
  _DenbKbRecvStock = '60';  // �d���敪�F�d����M
// 2016/05/06 ADD 30757���X�� �M�p SPK�d����M�G���[�Ή� <<<<<<<<<<<<<<<<<<<<<<<

implementation

//******************************************************************************
// ���C������
// ����  �FURL,CGI,հ�ް��,�߽ܰ��,̧���ިڸ��,SSL�敪,NET�׸�,հ�ް����,
//         ��ѱ�Ď���,nonce,created,SHA1ʯ���ϊ��l,�d����M�敪,�����׸޴װ����
// �߂�l�F�װ�敪
//******************************************************************************
function xPMPU9013(sAddress1: PChar; sAddress2: PChar; sUserName: PChar; sPassword: PChar;
                   sFileDir: PChar; iSSL: Smallint; iNetFlg: Smallint; sUserCode: PChar;
                   iTimeOut: Longint; sNonce: PChar; sCreated: PChar; sShaText: PChar;
                   iSJKbn: Smallint; iRestoreFlg: Smallint; var iErrCode: Smallint): Smallint; stdcall; overload;
var
  sWsse: String;
  sFDir: String;
begin
  // ������
  Result   := 0;
  iErrCode := 0;
  sWsse    := '';
  gErrKbn  := 0;
  gErrCode := 0;

  // �����擾
  gAddress1   := sAddress1;    // URL
  gAddress2   := sAddress2;    // CGI
  gUserName   := sUserName;    // ���[�U�[��
  gPassword   := sPassword;    // �p�X���[�h
  sFDir       := sFileDir;     // �t�@�C���p�X
  gSSL        := iSSL;         // SSL�敪
  gNetFlg     := iNetFlg;      // NET�t���O
  gUserCode   := sUserCode;    // ���[�U�[�R�[�h
  gTimeOut    := iTimeOut;     // �^�C���A�E�g����
  gNonce      := sNonce;       // WSSE�F�ؗp nonce
  gCreated    := sCreated;     // WSSE�F�ؗp created
  gShaText    := sShaText;     // WSSE�F�ؗp SHA1�n�b�V���ϊ��l
  gSJKbn      := iSJKbn;       // �d����M�敪
  gRestoreFlg := iRestoreFlg;  // �����t���O

  // ���M��M�e�L�X�g�p�X�ݒ�
  if IsPathDelimiter(sFDir,Length(sFDir)) = False then sFDir := sFDir + '\';
  if gNetFlg = 0 then begin
    // ���M�e�L�X�g(XML)
    gSNDFPath := sFDir + 'SPKSEND.XML';
    // ��M�e�L�X�g(XML)
    gRCVFPath := sFDir + 'SPKRECV.XML';
  end else begin
    // ���M�e�L�X�g(XML)
    if gRestoreFlg = 1 then begin
      gSNDFPath := sFDir + 'NETRECR.XML';
    end else begin
      gSNDFPath := sFDir + 'NETSEND.XML';
    end;
    // ��M�e�L�X�g(XML)
    gRCVFPath := sFDir + 'NETRECV.XML';
  end;

  // WSSE�w�b�_�[�쐬
  sWsse := xWsse;
  // �G���[������
  if (gErrCode <> 0) or (gErrKbn <> 0) then begin
    iErrCode := gErrCode;
    Result   := gErrKbn;
    Exit;
  end;

  // �f�[�^����M
  xUpLoad(sWsse);

  // �G���[������
  if (gErrCode <> 0) or (gErrKbn <> 0) then begin
    iErrCode := gErrCode;
    Result   := gErrKbn;
  end;
end;

//******************************************************************************
// ����M����
//******************************************************************************
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
begin
  // ���M��T�[�o�[��
  StrPCopy(Server,gAddress1);

  // ���M��CGI
  StrPCopy(Cgi,gAddress2);

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

    // �G���p�C���̏ꍇ�́A�v���e�N�g����Y�t����
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


    // �]���t�@�C����ǂݍ���
    AssignFile(F,gSNDFPath);
    Reset(F);
    sData := '';
    sWk   := '';

    while not Eof(F) do begin
      Read(F,buf[0]);
      sData := sData + buf[0];
    end;

    CloseFile(F);

// 2016/05/06 ADD 30757���X�� �M�p SPK�d����M�G���[�Ή� >>>>>>>>>>>>>>>>>>>>>>>
  // �d����M�敪������s��
  gRecvStockKbn := xGetReceivingStockKbn(sData);
// 2016/05/06 ADD 30757���X�� �M�p SPK�d����M�G���[�Ή� <<<<<<<<<<<<<<<<<<<<<<<

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
      // �G���[���e�F'�ް����M���ɴװ������(SendRequest)(�װ����)'
      gErrKbn  := 2;
      gErrCode := GetLastError;
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

    // �d����M�敪�`�F�b�N
    if gSJKbn = 1 then begin
      // �d����M��
      if (iSt = 200) or (iSt = 404) then bChkFlg := True;
    end else begin
      // �ʏ펞
      if iSt = 200 then bChkFlg := True;
    end;

    if bChkFlg = False then begin
      // �G���[���e�F'�ް����M���ɴװ������(�װ����)'
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
      gErrCode := 0;
    end;
  finally
    InternetCloseHandle(hRequest);
    InternetCloseHandle(hConnect);
    InternetCloseHandle(hSession);
  end;
end;

//******************************************************************************
// WSSE�F�ؗp������̍쐬����
//******************************************************************************
function xWsse: String;
var
  sWsse          : String;
  sUserName      : String;
  sNonce         : String;
  sCreated       : String;
  sPasswordDigest: String;
begin
  // WSSE�F�ؗp�̕���������
  // �����@Username�@����
  sUserName := gUserName;

  // �����@created�@ ���� ISO-8601�\�L�ŋL�q
  sCreated := gCreated;

  // �����@nonce�@�@ ����
  sNonce := gNonce;

  // �����@passwordDigest�@����
  sPasswordDigest := gShaText;

  // �� BASE64�G���R�[�f�B���O
  sWsse := Format('X-WSSE: UsernameToken Username="%s", PasswordDigest="%s", Nonce="%s", Created="%s"',
                  [sUserName, xBase64EncodeStr(sPasswordDigest), sNonce, sCreated]);

  // WSSE�w�b�_�[���e�ԋp
  Result := sWsse;
end;

//******************************************************************************
// Base64�G���R�[�h�֐��ďo
//******************************************************************************
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

//******************************************************************************
// ��M�f�[�^(XML)�쐬����
//******************************************************************************
procedure xMakeFile(sValue: String);
var
  F: TextFile;
// 2015/07/08 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�>>>>>>>>>>>>
  sReplace: String;
// 2015/07/08 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�<<<<<<<<<<<<
begin
  AssignFile(F,gRCVFPath);
  Rewrite(F);
  try

// 2015/07/08 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�>>>>>>>>>>>>
//// 2013/08/01 �֑������ϊ��Ώێ擾���@�ύX >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
////// 2013/05/17 �C�� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//////    Write(F,Trim(sValue));
////    Write(F,Trim(xConvertRcvXmlDocument(sValue)));
////// 2013/05/17 �C�� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//    Write(F,Trim(xXMLRowConv(sValue)));
//// 2013/08/01 �֑������ϊ��Ώێ擾���@�ύX <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    sReplace := xDeleteUnnecessaryChars(sValue);
    Write(F,Trim(xXMLRowConv(sReplace)));
// 2015/07/08 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�<<<<<<<<<<<<
  finally
    // �t�@�C�������
    CloseFile(F);
  end;
end;

// 2015/07/08 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�>>>>>>>>>>>>
//****************************************************************************//
// module name : </DATA>�`</NETRECV>�ԕs�v������폜����
//============================================================================//
// parameter : cValue: String : �����Ώە�����s
//----------------------------------------------------------------------------//
// return : String : �s�v������폜�㕶����
//****************************************************************************//
function xDeleteUnnecessaryChars(sValue: String): String;
const
  cStartTagLength = 7;
  cEndTagLength   = 10;
  cStartTag       = '</DATA>';
  cEndTag         = '</NETRECV>';
  cCRLF           = #13#10;
var
  iIndex         : integer;
  iStartPos      : integer;
  iLength        : integer;

  sBefore, sAfter: String;
// 2015/07/23 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�>>>>>>>>>>>>
  sStartTag, sEndTag: String;
// 2015/07/23 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�>>>>>>>>>>>>

begin
  sBefore := '';
  sAfter := '';
  Result := sValue;

  //
  //�u���O������̐���
  //

  //�ŏI</DATA>�^�O�ȍ~�`</NETRECV>�̕�����(�u���O������)�𐶐�
  sBefore := '';
  iIndex := Pos(cStartTag, AnsiUpperCase(sValue));
  while iIndex <> 0 do begin
    //</DATA>�^�O�ȍ~��u���O������Ƃ��ăZ�b�g
    if Length(sBefore) = 0 then begin
      sBefore := sValue;
    end;
// 2015/07/23 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�>>>>>>>>>>>>
    // </DATA>�^�O�̕�����(�啶��������)���u���O�ƈقȂ��XmlReader��NG
    // �ƂȂ�\�������邽�߁A�u���O�̃^�O�𒊏o���A�u����̃^�O�Ƃ���
    // ���p����B
    sStartTag := copy(sBefore, iIndex, cStartTagLength);
// 2015/07/23 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�<<<<<<<<<<<<
    iStartPos := iIndex + cStartTagLength;
    iLength := Length(sBefore) - iStartPos + 1;
    sBefore := Copy(sBefore, iStartPos, iLength);

    //����</DATA>�^�O�̈ʒu���擾
    iIndex := Pos(cStartTag, AnsiUpperCase(sBefore));
  end;
  //�u���O�����񂩂�</NETRECV>�ȍ~�̕�������폜
  iIndex := Pos(cEndTag, AnsiUpperCase(sBefore));
  if iIndex <> 0 then begin
// 2015/07/23 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�>>>>>>>>>>>>
    // </NETRECV>�^�O�̕�����(�啶��������)���u���O�ƈقȂ��XmlReader��NG
    // �ƂȂ邽�߁A�u���O�̃^�O�𒊏o���A�u����̃^�O�Ƃ��ė��p����B
    sEndTag := copy(sBefore, iIndex, cEndTagLength);
// 2015/07/23 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�<<<<<<<<<<<<
    iLength := iIndex + cEndTagLength - 1;
    sBefore := Copy(sBefore, 1, iLength);
// 2015/08/08 30757 ���X�� WebUOE���N�G�X�g���M���� �f�O���[�h�Ή�>>>>>>>>>>>>>>
  end else begin
     //�I�[�^�O��</NETRECV>�̏ꍇ�AsBefore�ɋ󕶎����ݒ肷��
     //�i�u���͍s���Ȃ��j
     sBefore := '';
// 2015/08/08 30757 ���X�� WebUOE���N�G�X�g���M���� �f�O���[�h�Ή�<<<<<<<<<<<<<<
  end;

  //
  //�u���㕶����̐���
  //
  if Length(sBefore) > 0 then begin
// 2015/07/23 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�>>>>>>>>>>>>
//    sAfter := cStartTag;
    sAfter := sStartTag;
// 2015/07/23 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�<<<<<<<<<<<<
    iIndex := Pos(cCRLF, sBefore);
    if iIndex > 0 then begin
      //�ŏI</DATA>�^�O�ȍ~�ŏ��̕��������s�R�[�h�̏ꍇ
      //�u���㕶����ɉ��s�R�[�h���܂߂�
      sAfter := sAfter + cCRLF;
    end;
    //�u���㕶����̖�����</NETRECV>��ǉ�����
// 2015/07/23 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�>>>>>>>>>>>>
//    sAfter := sAfter + cEndTag;
    sAfter := sAfter + sEndTag;
// 2015/07/23 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�<<<<<<<<<<<<
  end;
  
  //�u���O������̖`����</DATA>��}������
  if Length(sBefore) > 0 then begin
    sBefore := cStartTag + sBefore;
  end;

  //
  //�s�v�����̍폜
  //
  if Length(sBefore) > 0 then begin
    Result := StringReplace(sValue, sBefore, sAfter, [rfIgnoreCase]);
  end;

end;
// 2015/07/08 30757 ���X�� WebUOE���N�G�X�g���M���� ��M�d���s���Ή�<<<<<<<<<<<<

// 2013/05/17 �C�� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
// 2013/08/01 �֑������ϊ��Ώێ擾���@�ύX >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
////****************************************************************************//
//// module name : XML�h�L�������g�ϊ�����
////============================================================================//
//// parameter : sValue: String : �ϊ��Ώ�XML�h�L�������g
////----------------------------------------------------------------------------//
//// return : String : �ϊ���XML������
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
//    //���s�R�[�h�̏ꍇ�AXML�G���e�B�e�B�Q�ƕ�����ϊ����������s����
//    if ( buf[0] = cLF ) then begin
//      sXml := sXml + xXMLRowConv(sWk);
//      sWk := '';
//    end;
//  end;
//
//  //�ŏI�s�ɉ��s�R�[�h���Ȃ��ꍇ�AXML�G���e�B�e�B�Q�ƕ�����ϊ����������s����
//  if ( 0 < Length(sWk) ) then
//    sXml := sXml + xXMLRowConv(sWk);
//
//  Result := sXml;
//end;
//
////****************************************************************************//
//// module name : XML�G���e�B�e�B�Q�ƕ�����ϊ�����
////============================================================================//
//// parameter : cValue: String : �ϊ��Ώە�����s
////----------------------------------------------------------------------------//
//// return : String : �ϊ��㕶����
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
//  // �J�n�^�O�̉��
//  bTagStartFlag := false;
//  for iIndex := 1 to iLength do begin
//    // �}���`�o�C�g�����͔��ʑΏۊO
//    if ( mbSingleByte <> ByteType(sValue, iIndex ) ) then 
//      continue;
//
//    // >�̏ꍇ�A�^�O�I��
//    if ( sValue[iIndex] = cGreatThen ) and ( bTagStartFlag = true ) then begin
//      // /��>�̎�O�ɂȂ���΁A�J�n�I���^�O�ł͂Ȃ�
//      if ( iSlashPos >= 0 ) and ( iIndex <> iSlashPos + 1 ) then
//        iSlashPos := -1;
//
//      iStartTagPos := iIndex + 1;
//      break;
//    end;
//
//    // <�̏ꍇ�A�^�O�J�n
//    if ( sValue[iIndex] = cLessThen ) then
//      bTagStartFlag := true;
//
//   // /�̏ꍇ�A�I���^�O�̉\������
//    if ( sValue[iIndex] = cSlash ) then
//      iSlashPos := iIndex;
//  end;
//
//  // /���������Ă��Ȃ��ꍇ�A�I���^�O�̉�͂��s��
//  if ( iSlashPos = -1 ) then begin
//    bTagStartFlag := false;
//    for iIndex := iLength downto 1 do begin
//      // �}���`�o�C�g�����͔��ʑΏۊO
//      if ( mbSingleByte <> ByteType(sValue, iIndex ) ) then
//        continue;
//
//      // <�̏ꍇ�A�^�O�I���i�t���Ȃ̂Łj�̉\������
//      if ( sValue[iIndex] = cLessThen ) and ( bTagStartFlag = true ) then begin
//        // /��<�̂��ƂɂȂ���΁A�I���^�O�ł͂Ȃ�
//        if ( iSlashPos >= 0 ) and ( iIndex = iSlashPos - 1 ) then begin
//          iEndTagPos := iIndex - 1;
//          break;
//        end;
//      end;
//
//      // >�̏ꍇ�A�^�O�J�n�i�t���Ȃ̂Łj
//      if ( sValue[iIndex] = cGreatThen ) then
//        bTagStartFlag := true;
//
//      // /�̏ꍇ�A�I���^�O�̉\������
//      if ( sValue[iIndex] = cSlash ) then
//        iSlashPos := iIndex;
//    end;
//  end;
//
//  // �ϊ�����
//  for iIndex := 1 to iLength do begin
//    if ( mbSingleByte <> ByteType(sValue, iIndex ) ) then begin
//      // �}���`�o�C�g�����͕ϊ��ΏۊO
//      sData := sData + sValue[iIndex];
//    end else if ( iStartTagPos <= iIndex ) and ( iIndex <= iEndTagPos ) then begin
//      //iStartTagPos <= iIndex <= iEndTagPos���ϊ��Ώ�
//      sData := sData + xXMLProhibitionCharToStr(sValue[iIndex]);
//    end else begin
//      sData := sData + sValue[iIndex];
//    end;
//  end;
//
//  Result := sData;
//end;
//****************************************************************************//
// module name : XML�G���e�B�e�B�Q�ƕ�����ϊ�����
//============================================================================//
// parameter : cValue: String : �ϊ��Ώە�����s
//----------------------------------------------------------------------------//
// return : String : �ϊ��㕶����
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
// 2013/09/03 UOE���N�G�X�g���M������M�f�[�^�s���Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>
  cEndTag = '</NETRECV>';
// 2013/09/03 UOE���N�G�X�g���M������M�f�[�^�s���Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<
// 2014/04/01 ��MXML�f�[�^�Ń��}�[�N�ɋ󔒂�ݒ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
  cRemarkValue = '';
// 2014/04/01 ��MXML�f�[�^�Ń��}�[�N�ɋ󔒂�ݒ� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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
// 2014/04/01 ��MXML�f�[�^�Ń��}�[�N�ɋ󔒂�ݒ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
  iKeyIndex :  integer;                               // �ϊ����^�O�C���f�b�N�X
// 2014/04/01 ��MXML�f�[�^�Ń��}�[�N�ɋ󔒂�ݒ� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
begin
  iIndex := 0;
  sData := '';
  Result := '';
  iLength := Length(sValue);
  iEndIndex := 0;

// 2013/09/03 UOE���N�G�X�g���M������M�f�[�^�s���Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>
  // �ϊ��Ώە����񒷂��I�[�^�O�i</NETRECV>�j�܂łƂ���
  if ( iLength > 0 ) then begin
// 2014/04/01 �A�Ώۃ^�O�̑啶�����������ݑΉ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//    iEndPos := Pos( cEndTag, sValue );
    iEndPos := Pos( cEndTag, AnsiUpperCase(sValue) );
// 2014/04/01 �A�Ώۃ^�O�̑啶�����������ݑΉ� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    if ( iEndPos > 0 ) then begin
      iLength := iEndPos - 1 + Length(cEndTag) ;
    end;
  end;

// 2013/09/03 UOE���N�G�X�g���M������M�f�[�^�s���Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<
  while iIndex < iLength do begin
    iIndex := iIndex + 1;
    // �}���`�o�C�g�����͔��ʑΏۊO
    if ( mbSingleByte <> ByteType(sValue, iIndex ) ) then begin
      continue;
    end;
    // <�̏ꍇ�A�^�O���
    if ( sValue[iIndex] = cLessThen ) then begin
      bTagFindFlag := false;
// 2014/04/01 ��MXML�f�[�^�Ń��}�[�N�ɋ󔒂�ݒ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
      iKeyIndex := -1;
// 2014/04/01 ��MXML�f�[�^�Ń��}�[�N�ɋ󔒂�ݒ� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
      sTag := '';
      for iIdx2 := 0 to cKeyCount do begin
        if ( Copy(sValue, iIndex+1, Length(keys[iIdx2])) = keys[iIdx2] ) then begin
          //'<'�ȍ~�̕������L�[�̏ꍇ�A�ϊ��Ώۂ̊J�n�^�O���ۂ��m�F
          sTmp := Copy(sValue, iIndex+1+Length(keys[iIdx2]), iLength);
          if ( Copy(Trim(sTmp),1,1) <> cGreatThen ) then begin
            //�L�[�ɑ���������'>'�ȊO�̏ꍇ�A�ϊ��ΏۊO
            continue;
          end;
          sTag := keys[iIdx2];
          bTagFindFlag := true;
// 2014/04/01 ��MXML�f�[�^�Ń��}�[�N�ɋ󔒂�ݒ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
          iKeyIndex := iIdx2;
// 2014/04/01 ��MXML�f�[�^�Ń��}�[�N�ɋ󔒂�ݒ� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
          break;
        end;
      end;
      if ( bTagFindFlag = false ) then begin
        continue;
      end;
      //�ϊ��J�n�ʒu
      iStartPos := iIndex + Length(sTag) + Pos(cGreatThen,sTmp) + 1;
      iEndPos := iIndex + Length(sTag);
      //�I���^�O�̑O�ɊJ�n�^�O�����݂���\��������̂ŁA���̊J�n�^�O�̈ʒu����������
      iNextPos := Pos( cLessThen + sTag + cGreatThen,sTmp);
      if ( iNextPos > 0 ) then begin
        iNextPos := iEndPos + iNextPos - 1;
      end;
      //�ϊ��I���ʒu(�I���^�O�̎�O�܂�)
      sTag := cLessThen + cSlash + sTag + cGreatThen;
      iEndPos := iEndPos + Pos(sTag,sTmp) - 1;

      if ( ( iNextPos > 0 ) And ( iNextPos < iEndPos ) ) then begin
        // ���̊J�n�^�O�ʒu < ���̏I���^�O�ʒu�Ȃ�X�L�b�v
        continue;
      end;
      if ( iStartPos > iEndPos ) then begin
        // �ϊ��J�n�ʒu > �ϊ��I���ʒu�Ȃ�X�L�b�v
        continue;
      end;

      //�ϊ��J�n�ʒu�܂ł̃R�s�[
      sTmp := Copy(sValue, iEndIndex + 1, iStartPos - 1 - iEndIndex );
      sData := sData + sTmp;
      //�ϊ�
// 2014/04/01 ��MXML�f�[�^�Ń��}�[�N�ɋ󔒂�ݒ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//      for iIdx2 := iStartPos to iEndPos do begin
//        sData := sData + xXMLProhibitionCharToStr(sValue[iIdx2]);
//      end;
      case iKeyIndex of
        2, 9:
// 2016/05/06 ADD 30757���X�� �M�p SPK�d����M�G���[�Ή� >>>>>>>>>>>>>>>>>>>>>>>
//          //�J�n�^�O��'REMARK'�܂���'CHKCD'�̏ꍇ�A�󔒂��Z�b�g�B
//          sData := sData + cRemarkValue;
          //�J�n�^�O��'REMARK'�܂���'CHKCD'
          begin
            if ( gRecvStockKbn = _RecvStockKbnTrue ) then begin
              // �d����M�敪���L���̏ꍇ�A���̃^�O���l�AXML�G���e�B�e�B�Q�ƕ����ϊ�����
              for iIdx2 := iStartPos to iEndPos do begin
                sData := sData + xXMLProhibitionCharToStr(sValue[iIdx2]);
              end;
            end else begin
              //�d����M�敪���L���̏ꍇ�A�󔒂��Z�b�g�B
          sData := sData + cRemarkValue;
            end;
          end;
// 2016/05/06 ADD 30757���X�� �M�p SPK�d����M�G���[�Ή� <<<<<<<<<<<<<<<<<<<<<<<
        0, 1, 3, 4, 5, 6, 7, 8, 10:
          begin
            //�J�n�^�O��'REMARK'�����'CHKCD'�ȊO�̏ꍇ�AXML�G���e�B�e�B�Q�ƕ����ϊ�����
            for iIdx2 := iStartPos to iEndPos do begin
              sData := sData + xXMLProhibitionCharToStr(sValue[iIdx2]);
            end;
          end;
      end;
// 2014/04/01 ��MXML�f�[�^�Ń��}�[�N�ɋ󔒂�ݒ� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
      //�I���^�O�̃R�s�[
      sData := sData + sTag;
      iEndIndex := iEndPos + Length(sTag);
      iIndex := iEndIndex;
    end;
  end;

  if ( iEndIndex < iLength ) then begin
// 2013/09/03 UOE���N�G�X�g���M������M�f�[�^�s���Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>
//    sData := sData + Copy(sValue, iEndIndex + 1, iLength - iEndIndex + 1);
    sData := sData + Copy(sValue, iEndIndex + 1, iLength - iEndIndex);
// 2013/09/03 UOE���N�G�X�g���M������M�f�[�^�s���Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<
  end;

  Result := sData;
end;
// 2013/08/01 �֑������ϊ��Ώێ擾���@�ύX <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

//****************************************************************************//
// module name : XML�G���e�B�e�B�Q�ƕ����ϊ�����
//============================================================================//
// parameter : cValue: Char : �ϊ��Ώە���
//----------------------------------------------------------------------------//
// return : String : �ϊ��㕶����
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
// 2013/05/17 �C�� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

// 2016/05/06 ADD 30757���X�� �M�p SPK�d����M�G���[�Ή� >>>>>>>>>>>>>>>>>>>>>>>
//****************************************************************************//
// module name : �d����M�敪���菈��
//============================================================================//
//  parameter : sValue: String : ����Ώ�XML�h�L�������g
//----------------------------------------------------------------------------//
// return : Smallint : �d����M�敪�i1:�L���A0:�����j
//****************************************************************************//
function xGetReceivingStockKbn(sValue: String): Smallint;
const
  cLessThen       = '<';
  cGreatThen      = '>';
  cSlash          = '/';
  cSlashGreatThen = '/>';
  targetTag       = 'DENBKB';
var
  iIndex       : integer;
  iStartPos    : integer;
  iNextPos     : integer;
  iEndPos      : integer;
  iLength      : integer;
  bTagFindFlag : boolean;
  sTmp , sTag  : String;
begin
  Result  := _RecvStockKbnFalse; //�f�t�H���g�͖���
  iLength := Length(sValue);
  iIndex := 0;

  while iIndex < iLength do begin
    iIndex := iIndex + 1;
    // �}���`�o�C�g�����͔��ʑΏۊO
    if ( mbSingleByte <> ByteType(sValue, iIndex ) ) then begin
      continue;
    end;
    // <�̏ꍇ�A�^�O���
    if ( sValue[iIndex] = cLessThen ) then begin
      bTagFindFlag := false;
      sTag := '';
      if ( Copy(sValue, iIndex+1, Length(targetTag)) = targetTag ) then begin
        //'<'�ȍ~�̕������L�[�̏ꍇ�A�ϊ��Ώۂ̊J�n�^�O���ۂ��m�F
        sTmp := Copy(sValue, iIndex+1+Length(targetTag), iLength);
        if ( Copy(Trim(sTmp),1,1) <> cGreatThen ) then begin
          //�L�[�ɑ���������'>'�ȊO�̏ꍇ�A�ϊ��ΏۊO
          continue;
        end;
        sTag := targetTag;
        bTagFindFlag := true;
      end;
      if ( bTagFindFlag = false ) then begin
        continue;
      end;
      //����J�n�ʒu
      iStartPos := iIndex + Length(sTag) + Pos(cGreatThen,sTmp) + 1;
      iEndPos := iIndex + Length(sTag);
      //�I���^�O�̑O�ɊJ�n�^�O�����݂���\��������̂ŁA���̊J�n�^�O�̈ʒu����������
      iNextPos := Pos( cLessThen + sTag + cGreatThen,sTmp);
      if ( iNextPos > 0 ) then begin
        iNextPos := iEndPos + iNextPos - 1;
      end;
      //����I���ʒu(�I���^�O�̎�O�܂�)
      sTag := cLessThen + cSlash + sTag + cGreatThen;
      iEndPos := iEndPos + Pos(sTag,sTmp);

      if ( ( iNextPos > 0 ) And ( iNextPos < iEndPos ) ) then begin
        // ���̊J�n�^�O�ʒu < ���̏I���^�O�ʒu�Ȃ�X�L�b�v
        continue;
      end;
      if ( iStartPos > iEndPos ) then begin
        // ����J�n�ʒu > ����I���ʒu�Ȃ�X�L�b�v
        continue;
      end;

      //����Ώە����񒊏o
      sTmp := Copy(sValue, iStartPos, iEndPos - iStartPos );
      //����
      if ( sTmp = _DenbKbRecvStock ) then begin
        Result := _RecvStockKbnTrue; // �d����M�敪�L��
        break;
      end;
    end;
  end;
end;
// 2016/05/06 ADD 30757���X�� �M�p SPK�d����M�G���[�Ή� <<<<<<<<<<<<<<<<<<<<<<<

end.
