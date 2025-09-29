//****************************************************************************//
// System			      : HSS100									                                //
// Sub System       :	HLabel												                          //
// Program name     :	Hラベルコンポーネント	                                  //
//					        :	HLabel.pas									                            //
// Name Space		    :	                                                        //
// Programmer		    :	ueo												                              //
// Date				      :	2009.08.11										                          //
// Note             : HSS70から生成                                           //
//                  : Labelコンポーネントに下記機能を実装                     //
//                  : ①縦表示機能                                            //
//                  : ②枠線表示機能(Editに見せかけるため)                    //
//----------------------------------------------------------------------------//
// Update Note		  :													                                //
//----------------------------------------------------------------------------//
//				  (c)Copyright  2009 Broadleaf Co,. Ltd					                    //
//****************************************************************************//
unit HLabel;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, HVersion;

type
  // 方向プロパティ(文字を表示する方向を変更する)
  TDirection = (Horizontal,			//横方向
                Vertical);			//縦方向

  // ラベルスタイル(無し、パネル風(Lowered)、パネル風(Raised)、エディット風）
  TLabelStyle = (lsNone, lsLowered, lsRaised, lsEdit);

  THLabel = class(TLabel)
  private
    // Private 宣言
    FVersion : TVersion;
    FStyle   : TLabelStyle;
    strText  : String;
    procedure  HDrawText(var Rect: TRect; Flags: Longint; Text:String);
    procedure  SetDirection(Value:TDirection);
    procedure  SetStyle(Value: TLabelStyle);
  protected
    // Protected 宣言
    procedure  Paint; override;
    procedure  AdjustBounds;override;
  public
    // Public 宣言
    FDirection:TDirection;
    constructor Create(AOwner:TComponent);override;
  published
    // Published 宣言
    property Direction:TDirection read FDirection write SetDirection default Horizontal;
    property Version: TVersion read FVersion write FVersion stored False;
    property Style: TLabelStyle read FStyle write SetStyle default lsNone;
  end;

  {$IFNDEF HREG}
   procedure Register;
  {$ENDIF}

implementation
uses
  HLib;

{$IFNDEF HREG}
{
***************************************************************************
    ｺﾝﾎﾟｰﾈﾝﾄの登録
***************************************************************************
}
procedure Register;
begin
  RegisterComponents('HSS', [THLabel]);
end;
{$ENDIF}

//---------------------------------------------------------------------------
//    ｺﾝｽﾄﾗｸﾀ
//---------------------------------------------------------------------------
constructor THLabel.Create(AOwner:TComponent);
begin
  // 派生元呼び出し
  inherited Create(AOwner);
  FVersion   := HLabelVersion;
  // フォントは常に固定ピッチ
  Font.Pitch := fpFixed;
  Font.Name  := 'ＭＳ ゴシック';
  Font.Size  := 11;
end;


//---------------------------------------------------------------------------
//    THLabel  Directionﾌﾟﾛﾊﾟﾃｨの設定
//---------------------------------------------------------------------------
procedure THLabel.SetDirection(Value:TDirection);
begin
  if FDirection <> Value then
  begin
    FDirection := Value;
    Invalidate;
  end;
end;

//---------------------------------------------------------------------------
//    Paintをｵｰﾊﾞｰﾗｲﾄﾞ表示方向を調整する
//---------------------------------------------------------------------------
procedure THLabel.Paint;
const
  Alignments: array[TAlignment] of Word = (DT_LEFT, DT_RIGHT, DT_CENTER);
  WordWraps: array[Boolean] of Word = (0, DT_WORDBREAK);
var
  Rect, CalcRect: TRect;
  DrawStyle: Longint;
  ix:Integer;
