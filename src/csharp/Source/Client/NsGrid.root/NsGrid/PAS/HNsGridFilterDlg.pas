unit HNsGridFilterDlg;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, BaseGrid, AdvGrid, HNsGrid, ExtCtrls, Buttons,
  ComCtrls;

type
  TfrmSetFilterDlg = class(TForm)
    btnAdd: TBitBtn;
    btnDel: TBitBtn;
    bvlSep: TBevel;
    btnUp: TBitBtn;
    btnDown: TBitBtn;
    grdCondition: TAdvStringGrid;
    btnOk: TButton;
    btnCancel: TButton;
    StatusBar1: TStatusBar;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure grdConditionCanEditCell(Sender: TObject; ARow, ACol: Integer;
      var CanEdit: Boolean);
    procedure grdConditionGetEditorType(Sender: TObject; ACol, ARow: Integer;
      var AEditor: TEditorType);
    procedure grdConditionCellChanging(Sender: TObject; OldRow, OldCol, NewRow,
      NewCol: Integer; var Allow: Boolean);
    procedure btnUpClick(Sender: TObject);
    procedure btnDownClick(Sender: TObject);
    procedure btnAddClick(Sender: TObject);
    procedure btnDelClick(Sender: TObject);
    procedure grdConditionGetAlignment(Sender: TObject; ARow, ACol: Integer;
      var HAlign: TAlignment; var VAlign: TVAlignment);
    procedure grdConditionGetCellColor(Sender: TObject; ARow, ACol: Integer;
      AState: TGridDrawState; ABrush: TBrush; AFont: TFont);
    procedure FormCloseQuery(Sender: TObject; var CanClose: Boolean);
  protected
    procedure CreateParams(var Params: TCreateParams); override;  //ADD 2010/04/26 M.Kubota
  private
    { Private �錾 }
    Candidates: TStringList;
    //function GetOwnerGrid: THNsGrid;  //DEL 2010/04/26 M.Kubota
  public
    { Public �錾 }
  end;

  function ShowFilterDlg(Owner: THNsGrid; ACol, ARow: Integer; var FilterConditions: TFilterConditions): Integer;


implementation

{$R *.dfm}

var
  frmSetFilterDlg: TfrmSetFilterDlg;
  Conditions     : TFilterConditions;
  ClickCell      : TGridCoord;
  SenderGrid     : THNsGrid;  //ADD 2010/04/26 M.Kubota
const
  FASTRELATION = '��';

function ShowFilterDlg(Owner: THNsGrid; ACol, ARow: Integer; var FilterConditions: TFilterConditions): Integer;
var
  iRow: Integer;
  fltExist: Integer;
  fltCondition: TFilterCondition;
begin
  ClickCell.X := ACol;
  ClickCell.Y := ARow;

  //frmSetFilterDlg := TfrmSetFilterDlg.Create(Owner);  //DEL 2010/04/26 M.Kubota

  //--- ADD 2010/04/26 M.Kubota --->>>
  SenderGrid := Owner;
  frmSetFilterDlg := TfrmSetFilterDlg.Create(Owner.Owner); // HNSGrid �̃I�[�i(Form)���w�肷��
  //--- ADD 2010/04/26 M.Kubota ---<<<
  try
    //--- ADD 2010/08/18 M.Kubota --->>>
    with frmSetFilterDlg.grdCondition do
    begin
      iRow := RowCount - 1;

      if (Length(FilterConditions) > 0) then
      begin
          // ���ɑI�΂�Ă���t�B���^�[�������ăZ�b�g����
          RowCount := Length(FilterConditions) + FixedRows;
          fltExist := -1;

          for fltCondition in FilterConditions do
          begin
            with fltCondition do
            begin
              iRow := Priority + FixedRows;

              // �֘A
              if (Relation = frNone) then
              begin
                Cells[0, iRow] := FASTRELATION;
              end else
              begin
                Cells[0, iRow] := FilterRelationName[Relation];
              end;

              Cells[1, iRow] := SenderGrid.Cells[ColNo, RowNo]; // ��
              Cells[2, iRow] := Value;                          // �l
              Cells[3, iRow] := FilterOperationName[Operation]; // ����

              if ((ColNo = ClickCell.X) and (RowNo = ClickCell.Y)) then
              begin
                fltExist := iRow;
              end;
            end;
          end;

          if (fltExist = -1) then
          begin
            AddRow;
            iRow := RowCount - 1;
            Cells[0, iRow] := FilterRelationName[frAnd];
            Cells[1, iRow] := SenderGrid.Cells[ClickCell.X, ClickCell.Y];
          end else
          begin
            iRow := fltExist;
          end;
      end else
      begin
        Cells[1, iRow] := SenderGrid.Cells[ClickCell.X, ClickCell.Y];
      end;

      Col := 2;
      Row := iRow;
    end;
    //--- ADD 2010/08/18 M.Kubota ---<<<

    Result := frmSetFilterDlg.ShowModal;

    if (Result = mrOk) then
    begin
      // �O���b�h��Ŏw�肳�ꂽ�t�B���^������ݒ肷��
      FilterConditions := Copy(Conditions, 0, Length(Conditions));
    end;

  finally
    frmSetFilterDlg.Release;
    frmSetFilterDlg := nil;
  end;
