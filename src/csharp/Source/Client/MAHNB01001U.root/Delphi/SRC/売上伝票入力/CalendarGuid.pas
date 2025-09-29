//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上伝票入力画面用仕入日カレンダー
// プログラム概要   :
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚 洪
// 作 成 日  2012/10/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田　靖之
// 作 成 日  2012/12/17  修正内容 : クリック時の不具合を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚 洪
// 作 成 日  2012/12/18  修正内容 : Redmine#31582の不具合を修正
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
//    { Private 宣言 }
//  public
//    { Public 宣言 }
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
////カレンダーの閉じるイベント
//procedure TCalendarForm.FormClose(Sender: TObject; var Action: TCloseAction);
//begin
//end;
//
////カレンダーの初期表示イベント
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
////カレンダーのマウスイベント
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
  // 日付カレンダー
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
  // 最小日付
  DEFAULT_MINDATE = -53688.000000000000000000; // 1753/01/01
  // 最大日付
  DEFAULT_MAXDATE = 2958100.000000000000000000; //9998/12/31
  // 日モード
  MCMV_DAY = 0;
  // 月モード
  MCMV_MONTH = 1;
  // 年モード
  MCMV_YEAR = 2;
  // 十年モード
  MCMV_DECADE = 3;
  // 百年モード
  MCMV_CENTURY = 4;
  // カレンダー下部の今日（XP）HEIGHT
  TODAY_HEIGHT_XP = 20;
  // カレンダー下部の今日（WIN7）HEIGHT
  TODAY_HEIGHT_WIN7 = 25;
  // 日付変更
  MCN_VIEWCHANGE = MCN_FIRST + 0;
  // 日付モードを取得用
  MCM_GETCURRENTVIEW = MCM_FIRST + 22;
  // 日付モードを設定用
  MCM_SETCURRENTVIEW = MCM_FIRST + 32;

