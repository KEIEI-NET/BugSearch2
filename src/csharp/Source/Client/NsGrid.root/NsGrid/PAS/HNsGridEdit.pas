//**********************************************************************
// System           :   RC.NS
// Sub System       :
// Program name     :   BLStringGrid���C�A�E�g�G�f�B�^(�T���v������)
//                  :
// Name Space       :
// Programmer       :   �a�J
// Date             :   2009.11.04
//----------------------------------------------------------------------
// Update Note      :  2009.11.04 �a�J���
//                      �T���v���Ƃ��ĐV�K�쐬
//                      <<�����̊T�v>>
//                        BLStringGrid�̃��C�A�E�g�݌v��e�Ղɂ��邽�߂�
//                        �G�f�B�^���
//                         �E�݌v���ABLStringGrid.Layout��ҏW����ۂɕ\�������
//                         �E1���ׂ́A�J�������E�s���E�Z���̌�������ҏW�\
//
//                      <<�������e>>
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
unit HNsGridEdit;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, BaseGrid, AdvGrid, StdCtrls, Spin, DesignEditors, DesignIntf;

type
  THNsGridEditF = class(TForm)
    AdvStringGrid1: TAdvStringGrid;
    Button1: TButton;
    Button2: TButton;
    SpinEdit1: TSpinEdit;
    SpinEdit2: TSpinEdit;
    Button3: TButton;
    Button4: TButton;
    Label1: TLabel;
    Label2: TLabel;
    Memo1: TMemo;
    Button5: TButton;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure SpinEdit1Change(Sender: TObject);
    procedure SpinEdit2Change(Sender: TObject);
    procedure LoadFromLayoutStrings;
    procedure SaveToLayoutStrings;
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
  private
    { Private �錾 }
  public
    { Public �錾 }
  end;

//=============================================================================
//  Layout�v���p�e�B�̐ݒ�p�N���X
//  ���O�͔C�ӂ����C�����ł�TInfoProperty�Ƃ���
//  �Œ��GetAttributes��Edit�𑕔�����
//=============================================================================
  TLayoutProperty = class(TClassProperty)
    function GetAttributes: TPropertyAttributes; override;
    procedure Edit; override;
  end;


var
  LayoutStrings    : TStringList;
  BLStringGridEditF: THNsGridEditF;

procedure Register;

implementation

{$R *.dfm}

uses
  HNsGrid;

//=============================================================================
//  �R���|�[�l���g�o�^���
//  RegisterPropertyEditor��
//  TypeInfo(XXXX)   XXXX�̓v���p�e�B�̌^(String�^�Ȃ�String�Ƃ���)
//  TMyCompB         �R���|�[�l���g��
//  'Info'           �o�^����v���p�e�B�̖��O
//  TInfoProperty    �����Œ�`�����v���p�e�B�G�f�B�^�N���X��
//=============================================================================
procedure Register;
begin
  RegisterPropertyEditor(TypeInfo(TStringList), THNsGrid, 'Layout', TLayoutProperty);
end;

//=============================================================================
//  Layout�v���p�e�B�̑���
//  paDialog        �_�C�A���O�\��
//  paSubProperties �I�u�W�F�N�g�C���X�y�N�^��[+}�N���b�N�œW�J
//  paMultiSelect   �����R���|�����ҏW��
//  paReadOnly      �I�u�W�F�N�g�^�̏ꍇ�K���w��(���ڕҏW�s��)
//                  ���̃R���|�ł͎w�肵�Ă��ҏW�\(�v���p�e�B�̐�������)
//=============================================================================
function TLayoutProperty.GetAttributes: TPropertyAttributes;
begin
  Result := [paDialog, paReadOnly];
end;

//=============================================================================
//  Layout�v���p�e�B�ݒ�p�_�C�A���OMyCompBForm��\��
//=============================================================================
procedure TLayoutProperty.Edit;
var
  AEditor: THNsGridEditF;
  ALayout: TStringList;
begin
  AEditor := THNsGridEditF.Create(nil);
  ALayout := TStringList.Create;

  try
    //THNsGrid����Layout�v���p�e�B�̒l���󂯎��
    ALayout.Assign(Pointer(GetOrdValue));
    LayoutStrings.Text := ALayout.Text;

    if AEditor.ShowModal=mrOK then
    begin
      //THNsGrid��Layout�v���p�e�B�̒l��Ԃ�
      ALayout.Text := LayoutStrings.Text;
      SetOrdValue(LongInt(ALayout));
    end;
  finally
    FreeAndNil(AEditor);
    ALayout.Free;
  end;
end;

//=============================================================================
//  �G�f�B�^�[���Create
//=============================================================================
procedure THNsGridEditF.FormCreate(Sender: TObject);
begin
  LayoutStrings := TStringList.Create;