end;

procedure TfrmSetFilterDlg.btnAddClick(Sender: TObject);
begin
  with grdCondition do
  begin
    AddRow;

    Application.ProcessMessages;

    Row := RowCount - 1;
    Col := 0;
  end;
end;

procedure TfrmSetFilterDlg.btnDelClick(Sender: TObject);
begin
  with grdCondition do
  begin
    BeginUpdate;
    try
      if (RowCount = 2) then
      begin
        Rows[Row].Clear;
        //Cells[0, 1] := FASTRELATION;  //DEL 2010/08/18 M.Kubota
      end else
      begin
        RemoveRows(grdCondition.Row, 1);
      end;

      Cells[0, 1] := FASTRELATION;      //ADD 2010/08/18 M.Kubota
    finally
      EndUpdate;
    end;
  end;
end;

procedure TfrmSetFilterDlg.btnUpClick(Sender: TObject);
var
  CellValue: String;
begin
  with grdCondition do
  begin
    if (Row >= 2) then
    begin
      BeginUpdate;
      try
        if (Row = 2) then
        begin
          // �擪�s��"�֘A"�̂ݐ�ɓ���ւ���
          CellValue   := Cells[0, 1];
          Cells[0, 1] := Cells[0, 2];
          Cells[0, 2] := CellValue;
        end;

        MoveRow(Row, Row - 1);
        Row := Row - 1;
      finally
        EndUpdate;
      end;
    end;
  end;
end;

procedure TfrmSetFilterDlg.CreateParams(var Params: TCreateParams);
begin
  inherited CreateParams(Params);

  if (Self.Owner is TWinControl) then
  begin
    Params.WndParent := TWinControl(Self.Owner).Handle;
  end;
end;

procedure TfrmSetFilterDlg.btnDownClick(Sender: TObject);
var
  CellValue: String;
begin
  with grdCondition do
  begin
    if (Row < RowCount - 1) then
    begin
      BeginUpdate;
      try
        if (Row = 1) then
        begin
          // �擪�s��"�֘A"�̂ݐ�ɓ���ւ���
          CellValue   := Cells[0, 1];
          Cells[0, 1] := Cells[0, 2];
          Cells[0, 2] := CellValue;
        end;

        MoveRow(Row, Row + 1);
        Row := Row + 1;
      finally
        EndUpdate;
      end;
    end;
  end;
end;

procedure TfrmSetFilterDlg.FormCloseQuery(Sender: TObject;
  var CanClose: Boolean);

  function CheckEmptyCol(var ECol: Integer; ERow: Integer): Integer;
  var
    iCol: Integer;
    wCol: Integer;
    Emptys: array of Boolean;
    BlankPermit: Boolean;
  begin
    Result := -1;
    wCol   := - 1;

    with grdCondition do
    begin
      // "����"��"�|�󔒁["����"�[�󔒈ȊO�["�̏ꍇ�A"�l"�̋󔒂�������
      BlankPermit := ((Cells[3, ERow] = FilterOperationName[foIsBlank]) or
                      (Cells[3, ERow] = FilterOperationName[foNotBlank]) );

      SetLength(Emptys, ColCount);

      for iCol := 0 to ColCount - 1 do
      begin
        if iCol = 2 then
          Emptys[iCol] := (Cells[iCol, ERow] <> '') or BlankPermit
        else
          Emptys[iCol] := Cells[iCol, ERow] <> '';

        if ((not Emptys[iCol]) and (wCol = -1)) then
          wCol := iCol;
      end;

      if (ERow = 1) then
      begin
        if (Emptys[1] and Emptys[2] and Emptys[3]) then
          Result := 1
        else if (not(Emptys[1] or Emptys[2] or Emptys[3])) then
          Result := 0;
      end else
      begin
        if (Emptys[0] and Emptys[1] and Emptys[2] and Emptys[3]) then
          Result := 1
        else if (not(Emptys[0] or Emptys[1] or Emptys[2] or Emptys[3])) then
          Result := 0;
      end;

      if (Result = -1) then
        ECol := wCol;
    end;
  end;

var
  iCol, iRow: Integer;
  iValue: Integer;
  FilterOp: TFilterOperation;
