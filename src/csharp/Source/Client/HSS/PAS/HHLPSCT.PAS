{
******************************************************************************
	HSS ｺﾝﾎﾟｰﾈﾝﾄﾗｲﾌﾞﾗﾘ  ｢HSS｣

		ヘルプソケットコンポーネント

		ﾕﾆｯﾄ名  :   HHlpSct.PAS
		作成者  :   Kubochi
		作成日  :   1999/7
		概要    :   ヘルプモジュールへメッセージを送る
//-------------------------------------------------------------------------//
// Update Note   :   2000.10.20  鹿野　幸生                                //
//               :    ① HELPのインターフェースにＤＬＬタイプを追加        //
//               :   2000.10.26  鹿野　幸生                                //
//               :    ① HELP、Verの表示メソッドを追加                     //
//               :   2000.12.07  鹿野　幸生                                //
//               :    ① アプリケーション終了時にXボタンで終了させた時に   //
//               :       一般保護違反が発生していた障害を解除。            //
//               :   2001.01.06  鹿野　幸生                                //
//               :    ① シフト、ALT、CTRLキーのいずれかがF1と同時に押され //
//               :       ていれば、ヘルプを無効にするように修正            //
//               :   2001.02.26  鹿野　幸生                                //
//               :    ①  SFLITE.INIをHSSBASEINIに変更                     //
******************************************************************************
}
unit HHlpSct;

{$DEFINE UPDATE}
{$DEFINE HREG}

{
******************************************************************************
	interface部
******************************************************************************
}
interface

{ ﾕﾆｯﾄ指定 }
uses
  Windows, SysUtils, Classes, Forms, HVersion,dialogs,Controls,messages,
  Inifiles, ExtCtrls, HDspHelpPara, HDSPVERPARA, HFslLib;

{ 型宣言 }
type

{
-----------------------------------------------------------------------
	       	FocusChangedイベント取得ｵﾌﾞｼﾞｪｸﾄ定義
-----------------------------------------------------------------------
}
  TMessageReceiver = class(TControl)
  private
  { Private 宣言 }
  protected
  { Protected 宣言 }
  public
  { Public 宣言 }
    constructor Create(AOwner:TComponent); override;
    destructor  Destroy; override;
  published
  { Published 宣言 }
  end;

{
-----------------------------------------------------------------------
	THHelpSocketｵﾌﾞｼﾞｪｸﾄ定義
-----------------------------------------------------------------------
}
  THHelpSocket = class(TComponent)
  private
  { Private 宣言 }
    FVersion     : TVersion ;                       { ﾊﾞｰｼﾞｮﾝ              }
    FHFormClass  : string   ;                       { フォーム名称を指定   }
    FHelpPath    : string;                          // ヘルプパス
    FReceiver    :TMessageReceiver;
    FormNamePara : array[0..255] of char;
    CtrlNamePara : array[0..255] of char;
    CallHelpTimer: TTimer;
    DspHelpParam:   THDSPHELPPARAM;
    gfpShowHelp:    TShowHelp;
    gfpCloseHelp:   TCloseHelp;
    FHelpDllHandle: THandle;
    DspVerParam:    THDSPVERPARAM;
    gfpShowVer:     TShowVer;
    gfpCloseVer:    TCloseVer;
    FVerDllHandle:   THandle;
    FOnDspHelp:    boolean;
    procedure  OnCallHelpTimer(Sender: TObject);
    function   DllLoadCtl(DllNm:String;ModuleNm:String; var InsHandle:THandle;var fpProc:FARPROC):Boolean;
  protected
  { Protected 宣言 }
    MainForm     : TForm ;                          { ﾒｲﾝﾌｫｰﾑ              }
    OnMessageCounter:Integer;                       { ﾊﾝﾄﾞﾗ再入ｶｳﾝﾀ        }
    OrgOnMessageHandler:TMessageEvent;              { ｵﾘｼﾞﾅﾙﾊﾝﾄﾞﾗ          }
    procedure   OnMessageHandler(var Msg:TMsg; var Handled:Boolean);
  public
  { Public 宣言 }
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;
    function    ShowHelp(ihWnd: THANDLE) : integer;
    function    ShowVersion(ihWnd: THANDLE) : integer;
  published
  { Published 宣言 }
    property Version     : TVersion    read FVersion      write FVersion stored False;
    property HFormClass  : string      read FHFormClass   write FHFormClass;
  end;


