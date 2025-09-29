{
******************************************************************************
VCL ｺﾝﾎﾟｰﾈﾝﾄﾗｲﾌﾞﾗﾘ  ｢VCL/Xtend｣

日付入力ｴﾃﾞｨｯﾄｺﾝﾄﾛｰﾙ

ﾕﾆｯﾄ名  :   HDEDIT.PAS
作成者  :   Hiroaki Sakai (Penguin Cafe Software Co.)
作成日  :   1996/4
変更内容
  1999/07 ueo
    ・DSLをはずす
    ・PHOENIX.INIを読み込まないように変更
    ・ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰの追加
==============================================================================
修正履歴
 20000322 ueo  元号ﾘｽﾄを別ｳｨﾝﾄﾞｳで表示するように変更
 20000323 ueo  ｶﾚﾝﾀﾞｰを別ｳｨﾝﾄﾞｳで表示するように変更
 20000404 ueo  ｷｰﾎﾞｰﾄﾞで右ｸﾘｯｸﾎﾞﾀﾝ押下時にﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰが表示されるが「年変更」
               の年が-1とか0,+1で表示される不具合修正
 20000421 ueo  ｶﾚﾝﾀﾞｰのNameﾌﾟﾛﾊﾟﾃｨがｾｯﾄされていなかったのでｾｯﾄするように修正
 20000506 ueo  年変更の場合、年Editに空白が入っていると-2等で表示されるのを修正
// Update Note      :   2000.06.29  鹿野　幸生                          //
//                  :   ① ポップアップメニューにAutoHotkeysプロパティ  //
//                  :      の設定を追加(自動的に&が付く障害を解除)      //
//                  :   2000.07.21  鹿野　幸生                          //
//                  :   ① HATE.DLLのEXTERNALリンクを内部定義からHDATE  //
//                  :      ユニットを参照する形式に変更                 //
//                  :      (DLL関数取得が上手くいかなくなる場合がある為)//
//                  :   2000.08.05  鹿野　幸生                          //
//                  :   ① 元号表示のまま終了させようとすると、Win32API //
//                  :      呼び出しエラーが発生するのに対処(50%)        //
//                  :   2000.09.04  kubochi                             //
//                  :   ① 元号LIST表示のまま終了させようとすると、     //
//                  :      Win32API呼び出しエラーが発生するのに対処     //
//                  :   ② ｶﾚﾝﾀﾞｰの表示ｻｲｽﾞが合っていなかったので調整   //
//                  :   2000.09.06  kubochi                             //
//                  :   ① フォームのOnCloseｲﾍﾞﾝﾄが外れてしまうのに対応 //
//                  :   2000.09.12  鹿野　幸生                          //
//                  :   ① 右クリックで年のポップアップメニューが空で   //
//                  :      表示される障害を解除                         //
//                  :   ② 月日表示のときに右クリックでアドレスエラーが //
//                  :      発生する障害を解除                           //
//                  :   2000.09.12  kubochi                             //
//                  :   ① ReadOnlyﾌﾟﾛﾊﾟﾃｨｰをFalseにしても元号LISTが表示//
//                  :      され元号内容が変更できた障害を修正           //
//                  :   ② 元号変換時、変換文字の後にゴミが表示される   //
//                  :      障害を修正                                   //
//                  :   2000.09.25 kubochi                              //
//                  :   ①2000.09.04の対応でOnCloseをハンドリングして   //
//                  :     のをOnDestroyのハンドリングに変更             //
//                  :   2000.10.03  鹿野　幸生                          //
//                  :   ① 月日表示の場合、ALT押下でエラーが発生していた//
//                  :      障害を解除                                   //
//                  :   2000.10.19  鹿野　幸生                          //
//                  :   ① ポップアップウインドウキーでシステム日付を   //
//                  :      選択した時に、日付が入らない障害を解除       //
//                  :   2000.11.06  鹿野　幸生                          //
//                  :   ① KeyDownのメッセージをアプリケーションに戻す  //
//                  :      ように修正(HelpSocket対応)                   //
//                  :   2000.11.13  鹿野　幸生                          //
//                  :   ① Panel貼り付けの移動に対応                    //
//                  :   2000.12.20  鹿野　幸生                          //
//                  :   ① 年のポップアップメニューのセット位置を変更   //
//                  :   2001.02.15  鹿野　幸生                          //
//                  :   ① 元号にフォーカスがある時、最小化・戻すをした //
//                  :      ×ボタンで終了するとタスクバーに残る障害を   //
//                  :      解除                                         //
//                  :   2001.04.24  鹿野　幸生                          //
//                  :   ① 平成１２年１２月１日など日が１桁しか無い状態 //
//                  :      で、マウスの右クリックメニューから日付を入れ //
//                  :      ると、アクセスバイオレーションが発生する障害 //
//                  :      を解除。                                     //
//                  :   2001.12.11  鹿野　幸生                          //
//                  :   ① カレンダーから選択した場合、 年月日の書式に  //
//                  :      よっては不要な値が入ってきていたのを修正     //
//                  :      例) dfG2Y2M → 20011211 ×  → 20011200 ○   //
//                  :   ② LongDateにゼロをセットした場合、初期化処理が //
//                  :      行なわれるように変更                         //
//                  :   2003.08.18  鹿野　幸生                          //
//                  :   ① Edit部に数字以外が入った場合に(ペースト等で) //
//                  :      例外処理が発生する問題を対処                 //
//                  :   2009.08.12  ueo                                 //
//                  :   ① HSS100対応(HSS70ベース)                      //
//                  :   2009.09.10  ueo                                 //
//                  :   ① XTable上にHdateEditを貼ると終了時にエラーが  //
//                  :      発生する不具合修正                           //
//                  :      (OwnerのDestroyイベントフック後Parentに戻して//
//                  :       いたため)                                   //
//                  :   ② HDateEditのDestroyイベントでProcessMessageを //
//                  :      処理しているが、落ちることがある。           //
//                  :      今となっては不要であるため削除することで対応 //
//                  :   2010.05.13  T.Sugawa                            //
//                  :   ① HEditの桁数制御改良に依存する修正            //
//                  :   2018.12.20 譚洪 新元号対応(11470076-00)         //
//----------------------------------------------------------------------//
//                (c)Copyright  1999 TSUBASA SYSTEM Co,. Ltd            //
//**********************************************************************//
}
unit HDedit;

{$DEFINE UPDATE}
{$DEFINE HREG}
//{$DEFINE PHOENIX}

{
******************************************************************************
    interface部
******************************************************************************
}
interface
{ ﾕﾆｯﾄ指定 }
uses
  SysUtils, WinTypes, WinProcs, Messages, Classes, Graphics, Controls,
  Forms, StdCtrls, ExtCtrls, Dialogs, Menus, ComCtrls, Buttons,
//  HEdit, HExtCase, HVersion, Hdate; HSS70
  HEdit, HVersion, Hdate;

{ 定数 }
const
  kJpnListHeight  = 60;
  kDefJpnYearCol  = 4;
  kDefLabelY      = '年';
  kDefLabelM      = '月';
  kDefLabelD      = '日';

{ 型宣言 }
type
//  TGEN_REC = packed record                                                    2000.07.21 削除
//    szGen  : array[0..9] of array[0..3] of Char;
//    cRya   : array[0..9] of Char;
//    nSdate : array[0..9] of LongInt;
//    nEdate : array[0..9] of LongInt;
//    nSadate: array[0..9] of LongInt;
//  end;

  {
  -----------------------------------------------------------------------
    JpnYearｵﾌﾞｼﾞｪｸﾄ定義
  -----------------------------------------------------------------------
  }
  TJpnYear = class(TObject)
  public
    Year:Integer;                               { 開始年 }
    Name:String;                                { 名称   }
  end;

  { 入力桁数 }
  TDateFormat = (
                 df4Y2M2D,                      { 年4桁+月2桁+日2桁 }
                 df2Y2M2D,                      { 年2桁+月2桁+日2桁 }
                 dfG2Y2M2D,                     { 元号+年2桁+月2桁+日2桁 }
                 df4Y2M,                        { 年4桁+月2桁 }
                 df2Y2M,                        { 年2桁+月2桁 }
                 dfG2Y2M,                       { 元号+年2桁+月2桁 }
                 df2M2D,                        { 月2桁+日2桁 }
                 df4Y,                          { 年4桁 }
                 df2Y,                          { 年2桁 }
                 dfG2Y,                         { 元号+年2桁 }
                 df2M,                          { 月2桁 }
                 df2D                           { 日2桁 }
                );

  { 表示順序 }
  TDateSequence=(
                 dsYMD,                         { 年月日 }
                 dsYDM,                         { 年日月 }
                 dsMDY,                         { 月日年 }
                 dsMYD,                         { 月年日 }
                 dsDYM,                         { 日年月 }
                 dsDMY                          { 日月年 }
                );

  { 初期入力項目 }
  TDateInitFocus = (
                 difNone,                       { 無指定 }
                 difJpn,                        { 元号   }
                 difYear,                       { 年     }
                 difMonth,                      { 月     }
                 difDay                         { 日     }
                );

  { 入力可能要素 }
  TDateEnabledEditor = (
                 deeJpn,
                 deeYear,
                 deeMonth,
                 deeDay
                );
  TDateEnabledEditors = set of TDateEnabledEditor;

  { 入力必須要素 }
  TDateNecessaryEditor = (
                 dneJpn,
                 dneYear,
                 dneMonth,
                 dneDay
                );
  TDateNecessaryEditors = set of TDateNecessaryEditor;

  { 日付ｴﾃﾞｨｯﾄｵﾌﾟｼｮﾝ }
  TDateEditOption = (
                 deoZeroSuppY,                  { 年ｾﾞﾛｻﾌﾟﾚｽ }
                 deoZeroSuppM,                  { 月ｾﾞﾛｻﾌﾟﾚｽ }
                 deoZeroSuppD,                  { 日ｾﾞﾛｻﾌﾟﾚｽ }
                 deoYearNameList,               { 元号ﾘｽﾄ    }
                 deoInputCheck,                 { 入力ﾁｪｯｸ   }
                 deoSeparate                    { ｾﾊﾟﾚｰﾄ     }
                );
  TDateEditOptions = set of TDateEditOption;

  {
  -----------------------------------------------------------------------
    元号変換ﾘｽﾄﾉｰﾄﾞ定義
  -----------------------------------------------------------------------
  }
  TGengouNode = class(TObject)
    StartY:Integer;                             { 開始年 }
    EndY:Integer;                               { 終了年 }
    YearName:String;                            { 元号名 }
  end;

  {
  -----------------------------------------------------------------------
    THDateEditｵﾌﾞｼﾞｪｸﾄ定義
  -----------------------------------------------------------------------
  }
{$WARNINGS OFF}
  THDateEdit = class(TCustomControl)              { TCustomControlから派生 }
  private
    FVersion :TVersion;
    FDateFormat:TDateFormat;                    { 入力桁数      }
    FDateSequence:TDateSequence;                { 表示順序      }
    FOptions:TDateEditOptions;                  { 日付ｵﾌﾟｼｮﾝ    }
    FLabelY:String;                             { 年ﾗﾍﾞﾙ        }
    FLabelM:String;                             { 月ﾗﾍﾞﾙ        }
    FLabelD:String;                             { 日ﾗﾍﾞﾙ        }
    FGengouSection:String;                      { 元号ｾｸｼｮﾝ名   }
    FBorderStyle:TBorderStyle;                  { ﾎﾞｰﾀﾞｰｽﾀｲﾙ    }
    FCtl3D:Boolean;                             { 立体表示      }
    FColor:TColor;                              { 背景色        }
    FJpnYearCol:Integer;                        { 元号桁数      }
    FTabStop:Boolean;                           { ﾀﾌﾞｽﾄｯﾌﾟ      }
    FOnChange:TNotifyEvent;                     { ﾃﾞｰﾀ変更ｲﾍﾞﾝﾄ }
    FReadOnly:Boolean;                          { 読み込みのみ  }
    FLabelColor:TColor;                         { ﾗﾍﾞﾙ文字色    }
    FLabelSize:Integer;                         { ﾗﾍﾞﾙｻｲｽﾞ      }
    FInitFocus:TDateInitFocus;                  { 初期入力要素  }
    FEnabledEditors:TDateEnabledEditors;        { 入力可能要素  }
    FNecessaryEditors:TDateNecessaryEditors;    { 入力必須要素  }
    FExtCase:TExtCase;                          { 脱出要件      }
    FYearName:String;                           { 元号          }
    FImeMode:TImeMode;                          { IME制御       }
    FMenuType:Integer;                          { ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰﾀｲﾌﾟ}
    FTransparents:Boolean;                      { 透過設定      }
    FYearNmListNumofDisp:SmallInt;              { 元号表示数    }

    FOnDblClick:TNotifyEvent;                   { ﾀﾞﾌﾞﾙｸﾘｯｸｲﾍﾞﾝﾄ       }
    FOnKeyDown:TKeyEvent;                       { ｷｰ押し下げｲﾍﾞﾝﾄ      }
    FOnKeyUp:TKeyEvent;                         { ｷｰ放しｲﾍﾞﾝﾄ          }
    FOnMouseDown:TMouseEvent;                   { ﾏｳｽﾎﾞﾀﾝ押し下げｲﾍﾞﾝﾄ }
    FOnMouseUp:TMouseEvent;                     { ﾏｳｽﾎﾞﾀﾝ放しｲﾍﾞﾝﾄ     }
//    FOnClose:TCloseEvent;                       { closeｲﾍﾞﾝﾄ    }// ﾒｲﾝ画面Closeｲﾍﾞﾝﾄ保存用 20000904 add kubochi
    FOnDestroy:TNotifyEvent;                    { destroyｲﾍﾞﾝﾄ    }// ﾒｲﾝ画面destroyｲﾍﾞﾝﾄ保存用 20000925 add kubochi
  protected
    JpnEdit:THEdit;                             { 元号ｴﾃﾞｨｯﾄ    }
    JpnList:TListBox;                           { 元号ﾘｽﾄﾎﾞｯｸｽ  }
    JpnYears:TList;                             { 元号ﾘｽﾄ       }
    Gengous:TList;                              { 元号導出ﾘｽﾄ   }
    YearEdit:THNedit;                           { 年ｴﾃﾞｨｯﾄ      }
    MonthEdit:THNedit;                          { 月ｴﾃﾞｨｯﾄ      }
    DayEdit:THNedit;                            { 日ｴﾃﾞｨｯﾄ      }
    YearLabel:TLabel;                           { 年ﾗﾍﾞﾙ        }
    MonthLabel:TLabel;                          { 月ﾗﾍﾞﾙ        }
    DayLabel:TLabel;                            { 日ﾗﾍﾞﾙ        }
    PopMenu:TPopupMenu;                         { ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ }
    SubItems:array[0..4]   of TMenuItem;        { 　〃　　　項目}
    SItemYear:array[0..5]  of TMenuItem;        { 　〃　　　項目}
    SItemMonth:array[0..11]of TMenuItem;        { 　〃　　　項目}
    SItemDay:array[0..30]  of TMenuItem;        { 　〃　　　項目}
// 20000323 >>
//  BkPnel :TPanel;
    BkPnel :TForm;
