{
******************************************************************************
	HSS ｺﾝﾎﾟｰﾈﾝﾄﾗｲﾌﾞﾗﾘ  ｢HSS｣

		ｶｰｿﾙ移動ｺﾝﾄﾛｰﾙ

		ﾕﾆｯﾄ名  :   HFOCUS.PAS
		作成者  :   Kubochi
		作成日  :   1999/7
		概要    :   ｱﾌﾟﾘｹｰｼｮﾝに矢印ｷｰによる上下左右のﾌｫｰｶｽ移動、及び、RETｷｰ
					による前後のﾌｫｰｶｽ移動機能を付加するために、以下のｺﾝﾎﾟｰﾈﾝﾄ
					を定義する

						THArrowKeyControl   :   矢印ｷｰによるﾌｫｰｶｽ移動制御
			       		        THRetKeyControl     :   RETｷｰによるﾌｫｰｶｽ移動制御
//                  :   2003.04.03  鹿野　幸生                          //
//                  :   ① MDI・子画面のコンボボックスでALT+↓キー押下の//
//                  :      際、親画面にフォーカスが移動する障害を解除   //
//                  :   2003.04.14  鹿野　幸生                          //
//                  :   ① 子画面から戻る際、親側にフォーカスの行き所が //
//                  :      無い場合、アドレスエラーが発生していた障害を //
//                  :      解除                                         //
//                  :   2003.05.01  鹿野　幸生                          //
//                  :   ① 04.14の対応内容に不足が有ったのを修正        //
//                  :   2003.07.22  鹿野　幸生                          //
//                  :   ① 05.01の対応内容に不備が有り、RadioButtonの   //
//                  :      アローキーがおかしくなっていたのと、Always-  //
//                  :      Eventの際でもイベントが発生しないケースが有っ//
//                  :      たのを修正                                   //
//                  :   20090811 iwa HSS100修正なし
******************************************************************************
}
unit HFocus;

{$DEFINE UPDATE}
{$DEFINE HREG}
//{$DEFINE PHOENIX}
{$DEFINE SASA}
//{$DEFINE VDATE_PLUS}
{
******************************************************************************
	interface部
******************************************************************************
}
interface

	{ ﾕﾆｯﾄ指定 }
	uses
		SysUtils, WinTypes, WinProcs, Messages, Classes, Graphics, Controls,
		Forms, StdCtrls, Grids, ExtCtrls,{ PButton, }HVersion,
		HEdit, HDedit,{XTedit, XVedit, XCalendr,} HLib,{ XFkeyBtn,}ComCtrls,HDblBtn,dialogs;

	{ 型宣言 }
	type
		{ ﾌｫｰｶｽｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ型 }
		TFocusEvent = procedure(
				PrevCtrl:TWinControl;           { 現在のｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ     }
				var NextCtrl:TWinControl;       { 次にｱｸﾃｨﾌﾞになるｺﾝﾄﾛｰﾙ }
				VkCode:Word                     { 仮想ｷｰｺｰﾄﾞ             }
		) of object;

		{ フォーカス脱出イベント型 }
		TAfterFocusedEvent = procedure(
				NowCtrl :TWinControl           { ﾌｫｰｶｽの移ったｺﾝﾄﾛｰﾙ }
		) of object;


		{
		-----------------------------------------------------------------------
			FocusChangedイベント取得ｵﾌﾞｼﾞｪｸﾄ定義
		-----------------------------------------------------------------------
		}
		TMessageReceiver = class(TControl)
		private
			{ Private 宣言 }
			FAfterFocused :TAfterFocusedEvent ;
		protected
			{ Protected 宣言 }
			procedure CMFocusChanged( var Message:TCMFocusChanged) ; Message CM_FOCUSCHANGED;
		 public
			{ Public 宣言 }
			constructor Create(AOwner:TComponent); override;
			destructor  Destroy; override;
		published
			{ Published 宣言 }
			property AfterFocused :TAfterFocusedEvent read FAfterFocused write FAfterFocused;
		end;


		{
		-----------------------------------------------------------------------
			THArrowKeyControlｵﾌﾞｼﾞｪｸﾄ定義
		-----------------------------------------------------------------------
		}
		THArrowKeyControl = class(TComponent)
		private
                        FVersion :TVersion;
			FStyleV:TArrowFocusSeq;                         { 縦ﾌｫｰｶｽ移動ﾀｲﾌﾟ  }
			FStyleH:TArrowFocusSeq;                         { 横ﾌｫｰｶｽ移動ﾀｲﾌﾟ  }
			FOnChangeFocus:TFocusEvent;                     { ﾌｫｰｶｽ変更ｲﾍﾞﾝﾄ   }
			FCatchMouse:Boolean;                            { ﾏｳｽ捕捉ﾌﾗｸﾞ      }
			FAlwaysEvent:Boolean;                           { Nextなし捕捉     }
			FReceiver   :TMessageReceiver;
			FAfterOnChangeFocus :TAfterFocusedEvent;        { ﾌｫｰｶｽ遷移後ｲﾍﾞﾝﾄ }
			//Add(1997.1.17)
			FArrowRightClick :Boolean ;                     { 右ｸﾘｯｸﾌﾗｸﾞ       }
		protected
			oMainForm:TForm;                                 { ﾒｲﾝﾌｫｰﾑ          }
			OnMessageCounter:Integer;                       { ﾊﾝﾄﾞﾗ再入ｶｳﾝﾀ    }
			OrgOnMessageHandler:TMessageEvent;              { ｵﾘｼﾞﾅﾙﾊﾝﾄﾞﾗ      }

		protected
			procedure   OnMessageHandler(var Msg:TMsg; var Handled:Boolean);
			function    CanExit(Control:TControl; var VKey:Word):Boolean;
			procedure   SpecialKeyAssign(Control:TControl; var VKey:Word);
			procedure   DoChangeFocus(PrevCtrl:TWinControl; var NextCtrl:TWinControl; VkCode:Word);
//			function    XTableControl(ActiveControl:TWinControl; KeyMsg:TMsg):Boolean;
			Procedure   DoAfterChangeFocus( NowCtrl:TWinControl );

		public
			constructor Create(AOwner:TComponent); override;
			destructor  Destroy; override;

		published
                        property    Version: TVersion read FVersion write FVersion stored False;
			property    StyleV:TArrowFocusSeq read FStyleV write FStyleV;
			property    StyleH:TArrowFocusSeq read FStyleH write FStyleH;
			property    OnChangeFocus:TFocusEvent read FOnChangeFocus write FOnChangeFocus;
			property    CatchMouse:Boolean read FCatchMouse write FCatchMouse;
			property    AlwaysEvent:Boolean read FAlwaysEvent write FAlwaysEvent;
						//削除(1997.03.11)
			//property    AfterOnChangeFocus:TAfterFocusedEvent  read FAfterOnChangeFocus write FAfterOnChangeFocus;
			//Add(1997.1.17)
			property    ArrowRightClick :Boolean read FArrowRightClick write FArrowRightClick;
		end;

		{
		-----------------------------------------------------------------------
			THRetKeyControlｵﾌﾞｼﾞｪｸﾄ定義
		-----------------------------------------------------------------------
		}
		THRetKeyControl = class(TComponent)
		private
                        FVersion: TVersion;
			FStyle:TRetFocusSeq;                            { ﾌｫｰｶｽ移動ﾀｲﾌﾟ  }
			FCirculate:Boolean;                             { 循環ﾌﾗｸﾞ       }
			FInitFocus:Boolean;                             { ﾌｫｰｶｽ初期化    }
			FTabEnable:Boolean;                             { TABｷｰ有効      }
			FOnChangeFocus:TFocusEvent;                     { ﾌｫｰｶｽ変更ｲﾍﾞﾝﾄ }
			FCatchMouse:Boolean;                            { ﾏｳｽ捕捉ﾌﾗｸﾞ    }
			FAlwaysEvent:Boolean;                           { Nextなし捕捉     }
			FReceiver   :TMessageReceiver;
			FAfterOnChangeFocus :TAfterFocusedEvent;       { ﾌｫｰｶｽ遷移後ｲﾍﾞﾝﾄ }
			//Add(1997.1.17)
			FArrowRightClick: Boolean ;                     { 右ｸﾘｯｸﾌﾗｸﾞ       }
                        FExtendEnter: Boolean;
		protected
			OnMessageCounter:Integer;
			oMainForm:TForm;
			OrgOnMessageHandler:TMessageEvent;
			OrgOnShowHandler:TNotifyEvent;

		protected
			procedure   OnMessageHandler(var Msg:TMsg; var Handled:Boolean);
			procedure   OnShowHandler(Sender:TObject);
			function    CanExit(Control:TControl; var VKey:Word):Boolean;
(* Add matsu 1997-10-02 for Extended Enter Ket *)
//			procedure   DoChangeFocus(PrevCtrl:TWinControl; var NextCtrl:TWinControl; VkCode:Word);
                        procedure   DoChangeFocus(PrevCtrl:TWinControl;
                                      var NextCtrl:TWinControl; VkCode:Word; Flags: LPARAM);