begin
  if (ModalResult = mrOk) then
  begin
    // �Z���̓��͓��e���`�F�b�N����
    with grdCondition do
    begin
      for iRow := 1 to RowCount - 1 do
      begin
        iCol := 0;

        case CheckEmptyCol(iCol, iRow) of
          0:
            begin
              CanClose := True;
            end;
          1:
            begin
              CanClose := True;

              SetLength(Conditions, Length(Conditions) + 1);

              with Conditions[Length(Conditions) - 1] do
              begin
                Priority  := iRow - 1;           // �D�揇��

                // �i�荞�݊֘A�l
                if (iRow = 1) then
                begin
                  Relation := frNone;
                end else
                begin
                  if (Cells[0, iRow] = FilterRelationName[frAnd]) then
                  begin
                    Relation := frAnd;
                  end else
                  begin
                    Relation := frOr;
                  end;
                end;

                // �Z���l���s��l(Low=Col, High=Row)
                iValue := StrToIntDef(Candidates.Values[Cells[1, iRow]], 0);

                // �Ώۗ�ԍ�
                ColNo := LOWORD(iValue);

                // �Ώۍs�ԍ� (���i�p)
                RowNo := HIWORD(iValue);

                // �Ώےl
                Value     := grdCondition.Cells[2, iRow];

                // �i�荞�ݓ���
                for FilterOp := Low(TFilterOperation) to High(TFilterOperation) do
                begin
                  if (Cells[3, iRow] = FilterOperationName[FilterOp]) then
                  begin
                    Operation := FilterOp;
                    Break;
                  end;
                end;
              end;

            end;
          else
            begin
              CanClose := False;

              BeginUpdate;
              try
                Row := iRow;
                Col := iCol;
                SetFocus;
              finally
                EndUpdate;
              end;

              MessageDlg(Format('"%S"�Ɏw�肳��Ă�����e�Ɍ�肪�L��܂�', [Cells[iCol, 0]]), mtWarning, [mbOk], 0);
              Break;
            end;
        end;
      end;
    end;
  end;
end;

procedure TfrmSetFilterDlg.FormCreate(Sender: TObject);
var
  iCol, iRow: Integer;
  BasePos: TPoint;
begin
  Candidates := TStringList.Create;
  SetLength(Conditions, 0);

  with grdCondition do
  begin
    Cells[0, 0] := '�֘A';
    Cells[1, 0] := '��';
    Cells[2, 0] := '�l';
    Cells[3, 0] := '����';

    Cells[0, 1] := FASTRELATION;

    //Col := 1;  //DEL 2010/08/18 M.Kubota
    //Row := 1;  //DEL 2010/08/18 M.Kubota
  end;

  with SenderGrid do
  begin
    grdCondition.Look := Look;

    for iRow := 0 to FixedRows - 1 do
    begin
      for iCol := 0 to ColCount - 1 do
      begin
        // �c�����������Ă�Œ�s�͗L���l�Ƃ݂͂Ȃ��Ȃ�
        if iCol < FixedCols then
        begin
          Continue;
        end;

        // �^�C�g�����w�肳��Ă����̂ݍi�荞�݌��ɐݒ肷��
        // �w�W��
        if (Trim(Cells[iCol, iRow]) <> '') then
        begin

          // ��_�ł͂Ȃ������Z���͑ΏۊO
          if (IsMergedCell(iCol, iRow)) then
          begin
            BasePos := BaseCell(iCol, iRow);
            if ((BasePos.X <> iCol) or (BasePos.Y <> iRow)) then
            begin
              Continue;
            end;
          end;

          if (HasButton(iCol, iRow)) then
          begin
            // �Z���l���s��l(Low=Col, High=Row)
            Candidates.Values[Cells[iCol, iRow]] := IntToStr(MakeLong(iCol,iRow));
          end;
          {$REGION '�y�ۗ��z'}
          {
          if AutoLayoutSet then
          begin
            Candidates.Values[Cells[iCol, iRow]] := IntToStr(MakeLong(iCol,iRow));
          end else
          begin
            if iRow = (FixedRows - 1) then
            begin
              Candidates.Values[Cells[iCol, iRow]] := IntToStr(MakeLong(iCol,iRow));
            end;
          end;
          }
          {$ENDREGION}
        end;
      end;

      //grdCondition.Cells[1, 1] := Cells[ClickCell.X, ClickCell.Y];  //DEL 2010/08/18 M.Kubota
    end;
  end;

end;

procedure TfrmSetFilterDlg.FormDestroy(Sender: TObject);
begin
  // �񖼃��X�g�����
  Candidates.Free;
end;

