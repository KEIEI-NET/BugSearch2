//****************************************************************************//
// System           : HSS100                                                  //
// Sub System       : HComBox                                                 //
// Program name     : Hコンボボックス                                         //
//                  : HComBox.pas                                             //
// Name Space       :                                                         //
// Programmer       : Kumagai                                                 //
// Date             : 2009.08.10                                              //
// Note             : HSS70から生成（以下、HSS70との相違点）                  //
//                  : ①THComboBoxにてmChgPrevモードの対応                    //
//                  : ②THStrComboBoxにて                                     //
//                  :   mChgPrevモード時の動作が不正な部分を修正              //
//----------------------------------------------------------------------------//
// Update Note      :                                                         //
//----------------------------------------------------------------------------//
//          (c)Copyright  2009 Broadleaf Co,. Ltd                             //
//****************************************************************************//
unit HComBox;

{$DEFINE HREG}

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, HVersion, HLib, HFrame, ExtCtrls;

type
  TListDispType = (ldtNameOnly,     // ﾘｽﾄには名称のみ表示
                   ldtCodeOnly,     // ﾘｽﾄにはｺｰﾄﾞのみ表示
                   ldtCodeName);    // ﾘｽﾄにはｺｰﾄﾞと名称を表示

  TMode         = (mNotChg,         // ｺｰﾄﾞ名称自動変換を行わない
                   mChgOnly,        // ｺｰﾄﾞ名称自動変換を行い一致しないものはｸﾘｱしない
                   mChgAll,         // ｺｰﾄﾞ名称自動変換を行い一致しないものはｸﾘｱする
                   mChgPrev);       // ｺｰﾄﾞ名称自動変換を行い一致しないものは前選択値に戻す

  // 部分マッチ
  TSubMatchType = (mtMatchNone,     // 部分マッチを行わない
                   mtMatchBoth,     // SelCode,手入力両方部分マッチ
                   mtMatchSelCode,  // SelCode部分マッチ
                   mtMatchInputd);  // 手入力部分マッチ


  tagTList = record
    code:   LongInt;
    name:   string;
  end;

  // THStrComboBox用
  tagTSList = record
    code:   String;
    name:   string;
  end;

  THComboBox = class(TComboBox)
  private
    { Private 宣言 }
    FVersion:   TVersion;
    FListDispType:TListDispType;
    FEditDispType:TListDispType;
    FSelCode:   LongInt;
    FMode:      TMode;
    FAutoListSize:Boolean;
    FPrevItemIndex:  integer;
    drop:       bool;
    BkWidth:    Integer;
    BkLeft:     Integer;
    LongWidth:  Integer;                                                        // ﾘｽﾄ内の最大幅
    FOnDestroy:TNotifyEvent;                                                    // ﾒｲﾝ画面destroyｲﾍﾞﾝﾄ保存用
    function    TextChk:Boolean;
  protected
    { Protected 宣言 }
    Timer1:     TTimer;
    procedure   Change; override;
    procedure   DoExit; override;
    procedure   DropDown; override;
    procedure   SetAutoListSize(Value:Boolean);
    procedure   SetListDispType(Value:TListDispType);
    procedure   SetEditDispType(Value:TListDispType);
    procedure   SetMode(Value:TMode);
    procedure   SetSelCode(Value:LongInt);
    procedure   TextPut(Sender: TObject);
    procedure   OnOwnerFormDestroy(Sender: TObject);                            // THComboBoxﾒｲﾝﾌｫｰﾑ destroyｲﾍﾞﾝﾄ
   public
    { Public 宣言 }
    ListRec:    array of tagTList;
    ListCnt:    LongInt;
    constructor Create(AOwner:TComponent);override;
    destructor  Destroy;override;
    procedure   HClear;
    procedure   HAdd(nCode:LongInt;sCName:String);
    function    AdjustBounds(SrcString:String):LongInt;
  published
    { Published 宣言 }
    property    Version:TVersion read FVersion write FVersion stored False;
    property    ListDispType:TListDispType read FListDispType write SetListDispType default ldtNameOnly;
    property    EditDispType:TListDispType read FEditDispType write SetEditDispType default ldtNameOnly;
    property    SelCode:LongInt read FSelCode write SetSelCode;
    property    Mode:TMode read FMode write SetMode default mNotChg;
    property    AutoListSize:Boolean read FAutoListSize write SetAutoListSize default False;
  end;

  // HComboBoxのSelCode文字列版
  THStrComboBox = class(TComboBox)
  private
    { Private 宣言 }
    FVersion:   TVersion;
    FListDispType:TListDispType;
    FEditDispType:TListDispType;
    FSelCode:   string;
    FMode:      TMode;
    FAutoListSize:Boolean;
    FSubMatchType:   TSubMatchType;
    FSubMatchSelSart:   integer;
    FSubMatchSelLength: integer;
    FPrevItemIndex:  integer;
    drop:       bool;
    BkWidth:    Integer;
    BkLeft:     Integer;
    LongWidth:  Integer;                                                        // ﾘｽﾄ内の最大幅
    FOnDestroy: TNotifyEvent;                                                   // ﾒｲﾝ画面destroyｲﾍﾞﾝﾄ保存用
    function    TextChk:Boolean;
  protected
    { Protected 宣言 }
    Timer1:     TTimer;
    procedure   Change; override;
    procedure   DoExit; override;
    procedure   DropDown; override;
    procedure   SetAutoListSize(Value:Boolean);
    procedure   SetListDispType(Value:TListDispType);
    procedure   SetEditDispType(Value:TListDispType);
    procedure   SetMode(Value:TMode);
    procedure   SetSelCode(Value:string);
    procedure   TextPut(Sender: TObject);
    procedure   OnOwnerFormDestroy(Sender: TObject);                            // THStrComboBoxﾒｲﾝﾌｫｰﾑ destroyｲﾍﾞﾝﾄ
   public
    { Public 宣言 }
    ListRec:    array of tagTSList;
    ListCnt:    integer;
    constructor Create(AOwner:TComponent);override;
    destructor  Destroy;override;
    procedure   HClear;
    procedure   HAdd(sCode:string;sCName:String); overload;
    function    AdjustBounds(SrcString:String):integer;
  published
    { Published 宣言 }
    property    Version:TVersion           read FVersion        write FVersion stored False;
    property    ListDispType:TListDispType read FListDispType   write SetListDispType default ldtNameOnly;
    property    EditDispType:TListDispType read FEditDispType   write SetEditDispType default ldtNameOnly;
    property    SelCode:string             read FSelCode        write SetSelCode;
    property    Mode:TMode                 read FMode           write SetMode default mNotChg;
    property    AutoListSize:Boolean       read FAutoListSize   write SetAutoListSize default False;
    property    SubMatchType:   TSubMatchType read FSubMatchType      write FSubMatchType;
    property    SubMatchSelSart:   integer    read FSubMatchSelSart   write FSubMatchSelSart;
    property    SubMatchSelLength: integer    read FSubMatchSelLength write FSubMatchSelLength;
  end;

  { ﾌﾟﾛｼｰｼﾞｬ、関数宣言 }
  {$IFNDEF HREG}
  procedure Register;
  {$ENDIF}
