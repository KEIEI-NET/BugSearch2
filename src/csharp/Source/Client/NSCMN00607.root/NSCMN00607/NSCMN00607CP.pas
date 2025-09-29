//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���O�C���`�F�b�N
// �v���O�����T�v   :
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �� �B�@
// �� �� ��  2012/11/07  �C�����e : ���O�I�t���̃��b�Z�[�W����
//----------------------------------------------------------------------------//
unit NSCMN00607CP;


interface
uses Forms,Classes,Windows,SysUtils,NSCMN00607CT;

function  ApplicationStartControl():integer; stdcall; export;
function  StartApplication(out returnMsg: string ; productCode:string ; application:TApplication):integer; stdcall; export;
function  EndApplication():integer; stdcall; export;
function  MutexCheck():integer ; stdcall; export;

//���b�p�[dll�Ǎ� GetText
function StartApplicationCLI(returnMsg : PChar ; param :Pointer ; softwareCode:PChar): integer; cdecl; external 'NSCMN00607M.dll';
function EndApplicationCLI():integer ; cdecl; external 'NSCMN00607M.dll';
function GetMutexKeyCLI():PChar ; cdecl; external 'NSCMN00651M.dll';
procedure ApplicationReleasedMsg() ; cdecl; external 'NSCMN00607M.dll';

var
  gApplication : TApplication = nil;
  MutexCheckThread : TMutexCheckThread;
  hMutex :THandle;

implementation


function  ApplicationStartControl():integer; stdcall; export;
begin
  Result := 0;
end;

function  StartApplication(out returnMsg: string ; productCode:string ; application:TApplication):integer; stdcall; export;
var
  paramaeter: array [0 .. 1] of PChar;
  pReturnMsg:PChar;
  pProductCode:PChar;

  status:integer;


begin
  gApplication := application;

  //���s�����̎擾
  paramaeter[0] := PChar(ParamStr(1));
  paramaeter[1] := PChar(ParamStr(2));


  pReturnMsg := '';
  pProductCode := PChar(productCode);
  status := StartApplicationCLI(@pReturnMsg,@paramaeter,pProductCode);


  if(status = 0) then
    begin
      status := MutexCheck();
    end;


  returnMsg := string(pReturnMsg);
  Result := status;

end;


function  EndApplication():integer ; stdcall; export;
var
  status:integer;

begin
  status := EndApplicationCLI();
  Result := status;

end;


function  MutexCheck():integer ; stdcall; export;
var
  //hMutex :THandle;

  status:integer;
  pmutexKey:PChar;
  mutexKey:string;

begin
  status :=-1;

  //MutexKey�擾
  pmutexKey := GetMutexKeyCLI();
  mutexKey := string(pMutexKey);

  //�����̖��O��Э�ï����޼ު��ɂ�����ق��擾
  hMutex := OpenMutex(SYNCHRONIZE, false, pmutexKey);

  //�����ŃX���b�h�𐶐����A���������s���Ă���
  MutexCheckThread  := TMutexCheckThread.Create(False);

  //�X���b�h�I�����̏��������蓖�Ă�
  //MyThreadDone�葱���͂��̌�ł���
  //MutexCheckThread.OnTerminate  :=  MutexCheckThread;

  status       := 0;
  Result := status;

end;


end.
