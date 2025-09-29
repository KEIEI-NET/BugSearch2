object CalendarForm: TCalendarForm
  Left = 0
  Top = 0
  AutoSize = True
  BorderStyle = bsNone
  Caption = 'CalendarForm'
  ClientHeight = 189
  ClientWidth = 218
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  KeyPreview = True
  OldCreateOrder = False
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object ApplicationEvents1: TApplicationEvents
    OnMessage = AppEventsMessage
    Left = 112
    Top = 80
  end
end
