//****************************************************************************//
// システム         : RC.NSシリーズ
// プログラム名称   : TreeViewコンポーネント
// プログラム概要   : 構成部品の一覧を表示専用
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 水間 俊丞
// 作 成 日  2009/09/01  修正内容 : 新規作成
// 作 成 日  2009/09/24  修正内容 : iwamoto TRCTreeNode,TRCStringsをTHTreeNode,THStringsに変更
//----------------------------------------------------------------------------//

(*変更点①*)
//初期値↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
//初期値↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

(*変更点②*)
//色変え↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
//色変え↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

(*変更点③*)
//閉じない↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
//閉じない↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

(*変更点④*)
//ヘルプを出さない↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
//ヘルプを出さない↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

(*変更点⑤*)
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

unit HTreeView;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms,
  CommCtrl, ComStrs, Dialogs, ImgList;

//色変え↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
const
  NM_CUSTOMDRAW = NM_FIRST - 12;

  CDDS_ITEM         = $00010000;
  CDDS_PREPAINT     = $00000001;
  CDDS_ITEMPREPAINT = (CDDS_ITEM or CDDS_PREPAINT);

  CDRF_DODEFAULT      = $00000000;
  CDRF_NEWFONT        = $00000002;
  CDRF_NOTIFYITEMDRAW = $00000020;

  CDRF_NOTIFYPOSTPAINT   = $00000010;
  CDRF_NOTIFYITEMERASE   = $00000080;

//色変え↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
//ヘルプを出さない↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
  TVS_NOTOOLTIPS = $0080;
//ヘルプを出さない↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
  TVS_CHECKBOXES = $0100;
  TVIS_CHECKED = $2000;

  // itemState flags
  CDIS_SELECTED           = $0001;
  CDIS_GRAYED             = $0002;
  CDIS_DISABLED           = $0004;
  CDIS_CHECKED            = $0008;
  CDIS_FOCUS              = $0010;
  CDIS_DEFAULT            = $0020;
  CDIS_HOT                = $0040;
  CDIS_MARKED             = $0080;
  CDIS_INDETERMINATE      = $0100;

//  NM_RETRUN  = NM_FIRST -  4;
//  NM_KEYDOWN = NM_FIRST - 15;
  NM_CHAR    = NM_FIRST - 18;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

type
//色変え↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
  PNMCUSTOMDRAW = ^TNMCUSTOMDRAW;
  TNMCUSTOMDRAW = record
                    hdr        : TNMHdr;
                    dwDrawStage: DWORD;   // see above
                    hdc        : HDC;     // drawing area for the specific item
                    rc         : TRect;   // the enclosing rect for the specific item
                    dwItemSpec : DWORD;   // item number in the control
                    uItemState : UINT;    // see above
                    lItemlParam: LPARAM;  // item specific data
                  end;

  PNMTVCUSTOMDRAW = ^TNMTVCUSTOMDRAW;
  TNMTVCUSTOMDRAW = record
                      nmcd     : TNMCUSTOMDRAW;
                      clrText  : COLORREF;
                      clrTextBk: COLORREF;
                      iLevel   : Integer;
                    end;
//色変え↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑


  THTreeView = class;
  THTreeNodes = class;


  //=======================================================================
  //  RCTreeNode
  //=======================================================================
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
//  TNodeState = (nsCut, nsDropHilited, nsFocused, nsSelected, nsExpanded);
  TNodeState = (nsCut, nsDropHilited, nsFocused, nsSelected, nsExpanded, nsChecked);
  TNodeStates = set of TNodeState;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  TNodeAttachMode = (naAdd, naAddFirst, naAddChild, naAddChildFirst, naInsert);
  TAddMode = (taAddFirst, taAdd, taInsert);

  PNodeInfo = ^TNodeInfo;
  TNodeInfo = packed record
    ImageIndex: Integer;
    SelectedIndex: Integer;
    StateIndex: Integer;
    OverlayIndex: Integer;
    Data: Pointer;
    Count: Integer;
    Text: string;
//色変え↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    ParentFont: Boolean;
    ParentColor: Boolean;
    Color: TColor;
    Font: TFont;
//色変え↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    Checked: Boolean;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  end;

  THTreeNode = class(TPersistent)
  private
    { Private 宣言 }
    FOwner: THTreeNodes;
    FText: string;
    FData: Pointer;
    FItemId: HTreeItem;
    FImageIndex: Integer;
    FSelectedIndex: Integer;
    FOverlayIndex: Integer;
    FStateIndex: Integer;
    FDeleting: Boolean;
    FInTree: Boolean;
//色変え↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    FParentFont: Boolean;
    FParentColor: Boolean;
    FFont: TFont;
    FColor: TColor;
//色変え↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
    function CompareCount(CompareMe: Integer): Boolean;
    function DoCanExpand(Expand: Boolean): Boolean;
    procedure DoExpand(Expand: Boolean);
    procedure ExpandItem(Expand: Boolean; Recurse: Boolean);
    function GetAbsoluteIndex: Integer;
    function GetExpanded: Boolean;
    function GetLevel: Integer;
    function GetParent: THTreeNode;
    function GetChildren: Boolean;
    function GetCut: Boolean;
    function GetDropTarget: Boolean;
    function GetFocused: Boolean;
    function GetIndex: Integer;
    function GetItem(Index: Integer): THTreeNode;
    function GetSelected: Boolean;
    function GetState(NodeState: TNodeState): Boolean;
    function GetCount: Integer;
    function GetTreeView: THTreeView;
    procedure InternalMove(ParentNode, Node: THTreeNode; HItem: HTreeItem; AddMode: TAddMode);
    function IsEqual(Node: THTreeNode): Boolean;
    function IsNodeVisible: Boolean;
    procedure ReadData(Stream: TStream; Info: PNodeInfo);
    procedure SetChildren(Value: Boolean);
    procedure SetCut(Value: Boolean);
    procedure SetData(Value: Pointer);
    procedure SetDropTarget(Value: Boolean);
    procedure SetItem(Index: Integer; Value: THTreeNode);
    procedure SetExpanded(Value: Boolean);
    procedure SetFocused(Value: Boolean);
    procedure SetImageIndex(Value: Integer);
    procedure SetOverlayIndex(Value: Integer);
    procedure SetSelectedIndex(Value: Integer);
    procedure SetSelected(Value: Boolean);
    procedure SetStateIndex(Value: Integer);
    procedure SetText(const S: string);
    procedure WriteData(Stream: TStream; Info: PNodeInfo);
//色変え↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    function GetFont: TFont;
    procedure SetParentFont(AValue: Boolean);
    procedure SetParentColor(AValue: Boolean);
    procedure SetFont(AFont: TFont);
    procedure SetColor(AValue: TColor);
//色変え↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    function GetChecked: Boolean;
    procedure SetChecked(Value: Boolean);
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  protected
    { Protected 宣言 }
  public
    { Public 宣言 }
    constructor Create(AOwner: THTreeNodes);
    destructor Destroy; override;
    function AlphaSort: Boolean;
    procedure Assign(Source: TPersistent); override;
    procedure Collapse(Recurse: Boolean);
    function CustomSort(SortProc: TTVCompare; Data: Longint): Boolean;
    procedure Delete;
    procedure DeleteChildren;
    function DisplayRect(TextOnly: Boolean): TRect;
    function EditText: Boolean;
    procedure EndEdit(Cancel: Boolean);
    procedure Expand(Recurse: Boolean);
    function GetFirstChild: THTreeNode;
    function GetHandle: HWND;
    function GetLastChild: THTreeNode;
    function GetNext: THTreeNode;
    function GetNextChild(Value: THTreeNode): THTreeNode;
    function GetNextSibling: THTreeNode;
    function GetNextVisible: THTreeNode;
    function GetPrev: THTreeNode;
    function GetPrevChild(Value: THTreeNode): THTreeNode;
    function GetPrevSibling: THTreeNode;
    function GetPrevVisible: THTreeNode;
    function HasAsParent(Value: THTreeNode): Boolean;
    function IndexOf(Value: THTreeNode): Integer;
    procedure MakeVisible;
    procedure MoveTo(Destination: THTreeNode; Mode: TNodeAttachMode); virtual;
    property AbsoluteIndex: Integer read GetAbsoluteIndex;
    property Count: Integer read GetCount;
    property Cut: Boolean read GetCut write SetCut;
    property Data: Pointer read FData write SetData;
    property Deleting: Boolean read FDeleting;
    property Focused: Boolean read GetFocused write SetFocused;
    property DropTarget: Boolean read GetDropTarget write SetDropTarget;
    property Selected: Boolean read GetSelected write SetSelected;
    property Expanded: Boolean read GetExpanded write SetExpanded;
    property Handle: HWND read GetHandle;
    property HasChildren: Boolean read GetChildren write SetChildren;
    property ImageIndex: Integer read FImageIndex write SetImageIndex;
    property Index: Integer read GetIndex;
    property IsVisible: Boolean read IsNodeVisible;
    property Item[Index: Integer]: THTreeNode read GetItem write SetItem; default;
    property ItemId: HTreeItem read FItemId;
    property Level: Integer read GetLevel;
    property OverlayIndex: Integer read FOverlayIndex write SetOverlayIndex;
    property Owner: THTreeNodes read FOwner;
    property Parent: THTreeNode read GetParent;
    property SelectedIndex: Integer read FSelectedIndex write SetSelectedIndex;
    property StateIndex: Integer read FStateIndex write SetStateIndex;
    property Text: string read FText write SetText;
    property HTreeView: THTreeView read GetTreeView;
//色変え↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    property ParentFont: Boolean read FParentFont write SetParentFont default True;
    property ParentColor: Boolean read FParentColor write SetParentColor default True;
    property Font: TFont read GetFont write SetFont;
    property Color: TColor read FColor write SetColor;
//色変え↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    property Checked: Boolean read GetChecked write SetChecked;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  published
    { Published 宣言 }
  end;


  //=======================================================================
  //  RCTreeNodes
  //=======================================================================
  THTreeNodes = class(TPersistent)
  private
    { Private 宣言 }
    FOwner: THTreeView;
    FUpdateCount: Integer;
    procedure AddedNode(Value: THTreeNode);
    function GetHandle: HWND;
    function GetNodeFromIndex(Index: Integer): THTreeNode;
    procedure ReadData(Stream: TStream);
    procedure Repaint(Node: THTreeNode);
    procedure WriteData(Stream: TStream);
  protected
    { Protected 宣言 }
    function AddItem(Parent, Target: HTreeItem; const Item: TTVItem; AddMode: TAddMode): HTreeItem;
    function InternalAddObject(Node: THTreeNode; const S: string; Ptr: Pointer; AddMode: TAddMode): THTreeNode;
    procedure DefineProperties(Filer: TFiler); override;
    function CreateItem(Node: THTreeNode): TTVItem;
    function GetCount: Integer;
    procedure SetItem(Index: Integer; Value: THTreeNode);
    procedure SetUpdateState(Updating: Boolean);
  public
    { Public 宣言 }
    constructor Create(AOwner: THTreeView);
    destructor Destroy; override;
    function AddChildFirst(Node: THTreeNode; const S: string): THTreeNode;
    function AddChild(Node: THTreeNode; const S: string): THTreeNode;
    function AddChildObjectFirst(Node: THTreeNode; const S: string; Ptr: Pointer): THTreeNode;
    function AddChildObject(Node: THTreeNode; const S: string; Ptr: Pointer): THTreeNode;
    function AddFirst(Node: THTreeNode; const S: string): THTreeNode;
    function Add(Node: THTreeNode; const S: string): THTreeNode;
    function AddObjectFirst(Node: THTreeNode; const S: string; Ptr: Pointer): THTreeNode;
    function AddObject(Node: THTreeNode; const S: string; Ptr: Pointer): THTreeNode;
    procedure Assign(Source: TPersistent); override;
    procedure BeginUpdate;
    procedure Clear;
    procedure Delete(Node: THTreeNode);
    procedure EndUpdate;
    function GetFirstNode: THTreeNode;
    function GetNode(ItemId: HTreeItem): THTreeNode;
    function Insert(Node: THTreeNode; const S: string): THTreeNode;
    function InsertObject(Node: THTreeNode; const S: string; Ptr: Pointer): THTreeNode;
    property Count: Integer read GetCount;
    property Handle: HWND read GetHandle;
    property Item[Index: Integer]: THTreeNode read GetNodeFromIndex; default;
    property Owner: THTreeView read FOwner;
