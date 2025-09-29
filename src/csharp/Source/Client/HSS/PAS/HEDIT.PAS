
{
******************************************************************************
    HSS ｺﾝﾎﾟｰﾈﾝﾄﾗｲﾌﾞﾗﾘ  ｢HSS｣

        拡張ｴﾃﾞｨｯﾄｺﾝﾄﾛｰﾙ

        ﾕﾆｯﾄ名  :   HEDIT.PAS
        作成者  :   Kubochi
        作成日  :   1999/7
        概要    :   TEditｺﾝﾎﾟｰﾈﾝﾄに以下の機能を追加したTHEditを定義する。
                        数値編集（ｾﾞﾛ抑制、ｾﾞﾛ詰め、0表示、ｶﾝﾏ編集）
                        入力字種
                        電卓入力
        変更箇所:   X系ｺﾝﾎﾟｰﾈﾝﾄからの変更箇所。
                        DSL使用を無効
                    THNeditへMouseInputプロパティーを追加
                    ﾀﾌﾞﾙｸﾘｯｸ時にﾏｳｽ入力ﾎﾞﾀﾝPanelを表示
        変更履歴 20000322 kubochi
                    マウス入力PanelをOwner Form上では無く別フォーム上に
                    Createするように変更
//                  :   2001.03.02  鹿野　幸生                          //
//                  :   ①  範囲チェックでエラーが発生する場合があった  //
//                  :       障害を解除                                  //
//                  :   2001.03.17  鹿野　幸生                          //
//                  :   ①  空チェックでエラーが発生する場合があった    //
//                  :       障害を解除                                  //
//                  :   2001.04.12  鹿野　幸生                          //
//                  :   ①  ゼロサプレスするに設定してあるにも関わらず、//
//                  :       先行ゼロ列が残る場合が有る障害に対処障害を  //
//                  :       解除                                        //
//                  :   2001.06.19  鹿野　幸生                          //
//                  :   ①  マウスボタンのサイズが変更された場合、合わせ//
//                  :       てフォントサイズも自動的に最適になるように  //
//                  :       MouseBtnAutoFontSizeプロパティを追加        //
//                  :   2003.08.18  鹿野　幸生                          //
//                  :   ① Edit部で小数点をDEL、BACKで削除した際、指定桁//
//                  :      を超えて入力されてしまう障害を解除           //
//                  :   2009.08.11  須川  程志郎                        //
//                  :   ① HSS100対応(HSS70ベース)                      //
//                  :   2010.04.12  須川  程志郎                        //
//                  :   ① HNeditの数値文字以外を貼り付けした際、       //
//                  :      貼り付けで着ないようにする処理を追加         //
//                  :   2010.05.13  須川  程志郎                        //
//                  :   ① HEditにSJis換算でのバイト数入力制限機能の追加//
//                  :      (ColValidプロパティ追加)                     //
//                  :      (貼り付け時の処理追加)                       //
//                  :      (ｺﾝﾎﾟ幅→桁数, 桁数→ｺﾝﾎﾟ幅 取得ﾛｼﾞｯｸ改修)   //
******************************************************************************
}
unit Hedit;

{$DEFINE UPDATE}
{$DEFINE HREG}

{$DEFINE NEWCOLORCTL}   // Add 1997-04-17 T.Sasagawa

{
******************************************************************************
    interface部
******************************************************************************
}
interface

    { ﾕﾆｯﾄ指定 }
    uses
        SysUtils, WinTypes, WinProcs, Messages, Classes, Graphics, Controls,
//        Forms, StdCtrls, Menus, HExtCase{, XChkDD}, HVersion,ExtCtrls;
        Forms, StdCtrls, Menus, HVersion, ExtCtrls, Clipbrd;
    { 型宣言 }
    type
        { 数値文字列属性 }
        THNumStrAttr = record
            Sign:Boolean;                       { 符号       }
            HiColumn:Integer;                   { 整数部桁数 }
            Point:Boolean;                      { 小数点     }
            LoColumn:Integer;                   { 小数部桁数 }
        end;

        { 詰め方 }
        TAlignment = (alNone,                   { 無編集 }
                      alLeft,                   { 左詰め }
                      alCenter,                 { 中央   }
                      alRight);                 { 右詰め }

        { 入力字種 }
        TEnableChar = (ecWord,                  { 全角     }
                       ecSpace,                 { ｽﾍﾟｰｽ    }
                       ecSign,                  { 記号     }
                       ecKana,                  { ｶﾅ       }
                       ecAlpha,                 { 英字     }
                       ecNumSign,               { 数字記号 }
                       ecNum);                  { 数字     }
        TEnableChars = set of TEnableChar;

        { ｶｰｿﾙ位置 }
        TCursorPos = (cpPrev,                   { 前回位置 }
                      cpTop,                    { 先頭     }
                      cpEnd);                   { 末尾     }

        { 脱出要件 }
        TExitCtrl = (exAuto,                    { 自動脱出 }
                     exFull,                    { 全桁入力 }
                     exRet,                     { RETｷｰ    }
                     exRight,                   { 右矢印ｷｰ }
                     exLeft,                    { 左矢印ｷｰ }
                     exUp,                      { 上矢印ｷｰ }
                     exDown);                   { 下矢印ｷｰ }
        TExitCtrls = set of TExitCtrl;

        { ｾﾞﾛ抑制 }
        TZeroSupp = (zsOff,                     { 無編集  }
                     zsOn,                      { ｾﾞﾛ抑制 }
                     zsFill);                   { ｾﾞﾛ詰め }

// >>>>>>>>>>> 2010.05.13 Add T.Sugawa >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        { 桁数検証 }
        TColValid = (cvCharCount,               { 文字数  }
                     cvSJisByteCount);          { Shift-JIS換算ﾊﾞｲﾄ数 }
// <<<<<<<<<<< 2010.05.13 Add T.Sugawa <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        {
        ----------------------------------------------------------------------
            脱出要件型定義 (追加HSS70)
        ----------------------------------------------------------------------
        }
        TExtCase = class(TPersistent)
        private
            FNecessary:Boolean;                 { 入力必須        }
            FRetKey:Boolean;                    { RETｷｰ有効       }
            FShiftRetKey:Boolean;               { SHIFT+RETｷｰ有効 }
            FTabKey:Boolean;                    { TABｷｰ有効       }
            FShiftTabKey:Boolean;               { SHIFT+TABｷｰ有効 }
            FRightKey:Boolean;                  { 右矢印ｷｰ有効    }
            FLeftKey:Boolean;                   { 左矢印ｷｰ有効    }
            FUpKey:Boolean;                     { 上矢印ｷｰ有効    }
            FDownKey:Boolean;                   { 下矢印ｷｰ有効    }
        public
            constructor Create;
            procedure   Assign(Source:TPersistent); override;
        published
            property    Necessary:Boolean read FNecessary write FNecessary;
            property    RetKey:Boolean read FRetKey write FRetKey;
            property    ShiftRetKey:Boolean read FShiftRetKey write FShiftRetKey;
            property    TabKey:Boolean read FTabKey write FTabKey;
            property    ShiftTabKey:Boolean read FShiftTabKey write FShiftTabKey;
            property    RightKey:Boolean read FRightKey write FRightKey;
            property    LeftKey:Boolean read FLeftKey write FLeftKey;
            property    UpKey:Boolean read FUpKey write FUpKey;
            property    DownKey:Boolean read FDownKey write FDownKey;
        end;
        {
        -----------------------------------------------------------------------
            数値ﾏｳｽ入力用Panelｵﾌﾞｼﾞｪｸﾄ定義 1999-8-20 Add kubochi
        -----------------------------------------------------------------------
        }
        TMouseTach = class(TPanel)
        private
            HNeditName  : string;
            procedure TachPanelMouseDown(Sender:TObject;Button:TMouseButton; shift:TShiftState; X, Y:Integer);
            procedure TachPanelMouseUp(Sender:TObject;Button:TMouseButton; shift:TShiftState; X, Y:Integer);
        protected
            TachPanel0  : TPanel;                 { 0Panel  }
            TachPanel1  : TPanel;                 { 1Panel  }
            TachPanel2  : TPanel;                 { 2Panel  }
            TachPanel3  : TPanel;                 { 3Panel  }
            TachPanel4  : TPanel;                 { 4Panel  }
            TachPanel5  : TPanel;                 { 5Panel  }
            TachPanel6  : TPanel;                 { 6Panel  }
            TachPanel7  : TPanel;                 { 7Panel  }
            TachPanel8  : TPanel;                 { 8Panel  }
            TachPanel9  : TPanel;                 { 9Panel  }
            TachPanel10 : TPanel;                 { .Panel  }
            TachPanel11 : TPanel;                 { -Panel  }
        public
            constructor Create(AOwner: TComponent); override;
            destructor  Destroy; override;
        published
        end;

        {
        -----------------------------------------------------------------------
            拡張編集型ｵﾌﾞｼﾞｪｸﾄ定義
        -----------------------------------------------------------------------
        }
        TExtEdit = class(TPersistent)
        private
            FAlignment:TAlignment;                  { 詰め方      }
            FEnableChars:TEnableChars;              { 入力字種    }
            FCursorPos:TCursorPos;                  { ｶｰｿﾙ位置    }
            FFreeCursor:Boolean;                    { ﾌﾘｰｶｰｿﾙﾓｰﾄﾞ }
            FAutoWidth:Boolean;                     { 自動幅設定  }
            FColumn:Integer;                        { 桁数        }
            FColValid:TColValid;                    { 桁数検証    }             // 2010.05.13 Add T.Sugawa
            FOnChange:TNotifyEvent;
        protected
            procedure   SetAlignment(Value:TAlignment);
            procedure   SetAutoWidth(Value:Boolean);
            procedure   SetColumn(Value:Integer);
            procedure   SetColValid(Value:TColValid);
        public
            constructor Create;
            procedure   Assign(Source:TPersistent); override;
        published
            property    Alignment:TAlignment read FAlignment write SetAlignment;
            property    EnableChars:TEnableChars read FEnableChars write FEnableChars;
            property    CursorPos:TCursorPos read FCursorPos write FCursorPos;
            property    FreeCursor:Boolean read FFreeCursor write FFreeCursor;
            property    AutoWidth:Boolean read FAutoWidth write SetAutoWidth;
            property    Column:Integer read FColumn write SetColumn;
            property    ColValid:TColValid read FColValid write SetColValid default cvCharCount;    // 2010.05.13 Add T.Sugawa
            property    OnChange:TNotifyEvent read FOnChange write FOnChange;
        end;


        {
        -----------------------------------------------------------------------
            数値編集型ｵﾌﾞｼﾞｪｸﾄ定義
        -----------------------------------------------------------------------
        }
        THNumEdit = class(TPersistent)
        private
            FZeroSupp:TZeroSupp;                    { ｾﾞﾛ抑制  }
            FZeroDisp:Boolean;                      { 0表示    }
            FKanmaEdt:Boolean;                      { ｶﾝﾏ編集  }
            FDecLen:Integer;                        { 小数桁数 }
            FCalcInput:Boolean;                     { 電卓入力 }
(* Add matsu 1997-09-17 THNumEdit.Minusﾌﾟﾛﾊﾟﾃｨ追加 DSL型自動判定 *)
            FMinusSupp:Boolean;                     { ﾏｲﾅｽ入力抑制 }
(* Add End *)
            FOnChange:TNotifyEvent;
        protected
            procedure   SetZeroSupp(Value:TZeroSupp);
            procedure   SetZeroDisp(Value:Boolean);
            procedure   SetKanmaEdt(Value:Boolean);
            procedure   SetDecLen(Value:Integer);
        public
            constructor Create;
            procedure   Assign(Source:TPersistent); override;
        published
            property    ZeroSupp:TZeroSupp read FZeroSupp write SetZeroSupp;
            property    ZeroDisp:Boolean read FZeroDisp write SetZeroDisp;
            property    KanmaEdt:Boolean read FKanmaEdt write SetKanmaEdt;
            property    DecLen:Integer read FDecLen write SetDecLen;
            property    CalcInput:Boolean read FCalcInput write FCalcInput;
(* Add matsu 1997-09-17 THNumEdit.Minusﾌﾟﾛﾊﾟﾃｨ追加 DSL型自動判定 *)
            property    MinusSupp:Boolean read FMinusSupp write FMinusSupp;
(* Add End *)
            property    OnChange:TNotifyEvent read FOnChange write FOnChange;
        end;

        {
        -----------------------------------------------------------------------
            HEditｵﾌﾞｼﾞｪｸﾄ定義
        -----------------------------------------------------------------------
        }
        THEdit = class(TCustomEdit)
        private
            FVersion: TVersion;
            FExtEdit:TExtEdit;                          { 拡張編集     }
            FActFgColor:TColor;                         { ｱｸﾃｨﾌﾞFGC    }
            FActBgColor:TColor;                         { ｱｸﾃｨﾌﾞBGC    }
            FExtCase:TExtCase;                          { 脱出要件     }
            FCheckEmpty :Boolean;  //1996.11.25
//    {$IFDEF PHOENIX}
//            FCheckDD:TCheckDD;                          { ﾁｪｯｸDDの設定 }
//    {$ENDIF}
//          dimc :HIMC;  //ローカルIMEハンドル
        protected
            NorFgColor:TColor;
            NorBgColor:TColor;
            WMSizeCount:Integer;
            NowEditing:Boolean;
            NowFontChanging:Boolean;

            wkFlg:Boolean;

//    {$IFDEF PHOENIX}
//            PrevText:String;
//    {$ENDIF}
        private
            function    GetExtEdit:TExtEdit;
            procedure   SetExtEdit(Value:TExtEdit);
            function    GetDataText:TCaption; virtual;
            procedure   SetDataText(Value:TCaption); virtual;
            function    GetExtCase:TExtCase;
            procedure   SetExtCase(Value:TExtCase);
            procedure   SetActFgColor(Value:TColor);
            procedure   SetActBgColor(Value:TColor);
            function    GetColor:TColor;
            procedure   SetColor(Value:TColor);
