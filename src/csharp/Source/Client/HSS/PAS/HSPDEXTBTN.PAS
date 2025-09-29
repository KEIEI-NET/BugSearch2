unit HSpdExtBtn;
//**********************************************************************//
// System           :   システム共通                                    //
// Sub System       :   HSS部品                                         //
// Program name     :   Speed Extended Buttonコンポーネント             //
//                  :   HSpdExtBtn                                      //
// Programer        :   鹿野　幸生                                      //
// Date             :   2000.10.12                                      //
//----------------------------------------------------------------------//
// Update Note      :   ① マウス通過時のボタンリリース時間を設定する   //
//                  :      プロパティの追加                             //
//                  :   2009.08.12  鹿野　幸生                          //
//                  :   ① HSS100対応                                   //
//----------------------------------------------------------------------//
//                (c)Copyright  2000 TSUBASA SYSTEM Co,. Ltd            //
//**********************************************************************//

interface

{$S-,W-,R-}

uses
   Windows, Controls, Classes, Buttons, StdCtrls, ExtCtrls,
   Messages, Graphics, CommCtrl, Forms, HVersion;

type
  TDisabledImageType = (
    diDefault,          //スピードボタンで使われているものと同様
    diGrayscale,        //白→黒イメージ
    diAlphaHalfTrans,   //透過ソフトイメージ
    diAlphaQuaterTrans, //透過ハードイメージ
    diMaskTrans         //マスク模様の擬似透過イメージ
  );

  TActiveImageType = (
    aiNormal,       //ひかりらない
    aiXorLight,     //反転ライト
    aiHalfLight,    //透過ソフトライト
    aiQuaterLight,  //透過ハードライト
    aiAddLight,     //加算ライト
    aiFrameLight,   //ｱｲｺﾝの周り１ドットピカピカ
    aiFrameLight2,  //ｱｲｺﾝの周り２ドットピカピカ
    aiMaskLight     //マスク模様の擬似透過ライト
  );

  TFrameType = (
    ftFlatFrame,     //IE4/Office97/Borland型ボタンフレーム
    ftNormalFrame,   //通常のボタンフレーム
    ftEnclosedFrame  //Netscape4型ボタンフレーム
  );

  T_ActiveButtonState = (
    _sbsActiveDown,
    _sbsDown,
    _sbsActiveUp,
    _sbsUp,
    _sbsDisableUp,
    _sbsMax
  );

  THExtBtnColor = class(TPersistent)
  private
    FColor:      TColor;
    FHighlight:  TColor;
    FShadow:     TColor;
    FDarkShadow: TColor;
    FGradColor:  TColor;
    FGradVertical: Boolean;
    FGradation:    Boolean;
    FOnChange:  TNotifyEvent;
    procedure   SetColor(value: TColor);
    procedure   SetHighlight(value: TColor);
    procedure   SetShadow(value: TColor);
    procedure   SetDarkShadow(value: TColor);
    procedure   SetGradVertical(value: Boolean);
    procedure   SetGradColor(value: TColor);
    procedure   SetGradation(value: Boolean);
  protected
    procedure   AssignTo(Dest: TPersistent); override;
  public
    constructor Create;
    destructor  Destroy; override;
    procedure   Assign(Source: TPersistent); override;
    property    OnChange: TNotifyEvent read FOnChange write FOnChange ;
  published
    property    Highlight: TColor     read FHighlight    write SetHighlight    default clBtnHighlight ;
    property    Shadow: TColor        read FShadow       write SetShadow       default clBtnShadow ;
    property    DarkShadow: TColor    read FDarkShadow   write SetDarkShadow   default clWindowFrame ;
    property    GradColor: TColor     read FGradColor    write SetGradColor    default clBlue ;
    property    GradVertical: Boolean read FGradVertical write SetGradVertical default False ;
    property    Gradation: Boolean    read FGradation    write SetGradation    default False ;
    property    Color:TColor          read FColor        write SetColor        nodefault ;
  end;

  THSpeedExtButton = class(TGraphicControl)
  private
    //published Values
    FDown: Boolean;                                         //現在、ボタンが押されているかどうか
    FClickDownHook: Boolean;
    FAccelCharDown: Boolean;
    FFrameType: TFrameType;                                 //フレームの種類
    FAllowAllUp: Boolean;
    FGroupIndex: Integer;
    FLayout: TButtonLayout;
    FMargin: Integer;
    FSpacing: Integer;
    FTransparent: Boolean;                                  // 透過有効・無効
    FActiveFrame: Boolean;                                  // アクティブなフレーム描画を行うかどうか
    FUpFrame: Boolean;                                      // 上がった状態のフレーム描画を行うかどうか
    FDownFrame:         Boolean;                            // 下がった状態のフレーム描画を行うかどうか
    FActiveImage:       TActiveImageType;
    FDisabledImage:     TDisabledImageType ;                // 使用不可の時の表示メソッド
    FDisabledShadow:    TColor;                             // 使用不可のシャドウ色
    FDisabledHighlight: TColor;                             // 使用不可のハイライト色
    FColors:         THExtBtnColor;                         // デフォルトの背景色
    FPressedColors:  THExtBtnColor;                         // 押した時の背景色
    FActiveColor:    TColor;                                // アクティブ時の色
    FFont:           TFont;                                 // デフォルト文字スタイル
    FFontHighlight:  TColor;                                // フォントのハイライト色
    FFontShadow:     TColor;                                // フォントのシャドウ色
    FActiveFont:     TFont;                                 // アクティブ文字スタイル
    FGlyph:          TBitmap;                               // グリフ
    FVersion:        TVersion;                              // バージョン
    FCaption:        string;                                // キャプション
    FbCaptionWrap:   boolean;                               // キャプション文字列のラップ処理
    FReleaseTime:    cardinal;                                                  // 2002.11.13 追加
    FOnMouseEnter,FOnMouseLeave : TMouseMoveEvent ;         // マウスの エンター・リーブ イベント
    // PublicValues
    FMouseInControl: Boolean;
    // PrivateValues
    FDragging: Boolean;
    _ButtonState: T_ActiveButtonState ;                     // 現在のボタンの状態
    FActiveButtonTimer: TTimer;                             // リーブイベントが発生しない場合の自動非アクティブ化タイマー
    FAccelSB: TSpeedButton;
    FnLogicalNo: integer;
    //Set
    function  GetCaption: string;
    procedure SetCaption(value: string);
    procedure SetCaptionWrap(value: boolean);
    procedure SetClickDownHook(value: Boolean);
    procedure SetAccelCharDown(value: Boolean);
    procedure SetActiveFrame(value: Boolean);
    procedure SetUpFrame(value: Boolean);
    procedure SetDownFrame(value: Boolean);
    procedure SetFrameType(value: TFrameType);
    procedure SetTransparent(value: Boolean);
    procedure SetGlyph(value: TBitmap);
    procedure SetColors(value: THExtBtnColor);
    procedure SetPressedColors(value: THExtBtnColor);
    procedure SetActiveColor(value: TColor);
    procedure SetFont(value: TFont);
    procedure SetFontHighlight(value: TColor);
    procedure SetFontShadow(value: TColor);
    procedure SetActiveFont(value: TFont);
    procedure SetActiveImage(value: TActiveImageType);
    procedure SetDisabledImage(value: TDisabledImageType);
    procedure SetDisabledHighlight(value: TColor);
    procedure SetDisabledShadow(value: TColor);
    procedure SetDown(value: Boolean);
    procedure SetAllowAllUp(value: Boolean);
    procedure SetGroupIndex(value: Integer);
    procedure SetLayout(value: TButtonLayout);
    procedure SetMargin(value: Integer);
    procedure SetSpacing(value: Integer);
    // PrivateEvent
    procedure GlyphOnChange(Sender: TObject);
    procedure ActiveButtonTimerOnTimer(Sender: TObject);
    procedure FontsAndColorsOnChange(Sender: TObject);
    procedure SetReleaseTime(value: cardinal);                                  // 2002.11.13 追加
    // PrivateFunction
    procedure BackDraw(Canvas: TCanvas);
    procedure ImageDraw(Canvas: TCanvas);
    procedure FrameDraw(Canvas: TCanvas);
    function  CreateStateGlyph: TBitmap;
    procedure UpdateTracking;
    procedure GroupUpdateStatus(grpIndex: Integer);
    procedure CalcDrawPosition(Canvas: TCanvas;var iPos: TPoint ; var fTextBounds: TRect);
    // MessageHookers
    procedure WMLButtonDblClick(var Message: TWMLButtonDown); message WM_LBUTTONDBLCLK ;
    procedure CMEnabledChanged(var Message: TMessage); message CM_ENABLEDCHANGED ;
    procedure CMDialogChar(var Message: TCMDialogChar); message CM_DIALOGCHAR ;
    procedure CMFontChanged(var Message: TMessage); message CM_FONTCHANGED ;
    procedure CMTextChanged(var Message: TMessage); message CM_TEXTCHANGED ;
    procedure CMSysColorChange(var Message: TMessage); message CM_SYSCOLORCHANGE ;
    procedure CMMouseEnter(var Message: TMessage); message CM_MOUSEENTER ;
    procedure CMMouseLeave(var Message: TMessage); message CM_MOUSELEAVE ;
    procedure CMButtonPressed(var Message: TMessage); message CM_BUTTONPRESSED ;
  protected
    //Override Methods
    procedure Paint; override;
    procedure Loaded; override;
    procedure MouseDown(Button: TMouseButton ; ShiftState: TShiftState ; X,Y: Integer ); override ;
    procedure MouseMove(ShiftState: TShiftState ; X,Y: integer ); override;
    procedure MouseUp(Button: TMouseButton ; Shift: TShiftState ; X,Y: Integer ); override ;
    //new dynamics
    procedure MouseEnter(ShiftState: TShiftState ; X,Y: integer ); dynamic;
    procedure MouseLeave(ShiftState: TShiftState ; X,Y: integer ); dynamic;
  public
    constructor Create(AOwner: TComponent); override ;
    destructor Destroy; override ;
    procedure Click; override ;
    procedure PressedButton(Sender: TObject; ShiftState: TShiftState; X,Y: Integer );
    procedure UppedButton(Sender: TObject; ShiftState: TShiftState; X,Y: Integer );
    //public properties
    property MouseInControl:Boolean read FMouseInControl ;
  published
    // Extra Properties
    property GroupIndex: Integer read FGroupIndex write SetGroupIndex default 0 ;
    property Down: Boolean read FDown write SetDown default False ;
    property ClickDownHook: Boolean read FClickDownHook write SetClickDownHook default False ;
    property AccelCharDown: Boolean read FAccelCharDown write SetAccelCharDown default False ;
    property FrameType: TFrameType read FFrameType write SetFrameType default ftNormalFrame ;
    property Transparent: Boolean read FTransparent write SetTransparent default False ;
    property ActiveFrame: Boolean read FActiveFrame write SetActiveFrame default True ;
    property UpFrame: Boolean read FUpFrame write SetUpFrame default True ;
    property DownFrame: Boolean read FDownFrame write SetDownFrame default True;
    property ActiveImage: TActiveImageType
      read FActiveImage write SetActiveImage default aiFrameLight ;
    property DisabledImage: TDisabledImageType
      read FDisabledImage write SetDisabledImage default diDefault ;
    property DisabledHighlight: TColor
      read FDisabledHighlight write SetDisabledHighlight default clBtnHighlight ;
    property DisabledShadow: TColor
      read FDisabledShadow write SetDisabledShadow default clBtnShadow ;
    property Colors: THExtBtnColor read FColors write SetColors ;
    property PressedColors: THExtBtnColor read FPressedColors write SetPressedColors ;
    property ActiveColor: TColor read FActiveColor write SetActiveColor default clYellow ;
    property Font: TFont read FFont write SetFont ;
    property FontHighlight: TColor read FFontHighlight write SetFontHighlight default clNone;
    property FontShadow: TColor read FFontShadow write SetFontShadow default clNone ;
    property ActiveFont: TFont read FActiveFont write SetActiveFont ;
    property AllowAllUp: Boolean read FAllowAllUp write SetAllowAllUp default False ;
    property Layout: TButtonLayout read FLayout write SetLayout default blGlyphLeft ;
    property Margin: Integer read FMargin write SetMargin default -1 ;
    property Spacing: Integer read FSpacing write SetSpacing default 4 ;
    property Glyph: TBitmap  read FGlyph write SetGlyph ;
    property LogicalNo: integer  read FnLogicalNo write FnLogicalNo;
    property Caption:      string          read GetCaption    write SetCaption;
    property CaptionWrap:  boolean         read FbCaptionWrap write SetCaptionWrap default True;
    property Version:      TVersion        read FVersion      write FVersion stored False;
    property ReleaseTime:  cardinal        read FReleaseTime  write SetReleaseTime;   // 2002.11.13 追加
    property OnMouseEnter: TMouseMoveEvent read FOnMouseEnter write FOnMouseEnter default NIL ;
    property OnMouseLeave: TMouseMoveEvent read FOnMouseLeave write FOnMouseLeave default NIL ;
    // Inherited Properties
    property Action;
    property Anchors;
    property BiDiMode;
    property Constraints;
    property ParentBiDiMode;
    property Align;
    property Cursor;
    property Enabled;
    property Height;
    property Hint;
    property Left;
    property Name;
    property ParentShowHint;
    property ShowHint;
    property Tag;
    property Top;
    property Visible;
    property Width;
    property OnClick;
    property OnDblClick;
    property OnMouseDown;
    property OnMouseMove;
    property OnMouseUp;
  end;

