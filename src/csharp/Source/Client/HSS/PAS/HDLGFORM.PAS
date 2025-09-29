//**********************************************************************//
// System           :   システム共通                                    //
// Sub System       :   HSS100部品(HSS70より焼き直し）                  //
// Program name     :   HSS100用メッセージボックス                      //
//                  :   HDlgForm                                        //
// Programer        :   iwamoto                                         //
// Date             :   20090810                                        //
//----------------------------------------------------------------------//
// Update Note      :   2013.01.09  M.Kubota                            //
//                  :   ①親(EXE)→子(DLL)の子Formより呼出された状態で  //
//                  :     タスクバーより子Formを選択すると子の裏に隠れる//
//                  :     不具合を修正                                  //
//                  :   ※THDlgFormF.PopupMode を pmAuto に変更。       //
//                  :   ②CTRL+Cでクリップボードに表示内容をコピーする  //
//                  :     機能を追加                                    //
//                  :   ③MB_RETRYCANCELを指定した際に例外が発生する    //
//                  :     不具合を修正                                  //
//**********************************************************************//
unit HDlgForm;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ExtCtrls, StdCtrls, ImgList, HFocus, Clipbrd;

type
  THDlgFormF = class(TForm)
    LblMsg: TLabel;
    ImgIcon: TImage;
    ImgLst: TImageList;
    BtnOk: TButton;
    BtnCancel: TButton;
    BtnYes: TButton;
    BtnNo: TButton;
    BtnAbort: TButton;
    BtnRetry: TButton;
    BtnIgnore: TButton;
    HArrowKeyControl1: THArrowKeyControl;
    procedure FormActivate(Sender: TObject);
    procedure FormShortCut(var Msg: TWMKey; var Handled: Boolean);
  private
    { Private 宣言 }
  public
    { Public 宣言 }
  end;

  function HMessageBox(hWnd: THANDLE; lpText: PChar; lpCaption: PChar; uType: UINT): integer;


var
  HDlgFormF: THDlgFormF;

implementation

const
  ctLabelTop     = 18;
  ctButtonLeft   = 15;
  ctButtonTop    = 56;
  ctButtonWidth  = 87;
  ctButtonHeight = 23;
  ctButtonInt    = 10;

var
  guType : integer;

{$R *.DFM}


//*********************************************************************//
// Module Name     :  HMessageBox                                      //
// 引数            :  １ Windowハンドル                                //
//                 :  ２ メッセージ文字列へのポインタ                  //
//                 :  ３ キャプション文字列へのポインタ                //
//                 :  ４ ボタン・アイコンの種類                        //
// 戻り値          :  整数   MessegeBox APIの戻り値に同じ              //
// Programer       :  iwamoto                                          //
// Date            :  20090810                                         //
//---------------------------------------------------------------------//
// Update Note      :                                                  //
//*********************************************************************//
function HMessageBox(hWnd: THANDLE; lpText: PChar; lpCaption: PChar; uType: UINT): integer;
var
  oOrgForm:    TForm;
  oCompo:      TComponent;
  eWkHeight:   Extended;
  nTextWidth:  Integer;
  nBtnWidth:   Integer;
  nBtnFig:     Integer;
  nBtnTop:     Integer;
  nIconIdx:    Integer;
  i :          Integer;

