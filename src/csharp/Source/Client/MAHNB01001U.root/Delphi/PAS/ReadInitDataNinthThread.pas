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
  inherited Create(False); // False:�X���b�h�������㒼���Ɏ��s�����
  FreeOnTerminate := True; // �X���b�h���I�������Ƃ��ɁA�X���b�h�I�u�W�F�N�g���j�������
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
