{
******************************************************************************
  HSS ｺﾝﾎﾟｰﾈﾝﾄﾗｲﾌﾞﾗﾘ  ｢HSS｣

    ウインドウ位置記憶コンポーネント

    ﾕﾆｯﾄ名  : HMemPos.PAS
    作成者  : Kubochi
    作成日  : 1999/7
    概要  : ウインドウ位置を記憶する

        THMemPos   :   ウインドウ位置制御
// Update Note   :   2000.08.29  鹿野　幸生                                //
//                               ① WM_RECREATEイベントを解除              //
//               :   2001.02.26  鹿野　幸生                                //
//                               ① INIファイルの取得方法を変更            //
// Update Note   : 2010.07.06 noguchi タスクバーが画面外に行く現象対応     //
// Update Note   : 2015.11.16 廣瀬　亮輔                                   //
                              マルチディスプレイ対応                       //
// Update Note   : 2015.12.15 野口  悠哉                                   //
                   有効範囲外である場合デフォルト位置に表示されるよう対応  //
// Update Note   : 2015.12.16 廣瀬　亮輔                                   //
                   タスクバーが左部、上部に存在する際にウィンドウ起動位置が//
                   ずれる場合があるため対応                                //
******************************************************************************
}
unit HMemPos;

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
//      Windows,Messages, SysUtils, Classes, Forms,Inifiles, HVersion,dialogs,Controls,HLib; 2001.02.26 変更
      Windows,Messages, SysUtils, Classes, Forms,Inifiles, HVersion,dialogs,Controls,MultiMon;

  { 型宣言 }
    type

        { 表示制御ﾀｲﾌﾟ }
        TSaveType = (saDefaultType,           { ﾃﾞﾌｫﾙﾄ位置設定 }
               saSaveType    );         { ini保存ﾀｲﾌﾟ    }

        TSetType  = (sePosition,
               seRect,
               seBoth,
               seNone);             { 位置設定ﾓｰﾄﾞ   }

        TTruckType= (trNone,
               trMinimize,
               trMaximize,
               trBoth);


    {
    -----------------------------------------------------------------------
      TCustomSubClassｵﾌﾞｼﾞｪｸﾄ定義
    -----------------------------------------------------------------------
    }
        TCustomSubClass = class(TComponent)
          private
            FControl: TWinControl;          { フック対象となるコントロール   }
            FHokProc: TFarProc;           { すり替える手続き         }
            FDefProc: TFarProc;           { フック前の手続き         }
            FControlHandle: HWND;           { フック対象のハンドル       }

            procedure ConnectControl;         { 接続               }
            procedure DisconnectControl;        { 切断               }

            procedure SetControl(Value: TWinControl); { プロパティの設定         }
            procedure SetControlHandle(Value: HWND);  { プロパティの設定         }
          protected
            Handle: HWND;               { アロケートしたウィンドウ・ハンドル }

            procedure DoDestroy; virtual;       { 再構築される前と終了直前の処理 }
            procedure DoRecreated; virtual;     { 再構築された時の処理       }
            procedure HookWndProc(var Message: TMessage); virtual; { フックの動作    }
            procedure SelfWndProc(var Message: TMessage); virtual; { 再構築監視用    }
            procedure Notification(AComponent: TComponent; Operation: TOperation); override;
            property Control: TWinControl read FControl write SetControl;
          public
            constructor Create(AOwner: TComponent); override;
            destructor Destroy; override;
            property ControlHandle: HWND read FControlHandle write SetControlHandle;
          end;

    {
    -----------------------------------------------------------------------
      THMemPosｵﾌﾞｼﾞｪｸﾄ定義
    -----------------------------------------------------------------------
    }
        THMemPos = class(TCustomSubClass)
          private
          { Private 宣言 }
          FVersion   : TVersion;          { ﾊﾞｰｼﾞｮﾝ        }
          FOnShow    : TNotifyEvent;        { 元のOnShow ハンドラ  }
          FOnClose   : TCloseEvent;         { 元のOnClose ハンドラ }
          FDefault   : boolean;           { デフォルト値にセットするかしないかのフラグ }
          FDefLeft   : longint;           { デフォルトの 水平座標        }
          FDefTop    : longint;           { デフォルトの 垂直座標        }
          FDefWidth  : longint;           { デフォルトの ウインドウの幅      }
          FDefHeight   : longint;           { デフォルトの ウインドウの高さ    }
          FIni     : TInifile;          { 記憶するINIファイル          }
          FInifile   : string;            { 記憶するINIファイル名        }
          FIniSection  : string;            { ﾕｰｻﾞｰ変更用記憶INIﾌｧｲﾙｾｸｼｮﾝ      }
          FSection   : string;            { 記憶するINIファイルのセクション    }
          FSaveType  : TSaveType;         { 表示制御タイプ     }
          FSetType   : TSetType;          { 表示セットタイプ   }
          FTruckSet  : TTruckType;          { ﾄﾗｯｷﾝｸﾞｻｲｽﾞ指定ﾌﾗｸﾞ  }

          TrkMinHeight : longint;
          TrkMaxHeight : longint;
          TrkMinWidth  : longint;
          TrkMaxWidth  : longint;
          procedure HookedOnShow(Sender: TObject);  { Showのフック     }
          procedure HookedOnClose(Sender: TObject;
                   var Action:TCloseAction);{ Closeのフック    }

          protected
        { Protected 宣言 }
          MainForm      : TForm ;       { ﾒｲﾝﾌｫｰﾑ        }
          property  DefaultSet: boolean  read FDefault write FDefault default true;
          procedure SetSaveType(Value:TSaveType);
          procedure SetSetType (Value:TSetType);
          procedure SetTruckSet(Value:TTruckType);
          procedure HookWndProc(var Message: TMessage); override;

          public
      { Public 宣言 }
          constructor Create(AOwner: TComponent); override;
          destructor Destroy; override;
          procedure Loaded; override;
          property DefaultTop   : longint read FDefTop     write FDefTop;
          property DefaultLeft  : longint read FDefLeft    write FDefLeft;
          property DefaultWidth : longint read FDefWidth     write FDefWidth;
          property DefaultHeight: longint read FDefHeight    write FDefHeight;
          procedure HLoad;

          published
      { Published 宣言 }
          property Version   : TVersion read FVersion   write FVersion stored False;
          property Inifile    : string  read FInifile   write FInifile;
          property SaveType   : TSaveType  read FSaveType write SetSaveType ;
          property SetType    : TSetType   read FSetType  write SetSetType;
          property TruckSet   : TTruckType read FTruckSet write SetTruckSet;
          property IniSection   : string     read FIniSection write FIniSection;

          end;


  { ﾌﾟﾛｼｰｼﾞｬ、関数宣言 }
  {$IFNDEF HREG}
  procedure Register;                   { ｺﾝﾎﾟｰﾈﾝﾄの登録 }
  {$ENDIF}