(* Add End *)
//                        function    XTableControl(ActiveControl:TWinControl; Key:Word):Boolean;
			Procedure   DoAfterChangeFocus( NowCtrl:TWinControl );

		public
			constructor Create(AOwner:TComponent); override;
	   		destructor  Destroy; override;

		published
                        property    Version: TVersion read FVersion write FVersion stored False;
			property    Style:TRetFocusSeq read FStyle write FStyle;
			property    Circulate:Boolean read FCirculate write FCirculate;
			property    InitFocus:Boolean read FInitFocus write FInitFocus;
			property    TabEnable:Boolean read FTabEnable write FTabEnable;
			property    OnChangeFocus:TFocusEvent read FOnChangeFocus write FOnChangeFocus;
			property    CatchMouse:Boolean read FCatchMouse write FCatchMouse;
			property    AlwaysEvent:Boolean read FAlwaysEvent write FAlwaysEvent;
			//削除(1997.03.11)
			//property    AfterOnChangeFocus:TAfterFocusedEvent  read FAfterOnChangeFocus write FAfterOnChangeFocus;
			//Add(1997.1.17)
			property    ArrowRightClick :Boolean read FArrowRightClick write FArrowRightClick;
			property    ExtendEnter: Boolean read FExtendEnter write FExtendEnter;
		end;



	{ ﾌﾟﾛｼｰｼﾞｬ、関数宣言 }
	{$IFNDEF HREG}
	procedure Register;                                     { ｺﾝﾎﾟｰﾈﾝﾄの登録 }
	{$ENDIF}
//	{$IFDEF PHOENIX}
//	procedure   DoCheckDD(CrntCtrl:TWinControl);            { CHeckDDの実行 }
//	{$ENDIF}

{
******************************************************************************
	implementation部
******************************************************************************
}
implementation

//{$IFDEF PHOENIX}
//	{ ﾕﾆｯﾄ指定 }
//	uses
//{$IFDEF UPDATE}
//		XChkDD, DspLib, DllMan, DataCtrl, XTable, XGrids, XDbGrid
//
//                ,PGRIDLib_TLB   //Add 1998-01-21
//
//                ;
//{$ELSE}
//	      	XChkDD, DspLib, DllMan, DataCtrl, XTable;
//{$ENDIF}

//	{ 定数定義 }
//	const
//		kDefDataCheckStructName = 'WCHECKDD';
//	{$ENDIF}

	{
	-----------------------------------------------------------------------
		Foregound Window Check
	-----------------------------------------------------------------------
	}
        function IsForegound: Boolean;
        begin
//          Result := GetCurrentThreadID = GetWindowThreadProcessId(GetForeGroundWindow, Nil) HSS70
          Result := GetCurrentThreadID = WinTypes.GetWindowThreadProcessId(GetForeGroundWindow, Nil)
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
		TMessageReceiver    AfterFocusedｲﾍﾞﾝﾄ発生
	---------------------------------------------------------------------------
	}
	procedure TMessageReceiver.CMFocusChanged( var Message:TCMFocusChanged) ;
	begin
	   Caption := (Message.Sender).Name ;
	   if Assigned( FAfterFocused ) then begin
		  FAfterFocused( Message.Sender );
	  end;
	end;

	{
	---------------------------------------------------------------------------
		THArrowKeyControl    ｺﾝｽﾄﾗｸﾀ
	---------------------------------------------------------------------------
	}
	constructor THArrowKeyControl.Create(AOwner:TComponent);
	begin
		{ 派生元呼び出し }
		inherited Create(AOwner);
                FVersion     := HArrowKeyControlVersion;

		{ ﾒﾝﾊﾞ初期化 }
		FStyleV      := ByDist;
		FStyleH      := ByAxis;
		FCatchMouse  := True;
		FAlwaysEvent := False;
		FReceiver    := TMessageReceiver.Create(self);
		FReceiver.AfterFocused := DoAfterChangeFocus ;
		//Add(1997.1.17)
		FArrowRightClick := False ;

		oMainForm := TForm(AOwner);
		OnMessageCounter := 0;
(* Add Matsu 1997-04-02 *)
//		MainForm.InsertControl( FReceiver);//  下の条件文の中へ移動
(* Add End *)

		{ OnMessageｲﾍﾞﾝﾄﾌｯｸ }
		if not (csDesigning in ComponentState) then begin
(* Add Matsu 1997-04-02 *)
        		oMainForm.InsertControl( FReceiver);
(* Add End *)
                        Application.ProcessMessages;                            // ﾙｰﾌﾟ接続前のﾒｯｾｰｼﾞを全て完了させる
			OrgOnMessageHandler := Application.OnMessage;
			Application.OnMessage := OnMessageHandler;
		end;
	end;

	{
	---------------------------------------------------------------------------
		THArrowKeyControl    ﾃﾞｽﾄﾗｸﾀ
	---------------------------------------------------------------------------
	}
	destructor  THArrowKeyControl.Destroy;
	begin
		if not (csDesigning in ComponentState) then begin
			Application.OnMessage := OrgOnMessageHandler;
                end;
		{ 派生元呼び出し }
		inherited Destroy;
	end;

	{
	---------------------------------------------------------------------------
		THArrowKeyControl    Windowsﾒｯｾｰｼﾞのﾌｯｸ
	---------------------------------------------------------------------------
	}
	procedure THArrowKeyControl.OnMessageHandler(var Msg:TMsg; var Handled:Boolean);
	var
		WinCtrl:TWinControl;
		NextWinCtrl:TWinControl;
		ClickKey:Word;
	begin

    // アクティブが無い場合、抜ける                                             2003.04.14 鹿野
    if Screen.ActiveForm = nil then begin
  		// オリジナルハンドラ呼び出し
      if Assigned(OrgOnMessageHandler) then
			  OrgOnMessageHandler(Msg, Handled);
      exit;
    end;

		Inc(OnMessageCounter);
		if OnMessageCounter = 1 then begin
//			if (MainForm.Active) and (IsForegound) then begin                       2003.05.01 変更
//			if (oMainForm.Active) and ((IsForegound) or (oMainForm = Screen.ActiveForm)) then begin
			if (oMainForm.Active) and (oMainForm = Screen.ActiveForm) then begin
//				with Msg, MainForm do begin                                           2003.04.03 変更
				with Msg, Screen.ActiveForm do begin
(* 19990808 ADD kubochi begin *)

                                    { 移動先ｺﾝﾄﾛｰﾙ取得 }
				    WinCtrl := FindControl(hwnd);
//                                    if ActiveControl = WinCtrl then begin
//                                    if (ActiveControl = nil) or (handle = hwnd) or ((WinCtrl = nil) or (WinCtrl.Owner = MainForm) or (WinCtrl.Owner.Owner = MainForm)) then begin
          if (ActiveControl = nil) or (handle = hwnd) or ((WinCtrl = nil) or (WinCtrl.Owner = Screen.ActiveForm) or (WinCtrl.Owner.Owner = Screen.ActiveForm)) then begin
(* 19990808 ADD kubochi end; *)
					{ 矢印ｷｰの捕捉 }
					if (message = WM_KEYDOWN) and (ActiveControl <> nil)
					and ((Word(wParam) = VK_UP) or (Word(wParam) = VK_DOWN)
					or (Word(wParam) = VK_LEFT) or (Word(wParam) = VK_RIGHT)) then begin
						{ 脱出判定 }

{$IFDEF VER90}
						if CanExit(ActiveControl, Word(wParam)) then begin
{$ELSE}
						if CanExit(ActiveControl, PWord(@wParam)^) then begin
{$ENDIF}
//							if not XTableControl(ActiveControl, Msg) then begin
								{ 移動先TWinControlの取得 }
								NextWinCtrl := nil;
								case wParam of
								VK_UP:
									begin
										if ( ActiveControl.Parent is TTabSheet) then
										   GetUpperCtrl(NextWinCtrl, ActiveControl, ActiveControl.Parent.Parent, FStyleV);
//										if ActiveControl.Parent is TXChildPanel then
//										                                (* Add FIT 1997-05-02 ↑キー、↓キーでの動作に違いがあった為対応 *)
//                                                                                  begin
//                                                                                    if ActiveControl.Parent.Parent.Parent is TTabSheet then
//                                                                                      GetPrevCtrl(NextWinCtrl, ActiveControl, ActiveControl.Parent.Parent.Parent, TRetFocusSeq(1))
//                                                                                    else
//                                                                        (* Add End *)
//
//																					GetUpperCtrl(NextWinCtrl, ActiveControl, ActiveControl.Parent.Parent, FStyleV);
//											                                      end;
//{$IFDEF VDATE_PLUS}
//										if  (GetBaseControl(ActiveControl) is TVDateEdit) or
//											(GetBaseControl(ActiveControl) is TVTimeEdit) then
//											GetUpperCtrl(NextWinCtrl, GetBaseControl(ActiveControl), MainForm, FStyleV);
//{$ENDIF}
										if NextWinCtrl = nil then
