{
******************************************************************************
    VCL ｺﾝﾎﾟｰﾈﾝﾄﾗｲﾌﾞﾗﾘ  ｢VCL/Xtend｣

        ﾌｧﾝｸｼｮﾝｷｰﾎﾞﾀﾝｺﾝﾎﾟｰﾈﾝﾄ

        ﾕﾆｯﾄ名  :   XDBLBTN.PAS
        作成者  :   Hiroaki Sakai (Penguin Cafe Software Co.)
        作成日  :   1996/6
        概要    :   ｷｬﾌﾟｼｮﾝを2行表示可能なﾎﾞﾀﾝを定義する
// Update Note      :   2000.09.22  鹿野　幸生                          //
//                  :   ① ShowHintプロパティを追加                     //
//                  :   ② フォーカス取得時にIMEモードをDisEnabledに設定//
//                  :   2000.10.04  鹿野　幸生                          //
//                  :   ① 初期化フェーズが毎回動作していたのを初回のみ //
//                  :      に変更                                       //
//                  :   2000.10.05  鹿野　幸生                          //
//                  :   ① ボタンスタイルの初期化位置を変更             //
//                  :   2002.10.30  鹿野　幸生                          //
//                  :   ① フォーム読み込み時、強制的にTabStop=Trueに   //
//                  :      なる障害を解除                               //
//                  :   2002.12.16  鹿野　幸生                          //
//                  :   ① 2002.10.30の障害解除が不完全なため、暫定対応 //
//                  :      を行う                                       //
//                  :   2009.08.18  鹿野　幸生                          //
//                  :   ① HSS100化                                     //
******************************************************************************
}
unit HDblBtn;

{$DEFINE UPDATE}
{$DEFINE XREG}

{
******************************************************************************
    interface部
******************************************************************************
}
interface

    { ﾕﾆｯﾄ指定 }
    uses
        SysUtils, WinTypes, WinProcs, Messages, Classes, Graphics, Controls,
        Forms, StdCtrls, Buttons, Dialogs, HVersion, hreg;

    { 定数定義 }
    const
        kDefWidth   = 89;
        kDefHeight  = 33;
        kDefPitch   = 2;
        kBevelThick = 1;

    { 型宣言 }
    type
        {
        -----------------------------------------------------------------------
            THDoubleCaptionButtonｵﾌﾞｼﾞｪｸﾄ定義
        -----------------------------------------------------------------------
        }
        THDoubleCaptionButton = class(TButtonControl)   { TButtonControlから派生 }
        private
            FVersion: TVersion;
            FCaption1:String;                           { ｷｬﾌﾟｼｮﾝ文字列1 }
            FCaption2:String;                           { ｷｬﾌﾟｼｮﾝ文字列2 }
            FFont1:TFont;                               { ﾌｫﾝﾄ1          }
            FFont2:TFont;                               { ﾌｫﾝﾄ2          }
            FPitch:Integer;                             { 行間ﾋﾟｯﾁ       }
            //Add
            FBackColor :TColor;                         { 文字背景色     }
            //Add(1996.12.3)
            FColor     :TColor;
            FFlat: Boolean;
            RetKeyFlag :Boolean;                       { リターンキー押下フラグ}
            FEnableRetKey :Boolean;                     { リターンキー有効フラグ }
        protected
            Canvas:TCanvas;
        private
            procedure   SetCaption1(Value:String);
            procedure   SetCaption2(Value:String);
            procedure   SetFont1(Value:TFont);
            procedure   SetFont2(Value:TFont);
            procedure   SetPitch(Value:Integer);
            procedure   SetBackColor(Value:TColor);
            procedure   SetColor(Value:TColor);
            procedure   SetFlat(Value: Boolean);
        protected
            procedure   FontChanged(Sender:TObject);
            procedure   DrawItem(const DrawItemStruct:TDrawItemStruct);
            procedure   GetCaptionBounds(var ARect1:TRect; var ARect2:TRect);
            procedure   DrawCaptions(ARect1:TRect; ARect2:TRect);
            procedure   CreateParams(var Params:TCreateParams); override;
            procedure   CNDrawItem(var Message:TWMDrawItem); message CN_DRAWITEM;
{$IFDEF UPDATE}
            procedure   CNCommand(var Message: TWMCommand);  message CN_COMMAND;
{$ENDIF}
            procedure   WMLButtonDblClk(var Message:TWMLButtonDblClk); message WM_LBUTTONDBLCLK;
            procedure   CMEnabledChanged(Var Message:TMessage); message CM_ENABLEDCHANGED;
            //Add(1996.12.3)
            procedure   KeyDown( var Key:Word ; Shift:TShiftState ); override;
            procedure   KeyUp( var Key:Word ; Shift:TShiftState ); override;
            procedure   Click; override;
        public
            constructor Create(AOwner:TComponent); override;
            destructor  Destroy; override;
            procedure   DoEnter; override;
        published
            property    Version: TVersion read FVersion write FVersion stored False;
            property    Caption1:String read FCaption1 write SetCaption1;
            property    Caption2:String read FCaption2 write SetCaption2;
            property    Font1:TFont read FFont1 write SetFont1;
            property    Font2:TFont read FFont2 write SetFont2;
            property    Pitch:Integer read FPitch write SetPitch;
            property    EnableRetKey :Boolean read FEnableRetKey write FEnableRetKey;
            //Add(1996/10/22)
            property    BackColor:TColor read FBackColor write SetBackColor;
            //Add(1996/10/17)
            property    Color:TColor read FColor write SetColor;
            property    Flat: Boolean read FFlat write SetFlat default False;
            property    Cursor;
            property    Enabled;
            property    TabOrder;
