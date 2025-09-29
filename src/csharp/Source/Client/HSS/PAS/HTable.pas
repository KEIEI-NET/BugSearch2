//***********************************************f*****************************//
// �V�X�e��         : RC.NS�V���[�Y
// �v���O��������   : Table�R���|�[�l���g
// �v���O�����T�v   : ���חp(HSS100�R���|�[�l���g�ˑ�)
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� �r��
// �� �� ��  2009/09/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
unit HTable;

interface

uses
  SysUtils, Classes, Controls, ExtCtrls, Forms, Graphics, Windows, Messages,
  StdCtrls, Buttons, Mask, HEdit, HDedit;

const
  //THTable�v���p�e�B�����l
  kDefTableWidth      = 240;              // ��
  kDefTableHeight     = 120;              // ����
  kDefFixedColWidth   =  56;              // �Œ茅��
  kDefFixedRowHeight  =  24;              // �Œ�s����
  kDefDataRowWidth    = 200;              // �f�[�^�s��
  kDefDataRowHeight   =  32;              // �f�[�^�s����
  kDefDataRowCount    =  10;              // �f�[�^�s��
  kDefVisibleRowCount =   5;              // ���s��
  kCornerName         = 'CornerPanel';    // �R�[�i�[�p�l����
  kFixedRowName       = 'FixedRowPanel';  // �Œ�s�p�l����
  kFixedColName       = 'FixedColPanel';  // �Œ茅�p�l����
  kDataRowName        = 'DataRowPanel';   // �f�[�^�s�p�l����
  kDefHScrollMargin   =  24;              // ���X�N���[���}�[�W��
  kDefFastScrollRows  =   2;              // �����X�N���[���s��

  csCorner = 1;  // meBoth�J�[�\��
  csHSplit = 2;  // meHeight�J�[�\��
  csVSplit = 3;  // meWidth�J�[�\��

  MouseSense = 4;  // �}�E�X���x

type
  // �t�H�[�J�X�R���g���[���C�x���g�^
  TFocusEvent = procedure(
    PrevCtrl: TWinControl;      // ���݂̃A�N�e�B�u�R���g���[��
    var NextCtrl: TWinControl;  // ���ɃA�N�e�B�u�ɂȂ�R���g���[��
    VkCode: Word                // ���z�L�[�R�[�h
  ) of object;

  // �q�p�l���^�C�v
  TChildPanelType = (
    cpUnDefined,  // ����`
    cpCorner,     // �R�[�i�[�p�l��
    cpFixedRow,   // �Œ�s
    cpFixedCol,   // �Œ茅
    cpDataRow     // �f�[�^�s
  );

  // �}�E�X�ҏW���[�h
  TMouseEditMode = (
    meNone,    // �͈͊O
    meBoth,    // ���A�����ҏW
    meHeight,  // �����ҏW
    meWidth    // ���ҏW
  );

  // �Œ茅�s�X�^�C��
  TFixedStyle = (
    fsNone,  // �Ȃ�
    fsCol,   // �Œ茅�̂�
    fsRow,   // �Œ�s�̂�
    fsBoth   // �Œ茅�A�s
  );

  // �����o�̏�Ԏ擾
  TMemberState = (
    msVisible,  // ���S�Ɍ���Ă���
    msOverlap,  // �ꕔ����Ă���
    msHide      // �B��Ă���
  );

  // �T�C�Y�ҏW���[�h
  TSizingMode = record
    MouseEditMode: TMouseEditMode;    // �}�E�X�ҏW���[�h
    ChildPanelType: TChildPanelType;  // �q�p�l���^�C�v
  end;

  // SetTopline���[�h
  TSetTopLineMode = (
    lmSET,       // �擪����
    lmCUR,       // ���݈ʒu����
    lmTOP,       // �擪��
    lmBOTTOM,    // ������
    lmLINEUP,    // �s�f�N�������g
    lmLINEDOWN,  // �s�C���N�������g
    lmPAGEUP,    // �y�[�W�f�N�������g
    lmPAGEDOWN   // �y�[�W�C���N�������g
  );

  //--------------------------------------------------------------------------//
  //  TRCPanelStyle�I�u�W�F�N�g��`
  //--------------------------------------------------------------------------//
  TRCPanelStyle = class(TPersistent)
  private
    { Private �錾 }
    FBevelInner: TPanelBevel;    // �����x�x��
    FBevelOuter: TPanelBevel;    // �O���x�x��
    FBevelWidth: Integer;        // �x�x����
    FBorderStyle: TBorderStyle;  // �{�[�_�[�X�^�C��
    FColor: TColor;              // �\���F
    FOnChange: TNotifyEvent;     // OnChange�C�x���g
  protected
    { Protected �錾 }
    ChildType: TChildPanelType; // �q�p�l�����
    Name: TComponentName;       // Name
    procedure Changed;                              // OnChange�C�x���g����
    procedure SetBevelInner(Value: TPanelBevel);    // BevelInner�v���p�e�B�̐ݒ�
    procedure SetBevelOuter(Value: TPanelBevel);    // BevelOuter�v���p�e�B�̐ݒ�
    procedure SetBevelWidth(Value: Integer);        // BevelWidth�v���p�e�B�̐ݒ�
    procedure SetBorderStyle(Value: TBorderStyle);  // BorderStyle�v���p�e�B�̐ݒ�
    procedure SetColor(Value: TColor);              // Color�v���p�e�B�̐ݒ�
  public
    { Public �錾 }
    constructor Create(PanelType: TChildPanelType; PanelName: TComponentName);
    procedure Assign(Source: TPersistent); override;
  published
    { Published �錾 }
    property BevelInner: TPanelBevel read FBevelInner write SetBevelInner;
    property BevelOuter: TPanelBevel read FBevelOuter write SetBevelOuter;
    property BevelWidth: Integer read FBevelWidth write SetBevelWidth;
    property BorderStyle: TBorderStyle read FBorderStyle write SetBorderStyle;
    property Color: TColor read FColor write SetColor;
    property OnChange: TNotifyEvent read FOnChange write FOnChange;
  end;

  //--------------------------------------------------------------------------//
  //  TRCChildPanel�I�u�W�F�N�g��`
  //--------------------------------------------------------------------------//
  TRCChildPanel = class(TCustomPanel)
  private
    { Private �錾 }
    MousePoint: TPoint;
    MouseEditMode: TMouseEditMode;
    procedure WMSetCursor(var Msg: TWMSetCursor); message WM_SETCURSOR;
    procedure WMNCHitTest(var Msg: TWMNCHitTest); message WM_NCHITTEST;
    procedure WMLButtonDown(var Msg: TWMLButtonDown); message WM_LBUTTONDOWN;
    procedure WMLButtonUp(var Msg: TWMLButtonUp); message WM_LBUTTONUP;
    procedure WMLMouseMove(var Msg: TWMMouseMove); message WM_MouseMove;
  protected
    { Protected �錾 }
  public
    { Public �錾 }
    ChildType: TChildPanelType;
    constructor Create(AOwner: TComponent); override;
    function GetMouseEditMode(Point: TPoint): TMouseEditMode;
    procedure Invalidate; override;
    procedure SetVisible(Value: Boolean);
  published
    { Published �錾 }
  end;

  //--------------------------------------------------------------------------//
  //  THTable�I�u�W�F�N�g��`
  //--------------------------------------------------------------------------//
  THTable = class(TCustomControl)
  private
    { Private �錾 }
    FCornerStyle: TRCPanelStyle;    // �R�[�i�[�p�l���X�^�C��
    FFixedRowStyle: TRCPanelStyle;  // �Œ�s�p�l���X�^�C��
    FFixedColStyle: TRCPanelStyle;  // �Œ茅�p�l���X�^�C��
    FDataRowStyle: TRCPanelStyle;   // �f�[�^�s�p�l���X�^�C��
    FCornerMember: TStringList;     // �R�[�i�[�p�l�������o
    FFixedRowMember: TStringList;   // �Œ�s�p�l�������o
    FFixedColMember: TStringList;   // �Œ茅�p�l�������o
    FDataRowMember: TStringList;    // �f�[�^�s�p�l�������o
    FFixedStyle: TFixedStyle;       // �Œ茅�A�s�̗L��
    FFixedColWidth: Integer;        // �Œ茅�T�C�Y
    FFixedRowHeight: Integer;       // �Œ�s�T�C�Y
    FDataRowWidth: Integer;         // �f�[�^�s��
    FDataRowHeight: Integer;        // �f�[�^�s����
    FScrollBars: TScrollStyle;      // �X�N���[���o�[�̗L��
    FDataRowCount: Integer;         // �f�[�^�s��
    FHScrollMargin: Integer;        // ���X�N���[���}�[�W��
    FVisibleRowCount: Integer;      // ���s��
    FNextTopRow: Integer;           // �����擪�s
    FFastScrollRows: Integer;       // �����X�N���[���s��
    FOnChangeFocus: TFocusEvent;    // �t�H�[�J�X�ύX�C�x���g
    FMaxScrollRow: Integer;         // �X�N���[���\�ő�s
    FEnableMaxScrollRow: Boolean;   // �X�N���[���s��������t���O
    FTopLine: Integer;              // ���݉�ʏ�ɕ\������Ă���s�ԍ�
    function GetCornerMember: TStringList;
    procedure SetCornerMember(Value: TStringList);
    function GetFixedRowMember: TStringList;
    procedure SetFixedRowMember(Value: TStringList);
    function GetFixedColMember: TStringList;
    procedure SetFixedColMember(Value: TStringList);
    function GetDataRowMember: TStringList;
    procedure SetDataRowMember(Value: TStringList);
    procedure SetFixedStyle(Value: TFixedStyle);
    procedure SetScrollBars(Value: TScrollStyle);
    procedure SetFixedColWidth(Value: Integer);
    procedure SetFixedRowHeight(Value: Integer);
    procedure SetDataRowWidth(Value: Integer);
    procedure SetDataRowHeight(Value: Integer);
    procedure SetDataRowCount(Value: Integer);
    procedure SetVisibleRowCount(Value: Integer);
    function GetTopRow: Integer;
    procedure SetTopRow(Value: Integer);
    function GetCurRow: Integer;
  protected
    { Protected �錾 }
    CornerPanel: TRCChildPanel;    // �R�[�i�[�p�l��
    FixedRowPanel: TRCChildPanel;  // �Œ�s�p�l��
    FixedColPanel: TRCChildPanel;  // �Œ茅�p�l��
    DataRowPanel: TRCChildPanel;   // �f�[�^�s�p�l��
    SizingMode: TSizingMode;       // �T�C�Y�ύX���[�h
    MousePoint: TPoint;            // ���݂̃}�E�X���W
    BaseMousePoint: TPoint;        // �T�C�Y�ύX�n�_�}�E�X���W
    OldMousePoint: TPoint;         // �T�C�Y�ύX���C�������p�}�E�X���W
    NowSizing: Boolean;            // �T�C�Y�ύX���[�h�t���O
    DoSizing: Boolean;             // �T�C�Y�ύX���s�t���O
    StartX: Integer;               // �f�[�^�s�\���擪X���W
    StartRow: Integer;             // �f�[�^�s�\���擪�s�ԍ�
    Owner: TComponent;             // AOwner�ۑ�
    ActiveMember: TWinControl;     // �A�N�e�B�u�ȃ����o
    procedure SetPanelStyle(var Panel: TRCChildPanel; var PanelStyle: TRCPanelStyle);
    procedure PanelStyleChanged(Sender: TObject);
    procedure SetupChildPanels;
    procedure AttachPanel(var Panel: TRCChildPanel);
    procedure DetachPanel(var Panel: TRCChildPanel);
    procedure ReAttachPanel(var Panel: TRCChildPanel);
    procedure AllignMousePoint(var Pt: TPoint; SizingMode: TSizingMode);
    function GetSizingMode(Point: TPoint): TSizingMode;
    procedure DrawSizingLine(Point: TPoint; SizingMode: TSizingMode);
    procedure ChangeChildPanelSize(Point: TPoint; SizingMode: TSizingMode);
    procedure SetupPanelMember;
    procedure DuplicateRow;
    function IsMyMember(Control: TControl): Boolean;
    function GetEnableRowCount: Integer;
    function GetMovableRect: TRect;
    function GetMovableWidth: Integer;
    function ClientRcToScreenRc(WinControl: TWinControl; Rc: TRect): TRect;
    procedure InvalidateRow(ARow: Integer);
    procedure AdjustHeight;
    procedure CMDesignHitTest(var Msg: TCMDesignHitTest); message CM_DESIGNHITTEST;
    procedure WMLButtonDown(var Msg: TWMLButtonDown); message WM_LBUTTONDOWN;
    procedure WMLButtonUp(var Msg: TWMLButtonUp); message WM_LBUTTONUP;
    procedure WMMouseMove(var Msg: TWMMouseMove); message WM_MouseMove;
    procedure WMNCHitTest(var Msg: TWMNCHitTest); message WM_NCHITTEST;
    procedure WMVScroll(var Msg: TWMVScroll); message WM_VSCROLL;
    procedure WMHScroll(var Msg: TWMHScroll); message WM_HSCROLL;
    procedure CMFocusChanged(var Msg: TCMFocusChanged); message CM_FOCUSCHANGED;
    procedure WMSize(var Message: TWMSize); message WM_SIZE;
    procedure CreateParams(var Params: TCreateParams); override;
    procedure GetChildren(Proc: TGetChildProc; Root: TComponent); override;
    procedure Loaded; override;
    procedure CreateWnd; override;
  public
    { Public �錾 }
    NextControl: TWinControl;
    constructor Create(AOwner: TComponent); override;
    destructor Destroy; override;
    function GetInitialRect(Member: TControl): TRect;
    function GetMemberState(Member: TControl): TMemberState;
    property TopRow: Integer read GetTopRow write SetTopRow;
    property CurRow: Integer read GetCurRow;
    property NextTopRow: Integer read FNextTopRow;
    function SetTopLine(APos: Integer; AMode: TSetTopLineMode): Boolean;
    function GetCurNo: Integer;
    function GetCurItem: String;
    function GetPtr(Item: String; No: Integer): TWinControl;
    function GetDat(Item: String; No: Integer): String;
  published
    { Published �錾 }
    property CornerMember: TStringList read GetCornerMember write SetCornerMember;
    property FixedRowMember: TStringList read GetFixedRowMember write SetFixedRowMember;
    property FixedColMember: TStringList read GetFixedColMember write SetFixedColMember;
    property DataRowMember: TStringList read GetDataRowMember write SetDataRowMember;
    property FixedStyle: TFixedStyle read FFixedStyle write SetFixedStyle default fsBoth;
    property ScrollBars: TScrollStyle read FScrollBars write SetScrollBars default ssBoth;
    property FixedColWidth: Integer read FFixedColWidth write SetFixedColWidth default kDefFixedColWidth;
    property FixedRowHeight: Integer read FFixedRowHeight write SetFixedRowHeight default kDefFixedRowHeight;
    property DataRowWidth: Integer read FDataRowWidth write SetDataRowWidth default kDefDataRowWidth;
    property DataRowHeight: Integer read FDataRowHeight write SetDataRowHeight default kDefDataRowHeight;
    property DataRowCount: Integer read FDataRowCount write SetDataRowCount;
    property VisibleRowCount: Integer read FVisibleRowCount write SetVisibleRowCount;
    property HScrollMargin: Integer read FHScrollMargin write FHScrollMargin default kDefHScrollMargin;
    property CornerStyle: TRCPanelStyle read FCornerStyle write FCornerStyle;
    property FixedRowStyle: TRCPanelStyle read FFixedRowStyle write FFixedRowStyle;
    property FixedColStyle: TRCPanelStyle read FFixedColStyle write FFixedColStyle;
    property DataRowStyle: TRCPanelStyle read FDataRowStyle write FDataRowStyle;
    property FastScrollRows: Integer read FFastScrollRows write FFastScrollRows;
    property OnChangeFocus: TFocusEvent read FOnChangeFocus write FOnChangeFocus;
    property MaxScrollRow: Integer read FMaxScrollRow write FMaxScrollRow;
    property EnableMaxScrollRow: Boolean read FEnableMaxScrollRow write FEnableMaxScrollRow;
    property Align;
    property Ctl3D;
    property Color;
    property Enabled;
    property TabOrder;
    property TabStop;
    property Visible;
    property ParentBackground;
    property ParentBiDiMode;
    property ParentColor;
    property ParentCtl3D;
    property ParentCustomHint;
    property ParentDoubleBuffered;
    property ParentFont;
    property ParentShowHint;
  end;

//----------------------------------------------------------------------------//
//  �֐��錾
//----------------------------------------------------------------------------//
procedure DivideName(Src: String; var Name: String; var Row: Integer);
function CombineName(Name: String; Row: Integer): String;

function IsHTableControl(Component: TComponent): Boolean;
function GetTopLine2(Component: TComponent; var MaxTopLine: Integer): Integer;
function SetTopLine2(Component: TComponent; Position, Mode: Integer): Integer;

function GetControlRect(Control: TControl): TRect;
function ShiftRect(Rect: TRect; DX, DY: Integer): TRect;
function IsSameRect(Rc1, Rc2: TRect): Boolean;
function IsIncludePoint(Pt: TPoint; Rect: TRect): Boolean;
function ShiftPoint(Point: TPoint; DX, DY: Integer): TPoint;
function CreateControl(Owner: TComponent; Control: TControl): TControl;
procedure CopyControlProperty(Dst: TControl; Src: TControl);
function GetBaseControl(Control: TWinControl): TWinControl;
procedure CopyHDateEditProperty(Dst: THDateEdit; Src: THDateEdit);
procedure CopyHNeditProperty(Dst: THNedit; Src: THNedit);
procedure CopyHEditProperty(Dst: THEdit; Src: THEdit);
procedure CopyBitBtnProperty(Dst: TBitBtn; Src: TBitBtn);
procedure CopyMaskEditProperty(Dst: TMaskEdit; Src: TMaskEdit);
procedure CopyImageProperty(Dst: TImage; Src: TImage);
procedure CopyShapeProperty(Dst: TShape; Src: TShape);
procedure CopyBevelProperty(Dst: TBevel; Src: TBevel);
procedure CopyLabelProperty(Dst: TLabel; Src: TLabel);
procedure CopyEditProperty(Dst: TEdit; Src: TEdit);
procedure CopyButtonProperty(Dst: TButton; Src: TButton);
procedure CopyCheckBoxProperty(Dst: TCheckBox; Src: TCheckBox);
procedure CopyRadioButtonProperty(Dst: TRadioButton; Src: TRadioButton);
procedure CopyComboBoxProperty(Dst: TComboBox; Src: TComboBox);
procedure CopyRadioGroupProperty(Dst: TRadioGroup; Src: TRadioGroup);
procedure CopyPanelProperty(Dst: TPanel; Src: TPanel);

procedure Register;

implementation

//****************************************************************************//
//  �R���|�[�l���g�̓o�^
//****************************************************************************//
procedure Register;
begin
  RegisterComponents('HSS', [THTable]);
end;


//############################################################################//
//
//  TRCPanelStyle
//
//############################################################################//

//****************************************************************************//
//  TRCPanelStyle �R���X�g���N�^
//****************************************************************************//
constructor TRCPanelStyle.Create(PanelType: TChildPanelType; PanelName: TComponentName);
begin
  ChildType := PanelType;
  Name      := PanelName;

  BevelInner  := bvNone;
  BevelOuter  := bvRaised;
  BevelWidth  := 1;
  BorderStyle := bsNone;
  Color       := clSilver;
end;

//****************************************************************************//
//  TRCPanelStyle �I�u�W�F�N�g�̃R�s�[
//****************************************************************************//
procedure TRCPanelStyle.Assign(Source: TPersistent);
begin
  if (Source is TRCPanelStyle) then begin
    BevelInner  := TRCPanelStyle(Source).BevelInner;
    BevelOuter  := TRCPanelStyle(Source).BevelOuter;
    BevelWidth  := TRCPanelStyle(Source).BevelWidth;
    BorderStyle := TRCPanelStyle(Source).BorderStyle;
    Color       := TRCPanelStyle(Source).Color;
  end else begin
    inherited Assign(Source);
  end;
end;

//****************************************************************************//
//  TRCPanelStyle OnChange�C�x���g����
//****************************************************************************//
procedure TRCPanelStyle.Changed;
begin
  if Assigned(FOnChange) then FOnChange(Self);
end;

//****************************************************************************//
//  TRCPanelStyle BevelInner�v���p�e�B�̐ݒ�
//****************************************************************************//
procedure TRCPanelStyle.SetBevelInner(Value: TPanelBevel);
begin
  if (FBevelInner <> Value) then begin
    FBevelInner := Value;
    Changed;
  end;
end;