//    {$IFDEF PHOENIX}
//            function    GetCheckDD:TCheckDD;
//            procedure   SetCheckDD(Value:TCheckDD);
//    {$ENDIF}

        protected
            function    CheckCharactor(Key:Char; EnableChars:TEnableChars):Boolean; virtual;
            procedure   DisplayColChanging(ACol:Integer); virtual;
            procedure   ExtEditColChanging(ACol:Integer); virtual;
            function    ColumnToWidth(c:Integer):Integer;
            function    ClientWidthToColumn(w:Integer):Integer;

            function    ColumnToWidth2(c, m:Integer):Integer;                   // 2010.05.13 Add T.Sugawa
            function    ClientWidthToColumn2(w, m:Integer):Integer;             // 2010.05.13 Add T.Sugawa

            function    CheckExtCase(Key:Word; Shift:TShiftState):Boolean;
            procedure   ExtEditChanged(Sender:TObject);

(* Add matsu 1997-04-18 *)
{$IFDEF NEWCOLORCTL}
            procedure   WMKeyDown(var Message:TWMKeyDown); message WM_KEYDOWN;
            procedure   SetFontColor(Value: TColor);
{$ENDIF}
(* Add End *)

            procedure   KeyPress(var Key:Char); override;
            procedure   DoEnter; override;
            procedure   DoExit; override;
            procedure   Change; override;
//    {$IFDEF PHOENIX}
//            procedure   SetName(const NewName:TComponentName); override;
//    {$ENDIF}
            procedure   CMFontChanged(var Message:TMessage); message CM_FONTCHANGED;
            procedure   WMSize(var Message:TWMSize); message WM_SIZE;
            procedure   SetCheckEmpty( Permit :Boolean);  //1996.11.25
            procedure   WMPaste(var Message: TMessage); message WM_PASTE;       // 2010.05.13 Add T.Sugawa

        public
            constructor Create(AOwner:TComponent); override;
            destructor  Destroy; override;
            function    CanExit(Key:Word; Shift:TShiftState):Boolean;
            function    IsDataEmpty:Boolean;
//    {$IFDEF PHOENIX}
//            function    IsDataChanged:Boolean;
//   {$ENDIF}

(* Add matsu 1997-04-18 *)
            property    FontColor: TColor read NorFgColor write SetFontColor;
(* Add End *)

        published
            property    Version: TVersion read FVersion write FVersion stored False;
            property    ExtEdit:TExtEdit read GetExtEdit write SetExtEdit;
            property    ActFgColor:TColor read FActFgColor write SetActFgColor;
            property    ActBgColor:TColor read FActBgColor write SetActBgColor;
            property    DataText:TCaption read GetDataText write SetDataText;
            property    ExtCase:TExtCase read GetExtCase write SetExtCase;
            //1996.11.25
            property    CheckEmpty:Boolean read FCheckEmpty write SetCheckEmpty;
//    {$IFDEF PHOENIX}
//            property    CheckDD:TCheckDD read GetCheckDD write SetCheckDD;
//    {$ENDIF}

            property    AutoSelect;
            property    AutoSize;
            property    BorderStyle;
            property    CharCase;
{$IFDEF UPDATE}
            property    Color:TColor read GetColor write SetColor default clWindow;
{$ELSE}
            property    Color:TColor read GetColor write SetColor default clWhite;
{$ENDIF}
            property    Ctl3D;
            property    DragCursor;
            property    DragMode;
            property    Enabled;
            property    Font;
            property    HideSelection;
            property    ImeMode;
            property    OEMConvert;
            property    ParentColor;
            property    ParentCtl3D;
            property    ParentFont;
            property    ParentShowHint;
            property    PasswordChar;
            property    PopupMenu;
            property    ReadOnly;
            property    ShowHint;
            property    TabOrder;
            property    TabStop;
            property    Text;
            property    Visible;
            property    OnChange;
            property    OnClick;
            property    OnDblClick;
            property    OnDragDrop;
            property    OnDragOver;
            property    OnEndDrag;
            property    OnEnter;
            property    OnExit;
            property    OnKeyDown;
            property    OnKeyPress;
            property    OnKeyUp;
            property    OnMouseDown;
            property    OnMouseMove;
            property    OnMouseUp;
        end;

        {
        -----------------------------------------------------------------------
            HNeditｵﾌﾞｼﾞｪｸﾄ定義
        -----------------------------------------------------------------------
        }
        THNedit = class(THEdit)
        private
            FVersion : TVersion;
            FHNumEdit: THNumEdit;                         { 拡張編集 }
(* Add kubochi 1999-08-20 begin   *)
            FMouseInput      : Boolean;
            FMouseBtnSize    : integer;
            FMouseBtnFont    : TFont  ;
            FMouseBtnColor   : TColor ;
            FMouseBtnDwnColor: TColor ;
(* Add kubochi 1999-08-20 end     *)
            FMouseBtnAutoFontSize: Boolean;                                     // 2001.06.19 追加

        protected
(* Add matsu 1997-09-29 プロパティ設定のタイミング変更 TabSheetに貼った時、
                        表示がおかしかった点（左詰め）を修正 *)
            procedure   Loaded; override;
(* Add End *)
            procedure   KeyPress(var Key:Char); override;
            procedure   DoEnter; override;
            procedure   DoExit; override;
            procedure   CalcDeactivate(Sender:TObject);                 // 20000322 kubochi add
            procedure   CalcKeyDown(Sender: TObject; var Key: Word;
                                                   Shift: TShiftState); // 20000322 kubochi add
        private
            procedure   SetNumEdit(Value:THNumEdit);
            procedure   SetDataText(Value:TCaption); override;
            function    GetDataText:TCaption; override;
(* Add 1999-8-20 kubochi begin *)
            procedure   SetMouseBtnFont(Value:TFont);
            procedure   SetMouseBtnSize(Value:integer);
(* Add 1999-8-20 kubochi end *)
        protected
(* Add 1999-8-20 kubochi begin *)
            MTach       : TMouseTach;
            CalcForm    : TForm;                                        // 20000322 kubochi add
            procedure   DblClick; override;
(* Add 1999-8-20 kubochi end *)
            procedure   MouseDown(Button:TMouseButton; shift:TShiftState; X, Y:Integer); override;
            function    CheckCharactor(Key:Char; EnableChars:TEnableChars):Boolean; override;
            procedure   DisplayColChanging(ACol:Integer); override;
            procedure   ExtEditColChanging(ACol:Integer); override;
            procedure   WMKeyDown(var Message:TWMKeyDown); message WM_KEYDOWN;
            procedure   WMPaste(var Message: TMessage); message WM_PASTE;       // 2010.04.12 Add T.Sugawa
            function    EditNumStr(var Str:String):Integer;
            procedure   NumEditChanged(Sender:TObject);

        public
            FullInputed:Boolean;
            constructor Create(AOwner:TComponent); override;
(* Add 1999-8-20 kubochi begin *)
            destructor  Destroy; override;
            function    GetValue:double;
            procedure   SetValue(Value:double);
            function    GetInt:Longint;
            procedure   SetInt(Value:Longint);
(* Add 1999-8-20 kubochi end   *)
            function    CanExit(Key:Word; Shift:TShiftState):Boolean;

        published
            property    Version: TVersion read FVersion write FVersion stored False;
            property    NumEdit:THNumEdit read FHNumEdit write SetNumEdit;
            property    DataText:TCaption read GetDataText write SetDataText;
(* Add kubochi 1999-08-20 begin   *)
            property    MouseInput   :Boolean  read FMouseInput     write FMouseInput    ;
            property    MouseBtnSize :integer  read FMouseBtnSize   write SetMouseBtnSize;
            property    MouseBtnFont :TFont    read FMouseBtnFont   write SetMouseBtnFont;
            property    MouseBtnColor:TColor   read FMouseBtnColor  write FMouseBtnColor ;
            property    MouseBtnDwnColor : TColor read FMouseBtnDwnColor write FMouseBtnDwnColor;
(* Add kubochi 1999-08-20 end     *)
            property    MouseBtnAutoFontSize:Boolean                            // 2001.06.19 追加
                        read FMouseBtnAutoFontSize write FMouseBtnAutoFontSize
                        default True;
        end;

{$IFNDEF HREG}
    { ﾌﾟﾛｼｰｼﾞｬ、関数宣言 }
    procedure   Register;                           { ｺﾝﾎﾟｰﾈﾝﾄの登録 }
{$ENDIF}

{
******************************************************************************
    implementation部
******************************************************************************
}
implementation

    { ﾕﾆｯﾄ指定 }
    uses
        HLib, Dialogs,{ Dsplib, DataCtrl,} Imm;

    { 定数定義 }
    const
        kDefColumn = 12;                        { ﾃﾞﾌｫﾙﾄ桁数 }
        kBackSpace = #$08;                      { BSｺｰﾄﾞ }
//        KanjiBegin:Boolean = FALSE;             { 漢字入力開始ﾌﾗｸﾞ }          // 2009.08.11 Del

//        kByteSpace = $20;                       { 半角ｽﾍﾟｰｽｺｰﾄﾞ }             // 2009.08.11 Del
//        kWordSpace = $8140;                     { 全角ｽﾍﾟｰｽｺｰﾄﾞ }             // 2009.08.11 Del

(* Add kubochi 1999-8-20 begin   *)
        PanelCnt   = 12;                        { Panel数       }

        ctDEF_BTN_SIZE = 20;                                                    // 2001.06.19 追加

    {
    ---------------------------------------------------------------------------
        TExtCase    ｺﾝｽﾄﾗｸﾀ (HSS70追加)
    ---------------------------------------------------------------------------
    }
    constructor TExtCase.Create;
    begin
        FNecessary   := FALSE;
        FRetKey      := TRUE;
        FShiftRetKey := TRUE;
        FTabKey      := TRUE;
        FShiftTabKey := TRUE;
        FRightKey    := TRUE;
        FLeftKey     := TRUE;
        FUpKey       := TRUE;
        FDownKey     := TRUE;
    end;

    {
    ---------------------------------------------------------------------------
        TExtCase    ｵﾌﾞｼﾞｪｸﾄのｺﾋﾟｰ (HSS70追加)
    ---------------------------------------------------------------------------
    }
    procedure   TExtCase.Assign(Source:TPersistent);
    begin
        if not (Source is TExtCase) then
            inherited Assign(Source)
        else begin
            Necessary   := TExtCase(Source).Necessary;
            RetKey      := TExtCase(Source).RetKey;
            ShiftRetKey := TExtCase(Source).ShiftRetKey;
            TabKey      := TExtCase(Source).TabKey;
            ShiftTabKey := TExtCase(Source).ShiftTabKey;
            RightKey    := TExtCase(Source).RightKey;
            LeftKey     := TExtCase(Source).LeftKey;
            UpKey       := TExtCase(Source).UpKey;
            DownKey     := TExtCase(Source).DownKey;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        TMouseTach    ｺﾝｽﾄﾗｸﾀ
    ---------------------------------------------------------------------------
    }
    constructor TMouseTach.Create(AOwner:TComponent);
    var
        RoopCnt   : integer   ;
        TachPanel : TComponent;
        SetWidth,SetHeight,SetBtnSize : integer;
        Pt        : TPoint    ;
        i:          integer;
    begin
        { 派生元呼び出し }
//        inherited Create(AOwner.Owner);                               // 20000322 kubochi del
        inherited Create(THNedit(AOwner).CalcForm);                     // 20000322 kubochi add

        visible := False;
        UPDATE;
