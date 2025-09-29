//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ログインチェック
// プログラム概要   :
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 西 毅　
// 作 成 日  2012/11/07  修正内容 : ログオフ時のメッセージ制御
//----------------------------------------------------------------------------//
unit NSCMN00607CP;


interface
uses Forms,Classes,Windows,SysUtils,NSCMN00607CT;

function  ApplicationStartControl():integer; stdcall; export;
function  StartApplication(out returnMsg: string ; productCode:string ; application:TApplication):integer; stdcall; export;
function  EndApplication():integer; stdcall; export;
function  MutexCheck():integer ; stdcall; export;

//ラッパーdll読込 GetText
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

  //実行引数の取得
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

  //MutexKey取得
  pmutexKey := GetMutexKeyCLI();
  mutexKey := string(pMutexKey);

  //既存の名前つきﾐｭｰﾃｯｸｽｵﾌﾞｼﾞｪｸﾄﾉのﾊﾝﾄﾞﾙを取得
  hMutex := OpenMutex(SYNCHRONIZE, false, pmutexKey);

  //ここでスレッドを生成し、処理を実行している
  MutexCheckThread  := TMutexCheckThread.Create(False);

  //スレッド終了時の処理を割り当てる
  //MyThreadDone手続きはこの後でつくる
  //MutexCheckThread.OnTerminate  :=  MutexCheckThread;

  status       := 0;
  Result := status;

end;


end.