//****************************************************************************//
//  TRCPanelStyle BevelOuter�v���p�e�B�̐ݒ�
//****************************************************************************//
procedure TRCPanelStyle.SetBevelOuter(Value: TPanelBevel);
begin
  if (FBevelOuter <> Value) then begin
    FBevelOuter := Value;
    Changed;
  end;
end;

//****************************************************************************//
//  TRCPanelStyle BevelWidth�v���p�e�B�̐ݒ�
//****************************************************************************//
procedure TRCPanelStyle.SetBevelWidth(Value: Integer);
begin
  if (FBevelWidth <> Value) then begin
    FBevelWidth := Value;
    Changed;
  end;
end;

//****************************************************************************//
//  TRCPanelStyle BorderStyle�v���p�e�B�̐ݒ�
//****************************************************************************//
procedure TRCPanelStyle.SetBorderStyle(Value: TBorderStyle);
begin
  if (FBorderStyle <> Value) then begin
    FBorderStyle := Value;
    Changed;
  end;
end;

//****************************************************************************//
//  TRCPanelStyle Color�v���p�e�B�̐ݒ�
//****************************************************************************//
procedure TRCPanelStyle.SetColor(Value: TColor);
begin
  if (FColor <> Value) then begin
    FColor := Value;
    Changed;
  end;
end;


//############################################################################//
//
//  TRCChildPanel
//
//############################################################################//

//****************************************************************************//
//  TRCChildPanel �R���X�g���N�^
//****************************************************************************//
constructor TRCChildPanel.Create(AOwner: TComponent);
begin
  // �h�����Ăяo��
  inherited Create(AOwner);

  // TCustomEdit�Đݒ�
  TabStop     := False;
  //ParentColor := False;
  BevelInner  := bvNone;
  BevelOuter  := bvRaised;
  BevelWidth  := 1;
  BorderStyle := bsNone;
  Color       := clSilver;

  // �����o������
  MousePoint    := Point(0, 0);
  MouseEditMode := meNone;
  ChildType     := cpUnDefined;

  // �ҏW�p�J�[�\���̃��[�h
  Screen.Cursors[csCorner] := LoadCursor(HInstance, 'CS_CORNER');
  Screen.Cursors[csVSplit] := LoadCursor(HInstance, 'CS_VSPLIT');
  Screen.Cursors[csHSplit] := LoadCursor(HInstance, 'CS_HSPLIT');
end;

//****************************************************************************//
//  TRCChildPanel WM_SETCURSOR�ւ̉���
//****************************************************************************//
procedure TRCChildPanel.WMSetCursor(var Msg: TWMSetCursor);
var
  Cur: HCursor;
begin
  Cur := 0;
  if (Msg.HitTest = HTCLIENT) then begin
    // �T�C�Y�ύX�p�J�[�\���I��
    case GetMouseEditMode(MousePoint) of
      meBoth  : Cur := Screen.Cursors[csCorner];
      meWidth : Cur := Screen.Cursors[csVSplit];
      meHeight: Cur := Screen.Cursors[csHSplit];
      meNone  : Cur := 0;
    end;
  end;

  // �T�C�Y�ύX�p�J�[�\���\��
  if (Cur <> 0) then begin
    SetCursor(Cur)
  end else begin
    inherited;
  end;
end;

//****************************************************************************//
//  TRCChildPanel WM_NCHITTEST�ւ̉���
//****************************************************************************//
procedure TRCChildPanel.WMNCHitTest(var Msg: TWMNCHitTest);
var
  Pt: TPoint;
begin
  // �h�����ďo��
  inherited;

  Pt := ScreenToClient(Point(Msg.Pos.X, Msg.Pos.Y));

  // �f�U�C�����[�h
  if (GetMouseEditMode(Pt) = meNone) then SetDesigning(True)
  else                                    SetDesigning(False);

  // �}�E�X�|�C���^�̕ۑ�
  MousePoint := Pt;
end;

//****************************************************************************//
//  TRCChildPanel WM_LBUTTONDOWN�ւ̉���
//****************************************************************************//
procedure TRCChildPanel.WMLButtonDown(var Msg: TWMLButtonDown);
var
  NewMsg: TWMLButtonDown;
  Pt: TPoint;
begin
  // �h�����ďo��
  inherited;

  // THTable�Ƀ��b�Z�[�W���o
  NewMsg := Msg;
  Pt := Parent.ScreenToClient(ClientToScreen(Point(Msg.Pos.X, Msg.Pos.Y)));
  NewMsg.Pos.X := Pt.X;
  NewMsg.Pos.Y := Pt.Y;
  SendMessage(Parent.Handle, WM_LBUTTONDOWN, TMessage(NewMsg).WParam, TMessage(NewMsg).LParam);
end;

//****************************************************************************//
//  TRCChildPanel WM_LBUTTONUP�ւ̉���
//****************************************************************************//
procedure TRCChildPanel.WMLButtonUp(var Msg: TWMLButtonUp);
var
  NewMsg: TWMLButtonUp;
  Pt: TPoint;
begin
  // �h�����ďo��
  inherited;

  // THTable�Ƀ��b�Z�[�W���o
  NewMsg := Msg;
  Pt := Parent.ScreenToClient(ClientToScreen(Point(Msg.Pos.X, Msg.Pos.Y)));
  NewMsg.Pos.X := Pt.X;
  NewMsg.Pos.Y := Pt.Y;
  SendMessage(Parent.Handle, WM_LBUTTONUP, TMessage(NewMsg).WParam, TMessage(NewMsg).LParam);
end;

//****************************************************************************//
//  TRCChildPanel WM_MOUSEMOVE�ւ̉���
//****************************************************************************//
procedure TRCChildPanel.WMLMouseMove(var Msg: TWMMouseMove);
var
  NewMsg: TWMMouseMove;
  Pt: TPoint;
begin
  // �h�����ďo��
  inherited;

  // THTable�Ƀ��b�Z�[�W���o
  NewMsg := Msg;
  Pt := Parent.ScreenToClient(ClientToScreen(Point(Msg.Pos.X, Msg.Pos.Y)));
  NewMsg.Pos.X := Pt.X;
  NewMsg.Pos.Y := Pt.Y;
  SendMessage(Parent.Handle, WM_MouseMove, TMessage(NewMsg).WParam, TMessage(NewMsg).LParam);
end;

//****************************************************************************//
//  TRCChildPanel �}�E�X�ɂ��ҏW�ʒu�̎擾
//****************************************************************************//
function TRCChildPanel.GetMouseEditMode(Point: TPoint): TMouseEditMode;
begin
  if (Point.X > Width  - MouseSense) and
     (Point.Y > Height - MouseSense) then GetMouseEditMode := meBoth
  else
  if (Point.X > Width  - MouseSense) then GetMouseEditMode := meWidth
  else
  if (Point.Y > Height - MouseSense) then GetMouseEditMode := meHeight
  else                                    GetMouseEditMode := meNone;
end;

//****************************************************************************//
//  TRCChildPanel �ĕ`��
//****************************************************************************//
procedure TRCChildPanel.Invalidate;
var
  ix: Integer;
begin
  // �h�����Ăяo��
  inherited Invalidate;

  // �����o��R���g���[���̍ĕ`��
  for ix := 0 to ControlCount - 1 do Controls[ix].Invalidate;
end;

//****************************************************************************//
//  TRCChildPanel �\�������
//****************************************************************************//
procedure TRCChildPanel.SetVisible(Value: Boolean);
var
  ix: Integer;
begin
  if (HandleAllocated = True) then begin
    if (Value) then ShowWindow(Handle, SW_SHOWNA)
    else            ShowWindow(Handle, SW_HIDE);
  end;

  Visible := Value;

  for ix := 0 to ControlCount - 1 do Controls[ix].Visible := Value;
end;


//############################################################################//
//
//  THTable
//
//############################################################################//

//****************************************************************************//
//  THTable �R���X�g���N�^
//****************************************************************************//
constructor THTable.Create(AOwner: TComponent);
begin
  // �h�����Ăяo��
  inherited Create(AOwner);

  // TCustomComponent�̑����ݒ�
  ControlStyle              := [csCaptureMouse, csClickEvents, csFramed];

  Width                     := kDefTableWidth;
  Height                    := kDefTableHeight;
  TabStop                   := False;
  //ParentColor               := False;
  Color                     := clWhite;

  // �����o������
  CornerPanel               := nil;
  FixedRowPanel             := nil;
  FixedColPanel             := nil;
  DataRowPanel              := nil;
  SizingMode.MouseEditMode  := meNone;
  SizingMode.ChildPanelType := cpUnDefined;
  NowSizing                 := False;

  FCornerStyle              := TRCPanelStyle.Create(cpCorner, kCornerName);
  FCornerStyle.OnChange     := PanelStyleChanged;
  FFixedRowStyle            := TRCPanelStyle.Create(cpFixedRow, kFixedRowName);
  FFixedRowStyle.OnChange   := PanelStyleChanged;
  FFixedColStyle            := TRCPanelStyle.Create(cpFixedCol, kFixedColName);
  FFixedColStyle.OnChange   := PanelStyleChanged;
  FDataRowStyle             := TRCPanelStyle.Create(cpDataRow, '');
  FDataRowStyle.OnChange    := PanelStyleChanged;
  FDataRowStyle.Color       := clWhite;

  FCornerMember             := TStringList.Create;
  FFixedRowMember           := TStringList.Create;
  FFixedColMember           := TStringList.Create;
  FDataRowMember            := TStringList.Create;
  FFixedStyle               := fsBoth;
  FFixedColWidth            := kDefFixedColWidth;
  FFixedRowHeight           := kDefFixedRowHeight;
  FDataRowWidth             := kDefDataRowWidth;
  FDataRowHeight            := kDefDataRowHeight;
  FScrollBars               := ssBoth;
  FDataRowCount             := kDefDataRowCount;
  FVisibleRowCount          := kDefVisibleRowCount;
  FHScrollMargin            := kDefHScrollMargin;
  FNextTopRow               := 0;
  FFastScrollRows           := kDefFastScrollRows;
  FMaxScrollRow             := 0;
  FEnableMaxScrollRow       := False;
  Owner                     := AOwner;
  ActiveMember              := nil;
  FTopLine                  := 0;

  // �p�l�������o���X�g����
  FCornerMember             := TStringList.Create;
  FFixedRowMember           := TStringList.Create;
  FFixedColMember           := TStringList.Create;
  FDataRowMember            := TStringList.Create;
  StartX                    := 0;
  StartRow                  := 0;

  // �f�[�^�s�p�l�������A�t��
  AttachPanel(DataRowPanel);
  FDataRowStyle.Name := kDataRowName + '0';
  SetPanelStyle(DataRowPanel, FDataRowStyle);

  // �Œ茅�A�s�����A�t��
  SetupChildPanels;
end;

//****************************************************************************//
//  THTable �f�X�g���N�^
//****************************************************************************//
destructor THTable.Destroy;
begin
  // �h�����Ăяo��
  inherited Destroy;

  // �p�l�������o���X�g�j��
  FCornerMember  .Free;
  FFixedRowMember.Free;
  FFixedColMember.Free;
  FDataRowMember .Free;

  // �p�l���X�^�C���j��
  FCornerStyle  .Free;
  FFixedRowStyle.Free;
  FFixedColStyle.Free;
  FDataRowStyle .Free;
end;

//****************************************************************************//
//  THTable �����o�R���|�[�l���g�̏����N���C�A���g���W�̎擾
//****************************************************************************//
function THTable.GetInitialRect(Member: TControl): TRect;
var
  ParentPanel: TRCChildPanel;
  OrgRect, AbsRect, Rc: TRect;
  Pt1, Pt2: TPoint;
begin
  ParentPanel := TRCChildPanel(Member.Parent);
  OrgRect := GetControlRect(Member);

  Pt1 := ParentPanel.ClientToScreen(Point(OrgRect.Left , OrgRect.Top   ));
  Pt2 := ParentPanel.ClientToScreen(Point(OrgRect.Right, OrgRect.Bottom));
  AbsRect := Rect(Pt1.X, Pt1.Y, Pt2.X, Pt2.Y);

  case ParentPanel.ChildType of
    cpCorner  : Rc := ShiftRect(AbsRect, 0     , 0);
    cpFixedRow: Rc := ShiftRect(AbsRect, StartX, 0);
    cpFixedCol: Rc := ShiftRect(AbsRect, 0     , StartRow * DataRowHeight);
    cpDataRow : Rc := ShiftRect(AbsRect, StartX, StartRow * DataRowHeight);
  end;

  Pt1 := ScreenToClient(Point(Rc.Left , Rc.Top   ));
  Pt2 := ScreenToClient(Point(Rc.Right, Rc.Bottom));

  Result := Rect(Pt1.X, Pt1.Y, Pt2.X, Pt2.Y);
end;

//****************************************************************************//
//  THTable �����o�̏�Ԏ擾
//****************************************************************************//
function THTable.GetMemberState(Member: TControl): TMemberState;
  //--------------------------------------------------------------------------//
  //  �e�p�l���̕\�������擾
  //--------------------------------------------------------------------------//
  function GetVisiblePanelRect(XPanel: TRCChildPanel; var Rc: TRect): Boolean;
  var
    Client, PanelRect, PanelArea: TRect;
  begin
    PanelRect := GetControlRect(XPanel);
    Client := GetClientRect;
    case XPanel.ChildType of
      cpCorner  : begin
                    PanelArea := Rect(Client.Left, Client.Top, FFixedColWidth - 1, FFixedRowHeight - 1);
                  end;
      cpFixedRow: begin
                    if (CornerPanel <> nil) then begin
                      PanelArea := Rect(Client.Left   , Client.Top, Client.Right, FFixedRowHeight - 1)
                    end else begin
                      PanelArea := Rect(FFixedColWidth, Client.Top, Client.Right, FFixedRowHeight - 1);
                    end;
                  end;
      cpFixedCol: begin
                    if (CornerPanel <> nil) then begin
                      PanelArea := Rect(Client.Left, FFixedRowHeight, FFixedColWidth - 1, Client.Bottom)
                    end else begin
                      PanelArea := Rect(Client.Left, Client.Top     , FFixedColWidth - 1, Client.Bottom);
                    end;
                  end;
      cpDataRow : begin
                    if (CornerPanel <> nil) then begin
                      PanelArea := Rect(FFixedColWidth, FFixedRowHeight, Client.Right, Client.Bottom)
                    end else
                    if (FixedRowPanel <> nil) then begin
                      PanelArea := Rect(Client.Left   , FFixedRowHeight, Client.Right, Client.Bottom)
                    end else
                    if (FixedColPanel <> nil) then begin
                      PanelArea := Rect(FFixedColWidth, Client.Top     , Client.Right, Client.Bottom)
                    end else begin
                      PanelArea := Rect(Client.Left   , Client.Top     , Client.Right, Client.Bottom);
                    end;
                  end;
    end;

    if (IntersectRect(Rc, PanelArea, PanelRect) = True) then begin
      Rc := ShiftRect(Rc, -1 * PanelRect.Left, -1 * PanelRect.Top);
      Result := True;
    end else begin
      Result := False;
    end;
  end;

var
  Rc, MemberRect, VisiblePanelRect: TRect;
begin
  MemberRect := GetControlRect(Member);
  if (GetVisiblePanelRect(TRCChildPanel(Member.Parent), VisiblePanelRect) <> True) then begin
    Result := msHide;
  end else
  if (IntersectRect(Rc, VisiblePanelRect, MemberRect) <> True) then begin
    Result := msHide;
  end else
  if not IsSameRect(Rc, MemberRect) then begin
    Result := msOverlap;
  end else begin
    Result := msVisible;
  end;
end;

//****************************************************************************//
//  THTable �\���擪�s�̐ݒ�
//****************************************************************************//
function THTable.SetTopLine(APos: Integer; AMode: TSetTopLineMode): Boolean;
var
  CurTop, NewTop, MaxTop: Integer;
begin
  // ����擾
  CurTop := GetTopLine2(Self, MaxTop);

  case AMode of
    lmSET     : NewTop := SetTopLine2(Self, APos,   0);
    lmCUR     : NewTop := SetTopLine2(Self, APos,   1);
    lmTOP     : NewTop := SetTopLine2(Self, 0,      0);
    lmBOTTOM  : NewTop := SetTopLine2(Self, MaxTop, 0);
    lmLINEUP  : NewTop := SetTopLine2(Self, -1,     1);
    lmLINEDOWN: NewTop := SetTopLine2(Self, 1,      1);
    lmPAGEUP  : NewTop := SetTopLine2(Self, FVisibleRowCount * (-1), 1);
    lmPAGEDOWN: NewTop := SetTopLine2(Self, FVisibleRowCount,        1);
    else        NewTop := CurTop;
  end;

  if (NewTop = CurTop) then begin
    Result := False;
  end else begin
    if (FScrollBars = ssBoth) or (FScrollBars = ssVertical) then begin
      SetScrollPos(Handle, SB_VERT, NewTop, True);
    end;
    Result := True;
  end;
end;

//****************************************************************************//
//  THTable ���݈ʒu�̒ʂ��ԍ����擾
//****************************************************************************//
function THTable.GetCurNo: Integer;
var
  CurTop, MaxTop: Integer;
begin
  CurTop := GetTopLine2(Self, MaxTop);
  Result := CurTop + CurRow;
end;

//****************************************************************************//
//  THTable �t�H�[�J�X�ʒu�̍��ږ��̎擾
//****************************************************************************//
function THTable.GetCurItem: String;
var
  AName: String;
  ARow: Integer;
begin
  if (ActiveMember = nil) then begin
    Result := '';
  end else
  if (ActiveMember.Parent = CornerPanel) or
     (ActiveMember.Parent = FixedRowPanel) then begin
    Result := '';
  end else begin
    DivideName(ActiveMember.Name, AName, ARow);
    Result := AName;
  end;
end;

//****************************************************************************//
//  THTable ����ʒu�̃t�H�[�J�X�ʒu���擾
//****************************************************************************//
function THTable.GetPtr(Item: String; No: Integer): TWinControl;
var
  Component: TComponent;
  Name: String;
begin
  Name := CombineName(Item, No);
  Component := TForm(Owner).FindComponent(Name);
  if (Component = nil) then begin
    Result := nil;
  end else begin
    Result := TWinControl(Component);
  end;
end;

//****************************************************************************//
//  THTable ����ʒu�̃f�[�^���擾
//****************************************************************************//
function THTable.GetDat(Item: String; No: Integer): String;
var
  Component: TWinControl;
begin
  Result := '';
  Component := GetPtr(Item, No);
  // HSS100 palette
       if (Component.ClassNameIs('THDateEdit'  )) then Result := IntToStr(THDateEdit(Component).LongDate)
  else if (Component.ClassNameIs('THNedit'     )) then Result := THNedit     (Component).DataText
  else if (Component.ClassNameIs('THEdit'      )) then Result := THEdit      (Component).DataText
  // Additional palette
  else if (Component.ClassNameIs('TBitBtn'     )) then Result := TBitBtn     (Component).Caption
  else if (Component.ClassNameIs('TMaskEdit'   )) then Result := TMaskEdit   (Component).Text
  else if (Component.ClassNameIs('TImage'      )) then Result := ''
  else if (Component.ClassNameIs('TShape'      )) then Result := ''
  else if (Component.ClassNameIs('TBevel'      )) then Result := ''
  // Standard palette
  else if (Component.ClassNameIs('TLabel'      )) then Result := TLabel      (Component).Caption
  else if (Component.ClassNameIs('TEdit'       )) then Result := TEdit       (Component).Text
  else if (Component.ClassNameIs('TButton'     )) then Result := TButton     (Component).Caption
  else if (Component.ClassNameIs('TCheckBox'   )) then Result := TCheckBox   (Component).Caption
  else if (Component.ClassNameIs('TRadioButton')) then Result := TRadioButton(Component).Caption
  else if (Component.ClassNameIs('TComboBox'   )) then Result := TComboBox   (Component).Text
  else if (Component.ClassNameIs('TRadioGroup' )) then Result := TRadioGroup (Component).Caption
  else if (Component.ClassNameIs('TPanel'      )) then Result := TPanel      (Component).Caption
end;

//****************************************************************************//
//  THTable �Œ茅�A�s�̗L���ݒ�
//****************************************************************************//
procedure THTable.SetFixedStyle(Value: TFixedStyle);
begin
  if (FFixedStyle <> Value) then begin
    FFixedStyle := Value;
    SetupChildPanels;
  end;
end;

//****************************************************************************//
//  THTable �X�N���[���o�[�̗L���ݒ�
//****************************************************************************//
procedure THTable.SetScrollBars(Value: TScrollStyle);
begin
  if (FScrollBars <> Value) then begin
    FScrollBars := Value;
    RecreateWnd;
  end;
end;

//****************************************************************************//
//  THTable �Œ茅���ݒ�
//****************************************************************************//
procedure THTable.SetFixedColWidth(Value: Integer);
begin
  if (FFixedColWidth <> Value) then begin
    FFixedColWidth := Value;
    SetupChildPanels;
  end;