//        TForm(AOwner.Owner).InsertControl(Self);                      // 20000322 kubochi del
        TForm(THNedit(AOwner).CalcForm).InsertControl(Self);            // 20000322 kubochi add
        SetBtnSize:= THNedit(AOwner).MouseBtnSize;
        SetWidth  := THNedit(AOwner).MouseBtnSize * 3;
        SetHeight := THNedit(AOwner).MouseBtnSize * 4;

        Pt := TForm(AOwner.Owner).ScreenToClient(THNedit(AOwner).ClientToScreen(Point(THNedit(AOwner).Left, THNedit(AOwner).Top)));
        Pt.X := Pt.X - THNedit(AOwner).Left - 2;
        Pt.Y := Pt.Y - THNedit(AOwner).top  - 2;

        if (Pt.Y + THNedit(AOwner).height + SetHeight <= TForm(AOwner.Owner).Height)
        and(Pt.X + SetWidth <= TForm(AOwner.Owner).Width) then begin
            top  := Pt.Y + THNedit(AOwner).height;
            left := Pt.X;
        end else if (Pt.Y + THNedit(AOwner).height + SetHeight <= TForm(AOwner.Owner).Height)
                and (Pt.X + THNedit(AOwner).Width >= SetWidth) then begin
            top  := Pt.Y + THNedit(AOwner).height;
            left := (Pt.X + THNedit(AOwner).Width) - SetWidth;
        end else if (Pt.Y >= SetHeight)
                and (Pt.X + SetWidth <= TForm(AOwner.Owner).Width) then begin
            top  := Pt.Y - SetHeight;
            left := Pt.X;
        end else if (Pt.Y >= SetHeight)
                and (Pt.X + THNedit(AOwner).Width >= SetWidth) then begin
            top  := Pt.Y - SetHeight;
            left := (Pt.X + THNedit(AOwner).Width) - SetWidth;
        end else begin
            top  := Pt.Y + THNedit(AOwner).height;
            left := Pt.X;
        end;

        HNeditName  := AOwner.Name;
        Name        := 'BaseTachPanel';
        caption     := '';
        Width       := SetWidth;
        Height      := SetHeight;

        TachPanel0  := TPanel.Create(Self);{ 0Panel  }  TachPanel1  := TPanel.Create(Self);{ 1Panel  }
        TachPanel2  := TPanel.Create(Self);{ 2Panel  }  TachPanel3  := TPanel.Create(Self);{ 3Panel  }
        TachPanel4  := TPanel.Create(Self);{ 4Panel  }  TachPanel5  := TPanel.Create(Self);{ 5Panel  }
        TachPanel6  := TPanel.Create(Self);{ 6Panel  }  TachPanel7  := TPanel.Create(Self);{ 7Panel  }
        TachPanel8  := TPanel.Create(Self);{ 8Panel  }  TachPanel9  := TPanel.Create(Self);{ 9Panel  }
        TachPanel10 := TPanel.Create(Self);{ .Panel  }  TachPanel11 := TPanel.Create(Self);{ -Panel  }

        if Assigned(TachPanel0) then TachPanel0.Name := 'TachPanel0';  { 0Panel  }
        if Assigned(TachPanel1) then TachPanel1.Name := 'TachPanel1';  { 1Panel  }
        if Assigned(TachPanel2) then TachPanel2.Name := 'TachPanel2';  { 2Panel  }
        if Assigned(TachPanel3) then TachPanel3.Name := 'TachPanel3';  { 3Panel  }
        if Assigned(TachPanel4) then TachPanel4.Name := 'TachPanel4';  { 4Panel  }
        if Assigned(TachPanel5) then TachPanel5.Name := 'TachPanel5';  { 5Panel  }
        if Assigned(TachPanel6) then TachPanel6.Name := 'TachPanel6';  { 6Panel  }
        if Assigned(TachPanel7) then TachPanel7.Name := 'TachPanel7';  { 7Panel  }
        if Assigned(TachPanel8) then TachPanel8.Name := 'TachPanel8';  { 8Panel  }
        if Assigned(TachPanel9) then TachPanel9.Name := 'TachPanel9';  { 9Panel  }
        if Assigned(TachPanel10)then TachPanel10.Name := 'TachPanel10';{ .Panel  }
        if Assigned(TachPanel11)then TachPanel11.Name := 'TachPanel11';{ -Panel  }

        for RoopCnt := 0 to PanelCnt - 1 do begin
            TachPanel := FindComponent('TachPanel'+inttostr(RoopCnt));
            if TachPanel <> nil then begin
                InsertControl(TControl(TachPanel));
                TPanel(TachPanel).OnMouseDown := TachPanelMouseDown;
                TPanel(TachPanel).OnMouseUp   := TachPanelMouseUp  ;
                TPanel(TachPanel).Font.Assign(THNedit(AOwner).MouseBtnFont);
                TPanel(TachPanel).Color   := THNedit(AOwner).MouseBtnColor ;
                { 表示文字設定 }
                case RoopCnt of
                0..9:TPanel(TachPanel).caption := inttostr(RoopCnt);
                10:  TPanel(TachPanel).caption := '.';
                11:  TPanel(TachPanel).caption := '-';
                end;
                { Tag設定      }
                TPanel(TachPanel).Tag    := RoopCnt;
                { ｻｲｽﾞ設定     }
                TPanel(TachPanel).height := SetBtnSize;
                TPanel(TachPanel).Width  := SetBtnSize;
                // 文字フォントサイズ設定                                       2001.06.19 追加
                if THNedit(AOwner).MouseBtnAutoFontSize = True then begin
                  for i := 5 to 60 do begin
                    TPanel(TachPanel).Font.Size := i;
                    if Abs(TPanel(TachPanel).Font.Height) > (TPanel(TachPanel).ClientHeight*0.7) then begin
                      TPanel(TachPanel).Font.Size := i - 1;
                      break;
                    end;
                  end;
                end;
                { 位置設定     }
                case RoopCnt of
                7..9:TPanel(TachPanel).Top := 0;
                4..6:TPanel(TachPanel).Top := TPanel(TachPanel).height;
                1..3:TPanel(TachPanel).Top := TPanel(TachPanel).height * 2;
                0,10,11:TPanel(TachPanel).Top := TPanel(TachPanel).height * 3;
                end;
                case RoopCnt of
                0,1,4,7: TPanel(TachPanel).Left := 0;
                2,5,8,10:TPanel(TachPanel).Left := TPanel(TachPanel).Width;
                3,6,9,11:TPanel(TachPanel).Left := TPanel(TachPanel).Width * 2;
                end;
            end;
        end;

        visible := True;
        UPDATE;
    end;

    {
    ---------------------------------------------------------------------------
        TMouseTach  ﾃﾞｽﾄﾗｸﾀ
    ---------------------------------------------------------------------------
    }
    destructor  TMouseTach.Destroy;
    var
        RoopCnt   : integer   ;
        TachPanel : TComponent;
    begin

        for RoopCnt := PanelCnt - 1 Downto 0 do begin
            TachPanel := FindComponent('TachPanel'+inttostr(RoopCnt));
            if TachPanel <> nil then begin
                RemoveControl(TControl(TachPanel));
                TPanel(TachPanel).Free;
            end;
        end;
        TachPanel0 := nil; TachPanel1  := nil; TachPanel2  := nil;
        TachPanel3 := nil; TachPanel4  := nil; TachPanel5  := nil;
        TachPanel6 := nil; TachPanel7  := nil; TachPanel8  := nil;
        TachPanel9 := nil; TachPanel10 := nil; TachPanel11 := nil;

        TForm(Owner).RemoveControl(Self);

        { 派生元呼び出し }
        inherited Destroy;
    end;

    {
    ---------------------------------------------------------------------------
        TMouseTach    MouseDown
    ---------------------------------------------------------------------------
    }
    procedure TMouseTach.TachPanelMouseDown(Sender:TObject;Button:TMouseButton; shift:TShiftState; X, Y:Integer);
    var
        NeditControl : TComponent;
    begin
        if (HNeditName = '') or (Sender = nil) then exit;
//        NeditControl := TForm(Owner).FindComponent(HNeditName);       // 20000322 kubochi del
        NeditControl := TForm(Owner.Owner).FindComponent(HNeditName);   // 20000322 kubochi add
        if (Assigned(NeditControl)) then begin
            TPanel(Sender).Color := THNEdit(NeditControl).FMouseBtnDwnColor;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        TMouseTach    MouseUp
    ---------------------------------------------------------------------------
    }
    procedure TMouseTach.TachPanelMouseUp(Sender:TObject;Button:TMouseButton; shift:TShiftState; X, Y:Integer);
    var
        NeditControl : TComponent;
    begin
        if (HNeditName = '') or (Sender = nil) then exit;
//        NeditControl := TForm(Owner).FindComponent(HNeditName);       // 20000322 kubochi del
        NeditControl := TForm(Owner.Owner).FindComponent(HNeditName);   // 20000322 kubochi add
        if (Assigned(NeditControl)) then begin
            case TWinControl(Sender).tag of
            0..9 :PostMessage(THNEdit(NeditControl).handle,WM_KeyDown,48+TWinControl(Sender).tag,1);
            10,11:PostMessage(THNEdit(NeditControl).handle,WM_KeyDown,200-TWinControl(Sender).tag,1);
            end;
            TPanel(Sender).Color := THNEdit(NeditControl).MouseBtnColor ;
        end;
    end;

