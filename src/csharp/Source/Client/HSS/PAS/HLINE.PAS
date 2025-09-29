{
******************************************************************************
    HSS ∫›Œﬂ∞»›ƒ◊≤Ãﬁ◊ÿ  ¢HSS£

        íºê¸ï`âÊ∫›Œﬂ∞»›ƒ

        ’∆Øƒñº  :   HLINE.PAS
        çÏê¨é“  :   Kubochi
        çÏê¨ì˙  :   1999/7
******************************************************************************
}
unit HLine;

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
        SysUtils,  WinProcs,  Classes, Graphics, Controls,
//      DsgnIntf, HVersion;  HSS70
        HVersion;

    { å^êÈåæ }
    type
        HexWord = Word;

        { ◊≤›¿≤Ãﬂ }
        TLineType = (
            ltHorizontal,                           { êÖïΩ      }
            ltVertical,                             { âîíº      }
            ltDiagonal,                             { âEè„Ç™ÇË  }
            ltBackDiagonal                          { âEâ∫Ç™ÇË  }
        );

        { ◊≤›Ω¿≤Ÿ }
        TLineStyle = (
            lsSolid,                                { é¿ê¸      }
            lsDot,                                  { ƒﬁØƒ      }
            lsCsDot,                                { ñßÇ»ƒﬁØƒ  }
            lsDash,                                 { îjê¸      }
            lsCsDash,                               { ñßÇ»îjê¸  }
            lsPattern                               {  ﬂ¿∞›éwíË }
        );

        {
        -----------------------------------------------------------------------
            16êiílÃﬂ€ ﬂ√®¥√ﬁ®¿
        -----------------------------------------------------------------------
        }
//        THexWordProperty = class(TIntegerProperty)  HSS70
//        public
//            function    GetValue:String; override;
//        end;

        {
        -----------------------------------------------------------------------
            THLineµÃﬁºﬁ™∏ƒíËã`
        -----------------------------------------------------------------------
        }
        THLine = class(TGraphicControl)             { TGraphicControlÇ©ÇÁîhê∂ }
        private
            FVersion: TVersion;
            FLineType:TLineType;                    { ◊≤›¿≤Ãﬂ     }
            FThick:Integer;                         { ëæÇ≥        }
            FLineStyle:TLineStyle;                  { ◊≤›Ω¿≤Ÿ     }
            FPattern:HexWord;                       { ◊≤› ﬂ¿∞›    }
            FOpaque:Boolean;                        { îwåiÇ†ÇË    }
            FFgColor:TColor;                        { ï`âÊêF      }
            FBgColor:TColor;                        { îwåiï`âÊêF  }

        private
            procedure   SetLineType(Value:TLineType);
            procedure   SetThick(Value:Integer);
            procedure   SetLineStyle(Value:TLineStyle);
            procedure   SetPattern(Value:HexWord);
            procedure   SetOpaque(Value:Boolean);
            procedure   SetFgColor(Value:TColor);
            procedure   SetBgColor(Value:TColor);

        protected
            procedure   Paint; override;
            procedure   DrawLine(Canvas:TCanvas; Pt1:TPoint; Pt2:TPoint);

        public
            constructor Create(AOwner:TComponent); override;

        published
            property    Version: TVersion read FVersion write FVersion stored False;
            property    LineType:TLineType read FLineType write SetLineType;
            property    Thick:Integer read FThick write SetThick;
            property    LineStyle:TLineStyle read FLineStyle write SetLineStyle;
            property    Pattern:HexWord read FPattern write SetPattern;
            property    Opaque:Boolean read FOpaque write SetOpaque;
            property    FgColor:TColor read FFgColor write SetFgColor;
            property    BgColor:TColor read FBgColor write SetBgColor;
        end;

    { Ãﬂ€º∞ºﬁ¨ÅAä÷êîêÈåæ }
{$IFNDEF HREG}
    procedure   Register;
{$ENDIF}

{
******************************************************************************
    implementationïî
******************************************************************************
}
implementation

    uses
        HLib;

    {
    ---------------------------------------------------------------------------
        16êiílÃﬂ€ ﬂ√®¥√ﬁ®¿  µÃﬁºﬁ™∏ƒ≤›ΩÕﬂ∏¿Ç÷ÇÃï\é¶ï∂éöóÒÇÃãüó^
    ---------------------------------------------------------------------------
    }