{
******************************************************************************
  implementation部
******************************************************************************
}
implementation

  uses
    HFslLib;

    const
      csWM_RECREATED = 'WM_RECREATED';                     // フックしたコントロールが再構築された場合の登録メッセージ名

    var
      WM_RECREATED: Cardinal;                        // 登録後のメッセージID

  {
  ---------------------------------------------------------------------------
    THMemPos  ｺﾝｽﾄﾗｸﾀ
  ---------------------------------------------------------------------------
  }
    constructor THMemPos.Create(AOwner: TComponent);
    begin
    { 派生元呼び出し }
      inherited Create(AOwner);

      FVersion     := HMemPosVersion;
      Inifile    := 'HMEMPOSI';
      IniSection   := '';
      DefaultSet   := True;
      SaveType     := saDefaultType;
      SetType    := seBoth;
      TruckSet     := trNone;

    { ﾒﾝﾊﾞ初期化 }
    MainForm := TForm(AOwner);
      Control  := mainform;

    end;


  {
  ---------------------------------------------------------------------------
    THMemPos  ﾃﾞｽﾄﾗｸﾀ
  ---------------------------------------------------------------------------
  }
    destructor THMemPos.Destroy;
    begin
      if not (csDesigning in ComponentState) then
      begin
        FIni.Free;  //  INIファイルオブジェクト 開放
        MainForm.OnShow  := FOnShow;
        MainForm.OnClose := FOnClose;
      end;

      { 派生元呼び出し }
      inherited Destroy;
    end;


  {
  ---------------------------------------------------------------------------
    THMemPos  Loaded
  ---------------------------------------------------------------------------
  }
    procedure THMemPos.Loaded;
    var
      strProg:string;
    begin
      { 派生元呼び出し }
      inherited Loaded;

      if not (csDesigning in ComponentState) then
      begin
      (*  INI ファイル名にする  *)
        if Length(FInifile)=0 then Inifile:=Application.Title;

