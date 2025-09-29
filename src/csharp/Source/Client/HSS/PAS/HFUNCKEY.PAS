unit HFuncKey;
//**********************************************************************//
// System           :   システム共通                                    //
// Sub System       :   HSS部品                                         //
// Program name     :   Function Key コンポーネント                     //
//                  :   HFuncKey                                        //
// Programer        :   鹿野　幸生                                      //
// Date             :   2000.10.12                                      //
//----------------------------------------------------------------------//
// Update Note      :   2001.01.10  鹿野　幸生                          //
//                  :   ① Shiftキー等が押されている状態でFキーが押され //
//                  :      先にShiftキー等が離された時、Shiftキー等が   //
//                  :      効かなくなる障害を解除。                     //
//                  :   2001.01.10  鹿野　幸生                          //
//                  :   ① Shiftキー等が押されている状態でFキーが押され //
//                  :      先にShiftキー等が離された時、Shiftキー等が   //
//                  :      効かなくなる障害を解除。                     //
//                  :   2001.02.20  鹿野　幸生                          //
//                  :   ① Windows2000でHFuncKeyのPaint処理が上手く行え //
//                  :      ない障害を解除                               //
//                  :   2001.03.09  鹿野　幸生                          //
//                  :   ① BitmapのFreeの際、正しく再描画が行われない   //
//                  :      障害を解除                                   //
//                  :   2001.07.16  鹿野　幸生                          //
//                  :   ① Shiftキー系の制御がおかしくなっていた        //
//                  :      障害を解除                                   //
//                  :   2002.11.13  鹿野　幸生                          //
//                  :   ① 親コントロールのDoubleBufferedを制御するプロ //
//                  :      パティの追加                                 //
//                  :   ② マウス通過時のボタンリリース時間を設定する   //
//                  :      プロパティの追加                             //
//                  :   ③ ImageListセット系のプロパティ不正を修正      //
//                  :   2009.08.12  鹿野　幸生                          //
//                  :   ① HSS100対応                                   //
//----------------------------------------------------------------------//
//                (c)Copyright  2000 TSUBASA SYSTEM Co,. Ltd            //
//**********************************************************************//

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  Imm, HSpdExtBtn, Buttons, StdCtrls, ExtCtrls, HVersion;

const
  ctMaxBtnCnt   = 20;                                                  // ボタン最大個数
  ctDefBtnCnt   = 12;                                                  // ボタンデフォルト数
  ctSplitWidth  = 3;                                                   // スプリット幅

  // シフトステータス
  ctSS_NORMAL   = 0;                                                   // 通常状態
  ctSS_SHIFT    = 1;                                                   // シフトキー押下状態
  ctSS_CTRL     = 2;                                                   // CTRLキー押下状態
  ctSS_ALT      = 3;                                                   // ALTキー押下状態

type

  EHFuncKeyException = class(Exception);

  // ファンクションキー押下クリックイベント
  TCustomFuncKeyEvent = procedure (Sender: TObject; FuncKeyNo: integer; Shift: TShiftState) of object;
  TCustomMouseEvent   = procedure (Sender: TObject; Button: TMouseButton; Shift: TShiftState;
                                     X, Y: Integer; var Cancel: Boolean) of object;
  TCustomKeyEvent     = procedure (Sender: TObject; FuncKeyNo: integer;
                                     Shift: TShiftState; var Cancel: boolean) of object;

  // 自分のプロシージャ定義 (Keyフックで使用する)
  TOnFormKeyUp        = procedure (Sender: TObject; var Key: Word;  Shift: TShiftState) of object;
  TOnFormKeyDown      = procedure (Sender: TObject; var Key: Word;  Shift: TShiftState) of object;

  // CaptionStringクラス
  TCaptionStrings = Class(TStrings)
  private
    FCaptionString: TStringList;
    FCount:         integer;
    FOnChange:      TNotifyEvent;
  protected
    Function  Get(Index: Integer): string; Override;
    Function  GetCount: Integer; Override;
//    procedure Put(Index: Integer; const S: string); override;
  public
    Constructor Create;
    Destructor  Destroy; Override;
    Procedure   Clear; Override;
    Procedure   Delete(Index: Integer); Override;
    Procedure   Insert(Index: Integer; const S: string); Override;
    function    Add(const S: string): Integer; Override;
  published
    property    OnChange: TNotifyEvent read FOnChange write FOnChange;
  end;

  // ＦｕｎｃＫｅｙクラス
  THFuncKey = class(TCustomPanel)
  private
    // ボタン押下状態から脱出する為のタイマー
    CustomTimer:     TTimer;
    // 自分のプロパティ群
    FForm:           TForm;
    FColor:          TColor;
    FBackColor:      TColor;
    FCaptions:       TCaptionStrings;
    FShiftCaptions:  TCaptionStrings;
    FCtrlCaptions:   TCaptionStrings;
    FAltCaptions:    TCaptionStrings;
    FbBtnCaptionWrap:boolean;                                      // キャプション文字列のラップ処理
    FnSplit:         integer;
    FnSplitWidth:    integer;
    FnBtnCount:      integer;
    FnBtnWidth:      integer;
    FnBtnHeight:     integer;
    FImageList:      TImageList;
    FShiftImageList: TImageList;
    FCtrlImageList:  TImageList;
    FAltImageList:   TImageList;
    FnNoUseBtn:      integer;                                      // 宣言後未使用ボタン
    FbBtnAllowShiftKey: boolean;
    FbBtnAllowCtrlKey: boolean;
    FbBtnAllowAltKey: boolean;
    FbBtnAllowKey:   boolean;
    FnBtnOnPressed:  integer;                                      // 現在ボタンが押されているNo
    FnBtnMouseDowned:integer;                                      // 現在マウスが押されているNo
    FShiftState:     TShiftState;                                  // 現在押されているシフトキー状態
    FnActiveBtnNo:   integer;                                      // 現在押されているボタン
    FVersion:        TVersion;                                     // ﾊﾞｰｼﾞｮﾝ
    fbOnReSize:      boolean;                                      // ボタン位置計算中
    // 他コンポーネントのイベント横取り群
    FOnBtnMouseDown: TMouseEvent;
    FOnBtnMouseMove: TMouseMoveEvent;
    FOnBtnMouseUp:   TMouseEvent;
    FOnBtnClick:     TNotifyEvent;
    FReleaseTime:    cardinal;
    // SpeedExtBtnに渡すプロパティ群
    FColors:         THExtBtnColor;                                //デフォルトの背景色
    FActiveColor:    TColor;                                       //アイコンが光った時の色
    FFrameType:      TFrameType;                                   //フレームの種類
    FTransparent:    Boolean;                                      //透過有効・無効
    FActiveFrame:    Boolean;                                      //アクティブなフレーム描画を行うかどうか
    FUpFrame:        Boolean;                                      //上がった状態のフレーム描画を行うかどうか
    FDownFrame:      Boolean;                                      //下がった状態のフレーム描画を行うかどうか
    FActiveImage:    TActiveImageType;
    FDisabledImage:  TDisabledImageType;                           //使用不可の時の表示メソッド
    FDisabledShadow: TColor;                                       //使用不可のシャドウ色
    FDisabledHighlight: TColor;                                    //使用不可のハイライト色
    FFontHighlight:  TColor;                                       //フォントのハイライト色
    FFontShadow:     TColor;                                       //フォントのシャドウ色
    FActiveFont:     TFont;                                        //アクティブ文字スタイル
    FLayout:         TButtonLayout;                                //レイアウト
    FPressedColors:  THExtBtnColor;                                //押した時の背景色
    FBtnAutoEnable:  boolean;                                      //ボタンのEnabledコントロールを自動で行うか?
    BtnBitmap:       array [0..ctMaxBtnCnt-1] of TBitmap;
    BtnShiftBitmap:  array [0..ctMaxBtnCnt-1] of TBitmap;
    BtnCtrlBitmap:   array [0..ctMaxBtnCnt-1] of TBitmap;
    BtnAltBitmap:    array [0..ctMaxBtnCnt-1] of TBitmap;
    HSpeedExtBtn:    array [0..ctMaxBtnCnt-1] of THSpeedExtButton;
    FCtrlDoubleBuffered: boolean;                                               // 2002.11.13 追加
    // 状態フラグ
    FbRepaintNow:    boolean;
    // イベント
    FOnClickFuncKey: TCustomFuncKeyEvent;                           // クリックメッセージ
    FOnMouseDown:    TCustomMouseEvent;                             // MouseDownメッセージ
    FOnMouseUp:      TCustomMouseEvent;                             // MouseUpメッセージ
    FOnMouseMove:    TMouseMoveEvent;                               // MouseMoveメッセージ
    FOnKeyDown:      TCustomKeyEvent;                               // KeyDownメッセージ
    FOnKeyUp:        TCustomKeyEvent;                               // KeyUpメッセージ
    BtnEnable:       array [0..ctMaxBtnCnt-1] of boolean;
    BtnShiftEnable:  array [0..ctMaxBtnCnt-1] of boolean;
    BtnCtrlEnable:   array [0..ctMaxBtnCnt-1] of boolean;
    BtnAltEnable:    array [0..ctMaxBtnCnt-1] of boolean;
    // プロパティセット関数
//    procedure   SetColors(value: THExtBtnColor);
    procedure   SetColorsOnChange(Sender: TObject);
    procedure   SetActiveColor(value: TColor);
    procedure   SetActiveFrame(value: Boolean);
    procedure   SetUpFrame(value: Boolean);
    procedure   SetDownFrame(value: Boolean);
    procedure   SetFrameType(value: TFrameType);
    procedure   SetTransparent(value: Boolean);
    procedure   SetFontHighlight(value: TColor);
    procedure   SetFontShadow(value: TColor);
    procedure   SetLayout(value: TButtonLayout);
//    procedure   SetPressedColors(value: THExtBtnColor);
    procedure   SetPressedColorsOnChange(Sender: TObject);
    procedure   FontsAndColorsOnChange(Sender: TObject);
    procedure   SetActiveImage(value: TActiveImageType);
    procedure   SetDisabledImage(value: TDisabledImageType);
    procedure   SetDisabledHighlight(value: TColor);
    procedure   SetDisabledShadow(value: TColor);
    // 自分のプロパティのプロシージャ群
    function    CreateBtnCtrl(Sender: TComponent; inStrtIdx, inEndIdx: integer): integer;
    function    RemoveBtnCtrl(Sender: TComponent; inEndIdx: integer): integer;
    function    SetBtnProperty: integer;
    procedure   SetBtnCount(value: integer);
    procedure   SetBtnWidth(value: integer);
    procedure   SetBtnHeight(value: integer);
    procedure   SetActiveFont(value: TFont);
    procedure   DoPaintCtrl;
    procedure   SetBtnCaption(value:TCaptionStrings);
    procedure   SetBtnShiftCaption(value:TCaptionStrings);
    procedure   SetBtnCtrlCaption(value:TCaptionStrings);
    procedure   SetBtnAltCaption(value:TCaptionStrings);
    procedure   SetBtnAllowKey(value:boolean);
    function    GetBtnEnabled(index:integer): boolean;
    procedure   SetBtnEnabled(index:integer; value:boolean);
    function    GetBtnShiftEnabled(index:integer): boolean;
    procedure   SetBtnShiftEnabled(index:integer; value:boolean);
    function    GetBtnCtrlEnabled(index:integer): boolean;
    procedure   SetBtnCtrlEnabled(index:integer; value:boolean);
    function    GetBtnAltEnabled(index:integer): boolean;
    procedure   SetBtnAltEnabled(index:integer; value:boolean);
    procedure   SetSplitWidth(value:integer);
    procedure   SetImageList(value: TImageList);
    procedure   SetShiftImageList(value: TImageList);
    procedure   SetCtrlImageList(value: TImageList);
    procedure   SetAltImageList(value: TImageList);
    procedure   SetBackColor(value: TColor);
    function    CalcBtnPos: integer;
    procedure   SetDoubleBuffered(value:boolean);                               // 2002.11.13 追加
    procedure   SetReleaseTime(value: cardinal);                                // 2002.11.13 追加
    // ボタン監視タイマープロシージャ
    procedure   OnBtnForceUp(Sender: TObject);
    // 横取りプロシージャ
    procedure   BtnMouseMove(Sender: TObject;  Shift: TShiftState;X, Y: Integer);
    procedure   BtnMouseUp(Sender: TObject; Button: TMouseButton; Shift: TShiftState;X, Y: Integer);
    procedure   BtnMouseDown(Sender: TObject; Button: TMouseButton; Shift: TShiftState;X, Y: Integer);
    procedure   BtnClick(Sender: TObject);
    procedure   OnCaptionChange(Sender: TObject);
  protected
    procedure  Paint;override;
    procedure  WMSize(var Msg:TWMSize); message WM_SIZE;
