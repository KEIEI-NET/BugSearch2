{
******************************************************************************
    HSS ∫›Œﬂ∞»›ƒ◊≤Ãﬁ◊ÿ  ¢HSS£

        ≤“∞ºﬁï`âÊ∫›Œﬂ∞»›ƒ

        ’∆Øƒñº  :   HImage.PAS
        çÏê¨é“  :   Kubochi
        çÏê¨ì˙  :   1999/7

                    THGradationImage  : ∏ﬁ◊√ﬁ∞ºÆ› îwåiÇíÒãü
                    THRepeatImage     : BitMapï°êªîwåiÇíÒãü

******************************************************************************
}

unit Himage;

{$DEFINE UPDATE}
{$DEFINE HREG}


{
******************************************************************************
    interfaceïî
******************************************************************************
}
interface


    { ’∆ØƒéwíË }
    uses
      Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms,HVersion;


    { å^êÈåæ }
    type

        { ÉOÉâÉfÅ[ÉVÉáÉìï˚å¸ }
        THGradationType = ( gtVertical  ,                 { ècï˚å¸         }
                            gtHorizontal );               { â°ï˚å¸         }

        {
        -----------------------------------------------------------------------
            HGradationImageµÃﬁºﬁ™∏ƒíËã`
        -----------------------------------------------------------------------
        }
        THGradationImage = class(TGraphicControl)
          private
            { Private êÈåæ }
            FVersion      : TVersion;                     {  ﬁ∞ºﬁÆ›        }
            FBuffer       : TBitmap ;
            FGradationType: THGradationType;              { ∏ﬁ◊√ﬁ∞ºÆ›ï˚å¸  }
            FOnPaint      : TNotifyEvent;
            FAutoStepWidth: Boolean;
            FRef          : Boolean;
            FStartColor   : TColor ;                      { ∏ﬁ◊√ﬁ∞ºÆ›StartêF }
            FEndColor     : TColor ;                      { ∏ﬁ◊√ﬁ∞ºÆ›ENDêF }
            FStep         : Byte   ;
            FStepWidth    : Integer;
            procedure SetAutoStepWidth(Value: Boolean);
            procedure SetEndColor(Value: TColor);
            procedure SetGradationType(Value: THGradationType);
            procedure SetStartColor(Value: TColor);
            procedure SetStep(Value: Byte);
            procedure SetStepWidth(Value: Integer);

          public
            { public êÈåæ }
            constructor Create(AOwner: TComponent); override;
            destructor Destroy; override;
            procedure Paint; override;

            property Canvas;

          published
            { Published êÈåæ }
            property Version   : TVersion read FVersion write FVersion stored False;
            property AutoStepWidth: Boolean read FAutoStepWidth write SetAutoStepWidth default True;
            property Align;
            property DragCursor;
            property DragMode;
            property EndColor: TColor read FEndColor write SetEndColor default clBlack;
            property GradationType: THGradationType read FGradationType
                       write SetGradationType default gtVertical;
            property Hint;
            property ParentColor;
            property ParentFont;
            property ParentShowHint;
            property PopupMenu;
            property ShowHint;
            property StartColor: TColor read FStartColor write SetStartColor default clBlue;
            property Step: Byte read FStep write SetStep default 255;
            property StepWidth: Integer read FStepWidth write SetStepWidth default 4;
            property Visible;
            property Anchors;
            property Constraints;
            property DragKind;

            property OnClick;
            property OnDblClick;
            property OnDragDrop;
            property OnDragOver;
            property OnEndDrag;
            property OnMouseDown;
            property OnMouseMove;
            property OnMouseUp;
            property OnPaint: TNotifyEvent read FOnPaint write FOnPaint;
            property OnStartDrag;
            property OnEndDock;
            property OnStartDock;

          end;


        {
        -----------------------------------------------------------------------
            THRepeatImageµÃﬁºﬁ™∏ƒíËã`
        -----------------------------------------------------------------------
        }
        THRepeatImage = class(TGraphicControl)
          private
            { Private êÈåæ }
            FVersion    : TVersion;                       {  ﬁ∞ºﬁÆ›        }
            FOnPaint    : TNotifyEvent;
            FPicture    : TPicture;
            procedure SetPicture(const Value: TPicture);


          public
            { public êÈåæ }
            constructor Create(AOwner: TComponent); override;
            destructor Destroy; override;
            procedure Paint; override;

            property Canvas;

            
          published
            { Published êÈåæ }
            property Version   : TVersion read FVersion write FVersion stored False;
            property Align;
            property DragCursor;
            property DragMode;
            property Hint;
            property ParentColor;
            property ParentFont;
            property ParentShowHint;
            property Picture: TPicture read FPicture write SetPicture;
            property PopupMenu;
            property ShowHint;
            property Visible;
            property Anchors;
            property Constraints;
            property DragKind;

            property OnClick;
            property OnDblClick;
            property OnDragDrop;
            property OnDragOver;
            property OnEndDrag;
            property OnMouseDown;
            property OnMouseMove;
            property OnMouseUp;
            property OnPaint: TNotifyEvent read FOnPaint write FOnPaint;
            property OnStartDrag;

            property OnEndDock;
            property OnStartDock;
          end;

    { Ãﬂ€º∞ºﬁ¨ÅAä÷êîêÈåæ }
        function GetBFromColor(const Color: TColor): Byte;
        function GetGFromColor(const Color: TColor): Byte;
        function GetRFromColor(const Color: TColor): Byte;
        procedure GradationRect(Canvas: TCanvas; GType: THGradationType;
            Size: TRect; Step: Byte; StartColor, EndColor: TColor);


    {$IFNDEF HREG}
        procedure Register;
    {$ENDIF}

{
******************************************************************************
    implementationïî
******************************************************************************
}
implementation

// ã§í ä÷êîåQ

    {
    ---------------------------------------------------------------------------
      GetBFromColor
    ---------------------------------------------------------------------------
    }
    function GetBFromColor(const Color: TColor): Byte;
    begin
      Result := GetBValue(ColorToRGB(Color));
    end;

    {
    ---------------------------------------------------------------------------
      GetGFromColor
    ---------------------------------------------------------------------------
    }
    function GetGFromColor(const Color: TColor): Byte;
    begin
      Result := GetGValue(ColorToRGB(Color));
    end;

    {
    ---------------------------------------------------------------------------
      GetRFromColor
    ---------------------------------------------------------------------------
    }
    function GetRFromColor(const Color: TColor): Byte;
    begin
      Result := GetRValue(ColorToRGB(Color));
    end;

    {
    ---------------------------------------------------------------------------
      GradationRect
    ---------------------------------------------------------------------------
    }
    procedure GradationRect(Canvas: TCanvas; GType: THGradationType;
                Size: TRect; Step: Byte; StartColor, EndColor: TColor);
    var
      PRect: TRect;
      SRCol, SGCol, SBCol, ERCol, EGCol, EBCol, PRCol, PGCol, PBCol: BYTE;
      Temp, GT, I: Integer;
    begin
      if StartColor <> EndColor then begin

          SRCol := GetRFromColor(StartColor);
          SGCol := GetGFromColor(StartColor);
          SBCol := GetBFromColor(StartColor);
          ERCol := GetRFromColor(EndColor);
          EGCol := GetGFromColor(EndColor);
          EBCol := GetBFromColor(EndColor);

          Temp := 0;
          GT := 0;
          case (GType) of
          gtVertical:
            begin
              Temp := Round((Size.Bottom - Size.Top) div Step);
              GT := Size.Top;
            end;
          gtHorizontal:
            begin
              Temp := Round((Size.Right - Size.Left) div Step);
              GT := Size.Left;
            end;
          end;
          if Temp = 0 then Temp := 1;

          for I := 1 to (Step - 1) do begin
            PRCol := Round(SRCol + (((ERCol - SRCol) * I) div Step));
            PGCol := Round(SGCol + (((EGCol - SGCol) * I) div Step));
            PBCol := Round(SBCol + (((EBCol - SBCol) * I) div Step));
            Canvas.Brush.Color := RGB(PRCol, PGCol, PBCol);
            case (GType) of
            gtVertical   : PRect := Rect(Size.Left, GT, Size.Right, GT + Temp);
            gtHorizontal : PRect := Rect(GT, Size.Top, GT + temp, Size.Bottom);
            end;
            Canvas.FillRect(PRect);
            GT := GT + Temp;
          end;


          Canvas.Brush.Color := EndColor;
          case (GType) of
          gtVertical   : PRect := Rect(Size.Left, GT, Size.Right, Size.Bottom);
          gtHorizontal : PRect := Rect(GT, Size.Top, Size.Right, Size.Bottom);
          end;
          Canvas.FillRect(PRect);
      end else begin
        Canvas.Brush.Color := StartColor;
        Canvas.FillRect(Size);
      end;
    end;






// THGradationImageÉRÉìÉ|Å[ÉlÉìÉgèàóùåQ

    {
    ---------------------------------------------------------------------------
      THGradationImage  ∫›Ωƒ◊∏¿
    ---------------------------------------------------------------------------
    }
    constructor THGradationImage.Create(AOwner: TComponent);
    begin
      { îhê∂å≥åƒÇ—èoÇµ }
      inherited Create(AOwner);
      
      FVersion           := HGradationImageVersion;
      FBuffer            := TBitmap.Create;
      FBuffer.HandleType := bmDDB;
      FRef               := True;
      FGradationType     := gtVertical;
      FEndColor          := clBlack;
      Height             := 105;
      FStartColor        := clBlue;
      FStep              := 255;
      FStepWidth         := 4;
      AutoStepWidth      := True;
      Width              := 105;
    end;

    {
    ---------------------------------------------------------------------------
      THGradationImage  √ﬁΩƒ◊∏¿
    ---------------------------------------------------------------------------
    }
    destructor THGradationImage.Destroy;
    begin
      if Assigned(FBuffer) then FBuffer.Free;

      { îhê∂å≥åƒÇ—èoÇµ }
      inherited Destroy;
    end;


    {
    ---------------------------------------------------------------------------
      THGradationImage  SetAutoStepWidth
    ---------------------------------------------------------------------------
    }
    procedure THGradationImage.SetAutoStepWidth(Value: Boolean);
    begin
      if FAutoStepWidth <> Value then begin
        FAutoStepWidth := Value;
        if not FRef then begin
          FRef := True;
          Invalidate;
        end;
      end;
    end;

    {
    ---------------------------------------------------------------------------
      THGradationImage  SetEndColor
    ---------------------------------------------------------------------------
    }
    procedure THGradationImage.SetEndColor(Value: TColor);
    begin
      if FEndColor <> Value then begin
        FEndColor := Value;
        if not FRef then begin
          FRef := True;
          Invalidate;
        end;
      end;
    end;

    {
    ---------------------------------------------------------------------------
      THGradationImage  SetGradationType
    ---------------------------------------------------------------------------
    }
    procedure THGradationImage.SetGradationType(Value: THGradationType);
    begin
      if FGradationType <> Value then begin
        FGradationType := Value;
        if not FRef then begin
          FRef := True;
          Invalidate;
        end;
      end;
    end;

    {
    ---------------------------------------------------------------------------
      THGradationImage  SetGradationType
    ---------------------------------------------------------------------------
    }
    procedure THGradationImage.SetStartColor(Value: TColor);
    begin
      if FStartColor <> Value then begin
        FStartColor := Value;
        if not FRef then begin
          FRef := True;
          Invalidate;
        end;
      end;
    end;


    {
    ---------------------------------------------------------------------------
      THGradationImage  SetStep
    ---------------------------------------------------------------------------
    }
    procedure THGradationImage.SetStep(Value: Byte);
    begin
      if (FStep <> Value) and (Value > 1) then begin
        FStep := Value;
        if not FRef then begin
          FRef := True;
          Invalidate;
        end;
      end;
    end;

    {
    ---------------------------------------------------------------------------
      THGradationImage  SetStepWidth
    ---------------------------------------------------------------------------
    }
    procedure THGradationImage.SetStepWidth(Value: Integer);
    begin
      if (FStepWidth <> Value) and (Value > 0) then begin
        FStepWidth := Value;
        if not FRef then begin
          FRef := True;
          Invalidate;
        end;
      end;
    end;


    {
    ---------------------------------------------------------------------------
      THGradationImage  SetStepWidth
    ---------------------------------------------------------------------------
    }
    procedure THGradationImage.Paint;
    var
      Temp: Integer;
      SRCol, SGCol, SBCol, ERCol, EGCol, EBCol, PRCol, PGCol, PBCol, I: BYTE;
    begin

      if FAutoStepWidth then begin
        Temp := 1;
        case (FGradationType) of
        gtVertical:   Temp := Height div FStep;
        gtHorizontal: Temp := Width div FStep;
        end;
        if FStepWidth <> Temp then StepWidth := Temp;
      end;



      if FRef then begin

        case (FGradationType) of
        gtVertical:
          begin
            FBuffer.Width := Width;
            FBuffer.Height := FStep * FStepWidth;
          end;
        gtHorizontal:
          begin
            FBuffer.Width := FStep * FStepWidth;
            FBuffer.Height := Height;
          end;
        end;

        if FStartColor <> FEndColor then begin

          SRCol := GetRValue(ColorToRGB(FStartColor));
          SGCol := GetGValue(ColorToRGB(FStartColor));
          SBCol := GetBValue(ColorToRGB(FStartColor));
          ERCol := GetRValue(ColorToRGB(FEndColor));
          EGCol := GetGValue(ColorToRGB(FEndColor));
          EBCol := GetBValue(ColorToRGB(FEndColor));
          FBuffer.Canvas.Brush.Color := FStartColor;

          case (FGradationType) of
          gtVertical:   FBuffer.Canvas.FillRect(Rect(0, 0, FBuffer.Width, FStepWidth));
          gtHorizontal: FBuffer.Canvas.FillRect(Rect(0, 0, FStepWidth,    FBuffer.Height));
          end;

          for I := 1 to (FStep - 1) do begin
            PRCol := SRCol + (((ERCol - SRCol) * I) div FStep);
            PGCol := SGCol + (((EGCol - SGCol) * I) div FStep);
            PBCol := SBCol + (((EBCol - SBCol) * I) div FStep);
            FBuffer.Canvas.Brush.Color := RGB(PRCol, PGCol, PBCol);
            case (FGradationType) of
            gtVertical:   FBuffer.Canvas.FillRect(Rect(0, I * FStepWidth, FBuffer.Width,        (I + 1) * FStepWidth));
            gtHorizontal: FBuffer.Canvas.FillRect(Rect(I * FStepWidth, 0, (I + 1) * FStepWidth, FBuffer.Height));
            end;
          end;

          FBuffer.Canvas.Brush.Color := FStartColor;

          case (FGradationType) of
          gtVertical:   FBuffer.Canvas.FillRect(Rect(FBuffer.Width - FStepWidth, 0,  FBuffer.Width, FStepWidth));
          gtHorizontal: FBuffer.Canvas.FillRect(Rect(0, FBuffer.Height - FStepWidth, FStepWidth,    FBuffer.Height));
          end;

        end else begin

          FBuffer.Canvas.Brush.Color := FStartColor;
          FBuffer.Canvas.FillRect(Rect(0, 0, FBuffer.Width, FBuffer.Height));

        end;
        FRef := False;
      end;

      Canvas.StretchDraw(Rect(0, 0, Width, Height), FBuffer);
      if Assigned(FOnPaint) then FOnPaint(Self);

    end;





// THRepeatImageÉRÉìÉ|Å[ÉlÉìÉgèàóùåQ

    {
    ---------------------------------------------------------------------------
      THRepeatImage  ∫›Ωƒ◊∏¿
    ---------------------------------------------------------------------------
    }
    constructor THRepeatImage.Create(AOwner: TComponent);
    begin
      { îhê∂å≥åƒÇ—èoÇµ }
      inherited Create(AOwner);
      
      FVersion           := HRepeatImageVersion;
      FPicture           := TPicture.Create;
      Width              := 105;
      Height             := 105;
    end;

    {
    ---------------------------------------------------------------------------
      THRepeatImage  √ﬁΩƒ◊∏¿
    ---------------------------------------------------------------------------
    }
    destructor THRepeatImage.Destroy;
    begin
      FPicture.Free;

      { îhê∂å≥åƒÇ—èoÇµ }
      inherited Destroy;
    end;

    {
    ---------------------------------------------------------------------------
      THRepeatImage  SetPicture
    ---------------------------------------------------------------------------
    }
    procedure THRepeatImage.SetPicture(const Value: TPicture);
    begin
      FPicture.Assign(Value);
      Invalidate;
    end;

    {
    ---------------------------------------------------------------------------
      THRepeatImage  Paint;
    ---------------------------------------------------------------------------
    }
    procedure THRepeatImage.Paint;
    var W, H, MW, MH: Integer;
    begin
      { îhê∂å≥åƒÇ—èoÇµ }
      inherited Paint;

      if Assigned(FPicture.Graphic) then begin
        MW := (Width div FPicture.Width) + 1;
        MH := (Height div FPicture.Height) + 1;
        for W := 0 to MW do for H := 0 to MH do
          Canvas.Draw(FPicture.Width * W, FPicture.Height * H, FPicture.Graphic);
      end;

      if Assigned(FOnPaint) then FOnPaint(Self);
    end;

{$IFNDEF HREG}
    {
    ***************************************************************************
        ∫›Œﬂ∞»›ƒÇÃìoò^
    ***************************************************************************
    }
    procedure Register;
    begin
      RegisterComponents('HSS', [THGradationImage]);
      RegisterComponents('HSS', [THRepeatImage]);
    end;
{$ENDIF}

end.