{ ﾌﾟﾛｼｰｼﾞｬ、関数宣言 }
{$IFNDEF HREG}
procedure Register;                                     { ｺﾝﾎﾟｰﾈﾝﾄの登録 }
{$ENDIF}


{
******************************************************************************
	implementation部
******************************************************************************
}
implementation




{
-----------------------------------------------------------------------
	Foregound Window Check
-----------------------------------------------------------------------
}
function IsForegound: Boolean;
begin

  Result := GetCurrentThreadID = GetWindowThreadProcessId(GetForeGroundWindow, Nil)

end;

{
-----------------------------------------------------------------------
	TMessageReceiver ｺﾝｽﾄﾗｸﾀ
-----------------------------------------------------------------------
}
constructor TMessageReceiver.Create( AOwner :TComponent);
begin
  inherited Create(AOwner);
end;

{
-----------------------------------------------------------------------
	TMessageReceiver ﾃﾞｽﾄﾗｸﾀ
-----------------------------------------------------------------------
}
Destructor  TMessageReceiver.Destroy;
begin
  inherited Destroy;
end;

{
---------------------------------------------------------------------------
	  THHelpSocket ｺﾝｽﾄﾗｸﾀ
---------------------------------------------------------------------------
}
constructor THHelpSocket.Create(AOwner: TComponent);
var
  FIni         : TInifile;                  // SFlite.INI

begin

  { 派生元呼び出し }
  inherited Create(AOwner);

  FVersion     := HHelpSocketVersion;

  { ﾒﾝﾊﾞ初期化 }
  FReceiver    := TMessageReceiver.Create(self);
  MainForm := TForm(AOwner);

  OnMessageCounter := 0;

  { OnMessageｲﾍﾞﾝﾄﾌｯｸ }
  if not (csDesigning in ComponentState) then begin
    MainForm.InsertControl( FReceiver);
    Application.ProcessMessages;                                    // ﾙｰﾌﾟ接続前のﾒｯｾｰｼﾞを全て完了させる
    OrgOnMessageHandler := Application.OnMessage;
    Application.OnMessage := OnMessageHandler;
    FOnDspHelp  := False;                             // HELP表示フラグを初期化 2000.10.20 追加
    // HELP開始タイマー設定                                                     2000.10.20 追加
    CallHelpTimer := TTimer.Create(Self);
    with CallHelpTimer do begin
      Enabled  := False;
      Interval := 100;
      OnTimer  := OnCallHelpTimer;
    end;

    // HELP DLL 設定                                                            2000.10.20 追加
    DllLoadCtl(ctHDSPHELPDLL, ctShowHelp, FHelpDllHandle, @gfpShowHelp);
    DllLoadCtl(ctHDSPHELPDLL, ctCloseHelp, FHelpDllHandle, @gfpCloseHelp);
    // DLLが有ったら、HELPパスを取得                                            2000.10.20 追加
    if FHelpDllHandle <> 0 then begin