//											GetUpperCtrl(NextWinCtrl, ActiveControl, MainForm, FStyleV); 2003.05.01 変更
											GetUpperCtrl(NextWinCtrl, ActiveControl, oMainForm, FStyleV);
									end;
								VK_DOWN:
									begin
										if (ActiveControl is TPageControl) then
//										  GetNextCtrl(NextWinCtrl, ActiveControl, MainForm, TRetFocusSeq(1)); 2003.05.01 変更
										  GetNextCtrl(NextWinCtrl, ActiveControl, oMainForm, TRetFocusSeq(1));

										if ( ActiveControl.Parent is TTabSheet) then
										   GetLowerCtrl(NextWinCtrl, ActiveControl, ActiveControl.Parent.Parent, FStyleV);
//										if ActiveControl.Parent is TXChildPanel then
//										                                (* Add FIT 1997-05-02 ↑キー、↓キーでの動作に違いがあった為対応 *)
//                                                                                  begin
//                                                                                    if ActiveControl.Parent.Parent.Parent is TTabSheet then
//                                                                                      GetNextCtrl(NextWinCtrl, ActiveControl, ActiveControl.Parent.Parent.Parent, TRetFocusSeq(1))
//                                                                                    else
//                                                                        (* Add End *)
//																					  GetLowerCtrl(NextWinCtrl, ActiveControl, ActiveControl.Parent.Parent, FStyleV);
//																				  end;

//{$IFDEF VDATE_PLUS}
//										if  (GetBaseControl(ActiveControl) is TVDateEdit) or
//											(GetBaseControl(ActiveControl) is TVTimeEdit) then
//											GetLowerCtrl(NextWinCtrl, GetBaseControl(ActiveControl), MainForm, FStyleV);
//{$ENDIF}
										if NextWinCtrl = nil then
//											GetLowerCtrl(NextWinCtrl, MainForm.ActiveControl, MainForm, FStyleV); 2003.05.01 変更
											GetLowerCtrl(NextWinCtrl, ActiveControl, oMainForm, FStyleV);
									end;
								VK_LEFT:
									begin
										if ( ActiveControl.Parent is TTabSheet) then
										   GetLeftCtrl(NextWinCtrl, ActiveControl, ActiveControl.Parent.Parent, FStyleV);
//										if ActiveControl.Parent is TXChildPanel then
//										(* Add FIT 1997-05-02 ↑キー、↓キーでの動作に違いがあった為対応 *)
//                                                                                  begin
//                                                                                    if ActiveControl.Parent.Parent.Parent is TTabSheet then
//                                                                                      GetPrevCtrl(NextWinCtrl, ActiveControl, ActiveControl.Parent.Parent.Parent, TRetFocusSeq(1))
//                                                                                    else
//                                                                        (* Add End *)
//																					  GetLeftCtrl(NextWinCtrl, ActiveControl, ActiveControl.Parent.Parent, FStyleH);
//																				  end;
//{$IFDEF VDATE_PLUS}
//										if  (GetBaseControl(ActiveControl) is TVDateEdit) or
//											(GetBaseControl(ActiveControl) is TVTimeEdit) then
//											GetLeftCtrl(NextWinCtrl, GetBaseControl(ActiveControl), MainForm, FStyleH);
//{$ENDIF}
										if NextWinCtrl = nil then
//											GetLeftCtrl(NextWinCtrl, MainForm.ActiveControl, MainForm, FStyleH); 2003.05.01 変更
											GetLeftCtrl(NextWinCtrl, ActiveControl, oMainForm, FStyleH);
									end;
								VK_RIGHT:
									begin
										if ( ActiveControl.Parent is TTabSheet) then
										   GetRightCtrl(NextWinCtrl, ActiveControl, ActiveControl.Parent.Parent, FStyleV);
//										if ActiveControl.Parent is TXChildPanel then
//										                              (* Add FIT 1997-05-02 ↑キー、↓キーでの動作に違いがあった為対応 *)
//                                                                                  begin
//                                                                                    if ActiveControl.Parent.Parent.Parent is TTabSheet then
//                                                                                      GetNextCtrl(NextWinCtrl, ActiveControl, ActiveControl.Parent.Parent.Parent, TRetFocusSeq(1))
//                                                                                    else
//                                                                        (* Add End *)
//																					  GetRightCtrl(NextWinCtrl, ActiveControl, ActiveControl.Parent.Parent, FStyleH);
//																				  end;
//{$IFDEF VDATE_PLUS}
//										if  (GetBaseControl(ActiveControl) is TVDateEdit) or
//											(GetBaseControl(ActiveControl) is TVTimeEdit) then
//											GetRightCtrl(NextWinCtrl, GetBaseControl(ActiveControl), MainForm, FStyleH);
//{$ENDIF}										if NextWinCtrl = nil then
//											GetRightCtrl(NextWinCtrl, MainForm.ActiveControl, MainForm, FStyleH); 2003.05.01 変更
											GetRightCtrl(NextWinCtrl, ActiveControl, oMainForm, FStyleH);
									end;
								end;
//{$IFDEF VDATE_PLUS}
//								if  (GetBaseControl(ActiveControl) is TVDateEdit) or
//									(GetBaseControl(ActiveControl) is TVTimeEdit) then
//									NextWinCtrl := GetBaseControl(NextWinCtrl) ;
//{$ENDIF}

								{ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙの変更 }
								if FAlwaysEvent or (NextWinCtrl <> nil) then begin
									DoChangeFocus(ActiveControl, NextWinCtrl, wParam);
									if NextWinCtrl <> nil then begin
										if IsWindowVisible(NextWinCtrl.Handle) then
											NextWinCtrl.SetFocus;
									end;

									{ ｵﾘｼﾞﾅﾙの動作を殺す }
									wParam := 0;
								end;
//							end;
						end;

						{ TButtonの矢印ｷｰによるｵﾘｼﾞﾅﾙの動作を無効化 }
(* Add 1997-03-25 matsu *)
//						if (ActiveControl is TButton) or (ActiveControl is TCheckBox) then 2003.05.01 変更
//            if (ActiveControl is TButtonControl) or (ActiveControl is TCheckBox) then   2003.07.22 変更
            // RadioButtonの際、矢印キーでの操作が不正になっていたのを修正                2003.07.22 変更
            // その他、フォーカス不正との協調を取る為、複雑なIF文となった                 2003.07.22 変更
						if (ActiveControl is TButton) or (ActiveControl is TCheckBox) or (not(ActiveControl is TradioButton) and (ActiveControl is TButtonControl)) then
//						if ActiveControl is TButton then
(* Add End *)
							wParam := 0;
					end

					else if (message = WM_KEYDOWN) and (ActiveControl <> nil) then begin

						{ ｷｰｺｰﾄﾞ変更 }
{$IFDEF VER90}
						SpecialKeyAssign(ActiveControl, Word(wParam));
{$ELSE}
						SpecialKeyAssign(ActiveControl, PWord(@wParam)^);
{$ENDIF}

//						{ XTableのﾍﾟｰｼﾞ切り替え }
//						XTableControl(ActiveControl, Msg)
					end

					{ ﾏｳｽの捕捉 }
					else if FCatchMouse
(* ADD kubochi 19990818 右ｸﾘｯｸもﾌｫｰｶｽが移動するように仕様変更の為変更 begin  *)
//					and ((message = WM_LBUTTONDOWN) or (message =  WM_LBUTTONDBLCLK)) then begin
//                                                          ↓
					and ((message = WM_RBUTTONDOWN) or (message =  WM_RBUTTONDBLCLK)
                                           or(message = WM_LBUTTONDOWN) or (message =  WM_LBUTTONDBLCLK)) then begin
(* ADD kubochi 19990818 右ｸﾘｯｸもﾌｫｰｶｽが移動するように仕様変更の為変更 end    *)
						{ ﾏｳｽの場合のｷｰｺｰﾄﾞは0 }

						ClickKey := 0;

						{ 移動先ｺﾝﾄﾛｰﾙ取得 }
						WinCtrl := FindControl(hwnd);
						if WinCtrl = nil then
							WinCtrl := FindControl(GetParent(hwnd));

						if WinCtrl <> nil then begin
							if IsMouseFocusControl(WinCtrl) and
							((GetBaseControl(WinCtrl) <> GetBaseControl(ActiveControl))
							or (GetBaseControl(WinCtrl) is THDateEdit)
//							or (GetBaseControl(WinCtrl) is TXTimeEdit)
							) then begin
								if IsReadOnly(WinCtrl) or (not WinCtrl.CanFocus) then
									message := WM_NULL

								else if not CanExit(ActiveControl, ClickKey) then
									message := WM_NULL

								else begin
									NextWinCtrl := WinCtrl;
									DoChangeFocus(ActiveControl, NextWinCtrl, ClickKey);
									if NextWinCtrl = nil then begin
										WinCtrl.SetFocus;
										message := WM_NULL;
									end
									else if not IsWindowVisible(NextWinCtrl.Handle) then
										message := WM_NULL
									else if NextWinCtrl <> WinCtrl then begin
										NextWinCtrl.SetFocus;
										message := WM_NULL;
									end;
								end;
							end;
						end;
					end