begin

  // 元のアクティブフォームを保存
  oOrgForm := Screen.ActiveForm;

  HDlgFormF := THDlgFormF.Create(Application);

  with HDlgFormF do begin

    // アイコンのインデックス番号を決める
    if uType = 0 then begin
      nIconIdx := -1;
    end else if (uType and MB_ICONINFORMATION) = MB_ICONINFORMATION then begin
      nIconIdx := 0;
    end  else if (uType and MB_ICONASTERISK) = MB_ICONASTERISK	 then begin
      nIconIdx := 0;
    end  else if (uType and MB_ICONEXCLAMATION) = MB_ICONEXCLAMATION then begin
      nIconIdx := 1;
    end  else if (uType and MB_ICONSTOP) = MB_ICONSTOP then begin
      nIconIdx := 2;
    end  else if (uType and MB_ICONHAND) = MB_ICONHAND	then begin
      nIconIdx := 2;
    end  else if (uType and MB_ICONQUESTION) = MB_ICONQUESTION	then begin
      nIconIdx := 3;
    end else begin
      nIconIdx := -1;
    end;
    if nIconIdx >= 0 then begin
      ImgLst.GetIcon(nIconIdx, ImgIcon.Picture.Icon);
    end;

    // キャプションを設定
    caption := lpCaption;

    // メッセージを設定
    LblMsg.caption  := lpText;
    LblMsg.Autosize := True;

    // ラベルのTop位置を調整
    if AnsiStrPos(lpText, #13) = nil then
      LblMsg.Top := ctLabelTop + 4
    else
      LblMsg.Top := ctLabelTop;

    eWkHeight := (LblMsg.Top * 2.4);
    Height  := GetSystemMetrics(SM_CYCAPTION) + Round(eWkHeight) + LblMsg.Height + ctButtonHeight;

    // ボタンの開始位置を設定
    eWkHeight := (LblMsg.Top * 1.8);
    nBtnTop := Round(eWkHeight) + LblMsg.Height;

    // ボタンの数を決定
    if uType = 0 then begin
      nBtnFig := 1;
    end  else if (uType and MB_YESNOCANCEL) = MB_YESNOCANCEL then begin
      nBtnFig := 3;
    end  else if (uType and MB_RETRYCANCEL) = MB_RETRYCANCEL then begin
      nBtnFig := 2;
    end  else if (uType and MB_OKCANCEL) = MB_OKCANCEL then begin
      nBtnFig := 2;
    end  else if (uType and MB_ABORTRETRYIGNORE) = MB_ABORTRETRYIGNORE then begin
      nBtnFig := 3;
    end  else if (uType and MB_YESNO) = MB_YESNO then begin
      nBtnFig := 2;
    end else begin
      nBtnFig := 1;
    end;

    // アイコンの縦方向の位置を決定
    ImgIcon.Top := LblMsg.Top + ((LblMsg.Height - LblMsg.Top) div 2) - 5;

    // フォーム幅を決定
    nTextWidth  := ((ImgIcon.Left + ImgIcon.Width) * 2) + LblMsg.Width;
    nBtnWidth   := (ctButtonLeft * 2)  + (ctButtonWidth * nBtnFig) + (ctButtonInt * (nBtnFig -1));
    if nTextWidth > nBtnWidth then
      ClientWidth  := nTextWidth
    else
      ClientWidth  := nBtnWidth;

    ClientWidth   := ClientWidth  + 10;
    ClientHeight  := ClientHeight + 10;

    // ボタンの種類を決定
    if uType = 0 then begin
      BtnOK.Top     := nBtnTop;
      BtnOK.Left    := (ClientWidth - BtnOK.Width) div 2;
      BtnOK.Visible := True;
    end  else if (uType and MB_YESNOCANCEL) = MB_YESNOCANCEL then begin
      BtnYes.Top        := nBtnTop;
      BtnYes.Left       := (ClientWidth - ((ctButtonWidth * nBtnFig) + (ctButtonInt * (nBtnFig -1)))) div 2;
      BtnYes.Visible    := True;
      BtnNo.Top         := nBtnTop;
      BtnNo.Left        := BtnYes.Left + BtnYes.Width + ctButtonInt;
      BtnNo.Visible     := True;
      BtnCancel.Top     := nBtnTop;
      BtnCancel.Left    := BtnNo.Left + BtnNo.Width + ctButtonInt;
      BtnCancel.Visible := True;
    end  else if (uType and MB_RETRYCANCEL) = MB_RETRYCANCEL then begin
      BtnRetry.Top      := nBtnTop;
      BtnRetry.Left     := (ClientWidth - ((ctButtonWidth * nBtnFig) + (ctButtonInt * (nBtnFig -1)))) div 2;
      BtnRetry.Visible  := True;
      BtnCancel.Top     := nBtnTop;
      BtnCancel.Left    := BtnRetry.Left + BtnRetry.Width + ctButtonInt;
      BtnCancel.Visible := True;
    end  else if (uType and MB_OKCANCEL) = MB_OKCANCEL then begin
      BtnOK.Top         := nBtnTop;
      BtnOK.Left        := (ClientWidth - ((ctButtonWidth * nBtnFig) + (ctButtonInt * (nBtnFig -1)))) div 2;
      BtnOK.Visible     := True;
      BtnCancel.Top     := nBtnTop;
      BtnCancel.Left    := BtnOK.Left + BtnOK.Width + ctButtonInt;
      BtnCancel.Visible := True;
    end  else if (uType and MB_ABORTRETRYIGNORE) = MB_ABORTRETRYIGNORE then begin
      BtnAbort.Top      := nBtnTop;
      BtnAbort.Left     := (ClientWidth - ((ctButtonWidth * nBtnFig) + (ctButtonInt * (nBtnFig -1)))) div 2;
      BtnAbort.Visible  := True;
      BtnRetry.Top      := nBtnTop;
      BtnRetry.Left     := BtnAbort.Left + BtnAbort.Width + ctButtonInt;
      BtnRetry.Visible  := True;
      BtnIgnore.Top     := nBtnTop;
      BtnIgnore.Left    := BtnRetry.Left + BtnRetry.Width + ctButtonInt;
      BtnIgnore.Visible := True;
    end  else if (uType and MB_YESNO) = MB_YESNO then begin
      BtnYes.Top        := nBtnTop;
      BtnYes.Left       := (ClientWidth - ((ctButtonWidth * nBtnFig) + (ctButtonInt * (nBtnFig -1)))) div 2;
      BtnYes.Visible    := True;
      BtnNo.Top         := nBtnTop;
      BtnNo.Left        := BtnYes.Left + BtnYes.Width + ctButtonInt;
      BtnNo.Visible     := True;
    end else begin
      BtnOK.Top         := nBtnTop;
      BtnOK.Left        := (ClientWidth - BtnOK.Width) div 2;
      BtnOK.Visible     := True;
    end;

    // フォームShow内で使用
    guType := uType;

    // 画面表示
    Result := ShowModal;

    HDlgFormF.Free;

 end;

end;

//*********************************************************************//
// Module Name     :  フォームアクティブ                               //
//                 :  THDlgFormF.FormActivate                          //
// Programer       :  iwamoto                                       //
// Date            :  2001.04.19                                       //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
procedure THDlgFormF.FormActivate(Sender: TObject);
begin

  // カーソルのあるボタンを設定
  if (guType and MB_YESNOCANCEL) = MB_YESNOCANCEL then begin
    if (guType and MB_DEFBUTTON2) = MB_DEFBUTTON2 then
      BtnNo.SetFocus
    else if (guType and MB_DEFBUTTON3) = MB_DEFBUTTON3 then
      BtnCancel.SetFocus
    else
      BtnYes.SetFocus;
  end  else if (guType and MB_RETRYCANCEL) = MB_RETRYCANCEL then begin
    if (guType and MB_DEFBUTTON2) = MB_DEFBUTTON2 then
      BtnCancel.SetFocus
    else
      //BtnYes.SetFocus;  //DEL 2013.01.09  M.Kubota
      BtnRetry.SetFocus;  //ADD 2013.01.09  M.Kubota
  end  else if (guType and MB_OKCANCEL) = MB_OKCANCEL then begin
    if (guType and MB_DEFBUTTON2) = MB_DEFBUTTON2 then
      BtnCancel.SetFocus
    else
      BtnOK.SetFocus;
  end  else if (guType and MB_ABORTRETRYIGNORE) = MB_ABORTRETRYIGNORE then begin
    if (guType and MB_DEFBUTTON2) = MB_DEFBUTTON2 then
      BtnRetry.SetFocus
    else if (guType and MB_DEFBUTTON3) = MB_DEFBUTTON3 then
      BtnIgnore.SetFocus
    else
      BtnAbort.SetFocus;
  end  else if (guType and MB_YESNO) = MB_YESNO then begin
    if (guType and MB_DEFBUTTON2) = MB_DEFBUTTON2 then
      BtnNo.SetFocus
     else
       BtnYes.SetFocus;
  end;


end;

//--- ADD 2013.01.09 M.Kubota --->>>
procedure THDlgFormF.FormShortCut(var Msg: TWMKey; var Handled: Boolean);
var
  cpyTxt: String;
  idxBtn: Integer;
  lstBtn: array[0..6] of TButton;
const
  msgLine = '---------------------------'#13#10;
begin
  // CTRL+C の条件判定
  if (KeyboardStateToShiftState = [ssCtrl]) and (Msg.CharCode = Ord('C')) then
  begin
    // ボタンの配列には意味が有るので変更の際には注意が必要
    //   [0]  [1]  [2]    [3]  [4]    [5]  [6]
    // 1)ＯＫ
    // 2)     はい いいえ
    // 3)     はい いいえ                  キャンセル
    // 4)                 中止 再試行 無視
    // 5)                      再試行      キャンセル
    lstBtn[0] := BtnOk;
    lstBtn[1] := BtnYes;
    lstBtn[2] := BtnNo;
    lstBtn[3] := BtnAbort;
    lstBtn[4] := BtnRetry;
    lstBtn[5] := BtnIgnore;
    lstBtn[6] := BtnCancel;

    cpyTxt := '';

    // 表示ボタンのキャプションを収集
    for idxBtn := 0 to Length(lstBtn) - 1 do
    begin
      if lstBtn[idxBtn].Visible then
      begin
        cpyTxt := cpyTxt + lstBtn[idxBtn].Caption + '   ';
      end;
    end;

    cpyTxt := Format(msgLine + '%s'#13#10 +
                     msgLine + '%s'#13#10 +
                     msgLine + '%s'#13#10 +
                     msgLine, [Caption, LblMsg.Caption, Trim(cpyTxt)]);

    Clipboard.AsText := cpyTxt;
    Handled := True;
  end;
end;
//--- ADD 2013.01.09 M.Kubota ---<<<

end.