end;

//****************************************************************************//
//  THTable �Œ�s���ݒ�
//****************************************************************************//
procedure THTable.SetFixedRowHeight(Value: Integer);
begin
  if (FFixedRowHeight <> Value) then begin
    FFixedRowHeight := Value;
    SetupChildPanels;
  end;
end;

//****************************************************************************//
//  THTable �f�[�^�s���ݒ�
//****************************************************************************//
procedure THTable.SetDataRowWidth(Value: Integer);
begin
  if (FDataRowWidth <> Value) then begin
    FDataRowWidth := Value;
    SetupChildPanels;
  end;
end;

//****************************************************************************//
//  THTable �f�[�^�s���ݒ�
//****************************************************************************//
procedure THTable.SetDataRowHeight(Value: Integer);
begin
  if (FDataRowHeight <> Value) then begin
    FDataRowHeight := Value;
    SetupChildPanels;
  end;
end;

//****************************************************************************//
//  THTable DataRowCount�v���p�e�B�̐ݒ�
//****************************************************************************//
procedure THTable.SetDataRowCount(Value: Integer);
begin
  FDataRowCount := Value;

  // �c�X�N���[���o�[�����W�̐ݒ�
  if ((FScrollBars = ssBoth) or (FScrollBars = ssVertical)) and
     (FDataRowCount > FVisibleRowCount) then begin
    SetScrollRange(Handle, SB_VERT, 0, FDataRowCount - FVisibleRowCount, True);
  end;
end;

//****************************************************************************//
//  THTable VisibleRowCount�v���p�e�B�̐ݒ�
//****************************************************************************//
procedure THTable.SetVisibleRowCount(Value: Integer);
begin
  FVisibleRowCount := Value;

  // �R���|�[�l���g�����̒���
  AdjustHeight;

  // �c�X�N���[���o�[�����W�̐ݒ�
  if ((FScrollBars = ssBoth) or (FScrollBars = ssVertical)) and
     (FDataRowCount > FVisibleRowCount) then begin
    SetScrollRange(Handle, SB_VERT, 0, FDataRowCount - FVisibleRowCount, True);
  end;
end;

//****************************************************************************//
//  THTable TopRow�v���p�e�B
//****************************************************************************//
//----------------------------------------------------------------------------//
//  �擾
//----------------------------------------------------------------------------//
function THTable.GetTopRow: Integer;
begin
  Result := StartRow;
end;
//----------------------------------------------------------------------------//
//  �ݒ�
//----------------------------------------------------------------------------//
procedure THTable.SetTopRow(Value: Integer);
var
  NewTop, ix: Integer;
  Component: TComponent;
begin
  // �͈͊O�l�̒���
  if (Value < 0) then begin
    Value := 0;
  end else
  if (Value > FVisibleRowCount - GetEnableRowCount) then begin
    Value := FVisibleRowCount - GetEnableRowCount;
  end;

  // �擪�q�p�l����Y���W
  if (FixedRowPanel = nil) then begin
    NewTop := FDataRowHeight * Value * (-1);
  end else begin
    NewTop := FDataRowHeight * Value * (-1) + FFixedRowHeight;
  end;

  // �ĕ`��
  for ix := 0 to FDataRowCount - 1 do begin
    if (FixedColPanel <> nil) then begin
      Component := FindComponent(kFixedColName + IntToStr(ix));
      if (Component <> nil) then begin
        TRCChildPanel(Component).Top := NewTop + FDataRowHeight * ix;
      end;
    end;

    Component := FindComponent(kDataRowName + IntToStr(ix));
    if (Component <> nil) then begin
      TRCChildPanel(Component).Top := NewTop + FDataRowHeight * ix;
    end;
  end;

  // �X�N���[���o�[
  if (FScrollBars = ssBoth) or (FScrollBars = ssVertical) then begin
    SetScrollPos(Handle, SB_VERT, Value, True);
  end;

  // �擪�s�ݒ�
  StartRow := Value;
end;

//****************************************************************************//
//  THTable CurRow�v���p�e�B�̎擾
//****************************************************************************//
function THTable.GetCurRow: Integer;
var
  AName: String;
  ARow: Integer;
begin
  if (ActiveMember = nil) then begin
    Result := -1;
  end else
  if (ActiveMember.Parent = CornerPanel) or
     (ActiveMember.Parent = FixedRowPanel) then begin
    Result := -1;
  end else begin
    DivideName(ActiveMember.Name, AName, ARow);
    Result := ARow;
  end;
end;

//****************************************************************************//
//  THTable �R�[�i�p�l�������o
//****************************************************************************//
//----------------------------------------------------------------------------//
//  �擾
//----------------------------------------------------------------------------//
function THTable.GetCornerMember: TStringList;
var
  ix: Integer;
begin
  FCornerMember.Clear;
  if (CornerPanel <> nil) then begin
    for ix := 0 to CornerPanel.ControlCount - 1 do begin
      FCornerMember.Add(CornerPanel.Controls[ix].Name);
    end;
  end;
  Result := FCornerMember;
end;
//----------------------------------------------------------------------------//
//  �ݒ�
//----------------------------------------------------------------------------//
procedure THTable.SetCornerMember(Value: TStringList);
begin
  FCornerMember.Assign(Value);
end;

//****************************************************************************//
//  THTable �Œ�s�p�l�������o
//****************************************************************************//
//----------------------------------------------------------------------------//
//  �擾
//----------------------------------------------------------------------------//
function THTable.GetFixedRowMember: TStringList;
var
  ix: Integer;
begin
  FFixedRowMember.Clear;
  if (FixedRowPanel <> nil) then begin
    for ix := 0 to FixedRowPanel.ControlCount - 1 do begin
      FFixedRowMember.Add(FixedRowPanel.Controls[ix].Name);
    end;
  end;
  Result := FFixedRowMember;
end;
//----------------------------------------------------------------------------//
//  �ݒ�
//----------------------------------------------------------------------------//
procedure THTable.SetFixedRowMember(Value: TStringList);
begin
  FFixedRowMember.Assign(Value);
end;

//****************************************************************************//
//  THTable �Œ茅�p�l�������o
//****************************************************************************//
//----------------------------------------------------------------------------//
//  �擾
//----------------------------------------------------------------------------//
function THTable.GetFixedColMember: TStringList;
var
  ix: Integer;
begin
  FFixedColMember.Clear;
  if (FixedColPanel <> nil) then begin
    for ix := 0 to FixedColPanel.ControlCount - 1 do begin
      FFixedColMember.Add(FixedColPanel.Controls[ix].Name);
    end;
  end;
  Result := FFixedColMember;
end;
//----------------------------------------------------------------------------//
//  �ݒ�
//----------------------------------------------------------------------------//
procedure THTable.SetFixedColMember(Value: TStringList);
begin
  FFixedColMember.Assign(Value);
end;

//****************************************************************************//
//  THTable �f�[�^�s�p�l�������o
//****************************************************************************//
//----------------------------------------------------------------------------//
//  �擾
//----------------------------------------------------------------------------//
function THTable.GetDataRowMember: TStringList;
var
  ix: Integer;
begin
  FDataRowMember.Clear;
  for ix := 0 to DataRowPanel.ControlCount - 1 do begin
    FDataRowMember.Add(DataRowPanel.Controls[ix].Name);
  end;
  Result := FDataRowMember;
end;
//----------------------------------------------------------------------------//
//  �ݒ�
//----------------------------------------------------------------------------//
procedure THTable.SetDataRowMember(Value: TStringList);
begin
  FDataRowMember.Assign(Value);
end;

//****************************************************************************//
//  THTable �q�p�l���̃Z�b�g�A�b�v
//****************************************************************************//
procedure THTable.SetupChildPanels;
begin
  case FFixedStyle of
    fsNone: begin
              DetachPanel(CornerPanel);
              DetachPanel(FixedColPanel);
              DetachPanel(FixedRowPanel);

              DataRowPanel.SetBounds(StartX * (-1), 0, FDataRowWidth, FDataRowHeight);
            end;
    fsRow : begin
              DetachPanel(CornerPanel);
              DetachPanel(FixedColPanel);

              AttachPanel(FixedRowPanel);
              SetPanelStyle(FixedRowPanel, FFixedRowStyle);
              FixedRowPanel.SetBounds(StartX * (-1), 0, FDataRowWidth, FFixedRowHeight);

              DataRowPanel.SetBounds(StartX * (-1), FFixedRowHeight, FDataRowWidth, FDataRowHeight);
            end;
    fsCol : begin
              DetachPanel(CornerPanel);
              DetachPanel(FixedRowPanel);

              AttachPanel(FixedColPanel);
              FFixedColStyle.Name := kFixedColName + '0';
              SetPanelStyle(FixedColPanel, FFixedColStyle);
              FixedColPanel.SetBounds(0, 0, FFixedColWidth, FDataRowHeight);

              DataRowPanel.SetBounds(FFixedColWidth + StartX * (-1), 0, FDataRowWidth, FDataRowHeight);
            end;
    fsBoth: begin
              AttachPanel(FixedRowPanel);
              SetPanelStyle(FixedRowPanel, FFixedRowStyle);
              FixedRowPanel.SetBounds(FFixedColWidth + StartX * (-1), 0, FDataRowWidth, FFixedRowHeight);

              AttachPanel(FixedColPanel);
              FFixedColStyle.Name := kFixedColName + '0';
              SetPanelStyle(FixedColPanel, FFixedColStyle);
              FixedColPanel.SetBounds(0, FFixedRowHeight, FFixedColWidth, FDataRowHeight);

              AttachPanel(CornerPanel);
              SetPanelStyle(CornerPanel, FCornerStyle);
              CornerPanel.SetBounds(0, 0, FixedColWidth, FixedRowHeight);

              DataRowPanel.SetBounds(FFixedColWidth + StartX * (-1), FFixedRowHeight, FDataRowWidth, FDataRowHeight);
            end;
  end;
end;

//****************************************************************************//
//  THTable TPanel�X�^�C���̐ݒ�
//****************************************************************************//
procedure THTable.SetPanelStyle(var Panel: TRCChildPanel; var PanelStyle: TRCPanelStyle);
begin
  Panel.ChildType   := PanelStyle.ChildType;
  Panel.Name        := PanelStyle.Name;

  Panel.BevelInner  := PanelStyle.BevelInner;
  Panel.BevelOuter  := PanelStyle.BevelOuter;
  Panel.BevelWidth  := PanelStyle.BevelWidth;
  Panel.BorderStyle := PanelStyle.BorderStyle;
  Panel.Color       := PanelStyle.Color;

  Panel.TabStop     := False;
  //Panel.ParentColor := False;
  Panel.Caption     := '';
end;

//****************************************************************************//
//  THTable TRCPanelStyle�v���p�e�B�̍X�V
//****************************************************************************//
procedure THTable.PanelStyleChanged(Sender: TObject);
var
  Panel: TRCChildPanel;
begin
  // �Y������TRCChildPanel�擾
  Panel := nil;
  if (TRCPanelStyle(Sender).Name = kCornerName) and (CornerPanel <> nil) then begin
    Panel := CornerPanel;
  end else
  if (TRCPanelStyle(Sender).Name = kFixedRowName) and (FixedRowPanel <> nil) then begin
    Panel := FixedRowPanel;
  end else
  if (TRCPanelStyle(Sender).Name = kFixedColName + '0') and(FixedColPanel <> nil) then begin
    Panel := FixedColPanel;
  end else
  if (TRCPanelStyle(Sender).Name = kDataRowName + '0') and (DataRowPanel <> nil) then begin
    Panel := DataRowPanel;
  end;

  // TRCChildPanel�X�V
  if (Panel <> nil) then begin
    SetPanelStyle(Panel, TRCPanelStyle(Sender));
    Panel.Invalidate;
  end;
end;

//****************************************************************************//
//  THTable �q�p�l���̒ǉ�
//****************************************************************************//
procedure THTable.AttachPanel(var Panel: TRCChildPanel);
begin
  if (Panel = nil) then begin
    Panel := TRCChildPanel.Create(Self);
    InsertControl(Panel);
  end;
end;

//****************************************************************************//
//  THTable �q�p�l���̍폜
//****************************************************************************//
procedure THTable.DetachPanel(var Panel: TRCChildPanel);
begin
  if (Panel <> nil) then begin
    RemoveControl(Panel);
    Panel.Destroy;
    Panel := nil;
  end;
end;

//****************************************************************************//
//  THTable �q�p�l���̍Ēǉ�
//****************************************************************************//
procedure THTable.ReAttachPanel(var Panel: TRCChildPanel);
begin
  if (Panel <> nil) then begin
    RemoveControl(Panel);
    InsertControl(Panel);
  end;
end;

//****************************************************************************//
//  THTable �}�E�X���W�̕␳
//****************************************************************************//
procedure THTable.AllignMousePoint(var Pt: TPoint; SizingMode: TSizingMode);
begin
  case SizingMode.MouseEditMode of
    meBoth  : begin
                case SizingMode.ChildPanelType of
                  cpCorner  : with CornerPanel   do Pt := Point(Left + Width, Top + Height);
                  cpFixedRow: with FixedRowPanel do Pt := Point(Left + Width, Top + Height);
                  cpFixedCol: with FixedColPanel do Pt := Point(Left + Width, Top + Height);
                  cpDataRow : with DataRowPanel  do Pt := Point(Left + Width, Top + Height);
                end;
              end;
    meHeight: begin
                case SizingMode.ChildPanelType of
                  cpCorner  : with CornerPanel   do Pt.Y := Top + Height;
                  cpFixedRow: with FixedRowPanel do Pt.Y := Top + Height;
                  cpFixedCol: with FixedColPanel do Pt.Y := Top + Height;
                  cpDataRow : with DataRowPanel  do Pt.Y := Top + Height;
                end;
              end;
    meWidth : begin
                case SizingMode.ChildPanelType of
                  cpCorner  : with CornerPanel   do Pt.X := Left + Width;
                  cpFixedCol: with FixedColPanel do Pt.X := Left + Width;
                  cpFixedRow: with FixedRowPanel do Pt.X := Left + Width;
                  cpDataRow : with DataRowPanel  do Pt.X := Left + Width;
                end;
              end;
  end;
end;

//****************************************************************************//
//  THTable �}�E�X�ɂ��T�C�Y�ύX���[�h�̎擾
//****************************************************************************//
function THTable.GetSizingMode(Point: TPoint): TSizingMode;
var
  SizingMode: TSizingMode;
begin
  SizingMode.MouseEditMode  := meNone;
  SizingMode.ChildPanelType := cpUnDefined;

  if (CornerPanel <> nil) then begin
    with CornerPanel do
      if IsIncludePoint(Point, Rect(Left, Top, Left + Width, Top + Height)) then begin
        Point := ShiftPoint(Point, Left * (-1), Top * (-1));
        SizingMode.ChildPanelType := cpCorner;
        SizingMode.MouseEditMode := CornerPanel.GetMouseEditMode(Point);
      end;
  end;

  if (FixedRowPanel <> nil) then begin
    with FixedRowPanel do
      if IsIncludePoint(Point, Rect(StartX + Left, Top, Left + Width, Top + Height)) then begin
        Point := ShiftPoint(Point, Left * (-1), Top * (-1));
        SizingMode.ChildPanelType := cpFixedRow;
        SizingMode.MouseEditMode := FixedRowPanel.GetMouseEditMode(Point);
      end;
  end;

  if (FixedColPanel <> nil) then begin
    with FixedColPanel do
      if IsIncludePoint(Point, Rect(Left, Top, Left + Width, Top + Height)) then begin
        Point := ShiftPoint(Point, Left * (-1), Top * (-1));
        SizingMode.ChildPanelType := cpFixedCol;
        SizingMode.MouseEditMode := FixedColPanel.GetMouseEditMode(Point);
      end;
  end;

  if (DataRowPanel <> nil) then begin
    with DataRowPanel do
      if IsIncludePoint(Point, Rect(StartX + Left, Top, Left + Width, Top + Height)) then begin
        Point := ShiftPoint(Point, Left * (-1), Top * (-1));
        SizingMode.ChildPanelType := cpDataRow;
        SizingMode.MouseEditMode := DataRowPanel.GetMouseEditMode(Point);
      end;
  end;

  GetSizingMode := SizingMode;
end;

//****************************************************************************//
//  THTable �}�E�X�ɂ��T�C�Y�ҏW���C���\��
//****************************************************************************//
procedure THTable.DrawSizingLine(Point: TPoint; SizingMode: TSizingMode);
var
  OldPen: TPen;
  OldBrush: TBrush;
begin
  // �Ҕ�p�y���A�u���V����
  OldPen := TPen.Create;
  OldBrush := TBrush.Create;
  try
    with Canvas do begin
      // �y���A�u���V�ݒ�
      OldPen.Assign(Pen);
      Pen.Style := psSolid;
      Pen.Mode := pmXor;
      Pen.Width := 1;
      Pen.Color := clBlack;

      OldBrush.Assign(Brush);
      Brush.Style := bsSolid;
      Brush.Color := clGray;

      try
        // �T�C�Y�ύX���`��
        case SizingMode.MouseEditMode of
          meBoth  : begin
                      case SizingMode.ChildPanelType of
                        cpCorner  : begin
                                      if (CornerPanel   <> nil) then with CornerPanel   do RectAngle(Left, Top, Point.X, Point.Y);
                                      if (FixedRowPanel <> nil) then with FixedRowPanel do RectAngle(Point.X, Top, Point.X + Width - StartX, Point.Y);
                                      if (FixedColPanel <> nil) then with FixedColPanel do RectAngle(Left, Point.Y, Point.X, Point.Y + Height);
                                      if (DataRowPanel  <> nil) then with DataRowPanel  do RectAngle(Point.X, Point.Y, Point.X + Width - StartX, Point.Y + Height);
                                    end;
                        cpFixedRow: begin
                                      if (CornerPanel   <> nil) then with CornerPanel   do RectAngle(Left, Top, Left + Width, Point.Y);
                                      if (FixedRowPanel <> nil) then with FixedRowPanel do RectAngle(StartX + Left, Top, Point.X, Point.Y);
                                      if (FixedColPanel <> nil) then with FixedColPanel do RectAngle(Left, Point.Y, Left + Width, Point.Y + Height);
                                      if (DataRowPanel  <> nil) then with DataRowPanel  do RectAngle(StartX + Left, Point.Y, Point.X, Point.Y + Height);
                                    end;
                        cpFixedCol: begin
                                      if (CornerPanel   <> nil) then with CornerPanel   do RectAngle(Left, Top, Point.X, Top + Height);
                                      if (FixedRowPanel <> nil) then with FixedRowPanel do RectAngle(Point.X, Top, Point.X + Width - StartX, Top + Height);
                                      if (FixedColPanel <> nil) then with FixedColPanel do RectAngle(Left, Top, Point.X, Point.Y);
                                      if (DataRowPanel  <> nil) then with DataRowPanel  do RectAngle(Point.X, Top, Point.X + Width - StartX, Point.Y);
                                    end;
                        cpDataRow : begin
                                      if (CornerPanel   <> nil) then with CornerPanel   do RectAngle(Left, Top, Left + Width, Top + Height);
                                      if (FixedRowPanel <> nil) then with FixedRowPanel do RectAngle(StartX + Left, Top, Point.X, Top + Height);
                                      if (FixedColPanel <> nil) then with FixedColPanel do RectAngle(Left, Top, Left + Width, Point.Y);
                                      if (DataRowPanel  <> nil) then with DataRowPanel  do RectAngle(StartX + Left, Top, Point.X, Point.Y);
                                    end;
                      end;
                    end;
          meHeight: begin
                      case SizingMode.ChildPanelType of
                        cpCorner,
                        cpFixedRow: begin
                                      if (CornerPanel   <> nil) then with CornerPanel   do RectAngle(Left, Top, Left + Width, Point.Y);
                                      if (FixedRowPanel <> nil) then with FixedRowPanel do RectAngle(StartX + Left, Top, Left + Width, Point.Y);
                                      if (FixedColPanel <> nil) then with FixedColPanel do RectAngle(Left, Point.Y, Left + Width, Point.Y + Height);
                                      if (DataRowPanel  <> nil) then with DataRowPanel  do RectAngle(StartX + Left, Point.Y, Left + Width, Point.Y + Height);
                                    end;
                        cpFixedCol,
                        cpDataRow : begin
                                      if (CornerPanel   <> nil) then with CornerPanel   do RectAngle(Left, Top, Left + Width, Top + Height);
                                      if (FixedRowPanel <> nil) then with FixedRowPanel do RectAngle(StartX + Left, Top, Left + Width, Top + Height);
                                      if (FixedColPanel <> nil) then with FixedColPanel do RectAngle(Left, Top, Left + Width, Point.Y);
                                      if (DataRowPanel  <> nil) then with DataRowPanel  do RectAngle(StartX + Left, Top, Left + Width, Point.Y);
                                    end;
                      end;
                    end;
          meWidth : begin
                      case SizingMode.ChildPanelType of
                        cpCorner,
                        cpFixedCol: begin
                                      if (CornerPanel   <> nil) then with CornerPanel   do RectAngle(Left, Top, Point.X, Top + Height);
                                      if (FixedColPanel <> nil) then with FixedColPanel do RectAngle(Left, Top, Point.X, Top + Height);
                                      if (FixedRowPanel <> nil) then with FixedRowPanel do RectAngle(Point.X, Top, Point.X + Width - StartX, Top + Height);
                                      if (DataRowPanel  <> nil) then with DataRowPanel  do RectAngle(Point.X, Top, Point.X + Width - StartX, Top + Height);
                                    end;
                        cpFixedRow,
                        cpDataRow : begin
                                      if (CornerPanel   <> nil) then with CornerPanel   do RectAngle(Left, Top, Left + Width, Top + Height);
                                      if (FixedColPanel <> nil) then with FixedColPanel do RectAngle(Left, Top, Left + Width, Top + Height);
                                      if (FixedRowPanel <> nil) then with FixedRowPanel do RectAngle(StartX + Left, Top, Point.X, Top + Height);
                                      if (DataRowPanel  <> nil) then with DataRowPanel  do RectAngle(StartX + Left, Top, Point.X, Top + Height);
                                    end;
                      end;
                    end;
        end;
      finally
        // �y���A�u���V���A
        Pen := OldPen;
        Brush := OldBrush;
      end;
    end;
  finally
    //��p�y���A�u���V�j��
    OldPen.Free;
    OldBrush.Free;
  end;