(* Add matsu 1997-08-23 Gridには右クリックでフォーカスが移ってしまうのを修正 *)
//					{ ﾏｳｽ右ﾎﾞﾀﾝUPによるReadOnlyｺﾝﾄﾛｰﾙへのﾌｫｰｶｽ移動を抑制 }
//					else if message = WM_RBUTTONUP then begin


(* DEL kubochi 19990818 右ｸﾘｯｸもﾌｫｰｶｽが移動するように仕様変更の為削除     *)
//					{ ﾏｳｽ右ﾎﾞﾀﾝDOWNによるReadOnlyｺﾝﾄﾛｰﾙへのﾌｫｰｶｽ移動を抑制 }
//					else if (message = WM_RBUTTONDOWN) or (message = WM_RBUTTONDBLCLK) then begin
//(* Add End *)
//						{ 移動先ｺﾝﾄﾛｰﾙ取得 }
//						WinCtrl := FindControl(hwnd);
//						if WinCtrl = nil then
//							WinCtrl := FindControl(GetParent(hwnd));
//
//						if WinCtrl <> nil then begin
//							if IsMouseFocusControl(WinCtrl) and (GetBaseControl(WinCtrl) <> GetBaseControl(ActiveControl)) then begin
//								//if IsReadOnly(WinCtrl) or (not WinCtrl.CanFocus) then
//								//Add(1997.1.17)
//								if not ArrowRightClick then
//									message := WM_NULL
//							end;
//						end;
//					end;
//
(* DEL kubochi 19990818 右ｸﾘｯｸもﾌｫｰｶｽが移動するように仕様変更の為削除 end *)

                                    end;
				end;
			end;
		end;
		Dec(OnMessageCounter);

		{ ｵﾘｼﾞﾅﾙﾊﾝﾄﾞﾗ呼び出し}
		if Assigned(OrgOnMessageHandler) then
			OrgOnMessageHandler(Msg, Handled);
	end;

	{
	---------------------------------------------------------------------------
		THArrowKeyControl    ｶﾚﾝﾄｳｨﾝﾄﾞｳから脱出可能かどうか検査する
	---------------------------------------------------------------------------
	}
	{$WARNINGS OFF}
	function  THArrowKeyControl.CanExit(Control:TControl; var Vkey:Word):Boolean;
	var
		CurPos:Integer;
	begin
		if Control = nil then
			Result := TRUE

		{ ｼﾌﾄが押されている場合は無効 }
		else if (GetKeyState(VK_SHIFT) < 0) or (GetKeyState(VK_MENU) < 0) or (GetKeyState(VK_CONTROL) < 0) then
			Result := FALSE

		{ THDateEditの判定 }
		else if Control.Parent is THDateEdit then
			Result := THDateEdit(Control.Parent).CanExit(VKey, [])

//		{ TXTimeEditの判定 }
//		else if Control.Parent is TXTimeEdit then
//			Result := TXTimeEdit(Control.Parent).CanExit(VKey, [])
//
//		{ TXValueEditの判定 }
//		else if Control.Parent is TXValueEdit then
//			Result := TXValueEdit(Control.Parent).CanExit(VKey, [])
//
//{$IFDEF ADDCOMRADE}
//		{ TVNumEditの判定 }
//		else if Control is TVNedit then
//			Result := TVNedit(Control).CanExit(VKey, [])
//
//		{ TVValueEditの判定 }
//		else if Control.Parent is TVValueEdit then
//			Result := TVValueEdit(Control.Parent).CanExit(VKey, [])
//
//		{ TVTimeEditの判定 }
//		else if Control.Parent is TVTimeEdit then
//			Result := TVTimeEdit(Control.Parent).CanExit(VKey, [])
//
//		{ TVDateEditの判定 }
//		else if Control.Parent is TVDateEdit then
//			Result := TVDateEdit(Control.Parent).CanExit(VKey, [])
//
//		{ TVEditの判定 }
//		else if Control is TVEdit then
//			Result := TVEdit(Control).CanExit(VKey, [])
//
//		{ TVFormatEditの判定 }
//		else if Control is TVFormatEdit then
//			Result := TVEdit(Control).CanExit(VKey, [])
//
//		{ TVCalcEditの判定 }
//		else if Control is TVCalcEdit then
//			Result := TVCalcEdit(Control).CanExit(VKey, [])
//
//{$ENDIF}
		{ THNeditの判定 }
		else if Control is THNedit then
			Result := THNedit(Control).CanExit(VKey, [])

		{ THEditの判定 }
		else if Control is THEdit then
			Result := THEdit(Control).CanExit(VKey, [])

		else if Control is TPageControl then
			Result := True

		{ TCustomEditの判定 }
		else if Control is TCustomEdit then begin
			CurPos := LOWORD(SendMessage(TCustomEdit(Control).Handle, EM_GETSEL, 0, 0));
			case VKey of
			VK_UP, VK_DOWN:
				Result := TRUE;
			VK_LEFT:
				if TCustomEdit(Control).SelLength > 0 then
					Result := FALSE
				else if CurPos = 0 then
					Result := TRUE
				else
					Result := FALSE;
			VK_RIGHT:
				if TCustomEdit(Control).SelLength > 0 then
					Result := FALSE
				else if CurPos = TCustomEdit(Control).GetTextLen then
					Result := TRUE
				else
					Result := FALSE;
			0:
				Result := TRUE;
			end;
		end

{$IFDEF UPDATE}
//		{ TXDrawGridの判定 }
//		else if Control is TXDrawGrid then
//			Result := VKey = 0
{$ELSE}
		{ TDrawGridの判定 }
		else if Control is TDrawGrid then
			Result := FALSE
{$ENDIF}

//		{ TXButtonの判定 }
//		else if Control is TXButton then
//			Result := TXButton(Control).CanExit(VKey, [])

		{ TButtonの判定 }
		else if Control is TButtonControl then
			Result := TRUE

		{ TComboBoxの判定 }
		else if Control is TComboBox then begin
			CurPos := LOWORD(SendMessage(TComboBox(Control).Handle, CB_GETEDITSEL, 0, 0));

			case VKey of
			VK_UP, VK_DOWN:
				Result := SendMessage(TComboBox(Control).Handle, CB_GETDROPPEDSTATE, 0, 0) = 0;
			VK_LEFT:
				if SendMessage(TComboBox(Control).Handle, CB_GETDROPPEDSTATE, 0, 0) <> 0 then
					Result := FALSE
				else if  (TComboBox(Control).Style <> csDropDown)
				and (TComboBox(Control).Style <> csSimple) then
					Result := TRUE
				else if TComboBox(Control).SelLength > 0 then
					Result := FALSE
				else if CurPos = 0 then
					Result := TRUE
				else
					Result := FALSE;
			VK_RIGHT:
				if SendMessage(TComboBox(Control).Handle, CB_GETDROPPEDSTATE, 0, 0) <> 0 then
					Result := FALSE
				else if  (TComboBox(Control).Style <> csDropDown)
				and (TComboBox(Control).Style <> csSimple) then
					Result := TRUE
				else if TComboBox(Control).SelLength > 0 then
					Result := FALSE
				else if CurPos = TComboBox(Control).GetTextLen then
					Result := TRUE
				else
					Result := FALSE;
			0:
				Result := TRUE;
			end;
		end


//		{ TCheckBoxの判定 }
//		else if Control is TCheckBox then
//			Result := TRUE

//		{ TXCalendarの判定 }
//		else if Control is TXCalendar then
//			Result := TXCalendar(Control).CanExit(VKey, [])

		{ TListBoxの判定 }
		else if Control is TCustomListBox then
			Result := not ((VKey = VK_UP) or (VKey = VK_DOWN))

		{ ﾏｳｽｸﾘｯｸ }
		else if VKey = 0 then
			Result := TRUE

		{ その他 }
		else
			Result := FALSE;
	end;
	{$WARNINGS ON}

	{
	---------------------------------------------------------------------------
		THArrowKeyControl    ｷｰｺｰﾄﾞ変更
	---------------------------------------------------------------------------
	}
	procedure   THArrowKeyControl.SpecialKeyAssign(Control:TControl; var VKey:Word);
	begin
		{ TRadioGroupの判定 }
		if (Control is TRadioButton) and (Control.Parent is TRadioGroup) and (VKey = VK_SPACE) then begin
			if GetKeyState(VK_SHIFT) < 0 then VKey := VK_UP
			else                              VKey := VK_DOWN;
		end;
	end;

	{
	---------------------------------------------------------------------------
		THArrowKeyControl    OnChangeFocusｲﾍﾞﾝﾄ発生
	---------------------------------------------------------------------------
	}
	procedure   THArrowKeyControl.DoChangeFocus(PrevCtrl:TWinControl; var NextCtrl:TWinControl; VkCode:Word);
	var
		Prev, Next:TWinControl;
		OrgNext:TWinControl;
		IllegalControl:TWinControl;
	begin
		if PrevCtrl = nil then Prev := nil
		else                   Prev := GetBaseControl(PrevCtrl);

		if NextCtrl = nil then Next := nil
		else                   Next := GetBaseControl(NextCtrl);

		if Prev <> Next then begin
