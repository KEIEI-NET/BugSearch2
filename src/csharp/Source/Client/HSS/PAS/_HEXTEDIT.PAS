{
******************************************************************************
    HSS ∫›Œﬂ∞»›ƒ◊≤Ãﬁ◊ÿ  ¢HSS£

        ägí£ï“èWÃﬂ€ ﬂ√®¥√ﬁ®¿

        ’∆Øƒñº  :   HEXTEDIT.PAS
        çÏê¨é“  :   Kubochi
        çÏê¨ì˙  :   1999/7
        äTóv    :   TExtEditå^ópÇÃê›íË¿ﬁ≤±€∏ﬁÅAãyÇ—Ãﬂ€ ﬂ√®¥√ﬁ®¿ÇíËã`Ç∑ÇÈ
//                  :   2001.12.11  é≠ñÏÅ@çKê∂                              //
//                  :   á@  åÖêîÇÇSåÖëŒâû                                  //
//                  :   2009.08.11  ê{êÏ  íˆéuòY                            //
//                  :   á@ HSS100ëŒâû(HSS50ÉxÅ[ÉX)                          //
******************************************************************************
}

unit Hextedit;

{$DEFINE HREG}
{$DEFINE UPDATE}

{
******************************************************************************
    interfaceïî
******************************************************************************
}
interface

    { ’∆ØƒéwíË }
    uses
        SysUtils, WinTypes, WinProcs, Messages, Classes, Graphics, Controls,
        //Forms, StdCtrls, Buttons, ExtCtrls, DsgnIntf, Hedit;                  // 2009.08.11 Chg
        Forms, StdCtrls, Buttons, ExtCtrls, DesignIntf, DesignEditors, Hedit;

   { å^êÈåæ }
    type
        { ägí£ï“èWå^Ãﬂ€ ﬂ√®¿ﬁ≤±€∏ﬁíËã` }
        TExtEditDialog = class(TForm)
            OKBtn: TBitBtn;
            CancelBtn: TBitBtn;
            Alignment: TRadioGroup;
            EnableChars: TGroupBox;
            CBecWord: TCheckBox;
            CBecSpace: TCheckBox;
            CBecKana: TCheckBox;
            CBecNum: TCheckBox;
            CBecSign: TCheckBox;
            CBecAlpha: TCheckBox;
            CBecNumSign: TCheckBox;
            CursorPos: TRadioGroup;
            FreeCursor: TCheckBox;
            AutoWidth: TCheckBox;
            Column: TEdit;
            Label3: TLabel;
        private
            procedure SetDialogValue;
            procedure GetDialogValue;
        public
            ExtEdit:TExtEdit;
            constructor Create(AOwner:TComponent); override;
            destructor  Destroy; override;
            function Execute:Boolean;
        end;

        { ägí£ï“èWå^Ãﬂ€ ﬂ√®¥√ﬁ®¿íËã` }
        TExtEditProperty = class(TClassProperty)
        public
            procedure Edit; override;
            function GetAttributes:TPropertyAttributes; override;
        end;

    { Ãﬂ€º∞ºﬁ¨ÅAä÷êîêÈåæ }
    {$IFNDEF HREG}
    procedure Register;                         { Ãﬂ€ ﬂ√®¥√ﬁ®¿ÇÃìoò^ }
    {$ENDIF}

{
******************************************************************************
    implementationïî
******************************************************************************
}
implementation

    {
    ---------------------------------------------------------------------------
        ¿ﬁ≤±€∏ﬁÃ´∞—ì«Ç›çûÇ›
    ---------------------------------------------------------------------------
    }
    {$R *.DFM}

    {
    ---------------------------------------------------------------------------
        TExtEditDialog  ∫›Ωƒ◊∏¿
    ---------------------------------------------------------------------------
    }
    constructor TExtEditDialog.Create(AOwner:TComponent);
    begin
        inherited Create(AOwner);
        ExtEdit := TExtEdit.Create;
    end;

    {
    ---------------------------------------------------------------------------
        TExtEditDialog  √ﬁΩƒ◊∏¿
    ---------------------------------------------------------------------------
    }
    destructor  TExtEditDialog.Destroy;
    begin
        ExtEdit.Destroy;
        inherited Destroy;
    end;

    {
    ---------------------------------------------------------------------------
        TExtEditDialog  é¿çs
    ---------------------------------------------------------------------------
    }
    function TExtEditDialog.Execute:Boolean;
    begin
        { ¿ﬁ≤±€∏ﬁÇ÷ÇÃílê›íË }
        SetDialogValue;

        { ”∞ƒﬁïtÇ´¿ﬁ≤±€∏ﬁÇÃé¿çs }
        ShowModal;

        if ModalResult = mrCancel then
            Result := FALSE
        else
        begin
            { ¿ﬁ≤±€∏ﬁÇ©ÇÁÇÃíléÊìæ }
            GetDialogValue;
            Result := TRUE;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        TExtEditDialog  ¿ﬁ≤±€∏ﬁÇ÷ÇÃílê›íË
    ---------------------------------------------------------------------------
    }
    procedure   TExtEditDialog.SetDialogValue;
    begin
        Column.Text         := IntToStr(ExtEdit.Column);
        Alignment.ItemIndex := Integer(ExtEdit.Alignment);
        CursorPos.ItemIndex := Integer(ExtEdit.CursorPos);
        FreeCursor.Checked  := ExtEdit.FreeCursor;
        AutoWidth.Checked   := ExtEdit.AutoWidth;
        CBecWord.Checked    := (ecWord    in ExtEdit.EnableChars);
        CBecSpace.Checked   := (ecSpace   in ExtEdit.EnableChars);
        CBecKana.Checked    := (ecKana    in ExtEdit.EnableChars);
        CBecNum.Checked     := (ecNum     in ExtEdit.EnableChars);
        CBecSign.Checked    := (ecSign    in ExtEdit.EnableChars);
        CBecAlpha.Checked   := (ecAlpha   in ExtEdit.EnableChars);
        CBecNumSign.Checked := (ecNumSign in ExtEdit.EnableChars);
    end;

    {
    ---------------------------------------------------------------------------
        TExtEditDialog  ¿ﬁ≤±€∏ﬁÇ©ÇÁÇÃíléÊìæ
    ---------------------------------------------------------------------------
    }
    procedure   TExtEditDialog.GetDialogValue;
    begin
        ExtEdit.Column      := StrToInt(Column.Text);
        ExtEdit.Alignment   := TAlignment(Alignment.ItemIndex);
        ExtEdit.CursorPos   := TCursorPos(CursorPos.ItemIndex);
        ExtEdit.FreeCursor  := FreeCursor.Checked;
        ExtEdit.AutoWidth   := AutoWidth.Checked;
        ExtEdit.EnableChars := [];
        if CBecWord.Checked    then ExtEdit.EnableChars := ExtEdit.EnableChars + [ecWord];
        if CBecSpace.Checked   then ExtEdit.EnableChars := ExtEdit.EnableChars + [ecSpace];
        if CBecKana.Checked    then ExtEdit.EnableChars := ExtEdit.EnableChars + [ecKana];
        if CBecNum.Checked     then ExtEdit.EnableChars := ExtEdit.EnableChars + [ecNum];
        if CBecSign.Checked    then ExtEdit.EnableChars := ExtEdit.EnableChars + [ecSign];
        if CBecAlpha.Checked   then ExtEdit.EnableChars := ExtEdit.EnableChars + [ecAlpha];
        if CBecNumSign.Checked then ExtEdit.EnableChars := ExtEdit.EnableChars + [ecNumSign];
    end;

    {
    ---------------------------------------------------------------------------
        TExtEditProrety     ï“èWé¿çs
    ---------------------------------------------------------------------------
    }
    procedure TExtEditProperty.Edit;
    var
        ExtEditDialog:TExtEditDialog;
    begin
        { ¿ﬁ≤±€∏ﬁê∂ê¨ }
        ExtEditDialog := TExtEditDialog.Create(Application);
        try
            { ¿ﬁ≤±€∏ﬁé¿çs }
            ExtEditDialog.ExtEdit.Assign(TExtEdit(GetOrdValue));
            if ExtEditDialog.Execute then
{$IFDEF UPDATE}
                SetOrdValue(Longint(ExtEditDialog.ExtEdit));
{$ELSE}
                TExtEdit(GetOrdValue).Assign(ExtEditDialog.ExtEdit);
{$ENDIF}
        finally
            { ¿ﬁ≤±€∏ﬁîjä¸ }
            ExtEditDialog.Free;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        TNumEditProrety     ¥√ﬁ®¿ëÆê´ÇÃê›íË
    ---------------------------------------------------------------------------
    }
    function TExtEditProperty.GetAttributes:TPropertyAttributes;
    begin
{$IFDEF UPDATE}
        Result := [paMultiSelect, paSubProperties, paDialog];
{$ELSE}
        Result := [paMultiSelect, paSubProperties, paDialog, paReadOnly];
{$ENDIF}
    end;

    {$IFNDEF HREG}
    {
    ***************************************************************************
        Ãﬂ€ ﬂ√®¥√ﬁ®¿ÇÃìoò^

            ì¸óÕ    Ç»Çµ
            èoóÕ    Ç»Çµ
    ***************************************************************************
    }
    procedure Register;
    begin
        RegisterPropertyEditor(TypeInfo(TExtEdit), nil, '', TExtEditProperty);
    end;
    {$ENDIF}

end.