//            property    TabStop;                                              2002.10.30 変更
            property    TabStop default False;
            property    Visible;
            property    ShowHint;
            property    OnClick;
            property    OnDblClick;
            //Add(1996/10/23)
            property    OnKeyDown;
            property    OnKeyPress;
            property    OnKeyUp;
            property    OnMouseDown;
            property    OnMouseMove;
            property    OnMouseUp;
            property    OnEnter;
            property    OnExit;
        end;

    { ﾌﾟﾛｼｰｼﾞｬ、関数宣言 }
    {$IFNDEF XREG}
    procedure   Register];                                 { ｺﾝﾎﾟｰﾈﾝﾄの登録 }
    {$ENDIF}

{
******************************************************************************
    implementation部
******************************************************************************
}
implementation

    uses
        HLib;

    {
    ---------------------------------------------------------------------------
        ｺﾝｽﾄﾗｸﾀ
    ---------------------------------------------------------------------------
    }
    constructor THDoubleCaptionButton.Create(AOwner:TComponent);
    begin
        inherited Create(AOwner);


       FFont1          := TFont.Create;                                         // 2000.10.04 移動
       FFont2          := TFont.Create;
       FFont1.OnChange := FontChanged;
       FFont2.OnChange := FontChanged;

        // デザイン時のみ初期値設定                                             2000.10.04 追加
        if csDesigning in ComponentState then begin

          { 派生元変更 }
          FVersion     := HDoubleCaptionButtonVersion;
          Width        := kDefWidth;
          Height       := kDefHeight;
          ParentFont   := FALSE;
          TabStop      := True ;

          { ﾒﾝﾊﾞ設定 }
          FCaption1       := '';
          FCaption2       := '';
          FColor          := clBtnFace;
          FPitch          := kDefPitch;
          FBackColor      := clBtnFace ;
          FEnableRetKey   := False ;
          RetKeyFlag      := False ;

          { ﾌｫﾝﾄは常に固定ﾋﾟｯﾁ }
          FFont1.Pitch := fpFixed;
          FFont1.Name  := 'ＭＳ ゴシック';
          FFont1.Size  := 11;
          FFont2.Pitch := fpFixed;
          FFont2.Name  := 'ＭＳ ゴシック';
          FFont2.Size  := 11;

       end;

       TabStop      := True ;                                                   // 2002.12.16


