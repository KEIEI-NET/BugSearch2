unit ReadInitDataSeventhThread;

interface

uses
  Classes, Messages, Dialogs, SysUtils, HInitProc, MAHNB01019C;

type
  Thread_ReadInitDataSeventh = class(TThread)

  private
  public
  abort: Boolean;
  protected
    procedure Execute; override;
    procedure readInitDataSeventh;
  public
    constructor Create(); virtual;

  end;
implementation

// *************************************************************************
// Create
// *************************************************************************
constructor Thread_ReadInitDataSeventh.Create();
begin
  inherited Create(False); // False:スレッドが生成後直ちに実行される
  FreeOnTerminate := True; // スレッドが終了したときに、スレッドオブジェクトが破棄される
  abort := False;
end;

procedure Thread_ReadInitDataSeventh.Execute;
  begin
  while not Terminated do
    begin
      readInitDataSeventh;
      if abort then
      break;
    end;

  end;

procedure Thread_ReadInitDataSeventh.readInitDataSeventh;
begin
  gpxMAHNB01019B_ReadInitDataSeventh(HGetEnterpriseCode, HGetLoginEmployeeBelongSectionCode);
  abort := True;
end;

end.