//色変え↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    function IsUpdating: Boolean;
//色変え↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  published
    { Published 宣言 }
  end;


  //=======================================================================
  //  TreeStrings
  //=======================================================================
  THTreeStrings = class(TStrings)
  private
    { Private 宣言 }
    FOwner: THTreeNodes;
  protected
    { Protected 宣言 }
    function Get(Index: Integer): string; override;
    function GetBufStart(Buffer: PChar; var Level: Integer): PChar;
    function GetCount: Integer; override;
    function GetObject(Index: Integer): TObject; override;
    procedure PutObject(Index: Integer; AObject: TObject); override;
    procedure SetUpdateState(Updating: Boolean); override;
  public
    { Public 宣言 }
    constructor Create(AOwner: THTreeNodes);
    function Add(const S: string): Integer; override;
    procedure Clear; override;
    procedure Delete(Index: Integer); override;
    procedure Insert(Index: Integer; const S: string); override;
    procedure LoadTreeFromStream(Stream: TStream);
    procedure SaveTreeToStream(Stream: TStream);
    property Owner: THTreeNodes read FOwner;
  published
    { Published 宣言 }
  end;


  //=======================================================================
  //  HTreeView
  //=======================================================================
  TSortType = (stNone, stData, stText, stBoth);
  THitTest  = (htAbove, htBelow, htNowhere, htOnItem, htOnButton, htOnIcon, htOnIndent, htOnLabel, htOnRight, htOnStateIcon, htToLeft, htToRight);
  THitTests = set of THitTest;

  ETreeViewError = class(Exception);

  TTVChangingEvent   = procedure(Sender: TObject; Node: THTreeNode; var AllowChange: Boolean) of object;
  TTVChangedEvent    = procedure(Sender: TObject; Node: THTreeNode) of object;
  TTVEditingEvent    = procedure(Sender: TObject; Node: THTreeNode; var AllowEdit: Boolean) of object;
  TTVEditedEvent     = procedure(Sender: TObject; Node: THTreeNode; var S: string) of object;
  TTVExpandingEvent  = procedure(Sender: TObject; Node: THTreeNode; var AllowExpansion: Boolean) of object;
  TTVCollapsingEvent = procedure(Sender: TObject; Node: THTreeNode; var AllowCollapse: Boolean) of object;
  TTVExpandedEvent   = procedure(Sender: TObject; Node: THTreeNode) of object;
  TTVCompareEvent    = procedure(Sender: TObject; Node1, Node2: THTreeNode; Data: Integer; var Compare: Integer) of object;

  THTreeView = class(TWinControl)
  private
    { Private 宣言 }
    FShowLines: Boolean;
    FShowRoot: Boolean;
    FShowButtons: Boolean;
    FBorderStyle: TBorderStyle;
    FReadOnly: Boolean;
    FImages: TImageList;
    FStateImages: TImageList;
    FImageChangeLink: TChangeLink;
    FStateChangeLink: TChangeLink;
    FDragImage: TImageList;
    FTreeNodes: THTreeNodes;
    FSortType: TSortType;
    FSaveItems: TStringList;
    FSaveTopIndex: Integer;
    FSaveIndex: Integer;
    FSaveIndent: Integer;
    FHideSelection: Boolean;
    FMemStream: TMemoryStream;
    FEditInstance: Pointer;
    FDefEditProc: Pointer;
    FEditHandle: HWND;
    FDragged: Boolean;
    FRClickNode: THTreeNode;
    FLastDropTarget: THTreeNode;
    FDragNode: THTreeNode;
    FManualNotify: Boolean;
    FRightClickSelect: Boolean;
    FSavedSort: TSortType;
    FStateChanging: Boolean;
    FWideText: WideString;
    FOnEditing: TTVEditingEvent;
    FOnEdited: TTVEditedEvent;
    FOnExpanded: TTVExpandedEvent;
    FOnExpanding: TTVExpandingEvent;
    FOnCollapsed: TTVExpandedEvent;
    FOnCollapsing: TTVCollapsingEvent;
    FOnChanging: TTVChangingEvent;
    FOnChange: TTVChangedEvent;
    FOnCompare: TTVCompareEvent;
    FOnDeletion: TTVExpandedEvent;
    FOnGetImageIndex: TTVExpandedEvent;
    FOnGetSelectedIndex: TTVExpandedEvent;
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    FCheckBoxes: Boolean;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
    procedure CMColorChanged(var Message: TMessage); message CM_COLORCHANGED;
    procedure CMCtl3DChanged(var Message: TMessage); message CM_CTL3DCHANGED;
    procedure CMDrag(var Message: TCMDrag); message CM_DRAG;
    procedure CNNotify(var Message: TWMNotify); message CN_NOTIFY;
    procedure EditWndProc(var Message: TMessage);
    procedure DoDragOver(Source: TDragObject; X, Y: Integer; CanDrop: Boolean);
    procedure GetImageIndex(Node: THTreeNode);
    procedure GetSelectedIndex(Node: THTreeNode);
    function GetDropTarget: THTreeNode;
    function GetIndent: Integer;
    function GetNodeFromItem(const Item: TTVItem): THTreeNode;
    function GetSelection: THTreeNode;
    function GetTopItem: THTreeNode;
    procedure ImageListChange(Sender: TObject);
    procedure SetBorderStyle(Value: TBorderStyle);
    procedure SetButtonStyle(Value: Boolean);
    procedure SetDropTarget(Value: THTreeNode);
    procedure SetHideSelection(Value: Boolean);
    procedure SetImageList(Value: HImageList; Flags: Integer);
    procedure SetIndent(Value: Integer);
    procedure SetImages(Value: TImageList);
    procedure SetLineStyle(Value: Boolean);
    procedure SetReadOnly(Value: Boolean);
    procedure SetRootStyle(Value: Boolean);
    procedure SetSelection(Value: THTreeNode);
    procedure SetSortType(Value: TSortType);
    procedure SetStateImages(Value: TImageList);
    procedure SetStyle(Value: Integer; UseStyle: Boolean);
    procedure SetTreeNodes(Value: THTreeNodes);
    procedure SetTopItem(Value: THTreeNode);
    procedure WMLButtonDown(var Message: TWMLButtonDown); message WM_LBUTTONDOWN;
    procedure WMRButtonDown(var Message: TWMRButtonDown); message WM_RBUTTONDOWN;
    procedure WMRButtonUp(var Message: TWMRButtonUp); message WM_RBUTTONUP;
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    procedure WMKeyDown(var Message: TWMKeyDown); message WM_KEYDOWN;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
    procedure WMNotify(var Message: TWMNotify); message WM_NOTIFY;
    procedure CMSysColorChange(var Message: TMessage); message CM_SYSCOLORCHANGE;
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    procedure SetCheckBoxes(Value: Boolean);
    procedure xChildCheckOnOff (SelectNode: THTreeNode; iMode: Integer);
    procedure xParentCheckOnOff(SelectNode: THTreeNode; AItemId: HTreeItem);
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  protected
    { Protected 宣言 }
    function CanEdit(Node: THTreeNode): Boolean; dynamic;
    function CanChange(Node: THTreeNode): Boolean; dynamic;
    function CanCollapse(Node: THTreeNode): Boolean; dynamic;
    function CanExpand(Node: THTreeNode): Boolean; dynamic;
    procedure Change(Node: THTreeNode); dynamic;
    procedure Collapse(Node: THTreeNode); dynamic;
    function CreateNode: THTreeNode; virtual;
    procedure CreateParams(var Params: TCreateParams); override;
    procedure CreateWnd; override;
    procedure DestroyWnd; override;
    procedure DoEndDrag(Target: TObject; X, Y: Integer); override;
    procedure DoStartDrag(var DragObject: TDragObject); override;
    procedure Edit(const Item: TTVItem); dynamic;
    procedure Expand(Node: THTreeNode); dynamic;
    function GetDragImages: TDragImageList; override;
    procedure Loaded; override;
    procedure Notification(AComponent: TComponent; Operation: TOperation); override;
    procedure SetDragMode(Value: TDragMode); override;
    procedure WndProc(var Message: TMessage); override;
  public
    { Public 宣言 }
    constructor Create(AOwner: TComponent); override;
    destructor Destroy; override;
    function AlphaSort: Boolean;
    function CustomSort(SortProc: TTVCompare; Data: Longint): Boolean;
    procedure FullCollapse;
    procedure FullExpand;
    function GetHitTestInfoAt(X, Y: Integer): THitTests;
    function GetNodeAt(X, Y: Integer): THTreeNode;
    function IsEditing: Boolean;
    procedure LoadFromFile(const FileName: string);
    procedure LoadFromStream(Stream: TStream);
    procedure SaveToFile(const FileName: string);
    procedure SaveToStream(Stream: TStream);
    property DropTarget: THTreeNode read GetDropTarget write SetDropTarget;
    property Selected: THTreeNode read GetSelection write SetSelection;
    property TopItem: THTreeNode read GetTopItem write SetTopItem;
  published
    { Published 宣言 }
    property DragCursor;
    property DragMode;
    property Align;
    property Enabled;
    property Font;
    property Color;
    property ParentColor default False;
    property ParentCtl3D;
    property Ctl3D;
    property TabOrder;
    property TabStop default True;
    property Visible;
    property PopupMenu;
    property ParentFont;
    property ParentShowHint;
    property ShowHint;
    property ShowButtons: Boolean read FShowButtons write SetButtonStyle default True;
    property BorderStyle: TBorderStyle read FBorderStyle write SetBorderStyle default bsSingle;
    property ShowLines: Boolean read FShowLines write SetLineStyle default True;
    property ShowRoot: Boolean read FShowRoot write SetRootStyle default True;
    property ReadOnly: Boolean read FReadOnly write SetReadOnly default False;
    property RightClickSelect: Boolean read FRightClickSelect write FRightClickSelect default False;
    property Indent: Integer read GetIndent write SetIndent;
    property Items: THTreeNodes read FTreeNodes write SetTreeNodes;
    property SortType: TSortType read FSortType write SetSortType default stNone;
    property HideSelection: Boolean read FHideSelection write SetHideSelection default True;
    property Images: TImageList read FImages write SetImages;
    property StateImages: TImageList read FStateImages write SetStateImages;
    property OnClick;
    property OnEnter;
    property OnExit;
    property OnDragDrop;
    property OnDragOver;
    property OnStartDrag;
    property OnEndDrag;
    property OnMouseDown;
    property OnMouseMove;
    property OnMouseUp;
    property OnDblClick;
    property OnKeyDown;
    property OnKeyPress;
    property OnKeyUp;
    property OnEditing: TTVEditingEvent read FOnEditing write FOnEditing;
    property OnEdited: TTVEditedEvent read FOnEdited write FOnEdited;
    property OnExpanding: TTVExpandingEvent read FOnExpanding write FOnExpanding;
    property OnExpanded: TTVExpandedEvent read FOnExpanded write FOnExpanded;
    property OnCollapsing: TTVCollapsingEvent read FOnCollapsing write FOnCollapsing;
    property OnCollapsed: TTVExpandedEvent read FOnCollapsed write FOnCollapsed;
    property OnChanging: TTVChangingEvent read FOnChanging write FOnChanging;
    property OnChange: TTVChangedEvent read FOnChange write FOnChange;
    property OnCompare: TTVCompareEvent read FOnCompare write FOnCompare;
    property OnDeletion: TTVExpandedEvent read FOnDeletion write FOnDeletion;
    property OnGetImageIndex: TTVExpandedEvent read FOnGetImageIndex write FOnGetImageIndex;
    property OnGetSelectedIndex: TTVExpandedEvent read FOnGetSelectedIndex write FOnGetSelectedIndex;
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    property CheckBoxes: Boolean read FCheckBoxes write SetCheckBoxes default True;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  end;

  function InitCommonControl(CC: Integer): Boolean;

procedure Register;

implementation

procedure Register;
begin
  RegisterComponents('HSS', [THTreeView]);
end;

function InitCommonControl(CC: Integer): Boolean;
var
  ICC: TInitCommonControlsEx;