end;

//****************************************************************************//
//  THTable �}�E�X�ɂ��T�C�Y�ύX
//****************************************************************************//
procedure THTable.ChangeChildPanelSize(Point: TPoint; SizingMode: TSizingMode);
begin
  //���p�e�B�ύX
  case SizingMode.MouseEditMode of
    meBoth: case SizingMode.ChildPanelType of
              cpCorner  : begin
                            FixedRowHeight := Point.Y;
                            FixedColWidth := Point.X;
                          end;
              cpFixedRow: begin
                            FixedRowHeight := Point.Y;
                            if (FFixedStyle = fsBoth) then DataRowWidth := StartX + Point.X - FixedColWidth
                            else
                            if (FFixedStyle = fsCol ) then DataRowWidth := StartX + Point.X - FixedColWidth
                            else                           DataRowWidth := StartX + Point.X;
                          end;
              cpFixedCol: begin
                            if (FFixedStyle = fsBoth) then DataRowHeight := Point.Y - FixedRowHeight
                            else
                            if (FFixedStyle = fsRow ) then DataRowHeight := Point.Y - FixedRowHeight
                            else                           DataRowHeight := Point.Y;
                            FixedColWidth := Point.X;
                          end;
              cpDataRow : begin
                            if (FFixedStyle = fsBoth) then DataRowHeight := Point.Y - FixedRowHeight
                            else
                            if (FFixedStyle = fsRow ) then DataRowHeight := Point.Y - FixedRowHeight
                            else                           DataRowHeight := Point.Y;

                            if (FFixedStyle = fsBoth) then DataRowWidth := StartX + Point.X - FixedColWidth
                            else
                            if (FFixedStyle = fsCol ) then DataRowWidth := StartX + Point.X - FixedColWidth
                            else                           DataRowWidth := StartX + Point.X;
                          end;
            end;
    meHeight: case SizingMode.ChildPanelType of
                cpCorner,
                cpFixedRow: begin
                              FixedRowHeight := Point.Y;
                            end;
                cpFixedCol,
                cpDataRow : begin
                              if (FFixedStyle = fsBoth) then DataRowHeight := Point.Y - FixedRowHeight
                              else
                              if (FFixedStyle = fsRow ) then DataRowHeight := Point.Y - FixedRowHeight
                              else                           DataRowHeight := Point.Y;
                            end;
              end;
    meWidth : case SizingMode.ChildPanelType of
                cpCorner,
                cpFixedCol: begin
                              FixedColWidth := Point.X;
                            end;
                cpFixedRow,
                cpDataRow : begin
                              if (FFixedStyle = fsBoth) then DataRowWidth := StartX + Point.X - FixedColWidth
                              else
                              if (FFixedStyle = fsCol ) then DataRowWidth := StartX + Point.X - FixedColWidth
                              else                           DataRowWidth := StartX + Point.X;
                            end;
              end;
  end;

  //�p�l���ɕύX�𔽉f����
  SetupChildPanels;
end;

//****************************************************************************//
//  THTable �q�p�l���̃����o�ݒ�
//****************************************************************************//
procedure THTable.SetupPanelMember;
var
  ix, iy: Integer;
  Control: TControl;
begin
  // �R�[�i�[�p�l���q�R���g���[���̐ݒ�
  if (CornerPanel <> nil) then begin
    for ix := 0 to FCornerMember.Count - 1 do begin
      for iy := 0 to ControlCount do begin
        if (FCornerMember.Strings[ix] <> Controls[iy].Name) then Continue;
        Control := Controls[iy];
        RemoveControl(Control);
        CornerPanel.InsertControl(Control);
        Break;
      end;
    end;
  end;

  // �Œ�s�p�l���q�R���g���[���̐ݒ�
  if (FixedRowPanel <> nil) then begin
    for ix := 0 to FFixedRowMember.Count - 1 do begin
      for iy := 0 to ControlCount do begin
        if (FFixedRowMember.Strings[ix] <> Controls[iy].Name) then Continue;
        Control := Controls[iy];
        RemoveControl(Control);
        FixedRowPanel.InsertControl(Control);
        Break;
      end;
    end;
  end;

  // �Œ�s�p�l���q�R���g���[���̐ݒ�
  if (FixedColPanel <> nil) then begin
    for ix := 0 to FFixedColMember.Count - 1 do begin
      for iy := 0 to ControlCount do begin
        if (FFixedColMember.Strings[ix] <> Controls[iy].Name) then Continue;
        Control := Controls[iy];
        RemoveControl(Control);
        FixedColPanel.InsertControl(Control);
        Break;
      end;
    end;
  end;

  // �f�[�^�s�p�l���q�R���g���[���̐ݒ�
  for ix := 0 to FDataRowMember.Count - 1 do begin
    for iy := 0 to ControlCount do begin
      if (FDataRowMember.Strings[ix] <> Controls[iy].Name) then Continue;
      Control := Controls[iy];
      RemoveControl(Control);
      DataRowPanel.InsertControl(Control);
      Break;
    end;
  end;
end;

//****************************************************************************//
//  THTable �s�̕���
//****************************************************************************//
procedure THTable.DuplicateRow;
var
  ix, TabCount: Integer;
  NewFixedColPanel, NewDataRowPanel: TRCChildPanel;

  //--------------------------------------------------------------------------//
  //  �x�[�X�s�̃����o�̔z��ԍ����O��
  //--------------------------------------------------------------------------//
  procedure InitBaseMembers(Panel: TRCChildPanel);
  var
    ix: Integer;
    sTxt: String;
    Control: TControl;
  begin
    for ix := 0 to Panel.ControlCount - 1 do begin
      Control := Panel.Controls[ix];

      if (Control is TLabel) then sTxt := TLabel(Control).Caption
      else
      if (Control is TEdit ) then sTxt := TEdit(Control).Text;

      Control.Name := CombineName(Control.Name, 0);

      if (Control is TLabel) then TLabel(Control).Caption := sTxt
      else
      if (Control is TEdit ) then TEdit(Control).Text := sTxt;
    end;
  end;

  //--------------------------------------------------------------------------//
  //  �R���g���[���̕���
  //--------------------------------------------------------------------------//
  function DuplicateControl(Control: TControl; Index: Integer): TControl;
  var
    NewCtrl: TControl;
    Name: String;
    Row: Integer;
  begin
    NewCtrl := CreateControl(Owner, Control);
    if (NewCtrl <> nil) then begin
      DivideName(Control.Name, Name, Row);
      NewCtrl.Name := CombineName(Name, Index);
    end;
    Result := NewCtrl;
  end;

  //--------------------------------------------------------------------------//
  //  �p�l�������o�̕���
  //--------------------------------------------------------------------------//
  procedure DuplicateMembers(NewPanel: TRCChildPanel; Index: Integer; OrgPanel: TRCChildPanel);
  var
    ix: Integer;
    NewCtrl: TControl;
  begin
    for ix := 0 to OrgPanel.ControlCount - 1 do begin
      NewCtrl := DuplicateControl(OrgPanel.Controls[ix], Index);
      if (NewCtrl <> nil) then begin
        NewPanel.InsertControl(NewCtrl);
        CopyControlProperty(NewCtrl, OrgPanel.Controls[ix]);
      end;
    end;
  end;

begin
  // �^�u�ݒ�
  TabCount := 0;
  if (CornerPanel <> nil) then begin
    CornerPanel.TabOrder := TabCount;
    Inc(TabCount);
  end;

  if (FixedRowPanel <> nil) then begin
    FixedRowPanel.TabOrder := TabCount;
    Inc(TabCount);
  end;

  if (FixedColPanel <> nil) then begin
    FixedColPanel.TabOrder := TabCount;
    Inc(TabCount);
  end;

  if (DataRowPanel <> nil) then begin
    DataRowPanel.TabOrder := TabCount;
    Inc(TabCount);
  end;

  // �x�[�X�s�̃����o�̔z��ԍ���0��
  InitBaseMembers(DataRowPanel);
  if (FixedColPanel <> nil) then InitBaseMembers(FixedColPanel);

  for ix := 1 to FVisibleRowCount - 1 do begin
    // �f�[�^�s�p�l������
    NewDataRowPanel := TRCChildPanel.Create(Self);

    FDataRowStyle.Name     := kDataRowName + IntToStr(ix);
    SetPanelStyle(NewDataRowPanel, FDataRowStyle);
    NewDataRowPanel.Top    := DataRowPanel.Top + DataRowHeight * ix;
    NewDataRowPanel.Left   := DataRowPanel.Left;
    NewDataRowPanel.Height := DataRowPanel.Height;
    NewDataRowPanel.Width  := DataRowPanel.Width;
    InsertControl(NewDataRowPanel);

    // �f�[�^�s�p�l���̃����o�R���g���[������
    DuplicateMembers(NewDataRowPanel, ix, DataRowPanel);

    if (FixedColPanel <> nil) then begin
      // �Œ茅�p�l������
      NewFixedColPanel := TRCChildPanel.Create(Self);

      FFixedColStyle.Name := kFixedColName + IntToStr(ix);
      SetPanelStyle(NewFixedColPanel, FFixedColStyle);

      NewFixedColPanel.Top    := FixedColPanel.Top + DataRowHeight * ix;
      NewFixedColPanel.Left   := FixedColPanel.Left;
      NewFixedColPanel.Height := FixedColPanel.Height;
      NewFixedColPanel.Width  := FixedColPanel.Width;
      InsertControl(NewFixedColPanel);

      // �^�u�ݒ�
      NewFixedColPanel.TabOrder := TabCount;
      Inc(TabCount);

      // �Œ茅�p�l���̃����o�R���g���[������
      DuplicateMembers(NewFixedColPanel, ix, FixedColPanel);
    end;

    // �^�u�ݒ�
    NewDataRowPanel.TabOrder := TabCount;
    Inc(TabCount);
  end;
end;

//****************************************************************************//
//  THTable �����o�R���g���[���̌���
//****************************************************************************//
function THTable.IsMyMember(Control: TControl): Boolean;
begin
  if (Control = nil) then begin
    Result := False;
  end else
  if (Control.Parent is TRCChildPanel) then begin
    Result := True;
  end else begin
    Result := False;
  end;
end;

//****************************************************************************//
//  THTable ���L���s���̎擾
//****************************************************************************//
function THTable.GetEnableRowCount: Integer;
begin
  if (FixedRowPanel <> nil) then begin
    Result := (ClientHeight - FixedRowHeight) div DataRowHeight;
  end else begin
    Result := ClientHeight div DataRowHeight;
  end;
end;

//****************************************************************************//
//  THTable ���N���C�A���g���W�̎擾
//****************************************************************************//
function THTable.GetMovableRect: TRect;
begin
  Result := GetClientRect;
  if (FixedColPanel <> nil) then Result.Left := Result.Left + FFixedColWidth;
  if (FixedRowPanel <> nil) then Result.Top  := Result.Top  + FFixedRowHeight;
end;

//****************************************************************************//
//  THTable ���N���C�A���g���̎擾
//****************************************************************************//
function THTable.GetMovableWidth: Integer;
begin
  if (FixedColPanel <> nil) then begin
    Result := ClientWidth - FixedColWidth;
  end else begin
    Result := ClientWidth;
  end;
end;

//****************************************************************************//
//  THTable �N���C�A���g��`���X�N���[����`�ɕϊ�
//****************************************************************************//
function THTable.ClientRcToScreenRc(WinControl: TWinControl; Rc: TRect): TRect;
var
  Pt1, Pt2: TPoint;
begin
  Pt1 := WinControl.ClientToScreen(Point(Rc.Left , Rc.Top   ));
  Pt2 := WinControl.ClientToScreen(Point(Rc.Right, Rc.Bottom));
  Result := Rect(Pt1.X, Pt1.Y, Pt2.X, Pt2.Y);
end;

//****************************************************************************//
//  THTable �w��s�̖�����
//****************************************************************************//
procedure THTable.InvalidateRow(ARow: Integer);
var
  Component: TComponent;
begin
  // �Œ茅�p�l��
  if (FixedColPanel <> nil) then begin
    Component := FindComponent(kFixedColName + IntToStr(ARow));
    if (Component <> nil) then begin
      TRCChildPanel(Component).Invalidate;
    end;
  end;

  // �f�[�^�p�l��
  Component := FindComponent(kDataRowName + IntToStr(ARow));
  if (Component <> nil) then begin
    TRCChildPanel(Component).Invalidate;
  end;
end;

//****************************************************************************//
//  THTable �I�u�W�F�N�g���̒���
//****************************************************************************//
procedure THTable.AdjustHeight;
var
  NewHeight: Integer;
begin
  if (FixedRowPanel <> nil) then NewHeight := FixedRowHeight
  else                           NewHeight := 0;
  NewHeight := NewHeight + FDataRowHeight * FVisibleRowCount;
  ClientHeight := NewHeight;
end;

//****************************************************************************//
//  THTable CM_DESIGNHITTEST�ւ̉���
//****************************************************************************//
procedure THTable.CMDesignHitTest(var Msg: TCMDesignHitTest);
var
  ClientRect: TRect;
  Pt: TPoint;
begin
  Pt := Point(Msg.Pos.X, Msg.Pos.Y);
  MousePoint := Pt;

  // �T�C�Y�ύX���[�h
  if (NowSizing) then begin
    Msg.Result := Longint(True);
  end else begin
    // �q�p�l����ޕύX���[�h��L����
    SizingMode := GetSizingMode(Pt);
    if (SizingMode.MouseEditMode <> meNone) then begin
      Msg.Result := Longint(True);
    end;

    // �X�N���[���o�[��L����
    ClientRect := GetClientRect;
    if not IsIncludePoint(Pt, ClientRect) then begin
      Msg.Result := Longint(False);
    end;
  end;
end;

//****************************************************************************//
//  THTable WM_LBUTTONDOWN�ւ̉���
//****************************************************************************//
procedure THTable.WMLButtonDown(var Msg: TWMLButtonDown);
begin
  if (csDesigning in ComponentState) and (SizingMode.MouseEditMode <> meNone) then begin
    // �T�C�Y�ύX���[�h�˓�
    AllignMousePoint(MousePoint, SizingMode);
    DrawSizingLine(MousePoint, SizingMode);
    OldMousePoint := MousePoint;
    BaseMousePoint := MousePoint;
    NowSizing := True;
    DoSizing := False;

    // �}�E�X��L�J�n
    SetCaptureControl(Self);
  end;

  // �h�����ďo��
  inherited;
end;

//****************************************************************************//
//  THTable WM_LBUTTONUP�ւ̉���
//****************************************************************************//
procedure THTable.WMLButtonUp(var Msg: TWMLButtonUp);
begin
  if (NowSizing) then begin
    // �T�C�Y�ύX���[�h�I��
    DrawSizingLine(OldMousePoint, SizingMode);
    NowSizing := False;

    // �}�E�X��L�I��
    SetCaptureControl(nil);

    // �T�C�Y�ύX
    if (OldMousePoint.X <> BaseMousePoint.X) or (OldMousePoint.Y <> BaseMousePoint.Y) then begin
      // �q�p�l���T�C�Y�̕ύX
      ChangeChildPanelSize(OldMousePoint, SizingMode);

      // �R���|�[�l���g�����̒���
      AdjustHeight;
    end;
  end;

  // �h�����ďo��
  inherited;
end;

//****************************************************************************//
//  THTable WM_MOUSEMOVE�ւ̉���
//****************************************************************************//
procedure THTable.WMMouseMove(var Msg: TWMMouseMove);
begin
  // �T�C�Y�ύX���[�h
  if (NowSizing) then begin
    DrawSizingLine(OldMousePoint, SizingMode);
    if (DoSizing) then begin
      OldMousePoint := MousePoint;
    end else begin
      DoSizing := True;
    end;
    DrawSizingLine(OldMousePoint, SizingMode);
  end;

  // �h�����ďo��
  inherited;
end;

//****************************************************************************//
//  THTable WM_NCHITTEST�ւ̉���
//****************************************************************************//
procedure THTable.WMNCHitTest(var Msg: TWMNCHitTest);
begin
  // �݌v���̃X�N���[���o�[�̓����L����
  DefaultHandler(Msg);
end;

//****************************************************************************//
//  THTable WM_VSCROLL�ւ̉���
//****************************************************************************//
procedure THTable.WMVScroll(var Msg: TWMVScroll);
var
  VkCode: Word;
  PrevCtrl, NextCtrl, OrgNextCtrl: TWinControl;
  MaxTopRow, PrevTopRow: Integer;
begin
  if (Msg.ScrollCode = SB_ENDSCROLL) or (Msg.ScrollCode = SB_THUMBTRACK) then Exit;

  PrevCtrl := GetBaseControl(TForm(Owner).ActiveControl);
  if ((Msg.ScrollCode = SB_LINEUP) or (Msg.ScrollCode = SB_LINEDOWN)) and (TMessage(Msg).LParam = -1) then begin
    NextCtrl := NextControl;
  end else begin
    NextCtrl := GetBaseControl(TForm(Owner).ActiveControl);
  end;
  OrgNextCtrl := NextCtrl;
  PrevTopRow := GetTopLine2(Self, MaxTopRow);

  // OnChangeFocus�C�x���g����
  if IsHTableControl(PrevCtrl) then begin
    VkCode := 0;
    case Msg.ScrollCode of
      SB_LINEUP:        begin
                          if (Msg.Pos = 0) then begin
                            FNextTopRow := PrevTopRow - 1;
                          end else begin
                            FNextTopRow := PrevTopRow - FFastScrollRows;
                          end;
                          if (FNextTopRow < 0) then begin
                            FNextTopRow := 0;
                          end;
                          VkCode := VK_UP;
                        end;
      SB_LINEDOWN     : begin
                          // ���g�p�̈�ɂ́A�t�H�[�J�X�ړ��������Ȃ��B
                          if (EnableMaxScrollRow) and (PrevTopRow + VisibleRowCount - 1 >= MaxScrollRow) then Exit;

                          if (Msg.Pos = 0) then begin
                            FNextTopRow := PrevTopRow + 1;
                          end else begin
                            FNextTopRow := PrevTopRow + FFastScrollRows;
                          end;
                          if (FNextTopRow > MaxTopRow) then begin
                            FNextTopRow := MaxTopRow;
                          end;
                          VkCode := VK_DOWN;
                        end;
      SB_PAGEUP       : begin
                          FNextTopRow := PrevTopRow - FVisibleRowCount;
                          if (FNextTopRow < 0) then begin
                            FNextTopRow := 0;
                          end;
                          VkCode := VK_PRIOR;
                        end;
      SB_PAGEDOWN     : begin
                          FNextTopRow := PrevTopRow + FVisibleRowCount;
                          if (FNextTopRow > MaxTopRow) then begin
                            FNextTopRow := MaxTopRow;
                          end;
                          VkCode := VK_NEXT;
                        end;
      SB_THUMBPOSITION: begin
                          // ���g�p�̈�ɂ́A�t�H�[�J�X�ړ��������Ȃ��B
                          if (EnableMaxScrollRow) and ((PrevTopRow > MaxScrollRow) or (Msg.Pos + FVisibleRowCount + FVisibleRowCount > MaxScrollRow)) then Exit;
                          FNextTopRow := Msg.Pos;
                          VkCode := 0;
                        end;
    end;

    if Assigned(FOnChangeFocus) then FOnChangeFocus(PrevCtrl, NextCtrl, VkCode);
  end;

  if (NextCtrl <> OrgNextCtrl) then begin
    Msg.Result := -1;
    if (NextCtrl <> nil) then NextCtrl.SetFocus;
  end else begin
    // �X�N���[���A�y�[�W�؂�ւ�
    case Msg.ScrollCode of
      SB_LINEUP  : begin
                     if (Msg.Pos = 0) then SetTopLine2(Self, -1, 1)
                     else                  SetTopLine2(Self, -1 * FFastScrollRows, 1);
                   end;
      SB_LINEDOWN: begin
                     if (Msg.Pos = 0) then SetTopLine2(Self, 1, 1)
                     else                  SetTopLine2(Self, FFastScrollRows, 1);
                   end;
      SB_PAGEUP  : begin
                     SetTopLine2(Self, FVisibleRowCount * (-1), 1);
                   end;
      SB_PAGEDOWN: begin
                     if (EnableMaxScrollRow) and ((PrevTopRow > MaxScrollRow) or (PrevTopRow + FVisibleRowCount + FVisibleRowCount > MaxScrollRow)) then begin
                       SetTopLine(MaxScrollRow - FVisibleRowCount + 1, lmSET);
                     end else begin
                       SetTopLine2(Self, FVisibleRowCount, 1);
                     end;
                   end;
    end;

    // �c�X�N���[���o�[�T���ʒu�ݒ�
    if (FScrollBars = ssBoth) or (FScrollBars = ssVertical) then begin
      SetScrollPos(Handle, SB_VERT, GetTopLine2(Self, MaxTopRow), True);
    end;
  end;
