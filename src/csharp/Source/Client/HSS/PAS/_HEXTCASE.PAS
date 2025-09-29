{
******************************************************************************
    HSS ｺﾝﾎﾟｰﾈﾝﾄﾗｲﾌﾞﾗﾘ  ｢HSS｣

        脱出要件ﾌﾟﾛﾊﾟﾃｨｴﾃﾞｨﾀ

        ﾕﾆｯﾄ名  :   HEXTCASE.PAS
        作成者  :   Kubochi
        作成日  :   1999/7
        概要    :   TExtCase型用の設定ﾀﾞｲｱﾛｸﾞ、及びﾌﾟﾛﾊﾟﾃｨｴﾃﾞｨﾀを定義する

//                  :   2009.08.11  須川  程志郎                            //
//                  :   ① HSS100対応(HSS50ベース)                          //
******************************************************************************
}

unit Hextcase;

{$DEFINE HREG}
{$DEFINE UPDATE}

{
******************************************************************************
    interface部
******************************************************************************
}
interface

    { ﾕﾆｯﾄ指定 }
    uses
        Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
        //StdCtrls, Buttons,DsgnIntf;                                           // 2009.08.11 Chg
        StdCtrls, Buttons, DesignIntf, DesignEditors, HEdit;

    { 型宣言 }
    type
// 2009.08.11 DEL
//        {
//        ----------------------------------------------------------------------
//            脱出要件型定義
//        ----------------------------------------------------------------------
//        }
//        TExtCase = class(TPersistent)
//        private
//            FNecessary:Boolean;                 { 入力必須        }
//            FRetKey:Boolean;                    { RETｷｰ有効       }
//            FShiftRetKey:Boolean;               { SHIFT+RETｷｰ有効 }
//            FTabKey:Boolean;                    { TABｷｰ有効       }
//            FShiftTabKey:Boolean;               { SHIFT+TABｷｰ有効 }
//            FRightKey:Boolean;                  { 右矢印ｷｰ有効    }
//            FLeftKey:Boolean;                   { 左矢印ｷｰ有効    }
//            FUpKey:Boolean;                     { 上矢印ｷｰ有効    }
//            FDownKey:Boolean;                   { 下矢印ｷｰ有効    }
//        public
//            constructor Create;
//            procedure   Assign(Source:TPersistent); override;
//        published
//            property    Necessary:Boolean read FNecessary write FNecessary;
//            property    RetKey:Boolean read FRetKey write FRetKey;
//            property    ShiftRetKey:Boolean read FShiftRetKey write FShiftRetKey;
//            property    TabKey:Boolean read FTabKey write FTabKey;
//            property    ShiftTabKey:Boolean read FShiftTabKey write FShiftTabKey;
//            property    RightKey:Boolean read FRightKey write FRightKey;
//            property    LeftKey:Boolean read FLeftKey write FLeftKey;
//            property    UpKey:Boolean read FUpKey write FUpKey;
//            property    DownKey:Boolean read FDownKey write FDownKey;
//        end;
//
//        {
//        ----------------------------------------------------------------------
//            脱出要件型ﾌﾟﾛﾊﾟﾃｨｴﾃﾞｨﾀ定義
//        ----------------------------------------------------------------------
//        }
//        TExtCaseProperty = class(TClassProperty)
//        public
//            procedure Edit; override;
//            function GetAttributes:TPropertyAttributes; override;
//        end;

        {
        ----------------------------------------------------------------------
            脱出要件型ﾌﾟﾛﾊﾟﾃｨﾀﾞｲｱﾛｸﾞ定義
        ----------------------------------------------------------------------
        }
        TExtCaseDialog = class(TForm)
            CBNecessary: TCheckBox;
            CBRetKey:TCheckBox;
            CBShiftRetKey: TCheckBox;
            CBTabKey: TCheckBox;
            CBShiftTabKey: TCheckBox;
            CBUpKey:TCheckBox;
            CBLeftKey:TCheckBox;
            CBRightKey:TCheckBox;
            CBDownKey:TCheckBox;
            OkBtn:TBitBtn;
            CancelBtn:TBitBtn;
        private
            procedure   SetDialogValue;
            procedure   GetDialogValue;
        public
            ExtCase:TExtCase;
            constructor Create(AOwner:TComponent); override;
            destructor  Destroy; override;
            function    Execute:Boolean;
        end;

    { ﾌﾟﾛｼｰｼﾞｬ、関数宣言 }
    {$IFNDEF HREG}
    procedure Register;                         { ﾌﾟﾛﾊﾟﾃｨｴﾃﾞｨﾀの登録 }
    {$ENDIF}

{
******************************************************************************
    implementation部
******************************************************************************
}
implementation

    {
    ---------------------------------------------------------------------------
        ﾀﾞｲｱﾛｸﾞﾌｫｰﾑ読み込み
    ---------------------------------------------------------------------------
    }
    {$R *.DFM}