(* Add kubochi 1999-8-20 end   *)

    {
    ---------------------------------------------------------------------------
        TExtEdit    ｺﾝｽﾄﾗｸﾀ
    ---------------------------------------------------------------------------
    }
    constructor TExtEdit.Create;
    begin
        Column       := kDefColumn;
        ColValid     := cvCharCount;                                            // 2010.05.13 Add T.Sugawa
        FreeCursor   := False;
        AutoWidth    := False;
        Alignment    := alNone;
        EnableChars  := [ecWord, ecSpace, ecSign, ecKana, ecAlpha, ecNumSign, ecNum];
        CursorPos    := cpPrev;
    end;

    {
    ---------------------------------------------------------------------------
        TExtEdit    ｵﾌﾞｼﾞｪｸﾄのｺﾋﾟｰ
    ---------------------------------------------------------------------------
    }
    procedure TExtEdit.Assign(Source:TPersistent);
    begin
        if not (Source is TExtEdit) then
            inherited Assign(Source)
        else begin
            Column      := TExtEdit(Source).Column;
            FreeCursor  := TExtEdit(Source).FreeCursor;
            AutoWidth   := TExtEdit(Source).AutoWidth;
            Alignment   := TExtEdit(Source).Alignment;
            EnableChars := TExtEdit(Source).EnableChars;
            CursorPos   := TExtEdit(Source).CursorPos;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        TExtEdit    Alignmentﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
    procedure   TExtEdit.SetAlignment(Value:TAlignment);
    begin
        if FAlignment <> Value then begin
            FAlignment := Value;
            if Assigned(FOnChange) then FOnChange(Self);
        end;
    end;

    {
    ---------------------------------------------------------------------------
        TExtEdit    AutoWidthﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
    procedure   TExtEdit.SetAutoWidth(Value:Boolean);
    begin
        if FAutoWidth <> Value then begin
            FAutoWidth := Value;
            if Assigned(FOnChange) then FOnChange(Self);
        end;
    end;

    {
    ---------------------------------------------------------------------------
        TExtEdit    Columnﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
    procedure   TExtEdit.SetColumn(Value:Integer);
    begin
        if FColumn <> Value then begin
            FColumn := Value;
            if Assigned(FOnChange) then FOnChange(Self);
        end;
    end;

    {
    ---------------------------------------------------------------------------
        TExtEdit    ColValidﾌﾟﾛﾊﾟﾃｨの設定    2010.05.13 T.Sugawa
    ---------------------------------------------------------------------------
    }
    procedure   TExtEdit.SetColValid(Value:TColValid);
    begin
        if FColValid <> Value then begin
            FColValid := Value;
            if Assigned(FOnChange) then FOnChange(Self);
        end;
    end;

    {
    ---------------------------------------------------------------------------
        THNumEdit    ｺﾝｽﾄﾗｸﾀ
    ---------------------------------------------------------------------------
    }
    constructor THNumEdit.Create;
    begin
        ZeroSupp  := zsOff;
        ZeroDisp  := FALSE;
        KanmaEdt  := FALSE;
        DecLen    := 0;
        CalcInput := FALSE;
(* Add matsu 1997-09-17 THNumEdit.Minusﾌﾟﾛﾊﾟﾃｨ追加 DSL型自動判定 *)
        MinusSupp := FALSE;
    end;

    {
    ---------------------------------------------------------------------------
        THNumEdit    ｵﾌﾞｼﾞｪｸﾄのｺﾋﾟｰ
    ---------------------------------------------------------------------------
    }
    procedure THNumEdit.Assign(Source:TPersistent);
    begin
        if not (Source is THNumEdit) then
            inherited Assign(Source)
        else begin
            ZeroSupp  := THNumEdit(Source).ZeroSupp;
            ZeroDisp  := THNumEdit(Source).ZeroDisp;
            KanmaEdt  := THNumEdit(Source).KanmaEdt;
            DecLen    := THNumEdit(Source).DecLen;
            CalcInput := THNumEdit(Source).CalcInput;
(* Add matsu 1997-09-17 THNumEdit.Minusﾌﾟﾛﾊﾟﾃｨ追加 DSL型自動判定 *)
            MinusSupp := THNumEdit(Source).MinusSupp;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        THNumEdit    ZeroSuppﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
    procedure   THNumEdit.SetZeroSupp(Value:TZeroSupp);
    begin
        if FZeroSupp <> Value then begin
            FZeroSupp := Value;
            if Assigned(FOnChange) then FOnChange(Self);
        end;
    end;

    {
    ---------------------------------------------------------------------------
        THNumEdit    ZeroDispﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
    procedure   THNumEdit.SetZeroDisp(Value:Boolean);
    begin
        if FZeroDisp <> Value then begin
            FZeroDisp := Value;
            if Assigned(FOnChange) then FOnChange(Self);
        end;
    end;

    {
    ---------------------------------------------------------------------------
        THNumEdit    KanmaEdtﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
    procedure   THNumEdit.SetKanmaEdt(Value:Boolean);
    begin
        if FKanmaEdt <> Value then begin
            FKanmaEdt := Value;
            if Assigned(FOnChange) then FOnChange(Self);
        end;
    end;

    {
    ---------------------------------------------------------------------------
        THNumEdit    DecLenﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
    procedure   THNumEdit.SetDecLen(Value:Integer);
    begin
        if FDecLen <> Value then begin
            FDecLen := Value;
            if Assigned(FOnChange) then FOnChange(Self);
        end;
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  ｺﾝｽﾄﾗｸﾀ
    ---------------------------------------------------------------------------
    }
    constructor THEdit.Create(AOwner:TComponent);
    begin
        { 派生元呼び出し }
        inherited Create(AOwner);
        { ﾒﾝﾊﾞ初期化 }
        FVersion := HEditVersion;
        FExtEdit := TExtEdit.Create;
        FExtEdit.OnChange := ExtEditChanged;
        FActFgColor := Font.Color;
        FActBgColor := inherited Color;
        FExtCase := TExtCase.Create;
        FCheckEmpty  := False ;
//    {$IFDEF PHOENIX}
//        FCheckDD := TCheckDD.Create;
//    {$ENDIF}
{$IFDEF NEWCOLORCTL}
        NorBgColor := inherited Color ;
        NorFgColor := Font.Color ;
{$ELSE}
        //Add(1997.1.14)
        NorBgColor := Color ;
        NorFgColor := Font.Color ;
        inherited Color := Color ;
{$ENDIF}

        NowEditing := False;
        NowFontChanging := False;

        { ﾌｫﾝﾄは常に固定ﾋﾟｯﾁ }
        Font.Pitch := fpFixed;
        Font.Name  := 'ＭＳ ゴシック';
        Font.Size  := 11;

{$IFNDEF NEWCOLORCTL}
{$IFDEF UPDATE}
        Color := clWindow;
{$ENDIF}
{$ENDIF}
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  ﾃﾞｽﾄﾗｸﾀ
    ---------------------------------------------------------------------------
    }
    destructor  THEdit.Destroy;
    begin
        FExtEdit.Free;
        FExtCase.Free;
//    {$IFDEF PHOENIX}
//        FCheckDD.Free;
//    {$ENDIF}

        { 派生元呼び出し }
        inherited Destroy;
    end;

    {
    ---------------------------------------------------------------------------
        脱出可能かどうか調べる
    ---------------------------------------------------------------------------
    }
    {$WARNINGS OFF}
    function    THEdit.CanExit(Key:Word; Shift:TShiftState):Boolean;
    var
        CurPos:Integer;
    begin
        //空文字列の時の脱出許可のチェック
        if FCheckEmpty then begin
            if IsDataEmpty then begin
                Result := False ;
                exit;
            end;
        end;
        { 脱出要件ﾁｪｯｸ }
        if CheckExtCase(Key, Shift) = FALSE then
            Result := FALSE

        { ﾘﾀｰﾝｷｰ、ﾀﾌﾞｷｰ }
        else if (Key = VK_RETURN) or (Key = VK_TAB) then
            Result := (Shift = []) or (Shift = [ssShift])

        { 上下矢印ｷｰ }
        else if (Key = VK_UP) or (Key = VK_DOWN) then
            Result := TRUE

        { 左右矢印ｷｰ }
        else if (Key = VK_LEFT) or (Key = VK_RIGHT) then begin
            CurPos := LOWORD(SendMessage(Handle, EM_GETSEL, 0, 0));
            case Key of
            VK_LEFT:
                if SelLength > 0   then Result := FALSE
                else if CurPos = 0 then Result := TRUE
                else                    Result := FALSE;
            VK_RIGHT:
                if SelLength > 0            then Result := FALSE
                else if CurPos = GetTextLen then Result := TRUE
                else                             Result := FALSE;
            end;
        end

        { ﾏｳｽ }
        else if Key = 0 then
            Result := TRUE

        { その他のｷｰ }
        else
            Result := FALSE;
    end;
    {$WARNINGS ON}

    {
    ---------------------------------------------------------------------------
        ﾃﾞｰﾀの空をﾁｪｯｸする
    ---------------------------------------------------------------------------
    }
    function    THEdit.IsDataEmpty:Boolean;
    var
        Str:String;
    begin
        Str    := Text;
        Result := TRUE;
{                                                                               2001.03.02 変更
        while Length(Str) <> 0 do begin
            if Ord(Str[1]) = kByteSpace then
                Delete(Str, 1, 1)
            else if GetWordCharCode(Str[1] + Str[2]) = kWordSpace then
                Delete(Str, 1, 2)
            else begin
                Result := FALSE;
                Break;
            end;
        end;
}

// >>>>>>>>>>> 2009.08.11 Chg T.Sugawa >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//        while Length(Str) <> 0 do begin
//            if Ord(Str[1]) = kByteSpace then
//                Delete(Str, 1, 1)
//            else if (Length(Str) > 1) and (GetWordCharCode(Str[1] + Str[2]) = kWordSpace) then
//                Delete(Str, 1, 2)
//            else begin
//                Result := FALSE;
//                Break;
//            end;
//        end;

        while Length(Str) <> 0 do begin
            if (Str[1] = ' ') or (Str[1] = '　') then
                Delete(Str, 1, 1)
            else begin
                Result := FALSE;
                Break;
            end;
        end;
// <<<<<<<<<< 2009.08.11 Chg T.Sugawa <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    end;

//    {$IFDEF PHOENIX}
//    {
//    ---------------------------------------------------------------------------
//        ﾃﾞｰﾀの変更をﾁｪｯｸする
//   ---------------------------------------------------------------------------
//    }
//    function    THEdit.IsDataChanged:Boolean;
//    begin
//        Result := PrevText <> Text;
//    end;
//    {$ENDIF}

    {
    ---------------------------------------------------------------------------
        THEdit  入力字種のﾁｪｯｸ
    ---------------------------------------------------------------------------
    }
    function    THEdit.CheckCharactor(Key:Char; EnableChars:TEnableChars):Boolean;
    begin

// >>>>>>>>>>> 2009.08.11 Del T.Sugawa >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//(* Add matsu 1998-01-31 *)
//        if KanjiBegin then begin
//            KanjiBegin := FALSE;
//            Result := False;
//            Exit;
//        end;
//(* Add End *)
// <<<<<<<<<< 2009.08.11 Del T.Sugawa <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        if not (ecSpace in EnableChars) and (Key = ' ') then
            Result := False
        else if not (ecSign in EnableChars) and IsSign(Key) then
            Result := False
        else if not (ecKana in EnableChars) and IsKana(Key) then
            Result := False
        else if not (ecAlpha in EnableChars) and IsAlpha(Key) then
            Result := False
        else if not (ecNumSign in EnableChars) and IsNumSign(Key) then
            Result := False
        else if not (ecNum in EnableChars) and IsNum(Key) then
            Result := False
        else if not (ecWord in EnableChars) and IsKanji(Key) then begin
            //KanjiBegin := TRUE;                                               // 2009.08.11 Del
            Result := False;
        end
(* Add matsu 1998-01-31 漢字ｺｰﾄﾞが2回続く時があった｢旧｣｢九｣など *)
{
        else if KanjiBegin then begin
            KanjiBegin := FALSE;
            Result := False;
        end
}
(*  Add End *)
        else
            Result := TRUE;
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  表示桁数変更
    ---------------------------------------------------------------------------
    }
    procedure   THEdit.DisplayColChanging(ACol:Integer);
    begin
        ;
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  入力可能桁数変更
    ---------------------------------------------------------------------------
    }
    procedure   THEdit.ExtEditColChanging(ACol:Integer);
    begin
        MaxLength := ACol;
    end;


(* Add matsu 1997-04-18 *)
{$IFDEF NEWCOLORCTL}
    {
    ---------------------------------------------------------------------------
        THEdit  WMKeyDownｲﾍﾞﾝﾄ発生
    ---------------------------------------------------------------------------
    }
    procedure   THEdit.WMKeyDown(var Message:TWMKeyDown);
    begin
        inherited;

        if not (Self is THNedit) and ((Message.CharCode = VK_UP) or (Message.CharCode = VK_DOWN)) then
        begin
          if (AutoSelect) then
            SelectAll ;
        end;
    end;
{$ENDIF}
(* Add End *)

    {
    ---------------------------------------------------------------------------
        THEdit  OnKeyPressｲﾍﾞﾝﾄ発生
    ---------------------------------------------------------------------------
    }
    procedure THEdit.KeyPress(var Key:Char);
    var
      wkAStr: AnsiString;        // 2010.05.13 Add T.Sugawa
      wkWStr: String;            // 2010.05.13 Add T.Sugawa

    begin
        { 派生元呼び出し }
        inherited KeyPress(Key);

        { 無効文字棄却 }
        if (not CheckCharactor(Key, FExtEdit.EnableChars))
        and (not IsCntrl(Key)) then begin
            MessageBeep(0);
            Key := Chr(0);
        end;

// >>>>>>>>>>> 2010.05.13 Chg T.Sugawa >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//        { 桁数ﾁｪｯｸ }
//        if (Length(Text) = FExtEdit.Column) and (SelLength = 0) and not IsCntrl(Key) then
//            Key := Chr(0);

        { 桁数ﾁｪｯｸ }
        if FExtEdit.FColValid = cvSJisByteCount then
        begin
          // SJis換算バイト数制御
          wkWStr := Text;
          if SelLength > 0 then
            Delete(wkWStr, SelStart +1, SelLength);

          wkAStr := wkWStr + Key;

          if (Length(wkAStr) > FExtEdit.Column) and (SelLength = 0) and not IsCntrl(Key) then
              Key := Chr(0);
        end else begin
          // 文字数制御
          if (Length(Text) = FExtEdit.Column) and (SelLength = 0) and not IsCntrl(Key) then
              Key := Chr(0);
        end;
// <<<<<<<<<<< 2010.05.13 Chg T.Sugawa <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  OnEnterｲﾍﾞﾝﾄ発生
    ---------------------------------------------------------------------------
    }
    {$WARNINGS OFF}
{$IFDEF NEWCOLORCTL}
    procedure THEdit.DoEnter;
    var
        Str:String;
        CurPos:Integer;
        wnd: HWND; //matsu 980305
        imc: HIMC; //matsu 980305

    begin
        NowEditing := True;

        { 更新ｸﾘｱ }
        Modified := FALSE;

        { 通常色保存 }

        { ｱｸﾃｨﾌﾞｶﾗｰ設定 }
        NowFontChanging := TRUE;
        Font.Color      := FActFgColor;
        inherited Color := FActBgColor;
        NowFontChanging := FALSE;

        if not (Self is THNedit) then
        begin
          { 詰め方編集 }
          if (FExtEdit.Alignment <> alNone)
          and (FExtEdit.Column <= ClientWidthToColumn(Width)) then begin
              { 左右ｽﾍﾟｰｽｶｯﾄ }
              Str := Text;
              CutLeftSpc(Str);
              CutRightSpc(Str);
              Text := Str;
          end;
          { 初期ｶｰｿﾙ位置 }
          if (not AutoSelect) and (FExtEdit.CursorPos <> cpPrev) then begin
              case FExtEdit.CursorPos of
                cpTop: CurPos := 0;               { 先頭 }
                cpEnd: CurPos := Length(Text);    { 末尾 }
              end;
              SendMessage(Handle, EM_SETSEL, CurPos, CurPos);
          end;
         { AUTOSELECT復元 }
          if AutoSelect then
            SelectAll ;
        end;

        { IsDataChanged用ｵﾘｼﾞﾅﾙﾃﾞｰﾀ保存 }
//        PrevText := Text;

        NowEditing := False;

        { 派生元呼び出し }
        inherited DoEnter;

// Add matsu 1998-03-05 IMEが無効になる現象の対応
// (後日 DoExitで ImmDestroyContext追加修正が必要！！)
        wnd := Self.Handle;
        imc := ImmGetContext(wnd);

	if imc <> 0 then begin
	  if not ImmGetOpenStatus(imc) then begin
	    ImmSetOpenStatus(imc, False);
	  end;
	  ImmReleaseContext(wnd, imc);
	end else begin
	  imc := immCreateContext;
	  immAssociateContext(wnd, imc);
//	  dimc := imc;
        end;
//Add End

    end;
{$ELSE}
    procedure THEdit.DoEnter;
    var
        Str:String;
        CurPos:Integer;
    begin

        NowEditing := True;

        { 更新ｸﾘｱ }
        Modified := FALSE;

        { 通常色保存 }

(* Add matsu 1997-04-15 *)
//        NorBgColor := Color ;   //inherited Color;
        NorBgColor := inherited Color;
        NorFgColor := Font.Color;
(* Add End *)

        { ｱｸﾃｨﾌﾞｶﾗｰ設定 }
        NowFontChanging := TRUE;
        Font.Color      := FActFgColor;
        inherited Color := FActBgColor;
        NowFontChanging := FALSE;


        { 詰め方編集 }
        if (FExtEdit.Alignment <> alNone)
        and (FExtEdit.Column <= ClientWidthToColumn(Width)) then begin
            { 左右ｽﾍﾟｰｽｶｯﾄ }
            Str := Text;
            CutLeftSpc(Str);
            CutRightSpc(Str);
            Text := Str;

            { AUTOSELECT復元 }
            if AutoSelect then
                SelectAll;
        end;
        { 初期ｶｰｿﾙ位置 }
        if (not AutoSelect) and (FExtEdit.CursorPos <> cpPrev) then begin
            case FExtEdit.CursorPos of
              cpTop: CurPos := 0;               { 先頭 }
              cpEnd: CurPos := Length(Text);    { 末尾 }
            end;

    {$IFDEF WIN32}
            SendMessage(Handle, EM_SETSEL, CurPos, CurPos);
    {$ELSE}
            SendMessage(Handle, EM_SETSEL, 1, MAKELONG(CurPos, CurPos));
    {$ENDIF}

        end;

        NowEditing := False;

        { 派生元呼び出し }
        inherited DoEnter;

       //Add(1997.1.31)
       { AUTOSELECT復元 }
        if AutoSelect then
          SelectAll ;

//    {$IFDEF PHOENIX}
//        { IsDataChanged用ｵﾘｼﾞﾅﾙﾃﾞｰﾀ保存 }
//        PrevText := Text;
//    {$ENDIF}

    end;
{$ENDIF}
    {$WARNINGS ON}

    {
    ---------------------------------------------------------------------------
        THEdit  OnExitｲﾍﾞﾝﾄ発生
    ---------------------------------------------------------------------------
    }
    procedure THEdit.DoExit;
    var
        Str:String;
    begin

        NowEditing := True;

        { 詰め方編集 }
        if (MaxLength <> 0) and (FExtEdit.Alignment <> alNone)
        and (FExtEdit.Column <= ClientWidthToColumn(Width))  then begin
            Str := Text;
            AlignString(Str, MaxLength, FExtEdit.Alignment);
            Text := Str;
        end;

        { ﾉｰﾏﾙｶﾗｰ設定 }

{$IFDEF NEWCOLORCTL}
        NowFontChanging := TRUE;
        Font.Color      := NorFgColor;
        inherited Color := NorBgColor;
        NowFontChanging := FALSE;

{$ELSE}
        NowFontChanging := TRUE;
        //Add(1997.1.14)
        inherited Color := clWhite ;
        Color := NorBgColor ;
        Font.Color      := NorFgColor;
        NowFontChanging := FALSE;
{$ENDIF}