//	{$IFDEF PHOENIX}
//			{ CheckDD呼び出し }
//			DoCheckDD(Prev);
//	{$ENDIF}

			{ ﾃﾞｰﾀﾁｪｯｸ }
			if Prev is THDateEdit then begin
				IllegalControl := THDateEdit(Prev).CheckInputData;
				if IllegalControl <> nil then begin
					NextCtrl := IllegalControl;
					Exit;
				end;
			end;

{$IFDEF UPDATE}
			{ OnChangeFocusｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ呼び出し }
			if not (Next is TPanel) and not(Next is TGroupBox) then begin
				if (not FAlwaysEvent) and (Next = nil) then
				   NextCtrl := nil
				else if Assigned(FOnChangeFocus) then begin
          // 次コントロールがNilなら処理無し                                    2003.05.01 変更
//          if Next <> nil then begin                                           2003.07.22 変更
          if (FAlwaysEvent = True) or (Next <> nil) then begin
  					OrgNext := Next;
	  				FOnChangeFocus(Prev, Next, VkCode);
		  			if Next <> OrgNext then
			  			NextCtrl := Next;
  				end;
				end;
			end;
{$ELSE}
			{ OnChangeFocusｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ呼び出し }
			if (not FAlwaysEvent) and (Next = nil) then
			   NextCtrl := nil
			else if Assigned(FOnChangeFocus) then begin
        // 次コントロールがNilなら処理無し                                    2003.05.01 変更
//          if Next <> nil then begin                                           2003.07.22 変更
        if (FAlwaysEvent = True) or (Next <> nil) then begin
  				OrgNext := Next;
	  			FOnChangeFocus(Prev, Next, VkCode);
		  		if Next <> OrgNext then
			  		NextCtrl := Next;
//  			end;
  	  end;
{$ENDIF}
		end;
	end;

//	{
//	---------------------------------------------------------------------------
//		XTable制御
//	---------------------------------------------------------------------------
//	}
//	function    TArrowKeyControl.XTableControl(ActiveControl:TWinControl; KeyMsg:TMsg):Boolean;
//	var
//		XTable: TXTable;
//		DataCtrl:TDataControl;
//		TopLine, MaxTopLine: Integer;
//		Next:TWinControl;
//	begin
//		Result := FALSE;
//
//		{ XTableﾒﾝﾊﾞのﾁｪｯｸ } //Add(1996.12.14)
//		if (ActiveControl.Parent is TXDateEdit)or( ActiveControl.Parent is TXTimeEdit) then begin
//		  if not IsXTableControl(ActiveControl.Parent) then
//			exit
//		  else
//		   { XTable取得 }
//			XTable := TXTable(ActiveControl.Parent.Parent.Owner);
//		end else begin
//		  if not IsXTableControl(ActiveControl) then
//			exit
//		  else
//		   { XTable取得 }
//			XTable := TXTable(ActiveControl.Parent.Owner);
//		end;
//
//		{ DataControl取得 }
//		DataCtrl := TDataControl(MainForm.FindComponent(XTable.DataControl));
//		if DataCtrl = nil then
//			Exit;
//
//		TopLine := DataCtrl.GetTopLine(XTable, MaxTopLine);
//
//		case KeyMsg.wParam of
//		VK_UP:
//			if (XTable.CurRow = 0) and (TopLine > 0) then begin
//				Next := nil;
//				GetUpperCtrl(Next, ActiveControl, ActiveControl.Parent.Parent, ByAxis);
//				if Next = nil then begin
//					if LOWORD(KeyMsg.lParam) > 1 then
//						SendMessage(XTable.Handle, WM_VSCROLL, MAKEWPARAM(SB_LINEUP, 1), 0)
//					else
//						SendMessage(XTable.Handle, WM_VSCROLL, SB_LINEUP, 0);
//					Result := TRUE;
//				end;
//			end;
//		VK_DOWN:
//			begin
//			  //未使用領域に達したら、ﾌｫｰｶｽを外に出す。
//			  if( (XTable.EnableMaxScrollRow)and(TopLine + XTable.CurRow = XTable.MaxScrollRow) ) then begin
//				Result := False;
//				exit;
//			  end;
//			  if (XTable.CurRow + 1 = XTable.VisibleRowCount) and (TopLine < MaxTopLine) then begin
//				  Next := nil;
//				  GetLowerCtrl(Next, ActiveControl, ActiveControl.Parent.Parent, ByAxis);
//				  if Next = nil then begin
//					  if LOWORD(KeyMsg.lParam) > 1 then
//						  SendMessage(XTable.Handle, WM_VSCROLL, MAKEWPARAM(SB_LINEDOWN, 1), 0)
//					  else
//						  SendMessage(XTable.Handle, WM_VSCROLL, SB_LINEDOWN, 0);
//					  Result := TRUE;
//				  end;
//			  end;
//			end;
//		VK_PRIOR:
//			if TopLine > 0 then begin
//				SendMessage(XTable.Handle, WM_VSCROLL, SB_PAGEUP, 0);
//				Result := TRUE;
//			end;
//		VK_NEXT:
//			if TopLine < MaxTopLine then begin
//				SendMessage(XTable.Handle, WM_VSCROLL, SB_PAGEDOWN, 0);
//				Result := TRUE;
//			end;
//		end;
//	end;
//
	{
	---------------------------------------------------------------------------
		THArrowKeyControl    AfterOnChangeFocusEvent
	 ---------------------------------------------------------------------------
	}
	Procedure   THArrowKeyControl.DoAfterChangeFocus( NowCtrl:TWinControl );
	begin
	  if Assigned( FAfterOnChangeFocus ) then begin
		  FAfterOnChangeFocus( NowCtrl );
	  end;
	end;

	{
	---------------------------------------------------------------------------
		THRetKeyControl    ｺﾝｽﾄﾗｸﾀ
	---------------------------------------------------------------------------
	}
	constructor THRetKeyControl.Create(AOwner:TComponent);
	begin
		{ 派生元呼び出し }
		inherited Create(AOwner);
                FVersion     := HRetKeyControlVersion;
		{ ﾒﾝﾊﾞ初期化 }
		FStyle       := ByPosY;
		FCirculate   := TRUE;
		FInitFocus   := TRUE;
(* Add Kubochi 1999-07-23 ﾃﾞﾌｫﾙﾄTab移動を可能に変更 *)
// 		TabEnable    := FALSE;
 		TabEnable    := TRUE;
(* Add End *)
		FCatchMouse  := False;
		FAlwaysEvent := False;

		FReceiver    := TMessageReceiver.Create(self);
		FReceiver.AfterFocused := DoAfterChangeFocus ;
		//Add(1997.1.17)
		FArrowRightClick := False ;

		oMainForm   := TForm(AOwner);
		OnMessageCounter := 0;
(* Add Matsu 1997-04-02 *)
//		MainForm.InsertControl( FReceiver);//  下の条件文の中へ移動
(* Add End *)

		if not (csDesigning in ComponentState) then begin
(* Add Matsu 1997-04-02 *)
		oMainForm.InsertControl( FReceiver);
(* Add End *)
                        Application.ProcessMessages;                            // ﾙｰﾌﾟ接続前のﾒｯｾｰｼﾞを全て完了させる
			{ OnMessageｲﾍﾞﾝﾄﾌｯｸ }
			OrgOnMessageHandler := Application.OnMessage;
			Application.OnMessage := OnMessageHandler;

			{ OnShowｲﾍﾞﾝﾄﾌｯｸ }
			if AOwner is TForm then begin
				OrgOnShowHandler := TForm(AOwner).OnShow;
				TForm(AOwner).OnShow := OnShowHandler;
			end;
		end;
	end;

	{
	---------------------------------------------------------------------------
		THRetKeyControl    ﾃﾞｽﾄﾗｸﾀ
	---------------------------------------------------------------------------
	}
	destructor  THRetKeyControl.Destroy;
	begin
		if not (csDesigning in ComponentState) then begin
			Application.OnMessage := OrgOnMessageHandler;
                end;        
		{ 派生元呼び出し }
		inherited Destroy;
	end;

	{
	---------------------------------------------------------------------------
		THRetKeyControl    Windowsﾒｯｾｰｼﾞのﾌｯｸ
	---------------------------------------------------------------------------
	}
	procedure THRetKeyControl.OnMessageHandler(var Msg:TMsg; var Handled:Boolean);
	var
		WinCtrl:TWinControl;
		NextWinCtrl:TWinControl;
		ClickKey:Word;
	begin
		Inc(OnMessageCounter);
		if OnMessageCounter = 1 then begin
//			if (MainForm.Active) and (IsForegound) then begin                       2003.05.01 変更
//			if (oMainForm.Active) and ((IsForegound) or (oMainForm = Screen.activeForm)) then begin
			if (oMainForm.Active) and (oMainForm = Screen.activeForm) then begin
//				with Msg, MainForm do begin                                           2003.05.01 変更
				with Msg, Screen.ActiveForm do begin