//--- DEL 2010/04/26 M.Kubota --->>>
//function TfrmSetFilterDlg.GetOwnerGrid: THNsGrid;
//begin
//  Result := Owner as THNsGrid;
//end;
//--- DEL 2010/04/26 M.Kubota ---<<<

procedure TfrmSetFilterDlg.grdConditionCanEditCell(Sender: TObject; ARow,
  ACol: Integer; var CanEdit: Boolean);
begin
  if ((ACol = 0) and (ARow = 1)) then
  begin
    // �ŏ��̏����Ɋ֘A�͖���
    CanEdit := False;
  end;
end;

procedure TfrmSetFilterDlg.grdConditionCellChanging(Sender: TObject; OldRow,
  OldCol, NewRow, NewCol: Integer; var Allow: Boolean);
begin
  if ((NewCol = 0) and (NewRow = 1)) then
  begin
    Allow := False;
  end;
end;

procedure TfrmSetFilterDlg.grdConditionGetAlignment(Sender: TObject; ARow,
  ACol: Integer; var HAlign: TAlignment; var VAlign: TVAlignment);
begin
  if ((ACol = 0) and (ARow = 1)) then
  begin
    HAlign := taCenter;
  end;
end;

procedure TfrmSetFilterDlg.grdConditionGetCellColor(Sender: TObject; ARow,
  ACol: Integer; AState: TGridDrawState; ABrush: TBrush; AFont: TFont);
begin
  if ((ACol = 0) and (ARow = 1)) then
  begin
    ABrush.Color := grdCondition.GridLineColor;
    AFont.Color  := clGrayText;
  end;
end;

function ValueCompare(List: TStringList; Index1, Index2: Integer): Integer;
var
  num1,
  num2: Extended;
  str1,
  str2: String;
  numChk: Boolean;
begin

  str1 := List[Index1];
  str2 := List[Index2];

  numChk := True;

  try
    num1 := StrToFloat(str1);
    num2 := StrToFloat(str2);
  except
    numChk := False;
  end;

  if (numChk) then
  begin
    // ���l�Ƃ���
    if num1 < num2 then Result := -1 else
    if num1 > num2 then Result :=  1 else Result := 0;
  end else
  begin
    // �����Ƃ���
    Result := AnsiCompareStr(str1, str2);
  end;

end;

procedure TfrmSetFilterDlg.grdConditionGetEditorType(Sender: TObject; ACol,
  ARow: Integer; var AEditor: TEditorType);
var
  sbuf : string;
  iValue: Integer;
  iCol, iRow: Integer;
  iCnt: Integer;
  iIdx: Integer;
  sVal: String;
  FilterOp: TFilterOperation;
  slValues: TStringList;
begin
  case ACol of
    0:  // �֘A
      begin
        AEditor := edComboList;
        grdCondition.ClearComboString;
        grdCondition.AddComboString(FilterRelationName[frAnd]);
        grdCondition.AddComboString(FilterRelationName[frOr]);
      end;

    1: // ��
      begin
        AEditor := edComboList;
        grdCondition.ClearComboString;

        for iCnt := 0 to Candidates.Count - 1 do
        begin
          sVal := Candidates.Names[iCnt];
          iIdx := grdCondition.Cols[1].IndexOf(sVal);

          if ((iIdx <= 0) or (iIdx = ARow)) then
          begin
            grdCondition.AddComboString(sVal);
          end;
        end;
      end;

    2: // �l
      begin
        AEditor := edComboEdit;
        grdCondition.ClearComboString;

        if (grdCondition.Cells[1, ARow] <> '') then
        begin
          // �Z���l���s��l(Low=Col, High=Row)
          iValue := StrToIntDef(Candidates.Values[grdCondition.Cells[1, ARow]], 0);

          // �Ώۗ�ԍ�
          iCol := LOWORD(iValue);

          // �Ώۍs�ԍ� (���i�p)
          iRow := HIWORD(iValue);

          with SenderGrid do
          begin
            slValues := TStringList.Create;
            slValues.Sorted := True;
            slValues.Duplicates := dupIgnore;

            for sbuf in LogicalCols[iRow,iCol] do
            begin
              if Trim(sbuf) <> '' then
              begin
                slValues.Add(sbuf);
              end;
            end;

            slValues.Sorted := False;
            slValues.CustomSort(ValueCompare);

            for sbuf in slValues do
            begin
              grdCondition.AddComboString(sbuf);
            end;

          end;
        end;
      end;

    3: // �֌W
      begin
        AEditor := edComboList;
        grdCondition.ClearComboString;

        for FilterOp := Low(TFilterOperation) to High(TFilterOperation) do
        begin
          grdCondition.AddComboString(FilterOperationName[FilterOp]);
        end;
      end;
  end;
end;

end.
