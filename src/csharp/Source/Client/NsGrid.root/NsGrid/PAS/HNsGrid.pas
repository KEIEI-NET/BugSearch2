unit HNsGrid;
{$R 'HNsGrid.res' 'HNsGrid.rc'}

interface

uses
  SysUtils, Classes, Controls, Grids, BaseGrid, AdvGrid, Messages, Windows,
  Graphics, Dialogs,
  AdvUtil, ClipBrd, Forms;

type
  TNsGridCoord = record
    Col, Row, Line: Integer;
  end;

  TGetImeModeEvent = procedure(Sender: TObject; ACol, ARow: Integer; var AImeMode: TImeMode) of object;

  // �Œ���Ԓl
  TFixedColState = (csNone, csSort, csFilter, csBoth);

  // ���בւ����� ���\����
  TSortCondition = record
    Priority: Integer; // �D�揇��
    ColNo: Integer; // �Ώۗ�ԍ�
    RowNo: Integer; // �Ώۍs�ԍ� (���i�p)
    Direction: TSortDirection; // ���בւ���
  end;

  TSortConditions = array of TSortCondition;

  TCursorMode = (cmDefault, cmSimple); // 2010/06/04 ADD �{�{

  // �i�荞�݊֘A�l
  TFilterRelation = (frNone, frAnd, frOr);

  // �i�荞�� ���e��Ӗ��͌�q�̒萔 FilterOperationName ���Q��
  TFilterOperation = (foEqual, foNotequal, foMoreThan, foAndMore, foLessThen, foAndLess, foIsIn, foIsNotIn, foIsBlank, foNotBlank);

  // --- ADD 2010/09/17 H.Matsumoto --------------------------------------->>>>
  TNsCellValidateEvent = procedure(Sender: TObject; ACol, ARow: Integer; var Value: String; var Valid: Boolean; CheckOnly: Boolean) of object;
  // --- ADD 2010/09/17 H.Matsumoto ---------------------------------------<<<<

  // �i�荞�ݏ��� ���\����
  TFilterCondition = record
    Priority: Integer; // �D�揇��
    Relation: TFilterRelation; // �i�荞�݊֘A�l
    ColNo: Integer; // �Ώۗ�ԍ�
    RowNo: Integer; // �Ώۍs�ԍ� (���i�p)
    Value: String; // �Ώےl
    Operation: TFilterOperation; // �i�荞�ݓ���
  end;

  TFilterConditions = array of TFilterCondition;

  TCustomDataOperationEvent = procedure(Sender: TObject; ASorts: TSortConditions; AFilters: TFilterConditions) of object;