//    procedure  WMKeyDown(var Message: TWMKeyDown); message WM_KEYDOWN;
//    procedure  WMKeyUp(var Message: TWMKeyUp); message WM_KEYUP;
    procedure  OnFormKeyUp(Sender: TObject; var Key: Word;  Shift: TShiftState);
    procedure  OnFormKeyDown(Sender: TObject; var Key: Word;  Shift: TShiftState);
    procedure  DoButtonClick(FuncKeyNo:integer; Shift: TShiftState);
    procedure  CMFontChanged(var Message: TMessage); message CM_FONTCHANGED ;
    procedure  CMTextChanged(var Message: TMessage); message CM_TEXTCHANGED ;
    procedure  CMButtonPressed(var Message: TMessage); message CM_BUTTONPRESSED ;
    procedure  CMEnabledChanged(var Message: TMessage); message CM_ENABLEDCHANGED;
    procedure  Loaded; override;
  public
    // 自分のプロシージャ群
    constructor Create(AOwner: TComponent);override;
    destructor  Destroy;override;
//    procedure   RePaint;override;           //  2009.08.12 変更
    procedure   Repaint;override;             //  2009.08.12 変更
    // SpeedExtBtnに渡すプロシージャ群
    function    LoadBtnImage(inShiftState, inIdx: integer; ihBm:TBitmap): integer;
    function    LoadBtnImageFromResourceID(inShiftState, inIdx: integer; iInstance: THandle; iResID: Integer): integer;
    function    LoadBtnImageFromFile(inShiftState, inIdx: integer; istrFileName:string): integer;
    function    FreeBtnImage(inShiftState, inIdx: integer): integer;
    // 自分のプロパティ群
    property    BtnAutoEnable: boolean read FBtnAutoEnable write FBtnAutoEnable  default True;
    property    BtnEnabled[index:integer]:      boolean  read GetBtnEnabled      write SetBtnEnabled;
    property    BtnShiftEnabled[index:integer]: boolean  read GetBtnShiftEnabled write SetBtnShiftEnabled;
    property    BtnCtrlEnabled[index:integer]:  boolean  read GetBtnCtrlEnabled  write SetBtnCtrlEnabled;
    property    BtnAltEnabled[index:integer]:   boolean  read GetBtnAltEnabled   write SetBtnAltEnabled;
  Published
    // 自分のプロパティ群
    property  BtnWidth:          integer     read FnBtnWidth         write SetBtnWidth;
    property  BtnHeight:         integer     read FnBtnHeight        write SetBtnHeight;
    property  BtnCount:          integer     read FnBtnCount         write SetBtnCount;
    property  BtnCaptions:       TCaptionstrings    read FCaptions          write SetBtnCaption;
    property  BtnShiftCaptions:  TCaptionstrings    read FShiftCaptions     write SetBtnShiftCaption;
    property  BtnCtrlCaptions:   TCaptionstrings    read FCtrlCaptions      write SetBtnCtrlCaption;
    property  BtnAltCaptions:    TCaptionstrings    read FAltCaptions       write SetBtnAltCaption;
    property  BtnImageList:      TImageList  read FImageList         write SetImageList;
    property  BtnShiftImageList: TImageList  read FShiftImageList    write SetShiftImageList;
    property  BtnCtrlImageList:  TImageList  read FCtrlImageList     write SetCtrlImageList;
    property  BtnAltImageList:   TImageList  read FAltImageList      write SetAltImageList;
    property  BtnAllowShiftKey:  boolean     read FbBtnAllowShiftKey write FbBtnAllowShiftKey;
    property  BtnAllowCtrlKey:   boolean     read FbBtnAllowCtrlKey  write FbBtnAllowCtrlKey;
    property  BtnAllowAltKey:    boolean     read FbBtnAllowAltKey   write FbBtnAllowAltKey;
    property  BtnAllowKey:       boolean     read FbBtnAllowKey      write SetBtnAllowKey;
    property  BtnCaptionWrap:    boolean     read FbBtnCaptionWrap   write FbBtnCaptionWrap default True;
    property  SplitWidth:        integer     read FnSplitWidth       write SetSplitWidth;
    property  BackColor:         TColor      read FBackColor         write SetBackColor;
    property  Version:           TVersion    read FVersion           write FVersion stored False;
    // 自分のイベントプロパティ群
    property  OnMouseDown:TCustomMouseEvent  read FOnMouseDown       write FOnMouseDown;
    property  OnMouseUp:TCustomMouseEvent    read FOnMouseUp         write FOnMouseUp;
    property  OnMouseMove:TMouseMoveEvent    read FOnMouseMove       write FOnMouseMove;
    property  OnClickFuncKey:TCustomFuncKeyEvent read FOnClickFuncKey  write FOnClickFuncKey;
    property  OnKeyDown:TCustomKeyEvent      read FOnKeyDown         write FOnKeyDown;
    property  OnKeyUp:TCustomKeyEvent        read FOnKeyUp           write FOnKeyUp;
    property  CtrlDoubleBuffered: boolean    read FCtrlDoubleBuffered write SetDoubleBuffered; // 2002.11.13 追加
    property  ReleaseTime:  cardinal         read FReleaseTime        write SetReleaseTime;    // 2002.11.13 追加
    // SpeedExtBtnに渡すプロパティ群
//    property  Colors: THExtBtnColor read FColors      write SetColors;
    property  Colors: THExtBtnColor read FColors      write FColors;
    property  FrameType: TFrameType read FFrameType   write SetFrameType   default ftNormalFrame ;
    property  Transparent: Boolean  read FTransparent write SetTransparent default False ;
    property  ActiveFrame: Boolean  read FActiveFrame write SetActiveFrame default True ;
    property  UpFrame: Boolean      read FUpFrame     write SetUpFrame     default True ;
    property  DownFrame: Boolean    read FDownFrame   write SetDownFrame   default True;
    property  ActiveImage: TActiveImageType
                                    read FActiveImage write SetActiveImage default aiFrameLight ;
    property  DisabledImage: TDisabledImageType
                                    read FDisabledImage write SetDisabledImage default diDefault ;
    property  DisabledHighlight: TColor
                                    read FDisabledHighlight write SetDisabledHighlight default clBtnHighlight ;
    property  DisabledShadow: TColor
                                    read FDisabledShadow write SetDisabledShadow default clBtnShadow ;
    property  FontHighlight: TColor read FFontHighlight write SetFontHighlight default clNone;
    property  FontShadow: TColor    read FFontShadow write SetFontShadow default clNone ;
    property  Layout: TButtonLayout read FLayout     write SetLayout default blGlyphLeft ;
//    property  PressedColors: THExtBtnColor read FPressedColors write SetPressedColors ;
    property  PressedColors: THExtBtnColor read FPressedColors write FPressedColors;
    property  ActiveFont: TFont            read FActiveFont    write SetActiveFont ;
    property  ActiveColor: TColor          read FActiveColor   write SetActiveColor default clYellow ;
    // 継承プロパティ
    property  Font;
    property  Align;
    property  Cursor;
    property  Enabled;
    property  Action;
    property  Anchors;
    property  BiDiMode;
    property  Constraints;
    property  ParentBiDiMode;
    property  Hint;
    property  ParentFont;
    property  ParentShowHint;
    property  ShowHint;
    property  Visible;
    property  Tag;
  end;

procedure Register;

implementation

uses
  ComCtrls;

const
  ctBtnWidth    = 100;                                                 // ボタンデフォルト幅
  ctBtnHeight   = 50;                                                  // ボタンデフォルト高さ
//  ctBtnUpTime   = 800;                                                 // ボタン強制Up時間 2002.11.13 変更
  ctDefaultReleaseTime = 200;                                                   // 2002.11.13 追加

var
  ghSelfWnd:  THANDLE;
  hndHook:    HHOOK;
  wOnKeyType: DWORD;
  wOnMsgPram: DWORD;
  wOnShiftState:   TShiftState;
  POnFormKeyUp:    TOnFormKeyUp;
  POnFormKeyDown : TOnFormKeyDown;
  


//function  KeyHookProc(Code :integer ; wParam :DWORD ;  lParam : DWORD) : integer; stdcall; forward; // 2009.08.12 変更
function  GetMsgProc (Code :integer ; wParam :DWORD ;  lParam : DWORD) : integer; stdcall; forward;   // 2009.08.12 変更

//**********************************************************************//
// Module Name     :  キャプションリストクラスのメソッド群              //
//**********************************************************************//
//**********************************************************************//
// Module Name     :  キャプションリストクラスの生成                    //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
constructor TCaptionStrings.Create;
begin
  inherited Create;

  FCaptionString := TStringList.create;
  FCount := 0;

end;

//**********************************************************************//
// Module Name     :  キャプションリストクラスの破棄                    //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
destructor TCaptionStrings.Destroy;
begin

  FCaptionString.free;

  inherited Destroy;

end;

//**********************************************************************//
// Module Name     :  キャプションリストのクリア                        //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
procedure TCaptionStrings.clear;
begin

  FCaptionString.clear;

  FCount := 0;

  if Assigned(FOnChange) then begin
    FOnChange(Self);
  end;

end;

//**********************************************************************//
// Module Name     :  キャプションリストの１行削除                      //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
Procedure TCaptionStrings.Delete(Index: Integer);
begin

  FCaptionString.delete(Index);

  FCount := FCount - 1;

//  if Assigned(FOnChange) then begin
//    FOnChange(Self);
//  end;

end;

//**********************************************************************//
// Module Name     :  キャプションリストの挿入                          //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
Procedure TCaptionStrings.Insert(Index: Integer; const S: string);
begin

  If (Index > FCount) Or (Index < 0) Then exit;

  FCaptionString.Insert(Index ,S);

  FCount := FCount+1;

  if Assigned(FOnChange) then begin
    FOnChange(Self);
  end;

end;

//**********************************************************************//
// Module Name     :  キャプションリストの追加                          //
// Programer       :  鹿野　幸生                                        //
// Date            :  2001.04.20                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function TCaptionStrings.Add(const S: string): Integer;
begin

  FCaptionString.Add(S);

  FCount := FCount+1;

  if Assigned(FOnChange) then begin
    FOnChange(Self);
  end;

end;

//**********************************************************************//
// Module Name     :  キャプションリストの取得                          //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
Function TCaptionStrings.Get(Index: Integer): string;
begin

  If (Index >= FCount) Or (Index < 0) Then
    result := ''
  else
    result := FCaptionString.Strings[Index];

end;

//**********************************************************************//
// Module Name     :  キャプションリストの件数                          //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
Function TCaptionStrings.GetCount: integer;
begin

  result := FCount;