(* 19990808 ADD kubochi begin *)
                                    { 移動先ｺﾝﾄﾛｰﾙ取得 }
				    WinCtrl := FindControl(hwnd);
//                                    if ActiveControl = WinCtrl then begin
//                                    if (ActiveControl = nil) or (handle = hwnd) or ((WinCtrl = nil) or (WinCtrl.Owner = MainForm) or (WinCtrl.Owner.Owner = MainForm)) then begin
                                    if (ActiveControl = nil) or (handle = hwnd) or ((WinCtrl = nil) or (WinCtrl.Owner = Screen.ActiveForm) or (WinCtrl.Owner.Owner = Screen.ActiveForm)) then begin
(* 19990808 ADD kubochi end; *)
					{ RET, TABｷｰの捕捉 }
					if (message = WM_KEYDOWN) and (ActiveControl <> nil)
					and ((wParam = VK_RETURN) or (wParam = VK_TAB)) then begin
						{ 脱出判定 }
{$IFDEF VER90}
						if CanExit(ActiveControl, Word(wParam)) then begin
{$ELSE}
						if CanExit(ActiveControl, PWord(@wParam)^) then begin
{$ENDIF}
//							  if not XTableControl(ActiveControl, Word(wParam)) then begin
								{ 移動先TWinControlの取得 }
								NextWinCtrl := nil;
								if GetKeyState(VK_SHIFT) < 0 then begin
//									if ActiveControl.Parent is TXChildPanel then
//										GetPrevCtrl(NextWinCtrl, ActiveControl, ActiveControl.Parent.Parent, FStyle);
									if NextWinCtrl = nil then
//										GetPrevCtrl(NextWinCtrl, ActiveControl, MainForm, FStyle); 2003.05.01 変更
										GetPrevCtrl(NextWinCtrl, ActiveControl, oMainForm, FStyle);
									if (NextWinCtrl = nil) and FCirculate then
//										GetBtmCtrl(NextWinCtrl, MainForm, FStyle);                2003.05.01 変更
										GetBtmCtrl(NextWinCtrl, oMainForm, FStyle);
								end
								else begin
//									if ActiveControl.Parent is TXChildPanel then
//										GetNextCtrl(NextWinCtrl, ActiveControl, ActiveControl.Parent.Parent, FStyle);
									if NextWinCtrl = nil then
//										GetNextCtrl(NextWinCtrl, ActiveControl, MainForm, FStyle); 2003.05.01 変更
										GetNextCtrl(NextWinCtrl, ActiveControl, oMainForm, FStyle);
									if (NextWinCtrl = nil) and FCirculate then
//										GetTopCtrl(NextWinCtrl, MainForm, FStyle);                2003.05.01 変更
										GetTopCtrl(NextWinCtrl, oMainForm, FStyle);
								end;

								{ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙの変更 }
								if FAlwaysEvent or (NextWinCtrl <> nil) then begin
(* Add matsu 1997-10-02 for Extended Enter Key *)
//									DoChangeFocus(ActiveControl, NextWinCtrl, wParam);
									DoChangeFocus(ActiveControl, NextWinCtrl, wParam, lParam);
(* Add End *)
									if NextWinCtrl <> nil then begin
										if IsWindowVisible(NextWinCtrl.Handle) then
											NextWinCtrl.SetFocus;
									end;

									{ ｵﾘｼﾞﾅﾙの動作を殺す }
									wParam := 0;
								end;
//							end;
						end;
					end

					{ ﾏｳｽの捕捉 }
					else if FCatchMouse
(* ADD kubochi 19990818 右ｸﾘｯｸもﾌｫｰｶｽが移動するように仕様変更の為変更 begin  *)
//	     				and ((message = WM_LBUTTONDOWN) or (message =  WM_LBUTTONDBLCLK)) then begin
//                                                          ↓
					and ((message = WM_RBUTTONDOWN) or (message =  WM_RBUTTONDBLCLK)
                                           or(message = WM_LBUTTONDOWN) or (message =  WM_LBUTTONDBLCLK)) then begin
(* ADD kubochi 19990818 右ｸﾘｯｸもﾌｫｰｶｽが移動するように仕様変更の為変更 end    *)

						{ ﾏｳｽの場合のｷｰｺｰﾄﾞは0 }
						ClickKey := 0;

						{ 移動先ｺﾝﾄﾛｰﾙ取得 }
						WinCtrl := FindControl(hwnd);
						if WinCtrl = nil then
							WinCtrl := FindControl(GetParent(hwnd));

						if WinCtrl <> nil then begin
							if IsMouseFocusControl(WinCtrl) and
							((GetBaseControl(WinCtrl) <> GetBaseControl(ActiveControl))
							or (GetBaseControl(WinCtrl) is THDateEdit)
//							or (GetBaseControl(WinCtrl) is TXTimeEdit)
                                                        ) then begin
								if IsReadOnly(WinCtrl) or (not WinCtrl.CanFocus) then
									message := WM_NULL

								else if not CanExit(ActiveControl, ClickKey) then
									message := WM_NULL

								else begin
									NextWinCtrl := WinCtrl;
(* Add matsu 1997-10-02 for Extended Enter Key *)
//									DoChangeFocus(ActiveControl, NextWinCtrl, ClickKey);
									DoChangeFocus(ActiveControl, NextWinCtrl, ClickKey, 0);
(* Add End *)
									if NextWinCtrl = nil then begin
										WinCtrl.SetFocus;
										message := WM_NULL;
									end
									else if not IsWindowVisible(NextWinCtrl.Handle)
										then message := WM_NULL
									else if NextWinCtrl <> WinCtrl then begin
										NextWinCtrl.SetFocus;
										message := WM_NULL;
									end;
								end;
							end;
						end;
					end

(* Add matsu 1997-08-23 Gridには右クリックで移動してしまうのを修正 *)
//					{ ﾏｳｽ右ﾎﾞﾀﾝUPによるReadOnlyｺﾝﾄﾛｰﾙへのﾌｫｰｶｽ移動を抑制 }
//					else if message = WM_RBUTTONUP then begin
					{ ﾏｳｽ右ﾎﾞﾀﾝDOWNによるReadOnlyｺﾝﾄﾛｰﾙへのﾌｫｰｶｽ移動を抑制 }

(* DEL kubochi 19990818 右ｸﾘｯｸもﾌｫｰｶｽが移動するように仕様変更の為削除 begin  *)
//
//					else if (message = WM_RBUTTONDOWN) or (message = WM_RBUTTONDBLCLK) then begin
//(* Add End *)
//						{ 移動先ｺﾝﾄﾛｰﾙ取得 }
//						WinCtrl := FindControl(hwnd);
//						if WinCtrl = nil then
//							WinCtrl := FindControl(GetParent(hwnd));
//
//						if WinCtrl <> nil then begin
//							if IsMouseFocusControl(WinCtrl) and (GetBaseControl(WinCtrl) <> GetBaseControl(ActiveControl)) then begin
//								//if IsReadOnly(WinCtrl) or (not WinCtrl.CanFocus) then
//								//Add(1997.1.17)
//								if not ArrowRightClick then
//									message := WM_NULL
//							end;
//						end;
//					end;
(* DEL kubochi 19990818 右ｸﾘｯｸもﾌｫｰｶｽが移動するように仕様変更の為削除 end    *)


                                    end;
				end;
			end;
		end;
		Dec(OnMessageCounter);

		{ ｵﾘｼﾞﾅﾙﾊﾝﾄﾞﾗ呼び出し}
		if Assigned(OrgOnMessageHandler) then
			OrgOnMessageHandler(Msg, Handled);
	end;

	{
	---------------------------------------------------------------------------
		THRetKeyControl    OnShowﾒｯｾｰｼﾞのﾌｯｸ
	---------------------------------------------------------------------------
	}
	procedure THRetKeyControl.OnShowHandler(Sender:TObject);
	var
		InitWinControl:TWinControl;
	begin
		{ 初期ﾌｫｰｶｽ設定 }
		if InitFocus then begin
			InitWinControl := nil;
//			GetTopCtrl(InitWinControl, MainForm, FStyle);                           2003.05.01 変更
			GetTopCtrl(InitWinControl, oMainForm, FStyle);

			if(InitWinControl <> nil) then begin

(* ADD FIT T.S 1997-03-05 *)
                                InitWinControl := GetBaseControl(InitWinControl);
(* ADD END *)

				DoChangeFocus(nil, InitWinControl, 0, 0);
				InitWinControl.SetFocus;
			end;
		end;

		{ ｵﾘｼﾞﾅﾙﾊﾝﾄﾞﾗ呼び出し}
		if Assigned(OrgOnShowHandler) then
			OrgOnShowHandler(Sender);
	end;

	{
	---------------------------------------------------------------------------
		THRetKeyControl    ｶﾚﾝﾄｳｨﾝﾄﾞｳから脱出可能かどうか検査する
	---------------------------------------------------------------------------
	}
	function  THRetKeyControl.CanExit(Control:TControl; var Vkey:Word):Boolean;
	var
		CurRow, CurCol:LongInt;
		MinRow, MinCol:LongInt;
		MaxRow, MaxCol:LongInt;
	begin
		if Control = nil then
			Result := TRUE