//Add matsu 1998-03-05 dimcが確保できた時点で機能させる
{
        if dimc <> 0 then begin
	  ImmDestroyContext(dimc);
	  dimc := 0;
	end;
}

        { 派生元呼び出し }
        inherited DoExit;

        NowEditing := False;
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  OnChangeｲﾍﾞﾝﾄ発生
    ---------------------------------------------------------------------------
    }
    procedure   THEdit.Change;
    begin
        if not NowEditing then
            inherited Change;
    end;

//    {$IFDEF PHOENIX}
//    {
//    ---------------------------------------------------------------------------
//        THEdit  Nameﾌﾟﾛﾊﾟﾃｨの設定
//    ---------------------------------------------------------------------------
//    }
//    procedure   THEdit.SetName(const NewName:TComponentName);
//    begin
//        { 派生元呼び出し }
//        inherited SetName(NewName);

//        { CheckDD、DD名の更新 }
//        CheckDD.DDName := NewName;
//    end;
//    {$ENDIF}

    {
    ---------------------------------------------------------------------------
        THEdit  FONT変更ﾒｯｾｰｼﾞへの対応
    ---------------------------------------------------------------------------
    }
    procedure   THEdit.CMFontChanged(var Message:TMessage);
    begin
        if not NowFontChanging then begin
            NowFontChanging := TRUE;

            { ﾌｫﾝﾄは常に固定ﾋﾟｯﾁ }
            Font.Pitch := fpFixed;

            { 自動ﾌｨｰﾙﾄﾞ幅 }
            if FExtEdit.AutoWidth then
                Width := ColumnToWidth(FExtEdit.Column);

//{$IFDEF NEWCOLORCTL}
//            if(csLoading in ComponentState)then
            NorFgColor := Font.Color;

//            if Focused then
//              Font.Color := ActFgColor
//            else
//              Font.Color := NorFgColor;
//{$ELSE}


            { ｱｸﾃｨﾌﾞ時のFont色設定に対応 }
            if TForm(Owner).ActiveControl = Self then begin
//                NorFgColor    := Font.Color;
                Font.Color    := ActFgColor;
            end;
//{$ENDIF}
            NowFontChanging := FALSE;
        end;

        { 派生元呼び出し }
        inherited;
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  WM_SIZEﾒｯｾｰｼﾞへの対応
    ---------------------------------------------------------------------------
    }
    procedure THEdit.WMSize(var Message:TWMSize);
    var
        DispCol:Integer;
    begin
        Inc(WMSizeCount);

        if WMSizeCount = 1 then begin
            { 表示桁数 }
            DispCol := ClientWidthToColumn(Message.Width);

            { 自動ﾌｨｰﾙﾄﾞ幅 }
            if ExtEdit.AutoWidth then
                FExtEdit.Column := DispCol;

            { 幅を桁境界にあわせる }
            DisplayColChanging(DispCol);
            //MaxLength := DispCol;

            //2010.05.13 Chg T.Sugawa @ｻｲｽﾞ調整は既存動作を保障(桁数によっては既存ﾚｲｱｳﾄが崩れた為.半角ｻｲｽﾞに合わせてｸﾞﾘｯﾌﾟ)
            //Width := ColumnToWidth(DispCol);
            Width := ColumnToWidth2(ClientWidthToColumn2(Message.Width, 1), 1);
        end;

        Dec(WMSizeCount);

        { 派生元呼び出し }
        Inherited;
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  FExtEditの取得
    ---------------------------------------------------------------------------
    }
    function THEdit.GetExtEdit:TExtEdit;
    begin
        GetExtEdit := FExtEdit;
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  FExtEditの設定
    ---------------------------------------------------------------------------
    }
    procedure THEdit.SetExtEdit(Value:TExtEdit);
    begin
        FExtEdit.Assign(Value);

        { 自動ﾌｨｰﾙﾄﾞ幅 }
        if FExtEdit.AutoWidth then
            Width := ColumnToWidth(FExtEdit.Column);
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  桁数からｵﾌﾞｼﾞｪｸﾄ幅を取得する   2010.05.13 Chg T.Sugawa
    ---------------------------------------------------------------------------
    }
    function THEdit.ColumnToWidth(c:Integer):Integer;
    begin
      Result := ColumnToWidth2(c, 0);
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  桁数からｵﾌﾞｼﾞｪｸﾄ幅を取得する
    ---------------------------------------------------------------------------
    }
    //function THEdit.ColumnToWidth(c:Integer):Integer;                         // 2010.05.13 Chg T.Sugawa @シグネチャ変更
    function THEdit.ColumnToWidth2(c, m:Integer):Integer;
    var
        DC:HDC;
        SaveFont:HFont;
        SysTM, TxtTM:TTEXTMETRIC;
    begin
        { FONTのTEXTMETRICS取得 }
        DC := GetDC(0);
        GetTextMetrics(DC, SysTM);
        SaveFont := SelectObject(DC, Font.Handle);
        GetTextMetrics(DC, TxtTM);
        SelectObject(DC, SaveFont);
        ReleaseDC(0, DC);


// >>>>>>>>>>> 2010.05.13 Chg T.Sugawa >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//        Result := c * TxtTM.tmAveCharWidth + GetSystemMetrics(SM_CXBORDER) * 4 + 4;

        if m = 1 then
        begin
          Result := c * TxtTM.tmAveCharWidth + GetSystemMetrics(SM_CXBORDER) * 4 + 4;
        end else begin
          if (ecWord in FExtEdit.FEnableChars) and
             not (Self is THNedit) and
             (FExtEdit.ColValid = cvCharCount) then
          begin
            Result := c * TxtTM.tmAveCharWidth * 2 + GetSystemMetrics(SM_CXBORDER) * 4 + 4;
          end else begin
            Result := c * TxtTM.tmAveCharWidth + GetSystemMetrics(SM_CXBORDER) * 4 + 4;
          end;
        end;
// <<<<<<<<<<< 2010.05.13 Chg T.Sugawa <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  ｸﾗｲｱﾝﾄ幅から桁数を取得する     2010.05.13 Chg T.Sugawa
    ---------------------------------------------------------------------------
    }
    function THEdit.ClientWidthToColumn(w:Integer):Integer;
    begin
      Result := ClientWidthToColumn2(w, 0);
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  ｸﾗｲｱﾝﾄ幅から桁数を取得する
    ---------------------------------------------------------------------------
    }
    //function THEdit.ClientWidthToColumn(w:Integer):Integer;                   // 2010.05.13 Chg T.Sugawa @シグネチャ変更
    function THEdit.ClientWidthToColumn2(w, m:Integer):Integer;
    var
        DC:HDC;
        SaveFont:HFont;
        SysTM, TxtTM:TTEXTMETRIC;
    begin
        { FONTのTEXTMETRICS取得 }
        DC := GetDC(0);
        GetTextMetrics(DC, SysTM);
        SaveFont := SelectObject(DC, Font.Handle);
        GetTextMetrics(DC, TxtTM);
        SelectObject(DC, SaveFont);
        ReleaseDC(0, DC);

// >>>>>>>>>>> 2010.05.13 Chg T.Sugawa >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//        Result := (w - 4) div TxtTM.tmAveCharWidth;

        if m = 1 then
        begin
          Result := (w - 4) div TxtTM.tmAveCharWidth;
        end else
        begin
          if (ecWord in FExtEdit.FEnableChars) and
             not (Self is THNedit) and
             (FExtEdit.ColValid = cvCharCount) then
          begin
            Result := (w - 4) div (TxtTM.tmAveCharWidth * 2);
          end else begin
            Result := (w - 4) div TxtTM.tmAveCharWidth;
          end;
        end;
// <<<<<<<<<<< 2010.05.13 Chg T.Sugawa <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  脱出要件のﾁｪｯｸ
    ---------------------------------------------------------------------------
    }
    function    THEdit.CheckExtCase(Key:Word; Shift:TShiftState):Boolean;
    begin
//        if IsDataEmpty and FExtCase.Necessary then                            2001.03.17 変更
//            Result := FALSE
//        else if (Key = VK_RETURN) and (Shift = []) and (not FExtCase.RetKey) then

//        if FExtCase.Necessary then begin
//          if IsDataEmpty  then
//            Result := FALSE;
        if IsDataEmpty and FExtCase.Necessary then
            Result := FALSE
        else if (Key = VK_RETURN) and (Shift = []) and (not FExtCase.RetKey) then
            Result := FALSE
        else if (Key = VK_RETURN) and (Shift = [ssShift]) and (not FExtCase.ShiftRetKey) then
            Result := FALSE
        else if (Key = VK_TAB) and (Shift = []) and (not FExtCase.TabKey) then
            Result := FALSE
        else if (Key = VK_TAB) and (Shift = [ssShift]) and (not FExtCase.ShiftTabKey) then
            Result := FALSE
        else if (Key = VK_UP) and (Shift = []) and (not FExtCase.UpKey) then
            Result := FALSE
        else if (Key = VK_DOWN) and (Shift = []) and (not FExtCase.DownKey) then
            Result := FALSE
        else if (Key = VK_LEFT) and (Shift = []) and (not FExtCase.LeftKey) then
            Result := FALSE
        else if (Key = VK_RIGHT) and (Shift = []) and (not FExtCase.RightKey) then
            Result := FALSE
        else
            Result := TRUE;
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  DataTextﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
{$IFDEF NEWCOLORCTL}
    procedure   THEdit.SetDataText(Value:TCaption);
    var
        Str:String;
        Focus: Boolean;
    begin
        Focus := Focused;
        if Focus then
          DoExit;
        { 詰め方編集 }
        if (MaxLength <> 0)
        and (FExtEdit.Alignment <> alNone)
        and (FExtEdit.Column <= ClientWidthToColumn(Width))  then begin
            Str := Value;
            AlignString(Str, MaxLength, FExtEdit.Alignment);
            Text := Str;
        end
        else
            Text := Value;
        if Focus then
          DoEnter;
    end;
{$ELSE}
    procedure   THEdit.SetDataText(Value:TCaption);
    var
        Str:String;
        Focus: Boolean;
    begin
      Focus := Focused;
      if Focus then
        DoExit;
        { 詰め方編集 }
        if (MaxLength <> 0)
        and (FExtEdit.Alignment <> alNone)
        and (FExtEdit.Column <= ClientWidthToColumn(Width))  then begin
            Str := Value;
            AlignString(Str, MaxLength, FExtEdit.Alignment);
            Text := Str;
        end
        else
            Text := Value;

        if Focus then
          DoEnter;
    end;
{$ENDIF}
    {
    ---------------------------------------------------------------------------
        THEdit  DataTextﾌﾟﾛﾊﾟﾃｨの取得
    ---------------------------------------------------------------------------
    }
    function    THEdit.GetDataText:TCaption;
    var
        Str:String;
    begin
        if (FExtEdit.Alignment <> alNone)
        and (FExtEdit.Column <= ClientWidthToColumn(Width))  then begin
            { 左右ｽﾍﾟｰｽｶｯﾄ }
            Str := Text;
            CutLeftSpc(Str);
            CutRightSpc(Str);
            Result := Str;
        end
        else
            Result := Text;
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  ExtCaseﾌﾟﾛﾊﾟﾃｨの取得
    ---------------------------------------------------------------------------
    }
    function    THEdit.GetExtCase:TExtCase;
    begin
        Result := FExtCase;
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  ExtCaseﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
    procedure   THEdit.SetExtCase(Value:TExtCase);
    begin
        FExtCase.Assign(Value);
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  ActFgColorﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
    procedure   THEdit.SetActFgColor(Value:TColor);
    begin
        if Value <> FActFgColor then begin
            FActFgColor := Value;

            if TForm(Owner).ActiveControl = Self then begin
                NowFontChanging := TRUE;
                Font.Color      := Value;
                NowFontChanging := FALSE;
            end;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  ActBgColorﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
    procedure   THEdit.SetActBgColor(Value:TColor);
    begin
        if Value <> FActBgColor then begin
            FActBgColor := Value;

            if TForm(Owner).ActiveControl = Self then begin
                NowFontChanging := TRUE;
                inherited Color := Value;
                NowFontChanging := FALSE;
            end;
        end;
    end;

    function    THEdit.GetColor:TColor;
    begin
{$IFDEF NEWCOLORCTL}
        Result := NorBgColor;
{$ELSE}
        if TForm(Owner).ActiveControl = Self then
            Result := NorBgColor
        else
            Result := inherited Color;
{$ENDIF}
    end;

    procedure   THEdit.SetColor(Value:TColor);
    begin
{$IFDEF NEWCOLORCTL}
        if (NorBgColor <> Value) then
        begin
          NorBgColor := Value;
          if not Focused then inherited Color := Value;
        end;
{$ELSE}
        if TForm(Owner).ActiveControl = Self then
            NorBgColor := Value
        else
            inherited Color := Value;
{$ENDIF}
    end;

{$IFDEF NEWCOLORCTL}
    procedure THEdit.SetFontColor(Value: TColor);
    begin
      if (NorFgColor <> Value) then
      begin
        NorFgColor := Value;
        if not Focused then
        begin
          NowFontChanging := TRUE;
          Font.Color := NorFgColor;
          NowFontChanging := FALSE;
        end;
      end;
    end;
{$ENDIF}

//    {$IFDEF PHOENIX}
//    {
//    ---------------------------------------------------------------------------
//        THEdit  CheckDDﾌﾟﾛﾊﾟﾃｨの取得
//    ---------------------------------------------------------------------------
//    }
//    function    THEdit.GetCheckDD:TCheckDD;
//    begin
//        Result := FCheckDD;
//    end;
//    {$ENDIF}