begin
  ICC.dwSize := SizeOf(TInitCommonControlsEx);
  ICC.dwICC := CC;
  Result := InitCommonControlsEx(ICC);
  if not Result then InitCommonControls;
end;


//=========================================================================
//  RCTreeNode
//=========================================================================
function DefaultTreeViewSort(Node1, Node2: THTreeNode; lParam: Integer): Integer; stdcall;
begin
  with Node1 do
    if Assigned(HTreeView.OnCompare) then
      HTreeView.OnCompare(HTreeView, Node1, Node2, lParam, Result)
    else Result := lstrcmp(PChar(Node1.Text), PChar(Node2.Text));
end;

procedure TreeViewError(const Msg: string);
begin
  raise ETreeViewError.Create(Msg);
end;

procedure TreeViewErrorFmt(const Msg: string; Format: array of const);
begin
  raise ETreeViewError.CreateFmt(Msg, Format);
end;

constructor THTreeNode.Create(AOwner: THTreeNodes);
begin
  inherited Create;
  FOverlayIndex := -1;
  FStateIndex := -1;
//色変え↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
  FParentColor := True;
  FParentFont := True;
//色変え↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  FOwner := AOwner;
end;

destructor THTreeNode.Destroy;
var
  Node: THTreeNode;
  CheckValue: Integer;
begin
  FDeleting := True;
  if Owner.Owner.FLastDropTarget = Self then
    Owner.Owner.FLastDropTarget := nil;
  Node := Parent;
  if (Node <> nil) and (not Node.Deleting) then
  begin
    if Node.IndexOf(Self) <> -1 then CheckValue := 1
    else CheckValue := 0;
    if Node.CompareCount(CheckValue) then
    begin
      Expanded := False;
      Node.HasChildren := False;
    end;
  end;
  if ItemId <> nil then TreeView_DeleteItem(Handle, ItemId);
  Data := nil;
//色変え↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
  FFont.Free;
//色変え↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  inherited Destroy;
end;

function THTreeNode.GetHandle: HWND;
begin
  Result := HTreeView.Handle;
end;

function THTreeNode.GetTreeView: THTreeView;
begin
  Result := Owner.Owner;
end;

function THTreeNode.HasAsParent(Value: THTreeNode): Boolean;
begin
  if Value <> Nil then
  begin
    if Parent = Nil then Result := False
    else if Parent = Value then Result := True
    else Result := Parent.HasAsParent(Value);
  end
  else Result := True;
end;

procedure THTreeNode.SetText(const S: string);
var
  Item: TTVItem;
begin
  FText := S;
  with Item do
  begin
    mask := TVIF_TEXT;
    hItem := ItemId;
    pszText := LPSTR_TEXTCALLBACK;
  end;
  TreeView_SetItem(Handle, Item);
  if (HTreeView.SortType in [stText, stBoth]) and FInTree then
  begin
    if (Parent <> nil) then Parent.AlphaSort
    else HTreeView.AlphaSort;
  end;
end;

procedure THTreeNode.SetData(Value: Pointer);
begin
  FData := Value;
  if (HTreeView.SortType in [stData, stBoth]) and Assigned(HTreeView.OnCompare)
    and (not Deleting) and FInTree then
  begin
    if Parent <> nil then Parent.AlphaSort
    else HTreeView.AlphaSort;
  end;
end;

function THTreeNode.GetState(NodeState: TNodeState): Boolean;
var
  Item: TTVItem;
begin
  Result := False;
  with Item do
  begin
    mask := TVIF_STATE;
    hItem := ItemId;
    if TreeView_GetItem(Handle, Item) then
      case NodeState of
        nsCut: Result := (state and TVIS_CUT) <> 0;
        nsFocused: Result := (state and TVIS_FOCUSED) <> 0;
        nsSelected: Result := (state and TVIS_SELECTED) <> 0;
        nsExpanded: Result := (state and TVIS_EXPANDED) <> 0;
        nsDropHilited: Result := (state and TVIS_DROPHILITED) <> 0;
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        nsChecked: Result := (State and TVIS_CHECKED) <> 0;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
      end;
  end;
end;

procedure THTreeNode.SetImageIndex(Value: Integer);
var
  Item: TTVItem;
begin
  FImageIndex := Value;
  with Item do
  begin
    mask := TVIF_IMAGE or TVIF_HANDLE;
    hItem := ItemId;
    iImage := I_IMAGECALLBACK;
  end;
  TreeView_SetItem(Handle, Item);
end;

procedure THTreeNode.SetSelectedIndex(Value: Integer);
var
  Item: TTVItem;
begin
  FSelectedIndex := Value;
  with Item do
  begin
    mask := TVIF_SELECTEDIMAGE or TVIF_HANDLE;
    hItem := ItemId;
    iSelectedImage := I_IMAGECALLBACK;
  end;
  TreeView_SetItem(Handle, Item);
end;

procedure THTreeNode.SetOverlayIndex(Value: Integer);
var
  Item: TTVItem;
begin
  FOverlayIndex := Value;
  with Item do
  begin
    mask := TVIF_STATE or TVIF_HANDLE;
    stateMask := TVIS_OVERLAYMASK;
    hItem := ItemId;
    state := IndexToOverlayMask(OverlayIndex + 1);
  end;
  TreeView_SetItem(Handle, Item);
end;

procedure THTreeNode.SetStateIndex(Value: Integer);
var
  Item: TTVItem;
begin
  FStateIndex := Value;
  if Value >= 0 then Dec(Value);
  with Item do
  begin
    mask := TVIF_STATE or TVIF_HANDLE;
    stateMask := TVIS_STATEIMAGEMASK;
    hItem := ItemId;
    state := IndexToStateImageMask(Value + 1);
  end;
  TreeView_SetItem(Handle, Item);
end;

function THTreeNode.CompareCount(CompareMe: Integer): Boolean;
var
  Count: integer;
  Node: THTreeNode;
Begin
  Count := 0;
  Result := False;
  Node := GetFirstChild;
  while Node <> nil do
  begin
    Inc(Count);
    Node := Node.GetNextChild(Node);
    if Count > CompareMe then Exit;
  end;
  if Count = CompareMe then Result := True;
end;

function THTreeNode.DoCanExpand(Expand: Boolean): Boolean;
begin
  Result := False;
  if HasChildren then
  begin
    if Expand then Result := HTreeView.CanExpand(Self)
    else Result := HTreeView.CanCollapse(Self);
  end;
end;

procedure THTreeNode.DoExpand(Expand: Boolean);
begin
  if HasChildren then
  begin
    if Expand then HTreeView.Expand(Self)
    else HTreeView.Collapse(Self);
  end;
end;

procedure THTreeNode.ExpandItem(Expand: Boolean; Recurse: Boolean);
var
  Flag: Integer;
  Node: THTreeNode;
begin
  if Recurse then
  begin
    Node := Self;
    repeat
      Node.ExpandItem(Expand, False);
      Node := Node.GetNext;
    until (Node = nil) or (not Node.HasAsParent(Self));
  end
  else begin
    HTreeView.FManualNotify := True;
    try
      Flag := 0;
      if Expand then
      begin
        if DoCanExpand(True) then
        begin
          Flag := TVE_EXPAND;
          DoExpand(True);
        end;
      end
      else begin
        if DoCanExpand(False) then
        begin
          Flag := TVE_COLLAPSE;
          DoExpand(False);
        end;
      end;
      if Flag <> 0 then TreeView_Expand(Handle, ItemId, Flag);
    finally
      HTreeView.FManualNotify := False;
    end;
  end;
end;

procedure THTreeNode.Expand(Recurse: Boolean);
begin
  ExpandItem(True, Recurse);
end;

procedure THTreeNode.Collapse(Recurse: Boolean);
begin
  ExpandItem(False, Recurse);
end;

function THTreeNode.GetExpanded: Boolean;
begin
  Result := GetState(nsExpanded);
end;

procedure THTreeNode.SetExpanded(Value: Boolean);
begin
  if Value then Expand(False)
  else Collapse(False);
end;

function THTreeNode.GetSelected: Boolean;
begin
  Result := GetState(nsSelected);
end;

procedure THTreeNode.SetSelected(Value: Boolean);
begin
  if Value then TreeView_SelectItem(Handle, ItemId)
  else if Selected then TreeView_SelectItem(Handle, nil);
end;

function THTreeNode.GetCut: Boolean;
begin
  Result := GetState(nsCut);
end;

procedure THTreeNode.SetCut(Value: Boolean);
var
  Item: TTVItem;
  Template: Integer;
begin
  if Value then Template := -1
  else Template := 0;
  with Item do
  begin
    mask := TVIF_STATE;
    hItem := ItemId;
    stateMask := TVIS_CUT;
    state := stateMask and Template;
  end;
  TreeView_SetItem(Handle, Item);
end;

function THTreeNode.GetDropTarget: Boolean;
begin
  Result := GetState(nsDropHilited);
end;

procedure THTreeNode.SetDropTarget(Value: Boolean);
begin
  if Value then TreeView_SelectDropTarget(Handle, ItemId)
  else if DropTarget then TreeView_SelectDropTarget(Handle, nil);
end;

function THTreeNode.GetChildren: Boolean;
var
  Item: TTVItem;
begin
  Item.mask := TVIF_CHILDREN;
  Item.hItem := ItemId;
  if TreeView_GetItem(Handle, Item) then Result := Item.cChildren > 0
  else Result := False;
end;

procedure THTreeNode.SetFocused(Value: Boolean);
var
  Item: TTVItem;
  Template: Integer;
begin
  if Value then Template := -1
  else Template := 0;
  with Item do
  begin
    mask := TVIF_STATE;
    hItem := ItemId;
    stateMask := TVIS_FOCUSED;
    state := stateMask and Template;
  end;
  TreeView_SetItem(Handle, Item);
end;

function THTreeNode.GetFocused: Boolean;
begin
  Result := GetState(nsFocused);
end;

procedure THTreeNode.SetChildren(Value: Boolean);
var
  Item: TTVItem;
begin
  with Item do
  begin
    mask := TVIF_CHILDREN;
    hItem := ItemId;
    cChildren := Ord(Value);
  end;
  TreeView_SetItem(Handle, Item);
end;

function THTreeNode.GetParent: THTreeNode;
begin
  with FOwner do
    Result := GetNode(TreeView_GetParent(Handle, ItemId));
end;

function THTreeNode.GetNextSibling: THTreeNode;
begin
  with FOwner do
    Result := GetNode(TreeView_GetNextSibling(Handle, ItemId));
end;

function THTreeNode.GetPrevSibling: THTreeNode;
begin
  with FOwner do
    Result := GetNode(TreeView_GetPrevSibling(Handle, ItemId));
end;

function THTreeNode.GetNextVisible: THTreeNode;
begin
  if IsVisible then
    with FOwner do
      Result := GetNode(TreeView_GetNextVisible(Handle, ItemId))
  else Result := nil;
end;

function THTreeNode.GetPrevVisible: THTreeNode;
begin
  with FOwner do
    Result := GetNode(TreeView_GetPrevVisible(Handle, ItemId));
end;

function THTreeNode.GetNextChild(Value: THTreeNode): THTreeNode;
begin
  if Value <> nil then Result := Value.GetNextSibling
  else Result := nil;
end;

function THTreeNode.GetPrevChild(Value: THTreeNode): THTreeNode;
begin
  if Value <> nil then Result := Value.GetPrevSibling
  else Result := nil;
end;

function THTreeNode.GetFirstChild: THTreeNode;
begin
  with FOwner do
    Result := GetNode(TreeView_GetChild(Handle, ItemId));
end;

function THTreeNode.GetLastChild: THTreeNode;
var
  Node: THTreeNode;
begin
  Result := GetFirstChild;
  if Result <> nil then
  begin
    Node := Result;
    repeat
      Result := Node;
      Node := Result.GetNextSibling;
    until Node = nil;
  end;
end;

function THTreeNode.GetNext: THTreeNode;
var
  NodeID, ParentID: HTreeItem;
  Handle: HWND;
begin
  Handle := FOwner.Handle;
  NodeID := TreeView_GetChild(Handle, ItemId);
  if NodeID = nil then NodeID := TreeView_GetNextSibling(Handle, ItemId);
  ParentID := ItemId;
  while (NodeID = nil) and (ParentID <> nil) do
  begin
    ParentID := TreeView_GetParent(Handle, ParentID);
    NodeID := TreeView_GetNextSibling(Handle, ParentID);
  end;
  Result := FOwner.GetNode(NodeID);