procedure Register;

implementation

uses
  Consts, SysUtils;

const
  ctDefaultReleaseTime = 200;                                                   // 2002.11.13 追加

//===Register================================================================
procedure Register;
begin

  RegisterComponents('HSS', [THSpeedExtButton]);

end;

//---------------------------------------------------------------------------
//===StaticFunctions=========================================================
//---------------------------------------------------------------------------
function ColorToTrueColor(color: TColor): DWORD ;
var
  val:DWORD ;
  r,g,b:DWORD ;
begin
  val := DWORD(ColorToRGB(color));
  b := (val shr 16 ) and 255  ;
  g := (val shr 8 ) and 255  ;
  r := (val shr 0 ) and 255 ;
  Result := (r shl 16) or (g shl 8) or b ;
end;

//---------------------------------------------------------------------------
function GetShiftState(): TShiftState ;
begin
  Result:=[];
  if (GetKeyState(VK_LBUTTON)and $8000)<>0 then Include(Result,ssLeft);
  if (GetKeyState(VK_RBUTTON)and $8000)<>0 then Include(Result,ssRight);
  if (GetKeyState(VK_MBUTTON)and $8000)<>0 then Include(Result,ssMiddle);
  if (GetKeyState(VK_SHIFT)  and $8000)<>0 then Include(Result,ssShift);
  if (GetKeyState(VK_CONTROL)and $8000)<>0 then Include(Result,ssCtrl);
  if (GetKeyState(VK_MENU)   and $8000)<>0 then Include(Result,ssAlt);
end;

//---------------------------------------------------------------------------
//===THSpeedExtBtn=========================================================
//---------------------------------------------------------------------------
constructor THExtBtnColor.Create;
begin
  Inherited Create;
  FColor:=clBtnFace;
  FHighlight:=clBtnHighlight;
  FShadow:=clBtnShadow;
  FDarkShadow:=clWindowFrame;
  FGradColor:=clBlue;
  FGradVertical:=False;
  FGradation:=False;
  FOnChange:=NIL;
end;

//---------------------------------------------------------------------------
destructor THExtBtnColor.Destroy;
begin
  FOnChange:=NIL;
  Inherited Destroy;
end;

//---------------------------------------------------------------------------
procedure THExtBtnColor.SetColor(value: TColor);
begin
  if FColor<>value then begin
    FColor:=value;
    if Assigned(FOnChange) then begin
      FOnChange(Self) ;
    end;
  end;
end;

//---------------------------------------------------------------------------
procedure THExtBtnColor.SetHighlight(value: TColor);
begin
  if FHighlight<>value then begin
    FHighlight:=value;
    if Assigned(FOnChange) then begin
      FOnChange(Self);
    end;
  end;
end;

//---------------------------------------------------------------------------
procedure THExtBtnColor.SetShadow(value: TColor);
begin
  if FShadow<>value then begin
    FShadow:=value;
    if Assigned(FOnChange) then begin
      FOnChange(Self);
    end;
  end;
end;

//---------------------------------------------------------------------------
procedure THExtBtnColor.SetDarkShadow(value: TColor);
begin
  if FDarkShadow<>value then begin
    FDarkShadow:=value;
    if Assigned(FOnChange) then begin
      FOnChange(Self);
    end;
  end;
end;

//---------------------------------------------------------------------------
procedure THExtBtnColor.SetGradVertical(value: Boolean);
begin
  if FGradVertical<>value then begin
    FGradVertical:=value;
    if Assigned(FOnChange) then begin
      FOnChange(Self);
    end;
  end;
end;

//---------------------------------------------------------------------------
procedure THExtBtnColor.SetGradColor(value: TColor);
begin
  if FGradColor<>value then begin
    FGradColor:=value;
    if Assigned(FOnChange) then begin
      FOnChange(Self);
    end;
  end;
end;

//---------------------------------------------------------------------------
procedure THExtBtnColor.SetGradation(value: Boolean);
begin
  if FGradation<>value then begin
    FGradation:=value;
    if Assigned(FOnChange) then begin
      FOnChange(Self);
    end;
  end
end;

