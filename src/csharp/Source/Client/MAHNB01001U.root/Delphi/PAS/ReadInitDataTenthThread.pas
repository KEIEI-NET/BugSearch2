unit ReadInitDataTenthThread;

interface

uses
  Classes, Messages, Dialogs, SysUtils, HInitProc, MAHNB01019C;

type
  Thread_ReadInitDataTenth = class(TThread)

  private
  public
  abort: Boolean;
  protected
    procedure Execute; override;
    procedure readInitDataTenth;
  public
    constructor Create(); virtual;

  end;
implementation

// *************************************************************************
// Create
// *************************************************************************
constructor Thread_ReadInitDataTenth.Create();
begin
  inherited Create(False); // False:�X���b�h�������㒼���Ɏ��s�����
  FreeOnTerminate := True; // �X���b�h���I�������Ƃ��ɁA�X���b�h�I�u�W�F�N�g���j�������
  abort := False;
end;

procedure Thread_ReadInitDataTenth.Execute;
  begin
  while not Terminated do
    begin
      readInitDataTenth;
      if abort then
      break;
    end;

  end;

procedure Thread_ReadInitDataTenth.readInitDataTenth;
begin
  gpxMAHNB01019B_ReadInitDataTenth(HGetEnterpriseCode, HGetLoginEmployeeBelongSectionCode);
  abort := True;
end;

end.