begin
  with Canvas do
  begin
    if not Transparent then
    begin
      Brush.Color := Self.Color;
      Brush.Style := bsSolid;
      FillRect(ClientRect);
    end;
    Brush.Style := bsClear;
    Rect := ClientRect;
    //縦方向に描画
    if FDirection = Vertical then
    begin
      strText := '';
      ix := 0;
      while ix < Length(Caption) do
      begin
        if IsKanji(Caption[ix+1]) = false then
        begin //半角
          strText := strText + Copy(Caption,ix+1,1);
          Inc(ix);
        end else
        begin //全角
          strText := strText + Copy(Caption,ix+1,2);
          Inc(ix,2);
        end;
        if ix < Length(Caption) then
          strText := strText + #13;
      end;
      DrawStyle := DT_EXPANDTABS or WordWraps[WordWrap] or Alignments[Alignment];
      HDrawText(Rect, DrawStyle,strText);
    //横方向に描画
    end else
    begin
      Brush.Style := bsClear;
      Rect := ClientRect;
      { DoDrawText takes care of BiDi alignments }
      DrawStyle := DT_EXPANDTABS or WordWraps[WordWrap] or Alignments[Alignment];
      { Calculate vertical layout }
      if Layout <> tlTop then
      begin
        CalcRect := Rect;
        DoDrawText(CalcRect, DrawStyle or DT_CALCRECT);
        if Layout = tlBottom then OffsetRect(Rect, 0, Height - CalcRect.Bottom)
        else OffsetRect(Rect, 0, (Height - CalcRect.Bottom) div 2);
      end;
      DoDrawText(Rect, DrawStyle);
    end;
  end;
  if AutoSize = true then
    AdjustBounds;

  //枠をつける
  if FStyle = lsEdit then
  begin
    // Edit風
    Canvas.Pen.Color := clGray;
    Canvas.MoveTo(0, Height-1);
    Canvas.LineTo(0,0);
    Canvas.LineTo(Width-1, 0);
    Canvas.Pen.Color := $00DFDFDF;
    Canvas.LineTo(Width-1, Height-1);
    Canvas.LineTo(0, Height-1);
    Canvas.MoveTo(1, Height-2);
    Canvas.Pen.Color := clBlack;
    Canvas.LineTo(1,1);
    Canvas.LineTo(Width-2,1);
    Canvas.Pen.Color := clSilver;
    Canvas.LineTo(Width-2, Height-2);
    Canvas.LineTo(1, Height-2);
    // 枠線が文字とかぶるようなら、空白を入れる
    case Alignment of
      taLeftJustify:
      begin
        if Copy(Caption,1,1) <> ' ' then
          Caption := ' '+Caption;
      end;
      taRightJustify:
      begin
        if Copy(Caption,Length(Caption),1) <> ' ' then
          Caption := Caption + ' ';
      end;
    end;
  end
  else if FStyle = lsLowered then
  begin
    // Panel風(Lowered)
    Canvas.Pen.Color := clGray;
    Canvas.MoveTo(0, Height-1);
    Canvas.LineTo(0,0);
    Canvas.LineTo(Width-1, 0);
    Canvas.Pen.Color := $00DFDFDF;
    Canvas.LineTo(Width-1, Height-1);
    Canvas.LineTo(0, Height-1);
    // 枠線が文字とかぶるようなら、空白を入れる
    case Alignment of
      taLeftJustify:
      begin
        if Copy(Caption,1,1) <> ' ' then
          Caption := ' '+Caption;
      end;
      taRightJustify:
      begin
        if Copy(Caption,Length(Caption),1) <> ' ' then
          Caption := Caption + ' ';
      end;
    end;
  end
  else if FStyle = lsRaised then
  begin
    // Panel風(Raised)
    Canvas.Pen.Color := $00DFDFDF;
    Canvas.MoveTo(0, Height-1);
    Canvas.LineTo(0,0);
    Canvas.LineTo(Width-1, 0);
    Canvas.Pen.Color := clGray;
    Canvas.LineTo(Width-1, Height-1);
    Canvas.LineTo(0, Height-1);
    // 枠線が文字とかぶるようなら、空白を入れる
    case Alignment of
      taLeftJustify:
      begin
        if Copy(Caption,1,1) <> ' ' then
          Caption := ' '+Caption;
      end;
      taRightJustify:
      begin
        if Copy(Caption,Length(Caption),1) <> ' ' then
          Caption := Caption + ' ';
      end;
    end;
  end;
end;

//---------------------------------------------------------------------------
//    ﾃｷｽﾄ文字表示関数
//---------------------------------------------------------------------------
procedure THLabel.HDrawText(var Rect: TRect; Flags: Longint; Text:String);
begin
  if (Flags and DT_CALCRECT <> 0) and ((Text = '') or ShowAccelChar and
    (Text[1] = '&') and (Text[2] = #0)) then Text := Text + ' ';
  if not ShowAccelChar then Flags := Flags or DT_NOPREFIX;
  Flags := DrawTextBiDiModeFlags(Flags);
  Canvas.Font := Font;
  if not Enabled then
  begin
    OffsetRect(Rect, 1, 1);
    Canvas.Font.Color := clBtnHighlight;
    DrawText(Canvas.Handle, PChar(Text), Length(Text), Rect, Flags);
    OffsetRect(Rect, -1, -1);
    Canvas.Font.Color := clBtnShadow;
    DrawText(Canvas.Handle, PChar(Text), Length(Text), Rect, Flags);
  end
  else
    DrawText(Canvas.Handle, PChar(Text), Length(Text), Rect, Flags);
end;


//---------------------------------------------------------------------------
//    AutoSizeがTrueの場合は表示幅を自動で調整する
//---------------------------------------------------------------------------
procedure THLabel.AdjustBounds;
const
  WordWraps: array[Boolean] of Word = (0, DT_WORDBREAK);
var
  DC: HDC;
  X: Integer;
  Rect: TRect;
  AAlignment: TAlignment;
begin
  if not (csReading in ComponentState) and AutoSize then
  begin
    Rect := ClientRect;
    DC := GetDC(0);
    Canvas.Handle := DC;
    if FDirection = Vertical then
      HDrawText(Rect, (DT_EXPANDTABS or DT_CALCRECT) or WordWraps[WordWrap],strText)
    else
      DoDrawText(Rect, (DT_EXPANDTABS or DT_CALCRECT) or WordWraps[WordWrap]);
    Canvas.Handle := 0;
    ReleaseDC(0, DC);
    X := Left;
    AAlignment := Alignment;
    if UseRightToLeftAlignment = true then ChangeBiDiModeAlignment(AAlignment);
    if AAlignment = taRightJustify then Inc(X, Width - Rect.Right);
    SetBounds(X, Top, Rect.Right, Rect.Bottom);
  end;
end;

//---------------------------------------------------------------------------
//    THLabel  SetStyleプロパティの設定
//---------------------------------------------------------------------------
procedure THLabel.SetStyle(Value: TLabelStyle);
begin
  FStyle := value;
  Repaint;
end;

end.