{$IFDEF UPDATE}                                                                 // 2000.10.05 変更
       ControlStyle := [csSetCaption, csOpaque, csDoubleClicks];
{$ENDIF}

       Canvas := TCanvas.Create;

    end;

    {
    ---------------------------------------------------------------------------
        ﾃﾞｽﾄﾗｸﾀ
    ---------------------------------------------------------------------------
    }
    destructor  THDoubleCaptionButton.Destroy;
    begin
        FFont1.Free;
        FFont2.Free;

        Canvas.Free;

        inherited Destroy;
    end;

    {
    ---------------------------------------------------------------------------
        Caption1ﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
    procedure   THDoubleCaptionButton.SetCaption1(Value:String);
    begin
        if Value <> FCaption1 then begin
            FCaption1 := Value;
            Invalidate;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        Caption2ﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
    procedure   THDoubleCaptionButton.SetCaption2(Value:String);
    begin
        if Value <> FCaption2 then begin
            FCaption2 := Value;
            Invalidate;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        Font1ﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
    procedure   THDoubleCaptionButton.SetFont1(Value:TFont);
    begin
        FFont1.Assign(Value);
    end;

    {
    ---------------------------------------------------------------------------
        Font2ﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
    procedure   THDoubleCaptionButton.SetFont2(Value:TFont);
    begin
        FFont2.Assign(Value);
    end;


    {
    ---------------------------------------------------------------------------
        Pitchﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
    procedure   THDoubleCaptionButton.SetPitch(Value:Integer);
    begin
        if Value <> FPitch then begin
            FPitch := Value;
            Invalidate;
        end;
    end;
    {
    ---------------------------------------------------------------------------
        BackColorﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
    procedure   THDoubleCaptionButton.SetBackColor(Value:TColor);
    begin
        if FBackColor <> Value then begin
            FBackColor := Value ;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        ｺﾝﾎﾟｰﾈﾝﾄ描画
    ---------------------------------------------------------------------------
    }
    procedure   THDoubleCaptionButton.DrawItem(const DrawItemStruct:TDrawItemStruct);
    var
        IsDown, IsDefault:Boolean;
        TextBounds1, TextBounds2:TRect;
        Rc:TRect;
        Rc1:TRECT;
    begin
        with DrawItemStruct do begin
            IsDown    := itemState and ODS_SELECTED <> 0;
            IsDefault := itemState and ODS_FOCUS    <> 0;
        end;

        with Canvas do begin
            { TCanvas設定 }
            Canvas.Handle := DrawItemStruct.hDC;

            { 背景表示 }
            DrawButtonFace(Canvas, ClientRect, kBevelThick, bsAutoDetect, FALSE, IsDown, IsDefault);

            { ｷｬﾌﾟｼｮﾝ領域設定 }
            GetCaptionBounds(TextBounds1, TextBounds2);
            if IsDown then begin
                OffsetRect(TextBounds1, 1, 1);
                OffsetRect(TextBounds2, 1, 1);
            end;

            if IsDefault then begin
                Brush.Style := bsSolid;
                Brush.Color := BackColor;
                UnionRect(Rc, TextBounds1, TextBounds2);
                Rc1 := GetClientRect ;
                InflateRect(Rc1,-2,-2);
                //背景色表示
                Brush.Color := BackColor;
                FillRect(Rc1);
                //フォーカス枠表示
                WinProcs.DrawFocusRect( handle, Rc);
                { ｷｬﾌﾟｼｮﾝ表示 }
                DrawCaptions(TextBounds1, TextBounds2);
            end else begin
                { ｷｬﾌﾟｼｮﾝ表示 }
                Brush.Style := bsSolid;
                Brush.Color := Color;
                UnionRect(Rc, TextBounds1, TextBounds2);
                Rc1 := GetClientRect ;
                InflateRect(Rc1,-2,-2);
                //背景色表示
                Brush.Color := Color;
                FillRect(Rc1);
                FillRect(Rc1);
                DrawCaptions(TextBounds1, TextBounds2);
            end;

            { TCanvas復帰 }
            Handle := 0;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        ｷｬﾌﾟｼｮﾝ領域設定
    ---------------------------------------------------------------------------
    }
    procedure   THDoubleCaptionButton.GetCaptionBounds(var ARect1:TRect; var ARect2:TRect);
    var
        Client:TRect;
        TextPos1, TextPos2:TPoint;
        TextSize1, TextSize2:TPoint;
        ClientSize:TPoint;
        Str:array[0..255] of Char;
    begin
        with Canvas do begin
            Client := GetClientRect;

            Font.Assign(FFont1);
            if Length(FCaption1) = 0 then
                ARect1 := Rect(0, 0, 0, 0)
            else begin
                ARect1 := Rect(0, 0, Client.Right - Client.Left, 0);
                DrawText(Handle, StrPCopy(Str, FCaption1), -1, ARect1, DT_CALCRECT or DT_EXTERNALLEADING);
            end;
            TextSize1 := Point(ARect1.Right - ARect1.Left, ARect1.Bottom - ARect1.Top);

            Font.Assign(FFont2);
            if Length(FCaption2) = 0 then
                ARect2 := Rect(0, 0, 0, 0)
            else begin
                ARect2 := Rect(0, 0, Client.Right - Client.Left, 0);
                DrawText(Handle, StrPCopy(Str, FCaption2), -1, ARect2, DT_CALCRECT or DT_EXTERNALLEADING);
            end;
            TextSize2 := Point(ARect2.Right - ARect2.Left, ARect2.Bottom - ARect2.Top);

            ClientSize := Point(Client.Right - Client.Left, Client.Bottom - Client.Top);

            TextPos1.X := (ClientSize.X div 2) - (TextSize1.X div 2);
            TextPos2.X := (ClientSize.X div 2) - (TextSize2.X div 2);

            if TextSize2.Y = 0 then TextPos1.Y := (ClientSize.Y div 2) - (TextSize1.Y div 2)
            else                    TextPos1.Y := (ClientSize.Y - (TextSize1.Y + TextSize2.Y + FPitch)) div 2;

            if TextSize1.Y = 0 then TextPos2.Y := (ClientSize.Y div 2) - (TextSize2.Y div 2)
            else                    TextPos2.Y := TextPos1.Y + TextSize1.Y + FPitch;

            OffsetRect(ARect1, TextPos1.X + Client.Left, TextPos1.Y + Client.Top);
            OffsetRect(ARect2, TextPos2.X + Client.Left, TextPos2.Y + Client.Top);
        end;
    end;

    {
    ---------------------------------------------------------------------------
        ｷｬﾌﾟｼｮﾝ表示
    ---------------------------------------------------------------------------
    }
    procedure   THDoubleCaptionButton.DrawCaptions(ARect1:TRect; ARect2:TRect);
    var
        Str:array[0..255] of Char;
    begin
        with Canvas do begin
            Brush.Style := bsClear;
            if Enabled then begin
                if Length(Caption1) <> 0 then begin
                    Font.Assign(FFont1);
                    DrawText(Handle, StrPCopy(Str, Caption1), -1, ARect1, DT_CENTER or DT_VCENTER or DT_SINGLELINE);
                end;
                if Length(Caption2) <> 0 then begin
                    Font.Assign(FFont2);
                    DrawText(Handle, StrPCopy(Str, Caption2), -1, ARect2, DT_CENTER or DT_VCENTER or DT_SINGLELINE);
                end;
            end
            else begin
                if Length(Caption1) <> 0 then begin
                    Font.Assign(FFont1);
                    Font.Color := clWhite;
                    OffsetRect(ARect1, 1, 1);
                    DrawText(Handle, StrPCopy(Str, Caption1), -1, ARect1, DT_CENTER or DT_VCENTER or DT_SINGLELINE);
                    Font.Color := clDkGray;
                    OffsetRect(ARect1, -1, -1);
                    DrawText(Handle, StrPCopy(Str, Caption1), -1, ARect1, DT_CENTER or DT_VCENTER or DT_SINGLELINE);
                end;
                if Length(Caption2) <> 0 then begin
                    Font.Assign(FFont2);
                    Font.Color := clWhite;
                    OffsetRect(ARect2, 1, 1);
                    DrawText(Handle, StrPCopy(Str, Caption2), -1, ARect2, DT_CENTER or DT_VCENTER or DT_SINGLELINE);
                    Font.Color := clDkGray;
                    OffsetRect(ARect2, -1, -1);
                    DrawText(Handle, StrPCopy(Str, Caption2), -1, ARect2, DT_CENTER or DT_VCENTER or DT_SINGLELINE);
                end;
            end;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        TFont変更の捕捉
    ---------------------------------------------------------------------------
    }
    procedure   THDoubleCaptionButton.FontChanged(Sender:TObject);
    begin
        ParentFont := FALSE;
        Perform(CM_FONTCHANGED, 0, 0);
    end;

    {
    ---------------------------------------------------------------------------
        ｳｨﾝﾄﾞｳｽﾀｲﾙの設定
    ---------------------------------------------------------------------------
    }
    procedure   THDoubleCaptionButton.CreateParams(var Params:TCreateParams);
    begin
        { 派生元呼び出し }
        inherited CreateParams(Params);

        CreateSubClass(Params, 'BUTTON');
        Params.Style := Params.Style or BS_OWNERDRAW;
    end;

    {
    ---------------------------------------------------------------------------
        CN_DRAWITEMﾒｯｾｰｼﾞの捕捉
    ---------------------------------------------------------------------------
    }
    procedure   THDoubleCaptionButton.CNDrawItem(var Message:TWMDrawItem);
    begin
        DrawItem(Message.DrawItemStruct^);
    end;

{$IFDEF UPDATE}
    {
    ---------------------------------------------------------------------------
        CN_COMMANDﾒｯｾｰｼﾞの捕捉
    ---------------------------------------------------------------------------
    }
    procedure   THDoubleCaptionButton.CNCommand(var Message: TWMCommand);
    begin
        if Message.NotifyCode = BN_CLICKED then Click;
    end;
{$ENDIF}

    {
    ---------------------------------------------------------------------------
        WM_LBUTTONDBLCLKﾒｯｾｰｼﾞの捕捉
    ---------------------------------------------------------------------------
    }
    procedure   THDoubleCaptionButton.WMLButtonDblClk(var Message:TWMLButtonDblClk);
    begin
        { ｼﾝｸﾞﾙｸﾘｯｸに置き換え }
        Perform(WM_LBUTTONDOWN, Message.Keys, Longint(Message.Pos));
    end;

    {
    ---------------------------------------------------------------------------
        CM_ENABLEDCHANGEDﾒｯｾｰｼﾞの捕捉
    ---------------------------------------------------------------------------
    }
    procedure   THDoubleCaptionButton.CMEnabledChanged(Var Message:TMessage);
    begin
        inherited;

        Invalidate;
    end;

//**********************************************************************//
// Module Name      :   Enterイベント前処理                             //
//                  :   THDoubleCaptionButton.DoEnter                   //
// Programer        :   鹿野　幸生                                      //
// Date             :   2000.09.22                                      //
//----------------------------------------------------------------------//
// Update Note      :   200x.xx.xx ＸＸ　ＸＸ                     　    //
//**********************************************************************//
    procedure THDoubleCaptionButton.DoEnter;
    begin

      SetImeMode(Handle, imDisable);

      Inherited;
    end;

    procedure   THDoubleCaptionButton.KeyDown( var Key:Word ; Shift:TShiftState );
    begin
      if (Key = VK_RETURN)and(EnableRetKey = True) then begin
        RetKeyFlag := True ;
      end else begin
        RetKeyFlag := False ;
      end;
        inherited KeyDown( Key, Shift );
    end;

    procedure   THDoubleCaptionButton.KeyUp( var Key:Word ; Shift:TShiftState );
    begin
      if (EnableRetKey = True)and(RetKeyFlag = True )and(Key = VK_RETURN) then begin
        Click;
        RetKeyFlag := False ;
      end;
      inherited KeyUp( Key, Shift );
    end;

    procedure   THDoubleCaptionButton.Click;
    begin
      inherited Click;
    end;

    procedure THDoubleCaptionButton.SetColor(Value:TColor);
    begin
	    if FColor <> Value then
        begin
            FColor := Value;
            Invalidate;
        end;
    end;

    procedure THDoubleCaptionButton.SetFlat(Value: Boolean);
    begin
      if Value <> FFlat then
      begin
        FFlat := Value;
        Invalidate;
      end;
    end;

    {$IFNDEF XREG}
    {
    ***************************************************************************
        ｺﾝﾎﾟｰﾈﾝﾄの登録
    ***************************************************************************
    }
    procedure Register;
    begin
        RegisterComponents('HSS', [THDoubleCaptionButton]);
    end;
    {$ENDIF}

end.