//---------------------------------------------------------------------------
procedure THExtBtnColor.Assign(Source: TPersistent);
var SourceBtnColors: THExtBtnColor;
begin

  SourceBtnColors := THExtBtnColor(Source);

  FColor        := SourceBtnColors.FColor;
  FHighlight    := SourceBtnColors.FHighlight;
  FShadow       := SourceBtnColors.FShadow;
  FDarkShadow   := SourceBtnColors.FDarkShadow;
  FGradColor    := SourceBtnColors.FGradColor;
  FGradVertical := SourceBtnColors.FGradVertical;
  FGradation    := SourceBtnColors.FGradation;

  Inherited Assign(Source);

  if Assigned(FOnChange) then FOnChange(Self) ;
  
end;

//---------------------------------------------------------------------------
procedure THExtBtnColor.AssignTo(Dest: TPersistent);
var DestBtnColors: THExtBtnColor ;
begin
  //Inherited AssignTo(Dest);
  DestBtnColors := THExtBtnColor(Dest);
  DestBtnColors.FColor         := FColor;
  DestBtnColors.FHighlight    := FHighlight;
  DestBtnColors.FShadow       := FShadow;
  DestBtnColors.FDarkShadow   := FDarkShadow;
  DestBtnColors.FGradColor    := FGradColor;
  DestBtnColors.FGradVertical := FGradVertical;
  DestBtnColors.FGradation    := FGradation;
  if Assigned(DestBtnColors.FOnChange) then begin
    DestBtnColors.FOnChange(DestBtnColors);
  end;
end;

//---------------------------------------------------------------------------
//===THSpeedExtButton=======================================================
//---------------------------------------------------------------------------
constructor THSpeedExtButton.Create(Aowner: TComponent);
begin
  inherited Create(AOwner);

  ControlStyle := [csCaptureMouse,csDoubleClicks,csOpaque];

  FVersion           := HSpeedExtButtonVersion;

  FbCaptionWrap   := True; 
  FCaption        := ''; 

  FAccelSB := NIL ;
  FDown := False ;
  FClickDownHook := False ;
  FAccelCharDown := False ;
  FActiveImage   := aiFrameLight;
  FDisabledImage := diDefault;
  FDisabledHighlight := clBtnHighlight;
  FDisabledShadow := clBtnShadow;
  FActiveColor := clYellow;
  _ButtonState := _sbsUp;
  FActiveFrame := True;
  FUpFrame := True;
  FDownFrame := True;
  FAllowAllUp := False;
  FGroupIndex := 0;
  FTransparent := False;
  FFrameType := ftNormalFrame;
  FSpacing := 4;
  FMargin := -1;
  FLayout := blGlyphLeft;
  FColors := THExtBtnColor.Create;
  FColors.Color := clBtnFace;
  FColors.OnChange := FontsAndColorsOnChange;
  FPressedColors := THExtBtnColor.Create;
  FPressedColors.Color := clBtnHighlight;
  FPressedColors.OnChange := FontsAndColorsOnChange;

  FFont := TFont.Create;
  FFont.Color := clBtnText;
  FFont.OnChange := FontsAndColorsOnChange ;
  FFontHighlight := clNone ;
  FFontShadow := clNone ;
  FActiveFont := TFont.Create;
  FActiveFont.Color := clHighlight ;
  FActiveFont.OnChange := FontsAndColorsOnChange ;

  FGlyph := TBitmap.Create ;
  FGlyph.OnChange := GlyphOnChange;
  FGlyph.TransparentColor := clOlive;

  FReleaseTime := ctDefaultReleaseTime;                                         // 2002.11.13 追加

  FMouseInControl:=False;
  FOnMouseEnter := NIL ;
  FOnMouseLeave := NIL ;

  FActiveButtonTimer := TTimer.Create(Self);
//  FActiveButtonTimer.Interval := 200; //非アクテイブ化チェック実行まで200m秒。2002.11.13 変更
  FActiveButtonTimer.Interval := FReleaseTime; //非アクテイブ化チェック秒
  FActiveButtonTimer.Enabled := False ;
  FActiveButtonTimer.OnTimer := ActiveButtonTimerOnTimer ;

  FDragging := False;

  Width  := 25 ;
  Height := 25 ;

  Caption:='';
end;

//---------------------------------------------------------------------------
destructor THSpeedExtButton.Destroy;
begin

  FActiveButtonTimer.Enabled := False ;
  FActiveButtonTimer.Destroy;

  if Assigned(FGlyph) then FGlyph.Destroy ;

  FColors.Destroy;
  FPressedColors.Destroy;
  FFont.Destroy;
  FActiveFont.Destroy;

  Inherited Destroy;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.Loaded;
begin
  Inherited Loaded;
end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.Paint;
var Bitmap: TBitmap;
    DrawCanvas: TCanvas;
begin

  if not Enabled then begin
    _ButtonState:=_sbsDisableUp;
    FDragging:=false;
  end else begin
    {
    if MouseInControl then begin
      if FDown then _ButtonState := _sbsActiveDown
      else _ButtonState := _sbsActiveUp ;
    end;
    }
  end;
  if not FTransparent then begin
    Bitmap := TBitmap.Create();
    Bitmap.HandleType:=bmDDB;
    Bitmap.Width:=Width;
    Bitmap.Height:=Height;
    DrawCanvas:=Bitmap.Canvas;
  end else begin
    Bitmap:=NIL;
    DrawCanvas:=Canvas;
  end;
  //背景描画
  BackDraw(DrawCanvas);
  //イメージ描画
  ImageDraw(DrawCanvas);
  //枠線描画
  FrameDraw(DrawCanvas);
  if not FTransparent then begin
    if Assigned(Bitmap) then begin
      Canvas.Draw(0,0,Bitmap);
      Bitmap.Destroy;
    end;
  end;
end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.BackDraw(Canvas: TCanvas);
var
  backColor: TColor;
  grdColor: TColor;
  doGrad: Boolean;
  vertGrad: Boolean;
  rect: TRect;
  bm: TBitmap;
  gradTrue,backTrue: DWORD;
  grdR,grdG,grdB: Integer;
  bckR,bckG,bckB: Integer;
  r,g,b: Integer;
  line: PDWORD;
  i: Integer;

begin
  if not FTransparent then begin
    case _ButtonState of
      _sbsActiveDown,
      _sbsDown:
        with FPressedColors do begin
          backColor := Color;
          grdColor:= GradColor;
          doGrad    := Gradation;
          vertGrad  := GradVertical;
        end;
      else
     {_sbsActiveUp,
      _sbsUp,
      _sbsDisableUp:}
        with FColors do begin
          backColor := Color;
          grdColor  := GradColor;
          doGrad    := Gradation;
          vertGrad  := GradVertical;
        end;
    end;
    if not doGrad then begin //通常の背景
      rect:=ClientRect;
      with Canvas do begin
        Brush.Style:=bsSolid;
        Brush.Color:=backColor;
        FillRect(rect);
      end;
    end else begin //グラデーション背景
      bm:=TBitmap.Create();
      with bm do begin
        HandleType:=bmDIB;
        PixelFormat:=pf32bit;
      end;
      gradTrue:=ColorToTrueColor(grdColor);
      grdR:=Integer((gradTrue shr 16) and 255);
      grdG:=Integer((gradTrue shr 8) and 255);
      grdB:=Integer((gradTrue) and 255);
      backTrue:=ColorToTrueColor(backColor);
      bckR:=Integer((backTrue shr 16) and 255);
      bckG:=Integer((backTrue shr 8) and 255);
      bckB:=Integer((backTrue) and 255);
      if vertGrad then begin
        with bm do begin
          Width:=1;
          Height:=256;
        end;
        for i:=0 to 255 do begin
          line := PDWORD(bm.ScanLine[i]);
          r := (grdR-bckR)*i div 255 +bckR;
          g := (grdG-bckG)*i div 255 +bckG;
          b := (grdB-bckB)*i div 255 +bckB;
          line^ := (r shl 16)or(g shl 8)or b ;
        end;
      end else begin
        with bm do begin
          Width  := 256 ;
          Height := 1   ;
        end;
        line := PDWORD(bm.ScanLine[0]) ;
        for i:=0 to 255 do begin
          r:=(grdR-bckR)*i div 255 +bckR;
          g:=(grdG-bckG)*i div 255 +bckG;
          b:=(grdB-bckB)*i div 255 +bckB;
          line^ := (r shl 16)or(g shl 8)or b ;
          Inc(line);
        end;
      end;
      //bm.HandleType:=bmDDB;
      Canvas.StretchDraw(ClientRect,bm);
      bm.Free;
    end;
  end;
end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.ImageDraw(Canvas: TCanvas);
const
  ROP_DSPDxax = $00E20746;
var BM: TBitmap;
    iPos: TPoint;
    fTextBounds: TRect;
    color: TColor;