end;

//**********************************************************************//
// Module Name     :  キャプションリストの追加                          //
// Programer       :  鹿野　幸生                                        //
// Date            :  2001.04.20                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
//procedure TCaptionStrings.Put(Index: Integer; const S: string);
//var
//  TempObject: TObject;
//begin
//  inherited;
//  TempObject := GetObject(Index);
//  Delete(Index);
//  InsertObject(Index, S, TempObject);

//  if Assigned(FOnChange) then begin
//    FOnChange(Self);
//  end;

//end;

procedure Register;
begin
  RegisterComponents('HSS', [THFuncKey]);
end;

//                                          //  2009.08.12 削除 VV
//**********************************************************************//
// Module Name     :  キーフック関数                                    //
//                 :  KeyHookProc                                       //
// 引数            :  １ 整数 仮想キーコード                            //
//                 :  ２ 整数 WPARAMパラメータ                          //
//                 :  ３ 整数 LPARAMパラメータ                          //
// 戻り値          :  元のWindowsプロシージャの戻り値                   //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
//function KeyHookProc(Code: integer; wParam: DWORD; lParam: DWORD) : integer;
//var
//  hWnd:        THANDLE;
//  Key:         WORD;
//  MessagePram: dword;
//  bDoKeyCtl:   boolean;
//  ShiftStates: TShiftState;
//  szClassName: array [0..255] of char;
//  szMDICls:    array [0..255] of char;
//
//begin
//
//  try
//
//    // 必要な時だけ、フック処理を行う
//    if (Code >= HC_ACTION) and (Code <> HC_NOREMOVE) then begin
//
//      // キー処理有り
//      bDoKeyCtl  :=   true;
//
//      // アクティブウインドウが自分か、或いはMDIClientなら処理するが、
//      // それ以外はスルー
//      StrPCopy(szMDICls, 'MDIClient');
//      hWnd := GetActiveWindow;
//      if ghSelfWnd <> hWnd then begin
//        GetClassName(hWnd, @szClassName, sizeof(szClassName));
//        if StrIComp(szClassName, szMDICls) <> 0 then begin
//          bDoKeyCtl  :=   False;
//        end;
//      end;
//
//      // キー処理有りなら制御
//      if bDoKeyCtl = True then begin
//
//        // 仮想キーコード
//        Key := wParam;
//
//        // Windowsメッセージを擬似的に設定 (1:KeyUp、0:KeyDown)
//        if (lParam shr 31) = 1 then
//          MessagePram := WM_KEYUP
//        else
//          MessagePram := WM_KEYDOWN;
//
//        // シフトステータスを設定
//        ShiftStates := [];
//        if GetKeyState(VK_SHIFT) < 0then begin
//          ShiftStates := ShiftStates + [ssShift];
//        end;
//        if GetKeyState(VK_CONTROL) < 0then begin
//          ShiftStates := ShiftStates + [ssCtrl];
//        end;
//        if GetKeyState(VK_MENU) < 0then begin
//          ShiftStates := ShiftStates + [ssAlt];
//        end;
//
//        // Windowsメッセージ、仮想キーコードが違えば内部処理スタート
//        if (wOnKeyType <> Key) or (MessagePram <> wOnMsgPram) or (wOnShiftState <> ShiftStates) then begin
//
//          // シフトステータスを設定
//          // Windowsメッセージを保存
//          wOnMsgPram := MessagePram;
//
//          // シフト状態、WIndowsメッセージ、仮想キーコードが違ってなければ、処理しない
//          if (wOnShiftState <> ShiftStates) or
//                 ((Key >= VK_F1) and (Key <= VK_F12)) then begin
//
//            // シフト状態を保存
//            wOnShiftState := ShiftStates;
//          // 仮想キーコードを保存
//            wOnKeyType := Key;
//
//            if MessagePram = WM_KEYUP then begin
//              POnFormKeyUp(Application, Key, ShiftStates);
//            end else begin
//              POnFormKeyDown(Application, Key, ShiftStates);
//            end;
//
//          end;
//
//        end;
//
//      end;
//
//    end;
//
//  finally
//
//    // 元々のWindowsプロシージャを呼び出す
//    Result := CallNextHookEx(hndHook, Code, wParam, lParam);
//
//  end;
//
//end;
//                                          //  2009.08.12 削除 AA
//**********************************************************************//
// Module Name     :  メッセージフック関数                              //
//                 :  GetMsgProc                                        //
// 引数            :  １ 整数 仮想キーコード                            //
//                 :  ２ 整数 WPARAMパラメータ                          //
//                 :  ３ 整数 LPARAMパラメータ                          //
// 戻り値          :  元のWindowsプロシージャの戻り値                   //
// Programer       :  鹿野 幸生                                            //
// Date            :  2009.08.12                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function GetMsgProc(Code: integer; wParam: DWORD; lParam: DWORD) : integer;
var
  hWnd       : THANDLE;
  Key        : WORD;
  MessagePram: dword;
  bDoKeyCtl  : boolean;
  ShiftStates: TShiftState;
  szClassName: array [0..255] of char;
  szMDICls   : array [0..255] of char;

  Msg        : PMsg;

begin

  try

    if (Code = HC_ACTION) then
    begin

        // キー処理有り
        bDoKeyCtl := True;

        // アクティブウインドウが自分か、或いはMDIClientなら処理するが、
        // それ以外はスルー
        StrPCopy(szMDICls, 'MDIClient');
        hWnd := GetActiveWindow;
        if ghSelfWnd <> hWnd then
        begin
          GetClassName(hWnd, @szClassName, SizeOf(szClassName));
          if StrIComp(szClassName, szMDICls) <> 0 then
          begin
            bDoKeyCtl := False;
          end;
        end;

        // キー処理有りなら制御
        if bDoKeyCtl = True then
        begin
          Msg := PMsg(lParam);

          case Msg^.message of
            WM_KEYDOWN   ,
            WM_SYSKEYDOWN,
            WM_KEYUP     ,
            WM_SYSKEYUP  :
            begin
              if ((Msg^.message = WM_SYSKEYUP  )  or
                  (Msg^.message = WM_SYSKEYDOWN)) and
                 (Msg^.wParam <> VK_MENU)         then   //Altキー以外then
              begin
                // 仮想キーコード
                Key := VK_F10;
              end else
              begin
                // 仮想キーコード
                Key := Msg^.wParam;
              end;

              case Msg^.message of
                WM_KEYUP      : MessagePram := WM_KEYUP;
                WM_KEYDOWN    : MessagePram := WM_KEYDOWN;
                WM_SYSKEYUP   : MessagePram := WM_SYSKEYUP;
                WM_SYSKEYDOWN : MessagePram := WM_SYSKEYDOWN;
                else            MessagePram := WM_KEYDOWN;
              end;

              // シフトステータスを設定
              ShiftStates := [];
              if GetKeyState(VK_SHIFT) < 0 then
              begin
                ShiftStates := ShiftStates + [ssShift];
              end;
              if GetKeyState(VK_CONTROL) < 0then
              begin
                ShiftStates := ShiftStates + [ssCtrl];
              end;
              if GetKeyState(VK_MENU) < 0then
              begin
                ShiftStates := ShiftStates + [ssAlt];
              end;

              // Windowsメッセージ、仮想キーコードが違えば内部処理スタート
              if (wOnKeyType <> Key) or (MessagePram <> wOnMsgPram) or (wOnShiftState <> ShiftStates) then
              begin

                // シフトステータスを設定
                // Windowsメッセージを保存
                wOnMsgPram := MessagePram;

                // シフト状態、WIndowsメッセージ、仮想キーコードが違ってなければ、処理しない
                if (wOnShiftState <> ShiftStates) or
                   ((Key >= VK_F1) and (Key <= VK_F12)) then
                begin

                  // シフト状態を保存
                  wOnShiftState := ShiftStates;
                  // 仮想キーコードを保存
                  wOnKeyType := Key;

                  if (Key = VK_MENU)        or
                     (ssAlt in ShiftStates) then
                  begin
                  // Altキー押下では処理しない
                  end else begin

                    if (MessagePram = WM_KEYUP)    or
                       (MessagePram = WM_SYSKEYUP) then
                    begin
                      POnFormKeyUp(Application, Key, ShiftStates);
                    end else
                    begin
                      POnFormKeyDown(Application, Key, ShiftStates);
                    end;

                  end;
                end;
              end;
            end;
          end;
        end;
    end;
  finally

    // 元々のWindowsプロシージャを呼び出す
    Result := CallNextHookEx(hndHook, Code, wParam, lParam);

  end;

end;
//**********************************************************************//
// Module Name     :  キャプションリストクラスのメソッド群              //
//**********************************************************************//
//**********************************************************************//
// Module Name     :  コンポーネント生成                                //
//                 :  THFuncKey.Create                                  //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
constructor THFuncKey.Create(AOwner: TComponent);
var
  i:            integer;

begin

  // 継承
  Inherited Create(AOwner);

  try

//    ControlStyle := [csClickEvents, csCaptureMouse, csDoubleClicks, csOpaque];
    ControlStyle := [csClickEvents, csCaptureMouse, csOpaque];

    // 親フォーム設定
    FForm := TForm(AOwner);

    FVersion     := HFuncKeyVersion;

    FCtrlDoubleBuffered := False;                                               // 2002.11.13 追加

    FReleaseTime := ctDefaultReleaseTime;                                       // 2002.11.13 追加

    // カスタムタイマー作成
    CustomTimer  := TTimer.Create(self);
    with CustomTimer do begin
      Enabled  := False;
//      Interval := ctBtnUpTime;                                       // ボタンUPの基本間隔 2002.11.13 変更
      Interval := FReleaseTime;                                      // ボタンUPの基本間隔
      OnTimer  := OnBtnForceUp;                                      // ボタン強制UP
    end;

    // ボタン計算中をOFFに初期化
    fbOnReSize   := False;

    // FuncKeyのデフォルト数を設定
    FnBtnCount := ctDefBtnCnt;
    FnNoUseBtn := ctMaxBtnCnt;                                       // 宣言後未使用ボタン

    FnSplitWidth := ctSplitWidth;
    if (FnBtnCount mod 4) = 0 then
      FnSplit := 2
    else if (FnBtnCount mod 5) = 0 then
      FnSplit := 1
    else
      FnSplit := 0;

    // 現在押されているボタンを初期化
    FnActiveBtnNo := 0;

    // FuncKeyのデフォルトサイズを設定
    Left       := 0;
    Top        := 0;
    Width      := FForm.ClientWidth - 10;
    Height     := ctBtnHeight;
    FColor     := clBtnFace;
    FBackColor := clBtnFace;

    // コントロールサイズをジャストサイズにする
    // 内部ボタンのデフォルト幅をフォームサイズから決定
    CalcBtnPos;

    // 通常時カラー
//    FColors := THExtBtnColor.Create;
    FColors := THExtBtnColor.Create;
    FColors.OnChange := SetColorsOnChange;
    FColors.Color    := clBtnFace;
//    FColors.OnChange := FontsAndColorsOnChange;
    // PRESS時フォント
//    FPressedColors := THExtBtnColor.Create;
    FPressedColors := THExtBtnColor.Create;
    FPressedColors.OnChange := SetPressedColorsOnChange;
    FPressedColors.Color    := clBtnHighlight;