// 20000323 <<
    Clender:TMonthCalendar;
    OkPnel :TPanel;
    NgPnel :TPanel;
    NxtPnel :TPanel;
    PrvPnel :TPanel;
    IsJpnListOpened:Boolean;
    LongDateBuf:Longint;
    NowSettingLongDate:Boolean;
    CurrentEdit:THEdit;
    JpnYearsNotLoaded:Boolean;
    IsDateSetting:Boolean;
    IsYearChanged:Boolean;
    MainForm:TForm;                             { ﾒｲﾝﾌｫｰﾑ          }
// 20000322 >>
    JpnForm : TForm ;
// 20000322 <<
    OrgOnMessageHandler:TWndMethod;             // ｵﾘｼﾞﾅﾙﾊﾝﾄﾞﾗ                  2000.11.13 追加
    procedure Paint; override;
  private
    procedure   AttachPopElems(Attach:Boolean);
    procedure   SetDateFormat(Value:TDateFormat);
    procedure   SetDateSequence(Value:TDateSequence);
    procedure   SetOptions(Value:TDateEditOptions);
    procedure   SetLabelY(Value:String);
    procedure   SetLabelM(Value:String);
    procedure   SetLabelD(Value:String);
    procedure   SetGengouSection(Value:String);
    procedure   SetBorderStyle(Value:TBorderStyle);
    procedure   SetCtl3D(Value:Boolean);
    procedure   SetColor(Value:TColor);
    procedure   SetJpnYearCol(Value:integer);
    procedure   SetTabStop(Value:Boolean);
    function    GetLongDate:Longint;
    procedure   SetLongDate(Value:Longint);
    procedure   SetReadOnly(Value:Boolean);
    procedure   SetLabelColor(Value:TColor);
    procedure   SetLabelSize(Value:Integer);
    procedure   SetMenuType(Value:Integer);
    procedure   SetEnabledEditors(Value:TDateEnabledEditors);
    procedure   SetExtCase(Value:TExtCase);
    function    GetYearName:String;
    procedure   SetYearName(Value:String);
    procedure   SetImeMode(Value:TImeMode);
    procedure   SetChildrenName;
    procedure   SysDateGet(Sender: TObject);		{ ｼｽﾃﾑ日付取得	   }
    procedure   SetTransparents(Value:Boolean);
    procedure   SetYearNmListNumofDisp(Value:SmallInt);
    procedure   ChgYear(Sender:		TObject);		{ 年変更  }
    procedure   ChgMonth(Sender:TObject);			{ 月変更  }
    procedure   ChgDay(Sender:TObject);				{ 日変更  }
    procedure   CreateCalendar(Sender:TObject);
    procedure   OkClick(Sender:TObject);
    procedure   NextYear(Sender:TObject);
    procedure   PrevYear(Sender:TObject);
    procedure   DestClender;
    procedure   OwnerFormResize(Sender:TObject);
    procedure   FormMouseDown(Sender:TObject;Button:TMouseButton;
                             Shift: TShiftState; X, Y: Integer);
// 20000322 >>
    procedure   OnKeyDownJpnList(Sender: TObject; var Key: Word;
                  Shift: TShiftState);
    procedure   OnKeyUpJpnList(Sender: TObject; var Key: Word;
                  Shift: TShiftState);
    function GetParentWin:HWND;
// 20000322 <<
// 20000323 >>
    procedure   OnDeactivateBkPnel(Sender: TObject);