end;

function THTreeNode.GetPrev: THTreeNode;
var
  Node: THTreeNode;
begin
  Result := GetPrevSibling;
  if Result <> nil then
  begin
    Node := Result;
    repeat
      Result := Node;
      Node := Result.GetLastChild;
    until Node = nil;
  end else
    Result := Parent;
end;

function THTreeNode.GetAbsoluteIndex: Integer;
var
  Node: THTreeNode;
begin
  Result := -1;
  Node := Self;
  while Node <> nil do
  begin
    Inc(Result);
    Node := Node.GetPrev;
  end;
end;

function THTreeNode.GetIndex: Integer;
var
  Node: THTreeNode;
begin
  Result := -1;
  Node := Self;
  while Node <> nil do
  begin
    Inc(Result);
    Node := Node.GetPrevSibling;
  end;
end;

function THTreeNode.GetItem(Index: Integer): THTreeNode;
const
  SListIndexError    = 'リストのインデックスが範囲を超えています (%d)';
begin
  Result := GetFirstChild;
  while (Result <> nil) and (Index > 0) do
  begin
    Result := GetNextChild(Result);
    Dec(Index);
  end;
  if Result = nil then TreeViewError(SListIndexError);
end;

procedure THTreeNode.SetItem(Index: Integer; Value: THTreeNode);
begin
  item[Index].Assign(Value);
end;

function THTreeNode.IndexOf(Value: THTreeNode): Integer;
var
  Node: THTreeNode;
begin
  Result := -1;
  Node := GetFirstChild;
  while (Node <> nil) do
  begin
    Inc(Result);
    if Node = Value then Break;
    Node := GetNextChild(Node);
  end;
  if Node = nil then Result := -1;
end;

function THTreeNode.GetCount: Integer;
var
  Node: THTreeNode;
begin
  Result := 0;
  Node := GetFirstChild;
  while Node <> nil do
  begin
    Inc(Result);
    Node := Node.GetNextChild(Node);
  end;
end;

procedure THTreeNode.EndEdit(Cancel: Boolean);
begin
  TreeView_EndEditLabelNow(Handle, Cancel);
end;

procedure THTreeNode.InternalMove(ParentNode, Node: THTreeNode;
  HItem: HTreeItem; AddMode: TAddMode);
var
  I: Integer;
  NodeId: HTreeItem;
  TreeViewItem: TTVItem;
  Children: Boolean;
  IsSelected: Boolean;
begin
  if (AddMode = taInsert) and (Node <> nil) then
    NodeId := Node.ItemId else
    NodeId := nil;
  Children := HasChildren;
  IsSelected := Selected;
  if (Parent <> nil) and (Parent.CompareCount(1)) then
  begin
    Parent.Expanded := False;
    Parent.HasChildren := False;
  end;
  with TreeViewItem do
  begin
    mask := TVIF_PARAM;
    hItem := ItemId;
    lParam := 0;
  end;
  TreeView_SetItem(Handle, TreeViewItem);
  with Owner do
    HItem := AddItem(HItem, NodeId, CreateItem(Self), AddMode);
  if HItem = nil then
    raise EOutOfResources.Create(sInsertError);
  for I := Count - 1 downto 0 do
    Item[I].InternalMove(Self, nil, HItem, taAddFirst);
  TreeView_DeleteItem(Handle, ItemId);
  FItemId := HItem;
  Assign(Self);
  HasChildren := Children;
  Selected := IsSelected;
end;

procedure THTreeNode.MoveTo(Destination: THTreeNode; Mode: TNodeAttachMode);
var
  AddMode: TAddMode;
  Node: THTreeNode;
  HItem: HTreeItem;
  OldOnChanging: TTVChangingEvent;
  OldOnChange: TTVChangedEvent;
begin
  OldOnChanging := HTreeView.OnChanging;
  OldOnChange := HTreeView.OnChange;
  HTreeView.OnChanging := nil;
  HTreeView.OnChange := nil;
  try
    if (Destination = nil) or not Destination.HasAsParent(Self) then
    begin
      AddMode := taAdd;
      if (Destination <> nil) and not (Mode in [naAddChild, naAddChildFirst]) then
        Node := Destination.Parent else
        Node := Destination;
      case Mode of
        naAdd,
        naAddChild: AddMode := taAdd;
        naAddFirst,
        naAddChildFirst: AddMode := taAddFirst;
        naInsert:
          begin
            Destination := Destination.GetPrevSibling;
            if Destination = nil then AddMode := taAddFirst
            else AddMode := taInsert;
          end;
      end;
      if Node <> nil then
        HItem := Node.ItemId else
        HItem := nil;
      InternalMove(Node, Destination, HItem, AddMode);
      Node := Parent;
      if Node <> nil then
      begin
        Node.HasChildren := True;
        Node.Expanded := True;
      end;
    end;
  finally
    HTreeView.OnChanging := OldOnChanging;
    HTreeView.OnChange := OldOnChange;
  end;
end;

procedure THTreeNode.MakeVisible;
begin
  TreeView_EnsureVisible(Handle, ItemId);
end;

function THTreeNode.GetLevel: Integer;
var
  Node: THTreeNode;
begin
  Result := 0;
  Node := Parent;
  while Node <> nil do
  begin
    Inc(Result);
    Node := Node.Parent;
  end;
end;

function THTreeNode.IsNodeVisible: Boolean;
var
  Rect: TRect;
begin
  Result := TreeView_GetItemRect(Handle, ItemId, Rect, True);
end;

function THTreeNode.EditText: Boolean;
begin
  Result := TreeView_EditLabel(Handle, ItemId) <> 0;
end;

function THTreeNode.DisplayRect(TextOnly: Boolean): TRect;
begin
  FillChar(Result, SizeOf(Result), 0);
  TreeView_GetItemRect(Handle, ItemId, Result, TextOnly);
end;

function THTreeNode.AlphaSort: Boolean;
begin
  Result := CustomSort(nil, 0);
end;

function THTreeNode.CustomSort(SortProc: TTVCompare; Data: Longint): Boolean;
var
  SortCB: TTVSortCB;
begin
  with SortCB do
  begin
    if not Assigned(SortProc) then lpfnCompare := @DefaultTreeViewSort
    else lpfnCompare := SortProc;
    hParent := ItemId;
    lParam := Data;
  end;
  Result := TreeView_SortChildrenCB(Handle, SortCB, 0);
end;

procedure THTreeNode.Delete;
begin
  if not Deleting then Free;
end;

procedure THTreeNode.DeleteChildren;
begin
  TreeView_Expand(HTreeView.Handle, ItemID, TVE_COLLAPSE or TVE_COLLAPSERESET);
  HasChildren := False;
end;

procedure THTreeNode.Assign(Source: TPersistent);
var
  Node: THTreeNode;
begin
  if Source is THTreeNode then
  begin
    Node := THTreeNode(Source);
    Text := Node.Text;
    Data := Node.Data;
    ImageIndex := Node.ImageIndex;
    SelectedIndex := Node.SelectedIndex;
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
//    StateIndex := Node.StateIndex;
    if Assigned(HTreeView) and Assigned(HTreeView.StateImages) then StateIndex := Node.StateIndex;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
    OverlayIndex := Node.OverlayIndex;
    Focused := Node.Focused;
    DropTarget := Node.DropTarget;
    Cut := Node.Cut;
    HasChildren := Node.HasChildren;
//色変え↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    FParentFont := Node.FParentFont;
    FParentColor := Node.FParentColor;
    if not FParentFont then begin
      if (FFont = nil) then FFont := TFont.Create;
      FFont.Assign(Node.FFont);
    end else begin
      FFont.Free;
      FFont := nil;
    end;
//色変え↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  end
  else inherited Assign(Source);
end;

function THTreeNode.IsEqual(Node: THTreeNode): Boolean;
begin
  Result := (Text = Node.Text) and (Data = Node.Data);
end;

procedure THTreeNode.ReadData(Stream: TStream; Info: PNodeInfo);
var
  I, Size, ItemCount: Integer;
begin
  Stream.ReadBuffer(Size, SizeOf(Size));
  Stream.ReadBuffer(Info^, Size);
  Text := Info^.Text;
  ImageIndex := Info^.ImageIndex;
  SelectedIndex := Info^.SelectedIndex;
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
//  StateIndex := Info^.StateIndex;
  if Assigned(HTreeView) and Assigned(HTreeView.StateImages) then StateIndex := Info^.StateIndex;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  OverlayIndex := Info^.OverlayIndex;
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
  Checked := Info^.Checked;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  Data := Info^.Data;
//色変え↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
  Color := Info^.Color;
  ParentColor := Info^.ParentColor;
  ParentFont := Info^.ParentFont;
  if not ParentFont then begin
    FFont := TFont.Create;
    FFont := Info^.Font;
  end;
//色変え↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  ItemCount := Info^.Count;
  for I := 0 to ItemCount - 1 do
    with Owner.AddChild(Self, '') do ReadData(Stream, Info);
end;

procedure THTreeNode.WriteData(Stream: TStream; Info: PNodeInfo);
var
  I, Size, L, ItemCount: Integer;
begin
  L := Length(Text);
  if L > 255 then L := 255;
  Size := SizeOf(TNodeInfo) + L - 255;
  Info^.Text := Text;
  Info^.ImageIndex := ImageIndex;
  Info^.SelectedIndex := SelectedIndex;
  Info^.OverlayIndex := OverlayIndex;
  Info^.StateIndex := StateIndex;
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
  Info^.Checked := Checked;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  Info^.Data := Data;
//色変え↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
  Info^.Color := FColor;
  Info^.ParentFont := FParentFont;
  Info^.ParentColor := FParentColor;
  if not FParentFont then begin
    Info^.Font := FFont;
  end;
//色変え↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  ItemCount := Count;
  Info^.Count := ItemCount;
  Stream.WriteBuffer(Size, SizeOf(Size));
  Stream.WriteBuffer(Info^, Size);
  for I := 0 to ItemCount - 1 do Item[I].WriteData(Stream, Info);
end;

//色変え↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
procedure THTreeNode.SetParentFont(AValue: Boolean);
begin
  if (FParentFont <> AValue) then begin
    FParentFont := AValue;
    if (FParentFont) then begin
      FFont.Free;
      FFont := nil;
    end else begin
      FFont := TFont.Create;
    end;
    if Assigned(HTreeView) and (not HTreeView.Items.IsUpdating) then FOwner.Repaint(Self);
  end;
end;

procedure THTreeNode.SetParentColor(AValue: Boolean);
begin
  if (FParentColor <> AValue) then begin
    FParentColor := AValue;
    if Assigned(HTreeView) and (not HTreeView.Items.IsUpdating) then FOwner.Repaint(Self);
  end;
end;

function THTreeNode.GetFont: TFont;
begin
  if (FFont = nil) then FFont := TFont.Create;
  FParentFont := False;
  Result := FFont;
end;

procedure THTreeNode.SetFont(AFont: TFont);
begin
  if (FFont = nil) then FFont := TFont.Create;
  FFont.Assign(AFont);
  FParentFont := False;
  if Assigned(HTreeView) and (not HTreeView.Items.IsUpdating) then FOwner.Repaint(Self);
end;

procedure THTreeNode.SetColor(AValue: TColor);
begin
  if (FColor <> AValue) then begin
    FColor := AValue;
    FParentColor := False;
    if Assigned(HTreeView) and (not HTreeView.Items.IsUpdating) then FOwner.Repaint(Self);
  end;
end;
//色変え↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
function THTreeNode.GetChecked: Boolean;
begin
  Result := GetState(nsChecked);
end;

procedure THTreeNode.SetChecked(Value: Boolean);
var
  Item: TTVItem;
begin
  FillChar(Item,SizeOf(Item),0);
  with Item do begin
    Mask := TVIF_STATE or TVIF_HANDLE;
    StateMask := TVIS_STATEIMAGEMASK;
    if Value then State := TVIS_CHECKED
    else          State := TVIS_CHECKED shr 1;
    hItem := ItemId;
  end;
  TreeView_SetItem(Handle,Item);
end;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑


//=========================================================================
//  RCTreeNodes
//=========================================================================
constructor THTreeNodes.Create(AOwner: THTreeView);
begin
  inherited Create;
  FOwner := AOwner;