end;

//=============================================================================
//  �G�f�B�^�[���Destroy
//=============================================================================
procedure THNsGridEditF.FormDestroy(Sender: TObject);
begin
  LayoutStrings.Free;
end;

//=============================================================================
//  �G�f�B�^�[���Close
//=============================================================================
procedure THNsGridEditF.FormClose(Sender: TObject;
  var Action: TCloseAction);
begin
  //��ʐݒ�l��ۑ�����
  SaveToLayoutStrings;
end;

//=============================================================================
//  �G�f�B�^�[���Show
//=============================================================================
procedure THNsGridEditF.FormShow(Sender: TObject);
begin
  //��ʂɒl��ݒ肷��
  LoadFromLayoutStrings;
end;

//=============================================================================
//  �Z����������
//=============================================================================
procedure THNsGridEditF.Button3Click(Sender: TObject);
var
  x,y,w,h:integer;
begin
  //�Z����������
  with AdvStringGrid1.Selection do
  begin
    y := Top;
    x := Left;
  end;

  h := AdvStringGrid1.RowSelectCount;
  w := AdvStringGrid1.ColSelectCount;

  AdvStringGrid1.MergeCells(x, y, w, h);

  //�l��ۑ����čĕ`��
  SaveToLayoutStrings;
  LoadFromLayoutStrings;
end;

//=============================================================================
//  �Z��������������
//=============================================================================
procedure THNsGridEditF.Button4Click(Sender: TObject);
var
  x,y:integer;
begin
  //�Z��������������
  y := AdvStringGrid1.Row;
  x := AdvStringGrid1.Col;

  AdvStringGrid1.SplitCells(x,y);

  //�ĕ`��
  SaveToLayoutStrings;
  LoadFromLayoutStrings;
end;

procedure THNsGridEditF.Button5Click(Sender: TObject);
begin
  AdvStringGrid1.SplitAllCells;

  //�ĕ`��
  SaveToLayoutStrings;
  LoadFromLayoutStrings;
end;

//=============================================================================
//  RowCount Change�C�x���g
//=============================================================================
procedure THNsGridEditF.SpinEdit1Change(Sender: TObject);
begin
  AdvStringGrid1.RowCount := SpinEdit1.Value;
end;

//=============================================================================
//  ColCount Change�C�x���g
//=============================================================================
procedure THNsGridEditF.SpinEdit2Change(Sender: TObject);
begin
  AdvStringGrid1.ColCount := SpinEdit2.Value;

end;

//=============================================================================
//  ��ʂɒl��ݒ肷��
//=============================================================================
procedure THNsGridEditF.LoadFromLayoutStrings;
var
  sbuf : Tstringlist;
  ix :integer;
begin
  //���׍s���̐ݒ�
  sbuf := Tstringlist.Create;
  sbuf.CommaText := LayoutStrings[0];

  AdvStringGrid1.RowCount := strtoint(sbuf[1]);
  SpinEdit1.Value := strtoint(sbuf[1]);

  AdvStringGrid1.ColCount := strtoint(sbuf[0]) ;
  SpinEdit2.Value := strtoint(sbuf[0]);
  //�Z���̌�������
  for ix := 1 to LayoutStrings.Count - 1 do
  begin
    sbuf.CommaText := LayoutStrings[ix];
    AdvStringGrid1.MergeCells(strtoint(sbuf[0])-1,strtoint(sbuf[1]) - 1,strtoint(sbuf[2]),strtoint(sbuf[3]));
  end;

  sbuf.Free;
end;

//=============================================================================
//  ��ʐݒ�l��ۑ�����
//=============================================================================
procedure THNsGridEditF.SaveToLayoutStrings;
var
  ix,iy:integer;
  rectx,recty,rectw,recth:integer;
  rect :Trect;
begin
//�v���p�e�B�ύX�C�x���g

  LayoutStrings.Clear;
  //�ŏ��Ƀv���p�e�B�l�������o��
  LayoutStrings.Add(format('%d,%d',[AdvStringGrid1.ColCount,AdvStringGrid1.RowCount]));

  for iy := 0 to AdvStringGrid1.RowCount - 1 do
  begin
    for ix := 0 to AdvStringGrid1.ColCount - 1do
    begin
      if (AdvStringGrid1.IsBaseCell(ix,iy) and AdvStringGrid1.IsMergedCell(ix,iy)) then
      begin
        rect := AdvStringGrid1.FullCell(ix,iy);
        rectx := rect.Left + 1;
        recty := rect.Top + 1;
        rectw := rect.Right - rect.Left + 1;
        recth := rect.Bottom - rect.Top + 1;

        LayoutStrings.Add(format('%d,%d,%d,%d',[rectx,recty,rectw,recth]));
      end;
    end;
  end;

end;

end.
