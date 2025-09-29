//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : UOE発注先設定
// プログラム概要   : UOE発注先マスタ情報の設定を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 犬飼
// 作 成 日  2008/06/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/01  修正内容 : メーカー毎の専用項目をタブで表示するように変更
//           2009/08/12  修正内容 : 回答保存フォルダの入力チェックを無効に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 夏野 駿希
// 修 正 日  2009/09/14  修正内容 : MANTIS【14242】発注可能メーカー表示桁数不足
// 修 正 日  2009/09/14  修正内容 : MANTIS【14243】修正呼出時『初期値設定項目』の『指定拠点』が表示されない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : xuxh
// 修 正 日  2009/12/29  修正内容 : 【要件No.1】
//                                  トヨタ電子カタログで使用する送信・受信データの保存場所を設定する
//----------------------------------------------------------------------------//
// 管理番号  10507391-00 作成担当 : 譚洪
// 修 正 日  2010/01/19  修正内容 : Redmine:2505
//                                  Redmine指摘の対応
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 楊明俊
// 修 正 日  2010/03/08  修正内容 : PM1006
//                                  日産Web-UOE連動項目の対応
//----------------------------------------------------------------------------//
// 管理番号  10601191-00 作成担当 : jiangk
// 修 正 日  2010/04/23  修正内容 : PM1007C
//                                  三菱Web-UOE連動項目の対応
//----------------------------------------------------------------------------//
// 管理番号  10601191-00 作成担当 : 呉元嘯
// 修 正 日  2010/05/14  修正内容 : PM1008
//                                  明治UOEWeb項目の対応
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 朱猛
// 修 正 日  2010/07/27  修正内容 : PM1011
//                                  トヨタUOEWeb項目の対応
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : 譚洪
// 作 成 日  2010/12/31  修正内容 : UOE自動化改良
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : 施ヘイ中
// 作 成 日  2011/01/28  修正内容 : 回答自動取込区分（トヨタWEBUOE用自動連携用の設定区分）の変更
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : liyp
// 作 成 日  2011/03/01  修正内容 : 回答自動取込区分（日産WEBUOE用自動連携用の設定区分）の変更
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : liyp
// 作 成 日  2011/03/15  修正内容 : プログラム「0206」の追加仕様分の組み込み
//----------------------------------------------------------------------------//
// 管理番号  10702591-00 作成担当 : 施ヘイ中
// 作 成 日  2011/05/10  修正内容 : 回答保存フォルダ（マツダWebUOE用連携ファイルの格納場所）の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛中華
// 作 成 日  2011/10/26  修正内容 : PM1113A 卸NET-WEB対応に伴う仕様追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 作 成 日  2011/12/15  修正内容 : Redmine#27386トヨタUOEWebタクティー品番の発注対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高川 悟
// 作 成 日  2012/09/10  修正内容 : BL管理ユーザーコード対応
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// UOE発注先マスタ フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: UOE発注先マスタ情報の設定を行います。
    ///					  IMasterMaintenanceMultiTypeを実装しています。</br>
    /// <br>Programmer	: 30413 犬飼</br>
    /// <br>Date		: 2008.06.26</br>
    /// <br>UpdateNote  : 2009/06/01 照田 貴志　メーカー毎の専用項目をタブで表示するように変更</br>
    /// <br>                                    ホンダe-Parts項目を追加</br>
    /// <br>UpdateNote  : 2009/12/29 xuxh</br>
    /// <br>              【要件No.1】</br>
    /// <br>              トヨタ電子カタログで使用する送信・受信データの保存場所を設定する</br> 
    /// <br>Update Note : 2010/01/19 譚洪</br>
    /// <br>              Redmine:2505</br>
    /// <br>              Redmine指摘の対応</br>
    /// <br>Update Note : 2010/03/08 楊明俊</br>
    /// <br>              PM1006</br>
    /// <br>              日産Web-UOE連動項目の対応</br>
	/// <br>Update Note : 2010/04/23 jiangk</br>
	/// <br>              PM1007C</br>
	/// <br>              三菱Web-UOE連動項目の対応</br>
    /// <br>Update Note : 2010/05/14 呉元嘯</br>
    /// <br>              PM1008</br>
    /// <br>              明治UOEWeb項目の対応</br>
    /// <br>Update Note : 2010/07/27 朱猛</br>
    /// <br>              PM1011</br>
    /// <br>              トヨタUOEWeb項目の対応</br>
    /// <br>UpdateNote  : 2010/12/31 譚洪</br>
    /// <br>            : UOE自動化改良</br>
    /// <br>UpdateNote  : 2011/01/28 施ヘイ中</br>
    /// <br>            :（トヨタWEBUOE用自動連携用の設定区分）の変更</br>
    /// <br>Update Note      :  2011/03/01 liyp</br>
    /// <br>       回答自動取込区分（日産WEBUOE用自動連携用の設定区分）の変更</br>
    /// <br>Update Note  : 2011/03/15 liyp </br>
    /// <br>               プログラム「0206」の追加仕様分の組み込み</br>
    /// <br>UpdateNote  : 2011/05/10 施ヘイ中</br>
    /// <br>            : 回答保存フォルダ（マツダWebUOE用連携ファイルの格納場所）の追加</br>
    /// <br>UpdateNote  : 2011/10/26 葛中華</br>
    /// <br>            : PM1113A 卸NET-WEB対応に伴う仕様追加</br>
    /// <br>UpdateNote  : 2011/12/15 yangmj</br>
    /// <br>            : Redmine#27386トヨタUOEWebタクティー品番の発注対応</br>
    /// </remarks>
    public class PMUOE09020UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        # region ※Private Members (Component)

        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraLabel UOESupplierCd_Label;
        private TEdit UOESupplierName_tEdit;
        private Infragistics.Win.Misc.UltraLabel GoodsMakerCd_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel TelNo_Label;
        private Infragistics.Win.Misc.UltraLabel UOETerminalCd_Label;
        private Infragistics.Win.Misc.UltraLabel UOEHostCode_Label;
        private Infragistics.Win.Misc.UltraLabel UOEConnectPassword_Label;
        private Infragistics.Win.Misc.UltraLabel UOEConnectUserId_Label;
        private Infragistics.Win.Misc.UltraLabel UOEIDNum_Label;
        private Infragistics.Win.Misc.UltraLabel CommAssemblyId_Label;
        private TEdit GoodsMakerNm_tEdit;
        private TEdit TelNo_tEdit;
        private TNedit UOESupplierCd_tNedit;
        private TNedit tNedit_GoodsMakerCdAllowZero;
        private TEdit UOETerminalCd_tEdit;
        private TEdit UOEHostCode_tEdit;
        private TEdit UOEConnectPassword_tEdit;
        private TEdit UOEConnectUserId_tEdit;
        private TEdit UOEIDNum_tEdit;
        private TEdit CommAssemblyId_tEdit;
        private Infragistics.Win.Misc.UltraLabel ConnectVersionDiv_Label;
        private TComboEditor ConnectVersionDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel UOEShipSectCd_Label;
        private Infragistics.Win.Misc.UltraLabel UOESalSectCd_Label;
        private Infragistics.Win.Misc.UltraLabel UOEReservSectCd_Label;
        private Infragistics.Win.Misc.UltraLabel ReceiveCondition_Label;
        private Infragistics.Win.Misc.UltraLabel SubstPartsNoDiv_Label;
        private Infragistics.Win.Misc.UltraLabel PartsNoPrtCd_Label;
        private Infragistics.Win.Misc.UltraLabel ListPriceUseDiv_Label;
        private Infragistics.Win.Misc.UltraLabel StockSlipDtRecvDiv_Label;
        private Infragistics.Win.Misc.UltraLabel CheckCodeDiv_Label;
        private TEdit UOEShipSectCd_tEdit;
        private TEdit UOEShipSectNm_tEdit;
        private TEdit UOESalSectCd_tEdit;
        private TEdit UOESalSectNm_tEdit;
        private TEdit UOEReservSectCd_tEdit;
        private TEdit UOEReservSectNm_tEdit;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraLabel UOEOrderRate_Label;
        private Infragistics.Win.Misc.UltraLabel BoCode_Label;
        private Infragistics.Win.Misc.UltraLabel DeliveredGoodsDiv_Label;
        private Infragistics.Win.Misc.UltraLabel EmployeeCode_Label;
        private Infragistics.Win.Misc.UltraLabel UOEResvdSection_Label;
        private Infragistics.Win.Misc.UltraLabel BusinessCode_Label;
        private TComboEditor BusinessCode_tComboEditor;
        private TComboEditor ReceiveCondition_tComboEditor;
        private TComboEditor SubstPartsNoDiv_tComboEditor;
        private TComboEditor PartsNoPrtCd_tComboEditor;
        private TComboEditor ListPriceUseDiv_tComboEditor;
        private TComboEditor StockSlipDtRecvDiv_tComboEditor;
        private TComboEditor CheckCodeDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel26;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel33;
        private TEdit UOEOrderRate_tEdit;
        private Infragistics.Win.Misc.UltraButton uButton_UOESupplierGuide;
        private Infragistics.Win.Misc.UltraButton uButton_UOEShipSectGuide;
        private Infragistics.Win.Misc.UltraButton uButton_UOESalSectGuide;
        private Infragistics.Win.Misc.UltraButton uButton_UOEReservSectGuide;
        private Infragistics.Win.Misc.UltraButton uButton_MakerGuide;
        private Infragistics.Win.Misc.UltraButton uButton_SupplierGuide;
        private TRetKeyControl tRetKeyControl1;
        private IContainer components;
        private TArrowKeyControl tArrowKeyControl1;
        private DataSet Bind_DataSet;
        private Timer Initial_Timer;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel SupplierCd_Label;
        private TNedit tNedit_SupplierCd;
        private TEdit SupplierNm_tEdit;
        private TComboEditor UOEResvdSection_tComboEditor;
        private Infragistics.Win.Misc.UltraButton uButton_EmployeeGuide;
        private TComboEditor BoCode_tComboEditor;
        private TComboEditor DeliveredGoodsDiv_tComboEditor;
        private TEdit tEdit_EmployeeCode;
        private TEdit tEdit_EmployeeName;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl Maker_ultraTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl Mazda_AnswerAutoDiv_ultraLabel;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.Misc.UltraLabel HondaSectionCode_Label;
        private Infragistics.Win.Misc.UltraLabel UOEItemCd_Label;
        private Infragistics.Win.Misc.UltraLabel UOETestMode_Label;
        private Infragistics.Win.Misc.UltraLabel instrumentNo_Label;
        private TEdit instrumentNo_tEdit;
        private TEdit HondaSectionCode_tEdit;
        private TEdit UOEItemCd_tEdit;
        private TEdit UOETestMode_tEdit;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox4;
        private Infragistics.Win.Misc.UltraLabel MazdaSectionCode_Label;
        private TEdit MazdaSectionCode_tEdit;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox5;
        private Infragistics.Win.Misc.UltraLabel EmergencyDiv_Label;
        private TComboEditor EmergencyDiv_tComboEditor;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private TEdit UOEForcedTermUrl_tEdit;
        private Infragistics.Win.Misc.UltraLabel UOEForcedTermUrl_Label;
        private TEdit UOEStockCheckUrl_tEdit;
        private Infragistics.Win.Misc.UltraLabel UOEStockCheckUrl_Label;
        private TEdit UOEOrderUrl_tEdit;
        private Infragistics.Win.Misc.UltraLabel UOEOrderUrl_Label;
        private TEdit UOELoginUrl_tEdit;
        private Infragistics.Win.Misc.UltraLabel UOELoginUrl_Label;
        private TEdit AnswerSaveFolder_tEdit;
        private Infragistics.Win.Misc.UltraLabel AnswerSaveFolder_Label;
        private Infragistics.Win.Misc.UltraLabel InqOrdDivCd_Label;
        private TComboEditor InqOrdDivCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel LoginTimeoutVal_Label1;
        private TNedit LoginTimeoutVal_tNedit;
        private Infragistics.Win.Misc.UltraButton uButton_AnswerSaveFolder;
        private Infragistics.Win.Misc.UltraLabel LoginTimeoutVal_Label2;
        private TEdit EPartsPassWord_tEdit;
        private Infragistics.Win.Misc.UltraLabel EPartsPassWord_Label;
        private TEdit EPartsUserId_tEdit;
        private Infragistics.Win.Misc.UltraLabel EPartsUserId_Label;
        private TEdit UOEePartsItemCd_tEdit;
        private Infragistics.Win.Misc.UltraLabel UOEePartsItemCd_Label;
        private TNedit EnableOdrMakerCd6_tNedit;
        private TNedit EnableOdrMakerCd5_tNedit;
        private TNedit EnableOdrMakerCd4_tNedit;
        private Infragistics.Win.Misc.UltraButton uButton_EnableOdrMaker6Guide;
        private Infragistics.Win.Misc.UltraButton uButton_EnableOdrMaker5Guide;
        private Infragistics.Win.Misc.UltraButton uButton_EnableOdrMaker4Guide;
        private Infragistics.Win.Misc.UltraButton uButton_EnableOdrMaker3Guide;
        private Infragistics.Win.Misc.UltraButton uButton_EnableOdrMaker2Guide;
        private Infragistics.Win.Misc.UltraButton uButton_EnableOdrMaker1Guide;
        private TNedit EnableOdrMakerCd3_tNedit;
        private TNedit EnableOdrMakerCd2_tNedit;
        private TNedit EnableOdrMakerCd1_tNedit;
        private TEdit EnableOdrMakerNm6_tEdit;
        private TEdit EnableOdrMakerNm5_tEdit;
        private TEdit EnableOdrMakerNm4_tEdit;
        private TEdit EnableOdrMakerNm3_tEdit;
        private TEdit EnableOdrMakerNm2_tEdit;
        private TEdit EnableOdrMakerNm1_tEdit;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl4;
        private Infragistics.Win.Misc.UltraButton uButton_AnswerSaveFolderOfTOYOTA;
        private TEdit AnswerSaveFolderOfTOYOTA_tEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl5;
        private Infragistics.Win.Misc.UltraButton uButton_NissanAnswerSaveFolder;
        private TEdit NissanAnswerSaveFolder_tEdit;
        private Infragistics.Win.Misc.UltraLabel Nissan_ultraLabel;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl6;
		private TEdit MitsubishiAnswerSaveFolder_tEdit;
		private Infragistics.Win.Misc.UltraLabel Mitsubishi_ultraLabel;
		private Infragistics.Win.Misc.UltraButton uButton_MitsubishiAnswerSaveFolder;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl7;
        private TEdit MeiJiUoeEigyousyoCode_tEdit;
        private Infragistics.Win.Misc.UltraLabel MeiJiUoeEigyousyoCode_Label;
        private TEdit MeiJiUoeSystemUseType_tEdit;
        private Infragistics.Win.Misc.UltraLabel MeiJiUoeSystemUseType_Label;
        private TEdit MeiJiUoePassword_tEdit;
        private Infragistics.Win.Misc.UltraLabel MeiJiUoePassword_Label;
        private TEdit MeiJiUoeTerminalID_tEdit;
        private Infragistics.Win.Misc.UltraLabel MeiJiUoeTerminalID_Label;
        private TEdit MeiJiUoeCoCode_tEdit;
        private Infragistics.Win.Misc.UltraLabel MeiJiUoeCoCode_Label;
        private TEdit MeiJiUoeJigyousyoCode_tEdit;
        private Infragistics.Win.Misc.UltraLabel MeiJiUoeJigyousyoCode_Label;
        private TEdit MeiJiUoeEigyousyoFlag_tEdit;
        private Infragistics.Win.Misc.UltraLabel MeiJiUoeEigyousyoFlag_Label;
        private TComboEditor AnswerAutoDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel AnswerAutoDiv_ultraLabel;
        private TEdit WebPassword_tEdit;
        private Infragistics.Win.Misc.UltraLabel WebPassword_ultraLabel;
        private TEdit WebConnectCode_tEdit;
        private Infragistics.Win.Misc.UltraLabel WebConnectCode_ultraLabel;
        private TEdit WebUserID_tEdit;
        private Infragistics.Win.Misc.UltraLabel WebUserID_ultraLabel;
        private Infragistics.Win.Misc.UltraLabel Nissan_AnswerAutoDiv_ultraLabel;
        private TComboEditor Nissan_AnswerAutoDiv_tComboEditor;
        private TEdit tEdit_MazdaSectionCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_MazdaSectionCode;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_HondaSectionCode;
        private Infragistics.Win.Misc.UltraButton uButton_MazdaAnswerSaveFolder;
        private TEdit MazdaAnswerSaveFolder_tEdit;
        private Infragistics.Win.Misc.UltraLabel Mazda_ultraLabel;
        private TEdit tEdit_HondaSectionCode;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl9;
        private TEdit OrderAddress_tEdit;
        private TEdit Domain_tEdit;
        private TComboEditor Connection_tComboEditor;
        private TComboEditor Protocol_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel CarMaker_uLabel;
        private Infragistics.Win.Misc.UltraLabel Connection_uLabel;
        private Infragistics.Win.Misc.UltraLabel TimeOut_uLabel;
        private Infragistics.Win.Misc.UltraLabel PurchaseAddress_uLabel;
        private Infragistics.Win.Misc.UltraLabel RestoreAddress_uLabel;
        private Infragistics.Win.Misc.UltraLabel OrderAddress_uLabel;
        private Infragistics.Win.Misc.UltraLabel Domain_uLabel;
        private Infragistics.Win.Misc.UltraLabel Protocol_uLabel;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private TEdit TimeOut_tEdit;
        private TEdit PurchaseAddress_tEdit;
        private TEdit RestoreAddress_tEdit;
        private Infragistics.Win.Misc.UltraButton CarMaker_uButton;
        private TEdit BLMngUserCode_tEdit;
        private Infragistics.Win.Misc.UltraLabel BLMngUserCode_uLabel;
        private TComboEditor MakerCd6_tComboEditor;
        private TComboEditor MakerCd5_tComboEditor;
        private TComboEditor MakerCd4_tComboEditor;
        private TComboEditor MakerCd3_tComboEditor;
        private TComboEditor MakerCd2_tComboEditor;
        private TComboEditor MakerCd1_tComboEditor;

        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;

        #endregion

        #region ※Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance161 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance162 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance285 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance286 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance287 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance288 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance289 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance290 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance276 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance277 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance278 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance279 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance280 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance281 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance282 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance283 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance284 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance142 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance144 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance145 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance146 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance147 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance200 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance181 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance182 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance140 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance198 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance199 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance188 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance189 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance190 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance185 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance186 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance187 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance184 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance201 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance183 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance168 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance169 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance170 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance191 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance192 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance193 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance202 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance203 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance204 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance226 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance233 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance230 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance225 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance232 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance229 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance224 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance231 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance228 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance236 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance237 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance238 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance227 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance239 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance240 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance241 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance242 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance175 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance176 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance235 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance243 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance244 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance245 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance246 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance155 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance156 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance174 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance148 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance205 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance206 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance207 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance208 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance209 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance210 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance211 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance212 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance213 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance214 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance215 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance216 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance217 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance218 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance219 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance220 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance221 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance177 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance222 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance223 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance258 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance269 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance270 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance271 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance257 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance268 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance256 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance267 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance249 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance266 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance234 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance265 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance263 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance264 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance261 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance262 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance260 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance259 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance255 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance272 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance254 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance253 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance252 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance251 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance250 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance196 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance143 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance163 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance164 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance153 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance154 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance247 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance248 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance180 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance273 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance274 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance275 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance165 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance166 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance167 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance178 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance179 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance158 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance159 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance160 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance171 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance172 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance152 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance149 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance150 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance151 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance173 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance157 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance194 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance195 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance197 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab5 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab6 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab7 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab8 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab9 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMUOE09020UA));
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.MakerCd6_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MakerCd5_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MakerCd4_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MakerCd3_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MakerCd2_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MakerCd1_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.EnableOdrMakerCd6_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.EnableOdrMakerCd5_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.EnableOdrMakerCd4_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_EnableOdrMaker6Guide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_EnableOdrMaker5Guide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_EnableOdrMaker4Guide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_EnableOdrMaker3Guide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_EnableOdrMaker2Guide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_EnableOdrMaker1Guide = new Infragistics.Win.Misc.UltraButton();
            this.EnableOdrMakerCd3_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.EnableOdrMakerCd2_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.EnableOdrMakerCd1_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.EnableOdrMakerNm6_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EnableOdrMakerNm5_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EnableOdrMakerNm4_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EnableOdrMakerNm3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EnableOdrMakerNm2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EnableOdrMakerNm1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.HondaSectionCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEItemCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOETestMode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.instrumentNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.instrumentNo_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.HondaSectionCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEItemCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOETestMode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraGroupBox4 = new Infragistics.Win.Misc.UltraGroupBox();
            this.MazdaSectionCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MazdaSectionCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraGroupBox5 = new Infragistics.Win.Misc.UltraGroupBox();
            this.EmergencyDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EmergencyDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.EPartsPassWord_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EPartsPassWord_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EPartsUserId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EPartsUserId_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEePartsItemCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEePartsItemCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.LoginTimeoutVal_Label2 = new Infragistics.Win.Misc.UltraLabel();
            this.LoginTimeoutVal_Label1 = new Infragistics.Win.Misc.UltraLabel();
            this.LoginTimeoutVal_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_AnswerSaveFolder = new Infragistics.Win.Misc.UltraButton();
            this.InqOrdDivCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.InqOrdDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.UOEForcedTermUrl_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEForcedTermUrl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEStockCheckUrl_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEStockCheckUrl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEOrderUrl_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEOrderUrl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOELoginUrl_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOELoginUrl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AnswerSaveFolder_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.AnswerSaveFolder_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.WebConnectCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.WebConnectCode_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.WebUserID_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.WebUserID_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.WebPassword_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.WebPassword_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.AnswerAutoDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AnswerAutoDiv_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_AnswerSaveFolderOfTOYOTA = new Infragistics.Win.Misc.UltraButton();
            this.AnswerSaveFolderOfTOYOTA_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl5 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.tEdit_MazdaSectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel_MazdaSectionCode = new Infragistics.Win.Misc.UltraLabel();
            this.Nissan_AnswerAutoDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Nissan_AnswerAutoDiv_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_NissanAnswerSaveFolder = new Infragistics.Win.Misc.UltraButton();
            this.NissanAnswerSaveFolder_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Nissan_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl6 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.uButton_MitsubishiAnswerSaveFolder = new Infragistics.Win.Misc.UltraButton();
            this.MitsubishiAnswerSaveFolder_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Mitsubishi_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl7 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.MeiJiUoeSystemUseType_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MeiJiUoeSystemUseType_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MeiJiUoePassword_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MeiJiUoePassword_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MeiJiUoeTerminalID_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MeiJiUoeTerminalID_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MeiJiUoeCoCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MeiJiUoeCoCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MeiJiUoeJigyousyoCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MeiJiUoeJigyousyoCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MeiJiUoeEigyousyoFlag_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MeiJiUoeEigyousyoFlag_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MeiJiUoeEigyousyoCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MeiJiUoeEigyousyoCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl8 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.tEdit_HondaSectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel_HondaSectionCode = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_MazdaAnswerSaveFolder = new Infragistics.Win.Misc.UltraButton();
            this.MazdaAnswerSaveFolder_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Mazda_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl9 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.CarMaker_uButton = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.BLMngUserCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TimeOut_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PurchaseAddress_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.RestoreAddress_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.OrderAddress_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Domain_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Connection_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Protocol_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.CarMaker_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Connection_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BLMngUserCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.TimeOut_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.PurchaseAddress_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.RestoreAddress_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.OrderAddress_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Domain_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Protocol_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOESupplierCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOESupplierName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GoodsMakerCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.TelNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOETerminalCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEHostCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEConnectPassword_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEConnectUserId_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEIDNum_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CommAssemblyId_Label = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsMakerNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TelNo_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOESupplierCd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_GoodsMakerCdAllowZero = new Broadleaf.Library.Windows.Forms.TNedit();
            this.UOETerminalCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEHostCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEConnectPassword_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEConnectUserId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEIDNum_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CommAssemblyId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ConnectVersionDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ConnectVersionDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.UOEShipSectCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOESalSectCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEReservSectCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ReceiveCondition_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SubstPartsNoDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PartsNoPrtCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ListPriceUseDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.StockSlipDtRecvDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CheckCodeDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOEShipSectCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEShipSectNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOESalSectCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOESalSectNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEReservSectCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEReservSectNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UOEOrderRate_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BoCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DeliveredGoodsDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EmployeeCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_EmployeeGuide = new Infragistics.Win.Misc.UltraButton();
            this.UOEResvdSection_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BusinessCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BoCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DeliveredGoodsDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.UOEResvdSection_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.BusinessCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tEdit_EmployeeCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UOEOrderRate_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_EmployeeName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ReceiveCondition_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.SubstPartsNoDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PartsNoPrtCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ListPriceUseDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.StockSlipDtRecvDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.CheckCodeDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel33 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_UOESupplierGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_UOEShipSectGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_UOESalSectGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_UOEReservSectGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_MakerGuide = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.SupplierCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_SupplierGuide = new Infragistics.Win.Misc.UltraButton();
            this.SupplierNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Maker_ultraTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.Mazda_AnswerAutoDiv_ultraLabel = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd6_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd5_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd4_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd3_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd2_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd1_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd6_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd5_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd4_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd3_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd2_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd1_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm6_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm5_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm4_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm1_tEdit)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentNo_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HondaSectionCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEItemCd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOETestMode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).BeginInit();
            this.ultraGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MazdaSectionCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).BeginInit();
            this.ultraGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmergencyDiv_tComboEditor)).BeginInit();
            this.ultraTabPageControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EPartsPassWord_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EPartsUserId_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEePartsItemCd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginTimeoutVal_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InqOrdDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEForcedTermUrl_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEStockCheckUrl_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEOrderUrl_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOELoginUrl_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSaveFolder_tEdit)).BeginInit();
            this.ultraTabPageControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WebConnectCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebUserID_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebPassword_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerAutoDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSaveFolderOfTOYOTA_tEdit)).BeginInit();
            this.ultraTabPageControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MazdaSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nissan_AnswerAutoDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NissanAnswerSaveFolder_tEdit)).BeginInit();
            this.ultraTabPageControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MitsubishiAnswerSaveFolder_tEdit)).BeginInit();
            this.ultraTabPageControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeSystemUseType_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoePassword_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeTerminalID_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeCoCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeJigyousyoCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeEigyousyoFlag_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeEigyousyoCode_tEdit)).BeginInit();
            this.ultraTabPageControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_HondaSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MazdaAnswerSaveFolder_tEdit)).BeginInit();
            this.ultraTabPageControl9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BLMngUserCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeOut_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseAddress_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RestoreAddress_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderAddress_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Domain_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Connection_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Protocol_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TelNo_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierCd_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCdAllowZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOETerminalCd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEHostCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEConnectPassword_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEConnectUserId_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEIDNum_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommAssemblyId_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectVersionDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEShipSectCd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEShipSectNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalSectCd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalSectNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEReservSectCd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEReservSectNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveredGoodsDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEResvdSection_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEOrderRate_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveCondition_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubstPartsNoDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsNoPrtCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPriceUseDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSlipDtRecvDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckCodeDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maker_ultraTabControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mazda_AnswerAutoDiv_ultraLabel)).BeginInit();
            this.Mazda_AnswerAutoDiv_ultraLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.MakerCd6_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.MakerCd5_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.MakerCd4_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.MakerCd3_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.MakerCd2_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.MakerCd1_tComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerCd6_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerCd5_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerCd4_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.uButton_EnableOdrMaker6Guide);
            this.ultraTabPageControl1.Controls.Add(this.uButton_EnableOdrMaker5Guide);
            this.ultraTabPageControl1.Controls.Add(this.uButton_EnableOdrMaker4Guide);
            this.ultraTabPageControl1.Controls.Add(this.uButton_EnableOdrMaker3Guide);
            this.ultraTabPageControl1.Controls.Add(this.uButton_EnableOdrMaker2Guide);
            this.ultraTabPageControl1.Controls.Add(this.uButton_EnableOdrMaker1Guide);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerCd3_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerCd2_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerCd1_tNedit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerNm6_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerNm5_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerNm4_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerNm3_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerNm2_tEdit);
            this.ultraTabPageControl1.Controls.Add(this.EnableOdrMakerNm1_tEdit);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 21);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(938, 195);
            // 
            // MakerCd6_tComboEditor
            // 
            appearance124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance124.ForeColor = System.Drawing.Color.Black;
            appearance124.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd6_tComboEditor.ActiveAppearance = appearance124;
            appearance161.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance161.ForeColor = System.Drawing.Color.Black;
            appearance161.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd6_tComboEditor.Appearance = appearance161;
            this.MakerCd6_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MakerCd6_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance162.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerCd6_tComboEditor.ItemAppearance = appearance162;
            this.MakerCd6_tComboEditor.Location = new System.Drawing.Point(283, 163);
            this.MakerCd6_tComboEditor.MaxDropDownItems = 18;
            this.MakerCd6_tComboEditor.Name = "MakerCd6_tComboEditor";
            this.MakerCd6_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.MakerCd6_tComboEditor.TabIndex = 46;
            this.MakerCd6_tComboEditor.Visible = false;
            // 
            // MakerCd5_tComboEditor
            // 
            appearance285.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance285.ForeColor = System.Drawing.Color.Black;
            appearance285.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd5_tComboEditor.ActiveAppearance = appearance285;
            appearance286.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance286.ForeColor = System.Drawing.Color.Black;
            appearance286.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd5_tComboEditor.Appearance = appearance286;
            this.MakerCd5_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MakerCd5_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance287.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerCd5_tComboEditor.ItemAppearance = appearance287;
            this.MakerCd5_tComboEditor.Location = new System.Drawing.Point(283, 133);
            this.MakerCd5_tComboEditor.MaxDropDownItems = 18;
            this.MakerCd5_tComboEditor.Name = "MakerCd5_tComboEditor";
            this.MakerCd5_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.MakerCd5_tComboEditor.TabIndex = 43;
            this.MakerCd5_tComboEditor.Visible = false;
            // 
            // MakerCd4_tComboEditor
            // 
            appearance288.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance288.ForeColor = System.Drawing.Color.Black;
            appearance288.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd4_tComboEditor.ActiveAppearance = appearance288;
            appearance289.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance289.ForeColor = System.Drawing.Color.Black;
            appearance289.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd4_tComboEditor.Appearance = appearance289;
            this.MakerCd4_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MakerCd4_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance290.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerCd4_tComboEditor.ItemAppearance = appearance290;
            this.MakerCd4_tComboEditor.Location = new System.Drawing.Point(283, 103);
            this.MakerCd4_tComboEditor.MaxDropDownItems = 18;
            this.MakerCd4_tComboEditor.Name = "MakerCd4_tComboEditor";
            this.MakerCd4_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.MakerCd4_tComboEditor.TabIndex = 40;
            this.MakerCd4_tComboEditor.Visible = false;
            // 
            // MakerCd3_tComboEditor
            // 
            appearance276.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance276.ForeColor = System.Drawing.Color.Black;
            appearance276.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd3_tComboEditor.ActiveAppearance = appearance276;
            appearance277.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance277.ForeColor = System.Drawing.Color.Black;
            appearance277.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd3_tComboEditor.Appearance = appearance277;
            this.MakerCd3_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MakerCd3_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance278.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerCd3_tComboEditor.ItemAppearance = appearance278;
            this.MakerCd3_tComboEditor.Location = new System.Drawing.Point(283, 73);
            this.MakerCd3_tComboEditor.MaxDropDownItems = 18;
            this.MakerCd3_tComboEditor.Name = "MakerCd3_tComboEditor";
            this.MakerCd3_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.MakerCd3_tComboEditor.TabIndex = 37;
            this.MakerCd3_tComboEditor.Visible = false;
            // 
            // MakerCd2_tComboEditor
            // 
            appearance279.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance279.ForeColor = System.Drawing.Color.Black;
            appearance279.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd2_tComboEditor.ActiveAppearance = appearance279;
            appearance280.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance280.ForeColor = System.Drawing.Color.Black;
            appearance280.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd2_tComboEditor.Appearance = appearance280;
            this.MakerCd2_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MakerCd2_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance281.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerCd2_tComboEditor.ItemAppearance = appearance281;
            this.MakerCd2_tComboEditor.Location = new System.Drawing.Point(283, 43);
            this.MakerCd2_tComboEditor.MaxDropDownItems = 18;
            this.MakerCd2_tComboEditor.Name = "MakerCd2_tComboEditor";
            this.MakerCd2_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.MakerCd2_tComboEditor.TabIndex = 34;
            this.MakerCd2_tComboEditor.Visible = false;
            // 
            // MakerCd1_tComboEditor
            // 
            appearance282.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance282.ForeColor = System.Drawing.Color.Black;
            appearance282.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd1_tComboEditor.ActiveAppearance = appearance282;
            appearance283.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance283.ForeColor = System.Drawing.Color.Black;
            appearance283.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerCd1_tComboEditor.Appearance = appearance283;
            this.MakerCd1_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MakerCd1_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance284.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerCd1_tComboEditor.ItemAppearance = appearance284;
            this.MakerCd1_tComboEditor.Location = new System.Drawing.Point(283, 13);
            this.MakerCd1_tComboEditor.MaxDropDownItems = 18;
            this.MakerCd1_tComboEditor.Name = "MakerCd1_tComboEditor";
            this.MakerCd1_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.MakerCd1_tComboEditor.TabIndex = 31;
            this.MakerCd1_tComboEditor.Visible = false;
            // 
            // EnableOdrMakerCd6_tNedit
            // 
            appearance72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance72.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd6_tNedit.ActiveAppearance = appearance72;
            appearance92.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance92.ForeColorDisabled = System.Drawing.Color.Black;
            appearance92.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd6_tNedit.Appearance = appearance92;
            this.EnableOdrMakerCd6_tNedit.AutoSelect = true;
            this.EnableOdrMakerCd6_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.EnableOdrMakerCd6_tNedit.DataText = "";
            this.EnableOdrMakerCd6_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerCd6_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.EnableOdrMakerCd6_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.EnableOdrMakerCd6_tNedit.Location = new System.Drawing.Point(26, 163);
            this.EnableOdrMakerCd6_tNedit.MaxLength = 4;
            this.EnableOdrMakerCd6_tNedit.Name = "EnableOdrMakerCd6_tNedit";
            this.EnableOdrMakerCd6_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.EnableOdrMakerCd6_tNedit.Size = new System.Drawing.Size(43, 24);
            this.EnableOdrMakerCd6_tNedit.TabIndex = 44;
            // 
            // EnableOdrMakerCd5_tNedit
            // 
            appearance130.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance130.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd5_tNedit.ActiveAppearance = appearance130;
            appearance91.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance91.ForeColorDisabled = System.Drawing.Color.Black;
            appearance91.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd5_tNedit.Appearance = appearance91;
            this.EnableOdrMakerCd5_tNedit.AutoSelect = true;
            this.EnableOdrMakerCd5_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.EnableOdrMakerCd5_tNedit.DataText = "";
            this.EnableOdrMakerCd5_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerCd5_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.EnableOdrMakerCd5_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.EnableOdrMakerCd5_tNedit.Location = new System.Drawing.Point(26, 133);
            this.EnableOdrMakerCd5_tNedit.MaxLength = 4;
            this.EnableOdrMakerCd5_tNedit.Name = "EnableOdrMakerCd5_tNedit";
            this.EnableOdrMakerCd5_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.EnableOdrMakerCd5_tNedit.Size = new System.Drawing.Size(43, 24);
            this.EnableOdrMakerCd5_tNedit.TabIndex = 41;
            // 
            // EnableOdrMakerCd4_tNedit
            // 
            appearance131.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance131.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd4_tNedit.ActiveAppearance = appearance131;
            appearance90.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance90.ForeColorDisabled = System.Drawing.Color.Black;
            appearance90.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd4_tNedit.Appearance = appearance90;
            this.EnableOdrMakerCd4_tNedit.AutoSelect = true;
            this.EnableOdrMakerCd4_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.EnableOdrMakerCd4_tNedit.DataText = "";
            this.EnableOdrMakerCd4_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerCd4_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.EnableOdrMakerCd4_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.EnableOdrMakerCd4_tNedit.Location = new System.Drawing.Point(26, 103);
            this.EnableOdrMakerCd4_tNedit.MaxLength = 4;
            this.EnableOdrMakerCd4_tNedit.Name = "EnableOdrMakerCd4_tNedit";
            this.EnableOdrMakerCd4_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.EnableOdrMakerCd4_tNedit.Size = new System.Drawing.Size(43, 24);
            this.EnableOdrMakerCd4_tNedit.TabIndex = 38;
            // 
            // uButton_EnableOdrMaker6Guide
            // 
            appearance142.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance142.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EnableOdrMaker6Guide.Appearance = appearance142;
            this.uButton_EnableOdrMaker6Guide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EnableOdrMaker6Guide.Location = new System.Drawing.Point(228, 163);
            this.uButton_EnableOdrMaker6Guide.Name = "uButton_EnableOdrMaker6Guide";
            this.uButton_EnableOdrMaker6Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EnableOdrMaker6Guide.TabIndex = 45;
            this.uButton_EnableOdrMaker6Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EnableOdrMaker6Guide.Click += new System.EventHandler(this.uButton_EnableOdrMaker6Guide_Click);
            // 
            // uButton_EnableOdrMaker5Guide
            // 
            appearance144.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance144.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EnableOdrMaker5Guide.Appearance = appearance144;
            this.uButton_EnableOdrMaker5Guide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EnableOdrMaker5Guide.Location = new System.Drawing.Point(228, 133);
            this.uButton_EnableOdrMaker5Guide.Name = "uButton_EnableOdrMaker5Guide";
            this.uButton_EnableOdrMaker5Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EnableOdrMaker5Guide.TabIndex = 42;
            this.uButton_EnableOdrMaker5Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EnableOdrMaker5Guide.Click += new System.EventHandler(this.uButton_EnableOdrMaker5Guide_Click);
            // 
            // uButton_EnableOdrMaker4Guide
            // 
            appearance145.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance145.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EnableOdrMaker4Guide.Appearance = appearance145;
            this.uButton_EnableOdrMaker4Guide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EnableOdrMaker4Guide.Location = new System.Drawing.Point(228, 103);
            this.uButton_EnableOdrMaker4Guide.Name = "uButton_EnableOdrMaker4Guide";
            this.uButton_EnableOdrMaker4Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EnableOdrMaker4Guide.TabIndex = 39;
            this.uButton_EnableOdrMaker4Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EnableOdrMaker4Guide.Click += new System.EventHandler(this.uButton_EnableOdrMaker4Guide_Click);
            // 
            // uButton_EnableOdrMaker3Guide
            // 
            appearance146.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance146.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EnableOdrMaker3Guide.Appearance = appearance146;
            this.uButton_EnableOdrMaker3Guide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EnableOdrMaker3Guide.Location = new System.Drawing.Point(228, 73);
            this.uButton_EnableOdrMaker3Guide.Name = "uButton_EnableOdrMaker3Guide";
            this.uButton_EnableOdrMaker3Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EnableOdrMaker3Guide.TabIndex = 36;
            this.uButton_EnableOdrMaker3Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EnableOdrMaker3Guide.Click += new System.EventHandler(this.uButton_EnableOdrMaker3Guide_Click);
            // 
            // uButton_EnableOdrMaker2Guide
            // 
            appearance147.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance147.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EnableOdrMaker2Guide.Appearance = appearance147;
            this.uButton_EnableOdrMaker2Guide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EnableOdrMaker2Guide.Location = new System.Drawing.Point(228, 43);
            this.uButton_EnableOdrMaker2Guide.Name = "uButton_EnableOdrMaker2Guide";
            this.uButton_EnableOdrMaker2Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EnableOdrMaker2Guide.TabIndex = 33;
            this.uButton_EnableOdrMaker2Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EnableOdrMaker2Guide.Click += new System.EventHandler(this.uButton_EnableOdrMaker2Guide_Click);
            // 
            // uButton_EnableOdrMaker1Guide
            // 
            appearance200.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance200.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EnableOdrMaker1Guide.Appearance = appearance200;
            this.uButton_EnableOdrMaker1Guide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EnableOdrMaker1Guide.Location = new System.Drawing.Point(228, 13);
            this.uButton_EnableOdrMaker1Guide.Name = "uButton_EnableOdrMaker1Guide";
            this.uButton_EnableOdrMaker1Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EnableOdrMaker1Guide.TabIndex = 30;
            this.uButton_EnableOdrMaker1Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EnableOdrMaker1Guide.Click += new System.EventHandler(this.uButton_EnableOdrMaker1Guide_Click);
            // 
            // EnableOdrMakerCd3_tNedit
            // 
            appearance132.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance132.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd3_tNedit.ActiveAppearance = appearance132;
            appearance89.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance89.ForeColorDisabled = System.Drawing.Color.Black;
            appearance89.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd3_tNedit.Appearance = appearance89;
            this.EnableOdrMakerCd3_tNedit.AutoSelect = true;
            this.EnableOdrMakerCd3_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.EnableOdrMakerCd3_tNedit.DataText = "";
            this.EnableOdrMakerCd3_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerCd3_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.EnableOdrMakerCd3_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.EnableOdrMakerCd3_tNedit.Location = new System.Drawing.Point(26, 73);
            this.EnableOdrMakerCd3_tNedit.MaxLength = 4;
            this.EnableOdrMakerCd3_tNedit.Name = "EnableOdrMakerCd3_tNedit";
            this.EnableOdrMakerCd3_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.EnableOdrMakerCd3_tNedit.Size = new System.Drawing.Size(43, 24);
            this.EnableOdrMakerCd3_tNedit.TabIndex = 35;
            // 
            // EnableOdrMakerCd2_tNedit
            // 
            appearance133.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance133.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd2_tNedit.ActiveAppearance = appearance133;
            appearance88.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance88.ForeColorDisabled = System.Drawing.Color.Black;
            appearance88.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd2_tNedit.Appearance = appearance88;
            this.EnableOdrMakerCd2_tNedit.AutoSelect = true;
            this.EnableOdrMakerCd2_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.EnableOdrMakerCd2_tNedit.DataText = "";
            this.EnableOdrMakerCd2_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerCd2_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.EnableOdrMakerCd2_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.EnableOdrMakerCd2_tNedit.Location = new System.Drawing.Point(26, 43);
            this.EnableOdrMakerCd2_tNedit.MaxLength = 4;
            this.EnableOdrMakerCd2_tNedit.Name = "EnableOdrMakerCd2_tNedit";
            this.EnableOdrMakerCd2_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.EnableOdrMakerCd2_tNedit.Size = new System.Drawing.Size(43, 24);
            this.EnableOdrMakerCd2_tNedit.TabIndex = 32;
            // 
            // EnableOdrMakerCd1_tNedit
            // 
            appearance181.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance181.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd1_tNedit.ActiveAppearance = appearance181;
            appearance182.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance182.ForeColorDisabled = System.Drawing.Color.Black;
            appearance182.TextHAlignAsString = "Right";
            this.EnableOdrMakerCd1_tNedit.Appearance = appearance182;
            this.EnableOdrMakerCd1_tNedit.AutoSelect = true;
            this.EnableOdrMakerCd1_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.EnableOdrMakerCd1_tNedit.DataText = "";
            this.EnableOdrMakerCd1_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerCd1_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.EnableOdrMakerCd1_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.EnableOdrMakerCd1_tNedit.Location = new System.Drawing.Point(26, 13);
            this.EnableOdrMakerCd1_tNedit.MaxLength = 4;
            this.EnableOdrMakerCd1_tNedit.Name = "EnableOdrMakerCd1_tNedit";
            this.EnableOdrMakerCd1_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.EnableOdrMakerCd1_tNedit.Size = new System.Drawing.Size(43, 24);
            this.EnableOdrMakerCd1_tNedit.TabIndex = 29;
            // 
            // EnableOdrMakerNm6_tEdit
            // 
            this.EnableOdrMakerNm6_tEdit.ActiveAppearance = appearance35;
            appearance140.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance140.ForeColorDisabled = System.Drawing.Color.Black;
            this.EnableOdrMakerNm6_tEdit.Appearance = appearance140;
            this.EnableOdrMakerNm6_tEdit.AutoSelect = true;
            this.EnableOdrMakerNm6_tEdit.DataText = "";
            this.EnableOdrMakerNm6_tEdit.Enabled = false;
            this.EnableOdrMakerNm6_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerNm6_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EnableOdrMakerNm6_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EnableOdrMakerNm6_tEdit.Location = new System.Drawing.Point(75, 163);
            this.EnableOdrMakerNm6_tEdit.MaxLength = 30;
            this.EnableOdrMakerNm6_tEdit.Name = "EnableOdrMakerNm6_tEdit";
            this.EnableOdrMakerNm6_tEdit.Size = new System.Drawing.Size(144, 24);
            this.EnableOdrMakerNm6_tEdit.TabIndex = 48;
            this.EnableOdrMakerNm6_tEdit.TabStop = false;
            // 
            // EnableOdrMakerNm5_tEdit
            // 
            this.EnableOdrMakerNm5_tEdit.ActiveAppearance = appearance109;
            appearance139.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance139.ForeColorDisabled = System.Drawing.Color.Black;
            this.EnableOdrMakerNm5_tEdit.Appearance = appearance139;
            this.EnableOdrMakerNm5_tEdit.AutoSelect = true;
            this.EnableOdrMakerNm5_tEdit.DataText = "";
            this.EnableOdrMakerNm5_tEdit.Enabled = false;
            this.EnableOdrMakerNm5_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerNm5_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EnableOdrMakerNm5_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EnableOdrMakerNm5_tEdit.Location = new System.Drawing.Point(75, 133);
            this.EnableOdrMakerNm5_tEdit.MaxLength = 30;
            this.EnableOdrMakerNm5_tEdit.Name = "EnableOdrMakerNm5_tEdit";
            this.EnableOdrMakerNm5_tEdit.Size = new System.Drawing.Size(144, 24);
            this.EnableOdrMakerNm5_tEdit.TabIndex = 49;
            this.EnableOdrMakerNm5_tEdit.TabStop = false;
            // 
            // EnableOdrMakerNm4_tEdit
            // 
            this.EnableOdrMakerNm4_tEdit.ActiveAppearance = appearance106;
            appearance138.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance138.ForeColorDisabled = System.Drawing.Color.Black;
            this.EnableOdrMakerNm4_tEdit.Appearance = appearance138;
            this.EnableOdrMakerNm4_tEdit.AutoSelect = true;
            this.EnableOdrMakerNm4_tEdit.DataText = "";
            this.EnableOdrMakerNm4_tEdit.Enabled = false;
            this.EnableOdrMakerNm4_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerNm4_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EnableOdrMakerNm4_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EnableOdrMakerNm4_tEdit.Location = new System.Drawing.Point(75, 103);
            this.EnableOdrMakerNm4_tEdit.MaxLength = 30;
            this.EnableOdrMakerNm4_tEdit.Name = "EnableOdrMakerNm4_tEdit";
            this.EnableOdrMakerNm4_tEdit.Size = new System.Drawing.Size(144, 24);
            this.EnableOdrMakerNm4_tEdit.TabIndex = 50;
            this.EnableOdrMakerNm4_tEdit.TabStop = false;
            // 
            // EnableOdrMakerNm3_tEdit
            // 
            this.EnableOdrMakerNm3_tEdit.ActiveAppearance = appearance108;
            appearance137.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance137.ForeColorDisabled = System.Drawing.Color.Black;
            this.EnableOdrMakerNm3_tEdit.Appearance = appearance137;
            this.EnableOdrMakerNm3_tEdit.AutoSelect = true;
            this.EnableOdrMakerNm3_tEdit.DataText = "";
            this.EnableOdrMakerNm3_tEdit.Enabled = false;
            this.EnableOdrMakerNm3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerNm3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EnableOdrMakerNm3_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EnableOdrMakerNm3_tEdit.Location = new System.Drawing.Point(75, 73);
            this.EnableOdrMakerNm3_tEdit.MaxLength = 30;
            this.EnableOdrMakerNm3_tEdit.Name = "EnableOdrMakerNm3_tEdit";
            this.EnableOdrMakerNm3_tEdit.Size = new System.Drawing.Size(144, 24);
            this.EnableOdrMakerNm3_tEdit.TabIndex = 45;
            this.EnableOdrMakerNm3_tEdit.TabStop = false;
            // 
            // EnableOdrMakerNm2_tEdit
            // 
            this.EnableOdrMakerNm2_tEdit.ActiveAppearance = appearance107;
            appearance136.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance136.ForeColorDisabled = System.Drawing.Color.Black;
            this.EnableOdrMakerNm2_tEdit.Appearance = appearance136;
            this.EnableOdrMakerNm2_tEdit.AutoSelect = true;
            this.EnableOdrMakerNm2_tEdit.DataText = "";
            this.EnableOdrMakerNm2_tEdit.Enabled = false;
            this.EnableOdrMakerNm2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerNm2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EnableOdrMakerNm2_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EnableOdrMakerNm2_tEdit.Location = new System.Drawing.Point(75, 43);
            this.EnableOdrMakerNm2_tEdit.MaxLength = 30;
            this.EnableOdrMakerNm2_tEdit.Name = "EnableOdrMakerNm2_tEdit";
            this.EnableOdrMakerNm2_tEdit.Size = new System.Drawing.Size(144, 24);
            this.EnableOdrMakerNm2_tEdit.TabIndex = 46;
            this.EnableOdrMakerNm2_tEdit.TabStop = false;
            // 
            // EnableOdrMakerNm1_tEdit
            // 
            this.EnableOdrMakerNm1_tEdit.ActiveAppearance = appearance198;
            appearance199.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance199.ForeColorDisabled = System.Drawing.Color.Black;
            this.EnableOdrMakerNm1_tEdit.Appearance = appearance199;
            this.EnableOdrMakerNm1_tEdit.AutoSelect = true;
            this.EnableOdrMakerNm1_tEdit.DataText = "";
            this.EnableOdrMakerNm1_tEdit.Enabled = false;
            this.EnableOdrMakerNm1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EnableOdrMakerNm1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EnableOdrMakerNm1_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EnableOdrMakerNm1_tEdit.Location = new System.Drawing.Point(75, 13);
            this.EnableOdrMakerNm1_tEdit.MaxLength = 30;
            this.EnableOdrMakerNm1_tEdit.Name = "EnableOdrMakerNm1_tEdit";
            this.EnableOdrMakerNm1_tEdit.Size = new System.Drawing.Size(144, 24);
            this.EnableOdrMakerNm1_tEdit.TabIndex = 47;
            this.EnableOdrMakerNm1_tEdit.TabStop = false;
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ultraGroupBox2);
            this.ultraTabPageControl2.Controls.Add(this.ultraGroupBox4);
            this.ultraTabPageControl2.Controls.Add(this.ultraGroupBox5);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(938, 195);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.HondaSectionCode_Label);
            this.ultraGroupBox2.Controls.Add(this.UOEItemCd_Label);
            this.ultraGroupBox2.Controls.Add(this.UOETestMode_Label);
            this.ultraGroupBox2.Controls.Add(this.instrumentNo_Label);
            this.ultraGroupBox2.Controls.Add(this.instrumentNo_tEdit);
            this.ultraGroupBox2.Controls.Add(this.HondaSectionCode_tEdit);
            this.ultraGroupBox2.Controls.Add(this.UOEItemCd_tEdit);
            this.ultraGroupBox2.Controls.Add(this.UOETestMode_tEdit);
            this.ultraGroupBox2.Location = new System.Drawing.Point(614, 3);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(300, 157);
            this.ultraGroupBox2.TabIndex = 43;
            this.ultraGroupBox2.Text = "ホンダ項目";
            // 
            // HondaSectionCode_Label
            // 
            appearance93.TextVAlignAsString = "Middle";
            this.HondaSectionCode_Label.Appearance = appearance93;
            this.HondaSectionCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.HondaSectionCode_Label.Location = new System.Drawing.Point(6, 120);
            this.HondaSectionCode_Label.Name = "HondaSectionCode_Label";
            this.HondaSectionCode_Label.Size = new System.Drawing.Size(105, 23);
            this.HondaSectionCode_Label.TabIndex = 28;
            this.HondaSectionCode_Label.Text = "担当拠点";
            // 
            // UOEItemCd_Label
            // 
            appearance94.TextVAlignAsString = "Middle";
            this.UOEItemCd_Label.Appearance = appearance94;
            this.UOEItemCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEItemCd_Label.Location = new System.Drawing.Point(6, 90);
            this.UOEItemCd_Label.Name = "UOEItemCd_Label";
            this.UOEItemCd_Label.Size = new System.Drawing.Size(105, 23);
            this.UOEItemCd_Label.TabIndex = 28;
            this.UOEItemCd_Label.Text = "アイテム";
            // 
            // UOETestMode_Label
            // 
            appearance95.TextVAlignAsString = "Middle";
            this.UOETestMode_Label.Appearance = appearance95;
            this.UOETestMode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOETestMode_Label.Location = new System.Drawing.Point(6, 60);
            this.UOETestMode_Label.Name = "UOETestMode_Label";
            this.UOETestMode_Label.Size = new System.Drawing.Size(105, 23);
            this.UOETestMode_Label.TabIndex = 28;
            this.UOETestMode_Label.Text = "テストモード";
            // 
            // instrumentNo_Label
            // 
            appearance96.TextVAlignAsString = "Middle";
            this.instrumentNo_Label.Appearance = appearance96;
            this.instrumentNo_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.instrumentNo_Label.Location = new System.Drawing.Point(6, 30);
            this.instrumentNo_Label.Name = "instrumentNo_Label";
            this.instrumentNo_Label.Size = new System.Drawing.Size(105, 23);
            this.instrumentNo_Label.TabIndex = 28;
            this.instrumentNo_Label.Text = "号機";
            // 
            // instrumentNo_tEdit
            // 
            appearance97.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.instrumentNo_tEdit.ActiveAppearance = appearance97;
            appearance81.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance81.ForeColorDisabled = System.Drawing.Color.Black;
            this.instrumentNo_tEdit.Appearance = appearance81;
            this.instrumentNo_tEdit.AutoSelect = true;
            this.instrumentNo_tEdit.DataText = "";
            this.instrumentNo_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.instrumentNo_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.instrumentNo_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.instrumentNo_tEdit.Location = new System.Drawing.Point(117, 30);
            this.instrumentNo_tEdit.MaxLength = 1;
            this.instrumentNo_tEdit.Name = "instrumentNo_tEdit";
            this.instrumentNo_tEdit.Size = new System.Drawing.Size(28, 24);
            this.instrumentNo_tEdit.TabIndex = 1;
            // 
            // HondaSectionCode_tEdit
            // 
            appearance98.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.HondaSectionCode_tEdit.ActiveAppearance = appearance98;
            appearance84.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance84.ForeColorDisabled = System.Drawing.Color.Black;
            this.HondaSectionCode_tEdit.Appearance = appearance84;
            this.HondaSectionCode_tEdit.AutoSelect = true;
            this.HondaSectionCode_tEdit.DataText = "";
            this.HondaSectionCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.HondaSectionCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.HondaSectionCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.HondaSectionCode_tEdit.Location = new System.Drawing.Point(117, 120);
            this.HondaSectionCode_tEdit.MaxLength = 5;
            this.HondaSectionCode_tEdit.Name = "HondaSectionCode_tEdit";
            this.HondaSectionCode_tEdit.Size = new System.Drawing.Size(59, 24);
            this.HondaSectionCode_tEdit.TabIndex = 4;
            // 
            // UOEItemCd_tEdit
            // 
            appearance99.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEItemCd_tEdit.ActiveAppearance = appearance99;
            appearance83.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance83.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEItemCd_tEdit.Appearance = appearance83;
            this.UOEItemCd_tEdit.AutoSelect = true;
            this.UOEItemCd_tEdit.DataText = "";
            this.UOEItemCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEItemCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, true, true, true, true));
            this.UOEItemCd_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEItemCd_tEdit.Location = new System.Drawing.Point(117, 90);
            this.UOEItemCd_tEdit.MaxLength = 5;
            this.UOEItemCd_tEdit.Name = "UOEItemCd_tEdit";
            this.UOEItemCd_tEdit.Size = new System.Drawing.Size(59, 24);
            this.UOEItemCd_tEdit.TabIndex = 3;
            // 
            // UOETestMode_tEdit
            // 
            appearance100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOETestMode_tEdit.ActiveAppearance = appearance100;
            appearance82.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance82.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOETestMode_tEdit.Appearance = appearance82;
            this.UOETestMode_tEdit.AutoSelect = true;
            this.UOETestMode_tEdit.DataText = "";
            this.UOETestMode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOETestMode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOETestMode_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOETestMode_tEdit.Location = new System.Drawing.Point(117, 60);
            this.UOETestMode_tEdit.MaxLength = 1;
            this.UOETestMode_tEdit.Name = "UOETestMode_tEdit";
            this.UOETestMode_tEdit.Size = new System.Drawing.Size(28, 24);
            this.UOETestMode_tEdit.TabIndex = 2;
            // 
            // ultraGroupBox4
            // 
            this.ultraGroupBox4.Controls.Add(this.MazdaSectionCode_Label);
            this.ultraGroupBox4.Controls.Add(this.MazdaSectionCode_tEdit);
            this.ultraGroupBox4.Location = new System.Drawing.Point(308, 3);
            this.ultraGroupBox4.Name = "ultraGroupBox4";
            this.ultraGroupBox4.Size = new System.Drawing.Size(300, 66);
            this.ultraGroupBox4.TabIndex = 42;
            this.ultraGroupBox4.Text = "新マツダ項目";
            // 
            // MazdaSectionCode_Label
            // 
            appearance103.TextVAlignAsString = "Middle";
            this.MazdaSectionCode_Label.Appearance = appearance103;
            this.MazdaSectionCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MazdaSectionCode_Label.Location = new System.Drawing.Point(6, 30);
            this.MazdaSectionCode_Label.Name = "MazdaSectionCode_Label";
            this.MazdaSectionCode_Label.Size = new System.Drawing.Size(84, 23);
            this.MazdaSectionCode_Label.TabIndex = 28;
            this.MazdaSectionCode_Label.Text = "自拠点";
            // 
            // MazdaSectionCode_tEdit
            // 
            appearance104.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MazdaSectionCode_tEdit.ActiveAppearance = appearance104;
            appearance86.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance86.ForeColorDisabled = System.Drawing.Color.Black;
            this.MazdaSectionCode_tEdit.Appearance = appearance86;
            this.MazdaSectionCode_tEdit.AutoSelect = true;
            this.MazdaSectionCode_tEdit.DataText = "";
            this.MazdaSectionCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MazdaSectionCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.MazdaSectionCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MazdaSectionCode_tEdit.Location = new System.Drawing.Point(96, 30);
            this.MazdaSectionCode_tEdit.MaxLength = 3;
            this.MazdaSectionCode_tEdit.Name = "MazdaSectionCode_tEdit";
            this.MazdaSectionCode_tEdit.Size = new System.Drawing.Size(59, 24);
            this.MazdaSectionCode_tEdit.TabIndex = 1;
            // 
            // ultraGroupBox5
            // 
            this.ultraGroupBox5.Controls.Add(this.EmergencyDiv_Label);
            this.ultraGroupBox5.Controls.Add(this.EmergencyDiv_tComboEditor);
            this.ultraGroupBox5.Location = new System.Drawing.Point(3, 3);
            this.ultraGroupBox5.Name = "ultraGroupBox5";
            this.ultraGroupBox5.Size = new System.Drawing.Size(299, 66);
            this.ultraGroupBox5.TabIndex = 41;
            this.ultraGroupBox5.Text = "三菱項目";
            // 
            // EmergencyDiv_Label
            // 
            appearance55.TextVAlignAsString = "Middle";
            this.EmergencyDiv_Label.Appearance = appearance55;
            this.EmergencyDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.EmergencyDiv_Label.Location = new System.Drawing.Point(6, 30);
            this.EmergencyDiv_Label.Name = "EmergencyDiv_Label";
            this.EmergencyDiv_Label.Size = new System.Drawing.Size(84, 23);
            this.EmergencyDiv_Label.TabIndex = 28;
            this.EmergencyDiv_Label.Text = "緊急区分";
            // 
            // EmergencyDiv_tComboEditor
            // 
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance47.ForeColor = System.Drawing.Color.Black;
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            this.EmergencyDiv_tComboEditor.ActiveAppearance = appearance47;
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance48.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance48.ForeColor = System.Drawing.Color.Black;
            appearance48.ForeColorDisabled = System.Drawing.Color.Black;
            this.EmergencyDiv_tComboEditor.Appearance = appearance48;
            this.EmergencyDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.EmergencyDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EmergencyDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EmergencyDiv_tComboEditor.ItemAppearance = appearance49;
            this.EmergencyDiv_tComboEditor.Location = new System.Drawing.Point(96, 30);
            this.EmergencyDiv_tComboEditor.MaxDropDownItems = 18;
            this.EmergencyDiv_tComboEditor.Name = "EmergencyDiv_tComboEditor";
            this.EmergencyDiv_tComboEditor.Size = new System.Drawing.Size(141, 24);
            this.EmergencyDiv_tComboEditor.TabIndex = 1;
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.EPartsPassWord_tEdit);
            this.ultraTabPageControl3.Controls.Add(this.EPartsPassWord_Label);
            this.ultraTabPageControl3.Controls.Add(this.EPartsUserId_tEdit);
            this.ultraTabPageControl3.Controls.Add(this.EPartsUserId_Label);
            this.ultraTabPageControl3.Controls.Add(this.UOEePartsItemCd_tEdit);
            this.ultraTabPageControl3.Controls.Add(this.UOEePartsItemCd_Label);
            this.ultraTabPageControl3.Controls.Add(this.LoginTimeoutVal_Label2);
            this.ultraTabPageControl3.Controls.Add(this.LoginTimeoutVal_Label1);
            this.ultraTabPageControl3.Controls.Add(this.LoginTimeoutVal_tNedit);
            this.ultraTabPageControl3.Controls.Add(this.uButton_AnswerSaveFolder);
            this.ultraTabPageControl3.Controls.Add(this.InqOrdDivCd_Label);
            this.ultraTabPageControl3.Controls.Add(this.InqOrdDivCd_tComboEditor);
            this.ultraTabPageControl3.Controls.Add(this.UOEForcedTermUrl_tEdit);
            this.ultraTabPageControl3.Controls.Add(this.UOEForcedTermUrl_Label);
            this.ultraTabPageControl3.Controls.Add(this.UOEStockCheckUrl_tEdit);
            this.ultraTabPageControl3.Controls.Add(this.UOEStockCheckUrl_Label);
            this.ultraTabPageControl3.Controls.Add(this.UOEOrderUrl_tEdit);
            this.ultraTabPageControl3.Controls.Add(this.UOEOrderUrl_Label);
            this.ultraTabPageControl3.Controls.Add(this.UOELoginUrl_tEdit);
            this.ultraTabPageControl3.Controls.Add(this.UOELoginUrl_Label);
            this.ultraTabPageControl3.Controls.Add(this.AnswerSaveFolder_tEdit);
            this.ultraTabPageControl3.Controls.Add(this.AnswerSaveFolder_Label);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(938, 195);
            // 
            // EPartsPassWord_tEdit
            // 
            appearance76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EPartsPassWord_tEdit.ActiveAppearance = appearance76;
            appearance78.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance78.ForeColorDisabled = System.Drawing.Color.Black;
            this.EPartsPassWord_tEdit.Appearance = appearance78;
            this.EPartsPassWord_tEdit.AutoSelect = true;
            this.EPartsPassWord_tEdit.DataText = "";
            this.EPartsPassWord_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EPartsPassWord_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, true, true, true, true));
            this.EPartsPassWord_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EPartsPassWord_tEdit.Location = new System.Drawing.Point(757, 132);
            this.EPartsPassWord_tEdit.MaxLength = 16;
            this.EPartsPassWord_tEdit.Name = "EPartsPassWord_tEdit";
            this.EPartsPassWord_tEdit.Size = new System.Drawing.Size(136, 24);
            this.EPartsPassWord_tEdit.TabIndex = 54;
            // 
            // EPartsPassWord_Label
            // 
            appearance135.TextVAlignAsString = "Middle";
            this.EPartsPassWord_Label.Appearance = appearance135;
            this.EPartsPassWord_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.EPartsPassWord_Label.Location = new System.Drawing.Point(608, 133);
            this.EPartsPassWord_Label.Name = "EPartsPassWord_Label";
            this.EPartsPassWord_Label.Size = new System.Drawing.Size(143, 23);
            this.EPartsPassWord_Label.TabIndex = 50;
            this.EPartsPassWord_Label.Text = "パスワード";
            // 
            // EPartsUserId_tEdit
            // 
            appearance188.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EPartsUserId_tEdit.ActiveAppearance = appearance188;
            appearance189.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance189.ForeColorDisabled = System.Drawing.Color.Black;
            this.EPartsUserId_tEdit.Appearance = appearance189;
            this.EPartsUserId_tEdit.AutoSelect = true;
            this.EPartsUserId_tEdit.DataText = "";
            this.EPartsUserId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EPartsUserId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, true, true, true, true));
            this.EPartsUserId_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EPartsUserId_tEdit.Location = new System.Drawing.Point(757, 102);
            this.EPartsUserId_tEdit.MaxLength = 8;
            this.EPartsUserId_tEdit.Name = "EPartsUserId_tEdit";
            this.EPartsUserId_tEdit.Size = new System.Drawing.Size(82, 24);
            this.EPartsUserId_tEdit.TabIndex = 53;
            // 
            // EPartsUserId_Label
            // 
            appearance190.TextVAlignAsString = "Middle";
            this.EPartsUserId_Label.Appearance = appearance190;
            this.EPartsUserId_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.EPartsUserId_Label.Location = new System.Drawing.Point(608, 103);
            this.EPartsUserId_Label.Name = "EPartsUserId_Label";
            this.EPartsUserId_Label.Size = new System.Drawing.Size(143, 23);
            this.EPartsUserId_Label.TabIndex = 48;
            this.EPartsUserId_Label.Text = "ユーザID";
            // 
            // UOEePartsItemCd_tEdit
            // 
            appearance185.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEePartsItemCd_tEdit.ActiveAppearance = appearance185;
            appearance186.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance186.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEePartsItemCd_tEdit.Appearance = appearance186;
            this.UOEePartsItemCd_tEdit.AutoSelect = true;
            this.UOEePartsItemCd_tEdit.DataText = "";
            this.UOEePartsItemCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEePartsItemCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, true, true, true, true));
            this.UOEePartsItemCd_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEePartsItemCd_tEdit.Location = new System.Drawing.Point(757, 72);
            this.UOEePartsItemCd_tEdit.MaxLength = 5;
            this.UOEePartsItemCd_tEdit.Name = "UOEePartsItemCd_tEdit";
            this.UOEePartsItemCd_tEdit.Size = new System.Drawing.Size(59, 24);
            this.UOEePartsItemCd_tEdit.TabIndex = 52;
            // 
            // UOEePartsItemCd_Label
            // 
            appearance187.TextVAlignAsString = "Middle";
            this.UOEePartsItemCd_Label.Appearance = appearance187;
            this.UOEePartsItemCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEePartsItemCd_Label.Location = new System.Drawing.Point(608, 73);
            this.UOEePartsItemCd_Label.Name = "UOEePartsItemCd_Label";
            this.UOEePartsItemCd_Label.Size = new System.Drawing.Size(143, 23);
            this.UOEePartsItemCd_Label.TabIndex = 46;
            this.UOEePartsItemCd_Label.Text = "アイテム";
            // 
            // LoginTimeoutVal_Label2
            // 
            appearance120.TextVAlignAsString = "Middle";
            this.LoginTimeoutVal_Label2.Appearance = appearance120;
            this.LoginTimeoutVal_Label2.BackColorInternal = System.Drawing.Color.Transparent;
            this.LoginTimeoutVal_Label2.Location = new System.Drawing.Point(815, 43);
            this.LoginTimeoutVal_Label2.Name = "LoginTimeoutVal_Label2";
            this.LoginTimeoutVal_Label2.Size = new System.Drawing.Size(25, 23);
            this.LoginTimeoutVal_Label2.TabIndex = 44;
            this.LoginTimeoutVal_Label2.Text = "秒";
            // 
            // LoginTimeoutVal_Label1
            // 
            appearance184.TextVAlignAsString = "Middle";
            this.LoginTimeoutVal_Label1.Appearance = appearance184;
            this.LoginTimeoutVal_Label1.BackColorInternal = System.Drawing.Color.Transparent;
            this.LoginTimeoutVal_Label1.Location = new System.Drawing.Point(607, 43);
            this.LoginTimeoutVal_Label1.Name = "LoginTimeoutVal_Label1";
            this.LoginTimeoutVal_Label1.Size = new System.Drawing.Size(143, 23);
            this.LoginTimeoutVal_Label1.TabIndex = 43;
            this.LoginTimeoutVal_Label1.Text = "ログイン認証時間";
            // 
            // LoginTimeoutVal_tNedit
            // 
            appearance105.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance105.TextHAlignAsString = "Right";
            this.LoginTimeoutVal_tNedit.ActiveAppearance = appearance105;
            appearance87.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance87.ForeColorDisabled = System.Drawing.Color.Black;
            appearance87.TextHAlignAsString = "Right";
            this.LoginTimeoutVal_tNedit.Appearance = appearance87;
            this.LoginTimeoutVal_tNedit.AutoSelect = true;
            this.LoginTimeoutVal_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.LoginTimeoutVal_tNedit.DataText = "";
            this.LoginTimeoutVal_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.LoginTimeoutVal_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.LoginTimeoutVal_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.LoginTimeoutVal_tNedit.Location = new System.Drawing.Point(757, 41);
            this.LoginTimeoutVal_tNedit.MaxLength = 3;
            this.LoginTimeoutVal_tNedit.Name = "LoginTimeoutVal_tNedit";
            this.LoginTimeoutVal_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.LoginTimeoutVal_tNedit.Size = new System.Drawing.Size(51, 24);
            this.LoginTimeoutVal_tNedit.TabIndex = 51;
            // 
            // uButton_AnswerSaveFolder
            // 
            appearance201.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance201.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_AnswerSaveFolder.Appearance = appearance201;
            this.uButton_AnswerSaveFolder.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_AnswerSaveFolder.Location = new System.Drawing.Point(506, 12);
            this.uButton_AnswerSaveFolder.Name = "uButton_AnswerSaveFolder";
            this.uButton_AnswerSaveFolder.Size = new System.Drawing.Size(24, 24);
            this.uButton_AnswerSaveFolder.TabIndex = 45;
            this.uButton_AnswerSaveFolder.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_AnswerSaveFolder.Click += new System.EventHandler(this.uButton_AnswerSaveFolder_Click);
            // 
            // InqOrdDivCd_Label
            // 
            appearance183.TextVAlignAsString = "Middle";
            this.InqOrdDivCd_Label.Appearance = appearance183;
            this.InqOrdDivCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.InqOrdDivCd_Label.Location = new System.Drawing.Point(608, 12);
            this.InqOrdDivCd_Label.Name = "InqOrdDivCd_Label";
            this.InqOrdDivCd_Label.Size = new System.Drawing.Size(143, 23);
            this.InqOrdDivCd_Label.TabIndex = 40;
            this.InqOrdDivCd_Label.Text = "接続種別";
            // 
            // InqOrdDivCd_tComboEditor
            // 
            appearance168.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance168.ForeColor = System.Drawing.Color.Black;
            appearance168.ForeColorDisabled = System.Drawing.Color.Black;
            this.InqOrdDivCd_tComboEditor.ActiveAppearance = appearance168;
            appearance169.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance169.ForeColor = System.Drawing.Color.Black;
            appearance169.ForeColorDisabled = System.Drawing.Color.Black;
            this.InqOrdDivCd_tComboEditor.Appearance = appearance169;
            this.InqOrdDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.InqOrdDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance170.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InqOrdDivCd_tComboEditor.ItemAppearance = appearance170;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "0:発注処理";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "1:在庫確認";
            this.InqOrdDivCd_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.InqOrdDivCd_tComboEditor.Location = new System.Drawing.Point(757, 12);
            this.InqOrdDivCd_tComboEditor.MaxDropDownItems = 18;
            this.InqOrdDivCd_tComboEditor.Name = "InqOrdDivCd_tComboEditor";
            this.InqOrdDivCd_tComboEditor.Size = new System.Drawing.Size(124, 24);
            this.InqOrdDivCd_tComboEditor.TabIndex = 50;
            this.InqOrdDivCd_tComboEditor.Text = "0:発注処理";
            // 
            // UOEForcedTermUrl_tEdit
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEForcedTermUrl_tEdit.ActiveAppearance = appearance19;
            appearance26.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance26.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEForcedTermUrl_tEdit.Appearance = appearance26;
            this.UOEForcedTermUrl_tEdit.AutoSelect = true;
            this.UOEForcedTermUrl_tEdit.DataText = "";
            this.UOEForcedTermUrl_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEForcedTermUrl_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.UOEForcedTermUrl_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UOEForcedTermUrl_tEdit.Location = new System.Drawing.Point(163, 131);
            this.UOEForcedTermUrl_tEdit.MaxLength = 255;
            this.UOEForcedTermUrl_tEdit.Name = "UOEForcedTermUrl_tEdit";
            this.UOEForcedTermUrl_tEdit.Size = new System.Drawing.Size(330, 24);
            this.UOEForcedTermUrl_tEdit.TabIndex = 49;
            // 
            // UOEForcedTermUrl_Label
            // 
            appearance77.TextVAlignAsString = "Middle";
            this.UOEForcedTermUrl_Label.Appearance = appearance77;
            this.UOEForcedTermUrl_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEForcedTermUrl_Label.Location = new System.Drawing.Point(14, 132);
            this.UOEForcedTermUrl_Label.Name = "UOEForcedTermUrl_Label";
            this.UOEForcedTermUrl_Label.Size = new System.Drawing.Size(143, 23);
            this.UOEForcedTermUrl_Label.TabIndex = 38;
            this.UOEForcedTermUrl_Label.Text = "強制終了用URL";
            // 
            // UOEStockCheckUrl_tEdit
            // 
            appearance122.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEStockCheckUrl_tEdit.ActiveAppearance = appearance122;
            appearance123.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance123.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEStockCheckUrl_tEdit.Appearance = appearance123;
            this.UOEStockCheckUrl_tEdit.AutoSelect = true;
            this.UOEStockCheckUrl_tEdit.DataText = "";
            this.UOEStockCheckUrl_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEStockCheckUrl_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.UOEStockCheckUrl_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UOEStockCheckUrl_tEdit.Location = new System.Drawing.Point(163, 101);
            this.UOEStockCheckUrl_tEdit.MaxLength = 255;
            this.UOEStockCheckUrl_tEdit.Name = "UOEStockCheckUrl_tEdit";
            this.UOEStockCheckUrl_tEdit.Size = new System.Drawing.Size(330, 24);
            this.UOEStockCheckUrl_tEdit.TabIndex = 48;
            // 
            // UOEStockCheckUrl_Label
            // 
            appearance127.TextVAlignAsString = "Middle";
            this.UOEStockCheckUrl_Label.Appearance = appearance127;
            this.UOEStockCheckUrl_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEStockCheckUrl_Label.Location = new System.Drawing.Point(14, 102);
            this.UOEStockCheckUrl_Label.Name = "UOEStockCheckUrl_Label";
            this.UOEStockCheckUrl_Label.Size = new System.Drawing.Size(143, 23);
            this.UOEStockCheckUrl_Label.TabIndex = 36;
            this.UOEStockCheckUrl_Label.Text = "在庫確認用URL";
            // 
            // UOEOrderUrl_tEdit
            // 
            appearance191.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEOrderUrl_tEdit.ActiveAppearance = appearance191;
            appearance192.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance192.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEOrderUrl_tEdit.Appearance = appearance192;
            this.UOEOrderUrl_tEdit.AutoSelect = true;
            this.UOEOrderUrl_tEdit.DataText = "";
            this.UOEOrderUrl_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEOrderUrl_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.UOEOrderUrl_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UOEOrderUrl_tEdit.Location = new System.Drawing.Point(163, 71);
            this.UOEOrderUrl_tEdit.MaxLength = 255;
            this.UOEOrderUrl_tEdit.Name = "UOEOrderUrl_tEdit";
            this.UOEOrderUrl_tEdit.Size = new System.Drawing.Size(330, 24);
            this.UOEOrderUrl_tEdit.TabIndex = 47;
            // 
            // UOEOrderUrl_Label
            // 
            appearance193.TextVAlignAsString = "Middle";
            this.UOEOrderUrl_Label.Appearance = appearance193;
            this.UOEOrderUrl_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEOrderUrl_Label.Location = new System.Drawing.Point(14, 72);
            this.UOEOrderUrl_Label.Name = "UOEOrderUrl_Label";
            this.UOEOrderUrl_Label.Size = new System.Drawing.Size(143, 23);
            this.UOEOrderUrl_Label.TabIndex = 34;
            this.UOEOrderUrl_Label.Text = "発注用URL";
            // 
            // UOELoginUrl_tEdit
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOELoginUrl_tEdit.ActiveAppearance = appearance11;
            appearance128.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance128.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOELoginUrl_tEdit.Appearance = appearance128;
            this.UOELoginUrl_tEdit.AutoSelect = true;
            this.UOELoginUrl_tEdit.DataText = "";
            this.UOELoginUrl_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOELoginUrl_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.UOELoginUrl_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UOELoginUrl_tEdit.Location = new System.Drawing.Point(163, 41);
            this.UOELoginUrl_tEdit.MaxLength = 255;
            this.UOELoginUrl_tEdit.Name = "UOELoginUrl_tEdit";
            this.UOELoginUrl_tEdit.Size = new System.Drawing.Size(330, 24);
            this.UOELoginUrl_tEdit.TabIndex = 46;
            // 
            // UOELoginUrl_Label
            // 
            appearance134.TextVAlignAsString = "Middle";
            this.UOELoginUrl_Label.Appearance = appearance134;
            this.UOELoginUrl_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOELoginUrl_Label.Location = new System.Drawing.Point(14, 42);
            this.UOELoginUrl_Label.Name = "UOELoginUrl_Label";
            this.UOELoginUrl_Label.Size = new System.Drawing.Size(143, 23);
            this.UOELoginUrl_Label.TabIndex = 32;
            this.UOELoginUrl_Label.Text = "ログイン用URL";
            // 
            // AnswerSaveFolder_tEdit
            // 
            appearance202.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AnswerSaveFolder_tEdit.ActiveAppearance = appearance202;
            appearance203.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance203.ForeColorDisabled = System.Drawing.Color.Black;
            this.AnswerSaveFolder_tEdit.Appearance = appearance203;
            this.AnswerSaveFolder_tEdit.AutoSelect = true;
            this.AnswerSaveFolder_tEdit.DataText = "";
            this.AnswerSaveFolder_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AnswerSaveFolder_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 80, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.AnswerSaveFolder_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.AnswerSaveFolder_tEdit.Location = new System.Drawing.Point(163, 11);
            this.AnswerSaveFolder_tEdit.MaxLength = 80;
            this.AnswerSaveFolder_tEdit.Name = "AnswerSaveFolder_tEdit";
            this.AnswerSaveFolder_tEdit.Size = new System.Drawing.Size(330, 24);
            this.AnswerSaveFolder_tEdit.TabIndex = 44;
            // 
            // AnswerSaveFolder_Label
            // 
            appearance204.TextVAlignAsString = "Middle";
            this.AnswerSaveFolder_Label.Appearance = appearance204;
            this.AnswerSaveFolder_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.AnswerSaveFolder_Label.Location = new System.Drawing.Point(14, 12);
            this.AnswerSaveFolder_Label.Name = "AnswerSaveFolder_Label";
            this.AnswerSaveFolder_Label.Size = new System.Drawing.Size(143, 23);
            this.AnswerSaveFolder_Label.TabIndex = 30;
            this.AnswerSaveFolder_Label.Text = "回答保存フォルダ";
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.WebConnectCode_tEdit);
            this.ultraTabPageControl4.Controls.Add(this.WebConnectCode_ultraLabel);
            this.ultraTabPageControl4.Controls.Add(this.WebUserID_tEdit);
            this.ultraTabPageControl4.Controls.Add(this.WebUserID_ultraLabel);
            this.ultraTabPageControl4.Controls.Add(this.WebPassword_tEdit);
            this.ultraTabPageControl4.Controls.Add(this.WebPassword_ultraLabel);
            this.ultraTabPageControl4.Controls.Add(this.AnswerAutoDiv_tComboEditor);
            this.ultraTabPageControl4.Controls.Add(this.AnswerAutoDiv_ultraLabel);
            this.ultraTabPageControl4.Controls.Add(this.uButton_AnswerSaveFolderOfTOYOTA);
            this.ultraTabPageControl4.Controls.Add(this.AnswerSaveFolderOfTOYOTA_tEdit);
            this.ultraTabPageControl4.Controls.Add(this.ultraLabel1);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(938, 195);
            // 
            // WebConnectCode_tEdit
            // 
            appearance226.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.WebConnectCode_tEdit.ActiveAppearance = appearance226;
            appearance233.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance233.ForeColorDisabled = System.Drawing.Color.Black;
            this.WebConnectCode_tEdit.Appearance = appearance233;
            this.WebConnectCode_tEdit.AutoSelect = true;
            this.WebConnectCode_tEdit.DataText = "";
            this.WebConnectCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.WebConnectCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.WebConnectCode_tEdit.Location = new System.Drawing.Point(163, 131);
            this.WebConnectCode_tEdit.MaxLength = 20;
            this.WebConnectCode_tEdit.Name = "WebConnectCode_tEdit";
            this.WebConnectCode_tEdit.Size = new System.Drawing.Size(182, 24);
            this.WebConnectCode_tEdit.TabIndex = 56;
            // 
            // WebConnectCode_ultraLabel
            // 
            appearance230.TextVAlignAsString = "Middle";
            this.WebConnectCode_ultraLabel.Appearance = appearance230;
            this.WebConnectCode_ultraLabel.Location = new System.Drawing.Point(14, 132);
            this.WebConnectCode_ultraLabel.Name = "WebConnectCode_ultraLabel";
            this.WebConnectCode_ultraLabel.Size = new System.Drawing.Size(143, 23);
            this.WebConnectCode_ultraLabel.TabIndex = 55;
            this.WebConnectCode_ultraLabel.Text = "WEB接続先コード";
            // 
            // WebUserID_tEdit
            // 
            appearance225.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.WebUserID_tEdit.ActiveAppearance = appearance225;
            appearance232.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance232.ForeColorDisabled = System.Drawing.Color.Black;
            this.WebUserID_tEdit.Appearance = appearance232;
            this.WebUserID_tEdit.AutoSelect = true;
            this.WebUserID_tEdit.DataText = "";
            this.WebUserID_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.WebUserID_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.WebUserID_tEdit.Location = new System.Drawing.Point(163, 101);
            this.WebUserID_tEdit.MaxLength = 5;
            this.WebUserID_tEdit.Name = "WebUserID_tEdit";
            this.WebUserID_tEdit.Size = new System.Drawing.Size(59, 24);
            this.WebUserID_tEdit.TabIndex = 54;
            // 
            // WebUserID_ultraLabel
            // 
            appearance229.TextVAlignAsString = "Middle";
            this.WebUserID_ultraLabel.Appearance = appearance229;
            this.WebUserID_ultraLabel.Location = new System.Drawing.Point(14, 102);
            this.WebUserID_ultraLabel.Name = "WebUserID_ultraLabel";
            this.WebUserID_ultraLabel.Size = new System.Drawing.Size(143, 23);
            this.WebUserID_ultraLabel.TabIndex = 53;
            this.WebUserID_ultraLabel.Text = "WEBユーザーID";
            // 
            // WebPassword_tEdit
            // 
            appearance224.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.WebPassword_tEdit.ActiveAppearance = appearance224;
            appearance231.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance231.ForeColorDisabled = System.Drawing.Color.Black;
            this.WebPassword_tEdit.Appearance = appearance231;
            this.WebPassword_tEdit.AutoSelect = true;
            this.WebPassword_tEdit.DataText = "";
            this.WebPassword_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.WebPassword_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.WebPassword_tEdit.Location = new System.Drawing.Point(163, 71);
            this.WebPassword_tEdit.MaxLength = 3;
            this.WebPassword_tEdit.Name = "WebPassword_tEdit";
            this.WebPassword_tEdit.Size = new System.Drawing.Size(43, 24);
            this.WebPassword_tEdit.TabIndex = 52;
            // 
            // WebPassword_ultraLabel
            // 
            appearance228.TextVAlignAsString = "Middle";
            this.WebPassword_ultraLabel.Appearance = appearance228;
            this.WebPassword_ultraLabel.Location = new System.Drawing.Point(14, 72);
            this.WebPassword_ultraLabel.Name = "WebPassword_ultraLabel";
            this.WebPassword_ultraLabel.Size = new System.Drawing.Size(143, 23);
            this.WebPassword_ultraLabel.TabIndex = 51;
            this.WebPassword_ultraLabel.Text = "WEBパスワード";
            // 
            // AnswerAutoDiv_tComboEditor
            // 
            appearance236.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance236.ForeColor = System.Drawing.Color.Black;
            appearance236.ForeColorDisabled = System.Drawing.Color.Black;
            this.AnswerAutoDiv_tComboEditor.ActiveAppearance = appearance236;
            appearance237.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance237.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance237.ForeColor = System.Drawing.Color.Black;
            appearance237.ForeColorDisabled = System.Drawing.Color.Black;
            this.AnswerAutoDiv_tComboEditor.Appearance = appearance237;
            this.AnswerAutoDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.AnswerAutoDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance238.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AnswerAutoDiv_tComboEditor.ItemAppearance = appearance238;
            this.AnswerAutoDiv_tComboEditor.Location = new System.Drawing.Point(163, 41);
            this.AnswerAutoDiv_tComboEditor.MaxLength = 1;
            this.AnswerAutoDiv_tComboEditor.Name = "AnswerAutoDiv_tComboEditor";
            this.AnswerAutoDiv_tComboEditor.Size = new System.Drawing.Size(144, 24);
            this.AnswerAutoDiv_tComboEditor.TabIndex = 50;
            this.AnswerAutoDiv_tComboEditor.ValueMember = "";
            // 
            // AnswerAutoDiv_ultraLabel
            // 
            appearance227.TextVAlignAsString = "Middle";
            this.AnswerAutoDiv_ultraLabel.Appearance = appearance227;
            this.AnswerAutoDiv_ultraLabel.Location = new System.Drawing.Point(14, 42);
            this.AnswerAutoDiv_ultraLabel.Name = "AnswerAutoDiv_ultraLabel";
            this.AnswerAutoDiv_ultraLabel.Size = new System.Drawing.Size(143, 23);
            this.AnswerAutoDiv_ultraLabel.TabIndex = 49;
            this.AnswerAutoDiv_ultraLabel.Text = "回答自動取込区分";
            // 
            // uButton_AnswerSaveFolderOfTOYOTA
            // 
            appearance239.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance239.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_AnswerSaveFolderOfTOYOTA.Appearance = appearance239;
            this.uButton_AnswerSaveFolderOfTOYOTA.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_AnswerSaveFolderOfTOYOTA.Location = new System.Drawing.Point(506, 12);
            this.uButton_AnswerSaveFolderOfTOYOTA.Name = "uButton_AnswerSaveFolderOfTOYOTA";
            this.uButton_AnswerSaveFolderOfTOYOTA.Size = new System.Drawing.Size(24, 24);
            this.uButton_AnswerSaveFolderOfTOYOTA.TabIndex = 48;
            this.uButton_AnswerSaveFolderOfTOYOTA.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_AnswerSaveFolderOfTOYOTA.Click += new System.EventHandler(this.uButton_AnswerSaveFolder1_Click);
            // 
            // AnswerSaveFolderOfTOYOTA_tEdit
            // 
            appearance240.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AnswerSaveFolderOfTOYOTA_tEdit.ActiveAppearance = appearance240;
            appearance241.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance241.ForeColorDisabled = System.Drawing.Color.Black;
            this.AnswerSaveFolderOfTOYOTA_tEdit.Appearance = appearance241;
            this.AnswerSaveFolderOfTOYOTA_tEdit.AutoSelect = true;
            this.AnswerSaveFolderOfTOYOTA_tEdit.DataText = "";
            this.AnswerSaveFolderOfTOYOTA_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AnswerSaveFolderOfTOYOTA_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 80, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.AnswerSaveFolderOfTOYOTA_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.AnswerSaveFolderOfTOYOTA_tEdit.Location = new System.Drawing.Point(163, 11);
            this.AnswerSaveFolderOfTOYOTA_tEdit.MaxLength = 80;
            this.AnswerSaveFolderOfTOYOTA_tEdit.Name = "AnswerSaveFolderOfTOYOTA_tEdit";
            this.AnswerSaveFolderOfTOYOTA_tEdit.Size = new System.Drawing.Size(330, 24);
            this.AnswerSaveFolderOfTOYOTA_tEdit.TabIndex = 47;
            // 
            // ultraLabel1
            // 
            appearance242.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance242;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Location = new System.Drawing.Point(14, 12);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(143, 23);
            this.ultraLabel1.TabIndex = 46;
            this.ultraLabel1.Text = "回答保存フォルダ";
            // 
            // ultraTabPageControl5
            // 
            this.ultraTabPageControl5.Controls.Add(this.tEdit_MazdaSectionCode);
            this.ultraTabPageControl5.Controls.Add(this.ultraLabel_MazdaSectionCode);
            this.ultraTabPageControl5.Controls.Add(this.Nissan_AnswerAutoDiv_tComboEditor);
            this.ultraTabPageControl5.Controls.Add(this.Nissan_AnswerAutoDiv_ultraLabel);
            this.ultraTabPageControl5.Controls.Add(this.uButton_NissanAnswerSaveFolder);
            this.ultraTabPageControl5.Controls.Add(this.NissanAnswerSaveFolder_tEdit);
            this.ultraTabPageControl5.Controls.Add(this.Nissan_ultraLabel);
            this.ultraTabPageControl5.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl5.Name = "ultraTabPageControl5";
            this.ultraTabPageControl5.Size = new System.Drawing.Size(938, 195);
            // 
            // tEdit_MazdaSectionCode
            // 
            appearance175.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_MazdaSectionCode.ActiveAppearance = appearance175;
            appearance176.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance176.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance176.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_MazdaSectionCode.Appearance = appearance176;
            this.tEdit_MazdaSectionCode.AutoSelect = true;
            this.tEdit_MazdaSectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_MazdaSectionCode.DataText = "";
            this.tEdit_MazdaSectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MazdaSectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 80, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.tEdit_MazdaSectionCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_MazdaSectionCode.Location = new System.Drawing.Point(163, 71);
            this.tEdit_MazdaSectionCode.MaxLength = 3;
            this.tEdit_MazdaSectionCode.Name = "tEdit_MazdaSectionCode";
            this.tEdit_MazdaSectionCode.Size = new System.Drawing.Size(35, 24);
            this.tEdit_MazdaSectionCode.TabIndex = 53;
            // 
            // ultraLabel_MazdaSectionCode
            // 
            appearance235.TextVAlignAsString = "Middle";
            this.ultraLabel_MazdaSectionCode.Appearance = appearance235;
            this.ultraLabel_MazdaSectionCode.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel_MazdaSectionCode.Location = new System.Drawing.Point(14, 71);
            this.ultraLabel_MazdaSectionCode.Name = "ultraLabel_MazdaSectionCode";
            this.ultraLabel_MazdaSectionCode.Size = new System.Drawing.Size(143, 23);
            this.ultraLabel_MazdaSectionCode.TabIndex = 53;
            this.ultraLabel_MazdaSectionCode.Text = "WEBダミー品番";
            // 
            // Nissan_AnswerAutoDiv_tComboEditor
            // 
            appearance243.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance243.ForeColor = System.Drawing.Color.Black;
            appearance243.ForeColorDisabled = System.Drawing.Color.Black;
            this.Nissan_AnswerAutoDiv_tComboEditor.ActiveAppearance = appearance243;
            appearance244.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance244.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance244.ForeColor = System.Drawing.Color.Black;
            appearance244.ForeColorDisabled = System.Drawing.Color.Black;
            this.Nissan_AnswerAutoDiv_tComboEditor.Appearance = appearance244;
            this.Nissan_AnswerAutoDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Nissan_AnswerAutoDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance245.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Nissan_AnswerAutoDiv_tComboEditor.ItemAppearance = appearance245;
            this.Nissan_AnswerAutoDiv_tComboEditor.Location = new System.Drawing.Point(163, 41);
            this.Nissan_AnswerAutoDiv_tComboEditor.MaxLength = 1;
            this.Nissan_AnswerAutoDiv_tComboEditor.Name = "Nissan_AnswerAutoDiv_tComboEditor";
            this.Nissan_AnswerAutoDiv_tComboEditor.Size = new System.Drawing.Size(144, 24);
            this.Nissan_AnswerAutoDiv_tComboEditor.TabIndex = 52;
            this.Nissan_AnswerAutoDiv_tComboEditor.ValueMember = "";
            // 
            // Nissan_AnswerAutoDiv_ultraLabel
            // 
            appearance246.TextVAlignAsString = "Middle";
            this.Nissan_AnswerAutoDiv_ultraLabel.Appearance = appearance246;
            this.Nissan_AnswerAutoDiv_ultraLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.Nissan_AnswerAutoDiv_ultraLabel.Location = new System.Drawing.Point(14, 41);
            this.Nissan_AnswerAutoDiv_ultraLabel.Name = "Nissan_AnswerAutoDiv_ultraLabel";
            this.Nissan_AnswerAutoDiv_ultraLabel.Size = new System.Drawing.Size(144, 24);
            this.Nissan_AnswerAutoDiv_ultraLabel.TabIndex = 1;
            this.Nissan_AnswerAutoDiv_ultraLabel.Text = "回答自動取込区分";
            // 
            // uButton_NissanAnswerSaveFolder
            // 
            this.uButton_NissanAnswerSaveFolder.Appearance = appearance239;
            this.uButton_NissanAnswerSaveFolder.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_NissanAnswerSaveFolder.Location = new System.Drawing.Point(506, 12);
            this.uButton_NissanAnswerSaveFolder.Name = "uButton_NissanAnswerSaveFolder";
            this.uButton_NissanAnswerSaveFolder.Size = new System.Drawing.Size(24, 24);
            this.uButton_NissanAnswerSaveFolder.TabIndex = 51;
            this.uButton_NissanAnswerSaveFolder.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_NissanAnswerSaveFolder.Click += new System.EventHandler(this.uButton_NissanAnswerSaveFolder_Click);
            // 
            // NissanAnswerSaveFolder_tEdit
            // 
            this.NissanAnswerSaveFolder_tEdit.ActiveAppearance = appearance240;
            this.NissanAnswerSaveFolder_tEdit.Appearance = appearance241;
            this.NissanAnswerSaveFolder_tEdit.AutoSelect = true;
            this.NissanAnswerSaveFolder_tEdit.DataText = "";
            this.NissanAnswerSaveFolder_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.NissanAnswerSaveFolder_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 80, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.NissanAnswerSaveFolder_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.NissanAnswerSaveFolder_tEdit.Location = new System.Drawing.Point(163, 11);
            this.NissanAnswerSaveFolder_tEdit.MaxLength = 80;
            this.NissanAnswerSaveFolder_tEdit.Name = "NissanAnswerSaveFolder_tEdit";
            this.NissanAnswerSaveFolder_tEdit.Size = new System.Drawing.Size(330, 24);
            this.NissanAnswerSaveFolder_tEdit.TabIndex = 50;
            // 
            // Nissan_ultraLabel
            // 
            this.Nissan_ultraLabel.Appearance = appearance242;
            this.Nissan_ultraLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.Nissan_ultraLabel.Location = new System.Drawing.Point(14, 12);
            this.Nissan_ultraLabel.Name = "Nissan_ultraLabel";
            this.Nissan_ultraLabel.Size = new System.Drawing.Size(143, 23);
            this.Nissan_ultraLabel.TabIndex = 49;
            this.Nissan_ultraLabel.Text = "回答保存フォルダ";
            // 
            // ultraTabPageControl6
            // 
            this.ultraTabPageControl6.Controls.Add(this.uButton_MitsubishiAnswerSaveFolder);
            this.ultraTabPageControl6.Controls.Add(this.MitsubishiAnswerSaveFolder_tEdit);
            this.ultraTabPageControl6.Controls.Add(this.Mitsubishi_ultraLabel);
            this.ultraTabPageControl6.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl6.Name = "ultraTabPageControl6";
            this.ultraTabPageControl6.Size = new System.Drawing.Size(938, 195);
            // 
            // uButton_MitsubishiAnswerSaveFolder
            // 
            this.uButton_MitsubishiAnswerSaveFolder.Appearance = appearance239;
            this.uButton_MitsubishiAnswerSaveFolder.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_MitsubishiAnswerSaveFolder.Location = new System.Drawing.Point(506, 12);
            this.uButton_MitsubishiAnswerSaveFolder.Name = "uButton_MitsubishiAnswerSaveFolder";
            this.uButton_MitsubishiAnswerSaveFolder.Size = new System.Drawing.Size(24, 24);
            this.uButton_MitsubishiAnswerSaveFolder.TabIndex = 53;
            this.uButton_MitsubishiAnswerSaveFolder.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_MitsubishiAnswerSaveFolder.Click += new System.EventHandler(this.uButton_MitsubishiAnswerSaveFolder_Click);
            // 
            // MitsubishiAnswerSaveFolder_tEdit
            // 
            this.MitsubishiAnswerSaveFolder_tEdit.ActiveAppearance = appearance240;
            this.MitsubishiAnswerSaveFolder_tEdit.Appearance = appearance241;
            this.MitsubishiAnswerSaveFolder_tEdit.AutoSelect = true;
            this.MitsubishiAnswerSaveFolder_tEdit.DataText = "";
            this.MitsubishiAnswerSaveFolder_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MitsubishiAnswerSaveFolder_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 80, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.MitsubishiAnswerSaveFolder_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MitsubishiAnswerSaveFolder_tEdit.Location = new System.Drawing.Point(163, 11);
            this.MitsubishiAnswerSaveFolder_tEdit.MaxLength = 80;
            this.MitsubishiAnswerSaveFolder_tEdit.Name = "MitsubishiAnswerSaveFolder_tEdit";
            this.MitsubishiAnswerSaveFolder_tEdit.Size = new System.Drawing.Size(330, 24);
            this.MitsubishiAnswerSaveFolder_tEdit.TabIndex = 52;
            // 
            // Mitsubishi_ultraLabel
            // 
            this.Mitsubishi_ultraLabel.Appearance = appearance242;
            this.Mitsubishi_ultraLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.Mitsubishi_ultraLabel.Location = new System.Drawing.Point(14, 12);
            this.Mitsubishi_ultraLabel.Name = "Mitsubishi_ultraLabel";
            this.Mitsubishi_ultraLabel.Size = new System.Drawing.Size(143, 23);
            this.Mitsubishi_ultraLabel.TabIndex = 52;
            this.Mitsubishi_ultraLabel.Text = "回答保存フォルダ";
            // 
            // ultraTabPageControl7
            // 
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeSystemUseType_tEdit);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeSystemUseType_Label);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoePassword_tEdit);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoePassword_Label);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeTerminalID_tEdit);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeTerminalID_Label);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeCoCode_tEdit);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeCoCode_Label);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeJigyousyoCode_tEdit);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeJigyousyoCode_Label);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeEigyousyoFlag_tEdit);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeEigyousyoFlag_Label);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeEigyousyoCode_tEdit);
            this.ultraTabPageControl7.Controls.Add(this.MeiJiUoeEigyousyoCode_Label);
            this.ultraTabPageControl7.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl7.Name = "ultraTabPageControl7";
            this.ultraTabPageControl7.Size = new System.Drawing.Size(938, 195);
            // 
            // MeiJiUoeSystemUseType_tEdit
            // 
            appearance155.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MeiJiUoeSystemUseType_tEdit.ActiveAppearance = appearance155;
            appearance156.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance156.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance156.ForeColorDisabled = System.Drawing.Color.Black;
            this.MeiJiUoeSystemUseType_tEdit.Appearance = appearance156;
            this.MeiJiUoeSystemUseType_tEdit.AutoSelect = true;
            this.MeiJiUoeSystemUseType_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MeiJiUoeSystemUseType_tEdit.DataText = "";
            this.MeiJiUoeSystemUseType_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MeiJiUoeSystemUseType_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.MeiJiUoeSystemUseType_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MeiJiUoeSystemUseType_tEdit.Location = new System.Drawing.Point(165, 18);
            this.MeiJiUoeSystemUseType_tEdit.MaxLength = 1;
            this.MeiJiUoeSystemUseType_tEdit.Name = "MeiJiUoeSystemUseType_tEdit";
            this.MeiJiUoeSystemUseType_tEdit.Size = new System.Drawing.Size(35, 24);
            this.MeiJiUoeSystemUseType_tEdit.TabIndex = 1;
            // 
            // MeiJiUoeSystemUseType_Label
            // 
            appearance174.TextVAlignAsString = "Middle";
            this.MeiJiUoeSystemUseType_Label.Appearance = appearance174;
            this.MeiJiUoeSystemUseType_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MeiJiUoeSystemUseType_Label.Location = new System.Drawing.Point(25, 19);
            this.MeiJiUoeSystemUseType_Label.Name = "MeiJiUoeSystemUseType_Label";
            this.MeiJiUoeSystemUseType_Label.Size = new System.Drawing.Size(143, 23);
            this.MeiJiUoeSystemUseType_Label.TabIndex = 50;
            this.MeiJiUoeSystemUseType_Label.Text = "システム利用形態";
            // 
            // MeiJiUoePassword_tEdit
            // 
            appearance148.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MeiJiUoePassword_tEdit.ActiveAppearance = appearance148;
            appearance205.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance205.ForeColorDisabled = System.Drawing.Color.Black;
            this.MeiJiUoePassword_tEdit.Appearance = appearance205;
            this.MeiJiUoePassword_tEdit.AutoSelect = true;
            this.MeiJiUoePassword_tEdit.DataText = "";
            this.MeiJiUoePassword_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MeiJiUoePassword_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.MeiJiUoePassword_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MeiJiUoePassword_tEdit.Location = new System.Drawing.Point(165, 156);
            this.MeiJiUoePassword_tEdit.MaxLength = 10;
            this.MeiJiUoePassword_tEdit.Name = "MeiJiUoePassword_tEdit";
            this.MeiJiUoePassword_tEdit.Size = new System.Drawing.Size(314, 24);
            this.MeiJiUoePassword_tEdit.TabIndex = 7;
            // 
            // MeiJiUoePassword_Label
            // 
            appearance206.TextVAlignAsString = "Middle";
            this.MeiJiUoePassword_Label.Appearance = appearance206;
            this.MeiJiUoePassword_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MeiJiUoePassword_Label.Location = new System.Drawing.Point(25, 157);
            this.MeiJiUoePassword_Label.Name = "MeiJiUoePassword_Label";
            this.MeiJiUoePassword_Label.Size = new System.Drawing.Size(143, 23);
            this.MeiJiUoePassword_Label.TabIndex = 56;
            this.MeiJiUoePassword_Label.Text = "パスワード";
            // 
            // MeiJiUoeTerminalID_tEdit
            // 
            appearance207.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MeiJiUoeTerminalID_tEdit.ActiveAppearance = appearance207;
            appearance208.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance208.ForeColorDisabled = System.Drawing.Color.Black;
            this.MeiJiUoeTerminalID_tEdit.Appearance = appearance208;
            this.MeiJiUoeTerminalID_tEdit.AutoSelect = true;
            this.MeiJiUoeTerminalID_tEdit.DataText = "";
            this.MeiJiUoeTerminalID_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MeiJiUoeTerminalID_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.MeiJiUoeTerminalID_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MeiJiUoeTerminalID_tEdit.Location = new System.Drawing.Point(165, 133);
            this.MeiJiUoeTerminalID_tEdit.MaxLength = 5;
            this.MeiJiUoeTerminalID_tEdit.Name = "MeiJiUoeTerminalID_tEdit";
            this.MeiJiUoeTerminalID_tEdit.Size = new System.Drawing.Size(144, 24);
            this.MeiJiUoeTerminalID_tEdit.TabIndex = 6;
            // 
            // MeiJiUoeTerminalID_Label
            // 
            appearance209.TextVAlignAsString = "Middle";
            this.MeiJiUoeTerminalID_Label.Appearance = appearance209;
            this.MeiJiUoeTerminalID_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MeiJiUoeTerminalID_Label.Location = new System.Drawing.Point(25, 134);
            this.MeiJiUoeTerminalID_Label.Name = "MeiJiUoeTerminalID_Label";
            this.MeiJiUoeTerminalID_Label.Size = new System.Drawing.Size(143, 23);
            this.MeiJiUoeTerminalID_Label.TabIndex = 55;
            this.MeiJiUoeTerminalID_Label.Text = "端末ID";
            // 
            // MeiJiUoeCoCode_tEdit
            // 
            this.MeiJiUoeCoCode_tEdit.AcceptsReturn = true;
            appearance210.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MeiJiUoeCoCode_tEdit.ActiveAppearance = appearance210;
            appearance211.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance211.ForeColorDisabled = System.Drawing.Color.Black;
            this.MeiJiUoeCoCode_tEdit.Appearance = appearance211;
            this.MeiJiUoeCoCode_tEdit.AutoSelect = true;
            this.MeiJiUoeCoCode_tEdit.DataText = "";
            this.MeiJiUoeCoCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MeiJiUoeCoCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.MeiJiUoeCoCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MeiJiUoeCoCode_tEdit.Location = new System.Drawing.Point(165, 110);
            this.MeiJiUoeCoCode_tEdit.MaxLength = 6;
            this.MeiJiUoeCoCode_tEdit.Name = "MeiJiUoeCoCode_tEdit";
            this.MeiJiUoeCoCode_tEdit.Size = new System.Drawing.Size(175, 24);
            this.MeiJiUoeCoCode_tEdit.TabIndex = 5;
            // 
            // MeiJiUoeCoCode_Label
            // 
            appearance212.TextVAlignAsString = "Middle";
            this.MeiJiUoeCoCode_Label.Appearance = appearance212;
            this.MeiJiUoeCoCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MeiJiUoeCoCode_Label.Location = new System.Drawing.Point(25, 111);
            this.MeiJiUoeCoCode_Label.Name = "MeiJiUoeCoCode_Label";
            this.MeiJiUoeCoCode_Label.Size = new System.Drawing.Size(143, 23);
            this.MeiJiUoeCoCode_Label.TabIndex = 54;
            this.MeiJiUoeCoCode_Label.Text = "会社コード";
            // 
            // MeiJiUoeJigyousyoCode_tEdit
            // 
            this.MeiJiUoeJigyousyoCode_tEdit.AcceptsReturn = true;
            appearance213.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MeiJiUoeJigyousyoCode_tEdit.ActiveAppearance = appearance213;
            appearance214.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance214.ForeColorDisabled = System.Drawing.Color.Black;
            this.MeiJiUoeJigyousyoCode_tEdit.Appearance = appearance214;
            this.MeiJiUoeJigyousyoCode_tEdit.AutoSelect = true;
            this.MeiJiUoeJigyousyoCode_tEdit.DataText = "";
            this.MeiJiUoeJigyousyoCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MeiJiUoeJigyousyoCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.MeiJiUoeJigyousyoCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MeiJiUoeJigyousyoCode_tEdit.Location = new System.Drawing.Point(165, 87);
            this.MeiJiUoeJigyousyoCode_tEdit.MaxLength = 10;
            this.MeiJiUoeJigyousyoCode_tEdit.Name = "MeiJiUoeJigyousyoCode_tEdit";
            this.MeiJiUoeJigyousyoCode_tEdit.Size = new System.Drawing.Size(314, 24);
            this.MeiJiUoeJigyousyoCode_tEdit.TabIndex = 4;
            // 
            // MeiJiUoeJigyousyoCode_Label
            // 
            appearance215.TextVAlignAsString = "Middle";
            this.MeiJiUoeJigyousyoCode_Label.Appearance = appearance215;
            this.MeiJiUoeJigyousyoCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MeiJiUoeJigyousyoCode_Label.Location = new System.Drawing.Point(25, 88);
            this.MeiJiUoeJigyousyoCode_Label.Name = "MeiJiUoeJigyousyoCode_Label";
            this.MeiJiUoeJigyousyoCode_Label.Size = new System.Drawing.Size(143, 23);
            this.MeiJiUoeJigyousyoCode_Label.TabIndex = 53;
            this.MeiJiUoeJigyousyoCode_Label.Text = "事業所コード";
            // 
            // MeiJiUoeEigyousyoFlag_tEdit
            // 
            appearance216.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance216.TextHAlignAsString = "Right";
            this.MeiJiUoeEigyousyoFlag_tEdit.ActiveAppearance = appearance216;
            appearance217.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance217.ForeColorDisabled = System.Drawing.Color.Black;
            appearance217.TextHAlignAsString = "Right";
            this.MeiJiUoeEigyousyoFlag_tEdit.Appearance = appearance217;
            this.MeiJiUoeEigyousyoFlag_tEdit.AutoSelect = true;
            this.MeiJiUoeEigyousyoFlag_tEdit.DataText = "";
            this.MeiJiUoeEigyousyoFlag_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MeiJiUoeEigyousyoFlag_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.MeiJiUoeEigyousyoFlag_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MeiJiUoeEigyousyoFlag_tEdit.Location = new System.Drawing.Point(165, 64);
            this.MeiJiUoeEigyousyoFlag_tEdit.MaxLength = 1;
            this.MeiJiUoeEigyousyoFlag_tEdit.Name = "MeiJiUoeEigyousyoFlag_tEdit";
            this.MeiJiUoeEigyousyoFlag_tEdit.Size = new System.Drawing.Size(35, 24);
            this.MeiJiUoeEigyousyoFlag_tEdit.TabIndex = 3;
            // 
            // MeiJiUoeEigyousyoFlag_Label
            // 
            appearance218.TextVAlignAsString = "Middle";
            this.MeiJiUoeEigyousyoFlag_Label.Appearance = appearance218;
            this.MeiJiUoeEigyousyoFlag_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MeiJiUoeEigyousyoFlag_Label.Location = new System.Drawing.Point(25, 65);
            this.MeiJiUoeEigyousyoFlag_Label.Name = "MeiJiUoeEigyousyoFlag_Label";
            this.MeiJiUoeEigyousyoFlag_Label.Size = new System.Drawing.Size(143, 23);
            this.MeiJiUoeEigyousyoFlag_Label.TabIndex = 52;
            this.MeiJiUoeEigyousyoFlag_Label.Text = "営業所フラグ";
            // 
            // MeiJiUoeEigyousyoCode_tEdit
            // 
            appearance219.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MeiJiUoeEigyousyoCode_tEdit.ActiveAppearance = appearance219;
            appearance220.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance220.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance220.ForeColorDisabled = System.Drawing.Color.Black;
            this.MeiJiUoeEigyousyoCode_tEdit.Appearance = appearance220;
            this.MeiJiUoeEigyousyoCode_tEdit.AutoSelect = true;
            this.MeiJiUoeEigyousyoCode_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MeiJiUoeEigyousyoCode_tEdit.DataText = "";
            this.MeiJiUoeEigyousyoCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MeiJiUoeEigyousyoCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.MeiJiUoeEigyousyoCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MeiJiUoeEigyousyoCode_tEdit.Location = new System.Drawing.Point(165, 41);
            this.MeiJiUoeEigyousyoCode_tEdit.MaxLength = 5;
            this.MeiJiUoeEigyousyoCode_tEdit.Name = "MeiJiUoeEigyousyoCode_tEdit";
            this.MeiJiUoeEigyousyoCode_tEdit.Size = new System.Drawing.Size(144, 24);
            this.MeiJiUoeEigyousyoCode_tEdit.TabIndex = 2;
            // 
            // MeiJiUoeEigyousyoCode_Label
            // 
            appearance221.TextVAlignAsString = "Middle";
            this.MeiJiUoeEigyousyoCode_Label.Appearance = appearance221;
            this.MeiJiUoeEigyousyoCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MeiJiUoeEigyousyoCode_Label.Location = new System.Drawing.Point(25, 42);
            this.MeiJiUoeEigyousyoCode_Label.Name = "MeiJiUoeEigyousyoCode_Label";
            this.MeiJiUoeEigyousyoCode_Label.Size = new System.Drawing.Size(143, 23);
            this.MeiJiUoeEigyousyoCode_Label.TabIndex = 51;
            this.MeiJiUoeEigyousyoCode_Label.Text = "営業所コード";
            // 
            // ultraTabPageControl8
            // 
            this.ultraTabPageControl8.Controls.Add(this.tEdit_HondaSectionCode);
            this.ultraTabPageControl8.Controls.Add(this.ultraLabel_HondaSectionCode);
            this.ultraTabPageControl8.Controls.Add(this.uButton_MazdaAnswerSaveFolder);
            this.ultraTabPageControl8.Controls.Add(this.MazdaAnswerSaveFolder_tEdit);
            this.ultraTabPageControl8.Controls.Add(this.Mazda_ultraLabel);
            this.ultraTabPageControl8.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraTabPageControl8.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl8.Name = "ultraTabPageControl8";
            this.ultraTabPageControl8.Size = new System.Drawing.Size(938, 195);
            // 
            // tEdit_HondaSectionCode
            // 
            this.tEdit_HondaSectionCode.ActiveAppearance = appearance175;
            this.tEdit_HondaSectionCode.Appearance = appearance176;
            this.tEdit_HondaSectionCode.AutoSelect = true;
            this.tEdit_HondaSectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_HondaSectionCode.DataText = "";
            this.tEdit_HondaSectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_HondaSectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.tEdit_HondaSectionCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_HondaSectionCode.Location = new System.Drawing.Point(163, 41);
            this.tEdit_HondaSectionCode.MaxLength = 3;
            this.tEdit_HondaSectionCode.Name = "tEdit_HondaSectionCode";
            this.tEdit_HondaSectionCode.Size = new System.Drawing.Size(35, 24);
            this.tEdit_HondaSectionCode.TabIndex = 58;
            // 
            // ultraLabel_HondaSectionCode
            // 
            appearance177.TextVAlignAsString = "Middle";
            this.ultraLabel_HondaSectionCode.Appearance = appearance177;
            this.ultraLabel_HondaSectionCode.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel_HondaSectionCode.Location = new System.Drawing.Point(14, 41);
            this.ultraLabel_HondaSectionCode.Name = "ultraLabel_HondaSectionCode";
            this.ultraLabel_HondaSectionCode.Size = new System.Drawing.Size(144, 24);
            this.ultraLabel_HondaSectionCode.TabIndex = 57;
            this.ultraLabel_HondaSectionCode.Text = "WEBダミー品番";
            // 
            // uButton_MazdaAnswerSaveFolder
            // 
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_MazdaAnswerSaveFolder.Appearance = appearance12;
            this.uButton_MazdaAnswerSaveFolder.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_MazdaAnswerSaveFolder.Location = new System.Drawing.Point(506, 12);
            this.uButton_MazdaAnswerSaveFolder.Name = "uButton_MazdaAnswerSaveFolder";
            this.uButton_MazdaAnswerSaveFolder.Size = new System.Drawing.Size(24, 24);
            this.uButton_MazdaAnswerSaveFolder.TabIndex = 56;
            this.uButton_MazdaAnswerSaveFolder.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_MazdaAnswerSaveFolder.Click += new System.EventHandler(this.uButton_MazdaAnswerSaveFolder_Click);
            // 
            // MazdaAnswerSaveFolder_tEdit
            // 
            appearance222.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MazdaAnswerSaveFolder_tEdit.ActiveAppearance = appearance222;
            appearance223.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance223.ForeColorDisabled = System.Drawing.Color.Black;
            this.MazdaAnswerSaveFolder_tEdit.Appearance = appearance223;
            this.MazdaAnswerSaveFolder_tEdit.AutoSelect = true;
            this.MazdaAnswerSaveFolder_tEdit.DataText = "";
            this.MazdaAnswerSaveFolder_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MazdaAnswerSaveFolder_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 80, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.MazdaAnswerSaveFolder_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MazdaAnswerSaveFolder_tEdit.Location = new System.Drawing.Point(163, 11);
            this.MazdaAnswerSaveFolder_tEdit.MaxLength = 80;
            this.MazdaAnswerSaveFolder_tEdit.Name = "MazdaAnswerSaveFolder_tEdit";
            this.MazdaAnswerSaveFolder_tEdit.Size = new System.Drawing.Size(330, 24);
            this.MazdaAnswerSaveFolder_tEdit.TabIndex = 55;
            // 
            // Mazda_ultraLabel
            // 
            this.Mazda_ultraLabel.Appearance = appearance235;
            this.Mazda_ultraLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.Mazda_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.Mazda_ultraLabel.Location = new System.Drawing.Point(14, 12);
            this.Mazda_ultraLabel.Name = "Mazda_ultraLabel";
            this.Mazda_ultraLabel.Size = new System.Drawing.Size(143, 23);
            this.Mazda_ultraLabel.TabIndex = 54;
            this.Mazda_ultraLabel.Text = "回答保存フォルダ";
            // 
            // ultraTabPageControl9
            // 
            this.ultraTabPageControl9.Controls.Add(this.CarMaker_uButton);
            this.ultraTabPageControl9.Controls.Add(this.ultraLabel2);
            this.ultraTabPageControl9.Controls.Add(this.BLMngUserCode_tEdit);
            this.ultraTabPageControl9.Controls.Add(this.TimeOut_tEdit);
            this.ultraTabPageControl9.Controls.Add(this.PurchaseAddress_tEdit);
            this.ultraTabPageControl9.Controls.Add(this.RestoreAddress_tEdit);
            this.ultraTabPageControl9.Controls.Add(this.OrderAddress_tEdit);
            this.ultraTabPageControl9.Controls.Add(this.Domain_tEdit);
            this.ultraTabPageControl9.Controls.Add(this.Connection_tComboEditor);
            this.ultraTabPageControl9.Controls.Add(this.Protocol_tComboEditor);
            this.ultraTabPageControl9.Controls.Add(this.CarMaker_uLabel);
            this.ultraTabPageControl9.Controls.Add(this.Connection_uLabel);
            this.ultraTabPageControl9.Controls.Add(this.BLMngUserCode_uLabel);
            this.ultraTabPageControl9.Controls.Add(this.TimeOut_uLabel);
            this.ultraTabPageControl9.Controls.Add(this.PurchaseAddress_uLabel);
            this.ultraTabPageControl9.Controls.Add(this.RestoreAddress_uLabel);
            this.ultraTabPageControl9.Controls.Add(this.OrderAddress_uLabel);
            this.ultraTabPageControl9.Controls.Add(this.Domain_uLabel);
            this.ultraTabPageControl9.Controls.Add(this.Protocol_uLabel);
            this.ultraTabPageControl9.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl9.Name = "ultraTabPageControl9";
            this.ultraTabPageControl9.Size = new System.Drawing.Size(938, 195);
            // 
            // CarMaker_uButton
            // 
            this.CarMaker_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CarMaker_uButton.Location = new System.Drawing.Point(704, 10);
            this.CarMaker_uButton.Name = "CarMaker_uButton";
            this.CarMaker_uButton.Size = new System.Drawing.Size(80, 25);
            this.CarMaker_uButton.TabIndex = 16;
            this.CarMaker_uButton.Text = "登録";
            this.CarMaker_uButton.Click += new System.EventHandler(this.CarMaker_uButton_Click);
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(228, 162);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(32, 21);
            this.ultraLabel2.TabIndex = 15;
            this.ultraLabel2.Text = "秒";
            // 
            // BLMngUserCode_tEdit
            // 
            appearance258.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BLMngUserCode_tEdit.ActiveAppearance = appearance258;
            appearance269.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance269.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance269.ForeColorDisabled = System.Drawing.Color.Black;
            this.BLMngUserCode_tEdit.Appearance = appearance269;
            this.BLMngUserCode_tEdit.AutoSelect = true;
            this.BLMngUserCode_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BLMngUserCode_tEdit.DataText = "";
            this.BLMngUserCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BLMngUserCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.BLMngUserCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.BLMngUserCode_tEdit.Location = new System.Drawing.Point(434, 157);
            this.BLMngUserCode_tEdit.MaxLength = 9;
            this.BLMngUserCode_tEdit.Name = "BLMngUserCode_tEdit";
            this.BLMngUserCode_tEdit.Size = new System.Drawing.Size(82, 24);
            this.BLMngUserCode_tEdit.TabIndex = 15;
            // 
            // TimeOut_tEdit
            // 
            appearance270.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance270.TextHAlignAsString = "Right";
            this.TimeOut_tEdit.ActiveAppearance = appearance270;
            appearance271.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance271.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance271.ForeColorDisabled = System.Drawing.Color.Black;
            appearance271.TextHAlignAsString = "Right";
            this.TimeOut_tEdit.Appearance = appearance271;
            this.TimeOut_tEdit.AutoSelect = true;
            this.TimeOut_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.TimeOut_tEdit.DataText = "";
            this.TimeOut_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TimeOut_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.TimeOut_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TimeOut_tEdit.Location = new System.Drawing.Point(156, 159);
            this.TimeOut_tEdit.MaxLength = 3;
            this.TimeOut_tEdit.Name = "TimeOut_tEdit";
            this.TimeOut_tEdit.Size = new System.Drawing.Size(66, 24);
            this.TimeOut_tEdit.TabIndex = 14;
            // 
            // PurchaseAddress_tEdit
            // 
            appearance257.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PurchaseAddress_tEdit.ActiveAppearance = appearance257;
            appearance268.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance268.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance268.ForeColorDisabled = System.Drawing.Color.Black;
            this.PurchaseAddress_tEdit.Appearance = appearance268;
            this.PurchaseAddress_tEdit.AutoSelect = true;
            this.PurchaseAddress_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PurchaseAddress_tEdit.DataText = "";
            this.PurchaseAddress_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PurchaseAddress_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.PurchaseAddress_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.PurchaseAddress_tEdit.Location = new System.Drawing.Point(156, 129);
            this.PurchaseAddress_tEdit.MaxLength = 255;
            this.PurchaseAddress_tEdit.Name = "PurchaseAddress_tEdit";
            this.PurchaseAddress_tEdit.Size = new System.Drawing.Size(360, 24);
            this.PurchaseAddress_tEdit.TabIndex = 13;
            // 
            // RestoreAddress_tEdit
            // 
            appearance256.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RestoreAddress_tEdit.ActiveAppearance = appearance256;
            appearance267.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance267.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance267.ForeColorDisabled = System.Drawing.Color.Black;
            this.RestoreAddress_tEdit.Appearance = appearance267;
            this.RestoreAddress_tEdit.AutoSelect = true;
            this.RestoreAddress_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.RestoreAddress_tEdit.DataText = "";
            this.RestoreAddress_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.RestoreAddress_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.RestoreAddress_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.RestoreAddress_tEdit.Location = new System.Drawing.Point(156, 99);
            this.RestoreAddress_tEdit.MaxLength = 255;
            this.RestoreAddress_tEdit.Name = "RestoreAddress_tEdit";
            this.RestoreAddress_tEdit.Size = new System.Drawing.Size(360, 24);
            this.RestoreAddress_tEdit.TabIndex = 12;
            // 
            // OrderAddress_tEdit
            // 
            appearance249.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.OrderAddress_tEdit.ActiveAppearance = appearance249;
            appearance266.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance266.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance266.ForeColorDisabled = System.Drawing.Color.Black;
            this.OrderAddress_tEdit.Appearance = appearance266;
            this.OrderAddress_tEdit.AutoSelect = true;
            this.OrderAddress_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.OrderAddress_tEdit.DataText = "";
            this.OrderAddress_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.OrderAddress_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.OrderAddress_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.OrderAddress_tEdit.Location = new System.Drawing.Point(156, 69);
            this.OrderAddress_tEdit.MaxLength = 255;
            this.OrderAddress_tEdit.Name = "OrderAddress_tEdit";
            this.OrderAddress_tEdit.Size = new System.Drawing.Size(360, 24);
            this.OrderAddress_tEdit.TabIndex = 11;
            // 
            // Domain_tEdit
            // 
            appearance234.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Domain_tEdit.ActiveAppearance = appearance234;
            appearance265.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance265.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance265.ForeColorDisabled = System.Drawing.Color.Black;
            this.Domain_tEdit.Appearance = appearance265;
            this.Domain_tEdit.AutoSelect = true;
            this.Domain_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Domain_tEdit.DataText = "";
            this.Domain_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Domain_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, true, true, true, true, true));
            this.Domain_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Domain_tEdit.Location = new System.Drawing.Point(156, 41);
            this.Domain_tEdit.MaxLength = 255;
            this.Domain_tEdit.Name = "Domain_tEdit";
            this.Domain_tEdit.Size = new System.Drawing.Size(360, 24);
            this.Domain_tEdit.TabIndex = 10;
            // 
            // Connection_tComboEditor
            // 
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance51.ForeColor = System.Drawing.Color.Black;
            appearance51.ForeColorDisabled = System.Drawing.Color.Black;
            this.Connection_tComboEditor.ActiveAppearance = appearance51;
            appearance263.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance263.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance263.ForeColor = System.Drawing.Color.Black;
            appearance263.ForeColorDisabled = System.Drawing.Color.Black;
            this.Connection_tComboEditor.Appearance = appearance263;
            this.Connection_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Connection_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Connection_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance264.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Connection_tComboEditor.ItemAppearance = appearance264;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "Aタイプ";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "Bタイプ";
            valueListItem5.DataValue = 2;
            valueListItem5.DisplayText = "Cタイプ";
            this.Connection_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4,
            valueListItem5});
            this.Connection_tComboEditor.Location = new System.Drawing.Point(379, 10);
            this.Connection_tComboEditor.MaxLength = 1;
            this.Connection_tComboEditor.Name = "Connection_tComboEditor";
            this.Connection_tComboEditor.Size = new System.Drawing.Size(93, 24);
            this.Connection_tComboEditor.TabIndex = 9;
            this.Connection_tComboEditor.Text = "Aタイプ";
            this.Connection_tComboEditor.SelectionChanged += new System.EventHandler(this.Connection_tComboEditor_SelectionChanged);
            // 
            // Protocol_tComboEditor
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance36.ForeColor = System.Drawing.Color.Black;
            appearance36.ForeColorDisabled = System.Drawing.Color.Black;
            this.Protocol_tComboEditor.ActiveAppearance = appearance36;
            appearance261.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance261.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance261.ForeColor = System.Drawing.Color.Black;
            appearance261.ForeColorDisabled = System.Drawing.Color.Black;
            this.Protocol_tComboEditor.Appearance = appearance261;
            this.Protocol_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Protocol_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Protocol_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance262.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Protocol_tComboEditor.ItemAppearance = appearance262;
            valueListItem6.DataValue = 0;
            valueListItem6.DisplayText = "HTTP";
            valueListItem7.DataValue = 1;
            valueListItem7.DisplayText = "HTTPS";
            this.Protocol_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem6,
            valueListItem7});
            this.Protocol_tComboEditor.Location = new System.Drawing.Point(156, 11);
            this.Protocol_tComboEditor.MaxLength = 1;
            this.Protocol_tComboEditor.Name = "Protocol_tComboEditor";
            this.Protocol_tComboEditor.Size = new System.Drawing.Size(84, 24);
            this.Protocol_tComboEditor.TabIndex = 8;
            this.Protocol_tComboEditor.Text = "HTTP";
            // 
            // CarMaker_uLabel
            // 
            appearance260.TextVAlignAsString = "Middle";
            this.CarMaker_uLabel.Appearance = appearance260;
            this.CarMaker_uLabel.Location = new System.Drawing.Point(543, 10);
            this.CarMaker_uLabel.Name = "CarMaker_uLabel";
            this.CarMaker_uLabel.Size = new System.Drawing.Size(137, 23);
            this.CarMaker_uLabel.TabIndex = 7;
            this.CarMaker_uLabel.Text = "外車対応メーカー";
            // 
            // Connection_uLabel
            // 
            appearance259.TextVAlignAsString = "Middle";
            this.Connection_uLabel.Appearance = appearance259;
            this.Connection_uLabel.Location = new System.Drawing.Point(257, 10);
            this.Connection_uLabel.Name = "Connection_uLabel";
            this.Connection_uLabel.Size = new System.Drawing.Size(100, 23);
            this.Connection_uLabel.TabIndex = 6;
            this.Connection_uLabel.Text = "接続区分";
            // 
            // BLMngUserCode_uLabel
            // 
            appearance255.TextVAlignAsString = "Middle";
            this.BLMngUserCode_uLabel.Appearance = appearance255;
            this.BLMngUserCode_uLabel.Location = new System.Drawing.Point(264, 159);
            this.BLMngUserCode_uLabel.Name = "BLMngUserCode_uLabel";
            this.BLMngUserCode_uLabel.Size = new System.Drawing.Size(164, 23);
            this.BLMngUserCode_uLabel.TabIndex = 5;
            this.BLMngUserCode_uLabel.Text = "BL管理ユーザーコード";
            // 
            // TimeOut_uLabel
            // 
            appearance272.TextVAlignAsString = "Middle";
            this.TimeOut_uLabel.Appearance = appearance272;
            this.TimeOut_uLabel.Location = new System.Drawing.Point(3, 157);
            this.TimeOut_uLabel.Name = "TimeOut_uLabel";
            this.TimeOut_uLabel.Size = new System.Drawing.Size(100, 23);
            this.TimeOut_uLabel.TabIndex = 5;
            this.TimeOut_uLabel.Text = "タイムアウト";
            // 
            // PurchaseAddress_uLabel
            // 
            appearance254.TextVAlignAsString = "Middle";
            this.PurchaseAddress_uLabel.Appearance = appearance254;
            this.PurchaseAddress_uLabel.Location = new System.Drawing.Point(3, 128);
            this.PurchaseAddress_uLabel.Name = "PurchaseAddress_uLabel";
            this.PurchaseAddress_uLabel.Size = new System.Drawing.Size(145, 23);
            this.PurchaseAddress_uLabel.TabIndex = 4;
            this.PurchaseAddress_uLabel.Text = "仕入受信用アドレス";
            // 
            // RestoreAddress_uLabel
            // 
            appearance253.TextVAlignAsString = "Middle";
            this.RestoreAddress_uLabel.Appearance = appearance253;
            this.RestoreAddress_uLabel.Location = new System.Drawing.Point(3, 99);
            this.RestoreAddress_uLabel.Name = "RestoreAddress_uLabel";
            this.RestoreAddress_uLabel.Size = new System.Drawing.Size(112, 23);
            this.RestoreAddress_uLabel.TabIndex = 3;
            this.RestoreAddress_uLabel.Text = "復旧用アドレス";
            // 
            // OrderAddress_uLabel
            // 
            appearance252.TextVAlignAsString = "Middle";
            this.OrderAddress_uLabel.Appearance = appearance252;
            this.OrderAddress_uLabel.Location = new System.Drawing.Point(3, 70);
            this.OrderAddress_uLabel.Name = "OrderAddress_uLabel";
            this.OrderAddress_uLabel.Size = new System.Drawing.Size(112, 23);
            this.OrderAddress_uLabel.TabIndex = 2;
            this.OrderAddress_uLabel.Text = "発注用アドレス";
            // 
            // Domain_uLabel
            // 
            appearance251.TextVAlignAsString = "Middle";
            this.Domain_uLabel.Appearance = appearance251;
            this.Domain_uLabel.Location = new System.Drawing.Point(3, 44);
            this.Domain_uLabel.Name = "Domain_uLabel";
            this.Domain_uLabel.Size = new System.Drawing.Size(100, 23);
            this.Domain_uLabel.TabIndex = 1;
            this.Domain_uLabel.Text = "ドメイン";
            // 
            // Protocol_uLabel
            // 
            appearance250.TextVAlignAsString = "Middle";
            this.Protocol_uLabel.Appearance = appearance250;
            this.Protocol_uLabel.Location = new System.Drawing.Point(3, 10);
            this.Protocol_uLabel.Name = "Protocol_uLabel";
            this.Protocol_uLabel.Size = new System.Drawing.Size(100, 23);
            this.Protocol_uLabel.TabIndex = 0;
            this.Protocol_uLabel.Text = "プロトコル";
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 675);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(962, 23);
            this.ultraStatusBar1.SizeGripVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ultraStatusBar1.TabIndex = 26;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(850, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 27;
            this.Mode_Label.Text = "更新モード";
            // 
            // UOESupplierCd_Label
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.UOESupplierCd_Label.Appearance = appearance4;
            this.UOESupplierCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOESupplierCd_Label.Location = new System.Drawing.Point(12, 22);
            this.UOESupplierCd_Label.Name = "UOESupplierCd_Label";
            this.UOESupplierCd_Label.Size = new System.Drawing.Size(123, 23);
            this.UOESupplierCd_Label.TabIndex = 28;
            this.UOESupplierCd_Label.Text = "発注先コード";
            // 
            // UOESupplierName_tEdit
            // 
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOESupplierName_tEdit.ActiveAppearance = appearance45;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOESupplierName_tEdit.Appearance = appearance6;
            this.UOESupplierName_tEdit.AutoSelect = true;
            this.UOESupplierName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.UOESupplierName_tEdit.DataText = "";
            this.UOESupplierName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOESupplierName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.UOESupplierName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.UOESupplierName_tEdit.Location = new System.Drawing.Point(206, 22);
            this.UOESupplierName_tEdit.MaxLength = 30;
            this.UOESupplierName_tEdit.Name = "UOESupplierName_tEdit";
            this.UOESupplierName_tEdit.Size = new System.Drawing.Size(407, 24);
            this.UOESupplierName_tEdit.TabIndex = 1;
            // 
            // GoodsMakerCd_Label
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.GoodsMakerCd_Label.Appearance = appearance7;
            this.GoodsMakerCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.GoodsMakerCd_Label.Location = new System.Drawing.Point(12, 62);
            this.GoodsMakerCd_Label.Name = "GoodsMakerCd_Label";
            this.GoodsMakerCd_Label.Size = new System.Drawing.Size(123, 23);
            this.GoodsMakerCd_Label.TabIndex = 28;
            this.GoodsMakerCd_Label.Text = "メーカーコード";
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel8.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel8.Location = new System.Drawing.Point(10, 52);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(940, 4);
            this.ultraLabel8.TabIndex = 30;
            // 
            // TelNo_Label
            // 
            appearance85.TextVAlignAsString = "Middle";
            this.TelNo_Label.Appearance = appearance85;
            this.TelNo_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.TelNo_Label.Location = new System.Drawing.Point(12, 182);
            this.TelNo_Label.Name = "TelNo_Label";
            this.TelNo_Label.Size = new System.Drawing.Size(123, 23);
            this.TelNo_Label.TabIndex = 28;
            this.TelNo_Label.Text = "電話番号";
            // 
            // UOETerminalCd_Label
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.UOETerminalCd_Label.Appearance = appearance9;
            this.UOETerminalCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOETerminalCd_Label.Location = new System.Drawing.Point(12, 212);
            this.UOETerminalCd_Label.Name = "UOETerminalCd_Label";
            this.UOETerminalCd_Label.Size = new System.Drawing.Size(123, 23);
            this.UOETerminalCd_Label.TabIndex = 28;
            this.UOETerminalCd_Label.Text = "端末コード";
            // 
            // UOEHostCode_Label
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.UOEHostCode_Label.Appearance = appearance10;
            this.UOEHostCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEHostCode_Label.Location = new System.Drawing.Point(12, 242);
            this.UOEHostCode_Label.Name = "UOEHostCode_Label";
            this.UOEHostCode_Label.Size = new System.Drawing.Size(123, 23);
            this.UOEHostCode_Label.TabIndex = 28;
            this.UOEHostCode_Label.Text = "ホストコード";
            // 
            // UOEConnectPassword_Label
            // 
            appearance196.TextVAlignAsString = "Middle";
            this.UOEConnectPassword_Label.Appearance = appearance196;
            this.UOEConnectPassword_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEConnectPassword_Label.Location = new System.Drawing.Point(12, 272);
            this.UOEConnectPassword_Label.Name = "UOEConnectPassword_Label";
            this.UOEConnectPassword_Label.Size = new System.Drawing.Size(123, 23);
            this.UOEConnectPassword_Label.TabIndex = 28;
            this.UOEConnectPassword_Label.Text = "パスワード";
            // 
            // UOEConnectUserId_Label
            // 
            appearance143.TextVAlignAsString = "Middle";
            this.UOEConnectUserId_Label.Appearance = appearance143;
            this.UOEConnectUserId_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEConnectUserId_Label.Location = new System.Drawing.Point(12, 302);
            this.UOEConnectUserId_Label.Name = "UOEConnectUserId_Label";
            this.UOEConnectUserId_Label.Size = new System.Drawing.Size(123, 23);
            this.UOEConnectUserId_Label.TabIndex = 28;
            this.UOEConnectUserId_Label.Text = "ユーザーコード";
            // 
            // UOEIDNum_Label
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.UOEIDNum_Label.Appearance = appearance13;
            this.UOEIDNum_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEIDNum_Label.Location = new System.Drawing.Point(12, 332);
            this.UOEIDNum_Label.Name = "UOEIDNum_Label";
            this.UOEIDNum_Label.Size = new System.Drawing.Size(123, 23);
            this.UOEIDNum_Label.TabIndex = 28;
            this.UOEIDNum_Label.Text = "ＩＤ番号";
            // 
            // CommAssemblyId_Label
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.CommAssemblyId_Label.Appearance = appearance18;
            this.CommAssemblyId_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.CommAssemblyId_Label.Location = new System.Drawing.Point(12, 362);
            this.CommAssemblyId_Label.Name = "CommAssemblyId_Label";
            this.CommAssemblyId_Label.Size = new System.Drawing.Size(123, 23);
            this.CommAssemblyId_Label.TabIndex = 28;
            this.CommAssemblyId_Label.Text = "プログラム";
            // 
            // GoodsMakerNm_tEdit
            // 
            this.GoodsMakerNm_tEdit.ActiveAppearance = appearance163;
            appearance164.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance164.ForeColorDisabled = System.Drawing.Color.Black;
            this.GoodsMakerNm_tEdit.Appearance = appearance164;
            this.GoodsMakerNm_tEdit.AutoSelect = true;
            this.GoodsMakerNm_tEdit.DataText = "";
            this.GoodsMakerNm_tEdit.Enabled = false;
            this.GoodsMakerNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GoodsMakerNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.GoodsMakerNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.GoodsMakerNm_tEdit.Location = new System.Drawing.Point(141, 92);
            this.GoodsMakerNm_tEdit.MaxLength = 30;
            this.GoodsMakerNm_tEdit.Name = "GoodsMakerNm_tEdit";
            this.GoodsMakerNm_tEdit.Size = new System.Drawing.Size(159, 24);
            this.GoodsMakerNm_tEdit.TabIndex = 5;
            this.GoodsMakerNm_tEdit.TabStop = false;
            // 
            // TelNo_tEdit
            // 
            appearance101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TelNo_tEdit.ActiveAppearance = appearance101;
            appearance102.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance102.ForeColorDisabled = System.Drawing.Color.Black;
            this.TelNo_tEdit.Appearance = appearance102;
            this.TelNo_tEdit.AutoSelect = true;
            this.TelNo_tEdit.DataText = "";
            this.TelNo_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TelNo_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TelNo_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TelNo_tEdit.Location = new System.Drawing.Point(141, 182);
            this.TelNo_tEdit.MaxLength = 16;
            this.TelNo_tEdit.Name = "TelNo_tEdit";
            this.TelNo_tEdit.Size = new System.Drawing.Size(144, 24);
            this.TelNo_tEdit.TabIndex = 7;
            // 
            // UOESupplierCd_tNedit
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance20.TextHAlignAsString = "Right";
            this.UOESupplierCd_tNedit.ActiveAppearance = appearance20;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance2.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            this.UOESupplierCd_tNedit.Appearance = appearance2;
            this.UOESupplierCd_tNedit.AutoSelect = true;
            this.UOESupplierCd_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.UOESupplierCd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.UOESupplierCd_tNedit.DataText = "";
            this.UOESupplierCd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOESupplierCd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.UOESupplierCd_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.UOESupplierCd_tNedit.Location = new System.Drawing.Point(141, 22);
            this.UOESupplierCd_tNedit.MaxLength = 6;
            this.UOESupplierCd_tNedit.Name = "UOESupplierCd_tNedit";
            this.UOESupplierCd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.UOESupplierCd_tNedit.Size = new System.Drawing.Size(59, 24);
            this.UOESupplierCd_tNedit.TabIndex = 0;
            // 
            // tNedit_GoodsMakerCdAllowZero
            // 
            appearance111.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance111.TextHAlignAsString = "Right";
            this.tNedit_GoodsMakerCdAllowZero.ActiveAppearance = appearance111;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance14.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Right";
            this.tNedit_GoodsMakerCdAllowZero.Appearance = appearance14;
            this.tNedit_GoodsMakerCdAllowZero.AutoSelect = true;
            this.tNedit_GoodsMakerCdAllowZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_GoodsMakerCdAllowZero.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMakerCdAllowZero.DataText = "";
            this.tNedit_GoodsMakerCdAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMakerCdAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMakerCdAllowZero.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMakerCdAllowZero.Location = new System.Drawing.Point(141, 62);
            this.tNedit_GoodsMakerCdAllowZero.MaxLength = 4;
            this.tNedit_GoodsMakerCdAllowZero.Name = "tNedit_GoodsMakerCdAllowZero";
            this.tNedit_GoodsMakerCdAllowZero.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_GoodsMakerCdAllowZero.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsMakerCdAllowZero.TabIndex = 3;
            // 
            // UOETerminalCd_tEdit
            // 
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOETerminalCd_tEdit.ActiveAppearance = appearance79;
            appearance126.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance126.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOETerminalCd_tEdit.Appearance = appearance126;
            this.UOETerminalCd_tEdit.AutoSelect = true;
            this.UOETerminalCd_tEdit.DataText = "";
            this.UOETerminalCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOETerminalCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOETerminalCd_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOETerminalCd_tEdit.Location = new System.Drawing.Point(141, 212);
            this.UOETerminalCd_tEdit.MaxLength = 7;
            this.UOETerminalCd_tEdit.Name = "UOETerminalCd_tEdit";
            this.UOETerminalCd_tEdit.Size = new System.Drawing.Size(82, 24);
            this.UOETerminalCd_tEdit.TabIndex = 8;
            // 
            // UOEHostCode_tEdit
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEHostCode_tEdit.ActiveAppearance = appearance22;
            appearance42.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance42.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEHostCode_tEdit.Appearance = appearance42;
            this.UOEHostCode_tEdit.AutoSelect = true;
            this.UOEHostCode_tEdit.DataText = "";
            this.UOEHostCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEHostCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOEHostCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEHostCode_tEdit.Location = new System.Drawing.Point(141, 242);
            this.UOEHostCode_tEdit.MaxLength = 7;
            this.UOEHostCode_tEdit.Name = "UOEHostCode_tEdit";
            this.UOEHostCode_tEdit.Size = new System.Drawing.Size(82, 24);
            this.UOEHostCode_tEdit.TabIndex = 9;
            // 
            // UOEConnectPassword_tEdit
            // 
            appearance153.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEConnectPassword_tEdit.ActiveAppearance = appearance153;
            appearance154.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance154.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEConnectPassword_tEdit.Appearance = appearance154;
            this.UOEConnectPassword_tEdit.AutoSelect = true;
            this.UOEConnectPassword_tEdit.DataText = "";
            this.UOEConnectPassword_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEConnectPassword_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.UOEConnectPassword_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEConnectPassword_tEdit.Location = new System.Drawing.Point(141, 272);
            this.UOEConnectPassword_tEdit.MaxLength = 6;
            this.UOEConnectPassword_tEdit.Name = "UOEConnectPassword_tEdit";
            this.UOEConnectPassword_tEdit.Size = new System.Drawing.Size(59, 24);
            this.UOEConnectPassword_tEdit.TabIndex = 10;
            // 
            // UOEConnectUserId_tEdit
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEConnectUserId_tEdit.ActiveAppearance = appearance3;
            appearance44.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance44.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEConnectUserId_tEdit.Appearance = appearance44;
            this.UOEConnectUserId_tEdit.AutoSelect = true;
            this.UOEConnectUserId_tEdit.DataText = "";
            this.UOEConnectUserId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEConnectUserId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOEConnectUserId_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEConnectUserId_tEdit.Location = new System.Drawing.Point(141, 302);
            this.UOEConnectUserId_tEdit.MaxLength = 12;
            this.UOEConnectUserId_tEdit.Name = "UOEConnectUserId_tEdit";
            this.UOEConnectUserId_tEdit.Size = new System.Drawing.Size(105, 24);
            this.UOEConnectUserId_tEdit.TabIndex = 11;
            // 
            // UOEIDNum_tEdit
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEIDNum_tEdit.ActiveAppearance = appearance16;
            appearance46.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance46.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEIDNum_tEdit.Appearance = appearance46;
            this.UOEIDNum_tEdit.AutoSelect = true;
            this.UOEIDNum_tEdit.DataText = "";
            this.UOEIDNum_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEIDNum_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 15, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOEIDNum_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEIDNum_tEdit.Location = new System.Drawing.Point(141, 332);
            this.UOEIDNum_tEdit.MaxLength = 15;
            this.UOEIDNum_tEdit.Name = "UOEIDNum_tEdit";
            this.UOEIDNum_tEdit.Size = new System.Drawing.Size(144, 24);
            this.UOEIDNum_tEdit.TabIndex = 12;
            // 
            // CommAssemblyId_tEdit
            // 
            appearance247.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CommAssemblyId_tEdit.ActiveAppearance = appearance247;
            appearance248.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance248.ForeColorDisabled = System.Drawing.Color.Black;
            this.CommAssemblyId_tEdit.Appearance = appearance248;
            this.CommAssemblyId_tEdit.AutoSelect = true;
            this.CommAssemblyId_tEdit.DataText = "";
            this.CommAssemblyId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CommAssemblyId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(true, false, false, false, false, false, true));
            this.CommAssemblyId_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CommAssemblyId_tEdit.Location = new System.Drawing.Point(141, 362);
            this.CommAssemblyId_tEdit.MaxLength = 4;
            this.CommAssemblyId_tEdit.Name = "CommAssemblyId_tEdit";
            this.CommAssemblyId_tEdit.Size = new System.Drawing.Size(51, 24);
            this.CommAssemblyId_tEdit.TabIndex = 13;
            // 
            // ConnectVersionDiv_Label
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.ConnectVersionDiv_Label.Appearance = appearance5;
            this.ConnectVersionDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.ConnectVersionDiv_Label.Location = new System.Drawing.Point(199, 362);
            this.ConnectVersionDiv_Label.Name = "ConnectVersionDiv_Label";
            this.ConnectVersionDiv_Label.Size = new System.Drawing.Size(52, 23);
            this.ConnectVersionDiv_Label.TabIndex = 28;
            this.ConnectVersionDiv_Label.Text = "Ver";
            // 
            // ConnectVersionDiv_tComboEditor
            // 
            appearance113.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance113.ForeColor = System.Drawing.Color.Black;
            appearance113.ForeColorDisabled = System.Drawing.Color.Black;
            this.ConnectVersionDiv_tComboEditor.ActiveAppearance = appearance113;
            appearance114.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance114.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance114.ForeColor = System.Drawing.Color.Black;
            appearance114.ForeColorDisabled = System.Drawing.Color.Black;
            this.ConnectVersionDiv_tComboEditor.Appearance = appearance114;
            this.ConnectVersionDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ConnectVersionDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ConnectVersionDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance115.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ConnectVersionDiv_tComboEditor.ItemAppearance = appearance115;
            this.ConnectVersionDiv_tComboEditor.Location = new System.Drawing.Point(257, 362);
            this.ConnectVersionDiv_tComboEditor.MaxDropDownItems = 18;
            this.ConnectVersionDiv_tComboEditor.Name = "ConnectVersionDiv_tComboEditor";
            this.ConnectVersionDiv_tComboEditor.Size = new System.Drawing.Size(63, 24);
            this.ConnectVersionDiv_tComboEditor.TabIndex = 14;
            // 
            // UOEShipSectCd_Label
            // 
            appearance27.TextVAlignAsString = "Middle";
            this.UOEShipSectCd_Label.Appearance = appearance27;
            this.UOEShipSectCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEShipSectCd_Label.Location = new System.Drawing.Point(326, 62);
            this.UOEShipSectCd_Label.Name = "UOEShipSectCd_Label";
            this.UOEShipSectCd_Label.Size = new System.Drawing.Size(107, 23);
            this.UOEShipSectCd_Label.TabIndex = 28;
            this.UOEShipSectCd_Label.Text = "出庫拠点";
            // 
            // UOESalSectCd_Label
            // 
            appearance28.TextVAlignAsString = "Middle";
            this.UOESalSectCd_Label.Appearance = appearance28;
            this.UOESalSectCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOESalSectCd_Label.Location = new System.Drawing.Point(326, 92);
            this.UOESalSectCd_Label.Name = "UOESalSectCd_Label";
            this.UOESalSectCd_Label.Size = new System.Drawing.Size(107, 23);
            this.UOESalSectCd_Label.TabIndex = 28;
            this.UOESalSectCd_Label.Text = "売上拠点";
            // 
            // UOEReservSectCd_Label
            // 
            appearance29.TextVAlignAsString = "Middle";
            this.UOEReservSectCd_Label.Appearance = appearance29;
            this.UOEReservSectCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEReservSectCd_Label.Location = new System.Drawing.Point(326, 122);
            this.UOEReservSectCd_Label.Name = "UOEReservSectCd_Label";
            this.UOEReservSectCd_Label.Size = new System.Drawing.Size(107, 23);
            this.UOEReservSectCd_Label.TabIndex = 28;
            this.UOEReservSectCd_Label.Text = "指定拠点";
            // 
            // ReceiveCondition_Label
            // 
            appearance31.TextVAlignAsString = "Middle";
            this.ReceiveCondition_Label.Appearance = appearance31;
            this.ReceiveCondition_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.ReceiveCondition_Label.Location = new System.Drawing.Point(326, 152);
            this.ReceiveCondition_Label.Name = "ReceiveCondition_Label";
            this.ReceiveCondition_Label.Size = new System.Drawing.Size(107, 23);
            this.ReceiveCondition_Label.TabIndex = 28;
            this.ReceiveCondition_Label.Text = "受信有無区分";
            // 
            // SubstPartsNoDiv_Label
            // 
            appearance50.TextVAlignAsString = "Middle";
            this.SubstPartsNoDiv_Label.Appearance = appearance50;
            this.SubstPartsNoDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SubstPartsNoDiv_Label.Location = new System.Drawing.Point(326, 182);
            this.SubstPartsNoDiv_Label.Name = "SubstPartsNoDiv_Label";
            this.SubstPartsNoDiv_Label.Size = new System.Drawing.Size(107, 23);
            this.SubstPartsNoDiv_Label.TabIndex = 28;
            this.SubstPartsNoDiv_Label.Text = "代替品番区分";
            // 
            // PartsNoPrtCd_Label
            // 
            appearance33.TextVAlignAsString = "Middle";
            this.PartsNoPrtCd_Label.Appearance = appearance33;
            this.PartsNoPrtCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.PartsNoPrtCd_Label.Location = new System.Drawing.Point(326, 212);
            this.PartsNoPrtCd_Label.Name = "PartsNoPrtCd_Label";
            this.PartsNoPrtCd_Label.Size = new System.Drawing.Size(107, 23);
            this.PartsNoPrtCd_Label.TabIndex = 28;
            this.PartsNoPrtCd_Label.Text = "品番印刷区分";
            // 
            // ListPriceUseDiv_Label
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.ListPriceUseDiv_Label.Appearance = appearance34;
            this.ListPriceUseDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.ListPriceUseDiv_Label.Location = new System.Drawing.Point(326, 242);
            this.ListPriceUseDiv_Label.Name = "ListPriceUseDiv_Label";
            this.ListPriceUseDiv_Label.Size = new System.Drawing.Size(107, 23);
            this.ListPriceUseDiv_Label.TabIndex = 28;
            this.ListPriceUseDiv_Label.Text = "定価使用区分";
            // 
            // StockSlipDtRecvDiv_Label
            // 
            appearance37.TextVAlignAsString = "Middle";
            this.StockSlipDtRecvDiv_Label.Appearance = appearance37;
            this.StockSlipDtRecvDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.StockSlipDtRecvDiv_Label.Location = new System.Drawing.Point(326, 272);
            this.StockSlipDtRecvDiv_Label.Name = "StockSlipDtRecvDiv_Label";
            this.StockSlipDtRecvDiv_Label.Size = new System.Drawing.Size(107, 23);
            this.StockSlipDtRecvDiv_Label.TabIndex = 28;
            this.StockSlipDtRecvDiv_Label.Text = "仕入受信区分";
            // 
            // CheckCodeDiv_Label
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.CheckCodeDiv_Label.Appearance = appearance8;
            this.CheckCodeDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.CheckCodeDiv_Label.Location = new System.Drawing.Point(326, 302);
            this.CheckCodeDiv_Label.Name = "CheckCodeDiv_Label";
            this.CheckCodeDiv_Label.Size = new System.Drawing.Size(107, 23);
            this.CheckCodeDiv_Label.TabIndex = 28;
            this.CheckCodeDiv_Label.Text = "チェック区分";
            // 
            // UOEShipSectCd_tEdit
            // 
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEShipSectCd_tEdit.ActiveAppearance = appearance38;
            appearance52.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance52.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEShipSectCd_tEdit.Appearance = appearance52;
            this.UOEShipSectCd_tEdit.AutoSelect = true;
            this.UOEShipSectCd_tEdit.DataText = "";
            this.UOEShipSectCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEShipSectCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOEShipSectCd_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEShipSectCd_tEdit.Location = new System.Drawing.Point(439, 62);
            this.UOEShipSectCd_tEdit.MaxLength = 3;
            this.UOEShipSectCd_tEdit.Name = "UOEShipSectCd_tEdit";
            this.UOEShipSectCd_tEdit.Size = new System.Drawing.Size(35, 24);
            this.UOEShipSectCd_tEdit.TabIndex = 15;
            // 
            // UOEShipSectNm_tEdit
            // 
            this.UOEShipSectNm_tEdit.ActiveAppearance = appearance39;
            appearance71.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance71.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEShipSectNm_tEdit.Appearance = appearance71;
            this.UOEShipSectNm_tEdit.AutoSelect = true;
            this.UOEShipSectNm_tEdit.DataText = "";
            this.UOEShipSectNm_tEdit.Enabled = false;
            this.UOEShipSectNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEShipSectNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.UOEShipSectNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEShipSectNm_tEdit.Location = new System.Drawing.Point(481, 62);
            this.UOEShipSectNm_tEdit.MaxLength = 30;
            this.UOEShipSectNm_tEdit.Name = "UOEShipSectNm_tEdit";
            this.UOEShipSectNm_tEdit.Size = new System.Drawing.Size(113, 24);
            this.UOEShipSectNm_tEdit.TabIndex = 29;
            this.UOEShipSectNm_tEdit.TabStop = false;
            // 
            // UOESalSectCd_tEdit
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOESalSectCd_tEdit.ActiveAppearance = appearance40;
            appearance53.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance53.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOESalSectCd_tEdit.Appearance = appearance53;
            this.UOESalSectCd_tEdit.AutoSelect = true;
            this.UOESalSectCd_tEdit.DataText = "";
            this.UOESalSectCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOESalSectCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOESalSectCd_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOESalSectCd_tEdit.Location = new System.Drawing.Point(439, 92);
            this.UOESalSectCd_tEdit.MaxLength = 3;
            this.UOESalSectCd_tEdit.Name = "UOESalSectCd_tEdit";
            this.UOESalSectCd_tEdit.Size = new System.Drawing.Size(35, 24);
            this.UOESalSectCd_tEdit.TabIndex = 17;
            // 
            // UOESalSectNm_tEdit
            // 
            this.UOESalSectNm_tEdit.ActiveAppearance = appearance41;
            appearance74.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance74.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOESalSectNm_tEdit.Appearance = appearance74;
            this.UOESalSectNm_tEdit.AutoSelect = true;
            this.UOESalSectNm_tEdit.DataText = "";
            this.UOESalSectNm_tEdit.Enabled = false;
            this.UOESalSectNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOESalSectNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.UOESalSectNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOESalSectNm_tEdit.Location = new System.Drawing.Point(481, 92);
            this.UOESalSectNm_tEdit.MaxLength = 30;
            this.UOESalSectNm_tEdit.Name = "UOESalSectNm_tEdit";
            this.UOESalSectNm_tEdit.Size = new System.Drawing.Size(113, 24);
            this.UOESalSectNm_tEdit.TabIndex = 29;
            this.UOESalSectNm_tEdit.TabStop = false;
            // 
            // UOEReservSectCd_tEdit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEReservSectCd_tEdit.ActiveAppearance = appearance17;
            appearance54.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance54.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEReservSectCd_tEdit.Appearance = appearance54;
            this.UOEReservSectCd_tEdit.AutoSelect = true;
            this.UOEReservSectCd_tEdit.DataText = "";
            this.UOEReservSectCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEReservSectCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.UOEReservSectCd_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEReservSectCd_tEdit.Location = new System.Drawing.Point(439, 122);
            this.UOEReservSectCd_tEdit.MaxLength = 3;
            this.UOEReservSectCd_tEdit.Name = "UOEReservSectCd_tEdit";
            this.UOEReservSectCd_tEdit.Size = new System.Drawing.Size(35, 24);
            this.UOEReservSectCd_tEdit.TabIndex = 19;
            // 
            // UOEReservSectNm_tEdit
            // 
            this.UOEReservSectNm_tEdit.ActiveAppearance = appearance21;
            appearance75.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance75.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEReservSectNm_tEdit.Appearance = appearance75;
            this.UOEReservSectNm_tEdit.AutoSelect = true;
            this.UOEReservSectNm_tEdit.DataText = "";
            this.UOEReservSectNm_tEdit.Enabled = false;
            this.UOEReservSectNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEReservSectNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.UOEReservSectNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEReservSectNm_tEdit.Location = new System.Drawing.Point(481, 122);
            this.UOEReservSectNm_tEdit.MaxLength = 30;
            this.UOEReservSectNm_tEdit.Name = "UOEReservSectNm_tEdit";
            this.UOEReservSectNm_tEdit.Size = new System.Drawing.Size(113, 24);
            this.UOEReservSectNm_tEdit.TabIndex = 29;
            this.UOEReservSectNm_tEdit.TabStop = false;
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.UOEOrderRate_Label);
            this.ultraGroupBox1.Controls.Add(this.BoCode_Label);
            this.ultraGroupBox1.Controls.Add(this.DeliveredGoodsDiv_Label);
            this.ultraGroupBox1.Controls.Add(this.EmployeeCode_Label);
            this.ultraGroupBox1.Controls.Add(this.uButton_EmployeeGuide);
            this.ultraGroupBox1.Controls.Add(this.UOEResvdSection_Label);
            this.ultraGroupBox1.Controls.Add(this.BusinessCode_Label);
            this.ultraGroupBox1.Controls.Add(this.BoCode_tComboEditor);
            this.ultraGroupBox1.Controls.Add(this.DeliveredGoodsDiv_tComboEditor);
            this.ultraGroupBox1.Controls.Add(this.UOEResvdSection_tComboEditor);
            this.ultraGroupBox1.Controls.Add(this.BusinessCode_tComboEditor);
            this.ultraGroupBox1.Controls.Add(this.tEdit_EmployeeCode);
            this.ultraGroupBox1.Controls.Add(this.UOEOrderRate_tEdit);
            this.ultraGroupBox1.Controls.Add(this.tEdit_EmployeeName);
            this.ultraGroupBox1.Location = new System.Drawing.Point(642, 62);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(296, 255);
            this.ultraGroupBox1.TabIndex = 27;
            this.ultraGroupBox1.Text = "初期値設定項目";
            // 
            // UOEOrderRate_Label
            // 
            appearance116.TextVAlignAsString = "Middle";
            this.UOEOrderRate_Label.Appearance = appearance116;
            this.UOEOrderRate_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEOrderRate_Label.Location = new System.Drawing.Point(6, 210);
            this.UOEOrderRate_Label.Name = "UOEOrderRate_Label";
            this.UOEOrderRate_Label.Size = new System.Drawing.Size(79, 23);
            this.UOEOrderRate_Label.TabIndex = 28;
            this.UOEOrderRate_Label.Text = "レート";
            // 
            // BoCode_Label
            // 
            appearance117.TextVAlignAsString = "Middle";
            this.BoCode_Label.Appearance = appearance117;
            this.BoCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BoCode_Label.Location = new System.Drawing.Point(6, 180);
            this.BoCode_Label.Name = "BoCode_Label";
            this.BoCode_Label.Size = new System.Drawing.Size(79, 23);
            this.BoCode_Label.TabIndex = 28;
            this.BoCode_Label.Text = "ＢＯ区分";
            // 
            // DeliveredGoodsDiv_Label
            // 
            appearance118.TextVAlignAsString = "Middle";
            this.DeliveredGoodsDiv_Label.Appearance = appearance118;
            this.DeliveredGoodsDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DeliveredGoodsDiv_Label.Location = new System.Drawing.Point(6, 150);
            this.DeliveredGoodsDiv_Label.Name = "DeliveredGoodsDiv_Label";
            this.DeliveredGoodsDiv_Label.Size = new System.Drawing.Size(79, 23);
            this.DeliveredGoodsDiv_Label.TabIndex = 28;
            this.DeliveredGoodsDiv_Label.Text = "納品区分";
            // 
            // EmployeeCode_Label
            // 
            appearance119.TextVAlignAsString = "Middle";
            this.EmployeeCode_Label.Appearance = appearance119;
            this.EmployeeCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.EmployeeCode_Label.Location = new System.Drawing.Point(6, 90);
            this.EmployeeCode_Label.Name = "EmployeeCode_Label";
            this.EmployeeCode_Label.Size = new System.Drawing.Size(79, 23);
            this.EmployeeCode_Label.TabIndex = 28;
            this.EmployeeCode_Label.Text = "依頼者";
            // 
            // uButton_EmployeeGuide
            // 
            appearance180.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance180.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EmployeeGuide.Appearance = appearance180;
            this.uButton_EmployeeGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EmployeeGuide.Location = new System.Drawing.Point(163, 90);
            this.uButton_EmployeeGuide.Name = "uButton_EmployeeGuide";
            this.uButton_EmployeeGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EmployeeGuide.TabIndex = 4;
            this.uButton_EmployeeGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EmployeeGuide.Click += new System.EventHandler(this.uButton_EmployeeGuide_Click);
            // 
            // UOEResvdSection_Label
            // 
            appearance43.TextVAlignAsString = "Middle";
            this.UOEResvdSection_Label.Appearance = appearance43;
            this.UOEResvdSection_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOEResvdSection_Label.Location = new System.Drawing.Point(6, 60);
            this.UOEResvdSection_Label.Name = "UOEResvdSection_Label";
            this.UOEResvdSection_Label.Size = new System.Drawing.Size(79, 23);
            this.UOEResvdSection_Label.TabIndex = 28;
            this.UOEResvdSection_Label.Text = "指定拠点";
            // 
            // BusinessCode_Label
            // 
            appearance121.TextVAlignAsString = "Middle";
            this.BusinessCode_Label.Appearance = appearance121;
            this.BusinessCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BusinessCode_Label.Location = new System.Drawing.Point(6, 30);
            this.BusinessCode_Label.Name = "BusinessCode_Label";
            this.BusinessCode_Label.Size = new System.Drawing.Size(79, 23);
            this.BusinessCode_Label.TabIndex = 28;
            this.BusinessCode_Label.Text = "業務区分";
            // 
            // BoCode_tComboEditor
            // 
            appearance273.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance273.ForeColor = System.Drawing.Color.Black;
            appearance273.ForeColorDisabled = System.Drawing.Color.Black;
            this.BoCode_tComboEditor.ActiveAppearance = appearance273;
            appearance274.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance274.ForeColor = System.Drawing.Color.Black;
            appearance274.ForeColorDisabled = System.Drawing.Color.Black;
            this.BoCode_tComboEditor.Appearance = appearance274;
            this.BoCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BoCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance275.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BoCode_tComboEditor.ItemAppearance = appearance275;
            this.BoCode_tComboEditor.Location = new System.Drawing.Point(91, 180);
            this.BoCode_tComboEditor.MaxDropDownItems = 18;
            this.BoCode_tComboEditor.Name = "BoCode_tComboEditor";
            this.BoCode_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.BoCode_tComboEditor.TabIndex = 6;
            // 
            // DeliveredGoodsDiv_tComboEditor
            // 
            appearance165.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance165.ForeColor = System.Drawing.Color.Black;
            appearance165.ForeColorDisabled = System.Drawing.Color.Black;
            this.DeliveredGoodsDiv_tComboEditor.ActiveAppearance = appearance165;
            appearance166.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance166.ForeColor = System.Drawing.Color.Black;
            appearance166.ForeColorDisabled = System.Drawing.Color.Black;
            this.DeliveredGoodsDiv_tComboEditor.Appearance = appearance166;
            this.DeliveredGoodsDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DeliveredGoodsDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance167.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DeliveredGoodsDiv_tComboEditor.ItemAppearance = appearance167;
            this.DeliveredGoodsDiv_tComboEditor.Location = new System.Drawing.Point(91, 150);
            this.DeliveredGoodsDiv_tComboEditor.MaxDropDownItems = 18;
            this.DeliveredGoodsDiv_tComboEditor.Name = "DeliveredGoodsDiv_tComboEditor";
            this.DeliveredGoodsDiv_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.DeliveredGoodsDiv_tComboEditor.TabIndex = 5;
            // 
            // UOEResvdSection_tComboEditor
            // 
            appearance73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance73.ForeColor = System.Drawing.Color.Black;
            appearance73.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEResvdSection_tComboEditor.ActiveAppearance = appearance73;
            appearance178.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance178.ForeColor = System.Drawing.Color.Black;
            appearance178.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEResvdSection_tComboEditor.Appearance = appearance178;
            this.UOEResvdSection_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.UOEResvdSection_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance179.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEResvdSection_tComboEditor.ItemAppearance = appearance179;
            this.UOEResvdSection_tComboEditor.Location = new System.Drawing.Point(91, 60);
            this.UOEResvdSection_tComboEditor.MaxDropDownItems = 18;
            this.UOEResvdSection_tComboEditor.Name = "UOEResvdSection_tComboEditor";
            this.UOEResvdSection_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.UOEResvdSection_tComboEditor.TabIndex = 2;
            // 
            // BusinessCode_tComboEditor
            // 
            appearance158.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance158.ForeColor = System.Drawing.Color.Black;
            appearance158.ForeColorDisabled = System.Drawing.Color.Black;
            this.BusinessCode_tComboEditor.ActiveAppearance = appearance158;
            appearance159.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance159.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance159.ForeColor = System.Drawing.Color.Black;
            appearance159.ForeColorDisabled = System.Drawing.Color.Black;
            this.BusinessCode_tComboEditor.Appearance = appearance159;
            this.BusinessCode_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BusinessCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BusinessCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance160.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BusinessCode_tComboEditor.ItemAppearance = appearance160;
            this.BusinessCode_tComboEditor.Location = new System.Drawing.Point(91, 30);
            this.BusinessCode_tComboEditor.MaxDropDownItems = 18;
            this.BusinessCode_tComboEditor.Name = "BusinessCode_tComboEditor";
            this.BusinessCode_tComboEditor.Size = new System.Drawing.Size(139, 24);
            this.BusinessCode_tComboEditor.TabIndex = 1;
            // 
            // tEdit_EmployeeCode
            // 
            appearance125.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance125.TextHAlignAsString = "Right";
            this.tEdit_EmployeeCode.ActiveAppearance = appearance125;
            appearance80.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance80.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_EmployeeCode.Appearance = appearance80;
            this.tEdit_EmployeeCode.AutoSelect = true;
            this.tEdit_EmployeeCode.DataText = "";
            this.tEdit_EmployeeCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_EmployeeCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_EmployeeCode.Location = new System.Drawing.Point(91, 90);
            this.tEdit_EmployeeCode.MaxLength = 5;
            this.tEdit_EmployeeCode.Name = "tEdit_EmployeeCode";
            this.tEdit_EmployeeCode.Size = new System.Drawing.Size(66, 24);
            this.tEdit_EmployeeCode.TabIndex = 3;
            // 
            // UOEOrderRate_tEdit
            // 
            appearance171.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOEOrderRate_tEdit.ActiveAppearance = appearance171;
            appearance172.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance172.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOEOrderRate_tEdit.Appearance = appearance172;
            this.UOEOrderRate_tEdit.AutoSelect = true;
            this.UOEOrderRate_tEdit.DataText = "L1000";
            this.UOEOrderRate_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UOEOrderRate_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.UOEOrderRate_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UOEOrderRate_tEdit.Location = new System.Drawing.Point(91, 210);
            this.UOEOrderRate_tEdit.MaxLength = 5;
            this.UOEOrderRate_tEdit.Name = "UOEOrderRate_tEdit";
            this.UOEOrderRate_tEdit.Size = new System.Drawing.Size(66, 24);
            this.UOEOrderRate_tEdit.TabIndex = 7;
            this.UOEOrderRate_tEdit.Text = "L1000";
            // 
            // tEdit_EmployeeName
            // 
            this.tEdit_EmployeeName.ActiveAppearance = appearance129;
            appearance152.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance152.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_EmployeeName.Appearance = appearance152;
            this.tEdit_EmployeeName.AutoSelect = true;
            this.tEdit_EmployeeName.DataText = "";
            this.tEdit_EmployeeName.Enabled = false;
            this.tEdit_EmployeeName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_EmployeeName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_EmployeeName.Location = new System.Drawing.Point(91, 120);
            this.tEdit_EmployeeName.MaxLength = 30;
            this.tEdit_EmployeeName.Name = "tEdit_EmployeeName";
            this.tEdit_EmployeeName.Size = new System.Drawing.Size(159, 24);
            this.tEdit_EmployeeName.TabIndex = 29;
            this.tEdit_EmployeeName.TabStop = false;
            // 
            // ReceiveCondition_tComboEditor
            // 
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance56.ForeColor = System.Drawing.Color.Black;
            appearance56.ForeColorDisabled = System.Drawing.Color.Black;
            this.ReceiveCondition_tComboEditor.ActiveAppearance = appearance56;
            appearance57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance57.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance57.ForeColor = System.Drawing.Color.Black;
            appearance57.ForeColorDisabled = System.Drawing.Color.Black;
            this.ReceiveCondition_tComboEditor.Appearance = appearance57;
            this.ReceiveCondition_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ReceiveCondition_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ReceiveCondition_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ReceiveCondition_tComboEditor.ItemAppearance = appearance58;
            this.ReceiveCondition_tComboEditor.Location = new System.Drawing.Point(438, 152);
            this.ReceiveCondition_tComboEditor.MaxDropDownItems = 18;
            this.ReceiveCondition_tComboEditor.Name = "ReceiveCondition_tComboEditor";
            this.ReceiveCondition_tComboEditor.Size = new System.Drawing.Size(187, 24);
            this.ReceiveCondition_tComboEditor.TabIndex = 21;
            // 
            // SubstPartsNoDiv_tComboEditor
            // 
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance59.ForeColor = System.Drawing.Color.Black;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            this.SubstPartsNoDiv_tComboEditor.ActiveAppearance = appearance59;
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance60.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance60.ForeColor = System.Drawing.Color.Black;
            appearance60.ForeColorDisabled = System.Drawing.Color.Black;
            this.SubstPartsNoDiv_tComboEditor.Appearance = appearance60;
            this.SubstPartsNoDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SubstPartsNoDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SubstPartsNoDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SubstPartsNoDiv_tComboEditor.ItemAppearance = appearance61;
            this.SubstPartsNoDiv_tComboEditor.Location = new System.Drawing.Point(439, 182);
            this.SubstPartsNoDiv_tComboEditor.MaxDropDownItems = 18;
            this.SubstPartsNoDiv_tComboEditor.Name = "SubstPartsNoDiv_tComboEditor";
            this.SubstPartsNoDiv_tComboEditor.Size = new System.Drawing.Size(187, 24);
            this.SubstPartsNoDiv_tComboEditor.TabIndex = 22;
            // 
            // PartsNoPrtCd_tComboEditor
            // 
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance62.ForeColor = System.Drawing.Color.Black;
            appearance62.ForeColorDisabled = System.Drawing.Color.Black;
            this.PartsNoPrtCd_tComboEditor.ActiveAppearance = appearance62;
            appearance63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance63.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance63.ForeColor = System.Drawing.Color.Black;
            appearance63.ForeColorDisabled = System.Drawing.Color.Black;
            this.PartsNoPrtCd_tComboEditor.Appearance = appearance63;
            this.PartsNoPrtCd_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PartsNoPrtCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PartsNoPrtCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartsNoPrtCd_tComboEditor.ItemAppearance = appearance64;
            this.PartsNoPrtCd_tComboEditor.Location = new System.Drawing.Point(439, 212);
            this.PartsNoPrtCd_tComboEditor.MaxDropDownItems = 18;
            this.PartsNoPrtCd_tComboEditor.Name = "PartsNoPrtCd_tComboEditor";
            this.PartsNoPrtCd_tComboEditor.Size = new System.Drawing.Size(187, 24);
            this.PartsNoPrtCd_tComboEditor.TabIndex = 23;
            // 
            // ListPriceUseDiv_tComboEditor
            // 
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance65.ForeColor = System.Drawing.Color.Black;
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            this.ListPriceUseDiv_tComboEditor.ActiveAppearance = appearance65;
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance66.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance66.ForeColor = System.Drawing.Color.Black;
            appearance66.ForeColorDisabled = System.Drawing.Color.Black;
            this.ListPriceUseDiv_tComboEditor.Appearance = appearance66;
            this.ListPriceUseDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ListPriceUseDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ListPriceUseDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ListPriceUseDiv_tComboEditor.ItemAppearance = appearance67;
            this.ListPriceUseDiv_tComboEditor.Location = new System.Drawing.Point(439, 242);
            this.ListPriceUseDiv_tComboEditor.MaxDropDownItems = 18;
            this.ListPriceUseDiv_tComboEditor.Name = "ListPriceUseDiv_tComboEditor";
            this.ListPriceUseDiv_tComboEditor.Size = new System.Drawing.Size(187, 24);
            this.ListPriceUseDiv_tComboEditor.TabIndex = 24;
            // 
            // StockSlipDtRecvDiv_tComboEditor
            // 
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance68.ForeColor = System.Drawing.Color.Black;
            appearance68.ForeColorDisabled = System.Drawing.Color.Black;
            this.StockSlipDtRecvDiv_tComboEditor.ActiveAppearance = appearance68;
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance69.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance69.ForeColor = System.Drawing.Color.Black;
            appearance69.ForeColorDisabled = System.Drawing.Color.Black;
            this.StockSlipDtRecvDiv_tComboEditor.Appearance = appearance69;
            this.StockSlipDtRecvDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.StockSlipDtRecvDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.StockSlipDtRecvDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockSlipDtRecvDiv_tComboEditor.ItemAppearance = appearance70;
            this.StockSlipDtRecvDiv_tComboEditor.Location = new System.Drawing.Point(439, 272);
            this.StockSlipDtRecvDiv_tComboEditor.MaxDropDownItems = 18;
            this.StockSlipDtRecvDiv_tComboEditor.Name = "StockSlipDtRecvDiv_tComboEditor";
            this.StockSlipDtRecvDiv_tComboEditor.Size = new System.Drawing.Size(187, 24);
            this.StockSlipDtRecvDiv_tComboEditor.TabIndex = 25;
            // 
            // CheckCodeDiv_tComboEditor
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            this.CheckCodeDiv_tComboEditor.ActiveAppearance = appearance23;
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance24.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.ForeColorDisabled = System.Drawing.Color.Black;
            this.CheckCodeDiv_tComboEditor.Appearance = appearance24;
            this.CheckCodeDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CheckCodeDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.CheckCodeDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CheckCodeDiv_tComboEditor.ItemAppearance = appearance25;
            this.CheckCodeDiv_tComboEditor.Location = new System.Drawing.Point(439, 302);
            this.CheckCodeDiv_tComboEditor.MaxDropDownItems = 18;
            this.CheckCodeDiv_tComboEditor.Name = "CheckCodeDiv_tComboEditor";
            this.CheckCodeDiv_tComboEditor.Size = new System.Drawing.Size(187, 24);
            this.CheckCodeDiv_tComboEditor.TabIndex = 26;
            // 
            // ultraLabel26
            // 
            this.ultraLabel26.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel26.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel26.Location = new System.Drawing.Point(10, 392);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(940, 4);
            this.ultraLabel26.TabIndex = 30;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(825, 635);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 60;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(694, 635);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 58;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(566, 635);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 57;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(694, 635);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 59;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraLabel33
            // 
            this.ultraLabel33.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel33.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel33.Location = new System.Drawing.Point(12, 625);
            this.ultraLabel33.Name = "ultraLabel33";
            this.ultraLabel33.Size = new System.Drawing.Size(940, 4);
            this.ultraLabel33.TabIndex = 30;
            // 
            // uButton_UOESupplierGuide
            // 
            appearance149.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance149.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_UOESupplierGuide.Appearance = appearance149;
            this.uButton_UOESupplierGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_UOESupplierGuide.Location = new System.Drawing.Point(619, 22);
            this.uButton_UOESupplierGuide.Name = "uButton_UOESupplierGuide";
            this.uButton_UOESupplierGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_UOESupplierGuide.TabIndex = 2;
            this.uButton_UOESupplierGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_UOESupplierGuide.Click += new System.EventHandler(this.uButton_UOESupplierGuide_Click);
            // 
            // uButton_UOEShipSectGuide
            // 
            appearance150.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance150.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_UOEShipSectGuide.Appearance = appearance150;
            this.uButton_UOEShipSectGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_UOEShipSectGuide.Location = new System.Drawing.Point(600, 62);
            this.uButton_UOEShipSectGuide.Name = "uButton_UOEShipSectGuide";
            this.uButton_UOEShipSectGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_UOEShipSectGuide.TabIndex = 16;
            this.uButton_UOEShipSectGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_UOEShipSectGuide.Click += new System.EventHandler(this.uButton_UOEShipSectGuide_Click);
            // 
            // uButton_UOESalSectGuide
            // 
            appearance151.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance151.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_UOESalSectGuide.Appearance = appearance151;
            this.uButton_UOESalSectGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_UOESalSectGuide.Location = new System.Drawing.Point(600, 92);
            this.uButton_UOESalSectGuide.Name = "uButton_UOESalSectGuide";
            this.uButton_UOESalSectGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_UOESalSectGuide.TabIndex = 18;
            this.uButton_UOESalSectGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_UOESalSectGuide.Click += new System.EventHandler(this.uButton_UOESalSectGuide_Click);
            // 
            // uButton_UOEReservSectGuide
            // 
            appearance173.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance173.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_UOEReservSectGuide.Appearance = appearance173;
            this.uButton_UOEReservSectGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_UOEReservSectGuide.Location = new System.Drawing.Point(600, 122);
            this.uButton_UOEReservSectGuide.Name = "uButton_UOEReservSectGuide";
            this.uButton_UOEReservSectGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_UOEReservSectGuide.TabIndex = 20;
            this.uButton_UOEReservSectGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_UOEReservSectGuide.Click += new System.EventHandler(this.uButton_UOEReservSectGuide_Click);
            // 
            // uButton_MakerGuide
            // 
            appearance157.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance157.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_MakerGuide.Appearance = appearance157;
            this.uButton_MakerGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_MakerGuide.Location = new System.Drawing.Point(190, 62);
            this.uButton_MakerGuide.Name = "uButton_MakerGuide";
            this.uButton_MakerGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_MakerGuide.TabIndex = 4;
            this.uButton_MakerGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_MakerGuide.Click += new System.EventHandler(this.uButton_MakerGuide_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // SupplierCd_Label
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.SupplierCd_Label.Appearance = appearance30;
            this.SupplierCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SupplierCd_Label.Location = new System.Drawing.Point(12, 122);
            this.SupplierCd_Label.Name = "SupplierCd_Label";
            this.SupplierCd_Label.Size = new System.Drawing.Size(123, 23);
            this.SupplierCd_Label.TabIndex = 61;
            this.SupplierCd_Label.Text = "仕入先コード";
            // 
            // tNedit_SupplierCd
            // 
            appearance112.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance112.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd.ActiveAppearance = appearance112;
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance32.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_SupplierCd.Appearance = appearance32;
            this.tNedit_SupplierCd.AutoSelect = true;
            this.tNedit_SupplierCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_SupplierCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd.DataText = "";
            this.tNedit_SupplierCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tNedit_SupplierCd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tNedit_SupplierCd.Location = new System.Drawing.Point(141, 122);
            this.tNedit_SupplierCd.MaxLength = 9;
            this.tNedit_SupplierCd.Name = "tNedit_SupplierCd";
            this.tNedit_SupplierCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SupplierCd.Size = new System.Drawing.Size(59, 24);
            this.tNedit_SupplierCd.TabIndex = 5;
            // 
            // uButton_SupplierGuide
            // 
            appearance141.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance141.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SupplierGuide.Appearance = appearance141;
            this.uButton_SupplierGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SupplierGuide.Location = new System.Drawing.Point(206, 122);
            this.uButton_SupplierGuide.Name = "uButton_SupplierGuide";
            this.uButton_SupplierGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SupplierGuide.TabIndex = 6;
            this.uButton_SupplierGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SupplierGuide.Click += new System.EventHandler(this.ultraButton_SupplierGuide_Click);
            // 
            // SupplierNm_tEdit
            // 
            this.SupplierNm_tEdit.ActiveAppearance = appearance110;
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.SupplierNm_tEdit.Appearance = appearance15;
            this.SupplierNm_tEdit.AutoSelect = true;
            this.SupplierNm_tEdit.DataText = "";
            this.SupplierNm_tEdit.Enabled = false;
            this.SupplierNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SupplierNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SupplierNm_tEdit.Location = new System.Drawing.Point(141, 152);
            this.SupplierNm_tEdit.MaxLength = 30;
            this.SupplierNm_tEdit.Name = "SupplierNm_tEdit";
            this.SupplierNm_tEdit.Size = new System.Drawing.Size(159, 24);
            this.SupplierNm_tEdit.TabIndex = 7;
            this.SupplierNm_tEdit.TabStop = false;
            // 
            // Maker_ultraTabControl
            // 
            this.Maker_ultraTabControl.Location = new System.Drawing.Point(0, 0);
            this.Maker_ultraTabControl.Name = "Maker_ultraTabControl";
            this.Maker_ultraTabControl.SharedControlsPage = null;
            this.Maker_ultraTabControl.Size = new System.Drawing.Size(200, 100);
            this.Maker_ultraTabControl.TabIndex = 0;
            // 
            // Mazda_AnswerAutoDiv_ultraLabel
            // 
            appearance194.BackColor = System.Drawing.Color.White;
            appearance194.BackColor2 = System.Drawing.Color.LightPink;
            appearance194.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Mazda_AnswerAutoDiv_ultraLabel.ActiveTabAppearance = appearance194;
            appearance195.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.Mazda_AnswerAutoDiv_ultraLabel.Appearance = appearance195;
            appearance197.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.Mazda_AnswerAutoDiv_ultraLabel.ClientAreaAppearance = appearance197;
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabSharedControlsPage1);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl1);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl2);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl3);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl4);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl5);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl6);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl7);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl8);
            this.Mazda_AnswerAutoDiv_ultraLabel.Controls.Add(this.ultraTabPageControl9);
            this.Mazda_AnswerAutoDiv_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Mazda_AnswerAutoDiv_ultraLabel.Location = new System.Drawing.Point(10, 402);
            this.Mazda_AnswerAutoDiv_ultraLabel.Name = "Mazda_AnswerAutoDiv_ultraLabel";
            this.Mazda_AnswerAutoDiv_ultraLabel.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.Mazda_AnswerAutoDiv_ultraLabel.Size = new System.Drawing.Size(940, 217);
            this.Mazda_AnswerAutoDiv_ultraLabel.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Mazda_AnswerAutoDiv_ultraLabel.TabIndex = 28;
            this.Mazda_AnswerAutoDiv_ultraLabel.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowFixed;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "発注可能メーカー";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "三菱項目・新マツダ項目・ホンダ項目";
            ultraTab3.TabPage = this.ultraTabPageControl3;
            ultraTab3.Text = "ホンダe-Parts項目";
            ultraTab4.TabPage = this.ultraTabPageControl4;
            ultraTab4.Text = "トヨタ電子カタログ連動項目";
            ultraTab5.TabPage = this.ultraTabPageControl5;
            ultraTab5.Text = "日産Web-UOE連動項目";
            ultraTab6.TabPage = this.ultraTabPageControl6;
            ultraTab6.Text = "三菱WebUOE連動項目";
            ultraTab7.TabPage = this.ultraTabPageControl7;
            ultraTab7.Text = "明治UOEWeb項目";
            ultraTab8.TabPage = this.ultraTabPageControl8;
            ultraTab8.Text = "マツダWEB-UOE連動項目";
            ultraTab9.TabPage = this.ultraTabPageControl9;
            ultraTab9.Text = "卸NET-WEB項目";
            this.Mazda_AnswerAutoDiv_ultraLabel.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2,
            ultraTab3,
            ultraTab4,
            ultraTab5,
            ultraTab6,
            ultraTab7,
            ultraTab8,
            ultraTab9});
            this.Mazda_AnswerAutoDiv_ultraLabel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Mazda_AnswerAutoDiv_ultraLabel.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(938, 195);
            // 
            // PMUOE09020UA
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(962, 698);
            this.Controls.Add(this.Mazda_AnswerAutoDiv_ultraLabel);
            this.Controls.Add(this.SupplierNm_tEdit);
            this.Controls.Add(this.uButton_SupplierGuide);
            this.Controls.Add(this.tNedit_SupplierCd);
            this.Controls.Add(this.SupplierCd_Label);
            this.Controls.Add(this.uButton_UOEReservSectGuide);
            this.Controls.Add(this.uButton_UOESalSectGuide);
            this.Controls.Add(this.uButton_MakerGuide);
            this.Controls.Add(this.uButton_UOEShipSectGuide);
            this.Controls.Add(this.uButton_UOESupplierGuide);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.CheckCodeDiv_tComboEditor);
            this.Controls.Add(this.StockSlipDtRecvDiv_tComboEditor);
            this.Controls.Add(this.ListPriceUseDiv_tComboEditor);
            this.Controls.Add(this.PartsNoPrtCd_tComboEditor);
            this.Controls.Add(this.SubstPartsNoDiv_tComboEditor);
            this.Controls.Add(this.ReceiveCondition_tComboEditor);
            this.Controls.Add(this.ConnectVersionDiv_tComboEditor);
            this.Controls.Add(this.tNedit_GoodsMakerCdAllowZero);
            this.Controls.Add(this.UOESupplierCd_tNedit);
            this.Controls.Add(this.ultraLabel33);
            this.Controls.Add(this.ultraLabel26);
            this.Controls.Add(this.ultraLabel8);
            this.Controls.Add(this.UOESupplierName_tEdit);
            this.Controls.Add(this.GoodsMakerNm_tEdit);
            this.Controls.Add(this.UOEConnectUserId_tEdit);
            this.Controls.Add(this.UOEReservSectCd_tEdit);
            this.Controls.Add(this.UOESalSectCd_tEdit);
            this.Controls.Add(this.UOEShipSectCd_tEdit);
            this.Controls.Add(this.CommAssemblyId_tEdit);
            this.Controls.Add(this.UOEConnectPassword_tEdit);
            this.Controls.Add(this.UOEHostCode_tEdit);
            this.Controls.Add(this.UOEReservSectNm_tEdit);
            this.Controls.Add(this.UOESalSectNm_tEdit);
            this.Controls.Add(this.UOEShipSectNm_tEdit);
            this.Controls.Add(this.UOETerminalCd_tEdit);
            this.Controls.Add(this.UOEIDNum_tEdit);
            this.Controls.Add(this.TelNo_tEdit);
            this.Controls.Add(this.ConnectVersionDiv_Label);
            this.Controls.Add(this.CommAssemblyId_Label);
            this.Controls.Add(this.UOEIDNum_Label);
            this.Controls.Add(this.UOEConnectUserId_Label);
            this.Controls.Add(this.UOEConnectPassword_Label);
            this.Controls.Add(this.UOEHostCode_Label);
            this.Controls.Add(this.UOETerminalCd_Label);
            this.Controls.Add(this.CheckCodeDiv_Label);
            this.Controls.Add(this.StockSlipDtRecvDiv_Label);
            this.Controls.Add(this.ListPriceUseDiv_Label);
            this.Controls.Add(this.PartsNoPrtCd_Label);
            this.Controls.Add(this.SubstPartsNoDiv_Label);
            this.Controls.Add(this.ReceiveCondition_Label);
            this.Controls.Add(this.UOEReservSectCd_Label);
            this.Controls.Add(this.UOESalSectCd_Label);
            this.Controls.Add(this.UOEShipSectCd_Label);
            this.Controls.Add(this.TelNo_Label);
            this.Controls.Add(this.GoodsMakerCd_Label);
            this.Controls.Add(this.UOESupplierCd_Label);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMUOE09020UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UOE発注先マスタ設定";
            this.Load += new System.EventHandler(this.PMUOE09020UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMUOE09020UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMUOE09020UA_Closing);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd6_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd5_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd4_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd3_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd2_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd1_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd6_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd5_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd4_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd3_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd2_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerCd1_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm6_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm5_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm4_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableOdrMakerNm1_tEdit)).EndInit();
            this.ultraTabPageControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.instrumentNo_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HondaSectionCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEItemCd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOETestMode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).EndInit();
            this.ultraGroupBox4.ResumeLayout(false);
            this.ultraGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MazdaSectionCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).EndInit();
            this.ultraGroupBox5.ResumeLayout(false);
            this.ultraGroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmergencyDiv_tComboEditor)).EndInit();
            this.ultraTabPageControl3.ResumeLayout(false);
            this.ultraTabPageControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EPartsPassWord_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EPartsUserId_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEePartsItemCd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginTimeoutVal_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InqOrdDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEForcedTermUrl_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEStockCheckUrl_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEOrderUrl_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOELoginUrl_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSaveFolder_tEdit)).EndInit();
            this.ultraTabPageControl4.ResumeLayout(false);
            this.ultraTabPageControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WebConnectCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebUserID_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WebPassword_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerAutoDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSaveFolderOfTOYOTA_tEdit)).EndInit();
            this.ultraTabPageControl5.ResumeLayout(false);
            this.ultraTabPageControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MazdaSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nissan_AnswerAutoDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NissanAnswerSaveFolder_tEdit)).EndInit();
            this.ultraTabPageControl6.ResumeLayout(false);
            this.ultraTabPageControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MitsubishiAnswerSaveFolder_tEdit)).EndInit();
            this.ultraTabPageControl7.ResumeLayout(false);
            this.ultraTabPageControl7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeSystemUseType_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoePassword_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeTerminalID_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeCoCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeJigyousyoCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeEigyousyoFlag_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeiJiUoeEigyousyoCode_tEdit)).EndInit();
            this.ultraTabPageControl8.ResumeLayout(false);
            this.ultraTabPageControl8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_HondaSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MazdaAnswerSaveFolder_tEdit)).EndInit();
            this.ultraTabPageControl9.ResumeLayout(false);
            this.ultraTabPageControl9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BLMngUserCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeOut_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseAddress_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RestoreAddress_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderAddress_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Domain_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Connection_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Protocol_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TelNo_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierCd_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCdAllowZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOETerminalCd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEHostCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEConnectPassword_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEConnectUserId_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEIDNum_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommAssemblyId_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectVersionDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEShipSectCd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEShipSectNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalSectCd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalSectNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEReservSectCd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEReservSectNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveredGoodsDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEResvdSection_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEOrderRate_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveCondition_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubstPartsNoDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsNoPrtCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPriceUseDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSlipDtRecvDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckCodeDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maker_ultraTabControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mazda_AnswerAutoDiv_ultraLabel)).EndInit();
            this.Mazda_AnswerAutoDiv_ultraLabel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region << Private Members >>

        private UOESupplierAcs _uoeSupplierAcs;                         // UOE発注先マスタテーブルアクセスクラス

        // 2008.11.05 30413 アクセスクラスの追加 >>>>>>START
        private EmployeeAcs _employeeAcs;
        private MakerAcs _makerAcs;
        private SupplierAcs _supplierInfoAcs;
        private UOEGuideNameAcs _uoeGuideNameAcs;
        // 2008.11.05 30413 アクセスクラスの追加 <<<<<<END

        private string _enterpriseCode;                                 // 企業コード
        private string _sectionCode;

        // 比較用クローン
        private UOESupplier _uoeSupplierClone;

        private int _totalCount;
        private Hashtable _uoeSupplierTable;

        // プロパティ用
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        
        //_dataIndexバッファ（メインフレーム最小化対応）
        private int _indexBuf;

        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        // ---ADD 2011/10/26 ------------->>>>>
        //卸NET-WEB項目
        private PMUOE09020UB _pmuoe09020ub = null;
        // ---ADD 2011/10/26 -------------<<<<<
        # endregion

        # region ※Consts

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string DELETE_DATE = "削除日";
        private const string UOESUPPLIERCD_TITLE = "発注先コード";
        private const string UOESUPPLIERNAME_TITLE = "発注先名称";
        private const string GOODSMAKERCD_TITLE = "メーカーコード";
        private const string GOODSMAKERNM_TITLE = "メーカー名称";
        private const string SUPPLIERCD_TITLE = "仕入先コード";
        private const string SUPPLIERNM_TITLE = "仕入先名称";
        private const string TELNO_TITLE = "電話番号";
        private const string UOETERMINALCD_TITLE = "端末コード";
        private const string UOEHOSTCODE_TITLE = "ホストコード";
        private const string UOECONNECTPASSWORD_TITLE = "パスワード";
        private const string UOECONNECTUSERID_TITLE = "ユーザーコード";
        private const string UOEIDNUM_TITLE = "ＩＤ番号";
        private const string COMMASSEMBLYID_TITLE = "プログラム";
        private const string CONNECTVERSIONDIV_TITLE = "Ver";
        private const string UOESHIPSECTCD_TITLE = "出庫拠点コード";
        private const string UOESHIPSECTNM_TITLE = "出庫拠点名称";
        private const string UOESALSECTCD_TITLE = "売上拠点コード";
        private const string UOESALSECTNM_TITLE = "売上拠点名称";
        private const string UOERESERVSECTCD_TITLE = "指定拠点コード";
        private const string UOERESERVSECTNM_TITLE = "指定拠点名称";
        private const string RECEIVECONDITION_TITLE = "受信有無区分";
        private const string SUBSTPARTSNODIV_TITLE = "代替品番区分";
        private const string PARTSNOPRTCD_TITLE = "品番印刷区分";
        private const string LISTPRICEUSEDIV_TITLE = "定価使用区分";
        private const string STOCKSLIPDTRECVDIV_TITLE = "仕入受信区分";
        private const string CHECKCODEDIV_TITLE = "チェック区分";
        private const string BUSINESSCODE_TITLE = "業務区分";
        private const string UOERESVDSECTION_TITLE = "指定拠点";
        private const string EMPLOYEECODE_TITLE = "依頼者";
        private const string EMPLOYEENAME_TITLE = "依頼者名";
        private const string DELIVEREDGOODSDIV_TITLE = "納品区分";
        private const string BOCODE_TITLE = "ＢＯ区分";
        private const string UOEORDERRATE_TITLE = "レート";
        private const string INSTRUMENTNO_TITLE = "号機";
        private const string UOETESTMODE_TITLE = "テストモード";
        private const string UOEITEMCD_TITLE = "アイテム";
        private const string HONDASECTIONCODE_TITLE = "担当拠点";
        private const string ANSWERSAVEFOLDER_TITLE = "回答保存フォルダ";
        private const string MAZDASECTIONCODE_TITLE = "自拠点";
        private const string EMERGENCYDIV_TITLE = "緊急区分";
        private const string ENABLEODRMAKERCD1_TITLE = "発注可能メーカーコード１";
        private const string ENABLEODRMAKERNM1_TITLE = "発注可能メーカー名称１";
        private const string ENABLEODRMAKERCD2_TITLE = "発注可能メーカーコード２";
        private const string ENABLEODRMAKERNM2_TITLE = "発注可能メーカー名称２";
        private const string ENABLEODRMAKERCD3_TITLE = "発注可能メーカーコード３";
        private const string ENABLEODRMAKERNM3_TITLE = "発注可能メーカー名称３";
        private const string ENABLEODRMAKERCD4_TITLE = "発注可能メーカーコード４";
        private const string ENABLEODRMAKERNM4_TITLE = "発注可能メーカー名称４";
        private const string ENABLEODRMAKERCD5_TITLE = "発注可能メーカーコード５";
        private const string ENABLEODRMAKERNM5_TITLE = "発注可能メーカー名称５";
        private const string ENABLEODRMAKERCD6_TITLE = "発注可能メーカーコード６";
        private const string ENABLEODRMAKERNM6_TITLE = "発注可能メーカー名称６";
        // ---ADD 2009/06/01 ------------------------------------------->>>>>
        private const string UOELOGINURL_TITLE = "ＵＯＥログインＵＲＬ";
        private const string UOEORDERURL_TITLE = "ＵＯＥ発注ＵＲＬ";
        private const string UOESTOCKCHECKURL_TITLE = "ＵＯＥ在庫確認ＵＲＬ";
        private const string UOEFORCEDTERMURL_TITLE = "ＵＯＥ強制終了ＵＲＬ";
        private const string INQORDDIVCD_TITLE = "問合せ・発注種別";
        private const string LOGINTIMEOUTVAL_TITLE = "ログインタイムアウト";
        private const string EPARTSUSERID_TITLE = "ｅ－ＰａｒｔｓユーザＩＤ";
        private const string EPARTSPASSWORD_TITLE = "ｅ－Ｐａｒｔｓパスワード";
        // ---ADD 2009/06/01 -------------------------------------------<<<<<
        // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
        private const string BLMNGUSERCODE_TITLE = "BL管理ユーザーコード";
        // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<

        private const string GUID_TITLE = "GUID";
        private const string UOE_SUPPLIER_TABLE = "UOESUPPLIER";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";
        private const string REFERENCE_MODE = "参照モード";

        // メーカー名称
        private const string MAKER_CODE_ZERO = "卸商";

        // Message関連定義
        private const string ASSEMBLY_ID = "PMUOE09020U";
        private const string PG_NM = "UOE発注先マスタ";
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";
        // ---ADD 2010/03/08 ------------------------------------------->>>>>
        // 通信アセンブリID 
        private const string NISSAN_COMMASSEMBLY_ID = "0203";
        // ---ADD 2010/03/08 -------------------------------------------<<<<<
		// ---ADD 2010/04/23 ------------------------------------------->>>>>
		// 通信アセンブリID 
		private const string MITSUBISHI_COMMASSEMBLY_ID = "0302";
		// ---ADD 2010/04/23 -------------------------------------------<<<<<

        // ---ADD 2010/12/31 ------------------------------------------->>>>>
        // 通信アセンブリID 
        private const string AUTONISSAN_COMMASSEMBLY_ID = "0204";
        // 通信アセンブリID 
        private const string AUTOMITSUBISHI_COMMASSEMBLY_ID = "0303";
        // ---ADD 2010/12/31 -------------------------------------------<<<<<
        // ---ADD 2011/03/01 ------------------------------------------->>>>>
        private const string AUTONISSAN_COMMASSEMBLY_ID_0205 = "0205";
        private const string AUTONISSAN_COMMASSEMBLY_ID_0206 = "0206";
        // ---ADD 2011/03/01 -------------------------------------------<<<<<
        // ---ADD 2011/05/10 ------------------------------------------->>>>>
        // 通信アセンブリID 
        private const string MAZDA_COMMASSEMBLY_ID = "0403";
        // ---ADD 2011/05/10 -------------------------------------------<<<<<
        //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
        private const string MEKA_KUBUN_NASI = "ハイフン無し";
        private const string MEKA_KUBUN_ARI = "ハイフン有り";
        //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
        #endregion

        # region ※Constructor
		/// <summary>
        /// UOE発注先マスタ フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : UOE発注先マスタ フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30413 犬飼</br>
		/// <br>Date       : 2008.06.26</br>
        /// <br>UpdateNote : 2010/03/08 楊明俊 日産Web-UOE連動項目の対応</br>
		/// <br>UpdateNote : 2010/04/23 jiangk 三菱Web-UOE連動項目の対応</br>
        /// <br>UpdateNote : 2011/05/10 施炳中 回答保存フォルダ（マツダWebUOE用連携ファイルの格納場所）の追加</br>
		/// </remarks>
        public PMUOE09020UA()
		{
			InitializeComponent();

			// データセット列情報構築処理
			DataSetColumnConstruction();

			// プロパティ初期値設定
			this._canPrint = false;
			this._canClose = false;
			this._canNew = true;
			this._canDelete = true;
			this._canLogicalDeleteDataExtraction = true;
			this._canClose = true;		// デフォルト:true固定
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;

            // ガイドボタンの画像イメージ追加
            this.uButton_UOESupplierGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_MakerGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_UOEShipSectGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_UOESalSectGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_UOEReservSectGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_EnableOdrMaker1Guide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_EnableOdrMaker2Guide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_EnableOdrMaker3Guide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_EnableOdrMaker4Guide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_EnableOdrMaker5Guide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_EnableOdrMaker6Guide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_SupplierGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_EmployeeGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // ---ADD 2009/06/01 ------------------------------------------------>>>>>
            this.uButton_AnswerSaveFolder.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // ---ADD 2009/06/01 ------------------------------------------------<<<<<
            // ---------------------------- ADD 2009/12/29 xuxh ----------------->>>>>
            this.uButton_AnswerSaveFolderOfTOYOTA.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // ---------------------------- ADD 2009/12/29 xuxh -----------------<<<<<
            // ---ADD 2010/03/08 ------------------------------------------------>>>>>
            this.uButton_NissanAnswerSaveFolder.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // ---ADD 2010/03/08 ------------------------------------------------<<<<<
			// ---ADD 2010/04/23 ------------------------------------------------>>>>>
			this.uButton_MitsubishiAnswerSaveFolder.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
			// ---ADD 2010/04/23 ------------------------------------------------<<<<<
            // ---ADD 2011/05/10 ------------------------------------------------>>>>>
            this.uButton_MazdaAnswerSaveFolder.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // ---ADD 2011/05/10 ------------------------------------------------<<<<<

			//　企業コード取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

			// 変数初期化
			this._dataIndex = -1;

            this._uoeSupplierAcs = new UOESupplierAcs();
            
            // 2008.11.05 30413 犬飼 アクセスクラスの追加 >>>>>>START
            this._employeeAcs = new EmployeeAcs();
            this._makerAcs = new MakerAcs();
            this._supplierInfoAcs = new SupplierAcs();
            this._uoeGuideNameAcs = new UOEGuideNameAcs();
            // 2008.11.05 30413 犬飼 アクセスクラスの追加 <<<<<<END

            this._totalCount = 0;
            this._uoeSupplierTable = new Hashtable();

			//_dataIndexバッファ（メインフレーム最小化対応）
			this._indexBuf = -2;
		}

		# endregion

        # region ※Dispose
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        # endregion

        # region ※Main
        /// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMUOE09020UA());
        }
        # endregion

        # region ※Events
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        # region ※Properties
        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }

        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
        public bool CanClose
        {
            get
            {
                return this._canClose;
            }
            set
            {
                this._canClose = value;
            }
        }

        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /// <summary>データセットの選択データインデックスプロパティ</summary>
        /// <value>データセットの選択データインデックスを取得または設定します。</value>
        public int DataIndex
        {
            get
            {
                return this._dataIndex;
            }
            set
            {
                this._dataIndex = value;
            }
        }

        /// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
        /// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }
        # endregion

        # region ※Public Methods
        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = UOE_SUPPLIER_TABLE;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList uoeSupplierList = null;


            if (readCount == 0)
            {
                // 抽出対象件数が0の場合は全件抽出を実行する
                status = this._uoeSupplierAcs.SearchAll(out uoeSupplierList, this._enterpriseCode, this._sectionCode);

                this._totalCount = uoeSupplierList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (UOESupplier wkUOESupplier in uoeSupplierList)
                        {
                            UOESupplierToDataSet(wkUOESupplier.Clone(), index);
                            ++index;
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:      // 検索結果0件
                    {
                        // 検索結果0件は、ステータスをノーマルで返す
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "Search",							  // 処理名称
                            TMsgDisp.OPE_GET,					  // オペレーション
                            ERR_READ_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._uoeSupplierAcs,				  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                        break;
                    }
            }

            totalCount = this._totalCount;
            
            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 未実装
            return 9;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;
            string guid = (string)this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[this._dataIndex][GUID_TITLE];
            UOESupplier uoeSupplier = ((UOESupplier)this._uoeSupplierTable[guid]).Clone();

            status = this._uoeSupplierAcs.LogicalDelete(ref uoeSupplier);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._uoeSupplierAcs);
                        return status;
                    }

                case -2:
                    {
                        //主作業設定で使用中
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            ASSEMBLY_ID,
                            "このレコードは主作業設定で使用されているため削除できません",
                            status,
                            MessageBoxButtons.OK);
                        this.Hide();

                        return status;
                    }

                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "Delete",							// 処理名称
                            TMsgDisp.OPE_HIDE,					// オペレーション
                            ERR_RDEL_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._uoeSupplierAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        return status;
                    }
            }

            // データセット展開処理
            UOESupplierToDataSet(uoeSupplier.Clone(), this._dataIndex);
            return status;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Print()
        {
            // 印刷用アセンブリをロードする（未実装）
            return 0;
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(UOESUPPLIERCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(UOESUPPLIERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GOODSMAKERNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(SUPPLIERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(SUPPLIERNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(TELNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOETERMINALCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOEHOSTCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOECONNECTPASSWORD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOECONNECTUSERID_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOEIDNUM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(COMMASSEMBLYID_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(CONNECTVERSIONDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOESHIPSECTCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOESHIPSECTNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOESALSECTCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOESALSECTNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOERESERVSECTCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOERESERVSECTNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(RECEIVECONDITION_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(SUBSTPARTSNODIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(PARTSNOPRTCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(LISTPRICEUSEDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(STOCKSLIPDTRECVDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(CHECKCODEDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(BUSINESSCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOERESVDSECTION_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(EMPLOYEECODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(EMPLOYEENAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 >>>>>>START
            //appearanceTable.Add(DELIVEREDGOODSDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(DELIVEREDGOODSDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 <<<<<<END
            appearanceTable.Add(BOCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOEORDERRATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(INSTRUMENTNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOETESTMODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOEITEMCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(HONDASECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(ANSWERSAVEFOLDER_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(MAZDASECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(EMERGENCYDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERCD1_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERNM1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERCD2_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERNM2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERCD3_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERNM3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERCD4_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERNM4_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERCD5_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERNM5_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERCD6_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(ENABLEODRMAKERNM6_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---ADD 2009/06/01 ----------------------------------------------------------------------->>>>>
            appearanceTable.Add(UOELOGINURL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOEORDERURL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOESTOCKCHECKURL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(UOEFORCEDTERMURL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(INQORDDIVCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(LOGINTIMEOUTVAL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(EPARTSUSERID_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(EPARTSPASSWORD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---ADD 2009/06/01 -----------------------------------------------------------------------<<<<<
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
            appearanceTable.Add(BLMNGUSERCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
            return appearanceTable;
        }
        # endregion

        # region ■Private Methods
        //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
        /// <summary>
        /// ハイフンのセット処理
        /// </summary>
        /// <param name="combo">TComboEditor オブジェクト</param>
        /// <param name="flag">ハイフンあるかどうかフラグ</param>
        /// <remarks>
        /// <br>Note       : ハイフンのセット処理</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/12/15</br>
        private void mekaKubenSet(TComboEditor combo, bool flag)
        {
            if (flag)
            {
                combo.Enabled = true;
                combo.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
                if (combo.Items.Count == 0)
                {
                    combo.Items.Add(0, MEKA_KUBUN_NASI);
                    combo.Items.Add(1, MEKA_KUBUN_ARI);
                    combo.SelectedIndex = 0;
                }
            }
            else
            {
                combo.Enabled = false;
                combo.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
                combo.Items.Clear();
            }
        }
        //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
        /// <summary>
        /// UOE発注先マスタ オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先マスタ オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタ クラスをデータセットに格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>UPDATE Note: 2009/12/29 xuxh 回答保存フォルダ（トヨタ電子カタログ用発注送信データの格納場所）を追加する。</br>
        /// <br>Update Note: 2010/01/19 譚洪 Redmine#2505の対応</br>
        /// <br>UpdateNote : 2010/05/14 呉元嘯 明治UOEWeb項目の対応</br>
        /// <br>UpdateNote : 2010/07/27 朱猛 トヨタUOEWeb項目の対応</br>
        /// <br>UpdateNote : 2011/01/28 施ヘイ中 回答自動取込区分（トヨタWEBUOE用自動連携用の設定区分）の変更</br>
        /// <br>UpdateNote : 2011/03/01 liyp 回答自動取込区分（日産WEBUOE用自動連携用の設定区分）の変更</br>
        /// <br>UpdateNote : 2011/10/26 葛中華 PM1113A 卸NET-WEB対応に伴う仕様追加</br>
        /// </remarks>
        private void UOESupplierToDataSet(UOESupplier uoeSupplier, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].NewRow();
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows.Count - 1;
            }

            if (uoeSupplier.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][DELETE_DATE] = uoeSupplier.UpdateDateTimeJpInFormal;
            }

            // 発注先コード
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESUPPLIERCD_TITLE] = uoeSupplier.UOESupplierCd.ToString("d06");
            // 発注先名称
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESUPPLIERNAME_TITLE] = uoeSupplier.UOESupplierName;
            // メーカーコード
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][GOODSMAKERCD_TITLE] = uoeSupplier.GoodsMakerCd;
            // メーカー名称
            if (uoeSupplier.GoodsMakerCd == 0)
            {
                // 卸商
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][GOODSMAKERNM_TITLE] = MAKER_CODE_ZERO;
            }
            else
            {
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][GOODSMAKERNM_TITLE] = GetMakerName(uoeSupplier.GoodsMakerCd);
            }
            // 仕入先コード
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][SUPPLIERCD_TITLE] = uoeSupplier.SupplierCd;
            // 仕入先名称
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][SUPPLIERNM_TITLE] = GetSupplierName(uoeSupplier.SupplierCd);
            // 電話番号
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][TELNO_TITLE] = uoeSupplier.TelNo;
            // 端末コード
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOETERMINALCD_TITLE] = uoeSupplier.UOETerminalCd;
            // ホストコード
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEHOSTCODE_TITLE] = uoeSupplier.UOEHostCode;
            // パスワード
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOECONNECTPASSWORD_TITLE] = uoeSupplier.UOEConnectPassword;
            // ユーザーコード
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOECONNECTUSERID_TITLE] = uoeSupplier.UOEConnectUserId;
            // ＩＤ番号
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEIDNUM_TITLE] = uoeSupplier.UOEIDNum;
            // プログラム
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][COMMASSEMBLYID_TITLE] = uoeSupplier.CommAssemblyId;
            // Ver
            switch (uoeSupplier.ConnectVersionDiv)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][CONNECTVERSIONDIV_TITLE] = "旧";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][CONNECTVERSIONDIV_TITLE] = "新";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][CONNECTVERSIONDIV_TITLE] = "";
                        break;
                    }
            }
            // 出庫拠点コード
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESHIPSECTCD_TITLE] = uoeSupplier.UOEShipSectCd;
            // 出庫拠点名称
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESHIPSECTNM_TITLE] = GetUOEGuideName(uoeSupplier.UOESupplierCd, uoeSupplier.UOEShipSectCd);
            // 売上拠点コード
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESALSECTCD_TITLE] = uoeSupplier.UOESalSectCd;
            // 売上拠点名称
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESALSECTNM_TITLE] = GetUOEGuideName(uoeSupplier.UOESupplierCd, uoeSupplier.UOESalSectCd);
            // 指定拠点コード
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOERESERVSECTCD_TITLE] = uoeSupplier.UOEReservSectCd;
            // 指定拠点名称
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOERESERVSECTNM_TITLE] = GetUOEGuideName(uoeSupplier.UOESupplierCd, uoeSupplier.UOEReservSectCd);
            // 受信有無区分
            switch (uoeSupplier.ReceiveCondition)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][RECEIVECONDITION_TITLE] = "送受信可能";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][RECEIVECONDITION_TITLE] = "送信のみ";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][RECEIVECONDITION_TITLE] = "";
                        break;
                    }
            }
            // 代替品番区分
            switch (uoeSupplier.SubstPartsNoDiv)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][SUBSTPARTSNODIV_TITLE] = "代替品番採用";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][SUBSTPARTSNODIV_TITLE] = "発注品番採用";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][SUBSTPARTSNODIV_TITLE] = "";
                        break;
                    }
            }
            // 品番印刷区分
            switch (uoeSupplier.PartsNoPrtCd)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][PARTSNOPRTCD_TITLE] = "代替品番採用";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][PARTSNOPRTCD_TITLE] = "発注品番採用";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][PARTSNOPRTCD_TITLE] = "";
                        break;
                    }
            }
            // 定価使用区分
            switch (uoeSupplier.ListPriceUseDiv)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][LISTPRICEUSEDIV_TITLE] = "高い方";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][LISTPRICEUSEDIV_TITLE] = "入力優先";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][LISTPRICEUSEDIV_TITLE] = "オンライン優先";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][LISTPRICEUSEDIV_TITLE] = "";
                        break;
                    }
            }
            // 仕入受信区分
            switch (uoeSupplier.StockSlipDtRecvDiv)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][STOCKSLIPDTRECVDIV_TITLE] = "なし";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][STOCKSLIPDTRECVDIV_TITLE] = "あり";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][STOCKSLIPDTRECVDIV_TITLE] = "";
                        break;
                    }
            }
            // チェック区分
            switch (uoeSupplier.CheckCodeDiv)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][CHECKCODEDIV_TITLE] = "倉庫(4)＋棚番(6)";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][CHECKCODEDIV_TITLE] = "倉庫(2)＋棚番(8)";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][CHECKCODEDIV_TITLE] = "棚番のみ";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][CHECKCODEDIV_TITLE] = "";
                        break;
                    }
            }
            // 業務区分
            switch (uoeSupplier.BusinessCode)
            {
                case 1:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][BUSINESSCODE_TITLE] = "発注";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][BUSINESSCODE_TITLE] = "見積";
                        break;
                    }
                case 3:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][BUSINESSCODE_TITLE] = "在庫";
                        break;
                    }
                default:
                    {
                        this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][BUSINESSCODE_TITLE] = "";
                        break;
                    }
            }
            // 指定拠点
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOERESVDSECTION_TITLE] = uoeSupplier.UOEResvdSection;
            // 依頼者
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EMPLOYEECODE_TITLE] = uoeSupplier.EmployeeCode;
            // 依頼者名
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EMPLOYEENAME_TITLE] = GetEmployeeName(uoeSupplier.EmployeeCode);
            // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 >>>>>>START
            //// 納品区分
            //this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][DELIVEREDGOODSDIV_TITLE] = uoeSupplier.DeliveredGoodsDiv;
            // 納品区分
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][DELIVEREDGOODSDIV_TITLE] = uoeSupplier.UOEDeliGoodsDiv;
            // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 <<<<<<END
            // ＢＯ区分
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][BOCODE_TITLE] = uoeSupplier.BoCode;
            // レート
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEORDERRATE_TITLE] = uoeSupplier.UOEOrderRate;
            // 号機
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INSTRUMENTNO_TITLE] = uoeSupplier.instrumentNo;
            // テストモード
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOETESTMODE_TITLE] = uoeSupplier.UOETestMode;
            // アイテム
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEITEMCD_TITLE] = uoeSupplier.UOEItemCd;
            // 担当拠点
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][HONDASECTIONCODE_TITLE] = uoeSupplier.HondaSectionCode;
            // 回答保存フォルダ
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ANSWERSAVEFOLDER_TITLE] = uoeSupplier.AnswerSaveFolder;
            // 自拠点
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][MAZDASECTIONCODE_TITLE] = uoeSupplier.MazdaSectionCode;
            // 緊急区分
            if (uoeSupplier.EmergencyDiv.Equals("C"))
            {
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EMERGENCYDIV_TITLE] = "準緊急";
            }
            else if (uoeSupplier.EmergencyDiv.Equals("E"))
            {
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EMERGENCYDIV_TITLE] = "緊急";
            }
            else
            {
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EMERGENCYDIV_TITLE] = "";
            }
            // 発注可能メーカーコード１
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERCD1_TITLE] = uoeSupplier.EnableOdrMakerCd1;
            // 発注可能メーカー名称１
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERNM1_TITLE] = GetMakerName(uoeSupplier.EnableOdrMakerCd1);
            // 発注可能メーカーコード２
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERCD2_TITLE] = uoeSupplier.EnableOdrMakerCd2;
            // 発注可能メーカー名称２
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERNM2_TITLE] = GetMakerName(uoeSupplier.EnableOdrMakerCd2);
            // 発注可能メーカーコード３
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERCD3_TITLE] = uoeSupplier.EnableOdrMakerCd3;
            // 発注可能メーカー名称３
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERNM3_TITLE] = GetMakerName(uoeSupplier.EnableOdrMakerCd3);
            // 発注可能メーカーコード４
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERCD4_TITLE] = uoeSupplier.EnableOdrMakerCd4;
            // 発注可能メーカー名称４
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERNM4_TITLE] = GetMakerName(uoeSupplier.EnableOdrMakerCd4);
            // 発注可能メーカーコード５
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERCD5_TITLE] = uoeSupplier.EnableOdrMakerCd5;
            // 発注可能メーカー名称５
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERNM5_TITLE] = GetMakerName(uoeSupplier.EnableOdrMakerCd5);
            // 発注可能メーカーコード６
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERCD6_TITLE] = uoeSupplier.EnableOdrMakerCd6;
            // 発注可能メーカー名称６
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ENABLEODRMAKERNM6_TITLE] = GetMakerName(uoeSupplier.EnableOdrMakerCd6);
            
            // GUID
            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][GUID_TITLE] = CreateHashKey(uoeSupplier);
            
            if (this._uoeSupplierTable.ContainsKey(CreateHashKey(uoeSupplier)))
            {
                this._uoeSupplierTable.Remove(CreateHashKey(uoeSupplier));
            }
            this._uoeSupplierTable.Add(CreateHashKey(uoeSupplier), uoeSupplier);

            // ---ADD 2009/06/01 ----------------------------------------------------------->>>>>
            // プログラムをInt型に変換
            int commAssemblyId = 0;
            if (uoeSupplier.CommAssemblyId.Trim() != "")
            {
                commAssemblyId = int.Parse(uoeSupplier.CommAssemblyId.Trim());
            }
            if (commAssemblyId == 502)
            {
                // ログイン用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOELOGINURL_TITLE] = uoeSupplier.UOELoginUrl;
                // 発注用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEORDERURL_TITLE] = uoeSupplier.UOEOrderUrl;
                // 在庫確認用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESTOCKCHECKURL_TITLE] = uoeSupplier.UOEStockCheckUrl;
                // 強制終了用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEFORCEDTERMURL_TITLE] = uoeSupplier.UOEForcedTermUrl;
                // ログイン認証時間
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][LOGINTIMEOUTVAL_TITLE] = uoeSupplier.LoginTimeoutVal;
                // ユーザID
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EPARTSUSERID_TITLE] = uoeSupplier.EPartsUserId;
                // パスワード
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EPARTSPASSWORD_TITLE] = uoeSupplier.EPartsPassWord;

                // 接続種別
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 0:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "0:発注処理";
                            break;
                        }
                    case 1:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "1:在庫確認";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }
            }
            // ---ADD 2010/05/14 ---------------------------------------->>>>>
            else if (commAssemblyId == 1004)
            {
                // ログイン用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOELOGINURL_TITLE] = uoeSupplier.UOELoginUrl;
                // 発注用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEORDERURL_TITLE] = "";
                // 在庫確認用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESTOCKCHECKURL_TITLE] = "";
                // 強制終了用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEFORCEDTERMURL_TITLE] = uoeSupplier.UOEForcedTermUrl;
                // ログイン認証時間
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][LOGINTIMEOUTVAL_TITLE] = DBNull.Value;
                // ユーザID
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EPARTSUSERID_TITLE] = uoeSupplier.EPartsUserId;
                // パスワード
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EPARTSPASSWORD_TITLE] = uoeSupplier.EPartsPassWord;

                // 接続種別
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 0:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "0:発注処理";
                            break;
                        }
                    case 1:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "1:在庫確認";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }

            }
            // ---ADD 2010/05/14 ----------------------------------------<<<<<
            // ---ADD 2011/10/26 ---------------------------------------->>>>>
            else if (commAssemblyId == 1003)
            {
                // ログイン用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOELOGINURL_TITLE] = uoeSupplier.UOELoginUrl;
                // 発注用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEORDERURL_TITLE] = uoeSupplier.UOEOrderUrl;
                // 在庫確認用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESTOCKCHECKURL_TITLE] = uoeSupplier.UOEStockCheckUrl;
                // 強制終了用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEFORCEDTERMURL_TITLE] = uoeSupplier.UOEForcedTermUrl;
                // ログイン認証時間
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][LOGINTIMEOUTVAL_TITLE] = uoeSupplier.LoginTimeoutVal;
                // ユーザID
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EPARTSUSERID_TITLE] = uoeSupplier.EPartsUserId;
                // パスワード
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EPARTSPASSWORD_TITLE] = uoeSupplier.EPartsPassWord;
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                // BL管理ユーザーコード
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][BLMNGUSERCODE_TITLE] = uoeSupplier.BLMngUserCode;
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<

                // 接続種別
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 0:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "0:発注処理";
                            break;
                        }
                    case 1:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "1:在庫確認";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }
            }
            // ---ADD 2011/10/26 ----------------------------------------<<<<<
            else
            {
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOELOGINURL_TITLE] = "";                   // ログイン用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEORDERURL_TITLE] = "";                   // 発注用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESTOCKCHECKURL_TITLE] = "";              // 在庫確認用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEFORCEDTERMURL_TITLE] = "";              // 強制終了用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][LOGINTIMEOUTVAL_TITLE] = DBNull.Value;     // ログイン認証時間
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EPARTSUSERID_TITLE] = "";                  // ユーザID
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][EPARTSPASSWORD_TITLE] = "";                // パスワード
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";                   // 接続種別
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][BLMNGUSERCODE_TITLE] = "";                 // BL管理ユーザーコード
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
            }
            // ---ADD 2009/06/01 ----------------------------------------------------------->>>>>
            // ---------------------------- DEL 2010/01/19 -------------------------------->>>>>
            // ---------------------------- ADD 2009/12/29 xuxh -------------------------------->>>>>
            //if (commAssemblyId == 103)
            //{
            //    //this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][ANSWERSAVEFOLDER_TITLE] = AnswerSaveFolderOfTOYOTA_tEdit.Text;
            //}
            // ---------------------------- ADD 2009/12/29 xuxh --------------------------------<<<<<
            // ---------------------------- DEL 2010/01/19 -------------------------------------<<<<<
            // ---ADD 2010/07/27 ---------------------------------------->>>>>
            if ("0103".Equals(uoeSupplier.CommAssemblyId.Trim()))
            {
                // UOE発注用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEORDERURL_TITLE] = uoeSupplier.UOEOrderUrl;
                // UOE在庫確認用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESTOCKCHECKURL_TITLE] = uoeSupplier.UOEStockCheckUrl;
                // UOE強制終了用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEFORCEDTERMURL_TITLE] = uoeSupplier.UOEForcedTermUrl;
                // 接続種別
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 0:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "0:手動";
                            break;
                        }
                    case 1:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "1:自動";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }
            }
            // ---ADD 2010/07/27 ----------------------------------------<<<<<

          // ---ADD 2011/01/28 ---------------------------------------->>>>>
            if ("0104".Equals(uoeSupplier.CommAssemblyId.Trim()))
            {
                // UOE発注用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEORDERURL_TITLE] = uoeSupplier.UOEOrderUrl;
                // UOE在庫確認用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOESTOCKCHECKURL_TITLE] = uoeSupplier.UOEStockCheckUrl;
                // UOE強制終了用URL
                this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][UOEFORCEDTERMURL_TITLE] = uoeSupplier.UOEForcedTermUrl;
                // 接続種別
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 1:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] =  "1:自動";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }
            }
            // ---ADD 2011/01/28 ----------------------------------------<<<<<
            // ---ADD 2011/03/01 ---------------------------------------->>>>>
            if (AUTONISSAN_COMMASSEMBLY_ID_0205.Equals(uoeSupplier.CommAssemblyId.Trim()))
            {
                // 接続種別
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 0:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "0:手動";
                            break;
                        }
                    case 1:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "1:自動";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }
            }

            if (AUTONISSAN_COMMASSEMBLY_ID_0206.Equals(uoeSupplier.CommAssemblyId.Trim()))
            {
                // 接続種別
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 1:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "1:自動";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }
            }

            if (NISSAN_COMMASSEMBLY_ID.Equals(uoeSupplier.CommAssemblyId.Trim()))
            {
                // 接続種別
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 0:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "0:手動";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }
            }

            if (AUTONISSAN_COMMASSEMBLY_ID.Equals(uoeSupplier.CommAssemblyId.Trim()))
            {
                // 接続種別
                switch (uoeSupplier.InqOrdDivCd)
                {
                    case 1:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "1:自動";
                            break;
                        }
                    default:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[index][INQORDDIVCD_TITLE] = "";
                            break;
                        }
                }
            }

            // ---ADD 2011/03/01 ----------------------------------------<<<<<
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable uoeSupplierTable = new DataTable(UOE_SUPPLIER_TABLE);

            // Addを行う順番が、列の表示順位となります。
            uoeSupplierTable.Columns.Add(DELETE_DATE, typeof(string));

            // 発注先コード
            uoeSupplierTable.Columns.Add(UOESUPPLIERCD_TITLE, typeof(string));
            // 発注先名称
            uoeSupplierTable.Columns.Add(UOESUPPLIERNAME_TITLE, typeof(string));
            //メーカーコード
            uoeSupplierTable.Columns.Add(GOODSMAKERCD_TITLE, typeof(int));
            //メーカー名称
            uoeSupplierTable.Columns.Add(GOODSMAKERNM_TITLE, typeof(string));
            // 仕入先コード
            uoeSupplierTable.Columns.Add(SUPPLIERCD_TITLE, typeof(int));
            // 仕入先名称
            uoeSupplierTable.Columns.Add(SUPPLIERNM_TITLE, typeof(string));
            // 電話番号
            uoeSupplierTable.Columns.Add(TELNO_TITLE, typeof(string));
            // 端末コード
            uoeSupplierTable.Columns.Add(UOETERMINALCD_TITLE, typeof(string));
            // ホストコード
            uoeSupplierTable.Columns.Add(UOEHOSTCODE_TITLE, typeof(string));
            // パスワード
            uoeSupplierTable.Columns.Add(UOECONNECTPASSWORD_TITLE, typeof(string));
            // ユーザーコード
            uoeSupplierTable.Columns.Add(UOECONNECTUSERID_TITLE, typeof(string));
            // ＩＤ番号
            uoeSupplierTable.Columns.Add(UOEIDNUM_TITLE, typeof(string));
            // プログラム
            uoeSupplierTable.Columns.Add(COMMASSEMBLYID_TITLE, typeof(string));
            // Ver
            uoeSupplierTable.Columns.Add(CONNECTVERSIONDIV_TITLE, typeof(string));
            // 出庫拠点コード
            uoeSupplierTable.Columns.Add(UOESHIPSECTCD_TITLE, typeof(string));
            // 出庫拠点名称
            uoeSupplierTable.Columns.Add(UOESHIPSECTNM_TITLE, typeof(string));
            // 売上拠点コード
            uoeSupplierTable.Columns.Add(UOESALSECTCD_TITLE, typeof(string));
            // 売上拠点名称
            uoeSupplierTable.Columns.Add(UOESALSECTNM_TITLE, typeof(string));
            // 指定拠点コード
            uoeSupplierTable.Columns.Add(UOERESERVSECTCD_TITLE, typeof(string));
            // 指定拠点名称
            uoeSupplierTable.Columns.Add(UOERESERVSECTNM_TITLE, typeof(string));
            // 受信有無区分
            uoeSupplierTable.Columns.Add(RECEIVECONDITION_TITLE, typeof(string));
            // 代替品番区分
            uoeSupplierTable.Columns.Add(SUBSTPARTSNODIV_TITLE, typeof(string));
            // 品番印刷区分
            uoeSupplierTable.Columns.Add(PARTSNOPRTCD_TITLE, typeof(string));
            // 定価使用区分
            uoeSupplierTable.Columns.Add(LISTPRICEUSEDIV_TITLE, typeof(string));
            // 仕入受信区分
            uoeSupplierTable.Columns.Add(STOCKSLIPDTRECVDIV_TITLE, typeof(string));
            // チェック区分
            uoeSupplierTable.Columns.Add(CHECKCODEDIV_TITLE, typeof(string));
            // 業務区分
            uoeSupplierTable.Columns.Add(BUSINESSCODE_TITLE, typeof(string));
            // 指定拠点
            uoeSupplierTable.Columns.Add(UOERESVDSECTION_TITLE, typeof(string));
            // 依頼者
            uoeSupplierTable.Columns.Add(EMPLOYEECODE_TITLE, typeof(string));
            // 依頼者名
            uoeSupplierTable.Columns.Add(EMPLOYEENAME_TITLE, typeof(string));
            // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 >>>>>>START
            //// 納品区分
            //uoeSupplierTable.Columns.Add(DELIVEREDGOODSDIV_TITLE, typeof(int));
            // UOE納品区分
            uoeSupplierTable.Columns.Add(DELIVEREDGOODSDIV_TITLE, typeof(string));
            // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 <<<<<<END
            // ＢＯ区分
            uoeSupplierTable.Columns.Add(BOCODE_TITLE, typeof(string));
            // レート
            uoeSupplierTable.Columns.Add(UOEORDERRATE_TITLE, typeof(string));
            // 号機
            uoeSupplierTable.Columns.Add(INSTRUMENTNO_TITLE, typeof(string));
            // テストモード
            uoeSupplierTable.Columns.Add(UOETESTMODE_TITLE, typeof(string));
            // アイテム
            uoeSupplierTable.Columns.Add(UOEITEMCD_TITLE, typeof(string));
            // 担当拠点
            uoeSupplierTable.Columns.Add(HONDASECTIONCODE_TITLE, typeof(string));
            // 回答保存フォルダ
            uoeSupplierTable.Columns.Add(ANSWERSAVEFOLDER_TITLE, typeof(string));
            // 自拠点
            uoeSupplierTable.Columns.Add(MAZDASECTIONCODE_TITLE, typeof(string));
            // 緊急区分
            uoeSupplierTable.Columns.Add(EMERGENCYDIV_TITLE, typeof(string));
            // 発注可能メーカーコード１
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERCD1_TITLE, typeof(int));
            // 発注可能メーカー名称１
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERNM1_TITLE, typeof(string));
            // 発注可能メーカーコード２
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERCD2_TITLE, typeof(int));
            // 発注可能メーカー名称２
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERNM2_TITLE, typeof(string));
            // 発注可能メーカーコード３
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERCD3_TITLE, typeof(int));
            // 発注可能メーカー名称３
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERNM3_TITLE, typeof(string));
            // 発注可能メーカーコード４
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERCD4_TITLE, typeof(int));
            // 発注可能メーカー名称４
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERNM4_TITLE, typeof(string));
            // 発注可能メーカーコード５
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERCD5_TITLE, typeof(int));
            // 発注可能メーカー名称５
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERNM5_TITLE, typeof(string));
            // 発注可能メーカーコード６
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERCD6_TITLE, typeof(int));
            // 発注可能メーカー名称６
            uoeSupplierTable.Columns.Add(ENABLEODRMAKERNM6_TITLE, typeof(string));
 
            // GUID
            uoeSupplierTable.Columns.Add(GUID_TITLE, typeof(string));

            // ---ADD 2009/06/01 ---------------------------------------->>>>>
            // ログイン用URL
            uoeSupplierTable.Columns.Add(UOELOGINURL_TITLE, typeof(string));
            // 発注用URL
            uoeSupplierTable.Columns.Add(UOEORDERURL_TITLE, typeof(string));
            // 在庫確認用URL
            uoeSupplierTable.Columns.Add(UOESTOCKCHECKURL_TITLE, typeof(string));
            // 強制終了用URL
            uoeSupplierTable.Columns.Add(UOEFORCEDTERMURL_TITLE, typeof(string));
            // 接続種別
            uoeSupplierTable.Columns.Add(INQORDDIVCD_TITLE, typeof(string));
            // ログイン認証時間
            uoeSupplierTable.Columns.Add(LOGINTIMEOUTVAL_TITLE, typeof(int));
            // ユーザID
            uoeSupplierTable.Columns.Add(EPARTSUSERID_TITLE, typeof(string));
            // パスワード
            uoeSupplierTable.Columns.Add(EPARTSPASSWORD_TITLE, typeof(string));
            // ---ADD 2009/06/01 ----------------------------------------<<<<<
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
            //BL管理ユーザーコード
            uoeSupplierTable.Columns.Add(BLMNGUSERCODE_TITLE, typeof(string));
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<

            this.Bind_DataSet.Tables.Add(uoeSupplierTable);
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>UpdateNote : 2010/07/27 朱 猛 トヨタUOEWeb項目の対応</br>
        /// <br>UpdateNote : 2011/03/01 liyp 回答自動取込区分（日産WEBUOE用自動連携用の設定区分）の変更</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // コンボボックス初期化

            // Ver
            this.ConnectVersionDiv_tComboEditor.Items.Clear();
            this.ConnectVersionDiv_tComboEditor.Items.Add(0, "旧");
            this.ConnectVersionDiv_tComboEditor.Items.Add(1, "新");
            this.ConnectVersionDiv_tComboEditor.MaxDropDownItems = this.ConnectVersionDiv_tComboEditor.Items.Count;

            // 受信有無区分
            this.ReceiveCondition_tComboEditor.Items.Clear();
            this.ReceiveCondition_tComboEditor.Items.Add(0, "送受信可能");
            this.ReceiveCondition_tComboEditor.Items.Add(1, "送信のみ");
            this.ReceiveCondition_tComboEditor.MaxDropDownItems = this.ReceiveCondition_tComboEditor.Items.Count;

            // 代替品番区分
            this.SubstPartsNoDiv_tComboEditor.Items.Clear();
            this.SubstPartsNoDiv_tComboEditor.Items.Add(0, "代替品番採用");
            this.SubstPartsNoDiv_tComboEditor.Items.Add(1, "発注品番採用");
            this.SubstPartsNoDiv_tComboEditor.MaxDropDownItems = this.SubstPartsNoDiv_tComboEditor.Items.Count;

            // 品番印刷区分
            this.PartsNoPrtCd_tComboEditor.Items.Clear();
            this.PartsNoPrtCd_tComboEditor.Items.Add(0, "代替品番採用");
            this.PartsNoPrtCd_tComboEditor.Items.Add(1, "発注品番採用");
            this.PartsNoPrtCd_tComboEditor.MaxDropDownItems = this.PartsNoPrtCd_tComboEditor.Items.Count;

            // 定価使用区分
            this.ListPriceUseDiv_tComboEditor.Items.Clear();
            this.ListPriceUseDiv_tComboEditor.Items.Add(0, "高い方");
            this.ListPriceUseDiv_tComboEditor.Items.Add(1, "入力優先");
            this.ListPriceUseDiv_tComboEditor.Items.Add(2, "オンライン優先");
            this.ListPriceUseDiv_tComboEditor.MaxDropDownItems = this.ListPriceUseDiv_tComboEditor.Items.Count;

            // 仕入受信区分
            this.StockSlipDtRecvDiv_tComboEditor.Items.Clear();
            this.StockSlipDtRecvDiv_tComboEditor.Items.Add(0, "なし");
            this.StockSlipDtRecvDiv_tComboEditor.Items.Add(1, "あり");
            this.StockSlipDtRecvDiv_tComboEditor.MaxDropDownItems = this.StockSlipDtRecvDiv_tComboEditor.Items.Count;

            // チェック区分
            this.CheckCodeDiv_tComboEditor.Items.Clear();
            this.CheckCodeDiv_tComboEditor.Items.Add(0, "倉庫(4)＋棚番(6)");
            this.CheckCodeDiv_tComboEditor.Items.Add(1, "倉庫(2)＋棚番(8)");
            this.CheckCodeDiv_tComboEditor.Items.Add(2, "棚番のみ");
            this.CheckCodeDiv_tComboEditor.MaxDropDownItems = this.CheckCodeDiv_tComboEditor.Items.Count;

            // 業務区分
            this.BusinessCode_tComboEditor.Items.Clear();
            this.BusinessCode_tComboEditor.Items.Add(1, "発注");
            this.BusinessCode_tComboEditor.Items.Add(2, "見積");
            this.BusinessCode_tComboEditor.Items.Add(3, "在庫");
            this.BusinessCode_tComboEditor.MaxDropDownItems = this.BusinessCode_tComboEditor.Items.Count;

            // 緊急区分
            this.EmergencyDiv_tComboEditor.Items.Clear();
            this.EmergencyDiv_tComboEditor.Items.Add("C", "準緊急");
            this.EmergencyDiv_tComboEditor.Items.Add("E", "緊急");
            this.EmergencyDiv_tComboEditor.MaxDropDownItems = this.EmergencyDiv_tComboEditor.Items.Count;

            // ---ADD 2009/06/01 ---------------------------------------------------------------->>>>>
            // 接続種別
            this.InqOrdDivCd_tComboEditor.Items.Clear();
            this.InqOrdDivCd_tComboEditor.Items.Add(0, "0:発注処理");
            this.InqOrdDivCd_tComboEditor.Items.Add(1, "1:在庫確認");
            this.InqOrdDivCd_tComboEditor.MaxDropDownItems = this.InqOrdDivCd_tComboEditor.Items.Count;
            // ---ADD 2009/06/01 ----------------------------------------------------------------<<<<<

            // ---ADD 2010/07/27 ---------------------------------------------------------------->>>>>
            // 回答自動取込区分
            this.AnswerAutoDiv_tComboEditor.Items.Clear();
            this.AnswerAutoDiv_tComboEditor.Items.Add(0, "手動");
            this.AnswerAutoDiv_tComboEditor.Items.Add(1, "自動");
            this.AnswerAutoDiv_tComboEditor.MaxDropDownItems = this.AnswerAutoDiv_tComboEditor.Items.Count;
            // ---ADD 2010/07/27 ----------------------------------------------------------------<<<<<
            // ---ADD 2011/03/01 ---------------------------------------------------------------->>>>>
            // 回答自動取込区分(日産WEBUOE用)
            this.Nissan_AnswerAutoDiv_tComboEditor.Items.Clear();
            this.Nissan_AnswerAutoDiv_tComboEditor.Items.Add(0, "手動");
            this.Nissan_AnswerAutoDiv_tComboEditor.Items.Add(1, "自動");
            this.Nissan_AnswerAutoDiv_tComboEditor.MaxDropDownItems = this.Nissan_AnswerAutoDiv_tComboEditor.Items.Count;
            // ---ADD 2011/03/01 ----------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>UpdateNote : 2010/03/08 楊明俊 日産Web-UOE連動項目の対応</br>
		/// <br>UpdateNote : 2010/04/23 jiangk 三菱Web-UOE連動項目の対応</br>
        /// <br>UpdateNote : 2010/05/14 呉元嘯 明治UOEWeb項目の対応</br>
        /// <br>UpdateNote : 2010/07/27 朱 猛 トヨタUOEWeb項目の対応</br>
        /// <br>UpdateNote : 2011/03/15 liyp プログラム「0206」の追加仕様分の組み込み</br>
        /// <br>UpdateNote : 2011/05/10 施炳中 マツダUOE-WEB対応に伴う仕様追加</br>
        /// <br>UpdateNote : 2011/10/26 葛中華 PM1113A 卸NET-WEB対応に伴う仕様追加 </br>
        /// </remarks>
        private void ScreenClear()
        {
            this.UOESupplierCd_tNedit.Clear();                          // 発注先コード
            this.UOESupplierName_tEdit.Clear();                         // 発注先名称
            this.tNedit_GoodsMakerCdAllowZero.SetInt(0);                // メーカーコード
            this.GoodsMakerNm_tEdit.Text = "卸商";                      // メーカー名称
            this.tNedit_SupplierCd.Clear();                             // 仕入先コード
            this.SupplierNm_tEdit.Clear();                              // 仕入先名称
            this.TelNo_tEdit.Clear();                                   // 電話番号
            this.UOETerminalCd_tEdit.Clear();                           // 端末コード
            this.UOEHostCode_tEdit.Clear();                             // ホストコード
            this.UOEConnectPassword_tEdit.Clear();                      // パスワード
            this.UOEConnectUserId_tEdit.Clear();                        // ユーザーコード
            this.UOEIDNum_tEdit.Clear();                                // ＩＤ番号
            this.CommAssemblyId_tEdit.Clear();                          // プログラム
            this.ConnectVersionDiv_tComboEditor.Value = 0;              // Ver
            this.UOEShipSectCd_tEdit.Clear();                           // 出庫拠点コード
            this.UOEShipSectNm_tEdit.Clear();                           // 出庫拠点名称
            this.UOESalSectCd_tEdit.Clear();                            // 売上拠点コード
            this.UOESalSectNm_tEdit.Clear();                            // 売上拠点名称
            this.UOEReservSectCd_tEdit.Clear();                         // 指定拠点コード
            this.UOEReservSectNm_tEdit.Clear();                         // 指定拠点名称
            this.ReceiveCondition_tComboEditor.Value = 0;               // 受信有無区分
            this.SubstPartsNoDiv_tComboEditor.Value = 0;                // 代替品番区分
            this.PartsNoPrtCd_tComboEditor.Value = 0;                   // 品番印刷区分
            this.ListPriceUseDiv_tComboEditor.Value = 0;                // 定価使用区分
            this.StockSlipDtRecvDiv_tComboEditor.Value = 0;             // 仕入受信区分
            this.CheckCodeDiv_tComboEditor.Value = 0;                   // チェック区分
            this.BusinessCode_tComboEditor.Value = 1;                   // 業務区分
            this.UOEResvdSection_tComboEditor.Items.Clear();            // 指定拠点
            this.tEdit_EmployeeCode.Clear();                            // 依頼者コード
            this.tEdit_EmployeeName.Clear();                            // 依頼者名称
            this.DeliveredGoodsDiv_tComboEditor.Items.Clear();          // 納品区分
            this.BoCode_tComboEditor.Items.Clear();                     // ＢＯ区分
            // 2008.11.05 30413 犬飼 削除 >>>>>>START
            //this.UOEResvdSection_tEdit.Clear();                         // 指定拠点
            //this.EmployeeCode_tEdit.Clear();                            // 依頼者
            //this.DeliveredGoodsDiv_tNedit.Clear();                      // 納品区分
            //this.BoCode_tEdit.Clear();                                  // ＢＯ区分
            this.UOEOrderRate_tEdit.Text = "L1000";                     // レート
            this.instrumentNo_tEdit.Clear();                            // 号機
            this.UOETestMode_tEdit.Clear();                             // テストモード
            this.UOEItemCd_tEdit.Clear();                               // アイテム
            this.HondaSectionCode_tEdit.Clear();                        // 担当拠点
            //this.AnswerSaveFolder_tEdit.Clear();                        // 回答保存フォルダ
            // 2008.11.05 30413 犬飼 削除 <<<<<<END
            this.MazdaSectionCode_tEdit.Clear();                        // 自拠点
            this.EmergencyDiv_tComboEditor.Value = null;                // 緊急区分
            this.EnableOdrMakerCd1_tNedit.Clear();                      // 発注可能メーカーコード１
            this.EnableOdrMakerNm1_tEdit.Clear();                       // 発注可能メーカー名称１
            this.EnableOdrMakerCd2_tNedit.Clear();                      // 発注可能メーカーコード２
            this.EnableOdrMakerNm2_tEdit.Clear();                       // 発注可能メーカー名称２
            this.EnableOdrMakerCd3_tNedit.Clear();                      // 発注可能メーカーコード３
            this.EnableOdrMakerNm3_tEdit.Clear();                       // 発注可能メーカー名称３
            this.EnableOdrMakerCd4_tNedit.Clear();                      // 発注可能メーカーコード４
            this.EnableOdrMakerNm4_tEdit.Clear();                       // 発注可能メーカー名称４
            this.EnableOdrMakerCd5_tNedit.Clear();                      // 発注可能メーカーコード５
            this.EnableOdrMakerNm5_tEdit.Clear();                       // 発注可能メーカー名称５
            this.EnableOdrMakerCd6_tNedit.Clear();                      // 発注可能メーカーコード６
            this.EnableOdrMakerNm6_tEdit.Clear();                       // 発注可能メーカー名称６
            // ---ADD 2009/06/01 ---------------------------------------->>>>>
            this.AnswerSaveFolder_tEdit.Clear();                        // 回答保存フォルダ
            this.UOELoginUrl_tEdit.Clear();                             // ログイン用URL
            this.UOEOrderUrl_tEdit.Clear();                             // 発注用URL
            this.UOEStockCheckUrl_tEdit.Clear();                        // 在庫確認用URL
            this.UOEForcedTermUrl_tEdit.Clear();                        // 強制終了用URL
            this.InqOrdDivCd_tComboEditor.Value = null;                 // 接続種別
            this.LoginTimeoutVal_tNedit.Clear();                        // ログイン認証時間
            this.UOEePartsItemCd_tEdit.Clear();                         // アイテム[ホンダe-Parts項目]
            this.EPartsUserId_tEdit.Clear();                            // ユーザID
            this.EPartsPassWord_tEdit.Clear();                          // パスワード
            // ---ADD 2009/06/01 ----------------------------------------<<<<<
            // ---ADD 2010/05/14 ---------------------------------------->>>>>
            // 明治UOEWeb項目
            this.MeiJiUoeSystemUseType_tEdit.Clear();                             // システム利用形態
            this.MeiJiUoeEigyousyoCode_tEdit.Clear();                              // 営業所コード
            this.MeiJiUoeEigyousyoFlag_tEdit.Clear();                             // 営業所フラグ
            this.MeiJiUoeJigyousyoCode_tEdit.Clear();                          // 事業所コード
            this.MeiJiUoeCoCode_tEdit.Clear();                             // 会社コード
            this.MeiJiUoeTerminalID_tEdit.Clear();                              // 端末ID
            this.MeiJiUoePassword_tEdit.Clear();                              // パスワード
            // ---ADD 2010/05/14 ----------------------------------------<<<<<
            // ---ADD 2011/10/26 ---------------------------------------->>>>>
            //卸NET-WEB項目
            this.Protocol_tComboEditor.Value = 0;                       //プロトコル
            this.Connection_tComboEditor.Value = 0;                     //接続区分
            this.CarMaker_uButton.Enabled = true;                       //外車対応メーカー
            this.Domain_tEdit.Clear();                                  //ドメイン
            this.OrderAddress_tEdit.Clear();                            //発注用アドレス
            this.RestoreAddress_tEdit.Clear();                          //復旧用アドレス
            this.PurchaseAddress_tEdit.Clear();                         //仕入受信用アドレス
            this.TimeOut_tEdit.Clear();                                 //タイムアウト
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
            this.BLMngUserCode_tEdit.Clear();
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<

            // ---ADD 2011/10/26 ----------------------------------------<<<<<
            this.AnswerSaveFolderOfTOYOTA_tEdit.Clear();                        // 回答保存フォルダ // ADD 2009/12/29 xuxh
            // ---ADD 2010/03/08 ---------------------------------------->>>>>
            this.NissanAnswerSaveFolder_tEdit.Clear();                        // 日産回答保存フォルダ
            // ---ADD 2010/03/08 ----------------------------------------<<<<<
			// ---ADD 2010/04/23 ---------------------------------------->>>>>
			this.MitsubishiAnswerSaveFolder_tEdit.Clear();                    // 三菱回答保存フォルダ
			// ---ADD 2010/04/23 ----------------------------------------<<<<<
            // ---ADD 2010/07/27 ---------------------------------------------------------------->>>>>
            // ---ADD 2011/05/10 ---------------------------------------->>>>>
            this.MazdaAnswerSaveFolder_tEdit.Clear();                    // マツダ回答保存フォルダ
            this.tEdit_HondaSectionCode.Text = "";
            // ---ADD 2011/05/10 ----------------------------------------<<<<<
            // 回答自動取込区分
            this.AnswerAutoDiv_tComboEditor.Value = null;
            // WEBパスワード
            this.WebPassword_tEdit.Clear();
            // WEBユーザーID
            this.WebUserID_tEdit.Clear();
            // WEB接続先コード
            this.WebConnectCode_tEdit.Clear();
            // ---ADD 2010/07/27 ----------------------------------------------------------------<<<<<
            // 回答自動取込区分 (日産WEBUOE用)
            this.Nissan_AnswerAutoDiv_tComboEditor.Value = null; // ADD 2011/03/01
            this.tEdit_MazdaSectionCode.Text = ""; // ADD 2011/03/15
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                //クローン作成
                UOESupplier uoeSupplier = new UOESupplier();
                this._uoeSupplierClone = uoeSupplier.Clone();

                DispToUOESupplier(ref this._uoeSupplierClone);

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);
                
                //_dataIndexバッファ保持
                this._indexBuf = this._dataIndex;

                // フォーカス設定
                this.UOESupplierCd_tNedit.Focus();
            }
            else
            {
                string guid = (string)this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[this._dataIndex][GUID_TITLE];
                UOESupplier uoeSupplier = (UOESupplier)this._uoeSupplierTable[guid];

                if (uoeSupplier.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面展開処理
                    UOESupplierToScreen(uoeSupplier);

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    //クローン作成
                    this._uoeSupplierClone = uoeSupplier.Clone();
                    DispToUOESupplier(ref this._uoeSupplierClone);

                    //_dataIndexバッファ保持
                    this._indexBuf = this._dataIndex;

                    // フォーカス設定
                    this.tNedit_GoodsMakerCdAllowZero.Focus();
                    this.tNedit_GoodsMakerCdAllowZero.SelectAll();
                }
                else
                {
                    // 削除モード
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面展開処理
                    UOESupplierToScreen(uoeSupplier);

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(DELETE_MODE);

                    //_dataIndexバッファ保持
                    this._indexBuf = this._dataIndex;

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }
            }
        }

        /// <summary>
        /// 画面許可制御処理
        /// </summary>
        /// <param name="screenMode">画面モード</param>
        /// <remarks>
        /// <br>Note       : 画面モード毎に入力／ボタンの許可を制御します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>UpdateNote : 2010/03/08 楊明俊 日産Web-UOE連動項目の対応</br>
		/// <br>UpdateNote : 2010/04/23 jiangk 三菱Web-UOE連動項目の対応</br>
        /// <br>UpdateNote : 2010/05/14 呉元嘯 明治UOEWeb項目の対応</br>
        /// <br>UpdateNote : 2010/07/27 朱猛 トヨタUOEWeb項目の対応</br>
        /// <br>UpdateNote : 2011/03/15 liyp プログラム「0206」の追加仕様分の組み込み</br>
        /// <br>UpdateNote : 2011/05/10 施炳中 マツダUOE-WEB対応に伴う仕様追加</br>
        /// <br>UpdateNote : 2011/10/26 葛中華 PM1113A 卸NET-WEB対応に伴う仕様追加</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string screenMode)
        {
            // 新規
            if (screenMode.Equals(INSERT_MODE))
            {
                // ボタン設定
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.uButton_UOESupplierGuide.Enabled = true;
                this.uButton_MakerGuide.Enabled = true;
                this.uButton_UOEShipSectGuide.Enabled = true;
                this.uButton_UOESalSectGuide.Enabled = true;
                this.uButton_UOEReservSectGuide.Enabled = true;
                // 2008.11.05 30413 犬飼 仕入先と依頼者のガイドボタンを追加 >>>>>>START
                this.uButton_SupplierGuide.Enabled = true;
                this.uButton_EmployeeGuide.Enabled = true;
                // 2008.11.05 30413 犬飼 仕入先と依頼者のガイドボタンを追加 <<<<<<END
                

                // 入力設定
                this.UOESupplierCd_tNedit.Enabled = true;                   // 発注先コード
                this.UOESupplierName_tEdit.Enabled = true;                  // 発注先名称
                this.tNedit_GoodsMakerCdAllowZero.Enabled = true;           // メーカーコード
                this.tNedit_SupplierCd.Enabled = true;                      // 仕入先コード
                this.TelNo_tEdit.Enabled = true;                            // 電話番号
                this.UOETerminalCd_tEdit.Enabled = true;                    // 端末コード
                this.UOEHostCode_tEdit.Enabled = true;                      // ホストコード
                this.UOEConnectPassword_tEdit.Enabled = true;               // パスワード
                this.UOEConnectUserId_tEdit.Enabled = true;                 // ユーザーコード
                this.UOEIDNum_tEdit.Enabled = true;                         // ＩＤ番号
                this.CommAssemblyId_tEdit.Enabled = true;                   // プログラム
                this.ConnectVersionDiv_tComboEditor.Enabled = true;         // Ver
                this.UOEShipSectCd_tEdit.Enabled = true;                    // 出庫拠点コード
                this.UOESalSectCd_tEdit.Enabled = true;                     // 売上拠点コード
                this.UOEReservSectCd_tEdit.Enabled = true;                  // 指定拠点コード
                this.ReceiveCondition_tComboEditor.Enabled = true;          // 受信有無区分
                this.SubstPartsNoDiv_tComboEditor.Enabled = true;           // 代替品番区分
                this.PartsNoPrtCd_tComboEditor.Enabled = true;              // 品番印刷区分
                this.ListPriceUseDiv_tComboEditor.Enabled = true;           // 定価使用区分
                this.StockSlipDtRecvDiv_tComboEditor.Enabled = true;        // 仕入受信区分
                this.BusinessCode_tComboEditor.Enabled = true;              // 業務区分
                this.UOEResvdSection_tComboEditor.Enabled = true;           // 指定拠点
                this.tEdit_EmployeeCode.Enabled = true;                     // 依頼者
                this.DeliveredGoodsDiv_tComboEditor.Enabled = true;         // 納品区分
                this.BoCode_tComboEditor.Enabled = true;                    // ＢＯ区分
                // 2008.11.05 30413 犬飼 削除 >>>>>>START
                //this.UOEResvdSection_tEdit.Enabled = true;                  // 指定拠点
                //this.EmployeeCode_tEdit.Enabled = true;                     // 依頼者
                //this.DeliveredGoodsDiv_tNedit.Enabled = true;               // 納品区分
                //this.BoCode_tEdit.Enabled = true;                           // ＢＯ区分
                // 2008.11.05 30413 犬飼 削除 <<<<<<END
                this.UOEOrderRate_tEdit.Enabled = true;                     // レート
                this.EnableOdrMakerNm1_tEdit.Enabled = false;               // 発注可能メーカー名称１
                this.EnableOdrMakerNm2_tEdit.Enabled = false;               // 発注可能メーカー名称２
                this.EnableOdrMakerNm3_tEdit.Enabled = false;               // 発注可能メーカー名称３
                this.EnableOdrMakerNm4_tEdit.Enabled = false;               // 発注可能メーカー名称４
                this.EnableOdrMakerNm5_tEdit.Enabled = false;               // 発注可能メーカー名称５
                this.EnableOdrMakerNm6_tEdit.Enabled = false;               // 発注可能メーカー名称６

                // 入力項目の有効無効チェック
                InputEnableCheck();
            
            }
            // 更新
            else if (screenMode.Equals(UPDATE_MODE))
            {
                // ボタン設定
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.uButton_UOESupplierGuide.Enabled = false;
                this.uButton_MakerGuide.Enabled = true;
                this.uButton_UOEShipSectGuide.Enabled = true;
                this.uButton_UOESalSectGuide.Enabled = true;
                this.uButton_UOEReservSectGuide.Enabled = true;
                // 2008.11.05 30413 犬飼 仕入先と依頼者のガイドボタンを追加 >>>>>>START
                this.uButton_SupplierGuide.Enabled = true;
                this.uButton_EmployeeGuide.Enabled = true;
                // 2008.11.05 30413 犬飼 仕入先と依頼者のガイドボタンを追加 <<<<<<END

                // 入力設定
                this.UOESupplierCd_tNedit.Enabled = false;                  // 発注先コード
                this.UOESupplierName_tEdit.Enabled = true;                  // 発注先名称
                this.tNedit_GoodsMakerCdAllowZero.Enabled = true;           // メーカーコード
                this.tNedit_SupplierCd.Enabled = true;                      // 仕入先コード
                this.TelNo_tEdit.Enabled = true;                            // 電話番号
                this.UOETerminalCd_tEdit.Enabled = true;                    // 端末コード
                this.UOEHostCode_tEdit.Enabled = true;                      // ホストコード
                this.UOEConnectPassword_tEdit.Enabled = true;               // パスワード
                this.UOEConnectUserId_tEdit.Enabled = true;                 // ユーザーコード
                this.UOEIDNum_tEdit.Enabled = true;                         // ＩＤ番号
                this.CommAssemblyId_tEdit.Enabled = true;                   // プログラム
                this.ConnectVersionDiv_tComboEditor.Enabled = true;         // Ver
                this.UOEShipSectCd_tEdit.Enabled = true;                    // 出庫拠点コード
                this.UOESalSectCd_tEdit.Enabled = true;                     // 売上拠点コード
                this.UOEReservSectCd_tEdit.Enabled = true;                  // 指定拠点コード
                this.ReceiveCondition_tComboEditor.Enabled = true;          // 受信有無区分
                this.SubstPartsNoDiv_tComboEditor.Enabled = true;           // 代替品番区分
                this.PartsNoPrtCd_tComboEditor.Enabled = true;              // 品番印刷区分
                this.ListPriceUseDiv_tComboEditor.Enabled = true;           // 定価使用区分
                this.StockSlipDtRecvDiv_tComboEditor.Enabled = true;        // 仕入受信区分
                this.BusinessCode_tComboEditor.Enabled = true;              // 業務区分
                this.UOEResvdSection_tComboEditor.Enabled = true;           // 指定拠点
                this.tEdit_EmployeeCode.Enabled = true;                     // 依頼者
                this.DeliveredGoodsDiv_tComboEditor.Enabled = true;         // 納品区分
                this.BoCode_tComboEditor.Enabled = true;                    // ＢＯ区分
                // 2008.11.05 30413 犬飼 削除 >>>>>>START
                //this.UOEResvdSection_tEdit.Enabled = true;                  // 指定拠点
                //this.EmployeeCode_tEdit.Enabled = true;                     // 依頼者
                //this.DeliveredGoodsDiv_tNedit.Enabled = true;               // 納品区分
                //this.BoCode_tEdit.Enabled = true;                           // ＢＯ区分
                // 2008.11.05 30413 犬飼 削除 <<<<<<END
                this.UOEOrderRate_tEdit.Enabled = true;                     // レート
                this.EnableOdrMakerNm1_tEdit.Enabled = false;               // 発注可能メーカー名称１
                this.EnableOdrMakerNm2_tEdit.Enabled = false;               // 発注可能メーカー名称２
                this.EnableOdrMakerNm3_tEdit.Enabled = false;               // 発注可能メーカー名称３
                this.EnableOdrMakerNm4_tEdit.Enabled = false;               // 発注可能メーカー名称４
                this.EnableOdrMakerNm5_tEdit.Enabled = false;               // 発注可能メーカー名称５
                this.EnableOdrMakerNm6_tEdit.Enabled = false;               // 発注可能メーカー名称６

                // 入力項目の有効無効チェック
                InputEnableCheck();

            }
            // 削除
            else if (screenMode.Equals(DELETE_MODE))
            {
                // ボタン設定
                this.Ok_Button.Visible = false;
                this.Delete_Button.Visible = true;
                this.Revive_Button.Visible = true;
                this.uButton_UOESupplierGuide.Enabled = false;
                this.uButton_MakerGuide.Enabled = false;
                this.uButton_UOEShipSectGuide.Enabled = false;
                this.uButton_UOESalSectGuide.Enabled = false;
                this.uButton_UOEReservSectGuide.Enabled = false;
                this.uButton_EnableOdrMaker1Guide.Enabled = false;
                this.uButton_EnableOdrMaker2Guide.Enabled = false;
                this.uButton_EnableOdrMaker3Guide.Enabled = false;
                this.uButton_EnableOdrMaker4Guide.Enabled = false;
                this.uButton_EnableOdrMaker5Guide.Enabled = false;
                this.uButton_EnableOdrMaker6Guide.Enabled = false;
                // 2008.11.05 30413 犬飼 仕入先と依頼者のガイドボタンを追加 >>>>>>START
                this.uButton_SupplierGuide.Enabled = false;
                this.uButton_EmployeeGuide.Enabled = false;
                // 2008.11.05 30413 犬飼 仕入先と依頼者のガイドボタンを追加 <<<<<<END
                this.uButton_AnswerSaveFolder.Enabled = false;          //ADD 2009/06/01

                // 入力設定
                this.UOESupplierCd_tNedit.Enabled = false;                  // 発注先コード
                this.UOESupplierName_tEdit.Enabled = false;                 // 発注先名称
                this.tNedit_GoodsMakerCdAllowZero.Enabled = false;          // メーカーコード
                this.tNedit_SupplierCd.Enabled = false;                     // 仕入先コード
                this.TelNo_tEdit.Enabled = false;                           // 電話番号
                this.UOETerminalCd_tEdit.Enabled = false;                   // 端末コード
                this.UOEHostCode_tEdit.Enabled = false;                     // ホストコード
                this.UOEConnectPassword_tEdit.Enabled = false;              // パスワード
                this.UOEConnectUserId_tEdit.Enabled = false;                // ユーザーコード
                this.UOEIDNum_tEdit.Enabled = false;                        // ＩＤ番号
                this.CommAssemblyId_tEdit.Enabled = false;                  // プログラム
                this.ConnectVersionDiv_tComboEditor.Enabled = false;        // Ver
                this.UOEShipSectCd_tEdit.Enabled = false;                   // 出庫拠点コード
                this.UOESalSectCd_tEdit.Enabled = false;                    // 売上拠点コード
                this.UOEReservSectCd_tEdit.Enabled = false;                 // 指定拠点コード
                this.ReceiveCondition_tComboEditor.Enabled = false;         // 受信有無区分
                this.SubstPartsNoDiv_tComboEditor.Enabled = false;          // 代替品番区分
                this.PartsNoPrtCd_tComboEditor.Enabled = false;             // 品番印刷区分
                this.ListPriceUseDiv_tComboEditor.Enabled = false;          // 定価使用区分
                this.StockSlipDtRecvDiv_tComboEditor.Enabled = false;       // 仕入受信区分
                this.CheckCodeDiv_tComboEditor.Enabled = false;             // チェック区分
                this.BusinessCode_tComboEditor.Enabled = false;             // 業務区分
                this.UOEResvdSection_tComboEditor.Enabled = false;          // 指定拠点
                this.tEdit_EmployeeCode.Enabled = false;                    // 依頼者
                this.DeliveredGoodsDiv_tComboEditor.Enabled = false;        // 納品区分
                this.BoCode_tComboEditor.Enabled = false;                   // ＢＯ区分
                // 2008.11.05 30413 犬飼 削除 >>>>>>START
                //this.UOEResvdSection_tEdit.Enabled = false;                 // 指定拠点
                //this.EmployeeCode_tEdit.Enabled = false;                    // 依頼者
                //this.DeliveredGoodsDiv_tNedit.Enabled = false;              // 納品区分
                //this.BoCode_tEdit.Enabled = false;                          // ＢＯ区分
                this.UOEOrderRate_tEdit.Enabled = false;                    // レート
                this.instrumentNo_tEdit.Enabled = false;                    // 号機
                this.UOETestMode_tEdit.Enabled = false;                     // テストモード
                this.UOEItemCd_tEdit.Enabled = false;                       // アイテム
                this.HondaSectionCode_tEdit.Enabled = false;                // 担当拠点
                //this.AnswerSaveFolder_tEdit.Enabled = false;                // 回答保存フォルダ
                // 2008.11.05 30413 犬飼 削除 <<<<<<END
                this.MazdaSectionCode_tEdit.Enabled = false;                // 自拠点
                this.EmergencyDiv_tComboEditor.Enabled = false;             // 緊急区分
                this.EnableOdrMakerCd1_tNedit.Enabled = false;              // 発注可能メーカーコード１
                this.EnableOdrMakerNm1_tEdit.Enabled = false;               // 発注可能メーカー名称１
                this.EnableOdrMakerCd2_tNedit.Enabled = false;              // 発注可能メーカーコード２
                this.EnableOdrMakerNm2_tEdit.Enabled = false;               // 発注可能メーカー名称２
                this.EnableOdrMakerCd3_tNedit.Enabled = false;              // 発注可能メーカーコード３
                this.EnableOdrMakerNm3_tEdit.Enabled = false;               // 発注可能メーカー名称３
                this.EnableOdrMakerCd4_tNedit.Enabled = false;              // 発注可能メーカーコード４
                this.EnableOdrMakerNm4_tEdit.Enabled = false;               // 発注可能メーカー名称４
                this.EnableOdrMakerCd5_tNedit.Enabled = false;              // 発注可能メーカーコード５
                this.EnableOdrMakerNm5_tEdit.Enabled = false;               // 発注可能メーカー名称５
                this.EnableOdrMakerCd6_tNedit.Enabled = false;              // 発注可能メーカーコード６
                this.EnableOdrMakerNm6_tEdit.Enabled = false;               // 発注可能メーカー名称６
                // ---ADD 2009/06/01 --------------------------------------->>>>>
                this.AnswerSaveFolder_tEdit.Enabled = false;                // 回答保存フォルダ
                this.UOELoginUrl_tEdit.Enabled = false;                     // ログイン用URL
                this.UOEOrderUrl_tEdit.Enabled = false;                     // 発注用URL
                this.UOEStockCheckUrl_tEdit.Enabled = false;                // 在庫確認用URL
                this.UOEForcedTermUrl_tEdit.Enabled = false;                // 強制終了用URL
                this.InqOrdDivCd_tComboEditor.Enabled = false;              // 接続種別
                this.LoginTimeoutVal_tNedit.Enabled = false;                // ログイン認証時間
                this.UOEePartsItemCd_tEdit.Enabled = false;                 // アイテム[ホンダe-Parts項目]
                this.EPartsUserId_tEdit.Enabled = false;                    // ユーザID
                this.EPartsPassWord_tEdit.Enabled = false;                  // パスワード
                this.AnswerSaveFolderOfTOYOTA_tEdit.Enabled = false;                // トヨタ電子カタログの回答保存フォルダ　// ADD 2009/12/29 xuxh
                // ---ADD 2010/03/08 ---------------------------------------->>>>>
                this.NissanAnswerSaveFolder_tEdit.Enabled = false;          // 日産の回答保存フォルダ
                // ---ADD 2010/03/08 ----------------------------------------<<<<<
				// ---ADD 2010/04/23 ---------------------------------------->>>>>
				this.MitsubishiAnswerSaveFolder_tEdit.Enabled = false;      // 三菱の回答保存フォルダ
				// ---ADD 2010/04/23 ----------------------------------------<<<<<
                // ---ADD 2011/05/10 ---------------------------------------->>>>>
                this.MazdaAnswerSaveFolder_tEdit.Enabled = false;           // マツダ回答保存フォルダ
                this.uButton_MazdaAnswerSaveFolder.Enabled = false;
                // ---ADD 2011/05/10 ----------------------------------------<<<<<
                int commAssemblyId = 0;
                if (CommAssemblyId_tEdit.Text.Trim() != "")
                {
                    commAssemblyId = int.Parse(CommAssemblyId_tEdit.Text.Trim());
                }
                if (commAssemblyId != 502)
                {
                    this.InqOrdDivCd_tComboEditor.Value = null;

                    // ---ADD 2011/01/28 --------------------------------------->>>>>
                    this.AnswerSaveFolder_tEdit.Clear(); // 回答保存フォルダ
                    this.UOEOrderUrl_tEdit.Clear(); // 発注用URL
                    this.UOEStockCheckUrl_tEdit.Clear(); // 在庫確認用URL
                    this.UOEForcedTermUrl_tEdit.Clear(); // 強制終了用URL
                    // ---ADD 2011/01/28 ---------------------------------------<<<<<
                }
                // ---ADD 2009/06/01 ---------------------------------------<<<<<

                // ---ADD 2010/05/14 --------------------------------------->>>>>
                this.MeiJiUoeSystemUseType_tEdit.Enabled = false;       // システム利用形態
                this.MeiJiUoeEigyousyoCode_tEdit.Enabled = false;        // 営業所コード
                this.MeiJiUoeEigyousyoFlag_tEdit.Enabled = false;       // 営業所フラグ
                this.MeiJiUoeJigyousyoCode_tEdit.Enabled = false;    // 事業所コード
                this.MeiJiUoeCoCode_tEdit.Enabled = false;       // 会社コード
                this.MeiJiUoeTerminalID_tEdit.Enabled = false;        // 端末ID
                this.MeiJiUoePassword_tEdit.Enabled = false;        // パスワード
                // ---ADD 2010/05/14 ---------------------------------------<<<<<
                // ---ADD 2011/10/26 --------------------------------------->>>>>
                this.Protocol_tComboEditor.Enabled = false;         // プロトコル
                this.Connection_tComboEditor.Enabled = false;       // 接続区分
                this.CarMaker_uButton.Enabled = false;              // 外車対応メーカー
                this.Domain_tEdit.Enabled = false;                  // ドメイン
                this.OrderAddress_tEdit.Enabled = false;            // 発注用アドレス
                this.RestoreAddress_tEdit.Enabled = false;          // 復旧用アドレス
                this.PurchaseAddress_tEdit.Enabled = false;         // 仕入受信用アドレス
                this.TimeOut_tEdit.Enabled = false;                 // タイムアウト
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                this.BLMngUserCode_tEdit.Enabled = false;          // BL管理ユーザーコード
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
                // ---ADD 2011/10/26 ---------------------------------------<<<<<
                // ---ADD 2010/07/27 --------------------------------------->>>>>
                // 回答自動取込区分
                this.AnswerAutoDiv_tComboEditor.Enabled = false;
                // WEBパスワード
                this.WebPassword_tEdit.Enabled = false;
                // WEBユーザーID
                this.WebUserID_tEdit.Enabled = false;
                // WEB接続先コード
                this.WebConnectCode_tEdit.Enabled = false;
                // ---ADD 2010/07/27 ---------------------------------------<<<<<

                // ---ADD 2010/12/31 --------------------------------------->>>>>
                this.uButton_AnswerSaveFolderOfTOYOTA.Enabled = false;
                this.uButton_NissanAnswerSaveFolder.Enabled = false;
                this.uButton_MitsubishiAnswerSaveFolder.Enabled = false;
                // ---ADD 2010/12/31 ---------------------------------------<<<<<
                // 回答自動取込区分(日産WEBUOE用)
                this.Nissan_AnswerAutoDiv_tComboEditor.Enabled = false;//ADD 2011/03/01
                this.tEdit_MazdaSectionCode.Enabled = false; // ADD 2011/03/15
                // ---ADD 2011/05/10 --------------------------------------->>>>>
                this.tEdit_HondaSectionCode.Enabled = false;
                // ---ADD 2011/05/10 ---------------------------------------<<<<<
                //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                this.MakerCd1_tComboEditor.Enabled = false;
                this.MakerCd2_tComboEditor.Enabled = false;
                this.MakerCd3_tComboEditor.Enabled = false;
                this.MakerCd4_tComboEditor.Enabled = false;
                this.MakerCd5_tComboEditor.Enabled = false;
                this.MakerCd6_tComboEditor.Enabled = false;
                //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
            }
        }

        /// <summary>
        /// UOE発注先マスタ クラス画面展開処理
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先マスタ オブジェクト</param>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタ オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>Update Note: 2010/01/19 譚洪 Redmine#2505の対応</br>
        /// <br>Update Note: 2010/03/08 楊明俊 日産Web-UOE連動項目の対応</br>
		/// <br>Update Note: 2010/04/23 jiangk 三菱Web-UOE連動項目の対応</br>
        /// <br>UpdateNote : 2010/05/14 呉元嘯 明治UOEWeb項目の対応</br>
        /// <br>UpdateNote : 2010/07/27 朱 猛 トヨタUOEWeb項目の対応</br>
        /// <br>UpdateNote : 2011/01/28 施炳中 回答自動取込区分（トヨタWEBUOE用自動連携用の設定区分）の変更</br>
        /// <br>UpdateNote : 2011/03/01 liyp 回答自動取込区分（日産WEBUOE用自動連携用の設定区分）の変更</br>
        /// <br>UpdateNote : 2011/03/15 liyp プログラム「0206」の追加仕様分の組み込み</br>       
        /// <br>UpdateNote : 2011/05/10 施炳中 マツダUOE-WEB対応に伴う仕様追加</br>
        /// <br>UpdateNote : 2011/10/26 葛中華 PM1113A 卸NET-WEB対応に伴う仕様追加</br>
        /// </remarks>
        private void UOESupplierToScreen(UOESupplier uoeSupplier)
        {
            this.UOESupplierCd_tNedit.SetInt(uoeSupplier.UOESupplierCd);                        // 発注先コード
            this.UOESupplierName_tEdit.Text = uoeSupplier.UOESupplierName;                      // 発注先名称
            this.tNedit_GoodsMakerCdAllowZero.SetInt(uoeSupplier.GoodsMakerCd);                 // メーカーコード
            if (uoeSupplier.GoodsMakerCd == 0)
            {
                this.GoodsMakerNm_tEdit.Text = MAKER_CODE_ZERO;                                 // メーカー名称（卸商）
            }
            else
            {
                this.GoodsMakerNm_tEdit.Text = GetMakerName(uoeSupplier.GoodsMakerCd);          // メーカー名称
            }
            this.tNedit_SupplierCd.SetInt(uoeSupplier.SupplierCd);                              // 仕入先コード
            this.SupplierNm_tEdit.Text = GetSupplierName(uoeSupplier.SupplierCd);               // 仕入先名称
            this.TelNo_tEdit.Text = uoeSupplier.TelNo;                                          // 電話番号
            this.UOETerminalCd_tEdit.Text = uoeSupplier.UOETerminalCd;                          // 端末コード
            this.UOEHostCode_tEdit.Text = uoeSupplier.UOEHostCode;                              // ホストコード
            this.UOEConnectPassword_tEdit.Text = uoeSupplier.UOEConnectPassword;                // パスワード
            this.UOEConnectUserId_tEdit.Text = uoeSupplier.UOEConnectUserId;                    // ユーザーコード
            this.UOEIDNum_tEdit.Text = uoeSupplier.UOEIDNum;                                    // ＩＤ番号
            this.CommAssemblyId_tEdit.Text = uoeSupplier.CommAssemblyId;                        // プログラム
            this.ConnectVersionDiv_tComboEditor.Value = uoeSupplier.ConnectVersionDiv;          // Ver
            this.UOEShipSectCd_tEdit.Text = uoeSupplier.UOEShipSectCd;                          // 出庫拠点コード
            this.UOEShipSectNm_tEdit.Text = GetUOEGuideName(uoeSupplier.UOESupplierCd, uoeSupplier.UOEShipSectCd);         // 出庫拠点名称
            this.UOESalSectCd_tEdit.Text = uoeSupplier.UOESalSectCd;                            // 売上拠点コード
            this.UOESalSectNm_tEdit.Text = GetUOEGuideName(uoeSupplier.UOESupplierCd, uoeSupplier.UOESalSectCd);           // 売上拠点名称
            this.UOEReservSectCd_tEdit.Text = uoeSupplier.UOEReservSectCd;                      // 指定拠点コード
            this.UOEReservSectNm_tEdit.Text = GetUOEGuideName(uoeSupplier.UOESupplierCd, uoeSupplier.UOEReservSectCd);     // 指定拠点名称
            this.ReceiveCondition_tComboEditor.Value = uoeSupplier.ReceiveCondition;            // 受信有無区分
            this.SubstPartsNoDiv_tComboEditor.Value = uoeSupplier.SubstPartsNoDiv;              // 代替品番区分
            this.PartsNoPrtCd_tComboEditor.Value = uoeSupplier.PartsNoPrtCd;                    // 品番印刷区分
            this.ListPriceUseDiv_tComboEditor.Value = uoeSupplier.ListPriceUseDiv;              // 定価使用区分
            this.StockSlipDtRecvDiv_tComboEditor.Value = uoeSupplier.StockSlipDtRecvDiv;        // 仕入受信区分
            this.CheckCodeDiv_tComboEditor.Value = uoeSupplier.CheckCodeDiv;                    // チェック区分

            // 2008.11.05 30413 犬飼 初期値設定項目のコンボボックス追加 >>>>>>START            
            // 指定拠点
            this.InitialSettingUOEResvdSection();

            // 納品区分
            this.InitialSettingDeliveredGoodsDiv();

            // ＢＯ区分
            this.InitialSettingBoCode();
            // 2008.11.05 30413 犬飼 初期値設定項目のコンボボックス追加 <<<<<<END

            this.BusinessCode_tComboEditor.Value = uoeSupplier.BusinessCode;                    // 業務区分

            // 2009/09/14 トリムを実行するように変更 >>>
            //this.UOEResvdSection_tComboEditor.Value = uoeSupplier.UOEResvdSection;              // 指定拠点
            this.UOEResvdSection_tComboEditor.Value = uoeSupplier.UOEResvdSection.TrimEnd();              // 指定拠点
            // 2009/09/14 <<<
         
            // 2009.02.04 30413 依頼者コードはトリムを実施 >>>>>>START
            //this.tEdit_EmployeeCode.Text = uoeSupplier.EmployeeCode;                            // 依頼者
            this.tEdit_EmployeeCode.Text = uoeSupplier.EmployeeCode.TrimEnd();                  // 依頼者
            // 2009.02.04 30413 依頼者コードはトリムを実施 <<<<<<END
            this.tEdit_EmployeeName.Text = GetEmployeeName(uoeSupplier.EmployeeCode);           // 依頼者名称
            // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 >>>>>>START
            //this.DeliveredGoodsDiv_tComboEditor.Value = uoeSupplier.DeliveredGoodsDiv;          // 納品区分
            this.DeliveredGoodsDiv_tComboEditor.Value = uoeSupplier.UOEDeliGoodsDiv;          // UOE納品区分
            // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 <<<<<<END
            this.BoCode_tComboEditor.Value = uoeSupplier.BoCode;                                // ＢＯ区分
            // 2008.11.05 30413 犬飼 削除 >>>>>>START
            //this.UOEResvdSection_tEdit.Text = uoeSupplier.UOEResvdSection;                      // 指定拠点
            //this.EmployeeCode_tEdit.Text = uoeSupplier.EmployeeCode;                            // 依頼者
            //this.DeliveredGoodsDiv_tNedit.SetInt(uoeSupplier.DeliveredGoodsDiv);                // 納品区分
            //this.BoCode_tEdit.Text = uoeSupplier.BoCode;                                        // ＢＯ区分
            this.UOEOrderRate_tEdit.Text = uoeSupplier.UOEOrderRate;                            // レート
            this.instrumentNo_tEdit.Text = uoeSupplier.instrumentNo;                            // 号機
            this.UOETestMode_tEdit.Text = uoeSupplier.UOETestMode;                              // テストモード
            //this.UOEItemCd_tEdit.Text = uoeSupplier.UOEItemCd;                                  // アイテム       //DEL 2009/06/01
            this.HondaSectionCode_tEdit.Text = uoeSupplier.HondaSectionCode;                    // 担当拠点
            //this.AnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;                    // 回答保存フォルダ
            // 2008.11.05 30413 犬飼 削除 <<<<<<END
            this.MazdaSectionCode_tEdit.Text = uoeSupplier.MazdaSectionCode;                    // 自拠点
            this.EmergencyDiv_tComboEditor.Value = uoeSupplier.EmergencyDiv;                    // 緊急区分
            this.EnableOdrMakerCd1_tNedit.SetInt(uoeSupplier.EnableOdrMakerCd1);                // 発注可能メーカーコード１
            this.EnableOdrMakerNm1_tEdit.Text = GetMakerName(uoeSupplier.EnableOdrMakerCd1);    // 発注可能メーカー名称１
            this.EnableOdrMakerCd2_tNedit.SetInt(uoeSupplier.EnableOdrMakerCd2);                // 発注可能メーカーコード２
            this.EnableOdrMakerNm2_tEdit.Text = GetMakerName(uoeSupplier.EnableOdrMakerCd2);    // 発注可能メーカー名称２
            this.EnableOdrMakerCd3_tNedit.SetInt(uoeSupplier.EnableOdrMakerCd3);                // 発注可能メーカーコード３
            this.EnableOdrMakerNm3_tEdit.Text = GetMakerName(uoeSupplier.EnableOdrMakerCd3);    // 発注可能メーカー名称３
            this.EnableOdrMakerCd4_tNedit.SetInt(uoeSupplier.EnableOdrMakerCd4);                // 発注可能メーカーコード４
            this.EnableOdrMakerNm4_tEdit.Text = GetMakerName(uoeSupplier.EnableOdrMakerCd4);    // 発注可能メーカー名称４
            this.EnableOdrMakerCd5_tNedit.SetInt(uoeSupplier.EnableOdrMakerCd5);                // 発注可能メーカーコード５
            this.EnableOdrMakerNm5_tEdit.Text = GetMakerName(uoeSupplier.EnableOdrMakerCd5);    // 発注可能メーカー名称５
            this.EnableOdrMakerCd6_tNedit.SetInt(uoeSupplier.EnableOdrMakerCd6);                // 発注可能メーカーコード６
            this.EnableOdrMakerNm6_tEdit.Text = GetMakerName(uoeSupplier.EnableOdrMakerCd6);    // 発注可能メーカー名称６
            // ---ADD 2009/06/01 ------------------------------------------------------------>>>>>
            this.AnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;                    // 回答保存フォルダ
            // ---------------------------- ADD 2009/12/29 xuxh -------------------------------->>>>>
            //if (this.CommAssemblyId_tEdit.Text == "0103" || this.CommAssemblyId_tEdit.Text == "103")   // DEL 2010/01/19
            if ("0103".Equals(this.CommAssemblyId_tEdit.Text))                                           // ADD 2010/01/19
            {
                this.AnswerSaveFolderOfTOYOTA_tEdit.Text = uoeSupplier.AnswerSaveFolder;
                // ---ADD 2010/07/27 ----------------------------------------------------------->>>>>
                // 回答自動取込区分
                if ((uoeSupplier.InqOrdDivCd != 0) && (uoeSupplier.InqOrdDivCd) != 1)
                {
                    this.AnswerAutoDiv_tComboEditor.Value = 0;
                }
                else
                {
                    this.AnswerAutoDiv_tComboEditor.Value = uoeSupplier.InqOrdDivCd;
                }
                // WEBパスワード
                this.WebPassword_tEdit.Text = uoeSupplier.UOEOrderUrl;
                // WEBユーザーID
                this.WebUserID_tEdit.Text = uoeSupplier.UOEStockCheckUrl;
                // WEB接続先コード
                this.WebConnectCode_tEdit.Text = uoeSupplier.UOEForcedTermUrl;
                // ---ADD 2010/07/27 -----------------------------------------------------------<<<<<

                //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                this.MakerCd1_tComboEditor.Visible = true;
                this.MakerCd2_tComboEditor.Visible = true;
                this.MakerCd3_tComboEditor.Visible = true;
                this.MakerCd4_tComboEditor.Visible = true;
                this.MakerCd5_tComboEditor.Visible = true;
                this.MakerCd6_tComboEditor.Visible = true;
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd1_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd1_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd1_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd2_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd2_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd2_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd3_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd3_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd3_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd4_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd4_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd4_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd5_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd5_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd5_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd6_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd6_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd6_tComboEditor, false);
                }
                this.MakerCd1_tComboEditor.Value = uoeSupplier.OdrPrtsNoHyphenCd1;
                this.MakerCd2_tComboEditor.Value = uoeSupplier.OdrPrtsNoHyphenCd2;
                this.MakerCd3_tComboEditor.Value = uoeSupplier.OdrPrtsNoHyphenCd3;
                this.MakerCd4_tComboEditor.Value = uoeSupplier.OdrPrtsNoHyphenCd4;
                this.MakerCd5_tComboEditor.Value = uoeSupplier.OdrPrtsNoHyphenCd5;
                this.MakerCd6_tComboEditor.Value = uoeSupplier.OdrPrtsNoHyphenCd6;
                //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
            }
            // ---------------------------- ADD 2009/12/29 xuxh --------------------------------<<<<<

             // --- ADD 2011/01/28  -------------------------------->>>>>
            if ("0104".Equals(this.CommAssemblyId_tEdit.Text))                                          
            {
                this.AnswerSaveFolderOfTOYOTA_tEdit.Text = uoeSupplier.AnswerSaveFolder;
                // 回答自動取込区分
                //if ((uoeSupplier.InqOrdDivCd) != 1) // DEL 2011/01/28
                //{ // DEL 2011/01/28
                //    this.AnswerAutoDiv_tComboEditor.Value = 1; // DEL 2011/01/28
                //} // DEL 2011/01/28
                //else // DEL 2011/01/28
                //{ // DEL 2011/01/28
                    this.AnswerAutoDiv_tComboEditor.Value = uoeSupplier.InqOrdDivCd;
                //} // DEL 2011/01/28
                // WEBパスワード
                this.WebPassword_tEdit.Text = uoeSupplier.UOEOrderUrl;
                // WEBユーザーID
                this.WebUserID_tEdit.Text = uoeSupplier.UOEStockCheckUrl;
                // WEB接続先コード
                this.WebConnectCode_tEdit.Text = uoeSupplier.UOEForcedTermUrl;
            }
            // --- ADD 2011/01/28  --------------------------------<<<<<

            // ---ADD 2010/03/08 ---------------------------------------->>>>>
            if (NISSAN_COMMASSEMBLY_ID.Equals(this.CommAssemblyId_tEdit.Text))                                           // ADD 2010/01/19
            {
                this.NissanAnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;
                this.Nissan_AnswerAutoDiv_tComboEditor.Value = 0;// ADD 2011/03/01
            }
            // ---ADD 2010/03/08 ---------------------------------------->>>>>

            // ---ADD 2010/12/31 ---------------------------------------->>>>>
            if (AUTONISSAN_COMMASSEMBLY_ID.Equals(this.CommAssemblyId_tEdit.Text))                                 
            {
                this.NissanAnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;
                this.Nissan_AnswerAutoDiv_tComboEditor.Value = 1;// ADD 2011/03/01
            }

            if (AUTOMITSUBISHI_COMMASSEMBLY_ID.Equals(this.CommAssemblyId_tEdit.Text))
            {
                this.MitsubishiAnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;
            }
            // ---ADD 2010/12/31 ----------------------------------------<<<<<
            // ---ADD 2011/03/01 ---------------------------------------->>>>>
            if (AUTONISSAN_COMMASSEMBLY_ID_0205.Equals(this.CommAssemblyId_tEdit.Text))
            {
                this.NissanAnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;
                // 回答自動取込区分
                this.Nissan_AnswerAutoDiv_tComboEditor.Enabled = true;
                if ((uoeSupplier.InqOrdDivCd != 0) && (uoeSupplier.InqOrdDivCd) != 1)
                {
                    this.Nissan_AnswerAutoDiv_tComboEditor.Value = 0;
                }
                else
                {
                    this.Nissan_AnswerAutoDiv_tComboEditor.Value = uoeSupplier.InqOrdDivCd;
                }
                this.tEdit_MazdaSectionCode.Enabled = false;                 // ADD 2011/03/15
            }
            else if (AUTONISSAN_COMMASSEMBLY_ID_0206.Equals(this.CommAssemblyId_tEdit.Text))
            {
                this.NissanAnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;
                // 回答自動取込区分
                this.Nissan_AnswerAutoDiv_tComboEditor.Enabled = false;
                this.Nissan_AnswerAutoDiv_tComboEditor.Value = 1;
                this.tEdit_MazdaSectionCode.Enabled = true;                 // ADD 2011/03/15
                this.tEdit_MazdaSectionCode.Text = uoeSupplier.MazdaSectionCode; // ADD 2011/03/15
            }
            else 
            {
                this.Nissan_AnswerAutoDiv_tComboEditor.Enabled = false;
                this.tEdit_MazdaSectionCode.Enabled = false;                 // ADD 2011/03/15
            }
            // ---ADD 2011/03/01 ----------------------------------------<<<<<
			// ---ADD 2010/04/23 ---------------------------------------->>>>>
			if (MITSUBISHI_COMMASSEMBLY_ID.Equals(this.CommAssemblyId_tEdit.Text))                                       
			{
				this.MitsubishiAnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;
			}
			// ---ADD 2010/04/23 ----------------------------------------<<<<<
            this.UOELoginUrl_tEdit.Text = uoeSupplier.UOELoginUrl;                              // ログイン用URL
            this.UOEOrderUrl_tEdit.Text = uoeSupplier.UOEOrderUrl;                              // 発注用URL
            this.UOEStockCheckUrl_tEdit.Text = uoeSupplier.UOEStockCheckUrl;                    // 在庫確認用URL
            this.UOEForcedTermUrl_tEdit.Text = uoeSupplier.UOEForcedTermUrl;                    // 強制終了用URL
            this.InqOrdDivCd_tComboEditor.Value = uoeSupplier.InqOrdDivCd;                      // 接続種別
            this.LoginTimeoutVal_tNedit.SetInt(uoeSupplier.LoginTimeoutVal);                    // ログイン認証時間
            this.EPartsUserId_tEdit.Text = uoeSupplier.EPartsUserId;                            // ユーザID
            this.EPartsPassWord_tEdit.Text = uoeSupplier.EPartsPassWord;                        // パスワード

            // プログラムをInt型に変換
            int commAssemblyId = 0;
            if (CommAssemblyId_tEdit.Text.Trim() != "")
            {
                commAssemblyId = int.Parse(CommAssemblyId_tEdit.Text.Trim());
            }

            // ---ADD 2010/05/14 ------------------------------------------------------------>>>>>
            //明治UOEWeb項目場合
            if (commAssemblyId == 1004)
            {
                this.MeiJiUoeSystemUseType_tEdit.Text = uoeSupplier.UOETestMode;                // システム利用形態
                this.MeiJiUoeEigyousyoCode_tEdit.Text = uoeSupplier.UOEItemCd;                  // 営業所コード
                this.MeiJiUoeEigyousyoFlag_tEdit.Text = uoeSupplier.InqOrdDivCd.ToString();     // 営業所フラグ
                this.MeiJiUoeJigyousyoCode_tEdit.Text = uoeSupplier.UOELoginUrl;                // 事業所コード
                this.MeiJiUoeCoCode_tEdit.Text = uoeSupplier.UOEForcedTermUrl;                  // 会社コード
                this.MeiJiUoeTerminalID_tEdit.Text = uoeSupplier.EPartsUserId;                  // 端末ID
                this.MeiJiUoePassword_tEdit.Text = uoeSupplier.EPartsPassWord;                  // パスワード
            }
            // ---ADD 2010/05/14 ------------------------------------------------------------<<<<<
            // ---ADD 2011/10/26 ------------------------------------------------------------>>>>>
            //卸NET-WEB項目
            if (commAssemblyId == 1003)
            {
                this.Protocol_tComboEditor.Value = uoeSupplier.DaihatsuOrdreDiv;        // プロトコル
                this.Connection_tComboEditor.Value = uoeSupplier.InqOrdDivCd;           // 接続区分
                this.Domain_tEdit.Text = uoeSupplier.UOEOrderUrl;                       // ドメイン
                this.OrderAddress_tEdit.Text = uoeSupplier.UOEStockCheckUrl;            // 発注用アドレス
                this.RestoreAddress_tEdit.Text = uoeSupplier.UOEForcedTermUrl;          // 復旧用アドレス
                this.PurchaseAddress_tEdit.Text = uoeSupplier.UOELoginUrl;              // 仕入受信用アドレス
                this.TimeOut_tEdit.Text = uoeSupplier.LoginTimeoutVal.ToString();       // タイムアウト    
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                this.BLMngUserCode_tEdit.Text = uoeSupplier.BLMngUserCode.ToString();  // BL管理ユーザーコード
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
            }
            // ---ADD 2011/10/26 ------------------------------------------------------------<<<<<
            if (commAssemblyId == 501)
            {
                this.UOEItemCd_tEdit.Text = uoeSupplier.UOEItemCd;          // アイテム[ホンダ項目]
                this.UOEePartsItemCd_tEdit.Text = "";                       // アイテム[ホンダe-Parts項目]
            }
            else if (commAssemblyId == 502)
            {
                this.UOEItemCd_tEdit.Text = "";                             // アイテム[ホンダ項目]
                this.UOEePartsItemCd_tEdit.Text = uoeSupplier.UOEItemCd;    // アイテム[ホンダe-Parts項目]
            }
            else
            {
                this.UOEItemCd_tEdit.Text = "";                             // アイテム[ホンダ項目]
                this.UOEePartsItemCd_tEdit.Text = "";                       // アイテム[ホンダe-Parts項目]
            }
            // ---ADD 2009/06/01 ------------------------------------------------------------>>>>>
            // ---ADD 2011/05/10 ---------------------------------------->>>>
            if (MAZDA_COMMASSEMBLY_ID.Equals(this.CommAssemblyId_tEdit.Text))
            {
                this.MazdaAnswerSaveFolder_tEdit.Text = uoeSupplier.AnswerSaveFolder;
                this.tEdit_HondaSectionCode.Enabled = true;
                this.tEdit_HondaSectionCode.Text = uoeSupplier.HondaSectionCode.Trim().PadRight(3, ' ');
            }
            else
            {
                this.MazdaAnswerSaveFolder_tEdit.Enabled = false;
                this.uButton_MazdaAnswerSaveFolder.Enabled = false;
                this.tEdit_HondaSectionCode.Enabled = false;      
            }
            // ---ADD 2011/05/10 ----------------------------------------<<<<<
        }

        /// <summary>
        /// 画面情報UOE発注先マスタ クラス格納処理
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先マスタ オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からUOE発注先マスタ オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>UpdateNote : 2010/03/08 楊明俊 日産Web-UOE連動項目の対応</br>
		/// <br>UpdateNote : 2010/04/23 jiangk 三菱Web-UOE連動項目の対応</br>
        /// <br>UpdateNote : 2010/05/14 呉元嘯 明治UOEWeb項目の対応</br>
        /// <br>UpdateNote : 2010/07/27 朱 猛 トヨタUOEWeb項目の対応</br>
        /// <br>UpdateNote : 2011/01/28 施ヘイ中 回答自動取込区分（トヨタWEBUOE用自動連携用の設定区分）の変更</br>
        /// <br>UpdateNote : 2011/03/01 liyp 回答自動取込区分（日産WEBUOE用自動連携用の設定区分）の変更</br>
        /// <br>UpdateNote : 2011/03/15 liyp プログラム「0206」の追加仕様分の組み込み</br>
        /// <br>UpdateNote : 2011/05/10 施ヘイ中 マツダUOE-WEB対応に伴う仕様追加</br>
        /// </remarks>
        private void DispToUOESupplier(ref UOESupplier uoeSupplier)
        {
            if (uoeSupplier == null)
            {
                // 新規の場合
                uoeSupplier = new UOESupplier();
            }

            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
            // プログラム:1003 且つ 卸NET-WEB項目の接続区分がCタイプの場合のみBL管理ユーザーコードをセットする
            // そのため、予めBL管理ユーザーコードに空白をセットしておき、条件が揃ったときのみ値をセットする
            uoeSupplier.BLMngUserCode = string.Empty;
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<

            uoeSupplier.EnterpriseCode = this._enterpriseCode;                                  // 企業コード
            uoeSupplier.SectionCode = this._sectionCode;                                        // 拠点コード
            uoeSupplier.UOESupplierCd = this.UOESupplierCd_tNedit.GetInt();                     // 発注先コード
            uoeSupplier.UOESupplierName = this.UOESupplierName_tEdit.Text;                      // 発注先名称
            uoeSupplier.GoodsMakerCd = this.tNedit_GoodsMakerCdAllowZero.GetInt();              // メーカーコード
            uoeSupplier.SupplierCd = this.tNedit_SupplierCd.GetInt();                           // 仕入先コード
            uoeSupplier.TelNo = this.TelNo_tEdit.Text;                                          // 電話番号
            uoeSupplier.UOETerminalCd = this.UOETerminalCd_tEdit.Text;                          // 端末コード
            uoeSupplier.UOEHostCode = this.UOEHostCode_tEdit.Text;                              // ホストコード
            uoeSupplier.UOEConnectPassword = this.UOEConnectPassword_tEdit.Text;                // パスワード
            uoeSupplier.UOEConnectUserId = this.UOEConnectUserId_tEdit.Text;                    // ユーザーコード
            uoeSupplier.UOEIDNum = this.UOEIDNum_tEdit.Text;                                    // ＩＤ番号
            uoeSupplier.CommAssemblyId = this.CommAssemblyId_tEdit.Text;                        // プログラム
            uoeSupplier.ConnectVersionDiv = (int)this.ConnectVersionDiv_tComboEditor.Value;     // Ver
            uoeSupplier.UOEShipSectCd = this.UOEShipSectCd_tEdit.Text;                          // 出庫拠点コード
            uoeSupplier.UOESalSectCd = this.UOESalSectCd_tEdit.Text;                            // 売上拠点コード
            uoeSupplier.UOEReservSectCd = this.UOEReservSectCd_tEdit.Text;                      // 指定拠点コード
            uoeSupplier.ReceiveCondition = (int)this.ReceiveCondition_tComboEditor.Value;       // 受信有無区分
            uoeSupplier.SubstPartsNoDiv = (int)this.SubstPartsNoDiv_tComboEditor.Value;         // 代替品番区分
            uoeSupplier.PartsNoPrtCd = (int)this.PartsNoPrtCd_tComboEditor.Value;               // 品番印刷区分
            uoeSupplier.ListPriceUseDiv = (int)this.ListPriceUseDiv_tComboEditor.Value;         // 定価使用区分
            uoeSupplier.StockSlipDtRecvDiv = (int)this.StockSlipDtRecvDiv_tComboEditor.Value;   // 仕入受信区分
            uoeSupplier.CheckCodeDiv = (int)this.CheckCodeDiv_tComboEditor.Value;               // チェック区分
            if (this.BusinessCode_tComboEditor.Value != null)
            {
                uoeSupplier.BusinessCode = (int)this.BusinessCode_tComboEditor.Value;               // 業務区分
            }
            if (this.UOEResvdSection_tComboEditor.Value != null)
            {
                uoeSupplier.UOEResvdSection = (string)this.UOEResvdSection_tComboEditor.Value;      // 指定拠点
            }
            // 2009.02.04 30413 犬飼 未入力の場合は空文字を設定するように修正 >>>>>>START
            //uoeSupplier.EmployeeCode = this.tEdit_EmployeeCode.Text.TrimEnd().PadLeft(4, '0');  // 依頼者
            if (this.tEdit_EmployeeCode.Text.TrimEnd() == "")
            {
                uoeSupplier.EmployeeCode = "";
            }
            else
            {
                uoeSupplier.EmployeeCode = this.tEdit_EmployeeCode.Text.TrimEnd().PadLeft(4, '0');  // 依頼者
            }
            // 2009.02.04 30413 犬飼 未入力の場合は空文字を設定するように修正 <<<<<<END
            if (this.DeliveredGoodsDiv_tComboEditor.Value != null)
            {
                // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 >>>>>>START
                //uoeSupplier.DeliveredGoodsDiv = (int)this.DeliveredGoodsDiv_tComboEditor.Value;     // 納品区分
                uoeSupplier.UOEDeliGoodsDiv = (string)this.DeliveredGoodsDiv_tComboEditor.Value;     // UOE納品区分
                // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 <<<<<<END
            }
            if (this.BoCode_tComboEditor.Value != null)
            {
                uoeSupplier.BoCode = (string)this.BoCode_tComboEditor.Value;                        // ＢＯ区分
            }
            // 2008.11.05 30413 犬飼 削除 >>>>>>START
            //uoeSupplier.UOEResvdSection = this.UOEResvdSection_tEdit.Text;                      // 指定拠点
            //uoeSupplier.EmployeeCode = this.EmployeeCode_tEdit.Text;                            // 依頼者
            //uoeSupplier.DeliveredGoodsDiv = this.DeliveredGoodsDiv_tNedit.GetInt();             // 納品区分
            //uoeSupplier.BoCode = this.BoCode_tEdit.Text;                                        // ＢＯ区分
            uoeSupplier.UOEOrderRate = this.UOEOrderRate_tEdit.Text;                            // レート
            uoeSupplier.instrumentNo = this.instrumentNo_tEdit.Text;                            // 号機
            uoeSupplier.UOETestMode = this.UOETestMode_tEdit.Text;                              // テストモード
            uoeSupplier.UOEItemCd = this.UOEItemCd_tEdit.Text;                                  // アイテム
            uoeSupplier.HondaSectionCode = this.HondaSectionCode_tEdit.Text;                    // 担当拠点
            //uoeSupplier.AnswerSaveFolder = this.AnswerSaveFolder_tEdit.Text;                    // 回答保存フォルダ
            // 2008.11.05 30413 犬飼 削除 <<<<<<END
            uoeSupplier.MazdaSectionCode = this.MazdaSectionCode_tEdit.Text;                    // 自拠点
            if (this.EmergencyDiv_tComboEditor.Value == null)
            {
                uoeSupplier.EmergencyDiv = "";                                                  // 緊急区分
            }
            else
            {
                uoeSupplier.EmergencyDiv = (String)this.EmergencyDiv_tComboEditor.Value;        // 緊急区分
            }
            uoeSupplier.EnableOdrMakerCd1 = this.EnableOdrMakerCd1_tNedit.GetInt();             // 発注可能メーカーコード１
            uoeSupplier.EnableOdrMakerCd2 = this.EnableOdrMakerCd2_tNedit.GetInt();             // 発注可能メーカーコード２
            uoeSupplier.EnableOdrMakerCd3 = this.EnableOdrMakerCd3_tNedit.GetInt();             // 発注可能メーカーコード３
            uoeSupplier.EnableOdrMakerCd4 = this.EnableOdrMakerCd4_tNedit.GetInt();             // 発注可能メーカーコード４
            uoeSupplier.EnableOdrMakerCd5 = this.EnableOdrMakerCd5_tNedit.GetInt();             // 発注可能メーカーコード５
            uoeSupplier.EnableOdrMakerCd6 = this.EnableOdrMakerCd6_tNedit.GetInt();             // 発注可能メーカーコード６
            // ---ADD 2009/06/01 --------------------------------------------------->>>>>
            uoeSupplier.AnswerSaveFolder = this.AnswerSaveFolder_tEdit.Text;                    // 回答保存フォルダ
            // ---------------------------- ADD 2009/12/29 xuxh -------------------------------->>>>>
            if (uoeSupplier.CommAssemblyId == "0103" || uoeSupplier.CommAssemblyId == "103")
            {
                uoeSupplier.AnswerSaveFolder = this.AnswerSaveFolderOfTOYOTA_tEdit.Text;
                //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                if (this.MakerCd1_tComboEditor.Enabled)
                {
                    uoeSupplier.OdrPrtsNoHyphenCd1 = (int)this.MakerCd1_tComboEditor.Value;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 --------------------->>>>>>
                else
                {
                    // デフォールトはハイフン無しとセット
                    uoeSupplier.OdrPrtsNoHyphenCd1 = 0;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 ---------------------<<<<<<
                if (this.MakerCd2_tComboEditor.Enabled)
                {
                    uoeSupplier.OdrPrtsNoHyphenCd2 = (int)this.MakerCd2_tComboEditor.Value;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 --------------------->>>>>>
                else
                {
                    // デフォールトはハイフン無しとセット
                    uoeSupplier.OdrPrtsNoHyphenCd2 = 0;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 ---------------------<<<<<<
                if (this.MakerCd3_tComboEditor.Enabled)
                {
                    uoeSupplier.OdrPrtsNoHyphenCd3 = (int)this.MakerCd3_tComboEditor.Value;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 --------------------->>>>>>
                else
                {
                    // デフォールトはハイフン無しとセット
                    uoeSupplier.OdrPrtsNoHyphenCd3 = 0;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 ---------------------<<<<<<
                if (this.MakerCd4_tComboEditor.Enabled)
                {
                    uoeSupplier.OdrPrtsNoHyphenCd4 = (int)this.MakerCd4_tComboEditor.Value;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 --------------------->>>>>>
                else
                {
                    // デフォールトはハイフン無しとセット
                    uoeSupplier.OdrPrtsNoHyphenCd4 = 0;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 ---------------------<<<<<<
                if (this.MakerCd5_tComboEditor.Enabled)
                {
                    uoeSupplier.OdrPrtsNoHyphenCd5 = (int)this.MakerCd5_tComboEditor.Value;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 --------------------->>>>>>
                else
                {
                    // デフォールトはハイフン無しとセット
                    uoeSupplier.OdrPrtsNoHyphenCd5 = 0;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 ---------------------<<<<<<
                if (this.MakerCd6_tComboEditor.Enabled)
                {
                    uoeSupplier.OdrPrtsNoHyphenCd6 = (int)this.MakerCd6_tComboEditor.Value;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 --------------------->>>>>>
                else
                {
                    // デフォールトはハイフン無しとセット
                    uoeSupplier.OdrPrtsNoHyphenCd6 = 0;
                }
                // ADD 2011/12/15 yangmj for Redmine#27386 ---------------------<<<<<<
                //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
            }
            // ---------------------------- ADD 2009/12/29 xuxh --------------------------------<<<<<

            // --- ADD 2011/01/28 -------------------------------->>>>>
            if (uoeSupplier.CommAssemblyId == "0104" || uoeSupplier.CommAssemblyId == "104")
            {
                uoeSupplier.AnswerSaveFolder = this.AnswerSaveFolderOfTOYOTA_tEdit.Text;
            }
            // --- ADD 2011/01/28  --------------------------------<<<<<

            // ---ADD 2010/03/08 ---------------------------------------->>>>>
            if (uoeSupplier.CommAssemblyId == NISSAN_COMMASSEMBLY_ID || uoeSupplier.CommAssemblyId == "203")
            {
                uoeSupplier.AnswerSaveFolder = this.NissanAnswerSaveFolder_tEdit.Text;
            }

            // ---ADD 2010/12/31 ---------------------------------------->>>>>
            // ---ADD 2011/05/10 ---------------------------------------->>>>>
            if (uoeSupplier.CommAssemblyId == MAZDA_COMMASSEMBLY_ID || uoeSupplier.CommAssemblyId == "403")
            {
                uoeSupplier.AnswerSaveFolder = this.MazdaAnswerSaveFolder_tEdit.Text;
                uoeSupplier.HondaSectionCode = this.tEdit_HondaSectionCode.Text.PadRight(3, ' ');
            }

            // ---ADD 2011/05/10 ----------------------------------------<<<<<
            if (uoeSupplier.CommAssemblyId == AUTONISSAN_COMMASSEMBLY_ID || uoeSupplier.CommAssemblyId == "204")
            {
                uoeSupplier.AnswerSaveFolder = this.NissanAnswerSaveFolder_tEdit.Text;
            }

            if (uoeSupplier.CommAssemblyId == AUTOMITSUBISHI_COMMASSEMBLY_ID || uoeSupplier.CommAssemblyId == "303")
            {
                uoeSupplier.AnswerSaveFolder = this.MitsubishiAnswerSaveFolder_tEdit.Text;
            }
            // ---ADD 2010/12/31 ----------------------------------------<<<<<
            // ---ADD 2011/03/01 ---------------------------------------->>>>>
            if (uoeSupplier.CommAssemblyId == AUTONISSAN_COMMASSEMBLY_ID_0205 || uoeSupplier.CommAssemblyId == "205")
            {
                uoeSupplier.AnswerSaveFolder = this.NissanAnswerSaveFolder_tEdit.Text;
            }

            if (uoeSupplier.CommAssemblyId == AUTONISSAN_COMMASSEMBLY_ID_0206 || uoeSupplier.CommAssemblyId == "206")
            {
                uoeSupplier.AnswerSaveFolder = this.NissanAnswerSaveFolder_tEdit.Text;
                uoeSupplier.MazdaSectionCode = this.tEdit_MazdaSectionCode.Text.PadRight(3,' '); // ADD 2011/03/15
            }
            // ---ADD 2011/03/01 ----------------------------------------<<<<<
            // ---ADD 2010/03/08 ----------------------------------------<<<<<
			// ---ADD 2010/04/23 ---------------------------------------->>>>>
			if (uoeSupplier.CommAssemblyId == MITSUBISHI_COMMASSEMBLY_ID || uoeSupplier.CommAssemblyId == "302")
			{
				uoeSupplier.AnswerSaveFolder = this.MitsubishiAnswerSaveFolder_tEdit.Text;
			}
			// ---ADD 2010/04/23 ----------------------------------------<<<<<
            uoeSupplier.UOELoginUrl = this.UOELoginUrl_tEdit.Text;                              // ログイン用URL
            uoeSupplier.UOEOrderUrl = this.UOEOrderUrl_tEdit.Text;                              // 発注用URL
            uoeSupplier.UOEStockCheckUrl = this.UOEStockCheckUrl_tEdit.Text;                    // 在庫確認用URL
            uoeSupplier.UOEForcedTermUrl = this.UOEForcedTermUrl_tEdit.Text;                    // 強制終了用URL
            if (this.InqOrdDivCd_tComboEditor.Value == null)
            {
                uoeSupplier.InqOrdDivCd = 0;
            }
            else
            {
                uoeSupplier.InqOrdDivCd = (int)this.InqOrdDivCd_tComboEditor.Value;             // 接続種別
            }
            uoeSupplier.LoginTimeoutVal = this.LoginTimeoutVal_tNedit.GetInt();                 // ログイン認証時間
            uoeSupplier.EPartsUserId = this.EPartsUserId_tEdit.Text;                            // ユーザID
            uoeSupplier.EPartsPassWord = this.EPartsPassWord_tEdit.Text;                        // パスワード

            //プログラムをInt型に変換
            int commAssemblyId = 0;
            if (CommAssemblyId_tEdit.Text.Trim() != "")
            {
                commAssemblyId = int.Parse(CommAssemblyId_tEdit.Text.Trim());
            }

            if (commAssemblyId == 501)
            {
                uoeSupplier.UOEItemCd = this.UOEItemCd_tEdit.Text;                              // アイテム[ホンダ項目]
            }
            else if (commAssemblyId == 502)
            {
                uoeSupplier.UOEItemCd = this.UOEePartsItemCd_tEdit.Text;                        // アイテム[ホンダe-Parts項目]
            }
            else
            {
                uoeSupplier.UOEItemCd = "";
            }
            // ---ADD 2009/06/01 ---------------------------------------------------<<<<<

            // ---ADD 2010/05/14 ---------------------------------------->>>>>
            //明治UOEWeb項目
            if (commAssemblyId == 1004)
            {
                uoeSupplier.UOETestMode = this.MeiJiUoeSystemUseType_tEdit.Text;       // システム利用形態
                uoeSupplier.UOEItemCd = this.MeiJiUoeEigyousyoCode_tEdit.Text;        // 営業所コード
                uoeSupplier.UOELoginUrl = this.MeiJiUoeJigyousyoCode_tEdit.Text;    // 事業所コード
                uoeSupplier.UOEForcedTermUrl = this.MeiJiUoeCoCode_tEdit.Text;       // 会社コード
                uoeSupplier.EPartsUserId = this.MeiJiUoeTerminalID_tEdit.Text;        // 端末ID
                uoeSupplier.EPartsPassWord = this.MeiJiUoePassword_tEdit.Text;        // パスワード
                // 営業所フラグ
                int meiJiUoeEigyousyoFlag_tEdit = 0;
                int.TryParse(this.MeiJiUoeEigyousyoFlag_tEdit.Text.Trim(), out meiJiUoeEigyousyoFlag_tEdit);
                uoeSupplier.InqOrdDivCd = meiJiUoeEigyousyoFlag_tEdit;
            }
            // ---ADD 2010/05/14 ----------------------------------------<<<<<
            // ---ADD 2011/10/26 ------------------------------------------------------------>>>>>
            //卸NET-WEB項目
            if (commAssemblyId == 1003)
            {
                uoeSupplier.DaihatsuOrdreDiv = (int)this.Protocol_tComboEditor.Value;   // プロトコル
                uoeSupplier.InqOrdDivCd = (int)this.Connection_tComboEditor.Value;      // 接続区分
                uoeSupplier.UOEOrderUrl = this.Domain_tEdit.Text;                       // ドメイン
                if (this.OrderAddress_tEdit.Text != string.Empty && !this.OrderAddress_tEdit.Text.Substring(0, 1).Equals("/"))
                {
                    this.OrderAddress_tEdit.Text ="/" + this.OrderAddress_tEdit.Text;
                }
                if (this.RestoreAddress_tEdit.Text != string.Empty && !this.RestoreAddress_tEdit.Text.Substring(0, 1).Equals("/"))
                {
                    this.RestoreAddress_tEdit.Text = "/" + this.RestoreAddress_tEdit.Text;
                }
                if (this.PurchaseAddress_tEdit.Text != string.Empty && !this.PurchaseAddress_tEdit.Text.Substring(0, 1).Equals("/"))
                {
                    this.PurchaseAddress_tEdit.Text = "/" + this.PurchaseAddress_tEdit.Text;
                }
                uoeSupplier.UOEStockCheckUrl = this.OrderAddress_tEdit.Text;            // 発注用アドレス
                uoeSupplier.UOEForcedTermUrl = this.RestoreAddress_tEdit.Text;          // 復旧用アドレス
                uoeSupplier.UOELoginUrl = this.PurchaseAddress_tEdit.Text;              // 仕入受信用アドレス
                // タイムアウト 
                int timeOut_tEdit = 0;
                int.TryParse(this.TimeOut_tEdit.Text.Trim(), out timeOut_tEdit);
                uoeSupplier.LoginTimeoutVal = timeOut_tEdit;
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                // BL管理ユーザーコード
                if (uoeSupplier.InqOrdDivCd == 2)   //接続区分がCタイプの場合のみ
                {
                    uoeSupplier.BLMngUserCode = this.BLMngUserCode_tEdit.Text;
                }
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
            }
            // ---ADD 2011/10/26 ------------------------------------------------------------<<<<<
            // ---ADD 2010/07/27 ---------------------------------------->>>>>
            //トヨタUOEWeb項目
            if ("0103".Equals(uoeSupplier.CommAssemblyId.Trim()))
            {
                // 問合せ・発注種別
                uoeSupplier.InqOrdDivCd = (int)this.AnswerAutoDiv_tComboEditor.Value;
                // UOE発注URL
                uoeSupplier.UOEOrderUrl = this.WebPassword_tEdit.Text;
                // UOE在庫確認URL
                uoeSupplier.UOEStockCheckUrl = this.WebUserID_tEdit.Text;
                // UOE強制終了URL
                uoeSupplier.UOEForcedTermUrl = this.WebConnectCode_tEdit.Text;
            }
            // ---ADD 2010/07/27 ----------------------------------------<<<<<

             // ---ADD 2011/01/28 ---------------------------------------->>>>>
            if ("0104".Equals(uoeSupplier.CommAssemblyId.Trim()))
            {
                // 問合せ・発注種別
                uoeSupplier.InqOrdDivCd = (int)this.AnswerAutoDiv_tComboEditor.Value;
                // UOE発注URL
                uoeSupplier.UOEOrderUrl = this.WebPassword_tEdit.Text;
                // UOE在庫確認URL
                uoeSupplier.UOEStockCheckUrl = this.WebUserID_tEdit.Text;
                // UOE強制終了URL
                uoeSupplier.UOEForcedTermUrl = this.WebConnectCode_tEdit.Text;
            }
            // ---ADD 2011/01/28 ----------------------------------------<<<<<
            // ---ADD 2011/03/01 ---------------------------------------->>>>>
            if (uoeSupplier.CommAssemblyId == NISSAN_COMMASSEMBLY_ID)
            {
                // 問合せ・発注種別
                uoeSupplier.InqOrdDivCd = (int)this.Nissan_AnswerAutoDiv_tComboEditor.Value;
            }

            if (uoeSupplier.CommAssemblyId == AUTONISSAN_COMMASSEMBLY_ID)
            {
                // 問合せ・発注種別
                uoeSupplier.InqOrdDivCd = (int)this.Nissan_AnswerAutoDiv_tComboEditor.Value;
            }

            if (uoeSupplier.CommAssemblyId == AUTONISSAN_COMMASSEMBLY_ID_0205)
            {
                // 問合せ・発注種別
                uoeSupplier.InqOrdDivCd = (int)this.Nissan_AnswerAutoDiv_tComboEditor.Value;
            }

            if (uoeSupplier.CommAssemblyId == AUTONISSAN_COMMASSEMBLY_ID_0206)
            {
                // 問合せ・発注種別
                uoeSupplier.InqOrdDivCd = (int)this.Nissan_AnswerAutoDiv_tComboEditor.Value;
            }
            // ---ADD 2011/03/01 ----------------------------------------<<<<<
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <param name="loginID">ログインID</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>UpdateNote : 2010/05/14 呉元嘯 明治UOEWeb項目の対応</br>
        /// <br>UpdateNote : 2010/07/27 朱猛 トヨタUOEWeb項目の対応</br>
        /// <br>UpdateNote : 2011/10/26 葛中華 PM1113A 卸NET-WEB対応に伴う仕様追加</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
        {
            // 発注先コード
            if (this.UOESupplierCd_tNedit.Text == "0" || this.UOESupplierCd_tNedit.Text == "")
            {
                control = this.UOESupplierCd_tNedit;
                message = this.UOESupplierCd_Label.Text + "を入力して下さい。";
                return false;
            }

            // 発注先名称
            if (this.UOESupplierName_tEdit.Text.Trim() == "")
            {
                control = this.UOESupplierName_tEdit;
                message = "発注先名称を入力して下さい。";
                return false;
            }

            // メーカーコード
            if (this.tNedit_GoodsMakerCdAllowZero.Text == "")
            {
                control = this.tNedit_GoodsMakerCdAllowZero;
                message = this.GoodsMakerCd_Label.Text + "を入力して下さい。";
                return false;
            }

            // 仕入先コード
            if (this.tNedit_SupplierCd.GetInt() == 0)
            {
                control = this.tNedit_GoodsMakerCdAllowZero;
                message = this.SupplierCd_Label.Text + "を入力して下さい。";
                return false;
            }

            // 業務区分
            if (this.BusinessCode_tComboEditor.Value == null)
            {
                control = this.BusinessCode_tComboEditor;
                message = this.BusinessCode_Label.Text + "を選択して下さい。";
                return false;
            }

            // 回答自動取込区分
            if (this.AnswerAutoDiv_tComboEditor.Enabled == true)
            {
                if (this.AnswerAutoDiv_tComboEditor.Value == null)
                {
                    control = this.AnswerAutoDiv_tComboEditor;
                    message = this.AnswerAutoDiv_ultraLabel.Text + "を選択して下さい。";
                    return false;
                }
            }
            // ------------ADD 2011/03/15 ------------------------------>>>>>
            // WEBダミー品番
            if (this.tEdit_MazdaSectionCode.Enabled == true)
            {
                if (string.IsNullOrEmpty(this.tEdit_MazdaSectionCode.Text.Trim()))
                {
                    control = this.tEdit_MazdaSectionCode;
                    message = this.ultraLabel_MazdaSectionCode.Text + "を入力して下さい。";
                    return false;
                }
            }
            // ------------ADD 2011/03/15 ------------------------------<<<<<

            // ------------ADD 2011/05/10 ------------------------------>>>>>
            // WEBダミー品番
            if (this.tEdit_HondaSectionCode.Enabled == true)
            {
                if (string.IsNullOrEmpty(this.tEdit_HondaSectionCode.Text.Trim()))
                {
                    control = this.tEdit_HondaSectionCode;
                    message = this.ultraLabel_HondaSectionCode.Text + "を入力して下さい。";
                    return false;
                }
            }
            // ------------ADD 2011/05/10 ------------------------------<<<<<

            // ---DEL 2009/08/12 --------------------------------------->>>>>
            // // ---ADD 2009/06/01 --------------------------------------->>>>>
            // // 回答保存フォルダ
            // if (this.AnswerSaveFolder_tEdit.Enabled == true)
            // {
            //     if (System.IO.Directory.Exists(this.AnswerSaveFolder_tEdit.Text) == false)
            //     {
            //         control = this.AnswerSaveFolder_tEdit;
            //         message = "フォルダが存在しません。";
            //         return false;
            //     }
            // }
            // // ---ADD 2009/06/01 --------------------------------------->>>>>
            // ---DEL 2009/08/12 --------------------------------------->>>>>

            // ---------ADD 2010/05/14 --------->>>>>
            //明治UOEWeb項目
            if ("1004".Equals(this.CommAssemblyId_tEdit.Text))
            {
                // システム利用形態
                if (string.IsNullOrEmpty(MeiJiUoeSystemUseType_tEdit.Text))
                {
                    control = this.MeiJiUoeSystemUseType_tEdit;
                    message = this.MeiJiUoeSystemUseType_Label.Text + "を入力して下さい。";
                    return false;
                }

                // 営業所コード
                if (string.IsNullOrEmpty(MeiJiUoeEigyousyoCode_tEdit.Text))
                {
                    control = this.MeiJiUoeEigyousyoCode_tEdit;
                    message = this.MeiJiUoeEigyousyoCode_Label.Text + "を入力して下さい。";
                    return false;
                }
            }
            
            // ---------ADD 2010/05/14 ---------<<<<<
            // ---------ADD 2011/10/26 --------->>>>>
            //卸NET-WEB項目
            if ("1003".Equals(this.CommAssemblyId_tEdit.Text))
            {
                //プロトコル
                if (this.Protocol_tComboEditor.Value == null)
                {
                    control = this.Protocol_tComboEditor;
                    message = this.Protocol_uLabel.Text + "を選択して下さい。";
                    return false;
                }
                //接続区分
                if (this.Connection_tComboEditor.Value == null)
                {
                    control = this.Connection_tComboEditor;
                    message = this.Connection_uLabel.Text + "を選択して下さい。";
                    return false;
                }
                if (string.IsNullOrEmpty(this.Domain_tEdit.Text))
                {
                    control = this.Domain_tEdit;
                    message = this.Domain_uLabel.Text + "を入力して下さい。";
                    return false;
                }
                if (string.IsNullOrEmpty(this.OrderAddress_tEdit.Text))
                {
                    control = this.OrderAddress_tEdit;
                    message = this.OrderAddress_uLabel.Text + "を入力して下さい。";
                    return false;
                }
                if (string.IsNullOrEmpty(this.RestoreAddress_tEdit.Text))
                {
                    control = this.RestoreAddress_tEdit;
                    message = this.RestoreAddress_uLabel.Text + "を入力して下さい。";
                    return false;
                }
                if (string.IsNullOrEmpty(this.PurchaseAddress_tEdit.Text))
                {
                    control = this.PurchaseAddress_tEdit;
                    message = this.PurchaseAddress_uLabel.Text + "を入力して下さい。";
                    return false;
                }
                if (string.IsNullOrEmpty(this.TimeOut_tEdit.Text))
                {
                    control = this.TimeOut_tEdit;
                    message = this.TimeOut_uLabel.Text + "を入力して下さい。";
                    return false;
                }
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                // 接続区分がCタイプの場合のみBL管理ユーザーコード入力チェック
                if ((this.Connection_tComboEditor.SelectedIndex == 2) && (string.IsNullOrEmpty(this.BLMngUserCode_tEdit.Text)))
                {
                    control = this.BLMngUserCode_tEdit;
                    message = this.BLMngUserCode_uLabel.Text + "を入力してください。";
                    return false;
                }
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
            }
            // ---------ADD 2011/10/26 ---------<<<<<
            return true;
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="operation">オペレーション</param>
        /// <param name="erObject">エラーオブジェクト</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ExclusiveTransaction",				// 処理名称
                            operation,							// オペレーション
                            ERR_800_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            erObject,							// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ExclusiveTransaction",				// 処理名称
                            operation,							// オペレーション
                            ERR_801_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            erObject,							// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
            }
        }

        /// <summary>
        /// HashTable用キー作成
        /// </summary>
        /// <param name="UOESupplier">UOESupplierクラス</param>
        /// <returns>Hashテーブル用キー</returns>
        /// <remarks>
        /// <br>Note      : UOESupplierクラスからハッシュテーブル用のキーを作成します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>UPDATE Note: 2009/12/29 xuxh 回答保存フォルダ（トヨタ電子カタログ用発注送信データの格納場所）を追加する。</br>
        /// </remarks>
        private string CreateHashKey(UOESupplier uoeSupplier)
        {
            return uoeSupplier.UOESupplierCd.ToString("d9");
        }

        /// <summary>
        /// 入力項目の有効無効チェック
        /// </summary>
        /// <remarks>
        /// <br>Note       : プログラム項目の値で入力項目有効無効の設定を変更</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// <br>Update Note: 2010/01/19 譚洪 Redmine#2505の対応</br>
        /// <br>Update Note: 2010/03/08 楊明俊 日産Web-UOE連動項目の対応</br>
		/// <br>Update Note: 2010/04/23 jiangk 三菱Web-UOE連動項目の対応</br>
        /// <br>UpdateNote : 2010/05/14 呉元嘯 明治UOEWeb項目の対応</br> 
        /// <br>UpdateNote : 2010/07/27 朱 猛 トヨタUOEWeb項目の対応</br>
        /// <br>UpdateNote : 2011/01/28 施ヘイ中 回答自動取込区分（トヨタWEBUOE用自動連携用の設定区分）の変更</br>
        /// <br>UpdateNote : 2011/03/01 liyp 回答自動取込区分（日産WEBUOE用自動連携用の設定区分）の変更</br>
        /// <br>UpdateNote : 2011/03/15 liyp プログラム「0206」の追加仕様分の組み込み</br>
        /// <br>UpdateNote : 2011/05/10 施ヘイ中 マツダUOE-WEB対応に伴う仕様追加</br>
        /// <br>UpdateNote : 2011/10/26 葛中華 PM1113A 卸NET-WEB対応に伴う仕様追加</br>
        /// <br>UpdateNote : 2011/12/15 yangmj Redmine#27386トヨタUOEWebタクティー品番の発注対応</br>
        /// </remarks>
        private void InputEnableCheck()
        {
            int commAssemblyId = 0;

            if (CommAssemblyId_tEdit.Text.Trim() != "")
            {
                commAssemblyId = int.Parse(CommAssemblyId_tEdit.Text.Trim());
            }

            // チェック区分 有効／無効切り替え
            if ((commAssemblyId < 1001) || (1099 < commAssemblyId))
            {
                this.CheckCodeDiv_tComboEditor.Enabled = false;                 // チェック区分（無効）
            }
            else
            {
                this.CheckCodeDiv_tComboEditor.Enabled = true;                  // チェック区分（有効）
            }

            // ホンダ設定 有効／無効切り替え
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
            if ("0103".Equals(CommAssemblyId_tEdit.Text.Trim()))
            {
                this.MakerCd1_tComboEditor.Visible = true;
                this.MakerCd2_tComboEditor.Visible = true;
                this.MakerCd3_tComboEditor.Visible = true;
                this.MakerCd4_tComboEditor.Visible = true;
                this.MakerCd5_tComboEditor.Visible = true;
                this.MakerCd6_tComboEditor.Visible = true;
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd1_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd1_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd1_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd2_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd2_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd2_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd3_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd3_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd3_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd4_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd4_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd4_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd5_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd5_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd5_tComboEditor, false);
                }
                if (!string.IsNullOrEmpty(this.EnableOdrMakerCd6_tNedit.DataText))
                {
                    mekaKubenSet(this.MakerCd6_tComboEditor, true);
                }
                else
                {
                    mekaKubenSet(this.MakerCd6_tComboEditor, false);
                }
            }
            else
            {
                this.MakerCd1_tComboEditor.Visible = false;
                this.MakerCd2_tComboEditor.Visible = false;
                this.MakerCd3_tComboEditor.Visible = false;
                this.MakerCd4_tComboEditor.Visible = false;
                this.MakerCd5_tComboEditor.Visible = false;
                this.MakerCd6_tComboEditor.Visible = false;
                mekaKubenSet(this.MakerCd1_tComboEditor, false);
                mekaKubenSet(this.MakerCd2_tComboEditor, false);
                mekaKubenSet(this.MakerCd3_tComboEditor, false);
                mekaKubenSet(this.MakerCd4_tComboEditor, false);
                mekaKubenSet(this.MakerCd5_tComboEditor, false);
                mekaKubenSet(this.MakerCd6_tComboEditor, false);
            }
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
            //if ((commAssemblyId == 501) || (commAssemblyId == 502))       //DEL 2009/06/01
            if (commAssemblyId == 501)                                      //ADD 2009/06/01
            {
                this.instrumentNo_tEdit.Enabled = true;                         // 号機（有効）
                this.UOETestMode_tEdit.Enabled = true;                          // テストモード（有効）
                this.UOEItemCd_tEdit.Enabled = true;                            // アイテム（有効）
                this.HondaSectionCode_tEdit.Enabled = true;                     // 担当拠点（有効）
            }
            else
            {
                this.instrumentNo_tEdit.Enabled = false;                        // 号機（無効）
                this.instrumentNo_tEdit.Clear();
                this.UOETestMode_tEdit.Enabled = false;                         // テストモード（無効）
                this.UOETestMode_tEdit.Clear();
                this.UOEItemCd_tEdit.Enabled = false;                           // アイテム（無効）
                this.UOEItemCd_tEdit.Clear();
                this.HondaSectionCode_tEdit.Enabled = false;                    // 担当拠点（無効）
                this.HondaSectionCode_tEdit.Clear();
            }
            // ---ADD 2009/06/01 ----------------------------------------------->>>>>
            if (commAssemblyId == 502)
            {
                if (this.LoginTimeoutVal_tNedit.Enabled == false)
                {
                    this.LoginTimeoutVal_tNedit.SetValue(10);
                }

                this.AnswerSaveFolder_tEdit.Enabled = true;                     // 回答保存フォルダ
                this.uButton_AnswerSaveFolder.Enabled = true;                   // 回答保存フォルダボタン
                this.UOELoginUrl_tEdit.Enabled = true;                          // ログイン用URL
                this.UOEOrderUrl_tEdit.Enabled = true;                          // 発注用URL
                this.UOEStockCheckUrl_tEdit.Enabled = true;                     // 在庫確認用URL
                this.UOEForcedTermUrl_tEdit.Enabled = true;                     // 強制終了用URL
                this.InqOrdDivCd_tComboEditor.Enabled = true;                   // 接続種別
                this.LoginTimeoutVal_tNedit.Enabled = true;                     // ログイン認証時間
                this.UOEePartsItemCd_tEdit.Enabled = true;                      // アイテム[ホンダe-Parts項目]
                this.EPartsUserId_tEdit.Enabled = true;                         // ユーザID
                this.EPartsPassWord_tEdit.Enabled = true;                       // パスワード

                if (this.InqOrdDivCd_tComboEditor.Value == null)
                {
                    // コンボボックスの初期値設定
                    this.InqOrdDivCd_tComboEditor.Value = 0;
                }
            }
            else
            {
                this.AnswerSaveFolder_tEdit.Enabled = false;                    // 回答保存フォルダ
                this.AnswerSaveFolder_tEdit.Clear();
                this.uButton_AnswerSaveFolder.Enabled = false;                  // 回答保存フォルダボタン
                this.UOELoginUrl_tEdit.Enabled = false;                         // ログイン用URL
                this.UOELoginUrl_tEdit.Clear();
                this.UOEOrderUrl_tEdit.Enabled = false;                         // 発注用URL
                this.UOEOrderUrl_tEdit.Clear();
                this.UOEStockCheckUrl_tEdit.Enabled = false;                    // 在庫確認用URL
                this.UOEStockCheckUrl_tEdit.Clear();
                this.UOEForcedTermUrl_tEdit.Enabled = false;                    // 強制終了用URL
                this.UOEForcedTermUrl_tEdit.Clear();
                this.InqOrdDivCd_tComboEditor.Enabled = false;                  // 接続種別
                this.InqOrdDivCd_tComboEditor.Value = null;
                this.LoginTimeoutVal_tNedit.Enabled = false;                    // ログイン認証時間
                this.LoginTimeoutVal_tNedit.Clear();
                this.UOEePartsItemCd_tEdit.Enabled = false;                     // アイテム[ホンダe-Parts項目]
                this.UOEePartsItemCd_tEdit.Clear();
                this.EPartsUserId_tEdit.Enabled = false;                        // ユーザID
                this.EPartsUserId_tEdit.Clear();
                this.EPartsPassWord_tEdit.Enabled = false;                      // パスワード
                this.EPartsPassWord_tEdit.Clear();
            }
            // ---ADD 2009/06/01 -----------------------------------------------<<<<<

            // ---ADD 2010/05/14 ---------------------------------------->>>>>
            //明治UOEWeb項目
            if (commAssemblyId == 1004)
            {
                if (this.MeiJiUoeEigyousyoFlag_tEdit.Enabled == false)
                {
                    this.MeiJiUoeEigyousyoFlag_tEdit.Text = "0";
                }
                this.MeiJiUoeSystemUseType_tEdit.Enabled = true;       // システム利用形態
                this.MeiJiUoeEigyousyoCode_tEdit.Enabled = true;        // 営業所コード
                this.MeiJiUoeEigyousyoFlag_tEdit.Enabled = true;       // 営業所フラグ
                this.MeiJiUoeJigyousyoCode_tEdit.Enabled = true;    // 事業所コード
                this.MeiJiUoeCoCode_tEdit.Enabled = true;       // 会社コード
                this.MeiJiUoeTerminalID_tEdit.Enabled = true;        // 端末ID
                this.MeiJiUoePassword_tEdit.Enabled = true;        // パスワード
            }
            else
            {
                this.MeiJiUoeSystemUseType_tEdit.Enabled = false;       // システム利用形態
                this.MeiJiUoeSystemUseType_tEdit.Clear();
                this.MeiJiUoeEigyousyoCode_tEdit.Enabled = false;        // 営業所コード
                this.MeiJiUoeEigyousyoCode_tEdit.Clear();
                this.MeiJiUoeEigyousyoFlag_tEdit.Enabled = false;       // 営業所フラグ
                this.MeiJiUoeEigyousyoFlag_tEdit.Clear();
                this.MeiJiUoeJigyousyoCode_tEdit.Enabled = false;    // 事業所コード
                this.MeiJiUoeJigyousyoCode_tEdit.Clear();
                this.MeiJiUoeCoCode_tEdit.Enabled = false;       // 会社コード
                this.MeiJiUoeCoCode_tEdit.Clear();
                this.MeiJiUoeTerminalID_tEdit.Enabled = false;        // 端末ID
                this.MeiJiUoeTerminalID_tEdit.Clear();
                this.MeiJiUoePassword_tEdit.Enabled = false;        // パスワード
                this.MeiJiUoePassword_tEdit.Clear();
            }
            // ---ADD 2010/05/14 ----------------------------------------<<<<<
            // ---ADD 2011/10/26 ---------------------------------------->>>>>
            //卸NET-WEB項目
            if (commAssemblyId == 1003)
            {
                this.Protocol_tComboEditor.Enabled = true;          // プロトコル
                this.Connection_tComboEditor.Enabled = true;        // 接続区分
                this.CarMaker_uButton.Enabled = true;               // 外車対応メーカー
                this.Domain_tEdit.Enabled = true;                   // ドメイン
                this.OrderAddress_tEdit.Enabled = true;             // 発注用アドレス
                this.RestoreAddress_tEdit.Enabled = true;           // 復旧用アドレス
                this.PurchaseAddress_tEdit.Enabled = true;          // 仕入受信用アドレス
                this.TimeOut_tEdit.Enabled = true;                  // タイムアウト
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                this.BLMngUserCode_tEdit.Enabled = true;           // BL管理ユーザーコード
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
            }
            else
            {
                this.Protocol_tComboEditor.Enabled = false;         // プロトコル
                this.Connection_tComboEditor.Enabled = false;       // 接続区分
                this.CarMaker_uButton.Enabled = false;              // 外車対応メーカー
                this.Domain_tEdit.Enabled = false;                  // ドメイン
                this.Domain_tEdit.Clear();
                this.OrderAddress_tEdit.Enabled = false;            // 発注用アドレス
                this.OrderAddress_tEdit.Clear();
                this.RestoreAddress_tEdit.Enabled = false;          // 復旧用アドレス
                this.RestoreAddress_tEdit.Clear();
                this.PurchaseAddress_tEdit.Enabled = false;         // 仕入受信用アドレス
                this.PurchaseAddress_tEdit.Clear();
                this.TimeOut_tEdit.Enabled = false;                 // タイムアウト
                this.TimeOut_tEdit.Clear();
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                this.BLMngUserCode_tEdit.Enabled = false;          // BL管理ユーザーコード
                this.BLMngUserCode_tEdit.Clear();
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
            }
            // ---ADD 2011/10/26 ----------------------------------------<<<<<


            // 2008.11.05 30413 犬飼 削除 >>>>>>START
            //// ホンダe-Parts設定 有効／無効切り替え
            //if (commAssemblyId == 502)
            //{
            //    this.AnswerSaveFolder_tEdit.Enabled = true;                     // 回答保存フォルダ（有効）
            //}
            //else
            //{
            //    this.AnswerSaveFolder_tEdit.Enabled = false;                    // 回答保存フォルダ（無効）
            //    this.AnswerSaveFolder_tEdit.Clear();
            //}
            // 2008.11.05 30413 犬飼 削除 <<<<<<END
                
            // 新マツダ設定 有効／無効切り替え
            // ---UPD 2011/05/10 ------------------------------------------->>>>>
            //if (commAssemblyId == 402)
            if (commAssemblyId == 402 || commAssemblyId == 403)
            // ---UPD 2011/05/10 -------------------------------------------<<<<<
            {
                this.MazdaSectionCode_tEdit.Enabled = true;                     // 自拠点（有効）
            }
            else
            {
                this.MazdaSectionCode_tEdit.Enabled = false;                    // 自拠点（無効）
                this.MazdaSectionCode_tEdit.Clear();
            }

            // 三菱設定 有効／無効切り替え
            if (commAssemblyId == 301)
            {
                this.EmergencyDiv_tComboEditor.Enabled = true;                  // 緊急区分（有効）
                if (this.EmergencyDiv_tComboEditor.Value == null)
                {
                    // コンボボックスの初期値設定
                    this.EmergencyDiv_tComboEditor.Value = "E";
                }
            }
            else
            {
                this.EmergencyDiv_tComboEditor.Enabled = false;                 // 緊急区分（無効）
                this.EmergencyDiv_tComboEditor.Value = null;
            }

            // 発注可能メーカー 有効／無効切り替え
            if ((commAssemblyId < 1001) || (1099 < commAssemblyId))
            {
                this.uButton_EnableOdrMaker1Guide.Enabled = true;               // 発注可能メーカーガイド１（有効）
                this.uButton_EnableOdrMaker2Guide.Enabled = true;               // 発注可能メーカーガイド２（有効）
                this.uButton_EnableOdrMaker3Guide.Enabled = true;               // 発注可能メーカーガイド３（有効）
                this.uButton_EnableOdrMaker4Guide.Enabled = true;               // 発注可能メーカーガイド４（有効）
                this.uButton_EnableOdrMaker5Guide.Enabled = true;               // 発注可能メーカーガイド５（有効）
                this.uButton_EnableOdrMaker6Guide.Enabled = true;               // 発注可能メーカーガイド６（有効）
                this.EnableOdrMakerCd1_tNedit.Enabled = true;                   // 発注可能メーカーコード１（有効）
                this.EnableOdrMakerCd2_tNedit.Enabled = true;                   // 発注可能メーカーコード２（有効）
                this.EnableOdrMakerCd3_tNedit.Enabled = true;                   // 発注可能メーカーコード３（有効）
                this.EnableOdrMakerCd4_tNedit.Enabled = true;                   // 発注可能メーカーコード４（有効）
                this.EnableOdrMakerCd5_tNedit.Enabled = true;                   // 発注可能メーカーコード５（有効）
                this.EnableOdrMakerCd6_tNedit.Enabled = true;                   // 発注可能メーカーコード６（有効）
            }
            else
            {
                this.uButton_EnableOdrMaker1Guide.Enabled = false;              // 発注可能メーカーガイド１（無効）
                this.uButton_EnableOdrMaker2Guide.Enabled = false;              // 発注可能メーカーガイド２（無効）
                this.uButton_EnableOdrMaker3Guide.Enabled = false;              // 発注可能メーカーガイド３（無効）
                this.uButton_EnableOdrMaker4Guide.Enabled = false;              // 発注可能メーカーガイド４（無効）
                this.uButton_EnableOdrMaker5Guide.Enabled = false;              // 発注可能メーカーガイド５（無効）
                this.uButton_EnableOdrMaker6Guide.Enabled = false;              // 発注可能メーカーガイド６（無効）
                this.EnableOdrMakerCd1_tNedit.Enabled = false;                  // 発注可能メーカーコード１（無効）
                this.EnableOdrMakerCd2_tNedit.Enabled = false;                  // 発注可能メーカーコード２（無効）
                this.EnableOdrMakerCd3_tNedit.Enabled = false;                  // 発注可能メーカーコード３（無効）
                this.EnableOdrMakerCd4_tNedit.Enabled = false;                  // 発注可能メーカーコード４（無効）
                this.EnableOdrMakerCd5_tNedit.Enabled = false;                  // 発注可能メーカーコード５（無効）
                this.EnableOdrMakerCd6_tNedit.Enabled = false;                  // 発注可能メーカーコード６（無効）
            }
            // ---------------------------- ADD 2009/12/29 xuxh -------------------------------->>>>>
            //if (commAssemblyId == 0103)                                // DEL 2010/01/19
            // --- UPD 2011/01/28-------------------------------->>>>>
            //if ("0103".Equals(CommAssemblyId_tEdit.Text.Trim()))         // ADD 2010/01/19
              if ("0103".Equals(CommAssemblyId_tEdit.Text.Trim()) || "0104".Equals(CommAssemblyId_tEdit.Text.Trim()))
            // --- UPD 2011/01/28---------------------------<<<<<
              {
                AnswerSaveFolderOfTOYOTA_tEdit.Enabled = true;
                uButton_AnswerSaveFolderOfTOYOTA.Enabled = true;
            // --- UPD 2011/01/28-------------------------------->>>>>
                if ("0103".Equals(CommAssemblyId_tEdit.Text.Trim()))
                {
                    // 回答自動取込区分
                    this.AnswerAutoDiv_tComboEditor.Enabled = true;
                    if (this.AnswerAutoDiv_tComboEditor.Value == null)
                    {
                        this.AnswerAutoDiv_tComboEditor.Value = 0;
                    }
                }
                else
                {
                    // 回答自動取込区分
                    this.AnswerAutoDiv_tComboEditor.Enabled = false;
                    //if (this.AnswerAutoDiv_tComboEditor.Value == null) // DEL 2011/01/28
                    //{ // DEL 2011/01/28
                        this.AnswerAutoDiv_tComboEditor.Value = 1;
                    //} // DEL 2011/01/28

                  }
                // --- UPD 2011/01/28-------------------------------->>>>>
                //uButton_AnswerSaveFolderOfTOYOTA.Enabled = true;
                //// ---ADD 2010/07/27 ---------------------------------------->>>>>
                //// 回答自動取込区分
                //this.AnswerAutoDiv_tComboEditor.Enabled = true;
                //if (this.AnswerAutoDiv_tComboEditor.Value == null)
                //{
                //    this.AnswerAutoDiv_tComboEditor.Value = 0;
                //}
                // --- UPD 2011/01/28--------------------------------<<<<
                // WEBパスワード
                this.WebPassword_tEdit.Enabled = true;
                // WEBユーザーID
                this.WebUserID_tEdit.Enabled = true;
                // WEB接続先コード
                this.WebConnectCode_tEdit.Enabled = true;
                // ---ADD 2010/07/27 ----------------------------------------<<<<<
            }
            else
            {
                AnswerSaveFolderOfTOYOTA_tEdit.Enabled = false;
                uButton_AnswerSaveFolderOfTOYOTA.Enabled = false;
                AnswerSaveFolderOfTOYOTA_tEdit.Text = "";
                // ---ADD 2010/07/27 ---------------------------------------->>>>>
                // 回答自動取込区分
                this.AnswerAutoDiv_tComboEditor.Enabled = false;
                this.AnswerAutoDiv_tComboEditor.Text = "";
                // WEBパスワード
                this.WebPassword_tEdit.Enabled = false;
                this.WebPassword_tEdit.Text = "";
                // WEBユーザーID
                this.WebUserID_tEdit.Enabled = false;
                this.WebUserID_tEdit.Text = "";
                // WEB接続先コード
                this.WebConnectCode_tEdit.Enabled = false;
                this.WebConnectCode_tEdit.Text = "";
                // ---ADD 2010/07/27 ----------------------------------------<<<<<
            }
            // ---------------------------- ADD 2009/12/29 xuxh --------------------------------<<<<
            // ---ADD 2010/03/08 ---------------------------------------->>>>>
            if (NISSAN_COMMASSEMBLY_ID.Equals(CommAssemblyId_tEdit.Text.Trim())
                || AUTONISSAN_COMMASSEMBLY_ID.Equals(CommAssemblyId_tEdit.Text.Trim()))   // ADD 2010/12/31
            {
                NissanAnswerSaveFolder_tEdit.Enabled = true;
                uButton_NissanAnswerSaveFolder.Enabled = true;
                // ---ADD 2011/03/01 ---------------------------------------->>>>>
                this.Nissan_AnswerAutoDiv_tComboEditor.Enabled = false;
                if(NISSAN_COMMASSEMBLY_ID.Equals(CommAssemblyId_tEdit.Text.Trim()))
                {
                     this.Nissan_AnswerAutoDiv_tComboEditor.Value = 0;
                }
                if (AUTONISSAN_COMMASSEMBLY_ID.Equals(CommAssemblyId_tEdit.Text.Trim()))
                {
                    this.Nissan_AnswerAutoDiv_tComboEditor.Value = 1;
                }
                // ---ADD 2011/03/01 ----------------------------------------<<<<<
                this.tEdit_MazdaSectionCode.Enabled = false; //ADD 2011/03/15
                this.tEdit_MazdaSectionCode.Text = ""; //ADD 2011/03/15
            }
            // ---ADD 2011/03/01 ---------------------------------------->>>>>
            else if (AUTONISSAN_COMMASSEMBLY_ID_0205.Equals(CommAssemblyId_tEdit.Text.Trim()))
            {
                NissanAnswerSaveFolder_tEdit.Enabled = true;
                uButton_NissanAnswerSaveFolder.Enabled = true;
                // 回答自動取込区分
                this.Nissan_AnswerAutoDiv_tComboEditor.Enabled = true;
                if (this.Nissan_AnswerAutoDiv_tComboEditor.Value == null)
                {
                    this.Nissan_AnswerAutoDiv_tComboEditor.Value = 0;
                }
                this.tEdit_MazdaSectionCode.Enabled = false; //ADD 2011/03/15
                this.tEdit_MazdaSectionCode.Text = ""; //ADD 2011/03/15
            }
            else if (AUTONISSAN_COMMASSEMBLY_ID_0206.Equals(CommAssemblyId_tEdit.Text.Trim()))
            {
                NissanAnswerSaveFolder_tEdit.Enabled = true;
                uButton_NissanAnswerSaveFolder.Enabled = true;
                // 回答自動取込区分
                this.Nissan_AnswerAutoDiv_tComboEditor.Enabled = false;
                this.Nissan_AnswerAutoDiv_tComboEditor.Value = 1;
                this.tEdit_MazdaSectionCode.Enabled = true; //ADD 2011/03/15
            }
            // ---ADD 2011/03/01 ----------------------------------------<<<<<
            else
            {
                NissanAnswerSaveFolder_tEdit.Enabled = false;
                uButton_NissanAnswerSaveFolder.Enabled = false;
                NissanAnswerSaveFolder_tEdit.Text = "";
                this.Nissan_AnswerAutoDiv_tComboEditor.Enabled = false;// ADD 2011/03/01
                this.Nissan_AnswerAutoDiv_tComboEditor.Value = null;// ADD 2011/03/01
                this.tEdit_MazdaSectionCode.Enabled = false; //ADD 2011/03/15
                this.tEdit_MazdaSectionCode.Text = ""; //ADD 2011/03/15
            }
            // ---ADD 2010/03/08 ----------------------------------------<<<<<
			// ---ADD 2010/04/23 ---------------------------------------->>>>>
			if (MITSUBISHI_COMMASSEMBLY_ID.Equals(CommAssemblyId_tEdit.Text.Trim())
                || AUTOMITSUBISHI_COMMASSEMBLY_ID.Equals(CommAssemblyId_tEdit.Text.Trim())) // ADD 2010/12/31
			{
				MitsubishiAnswerSaveFolder_tEdit.Enabled = true;
				uButton_MitsubishiAnswerSaveFolder.Enabled = true;
			}
			else
			{
				MitsubishiAnswerSaveFolder_tEdit.Enabled = false;
				uButton_MitsubishiAnswerSaveFolder.Enabled = false;
				MitsubishiAnswerSaveFolder_tEdit.Text = "";
			}

			// ---ADD 2011/05/10 ----------------------------------------<<<<<
            if (MAZDA_COMMASSEMBLY_ID.Equals(CommAssemblyId_tEdit.Text.Trim())) // ADD 2010/12/31
            {
                MazdaAnswerSaveFolder_tEdit.Enabled = true;
                uButton_MazdaAnswerSaveFolder.Enabled = true;
                this.tEdit_HondaSectionCode.Enabled = true;
            }
            else
            {
                MazdaAnswerSaveFolder_tEdit.Enabled = false;
                uButton_MazdaAnswerSaveFolder.Enabled = false;
                MazdaAnswerSaveFolder_tEdit.Text = "";
                tEdit_HondaSectionCode.Text = "";
                this.tEdit_HondaSectionCode.Enabled = false;
            }
            // ---ADD 2011/05/10 ----------------------------------------<<<<<

        }

        /// <summary>
        /// UOE発注先ガイド起動処理
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先マスタオブジェクト</param>
        /// <returns>結果(0:OK, 1:Cancel)</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先ガイドの起動を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private int ShowUOESupplierGuide(out UOESupplier uoeSupplier)
        {
            uoeSupplier = new UOESupplier();

            return this._uoeSupplierAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode,LoginInfoAcquisition.Employee.BelongSectionCode, out uoeSupplier);
        }

        /// <summary>
        /// メーカーガイド起動処理
        /// </summary>
        /// <param name="makerUMnt">メーカーマスタオブジェクト</param>
        /// <returns>結果(0:OK, 1:Cancel)</returns>
        /// <remarks>
        /// <br>Note       : メーカーガイドの起動を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private int ShowMakerUMntGuide(out MakerUMnt makerUMnt)
        {
            MakerAcs makerAcs = new MakerAcs();

            makerUMnt = new MakerUMnt();

            return makerAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, out makerUMnt);
        }

        /// <summary>
        /// 仕入先ガイド起動処理
        /// </summary>
        /// <param name="SupplierAcs">仕入先マスタオブジェクト</param>
        /// <returns>結果(0:OK, 1:Cancel)</returns>
        /// <remarks>
        /// <br>Note       : 仕入先ガイド起動を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private int ShowSupplierGuide(out Supplier supplier)
        {
            SupplierAcs supplierAcs = new SupplierAcs();

            supplier = new Supplier();

            return supplierAcs.ExecuteGuid(out supplier, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
        }

        /// <summary>
        /// UOEガイド名称ガイド起動処理
        /// </summary>
        /// <param name="uoeGuideName">UOEガイド名称マスタオブジェクト</param>
        /// <returns>結果(0:OK, 1:Cancel)</returns>
        /// <remarks>
        /// <br>Note       : UOEガイド名称ガイドの起動を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private int ShowUOEGuideNameGuide(out UOEGuideName uoeGuideName)
        {
            UOEGuideName inUOEGuideName = new UOEGuideName();
            UOEGuideNameAcs uoeGuideNameAcs = new UOEGuideNameAcs();

            uoeGuideName = new UOEGuideName();

            inUOEGuideName.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ガイド区分は拠点区分
            inUOEGuideName.UOEGuideDivCd = 3;
            // 画面から発注先コードを取得
            inUOEGuideName.UOESupplierCd = this.UOESupplierCd_tNedit.GetInt();
            // 拠点コード
            inUOEGuideName.SectionCode = this._sectionCode;

            if (inUOEGuideName.UOESupplierCd != 0)
            {
                return uoeGuideNameAcs.ExecuteGuid(inUOEGuideName, out uoeGuideName);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/06/30</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            int status;
            //ArrayList makerUMntRetArray;
            //MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt;

            try
            {
                // 2008.11.06 30413 犬飼 メーカーマスタの取得をReadに変更 >>>>>>START
                //status = makerAcs.SearchAll(out makerUMntRetArray, this._enterpriseCode);
                //if (status == 0)
                //{
                    //if (makerUMntRetArray.Count <= 0)
                    //{
                    //    return makerName;
                    //}

                    //foreach (MakerUMnt makerUMnt in makerUMntRetArray)
                    //{
                    //    if (makerUMnt.GoodsMakerCd == makerCode)
                    //    {
                    //        makerName = makerUMnt.MakerName.Trim();
                    //        return makerName;
                    //    }
                    //}
                //}
                status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, makerCode);
                if ((status == 0) && (makerUMnt.LogicalDeleteCode == 0))
                {
                    makerName = makerUMnt.MakerName.Trim();
                }
                // 2008.11.06 30413 犬飼 メーカーマスタの取得をReadに変更 <<<<<<END                    
            }
            catch
            {
                makerName = "";
            }

            return makerName;
        }

        /// <summary>
        /// UOEガイド名称取得処理
        /// </summary>
        /// <param name="uoeSupplierCd">UOE発注先コード</param>
        /// <param name="uoeGuideCode">ガイドコード</param>
        /// <returns>UOEガイド名称</returns>
        /// <remarks>
        /// <br>Note       : UOEガイド名称を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/06/30</br>
        /// </remarks>
        private string GetUOEGuideName(int uoeSupplierCd, string uoeGuideCode)
        {
            string uoeGuideNm = "";

            int status;
            //ArrayList uoeGuideNameArray;
            //UOEGuideName uoeGuideName = new UOEGuideName();
            UOEGuideName uoeGuideName;
            //UOEGuideNameAcs uoeGuideNameAcs = new UOEGuideNameAcs();

            try
            {
                // 2008.11.06 30413 犬飼 UOEガイドマスタの取得をReadに変更 >>>>>>START
                //uoeGuideName.EnterpriseCode = this._enterpriseCode;
                //uoeGuideName.SectionCode = this._sectionCode;
                //uoeGuideName.UOEGuideDivCd = 3;
                //uoeGuideName.UOEGuideCode = uoeGuideCode;
                
                //status = uoeGuideNameAcs.SearchAll(out uoeGuideNameArray, uoeGuideName);
                //if (status == 0)
                //{
                //    if (uoeGuideNameArray.Count <= 0)
                //    {
                //        return uoeGuideNm;
                //    }

                //    foreach (UOEGuideName wkUOEGuideName in uoeGuideNameArray)
                //    {
                //        if (wkUOEGuideName.UOEGuideCode.Equals(uoeGuideCode))
                //        {
                //            uoeGuideNm = wkUOEGuideName.UOEGuideNm.Trim();
                //            return uoeGuideNm;
                //        }
                //    }
                //}

                status = this._uoeGuideNameAcs.Read(out uoeGuideName, this._enterpriseCode, 3, uoeSupplierCd, uoeGuideCode, this._sectionCode);
                if ((status == 0) && (uoeGuideName.LogicalDeleteCode == 0))
                {
                    uoeGuideNm = uoeGuideName.UOEGuideNm.Trim();
                }
                // 2008.11.06 30413 犬飼 UOEガイドマスタの取得をReadに変更 <<<<<<END
            }
            catch
            {
                uoeGuideNm = "";
            }

            return uoeGuideNm;
        }

        /// <summary>
        /// 仕入先名称取得処理
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <returns>仕入先名称</returns>
        /// <remarks>
        /// <br>Note       : 仕入先名称を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private string GetSupplierName(int supplierCd)
        {
            string supplierName = "";

            int status;
            //SupplierAcs supplierInfoAcs = new SupplierAcs();
            Supplier supplier;

            try
            {
                status = this._supplierInfoAcs.Read(out supplier, this._enterpriseCode, supplierCd);
                if ((status == 0) && (supplier.LogicalDeleteCode == 0))
                {
                    supplierName = supplier.SupplierSnm.Trim();
                }
            }
            catch
            {
                supplierName = "";
            }

            return supplierName;
        }

        /// <summary>
        /// 依頼者名称取得処理
        /// </summary>
        /// <param name="employeeCode">依頼者コード</param>
        /// <returns>依頼者名称</returns>
        /// <remarks>
        /// <br>Note       : 依頼者名称を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private string GetEmployeeName(string employeeCode)
        {
            string employeeName = "";

            int status;
            Employee employee;

            try
            {
                status = this._employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);
                if ((status == 0) && (employee.LogicalDeleteCode == 0))
                {
                    employeeName = employee.Name.Trim();
                }
            }
            catch
            {
                employeeName = "";
            }

            return employeeName;
        }

        /// <summary>
        /// 指定拠点コンボボックス設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 指定拠点コンボボックスを設定します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void InitialSettingUOEResvdSection()
        {
            int status = -1;
            ArrayList retList;
            UOEGuideName uoeGuideName = new UOEGuideName();
            
            // 指定拠点のアイテムクリア
            this.UOEResvdSection_tComboEditor.Items.Clear();

            if (this.UOESupplierCd_tNedit.GetInt() == 0)
            {
                // 発注先コードが未入力
                return;
            }

            uoeGuideName.EnterpriseCode = this._enterpriseCode;
            uoeGuideName.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            uoeGuideName.UOEGuideDivCd = 3; // 指定拠点
            uoeGuideName.UOESupplierCd = this.UOESupplierCd_tNedit.GetInt();
            
            status = this._uoeSupplierAcs.GetUOEGuideData(out retList, uoeGuideName);
            if (status == 0)
            {
                foreach (UOEGuideName wkUOEGuideName in retList)
                {
                    this.UOEResvdSection_tComboEditor.Items.Add(wkUOEGuideName.UOEGuideCode, wkUOEGuideName.UOEGuideNm);
                }
                this.UOEResvdSection_tComboEditor.MaxDropDownItems = this.UOEResvdSection_tComboEditor.Items.Count;
            }
        }

        /// <summary>
        /// 納品区分コンボボックス設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 納品区分コンボボックスを設定します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void InitialSettingDeliveredGoodsDiv()
        {
            int status = -1;
            ArrayList retList;
            UOEGuideName uoeGuideName = new UOEGuideName();

            // 納品区分のアイテムクリア
            this.DeliveredGoodsDiv_tComboEditor.Items.Clear();

            if (this.UOESupplierCd_tNedit.GetInt() == 0)
            {
                // 発注先コードが未入力
                return;
            }

            uoeGuideName.EnterpriseCode = this._enterpriseCode;
            uoeGuideName.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            uoeGuideName.UOEGuideDivCd = 2; // 納品区分
            uoeGuideName.UOESupplierCd = this.UOESupplierCd_tNedit.GetInt();

            status = this._uoeSupplierAcs.GetUOEGuideData(out retList, uoeGuideName);
            if (status == 0)
            {
                foreach (UOEGuideName wkUOEGuideName in retList)
                {
                    this.DeliveredGoodsDiv_tComboEditor.Items.Add(wkUOEGuideName.UOEGuideCode, wkUOEGuideName.UOEGuideNm);
                }
                this.DeliveredGoodsDiv_tComboEditor.MaxDropDownItems = this.DeliveredGoodsDiv_tComboEditor.Items.Count;
            }
        }

        /// <summary>
        /// ＢＯ区分コンボボックス設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ＢＯ区分コンボボックスを設定します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void InitialSettingBoCode()
        {
            int status = -1;
            ArrayList retList;
            UOEGuideName uoeGuideName = new UOEGuideName();

            // ＢＯ区分のアイテムクリア
            this.BoCode_tComboEditor.Items.Clear();

            if (this.UOESupplierCd_tNedit.GetInt() == 0)
            {
                // 発注先コードが未入力
                return;
            }

            uoeGuideName.EnterpriseCode = this._enterpriseCode;
            uoeGuideName.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            uoeGuideName.UOEGuideDivCd = 1; // ＢＯ区分
            uoeGuideName.UOESupplierCd = this.UOESupplierCd_tNedit.GetInt();

            status = this._uoeSupplierAcs.GetUOEGuideData(out retList, uoeGuideName);
            if (status == 0)
            {
                foreach (UOEGuideName wkUOEGuideName in retList)
                {
                    this.BoCode_tComboEditor.Items.Add(wkUOEGuideName.UOEGuideCode, wkUOEGuideName.UOEGuideNm);
                }
                this.BoCode_tComboEditor.MaxDropDownItems = this.BoCode_tComboEditor.Items.Count;
            }
        }

        # endregion

        #region ■Control Events
        /// <summary>
        /// Form.Load イベント(PMUOE09020UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void PMUOE09020UA_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

            // 画面初期設定処理
            ScreenInitialSetting();
        }

        /// <summary>
        /// Form.Closing イベント(PMUOE09020UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void PMUOE09020UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;

            // フォームの「×」をクリックされた場合の対応です。
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Control.VisibleChanged イベント(PMUOE09020UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void PMUOE09020UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // 自分自身が非表示になった場合、
            // またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            Initial_Timer.Enabled = true;
            ScreenClear();
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            if (SaveProc() == false)
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// UOE発注先マスタ 情報登録処理
        /// </summary>
        /// <returns>登録結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタ 情報登録を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private bool SaveProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            Control control = null;
            string message = null;
            string loginID = "";
            
            UOESupplier uoeSupplier = null;

            if (this.DataIndex >= 0)
            {
                string guid = (string)this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[this._dataIndex][GUID_TITLE];
                uoeSupplier = ((UOESupplier)this._uoeSupplierTable[guid]).Clone();
            }

            if (!ScreenDataCheck(ref control, ref message, loginID))
            {
                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                control.Focus();
                return false;
            }

            this.DispToUOESupplier(ref uoeSupplier);

            status = this._uoeSupplierAcs.Write(ref uoeSupplier);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            ERR_DPR_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン

                        this.UOESupplierCd_tNedit.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._uoeSupplierAcs);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return false;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "SaveProc",							// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            ERR_UPDT_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._uoeSupplierAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return false;
                    }
            }

            // DataSet展開処理
            UOESupplierToDataSet(uoeSupplier, this.DataIndex);

            return true;
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // 削除モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //保存確認
                UOESupplier compareUOESupplier = new UOESupplier();
                compareUOESupplier = this._uoeSupplierClone.Clone();
                //現在の画面情報を取得する
                DispToUOESupplier(ref compareUOESupplier);
                //最初に取得した画面情報と比較
                if (!(this._uoeSupplierClone.Equals(compareUOESupplier)))
                {
                    //画面情報が変更されていた場合は、保存確認メッセージを表示する
                    DialogResult res = TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        "",									// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.YesNoCancel);		// 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (SaveProc() == false)
                                {
                                    return;
                                }

                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        case DialogResult.No:
                            {
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        default:
                            {
                                // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                                //this.Cancel_Button.Focus();
                                if (_modeFlg)
                                {
                                    UOESupplierCd_tNedit.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                                return;
                            }
                    }
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            int status = 0;
            DialogResult result = TMsgDisp.Show(
                this,													// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION,						// エラーレベル
                ASSEMBLY_ID,											// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" + "よろしいですか？",	// 表示するメッセージ 
                0,														// ステータス値
                MessageBoxButtons.OKCancel,								// 表示するボタン
                MessageBoxDefaultButton.Button2);						// 初期表示ボタン


            if (result == DialogResult.OK)
            {
                string guid = (string)this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[this._dataIndex][GUID_TITLE];
                UOESupplier uoeSupplier = ((UOESupplier)this._uoeSupplierTable[guid]).Clone();

                status = this._uoeSupplierAcs.Delete(uoeSupplier);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[this.DataIndex].Delete();
                            this._uoeSupplierTable.Remove(CreateHashKey(uoeSupplier));
                            
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._uoeSupplierAcs);

                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._indexBuf = -2;

                            if (CanClose == true)
                            {
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                            }

                            return;
                        }
                    default:
                        {
                            TMsgDisp.Show(
                                this,								  // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                                ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                                this.Text,							  // プログラム名称
                                "Delete_Button_Click",				  // 処理名称
                                TMsgDisp.OPE_DELETE,				  // オペレーション
                                ERR_RDEL_MSG,						  // 表示するメッセージ 
                                status,								  // ステータス値
                                this._uoeSupplierAcs,					  // エラーが発生したオブジェクト
                                MessageBoxButtons.OK,				  // 表示するボタン
                                MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._indexBuf = -2;

                            if (CanClose == true)
                            {
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                            }

                            return;
                        }
                }
            }
            else
            {
                this.Delete_Button.Focus();
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string guid = (string)this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[this._dataIndex][GUID_TITLE];
            UOESupplier uoeSupplier = ((UOESupplier)_uoeSupplierTable[guid]).Clone();

            status = this._uoeSupplierAcs.Revival(ref uoeSupplier);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._uoeSupplierAcs);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "Revive_Button_Click",				  // 処理名称
                            TMsgDisp.OPE_UPDATE,				  // オペレーション
                            ERR_RVV_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._uoeSupplierAcs,					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
            }

            // DataSet展開処理
            UOESupplierToDataSet(uoeSupplier, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
        ///					  この処理は、システムが提供するスレッド プール
        ///					  スレッドで実行されます。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        /// UOE発注先ガイドボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : UOE発注先ガイドボタン押下時の処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_UOESupplierGuide_Click(object sender, EventArgs e)
        {
            UOESupplier uoeSupplier = null;
            int status = this.ShowUOESupplierGuide(out uoeSupplier);

            if (status == 0)
            {
                // 選択した情報を画面に設定
                UOESupplierToScreen(uoeSupplier);
                // 入力項目の有効無効チェック
                InputEnableCheck();

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// メーカーガイドボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : メーカーガイドボタン押下時の処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_MakerGuide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            int status = this.ShowMakerUMntGuide(out makerUMnt);

            if (status == 0)
            {
                // 選択した情報を取得
                this.tNedit_GoodsMakerCdAllowZero.SetInt(makerUMnt.GoodsMakerCd);
                this.GoodsMakerNm_tEdit.Text = makerUMnt.MakerName;

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// 仕入先ガイド押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 仕入先ガイド押下時の処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void ultraButton_SupplierGuide_Click(object sender, EventArgs e)
        {
            Supplier supplier = null;
            int status = this.ShowSupplierGuide(out supplier);

            if (status == 0)
            {
                // 選択した情報を取得
                this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);
                this.SupplierNm_tEdit.Text = supplier.SupplierSnm;

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// 出庫拠点ガイドボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 出庫拠点ガイドボタン押下時の処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_UOEShipSectGuide_Click(object sender, EventArgs e)
        {
            UOEGuideName uoeGuideName = null;
            string message;
            int status = this.ShowUOEGuideNameGuide(out uoeGuideName);

            if (status == 0)
            {
                // 選択した情報を取得
                this.UOEShipSectCd_tEdit.Text = uoeGuideName.UOEGuideCode;
                this.UOEShipSectNm_tEdit.Text = uoeGuideName.UOEGuideNm;

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else if (status == -1)
            {
                // 発注先コードが未入力
                message = this.UOESupplierCd_Label.Text + "を入力して下さい。";

                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    ASSEMBLY_ID,      					// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.UOESupplierCd_tNedit.Focus();
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// 売上拠点ガイドボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 売上拠点ガイドボタン押下時の処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_UOESalSectGuide_Click(object sender, EventArgs e)
        {
            UOEGuideName uoeGuideName = null;
            string message;
            int status = this.ShowUOEGuideNameGuide(out uoeGuideName);

            if (status == 0)
            {
                // 選択した情報を取得
                this.UOESalSectCd_tEdit.Text = uoeGuideName.UOEGuideCode;
                this.UOESalSectNm_tEdit.Text = uoeGuideName.UOEGuideNm;

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else if (status == -1)
            {
                // 発注先コードが未入力
                message = this.UOESupplierCd_Label.Text + "を入力して下さい。";

                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    ASSEMBLY_ID,      					// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.UOESupplierCd_tNedit.Focus();
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// 指定拠点ガイドボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 指定拠点ガイドボタン押下時の処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_UOEReservSectGuide_Click(object sender, EventArgs e)
        {
            UOEGuideName uoeGuideName = null;
            string message;
            int status = this.ShowUOEGuideNameGuide(out uoeGuideName);

            if (status == 0)
            {
                // 選択した情報を取得
                this.UOEReservSectCd_tEdit.Text = uoeGuideName.UOEGuideCode;
                this.UOEReservSectNm_tEdit.Text = uoeGuideName.UOEGuideNm;

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else if (status == -1)
            {
                // 発注先コードが未入力
                message = this.UOESupplierCd_Label.Text + "を入力して下さい。";

                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    ASSEMBLY_ID,      					// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.UOESupplierCd_tNedit.Focus();
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// 発注可能メーカー１ガイドボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 発注可能メーカー１ガイドボタン押下時の処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_EnableOdrMaker1Guide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            string message;
            int status = this.ShowMakerUMntGuide(out makerUMnt);

            if (status == 0)
            {
                if ((this.EnableOdrMakerCd2_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd3_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd4_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd5_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd6_tNedit.GetInt() == makerUMnt.GoodsMakerCd))
                {
                    // 発注可能メーカーが重複
                    message = "選択した発注可能メーカーは重複しています。";

                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        ASSEMBLY_ID,      					// アセンブリＩＤまたはクラスＩＤ
                        message,							// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン

                    this.EnableOdrMakerCd1_tNedit.Focus();
                }
                else
                {
                    // 選択した情報を取得
                    this.EnableOdrMakerCd1_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.EnableOdrMakerNm1_tEdit.Text = makerUMnt.MakerName;

                    mekaKubenSet(this.MakerCd1_tComboEditor, true); // ADD 2011/12/15 yangmj for Redmine#27386

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// 発注可能メーカー２ガイドボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 発注可能メーカー２ガイドボタン押下時の処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_EnableOdrMaker2Guide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            string message;
            int status = this.ShowMakerUMntGuide(out makerUMnt);

            if (status == 0)
            {
                if ((this.EnableOdrMakerCd1_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd3_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd4_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd5_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd6_tNedit.GetInt() == makerUMnt.GoodsMakerCd))
                {
                    // 発注可能メーカーが重複
                    message = "選択した発注可能メーカーは重複しています。";

                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        ASSEMBLY_ID,      					// アセンブリＩＤまたはクラスＩＤ
                        message,							// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン

                    this.EnableOdrMakerCd2_tNedit.Focus();
                }
                else
                {
                    // 選択した情報を取得
                    this.EnableOdrMakerCd2_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.EnableOdrMakerNm2_tEdit.Text = makerUMnt.MakerName;

                    mekaKubenSet(this.MakerCd2_tComboEditor, true); // ADD 2011/12/15 yangmj for Redmine#27386

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// 発注可能メーカー３ガイドボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 発注可能メーカー３ガイドボタン押下時の処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_EnableOdrMaker3Guide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            string message;
            int status = this.ShowMakerUMntGuide(out makerUMnt);

            if (status == 0)
            {
                if ((this.EnableOdrMakerCd1_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd2_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd4_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd5_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd6_tNedit.GetInt() == makerUMnt.GoodsMakerCd))
                {
                    // 発注可能メーカーが重複
                    message = "選択した発注可能メーカーは重複しています。";

                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        ASSEMBLY_ID,      					// アセンブリＩＤまたはクラスＩＤ
                        message,							// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン

                    this.EnableOdrMakerCd3_tNedit.Focus();
                }
                else
                {
                    // 選択した情報を取得
                    this.EnableOdrMakerCd3_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.EnableOdrMakerNm3_tEdit.Text = makerUMnt.MakerName;

                    mekaKubenSet(this.MakerCd3_tComboEditor, true); // ADD 2011/12/15 yangmj for Redmine#27386

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// 発注可能メーカー４ガイドボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 発注可能メーカー４ガイドボタン押下時の処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_EnableOdrMaker4Guide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            string message;
            int status = this.ShowMakerUMntGuide(out makerUMnt);

            if (status == 0)
            {
                if ((this.EnableOdrMakerCd1_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd2_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd3_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd5_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd6_tNedit.GetInt() == makerUMnt.GoodsMakerCd))
                {
                    // 発注可能メーカーが重複
                    message = "選択した発注可能メーカーは重複しています。";

                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        ASSEMBLY_ID,      					// アセンブリＩＤまたはクラスＩＤ
                        message,							// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン

                    this.EnableOdrMakerCd4_tNedit.Focus();
                }
                else
                {
                    // 選択した情報を取得
                    this.EnableOdrMakerCd4_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.EnableOdrMakerNm4_tEdit.Text = makerUMnt.MakerName;

                    mekaKubenSet(this.MakerCd4_tComboEditor, true); // ADD 2011/12/15 yangmj for Redmine#27386

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// 発注可能メーカー５ガイドボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 発注可能メーカー５ガイドボタン押下時の処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_EnableOdrMaker5Guide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            string message;
            int status = this.ShowMakerUMntGuide(out makerUMnt);

            if (status == 0)
            {
                if ((this.EnableOdrMakerCd1_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd2_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd3_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd4_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd6_tNedit.GetInt() == makerUMnt.GoodsMakerCd))
                {
                    // 発注可能メーカーが重複
                    message = "選択した発注可能メーカーは重複しています。";

                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        ASSEMBLY_ID,      					// アセンブリＩＤまたはクラスＩＤ
                        message,							// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン

                    this.EnableOdrMakerCd5_tNedit.Focus();
                }
                else
                {
                    // 選択した情報を取得
                    this.EnableOdrMakerCd5_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.EnableOdrMakerNm5_tEdit.Text = makerUMnt.MakerName;

                    mekaKubenSet(this.MakerCd5_tComboEditor, true); // ADD 2011/12/15 yangmj for Redmine#27386

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// 発注可能メーカー６ガイドボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 発注可能メーカー６ガイドボタン押下時の処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private void uButton_EnableOdrMaker6Guide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            string message;
            int status = this.ShowMakerUMntGuide(out makerUMnt);

            if (status == 0)
            {
                if ((this.EnableOdrMakerCd1_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd2_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd3_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd4_tNedit.GetInt() == makerUMnt.GoodsMakerCd) ||
                    (this.EnableOdrMakerCd5_tNedit.GetInt() == makerUMnt.GoodsMakerCd))
                {
                    // 発注可能メーカーが重複
                    message = "選択した発注可能メーカーは重複しています。";

                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        ASSEMBLY_ID,      					// アセンブリＩＤまたはクラスＩＤ
                        message,							// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン

                    this.EnableOdrMakerCd6_tNedit.Focus();
                }
                else
                {
                    // 選択した情報を取得
                    this.EnableOdrMakerCd6_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.EnableOdrMakerNm6_tEdit.Text = makerUMnt.MakerName;

                    mekaKubenSet(this.MakerCd6_tComboEditor, true); // ADD 2011/12/15 yangmj for Redmine#27386

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        // ---ADD 2009/06/01 ------------------------------------------------------------->>>>>
        /// <summary>
        /// 回答保存フォルダボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 回答保存フォルダボタン押下時の処理を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void uButton_AnswerSaveFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dialogResult = fbd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.AnswerSaveFolder_tEdit.Text = fbd.SelectedPath;
                this.UOELoginUrl_tEdit.Focus();
            }
        }
        // ---ADD 2009/06/01 -------------------------------------------------------------<<<<<

        /// <summary>
        /// リターンキー移動イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : リターンキー押下時の制御を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// <br>UpdateNote : 2010/05/14 呉元嘯 明治UOEWeb項目の対応</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            bool canChangeFocus = true;

            object inParamObj = null;
            object outParamObj = null;
            ArrayList inParamList = new ArrayList();

            // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
            
            switch (e.PrevCtrl.Name)
            {
                // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                case "UOESupplierCd_tNedit":
                    {
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = UOESupplierCd_tNedit;
                            }
                        }
                        break;
                    }
                // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                // メーカーコード
                case "tNedit_GoodsMakerCdAllowZero":
                    {
                        // 条件設定クリア
                        inParamObj = null;
                        outParamObj = null;

                        if (this.tNedit_GoodsMakerCdAllowZero.GetInt() == 0)
                        {
                            // メーカー名称設定
                            this.GoodsMakerNm_tEdit.Text = MAKER_CODE_ZERO;
                            break;
                        }
                        
                        // 条件設定
                        inParamObj = this.tNedit_GoodsMakerCdAllowZero.GetInt();
                        // メーカー名称取得
                        outParamObj = this.GetMakerName((int)inParamObj);

                        // メーカー名称の存在チェック
                        if (!outParamObj.Equals(""))
                        {
                            // メーカー名称設定
                            this.GoodsMakerNm_tEdit.Text = (string)outParamObj;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            // フォーカスを仕入先コードに遷移
                                            e.NextCtrl = this.tNedit_SupplierCd;
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            // 該当データ無し
                            TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "該当するメーカーコードが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                            this.tNedit_GoodsMakerCdAllowZero.Clear();
                            this.GoodsMakerNm_tEdit.Clear();

                            // フォーカスは遷移しない
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // プログラム
                case "CommAssemblyId_tEdit":
                    {
                        // 入力項目の有効無効チェック
                        InputEnableCheck();

                        break;
                    }
                // 出庫拠点
                case "UOEShipSectCd_tEdit":
                    {
                        // 条件設定クリア
                        inParamObj = null;
                        outParamObj = null;

                        if (this.UOEShipSectCd_tEdit.Text.TrimEnd() != "")
                        {
                            // UOE発注先コードのチェック
                            if (this.UOESupplierCd_tNedit.Text.Trim() == "")
                            {
                                // 未入力
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "発注先コードを入力してください。",
                                    -1,
                                    MessageBoxButtons.OK);

                                // フォーカスをUOE発注先コードに遷移
                                e.NextCtrl = this.UOESupplierCd_tNedit;
                                break;
                            }

                            // 条件設定
                            inParamObj = this.UOEShipSectCd_tEdit.Text.TrimEnd();
                            // ガイド名称取得
                            outParamObj = this.GetUOEGuideName(this.UOESupplierCd_tNedit.GetInt(), (string)inParamObj);

                            // ガイド名称の存在チェック
                            if (!outParamObj.Equals(""))
                            {
                                // 出庫拠点名称設定
                                this.UOEShipSectNm_tEdit.Text = (string)outParamObj;

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // フォーカスを売上拠点コードに遷移
                                                e.NextCtrl = this.UOESalSectCd_tEdit;
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // 該当データ無し
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する拠点コードが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.UOEShipSectCd_tEdit.Clear();
                                this.UOEShipSectNm_tEdit.Clear();

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // 未入力
                            this.UOEShipSectCd_tEdit.Clear();
                            this.UOEShipSectNm_tEdit.Clear();
                        }
                        break;
                    }
                // 売上拠点
                case "UOESalSectCd_tEdit":
                    {
                        // 条件設定クリア
                        inParamObj = null;
                        outParamObj = null;

                        // Shift+Tabのフォーカス制御
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.UOEShipSectCd_tEdit.Text.Trim() != "")
                            {
                                // 出庫拠点コードにフォーカス遷移
                                e.NextCtrl = this.UOEShipSectCd_tEdit;
                                break;
                            }
                        }

                        if (this.UOESalSectCd_tEdit.Text.TrimEnd() != "")
                        {
                            // UOE発注先コードのチェック
                            if (this.UOESupplierCd_tNedit.Text.Trim() == "")
                            {
                                // 未入力
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "発注先コードを入力してください。",
                                    -1,
                                    MessageBoxButtons.OK);

                                // フォーカスをUOE発注先コードに遷移
                                e.NextCtrl = this.UOESupplierCd_tNedit;
                                break;
                            }

                            // 条件設定
                            inParamObj = this.UOESalSectCd_tEdit.Text.TrimEnd();
                            // ガイド名称取得
                            outParamObj = this.GetUOEGuideName(this.UOESupplierCd_tNedit.GetInt(), (string)inParamObj);

                            // ガイド名称の存在チェック
                            if (!outParamObj.Equals(""))
                            {
                                // 売上拠点名称設定
                                this.UOESalSectNm_tEdit.Text = (string)outParamObj;

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // フォーカスを指定拠点コードに遷移
                                                e.NextCtrl = this.UOEReservSectCd_tEdit;
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // 該当データ無し
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する拠点コードが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.UOESalSectCd_tEdit.Clear();
                                this.UOESalSectNm_tEdit.Clear();

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // 未入力
                            this.UOESalSectCd_tEdit.Clear();
                            this.UOESalSectNm_tEdit.Clear();
                        }
                        break;
                    }
                // 指定拠点
                case "UOEReservSectCd_tEdit":
                    {
                        // 条件設定クリア
                        inParamObj = null;
                        outParamObj = null;

                        // Shift+Tabのフォーカス制御
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.UOESalSectCd_tEdit.Text.Trim() != "")
                            {
                                // 売上拠点コードにフォーカス遷移
                                e.NextCtrl = this.UOESalSectCd_tEdit;
                                break;
                            }
                        }


                        if (this.UOEReservSectCd_tEdit.Text.TrimEnd() != "")
                        {
                            // UOE発注先コードのチェック
                            if (this.UOESupplierCd_tNedit.Text.Trim() == "")
                            {
                                // 未入力
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "発注先コードを入力してください。",
                                    -1,
                                    MessageBoxButtons.OK);

                                // フォーカスをUOE発注先コードに遷移
                                e.NextCtrl = this.UOESupplierCd_tNedit;
                                break;
                            }

                            // 条件設定
                            inParamObj = this.UOEReservSectCd_tEdit.Text.TrimEnd();
                            // ガイド名称取得
                            outParamObj = this.GetUOEGuideName(this.UOESupplierCd_tNedit.GetInt(), (string)inParamObj);

                            // ガイド名称の存在チェック
                            if (!outParamObj.Equals(""))
                            {
                                // 指定拠点名称設定
                                this.UOEReservSectNm_tEdit.Text = (string)outParamObj;

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // フォーカスを受信有無区分に遷移
                                                e.NextCtrl = this.ReceiveCondition_tComboEditor;
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // 該当データ無し
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する拠点コードが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.UOEReservSectCd_tEdit.Clear();
                                this.UOEReservSectNm_tEdit.Clear();

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // 未入力
                            this.UOEReservSectCd_tEdit.Clear();
                            this.UOEReservSectNm_tEdit.Clear();
                        }
                        break;
                    }
                // 発注可能メーカー１
                case "EnableOdrMakerCd1_tNedit":
                    {
                        // 条件設定クリア
                        inParamObj = null;
                        outParamObj = null;

                        if (e.Key == Keys.Up)
                        {
                            if (this.UOEOrderRate_tEdit.Enabled)
                            {
                                // レートにフォーカス遷移
                                e.NextCtrl = this.UOEOrderRate_tEdit;
                                break;
                            }
                        }

                        if (this.EnableOdrMakerCd1_tNedit.GetInt() != 0)
                        {
                            // 条件設定
                            inParamObj = this.EnableOdrMakerCd1_tNedit.GetInt();

                            if ((this.EnableOdrMakerCd2_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd3_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd4_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd5_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd6_tNedit.GetInt() == (int)inParamObj))
                            {
                                // 発注可能メーカーが重複
                                TMsgDisp.Show(
                                    this,								            // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	            // エラーレベル
                                    ASSEMBLY_ID,      					            // アセンブリＩＤまたはクラスＩＤ
                                    "選択した発注可能メーカーは重複しています。",	// 表示するメッセージ 
                                    0,          									// ステータス値
                                    MessageBoxButtons.OK);				            // 表示するボタン

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }

                            // メーカー名称取得
                            outParamObj = this.GetMakerName((int)inParamObj);

                            // メーカー名称の存在チェック
                            if (!outParamObj.Equals(""))
                            {
                                // 発注可能メーカー名称１設定
                                this.EnableOdrMakerNm1_tEdit.Text = (string)outParamObj;
                                mekaKubenSet(this.MakerCd1_tComboEditor, true);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // フォーカスを発注可能メーカー２コードに遷移
                                                //e.NextCtrl = this.EnableOdrMakerCd2_tNedit;//DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                                                // ADD 2011/12/15 yangmj for Redmine#27386 ----------------->>>>>>
                                                if (this.MakerCd1_tComboEditor.Visible && this.MakerCd1_tComboEditor.Enabled)
                                                {
                                                    e.NextCtrl = this.MakerCd1_tComboEditor;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.EnableOdrMakerCd2_tNedit;
                                                }
                                                // ADD 2011/12/15 yangmj for Redmine#27386 -----------------<<<<<<
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // 該当データ無し
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当するメーカーコードが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.EnableOdrMakerCd1_tNedit.Clear();
                                this.EnableOdrMakerNm1_tEdit.Clear();
                                mekaKubenSet(this.MakerCd1_tComboEditor, true);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // 未入力
                            this.EnableOdrMakerCd1_tNedit.Clear();
                            this.EnableOdrMakerNm1_tEdit.Clear();
                            mekaKubenSet(this.MakerCd1_tComboEditor, false);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                        }
                        break;
                    }
                // 発注可能メーカー２
                case "EnableOdrMakerCd2_tNedit":
                    {
                        // 条件設定クリア
                        inParamObj = null;
                        outParamObj = null;

                        // Shift+Tabのフォーカス制御
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.EnableOdrMakerCd1_tNedit.Text.Trim() != "")
                            {
                                // 発注可能メーカーコード１にフォーカス遷移
                                //e.NextCtrl = this.EnableOdrMakerCd1_tNedit;// DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                                //----- ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                                if (this.MakerCd1_tComboEditor.Visible && this.MakerCd1_tComboEditor.Enabled == true)
                                {
                                    e.NextCtrl = this.MakerCd1_tComboEditor;
                                }
                                else
                                {
                                    e.NextCtrl = this.EnableOdrMakerCd1_tNedit;
                                }
                                //----- ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
                                break;
                            }
                        }

                        if (this.EnableOdrMakerCd2_tNedit.GetInt() != 0)
                        {
                            // 条件設定
                            inParamObj = this.EnableOdrMakerCd2_tNedit.GetInt();

                            if ((this.EnableOdrMakerCd1_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd3_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd4_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd5_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd6_tNedit.GetInt() == (int)inParamObj))
                            {
                                // 発注可能メーカーが重複
                                TMsgDisp.Show(
                                    this,								            // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	            // エラーレベル
                                    ASSEMBLY_ID,      					            // アセンブリＩＤまたはクラスＩＤ
                                    "選択した発注可能メーカーは重複しています。",	// 表示するメッセージ 
                                    0,          									// ステータス値
                                    MessageBoxButtons.OK);				            // 表示するボタン

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }

                            // メーカー名称取得
                            outParamObj = this.GetMakerName((int)inParamObj);

                            // メーカー名称の存在チェック
                            if (!outParamObj.Equals(""))
                            {
                                // 発注可能メーカー名称２設定
                                this.EnableOdrMakerNm2_tEdit.Text = (string)outParamObj;
                                mekaKubenSet(this.MakerCd2_tComboEditor, true);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // フォーカスを発注可能メーカー３コードに遷移
                                                //e.NextCtrl = this.EnableOdrMakerCd3_tNedit;// DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                                                // ADD 2011/12/15 yangmj for Redmine#27386 ----------------->>>>>>
                                                if (this.MakerCd2_tComboEditor.Visible && this.MakerCd2_tComboEditor.Enabled)
                                                {
                                                    e.NextCtrl = this.MakerCd2_tComboEditor;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.EnableOdrMakerCd3_tNedit;
                                                }
                                                // ADD 2011/12/15 yangmj for Redmine#27386 -----------------<<<<<<
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // 該当データ無し
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当するメーカーコードが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.EnableOdrMakerCd2_tNedit.Clear();
                                this.EnableOdrMakerNm2_tEdit.Clear();
                                mekaKubenSet(this.MakerCd2_tComboEditor, false);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // 未入力
                            this.EnableOdrMakerCd2_tNedit.Clear();
                            this.EnableOdrMakerNm2_tEdit.Clear();
                            mekaKubenSet(this.MakerCd2_tComboEditor, false);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                        }
                        break;
                    }
                // 発注可能メーカー３
                case "EnableOdrMakerCd3_tNedit":
                    {
                        // 条件設定クリア
                        inParamObj = null;
                        outParamObj = null;

                        // Shift+Tabのフォーカス制御
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.EnableOdrMakerCd2_tNedit.Text.Trim() != "")
                            {
                                // 発注可能メーカーコード２にフォーカス遷移
                                //e.NextCtrl = this.EnableOdrMakerCd2_tNedit;// DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                                //----- ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                                if (this.MakerCd2_tComboEditor.Visible && this.MakerCd2_tComboEditor.Enabled == true)
                                {
                                    e.NextCtrl = this.MakerCd2_tComboEditor;
                                }
                                else
                                {
                                    e.NextCtrl = this.EnableOdrMakerCd2_tNedit;
                                }
                                //----- ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
                                break;
                            }
                        }

                        if (this.EnableOdrMakerCd3_tNedit.GetInt() != 0)
                        {
                            // 条件設定
                            inParamObj = this.EnableOdrMakerCd3_tNedit.GetInt();

                            if ((this.EnableOdrMakerCd1_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd2_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd4_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd5_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd6_tNedit.GetInt() == (int)inParamObj))
                            {
                                // 発注可能メーカーが重複
                                TMsgDisp.Show(
                                    this,								            // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	            // エラーレベル
                                    ASSEMBLY_ID,      					            // アセンブリＩＤまたはクラスＩＤ
                                    "選択した発注可能メーカーは重複しています。",	// 表示するメッセージ 
                                    0,          									// ステータス値
                                    MessageBoxButtons.OK);				            // 表示するボタン

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }

                            // メーカー名称取得
                            outParamObj = this.GetMakerName((int)inParamObj);

                            // メーカー名称の存在チェック
                            if (!outParamObj.Equals(""))
                            {
                                // 発注可能メーカー名称３設定
                                this.EnableOdrMakerNm3_tEdit.Text = (string)outParamObj;
                                mekaKubenSet(this.MakerCd3_tComboEditor, true);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // フォーカスを発注可能メーカー４コードに遷移
                                                //e.NextCtrl = this.EnableOdrMakerCd4_tNedit;// DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                                                // ADD 2011/12/15 yangmj for Redmine#27386 ----------------->>>>>>
                                                if (this.MakerCd3_tComboEditor.Visible && this.MakerCd3_tComboEditor.Enabled)
                                                {
                                                    e.NextCtrl = this.MakerCd3_tComboEditor;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.EnableOdrMakerCd4_tNedit;
                                                }
                                                // ADD 2011/12/15 yangmj for Redmine#27386 -----------------<<<<<<
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // 該当データ無し
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当するメーカーコードが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.EnableOdrMakerCd3_tNedit.Clear();
                                this.EnableOdrMakerNm3_tEdit.Clear();
                                mekaKubenSet(this.MakerCd3_tComboEditor, false);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // 未入力
                            this.EnableOdrMakerCd3_tNedit.Clear();
                            this.EnableOdrMakerNm3_tEdit.Clear();
                            mekaKubenSet(this.MakerCd3_tComboEditor, false);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                        }
                        break;
                    }
                // 発注可能メーカー４
                case "EnableOdrMakerCd4_tNedit":
                    {
                        // 条件設定クリア
                        inParamObj = null;
                        outParamObj = null;

                        // Shift+Tabのフォーカス制御
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.EnableOdrMakerCd3_tNedit.Text.Trim() != "")
                            {
                                // 発注可能メーカーコード３にフォーカス遷移
                                //e.NextCtrl = this.EnableOdrMakerCd3_tNedit;//DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                                //----- ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                                if (this.MakerCd3_tComboEditor.Visible && this.MakerCd3_tComboEditor.Enabled == true)
                                {
                                    e.NextCtrl = this.MakerCd3_tComboEditor;
                                }
                                else
                                {
                                    e.NextCtrl = this.EnableOdrMakerCd3_tNedit;
                                }
                                //----- ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
                                break;
                            }
                        }

                        if (this.EnableOdrMakerCd4_tNedit.GetInt() != 0)
                        {
                            // 条件設定
                            inParamObj = this.EnableOdrMakerCd4_tNedit.GetInt();

                            if ((this.EnableOdrMakerCd1_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd2_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd3_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd5_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd6_tNedit.GetInt() == (int)inParamObj))
                            {
                                // 発注可能メーカーが重複
                                TMsgDisp.Show(
                                    this,								            // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	            // エラーレベル
                                    ASSEMBLY_ID,      					            // アセンブリＩＤまたはクラスＩＤ
                                    "選択した発注可能メーカーは重複しています。",	// 表示するメッセージ 
                                    0,          									// ステータス値
                                    MessageBoxButtons.OK);				            // 表示するボタン

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }

                            // メーカー名称取得
                            outParamObj = this.GetMakerName((int)inParamObj);

                            // メーカー名称の存在チェック
                            if (!outParamObj.Equals(""))
                            {
                                // 発注可能メーカー名称４設定
                                this.EnableOdrMakerNm4_tEdit.Text = (string)outParamObj;
                                mekaKubenSet(this.MakerCd4_tComboEditor, true);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // フォーカスを発注可能５コードに遷移
                                                //e.NextCtrl = this.EnableOdrMakerCd5_tNedit;// DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                                                // ADD 2011/12/15 yangmj for Redmine#27386 ----------------->>>>>>
                                                if (this.MakerCd4_tComboEditor.Visible && this.MakerCd4_tComboEditor.Enabled)
                                                {
                                                    e.NextCtrl = this.MakerCd4_tComboEditor;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.EnableOdrMakerCd5_tNedit;
                                                }
                                                // ADD 2011/12/15 yangmj for Redmine#27386 -----------------<<<<<<
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // 該当データ無し
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当するメーカーコードが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.EnableOdrMakerCd4_tNedit.Clear();
                                this.EnableOdrMakerNm4_tEdit.Clear();
                                mekaKubenSet(this.MakerCd4_tComboEditor, false);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // 未入力
                            this.EnableOdrMakerCd4_tNedit.Clear();
                            this.EnableOdrMakerNm4_tEdit.Clear();
                            mekaKubenSet(this.MakerCd4_tComboEditor, false);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                        }
                        break;
                    }
                // 発注可能メーカー５
                case "EnableOdrMakerCd5_tNedit":
                    {
                        // 条件設定クリア
                        inParamObj = null;
                        outParamObj = null;

                        // Shift+Tabのフォーカス制御
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.EnableOdrMakerCd4_tNedit.Text.Trim() != "")
                            {
                                // 発注可能メーカーコード４にフォーカス遷移
                                //e.NextCtrl = this.EnableOdrMakerCd4_tNedit;//DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                                //----- ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                                if (this.MakerCd4_tComboEditor.Visible && this.MakerCd4_tComboEditor.Enabled == true)
                                {
                                    e.NextCtrl = this.MakerCd4_tComboEditor;
                                }
                                else
                                {
                                    e.NextCtrl = this.EnableOdrMakerCd4_tNedit;
                                }
                                //----- ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
                                break;
                            }
                        }

                        if (this.EnableOdrMakerCd5_tNedit.GetInt() != 0)
                        {
                            // 条件設定
                            inParamObj = this.EnableOdrMakerCd5_tNedit.GetInt();

                            if ((this.EnableOdrMakerCd1_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd2_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd3_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd4_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd6_tNedit.GetInt() == (int)inParamObj))
                            {
                                // 発注可能メーカーが重複
                                TMsgDisp.Show(
                                    this,								            // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	            // エラーレベル
                                    ASSEMBLY_ID,      					            // アセンブリＩＤまたはクラスＩＤ
                                    "選択した発注可能メーカーは重複しています。",	// 表示するメッセージ 
                                    0,          									// ステータス値
                                    MessageBoxButtons.OK);				            // 表示するボタン

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }

                            // メーカー名称取得
                            outParamObj = this.GetMakerName((int)inParamObj);

                            // メーカー名称の存在チェック
                            if (!outParamObj.Equals(""))
                            {
                                // 発注可能メーカー名称５設定
                                this.EnableOdrMakerNm5_tEdit.Text = (string)outParamObj;
                                mekaKubenSet(this.MakerCd5_tComboEditor, true);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // フォーカスを発注可能６コードに遷移
                                                //e.NextCtrl = this.EnableOdrMakerCd6_tNedit;// DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                                                // ADD 2011/12/15 yangmj for Redmine#27386 ----------------->>>>>>
                                                if (this.MakerCd5_tComboEditor.Visible && this.MakerCd5_tComboEditor.Enabled)
                                                {
                                                    e.NextCtrl = this.MakerCd5_tComboEditor;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.EnableOdrMakerCd6_tNedit;
                                                }
                                                // ADD 2011/12/15 yangmj for Redmine#27386 -----------------<<<<<<
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // 該当データ無し
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当するメーカーコードが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.EnableOdrMakerCd5_tNedit.Clear();
                                this.EnableOdrMakerNm5_tEdit.Clear();
                                mekaKubenSet(this.MakerCd5_tComboEditor, false);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // 未入力
                            this.EnableOdrMakerCd5_tNedit.Clear();
                            this.EnableOdrMakerNm5_tEdit.Clear();
                            mekaKubenSet(this.MakerCd5_tComboEditor, false);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                        }
                        break;
                    }
                // 発注可能メーカー６
                case "EnableOdrMakerCd6_tNedit":
                    {
                        // 条件設定クリア
                        inParamObj = null;
                        outParamObj = null;

                        // Shift+Tabのフォーカス制御
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.EnableOdrMakerCd5_tNedit.Text.Trim() != "")
                            {
                                // 発注可能メーカーコード５にフォーカス遷移
                                e.NextCtrl = this.EnableOdrMakerCd5_tNedit;//DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                                //----- ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                                if (this.MakerCd5_tComboEditor.Visible && this.MakerCd5_tComboEditor.Enabled == true)
                                {
                                    e.NextCtrl = this.MakerCd5_tComboEditor;
                                }
                                else
                                {
                                    e.NextCtrl = this.EnableOdrMakerCd5_tNedit;
                                }
                                //----- ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
                                break;
                            }
                        }

                        if (this.EnableOdrMakerCd6_tNedit.GetInt() != 0)
                        {
                            // 条件設定
                            inParamObj = this.EnableOdrMakerCd6_tNedit.GetInt();

                            if ((this.EnableOdrMakerCd1_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd2_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd3_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd4_tNedit.GetInt() == (int)inParamObj) ||
                                (this.EnableOdrMakerCd5_tNedit.GetInt() == (int)inParamObj))
                            {
                                // 発注可能メーカーが重複
                                TMsgDisp.Show(
                                    this,								            // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	            // エラーレベル
                                    ASSEMBLY_ID,      					            // アセンブリＩＤまたはクラスＩＤ
                                    "選択した発注可能メーカーは重複しています。",	// 表示するメッセージ 
                                    0,          									// ステータス値
                                    MessageBoxButtons.OK);				            // 表示するボタン

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }

                            // メーカー名称取得
                            outParamObj = this.GetMakerName((int)inParamObj);

                            // メーカー名称の存在チェック
                            if (!outParamObj.Equals(""))
                            {
                                // 発注可能メーカー名称６設定
                                this.EnableOdrMakerNm6_tEdit.Text = (string)outParamObj;
                                mekaKubenSet(this.MakerCd6_tComboEditor, true);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // フォーカスを保存ボタンに遷移
                                                //e.NextCtrl = this.Ok_Button;// DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                                                // ADD 2011/12/15 yangmj for Redmine#27386 ----------------->>>>>>
                                                if (this.MakerCd6_tComboEditor.Visible && this.MakerCd6_tComboEditor.Enabled)
                                                {
                                                    e.NextCtrl = this.MakerCd6_tComboEditor;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.Ok_Button;
                                                }
                                                // ADD 2011/12/15 yangmj for Redmine#27386 -----------------<<<<<<
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // 該当データ無し
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当するメーカーコードが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.EnableOdrMakerCd6_tNedit.Clear();
                                this.EnableOdrMakerNm6_tEdit.Clear();
                                mekaKubenSet(this.MakerCd6_tComboEditor, false);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // 未入力
                            this.EnableOdrMakerCd6_tNedit.Clear();
                            this.EnableOdrMakerNm6_tEdit.Clear();
                            mekaKubenSet(this.MakerCd6_tComboEditor, false);// ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                        }
                        break;
                    }
                // ADD 2011/12/15 yangmj for Redmine#27386 ----------------->>>>>>
                // 発注可能メーカー１のハイフン設定
                case "MakerCd1_tComboEditor":
                    {
                        if (e.ShiftKey && e.Key == Keys.Tab && this.EnableOdrMakerCd1_tNedit.Text.Trim() != "")
                        {
                            e.NextCtrl = this.EnableOdrMakerCd1_tNedit;
                        }
                        break;
                    }
                // 発注可能メーカー２のハイフン設定
                case "MakerCd2_tComboEditor":
                    {
                        if (e.ShiftKey && e.Key == Keys.Tab && this.EnableOdrMakerCd2_tNedit.Text.Trim() != "")
                        {
                            e.NextCtrl = this.EnableOdrMakerCd2_tNedit;
                        }
                        break;
                    }
                // 発注可能メーカー３のハイフン設定
                case "MakerCd3_tComboEditor":
                    {
                        if (e.ShiftKey && e.Key == Keys.Tab && this.EnableOdrMakerCd3_tNedit.Text.Trim() != "")
                        {
                            e.NextCtrl = this.EnableOdrMakerCd3_tNedit;
                        }
                        break;
                    }
                // 発注可能メーカー４のハイフン設定
                case "MakerCd4_tComboEditor":
                    {
                        if (e.ShiftKey && e.Key == Keys.Tab && this.EnableOdrMakerCd4_tNedit.Text.Trim() != "")
                        {
                            e.NextCtrl = this.EnableOdrMakerCd4_tNedit;
                        }
                        break;
                    }
                // 発注可能メーカー５のハイフン設定
                case "MakerCd5_tComboEditor":
                    {
                        if (e.ShiftKey && e.Key == Keys.Tab && this.EnableOdrMakerCd5_tNedit.Text.Trim() != "")
                        {
                            e.NextCtrl = this.EnableOdrMakerCd5_tNedit;
                        }
                        break;
                    }
                // 発注可能メーカー６のハイフン設定
                case "MakerCd6_tComboEditor":
                    {
                        if (e.ShiftKey && e.Key == Keys.Tab && this.EnableOdrMakerCd6_tNedit.Text.Trim() != "")
                        {
                            e.NextCtrl = this.EnableOdrMakerCd6_tNedit;
                        }
                        break;
                    }
                // ADD 2011/12/15 yangmj for Redmine#27386 -----------------<<<<<<
                #region 仕入先
                case "tNedit_SupplierCd":
                    {
                        // 条件設定クリア
                        inParamObj = null;
                        outParamObj = null;

                        // Shift+Tabのフォーカス制御
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if ((this.tNedit_GoodsMakerCdAllowZero.Text.Trim() != "") && (this.tNedit_GoodsMakerCdAllowZero.GetInt() != 0))
                            {
                                // メーカーコードにフォーカス遷移
                                e.NextCtrl = this.tNedit_GoodsMakerCdAllowZero;
                                break;
                            }
                        }

                        if (this.tNedit_SupplierCd.GetInt() != 0)
                        {
                            // 条件設定
                            inParamObj = this.tNedit_SupplierCd.GetInt();
                            // 仕入先名称取得
                            outParamObj = this.GetSupplierName((int)inParamObj);

                            // 仕入先名称の存在チェック
                            if (!outParamObj.Equals(""))
                            {
                                // 仕入先名称の設定
                                this.SupplierNm_tEdit.DataText = (string)outParamObj;

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // フォーカスを電話番号に遷移
                                                e.NextCtrl = this.TelNo_tEdit;
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "該当する仕入先コードが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tNedit_SupplierCd.Clear();
                                this.SupplierNm_tEdit.Clear();

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // 未入力
                            this.tNedit_SupplierCd.Clear();
                            this.SupplierNm_tEdit.Clear();
                        }

                        // 2008.11.06 30413 犬飼 他でも名称取得を行うので削除 >>>>>>START
                        #region < 入力チェック >
                        //if (this.tNedit_SupplierCd.GetInt() != 0)
                        //{
                        //    // 発注先データクラス
                        //    Supplier supplier;
                        //    // 発注先データクラスインスタンス化
                        //    SupplierAcs supplierInfoAcs = new SupplierAcs();

                        //    #region < 発注情報取得処理 >
                        //    int status = supplierInfoAcs.Read(out supplier, this._enterpriseCode, this.tNedit_SupplierCd.GetInt());
                        //    #endregion

                        //    #region < 画面表示処理 >

                        //    // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
                        //    if ((status == 0) && (supplier.LogicalDeleteCode != 1))

                        //    // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
                        //    {
                        //        #region -- 取得データ展開 --
                        //        // 取得データ表示
                        //        // 発注情報画面表示
                        //        this.SupplierNm_tEdit.DataText = supplier.SupplierSnm;

                        //        // フォーカスを電話番号に遷移
                        //        e.NextCtrl = this.TelNo_tEdit;
                        //        #endregion
                        //    }
                        //    else
                        //    {
                        //        #region -- 取得失敗 --
                        //        TMsgDisp.Show(
                        //            this,
                        //            emErrorLevel.ERR_LEVEL_INFO,
                        //            this.Name,
                        //            "該当する仕入先コードが存在しません。",
                        //            -1,
                        //            MessageBoxButtons.OK);

                        //        this.tNedit_SupplierCd.Clear();
                        //        this.SupplierNm_tEdit.Clear();

                        //        // フォーカスは遷移しない
                        //        e.NextCtrl = e.PrevCtrl;
                        //        #endregion
                        //    }
                        //    #endregion
                        //}
                        //else
                        //{
                        //    // 未入力
                        //    this.tNedit_SupplierCd.Clear();
                        //    this.SupplierNm_tEdit.Clear();
                        //}
                        #endregion
                        // 2008.11.06 30413 犬飼 他でも名称取得を行うので削除 <<<<<<END
                        break;
                    }
                #endregion
                // 依頼者コード
                case "tEdit_EmployeeCode":
                    {
                        if (this.tEdit_EmployeeCode.Text.Trim() != "")
                        {
                            // 条件設定
                            inParamObj = this.tEdit_EmployeeCode.Text.Trim().PadLeft(4, '0');
                            // 仕入先名称取得
                            outParamObj = this.GetEmployeeName((string)inParamObj);

                            // 仕入先名称の存在チェック
                            if (!outParamObj.Equals(""))
                            {
                                // 依頼者名の設定
                                this.tEdit_EmployeeName.Text = (string)outParamObj;

                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            {
                                                // フォーカスを納品区分に遷移
                                                e.NextCtrl = this.DeliveredGoodsDiv_tComboEditor;
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                // 該当データ無し
                                TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する依頼者コードが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                this.tEdit_EmployeeCode.Clear();
                                this.tEdit_EmployeeName.Clear();

                                // フォーカスは遷移しない
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // 未入力
                            this.tEdit_EmployeeCode.Clear();
                            this.tEdit_EmployeeName.Clear();
                        }
                        break;
                    }
                // 電話番号
                case "TelNo_tEdit":
                    {
                        // Shift+Tabのフォーカス制御
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.tNedit_SupplierCd.Text.Trim() != "")
                            {
                                // 仕入先コードにフォーカス遷移
                                e.NextCtrl = this.tNedit_SupplierCd;
                                break;
                            }
                        }
                        break;
                    }
                // 受信有無コード
                case "ReceiveCondition_tComboEditor":
                    {
                        // Shift+Tabのフォーカス制御
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.UOEReservSectCd_tEdit.Text.Trim() != "")
                            {
                                // 指定拠点コードにフォーカス遷移
                                e.NextCtrl = this.UOEReservSectCd_tEdit;
                                break;
                            }
                        }
                        break;
                    }
                // 納品区分
                case "DeliveredGoodsDiv_tComboEditor":
                    {
                        // Shift+Tabのフォーカス制御
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.tEdit_EmployeeCode.Text.Trim() != "")
                            {
                                // 依頼者コードにフォーカス遷移
                                e.NextCtrl = this.tEdit_EmployeeCode;
                                break;
                            }
                        }
                        break;
                    }
                // 保存ボタン
                case "Ok_Button":
                    {
                        // Shift+Tabのフォーカス制御
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.EnableOdrMakerCd6_tNedit.Text.Trim() != "")
                            {
                                // 発注可能メーカーコード６にフォーカス遷移
                                //e.NextCtrl = this.EnableOdrMakerCd6_tNedit; // DEL 2011/12/15 yangmj for Redmine#27386
                                // ADD 2011/12/15 yangmj for Redmine#27386 ----------------->>>>>>
                                if (this.MakerCd6_tComboEditor.Visible && this.MakerCd6_tComboEditor.Enabled)
                                {
                                    e.NextCtrl = this.MakerCd6_tComboEditor;
                                }
                                else
                                {
                                    e.NextCtrl = this.EnableOdrMakerCd6_tNedit;
                                }
                                // ADD 2011/12/15 yangmj for Redmine#27386 -----------------<<<<<<
                                break;
                            }
                        }
                        else if (e.Key == Keys.Up)
                        {
                            if (this.EnableOdrMakerCd6_tNedit.Enabled)
                            {
                                // 発注可能メーカーコード６にフォーカス遷移
                                e.NextCtrl = this.EnableOdrMakerCd6_tNedit;
                                break;
                            }
                            else if (this.UOEOrderRate_tEdit.Enabled)
                            {
                                // レートにフォーカス遷移
                                e.NextCtrl = this.UOEOrderRate_tEdit;
                                break;
                            }
                        }
                        break;
                    }
                // レート
                case "UOEOrderRate_tEdit":
                    {
                        // ---DEL 2009/06/01 --------------------------------->>>>>
                        //if (e.Key == Keys.Down)
                        //{
                        //    if (this.EnableOdrMakerCd1_tNedit.Enabled)
                        //    {
                        //        // 発注可能メーカーコード１にフォーカス遷移
                        //        e.NextCtrl = this.EnableOdrMakerCd1_tNedit;
                        //        break;
                        //    }
                        //}
                        // ---DEL 2009/06/01 ---------------------------------<<<<<
                        // ---ADD 2009/06/01 --------------------------------->>>>>
                        if (((e.Key == Keys.Enter) && (e.ShiftKey == false)) ||
                            ((e.Key == Keys.Tab) && (e.ShiftKey == false)))
                        {
                            // 発注可能メーカータブの場合
                            if (this.Mazda_AnswerAutoDiv_ultraLabel.SelectedTab.Index == 0)
                            {
                                if (this.EnableOdrMakerCd1_tNedit.Enabled)
                                {
                                    e.NextCtrl = this.EnableOdrMakerCd1_tNedit;
                                }
                            }
                            // 三菱・新マツダ・ホンダ項目タブの場合
                            else if (this.Mazda_AnswerAutoDiv_ultraLabel.SelectedTab.Index == 1)
                            {
                                if (this.EmergencyDiv_tComboEditor.Enabled)
                                {
                                    e.NextCtrl = this.EmergencyDiv_tComboEditor;
                                }
                                else if (this.MazdaSectionCode_tEdit.Enabled)
                                {
                                    e.NextCtrl = this.MazdaSectionCode_tEdit;
                                }
                                else if (this.instrumentNo_tEdit.Enabled)
                                {
                                    e.NextCtrl = this.instrumentNo_tEdit;
                                }
                            }
                            // ホンダe-Parts項目タブの場合
                            else
                            {
                                if (this.AnswerSaveFolder_tEdit.Enabled)
                                {
                                    e.NextCtrl = this.AnswerSaveFolder_tEdit;
                                }
                            }
                        }
                        // ---ADD 2009/06/01 ---------------------------------<<<<<

                        break;
                    }
                // ---ADD 2009/06/01 -------------------------------------------------->>>>>
                case "AnswerSaveFolder_tEdit":
                    {
                        if (((e.Key == Keys.Enter) && (e.ShiftKey == false)) ||
                            ((e.Key == Keys.Tab) && (e.ShiftKey == false)))
                        {
                            if (System.IO.Directory.Exists(this.AnswerSaveFolder_tEdit.Text.Trim()))
                            {
                                e.NextCtrl = this.UOELoginUrl_tEdit;
                            }
                            else
                            {
                                e.NextCtrl = this.uButton_AnswerSaveFolder;
                            }
                        }
                        break;
                    }
                // ---ADD 2009/06/01 --------------------------------------------------<<<<<
                // ---ADD 2010/05/14 -------------------------------------------------->>>>>
                // 営業所フラグ
                case "MeiJiUoeEigyousyoFlag_tEdit":
                    {
                        int eigyousyoFlag = 0;
                        int.TryParse(this.MeiJiUoeEigyousyoFlag_tEdit.Text.Trim(), out eigyousyoFlag);
                        if (eigyousyoFlag != 0 && eigyousyoFlag != 1)
                        {
                            this.MeiJiUoeEigyousyoFlag_tEdit.Text = "0";
                        }
                        break;
                    }
                // ---ADD 2010/05/14 --------------------------------------------------<<<<<
            }

            // フォーカス制御
            if (canChangeFocus == false)
            {
                e.NextCtrl = e.PrevCtrl;

                // 現在の項目から移動せず、テキスト全選択状態とする
                e.NextCtrl.Select();
            }

        }

        // 2008.11.06 30413 犬飼 イベントを一括設定したので削除 >>>>>>START
        #region 一括設定のため削除
        ///// <summary>
        ///// GoodsMakerCd_tNedit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : コントロールが編集モードに入る前に発生します。</br>
        ///// <br>Programmer : 30413 犬飼</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void GoodsMakerCd_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocusイベント一時停止
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocusイベント再開
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// UOEShipSectCd_tEdit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : コントロールが編集モードに入る前に発生します。</br>
        ///// <br>Programmer : 30413 犬飼</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void UOEShipSectCd_tEdit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocusイベント一時停止
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocusイベント再開
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// UOESalSectCd_tEdit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : コントロールが編集モードに入る前に発生します。</br>
        ///// <br>Programmer : 30413 犬飼</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void UOESalSectCd_tEdit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocusイベント一時停止
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocusイベント再開
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// UOEReservSectCd_tEdit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : コントロールが編集モードに入る前に発生します。</br>
        ///// <br>Programmer : 30413 犬飼</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void UOEReservSectCd_tEdit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocusイベント一時停止
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocusイベント再開
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// EnableOdrMakerCd1_tNedit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : コントロールが編集モードに入る前に発生します。</br>
        ///// <br>Programmer : 30413 犬飼</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void EnableOdrMakerCd1_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocusイベント一時停止
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocusイベント再開
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// EnableOdrMakerCd2_tNedit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : コントロールが編集モードに入る前に発生します。</br>
        ///// <br>Programmer : 30413 犬飼</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void EnableOdrMakerCd2_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocusイベント一時停止
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocusイベント再開
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// EnableOdrMakerCd3_tNedit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : コントロールが編集モードに入る前に発生します。</br>
        ///// <br>Programmer : 30413 犬飼</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void EnableOdrMakerCd3_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocusイベント一時停止
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocusイベント再開
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// EnableOdrMakerCd4_tNedit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : コントロールが編集モードに入る前に発生します。</br>
        ///// <br>Programmer : 30413 犬飼</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void EnableOdrMakerCd4_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocusイベント一時停止
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocusイベント再開
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// EnableOdrMakerCd5_tNedit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : コントロールが編集モードに入る前に発生します。</br>
        ///// <br>Programmer : 30413 犬飼</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void EnableOdrMakerCd5_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocusイベント一時停止
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocusイベント再開
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// EnableOdrMakerCd6_tNedit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : コントロールが編集モードに入る前に発生します。</br>
        ///// <br>Programmer : 30413 犬飼</br>
        ///// <br>Date       : 2008.06.30</br>
        ///// </remarks>
        //private void EnableOdrMakerCd6_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocusイベント一時停止
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocusイベント再開
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}

        ///// <summary>
        ///// CommAssemblyId_tEdit_BeforeEnterEditMode
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : コントロールが編集モードに入る前に発生します。</br>
        ///// <br>Programmer : 30413 犬飼</br>
        ///// <br>Date       : 2008.07.02</br>
        ///// </remarks>
        //private void CommAssemblyId_tEdit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        //{
        //    // ChangeFocusイベント一時停止
        //    this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

        //    // ChangeFocusイベント再開
        //    this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
        //}
        #endregion
        // 2008.11.06 30413 犬飼 イベントを一括設定したので削除 <<<<<<END
        
        /// <summary>
        /// 依頼者ガイドボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 依頼者ガイドボタン押下時の処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.11.05</br>
        /// </remarks>
        private void uButton_EmployeeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Employee employee = new Employee();
            status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

            // 項目に展開
            if (status == 0)
            {
                this.tEdit_EmployeeCode.DataText = employee.EmployeeCode.TrimEnd();
                this.tEdit_EmployeeName.DataText = employee.Name;

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        # endregion

        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // UOE発注先コード
            int uoeSupplierCd = UOESupplierCd_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsUOESupplierCd = int.Parse((string)this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[i][UOESUPPLIERCD_TITLE]);
                if (uoeSupplierCd == dsUOESupplierCd)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[UOE_SUPPLIER_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのUOE発注先情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // UOE発注先コードのクリア
                        UOESupplierCd_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードのUOE発注先情報が既に登録されています。\n編集を行いますか？",                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // UOE発注先コードのクリア
                                UOESupplierCd_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // ---------------------------- ADD 2009/12/29 xuxh -------------------------------->>>>>
        /// <summary>
        /// 回答保存フォルダボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 回答保存フォルダボタン押下時の処理を行います。</br>
        /// <br>Programmer : xuxh</br>
        /// <br>Date       : 2009/12/29</br>
        /// </remarks>
        private void uButton_AnswerSaveFolder1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dialogResult = fbd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.AnswerSaveFolderOfTOYOTA_tEdit.Text = fbd.SelectedPath;
                this.Revive_Button.Focus();
            }
        }

        // ---------------------------- ADD 2009/12/29 xuxh --------------------------------<<<<<
        // ---ADD 2010/03/08 ---------------------------------------->>>>>
        /// <summary>
        /// 回答保存フォルダボタン押下イベント(日産)
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 回答保存フォルダボタン押下時の処理を行います。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void uButton_NissanAnswerSaveFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dialogResult = fbd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.NissanAnswerSaveFolder_tEdit.Text = fbd.SelectedPath;
                this.Revive_Button.Focus();
            }
        }
        // ---ADD 2010/03/08 ----------------------------------------<<<<<

        // ---ADD 2011/05/10 ----------------------------------------<<<<<
        /// <summary>
        /// 回答保存フォルダボタン押下イベント(マツダ)
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 回答保存フォルダボタン押下時の処理を行います。</br>
        /// <br>Programmer : 施炳中</br>
        /// <br>Date       : 2011/05/10</br>
        /// </remarks>
        private void uButton_MazdaAnswerSaveFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dialogResult = fbd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.MazdaAnswerSaveFolder_tEdit.Text = fbd.SelectedPath;
                this.Revive_Button.Focus();
            }
        }
        // ---ADD 2011/05/10 ----------------------------------------<<<<<
        // ---ADD 2011/10/26 ----------------------------------------<<<<<
        /// <summary>
        /// 登録ダボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 登録ダボタン押下時の処理を行います。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void CarMaker_uButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.UOESupplierCd_tNedit.Text.Trim()))
            {
                TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "発注先コードが未入力です。",           // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.OK);                  // 表示するボタン

            }
            else
            {
                this._pmuoe09020ub = new PMUOE09020UB();
                this._pmuoe09020ub.ShowDialog(this.UOESupplierCd_tNedit.Text);
            }

        }
        /// <summary>
        /// SelectionChanged イベント(Connection_tComboEditor)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : SelectionChangedときに発生します。</br>
        /// <br>Programmer : 葛中華</br>
        /// <br>Date       : 2011/10/26</br>
        /// </remarks>
        private void Connection_tComboEditor_SelectionChanged(object sender, EventArgs e)
        {
            if (Connection_tComboEditor.SelectedIndex == 0)
            {
                this.CarMaker_uLabel.Visible = true;
                this.CarMaker_uButton.Visible = true;
            }
            else
            {
                this.CarMaker_uLabel.Visible = false;
                this.CarMaker_uButton.Visible = false;
            }
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
            // 接続区分がCタイプの場合のみBL管理ユーザーコードを表示させる
            if (Connection_tComboEditor.SelectedIndex == 2)
            {
                this.BLMngUserCode_uLabel.Visible = true;
                this.BLMngUserCode_tEdit.Visible = true;
            }
            else
            {
                this.BLMngUserCode_uLabel.Visible = false;
                this.BLMngUserCode_tEdit.Visible = false;
            }
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
        }
        // ---ADD 2011/10/26 ----------------------------------------<<<<<
		// ---ADD 2010/04/23 ---------------------------------------->>>>>
		/// <summary>
		/// 回答保存フォルダボタン押下イベント(三菱)
		/// </summary>
		/// <param name="sender">コントロール</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note       : 回答保存フォルダボタン押下時の処理を行います。</br>
		/// <br>Programmer : jiangk</br>
		/// <br>Date       : 2010/04/23</br>
		/// </remarks>
		private void uButton_MitsubishiAnswerSaveFolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			DialogResult dialogResult = fbd.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				this.MitsubishiAnswerSaveFolder_tEdit.Text = fbd.SelectedPath;
				this.Revive_Button.Focus();
			}
        }

		// ---ADD 2010/04/23 ----------------------------------------<<<<<
        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END

       
    }
}