var
  StartFlg:   Integer;
  StartFlg2:  Integer;

implementation
uses
  HReg;

{$IFNDEF HREG}
procedure Register;
begin
  RegisterComponents('HSS', [THComboBox]);
  RegisterComponents('HSS', [THStrComboBox]);
end;
{$ENDIF}

{
---------------------------------------------------------------------------
  THComboBox    ｺﾝｽﾄﾗｸﾀ
---------------------------------------------------------------------------
}
constructor THComboBox.Create(AOwner:TComponent);
begin
  { 派生元呼び出し }
  inherited Create(AOwner);

  { ﾒﾝﾊﾞ初期化 }
  FVersion := HComboBoxVersion;
  FSelCode := -1;
  FPrevItemIndex := -1;
  if not (csDesigning in ComponentState) then begin

    FOnDestroy := TForm(AOwner).OnDestroy;                                      // ﾒｲﾝ画面Destroyｲﾍﾞﾝﾄ保存
    TForm(AOwner).OnDestroy  := OnOwnerFormDestroy;                             // THComboBox ﾒｲﾝ画面Destroyｲﾍﾞﾝﾄ結合

    Timer1 := TTimer.Create(Self);
    Timer1.Interval := 0;
    Timer1.OnTimer:=TextPut;
  end;

end;

{
---------------------------------------------------------------------------
  THComboBox    ﾃﾞｽﾄﾗｸﾀ
---------------------------------------------------------------------------
}
destructor THComboBox.Destroy;
begin
  Timer1.Free;
  Timer1 := nil;

  { 派生元呼び出し }
  inherited Destroy;
end;

{
---------------------------------------------------------------------------
  THComboBox    ListDispTypeﾌﾟﾛﾊﾟﾃｨ設定
---------------------------------------------------------------------------
}
procedure THComboBox.SetListDispType(Value:TListDispType);
begin
  if FListDispType <> Value then
    FListDispType := Value;
end;

{
---------------------------------------------------------------------------
  THComboBox    EditDispTypeﾌﾟﾛﾊﾟﾃｨ設定
---------------------------------------------------------------------------
}
procedure THComboBox.SetEditDispType(Value:TListDispType);
begin
  if FEditDispType <> Value then
    FEditDispType := Value;
end;

{
---------------------------------------------------------------------------
  THComboBox    Modeﾌﾟﾛﾊﾟﾃｨ設定
---------------------------------------------------------------------------
}
procedure THComboBox.SetMode(Value:TMode);
begin
  if FMode <> Value then
    FMode := Value;
end;

{
---------------------------------------------------------------------------
  THComboBox    AutoListSizeﾌﾟﾛﾊﾟﾃｨ設定
---------------------------------------------------------------------------
}
procedure THComboBox.SetAutoListSize(Value:Boolean);
begin
  if FAutoListSize <> Value then
    FAutoListSize := Value;
end;

{
---------------------------------------------------------------------------
  THComboBox    SelCodeﾌﾟﾛﾊﾟﾃｨ設定
    SelCodeに値が入力された場合は対応するﾃﾞｰﾀをｴﾃﾞｨｯﾄ部に表示する
---------------------------------------------------------------------------
}
procedure THComboBox.SetSelCode(Value:LongInt);
var
  ix: Integer;
