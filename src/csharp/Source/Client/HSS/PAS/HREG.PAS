{
******************************************************************************
    HSS ｺﾝﾎﾟｰﾈﾝﾄﾗｲﾌﾞﾗﾘ  ｢HSS｣

        ｺﾝﾎﾟｰﾈﾝﾄ登録ﾓｼﾞｭｰﾙ

        ﾕﾆｯﾄ名  :   HREG.PAS
        作成者  :   Kubochi
        作成日  :   1999/7
//                  :   2001.02.26  鹿野　幸生                          //
//                  :   ① HFrm,HRecをHPR50.BPLに移動                   //
//                  :   2002.10.30  鹿野　幸生                          //
//                  :   ① HStrComboBoxを追加                           //
//                  :   2009.08.11  須川  程志郎                        //
//                      HSS100対応(HSS70ベース)
//                  :   2009.09.29  iwamoto                        //
//                      HGrid追加
******************************************************************************
}
unit Hreg;

{$IFDEF VER90}        //Delphi2.0j Version
{$DEFINE UPDATE}
{$ELSE}
//{$DEFINE UPDATE}    //Delphi3
{$ENDIF}

{
******************************************************************************
    interface部
******************************************************************************
}
interface

    { ﾌﾟﾛｼｰｼﾞｬ、関数宣言 }
    procedure   Register;

{
******************************************************************************
    implementation部
******************************************************************************
}
implementation

    { ﾕﾆｯﾄ指定 }
    uses
//        Classes, DsgnIntf, Windows, HSS70
        Classes, Windows,
        HFocus,
        HEdit,
        HDedit,
//        XTedit,
//        XVedit,
//        XTable,
//        XFKey,
//        XFKeyBtn,
//        XSelGrid,
//        XCalendr,
//        XRepeat,
//        XRect,
//        HAnima,            // 2009.08.11 DEL
        HDblBtn,
//{$IFDEF UPDATE}
//        XPalette,
//{$ENDIF}
//        XAniEdit,
//        XRectFS,
//        XRectFT,
//        XEditCD,
//        HEditTag,
//        HExtCase,
//        XChkDD,
//        HExtEdit,
//        HNumEdit,
        HFrame,
        HImage,
        HLine,
        HLabel,
        HMemPos,
//        HImeCtl,           // 2009.08.11 DEL
        HDllCall,
        HComBox,
//        HRec,
//        HFrm,
        HHlpSct,
        HGRIDS;//2009.09.29 iwa add
