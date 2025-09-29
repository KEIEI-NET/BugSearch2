unit ReadInitDataSixthThread;

interface

uses
  Classes, Messages, Dialogs, SysUtils, HInitProc, MAHNB01019C;

type
  Thread_ReadInitDataSixth = class(TThread)

  private
  public
  abort: Boolean;
  protected
    procedure Execute; override;
    procedure readInitDataSixth;
  public
    constructor Create(); virtual;

  end;
implementation

// *************************************************************************
// Create
// *************************************************************************
constructor Thread_ReadInitDataSixth.Create();
begin
  inherited Create(False); // False:スレッドが生成後直ちに実行される
  FreeOnTerminate := True; // スレッドが終了したときに、スレッドオブジェクトが破棄される
  abort := False;
end;

procedure Thread_ReadInitDataSixth.Execute;
  begin
  while not Terminated do
    begin
      readInitDataSixth;
      if abort then
      break;
    end;

  end;

procedure Thread_ReadInitDataSixth.readInitDataSixth;
begin
  gpxMAHNB01019B_ReadInitDataSixth(HGetEnterpriseCode, HGetLoginEmployeeBelongSectionCode);
  abort := True;
end;

end.
