//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����`�[���͉�ʗp�d�����J�����_�[
// �v���O�����T�v   :
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : � �^
// �� �� ��  2012/10/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �e�c�@���V
// �� �� ��  2012/12/17  �C�����e : �N���b�N���̕s����C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : � �^
// �� �� ��  2012/12/18  �C�����e : Redmine#31582�̕s����C��
//----------------------------------------------------------------------------//
unit CalendarGuid;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ComCtrls, CommCtrl, AppEvnts, DateUtils;

// ------------- DEL 2012/12/18  ------------ >>>>>>>>>>>>>>>>
//type
//  TCalendarForm = class(TForm)
//    MonthCalendar: TMonthCalendar;
//    procedure MonthCalendarClick(Sender: TObject);
//    procedure FormClose(Sender: TObject; var Action: TCloseAction);
//    procedure FormKeyDown(Sender: TObject; var Key: Word; Shift: TShiftState);
//    procedure FormMouseWheelDown(Sender: TObject; Shift: TShiftState;
//      MousePos: TPoint; var Handled: Boolean);
//    procedure FormMouseWheelUp(Sender: TObject; Shift: TShiftState;
//      MousePos: TPoint; var Handled: Boolean);
//    procedure MonthCalendarDblClick(Sender: TObject);
//    procedure MonthCalendarKeyUp(Sender: TObject; var Key: Word;
//      Shift: TShiftState);
//    procedure FormShow(Sender: TObject);
//  private
//    { Private �錾 }
//  public
//    { Public �錾 }
//    SelectDate: TDate;
//    Col: Integer;
//    Row: Integer;
//  end;
//
//var
//  CalendarForm: TCalendarForm;
//  MouseRect :TRect;
//implementation
//uses
//  MAHNB01001UA;
//
//{$R *.dfm}
//
////�J�����_�[�̕���C�x���g
//procedure TCalendarForm.FormClose(Sender: TObject; var Action: TCloseAction);
//begin
//end;
//
////�J�����_�[�̏����\���C�x���g
//procedure TCalendarForm.FormKeyDown(Sender: TObject; var Key: Word;
//  Shift: TShiftState);
//var
//  tempStr:string;
//  valid:Boolean;
//begin
//  case Key of
//  VK_ESCAPE : begin
//                ModalResult := mrCancel;
//              end;
//  VK_RETURN : begin
//                SelectDate := MonthCalendar.Date;
//                tempStr := FormatDateTime('yyyy/mm/dd',SelectDate);
//                Form4.HNsGrid1.GridCells[Col,Row] := tempStr;
//                Form4.HNsGrid1.OnCellValidate(Sender, Col, Row, tempStr, valid);
//                ModalResult := mrOk;
//              end;
//  end;
//end;
//
//procedure TCalendarForm.FormMouseWheelDown(Sender: TObject; Shift: TShiftState;
//  MousePos: TPoint; var Handled: Boolean);
//var
//  tempStr:string;
//  valid:Boolean;
//begin
////  SelectDate := MonthCalendar.Date;
////  tempStr := FormatDateTime('yyyy/mm/dd',SelectDate);
////  Form4.HNsGrid1.GridCells[Col,Row] := tempStr;
////  Form4.HNsGrid1.OnCellValidate(Sender, Col, Row, tempStr, valid);
//end;
//
//procedure TCalendarForm.FormMouseWheelUp(Sender: TObject; Shift: TShiftState;
//  MousePos: TPoint; var Handled: Boolean);
//var
//  tempStr:string;
//  valid:Boolean;
//begin
////  SelectDate := MonthCalendar.Date;
////  tempStr := FormatDateTime('yyyy/mm/dd',SelectDate);
////  Form4.HNsGrid1.GridCells[Col,Row] := tempStr;
////  Form4.HNsGrid1.OnCellValidate(Sender, Col, Row, tempStr, valid);
//end;
//
//procedure TCalendarForm.FormShow(Sender: TObject);
//begin
//  AutoSize := False ;
//  AutoSize := True  ;
//end;
//
////�J�����_�[�̃}�E�X�C�x���g
//procedure TCalendarForm.MonthCalendarClick(Sender: TObject);
//var
//tempStr:string;
//valid:Boolean;
//mousePoint:TPoint;
//begin
////  SelectDate := MonthCalendar.Date;
////  tempStr := FormatDateTime('yyyy/mm/dd',SelectDate);
////  Form4.HNsGrid1.GridCells[Col,Row] := tempStr;
////  Form4.HNsGrid1.OnCellValidate(Sender, Col, Row, tempStr, valid);
//end;
//
//procedure TCalendarForm.MonthCalendarDblClick(Sender: TObject);
//var
//  tempStr:string;
//  valid:Boolean;
//  mousePoint:TPoint;
//begin
//  MouseRect:= Bounds(self.Left, self.Top+45, self.Width, self.Height);
//  GetCursorPos(mousePoint);
//
//  SelectDate := MonthCalendar.Date;
//  tempStr := FormatDateTime('yyyy/mm/dd',SelectDate);
//  Form4.HNsGrid1.GridCells[Col,Row] := tempStr;
//  Form4.HNsGrid1.OnCellValidate(Sender, Col, Row, tempStr, valid);
//  if (PtInRect(MouseRect, mousePoint)) then
//  begin
//    ModalResult := mrOk;
//  end;
//end;
//procedure TCalendarForm.MonthCalendarKeyUp(Sender: TObject; var Key: Word;
//  Shift: TShiftState);
//var
//  tempStr:string;
//  valid:Boolean;
//begin
////  SelectDate := MonthCalendar.Date;
////  tempStr := FormatDateTime('yyyy/mm/dd',SelectDate);
////  Form4.HNsGrid1.GridCells[Col,Row] := tempStr;
////  Form4.HNsGrid1.OnCellValidate(Sender, Col, Row, tempStr, valid);
//end;
// ------------- DEL 2012/12/18  ------------ <<<<<<<<<<<<<<

