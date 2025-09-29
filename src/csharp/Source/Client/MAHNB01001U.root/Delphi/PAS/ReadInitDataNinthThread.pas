unit ReadInitDataNinthThread;

interface

uses
  Classes, Messages, Dialogs, SysUtils, HInitProc, MAHNB01019C;

type
  Thread_ReadInitDataNinth = class(TThread)

  private
  public
  abort: Boolean;
  protected
    procedure Execute; override;
    procedure readInitDataNinth;
  public
    constructor Create(); virtual;

  end;
implementation

// *************************************************************************
// Create
// *************************************************************************
constructor Thread_ReadInitDataNinth.Create();
begin
  inherited Create(False); // False:スレッドが生成後直ちに実行される
  FreeOnTerminate := True; // スレッドが終了したときに、スレッドオブジェクトが破棄される
  abort := False;
end;

procedure Thread_ReadInitDataNinth.Execute;
  begin
  while not Terminated do
    begin
      readInitDataNinth;
      if abort then
      break;
    end;

  end;

procedure Thread_ReadInitDataNinth.readInitDataNinth;
begin
  gpxMAHNB01019B_ReadInitDataNinth(HGetEnterpriseCode, HGetLoginEmployeeBelongSectionCode);
  abort := True;
end;

end.
