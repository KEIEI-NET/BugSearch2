unit HDspHelpPara;
//**********************************************************************//
// System           :   システム共通                                    //
// Sub System       :   HSS部品                                         //
// Program name     :   HTML Help表示アクセスDLL関数群(ヘッダ)          //
//                  :   HDspHelp.DLL                                    //
// Programer        :   鹿野　幸生                                      //
// Date             :   2000.10.25                                      //
//----------------------------------------------------------------------//
// Update Note      :   2001.02.26  鹿野　幸生                          //
//                  :   ① HDSPHELP.DLLをHDSPHELP50.DLLに変更           //
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co,. Ltd                 //
//**********************************************************************//

interface

uses
  Windows;

type
  pHDspHelpParam = ^THDSPHELPPARAM;
  THDSPHELPPARAM = record
   szPgName:        array [0..127] of Char;
   szPgTitle:       array [0..127] of Char;
   szMainFormName:  array [0..127] of Char;
   szActvFormName:  array [0..127] of Char;
   szFormTitle:     array [0..127] of Char;
   szFormClassName: array [0..127] of char;
   szItemName:      array [0..127] of char;
   szItemClassName: array [0..127] of char;
   nTabOrder:       integer;
   nValuType:       integer;
   szValu:          array [0..127] of char;
   szHelpPath:      array [0..255] of char;
   hWnd:            THANDLE;
   szReserve:       array [0..29] of char;
  end;
  TShowHelp = function (ipHDspHelpParam: pHDspHelpParam): integer; stdcall;
  TCloseHelp = function (ipHDspHelpParam: pHDspHelpParam): integer;stdcall;

const
//  ctHDSPHELPDLL = 'HDSPHELP.DLL';                                             2001.02.26 変更
  ctHDSPHELPDLL = 'HDSPHELP50.DLL';
  ctShowHelp    = 'ShowHelp';
  ctCloseHelp   = 'CloseHelp';

var
  vShowHelp : function (ipHDspHelpParam: pHDspHelpParam): integer;stdcall;
  vCloseHelp : function (ipHDspHelpParam: pHDspHelpParam): integer;stdcall;

implementation

end.
 