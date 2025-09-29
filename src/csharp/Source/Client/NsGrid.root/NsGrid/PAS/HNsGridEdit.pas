//**********************************************************************
// System           :   RC.NS
// Sub System       :
// Program name     :   BLStringGridレイアウトエディタ(サンプル実装)
//                  :
// Name Space       :
// Programmer       :   渋谷
// Date             :   2009.11.04
//----------------------------------------------------------------------
// Update Note      :  2009.11.04 渋谷大輔
//                      サンプルとして新規作成
//                      <<実装の概要>>
//                        BLStringGridのレイアウト設計を容易にするための
//                        エディタ画面
//                         ・設計時、BLStringGrid.Layoutを編集する際に表示される
//                         ・1明細の、カラム数・行数・セルの結合情報を編集可能
//
//                      <<実装内容>>
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
unit HNsGridEdit;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, BaseGrid, AdvGrid, StdCtrls, Spin, DesignEditors, DesignIntf;

type
  THNsGridEditF = class(TForm)
    AdvStringGrid1: TAdvStringGrid;
    Button1: TButton;
    Button2: TButton;
    SpinEdit1: TSpinEdit;
    SpinEdit2: TSpinEdit;
    Button3: TButton;
    Button4: TButton;
    Label1: TLabel;
    Label2: TLabel;
    Memo1: TMemo;
    Button5: TButton;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure SpinEdit1Change(Sender: TObject);
    procedure SpinEdit2Change(Sender: TObject);
    procedure LoadFromLayoutStrings;
    procedure SaveToLayoutStrings;
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
  private
    { Private 宣言 }
  public
    { Public 宣言 }
  end;

//=============================================================================
//  Layoutプロパティの設定用クラス
//  名前は任意だが，ここではTInfoPropertyとした
//  最低限GetAttributesとEditを装備する
//=============================================================================
  TLayoutProperty = class(TClassProperty)
    function GetAttributes: TPropertyAttributes; override;
    procedure Edit; override;
  end;


var
  LayoutStrings    : TStringList;
  BLStringGridEditF: THNsGridEditF;

procedure Register;

implementation

{$R *.dfm}

uses
  HNsGrid;

//=============================================================================
//  コンポーネント登録情報
//  RegisterPropertyEditor部
//  TypeInfo(XXXX)   XXXXはプロパティの型(String型ならStringとする)
//  TMyCompB         コンポーネント名
//  'Info'           登録するプロパティの名前
//  TInfoProperty    自分で定義したプロパティエディタクラス名
//=============================================================================
procedure Register;
begin
  RegisterPropertyEditor(TypeInfo(TStringList), THNsGrid, 'Layout', TLayoutProperty);
end;

//=============================================================================
//  Layoutプロパティの属性
//  paDialog        ダイアログ表示
//  paSubProperties オブジェクトインスペクタで[+}クリックで展開
//  paMultiSelect   複数コンポ同時編集可
//  paReadOnly      オブジェクト型の場合必ず指定(直接編集不可)
//                  このコンポでは指定しても編集可能(プロパティの性質から)
//=============================================================================
function TLayoutProperty.GetAttributes: TPropertyAttributes;
begin
  Result := [paDialog, paReadOnly];
end;

//=============================================================================
//  Layoutプロパティ設定用ダイアログMyCompBFormを表示
//=============================================================================
procedure TLayoutProperty.Edit;
var
  AEditor: THNsGridEditF;
  ALayout: TStringList;
begin
  AEditor := THNsGridEditF.Create(nil);
  ALayout := TStringList.Create;

  try
    //THNsGridからLayoutプロパティの値を受け取る
    ALayout.Assign(Pointer(GetOrdValue));
    LayoutStrings.Text := ALayout.Text;

    if AEditor.ShowModal=mrOK then
    begin
      //THNsGridにLayoutプロパティの値を返す
      ALayout.Text := LayoutStrings.Text;
      SetOrdValue(LongInt(ALayout));
    end;
  finally
    FreeAndNil(AEditor);
    ALayout.Free;
  end;
end;

//=============================================================================
//  エディター画面Create
//=============================================================================
procedure THNsGridEditF.FormCreate(Sender: TObject);
begin
  LayoutStrings := TStringList.Create;
end;

//=============================================================================
//  エディター画面Destroy
//=============================================================================
procedure THNsGridEditF.FormDestroy(Sender: TObject);
begin
  LayoutStrings.Free;