begin
  case _ButtonState of
    _sbsActiveDown,
    _sbsActiveUp:
      Canvas.Font:=FActiveFont
  else
      Canvas.Font:=FFont
  end;
  //リアルタイムに画像を生成する。でないと、ボタンの数を増やした場合に、
  //リソース不足のエラーでハングアップする危険性を伴う。
  BM:=CreateStateGlyph;
  CalcDrawPosition(Canvas,iPos,fTextBounds);
  if Assigned(BM) then begin
    if (_ButtonState=_sbsDown) or (_ButtonState=_sbsActiveDown) then begin
      with iPos do begin
        x := x + 1 ;
        y := y + 1 ;
      end;
    end;
    if (_ButtonState=_sbsDisableUp) and (FDisabledImage=diDefault) then begin
      Canvas.Brush.Color:=FDisabledHighlight;
      SetTextColor(Canvas.Handle,clBlack);
      SetBkColor(Canvas.Handle,clWhite);
      BitBlt(Canvas.Handle,iPos.x+1,iPos.y+1
        ,BM.Width,BM.Height
        ,BM.Canvas.Handle,0,0, ROP_DSPDxax);
      Canvas.Brush.Color:=FDisabledShadow;
      SetTextColor(Canvas.Handle,clBlack);
      SetBkColor(Canvas.Handle,clWhite);
      BitBlt(Canvas.Handle,iPos.x,iPos.y
        ,BM.Width,BM.Height
        ,BM.Canvas.Handle,0,0, ROP_DSPDxax);
    end else begin
      with Canvas do begin
        Brush.Style:=bsClear;
        Draw(iPos.x,iPos.y,BM);
      end;
    end;
    BM.Free;
  end;

  // キャンプション描画
  if Length(FCaption)>0 then begin

    if (_ButtonState=_sbsDown) or (_ButtonState=_sbsActiveDown) then begin
      OffsetRect(fTextBounds,1,1);
    end;
    Canvas.Brush.Style := bsClear;

    if _ButtonState=_sbsDisableUp then begin
      Canvas.Font.Color:=FDisabledHighlight;
      OffsetRect(fTextBounds,1,1);
      DrawText(Canvas.Handle,PChar(FCaption),Length(FCaption)
        ,fTextBounds,DT_CENTER or DT_VCENTER);
      Canvas.Font.Color := FDisabledShadow;
      OffsetRect(fTextBounds,-1,-1);
      DrawText(Canvas.Handle,PChar(FCaption),Length(FCaption)
        ,fTextBounds,DT_CENTER or DT_VCENTER);
    end else begin
      color := Canvas.Font.Color;
      //シャドウ描画
      if FFontShadow<>clNone then begin
        Canvas.Font.Color := FFontShadow ;
        OffsetRect(fTextBounds,1,1);
        DrawText(Canvas.Handle,PChar(FCaption),Length(FCaption)
          ,fTextBounds,DT_CENTER or DT_VCENTER);
        OffsetRect(fTextBounds,-1,-1);
      end;
      //ハイライト描画
      if FFontHighlight <> clNone then begin
        Canvas.Font.Color := FFontHighlight ;
        OffsetRect(fTextBounds,-1,-1);
        DrawText(Canvas.Handle,PChar(FCaption),Length(FCaption)
          ,fTextBounds,DT_CENTER or DT_VCENTER);
        OffsetRect(fTextBounds,1,1);
      end;
     Canvas.Font.Color := color ;
      //通常描画
      DrawText(Canvas.Handle,PChar(FCaption),Length(FCaption)
        ,fTextBounds,DT_CENTER or DT_VCENTER);
    end;

  end;
end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.FrameDraw(Canvas: TCanvas);
var MustDraw: Boolean;
begin
  with Canvas.Pen do begin
    Style:=psSolid;
    Width:=1;
    Mode:=pmCopy;
  end;
  case FFrameType of
    ftFlatFrame: begin //平らなボタン
      case _ButtonState of
        _sbsActiveDown,
        _sbsDown: begin
          if  (FDownFrame and (_ButtonState<>_sbsActiveDown)) or
              (FActiveFrame and (_ButtonState=_sbsActiveDown)) then begin
            with Canvas do begin
              //シャドウ描画
              Pen.Color:=FPressedColors.Shadow;
              MoveTo(0,0);
              LineTo(Width-1,0);
              MoveTo(0,0);
              LineTo(0,Height-1);
              //ハイライト描画
              Pen.Color:=FPressedColors.Highlight;
              MoveTo(Width-1,Height-1);
              LineTo(0,Height-1);
              MoveTo(Width-1,Height-1);
              LineTo(Width-1,0);
            end;
          end;
        end;
        _sbsActiveUp,
        _sbsUp,
        _sbsDisableUp: begin
          if ((FUpFrame) and (_ButtonState<>_sbsActiveUp)) or
             ((FActiveFrame) and (_ButtonState=_sbsActiveUp)) then begin
            with Canvas do begin
              //ハイライト描画
              Pen.Color:=FColors.Highlight;
              MoveTo(0,0);
              LineTo(Width-1,0);
              MoveTo(0,0);
              LineTo(0,Height-1);
              //シャドウ描画
              Pen.Color:=FColors.Shadow;
              MoveTo(Width-1,Height-1);
              LineTo(0,Height-1);
              MoveTo(Width-1,Height-1);
              LineTo(Width-1,0);
            end;
          end;
        end;
      end;
    end;
    ftNormalFrame: //ただのボタン
      case _ButtonState of
        _sbsActiveDown,
        _sbsDown: begin
          if  (FDownFrame and (_ButtonState<>_sbsActiveDown)) or
              (FActiveFrame and (_ButtonState=_sbsActiveDown)) then begin
            with Canvas do begin
              //シャドウ描画
              Pen.Color:=FPressedColors.Shadow;
              MoveTo(1,1);
              LineTo(Width-1,1);
              MoveTo(1,1);
              LineTo(1,Height-1);
              //シャドウフレーム描画
              Pen.Color:=FPressedColors.DarkShadow;
              MoveTo(0,0);
              LineTo(Width-1,0);
              MoveTo(0,0);
              LineTo(0,Height-1);
              //ハイライト描画
              Pen.Color:=FPressedColors.Highlight;
              MoveTo(Width-1,Height-1);
              LineTo(0,Height-1);
              MoveTo(Width-1,Height-1);
              LineTo(Width-1,0);
            end;
          end;
        end;
        _sbsActiveUp,
        _sbsUp,
        _sbsDisableUp: begin
          if  (FUpFrame and (_ButtonState<>_sbsActiveUp)) or
              (FActiveFrame and (_ButtonState=_sbsActiveUp)) then begin
            with Canvas do begin
              //シャドウ描画
              Pen.Color:=FColors.Shadow;
              MoveTo(Width-2,Height-2);
              LineTo(0,Height-2);
              MoveTo(Width-2,Height-2);
              LineTo(Width-2,0);
              //シャドウフレーム描画
              Pen.Color:=FColors.DarkShadow;
              MoveTo(Width-1,Height-1);
              LineTo(0,Height-1);
              MoveTo(Width-1,Height-1);
              LineTo(Width-1,0);
              //ハイライト描画
              Pen.Color:=FColors.Highlight;
              MoveTo(0,0);
              LineTo(Width-1,0);
              MoveTo(0,0);
              LineTo(0,Height-1);
            end;
          end;
        end;
    end;
    ftEnclosedFrame: begin //囲いのあるボタン
      MustDraw:=False;
      case _ButtonState of
        _sbsActiveDown,
        _sbsDown: begin
          if  (FDownFrame and (_ButtonState<>_sbsActiveDown)) or
              (FActiveFrame and (_ButtonState=_sbsActiveDown)) then begin
            with Canvas do begin
              //シャドウ描画
              Pen.Color:=FPressedColors.Shadow;
              MoveTo(1,1);
              LineTo(Width-2,1);
              MoveTo(1,1);
              LineTo(1,Height-2);
              //ハイライト描画
              Pen.Color:=FPressedColors.Highlight;
              MoveTo(Width-2,Height-2);
              LineTo(1,Height-2);
              MoveTo(Width-2,Height-2);
              LineTo(Width-2,1);
            end;
            MustDraw:=True;
          end;
        end;
        _sbsActiveUp,
        _sbsUp,
        _sbsDisableUp: begin
          if  (FUpFrame and (_ButtonState<>_sbsActiveUp)) or
              (FActiveFrame and (_ButtonState=_sbsActiveUp)) then begin
            with Canvas do begin
              //ハイライト描画
              Pen.Color:=FColors.Highlight;
              MoveTo(1,1);
              LineTo(Width-2,1);
              MoveTo(1,1);
              LineTo(1,Height-2);
              //シャドウ描画
              Pen.Color:=FColors.Shadow;
              MoveTo(Width-2,Height-2);
              LineTo(1,Height-2);
              MoveTo(Width-2,Height-2);
              LineTo(Width-2,1);
            end;
            MustDraw:=True;
          end;
        end;
      end;
      if MustDraw then begin
        with Canvas do begin
          Pen.Color:=FColors.DarkShadow;
          Rectangle(0,0,Width,Height);
        end;
      end;
    end;
  end;