//    FPressedColors.OnChange := FontsAndColorsOnChange;
    // アクティブ時フォント
    FActiveFont := TFont.Create;
    FActiveFont.Color    := clHighlight ;
    FActiveFont.OnChange := FontsAndColorsOnChange ;
    // フォントのデフォルト値設定
    if csDesigning in ComponentState then begin
      // 通常時フォント
      Font.Pitch := fpFixed;
      Font.Name  := 'ＭＳ ゴシック';
      Font.Size  := 11;
      // アクティブ時フォント
      FActiveFont.Pitch := fpFixed;
      FActiveFont.Name  := 'ＭＳ ゴシック';
      FActiveFont.Size  := 11;
      FActiveFont.style := [fsBold];
    end;

    FbBtnCaptionWrap := True;
    FActiveColor     := clYellow;
    FActiveFrame     := True;
    FUpFrame         := True;
    FDownFrame       := True;
    FTransparent     := False;
    FFrameType       := ftNormalFrame;
    FDisabledImage   := diDefault;
    FDisabledHighlight := clBtnHighlight;
    FDisabledShadow  := clBtnShadow;
    FLayout          := blGlyphLeft;
    FFontHighlight   := clNone ;
    FFontShadow      := clNone ;
    FBtnAutoEnable   := True;

    // キャプション配列作成
    FCaptions      := TCaptionStrings.create;
    FShiftCaptions := TCaptionStrings.create;
    FCtrlCaptions  := TCaptionStrings.create;
    FAltCaptions   := TCaptionStrings.create;

    // キャプション文字列作成
    if csDesigning in ComponentState then begin
      // ボタン個数分ボタンをキャプション文字列を設定
      for i := 1 to FnBtnCount do begin
        FCaptions.Add('F' + IntToStr(i));
        FShiftCaptions.Add('SF' + IntToStr(i));
        FCtrlCaptions.Add('CF' + IntToStr(i));
        FAltCaptions.Add('AF' + IntToStr(i));
      end;
    end;

    // ボタンEnabledプロパティ設定                                              2001.07.16 追加
    if csDesigning in ComponentState then begin
      FbBtnAllowKey      := True;
      FbBtnAllowShiftKey := False;
      FbBtnAllowCtrlKey  := False;
      FbBtnAllowAltKey   := False;
    end;

    try

      // ボタンコントロール作成
      for i := 0 to FnBtnCount-1 do begin

        // ボタンコントロールをクリエート
        if HSpeedExtBtn[i] = nil then begin
          HSpeedExtBtn[i] := THSpeedExtButton.Create(self);
        end;

        with HSpeedExtBtn[i] do begin
          Parent          := self;
          Name            := 'HSpdExtBtn' + IntToStr(i + 1);
          LogicalNo       :=  i+1;
          BtnEnable[i]      := True;
          BtnShiftEnable[i] := True;
          BtnCtrlEnable[i]  := True;
          BtnAltEnable[i]   := True;
          ReleaseTime       := FReleaseTime;                                    // 2002.11.13 追加
          if not (csDesigning in ComponentState) then begin
            FOnBtnClick     := OnClick;
            FOnBtnMouseMove := OnMouseMove;
            FOnBtnMouseDown := OnMouseDown;
            FOnBtnMouseUp   := OnMouseUp;
            OnClick         := BtnClick;
            OnMouseMove     := BtnMouseMove;
            OnMouseDown     := BtnMouseDown;
            OnMouseUp       := BtnMouseUp;
          end;
        end;


      end;

    Except
      // 例外の発生
      else raise EHFuncKeyException.Create('HFuncKeyボタンの作成に失敗しました');
    end;

  Except
    // 例外の発生
    else raise EHFuncKeyException.Create('HFuncKeyの作成に失敗しました');

  end;

  // リペイントを可能に
  FbRepaintNow :=False;

//  invalidate;


end;

//**********************************************************************//
// Module Name     :  ボタンコントロール生成                            //
//                 :  THFuncKey.CreateBtnCtrl                           //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THFuncKey.CreateBtnCtrl(Sender: TComponent; inStrtIdx, inEndIdx: integer): integer;
var
  i:  integer;

begin

  try

    // ボタン個数分ボタンを作成
    for i := inStrtIdx to inEndIdx do begin

      // ボタンコントロールをクリエート
      if HSpeedExtBtn[i] = nil then begin
        HSpeedExtBtn[i] := THSpeedExtButton.Create(Sender);
      end;

      with HSpeedExtBtn[i] do begin
        Parent          := TWinControl(Sender);
        Name            := 'HSpdExtBtn' + IntToStr(i + 1);
        LogicalNo       :=  i+1;
        BtnEnable[i]      := True;
        BtnShiftEnable[i] := True;
        BtnCtrlEnable[i]  := True;
        BtnAltEnable[i]   := True;
        ReleaseTime       := FReleaseTime;                                      // 2002.11.13 追加
        if not (csDesigning in ComponentState) then begin
          FOnBtnClick     := OnClick;             //
          FOnBtnMouseMove := OnMouseMove;         //
          FOnBtnMouseDown := OnMouseDown;         //
          FOnBtnMouseUp   := OnMouseUp;           //
          OnClick         := BtnClick;
          OnMouseMove     := BtnMouseMove;
          OnMouseDown     := BtnMouseDown;
          OnMouseUp       := BtnMouseUp;
        end;
      end;

    end;

  except
    // 例外の発生
    else raise EHfuncKeyException.Create('HFuncKey Button Create Error');

  end;


  // コントロールを描画
//  DoPaintCtrl;

  Result := 0;

end;

//**********************************************************************//
// Module Name     :  ボタンコントロール破棄                            //
//                 :  THFuncKey.RemoveBtnCtrl                           //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THFuncKey.RemoveBtnCtrl(Sender: TComponent; inEndIdx: integer): integer;
var
  i:  integer;

begin

  // 指定されたボタン個数を超過した分を破棄
  for i := FnBtnCount to inEndIdx do begin

    HSpeedExtBtn[i].Free;

  end;

  Result := 0;

end;

//**********************************************************************//
// Module Name     :  THFuncKeyクラス消滅                               //
//                 :  THFuncKey.Destroy                                 //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
destructor THFuncKey.Destroy;
var
  i :integer;

begin

  if (BtnAllowKey = True) and not (csDesigning in ComponentState) then begin
    //インストールした時のハンドルを使ってフック削除
    UnHookWindowsHookEx(hndHook);
  end;

  // カスタムタイマー破棄
  CustomTimer.Enabled  := False;
  CustomTimer.Free;

  // 作業用の各サブプロパティ破棄
  FPressedColors.Free;
  FCaptions.Free;
  FShiftCaptions.Free;
  FCtrlCaptions.Free;
  FAltCaptions.Free;
  FActiveFont.Free;
  FColors.Free;

  // イメージリスト破棄                                                         2002.11.13 削除
//  if FImageList <> nil then
//    FImageList.Free;
//  if FShiftImageList <> nil then
//    FShiftImageList.Free;
//  if FCtrlImageList <> nil then
//    FCtrlImageList.Free;
//  if FAltImageList <> nil then
//    FAltImageList.Free;

  // ビットマップ破棄
  for i := 0 to FnBtnCount - 1 do begin
    HSpeedExtBtn[i].Free;
    if BtnBitmap[i] <> nil then
      BtnBitmap[i].Free;
    if BtnShiftBitmap[i] <> nil then
      BtnShiftBitmap[i].Free;
    if BtnCtrlBitmap[i] <> nil then
      BtnCtrlBitmap[i].Free;
    if BtnAltBitmap[i] <> nil then
      BtnAltBitmap[i].Free;
  end;

  // 継承
  inherited Destroy;

end;

//**********************************************************************//
// Module Name     :  プロパティロード                                  //
//                 :  THFuncKey.Loaded                                  //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
procedure THFuncKey.Loaded;
begin

  inherited Loaded;

  // 描画範囲を設定
  FnActiveBtnNo := FnBtnCount;

  // 親フォームのKeyを横取り (Keyにフックをかける)
//  if (BtnAllowKey = True) and not (csDesigning in ComponentState) then begin  2001.07.16 変更
  if not (csDesigning in ComponentState) then begin
    if (FbBtnAllowKey = True) or (FbBtnAllowShiftKey = True) or
       (FbBtnAllowAltKey = True) or (FbBtnAllowCtrlKey = True) then begin

      ghSelfWnd    := FForm.Handle;
      POnFormKeyUp := OnFormKeyUp;
      POnFormKeyDown := OnFormKeyDown;
      wOnKeyType := 0;
      wOnMsgPram := 0;
    //フックプロシージャ
//      hndHook := SetWindowsHookEx(WH_KEYBOARD, @KeyHookProc, hInstance, GetCurrentThreadID);     // 2009.08.12 変更
      hndHook := SetWindowsHookEx(WH_GETMESSAGE, @GetMsgProc, hInstance, GetCurrentThreadID);      // 2009.08.12 変更
//    hndHook := SetWindowsHookEx(WH_KEYBOARD, @KeyHookProc, Application.handle, GetCurrentThreadID);

    end;
  end;

  SetBtnProperty;

  // キャプション文字列の変更を反映させるイベントを設定
  FCaptions.OnChange      := OnCaptionChange;
//  FShiftCaptions.OnChange := OnCaptionChange;
//  FCtrlCaptions.OnChange  := OnCaptionChange;
//  FAltCaptions.OnChange   := OnCaptionChange;


end;

//**********************************************************************//
// Module Name     :  キャプション描画                                  //
//                 :  THFuncKey.OnCaptionChange                         //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  鹿野　幸生                                        //
// Date            :  2001.04.20                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
procedure THFuncKey.OnCaptionChange(Sender: TObject);
begin
  inherited;

  Perform(CM_TEXTCHANGED, 0, 0);

end;

//**********************************************************************//
// Module Name     :  コントロール描画                                  //
//                 :  THFuncKey.Paint                                   //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
procedure THFuncKey.Paint;
begin

  if FbRepaintNow = True then
    exit;

//    DoPaintCtrl;                                                              2001.02.20 削除

  inherited paint;


end;

//**********************************************************************//
// Module Name     :  コントロール描画                                  //
//                 :  THFuncKey.Paint                                   //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
//procedure THFuncKey.RePaint;                  //  2009.08.12  変更
procedure THFuncKey.Repaint;                    //  2009.08.12  変更
begin
{
  if FbRepaintNow = True then
    exit;

  try

    LockWindowUpdate(Handle);

    DoPaintCtrl;

  finally

    LockWindowUpdate(0);

//    inherited repaint;

  end;

}
end;

//**********************************************************************//
// Module Name     :  コントロール描画(実装部)                          //
//                 :  THFuncKey.DoPaintCtrl                             //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
procedure THFuncKey.DoPaintCtrl;
var
  i:            integer;
  nStrtPaintBtn: integer;
  nEndPaintBtn: integer;
  WkBm:         TBitmap;
  bForceDisEnabled: boolean;

begin

  FbRepaintNow := True;

  bForceDisEnabled := False;                                                     // 2001.07.16 追加

//  WkBm := TBitmap.create;               // 2009.08.12 削除

  try

    // もし現在押されているボタンが設定されていたら、それだけ描画               2001.02.20 削除
//    if FnActiveBtnNo = 0 then begin
//      nStrtPaintBtn := 0;
//      nEndPaintBtn := FnBtnCount
//    end else begin
//      nStrtPaintBtn := FnActiveBtnNo - 1;
//      nStrtPaintBtn := 0;
//      nEndPaintBtn  := FnActiveBtnNo;
//      FnActiveBtnNo := 0;
//    end;
    nStrtPaintBtn := 0;
    nEndPaintBtn  := FnBtnCount;

    for i := nStrtPaintBtn to nEndPaintBtn - 1 do begin

      WkBm := TBitmap.create;             //  2009.08.12 追加

      if HSpeedExtBtn[i] = nil then
        break;

      with HSpeedExtBtn[i] do begin

        // グラフィックの読み込み(ImageList、ダイナミック指定により実装が異なる)
        Glyph.width := 0;
        Glyph.Height := 0;