end;

//****************************************************************************//
//  THTable WM_HSCROLL�ւ̉���
//****************************************************************************//
procedure THTable.WMHScroll(var Msg: TWMHScroll);
var
  ix, MaxPos, NewStartX, NewLeft: Integer;
  Component: TComponent;
begin
  // �����W�ݒ�
  MaxPos := DataRowWidth - GetMovableWidth + 24;
  if (MaxPos < 1) then MaxPos := 1;
  if (FScrollBars = ssBoth) or (FScrollBars = ssHorizontal) then SetScrollRange(Handle, SB_HORZ, 0, MaxPos, True);

  // �V�����n�_X���W�擾
  NewStartX := StartX;
  case Msg.ScrollCode of
    SB_LINELEFT  : NewStartX := StartX - 1;
    SB_LINERIGHT : NewStartX := StartX + 1;
    SB_PAGELEFT  : NewStartX := StartX - GetMovableWidth;
    SB_PAGERIGHT : NewStartX := StartX + GetMovableWidth;
    SB_THUMBTRACK: NewStartX := Msg.Pos;
  end;
  if (NewStartX < 0     ) then NewStartX := 0
  else
  if (NewStartX > MaxPos) then NewStartX := MaxPos;

  // �ĕ`��
  if (NewStartX <> StartX) and (MaxPos > 1) then begin
    // �X�N���[���o�[
    StartX := NewStartX;
    if (FScrollBars = ssBoth) or (FScrollBars = ssHorizontal) then SetScrollPos(Handle, SB_HORZ, StartX, True);

    // �q�p�l��
    if (FixedColPanel = nil) then  NewLeft := StartX * (-1)
    else                           NewLeft := StartX * (-1) + FixedColWidth;

    if (FixedRowPanel <> nil) then FixedRowPanel.Left := NewLeft;
    DataRowPanel.Left := NewLeft;

    if not(csDesigning in ComponentState) then begin
      for ix := 1 to FDataRowCount - 1 do begin
        Component := FindComponent(kDataRowName + IntToStr(ix));
        if (Component <> nil) then (Component as TControl).Left := NewLeft;
      end;
    end;

    Update;
  end;
end;

//****************************************************************************//
//  THTable CM_FOCUSCHANGERD�ւ̉���
//****************************************************************************//
procedure THTable.CMFocusChanged(var Msg: TCMFocusChanged);
var
  PrevActiveMember, ActiveCtrl: TWinControl;
  PrevRow, NextRow, NextX: Integer;
  PrevName, NextName: String;
  MovableRect, MemberRect: TRect;
begin
  if (TForm(Owner).ActiveControl = nil) then Exit;

  ActiveCtrl := GetBaseControl(TForm(Owner).ActiveControl);

  // �e�q�p�l���̃����o�̃t�H�[�J�X�ړ��ɑΉ�
  if IsMyMember(ActiveCtrl) then begin
    PrevActiveMember := ActiveMember;
    ActiveMember := ActiveCtrl;

    // �c�X�N���[��
    if (PrevActiveMember = nil) then begin
      PrevRow := 0;
    end else begin
      DivideName(PrevActiveMember.Name, PrevName, PrevRow);
    end;
    DivideName(ActiveMember.Name, NextName, NextRow);

    if (TRCChildPanel(ActiveMember.Parent).ChildType = cpCorner  ) or
       (TRCChildPanel(ActiveMember.Parent).ChildType = cpFixedRow) then begin
      ;
    end else
    if (StartRow + GetEnableRowCount <= NextRow) then begin
      if (NextRow = PrevRow + 1) then begin
        SendMessage(Handle, WM_VSCROLL, SB_LINEDOWN, 0);
      end else begin
        SendMessage(Handle, WM_VSCROLL, MAKEWPARAM(SB_THUMBTRACK, NextRow), 0);
      end;
    end else
    if (NextRow < StartRow) then begin
      if (NextRow = PrevRow - 1) then begin
        SendMessage(Handle, WM_VSCROLL, SB_LINEUP, 0);
      end else begin
        SendMessage(Handle, WM_VSCROLL, MAKEWPARAM(SB_THUMBTRACK, NextRow), 0);
      end;
    end;

    // ���X�N���[��
    MovableRect := ClientRcToScreenRc(Self, GetMovableRect);
    MemberRect  := ClientRcToScreenRc(ActiveMember.Parent, GetControlRect(ActiveMember));

    if (TRCChildPanel(ActiveMember.Parent).ChildType = cpCorner  ) or
       (TRCChildPanel(ActiveMember.Parent).ChildType = cpFixedCol) then begin
      ;
    end else
    if (MemberRect.Left < MovableRect.Left) then begin
      NextX := ActiveMember.Left - FHScrollMargin;
      if (NextX < 0) then NextX := 0;
      SendMessage(Handle, WM_HSCROLL, MAKEWPARAM(SB_THUMBTRACK, NextX), 0);
    end else
    if (MemberRect.Right > MovableRect.Right) then begin
      NextX := ActiveMember.Left + ActiveMember.Width - GetMovableWidth + HScrollMargin;
      SendMessage(Handle, WM_HSCROLL, MAKEWPARAM(SB_THUMBTRACK, NextX), 0);
    end;
  end;
end;

//****************************************************************************//
//  THTable WM_SIZE���b�Z�[�W�̕ߑ�
//****************************************************************************//
procedure THTable.WMSize(var Message: TWMSize);
begin
  // �h�����Ăяo��
  inherited;
  AdjustHeight;
end;

//****************************************************************************//
//  THTable �E�B���h�E�X�^�C���̐ݒ�
//****************************************************************************//
procedure THTable.CreateParams(var Params: TCreateParams);
begin
  // �h�����ďo��
  inherited CreateParams(Params);

  // Window�X�^�C���̐ݒ�
  with Params do begin
    Style := Style or WS_TABSTOP;
    Style := Style or WS_BORDER;
    if FScrollBars in [ssVertical  , ssBoth] then Style := Style or WS_VSCROLL;
    if FScrollBars in [ssHorizontal, ssBoth] then Style := Style or WS_HSCROLL;
  end;
end;

//****************************************************************************//
//  THTable �q�R���|�[�l���g��Ԃ�
//****************************************************************************//
procedure THTable.GetChildren(Proc: TGetChildProc; Root: TComponent);
var
  ix: Integer;
begin
  // �R�[�i�[�p�l��
  if (FFixedStyle = fsBoth) then begin
    with CornerPanel do begin
      for ix := 0 to ControlCount - 1 do Proc(Controls[ix]);
    end;
  end;

  // �Œ�s�p�l��
  if (FFixedStyle = fsBoth) or (FFixedStyle = fsRow) then begin
    with FixedRowPanel do begin
      for ix := 0 to ControlCount - 1 do Proc(Controls[ix]);
    end;
  end;

  // �Œ茅�p�l��
  if (FFixedStyle = fsBoth) or (FFixedStyle = fsCol) then begin
    with FixedColPanel do begin
      for ix := 0 to ControlCount - 1 do Proc(Controls[ix]);
    end;
  end;

  // �f�[�^�s�p�l��
  with DataRowPanel do begin
    for ix := 0 to ControlCount - 1 do Proc(Controls[ix]);
  end;
end;

//****************************************************************************//
//  THTable �t�H�[���ǂݍ��݌�̏�����
//****************************************************************************//
procedure THTable.Loaded;
var
  TabCount: Integer;
begin
  // �h�����ďo��
  inherited Loaded;

  // �q�p�l���̃����o�̐ݒ�
  SetupPanelMember;

  if not(csDesigning in ComponentState) then begin
    // �s�̕���
    DuplicateRow;

    // �Œ�s�p�l���A�R�[�i�[�p�l���̍đ}��
    if (FixedRowPanel <> nil) then ReAttachPanel(FixedRowPanel);
    if (CornerPanel   <> nil) then ReAttachPanel(CornerPanel);

    // �Œ�s�p�l���A�R�[�i�[�p�l���̃^�u�Đݒ�
    TabCount := 0;
    if (CornerPanel <> nil) then begin
      CornerPanel.TabOrder := TabCount;
      Inc(TabCount);
    end;
    if (FixedRowPanel <> nil) then begin
      FixedRowPanel.TabOrder := TabCount;
    end;

    // ���s���ݒ�
    SetVisibleRowCount(FVisibleRowCount);
  end;
end;

//****************************************************************************//
//  THTable �E�B���h�E����
//****************************************************************************//
procedure THTable.CreateWnd;
begin
  // �h�����Ăяo��
  inherited CreateWnd;

  // �c�X�N���[���o�[�����W�̐ݒ�
  if ((FScrollBars = ssBoth) or (FScrollBars = ssVertical)) and (FDataRowCount > FVisibleRowCount) then begin
    SetScrollRange(Handle, SB_VERT, 0, FDataRowCount - FVisibleRowCount, True);
  end;
end;


//############################################################################//
//
//  �֐�
//
//############################################################################//

//****************************************************************************//
//  Name�̕���
//****************************************************************************//
procedure DivideName(Src: String; var Name: String; var Row: Integer);
var
  sBuf: String;
  ix: Integer;
begin
  Name := Src;
  sBuf := '';

  for ix := Length(Name) downto 1 do begin
    if (Name[ix] = '_') then begin
      Delete(Name, ix, 1);
      Break;
    end;

    if Ord(Name[ix]) in [Ord('0') .. Ord('9')] then Insert(Name[ix], sBuf, 1);

    Delete(Name, ix, 1);
  end;

  if (sBuf = '') then begin
    Row := -1;
  end else begin
    Row := StrToInt(sBuf);
  end;
end;

//****************************************************************************//
//  Name�̐���
//****************************************************************************//
function CombineName(Name: String; Row: Integer): String;
begin
  Result := Name + '_' + IntToStr(Row);
end;

//****************************************************************************//
//
//****************************************************************************//
function IsHTableControl(Component: TComponent): Boolean;
begin
  Result := False;
  if (Component is TControl) then begin
    Result := (TControl(Component).Parent.Owner is THTable) and
              ((Pos('FixedColPanel', TControl(Component).Parent.Name) > 0) or (Pos('DataRowPanel' , TControl(Component).Parent.Name) > 0));
  end;
end;

//****************************************************************************//
//
//****************************************************************************//
function GetTopLine2(Component: TComponent; var MaxTopLine: Integer): Integer;
begin
  Result := 0;
  if (Component is THTable) then begin
    MaxTopLine := (THTable(Component).DataRowCount - 1) - THTable(Component).VisibleRowCount + 1;
    Result := THTable(Component).FTopLine;
  end;
end;

//****************************************************************************//
//
//****************************************************************************//
function SetTopLine2(Component: TComponent; Position, Mode: Integer): Integer;
var
  TopLine, MaxTopLine: Integer;
begin
  Result := 0;
  if (Component is THTable) then begin
    TopLine := GetTopLine2(Component, MaxTopLine);

    if (Mode <> 0) then begin
      Position := Position + TopLine;
    end;

    if (Position < 0) then begin
      Position := 0
    end else
    if (Position > MaxTopLine) then begin
      Position := MaxTopLine;
    end;

    THTable(Component).FTopLine := Position;

    Result := Position;
  end;
end;

//****************************************************************************//
//  �R���g���[����`�̎擾
//****************************************************************************//
function GetControlRect(Control: TControl): TRect;
begin
  with Control do begin
    Result.Left   := Left;
    Result.Top    := Top;
    Result.Right  := Left + Width  - 1;
    Result.Bottom := Top  + Height - 1;
  end;
end;

//****************************************************************************//
//  TRect�^�̃V�t�g
//****************************************************************************//
function ShiftRect(Rect: TRect; DX, DY: Integer): TRect;
begin
  with Rect do begin
    Result.Left   := Left   + DX;
    Result.Top    := Top    + DY;
    Result.Right  := Right  + DX;
    Result.Bottom := Bottom + DY;
  end;
end;

//****************************************************************************//
//  TRect�^���������ǂ������ׂ�
//****************************************************************************//
function IsSameRect(Rc1, Rc2: TRect): Boolean;
begin
  if (Rc1.Left   <> Rc2.Left  ) then Result := False
  else
  if (Rc1.Top    <> Rc2.Top   ) then Result := False
  else
  if (Rc1.Right  <> Rc2.Right ) then Result := False
  else
  if (Rc1.Bottom <> Rc2.Bottom) then Result := False
  else                               Result := True;
end;

//****************************************************************************//
//  ���W�̋�`��܌���
//****************************************************************************//
function IsIncludePoint(Pt: TPoint; Rect: TRect): Boolean;
begin
  if (Pt.X < Rect.Left) or (Rect.Right  < Pt.X) then IsIncludePoint := False
  else
  if (Pt.Y < Rect.Top ) or (Rect.Bottom < Pt.Y) then IsIncludePoint := False
  else                                               IsIncludePoint := True;
end;

//****************************************************************************//
//  TPoint�^�̃V�t�g
//****************************************************************************//
function ShiftPoint(Point: TPoint; DX, DY: Integer): TPoint;
begin
  ShiftPoint.X := Point.X + DX;
  ShiftPoint.Y := Point.Y + DY;
end;

//****************************************************************************//
//  �����R���|�[�l���g�̃x�[�X�R���g���[�����擾����
//****************************************************************************//
function GetBaseControl(Control: TWinControl): TWinControl;
begin
       if (Control = nil)               then Result := nil
  else if (Control.Owner is THDateEdit) then Result := TWinControl(Control.Owner)
  else if (Control.Owner is THTable  ) then Result := TWinControl(Control.Owner)
  else                                       Result := Control;
end;

//****************************************************************************//
//  TControl�h���I�u�W�F�N�g�̐���
//****************************************************************************//
function CreateControl(Owner: TComponent; Control: TControl): TControl;
begin
  Result := nil;
  // HSS100 palette
       if (Control is THDateEdit  ) then Result := THDateEdit  .Create(Owner)
  else if (Control is THNedit     ) then Result := THNedit     .Create(Owner)
  else if (Control is THEdit      ) then Result := THEdit      .Create(Owner)
  // Additional palette
  else if (Control is TBitBtn     ) then Result := TBitBtn     .Create(Owner)
  else if (Control is TMaskEdit   ) then Result := TMaskEdit   .Create(Owner)
  else if (Control is TImage      ) then Result := TImage      .Create(Owner)
  else if (Control is TShape      ) then Result := TShape      .Create(Owner)
  else if (Control is TBevel      ) then Result := TBevel      .Create(Owner)
  // Standard palette
  else if (Control is TLabel      ) then Result := TLabel      .Create(Owner)
  else if (Control is TEdit       ) then Result := TEdit       .Create(Owner)
  else if (Control is TButton     ) then Result := TButton     .Create(Owner)
  else if (Control is TCheckBox   ) then Result := TCheckBox   .Create(Owner)
  else if (Control is TRadioButton) then Result := TRadioButton.Create(Owner)
  else if (Control is TComboBox   ) then Result := TComboBox   .Create(Owner)
  else if (Control is TRadioGroup ) then Result := TRadioGroup .Create(Owner)
  else if (Control is TPanel      ) then Result := TPanel      .Create(Owner)
end;

//****************************************************************************//
//  TControl�v���p�e�B�̃R�s�[
//****************************************************************************//
procedure CopyControlProperty(Dst: TControl; Src: TControl);
begin
  // HSS100 palette
       if (Src is THDateEdit  ) then CopyHDateEditProperty(THDateEdit(Dst), THDateEdit(Src))
  else if (Src is THNedit     ) then CopyHNeditProperty(THNedit(Dst), THNedit(Src))
  else if (Src is THEdit      ) then CopyHEditProperty(THEdit(Dst), THEdit(Src))
  // Additional palette
  else if (Src is TBitBtn     ) then CopyBitBtnProperty(TBitBtn(Dst), TBitBtn(Src))
  else if (Src is TMaskEdit   ) then CopyMaskEditProperty(TMaskEdit(Dst), TMaskEdit(Src))
  else if (Src is TImage      ) then CopyImageProperty(TImage(Dst), TImage(Src))
  else if (Src is TShape      ) then CopyShapeProperty(TShape(Dst), TShape(Src))
  else if (Src is TBevel      ) then CopyBevelProperty(TBevel(Dst), TBevel(Src))
  // Standard palette
  else if (Src is TLabel      ) then CopyLabelProperty(TLabel(Dst), TLabel(Src))
  else if (Src is TEdit       ) then CopyEditProperty(TEdit(Dst), TEdit(Src))
  else if (Src is TButton     ) then CopyButtonProperty(TButton(Dst), TButton(Src))
  else if (Src is TCheckBox   ) then CopyCheckBoxProperty(TCheckBox(Dst), TCheckBox(Src))
  else if (Src is TRadioButton) then CopyRadioButtonProperty(TRadioButton(Dst), TRadioButton(Src))
  else if (Src is TComboBox   ) then CopyComboBoxProperty(TComboBox(Dst), TComboBox(Src))
  else if (Src is TRadioGroup ) then CopyRadioGroupProperty(TRadioGroup(Dst), TRadioGroup(Src))
  else if (Src is TPanel      ) then CopyPanelProperty(TPanel(Dst), TPanel(Src))
end;


//****************************************************************************//
//  �v���p�e�B�̃R�s�[
//============================================================================//
//  Name��TabOrder�̓R�s�[���Ȃ�
//  "*"�����Ă�����͍̂���ǉ���������
//****************************************************************************//

//----------------------------------------------------------------------------//
//  THDateEdit
//----------------------------------------------------------------------------//
procedure CopyHDateEditProperty(Dst: THDateEdit; Src: THDateEdit);
begin
  // �v���p�e�B
  Dst.AlignWithMargins    := Src.AlignWithMargins   ;  // *
  Dst.BorderStyle         := Src.BorderStyle        ;
  Dst.Color               := Src.Color              ;
  Dst.Ctl3D               := Src.Ctl3D              ;
  Dst.Cursor              := Src.Cursor             ;
  Dst.CustomHint          := Src.CustomHint         ;  // *
  Dst.DateFormat          := Src.DateFormat         ;
  Dst.DateSequence        := Src.DateSequence       ;
  Dst.Enabled             := Src.Enabled            ;
  Dst.EnabledEditors      := Src.EnabledEditors     ;
  Dst.ExtCase             := Src.ExtCase            ;
  Dst.Font                := Src.Font               ;
  Dst.GengouSection       := Src.GengouSection      ;
  Dst.Height              := Src.Height             ;
  Dst.HelpContext         := Src.HelpContext        ;
  Dst.HelpKeyword         := Src.HelpKeyword        ;  // *
  Dst.HelpType            := Src.HelpType           ;  // *
  Dst.Hint                := Src.Hint               ;
  Dst.ImeMode             := Src.ImeMode            ;
  Dst.InitFocus           := Src.InitFocus          ;
  Dst.JpnYearCol          := Src.JpnYearCol         ;
  Dst.LabelColor          := Src.LabelColor         ;  // *
  Dst.LabelD              := Src.LabelD             ;
  Dst.LabelM              := Src.LabelM             ;
  Dst.LabelSize           := Src.LabelSize          ;  // *
  Dst.LabelY              := Src.LabelY             ;
  Dst.Left                := Src.Left               ;
  Dst.Margins             := Src.Margins            ;  // *
  Dst.MenuType            := Src.MenuType           ;  // *
  Dst.NecessaryEditors    := Src.NecessaryEditors   ;
  Dst.Options             := Src.Options            ;
  Dst.ParentCustomHint    := Src.ParentCustomHint   ;  // *
  Dst.ReadOnly            := Src.ReadOnly           ;
  Dst.TabStop             := Src.TabStop            ;
  Dst.Tag                 := Src.Tag                ;
  Dst.Top                 := Src.Top                ;
  Dst.Transparents        := Src.Transparents       ;  // *
  Dst.Width               := Src.Width              ;
  Dst.YearName            := Src.YearName           ;
  Dst.YearNmListNumofDisp := Src.YearNmListNumofDisp;  // *

  // �C�x���g
  Dst.Onchange            := Src.Onchange           ;
  Dst.OnDblClick          := Src.OnDblClick         ;
  Dst.OnEnter             := Src.OnEnter            ;
  Dst.OnExit              := Src.OnExit             ;
  Dst.OnKeyDown           := Src.OnKeyDown          ;
  Dst.OnKeyUp             := Src.OnKeyUp            ;
  Dst.OnMouseDown         := Src.OnMouseDown        ;
  Dst.OnMouseUp           := Src.OnMouseUp          ;