end;

//=============================================================================
//  エディター画面Close
//=============================================================================
procedure THNsGridEditF.FormClose(Sender: TObject;
  var Action: TCloseAction);
begin
  //画面設定値を保存する
  SaveToLayoutStrings;
end;

//=============================================================================
//  エディター画面Show
//=============================================================================
procedure THNsGridEditF.FormShow(Sender: TObject);
begin
  //画面に値を設定する
  LoadFromLayoutStrings;
end;

//=============================================================================
//  セル結合処理
//=============================================================================
procedure THNsGridEditF.Button3Click(Sender: TObject);
var
  x,y,w,h:integer;
begin
  //セル結合処理
  with AdvStringGrid1.Selection do
  begin
    y := Top;
    x := Left;
  end;

  h := AdvStringGrid1.RowSelectCount;
  w := AdvStringGrid1.ColSelectCount;

  AdvStringGrid1.MergeCells(x, y, w, h);

  //値を保存して再描画
  SaveToLayoutStrings;
  LoadFromLayoutStrings;
end;

//=============================================================================
//  セル結合解除処理
//=============================================================================
procedure THNsGridEditF.Button4Click(Sender: TObject);
var
  x,y:integer;
begin
  //セル結合解除処理
  y := AdvStringGrid1.Row;
  x := AdvStringGrid1.Col;

  AdvStringGrid1.SplitCells(x,y);

  //再描画
  SaveToLayoutStrings;
  LoadFromLayoutStrings;
end;

procedure THNsGridEditF.Button5Click(Sender: TObject);
begin
  AdvStringGrid1.SplitAllCells;

  //再描画
  SaveToLayoutStrings;
  LoadFromLayoutStrings;
end;

//=============================================================================
//  RowCount Changeイベント
//=============================================================================
procedure THNsGridEditF.SpinEdit1Change(Sender: TObject);
begin
  AdvStringGrid1.RowCount := SpinEdit1.Value;
end;

//=============================================================================
//  ColCount Changeイベント
//=============================================================================
procedure THNsGridEditF.SpinEdit2Change(Sender: TObject);
begin
  AdvStringGrid1.ColCount := SpinEdit2.Value;

end;

//=============================================================================
//  画面に値を設定する
//=============================================================================
procedure THNsGridEditF.LoadFromLayoutStrings;
var
  sbuf : Tstringlist;
  ix :integer;
begin
  //明細行数の設定
  sbuf := Tstringlist.Create;
  sbuf.CommaText := LayoutStrings[0];

  AdvStringGrid1.RowCount := strtoint(sbuf[1]);
  SpinEdit1.Value := strtoint(sbuf[1]);

  AdvStringGrid1.ColCount := strtoint(sbuf[0]) ;
  SpinEdit2.Value := strtoint(sbuf[0]);
  //セルの結合処理
  for ix := 1 to LayoutStrings.Count - 1 do
  begin
    sbuf.CommaText := LayoutStrings[ix];
    AdvStringGrid1.MergeCells(strtoint(sbuf[0])-1,strtoint(sbuf[1]) - 1,strtoint(sbuf[2]),strtoint(sbuf[3]));
  end;

  sbuf.Free;
end;

//=============================================================================
//  画面設定値を保存する
//=============================================================================
procedure THNsGridEditF.SaveToLayoutStrings;
var
  ix,iy:integer;
  rectx,recty,rectw,recth:integer;
  rect :Trect;
begin
//プロパティ変更イベント

  LayoutStrings.Clear;
  //最初にプロパティ値を書き出す
  LayoutStrings.Add(format('%d,%d',[AdvStringGrid1.ColCount,AdvStringGrid1.RowCount]));

  for iy := 0 to AdvStringGrid1.RowCount - 1 do
  begin
    for ix := 0 to AdvStringGrid1.ColCount - 1do
    begin
      if (AdvStringGrid1.IsBaseCell(ix,iy) and AdvStringGrid1.IsMergedCell(ix,iy)) then
      begin
        rect := AdvStringGrid1.FullCell(ix,iy);
        rectx := rect.Left + 1;
        recty := rect.Top + 1;
        rectw := rect.Right - rect.Left + 1;
        recth := rect.Bottom - rect.Top + 1;

        LayoutStrings.Add(format('%d,%d,%d,%d',[rectx,recty,rectw,recth]));
      end;
    end;
  end;

end;

end.