end;

destructor THTreeNodes.Destroy;
begin
  Clear;
  inherited Destroy;
end;

function THTreeNodes.GetCount: Integer;
begin
  if Owner.HandleAllocated then Result := TreeView_GetCount(Handle)
  else Result := 0;
end;

function THTreeNodes.GetHandle: HWND;
begin
  Result := Owner.Handle;
end;

procedure THTreeNodes.Delete(Node: THTreeNode);
begin
  if (Node.ItemId = nil) and Assigned(Owner.FOnDeletion) then
    Owner.FOnDeletion(Self, Node);
  Node.Delete;
end;

procedure THTreeNodes.Clear;
begin
  if Owner.HandleAllocated then
    TreeView_DeleteAllItems(Handle);
end;

function THTreeNodes.AddChildFirst(Node: THTreeNode; const S: string): THTreeNode;
begin
  Result := AddChildObjectFirst(Node, S, nil);
end;

function THTreeNodes.AddChildObjectFirst(Node: THTreeNode; const S: string;
  Ptr: Pointer): THTreeNode;
begin
  Result := InternalAddObject(Node, S, Ptr, taAddFirst);
end;

function THTreeNodes.AddChild(Node: THTreeNode; const S: string): THTreeNode;
begin
  Result := AddChildObject(Node, S, nil);
end;

function THTreeNodes.AddChildObject(Node: THTreeNode; const S: string;
  Ptr: Pointer): THTreeNode;
begin
  Result := InternalAddObject(Node, S, Ptr, taAdd);
end;

function THTreeNodes.AddFirst(Node: THTreeNode; const S: string): THTreeNode;
begin
  Result := AddObjectFirst(Node, S, nil);
end;

function THTreeNodes.AddObjectFirst(Node: THTreeNode; const S: string;
  Ptr: Pointer): THTreeNode;
begin
  if Node <> nil then Node := Node.Parent;
  Result := InternalAddObject(Node, S, Ptr, taAddFirst);
end;

function THTreeNodes.Add(Node: THTreeNode; const S: string): THTreeNode;
begin
  Result := AddObject(Node, S, nil);
end;

procedure THTreeNodes.Repaint(Node: THTreeNode);
var
  R: TRect;
begin
  if FUpdateCount < 1 then
  begin
    while (Node <> nil) and not Node.IsVisible do Node := Node.Parent;
    if Node <> nil then
    begin
      R := Node.DisplayRect(False);
      InvalidateRect(Owner.Handle, @R, True);
    end;
  end;
end;

function THTreeNodes.AddObject(Node: THTreeNode; const S: string;
  Ptr: Pointer): THTreeNode;
begin
  if Node <> nil then Node := Node.Parent;
  Result := InternalAddObject(Node, S, Ptr, taAdd);
end;

function THTreeNodes.Insert(Node: THTreeNode; const S: string): THTreeNode;
begin
  Result := InsertObject(Node, S, nil);
end;

procedure THTreeNodes.AddedNode(Value: THTreeNode);
begin
  if Value <> nil then
  begin
    Value.HasChildren := True;
    Repaint(Value);
  end;
end;

function THTreeNodes.InsertObject(Node: THTreeNode; const S: string;
  Ptr: Pointer): THTreeNode;
var
  Item, ItemId: HTreeItem;
  Parent: THTreeNode;
  AddMode: TAddMode;
begin
  Result := Owner.CreateNode;
  try
    Item := nil;
    ItemId := nil;
    Parent := nil;
    AddMode := taInsert;
    if Node <> nil then
    begin
      Parent := Node.Parent;
      if Parent <> nil then Item := Parent.ItemId;
      Node := Node.GetPrevSibling;
      if Node <> nil then ItemId := Node.ItemId
      else AddMode := taAddFirst;
    end;
    Result.Data := Ptr;
    Result.Text := S;
    Item := AddItem(Item, ItemId, CreateItem(Result), AddMode);
    if Item = nil then
      raise EOutOfResources.Create(sInsertError);
    Result.FItemId := Item;
    AddedNode(Parent);
  except
    Result.Free;
    raise;
  end;
end;

function THTreeNodes.InternalAddObject(Node: THTreeNode; const S: string;
  Ptr: Pointer; AddMode: TAddMode): THTreeNode;
var
  Item: HTreeItem;
begin
  Result := Owner.CreateNode;
  try
    if Node <> nil then Item := Node.ItemId
    else Item := nil;
    Result.Data := Ptr;
    Result.Text := S;
    Item := AddItem(Item, nil, CreateItem(Result), AddMode);
    if Item = nil then
      raise EOutOfResources.Create(sInsertError);
    Result.FItemId := Item;
    AddedNode(Node);
  except
    Result.Free;
    raise;
  end;
end;

function THTreeNodes.CreateItem(Node: THTreeNode): TTVItem;
begin
  Node.FInTree := True;
  with Result do
  begin
    mask := TVIF_TEXT or TVIF_PARAM or TVIF_IMAGE or TVIF_SELECTEDIMAGE;
    lParam := Longint(Node);
    pszText := LPSTR_TEXTCALLBACK;
    iImage := I_IMAGECALLBACK;
    iSelectedImage := I_IMAGECALLBACK;
  end;
end;

function THTreeNodes.AddItem(Parent, Target: HTreeItem;
  const Item: TTVItem; AddMode: TAddMode): HTreeItem;
var
  InsertStruct: TTVInsertStruct;
begin
  with InsertStruct do
  begin
    hParent := Parent;
    case AddMode of
      taAddFirst:
        hInsertAfter := TVI_FIRST;
      taAdd:
        hInsertAfter := TVI_LAST;
      taInsert:
        hInsertAfter := Target;
    end;
  end;
  InsertStruct.item := Item;
  Result := TreeView_InsertItem(Handle, InsertStruct);
end;

function THTreeNodes.GetFirstNode: THTreeNode;
begin
  Result := GetNode(TreeView_GetRoot(Handle));
end;

function THTreeNodes.GetNodeFromIndex(Index: Integer): THTreeNode;
begin
  Result := GetFirstNode;
  while (Index <> 0) and (Result <> nil) do
  begin
    Result := Result.GetNext;
    Dec(Index);
  end;
  if Result = nil then TreeViewError(sInvalidIndex);
end;

function THTreeNodes.GetNode(ItemId: HTreeItem): THTreeNode;
var
  Item: TTVItem;
begin
  with Item do
  begin
    hItem := ItemId;
    mask := TVIF_PARAM;
  end;
  if TreeView_GetItem(Handle, Item) then Result := THTreeNode(Item.lParam)
  else Result := nil;
end;

procedure THTreeNodes.SetItem(Index: Integer; Value: THTreeNode);
begin
  GetNodeFromIndex(Index).Assign(Value);
end;

procedure THTreeNodes.BeginUpdate;
begin
  if FUpdateCount = 0 then SetUpdateState(True);
  Inc(FUpdateCount);
end;

procedure THTreeNodes.SetUpdateState(Updating: Boolean);
begin
  SendMessage(Handle, WM_SETREDRAW, Ord(not Updating), 0);
  if Updating then
    with Owner do
    begin
      FSavedSort := SortType;
      SortType := stNone;
    end
  else
    with Owner do
    begin
      SortType := FSavedSort;
      Refresh;
    end;
end;

procedure THTreeNodes.EndUpdate;
begin
  Dec(FUpdateCount);
  if FUpdateCount = 0 then SetUpdateState(False);
end;

procedure THTreeNodes.Assign(Source: TPersistent);
var
  TreeNodes: THTreeNodes;
  MemStream: TMemoryStream;
begin
  if Source is THTreeNodes then
  begin
    TreeNodes := THTreeNodes(Source);
    Clear;
    MemStream := TMemoryStream.Create;
    try
      TreeNodes.WriteData(MemStream);
      MemStream.Position := 0;
      ReadData(MemStream);
    finally
      MemStream.Free;
    end;
  end
  else inherited Assign(Source);
end;

procedure THTreeNodes.DefineProperties(Filer: TFiler);

  function WriteNodes: Boolean;
  var
    I: Integer;
    Nodes: THTreeNodes;
  begin
    Nodes := THTreeNodes(Filer.Ancestor);
    Result := False;
    if (Nodes <> nil) and (Nodes.Count = Count) then
      for I := 0 to Count - 1 do
      begin
        Result := not Item[I].IsEqual(Nodes[I]);
        if Result then Exit;
      end
    else Result := Count > 0;
  end;

begin
  inherited DefineProperties(Filer);
  Filer.DefineBinaryProperty('Data', ReadData, WriteData, WriteNodes);
end;

procedure THTreeNodes.ReadData(Stream: TStream);
var
  I, Count: Integer;
  NodeInfo: TNodeInfo;
begin
  Clear;
  Stream.ReadBuffer(Count, SizeOf(Count));
  for I := 0 to Count - 1 do
    Add(nil, '').ReadData(Stream, @NodeInfo);
end;

procedure THTreeNodes.WriteData(Stream: TStream);
var
  I: Integer;
  Node: THTreeNode;
  NodeInfo: TNodeInfo;
begin
  I := 0;
  Node := GetFirstNode;
  while Node <> nil do
  begin
    Inc(I);
    Node := Node.GetNextSibling;
  end;
  Stream.WriteBuffer(I, SizeOf(I));
  Node := GetFirstNode;
  while Node <> nil do
  begin
    Node.WriteData(Stream, @NodeInfo);
    Node := Node.GetNextSibling;
  end;
end;

//色変え↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
function THTreeNodes.IsUpdating: Boolean;
begin
  Result := FUpdateCount > 0;
end;
//色変え↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑


//=========================================================================
//  TreeStrings
//=========================================================================
constructor THTreeStrings.Create(AOwner: THTreeNodes);
begin
  inherited Create;
  FOwner := AOwner;
end;

function THTreeStrings.Get(Index: Integer): string;
const
  TabChar = #9;
var
  Level, I: Integer;
  Node: THTreeNode;
begin
  Result := '';
  Node := Owner.GetNodeFromIndex(Index);
  Level := Node.Level;
  for I := 0 to Level - 1 do Result := Result + TabChar;
  Result := Result + Node.Text;
end;

