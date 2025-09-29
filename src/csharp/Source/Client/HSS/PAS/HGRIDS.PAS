
{*******************************************************}
{                                                       }
{       Delphi Visual Component Library                 }
{                                                       }
{       Copyright (c) 1995,96 Borland International     }
{                                                       }
{*******************************************************}
{ UpDate : 20090929 iwa HSS100に組み込み                }
{           TXStringGrid ⇒ THStringGridに変更          }
{ Update : 20091007 noguchi 終了時にエラーになる箇所を  }
{                           修正                        }
{*******************************************************}

unit HGrids;

{$R-}

interface

uses SysUtils, Messages, Windows, Classes, Graphics, Menus, Controls, Forms,
  StdCtrls, Mask, Dialogs, HVersion;

const
  MaxCustomExtents = MaxListSize;
  MaxShortInt = High(ShortInt);

type
  EInvalidGridOperation = class(Exception);

  { Internal grid types }
  TXGetExtentsFunc = function(Index: Longint): Integer of object;

  TXGridAxisDrawInfo = record
    EffectiveLineWidth: Integer;
    FixedBoundary: Integer;
    GridBoundary: Integer;
    GridExtent: Integer;
    LastFullVisibleCell: Longint;
    FullVisBoundary: Integer;
    FixedCellCount: Integer;
    FirstGridCell: Integer;
    GridCellCount: Integer;
    GetExtent: TXGetExtentsFunc;
  end;

  TXGridDrawInfo = record
    Horz, Vert: TXGridAxisDrawInfo;
  end;

  TXGridState = (gsNormal, gsSelecting, gsRowSizing, gsColSizing,
    gsRowMoving, gsColMoving, gsSelectingRow, gsSelectingCol);

  { TXGridEdit }
  { The inplace editor is not intended to be used outside the grid }

  TXCustomGrid = class;

  TXGridEdit = class(TCustomMaskEdit)
  private
    FGrid: TXCustomGrid;
    FClickTime: Longint;
    procedure InternalMove(const Loc: TRect; Redraw: Boolean);
    procedure SetGrid(Value: TXCustomGrid);
    procedure CMShowingChanged(var Message: TMessage); message CM_SHOWINGCHANGED;
    procedure WMGetDlgCode(var Message: TWMGetDlgCode); message WM_GETDLGCODE;
    procedure WMPaste(var Message); message WM_PASTE;
    procedure WMCut(var Message); message WM_CUT;
    procedure WMClear(var Message); message WM_CLEAR;
  protected
    procedure CreateParams(var Params: TCreateParams); override;
    procedure DblClick; override;
    function EditCanModify: Boolean; override;
    procedure KeyDown(var Key: Word; Shift: TShiftState); override;
    procedure KeyPress(var Key: Char); override;
    procedure KeyUp(var Key: Word; Shift: TShiftState); override;
    procedure BoundsChanged; virtual;
    procedure UpdateContents; virtual;
    procedure WndProc(var Message: TMessage); override;
    property  Grid: TXCustomGrid read FGrid;
  public
    constructor Create(AOwner: TComponent); override;
    procedure Deselect;
    procedure Hide;
    procedure Invalidate; override;
    procedure Move(const Loc: TRect);
    function PosEqual(const Rect: TRect): Boolean;
    procedure SetFocus; override;
    procedure UpdateLoc(const Loc: TRect);
    function Visible: Boolean;
    property ImeMode;
    property MaxLength;
  end;

  { TXCustomGrid }

  { TXCustomGrid is an abstract base class that can be used to implement
    general purpose grid style controls.  The control will call DrawCell for
    each of the cells allowing the derived class to fill in the contents of
    the cell.  The base class handles scrolling, selection, cursor keys, and
    scrollbars.
      DrawCell
        Called by Paint. If DefaultDrawing is true the font and brush are
        intialized to the control font and cell color.  The cell is prepainted
        in the cell color and a focus rect is drawn in the focused cell after
        DrawCell returns.  The state passed will reflect whether the cell is
        a fixed cell, the focused cell or in the selection.
      SizeChanged
        Called when the size of the grid has changed.
      BorderStyle
        Allows a single line border to be drawn around the control.
      Col
        The current column of the focused cell (runtime only).
      ColCount
        The number of columns in the grid.
      ColWidths
        The width of each column (up to a maximum MaxCustomExtents, runtime
        only).
      DefaultColWidth
        The default column width.  Changing this value will throw away any
        customization done either visually or through ColWidths.
      DefaultDrawing
        Indicates whether the Paint should do the drawing talked about above in
        DrawCell.
      DefaultRowHeight
        The default row height.  Changing this value will throw away any
        customization done either visually or through RowHeights.
      FixedCols
        The number of non-scrolling columns.  This value must be at least one
        below ColCount.
      FixedRows
        The number of non-scrolling rows.  This value must be at least one
        below RowCount.
      GridLineWidth
        The width of the lines drawn between the cells.
      LeftCol
        The index of the left most displayed column (runtime only).
      Options
        The following options are available:
          goFixedHorzLine:     Draw horizontal grid lines in the fixed cell area.
          goFixedVertLine:     Draw veritical grid lines in the fixed cell area.
          goHorzLine:          Draw horizontal lines between cells.
          goVertLine:          Draw vertical lines between cells.
          goRangeSelect:       Allow a range of cells to be selected.
          goDrawFocusSelected: Draw the focused cell in the selected color.
          goRowSizing:         Allows rows to be individually resized.
          goColSizing:         Allows columns to be individually resized.
          goRowMoving:         Allows rows to be moved with the mouse
          goColMoving:         Allows columns to be moved with the mouse.
          goEditing:           Places an edit control over the focused cell.
          goAlwaysShowEditor:  Always shows the editor in place instead of
                               waiting for a keypress or F2 to display it.
          goTabs:              Enables the tabbing between columns.
          goRowSelect:         Selection and movement is done a row at a time.
      Row
        The row of the focused cell (runtime only).
      RowCount
        The number of rows in the grid.
      RowHeights
        The hieght of each row (up to a maximum MaxCustomExtents, runtime
        only).
      ScrollBars
        Determines whether the control has scrollbars.
      Selection
        A TGridRect of the current selection.
      TopLeftChanged
        Called when the TopRow or LeftCol change.
      TopRow
        The index of the top most row displayed (runtime only)
      VisibleColCount
        The number of columns fully displayed.  There could be one more column
        partially displayed.
      VisibleRowCount
        The number of rows fully displayed.  There could be one more row
        partially displayed. }

  TXGridOption = (goEditing, goAlwaysShowEditor, goTabs,
    goRangeSelect, goRowSelect, goDrawFocusSelected,
    goSelectCol, goSelectRow, goLineNumber,
    goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine,
    goColSizing,  goColMoving, goRowSizing, goRowMoving,
    goThumbTracking, goMultiSelect);


  TXGridOptions = set of TXGridOption;
  TXGridDrawState = set of (gdSelected, gdFocused, gdFixed);
  TXGridScrollDirection = set of (sdLeft, sdRight, sdUp, sdDown);
  TXGridTextMode = (gtLeft, gtRight, gtCenter);

  TXGridCoord = record
    X: Longint;
    Y: Longint;
  end;

  TXGridRect = record
    case Integer of
      0: (Left, Top, Right, Bottom: Longint);
      1: (TopLeft, BottomRight: TXGridCoord);
  end;

  TXSelectCellEvent = procedure (Sender: TObject; ACol, ARow: Longint;
    var CanSelect: Boolean) of object;
  TXDrawCellEvent = procedure (Sender: TObject; ACol, ARow: Longint;
    Rect: TRect; State: TXGridDrawState) of object;

  TXGridCellInfo = class(TPersistent)
  private
    FCellSize : Integer;
    FTabStops : Boolean;
    FSelecting: Boolean;
  public
    constructor Create; virtual;
    procedure Assign(Source: TPersistent); override;
    function Duplicate: TXGridCellInfo; virtual;
    function IsEqual(Source: TXGridCellInfo): Boolean; virtual;
    property CellSize : Integer read FCellSize  write FCellSize;
    property TabStops : Boolean read FTabStops  write FTabStops default True;
    property Selecting: Boolean read FSelecting write FSelecting;
  end;

  TXCustomGrid = class(TCustomControl)
  private
    FBorderColor     : TColor;           (* 追加 1997/02/13 *)
    FOffScreenDrawing: Boolean;
    FBitmap: TBitmap;
    FDefaultLineNumberWidth: Integer;
    FDefaultColInfo  : TXGridCellInfo;   (* 追加 1996/06/26 *)
    FDefaultRowInfo  : TXGridCellInfo;   (* 追加 1996/06/26 *)
    FAutoSize        : Boolean;          (* 追加 1996/06/26 *)
    FDataChanged     : Boolean;          (* 追加 1996/06/26 *)
    FColInfos        : Pointer;          (* 追加 1996/06/26 *)
    FRowInfos        : Pointer;          (* 追加 1996/06/26 *)
    FAnchor: TXGridCoord;
    FBorderStyle: TBorderStyle;
    FCanEditModify: Boolean;
    FColCount: Longint;
    FCurrent: TXGridCoord;
    FNScrlCols: Integer;
    FNScrlRows: Integer;
    FFixedCols: Integer;
    FFixedRows: Integer;
    FFixedColor: TColor;
    FGridLineWidth: Integer;
    FOptions: TXGridOptions;
    FRowCount: Longint;
    FScrollBars: TScrollStyle;
    FTopLeft: TXGridCoord;
    FSizingIndex: Longint;
    FSizingPos, FSizingOfs: Integer;
    FMoveIndex, FMovePos: Longint;
    FHitTest: TPoint;
    FInplaceEdit: TXGridEdit;
    FInplaceCol, FInplaceRow: Longint;
    FDefaultDrawing: Boolean;
    FEditorMode: Boolean;
    FColOffset: Integer;
(*$IFNDEF USLIB*)
    function  GetImeMode: TImeMode;
    procedure UpdImeMode(Value: TImeMode);
(*$ENDIF USLIB*)
    procedure SetBorderColor(Value: TColor);
    procedure SetOffScreenDrawing(Value: Boolean);
    procedure SetDefaultLineNumberWidth(Value: Integer);
    function  GetDrawCellWidth(Cell: Longint): Integer;
    function  GetDrawCellHeight(Cell: Longint): Integer;
    function  CalcStartCol(DrawInfo: TXGridDrawInfo; Start: integer; var ACol: Longint): Integer;
    function  CalcStartRow(DrawInfo: TXGridDrawInfo; Start: integer; var ARow: Longint): Integer;
    function  GetColInfo(Index: Longint): TXGridCellInfo;         (* 追加 1996/06/26 *)
    function  GetRowInfo(Index: Longint): TXGridCellInfo;         (* 追加 1996/06/26 *)
    procedure SetColInfo(Index: Longint; Info: TXGridCellInfo);   (* 追加 1996/06/26 *)
    procedure SetRowInfo(Index: Longint; Info: TXGridCellInfo);   (* 追加 1996/06/26 *)
    function  GetSelectCol(Index: Longint): Boolean;
    function  GetSelectRow(Index: Longint): Boolean;
    procedure SetColSelect(Index: Longint; Value: Boolean);
    procedure SetRowSelect(Index: Longint; Value: Boolean);
    procedure UpdateColSelect(Index: Longint; Value: Boolean);
    procedure UpdateRowSelect(Index: Longint; Value: Boolean);
    procedure UpdateLineNumberWidth;                              (* 追加 1996/06/26 *)
    procedure AdjustDefaultRowHeight;                             (* 追加 1996/06/26 *)
    function CalcCoordFromPoint(X, Y: Integer;
      const DrawInfo: TXGridDrawInfo): TXGridCoord;
    procedure CalcDrawInfo(var DrawInfo: TXGridDrawInfo);
    procedure CalcDrawInfoXY(var DrawInfo: TXGridDrawInfo;
      UseWidth, UseHeight: Integer);
    procedure CalcFixedInfo(var DrawInfo: TXGridDrawInfo);
    function CalcMaxTopLeft(const Coord: TXGridCoord;
      const DrawInfo: TXGridDrawInfo): TXGridCoord;
    procedure CalcSizingState(X, Y: Integer; var State: TXGridState;
      var Index: Longint; var SizingPos, SizingOfs: Integer;
      var FixedInfo: TXGridDrawInfo);
    procedure ChangeSize(NewColCount, NewRowCount: Longint);
    procedure ClampInView(const Coord: TXGridCoord);
    procedure DrawSizingLine(const DrawInfo: TXGridDrawInfo);
    procedure DrawMove;
    procedure FocusCell(ACol, ARow: Longint; MoveAnchor: Boolean);
    function  GetAvgCharWidth: Integer;                          (* 追加 1996/06/26 *)
    procedure GridRectToScreenRect(GridRect: TXGridRect;
      var ScreenRect: TRect; IncludeLine: Boolean);
    procedure HideEdit;
    procedure Initialize;
    procedure ModifyScrollBar(ScrollBar, ScrollCode, Pos: Cardinal);
    procedure MoveAdjust(var CellPos: Longint; FromIndex, ToIndex: Longint);
    procedure MoveAnchor(const NewAnchor: TXGridCoord);
    procedure MoveAndScroll(Mouse, CellHit: Integer; var DrawInfo: TXGridDrawInfo;
      var Axis: TXGridAxisDrawInfo; Scrollbar: Integer);
    procedure MoveCurrent(ACol, ARow: Longint; MoveAnchor, Show: Boolean);
    procedure MoveTopLeft(ALeft, ATop: Longint);
    procedure SelectionMoved(const OldSel: TXGridRect);
    procedure ScrollDataInfo(DX, DY: Integer; var DrawInfo: TXGridDrawInfo);
    procedure TopLeftMoved(const OldTopLeft: TXGridCoord);
    procedure UpdateDefaultRowHeight;                            (* 追加 1996/06/26 *)
    procedure UpdateScrollPos;
    procedure UpdateScrollRange;
    function GetColTextLens(Index: Longint): Integer;            (* 追加 1996/06/26 *)
    function GetColWidths(Index: Longint): Integer;              (* 追加 1996/06/26 *)
    function GetDefaultColWidth: Integer;                        (* 追加 1996/06/26 *)
    function GetDefaultRowHeight: Integer;                       (* 追加 1996/06/26 *)
    function GetRowHeights(Index: Longint): Integer;
    function GetSelection: TXGridRect;
    function GetTabStops(Index: Longint): Boolean;
    function GetVisibleColCount: Integer;
    function GetVisibleRowCount: Integer;
    procedure ReadColWidths(Reader: TReader);
    procedure ReadRowHeights(Reader: TReader);
    procedure SetAutoSize(Value: Boolean);                       (* 追加 1996/06/26 *)
    procedure SetBorderStyle(Value: TBorderStyle);
    procedure SetCol(Value: Longint);
    procedure SetColCount(Value: Longint);
    procedure SetColTextLens(Index: Longint; Value: Integer);    (* 追加 1996/06/26 *)
    procedure SetColWidths(Index: Longint; Value: Integer);
    procedure SetDefaultColWidth(Value: Integer);
    procedure SetDefaultRowHeight(Value: Integer);
    procedure SetEditorMode(Value: Boolean);
    procedure SetFixedColor(Value: TColor);
    function  GetFixedCols: Integer;
    function  GetFixedRows: Integer;
    procedure SetFixedCols(Value: Integer);
    procedure SetFixedRows(Value: Integer);
    procedure SetNScrlCols(Value: Integer);
    procedure SetNScrlRows(Value: Integer);
    procedure SetGridLineWidth(Value: Integer);
    procedure SetLeftCol(Value: Longint);
    procedure SetOptions(Value: TXGridOptions);
    procedure SetRow(Value: Longint);
    procedure SetRowCount(Value: Longint);
    procedure SetRowHeights(Index: Longint; Value: Integer);
    procedure SetScrollBars(Value: TScrollStyle);
    procedure SetSelection(Value: TXGridRect);
    procedure SetTabStops(Index: Longint; Value: Boolean);
    procedure SetTopRow(Value: Longint);
    procedure UpdateEdit;
    procedure UpdateText;
    procedure WriteColWidths(Writer: TWriter);
    procedure WriteRowHeights(Writer: TWriter);
    procedure CMCancelMode(var Msg: TMessage); message CM_CANCELMODE;
    procedure CMFontChanged(var Message: TMessage); message CM_FONTCHANGED;
    procedure CMCtl3DChanged(var Message: TMessage); message CM_CTL3DCHANGED;
    procedure CMDesignHitTest(var Msg: TCMDesignHitTest); message CM_DESIGNHITTEST;
    procedure CMWantSpecialKey(var Msg: TCMWantSpecialKey); message CM_WANTSPECIALKEY;
    procedure WMChar(var Msg: TWMChar); message WM_CHAR;
    procedure WMCommand(var Message: TWMCommand); message WM_COMMAND;
    procedure WMEraseBkgnd(var Message: TWmEraseBkgnd); message WM_ERASEBKGND;  (* 追加 1996/06/26 *)
    procedure WMGetDlgCode(var Msg: TWMGetDlgCode); message WM_GETDLGCODE;
    procedure WMHScroll(var Msg: TWMHScroll); message WM_HSCROLL;
    procedure WMKillFocus(var Msg: TWMKillFocus); message WM_KILLFOCUS;
    procedure WMLButtonDown(var Message: TMessage); message WM_LBUTTONDOWN;
    procedure WMNCHitTest(var Msg: TWMNCHitTest); message WM_NCHITTEST;
    procedure WMSetCursor(var Msg: TWMSetCursor); message WM_SETCURSOR;
    procedure WMSetFocus(var Msg: TWMSetFocus); message WM_SETFOCUS;
    procedure WMSize(var Msg: TWMSize); message WM_SIZE;
    procedure WMTimer(var Msg: TWMTimer); message WM_TIMER;
    procedure WMVScroll(var Msg: TWMVScroll); message WM_VSCROLL;
  protected
    FGridState: TXGridState;
    FSaveCellExtents: Boolean;
    function CreateEditor: TXGridEdit; virtual;
    procedure CreateParams(var Params: TCreateParams); override;
    procedure KeyDown(var Key: Word; Shift: TShiftState); override;
    procedure KeyPress(var Key: Char); override;
    procedure Loaded; override;
    procedure MouseDown(Button: TMouseButton; Shift: TShiftState;
      X, Y: Integer); override;
    procedure MouseMove(Shift: TShiftState; X, Y: Integer); override;
    procedure MouseUp(Button: TMouseButton; Shift: TShiftState;
      X, Y: Integer); override;
    function BoxRect(ALeft, ATop, ARight, ABottom: Longint): TRect;
    procedure DoExit; override;
    function CanEditAcceptKey(Key: Char): Boolean; dynamic;
    function CanGridAcceptKey(Key: Word; Shift: TShiftState): Boolean; dynamic;
    function CanEditModify: Boolean; dynamic;
    function CanEditShow: Boolean; virtual;
    function GetEditText(ACol, ARow: Longint): string; dynamic;
    procedure SetEditText(ACol, ARow: Longint; const Value: string); dynamic;
    function GetEditMask(ACol, ARow: Longint): string; dynamic;
    function GetEditLimit: Integer; dynamic;
    function GetGridWidth: Integer;
    function GetGridHeight: Integer;
    procedure HideEditor;
    procedure ShowEditor;
    procedure BeginEdit(ACol, ARow: Longint); dynamic; (* 追加 *)
    procedure EndEdit(ACol, ARow: Longint);   dynamic; (* 追加 *)
    procedure ShowEditorChar(Ch: Char);
    procedure InvalidateEditor;
    procedure MoveColumn(FromIndex, ToIndex: Longint);
    procedure ColumnMoved(FromIndex, ToIndex: Longint); dynamic;
    procedure MoveRow(FromIndex, ToIndex: Longint);
    procedure RowMoved(FromIndex, ToIndex: Longint); dynamic;
    procedure DrawCell(ACol, ARow: Longint; ARect: TRect;
      AState: TXGridDrawState); virtual;
    procedure DefineProperties(Filer: TFiler); override;
    function MouseCoord(X, Y: Integer): TXGridCoord;
    procedure MoveColRow(ACol, ARow: Longint; MoveAnchor, Show: Boolean);
    function  SelectCell(ACol, ARow: Longint): Boolean; virtual;
    procedure CurrentChanged; virtual;
    procedure SizeChanged(OldColCount, OldRowCount: Longint); dynamic;
    function  Sizing(X, Y: Integer): Boolean;
    procedure ScrollData(DX, DY: Integer);
    procedure TopLeftChanged; dynamic;
    procedure TimedScroll(Direction: TXGridScrollDirection); dynamic;
    procedure Paint; override;
    procedure PaintRect(ARect: TRect); virtual;
    procedure ColWidthsChanged; dynamic;
    procedure RowHeightsChanged; dynamic;
    procedure DeleteColumn(ACol: Longint);
    procedure DeleteRow(ARow: Longint);
    procedure UpdateDesigner;
    procedure ResizeCol(Index: Longint; OldSize, NewSize: Integer); dynamic;
    procedure ResizeRow(Index: Longint; OldSize, NewSize: Integer); dynamic;
    property DefaultLineNumberWidth: Integer read FDefaultLineNumberWidth write SetDefaultLineNumberWidth;
    property ColInfos[Index: Longint]: TXGridCellInfo read GetColInfo write SetColInfo;  (* 追加 1996/06/26 *)
    property RowInfos[Index: Longint]: TXGridCellInfo read GetRowInfo write SetRowInfo;  (* 追加 1996/06/26 *)
    property SelectCol[Index: Longint]: Boolean read GetSelectCol write SetColSelect;    (* 追加 1996/06/26 *)
    property SelectRow[Index: Longint]: Boolean read GetSelectRow write SetRowSelect;    (* 追加 1996/06/26 *)
    property AutoSize: Boolean read FAutoSize write SetAutoSize default True;            (* 追加 1996/06/26 *)
    property BorderStyle: TBorderStyle read FBorderStyle write SetBorderStyle default bsSingle;
    property BorderColor: TColor read FBorderColor write SetBorderColor default clAppWorkSpace; (* 追加 *)
    property Col: Longint read FCurrent.X write SetCol;
    property Color default clWindow;
    property ColCount: Longint read FColCount write SetColCount default 5;
    property ColTextLens[Index: Longint]: Integer read GetColTextLens write SetColTextLens;  (* 追加 1996/06/26 *)
    property ColWidths[Index: Longint]: Integer read GetColWidths write SetColWidths;
    property DataChanged: Boolean read FDataChanged write FDataChanged;                      (* 追加 1996/06/26 *)
    property DefaultColWidth: Integer read GetDefaultColWidth write SetDefaultColWidth default 64;
    property DefaultDrawing: Boolean read FDefaultDrawing write FDefaultDrawing default True;
    property DefaultRowHeight: Integer read GetDefaultRowHeight write SetDefaultRowHeight default 24;
    property EditorMode: Boolean read FEditorMode write SetEditorMode;
    property FixedColor: TColor read FFixedColor write SetFixedColor default clBtnFace;
    property FixedCols: Integer read GetFixedCols write SetFixedCols default 1;
    property FixedRows: Integer read GetFixedRows write SetFixedRows default 1;
    property NScrlCols: Integer read FNScrlCols write SetNScrlCols default 0;
    property NScrlRows: Integer read FNScrlRows write SetNScrlRows default 0;
    property GridHeight: Integer read GetGridHeight;
    property GridLineWidth: Integer read FGridLineWidth write SetGridLineWidth default 1;
    property GridWidth: Integer read GetGridWidth;
    property LeftCol: Longint read FTopLeft.X write SetLeftCol;
    property Options: TXGridOptions read FOptions write SetOptions
      default [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine,
      goRangeSelect];
    property ParentColor default False;
    property Row: Longint read FCurrent.Y write SetRow;
    property RowCount: Longint read FRowCount write SetRowCount default 5;
    property RowHeights[Index: Longint]: Integer read GetRowHeights write SetRowHeights;
    property ScrollBars: TScrollStyle read FScrollBars write SetScrollBars default ssBoth;
    property Selection: TXGridRect read GetSelection write SetSelection;
    property TabStops[Index: Longint]: Boolean read GetTabStops write SetTabStops;
    property TopRow: Longint read FTopLeft.Y write SetTopRow;
    property VisibleColCount: Integer read GetVisibleColCount;
    property VisibleRowCount: Integer read GetVisibleRowCount;
(*$IFNDEF USLIB*)
    property ImeMode: TImeMode read GetImeMode write UpdImeMode;