begin
  if FSelCode <> Value then
  begin
    FSelCode := Value;
    //ｺｰﾄﾞ検索
    for ix:=0 to ListCnt-1 do
    begin
      if SelCode = ListRec[ix].code then
      begin
        ItemIndex := ix;
        FPrevItemIndex := ItemIndex;
        TextChk;
        Change;
        //ﾌｫｰｶｽが無い場合は選択状態を解除する
        if GetFocus <> Handle then
        begin
          SelStart := 0;
          SelLength:= 0;
        end;
        break;
      end;
    end;
    if FSelCode = -1 then
    begin
      if FMode = mChgPrev then
      begin
        ItemIndex := FPrevItemIndex;
      end else
      begin
        ItemIndex := -1;
      end;
      TextChk;
      Change;
    end;
  end;
end;

{
---------------------------------------------------------------------------
  THComboBox    HAddﾒｿｯﾄﾞ
---------------------------------------------------------------------------
}
procedure THComboBox.HAdd(nCode:LongInt;sCName:String);
var
  strWrk: String;
  wkListRec: array of tagTList;
  ix: Integer;
begin
  strWrk := '';
  if (FListDispType = ldtCodeOnly) or (FListDispType = ldtCodeName) then
    strWrk := format('%6d',[nCode]);
  if (FListDispType = ldtNameOnly) then
    strWrk := strWrk + sCName;
  if (FListDispType = ldtCodeName) then
    strWrk := strWrk + '｜' + sCName;

  //ListBox内容を保存
  SetLength(wkListRec,ListCnt);  //ﾜｰｸ用tagTListを確保
  if ListRec <> nil then
  begin
    //ListRecの内容をwkListRecに保存
    for ix:=0 to ListCnt-1 do
    begin
      wkListRec[ix].code := ListRec[ix].code;
      wkListRec[ix].name := ListRec[ix].name;
    end;
    //繰り返し数を変更するため一旦破棄
    ListRec := nil
  end;
  Inc(ListCnt);
  //新たに領域確保
  SetLength(ListRec,ListCnt);
  //保存しておいた内容を元に戻す。
  for ix:=0 to ListCnt -2 do
  begin
    ListRec[ix].code := wkListRec[ix].code;
    ListRec[ix].name := wkListRec[ix].name;
  end;
  //新内容を追加
  ListRec[ListCnt-1].code := nCode;
  ListRec[ListCnt-1].name := sCName;

  if AdjustBounds(strWrk) > LongWidth then
    LongWidth := AdjustBounds(strWrk);
  Items.Add(strWrk);

  //ｽｺｰﾌﾟ外になるので自動的に破棄されると思うが念のため自ら破棄
  wkListRec := nil;

  //ﾘｽﾄにｽｸﾛｰﾙﾊﾞｰが出現する場合はｽｸﾛｰﾙﾊﾞｰ分幅を足す。
  if ListCnt = DropDownCount +1 then
    LongWidth := LongWidth + 16;
end;

{
---------------------------------------------------------------------------
  THComboBox    Text書き換え
---------------------------------------------------------------------------
}
function THComboBox.TextChk:Boolean;
var
  ix: Integer;
begin
  Result := TRUE;

  if (DroppedDown = false) and (drop = true) and (FAutoListSize = true) then
  begin
    drop := false;
    Width := BkWidth;
    Left := BkLeft;
    BkWidth := 0;
    BkLeft := 0;
    for ix := 0 to TForm(Owner).ComponentCount -1 do
    begin
      if TForm(Owner).Components[ix] is THFrameControl then
      begin
        THFrameControl(TForm(Owner).Components[ix]).Repaint;
        break;
      end;
    end;
  end;

  if ItemIndex = -1 then
  begin
    Exit;
  end;
  if ListRec = nil then
  begin
    Exit;
  end;

  if ListRec <> nil then
  begin
    FSelCode := ListRec[ItemIndex].code;
  end;

  case FEditDispType of
  ldtNameOnly:
  begin
    if Text <> ListRec[ItemIndex].name then
    begin
      Text := ListRec[ItemIndex].name;
      Result := FALSE;
    end;
  end;
  ldtCodeOnly:
  begin
    if StrToIntDef(Text,-1) <> ListRec[ItemIndex].code then
    begin
      Text := format('%d',[ListRec[ItemIndex].code]);
      Result := FALSE;
    end;
  end;
  ldtCodeName:
  begin
    if Text <> format('%6d',[ListRec[ItemIndex].code])+'｜'+
                        ListRec[ItemIndex].name then
    begin
      Text := format('%6d',[ListRec[ItemIndex].code])+'｜'+
                       ListRec[ItemIndex].name;
      Result := FALSE;
    end;
  end;
  end;
end;

{
---------------------------------------------------------------------------
  THComboBox    Changﾒｿｯﾄﾞ
---------------------------------------------------------------------------
}
procedure THComboBox.Change;
begin
  if (ListRec <> nil) and (ItemIndex <> -1) then
  begin
    FSelCode := ListRec[ItemIndex].code;
    if not (csDesigning in ComponentState) then
    begin
      Timer1.Interval := 10;
    end;
  end;
  { 派生元呼び出し }
  inherited;
end;

{
---------------------------------------------------------------------------
  THComboBox    OnExitｲﾍﾞﾝﾄのﾌｯｸ
---------------------------------------------------------------------------
}
procedure THComboBox.DoExit;
var
  ix: Integer;
  strWrk:String;
  chgflg:Boolean;