end;

//----------------------------------------------------------------------------//
//  THNedit
//----------------------------------------------------------------------------//
procedure CopyHNeditProperty(Dst: THNedit; Src: THNedit);
begin
  // �v���p�e�B
  Dst.ActBgColor           := Src.ActBgColor          ;
  Dst.ActFgColor           := Src.ActFgColor          ;
  Dst.AlignWithMargins     := Src.AlignWithMargins    ;  // *
  Dst.AutoSelect           := Src.AutoSelect          ;
  Dst.AutoSize             := Src.AutoSize            ;
  Dst.BorderStyle          := Src.BorderStyle         ;
  Dst.CharCase             := Src.CharCase            ;
  Dst.CheckEmpty           := Src.CheckEmpty          ;  // *
  Dst.Color                := Src.Color               ;
  Dst.Ctl3D                := Src.Ctl3D               ;
  Dst.Cursor               := Src.Cursor              ;
  Dst.CustomHint           := Src.CustomHint          ;  // *
  Dst.DragCursor           := Src.DragCursor          ;
  Dst.DragMode             := Src.DragMode            ;
  Dst.Enabled              := Src.Enabled             ;
  Dst.ExtCase              := Src.ExtCase             ;  // *
  Dst.ExtEdit              := Src.ExtEdit             ;
  Dst.Font                 := Src.Font                ;
  Dst.Height               := Src.Height              ;
  Dst.HelpContext          := Src.HelpContext         ;
  Dst.HelpKeyword          := Src.HelpKeyword         ;
  Dst.HelpType             := Src.HelpType            ;  // *
  Dst.HideSelection        := Src.HideSelection       ;  // *
  Dst.Hint                 := Src.Hint                ;
  Dst.ImeMode              := Src.ImeMode             ;
  Dst.Left                 := Src.Left                ;
  Dst.Margins              := Src.Margins             ;  // *
  Dst.MouseBtnAutoFontSize := Src.MouseBtnAutoFontSize;  // *
  Dst.MouseBtnColor        := Src.MouseBtnColor       ;  // *
  Dst.MouseBtnDwnColor     := Src.MouseBtnDwnColor    ;  // *
  Dst.MouseBtnFont         := Src.MouseBtnFont        ;  // *
  Dst.MouseBtnSize         := Src.MouseBtnSize        ;  // *
  Dst.MouseInput           := Src.MouseInput          ;  // *
  Dst.NumEdit              := Src.NumEdit             ;
  Dst.OEMConvert           := Src.OEMConvert          ;
  Dst.ParentColor          := Src.ParentColor         ;
  Dst.ParentCtl3D          := Src.ParentCtl3D         ;
  Dst.ParentCustomHint     := Src.ParentCustomHint    ;  // *
  Dst.ParentFont           := Src.ParentFont          ;
  Dst.ParentShowHint       := Src.ParentShowHint      ;
  Dst.PasswordChar         := Src.PasswordChar        ;
  Dst.PopupMenu            := Src.PopupMenu           ;
  Dst.ReadOnly             := Src.ReadOnly            ;
  Dst.ShowHint             := Src.ShowHint            ;
  Dst.TabStop              := Src.TabStop             ;
  Dst.Tag                  := Src.Tag                 ;
  Dst.Top                  := Src.Top                 ;
  Dst.Visible              := Src.Visible             ;
  Dst.Width                := Src.Width               ;

  // �C�x���g
  Dst.Onchange             := Src.Onchange            ;
  Dst.Onclick              := Src.Onclick             ;
  Dst.OnDblClick           := Src.OnDblClick          ;
  Dst.OnDragDrop           := Src.OnDragDrop          ;
  Dst.OnDragOver           := Src.OnDragOver          ;
  Dst.OnEndDrag            := Src.OnEndDrag           ;
  Dst.OnEnter              := Src.OnEnter             ;
  Dst.OnExit               := Src.OnExit              ;
  Dst.OnKeyDown            := Src.OnKeyDown           ;
  Dst.OnKeyPress           := Src.OnKeyPress          ;
  Dst.OnKeyUp              := Src.OnKeyUp             ;
  Dst.OnMouseDown          := Src.OnMouseDown         ;
  Dst.OnMouseMove          := Src.OnMouseMove         ;
  Dst.OnMouseUp            := Src.OnMouseUp           ;
end;

//----------------------------------------------------------------------------//
//  THEdit
//----------------------------------------------------------------------------//
procedure CopyHEditProperty(Dst: THEdit; Src: THEdit);
begin
  // �v���p�e�B
  Dst.ActBgColor       := Src.ActBgColor      ;
  Dst.ActFgColor       := Src.ActFgColor      ;
  Dst.AutoSelect       := Src.AutoSelect      ;
  Dst.AlignWithMargins := Src.AlignWithMargins;  // *
  Dst.AutoSelect       := Src.AutoSelect      ;  // *
  Dst.AutoSize         := Src.AutoSize        ;
  Dst.BorderStyle      := Src.BorderStyle     ;
  Dst.CharCase         := Src.CharCase        ;
  Dst.CheckEmpty       := Src.CheckEmpty      ;  // *
  Dst.Color            := Src.Color           ;
  Dst.Ctl3D            := Src.Ctl3D           ;
  Dst.Cursor           := Src.Cursor          ;
  Dst.CustomHint       := Src.CustomHint      ;  // *
  Dst.DragCursor       := Src.DragCursor      ;
  Dst.DragMode         := Src.DragMode        ;
  Dst.Enabled          := Src.Enabled         ;
  Dst.ExtCase          := Src.ExtCase         ;
  Dst.ExtEdit          := Src.ExtEdit         ;
  Dst.Font             := Src.Font            ;
  Dst.Height           := Src.Height          ;
  Dst.HelpContext      := Src.HelpContext     ;
  Dst.HelpKeyword      := Src.HelpKeyword     ;  // *
  Dst.HelpType         := Src.HelpType        ;  // *
  Dst.HideSelection    := Src.HideSelection   ;
  Dst.Hint             := Src.Hint            ;
  Dst.ImeMode          := Src.ImeMode         ;
  Dst.Left             := Src.Left            ;
  Dst.Margins          := Src.Margins         ;  // *
  Dst.OEMConvert       := Src.OEMConvert      ;
  Dst.ParentColor      := Src.ParentColor     ;
  Dst.ParentCtl3D      := Src.ParentCtl3D     ;
  Dst.ParentCustomHint := Src.ParentCustomHint;  // *
  Dst.ParentFont       := Src.ParentFont      ;
  Dst.ParentShowHint   := Src.ParentShowHint  ;
  Dst.PasswordChar     := Src.PasswordChar    ;
  Dst.PopupMenu        := Src.PopupMenu       ;
  Dst.ReadOnly         := Src.ReadOnly        ;
  Dst.ShowHint         := Src.ShowHint        ;
  Dst.TabStop          := Src.TabStop         ;
  Dst.Tag              := Src.Tag             ;
  Dst.Top              := Src.Top             ;
  Dst.Visible          := Src.Visible         ;
  Dst.Width            := Src.Width           ;

  // �C�x���g
  Dst.Onchange         := Src.Onchange        ;
  Dst.Onclick          := Src.Onclick         ;
  Dst.OnDblClick       := Src.OnDblClick      ;
  Dst.OnDragDrop       := Src.OnDragDrop      ;
  Dst.OnDragOver       := Src.OnDragOver      ;
  Dst.OnEndDrag        := Src.OnEndDrag       ;
  Dst.OnEnter          := Src.OnEnter         ;
  Dst.OnExit           := Src.OnExit          ;
  Dst.OnKeyDown        := Src.OnKeyDown       ;
  Dst.OnKeyPress       := Src.OnKeyPress      ;
  Dst.OnKeyUp          := Src.OnKeyUp         ;
  Dst.OnMouseDown      := Src.OnMouseDown     ;
  Dst.OnMouseMove      := Src.OnMouseMove     ;
  Dst.OnMouseUp        := Src.OnMouseUp       ;
end;

//----------------------------------------------------------------------------//
//  TBitBtn
//----------------------------------------------------------------------------//
procedure CopyBitBtnProperty(Dst: TBitBtn; Src: TBitBtn);
begin
  // �v���p�e�B
  Dst.Action               := Src.Action              ;  // *
  Dst.Align                := Src.Align               ;  // *
  Dst.AlignWithMargins     := Src.AlignWithMargins    ;  // *
  Dst.Anchors              := Src.Anchors             ;  // *
  Dst.BiDiMode             := Src.BiDiMode            ;  // *
  Dst.Cancel               := Src.Cancel              ;
  Dst.Caption              := Src.Caption             ;
  Dst.Constraints          := Src.Constraints         ;  // *
  Dst.Cursor               := Src.Cursor              ;
  Dst.CustomHint           := Src.CustomHint          ;  // *
  Dst.Default              := Src.Default             ;
  Dst.DoubleBuffered       := Src.DoubleBuffered      ;  // *
  Dst.DragCursor           := Src.DragCursor          ;
  Dst.DragKind             := Src.DragKind            ;  // *
  Dst.DragMode             := Src.DragMode            ;
  Dst.Enabled              := Src.Enabled             ;
  Dst.Font                 := Src.Font                ;
  Dst.Glyph                := Src.Glyph               ;
  Dst.Height               := Src.Height              ;
  Dst.HelpContext          := Src.HelpContext         ;
  Dst.HelpKeyword          := Src.HelpKeyword         ;  // *
  Dst.HelpType             := Src.HelpType            ;  // *
  Dst.Hint                 := Src.Hint                ;
  Dst.Kind                 := Src.Kind                ;
  Dst.Layout               := Src.Layout              ;
  Dst.Left                 := Src.Left                ;
  Dst.Margin               := Src.Margin              ;
  Dst.Margins              := Src.Margins             ;  // *
  Dst.ModalResult          := Src.ModalResult         ;
  Dst.NumGlyphs            := Src.NumGlyphs           ;
  Dst.ParentBiDiMode       := Src.ParentBiDiMode      ;  // *
  Dst.ParentCustomHint     := Src.ParentCustomHint    ;  // *
  Dst.ParentDoubleBuffered := Src.ParentDoubleBuffered;  // *
  Dst.ParentFont           := Src.ParentFont          ;
  Dst.ParentShowHint       := Src.ParentShowHint      ;
  Dst.PopupMenu            := Src.PopupMenu           ;
  Dst.ShowHint             := Src.ShowHint            ;
  Dst.Spacing              := Src.Spacing             ;
  Dst.Style                := Src.Style               ;
  Dst.TabStop              := Src.TabStop             ;
  Dst.Tag                  := Src.Tag                 ;
  Dst.Top                  := Src.Top                 ;
  Dst.Visible              := Src.Visible             ;
  Dst.Width                := Src.Width               ;
  Dst.WordWrap             := Src.WordWrap            ;  // *

  // �C�x���g
  Dst.OnClick              := Src.OnClick             ;
  Dst.OnContextPopup       := Src.OnContextPopup      ;  // *
  Dst.OnDragDrop           := Src.OnDragDrop          ;
  Dst.OnDragOver           := Src.OnDragOver          ;
  Dst.OnEndDock            := Src.OnEndDock           ;  // *
  Dst.OnEndDrag            := Src.OnEndDrag           ;
  Dst.OnEnter              := Src.OnEnter             ;
  Dst.OnExit               := Src.OnExit              ;
  Dst.OnKeyDown            := Src.OnKeyDown           ;
  Dst.OnKeyPress           := Src.OnKeyPress          ;
  Dst.OnKeyUp              := Src.OnKeyUp             ;
  Dst.OnMouseActivate      := Src.OnMouseActivate     ;
  Dst.OnMouseDown          := Src.OnMouseDown         ;
  Dst.OnMouseEnter         := Src.OnMouseEnter        ;  // *
  Dst.OnMouseLeave         := Src.OnMouseLeave        ;  // *
  Dst.OnMouseMove          := Src.OnMouseMove         ;
  Dst.OnMouseUp            := Src.OnMouseUp           ;
  Dst.OnStartDock          := Src.OnStartDock         ;  // *
  Dst.OnStartDrag          := Src.OnStartDrag         ;  // *
end;

//----------------------------------------------------------------------------//
//  TMaskEdit
//----------------------------------------------------------------------------//
procedure CopyMaskEditProperty(Dst: TMaskEdit; Src: TMaskEdit);
begin
  // �v���p�e�B
  Dst.Align                := Src.Align               ;  // *
  Dst.Alignment            := Src.Alignment           ;  // *
  Dst.AlignWithMargins     := Src.AlignWithMargins    ;  // *
  Dst.Anchors              := Src.Anchors             ;  // *
  Dst.AutoSelect           := Src.AutoSelect          ;
  Dst.AutoSize             := Src.AutoSize            ;
  Dst.BevelEdges           := Src.BevelEdges          ;  // *
  Dst.BevelInner           := Src.BevelInner          ;  // *
  Dst.BevelKind            := Src.BevelKind           ;  // *
  Dst.BevelOuter           := Src.BevelOuter          ;  // *
  Dst.BevelWidth           := Src.BevelWidth          ;  // *
  Dst.BiDiMode             := Src.BiDiMode            ;  // *
  Dst.BorderStyle          := Src.BorderStyle         ;
  Dst.CharCase             := Src.CharCase            ;
  Dst.Color                := Src.Color               ;
  Dst.Constraints          := Src.Constraints         ;  // *
  Dst.Ctl3D                := Src.Ctl3D               ;
  Dst.Cursor               := Src.Cursor              ;
  Dst.CustomHint           := Src.CustomHint          ;  // *
  Dst.DoubleBuffered       := Src.DoubleBuffered      ;  // *
  Dst.DragCursor           := Src.DragCursor          ;
  Dst.DragKind             := Src.DragKind            ;  // *
  Dst.DragMode             := Src.DragMode            ;
  Dst.EditMask             := Src.EditMask            ;
  Dst.Enabled              := Src.Enabled             ;
  Dst.Font                 := Src.Font                ;
  Dst.Height               := Src.Height              ;
  Dst.HelpContext          := Src.HelpContext         ;
  Dst.HelpKeyword          := Src.HelpKeyword         ;  // *
  Dst.HelpType             := Src.HelpType            ;  // *
  Dst.Hint                 := Src.Hint                ;
  Dst.ImeMode              := Src.ImeMode             ;
  Dst.ImeName              := Src.ImeName             ;  // *
  Dst.Left                 := Src.Left                ;
  Dst.Margins              := Src.Margins             ;  // *
  Dst.MaxLength            := Src.MaxLength           ;
  Dst.ParentBiDiMode       := Src.ParentBiDiMode      ;  // *
  Dst.ParentColor          := Src.ParentColor         ;
  Dst.ParentCtl3D          := Src.ParentCtl3D         ;
  Dst.ParentCustomHint     := Src.ParentCustomHint    ;  // *
  Dst.ParentDoubleBuffered := Src.ParentDoubleBuffered;  // *
  Dst.ParentFont           := Src.ParentFont          ;
  Dst.ParentShowHint       := Src.ParentShowHint      ;
  Dst.PasswordChar         := Src.PasswordChar        ;
  Dst.PopupMenu            := Src.PopupMenu           ;
  Dst.ReadOnly             := Src.ReadOnly            ;
  Dst.ShowHint             := Src.ShowHint            ;
  Dst.TabStop              := Src.TabStop             ;
  Dst.Tag                  := Src.Tag                 ;
  Dst.TextHint             := Src.TextHint            ;  // *
  Dst.Top                  := Src.Top;                ;
  Dst.Touch                := Src.Touch               ;  // *
  Dst.Visible              := Src.Visible;            ;
  Dst.Width                := Src.Width;              ;

  // �C�x���g
  Dst.OnChange        := Src.OnChange       ;
  Dst.OnClick         := Src.OnClick        ;
  Dst.OnDblClick      := Src.OnDblClick     ;
  Dst.OnDragDrop      := Src.OnDragDrop     ;
  Dst.OnDragOver      := Src.OnDragOver     ;
  Dst.OnEndDock       := Src.OnEndDock      ;  // *
  Dst.OnEndDrag       := Src.OnEndDrag      ;
  Dst.OnEnter         := Src.OnEnter        ;
  Dst.OnExit          := Src.OnExit         ;
  Dst.OnGesture       := Src.OnGesture      ;  // *
  Dst.OnKeyDown       := Src.OnKeyDown      ;
  Dst.OnKeyPress      := Src.OnKeyPress     ;
  Dst.OnKeyUp         := Src.OnKeyUp        ;
  Dst.OnMouseActivate := Src.OnMouseActivate;  // *
  Dst.OnMouseDown     := Src.OnMouseDown    ;
  Dst.OnMouseEnter    := Src.OnMouseEnter   ;  // *
  Dst.OnMouseLeave    := Src.OnMouseLeave   ;  // *
  Dst.OnMouseMove     := Src.OnMouseMove    ;
  Dst.OnMouseUp       := Src.OnMouseUp      ;
  Dst.OnStartDock     := Src.OnStartDock    ;  // *
  Dst.OnStartDrag     := Src.OnStartDrag    ;  // *
end;

//----------------------------------------------------------------------------//
//  TImage
//----------------------------------------------------------------------------//
procedure CopyImageProperty(Dst: TImage; Src: TImage);
begin
  // �v���p�e�B
  Dst.Align              := Src.Align             ;
  Dst.AlignWithMargins   := Src.AlignWithMargins  ;  // *
  Dst.Anchors            := Src.Anchors           ;  // *
  Dst.AutoSize           := Src.AutoSize          ;
  Dst.Center             := Src.Center            ;
  Dst.Constraints        := Src.Constraints       ;  // *
  Dst.Cursor             := Src.Cursor            ;
  Dst.CustomHint         := Src.CustomHint        ;  // *
  Dst.DragCursor         := Src.DragCursor        ;
  Dst.DragKind           := Src.DragKind          ;  // *
  Dst.DragMode           := Src.DragMode          ;
  Dst.Enabled            := Src.Enabled           ;
  Dst.Height             := Src.Height            ;
  Dst.HelpContext        := Src.HelpContext       ;  // *
  Dst.HelpKeyword        := Src.HelpKeyword       ;  // *
  Dst.HelpType           := Src.HelpType          ;  // *
  Dst.Hint               := Src.Hint              ;
  Dst.IncrementalDisplay := Src.IncrementalDisplay;  // *
  Dst.Left               := Src.Left              ;
  Dst.Margins            := Src.Margins           ;  // *
  Dst.ParentCustomHint   := Src.ParentCustomHint  ;  // *
  Dst.ParentShowHint     := Src.ParentShowHint    ;
  Dst.Picture            := Src.Picture           ;
  Dst.PopupMenu          := Src.PopupMenu         ;
  Dst.Proportional       := Src.Proportional      ;  // *
  Dst.ShowHint           := Src.ShowHint          ;
  Dst.Stretch            := Src.Stretch           ;
  Dst.Tag                := Src.Tag               ;
  Dst.Top                := Src.Top               ;
  Dst.Touch              := Src.Touch             ;  // *
  Dst.Transparent        := Src.Transparent       ;  // *
  Dst.Visible            := Src.Visible           ;
  Dst.Width              := Src.Width             ;

  // �C�x���g
  Dst.OnClick         := Src.OnClick              ;
  Dst.OnContextPopup  := Src.OnContextPopup       ;  // *
  Dst.OnDblClick      := Src.OnDblClick           ;
  Dst.OnDragDrop      := Src.OnDragDrop           ;
  Dst.OnDragOver      := Src.OnDragOver           ;
  Dst.OnEndDock       := Src.OnEndDock            ;  // *
  Dst.OnEndDrag       := Src.OnEndDrag            ;  // *
  Dst.OnGesture       := Src.OnGesture            ;  // *
  Dst.OnMouseActivate := Src.OnMouseActivate      ;  // *
  Dst.OnMouseDown     := Src.OnMouseDown          ;
  Dst.OnMouseEnter    := Src.OnMouseEnter         ;  // *
  Dst.OnMouseLeave    := Src.OnMouseLeave         ;  // *
  Dst.OnMouseMove     := Src.OnMouseMove          ;
  Dst.OnMouseUp       := Src.OnMouseUp            ;
  Dst.OnProgress      := Src.OnProgress           ;  // *
  Dst.OnStartDock     := Src.OnStartDock          ;  // *
  Dst.OnStartDrag     := Src.OnStartDrag          ;  // *