type
  // 日付FORM
  TCalendarForm = class(TForm)
    ApplicationEvents1: TApplicationEvents;
    procedure FormCreate(Sender: TObject);
    procedure AppEventsMessage(var Msg: tagMSG; var Handled: boolean);
    procedure FormShow(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
  private
    { Private 宣言 }
    FMinVistaVersion: boolean;
    function GetMonthCalendar: TCustomMonthCalendar;
    procedure ResetXEvent(var Msg: tagMSG);
    function Minutes(Time:TDateTime): Integer;
    function MinuteDiff(beginning:TDateTime; ending:TDateTime): Integer;
  public
    { Public 宣言 }
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
// ユーザーのシステムを取得する。
//*************************************************************************
constructor TCustomMonthCalendar.Create(AOwner: TComponent);
begin
  inherited;
  FMinVistaVersion := Win32MajorVersion >= 6;
  AutoSize := False ;
  AutoSize := True  ;
end;

//*************************************************************************
// 日付カレンダーのMSGを処理する。
//*************************************************************************
procedure TCustomMonthCalendar.CNNotify(var Msg: TWMNotify);
begin
  inherited;
  with Msg, NMHdr^ do
  begin
    case code of
      MCN_SELECT:     // 日付選択
        DoSelect;
      MCN_SELCHANGE:  // 日付変更
      begin
         DoSelChange;
      end;
    end;
  end;
end;

//*************************************************************************
// 日付モードを設定する。
//*************************************************************************
procedure TCustomMonthCalendar.SetViewMode(mode : Integer);
begin
  if FMinVistaVersion then  // WIN7
  begin
   SendMessage(Handle, MCM_SETCURRENTVIEW, 0, mode);
  end;
end;

//*************************************************************************
// 日付モードを取得する。
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
// 日付変更後、売上画面を設定する。
//*************************************************************************
procedure TCustomMonthCalendar.DoSelChange;
begin

  if Assigned(FOnSelect) then
  begin
    FOnSelect(Self);
  end;
end;

//*************************************************************************
// 日付カレンダー日付処理イベント
//*************************************************************************
procedure TCustomMonthCalendar.DoSelect;
var
  CloseCalendar : Boolean;
begin
  CloseCalendar := False;
  // カレンダー下部の今日をクリックの場合、
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
  // 日付変更後、売上画面を設定する。
  if Assigned(FOnSelect) then
  begin
    FOnSelect(Self);
  end;
  // 日モード以外の場合、カレンダーを閉じしない。
  if xIgnoreEvent then
  begin
    xIgnoreEvent := False;
    Exit;
  end;

  // 日モードの場合、シングルクリック、かつ、同じ日付を選択したら、カレンダー閉じる
  if (xEventDiv = WM_LBUTTONDOWN) And IsSameDay(xEventOldDate,Self.Date)
    And (Self.ViewMode = MCMV_DAY) Then
  begin
     CloseCalendar := True;

  // 日モードの場合、ダブルクリックしてカレンダー閉じる
  end else if (xEventDiv = WM_LBUTTONDBLCLK) And (Self.ViewMode = MCMV_DAY) Then
  begin
     CloseCalendar := True;

  // 日モードの場合、Enterキーを押してカレンダー閉じる
  end else if (xEventDiv = WM_KEYDOWN) And (xEventParam = VK_RETURN) Then
  begin
     CloseCalendar := True;
  end;

  // カレンダー閉じるフラグがTRUEの場合、カレンダー閉じる
  if CloseCalendar then
  begin
    SendMessage(Self.Parent.Handle, WM_SYSCOMMAND, SC_CLOSE, 0);
    Exit;
  end;
end;

//*************************************************************************
// カレンダーの有効性のチェック
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
// WINDOWXPの場合、←、→、↑、↓キー移動の処理
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
// カレンダーインスタンス取得
//*************************************************************************
function TCalendarForm.GetMonthCalendar: TCustomMonthCalendar;
begin
  Result := FMonthCalendar;
end;

//*************************************************************************
// 日付変更の場合、変更前の日付バック
//*************************************************************************
procedure TCalendarForm.ResetXEvent(var Msg: tagMSG);
begin
    xEventDiv := Msg.message;
    xEventOldDate := FMonthCalendar.Date;
    xEventParam := Msg.wParam;
end;

//*************************************************************************
// 時間差の計算
//*************************************************************************
function TCalendarForm.Minutes(Time: TDateTime) : LongInt;
var
H, M, S, MS:word;
begin
  DecodeTime(Time, H, M, S, MS);
  result := H*3600*1000 +  60*M*1000 + S*1000 + MS
end;

//*************************************************************************
// 時間差の計算
//*************************************************************************
function TCalendarForm.MinuteDiff(Beginning :TDateTime; Ending:TDateTime):LongInt;
begin
   result :=  Minutes(Ending - Beginning);
end;


//*************************************************************************
// カレンダーフォームの各メッセージ処理
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

    // シングルクリック、ダブルクリックの場合
    if ((Msg.message = WM_LBUTTONDOWN) Or (Msg.message = WM_LBUTTONDBLCLK))
      And (Msg.wParam = VK_LBUTTON) then
    begin

      // 現在の時間は月モードでダブルクリック時の時間との時間差異を計算する
      dateTimeTwo := Now();
      diffInt := MinuteDiff(dateTimeOne, dateTimeTwo);

      // 差異時間<0.3Sの場合、何処理もしない
      if (diffInt < 300) then
      begin
        Handled := True;
        Exit;
      end;

      // 日付エアリア取得
      ValidRect:= Bounds(Self.Left, Self.Top+ 45, Self.Width, Self.Height);

      // 今日エアリア取得
      if FMinVistaVersion then
      begin
        TodayHeight := TODAY_HEIGHT_WIN7;
      end
      else
        TodayHeight := TODAY_HEIGHT_XP;
      TodayRect := Bounds(Self.Left, Self.Top + Self.Height - TodayHeight,
            Self.Width, TodayHeight);

      // 今日エアリアクリックフラグ
      xTodayClick := False;

      // マウスのポイント取得
      GetCursorPos(MousePoint);

      // 今日エアリア範囲内クリックした場合、日付を保存する
      if PtInRect(TodayRect, MousePoint) then
      begin
        ResetXEvent(Msg);
        xTodayClick := True;
      end

      // 日付エアリア範囲内クリックしたか場合
      else if PtInRect(ValidRect, MousePoint) then
      begin

        // 日付モードの場合
        if FMonthCalendar.ViewMode = MCMV_DAY then
        begin
          // 日付保存
          ResetXEvent(Msg);
          // ダブルクリックの場合、カレンダー閉じる、
          // 選択日付を売上入力画面に表示する
          if (Msg.message = WM_LBUTTONDBLCLK) then
          begin
            FMonthCalendar.DoSelect;
            Handled := True;
          end;
        end

        // 月モードの場合
        else if FMonthCalendar.ViewMode = MCMV_MONTH then
        begin
            // システム日付を保存(ダブルクリックとシングルクリックを同時に動かないため）
            dateTimeOne := Now();
            // カレンダーを閉じらないため、フラグ設定
            xIgnoreEvent := False;
        end
        else
        begin
           xIgnoreEvent := True;
        end;
      end;
    end

    // KeyDown(の処理
    else if Msg.message = WM_KEYDOWN then
    begin
      case Msg.wParam of

        // ←、→、↑、↓キーの処理
        VK_DOWN, VK_UP, VK_LEFT, VK_RIGHT:
          begin
            // 日付保存
            ResetXEvent(Msg);

            // WINDOWXPの場合、←、→、↑、↓キー移動処理補足
            //（WINDDOWS7はTABSTOPで有効ですので処理補足不要）
            if not FMinVistaVersion then
            begin
              FMonthCalendar.ChangeDate(FMonthCalendar.ViewMode, Msg.wParam);
              Handled := True;
            end;
          end;

        // Enterキーの処理
        VK_RETURN:
          begin

            // 日付モード以外の場合、前のモードに戻す
            if FMonthCalendar.ViewMode > 0 then
            begin
              FMonthCalendar.ViewMode := FMonthCalendar.ViewMode - 1;

            // 日付モードの場合、日付を売上画面に表示して、カレンダー閉じる
            end else begin
              ResetXEvent(Msg);
              FMonthCalendar.DoSelect;
              ModalResult := mrOk;
            end;
            Handled := True;
          end;

          // ESCキーの処理
          VK_ESCAPE :
          begin

            // カレンダー閉じる
            ModalResult := mrCancel;
            Handled := True;
          end;
      end;
    end
    // WindowXPのキーUP場合、選択日付設定（WINDOWS7で問題がないので補足不要）
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
// カレンダーフォーム生成
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
// カレンダーフォーム表示
//*************************************************************************
procedure TCalendarForm.FormShow(Sender: TObject);
begin
   AutoSize := False ;
   AutoSize := True  ;
end;

//*************************************************************************
// カレンダーフォームDestroy
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