end;

//---------------------------------------------------------------------------
function THSpeedExtButton.CreateStateGlyph: TBitmap;
const
  colorMask32 = $00FFFFFF ;
var
  transTrueColor: DWORD;
  transColor: TColor;
  disableTrueColor: DWORD;
  disableR,disableG,disableB: Integer;
  whiteTrueColor: DWORD;
  ActiveTrueColor: DWORD;
  ActiveR,ActiveG,ActiveB: Integer;
  BM,bmS,bmD: TBitmap;
  w,h,y,x: Integer;
  line,lineS,lineD,lineSPrev,lineDPrev,lineSNext,lineDNext: PDWORD;
  val: DWORD;
  r,g,b,m: Integer;
  sR,sG,sB: Integer;
  dR,dG,dB: Integer;
  lv2: Boolean;
  maskBool: Integer;
  function DwP(p:PDWORD;offset:Integer): PDWORD;
  begin
    //DWORD簡易オフセット変換。
    //変換が面倒いから作りました。
    //(デルファイよく知らないので、もっと良い方法があるかもしれません....)
    //最適化でインライン展開されるでしょうから、速度的には問題ないでしょう。
    Result := PDWORD(PCHAR(p)+offset*4);
  end;

begin

  if Assigned(FGlyph) and (not FGlyph.Empty) then begin

    BM:=TBitmap.Create;
    transTrueColor := PDWORD(FGlyph.ScanLine[FGlyph.Height-1])^ ;
    transTrueColor := transTrueColor and colorMask32;
    case _ButtonState of
      _sbsUp,         //デフォルトアップイメージ
      _sbsDown: begin //ダウンイメージ
        BM.Assign(FGlyph);
      end;
      _sbsActiveUp,
      _sbsActiveDown: begin //アクティブアップ/ダウンイメージ
        ActiveTrueColor:=ColorToTrueColor(FActiveColor);
        ActiveR:=(ActiveTrueColor shr 16)and 255;
        ActiveG:=(ActiveTrueColor shr 8)and 255;
        ActiveB:=(ActiveTrueColor)and 255;
        {
            BM.Width :=FGlyph.Width;
            BM.Height:=FGlyph.Height;
            BM.HandleType:=bmDIB;
            BM.PixelFormat:=pf32bit;
        }
        case FActiveImage of
          aiNormal: begin
            // no action
            BM.Assign(FGlyph);
          end;
          aiXorLight: begin
            BM.Assign(FGlyph);
            w:=BM.Width;
            h:=BM.Height;
            for y:=0 to h-1 do begin
              line := PDWORD(BM.ScanLine[y]);
              for x:=0 to w-1 do begin
                val:=line^ and colorMask32;
                if val<>transTrueColor then begin
                  r := (val shr 16)and 255;
                  g := (val shr 8)and 255;
                  b := (val)and 255;
                  r := ActiveR xor r ;
                  g := ActiveG xor g ;
                  b := ActiveB xor b ;
                  line^:=(r shl 16)or(g shl 8)or b;
                end;
                inc(line);
              end;
            end;
          end;
          aiHalfLight: begin
            BM.Assign(FGlyph);
            w := BM.Width;
            h := BM.Height;
            for y:=0 to h-1 do begin
              line := PDWORD(BM.ScanLine[y]);
              for x:=0 to w-1 do begin
                val := line^ and colorMask32 ;
                if val<>transTrueColor then begin
                  r := (val shr 16)and 255;
                  g := (val shr 8)and 255;
                  b := (val)and 255;
                  r := (ActiveR+r) div 2;
                  g := (ActiveG+g) div 2;
                  b := (ActiveB+b) div 2;
                  line^:=(r shl 16)or(g shl 8) or b;
                end;
                inc(line);
              end;
            end;
          end;
          aiQuaterLight: begin
            BM.Assign(FGlyph);
            w := BM.Width;
            h := BM.Height;
            sR := ActiveR*3 ;
            sG := ActiveG*3 ;
            sB := ActiveB*3 ;
            for y:=0 to h-1 do begin
              line:=PDWORD(BM.ScanLine[y]);
              for x:=0 to w-1 do begin
                val := line^ and colorMask32 ;
                if val<>transTrueColor then begin
                  r := (val shr 16)and 255;
                  g := (val shr 8)and 255;
                  b := (val)and 255;
                  r := (sR+r)div 4;
                  g := (sG+g)div 4;
                  b := (sB+b)div 4;
                  line^:=(r shl 16)or(g shl 8)or b;
                end;
                inc(line);
              end;
            end;
          end;
          aiAddLight: begin
            BM.Assign(FGlyph);
            w := BM.Width;
            h := BM.Height;
            for y:=0 to h-1 do begin
              line:=PDWORD(BM.ScanLine[y]);
              for x:=0 to w-1 do begin
                val:=line^ and colorMask32;
                if val<>transTrueColor then begin
                  r := (val shr 16)and 255;
                  g := (val shr 8)and 255;
                  b := (val)and 255;
                  r := r+ActiveR;  if r>=256 then r:=255;
                  g := g+ActiveG;  if g>=256 then g:=255;
                  b := b+ActiveB;  if b>=256 then b:=255;
                  line^:=(r shl 16)or(g shl 8)or b;
                end;
                inc(line);
              end;
            end;
          end;
          aiFrameLight,
          aiFrameLight2: begin
            BM.Assign(FGlyph);
            w:=BM.Width;
            h:=BM.Height;
            bmS:=FGlyph;
            bmD:=BM;
            if FActiveImage=aiFrameLight2 then lv2:=True else lv2:=False ;
            //上下左右フレームライト生成
            for y:=0 to h-1 do begin
              lineS := PDWORD(bmS.ScanLine[y]);
              lineD := PDWORD(bmD.ScanLine[y]);
              lineSPrev := NIL ; lineDPrev := NIL ;
              if y>0 then begin
                lineSPrev := PDWORD(bmS.ScanLine[y-1]) ;
                lineDPrev := PDWORD(bmD.ScanLine[y-1]) ;
              end;
              lineSNext := NIL; lineDNext := NIL;
              if y<h-1 then begin
                lineSNext := PDWORD(bmS.ScanLine[y+1]);
                lineDNext := PDWORD(bmD.ScanLine[y+1]);
              end;
              //レフトライト
              if w>=2 then for x:=0 to w-2 do begin
                if ( DwP(lineS,x+1)^ and colorMask32)<>transTrueColor then begin
                  if (DwP(lineS,x)^ and colorMask32)=transTrueColor then begin
                    DwP(lineD,x)^:=ActiveTrueColor;
                    if lv2 then begin
                      if x>=1 then begin
                        if (DwP(lineS,x-1)^and colorMask32)=transTrueColor then begin
                         DwP(lineD,x-1)^:=ActiveTrueColor;
                        end;
                      end;
                      if Assigned(lineSPrev) then begin
                        if (DwP(lineSPrev,x)^and colorMask32)=transTrueColor then begin
                          DwP(lineDPrev,x)^:=ActiveTrueColor;
                        end;
                      end;
                      if Assigned(lineSNext) then begin
                        if (DwP(lineSNext,x)^ and colorMask32)=transTrueColor then begin
                          DwP(lineDNext,x)^:=ActiveTrueColor;
                        end;
                      end;
                    end;
                  end;
                end;
              end;
              //ライトライト
              if w>=2 then for x:=1 to w-1 do begin
                if (DwP(lineS,x-1)^and colorMask32)<>transTrueColor then begin
                  if (DwP(lineS,x)^ and colorMask32)=transTrueColor then begin
                    DwP(lineD,x)^ := ActiveTrueColor ;
                    if lv2 then begin
                      if x<w-1 then begin
                        if (DwP(lineS,x+1)^and colorMask32)=transTrueColor then begin
                          DwP(lineD,x+1)^:=ActiveTrueColor;
                        end;
                      end;
                      if Assigned(lineSPrev) then begin
                        if (DwP(lineSPrev,x)^and colorMask32)=transTrueColor then begin
                          DwP(lineDPrev,x)^:=ActiveTrueColor;
                        end;
                      end;
                      if Assigned(lineSNext) then begin
                        if (DwP(lineSNext,x)^and colorMask32)=transTrueColor then begin
                          DwP(lineDNext,x)^:=ActiveTrueColor;
                        end;
                      end;
                    end;
                  end;
                end;
              end;
              //アッパーライト
              if Assigned(lineSNext) then begin
                for x:=0 to w-1 do begin
                  if (DwP(lineSNext,x)^ and colorMask32)<>transTrueColor then begin
                    if (DwP(lineS,x)^ and colorMask32)=transTrueColor then begin
                      DwP(lineD,x)^:=ActiveTrueColor;
                      if lv2 then begin
                        if Assigned(lineSPrev) then begin
                          if (DwP(lineSPrev,x)^and colorMask32)=transTrueColor then begin
                            DwP(lineDPrev,x)^:=ActiveTrueColor;
                          end;
                        end;
                        if x>=1 then begin
                          if (DwP(lineS,x-1)^and colorMask32)=transTrueColor then begin
                            DwP(lineD,x-1)^:=ActiveTrueColor;
                          end;
                        end;
                        if x<w-1 then begin
                          if (DwP(lineS,x+1)^and colorMask32)=transTrueColor then begin
                            DwP(lineD,x+1)^:=ActiveTrueColor;
                          end;
                        end;
                      end;
                    end;
                  end;
                end;
              end;
              //ローワーライト
              if Assigned(lineSPrev) then begin
                for x:=0 to w-1 do begin
                  if (DwP(lineSPrev,x)^and colorMask32)<>transTrueColor then begin
                    if (DwP(lineS,x)^and colorMask32)=transTrueColor then begin
                      DwP(lineD,x)^ :=ActiveTrueColor;
                      if lv2 then begin
                        if Assigned(lineSNext) then begin
                          if (DwP(lineSNext,x)^and colorMask32)=transTrueColor then begin
                            DwP(lineDNext,x)^ := ActiveTrueColor;
                          end;
                        end;
                        if x>=1 then begin
                          if (DwP(lineS,x-1)^ and colorMask32)=transTrueColor then begin
                            DwP(lineD,x-1)^ := ActiveTrueColor;
                          end;
                        end;
                        if x<w-1 then begin
                          if (Dwp(lineS,x+1)^ and colorMask32)=transTrueColor then begin
                            DwP(lineD,x+1)^ := ActiveTrueColor;
                          end;
                        end;
                      end;
                    end;
                  end;
                end;
              end;
            end;
          end;
          aiMaskLight: begin
            BM.Assign(FGlyph);
            w:=BM.Width;
            h:=BM.Height;
            maskBool:=0;
            for y:=0 to h-1 do begin
              line:=PDWORD(BM.ScanLine[y]);
              for x:=0 to w-1 do begin
                val:=line^and colorMask32;
                if val<>transTrueColor then begin
                  if (maskBool and 1)=1 then begin
                    line^:=ActiveTrueColor;
                  end;
                end;
                Inc(maskBool);
                Inc(line);
              end;
              if (h and 1)=0 then Inc(maskBool);
            end;
          end;
        end;
      end;
      _sbsDisableUp: begin //ディザブルイメージ
        BM.Assign(FGlyph);
        disableTrueColor:=ColorToTrueColor(FColors.Color);
        disableR:=(disableTrueColor shr 16)and 255;
        disableG:=(disableTrueColor shr 8)and 255;
        disableB:=(disableTrueColor)and 255;
        case FDisabledImage of
          diDefault: begin
            w:=BM.Width;
            h:=BM.Height;
            bmS:=FGlyph;
            bmD:=BM;
            with bmD.Canvas do begin
              Brush.Color:=clBlack;
              Brush.Style:=bsSolid;
              FillRect(ClipRect);
            end;
            whiteTrueColor := ColorToTrueColor(clWhite);
            //上下左右ホワイトフレーム生成
            for y:=0 to h-1 do begin
              lineS:=PDWORD(bmS.ScanLine[y]);
              lineD:=PDWORD(bmD.ScanLine[y]);
              lineSNext:=NIL;
              if y<h-1 then begin
                lineSNext:=PDWORD(bmS.ScanLine[y+1]);
              end;
              if Assigned(lineSNext) then begin
                //アッパーレフト
                if w>=2 then for x:=0 to w-2 do begin
                  if (DwP(lineSNext,x+1)^and colorMask32)<>(DwP(lineS,x)^and colorMask32) then begin
                      DwP(lineD,x)^ := whiteTrueColor;
                  end;
                end;
                //アッパーライト
                if w>=2 then for x:=1 to w-1 do begin
                  if (DwP(lineSNext,x-1)^ and colorMask32)<>(DwP(lineS,x)^and colorMask32) then begin
                      DwP(lineD,x-1)^ := whiteTrueColor;
                  end;
                end;
              end;
            end;
            bmD.Monochrome:=True;
          end;
          diGrayscale: begin
            w:=BM.Width;
            h:=BM.Height;
            for y:=0 to h-1 do begin
              line:=PDWORD(BM.ScanLine[y]);
              for x:=0 to w-1 do begin
                val:=line^ and colorMask32;
                if val<>transTrueColor then begin
                  r:=(val shr 16) and 255;
                  g:=(val shr 8) and 255;
                  b:=(val) and 255;
                  m:=(r+g+b) div 3;
                  line^:=(m shl 16)or(m shl 8)or m;
                end;
                Inc(line);
              end;
            end;
          end;
          diAlphaHalfTrans: begin
            w:=BM.Width;
            h:=BM.Height;
            for y:=0 to h-1 do begin
              line:=PDWORD(BM.ScanLine[y]);
              for x:=0 to w-1 do begin
                val:=line^and colorMask32;
                if val<>transTrueColor then begin
                  r := (val shr 16) and 255;
                  g := (val shr 8) and 255;
                  b := (val)and 255;
                  r := (disableR+r) div 2;
                  g := (disableG+g) div 2;
                  b := (disableB+b) div 2;
                  line^:=(r shl 16)or(g shl 8)or b;
                end;
                Inc(line);
              end;
            end;
          end;
          diAlphaQuaterTrans: begin
            w:=BM.Width;
            h:=BM.Height;
            dR:=disableR*3;
            dG:=disableG*3;
            dB:=disableB*3;
            for y:=0 to h-1 do begin
              line:=PDWORD(BM.ScanLine[y]);
              for x:=0 to w-1 do begin
                val:=line^ and colorMask32;
                if val<>transTrueColor then begin
                  r:=(val shr 16) and 255;
                  g:=(val shr 8) and 255;
                  b:=(val) and 255;
                  r:=(dR+r) div 4;
                  g:=(dG+g) div 4;
                  b:=(dB+b) div 4;
                  line^:=(r shl 16) or (g shl 8) or b;
                end;
                Inc(line);
              end;
            end;
          end;
          diMaskTrans: begin
            w:=BM.Width;
            h:=BM.Height;
            maskBool:=0;
            for y:=0 to h-1 do begin
              line:=PDWORD(BM.ScanLine[y]);
              for x:=0 to w-1 do begin
                val:=line^ and colorMask32;
                if val<>transTrueColor then begin
                  if (maskBool and 1)=1 then begin
                    line^:=transTrueColor;
                  end;
                end;
                Inc(line);
                Inc(maskBool);
              end;
              if (h and 1)=0 then Inc(maskBool);
            end;
          end;
        end;
      end;
    end;
    //透過色を設定する。
    BM.HandleType:=bmDDB;
    transColor    := BM.Canvas.Pixels
      [0,BM.Height-1];
    BM.Transparent:=True;
    BM.TransparentColor:=transColor;
    if (_ButtonState=_sbsDisableUp) and (FDisabledImage=diDefault) then begin
      BM.TransparentColor:=clBlack;
    end;
    Result := BM;
  end else begin

    Result := nil;

  end;

