unit NSCMN00607CT;

interface


uses
  Windows,Classes;

function GetMutexKeyCLI():PChar ; cdecl; external 'NSCMN00651M.dll';

type
  TMutexCheckThread = class(TThread)
  private
    { Private 宣言 }
    procedure TMutexClose;

  protected
    procedure Execute; override;
  end;

implementation

uses
  NSCMN00607CP;

{ 重要：ビジュアルコンポーネントではオブジェクトのメソッドと
  プロパティは Synchronize を使用して呼び出されたメソッドで
  しか使用することができません。他のオブジェクトを参照するため
  のメソッドをスレッドクラスに追加し、Synchronize メソッドの
  引数として渡します。

      Synchronize(UpdateCaption);

  たとえば、UpdateCaption メソッドを以下のように定義し、

    procedure TMutexCheckThread.UpdateCaption;
    begin
      Form1.Caption := 'スレッドから書き換えました';
    end; 
    
    または、次のようにします。
    
    Synchronize(
      procedure 
      begin
        Form1.Caption := '無名メソッドを通じてスレッドで更新されました'
      end
      )
    );
    
  ここでは、無名メソッドが渡されています。

  同様に、開発者は上記と似たパラメータで Queue メソッドを呼び出すことができます。
  代わりに別の TThread クラスを第 1 パラメータとして渡し、呼び出し元のスレッドを
  もう一方のスレッドでキューに入れます。
    
}

{ TMutexCheckThread }

procedure TMutexCheckThread.Execute;

begin
  { スレッドとして実行したいコードをここに記述してください }

  WaitForSingleObject(hMutex, INFINITE);
  // --- UPD 2012/11/07 T.Nishi ---------->>>>>
  //ApplicationReleasedMsg();
  //メインフォームのタグ番号が0の場合はメッセージ表示
  if gApplication.MainForm.Tag = 0 then begin
    ApplicationReleasedMsg();
  end;
  // --- UPD 2012/11/07 T.Nishi ----------<<<<<
  Synchronize(TMutexClose);

end;


procedure  TMutexCheckThread.TMutexClose;
begin
  ReleaseMutex(hMutex);
  CloseHandle(hMutex);
  //gApplication.MainForm.Close;
  gApplication.Terminate;

end;


end.