function THTreeStrings.GetBufStart(Buffer: PChar; var Level: Integer): PChar;
begin
  Level := 0;
  while CharInSet(Buffer^, [' ', #9]) do
  begin
    Inc(Buffer);
    Inc(Level);
  end;
  Result := Buffer;
end;

function THTreeStrings.GetObject(Index: Integer): TObject;
begin
  Result := Owner.GetNodeFromIndex(Index).Data;
end;

procedure THTreeStrings.PutObject(Index: Integer; AObject: TObject);
begin
  Owner.GetNodeFromIndex(Index).Data := AObject;
end;

function THTreeStrings.GetCount: Integer;
begin
  Result := Owner.Count;
end;

procedure THTreeStrings.Clear;
begin
  Owner.Clear;
end;

procedure THTreeStrings.Delete(Index: Integer);
begin
  Owner.GetNodeFromIndex(Index).Delete;
end;

procedure THTreeStrings.SetUpdateState(Updating: Boolean);
begin
  SendMessage(Owner.Handle, WM_SETREDRAW, Ord(not Updating), 0);
  if not Updating then Owner.Owner.Refresh;
end;

function THTreeStrings.Add(const S: string): Integer;
var
  Level, OldLevel, I: Integer;
  NewStr: string;
  Node: THTreeNode;
begin
  Result := GetCount;
  if (Length(S) = 1) and (S[1] = Chr($1A)) then Exit;
  Node := nil;
  OldLevel := 0;
  NewStr := GetBufStart(PChar(S), Level);
  if Result > 0 then
  begin
    Node := Owner.GetNodeFromIndex(Result - 1);
    OldLevel := Node.Level;
  end;
  if (Level > OldLevel) or (Node = nil) then
  begin
    if Level - OldLevel > 1 then TreeViewError(sInvalidLevel);
  end
  else begin
    for I := OldLevel downto Level do
    begin
      Node := Node.Parent;
      if (Node = nil) and (I - Level > 0) then
        TreeViewError(sInvalidLevel);
    end;
  end;
  Owner.AddChild(Node, NewStr);
end;

procedure THTreeStrings.Insert(Index: Integer; const S: string);
begin
  with Owner do
    Insert(GetNodeFromIndex(Index), S);
end;

procedure THTreeStrings.LoadTreeFromStream(Stream: TStream);
var
  List: TStringList;
  ANode, NextNode: THTreeNode;
  ALevel, i: Integer;
  CurrStr: string;
begin
  List := TStringList.Create;
  Owner.BeginUpdate;
  try
    try
      Clear;
      List.LoadFromStream(Stream);
      ANode := nil;
      for i := 0 to List.Count - 1 do
      begin
        CurrStr := GetBufStart(PChar(List[i]), ALevel);
        if ANode = nil then
          ANode := Owner.AddChild(nil, CurrStr)
        else if ANode.Level = ALevel then
          ANode := Owner.AddChild(ANode.Parent, CurrStr)
        else if ANode.Level = (ALevel - 1) then
          ANode := Owner.AddChild(ANode, CurrStr)
        else if ANode.Level > ALevel then
        begin
          NextNode := ANode.Parent;
          while NextNode.Level > ALevel do
            NextNode := NextNode.Parent;
          ANode := Owner.AddChild(NextNode.Parent, CurrStr);
        end
        else TreeViewErrorFmt(sInvalidLevelEx, [ALevel, CurrStr]);
      end;
    finally
      Owner.EndUpdate;
      List.Free;
    end;
  except
    Owner.Owner.Invalidate;  // force repaint on exception
    raise;
  end;
end;

procedure THTreeStrings.SaveTreeToStream(Stream: TStream);
const
  TabChar = #9;
  EndOfLine = #13#10;
var
  i: Integer;
  ANode: THTreeNode;
  NodeStr: string;
begin
  if Count > 0 then
  begin
    ANode := Owner[0];
    while ANode <> nil do
    begin
      NodeStr := '';
      for i := 0 to ANode.Level - 1 do NodeStr := NodeStr + TabChar;
      NodeStr := NodeStr + ANode.Text + EndOfLine;
      Stream.Write(Pointer(NodeStr)^, Length(NodeStr));
      ANode := ANode.GetNext;
    end;
  end;
end;


//=========================================================================
//  HTreeView
//=========================================================================
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
function MakeNodeState(ItemStates: UINT): TNodeStates;
begin
  Result:=[];
  if (ItemStates and CDIS_SELECTED     ) <> 0 then Include(Result,nsSelected     );
  if (ItemStates and CDIS_CHECKED      ) <> 0 then Include(Result,nsChecked      );
  if (ItemStates and CDIS_FOCUS        ) <> 0 then Include(Result,nsFocused      );
//  if (ItemStates and CDIS_DISABLED     ) <> 0 then Include(Result,nsDisabled     );
//  if (ItemStates and CDIS_GRAYED       ) <> 0 then Include(Result,nsGrayed       );
//  if (ItemStates and CDIS_HOT          ) <> 0 then Include(Result,nsHot          );
//  if (ItemStates and CDIS_INDETERMINATE) <> 0 then Include(Result,nsIndeterminate);
//  if (ItemStates and CDIS_MARKED       ) <> 0 then Include(Result,nsMarked       );
end;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

constructor THTreeView.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
  ControlStyle := ControlStyle - [csCaptureMouse] + [csDisplayDragImage, csReflector];
  Width := 121;
  Height := 97;
  TabStop := True;
  ParentColor := False;
  FTreeNodes := THTreeNodes.Create(Self);
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
  FCheckBoxes := True;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  FBorderStyle := bsSingle;
  FShowButtons := True;
  FShowRoot := True;
  FShowLines := True;
  FHideSelection := True;
  FDragImage := TImageList.CreateSize(32, 32);
  FSaveIndent := -1;
  FEditInstance := MakeObjectInstance(EditWndProc);
  FImageChangeLink := TChangeLink.Create;
  FImageChangeLink.OnChange := ImageListChange;
  FStateChangeLink := TChangeLink.Create;
  FStateChangeLink.OnChange := ImageListChange;
//初期値↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
  Font.Name := 'ＭＳ 明朝';
  Font.Size := 10;
  ReadOnly := True;
  ShowButtons := False;
  ShowRoot := False;
  CheckBoxes := True;
  Height := 165;
  Width  := 221;
//初期値↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
end;

destructor THTreeView.Destroy;
begin
  Items.Free;
  FSaveItems.Free;
  FDragImage.Free;
  FMemStream.Free;
  FreeObjectInstance(FEditInstance);
  FImageChangeLink.Free;
  FStateChangeLink.Free;
  inherited Destroy;
end;

procedure THTreeView.CreateParams(var Params: TCreateParams);
const
  BorderStyles: array[TBorderStyle] of Integer = (0, WS_BORDER);
  LineStyles: array[Boolean] of Integer = (0, TVS_HASLINES);
  RootStyles: array[Boolean] of Integer = (0, TVS_LINESATROOT);
  ButtonStyles: array[Boolean] of Integer = (0, TVS_HASBUTTONS);
  EditStyles: array[Boolean] of Integer = (TVS_EDITLABELS, 0);
  HideSelections: array[Boolean] of Integer = (TVS_SHOWSELALWAYS, 0);
  DragStyles: array[TDragMode] of Integer = (TVS_DISABLEDRAGDROP, 0);
begin
  InitCommonControl(ICC_TREEVIEW_CLASSES);
  inherited CreateParams(Params);
  CreateSubClass(Params, WC_TREEVIEW);
  with Params do
  begin
    Integer(Style) := Integer(Style) or LineStyles[FShowLines] or BorderStyles[FBorderStyle] or
      RootStyles[FShowRoot] or ButtonStyles[FShowButtons] or
      EditStyles[FReadOnly] or HideSelections[FHideSelection] or
      DragStyles[DragMode];
//ヘルプを出さない↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    Style := Style or TVS_NOTOOLTIPS;
//ヘルプを出さない↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    if CheckBoxes then begin
      Style := Style or TVS_CHECKBOXES;
    end;  
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
    if Ctl3D and NewStyleControls and (FBorderStyle = bsSingle) then
    begin
      Style := Style and not WS_BORDER;
      ExStyle := Params.ExStyle or WS_EX_CLIENTEDGE;
    end;
    WindowClass.style := WindowClass.style and not (CS_HREDRAW or CS_VREDRAW);
  end;
end;

procedure THTreeView.CreateWnd;
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
var
  TempImages: TImageList;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
begin
  FStateChanging := False;
  inherited CreateWnd;
  if FMemStream <> nil then
  begin
    Items.ReadData(FMemStream);
    FMemStream.Destroy;
    FMemStream := nil;
    SetTopItem(Items.GetNodeFromIndex(FSaveTopIndex));
    FSaveTopIndex := 0;
    SetSelection(Items.GetNodeFromIndex(FSaveIndex));
    FSaveIndex := 0;
  end;
  if FSaveIndent <> -1 then Indent := FSaveIndent;
  if (Images <> nil) and Images.HandleAllocated then
    SetImageList(Images.Handle, TVSIL_NORMAL);
  if (StateImages <> nil) and StateImages.HandleAllocated then
    SetImageList(StateImages.Handle, TVSIL_STATE);
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
  if not Assigned(FImages) then begin
    TempImages := TImageList.Create(nil);
    try
      Images := TempImages;
      Images := nil;
    finally
      TempImages.Free;
    end;
  end;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
end;

procedure THTreeView.DestroyWnd;
var
  Node: THTreeNode;
begin
  FStateChanging := True;
  if Items.Count > 0 then
  begin
    FMemStream := TMemoryStream.Create;
    Items.WriteData(FMemStream);
    FMemStream.Position := 0;
    Node := GetTopItem;
    if Node <> nil then FSaveTopIndex := Node.AbsoluteIndex;
    Node := Selected;
    if Node <> nil then FSaveIndex := Node.AbsoluteIndex;
  end;
  FSaveIndent := Indent;
  inherited DestroyWnd;
end;

procedure THTreeView.EditWndProc(var Message: TMessage);
begin
  try
    with Message do
    begin
      case Msg of
        WM_KEYDOWN,
        WM_SYSKEYDOWN: if DoKeyDown(TWMKey(Message)) then Exit;
        WM_CHAR: if DoKeyPress(TWMKey(Message)) then Exit;
        WM_KEYUP,
        WM_SYSKEYUP: if DoKeyUp(TWMKey(Message)) then Exit;
        CN_KEYDOWN,
        CN_CHAR, CN_SYSKEYDOWN,
        CN_SYSCHAR:
          begin
            WndProc(Message);
            Exit;
          end;
      end;
      Result := CallWindowProc(FDefEditProc, FEditHandle, Msg, WParam, LParam);
    end;
  except
    Application.HandleException(Self);
  end;
end;

procedure THTreeView.CMColorChanged(var Message: TMessage);
begin
  inherited;
  RecreateWnd;
end;

procedure THTreeView.CMCtl3DChanged(var Message: TMessage);
begin
  inherited;
  if FBorderStyle = bsSingle then RecreateWnd;
end;

procedure THTreeView.CMSysColorChange(var Message: TMessage);
begin
  inherited;
  if not (csLoading in ComponentState) then
  begin
    Message.Msg := WM_SYSCOLORCHANGE;
    DefaultHandler(Message);
  end;
end;

function THTreeView.AlphaSort: Boolean;
var
  I: Integer;
begin
  if HandleAllocated then
  begin
    Result := CustomSort(nil, 0);
    for I := 0 to Items.Count - 1 do
      with Items[I] do
        if HasChildren then AlphaSort;
  end
  else Result := False;
end;

function THTreeView.CustomSort(SortProc: TTVCompare; Data: Longint): Boolean;
var
  SortCB: TTVSortCB;
  I: Integer;
  Node: THTreeNode;
begin
  Result := False;
  if HandleAllocated then
  begin
    with SortCB do
    begin
      if not Assigned(SortProc) then lpfnCompare := @DefaultTreeViewSort
      else lpfnCompare := SortProc;
      hParent := TVI_ROOT;
      lParam := Data;
      Result := TreeView_SortChildrenCB(Handle, SortCB, 0);
    end;
    for I := 0 to Items.Count - 1 do
    begin
      Node := Items[I];
      if Node.HasChildren then Node.CustomSort(SortProc, Data);
    end;
  end;
end;

procedure THTreeView.SetSortType(Value: TSortType);
begin
  if SortType <> Value then
  begin
    FSortType := Value;
    if ((SortType in [stData, stBoth]) and Assigned(OnCompare)) or
      (SortType in [stText, stBoth]) then
      AlphaSort;
  end;
end;

procedure THTreeView.SetStyle(Value: Integer; UseStyle: Boolean);
var
  Style: Integer;
begin
  if HandleAllocated then
  begin
    Style := GetWindowLong(Handle, GWL_STYLE);
    if not UseStyle then Style := Style and not Value
    else Style := Style or Value;
    SetWindowLong(Handle, GWL_STYLE, Style);
  end;
end;

procedure THTreeView.SetBorderStyle(Value: TBorderStyle);
begin
  if BorderStyle <> Value then
  begin
    FBorderStyle := Value;
    RecreateWnd;
  end;
end;

procedure THTreeView.SetDragMode(Value: TDragMode);
begin
  if Value <> DragMode then
    SetStyle(TVS_DISABLEDRAGDROP, Value = dmManual);
  inherited;
end;

//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
procedure THTreeView.SetCheckBoxes(Value: Boolean);
begin
  if CheckBoxes <> Value then
  begin
    FCheckBoxes := Value;
    SetStyle(TVS_CHECKBOXES, Value);
  end;
end;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

procedure THTreeView.SetButtonStyle(Value: Boolean);
begin
  if ShowButtons <> Value then
  begin
    FShowButtons := Value;
    SetStyle(TVS_HASBUTTONS, Value);
  end;
end;

procedure THTreeView.SetLineStyle(Value: Boolean);
begin
  if ShowLines <> Value then
  begin
    FShowLines := Value;
    SetStyle(TVS_HASLINES, Value);
  end;
end;

procedure THTreeView.SetRootStyle(Value: Boolean);
begin
  if ShowRoot <> Value then
  begin
    FShowRoot := Value;
    SetStyle(TVS_LINESATROOT, Value);
  end;
end;

procedure THTreeView.SetReadOnly(Value: Boolean);
begin
  if ReadOnly <> Value then
  begin
    FReadOnly := Value;
    SetStyle(TVS_EDITLABELS, not Value);
  end;
end;

procedure THTreeView.SetHideSelection(Value: Boolean);
begin
  if HideSelection <> Value then
  begin
    FHideSelection := Value;
    SetStyle(TVS_SHOWSELALWAYS, not Value);
    Invalidate;
  end;
end;

function THTreeView.GetNodeAt(X, Y: Integer): THTreeNode;
var
  HitTest: TTVHitTestInfo;
begin
  with HitTest do
  begin
    pt.X := X;
    pt.Y := Y;
    if TreeView_HitTest(Handle, HitTest) <> nil then
      Result := Items.GetNode(HitTest.hItem)
    else Result := nil;
  end;
end;

function THTreeView.GetHitTestInfoAt(X, Y: Integer): THitTests;
var
  HitTest: TTVHitTestInfo;
begin
  Result := [];
  with HitTest do
  begin
    pt.X := X;
    pt.Y := Y;
    TreeView_HitTest(Handle, HitTest);
    if (flags and TVHT_ABOVE) <> 0 then Include(Result, htAbove);
    if (flags and TVHT_BELOW) <> 0 then Include(Result, htBelow);
    if (flags and TVHT_NOWHERE) <> 0 then Include(Result, htNowhere);
    if (flags and TVHT_ONITEM) <> 0 then Include(Result, htOnItem);
    if (flags and TVHT_ONITEMBUTTON) <> 0 then Include(Result, htOnButton);
    if (flags and TVHT_ONITEMICON) <> 0 then Include(Result, htOnIcon);
    if (flags and TVHT_ONITEMINDENT) <> 0 then Include(Result, htOnIndent);
    if (flags and TVHT_ONITEMLABEL) <> 0 then Include(Result, htOnLabel);
    if (flags and TVHT_ONITEMRIGHT) <> 0 then Include(Result, htOnRight);
    if (flags and TVHT_ONITEMSTATEICON) <> 0 then Include(Result, htOnStateIcon);
    if (flags and TVHT_TOLEFT) <> 0 then Include(Result, htToLeft);
    if (flags and TVHT_TORIGHT) <> 0 then Include(Result, htToRight);
  end;
end;

procedure THTreeView.SetTreeNodes(Value: THTreeNodes);
begin
  Items.Assign(Value);
end;

procedure THTreeView.SetIndent(Value: Integer);
begin
  if Value <> Indent then TreeView_SetIndent(Handle, Value);
end;

function THTreeView.GetIndent: Integer;
begin
  Result := TreeView_GetIndent(Handle)
end;

procedure THTreeView.FullExpand;
var
  Node: THTreeNode;
begin
  Node := Items.GetFirstNode;
  while Node <> nil do
  begin
    Node.Expand(True);
    Node := Node.GetNextSibling;
  end;
end;

procedure THTreeView.FullCollapse;
var
  Node: THTreeNode;
begin
  Node := Items.GetFirstNode;
  while Node <> nil do
  begin
    Node.Collapse(True);
    Node := Node.GetNextSibling;
  end;
end;

procedure THTreeView.Loaded;
begin
  inherited Loaded;
  if csDesigning in ComponentState then FullExpand;
end;

function THTreeView.GetTopItem: THTreeNode;
begin
  if HandleAllocated then
    Result := Items.GetNode(TreeView_GetFirstVisible(Handle))
  else Result := nil;
end;

procedure THTreeView.SetTopItem(Value: THTreeNode);
begin
  if HandleAllocated and (Value <> nil) then
    TreeView_SelectSetFirstVisible(Handle, Value.ItemId);
end;

function THTreeView.GetSelection: THTreeNode;
begin
  if HandleAllocated then
  begin
    if FRightClickSelect and Assigned(FRClickNode) then
      Result := FRClickNode
    else
      Result := Items.GetNode(TreeView_GetSelection(Handle));
  end
  else Result := nil;
end;

procedure THTreeView.SetSelection(Value: THTreeNode);
begin
  if Value <> nil then Value.Selected := True
  else TreeView_SelectItem(Handle, nil);
end;

function THTreeView.GetDropTarget: THTreeNode;
begin
  if HandleAllocated then
  begin
    Result := Items.GetNode(TreeView_GetDropHilite(Handle));
    if Result = nil then Result := FLastDropTarget;
  end
  else Result := nil;
end;

procedure THTreeView.SetDropTarget(Value: THTreeNode);
begin
  if HandleAllocated then
    if Value <> nil then Value.DropTarget := True
    else TreeView_SelectDropTarget(Handle, nil);
end;

function THTreeView.GetNodeFromItem(const Item: TTVItem): THTreeNode;
begin
  with Item do
    if (state and TVIF_PARAM) <> 0 then Result := Pointer(lParam)
    else Result := Items.GetNode(hItem);
end;

function THTreeView.IsEditing: Boolean;
var
  ControlHand: HWnd;
begin
  ControlHand := TreeView_GetEditControl(Handle);
  Result := (ControlHand <> 0) and IsWindowVisible(ControlHand);
end;

procedure THTreeView.CNNotify(var Message: TWMNotify);
var
  Node: THTreeNode;
  MousePos: TPoint;
  HitTest: TTVHitTestInfo;
begin
  with Message.NMHdr^ do
    case code of
      TVN_BEGINDRAG:
        begin
          FDragged := True;
          with PNMTreeView(Pointer(Message.NMHdr))^ do
            FDragNode := GetNodeFromItem(ItemNew);
        end;
      TVN_BEGINLABELEDIT:
        begin
          with PTVDispInfo(Pointer(Message.NMHdr))^ do
            if Dragging or not CanEdit(GetNodeFromItem(item)) then
              Message.Result := 1;
          if Message.Result = 0 then
          begin
            FEditHandle := TreeView_GetEditControl(Handle);
            FDefEditProc := Pointer(GetWindowLong(FEditHandle, GWL_WNDPROC));
            SetWindowLong(FEditHandle, GWL_WNDPROC, LongInt(FEditInstance));
          end;
        end;
      TVN_ENDLABELEDIT:
        with PTVDispInfo(Pointer(Message.NMHdr))^ do
          Edit(item);
      TVN_ITEMEXPANDING:
        if not FManualNotify then
        begin
          with PNMTreeView(Pointer(Message.NMHdr))^ do
          begin
            Node := GetNodeFromItem(ItemNew);
            if (action = TVE_EXPAND) and not CanExpand(Node) then
              Message.Result := 1
            else if (action = TVE_COLLAPSE) and
              not CanCollapse(Node) then Message.Result := 1;
          end;
        end;
      TVN_ITEMEXPANDED:
        if not FManualNotify then
        begin
          with PNMTreeView(Pointer(Message.NMHdr))^ do
          begin
            Node := GetNodeFromItem(itemNew);
            if (action = TVE_EXPAND) then Expand(Node)
            else if (action = TVE_COLLAPSE) then Collapse(Node);
          end;
        end;
      TVN_SELCHANGING:
        with PNMTreeView(Pointer(Message.NMHdr))^ do
          if not CanChange(GetNodeFromItem(itemNew)) then
            Message.Result := 1;
      TVN_SELCHANGED:
        with PNMTreeView(Pointer(Message.NMHdr))^ do
          Change(GetNodeFromItem(itemNew));
      TVN_DELETEITEM:
        begin
          if not FStateChanging then
          begin
            with PNMTreeView(Pointer(Message.NMHdr))^ do
              Node := GetNodeFromItem(itemOld);
            if Node <> nil then
            begin
              Node.FItemId := nil;
              Items.Delete(Node);
            end;
          end;
        end;
      TVN_SETDISPINFO:
        with PTVDispInfo(Pointer(Message.NMHdr))^ do
        begin
          Node := GetNodeFromItem(item);
          if (Node <> nil) and ((item.mask and TVIF_TEXT) <> 0) then
            Node.Text := item.pszText;
        end;
      TVN_GETDISPINFO:
        with PTVDispInfo(Pointer(Message.NMHdr))^ do
        begin
          Node := GetNodeFromItem(item);
          if Node <> nil then
          begin
            if (item.mask and TVIF_TEXT) <> 0 then
              StrLCopy(item.pszText, PChar(Node.Text), item.cchTextMax);
            if (item.mask and TVIF_IMAGE) <> 0 then
            begin
              GetImageIndex(Node);
              item.iImage := Node.ImageIndex;
            end;
            if (item.mask and TVIF_SELECTEDIMAGE) <> 0 then
            begin
              GetSelectedIndex(Node);
              item.iSelectedImage := Node.SelectedIndex;
            end;
          end;
        end;
      NM_RCLICK:
        begin
          if RightClickSelect then
          begin
            GetCursorPos(MousePos);
            with PointToSmallPoint(ScreenToClient(MousePos)) do
            begin
              FRClickNode := GetNodeAt(X, Y);
              Perform(WM_RBUTTONUP, 0, MakeLong(X, Y));
            end;
          end
          else FRClickNode := Pointer(1);
        end;
//色変え↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
      NM_CUSTOMDRAW:
        begin
          case PNMTVCUSTOMDRAW(Pointer(Message.NMHdr))^.nmcd.dwDrawStage of
            CDDS_PREPAINT    : Message.Result := CDRF_NOTIFYITEMDRAW;
            CDDS_ITEMPREPAINT: begin
                                 Node := THTreeNode(PNMTVCUSTOMDRAW(Pointer(Message.NMHdr))^.nmcd.lItemlParam);
                                 if (Node <> nil) then begin
                                   if (Node.ParentFont <> True) then begin
                                     SelectObject(PNMTVCUSTOMDRAW(Pointer(Message.NMHdr))^.nmcd.hdc, Node.Font.Handle);
                                     PNMTVCUSTOMDRAW(Pointer(Message.NMHdr))^.clrText   := ColorToRGB(Node.Font.Color);
                                     if (Node.ParentColor <> True) then
                                       PNMTVCUSTOMDRAW(Pointer(Message.NMHdr))^.clrTextBk := ColorToRGB(Node.Color);
                                     Message.Result := CDRF_NEWFONT;
                                   end else begin
                                     Message.Result := CDRF_DODEFAULT;
                                   end;
                                 end else begin
                                   Message.Result := CDRF_DODEFAULT;
                                 end;
                               end;
          else Message.Result := CDRF_DODEFAULT;
          end;
        end;
//色変え↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
      NM_CLICK:
        begin
          GetCursorPos(MousePos);
          with PointToSmallPoint(ScreenToClient(MousePos)) do begin
            Node := GetNodeAt(X, Y);
            if (Node <> nil) then begin
              HitTest.pt.X := X;
              HitTest.pt.Y := Y;
              if (TreeView_HitTest(Handle, HitTest) <> nil) then begin
                //状態が変わっていたら
                if (HitTest.flags in [TVHT_ONITEMSTATEICON]) then begin
                  //子供を持っている場合、子供以下全てに反映させる
                  if not Node.Checked then xChildCheckOnOff(Node,1)   // Check On
                  else                     xChildCheckOnOff(Node,0);  // Check Off

                  //自分が子供だった場合、親にも反映させる
                  //(子に全てチェックが付いたら、親にもチェックを付ける
                  // 子の内どれかにチェックが付いていなかったら、親のチェックを外す)
                  if (Node.Level >= 1) then xParentCheckOnOff(Node,Node.ItemId);
                end;
              end;
            end;
          end;
        end;
      NM_CHAR:
        begin
          //これが効かないのでWMKeyDownで対処。
        end;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
    end;
end;

function THTreeView.GetDragImages: TDragImageList;
begin
  if FDragImage.Count > 0 then
    Result := FDragImage else
    Result := nil;
end;

procedure THTreeView.WndProc(var Message: TMessage);
begin
  if not (csDesigning in ComponentState) and ((Message.Msg = WM_LBUTTONDOWN) or
    (Message.Msg = WM_LBUTTONDBLCLK)) and not Dragging and (DragMode = dmAutomatic) then
  begin
    if not IsControlMouseMsg(TWMMouse(Message)) then
    begin
      ControlState := ControlState + [csLButtonDown];
      Dispatch(Message);
    end;
  end
  else inherited WndProc(Message);
end;

procedure THTreeView.DoStartDrag(var DragObject: TDragObject);
var
  ImageHandle: HImageList;
  DragNode: THTreeNode;
  P: TPoint;
begin
  inherited DoStartDrag(DragObject);
  DragNode := FDragNode;
  FLastDropTarget := nil;
  FDragNode := nil;
  if DragNode = nil then
  begin
    GetCursorPos(P);
    with ScreenToClient(P) do DragNode := GetNodeAt(X, Y);
  end;
  if DragNode <> nil then
  begin
    ImageHandle := TreeView_CreateDragImage(Handle, DragNode.ItemId);
    if ImageHandle <> 0 then
      with FDragImage do
      begin
        Handle := ImageHandle;
        SetDragImage(0, 2, 2);
      end;
  end;
end;

procedure THTreeView.DoEndDrag(Target: TObject; X, Y: Integer);
begin
  inherited DoEndDrag(Target, X, Y);
  FLastDropTarget := nil;
end;

procedure THTreeView.CMDrag(var Message: TCMDrag);
begin
  inherited;
  with Message, DragRec^ do
    case DragMessage of
      dmDragMove: with ScreenToClient(Pos) do DoDragOver(Source, X, Y, Message.Result<>0);
      dmDragLeave:
        begin
          TDragObject(Source).HideDragImage;
          FLastDropTarget := DropTarget;
          DropTarget := nil;
          TDragObject(Source).ShowDragImage;
        end;
      dmDragDrop: FLastDropTarget := nil;
    end;
end;

procedure THTreeView.DoDragOver(Source: TDragObject; X, Y: Integer; CanDrop: Boolean);
var
  Node: THTreeNode;
begin
  Node := GetNodeAt(X, Y);
  if (Node <> nil) and
    ((Node <> DropTarget) or (Node = FLastDropTarget)) then
  begin
    FLastDropTarget := nil;
    TDragObject(Source).HideDragImage;
    Node.DropTarget := CanDrop;
    TDragObject(Source).ShowDragImage;
  end;
end;

procedure THTreeView.GetImageIndex(Node: THTreeNode);
begin
  if Assigned(FOnGetImageIndex) then FOnGetImageIndex(Self, Node);
end;

procedure THTreeView.GetSelectedIndex(Node: THTreeNode);
begin
  if Assigned(FOnGetSelectedIndex) then FOnGetSelectedIndex(Self, Node);
end;

function THTreeView.CanChange(Node: THTreeNode): Boolean;
begin
  Result := True;
  if Assigned(FOnChanging) then FOnChanging(Self, Node, Result);
end;

procedure THTreeView.Change(Node: THTreeNode);
begin
  if Assigned(FOnChange) then FOnChange(Self, Node);
end;

procedure THTreeView.Expand(Node: THTreeNode);
begin
  if Assigned(FOnExpanded) then FOnExpanded(Self, Node);
end;

function THTreeView.CanExpand(Node: THTreeNode): Boolean;
begin
  Result := True;
  if Assigned(FOnExpanding) then FOnExpanding(Self, Node, Result);
end;

procedure THTreeView.Collapse(Node: THTreeNode);
begin
  if Assigned(FOnCollapsed) then FOnCollapsed(Self, Node);
end;

function THTreeView.CanCollapse(Node: THTreeNode): Boolean;
begin
//閉じない↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
//  Result := True;
  Result := False;
//閉じない↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
  if Assigned(FOnCollapsing) then FOnCollapsing(Self, Node, Result);
end;

function THTreeView.CanEdit(Node: THTreeNode): Boolean;
begin
  Result := True;
  if Assigned(FOnEditing) then FOnEditing(Self, Node, Result);
end;

procedure THTreeView.Edit(const Item: TTVItem);
var
  S: string;
  Node: THTreeNode;
begin
  with Item do
    if pszText <> nil then
    begin
      S := pszText;
      Node := GetNodeFromItem(Item);
      if Assigned(FOnEdited) then FOnEdited(Self, Node, S);
      if Node <> nil then Node.Text := S;
    end;
end;

function THTreeView.CreateNode: THTreeNode;
begin
  Result := THTreeNode.Create(Items);
end;

procedure THTreeView.SetImageList(Value: HImageList; Flags: Integer);
begin
  if HandleAllocated then TreeView_SetImageList(Handle, Value, Flags);
end;

procedure THTreeView.ImageListChange(Sender: TObject);
var
  ImageHandle: HImageList;
begin
  if HandleAllocated then
  begin
    ImageHandle := TImageList(Sender).Handle;
    if Sender = Images then
      SetImageList(ImageHandle, TVSIL_NORMAL)
    else if Sender = StateImages then
      SetImageList(ImageHandle, TVSIL_STATE);
  end;
end;

procedure THTreeView.Notification(AComponent: TComponent;
  Operation: TOperation);
begin
  inherited Notification(AComponent, Operation);
  if Operation = opRemove then
  begin
    if AComponent = Images then Images := nil;
    if AComponent = StateImages then StateImages := nil;
  end;
end;

procedure THTreeView.SetImages(Value: TImageList);
begin
  if Images <> nil then
    Images.UnRegisterChanges(FImageChangeLink);
  FImages := Value;
  if Images <> nil then
  begin
    Images.RegisterChanges(FImageChangeLink);
    SetImageList(Images.Handle, TVSIL_NORMAL)
  end
  else SetImageList(0, TVSIL_NORMAL);
end;

procedure THTreeView.SetStateImages(Value: TImageList);
begin
  if StateImages <> nil then
    StateImages.UnRegisterChanges(FStateChangeLink);
  FStateImages := Value;
  if StateImages <> nil then
  begin
    StateImages.RegisterChanges(FStateChangeLink);
    SetImageList(StateImages.Handle, TVSIL_STATE)
  end
//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
//  else SetImageList(0, TVSIL_STATE);
  else
  begin
    SetImageList(0, TVSIL_STATE);
    RecreateWnd;
  end;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
end;

procedure THTreeView.LoadFromFile(const FileName: string);
var
  Stream: TStream;
begin
  Stream := TFileStream.Create(FileName, fmOpenRead);
  try
    LoadFromStream(Stream);
  finally
    Stream.Free;
  end;
end;

procedure THTreeView.LoadFromStream(Stream: TStream);
begin
  with THTreeStrings.Create(Items) do
    try
      LoadTreeFromStream(Stream);
    finally
      Free;
  end;
end;

procedure THTreeView.SaveToFile(const FileName: string);
var
  Stream: TStream;
begin
  Stream := TFileStream.Create(FileName, fmCreate);
  try
    SaveToStream(Stream);
  finally
    Stream.Free;
  end;
end;

procedure THTreeView.SaveToStream(Stream: TStream);
begin
  with THTreeStrings.Create(Items) do
    try
      SaveTreeToStream(Stream);
    finally
      Free;
  end;
end;

procedure THTreeView.WMRButtonDown(var Message: TWMRButtonDown);
var
  MousePos: TPoint;
begin
  FRClickNode := nil;
  try
    if not RightClickSelect then
    begin
      inherited;
      if FRClickNode <> nil then
      begin
        GetCursorPos(MousePos);
        with PointToSmallPoint(ScreenToClient(MousePos)) do
          Perform(WM_RBUTTONUP, 0, MakeLong(X, Y));
      end;
    end
    else DefaultHandler(Message);
  finally
    FRClickNode := nil;

  end;
end;

procedure THTreeView.WMRButtonUp(var Message: TWMRButtonUp);

  procedure DoMouseDown(var Message: TWMMouse; Button: TMouseButton;
    Shift: TShiftState);
  begin
    if not (csNoStdEvents in ControlStyle) then
      with Message do
        MouseDown(Button, KeysToShiftState(Keys) + Shift, XPos, YPos);
  end;

begin
  if RightClickSelect then DoMouseDown(Message, mbRight, []);
  inherited;
end;

procedure THTreeView.WMLButtonDown(var Message: TWMLButtonDown);
var
  Node: THTreeNode;
  MousePos: TPoint;
begin
  FDragged := False;
  FDragNode := nil;
  try
    inherited;
    if DragMode = dmAutomatic then
    begin
      SetFocus;
      if not FDragged then
      begin
        GetCursorPos(MousePos);
        with PointToSmallPoint(ScreenToClient(MousePos)) do
          Perform(WM_LBUTTONUP, 0, MakeLong(X, Y));
      end
      else begin
        Node := GetNodeAt(Message.XPos, Message.YPos);
        if Node <> nil then
        begin
          Node.Focused := True;
          Node.Selected := True;
          BeginDrag(False);
        end;
      end;
    end;
  finally
    FDragNode := nil;
  end;
end;

//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
procedure THTreeView.WMKeyDown(var Message: TWMKeyDown);
var
  Node: THTreeNode;
begin
  inherited;

  if (Message.CharCode = VK_SPACE) then begin
    Node := Selected;
    if (Node <> nil) then begin
      //子供を持っている場合、子供以下全てに反映させる
      if (Node.Checked) then xChildCheckOnOff(Node,1)
      else                   xChildCheckOnOff(Node,0);

      //自分が子供だった場合、親にも反映させる
      //(子に全てチェックが付いたら、親にもチェックを付ける
      // 子の内どれかにチェックが付いていなかったら、親のチェックを外す)
      if (Node.Level >= 1) then xParentCheckOnOff(Node,nil);
    end;
  end;
end;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

procedure THTreeView.WMNotify(var Message: TWMNotify);
var
  Node: THTreeNode;
  MaxTextLen: Integer;
  Pt: TPoint;
begin
  with Message do
    if NMHdr^.code = TTN_NEEDTEXTW then
    begin
      // Work around NT COMCTL32 problem with tool tips >= 80 characters
      GetCursorPos(Pt);
      Pt := ScreenToClient(Pt);
      Node := GetNodeAt(Pt.X, Pt.Y);
      if (Node = nil) or (Node.Text = '') then Exit;
      FWideText := Node.Text;
      MaxTextLen := SizeOf(PToolTipTextW(NMHdr)^.szText) div SizeOf(WideChar);
      if Length(FWideText) >= MaxTextLen then
        SetLength(FWideText, MaxTextLen - 1);
      PToolTipTextW(NMHdr)^.lpszText := PWideChar(FWideText);
      FillChar(PToolTipTextW(NMHdr)^.szText, MaxTextLen, 0);
      Move(Pointer(FWideText)^, PToolTipTextW(NMHdr)^.szText, Length(FWideText));
      PToolTipTextW(NMHdr)^.hInst := 0;
      SetWindowPos(NMHdr^.hwndFrom, HWND_TOP, 0, 0, 0, 0, SWP_NOACTIVATE or
        SWP_NOSIZE or SWP_NOMOVE);
      Result := 1;
    end
    else inherited;
end;

//チェックボックスを付ける↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
procedure THTreeView.xChildCheckOnOff(SelectNode: THTreeNode; iMode: Integer);
var
  ChildNode: THTreeNode;
begin
  //子供を持っている場合、子供以下全てに反映させる
  if (SelectNode.HasChildren = True) then begin
    ChildNode := SelectNode.GetFirstChild;
    while (ChildNode <> nil) do begin
      if (iMode = 1) then ChildNode.Checked := True
      else                ChildNode.Checked := False;
      xChildCheckOnOff(ChildNode,iMode);
      ChildNode := SelectNode.GetNextChild(ChildNode);
    end;
  end;
end;

procedure THTreeView.xParentCheckOnOff(SelectNode: THTreeNode; AItemId: HTreeItem);
var
  bFlg: Boolean;
  ParentNode, ChildNode: THTreeNode;
begin
  ParentNode := SelectNode.Parent;  //親ノード取得

  bFlg := True;  //子供にチェックが付いているか  True:全てにチェックが付いている

  //子を検索
  ChildNode := ParentNode.GetFirstChild;
  while (ChildNode <> nil) do begin
    if (ChildNode.ItemId = AItemId) then begin  //←今選択したノードはチェックがまだ付いていない為
      if ChildNode.Checked then bFlg := False;
    end else begin
      if not ChildNode.Checked then bFlg := False;
    end;

    ChildNode := ParentNode.GetNextChild(ChildNode);
  end;
  ParentNode.Checked := bFlg;

  //自分が子供だった場合、
  if (ParentNode.Level >= 1) then xParentCheckOnOff(ParentNode,AItemId);
end;
//チェックボックスを付ける↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

end.