//        Glyph.FreeImage;                                                      2002.11.13 削除
//        Glyph.Dormant;                                                        2002.11.13 削除
        Glyph.ReleaseHandle;
        if ssShift in FShiftState then begin
          if FShiftImageList <> nil then begin
            if i < FShiftImageList.Count then begin
              FShiftImageList.GetBitmap(i, WkBm);
              WkBm.FreeImage;                                                   // 2002.11.13 追加
              WkBm.Dormant;                                                     // 2002.11.13 追加
              Glyph.Assign(WkBm);
            end;
          end else
            if BtnShiftBitmap[i] <> nil then begin
              glyph.Assign(BtnShiftBitmap[i]);
            end;
        end else if ssCtrl in FShiftState then begin
          if FCtrlImageList <> nil then begin
            if i < FCtrlImageList.Count then begin
              FCtrlImageList.GetBitmap(i, WkBm);
              WkBm.FreeImage;                                                   // 2002.11.13 追加
              WkBm.Dormant;                                                     // 2002.11.13 追加
              Glyph.Assign(WkBm);
            end;
          end else
            if BtnCtrlBitmap[i] <> nil then begin
              glyph.Assign(BtnCtrlBitmap[i]);
            end;
        end else if ssAlt in FShiftState then begin
          if FAltImageList <> nil then begin begin
            if i < FAltImageList.Count then
              FAltImageList.GetBitmap(i, WkBm);
              WkBm.FreeImage;                                                   // 2002.11.13 追加
              WkBm.Dormant;                                                     // 2002.11.13 追加
              Glyph.Assign(WkBm);
            end;
          end else
            if BtnAltBitmap[i] <> nil then begin
              glyph.Assign(BtnAltBitmap[i]);
            end;
        end else begin
          if FImageList <>  nil then begin
            if i < FImageList.Count then begin
              FImageList.GetBitmap(i, WkBm);
              WkBm.FreeImage;                                                   // 2002.11.13 追加
              WkBm.Dormant;                                                     // 2002.11.13 追加
              glyph.Assign(WkBM);
            end;
          end else
            if BtnBitmap[i] <> nil then begin
              glyph.Assign(BtnBitmap[i]);
            end;
        end;

        glyph.PixelFormat := pf24bit;       // 2009.08.12 追加

        // キャプションの表示
        CaptionWrap  := FbBtnCaptionWrap;
        if ssShift in FShiftState then begin
          Caption    := FShiftCaptions.Strings[i];
        end else if ssCtrl in FShiftState then begin
          Caption    := FCtrlCaptions.Strings[i];
        end else  if ssAlt in FShiftState then begin
          Caption    := FAltCaptions.Strings[i];
        end else begin
          Caption    := FCaptions.Strings[i];
          // 通常ファンクションが使用不可の場合を考慮する
          if FbBtnAllowKey = False then begin
            bForceDisEnabled := True;
          end;
        end;
        // ボタンのEnabledコントロール
        if FBtnAutoEnable = True then begin
          // キャプション無しは使用不可
          if Caption = '' then
            Enabled         := False
          else
//           Enabled         := True;                                           2001.07.16 変更
          // 通常ファンクションが使用不可の場合を考慮する
           if bForceDisEnabled = True then begin
             Enabled         := False;
           end else begin
             Enabled         := True;
           end;
        end else begin
          if ssShift in FShiftState then begin
            Enabled := BtnShiftEnable[i];
          end else if ssCtrl in FShiftState then begin
            Enabled := BtnCtrlEnable[i];
          end else if ssAlt in FShiftState then begin
            Enabled := BtnAltEnable[i];
          end else begin
            Enabled := BtnEnable[i];
          end

        end;

//        invalidate;                                                          // 2001.03.09 削除

      end;

      WkBm.Free;                                // 2009.08.12 追加

    end;

//    WkBm.Free;                                // 2009.08.12 削除

    invalidate;                                                          // 2001.03.09 削除

    FbRepaintNow := False;

    refresh;

  except

    else begin
      SHowMessage('Can not Pait Component');
      FbRepaintNow := False;
      WkBm.Free;
      exit;
    end;

  end;


end;

//**********************************************************************//
// Module Name     :  コントロールサイズ変更イベント処理                //
//                 :  THFuncKey.WMSize                                  //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
procedure THFuncKey.WMSize(var Msg:TWMSize);
begin

  FbRepaintNow := False;

  // 既にポジション計算中なら抜ける
  if fbOnReSize = True then
    exit;

  // ポジション計算中にする
  fbOnReSize := True;

  // コントロールの幅に合わせ、ボタンサイズを決定
  CalcBtnPos;

  // コンポーネント描画
  DoPaintCtrl;

  // 派生元呼び出し
  inherited;

  // ポジション計算中にする
  fbOnReSize := False;

end;

//**********************************************************************//
// Module Name     :  ボタンフェイス強制UPイベント                      //
//                 :  THFuncKey.OnBtnForceUp                            //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :  2001.01.10  鹿野　幸生                            //
//**********************************************************************//
procedure THFuncKey.OnBtnForceUp(Sender: TObject);
var
  Key: Word;
//  ShiftStates: TShiftState;

begin

 // ボタンが押されて続けていれば、ボタンの強制UPはしない
  if (wOnMsgPram = WM_KEYDOWN) and (FnBtnOnPressed <> 0) then begin
    CustomTimer.Interval := 0;
//    CustomTimer.Interval := ctBtnUpTime;                                      2002.11.13 変更
    CustomTimer.Interval := FReleaseTime;
    exit;
  end;
{
  // シフトステータスを設定                                                     2001.01.10 追加
  ShiftStates := [];
  if GetKeyState(VK_SHIFT) < 0then begin
    ShiftStates := ShiftStates + [ssShift];
  end;
 if GetKeyState(VK_CONTROL) < 0then begin
   ShiftStates := ShiftStates + [ssCtrl];
 end;
 if GetKeyState(VK_MENU) < 0then begin
   ShiftStates := ShiftStates + [ssAlt];
 end;

 // 同じShiftキー等が押されて続けていれば、ボタンの強制UPはしない               2001.01.10 追加
 if (wOnMsgPram = WM_KEYDOWN) and (wOnShiftState = ShiftStates) then begin
    CustomTimer.Interval := 0;
    CustomTimer.Interval := ctBtnUpTime;
    exit;
  end;
}
  // 強制タイマーを切る
  CustomTimer.Enabled := False;

  // 押されていたファンクションキーを返す
  Key := 0;
  case FnBtnOnPressed of
    1:  Key := VK_F1;
    2:  Key := VK_F2;
    3:  Key := VK_F3;
    4:  Key := VK_F4;
    5:  Key := VK_F5;
    6:  Key := VK_F6;
    7:  Key := VK_F7;
    8:  Key := VK_F8;
    9:  Key := VK_F9;
    10: Key := VK_F10;
    11: Key := VK_F11;
    12: Key := VK_F12;
  end;

  // 強制的にボタンアップUP
  OnFormKeyUp(Sender, Key, FShiftState);

  // 押されていたシフトキー状態を消す
  // シフトステータスを設定                                                     2001.01.10 追加
  FShiftState := [];
//  if GetKeyState(VK_SHIFT) < 0then begin                                      2001.07.16 変更
//    FShiftState := FShiftState + [ssShift];
//  end;
// if GetKeyState(VK_CONTROL) < 0then begin
//   FShiftState := FShiftState + [ssCtrl];
// end;
// if GetKeyState(VK_MENU) < 0then begin
//   FShiftState := FShiftState + [ssAlt];
// end;
  If (FbBtnAllowShiftKey = TRue) and (GetKeyState(VK_SHIFT) < 0) then begin
    FShiftState := FShiftState + [ssShift];
  end;
  If (FbBtnAllowCtrlKey = True) and (GetKeyState(VK_CONTROL) < 0) then begin
    FShiftState := FShiftState + [ssCtrl];
  end;
  If (FbBtnAllowAltKey = True) and (GetKeyState(VK_MENU) < 0) then begin
    FShiftState := FShiftState + [ssAlt];
  end;

  // ボタン全体を描画対象にする                                                 2001.01.10 追加  2001.02.20 削除
// FnActiveBtnNo := FnBtnCount;

  DoPaintCtrl;                                                                  // 2001.02.20 追加

// invalidate;                                                                  2002.11.13 削除

end;

//**********************************************************************//
// Module Name     :  フォームレベルのキー押下時のイベント処理          //
//                 :  THFuncKey.OnFormKeyDown                           //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
procedure THFuncKey.OnFormKeyDown(Sender: TObject; var Key: Word;  Shift: TShiftState);
var
  Cancel:  boolean;
  nFKeyNo: integer;
  bDoPaint: boolean;
  hlmc: Integer;
  dwSize: Longword;
  imestr: array[0..255] of char;


begin

  // 使用不可なら押せない
  if Enabled = False then
    exit;

  // マウス押下中は新たに押せない
  if FnBtnMouseDowned > 0 then
    exit;

  // ボタン押下中は新たに押せない
  if FnBtnOnPressed > 0 then
    exit;

  // IME使用中は押せない
  hlmc := ImmGetContext(Handle);        // 変換中文字列を取得
  if hlmc <> 0 then begin
    // 変換中文字列長を取得
    dwSize := ImmGetCompositionStringA(hlmc, 1, @imestr, sizeof(imestr));
    // 使用したコンテキストを開放
    immReleaseContext(Handle, hlmc);
    // 使用中
    if dwSize > 0 then begin
      Exit;
    end;
  end;

  // コンポーネントMouseDownイベント
  if Assigned(FOnKeyDown) then FOnKeyDown(Self, Key, Shift, Cancel);

  // Cancel=Trueならボタンのイベントは呼び出さない
  if Cancel = True then
    exit;

  bDoPaint     := False;

  FbRepaintNow := False;

  // カスタムタイマー監視解除
  CustomTimer.Enabled  := False;

  // シフト状態が変われば、再設定＆再描画
  if FShiftState <> Shift then begin

    FShiftState := [];
    If (FbBtnAllowShiftKey = TRue) and (ssShift in Shift) then begin
      FShiftState := FShiftState + [ssShift];
    end;
    If (FbBtnAllowCtrlKey = True) and (ssCtrl in Shift) then begin
      FShiftState := FShiftState + [ssCtrl];
    end;
    If (FbBtnAllowAltKey = True) and (ssAlt in Shift) then begin
      FShiftState := FShiftState + [ssAlt];
    end;

    bDoPaint     := True;
//    paint;
//    invalidate;

  end;

  // ボタンが押された時に、反応する設定であれば、反応
  if FbBtnAllowKey = True then begin

    // ファンクションキーが押されたか？
    nFKeyNo := 0;
    case Key of
      VK_F1:  nFKeyNo := 1;
      VK_F2:  nFKeyNo := 2;
      VK_F3:  nFKeyNo := 3;
      VK_F4:  nFKeyNo := 4;
      VK_F5:  nFKeyNo := 5;
      VK_F6:  nFKeyNo := 6;
      VK_F7:  nFKeyNo := 7;
      VK_F8:  nFKeyNo := 8;
      VK_F9:  nFKeyNo := 9;
      VK_F10: nFKeyNo := 10;
      VK_F11: nFKeyNo := 11;
      VK_F12: nFKeyNo := 12;
    end;

    // ファンクションキーが押されていた時だけ、クリックイベントを動かす
    if nFKeyNo <> 0 then begin
      if HSpeedExtBtn[nFKeyNo-1] = nil then begin
        exit;
      end else if HSpeedExtBtn[nFKeyNo-1].Enabled = False then begin
        exit;
      end;
      // 現在ボタンが押されていなければ、押された状態にする
      if FnBtnOnPressed = 0 then begin
        // 現在押されているボタンを設定
        FnBtnOnPressed := nFKeyNo;
        FnActiveBtnNo := nFKeyNo;
        HSpeedExtBtn[nFKeyNo-1].PressedButton(Sender, FShiftState, 0, 0);
        // カスタムタイマー監視開始