//    function    THexWordProperty.GetValue:String; HSS70
//    begin
//        FmtStr(Result, '$%.4x', [GetOrdValue]);
//    end;

    {
    ---------------------------------------------------------------------------
        ∫›Ωƒ◊∏¿
    ---------------------------------------------------------------------------
    }
    constructor THLine.Create(AOwner:TComponent);
    begin
        { îhê∂å≥åƒÇ—èoÇµ }
        inherited Create(AOwner);
        FVersion   := HLineVersion;

        { “› ﬁèâä˙âª }
        FLineType  := ltHorizontal;
        FThick     := 1;
        FLineStyle := lsSolid;
        FPattern   := $0000;
        FOpaque    := FALSE;
        FFgColor   := clBlack;
        FBgColor   := clWhite;
    end;

    {
    ---------------------------------------------------------------------------
        LineTypeÃﬂ€ ﬂ√®ÇÃê›íË
    ---------------------------------------------------------------------------
    }
    procedure   THLine.SetLineType(Value:TLineType);
    begin
        if Value <> FLineType then begin
            FLineType := Value;
            Invalidate;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        ThickÃﬂ€ ﬂ√®ÇÃê›íË
    ---------------------------------------------------------------------------
    }
    procedure   THLine.SetThick(Value:Integer);
    begin
        if Value <> FThick then begin
            FThick := Value;
            Invalidate;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        LineStyleÃﬂ€ ﬂ√®ÇÃê›íË
    ---------------------------------------------------------------------------
    }
    procedure   THLine.SetLineStyle(Value:TLineStyle);
    begin
        if Value <> FLineStyle then begin
            FLineStyle := Value;
            Invalidate;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        PatternÃﬂ€ ﬂ√®ÇÃê›íË
    ---------------------------------------------------------------------------
    }
    procedure   THLine.SetPattern(Value:HexWord);
    begin
        if Value <> FPattern then begin
            FPattern := Value;
            Invalidate;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        OpaqueÃﬂ€ ﬂ√®ÇÃê›íË
    ---------------------------------------------------------------------------
    }
    procedure   THLine.SetOpaque(Value:Boolean);
    begin
        if Value <> FOpaque then begin
            FOpaque := Value;
            Invalidate;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        FgColorÃﬂ€ ﬂ√®ÇÃê›íË
    ---------------------------------------------------------------------------
    }
    procedure   THLine.SetFgColor(Value:TColor);
    begin
        if Value <> FFgColor then begin
            FFgColor := Value;
            Invalidate;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        BgColorÃﬂ€ ﬂ√®ÇÃê›íË
    ---------------------------------------------------------------------------
    }
    procedure   THLine.SetBgColor(Value:TColor);
    begin
        if Value <> FBgColor then begin
            FBgColor := Value;
            Invalidate;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        ï`âÊ
    ---------------------------------------------------------------------------
    }
    procedure   THLine.Paint;
{$IFDEF ZERO}
    var
        ARect:TRect;
{$ENDIF}
    begin
        { îhê∂å≥åƒÇ—èoÇµ }
        inherited Paint;

        { íºê¸ï`âÊ }
        case FLineType of
        ltHorizontal:   DrawLine(Canvas, Point(0, 0),          Point(Width - 1,  0));
        ltVertical:     DrawLine(Canvas, Point(0, 0),          Point(0, Height - 1));
        ltDiagonal:     DrawLine(Canvas, Point(0, 0),          Point(Width - 1, Height - 1));
        ltBackDiagonal: DrawLine(Canvas, Point(0, Height - 1), Point(Width - 1, 0));
        end;
    end;

    {
    ---------------------------------------------------------------------------
        íºê¸ï`âÊ
    ---------------------------------------------------------------------------
    }
    procedure   THLine.DrawLine(Canvas:TCanvas; Pt1:TPoint; Pt2:TPoint);
        {  ﬂ¿∞›éÊìæ }
        function    GetDrawPattern:HexWord;
        begin
            case FLineStyle of
            lsSolid:   Result := $FFFF;
            lsDot:     Result := $8888;
            lsCsDot:   Result := $AAAA;
            lsDash:    Result := $CCCC;
            lsCsDash:  Result := $EEEE;
            lsPattern: Result := FPattern;
            else
                Result := $0000;
            end;
        end;

    var
        i, j:Integer;
{$IFDEF ZERO}
        Rc:TRect;
{$ENDIF}
        Bitmap:TBitmap;
        DstRc:TRect;
        SrcRc:TRect;
        DrawPattern:HexWord;
        ScrnDC:HDC;
        ScrnPt:TPoint;

    begin
        { éŒê¸ }
        if (Pt1.X - Pt2.X) * (Pt1.Y - Pt2.Y) <> 0 then begin
            { Õﬂ›ê›íË }
            Canvas.Pen.Style := psSolid;
            Canvas.Pen.Mode  := pmCopy;
            Canvas.Pen.Color := FFgColor;
            Canvas.Pen.Width := FThick;

            { ◊≤›ï`âÊ }
            Canvas.MoveTo(Pt1.X, Pt1.Y); Canvas.LineTo(Pt2.X, Pt2.Y);
        end
        { êÖïΩê¸ÅAâîíºê¸ }
        else begin
            { TBitmapê∂ê¨ }
            Bitmap := TBitmap.Create;
            if Pt1.X = Pt2.X then begin
                Bitmap.Width  := FThick;
                Bitmap.Height := Pt2.Y - Pt1.Y + 1;
            end;
            if Pt1.Y = Pt2.Y then begin
                Bitmap.Width  := Pt2.X - Pt1.X + 1;
                Bitmap.Height := FThick;
            end;

            { ï`âÊãÈå` }
            if Pt1.X = Pt2.X then begin
                SrcRc := Rect(0, 0, FThick, Pt2.Y - Pt1.Y + 1);
                DstRc := Rect(Pt1.X, Pt1.Y, Pt2.X + FThick, Pt2.Y);
            end;
            if Pt1.Y = Pt2.Y then begin
                SrcRc := Rect(0, 0, Pt2.X - Pt1.X + 1, FThick);
                DstRc := Rect(Pt1.X, Pt1.Y, Pt2.X, Pt2.Y + FThick);
            end;

            { îwåiê∂ê¨ }
            if FOpaque then begin
                ScrnPt := ClientToScreen(Point(0, 0));
                ScrnDC := GetDC(0);
                BitBlt(Bitmap.Canvas.Handle, SrcRc.Left, SrcRc.Top,
                    SrcRc.Right - SrcRc.Left + 1, SrcRc.Bottom - SrcRc.Top + 1,
                    ScrnDC, ScrnPt.X, ScrnPt.Y, SRCCOPY);
                ReleaseDC(0, ScrnDC);
            end
            else begin
                Bitmap.Canvas.Brush.Style := bsSolid;
                Bitmap.Canvas.Brush.Color := FBgColor;
                Bitmap.Canvas.FillRect(SrcRc);
            end;

            { ◊≤›ê∂ê¨ }
            DrawPattern := GetDrawPattern;
            if Pt1.X = Pt2.X then begin
                for i := 0 to FThick - 1 do begin
                    for j := 0 to Pt2.Y - Pt1.Y do begin
                        if ((DrawPattern shl (j mod 16)) and $8000) = 0 then
                            Continue;
                        Bitmap.Canvas.Pixels[i, j] := FFgColor;
                    end;
                end;
            end;
            if Pt1.Y = Pt2.Y then begin
                for i := 0 to FThick - 1 do begin
                    for j := 0 to Pt2.X - Pt1.X do begin
                        if ((DrawPattern shl (j mod 16)) and $8000) = 0 then
                            Continue;
                        Bitmap.Canvas.Pixels[j, i] := FFgColor;
                    end;
                end;
            end;

            { ï`âÊ }
            Canvas.Draw(DstRc.Left, DstRc.Top, Bitmap);

            { TBitmapîjä¸ }
            Bitmap.Free;
        end
    end;

{$IFNDEF HREG}
    {
    ***************************************************************************
        ∫›Œﬂ∞»›ƒÇÃìoò^
    ***************************************************************************
    }
    procedure   Register;
    begin
        RegisterComponents('HSS', [THLine]);
        RegisterPropertyEditor(TypeInfo(HexWord), nil, '', THexWordProperty);
    end;
{$ENDIF}

end.