//    {$IFDEF PHOENIX}
//    {
//    ---------------------------------------------------------------------------
//        TXEdit  CheckDDﾌﾟﾛﾊﾟﾃｨの設定
//    ---------------------------------------------------------------------------
//    }
//    procedure   TXEdit.SetCheckDD(Value:TCheckDD);
//    begin
//        FCheckDD.Assign(Value);
//    end;
//    {$ENDIF]

    {
    ---------------------------------------------------------------------------
        THEdit  ExtEditﾌﾟﾛﾊﾟﾃｨの変更
    ---------------------------------------------------------------------------
    }
    procedure   THEdit.ExtEditChanged(Sender:TObject);
    begin
        { 自動ﾌｨｰﾙﾄﾞ幅 }
        if FExtEdit.AutoWidth then
            Width := ColumnToWidth(FExtEdit.Column);
        ExtEditColChanging(FExtEdit.Column);
    end;
    {
    ---------------------------------------------------------------------------
        THEdit CheckEmptyプロパティの変更
    ---------------------------------------------------------------------------
    }
    procedure  THEdit.SetCheckEmpty( Permit :Boolean );
    begin
      if FCheckEmpty <> Permit then begin
        FCheckEmpty := Permit;
      end;
    end;

    {
    ---------------------------------------------------------------------------
        THEdit  WM_PASTEｲﾍﾞﾝﾄ処理     2010.05.13 Add by T.Sugawa
    ---------------------------------------------------------------------------
    }
    procedure THEdit.WMPaste(var Message: TMessage);
    var
      wkWStr, pasteStr: String;
      wkAStr: AnsiString;
      wkLen, idx: Integer;
      ClipText: Array of WideChar;

    begin
      // クリップボート内テキスト取得
      SetLength(ClipText, Self.FExtEdit.Column + 1);
      Clipboard.GetTextBuf(@ClipText[0], Length(ClipText));

      case FExtEdit.FColValid of
        cvCharCount:
          begin
            // 貼付け可能文字数計算
            wkWStr := Text;
            if SelLength > 0 then
            begin
              Delete(wkWStr, SelStart + 1, SelLength);
            end;
            wkLen := FExtEdit.Column - Length(wkWStr);

            pasteStr := '';
            for idx := 0 to Length(ClipText) - 1 do
            begin
              if ClipText[idx] = #0 then break;

              // 文字チェック
              if CheckCharactor(ClipText[idx], FExtEdit.EnableChars) then
              begin
                Dec(wkLen, Length(ClipText[idx]));
                if wkLen < 0 then
                begin
                  break;
                end else begin
                  pasteStr := pasteStr + ClipText[idx];
                end;
              end;
            end;

            // 貼付け後の文字列を生成
            if Length(pasteStr) > 0 then
            begin
              Insert(pasteStr, wkWStr, Self.SelStart + 1);
              wkLen := SelStart + Length(pasteStr);
              Text := wkWStr;
              SelStart := wkLen;
            end;
          end;

        cvSJisByteCount:
          begin
            // 貼付け可能バイト数計算
            wkWStr := Text;
            if SelLength > 0 then
            begin
              Delete(wkWStr, SelStart + 1, SelLength);
              wkAStr := wkWStr;
            end else begin
              wkAStr := Text;
            end;
            wkLen := FExtEdit.Column - Length(wkAStr);

            pasteStr := '';
            for idx := 0 to Length(ClipText) - 1 do
            begin
              if ClipText[idx] = #0 then break;

              // 文字チェック
              if CheckCharactor(ClipText[idx], FExtEdit.EnableChars) then
              begin
                wkAStr := ClipText[idx];
                Dec(wkLen, Length(wkAStr));
                if wkLen < 0 then
                begin
                  break;
                end else begin
                  pasteStr := pasteStr + ClipText[idx];
                end;
              end;
            end;

            // 貼付け後の文字列を生成
            if Length(pasteStr) > 0 then
            begin
              Insert(pasteStr, wkWStr, Self.SelStart + 1);
              wkLen := SelStart + Length(pasteStr);
              Text := wkWStr;
              SelStart := wkLen;
            end;
          end;
        else
          begin
            inherited;
          end;
      end;
    end;

    {
    ---------------------------------------------------------------------------
        THNedit  ｺﾝｽﾄﾗｸﾀ
    ---------------------------------------------------------------------------
    }
    constructor THNedit.Create(AOwner:TComponent);
    begin
        { 派生元呼び出し }
        inherited Create(AOwner);
        FVersion := HNeditVersion;
          { THNumEdit生成、初期化 }
        FHNumEdit := THNumEdit.Create;
        FHNumEdit.OnChange := NumEditChanged;

        { THEdit設定 }
        FExtEdit.fAlignment := alRight;

(* Add 1999-8-20 kubochi begin *)
        MTach    := nil;
        CalcForm := nil;                                                // 20000322 add kubochi
        { ﾌｫﾝﾄは常に固定ﾋﾟｯﾁ }
//        FMouseBtnSize := 20;
        FMouseBtnSize := ctDEF_BTN_SIZE;
        FMouseBtnFont := TFont.Create;
        FMouseBtnFont.Assign(Font);
        FMouseBtnColor:= clBtnFace;
        FMouseBtnDwnColor := clYellow;
(* Add 1999-8-20 kubochi end   *)
        FMouseBtnAutoFontSize := True;                                          // 2001.06.19 追加
    end;

    {
    ---------------------------------------------------------------------------
        THNedit  ﾃﾞｽﾄﾗｸﾀ        1999-8-20 kubochi Add
    ---------------------------------------------------------------------------
    }
    destructor  THNedit.Destroy;
    begin
        FMouseBtnFont.Free;

        if MTach    <> nil then begin
            MTach.Free;
            MTach := nil;
        end;
        if CalcForm <> nil then begin
            CalcForm.Release;
            CalcForm := nil;
        end;

        { 派生元呼び出し }
        inherited Destroy;
    end;

    {
    ---------------------------------------------------------------------------
        脱出可能かどうか調べる
    ---------------------------------------------------------------------------
    }
    {$WARNINGS OFF}
    function    THNedit.CanExit(Key:Word; Shift:TShiftState):Boolean;
    var
        CurPos:Integer;
    begin

        //空文字列の時の脱出許可のチェック
        if FCheckEmpty then begin
            if IsDataEmpty then begin
                Result := False ;
                exit;
            end;
        end;
        { 脱出要件ﾁｪｯｸ }
        if CheckExtCase(Key, Shift) = FALSE then
            Result := FALSE

        { TAB, ﾘﾀｰﾝｷｰ }
        else if (Key = VK_RETURN) or (Key = VK_TAB) then
            Result := (Shift = []) or (Shift = [ssShift])

        { 上下矢印ｷｰ }
        else if (Key = VK_UP) or (Key = VK_DOWN) then
            Result := TRUE

        { 左右矢印ｷｰ }
        else if (Key = VK_LEFT) or (Key = VK_RIGHT) then begin
            if FHNumEdit.CalcInput then Result := TRUE
            else begin
                CurPos := LOWORD(SendMessage(Handle, EM_GETSEL, 0, 0));
                case Key of
                VK_LEFT:
                    if SelLength > 0   then Result := FALSE
                    else if CurPos = 0 then Result := TRUE
                    else                    Result := FALSE;
                VK_RIGHT:
                    if SelLength > 0            then Result := FALSE
                    else if CurPos = GetTextLen then Result := TRUE
                    else                             Result := FALSE;
                end;
            end;
        end

        { ﾏｳｽ }
        else if Key = 0 then
            Result := TRUE

        { その他のｷｰ }
        else
            Result := FALSE;
    end;
    {$WARNINGS ON}

    {
    ---------------------------------------------------------------------------
        THNedit  入力字種のﾁｪｯｸ
    ---------------------------------------------------------------------------
    }
    function THNedit.CheckCharactor(Key:Char; EnableChars:TEnableChars):Boolean;
    begin
        Result := TRUE;
    end;

(* Add matsu 1997-09-29 *)
    {
    ---------------------------------------------------------------------------
        THNedit  表示桁数変更
    ---------------------------------------------------------------------------
    }
    procedure   THNedit.Loaded;
    begin
        MaxLength := ClientWidthToColumn(Width);
    end;
(* Add End *)

    {
    ---------------------------------------------------------------------------
        THNedit  表示桁数変更
    ---------------------------------------------------------------------------
    }
    procedure   THNedit.DisplayColChanging(ACol:Integer);
    begin
        MaxLength := ACol;
    end;

    {
    ---------------------------------------------------------------------------
        THNedit  入力可能桁数変更
    ---------------------------------------------------------------------------
    }
    procedure   THNedit.ExtEditColChanging(ACol:Integer);
    begin
        ;
    end;
    {
    ---------------------------------------------------------------------------
        THNedit  DataTextﾌﾟﾛﾊﾟﾃｨの設定
    ---------------------------------------------------------------------------
    }
{$IFNDEF NEWCOLORCTL}
    procedure   THNedit.SetDataText(Value:TCaption);
    var
        nMaxSize : integer;
        Str:String;
    begin
        Str := Value;

        if (Focused) then
        begin
          { ｶﾝﾏ除去 }
          if HNumEdit.KanmaEdt then
            DelStrChr(Str, ',');

          CutRightSpc(Str);
          CutLeftSpc(Str);

          // ゼロサプレスするの時は、先行ゼロ列を削除                           2001.04.12 追加
          if FHNumEdit.FZeroSupp = zsOn then begin
            nMaxSize := Length(Str);
            if (nMaxSize > 1) and (Str[1] ='0') then begin
              while (True) do begin
                Delete(Str, 1, 1);
                if (Length(Str) = 1) or (Str[1] <> '0') then
                  break;
              end;
            end;
          end;

          { 電卓入力処理}
          if FHNumEdit.CalcInput then
            AlignString(Str, MaxLength, alRight);

          {編集用のﾃｷｽﾄを設定}
          Text := Str;

          if (AutoSelect or FHNumEdit.CalcInput) then
            SelectAll ;
        end
        else
        begin
          { 数値編集 }
          if Length(Str) <> 0 then begin
              if Str = '-' then Str := ''
              else         EditNumStr(Str);
          end;

          { 詰め方編集 }
          if (MaxLength <> 0) and (FExtEdit.Alignment <> alNone) then
              AlignString(Str, MaxLength, FExtEdit.Alignment);

          Text := Str;

          if Showing then begin
    {$IFDEF WIN32}
            if not AutoSelect or (Length(Str) = 0) then
                SendMessage(Handle, EM_SETSEL, MaxLength, MaxLength)
            else
                SendMessage(Handle, EM_SETSEL, MaxLength - Length(Str), MaxLength);
    {$ELSE}
            if not AutoSelect or (Length(Str) = 0) then
                SendMessage(Handle, EM_SETSEL, 1, MAKELONG(MaxLength, MaxLength))
            else
                SendMessage(Handle, EM_SETSEL, 1, MAKELONG(MaxLength - Length(Str), MaxLength));
    {$ENDIF}
          end;
        end;
    end;
{$ELSE}
    procedure   THNedit.SetDataText(Value:TCaption);
    var
        nMaxSize : integer;
        Str:String;
        Focus :boolean;
    begin
        Focus :=Focused ;
        Str := Value;

        if Focus then
          DoExit;

        // ゼロサプレスするの時は、先行ゼロ列を削除                             2001.04.12 追加
        if FHNumEdit.FZeroSupp = zsOn then begin
          nMaxSize := Length(Str);
          if (nMaxSize > 1) and (Str[1] ='0') then begin
            while (True) do begin
              Delete(Str, 1, 1);
              if (Length(Str) = 1) or (Str[1] <> '0') then
                break;
            end;
          end;
        end;

        { 数値編集 }
        if Length(Str) <> 0 then begin
            if Str = '-' then Str := ''
            else         EditNumStr(Str);
        end;

        { 詰め方編集 }
        if (MaxLength <> 0) and (FExtEdit.Alignment <> alNone) then
            AlignString(Str, MaxLength, FExtEdit.Alignment);

        Text := Str;

        if Showing then begin
    {$IFDEF WIN32}
            if not AutoSelect or (Length(Str) = 0) then
                SendMessage(Handle, EM_SETSEL, MaxLength, MaxLength)
            else
                SendMessage(Handle, EM_SETSEL, MaxLength - Length(Str), MaxLength);
    {$ELSE}
            if not AutoSelect or (Length(Str) = 0) then
                SendMessage(Handle, EM_SETSEL, 1, MAKELONG(MaxLength, MaxLength))
            else
                SendMessage(Handle, EM_SETSEL, 1, MAKELONG(MaxLength - Length(Str), MaxLength));
    {$ENDIF}
        end;

        if Focus then
          DoEnter;
    end;
{$ENDIF}
    {
    ---------------------------------------------------------------------------
        THNedit  DataTextﾌﾟﾛﾊﾟﾃｨの取得
    ---------------------------------------------------------------------------
    }
    function    THNedit.GetDataText:TCaption;
    var
        Str:String;
    begin
        { 派生元呼び出し }
        Str := inherited GetDataText;

        { ｶﾝﾏ除去 }
        if NumEdit.KanmaEdt then
            DelStrChr(Str, ',');

        Result := Str;
    end;

    {
    ---------------------------------------------------------------------------
        THNedit  OnKeyPressｲﾍﾞﾝﾄ発生
    ---------------------------------------------------------------------------
    }
    procedure THNedit.KeyPress(var Key:Char);
    var
        Str:String;
        NSA:THNumStrAttr;
        Ok:Boolean;

        DsHiLength            //1997-10-29 DSL入力可能整数桁数
        , FdHiLength: Integer;//           ﾌｨｰﾙﾄﾞ入力可能整数桁数