//        CustomTimer.Enabled  := True;
        bDoPaint     := True;
      end;
//      invalidate;
    end;

  end;


  if bDoPaint = True then begin
    // カスタムタイマー監視開始
    CustomTimer.Enabled  := True;
//    invalidate;                                                               2001.02.20 変更
    DoPaintCtrl;
//    paint;
  end;

end;

//**********************************************************************//
// Module Name     :  フォームレベルのキーアップ時のイベント処理        //
//                 :  THFuncKey.OnFormKeyUp                             //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :  2001.01.10  鹿野　幸生                            //
//**********************************************************************//
procedure THFuncKey.OnFormKeyUp(Sender: TObject; var Key: Word;  Shift: TShiftState);
var
  Cancel:  boolean;
  nFKeyNo: integer;
  bDoPaint: boolean;

begin

 // ボタンが押されて続けていれば、ボタンの強制UPはしない
  if wOnMsgPram = WM_KEYDOWN then begin
    CustomTimer.Interval := 0;
//    CustomTimer.Interval := ctBtnUpTime;                                      2002.11.13変更
    CustomTimer.Interval := FReleaseTime;
    exit;
  end;

 // コンポーネントMouseUpイベント
  if Assigned(FOnKeyUp) then FOnKeyUp(Self, Key, Shift, Cancel);


  // Cancel=Trueならボタンのイベントは呼び出さない
  if Cancel = True then
    exit;

  bDoPaint     := False;

  FbRepaintNow := False;

  // シフト状態が変われば、再設定＆再描画
  if FShiftState <> Shift then begin

    // 既にボタンが押された状態で、Shift、Alt、Ctrlキーのみの変更は不可         2000.01.10 追加
    if FnBtnOnPressed <> 0 then
      exit;

    FShiftState := [];
    If (FbBtnAllowShiftKey = TRue) and (ssShift in Shift) then begin
      FShiftState := FShiftState + [ssShift];
    end;
    If (FbBtnAllowCtrlKey = True) and (ssCtrl in Shift) then begin
      FShiftState := FShiftState + [ssCtrl];
    end;
    If (FbBtnAllowAltKey = True) and (ssAlt in Shift) then begin
      FShiftState := FShiftState + [ssAlt];
    end;

   // カスタムタイマー監視終了
   CustomTimer.Enabled  := False;

   bDoPaint     := True;
//    paint;
//    invalidate;

  end;

  // ボタンが押された時に、反応する設定であれば、反応
  if FbBtnAllowKey = True then begin

    // ファンクションキーが押されたか？
    nFKeyNo := 0;
    case Key of
      VK_F1:  nFKeyNo := 1;
      VK_F2:  nFKeyNo := 2;
      VK_F3:  nFKeyNo := 3;
      VK_F4:  nFKeyNo := 4;
      VK_F5:  nFKeyNo := 5;
      VK_F6:  nFKeyNo := 6;
      VK_F7:  nFKeyNo := 7;
      VK_F8:  nFKeyNo := 8;
      VK_F9:  nFKeyNo := 9;
      VK_F10: nFKeyNo := 10;
      VK_F11: nFKeyNo := 11;
      VK_F12: nFKeyNo := 12;
    end;

    // ファンクションキーが押されていた時だけ、クリックイベントを動かす
    if nFKeyNo <> 0 then begin
      if HSpeedExtBtn[nFKeyNo-1] = nil then begin
        exit;
      end else if HSpeedExtBtn[nFKeyNo-1].Enabled = False then begin
        exit;
      end;

      // 現在押されているボタンを設定
      FnActiveBtnNo := nFKeyNo;

      // 現在ボタンが押されているボタンと違えばUpしない
      if FnBtnOnPressed <> nFKeyNo then
        exit;

      // ボタンを上げる(この瞬間にボタンのOnClickイベントが働く)
      HSpeedExtBtn[nFKeyNo-1].UppedButton(Sender, FShiftState, 0, 0);

      // カスタムタイマー監視終了
      CustomTimer.Enabled  := False;

      // 現在ボタンが押されていない状態にする
      FnBtnOnPressed := 0;

      bDoPaint     := True;
//      invalidate;

    end;


  end;

  if bDoPaint = True then begin
//    invalidate;                                                               2001.02.20 変更
    DoPaintCtrl;

    //    paint;
  end;

end;

//**********************************************************************//
// Module Name     :  プロパティ用処理関数群                            //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.10.05                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THFuncKey.LoadBtnImage(inShiftState, inIdx: integer; ihBm:TBitmap): integer;
begin

  if (HSpeedExtBtn[inIdx] = nil) or (ihBm = nil) then begin
    Result := 5;
    exit;
  end;

  // リソース低減の為、オンデマンドでビットマップをクリエート
  try
    if inShiftState = 0 then begin
      if BtnBitmap[inIdx] = nil then
        BtnBitmap[inIdx] := TBitMap.Create;
      BtnBitmap[inIdx].Assign(ihBm);
    end else if inShiftState = 1 then begin
      if BtnShiftBitmap[inIdx] = nil then
        BtnShiftBitmap[inIdx] := TBitMap.Create;
      BtnShiftBitmap[inIdx].Assign(ihBm);
    end else if inShiftState = 2 then begin
      if BtnCtrlBitmap[inIdx] = nil then
        BtnCtrlBitmap[inIdx] := TBitMap.Create;
      BtnCtrlBitmap[inIdx].Assign(ihBm);
    end else if inShiftState = 3 then begin
      if BtnAltBitmap[inIdx] = nil then
        BtnAltBitmap[inIdx] := TBitMap.Create;
      BtnAltBitmap[inIdx].Assign(ihBm);
    end;

    // 現在押されているボタンを設定(ダミー)
    FnActiveBtnNo := inIdx + 1;

    DoPaintCtrl;

//    invalidate;                                                               2002.11.13 削除

  except
    else begin
           Result := 5;
           exit;
         end;
  end;

  Result := 0;

end;
//---------------------------------------------------------------------------
function THFuncKey.LoadBtnImageFromResourceID(inShiftState, inIdx: integer; iInstance: THandle; iResID: Integer): integer;
begin

  if (HSpeedExtBtn[inIdx] = nil) or
       (iInstance = 0) or (iResID = 0) then begin
    Result := 5;
    exit;
  end;

  // リソース低減の為、オンデマンドでビットマップをクリエート
  try
    if inShiftState = 0 then begin
      if BtnBitmap[inIdx] = nil then
        BtnBitmap[inIdx] := TBitMap.Create;
      BtnBitmap[inIdx].LoadFromResourceID(iInstance, iResID);
    end else if inShiftState = 1 then begin
      if BtnShiftBitmap[inIdx] = nil then
        BtnShiftBitmap[inIdx] := TBitMap.Create;
      BtnShiftBitmap[inIdx].LoadFromResourceID(iInstance, iResID);
    end else if inShiftState = 2 then begin
      if BtnCtrlBitmap[inIdx] = nil then
        BtnCtrlBitmap[inIdx] := TBitMap.Create;
      BtnCtrlBitmap[inIdx].LoadFromResourceID(iInstance, iResID);
    end else if inShiftState = 3 then begin
      if BtnAltBitmap[inIdx] = nil then
        BtnAltBitmap[inIdx] := TBitMap.Create;
      BtnAltBitmap[inIdx].LoadFromResourceID(iInstance, iResID);
    end;

    // 現在押されているボタンを設定(ダミー)
    FnActiveBtnNo := inIdx + 1;

    DoPaintCtrl;                                                                // 2001.03.09 追加

    invalidate;

  except
    else begin
           Result := 5;
           exit;
         end;
  end;

  Result := 0;

end;
//---------------------------------------------------------------------------
function  THFuncKey.LoadBtnImageFromFile(inShiftState, inIdx: integer; istrFileName:string): integer;
begin

  if (HSpeedExtBtn[inIdx] = nil) or (istrFileName = '') then begin
    Result := 5;
    exit;
  end;

  // リソース低減の為、オンデマンドでビットマップをクリエート
  try
    if inShiftState = 0 then begin
      if BtnBitmap[inIdx] = nil then
        BtnBitmap[inIdx] := TBitMap.Create;
      BtnBitmap[inIdx].LoadFromFile(istrFileName);
    end else if inShiftState = 1 then begin
      if BtnShiftBitmap[inIdx] = nil then
        BtnShiftBitmap[inIdx] := TBitMap.Create;
      BtnShiftBitmap[inIdx].LoadFromFile(istrFileName);
    end else if inShiftState = 2 then begin
      if BtnCtrlBitmap[inIdx] = nil then
        BtnCtrlBitmap[inIdx] := TBitMap.Create;
      BtnCtrlBitmap[inIdx].LoadFromFile(istrFileName);
    end else if inShiftState = 3 then begin
      if BtnAltBitmap[inIdx] = nil then
        BtnAltBitmap[inIdx] := TBitMap.Create;
      BtnAltBitmap[inIdx].LoadFromFile(istrFileName);
    end;

    // 現在押されているボタンを設定(ダミー)
    FnActiveBtnNo := inIdx + 1;

    DoPaintCtrl;

    invalidate;

  except
    else begin
           Result := 5;
           exit;
         end;
  end;

  Result := 0;

end;
//---------------------------------------------------------------------------
function THFuncKey.FreeBtnImage(inShiftState, inIdx: integer): integer;
begin

  try

    if inShiftState = 0 then begin
      if BtnBitmap[inIdx] <> nil then begin
        with BtnBitmap[inIdx] do begin
          Height  := 0;
          Width   := 0;
          Dormant;
          FreeImage;
          ReleaseHandle;
        end;
      end;
    end else if inShiftState = 1 then begin
      if BtnShiftBitmap[inIdx] <> nil then begin
        with BtnShiftBitmap[inIdx] do begin
          Height := 0;
          Width  := 0;
          Dormant;
          FreeImage;
          ReleaseHandle;
        end;
      end;
    end else if inShiftState = 2 then begin
      if BtnCtrlBitmap[inIdx] <> nil then begin
        with BtnCtrlBitmap[inIdx] do begin
          Height := 0;
          Width  := 0;
          Dormant;
          FreeImage;
          ReleaseHandle;
        end;
      end;
    end else if inShiftState = 3 then begin
      if BtnAltBitmap[inIdx] <> nil then begin
        with BtnAltBitmap[inIdx] do begin
          Height := 0;
          Width  := 0;
          Dormant;
          FreeImage;
          ReleaseHandle;
        end;
      end;
    end;

    DoPaintCtrl;

    invalidate;

  except
    else begin
           Result := 5;
           exit;
         end;
  end;

  Result := 0;

end;
//---------------------------------------------------------------------------
{procedure THFuncKey.SetColors(value: THExtBtnColor);
var
  i: integer;

begin

  FColors.Assign(value);

  //レイアウトの内容をHSeepdExtBtnに反映
  for i := 0 to FnBtnCount - 1 do begin

    if HSpeedExtBtn[i] = nil then
      break;

    HSpeedExtBtn[i].Colors.Assign(FColors);

  end;

//  if csDesigning  in ComponentState then
    repaint
//  else
//    invalidate;

end;}
procedure THFuncKey.SetColorsOnChange(Sender: TObject);
var
  i: integer;

begin

  //レイアウトの内容をHSeepdExtBtnに反映
  for i := 0 to FnBtnCount - 1 do begin

    if HSpeedExtBtn[i] = nil then
      break;

    HSpeedExtBtn[i].Colors.Assign(FColors);

  end;

