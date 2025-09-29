{
******************************************************************************
	HSS ｺﾝﾎﾟｰﾈﾝﾄﾗｲﾌﾞﾗﾘ  ｢HSS｣

		ﾌｫｰｶｽ枠描画ｺﾝﾄﾛｰﾙ

		ﾕﾆｯﾄ名  :   HFRAME.PAS
		作成者  :   Kubochi
		作成日  :   1999/7
		概要    :   ﾌｫｰｶｽを取得したｺﾝﾄﾛｰﾙの枠を着色する。

				THFrameControl   :   ﾌｫｰｶｽ枠色制御
//                  :                                                   //
// Update Note      :   2001.01.23  鹿野　幸生                          //
//                  :   ① ToolBarにフレーム描画が発生するとフォームの  //
//                  :      スクロールバーが表示されてしまう障害を解除   //
// Update Note      :   2009.08.10 23011 noguchi                        //
//                  :   Delphi2009ではTPanel.ParentBackgroundが         //
//                  :   デフォルトでTrueのためColorが反映されなかった   //
//                  :   現象を修正。                                    //
******************************************************************************
}
unit HFrame;

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
		SysUtils, WinTypes, WinProcs, Messages, Classes, Graphics, Controls,
		Forms, StdCtrls, ExtCtrls, HVersion, HLib,ComCtrls,dialogs;

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
			THFrameControlｵﾌﾞｼﾞｪｸﾄ定義
		-----------------------------------------------------------------------
		}
		THFrameControl = class(TComponent)
		private
                        FVersion :TVersion;
                        FFrameColor:TColor;				{ ﾌｫｰｶｽ枠色        }
                        FFrameVisible :Boolean;                         { 表示・非表示     }
                        FThick:Integer;                                 { 太さ             }
			FReceiver   :TMessageReceiver;

		protected
			MainForm:TForm;                                 { ﾒｲﾝﾌｫｰﾑ          }
                        PrevControl:TWinControl;                        { 前ﾌｫｰｶｽｺﾝﾄﾛｰﾙ    }
                        FocusPanel : TPanel;                            { ﾌｫｰｶｽPanel       }
			OnMessageCounter:Integer;                       { ﾊﾝﾄﾞﾗ再入ｶｳﾝﾀ    }
			OrgOnMessageHandler:TMessageEvent;              { ｵﾘｼﾞﾅﾙﾊﾝﾄﾞﾗ      }
                        
                private
                        procedure   PrintFrame(MODE:word;FocusCntrl:TWinControl);

		protected
			procedure   OnMessageHandler(var Msg:TMsg; var Handled:Boolean);

		public
			constructor Create(AOwner:TComponent); override;
			destructor  Destroy; override;
                        procedure   repaint;

		published
                        property    Version: TVersion read FVersion write FVersion stored False;
                        property    FrameColor : TColor read FFrameColor write FFrameColor;
                        property    FrameVisible :Boolean read FFrameVisible write FFrameVisible;
                        property    Thick:Integer read FThick write FThick;
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
		THFrameControl    ｺﾝｽﾄﾗｸﾀ
	---------------------------------------------------------------------------
	}
	constructor THFrameControl.Create(AOwner:TComponent);
	begin
		{ 派生元呼び出し }
		inherited Create(AOwner);
                FVersion     := HFrameControlVersion;
                FFrameColor  := clYellow;
                FFrameVisible:= True;
                Thick        := 1;

		{ ﾒﾝﾊﾞ初期化 }
		FReceiver    := TMessageReceiver.Create(self);
		MainForm := TForm(AOwner);
                PrevControl := nil;
                FocusPanel  := nil;
		OnMessageCounter := 0;

		{ OnMessageｲﾍﾞﾝﾄﾌｯｸ }
		if not (csDesigning in ComponentState) then begin
        		MainForm.InsertControl( FReceiver);
                        Application.ProcessMessages;                            // ﾙｰﾌﾟ接続前のﾒｯｾｰｼﾞを全て完了させる
			OrgOnMessageHandler := Application.OnMessage;
			Application.OnMessage := OnMessageHandler;
		end;
	end;

	{
	---------------------------------------------------------------------------
		THFrameControl    ﾃﾞｽﾄﾗｸﾀ
	---------------------------------------------------------------------------
	}
	destructor  THFrameControl.Destroy;
	begin
		if not (csDesigning in ComponentState) then begin
			Application.OnMessage := OrgOnMessageHandler;
                end;
		{ 派生元呼び出し }
		inherited Destroy;
	end;

	{
	---------------------------------------------------------------------------
		THFrameControl    ﾌｫｰｶｽ枠描画
	---------------------------------------------------------------------------
	}
        procedure THFrameControl.PrintFrame(MODE:word;FocusCntrl:TWinControl);
        begin
                if (FocusCntrl        = nil)
                or (FocusCntrl.Parent = nil)
                or (not(FocusCntrl.Parent is TWinControl)) then exit;

                if (MODE = 0)
                and(PrevControl = FocusCntrl) then exit;

                // ツールバーにはフレーム描画無し                               2001.01.23 追加
                if FocusCntrl is TToolbar then
                  Exit;

                if FocusPanel <> nil then
                  begin
                    FocusPanel.Free;
                    FocusPanel := nil;
                  end;

                if not(FFrameVisible) then begin
                  exit;
                end;

                { TPanel生成 }
                FocusPanel := TPanel.Create(MainForm);

                with FocusPanel do begin
                  //2009.08.10 23011 noguchi Delphi2009対応
                  //Delphi2009ではTPanel.ParentBackgroundがデフォルトでTrueのため指定背景色が反映されないのに対応
                  FocusPanel.ParentBackground := False;

                  Visible:= False;
                  Enabled:= False;
                  Parent := FocusCntrl.Parent;
                  Color  := FFrameColor;
                  Caption:= '';
                  BevelOuter := bvNone;
                  Top    := FocusCntrl.Top   - Thick;
                  Left   := FocusCntrl.Left  - Thick;
                  Width  := FocusCntrl.Width  + ( 2 * Thick );
                  Height := FocusCntrl.Height + ( 2 * Thick );
                end;

                FocusCntrl.BringToFront;

                FocusPanel.Visible:= True;

                FocusPanel.Repaint;

                { 今回ﾌｫｰｶｽ位置保存 }
                PrevControl := FocusCntrl;
                

        end;

	{
	---------------------------------------------------------------------------
		THFrameControl    Windowsﾒｯｾｰｼﾞのﾌｯｸ
	---------------------------------------------------------------------------
	}
	procedure THFrameControl.OnMessageHandler(var Msg:TMsg; var Handled:Boolean);
	var
		WinCtrl:TWinControl;
	begin
		Inc(OnMessageCounter);
		if OnMessageCounter = 1 then begin
			if (MainForm.Active) and (IsForegound) then begin
				with Msg, MainForm do begin
                                    { 移動先ｺﾝﾄﾛｰﾙ取得 }
				    WinCtrl := FindControl(hwnd);
				    if WinCtrl = nil then
				       WinCtrl := FindControl(GetParent(hwnd));

                                    if (handle = hwnd) or ((WinCtrl = nil) or (WinCtrl.Owner = MainForm) or (WinCtrl.Owner.Owner = MainForm)) then begin
					{ 再描画の捕捉 }
					if ((message = WM_ACTIVATE)
                                          or(message = WM_PAINT)
                                          or(message = WM_LBUTTONUP)
                                          or((message = WM_KEYUP)
       					      and ((Word(wParam) = VK_UP  ) or (Word(wParam) = VK_DOWN  )
  					        or (Word(wParam) = VK_LEFT) or (Word(wParam) = VK_RIGHT )
                                                or (Word(wParam) = VK_TAB ) or (Word(wParam) = VK_RETURN))))
                                        and (ActiveControl <> nil) then
                                            PrintFrame(0,ActiveControl)
                                        else if (WinCtrl <> nil)
                                            and (((message = WM_RBUTTONDOWN) and ((WinCtrl is TTreeView) or (WinCtrl is TListView)))
                                                 or (message = WM_RBUTTONUP))
                                            and (WinCtrl.CanFocus) and (not IsReadOnly(WinCtrl))
                                            and (IsMouseFocusControl(WinCtrl))
                                            and (GetBaseControl(WinCtrl) <> GetBaseControl(ActiveControl)) then
                                                PrintFrame(0,WinCtrl);

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
		THFrameControl    repaint
	---------------------------------------------------------------------------
	}
        procedure   THFrameControl.repaint;
        begin
            if (OnMessageCounter = 0)  
            and(MainForm.ActiveControl <> nil) then begin
                inc(OnMessageCounter);
                PrintFrame(1,MainForm.ActiveControl);
                Dec(OnMessageCounter);
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
		RegisterComponents('HSS', [THFrameControl]);
	end;
	{$ENDIF}

end.