//        FormDsl: TComponent;  //           画面DSLを取得格納
//        FieldInfo: FLDINFO;   //           DSL項目属性レコード型
//        tmpName: string;
        nDelPos:integer;                                                        // 2003.08.18 追加
        nDelLine:integer;                                                       // 2003.08.18 追加
        nPeriod:integer;                                                        // 2003.08.18 追加
    begin

(* Add matsu 1997-09-06 *)
      if (ReadOnly) then begin
        Key := #0;
        Exit;
      end;
(* Add End *)

    {$IFDEF WIN32}
        if Assigned(OnKeyPress) then
            OnKeyPress(Self, Key);
    {$ENDIF}

       // 小数点指定が有る場合、小数点が消えると有効桁を超えて入力できてしまう  // 2003.08.18 追加
       // 為、特定条件で小数点を消せないように修正
       if (FHNumEdit.DecLen > 0) and (Key = Chr($8)) then begin
         nDelPos  :=LOWORD(SendMessage(Handle, EM_GETSEL, 0, 0));
         nDelLine := (Length(Text) - nDelPos) + 1;
         nPeriod := FHNumEdit.DecLen + 1;
         if (nDelLine = nPeriod) and (Copy(Text, nDelPos, 1) = '.') then begin
           Key := #$00;
           Exit;
         end;
       end;

        FullInputed := False;

        { 制御文字以外をﾁｪｯｸ }
        if not IsCntrl(Key) then begin
            { 現在の文字入力後の文字列生成 }
            if SelLength > 0 then
                Str := Key
            else begin
                Str := Text;

// 1997-10-29 matsu EM_GETSELを Wordで変換し、EDIT内でのカレット位置を取得、入力文字列作成
//                Insert(Key, Str, SendMessage(Handle, EM_GETSEL, 0, 0) + 1);
                Insert(Key, Str, Word(SendMessage(Handle, EM_GETSEL, 0, 0)) + 1);

                { 電卓入力用 }
                if FHNumEdit.CalcInput then
                    CutLeftSpc(Str);
            end;

            //フィールド桁数以上の文字数は入力出来ない
            if Length(Str) = FExtEdit.Column then
                FullInputed := True;

(* Add matsu 1997-10-29 整数部入力可能文字数設定 *)
            //DSLが無い時、フィールドが無い時にはフィールド桁から計算
            DsHiLength := FExtEdit.Column - FHNumEdit.DecLen;
            if FHNumEdit.DecLen > 0 then Dec(DsHiLength);//小数点分の減

//            FormDsl := GetCurrDataControl(Self);     //画面のDslを取得
//            if Assigned(FormDsl) and (FormDsl is TDataControl) then begin
//
//              tmpName := Name;
//              //XTable対応
//              if (IsXTableControl(Self) or IsXRepeatControl(Self)) then begin
//                tmpName := Copy(tmpName,0,Pos('_',tmpName)-1);
//              end;
//
//              //項目情報取得
//              if DsGetFieldInfo(TDataControl(FormDsl).Handle,PChar(tmpName),FieldInfo) then
//                //DSLからの整数部入力文字数を設定
//                DsHiLength := FieldInfo.nDspLen - FieldInfo.nSyoLen;
//            end;

            //フィールド桁からの整数部入力文字数を設定
            FdHiLength := FExtEdit.Column - FHNumEdit.DecLen;
            if FHNumEdit.DecLen > 0 then Dec(FdHiLength);//小数点分の減
//            if not FHNumEdit.FMinusSupp then Dec(HiLength);//符号分の減
//          符号分はDSL桁数に含まれなくなった為、DSL桁数までは入力可とする
//          従来もDSL桁数までは入力可であった
(* Add End *)

            { 数値文字列のﾁｪｯｸ }
            if Str = ''                                   then Ok := TRUE
(* Add matsu 1997-09-17 THNumEdit.Minusﾌﾟﾛﾊﾟﾃｨ追加 入力文字抑制 *)
            else if FHNumEdit.MinusSupp and (Key = '-')   then Ok := FALSE
(* Add End *)
            else if Str = '-'                             then Ok := TRUE
            else if GetNumStrAttr(Str, NSA) = FALSE       then Ok := FALSE
            else if (FHNumEdit.DecLen = 0) and (Key = '.')then Ok := FALSE
            else if NSA.LoColumn > FHNumEdit.DecLen       then Ok := FALSE
            else if EditNumStr(Str) > FExtEdit.Column     then Ok := FALSE
//Add 1997-10-29 設定桁数以上の入力を抑制
            else if (NSA.HiColumn > FdHiLength) or (NSA.HiColumn > DsHiLength)
//            else if (NSA.HiColumn > FdHiLength)
//          10-29現在検討中 DSLからの桁数判定を保留 → 一転ＧＯ
                                                          then Ok := FALSE

            else                                               Ok := TRUE;


            {無効文字棄却 }
            if not Ok then begin
                MessageBeep(0);
                Key := #$00;
            end;
        end;

        { 電卓入力処理}
        if FHNumEdit.CalcInput and (Key <> #$00) and
        (not IsCntrl(Key) or (Key = kBackSpace)) then begin
            { BSの処理 }
            if Key = kBackSpace then begin
                Str := Text;
                Delete(Str, Length(Str), 1);
                CutLeftSpc(Str);
            end

            { 通常時ﾃﾞｰﾀ入力 }
            else if SelLength = 0 then begin
                Str := Text + Key;
                CutLeftSpc(Str);
            end

            { 選択時ﾃﾞｰﾀ入力 }
            else
                Str := Key;

            { 右詰め }
            AlignString(Str, MaxLength, alRight);
            Text := Str;

            { ｶｰｿﾙは末尾 }
    {$IFDEF WIN32}
            SendMessage(Handle, EM_SETSEL, MaxLength, MaxLength);
    {$ELSE}
            SendMessage(Handle, EM_SETSEL, 1, MAKELONG(MaxLength, MaxLength));
    {$ENDIF}
            Key := #$00;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        THNedit  OnEnterｲﾍﾞﾝﾄ発生
    ---------------------------------------------------------------------------
    }
    procedure THNedit.DoEnter;
    var
        Str:String;
    begin
        NowEditing := True;

{$IFDEF NEWCOLORCTL}

        {現在のﾃｷｽﾄを取得}
        Str := Text;

        { ｶﾝﾏ除去 }
        if NumEdit.KanmaEdt then
          DelStrChr(Str, ',');

        CutRightSpc(Str);
        CutLeftSpc(Str);

        { 電卓入力処理}
        if FHNumEdit.CalcInput then
          AlignString(Str, MaxLength, alRight);

        {編集用のﾃｷｽﾄを設定}
        Text := Str;

        if (AutoSelect or FHNumEdit.CalcInput) then
          SelectAll ;

        { 派生元呼び出し }
        inherited DoEnter;

{$ELSE}
        { ｶﾝﾏ除去 }
        if HNumEdit.KanmaEdt then begin
            Str := Text;
            DelStrChr(Str, ',');
            Text := Str;
        end;

        NowEditing := False;


        { 派生元呼び出し }
        inherited DoEnter;

        NowEditing := True;

        { 電卓入力処理}
        if FHNumEdit.CalcInput then begin
            { 右詰め }
            Str := Text;
            AlignString(Str, MaxLength, alRight);
            Text := Str;

            { AUTOSELECT復元、ｶｰｿﾙは末尾に }
            CutLeftSpc(Str);
    {$IFDEF WIN32}
            if not AutoSelect or (Length(Str) = 0) then
                SendMessage(Handle, EM_SETSEL, MaxLength, MaxLength)
            else
                SendMessage(Handle, EM_SETSEL, MaxLength - Length(Str), MaxLength);
    {$ELSE}
            if not AutoSelect or (Length(Str) = 0) then
                SendMessage(Handle, EM_SETSEL, 1, MAKELONG(MaxLength, MaxLength))
            else
                SendMessage(Handle, EM_SETSEL, 1, MAKELONG(MaxLength - Length(Str), MaxLength));
    {$ENDIF}
        end;

        NowEditing := False;

       //Add(1997.1.31)
       { AUTOSELECT復元 }
        if AutoSelect then
          SelectAll ;
//    {$IFDEF PHOENIX}
//        { IsDataChanged用ｵﾘｼﾞﾅﾙﾃﾞｰﾀ保存 }
//        PrevText := Text;
//    {$ENDIF}

{$ENDIF}

    end;

    {
    ---------------------------------------------------------------------------
        THNedit  OnExitｲﾍﾞﾝﾄ発生
    ---------------------------------------------------------------------------
    }
    procedure THNedit.DoExit;
    var
        //i:        integer;                                                    // 2009.08.11 DEL @未使用
        nMaxSize: integer;
        Str:String;
    begin
        NowEditing := True;

        Str := Text;

        // ゼロサプレスするの時は、先行ゼロ列を削除                             2001.04.12 追加
        if FHNumEdit.FZeroSupp = zsOn then begin
          nMaxSize := Length(Str);
          if (nMaxSize > 1) and (Str[1] ='0') then begin
            while (True) do begin
              Delete(Str, 1, 1);
              if (Length(Str) = 1) or (Str[1] <> '0') then
                break;
            end;
          end;
        end;

        { 電卓入力対応 }
        if FHNumEdit.CalcInput then
            CutLeftSpc(Str);

        { 数値編集 }
        if Length(Str) <> 0 then begin
            if Str = '-' then Str := ''
            else              EditNumStr(Str);
        end;

        Text := Str;

(* Add 1999-8-20 kubochi begin *)
        if MTach <> nil then begin
            MTach.Free;
            MTach := nil;
        end;
        if CalcForm <> nil then begin                                   // 20000322 add kubochi begin
            CalcForm.Release;
            CalcForm := nil;
        end;                                                            // 20000322 add kubochi end
(* Add 1999-8-20 kubochi end   *)

        { 派生元呼び出し }
        inherited DoExit;
    end;

    {
    ---------------------------------------------------------------------------
        THNedit  OnMouseDownｲﾍﾞﾝﾄ発生
    ---------------------------------------------------------------------------
    }
    procedure   THNedit.MouseDown(Button:TMouseButton; shift:TShiftState; X, Y:Integer);
    begin
        { 派生元呼び出し }
        inherited MouseDown(Button, shift, X, Y);

       { 電卓入力時ｶｰｿﾙ位置 }
        if FHNumEdit.CalcInput then
    {$IFDEF WIN32}
            SendMessage(Handle, EM_SETSEL, MaxLength, MaxLength);
    {$ELSE}
            SendMessage(Handle, EM_SETSEL, 1, MAKELONG(MaxLength, MaxLength));
    {$ENDIF}
    end;


    {
    ---------------------------------------------------------------------------
        THNedit  WM_KEYDOWNｲﾍﾞﾝﾄ処理
    ---------------------------------------------------------------------------
    }
    procedure THNedit.WMKeyDown(var Message:TWMKeyDown);
    var
        Str:String;
        nDelPos:integer;                                                        // 2003.08.18 追加
        nDelLine:integer;                                                       // 2003.08.18 追加
        nPeriod:integer;                                                        // 2003.08.18 追加
    begin
        FullInputed := False;

(* Add 1999-8-20 kubochi begin *)
//        if (Message.CharCode = VK_ESCAPE)                             // 20000322 kubochi del start
//        and(MTach <> nil) then begin
//            MTach.Free;
//            MTach := nil;
//        end;                                                          // 20000322 kubochi del end
(* Add 1999-8-20 kubochi end   *)


       // 小数点指定が有る場合、小数点が消えると有効桁を超えて入力できてしまう  // 2003.08.18 追加
       // 為、特定条件で小数点を消せないように修正
       if (FHNumEdit.DecLen > 0) and (Message.CharCode = VK_DELETE) then begin
         nDelPos  :=LOWORD(SendMessage(Handle, EM_GETSEL, 0, 0));
         nDelLine := Length(Text) - nDelPos;
         nPeriod := FHNumEdit.DecLen + 1;
         if (nDelLine = nPeriod) and (Copy(Text, nDelPos+1, 1) = '.') then begin
           Exit;
         end;
       end;


{$IFDEF NEWCOLORCTL}
        if (Message.CharCode = VK_UP) or (Message.CharCode = VK_DOWN) then
        begin
          Inherited;
          if (AutoSelect or FHNumEdit.CalcInput) then
            SelectAll ;
          Exit;
        end;
{$ENDIF}

        { 電卓入力DEL処理 }
(* Add matsu 1997-09-06 *)
//        if FHNumEdit.CalcInput then begin
        if (FHNumEdit.CalcInput) and (not ReadOnly) then begin