begin
  chgflg := TRUE;
  if (BkWidth <> 0) or (BkLeft <> 0) then
  begin
    drop := false;
    Width := BkWidth;
    Left := BkLeft;
    BkWidth := 0;
    BkLeft  := 0;
    for ix := 0 to TForm(Owner).ComponentCount -1 do
    begin
      if TForm(Owner).Components[ix] is THFrameControl then
      begin
        THFrameControl(TForm(Owner).Components[ix]).Repaint;
        break;
      end;
    end;
  end;
  if ListRec = nil then
  begin
    //ｺｰﾄﾞにも名称にも該当ﾃﾞｰﾀがない場合
    if (FMode = mChgAll) and ( FEditDispType <> ldtCodeName) then
    begin
      ItemIndex := -1;
      SelCode := -1;
      Text := '';
    end;
    { 派生元呼び出し }
    inherited;
    Exit;
  end;

  //ｺｰﾄﾞ名称自動変換を行わないのであれば終了
  if FMode = mNotChg then
  begin
    { 派生元呼び出し }
    inherited;
    Exit;
  end;

  //名称検索
  for ix:=0 to ListCnt-1 do
  begin
    if HSpcCut(Text) = HSpcCut(ListRec[ix].name) then
    begin
      if ListRec[ix].Code = SelCode then
        chgflg := FALSE;
      ItemIndex := ix;
      FPrevItemIndex := ItemIndex;
      TextChk;
      if chgflg = TRUE then
        Change;
      { 派生元呼び出し }
      inherited;
      Exit;
    end;
  end;

  //ｺｰﾄﾞ検索
  for ix:=0 to ListCnt-1 do
  begin
    if StrToIntDef(Text,-999) = ListRec[ix].Code then
    begin
      if ListRec[ix].Code = SelCode then
        chgflg := FALSE;
      ItemIndex := ix;
      FPrevItemIndex := ItemIndex;
      TextChk;
      if chgflg = TRUE then
        Change;
      { 派生元呼び出し }
      inherited;
      Exit;
    end;
  end;

  //ｺｰﾄﾞにも名称にも該当ﾃﾞｰﾀがない場合(モード＝前選択済み値)
  if (FMode = mChgPrev) and ( FEditDispType = ldtCodeName) then
  begin
    for ix:=0 to ListCnt-1 do
    begin
      strWrk := format('%6d',[ListRec[ix].code]);
      strWrk := strWrk + '｜' + ListRec[ix].name;

      if HSpcCut(strWrk) = HSpcCut(Text) then
      begin
        if ListRec[ix].Code = SelCode then
          chgflg := FALSE;
        ItemIndex := ix;
        FPrevItemIndex := ItemIndex;
        TextChk;
        if chgflg = TRUE then
          Change;
        { 派生元呼出し }
        inherited;
        Exit;
      end;
    end;
    ItemIndex := -1;
    SelCode := -1;
    Text := '';
  end;

  //ｺｰﾄﾞにも名称にも該当ﾃﾞｰﾀがない場合(モード＝前選択済み値)
  if FMode = mChgPrev then
  begin
    ItemIndex := FPrevItemIndex;                                                // 選択済みを設定
    TextChk;
    if chgflg = TRUE then
      Change;
    { 派生元呼び出し }
    inherited;
    Exit;
  end;

  //ｺｰﾄﾞにも名称にも該当ﾃﾞｰﾀがない場合
  if (FMode = mChgAll) and ( FEditDispType <> ldtCodeName) then
  begin
    ItemIndex := -1;
    SelCode := -1;
    Text := '';
  end;

  //ｺｰﾄﾞにも名称にも該当ﾃﾞｰﾀがない場合
  if (FMode = mChgAll) and (FEditDispType = ldtCodeName) then
  begin
    for ix:=0 to ListCnt-1 do
    begin
      strWrk := format('%6d',[ListRec[ix].code]);
      strWrk := strWrk + '｜' + ListRec[ix].name;
      if HSpcCut(strWrk) = HSpcCut(Text) then
      begin
        inherited;
        Exit;
      end;
    end;
    ItemIndex := -1;
    SelCode := -1;
    Text := '';
  end;

  { 派生元呼び出し }
  inherited;
end;

{
---------------------------------------------------------------------------
  THComboBox    DropDownｲﾍﾞﾝﾄのﾌｯｸ
---------------------------------------------------------------------------
}
procedure THComboBox.DropDown;
var
  Pt: TPoint;
  ix: Integer;
begin
  if (DroppedDown = false) and (FAutoListSize = true) then
  begin
    if BkWidth = 0 then
    BkWidth := Width;
    if BkLeft = 0 then
      BkLeft := Left;

    if Width < LongWidth then
    begin
      Pt := TForm(Owner).ScreenToClient(Parent.ClientToScreen(
              Point(Left,Top)));
      if TForm(Owner).Width - Pt.x  > LongWidth +10 then
        Width := LongWidth +10
      else if Pt.x + Width > LongWidth +10 then
      begin
        Left := TForm(Owner).Width - LongWidth - 23;
        Width := LongWidth +10;
      end else
        Width := TForm(Owner).Width - Pt.x -10;

      for ix := 0 to TForm(Owner).ComponentCount -1 do
      begin
        if TForm(Owner).Components[ix] is THFrameControl then
        begin
          THFrameControl(TForm(Owner).Components[ix]).Repaint;
          break;
        end;
      end;
    end;
    drop := true;
  end;

  { 派生元呼び出し }
  inherited;
end;