//        strProg := trim(HIniPathMakeLib(FInifile));                                  2001.02.26 変更
//        if strProg = '' then
//          strProg:=ChangeFileExt(ExtractFilePath(Application.ExeName)+FInifile+'.INI');
        HGetIniPath(FInifile);
        strProg := FInifile;

      (*  IniSectionに指定セクションが無ければ               *)
      (*  EXEファイル名 DLLファイル名,ウインドウ名で セクション名を作る  *)
        if Length(IniSection) = 0 then
        FSection:=ExtractFileName(Application.ExeName)
            +ExtractFileName(Application.Title)
            +MainForm.Name
        else
      (*  IniSectionに指定セクションが有ればプロパティー値を使用する     *)
        FSection:=IniSection;
        
        FIni:=TInifile.Create(strProg);

      (* 最小ﾄﾗｯｷﾝｸﾞｻｲｽﾞの取得 *)
        TrkMinHeight := FIni.ReadInteger(FSection, 'TruckMinHeight'  , -1);
        TrkMaxHeight := FIni.ReadInteger(FSection, 'TruckMaxHeight'  , -1);

      (* 最大ﾄﾗｯｷﾝｸﾞｻｲｽﾞの取得 *)
        TrkMinWidth  := FIni.ReadInteger(FSection, 'TruckMinWidth'   , -1);
        TrkMaxWidth  := FIni.ReadInteger(FSection, 'TruckMaxWidth'   , -1);

        FOnShow:=MainForm.OnShow;    //  OnShowイベントをフック
        MainForm.OnShow:=HookedOnShow;

        FOnClose:=MainForm.OnClose;  //  OnCloseイベントをフック
        MainForm.OnClose:=HookedOnClose;

      end;
    end;


  {
  ---------------------------------------------------------------------------
    THMemPos  HookedOnShow
  ---------------------------------------------------------------------------
  }
    procedure THMemPos.HookedOnShow(Sender: TObject);
    begin
      (*  元のハンドラを呼び出す  *)
      if Assigned(FOnShow) then FOnShow(Sender);

      HLoad;

    end;


  {
  ---------------------------------------------------------------------------
    THMemPos  HookedOnClose
  ---------------------------------------------------------------------------
  }
    procedure THMemPos.HookedOnClose(Sender: TObject; var Action: TCloseAction);
    var
      wp: TWindowPlacement;
      ws: integer;
    begin

      (*  位置を記憶するか判定  *)
      try

      wp.length:=sizeof(wp);
      MainForm.HandleNeeded;
      GetWindowPlacement(MainForm.Handle, @wp);
      FIni.WriteString(FSection, 'caption', MainForm.Caption);
      if (FSaveType = saSaveType)
      and((FSetType = sePosition) or (FSetType = seBoth)) then
        begin
        (*  INI ファイルに書き込む  *)
        FIni.WriteInteger(FSection, 'Left', wp.rcNormalPosition.Left);
        FIni.WriteInteger(FSection, 'Top' , wp.rcNormalPosition.Top);
        end;
      FIni.UpdateFile;

      (*  大きさを記憶するか判定  *)
      if (FSaveType = saSaveType)
      and((FSetType = seRect) or (FSetType = seBoth)) then
        begin
        (*  INIファイルに書き込む  *)
        FIni.WriteInteger(FSection, 'Width', wp.rcNormalPosition.Right-wp.rcNormalPosition.Left);
        FIni.WriteInteger(FSection, 'Height' , wp.rcNormalPosition.Bottom-wp.rcNormalPosition.Top);
        if IsZoomed(MainForm.Handle) then
          begin
          ws:=1;
          end else begin
          ws:=0;
          end;
        FIni.WriteInteger(FSection, 'Status' , ws);
        end;
      FIni.UpdateFile;
      except
      end;

      (*  元のハンドラを呼び出す  *)
      if Assigned(FOnClose) then
      begin
        FOnClose(Sender, Action);
      end
    end;


  {
  ---------------------------------------------------------------------------
    THMemPos  SetSaveType
  ---------------------------------------------------------------------------
  }
    procedure THMemPos.SetSaveType(Value:TSaveType);
    begin
      if FSaveType <> Value then
        FSaveType := Value;
    end;

  {
  ---------------------------------------------------------------------------
    THMemPos  SetSetType
  ---------------------------------------------------------------------------
  }
    procedure THMemPos.SetSetType (Value:TSetType);
    begin
      if FSetType <> Value then
        FSetType := Value;
    end;

  {
  ---------------------------------------------------------------------------
    THMemPos  SetTruckSet
  ---------------------------------------------------------------------------
  }
    procedure THMemPos.SetTruckSet(Value:TTruckType);
    begin
      if FTruckSet <> Value then
        FTruckSet := Value;
    end;

  {
  ---------------------------------------------------------------------------
    THMemPos  Reload
  ---------------------------------------------------------------------------
  }
    procedure THMemPos.HLoad;
    var
      wp: TWindowPlacement;
      I : integer;
      offScreenFlg : Boolean;
      formPtUpLeft : TPoint;
      formPtUpRight : TPoint;
      formPtBtmLeft : TPoint;
      formPtBtmRight : TPoint;
    begin
      if DefaultSet then begin

        (*  デフォルト値を求める  *)
        if FSaveType = saDefaultType then begin
          DefaultLeft  :=FIni.ReadInteger(FSection, 'DefaultLeft'  , MainForm.Left);
          DefaultTop   :=FIni.ReadInteger(FSection, 'DefaultTop'   , MainForm.Top);
          if(MainForm.BorderStyle=bsSizeable)or(MainForm.BorderStyle=bsSizeToolWin) then begin
            DefaultWidth :=FIni.ReadInteger(FSection, 'DefaultWidth' , MainForm.Width);
            DefaultHeight:=FIni.ReadInteger(FSection, 'DefaultHeight', MainForm.Height);
          end else begin
            DefaultWidth :=MainForm.Width;
            DefaultHeight:=MainForm.Height;
          end;
        end else begin
          DefaultLeft  :=FIni.ReadInteger(FSection, 'Left'  , MainForm.Left);
          DefaultTop   :=FIni.ReadInteger(FSection, 'Top' , MainForm.Top);
          if(MainForm.BorderStyle=bsSizeable)or(MainForm.BorderStyle=bsSizeToolWin) then begin
            DefaultWidth :=FIni.ReadInteger(FSection, 'Width' , MainForm.Width);
            DefaultHeight:=FIni.ReadInteger(FSection, 'Height', MainForm.Height);
          end else begin
            DefaultWidth :=MainForm.Width;
            DefaultHeight:=MainForm.Height;
          end;
        end;

        if FSetType = seNone then begin
          DefaultLeft  :=MainForm.Left;
          DefaultTop   :=MainForm.Top;
          DefaultWidth :=MainForm.Width;
          DefaultHeight:=MainForm.Height;
        end else if FSetType = sePosition then begin
          DefaultWidth :=MainForm.Width;
          DefaultHeight:=MainForm.Height;
        end else if FSetType = seRect then begin
          DefaultLeft  :=MainForm.Left;
          DefaultTop   :=MainForm.Top;
        end;

        (*
         *  ウインドウの位置を設定する
         *------------------------------*)
        // --- DEL 2015.11.16 30362 廣瀬 マルチディスプレイ対応 ---------->>>>>
        //if (DefaultTop+DefaultHeight)>Screen.Height then
        //DefaultTop:=Screen.Height-DefaultHeight;
        //
        //if (DefaultLeft+DefaultWidth)>Screen.Width then
        //DefaultLeft:=Screen.Width-DefaultWidth;
        // --- DEL 2015.11.16 30362 廣瀬 マルチディスプレイ対応 ----------<<<<<

        // --- ADD 2015.11.16 30362 廣瀬 マルチディスプレイ対応 ---------->>>>>

        //全ディスプレイ領域内の範囲で移動(マルチディスプレイ時のマイナス座標を考慮)
        //(DesktopTop(Width)はメインディスプレイからの座標となるため)
        //======================================================================
        // DefaultTop:アプリケーションの上端座標
        // DefaultLeft:アプリケーションの左端座標
        // DefaultHeight：アプリケーションの縦幅
        // DefaultWidth：アプリケーションの横幅
        // Screen.DesktopLeft：マルチディスプレイ含めたメインディスプレイからの左端座標
        // Screen.DesktopTop：マルチディスプレイ含めたメインディスプレイからの上端座標
        // Screen.DesktopWidth：マルチディスプレイ含めたディスプレイ全体の横幅
        // Screen.DesktopHeight：マルチディスプレイ含めたディスプレイ全体の縦幅
        // Screen.WorkAreaTop：タスクバーを考慮したメインディスプレイの上端
        // Screen.WorkAreaLeft：タスクバーを考慮したメインディスプレイの左端
        // Screen.WorkAreaHeight：タスクバーを考慮したメインディスプレイの縦幅
        // Screen.WorkAreaWidth：タスクバーを考慮したメインディスプレイの横幅

        //対象画面座標
        formPtUpLeft   := Point(DefaultLeft,DefaultTop);
        formPtUpRight  := Point(DefaultLeft + DefaultWidth,DefaultTop);
        formPtBtmLeft  := Point(DefaultLeft,DefaultTop + DefaultHeight);
        formPtBtmRight := Point(DefaultLeft + DefaultWidth,DefaultTop + DefaultHeight);

        // --- ADD 2015.12.15 31017 野口 対象画面がディスプレイ有効範囲外である場合を考慮 --->>>>>
        // 初期化
        offScreenFlg := False;
        //ディスプレイの数分繰り返し
        for I := 0 to Screen.MonitorCount - 1 do begin
          //対象画面が配置されるディスプレイを特定
          if (PtInRect(Screen.Monitors[I].WorkareaRect,formPtUpLeft  ) = False) and
             (PtInRect(Screen.Monitors[I].WorkareaRect,formPtUpRight ) = False) and
             (PtInRect(Screen.Monitors[I].WorkareaRect,formPtBtmLeft ) = False) and
             (PtInRect(Screen.Monitors[I].WorkareaRect,formPtBtmRight) = False) then begin
            //完全に対象ディスプレイ外
            offScreenFlg := True;
          end else begin
            if (PtInRect(Screen.Monitors[I].WorkareaRect,formPtUpLeft  ) = True) and
               (PtInRect(Screen.Monitors[I].WorkareaRect,formPtUpRight ) = True) and
               (PtInRect(Screen.Monitors[I].WorkareaRect,formPtBtmLeft ) = True) and
               (PtInRect(Screen.Monitors[I].WorkareaRect,formPtBtmRight) = True) then begin
                //対象ディスプレイ内
                offScreenFlg := False;
                //前回位置に表示してOK
                break;
              end else begin
                //ディスプレイ外にはみ出ている
                offScreenFlg := False;
                break;
              end;
          end;
        end;
        // --- ADD 2015.12.15 31017 野口 対象画面がディスプレイ有効範囲外である場合を考慮 ---<<<<<

        //最上端より上の座標の場合
        if ((DefaultTop) < Screen.DesktopTop) then
          DefaultTop := Screen.DesktopTop;

        //最左端より左の座標の場合
        if ((DefaultLeft) < Screen.DesktopLeft) then
          DefaultLeft := Screen.DesktopLeft;

        //最下端より下の座標の場合
        if (DefaultTop + DefaultHeight) > (Screen.DesktopHeight + Screen.DesktopTop) then
          DefaultTop := Screen.DesktopHeight + Screen.DesktopTop - DefaultHeight;

        //最右端より右の座標の場合
        if (DefaultLeft + DefaultWidth) > (Screen.DesktopWidth + Screen.DesktopLeft) then
          DefaultLeft := Screen.DesktopWidth + Screen.DesktopLeft - DefaultWidth;

        // --- DEL 2015.12.16 30362 廣瀬 マルチディスプレイ対応 ---------->>>>>
        ////メインディスプレイ上に存在する場合にタスクバーを考慮して位置移動
        //if (DefaultTop >= 0) and (DefaultTop < Screen.Height) and          //縦方向の位置確認
        //   (DefaultLeft >= 0) and (DefaultLeft < Screen.Width) then begin  //横方向の位置確認
        // --- DEL 2015.12.16 30362 廣瀬 マルチディスプレイ対応 ----------<<<<<

        // --- ADD 2015.12.16 30362 廣瀬 マルチディスプレイ対応 ---------->>>>>
        if (DefaultTop + Screen.WorkAreaTop >= 0) and (DefaultTop < Screen.Height) and          //縦方向の位置確認
           (DefaultLeft + Screen.WorkAreaLeft >= 0) and (DefaultLeft < Screen.Width) then begin  //横方向の位置確認

          //メインディスプレイの場合、タスクバー位置を考慮して位置調整を行う必要がある。
          if (Screen.WorkAreaTop > 0) then DefaultTop := DefaultTop + Screen.WorkAreaTop;
          if (Screen.WorkAreaLeft > 0) then DefaultLeft := DefaultLeft + Screen.WorkAreaLeft;
        // --- ADD 2015.12.16 30362 廣瀬 マルチディスプレイ対応 ----------<<<<<

          //縦方向の飛出を抑制
          //上端抑制
          if (DefaultTop < Screen.WorkAreaTop) then
            DefaultTop := Screen.WorkAreaTop;

          if ((DefaultTop + DefaultHeight) > (Screen.WorkAreaHeight + Screen.WorkAreaTop)) then
            DefaultTop := DefaultTop - ((DefaultTop + DefaultHeight) - (Screen.WorkAreaHeight + Screen.WorkAreaTop));

          //横方向の飛出を抑制
          //左端抑制
          if (DefaultLeft < Screen.WorkAreaLeft) then
            DefaultLeft := Screen.WorkAreaLeft;

          if ((DefaultLeft + DefaultWidth) > (Screen.WorkAreaWidth + Screen.WorkAreaLeft)) then
            DefaultLeft := DefaultLeft - ((DefaultLeft+DefaultWidth) - (Screen.WorkAreaWidth + Screen.WorkAreaLeft));
        end;

        // --- ADD 2015.12.15 31017 野口 対象画面がディスプレイ有効範囲外である場合を考慮 --->>>>>
        if (offScreenFlg = True) then begin
          //ディスプレイ外である場合メインディスプレイの中央に表示
          DefaultLeft  := MainForm.Left;
          DefaultTop   := MainForm.Top;
          DefaultWidth := MainForm.Width;
          DefaultHeight:= MainForm.Height;
        end;
        // --- ADD 2015.12.15 31017 野口 対象画面がディスプレイ有効範囲外である場合を考慮 ---<<<<<
        // --- ADD 2015.11.16 30362 廣瀬 マルチディスプレイ対応 ----------<<<<<

        // --- DEL 2015.11.16 30362 廣瀬 マルチディスプレイ対応 ---------->>>>>
        ////2010.07.06 noguchi タスクバーが画面外に行く現象対応 >>
        //
        //if(DefaultTop < 0)then
        //    DefaultTop := 0;
        //
        //if(DefaultLeft < 0) then
        //    DefaultLeft := 0;
        //
        ////>> 2010.07.06 noguchi タスクバーが画面外に行く現象対応
        // --- DEL 2015.11.16 30362 廣瀬 マルチディスプレイ対応 ----------<<<<<

        // --- ADD 2015.11.16 30362 廣瀬 マルチディスプレイ対応 ---------->>>>>
        //上記の調整により画面外に出る場合には画面の左上に表示
        //(画面がディスプレイより大きい場合を考慮)
        if(DefaultTop < Screen.DesktopTop)then
            DefaultTop := Screen.DesktopTop;

        if(DefaultLeft < Screen.DesktopLeft) then
            DefaultLeft := Screen.DesktopLeft;
        // --- ADD 2015.11.16 30362 廣瀬 マルチディスプレイ対応 ----------<<<<<

        wp.length:=sizeof(wp);
        GetWindowPlacement(MainForm.Handle, @wp);
        with wp.rcNormalPosition do begin
          Left:=DefaultLeft;
          Top:=DefaultTop;
          Right:=DefaultLeft+DefaultWidth;
          Bottom:=DefaultTop+DefaultHeight;
        end;

        if FSaveType = saDefaultType then begin
          if (FIni.ReadInteger(FSection, 'DefaultStatus', 0)=1)
          and((FSetType = seRect) or (FSetType = seBoth)) then begin
          (*  Maximized  *)
            wp.showCmd:=SW_SHOWMAXIMIZED;
            SetWindowPlacement(MainForm.Handle, @wp);
          end else begin
            wp.showCmd:=SW_SHOWNORMAL;
            MainForm.SetBounds(DefaultLeft, DefaultTop, DefaultWidth, DefaultHeight);
          end;
        end else begin
          if (FIni.ReadInteger(FSection, 'Status', 0)=1)
          and((FSetType = seRect) or (FSetType = seBoth)) then begin
          (*  Maximized  *)
            wp.showCmd:=SW_SHOWMAXIMIZED;
            SetWindowPlacement(MainForm.Handle, @wp);
          end else begin
            wp.showCmd:=SW_SHOWNORMAL;
            MainForm.SetBounds(DefaultLeft, DefaultTop, DefaultWidth, DefaultHeight);
          end;
        end;
      end;

    end;

  {
  ---------------------------------------------------------------------------
    THMemPos  Reload
  ---------------------------------------------------------------------------
  }
    procedure THMemPos.HookWndProc(var Message: TMessage);
    begin
      inherited HookWndProc(Message);
      
      case (Message.Msg) of
      WM_GETMINMAXINFO:
        begin
          {最小ﾄﾗｯｷﾝｸﾞｻｲｽﾞの指定}
          if((FTruckSet = trMinimize)
           or(FTruckSet = trBoth))
          and(TrkMinWidth  >= 0)
          and(TrkMinHeight >= 0) then
            with TWMGetMinMaxInfo(Message).MinMaxInfo^ do begin
              ptMinTrackSize.x := TrkMinWidth;
              ptMinTrackSize.y := TrkMinHeight;
            end;

          {最大ﾄﾗｯｷﾝｸﾞｻｲｽﾞの指定}
          if((FTruckSet = trMaximize)
           or(FTruckSet = trBoth))
          and(TrkMaxWidth  >= 0)
          and(TrkMaxHeight >= 0) then
            with TWMGetMinMaxInfo(Message).MinMaxInfo^ do begin
              ptMaxTrackSize.x := TrkMaxWidth;
              ptMaxTrackSize.y := TrkMaxHeight;
            end;
        end;
      end;
    end;

  {$IFNDEF HREG}
  {
  ***************************************************************************
    ｺﾝﾎﾟｰﾈﾝﾄの登録
  ***************************************************************************
  }
  procedure Register;
  begin
    RegisterComponents('HSS', [THMemPos]);
  end;
  {$ENDIF}


  {
  ---------------------------------------------------------------------------
    TCustomSubClass    ｺﾝｽﾄﾗｸﾀ
  ---------------------------------------------------------------------------
  }
    constructor TCustomSubClass.Create(AOwner: TComponent);
    begin
    { 派生元呼び出し }
      inherited Create(AOwner);

      WM_RECREATED := RegisterWindowMessage(csWM_RECREATED);
      FHokProc := MakeObjectInstance(HookWndProc);
      Handle := AllocateHWnd(SelfWndProc);
    end;

  {
  ---------------------------------------------------------------------------
    TCustomSubClass    ﾃﾞｽﾄﾗｸﾀ
  ---------------------------------------------------------------------------
  }
    destructor TCustomSubClass.Destroy;
    begin
      DisconnectControl;
      DeallocateHWnd(Handle);
      FreeObjectInstance(FHokProc);
      { 派生元呼び出し }
      inherited Destroy;
    end;

  {
  ---------------------------------------------------------------------------
    TCustomSubClass    ConnectControl
  ---------------------------------------------------------------------------
  }
    procedure TCustomSubClass.ConnectControl;
    begin
      if csDesigning in ComponentState then Exit;

      FControl.FreeNotification(Self);
      FDefProc := TFarProc(SetWindowLong(FControlHandle, GWL_WNDPROC, Longint(FHokProc)));
    end;

  {
  ---------------------------------------------------------------------------
    TCustomSubClass    DisconnectControl
  ---------------------------------------------------------------------------
  }
    procedure TCustomSubClass.DisconnectControl;
    begin
      {コントロールと切り放します。ある程度のチェックは外部で終了済みとする}
      {すり替えていた手続きを元に戻せるならば戻す }
      if csDesigning in ComponentState then Exit;

      if (FControl <> Nil) and (FControlHandle <> 0) then begin
         if isWindow(FControlHandle) then begin
          SetWindowLong(FControlHandle, GWL_WNDPROC, Longint(FDefProc));
         end;
      end;
    end;

  {
  ---------------------------------------------------------------------------
    TCustomSubClass    SetControl
  ---------------------------------------------------------------------------
  }
    procedure TCustomSubClass.SetControl(Value: TWinControl);
    begin
      if FControl = Value then Exit;

      if not (csDesigning in ComponentState) and Assigned(FControl)
        and (FControl.HandleAllocated) then
          DisconnectControl;

      FControl := Value;  (* 値の設定 *)

      if Value = Nil then
        FControlHandle := 0
      else
        FControlHandle := Value.Handle;

      if not (csDesigning in ComponentState) and Assigned(FControl) then
        ConnectControl;
    end;

  {
  ---------------------------------------------------------------------------
    TCustomSubClass    SetControlHandle
  ---------------------------------------------------------------------------
  }
    procedure TCustomSubClass.SetControlHandle(Value: HWND);
    begin
      if FControlHandle = Value then Exit;

      FControl := Nil;
      FControlHandle := Value;
    end;

  {
  ---------------------------------------------------------------------------
    TCustomSubClass    SetControlHandle
  ---------------------------------------------------------------------------
  }
    procedure TCustomSubClass.DoDestroy;
    begin
