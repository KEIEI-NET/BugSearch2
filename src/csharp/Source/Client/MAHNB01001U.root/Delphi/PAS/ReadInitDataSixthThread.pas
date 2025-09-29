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
  inherited Create(False); // False:�X���b�h�������㒼���Ɏ��s�����
  FreeOnTerminate := True; // �X���b�h���I�������Ƃ��ɁA�X���b�h�I�u�W�F�N�g���j�������
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
