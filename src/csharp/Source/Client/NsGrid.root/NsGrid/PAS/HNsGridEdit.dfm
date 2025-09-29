object HNsGridEditF: THNsGridEditF
  Left = 0
  Top = 0
  BorderIcons = [biSystemMenu, biMaximize]
  Caption = #35542#29702#26126#32048#12475#12523#32080#21512#35373#23450
  ClientHeight = 262
  ClientWidth = 634
  Color = clBtnFace
  Constraints.MinHeight = 300
  Constraints.MinWidth = 650
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnClose = FormClose
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  OnShow = FormShow
  DesignSize = (
    634
    262)
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 377
    Top = 203
    Width = 21
    Height = 13
    Anchors = [akRight, akBottom]
    Caption = 'Row'
    ExplicitTop = 204
  end
  object Label2: TLabel
    Left = 377
    Top = 171
    Width = 15
    Height = 13
    Anchors = [akRight, akBottom]
    Caption = 'Col'
    ExplicitTop = 172
  end
  object AdvStringGrid1: TAdvStringGrid
    Left = 8
    Top = 8
    Width = 618
    Height = 151
    Cursor = crDefault
    Anchors = [akLeft, akTop, akRight, akBottom]
    FixedCols = 0
    FixedRows = 0
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    ScrollBars = ssBoth
    TabOrder = 0
    ActiveCellFont.Charset = DEFAULT_CHARSET
    ActiveCellFont.Color = clWindowText
    ActiveCellFont.Height = -11
    ActiveCellFont.Name = 'Tahoma'
    ActiveCellFont.Style = [fsBold]
    ControlLook.DropDownHeader.Font.Charset = DEFAULT_CHARSET
    ControlLook.DropDownHeader.Font.Color = clWindowText
    ControlLook.DropDownHeader.Font.Height = -11
    ControlLook.DropDownHeader.Font.Name = 'Tahoma'
    ControlLook.DropDownHeader.Font.Style = []
    ControlLook.DropDownHeader.Visible = True
    ControlLook.DropDownHeader.Buttons = <>
    ControlLook.DropDownFooter.Font.Charset = DEFAULT_CHARSET
    ControlLook.DropDownFooter.Font.Color = clWindowText
    ControlLook.DropDownFooter.Font.Height = -11
    ControlLook.DropDownFooter.Font.Name = 'Tahoma'
    ControlLook.DropDownFooter.Font.Style = []
    ControlLook.DropDownFooter.Visible = True
    ControlLook.DropDownFooter.Buttons = <>
    Filter = <>
    FilterDropDown.Font.Charset = DEFAULT_CHARSET
    FilterDropDown.Font.Color = clWindowText
    FilterDropDown.Font.Height = -11
    FilterDropDown.Font.Name = 'Tahoma'
    FilterDropDown.Font.Style = []
    FilterDropDownClear = '(All)'
    FixedRowHeight = 22
    FixedFont.Charset = DEFAULT_CHARSET
    FixedFont.Color = clWindowText
    FixedFont.Height = -11
    FixedFont.Name = 'Tahoma'
    FixedFont.Style = [fsBold]
    FloatFormat = '%.2f'
    PrintSettings.DateFormat = 'dd/mm/yyyy'
    PrintSettings.Font.Charset = DEFAULT_CHARSET
    PrintSettings.Font.Color = clWindowText
    PrintSettings.Font.Height = -11
    PrintSettings.Font.Name = 'Tahoma'
    PrintSettings.Font.Style = []
    PrintSettings.FixedFont.Charset = DEFAULT_CHARSET
    PrintSettings.FixedFont.Color = clWindowText
    PrintSettings.FixedFont.Height = -11
    PrintSettings.FixedFont.Name = 'Tahoma'
    PrintSettings.FixedFont.Style = []
    PrintSettings.HeaderFont.Charset = DEFAULT_CHARSET
    PrintSettings.HeaderFont.Color = clWindowText
    PrintSettings.HeaderFont.Height = -11
    PrintSettings.HeaderFont.Name = 'Tahoma'
    PrintSettings.HeaderFont.Style = []
    PrintSettings.FooterFont.Charset = DEFAULT_CHARSET
    PrintSettings.FooterFont.Color = clWindowText
    PrintSettings.FooterFont.Height = -11
    PrintSettings.FooterFont.Name = 'Tahoma'
    PrintSettings.FooterFont.Style = []
    PrintSettings.PageNumSep = '/'
    SearchFooter.FindNextCaption = 'Find &next'
    SearchFooter.FindPrevCaption = 'Find &previous'
    SearchFooter.Font.Charset = DEFAULT_CHARSET
    SearchFooter.Font.Color = clWindowText
    SearchFooter.Font.Height = -11
    SearchFooter.Font.Name = 'Tahoma'
    SearchFooter.Font.Style = []
    SearchFooter.HighLightCaption = 'Highlight'
    SearchFooter.HintClose = 'Close'
    SearchFooter.HintFindNext = 'Find next occurence'
    SearchFooter.HintFindPrev = 'Find previous occurence'
    SearchFooter.HintHighlight = 'Highlight occurences'
    SearchFooter.MatchCaseCaption = 'Match case'
    Version = '5.0.0.3'
  end
  object Button1: TButton
    Left = 470
    Top = 229
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = 'OK'
    Default = True
    ModalResult = 1
    TabOrder = 7
  end
  object Button2: TButton
    Left = 551
    Top = 229
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = #12461#12515#12531#12475#12523
    ModalResult = 2
    TabOrder = 8
  end
  object SpinEdit1: TSpinEdit
    Left = 407
    Top = 200
    Width = 57
    Height = 22
    Anchors = [akRight, akBottom]
    MaxValue = 10
    MinValue = 1
    TabOrder = 3
    Value = 1
    OnChange = SpinEdit1Change
  end
  object SpinEdit2: TSpinEdit
    Left = 407
    Top = 168
    Width = 57
    Height = 22
    Anchors = [akRight, akBottom]
    MaxValue = 150
    MinValue = 1
    TabOrder = 2
    Value = 1
    OnChange = SpinEdit2Change
  end
  object Button3: TButton
    Left = 470
    Top = 166
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = #12475#12523#12398#32080#21512
    TabOrder = 4
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 551
    Top = 166
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = #32080#21512#12434#35299#38500
    TabOrder = 5
    OnClick = Button4Click
  end
  object Memo1: TMemo
    Left = 8
    Top = 165
    Width = 353
    Height = 89
    TabStop = False
    Anchors = [akLeft, akRight, akBottom]
    BevelEdges = []
    BevelInner = bvNone
    BevelOuter = bvNone
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = #65325#65331' '#12468#12471#12483#12463
    Font.Style = []
    Lines.Strings = (
      '['#35542#29702#26126#32048#12475#12523#32080#21512#35373#23450']'
      #65297#35542#29702#26126#32048#20998#12398'Col, Row'#21450#12403#12475#12523#12398#32080#21512#24773#22577#12434#35373#23450#12375#12414#12377#12290
      ''
      #8251#65358#34892#65297#26126#32048#12398#65358#20516#12434'Row'#12395#35373#23450#12375#12414#12377#12290)
    ParentFont = False
    ReadOnly = True
    TabOrder = 1
  end
  object Button5: TButton
    Left = 470
    Top = 197
    Width = 156
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = #20840#12390#12398#32080#21512#12434#35299#38500
    TabOrder = 6
    OnClick = Button5Click
  end
end