{
---------------------------------------------------------------------------
  THComboBox    Clearﾒｿｯﾄﾞｵｰﾊﾞｰﾗｲﾄﾞ
---------------------------------------------------------------------------
}
procedure THComboBox.HClear;
begin
  if ListRec <> nil then
  begin
    ListRec := nil;
    ListCnt := 0;
    LongWidth := 0;
    FSelCode := -1;
  end;
  Clear;
end;

{
---------------------------------------------------------------------------
  THComboBox    文字列の幅(ﾋﾟｸｾﾙ)を計算する。
---------------------------------------------------------------------------
}
function THComboBox.AdjustBounds(SrcString:String):LongInt;
var
  DC: HDC;
  SaveFont: HFont;
  TextSize: TSize;
begin
  DC := GetDC(0);
  SaveFont := SelectObject(DC, Font.Handle);
  GetTextExtentPoint32(DC, PChar(SrcString), Length(SrcString), TextSize);
  SelectObject(DC, SaveFont);
  ReleaseDC(0, DC);

  Result := TextSize.cx;
end;

procedure THComboBox.TextPut(Sender: TObject);
begin
  if StartFlg = 0 then
  begin
    StartFlg := 1;
    if TextChk = TRUE then
      Timer1.Interval := 0;
    StartFlg := 0;
  end;
end;

{
---------------------------------------------------------------------------
  THComboBox    FormDestroyｲﾍﾞﾝﾄのﾌｯｸ
---------------------------------------------------------------------------
}
procedure THComboBox.OnOwnerFormDestroy(Sender: TObject);
begin
  inherited ;
  if Assigned(FOnDestroy) then FOnDestroy(Sender);                              // メインフォームイベント呼び出し

  Timer1.Enabled := False;

end;

{
---------------------------------------------------------------------------
  THStrComboBox   ｺﾝｽﾄﾗｸﾀ
---------------------------------------------------------------------------
}
constructor THStrComboBox.Create(AOwner:TComponent);
begin

  // 派生元呼び出し
  inherited Create(AOwner);

  // ﾒﾝﾊﾞ初期化
  FVersion := HComboBoxVersion;
  FSelCode := '';

  FPrevItemIndex := -1;

  // 実行時のみ
  if not (csDesigning in ComponentState) then begin

    FOnDestroy := TForm(AOwner).OnDestroy;                                      // ﾒｲﾝ画面Destroyｲﾍﾞﾝﾄ保存
    TForm(AOwner).OnDestroy  := OnOwnerFormDestroy;                             // THStrComboBox ﾒｲﾝ画面Destroyｲﾍﾞﾝﾄ結合

    Timer1 := TTimer.Create(Self);
    Timer1.Interval := 0;
    Timer1.OnTimer:=TextPut;

  end;

end;

{
---------------------------------------------------------------------------
  THStrComboBox   ﾃﾞｽﾄﾗｸﾀ
---------------------------------------------------------------------------
}
destructor THStrComboBox.Destroy;
begin

  Timer1.Free;
  Timer1 := nil;

  // 派生元呼び出し
  inherited Destroy;

end;

{
---------------------------------------------------------------------------
  THStrComboBox   ListDispTypeﾌﾟﾛﾊﾟﾃｨ設定
---------------------------------------------------------------------------
}
procedure THStrComboBox.SetListDispType(Value:TListDispType);
begin

  if FListDispType <> Value then
    FListDispType := Value;
    
end;

{
---------------------------------------------------------------------------
  THStrComboBox   EditDispTypeﾌﾟﾛﾊﾟﾃｨ設定
---------------------------------------------------------------------------
}
procedure THStrComboBox.SetEditDispType(Value:TListDispType);
begin

  if FEditDispType <> Value then
    FEditDispType := Value;

end;

{
---------------------------------------------------------------------------
  THStrComboBox   Modeﾌﾟﾛﾊﾟﾃｨ設定
---------------------------------------------------------------------------
}
procedure THStrComboBox.SetMode(Value:TMode);
begin

  if FMode <> Value then
    FMode := Value;
    
end;

{
---------------------------------------------------------------------------
  THStrComboBox   AutoListSizeﾌﾟﾛﾊﾟﾃｨ設定
---------------------------------------------------------------------------
}
procedure THStrComboBox.SetAutoListSize(Value:Boolean);
begin

  if FAutoListSize <> Value then
    FAutoListSize := Value;

end;

{
---------------------------------------------------------------------------
  THStrComboBox   SelCodeﾌﾟﾛﾊﾟﾃｨ設定
    SelCodeに値が入力された場合は対応するﾃﾞｰﾀをｴﾃﾞｨｯﾄ部に表示する
---------------------------------------------------------------------------
}
procedure THStrComboBox.SetSelCode(Value:string);
var
  ix: Integer;
  bMatch: boolean;
  strWkSelCode: string;