end;

//---------------------------------------------------------------------------
function THSpeedExtButton.GetCaption: string;
var
  strWork: string;
  
begin

  // キャプションのラップ処理
  if FbCaptionWrap = True then begin
    strWork := FCaption;
    Result := StringReplace(strWork, #13#10, ' ', [rfReplaceAll])
  end else
    Result := FCaption;


end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetCaption(value: string);
begin

  FCaption := value;

  // キャプションのラップ処理
  if FbCaptionWrap = True then
    FCaption := StringReplace(FCaption, ' ', #13#10, [rfReplaceAll])
  else
    FCaption := StringReplace(FCaption, #13#10, ' ', [rfReplaceAll])

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetCaptionWrap(value: boolean);
begin

  if FbCaptionWrap = value then
    exit;

  FbCaptionWrap := value;

  // キャプションのラップ処理
  if FbCaptionWrap = True then
    FCaption := StringReplace(FCaption, ' ', #13#10, [rfReplaceAll])
  else
    FCaption := StringReplace(FCaption, #13#10, ' ', [rfReplaceAll])

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetAccelCharDown(value: Boolean);
begin

  if FAccelCharDown <> value then begin
    FAccelCharDown := value;
    Invalidate;
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetClickDownHook(value: Boolean);
begin

  if FClickDownHook <> value then begin
    FClickDownHook := value;
    Invalidate;
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetActiveFrame(value: Boolean);
begin

  if FActiveFrame <> value then begin
    FActiveFrame := value;
    Invalidate;
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetUpFrame(Value: Boolean);
begin

  if FUpFrame <> value then begin
    FUpFrame := value;
    Invalidate;
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetDownFrame(Value: Boolean);
begin

  if FDownFrame <> value then begin
    FDownFrame := value;
    Invalidate;
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetFrameType(value: TFrameType);
begin

  if value <> FFrameType then begin
    FFrameType := value;
    Invalidate;
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetTransparent(value: Boolean);
var style: TControlStyle;
begin

  if value <> FTransparent then begin

    FTransparent := value;
    style        := ControlStyle;
    if FTransparent then begin
      style := style - [csOpaque];
    end else begin
      style := style + [csOpaque];
    end;
    ControlStyle:=style;
    Invalidate;

  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetGlyph(value: TBitmap);
begin

  with Glyph do begin
    if Assigned(value) then begin
      OnChange:=NIL;
      Assign(value);
      OnChange := GlyphOnChange;
      GlyphOnChange(FGlyph);
    end else begin
      OnChange:=NIL;
      FreeImage;
      Width:=0;
      Height:=0;
      FGlyph.OnChange := GlyphOnChange;
    end;
  end;

  Invalidate;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetColors(value: THExtBtnColor);
begin

  FColors.Assign(value);

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetPressedColors(value: THExtBtnColor);
begin

  FPressedColors.Assign(value);

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetActiveColor(value: TColor);
begin

  if value <> FActiveColor  then begin
    FActiveColor := value;
    Invalidate;
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetFont(value: TFont);
begin

  if Assigned(value) then begin
    FFont.Assign(value);
    Invalidate;
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetActiveFont(value: TFont);
begin

  if Assigned(value) then begin
    FActiveFont.Assign(value);
    Invalidate;
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetActiveImage(value: TActiveImageType);
begin

  if value <> FActiveImage then begin
    FActiveImage := value;
    Invalidate;
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetDisabledImage(value: TDisabledImageType);
begin
  if(value<>FDisabledImage)then begin
    FDisabledImage:=value;
    Invalidate;
  end;
end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetDisabledHighlight(value: TColor);
begin

  if value <> FDisabledHighlight then begin
    FDisabledHighlight := value;
    Invalidate;
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetDisabledShadow(value: TColor);
begin

  if value <> FDisabledShadow then begin
    FDisabledShadow := value;
    Invalidate;
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetDown(value: Boolean);
begin

  if value <> FDown then begin

    if FGroupIndex <> 0 then begin
      if FAllowAllUp then begin
        FDown := value;
        GroupUpdateStatus(FGroupIndex);
        if FDown then
          _ButtonState := _sbsDown
        else
          _ButtonState := _sbsUp;
        Repaint;
      end else begin
        if not FDown then begin
          FDown := value;
          GroupUpdateStatus(FGroupIndex);
          if FDown then
            _ButtonState := _sbsDown;
          Repaint;
        end;
      end;
    end;

  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetAllowAllUp(value: Boolean);
begin

  if value <> FAllowAllUp then begin
    FAllowAllUp:=value;
    GroupUpdateStatus(FGroupIndex);
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetGroupIndex(value: Integer);
begin

  if value <> FGroupIndex then begin
    GroupUpdateStatus(value);
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetLayout(value: TButtonLayout);
begin
  if value <> FLayout then begin
    FLayout:=value;
    Invalidate;
  end;
end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetMargin(value :Integer);
begin

  if value <> FMargin then begin
    FMargin := value;
    Invalidate;
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetSpacing(value :Integer);
begin

  if value <> FSpacing then begin
    FSpacing := value;
    Invalidate;
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetFontHighlight(value: TColor);
begin

  FFontHighlight := value ;
  Invalidate();

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.SetFontShadow(value: TColor);
begin

  FFontShadow := value ;
  Invalidate();

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.GroupUpdateStatus(grpIndex: Integer);
var Msg:TMessage;
begin

  FGroupIndex:=grpIndex;

  if (FGroupIndex <> 0) and (Assigned(Parent)) then begin
    //仮のスピードボタンを作り、CM_BUTTONPRESSEDへのフェイクを促す
    // CM_BUTTONPRESSED は、TSpeedButton 専用のメッセージ（FDownプロパティー
    // を読み出す手続きを独自にメッセージハンドラ内に記述してしまっている）
    // なので、このような形を取る以外は、対処のしようがない。
    FAccelSB := TSpeedButton.Create(Self);
    Parent.InsertControl(FAccelSB);
    FAccelSB.GroupIndex:=FGroupIndex;
    FAccelSB.AllowAllUp:=FAllowAllUp;
    FAccelSB.Down:=FDown;
    Msg.Msg := CM_BUTTONPRESSED;
    Msg.WParam := FGroupIndex;
    Msg.LParam := DWORD(FAccelSB);
    Msg.Result := 0;
    Parent.Broadcast(Msg);
    Parent.RemoveControl(FAccelSB);
    FAccelSB.Destroy;
    FAccelSB:=NIL;
  end;
end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.CalcDrawPosition(Canvas: TCanvas; var iPos:TPoint; var fTextBounds:TRect);
var
  wholeW, wholeH: Integer;
  dIX, dIY:       Integer;
  dFX, dFY:       Integer;
  glyphEmpty:     Boolean;
  glyphW, glyphH: Integer;
  textW, textH:   Integer;
  textBounds:     TRect;
  sx, sy:         Integer;
  function max(a,b:Integer):Integer;
  begin
    if(a>b)then Result:=a else Result:=b;
  end;

begin

  wholeW:=0;
  wholeH:=0;
  dIX :=0; dIY :=0;
  dFX :=0; dFY :=0;

  glyphEmpty := FGlyph.Empty;
  glyphW     := FGlyph.Width;
  glyphH     := FGlyph.Height;

  textBounds := Rect(0,0,ClientRect.Right-ClientRect.Left,0);
  DrawText(Canvas.Handle,PCHAR(FCaption),-1
                ,textBounds,DT_CALCRECT);

  textW := textBounds.right-textBounds.left;
  textH := textBounds.bottom-textBounds.top;

  case FLayout of
    blGlyphLeft: begin
      dIX:=wholeW;
      if Assigned(FGlyph) then begin
        wholeW := wholeW +glyphW;
        wholeH := max(glyphH,wholeH);
      end;
      if (not glyphEmpty) and (FCaption<>'') then begin
        wholeW:=wholeW+FSpacing;
      end;
      dFX:=wholeW;
      if(FCaption<>'')then begin
        wholeW :=wholeW+textW;
        wholeH :=max(textH,wholeH);
      end;
      if( not glyphEmpty)then begin
        dIY:=(wholeH-glyphH) div 2;
      end;
      if(FCaption<>'')then begin
        dFY:=(wholeH-textH) div 2;
      end;
    end;
    blGlyphRight: begin
      dFX:=wholeW;
      if(FCaption<>'')then begin
        wholeW :=wholeW+textW;
        wholeH :=max(textH,wholeH);
      end;
      if( not glyphEmpty) and (FCaption<>'') then begin
        wholeW := wholeW+FSpacing;
      end;
      dIX:=wholeW;
      if( not glyphEmpty)then begin
        wholeW :=wholeW+glyphW;
        wholeH :=max(glyphH,wholeH);
      end;
      if( not glyphEmpty)then begin
        dIY:=(wholeH-glyphH) div 2;
      end;
      if(FCaption<>'')then begin
        dFY:=(wholeH-textH) div 2;
      end;
    end;
    blGlyphTop: begin
      dIY:=wholeH;
      if( not glyphEmpty)then begin
        wholeH :=wholeH+glyphH;
        wholeW :=max(glyphW,wholeW);
      end;
      if Assigned(FGlyph) and  (FCaption<>'') then begin
        wholeH := wholeH+FSpacing;
      end;
      dFY:=wholeH;
      if(FCaption<>'')then begin
        wholeH := wholeH + textH;
        wholeW:=max(textW,wholeW);
      end;
      if( not glyphEmpty)then begin
        dIX:=(wholeW-glyphW) div 2;
      end;
      if(FCaption<>'')then begin
        dFX:=(wholeW-textW) div 2;
      end;
    end;
    blGlyphBottom: begin
      dFY:=wholeH;
      if(FCaption <> '')then begin
        wholeH := wholeH + textH;
        wholeW := max(textW,wholeW);
      end;
      if( not glyphEmpty) and (FCaption <> '')then begin
        wholeH := wholeH + FSpacing;
      end;
      dIY:=wholeH;
      if Assigned(FGlyph) then begin
        wholeH := wholeH + glyphH;
        wholeW := max(glyphW,wholeW);
      end;
      if( not glyphEmpty) then begin
        dIX := (wholeW-glyphW) div 2;
      end;
      if(FCaption <> '')then begin
        dFX := (wholeW-textW) div 2;
      end;
    end;
  end;

  sx:=0; sy:=0;

  if(FMargin<0)then begin
    sx := (ClientWidth-wholeW) div 2;
    sy := (ClientHeight-wholeH) div 2;
  end else begin
    case (FLayout) of
      blGlyphLeft: begin
        sx := FMargin;
        sy := (ClientHeight-wholeH) div 2;
      end;
      blGlyphRight: begin
        sx := (ClientWidth-wholeW)-FMargin;
        sy := (ClientHeight-wholeH) div 2;
      end;
      blGlyphTop: begin
        sx := (ClientWidth-wholeW) div 2;
        sy := FMargin;
      end;
      blGlyphBottom: begin
        sx := (ClientWidth-wholeW) div 2;
        sy := (ClientHeight-wholeH)-FMargin;
      end;
    end;
  end;

  iPos.x := dIX+sx;
  iPos.y := dIY+sy;

  OffsetRect(textBounds, dFX + sx, dFY + sy);

  fTextBounds := textBounds;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.GlyphOnChange(Sender: TObject);
begin

  FGlyph.HandleType  := bmDIB;
  FGlyph.PixelFormat := pf32bit;
  Invalidate;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.FontsAndColorsOnChange(Sender: TObject);
begin

  Invalidate;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.UpdateTracking;
var
  P:TPoint;

begin

  if(Enabled)then begin

    GetCursorPos(P);

    FMouseInControl :=  not (FindDragTarget(P,true)=Self);

    if(FMouseInControl) then
      Perform(CM_MOUSELEAVE,0,0)
    else
      Perform(CM_MOUSEENTER,0,0);

  end;
  
end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.PressedButton(Sender: TObject; ShiftState: TShiftState; X,Y: Integer );
begin

  MouseDown(mbLeft, ShiftState, X, Y);

  FActiveButtonTimer.Enabled := True ; //リーブ自動化タイマー起動

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.UppedButton(Sender: TObject; ShiftState: TShiftState; X,Y: Integer );
begin

  MouseUp(mbLeft, ShiftState, X, Y);

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.MouseDown(Button: TMouseButton ; ShiftState: TShiftState ; X,Y: Integer );
begin

  Inherited MouseDown(Button,ShiftState,X,Y);

  if (Button=mbLeft) and (Enabled) then begin

    if ( not FDown) then begin
      _ButtonState := _sbsActiveDown;
      Invalidate;
    end else begin
      _ButtonState := _sbsActiveDown;
    end;

    FDragging:=true;

  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.MouseMove(ShiftState: TShiftState ; X,Y: integer);
var NewState: T_ActiveButtonState;
begin

  inherited MouseMove(ShiftState,X,Y);

  if(FDragging)then begin

    if ( not FDown) then
      NewState:=_sbsUp
    else
      NewState:=_sbsDown;

    if (X>0)and(X<ClientWidth)and(Y>0)and(Y<ClientHeight) then begin
      NewState:=_sbsActiveDown;
    end;
    if(NewState<>_ButtonState)then begin
      _ButtonState:=NewState;
      Invalidate;
    end;

  end else if( not FMouseInControl)then begin

    UpdateTracking;

  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.MouseUp(
  Button: TMouseButton ; Shift: TShiftState ; X,Y: Integer );
var
  DoClick: Boolean;
begin
  inherited MouseUp(Button,Shift,X,Y);
  if(FDragging)then begin
    DoClick := (X>=0)and(X<ClientWidth)and(Y>=0)and(Y<ClientHeight);
    if(FGroupIndex=0)then begin
      _ButtonState:=_sbsUp;
      FMouseInControl:=false;
      FDown:=false;
      if (DoClick)and  not ((_ButtonState=_sbsDown)or(_ButtonState=_sbsActiveDown)) then begin
        Repaint;
      end;
    end else if(DoClick)then begin
      SetDown( not FDown);
      if(FDown)then Repaint;
    end else begin
      if(FDown)then _ButtonState:=_sbsActiveDown
      else  _ButtonState:=_sbsActiveUp;
      Repaint;
    end;
    FDragging:=false;
    if(DoClick)then Click;
    UpdateTracking;
  end;
end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.MouseEnter(ShiftState: TShiftState ; X,Y: integer );
begin

  if Assigned(FOnMouseEnter) then FOnMouseEnter(Self,ShiftState,X,Y);

  if (not FMouseInControl) and  Enabled and  (DragMode<>dmAutomatic) and (GetCapture=0) then begin

    FMouseInControl := true;

    if (_ButtonState=_sbsUp) then begin
      _ButtonState := _sbsActiveUp;
    end;

    if (_ButtonState=_sbsDown) then begin
      _ButtonState := _sbsActiveDown;
    end;

    Repaint;

    FActiveButtonTimer.Enabled := True ; //リーブ自動化タイマー起動

  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.MouseLeave(ShiftState: TShiftState ; X,Y: integer );
begin

  if Assigned(FOnMouseLeave) then FOnMouseLeave(Self,ShiftState,X,Y);

  if (FMouseInControl) and Enabled and (not FDragging) then begin

    FActiveButtonTimer.Enabled := False;  //リーブ自動化タイマー切断
    FMouseInControl := false;

    if(_ButtonState=_sbsActiveUp)then begin
      _ButtonState := _sbsUp;
    end;

    if(_ButtonState=_sbsActiveDown)then begin
      _ButtonState := _sbsDown;
    end;

    Repaint;

  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.ActiveButtonTimerOnTimer(Sender: TObject);
var
   ScreenPos,ClientPos:TPoint;
   Shift:TShiftState;

begin

  if FMouseInControl and Enabled and (not FDragging) then begin

    GetCursorPos(ScreenPos);
    ClientPos:=ScreenToClient(ScreenPos);
    if not ( (ClientRect.Left<=ClientPos.x) and (ClientRect.Right >ClientPos.x) and
             (ClientRect.Top <=ClientPos.y) and (ClientRect.Bottom>ClientPos.y) ) then begin
      Shift:=GetShiftState;
      MouseLeave(Shift,ClientPos.x,ClientPos.y);
    end;

  end else begin

    FActiveButtonTimer.Enabled := False ;

  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.Click;
var
  state: T_ActiveButtonState;

begin

  state := _sbsUp;

  if FClickDownHook then begin
    state:=_ButtonState;
    _ButtonState:=_sbsActiveDown;
    Repaint;
  end;

  Inherited Click;

  if FClickDownHook then begin
    _ButtonState:=state;
    Repaint;
  end;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.WMLButtonDblClick(var Message:TWMLButtonDown);
begin

  inherited;

  if (FDown) then DblClick;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.CMEnabledChanged(var Message:TMessage);
begin

  FDown := false;

  if (Enabled) then begin
    _ButtonState:=_sbsUp;
  end else begin
    _ButtonState:=_sbsDisableUp;
  end;

  UpdateTracking;

  Invalidate;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.CMDialogChar(var Message:TCMDialogChar);
begin

  with Message do

    if IsAccel(CharCode,FCaption) and Enabled and Visible
       and(Parent<>NIL) and Parent.Showing then begin

      if FAccelCharDown then begin
        SetDown( not FDown);
      end;

      Click;

      Result:=1;

    end else begin

      Inherited;

  end;
  
end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.CMFontChanged(var Message: TMessage);
begin

  Invalidate;
  
end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.CMTextChanged(var Message: TMessage);
begin

  Invalidate;
  
end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.CMSysColorChange(var Message: TMessage);
begin

  Invalidate;

end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.CMMouseEnter(var Message: TMessage);
var ScreenPos,ClientPos:TPoint;
    Shift:TShiftState;
begin

  GetCursorPos(ScreenPos);
  ClientPos :=ScreenToClient(ScreenPos);
  Shift     :=GetShiftState;
  MouseEnter(Shift,ClientPos.X,ClientPos.Y);
  
end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.CMMouseLeave(var Message: TMessage);
var ScreenPos,ClientPos:TPoint;
    Shift:TShiftState;
begin

  GetCursorPos(ScreenPos);
  ClientPos := ScreenToClient(ScreenPos);
  Shift     := GetShiftState;
  MouseLeave(Shift,ClientPos.X,ClientPos.Y);
  
end;

//---------------------------------------------------------------------------
procedure THSpeedExtButton.CMButtonPressed(var Message: TMessage);
var Sender: TSpeedButton;
begin

  if(Message.WParam=FGroupIndex)then begin

    Sender := TSpeedButton(Message.LParam);
    if Assigned(Sender)and(Sender<>FAccelSB)then begin
      if(Sender.Down)and(FDown)then begin
        FDown        := false;
        _ButtonState := _sbsUp;
        Invalidate;
      end;
      FAllowAllUp := Sender.AllowAllUp;
    end;

  end;

end;

// 20002.11.13 追加
procedure THSpeedExtButton.SetReleaseTime(value: cardinal);
begin

  if value <> FReleaseTime then begin

    FReleaseTime := value;
    if FActiveButtonTimer <> nil then begin
      FActiveButtonTimer.Interval := FReleaseTime;
    end;

  end;

end;

end.