{(* 19990729 ADD kubochi THDoubleCaptionButton対応 begin *)}
		{ THDoubleCaptionButtonの判定 }
		else if (Control is THDoubleCaptionButton)
                     and(THDoubleCaptionButton(Control).EnableRetKey)
                     and(VKey = VK_RETURN) then Result := False
                     
{(* 19990729 ADD kubochi THDoubleCaptionButton対応 end   *)}
                        
		{ THDateEditの判定 }
		else if Control.Parent is THDateEdit then begin
			if VKey <> VK_TAB then
				Result := THDateEdit(Control.Parent).CanExit(VKey, GetShiftState)
			else if FTabEnable then begin
				Result := THDateEdit(Control.Parent).CanExit(VKey, GetShiftState);
				if Result = FALSE then VKey := 0;
			end
			else begin
				VKey   := 0;
				Result := FALSE;
			end;
		end

//		{ TXTimeEditの判定 }
//		else if Control.Parent is TXTimeEdit then begin
//			if VKey <> VK_TAB then
//				Result := TXTimeEdit(Control.Parent).CanExit(VKey, GetShiftState)
//			else if FTabEnable then begin
//				Result := TXTimeEdit(Control.Parent).CanExit(VKey, GetShiftState);
//				if Result = FALSE then VKey := 0;
//			end
//			else begin
//				VKey   := 0;
//				Result := FALSE;
//			end;
//		end
//
//		{ TXValueEditの判定 }
//		else if Control.Parent is TXValueEdit then begin
//			if VKey <> VK_TAB then
//				Result := TXValueEdit(Control.Parent).CanExit(VKey, GetShiftState)
//			else if FTabEnable then begin
//				Result := TXValueEdit(Control.Parent).CanExit(VKey, GetShiftState);
//				if Result = FALSE then VKey := 0;
//			end
//			else begin
//				VKey   := 0;
//				Result := FALSE;
//			end;
//		end
//
//		{ TXFunckeyButtonの判定 }
//		else if Control.Parent is TXFunckeyButton then begin
//			if VKey <> VK_TAB then
//				Result := FALSE
//			else if FTabEnable then
//				Result := TRUE
//			else begin
//				VKey   := 0;
//				Result := FALSE;
//			end;
//		end
//
//		{ TXButtonの判定 }
//		else if Control is TXButton then begin
//			if VKey <> VK_TAB then
//				Result := TXButton(Control).CanExit(VKey, GetShiftState)
//			else if FTabEnable then begin
//				Result := TXButton(Control).CanExit(VKey, GetShiftState);
//				if Result = FALSE then VKey := 0;
//			end
//			else begin
//				VKey   := 0;
//				Result := FALSE;
//			end;
//		end
//
		{THNeditの判定 }
		else if Control is THNedit then begin
			if VKey <> VK_TAB then
				Result := THNedit(Control).CanExit(VKey, GetShiftState)
			else if FTabEnable then begin
				Result := THNedit(Control).CanExit(VKey, GetShiftState);
				if Result = FALSE then VKey := 0;
			end
			else begin
				VKey   := 0;
				Result := FALSE;
			end;
		end

		{THEditの判定 }
		else if Control is THEdit then begin
			if VKey <> VK_TAB then
				Result := THEdit(Control).CanExit(VKey, GetShiftState)
			else if FTabEnable then begin
				Result := THEdit(Control).CanExit(VKey, GetShiftState);
				if Result = FALSE then VKey := 0;
			end
			else begin
				VKey   := 0;
				Result := FALSE;
			end;
		end

		{ TCustomEditの判定 }
		else if Control is TCustomEdit then begin
			if (VKey = VK_RETURN) or ((VKey = VK_TAB) and FTabEnable) or (VKey = 0) then
				Result := TRUE
			else begin
				if VKey = VK_TAB then VKey := 0;
				Result := FALSE;
			end;
		end

//{$IFDEF UPDATE}
//		{ TXDrawGridの判定 }
//		else if Control is TXDrawGrid then begin
//			if VKey = 0 then
//				Result := TRUE
//			else if (goAlwaysShowEditor in TXDrawGrid(Control).Options)
//			or (not TXDrawGrid(Control).EditorMode) then
//				Result := FALSE
//			else if (VKey = VK_RETURN) or ((VKey = VK_TAB) and FTabEnable) then begin
//				CurRow := TXDrawGrid(Control).Row;
//				CurCol := TXDrawGrid(Control).Col;
//				MinRow := TXDrawGrid(Control).FixedRows;
//				MinCol := TXDrawGrid(Control).FixedCols;
//				MaxRow := TXDrawGrid(Control).RowCount - 1;
//				MaxCol := TXDrawGrid(Control).ColCount - 1;
//
//				if (GetKeyState(VK_SHIFT) < 0)
//				and (CurRow = MinRow) and (CurCol = MinCol) then
//					Result := TRUE
//				else if (GetKeyState(VK_SHIFT) >= 0)
//				and (CurRow = MaxRow) and (CurCol = MaxCol) then
//					Result := TRUE
//				else if not (goTabs in TXDrawGrid(Control).Options) then
//					Result := TRUE
//				else begin
//					VKey   := VK_TAB;
//					Result := FALSE;
//				end;
//			end
//			else if VKey = 0 then
//				Result := TRUE
//			else begin
//				if VKey = VK_TAB then VKey := 0;
//				Result := FALSE;
//			end;
//		end
//
//		{ TXDbGridの判定 }
//		else if Control is TXDbGrid then begin
//			if VKey = 0 then
//				Result := TRUE
//			else if (dgAlwaysShowEditor in TXDbGrid(Control).Options)
//			or (not TXDbGrid(Control).EditorMode) then
//				Result := FALSE
//			else if (VKey = VK_RETURN) or ((VKey = VK_TAB) and FTabEnable) then begin
//				CurRow := TXDbGrid(Control).Row;
//				CurCol := TXDbGrid(Control).Col;
//				MinRow := TXDbGrid(Control).FixedRows;
//				MinCol := TXDbGrid(Control).FixedCols;
//				MaxRow := TXDbGrid(Control).RowCount - 1;
//				MaxCol := TXDbGrid(Control).ColCount - 1;
//
//				if (GetKeyState(VK_SHIFT) < 0)
//				and (CurRow = MinRow) and (CurCol = MinCol) then
//					Result := TRUE
//				else if (GetKeyState(VK_SHIFT) >= 0)
//				and (CurRow = MaxRow) and (CurCol = MaxCol) then
//					Result := TRUE
//				else if not (dgTabs in TXDbGrid(Control).Options) then
//					Result := TRUE
//				else begin
//					VKey   := VK_TAB;
//					Result := FALSE;
//				end;
//			end
//			else if VKey = 0 then
//				Result := TRUE
//			else begin
//				if VKey = VK_TAB then VKey := 0;
//				Result := FALSE;
//			end;
//		end
//
//(* Add matsu 1998-01-21 PerfectGridの対応 *)
//		{ TPerfectGridの判定 }
//		else if Control is TPerfectGrid then begin
//			if VKey = 0 then
//				Result := TRUE
//			else begin
//				if VKey = VK_TAB then VKey := 0;
//				Result := FALSE;
//			end;
//		end
//(* Add End *)
//{$ELSE}
		{ TDrawGridの判定 }
		else if Control is TDrawGrid then begin
(* DEL 19990804 kubochi begin *)
//			if (goAlwaysShowEditor in TDrawGrid(Control).Options)
(* DEL 19990804 kubochi end *)
(* Add 19990804 kubochi begin *)
			if VKey = 0 then
				Result := TRUE
			else if (goAlwaysShowEditor in TDrawGrid(Control).Options)
(* Add 19990804 kubochi end *)
			or (not TDrawGrid(Control).EditorMode) then
				Result := FALSE
			else if (VKey = VK_RETURN) or ((VKey = VK_TAB) and FTabEnable) then begin
				CurRow := TDrawGrid(Control).Row;
				CurCol := TDrawGrid(Control).Col;
				MinRow := TDrawGrid(Control).FixedRows;
				MinCol := TDrawGrid(Control).FixedCols;
				MaxRow := TDrawGrid(Control).RowCount - 1;
				MaxCol := TDrawGrid(Control).ColCount - 1;

				if (GetKeyState(VK_SHIFT) < 0)
				and (CurRow = MinRow) and (CurCol = MinCol) then
					Result := TRUE
				else if (GetKeyState(VK_SHIFT) >= 0)
				and (CurRow = MaxRow) and (CurCol = MaxCol) then
					Result := TRUE
				else if not (goTabs in TDrawGrid(Control).Options) then
					Result := TRUE
				else begin
					VKey   := VK_TAB;
					Result := FALSE;
				end;
			end
			else if VKey = 0 then
				Result := TRUE
			else begin
				if VKey = VK_TAB then VKey := 0;
				Result := FALSE;
			end;
		end