// 20000323 <<
//  procedure   OnOwnerFormClose(Sender: TObject; var Action: TCloseAction); // THDateEditﾒｲﾝﾌｫｰﾑ Closeｲﾍﾞﾝﾄ 20000904 add kubochi
    procedure   OnOwnerFormDestroy(Sender: TObject); // THDateEditﾒｲﾝﾌｫｰﾑ destroyｲﾍﾞﾝﾄ 20000925 add kubochi

  protected
    procedure   AttachChildren;
    procedure   SetupChildren;
    procedure   AlignChildren;
    function    GetControlByTab(ATabOrder:Integer):TWinControl;
    function    GetFirstEnableControl:TWinControl;
    function    GetPrevEnableControl:TWinControl;
    function    GetNextEnableControl:TWinControl;
    procedure   DecCurPos(CrntEdit:THEdit);
    procedure   IncCurPos(CrntEdit:THEdit);
    function    GetInitEdit:THEdit;
    function    CheckExtCase(Key:Word; Shift:TShiftState):Boolean;
    function    CheckNecessary:Boolean;
    function    IsDataEmpty:Boolean;
    procedure   LoadIniFile;
    function    LoadGengou(AGengous:TList):Boolean;
    function    LoadJpnYears(JpnYearsList:TList):Boolean;
    function    GetYearNameIndex(YearName:String):Integer;

    procedure   OnKeyDownEdits(Sender:TObject; var Key:Word; Shift:TShiftState);
    procedure   OnKeyUpEdits(Sender:TObject; var Key:Word; Shift:TShiftState);
    procedure   OnMouseDownEdits(Sender:TObject; Button:TMouseButton; Shift:TShiftState; X, Y:Integer);
    procedure   OnMouseUpEdits(Sender:TObject; Button:TMouseButton; Shift:TShiftState; X, Y:Integer);
    procedure   OnDblClickEdits(Sender:TObject);
    procedure   OnKeyPressEdits(Sender:TObject; var Key:Char);
    procedure   OnEnterEdits(Sender:TObject);
    procedure   OnExitEdits(Sender:TObject);
    procedure   OnChangeEdits(Sender:TObject);
    procedure   OnEnterJpnList(Sender:TObject);
    procedure   OnMouseDownJpnList(Sender:TObject; Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
    procedure   OnJpnFormDestroy(Sender: TObject);                              // 2001.02.15 追加

    procedure   CreateParams(var Params:TCreateParams); override;
    procedure   DoEnter; override;
    procedure   DoExit; override;
    procedure   CMFontChanged(var Message:TMessage); message CM_FONTCHANGED;
    procedure   Flesh;
    procedure   OnSubClassWndProc(var Message: TMessage);                       // 2000.11.13 追加
  public
    constructor Create(AOwner:TComponent); override;
    destructor  Destroy; override;
    procedure   SetDate(AYear, AMonth, ADay:Integer);
    procedure   GetDate(var AYear, AMonth, ADay:Integer);
    procedure   Clear;
    function    CanExit(Key:Word; Shift:TShiftState):Boolean;
    function    CheckInputData:TWinControl;
    procedure   SetFocus; override;
    property    LongDate:Longint read GetLongDate write SetLongDate stored False;
    procedure   Loaded; override;

  published
    property    Version: TVersion read FVersion write FVersion stored False;
    property    DateFormat:TDateFormat read FDateFormat write SetDateFormat;
    property    DateSequence:TDateSequence read FDateSequence write SetDateSequence;
    property    Options:TDateEditOptions read FOptions write SetOptions;
    property    LabelY:String read FLabelY write SetLabelY;
    property    LabelM:String read FLabelM write SetLabelM;
    property    LabelD:String read FLabelD write SetLabelD;
    property    GengouSection:String read FGengouSection write SetGengouSection;
    property    BorderStyle:TBorderStyle read FBorderStyle write SetBorderStyle;
    property    Ctl3D:Boolean read FCtl3D write SetCtl3D;
    property    Color:TColor read FColor write SetColor;
    property    JpnYearCol:Integer read FJpnYearCol write SetJpnYearCol;
    property    TabStop:Boolean read FTabStop write SetTabStop;
    property    ReadOnly:Boolean read FReadOnly write SetReadOnly;
    property    LabelColor:TColor read FLabelColor write SetLabelColor;
    property    LabelSize:Integer read FLabelSize  write SetLabelSize;
    property    MenuType:Integer  read FMenuType   write SetMenuType;
    property    InitFocus:TDateInitFocus read FInitFocus write FInitFocus;
    property    EnabledEditors:TDateEnabledEditors read FEnabledEditors write SetEnabledEditors;
    property    NecessaryEditors:TDateNecessaryEditors read FNecessaryEditors write FNecessaryEditors;
    property    ExtCase:TExtCase read FExtCase write SetExtCase;
    property    YearName:String read GetYearName write SetYearName;
    property    ImeMode:TImeMode read FImeMode write SetImeMode;
    property    Transparents:Boolean read FTransparents write SetTransparents default false;
    property    YearNmListNumofDisp:SmallInt read FYearNmListNumofDisp write SetYearNmListNumofDisp default 3;

    property    OnDblClick:TNotifyEvent read FOnDblClick write FOnDblClick;
    property    OnKeyDown:TKeyEvent read FOnKeyDown write FOnKeyDown;
    property    OnKeyUp:TKeyEvent read FOnKeyUp write FOnKeyUp;
    property    OnMouseDown:TMouseEvent read FOnMouseDown write FOnMouseDown;
    property    OnMouseUp:TMouseEvent read FOnMouseUp write FOnMouseUp;
    property    OnChange:TNotifyEvent read FOnChange write FOnChange;
    property    Font;
    property    Enabled;
    property    Visible;
    property    TabOrder;
    property    OnEnter;
    property    OnExit;
  end;

{$WARNINGS ON}

  { ﾌﾟﾛｼｰｼﾞｬ、関数宣言 }
{$IFNDEF HREG}
  procedure   Register;                               { ｺﾝﾎﾟｰﾈﾝﾄの登録 }
{$ENDIF}
  function    YearToGengou(AJpnYears:TList;gengo:string;AYear:Integer; AGengous:TList;var NewYear:Integer):String;
  function    ConvertCrsYear(JpnYears:TList; AName:String; AYear, AMonth, ADay:Integer):Integer;
  procedure   ConvertJpnYear(JpnYears: TList; AYear, AMonth, ADay: Integer;
                               var JpnYearName: String; var JpnYearYear: Integer);

//                                                                              2000.07.21 削除
//  function genset(var gengo:TGEN_REC):SmallInt;stdcall;
//  function swchg(lSdate:LongInt;szGen:Pointer;cRya:Pointer):LongInt;stdcall;
//  function wschg(lWdate:LongInt;cRya:PChar):LongInt;stdcall;
//  function sdateget1(sYy:PSmallInt;sMm:PSmallInt;sDd:PSmallInt):SmallInt;stdcall;
//  function sdateget2:LongInt;stdcall;
//  function DateAdd( kb:SmallInt;ymd:LongInt;addymd:LongInt):LongInt;stdcall;
//  function daycheck( kb1:SmallInt; yymmdd:LongInt ):LongInt;stdcall;
var
  PaintFlg:integer;			{ Paintｺﾝﾄﾛｰﾙ用ﾌﾗｸﾞ 0:RepaintOK, 1:RepaintNG}
  PaintFlg2:integer;			{ Paintｺﾝﾄﾛｰﾙ用ﾌﾗｸﾞ 0:RepaintOK, 1:RepaintNG}
  CHFrame :TComponent = nil;	        { HFrameｺﾝﾄﾛｰﾙ	}
  Rbutton: Integer;
{
******************************************************************************
    implementation部
******************************************************************************
}
implementation
{ ﾌﾟﾗｲﾍﾞｰﾄな参照、型宣言 }
uses
  Windows, HLib{, DllMan},HFrame;

type
  TElemType = (etJpn, etYear, etMonth, etDay);

var
  giSearch: integer = 0;

//                                                                              2000.07.21 削除
//  function genset(var gengo:TGEN_REC):SmallInt;stdcall;
//  external 'HDATE.DLL'
//  function swchg(lSdate:LongInt;szGen:Pointer;cRya:Pointer):LongInt;stdcall;
//  external 'HDATE.DLL'
//  function wschg(lWdate:LongInt;cRya:PChar):LongInt;stdcall;
//  external 'HDATE.DLL'
//  function sdateget1(sYy:PSmallInt;sMm:PSmallInt;sDd:PSmallInt):SmallInt;stdcall;
//  external 'HDATE.DLL'
//  function sdateget2:LongInt;stdcall;
//  external 'HDATE.DLL'
//  function DateAdd( kb:SmallInt;ymd:LongInt;addymd:LongInt):LongInt;stdcall;
//  external 'HDATE.DLL'
//  function daycheck( kb1:SmallInt; yymmdd:LongInt ):LongInt;stdcall;
//  external 'HDATE.DLL'

{
---------------------------------------------------------------------------
  ｺﾝｽﾄﾗｸﾀ
---------------------------------------------------------------------------
}

constructor THDateEdit.Create(AOwner:TComponent);
begin
  { 派生元呼び出し }
  inherited Create(AOwner);
  FVersion := HDateEditVersion;

  { 派生元再設定 }
  ControlStyle := [csClickEvents, csFramed, csDoubleClicks, csFixedHeight];
  ParentCtl3D  := False;

  { ﾒﾝﾊﾞ初期化 }
  FDateFormat       := df4Y2M2D;
  FDateSequence     := dsYMD;
  FOptions          := [deoSeparate];
  FLabelY           := kDefLabelY;
  FLabelM           := kDefLabelM;
  FLabelD           := kDefLabelD;
  FBorderStyle      := bsSingle;
  FCtl3D            := True;
  FColor            := clWhite;
  FJpnYearCol       := kDefJpnYearCol;
  FTabStop          := True;
  FOnChange         := nil;
  FLabelColor       := clWindowText;
  FLabelSize        := 11;
  FMenuType         := 0;
  FInitFocus        := difNone;
  FEnabledEditors   := [deeJpn, deeYear, deeMonth, deeDay];
  FNecessaryEditors := [];
  FExtCase          := TExtCase.Create;
  FImeMode          := imDontCare;

// 20000322 >>
  JpnForm           := nil;
// 20000322 <<
// 20000323 >>
  BkPnel            := nil;
  Clender           := nil;
  OkPnel            := nil;
  NgPnel            := nil;
  NxtPnel           := nil;
  PrvPnel           := nil;
// 20000323 <<
  JpnList           := nil;
  JpnYears          := nil;
  Gengous           := nil;
  YearEdit          := nil;
  MonthEdit         := nil;
  DayEdit           := nil;
  YearLabel         := nil;
  MonthLabel        := nil;
  DayLabel          := nil;
  IsJpnListOpened   := False;
  JpnYearsNotLoaded := True;
  IsDateSetting     := False;
  Clender           := nil;
  FYearNmListNumofDisp := 3;

  TForm(AOwner).OnResize := OwnerFormResize  ;
//  FOnClose := TForm(AOwner).OnClose;           // ﾒｲﾝ画面Closeｲﾍﾞﾝﾄ保存            20000904 add kubochi  20000906 del kubochi
//  TForm(AOwner).OnClose  := OnOwnerFormClose ; // THDateEdit ﾒｲﾝ画面Closeｲﾍﾞﾝﾄ結合 20000904 add kubochi  20000906 del kubochi
  OnMouseDown := FormMouseDown;

  if (csDesigning in ComponentState) then
  begin
    { ﾌｫﾝﾄは常に固定ﾋﾟｯﾁ }
    Font.Pitch := fpFixed;
    Font.Name  := 'ＭＳ ゴシック';
    Font.Size  := 11;
  end else begin
//    FOnClose := TForm(AOwner).OnClose;           // ﾒｲﾝ画面Closeｲﾍﾞﾝﾄ保存            20000906 add kubochi
//    TForm(AOwner).OnClose  := OnOwnerFormClose ; // THDateEdit ﾒｲﾝ画面Closeｲﾍﾞﾝﾄ結合 20000906 add kubochi
    FOnDestroy := TForm(AOwner).OnDestroy;         // ﾒｲﾝ画面Destroyｲﾍﾞﾝﾄ保存          20000925 add kubochi
    TForm(AOwner).OnDestroy  := OnOwnerFormDestroy;// THDateEdit ﾒｲﾝ画面Destroyｲﾍﾞﾝﾄ結合 20000925 add kubochi
  end;

  { 子ｺﾝﾄﾛｰﾙ接続､ｾｯﾄｱｯﾌﾟ、配置 }
  AttachChildren;
  SetupChildren;
  AlignChildren;
end;

{
---------------------------------------------------------------------------
  ﾃﾞｽﾄﾗｸﾀ
---------------------------------------------------------------------------
}
destructor  THDateEdit.Destroy;
begin
// 20000322 >>
  if JpnList <> nil then
  begin
    JpnList.Free;
    JpnList := nil;
  end;
  //Application.ProcessMessages;  // 2009.09.10
  if JpnForm <> nil then
  begin
    JpnForm.Free;
    JpnForm := nil;
  end;
  //Application.ProcessMessages;  // 2009.09.10

// 20000322 <<

  FExtCase.Free;

  { 派生元呼び出し }
  inherited Destroy;
end;

procedure  THDateEdit.Loaded;
begin
  SetChildrenName;

  // 親のイベントを横取り                                                       2000.11.13 追加
  if not (csDesigning in ComponentState) then begin
    OrgOnMessageHandler := TControl(Parent).WindowProc;
    TControl(Parent).WindowProc := OnSubClassWndProc;
  end;

end;

procedure  THDateEdit.SetChildrenName;
begin
  if Assigned(JpnEdit) then
  begin
    JpnEdit.Name:= Name+'Jpn';
    JpnEdit.Text := '';
  end;
  if Assigned(YearEdit) then
  begin
    YearEdit.Name:= Name+'Year';
    YearEdit.Text:='';
  end;
  if Assigned(MonthEdit) then
  begin
    MonthEdit.Name:= Name+'Month';
    MonthEdit.Text:='';
  end;
  if Assigned(DayEdit) then
  begin
    DayEdit.Name := Name+'Day';
    DayEdit.Text:='';
  end;
  if Assigned(JpnList) then
  begin
    JpnList.Name := Name+'JpnList';
  end;
  //ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰの名前登録
  if Assigned(PopMenu) then
  begin
    PopMenu.Name := Name+'PopMenu';
  end;
end;

{
---------------------------------------------------------------------------
  日付の設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetDate(AYear, AMonth, ADay:Integer);
var
  YY, MM, DD:Word;
  S:String;
  N:Integer;
begin
  IsDateSetting := True;

  { ｼｽﾃﾑ日付取得 }
  DecodeDate(Date, YY, MM, DD);
  if AYear  = -1 then AYear  := YY;
  if AMonth = -1 then AMonth := MM;
  if ADay   = -1 then ADay   := DD;
  { 年 }
  if (YearEdit <> nil) and (AYear <> 0) then
  begin
    if JpnEdit = nil then
      YearEdit.DataText := SpnStrR(IntToStr(AYear), YearEdit.ExtEdit.Column)
    else
    begin
//西暦和暦変換
      ConvertJpnYear(JpnYears, AYear, AMonth, ADay,S, N);
      JpnEdit.Text      := S;
      YearEdit.DataText := SpnStrR(IntToStr(N), YearEdit.ExtEdit.Column);
    end;
  end;

  { 月 }
  if (MonthEdit <> nil) and (AMonth <> 0) then
    MonthEdit.DataText := SpnStrR(IntToStr(AMonth), MonthEdit.ExtEdit.Column);

  { 日 }
  if (DayEdit <> nil) and (ADay <> 0) then
    DayEdit.DataText := SpnStrR(IntToStr(ADay), DayEdit.ExtEdit.Column);

  IsDateSetting := False;
end;

{
---------------------------------------------------------------------------
  日付の取得
---------------------------------------------------------------------------
}
procedure   THDateEdit.GetDate(var AYear, AMonth, ADay:Integer);
begin
  // 例外発生時、値を初期化するように変更                                       // 2003.08.18 変更
  { 月 }
  try                                                                           // 2003.08.18 変更
    if MonthEdit = nil              then AMonth := -1
    else if MonthEdit.DataText = '' then AMonth := -1
    else                                 AMonth := StrToInt(MonthEdit.DataText);
  except
    AMonth := -1;
    MonthEdit.DataText := '';
  end;

  { 日 }
  try                                                                           // 2003.08.18 変更
    if DayEdit = nil              then ADay := -1
    else if DayEdit.DataText = '' then ADay := -1
    else                               ADay := StrToInt(DayEdit.DataText);
  except
    ADay := -1;
    DayEdit.DataText := '';
  end;

  { 年 }                                                                        // 2003.08.18 変更
  try
    if YearEdit = nil              then AYear := -1
    else if YearEdit.DataText = '' then AYear := -1
    else if StrToInt(YearEdit.DataText) = 0 then AYear := -1
    else if JpnEdit = nil          then AYear := StrToInt(YearEdit.DataText)
//和暦西暦変換
    else AYear := ConvertCrsYear(JpnYears, JpnEdit.Text, StrToInt(YearEdit.DataText), AMonth, ADay);
  except
    AYear := -1;
    YearEdit.DataText := '';
  end;

end;

{
---------------------------------------------------------------------------
  入力項目のｸﾘｱ
---------------------------------------------------------------------------
}
procedure   THDateEdit.Clear;
begin
  IsDateSetting := True;
  NowSettingLongDate := True;

  if YearEdit  <> nil then YearEdit.DataText  := '';
  if MonthEdit <> nil then MonthEdit.DataText := '';
  if DayEdit   <> nil then DayEdit.DataText   := '';
  if JpnEdit   <> nil then JpnEdit.DataText  := FYearName;

  IsDateSetting := False;
  NowSettingLongDate := False;

  LongDateBuf := 0;
end;

{
---------------------------------------------------------------------------
  脱出可能かどうか調べる
---------------------------------------------------------------------------
}
{$WARNINGS OFF}
function    THDateEdit.CanExit(Key:Word; Shift:TShiftState):Boolean;
var
  NextEdit:TWinControl;
begin
  { 脱出要件ﾁｪｯｸ }
  if CheckExtCase(Key, Shift) = FALSE then
    Result := FALSE

  { 入力必須ﾁｪｯｸ }
  else if CheckNecessary = FALSE then
    Result := FALSE

  { TABｷｰ }
  else if Key = VK_TAB then
    Result := (Shift = []) or (Shift = [ssShift])

  { ﾘﾀｰﾝｷｰ }
  else if Key = VK_RETURN then
  begin
    if Shift = [ssShift] then NextEdit := GetPrevEnableControl
    else if Shift = []   then NextEdit := GetNextEnableControl
    else                      NextEdit := CurrentEdit;
    Result := NextEdit = nil;
  end

  { 上下矢印ｷｰ }
  else if (Key = VK_UP) or (Key = VK_DOWN) then
  begin
    if (CurrentEdit=JpnEdit) and (deoYearNameList in FOptions) then
      Result := not ((CurrentEdit = JpnEdit) and (deoYearNameList in FOptions))
  end

  { 左右矢印ｷｰ }
  else if (Key = VK_LEFT) or (Key = VK_RIGHT) then
  begin
    case Key of
      VK_LEFT:  NextEdit := GetPrevEnableControl;
      VK_RIGHT: NextEdit := GetNextEnableControl;
    end;
    Result := NextEdit = nil;
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
  ｱｸﾃｨﾌﾞ化
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetFocus;
var
  NextEdit:TWinControl;
begin
  { 初期入力項目の設定 }
  NextEdit := GetInitEdit;
  if NextEdit = nil then
    NextEdit := GetFirstEnableControl;

  if NextEdit <> nil then NextEdit.SetFocus
  else                    inherited SetFocus;
end;

{
---------------------------------------------------------------------------
  DataFormatﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetDateFormat(Value:TDateFormat);
begin
  if Value <> FDateFormat then
  begin
    FDateFormat := Value;

    { 子ｺﾝﾄﾛｰﾙ接続､ｾｯﾄｱｯﾌﾟ、配置 }
    AttachChildren;
    SetupChildren;
    AlignChildren;
  end;
end;

{
---------------------------------------------------------------------------
  DataSequenceﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetDateSequence(Value:TDateSequence);
begin
  if Value <> FDateSequence then
  begin
    FDateSequence := Value;

    { 子ｺﾝﾄﾛｰﾙ配置 }
    AlignChildren;
  end;
end;

{
---------------------------------------------------------------------------
  Optionsﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetOptions(Value:TDateEditOptions);
begin
  if Value <> FOptions then
  begin
    FOptions := Value;

    { deoSeparateの反映 }
    if deoSeparate in FOptions then
    begin
      inherited Ctl3D := False;
      ParentColor     := True
    end else
    begin
      inherited Ctl3D := FCtl3D;
      ParentColor     := False;
      inherited Color := FColor;
    end;

    RecreateWnd;

    { 子ｺﾝﾄﾛｰﾙｾｯﾄｱｯﾌﾟ、配置 }
    SetupChildren;
    AlignChildren;
  end;
end;

{
---------------------------------------------------------------------------
  LabelYﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetLabelY(Value:String);
begin
  if Value = '' then Value := ' ';

  if Value <> FLabelY then
  begin
    FLabelY := Value;

    { 子ｺﾝﾄﾛｰﾙｾｯﾄｱｯﾌﾟ、配置 }
    SetupChildren;
    AlignChildren;
  end;
end;

{
---------------------------------------------------------------------------
  LabelMﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetLabelM(Value:String);
begin
  if Value = '' then Value := ' ';

  if Value <> FLabelM then
  begin
    FLabelM := Value;

    { 子ｺﾝﾄﾛｰﾙｾｯﾄｱｯﾌﾟ、配置 }
    SetupChildren;
    AlignChildren;
  end;
end;

{
---------------------------------------------------------------------------
  LabelDﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetLabelD(Value:String);
begin
  if Value = '' then Value := ' ';

  if Value <> FLabelD then
  begin
    FLabelD := Value;

    { 子ｺﾝﾄﾛｰﾙｾｯﾄｱｯﾌﾟ、配置 }
    SetupChildren;
    AlignChildren;
  end;
end;

{
---------------------------------------------------------------------------
  GengouSectionﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetGengouSection(Value:String);
begin
  if Value <> FGengouSection then
  begin
    FGengouSection := Value;

    { 再ﾛｰﾄﾞ }
    if Gengous <> nil then
      LoadIniFile;
  end;
end;

{
---------------------------------------------------------------------------
  BorderStyleﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetBorderStyle(Value:TBorderStyle);
begin
  if Value <> FBorderStyle then
  begin
    FBorderStyle := Value;
    RecreateWnd;

    { 子ｺﾝﾄﾛｰﾙｾｯﾄｱｯﾌﾟ、配置 }
    SetupChildren;
    AlignChildren;
  end;
end;

{
---------------------------------------------------------------------------
  Ctl3Dﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetCtl3D(Value:Boolean);
begin
  if Value <> FCtl3D then
  begin
    FCtl3D := Value;

    if deoSeparate in FOptions then
    begin
      inherited Ctl3D := False;
      SetupChildren;
    end else
      inherited Ctl3D := FCtl3D;
  end;
end;

{
---------------------------------------------------------------------------
  Colorﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetColor(Value:TColor);
begin
  if Value <> FColor then
  begin
    FColor := Value;

    if deoSeparate in FOptions then
      SetupChildren
    else
      inherited Color := FColor;
  end;
end;

{
---------------------------------------------------------------------------
  JpnYearColﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetJpnYearCol(Value:integer);
begin
  if Value <> FJpnYearCol then
  begin
    FJpnYearCol := Value;

    { 子ｺﾝﾄﾛｰﾙｾｯﾄｱｯﾌﾟ、配置 }
    SetupChildren;
    AlignChildren;
  end;
end;

{
---------------------------------------------------------------------------
  TabStopﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetTabStop(Value:Boolean);
begin
  if Value <> FTabStop then
  begin
    FTabStop := Value;

    { 子ｺﾝﾄﾛｰﾙｾｯﾄｱｯﾌﾟ }
    SetupChildren;
  end;
end;

{
---------------------------------------------------------------------------
  LongDateﾌﾟﾛﾊﾟﾃｨの取得
---------------------------------------------------------------------------
}
function    THDateEdit.GetLongDate:Longint;
begin
  Result := LongDateBuf;
end;

{
---------------------------------------------------------------------------
  LongDateﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetLongDate(Value:Longint);
var
  YY, MM, DD:Integer;
begin
  if Value <> LongDateBuf then
  begin
//    if Value = -1 then                                                        2001.12.11 変更
    if (Value = -1) or (Value = 0)then
      Clear
    else
    begin
      NowSettingLongDate := True;
      LongDateBuf := Value;
      DecodeLongDate(Value, YY, MM, DD);
      SetDate(YY, MM, DD);
      NowSettingLongDate := False;
    end
  end;
end;

{
---------------------------------------------------------------------------
  ReadOnlyﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetReadOnly(Value:Boolean);
begin
  FReadOnly := Value;

  { 子ｺﾝﾄﾛｰﾙｾｯﾄｱｯﾌﾟ }
  SetupChildren;
end;

{
---------------------------------------------------------------------------
  LabelColorﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetLabelColor(Value:TColor);
begin
  if Value <> FLabelColor then
  begin
    FLabelColor := Value;

    { 子ｺﾝﾄﾛｰﾙｾｯﾄｱｯﾌﾟ }
    SetupChildren;
  end;
end;

{
---------------------------------------------------------------------------
  LabelSizeﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetLabelSize(Value:Integer);
begin
  if (Value <> FLabelSize) then
  begin
    FLabelSize := Value;

    { 子ｺﾝﾄﾛｰﾙｾｯﾄｱｯﾌﾟ }
    SetupChildren;
    AlignChildren;
  end;
end;

{
---------------------------------------------------------------------------
  MenuTypeﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetMenuType(Value:Integer);
begin
  if (Value <> FMenuType) then
  begin
    FMenuType := Value;
  end;
end;

{
---------------------------------------------------------------------------
  EnabledEditorsﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetEnabledEditors(Value:TDateEnabledEditors);
begin
  if Value <> FEnabledEditors then
  begin
    FEnabledEditors := Value;
    SetupChildren;
  end;
end;

{
---------------------------------------------------------------------------
  ExtCaseﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetExtCase(Value:TExtCase);
begin
  FExtCase.Assign(Value);
end;

{
---------------------------------------------------------------------------
  YearNameﾌﾟﾛﾊﾟﾃｨの取得
---------------------------------------------------------------------------
}
function    THDateEdit.GetYearName:String;
begin
  if JpnEdit <> nil then
    Result := JpnEdit.DataText
  else
    Result := '';
end;

{
---------------------------------------------------------------------------
  YearNameﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetYearName(Value:String);
begin
  FYearName := Value;

  if JpnEdit <> nil then
    JpnEdit.DataText := Value;
end;

{
---------------------------------------------------------------------------
  ImeModeﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetImeMode(Value:TImeMode);
begin
  if Value <> FImeMode then
  begin
    FImeMode := Value;
    SetupChildren;
  end;
end;

{ ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ要素の接続 }
procedure   THDateEdit.AttachPopElems(Attach:Boolean);
var
  ix:	Integer;
  yy:   smallint;
  mm:   smallint;
  dd:   smallint;

begin
  if Attach and (PopMenu = nil) then
  begin
    PopMenu  := TPopupMenu.Create(Self);
    PopMenu.AutoHotkeys := maManual;
    //ｻﾌﾞﾒﾆｭｰ項目をｾｯﾄ
    SubItems[0] := TMenuItem.Create(Self);
    SubItems[0].AutoHotkeys := maManual;
    SubItems[0].Caption := 'システム日付';
    SubItems[0].OnClick := SysDateGet;
    PopMenu.Items.Add(SubItems[0]);
    SubItems[1] := TMenuItem.Create(Self);
    SubItems[1].AutoHotkeys := maManual;
    SubItems[1].Caption := '年変更';
    PopMenu.Items.Add(SubItems[1]);

    //年項目設定
    HDATE.sdateget1(yy,mm,dd);                                               // 2000.09.11 追加
    for ix:=0 to 5 do
    begin
      SItemYear[ix]:= TMenuItem.Create(Self);
      SItemYear[ix].AutoHotkeys := maManual;
      SItemYear[ix].Caption := IntToStr(yy+(ix-2));                             // 2000.09.11 追加
      SItemYear[ix].Tag := ix;
      SItemYear[ix].OnClick := ChgYear;
      SubItems[1].Add(SItemYear[ix]);
    end;

    //月項目設定
    SubItems[2] := TMenuItem.Create(Self);
    SubItems[2].Caption := '月変更';
    PopMenu.Items.Add(SubItems[2]);

    for ix:=0 to 11 do
    begin
      SItemMonth[ix]:= TMenuItem.Create(Self);
      SItemMonth[ix].AutoHotkeys := maManual;
      SItemMonth[ix].Caption := IntToStr(ix+1);
      SItemMonth[ix].Tag := ix;
      SItemMonth[ix].OnClick := ChgMonth;
      SubItems[2].Add(SItemMonth[ix]);
    end;

    //日項目設定
    SubItems[3] := TMenuItem.Create(Self);
    SubItems[3].Caption := '日変更';
    PopMenu.Items.Add(SubItems[3]);

    for ix:=0 to 30 do
    begin
      SItemDay[ix]:= TMenuItem.Create(Self);
      SItemDay[ix].AutoHotkeys := maManual;
      SItemDay[ix].Caption := IntToStr(ix+1);
      SItemDay[ix].Tag := ix;
      SItemDay[ix].OnClick := ChgDay;
      SubItems[3].Add(SItemDay[ix]);
    end;

    SubItems[4] := TMenuItem.Create(Self);
    SubItems[4].AutoHotkeys := maManual;
    SubItems[4].Caption := 'カレンダー';
    SubItems[4].OnClick := CreateCalendar;
    PopMenu.Items.Add(SubItems[4]);

    //元号項目に接続
    if JpnEdit <> Nil then
      JpnEdit.PopupMenu := PopMenu;
    //年項目に接続
    if YearEdit <> Nil then
      YearEdit.PopupMenu := PopMenu;
    //月項目に接続
    if MonthEdit <> Nil then
      MonthEdit.PopupMenu := PopMenu;
    //日項目に接続
    if DayEdit <> Nil then
      DayEdit.PopupMenu := PopMenu;
  end else if Attach and (PopMenu <>Nil) then
  begin
    //元号項目に接続
    if JpnEdit <> Nil then
      JpnEdit.PopupMenu := PopMenu;
    //年項目に接続
    if YearEdit <> Nil then
      YearEdit.PopupMenu := PopMenu;
    //月項目に接続
    if MonthEdit <> Nil then
      MonthEdit.PopupMenu := PopMenu;
    //日項目に接続
    if DayEdit <> Nil then
      DayEdit.PopupMenu := PopMenu;
  end else if not Attach and (PopMenu <> nil) then
  begin
    for ix:=0 to 5 do
    begin
      SItemYear[ix].Free;
      SItemYear[ix] := nil;
    end;
    for ix:=0 to 11 do
    begin
      SItemMonth[ix].Free;
      SItemMonth[ix] := nil;
    end;
    for ix:=0 to 2 do
    begin
      SubItems[ix].Free;
      SubItems[ix] := nil;
    end;
    PopMenu.Free;  PopMenu  := nil;
  end
end;

{
---------------------------------------------------------------------------
  子ｺﾝﾄﾛｰﾙ接続
---------------------------------------------------------------------------
}
procedure   THDateEdit.AttachChildren;
  { 元号要素の接続 }
  procedure   AttachJpnElems(Attach:Boolean);
  var
    i:Integer;
  begin
    if Attach and (JpnEdit = nil) then
    begin
      JpnEdit := THEdit.Create(Self);
      JpnEdit.Text := '';
      JpnEdit.OnKeyDown   := OnKeyDownEdits;
      JpnEdit.OnKeyUp     := OnKeyUpEdits;
      JpnEdit.OnMouseDown := OnMouseDownEdits;
      JpnEdit.OnMouseUp   := OnMouseUpEdits;
      JpnEdit.OnDblClick  := OnDblClickEdits;
      JpnEdit.OnKeyPress  := OnKeyPressEdits;
      JpnEdit.OnEnter     := OnEnterEdits;
      JpnEdit.OnExit      := OnExitEdits;
      JpnEdit.OnChange    := OnChangeEdits;
      InsertControl(JpnEdit);

      { 元号ﾘｽﾄ生成 }
      JpnYears := TList.Create;
      Gengous := TList.Create;
      LoadIniFile;

// 20000322 >> 元号ﾘｽﾄ用ﾌｫｰﾑの作成
      if not (csDesigning in ComponentState) then
      begin

        JpnForm := TForm.Create(Owner);
        if JpnForm <> nil then
        begin
          with JpnForm do
          begin
            BorderStyle  := bsNone;
            height       := kJpnListHeight;
            width        := 100;
            top          :=  0;
            left         :=  0;
            color        := clBtnFace;
            tag          := 0 ;
            caption      := '';
            OnDestroy    := OnJpnFormDestroy;                                   // 2001.02.15 追加
          end;
          JpnForm.name   := 'JpnForm' + name ;
        end else Exit;
        { 元号ﾘｽﾄﾎﾞｯｸｽ生成 }
        JpnList := TListBox.Create(JpnForm);
        if JpnList <> nil then
        begin
          with JpnList do
          begin
            Parent  := JpnForm;
            OnEnter := OnEnterJpnList;
            OnKeyDown := OnKeyDownJpnList;
            OnKeyUp := OnKeyUpJpnList;
            OnMouseDown := OnMouseDownJpnList;
            Height := kJpnListHeight;
          end;
        end else Exit;
      end;
//↓↓↓DEL↓↓↓
//    JpnList := TListBox.Create(Self);
//    JpnList.OnEnter := OnEnterJpnList;
//    JpnList.OnMouseDown := OnMouseDownJpnList;
//    JpnList.Height := kJpnListHeight;
// 20000322 <<
    end else if not Attach and (JpnEdit <> nil) then
    begin
      RemoveControl(JpnEdit);
      JpnEdit.Free;
      JpnEdit := nil;

      { 元号ﾘｽﾄ破棄 }
      for i := 0 to JpnYears.Count - 1 do
        TJpnYear(JpnYears.Items[i]).Free;
      JpnYears.Free;
      JpnYears := nil;
      for i := 0 to Gengous.Count - 1 do
        TGengouNode(Gengous.Items[i]).Free;
      Gengous.Free;
      Gengous := nil;

// 20000322 >> 元号ﾌｫｰﾑ破棄
     // 破棄の際、Windowsに一旦制御を渡す                                       2000.08.05 追加
      if not (csDesigning in ComponentState) then
      begin
        { 元号ﾘｽﾄﾎﾞｯｸｽ破棄 }
        if JpnList <> nil then
        begin
          JpnList.Free;
          JpnList := nil;
        end;
        Application.ProcessMessages;
        if JpnForm <> nil then
        begin
          JpnForm.Free;
          JpnForm := nil;
        end;
        Application.ProcessMessages;
      end;
// 20000322 >>
    end
  end;

  { 年要素の接続 }
  procedure   AttachYearElems(Attach:Boolean);
  begin
    if Attach and (YearEdit = nil) then
    begin
      YearEdit  := THNedit.Create(Self); InsertControl(YearEdit);
      YearEdit.Text := '';
      YearLabel := TLabel.Create(Self);  InsertControl(YearLabel);
    end else if not Attach and (YearEdit <> nil) then
    begin
      RemoveControl(YearEdit);  YearEdit.Free;  YearEdit  := nil;
      RemoveControl(YearLabel); YearLabel.Free; YearLabel := nil;
    end
  end;

  { 月要素の接続 }
  procedure   AttachMonthElems(Attach:Boolean);
  begin
    if Attach and (MonthEdit = nil) then
    begin
      MonthEdit  := THNedit.Create(Self); InsertControl(MonthEdit);
      MonthEdit.Text := '';
      MonthLabel := TLabel.Create(Self);  InsertControl(MonthLabel);
    end else if not Attach and (MonthEdit <> nil) then
    begin
      RemoveControl(MonthEdit);  MonthEdit.Free;  MonthEdit  := nil;
      RemoveControl(MonthLabel); MonthLabel.Free; MonthLabel := nil;
    end
  end;

  { 日要素の接続 }
  procedure   AttachDayElems(Attach:Boolean);
  begin
    if Attach and (DayEdit = nil) then
    begin
      DayEdit  := THNedit.Create(Self); InsertControl(DayEdit);
      DayEdit.Text := '';
      DayLabel := TLabel.Create(Self);  InsertControl(DayLabel);
    end else if not Attach and (DayEdit <> nil) then
    begin
      RemoveControl(DayEdit);  DayEdit.Free;  DayEdit  := nil;
      RemoveControl(DayLabel); DayLabel.Free; DayLabel := nil;
    end
  end;

begin
  case  FDateFormat of
    df4Y2M2D, df2Y2M2D, dfG2Y2M2D:
    begin
      if FDateFormat = dfG2Y2M2D then AttachJpnElems(True)
      else                            AttachJpnElems(False);
      AttachYearElems(True);
      AttachMonthElems(True);
      AttachDayElems(True);
    end;
    df4Y2M, df2Y2M, dfG2Y2M:
    begin
      if FDateFormat = dfG2Y2M then AttachJpnElems(True)
      else                          AttachJpnElems(False);
      AttachYearElems(True);
      AttachMonthElems(True);
      AttachDayElems(False);
    end;
    df2M2D:
    begin
      AttachJpnElems(False);
      AttachYearElems(False);
      AttachMonthElems(True);
      AttachDayElems(True);
    end;
    df4Y, df2Y, dfG2Y:
    begin
      if FDateFormat = dfG2Y then AttachJpnElems(True)
      else                        AttachJpnElems(False);
      AttachYearElems(True);
      AttachMonthElems(False);
      AttachDayElems(False);
    end;
    df2M:
    begin
      AttachJpnElems(False);
      AttachYearElems(False);
      AttachMonthElems(True);
      AttachDayElems(False);
    end;
    df2D:
    begin
      AttachJpnElems(False);
      AttachYearElems(False);
      AttachMonthElems(False);
      AttachDayElems(True);
    end;
  end;

  SetChildrenName;

end;

{
---------------------------------------------------------------------------
  子ｺﾝﾄﾛｰﾙｾｯﾄｱｯﾌﾟ
---------------------------------------------------------------------------
}
procedure   THDateEdit.SetupChildren;
  { ｴﾃﾞｨｯﾄの桁数取得 }
  procedure   GetColumns(var AColY, AColM, AColD:Integer);
  begin
    case  FDateFormat of
      df4Y2M2D:            begin  AColY := 4; AColM := 2; AColD := 2; end;
      df2Y2M2D, dfG2Y2M2D: begin  AColY := 2; AColM := 2; AColD := 2; end;
      df4Y2M:              begin  AColY := 4; AColM := 2; AColD := 0; end;
      df2Y2M,dfG2Y2M:      begin  AColY := 2; AColM := 2; AColD := 0; end;
      df2M2D:              begin  AColY := 0; AColM := 2; AColD := 2; end;
      df4Y:                begin  AColY := 4; AColM := 0; AColD := 0; end;
      df2Y, dfG2Y:         begin  AColY := 2; AColM := 0; AColD := 0; end;
      df2M:                begin  AColY := 0; AColM := 2; AColD := 0; end;
      df2D:                begin  AColY := 0; AColM := 0; AColD := 2; end;
    end;
  end;

  { ﾗﾍﾞﾙの既定値設定 }
  procedure   SetDefLabelStyle(ALabel:TLabel);
  begin
    ALabel.AutoSize    := True;
    ALabel.ParentFont  := True;
    ALabel.ParentColor := True;
    ALabel.ParentFont  := True;
    ALabel.Font.Color  := FLabelColor;
    ALabel.Transparent := true;
    ALabel.Font.size   := FLabelSize;
  end;

  { ｴﾃﾞｨｯﾄの既定値設定 }
  procedure   SetDefEditStyle(AEdit:THEdit);
  begin
    if deoSeparate in FOptions then
    begin
      AEdit.BorderStyle := FBorderStyle;
      AEdit.Ctl3D       := FCtl3D;
      AEdit.ParentColor := False;
      AEdit.Color       := FColor;
      AEdit.TabStop     := FTabStop;
    end else
    begin
      AEdit.BorderStyle := bsNone;
      AEdit.Ctl3D       := False;
      AEdit.ParentColor := True;
    end;
    AEdit.ReadOnly          := FReadOnly;
    AEdit.AutoSize          := True;
    AEdit.ParentFont        := True;
    AEdit.ExtEdit.AutoWidth := True;
    AEdit.ImeMode           := FImeMode;

    AEdit.OnKeyDown   := OnKeyDownEdits;
    AEdit.OnKeyUp     := OnKeyUpEdits;
    AEdit.OnMouseDown := OnMouseDownEdits;
    AEdit.OnMouseUp   := OnMouseUpEdits;
    AEdit.OnDblClick  := OnDblClickEdits;
    AEdit.OnKeyPress  := OnKeyPressEdits;
    AEdit.OnEnter     := OnEnterEdits;
    AEdit.OnExit      := OnExitEdits;
    AEdit.OnChange    := OnChangeEdits;
  end;

var
  ColY, ColM, ColD:Integer;
begin
  { ﾗﾍﾞﾙの設定 }
  if YearLabel  <> nil then
  begin
    SetDefLabelStyle(YearLabel);
    YearLabel.Caption  := FLabelY;
  end;
  if MonthLabel <> nil then
  begin
    SetDefLabelStyle(MonthLabel);
    MonthLabel.Caption := FLabelM;
  end;
  if DayLabel   <> nil then
  begin
    SetDefLabelStyle(DayLabel);
    DayLabel.Caption   := FLabelD;
  end;

  { ｴﾃﾞｨｯﾄの設定 }
  GetColumns(ColY, ColM, ColD);
  if JpnEdit <> nil then
  begin
    SetDefEditStyle(JpnEdit);
    JpnEdit.ExtEdit.ColValid := cvSJisByteCount;                                // 2010.05.13 Add T.Sugawa
    JpnEdit.ExtEdit.Column := FJpnYearCol;
    if not (deeJpn in FEnabledEditors) then JpnEdit.ReadOnly := TRUE;
  end;
  if YearEdit <> nil then
  begin
    SetDefEditStyle(YearEdit);
    YearEdit.ExtEdit.Column    := ColY;
    YearEdit.NumEdit.CalcInput := True;
    YearEdit.NumEdit.MinusSupp := True;
    if deoZeroSuppY in FOptions then YearEdit.NumEdit.ZeroSupp := zsOn
    else                             YearEdit.NumEdit.ZeroSupp := zsFill;
    if not (deeYear in FEnabledEditors) then YearEdit.ReadOnly := TRUE;
  end;
  if MonthEdit <> nil then
  begin
    SetDefEditStyle(MonthEdit);
    MonthEdit.ExtEdit.Column    := ColM;
    MonthEdit.NumEdit.CalcInput := True;
(* Add matsu 1997-10-09 XNeditのマイナス値入力抑制変更に伴う *)
    MonthEdit.NumEdit.MinusSupp := True;
(* Add End *)
    if deoZeroSuppM in FOptions then MonthEdit.NumEdit.ZeroSupp := zsOn
    else                             MonthEdit.NumEdit.ZeroSupp := zsFill;
    if not (deeMonth in FEnabledEditors) then MonthEdit.ReadOnly := TRUE;
  end;
  if DayEdit <> nil then
  begin
    SetDefEditStyle(DayEdit);
    DayEdit.ExtEdit.Column    := ColD;
    DayEdit.NumEdit.CalcInput := True;
(* Add matsu 1997-10-09 XNeditのマイナス値入力抑制変更に伴う *)
    DayEdit.NumEdit.MinusSupp := True;
(* Add End *)
    if deoZeroSuppD in FOptions then DayEdit.NumEdit.ZeroSupp := zsOn
    else                             DayEdit.NumEdit.ZeroSupp := zsFill;
    if not (deeDay in FEnabledEditors) then DayEdit.ReadOnly := TRUE;
  end;
  //ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰの作成
  AttachPopElems(not FReadOnly);
end;

{
---------------------------------------------------------------------------
  子ｺﾝﾄﾛｰﾙ配置
---------------------------------------------------------------------------
}
{$WARNINGS OFF}
procedure   THDateEdit.AlignChildren;
  { 元号年月日単位の配置 }
  procedure   AlignElem(var AX, AY:Integer; var ATabOrder:Integer; Elem:TElemType);
  var
    Ctl3DThick:Integer;
    AEdit:THEdit;
    ALabel:TLabel;
  begin
    case Elem of
      etJpn:   begin  AEdit := JpnEdit;   ALabel := nil         end;
      etYear:  begin  AEdit := YearEdit;  ALabel := YearLabel;  end;
      etMonth: begin  AEdit := MonthEdit; ALabel := MonthLabel; end;
      etDay:   begin  AEdit := DayEdit;   ALabel := DayLabel;   end;
    end;

    if FCtl3D and (deoSeparate in FOptions) then
      Ctl3DThick := 1
    else
      Ctl3DThick := 0;

    if AEdit <> nil then
    begin
      AEdit.Top := Ctl3DThick;
      AEdit.Left := AX + Ctl3DThick;
      AEdit.TabOrder := ATabOrder;

      AX := AX + AEdit.Width + Ctl3DThick * 2;
      if AY < AEdit.Height  + Ctl3DThick * 2 then
        AY := AEdit.Height + Ctl3DThick * 2;
      Inc(ATabOrder);

      if ALabel <> nil then
      begin
        ALabel.Top := (AEdit.Height  + Ctl3DThick * 2 - ALabel.Height) div 2;
        ALabel.Left := AX;
        if ALabel.Caption <> '' then
        AX := AX + ALabel.Width;
        if AY < ALabel.Height then
          AY := ALabel.Height;
      end;
    end;
  end;

var
  X, Y:Integer;
  TabOrder:Integer;
begin
  X := 0;
  Y := 0;
  TabOrder := 1;

  case FDateSequence of
    dsYMD:
    begin
      AlignElem(X, Y, TabOrder, etJpn); AlignElem(X, Y, TabOrder, etYear);
      AlignElem(X, Y, TabOrder, etMonth);
      AlignElem(X, Y, TabOrder, etDay);
    end;
    dsYDM:
    begin
      AlignElem(X, Y, TabOrder, etJpn); AlignElem(X, Y, TabOrder, etYear);
      AlignElem(X, Y, TabOrder, etDay);
      AlignElem(X, Y, TabOrder, etMonth);
    end;
    dsMDY:
    begin
      AlignElem(X, Y, TabOrder, etMonth);
      AlignElem(X, Y, TabOrder, etDay);
      AlignElem(X, Y, TabOrder, etJpn); AlignElem(X, Y, TabOrder, etYear);
    end;
    dsMYD:
    begin
      AlignElem(X, Y, TabOrder, etMonth);
      AlignElem(X, Y, TabOrder, etJpn); AlignElem(X, Y, TabOrder, etYear);
      AlignElem(X, Y, TabOrder, etDay);
    end;
    dsDYM:
    begin
      AlignElem(X, Y, TabOrder, etDay);
      AlignElem(X, Y, TabOrder, etJpn); AlignElem(X, Y, TabOrder, etYear);
      AlignElem(X, Y, TabOrder, etMonth);
    end;
    dsDMY:
    begin
      AlignElem(X, Y, TabOrder, etDay);
      AlignElem(X, Y, TabOrder, etMonth);
      AlignElem(X, Y, TabOrder, etJpn); AlignElem(X, Y, TabOrder, etYear);
    end;
  end;


  { ｺﾝﾎﾟｰﾈﾝﾄｻｲｽﾞの確定 }
  if (FBorderStyle = bsSingle) and not (deoSeparate in FOptions) then
  begin
    Width  := X + GetSystemMetrics(SM_CXBORDER) * 2;
    Height := y + GetSystemMetrics(SM_CYBORDER) * 2;
  end else
  begin
    Width  := X;
    Height := y;
  end;
end;
{$WARNINGS ON}

{
---------------------------------------------------------------------------
  ﾀﾌﾞｵｰﾀﾞｰから子ｺﾝﾄﾛｰﾙを取得する
---------------------------------------------------------------------------
}
function    THDateEdit.GetControlByTab(ATabOrder:Integer):TWinControl;
var
  i:Integer;
begin
  Result := nil;
  for i := 0 to ControlCount - 1 do
  begin
    if not (Controls[i] is TWinControl) then
      continue;
    if TWinControl(Controls[i]).TabOrder <> ATabOrder then
      continue;
    Result := TWinControl(Controls[i]);
    Break;
  end;
end;

{
---------------------------------------------------------------------------
  先頭の入力可能な子ｺﾝﾄﾛｰﾙを取得する
---------------------------------------------------------------------------
}
function    THDateEdit.GetFirstEnableControl:TWinControl;
var
  i:Integer;
begin
  Result := nil;
  for i := 0 to ControlCount - 1 do
  begin
    Result := GetControlByTab(i);
    if Result = nil                     then Exit
    else if not THEdit(Result).ReadOnly then Exit
    else
    begin
      Result := nil;
      Continue;
    end;
  end;
end;

{
---------------------------------------------------------------------------
  前の入力可能な子ｺﾝﾄﾛｰﾙを取得する
---------------------------------------------------------------------------
}
function    THDateEdit.GetPrevEnableControl:TWinControl;
var
  i:Integer;
begin
  Result := nil;
  for i := CurrentEdit.TabOrder - 1 downto 0 do
  begin
    Result := GetControlByTab(i);
    if Result = nil                     then Exit
    else if not THEdit(Result).ReadOnly then Exit
    else
    begin
      Result := nil;
      Continue;
    end;
  end;
end;

{
---------------------------------------------------------------------------
  次の入力可能な子ｺﾝﾄﾛｰﾙを取得する
// Update Note     :  2001.04.24  鹿野　幸生                            //
---------------------------------------------------------------------------
}
function    THDateEdit.GetNextEnableControl:TWinControl;
var
  i:Integer;
begin
  Result := nil;
  //現在位置がNilなら抜ける                                                     2001.04.24 追加
  if CurrentEdit = nil then
    exit;
  //日にｶｰｿﾙがある場合は次のｺﾝﾎﾟに移る為、Nilを返す。
  if CurrentEdit = DayEdit then
    exit;
  //月にｶｰｿﾙがある場合でかつ日がない場合は次のｺﾝﾎﾟに移る為、Nilを返す
  if (CurrentEdit = MonthEdit) and (DayEdit = Nil) then
    exit;
  //年にｶｰｿﾙがある場合でかつ月と日がない場合は次のｺﾝﾎﾟに移る為、Nilを返す
  if (CurrentEdit = YearEdit)and(MonthEdit = Nil)and(DayEdit = Nil) then
    exit;
  for i := CurrentEdit.TabOrder + 1 to ControlCount - 1 do
  begin
    Result := GetControlByTab(i);
    if Result = nil                     then Exit
    else if not THEdit(Result).ReadOnly then Exit
    else
    begin
      Result := nil;
      Continue;
    end;
  end;
end;

{
---------------------------------------------------------------------------
  ｶﾚﾝﾄ入力位置のﾃﾞｸﾘﾒﾝﾄ
---------------------------------------------------------------------------
}
procedure   THDateEdit.DecCurPos(CrntEdit:THEdit);
var
  NextEdit:TWinControl;
begin
  NextEdit := GetPrevEnableControl;
  if NextEdit <> nil then
  begin
    NextEdit.SetFocus;
  end;
end;

{
---------------------------------------------------------------------------
  ｶﾚﾝﾄ入力位置のｲﾝｸﾘﾒﾝﾄ
---------------------------------------------------------------------------
}
procedure   THDateEdit.IncCurPos(CrntEdit:THEdit);
var
  NextEdit:TWinControl;
begin
  NextEdit := GetNextEnableControl;
  if NextEdit <> nil then
  begin
    NextEdit.SetFocus;
  end;
end;

{
---------------------------------------------------------------------------
  初期入力項目の取得
---------------------------------------------------------------------------
}
function    THDateEdit.GetInitEdit:THEdit;
begin
  if      FInitFocus = difJpn   then Result := JpnEdit
  else if FInitFocus = difYear  then Result := YearEdit
  else if FInitFocus = difMonth then Result := MonthEdit
  else if FInitFocus = difDay   then Result := DayEdit
  else                               Result := nil;
end;

{
---------------------------------------------------------------------------
  脱出要件のﾁｪｯｸ
---------------------------------------------------------------------------
}
function    THDateEdit.CheckExtCase(Key:Word; Shift:TShiftState):Boolean;
begin
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
  入力必須のﾁｪｯｸ
---------------------------------------------------------------------------
}
function    THDateEdit.CheckNecessary:Boolean;
begin
  Result := TRUE;
  if (JpnEdit <> nil) and (dneJpn in FNecessaryEditors) then
  begin
    if JpnEdit.DataText = '' then Result := FALSE;
  end;
  if (YearEdit <> nil) and (dneYear in FNecessaryEditors) then
  begin
    if YearEdit.DataText = ''               then Result := FALSE
//    else if StrToInt(YearEdit.DataText) = 0 then Result := FALSE;             // 2003.08.18 変更
    else if StrToIntDef(YearEdit.DataText, 0) = 0 then Result := FALSE;
  end;
  if (MonthEdit <> nil) and (dneMonth in FNecessaryEditors) then
  begin
    if MonthEdit.DataText = ''               then Result := FALSE
//    else if StrToInt(MonthEdit.DataText) = 0 then Result := FALSE;            // 2003.08.18 変更
    else if StrToIntDef(MonthEdit.DataText, 0) = 0 then Result := FALSE;
  end;
  if (DayEdit <> nil) and (dneDay in FNecessaryEditors) then
  begin
    if DayEdit.DataText = ''               then Result := FALSE
//    else if StrToInt(DayEdit.DataText) = 0 then Result := FALSE;              // 2003.08.18 変更
    else if StrToIntDef(DayEdit.DataText, 0) = 0 then Result := FALSE;
  end;
end;

{
---------------------------------------------------------------------------
  入力値妥当性のﾁｪｯｸ
---------------------------------------------------------------------------
}
{$WARNINGS OFF}
function    THDateEdit.CheckInputData:TWinControl;
begin
  { ﾁｪｯｸ無し }
  if not (deoInputCheck in FOptions) then
    Result := nil
  { ﾁｪｯｸ有り }
  else
  begin
    case CheckLongDate(LongDate) of
      cdsOk:           Result := nil;
      cdsIllegalYear:  Result := YearEdit;
      cdsIllegalMonth: Result := MonthEdit;
      cdsIllegalDay:   Result := DayEdit;
    end;
  end;
end;
{$WARNINGS ON}

{
---------------------------------------------------------------------------
  ﾃﾞｰﾀの空をﾁｪｯｸする
---------------------------------------------------------------------------
}
function    THDateEdit.IsDataEmpty:Boolean;
begin
  Result := TRUE;

  if JpnEdit <> nil then
    if not JpnEdit.IsDataEmpty then Result := FALSE;
  if YearEdit <> nil then
    if not YearEdit.IsDataEmpty then Result := FALSE;
  if MonthEdit <> nil then
    if not MonthEdit.IsDataEmpty then Result := FALSE;
  if DayEdit <> nil then
    if not DayEdit.IsDataEmpty then Result := FALSE;
end;

{
---------------------------------------------------------------------------
  Iniﾌｧｲﾙのﾛｰﾄﾞ
---------------------------------------------------------------------------
}
procedure   THDateEdit.LoadIniFile;
begin
  LoadJpnYears(JpnYears);
  LoadGengou(Gengous)
end;

{
---------------------------------------------------------------------------
  元号名ｲﾝﾃﾞｯｸｽの取得
---------------------------------------------------------------------------
}
function    THDateEdit.GetYearNameIndex(YearName:String):Integer;
var
  i:Integer;
begin
  Result := -1;
  with JpnYears do
  begin
    for i := 0 to Count -1 do
    begin
      if TJpnYear(Items[i]).Name <> YearName then
        Continue;
      Result := i;
      Break;
    end;
  end;
end;

{
---------------------------------------------------------------------------
  ｷｰ押し下げの捕捉
//                  :   2000.11.06  鹿野　幸生                          //
---------------------------------------------------------------------------
}
procedure   THDateEdit.OnKeyDownEdits(Sender:TObject; var Key:Word; Shift:TShiftState);
var
  CurIndex:Integer;
begin
  { OnKeyDownｲﾍﾞﾝﾄ発生 }
  if Assigned(FOnKeyDown) then
    FOnKeyDown(Self, Key, Shift);

  // 元号が表示されていて、且つAltキーなら閉じる                                2000.08.05 追加
  if Key = VK_MENU then begin
    if (JpnForm <> nil) and (IsJpnListOpened = True) then begin                 // 2000.10.03 変更
      JpnForm.Close;
      JpnEdit.SetFocus;
    end;
  end;

  case Key of
    93:                                                    // ポップアップキー  2000.10.19 追加
       Rbutton := 1;
    VK_LEFT:  DecCurPos(THEdit(Sender));
    VK_RIGHT: IncCurPos(THEdit(Sender));
    VK_UP:
      if (Sender = TObject(JpnEdit)) and (deoYearNameList in FOptions)
        and (JpnList.ItemIndex > 0) then
      begin
        JpnList.ItemIndex := JpnList.ItemIndex - 1;
        JpnEdit.Text := JpnList.Items.Strings[JpnList.ItemIndex];
        JpnEdit.SelectAll;
        Key := 0;
      end;
    VK_DOWN:
      if (Sender = TObject(JpnEdit)) and (deoYearNameList in FOptions)
        and (JpnList.ItemIndex < JpnList.Items.Count - 1) then
      begin
        JpnList.ItemIndex := JpnList.ItemIndex + 1;
        JpnEdit.Text := JpnList.Items.Strings[JpnList.ItemIndex];
        JpnEdit.SelectAll;
        Key := 0;
      end;
    VK_RETURN:
      if Shift = [] then
      begin
        if (Sender = TObject(JpnEdit)) and (deoYearNameList in FOptions) then
        begin
          if JpnList.ItemIndex <> -1 then
            JpnEdit.Text := JpnList.Items.Strings[JpnList.ItemIndex];
          end;
          IncCurPos(THEdit(Sender));
        end else if Shift = [ssShift] then
          DecCurPos(THEdit(Sender));
    VK_SPACE:
      if (Sender = TObject(JpnEdit)) and not (deoYearNameList in FOptions)
        and (JpnYears.Count <> 0) then
      begin
        CurIndex := GetYearNameIndex(JpnEdit.DataText) + 1;
        if CurIndex > JpnYears.Count - 1 then
        //--------------- UPD 譚洪 2018/12/20 新元号対応 --------------->>>>>
          //JpnEdit.DataText := TJpnYear(JpnYears.Items[0]).Name
          JpnEdit.DataText := TJpnYear(JpnYears.Items[1]).Name
        //else
          //JpnEdit.DataText := TJpnYear(JpnYears.Items[CurIndex]).Name;
        else if CurIndex = JpnYears.Count - 1 then
          JpnEdit.DataText := TJpnYear(JpnYears.Items[0]).Name
        else
          JpnEdit.DataText := TJpnYear(JpnYears.Items[2]).Name;
        //--------------- UPD 譚洪 2018/12/20 新元号対応 ---------------<<<<<
        JpnEdit.SelectAll;
        Key := 0;
      end;
    else
       PostMessage(Application.Handle, WM_KEYDOWN, wParam(Key), lParam(0));     // 2000.11.06 追加
  end;

end;

{
---------------------------------------------------------------------------
  ｷｰ放しの捕捉
---------------------------------------------------------------------------
}
procedure   THDateEdit.OnKeyUpEdits(Sender:TObject; var Key:Word; Shift:TShiftState);
//var
//  yy,mm,dd : SmallInt;
begin
//20000404 >>
//  if Key = VK_APPS then
//  begin
// 20000506 >>
//  if (YearEdit.Text <> '') then
//    if YearEdit.GetInt <> 0 then                                              // 2000.12.20 削除
// 20000506 <<
//    begin
//      if PopMenu <> nil then
//      begin
//        PopMenu.Items[1].Items[0].Caption := IntToStr(LongDate div 10000 -2);
//        PopMenu.Items[1].Items[1].Caption := IntToStr(LongDate div 10000 -1);
//        PopMenu.Items[1].Items[2].Caption := IntToStr(LongDate div 10000 );
//        PopMenu.Items[1].Items[3].Caption := IntToStr(LongDate div 10000 +1);
//        PopMenu.Items[1].Items[4].Caption := IntToStr(LongDate div 10000 +2);
//        PopMenu.Items[1].Items[5].Caption := IntToStr(LongDate div 10000 +3);
//      end;
//    end else
//    begin
//      if PopMenu <> nil then
//      begin
//        HDATE.sdateget1(@yy,@mm,@dd);                                           // 2000.07.21 変更
//        PopMenu.Items[1].Items[0].Caption := IntToStr(yy -2);
//        PopMenu.Items[1].Items[1].Caption := IntToStr(yy -1);
//        PopMenu.Items[1].Items[2].Caption := IntToStr(yy);
//        PopMenu.Items[1].Items[3].Caption := IntToStr(yy +1);
//        PopMenu.Items[1].Items[4].Caption := IntToStr(yy +2);
//        PopMenu.Items[1].Items[5].Caption := IntToStr(yy +3);
//      end;
//    end;
//  end;
//20000404 <<
  { OnKeyUpｲﾍﾞﾝﾄ発生 }
  if Assigned(FOnKeyUp) then
    FOnKeyUp(Self, Key, Shift);
end;

{
---------------------------------------------------------------------------
  ﾏｳｽﾎﾞﾀﾝ押し下げの捕捉
---------------------------------------------------------------------------
}
procedure   THDateEdit.OnMouseDownEdits(Sender:TObject; Button:TMouseButton; Shift:TShiftState; X, Y:Integer);
var
  Pt:TPoint;
begin
  { OnMouseDownｲﾍﾞﾝﾄ発生 }
  if Assigned(FOnMouseDown) then
  begin
    Pt := ScreenToClient(THEdit(Sender).ClientToScreen(Point(X, Y)));
    FOnMouseDown(Self, Button, Shift, Pt.X, Pt.Y);
  end;
end;

{
---------------------------------------------------------------------------
  ﾏｳｽﾎﾞﾀﾝ放しの捕捉
---------------------------------------------------------------------------
}
procedure   THDateEdit.OnMouseUpEdits(Sender:TObject; Button:TMouseButton; Shift:TShiftState; X, Y:Integer);
var
  Pt:TPoint;
//  yy,mm,dd:	SmallInt;
begin
  // 年のポップアップウインドウは年が非表示なら反応させない                     2000.09.12 変更
//  if YearEdit <> nil then begin

// 20000506 >>
//if (YearEdit.Text <> '') then
//    if YearEdit.GetInt <> 0 then                                              // 2000.12.20 削除
// 20000506 <<
//    begin
//      if PopMenu <> nil then
//      begin
//        PopMenu.Items[1].Items[0].Caption := IntToStr(LongDate div 10000 -2);
//        PopMenu.Items[1].Items[1].Caption := IntToStr(LongDate div 10000 -1);
//        PopMenu.Items[1].Items[2].Caption := IntToStr(LongDate div 10000 );
//        PopMenu.Items[1].Items[3].Caption := IntToStr(LongDate div 10000 +1);
//        PopMenu.Items[1].Items[4].Caption := IntToStr(LongDate div 10000 +2);
//        PopMenu.Items[1].Items[5].Caption := IntToStr(LongDate div 10000 +3);
//      end;
//    end else
//    begin
//      if PopMenu <> nil then
//      begin
//        sdateget1(@yy,@mm,@dd);
//        PopMenu.Items[1].Items[0].Caption := IntToStr(yy -2);
//        PopMenu.Items[1].Items[1].Caption := IntToStr(yy -1);
//        PopMenu.Items[1].Items[2].Caption := IntToStr(yy);
//        PopMenu.Items[1].Items[3].Caption := IntToStr(yy +1);
//        PopMenu.Items[1].Items[4].Caption := IntToStr(yy +2);
//        PopMenu.Items[1].Items[5].Caption := IntToStr(yy +3);
//      end;
//    end;
//  end;

  //ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰがあるため右ｸﾘｯｸでﾌｫｰｶｽが移らないため手動で制御する
  if (Button = mbRight) and (FReadOnly = FALSE) then
  begin
    TEdit(Sender).SetFocus;
  end;

  { OnMouseUpｲﾍﾞﾝﾄ発生 }
  if Assigned(FOnMouseUp) then
  begin
    Pt := ScreenToClient(THEdit(Sender).ClientToScreen(Point(X, Y)));
    FOnMouseUp(Self, Button, Shift, Pt.X, Pt.Y);
  end;
end;

{
---------------------------------------------------------------------------
  ﾀﾞﾌﾞﾙｸﾘｯｸの捕捉
---------------------------------------------------------------------------
}
procedure   THDateEdit.OnDblClickEdits(Sender:TObject);
begin
// 20000322 >> 元号Editﾀﾞﾌﾞﾙｸﾘｯｸで元号ﾘｽﾄを表示する
    if Sender = JpnEdit then
      OnEnterEdits(Sender);
// 20000322 <<

  { OnDblClickｲﾍﾞﾝﾄ発生 }
  if Assigned(FOnDblClick) then
    FOnDblClick(Self);
end;

{
---------------------------------------------------------------------------
  文字入力の捕捉
---------------------------------------------------------------------------
}
procedure   THDateEdit.OnKeyPressEdits(Sender:TObject; var Key:Char);
begin
  { RETｷｰ押し下げによるﾋﾞｰﾌﾟ音抑制 }
  if Key = #13 then
    Key := #00

  { 元号入力ﾌｨｰﾙﾄﾞは文字入力不可 }
  else if Sender = JpnEdit then
    Key := #00

  { 数字文字以外を却下 }
  else if not IsCntrl(Key) and not IsNum(Key) then
  begin
    MessageBeep(0);
    Key := #00;
  end;
end;

{
---------------------------------------------------------------------------
  子ｴﾃﾞｨｯﾄのﾌｫｰｶｽONを捕捉
---------------------------------------------------------------------------
}
procedure   THDateEdit.OnEnterEdits(Sender:TObject);
var
  i:Integer;
  Pt:TPoint;
//Add matsu 1998-03-18 JpnListのＹ座標
  y:integer;
//Add kubochi 1998-10-05 元号初期ﾌｫｰｶｽ検索用ﾙｰﾌﾟｶｳﾝﾀ
  RoopCnt:Integer;
  nJpnListHeight : Integer;
begin
  CurrentEdit := THEdit(Sender);
  { 元号選択ON }
//  if (deoYearNameList in FOptions) and (Sender = TObject(JpnEdit)) then    20000912 del kubochi
  if (deoYearNameList in FOptions) and (Sender = TObject(JpnEdit))
  and(not(FReadOnly)) then                                                // 20000912 add kubochi
  begin
    JpnEdit.SelectAll;
    if not IsJpnListOpened then
    begin
// 20000322 >> 元号ﾘｽﾄの表示
      { 元号ﾘｽﾄﾎﾞｯｸｽｵｰﾌﾟﾝ }
//    Pt := TForm(Owner).ScreenToClient(Parent.ClientToScreen(Point(Left,Top)));
//    if (TForm(Owner).Height - (Pt.Y + Height)) <= JpnList.Height then
//    begin
//      y := Pt.Y - JpnList.Height;
//    end else
//    begin
//      y := Pt.Y + Height;
//    end;
//    JpnList.SetBounds(
//                Pt.X + JpnEdit.Left,
//                y,
//                JpnEdit.Width + GetSystemMetrics(SM_CXHSCROLL),
//                kJpnListHeight
//            );
//    JpnList.TabStop := False;
//    JpnList.ParentCtl3D := False;
//    JpnList.Ctl3D  := False;

//    TForm(Owner).InsertControl(JpnList);
//↑↑↑DEL↑↑↑
      JpnList.TabStop := False;
      JpnList.ParentCtl3D := False;
      JpnList.Ctl3D  := False;
      JpnList.Align  := alClient;
      JpnList.Visible:= TRUE;

      Pt:= TForm(Owner).ScreenToClient(Parent.ClientToScreen(Point(Left,Top)));
      y := Pt.y+ JpnEdit.Height + 2;

      nJpnListHeight := JpnYears.Count * 15;
      if y + nJpnListHeight > TForm(Owner).ClientHeight then
        y := y - JpnEdit.Height - nJpnListHeight -2;
      JpnForm.SetBounds(
                    Pt.X,
                    y,
                    JpnEdit.Width + GetSystemMetrics(SM_CXHSCROLL),
                    nJpnListHeight
              );
      JpnForm.ParentWindow := GetParentWin;
      JpnForm.Show;
      // なぜか初回のみShowした瞬間座標が(0,0)になる時があるので、(0,0)なら
      // 再度座標をセットする[2009.08.14]
      if (JpnForm.Top = 0) and (JpnForm.Left = 0) then
      begin
        JpnForm.SetBounds(
                    Pt.X,
                    y,
                    JpnEdit.Width + GetSystemMetrics(SM_CXHSCROLL),
                    nJpnListHeight
              );
      end;




// 20000322 <<
      if JpnYearsNotLoaded then
      begin
        for i := 0 to JpnYears.Count - 1 do
          JpnList.Items.Add(TJpnYear(JpnYears.Items[i]).Name);
        JpnYearsNotLoaded := False;
      end;
//Mod matsu 1998-10-08
      if giSearch = 0 then    // グローバル変数の初期値を判定
      begin                   // 初回のみINIファイルを読む
        giSearch := 1;      // 入力されているデータに元号を合わせるモード
      end;

      if giSearch = 1 then
      begin
//Add kubochi 1998-10-07
        JpnList.ItemIndex := 0; // 初期値を設定(先頭)
        for RoopCnt := 0 to JpnList.Items.Count - 1 do
        begin
          if trim(JpnEdit.Text) = trim(JpnList.Items.Strings[RoopCnt]) then
          begin
            JpnList.ItemIndex := RoopCnt;
            Break;
          end;
        end;
//Add end
      end else
      begin
        JpnList.ItemIndex := 0;
      end;
//Mod End 1998-10-08
      IsJpnListOpened := True;
    end;
  end;
  if Sender = YearEdit then
    IsYearChanged := FALSE;
end;

{
---------------------------------------------------------------------------
  子ｴﾃﾞｨｯﾄのﾌｫｰｶｽOFFを捕捉
---------------------------------------------------------------------------
}
procedure   THDateEdit.OnExitEdits(Sender:TObject);
begin
  CurrentEdit := nil;

  { 元号選択OFF }
  if (deoYearNameList in FOptions) and (Sender = TObject(JpnEdit)) then
  begin
    { 元号ﾘｽﾄﾎﾞｯｸｽｸﾛｰｽﾞ }
    if TForm(Owner).ActiveControl <> JpnList then
    begin
// 20000322 >>
//    TForm(Owner).RemoveControl(JpnList;
      if JpnForm <> nil then
        JpnForm.Close;
// 20000322 <<
      IsJpnListOpened := False;
    end;
  end;

  if (Sender = YearEdit) and (JpnEdit <> nil) and (Gengous.Count <> 0)
     and IsYearChanged then
  begin
    if THNedit(Sender).DataText = '' then
    JpnEdit.DataText := ''
  end;
end;

{
---------------------------------------------------------------------------
  子ｴﾃﾞｨｯﾄのﾃﾞｰﾀ変更を捕捉
---------------------------------------------------------------------------
}
procedure   THDateEdit.OnChangeEdits(Sender:TObject);
var
  OrgYY, OrgMM, OrgDD:Integer;
  YY, MM, DD:Integer;
begin
  { LongDateBuf更新 }
  if not NowSettingLongDate then
  begin
    DecodeLongDate(LongDateBuf, OrgYY, OrgMM, OrgDD);
    GetDate(YY, MM, DD);
    if YY = -1 then
    begin
      if YearEdit = nil then YY := OrgYY
      else                   YY := 0;
    end;
    if MM = -1 then
    begin
      if MonthEdit = nil then MM := OrgMM
      else                    MM := 0;
    end;
    if DD = -1 then
    begin
      if DayEdit = nil then DD := OrgDD
      else                  DD := 0;
    end;
    LongDateBuf := EncodeLongDate(YY, MM, DD);

    if Sender = YearEdit then
      IsYearChanged := TRUE;
  end;

  { OnChangeｲﾍﾞﾝﾄ発生 }
  if Assigned(FOnChange) then
    FOnChange(Self);

  { 全桁入力脱出 }
  if not IsDateSetting and (Sender is THNedit) then
  begin
    if THNedit(Sender).FullInputed then
    IncCurPos(THEdit(Sender));
  end;
end;

{
---------------------------------------------------------------------------
  元号ﾘｽﾄﾎﾞｯｸｽにﾌｫｰｶｽがかかった場合の処理
---------------------------------------------------------------------------
}
procedure   THDateEdit.OnEnterJpnList(Sender:TObject);
begin
  JpnEdit.SetFocus;
end;

{
---------------------------------------------------------------------------
  元号ﾘｽﾄﾎﾞｯｸｽがｸﾘｯｸされた場合の処理
---------------------------------------------------------------------------
}
procedure   THDateEdit.OnMouseDownJpnList(Sender:TObject; Button:TMouseButton; Shift:TShiftState; X, Y:Integer);
var
  i:Integer;
  Pt:TPoint;
  Rc:TRect;
begin
  if Button = mbLeft then
  begin
    { ｸﾘｯｸされた項目を調べる }
    Pt := Point(X, Y);
    for i := 0 to JpnList.Items.Count - 1 do
    begin
      SendMessage(JpnList.Handle, LB_GETITEMRECT, i, Longint(@Rc));
      if not IsIncludePoint(Pt,Rc) then
        continue;

      { ｸﾘｯｸされた項目を選択する }
      JpnList.ItemIndex := i;
      JpnEdit.Text := JpnList.Items.Strings[JpnList.ItemIndex];
      JpnEdit.SelectAll;

(* 991218 >> *)
      {MouseDownｲﾍﾞﾝﾄを発生させる}
      Pt := ScreenToClient(TListBox(Sender).ClientToScreen(Point(X, Y)));
      FOnMouseDown(Self, Button, Shift, Pt.X, Pt.Y);
(* 991218 << *)
      Break;
    end;
  end;
end;

{
---------------------------------------------------------------------------
  ｳｨﾝﾄﾞｳ生成ﾊﾟﾗﾒｰﾀの設定
---------------------------------------------------------------------------
}
procedure   THDateEdit.CreateParams(var Params:TCreateParams);
const
  BorderStyles:array[TBorderStyle] of Longint = (0, WS_BORDER);
begin
  { 派生元呼び出し }
  inherited CreateParams(Params);

  if not (deoSeparate in FOptions) then
{$WARNINGS OFF}
    Params.Style := Params.Style or BorderStyles[FBorderStyle];
{$WARNINGS ON}
  if not (csDesigning in ComponentState) then
  begin
    if FTransparents = true then
      Params.ExStyle := WS_EX_TRANSPARENT
    else
      Params.ExStyle := 0;
  end;
end;

{
---------------------------------------------------------------------------
  OnEnterｲﾍﾞﾝﾄの発生
---------------------------------------------------------------------------
}
procedure   THDateEdit.DoEnter;
var
  InitEdit:THEdit;
begin
  { 元号ﾘｽﾄ移動時は発生させない }
  if not IsJpnListOpened then
  begin
    InitEdit := GetInitEdit;
    if InitEdit <> nil then
    begin
      InitEdit.SetFocus;
    end;

    {$IFDEF WIN32}
      inherited;
    {$ELSE}
      inherited DoEnter;
    {$ENDIF}
  end;
end;

{
---------------------------------------------------------------------------
  OnExitｲﾍﾞﾝﾄの発生
---------------------------------------------------------------------------
}
procedure   THDateEdit.DoExit;
begin
  { 元号ﾘｽﾄ移動時は発生させない }
  if (not Assigned(TForm(Parent).ActiveControl) ) or
     (TForm(Parent).ActiveControl <> JpnList) then
  begin
    if BkPnel <> nil then
      DestClender;
  end;

  {$IFDEF WIN32}
    inherited;
  {$ELSE}
    inherited DoExit;
  {$ENDIF}
end;

{
---------------------------------------------------------------------------
  Fontﾌﾟﾛﾊﾟﾃｨの変更を捕捉
---------------------------------------------------------------------------
}
procedure   THDateEdit.CMFontChanged(var Message:TMessage);
begin
  { 派生元呼び出し }
  inherited;

  AlignChildren;
end;

{$IFNDEF HREG}
{
***************************************************************************
  ｺﾝﾎﾟｰﾈﾝﾄの登録
***************************************************************************
}
procedure   Register;
begin
  RegisterComponents('HSS', [THDateEdit]);
end;
{$ENDIF}

{
***************************************************************************
  元号導出ﾘｽﾄの読み込み
***************************************************************************
}
function    THDateEdit.LoadGengou(AGengous:TList):Boolean;
var
  i:Integer;
  GengouNode:TGengouNode;
  GenRec: TGEN_REC;
  nx: SmallInt;
begin
  { 既存のJpnYearﾘｽﾄｸﾘｱ }
  for i := 0 to AGengous.Count - 1 do
    TGengouNode(AGengous.Items[i]).Free;
  AGengous.Clear;

  //ここで元号を取得する
  ZeroMemory(@GenRec,sizeof(GenRec));
  nx := HDATE.genset(GenRec,3);

  { GengouNodeｵﾌﾞｼﾞｪｸﾄ生成 }
  for i:=0 to nx-1 do
  begin
    GengouNode := TGengouNode.Create;
    GengouNode.StartY  := GenRec.nSdate[i] div 10000;
    GengouNode.EndY    := GenRec.nEdate[i] div 10000;
    GengouNode.YearName:= GenRec.szGen[i];

    { AGengousﾘｽﾄに挿入 }
    AGengous.Add(GengouNode);
  end;
  Result := TRUE;
end;

{
***************************************************************************
  元号導出
***************************************************************************
}
function    YearToGengou(AJpnYears:TList;gengo:string;AYear:Integer;
               AGengous:TList;var NewYear:Integer):String;
var
  s:string;
  n:Integer;
begin
  AYear := ConvertCrsYear(AJpnYears, gengo, AYear, -1, -1);
  ConvertJpnYear(AJpnYears, AYear, 0, 0,S, n);
  Result := s;
  NewYear := n;
end;

{
***************************************************************************
  設定ﾌｧｲﾙ中JpnYearsの読み込み
***************************************************************************
}
function    THDateEdit.LoadJpnYears(JpnYearsList:TList):Boolean;
var
  i:Integer;
  JpnYear:TJpnYear;
{$IFNDEF WIN32}
  IniSection:array[0..255] of Char;
  IniFile:array[0..255] of Char;
{$ENDIF}
  GenRec:TGEN_REC;
  nx: SmallInt;
  ix: SmallInt;
  szWrk: array[0..10] of Char;
begin
  { 既存のJpnYearﾘｽﾄｸﾘｱ }
  for i := 0 to JpnYearsList.Count - 1 do
    TJpnYear(JpnYearsList.Items[i]).Free;
  JpnYearsList.Clear;

  //ここで元号を取得する ueoueo
  ZeroMemory(@GenRec,sizeof(GenRec));
  //--------------- UPD 譚洪 2018/12/20 新元号対応 --------------->>>>>
  //nx := HDate.genset(GenRec,3);
  nx := HDate.genset(GenRec,2);
  //--------------- UPD 譚洪 2018/12/20 新元号対応 ---------------<<<<<

  { JpnYearsListﾘｽﾄに挿入 }
  for ix:=0 to nx-1 do
  begin
    { JpnYearｵﾌﾞｼﾞｪｸﾄ生成 }
    JpnYear := TJpnYear.Create;
    ZeroMemory(@szWrk,sizeof(szWrk));
    JpnYear.Name := GenRec.szGen[ix];
    JpnYear.Year := GenRec.nSadate[ix]+1;
    JpnYearsList.Add(JpnYear);
  end;

  Result := TRUE;
end;

{
***************************************************************************
  和暦から西暦への変換
***************************************************************************
}
function    ConvertCrsYear(JpnYears:TList; AName:String; AYear, AMonth, ADay:Integer):Integer;
var
  i:Integer;
  JpnYear:TJpnYear;
begin
  JpnYear := nil;
  for i := 0 to JpnYears.Count - 1 do
  begin
    if TJpnYear(JpnYears.Items[i]).Name <> AName then
      continue;
    JpnYear := TJpnYear(JpnYears.Items[i]);
    Break;
  end;

  if JpnYear = nil then Result := AYear
  else                  Result := JpnYear.Year + AYear -1;
end;

{
********************************************************************************
  西暦から和暦への変換
********************************************************************************
}
procedure ConvertJpnYear(JpnYears: TList; AYear, AMonth, ADay: Integer;
                               var JpnYearName: String; var JpnYearYear: Integer);
var
  lSdate:	LongInt;
  //szGen:	array[0..4] of Char;
  sGen : String;
  cRya:		String;
begin
  lSdate := (AYear*10000)+(AMonth*100)+ADay;
  //ZeroMemory(@szGen,sizeof(szGen));                                             // 20000912 add kubochi
  JpnYearYear := (HDATE.swchg(lSdate,sGen,cRya) div 10000);                  // 2000.07.21 変更
  JpnYearName := sGen;
end;

procedure THDateEdit.SysDateGet(Sender: TObject);
var
  yy,mm,dd: SmallInt;
  S:        String;
  N:        Integer;
  hwndH:array[0..4] of HWND;
  ix:       Integer;
begin
  //ﾘﾀｰﾝｺﾝﾄﾛｰﾙやｱﾛｰｺﾝﾄﾛｰﾙでなぜかこのｲﾍﾞﾝﾄが発生してしまい
  //THDateEditからﾌｫｰｶｽが抜ける際にｼｽﾃﾑ日付がｾｯﾄされてしまうので
  //現在のﾌｫｰｶｽ位置で処理を行うかどうか判断する
  ZeroMemory(@hwndH,sizeof(hwndH));
  if YearEdit <> Nil then
    hwndH[0] := YearEdit.Handle;
  if MonthEdit <> Nil then
    hwndH[1] := MonthEdit.Handle;
  if DayEdit <> Nil then
    hwndH[2] := DayEdit.Handle;
  if JpnEdit <> Nil then
    hwndH[3] := JpnEdit.Handle;
  for ix:=0 to 3 do
  begin
    if GetFocus = hwndH[ix] then
      break;
    if ix = 3 then
      Exit;
  end;
  if Rbutton = 0 then
    Exit;

  Rbutton := 0;
  //ｼｽﾃﾑ日付取得
  sdateget1(yy,mm,dd);
  //西暦和暦変換処理
  ConvertJpnYear(JpnYears, yy, mm, dd, S, N);
  //ｼｽﾃﾑ日付をｾｯﾄ
  if JpnEdit <> Nil then
    JpnEdit.Text      := Copy(S,1,4);
  if MonthEdit <> Nil then
    MonthEdit.Text:= SpnStrR(IntToStr(mm),MonthEdit.ExtEdit.Column);
  if DayEdit <> Nil then
  begin
    if dd < 10 then
      DayEdit.Text  := '0' + SpnStrR(IntToStr(dd),DayEdit.ExtEdit.Column)
    else
      DayEdit.Text  := SpnStrR(IntToStr(dd),DayEdit.ExtEdit.Column);
  end;

  //年は和暦か西暦かを判断し、対応する年をｾｯﾄ
  case FDateFormat of
    dfG2Y2M2D,dfG2Y2M,dfG2Y:
    begin
      if YearEdit <> Nil then
        YearEdit.DataText := SpnStrR(IntToStr(N), YearEdit.ExtEdit.Column);
      end else
      begin
        if YearEdit <> Nil then
          YearEdit.DataText := SpnStrR(IntToStr(yy), YearEdit.ExtEdit.Column);
      end;
    end;
end;

procedure THDateEdit.ChgYear(Sender:TObject);
var
  nYY: integer;
begin
  if YearEdit <> nil then
  begin
    //                                                                          // 2000.12.20 変更
    // もし年に何も入ってなければ、年のポップアップメニューに年をセット(２回目のポップが正しく動作しない障害を解除)
    if YearEdit.GetInt = 0 then begin
      if PopMenu <> nil then  begin
//        nYY := StrToInt(SItemYear[TEdit(Sender).Tag].Caption);                // 2003.08.18 変更
        nYY := StrToIntDef(SItemYear[TEdit(Sender).Tag].Caption, 0);
        PopMenu.Items[1].Items[0].Caption := IntToStr(nYY -2);
        PopMenu.Items[1].Items[1].Caption := IntToStr(nYY -1);
        PopMenu.Items[1].Items[2].Caption := IntToStr(nYY);
        PopMenu.Items[1].Items[3].Caption := IntToStr(nYY +1);
        PopMenu.Items[1].Items[4].Caption := IntToStr(nYY +2);
        PopMenu.Items[1].Items[5].Caption := IntToStr(nYY +3);
      end;
      LongDate := nYY * 10000 + LongDate mod 10000;
    end else begin
      // 入っていたら、ポップアップメニューを再セット
//      LongDate := StrToInt(SItemYear[TEdit(Sender).Tag].Caption) * 10000 + LongDate mod 10000; // 2003.08.18 変更
      LongDate := StrToIntDef(SItemYear[TEdit(Sender).Tag].Caption, 0) * 10000 + LongDate mod 10000;
      if PopMenu <> nil then
      begin
        PopMenu.Items[1].Items[0].Caption := IntToStr(LongDate div 10000 -2);
        PopMenu.Items[1].Items[1].Caption := IntToStr(LongDate div 10000 -1);
        PopMenu.Items[1].Items[2].Caption := IntToStr(LongDate div 10000 );
        PopMenu.Items[1].Items[3].Caption := IntToStr(LongDate div 10000 +1);
        PopMenu.Items[1].Items[4].Caption := IntToStr(LongDate div 10000 +2);
        PopMenu.Items[1].Items[5].Caption := IntToStr(LongDate div 10000 +3);
      end;
    end;
  end;
end;

procedure THDateEdit.ChgMonth(Sender:TObject);
begin
  if MonthEdit <> nil then
  begin
    MonthEdit.Text := SpnStrR(SItemMonth[TEdit(Sender).Tag].Caption,
    MonthEdit.ExtEdit.Column);
  end;
end;

procedure THDateEdit.ChgDay(Sender:TObject);
begin
  if DayEdit <> nil then
  begin
    DayEdit.Text := SpnStrR(SItemDay[TEdit(Sender).Tag].Caption,
    DayEdit.ExtEdit.Column);
  end;
end;

procedure THDateEdit.CreateCalendar(Sender:TObject);
var
  Pt        : TPoint;
  SysDate   : LongInt;
// 20000323 >>
  y         : Integer;
  rect      : TRECT;
// 20000323 <<
begin
  if BkPnel = nil then
  begin
// 20000323 >>
//  BkPnel:=TPanel.Create(Owner);
//  Pt := TForm(Owner).ScreenToClient(Parent.ClientToScreen(Point(Left,Top)));

//  if TForm(Owner).Height - Pt.y - Height -212 > 0 then
//    BkPnel.Top := Pt.y + Height
//  else
//    BkPnel.Top := Pt.y - 212;
//  BkPnel.Left:= Pt.x;
//  BkPnel.Height := 212;
//  BkPnel.Width := 186;
//  BkPnel.Caption:= '';
//  TForm(Owner).InsertControl(BkPnel);
//end else
//  BkPnel.Visible := true;

//    BkPnel := TForm.Create(Owner);
    BkPnel := TForm.Create(Application);
    if BkPnel <> nil then
    begin
      with BkPnel do
      begin
        color        := clBtnFace;
        tag          := 0 ;
        caption      := 'カレンダー入力';
        BorderStyle  := bsDialog;
        OnDeactivate := OnDeactivateBkPnel;
      end;
    end else Exit;
  end;
  if BkPnel <> nil then
  begin
    Pt:= Parent.ClientToScreen(Point(Left,Top));
    y := Pt.y+ Height + 1;
    GetWindowRect(GetDeskTopWindow,rect);
    if y + BkPnel.Height > rect.Bottom then
      y := y - Height - BkPnel.Height;
    with BkPnel do
    begin
      height       := 235;
//      width        := 190;          20000904 del kubochi
      width        := 204;          //20000904 add kubochi
      top          := y;
      left         := Pt.x;
    end;
  end;
// 20000323 <<

  if Clender = nil then
  begin
    Clender:=TMonthCalendar.Create(BkPnel);
    Clender.Top := 2;
    Clender.Left:= 4;
//20000421 >>
    Clender.Name:= Name + 'Clender';
//20000421 <<
    if (LongDate <> 0) and (YearEdit.Text <> '') and (MonthEdit.Text <> '')
      and (DayEdit.Text <> '') then
    begin
      if HDATE.daycheck(0,LongDate) <> 0 then                                   // 2000.07.21 変更
      begin
        SysDate := HDATE.sdateget2;                                             // 2000.07.21 変更
        Clender.Date := EncodeDate(SysDate div 10000,
                          ((SysDate mod 10000) div 100), SysDate mod 100);
      end else
        Clender.Date := EncodeDate(LongDate div 10000,
                          ((LongDate mod 10000) div 100), LongDate mod 100);
    end;
  BkPnel.InsertControl(Clender);
  end;

  if PrvPnel = nil then
  begin
    PrvPnel:=TPanel.Create(BkPnel);
    PrvPnel.OnClick  := PrevYear;
    PrvPnel.Top := Clender.Top + Clender.Height;
    PrvPnel.Left:= Clender.Left;
    PrvPnel.Height := 24;
    PrvPnel.Width := Clender.Width div 2;
    PrvPnel.Caption:= '前年';
    BkPnel.InsertControl(PrvPnel);
  end;

  if NxtPnel = nil then
  begin
    NxtPnel:=TPanel.Create(BkPnel);
    NxtPnel.OnClick  := NextYear;
    NxtPnel.Top := Clender.Top + Clender.Height;
    NxtPnel.Left:= Clender.Left + PrvPnel.Width;
    NxtPnel.Height := 24;
    NxtPnel.Width := Clender.Width div 2;
    NxtPnel.Caption:= '翌年';
    BkPnel.InsertControl(NxtPnel);
  end;

  if OkPnel = nil then
  begin
    OkPnel:=TPanel.Create(BkPnel);
    OkPnel.OnClick  := OkClick;
    OkPnel.Top := PrvPnel.Top + PrvPnel.Height;
    OkPnel.Left:= Clender.Left;
    OkPnel.Height := 24;
//    OkPnel.Width := Clender.Width;           20000904 del kubochi
    OkPnel.Width := Clender.Width - 1;       //20000904 add kubochi
    OkPnel.Caption:= 'OK';
    BkPnel.InsertControl(OkPnel);
  end;
// 20000323 >>
//RePaint;
  BkPnel.Show;
// 20000323 <<
end;

procedure THDateEdit.NextYear(Sender:TObject);
var
  yy,mm,dd:WORD;
begin
  DecodeDate(Clender.Date,yy,mm,dd);
  Inc(yy);
  Clender.Date := EncodeDate(yy,mm,dd);
end;

procedure THDateEdit.PrevYear(Sender:TObject);
var
  yy,mm,dd:WORD;
begin
  DecodeDate(Clender.Date,yy,mm,dd);
  Dec(yy);
  Clender.Date := EncodeDate(yy,mm,dd);
end;

procedure THDateEdit.OkClick(Sender:TObject);
var
  yy,mm,dd:WORD;
begin
  DecodeDate(Clender.Date,yy,mm,dd);
//  LongDate := yy*10000+mm*100+dd;                                             2001.12.11 変更
  // 日付フォーマットに従い、設定する年月日を変える
  case FDateFormat of
    df4Y2M2D, df2Y2M2D, dfG2Y2M2D: begin                   // 年4桁+月2桁+日2桁・年2桁+月2桁+日2桁・元号+年2桁+月2桁+日2桁
      LongDate := yy*10000+mm*100+dd;
    end;
    df4Y2M, df2Y2M, dfG2Y2M: begin                         // 年4桁+月2桁・年2桁+月2桁・元号+年2桁+月2桁
      LongDate := yy*10000+mm*100;
    end;
    df2M2D: begin                                          // 月2桁+日2桁
      LongDate := yy*10000+mm*100;
    end;
    df4Y,df2Y,dfG2Y: begin                                // 年4桁・年2桁・元号+年2桁
      LongDate := yy*10000;
    end;
    df2M: begin                                           // 月2桁
      LongDate := mm*100;
    end;
    df2D: begin                                           // 日2桁
      LongDate := dd;
    end;
    else
      LongDate := yy*10000+mm*100+dd;
  end;
  BkPnel.Visible := false;
  RePaint;
end;

procedure THDateEdit.DestClender;
begin
// 20000323 >>
  BkPnel.Close;
// 20000323 <<
  if BkPnel <> nil then
  begin
    if OkPnel <> nil then
    begin
      BkPnel.RemoveControl(OkPnel);
      OkPnel.Free;
      OkPnel := nil;
    end;
    if NxtPnel <> nil then
    begin
      BkPnel.RemoveControl(NxtPnel);
      NxtPnel.Free;
      NxtPnel := nil;
    end;
    if PrvPnel <> nil then
    begin
      BkPnel.RemoveControl(PrvPnel);
      PrvPnel.Free;
      PrvPnel := nil;
    end;
    if Clender <> nil then
    begin
      BkPnel.RemoveControl(Clender);
      Clender.Free;
      Clender := nil;
    end;
    if BkPnel <> nil then
    begin
// 20000323 >>
//    TForm(Owner).RemoveControl(BkPnel);
// 20000323 <<
      BkPnel.Free;
      BkPnel := nil;
    end;
  end;
end;

procedure THDateEdit.SetTransparents(Value:Boolean);
begin
  if Value <> FTransparents then
    FTransparents := Value;
end;

procedure THDateEdit.SetYearNmListNumofDisp(value:SmallInt);
var
  genrec : TGEN_REC;
  gencnt : Integer;
  ix: Integer;
  JpnYear:TJpnYear;
begin
  if Value <> FYearNmListNumofDisp then
  begin
    FYearNmListNumofDisp := Value;
    // 実行時のみリストを再生成
    if not (csDesigning in ComponentState) then
    begin
      JpnYears.Clear;
      gencnt := Hdate.genset(genrec,FYearNmListNumofDisp);
      for ix := 0 to gencnt - 1 do
      begin
        { JpnYearｵﾌﾞｼﾞｪｸﾄ生成 }
        JpnYear := TJpnYear.Create;
        JpnYear.Name := GenRec.szGen[ix];
        JpnYear.Year := GenRec.nSadate[ix]+1;
        JpnYears.Add(JpnYear);
      end;
    end;
  end;
end;

procedure THDateEdit.Paint;
begin
  if PaintFlg = 1 then exit;
  inherited Paint;
  Flesh;
end;

procedure THDateEdit.Flesh;
var
  Rect:  TRect;
  Point: TPoint;
  HParent: HWND;
  ix:integer;
begin
  if PaintFlg = 1 then exit;

  if not(csDesigning in ComponentState) and (FTransparents = True) then
  begin
    HParent := GetParent(Handle);
    GetWindowRect(Handle, Rect);
    Point := Rect.TopLeft;
    WinProcs.ScreenToClient(HParent, Point);
    Rect.TopLeft := Point;
    Point := Rect.BottomRight;
    WinProcs.ScreenToClient(HParent, Point);
    Rect.BottomRight := Point;
    InvalidateRect(HParent, @Rect, TRUE);
    SendMessage(HParent, WM_PAINT, 0, 0);
    ValidateRect(HParent, nil);
    InvalidateRect(handle, nil, False);
    for ix := 0 to TForm(Owner).ComponentCount -1 do
    begin
      CHFrame := Nil;
      if TForm(Owner).Components[ix] is THFrameControl then
      begin
        CHFrame := THFrameControl(TForm(Owner).Components[ix]);
        break;
      end;
    end;
    PaintFlg := 1;
    SendMessage(handle,WM_PAINT,0,0);
    if CHFrame <> nil then
      THFrameControl(CHFrame).Repaint;
    PaintFlg := 0;
    ValidateRect(Handle, nil);
    if JpnEdit <> nil then
      JpnEdit.Repaint;
    if YearEdit <> nil then
      YearEdit.Repaint;
    if MonthEdit <> nil then
      MonthEdit.Repaint;
    if DayEdit <> nil then
      DayEdit.Repaint;
  end;
end;

procedure THDateEdit.OwnerFormResize(Sender:TObject);
var
  ix:Integer;
begin
  for ix := 0 to TForm(Owner).ComponentCount -1 do
  begin
    if TForm(Owner).Components[ix] is THDateEdit then
    begin
      THDateEdit(TForm(Owner).Components[ix]).Repaint;
    end;
  end;
  inherited;
end;

procedure THDateEdit.FormMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  case Button of
    mbRight:Rbutton := 1;
    mbLeft: Rbutton := 0;
  end;

  inherited;
end;

// 20000322 >>
procedure THDateEdit.OnKeyDownJpnList(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
  case Key of
    VK_RIGHT: IncCurPos(JpnEdit);
    VK_LEFT:
    begin
      JpnEdit.SetFocus;
      PostMessage(TForm(Owner).Handle,WM_KEYDOWN,VK_LEFT,0);
    end;
    Vk_RETURN:
    begin
      JpnEdit.Text := JpnList.Items.Strings[JpnList.ItemIndex];
      IncCurPos(JpnEdit);
    end;
  end;
end;

procedure THDateEdit.OnKeyUpJpnList(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
  case Key of
    VK_UP,VK_DOWN:
      JpnEdit.Text := JpnList.Items.Strings[JpnList.ItemIndex];
  end;
end;
procedure THDateEdit.OnDeactivateBkPnel(Sender: TObject);
begin
  if BkPnel <> nil then
    BkPnel.Close;
end;

(*
// ｲﾍﾞﾝﾄ処理内容追加 20000904 add kubochi
// THDateEdit ﾒｲﾝ画面Closeｲﾍﾞﾝﾄ
procedure THDateEdit.OnOwnerFormClose(Sender: TObject; var Action: TCloseAction);
begin
  inherited ;
  if Assigned(FOnClose) then FOnClose(Sender,Action);                    // メインフォームイベント呼び出し

  if Action = caNone then Exit;               // 画面終了無しの場合は無処理

  if JpnList <> nil then
  begin
    JpnList.Free;
    JpnList := nil;
  end;
  if JpnForm <> nil then
  begin
    JpnForm.Free;
    JpnForm := nil;
  end;

end;
*)
// ｲﾍﾞﾝﾄ処理内容追加 20000925 add kubochi
// THDateEdit ﾒｲﾝ画面destroyｲﾍﾞﾝﾄ
procedure THDateEdit.OnOwnerFormDestroy(Sender: TObject);
begin
  inherited ;

  // 2009.09.10 >>
  // 親の横取りイベントを戻す                                                   2000.11.13 追加
  //if Assigned(OrgOnMessageHandler) then
  // TControl(Parent).WindowProc := OrgOnMessageHandler;
  if Assigned(OrgOnMessageHandler) then
    TControl(Owner).WindowProc := OrgOnMessageHandler;
  // 2009.09.10 <<

  if Assigned(FOnDestroy) then FOnDestroy(Sender);                       // メインフォームイベント呼び出し

  if JpnList <> nil then
  begin
    JpnList.Free;
    JpnList := nil;
  end;
  if JpnForm <> nil then
  begin
    JpnForm.Free;
    JpnForm := nil;
  end;

end;

//親ハンドルを取得する。ただし、親となりえるのはフォームとスクロールボックス
//のみとします。スクロールボックスが親の場合は元号リストの表示位置も
//スクロールボックスを元に割り出しなおす。
function THDateEdit.GetParentWin:HWND;
var
  prnt : TWinControl;
  ret  : HWND;
  Pt   : TPoint;
  y    : integer;
  nJpnListHeight : Integer;
begin
  ret := 0;
  prnt := Parent;
  while prnt <> nil do
  begin
    if prnt is TForm then
    begin
      ret := prnt.Handle;
      break;
    end;
    if prnt is TScrollBox then
    begin
      nJpnListHeight := JpnYears.Count * 15;
      Pt:= TScrollBox(prnt).ScreenToClient(Parent.ClientToScreen(Point(Left,Top)));
      y := Pt.y+ JpnEdit.Height + 2;
      if y + nJpnListHeight > TScrollBox(prnt).Height -20 then
        y := y - JpnEdit.Height - nJpnListHeight -2;
      JpnForm.SetBounds(
                    Pt.X,
                    y,
                    JpnEdit.Width + GetSystemMetrics(SM_CXHSCROLL),
                    nJpnListHeight
              );
      ret := prnt.Handle;
      break;
    end;
    prnt := prnt.Parent;
  end;
  if ret = 0 then
    ret := TForm(Owner).Handle;
  Result := ret;
end;
// 20000322 <<

//**********************************************************************//
// Module Name     :  親の横取りイベント                                //
//                 :  THDateEdit.OnSubClassWndProc                      //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.11.13                                        //
//----------------------------------------------------------------------//
// Update Note     :  200x.xx.xx  ＸＸ　ＸＸ                            //
//**********************************************************************//
procedure THDateEdit.OnSubClassWndProc(var Message: TMessage);
var
  stPoint:  TPoint;
  stRect:   TRect;

begin

  // リサイズ・移動のみ横取りして、元号リストを移動
  if (Message.Msg = WM_MOVE) then begin
    if (JpnForm <> nil) and (JpnForm.Visible = True) then begin
      GetWindowRect(Handle, stRect);
      stPoint.X := stRect.Left;
      stPoint.Y := stRect.Top + Height;
      Windows.ScreenToClient(TForm(Owner).Handle, stPoint);
      JpnForm.SetBounds(stPoint.X, stPoint.Y, JpnEdit.Width + GetSystemMetrics(SM_CXHSCROLL),JpnYears.Count * 15 {kJpnListHeight});


    end;
  end;

  // ｵﾘｼﾞﾅﾙﾊﾝﾄﾞﾗ呼び出し
  if Assigned(OrgOnMessageHandler) then
    OrgOnMessageHandler(Message);

end;

//**********************************************************************//
// Module Name      :   元号リスト用フォーム破棄時のイベント            //
//                  :   THDateEdit.OnJpnFormDestroy                     //
// Programer        :   鹿野　幸生                                      //
// Date             :   2001.02.15                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//**********************************************************************//
procedure THDateEdit.OnJpnFormDestroy(Sender: TObject);
begin

  ShowWindow(Application.Handle, SW_SHOW);

end;

end.

