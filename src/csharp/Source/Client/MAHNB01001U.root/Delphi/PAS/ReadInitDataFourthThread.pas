unit ReadInitDataFourthThread;

interface

uses
  Classes, Messages, Dialogs, SysUtils, HInitProc, MAHNB01013C;

type
  Thread_ReadInitDataFourth = class(TThread)

  private
  public
  abort: Boolean;
  protected
    procedure Execute; override;
    procedure readInitDataFourth;
  public
    constructor Create(); virtual;

  end;

implementation

// *************************************************************************
// Create
// *************************************************************************
constructor Thread_ReadInitDataFourth.Create();
begin
  inherited Create(False); // False:スレッドが生成後直ちに実行される
  FreeOnTerminate := False; // スレッドが終了したときに、スレッドオブジェクトが破棄される
  abort := False;
end;

procedure Thread_ReadInitDataFourth.Execute;
  begin
  while not Terminated do
    begin
      readInitDataFourth;
      if abort then
      break;
    end;

  end;

procedure Thread_ReadInitDataFourth.readInitDataFourth;
begin
  //gpxMAHNB01019B_ReadInitDataFourth(HGetEnterpriseCode, HGetLoginEmployeeBelongSectionCode);
  gpxMAHNB01013B_DoAfterSave();
  abort := True;
end;

end.