//      FHelpPath := 'SFLITE';                                                  2001.02.26 変更
      FHelpPath := ctHSSBASEINI;
      HGetIniPath(FHelpPath);
      FIni := TInifile.Create(FHelpPath);
      StrPCopy(DspHelpParam.szHelpPath, FIni.ReadString('HELP','HELPDIR',''));
      if DspHelpParam.szHelpPath[StrLen(DspHelpParam.szHelpPath)-1] <> '\' then
        StrCat(DspHelpParam.szHelpPath, '\');
      FIni.Free;
    end;
    // Ver DLL 設定                                                            2000.10.20 追加
    DllLoadCtl(ctHDSPVERDLL, ctShowVer, FVerDllHandle, @gfpShowVer);
    DllLoadCtl(ctHDSPVERDLL, ctCloseVer, FVerDllHandle, @gfpCloseVer);

  end;


end;


{
---------------------------------------------------------------------------
	  THHelpSocket ﾃﾞｽﾄﾗｸﾀ
---------------------------------------------------------------------------
}
destructor THHelpSocket.Destroy;
begin

  if not (csDesigning in ComponentState) then begin
    Application.OnMessage := OrgOnMessageHandler;
    // タイマーを解放し、HELPを表示していたらHELPをクローズ                     2000.10.20 追加
    if CallHelpTimer <> nil then begin
      CallHelpTimer.Enabled := False;
      CallHelpTimer.Free;
    end;
    // HELPを表示していたら閉じて解放                                           2000.12.07 変更
    if FOnDspHelp = True then
      if FHelpDllHandle <> 0 then begin
        gfpCloseHelp(@DspHelpParam);
//        Application.ProcessMessages;
        FreeLibrary(FHelpDllHandle);
      end;
    end;
    // を表示していたら閉じて解放                                               2000.12.07 変更
    if FVerDllHandle <> 0 then begin
      gfpCloseVer(@DspVerParam);
//      Application.ProcessMessages;
      FreeLibrary(FVerDllHandle);
    end;

  { 派生元呼び出し }
  inherited Destroy;
end;


{
---------------------------------------------------------------------------
	  THHelpSocket Windowsﾒｯｾｰｼﾞのﾌｯｸ
---------------------------------------------------------------------------
}
procedure THHelpSocket.OnMessageHandler(var Msg:TMsg; var Handled:Boolean);
var
  WinCtrl:TWinControl;
//  WinHandle : Longint;                                   { Windowハンドル格納用 }
//  RoopCnt   : integer;                                   { ループカウンタ       }

//  FIni         : TInifile;                  { 記憶するINIファイル                }

begin

  Inc(OnMessageCounter);
  if OnMessageCounter = 1 then begin

    if (MainForm.Active) and (IsForegound) then begin

      with Msg, MainForm do begin

        { 移動先ｺﾝﾄﾛｰﾙ取得 }
        WinCtrl := FindControl(hwnd);
        if (ActiveControl = nil) or (handle = hwnd) or ((WinCtrl = nil) or (WinCtrl.Owner = MainForm)) then begin

	  { 再描画の捕捉 }                                                      // 2000.10.26 移動
	  if (message = WM_KEYDOWN) and (Word(wParam) = VK_F1)
            and (ActiveControl <> nil) then begin

//
//            WinHandle := FindWindow(PChar(FHFormClass),nil);
//            if (WinHandle <> 0) then begin
//
//              for RoopCnt := 0 to sizeof(FormNamePara) - 1 do
//                FormNamePara[RoopCnt] := ' ';
//              for RoopCnt := 0 to sizeof(CtrlNamePara) - 1 do
//                CtrlNamePara[RoopCnt] := ' ';
//              strplcopy(FormNamePara,mainform.name,sizeof(FormNamePara));
//              strplcopy(CtrlNamePara,WinCtrl.name ,sizeof(CtrlNamePara));
//
//              FIni:=TInifile.Create(GetCurrentDir+'\'+'HHelpSocket.ini');
//              FIni.WriteString('HELPDATA','FORM',FormNamePara);
//              FIni.WriteString('HELPDATA','CTRL',CtrlNamePara);
//              FIni.UpdateFile;
//              FIni.Free;
//
//              PostMessage(WinHandle,WM_USER+100,integer(@FormNamePara),integer(@CtrlNamePara));
//
//
//            end;
//
//            // DLLをロードしていたらタイマーオン
//            if FHelpDllHandle <> 0 then begin
//              // DLLタイプのHELPラッパー呼び出し                                  2000.10.20 追加
//              try
//                StrPLcopy(DspHelpParam.szPgName,   ExtractFileName(Application.EXEName), sizeof(DspHelpParam.szPgName));
//                StrPLcopy(DspHelpParam.szPgTitle,  Application.Title, sizeof(DspHelpParam.szPgTitle));
//                strplcopy(DspHelpParam.szMainFormName, mainform.name, sizeof(DspHelpParam.szMainFormName));
//                strplcopy(DspHelpParam.szActvFormName, Screen.ActiveForm.name, sizeof(DspHelpParam.szActvFormName));
//                strplcopy(DspHelpParam.szFormTitle, Screen.ActiveForm.Caption, sizeof(DspHelpParam.szFormTitle));
//                strplcopy(DspHelpParam.szFormClassName, Screen.ActiveForm.ClassName ,sizeof(DspHelpParam.szFormClassName));
//                if WinCtrl <> nil then begin
//                  strplcopy(DspHelpParam.szItemName, WinCtrl.name ,sizeof(DspHelpParam.szItemName));
//                  strplcopy(DspHelpParam.szItemClassName, WinCtrl.ClassName ,sizeof(DspHelpParam.szItemClassName));
//                  DspHelpParam.nTabOrder := WinCtrl.TabOrder;
//                  DspHelpParam.nValuType := 0;                                        // 将来の拡張
//                end else begin
//                  if Screen.ActiveControl <> nil then begin
//                    strplcopy(DspHelpParam.szItemName, Screen.ActiveControl.name, sizeof(DspHelpParam.szItemName));
//                    strplcopy(DspHelpParam.szItemClassName, Screen.ActiveControl.ClassName ,sizeof(DspHelpParam.szItemClassName));
//                    DspHelpParam.nTabOrder := Screen.ActiveControl.TabOrder;
//                    DspHelpParam.nValuType := 0;                                        // 将来の拡張
//                  end;
//                end;
//                strplcopy(DspHelpParam.szValu, '' ,sizeof(DspHelpParam.szValu));    // 将来の拡張
//              except
//              end;
//              CallHelpTimer.Enabled := True;
//            end;
//
            // シフト、ALT、CTRLキーのいずれかがF1と同時に押されていれば、ヘルプは無効 2001.01.06 追加
            if (GetKeyState(VK_SHIFT) >= 0) and (GetKeyState(VK_CONTROL) >= 0) and (GetKeyState(VK_MENU) >= 0) then begin

              ShowHelp(hwnd);

            end;

          end;

        end;

      end;

    end;

  end;

  Dec(OnMessageCounter);

  { ｵﾘｼﾞﾅﾙﾊﾝﾄﾞﾗ呼び出し}
  if Assigned(OrgOnMessageHandler) then
    OrgOnMessageHandler(Msg, Handled);

end;

//*********************************************************************//
// Module Name     :  HELP表示タイマーイベント                         //
//                 :  THHelpSocket.OnCallHelpTimer                     //
// Programer       :  鹿野　幸生                                       //
// Date            :  2000.10.20                                       //
//---------------------------------------------------------------------//
// Update Note     :  2000.10.20 ＸＸ ＸＸ                             //
//*********************************************************************//
procedure  THHelpSocket.OnCallHelpTimer(Sender: TObject);
begin

  CallHelpTimer.Enabled := False;
  gfpShowHelp(@DspHelpParam);
  FOnDspHelp  := True;
//  Application.ProcessMessages;

end;

//*********************************************************************//
// Module Name     :  メッセージ初期化関数(オーバーロードタイプ１)     //
//                 :  THHelpSocket.DllLoadCtl                          //
// 引数            :  １ Ｄｌｌ名                                      //
//                 :  ２ 関数名                                        //
//                 :  ３ ＤＬＬハンドル(受け渡し)                      //
//                 :  ４ 関数ポインタ(受け渡し)                        //
// 戻り値          :  整数  True：正常終了                             //
//                 :        False５： DLL Load 失敗                    //
// Programer       :  鹿野　幸生                                       //
// Date            :  2000.10.05                                       //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function THHelpSocket.DllLoadCtl(DllNm:String;ModuleNm:String; var InsHandle:THandle;var fpProc:FARPROC):Boolean;
begin

  Result := FALSE;

  //DLLが既にﾛｰﾄﾞ済みであればﾛｰﾄﾞ処理は行わない
  if InsHandle = 0 then begin
    //DLLのﾛｰﾄﾞ
    InsHandle := LoadLibrary(PChar(DllNm));
    if InsHandle <= 0 then begin
      //ﾛｰﾄﾞ失敗
      InsHandle := 0;
      Exit;
    end;
  end;

  //ﾓｼﾞｭｰﾙﾈｰﾑが無い場合はｱﾄﾞﾚｽ取得を行わない
  if ModuleNm <> '' then begin
    //関数ｱﾄﾞﾚｽ取得
    fpProc := GetProcAddress(InsHandle,PChar(ModuleNm));
    if fpProc = nil then begin
      Exit;
    end;
  end;

  Result := TRUE;

end;

//*********************************************************************//
// Module Name     :  ヘルプ表示メソッド                               //
//                 :  THHelpSocket.ShowHlp                             //
// 引数            :  １ 無し                                          //
// 戻り値          :  整数  ゼロ：ダミー                               //
// Programer       :  鹿野　幸生                                       //
// Date            :  2000.10.26                                       //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function THHelpSocket.ShowHelp(ihWnd: THANDLE) : integer;
var
  WinHandle: Longint;
  WinCtrl:   TWinControl;
  RoopCnt:   integer;
  FIni   :   TInifile;

begin

  WinHandle := FindWindow(PChar(FHFormClass),nil);
  WinCtrl := FindControl(ihWnd);

  // EXEタイプのHELPラッパー呼び出し
  if WinHandle <> 0 then begin

    for RoopCnt := 0 to sizeof(FormNamePara) - 1 do
      FormNamePara[RoopCnt] := ' ';
    for RoopCnt := 0 to sizeof(CtrlNamePara) - 1 do
      CtrlNamePara[RoopCnt] := ' ';
    strplcopy(FormNamePara,mainform.name,sizeof(FormNamePara));
    strplcopy(CtrlNamePara,WinCtrl.name ,sizeof(CtrlNamePara));

    FIni:=TInifile.Create(GetCurrentDir+'\'+'HHelpSocket.ini');
    FIni.WriteString('HELPDATA','FORM',FormNamePara);
    FIni.WriteString('HELPDATA','CTRL',CtrlNamePara);
    FIni.UpdateFile;
    FIni.Free;

    PostMessage(WinHandle, WM_USER+100, integer(@FormNamePara), integer(@CtrlNamePara));

  end;

  // DLLをロードしていたらHELPラッパー呼び出し
  if FHelpDllHandle <> 0 then begin
    // DLLタイプのHELPラッパー呼び出し
    try
      StrPLcopy(DspHelpParam.szPgName,   ExtractFileName(Application.EXEName), sizeof(DspHelpParam.szPgName));
      StrPLcopy(DspHelpParam.szPgTitle,  Application.Title, sizeof(DspHelpParam.szPgTitle));
      strplcopy(DspHelpParam.szMainFormName, mainform.name, sizeof(DspHelpParam.szMainFormName));
      strplcopy(DspHelpParam.szActvFormName, Screen.ActiveForm.name, sizeof(DspHelpParam.szActvFormName));
      strplcopy(DspHelpParam.szFormTitle, Screen.ActiveForm.Caption, sizeof(DspHelpParam.szFormTitle));
      strplcopy(DspHelpParam.szFormClassName, Screen.ActiveForm.ClassName ,sizeof(DspHelpParam.szFormClassName));
      if WinCtrl <> nil then begin
        strplcopy(DspHelpParam.szItemName, WinCtrl.name ,sizeof(DspHelpParam.szItemName));
        strplcopy(DspHelpParam.szItemClassName, WinCtrl.ClassName ,sizeof(DspHelpParam.szItemClassName));
        DspHelpParam.nTabOrder := WinCtrl.TabOrder;
        DspHelpParam.nValuType := 0;                                      // 将来の拡張
      end else begin
        if Screen.ActiveControl <> nil then begin
          strplcopy(DspHelpParam.szItemName, Screen.ActiveControl.name, sizeof(DspHelpParam.szItemName));
          strplcopy(DspHelpParam.szItemClassName, Screen.ActiveControl.ClassName ,sizeof(DspHelpParam.szItemClassName));
          DspHelpParam.nTabOrder := Screen.ActiveControl.TabOrder;
          DspHelpParam.nValuType := 0;                                    // 将来の拡張
        end;
      end;
      strplcopy(DspHelpParam.szValu, '' ,sizeof(DspHelpParam.szValu));    // 将来の拡張
      DspHelpParam.hWnd := ihWnd;
    except
    end;
    CallHelpTimer.Enabled := True;
  end;

  result := 0;

end;

//*********************************************************************//
// Module Name     :  バージョン表示メソッド                           //
//                 :  THHelpSocket.ShowVer                             //
// 引数            :  １ 無し                                          //
// 戻り値          :  整数  ゼロ：ダミー                               //
// Programer       :  鹿野　幸生                                       //
// Date            :  2000.10.26                                       //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function THHelpSocket.ShowVersion(ihWnd: THANDLE) : integer;
var
  WinCtrl:   TWinControl;
  
begin

  // DLLをロードしていたらHELPラッパー呼び出し
  if FVerDllHandle <> 0 then begin

    WinCtrl := FindControl(ihWnd);

    // DLLタイプのHELPラッパー呼び出し
    try
      StrPLcopy(DspVerParam.szPgName,   ExtractFileName(Application.EXEName), sizeof(DspVerParam.szPgName));
      StrPLcopy(DspVerParam.szPgTitle,  Application.Title, sizeof(DspVerParam.szPgTitle));
      strplcopy(DspVerParam.szMainFormName, mainform.name, sizeof(DspVerParam.szMainFormName));
      strplcopy(DspVerParam.szActvFormName, Screen.ActiveForm.name, sizeof(DspVerParam.szActvFormName));
      strplcopy(DspVerParam.szFormTitle, Screen.ActiveForm.Caption, sizeof(DspVerParam.szFormTitle));
      strplcopy(DspVerParam.szFormClassName, Screen.ActiveForm.ClassName ,sizeof(DspVerParam.szFormClassName));
      if WinCtrl <> nil then begin
        strplcopy(DspVerParam.szItemName, WinCtrl.name ,sizeof(DspVerParam.szItemName));
        strplcopy(DspVerParam.szItemClassName, WinCtrl.ClassName ,sizeof(DspVerParam.szItemClassName));
      end else begin
        if Screen.ActiveControl <> nil then begin
          strplcopy(DspVerParam.szItemName, Screen.ActiveControl.name, sizeof(DspVerParam.szItemName));
          strplcopy(DspVerParam.szItemClassName, Screen.ActiveControl.ClassName ,sizeof(DspVerParam.szItemClassName));
        end;
      end;
      DspVerParam.hWnd := ihWnd;
    except
    end;
    gfpShowVer(@DspVerParam);
  end;

  result := 0;

end;


{$IFNDEF HREG}
{
***************************************************************************
	ｺﾝﾎﾟｰﾈﾝﾄの登録
***************************************************************************
}
procedure Register;
begin
  RegisterComponents('HSS', [THHelpSocket]);
end;
{$ENDIF}

end.