//  if csDesigning  in ComponentState then
//    repaint
//  else
    invalidate;

end;
//---------------------------------------------------------------------------
procedure THFuncKey.SetActiveColor(value: TColor);
var
  i: integer;

begin

  if value <> FActiveColor then begin

    FActiveColor := value;

    //レイアウトの内容をHSeepdExtBtnに反映
    for i := 0 to FnBtnCount - 1 do begin

      if HSpeedExtBtn[i] = nil then
        break;

      HSpeedExtBtn[i].ActiveColor := FActiveColor;

    end;

    Invalidate;

  end;

end;
//---------------------------------------------------------------------------
procedure THFuncKey.SetDisabledHighlight(value: TColor);
var
  i: integer;

begin

  if value <> FDisabledHighlight then begin

    FDisabledHighlight:=value;

    //レイアウトの内容をHSeepdExtBtnに反映
    for i := 0 to FnBtnCount - 1 do begin

      if HSpeedExtBtn[i] = nil then
        break;

      HSpeedExtBtn[i].DisabledHighlight := FDisabledHighlight;

    end;

    Invalidate;

  end;

end;
//---------------------------------------------------------------------------
procedure THFuncKey.SetDisabledShadow(value: TColor);
var
  i: integer;

begin

  if value <> FDisabledShadow then begin

    FDisabledShadow := value;

    //レイアウトの内容をHSeepdExtBtnに反映
    for i := 0 to FnBtnCount - 1 do begin

      if HSpeedExtBtn[i] = nil then
        break;

      HSpeedExtBtn[i].DisabledShadow := FDisabledShadow;

    end;

    Invalidate;

  end;

end;
//---------------------------------------------------------------------------
procedure THFuncKey.SetActiveImage(value: TActiveImageType);
var
  i: integer;

begin

  if value <> FActiveImage then begin

    FActiveImage := value;

    //レイアウトの内容をHSeepdExtBtnに反映
    for i := 0 to FnBtnCount - 1 do begin

      if HSpeedExtBtn[i] = nil then
        break;

      HSpeedExtBtn[i].ActiveImage := FActiveImage;

    end;

    Invalidate;

  end;

end;
//---------------------------------------------------------------------------
procedure THFuncKey.SetDisabledImage(value: TDisabledImageType);
var
  i: integer;

begin

  if value <> FDisabledImage then begin

    FDisabledImage := value;

    //レイアウトの内容をHSeepdExtBtnに反映
    for i := 0 to FnBtnCount - 1 do begin

      if HSpeedExtBtn[i] = nil then
        break;

      HSpeedExtBtn[i].DisabledImage := FDisabledImage;

    end;

    Invalidate;

  end;

end;
//---------------------------------------------------------------------------
procedure THFuncKey.SetActiveFrame(value: Boolean);
var
  i: integer;

begin

  if FActiveFrame <> value then begin

    FActiveFrame := value;

    //レイアウトの内容をHSeepdExtBtnに反映
    for i := 0 to FnBtnCount - 1 do begin

      if HSpeedExtBtn[i] = nil then
        break;

      HSpeedExtBtn[i].ActiveFrame := FActiveFrame;

    end;

    Invalidate;

  end;

end;
//---------------------------------------------------------------------------
procedure THFuncKey.SetUpFrame(Value: Boolean);
var
  i: integer;

begin

  if FUpFrame <> value then begin

    FUpFrame := value;

    //レイアウトの内容をHSeepdExtBtnに反映
    for i := 0 to FnBtnCount - 1 do begin

      if HSpeedExtBtn[i] = nil then
        break;

      HSpeedExtBtn[i].UpFrame := FUpFrame;

    end;

    Invalidate;

  end;
end;
//---------------------------------------------------------------------------
procedure THFuncKey.SetDownFrame(Value: Boolean);
var
  i: integer;
begin

  if FDownFrame <> value then begin

    FDownFrame := value;

    //レイアウトの内容をHSeepdExtBtnに反映
    for i := 0 to FnBtnCount - 1 do begin

      if HSpeedExtBtn[i] = nil then
        break;

      HSpeedExtBtn[i].DownFrame := FDownFrame;

    end;

    Invalidate;

  end;

end;
//---------------------------------------------------------------------------
procedure THFuncKey.SetFrameType(value: TFrameType);
var
 i: integer;

begin

  if value <> FFrameType then begin

    FFrameType := value;

    //レイアウトの内容をHSeepdExtBtnに反映
    for i := 0 to FnBtnCount - 1 do begin

      if HSpeedExtBtn[i] = nil then
        break;

      HSpeedExtBtn[i].FrameType := FFrameType;

    end;

    Invalidate;

  end;

end;
//---------------------------------------------------------------------------
procedure THFuncKey.SetTransparent(value: Boolean);
var
  i: integer;

begin

  if value <> FTransparent then begin


    FTransparent := value;

    for i := 0 to FnBtnCount - 1 do begin

      HSpeedExtBtn[i].Transparent := FTransparent;

    end;

    FbRepaintNow := False;

    // 透過処理の内容に従ってバックカラーを変える
    if FTransparent = True then begin
//      if Color <>  FForm.Color then begin                                     2002.11.13 変更
//        Color :=  FForm.Color;
//      end;
      if Parent is TPanel then begin
        if Color <> TPanel(Parent).Color then begin
          Color := TPanel(Parent).Color;
        end;
      end else if Parent is TCoolBar then begin
        if Color <> TCoolBar(Parent).Color then begin
          Color := TCoolBar(Parent).Color;
        end;
      end else if Parent is TToolBar then begin
        if Color <> TToolBar(Parent).Color then begin
          Color := TToolBar(Parent).Color;
        end;
      end else if Parent is TForm then begin
        if Color <> TForm(Parent).Color then begin
          Color := TForm(Parent).Color;
        end;
      end;
    end else begin
      if Color <> FBackColor then begin
        Color :=  FBackColor;
      end;
    end;

    Invalidate;

  end;


end;
//---------------------------------------------------------------------------
procedure THFuncKey.SetFontHighlight(value: TColor);
var
  i: integer;
begin

  FFontHighlight := value ;

  //レイアウトの内容をHSeepdExtBtnに反映
  for i := 0 to FnBtnCount - 1 do begin

    if HSpeedExtBtn[i] = nil then
      break;

    HSpeedExtBtn[i].FontHighlight := FFontHighlight;

  end;

  Invalidate;

end;
//---------------------------------------------------------------------------
procedure THFuncKey.SetFontShadow(value: TColor);
var
  i: integer;

begin

  FFontShadow := value ;

  //レイアウトの内容をHSeepdExtBtnに反映
  for i := 0 to FnBtnCount - 1 do begin

    if HSpeedExtBtn[i] = nil then
      break;

    HSpeedExtBtn[i].ActiveFont.Assign(FActiveFont);


  end;

  Invalidate;

end;

procedure THFuncKey.FontsAndColorsOnChange(Sender: TObject);
begin
  Invalidate;
end;

procedure THFuncKey.SetActiveFont(value: TFont);
var
 i : integer;
begin

  if Assigned(value) then begin

    FActiveFont.Assign(value);

    //レイアウトの内容をHSeepdExtBtnに反映
    for i := 0 to FnBtnCount - 1 do begin

      if HSpeedExtBtn[i] = nil then
        break;

       HSpeedExtBtn[i].ActiveFont.Assign(FActiveFont);

    end;

    Invalidate;

  end;

end;

procedure THFuncKey.SetBtnCount(value: integer);
begin

  // 20個が最大個数
  if (Value = 0) or (Value > 20) then
    exit;

  // ボタン数が違えば、コントロールを再設定
  if FnBtnCount <> value then begin

    if FnBtnCount < value then begin
      // ボタン作成
      CreateBtnCtrl(Self, FnBtnCount, value-1);
    end else begin
      // ボタン破棄
      RemoveBtnCtrl(Self, value-1);
    end;

  end else begin
    // イコールは何もしない
    exit;
  end;

  FnBtnCount := value;

  // コントロールの幅を変える
  if (FnBtnCount mod 4) = 0 then
    FnSplit := 2
  else if (FnBtnCount mod 5) = 0 then
    FnSplit := 1
  else
    FnSplit := 0;

  FnNoUseBtn := ctMaxBtnCnt;                                      // 宣言後未使用ボタン

  CalcBtnPos;

  FbRepaintNow := False;

  invalidate;

end;

procedure THFuncKey.SetImageList(value: TImageList);
begin

   if FImageLIst = value then
     exit;

   // イメージリストを作成(オンデマンド)
   if FImageLIst = nil then
//     FImageLIst := TImageList.Create(Self);                                   2002.11.13 変更
     FImageLIst := value
   else
     FImageLIst := nil;

//   FImageLIst.Assign(value);                                                  2002.11.13 変更

//   paint;                                                                     2002.11.13 変更
   DoPaintCtrl;

end;

procedure THFuncKey.SetShiftImageList(value: TImageList);
begin

   if FShiftImageLIst = value then
     exit;

   // イメージリストを作成(オンデマンド)
   if FShiftImageLIst = nil then
//     FShiftImageLIst := TImageList.Create(Self);                              2002.11.13 変更
     FShiftImageLIst := value
   else
     FShiftImageLIst := nil;

//   FShiftImageLIst.Assign(value);                                             2002.11.13 変更

//   paint;                                                                     2002.11.13 変更

end;

procedure THFuncKey.SetCtrlImageList(value: TImageList);
begin

   if FCtrlImageLIst = value then
     exit;

   // イメージリストを作成(オンデマンド)
   if FCtrlImageLIst = nil then
//     FCtrlImageLIst := TImageList.Create(Self);
     FCtrlImageLIst := value
   else
     FCtrlImageLIst := nil;

//   FCtrlImageLIst.Assign(value);                                              2002.11.13 変更

//   paint;                                                                     2002.11.13 変更

end;

procedure THFuncKey.SetAltImageList(value: TImageList);
begin

   if FAltImageLIst = value then
     exit;

   // イメージリストを作成(オンデマンド)
   if FAltImageLIst = nil then
//     FAltImageLIst := TImageList.Create(Self);
     FAltImageLIst := value
   else
     FAltImageLIst := nil;

//   FAltImageLIst.Assign(value);                                               2002.11.13 変更

//   paint;                                                                     2002.11.13 変更

end;

procedure THFuncKey.SetBtnWidth(value: Integer);
begin

  if Value = 0 then
    exit;

  FnBtnWidth := value;

  FbRepaintNow := False;

  CalcBtnPos;

  invalidate;


end;

procedure  THFuncKey.SetBtnHeight(value: Integer);
begin

  if Value = 0 then
    exit;

  FnBtnHeight := value;

  CalcBtnPos;

  invalidate;

end;

procedure THFuncKey.SetBtnCaption(value:TCaptionStrings);
begin

  if value.Count = 0 then
    value.Add('');

  FCaptions.assign(value);

  Perform(CM_TEXTCHANGED, 0, 0);

  if csDesigning  in ComponentState then
    repaint
  else
    invalidate;

end;

procedure THFuncKey.SetBtnShiftCaption(value:TCaptionStrings);
begin

  if value.Count = 0 then
    value.Add('');

  FShiftCaptions.assign(value);

  Perform(CM_TEXTCHANGED, 0, 0);

  if csDesigning  in ComponentState then
    repaint
  else
    invalidate;

end;

procedure THFuncKey.SetBtnCtrlCaption(value:TCaptionStrings);
begin

  if value.Count = 0 then
    value.Add('');

  FCtrlCaptions.assign(value);

  Perform(CM_TEXTCHANGED, 0, 0);

  if csDesigning  in ComponentState then
    repaint
  else
    invalidate;