(*$ENDIF USLIB*)
  public
    constructor Create(AOwner: TComponent); override;
    destructor Destroy; override;
    function   CellRect(ACol, ARow: Longint): TRect;
    function   MouseToCell(X, Y: Integer; var ACol, ARow: Longint): Boolean;
    procedure  DrawCellText(ARect: TRect; Text: String; Mode: TXGridTextMode); virtual;
    procedure  InvalidateGrid;
    procedure  InvalidateRect(ARect: TXGridRect);
    procedure  InvalidateCell(ACol, ARow: Longint);
    procedure  InvalidateCol(ACol: Longint);
    procedure  InvalidateRow(ARow: Longint);
    procedure  InvertRect(const Rect: TRect);
    procedure  ResetColSelect;
    procedure  ResetRowSelect;
    property   InplaceEditor: TXGridEdit read FInplaceEdit;
  published
    property OffScreenDrawing: Boolean read FOffScreenDrawing write SetOffScreenDrawing;
    property TabStop default True;
  end;

  { TXDrawGrid }

  { A grid relies on the OnDrawCell event to display the cells.
     CellRect
       This method returns control relative screen coordinates of the cell or
       an empty rectangle if the cell is not visible.
     EditorMode
       Setting to true shows the editor, as if the F2 key was pressed, when
       goEditing is turned on and goAlwaysShowEditor is turned off.
     MouseToCell
       Takes control relative screen X, Y location and fills in the column and
       row that contain that point.
     OnColumnMoved
       Called when the user request to move a column with the mouse when
       the goColMoving option is on.
     OnDrawCell
       This event is passed the same information as the DrawCell method
       discussed above.
     OnGetEditMask
       Called to retrieve edit mask in the inplace editor when goEditing is
       turned on.
     OnGetEditText
       Called to retrieve text to edit when goEditing is turned on.
     OnRowMoved
       Called when the user request to move a row with the mouse when
       the goRowMoving option is on.
     OnSetEditText
       Called when goEditing is turned on to reflect changes to the text
       made by the editor.
     OnTopLeftChanged
       Invoked when TopRow or LeftCol change. }

  TXChangeEditEvent = procedure (Sender: TObject; ACol, ARow: Longint) of object;
  TXGetEditEvent = procedure (Sender: TObject; ACol, ARow: Longint; var Value: string) of object;
  TXSetEditEvent = procedure (Sender: TObject; ACol, ARow: Longint; const Value: string) of object;
  TXMovedEvent   = procedure (Sender: TObject; FromIndex, ToIndex: Longint) of object;

  TXDrawGrid = class(TXCustomGrid)
  private
    FVersion: TVersion;
    FOnColumnMoved: TXMovedEvent;
    FOnDrawCell: TXDrawCellEvent;
    FOnGetEditMask: TXGetEditEvent;
    FOnGetEditText: TXGetEditEvent;
    FOnRowMoved: TXMovedEvent;
    FOnSelectCell: TXSelectCellEvent;
    FOnCurrentChanged: TNotifyEvent;
    FOnSetEditText: TXSetEditEvent;
    FOnTopLeftChanged: TNotifyEvent;
    FOnBeginEdit: TXChangeEditEvent;
    FOnEndEdit: TXChangeEditEvent;
  protected
    procedure ColumnMoved(FromIndex, ToIndex: Longint); override;
    procedure DrawCell(ACol, ARow: Longint; ARect: TRect;
      AState: TXGridDrawState); override;
    function  GetEditMask(ACol, ARow: Longint): string; override;
    function  GetEditText(ACol, ARow: Longint): string; override;
    procedure RowMoved(FromIndex, ToIndex: Longint); override;
    function  SelectCell(ACol, ARow: Longint): Boolean; override;
    procedure CurrentChanged; override;
    procedure SetEditText(ACol, ARow: Longint; const Value: string); override;
    procedure TopLeftChanged; override;
    procedure BeginEdit(ACol, ARow: Longint); override; (* 追加 *)
    procedure EndEdit(ACol, ARow: Longint);   override; (* 追加 *)
  public
    property Canvas;
    property Col;
    property ColTextLens;    (*  追加 1996/06/26 *)
    property ColWidths;
    property DataChanged;
    property EditorMode;
    property GridHeight;
    property GridWidth;
    property LeftCol;
    property Selection;
    property Row;
    property RowHeights;
    property SelectCol;      (*  追加 1996/07/13 *)
    property SelectRow;      (*  追加 1996/07/13 *)
    property TabStops;
    property TopRow;
    procedure LineUp;         //1996.11.25
    procedure LineDown;
    procedure PageUp;
    procedure PageDown;

(* Add matsu 1997-04-19 *)
    constructor Create(AOwner: TComponent); override;
    destructor Destroy; override;
(* Add End *)

  published
(* Add matsu 1997-04-19 *)
    property Version: TVersion read FVersion write FVersion stored False;
(* Add End *)
(*$IFNDEF USLIB*)
    property ImeMode;
(*$ENDIF USLIB*)
    property Align;
    property AutoSize;       (*  追加 1996/06/26 *)
    property BorderStyle;
    property BorderColor;    (* 追加 1996/02/13 *)
    property Color;
    property ColCount;
    property Ctl3D;
    property DefaultColWidth;
    property DefaultRowHeight;
    property DefaultDrawing;
    property DefaultLineNumberWidth;
    property DragCursor;
    property DragMode;
    property Enabled;
    property FixedColor;
    property FixedCols;
    property RowCount;
    property FixedRows;
    property Font;
    property GridLineWidth;
    property Options;
    property NScrlCols;
    property NScrlRows;
    property ParentColor;
    property ParentCtl3D;
    property ParentFont;
    property ParentShowHint;
    property PopupMenu;
    property ScrollBars;
    property ShowHint;
    property TabOrder;
    property TabStop;
    property Visible;
    property VisibleColCount;
    property VisibleRowCount;
    property OnClick;
    property OnColumnMoved: TXMovedEvent read FOnColumnMoved write FOnColumnMoved;
    property OnDblClick;
    property OnDragDrop;
    property OnDragOver;
    property OnDrawCell: TXDrawCellEvent read FOnDrawCell write FOnDrawCell;
    property OnEndDrag;
    property OnEnter;
    property OnExit;
    property OnGetEditMask: TXGetEditEvent read FOnGetEditMask write FOnGetEditMask;
    property OnGetEditText: TXGetEditEvent read FOnGetEditText write FOnGetEditText;
    property OnKeyDown;
    property OnKeyPress;
    property OnKeyUp;
    property OnMouseDown;
    property OnMouseMove;
    property OnMouseUp;
    property OnRowMoved: TXMovedEvent read FOnRowMoved write FOnRowMoved;
    property OnSelectCell: TXSelectCellEvent read FOnSelectCell write FOnSelectCell;
    property OnCurrentChanged: TNotifyEvent read FOnCurrentChanged write FOnCurrentChanged;
    property OnSetEditText: TXSetEditEvent read FOnSetEditText write FOnSetEditText;
    property OnStartDrag;
    property OnTopLeftChanged: TNotifyEvent read FOnTopLeftChanged write FOnTopLeftChanged;
    property OnBeginEdit: TXChangeEditEvent read FOnBeginEdit write FOnBeginEdit; (* 追加 *)
    property OnEndEdit: TXChangeEditEvent read FOnEndEdit write FOnEndEdit; (* 追加 *)
  end;

  { THStringGrid }

  { THStringGrid adds to TXDrawGrid the ability to save a string and associated
    object (much like TListBox).  It also adds to the DefaultDrawing the drawing
    of the string associated with the current cell.
      Cells
        A ColCount by RowCount array of strings which are associated with each
        cell.  By default, the string is drawn into the cell before OnDrawCell
        is called.  This can be turned off (along with all the other default
        drawing) by setting DefaultDrawing to false.
      Cols
        A TStrings object that contains the strings and objects in the column
        indicated by Index.  The TStrings will always have a count of RowCount.
        If a another TStrings is assigned to it, the strings and objects beyond
        RowCount are ignored.
      Objects
        A ColCount by Rowcount array of TObject's associated with each cell.
        Object put into this array will *not* be destroyed automatically when
        the grid is destroyed.
      Rows
        A TStrings object that contains the strings and objects in the row
        indicated by Index.  The TStrings will always have a count of ColCount.
        If a another TStrings is assigned to it, the strings and objects beyond
        ColCount are ignored. }

  THStringGrid = class;

  THStringGridStrings = class(TStrings)
  private
    FGrid: THStringGrid;
    FIndex: Integer;
    procedure CalcXY(Index: Integer; var X, Y: Integer);
  protected
    procedure Clear; override;
    function Add(const S: string): Integer; override;
    function Get(Index: Integer): string; override;
    function GetCount: Integer; override;
    function GetObject(Index: Integer): TObject; override;
    procedure Put(Index: Integer; const S: string); override;
    procedure PutObject(Index: Integer; AObject: TObject); override;
    procedure SetUpdateState(Updating: Boolean); override;
  public
    constructor Create(AGrid: THStringGrid; AIndex: Longint);
    procedure Assign(Source: TPersistent); override;
  published
  end;


  THStringGrid = class(TXDrawGrid)
  private
    FVersion: TVersion;
    FData: Pointer;
    FRows: Pointer;
    FCols: Pointer;
    FUpdating: Boolean;
    FNeedsUpdating: Boolean;
    FEditUpdate: Integer;
    procedure DisableEditUpdate;
    procedure EnableEditUpdate;
    procedure Initialize;
    procedure CellUpdate(ACol, ARow: Integer);
    procedure SetUpdateState(Updating: Boolean);
    function GetCells(ACol, ARow: Integer): string;
    function GetCols(Index: Integer): TStrings;
    function GetObjects(ACol, ARow: Integer): TObject;
    function GetRows(Index: Integer): TStrings;
    procedure SetCells(ACol, ARow: Integer; const Value: string);
    procedure SetCols(Index: Integer; Value: TStrings);
    procedure SetObjects(ACol, ARow: Integer; Value: TObject);
    procedure SetRows(Index: Integer; Value: TStrings);
    function EnsureColRow(Index: Integer; IsCol: Boolean): THStringGridStrings;
    function EnsureDataRow(ARow: Integer): Pointer;
  protected
    procedure ColumnMoved(FromIndex, ToIndex: Longint); override;
    procedure DrawCell(ACol, ARow: Longint; ARect: TRect;
      AState: TXGridDrawState); override;
    function GetEditText(ACol, ARow: Longint): string; override;
    procedure SetEditText(ACol, ARow: Longint; const Value: string); override;
    procedure RowMoved(FromIndex, ToIndex: Longint); override;
  public
    constructor Create(AOwner: TComponent); override;
    destructor Destroy; override;
    property Cells[ACol, ARow: Integer]: string read GetCells write SetCells;
    property Cols[Index: Integer]: TStrings read GetCols write SetCols;
    property Objects[ACol, ARow: Integer]: TObject read GetObjects write SetObjects;
    property Rows[Index: Integer]: TStrings read GetRows write SetRows;
  published
    property Version: TVersion read FVersion write FVersion stored False;
  end;

implementation

uses Consts;

type
  PIntArray = ^TIntArray;
  TIntArray = array[0..MaxCustomExtents] of Integer;

  PObjArray = ^TObjArray;                                     (*  追加 1996/06/26 *)
  TObjArray = array[0..MaxCustomExtents] of TXGridCellInfo;    (*  追加 1996/06/26 *)

{$IFDEF VER90}     //Delphi2.0j Version
procedure InvalidOp(const id: Integer);
begin
  raise EInvalidGridOperation.CreateRes(id);
end;
{$ELSE}            //Delphi3
procedure InvalidOp(const id: string);
begin
  raise EInvalidGridOperation.Create(id);
end;
{$ENDIF}

function IMin(A, B: Integer): Integer;
begin
  Result := B;
  if A < B then Result := A;
end;

function IMax(A, B: Integer): Integer;
begin
  Result := B;
  if A > B then Result := A;
end;

function CoordInRect(const ACoord: TXGridCoord; const ARect: TXGridRect): Boolean;
begin
  with ACoord, ARect do
    Result := (X >= Left) and (X <= Right) and (Y >= Top) and (Y <= Bottom);
end;

function GridRect(Coord1, Coord2: TXGridCoord): TXGridRect;
begin
  with Result do
  begin
    Left := Coord2.X;
    if Coord1.X < Coord2.X then Left := Coord1.X;
    Right := Coord1.X;
    if Coord1.X < Coord2.X then Right := Coord2.X;
    Top := Coord2.Y;
    if Coord1.Y < Coord2.Y then Top := Coord1.Y;
    Bottom := Coord1.Y;
    if Coord1.Y < Coord2.Y then Bottom := Coord2.Y;
  end;
end;

function GridRectUnion(const ARect1, ARect2: TXGridRect): TXGridRect;
begin
  with Result do
  begin
    Left := ARect1.Left;
    if ARect1.Left > ARect2.Left then Left := ARect2.Left;
    Right := ARect1.Right;
    if ARect1.Right < ARect2.Right then Right := ARect2.Right;
    Top := ARect1.Top;
    if ARect1.Top > ARect2.Top then Top := ARect2.Top;
    Bottom := ARect1.Bottom;
    if ARect1.Bottom < ARect2.Bottom then Bottom := ARect2.Bottom;
  end;
end;

function PointInGridRect(Col, Row: Longint; const Rect: TXGridRect): Boolean;
begin
  Result := (Col >= Rect.Left) and (Col <= Rect.Right) and (Row >= Rect.Top)
    and (Row <= Rect.Bottom);
end;

type
  TXorRects = array[0..3] of TRect;

procedure XorRects(const R1, R2: TRect; var XorRects: TXorRects);
var
  Intersect, Union: TRect;

  function PtInRect(X, Y: Integer; const Rect: TRect): Boolean;
  begin
    with Rect do Result := (X >= Left) and (X <= Right) and (Y >= Top) and
      (Y <= Bottom);
  end;

  function Includes(const P1: TPoint; var P2: TPoint): Boolean;
  begin
    with P1 do
    begin
      Result := PtInRect(X, Y, R1) or PtInRect(X, Y, R2);
      if Result then P2 := P1;
    end;
  end;

  function Build(var R: TRect; const P1, P2, P3: TPoint): Boolean;
  begin
    Build := True;
    with R do
      if Includes(P1, TopLeft) then
      begin
        if not Includes(P3, BottomRight) then BottomRight := P2;
      end
      else if Includes(P2, TopLeft) then BottomRight := P3
      else Build := False;
  end;

