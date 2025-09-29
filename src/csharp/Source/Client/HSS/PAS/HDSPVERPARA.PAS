//****************************************************************************//
// System           : HSS100                                                  //
// Sub System       : HDSPVERPARA                                             //
// Program name     : バージョン表示アクセスDLL関数群(ヘッダ)                 //
//                  : HDSPVERPARA.PAS                                         //
// Name Space       :                                                         //
// Programmer       : Kumagai                                                 //
// Date             : 2009.08.10                                              //
// Note             : HSS70から生成                                           //
//----------------------------------------------------------------------------//
// Update Note      :                                                         //
//----------------------------------------------------------------------------//
//          (c)Copyright  2009 Broadleaf Co,. Ltd                             //
//****************************************************************************//
unit HDSPVERPARA;

interface

uses
  Windows;

type
  pHDspVerParam = ^THDSPVERPARAM;
  THDSPVERPARAM = record
   szPgName:        array [0..127] of Char;
   szPgTitle:       array [0..127] of Char;
   szMainFormName:  array [0..127] of Char;
   szActvFormName:  array [0..127] of Char;
   szFormTitle:     array [0..127] of Char;
   szFormClassName: array [0..127] of char;
   szItemName:      array [0..127] of char;
   szItemClassName: array [0..127] of char;
   szHelpPath:      array [0..255] of char;
   hWnd:            THANDLE;
   szReserve:       array [0..29] of char;
  end;
  TShowVer = function (ipHDspVerParam: pHDspVerParam): integer; stdcall;
  TCloseVer = function (ipHDspVerParam: pHDspVerParam): integer;stdcall;

const
  ctHDSPVERDLL = '';            // 未設定
  ctShowVer    = 'ShowVer';
  ctCloseVer   = 'CloseVer';

var
  vShowVer : function (ipHDspVerParam: pHDspVerParam): integer;stdcall;
  vCloseVer : function (ipHDspVerParam: pHDspVerParam): integer;stdcall;

implementation

end.
 