end;

//----------------------------------------------------------------------------//
//  TShape
//----------------------------------------------------------------------------//
procedure CopyShapeProperty(Dst: TShape; Src: TShape);
begin
  // �v���p�e�B
  Dst.Align            := Src.Align           ;  // *
  Dst.AlignWithMargins := Src.AlignWithMargins;  // *
  Dst.Anchors          := Src.Anchors         ;  // *
  Dst.Brush            := Src.Brush           ;
  Dst.Constraints      := Src.Constraints     ;  // *
  Dst.Cursor           := Src.Cursor          ;
  Dst.CustomHint       := Src.CustomHint      ;  // *
  Dst.DragCursor       := Src.DragCursor      ;
  Dst.DragKind         := Src.DragKind        ;  // *
  Dst.DragMode         := Src.DragMode        ;
  Dst.Enabled          := Src.Enabled         ;
  Dst.Height           := Src.Height          ;
  Dst.HelpContext      := Src.HelpContext     ;  // *
  Dst.HelpKeyword      := Src.HelpKeyword     ;  // *
  Dst.HelpType         := Src.HelpType        ;  // *
  Dst.Hint             := Src.Hint            ;
  Dst.Left             := Src.Left            ;
  Dst.Margins          := Src.Margins         ;  // *
  Dst.ParentCustomHint := Src.ParentCustomHint;  // *
  Dst.ParentShowHint   := Src.ParentShowHint  ;
  Dst.Pen              := Src.Pen             ;
  Dst.Shape            := Src.Shape           ;
  Dst.ShowHint         := Src.ShowHint        ;
  Dst.Tag              := Src.Tag             ;
  Dst.Top              := Src.Top             ;
  Dst.Touch            := Src.Touch           ;  // *
  Dst.Visible          := Src.Visible         ;
  Dst.Width            := Src.Width           ;

  // �C�x���g
  Dst.OnContextPopup  := Src.OnContextPopup   ;  // *
  Dst.OnDragDrop      := Src.OnDragDrop       ;
  Dst.OnDragOver      := Src.OnDragOver       ;
  Dst.OnEndDock       := Src.OnEndDock        ;  // *
  Dst.OnEndDrag       := Src.OnEndDrag        ;
  Dst.OnGesture       := Src.OnGesture        ;  // *
  Dst.OnMouseActivate := Src.OnMouseActivate  ;  // *
  Dst.OnMouseDown     := Src.OnMouseDown      ;
  Dst.OnMouseEnter    := Src.OnMouseEnter     ;  // *
  Dst.OnMouseLeave    := Src.OnMouseLeave     ;  // *
  Dst.OnMouseMove     := Src.OnMouseMove      ;
  Dst.OnMouseUp       := Src.OnMouseUp        ;
  Dst.OnStartDock     := Src.OnStartDock      ;  // *
  Dst.OnStartDrag     := Src.OnStartDrag      ;  // *
end;

//----------------------------------------------------------------------------//
//  TBevel
//----------------------------------------------------------------------------//
procedure CopyBevelProperty(Dst: TBevel; Src: TBevel);
begin
  // �v���p�e�B
  Dst.Align            := Src.Align           ;
  Dst.AlignWithMargins := Src.AlignWithMargins;  // *
  Dst.Anchors          := Src.Anchors         ;  // *
  Dst.Constraints      := Src.Constraints     ;  // *
  Dst.Cursor           := Src.Cursor          ;
  Dst.CustomHint       := Src.CustomHint      ;  // *
  Dst.Height           := Src.Height          ;
  Dst.HelpContext      := Src.HelpContext     ;  // *
  Dst.HelpKeyword      := Src.HelpKeyword     ;  // *
  Dst.HelpType         := Src.HelpType        ;  // *
  Dst.Hint             := Src.Hint            ;
  Dst.Left             := Src.Left            ;
  Dst.Margins          := Src.Margins         ;  // *
  Dst.ParentCustomHint := Src.ParentCustomHint;  // *
  Dst.ParentShowHint   := Src.ParentShowHint  ;
  Dst.Shape            := Src.Shape           ;
  Dst.ShowHint         := Src.ShowHint        ;
  Dst.Style            := Src.Style           ;
  Dst.Tag              := Src.Tag             ;
  Dst.Top              := Src.Top             ;
  Dst.Touch            := Src.Touch           ;  // *
  Dst.Visible          := Src.Visible         ;
  Dst.Width            := Src.Width           ;

  // �C�x���g
  Dst.OnGesture        := Src.OnGesture       ;  // *
end;

//----------------------------------------------------------------------------//
//  TLabel
//----------------------------------------------------------------------------//
procedure CopyLabelProperty(Dst: TLabel; Src: TLabel);
begin
  // �v���p�e�B
  Dst.Align            := Src.Align           ;
  Dst.Alignment        := Src.Alignment       ;
  Dst.AlignWithMargins := Src.AlignWithMargins;  // *
  Dst.Anchors          := Src.Anchors         ;  // *
  Dst.AutoSize         := Src.AutoSize        ;
  Dst.BiDiMode         := Src.BiDiMode        ;  // *
  //Dst.Caption          := Src.Caption         ;
  Dst.Color            := Src.Color           ;
  Dst.Constraints      := Src.Constraints     ;  // *
  Dst.Cursor           := Src.Cursor          ;
  Dst.CustomHint       := Src.CustomHint      ;  // *
  Dst.DragCursor       := Src.DragCursor      ;
  Dst.DragKind         := Src.DragKind        ;  // *
  Dst.DragMode         := Src.DragMode        ;
  Dst.EllipsisPosition := Src.EllipsisPosition;  // *
  Dst.Enabled          := Src.Enabled         ;
  Dst.FocusControl     := Src.FocusControl    ;
  Dst.Font             := Src.Font            ;
  Dst.GlowSize         := Src.GlowSize        ;  // *
  Dst.Height           := Src.Height          ;
  Dst.HelpContext      := Src.HelpContext     ;  // *
  Dst.HelpKeyword      := Src.HelpKeyword     ;  // *
  Dst.HelpType         := Src.HelpType        ;  // *
  Dst.Hint             := Src.Hint            ;
  Dst.Layout           := Src.Layout          ;  // *
  Dst.Left             := Src.Left            ;
  Dst.Margins          := Src.Margins         ;  // *
  Dst.ParentBiDiMode   := Src.ParentBiDiMode  ;  // *
  Dst.ParentColor      := Src.ParentColor     ;
  Dst.ParentCustomHint := Src.ParentCustomHint;  // *
  Dst.ParentFont       := Src.ParentFont      ;
  Dst.ParentShowHint   := Src.ParentShowHint  ;
  Dst.PopupMenu        := Src.PopupMenu       ;
  Dst.ShowAccelChar    := Src.ShowAccelChar   ;
  Dst.ShowHint         := Src.ShowHint        ;
  Dst.Tag              := Src.Tag             ;
  Dst.Top              := Src.Top             ;
  Dst.Touch            := Src.Touch           ;  // *
  Dst.Transparent      := Src.Transparent     ;
  Dst.Visible          := Src.Visible         ;
  Dst.Width            := Src.Width           ;
  Dst.WordWrap         := Src.WordWrap        ;

  // �C�x���g
  Dst.OnClick          := Src.OnClick         ;
  Dst.OnContextPopup   := Src.OnContextPopup  ;  // *
  Dst.OnDblClick       := Src.OnDblClick      ;
  Dst.OnDragDrop       := Src.OnDragDrop      ;
  Dst.OnDragOver       := Src.OnDragOver      ;
  Dst.OnEndDock        := Src.OnEndDock       ;  // *
  Dst.OnEndDrag        := Src.OnEndDrag       ;
  Dst.OnGesture        := Src.OnGesture       ;  // *
  Dst.OnMouseActivate  := Src.OnMouseActivate ;  // *
  Dst.OnMouseDown      := Src.OnMouseDown     ;
  Dst.OnMouseEnter     := Src.OnMouseEnter    ;  // *
  Dst.OnMouseLeave     := Src.OnMouseLeave    ;  // *
  Dst.OnMouseMove      := Src.OnMouseMove     ;
  Dst.OnMouseUp        := Src.OnMouseUp       ;
  Dst.OnStartDock      := Src.OnStartDock     ;  // *
  Dst.OnStartDrag      := Src.OnStartDrag     ;  // *
end;

//----------------------------------------------------------------------------//
//  TEdit
//----------------------------------------------------------------------------//
procedure CopyEditProperty(Dst: TEdit; Src: TEdit);
begin
  // �v���p�e�B
  Dst.Align                := Src.Align               ;  // *
  Dst.Alignment            := Src.Alignment           ;  // *
  Dst.AlignWithMargins     := Src.AlignWithMargins    ;  // *
  Dst.Anchors              := Src.Anchors             ;  // *
  Dst.AutoSelect           := Src.AutoSelect          ;
  Dst.AutoSize             := Src.AutoSize            ;
  Dst.BevelEdges           := Src.BevelEdges          ;  // *
  Dst.BevelInner           := Src.BevelInner          ;  // *
  Dst.BevelKind            := Src.BevelKind           ;  // *
  Dst.BevelOuter           := Src.BevelOuter          ;  // *
  Dst.BevelWidth           := Src.BevelWidth          ;  // *
  Dst.BiDiMode             := Src.BiDiMode            ;  // *
  Dst.BorderStyle          := Src.BorderStyle         ;
  Dst.CharCase             := Src.CharCase            ;
  Dst.Color                := Src.Color               ;
  Dst.Constraints          := Src.Constraints         ;  // *
  Dst.Ctl3D                := Src.Ctl3D               ;
  Dst.Cursor               := Src.Cursor              ;
  Dst.CustomHint           := Src.CustomHint          ;  // *
  Dst.DoubleBuffered       := Src.DoubleBuffered      ;  // *
  Dst.DragCursor           := Src.DragCursor          ;
  Dst.DragKind             := Src.DragKind            ;  // *
  Dst.DragMode             := Src.DragMode            ;
  Dst.Enabled              := Src.Enabled             ;
  Dst.Font                 := Src.Font                ;
  Dst.Height               := Src.Height              ;
  Dst.HelpContext          := Src.HelpContext         ;
  Dst.HelpKeyword          := Src.HelpKeyword         ;  // *
  Dst.HelpType             := Src.HelpType            ;  // *
  Dst.HideSelection        := Src.HideSelection       ;
  Dst.Hint                 := Src.Hint                ;
  Dst.ImeMode              := Src.ImeMode             ;
  Dst.ImeName              := Src.ImeName             ;  // *
  Dst.Left                 := Src.Left                ;
  Dst.Margins              := Src.Margins             ;  // *
  Dst.MaxLength            := Src.MaxLength           ;
  Dst.NumbersOnly          := Src.NumbersOnly         ;  // *
  Dst.OEMConvert           := Src.OEMConvert          ;
  Dst.ParentBiDiMode       := Src.ParentBiDiMode      ;  // *
  Dst.ParentColor          := Src.ParentColor         ;
  Dst.ParentCtl3D          := Src.ParentCtl3D         ;
  Dst.ParentCustomHint     := Src.ParentCustomHint    ;  // *
  Dst.ParentDoubleBuffered := Src.ParentDoubleBuffered;  // *
  Dst.ParentFont           := Src.ParentFont          ;
  Dst.ParentShowHint       := Src.ParentShowHint      ;
  Dst.PasswordChar         := Src.PasswordChar        ;
  Dst.PopupMenu            := Src.PopupMenu           ;
  Dst.ReadOnly             := Src.ReadOnly            ;
  Dst.ShowHint             := Src.ShowHint            ;
  Dst.TabStop              := Src.TabStop             ;
  Dst.Tag                  := Src.Tag                 ;
  //Dst.Text                 := Src.Text                ;
  Dst.TextHint             := Src.TextHint            ;  // *
  Dst.Top                  := Src.Top                 ;
  Dst.Touch                := Src.Touch               ;  // *
  Dst.Visible              := Src.Visible             ;
  Dst.Width                := Src.Width               ;

  // �C�x���g
  Dst.OnChange             := Src.OnChange            ;
  Dst.OnClick              := Src.OnClick             ;
  Dst.OnContextPopup       := Src.OnContextPopup      ;  // *
  Dst.OnDblClick           := Src.OnDblClick          ;
  Dst.OnDragDrop           := Src.OnDragDrop          ;
  Dst.OnDragOver           := Src.OnDragOver          ;
  Dst.OnEndDock            := Src.OnEndDock           ;  // *
  Dst.OnEndDrag            := Src.OnEndDrag           ;
  Dst.OnEnter              := Src.OnEnter             ;
  Dst.OnExit               := Src.OnExit              ;
  Dst.OnGesture            := Src.OnGesture           ;  // *
  Dst.OnKeyDown            := Src.OnKeyDown           ;
  Dst.OnKeyPress           := Src.OnKeyPress          ;
  Dst.OnKeyUp              := Src.OnKeyUp             ;
  Dst.OnMouseActivate      := Src.OnMouseActivate     ;  // *
  Dst.OnMouseDown          := Src.OnMouseDown         ;
  Dst.OnMouseEnter         := Src.OnMouseEnter        ;  // *
  Dst.OnMouseLeave         := Src.OnMouseLeave        ;  // *
  Dst.OnMouseMove          := Src.OnMouseMove         ;
  Dst.OnMouseUp            := Src.OnMouseUp           ;
  Dst.OnStartDock          := Src.OnStartDock         ;  // *
  Dst.OnStartDrag          := Src.OnStartDrag         ;  // *
end;

//----------------------------------------------------------------------------//
//  TButton
//----------------------------------------------------------------------------//
procedure CopyButtonProperty(Dst: TButton; Src: TButton);
begin
  // �v���p�e�B
  Dst.Action               := Src.Action              ;  // *
  Dst.Align                := Src.Align               ;  // *
  Dst.AlignWithMargins     := Src.AlignWithMargins    ;  // *
  Dst.Anchors              := Src.Anchors             ;  // *
  Dst.BiDiMode             := Src.BiDiMode            ;  // *
  Dst.Cancel               := Src.Cancel              ;
  Dst.Caption              := Src.Caption             ;
  Dst.CommandLinkHint      := Src.CommandLinkHint     ;  // *
  Dst.Constraints          := Src.Constraints         ;  // *
  Dst.Cursor               := Src.Cursor              ;
  Dst.CustomHint           := Src.CustomHint          ;  // *
  Dst.Default              := Src.Default             ;
  Dst.DisabledImageIndex   := Src.DisabledImageIndex  ;  // *
  Dst.DoubleBuffered       := Src.DoubleBuffered      ;  // *
  Dst.DragCursor           := Src.DragCursor          ;
  Dst.DragKind             := Src.DragKind            ;  // *
  Dst.DragMode             := Src.DragMode            ;
  Dst.DropDownMenu         := Src.DropDownMenu        ;  // *
  Dst.ElevationRequired    := Src.ElevationRequired   ;  // *
  Dst.Enabled              := Src.Enabled             ;
  Dst.Font                 := Src.Font                ;
  Dst.Height               := Src.Height              ;
  Dst.HelpContext          := Src.HelpContext         ;
  Dst.HelpKeyword          := Src.HelpKeyword         ;  // *
  Dst.HelpType             := Src.HelpType            ;  // *
  Dst.Hint                 := Src.Hint                ;
  Dst.HotImageIndex        := Src.HotImageIndex       ;  // *
  Dst.ImageAlignment       := Src.ImageAlignment      ;  // *
  Dst.ImageIndex           := Src.ImageIndex          ;  // *
  Dst.ImageMargins         := Src.ImageMargins        ;  // *
  Dst.Images               := Src.Images              ;  // *
  Dst.Left                 := Src.Left                ;
  Dst.Margins              := Src.Margins             ;  // *
  Dst.ModalResult          := Src.ModalResult         ;
  Dst.ParentBiDiMode       := Src.ParentBiDiMode      ;  // *
  Dst.ParentCustomHint     := Src.ParentCustomHint    ;  // *
  Dst.ParentDoubleBuffered := Src.ParentDoubleBuffered;  // *
  Dst.ParentFont           := Src.ParentFont          ;
  Dst.ParentShowHint       := Src.ParentShowHint      ;
  Dst.PopupMenu            := Src.PopupMenu           ;
  Dst.PressedImageIndex    := Src.PressedImageIndex   ;  // *
  Dst.SelectedImageIndex   := Src.SelectedImageIndex  ;  // *
  Dst.ShowHint             := Src.ShowHint            ;
  Dst.Style                := Src.Style               ;  // *
  Dst.TabStop              := Src.TabStop             ;
  Dst.Tag                  := Src.Tag                 ;
  Dst.Top                  := Src.Top                 ;
  Dst.Visible              := Src.Visible             ;
  Dst.Width                := Src.Width               ;
  Dst.WordWrap             := Src.WordWrap            ;  // *

  // �C�x���g
  Dst.OnClick              := Src.OnClick             ;
  Dst.OnContextPopup       := Src.OnContextPopup      ;  // *
  Dst.OnDragDrop           := Src.OnDragDrop          ;
  Dst.OnDragOver           := Src.OnDragOver          ;
  Dst.OnDropDownClick      := Src.OnDropDownClick     ;  // *
  Dst.OnEndDock            := Src.OnEndDock           ;  // *
  Dst.OnEndDrag            := Src.OnEndDrag           ;
  Dst.OnEnter              := Src.OnEnter             ;
  Dst.OnExit               := Src.OnExit              ;
  Dst.OnKeyDown            := Src.OnKeyDown           ;
  Dst.OnKeyPress           := Src.OnKeyPress          ;
  Dst.OnKeyUp              := Src.OnKeyUp             ;
  Dst.OnMouseActivate      := Src.OnMouseActivate     ;  // *
  Dst.OnMouseDown          := Src.OnMouseDown         ;
  Dst.OnMouseEnter         := Src.OnMouseEnter        ;  // *
  Dst.OnMouseLeave         := Src.OnMouseLeave        ;  // *
  Dst.OnMouseMove          := Src.OnMouseMove         ;
  Dst.OnMouseUp            := Src.OnMouseUp           ;
  Dst.OnStartDock          := Src.OnStartDock         ;  // *
  Dst.OnStartDrag          := Src.OnStartDrag         ;  // *
end;