//                                                                              2000.08.29 削除
//      PostMessage(Handle, WM_RECREATED, 0, 0);

      if FControl <> Nil then
        DisconnectControl;
    end;

  {
  ---------------------------------------------------------------------------
    TCustomSubClass    SetControlHandle
  ---------------------------------------------------------------------------
  }
    procedure TCustomSubClass.DoRecreated;
    begin
      if FControl <> Nil then begin
        FControlHandle := FControl.Handle;
        ConnectControl;
      end else begin
        FControlHandle := 0;
      end;
    end;

  {
  ---------------------------------------------------------------------------
    TCustomSubClass    HookWndProc
  ---------------------------------------------------------------------------
  }
    procedure TCustomSubClass.HookWndProc(var Message: TMessage);
    begin
       with Message do begin
         case Msg of
         WM_DESTROY: DoDestroy;
         end;
         Result := CallWindowProc(FDefProc, FControlHandle, Msg, WParam, LParam);
      end;
    end;

  {
  ---------------------------------------------------------------------------
    TCustomSubClass    SelfWndProc
  ---------------------------------------------------------------------------
  }
    procedure TCustomSubClass.SelfWndProc(var Message: TMessage);
    begin
      with Message do begin
//                                                                              2000.08.29 削除
//         if Msg = WM_RECREATED then DoRecreated; // 再構築監視用 変数なのでifで判断
         Result := DefWindowProc(Handle, Msg, WParam, LParam);
      end;
    end;

  {
  ---------------------------------------------------------------------------
    TCustomSubClass    Notification
  ---------------------------------------------------------------------------
  }
    procedure TCustomSubClass.Notification(AComponent: TComponent; Operation: TOperation);
    begin
      inherited;
      if (AComponent = FControl) and (Operation = opRemove) then
        FControl := Nil;
    end;


end.