//--- DEL 2010/10/21 Miyamoto ---------------------------------------------->>>>
(*THNsGrid�̒�`��Ɉړ�
  // --- ADD 2010/06/15 M.Kubota --------------------------------------------->>>
  THNsInplaceEdit = class(TAdvInplaceEdit)
  private
    procedure WMChar(var Msg: TWMKey); message WM_CHAR;
    // ADD 2010/09/01 M.Kubota
    procedure WMPaste(var Msg: TMessage); message WM_PASTE;
    // ADD 2010/09/01 M.Kubota
  published
    property ImeMode;
  end;
  // --- ADD 2010/06/15 M.Kubota ---------------------------------------------<<<
*)
//--- DEL 2010/10/21 Miyamoto ----------------------------------------------<<<<

  THNsGrid = class(TAdvStringGrid)
  private
    { Private �錾 }
    FOnGetImeMode: TGetImeModeEvent;
    FOnCellChanging: TCellChangingEvent;
    FOnCustomDataOperation: TCustomDataOperationEvent;
    FOnButtonClick: TButtonClickEvent;
    FOnGetWordWrap: TWordWrapEvent;
    FOnGetAlignment: TGridAlignEvent;
    FOnKeyDown: TKeyEvent;
    FOnClickCell: TClickCellEvent;
    FOnEditCellDone: TEditCellDoneEvent;
    FFixedCellClick: TFixedCellClickEvent;
    FSortConditions: TSortConditions; // ���݂̕��ёւ�����ێ�
    FFilterConditions: TFilterConditions; // ���݂̍i�荞�ݏ���ێ�
//    FPreFilterConditions: TFilterConditions; //2010/11/18 ADD �{�{ //2010/11/25 DEL �{�{
    FFilterGlyph: array [0 .. 1] of TBitmap;
    FRatioPhysicalToLogical: Integer;
    FLogicalRowCount: Integer;
    FLayout: TStringList;
    FLogicalCols: TStringList;
    FLogicalRows: TStringList;
    FAutoLayoutSet: Boolean;
    FFixedColStGridArray: array of array of TFixedColState;
    FActiveCellShow: Boolean;
    FLogicalScroll: Boolean; // 2010/06/04 ADD �{�{
    FCursorMode: TCursorMode; // 2010/06/04 ADD �{�{
    FSaveTopRow: Integer; // 2010/06/04 ADD �{�{
    FSaveLeftCol: Integer; // 2010/06/04 ADD �{�{
    FTopRowFlg: Boolean; // 2010/06/09 ADD �{�{
    FCellChang: Boolean; // 2010/06/10 ADD �{�{
    FActivate: Boolean; // 2010/06/10 ADD �{�{
    FCursorJump: Boolean; // 2010/09/13 ADD �{�{ #13189
    FActiveCellColorMode: Boolean; //2010/10/26 ADD �{�{

    x1, x2, y1, y2: Integer;
    mouseflg: Boolean;
    FDummyActiveCellShow: Boolean; // ADD 2010/04/26 M.Kubota
    FDummyShowSelection: Boolean; // ADD 2010/04/26 M.Kubota
    FInplaceEditImeMode: TImeMode; // ADD 2010/06/15 M.Kubota
    // --- ADD 2010/05/21 �{�{ ---------------------------------------------->>>>
    // FHookWndProc : Pointer;  //DEL 2010/06/30 M.Kubota
    // FAddress     : Pointer;  //DEL 2010/06/30 M.Kubota
    OwnerForm: TForm;
    // procedure HookWndProc( var Msg:TMessage );  //DEL 2010/06/30 M.Kubota
    // --- ADD 2010/05/21 �{�{ ----------------------------------------------<<<<

    // --- ADD 2010/09/17 H.Matsumoto --------------------------------------->>>>
    FIsNoInplaceEditorFocusing: Boolean; // ADD 2010/09/16 H.Matsumoto
    SelectCol: Integer;
    SelectRow: Integer;
    SelectVal: String;
    FOnNsCellValidate: TNsCellValidateEvent; // ADD 2010/09/16 H.Matsumoto
    // --- ADD 2010/09/17 H.Matsumoto ---------------------------------------<<<<
//--- ADD 2010/10/26 �{�{ -------------------------------------------------->>>>
    MouseMoveX :Integer;
    MouseMoveY :Integer;
//--- ADD 2010/10/26 �{�{ --------------------------------------------------<<<<
//--- ADD 2011/03/22 ���I -------------------------------------------------->>>>
    FOriValFlg: Boolean;
    FOriValue: String;
    FOriSet: Boolean;
//--- ADD 2011/03/22 ���I --------------------------------------------------<<<<

    procedure WMSetFocus(var Msg: TWMSetFocus); message WM_SETFOCUS;
    procedure DoCellChanging(Sender: TObject; OldRow, OldCol, NewRow, NewCol: Integer; var Allow: Boolean);
    procedure DoImeMode(Sender: TObject; ACol, ARow: Integer);
    procedure DoButtonClick(Sender: TObject; ACol, ARow: Integer);
    procedure DoGetAlignment(Sender: TObject; ARow, ACol: Integer; var HAlign: TAlignment; var VAlign: TVAlignment);
    procedure DoGetWordWrap(Sender: TObject; ACol, ARow: Integer; var WordWrap: Boolean);
    procedure DoKeyDown(Sender: TObject; var Key: Word; Shift: TShiftState);
    procedure DoClickCell(Sender: TObject; ARow, ACol: Integer);
    procedure DoFixedCellClick(Sender: TObject; ACol, ARow: Integer);
    procedure DoEditCellDone(Sender: TObject; ACol, ARow: Integer);
{$REGION '�y�d�l�ύX�ɔ����폜�z'}
    // procedure SetFilterGlyph;
{$ENDREGION}
    procedure RemoveFilterGlyph;
    function GetCellEx(c, r: Integer): String;
    procedure SetCellEx(c, r: Integer; const Value: String);

    procedure SetLayout(const Value: TStringList);
    // procedure SetLogicalCols(Aline,Index: Integer;const Value: TStrings);
    function GetLogicalCols(Aline, Index: Integer): TStrings;
    // procedure SetLogicalObjects(ACol,Aline, ARow: Integer;const Value: TObject);
    // function  GetLogicalObjects(ACol,Aline, ARow: Integer):TObject;
    // procedure SetLogicalRows(Index: Integer;const Value: TStrings);
    function GetLogicalRows(Index: Integer): TStrings;
    procedure SetAutoLayoutSet(const Value: Boolean);
    procedure SetLogicalCells(ACol, Aline, ARow: Integer; const Value: string);
    function GetLogicalCells(ACol, Aline, ARow: Integer): string;
    procedure SetLogicalRow(const Value: Integer);
    function GetLogicalRow: Integer;
    procedure SetLogicalLine(const Value: Integer);
    function GetLogicalLine: Integer;
    procedure SetLogicalRowCount(const Value: Integer);
    procedure SetGridLayout;
    procedure SetGridLayoutOnlyPart(StartLogicalRow, EndLogicalRow: Integer);
    procedure ChangeLineCountAtLogicalRow(OldLineCount, NewLineCount: Integer);
    procedure SetLogicalScroll(const Value: Boolean);
    procedure SetCursorMode(const Value: TCursorMode); // 2010/06/04 ADD �{�{

    procedure SetFixedRowsEx(Value: Integer);
    function GetFixedRowsEx: Integer;
    procedure SetFixedColsEx(Value: Integer);
    function GetFixedColsEx: Integer;

    function GetLogicalInts(ACol, Aline, ARow: Integer): Integer;
    function GetLogicalColors(ACol, Aline, ARow: Integer): TColor;
    function GetLogicalColorsTo(ACol, Aline, ARow: Integer): TColor;
    function GetLogicalFontColors(ACol, Aline, ARow: Integer): TColor;
    function GetLogicalReadOnly(ACol, Aline, ARow: Integer): Boolean;
    function GetLogicalFloats(ACol, Aline, ARow: Integer): Double;
    function GetLogicalDates(ACol, Aline, ARow: Integer): TDateTime;
    procedure SetLogicalInts(ACol, Aline, ARow: Integer; const Value: Integer);
    procedure SetLogicalColors(ACol, Aline, ARow: Integer; const Value: TColor);
    procedure SetLogicalColorsTo(ACol, Aline, ARow: Integer; const Value: TColor);
    procedure SetLogicalFontColors(ACol, Aline, ARow: Integer; const Value: TColor);
    procedure SetLogicalReadOnly(ACol, Aline, ARow: Integer; const Value: Boolean);
    procedure SetLogicalFloats(ACol, Aline, ARow: Integer; const Value: Double);
    procedure SetLogicalDates(ACol, Aline, ARow: Integer; const Value: TDateTime);
    function GetFixedColStatus(ACol, ARow: Integer): TFixedColState;
    procedure SetFixedColStatus(ACol, ARow: Integer; const Value: TFixedColState);
    procedure SetColCountEx(Value: Integer);
    function GetColCountEx: Integer;
    procedure SetActiveCellShow(Value: Boolean);
    procedure AllocateGridArray;
    procedure LogicalScrollChk(OldCol, OldRow, NewCol, NewRow: Integer); //2010/06/09 ADD �{�{
    procedure SetCursorJump(const Value: Boolean); //2010/09/13 ADD �{�{ #13189
    procedure SetActiveCellColorMode(const Value: Boolean); //2010/10/26 ADD �{�{
  protected
    { Protected �錾 }
    procedure DrawGridCell(Canvas: TCanvas; ACol, ARow: longint; ARect: TRect; AState: TGridDrawState); override;
    procedure Loaded; override;
    procedure MouseMove(Shift: TShiftState; X, Y: Integer); override;
    procedure MouseDown(Button: TMouseButton; Shift: TShiftState; X, Y: Integer); override;
    procedure MouseUp(Button: TMouseButton; Shift: TShiftState; X, Y: Integer); override;
    procedure SelectionChanged(ALeft, ATop, ARight, ABottom: Integer); override;
    function CreateEditor: TInplaceEdit; override;
    procedure DoExit; override; // 2010/04/22 ADD �{�{
    procedure DoEnter; override; // 2010/04/22 ADD �{�{
    // procedure ShowInplaceEdit;   //2010/05/20 ADD �{�{  // public�Ɉړ� 2010/06/15 M.Kubota
    procedure TopLeftChanged; override; // 2010/06/04 ADD �{�{
    procedure InitValidate(ACol, ARow: Integer); override; // 2010/06/10 ADD �{�{
    function CanEditShow: Boolean; override; //2010/12/21 ADD �{�{

    // --- ADD 2010/09/17 H.Matsumoto --------------------------------------->>>>
    function SelectCell(ACol, ARow: longint): Boolean; override;
    // --- ADD 2010/09/17 H.Matsumoto ---------------------------------------<<<<

  public
    { Public �錾 }
    constructor Create(AOwner: tComponent); override;
    destructor Destroy; override;
    procedure InsertLogicalRows(LogicalRowIndex, addLogicalRowCount: Integer; UpdateCellControls: Boolean = true);
    procedure RemoveLogicalRows(LogicalRowIndex, RemoveLogicalRowCount: Integer);
    procedure RemoveLogicalRowsEx(LogicalRowIndex, RemoveLogicalRowCount: Integer);
    procedure ReSetGridLayout;
    procedure GotoCell(Col, Row: Integer);
    procedure FocusCell(Col, Row: Integer);
    procedure LogicalFocusCell(ACol, Aline, ARow: Integer);
    // procedure UpdateFixedColIndicator;
    function NoInplaceEditorFocusing(Key: Word; Shift: TShiftState): Word;
    procedure NoInplaceEditorScrollInView(ColIndex, RowIndex: Integer);
    // ADD 2010/02/26 D.Shibuya
    function LogicalToPhysicalCell(ACol, Aline, ARow: Integer): TGridCoord;
    function LogicalIsEditable(ACol, Aline, ARow: Integer): Boolean;
    procedure GetVisualProperties(ACol, ARow: Integer; var AState: TGridDrawState; Print, Select, Remap: Boolean; ABrush: TBrush; var AColorTo, AMirrorColor, AMirrorColorTo: TColor; AFont: TFont; var HA: TAlignment; var VA: TVAlignment; var WW: Boolean; var GD: TCellGradientDirection); override;
    procedure CustomDataOperationClear(Sort: Boolean; Filter: Boolean);
    // ADD 2010/04/26 M.Kubota
    procedure ShowInplaceEdit; // ADD 2010/06/15 M.Kubota
    procedure HideInplaceEdit; // ADD 2010/06/15 M.Kubota
    procedure Clear; // ADD 2010/08/19 M.Kubota
    property LogicalCells[ACol, Aline, ARow: Integer]: string read GetLogicalCells write SetLogicalCells;
    property LogicalRow: Integer read GetLogicalRow write SetLogicalRow;
    property LogicalLine: Integer read GetLogicalLine write SetLogicalLine;
    property LogicalCols[Aline, Index: Integer]: TStrings read GetLogicalCols;
    property LogicalRows[Index: Integer]: TStrings read GetLogicalRows;
    // property LogicalCols[Aline,Index: Integer]: TStrings read GetLogicalCols write SetLogicalCols;
    // property LogicalObjects[ACol,Aline, ARow: Integer]: TObject read GetLogicalObjects write SetLogicalObjects;
    // property LogicalRows[Index: Integer]: TStrings read GetLogicalRows write SetLogicalRows;
    property Cells[c, r: Integer]: String read GetCellEx write SetCellEx;
    property LogicalInts[ACol, Aline, ARow: Integer]: Integer read GetLogicalInts write SetLogicalInts;
    property LogicalColors[ACol, Aline, ARow: Integer]: TColor read GetLogicalColors write SetLogicalColors;
    property LogicalColorsTo[ACol, Aline, ARow: Integer]: TColor read GetLogicalColorsTo write SetLogicalColorsTo;
    property LogicalFontColors[ACol, Aline, ARow: Integer]: TColor read GetLogicalFontColors write SetLogicalFontColors;
    property LogicalReadOnly[ACol, Aline, ARow: Integer]: Boolean read GetLogicalReadOnly write SetLogicalReadOnly;
    property LogicalFloats[ACol, Aline, ARow: Integer]: Double read GetLogicalFloats write SetLogicalFloats;
    property LogicalDates[ACol, Aline, ARow: Integer]: TDateTime read GetLogicalDates write SetLogicalDates;
    property FixedColStatus[ACol, ARow: Integer]: TFixedColState read GetFixedColStatus write SetFixedColStatus;
    function ValidateCell(const NewValue: string): Boolean; override;
    // 2010/06/10 ADD �{�{

    // --- ADD 2010/09/17 H.Matsumoto --------------------------------------->>>>
    property IsNoInplaceEditorFocusing: Boolean read FIsNoInplaceEditorFocusing write FIsNoInplaceEditorFocusing; // ADD 2010/09/16 H.Matsumoto
    // --- ADD 2010/09/17 H.Matsumoto ---------------------------------------<<<<

//--- ADD 2010/11/18 �{�{ -------------------------------------------------->>>>
    procedure SaveFilterConditions;
    procedure BackFilterConditions;
//--- ADD 2010/11/18 �{�{ --------------------------------------------------<<<<
//--- ADD 2010/11/18 �{�{ -------------------------------------------------->>>>
    procedure UpdateScrollBars(Refresh: Boolean);
//--- ADD 2010/11/18 �{�{ --------------------------------------------------<<<<

  published
    { Published �錾 }
    property FixedCols: Integer read GetFixedColsEx write SetFixedColsEx default 1;
    property FixedRows: Integer read GetFixedRowsEx write SetFixedRowsEx default 1;
    property ColCount: Integer read GetColCountEx write SetColCountEx;
    property AutoLayoutSet: Boolean read FAutoLayoutSet write SetAutoLayoutSet default False;
    property Layout: TStringList read FLayout write SetLayout;
    property LogicalRowCount: Integer read FLogicalRowCount write SetLogicalRowCount;
    property OnCellChanging: TCellChangingEvent read FOnCellChanging write FOnCellChanging;
    property OnGetImeMode: TGetImeModeEvent read FOnGetImeMode write FOnGetImeMode;
    property OnCustomDataOperation: TCustomDataOperationEvent read FOnCustomDataOperation write FOnCustomDataOperation;
    property OnButtonClick: TButtonClickEvent read FOnButtonClick write FOnButtonClick;
    property OnGetAlignment: TGridAlignEvent read FOnGetAlignment write FOnGetAlignment;
    property OnGetWordWrap: TWordWrapEvent read FOnGetWordWrap write FOnGetWordWrap;
    property OnKeyDown: TKeyEvent read FOnKeyDown write FOnKeyDown;
    property OnClickCell: TClickCellEvent read FOnClickCell write FOnClickCell;
    property OnFixedCellClick: TFixedCellClickEvent read FFixedCellClick write FFixedCellClick;
    // property ActiveCellShow: Boolean read FActiveCellShow write SetActiveCellShow default True;        //DEL 2010/04/26 M.Kubota
    property ActiveCellShow: Boolean read FDummyActiveCellShow write FDummyActiveCellShow default true; // ADD 2010/04/26 M.Kubota
    property ShowSelection: Boolean read FDummyShowSelection write FDummyShowSelection default true; // ADD 2010/04/26 M.Kubota
    property LogicalScroll: Boolean read FLogicalScroll write SetLogicalScroll default False; // 2010/06/04 ADD �{�{
    property CursorMode: TCursorMode read FCursorMode write SetCursorMode default cmDefault; // 2010/06/04 ADD �{�{
    property CursorJump: Boolean read FCursorJump write SetCursorJump default true;    // 2010/09/13 ADD �{�{ #13189
    //property ActiveCellColorMode: Boolean read FActiveCellColorMode write SetActiveCellColorMode default False; //2010/10/26 ADD �{�{ //2010/11/05 DEL 30146
    property ActiveCellColorMode: Boolean read FActiveCellColorMode write SetActiveCellColorMode default True; //2010/11/05 ADD 30146

    // �e��v���p�e�B��default�l�݂̂�ύX (�R���X�g���N�^�ł̏������͕K�v)
    property Options default[goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goAlwaysShowEditor, goTabs];
    property SelectionColor default $5EC1F1;
    property ActiveCellColor default $94E6FB;
    property ActiveCellColorTo default $1595EE;
    property DefaultRowHeight default 23;
    property FixedRowHeight default 26;
    property WordWrap default False; // ADD 2010/07/14 M.Kubota

    // --- ADD 2010/09/17 H.Matsumoto --------------------------------------->>>>
    property OnNsCellValidate: TNsCellValidateEvent read FOnNsCellValidate
    // ADD 2010/09/16 H.Matsumoto
      write FOnNsCellValidate; // ADD 2010/09/16 H.Matsumoto
    // --- ADD 2010/09/17 H.Matsumoto ---------------------------------------<<<<
  end;

//--- ADD 2010/10/21 Miyamoto ---------------------------------------------->>>>
  // --- ADD 2010/06/15 M.Kubota --------------------------------------------->>>
  THNsInplaceEdit = class(TAdvInplaceEdit)
  private
    FGrid: THNsGrid;  //ADD 2010/10/21 Miyamoto

    procedure WMChar(var Msg: TWMKey); message WM_CHAR;
    // ADD 2010/09/01 M.Kubota
    procedure WMPaste(var Msg: TMessage); message WM_PASTE;
    // ADD 2010/09/01 M.Kubota
    procedure WMSetFocus(var Msg: TWMSetFocus); message WM_SETFOCUS; //2010/10/26 ADD �{�{
  protected
    procedure BoundsChanged; override; //ADD 2010/10/21 Miyamoto
  published
    property ImeMode;
  end;
  // --- ADD 2010/06/15 M.Kubota ---------------------------------------------<<<
//--- ADD 2010/10/21 Miyamoto ----------------------------------------------<<<<

const
  FilterOperationName: array [TFilterOperation] of String = ('�Ɠ�����', '�Ɠ������Ȃ�', '���傫��', '�ȏ�', '��菬����', '�ȉ�', '���܂�', '���܂܂Ȃ�', '�|�󔒁|', '�|�󔒈ȊO�|');
  FilterRelationName: array [TFilterRelation] of String = ('', '����', '�܂���');

procedure Register;

implementation

uses
  HNsGridFilterDlg;

// --- ADD 2010/06/30 M.Kubota --------------------------------------------->>>>>
var
  OrgWndProc: Pointer;

  PreFilterConditions: TFilterConditions; //2010/11/25 ADD �{�{


function NewWndProc(hwnd: hwnd; iMsg: UINT; wParam: wParam; lParam: lParam): LRESULT; stdcall;
var
  iForms: Integer;
  iComps: Integer;
  wForm: TForm;
  wGrid: THNsGrid;
begin
  if (iMsg = WM_ACTIVATE) then
  begin
    wForm := nil;

    for iForms := 0 to Screen.FormCount - 1 do
    begin
      if (Screen.Forms[iForms].Handle = hwnd) then
        wForm := Screen.Forms[iForms];
    end;

    if Assigned(wForm) then
    begin
      for iComps := 0 to wForm.ComponentCount - 1 do
      begin
        if (wForm.Components[iComps] is THNsGrid) then
        begin
          wGrid := wForm.Components[iComps] as THNsGrid;

          with wGrid do
          begin

//--- ADD 2011/03/22 ���I -------------------------------------------------->>>>
            wGrid.FOriSet:= False;
//--- ADD 2011/03/22 ���I --------------------------------------------------<<<<

            if (wParam <> WA_INACTIVE) then
            begin
              if not((Row < TopRow) or (Col < LeftCol)) then
              begin
                if IsEditable(Col, Row) and (Assigned(NormalEdit)) then
                begin
                  if (wForm.ActiveControl = wGrid) then
                  begin
                    NormalEdit.SetFocus;
                  end;
                end;
              end;
              wGrid.FActivate := true;
//--- ADD 2011/03/22 ���I -------------------------------------------------->>>>
              wGrid.FOriSet:= True;

              //Debug�p���i�R�����g�A�E�g�j
              //OutPutDebugString(pChar(wGrid.Name + ' �t���O�Z�b�g'));

              //Active�Ɠ����ɈႤ�Z�����N���b�N���ꂽ�p�̏���
              if (FOriSet = True) and (FOriValFlg = True) then begin
                FCellCache := FOriValue;

                //Debug�p���i�R�����g�A�E�g�j
                //OutPutDebugString(pChar(Name +'Set:' + FOriValue));
              end;
//--- ADD 2011/03/22 ���I --------------------------------------------------<<<<
            end
            else
            begin
              wGrid.FActivate := False;
//--- ADD 2011/03/22 ���I -------------------------------------------------->>>>
              if (FOriValFlg = False) and
                 (Trim(OriginalCellValue) <> Trim(Cells[Col,Row])) then begin
                FOriValue := OriginalCellValue;
                FOriValFlg := True;

                //Debug�p���i�R�����g�A�E�g�j
                //OutPutDebugString(pChar(wGrid.Name + ' Get:' + wGrid.FOriValue));

              end;
//--- ADD 2011/03/22 ���I --------------------------------------------------<<<<

            end;
          end;
        end;
      end;
    end;
  end;

  Result := CallWindowProc(OrgWndProc, hwnd, iMsg, wParam, lParam);
end;

// --- ADD 2010/06/30 M.Kubota ---------------------------------------------<<<<<

// =============================================================================
// �R���|�[�l���g�o�^���
// RegisterPropertyEditor��
// TypeInfo(XXXX)   XXXX�̓v���p�e�B�̌^(String�^�Ȃ�String�Ƃ���)
// TMyCompB         �R���|�[�l���g��
// 'Info'           �o�^����v���p�e�B�̖��O
// TInfoProperty    �����Œ�`�����v���p�e�B�G�f�B�^�N���X��
// =============================================================================
procedure Register;
begin
  RegisterComponents('HSS', [THNsGrid]);
end;

{ TModStringGrid }

constructor THNsGrid.Create(AOwner: tComponent);
begin
  inherited Create(AOwner);

  SelectCol := -1;
  SelectRow := -1;

  AllocateGridArray;

  DoubleBuffered := true;

  FOnGetImeMode := nil;
  FOnCellChanging := nil;
  FOnGetWordWrap := nil;
  FOnGetAlignment := nil;
  FOnKeyDown := nil;
  FOnClickCell := nil;
  FFixedCellClick := nil;
  FOnEditCellDone := nil;

  inherited OnGetAlignment := DoGetAlignment;
  inherited OnGetWordWrap := DoGetWordWrap;
  inherited OnCellChanging := DoCellChanging;
  inherited OnButtonClick := DoButtonClick;
  inherited OnKeyDown := DoKeyDown;
  inherited OnClickCell := DoClickCell;
  inherited OnFixedCellClick := DoFixedCellClick;
  inherited OnEditCellDone := DoEditCellDone;

  SetLength(FSortConditions, 0);
  SetLength(FFilterConditions, 0);

  FFilterGlyph[0] := TBitmap.Create;
  FFilterGlyph[0].LoadFromResourceName(hInstance, 'Filter');
  FFilterGlyph[1] := TBitmap.Create;
  FFilterGlyph[1].LoadFromResourceName(hInstance, 'Filtered');

  Options := Options - [goRangeSelect];
  Options := Options + [goAlwaysShowEditor, goTabs];

  // �^�C�g���s�̑����𖳂���
  FixedFont.Style := [];

  // ����.NS�V���[�Y�ɍ����āA�W���� Office2003 ���ɂ���
  SelectionColor := $5EC1F1;
  SelectionTextColor := clBlack;
  TMSGradientFrom := $D68759;
  TMSGradientTo := $963B07;
  TMSGradientMirrorFrom := clNone;
  TMSGradientMirrorTo := clNone;
  ActiveCellColor := $94E6FB;
  ActiveCellColorTo := $1595EE;
  ActiveCellFont.Color := clBlack;
  ActiveCellFont.Style := [];
  GridLineColor := clSilver;
  GridFixedLineColor := clGray;

  FixedFont.Color := clWhite;

  DefaultRowHeight := 23;
  FixedRowHeight := 26;

  FAutoLayoutSet := False;
  FLayout := TStringList.Create;
  FLayout.Add(Format('%D,%D', [FixedCols, FixedRows]));

  FLogicalCols := TStringList.Create;
  FLogicalRows := TStringList.Create;

  FLogicalRowCount := 2;
  FRatioPhysicalToLogical := 1;
  FLogicalScroll := False; // 2010/06/04 ADD �{�{
  FCursorMode := cmDefault; // 2010/06/04 ADD �{�{

  // FActiveCellShow := True;  //DEL 2010/04/26 M.Kubota
  FActiveCellShow := False; // ADD 2010/04/26 M.Kubota

  FCursorJump := true; // 2010/09/13 ADD �{�{ #13189
  //FActiveCellColorMode := False; //2010/10/26 ADD �{�{ //2010/11/05 DEL 30146
  ActiveCellColorMode := True; //2010/11/05 ADD 30146

  inherited ActiveCellShow := False;

  // �݌v���ɂ̂ݏ����ݒ肪�K�v�ȃv���p�e�B�Q
  if (csDesigning in ComponentState) then
  begin
    Bands.Active := true;
    Bands.PrimaryColor := clWhite;
    Bands.SecondaryColor := $FAE6E6;

    SearchFooter.Color := TMSGradientFrom;
    SearchFooter.ColorTo := TMSGradientMirrorTo;

    ControlLook.FixedGradientFrom := TMSGradientFrom;
    ControlLook.FixedGradientTo := TMSGradientTo;

    Navigation.TabToNextAtEnd := true;
    MouseActions.AutoSizeColOnDblClick := False;
  end;

  // �����̃v���p�e�B�͏�� False �Ƃ��� --->>>
  Navigation.AdvanceOnEnter := False;
  Navigation.CursorWalkEditor := False;
  MouseActions.DirectComboDrop := False;
  MouseActions.DirectDateDrop := False;
  MouseActions.DirectEdit := False;
  // �����̃v���p�e�B�͏�� False �Ƃ��� ---<<<

  // 2010/04/22 ADD �{�{ >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
  // ActiveCellShow := False;
  // ShowSelection  := False;

  FDummyActiveCellShow := true;
  FDummyShowSelection := true;

  SetActiveCellShow(False);
  inherited ShowSelection := False;
  // 2010/04/22 ADD �{�{ <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

  mouseflg := False;
{$REGION '<<<<--- DEL 2010/06/30 M.Kubota -------------------------------------------->>>>'}
  {
    //2010/05/21 ADD �{�{ >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    if not(csDesigning in ComponentState) then
    begin
    // �t�b�N�J�n
    OwnerForm := TForm(Owner);
    FHookWndProc := MakeObjectInstance(HookWndProc);
    FAddress := Pointer(SetWindowLong(OwnerForm.Handle, GWL_WNDPROC, Longint(FHookWndProc)));
    end;
    //2010/05/21 ADD �{�{ <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    }
{$ENDREGION}
  // --- ADD 2010/06/30 M.Kubota -------------------------------------------->>>>
  if not(csDesigning in ComponentState) and (not Assigned(OrgWndProc)) then
  begin
    // �t�b�N�J�n
    OwnerForm := TForm(Owner);
    OrgWndProc := Pointer(SetWindowLong(OwnerForm.Handle, GWL_WNDPROC, DWORD(@NewWndProc)));
  end;
  // --- ADD 2010/06/30 M.Kubota --------------------------------------------<<<<

  FInplaceEditImeMode := imDisable; // ADD 2010/06/15 M.Kubota

  FTopRowFlg := true; // 2010/06/18 ADD �{�{
  FCellChang := true; // 2010/06/18 ADD �{�{
  FActivate := true; // 2010/06/18 ADD �{�{

  WordWrap := False; // ADD 2010/07/14 M.Kubota  �W����"�܂�Ԃ��֎~"�ɂ���B

//--- ADD 2010/10/26 �{�{ -------------------------------------------------->>>>
  MouseMoveX := -1;
  MouseMoveY := -1;
//--- ADD 2010/10/26 �{�{ --------------------------------------------------<<<<

//--- ADD 2011/03/22 ���I -------------------------------------------------->>>>
  FOriValue  := '';
  FOriValFlg := False;
  FOriSet := False;
//--- ADD 2011/03/22 ���I --------------------------------------------------<<<<

end;

function THNsGrid.CreateEditor: TInplaceEdit;
var
  InplaceEdit: THNsInplaceEdit; // ADD 2010/06/15 M.Kubota
begin
  // Result := inherited CreateEditor;      //DEL 2010/06/15 M.Kubota

  // --- ADD 2010/06/15 M.Kubota -------------------------------------------->>>>
  // ����IME���[�h��ݒ肷��ׂɁA�Ǝ��� InplaceEdit �𐶐�����
  InplaceEdit := THNsInplaceEdit.Create(Self);
  InplaceEdit.ImeName := ImeName;
  InplaceEdit.ImeMode := FInplaceEditImeMode;

  InplaceEdit.FGrid := THNsGrid(Self); //--- ADD 2010/10/21 Miyamoto

  Result := InplaceEdit;
  // --- ADD 2010/06/15 M.Kubota --------------------------------------------<<<<
end;

// --- ADD 2010/04/26 M.Kubota ---------------------------------------------->>>>
procedure THNsGrid.CustomDataOperationClear(Sort: Boolean; Filter: Boolean);
var
  cg: TCellGraphic;
  iCnt: Integer;
  wCol, wRow: Integer;
begin
  if (Sort or Filter) then
  begin
    if (Sort) then
      SetLength(FSortConditions, 0);
    if (Filter) then
      SetLength(FFilterConditions, 0);

    BeginUpdate;
    try
      Self.FilterActive := False;

      for wCol := 0 to ColCount - 1 do
      begin
        for wRow := 0 to FixedRows - 1 do
        begin
          FixedColStatus[wCol, wRow] := FixedColStatus[wCol, wRow];
        end;
      end;

      if (not Filter) then
      begin
        for iCnt := 0 to Length(FFilterConditions) - 1 do
        begin
          cg := GetCellGraphic(FFilterConditions[iCnt].ColNo, FFilterConditions[iCnt].RowNo);

          if (Assigned(cg) and (cg.CellType in [ctButton, ctBitButton])) then
          begin
            cg.CellBitmap := FFilterGlyph[1];
          end;
        end;
      end;

      if (Assigned(FOnCustomDataOperation)) then
      begin
        FOnCustomDataOperation(Self, FSortConditions, FFilterConditions);
      end;
    finally
      EndUpdate;
    end;
  end;
end;
// --- ADD 2010/04/26 M.Kubota ----------------------------------------------<<<<

destructor THNsGrid.Destroy;
begin
{$REGION '<<<<--- DEL 2010/06/30 M.Kubota -------------------------------------------->>>>'}
  {
    //--- ADD 2010/05/21 �{�{ ------------------------------------------------>>>>
    //�t�b�N�I��
    if not(csDesigning in ComponentState) then
    FreeObjectInstance(FHookWndProc);
    //--- ADD 2010/05/21 �{�{ ------------------------------------------------<<<<
    }
{$ENDREGION}
  FLayout.Free;
  FLogicalCols.Free;
  FLogicalRows.Free;
  FFilterGlyph[0].Free;
  FFilterGlyph[1].Free;
  RemoveFilterGlyph;

  SetLength(FFixedColStGridArray, 0, 0);

  inherited OnGetAlignment := nil;
  inherited OnGetWordWrap := nil;
  inherited OnCellChanging := nil;
  inherited OnButtonClick := nil;
  inherited OnKeyDown := nil;
  inherited OnClickCell := nil;
  inherited OnFixedCellClick := nil;
  inherited OnEditCellDone := nil;

  inherited;
end;

procedure THNsGrid.DoButtonClick(Sender: TObject; ACol, ARow: Integer);
var
  cg: TCellGraphic;
  ButtonRect: TRect;
  CellPos: TPoint;
  CursorPos: TPoint;
  // FilterBtnClick: Boolean;
  // RepaintCell  : TGridRect;
  // RepaintRect  : TRect;
  OlgFixedRows: Integer;
  iCnt: Integer;
  wCol, wRow: Integer;
begin

  if Assigned(FOnButtonClick) then
  begin
    FOnButtonClick(Sender, ACol, ARow);
  end;

  // �t�B���^�[�����w��
  if (FixedColStatus[ACol, ARow] in [csFilter, csBoth]) then
  begin
    cg := GetCellGraphic(ACol, ARow);

    if (Assigned(cg) and (cg.CellType in [ctButton, ctBitButton])) then
    begin
      CellPos := CellRect(ACol, ARow).TopLeft;

      ButtonRect.Top := HIWORD(Trunc(cg.CellValue));
      ButtonRect.Left := LOWORD(Trunc(cg.CellValue));
      ButtonRect.Right := ButtonRect.Left + LOWORD(cg.CellIndex);
      ButtonRect.Bottom := ButtonRect.Top + HIWORD(cg.CellIndex);

      OffsetRect(ButtonRect, CellPos.X, CellPos.Y);

      GetCursorPos(CursorPos);
      CursorPos := ScreenToClient(CursorPos);

      if (PtInRect(ButtonRect, CursorPos)) then
      begin
        // �i�荞�ݏ����ݒ��ʕ\��
        if (ShowFilterDlg(Self, ACol, ARow, FFilterConditions) = mrOk) then
        begin
          BeginUpdate;
          try
            for wCol := 0 to ColCount - 1 do
            begin
              for wRow := 0 to FixedRows - 1 do
              begin
                FixedColStatus[wCol, wRow] := FixedColStatus[wCol, wRow];
              end;
            end;

            for iCnt := 0 to Length(FFilterConditions) - 1 do
            begin
              cg := GetCellGraphic(FFilterConditions[iCnt].ColNo, FFilterConditions[iCnt].RowNo);

              if (Assigned(cg) and (cg.CellType in [ctButton, ctBitButton])) then
              begin
                cg.CellBitmap := FFilterGlyph[1];
              end;
            end;

            if (Assigned(FOnCustomDataOperation)) then
            begin
              OlgFixedRows := FixedRows;
              FOnCustomDataOperation(Sender, FSortConditions, FFilterConditions);

              if ((Self.Filter.Count > 0) and (Self.RowCount = OlgFixedRows)) then
              begin
                MessageDlg('�i���ݏ����Ɉ�v����s���L��܂���', mtConfirmation, [mbOk], 0);
                Self.CustomDataOperationClear(False, true);
              end;
            end;

          finally
            EndUpdate;
          end;
        end;
      end;
    end;
  end;
{$REGION '�y�d�l�ύX�ɔ����폜�z'}
  {
    if (CustomDataOperation <> coNone) and (ACol > FixedCols - 1) then
    begin
    //FilterBtnClick := False;

    // �t�B���^�[�����w��
    if (CustomDataOperation in [coFilter, coBoth]) then
    begin
    cg := GetCellGraphic(ACol, Arow);

    if (Assigned(cg) and (cg.CellType in [ctButton, ctBitButton])) then
    begin
    CellPos := CellRect(ACol, ARow).TopLeft;

    ButtonRect.Top    := HIWORD(Trunc(cg.CellValue));
    ButtonRect.Left   := LOWORD(Trunc(cg.CellValue));
    ButtonRect.Right  := ButtonRect.Left + LOWORD(cg.CellIndex);


    OffsetRect(ButtonRect, CellPos.X, CellPos.Y);

    GetCursorPos(CursorPos);
    CursorPos := ScreenToClient(CursorPos);

    if (PtInRect(ButtonRect, CursorPos)) then
    begin
    //FilterBtnClick := True;

    // �i�荞�ݏ����ݒ��ʕ\��
    if (ShowFilterDlg(Self, ACol, ARow, FFilterConditions) <> mrOk) then
    begin
    // �i�荞�ݏ����w�肪�L�����Z�����ꂽ�̂ŁAOnCustomDataOperation
    // �C�x���g���������Ȃ��B
    Exit;
    end;
    end;
    end;
    end;

    // �\�[�g�����w��
    if ((not FilterBtnClick) and (CustomDataOperation in [coSort, coBoth])) then
    begin
    RepaintCell.Top    := -1;
    RepaintCell.Left   := -1;
    RepaintCell.Bottom := -1;
    RepaintCell.Right  := -1;

    // �^�C�g���N���b�N�ɂ����בւ��́A�P������ł̂ݍs��
    if (Length(FSortConditions) = 0) then
    begin
    SetLength(FSortConditions, 1);
    FSortConditions[0].Priority  :=  0;
    FSortConditions[0].ColNo     := -1;
    FSortConditions[0].RowNo     := -1;
    FSortConditions[0].Direction := sdAscending;  // ����
    end;

    if ((FSortConditions[0].ColNo = ACol) and
    (FSortConditions[0].RowNo = ARow))then
    begin
    case FSortConditions[0].Direction of
    sdAscending :
    begin
    // ���� �� �~��
    FSortConditions[0].Direction := sdDescending;
    end;
    sdDescending:
    begin
    // �~�� �� ����
    SetLength(FSortConditions, 0);
    end;
    end;
    end else
    begin
    with FSortConditions[0] do
    begin
    if ((ColNo > -1) and (RowNo > -1)) then
    begin
    RepaintRect        := FullCell(ColNo, RowNo);
    RepaintCell.Top    := RepaintRect.Top;
    RepaintCell.Left   := RepaintRect.Left;
    RepaintCell.Bottom := RepaintRect.Bottom;
    RepaintCell.Right  := RepaintRect.Right;
    end;

    ColNo := ACol;
    RowNo := ARow;
    Direction := sdAscending;  // ����
    end;
    end;
    end;

    BeginUpdate;  // �ĕ\�����̃`�������y������ړI�ŁA�`����ꎞ��~����
    try
    if ((CustomDataOperation <> coNone) and Assigned(FOnCustomDataOperation)) then
    begin
    FOnCustomDataOperation(Sender, FSortConditions, FFilterConditions);
    end;

    if ((RepaintCell.Top    > -1) and
    (RepaintCell.Left   > -1) and
    (RepaintCell.Bottom > -1) and
    (RepaintCell.Right  > -1)) then
    begin
    InvalidateGridRect(RepaintCell);
    end;
    finally
    EndUpdate;  // �`����ĊJ����
    end;
    end;
    }
{$ENDREGION}
end;

procedure THNsGrid.DoCellChanging(Sender: TObject; OldRow, OldCol, NewRow, NewCol: Integer; var Allow: Boolean);
var
  OGrdRct, NGrdRct: TGridRect;
  // --- ADD 2010/09/17 H.Matsumoto --------------------------------------->>>>
  Value: String;
  iRow, iCol: Integer;
  // --- ADD 2010/09/17 H.Matsumoto ---------------------------------------<<<<
begin
  OGrdRct := TGridRect(FullCell(OldCol, (OldRow mod FRatioPhysicalToLogical)));
  NGrdRct := TGridRect(FullCell(NewCol, (NewRow mod FRatioPhysicalToLogical)));

  InvalidateGridRect(OGrdRct);
  InvalidateGridRect(NGrdRct);

  if IsMergedCell(NewCol, NewRow) and (not IsBaseCell(NewCol, NewRow)) then
  begin
    Allow := False; // ADD 2010.09.17
    Exit;
  end;

  // --- ADD 2010/09/17 H.Matsumoto --------------------------------------->>>>
  // IsNoInplaceEditorFocusing����Ă΂��ꍇ�͍ŐV�̏����g�p���Ė��Ȃ��B
  // �������A���̑���AdvStringGrid������̃C�x���g(KeyDown��)���璼�ڌĂ΂��ꍇ
  // Cells�̏��͕s����ɂȂ�B
  // ��ʑ���Cells�̒��g�����������Ă��܂����Ƃ�����
  if Assigned(OnNsCellValidate) then
  begin
    if (IsNoInplaceEditorFocusing) then
    begin
      iRow := OldRow;
      iCol := OldCol;
      Value := Cells[iCol, iRow];
      SelectVal := Value;
    end
    else
    begin
      iRow := SelectRow;
      iCol := SelectCol;
      Value := SelectVal;
    end;
    if not((NewCol = iCol) and (NewRow = iRow)) then
    begin
      FOnNsCellValidate(Self, SelectCol, SelectRow, Value, Allow, true);
    end;
  end;
  // --- ADD 2010/09/17 H.Matsumoto ---------------------------------------<<<<

  if Assigned(FOnCellChanging) and Allow then
  begin
    FOnCellChanging(Sender, OldRow, OldCol, NewRow, NewCol, Allow);
  end;

  if (Self.ColWidths[NewCol] = 0) then
    Allow := False; // ADD 2010/04/26 M.Kubota

  FCellChang := False; // 2010/06/10 ADD �{�{
  if (Allow) then
  begin
    FCellChang := true; // 2010/06/10 ADD �{�{
    // DoImeMode(Sender, NewCol, NewRow);  //DEL 2010/06/15 M.Kubota �� ShowInplaceEdit �Ɉړ�
    LogicalScrollChk(OldCol, OldRow, NewCol, NewRow); // 2010/06/09 ADD �{�{
  end;
end;

procedure THNsGrid.DoClickCell(Sender: TObject; ARow, ACol: Integer);
var
  lx1, lx2, ly1, ly2: Integer;
begin
  if Assigned(FOnClickCell) then
  begin
    FOnClickCell(Sender, ARow, ACol);
  end;

  // �Œ����N���b�N���ƁA�����t�H�[�J�X���ړ��������̂悤�ȕ`�挋�ʂɂȂ��Ă��܂��s����C��
  // if (goRowSelect in Options) then                                //DEL 2010/02/26
  if ((not IsFixed(ACol, ARow)) and (goRowSelect in Options)) then
  // ADD 2010/02/26
  begin
    lx1 := FixedCols;
    lx2 := ColCount - 1;
    ly1 := (ARow div FRatioPhysicalToLogical) * FRatioPhysicalToLogical;
    ly2 := (ARow div FRatioPhysicalToLogical) * FRatioPhysicalToLogical + FRatioPhysicalToLogical - 1;
    SelectRange(lx1, lx2, ly1, ly2); // �p����TAdvStringGrid�̕s��H����̂��߁Ay1,y2����ւ��Ă܂�
    SelectRange(lx1, lx2, ly2, ly1); // �p����TAdvStringGrid�̕s��H����̂��߁Ay1,y2����ւ��Ă܂�
  end;

  // MouseActions.DirectEdit = True �Ƃ���ƁACellValidate �� Valid := False ��
  // �����ꍇ�ł��Z���̈ړ����s���Ă��܂��ׁA��֍�
  if IsEditable(ACol, ARow) then
  begin
    ShowInplaceEdit;
  end;

end;

procedure THNsGrid.DoFixedCellClick(Sender: TObject; ACol, ARow: Integer);
var
  RepaintCell: TGridRect;
  RepaintRect: TRect;
  cg: TCellGraphic;
  ButtonRect: TRect;
  CellPos: TPoint;
  CursorPos: TPoint;
begin
  if Assigned(FFixedCellClick) then
  begin
    FFixedCellClick(Sender, ACol, ARow);
  end;

  with BaseCell(ACol, ARow) do
  begin
    ACol := X;
    ARow := Y;
  end;

  if (FixedColStatus[ACol, ARow] in [csSort, csBoth]) then
  begin
    cg := GetCellGraphic(ACol, ARow);

    if (Assigned(cg) and (cg.CellType in [ctButton, ctBitButton])) then
    begin
      CellPos := CellRect(ACol, ARow).TopLeft;

      ButtonRect.Top := HIWORD(Trunc(cg.CellValue));
      ButtonRect.Left := LOWORD(Trunc(cg.CellValue));
      ButtonRect.Right := ButtonRect.Left + LOWORD(cg.CellIndex);
      ButtonRect.Bottom := ButtonRect.Top + HIWORD(cg.CellIndex);

      OffsetRect(ButtonRect, CellPos.X, CellPos.Y);

      GetCursorPos(CursorPos);
      CursorPos := ScreenToClient(CursorPos);

      if (PtInRect(ButtonRect, CursorPos)) then
      begin
        Exit;
      end;
    end;

    // �\�[�g�����w��
    RepaintRect := Rect(-1, -1, -1, -1);

    // �^�C�g���N���b�N�ɂ����בւ��́A�P������ł̂ݍs��
    if (Length(FSortConditions) = 0) then
    begin
      SetLength(FSortConditions, 1);
      FSortConditions[0].Priority := 0;
      FSortConditions[0].ColNo := -1;
      FSortConditions[0].RowNo := -1;
      FSortConditions[0].Direction := sdAscending; // ����
    end;

    if ((FSortConditions[0].ColNo = ACol) and (FSortConditions[0].RowNo = ARow)) then
    begin
      case FSortConditions[0].Direction of
        sdAscending:
          begin
            // ���� �� �~��
            FSortConditions[0].Direction := sdDescending;
          end;
        sdDescending:
          begin
            // �~�� �� ����
            SetLength(FSortConditions, 0);
          end;
      end;
    end
    else
    begin
      with FSortConditions[0] do
      begin
        if ((ColNo > -1) and (RowNo > -1)) then
        begin
          RepaintRect := FullCell(ColNo, RowNo);
        end;

        ColNo := ACol;
        RowNo := ARow;
        Direction := sdAscending; // ����
      end;
    end;

    BeginUpdate; // �ĕ\�����̃`�������y������ړI�ŁA�`����ꎞ��~����
    try
      if (Assigned(FOnCustomDataOperation)) then
      begin
        FOnCustomDataOperation(Sender, FSortConditions, FFilterConditions);
      end;

      if ((RepaintRect.Top > -1) and (RepaintRect.Left > -1) and (RepaintRect.Bottom > -1) and (RepaintRect.Right > -1)) then
      begin
        RepaintCell.Top := RepaintRect.Top;
        RepaintCell.Left := RepaintRect.Left;
        RepaintCell.Bottom := RepaintRect.Bottom;
        RepaintCell.Right := RepaintRect.Right;

        InvalidateGridRect(RepaintCell);
      end;
    finally
      EndUpdate; // �`����ĊJ����
    end;

  end;
end;

procedure THNsGrid.DoGetAlignment(Sender: TObject; ARow, ACol: Integer; var HAlign: TAlignment; var VAlign: TVAlignment);
begin
  if (ARow < FixedRows) then
  begin
    VAlign := vtaCenter;
  end;

  if Assigned(FOnGetAlignment) then
  begin
    FOnGetAlignment(Sender, ARow, ACol, HAlign, VAlign);
  end;
end;

procedure THNsGrid.DoGetWordWrap(Sender: TObject; ACol, ARow: Integer; var WordWrap: Boolean);
begin
  if (ARow < FixedRows) then
  begin
    WordWrap := False;
  end;

  if Assigned(FOnGetWordWrap) then
  begin
    FOnGetWordWrap(Sender, ACol, ARow, WordWrap);
  end;
end;

procedure THNsGrid.DoImeMode(Sender: TObject; ACol, ARow: Integer);
var
  AImeMode: TImeMode;
begin
  if (Assigned(FOnGetImeMode)) then
  begin
    // IME���[�h�� default �� imDisable �Ƃ���
    AImeMode := imDisable;

    FOnGetImeMode(Sender, ACol, ARow, AImeMode);
{$REGION '<<<<--- DEL 2010/06/15 M.Kubota ---------------------------------------->>>>'}
    {
      // imDisable ���w�肳�ꂽ�ꍇ�A�����ڂ̌���������ׂɈ�x����
      if (AImeMode = imDisable) then
      begin
      ImeMode := imClose;
      SetIme;
      end;

      // �w�肳�ꂽIME���[�h�ɏ]���āAIME�̏�Ԃ�ύX����
      ImeMode := AImeMode;
      SetIme;
      }
{$ENDREGION}
    // --- ADD 2010/06/15 M.Kubota ------------------------------------------>>>>
    FInplaceEditImeMode := AImeMode;

    if (NormalEdit is THNsInplaceEdit) then // NULL����������ɍs��
    begin
      // Grid�{�̂ł͂Ȃ��A�ҏW�G�f�B�b�g���̂�ImeMode�𒼐ڕύX����
      THNsInplaceEdit(NormalEdit).ImeMode := AImeMode;
    end;
    // --- ADD 2010/06/15 M.Kubota ------------------------------------------<<<<
  end;
end;

// --- ADD 2010/04/22 �{�{ -------------------------------------------------->>>>
procedure THNsGrid.DoExit;
var
  Valid : Boolean;
  // --- ADD 2010/09/22 H.Matsumoto --------------------------------------->>>>
  Value : String;
  Allow : Boolean;
  // --- ADD 2010/09/22 H.Matsumoto ---------------------------------------<<<<
begin
  // --- ADD 2010/09/22 H.Matsumoto --------------------------------------->>>>
  Allow := True;
  Value := Self.Cells[Col,Row];
  if Assigned(OnNsCellValidate) then
  begin
    FOnNsCellValidate(Self, Col, Row, Value, Allow, false);
  end;
  //09/22
  if Allow then begin
    ValidateCell(Value);
  end;

  if Allow then begin
    inherited DoExit;
    SetActiveCellShow(False);
    inherited ShowSelection := False;
  end else begin
    SetFocus;
    GotoCell(Col,Row);
    ShowInplaceEdit;
  end;
  // --- ADD 2010/09/22 H.Matsumoto ---------------------------------------<<<<
  // --- DEL 2010/09/22 H.Matsumoto --------------------------------------->>>>
  // inherited DoExit;
  // ActiveCellShow := False;  //DEL 2010/04/26 M.Kubota
  // ShowSelection := False;   //DEL 2010/04/26 M.Kubota
  // --- DEL 2010/09/22 H.Matsumoto ---------------------------------------<<<<
end;

procedure THNsGrid.DoEnter;
begin

  inherited DoEnter;
  //ActiveCellShow := True; //DEL 2010/04/26 M.Kubota
  //ShowSelection  := True; //DEL 2010/04/26 M.Kubota

  SetActiveCellShow(FDummyActiveCellShow); // ADD 2010/04/26 M.Kubota
  inherited ShowSelection := FDummyShowSelection; // ADD 2010/04/26 M.Kubota

  FSaveTopRow := Self.TopRow; // 2010/06/04 ADD �{�{
  FSaveLeftCol := Self.LeftCol; // 2010/06/04 ADD �{�{

  FTopRowFlg := true; // 2010/06/09 ADD �{�{

  FCellChang := true; // 2010/06/10 ADD �{�{
  FActivate := true; // 2010/06/10 ADD �{�{
end;
// --- ADD 2010/04/22 �{�{ --------------------------------------------------<<<<

procedure THNsGrid.DoKeyDown(Sender: TObject; var Key: Word; Shift: TShiftState);
var
  Value: string;
  Valid: Boolean;
begin
//--- ADD 2010/11/01 �{�{ -------------------------------------------------->>>>
  //Enter�L�[��A�ł�������CellValidate�C�x���g�����s����Ȃ��ꍇ������ׁA
  //KeyDown�ł�Enter�L�[�̎擾�ŋ����I��CellValidate�C�x���g�����s����B
  //���ʏ��Enter������CellValidate�C�x���g��KeyDown(key=VK_TAB)
  if (key = VK_RETURN) then begin
    Value := Cells[Col,Row];
    Valid := True;
    if (Assigned(OnGetEditText)) then  //ADD:2010.11.04 30146  redmine#16777
    begin                              //ADD:2010.11.04 30146  redmine#16777
      OnGetEditText(Sender,Col,Row,Value);
    end;                               //ADD:2010.11.04 30146  redmine#16777
    if (Assigned(OnCellValidate)) then //ADD:2010.11.04 30146  redmine#16777
    begin                              //ADD:2010.11.04 30146  redmine#16777
      OnCellValidate(Sender,Col,Row,Value,Valid);
    end;                               //ADD:2010.11.04 30146  redmine#16777
  end;
//--- ADD 2010/11/01 �{�{ --------------------------------------------------<<<<

  // --- ADD 2010/06/09 �{�{ ------------------------------------------------>>>>
  if (Assigned(FOnKeyDown)) then
  begin
    FOnKeyDown(Sender, Key, Shift);
  end;
  // --- ADD 2010/06/09 �{�{ ------------------------------------------------<<<<
  {
    if not(goEditing in Options) then
    begin
    Key := NoInplaceEditorFocusing(Key, Shift);
    end;
    }
  FIsNoInplaceEditorFocusing := true;
  Key := NoInplaceEditorFocusing(Key, Shift);
  FIsNoInplaceEditorFocusing := False;
{$REGION '<<<--- 2010/06/09 DEL �{�{ ------------------------------------>>>'}
  // 2010/06/09 DEL �{�{ >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
  // �ȉ���NoInplaceEditorFocusing�̑O�Ɉړ��i�p�����KeyDown�C�x���g��D��j
  // if (Assigned(FOnKeyDown)) then
  // begin
  // FOnKeyDown(Sender, Key, Shift);
  // end;
  // 2010/06/09 DEL �{�{ <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
{$ENDREGION}
end;

procedure THNsGrid.DrawGridCell(Canvas: TCanvas; ACol, ARow: Integer; ARect: TRect; AState: TGridDrawState);
var
  CenterX: Integer;
  FaceColor: TColor;
  ShadowColor: TColor;
  LightColor: TColor;
  CustomDrawing: Boolean;
  FixedColArea: TRect;
begin
  inherited DrawGridCell(Canvas, ACol, ARow, ARect, AState);

  if (FixedRows > 0) then
  begin
    FixedColArea.Top := 0;
    FixedColArea.Bottom := FixedRows - 1;
    FixedColArea.Left := FixedCols;
    FixedColArea.Right := ColCount - 1;
  end
  else
  begin
    FixedColArea.Top := -1;
    FixedColArea.Bottom := -1;
    FixedColArea.Left := -1;
    FixedColArea.Right := -1;
  end;

  if ((ACol in [FixedColArea.Left .. FixedColArea.Right]) and (ARow in [FixedColArea.Top .. FixedColArea.Bottom])) then
  begin
    CustomDrawing := False;

    // B G R
    FaceColor := $00D1D1D1;
    ShadowColor := $00A0A0A0;
    LightColor := $00ECECEC;

    CenterX := (ARect.Right - ARect.Left) div 2;

    // �w�肵�Ă�����W�����т����A���ۂɕ`�悷��Ɨǂ������ɂȂ��Ă���̂ł悵�Ƃ���B

    // �\�[�g���s����Ă���Z���̕`��
    if (Length(FSortConditions) > 0) then
    begin
      if ((FSortConditions[0].ColNo = ACol) and (FSortConditions[0].RowNo = ARow)) then
      begin
        CustomDrawing := true;

        Canvas.Pen.Color := ShadowColor;
        Canvas.Brush.Color := FaceColor;

        if (FSortConditions[0].Direction = sdAscending) then
        begin
          // ��
          Canvas.Polygon([Point(ARect.Left + CenterX - 6, ARect.Top + 5), Point(ARect.Left + CenterX + 1, ARect.Top + 2), Point(ARect.Left + CenterX + 6, ARect.Top + 5)]);

          Canvas.Pen.Color := LightColor;
          Canvas.MoveTo(ARect.Left + CenterX + 1, ARect.Top + 2);
          Canvas.LineTo(ARect.Left + CenterX + 8, ARect.Top + 6);
        end
        else
        begin
          // ��
          Canvas.Polygon([Point(ARect.Left + CenterX - 6, ARect.Top + 2), Point(ARect.Left + CenterX + 7, ARect.Top + 2), Point(ARect.Left + CenterX + 0, ARect.Top + 5)]);

          Canvas.Pen.Color := LightColor;
          Canvas.MoveTo(ARect.Left + CenterX + 1, ARect.Top + 5);
          Canvas.LineTo(ARect.Left + CenterX + 8, ARect.Top + 1);
        end;
      end;
    end;

    // �\�[�g�ݒ肳��Ă���Z���̕`��
    if ((FixedColStatus[ACol, ARow] in [csSort, csBoth]) and (not CustomDrawing)) then
    begin
      Canvas.Pen.Color := ShadowColor;
      Canvas.Brush.Color := FaceColor;

      // ��
      Canvas.Polygon([Point(ARect.Left + CenterX - 12, ARect.Top + 5), Point(ARect.Left + CenterX - 5, ARect.Top + 2), Point(ARect.Left + CenterX + 0, ARect.Top + 5)]);

      // ��
      Canvas.Polygon([Point(ARect.Left + CenterX - 1, ARect.Top + 2), Point(ARect.Left + CenterX + 12, ARect.Top + 2), Point(ARect.Left + CenterX + 5, ARect.Top + 5)]);

      // �n�C���C�g�����̕`��
      // ��
      Canvas.Pen.Color := LightColor;
      Canvas.MoveTo(ARect.Left + CenterX - 5, ARect.Top + 2);
      Canvas.LineTo(ARect.Left + CenterX + 2, ARect.Top + 6);

      // ��
      Canvas.MoveTo(ARect.Left + CenterX + 6, ARect.Top + 5);
      Canvas.LineTo(ARect.Left + CenterX + 13, ARect.Top + 1);
    end;
  end;

end;



//procedure DrawCell(ACol,ARow:longint;ARect:TRect;AState:TGridDrawState); override;
//begin
//
//  inherited DrawCell(Canvas, ACol, ARow, ARect, AState);
//
//end;



procedure THNsGrid.FocusCell(Col, Row: Integer);
begin
  inherited FocusCell(Col, Row);
  Invalidate;
  InvalidateEditor;
  Click;
end;

procedure THNsGrid.SetActiveCellShow(Value: Boolean);
begin
  if (FActiveCellShow <> Value) then
  begin
    FActiveCellShow := Value;
    Invalidate;
  end;
end;

function THNsGrid.GetCellEx(c, r: Integer): String;
begin
  Result := inherited Cells[c, r];
end;

function THNsGrid.GetColCountEx: Integer;
begin
  Result := inherited ColCount;
end;

function THNsGrid.GetFixedColsEx: Integer;
begin
  Result := inherited FixedCols;
end;

function THNsGrid.GetFixedColStatus(ACol, ARow: Integer): TFixedColState;
var
  FixedColArea: TRect;
begin
  FixedColArea.Left := Low(FFixedColStGridArray);
  FixedColArea.Right := High(FFixedColStGridArray);

  FixedColArea.Top := Low(FFixedColStGridArray[FixedColArea.Left]);
  FixedColArea.Bottom := High(FFixedColStGridArray[FixedColArea.Right]);

  if ((ACol in [FixedColArea.Left .. FixedColArea.Right]) and (ARow in [FixedColArea.Top .. FixedColArea.Bottom])) then
  begin
    Result := FFixedColStGridArray[ACol, ARow];
  end
  else
  begin
    Result := csNone;
  end;
end;

function THNsGrid.GetFixedRowsEx: Integer;
begin
  Result := inherited FixedRows;
end;

procedure THNsGrid.SetFixedColsEx(Value: Integer);
begin
  inherited FixedCols := Value;
  AllocateGridArray;
end;

procedure THNsGrid.SetFixedColStatus(ACol, ARow: Integer; const Value: TFixedColState);
var
  cg: TCellGraphic;
  FixedColArea: TRect;
  OldColState: TFixedColState;
  iCnt :integer; //2010/11/18 ADD �{�{
begin
  if (FixedRows > 0) then
  begin
    FixedColArea.Top := 0;
    FixedColArea.Bottom := FixedRows - 1;
    FixedColArea.Left := FixedCols;
    FixedColArea.Right := ColCount - 1;
  end
  else
  begin
    FixedColArea.Top := -1;
    FixedColArea.Bottom := -1;
    FixedColArea.Left := -1;
    FixedColArea.Right := -1;
  end;

  if ((ACol in [FixedColArea.Left .. FixedColArea.Right]) and (ARow in [FixedColArea.Top .. FixedColArea.Bottom])) then
  begin
    OldColState := FFixedColStGridArray[ACol, ARow];
    FFixedColStGridArray[ACol, ARow] := Value;

    if (Value in [csSort, csBoth]) then
    begin
      Options := Options + [goFixedRowClick];
    end;

    if (Value in [csFilter, csBoth]) then
    begin
      // �{�^����ǉ�
      if (Trim(Cells[ACol, ARow]) <> '') then
      begin
        if (not HasButton(ACol, ARow)) then
        begin
          AddBitButton(ACol, ARow, 17, 17, '', FFilterGlyph[0], haRight, vaBottom);
        end
        else
        begin
          cg := GetCellGraphic(ACol, ARow);
          if Assigned(cg) then
          begin
            cg.CellBitmap := FFilterGlyph[0];
//--- ADD 2010/11/18 �{�{ -------------------------------------------------->>>>
            for iCnt := 0 to (Length(FFilterConditions) - 1) do begin
              if (FFilterConditions[iCnt].ColNo = ACol) and
                 (FFilterConditions[iCnt].RowNo = ARow) then
              begin
                //�ΏۃZ����Filter�ɐݒ�ρ������w��Bitmap���Z�b�g
                cg.CellBitmap := FFilterGlyph[1];
                Break;
              end;
            end;
//--- ADD 2010/11/18 �{�{ --------------------------------------------------<<<<
          end;
        end;
      end;
    end
    else if (OldColState in [csFilter, csBoth]) then
    begin
      // �{�^�����폜
      RemoveButton(ACol, ARow);
    end;

    if (not(csDesigning in ComponentState)) then
    begin
      RepaintCell(ACol, ARow);
    end;
  end;
end;

procedure THNsGrid.SetFixedRowsEx(Value: Integer);
begin
  inherited FixedRows := Value;
  AllocateGridArray;
end;

procedure THNsGrid.SetCellEx(c, r: Integer; const Value: String);
begin
  inherited Cells[c, r] := Value;

  // �ꍇ�ɂ���Ă̓t�B���^�[�̃A�C�R�����\������邩������Ȃ�
  if IsFixed(c, r) then
  begin
    FixedColStatus[c, r] := FixedColStatus[c, r];
  end;
end;

procedure THNsGrid.SetColCountEx(Value: Integer);
begin
  inherited ColCount := Value;
  AllocateGridArray;
end;

{
  procedure THNsGrid.UpdateFixedColIndicator;
  var
  bkCstDtOpt: TCustomDataOperation;
  begin
  bkCstDtOpt := CustomDataOperation;

  if (bkCstDtOpt <> coNone) then
  begin
  CustomDataOperation := coNone;
  CustomDataOperation := bkCstDtOpt;
  end;
  end;
}

procedure THNsGrid.RemoveFilterGlyph;
var
  iCol, iRow: Integer;
begin

  for iRow := 0 to FixedRows - 1 do
  begin
    for iCol := 0 to FixedCols - 1 do
    begin
      RemoveButton(iCol, iRow);
    end;
  end;

end;
{$REGION '�y�d�l�ύX�ɂ��폜�z'}
{
  procedure THNsGrid.SetCustomDataOperation(Value: TCustomDataOperation);
  begin

  if (FCustomDataOperation <> Value) then
  begin

  if (Value in [coFilter, coBoth]) then
  begin
  ControlLook.NoDisabledButtonLook := True;
  SetFilterGlyph;
  end else
  begin
  RemoveFilterGlyph;
  end;

  if (Value in [coSort, coBoth]) then
  begin
  FixedAsButtons := True;
  end;

  FCustomDataOperation := Value;
  end;

  end;

  procedure THNsGrid.SetFilterGlyph;
  var
  iCol, iRow: Integer;
  begin

  for iRow := 0 to FixedRows - 1 do
  begin
  for iCol := 0 to ColCount - 1 do
  begin
  if iCol < FixedCols then
  begin
  Continue;
  end;

  if (not HasButton(iCol, iRow) and (Trim(Cells[iCol, iRow]) <> '')) then
  begin
  AddBitButton(iCol, iRow, 17, 17, '', FFilterGlyph[0], haRight, vaBottom);
  end;
  end;
  end;

  end;
}
{$ENDREGION}

procedure THNsGrid.WMSetFocus(var Msg: TWMSetFocus);
begin
  // �t�H�[�J�X�擾���ɑI���Z���ɉ�����IME������s��
  DoImeMode(Self, Col, Row);
end;

// ------------------------------------------------------------------------------
// Layout �̃Z�b�g
// ------------------------------------------------------------------------------
procedure THNsGrid.SetLayout(const Value: TStringList);
begin
  if Value <> nil then
  begin
    FLayout.Assign(Value);

    if FAutoLayoutSet then
    begin
      SetGridLayout;
    end;
  end;
end;

// ------------------------------------------------------------------------------
// AutoLayoutSet �̃Z�b�g
// ------------------------------------------------------------------------------
procedure THNsGrid.SetAutoLayoutSet(const Value: Boolean);
begin
  FAutoLayoutSet := Value;

  if Value = true then
  begin
    if not(csLoading in ComponentState) then
    begin
      SetGridLayout;
    end;
  end
  else
  begin
    FRatioPhysicalToLogical := 1;
  end;
end;

// ------------------------------------------------------------------------------
// LogicalRowCount �̃Z�b�g
// ------------------------------------------------------------------------------
procedure THNsGrid.SetLogicalRowCount(const Value: Integer);
var
  OldValue: Integer;
  StartLogicalRow, EndLogicalRow: Integer;
begin
  OldValue := FLogicalRowCount;
  FLogicalRowCount := Value;

  if (csLoading in ComponentState) then
  begin
    Exit;
  end;

  if OldValue > FLogicalRowCount then
  begin
    // �_���s���̌���
    Self.RowCount := FRatioPhysicalToLogical * FLogicalRowCount;
  end
  else if OldValue < FLogicalRowCount then
  begin
    // �_���s���̑���
    Self.RowCount := FRatioPhysicalToLogical * FLogicalRowCount;
    StartLogicalRow := OldValue;
    EndLogicalRow := FLogicalRowCount - 1;

    if FAutoLayoutSet then
    begin
      SetGridLayoutOnlyPart(StartLogicalRow, EndLogicalRow);
    end;
  end
  else
  begin
    // �_���s���̑�������

  end;

  Enabled := FLogicalRowCount > 1; // ADD 2010/05/17 #7561�Ή�
end;

// ------------------------------------------------------------------------------
// LogicalCells �̃Z�b�g
// ------------------------------------------------------------------------------
procedure THNsGrid.SetLogicalCells(ACol, Aline, ARow: Integer; const Value: string);
var
  PhysicalCol: Integer;
  PhysicalRow: Integer;
begin
  // �_���Z���̐ݒ�𕨗��Z��������悤�ɕϊ�
  PhysicalCol := ACol;
  PhysicalRow := ARow * FRatioPhysicalToLogical + Aline;

  // �l���Z���Ɋi�[
  Self.Cells[PhysicalCol, PhysicalRow] := Value;
end;

procedure THNsGrid.SetLogicalColors(ACol, Aline, ARow: Integer; const Value: TColor);
var
  PhysicalCell: TGridCoord;
begin
  PhysicalCell := LogicalToPhysicalCell(ACol, Aline, ARow);
  Colors[PhysicalCell.X, PhysicalCell.Y] := Value;
end;

procedure THNsGrid.SetLogicalColorsTo(ACol, Aline, ARow: Integer; const Value: TColor);
var
  PhysicalCell: TGridCoord;
begin
  PhysicalCell := LogicalToPhysicalCell(ACol, Aline, ARow);
  ColorsTo[PhysicalCell.X, PhysicalCell.Y] := Value;
end;

procedure THNsGrid.SetLogicalDates(ACol, Aline, ARow: Integer; const Value: TDateTime);
var
  PhysicalCell: TGridCoord;
begin
  PhysicalCell := LogicalToPhysicalCell(ACol, Aline, ARow);
  Dates[PhysicalCell.X, PhysicalCell.Y] := Value;
end;

procedure THNsGrid.SetLogicalFloats(ACol, Aline, ARow: Integer; const Value: Double);
var
  PhysicalCell: TGridCoord;
begin
  PhysicalCell := LogicalToPhysicalCell(ACol, Aline, ARow);
  Floats[PhysicalCell.X, PhysicalCell.Y] := Value;
end;

procedure THNsGrid.SetLogicalFontColors(ACol, Aline, ARow: Integer; const Value: TColor);
var
  PhysicalCell: TGridCoord;
begin
  PhysicalCell := LogicalToPhysicalCell(ACol, Aline, ARow);
  FontColors[PhysicalCell.X, PhysicalCell.Y] := Value;
end;

procedure THNsGrid.SetLogicalInts(ACol, Aline, ARow: Integer; const Value: Integer);
var
  PhysicalCell: TGridCoord;
begin
  PhysicalCell := LogicalToPhysicalCell(ACol, Aline, ARow);
  Ints[PhysicalCell.X, PhysicalCell.Y] := Value;
end;

// ------------------------------------------------------------------------------
// LogicalCells �̃Q�b�g
// ------------------------------------------------------------------------------
function THNsGrid.GetLogicalCells(ACol, Aline, ARow: Integer): string;
var
  PhysicalCol: Integer;
  PhysicalRow: Integer;
begin
  // �_���Z���̐ݒ�𕨗��Z��������悤�ɕϊ�
  PhysicalCol := ACol;
  PhysicalRow := ARow * FRatioPhysicalToLogical + Aline;

  // �l���Z������擾
  Result := Self.Cells[PhysicalCol, PhysicalRow];
end;

// ------------------------------------------------------------------------------
// LogicalRow �̃Z�b�g
// ------------------------------------------------------------------------------
procedure THNsGrid.SetLogicalReadOnly(ACol, Aline, ARow: Integer; const Value: Boolean);
var
  PhysicalCell: TGridCoord;
begin
  PhysicalCell := LogicalToPhysicalCell(ACol, Aline, ARow);
  ReadOnly[PhysicalCell.X, PhysicalCell.Y] := Value;
end;

procedure THNsGrid.SetLogicalRow(const Value: Integer);
begin
  Self.Row := Value * FRatioPhysicalToLogical + (Value mod FRatioPhysicalToLogical);
end;

function THNsGrid.GetLogicalReadOnly(ACol, Aline, ARow: Integer): Boolean;
var
  PhysicalCell: TGridCoord;
begin
  PhysicalCell := LogicalToPhysicalCell(ACol, Aline, ARow);
  Result := ReadOnly[PhysicalCell.X, PhysicalCell.Y];
end;

// ------------------------------------------------------------------------------
// LogicalRow �̃Q�b�g
// ------------------------------------------------------------------------------
function THNsGrid.GetLogicalRow: Integer;
begin
  Result := Self.Row div FRatioPhysicalToLogical
end;

// ------------------------------------------------------------------------------
// LogicalLine �̃Z�b�g
// ------------------------------------------------------------------------------
procedure THNsGrid.SetLogicalLine(const Value: Integer);
begin
  Self.Row := (Self.Row div FRatioPhysicalToLogical) * FRatioPhysicalToLogical + Value;
end;

// ------------------------------------------------------------------------------
// LogicalLine �̃Q�b�g
// ------------------------------------------------------------------------------
function THNsGrid.GetLogicalLine: Integer;
begin
  Result := Self.Row mod FRatioPhysicalToLogical
end;

// ------------------------------------------------------------------------------
// LogicalCols �̃Z�b�g
// ------------------------------------------------------------------------------
// procedure THNsGrid.SetLogicalCols(Aline,Index: Integer;const Value: TStrings);
// begin
// end;

// ------------------------------------------------------------------------------
// LogicalCols �̃Q�b�g
// ------------------------------------------------------------------------------

function THNsGrid.GetLogicalColors(ACol, Aline, ARow: Integer): TColor;
var
  PhysicalCell: TGridCoord;
begin
  PhysicalCell := LogicalToPhysicalCell(ACol, Aline, ARow);
  Result := Colors[PhysicalCell.X, PhysicalCell.Y];
end;

function THNsGrid.GetLogicalColorsTo(ACol, Aline, ARow: Integer): TColor;
var
  PhysicalCell: TGridCoord;
begin
  PhysicalCell := LogicalToPhysicalCell(ACol, Aline, ARow);
  Result := ColorsTo[PhysicalCell.X, PhysicalCell.Y];
end;

function THNsGrid.GetLogicalCols(Aline, Index: Integer): TStrings;
var
  iy: Integer;
begin
  FLogicalCols.Clear;

  if FAutoLayoutSet then
  begin
    for iy := 1 to Self.LogicalRowCount - 1 do
    begin
      FLogicalCols.Add(Self.LogicalCells[Index, Aline, iy]);
    end;
  end
  else
  begin
    // FAutoLayoutSet=False�̏ꍇ�́A�����Z�����擾����
    for iy := Self.FixedRows to Self.RowCount - 1 do
    begin
      FLogicalCols.Add(Self.Cells[Index, iy]);
    end;
  end;

  Result := FLogicalCols;
end;

function THNsGrid.GetLogicalDates(ACol, Aline, ARow: Integer): TDateTime;
var
  PhysicalCell: TGridCoord;
begin
  PhysicalCell := LogicalToPhysicalCell(ACol, Aline, ARow);
  Result := Dates[PhysicalCell.X, PhysicalCell.Y];
end;

function THNsGrid.GetLogicalFloats(ACol, Aline, ARow: Integer): Double;
var
  PhysicalCell: TGridCoord;
begin
  PhysicalCell := LogicalToPhysicalCell(ACol, Aline, ARow);
  Result := Floats[PhysicalCell.X, PhysicalCell.Y];
end;

function THNsGrid.GetLogicalFontColors(ACol, Aline, ARow: Integer): TColor;
var
  PhysicalCell: TGridCoord;
begin
  PhysicalCell := LogicalToPhysicalCell(ACol, Aline, ARow);
  Result := FontColors[PhysicalCell.X, PhysicalCell.Y];
end;

function THNsGrid.GetLogicalInts(ACol, Aline, ARow: Integer): Integer;
var
  PhysicalCell: TGridCoord;
begin
  PhysicalCell := LogicalToPhysicalCell(ACol, Aline, ARow);
  Result := Ints[PhysicalCell.X, PhysicalCell.Y];
end;

// ------------------------------------------------------------------------------
// LogicalObjects �̃Z�b�g
// ------------------------------------------------------------------------------
// procedure THNsGrid.SetLogicalObjects(ACol,Aline, ARow: Integer;const Value: TObject);
// begin
// end;

// ------------------------------------------------------------------------------
// LogicalObjects �̃Q�b�g
// ------------------------------------------------------------------------------
// function THNsGrid.GetLogicalObjects(ACol,Aline, ARow: Integer):TObject;
// begin
// end;

// ------------------------------------------------------------------------------
// LogicalRows �̃Z�b�g
// ------------------------------------------------------------------------------
// procedure THNsGrid.SetLogicalRows(Index: Integer;const Value: TStrings);
// begin
// end;

// ------------------------------------------------------------------------------
// LogicalRows �̃Q�b�g
// ------------------------------------------------------------------------------
function THNsGrid.GetLogicalRows(Index: Integer): TStrings;
var
  iy: Integer;
  sbuf: string;
  StartPhysicalIndex: Integer;
  EndPhysicalIndex: Integer;
begin
  FLogicalRows.Clear;

  StartPhysicalIndex := Index * FRatioPhysicalToLogical;
  EndPhysicalIndex := Index * FRatioPhysicalToLogical + (FRatioPhysicalToLogical - 1);

  if FAutoLayoutSet then
  begin
    for iy := StartPhysicalIndex to EndPhysicalIndex do
    begin
      for sbuf in Self.Rows[iy] do
      begin
        FLogicalRows.Add(sbuf);
      end;
    end;
  end
  else
  begin
    // FAutoLayoutSet=False�̏ꍇ�́A����ROW���擾����
    for sbuf in Self.Rows[Index] do
    begin
      FLogicalRows.Add(sbuf);
    end;
  end;

  Result := FLogicalRows;
end;

procedure THNsGrid.GotoCell(Col, Row: Integer);
begin
  inherited GotoCell(Col, Row);
  Invalidate;
  InvalidateEditor;
  Click;
end;

// ------------------------------------------------------------------------------
// �_�����ד��i���ύX����
// ------------------------------------------------------------------------------
// �@�\ : �_�����ד��̒i�����ύX���ꂽ�ꍇ�ɌĂяo���A�i���̑������������܂�
// 1�_�����ז���Line��insert/remove���s���܂�
// (�P����RowCount��ύX���邾�����ƃO���b�h���̃f�[�^��
// �߂��Ⴍ����ɂȂ��Ă��܂�)
// note : SetGridLayout ����Ăяo�����߂Ɏ������Ă��܂��B
// ���̏���������s���Ȃ��ł�������
// ------------------------------------------------------------------------------
procedure THNsGrid.AllocateGridArray;
var
  ACol, ARow: Integer;
  ColMax, RowMax: Integer;
begin

  if (FixedRows > 0) then
  begin
    ColMax := ColCount;
    RowMax := FixedRows;
  end
  else if (FixedCols > 0) then
  begin
    ColMax := FixedCols;
    RowMax := 1;
  end
  else
  begin
    ColMax := 0;
    RowMax := 0;
  end;

  // �Q�����z��̍Ċm�ۂ��s��
  SetLength(FFixedColStGridArray, ColMax, RowMax);

  for ACol := 0 to ColMax - 1 do
  begin
    for ARow := 0 to RowMax - 1 do
    begin
      FixedColStatus[ACol, ARow] := csNone;
    end;
  end;

end;

procedure THNsGrid.ChangeLineCountAtLogicalRow(OldLineCount, NewLineCount: Integer);
var
  incCount: Integer;
  iy: Integer;

begin
  incCount := NewLineCount - OldLineCount;
  if (incCount > 0) then
  begin
    // incCount������������ALine�𑝂₷
    for iy := 0 to FLogicalRowCount - 1 do
    begin
      Self.InsertRows(NewLineCount * iy + OldLineCount, incCount, true);
    end;
    Self.FixedRows := NewLineCount;
  end
  else if (incCount < 0) then
  begin
    // incCount������������ALine�����炷
    Self.FixedRows := NewLineCount;
    for iy := 0 to FLogicalRowCount - 1 do
    begin
      Self.InsertRows(NewLineCount * iy + OldLineCount - 1, -incCount, true);
    end;
  end
  else
  begin
    // incCount��0��������A�������Ȃ�

  end;
end;

procedure THNsGrid.Clear;
begin
  if (NormalEdit is THNsInplaceEdit) then
  begin
    THNsInplaceEdit(NormalEdit).Clear;
  end;

  inherited Clear;
end;

// ------------------------------------------------------------------------------
// �O���b�h�̏����ݒ菈��
// ------------------------------------------------------------------------------
// note : PG���s���ɃO���b�h�̃��C�A�E�g��ς����ꍇ�A�ꖾ�ׂ̒i����
// �ύX����Ƃ��������Ȃ�̂Œ��ӂ��邱�ƁB
// (�����_�ł����܂Ŏ������Ă��܂���)
//
//
// layput�v���p�e�B�̓����\��(TStringList�ŕێ����Ă���)
// ---------------------------------------------------------------------
// 6,3                            //1�s�ڂ͕K�� Col,Line ��ݒ肷��
// 1,1,2,2                        //2�s�ڈȍ~�� Col,Line,spanx,spany ��ݒ肷��
// 4,1,1,2                        //2�s�ڈȍ~�͖����Ă�����
// 5,3,2,1
//
// ---------------------------------------------------------------------
// ------------------------------------------------------------------------------
procedure THNsGrid.SetGridLayout;
var
  ix, iy: Integer;
  sbuf: TStringList;
begin
  if (csLoading in ComponentState) then
  begin
    Exit;
  end;

  if FLayout.Count < 1 then
  begin
    // ���C�A�E�g���ݒ肳��Ă��Ȃ���Ή����s��Ȃ�
    Exit;
  end;

  // �S�Z���̌�������U��������
  SplitAllCells;

  // ���׍s���̐ݒ�
  sbuf := TStringList.Create;
  try
    sbuf.CommaText := FLayout.Strings[0];

    FRatioPhysicalToLogical := strtoint(sbuf[1]);
    Self.MouseActions.WheelIncrement := FRatioPhysicalToLogical;
    // ------------------------------------------------------------------------------
    // ChangeLineCountAtLogicalRow�ɒu��������
    // self.RowCount := FRatioPhysicalToLogical*(FLogicalRowCount );
    // self.FixedRows := FRatioPhysicalToLogical;
    ChangeLineCountAtLogicalRow(Self.FixedRows, FRatioPhysicalToLogical);
    // ------------------------------------------------------------------------------

    Self.ColCount := strtoint(sbuf[0]) + Self.FixedCols;
    Self.Bands.PrimaryLength := FRatioPhysicalToLogical;
    Self.Bands.SecondaryLength := FRatioPhysicalToLogical;

    // �Z���̌�������
    for iy := 0 to FLogicalRowCount - 1 do
    begin
      for ix := 1 to FLayout.Count - 1 do
      begin
        sbuf.CommaText := FLayout.Strings[ix];
        Self.MergeCells(strtoint(sbuf[0]) + Self.FixedCols - 1, FRatioPhysicalToLogical * iy + strtoint(sbuf[1]) - 1, strtoint(sbuf[2]), strtoint(sbuf[3]));
      end;

      // FixedCol������ꍇ�́ACol:0�̂݌�������
      if Self.FixedCols > 0 then
      begin
        Self.MergeCells(0, FRatioPhysicalToLogical * iy, 1, FRatioPhysicalToLogical);
      end;
    end;
  finally
    // �t�H�[�J�X�̍ăZ�b�g
    sbuf.Free;
  end;
end;

// ------------------------------------------------------------------------------
// �O���b�h�̏����ݒ菈��
// ------------------------------------------------------------------------------
procedure THNsGrid.SetGridLayoutOnlyPart(StartLogicalRow, EndLogicalRow: Integer);
var
  ix, iy: Integer;
  sbuf: TStringList;
begin
  if (csLoading in ComponentState) then
  begin
    Exit;
  end;

  // ���׍s���̐ݒ�
  sbuf := TStringList.Create;
  try
    // �Z���̌�������
    for iy := StartLogicalRow to EndLogicalRow do
    begin
      for ix := 1 to FLayout.Count - 1 do
      begin
        sbuf.CommaText := FLayout.Strings[ix];
        Self.MergeCells(strtoint(sbuf[0]), Self.Bands.PrimaryLength * iy + strtoint(sbuf[1]) - 1, strtoint(sbuf[2]), strtoint(sbuf[3]));
      end;
      // FixedCol������ꍇ�́ACol:0�̂݌�������
      if Self.FixedCols > 0 then
      begin
        Self.MergeCells(0, FRatioPhysicalToLogical * iy, 1, FRatioPhysicalToLogical);
      end;
    end;
  finally
    // �t�H�[�J�X�̍ăZ�b�g
    sbuf.Free;
  end;
end;

// ------------------------------------------------------------------------------
// �v���p�e�B���[�h�㏈��
// ----------------------------------------------------------------------
// Note :  �v���p�e�B���[�h��̃O���b�h�̍Đݒ���s��
// ------------------------------------------------------------------------------
procedure THNsGrid.Loaded;
begin
  inherited Loaded;

  // �����̃v���p�e�B�͏�� False �Ƃ��� --->>>
  Navigation.AdvanceOnEnter := False;
  Navigation.CursorWalkEditor := False;
  MouseActions.DirectComboDrop := False;
  MouseActions.DirectDateDrop := False;
  MouseActions.DirectEdit := False;
  // �����̃v���p�e�B�͏�� False �Ƃ��� ---<<<

  if FAutoLayoutSet then
  begin
    SetGridLayout;

    if (goRowSelect in Options) then
    begin
      y1 := (Row div Bands.PrimaryLength) * Bands.PrimaryLength;
      x1 := FixedCols;
      x2 := ColCount - 1;
      y2 := (Row div Bands.PrimaryLength) * Bands.PrimaryLength + Bands.PrimaryLength - 1;
      SelectRange(x1, x2, y1, y2); // �p����TAdvStringGrid�̕s��H����̂��߁Ay1, y2����ւ��Ă܂�
      SelectRange(x1, x2, y2, y1); // �p����TAdvStringGrid�̕s��H����̂��߁Ay1, y2����ւ��Ă܂�
    end;
  end;

end;

procedure THNsGrid.LogicalFocusCell(ACol, Aline, ARow: Integer);
var
  PhysicalCell: TGridCoord;
begin
  PhysicalCell := LogicalToPhysicalCell(ACol, Aline, ARow);
  FocusCell(PhysicalCell.X, PhysicalCell.Y);
end;

function THNsGrid.LogicalIsEditable(ACol, Aline, ARow: Integer): Boolean;
var
  PhysicalCell: TGridCoord;
begin
  PhysicalCell := LogicalToPhysicalCell(ACol, Aline, ARow);
  Result := IsEditable(PhysicalCell.X, PhysicalCell.Y);
end;

function THNsGrid.LogicalToPhysicalCell(ACol, Aline, ARow: Integer): TGridCoord;
var
  BasePos: TPoint;
begin
  // �_���Z���̐ݒ�𕨗��Z��������悤�ɕϊ�
  Result.X := ACol;
  Result.Y := ARow * FRatioPhysicalToLogical + Aline;

  BasePos := BaseCell(Result.X, Result.Y);

  Result.X := BasePos.X;
  Result.Y := BasePos.Y;
end;

function THNsGrid.NoInplaceEditorFocusing(Key: Word; Shift: TShiftState): Word;
var
  NextCellRect: TRect;
  NextCell: TPoint;
  Prevcell: TPoint;
  CellCheck: Boolean;
  MaxCellCount: Integer;
  iCount: Integer;
  lx1, lx2, ly1, ly2: Integer;

  dbgMsg: String;
  bReturn: Boolean; // 2010/06/01 ADD �{�{
  Value: String; // 2010/09/16 ADD
  Valid: Boolean;
begin
  Result := Key;

  // Enter����̕␳
  if (Key = VK_RETURN) or (Key = VK_TAB) then
  begin
    if (Shift = [ssSHIFT]) then
      Key := VK_LEFT
    else
      Key := VK_RIGHT;
    // --- ADD 2010/06/01 �{�{ ------------------------------------------------>>>>
    bReturn := true;
  end
  else
  begin
    bReturn := False;
    // --- ADD 2010/06/01 �{�{ ------------------------------------------------<<<<
  end;

  // �K�v�Ȓl�̃Z�b�g
  iCount := 0;
  NextCell.X := Col;
  NextCell.Y := Row;
  Prevcell.X := Col;
  Prevcell.Y := Row;
  CellCheck := False;

  // �t�H�[�J�X����
{$REGION 'if (goRowSelect in Options) then'}
  if (goRowSelect in Options) then
  begin
    // 2010/02/26 UPD start>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    // ���������̃t�H�[�J�X�ړ����\�ɂ���B
    // �_���s�P�ʂɈړ�
{$REGION '--- Key in [VK_UP, VK_DOWN] ---'}
    if Key in [VK_UP, VK_DOWN] then
    begin
      case Key of
        VK_UP:
          begin
            // ������Ɉړ�
            if ((NextCell.Y - FRatioPhysicalToLogical) > (FixedRows - 1)) then
            begin
              NextCell.X := FixedCols;
              NextCell.Y := ((Prevcell.Y div FRatioPhysicalToLogical) - 1) * FRatioPhysicalToLogical;
              CellCheck := true;
            end
            else
            begin
              CellCheck := False;
              Result := 0;
            end;

            DoCellChanging(Self, Prevcell.Y, Prevcell.X, NextCell.Y, NextCell.X, CellCheck);
          end;
        VK_DOWN:
          begin
            // �������Ɉړ�
            if ((NextCell.Y + FRatioPhysicalToLogical) <= (RowCount - 1)) then
            begin
              NextCell.X := FixedCols;
              NextCell.Y := ((Prevcell.Y div FRatioPhysicalToLogical) + 1) * FRatioPhysicalToLogical;
              CellCheck := true;
            end
            else
            begin
              CellCheck := False;
              Result := 0;
            end;

            DoCellChanging(Self, Prevcell.Y, Prevcell.X, NextCell.Y, NextCell.X, CellCheck);
          end;
      end;

      if not((not CellCheck) or (NextCell.X = Prevcell.X) and (NextCell.Y = Prevcell.Y)) then
      begin
        lx1 := FixedCols;
        lx2 := ColCount - 1;
        ly1 := (NextCell.Y div FRatioPhysicalToLogical) * FRatioPhysicalToLogical;
        ly2 := (NextCell.Y div FRatioPhysicalToLogical) * FRatioPhysicalToLogical + FRatioPhysicalToLogical - 1;
        SelectRange(lx1, lx2, ly2, ly1); // �p����TAdvStringGrid�̕s��H����̂��߁Ay1,y2����ւ��Ă܂�
        RepaintCell(Prevcell.X, Prevcell.Y);
        SelectionChanged(lx1, ly1, lx2, ly2);
        Result := 0;
      end;
    end
    else
{$ENDREGION}
    if Key in [VK_LEFT, VK_RIGHT] then
    begin

      dbgMsg := FormatDateTime('"("nn:ss") Key in [VK_LEFT, VK_RIGHT]"', Time);
      OutputDebugString(PChar(dbgMsg));

      // ���X�N���[���\�ȏꍇ�̓X�N���[������
      if (ColCount >= FixedCols + VisibleColCount) then
      begin

        dbgMsg := FormatDateTime('"("nn:ss") ColCount >= FixedCols + VisibleColCount"', Time);
        OutputDebugString(PChar(dbgMsg));

        case Key of
          VK_LEFT:
            begin
              dbgMsg := FormatDateTime('"("nn:ss") case Key of VK_LEFT"', Time);
              OutputDebugString(PChar(dbgMsg));

              if (LeftCol <= FixedCols) then
              begin
                if Navigation.LeftRightRowSelect then
                begin
                  // ������Ɉړ�
                  if ((NextCell.Y - FRatioPhysicalToLogical) > (FixedRows - 1)) then
                  begin
                    NextCell.X := FixedCols;
                    NextCell.Y := ((Prevcell.Y div FRatioPhysicalToLogical) - 1) * FRatioPhysicalToLogical;
                    CellCheck := true;
                  end
                  else
                  begin
                    CellCheck := False;
                    Result := 0;
                  end;

                  DoCellChanging(Self, Prevcell.Y, Prevcell.X, NextCell.Y, NextCell.X, CellCheck);
                  if not((not CellCheck) or (NextCell.X = Prevcell.X) and (NextCell.Y = Prevcell.Y)) then
                  begin
                    lx1 := FixedCols;
                    lx2 := ColCount - 1;
                    ly1 := (NextCell.Y div FRatioPhysicalToLogical) * FRatioPhysicalToLogical;
                    ly2 := (NextCell.Y div FRatioPhysicalToLogical) * FRatioPhysicalToLogical + FRatioPhysicalToLogical - 1;
                    SelectRange(lx1, lx2, ly2, ly1);
                    // �p����TAdvStringGrid�̕s��H����̂��߁Ay1,y2����ւ��Ă܂�
                    RepaintCell(Prevcell.X, Prevcell.Y);
                    SelectionChanged(lx1, ly1, lx2, ly2);
                    Result := 0;
                  end;
                end;
              end
              else
              begin
                // LeftCol := LeftCol -1;      //�p�����ő��삵�Ă���̂ŕύX����K�v�Ȃ�  //2010/03/06 del
                Result := 0;
              end;
            end;
          VK_RIGHT:
            begin
              dbgMsg := FormatDateTime('"("nn:ss") case Key of VK_RIGHT"', Time);
              OutputDebugString(PChar(dbgMsg));

              dbgMsg := Format('LeftCol:%D, ColCount:%D, VisibleColCount:%D, Ans:%D', [LeftCol, ColCount, VisibleColCount, ColCount - VisibleColCount]);
              OutputDebugString(PChar(dbgMsg));

              if (LeftCol > (ColCount - VisibleColCount)) then
              begin
                dbgMsg := FormatDateTime('"("nn:ss") (LeftCol > (ColCount - VisibleColCount))"', Time);
                OutputDebugString(PChar(dbgMsg));

                if Navigation.LeftRightRowSelect then
                begin
                  // �������Ɉړ�
                  if ((NextCell.Y + FRatioPhysicalToLogical) <= (RowCount - 1)) then
                  begin
                    NextCell.X := FixedCols;
                    NextCell.Y := ((Prevcell.Y div FRatioPhysicalToLogical) + 1) * FRatioPhysicalToLogical;
                    CellCheck := true;
                  end
                  else
                  begin
                    CellCheck := False;
                    Result := 0;
                  end;

                  DoCellChanging(Self, Prevcell.Y, Prevcell.X, NextCell.Y, NextCell.X, CellCheck);
                  if not((not CellCheck) or (NextCell.X = Prevcell.X) and (NextCell.Y = Prevcell.Y)) then
                  begin
                    lx1 := FixedCols;
                    lx2 := ColCount - 1;
                    ly1 := (NextCell.Y div FRatioPhysicalToLogical) * FRatioPhysicalToLogical;
                    ly2 := (NextCell.Y div FRatioPhysicalToLogical) * FRatioPhysicalToLogical + FRatioPhysicalToLogical - 1;
                    SelectRange(lx1, lx2, ly2, ly1);
                    // �p����TAdvStringGrid�̕s��H����̂��߁Ay1,y2����ւ��Ă܂�
                    RepaintCell(Prevcell.X, Prevcell.Y);
                    SelectionChanged(lx1, ly1, lx2, ly2);
                    Result := 0;
                  end;
                end;
              end
              else
              begin
                dbgMsg := FormatDateTime('"("nn:ss") ELSE (LeftCol > (ColCount - VisibleColCount))"', Time);
                OutputDebugString(PChar(dbgMsg));

                // LeftCol := LeftCol +1;  // �p�����ő��삵�Ă���̂ŕύX����K�v�Ȃ�  //2010/03/06 del
                Result := 0;
              end;
            end;
        end;
      end
      else
      begin

        dbgMsg := FormatDateTime('"("nn:ss") ELSE (ColCount >= FixedCols + VisibleColCoun)"', Time);
        OutputDebugString(PChar(dbgMsg));

        if (Navigation.LeftRightRowSelect) then
        begin
          // �X�N���[���������㉺�����Ɉړ�
          case Key of
            VK_LEFT:
              begin
                // ������Ɉړ�
                if ((NextCell.Y - FRatioPhysicalToLogical) > (FixedRows - 1)) then
                begin
                  NextCell.X := FixedCols;
                  NextCell.Y := ((Prevcell.Y div FRatioPhysicalToLogical) - 1) * FRatioPhysicalToLogical;
                  CellCheck := true;
                end
                else
                begin
                  CellCheck := False;
                  Result := 0;
                end;

                DoCellChanging(Self, Prevcell.Y, Prevcell.X, NextCell.Y, NextCell.X, CellCheck);
              end;
            VK_RIGHT:
              begin
                // �������Ɉړ�
                if ((NextCell.Y + FRatioPhysicalToLogical) <= (RowCount - 1)) then
                begin
                  NextCell.X := FixedCols;
                  NextCell.Y := ((Prevcell.Y div FRatioPhysicalToLogical) + 1) * FRatioPhysicalToLogical;
                  CellCheck := true;
                end
                else
                begin
                  CellCheck := False;
                  Result := 0;
                end;

                DoCellChanging(Self, Prevcell.Y, Prevcell.X, NextCell.Y, NextCell.X, CellCheck);
              end;
          end;

          if not((not CellCheck) or (NextCell.X = Prevcell.X) and (NextCell.Y = Prevcell.Y)) then
          begin
            lx1 := FixedCols;
            lx2 := ColCount - 1;
            ly1 := (NextCell.Y div FRatioPhysicalToLogical) * FRatioPhysicalToLogical;
            ly2 := (NextCell.Y div FRatioPhysicalToLogical) * FRatioPhysicalToLogical + FRatioPhysicalToLogical - 1;
            SelectRange(lx1, lx2, ly2, ly1); // �p����TAdvStringGrid�̕s��H����̂��߁Ay1,y2����ւ��Ă܂�
            RepaintCell(Prevcell.X, Prevcell.Y);
            SelectionChanged(lx1, ly1, lx2, ly2);
            Result := 0;
          end;
        end;
      end;
    end;
{$REGION '--- DEL 2010/02/26 ---'}
    {
      // �_���s�P�ʂɈړ�
      case Key of
      VK_LEFT, VK_UP:
      begin
      //������Ɉړ�
      if ((NextCell.Y - FRatioPhysicalToLogical) > (FixedRows - 1)) then
      begin
      NextCell.X := FixedCols;
      NextCell.Y := ((Prevcell.Y div FRatioPhysicalToLogical) - 1) * FRatioPhysicalToLogical;
      CellCheck  := True;
      end else
      begin
      CellCheck  := False;
      Result := 0;
      end;

      DoCellChanging(Self, Prevcell.Y, Prevcell.X, NextCell.Y, NextCell.X, CellCheck);
      end;
      VK_RIGHT, VK_DOWN:
      begin
      //�������Ɉړ�
      if ((NextCell.Y + FRatioPhysicalToLogical) <= (RowCount-1)) then
      begin
      NextCell.X := FixedCols;
      NextCell.Y := ((Prevcell.Y div FRatioPhysicalToLogical) + 1) * FRatioPhysicalToLogical;
      CellCheck  := True;
      end else
      begin
      CellCheck  := False;
      Result := 0;
      end;

      DoCellChanging(Self, Prevcell.Y, Prevcell.X, NextCell.Y, NextCell.X, CellCheck);
      end;
      end;

      if not((not CellCheck) or (NextCell.X = Prevcell.X) and (NextCell.Y = Prevcell.Y)) then
      begin
      lx1 := FixedCols;
      lx2 := ColCount - 1;
      ly1 := (NextCell.Y div FRatioPhysicalToLogical)*FRatioPhysicalToLogical;
      ly2 := (NextCell.Y div FRatioPhysicalToLogical)*FRatioPhysicalToLogical + FRatioPhysicalToLogical - 1;
      SelectRange(lx1, lx2, ly2, ly1);   //�p����TAdvStringGrid�̕s��H����̂��߁Ay1,y2����ւ��Ă܂�
      RepaintCell(Prevcell.X, Prevcell.Y);
      SelectionChanged(lx1, ly1, lx2, ly2);
      Result := 0;
      end;
      }
{$ENDREGION}
    // 2010/02/26 UPD end<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
{$ENDREGION}
  end
  else
{$REGION 'ELSE if (goRowSelect in Options) then'}
  begin
    case Key of
      VK_LEFT, VK_RIGHT:
        begin
          // 2010/06/01 ADD �{�{ >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
          // if ((bReturn = False) and Assigned(NormalEdit)) then                       //DEL 2010/07/23 M.Kubota
          if ((bReturn = False) and Assigned(NormalEdit) and NormalEdit.Visible) then // ADD 2010/07/23 M.Kubota
          begin
            if (Key = VK_RIGHT) then
            begin
              if (Length(NormalEdit.Text) > NormalEdit.SelStart) then
              begin
                Exit;
              end;
            end;

            if (Key = VK_LEFT) then
            begin
              // 2010/06/04 UPD �{�{ <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
              // if (NormalEdit.SelStart <> 0) or
              // ((NormalEdit.SelLength <> 0) and
              // (NormalEdit.SelLength <> Length(NormalEdit.Text))) then
              if (NormalEdit.SelStart <> 0) or ((NormalEdit.SelLength <> 0) and (NormalEdit.SelLength <> Length(NormalEdit.Text))) or ((NormalEdit.SelLength <> 0) and (NormalEdit.SelLength = Length(NormalEdit.Text)) and (FCursorMode <> cmSimple)) then
              // 2010/06/04 UPD �{�{ <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
              begin
                Exit;
              end;
            end;
          end;
          // 2010/06/01 ADD �{�{ <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

          MaxCellCount := (ColCount - FixedCols) * (RowCount - FixedRows);
          while (not CellCheck) and (iCount <= MaxCellCount) do
          begin
            // --- ADD 2010/09/13 �{�{ #13189 ------------------------------------------->>>>
            if (not FCursorJump) and // �����è��CursorJump��False�̏ꍇ��Jump���Ȃ�
            // --- ADD 2010/09/27 ���� #13189 ------------------------------------------->>>>
            //  (((Key = VK_LEFT) and (NextCell.X = FixedCols)) or ((Key = VK_RIGHT) and (NextCell.X = ColCount - 1))) then
              (((Key = VK_LEFT) and (NextCell.X = FixedCols) and (NextCell.Y = FixedRows) ) or
              ((Key = VK_RIGHT) and (NextCell.X = ColCount - 1) and (NextCell.Y = RowCount - 1))) then
            // --- ADD 2010/09/27 ���� #13189 --------------------------------------------<<<
            begin
              CellCheck := False;
              Break;
            end;
            // --- ADD 2010/09/13 �{�{ #13189 --------------------------------------------<<<

            if (Key = VK_LEFT) then
            begin
              // ���ɐi�߂��ꍇ
              if (NextCell.X = FixedCols) then
              begin
                NextCell.X := ColCount - 1;

                if (NextCell.Y = FixedRows) then
                  NextCell.Y := RowCount - 1
                else
                  NextCell.Y := NextCell.Y - 1;
{$REGION'ENTER�ƃJ�[�\���̐�������ʉ�'}
                {
                  if (NextCell.Y <> FixedRows) then
                  begin
                  NextCell.X := ColCount - 1;
                  NextCell.Y := NextCell.Y - 1;
                  end;
                  }
{$ENDREGION}
              end
              else
              begin
                NextCell.X := NextCell.X - 1;
              end;
            end
            else
            begin
              // �E�ɐi�߂��ꍇ
              if (NextCell.X = ColCount - 1) then
              begin
                NextCell.X := FixedCols;

                if (NextCell.Y = RowCount - 1) then
                  NextCell.Y := FixedRows
                else
                  NextCell.Y := NextCell.Y + 1;
{$REGION'ENTER�ƃJ�[�\���̐�������ʉ�'}
                {
                  if (NextCell.Y <> RowCount - 1) then
                  begin
                  NextCell.X := FixedCols;
                  NextCell.Y := NextCell.Y + 1;
                  end;
                  }
{$ENDREGION}
              end
              else
              begin
                NextCell.X := NextCell.X + 1;
              end;
            end;
            CellCheck := true;

            Inc(iCount);

            DoCellChanging(Self, Prevcell.Y, Prevcell.X, NextCell.Y, NextCell.X, CellCheck);

            // --- ADD 2010/09/17 H.Matsumoto --------------------------------------->>>>
//            if CellCheck then
//            begin
              // �t�H�[�J�X�O���ڃ`�F�b�N�Ń_���Ȃ烋�[�v�𔲂���
              if Assigned(FOnNsCellValidate) then
              begin
                Value := Cells[Prevcell.X, Prevcell.Y];
                FOnNsCellValidate(Self, Prevcell.X, Prevcell.Y, Value, Valid, true);
                if not(Valid) then
                begin
                  CellCheck := False;
                  Break;
                end;
              end;
//            end;
            // --- ADD 2010/09/17 H.Matsumoto ---------------------------------------<<<<

            CellCheck := CellCheck and IsBaseCell(NextCell.X, NextCell.Y);
          end;
        end;
      VK_UP, VK_DOWN:
        begin
          MaxCellCount := RowCount - FixedRows;

          while (not CellCheck) and (iCount <= MaxCellCount) do
          begin
            CellCheck := true;

            Inc(iCount);

            // --- ADD 2010/09/13 �{�{ #13189 ------------------------------------------->>>>
            if (not FCursorJump) and // �����è��CursorJump��False�̏ꍇ��Jump���Ȃ�
              (((Key = VK_UP) and (NextCell.Y = FixedRows)) or ((Key = VK_DOWN) and (NextCell.Y = RowCount - 1))) then
            begin
              CellCheck := False;
              Break;
            end;
            // --- ADD 2010/09/13 �{�{ #13189 --------------------------------------------<<<

            if (Key = VK_UP) then
            begin
              // ��ɐi�߂��ꍇ
              if (NextCell.Y = FixedRows) then
                NextCell.Y := RowCount - 1 // �ŏ�i�ɗ�����A�ŉ��i�Ɉړ�����
              else
                NextCell.Y := NextCell.Y - 1;
            end
            else
            begin
              // ���ɐi�߂��ꍇ
              if (NextCell.Y = RowCount - 1) then
                NextCell.Y := FixedRows // �ŉ��i�ɗ�����A�ŏ�i�Ɉړ�����
              else
                NextCell.Y := NextCell.Y + 1;
            end;

            // --- ADD 2010/09/15 �{�{ #14607 ------------------------------------------->>>>
            NextCell.X := Col;
            while (not IsBaseCell(NextCell.X, NextCell.Y)) and (NextCell.X >= FixedCols) do
            begin
              NextCell.X := NextCell.X - 1;
            end;
            // --- ADD 2010/09/15 �{�{ #14607 --------------------------------------------<<<

            DoCellChanging(Self, Prevcell.Y, Prevcell.X, NextCell.Y, NextCell.X, CellCheck);

            // --- ADD 2010/09/17 H.Matsumoto --------------------------------------->>>>
            //if CellCheck then
            //begin
              // �t�H�[�J�X�O���ڃ`�F�b�N�Ń_���Ȃ烋�[�v�𔲂���
              if Assigned(FOnNsCellValidate) then
              begin
                Value := Cells[Prevcell.X, Prevcell.Y];
                FOnNsCellValidate(Self, Prevcell.X, Prevcell.Y, Value, Valid, true);
                if not(Valid) then
                begin
                  CellCheck := False;
                  Break;
                end;
              end;
//            end;
//            end;
            // --- ADD 2010/09/17 H.Matsumoto ---------------------------------------<<<<

            CellCheck := CellCheck and IsBaseCell(NextCell.X, NextCell.Y);
          end;
        end;
    end;

    if not((not CellCheck) or (NextCell.X = Prevcell.X) and (NextCell.Y = Prevcell.Y)) then
    begin
      NextCellRect := FullCell(NextCell.X, NextCell.Y);

      if (goEditing in Options) then
      begin
        HideInplaceEdit;
      end;

      // FocusCell(NextCellRect.Left, NextCellRect.Top); //2010/06/17 DEL �{�{
      GotoCell(NextCellRect.Left, NextCellRect.Top); // 2010/06/17 ADD �{�{

      // 2010/02/26 add start>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
      NoInplaceEditorScrollInView(NextCellRect.Left, NextCellRect.Top);
      // 2010/02/26 add end<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

      if ((goEditing in Options) and ((Navigation.CursorWalkAlwaysEdit) or (Navigation.AlwaysEdit))) then
      begin
        if IsEditable(NextCellRect.Left, NextCellRect.Top) then
        begin
          ShowInplaceEdit;
        end;
      end;

      {
        SelectCells(NextCellRect.Right, NextCellRect.Bottom, NextCellRect.Left, NextCellRect.Top);
        RepaintCell(Prevcell.X, Prevcell.Y);
        SelectionChanged(NextCellRect.Left, NextCellRect.Top, NextCellRect.Right, NextCellRect.Bottom);
        }
      Result := 0;
      // --- ADD 2010/09/17 H.Matsumoto --------------------------------------->>>>
    end
    else if Assigned(OnNsCellValidate) and  not(CellCheck) and ((Key = VK_LEFT) or (Key = VK_RIGHT) or (Key = VK_DOWN) or (Key = VK_UP)) and Assigned(NormalEdit) then
    begin
      // ���A���C�x���g����SelectCell�C�x���g���������Ȃ��B
      // ������蔭��������悤�ɏC��
      if (bReturn) or ((Key = VK_DOWN) and (Prevcell.Y = RowCount - 1)) or ( (Key = VK_UP) and (Prevcell.Y = FixedRows) ) or ((Key = VK_LEFT) and (NormalEdit.SelStart = 0)) or ((Key = VK_RIGHT) and (NormalEdit.SelStart = Length(NormalEdit.Text))) then
      begin
        SelectCol := -1;
        SelectRow := -1;
        SelectCell(Prevcell.X, Prevcell.Y);
        InitValidate(Prevcell.X, Prevcell.Y);
        // --- ADD 2010/09/27 ���� #13189 ------------------------------------------->>>>
        Result := 0;
        // --- ADD 2010/09/27 ���� #13189 --------------------------------------------<<<

      end;
      // --- ADD 2010/09/17 H.Matsumoto ---------------------------------------<<<<
    end;
  end;
{$ENDREGION}
end;

// ------------------------------------------------------------------------------
// �t�H�[�J�X�ړ����̃X�N���[������
// NoInplaceEditorFocusing���Ăяo��()
// ------------------------------------------------------------------------------
procedure THNsGrid.NoInplaceEditorScrollInView(ColIndex, RowIndex: Integer);
var
  NewLeftCol, NewTopRow: Integer;
begin
  // �x���΍�
  NewTopRow := TopRow;
  NewLeftCol := LeftCol;

  // �ُ�l�̏ꍇ�͏������Ȃ�
  if ColIndex >= ColCount then
    Exit;
  if RowIndex >= RowCount then
    Exit;
  if ColIndex < FixedCols then
    Exit;
  if RowIndex < FixedRows then
    Exit;

  // �X�N���[���s�v�̏ꍇ�͏������Ȃ�
  // �ړ��悪��ʔ͈͓�
  if (ColIndex < LeftCol) or ((LeftCol + VisibleColCount - 1) < ColIndex) then
  begin
    // ����݂̂ł����ł͉������Ȃ�
  end
  else if (RowIndex < TopRow) or ((TopRow + VisibleRowCount - 1) < RowIndex) then
  begin
    // ����݂̂ł����ł͉������Ȃ�
  end
  else
  begin
    Exit;
  end;

  // Col:��ʕ\���͈͈ȉ��̏ꍇ
  if (ColIndex < LeftCol) then
  begin
    NewLeftCol := ColIndex
  end;

  // Col:��ʕ\���͈͈ȏ�̏ꍇ
  if ((LeftCol + VisibleColCount - 1) < ColIndex) then
  begin
    NewLeftCol := (ColIndex - (VisibleColCount - 1));
  end;

  // Row:��ʕ\���͈͈ȉ��̏ꍇ
  if (RowIndex < TopRow) then
  begin
    NewTopRow := RowIndex
  end;

  // Row:��ʕ\���͈͈ȏ�̏ꍇ
  if ((TopRow + VisibleRowCount - 1) < RowIndex) then
  begin
    NewTopRow := (RowIndex - (VisibleRowCount - 1));
  end;

  // TopRow,LwftCol�ɒl�𔽉f
  TopRow := NewTopRow;
  LeftCol := NewLeftCol;

end;
// �ȉ��Q�l�B�{�Ƃ�ScrollInView����
(*
  procedure TAdvStringGrid.ScrollInView(ColIndex,RowIndex: Integer);
  var
  nc,nr: Integer;

  begin
  if ColIndex >= ColCount then
  Exit;
  if RowIndex >= RowCount then
  Exit;

  nc := LeftCol;
  nr := TopRow;
  if (ColIndex < LeftCol) or (ColIndex >= LeftCol + VisibleColCount) then
  begin
  Col := ColIndex;
  nc := ColIndex - (VisibleColCount shr 1);
  if nc < FixedCols then nc := FixedCols;
  end;

  if (RowIndex < TopRow) or (RowIndex >= TopRow + VisibleRowCount) then
  begin
  Row := RowIndex;
  nr := RowIndex - (VisibleRowCount shr 1);
  if nr < FixedRows then nr := FixedRows;
  end;

  if nc > ColCount - (VisibleColCount - 1) then // - 1 to avoid partially visible last column
  nc := ColCount - (VisibleColCount - 1);

  if (ColCount > FixedCols + VisibleColCount) then
  LeftCol := nc;

  if nr > RowCount - (VisibleRowCount - 1) then // -1 to avoid partially visible last row
  nr := RowCount - (VisibleRowCount - 1);

  if RowCount > FixedRows + VisibleRowCount then
  begin
  TopRow := nr;

  if Searchfooter.Visible then
  begin
  if TopRow = RowCount - VisibleRowCount then
  begin
  TopRow := nr + 1;
  end;
  end;
  end;
  end;
*)

// ------------------------------------------------------------------------------
// �_���s��Insert����
// ------------------------------------------------------------------------------
procedure THNsGrid.InsertLogicalRows(LogicalRowIndex, addLogicalRowCount: Integer; UpdateCellControls: Boolean);
var
  PhysicalRowIndex: Integer;
  PhysicalRowCount: Integer;
begin
  PhysicalRowIndex := LogicalRowIndex * FRatioPhysicalToLogical;
  PhysicalRowCount := addLogicalRowCount * FRatioPhysicalToLogical;
  FLogicalRowCount := FLogicalRowCount + addLogicalRowCount;
  Self.InsertRows(PhysicalRowIndex, PhysicalRowCount, UpdateCellControls);

  if FAutoLayoutSet then
  begin
    SetGridLayoutOnlyPart(LogicalRowIndex, LogicalRowIndex + addLogicalRowCount - 1);
  end;
end;

// ------------------------------------------------------------------------------
// �_���s��Remove����
// ------------------------------------------------------------------------------
procedure THNsGrid.RemoveLogicalRows(LogicalRowIndex, RemoveLogicalRowCount: Integer);
var
  PhysicalRowIndex: Integer;
  PhysicalRowCount: Integer;
begin
  if (FLogicalRowCount - RemoveLogicalRowCount) <= 1 then
  begin
    // ���ׂĂ̓��͍s���폜���邱�Ƃ͂ł��܂���
    Exit;
  end;

  PhysicalRowIndex := LogicalRowIndex * FRatioPhysicalToLogical;
  PhysicalRowCount := RemoveLogicalRowCount * FRatioPhysicalToLogical;
  FLogicalRowCount := FLogicalRowCount - RemoveLogicalRowCount;
  Self.RemoveRows(PhysicalRowIndex, PhysicalRowCount);
end;

// ------------------------------------------------------------------------------
// �_���s��Remove����
// ------------------------------------------------------------------------------
procedure THNsGrid.RemoveLogicalRowsEx(LogicalRowIndex, RemoveLogicalRowCount: Integer);
var
  PhysicalRowIndex: Integer;
  PhysicalRowCount: Integer;
begin
  if (FLogicalRowCount - RemoveLogicalRowCount) <= 1 then
  begin
    // ���ׂĂ̓��͍s���폜���邱�Ƃ͂ł��܂���
    Exit;
  end;

  PhysicalRowIndex := LogicalRowIndex * FRatioPhysicalToLogical;
  PhysicalRowCount := RemoveLogicalRowCount * FRatioPhysicalToLogical;
  FLogicalRowCount := FLogicalRowCount - RemoveLogicalRowCount;
  Self.RemoveRowsEx(PhysicalRowIndex, PhysicalRowCount);
end;

// ------------------------------------------------------------------------------
// ���C�A�E�g�̍ăZ�b�g
// ------------------------------------------------------------------------------
procedure THNsGrid.ReSetGridLayout;
begin
  SetGridLayout;
end;
// ------------------------------------------------------------------------------

procedure THNsGrid.MouseMove(Shift: TShiftState; X, Y: Integer);
var
  mrect: TRect;
begin
  if (goRowSelect in Options) then
  begin
    if mouseflg then
    begin
      MouseToCell(X, Y, mrect.Left, mrect.Top);

      if mrect.Top < FixedRows then
      begin
        // mrect.Top := FixedRows
        Exit;
      end;

      x1 := FixedCols;
      x2 := ColCount - 1;

      if not(goRangeSelect in Options) then
      begin
        y1 := (Row div FRatioPhysicalToLogical) * FRatioPhysicalToLogical;
      end;

      y2 := (mrect.Top div FRatioPhysicalToLogical) * FRatioPhysicalToLogical + FRatioPhysicalToLogical - 1;

      if (y1 > y2) then
      begin
        SelectRange(x1, x2, y2 - 1, y1 + 1); // �p����TAdvStringGrid�̕s��H����̂��߁Ay1,y2����ւ��Ă܂�
        SelectRange(x1, x2, y1 + 1, y2 - 1); // �p����TAdvStringGrid�̕s��H����̂��߁Ay1,y2����ւ��Ă܂�
      end
      else
      begin
        SelectRange(x1, x2, y1, y2); // �p����TAdvStringGrid�̕s��H����̂��߁Ay1,y2����ւ��Ă܂�
        SelectRange(x1, x2, y2, y1); // �p����TAdvStringGrid�̕s��H����̂��߁Ay1,y2����ւ��Ă܂�
      end;
      // 2010/03/06 add start>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
      // �}�E�X�ɂė񕝂��ύX�ł��Ȃ��s����C���B
    end
    else
    begin
      inherited MouseMove(Shift, X, Y);
      // 2010/03/06 add end<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    end;
  end
  else
  begin
//--- UPD 2010/10/26 �{�{ -------------------------------------------------->>>>
//    inherited MouseMove(Shift, X, Y);
    if ((MouseMoveX <> -1) or (MouseMoveY <> -1)) and
       ((MouseMoveX <>  X) or (MouseMoveY <>  Y)) then
    begin
      inherited MouseMove(Shift, X, Y);
    end;
    MouseMoveX := X;
    MouseMoveY := Y;
//--- UPD 2010/10/26 �{�{ --------------------------------------------------<<<<
  end;
end;

procedure THNsGrid.MouseUp(Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
begin
  inherited MouseUp(Button, Shift, X, Y);
  mouseflg := False;
end;

procedure THNsGrid.MouseDown(Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
var
  c, r: Integer;
begin
  inherited MouseDown(Button, Shift, X, Y);

  try
    // 2010/03/06 UPD start>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    // �}�E�X�ɂė񕝂��ύX�ł��Ȃ��s����C���B
    MouseToCell(X, Y, c, r);
    if (r < RowCount) then
    begin
      Exit;
    end;
    mouseflg := true;
    // 2010/03/06 UPD end<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

    if (goRangeSelect in Options) then
    begin
      y1 := (Row div Bands.PrimaryLength) * Bands.PrimaryLength;
    end;
  finally
    // --- ADD 2010/03/29 try �` finally ---
    // �}�E�X����ɂ���đI���s��ύX�����ۂɁA�Œ�Z���̑I��E�`�悪�����e���|
    // �x��錻�ۂ��C�� �� 3/6�̏C�����ōĕ`���������Exit�����Ă�̂�����
    Invalidate;
  end;
end;

procedure THNsGrid.SelectionChanged(ALeft, ATop, ARight, ABottom: Integer);
var
  r: TGridRect;
begin
  if (goRowSelect in Options) then
  begin
    // �I��͈͂�␳����
    r.Left := Selection.Left;
    r.Top := (Selection.Top div FRatioPhysicalToLogical) * FRatioPhysicalToLogical;
    r.Bottom := (Selection.Bottom div FRatioPhysicalToLogical) * FRatioPhysicalToLogical + FRatioPhysicalToLogical - 1;
    r.Right := Selection.Right;
    if (r.Top < FixedRows) or (r.Left < FixedCols) then Exit; //2010/11/11 ADD
    Selection := r;
    TopRow := (TopRow div FRatioPhysicalToLogical) * FRatioPhysicalToLogical;

    inherited SelectionChanged(Selection.Left, Selection.Top, Selection.Right, Selection.Bottom);
  end
  else if not(goRangeSelect in Options) then
  begin
    if not IsBaseCell(ALeft, ATop) then
    begin
      r.Left := BaseCell(ALeft, ATop).X;
      r.Top := BaseCell(ALeft, ATop).Y;
      r.Bottom := (Selection.Bottom div FRatioPhysicalToLogical) * FRatioPhysicalToLogical + FRatioPhysicalToLogical - 1;
      r.Right := Selection.Right;
      Selection := r;
      Col := r.Left;
      Row := r.Top;
    end;

    inherited SelectionChanged(Selection.Left, Selection.Top, Selection.Right, Selection.Bottom);
  end
  else
  begin
    inherited SelectionChanged(ALeft, ATop, ARight, ABottom);
  end;

  Invalidate;
end;

procedure THNsGrid.GetVisualProperties(ACol, ARow: Integer; var AState: TGridDrawState; Print, Select, Remap: Boolean; ABrush: TBrush; var AColorTo, AMirrorColor, AMirrorColorTo: TColor; AFont: TFont; var HA: TAlignment; var VA: TVAlignment; var WW: Boolean; var GD: TCellGradientDirection);
begin
  inherited GetVisualProperties(ACol, ARow, AState, Print, Select, Remap, ABrush, AColorTo, AMirrorColor, AMirrorColorTo, AFont, HA, VA, WW, GD);
{$REGION'�o�b�N�A�b�v'}
  {
    if (((ACol = Selection.Left) or (ACol = (BaseCell(Selection.Left,(Selection.Top mod FRatioPhysicalToLogical)).X))) and
    (((ARow = (Selection.Top mod FRatioPhysicalToLogical)) or (ARow = (BaseCell(Selection.Left,(Selection.Top mod FRatioPhysicalToLogical)).Y))))) then
    begin
    ABrush.Color   := ActiveCellColor;
    AColorTo       := ActiveCellColorTo;
    AFont.Color    := ActiveCellFont.Color;
    AMirrorColor   := clNone;
    AMirrorColorTo := clNone;
    end else
    if (ACol < FixedCols) and (ARow = (Selection.Top div FRatioPhysicalToLogical) * FRatioPhysicalToLogical) then
    begin
    ABrush.Color   := ActiveCellColor;
    AColorTo       := ActiveCellColorTo;
    AFont.Color    := ActiveCellFont.Color;
    AFont.Color    := ActiveCellFont.Color;
    AMirrorColor   := clNone;
    AMirrorColorTo := clNone;
    end else
    if (IsFixed(ACol, ARow)) then
    begin
    if (FontColors[ACol, ARow] = clNone) then
    begin
    AFont.Color := FixedFont.Color;
    end else begin
    AFont.Color := FontColors[ACol, ARow];
    end;
    end;
    }
{$ENDREGION}
  if (FActiveCellShow and ((((ACol = Selection.Left) or (ACol = BaseCell(Selection.Left, (Selection.Top mod FRatioPhysicalToLogical)).X)) and ((ARow = (Selection.Top mod FRatioPhysicalToLogical)) or (ARow = (BaseCell(Selection.Left, (Selection.Top mod FRatioPhysicalToLogical)).Y)))) or
        ((ACol < FixedCols) and (ARow = (Selection.Top div FRatioPhysicalToLogical) * FRatioPhysicalToLogical)))) then
  begin
    ABrush.Color := ActiveCellColor;
    AColorTo := ActiveCellColorTo;
    AFont.Color := ActiveCellFont.Color;
    AMirrorColor := clNone;
    AMirrorColorTo := clNone;
  end
  else if (IsFixed(ACol, ARow)) then
  begin
    if (FontColors[ACol, ARow] = clNone) then
    begin
      AFont.Color := FixedFont.Color;
    end
    else
    begin
      AFont.Color := FontColors[ACol, ARow];
    end;
  end;

end;

procedure THNsGrid.DoEditCellDone(Sender: TObject; ACol, ARow: Integer);
begin
  // Invalidate; //DEL 2010/04/23 �{�{

  if Assigned(FOnEditCellDone) then
  begin
    FOnEditCellDone(Self, ACol, ARow);
  end;

  // ShowInplaceEdit;  //DEL 2010/04/23 �{�{
  // --- ADD 2010/04/23 �{�{ ------------------------------------------------>>>>
  if (Row < TopRow) or (Col < LeftCol) then
  begin
  end
  else
  begin
    ShowInplaceEdit;
  end;
  // --- ADD 2010/04/23 �{�{ ------------------------------------------------<<<<
end;

// --- ADD 2010/05/20 �{�{ -------------------------------------------------->>>>
procedure THNsGrid.ShowInplaceEdit;
begin
  // �Z���̕ҏW���ɕʂ̃A�v���P�[�V�����Ƀt�H�[�J�X��J�ڂ����Ė߂����ۂ�
  // �Z���̕ҏW��Ԃ���������Ă��܂��A�X�ɃZ���̕`�悪���������Ȃ�s�
  // �ɑΉ�����B �� PM.NS����̏�Q��
  Application.ProcessMessages; //�ŐV�̓R�����g //2010/10/25

  DoImeMode(Self, Col, Row); // ADD 2010/06/15 M.Kubota

  inherited ShowInplaceEdit;
end;
// --- ADD 2010/05/20 �{�{ --------------------------------------------------<<<<

// --- ADD 2010/06/15 M.Kubota ---------------------------------------------->>>>
procedure THNsGrid.HideInplaceEdit;
begin
  if Assigned(NormalEdit) then
  begin
    // �O�̂��߁A�f�t�H���g�ɖ߂��Ă���
    FInplaceEditImeMode := imDisable;
    (NormalEdit as THNsInplaceEdit).ImeMode := imDisable;
  end;

  inherited HideInplaceEdit;
end;
// --- ADD 2010/06/15 M.Kubota ----------------------------------------------<<<<
{$REGION '<<<<--- DEL 2010/06/30 M.Kubota -------------------------------------------->>>>'}
(* Windows 7�̊��ŁA�v���O�����I�����ɃG���[����������ׂɍ폜
  //--- ADD 2010/05/20 �{�{ -------------------------------------------------->>>>
  {���b�Z�[�W��߂܂���}
  procedure THNsGrid.HookWndProc( var Msg:TMessage );
  begin
  // ���̃A�v���P�[�V��������t�H�[�J�X���J�ڂ��������R���|�[�l���g���Ō��m
  // �o����悤�ɁA�I�[�i�[�ł���t�H�[���̃��b�Z�[�W���t�b�N����
  if (Msg.Msg = WM_ACTIVATE) then
  begin
  if (Msg.WParam <> WA_INACTIVE) then
  begin
  if (OwnerForm.ActiveControl = Self) then
  begin
  if not ((Row < TopRow) or (Col < LeftCol)) then
  begin
  if IsEditable(Col, Row) then
  begin
  if (NormalEdit <> nil) then
  begin
  NormalEdit.SetFocus;
  end;
  end;
  end;
  end;
  //--- ADD 2010/06/10 �{�{ -------------------------------------------->>>>
  FActivate := True;
  end else
  begin
  FActivate := False;
  //--- ADD 2010/06/10 �{�{ --------------------------------------------<<<<
  end;
  end else
  if (Msg.Msg = WM_CLOSE) and (Assigned(FAddress)) then
  begin
  SetWindowLong(OwnerForm.Handle,GWL_WNDPROC,Longint(FAddress));
  end;

  With Msg do
  begin
  //���b�Z�[�W������������(�d�v)
  Result := CallWindowProc(FAddress ,Handle,Msg,WParam,LParam );
  end;
  end;
  //--- ADD 2010/05/20 �{�{ --------------------------------------------------<<<<
*)
{$ENDREGION}

// --- ADD 2010/06/04 �{�{ -------------------------------------------------->>>>
// ------------------------------------------------------------------------------
// LogicalScroll �̃Z�b�g
// ------------------------------------------------------------------------------
procedure THNsGrid.SetLogicalScroll(const Value: Boolean);
begin
  FLogicalScroll := Value;
end;

// ------------------------------------------------------------------------------
// CursorMode �̃Z�b�g
// ------------------------------------------------------------------------------
procedure THNsGrid.SetCursorMode(const Value: TCursorMode);
begin
  FCursorMode := Value;
end;

// ------------------------------------------------------------------------------
// TopLeftChanged
// ------------------------------------------------------------------------------
procedure THNsGrid.TopLeftChanged;
var
  iTopLogicalLine: Integer;
begin
  try // 2010/06/15 ADD �{�{

    if (not FLogicalScroll) then
      Exit; // �����è��LogicalScroll��False�̏ꍇ�͑ΏۊO

    // --- ADD 2010/06/09 �{�{ ---------------------------------------------->>>>
    if (FSaveLeftCol <> Self.LeftCol) then
    begin
      FSaveLeftCol := Self.LeftCol;
      Exit;
    end;

    if (not FTopRowFlg) then
    begin
      FTopRowFlg := true;
      Exit;
    end;
    // --- ADD 2010/06/09 �{�{ ----------------------------------------------<<<<

    try
      // BeginUpdate; //2010/06/15 DEL �{�{
      iTopLogicalLine := Self.TopRow mod FRatioPhysicalToLogical;

      // if (iTopLogicalLine <> 0) then begin //�擪�s���_�����ׂ̂P�s�ڈȊO�̏ꍇ
      // --- ADD 2010/06/09 �{�{ -------------------------------------------->>>>
      if (iTopLogicalLine <> 0) and // �擪�s���_�����ׂ̂P�s�ڈȊO�̏ꍇ
        (((Self.RowCount - 1) - Self.TopRow) >= Self.VisibleRowCount) then
      begin
        // --- ADD 2010/06/09 �{�{ --------------------------------------------<<<<
        if (FSaveTopRow < Self.TopRow) then
          Self.TopRow := Self.TopRow + (FRatioPhysicalToLogical - iTopLogicalLine)
        else
          Self.TopRow := Self.TopRow - iTopLogicalLine;
        Exit;
      end;
      FSaveTopRow := Self.TopRow;
    finally
      // EndUpdate; //2010/06/15 DEL �{�{
    end;
  finally // 2010/06/15 ADD �{�{
    inherited; // 2010/06/15 ADD �{�{
  end; // 2010/06/15 ADD �{�{
end;
// --- ADD 2010/06/04 �{�{ --------------------------------------------------<<<<

// --- ADD 2010/06/09 �{�{ -------------------------------------------------->>>>
// ------------------------------------------------------------------------------
// LogicalScroll �̃`�F�b�N
// ------------------------------------------------------------------------------
procedure THNsGrid.LogicalScrollChk(OldCol, OldRow, NewCol, NewRow: Integer);
var
  iNewLogicalLine: Integer;
  iLine: Integer;
  iTopRow: Integer;
begin
  if (not FLogicalScroll) then
    Exit; // �����è��LogicalScroll��False�̏ꍇ�͑ΏۊO
  if (OldRow = NewRow) then
    Exit;
  try
    // BeginUpdate; //2010/06/15 DEL �{�{

    // �_������(n�s1����)�̒��̍s�ԍ�
    iNewLogicalLine := NewRow mod FRatioPhysicalToLogical + 1;

    iTopRow := Self.TopRow;
    iLine := NewRow - Self.TopRow + 1; // �ړ��s�ԍ�

    // TopRow�͈ړ��O�̒l�̂��ߍĎ擾
    if (iLine < 1) then
      iTopRow := NewRow;

    if (iLine > Self.VisibleRowCount) then
      iTopRow := NewRow - Self.VisibleRowCount + 1;

    iLine := NewRow - iTopRow + 1;

    if ((iLine + (FRatioPhysicalToLogical - iNewLogicalLine)) > Self.VisibleRowCount) then
    begin
      // �ړ���̘_�����ׂ̑S�s���ŏI���ׂɕ\������Ȃ��ꍇ
      FTopRowFlg := False;
      Self.TopRow := NewRow + (FRatioPhysicalToLogical - iNewLogicalLine) - Self.VisibleRowCount + 1;
    end;

    if ((iLine - iNewLogicalLine) < 0) then
    begin
      // �ړ���̘_�����ׂ̑S�s���擪���ׂɕ\������Ȃ��ꍇ
      FTopRowFlg := False;
      Self.TopRow := NewRow - iNewLogicalLine + 1;
    end;

  finally
    // EndUpdate; //2010/06/15 DEL �{�{
  end;
end;

// ------------------------------------------------------------------------------
// InitValidate
// ------------------------------------------------------------------------------
procedure THNsGrid.InitValidate(ACol, ARow: Integer);
begin
  // CellChanging�ňړ��s�̏ꍇ��InitValidate�����s���Ȃ�
  if (not FCellChang) then
    Exit;
  inherited;
end;
//--- ADD 2010/12/21 �{�{ --------------------------------------------------->>>
// ------------------------------------------------------------------------------
// CanEditShow
// ------------------------------------------------------------------------------
function THNsGrid.CanEditShow: Boolean;
var
  PreCellCache : String;           //2011/03/10 ADD �x
begin
//  if (not FCellChang) then Exit; //2011/03/10 DEL �x
//  Result := inherited;           //2011/03/10 DEL �x
//--- ADD 2011/03/10 �x ----------------------------------------------------->>>

  PreCellCache := OriginalCellValue;

  Result := inherited CanEditShow;

  if (not FCellChang) then begin
    FCellCache := PreCellCache;
  end;
//--- ADD 2011/03/10 �x -----------------------------------------------------<<<
//--- ADD 2011/03/22 ���I --------------------------------------------------->>>
  //Active�Ɠ����ɓ����Z�����N���b�N���ꂽ�p�̏���
  if (FOriSet = True) and (FOriValFlg = True) then begin
    FCellCache := FOriValue;

    //Debug�p���i�R�����g�A�E�g�j
    //OutPutDebugString(pChar(Name +'CanEditShow OriginalCellValue:' + OriginalCellValue));
  end;
//--- ADD 2011/03/22 ���I ---------------------------------------------------<<<

end;
//--- ADD 2010/12/21 �{�{ ---------------------------------------------------<<<

// ------------------------------------------------------------------------------
// ValidateCell
// ------------------------------------------------------------------------------
function THNsGrid.ValidateCell(const NewValue: string): Boolean;
begin
  Result := true;
  // �E�B���h�E�ؑ֎���ValidateCell�͎��s���Ȃ�
  if (not FActivate) then
    Exit;

  Result := inherited ValidateCell(NewValue);

//--- ADD 2011/03/22 ���I ----------------------------------------------------->>>
  if (Result = True) then begin
    //Debug�p���i�R�����g�A�E�g�j
    //OutPutDebugString(pChar(Name +'ValidateCell �t���O�N���b�V��'));

    FOriSet := False;
    FOriValFlg := False;
    FOriValue := '';
  end;
//--- ADD 2011/03/22 ���I -----------------------------------------------------<<<
end;
// --- ADD 2010/06/09 �{�{ --------------------------------------------------<<<<

// --- ADD 2010/09/13 �{�{ #13189 ------------------------------------------->>>>
procedure THNsGrid.SetCursorJump(const Value: Boolean);
begin
  FCursorJump := Value;
end;
// --- ADD 2010/09/13 �{�{ #13189 --------------------------------------------<<<

//--- ADD 2010/10/26 �{�{ -------------------------------------------------->>>>
procedure THNsGrid.SetActiveCellColorMode(const Value: Boolean);
begin
  FActiveCellColorMode := Value;
end;
//--- ADD 2010/10/26 �{�{ --------------------------------------------------<<<<

{ THNsInplaceEdit }

procedure THNsInplaceEdit.WMChar(var Msg: TWMKey);
var
  AddStr: String;
begin
  AddStr := WideChar(Msg.CharCode);

  if (LengthLimit > 0) and (Length(AnsiString(Text + AddStr)) > LengthLimit) and (SelLength = 0) and (Msg.CharCode <> VK_BACK) and (Msg.CharCode <> VK_ESCAPE) and (Msg.CharCode <> VK_RETURN) then
  begin
    Exit;
  end;

  inherited;
end;

// --- ADD 2010/09/17 H.Matsumoto --------------------------------------->>>>
function THNsGrid.SelectCell(ACol, ARow: longint): Boolean;
var
  PreCellCache : String;           //2011/03/10 ADD �x
  SelRow,SelCol,PreRow,PreCol : integer;       //hori <<<
  Value: String;
  LogicalRow : Integer; //2010/10/27 ADD �{�{
begin
  Result := True;

  //hori >>>
  PreCellCache := OriginalCellValue;

  SelRow := ARow;
  PreRow := Row;
  SelCol := ACol;
  PreCol := Col;
  //hori <<<

  if Assigned(OnNsCellValidate) and not(IsMergedCell(ACol, ARow) and (not IsBaseCell(ACol, ARow))) then
  begin
    if (SelectCol <> -1) then
    begin
      // if (ACol = SelectCol) and (ARow = SelectRow)  then begin
      // if not(IsMergedCell(ACol, ARow) and (not IsBaseCell(ACol, ARow))) then begin
      // SelectVal := Cells[SelectCol,SelectRow];
      // end else if (ACol = SelectCol) and (ARow = SelectRow) then begin
      SelectVal := Cells[SelectCol, SelectRow];
      // end;
    end
    else
    begin
      SelectVal := Cells[ACol, ARow];
    end;
    // if SelectCol = -1 then begin
    // SelectVal := Cells[ACol,ARow];
    // end;
    if not((ACol = SelectCol) and (ARow = SelectRow)) then
    begin
      if SelectCol = -1 then
      begin
        SelectCol := ACol;
        SelectRow := ARow;
      end;
      FOnNsCellValidate(Self, SelectCol, SelectRow, SelectVal, Result, False);
    end;

    // �Z���ړ�������Ɋ��������ꍇ�͂��̏���ێ�����
    if Result then
    begin
      SelectCol := ACol;
      SelectRow := ARow;
      SelectVal := Cells[ACol, ARow];
    end;

    // --- ADD 2010/09/21 H.Matsumoto --------------------------------------->>>>
    if not(Result) and (ACol = SelectCol) and (ARow = SelectRow) then begin
      //Result := True;
      ShowInplaceEdit;
    end;
    // --- ADD 2010/09/21 H.Matsumoto ---------------------------------------<<<<
  end;

//--- ADD 2010/10/27 �{�{ -------------------------------------------------->>>>
  if (goRowSelect in Options) or
     (ActiveCellColorMode) then
  begin
    SelectionColor := ActiveCellColor;
  end else begin
    if (Bands.Active = True) then begin
      SelectionColor := Bands.PrimaryColor;
      LogicalRow := (ARow - FixedRows) div FRatioPhysicalToLogical;
      if ((LogicalRow mod 2) = 1) then begin
        SelectionColor := Bands.SecondaryColor;
      end;
    end;
  end;
//--- ADD 2010/10/27 �{�{ --------------------------------------------------<<<<
//--- ADD 2011/03/16 �x ----------------------------------------------------<<<<

  Result := (Result and inherited);

//hori >>>
//  if OriginalCellValue <> PreCellCache then begin
//    showmessage('Ori:'+ OriginalCellValue + ' <> ' +'Pre:'+ PreCellCache);
//
//    if result then showmessage('result = true')
//    else           showmessage('result = false');
//    if FCellChang then showmessage('FCellChang = true')
//    else           showmessage('FCellChang = false');
//
//    showmessage(' SelRow = ' + IntToStr(SelRow) +
//                ' SelCol = ' + IntToStr(SelCol) +
//                ' PreRow = ' + IntToStr(PreRow) +
//                ' PreCol = ' + IntToStr(PreCol));
//
//  end;

//  if (not FCellChang) then begin
//    if (not Result) then begin
//      FCellCache := PreCellCache;
//    end;
//  end;

//  showmessage(' SelRow = ' + IntToStr(SelRow) +
//              ' SelCol = ' + IntToStr(SelCol) +
//              ' PreRow = ' + IntToStr(PreRow) +
//              ' PreCol = ' + IntToStr(PreCol) + #13#10 + 'FCell:'+ FCellCache + '  ' +'Pre:'+ PreCellCache);

  if (SelRow = PreRow) and (SelCol = PreCol) then begin
    //�ړ������͒l��߂�
    FCellCache := PreCellCache;

//    showmessage('FCell:'+ FCellCache);
  end;

//hori <<<
end;
//--- ADD 2011/03/16 �x ----------------------------------------------------<<<<
// --- ADD 2010/09/17 H.Matsumoto ---------------------------------------<<<<

// --- ADD 2010/09/14 �{�{ #6892 -------------------------------------------->>>>
procedure THNsInplaceEdit.WMPaste(var Msg: TMessage);
var
  CopyText: WideString;
  NewStr: AnsiString;
  CopyLen: Integer;
begin
  try
    CopyText := ClipBoard.AsText; // �N���b�v�{�[�h�̒l
    NewStr := AnsiString(ClipBoard.AsText);

    if (LengthLimit > 0) and (LengthLimit < Length(AnsiString(Text + CopyText))) then
    begin
      // �\��t���\�ȕ�����(�o�C�g��)���Z�o �� �������|(�\���������|���]������)
      CopyLen := LengthLimit - (Length(AnsiString(Text)) - Length(AnsiString(SelText)));
      // �\��t����������N���b�v�{�[�h�ɃR�s�[
      case ByteType(NewStr, CopyLen) of
        mbSingleByte, mbTrailByte:
          ClipBoard.AsText := Copy(NewStr, 1, CopyLen);
      else
        ClipBoard.AsText := Copy(NewStr, 1, CopyLen - 1);
      end;
    end;

    // �p�����̏������ďo
    inherited;
  finally
    ClipBoard.AsText := CopyText; // �N���b�v�{�[�h�̒l�����ɖ߂�
  end;
end;
// --- ADD 2010/09/14 �{�{ #6892 ---------------------------------------------<<<
//--- ADD 2010/10/26 �{�{ -------------------------------------------------->>>>
procedure THNsInplaceEdit.WMSetFocus(var Msg: TWMSetFocus);
begin
  if (Self.FGrid.FActiveCellColorMode) then
    Self.Brush.Color := Self.FGrid.ActiveCellColor;
  inherited;
end;
//--- ADD 2010/10/26 �{�{ --------------------------------------------------<<<<

//--- ADD 2010/10/21 Miyamoto ---------------------------------------------->>>>
procedure THNsInplaceEdit.BoundsChanged;
var
  r: TRect;
begin
//  inherited;

  r := FGrid.CellRect(FGrid.Col,FGrid.Row);

  Top := r.Top;
  Left := r.Left;

  if FGrid.UseRightToLeftAlignment then
  begin
    r.Left := r.Left + 1;
  end;

  SetWindowPos(self.Handle, 0, r.Left, r.Top, r.Right - r.Left - 1, r.Bottom - r.Top - 1,
    SWP_NOREDRAW or SWP_NOZORDER or SWP_SHOWWINDOW);

  R := Rect(3, 3, Width - 2, Height);
  {$IFNDEF TMSDOTNET}
  SendMessage(Handle, EM_SETRECTNP, 0, LongInt(@R));
  {$ENDIF}
  {$IFDEF TMSDOTNET}
  Perform(EM_SETRECTNP,0,R);
  {$ENDIF}
  SendMessage(Handle, EM_SCROLLCARET, 0, 0);
end;
//--- ADD 2010/10/21 Miyamoto ----------------------------------------------<<<<

//--- ADD 2010/11/18 �{�{ -------------------------------------------------->>>>
procedure THNsGrid.SaveFilterConditions;
begin
  //�i��������ۑ�
//--- UPD 2010/11/25 �{�{ -------------------------------------------------->>>>
//  SetLength(FPreFilterConditions, 0);
//  FPreFilterConditions := Copy(FFilterConditions, 0, Length(FFilterConditions));
  SetLength(PreFilterConditions, 0);
  PreFilterConditions := Copy(FFilterConditions, 0, Length(FFilterConditions));
//--- UPD 2010/11/25 �{�{ --------------------------------------------------<<<<
end;
procedure THNsGrid.BackFilterConditions;
var
  iCol :Integer;
  iRow :Integer;
begin
  //�O��̍i�������ɖ߂�
  SetLength(FFilterConditions, 0);
//--- UPD 2010/11/25 �{�{ -------------------------------------------------->>>>
//  FFilterConditions := Copy(FPreFilterConditions, 0, Length(FPreFilterConditions));
  FFilterConditions := Copy(PreFilterConditions, 0, Length(PreFilterConditions));
//--- UPD 2010/11/25 �{�{ --------------------------------------------------<<<<

  for iRow:=0 to (FixedRows - 1) do begin
    for iCol:=0 to (ColCount - 1) do begin
      FixedColStatus[iCol,iRow] := FixedColStatus[iCol,iRow];
    end;
  end;
end;
//--- ADD 2010/11/18 �{�{ --------------------------------------------------<<<<
//--- ADD 2010/11/22 �{�{ -------------------------------------------------->>>>
procedure THNsGrid.UpdateScrollBars(Refresh: Boolean);
begin
  if (ScrollBarAlways = saNone) then
  begin
    if Refresh then
    begin
      if (VisibleRowCount + FixedRows >= RowCount) then
        ShowScrollBar(self.Handle, SB_VERT, False)
      else
        ShowScrollBar(self.Handle, SB_VERT, True);

      if (VisibleColCount + FixedCols >= ColCount) then
        ShowScrollBar(self.Handle, SB_HORZ, False)
      else
        ShowScrollBar(self.Handle, SB_HORZ, True);
    end;
    Exit;
  end;
  if (VisibleRowCount + FixedRows >= RowCount) then
    ShowScrollbar(self.Handle, SB_VERT, (ScrollBarAlways in [saBoth, saVert]));

  if (VisibleColCount + FixedCols >= ColCount) then
    ShowScrollbar(self.Handle, SB_HORZ, (ScrollBarAlways in [saBoth, saHorz]));

  if (VisibleRowCount + FixedRows >= RowCount) then
    EnableScrollBar(self.Handle, SB_VERT, ESB_DISABLE_BOTH);

  if (VisibleColCount + FixedCols >= ColCount) then
    EnableScrollBar(self.Handle, SB_HORZ, ESB_DISABLE_BOTH);

  if (VisibleRowCount + FixedRows < RowCount) then
  begin
    EnableScrollBar(self.Handle, SB_VERT, ESB_ENABLE_BOTH);
  end;

  if (VisibleColCount + FixedCols < ColCount) then
    EnableScrollBar(self.Handle, SB_HORZ, ESB_ENABLE_BOTH);
end;
//--- ADD 2010/11/22 �{�{ --------------------------------------------------<<<<


initialization

OrgWndProc := nil; // ADD 2010/06/30 M.Kubota

end.
