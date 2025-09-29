unit ReadInitDataThread;

interface

uses
  Classes, Messages, Dialogs, SysUtils, HInitProc, MAHNB01019C;

type
  Thread_ReadInitData = class(TThread)

  private
  public
  abort: Boolean;
  protected
    procedure Execute; override;
    procedure readInitData;
  public
    constructor Create(); virtual;

  end;

implementation

// *************************************************************************
// Create
// *************************************************************************
constructor Thread_ReadInitData.Create();
begin
  inherited Create(False); // False:スレッドが生成後直ちに実行される
  FreeOnTerminate := False; // スレッドが終了したときに、スレッドオブジェクトが破棄される
  abort := False;
end;

procedure Thread_ReadInitData.Execute;
begin
  while not Terminated do
  begin
    readInitData;
    if abort then
    break;
  end;

end;

procedure Thread_ReadInitData.readInitData;
begin
  gpxMAHNB01019B_ReadInitData(HGetEnterpriseCode, HGetLoginEmployeeBelongSectionCode);
  abort := True;
end;

end.