begin

  // マッチタイプで文字列ヒット方法を変える
  bMatch := False;
  if ((FSubMatchType = mtMatchBoth) or (FSubMatchType = mtMatchSelCode)) then begin
    // 部分マッチが行えなければモードにより抜ける方法を分ける
    if (FSubMatchSelSart = 0) or (FSubMatchSelLength = 0) then begin
       if FMode = mChgPrev then begin
         ItemIndex := FPrevItemIndex;
       end else begin
         FSelCode  := '';
         ItemIndex := -1;
       end;
       TextChk;
       Change;
    // 両方・SelCodeタイプ
    end else if AnsiCompareText(Trim(Value), Copy(FSelCode, FSubMatchSelSart, FSubMatchSelLength)) = 0 then begin
      bMatch := True;
    end;
  end else begin
    // 通常比較
    if AnsiCompareText(FSelCode, Trim(Value)) = 0 then begin
      bMatch := True;
    end;
  end;

  // 元が同じでなければ検索開始
  if bMatch = False then begin

    strWkSelCode := Trim(Value);

    //ｺｰﾄﾞ検索
    for ix:=0 to ListCnt-1 do begin

      // マッチタイプで文字列ヒット方法を変える
      bMatch := False;
      if ((FSubMatchType = mtMatchBoth) or (FSubMatchType = mtMatchSelCode)) then begin
        // 部分マッチが行えなければモードにより抜ける方法を分ける
        if (FSubMatchSelSart = 0) or (FSubMatchSelLength = 0) then begin
           if FMode = mChgPrev then begin
             ItemIndex := FPrevItemIndex;
           end else begin
             FSelCode  := '';
             ItemIndex := -1;
           end;
           TextChk;
           Change;
        // 両方・SelCodeタイプ
        end else if AnsiCompareText(strWkSelCode, Copy(ListRec[ix].code, FSubMatchSelSart, FSubMatchSelLength)) = 0 then begin
          bMatch := True;
        end;
      end else begin
        // 通常比較
        if AnsiCompareText(strWkSelCode, ListRec[ix].code) = 0 then begin
          bMatch := True;
        end;
      end;

      // マッチすれば
      if bMatch = True then begin

        ItemIndex := ix;
        FPrevItemIndex := ItemIndex;                                            // 選択済みを保管
        TextChk;
        Change;

        //ﾌｫｰｶｽが無い場合は選択状態を解除する
        if GetFocus <> Handle then begin
          SelStart := 0;
          SelLength:= 0;
        end;

        FSelCode := strWkSelCode;
        break;

      end;

    end;

    // 未選択の場合
    if (FSelCode = '') or (Value = '') then begin
      if FMode = mChgPrev then begin
        ItemIndex := FPrevItemIndex;
      end else begin
        FSelCode  := '';
        ItemIndex := -1;
      end;
      TextChk;
      Change;
    end;

  end;

end;

{
---------------------------------------------------------------------------
  THStrComboBox   HAddﾒｿｯﾄﾞ
---------------------------------------------------------------------------
}
procedure THStrComboBox.HAdd(sCode:string;sCName:String);
var
  strWrk: String;
  wkListRec: array of tagTSList;
  ix: Integer;

begin

  strWrk := '';
  if (FListDispType = ldtCodeOnly) or (FListDispType = ldtCodeName) then
    strWrk := trim(sCode);
  if (FListDispType = ldtNameOnly) then
    strWrk := strWrk + sCName;
  if (FListDispType = ldtCodeName) then
    strWrk := strWrk + '｜' + sCName;

  //ListBox内容を保存
  SetLength(wkListRec,ListCnt);  //ﾜｰｸ用tagTListを確保

  if ListRec <> nil then begin
    //ListRecの内容をwkListRecに保存
    for ix:=0 to ListCnt-1 do begin
      wkListRec[ix].code := ListRec[ix].code;
      wkListRec[ix].name := ListRec[ix].name;
    end;
    //繰り返し数を変更するため一旦破棄
    ListRec := nil
  end;

  Inc(ListCnt);
  //新たに領域確保
  SetLength(ListRec,ListCnt);

  //保存しておいた内容を元に戻す
  for ix:=0 to ListCnt -2 do begin
    ListRec[ix].code := wkListRec[ix].code;
    ListRec[ix].name := wkListRec[ix].name;
  end;

  //新内容を追加
  ListRec[ListCnt-1].code := sCode;
  ListRec[ListCnt-1].name := sCName;

  if AdjustBounds(strWrk) > LongWidth then
    LongWidth := AdjustBounds(strWrk);
  Items.Add(strWrk);

  //ｽｺｰﾌﾟ外になるので自動的に破棄されると思うが念のため自ら破棄
  wkListRec := nil;

  //ﾘｽﾄにｽｸﾛｰﾙﾊﾞｰが出現する場合はｽｸﾛｰﾙﾊﾞｰ分幅を足す。
  if ListCnt = DropDownCount +1 then
    LongWidth := LongWidth + 16;

end;


{
---------------------------------------------------------------------------
  THStrComboBox   Text書き換え
---------------------------------------------------------------------------
}
function THStrComboBox.TextChk:Boolean;
var
  ix: Integer;
