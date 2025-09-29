unit ReadInitDataFifthThread;

interface

uses
  Classes, Messages, Dialogs, SysUtils, HInitProc, MAHNB01019C;

type
  Thread_ReadInitDataFifth = class(TThread)

  private
  public
  abort: Boolean;
  protected
    procedure Execute; override;
    procedure readInitDataFifth;
  public
    constructor Create(); virtual;

  end;
implementation

// *************************************************************************
// Create
// *************************************************************************
constructor Thread_ReadInitDataFifth.Create();
begin
  inherited Create(False); // False:スレッドが生成後直ちに実行される
  FreeOnTerminate := True; // スレッドが終了したときに、スレッドオブジェクトが破棄される
  abort := False;
end;

procedure Thread_ReadInitDataFifth.Execute;
  begin
  while not Terminated do
    begin
      readInitDataFifth;
      if abort then
      break;
    end;

  end;

procedure Thread_ReadInitDataFifth.readInitDataFifth;
begin
  gpxMAHNB01019B_ReadInitDataFifth(HGetEnterpriseCode, HGetLoginEmployeeBelongSectionCode);
  abort := True;
end;

end.
