{
******************************************************************************
    HSS ｺﾝﾎﾟｰﾈﾝﾄﾗｲﾌﾞﾗﾘ  ｢HSS｣

        数値編集ﾌﾟﾛﾊﾟﾃｨｴﾃﾞｨﾀ

        ﾕﾆｯﾄ名  :   HNUMEDIT.PAS
        作成者  :   Kubochi
        作成日  :   1999/7
        概要    :   THNumEdit型用の設定ﾀﾞｲｱﾛｸﾞ、及びﾌﾟﾛﾊﾟﾃｨｴﾃﾞｨﾀを定義する
//                  :   2009.08.11  須川  程志郎                            //
//                  :   ① HSS100対応(HSS50ベース)                          //
******************************************************************************
}

unit Hnumedit;

{$DEFINE XDEF}
{$DEFINE UPDATE}

{
******************************************************************************
    interface部
******************************************************************************
}
interface

     { ﾕﾆｯﾄ指定 }
    uses
        //SysUtils,  Classes, Controls, Forms, StdCtrls, Buttons, ExtCtrls, DsgnIntf, Hedit, Mask;    // 2008.08.11 Chg
        SysUtils,  Classes, Controls, Forms, StdCtrls, Buttons, ExtCtrls, Hedit, Mask,
        DesignIntf, DesignEditors;

   { 型宣言 }
    type
        { 数値編集型ﾌﾟﾛﾊﾟﾃｨﾀﾞｲｱﾛｸﾞ定義 }
        TNumEditDialog = class(TForm)
            OKBtn: TBitBtn;
            CancelBtn: TBitBtn;
            ZeroSupp: TRadioGroup;
            ZeroDisp: TRadioGroup;
            KanmaEdt: TRadioGroup;
            Label1: TLabel;
            DecLen: TMaskEdit;
            CalcInput: TCheckBox;
            MinusSupp: TCheckBox;
        private
            procedure SetDialogValue;
            procedure GetDialogValue;
        public
            HNumEdit:THNumEdit;
            constructor Create(AOwner:TComponent); override;
            destructor  Destroy; override;
            function Execute:Boolean;
        end;

        { 数値編集型ﾌﾟﾛﾊﾟﾃｨｴﾃﾞｨﾀ定義 }
        THNumEditProperty = class(TClassProperty)
        public
            procedure Edit; override;
            function GetAttributes:TPropertyAttributes; override;
        end;

    { ﾌﾟﾛｼｰｼﾞｬ、関数宣言 }
    {$IFDEF HREG}
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

    {
    ---------------------------------------------------------------------------
        TNumEditDialog  ｺﾝｽﾄﾗｸﾀ
    ---------------------------------------------------------------------------
    }
    constructor TNumEditDialog.Create(AOwner:TComponent);
    begin
        inherited Create(AOwner);
        HNumEdit := THNumEdit.Create;
    end;

    {
    ---------------------------------------------------------------------------
        TNumEditDialog  ﾃﾞｽﾄﾗｸﾀ
    ---------------------------------------------------------------------------
    }
    destructor  TNumEditDialog.Destroy;
    begin
        HNumEdit.Free;
        inherited Destroy;
    end;

    {
    ---------------------------------------------------------------------------
        TNumEditDialog  実行
    ---------------------------------------------------------------------------
    }
    function TNumEditDialog.Execute:Boolean;
    begin
        { ﾀﾞｲｱﾛｸﾞへの値設定 }
        SetDialogValue;

        { ﾓｰﾄﾞ付きﾀﾞｲｱﾛｸﾞの実行 }
        ShowModal;

        if ModalResult = mrCancel then
            Result := FALSE
        else begin
            { ﾀﾞｲｱﾛｸﾞからの値取得 }
            GetDialogValue;
            Result := TRUE;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        TNumEditDialog  ﾀﾞｲｱﾛｸﾞへの値設定
    ---------------------------------------------------------------------------
    }
    procedure   TNumEditDialog.SetDialogValue;
    begin
        ZeroSupp.ItemIndex := Integer(HNumEdit.ZeroSupp);
        ZeroDisp.ItemIndex := Integer(HNumEdit.ZeroDisp);
        KanmaEdt.ItemIndex := Integer(HNumEdit.KanmaEdt);
        DecLen.Text        := IntToStr(LongInt(HNumEdit.DecLen));
        CalcInput.Checked  := HNumEdit.CalcInput;
        MinusSupp.Checked  := HNumEdit.MinusSupp;
    end;

    {
    ---------------------------------------------------------------------------
        TNumEditDialog  ﾀﾞｲｱﾛｸﾞからの値取得
    ---------------------------------------------------------------------------
    }
    procedure   TNumEditDialog.GetDialogValue;
    begin
        HNumEdit.ZeroSupp  := TZeroSupp(ZeroSupp.ItemIndex);
        HNumEdit.ZeroDisp  := Boolean(ZeroDisp.ItemIndex);
        HNumEdit.KanmaEdt  := Boolean(KanmaEdt.ItemIndex);
        HNumEdit.DecLen    := Integer(StrToInt(DecLen.Text));
        HNumEdit.CalcInput := CalcInput.Checked;
        HNumEdit.MinusSupp := MinusSupp.Checked;
    end;

    {
    ---------------------------------------------------------------------------
        THNumEditProrety     編集実行
    ---------------------------------------------------------------------------
    }
    procedure THNumEditProperty.Edit;
    var
        NumEditDialog:TNumEditDialog;
    begin
        { ﾀﾞｲｱﾛｸﾞ生成 }
        NumEditDialog := TNumEditDialog.Create(Application);
        try
            { ﾀﾞｲｱﾛｸﾞ実行 }
            NumEditDialog.HNumEdit.Assign(THNumEdit(GetOrdValue));
            if NumEditDialog.Execute then
{$IFDEF UPDATE}
               SetOrdValue(Longint(NumEditDialog.HNumEdit));
{$ELSE}
               THNumEdit(GetOrdValue).Assign(NumEditDialog.HNumEdit);
{$ENDIF}
        finally
            { ﾀﾞｲｱﾛｸﾞ破棄 }
            NumEditDialog.Free;
        end;
    end;

    {
    ---------------------------------------------------------------------------
        THNumEditProrety     ｴﾃﾞｨﾀ属性の設定
    ---------------------------------------------------------------------------
    }
    function THNumEditProperty.GetAttributes:TPropertyAttributes;
    begin
        Result := [paMultiSelect, paSubProperties, paDialog, paReadOnly];
    end;

    {$IFNDEF HREG}
    {
    ***************************************************************************
        ﾌﾟﾛﾊﾟﾃｨｴﾃﾞｨﾀの登録

            入力    なし
            出力    なし
    ***************************************************************************
    }
//    procedure Register;
//    begin
//        RegisterPropertyEditor(TypeInfo(THNumEdit), nil, '', THNumEditProperty);
//    end;
    {$ENDIF}

end.