// ------------- ADD 2012/12/18  ------------ >>>>>>>>>>>>>>>>
type
  // ���t�J�����_�[
  TCustomMonthCalendar = class(TMonthCalendar)
  private
    FMinVistaVersion: boolean;
    FOnSelect: TNotifyEvent;
    procedure CNNotify(var Msg: TWMNotify);
    message CN_NOTIFY;
    function GetViewMode: Integer;
    procedure SetViewMode(mode : Integer);
    function ValidateDate(Value : TDate) : TDate;
  protected
    procedure DoSelect;
    procedure DoSelChange;
    procedure ChangeDate(mUnit: Integer; mKey: Word);
  public
    constructor Create(AOwner: TComponent); override;
    property OnSelect: TNotifyEvent read FOnSelect write FOnSelect;
    property ViewMode: Integer read GetViewMode write SetViewMode;
  end;

const
  // �ŏ����t
  DEFAULT_MINDATE = -53688.000000000000000000; // 1753/01/01
  // �ő���t
  DEFAULT_MAXDATE = 2958100.000000000000000000; //9998/12/31
  // �����[�h
  MCMV_DAY = 0;
  // �����[�h
  MCMV_MONTH = 1;
  // �N���[�h
  MCMV_YEAR = 2;
  // �\�N���[�h
  MCMV_DECADE = 3;
  // �S�N���[�h
  MCMV_CENTURY = 4;
  // �J�����_�[�����̍����iXP�jHEIGHT
  TODAY_HEIGHT_XP = 20;
  // �J�����_�[�����̍����iWIN7�jHEIGHT
  TODAY_HEIGHT_WIN7 = 25;
  // ���t�ύX
  MCN_VIEWCHANGE = MCN_FIRST + 0;
  // ���t���[�h���擾�p
  MCM_GETCURRENTVIEW = MCM_FIRST + 22;
  // ���t���[�h��ݒ�p
  MCM_SETCURRENTVIEW = MCM_FIRST + 32;