begin

  Result := TRUE;

  if (DroppedDown = false) and (drop = true) and (FAutoListSize = true) then begin

    drop := false;
    Width := BkWidth;
    Left := BkLeft;
    BkWidth := 0;
    BkLeft := 0;

    for ix := 0 to TForm(Owner).ComponentCount -1 do begin

      if TForm(Owner).Components[ix] is THFrameControl then begin

        THFrameControl(TForm(Owner).Components[ix]).Repaint;
        break;
        
      end;

    end;

  end;

  if ItemIndex = -1 then begin
    Exit;
  end;

  if ListRec = nil then begin
    Exit;
  end;

  if ListRec <> nil then begin
    FSelCode := ListRec[ItemIndex].code;
  end;

  // 表示方式に従って表示
  case FEditDispType of

    // 名称のみ
    ldtNameOnly: begin
      if AnsiCompareText(Text, ListRec[ItemIndex].name) <> 0 then begin
        Text := ListRec[ItemIndex].name;
        Result := FALSE;
      end;
    end;
    // コードのみ
    ldtCodeOnly: begin
      if AnsiCompareText(Trim(Text), ListRec[ItemIndex].code) <> 0 then begin
        Text := ListRec[ItemIndex].code;
        Result := FALSE;
      end;
    end;
    // コード・名称
    ldtCodeName: begin
      if AnsiCompareText(Trim(Text), format('%s｜%s',[ListRec[ItemIndex].code, ListRec[ItemIndex].name])) <> 0 then begin
        Text := format('%s｜%s',[ListRec[ItemIndex].code, ListRec[ItemIndex].name]);
        Result := FALSE;
      end;

    end;

  end;
  
end;

{
---------------------------------------------------------------------------
  THStrComboBox   Changﾒｿｯﾄﾞ
---------------------------------------------------------------------------
}
procedure THStrComboBox.Change;
begin

  if (ListRec <> nil) and (ItemIndex <> -1) then begin

    FSelCode := ListRec[ItemIndex].code;
    if not (csDesigning in ComponentState) then begin
      Timer1.Interval := 10;
    end;

  end;

  // 派生元呼び出し
  inherited;

end;

{
---------------------------------------------------------------------------
  THStrComboBox   OnExitｲﾍﾞﾝﾄのﾌｯｸ
---------------------------------------------------------------------------
}
procedure THStrComboBox.DoExit;
var
  ix: Integer;
  strWrk :String;
  chgflg :Boolean;
  bMatch :Boolean;

begin

  chgflg := TRUE;

  if (BkWidth <> 0) or (BkLeft <> 0) then begin

    drop := false;
    Width := BkWidth;
    Left := BkLeft;
    BkWidth := 0;
    BkLeft  := 0;

    for ix := 0 to TForm(Owner).ComponentCount -1 do begin

      if TForm(Owner).Components[ix] is THFrameControl then begin
        THFrameControl(TForm(Owner).Components[ix]).Repaint;
        break;
      end;

    end;

  end;

  if ListRec = nil then begin

    // ｺｰﾄﾞにも名称にも該当ﾃﾞｰﾀがない場合
    if (FMode = mChgAll) and ( FEditDispType <> ldtCodeName) then begin
      ItemIndex := -1;
      SelCode := '';
      Text := '';
    end;

    // 派生元呼び出し
    inherited;

    Exit;

  end;

  // ｺｰﾄﾞ名称自動変換を行わないのであれば終了
  if FMode = mNotChg then begin
    // 派生元呼び出し
    inherited;
    Exit;
  end;

  // 名称検索
  for ix:=0 to ListCnt-1 do begin

    // マッチタイプで文字列ヒット方法を変える
    bMatch := False;
    if FSubMatchType <> mtMatchNone then begin
      // 部分マッチが行えなければモードにより抜ける方法を分ける
      if (FSubMatchSelSart > 0) and (FSubMatchSelLength > 0) then begin
        if AnsiCompareText(Trim(Text), Copy(ListRec[ix].name, FSubMatchSelSart, FSubMatchSelLength)) = 0 then begin
          bMatch := True;
        end;
      end;
    end else begin
      if AnsiCompareText(Trim(Text), ListRec[ix].name) = 0 then begin
        bMatch := True;
      end;
    end;

    if bMatch = True then begin

      if AnsiCompareText(ListRec[ix].Code, SelCode) = 0 then
        chgflg := FALSE;

      ItemIndex := ix;
      FPrevItemIndex := ItemIndex;                                              // 選択済みを保管
      TextChk;

      if chgflg = TRUE then
        Change;

      // 派生元呼び出し
      inherited;
      Exit;

    end;

  end;

  // ｺｰﾄﾞ検索
  for ix:=0 to ListCnt-1 do begin

    // マッチタイプで文字列ヒット方法を変える
    bMatch := False;
    if FSubMatchType <> mtMatchNone then begin
      if AnsiCompareText(Trim(Text), Copy(ListRec[ix].Code, FSubMatchSelSart, FSubMatchSelLength)) = 0 then begin
        bMatch := True;
      end;
    end else begin
      if AnsiCompareText(Trim(Text), ListRec[ix].Code) = 0 then begin
        bMatch := True;
      end;
    end;

    if bMatch = True then begin

      if AnsiCompareText(ListRec[ix].Code, SelCode) = 0 then
        chgflg := FALSE;

      ItemIndex := ix;
      FPrevItemIndex := ItemIndex;                                              // 選択済みを保管
      TextChk;

      if chgflg = TRUE then
        Change;

      // 派生元呼び出し
      inherited;
      Exit;

    end;

  end;

  // ｺｰﾄﾞにも名称にも該当ﾃﾞｰﾀがない場合(モード＝前選択済み値)
  if (FMode = mChgPrev) and ( FEditDispType = ldtCodeName) then begin

    for ix:=0 to ListCnt-1 do begin

      strWrk := Trim(ListRec[ix].code + '｜' + ListRec[ix].name);

      // マッチタイプで文字列ヒット方法を変える
      bMatch := False;
      if FSubMatchType = mtMatchNone then begin
        if AnsiCompareText(Trim(Text), strWrk) = 0 then begin
          bMatch := True;
        end;
      end;

      if bMatch = True then begin

        if AnsiCompareText(ListRec[ix].Code, SelCode) = 0 then
          chgflg := FALSE;

        ItemIndex := ix;
        FPrevItemIndex := ItemIndex;                                            // 選択済みを保管
        TextChk;

        if chgflg = TRUE then
          Change;

        // 派生元呼び出し
        inherited;
        Exit;

      end;

    end;

    ItemIndex := -1;
    SelCode   := '';
    Text      := '';

  end;

  // ｺｰﾄﾞにも名称にも該当ﾃﾞｰﾀがない場合(モード＝前選択済み値)
  if FMode = mChgPrev then begin
    ItemIndex := FPrevItemIndex;                                                // 選択済みを設定
    TextChk;
    if chgflg = TRUE then
      Change;
    // 派生元呼び出し
    inherited;
     Exit;
  end;


  // ｺｰﾄﾞにも名称にも該当ﾃﾞｰﾀがない場合
  if (FMode = mChgAll) and ( FEditDispType <> ldtCodeName) then begin
    ItemIndex := -1;
    SelCode   := '';
    Text      := '';
  end;


  // ｺｰﾄﾞにも名称にも該当ﾃﾞｰﾀがない場合
  if (FMode = mChgAll) and (FEditDispType = ldtCodeName) then begin

    for ix:=0 to ListCnt-1 do begin

      strWrk := ListRec[ix].code + '｜' + ListRec[ix].name;

      // マッチタイプで文字列ヒット方法を変える
      bMatch := False;
      if FSubMatchType = mtMatchNone then begin
        if AnsiCompareText(Trim(Text), strWrk) = 0 then begin
          bMatch := True;
        end;
      end;

      if bMatch = True then begin

        if AnsiCompareText(ListRec[ix].Code, SelCode) = 0 then
          chgflg := FALSE;

        ItemIndex := ix;
        FPrevItemIndex := ItemIndex;                                            // 選択済みを保管
        TextChk;

        if chgflg = TRUE then
          Change;

        // 派生元呼び出し
        inherited;
        Exit;

      end;

    end;

    ItemIndex := -1;
    SelCode := '';
    Text := '';

  end;

  // 派生元呼び出し
  inherited;