// 2009.08.11 DEL
//
//    {
//    ---------------------------------------------------------------------------
//        TExtCase    ｺﾝｽﾄﾗｸﾀ
//    ---------------------------------------------------------------------------
//    }
//    constructor TExtCase.Create;
//    begin
//        FNecessary   := FALSE;
//        FRetKey      := TRUE;
//        FShiftRetKey := TRUE;
//        FTabKey      := TRUE;
//        FShiftTabKey := TRUE;
//        FRightKey    := TRUE;
//        FLeftKey     := TRUE;
//        FUpKey       := TRUE;
//        FDownKey     := TRUE;
//    end;
//
//    {
//    ---------------------------------------------------------------------------
//        TExtCase    ｵﾌﾞｼﾞｪｸﾄのｺﾋﾟｰ
//    ---------------------------------------------------------------------------
//    }
//    procedure   TExtCase.Assign(Source:TPersistent);
//    begin
//        if not (Source is TExtCase) then
//            inherited Assign(Source)
//        else begin
//            Necessary   := TExtCase(Source).Necessary;
//            RetKey      := TExtCase(Source).RetKey;
//            ShiftRetKey := TExtCase(Source).ShiftRetKey;
//            TabKey      := TExtCase(Source).TabKey;
//            ShiftTabKey := TExtCase(Source).ShiftTabKey;
//            RightKey    := TExtCase(Source).RightKey;
//            LeftKey     := TExtCase(Source).LeftKey;
//            UpKey       := TExtCase(Source).UpKey;
//            DownKey     := TExtCase(Source).DownKey;
//        end;
//    end;

    {
    ---------------------------------------------------------------------------
        TExtCaseProperty    編集実行
    ---------------------------------------------------------------------------
    }
    procedure   TExtCaseProperty.Edit;
    var
        ExtCaseDialog:TExtCaseDialog;
    begin
        { ﾀﾞｲｱﾛｸﾞ生成 }
        ExtCaseDialog := TExtCaseDialog.Create(Application);
        try
            { ﾀﾞｲｱﾛｸﾞ実行 }
            ExtCaseDialog.ExtCase.Assign(TExtCase(GetOrdValue));
            if ExtCaseDialog.Execute then
{$IFDEF UPDATE}
                SetOrdValue(Longint(ExtCaseDialog.ExtCase));
{$ELSE}
                TExtCase(GetOrdValue).Assign(ExtCaseDialog.ExtCase);
{$ENDIF}
        finally
            { ﾀﾞｲｱﾛｸﾞ破棄 }
            ExtCaseDialog.Free;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        TExtCaseProperty    ﾌﾟﾛﾊﾟﾃｨｴﾃﾞｨﾀ属性の設定
    ---------------------------------------------------------------------------
    }
    function    TExtCaseProperty.GetAttributes:TPropertyAttributes;
    begin
        Result := [paMultiSelect, paSubProperties, paDialog, paReadOnly];
    end;

    {
    ---------------------------------------------------------------------------
        TExtCaseDialog      ｺﾝｽﾄﾗｸﾀ
    ---------------------------------------------------------------------------
    }
    constructor TExtCaseDialog.Create(AOwner:TComponent);
    begin
        inherited   Create(AOwner);
        ExtCase := TExtCase.Create;
    end;

    {
    ---------------------------------------------------------------------------
        TExtCaseDialog      ﾃﾞｽﾄﾗｸﾀ
    ---------------------------------------------------------------------------
    }
    destructor  TExtCaseDialog.Destroy;
    begin
        ExtCase.Free;
        inherited Destroy;
    end;

    {
    ---------------------------------------------------------------------------
        TExtCaseDialog      実行
    ---------------------------------------------------------------------------
    }
    function    TExtCaseDialog.Execute:Boolean;
    begin
        { ﾀﾞｲｱﾛｸﾞへの値設定 }
        SetDialogValue;

        { ﾓｰﾄﾞ付きﾀﾞｲｱﾛｸﾞの実行 }
        ShowModal;

        if ModalResult = mrCancel then
            Result := FALSE
        else
        begin
            { ﾀﾞｲｱﾛｸﾞからの値取得 }
            GetDialogValue;
            Result := TRUE;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        TExtCaseDialog      ﾀﾞｲｱﾛｸﾞへの値設定
    ---------------------------------------------------------------------------
    }
    procedure   TExtCaseDialog.SetDialogValue;
    begin
        CBNecessary.Checked   := ExtCase.Necessary;
        CBRetKey.Checked      := ExtCase.RetKey;
        CBShiftRetKey.Checked := ExtCase.ShiftRetKey;
        CBTabKey.Checked      := ExtCase.TabKey;
        CBShiftTabKey.Checked := ExtCase.ShiftTabKey;
        CBUpKey.Checked       := ExtCase.UpKey;
        CBLeftKey.Checked     := ExtCase.LeftKey;
        CBRightKey.Checked    := ExtCase.RightKey;
        CBDownKey.Checked     := ExtCase.DownKey;
    end;

    {
    ---------------------------------------------------------------------------
        TExtCaseDialog      ﾀﾞｲｱﾛｸﾞからの値取得
    ---------------------------------------------------------------------------
    }
    procedure   TExtCaseDialog.GetDialogValue;
    begin
        ExtCase.Necessary   := CBNecessary.Checked;
        ExtCase.RetKey      := CBRetKey.Checked;
        ExtCase.ShiftRetKey := CBShiftRetKey.Checked;
        ExtCase.TabKey      := CBTabKey.Checked;
        ExtCase.ShiftTabKey := CBShiftTabKey.Checked;
        ExtCase.UpKey       := CBUpKey.Checked;
        ExtCase.LeftKey     := CBLeftKey.Checked;
        ExtCase.RightKey    := CBRightKey.Checked;
        ExtCase.DownKey     := CBDownKey.Checked;
    end;

    {$IFNDEF HREG}
    {
    ***************************************************************************
        ﾌﾟﾛﾊﾟﾃｨｴﾃﾞｨﾀの登録

            入力    なし
            出力    なし
    ***************************************************************************
    }
    procedure Register;
    begin
        RegisterPropertyEditor(TypeInfo(TExtCase), nil, '', TExtCaseProperty);
    end;
    {$ENDIF}

end.



