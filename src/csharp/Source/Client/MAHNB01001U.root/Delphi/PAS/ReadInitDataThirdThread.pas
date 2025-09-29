unit ReadInitDataThirdThread;

interface

uses
  Classes, Messages, Dialogs, SysUtils, HInitProc, MAHNB01019C;

type
  Thread_ReadInitDataThird = class(TThread)

  private
  public
  abort: Boolean;
  protected
    procedure Execute; override;
    procedure readInitDataThird;
  public
    constructor Create(); virtual;

  end;
implementation

// *************************************************************************
// Create
// *************************************************************************
constructor Thread_ReadInitDataThird.Create();
begin
  inherited Create(False); // False:スレッドが生成後直ちに実行される
  FreeOnTerminate := False; // スレッドが終了したときに、スレッドオブジェクトが破棄される
  abort := False;
end;

procedure Thread_ReadInitDataThird.Execute;
  begin
  while not Terminated do
    begin
      readInitDataThird;
      if abort then
      break;
    end;

  end;

procedure Thread_ReadInitDataThird.readInitDataThird;
begin
  gpxMAHNB01019B_ReadInitDataThird(HGetEnterpriseCode, HGetLoginEmployeeBelongSectionCode);
  abort := True;
end;

end.