//----------------------------------------------------------------------------//
//  TCheckBox
//----------------------------------------------------------------------------//
procedure CopyCheckBoxProperty(Dst: TCheckBox; Src: TCheckBox);
begin
  // �v���p�e�B
  Dst.Action               := Src.Action              ;  // *
  Dst.Align                := Src.Align               ;  // *
  Dst.Alignment            := Src.Alignment           ;
  Dst.AlignWithMargins     := Src.AlignWithMargins    ;  // *
  Dst.AllowGrayed          := Src.AllowGrayed         ;
  Dst.Anchors              := Src.Anchors             ;  // *
  Dst.BiDiMode             := Src.BiDiMode            ;  // *
  Dst.Caption              := Src.Caption             ;
  Dst.Checked              := Src.Checked             ;
  Dst.Color                := Src.Color               ;
  Dst.Constraints          := Src.Constraints         ;  // *
  Dst.Ctl3D                := Src.Ctl3D               ;
  Dst.Cursor               := Src.Cursor              ;
  Dst.CustomHint           := Src.CustomHint          ;  // *
  Dst.DoubleBuffered       := Src.DoubleBuffered      ;  // *
  Dst.DragCursor           := Src.DragCursor          ;
  Dst.DragKind             := Src.DragKind            ;  // *
  Dst.DragMode             := Src.DragMode            ;
  Dst.Enabled              := Src.Enabled             ;
  Dst.Font                 := Src.Font                ;
  Dst.Height               := Src.Height              ;
  Dst.HelpContext          := Src.HelpContext         ;
  Dst.HelpKeyword          := Src.HelpKeyword         ;  // *
  Dst.HelpType             := Src.HelpType            ;  // *
  Dst.Hint                 := Src.Hint                ;
  Dst.Left                 := Src.Left                ;
  Dst.Margins              := Src.Margins             ;  // *
  Dst.ParentBiDiMode       := Src.ParentBiDiMode      ;  // *
  Dst.ParentColor          := Src.ParentColor         ;
  Dst.ParentCtl3D          := Src.ParentCtl3D         ;
  Dst.ParentCustomHint     := Src.ParentCustomHint    ;  // *
  Dst.ParentDoubleBuffered := Src.ParentDoubleBuffered;  // *
  Dst.ParentFont           := Src.ParentFont          ;
  Dst.ParentShowHint       := Src.ParentShowHint      ;
  Dst.PopupMenu            := Src.PopupMenu           ;
  Dst.ShowHint             := Src.ShowHint            ;
  Dst.State                := Src.State               ;
  Dst.TabStop              := Src.TabStop             ;
  Dst.Tag                  := Src.Tag                 ;
  Dst.Top                  := Src.Top                 ;
  Dst.Visible              := Src.Visible             ;
  Dst.Width                := Src.Width               ;
  Dst.WordWrap             := Src.WordWrap            ;  // *

  // �C�x���g
  Dst.OnClick              := Src.OnClick             ;
  Dst.OnContextPopup       := Src.OnContextPopup      ;  // *
  Dst.OnDragDrop           := Src.OnDragDrop          ;
  Dst.OnDragOver           := Src.OnDragOver          ;
  Dst.OnEndDock            := Src.OnEndDock           ;  // *
  Dst.OnEndDrag            := Src.OnEndDrag           ;
  Dst.OnEnter              := Src.OnEnter             ;
  Dst.OnExit               := Src.OnExit              ;
  Dst.OnKeyDown            := Src.OnKeyDown           ;
  Dst.OnKeyPress           := Src.OnKeyPress          ;
  Dst.OnKeyUp              := Src.OnKeyUp             ;
  Dst.OnMouseActivate      := Src.OnMouseActivate     ;  // *
  Dst.OnMouseDown          := Src.OnMouseDown         ;
  Dst.OnMouseEnter         := Src.OnMouseEnter        ;  // *
  Dst.OnMouseLeave         := Src.OnMouseLeave        ;  // *
  Dst.OnMouseMove          := Src.OnMouseMove         ;
  Dst.OnMouseUp            := Src.OnMouseUp           ;
  Dst.OnStartDock          := Src.OnStartDock         ;  // *
  Dst.OnStartDrag          := Src.OnStartDrag         ;  // *
end;

//----------------------------------------------------------------------------//
//  TRadioButton
//----------------------------------------------------------------------------//
procedure CopyRadioButtonProperty(Dst: TRadioButton; Src: TRadioButton);
begin
  // �v���p�e�B
  Dst.Action               := Src.Action              ;  // *
  Dst.Align                := Src.Align               ;  // *
  Dst.Alignment            := Src.Alignment           ;
  Dst.AlignWithMargins     := Src.AlignWithMargins    ;  // *
  Dst.Anchors              := Src.Anchors             ;  // *
  Dst.BiDiMode             := Src.BiDiMode            ;  // *
  Dst.Caption              := Src.Caption             ;
  Dst.Checked              := Src.Checked             ;
  Dst.Color                := Src.Color               ;
  Dst.Constraints          := Src.Constraints         ;  // *
  Dst.Ctl3D                := Src.Ctl3D               ;
  Dst.Cursor               := Src.Cursor              ;
  Dst.CustomHint           := Src.CustomHint          ;  // *
  Dst.DoubleBuffered       := Src.DoubleBuffered      ;  // *
  Dst.DragCursor           := Src.DragCursor          ;
  Dst.DragKind             := Src.DragKind            ;  // *
  Dst.DragMode             := Src.DragMode            ;
  Dst.Enabled              := Src.Enabled             ;
  Dst.Font                 := Src.Font                ;
  Dst.Height               := Src.Height              ;
  Dst.HelpContext          := Src.HelpContext         ;
  Dst.HelpKeyword          := Src.HelpKeyword         ;  // *
  Dst.HelpType             := Src.HelpType            ;  // *
  Dst.Hint                 := Src.Hint                ;
  Dst.Left                 := Src.Left                ;
  Dst.Margins              := Src.Margins             ;  // *
  Dst.ParentBiDiMode       := Src.ParentBiDiMode      ;  // *
  Dst.ParentColor          := Src.ParentColor         ;
  Dst.ParentCtl3D          := Src.ParentCtl3D         ;
  Dst.ParentCustomHint     := Src.ParentCustomHint    ;  // *
  Dst.ParentDoubleBuffered := Src.ParentDoubleBuffered;  // *
  Dst.ParentFont           := Src.ParentFont          ;
  Dst.ParentShowHint       := Src.ParentShowHint      ;
  Dst.PopupMenu            := Src.PopupMenu           ;
  Dst.ShowHint             := Src.ShowHint            ;
  Dst.TabStop              := Src.TabStop             ;
  Dst.Tag                  := Src.Tag                 ;
  Dst.Top                  := Src.Top                 ;
  Dst.Visible              := Src.Visible             ;
  Dst.Width                := Src.Width               ;
  Dst.WordWrap             := Src.WordWrap            ;  // *

  // �C�x���g
  Dst.OnClick              := Src.OnClick             ;
  Dst.OnContextPopup       := Src.OnContextPopup      ;  // *
  Dst.OnDblClick           := Src.OnDblClick          ;
  Dst.OnDragDrop           := Src.OnDragDrop          ;
  Dst.OnDragOver           := Src.OnDragOver          ;
  Dst.OnEndDock            := Src.OnEndDock           ;  // *
  Dst.OnEndDrag            := Src.OnEndDrag           ;
  Dst.OnEnter              := Src.OnEnter             ;
  Dst.OnExit               := Src.OnExit              ;
  Dst.OnKeyDown            := Src.OnKeyDown           ;
  Dst.OnKeyPress           := Src.OnKeyPress          ;
  Dst.OnKeyUp              := Src.OnKeyUp             ;
  Dst.OnMouseActivate      := Src.OnMouseActivate     ;  // *
  Dst.OnMouseDown          := Src.OnMouseDown         ;
  Dst.OnMouseEnter         := Src.OnMouseEnter        ;  // *
  Dst.OnMouseLeave         := Src.OnMouseLeave        ;  // *
  Dst.OnMouseMove          := Src.OnMouseMove         ;
  Dst.OnMouseUp            := Src.OnMouseUp           ;
  Dst.OnStartDock          := Src.OnStartDock         ;  // *
  Dst.OnStartDrag          := Src.OnStartDrag         ;  // *
end;

//----------------------------------------------------------------------------//
//  TComboBox
//----------------------------------------------------------------------------//
procedure CopyComboBoxProperty(Dst: TComboBox; Src: TComboBox);
begin
  // �v���p�e�B
  Dst.Align                := Src.Align               ;  // *
  Dst.AlignWithMargins     := Src.AlignWithMargins    ;  // *
  Dst.Anchors              := Src.Anchors             ;  // *
  Dst.AutoCloseUp          := Src.AutoCloseUp         ;  // *
  Dst.AutoComplete         := Src.AutoComplete        ;  // *
  Dst.AutoCompleteDelay    := Src.AutoCompleteDelay   ;  // *
  Dst.AutoDropDown         := Src.AutoDropDown        ;  // *
  Dst.BevelEdges           := Src.BevelEdges          ;  // *
  Dst.BevelInner           := Src.BevelInner          ;  // *
  Dst.BevelKind            := Src.BevelKind           ;  // *
  Dst.BevelOuter           := Src.BevelOuter          ;  // *
  Dst.BiDiMode             := Src.BiDiMode            ;  // *
  Dst.CharCase             := Src.CharCase            ;  // *
  Dst.Color                := Src.Color               ;
  Dst.Constraints          := Src.Constraints         ;  // *
  Dst.Ctl3D                := Src.Ctl3D               ;
  Dst.Cursor               := Src.Cursor              ;
  Dst.CustomHint           := Src.CustomHint          ;  // *
  Dst.DoubleBuffered       := Src.DoubleBuffered      ;  // *
  Dst.DragCursor           := Src.DragCursor          ;
  Dst.DragKind             := Src.DragKind            ;  // *
  Dst.DragMode             := Src.DragMode            ;
  Dst.DropDownCount        := Src.DropDownCount       ;
  Dst.Enabled              := Src.Enabled             ;
  Dst.Font                 := Src.Font                ;
  Dst.Height               := Src.Height              ;
  Dst.HelpContext          := Src.HelpContext         ;
  Dst.HelpKeyword          := Src.HelpKeyword         ;  // *
  Dst.HelpType             := Src.HelpType            ;  // *
  Dst.Hint                 := Src.Hint                ;
  Dst.ImeMode              := Src.ImeMode             ;
  Dst.ImeName              := Src.ImeName             ;  // *
  Dst.ItemHeight           := Src.ItemHeight          ;
  Dst.ItemIndex            := Src.ItemIndex           ;  // *
  Dst.Items                := Src.Items               ;
  Dst.Left                 := Src.Left                ;
  Dst.Margins              := Src.Margins             ;  // *
  Dst.MaxLength            := Src.MaxLength           ;
  Dst.ParentBiDiMode       := Src.ParentBiDiMode      ;  // *
  Dst.ParentColor          := Src.ParentColor         ;
  Dst.ParentCtl3D          := Src.ParentCtl3D         ;
  Dst.ParentCustomHint     := Src.ParentCustomHint    ;  // *
  Dst.ParentDoubleBuffered := Src.ParentDoubleBuffered;  // *
  Dst.ParentFont           := Src.ParentFont          ;
  Dst.ParentShowHint       := Src.ParentShowHint      ;
  Dst.PopupMenu            := Src.PopupMenu           ;
  Dst.ShowHint             := Src.ShowHint            ;
  Dst.Sorted               := Src.Sorted              ;
  Dst.Style                := Src.Style               ;
  Dst.TabStop              := Src.TabStop             ;
  Dst.Tag                  := Src.Tag                 ;
  Dst.Text                 := Src.Text                ;
  Dst.TextHint             := Src.TextHint            ;  // *
  Dst.Top                  := Src.Top                 ;
  Dst.Touch                := Src.Touch               ;  // *
  Dst.Visible              := Src.Visible             ;
  Dst.Width                := Src.Width               ;

  // �C�x���g
  Dst.OnChange             := Src.OnChange            ;
  Dst.OnClick              := Src.OnClick             ;
  Dst.OnCloseUp            := Src.OnCloseUp           ;  // *
  Dst.OnContextPopup       := Src.OnContextPopup      ;  // *
  Dst.OnDblClick           := Src.OnDblClick          ;
  Dst.OnDragDrop           := Src.OnDragDrop          ;
  Dst.OnDragOver           := Src.OnDragOver          ;
  Dst.OnDrawItem           := Src.OnDrawItem          ;
  Dst.OnDropDown           := Src.OnDropDown          ;
  Dst.OnEndDock            := Src.OnEndDock           ;  // *
  Dst.OnEndDrag            := Src.OnEndDrag           ;
  Dst.OnEnter              := Src.OnEnter             ;
  Dst.OnExit               := Src.OnExit              ;
  Dst.OnGesture            := Src.OnGesture           ;  // *
  Dst.OnKeyDown            := Src.OnKeyDown           ;
  Dst.OnKeyPress           := Src.OnKeyPress          ;
  Dst.OnKeyUp              := Src.OnKeyUp             ;
  Dst.OnMeasureItem        := Src.OnMeasureItem       ;
  Dst.OnMouseEnter         := Src.OnMouseEnter        ;  // *
  Dst.OnMouseLeave         := Src.OnMouseLeave        ;  // *
  Dst.OnSelect             := Src.OnSelect            ;  // *
  Dst.OnStartDock          := Src.OnStartDock         ;  // *
  Dst.OnStartDrag          := Src.OnStartDrag         ;  // *
end;

//----------------------------------------------------------------------------//
//  TRadioGroup
//----------------------------------------------------------------------------//
procedure CopyRadioGroupProperty(Dst: TRadioGroup; Src: TRadioGroup);
begin
  // �v���p�e�B
  Dst.Align                := Src.Align               ;
  Dst.AlignWithMargins     := Src.AlignWithMargins    ;  // *
  Dst.Anchors              := Src.Anchors             ;  // *
  Dst.BiDiMode             := Src.BiDiMode            ;  // *
  Dst.Caption              := Src.Caption             ;
  Dst.Color                := Src.Color               ;
  Dst.Columns              := Src.Columns             ;
  Dst.Constraints          := Src.Constraints         ;  // *
  Dst.Ctl3D                := Src.Ctl3D               ;
  Dst.Cursor               := Src.Cursor              ;
  Dst.CustomHint           := Src.CustomHint          ;  // *
  Dst.DoubleBuffered       := Src.DoubleBuffered      ;  // *
  Dst.DragCursor           := Src.DragCursor          ;
  Dst.DragKind             := Src.DragKind            ;  // *
  Dst.DragMode             := Src.DragMode            ;
  Dst.Enabled              := Src.Enabled             ;
  Dst.Font                 := Src.Font                ;
  Dst.Height               := Src.Height              ;
  Dst.HelpContext          := Src.HelpContext         ;
  Dst.HelpKeyword          := Src.HelpKeyword         ;  // *
  Dst.HelpType             := Src.HelpType            ;  // *
  Dst.Hint                 := Src.Hint                ;
  Dst.ItemIndex            := Src.ItemIndex           ;
  Dst.Items                := Src.Items               ;
  Dst.Left                 := Src.Left                ;
  Dst.Margins              := Src.Margins             ;  // *
  Dst.ParentBackground     := Src.ParentBackground    ;  // *
  Dst.ParentBiDiMode       := Src.ParentBiDiMode      ;  // *
  Dst.ParentColor          := Src.ParentColor         ;
  Dst.ParentCtl3D          := Src.ParentCtl3D         ;
  Dst.ParentCustomHint     := Src.ParentCustomHint    ;  // *
  Dst.ParentDoubleBuffered := Src.ParentDoubleBuffered;  // *
  Dst.ParentFont           := Src.ParentFont          ;
  Dst.ParentShowHint       := Src.ParentShowHint      ;
  Dst.PopupMenu            := Src.PopupMenu           ;
  Dst.ShowHint             := Src.ShowHint            ;
  Dst.TabStop              := Src.TabStop             ;
  Dst.Tag                  := Src.Tag                 ;
  Dst.Top                  := Src.Top                 ;
  Dst.Touch                := Src.Touch               ;  // *
  Dst.Visible              := Src.Visible             ;
  Dst.Width                := Src.Width               ;
  Dst.WordWrap             := Src.WordWrap            ;  // *

  // �C�x���g
  Dst.OnClick              := Src.OnClick             ;
  Dst.OnContextPopup       := Src.OnContextPopup      ;  // *
  Dst.OnDragDrop           := Src.OnDragDrop          ;
  Dst.OnDragOver           := Src.OnDragOver          ;
  Dst.OnEndDock            := Src.OnEndDock           ;  // *
  Dst.OnEndDrag            := Src.OnEndDrag           ;
  Dst.OnEnter              := Src.OnEnter             ;
  Dst.OnExit               := Src.OnExit              ;
  Dst.OnGesture            := Src.OnGesture           ;  // *
  Dst.OnStartDock          := Src.OnStartDock         ;  // *
  Dst.OnStartDrag          := Src.OnStartDrag         ;  // *
end;

//----------------------------------------------------------------------------//
//  TPanel
//----------------------------------------------------------------------------//
procedure CopyPanelProperty(Dst: TPanel; Src: TPanel);
begin
  // �v���p�e�B
  Dst.Align                := Src.Align               ;
  Dst.Alignment            := Src.Alignment           ;
  Dst.AlignWithMargins     := Src.AlignWithMargins    ;  // *
  Dst.Anchors              := Src.Anchors             ;  // *
  Dst.AutoSize             := Src.AutoSize            ;  // *
  Dst.BevelEdges           := Src.BevelEdges          ;  // *
  Dst.BevelInner           := Src.BevelInner          ;
  Dst.BevelKind            := Src.BevelKind           ;  // *
  Dst.BevelOuter           := Src.BevelOuter          ;
  Dst.BevelWidth           := Src.BevelWidth          ;
  Dst.BiDiMode             := Src.BiDiMode            ;  // *
  Dst.BorderStyle          := Src.BorderStyle         ;
  Dst.BorderWidth          := Src.BorderWidth         ;
  Dst.Caption              := Src.Caption             ;
  Dst.Color                := Src.Color               ;
  Dst.Constraints          := Src.Constraints         ;  // *
  Dst.Ctl3D                := Src.Ctl3D               ;
  Dst.Cursor               := Src.Cursor              ;
  Dst.CustomHint           := Src.CustomHint          ;  // *
  Dst.DockSite             := Src.DockSite            ;  // *
  Dst.DoubleBuffered       := Src.DoubleBuffered      ;  // *
  Dst.DragCursor           := Src.DragCursor          ;
  Dst.DragKind             := Src.DragKind            ;  // *
  Dst.DragMode             := Src.DragMode            ;
  Dst.Enabled              := Src.Enabled             ;
  Dst.Font                 := Src.Font                ;
  Dst.FullRepaint          := Src.FullRepaint         ;  // *
  Dst.Height               := Src.Height              ;
  Dst.HelpContext          := Src.HelpContext         ;
  Dst.HelpKeyword          := Src.HelpKeyword         ;  // *
  Dst.HelpType             := Src.HelpType            ;  // *
  Dst.Hint                 := Src.Hint                ;
  Dst.Left                 := Src.Left                ;
  Dst.Locked               := Src.Locked              ;
  Dst.Margins              := Src.Margins             ;  // *
  Dst.Padding              := Src.Padding             ;  // *
  Dst.ParentBackground     := Src.ParentBackground    ;  // *
  Dst.ParentBiDiMode       := Src.ParentBiDiMode      ;  // *
  Dst.ParentColor          := Src.ParentColor         ;
  Dst.ParentCtl3D          := Src.ParentCtl3D         ;
  Dst.ParentCustomHint     := Src.ParentCustomHint    ;  // *
  Dst.ParentDoubleBuffered := Src.ParentDoubleBuffered;  // *
  Dst.ParentFont           := Src.ParentFont          ;
  Dst.ParentShowHint       := Src.ParentShowHint      ;
  Dst.PopupMenu            := Src.PopupMenu           ;
  Dst.ShowCaption          := Src.ShowCaption         ;  // *
  Dst.ShowHint             := Src.ShowHint            ;
  Dst.TabStop              := Src.TabStop             ;
  Dst.Tag                  := Src.Tag                 ;
  Dst.Top                  := Src.Top                 ;
  Dst.Touch                := Src.Touch               ;  // *
  Dst.UseDockManager       := Src.UseDockManager      ;  // *
  Dst.VerticalAlignment    := Src.VerticalAlignment   ;  // *
  Dst.Visible              := Src.Visible             ;
  Dst.Width                := Src.Width               ;

  // �C�x���g
  Dst.OnAlignInsertBefore  := Src.OnAlignInsertBefore ;  // *
  Dst.OnAlignPosition      := Src.OnAlignPosition     ;  // *
  Dst.OnCanResize          := Src.OnCanResize         ;  // *
  Dst.OnClick              := Src.OnClick             ;
  Dst.OnConstrainedResize  := Src.OnConstrainedResize ;  // *
  Dst.OnContextPopup       := Src.OnContextPopup      ;  // *
  Dst.OnDblClick           := Src.OnDblClick          ;
  Dst.OnDockDrop           := Src.OnDockDrop          ;  // *
  Dst.OnDockOver           := Src.OnDockOver          ;  // *
  Dst.OnDragDrop           := Src.OnDragDrop          ;
  Dst.OnDragOver           := Src.OnDragOver          ;
  Dst.OnEndDock            := Src.OnEndDock           ;  // *
  Dst.OnEndDrag            := Src.OnEndDrag           ;
  Dst.OnEnter              := Src.OnEnter             ;
  Dst.OnExit               := Src.OnExit              ;
  Dst.OnGesture            := Src.OnGesture           ;  // *
  Dst.OnGetSiteInfo        := Src.OnGetSiteInfo       ;  // *
  Dst.OnMouseActivate      := Src.OnMouseActivate     ;  // *
  Dst.OnMouseDown          := Src.OnMouseDown         ;
  Dst.OnMouseEnter         := Src.OnMouseEnter        ;  // *
  Dst.OnMouseLeave         := Src.OnMouseLeave        ;  // *
  Dst.OnMouseMove          := Src.OnMouseMove         ;
  Dst.OnMouseUp            := Src.OnMouseUp           ;
  Dst.OnResize             := Src.OnResize            ;
  Dst.OnStartDock          := Src.OnStartDock         ;  // *
  Dst.OnStartDrag          := Src.OnStartDrag         ;  // *
  Dst.OnUnDock             := Src.OnUnDock            ;  // *
end;

end.