//        NkGraph,           // 2009.08.11 DEL
//        NkDIB,             // 2009.08.11 DEL
//        NkImage;           // 2009.08.11 DEL

    { 定数定義 }
    const
        kPalettePageName = 'HSS'; { ﾊﾟﾚｯﾄﾍﾟｰｼﾞ名 }

    {
    ---------------------------------------------------------------------------
        登録
    ---------------------------------------------------------------------------
    }
    procedure   Register;
    begin
        { ｺﾝﾎﾟｰﾈﾝﾄの登録 }
        RegisterComponents(kPalettePageName, [
            THArrowKeyControl,            { 矢印ｷｰﾌｫｰｶｽｺﾝﾄﾛｰﾙ      }
            THRetKeyControl,              { RETｷｰﾌｫｰｶｽｺﾝﾄﾛｰﾙ       }
            THEdit,                       { 拡張ｴﾃﾞｨｯﾄ             }
            THNedit,                      { 数値ｴﾃﾞｨｯﾄ             }
            THDateEdit,                   { 日付ｴﾃﾞｨｯﾄ             }
//            TXTimeEdit,                 { 時刻ｴﾃﾞｨｯﾄ             }
//            TXValueEdit,                { 値ｴﾃﾞｨｯﾄ               }
//            TXFunckey,                  { ﾌｧﾝｸｼｮﾝｷｰｺﾝﾄﾛｰﾙ        }
//            TXFunckeyButton,            { ﾌｧﾝｸｼｮﾝｷｰﾎﾞﾀﾝ          }
//            TXTable,                    { 表構造                 }
//            TXSelectGrid,               { 選択ｸﾞﾘｯﾄﾞ             }
//            TXCalendar,                 { ｶﾚﾝﾀﾞ                  }
//            TXRepeat,                   { ﾘﾋﾟｰﾄｺﾝﾄﾛｰﾙ            }
//            TXRectangle,                { 矩形                   }
//            THAnimation,                  { ｱﾆﾒｰｼｮﾝ                }          // 2009.08.11 DEL
            THDoubleCaptionButton,        { ﾀﾞﾌﾞﾙｷｬﾌﾟｼｮﾝﾎﾞﾀﾝ       }
//{$IFDEF UPDATE}
//            TXPalette,                  { ﾊﾟﾚｯﾄｺﾝﾄﾛｰﾙ            }
//{$ENDIF}
//            TXEditCheckDD,              { CheckDDﾌﾟﾛﾊﾟﾃｨｴﾃﾞｨﾀ    }
//            THEditTag,                  { Tagﾌﾟﾛﾊﾟﾃｨｴﾃﾞｨﾀ        }
            THFrameControl,               { ﾌｫｰｶｽ枠描画ｺﾝﾄﾛｰﾙ      }
            THGradationImage,             { ｸﾞﾗﾃﾞｰｼｮﾝ描画ｺﾝﾄﾛｰﾙ    }
            THRepeatImage,                { BitMap複製描画ｺﾝﾄﾛｰﾙ   }
            THLine,                       { 直線                   }
            THLabel,                      { ﾗﾍﾞﾙｺﾝﾄﾛｰﾙ             }
            THMemPos,                     { Window位置記憶ｺﾝﾎﾟｰﾈﾝﾄ }
//            THImeControl,                 { かな変換ｺﾝﾎﾟｰﾈﾝﾄ       }          // 2009.08.11 DEL
            THDllCall,                    { DLLCALLコンポーネント  }
            THComboBox,                   { コンボボックス         }
            THStrComboBox,                { コンボボックス2        }            // 2002.10.30 追加
//            THRecControl,                 { ﾚｺｰﾄﾞ 読込ｺﾝﾎﾟｰﾈﾝﾄ     }
//            THFrmControl,                 { ﾌｫｰﾏｯﾄ読込ｺﾝﾎﾟｰﾈﾝﾄ     }
            THHelpSocket,                  { ヘルプソケットｺﾝﾎﾟｰﾈﾝﾄ }
            THStringGrid//2009.09.29 iwa add
//            THNkImage                                                         // 2009.08.11 DEL

        ]);

        { ﾌﾟﾛﾊﾟﾃｨｴﾃﾞｨﾀの登録 }
//        RegisterPropertyEditor(TypeInfo(TExtEdit),   nil, '', TExtEditProperty);
//        RegisterPropertyEditor(TypeInfo(THNumEdit),  nil, '', THNumEditProperty);
//        RegisterPropertyEditor(TypeInfo(TExtCase),   nil, '', TExtCaseProperty);

//        RegisterPropertyEditor(TypeInfo(TCheckDD),   nil, '', TCheckDDProperty);
//        RegisterPropertyEditor(TypeInfo(TXShortCut), nil, '', TXShortCutProperty);
//        RegisterPropertyEditor(TypeInfo(TFillStyle), nil, '', TFillStyleProperty);
//        RegisterPropertyEditor(TypeInfo(TFrameType), nil, '', TFrameTypeProperty);
//        RegisterPropertyEditor(TypeInfo(TScenario),  nil, '', TScenarioProperty);
{$IFDEF UPDATE}
        RegisterPropertyEditor(TypeInfo(COLORREF), TPaletteValue, '', TColorRefProperty);
{$ENDIF}

        { ｺﾝﾎﾟｰﾈﾝﾄｴﾃﾞｨﾀの登録 }
//        RegisterComponentEditor(TXEditCheckDD, TXEditCheckDDEditor);
//        RegisterComponentEditor(THEditTag, THEditTagEditor);
//{$IFDEF UPDATE}
//        RegisterComponentEditor(TXPalette, TXPaletteEditor);
//{$ENDIF}
    end;
end.


