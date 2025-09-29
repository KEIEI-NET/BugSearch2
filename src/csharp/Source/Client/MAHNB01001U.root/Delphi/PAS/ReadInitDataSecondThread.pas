unit ReadInitDataSecondThread;

interface

uses
  Classes, Messages, Dialogs, SysUtils, HInitProc, MAHNB01019C;

type
  Thread_ReadInitDataSecond = class(TThread)

  private
  public
  abort: Boolean;
  protected
    procedure Execute; override;
    procedure readInitDataSecond;
  public
    constructor Create(); virtual;

  end;

implementation

// *************************************************************************
// Create
// *************************************************************************
constructor Thread_ReadInitDataSecond.Create();
begin
  inherited Create(False); // False:�X���b�h�������㒼���Ɏ��s�����
  FreeOnTerminate := False; // �X���b�h���I�������Ƃ��ɁA�X���b�h�I�u�W�F�N�g���j�������
  abort := False;
end;

procedure Thread_ReadInitDataSecond.Execute;
  begin
    while not Terminated do
    begin
      readInitDataSecond;
      if abort then
      break;
    end;
  end;

procedure Thread_ReadInitDataSecond.readInitDataSecond;
begin
  gpxMAHNB01019B_ReadInitDataSecond(HGetEnterpriseCode, HGetLoginEmployeeBelongSectionCode);
  abort := True;
end;



end.