//{$ENDIF}

		{ ﾏｳｽｸﾘｯｸ }
		else if VKey = 0 then
			Result := TRUE

		{ その他 }
		else begin
			if (VKey = VK_RETURN) or ((VKey = VK_TAB) and FTabEnable) or (VKey = 0) then
				Result := TRUE
			else begin
				if VKey = VK_TAB then VKey := 0;
				Result := FALSE;
			end;
		end;
	end;

	{
	---------------------------------------------------------------------------
		THRetKeyControl  OnChangeFocusｲﾍﾞﾝﾄ発生
	---------------------------------------------------------------------------
	}
	procedure   THRetKeyControl.DoChangeFocus(PrevCtrl: TWinControl;
          var NextCtrl: TWinControl; VkCode: Word; Flags: LPARAM);
	var
		Prev, Next:TWinControl;
		OrgNext:TWinControl;
		IllegalControl:TWinControl;
	begin
(* Add matsu 1997-10-02 for Extended Enter Key *)
                if FExtendEnter and
                   ((VkCode = VK_RETURN) and ((HIWORD(Flags) and KF_EXTENDED) <> 0)) then
                  VkCode := VK_RETURN or KF_EXTENDED;
(* Add End *)
		if PrevCtrl = nil then Prev := nil
		else                   Prev := GetBaseControl(PrevCtrl);

		if NextCtrl = nil then Next := nil
		else                   Next := GetBaseControl(NextCtrl);

		if Prev <> Next then begin
//	{$IFDEF PHOENIX}
//			{ CheckDD呼び出し }
//			DoCheckDD(Prev);
//	{$ENDIF}

			{ ﾃﾞｰﾀﾁｪｯｸ }
			if Prev is THDateEdit then begin
				IllegalControl := THDateEdit(Prev).CheckInputData;
				if IllegalControl <> nil then begin
					NextCtrl := IllegalControl;
					Exit;
				end;
			end;

			{ OnChangeFocusｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ呼び出し }
{$IFDEF UPDATE}
			if not (Next is TPanel) and not (Next is TGroupBox) then begin
				if (not FAlwaysEvent) and (Next = nil) then
				   NextCtrl := nil
				else if Assigned(FOnChangeFocus) then begin
          // 次コントロールがNilなら処理無し                                    2003.05.01 変更
          if Next <> nil then begin
  					OrgNext := Next;
  					FOnChangeFocus(Prev, Next, VkCode);
  					if Next <> OrgNext then
  						NextCtrl := Next;
  				end;
				end;
			end;
{$ELSE}
			if (not FAlwaysEvent) and (Next = nil) then
			   NextCtrl := nil
			else if Assigned(FOnChangeFocus) then begin
        // 次コントロールがNilなら処理無し                                    2003.05.01 変更
        if Next <> nil then begin
  				OrgNext := Next;
	  			FOnChangeFocus(Prev, Next, VkCode);
		  		if Next <> OrgNext then
			  		NextCtrl := Next;
  			end;
      end;
{$ENDIF}
		end;
	end;

//	{
//	---------------------------------------------------------------------------
//		XTable制御
//	---------------------------------------------------------------------------
//	}
//	function    TRetKeyControl.XTableControl(ActiveControl:TWinControl; Key:Word):Boolean;
//	var
//		XTable: TXTable;
//		DataCtrl:TDataControl;
//		TopLine, MaxTopLine: Integer;
//		Next:TWinControl;
//	begin
//		Result := FALSE;
//
//		{ XTableﾒﾝﾊﾞのﾁｪｯｸ }  //Add(1996.12.14)
//		if (ActiveControl.Parent is TXDateEdit)or( ActiveControl.Parent is TXTimeEdit) then begin
//		  if not IsXTableControl(ActiveControl.Parent) then
//			exit
//		  else
//		   { XTable取得 }
//			XTable := TXTable(ActiveControl.Parent.Parent.Owner);
//		end else begin
//		  if not IsXTableControl(ActiveControl) then
//			exit
//		  else
//		   { XTable取得 }
//			XTable := TXTable(ActiveControl.Parent.Owner);
//		end;
//
//		{ DataControl取得 }
//		DataCtrl := TDataControl(MainForm.FindComponent(XTable.DataControl));
//		if DataCtrl = nil then
//			Exit;
//
//		case Key of
//		VK_RETURN, VK_TAB:
//			begin
//				if (Key = VK_TAB) and not FTabEnable then
//					Exit;
//
//				TopLine := DataCtrl.GetTopLine(XTable, MaxTopLine);
//
//				if GetKeyState(VK_SHIFT) < 0 then begin
//					if (XTable.CurRow = 0) and (TopLine > 0) then begin
//						Next := nil;
//						//Add(1996.12.14)
//						if (ActiveControl.Parent is TXDateEDit)or(ActiveControl.Parent is TXTimeEdit) then
//						  GetPrevCtrl(Next, ActiveControl.Parent, ActiveControl.Parent.Parent, ByPosY)
//						else
//						  GetPrevCtrl(Next, ActiveControl, ActiveControl.Parent.Parent, ByPosY);
//						if Next = nil then begin
//						  GetBtmCtrl(Next, ActiveControl.Parent, ByPosY);
//						  if Next <> nil then begin
//							XTable.NextControl := Next;
//							if SendMessage(XTable.Handle, WM_VSCROLL, SB_LINEUP, -1) = 0 then
//							  Next.SetFocus;
//						  end;
//						  Result := TRUE;
//						end;
//					end;
//				end
//
//				else begin
//					if (XTable.CurRow + 1 = XTable.VisibleRowCount) and (TopLine < MaxTopLine) then begin
//						Next := nil;
//						//Add(1996.12.14)
//						if (ActiveControl.Parent is TXDateEDit)or(ActiveControl.Parent is TXTimeEdit) then
//						  GetNextCtrl(Next, ActiveControl.Parent, ActiveControl.Parent.Parent, ByPosY)
//						else
//						  GetNextCtrl(Next, ActiveControl, ActiveControl.Parent.Parent, ByPosY);
//						if Next = nil then begin
//							GetTopCtrl(Next, ActiveControl.Parent, ByPosY);
//							if Next <> nil then begin
//								XTable.NextControl := Next;
//								if SendMessage(XTable.Handle, WM_VSCROLL, SB_LINEDOWN, -1) = 0 then
//									Next.SetFocus;
//							end;
//							Result := TRUE;
//						end;
//					end;
//				end;
//			end;
//		end;
//	end;

	{
	---------------------------------------------------------------------------
		THRetKeyControl    AfterOnChangeFocusEvent
	 ---------------------------------------------------------------------------
	}
	Procedure   THRetKeyControl.DoAfterChangeFocus( NowCtrl:TWinControl );
	begin
	  if Assigned( FAfterOnChangeFocus ) then begin
		  FAfterOnChangeFocus( NowCtrl );
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
		RegisterComponents('HSS', [THArrowKeyControl]);
		RegisterComponents('HSS', [THRetKeyControl]);
	end;
	{$ENDIF}

//	{$IFDEF PHOENIX}
//	{
//	***************************************************************************
//		CheckDD実行
//	***************************************************************************
//	}
//	procedure   DoCheckDD(CrntCtrl:TWinControl);
//		{ CheckDD関連DLLの呼び出し }
//		procedure   CallCheckDD(ACheckDD:TCheckDD; CrntData:String);
//		var
//			hDSet:HDATASET;
//		begin
//			{ ﾃﾞｰﾀﾁｪｯｸ用ﾃﾞｰﾀ構造体のﾊﾝﾄﾞﾙ取得 }
//			hDSet := 0;
//			if (ACheckDD.Enabled = TRUE)
//			and (DsGetHandle(hDSet, kDefDataCheckStructName, _DA_GLOBAL) = TRUE) then begin
//				{  ﾃﾞｰﾀﾁｪｯｸ用ﾃﾞｰﾀ項目設定 }
//				DsSetText(hDSet, 'MODE',   PChar(ACheckDD.Mode));
//				DsSetText(hDSet, 'DDNAME', PChar(ACheckDD.DDName));
//				if ACheckDD.Data1             then DsSetText(hDSet, 'INPUT1', PChar(CrntData))
//				else if ACheckDD.Input1 <> '' then DsSetText(hDSet, 'INPUT1', PChar(ACheckDD.Input1));
//				if ACheckDD.Data2             then DsSetText(hDSet, 'INPUT2', PChar(CrntData))
//				else if ACheckDD.Input2 <> '' then DsSetText(hDSet, 'INPUT2', PChar(ACheckDD.Input2));
//
//				{ ﾃﾞｰﾀﾁｪｯｸ用DLL呼び出し }
//				DllCall(PChar(ACheckDD.FileName));
//			end;
//		end;
//
//	begin
//		{ TXEditの場合 }
//		if CrntCtrl is TXEdit then begin
//			if (TXEdit(CrntCtrl).Text <> '') and TXEdit(CrntCtrl).IsDataChanged then
//				CallCheckDD(TXEdit(CrntCtrl).CheckDD, TXEdit(CrntCtrl).Text);
//		end;
//	end;
//	{$ENDIF}

end.