end;

{
---------------------------------------------------------------------------
  THStrComboBox   DropDownｲﾍﾞﾝﾄのﾌｯｸ
---------------------------------------------------------------------------
}
procedure THStrComboBox.DropDown;
var
  Pt: TPoint;
  ix: Integer;

begin

  if (DroppedDown = false) and (FAutoListSize = true) then begin

    if BkWidth = 0 then
      BkWidth := Width;

    if BkLeft = 0 then
      BkLeft := Left;

    if Width < LongWidth then begin
      Pt := TForm(Owner).ScreenToClient(Parent.ClientToScreen(
              Point(Left,Top)));
      if TForm(Owner).Width - Pt.x  > LongWidth +10 then
        Width := LongWidth +10
      else if Pt.x + Width > LongWidth +10 then begin
        Left := TForm(Owner).Width - LongWidth - 23;
        Width := LongWidth +10;
      end else
        Width := TForm(Owner).Width - Pt.x -10;

      for ix := 0 to TForm(Owner).ComponentCount -1 do begin
        if TForm(Owner).Components[ix] is THFrameControl then begin
          THFrameControl(TForm(Owner).Components[ix]).Repaint;
          break;
        end;
      end;

    end;

    drop := true;

  end;

  // 派生元呼び出し
  inherited;
  
end;

{
---------------------------------------------------------------------------
  THStrComboBox   Clearﾒｿｯﾄﾞｵｰﾊﾞｰﾗｲﾄﾞ
---------------------------------------------------------------------------
}
procedure THStrComboBox.HClear;
begin

  if ListRec <> nil then begin

    ListRec := nil;
    ListCnt := 0;
    LongWidth := 0;
    FSelCode := '';

  end;

  Clear;
  
end;

{
---------------------------------------------------------------------------
  THStrComboBox   文字列の幅(ﾋﾟｸｾﾙ)を計算する。
---------------------------------------------------------------------------
}
function THStrComboBox.AdjustBounds(SrcString:String):integer;
var
  DC: HDC;
  SaveFont: HFont;
  TextSize: TSize;

begin

  DC := GetDC(0);
  SaveFont := SelectObject(DC, Font.Handle);
  GetTextExtentPoint32(DC, PChar(SrcString), Length(SrcString), TextSize);
  SelectObject(DC, SaveFont);
  ReleaseDC(0, DC);

  Result := TextSize.cx;
  
end;

procedure THStrComboBox.TextPut(Sender: TObject);
begin

  if StartFlg2 = 0 then begin

    StartFlg2 := 1;
    if TextChk = TRUE then
      Timer1.Interval := 0;
    StartFlg2 := 0;

  end;

end;

{
---------------------------------------------------------------------------
  THStrComboBox   FormDestroyｲﾍﾞﾝﾄのﾌｯｸ
---------------------------------------------------------------------------
}
procedure THStrComboBox.OnOwnerFormDestroy(Sender: TObject);
begin

  inherited ;

  if Assigned(FOnDestroy) then FOnDestroy(Sender);                              // メインフォームイベント呼び出し

  Timer1.Enabled := False;

end;

end.