end;

procedure THFuncKey.SetBtnAllowKey(value:boolean);
begin

  FbBtnAllowKey := value;

end;

procedure THFuncKey.SetBtnAltCaption(value:TCaptionStrings);
begin

  if value.Count = 0 then
    value.Add('');

  FAltCaptions.assign(value);

  Perform(CM_TEXTCHANGED, 0, 0);

  invalidate;

end;
function THFuncKey.GetBtnEnabled(index:integer): boolean;
begin


  if index >= FnBtnCount then begin
    Result := False;
    exit;
  end;

  Result := BtnEnable[index];

end;

procedure THFuncKey.SetBtnEnabled(index:integer; value:boolean);
begin

  if index >= FnBtnCount then
    exit;

  BtnEnable[index] := value;

  Perform(CM_ENABLEDCHANGED, 0, 0);

  invalidate;

end;
function THFuncKey.GetBtnShiftEnabled(index:integer): boolean;
begin


  if index >= FnBtnCount then begin
    Result := False;
    exit;
  end;

  Result := BtnShiftEnable[index];

end;

procedure THFuncKey.SetBtnShiftEnabled(index:integer; value:boolean);
begin

  if index >= FnBtnCount then
    exit;

  BtnShiftEnable[index] := value;

  Perform(CM_ENABLEDCHANGED, 0, 0);

  invalidate;

end;
function THFuncKey.GetBtnCtrlEnabled(index:integer): boolean;
begin


  if index >= FnBtnCount then begin
    Result := False;
    exit;
  end;

  Result := BtnCtrlEnable[index];

end;

procedure THFuncKey.SetBtnCtrlEnabled(index:integer; value:boolean);
begin

  if index >= FnBtnCount then
    exit;

  BtnCtrlEnable[index] := value;

  Perform(CM_ENABLEDCHANGED, 0, 0);

  invalidate;

end;
function THFuncKey.GetBtnAltEnabled(index:integer): boolean;
begin


  if index >= FnBtnCount then begin
    Result := False;
    exit;
  end;

  Result := BtnAltEnable[index];

end;

procedure THFuncKey.SetBtnAltEnabled(index:integer; value:boolean);
begin

  if index >= FnBtnCount then
    exit;

  BtnAltEnable[index] := value;

  Perform(CM_ENABLEDCHANGED, 0, 0);

  invalidate;

end;

{***************************************************************}
{マウスイベントに対する処理とその関連}
procedure THFuncKey.BtnClick(Sender: TObject);
var
  nFkeyNo : integer;
begin

  if Assigned(FOnBtnClick) then FOnBtnClick(Sender);

  nFKeyNo := THSpeedExtButton(Sender).LogicalNo;

  DoButtonClick(nFKeyNo, FShiftState);

end;

procedure THFuncKey.BtnMouseDown(Sender: TObject; Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
var
  Cancel: boolean;

begin

  // 使用不可なら押せない
  if Enabled = False then
    exit;

  // マウス押下中は新たに押せない
  if FnBtnMouseDowned > 0 then
    exit;

  // ボタン押下中は新たに押せない
  if FnBtnOnPressed > 0 then
    exit;

  Cancel := False;

  // コンポーネントMouseDownイベント
  if Assigned(FOnMouseDown) then FOnMouseDown(Sender, Button, Shift, X, Y, Cancel);

  // Cancel=Trueならボタンのイベントは呼び出さない
  if Cancel = True then
    exit;

  FnBtnMouseDowned := THSpeedExtButton(Sender).LogicalNo;

  // ボタンMouseDownイベント
  if Assigned(FOnBtnMouseDown) then FOnBtnMouseDown(Sender, Button, Shift, X, Y);

end;

{*******}
procedure THFuncKey.BtnMouseMove(Sender: TObject; Shift: TShiftState; X, Y: Integer);
begin

  // ボタンMouseMoveイベント
  if Assigned(FOnBtnMouseMove) then FOnBtnMouseMove(Sender, Shift, X, Y);

  // コンポーネントMouseMoveイベント
  if Assigned(FOnMouseMove) then FOnMouseMove(Sender, Shift, X, Y);


end;

{*******}

procedure THFuncKey.BtnMouseUp(Sender: TObject; Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
var
  Cancel: boolean;

begin

  Cancel := False;

  // コンポーネントMouseUpイベント
  if Assigned(FOnMouseUp) then FOnMouseUp(Sender, Button, Shift, X, Y, Cancel);

  // Cancel=Trueならボタンのイベントは呼び出さない
  if Cancel = True then
    exit;

  // 現在ボタンが押されているボタンと違えばUpしない
  if FnBtnMouseDowned <> THSpeedExtButton(Sender).LogicalNo then
   exit;

  // ボタンMouseUpイベント
  if Assigned(FOnBtnMouseUp) then FOnBtnMouseUp(Sender, Button, Shift, X, Y);

  FnBtnMouseDowned := 0;

end;

procedure THFuncKey.SetBackColor(value: TColor);
begin

  FBackColor := value;

  Invalidate;

end;

procedure THFuncKey.SetLayout(value: TButtonLayout);
var
  i: integer;
begin

  if (value <> FLayout) then begin

    FLayout := value;

    //レイアウトの内容をHSeepdExtBtnに反映
    for i := 0 to FnBtnCount - 1 do begin

      if HSpeedExtBtn[i] = nil then
        break;

      HSpeedExtBtn[i].Layout := FLayout;

    end;

    Invalidate;

  end;

end;

procedure THFuncKey.SetSplitWidth(value:integer);
begin

  if value < 0 then
    exit;

  FnSplitWidth := value;

  // コントロールの幅に合わせ、ボタンサイズを決定
  CalcBtnPos;

  Invalidate;

end;

{procedure THFuncKey.SetPressedColors(value: THExtBtnColor);
var
  i: integer;

begin

  FPressedColors.Assign(value);

  //レイアウトの内容をHSeepdExtBtnに反映
  for i := 0 to FnBtnCount - 1 do begin

    if HSpeedExtBtn[i] = nil then
      break;

    HSpeedExtBtn[i].PressedColors.Assign(FPressedColors);

  end;

end;}
procedure THFuncKey.SetPressedColorsOnChange(Sender: TObject);
var
  i: integer;

begin

  //レイアウトの内容をHSeepdExtBtnに反映
  for i := 0 to FnBtnCount - 1 do begin

    if HSpeedExtBtn[i] = nil then
      break;

    HSpeedExtBtn[i].PressedColors.Assign(FPressedColors);

  end;

  invalidate;

end;

function THFuncKey.CalcBtnPos: integer;
var
  i:       integer;
  nEndPos: integer;
  nWkCtrlWidth: integer;

begin

  Result := 0;

  // ボタン個数分ボタンをＲｅｐａｉｎｔ
  nEndPos := 0;


  // コントロールの幅に合わせ、ボタンサイズを決定
  if Align <> alNone then begin
    Width := Parent.ClientWidth;
    FnBtnWidth := ((Width - (FnSplit * FnSplitWidth)) div FnBtnCount);
  end else begin
    FnBtnWidth := ((Width - (FnSplit * FnSplitWidth)) div FnBtnCount);
    nWkCtrlWidth := (FnBtnWidth * FnBtnCOunt) + (FnSplit * FnSplitWidth);
    if (Width - nWkCtrlWidth) > FnBtnWidth then begin
      Width := nWkCtrlWidth;
    end;
  end;

  if Height <> FnBtnHeight then begin
    if Align <> alClient then
      FnBtnHeight := Height
    else
      Height  := FnBtnHeight;
  end;

  // 各ボタンコントロールに命令
   for i := 0 to FnBtnCount - 1 do begin

     if HSpeedExtBtn[i] <> nil then begin

       with  HSpeedExtBtn[i] do begin

         Width       := FnBtnWidth;                           // 内部ボタン幅
         Height      := FnBtnHeight;                          // 内部ボタン高さ

         // ボタン位置
         if i > 0 then begin
           if FnSplitWidth <> 0 then begin
             if (FnSplit = 2) and ((i mod 4) = 0) then
               left  := nEndPos + FnSplitWidth
             else if (FnSplit = 1) and ((i mod 5) = 0) then
               left  := nEndPos + FnSplitWidth
             else
               left  := nEndPos;
             end else  begin
               left  := nEndPos;
             end;
           end else begin
             left     := 0;
         end;

        nEndPos := Left + Width;

       end;

     end;

   end;

  // 使用していないコントロールを見えなくする
  for i := FnBtnCount to FnNoUseBtn  -1 do begin

    if HSpeedExtBtn[i] <> nil then begin
      if csDesigning in ComponentState then begin
        HSpeedExtBtn[i].Left    := FForm.Width + 100;
      end else begin
        if HSpeedExtBtn[i].visible = True then begin
          HSpeedExtBtn[i].Visible := False;
        end;
      end;
    end;

  end;

  refresh;
  
end;

function THFuncKey.SetBtnProperty: integer;
var
  i: integer;

begin

  // 各ボタンコントロールに命令
  for i := 0 to FnBtnCount - 1 do begin

    if HSpeedExtBtn[i] = nil then
      break;

    // ボタンの整列
    with HSpeedExtBtn[i] do begin

      Visible           := True;
      Layout            := FLayout;
      ActiveColor       := FActiveColor;
      ActiveFrame       := FActiveFrame;
      UpFrame           := FUpFrame;
      DownFrame         := FDownFrame;
      Transparent       := FTransparent;
      FrameType         := FFrameType;
      DisabledImage     := FDisabledImage;
      DisabledHighlight := FDisabledHighlight;
      DisabledShadow    := FDisabledShadow;
      FontHighlight     := FFontHighlight;
      FontShadow        := FFontShadow;
      ActiveImage       := FActiveImage;
      ActiveFont        := FActiveFont;
      PressedColors.Assign(FPressedColors);
      Colors.Assign(FColors);
    end;

    HSpeedExtBtn[i].Font := Font;

  end;

  DoPaintCtrl;

  Result := 0;

end;

// プロパティ変更
procedure THFuncKey.CMFontChanged(var Message: TMessage);
begin
  inherited;

  Invalidate;

  DoPaintCtrl;

end;

procedure THFuncKey.CMTextChanged(var Message: TMessage);
begin
  inherited;

  Invalidate;

  DoPaintCtrl;

end;

procedure THFuncKey.CMEnabledChanged(var Message: TMessage);
begin
  inherited;

  Invalidate;

  DoPaintCtrl;

end;

// 2002.11.13 追加
procedure THFuncKey.SetDoubleBuffered(value:boolean);
begin

  // 設定値が変われば、親を見て、TWinControl系ならばDoubleBuffred=Trueに
  if FCtrlDoubleBuffered <> value then begin
    if not (csDesigning in ComponentState) then begin
      if (Parent is TWinControl) and (value = True) then begin
        TWinControl(Parent).DoubleBuffered := True;
      end;
    end;
    FCtrlDoubleBuffered := value;
  end

end;

// 20002.11.13 追加
procedure THFuncKey.SetReleaseTime(value: cardinal);
begin

  if value <> FReleaseTime then begin

    FReleaseTime := value;
    if CustomTimer <> nil then begin
      CustomTimer.Interval := FReleaseTime;
    end;

  end;

end;

//---------------------------------------------------------------------------
procedure THFuncKey.CMButtonPressed(var Message: TMessage);

begin

  Invalidate;

end;

// イベント群

procedure  THFuncKey.DoButtonClick(FuncKeyNo:integer; Shift: TShiftState);
begin

  // ボタンクリックイベント
  if Assigned(FOnClickFuncKey) then FOnClickFuncKey(Self, FuncKeyNo, Shift);

end;

end.