(* Add End *)
            if Message.CharCode = VK_DELETE then begin
                { ｸﾘｱ }
                Str := '';
                AlignString(Str, MaxLength, alRight);
                Text := Str;
                Message.CharCode := $0000;

                { ｶｰｿﾙは末尾に }
    {$IFDEF WIN32}
                SendMessage(Handle, EM_SETSEL, MaxLength, MaxLength);
    {$ELSE}
                SendMessage(Handle, EM_SETSEL, 1, MAKELONG(MaxLength, MaxLength));
    {$ENDIF}
            end
            else if (Message.CharCode = VK_LEFT) or (Message.CharCode = VK_RIGHT)
            or      (Message.CharCode = VK_UP)   or (Message.CharCode = VK_DOWN) then begin
                { 派生元呼出し }
                Inherited;

                { ｶｰｿﾙは末尾に }
    {$IFDEF WIN32}
                SendMessage(Handle, EM_SETSEL, MaxLength, MaxLength);
    {$ELSE}
                SendMessage(Handle, EM_SETSEL, 1, MAKELONG(MaxLength, MaxLength));
    {$ENDIF}
            end
            else
                Inherited;
        end

        { 派生元呼出し }
        else
            Inherited;
    end;

    {
    ---------------------------------------------------------------------------
        THNedit  WM_PASTEｲﾍﾞﾝﾄ処理     2010.04.12 Add by T.Sugawa
    ---------------------------------------------------------------------------
    }
    procedure THNedit.WMPaste(var Message: TMessage);
    var
      Str:String;
      ClipText: Array of WideChar;
      Key: Char;
      idx,
      FdHiLength: Integer;    // ﾌｨｰﾙﾄﾞ入力可能整数桁数
      Ok: Boolean;
      NSA: THNumStrAttr;
    begin
      // クリップボート内テキスト取得
      SetLength(ClipText, Self.FExtEdit.Column + 1);
      Clipboard.GetTextBuf(@ClipText[0], Length(ClipText));

      // 貼付け後の文字列を生成
      Str := Text;
      if (Self.SelLength > 0) then
      begin
        Delete(Str, Self.SelStart + 1, Self.SelLength);
        Insert(StrPas(PWideChar(@ClipText[0])), Str, Self.SelStart + 1);
      end else
      begin
        Insert(StrPas(PWideChar(@ClipText[0])), Str, Self.SelStart + 1);
      end;

      // 桁数調整
      if (Length(Str) > Self.FExtEdit.Column) then
      begin
        Delete(Str, Self.FExtEdit.Column + 1, Length(Str) - Self.FExtEdit.Column)
      end;

      //フィールド桁からの整数部入力文字数を設定
      FdHiLength := FExtEdit.Column - FHNumEdit.DecLen;
      if FHNumEdit.DecLen > 0 then Dec(FdHiLength);//小数点分の減


      // 入力不可文字を削除(KeyPress処理より流用)
      idx := 1;
      while (Length(Str) >= idx) do
      begin
        Key := Str[idx];

        if Key = ''                                   then Ok := TRUE
        else if FHNumEdit.MinusSupp and (Key = '-')   then Ok := FALSE
        else if Str = '-'                             then Ok := TRUE
        else if GetNumStrAttr(Str, NSA) = FALSE       then Ok := FALSE
        else if (FHNumEdit.DecLen = 0) and (Key = '.')then Ok := FALSE
        else if NSA.LoColumn > FHNumEdit.DecLen       then Ok := FALSE
        else if EditNumStr(Str) > FExtEdit.Column     then Ok := FALSE
        else if (NSA.HiColumn > FdHiLength)           then Ok := FALSE
        else                                               Ok := TRUE;

        if (Ok) then
          inc(idx)
        else
          Delete(Str, idx, 1);
      end;

      if (Length(Str) > 0) then
        Text := Str;
    end;

    {
    ---------------------------------------------------------------------------
        THNedit   OnDblClickｲﾍﾞﾝﾄ発生  1999-8-20 Add kubochi
    ---------------------------------------------------------------------------
    }
    procedure   THNedit.DblClick;
    var
      Pt   : TPoint;                                                    // 20000322 add kubochi
      wrect: TRect ;                                                    // 20000322 add kubochi
    begin
        { 派生元呼び出し }
        inherited DblClick;
//        if (MTach <> nil) or (not MouseInput) then exit;              // 20000322 kubochi del
//        MTach := TMouseTach.Create(Self);                             // 20000322 kubochi del

        if (not (csDesigning in ComponentState))
        and (MouseInput) and (CalcForm = nil) then begin                // 20000322 kubochi add begin
            CalcForm := TForm.Create(Owner);
            if CalcForm <> nil then begin
                with CalcForm do begin
                    //BorderStyle  := bsDialog;                         // 2009.08.11 Chg T.Sugawa
                    BorderStyle  := bsToolWindow;
                    height       :=  0;
                    width        :=  0;
                    top          :=  0;
                    left         :=  0;
                    color        := clBtnFace;
                    name         := Self.Name+'CalcForm';
                    tag          := 0 ;
                    caption      := 'Mouse Window';

                    OnDeactivate := CalcDeactivate;                     // ﾃﾞｱｸﾃｨﾍﾞｰﾄ接続
                    OnKeyDown    := CalcKeyDown;                        // ｷｰﾀﾞｳﾝ接続
                end;{with end}
            end else exit;

            MTach := TMouseTach.create(Self);
            if MTach <> nil then begin
                with MTach do begin
                    //CalcForm.SetBounds(0,0,Width+6,Height+25);        // 2009.08.11 Del T.Sugawa
                    CalcForm.SetBounds(0,0,Width,Height);               // 2009.08.11 Add T.Sugawa
                    CalcForm.ClientWidth := Width;                      // 2009.08.11 Add T.Sugawa
                    CalcForm.ClientHeight := Height;                    // 2009.08.11 Add T.Sugawa
                    Top  := 0;
                    Left := 0;
                end;{with end}
            end;
        end;

        if (CalcForm <> nil)
        and(MTach    <> nil)
        and(MouseInput) then begin
            Pt   := Parent.ClientToScreen(Point(Self.Left, Self.Top));
            Pt.y := Pt.y+(Self.Height);
            GetWindowRect(GetDeskTopWindow,wrect);
            if Pt.y + CalcForm.Height > wrect.Bottom then
              Pt.y := Pt.y - Self.Height - CalcForm.Height;
            CalcForm.Top := Pt.y;
            CalcForm.Left:= Pt.x;
            CalcForm.Show;
        end;                                                            // 20000322 kubochi add end
    end;

    {
    ---------------------------------------------------------------------------
        THNedit   CalcDeactivateｲﾍﾞﾝﾄ発生  20000322 add kubochi
    ---------------------------------------------------------------------------
    }
    procedure   THNedit.CalcDeactivate;
    begin
        if CalcForm <> nil then CalcForm.Close;
    end;

    {
    ---------------------------------------------------------------------------
        THNedit   CalcKeyDownｲﾍﾞﾝﾄ発生  20000322 add kubochi
    ---------------------------------------------------------------------------
    }
    procedure   THNedit.CalcKeyDown(Sender: TObject; var Key: Word; Shift: TShiftState);
    begin
        case key of
        VK_ESCAPE:if CalcForm <> nil then CalcForm.Close;
        48,96  :if (MTach <> nil) and (Shift = []) then with MTach do
                    TachPanelMouseUp(TObject(TachPanel0 ),mbLeft,[],0,0); //0
        49,97  :if (MTach <> nil) and (Shift = []) then with MTach do
                    TachPanelMouseUp(TObject(TachPanel1 ),mbLeft,[],0,0); //1
        50,98  :if (MTach <> nil) and (Shift = []) then with MTach do
                    TachPanelMouseUp(TObject(TachPanel2 ),mbLeft,[],0,0); //2
        51,99  :if (MTach <> nil) and (Shift = []) then with MTach do
                    TachPanelMouseUp(TObject(TachPanel3 ),mbLeft,[],0,0); //3
        52,100 :if (MTach <> nil) and (Shift = []) then with MTach do
                    TachPanelMouseUp(TObject(TachPanel4 ),mbLeft,[],0,0); //4
        53,101 :if (MTach <> nil) and (Shift = []) then with MTach do
                    TachPanelMouseUp(TObject(TachPanel5 ),mbLeft,[],0,0); //5
        54,102 :if (MTach <> nil) and (Shift = []) then with MTach do
                    TachPanelMouseUp(TObject(TachPanel6 ),mbLeft,[],0,0); //6
        55,103 :if (MTach <> nil) and (Shift = []) then with MTach do
                    TachPanelMouseUp(TObject(TachPanel7 ),mbLeft,[],0,0); //7
        56,104 :if (MTach <> nil) and (Shift = []) then with MTach do
                    TachPanelMouseUp(TObject(TachPanel8 ),mbLeft,[],0,0); //8
        57,105 :if (MTach <> nil) and (Shift = []) then with MTach do
                    TachPanelMouseUp(TObject(TachPanel9 ),mbLeft,[],0,0); //9
        110,190:if (MTach <> nil) and (Shift = []) then with MTach do
                    TachPanelMouseUp(TObject(TachPanel10),mbLeft,[],0,0); // .
        109,189:if (MTach <> nil) and (Shift = []) then with MTach do
                    TachPanelMouseUp(TObject(TachPanel11),mbLeft,[],0,0); // -
        end;{case end}

    end;

    {
    ---------------------------------------------------------------------------
        THNedit   数値文字列の編集
    ---------------------------------------------------------------------------
    }
    {$WARNINGS OFF}
    function THNedit.EditNumStr(var Str:String):Integer;
    var
        i:Integer;
        n, m:Integer;
        Value:Real;
        Code:Integer;
        NSA:THNumStrAttr;
        Pos:Integer;
    begin
//        if Str[Length(Str)] = '.' then begin
//            Delete(Str, Length(Str), 1);
//            Str := '0';
//        end;

        Val(Str, Value, Code);
        if Code = 0 then begin
            { 0非表示 }
            if not FHNumEdit.ZeroDisp and (Value = 0.0) then
                Str := ''
            else begin
                case FHNumEdit.ZeroSupp of
                { ｾﾞﾛ抑制OFF }
                zsOff:
                    begin
                        { 入力値先頭の'0'の数取得 }
                        n := 0;
                        for i := 1 to Length(Str) - 1 do begin
                            if Str[i] = '0' then
                                Inc(n)
                            else if (Str[i] = '.') and (n = 1) then begin
                                n := 0;
                                Break;
                            end
                            else if Str[i] <> '-' then
                                break;
                        end;

                        { 小数桁生成 }
                        Str := Format('%.*f', [FHNumEdit.DecLen, Value]);

                        { 入力値先頭の'0'付加 }
                        if Value < 0.0 then Pos := 2 else Pos := 1;
                        for i := 1 to n do
                            Insert('0', Str, Pos);

                        { ｶﾝﾏ編集 }
                        if FHNumEdit.KanmaEdt then
                            KanmaEdit(Str);
                    end;
                { ｾﾞﾛ抑制ON }
                zsOn:
                    begin
                        if FHNumEdit.KanmaEdt then
                            Str := Format('%.*n', [FHNumEdit.DecLen, Value])
                        else
                            Str := Format('%.*f', [FHNumEdit.DecLen, Value]);
                    end;
                { ｾﾞﾛ抑制FILL }
                zsFill:
                    begin
                        { 小数桁生成 }
                        Str := Format('%.*f', [FHNumEdit.DecLen, Value]);
                        GetNumStrAttr(Str, NSA);

                        { FILLする'0'の数取得 }
                        n := FExtEdit.Column;
                        if FHNumEdit.DecLen > 0 then
                            n := n - FHNumEdit.DecLen - 1;
                        m := n;
                        if FHNumEdit.KanmaEdt then
                            n := n - (n div 4);
                        if NSA.Sign and not (FHNumEdit.KanmaEdt and (m mod 4 = 0)) then
                            n := n - 1;
                        n := n - NSA.HiColumn;

                        { 入力値先頭の'0'付加 }
                        if Value < 0.0 then Pos := 2 else Pos := 1;
                        for i := 1 to n do
                            Insert('0', Str, Pos);

                        { ｶﾝﾏ編集 }
                        if FHNumEdit.KanmaEdt then
                            KanmaEdit(Str);
                    end;
                end;
            end;

            Result := Length(Str);
        end;
    end;
    {$WARNINGS ON}

    {
    ---------------------------------------------------------------------------
        THNedit  GetValue         1999-8-25 Add kubochi
    ---------------------------------------------------------------------------
    }
    function THNedit.GetValue:double;
    var
      idx : integer;
    begin
      val(DataText,result,idx);
    end;

    {
    ---------------------------------------------------------------------------
        THNedit  SetValue         1999-8-25 Add kubochi
    ---------------------------------------------------------------------------
    }
    procedure THNedit.SetValue(Value:double);
    begin
      DataText := FloatToStr(Value);
      UPDATE;
    end;

    {
    ---------------------------------------------------------------------------
        THNedit  GetInt           1999-8-25 Add kubochi
    ---------------------------------------------------------------------------
    }
    function THNedit.GetInt:Longint;
    var
      idx : integer;
    begin
      val(DataText,result,idx);
    end;

    {
    ---------------------------------------------------------------------------
        THNedit  SetInt           1999-8-25 Add kubochi
    ---------------------------------------------------------------------------
    }
    procedure THNedit.SetInt(Value:Longint);
    begin
      DataText := IntToStr(Value);
      UPDATE;
    end;


    {
    ---------------------------------------------------------------------------
        THNedit  FHNumEditの設定
    ---------------------------------------------------------------------------
    }
    procedure THNedit.SetNumEdit(Value:THNumEdit);
    begin
        FHNumEdit.Assign(Value);
    end;

    {
    ---------------------------------------------------------------------------
        MouseBtnFontﾌﾟﾛﾊﾟﾃｨの設定      1999-8-20 Add kubochi
    ---------------------------------------------------------------------------
    }
    procedure   THNedit.SetMouseBtnFont(Value:TFont);
    begin
        FMouseBtnFont.Assign(Value);
    end;

    {
    ---------------------------------------------------------------------------
        SetMouseBtnSizeﾌﾟﾛﾊﾟﾃｨの設定      1999-8-20 Add kubochi
    ---------------------------------------------------------------------------
    }
    procedure   THNedit.SetMouseBtnSize(Value:integer);
    begin
        if Value > 0 then
            FMouseBtnSize := Value;
    end;

    {
    ---------------------------------------------------------------------------
        THNedit  HNumEditﾌﾟﾛﾊﾟﾃｨの変更
    ---------------------------------------------------------------------------
    }
    procedure   THNedit.NumEditChanged(Sender:TObject);
    begin
        { 再描画 }
        Invalidate;
    end;

{$IFNDEF HREG}
    {
    ***************************************************************************
        ｺﾝﾎﾟｰﾈﾝﾄの登録

            入力    なし
            出力    なし
    ***************************************************************************
    }
    procedure Register;
    begin
        RegisterComponents('HSS', [THEdit]);
        RegisterComponents('HSS', [THNedit]);
    end;
{$ENDIF}

end.

