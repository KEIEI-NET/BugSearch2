//****************************************************************************//
// System           : HSS100                                                  //
// Sub System       : HCheckListBox                                           //
// Program name     : Hチェックリストボックス                                 //
//                  : HCheckListBox.pas                                       //
// Name Space       :                                                         //
// Programmer       : Kumagai                                                 //
// Date             : 2009.08.10                                              //
// Note             : HSS70から生成                                           //
//                  : チェックリストボックスに                                //
//                  : コードを保持できるように領域追加                        //
//----------------------------------------------------------------------------//
// Update Note      :                                                         //
//----------------------------------------------------------------------------//
//          (c)Copyright  2009 Broadleaf Co,. Ltd                             //
//****************************************************************************//
unit HCheckListBox;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, HVersion, CheckLst;

type
  THCheckListBox = class(TCheckListBox)
  private
    { Private 宣言 }
    FVersion: TVersion;
  protected
    { Protected 宣言 }
    procedure DestroyWnd; override;                   // code破棄のためoverride
  public
    { Public 宣言 }
    code:   TStrings ;                                // コード格納用
    constructor Create(AOwner: TComponent); override; // code作成のためoverride
  published
    { Published 宣言 }
    property    Version: TVersion read FVersion write FVersion stored False;
  end;

procedure Register;

implementation

//****************************************************************************//
// Module       : Register                                                    //
//----------------------------------------------------------------------------//
// Programer    : Kumagai                                                     //
// Date         : 2009.08.10                                                  //
//****************************************************************************//
procedure Register;
begin
  RegisterComponents('HSS', [THCheckListBox]);
end;

//****************************************************************************//
// Module       : Create  (constructor)                                       //
//----------------------------------------------------------------------------//
// Programer    : Kumagai                                                     //
// Date         : 2009.08.10                                                  //
//****************************************************************************//
constructor THCheckListBox.Create(AOwner: TComponent);
begin
  inherited Create(AOwner) ;
  FVersion := HCheckListBoxVersion;
  code := TStringList.Create ;    // コード領域の作成
end ;

//****************************************************************************//
// Module       : DestroyWnd ウィンドウ破棄処理                               //
//----------------------------------------------------------------------------//
// Programer    : Kumagai                                                     //
// Date         : 2009.08.10                                                  //
//****************************************************************************//
procedure THCheckListBox.DestroyWnd;
begin
  code.Free ;                     // コード領域の破棄
  inherited DestroyWnd ;
end ;

end.