type
  // ���tFORM
  TCalendarForm = class(TForm)
    ApplicationEvents1: TApplicationEvents;
    procedure FormCreate(Sender: TObject);
    procedure AppEventsMessage(var Msg: tagMSG; var Handled: boolean);
    procedure FormShow(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
  private
    { Private �錾 }
    FMinVistaVersion: boolean;
    function GetMonthCalendar: TCustomMonthCalendar;
    procedure ResetXEvent(var Msg: tagMSG);
    function Minutes(Time:TDateTime): Integer;
    function MinuteDiff(beginning:TDateTime; ending:TDateTime): Integer;
  public
    { Public �錾 }
    SelectDate: TDate;
    Col: Integer;
    Row: Integer;

    property MonthCalendar: TCustomMonthCalendar read GetMonthCalendar;


  end;

var
  CalendarForm: TCalendarForm;
  FMonthCalendar: TCustomMonthCalendar;

  xEventDiv : Integer;
  xEventParam : Integer;
  xEventOldDate : TDate;
  xIgnoreEvent : Boolean;
  xTodayClick: Boolean;

  dateTimeOne:TDateTime;
  dateTimeTwo:TDateTime;

implementation

{$R *.dfm}

//*************************************************************************
// ���[�U�[�̃V�X�e�����擾����B
//*************************************************************************
constructor TCustomMonthCalendar.Create(AOwner: TComponent);
begin
  inherited;
  FMinVistaVersion := Win32MajorVersion >= 6;
  AutoSize := False ;
  AutoSize := True  ;
end;

//*************************************************************************
// ���t�J�����_�[��MSG����������B
//*************************************************************************
procedure TCustomMonthCalendar.CNNotify(var Msg: TWMNotify);
begin
  inherited;
  with Msg, NMHdr^ do
  begin
    case code of
      MCN_SELECT:     // ���t�I��
        DoSelect;
      MCN_SELCHANGE:  // ���t�ύX
      begin
         DoSelChange;
      end;
    end;
  end;
end;

//*************************************************************************
// ���t���[�h��ݒ肷��B
//*************************************************************************
procedure TCustomMonthCalendar.SetViewMode(mode : Integer);
begin
  if FMinVistaVersion then  // WIN7
  begin
   SendMessage(Handle, MCM_SETCURRENTVIEW, 0, mode);
  end;
end;

//*************************************************************************
// ���t���[�h���擾����B
//*************************************************************************
function TCustomMonthCalendar.GetViewMode: Integer;
begin
  if FMinVistaVersion then  // WIN7
  begin
    Result := SendMessage(Handle, MCM_GETCURRENTVIEW, 0, 0);
  end
  else
    Result := MCMV_DAY;     // XP
end;

//*************************************************************************
// ���t�ύX��A�����ʂ�ݒ肷��B
//*************************************************************************
procedure TCustomMonthCalendar.DoSelChange;
begin

  if Assigned(FOnSelect) then
  begin
    FOnSelect(Self);
  end;
end;

//*************************************************************************
// ���t�J�����_�[���t�����C�x���g
//*************************************************************************
procedure TCustomMonthCalendar.DoSelect;
var
  CloseCalendar : Boolean;
begin
  CloseCalendar := False;
  // �J�����_�[�����̍������N���b�N�̏ꍇ�A
  if xTodayClick And (xEventDiv = WM_LBUTTONDOWN) Then
  begin
    Self.Date := Today;
    if Assigned(FOnSelect) then
    begin
      FOnSelect(Self);
    end;
    SendMessage(Self.Parent.Handle, WM_SYSCOMMAND, SC_CLOSE, 0);
    Exit;
  end;
  // ���t�ύX��A�����ʂ�ݒ肷��B
  if Assigned(FOnSelect) then
  begin
    FOnSelect(Self);
  end;
  // �����[�h�ȊO�̏ꍇ�A�J�����_�[������Ȃ��B
  if xIgnoreEvent then
  begin
    xIgnoreEvent := False;
    Exit;
  end;

  // �����[�h�̏ꍇ�A�V���O���N���b�N�A���A�������t��I��������A�J�����_�[����
  if (xEventDiv = WM_LBUTTONDOWN) And IsSameDay(xEventOldDate,Self.Date)
    And (Self.ViewMode = MCMV_DAY) Then
  begin
     CloseCalendar := True;

  // �����[�h�̏ꍇ�A�_�u���N���b�N���ăJ�����_�[����
  end else if (xEventDiv = WM_LBUTTONDBLCLK) And (Self.ViewMode = MCMV_DAY) Then
  begin
     CloseCalendar := True;

  // �����[�h�̏ꍇ�AEnter�L�[�������ăJ�����_�[����
  end else if (xEventDiv = WM_KEYDOWN) And (xEventParam = VK_RETURN) Then
  begin
     CloseCalendar := True;
  end;

  // �J�����_�[����t���O��TRUE�̏ꍇ�A�J�����_�[����
  if CloseCalendar then
  begin
    SendMessage(Self.Parent.Handle, WM_SYSCOMMAND, SC_CLOSE, 0);
    Exit;
  end;
end;

//*************************************************************************
// �J�����_�[�̗L�����̃`�F�b�N
//*************************************************************************
function TCustomMonthCalendar.ValidateDate(Value : TDate) : TDate;
begin
  if (Self.MinDate <> 0.0) And (Value < Self.MinDate) then
  begin
    Result := Self.MinDate;
  end else if (Self.MaxDate <> 0.0) And (Value > Self.MaxDate) then
  begin
    Result := Self.MaxDate;
  end else
  begin
    Result := Value;
  end;
end;

//*************************************************************************
// WINDOWXP�̏ꍇ�A���A���A���A���L�[�ړ��̏���
//*************************************************************************
procedure TCustomMonthCalendar.ChangeDate(mUnit: Integer; mKey: Word);
var
tempYear, tempMonth, tempDay:Integer;
tempYearDate, tempMonthDate, tempDayDate:TDate;
tempDate : TDate;
begin
  case mUnit of
    MCMV_DAY:
      case mKey of
        VK_UP:
          Self.Date := ValidateDate(Self.Date - 7);
        VK_DOWN:
          Self.Date := ValidateDate(Self.Date + 7);
        VK_LEFT:
          Self.Date := ValidateDate(Self.Date - 1);
        VK_RIGHT:
          Self.Date := ValidateDate(Self.Date + 1);
      end;
  end;
end;

//*************************************************************************
// �J�����_�[�C���X�^���X�擾
//*************************************************************************
function TCalendarForm.GetMonthCalendar: TCustomMonthCalendar;
begin
  Result := FMonthCalendar;
end;

//*************************************************************************
// ���t�ύX�̏ꍇ�A�ύX�O�̓��t�o�b�N
//*************************************************************************
procedure TCalendarForm.ResetXEvent(var Msg: tagMSG);
begin
    xEventDiv := Msg.message;
    xEventOldDate := FMonthCalendar.Date;
    xEventParam := Msg.wParam;
end;

//*************************************************************************
// ���ԍ��̌v�Z
//*************************************************************************
function TCalendarForm.Minutes(Time: TDateTime) : LongInt;
var
H, M, S, MS:word;
begin
  DecodeTime(Time, H, M, S, MS);
  result := H*3600*1000 +  60*M*1000 + S*1000 + MS
end;

//*************************************************************************
// ���ԍ��̌v�Z
//*************************************************************************
function TCalendarForm.MinuteDiff(Beginning :TDateTime; Ending:TDateTime):LongInt;
begin
   result :=  Minutes(Ending - Beginning);
end;


//*************************************************************************
// �J�����_�[�t�H�[���̊e���b�Z�[�W����
//*************************************************************************
procedure TCalendarForm.AppEventsMessage
  (var Msg: tagMSG; var Handled: boolean);
var
  MousePoint:TPoint;
  ValidRect :TRect;
  ValidRect2 :TRect;
  MousePoint2:TPoint;
  TodayRect: TRect;
  TodayHeight: Integer;
  diffInt :LongInt;
begin
  if Application.ActiveFormHandle = Self.Handle then
  begin

    // �V���O���N���b�N�A�_�u���N���b�N�̏ꍇ
    if ((Msg.message = WM_LBUTTONDOWN) Or (Msg.message = WM_LBUTTONDBLCLK))
      And (Msg.wParam = VK_LBUTTON) then
    begin

      // ���݂̎��Ԃ͌����[�h�Ń_�u���N���b�N���̎��ԂƂ̎��ԍ��ق��v�Z����
      dateTimeTwo := Now();
      diffInt := MinuteDiff(dateTimeOne, dateTimeTwo);

      // ���َ���<0.3S�̏ꍇ�A�����������Ȃ�
      if (diffInt < 300) then
      begin
        Handled := True;
        Exit;
      end;

      // ���t�G�A���A�擾
      ValidRect:= Bounds(Self.Left, Self.Top+ 45, Self.Width, Self.Height);

      // �����G�A���A�擾
      if FMinVistaVersion then
      begin
        TodayHeight := TODAY_HEIGHT_WIN7;
      end
      else
        TodayHeight := TODAY_HEIGHT_XP;
      TodayRect := Bounds(Self.Left, Self.Top + Self.Height - TodayHeight,
            Self.Width, TodayHeight);

      // �����G�A���A�N���b�N�t���O
      xTodayClick := False;

      // �}�E�X�̃|�C���g�擾
      GetCursorPos(MousePoint);

      // �����G�A���A�͈͓��N���b�N�����ꍇ�A���t��ۑ�����
      if PtInRect(TodayRect, MousePoint) then
      begin
        ResetXEvent(Msg);
        xTodayClick := True;
      end

      // ���t�G�A���A�͈͓��N���b�N�������ꍇ
      else if PtInRect(ValidRect, MousePoint) then
      begin

        // ���t���[�h�̏ꍇ
        if FMonthCalendar.ViewMode = MCMV_DAY then
        begin
          // ���t�ۑ�
          ResetXEvent(Msg);
          // �_�u���N���b�N�̏ꍇ�A�J�����_�[����A
          // �I����t�𔄏���͉�ʂɕ\������
          if (Msg.message = WM_LBUTTONDBLCLK) then
          begin
            FMonthCalendar.DoSelect;
            Handled := True;
          end;
        end

        // �����[�h�̏ꍇ
        else if FMonthCalendar.ViewMode = MCMV_MONTH then
        begin
            // �V�X�e�����t��ۑ�(�_�u���N���b�N�ƃV���O���N���b�N�𓯎��ɓ����Ȃ����߁j
            dateTimeOne := Now();
            // �J�����_�[�����Ȃ����߁A�t���O�ݒ�
            xIgnoreEvent := False;
        end
        else
        begin
           xIgnoreEvent := True;
        end;
      end;
    end

    // KeyDown(�̏���
    else if Msg.message = WM_KEYDOWN then
    begin
      case Msg.wParam of

        // ���A���A���A���L�[�̏���
        VK_DOWN, VK_UP, VK_LEFT, VK_RIGHT:
          begin
            // ���t�ۑ�
            ResetXEvent(Msg);

            // WINDOWXP�̏ꍇ�A���A���A���A���L�[�ړ������⑫
            //�iWINDDOWS7��TABSTOP�ŗL���ł��̂ŏ����⑫�s�v�j
            if not FMinVistaVersion then
            begin
              FMonthCalendar.ChangeDate(FMonthCalendar.ViewMode, Msg.wParam);
              Handled := True;
            end;
          end;

        // Enter�L�[�̏���
        VK_RETURN:
          begin

            // ���t���[�h�ȊO�̏ꍇ�A�O�̃��[�h�ɖ߂�
            if FMonthCalendar.ViewMode > 0 then
            begin
              FMonthCalendar.ViewMode := FMonthCalendar.ViewMode - 1;

            // ���t���[�h�̏ꍇ�A���t�𔄏��ʂɕ\�����āA�J�����_�[����
            end else begin
              ResetXEvent(Msg);
              FMonthCalendar.DoSelect;
              ModalResult := mrOk;
            end;
            Handled := True;
          end;

          // ESC�L�[�̏���
          VK_ESCAPE :
          begin

            // �J�����_�[����
            ModalResult := mrCancel;
            Handled := True;
          end;
      end;
    end
    // WindowXP�̃L�[UP�ꍇ�A�I����t�ݒ�iWINDOWS7�Ŗ�肪�Ȃ��̂ŕ⑫�s�v�j
    else if (Msg.message = WM_KEYUP) and (not FMinVistaVersion) then
    begin
      case Msg.wParam of
        VK_DOWN, VK_UP, VK_LEFT, VK_RIGHT:
          begin
            FMonthCalendar.DoSelChange;
          end;
      end;
    end;
  end;
end;

//*************************************************************************
// �J�����_�[�t�H�[������
//*************************************************************************
procedure TCalendarForm.FormCreate(Sender: TObject);
begin

  FMinVistaVersion := Win32MajorVersion >= 6;

  FMonthCalendar := TCustomMonthCalendar.Create(Self);

  FMonthCalendar.Parent := Self;

  if FMonthCalendar.MinDate = 0.0 then
     FMonthCalendar.MinDate := DEFAULT_MINDATE;

  if FMonthCalendar.MaxDate = 0.0 then
     FMonthCalendar.MaxDate := DEFAULT_MAXDATE;


  if FMinVistaVersion then
  begin
    FMonthCalendar.Height := 180;
    FMonthCalendar.Width := 210;
  end
  else
  begin
    FMonthCalendar.Height := 153;
    FMonthCalendar.Width := 134;
  end;

  FMonthCalendar.TabStop := True;
  AutoSize := False;
  AutoSize := True;
end;

//*************************************************************************
// �J�����_�[�t�H�[���\��
//*************************************************************************
procedure TCalendarForm.FormShow(Sender: TObject);
begin
   AutoSize := False ;
   AutoSize := True  ;
end;

//*************************************************************************
// �J�����_�[�t�H�[��Destroy
//*************************************************************************
procedure TCalendarForm.FormDestroy(Sender: TObject);
begin
   if Assigned(FMonthCalendar) then
   begin
    FMonthCalendar.Destroy;
    FMonthCalendar := nil;
   end;
end;

// ------------- ADD 2012/12/18  ------------ <<<<<<<<<<<<<<<<

end.