begin
  FillChar(XorRects, SizeOf(XorRects), 0);
  if not Bool(IntersectRect(Intersect, R1, R2)) then
  begin
    { Don't intersect so its simple }
    XorRects[0] := R1;
    XorRects[1] := R2;
  end
  else
  begin
    UnionRect(Union, R1, R2);
    if Build(XorRects[0],
      Point(Union.Left, Union.Top),
      Point(Union.Left, Intersect.Top),
      Point(Union.Left, Intersect.Bottom)) then
      XorRects[0].Right := Intersect.Left;
    if Build(XorRects[1],
      Point(Intersect.Left, Union.Top),
      Point(Intersect.Right, Union.Top),
      Point(Union.Right, Union.Top)) then
      XorRects[1].Bottom := Intersect.Top;
    if Build(XorRects[2],
      Point(Union.Right, Intersect.Top),
      Point(Union.Right, Intersect.Bottom),
      Point(Union.Right, Union.Bottom)) then
      XorRects[2].Left := Intersect.Right;
    if Build(XorRects[3],
      Point(Union.Left, Union.Bottom),
      Point(Intersect.Left, Union.Bottom),
      Point(Intersect.Right, Union.Bottom)) then
      XorRects[3].Top := Intersect.Bottom;
  end;
end;

procedure InheritExtents(var Extents: Pointer; NewInfo: TXGridCellInfo);
var
  OldObj: TXGridCellInfo;
  i, j: Longint;
begin
  if Assigned(Extents) then
  begin
    j := PLongint(Extents)^;
    for i := 1 to j do
    begin
      OldObj := PObjArray(Extents)^[i];
      if Assigned(OldObj) then
      begin
        PObjArray(Extents)^[i] := NewInfo.Duplicate;
        PObjArray(Extents)^[i].Assign(OldObj);
        OldObj.Free;
      end;
    end;
  end;
end;

procedure UpdateExtents(var Extents: Pointer; NewSize: Longint);
var
  OldSize: Longint;
  i: Longint;
begin
  if Assigned(Extents) then OldSize := PLongint(Extents)^ else OldSize := 0;
  if (NewSize <> OldSize) then
  begin
    for i := NewSize + 1 to OldSize do
      if Assigned(PObjArray(Extents)^[i]) then PObjArray(Extents)^[i].Free;
    ReallocMem(Extents, (NewSize + 1) * SizeOf(Pointer));
    if Assigned(Extents) then
    begin
      for i := OldSize + 1 to NewSize do
        PObjArray(Extents)^[i] := nil;
      PLongint(Extents)^ := NewSize;
    end;
  end;
end;

procedure MoveExtent(var Extents: Pointer; FromIndex, ToIndex: Longint);
var
  Extent: TXGridCellInfo;
begin
  if Assigned(Extents) then begin
    Inc(FromIndex);
    Inc(ToIndex  );
    Extent := PObjArray(Extents)^[FromIndex];
    if FromIndex < ToIndex then
      Move(PObjArray(Extents)^[FromIndex + 1], PObjArray(Extents)^[FromIndex],
        (ToIndex - FromIndex) * SizeOf(Pointer))
    else if FromIndex > ToIndex then
      Move(PObjArray(Extents)^[ToIndex], PObjArray(Extents)^[ToIndex + 1],
        (FromIndex - ToIndex) * SizeOf(Pointer));
    PObjArray(Extents)^[ToIndex] := Extent;
  end;
end;

function CompareExtents(E1, E2: Pointer): Boolean;
var
  I: Integer;
begin
  Result := False;
  if E1 <> nil then
  begin
    if E2 <> nil then
    begin
      if PLongint(E1)^ <> PLongint(E2)^ then Exit;
      for I := 1 to PLongint(E1)^ do
        if not PObjArray(E1)^[I].IsEqual(PObjArray(E2)^[I]) then Exit;
      Result := True;
    end
  end
  else Result := E2 = nil;
end;

{ Private. LongMulDiv multiplys the first two arguments and then
  divides by the third.  This is used so that real number
  (floating point) arithmetic is not necessary.  This routine saves
  the possible 64-bit value in a temp before doing the divide.  Does
  not do error checking like divide by zero.  Also assumes that the
  result is in the 32-bit range (Actually 31-bit, since this algorithm
  is for unsigned). }

function LongMulDiv(Mult1, Mult2, Div1: Longint): Longint; stdcall;
  external 'kernel32.dll' name 'MulDiv';

type
  TSelection = record
    StartPos, EndPos: Integer;
  end;

constructor TXGridEdit.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
  ParentCtl3D := False;
  Ctl3D := False;
  TabStop := False;
  BorderStyle := bsNone;
end;

procedure TXGridEdit.CreateParams(var Params: TCreateParams);
begin
  inherited CreateParams(Params);
  Params.Style := Params.Style or ES_MULTILINE;
end;

procedure TXGridEdit.SetGrid(Value: TXCustomGrid);
begin
  FGrid := Value;
end;

procedure TXGridEdit.CMShowingChanged(var Message: TMessage);
begin
  { Ignore showing using the Visible property }
end;

procedure TXGridEdit.WMGetDlgCode(var Message: TWMGetDlgCode);
begin
  inherited;
  if goTabs in Grid.Options then
    Message.Result := Message.Result or DLGC_WANTTAB;
end;

procedure TXGridEdit.WMPaste(var Message);
begin
  if not EditCanModify then Exit;
  inherited
end;

procedure TXGridEdit.WMClear(var Message);
begin
  if not EditCanModify then Exit;
  inherited;
end;

procedure TXGridEdit.WMCut(var Message);
begin
  if not EditCanModify then Exit;
  inherited;
end;

procedure TXGridEdit.DblClick;
begin
  Grid.DblClick;
end;

function TXGridEdit.EditCanModify: Boolean;
begin
  Result := Grid.CanEditModify;
end;

procedure TXGridEdit.KeyDown(var Key: Word; Shift: TShiftState);

  function Selection: TSelection;
  begin
    SendMessage(Handle, EM_GETSEL, Longint(@Result.StartPos), Longint(@Result.EndPos));
  end;

  procedure SendToParent;
  begin
    Grid.KeyDown(Key, Shift);
    Key := 0;
  end;

  procedure ParentEvent;
  var
    GridKeyDown: TKeyEvent;
  begin
    GridKeyDown := Grid.OnKeyDown;
    if Assigned(GridKeyDown) then GridKeyDown(Grid, Key, Shift);
  end;

  function ForwardMovement: Boolean;
  begin
    // Result := goAlwaysShowEditor in Grid.Options;
    with Selection do
      Result := (goAlwaysShowEditor in Grid.Options)
        or (Key = VK_RIGHT) or (StartPos = EndPos);
  end;

  function Ctrl: Boolean;
  begin
    Result := ssCtrl in Shift;
  end;

  function RightSide: Boolean;
  begin
    with Selection do
      Result := ((StartPos = 0) or (EndPos = StartPos)) and
        (EndPos = GetTextLen);
   end;

  function LeftSide: Boolean;
  begin
    with Selection do
      Result := (StartPos = 0) and ((EndPos = 0) or (EndPos = GetTextLen));
  end;

begin
  case Key of
    VK_UP, VK_DOWN, VK_PRIOR, VK_NEXT, VK_ESCAPE: SendToParent;
    VK_INSERT : if Shift = [] then SendToParent
                else if (Shift = [ssShift]) and not Grid.CanEditModify then Key := 0;
    VK_LEFT  : if ForwardMovement and (Ctrl or LeftSide) then SendToParent;
    VK_RIGHT : if ForwardMovement and (Ctrl or RightSide) then SendToParent;
    VK_HOME  : if ForwardMovement and (Ctrl or LeftSide) then SendToParent;
    VK_END   : if ForwardMovement and (Ctrl or RightSide) then SendToParent;
    VK_F2    :
      begin
        if (goAlwaysShowEditor in Grid.Options) then
        begin
          if (Selection.StartPos = 0) and (Selection.EndPos = GetTextLen) then Deselect else SelectAll;
        end
        else if Focused then SendToParent else Deselect;
      end;
{
      begin
        ParentEvent;
        if Key = VK_F2 then
        begin
          Deselect;
          Exit;
        end;
      end;
}
    VK_TAB: if not (ssAlt in Shift) then SendToParent;
  end;
  if (Key = VK_DELETE) and not Grid.CanEditModify then Key := 0;
  if Key <> 0 then
  begin
    ParentEvent;
    inherited KeyDown(Key, Shift);
  end;
end;

procedure TXGridEdit.KeyPress(var Key: Char);
var
  Selection: TSelection;
begin
  Grid.KeyPress(Key);
  if (Key in [#32..#255]) and not Grid.CanEditAcceptKey(Key) then
  begin
    Key := #0;
    MessageBeep(0);
  end;
  case Key of
    #9, #27: Key := #0;
    #13:
      begin
        SendMessage(Handle, EM_GETSEL, Longint(@Selection.StartPos), Longint(@Selection.EndPos));
        if (Selection.StartPos = 0) and (Selection.EndPos = GetTextLen) then
          Deselect else
          SelectAll;
        Key := #0;
      end;
    ^H, ^V, ^X, #32..#255:
      if not Grid.CanEditModify then Key := #0;
  end;
  if Key <> #0 then inherited KeyPress(Key);
end;

procedure TXGridEdit.KeyUp(var Key: Word; Shift: TShiftState);
begin
  Grid.KeyUp(Key, Shift);
end;

procedure TXGridEdit.WndProc(var Message: TMessage);
begin
  case Message.Msg of
    WM_SETFOCUS:
      begin
        if GetParentForm(Self).SetFocusedControl(Grid) then Dispatch(Message);
        Exit;
      end;
    WM_LBUTTONDOWN:
      begin
        if GetMessageTime - FClickTime < GetDoubleClickTime then
          Message.Msg := WM_LBUTTONDBLCLK;
        FClickTime := 0;
      end;
  end;
  inherited WndProc(Message);
end;

procedure TXGridEdit.Deselect;
begin
  SendMessage(Handle, EM_SETSEL, $7FFFFFFF, Longint($FFFFFFFF));
end;

procedure TXGridEdit.Invalidate;
var
  Cur: TRect;
begin
  ValidateRect(Handle, nil);
  InvalidateRect(Handle, nil, True);
  Windows.GetClientRect(Handle, Cur);
  MapWindowPoints(Handle, Grid.Handle, Cur, 2);
  ValidateRect(Grid.Handle, @Cur);
  InvalidateRect(Grid.Handle, @Cur, False);
end;

procedure TXGridEdit.Hide;
begin
  if HandleAllocated and IsWindowVisible(Handle) then
  begin
    Invalidate;
    SetWindowPos(Handle, 0, 0, 0, 0, 0, SWP_HIDEWINDOW or SWP_NOZORDER or
      SWP_NOREDRAW);
    if Focused then Windows.SetFocus(Grid.Handle);
  end;
end;

function TXGridEdit.PosEqual(const Rect: TRect): Boolean;
var
  Cur: TRect;
begin
  GetWindowRect(Handle, Cur);
  MapWindowPoints(HWND_DESKTOP, Grid.Handle, Cur, 2);
  Result := EqualRect(Rect, Cur);
end;

procedure TXGridEdit.InternalMove(const Loc: TRect; Redraw: Boolean);
begin
  if IsRectEmpty(Loc) then Hide
  else
  begin
    CreateHandle;
    Redraw := Redraw or not IsWindowVisible(Handle);
    Invalidate;
    with Loc do
      SetWindowPos(Handle, HWND_TOP, Left, Top, Right - Left, Bottom - Top,
        SWP_SHOWWINDOW or SWP_NOREDRAW);
    BoundsChanged;
    if Redraw then Invalidate;
    if Grid.Focused then
      Windows.SetFocus(Handle);
  end;
end;

procedure TXGridEdit.BoundsChanged;
var
  R: TRect;
begin
  R := Rect(2, 2, Width - 2, Height);
  SendMessage(Handle, EM_SETRECTNP, 0, LongInt(@R));
  SendMessage(Handle, EM_SCROLLCARET, 0, 0);
end;

procedure TXGridEdit.UpdateLoc(const Loc: TRect);
begin
  InternalMove(Loc, False);
end;

function TXGridEdit.Visible: Boolean;
begin
  Result := IsWindowVisible(Handle);
end;

procedure TXGridEdit.Move(const Loc: TRect);
begin
  InternalMove(Loc, True);
end;

procedure TXGridEdit.SetFocus;
begin
  if IsWindowVisible(Handle) then
    Windows.SetFocus(Handle);
end;

procedure TXGridEdit.UpdateContents;
begin
  Text := '';
  EditMask := Grid.GetEditMask(Grid.Col, Grid.Row);
  Text := Grid.GetEditText(Grid.Col, Grid.Row);
  MaxLength := Grid.GetEditLimit;
end;

{ TXGridCellInfo }

constructor TXGridCellInfo.Create;
begin
  inherited Create;
  FTabStops := True;
end;

function TXGridCellInfo.Duplicate: TXGridCellInfo;
begin
  Result := TXGridCellInfo.Create;
  Result.Assign(Self);
end;

procedure TXGridCellInfo.Assign(Source: TPersistent);
begin
  if (Source is TXGridCellInfo) then
  begin
    CellSize  := TXGridCellInfo(Source).CellSize ;
    TabStops  := TXGridCellInfo(Source).TabStops ;
    Selecting := TXGridCellInfo(Source).Selecting;
  end
  else
    inherited Assign(Source);
end;

function TXGridCellInfo.IsEqual(Source: TXGridCellInfo): Boolean;
begin
  Result := (CellSize  = Source.CellSize )
        and (TabStops  = Source.TabStops )
        and (Selecting = Source.Selecting);
end;

{ TXCustomGrid }

constructor TXCustomGrid.Create(AOwner: TComponent);
const
//  GridStyle = [csCaptureMouse, csOpaque, csDoubleClicks];
  GridStyle = [csCaptureMouse, csDoubleClicks];
begin
  inherited Create(AOwner);
  if not (csDesigning in ComponentState) then Parent := TWinControl(AOwner);
  if NewStyleControls then
    ControlStyle := GridStyle else
    ControlStyle := GridStyle + [csFramed];

  FBitmap := TBitmap.Create;
  FBitmap.Monochrome := False;

  FDefaultColInfo  := TXGridCellInfo.Create;  (* 追加 1996/06/26 *)
  FDefaultRowInfo  := TXGridCellInfo.Create;  (* 追加 1996/06/26 *)
  FDefaultColInfo.CellSize := 64;             (* 追加 1996/06/26 *)
  FDefaultRowInfo.CellSize := 24;             (* 追加 1996/06/26 *)
  FAutoSize := True;                          (* 追加 1996/06/26 *)
  FCanEditModify := True;
  FColCount := 5;
  FRowCount := 5;
  FFixedCols := 1;
  FFixedRows := 1;
  FGridLineWidth := 1;
  FOptions := [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine,
    goRangeSelect];
  FFixedColor := clBtnFace;
  FScrollBars := ssBoth;
  FBorderStyle := bsSingle;
(* Add T.S 1997-02-13 *)
  FBorderColor := clAppWorkSpace;
(* Add End *)
  FDefaultDrawing := True;
  FSaveCellExtents := True;
  FEditorMode := False;
  Color := clWindow;
  ParentColor := False;
  TabStop := True;
  UpdateExtents(FColInfos, FColCount);
  UpdateExtents(FRowInfos, FRowCount);
  SetBounds(Left, Top, FColCount * DefaultColWidth, FRowCount * DefaultRowHeight);
  Initialize;
  UpdateDefaultRowHeight;
end;

destructor TXCustomGrid.Destroy;
begin
  FInplaceEdit.Free;
  UpdateExtents(FColInfos, 0);
  UpdateExtents(FRowInfos, 0);
  FreeMem(FRowInfos);
  FreeMem(FColInfos);
  FDefaultColInfo.Free;   (* 追加 1996/06/26 *)
  FDefaultRowInfo.Free;   (* 追加 1996/06/26 *)
  FBitmap.Free;
  inherited Destroy;
end;

procedure TXCustomGrid.SetOffScreenDrawing(Value: Boolean);
begin
  if (FOffScreenDrawing <> Value) then begin
    FOffScreenDrawing := Value;
    if FOffScreenDrawing then begin
      FBitmap.Width  := Width;
      FBitmap.Height := Height;
    end else begin
      FBitmap.Width  := 8;
      FBitmap.Height := 8;
    end;
    InvalidateGrid;
  end;
end;

function  TXCustomGrid.GetImeMode: TImeMode;
begin
  Result := inherited ImeMode;
end;

procedure TXCustomGrid.UpdImeMode(Value: TImeMode);
begin
  inherited ImeMode := Value;
{$IFDEF VER90}
  inherited SetImeMode;
{$ELSE}
  inherited SetIme;
{$ENDIF}
end;

(* Add T.S 1997-02-13 *)
procedure TXCustomGrid.SetBorderColor(Value: TColor);
begin
  if (Value <> FBorderColor) then
  begin
    FBorderColor := Value;
    InvalidateGrid;
  end;
end;
(* Add End *)

function TXCustomGrid.GetColInfo(Index: Longint): TXGridCellInfo;
begin
  if ((Index >= 0) and (Index < PLongint(FColInfos)^)) then
    Result := PObjArray(FColInfos)^[Index + 1] else Result := nil;
  if not Assigned(Result) then Result := FDefaultColInfo;
end;

function TXCustomGrid.GetRowInfo(Index: Longint): TXGridCellInfo;
begin
  if ((Index >= 0) and (Index < PLongint(FRowInfos)^)) then
    Result := PObjArray(FRowInfos)^[Index + 1] else Result := nil;
  if not Assigned(Result) then Result := FDefaultRowInfo;
end;

procedure TXCustomGrid.SetColInfo(Index: Longint; Info: TXGridCellInfo);
begin
  if ((Index >= 0) or (Index < PLongint(FColInfos)^)) then
    PObjArray(FColInfos)^[Index + 1] := Info;
end;

procedure TXCustomGrid.SetRowInfo(Index: Longint; Info: TXGridCellInfo);
begin
  if ((Index >= 0) and (Index < PLongint(FRowInfos)^)) then
    PObjArray(FRowInfos)^[Index + 1] := Info;
end;


function TXCustomGrid.BoxRect(ALeft, ATop, ARight, ABottom: Longint): TRect;
var
  GridRect: TXGridRect;
begin
  GridRect.Left := ALeft;
  GridRect.Right := ARight;
  GridRect.Top := ATop;
  GridRect.Bottom := ABottom;
  GridRectToScreenRect(GridRect, Result, False);
end;

procedure TXCustomGrid.DoExit;
begin
  inherited DoExit;
  if not (goAlwaysShowEditor in Options) then HideEditor;
end;

function TXCustomGrid.CellRect(ACol, ARow: Longint): TRect;
begin
  Result := BoxRect(ACol, ARow, ACol, ARow);
end;

function TXCustomGrid.CanEditAcceptKey(Key: Char): Boolean;
begin
  Result := True;
end;

function TXCustomGrid.CanGridAcceptKey(Key: Word; Shift: TShiftState): Boolean;
begin
  Result := True;
end;

function TXCustomGrid.CanEditModify: Boolean;
begin
  Result := FCanEditModify;
end;

function TXCustomGrid.CanEditShow: Boolean;
begin
  Result := ([goRowSelect, goEditing] * Options = [goEditing]) and
    FEditorMode and not (csDesigning in ComponentState) and HandleAllocated and
    ((goAlwaysShowEditor in Options) or (ValidParentForm(Self).ActiveControl = Self));
end;

function TXCustomGrid.GetEditMask(ACol, ARow: Longint): string;
begin
  Result := '';
end;

function TXCustomGrid.GetEditText(ACol, ARow: Longint): string;
begin
  Result := '';
end;

procedure TXCustomGrid.SetEditText(ACol, ARow: Longint; const Value: string);
begin
end;

function TXCustomGrid.GetEditLimit: Integer;
begin
  Result := 0;
end;

procedure TXCustomGrid.HideEditor;
begin
  FEditorMode := False;
  HideEdit;
end;

procedure TXCustomGrid.ShowEditor;
begin
  FEditorMode := True;
  UpdateEdit;
end;

procedure TXCustomGrid.ShowEditorChar(Ch: Char);
begin
  ShowEditor;
  if FInplaceEdit <> nil then
    PostMessage(FInplaceEdit.Handle, WM_CHAR, Word(Ch), 0);
end;

procedure TXCustomGrid.AdjustDefaultRowHeight;  (* 追加 1996/06/26 *)
var
  DC: HDC;
  SaveFont: HFont;
  Metrics: TTextMetric;
begin
  DC := GetDC(0);
  SaveFont := SelectObject(DC, Font.Handle);
  GetTextMetrics(DC, Metrics);
  SelectObject(DC, SaveFont);
  ReleaseDC(0, DC);
  DefaultRowHeight := Metrics.tmHeight + 4;
end;

procedure TXCustomGrid.UpdateDefaultRowHeight;  (* 追加 1996/06/26 *)
begin
  if FAutoSize then AdjustDefaultRowHeight;
end;

procedure TXCustomGrid.InvalidateEditor;
begin
  FInplaceCol := -1;
  FInplaceRow := -1;
  UpdateEdit;
end;

procedure TXCustomGrid.ReadColWidths(Reader: TReader);
var
  I: Integer;
begin
  with Reader do
  begin
    ReadListBegin;
    for I := 0 to ColCount - 1 do ColWidths[I] := ReadInteger;
    ReadListEnd;
  end;
end;

procedure TXCustomGrid.ReadRowHeights(Reader: TReader);
var
  I: Integer;
begin
  with Reader do
  begin
    ReadListBegin;
    for I := 0 to RowCount - 1 do RowHeights[I] := ReadInteger;
    ReadListEnd;
  end;
end;

procedure TXCustomGrid.WriteColWidths(Writer: TWriter);
var
  I: Integer;
begin
  with Writer do
  begin
    WriteListBegin;
    for I := 0 to ColCount - 1 do WriteInteger(ColWidths[I]);
    WriteListEnd;
  end;
end;

procedure TXCustomGrid.WriteRowHeights(Writer: TWriter);
var
  I: Integer;
begin
  with Writer do
  begin
    WriteListBegin;
    for I := 0 to RowCount - 1 do WriteInteger(RowHeights[I]);
    WriteListEnd;
  end;
end;

procedure TXCustomGrid.DefineProperties(Filer: TFiler);

  function DoColWidths: Boolean;
  begin
    if Filer.Ancestor <> nil then
      Result := not CompareExtents(TXCustomGrid(Filer.Ancestor).FColInfos, FColInfos)
    else
      Result := True;
  end;

  function DoRowHeights: Boolean;
  begin
    if Filer.Ancestor <> nil then
      Result := not CompareExtents(TXCustomGrid(Filer.Ancestor).FRowInfos, FRowInfos)
    else
      Result := True;
  end;


begin
  inherited DefineProperties(Filer);
  if FSaveCellExtents then
    with Filer do
    begin
      DefineProperty('ColWidths', ReadColWidths, WriteColWidths, DoColWidths);
      DefineProperty('RowHeights', ReadRowHeights, WriteRowHeights, DoRowHeights);
    end;
end;

procedure TXCustomGrid.MoveColumn(FromIndex, ToIndex: Longint);
var
  Rect: TXGridRect;
begin
  if FromIndex = ToIndex then Exit;
  MoveExtent(FColInfos, FromIndex, ToIndex);
  if not (goRowSelect in FOptions) then
  begin
    MoveAdjust(FCurrent.X, FromIndex, ToIndex);
    MoveAdjust(FAnchor.X, FromIndex, ToIndex);
  end;
  MoveAdjust(FInplaceCol, FromIndex, ToIndex);
  (* バグ修正の開始*)
  if FromIndex < LeftCol then
  begin
    InvalidateGrid;
  end
  else if FromIndex < ToIndex then
  begin
    Rect.Left   := FromIndex;
    Rect.Top    := 0;
    Rect.Right  := ToIndex;
    Rect.Bottom := VisibleRowCount + TopRow;
    InvalidateRect(Rect);
  end
  else
  begin
    Rect.Left   := ToIndex;
    Rect.Top    := 0;
    Rect.Right  := FromIndex;
    Rect.Bottom := VisibleRowCount + TopRow;
    InvalidateRect(Rect);
  end;
  ColumnMoved(FromIndex, ToIndex);
  ColWidthsChanged;
  UpdateEdit;
end;

procedure TXCustomGrid.ColumnMoved(FromIndex, ToIndex: Longint);
begin
end;

procedure TXCustomGrid.MoveRow(FromIndex, ToIndex: Longint);
var
  Rect: TXGridRect;
begin
  if FromIndex = ToIndex then Exit;
  MoveExtent(FRowInfos, FromIndex, ToIndex);
  MoveAdjust(FCurrent.Y, FromIndex, ToIndex);
  MoveAdjust(FAnchor.Y, FromIndex, ToIndex);
  MoveAdjust(FInplaceRow, FromIndex, ToIndex);
  (* バグ修正の開始*)
  if FromIndex < TopRow then
  begin
    InvalidateGrid;
  end
  else if FromIndex < ToIndex then
  begin
    Rect.Left   := 0;
    Rect.Top    := FromIndex;
    Rect.Right  := VisibleColCount + LeftCol;
    Rect.Bottom := ToIndex;
    InvalidateRect(Rect);
  end
  else
  begin
    Rect.Left   := 0;
    Rect.Top    := ToIndex;
    Rect.Right  := VisibleColCount + LeftCol;
    Rect.Bottom := FromIndex;
    InvalidateRect(Rect);
  end;
  (* バグ修正の終わり*)
  RowMoved(FromIndex, ToIndex);
  RowHeightsChanged;
  UpdateEdit;
end;

procedure TXCustomGrid.RowMoved(FromIndex, ToIndex: Longint);
begin
end;

function TXCustomGrid.MouseCoord(X, Y: Integer): TXGridCoord;
var
  DrawInfo: TXGridDrawInfo;
begin
  CalcDrawInfo(DrawInfo);
  Result := CalcCoordFromPoint(X, Y, DrawInfo);
  if Result.X < 0 then Result.Y := -1
  else if Result.Y < 0 then Result.X := -1;
end;

procedure TXCustomGrid.MoveColRow(ACol, ARow: Longint; MoveAnchor,
  Show: Boolean);
begin
  MoveCurrent(ACol, ARow, MoveAnchor, Show);
end;

function TXCustomGrid.SelectCell(ACol, ARow: Longint): Boolean;
begin
  Result := True;
end;

procedure TXCustomGrid.CurrentChanged;
begin
end;

procedure TXCustomGrid.SizeChanged(OldColCount, OldRowCount: Longint);
begin
end;

function TXCustomGrid.Sizing(X, Y: Integer): Boolean;
var
  FixedInfo: TXGridDrawInfo;
  State: TXGridState;
  Index: Longint;
  Pos, Ofs: Integer;
begin
  State := FGridState;
  if State = gsNormal then
  begin
    CalcFixedInfo(FixedInfo);
    CalcSizingState(X, Y, State, Index, Pos, Ofs, FixedInfo);
  end;
  Result := State <> gsNormal;
end;

procedure TXCustomGrid.TopLeftChanged;
begin
  if FEditorMode and (FInplaceEdit <> nil) then FInplaceEdit.UpdateLoc(CellRect(Col, Row));
end;

function TXCustomGrid.GetDrawCellWidth(Cell: Longint): Integer;
begin
  if Cell < FixedCols then
    Result := ColWidths[Cell]
  else
    Result := ColWidths[Cell - FixedCols + LeftCol];
end;

function TXCustomGrid.GetDrawCellHeight(Cell: Longint): Integer;
begin
  if Cell < FixedRows then
    Result := RowHeights[Cell]
  else
    Result := RowHeights[Cell - FixedRows + TopRow];
end;

function TXCustomGrid.CalcStartCol(DrawInfo: TXGridDrawInfo; Start: integer; var ACol: Longint): Integer;
var
  I: Longint;
  X: Integer;
begin
  Result := 0;
  ACol   := 0;
  I := (DrawInfo.Horz.LastFullVisibleCell - LeftCol + 1) + FixedCols;
  while (ACol <= I) do
  begin
    X := Result + GetDrawCellWidth(ACol) + DrawInfo.Horz.EffectiveLineWidth;
(* Add T.S 1997-02-13 *)
//    if (X > Start) then Exit;
    if (X > Start) then Break;
(* Add End *)
    Result := X;
    Inc(ACol);
  end;
(* Add T.S 1997-02-13 *)
  Dec(Result, FColOffset);
(* Add End *)
end;

function TXCustomGrid.CalcStartRow(DrawInfo: TXGridDrawInfo; Start: integer; var ARow: Longint): Integer;
var
  I: Longint;
  Y: Integer;
begin
  Result := 0;
  ARow   := 0;
  I := (DrawInfo.Vert.LastFullVisibleCell - TopRow + 1) + FixedRows;
  while (ARow <= I) do
  begin
    Y := Result + GetDrawCellHeight(ARow) + DrawInfo.Vert.EffectiveLineWidth;
(* Add T.S 1997-02-13 *)
//    if (Y > Start) then Exit;
    if (Y > Start) then Break;
(* Add End *)
    Result := Y;
    Inc(ARow);
  end;
end;

procedure TXCustomGrid.Paint;
begin
  SetBkMode(Canvas.Handle, TRANSPARENT);
  PaintRect(Canvas.ClipRect);
end;

procedure TXCustomGrid.PaintRect(ARect: TRect);
var
  i, StartX, StartY, FixedWidth, FixedHeight: Integer;
  rcDraw, rcFix, rcData: TRect;
  ColNo, RowNo, StartCol, StartRow: Longint;
  DrawInfo: TXGridDrawInfo;
  DrawState: TXGridDrawState;
  Selecting: Boolean;
  dc: HDC;
begin
  CalcDrawInfo(DrawInfo);
  dc := Canvas.Handle;
  if FOffScreenDrawing then Canvas.Handle := FBitmap.Canvas.Handle;
  with DrawInfo, Canvas do begin
    //
    // 非ｽｸﾛｰﾙ領域の設定
    //
    FixedWidth  := Horz.FixedBoundary;
    FixedHeight := Vert.FixedBoundary;
    if (NScrlCols <> 0) then begin
      if (FFixedCols <> 0) then
        FixedWidth := ColWidths [0] + Horz.EffectiveLineWidth
      else
        FixedWidth := 0;
    end;
    if (NScrlRows <> 0) then begin
      if (FFixedRows <> 0) then
        FixedHeight := RowHeights[0] + Vert.EffectiveLineWidth
      else
        FixedHeight := 0;
    end;
    //
    // グリッド領域以外の塗りつぶし
    //
    with Horz do if (GridBoundary < GridExtent) then Dec(GridBoundary, EffectiveLineWidth);
    with Vert do if (GridBoundary < GridExtent) then Dec(GridBoundary, EffectiveLineWidth);
    Pen.Color   := clNone;
(* Add T.S 1997-02-13 *)
//    Brush.Color := clAppWorkSpace;
    Brush.Color := FBorderColor;
(* Add End *)
    if (Horz.GridBoundary < Horz.GridExtent) then
      FillRect(Rect(Horz.GridBoundary + 1, ARect.Top, ARect.Right, Vert.GridBoundary + 1));
    if (Vert.GridBoundary < Vert.GridExtent) then
      FillRect(Rect(ARect.Left, Vert.GridBoundary + 1, ARect.Right, ARect.Bottom));
    Brush.Color := clBlack;
    if (Horz.GridBoundary < Horz.GridExtent) then
      FillRect(Rect(Horz.GridBoundary, ARect.Top, Horz.GridBoundary + 1, Vert.GridBoundary + 1));
    if (Vert.GridBoundary < Vert.GridExtent) then
      FillRect(Rect(ARect.Left, Vert.GridBoundary, Horz.GridBoundary + 1, Vert.GridBoundary + 1));
    //
    // 描画領域の計算
    //
    if (not IntersectRect(rcDraw, ARect, Rect(0, 0, Horz.GridBoundary, Vert.GridBoundary))) then Exit;
    //
    // 固定領域の塗りつぶし
    //
    Brush.Color := FixedColor;
    rcData      := rcDraw;
    if (rcDraw.Top  < FixedHeight{Vert.FixedBoundary}) then begin
      rcFix        := rcDraw;
      rcFix.Bottom := FixedHeight;//Vert.FixedBoundary;
      rcData.Top   := FixedHeight;//Vert.FixedBoundary;
      FillRect(rcFix);
    end;
    if (rcDraw.Left < FixedWidth{Horz.FixedBoundary}) then begin
      rcFix        := rcDraw;
      rcFix.Right  := FixedWidth;//Horz.FixedBoundary;
      rcData.Left  := FixedWidth;//Horz.FixedBoundary;
      FillRect(rcFix);
    end;
    //
    // データ領域の塗りつぶし
    //
    Brush.Color := Color;
    FillRect(rcData);
    //
    // 描画開始セルの計算
    //
    StartX := CalcStartCol(DrawInfo, rcDraw.Left, StartCol);
    StartY := CalcStartRow(DrawInfo, rcDraw.Top , StartRow);
    //
    // 固定セル領域の３Ｄ表示処理
    //
    if DefaultDrawing and Ctl3D and ([goFixedHorzLine, goFixedVertLine] * Options <> []) then begin
      //
      // 固定セル領域をボタン形状に見せるための影線描画
      //
      Brush.Color := clBtnShadow;
      RowNo := StartRow;
      i     := StartY + GetDrawCellHeight(RowNo) - 1;
      while (i < rcDraw.Bottom) do begin
        if (i < FixedHeight{Vert.FixedBoundary}) then begin
          FillRect(Rect(rcDraw.Left, i, rcDraw.Right, i + 1));
        end else if (rcDraw.Left < FixedWidth{Horz.FixedBoundary}) then begin
          FillRect(Rect(rcDraw.Left, i, FixedWidth{Horz.FixedBoundary} - Horz.EffectiveLineWidth, i + 1));
        end else
          Break;
        Inc(RowNo);
        Inc(i, GetDrawCellHeight(RowNo) + Vert.EffectiveLineWidth);
      end;
      ColNo := StartCol;
      i     := StartX + GetDrawCellWidth(ColNo) - 1;
      while (i < rcDraw.Right) do begin
        if (i < FixedWidth{Horz.FixedBoundary}) then begin
          FillRect(Rect(i, rcDraw.Top, i + 1, rcDraw.Bottom));
        end else if (rcDraw.Top < FixedHeight{Vert.FixedBoundary}) then begin
          FillRect(Rect(i, rcDraw.Top, i + 1, FixedHeight{Vert.FixedBoundary} - Vert.EffectiveLineWidth));
        end else
          Break;
        Inc(ColNo);
        Inc(i, GetDrawCellWidth(ColNo) + Horz.EffectiveLineWidth);
      end;
      //
      // 固定セル領域をボタン形状に見せるための明線描画
      //
      Brush.Color := clBtnHighLight;
      RowNo := StartRow;
      i     := StartY  ;
      while (i < rcDraw.Bottom) do begin
        if (i < FixedHeight{Vert.FixedBoundary}) then begin
          FillRect(Rect(rcDraw.Left, i, rcDraw.Right, i + 1));
        end else if (rcDraw.Left < FixedWidth{Horz.FixedBoundary}) then begin
          FillRect(Rect(rcDraw.Left, i, FixedWidth{Horz.FixedBoundary} - Horz.EffectiveLineWidth, i + 1));
        end else
          Break;
        Inc(i, GetDrawCellHeight(RowNo) + Vert.EffectiveLineWidth);
        Inc(RowNo);
      end;
      ColNo := StartCol;
      i     := StartX  ;
      while (i < rcDraw.Right) do begin
        if (i < FixedWidth{Horz.FixedBoundary}) then begin
          FillRect(Rect(i, rcDraw.Top, i + 1, rcDraw.Bottom));
        end else if (rcDraw.Top < FixedHeight{Vert.FixedBoundary}) then begin
          FillRect(Rect(i, rcDraw.Top, i + 1, FixedHeight{Vert.FixedBoundary} - Vert.EffectiveLineWidth));
        end else
          Break;
        Inc(i, GetDrawCellWidth(ColNo) + Horz.EffectiveLineWidth);
        Inc(ColNo);
      end;
    end;
    //
    // 固定領域の境界線描画
    //
    Brush.Color := clBlack;
    if (Vert.EffectiveLineWidth > 0) then begin
      RowNo := StartRow;
      i     := StartY + GetDrawCellHeight(RowNo);
      while (i < rcDraw.Bottom) do begin
        if (i < Vert.FixedBoundary) then begin
          FillRect(Rect(rcDraw.Left, i, rcDraw.Right, i + Vert.EffectiveLineWidth));
        end else if (rcDraw.Left < Horz.FixedBoundary) then begin
          FillRect(Rect(rcDraw.Left, i, Horz.FixedBoundary, i + Vert.EffectiveLineWidth));
        end else
          Break;
        Inc(RowNo);
        Inc(i, GetDrawCellHeight(RowNo) + Vert.EffectiveLineWidth);
      end;
    end;
    if (Horz.EffectiveLineWidth > 0) then begin
      ColNo := StartCol;
      i     := StartX + GetDrawCellWidth(ColNo);
      while (i < rcDraw.Right) do begin
        if (i < Horz.FixedBoundary) then begin
          FillRect(Rect(i, rcDraw.Top, i + Horz.EffectiveLineWidth, rcDraw.Bottom));
        end else if (rcDraw.Top < Vert.FixedBoundary) then begin
          FillRect(Rect(i, rcDraw.Top, i + Horz.EffectiveLineWidth, Vert.FixedBoundary));
        end else
          Break;
        Inc(ColNo);
        Inc(i, GetDrawCellWidth(ColNo) + Horz.EffectiveLineWidth);
      end;
    end;
    //
    // データ描画領域の計算
    //
    if IntersectRect(rcDraw, rcDraw,
      Rect(Horz.FixedBoundary, Vert.FixedBoundary, rcDraw.Right, rcDraw.Bottom)) then begin
      //
      // 描画開始セルの計算
      //
      StartX := CalcStartCol(DrawInfo, rcDraw.Left, StartCol);
      StartY := CalcStartRow(DrawInfo, rcDraw.Top , StartRow);
      //
      // データ描画領域の境界線描画
      //
      if ColorToRGB(Color) = clSilver then Brush.Color := clGray else Brush.Color := clSilver;
      if (goHorzLine in Options) then begin
        RowNo := StartRow;
        i     := StartY + GetDrawCellHeight(RowNo);
        while (i < rcDraw.Bottom) do begin
          FillRect(Rect(rcDraw.Left, i, rcDraw.Right, i + Vert.EffectiveLineWidth));
          Inc(RowNo);
          Inc(i, GetDrawCellHeight(RowNo) + Vert.EffectiveLineWidth);
        end;
      end;
      if (goVertLine in Options) then begin
        ColNo := StartCol;
        i     := StartX + GetDrawCellWidth(ColNo);
        while (i < rcDraw.Right) do begin
          FillRect(Rect(i, rcDraw.Top, i + Horz.EffectiveLineWidth, rcDraw.Bottom));
          Inc(ColNo);
          Inc(i, GetDrawCellWidth(ColNo) + Horz.EffectiveLineWidth);
        end;
      end;
    end;
    //
    // セル・データの描画
    //
    if (not IntersectRect(rcDraw, ARect, Rect(0, 0, Horz.GridBoundary, Vert.GridBoundary))) then Exit;
    //
    // 描画開始セルの計算
    //
    StartX := CalcStartCol(DrawInfo, rcDraw.Left, StartCol);
    StartY := CalcStartRow(DrawInfo, rcDraw.Top , StartRow);
    if StartCol >= FixedCols then Inc(StartCol, LeftCol - FixedCols);
    if StartRow >= FixedRows then Inc(StartRow, TopRow  - FixedRows);
    //
    Font := Self.Font;
    //
    rcData.Top := StartY;
    RowNo      := StartRow;
    while (rcData.Top < rcDraw.Bottom) do begin
      if RowNo = FixedRows then RowNo := TopRow;
      rcData.Bottom := rcData.Top + RowHeights[RowNo];
      rcData.Left   := StartX;
      ColNo         := StartCol;
      while (rcData.Left < rcDraw.Right) do begin
        if ColNo = FixedCols then ColNo := LeftCol;
        rcData.Right := rcData.Left + ColWidths[ColNo];
        (* 選択状態の判定 *)
        if (FGridState = gsSelectingCol) then begin
          Selecting := SelectCol[ColNo];
          if (ColNo >= IMin(FMoveIndex, FMovePos)) and (ColNo <= IMax(FMoveIndex, FMovePos)) then
            Selecting := not Selecting;
          Selecting := Selecting or SelectRow[RowNo];
        end else if (FGridState = gsSelectingRow) then begin
          Selecting := SelectRow[RowNo];
          if (RowNo >= IMin(FMoveIndex, FMovePos)) and (RowNo <= IMax(FMoveIndex, FMovePos)) then
            Selecting := not Selecting;
          Selecting := Selecting or SelectCol[ColNo];
        end else begin
          Selecting := SelectCol[ColNo] or SelectRow[RowNo];
        end;
        (* 描画状態ﾌﾗｸﾞの設定 *)
        DrawState := [];
        if (ColNo < FFixedCols) or (RowNo < FFixedRows) then
          Include(DrawState, gdFixed);
        if Focused and (RowNo = Row) and (ColNo = Col) then
          Include(DrawState, gdFocused);
        if PointInGridRect(ColNo, RowNo, Selection) then
          Include(DrawState, gdSelected);
        (* ｴﾃﾞｨｯﾄ中のｾﾙの判定 *)
        if not (gdFocused in DrawState) or not (goEditing in Options) or
          not FEditorMode or (csDesigning in ComponentState) then begin
          (* ﾌﾞﾗｼとﾌｫﾝﾄ･ｶﾗｰの設定 *)
          if DefaultDrawing or (csDesigning in ComponentState) then begin
            if (gdFixed in DrawState) then begin
              Brush.Color := FixedColor;
              Font.Color  := Self.Font.Color;
            end else if (gdSelected in DrawState) and (not (gdFocused in DrawState)
            or ([goDrawFocusSelected, goRowSelect] * Options <> [])) then begin
              if Focused and ([goDrawFocusSelected, goRangeSelect] * Options <> []) then begin
                Brush.Color := clHighlight;
                Font.Color  := clHighlightText;
                FillRect(rcData);
              end else begin
                Brush.Color := Color;
                Font.Color  := Self.Font.Color;
              end;
            end else begin
              Brush.Color := Color;
              Font.Color  := Self.Font.Color;
            end;
            Brush.Handle;
          end;
          (* 行番号表示 *)
          if (goLineNumber in FOptions) and (ColNo = 0) and (RowNo >= FixedRows) then
            DrawCellText(rcData, IntToStr(RowNo - FixedRows + 1), gtCenter);
          (* ｾﾙ･ﾃﾞｰﾀの描画*)
          DrawCell(ColNo, RowNo, rcData, DrawState);
          (* ﾌｫｰｶｽ枠の描画*)
          if DefaultDrawing and (gdFocused in DrawState) and not (csDesigning in ComponentState)
          and ([goEditing, goAlwaysShowEditor] * Options <> [goEditing, goAlwaysShowEditor])
          and not (goRowSelect in Options) then
            Windows.DrawFocusRect(Handle, rcData);
          (* 選択状態のときにデータ・セルを反転表示 *)
          if DefaultDrawing and Selecting then begin
            if (gdFixed in DrawState) and ((ColNo < FFixedCols) or (RowNo < FFixedRows)) then begin
              if Ctl3D and ([goFixedHorzLine, goFixedVertLine] * Options <> []) then begin
                rcFix := rcData;
                Dec(rcFix.Right );
                Dec(rcFix.Bottom);
                Pen.Color := clBtnShadow;
                PolyLine([Point(rcFix.Left, rcFix.Bottom), rcFix.TopLeft, Point(rcFix.Right, rcFix.Top)]);
                Pen.Color := clBtnHighlight;
                PolyLine([Point(rcFix.Right, rcFix.Top), rcFix.BottomRight, Point(rcFix.Left, rcFix.Bottom)]);
              end;
            end else
              InvertRect(rcData);
          end;
        end;
        rcData.Left := rcData.Right + Horz.EffectiveLineWidth;
        Inc(ColNo);
      end;
      (* 行選択ﾌｫｰｶｽ枠の描画*)
      if DefaultDrawing and Focused and (RowNo = Row) and not (csDesigning in ComponentState) and (goRowSelect in Options) then begin
        rcData.Left  := Horz.FixedBoundary;
        rcData.Right := Horz.GridBoundary;
        DrawFocusRect(rcData);
      end;
      rcData.Top  := rcData.Bottom + Vert.EffectiveLineWidth;
      Inc(RowNo);
    end;
  end;
  (* ｵﾌｽｸﾘｰﾝ描画 *)
  if FOffScreenDrawing then begin
    Canvas.Handle := dc;
    Canvas.Draw(0, 0, FBitmap);
  end;
end;

function TXCustomGrid.CalcCoordFromPoint(X, Y: Integer;
  const DrawInfo: TXGridDrawInfo): TXGridCoord;

  function DoCalc(const AxisInfo: TXGridAxisDrawInfo; N: Integer): Integer;
  var
    I, Start, Stop: Longint;
    Line: Integer;
  begin
    with AxisInfo do
    begin
      if N < FixedBoundary then
      begin
        Start := 0;
        Stop :=  FixedCellCount - 1;
        Line := 0;
      end
      else
      begin
        Start := FirstGridCell;
        Stop := GridCellCount - 1;
        Line := FixedBoundary;
      end;
      Result := -1;
      for I := Start to Stop do
      begin
        Inc(Line, GetExtent(I) + EffectiveLineWidth);
        if N < Line then
        begin
          Result := I;
          Exit;
        end;
      end;
    end;
  end;

begin
  Result.X := DoCalc(DrawInfo.Horz, X);
  Result.Y := DoCalc(DrawInfo.Vert, Y);
end;

procedure TXCustomGrid.CalcDrawInfo(var DrawInfo: TXGridDrawInfo);
begin
  CalcDrawInfoXY(DrawInfo, ClientWidth, ClientHeight);
end;

procedure TXCustomGrid.CalcDrawInfoXY(var DrawInfo: TXGridDrawInfo;
  UseWidth, UseHeight: Integer);

  procedure CalcAxis(var AxisInfo: TXGridAxisDrawInfo; UseExtent: Integer);
  var
    I: Integer;
  begin
    with AxisInfo do
    begin
      GridExtent := UseExtent;
      GridBoundary := FixedBoundary;
      FullVisBoundary := FixedBoundary;
      LastFullVisibleCell := FirstGridCell;
      for I := FirstGridCell to GridCellCount - 1 do
      begin
        Inc(GridBoundary, GetExtent(I) + EffectiveLineWidth);
        if GridBoundary > GridExtent + EffectiveLineWidth then
        begin
          GridBoundary := GridExtent;
          Break;
        end;
        LastFullVisibleCell := I;
        FullVisBoundary := GridBoundary;
      end;
    end;
  end;

begin
  CalcFixedInfo(DrawInfo);
  CalcAxis(DrawInfo.Horz, UseWidth);
  CalcAxis(DrawInfo.Vert, UseHeight);
end;

procedure TXCustomGrid.CalcFixedInfo(var DrawInfo: TXGridDrawInfo);

  procedure CalcFixedAxis(var Axis: TXGridAxisDrawInfo; LineOptions: TXGridOptions;
    FixedCount, FirstCell, CellCount: Integer; GetExtentFunc: TXGetExtentsFunc);
  var
    I: Integer;
  begin
    with Axis do
    begin
      if LineOptions * Options = [] then
        EffectiveLineWidth := 0
      else
        EffectiveLineWidth := GridLineWidth;

      FixedBoundary := 0;
      for I := 0 to FixedCount - 1 do
        Inc(FixedBoundary, GetExtentFunc(I) + EffectiveLineWidth);

      FixedCellCount := FixedCount;
      FirstGridCell := FirstCell;
      GridCellCount := CellCount;
      GetExtent := GetExtentFunc;
    end;
  end;

begin
  CalcFixedAxis(DrawInfo.Horz, [goFixedVertLine, goVertLine], FixedCols,
    LeftCol, ColCount, GetColWidths);
  CalcFixedAxis(DrawInfo.Vert, [goFixedHorzLine, goHorzLine], FixedRows,
    TopRow, RowCount, GetRowHeights);
end;

{ Calculates the TopLeft that will put the given Coord in view }
function TXCustomGrid.CalcMaxTopLeft(const Coord: TXGridCoord;
  const DrawInfo: TXGridDrawInfo): TXGridCoord;

  function CalcMaxCell(const Axis: TXGridAxisDrawInfo; Start: Integer): Integer;
  var
    Line: Integer;
    I: Longint;
  begin
    Result := Start;
    with Axis do
    begin
      Line := GridExtent + EffectiveLineWidth;
      for I := Start downto FixedCellCount do
      begin
        Dec(Line, GetExtent(I));
        Dec(Line, EffectiveLineWidth);
        if Line < FixedBoundary then Break;
        Result := I;
      end;
    end;
  end;

begin
  Result.X := CalcMaxCell(DrawInfo.Horz, Coord.X);
  Result.Y := CalcMaxCell(DrawInfo.Vert, Coord.Y);
end;

procedure TXCustomGrid.CalcSizingState(X, Y: Integer; var State: TXGridState;
  var Index: Longint; var SizingPos, SizingOfs: Integer;
  var FixedInfo: TXGridDrawInfo);

  procedure CalcAxisState(const AxisInfo: TXGridAxisDrawInfo; Pos: Integer;
    NewState: TXGridState);
  var
    I, Line, Back, Range: Integer;
  begin
    with AxisInfo do
    begin
{$IFDEF NOTHING}
      Line  := FixedBoundary;
      Range := EffectiveLineWidth;
      Back  := 0;
      if Range < 7 then
      begin
        Range := 7;
        Back  := (Range - EffectiveLineWidth) shr 1;
      end;
{$ELSE}
      Line  := 0;
      Range := EffectiveLineWidth;
      Back  := 0;
      if Range < 7 then
      begin
        Range := 7;
        Back  := (Range - EffectiveLineWidth) shr 1;
      end;
      for I := 0 to FixedCellCount - 1 do
      begin
        Inc(Line, GetExtent(I));
        if Line > GridExtent then Break;
        if (Pos >= Line - Back) and (Pos <= Line - Back + Range) then
        begin
          State     := NewState;
          SizingPos := Line;
          SizingOfs := Line - Pos;
          Index     := I;
          Exit;
        end;
        Inc(Line, EffectiveLineWidth);
      end;
{$ENDIF}
      for I := FirstGridCell to GridCellCount - 1 do
      begin
        Inc(Line, GetExtent(I));
        if Line > GridExtent then Break;
        if (Pos >= Line - Back) and (Pos <= Line - Back + Range) then
        begin
          State     := NewState;
          SizingPos := Line;
          SizingOfs := Line - Pos;
          Index     := I;
          Exit;
        end;
        Inc(Line, EffectiveLineWidth);
      end;
      if (Pos >= GridExtent - Back) and (Pos <= GridExtent) then
      begin
        State     := NewState;
        SizingPos := GridExtent;
        SizingOfs := GridExtent - Pos;
        Index     := I;
      end;
    end;
  end;

var
  EffectiveOptions: TXGridOptions;
begin
  State := gsNormal;
  Index := -1;
  EffectiveOptions := Options;
  if csDesigning in ComponentState then
  begin
    Include(EffectiveOptions, goColSizing);
    Include(EffectiveOptions, goRowSizing);
  end;
  if [goColSizing, goRowSizing] * EffectiveOptions <> [] then
    with FixedInfo do
    begin
      Vert.GridExtent := ClientHeight;
      Horz.GridExtent := ClientWidth;
{$IFDEF NOTHING}
      if (X > Horz.FixedBoundary) and (goColSizing in EffectiveOptions) then
      begin
        if Y >= Vert.FixedBoundary then Exit;
        CalcAxisState(Horz, X, gsColSizing);
      end
      else if (Y > Vert.FixedBoundary) and (goRowSizing in EffectiveOptions) then
      begin
        if X >= Horz.FixedBoundary then Exit;
        CalcAxisState(Vert, Y, gsRowSizing);
      end;
{$ELSE}
      if (Y < Vert.FixedBoundary) and (goColSizing in EffectiveOptions) then
      begin
        CalcAxisState(Horz, X, gsColSizing);
      end
      else if (X < Horz.FixedBoundary) and (goRowSizing in EffectiveOptions) then
      begin
        CalcAxisState(Vert, Y, gsRowSizing);
      end;
{$ENDIF}
    end;
end;

procedure TXCustomGrid.ChangeSize(NewColCount, NewRowCount: Longint);
var
  OldColCount, OldRowCount: Longint;
  OldDrawInfo: TXGridDrawInfo;

  procedure MinRedraw(const OldInfo, NewInfo: TXGridAxisDrawInfo; Axis: Integer);
  var
    R: TRect;
    First: Integer;
  begin
    if (OldInfo.LastFullVisibleCell = NewInfo.LastFullVisibleCell) then Exit;
    First := IMin(OldInfo.LastFullVisibleCell, NewInfo.LastFullVisibleCell);
    // Get the rectangle around the leftmost or topmost cell in the target range.
    R := CellRect(First and not Axis, First and Axis);
    R.Bottom := Height;
    R.Right := Width;
    Windows.InvalidateRect(Handle, @R, False);
  end;

  procedure DoChange;
  var
    Coord: TXGridCoord;
    NewDrawInfo: TXGridDrawInfo;
  begin
    UpdateExtents(FColInfos, ColCount);
    UpdateExtents(FRowInfos, RowCount);
    Coord := FCurrent;
    if Row >= RowCount then Coord.Y := RowCount - 1;
    if Col >= ColCount then Coord.X := ColCount - 1;
    if (FCurrent.X <> Coord.X) or (FCurrent.Y <> Coord.Y) then
      MoveCurrent(Coord.X, Coord.Y, True, True);
    if (FAnchor.X <> Coord.X) or (FAnchor.Y <> Coord.Y) then
      MoveAnchor(Coord);
    if (LeftCol <> OldDrawInfo.Horz.FirstGridCell) or
      (TopRow <> OldDrawInfo.Vert.FirstGridCell) then
      InvalidateGrid
    else if HandleAllocated then
    begin
      CalcDrawInfo(NewDrawInfo);
      MinRedraw(OldDrawInfo.Horz, NewDrawInfo.Horz, 0);
      MinRedraw(OldDrawInfo.Vert, NewDrawInfo.Vert, -1);
    end;
    UpdateScrollRange;
    SizeChanged(OldColCount, OldRowCount);
  end;

begin
  if HandleAllocated then CalcDrawInfo(OldDrawInfo);
  if not (csReading in ComponentState) then begin
    if NewColCount <= FixedCols then NewColCount := FixedCols + 1;
    if NewRowCount <= FixedRows then NewRowCount := FixedRows + 1;
  end;
  OldColCount := FColCount;
  OldRowCount := FRowCount;
  FColCount   := NewColCount;
  FRowCount   := NewRowCount;
  try
    DoChange;
  except
    { Could not change size so try to clean up by setting the size back }
    FColCount := OldColCount;
    FRowCount := OldRowCount;
    DoChange;
    InvalidateGrid;
    raise;
  end;
end;

{ Will move TopLeft so that Coord is in view }
procedure TXCustomGrid.ClampInView(const Coord: TXGridCoord);
var
  DrawInfo: TXGridDrawInfo;
  MaxTopLeft: TXGridCoord;
  OldTopLeft: TXGridCoord;
begin
  if not HandleAllocated then Exit;
  CalcDrawInfo(DrawInfo);
  with DrawInfo, Coord do
  begin
    if (X > Horz.LastFullVisibleCell) or
      (Y > Vert.LastFullVisibleCell) or (X < LeftCol) or (Y < TopRow) then
    begin
      OldTopLeft := FTopLeft;
      MaxTopLeft := CalcMaxTopLeft(Coord, DrawInfo);
      Update;
      if (X < LeftCol) and (X >= FixedCols) then FTopLeft.X := X
      else if X > Horz.LastFullVisibleCell then FTopLeft.X := MaxTopLeft.X;
      if (Y < TopRow) and (Y >= FixedRows) then FTopLeft.Y := Y
      else if Y > Vert.LastFullVisibleCell then FTopLeft.Y := MaxTopLeft.Y;
      TopLeftMoved(OldTopLeft);
    end;
  end;
end;

procedure TXCustomGrid.DrawSizingLine(const DrawInfo: TXGridDrawInfo);
var
  OldPen: TPen;
begin
  OldPen := TPen.Create;
  try
    with Canvas, DrawInfo do
    begin
      OldPen.Assign(Pen);
      Pen.Color := clBlack;
      Pen.Style := psDot;
      Pen.Mode  := pmXor;
      Pen.Width := 1;
      try
        if FGridState = gsRowSizing then
        begin
          MoveTo(0, FSizingPos);
          LineTo(Horz.GridBoundary, FSizingPos);
        end
        else
        begin
          MoveTo(FSizingPos, 0);
          LineTo(FSizingPos, Vert.GridBoundary);
        end;
      finally
        Pen := OldPen;
      end;
    end;
  finally
    OldPen.Free;
  end;
end;

procedure TXCustomGrid.DrawMove;
var
  OldPen: TPen;
  Pos: Integer;
  R: TRect;
begin
  OldPen := TPen.Create;
  try
    with Canvas do
    begin
      OldPen.Assign(Pen);
      try
        Pen.Style := psDot;
        Pen.Mode  := pmNot;//pmXor;
        Pen.Width := 5;
        if FGridState = gsRowMoving then
        begin
          R := CellRect(0, FMovePos);
          if FMovePos > FMoveIndex then
            Pos := R.Bottom else
            Pos := R.Top;
          MoveTo(0, Pos);
          LineTo(ClientWidth, Pos);
        end
        else
        begin
          R := CellRect(FMovePos, 0);
          if FMovePos > FMoveIndex then
            Pos := R.Right else
            Pos := R.Left;
          MoveTo(Pos, 0);
          LineTo(Pos, ClientHeight);
        end;
      finally
        Pen := OldPen;
      end;
    end;
  finally
    OldPen.Free;
  end;
end;

procedure TXCustomGrid.FocusCell(ACol, ARow: Longint; MoveAnchor: Boolean);
begin
  MoveCurrent(ACol, ARow, MoveAnchor, True);
  UpdateEdit;
  Click;
end;

procedure TXCustomGrid.GridRectToScreenRect(GridRect: TXGridRect;
  var ScreenRect: TRect; IncludeLine: Boolean);

  function LinePos(const AxisInfo: TXGridAxisDrawInfo; Line: Integer): Integer;
  var
    Start, I: Longint;
  begin
    with AxisInfo do
    begin
      Result := 0;
      if Line < FixedCellCount then
        Start := 0
      else
      begin
        if Line >= FirstGridCell then
          Result := FixedBoundary;
        Start := FirstGridCell;
      end;
      for I := Start to Line - 1 do
      begin
        Inc(Result, GetExtent(I) + EffectiveLineWidth);
        if Result > GridExtent then
        begin
          Result := 0;
          Exit;
        end;
      end;
    end;
  end;

  function CalcAxis(const AxisInfo: TXGridAxisDrawInfo;
    GridRectMin, GridRectMax: Integer;
    var ScreenRectMin, ScreenRectMax: Integer): Boolean;
  begin
    Result := False;
    with AxisInfo do
    begin
      if (GridRectMin >= FixedCellCount) and (GridRectMin < FirstGridCell) then
        if GridRectMax < FirstGridCell then
        begin
          FillChar(ScreenRect, SizeOf(ScreenRect), 0); { erase partial results }
          Exit;
        end
        else
          GridRectMin := FirstGridCell;
      if GridRectMax > LastFullVisibleCell then
      begin
        GridRectMax := LastFullVisibleCell;
        if GridRectMax < GridCellCount - 1 then Inc(GridRectMax);
        if LinePos(AxisInfo, GridRectMax) = 0 then
          Dec(GridRectMax);
      end;

      ScreenRectMin := LinePos(AxisInfo, GridRectMin);
      ScreenRectMax := LinePos(AxisInfo, GridRectMax);
      if ScreenRectMax = 0 then
        ScreenRectMax := ScreenRectMin + GetExtent(GridRectMin)
      else
        Inc(ScreenRectMax, GetExtent(GridRectMax));
      if ScreenRectMax > GridExtent then
        ScreenRectMax := GridExtent;
      if IncludeLine then Inc(ScreenRectMax, EffectiveLineWidth);
    end;
    Result := True;
  end;

var
  DrawInfo: TXGridDrawInfo;
begin
  FillChar(ScreenRect, SizeOf(ScreenRect), 0);
  if (GridRect.Left > GridRect.Right) or (GridRect.Top > GridRect.Bottom) then
    Exit;
  CalcDrawInfo(DrawInfo);
  with DrawInfo do
  begin
    if GridRect.Left > Horz.LastFullVisibleCell + 1 then Exit;
    if GridRect.Top > Vert.LastFullVisibleCell + 1 then Exit;

    if CalcAxis(Horz, GridRect.Left, GridRect.Right, ScreenRect.Left,
      ScreenRect.Right) then
    begin
      CalcAxis(Vert, GridRect.Top, GridRect.Bottom, ScreenRect.Top,
        ScreenRect.Bottom);
    end;
  end;
end;

procedure TXCustomGrid.Initialize;
begin
  FTopLeft.X := FixedCols;
  FTopLeft.Y := FixedRows;
  FCurrent   := FTopLeft;
  FAnchor    := FCurrent;
  if goRowSelect in Options then FAnchor.X := ColCount - 1;
end;

procedure TXCustomGrid.InvalidateCell(ACol, ARow: Longint);
var
  Rect: TXGridRect;
begin
  Rect.Top := ARow;
  Rect.Left := ACol;
  Rect.Bottom := ARow;
  Rect.Right := ACol;
  InvalidateRect(Rect);
end;

procedure TXCustomGrid.InvalidateCol(ACol: Longint);
var
  Rect: TXGridRect;
begin
  if not HandleAllocated then Exit;
  Rect.Top := 0;
  Rect.Left := ACol;
  Rect.Bottom := VisibleRowCount + TopRow;  (* バグ修正 *)
  Rect.Right := ACol;
  InvalidateRect(Rect);
end;

procedure TXCustomGrid.InvalidateRow(ARow: Longint);
var
  Rect: TXGridRect;
begin
  if not HandleAllocated then Exit;
  Rect.Top := ARow;
  Rect.Left := 0;
  Rect.Bottom := ARow;
  Rect.Right := VisibleColCount + LeftCol;  (* バグ修正 *)
  InvalidateRect(Rect);
end;

procedure TXCustomGrid.InvalidateGrid;
begin
  Invalidate;
end;

procedure TXCustomGrid.InvalidateRect(ARect: TXGridRect);
var
  InvalidRect: TRect;
begin
  if not HandleAllocated then Exit;
  GridRectToScreenRect(ARect, InvalidRect, True);
  Windows.InvalidateRect(Handle, @InvalidRect, False);
end;

procedure TXCustomGrid.InvertRect(const Rect: TRect);
begin
  with Rect do
    PatBlt(Canvas.Handle, Left, Top, Right - Left, Bottom - Top, DSTINVERT);
end;

procedure TXCustomGrid.ModifyScrollBar(ScrollBar, ScrollCode, Pos: Cardinal);
var
  NewTopLeft, MaxTopLeft: TXGridCoord;
  DrawInfo: TXGridDrawInfo;

  function Min: Longint;
  begin
    if ScrollBar = SB_HORZ then Result := FixedCols
    else Result := FixedRows;
  end;

  function Max: Longint;
  begin
    if ScrollBar = SB_HORZ then Result := MaxTopLeft.X
    else Result := MaxTopLeft.Y;
  end;

  function PageUp: Longint;
  var
    MaxTopLeft: TXGridCoord;
  begin
    MaxTopLeft := CalcMaxTopLeft(FTopLeft, DrawInfo);
    if ScrollBar = SB_HORZ then
      Result := FTopLeft.X - MaxTopLeft.X else
      Result := FTopLeft.Y - MaxTopLeft.Y;
    if Result < 1 then Result := 1;
  end;

  function PageDown: Longint;
  var
    DrawInfo: TXGridDrawInfo;
  begin
    CalcDrawInfo(DrawInfo);
    with DrawInfo do
      if ScrollBar = SB_HORZ then
        Result := Horz.LastFullVisibleCell - FTopLeft.X else
        Result := Vert.LastFullVisibleCell - FTopLeft.Y;
    if Result < 1 then Result := 1;
  end;

  function CalcScrollBar(Value: Longint): Longint;
  begin
    Result := Value;
    case ScrollCode of
      SB_LINEUP:
        Result := Value - 1;
      SB_LINEDOWN:
        Result := Value + 1;
      SB_PAGEUP:
        Result := Value - PageUp;
      SB_PAGEDOWN:
        Result := Value + PageDown;
      SB_THUMBPOSITION, SB_THUMBTRACK:
        if (goThumbTracking in Options) or (ScrollCode = SB_THUMBPOSITION) then
          Result := Min + LongMulDiv(Pos, Max - Min, MaxShortInt);
      SB_BOTTOM:
        Result := Min;
      SB_TOP:
        Result := Min;
    end;
  end;

  procedure ModifyPixelScrollBar(Code, Pos: Cardinal);
  var
    NewOffset: Integer;
    OldOffset: Integer;
//    R: TXGridRect;
  begin
    NewOffset := FColOffset;
    case Code of
      SB_LINEUP: Dec(NewOffset, Canvas.TextWidth('0'));
      SB_LINEDOWN: Inc(NewOffset, Canvas.TextWidth('0'));
      SB_PAGEUP: Dec(NewOffset, ClientWidth);
      SB_PAGEDOWN: Inc(NewOffset, ClientWidth);
      SB_THUMBPOSITION: NewOffset := Pos;
      SB_THUMBTRACK: if goThumbTracking in Options then NewOffset := Pos;
      SB_BOTTOM: NewOffset := 0;
      SB_TOP: NewOffset := ColWidths[0] - ClientWidth;
    end;
    if NewOffset < 0 then
      NewOffset := 0
    else if NewOffset >= ColWidths[0] - ClientWidth then
      NewOffset := ColWidths[0] - ClientWidth;
    if NewOffset <> FColOffset then
    begin
      OldOffset := FColOffset;
      FColOffset := NewOffset;
      ScrollData(OldOffset - NewOffset, 0);
//      FillChar(R, SizeOf(R), 0);
//      R.Bottom := FixedRows;
//      InvalidateRect(R);
      Update;
      UpdateScrollPos;
    end;
  end;

begin
  if Visible and CanFocus and TabStop and not (csDesigning in ComponentState) then
    SetFocus;
  if (ScrollBar = SB_HORZ) and (ColCount = 1) then
  begin
    ModifyPixelScrollBar(ScrollCode, Pos);
    Exit;
  end;
  CalcDrawInfo(DrawInfo);
  MaxTopLeft.X := ColCount - 1;
  MaxTopLeft.Y := RowCount - 1;
  MaxTopLeft := CalcMaxTopLeft(MaxTopLeft, DrawInfo);
  NewTopLeft := FTopLeft;
  if ScrollBar = SB_HORZ then NewTopLeft.X := CalcScrollBar(NewTopLeft.X)
  else NewTopLeft.Y := CalcScrollBar(NewTopLeft.Y);
  if NewTopLeft.X < FixedCols then NewTopLeft.X := FixedCols
  else if NewTopLeft.X > MaxTopLeft.X then NewTopLeft.X := MaxTopLeft.X;
  if NewTopLeft.Y < FixedRows then NewTopLeft.Y := FixedRows
  else if NewTopLeft.Y > MaxTopLeft.Y then NewTopLeft.Y := MaxTopLeft.Y;
  if (NewTopLeft.X <> FTopLeft.X) or (NewTopLeft.Y <> FTopLeft.Y) then
    MoveTopLeft(NewTopLeft.X, NewTopLeft.Y);
end;

procedure TXCustomGrid.MoveAdjust(var CellPos: Longint; FromIndex, ToIndex: Longint);
var
  Min, Max: Longint;
begin
  if CellPos = FromIndex then CellPos := ToIndex
  else
  begin
    Min := FromIndex;
    Max := ToIndex;
    if FromIndex > ToIndex then
    begin
      Min := ToIndex;
      Max := FromIndex;
    end;
    if (CellPos >= Min) and (CellPos <= Max) then
      if FromIndex > ToIndex then
        Inc(CellPos) else
        Dec(CellPos);
  end;
end;

procedure TXCustomGrid.MoveAnchor(const NewAnchor: TXGridCoord);
var
  OldSel: TXGridRect;
begin
  if (goRowSelect in Options) and (FAnchor.Y = NewAnchor.Y) then Exit;
//
  if [goRangeSelect, goEditing] * Options = [goRangeSelect] then
  begin
    OldSel := Selection;
    FAnchor := NewAnchor;
    if goRowSelect in Options then FAnchor.X := ColCount - 1;
    ClampInView(NewAnchor);
    SelectionMoved(OldSel);
  end
  else MoveCurrent(NewAnchor.X, NewAnchor.Y, True, True);
end;

procedure TXCustomGrid.MoveCurrent(ACol, ARow: Longint; MoveAnchor,
  Show: Boolean);
var
  OldSel: TXGridRect;
  OldCurrent: TXGridCoord;
begin
  if (ACol < 0) or (ARow < 0) or (ACol >= ColCount) or (ARow >= RowCount) then
    InvalidOp(SIndexOutOfRange);
  if SelectCell(ACol, ARow) then
  begin
    OldSel := Selection;
    OldCurrent := FCurrent;
    FCurrent.X := ACol;
    FCurrent.Y := ARow;
    if not (goAlwaysShowEditor in Options) then HideEditor;
    if MoveAnchor or not (goRangeSelect in Options) then
    begin
      FAnchor := FCurrent;
      if goRowSelect in Options then FAnchor.X := ColCount - 1;
    end;
    if goRowSelect in Options then FCurrent.X := FixedCols;
    if Show then ClampInView(FCurrent);
    SelectionMoved(OldSel);
    if goRowSelect in Options then
    begin
      with OldCurrent do InvalidateRow(Y);
      with FCurrent   do InvalidateRow(Y);
    end
    else
    begin
      with OldCurrent do InvalidateCell(X, Y);
      with FCurrent   do InvalidateCell(X, Y);
    end;
    if ([csDesigning, csReading] * ComponentState = []) then CurrentChanged;
  end;
end;

procedure TXCustomGrid.MoveTopLeft(ALeft, ATop: Longint);
var
  OldTopLeft: TXGridCoord;
begin
  if (ALeft < FixedCols) or (ALeft >= FColCount)  then Exit;
  if (ATop  < FixedRows) or (ATop  >= FRowCount)  then Exit;
  if (ALeft = FTopLeft.X) and (ATop = FTopLeft.Y) then Exit;
  Update;
  OldTopLeft := FTopLeft;
  FTopLeft.X := ALeft;
  FTopLeft.Y := ATop;
  TopLeftMoved(OldTopLeft);
end;

procedure TXCustomGrid.ResizeCol(Index: Longint; OldSize, NewSize: Integer);
begin
  InvalidateGrid;
end;

procedure TXCustomGrid.ResizeRow(Index: Longint; OldSize, NewSize: Integer);
begin
  InvalidateGrid;
end;

procedure TXCustomGrid.SelectionMoved(const OldSel: TXGridRect);
var
  OldRect, NewRect: TRect;
  AXorRects: TXorRects;
  I: Integer;
begin
  if not HandleAllocated then Exit;
  GridRectToScreenRect(OldSel, OldRect, True);
  GridRectToScreenRect(Selection, NewRect, True);
  XorRects(OldRect, NewRect, AXorRects);
  for I := Low(AXorRects) to High(AXorRects) do
    Windows.InvalidateRect(Handle, @AXorRects[I], False);
end;

procedure TXCustomGrid.ScrollDataInfo(DX, DY: Integer;
  var DrawInfo: TXGridDrawInfo);
var
  ScrollArea: TRect;
  ScrollFlags: Integer;
begin
  with DrawInfo do
  begin
    ScrollFlags := SW_INVALIDATE;
    if not DefaultDrawing then
      ScrollFlags := ScrollFlags or SW_ERASE;
    { Scroll the area }
    if DY = 0 then
    begin
      { Scroll both the column titles and data area at the same time }
      ScrollArea := Rect(Horz.FixedBoundary, 0, Horz.GridExtent, Vert.GridExtent);
      ScrollWindowEx(Handle, DX, 0, @ScrollArea, @ScrollArea, 0, nil, ScrollFlags);
    end
    else if DX = 0 then
    begin
      { Scroll both the row titles and data area at the same time }
      ScrollArea := Rect(0, Vert.FixedBoundary, Horz.GridExtent, Vert.GridExtent);
      ScrollWindowEx(Handle, 0, DY, @ScrollArea, @ScrollArea, 0, nil, ScrollFlags);
    end
    else
    begin
      { Scroll titles and data area separately }
      { Column titles }
      ScrollArea := Rect(Horz.FixedBoundary, 0, Horz.GridExtent, Vert.FixedBoundary);
      ScrollWindowEx(Handle, DX, 0, @ScrollArea, @ScrollArea, 0, nil, ScrollFlags);
      { Row titles }
      ScrollArea := Rect(0, Vert.FixedBoundary, Horz.FixedBoundary, Vert.GridExtent);
      ScrollWindowEx(Handle, 0, DY, @ScrollArea, @ScrollArea, 0, nil, ScrollFlags);
      { Data area }
      ScrollArea := Rect(Horz.FixedBoundary, Vert.FixedBoundary, Horz.GridExtent,
        Vert.GridExtent);
      ScrollWindowEx(Handle, DX, DY, @ScrollArea, @ScrollArea, 0, nil, ScrollFlags);
    end;
  end;
end;

procedure TXCustomGrid.ScrollData(DX, DY: Integer);
var
  DrawInfo: TXGridDrawInfo;
begin
  CalcDrawInfo(DrawInfo);
  ScrollDataInfo(DX, DY, DrawInfo);
end;

procedure TXCustomGrid.TopLeftMoved(const OldTopLeft: TXGridCoord);

  function CalcScroll(const AxisInfo: TXGridAxisDrawInfo;
    OldPos, CurrentPos: Integer; var Amount: Longint): Boolean;
  var
    Start, Stop: Longint;
    I: Longint;
  begin
//  Result := False;
    with AxisInfo do
    begin
      if OldPos < CurrentPos then
      begin
        Start := OldPos;
        Stop := CurrentPos;
      end
      else
      begin
        Start := CurrentPos;
        Stop := OldPos;
      end;
      Amount := 0;
      for I := Start to Stop - 1 do
      begin
        Inc(Amount, GetExtent(I) + EffectiveLineWidth);
        if Amount > (GridBoundary - FixedBoundary) then
        begin
//          { Scroll amount too big, redraw the whole thing }
//          InvalidateGrid;
//          Exit;
            Break;
        end;
      end;
      if OldPos < CurrentPos then Amount := -Amount;
    end;
    Result := True;
  end;

var
  DrawInfo: TXGridDrawInfo;
  Delta: TXGridCoord;
  Rect: TXGridRect;
begin
  UpdateScrollPos;
  CalcDrawInfo(DrawInfo);
  if CalcScroll(DrawInfo.Horz, OldTopLeft.X, FTopLeft.X, Delta.X) and
    CalcScroll(DrawInfo.Vert, OldTopLeft.Y, FTopLeft.Y, Delta.Y) then
    ScrollDataInfo(Delta.X, Delta.Y, DrawInfo);
  if (OldTopLeft.Y <> FTopLeft.Y) then UpdateLineNumberWidth;
  if (OldTopLeft.X <> FTopLeft.X) and (goRowSelect in Options) then
  begin
   Rect.Left   := FTopLeft.X;
   Rect.Right  := DrawInfo.Horz.LastFullVisibleCell + 1;
   Rect.Top    := FCurrent.Y;
   Rect.Bottom := FCurrent.Y;
   InvalidateRect(Rect);
  end;
  TopLeftChanged;
end;

procedure TXCustomGrid.UpdateScrollPos;
var
  DrawInfo: TXGridDrawInfo;
  MaxTopLeft: TXGridCoord;

  procedure SetScroll(Code: Word; Value: Integer);
  begin
    if GetScrollPos(Handle, Code) <> Value then
      SetScrollPos(Handle, Code, Value, True);
  end;

begin
  if (not HandleAllocated) or (ScrollBars = ssNone) then Exit;
  CalcDrawInfo(DrawInfo);
  MaxTopLeft.X := ColCount - 1;
  MaxTopLeft.Y := RowCount - 1;
  MaxTopLeft := CalcMaxTopLeft(MaxTopLeft, DrawInfo);
  if ScrollBars in [ssHorizontal, ssBoth] then
    if ColCount = 1 then
    begin
      if (FColOffset > 0) and (ClientWidth > ColWidths[0] - FColOffset) then
        ModifyScrollbar(SB_HORZ, SB_THUMBPOSITION, ColWidths[0] - ClientWidth)
      else
        SetScroll(SB_HORZ, FColOffset)
    end
    else
      SetScroll(SB_HORZ, LongMulDiv(FTopLeft.X - FixedCols, MaxShortInt,
        MaxTopLeft.X - FixedCols));
  if ScrollBars in [ssVertical, ssBoth] then
    SetScroll(SB_VERT, LongMulDiv(FTopLeft.Y - FixedRows, MaxShortInt,
      MaxTopLeft.Y - FixedRows));
end;

procedure TXCustomGrid.UpdateScrollRange;
var
  MaxTopLeft, OldTopLeft: TXGridCoord;
  DrawInfo: TXGridDrawInfo;
  OldScrollBars: TScrollStyle;
  Updated: Boolean;

  procedure DoUpdate;
  begin
    if not Updated then
    begin
      Update;
      Updated := True;
    end;
  end;

  function ScrollBarVisible(Code: Word): Boolean;
  var
    Min, Max: Integer;
  begin
    Result := False;
    if (ScrollBars = ssBoth) or
      ((Code = SB_HORZ) and (ScrollBars = ssHorizontal)) or
      ((Code = SB_VERT) and (ScrollBars = ssVertical)) then
    begin
      GetScrollRange(Handle, Code, Min, Max);
      Result := Min <> Max;
    end;
  end;

  procedure CalcSizeInfo;
  begin
    CalcDrawInfoXY(DrawInfo, DrawInfo.Horz.GridExtent, DrawInfo.Vert.GridExtent);
    MaxTopLeft.X := ColCount - 1;
    MaxTopLeft.Y := RowCount - 1;
    MaxTopLeft := CalcMaxTopLeft(MaxTopLeft, DrawInfo);
  end;

  procedure SetAxisRange(var Max, Old, Current: Longint; Code: Word;
    Fixeds: Integer);
  begin
    CalcSizeInfo;
    if Fixeds < Max then
      SetScrollRange(Handle, Code, 0, MaxShortInt, True)
    else
      SetScrollRange(Handle, Code, 0, 0, True);
    if Old > Max then
    begin
      DoUpdate;
      Current := Max;
    end;
  end;

  procedure SetHorzRange;
  var
    Range: Integer;
  begin
    if OldScrollBars in [ssHorizontal, ssBoth] then
      if ColCount = 1 then
      begin
        Range := ColWidths[0] - ClientWidth;
        if Range < 0 then Range := 0;
        SetScrollRange(Handle, SB_HORZ, 0, Range, True);
      end
      else
        SetAxisRange(MaxTopLeft.X, OldTopLeft.X, FTopLeft.X, SB_HORZ, FixedCols);
  end;

  procedure SetVertRange;
  begin
    if OldScrollBars in [ssVertical, ssBoth] then
      SetAxisRange(MaxTopLeft.Y, OldTopLeft.Y, FTopLeft.Y, SB_VERT, FixedRows);
  end;

begin
  if (ScrollBars = ssNone) or not HandleAllocated then Exit;
  with DrawInfo do
  begin
    Horz.GridExtent := ClientWidth;
    Vert.GridExtent := ClientHeight;
    { Ignore scroll bars for initial calculation }
    if ScrollBarVisible(SB_HORZ) then
      Inc(Vert.GridExtent, GetSystemMetrics(SM_CYHSCROLL));
    if ScrollBarVisible(SB_VERT) then
      Inc(Horz.GridExtent, GetSystemMetrics(SM_CXVSCROLL));
  end;
  OldTopLeft := FTopLeft;
  { Temporarily mark us as not having scroll bars to avoid recursion }
  OldScrollBars := FScrollBars;
  FScrollBars := ssNone;
  Updated := False;
  try
    { Update scrollbars }
    SetHorzRange;
    DrawInfo.Vert.GridExtent := ClientHeight;
    SetVertRange;
    if DrawInfo.Horz.GridExtent <> ClientWidth then
    begin
      DrawInfo.Horz.GridExtent := ClientWidth;
      SetHorzRange;
    end;
  finally
    FScrollBars := OldScrollBars;
  end;
  UpdateScrollPos;
  if (FTopLeft.X <> OldTopLeft.X) or (FTopLeft.Y <> OldTopLeft.Y) then
    TopLeftMoved(OldTopLeft);
end;

function TXCustomGrid.CreateEditor: TXGridEdit;
begin
  Result := TXGridEdit.Create(Self);
end;

procedure TXCustomGrid.CreateParams(var Params: TCreateParams);
begin
  inherited CreateParams(Params);
  with Params do
  begin
    Style := Style or WS_TABSTOP;
    if FScrollBars in [ssVertical, ssBoth] then Style := Style or WS_VSCROLL;
    if FScrollBars in [ssHorizontal, ssBoth] then Style := Style or WS_HSCROLL;
    WindowClass.style := CS_DBLCLKS;
    if FBorderStyle = bsSingle then
      if NewStyleControls and Ctl3D then
      begin
        Style := Style and not WS_BORDER;
        ExStyle := ExStyle or WS_EX_CLIENTEDGE;
      end
      else
        Style := Style or WS_BORDER;
  end;
end;

procedure TXCustomGrid.DrawCell(ACol, ARow: Longint; ARect: TRect;
      AState: TXGridDrawState);
begin
end;

procedure TXCustomGrid.DrawCellText(ARect: TRect; Text: String; Mode: TXGridTextMode);
var
  x, y, w: Integer;
begin
  Inc(ARect.Left);
  Inc(ARect.Top );
  Dec(ARect.Right , 2);
  Dec(ARect.Bottom, 2);
  x := ARect.Left + 1;
  y := ARect.Top  + 1;
  case Mode Of
  gtRight:
    begin
      w := Canvas.TextWidth(Text);
      x := (ARect.Right - w);
    end;
  gtCenter:
    begin
      w := Canvas.TextWidth(Text);
      Inc(x, (ARect.Right - x - w) div 2);
    end;
  end;
  SetBkMode(Canvas.Handle, TRANSPARENT);
  ExtTextOut(Canvas.Handle, x, y, ETO_CLIPPED, @ARect, PChar(Text), Length(Text), nil);
end;

procedure TXCustomGrid.KeyDown(var Key: Word; Shift: TShiftState);
var
  NewTopLeft, NewCurrent, MaxTopLeft: TXGridCoord;
  DrawInfo: TXGridDrawInfo;
  PageWidth, PageHeight: Integer;

  procedure CalcPageExtents;
  begin
    CalcDrawInfo(DrawInfo);
    PageWidth := DrawInfo.Horz.LastFullVisibleCell - LeftCol;
    if PageWidth < 1 then PageWidth := 1;
    PageHeight := DrawInfo.Vert.LastFullVisibleCell - TopRow;
    if PageHeight < 1 then PageHeight := 1;
  end;

  procedure Restrict(var Coord: TXGridCoord; MinX, MinY, MaxX, MaxY: Longint);
  begin
    with Coord do
    begin
      if X > MaxX then X := MaxX
      else if X < MinX then X := MinX;
      if Y > MaxY then Y := MaxY
      else if Y < MinY then Y := MinY;
    end;
  end;

begin
  inherited KeyDown(Key, Shift);
  if not CanGridAcceptKey(Key, Shift) then Key := 0;
  NewCurrent := FCurrent;
  NewTopLeft := FTopLeft;
  CalcPageExtents;
  if ssCtrl in Shift then
    case Key of
      VK_UP: Dec(NewTopLeft.Y);
      VK_DOWN: Inc(NewTopLeft.Y);
      VK_LEFT:
        if not (goRowSelect in Options) then
        begin
          Dec(NewCurrent.X, PageWidth);
          Dec(NewTopLeft.X, PageWidth);
        end;
      VK_RIGHT:
        if not (goRowSelect in Options) then
        begin
          Inc(NewCurrent.X, PageWidth);
          Inc(NewTopLeft.X, PageWidth);
        end;
      VK_PRIOR: NewCurrent.Y := TopRow;
      VK_NEXT: NewCurrent.Y := DrawInfo.Vert.LastFullVisibleCell;
      VK_HOME:
        begin
          NewCurrent.X := FixedCols;
          NewCurrent.Y := FixedRows;
        end;
      VK_END:
        begin
          NewCurrent.X := ColCount - 1;
          NewCurrent.Y := RowCount - 1;
        end;
    end
  else
    case Key of
      VK_UP: Dec(NewCurrent.Y);
      VK_DOWN: Inc(NewCurrent.Y);
      VK_LEFT:
        if goRowSelect in Options then
          Dec(NewCurrent.Y) else
          Dec(NewCurrent.X);
      VK_RIGHT:
        if goRowSelect in Options then
          Inc(NewCurrent.Y) else
          Inc(NewCurrent.X);
      VK_NEXT:
        begin
          Inc(NewCurrent.Y, PageHeight);
          Inc(NewTopLeft.Y, PageHeight);
        end;
      VK_PRIOR:
        begin
          Dec(NewCurrent.Y, PageHeight);
          Dec(NewTopLeft.Y, PageHeight);
        end;
      VK_HOME:
        if goRowSelect in Options then
          NewCurrent.Y := FixedRows else
          NewCurrent.X := FixedCols;
      VK_END:
        if goRowSelect in Options then
          NewCurrent.Y := RowCount - 1 else
          NewCurrent.X := ColCount - 1;
      VK_TAB:
        if not (ssAlt in Shift) then
        repeat
          if ssShift in Shift then
          begin
            Dec(NewCurrent.X);
            if NewCurrent.X < FixedCols then
            begin
              NewCurrent.X := ColCount - 1;
              Dec(NewCurrent.Y);
              if NewCurrent.Y < FixedRows then NewCurrent.Y := RowCount - 1;
            end;
            Shift := [];
          end
          else
          begin
            Inc(NewCurrent.X);
            if NewCurrent.X >= ColCount then
            begin
              NewCurrent.X := FixedCols;
              Inc(NewCurrent.Y);
              if NewCurrent.Y >= RowCount then NewCurrent.Y := FixedRows;
            end;
          end;
        until TabStops[NewCurrent.X] or (NewCurrent.X = FCurrent.X);
      VK_F2: if not (goAlwaysShowEditor in Options) then EditorMode := not EditorMode;//True;
    end;
  MaxTopLeft.X := ColCount - 1;
  MaxTopLeft.Y := RowCount - 1;
  MaxTopLeft := CalcMaxTopLeft(MaxTopLeft, DrawInfo);
  Restrict(NewTopLeft, FixedCols, FixedRows, MaxTopLeft.X, MaxTopLeft.Y);
  if (NewTopLeft.X <> LeftCol) or (NewTopLeft.Y <> TopRow) then
    MoveTopLeft(NewTopLeft.X, NewTopLeft.Y);
  Restrict(NewCurrent, FFixedCols, FFixedRows, ColCount - 1, RowCount - 1);
  if (NewCurrent.X <> Col) or (NewCurrent.Y <> Row) then
    FocusCell(NewCurrent.X, NewCurrent.Y, not (ssShift in Shift));
end;

procedure TXCustomGrid.KeyPress(var Key: Char);
var
  i: Longint;
begin
  inherited KeyPress(Key);
  if not (goEditing in Options) then
  begin
    if (Key = Char(VK_RETURN)) or (Key = Char(VK_SPACE)) then
    begin
      if (goSelectRow in Options) then
      begin
        if (goMultiSelect in Options) then
        begin
          for i := Selection.Top to Selection.Bottom do
            SelectRow[i] := not SelectRow[i];
        end
        else
          SelectRow[Row] := not SelectRow[Row];
        Key := #0;
      end
      else if (goSelectCol in Options) then
      begin
        if (goMultiSelect in Options) then
        begin
          for i := Selection.Left to Selection.Right do
            SelectCol[i] := not SelectCol[i];
        end
        else
          SelectCol[Col] := not SelectCol[Col];
        Key := #0;
      end;
    end;
  end
  else if not (goAlwaysShowEditor in Options) and (Key = Char(VK_RETURN)) then
  begin
    if FEditorMode then
      HideEditor else
      ShowEditor;
    Key := #0;
  end;
end;

procedure TXCustomGrid.Loaded;   (* 追加 1996/06/26 *)
begin
  inherited Loaded;
  Canvas.Font := Font;
  UpdateDefaultRowHeight;
end;

procedure TXCustomGrid.MouseDown(Button: TMouseButton; Shift: TShiftState;
  X, Y: Integer);
var
  CellHit: TXGridCoord;
  DrawInfo: TXGridDrawInfo;
  MoveDrawn: Boolean;
begin
  MoveDrawn := False;
//  HideEdit;
  if not (csDesigning in ComponentState) and CanFocus then
  begin
    SetFocus;
    if ValidParentForm(Self).ActiveControl <> Self then
    begin
      MouseCapture := False;
      Exit;
    end;
  end;
  if (Button = mbLeft) and (ssDouble in Shift) then
    DblClick
  else if Button = mbLeft then
  begin
    CalcDrawInfo(DrawInfo);
    { Check grid sizing }
    CalcSizingState(X, Y, FGridState, FSizingIndex, FSizingPos, FSizingOfs,
      DrawInfo);
    if FGridState <> gsNormal then
    begin
      Update;         (* 追加 1996/06/26 *)
      DrawSizingLine(DrawInfo);
      Exit;
    end;
    CellHit := CalcCoordFromPoint(X, Y, DrawInfo);
    if (CellHit.X >= FFixedCols) and (CellHit.Y >= FFixedRows) then
    begin
      if goEditing in Options then
      begin
        if (CellHit.X = FCurrent.X) and (CellHit.Y = FCurrent.Y) then
          ShowEditor
        else
        begin
          MoveCurrent(CellHit.X, CellHit.Y, True, True);
          UpdateEdit;
        end;
        Click;
      end
      else
      begin
        FGridState := gsSelecting;
        SetTimer(Handle, 1, 60, nil);
        if ssShift in Shift then
          MoveAnchor(CellHit)
        else
          MoveCurrent(CellHit.X, CellHit.Y, True, True);
      end;
    end
//    else if (CellHit.X >= 0) and (CellHit.X < FixedCols) and (CellHit.Y >= FixedRows) then
    else if (CellHit.X = 0) and (CellHit.Y >= FixedRows) then
    begin
      if (goRowMoving in Options) then
      begin
        FGridState := gsRowMoving;
        FMoveIndex := CellHit.Y;
        FMovePos := FMoveIndex;
        Update;
        DrawMove;
        MoveDrawn := True;
        SetTimer(Handle, 1, 60, nil);
      end
      else if (goSelectRow in Options) then
      begin
        if (goMultiSelect in Options) then
        begin
          FGridState := gsSelectingRow;
          FMoveIndex := CellHit.Y;
          FMovePos := FMoveIndex;
          InvalidateRow(FMoveIndex);
          SetTimer(Handle, 1, 60, nil);
        end
        else
        begin
          SelectRow[CellHit.Y] := not SelectRow[CellHit.Y];
        end;
      end;
    end
//    else if (CellHit.Y >= 0) and (CellHit.Y < FixedRows) and (CellHit.X >= FixedCols) then
    else if (CellHit.Y = 0) and (CellHit.X >= FixedCols) then
    begin
      if (goColMoving in Options) then
      begin
        FGridState := gsColMoving;
        FMoveIndex := CellHit.X;
        FMovePos := FMoveIndex;
        Update;
        DrawMove;
        MoveDrawn := True;
        SetTimer(Handle, 1, 60, nil);
      end
      else if (goSelectCol in Options) then
      begin
        if (goMultiSelect in Options) then
        begin
          FGridState := gsSelectingCol;
          FMoveIndex := CellHit.X;
          FMovePos := FMoveIndex;
          InvalidateCol(FMoveIndex);
          SetTimer(Handle, 1, 60, nil);
        end
        else
        begin
          SelectCol[CellHit.X] := not SelectCol[CellHit.X];
        end;
      end;
    end;
  end;
  try
    inherited MouseDown(Button, Shift, X, Y);
  except
    if MoveDrawn then DrawMove;
  end;
end;

procedure TXCustomGrid.MouseMove(Shift: TShiftState; X, Y: Integer);
var
  DrawInfo: TXGridDrawInfo;
  CellHit: TXGridCoord;
  i: Longint;
begin
  CalcDrawInfo(DrawInfo);
  case FGridState of
    gsSelecting, gsColMoving, gsRowMoving:
      begin
        CellHit := CalcCoordFromPoint(X, Y, DrawInfo);
        if (CellHit.X >= FixedCols) and (CellHit.Y >= FixedRows) and
          (CellHit.X <= DrawInfo.Horz.LastFullVisibleCell+1) and
          (CellHit.Y <= DrawInfo.Vert.LastFullVisibleCell+1) then
          case FGridState of
            gsSelecting:
              if ((CellHit.X <> FAnchor.X) or (CellHit.Y <> FAnchor.Y)) then
                MoveAnchor(CellHit);
            gsColMoving:
              MoveAndScroll(X, CellHit.X, DrawInfo, DrawInfo.Horz, SB_HORZ);
            gsRowMoving:
              MoveAndScroll(Y, CellHit.Y, DrawInfo, DrawInfo.Vert, SB_VERT);
          end;
      end;
    gsRowSizing, gsColSizing:
      begin
        DrawSizingLine(DrawInfo); { XOR it out }
        if FGridState = gsRowSizing then
          FSizingPos := Y + FSizingOfs else
          FSizingPos := X + FSizingOfs;
        DrawSizingLine(DrawInfo); { XOR it back in }
      end;
    gsSelectingCol:
      begin
        CellHit := CalcCoordFromPoint(X, Y, DrawInfo);
        if CellHit.X < FixedCols then
          CellHit.X := LeftCol;
        if CellHit.X > DrawInfo.Horz.LastFullVisibleCell then
          CellHit.X := DrawInfo.Horz.LastFullVisibleCell;
        if (FMovePos <> CellHit.X) then
        begin
          if FMovePos <= CellHit.X then
            for i := FMovePos     to CellHit.X do InvalidateCol(i)
          else
            for i := FMovePos downto CellHit.X do InvalidateCol(i);
          FMovePos := CellHit.X;
        end;
      end;
    gsSelectingRow:
      begin
        CellHit := CalcCoordFromPoint(X, Y, DrawInfo);
        if CellHit.Y < FixedRows then
          CellHit.Y := TopRow;
        if CellHit.Y > DrawInfo.Vert.LastFullVisibleCell then
          CellHit.Y := DrawInfo.Vert.LastFullVisibleCell;
        if (FMovePos <> CellHit.Y) then
        begin
          if FMovePos <= CellHit.Y then
            for i := FMovePos     to CellHit.Y do InvalidateRow(i)
          else
            for i := FMovePos downto CellHit.Y do InvalidateRow(i);
          FMovePos := CellHit.Y;
        end;
      end;
  end;
  inherited MouseMove(Shift, X, Y);
end;

procedure TXCustomGrid.MouseUp(Button: TMouseButton; Shift: TShiftState;
  X, Y: Integer);
var
  DrawInfo: TXGridDrawInfo;
  NewSize: Integer;

  function ResizeLine(const AxisInfo: TXGridAxisDrawInfo): Integer;
  var
    I: Integer;
  begin
    with AxisInfo do
    begin
{$IFNDEF NOTHING}
      if (FSizingIndex < FixedCellCount) then
      begin
        Result := 0;
        for I := 0 to FSizingIndex - 1 do
          Inc(Result, GetExtent(I) + EffectiveLineWidth);
      end
      else
      begin
        Result := FixedBoundary;
        for I := FirstGridCell to FSizingIndex - 1 do
          Inc(Result, GetExtent(I) + EffectiveLineWidth);
      end;
{$ELSE}
      Result := FixedBoundary;
      for I := FirstGridCell to FSizingIndex - 1 do
        Inc(Result, GetExtent(I) + EffectiveLineWidth);
{$ENDIF}
      Result := FSizingPos - Result;
    end;
  end;

  procedure UpdateSelectCol(FromIndex, ToIndex: Longint);
  var
    i: Integer;
  begin
    if (FromIndex > ToIndex) then
    begin
      i := FromIndex;
      FromIndex := ToIndex;
      ToIndex := i;
    end;
    for i := FromIndex to ToIndex do
      SelectCol[i] := not SelectCol[i];
  end;

  procedure UpdateSelectRow(FromIndex, ToIndex: Longint);
  var
    i: Integer;
  begin
    if (FromIndex > ToIndex) then
    begin
      i := FromIndex;
      FromIndex := ToIndex;
      ToIndex := i;
    end;
    for i := FromIndex to ToIndex do
      SelectRow[i] := not SelectRow[i];
  end;

begin
  try
    case FGridState of
      gsSelecting:
        begin
          MouseMove(Shift, X, Y);
          KillTimer(Handle, 1);
          UpdateEdit;
          Click;
        end;
      gsRowSizing, gsColSizing:
        begin
          CalcDrawInfo(DrawInfo);
          DrawSizingLine(DrawInfo);
          if FGridState = gsColSizing then
          begin
            NewSize := ResizeLine(DrawInfo.Horz);
            if NewSize > 1 then
            begin
              ColWidths[FSizingIndex] := NewSize;
              UpdateDesigner;
            end;
          end
          else
          begin
            NewSize := ResizeLine(DrawInfo.Vert);
            if NewSize > 1 then
            begin
              RowHeights[FSizingIndex] := NewSize;
              UpdateDesigner;
            end;
          end;
        end;
      gsColMoving, gsRowMoving:
        begin
          DrawMove;
          KillTimer(Handle, 1);
          if FMoveIndex <> FMovePos then
          begin
            if FGridState = gsColMoving then
              MoveColumn(FMoveIndex, FMovePos)
            else
              MoveRow(FMoveIndex, FMovePos);
            UpdateDesigner;
          end;
          UpdateEdit;
        end;
      gsSelectingCol:
        begin
          KillTimer(Handle, 1);
          UpdateSelectCol(FMoveIndex, FMovePos)
        end;
      gsSelectingRow:
        begin
          KillTimer(Handle, 1);
          UpdateSelectRow(FMoveIndex, FMovePos);
        end;
    else
      UpdateEdit;
    end;
    inherited MouseUp(Button, Shift, X, Y);
  finally
    FGridState := gsNormal;
  end;
end;

procedure TXCustomGrid.MoveAndScroll(Mouse, CellHit: Integer;
  var DrawInfo: TXGridDrawInfo; var Axis: TXGridAxisDrawInfo; ScrollBar: Integer);
begin
  if (CellHit <> FMovePos) and
    not((FMovePos = Axis.FixedCellCount) and (Mouse < Axis.FixedBoundary)) and
    not((FMovePos = Axis.GridCellCount-1) and (Mouse > Axis.GridBoundary)) then
  begin
    DrawMove;
    if (Mouse < Axis.FixedBoundary) then
    begin
      if (FMovePos > Axis.FixedCellCount) then
      begin
        ModifyScrollbar(ScrollBar, SB_LINEUP, 0);
        Update;
        CalcDrawInfo(DrawInfo);    // this changes contents of Axis var
      end;
      CellHit := Axis.FirstGridCell;
    end
    else if (Mouse >= Axis.FullVisBoundary) then
    begin
      if (FMovePos = Axis.LastFullVisibleCell) and
        (FMovePos < Axis.GridCellCount -1) then
      begin
        ModifyScrollBar(Scrollbar, SB_LINEDOWN, 0);
        Update;
        CalcDrawInfo(DrawInfo);    // this changes contents of Axis var
      end;
      CellHit := Axis.LastFullVisibleCell;
    end
    else if CellHit < 0 then CellHit := FMovePos;
    FMovePos := CellHit;
    DrawMove;
  end;
end;

function TXCustomGrid.GetColWidths(Index: Longint): Integer;
begin
  Result := ColInfos[Index].CellSize;
end;

function TXCustomGrid.GetDefaultColWidth: Integer;                        (* 追加 1996/06/26 *)
begin
  Result := FDefaultColInfo.CellSize;
end;

function TXCustomGrid.GetDefaultRowHeight: Integer;                       (* 追加 1996/06/26 *)
begin
  Result := FDefaultRowInfo.CellSize;
end;

function TXCustomGrid.GetRowHeights(Index: Longint): Integer;
begin
  Result := RowInfos[Index].CellSize;
end;

function TXCustomGrid.GetGridWidth: Integer;
var
  DrawInfo: TXGridDrawInfo;
begin
  CalcDrawInfo(DrawInfo);
  Result := DrawInfo.Horz.GridBoundary;
end;

function TXCustomGrid.GetGridHeight: Integer;
var
  DrawInfo: TXGridDrawInfo;
begin
  CalcDrawInfo(DrawInfo);
  Result := DrawInfo.Vert.GridBoundary;
end;

function TXCustomGrid.GetSelection: TXGridRect;
begin
  Result := GridRect(FCurrent, FAnchor);
end;

function TXCustomGrid.GetTabStops(Index: Longint): Boolean;
begin
  Result := ColInfos[Index].TabStops;
end;

function TXCustomGrid.GetVisibleColCount: Integer;
var
  DrawInfo: TXGridDrawInfo;
begin
  CalcDrawInfo(DrawInfo);
  Result := DrawInfo.Horz.LastFullVisibleCell - LeftCol + 1;
end;

function TXCustomGrid.GetVisibleRowCount: Integer;
var
  DrawInfo: TXGridDrawInfo;
begin
  CalcDrawInfo(DrawInfo);
  Result := DrawInfo.Vert.LastFullVisibleCell - TopRow + 1;
end;

procedure TXCustomGrid.SetAutoSize(Value: Boolean);       (* 追加 1996/06/26 *)
begin
  if FAutoSize <> Value then
  begin
    FAutoSize := Value;
    UpdateDefaultRowHeight;
  end;
end;

procedure TXCustomGrid.SetBorderStyle(Value: TBorderStyle);
begin
  if FBorderStyle <> Value then
  begin
    FBorderStyle := Value;
    RecreateWnd;
  end;
end;

procedure TXCustomGrid.SetCol(Value: Longint);
begin
  if Col <> Value then FocusCell(Value, Row, True);
end;

procedure TXCustomGrid.SetColCount(Value: Longint);
begin
  if FColCount <> Value then
  begin
    ChangeSize(Value, RowCount);
    if goRowSelect in Options then
    begin
      FAnchor.X := ColCount - 1;
      Invalidate;
    end;
  end;
end;

function TXCustomGrid.GetAvgCharWidth: Integer;  (* 追加 1996/06/26 *)
var
  i, j: Integer;
begin
  i := Canvas.TextWidth('亜亜亜亜') div 8;
  j := Canvas.TextWidth('MMMMMMMM') div 8;
  Result := IMax(i, j);
end;

function TXCustomGrid.GetColTextLens(Index: Longint): Integer;  (* 追加 1996/06/26 *)
begin
  Result := (GetColWidths(Index) - 4) div GetAvgCharWidth;
end;

procedure TXCustomGrid.SetColTextLens(Index: Longint; Value: Integer);  (* 追加 1996/06/26 *)
begin
  SetColWidths(Index, Value * GetAvgCharWidth + 4);
end;

procedure TXCustomGrid.SetDefaultLineNumberWidth(Value: Integer);
begin
  if FDefaultLineNumberWidth <> Value then begin
    FDefaultLineNumberWidth := Value;
    if (goLineNumber in Options) then UpdateLineNumberWidth;
  end;
end;

procedure TXCustomGrid.SetColWidths(Index: Longint; Value: Integer);
begin
  if Index >= ColCount then InvalidOp(SIndexOutOfRange);
  UpdateExtents(FColInfos, FColCount);
  if (ColInfos[Index].CellSize <> Value) then
  begin
    ResizeCol(Index, ColInfos[Index].CellSize, Value);
    if (ColInfos[Index] = FDefaultColInfo) then
    begin
      ColInfos[Index] := FDefaultColInfo.Duplicate;
      ColInfos[Index].CellSize := Value;
    end
    else
    begin
      ColInfos[Index].CellSize := Value;
      if ColInfos[Index].IsEqual(FDefaultColInfo) then
      begin
        ColInfos[Index].Free;
        ColInfos[Index] := nil;
      end;
    end;
    ColWidthsChanged;
  end;
end;

procedure TXCustomGrid.SetDefaultColWidth(Value: Integer);
begin
  UpdateExtents(FColInfos, 0);
  UpdateExtents(FColInfos, FColCount);
  FDefaultColInfo.CellSize := Value;
  ColWidthsChanged;
  InvalidateGrid;
end;

procedure TXCustomGrid.SetDefaultRowHeight(Value: Integer);
begin
  UpdateExtents(FRowInfos, 0);
  UpdateExtents(FRowInfos, FRowCount);
  FDefaultRowInfo.CellSize := Value;
  RowHeightsChanged;
  InvalidateGrid;
end;

procedure TXCustomGrid.SetFixedColor(Value: TColor);
begin
  if FFixedColor <> Value then
  begin
    FFixedColor := Value;
    InvalidateGrid;
  end;
end;

function TXCustomGrid.GetFixedCols: Integer;
begin
  if (csWriting in ComponentState) then
    Result := FFixedCols
  else
    Result := FFixedCols + NScrlCols;
end;

procedure TXCustomGrid.SetFixedCols(Value: Integer);
begin
  if not (csReading in ComponentState) then
    Value := Value - FNScrlCols;
  if FFixedCols <> Value then
  begin
    if Value < 0 then InvalidOp(SIndexOutOfRange);
    if Value + FNScrlCols >= ColCount then ColCount := Value + FNScrlCols + 1;
    FFixedCols := Value;
    Initialize;
    InvalidateGrid;
  end;
end;

function TXCustomGrid.GetFixedRows: Integer;
begin
  if (csWriting in ComponentState) then
    Result := FFixedRows
  else
    Result := FFixedRows + FNScrlRows;
end;

procedure TXCustomGrid.SetFixedRows(Value: Integer);
begin
  if not (csReading in ComponentState) then
    Value := Value - FNScrlRows;
  if FFixedRows <> Value then
  begin
    if Value < 0 then InvalidOp(SIndexOutOfRange);
    if Value + FNScrlRows >= RowCount then RowCount := Value + FNScrlRows + 1;
    FFixedRows := Value;
    Initialize;
    InvalidateGrid;
  end;
end;

procedure TXCustomGrid.SetNScrlCols(Value: Integer);
begin
  if FNScrlCols <> Value then
  begin
    if Value < 0 then InvalidOp(SIndexOutOfRange);
    if Value + FFixedCols >= ColCount then ColCount := Value + FFixedCols + 1;
    FNScrlCols := Value;
    Initialize;
    InvalidateGrid;
  end;
end;

procedure TXCustomGrid.SetNScrlRows(Value: Integer);
begin
  if FNScrlRows <> Value then
  begin
    if Value < 0 then InvalidOp(SIndexOutOfRange);
    if Value + FFixedRows >= RowCount then RowCount := Value + FFixedRows + 1;
    FNScrlRows := Value;
    Initialize;
    InvalidateGrid;
  end;
end;

procedure TXCustomGrid.SetEditorMode(Value: Boolean);
begin
  if not Value then
    HideEditor
  else
  begin
    ShowEditor;
    if FInplaceEdit <> nil then FInplaceEdit.Deselect;
  end;
end;

procedure TXCustomGrid.SetGridLineWidth(Value: Integer);
begin
  if FGridLineWidth <> Value then
  begin
    FGridLineWidth := Value;
    InvalidateGrid;
  end;
end;

procedure TXCustomGrid.SetLeftCol(Value: Longint);
begin
  if FTopLeft.X <> Value then MoveTopLeft(Value, TopRow);
end;

procedure TXCustomGrid.SetOptions(Value: TXGridOptions);
const
  DrawOpt = [goRowSelect, goDrawFocusSelected, goLineNumber,
      goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine];
var
  OldOptions: TXGridOptions;
  OptLineNumber: Boolean;
begin
  if FOptions <> Value then
  begin
    if goRowSelect in Value then
      Exclude(Value, goAlwaysShowEditor);
    OptLineNumber := Integer(goLineNumber in FOptions) <> Integer(goLineNumber in Value);
    OldOptions := FOptions;
    FOptions := Value;
    if OptLineNumber then begin
      if goLineNumber in FOptions then UpdateLineNumberWidth else ColWidths[0] := DefaultColWidth;
      InvalidateRow(0);
    end;
    if not FEditorMode then
      if goAlwaysShowEditor in Value then
        ShowEditor else
        HideEditor;
    MoveCurrent(Col, Row, True, not (goRowSelect in Value));
    if (DrawOpt * OldOptions) <> (DrawOpt * FOptions) then InvalidateGrid;
  end;
end;

procedure TXCustomGrid.SetRow(Value: Longint);
begin
  if Row <> Value then FocusCell(Col, Value, True);
end;

procedure TXCustomGrid.SetRowCount(Value: Longint);
begin
  if FRowCount <> Value then
    ChangeSize(ColCount, Value);
end;

procedure TXCustomGrid.SetRowHeights(Index: Longint; Value: Integer);
begin
  if Index >= RowCount then InvalidOp(SIndexOutOfRange);
  UpdateExtents(FRowInfos, FRowCount);
  if RowInfos[Index].CellSize <> Value then
  begin
    ResizeRow(Index, RowInfos[Index].CellSize, Value);
    if (RowInfos[Index] = FDefaultRowInfo) then
    begin
      RowInfos[Index] := FDefaultRowInfo.Duplicate;
      RowInfos[Index].CellSize := Value;
    end
    else
    begin
      RowInfos[Index].CellSize := Value;
      if RowInfos[Index].IsEqual(FDefaultRowInfo) then
      begin
        RowInfos[Index].Free;
        RowInfos[Index] := nil;
      end;
    end;
    RowHeightsChanged;
  end;
end;

procedure TXCustomGrid.SetScrollBars(Value: TScrollStyle);
begin
  if FScrollBars <> Value then
  begin
    FScrollBars := Value;
    RecreateWnd;
  end;
end;

procedure TXCustomGrid.SetSelection(Value: TXGridRect);
var
  OldSel: TXGridRect;
begin
  OldSel := Selection;
  FAnchor := Value.TopLeft;
  FCurrent := Value.BottomRight;
  SelectionMoved(OldSel);
end;

function TXCustomGrid.GetSelectCol(Index: Longint): Boolean;
begin
  Result := ColInfos[Index].Selecting;
end;

function TXCustomGrid.GetSelectRow(Index: Longint): Boolean;
begin
  Result := RowInfos[Index].Selecting;
end;

procedure TXCustomGrid.SetColSelect(Index: Longint; Value: Boolean);
begin
  if Index >= ColCount then InvalidOp(SIndexOutOfRange);
  UpdateExtents(FColInfos, ColCount);
  ResetRowSelect;
  if not (goMultiSelect in Options) then ResetColSelect;
  UpdateColSelect(Index, Value);
end;

procedure TXCustomGrid.SetRowSelect(Index: Longint; Value: Boolean);
begin
  if Index >= RowCount then InvalidOp(SIndexOutOfRange);
  UpdateExtents(FRowInfos, RowCount);
  ResetColSelect;
  if not (goMultiSelect in Options) then ResetRowSelect;
  UpdateRowSelect(Index, Value);
end;

procedure TXCustomGrid.ResetColSelect;
var
  i: Longint;
begin
  UpdateExtents(FColInfos, ColCount);
  for i := 0 to ColCount - 1 do
    UpdateColSelect(i, False);
end;

procedure TXCustomGrid.ResetRowSelect;
var
  i: Longint;
begin
  UpdateExtents(FRowInfos, RowCount);
  for i := 0 to RowCount - 1 do
    UpdateRowSelect(i, False);
end;

procedure TXCustomGrid.UpdateColSelect(Index: Longint; Value: Boolean);
begin
  if ColInfos[Index].Selecting <> Value then
  begin
    if (ColInfos[Index] = FDefaultColInfo) then
    begin
      ColInfos[Index] := FDefaultColInfo.Duplicate;
      ColInfos[Index].Selecting := Value;
    end
    else
    begin
      ColInfos[Index].Selecting := Value;
      if ColInfos[Index].IsEqual(FDefaultColInfo) then
      begin
        ColInfos[Index].Free;
        ColInfos[Index] := nil;
      end;
    end;
    if (FGridState <> gsSelectingCol) then InvalidateCol(Index);
  end;
end;

procedure TXCustomGrid.UpdateRowSelect(Index: Longint; Value: Boolean);
begin
  if RowInfos[Index].Selecting <> Value then
  begin
    if (RowInfos[Index] = FDefaultRowInfo) then
    begin
      RowInfos[Index] := FDefaultRowInfo.Duplicate;
      RowInfos[Index].Selecting := Value;
    end
    else
    begin
      RowInfos[Index].Selecting := Value;
      if RowInfos[Index].IsEqual(FDefaultRowInfo) then
      begin
        RowInfos[Index].Free;
        RowInfos[Index] := nil;
      end;
    end;
    if (FGridState <> gsSelectingRow) then InvalidateRow(Index);
  end;
end;

procedure TXCustomGrid.SetTabStops(Index: Longint; Value: Boolean);
begin
  if Index >= ColCount then InvalidOp(SIndexOutOfRange);
  UpdateExtents(FColInfos, FColCount);
  if ColInfos[Index].TabStops <> Value then
  begin
    if (ColInfos[Index] = FDefaultColInfo) then
    begin
      ColInfos[Index] := FDefaultColInfo.Duplicate;
      ColInfos[Index].TabStops := Value;
    end
    else
    begin
      ColInfos[Index].TabStops := Value;
      if ColInfos[Index].IsEqual(FDefaultColInfo) then
      begin
        ColInfos[Index].Free;
        ColInfos[Index] := nil;
      end;
    end;
  end;
end;

procedure TXCustomGrid.SetTopRow(Value: Longint);
begin
  if FTopLeft.Y <> Value then MoveTopLeft(LeftCol, Value);
end;

procedure TXCustomGrid.BeginEdit(ACol, ARow: Longint);
begin
end;

procedure TXCustomGrid.EndEdit(ACol, ARow: Longint);
begin
end;

procedure TXCustomGrid.HideEdit;
begin
  if (FInplaceEdit <> nil) and ((FInplaceCol <> -1) or (FInplaceRow <> -1)) then
  begin
    try
      UpdateText;
    finally
      EndEdit(FInplaceCol, FInplaceRow);
      FInplaceEdit.Hide;
      FInplaceCol := -1;
      FInplaceRow := -1;
    end;
  end;
end;

procedure TXCustomGrid.UpdateEdit;

  procedure UpdateEditor;
  begin
    FInplaceCol := Col;
    FInplaceRow := Row;
    FInplaceEdit.UpdateContents;
    if FInplaceEdit.MaxLength = -1 then FCanEditModify := False
    else FCanEditModify := True;
    FInplaceEdit.SelectAll;
    BeginEdit(FInplaceCol, FInplaceRow);
  end;

begin
  if CanEditShow then
  begin
    if FInplaceEdit = nil then
    begin
      FInplaceEdit := CreateEditor;
      FInplaceEdit.SetGrid(Self);
      FInplaceEdit.Parent := Self;
      UpdateEditor;
    end
    else
    begin
      if (Col <> FInplaceCol) or (Row <> FInplaceRow) then
      begin
        HideEdit;
        UpdateEditor;
      end;
    end;
    if CanEditShow then FInplaceEdit.Move(CellRect(Col, Row));
  end;
end;

procedure TXCustomGrid.UpdateText;
begin
  if (FInplaceCol <> -1) and (FInplaceRow <> -1) then
  begin
    SetEditText(FInplaceCol, FInplaceRow, FInplaceEdit.Text);
    DataChanged := True;
  end;
end;

procedure TXCustomGrid.WMChar(var Msg: TWMChar);
begin
  if (goEditing in Options) and (Char(Msg.CharCode) in [^H, #32..#255]) then
    ShowEditorChar(Char(Msg.CharCode))
  else
    inherited;
end;

procedure TXCustomGrid.WMCommand(var Message: TWMCommand);
begin
  with Message do
  begin
    if (FInplaceEdit <> nil) and (Ctl = FInplaceEdit.Handle) then
      case NotifyCode of
        EN_CHANGE: UpdateText;
      end;
  end;
end;

procedure TXCustomGrid.WMEraseBkgnd(var Message: TWMEraseBkgnd);
begin
  Message.Result := 1;
end;

procedure TXCustomGrid.WMGetDlgCode(var Msg: TWMGetDlgCode);
begin
  Msg.Result := DLGC_WANTARROWS;
  if goRowSelect in Options then Exit;
  if goTabs in Options then Msg.Result := Msg.Result or DLGC_WANTTAB;
  if goEditing in Options then Msg.Result := Msg.Result or DLGC_WANTCHARS;
end;

procedure TXCustomGrid.WMKillFocus(var Msg: TWMKillFocus);
begin
  inherited;
  InvalidateRect(Selection);
//  if (FInplaceEdit <> nil) and (Msg.FocusedWnd <> FInplaceEdit.Handle) then
//    HideEdit;
end;

procedure TXCustomGrid.WMLButtonDown(var Message: TMessage);
begin
  inherited;
  if FInplaceEdit <> nil then FInplaceEdit.FClickTime := GetMessageTime;
end;

procedure TXCustomGrid.WMNCHitTest(var Msg: TWMNCHitTest);
begin
  DefaultHandler(Msg);
  FHitTest := SmallPointToPoint(Msg.Pos);
end;

procedure TXCustomGrid.UpdateLineNumberWidth;   (* 追加 1996/06/26 *)
var
  i: Integer;
begin
  if (goLineNumber in FOptions) and HandleAllocated then begin
    i := Canvas.TextWidth(IntToStr(VisibleRowCount + TopRow - FixedRows + 1)) + 4;
    if (i < FDefaultLineNumberWidth) then i := FDefaultLineNumberWidth;
    ColWidths[0] := i;
  end;
end;

procedure TXCustomGrid.WMSetCursor(var Msg: TWMSetCursor);
var
  FixedInfo: TXGridDrawInfo;
  State: TXGridState;
  Index: Longint;
  Pos, Ofs: Integer;
  Cur: HCURSOR;
begin
  Cur := 0;
  with Msg do
  begin
    if HitTest = HTCLIENT then
    begin
      if FGridState = gsNormal then
      begin
        FHitTest := ScreenToClient(FHitTest);
        CalcFixedInfo(FixedInfo);
        CalcSizingState(FHitTest.X, FHitTest.Y, State, Index, Pos, Ofs,
          FixedInfo);
      end else State := FGridState;
      if State = gsRowSizing then
        Cur := Screen.Cursors[crVSplit]
      else if State = gsColSizing then
        Cur := Screen.Cursors[crHSplit]
    end;
  end;
  if Cur <> 0 then SetCursor(Cur)
  else inherited;
end;

procedure TXCustomGrid.WMSetFocus(var Msg: TWMSetFocus);
begin
  inherited;
  if (FInplaceEdit = nil) or (Msg.FocusedWnd <> FInplaceEdit.Handle) then
  begin
    InvalidateRect(Selection);
    UpdateEdit;
  end;
end;

procedure TXCustomGrid.WMSize(var Msg: TWMSize);
begin
  if FOffScreenDrawing then begin
    FBitmap.Width  := Msg.Width;
    FBitmap.Height := Msg.Height;
  end;
  inherited;
  UpdateLineNumberWidth;   (* 追加 1996/06/26 *)
  UpdateScrollRange;
end;

procedure TXCustomGrid.WMVScroll(var Msg: TWMVScroll);
begin
  ModifyScrollBar(SB_VERT, Msg.ScrollCode, Msg.Pos);
end;

procedure TXCustomGrid.WMHScroll(var Msg: TWMHScroll);
begin
  ModifyScrollBar(SB_HORZ, Msg.ScrollCode, Msg.Pos);
end;

procedure TXCustomGrid.CMCancelMode(var Msg: TMessage);
begin
  if Assigned(FInplaceEdit) then FInplaceEdit.WndProc(Msg);
  inherited;
end;

procedure TXCustomGrid.CMFontChanged(var Message: TMessage);
begin
  if not ((csDesigning in ComponentState) and (csLoading in ComponentState))
    then UpdateDefaultRowHeight;
  if FInplaceEdit <> nil then FInplaceEdit.Font := Font;
  inherited;
end;

procedure TXCustomGrid.CMCtl3DChanged(var Message: TMessage);
begin
  inherited;
  RecreateWnd;
end;

procedure TXCustomGrid.CMDesignHitTest(var Msg: TCMDesignHitTest);
begin
  Msg.Result := Longint(BOOL(Sizing(Msg.Pos.X, Msg.Pos.Y)));
end;

procedure TXCustomGrid.CMWantSpecialKey(var Msg: TCMWantSpecialKey);
begin
  inherited;
  if (goEditing in Options) and (Char(Msg.CharCode) = #13) then Msg.Result := 1;
end;

procedure TXCustomGrid.TimedScroll(Direction: TXGridScrollDirection);
var
  MaxAnchor, NewAnchor: TXGridCoord;
begin
  NewAnchor := FAnchor;
  MaxAnchor.X := ColCount - 1;
  MaxAnchor.Y := RowCount - 1;
  if (sdLeft in Direction) and (FAnchor.X > FixedCols) then Dec(NewAnchor.X);
  if (sdRight in Direction) and (FAnchor.X < MaxAnchor.X) then Inc(NewAnchor.X);
  if (sdUp in Direction) and (FAnchor.Y > FixedRows) then Dec(NewAnchor.Y);
  if (sdDown in Direction) and (FAnchor.Y < MaxAnchor.Y) then Inc(NewAnchor.Y);
  if (FAnchor.X <> NewAnchor.X) or (FAnchor.Y <> NewAnchor.Y) then
    MoveAnchor(NewAnchor);
end;

procedure TXCustomGrid.WMTimer(var Msg: TWMTimer);
var
  Point: TPoint;
  DrawInfo: TXGridDrawInfo;
  ScrollDirection: TXGridScrollDirection;
  CellHit: TXGridCoord;
begin
  if not (FGridState in [gsSelecting, gsRowMoving, gsColMoving, gsSelectingCol, gsSelectingRow]) then Exit;
  GetCursorPos(Point);
  Point := ScreenToClient(Point);
  CalcDrawInfo(DrawInfo);
  ScrollDirection := [];
  with DrawInfo do
  begin
    CellHit := CalcCoordFromPoint(Point.X, Point.Y, DrawInfo);
    case FGridState of
      gsColMoving:
        MoveAndScroll(Point.X, CellHit.X, DrawInfo, Horz, SB_HORZ);
      gsRowMoving:
        MoveAndScroll(Point.Y, CellHit.Y, DrawInfo, Vert, SB_VERT);
      gsSelecting:
      begin
        if Point.X < Horz.FixedBoundary        then Include(ScrollDirection, sdLeft)
        else if Point.X > Horz.FullVisBoundary then Include(ScrollDirection, sdRight);
        if Point.Y < Vert.FixedBoundary        then Include(ScrollDirection, sdUp)
        else if Point.Y > Vert.FullVisBoundary then Include(ScrollDirection, sdDown);
        if ScrollDirection <> [] then TimedScroll(ScrollDirection);
      end;
      gsSelectingCol:
      begin
        if Point.X < Horz.FixedBoundary        then
        begin
          ModifyScrollBar(SB_HORZ, SB_LINEUP  , 0);
          MouseMove([], Horz.FixedBoundary, Point.Y);
        end
        else if Point.X > Horz.FullVisBoundary then
        begin
          ModifyScrollBar(SB_HORZ, SB_LINEDOWN, 0);
          MouseMove([], Horz.FullVisBoundary, Point.Y);
        end;
      end;
      gsSelectingRow:
      begin
        if Point.Y < Vert.FixedBoundary        then
        begin
          ModifyScrollBar(SB_VERT, SB_LINEUP  , 0);
          MouseMove([], Point.X, Vert.FixedBoundary);
        end
        else if Point.Y > Vert.FullVisBoundary then
        begin
          ModifyScrollBar(SB_VERT, SB_LINEDOWN, 0);
          MouseMove([], Point.X, Vert.FullVisBoundary);
        end;
      end;
    end;
  end;
end;

procedure TXCustomGrid.ColWidthsChanged;
begin
  UpdateScrollRange;
  UpdateEdit;
end;

procedure TXCustomGrid.RowHeightsChanged;
begin
  UpdateScrollRange;
  UpdateEdit;
end;

procedure TXCustomGrid.DeleteColumn(ACol: Longint);
begin
  MoveColumn(ACol, ColCount-1);
  ColCount := ColCount - 1;
end;

procedure TXCustomGrid.DeleteRow(ARow: Longint);
begin
  MoveRow(ARow, RowCount - 1);
  RowCount := RowCount - 1;
end;

procedure TXCustomGrid.UpdateDesigner;
var
{$IFDEF VER90}
  ParentForm: TForm;
{$ELSE}
  ParentForm: TCustomForm;
{$ENDIF}
begin
  if (csDesigning in ComponentState) and HandleAllocated and
    not (csUpdating in ComponentState) then
  begin
    ParentForm := GetParentForm(Self);
    if Assigned(ParentForm) and Assigned(ParentForm.Designer) then
      ParentForm.Designer.Modified;
  end;
end;

function TXCustomGrid.MouseToCell(X, Y: Integer; var ACol, ARow: Longint): Boolean;
var
  Coord: TXGridCoord;
begin
  Coord  := MouseCoord(X, Y);
  ACol   := Coord.X;
  ARow   := Coord.Y;
  Result := (X < GridWidth) and (Y < GridHeight);  (* 関数型に変更 *)
end;

{ TXDrawGrid }

(* Add matsu 1997-04-19 *)
constructor TXDrawGrid.Create(AOwner:TComponent);
begin
  { 派生元呼び出し }
  inherited Create(AOwner);
  FVersion := HGridVersion;
end;

destructor  TXDrawGrid.Destroy;
begin
  inherited Destroy;
end;
(* Add End *)

procedure TXDrawGrid.ColumnMoved(FromIndex, ToIndex: Longint);
begin
  if Assigned(FOnColumnMoved) then FOnColumnMoved(Self, FromIndex, ToIndex);
end;

function TXDrawGrid.GetEditMask(ACol, ARow: Longint): string;
begin
  Result := '';
  if Assigned(FOnGetEditMask) then FOnGetEditMask(Self, ACol, ARow, Result);
end;

function TXDrawGrid.GetEditText(ACol, ARow: Longint): string;
begin
  Result := '';
  if Assigned(FOnGetEditText) then FOnGetEditText(Self, ACol, ARow, Result);
end;

procedure TXDrawGrid.RowMoved(FromIndex, ToIndex: Longint);
begin
  if Assigned(FOnRowMoved) then FOnRowMoved(Self, FromIndex, ToIndex);
end;

function TXDrawGrid.SelectCell(ACol, ARow: Longint): Boolean;
begin
  Result := True;
  if Assigned(FOnSelectCell) then FOnSelectCell(Self, ACol, ARow, Result);
end;

procedure TXDrawGrid.CurrentChanged;
begin
  if Assigned(FOnCurrentChanged) then FOnCurrentChanged(Self);
end;

procedure TXDrawGrid.SetEditText(ACol, ARow: Longint; const Value: string);
begin
  if Assigned(FOnSetEditText) then FOnSetEditText(Self, ACol, ARow, Value);
end;

procedure TXDrawGrid.DrawCell(ACol, ARow: Longint; ARect: TRect;
  AState: TXGridDrawState);
begin
  if Assigned(FOnDrawCell) then FOnDrawCell(Self, ACol, ARow, ARect, AState);
end;

procedure TXDrawGrid.TopLeftChanged;
begin
  inherited TopLeftChanged;
  if Assigned(FOnTopLeftChanged) then FOnTopLeftChanged(Self);
end;

procedure TXDrawGrid.BeginEdit(ACol, ARow: Longint); (* 追加 *)
begin
  if Assigned(FOnBeginEdit) then FOnBeginEdit(Self, ACol, ARow);
end;

procedure TXDrawGrid.EndEdit(ACol, ARow: Longint);   (* 追加 *)
begin
  if Assigned(FOnEndEdit) then FOnEndEdit(Self, ACol, ARow);
end;

{ StrItem management for TStringSparseList }

type
  PStrItem = ^TStrItem;
  TStrItem = record
    FObject: TObject;
    FString: string;
  end;

//
//一行上にスクロールする。
//
procedure TXDrawGrid.LineUp;
begin
  SendMessage( Handle, WM_VSCROLL,  SB_LINEUP  , 0 );
  if Row > FixedRows then Row := Row -1 ;
end;

//
//一行下にスクロールする。
//
procedure TXDrawGrid.LineDown;
begin
  SendMessage( Handle, WM_VSCROLL,  SB_LINEDOWN  , 0 );
  if Row < RowCount -1  then Row := Row + 1 ;
end;

//
//1ページ上にスクロールする。
//
procedure TXDrawGrid.PageUp;
begin
  SendMessage( Handle, WM_VSCROLL,  SB_PAGEUP  , 0 );
  Row := TopRow ;
end;

//
//１ページ下にスクロールする。
//
procedure TXDrawGrid.PageDown;
begin
  SendMessage( Handle, WM_VSCROLL,  SB_PAGEDOWN  , 0 );
  Row := TopRow ;
end;



function NewStrItem(const AString: string; AObject: TObject): PStrItem;
begin
  New(Result);
  Result^.FObject := AObject;
  Result^.FString := AString;
end;

procedure DisposeStrItem(P: PStrItem);
begin
  Dispose(P);
end;

{ Sparse array classes for THStringGrid }

type

  PPointer = ^Pointer;

{ Exception classes }

  EStringSparseListError = class(Exception);

{ TSparsePointerArray class}

{ Used by TSparseList.  Based on Sparse1Array, but has Pointer elements
  and Integer index, just like TPointerList/TList, and less indirection }

  { Apply function for the applicator:
        TheIndex        Index of item in array
        TheItem         Value of item (i.e pointer element) in section
        Returns: 0 if success, else error code. }
  TSPAApply = function(TheIndex: Integer; TheItem: Pointer): Integer;

  TSecDir = array[0..4095] of Pointer;  { Enough for up to 12 bits of sec }
  PSecDir = ^TSecDir;
  TSPAQuantum = (SPASmall, SPALarge);   { Section size }

  TSparsePointerArray = class(TObject)
  private
    secDir: PSecDir;
    slotsInDir: Word;
    indexMask, secShift: Word;
    FHighBound: Integer;
    FSectionSize: Word;
    cachedIndex: Integer;
    cachedPointer: Pointer;
    { Return item[i], nil if slot outside defined section. }
    function  GetAt(Index: Integer): Pointer;
    { Return address of item[i], creating slot if necessary. }
    function  MakeAt(Index: Integer): PPointer;
    { Store item at item[i], creating slot if necessary. }
    procedure PutAt(Index: Integer; Item: Pointer);
  public
    constructor Create(Quantum: TSPAQuantum);
    destructor  Destroy; override;

    { Traverse SPA, calling apply function for each defined non-nil
      item.  The traversal terminates if the apply function returns
      a value other than 0. }
    { NOTE: must be static method so that we can take its address in
      TSparseList.ForAll }
    function  ForAll(ApplyFunction: Pointer {TSPAApply}): Integer;

    { Ratchet down HighBound after a deletion }
    procedure ResetHighBound;

    property HighBound: Integer read FHighBound;
    property SectionSize: Word read FSectionSize;
    property Items[Index: Integer]: Pointer read GetAt write PutAt; default;
  end;

{ TSparseList class }

  TSparseList = class(TObject)
  private
    FList: TSparsePointerArray;
    FCount: Integer;    { 1 + HighBound, adjusted for Insert/Delete }
    FQuantum: TSPAQuantum;
    procedure NewList(Quantum: TSPAQuantum);
  protected
    procedure Error; virtual;
    function  Get(Index: Integer): Pointer;
    procedure Put(Index: Integer; Item: Pointer);
  public
    constructor Create(Quantum: TSPAQuantum);
    destructor  Destroy; override;
    function  Add(Item: Pointer): Integer;
    procedure Clear;
    procedure Delete(Index: Integer);
    procedure Exchange(Index1, Index2: Integer);
    function First: Pointer;
    function ForAll(ApplyFunction: Pointer {TSPAApply}): Integer;
    function IndexOf(Item: Pointer): Integer;
    procedure Insert(Index: Integer; Item: Pointer);
    function Last: Pointer;
    procedure Move(CurIndex, NewIndex: Integer);
    procedure Pack;
    function Remove(Item: Pointer): Integer;
    property Count: Integer read FCount;
    property Items[Index: Integer]: Pointer read Get write Put; default;
  end;

{ TStringSparseList class }

  TStringSparseList = class(TStrings)
  private
    FList: TSparseList;                 { of StrItems }
    FOnChange: TNotifyEvent;
  protected
    function  Get(Index: Integer): String; override;
    function  GetCount: Integer; override;
    function  GetObject(Index: Integer): TObject; override;
    procedure Put(Index: Integer; const S: String); override;
    procedure PutObject(Index: Integer; AObject: TObject); override;
    procedure Changed; virtual;
    procedure Error; virtual;
  public
    constructor Create(Quantum: TSPAQuantum);
    destructor  Destroy; override;
    procedure ReadData(Reader: TReader);
    procedure WriteData(Writer: TWriter);
    procedure DefineProperties(Filer: TFiler); override;
    procedure Delete(Index: Integer); override;
    procedure Exchange(Index1, Index2: Integer); override;
    procedure Insert(Index: Integer; const S: String); override;
    procedure Clear; override;
    property List: TSparseList read FList;
    property OnChange: TNotifyEvent read FOnChange write FOnChange;
  end;

{ TSparsePointerArray }

const
  SPAIndexMask: array[TSPAQuantum] of Byte = (15, 255);
  SPASecShift: array[TSPAQuantum] of Byte = (4, 8);

{ Expand Section Directory to cover at least `newSlots' slots. Returns: Possibly
  updated pointer to the Section Directory. }
function  ExpandDir(secDir: PSecDir; var slotsInDir: Word;
  newSlots: Word): PSecDir;
begin
  Result := secDir;
  ReallocMem(Result, newSlots * SizeOf(Pointer));
  FillChar(Result^[slotsInDir], (newSlots - slotsInDir) * SizeOf(Pointer), 0);
  slotsInDir := newSlots;
end;

{ Allocate a section and set all its items to nil. Returns: Pointer to start of
  section. }
function  MakeSec(SecIndex: Integer; SectionSize: Word): Pointer;
var
  SecP: Pointer;
  Size: Word;
begin
  Size := SectionSize * SizeOf(Pointer);
  GetMem(secP, size);
  FillChar(secP^, size, 0);
  MakeSec := SecP
end;

constructor TSparsePointerArray.Create(Quantum: TSPAQuantum);
begin
  SecDir := nil;
  SlotsInDir := 0;
  FHighBound := -1;
  FSectionSize := Word(SPAIndexMask[Quantum]) + 1;
  IndexMask := Word(SPAIndexMask[Quantum]);
  SecShift := Word(SPASecShift[Quantum]);
  CachedIndex := -1
end;

destructor TSparsePointerArray.Destroy;
var
  i:  Integer;
  size: Word;
begin
  { Scan section directory and free each section that exists. }
  i := 0;
  size := FSectionSize * SizeOf(Pointer);
  while i < slotsInDir do begin
    if secDir^[i] <> nil then
      FreeMem(secDir^[i], size);
    Inc(i)
  end;

  { Free section directory. }
  if secDir <> nil then
    FreeMem(secDir, slotsInDir * SizeOf(Pointer));
end;

function  TSparsePointerArray.GetAt(Index: Integer): Pointer;
var
  //20091007 23011 noguchi PChar→PAnsiCharへ変更
  //byteP: PChar;
  byteP: PAnsiChar;
  secIndex: Cardinal;
begin
  { Index into Section Directory using high order part of
    index.  Get pointer to Section. If not null, index into
    Section using low order part of index. }
  if Index = cachedIndex then
    Result := cachedPointer
  else begin
    secIndex := Index shr secShift;
    if secIndex >= slotsInDir then
      byteP := nil
    else begin
      byteP := secDir^[secIndex];
      if byteP <> nil then begin
        Inc(byteP, (Index and indexMask) * SizeOf(Pointer));
      end
    end;
    if byteP = nil then Result := nil else Result := PPointer(byteP)^;
    cachedIndex := Index;
    cachedPointer := Result
  end
end;

function  TSparsePointerArray.MakeAt(Index: Integer): PPointer;
var
  dirP: PSecDir;
  p: Pointer;
  //20091007 23011 noguchi PChar→PAnsiCharへ変更
  //byteP: PChar;
  byteP: PAnsiChar;
  secIndex: Word;
begin
  { Expand Section Directory if necessary. }
  secIndex := Index shr secShift;       { Unsigned shift }
  if secIndex >= slotsInDir then
    dirP := expandDir(secDir, slotsInDir, secIndex + 1)
  else
    dirP := secDir;

  { Index into Section Directory using high order part of
    index.  Get pointer to Section. If null, create new
    Section.  Index into Section using low order part of index. }
  secDir := dirP;
  p := dirP^[secIndex];
  if p = nil then begin
    p := makeSec(secIndex, FSectionSize);
    dirP^[secIndex] := p
  end;
  byteP := p;
  Inc(byteP, (Index and indexMask) * SizeOf(Pointer));
  if Index > FHighBound then
    FHighBound := Index;
  Result := PPointer(byteP);
  cachedIndex := -1
end;

procedure TSparsePointerArray.PutAt(Index: Integer; Item: Pointer);
begin
  if (Item <> nil) or (GetAt(Index) <> nil) then
  begin
    MakeAt(Index)^ := Item;
    if Item = nil then
      ResetHighBound
  end
end;

function  TSparsePointerArray.ForAll(ApplyFunction: Pointer {TSPAApply}):
  Integer;
var
  //20091007 23011 noguchi PChar→PAnsiCharへ変更
  //itemP: PChar;                         { Pointer to item in section }
  itemP: PAnsiChar;                         { Pointer to item in section }

  item: Pointer;
  i, callerBP: Cardinal;
  j, index: Integer;
begin
  { Scan section directory and scan each section that exists,
    calling the apply function for each non-nil item.
    The apply function must be a far local function in the scope of
    the procedure P calling ForAll.  The trick of setting up the stack
    frame (taken from TurboVision's TCollection.ForEach) allows the
    apply function access to P's arguments and local variables and,
    if P is a method, the instance variables and methods of P's class }
  Result := 0;
  i := 0;
  asm
    mov   eax,[ebp]                     { Set up stack frame for local }
    mov   callerBP,eax
  end;
  while (i < slotsInDir) and (Result = 0) do begin
    itemP := secDir^[i];
    if itemP <> nil then begin
      j := 0;
      index := i shl SecShift;
      while (j < FSectionSize) and (Result = 0) do begin
        item := PPointer(itemP)^;
        if item <> nil then
          { ret := ApplyFunction(index, item.Ptr); }
          asm
            mov   eax,index
            mov   edx,item
            push  callerBP
            call  ApplyFunction
            pop   ecx
            mov   @Result,eax
          end;
        Inc(itemP, SizeOf(Pointer));
        Inc(j);
        Inc(index)
      end
    end;
    Inc(i)
  end;
end;

procedure TSparsePointerArray.ResetHighBound;
var
  NewHighBound: Integer;

  function  Detector(TheIndex: Integer; TheItem: Pointer): Integer; far;
  begin
    if TheIndex > FHighBound then
      Result := 1
    else
    begin
      Result := 0;
      if TheItem <> nil then NewHighBound := TheIndex
    end
  end;

begin
  NewHighBound := -1;
  ForAll(@Detector);
  FHighBound := NewHighBound
end;

{ TSparseList }

constructor TSparseList.Create(Quantum: TSPAQuantum);
begin
  NewList(Quantum)
end;

destructor TSparseList.Destroy;
begin
  if FList <> nil then FList.Destroy
end;

function  TSparseList.Add(Item: Pointer): Integer;
begin
  Result := FCount;
  FList[Result] := Item;
  Inc(FCount)
end;

procedure TSparseList.Clear;
begin
  FList.Destroy;
  NewList(FQuantum);
  FCount := 0
end;

procedure TSparseList.Delete(Index: Integer);
var
  I: Integer;
begin
  if (Index < 0) or (Index >= FCount) then Exit;
  for I := Index to FCount - 1 do
    FList[I] := FList[I + 1];
  FList[FCount] := nil;
  Dec(FCount);
end;

procedure TSparseList.Error;
begin
{$IFDEF VER90}
  raise EListError.CreateRes(SListIndexError);
{$ELSE}
  //raise EListError.Create(SListIndexError);
{$ENDIF}
end;

procedure TSparseList.Exchange(Index1, Index2: Integer);
var
  temp: Pointer;
begin
  temp := Get(Index1);
  Put(Index1, Get(Index2));
  Put(Index2, temp);
end;

function  TSparseList.First: Pointer;
begin
  Result := Get(0)
end;

{ Jump to TSparsePointerArray.ForAll so that it looks like it was called
  from our caller, so that the BP trick works. }

function TSparseList.ForAll(ApplyFunction: Pointer {TSPAApply}): Integer; assembler;
asm
        MOV     EAX,[EAX].TSparseList.FList
        JMP     TSparsePointerArray.ForAll
end;

function  TSparseList.Get(Index: Integer): Pointer;
begin
  if Index < 0 then Error;
  Result := FList[Index]
end;

function  TSparseList.IndexOf(Item: Pointer): Integer;
var
  MaxIndex, Index: Integer;

  function  IsTheItem(TheIndex: Integer; TheItem: Pointer): Integer; far;
  begin
    if TheIndex > MaxIndex then
      Result := -1                      { Bail out }
    else if TheItem <> Item then
      Result := 0
    else begin
      Result := 1;                      { Found it, stop traversal }
      Index := TheIndex
    end
  end;

begin
  Index := -1;
  MaxIndex := FList.HighBound;
  FList.ForAll(@IsTheItem);
  Result := Index
end;

procedure TSparseList.Insert(Index: Integer; Item: Pointer);
var
  i: Integer;
begin
  if Index < 0 then Error;
  I := FCount;
  while I > Index do
  begin
    FList[i] := FList[i - 1];
    Dec(i)
  end;
  FList[Index] := Item;
  if Index > FCount then FCount := Index;
  Inc(FCount)
end;

function  TSparseList.Last: Pointer;
begin
  Result := Get(FCount - 1);
end;

procedure TSparseList.Move(CurIndex, NewIndex: Integer);
var
  Item: Pointer;
begin
  if CurIndex <> NewIndex then
  begin
    Item := Get(CurIndex);
    Delete(CurIndex);
    Insert(NewIndex, Item);
  end;
end;

procedure TSparseList.NewList(Quantum: TSPAQuantum);
begin
  FQuantum := Quantum;
  FList := TSparsePointerArray.Create(Quantum)
end;

procedure TSparseList.Pack;
var
  i: Integer;
begin
  for i := FCount - 1 downto 0 do if Items[i] = nil then Delete(i)
end;

procedure TSparseList.Put(Index: Integer; Item: Pointer);
begin
  if Index < 0 then Error;
  FList[Index] := Item;
  FCount := FList.HighBound + 1
end;

function  TSparseList.Remove(Item: Pointer): Integer;
begin
  Result := IndexOf(Item);
  if Result <> -1 then Delete(Result)
end;

{ TStringSparseList }

constructor TStringSparseList.Create(Quantum: TSPAQuantum);
begin
  FList := TSparseList.Create(Quantum)
end;

destructor  TStringSparseList.Destroy;
begin
  if FList <> nil then begin
    Clear;
    FList.Destroy
  end
end;

procedure TStringSparseList.ReadData(Reader: TReader);
var
  i: Integer;
begin
  with Reader do begin
    i := Integer(ReadInteger);
    while i > 0 do begin
      InsertObject(Integer(ReadInteger), ReadString, nil);
      Dec(i)
    end
  end
end;

procedure TStringSparseList.WriteData(Writer: TWriter);
var
  itemCount: Integer;

  function  CountItem(TheIndex: Integer; TheItem: Pointer): Integer; far;
  begin
    Inc(itemCount);
    Result := 0
  end;

  function  StoreItem(TheIndex: Integer; TheItem: Pointer): Integer; far;
  begin
    with Writer do
    begin
      WriteInteger(TheIndex);           { Item index }
      WriteString(PStrItem(TheItem)^.FString);
    end;
    Result := 0
  end;

begin
  with Writer do
  begin
    itemCount := 0;
    FList.ForAll(@CountItem);
    WriteInteger(itemCount);
    FList.ForAll(@StoreItem);
  end
end;

procedure TStringSparseList.DefineProperties(Filer: TFiler);
begin
  Filer.DefineProperty('List', ReadData, WriteData, True);
end;

function  TStringSparseList.Get(Index: Integer): String;
var
  p: PStrItem;
begin
  p := PStrItem(FList[Index]);
  if p = nil then Result := '' else Result := p^.FString
end;

function  TStringSparseList.GetCount: Integer;
begin
  Result := FList.Count
end;

function  TStringSparseList.GetObject(Index: Integer): TObject;
var
  p: PStrItem;
begin
  p := PStrItem(FList[Index]);
  if p = nil then Result := nil else Result := p^.FObject
end;

procedure TStringSparseList.Put(Index: Integer; const S: String);
var
  p: PStrItem;
  obj: TObject;
begin
  p := PStrItem(FList[Index]);
  if p = nil then obj := nil else obj := p^.FObject;
  if (S = '') and (obj = nil) then   { Nothing left to store }
    FList[Index] := nil
  else
    FList[Index] := NewStrItem(S, obj);
  if p <> nil then DisposeStrItem(p);
  Changed
end;

procedure TStringSparseList.PutObject(Index: Integer; AObject: TObject);
var
  p: PStrItem;
begin
  p := PStrItem(FList[Index]);
  if p <> nil then
    p^.FObject := AObject
  else if AObject <> nil then
    Error;
  Changed
end;

procedure TStringSparseList.Changed;
begin
  if Assigned(FOnChange) then FOnChange(Self)
end;

procedure TStringSparseList.Error;
begin
{$IFDEF VER90}
  raise EStringSparseListError.CreateRes(SPutObjectError);
{$ELSE}
  raise EStringSparseListError.Create(SPutObjectError);
{$ENDIF}
end;

procedure TStringSparseList.Delete(Index: Integer);
var
  p: PStrItem;
begin
  p := PStrItem(FList[Index]);
  if p <> nil then DisposeStrItem(p);
  FList.Delete(Index);
  Changed
end;

procedure TStringSparseList.Exchange(Index1, Index2: Integer);
begin
  FList.Exchange(Index1, Index2);
end;

procedure TStringSparseList.Insert(Index: Integer; const S: String);
begin
  FList.Insert(Index, NewStrItem(S, nil));
  Changed
end;

procedure TStringSparseList.Clear;

  function  ClearItem(TheIndex: Integer; TheItem: Pointer): Integer; far;
  begin
    DisposeStrItem(PStrItem(TheItem));    { Item guaranteed non-nil }
    Result := 0
  end;

begin
  FList.ForAll(@ClearItem);
  FList.Clear;
  Changed
end;

{ THStringGridStrings }

{ AIndex < 0 is a column (for column -AIndex - 1)
  AIndex > 0 is a row (for row AIndex - 1)
  AIndex = 0 denotes an empty row or column }

constructor THStringGridStrings.Create(AGrid: THStringGrid; AIndex: Longint);
begin
  inherited Create;
  FGrid := AGrid;
  FIndex := AIndex;
end;

procedure THStringGridStrings.Assign(Source: TPersistent);
var
  I, Max: Integer;
begin
  if Source is TStrings then
  begin
    BeginUpdate;
    Max := TStrings(Source).Count - 1;
    if Max >= Count then Max := Count - 1;
    try
      for I := 0 to Max do
      begin
        Put(I, TStrings(Source).Strings[I]);
        PutObject(I, TStrings(Source).Objects[I]);
      end;
    finally
      EndUpdate;
    end;
    Exit;
  end;
  inherited Assign(Source);
end;

procedure THStringGridStrings.CalcXY(Index: Integer; var X, Y: Integer);
begin
  if FIndex = 0 then
  begin
    X := -1; Y := -1;
  end else if FIndex > 0 then
  begin
    X := Index;
    Y := FIndex - 1;
  end else
  begin
    X := -FIndex - 1;
    Y := Index;
  end;
end;

{ Changes the meaning of Add to mean copy to the first empty string }
function THStringGridStrings.Add(const S: string): Integer;
var
  I: Integer;
begin
  for I := 0 to Count - 1 do
    if Strings[I] = '' then
    begin
      Strings[I] := S;
      Result := I;
      Exit;
    end;
  Result := -1;
end;

procedure THStringGridStrings.Clear;
var
  SSList: TStringSparseList;
  I: Integer;

  function BlankStr(TheIndex: Integer; TheItem: Pointer): Integer; far;
  begin
    Objects[TheIndex] := nil;
    Strings[TheIndex] := '';
    Result := 0;
  end;

begin
  if FIndex > 0 then
  begin
    SSList := TStringSparseList(TSparseList(FGrid.FData)[FIndex - 1]);
    if SSList <> nil then SSList.List.ForAll(@BlankStr);
  end
  else if FIndex < 0 then
    for I := Count - 1 downto 0 do
    begin
      Objects[I] := nil;
      Strings[I] := '';
    end;
end;

function THStringGridStrings.Get(Index: Integer): string;
var
  X, Y: Integer;
begin
  CalcXY(Index, X, Y);
  if X < 0 then Result := '' else Result := FGrid.Cells[X, Y];
end;

function THStringGridStrings.GetCount: Integer;
begin
  { Count of a row is the column count, and vice versa }
  if FIndex = 0 then Result := 0
  else if FIndex > 0 then Result := Integer(FGrid.ColCount)
  else Result := Integer(FGrid.RowCount);
end;

function THStringGridStrings.GetObject(Index: Integer): TObject;
var
  X, Y: Integer;
begin
  CalcXY(Index, X, Y);
  if X < 0 then Result := nil else Result := FGrid.Objects[X, Y];
end;

procedure THStringGridStrings.Put(Index: Integer; const S: string);
var
  X, Y: Integer;
begin
  CalcXY(Index, X, Y);
  FGrid.Cells[X, Y] := S;
end;

procedure THStringGridStrings.PutObject(Index: Integer; AObject: TObject);
var
  X, Y: Integer;
begin
  CalcXY(Index, X, Y);
  FGrid.Objects[X, Y] := AObject;
end;

procedure THStringGridStrings.SetUpdateState(Updating: Boolean);
begin
  FGrid.SetUpdateState(Updating);
end;

{ THStringGrid }

constructor THStringGrid.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);

  Initialize;
(* Add matsu 1997-04-19 *)
  FVersion := HGridVersion;
(* Add End *)
end;

destructor THStringGrid.Destroy;
  function FreeItem(TheIndex: Integer; TheItem: Pointer): Integer; far;
  begin
    TObject(TheItem).Free;
    Result := 0;
  end;

begin
  if FRows <> nil then
  begin
    TSparseList(FRows).ForAll(@FreeItem);
    TSparseList(FRows).Free;
  end;
  if FCols <> nil then
  begin
    TSparseList(FCols).ForAll(@FreeItem);
    TSparseList(FCols).Free;
  end;
  if FData <> nil then
  begin
    TSparseList(FData).ForAll(@FreeItem);
    TSparseList(FData).Free;
  end;
  inherited Destroy;
end;

procedure THStringGrid.ColumnMoved(FromIndex, ToIndex: Longint);

  function MoveColData(Index: Integer; ARow: TStringSparseList): Integer; far;
  begin
    ARow.Move(FromIndex, ToIndex);
    Result := 0;
  end;

begin
  TSparseList(FData).ForAll(@MoveColData);
  Invalidate;
  inherited ColumnMoved(FromIndex, ToIndex);
end;

procedure THStringGrid.RowMoved(FromIndex, ToIndex: Longint);
begin
  TSparseList(FData).Move(FromIndex, ToIndex);
  Invalidate;
  inherited RowMoved(FromIndex, ToIndex);
end;

function THStringGrid.GetEditText(ACol, ARow: Longint): string;
begin
  Result := Cells[ACol, ARow];
  if Assigned(FOnGetEditText) then FOnGetEditText(Self, ACol, ARow, Result);
end;

procedure THStringGrid.SetEditText(ACol, ARow: Longint; const Value: string);
begin
  DisableEditUpdate;
  try
    if Value <> Cells[ACol, ARow] then Cells[ACol, ARow] := Value;
  finally
    EnableEditUpdate;
  end;
(* Add FIT T.S 1997-05-28 *)
  inherited SetEditText(ACol, ARow, Value);
(* AddEnd *)
end;

procedure THStringGrid.DrawCell(ACol, ARow: Longint; ARect: TRect;
  AState: TXGridDrawState);
begin
  if DefaultDrawing then DrawCellText(ARect, Cells[ACol, ARow], gtLeft);
  inherited DrawCell(ACol, ARow, ARect, AState);
end;

procedure THStringGrid.DisableEditUpdate;
begin
  Inc(FEditUpdate);
end;

procedure THStringGrid.EnableEditUpdate;
begin
  Dec(FEditUpdate);
end;

procedure THStringGrid.Initialize;
var
  quantum: TSPAQuantum;
begin
  if FCols = nil then
  begin
    if ColCount > 512 then quantum := SPALarge else quantum := SPASmall;
    FCols := TSparseList.Create(quantum);
  end;
  if RowCount > 256 then quantum := SPALarge else quantum := SPASmall;
  if FRows = nil then FRows := TSparseList.Create(quantum);
  if FData = nil then FData := TSparseList.Create(quantum);
end;

procedure THStringGrid.SetUpdateState(Updating: Boolean);
begin
  FUpdating := Updating;
  if not Updating and FNeedsUpdating then
  begin
    InvalidateGrid;
    FNeedsUpdating := False;
  end;
end;

procedure THStringGrid.CellUpdate(ACol, ARow: Integer);
begin
  if not FUpdating then InvalidateCell(ACol, ARow)
  else FNeedsUpdating := True;
  if (ACol = Col) and (ARow = Row) and (FEditUpdate = 0) then InvalidateEditor;
end;

function  THStringGrid.EnsureColRow(Index: Integer; IsCol: Boolean):
  THStringGridStrings;
var
  RCIndex: Integer;
  PList: ^TSparseList;
begin
  if IsCol then PList := @FCols else PList := @FRows;
  Result := THStringGridStrings(PList^[Index]);
  if Result = nil then
  begin
    if IsCol then RCIndex := -Index - 1 else RCIndex := Index + 1;
    Result := THStringGridStrings.Create(Self, RCIndex);
    PList^[Index] := Result;
  end;
end;

function  THStringGrid.EnsureDataRow(ARow: Integer): Pointer;
var
  quantum: TSPAQuantum;
begin
  Result := TStringSparseList(TSparseList(FData)[ARow]);
  if Result = nil then
  begin
    if ColCount > 512 then quantum := SPALarge else quantum := SPASmall;
    Result := TStringSparseList.Create(quantum);
    TSparseList(FData)[ARow] := Result;
  end;
end;

function THStringGrid.GetCells(ACol, ARow: Integer): string;
var
  ssl: TStringSparseList;
begin
  ssl := TStringSparseList(TSparseList(FData)[ARow]);
  if ssl = nil then Result := '' else Result := ssl[ACol];
end;

function THStringGrid.GetCols(Index: Integer): TStrings;
begin
  Result := EnsureColRow(Index, True);
end;

function THStringGrid.GetObjects(ACol, ARow: Integer): TObject;
var
  ssl: TStringSparseList;
begin
  ssl := TStringSparseList(TSparseList(FData)[ARow]);
  if ssl = nil then Result := nil else Result := ssl.Objects[ACol];
end;

function THStringGrid.GetRows(Index: Integer): TStrings;
begin
  Result := EnsureColRow(Index, False);
end;

procedure THStringGrid.SetCells(ACol, ARow: Integer; const Value: string);
begin
  THStringGridStrings(EnsureDataRow(ARow))[ACol] := Value;
  EnsureColRow(ACol, True);
  EnsureColRow(ARow, False);
  CellUpdate(ACol, ARow);
  DataChanged := True;
end;

procedure THStringGrid.SetCols(Index: Integer; Value: TStrings);
begin
  EnsureColRow(Index, True).Assign(Value);
end;

procedure THStringGrid.SetObjects(ACol, ARow: Integer; Value: TObject);
begin
  THStringGridStrings(EnsureDataRow(ARow)).Objects[ACol] := Value;
  EnsureColRow(ACol, True);
  EnsureColRow(ARow, False);
  CellUpdate(ACol, ARow);
end;

procedure THStringGrid.SetRows(Index: Integer; Value: TStrings);
begin
  EnsureColRow(Index, False).Assign(Value);
end;

end.


