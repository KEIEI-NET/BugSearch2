unit NSCMN00607CT;

interface


uses
  Windows,Classes;

function GetMutexKeyCLI():PChar ; cdecl; external 'NSCMN00651M.dll';

type
  TMutexCheckThread = class(TThread)
  private
    { Private �錾 }
    procedure TMutexClose;

  protected
    procedure Execute; override;
  end;

implementation

uses
  NSCMN00607CP;

{ �d�v�F�r�W���A���R���|�[�l���g�ł̓I�u�W�F�N�g�̃��\�b�h��
  �v���p�e�B�� Synchronize ���g�p���ČĂяo���ꂽ���\�b�h��
  �����g�p���邱�Ƃ��ł��܂���B���̃I�u�W�F�N�g���Q�Ƃ��邽��
  �̃��\�b�h���X���b�h�N���X�ɒǉ����ASynchronize ���\�b�h��
  �����Ƃ��ēn���܂��B

      Synchronize(UpdateCaption);

  ���Ƃ��΁AUpdateCaption ���\�b�h���ȉ��̂悤�ɒ�`���A

    procedure TMutexCheckThread.UpdateCaption;
    begin
      Form1.Caption := '�X���b�h���珑�������܂���';
    end; 
    
    �܂��́A���̂悤�ɂ��܂��B
    
    Synchronize(
      procedure 
      begin
        Form1.Caption := '�������\�b�h��ʂ��ăX���b�h�ōX�V����܂���'
      end
      )
    );
    
  �����ł́A�������\�b�h���n����Ă��܂��B

  ���l�ɁA�J���҂͏�L�Ǝ����p�����[�^�� Queue ���\�b�h���Ăяo�����Ƃ��ł��܂��B
  ����ɕʂ� TThread �N���X��� 1 �p�����[�^�Ƃ��ēn���A�Ăяo�����̃X���b�h��
  ��������̃X���b�h�ŃL���[�ɓ���܂��B
    
}

{ TMutexCheckThread }

procedure TMutexCheckThread.Execute;

begin
  { �X���b�h�Ƃ��Ď��s�������R�[�h�������ɋL�q���Ă������� }

  WaitForSingleObject(hMutex, INFINITE);
  // --- UPD 2012/11/07 T.Nishi ---------->>>>>
  //ApplicationReleasedMsg();
  //���C���t�H�[���̃^�O�ԍ���0�̏ꍇ�̓��b�Z�[�W�\��
  if gApplication.MainForm.Tag = 0 then begin
    ApplicationReleasedMsg();
  end;
  // --- UPD 2012/11/07 T.Nishi ----------<<<<<
  Synchronize(TMutexClose);

end;


procedure  TMutexCheckThread.TMutexClose;
begin
  ReleaseMutex(hMutex);
  CloseHandle(hMutex);
  //gApplication.MainForm.Close;
  gApplication.Terminate;

end;


end.
